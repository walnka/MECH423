#include <msp430.h> 


/**
 * main.c
 */
int main(void)
{
    WDTCTL = WDTPW | WDTHOLD;   // stop watchdog timer

    // Setup Clock Source
    CSCTL0_H = 0xA5;
    CSCTL1 = DCOFSEL0 + DCOFSEL1;
    CSCTL2 = SELM_3 + SELA_3 + SELS_3;
    CSCTL3 = DIVA_3 + DIVS_3 + DIVM_3;

    // Setup Timer B
    TB1CTL = TBSSEL_2 + MC_1 + TBCLR;
    TB1CCTL1 = OUTMOD_7;
    TB1CCR0 = 333;
    TB1CCR1 = 111;

    // Configure P3.4 and P3.5
    P3DIR |= BIT4;
    P3SEL0 |= BIT4;

    _EINT();

    while(1);
}

