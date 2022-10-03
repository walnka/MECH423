#include <msp430.h> 

/**
 * main.c
 */
int main(void)
{
    WDTCTL = WDTPW | WDTHOLD;   // stop watchdog timer
    // Set up registers for clock
    CSCTL0_H = 0xA5;
    CSCTL1 &= DCORSEL;
    CSCTL1 |= DCOFSEL0 + DCOFSEL1;
    CSCTL2 = SELS_3;
    CSCTL3 = DIVS_5;

    // Set up registers for output
    P3DIR |= BIT4;
    P3SEL0 |= BIT4;
    P3SEL1 |= BIT4;

    while(1);
}
