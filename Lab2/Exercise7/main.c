#include <msp430.h> 


/**
 * main.c
 */

unsigned volatile int state = 12;
unsigned volatile char x = 'x';
unsigned volatile char y = 'y';
unsigned volatile char z = 'z';

int main(void)
{
    WDTCTL = WDTPW | WDTHOLD;   // stop watchdog timer

    // Pin 2.7 output High for ADC
    P2DIR |= BIT7;
    P2OUT |= BIT7;

    // Setup ADC
    ADC10CTL0 &= ~ADC10ON;     // Turn off for editing
    ADC10CTL0 |= ADC10SHT_2;     // Set as 10bit (1024)
    ADC10CTL1 |= ADC10SHP;
    ADC10MCTL0 |= ADC10INCH_12;

    // Setup 1MHz Clock
    CSCTL0 = 0xA500;
    CSCTL1 = DCOFSEL0 + DCOFSEL1;                           // DCO = 8 MHz
    CSCTL2 = SELM0 + SELM1 + SELA0 + SELA1 + SELS0 + SELS1; // MCLK = DCO, ACLK = DCO, SMCLK = DCO
    CSCTL3 = DIVS__8; //divide clock by 8 for SMCLK

    // Setup Timer
    TA1CTL |= MC__UP + TASSEL__SMCLK + TACLR;
    TA1CCTL0 |= CCIE + OUTMOD_3;
    TA1CCR0 = 40000;

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

    //Global Interrupts
    _EINT();

    while(1);
}

//TIMER ISR
#pragma vector = TIMER1_A0_VECTOR
__interrupt void ISR_TA1_CCR0(void)
{
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

//ADC ISR
#pragma vector = ADC10_VECTOR
__interrupt void ISR_ADC10_B(void)
{
    ADC10CTL0 &= ~ADC10ENC;
    switch (state)
    {
    case 12:
        ADC10MCTL0 = ADC10INCH_13; //Convert from Channel 13 (Y)
        state++;
        x = ADC10MEM0>>2;
        break;
    case 13:
        ADC10MCTL0 = ADC10INCH_14; //Convert from Channel 14 (Z)
        state++;
        y = ADC10MEM0>>2;
        break;
    case 14:
        ADC10MCTL0 = ADC10INCH_12; //Convert from Channel 12 (X)
        state = 12;
        z = ADC10MEM0>>2;
        break;
    }
    ADC10CTL0 |= ADC10ENC + ADC10SC;
    ADC10IFG &= ~ADC10IFG0; //RESET FLAG
}

