#include <msp430.h> 


/**
 * main.c
 */
unsigned volatile int state = 0;

int main(void)
{
    WDTCTL = WDTPW | WDTHOLD;   // stop watchdog timer

    // Setup P4.0 as digital input with pullup resistor
    P4DIR &= ~BIT0;
    P4REN |= BIT0;
    P4OUT |= BIT0;

    //Configure P4.0 interrupt
    P4IES |= BIT0;
    P4IE |= BIT0;

    //Configure P3.7 as output toggled on sw1
    P3DIR |= BIT4 + BIT5 + BIT6 + BIT7;
    PJDIR |= BIT0 + BIT1 + BIT2 + BIT3;
    P3OUT &= ~(BIT4 + BIT5 + BIT6 + BIT7);
    PJOUT &= ~(BIT0 + BIT1 + BIT2 + BIT3);


    //Global enable interrupt
    _EINT();

    while(1);
}

#pragma vector = PORT4_VECTOR
__interrupt void SwitchToggle (void){
    switch(state)
    {
    case 0:
        PJOUT |= BIT0;
        P3OUT &= ~BIT7;
        P4IFG &= ~BIT0;
        state++;
        break;
    case 1:
        PJOUT &= ~BIT0;
        PJOUT |= BIT1;
        P4IFG &= ~BIT0;
        state++;
        break;
    case 2:
        PJOUT &= ~BIT1;
        PJOUT |= BIT2;
        P4IFG &= ~BIT0;
        state++;
        break;
    case 3:
        PJOUT &= ~BIT2;
        PJOUT |= BIT3;
        P4IFG &= ~BIT0;
        state++;
        break;
    case 4:
        PJOUT &= ~BIT3;
        P3OUT |= BIT4;
        P4IFG &= ~BIT0;
        state++;
        break;
    case 5:
        P3OUT &= ~BIT4;
        P3OUT |= BIT5;
        P4IFG &= ~BIT0;
        state++;
        break;
    case 6:
        P3OUT &= ~BIT5;
        P3OUT |= BIT6;
        P4IFG &= ~BIT0;
        state++;
        break;
    case 7:
        P3OUT &= ~BIT6;
        P3OUT |= BIT7;
        P4IFG &= ~BIT0;
        state = 0;
        break;
    }
}
