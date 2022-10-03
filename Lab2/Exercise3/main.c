#include <msp430.h> 


/**
 * main.c
 */
int main(void)
{
	WDTCTL = WDTPW | WDTHOLD;	// stop watchdog timer
	
	// Setup P4.0 as digital input with pullup resistor
	P4DIR &= ~BIT0;
	P4REN |= BIT0;
	P4OUT |= BIT0;

	//Configure P4.0 interrupt
	P4IES &= ~BIT0;
	P4IE |= BIT0;

	//Configure P3.7 as output toggled on sw1
	P3DIR |= BIT7;

	//Global enable interrupt
	_EINT();

	while(1);
}

#pragma vector = PORT4_VECTOR
__interrupt void SwitchToggle (void){
    P3OUT ^= BIT7;
    P4IFG &= ~BIT0;
}
