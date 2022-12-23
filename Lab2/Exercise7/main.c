#include <msp430.h> 

unsigned volatile int state = 12; // Start state at 12
unsigned volatile char x;
unsigned volatile char y;
unsigned volatile char z;

int main(void)
{
    WDTCTL = WDTPW | WDTHOLD;   // stop watchdog timer

    // Pin 2.7 output High for ADC
    P2DIR |= BIT7;
    P2OUT |= BIT7;

    // Setup ADC
    ADC10CTL0 &= ~ADC10ON;     // Turn off ADC
    ADC10CTL0 |= ADC10SHT_2;     // Set to 10bit (1024)
    ADC10CTL1 |= ADC10SHP;
    ADC10MCTL0 |= ADC10INCH_12;

    // Setup clock
    CSCTL0 = 0xA500;
    CSCTL1 = DCOFSEL0 + DCOFSEL1;                           // DCO = 8 MHz
    CSCTL2 = SELM0 + SELM1 + SELA0 + SELA1 + SELS0 + SELS1; // MCLK = DCO, ACLK = DCO, SMCLK = DCO
    CSCTL3 = DIVS__8; //Make SMCLK 1MHz

    // Setup Timer
    TA1CTL |= MC__UP + TASSEL__SMCLK + TACLR;
    TA1CCTL0 |= CCIE + OUTMOD_3;
    TA1CCR0 = 40000; // Interrupt every 40000 ticks

    //Configure UART
    UCA0CTLW0 |= UCSSEL0;
    UCA0MCTLW = UCOS16 + UCBRF0 + 0x4900;
    UCA0BRW = 52;
    UCA0CTLW0 &= ~UCSWRST;
    UCA0IE |= UCRXIE;

    //Configure P2.0 and P2.1 as UART pins
    P2SEL1 |= BIT0 + BIT1;
    P2SEL0 &= ~(BIT0 + BIT1);

    // Start Conversions
    ADC10CTL0 |= ADC10ON + ADC10ENC + ADC10SC;
    TA1CCTL0 &= ~CCIFG;
    ADC10IE |= BIT0;
    ADC10IFG &= ~ADC10IFG0;

    _EINT();

    while(1);
}

//ADC Reading
#pragma vector = ADC10_VECTOR
__interrupt void ISR_ADC10_B(void)
{
    ADC10CTL0 &= ~ADC10ENC;
    switch (state)
    {
    case 12:
        ADC10MCTL0 = ADC10INCH_13; //Set next conversion to 13 Y
        state++; // Increase next state to 13
        x = ADC10MEM0>>2; //Record 8 MSB of data
        break;
    case 13:
        ADC10MCTL0 = ADC10INCH_14; //Set next conversion to 14 Z
        state++; // Increase next state to 14
        y = ADC10MEM0>>2; //Record 8 MSB of data
        break;
    case 14:
        ADC10MCTL0 = ADC10INCH_12; //Set next conversion to 12 X
        state = 12; // Change next state to 12
        z = ADC10MEM0>>2; //Record 8 MSB of data
        break;
    }
    ADC10CTL0 |= ADC10ENC + ADC10SC;
    ADC10IFG &= ~ADC10IFG0;
}

//Timer
#pragma vector = TIMER1_A0_VECTOR
__interrupt void ISR_TA1_CCR0(void)
{
    // Send data packet of X Y Z accelerometer Data
    int resetByte = 255;
    while ((UCA0IFG & UCTXIFG)==0);
    UCA0TXBUF = resetByte;
    while ((UCA0IFG & UCTXIFG)==0);
    UCA0TXBUF = x;
    while ((UCA0IFG & UCTXIFG)==0);
    UCA0TXBUF = y;
    while ((UCA0IFG & UCTXIFG)==0);
    UCA0TXBUF = z;
    TA1CCTL0 &= ~CCIFG;
}
