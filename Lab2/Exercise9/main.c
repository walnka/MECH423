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

int main(void)
{
	WDTCTL = WDTPW | WDTHOLD;	// stop watchdog timer

	//Configure Clocks
	//Configure Clocks
    CSCTL0_H = 0xA5;
    CSCTL1 = DCOFSEL0 + DCOFSEL1;
    CSCTL2 = SELM0 + SELM1 + SELA0 + SELA1 + SELS0 + SELS1;

	//Configure UART
    UCA0CTLW0 |= UCSSEL0;
    UCA0MCTLW = UCOS16 + UCBRF0 + 0x4900;
    UCA0BRW = 52;
    UCA0CTLW0 &= ~UCSWRST;
    UCA0IE |= UCRXIE;

    //Configure P2.0(TX) and P2.1(RX) as UART pins
    P2SEL1 |= BIT0 + BIT1;
    P2SEL0 &= ~(BIT0 + BIT1);

    _EINT();

    while(1);

}

#pragma vector = USCI_A0_VECTOR
__interrupt void USCI_A0_ISR(void)
{
    unsigned char RxByte = 0;
    RxByte = UCA0RXBUF;
    if (RxByte == RETURN){
        // Assign next head
        unsigned volatile char* nextHead;
        if (head == &buffer[BUFFER_SIZE-1]){
            nextHead = &buffer[0];
        }
        else{
            nextHead = head + 1;
        }

        if (head == tail){
            int i = 0;
            while (emptyMessage[i] != '\0'){
                UCA0TXBUF = emptyMessage[i];
                while (!(UCA0IFG & UCTXIFG));
                i++;
            }
            UCA0TXBUF = '\r';
            while (!(UCA0IFG & UCTXIFG));
            UCA0TXBUF = '\n';
            while (!(UCA0IFG & UCTXIFG));
        }
        else{
            UCA0TXBUF = *head;
            while (!(UCA0IFG & UCTXIFG));
            head = nextHead;
        }
    }
    else{
        // Assign Next Tail
        unsigned volatile char* nextTail;
        if (tail == &buffer[BUFFER_SIZE-1]){
            nextTail = &buffer[0];
        }
        else{
            nextTail = tail + 1;
        }

        if (nextTail == head){
            int j = 0;
            while (fullMessage[j] != '\0'){
                UCA0TXBUF = fullMessage[j];
                while (!(UCA0IFG & UCTXIFG));
                j++;
            }
            UCA0TXBUF = '\r';
            while (!(UCA0IFG & UCTXIFG));
            UCA0TXBUF = '\n';
            while (!(UCA0IFG & UCTXIFG));
        }
        else{
            *tail = RxByte;
            tail = nextTail;
        }
    }
}
