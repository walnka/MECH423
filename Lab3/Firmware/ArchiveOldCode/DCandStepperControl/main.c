#include <msp430.h> 


#define bufferSize 150
#define numPhases 8

unsigned volatile int circBuffer[bufferSize];                   // For storing received data packets
unsigned volatile int head = 0;                                 // circBuffer head
unsigned volatile int tail = 0;                                 // circBuffer tail
unsigned volatile int length = 0;                               // circBuffer length
unsigned volatile char* bufferFullMsg = "Buffer is full";       // Message to print when buffer is full
unsigned volatile char* bufferEmptyMsg = "Buffer is empty";     // Message to print when buffer is empty
unsigned volatile int rxByte = 0;                               // Temporary variable for storing each received byte
volatile int rxFlag;                                            // Received data flag, triggered when a packet is received
volatile int rxIndex = 0;                                           // Counts bytes in data packet
unsigned int halfStepLookupTable[numPhases][4] =
{
 // Full Step
// {1, 0, 0, 0},
// {0, 0, 1, 0},
// {0, 1, 0, 0},
// {0, 0, 0, 1}
 // Half Step
 {1, 0, 0, 0},
 {1, 0, 1, 0},
 {0, 0, 1, 0},
 {0, 1, 1, 0},
 {0, 1, 0, 0},
 {0, 1, 0, 1},
 {0, 0, 0, 1},
 {1, 0, 0, 1}
};
unsigned volatile int stepperState = 0;
unsigned volatile int stepperStateChange = 1;
volatile int contStepperMode = 0;

void updateStepperCoils(){
    if (halfStepLookupTable[stepperState][0] == 1)
        P1OUT |= BIT4;
    else
        P1OUT &= ~BIT4;
    if (halfStepLookupTable[stepperState][1] == 1)
        P1OUT |= BIT5;
    else
        P1OUT &= ~BIT5;
    if (halfStepLookupTable[stepperState][2] == 1)
        P3OUT |= BIT4;
    else
        P3OUT &= ~BIT4;
    if (halfStepLookupTable[stepperState][3] == 1)
        P3OUT |= BIT5;
    else
        P3OUT &= ~BIT5;
}


int main(void)
{
    WDTCTL = WDTPW | WDTHOLD;   // stop watchdog timer

    // Configure clocks
    CSCTL0 = 0xA500;                        // Write password to modify CS registers
    CSCTL1 = DCOFSEL0 + DCOFSEL1;           // DCO = 8 MHz
    CSCTL2 = SELM_3 + SELS_3 + SELA_3;      // MCLK = DCO, ACLK = DCO, SMCLK = DCO
    CSCTL3 |= DIVS_4;      // Set all dividers

    // Configure timer B for DC Motor
    TB2CTL = TBSSEL_1 + MC_2 + TBCLR;       // SMCLK, continuous mode, clear TBR
    TB2CCTL1 = OUTMOD_7;                    // CCR1 reset/set
    TB2CCR1 = 0;                         // CCR1 PWM duty cycle

    // Configure timer A for Stepper Motor
    TB0CTL = TBSSEL_1 + MC_1 + TBCLR;       // SMCLK, continuous mode, clear TBR
    TB0CCTL0 = CCIE;                    // CCR1 reset/set
    TB0CCR0 = 0x9C40;                            // CCR1 PWM Duty Cycle

    // Configure outputs for DC PWM Pin
    P2SEL0 |= BIT1;
    P2DIR |= BIT1;

    // Configure outputs for DC AIN1 and AIN2 Pins
    P3DIR |= BIT6 + BIT7;                   // Output pins for AIN2 and AIN1 respectively

    // Configure outputs for Stepper A1 A2 B1 B2 Pins
    P1DIR |= BIT4 + BIT5;                   // AIN2 and AIN1 Pins respectively
    P3DIR |= BIT4 + BIT5;                   // BIN2 and BIN1 Pins respectively

    // Configure ports for UART
    P2SEL0 &= ~(BIT5 + BIT6);
    P2SEL1 |= BIT5 + BIT6;

    // Configure UART
    UCA1CTLW0 |= UCSSEL0;
    UCA1MCTLW = UCOS16 + UCBRF0 + 0x4900;
    UCA1BRW = 52;
    UCA1CTLW0 &= ~UCSWRST;
    UCA1IE |= UCRXIE;                       //enable UART receive interrupt
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

            // Handle the Data Bytes
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


            // Handle the command Bytes
            switch(commandByte)
            {
            case 0: // Stop DC Motor
                P3OUT &= ~(BIT6 + BIT7);
                TB2CCR1 = 0xFFFF;
                break;
            case 1: // CW DC Motor
                P3OUT |= BIT7;
                P3OUT &= ~BIT6;
                TB2CCR1 = dataByte;
                break;
            case 2: // CCW DC Motor
                P3OUT |= BIT6;
                P3OUT &= ~BIT7;
                TB2CCR1 = dataByte;
                break;
            case 3: // Single Step CW
                contStepperMode = 0;
                if (stepperState == numPhases -1)
                    stepperState = 0;
                else
                    stepperState++;
                break;
            case 4: // Single Step CCW
                contStepperMode = 0;
                if (stepperState == 0)
                    stepperState = numPhases-1;
                else
                    stepperState--;
                break;
            case 5: // Continuous Step CW
                contStepperMode = 1;
                TB0CCR0 = 0xFFFF - dataByte;
                break;
            case 6: // Continuous Step CCW
                contStepperMode = -1;
                TB0CCR0 = 0xFFFF - dataByte;
                break;
            case 7: // Stop Stepper Continuous
                contStepperMode = 0;
                break;
            default: // No known command
                break;
            }

            // Remove the processed bytes from the buffer
            length -= 5;                        // Decrease length by 5
            if (bufferSize - tail <= 5) { tail = 0; }   // Check if tail at end of buffer and if so put it at start
            else { tail += 5; }                 // Else, increase tail by 5

            // reset the data received flag
            rxFlag = 0;
        }
        if (contStepperMode == 0){
              updateStepperCoils();
        }
    }
    return 0;
}

#pragma vector = USCI_A1_VECTOR
__interrupt void USCI_A1_ISR(void)
{
    rxByte = UCA1RXBUF;                 // rxByte gets the received byte

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
                UCA1TXBUF = bufferFullMsg[i];
                while (!(UCA1IFG & UCTXIFG));
                i++;
            }

            // New line
            UCA1TXBUF = '\r';
            while (!(UCA1IFG & UCTXIFG));
            UCA1TXBUF = '\n';
            while (!(UCA1IFG & UCTXIFG));
        }
    }
}
#pragma vector = TIMER0_B0_VECTOR
__interrupt void TriggerTimer (void){
    if (contStepperMode == 1){
        if (stepperState == numPhases - 1)
            stepperState = 0;
        else
            stepperState++;
    }
    else if (contStepperMode == -1){
        if (stepperState == 0)
            stepperState = numPhases - 1;
        else
            stepperState--;
    }
    if (contStepperMode != 0){
        updateStepperCoils();
    }

    TB0CCTL0 &= ~CCIFG;
}

