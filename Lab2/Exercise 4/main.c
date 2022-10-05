#include <msp430.h> 


/**
 * main.c
 */
int main(void)
{
	WDTCTL = WDTPW | WDTHOLD;	// stop watchdog timer
	
	//Configure Clocks
	CSCTL0_H = 0xA5;
	CSCTL1 &= ~DCORSEL;
	CSCTL1 |= DCOFSEL0 + DCOFSEL1;
	CSCTL2 |= SELM0 + SELM1 + SELA0 + SELA1 + SELS0 + SELS1;

	//Configure UART
	UCA0CTLW0 = UCSSEL0;
	UCA0MCTLW = UCOS16 + UCBRF0 + 0x4900;
	UCA0BRW = 52;
	UCA0CTLW0 &= ~UCSWRST;
	UCA0IE |= UCTXIE;

	while(1){
	    unsigned char TXByte = 'a';
	    while(!(UCA0IFG & UCTXIFG));
	    UCA0TXBUF = TXByte;
	}
}
