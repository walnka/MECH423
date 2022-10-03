#include <msp430.h> 


/**
 * main.c
 */
int main(void)
{
	WDTCTL = WDTPW | WDTHOLD;	// stop watchdog timer
	
	//Configure output pins
	PJDIR |= BIT0 + BIT1 + BIT2 + BIT3;
	P3DIR |= BIT4 + BIT5 + BIT6 + BIT7;

	//Set LEDs to output initial values
	PJOUT |= BIT0 + BIT3;
	P3OUT |= BIT6 + BIT7;

	int i;
	while(1){
	    for(i = 0; i < 20000; i++);
	    PJOUT ^= BIT1 + BIT2;
	    P3OUT ^= BIT4 + BIT5;
	}
}
