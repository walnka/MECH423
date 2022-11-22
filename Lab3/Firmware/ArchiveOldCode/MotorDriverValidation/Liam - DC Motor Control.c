#include <msp430.h> 



unsigned volatile int circBuffer[50];                           // For storing received data packets
unsigned volatile int head = 0;                                 // circBuffer head
unsigned volatile int tail = 0;                                 // circBuffer tail
unsigned volatile int length = 0;                               // circBuffer length
unsigned volatile char* bufferFullMsg = "Buffer is full";       // Message to print when buffer is full
unsigned volatile char* bufferEmptyMsg = "Buffer is empty";     // Message to print when buffer is empty
unsigned volatile int rxByte = 0;                               // Temporary variable for storing each received byte
volatile int rxFlag;                                            // Received data flag, triggered when a packet is received
volatile int rxIndex;                                           // Counts bytes in data packet


int main(void)
{
    WDTCTL = WDTPW | WDTHOLD;   // stop watchdog timer

    // Configure clocks
    CSCTL0 = 0xA500;                        // Write password to modify CS registers
    CSCTL1 = DCOFSEL0 + DCOFSEL1;           // DCO = 8 MHz
    CSCTL2 = SELM_3 + SELS_3 + SELA_3;      // MCLK = DCO, ACLK = DCO, SMCLK = DCO
    CSCTL3 = DIVM_4 + DIVS_4 + DIVA_4;      // Set all dividers

    // Configure timer B
    TB1CTL = TBSSEL_2 + MC_2 + TBCLR;       // SMCLK, continuous mode, clear TBR
    TB1CCTL1 = OUTMOD_7;                    // CCR1 reset/set
    TB1CCR1 = 1000;                         // CCR1 PWM duty cycle

    // Configure outputs
    P2SEL0 |= BIT1;

    P3DIR |= BIT6 + BIT7;                   // Output pins for AIN2 and AIN1 respectively


//    // Set P1.6 as input
//    P1SEL0 |= BIT6;
//    P1SEL1 |= BIT6;

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
            circBuffer[head] = rxByte;      // Buffer gets received byte at head
            length++;                       // Increment length

            if (head == 50) { head = 0; }   // Check if head at end of buffer and if so put it at start
            else { head++; }                // Else, increment head

            // Check if receiving index is 4 or greater and if so reset
            if (rxIndex >= 4)
            {
                rxIndex = 0;                // Reset receiving index
                rxFlag = 1;                 // Set the data received flag
            }
            else { rxIndex++; }             // Increment rxIndex
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
