#include <msp430.h> 


const int bufferSize = 50;
unsigned volatile int rxByte = 0;
unsigned volatile int circBuffer[50];
unsigned volatile int head = 0;
unsigned volatile int tail = 0;
unsigned volatile int length = 0;
unsigned volatile char* bufferFullMsg = "Buffer is full";
unsigned volatile char* bufferEmptyMsg = "Buffer is empty";
volatile int rxFlag;
volatile int rxIndex;
unsigned volatile int number;


int main(void)
{
    WDTCTL = WDTPW | WDTHOLD;   // stop watchdog timer

    // Configure PJ.0 as an output
    PJDIR |= BIT0;

    // Configure clocks
    CSCTL0 = 0xA500;                        // Write password to modify CS registers
    CSCTL1 = DCOFSEL0 + DCOFSEL1;           // DCO = 8 MHz
    CSCTL2 = SELM0 + SELM1 + SELA0 + SELA1 + SELS0 + SELS1; // MCLK = DCO, ACLK = DCO, SMCLK = DCO
    CSCTL3 = DIVS_4;      // set all dividers

    // Configure timer B
    TB1CTL = TBSSEL_2 + MC_1 + TBCLR;       // SMCLK, up mode, clear TAR
    TB1CCR0 = 0xFFFF;                       // PWM Period
    TB1CCTL1 = OUTMOD_7;                    // CCR1 reset/set
    TB1CCR1 = 1000;                            // CCR1 PWM duty cycle

//    // Set up Timer A
//    // SMCLK as Timer A clock, up mode, clear TAR, enable interrupt
//    TA0CTL |= TASSEL_2 + MC_2 + TACLR + TAIE;
//    TA0CCTL0 |= CM_3 + CCIS_0 + SCS + SCCI + CAP + CCIE;

    P3DIR |= BIT4;                     // P3.4 & P3.5 output
    P3SEL0 |= BIT4;                    //

    // Set P1.6 as input
    P1SEL0 |= BIT6;
    P1SEL1 |= BIT6;


    // Configure ports for UART
    P2SEL0 &= ~(BIT0 + BIT1);
    P2SEL1 |= BIT0 + BIT1;

    // Configure UART
    UCA0CTLW0 |= UCSSEL0;
    UCA0MCTLW = UCOS16 + UCBRF0 + 0x4900;
    UCA0BRW = 52;
    UCA0CTLW0 &= ~UCSWRST;
    UCA0IE |= UCRXIE;                       //enable UART receive interrupt
    _EINT();                                //Global interrupt enable

    // data processing variables
    unsigned volatile int commandByte, dataByte1, dataByte2, escapeByte, dataByte;

    while (1)
    {
        if (rxFlag)
        {
            // Get escape byte and command byte from buffer
            escapeByte = circBuffer[head - 1];
            commandByte = circBuffer[head - 4];

            // Check if command byte is 2 and if so turn on LED1
            if (commandByte == 2) { PJOUT |= BIT0; }
            // Else, check if command byte is 3 and if so turn off LED1
            else if (commandByte == 3) { PJOUT &= ~BIT0; }
            // Else, handle the data bytes
            else
            {
                // Check if the first bit of escape byte is 1 and if so set dataByte2 to 255
                if (escapeByte & 1) { dataByte2 = 255; }
                // Else, dataByte2 gets the value from the buffer
                else { dataByte2 = circBuffer[head - 2]; }
                // Check if the second bit of escape byte is 1 and if so set dataByte1 to 255
                if (escapeByte & 2) { dataByte1 = 255; }
                // Else, dataByte1 gets the value from the buffer
                else { dataByte1 = circBuffer[head - 3]; }

                // DataByte gets the combination of dataByte1 & dataByte2
                dataByte = (dataByte1 << 8) + dataByte2;
                // Set the timer period to dataByte
                TB1CCR1 = dataByte;
            }

//            // Remove the processed bytes from the buffer
//            length -= 5;                        // Decrease length by 5
//            if (50 - tail <= 5) { tail = 0; }   // Check if tail at end of buffer and if so put it at start
//            else { tail += 5; }                 // Else, increase tail by 5
//
            // reset the data received flag
            rxFlag = 0;
        }
    }
    return 0;
}

#pragma vector = USCI_A0_VECTOR
__interrupt void USCI_A0_ISR(void)
{
    rxByte = UCA0RXBUF;                 // rxByte gets the received byte

    // Check if 255 was received
    if (rxByte == 255 || rxIndex > 0)
    {
        // Check that the buffer isn't full
        if (length < bufferSize)
        {
            //while (!(UCA0IFG & UCTXIFG));   // Wait for the transmit IFG to be zero

            circBuffer[head] = rxByte;      // Buffer gets received byte at head
            length++;                       // Increment length

            if (head == 50) { head = 0; }   // Check if head at end of buffer and if so put it at start
            else { head++; }                // Else, increment head

            // Check if rxIndex is 4 or greater and if so reset
            if (rxIndex >= 4)
            {
                rxIndex = 0;
                rxFlag = 1;                   // Set the data received flag
            }
            else { rxIndex++; }          // Increment rxIndex
        }
        else
        {
            // Loop through the buffer full message and print it
            int i = 0;
            while (bufferFullMsg[i] != '\0')
            {
                UCA0TXBUF = bufferFullMsg[i];
                while (!(UCA0IFG & UCTXIFG));
                i++;
            }

            // New line
            UCA0TXBUF = '\r';
            while (!(UCA0IFG & UCTXIFG));
            UCA0TXBUF = '\n';
            while (!(UCA0IFG & UCTXIFG));
        }
    }
}

//#pragma vector = TIMER0_A0_VECTOR;
//__interrupt void TA0CCR0_ISR(void)
//{
//    if (TA0CCTL0 & CCI)
//    {
//        TA0R = 0x0000;
//    }
//    else
//    {
//        number = TA0R;
//    }
//
//    TA0CCTL0 &= ~(CCIFG);
//
//}
