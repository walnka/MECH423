#include <msp430.h> 

volatile long finalTemp = 0;
volatile long tempOne = 0;
volatile long tempTwo = 0;
volatile long tempThree = 0;
voltaile long tempFour = 0;

int main(void)
{
    WDTCTL = WDTPW | WDTHOLD;   // stop watchdog timer

    //Pin Configuration
    P1DIR |= BIT7;
    P1SEL0 |= BIT7;
    P1SEL1 |= BIT7;
    P1OUT &= ~BIT7;

    P3DIR |= (BIT4 + BIT5 + BIT6 + BIT7);
    P3OUT &= ~(BIT4 + BIT5 + BIT6 + BIT7);

    PJDIR |= (BIT0 + BIT1 + BIT2 + BIT3);
    PJOUT &= ~(BIT0 + BIT1 + BIT2 + BIT3);

    // Setup Clock
    CSCTL0 = 0xA500;
    CSCTL1 = DCOFSEL0 + DCOFSEL1;                           // DCO = 8 MHz
    CSCTL2 = SELM0 + SELM1 + SELA0 + SELA1 + SELS0 + SELS1; // MCLK = DCO, ACLK = DCO, SMCLK = DCO
    CSCTL3 = DIVS__8; //Make SMCLK 1MHz

    //UART
    //Configure UART
    UCA0CTLW0 |= UCSSEL0;
    UCA0MCTLW = UCOS16 + UCBRF0 + 0x4900;
    UCA0BRW = 52;
    UCA0CTLW0 &= ~UCSWRST;
    UCA0IE |= UCRXIE;

    //Configure P2.0 and P2.1 as UART pins
    P2SEL1 |= BIT0 + BIT1;
    P2SEL0 &= ~(BIT0 + BIT1);

    //Temperature Sensor
    while(REFCTL0 & REFGENBUSY);
    REFCTL0 |= REFVSEL_0+REFON;

    //ADC
    P2DIR |= BIT7; // Pin to power ADC
    P2OUT |= BIT7;
    ADC10CTL0 &= ~(ADC10ENC);   //Turning Enable Conversion off for Editing
    ADC10CTL0 = ADC10SHT_8;     //16 samples
    ADC10CTL1 = ADC10CONSEQ_0 + ADC10SHP;
    ADC10CTL2 = ADC10RES;
    ADC10MCTL0 = ADC10INCH_4; // Set channel to 4 for temperature sensor

    // Setup Timer
    TA1CTL |= MC__UP + TASSEL__SMCLK + TACLR;
    TA1CCTL0 |= CCIE + OUTMOD_3;
    TA1CCR0 = 40000;

    //Start interrupts and ADC
    TA1CCTL0 &= ~CCIFG;
    ADC10IE |= BIT0;
    ADC10CTL0 |= ADC10ON;
    ADC10CTL0 |= ADC10ENC | ADC10SC;
    ADC10IFG &= ~ADC10IFG0;

    //Global Interrupts
    _EINT();

    int value = 163;
    int subvalue = 3;

    while(1)
    {
        // Min Temp Value
        if (finalTemp > value)
            {
                PJOUT = BIT0;
                P3OUT = 0;
            }
            else if (finalTemp > (value-subvalue*1))
            {
                PJOUT = BIT0 + BIT1;
                P3OUT = 0;
            }
            else if (finalTemp > (value-subvalue*2))
            {
                PJOUT = BIT0 + BIT1 + BIT2;
                P3OUT = 0;
            }
            else if (finalTemp > (value-subvalue*3))
            {
                PJOUT = BIT0 + BIT1 + BIT2 + BIT3;
                P3OUT = 0;
            }
            else if (finalTemp > (value-subvalue*4))
           {
               PJOUT = BIT0 + BIT1 + BIT2 + BIT3;
               P3OUT = BIT4;
           }
            else if (finalTemp > (value-subvalue*5))
           {
               PJOUT = BIT0 + BIT1 + BIT2 + BIT3;
               P3OUT = BIT4 + BIT5;
           }
            else if (finalTemp > (value-subvalue*6))
           {
               PJOUT = BIT0 + BIT1 + BIT2 + BIT3;
               P3OUT = BIT4 + BIT5 + BIT6;
           }
            else
           {
               PJOUT = BIT0 + BIT1 + BIT2 + BIT3;
               P3OUT = BIT4 + BIT5 + BIT6 + BIT7;
           }
    }
    return 0;
}
//Timer Interrupt
#pragma vector = TIMER1_A0_VECTOR
__interrupt void ISR_TA1_CCR0(void)
{
    while ((UCA0IFG & UCTXIFG)==0);
    UCA0TXBUF = finalTemp;
    TA1CCTL0 &= ~CCIFG;
}

//ADC Interrupt
#pragma vector = ADC10_VECTOR
__interrupt void ISR_ADC10_B(void)
{
    // Average Last 4 Temperatures
    ADC10CTL0 &= ~ADC10ENC;
    tempOne = tempTwo;
    tempTwo = tempThree;
    tempThree = tempFour;
    tempFour = ADC10MEM0;
    finalTemp = (tempOne+tempTwo+tempThree+tempFour)/4;
    ADC10CTL0 |= ADC10ENC + ADC10SC;
    ADC10IFG &= ~ADC10IFG0;
}
