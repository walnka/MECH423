#include <msp430.h> 


#define bufferSize 150
#define numPhases 8
#define maxEncoderJump 300
const double locErrorTolerance = 0.1;
const int offsetZero = 0;
const double x_rise_time = 1;
const double fiveMSscale = 0x9C4/0xFFFF;
const double hundredMSscale = 0xC350/0xFFFF;

// Control Constants
const double Kd = 0xFFFF/123;
const double Kdy = 0xFFFF/123*2*20/400;
const double Kenc = (4*40)/(20.4*48);
const double Kv = 0.00314;
const double tau = 0.02375;
const double Kp = 1/0.02375*0.2;


// UART Variables
unsigned volatile int circBuffer[bufferSize];                   // For storing received data packets
unsigned volatile int head = 0;                                 // circBuffer head
unsigned volatile int tail = 0;                                 // circBuffer tail
unsigned volatile int length = 0;                               // circBuffer length
unsigned volatile char* bufferFullMsg = "Buffer is full";       // Message to print when buffer is full
unsigned volatile char* bufferEmptyMsg = "Buffer is empty";     // Message to print when buffer is empty
unsigned volatile int rxByte = 0;                               // Temporary variable for storing each received byte
volatile int rxFlag = 0;                                            // Received data flag, triggered when a packet is received
volatile int rxIndex = 0;                                           // Counts bytes in data packet

// Stepper Control Variables
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

// Variables for X Control
unsigned int currentTA0, currentTA1, prevTA0, prevTA1;
unsigned volatile int xr = 0;
unsigned volatile int xControlFlag = 0;

// Variables for Y Control
const double mmPerHalfStep = 2*20/400;
unsigned volatile int yr = 0;
unsigned volatile int yControlFlag = 0;
unsigned int yLoc = 0;

void updateStepperCoils(){
    if (halfStepLookupTable[yLoc%numPhases][0] == 1)
        P1OUT |= BIT4;
    else
        P1OUT &= ~BIT4;
    if (halfStepLookupTable[yLoc%numPhases][1] == 1)
        P1OUT |= BIT5;
    else
        P1OUT &= ~BIT5;
    if (halfStepLookupTable[yLoc%numPhases][2] == 1)
        P3OUT |= BIT4;
    else
        P3OUT &= ~BIT4;
    if (halfStepLookupTable[yLoc%numPhases][3] == 1)
        P3OUT |= BIT5;
    else
        P3OUT &= ~BIT5;
}

void transmitPackage(unsigned int instrByte, unsigned int dataByte1, unsigned int dataByte2){
    unsigned int decoderByte = 0;
    if (dataByte1 == 255){
        decoderByte |= 2;
        dataByte1 = 0;
    }
    if (dataByte2 == 255){
        decoderByte |= 1;
        dataByte2 = 0;
    }
    while (!(UCA1IFG & UCTXIFG));
    UCA1TXBUF = 255;
    while (!(UCA1IFG & UCTXIFG));
    UCA1TXBUF = instrByte;
    while (!(UCA1IFG & UCTXIFG));
    UCA1TXBUF = dataByte1;
    while (!(UCA1IFG & UCTXIFG));
    UCA1TXBUF = dataByte2;
    while (!(UCA1IFG & UCTXIFG));
    UCA1TXBUF = decoderByte;
    while (!(UCA1IFG & UCTXIFG));
}


int main(void)
{
    WDTCTL = WDTPW | WDTHOLD;   // stop watchdog timer

    // Configure clocks
    CSCTL0 = 0xA500;                        // Write password to modify CS registers
    CSCTL1 |= DCOFSEL0 + DCOFSEL1;           // DCO = 8 MHz
    CSCTL2 |= SELM_3 + SELS_3 + SELA_3;      // MCLK = DCO, ACLK = DCO, SMCLK = DCO
    CSCTL3 |= DIVS_4;      // Set all dividers

    // Configure timer B2 for DC Motor
    TB2CTL |= TBSSEL_2 + MC_1 + TBIE;               // SCLK, up mode
    TB2CCTL1 |= OUTMOD_7;                    // CCR1 reset/set + CLLD_1
    TB2CCR0 = 0xC350;                       // CCR0 reset at Max
    TB2CCR1 = 0x9C40 * 0xC350/0xFFFF;                            // CCR1 PWM duty cycle

    // Configure timer B0 for Stepper Motor
    TB0CTL |= TBSSEL_1 + MC_1;               // ACLK, up mode
    TB0CCTL0 |= CCIE;                        // CCR1 reset/set
    TB0CCR0 = 0x9C40;                       // CCR1 PWM Duty Cycle

    // Configure outputs for DC PWM Pin
    P2SEL0 |= BIT1;
    P2DIR |= BIT1;

    // Configure outputs for DC AIN1 and AIN2 Pins
    P3DIR |= BIT6 + BIT7;                   // Output pins for AIN2 and AIN1 respectively

    // Configure outputs for Stepper A1 A2 B1 B2 Pins
    P1DIR |= BIT4 + BIT5;                   // AIN2 and AIN1 Pins respectively
    P3DIR |= BIT4 + BIT5;                   // BIN2 and BIN1 Pins respectively

    // Configure Timers for DC Encoder
    // Timer A0 for DWN Encoder
    TA0CTL |= TASSEL_0 + MC_1 + TACLR;
    TA0CCR0 = 0xFFFF;
    // Timer A1 for UP Encoder
    TA1CTL |= TASSEL_0 + MC_1 + TACLR;
    TA1CCR0 = 0xFFFF;

    // Configure Timer for Duty Cycle of Stepper Pins
    TB1CTL |= TBSSEL_1 + MC_1 + ID_2;
    TB1CCTL0 = CCIE;
    TB1CCTL1 = CCIE;
    TB1CCR0 = 0x7D0;// 5ms 0x9C4; //0xC350; // Interrupt every 100ms
    TB1CCR1 = 0x238; // Every 25% duty cycle

    // Setup Pins for DC Encoder Interrupt Capture
    P1SEL1 |= BIT1 + BIT2;

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
                xControlFlag = 0;
                TB2CCR1 = 0;
                break;
            case 1: // CW DC Motor
                P3OUT |= BIT7;
                P3OUT &= ~BIT6;
                TB2CCR1 = dataByte * 0.7629;
                break;
            case 2: // CCW DC Motor
                P3OUT |= BIT6;
                P3OUT &= ~BIT7;
                TB2CCR1 = dataByte * 0.7629;
                break;
            case 3: // Single Step CW
                contStepperMode = 2;
                yLoc++;
                break;
            case 4: // Single Step CCW
                contStepperMode = 2;
                yLoc--;
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
            case 8: // Zero the Encoder
                TA0R = offsetZero;
                TA1R = 0;
                currentTA0 = 0;
                currentTA1 = 0;
                prevTA0 = offsetZero;
                prevTA1 = 0;
                break;
            case 9: // Go To X Loc
                xr = dataByte;
                TB2CCR0 = 0x9C4;// 5ms 0x9C4; //0xC350; // Interrupt every 100ms
                xControlFlag = 1;
                break;
            case 10: // Zero The Stepper
                while(yLoc%8 != 1){
                    yLoc++;
                }
                yLoc = 0;
                break;
            case 11: // Go To Y Loc
                yr = dataByte/Kdy;
                transmitPackage(3, (int)Kdy>>8, (int)Kdy & 0xFF);
                transmitPackage(1, yr>>8, yr & 0xFF);
                transmitPackage(2, yLoc>>8, yLoc & 0xFF);
                yControlFlag = 1;
                TB0CCR0 = 0xFFFF - 0xBD4C;
                if (yLoc < yr){
                    contStepperMode = 1;
                }
                else if (yLoc > yr){
                    contStepperMode = -1;
                }
                break;
            default: // No known command
                break;
            }

//             Remove the processed bytes from the buffer
            length -= 5;                        // Decrease length by 5
            if (bufferSize - tail <= 5) { tail = 0; }   // Check if tail at end of buffer and if so put it at start
            else { tail += 5; }                 // Else, increase tail by 5

            // reset the data received flag
            rxFlag = 0;
        }
    }
    return 0;
}

#pragma vector = USCI_A1_VECTOR
__interrupt void USCI_A1_ISR(void)
{
//    while (!(UCA1IFG & UCRXIFG));
    rxByte = UCA1RXBUF;                 // rxByte gets the received byte

    // Check if 255 was received
    if (rxByte == 255 || rxIndex > 0)
    {
        // Check that the buffer isn't full
        if (length < bufferSize)
        {
            circBuffer[head] = rxByte;      // Buffer gets received byte at head
            length++;                       // Increment length

            if (head == bufferSize) { head = 0; }   // Check if head at end of buffer and if so put it at start
            else { head++; }                // Else, increment head

            // Check if receiving index is 4 or greater and if so reset
            if (rxIndex >= 4)
            {
                rxIndex = 0;                // Reset receiving index
                rxFlag = 1;                 // Set the data received flag
            }
            else { rxIndex++; }             // Increment rxIndex
        }
    }
}
#pragma vector = TIMER0_B0_VECTOR
__interrupt void TriggerTimer (void){
    if (contStepperMode == 1){
        yLoc++;
    }
    else if (contStepperMode == -1){
        yLoc--;
    }
    if (yControlFlag == 1 && yLoc == yr){
        yControlFlag = 0;
        contStepperMode = 0;
    }

    TB0CCTL0 &= ~CCIFG;
}

// Timer interrupt to send Encoder Count Transmits every 100ms
// Y axis: 188mm Pitch: 2mm Teeth: 20
// rot/full travel = 188/2/20 = 4.7
// gear ratio: 20.4:1 rotMotor/full travel = 20.4*4.7 = 95.88
// 48 counts/rev * 95.88 = 4602.24
#pragma vector = TIMER2_B1_VECTOR
__interrupt void SendEncoderCount(void){
    unsigned int instructionByte = 0;
    TA0CTL &= MC_0;
    TA1CTL &= MC_0;
    currentTA0 = TA0R;
    currentTA1 = TA1R;
    TA0CTL |= MC_1;
    TA1CTL |= MC_1;
    unsigned int encoderCount = currentTA0 - currentTA1;
    if (currentTA1 > currentTA0){
        encoderCount = 0;
    }
    // Do Controls for DC Motor
    if (xControlFlag == 1){
        instructionByte = 1;
        int error = xr - (encoderCount-offsetZero)*Kenc*Kd;
        TB2CCR1 = (abs(error)*Kp) * 0x9C4/0xFFFF;
        if (error > locErrorTolerance*Kd){
            P3OUT |= BIT7;
            P3OUT &= ~BIT6;
        }
        else if (error < -locErrorTolerance*Kd){
            P3OUT |= BIT6;
            P3OUT &= ~BIT7;
        }
        else{
            P3OUT &= ~(BIT6 + BIT7);
            TB2CCR0 = 0xC350;// 5ms 0x9C4; //0xC350; // Interrupt every 100ms
            xControlFlag = 0;
        }
    }
    transmitPackage(instructionByte, encoderCount>>8, encoderCount & 0xFF);
    TB2CTL &= ~TBIFG;
}

#pragma vector = TIMER1_B1_VECTOR
__interrupt void TurnOffStepperPhases(void){
    P1OUT &= ~(BIT4 + BIT5);
    P3OUT &= ~(BIT4 + BIT5);
    TB1CCTL1 &= ~CCIFG;
}

#pragma vector = TIMER1_B0_VECTOR
__interrupt void TurnOnStepperPhases(void){
    if (contStepperMode != 0){
        updateStepperCoils();
    }
    TB1CCTL0 &= ~CCIFG;
}

