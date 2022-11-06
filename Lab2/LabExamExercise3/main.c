#include <msp430.h> 


/**
 * main.c
 */
unsigned volatile int TimerCount = 0;
unsigned volatile char timerCountChar = '0';


int main(void)
{
    WDTCTL = WDTPW | WDTHOLD;   // stop watchdog timer

//    // Setup Clock Source
//    CSCTL0_H = 0xA5;
//    CSCTL1 = DCOFSEL0 + DCOFSEL1;
//    CSCTL2 = SELM_3 + SELA_3 + SELS_3;
//    CSCTL3 = DIVA_4 + DIVS_4 + DIVM_4;
    // Setup 1MHz Clock
        CSCTL0 = 0xA500;
        CSCTL1 = DCOFSEL0 + DCOFSEL1;                           // DCO = 8 MHz
        CSCTL2 = SELM0 + SELM1 + SELA0 + SELA1 + SELS0 + SELS1; // MCLK = DCO, ACLK = DCO, SMCLK = DCO
        CSCTL3 = DIVS__8; //divide clock by 8 for SMCLK

    //Configure UART
    UCA0CTLW0 |= UCSSEL0;
    UCA0MCTLW = UCOS16 + UCBRF0 + 0x4900;
    UCA0BRW = 52;
    UCA0CTLW0 &= ~UCSWRST;
    UCA0IE |= UCRXIE;

    //Configure P2.0 and P2.1 as UART pins
    P2SEL1 |= BIT0 + BIT1;
    P2SEL0 &= ~(BIT0 + BIT1);

    // Setup P4.0 as digital input with pullup resistor
    P4DIR &= ~BIT0;
    P4SEL0 |= BIT0;
    P4SEL1 &= ~BIT0;
    P4REN |= BIT0;

    //Configure P4.0 interrupt
//    P4IES |= BIT0;
//    P4IE |= BIT0;

    // Setup Timer A
    TB2CTL = TBSSEL_2 + MC_2 + ID_1 + TACLR;
//    TB2CCTL0 |= CCIE;
    TB2CCTL0 |= CM_3 + CCIS_1 + SCS + CAP + CCIE + SCCI;
    TB2CCTL0 &= ~CCIFG;


    //Global enable interrupt
    _EINT();

    while(1);
}


#pragma vector = TIMER2_B0_VECTOR
__interrupt void TriggerTimer (void){
    if (!(TB2CCTL0 & CCI)){
        TB2R = 0x0000;
        TimerCount = 0;
    }
    else{
        TimerCount = TB2R;
        timerCountChar = TimerCount>>8;
//        int resetByte = 255;
        while ((UCA0IFG & UCTXIFG)==0);
        UCA0TXBUF = timerCountChar;
        while ((UCA0IFG & UCTXIFG)==0);
    }
    TB2CCTL0 &= ~CCIFG;
}
