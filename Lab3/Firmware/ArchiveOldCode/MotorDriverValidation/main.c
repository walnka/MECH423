#include <msp430.h> 


/**
 * main.c
 */
int main(void)
{
	WDTCTL = WDTPW | WDTHOLD;	// stop watchdog timer
	
	P2DIR |= BIT1;
	P3DIR |= BIT6;
	P2OUT |= BIT1;
    P3OUT |= BIT6;


	while(1);

	return 0;
}
