#include <msp430.h> 


/**
 * main.c
 */
int main(void)
{
	WDTCTL = WDTPW | WDTHOLD;	// stop watchdog timer
	
	// Setup Clock Source
    CSCTL0_H = 0xA5;
    CSCTL1 = DCOFSEL0 + DCOFSEL1;
    CSCTL2 = SELM_3 + SELA_3 + SELS_3;
    CSCTL3 = DIVA_4 + DIVS_4 + DIVM_4;

	// Setup Timer B
	TB1CTL = TBSSEL_2 + MC_1 + TBCLR;
	TB1CCTL1 = OUTMOD_7;
	TB1CCTL2 = OUTMOD_7;
	TB1CCR0 = 1000;
	TB1CCR1 = 1000;
	TB1CCR2 = 250;

	// Configure P3.4 and P3.5
	P3DIR |= BIT4 + BIT5;
	P3SEL0 |= BIT4 + BIT5;

	_EINT();

	while(1);
}

