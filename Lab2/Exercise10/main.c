#include <msp430.h> 


/**
 * main.c
 */
#define RETURN 13
#define BUFFER_SIZE 50
unsigned volatile char buffer[BUFFER_SIZE];
unsigned volatile char* head = &buffer[0];
unsigned volatile char* tail = &buffer[0];
unsigned volatile char* fullMessage = "Buffer is Full";
unsigned volatile char* emptyMessage = "Buffer is Empty";

// Define packet vars
unsigned volatile char commandByte;
unsigned volatile int byte1;
unsigned volatile int byte2;
unsigned volatile char escapeByte;

unsigned volatile int result = 0;

unsigned volatile int state = 0;

unsigned volatile int TimerCount = 0;


int main(void)
{
    WDTCTL = WDTPW | WDTHOLD;   // stop watchdog timer

    //Configure Clocks
    CSCTL0_H = 0xA5;
    CSCTL1 = DCOFSEL0 + DCOFSEL1;
    CSCTL2 = SELM0 + SELM1 + SELA0 + SELA1 + SELS0 + SELS1;
    CSCTL3 = DIVS_4;

    //Configure UART
    UCA0CTLW0 |= UCSSEL0;
    UCA0MCTLW = UCOS16 + UCBRF0 + 0x4900;
    UCA0BRW = 52;
    UCA0CTLW0 &= ~UCSWRST;
    UCA0IE |= UCRXIE;

    //Configure P2.0(TX) and P2.1(RX) as UART pins
    P2SEL1 |= BIT0 + BIT1;
    P2SEL0 &= ~(BIT0 + BIT1);

    // Setup Timer B
    TB1CTL = TBSSEL_2 + MC_1 + TBCLR;
    TB1CCTL1 = OUTMOD_7;
    TB1CCTL2 = OUTMOD_7;
    TB1CCR0 = 0xFFFF;
    TB1CCR1 = 0;

    // Configure P3.4 for Timer B Output
    P3DIR |= BIT4;
    P3SEL0 |= BIT4;

    // Setup Timer A
    TA0CTL = TASSEL_2 + MC_2 + TACLR;
    TA0CCTL0 |= CM_3 + CCIS_0 + SCS + CAP + CCIE + SCCI;

    // Configure P1.6 for Timer A input
    P1SEL0 |= BIT6;
    P1SEL1 |= BIT6;

    // Setup LED1 for output
    PJDIR |= BIT0;
    PJOUT &= ~(BIT0);

    _EINT();

    while(1){
        // Assign Next Head
        unsigned volatile char* nextHead;
        if (head == &buffer[BUFFER_SIZE-1]){
            nextHead = &buffer[0];
        }
        else{
            nextHead = head + 1;
        }

        switch (state)
        {
        case 0: // Wait for starting byte
            if (*head == 255){
                state = 1;
            }
            else if (nextHead < tail){
                head = nextHead;
            }
            break;

        case 2:
            commandByte = *head;
            if (commandByte == 0x02){
                PJOUT |= BIT0;
            }
            else if (commandByte == 0x03){
                PJOUT &= ~BIT0;
            }
            state = 3;
            break;

        case 4:
            byte1 = *head;
            state = 5;
            break;

        case 6:
            byte2 = *head;
            state = 7;
            break;

        case 8:
            escapeByte = *head;
            if (escapeByte & BIT0){
                byte2 = 255;
            }
            if (escapeByte & BIT1){
                byte1 = 255;
            }
            result = (byte1<<8) + byte2;
            TB1CCR1 = result;
            state = 0;
            break;

        default:
            if (nextHead < tail){
                head = nextHead;
                state++;
            }
            break;
        }
    }

}

#pragma vector = USCI_A0_VECTOR
__interrupt void USCI_A0_ISR(void)
{
    unsigned char RxByte = 0;
    RxByte = UCA0RXBUF;
    // Assign Next Tail
    unsigned volatile char* nextTail;
    if (tail == &buffer[BUFFER_SIZE-1]){
        nextTail = &buffer[0];
    }
    else{
        nextTail = tail + 1;
    }

    // Add new byte to buffer
    if (nextTail == head){
        int j = 0;
        while (fullMessage[j] != '\0'){
            UCA0TXBUF = fullMessage[j];
            while (!(UCA0IFG & UCTXIFG));
            j++;
        }
    }
    else{
        *tail = RxByte;
        tail = nextTail;
    }
}

#pragma vector = TIMER0_A0_VECTOR
__interrupt void TriggerTimer (void){
    if (TA0CCTL0 & CCI){
        TA0R = 0x0000;
    }
    else{
        TimerCount = TA0R;
    }
    TA0CCTL0 &= ~CCIFG;
}
