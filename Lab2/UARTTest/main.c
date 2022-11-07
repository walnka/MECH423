#include <msp430.h> 
/**
 * main.c
 */
int main(void)
{
WDTCTL = WDTPW | WDTHOLD; // stop watchdog timer
    // Configure clocks
    CSCTL0 = 0xA500;                        // Write password to modify CS registers
    CSCTL1 = DCOFSEL0 + DCOFSEL1;           // DCO = 8 MHz
    CSCTL2 = SELM0 + SELM1 + SELA0 + SELA1 + SELS0 + SELS1; // MCLK = DCO, ACLK = DCO, SMCLK = DCO
    // Configure ports for UART
    P2SEL0 &= ~(BIT0 + BIT1);
    P2SEL1 |= BIT0 + BIT1;
    // Configure UART
    UCA0CTLW0 |= UCSSEL0;
    UCA0MCTLW = UCOS16 + UCBRF0 + 0x4900;
    UCA0BRW = 52;
    UCA0CTLW0 &= ~UCSWRST;
    UCA0IE |= UCRXIE; //enable UART receive interrupt
    _EINT();    //Global interrupt enable
    while (1)
    {
    }
return 0;
}
#pragma vector = USCI_A0_VECTOR
__interrupt void USCI_A0_ISR(void)
{
    unsigned char RxByte =0;
    RxByte = UCA0RXBUF;
    while (!(UCA0IFG & UCTXIFG));
    UCA0TXBUF = RxByte;
    while (!(UCA0IFG & UCTXIFG));
    UCA0TXBUF = RxByte + 1;
}
