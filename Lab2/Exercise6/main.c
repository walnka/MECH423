#include <msp430.h> 


/**
 * main.c
 */

unsigned volatile int TimerCount = 0;

int main(void)
{
    WDTCTL = WDTPW | WDTHOLD;   // stop watchdog timer

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
    TB1CCR1 = 500;
    TB1CCR2 = 250;

    // Setup Timer A
    TA0CTL = TASSEL_2 + MC_2 + TACLR;
    TA0CCTL0 |= CM_3 + CCIS_0 + SCS + CAP + CCIE + SCCI;

    // Configure P3.4 and P3.5 for Timer B outputs
    P3DIR |= BIT4 + BIT5;
    P3SEL0 |= BIT4 + BIT5;

    // Configure P1.6 for Timer A input
    P1SEL0 |= BIT6;
    P1SEL1 |= BIT6;

    _EINT();

    while(1);
}

#pragma vector = TIMER0_A0_VECTOR
__interrupt void TriggerTimer (void){
    if (TA0CCTL0 & CCI){
        TA0R = 0x0000;
    }
    else{
        TimerCount = TA0R;
    }
    TA0CCTL0 &= ~CCIFG;
}

