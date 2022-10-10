#include <msp430.h> 


/**
 * main.c
 */
int main(void)
{
    WDTCTL = WDTPW | WDTHOLD;   // stop watchdog timer

    //Configure Clocks
    CSCTL0_H = 0xA5;
    CSCTL1 = DCOFSEL0 + DCOFSEL1;
    CSCTL2 = SELM0 + SELM1 + SELA0 + SELA1 + SELS0 + SELS1;

    //Configure UART
    UCA0CTLW0 |= UCSSEL0;
    UCA0MCTLW = UCOS16 + UCBRF0 + 0x4900;
    UCA0BRW = 52;
    UCA0CTLW0 &= ~UCSWRST;
    UCA0IE |= UCRXIE;
    _EINT();

    //Configure P2.0 and P2.1 as UART pins
    P2SEL1 |= BIT0 + BIT1;
    P2SEL0 &= ~(BIT0 + BIT1);

    //Setup LED1
    PJDIR |= BIT0;

    //unsigned char TXByte = 'a';

    while(1){
        //while(!(UCA0IFG & UCTXIFG));
        //UCA0TXBUF = TXByte;
    }
}

#pragma vector = USCI_A0_VECTOR
__interrupt void USCI_A0_ISR(void)
{
    unsigned char RxByte = 0;
    RxByte = UCA0RXBUF;
    if (RxByte == 'j'){
        PJOUT |= BIT0;
    }
    else if(RxByte == 'k'){
        PJOUT &= ~BIT0;
    }

    while (!(UCA0IFG & UCTXIFG));
    UCA0TXBUF = RxByte;
    while (!(UCA0IFG & UCTXIFG));
    UCA0TXBUF = RxByte + 1;
    while (!(UCA0IFG & UCTXIFG));
}
