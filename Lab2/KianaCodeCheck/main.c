#include <msp430.h> 

volatile unsigned int risingEdge = 0;
volatile unsigned int fallingEdge = 0;
volatile unsigned int pulseWidth = 0;
volatile unsigned int edge = 0;


/**
 * main.c
 */
int main(void)
{
    WDTCTL = WDTPW | WDTHOLD;   // stop watchdog timer
    _EINT(); //Enables the interrupts

    //use the 1MHz SMCLK
    CSCTL0 = CSKEY; //setup a password
    CSCTL1 &= ~DCORSEL; //setup the clock system control register 1 to DCO range select
    CSCTL1 = DCOFSEL_3; //select the frequency for the DCO clock
    CSCTL2 = SELS_3; //select the SMCLK source which in this case is DCOCLK (clock register 2)

    //setting up the pin for TB1.1
    P3DIR |= BIT4;
    P3SEL1 &= ~BIT4;
    P3SEL0 |= BIT4;

    //setting up the pin for TB1.2
    P3DIR |= BIT5;
    P3SEL1 &= ~BIT5;
    P3SEL0 |= BIT5;

    //setup timer B in up mode
    TB1CTL = TBSSEL_2 + MC_1; //this is for the SMCLK using the up mode configuration
    TB1CCTL1 = OUTMOD_7; //set/reset
    TB1CCTL2 = OUTMOD_7; //set/reset


    TB1CCR1 = 1500; //This 75% of the cycle
    TB1CCTL1 = OUTMOD_7; //set/reset

    TB1CCR2 = 500; //This 75% of the cycle
    TB1CCTL2 = OUTMOD_7; //set/reset


    //setup timer A in continuous mode since this is measuring rising edge to falling edge
    TA1CTL = TASSEL_1 + MC_2; //this is for ACLK clock plus the continuous mode


    //Capture
    TA1CCTL1 = CM_1; //capture on rising edge; capture/compare mode
    TA1CCTL1 = CAP; //capture and compare the register; CAP_1 DNE
    TA1CCTL1 = CCIE; //capture/compare interrupt enable

    //setting up the pin for TA1.1
    P1DIR |= BIT2;
    P1SEL1 &= ~BIT2;
    P1SEL0 |= BIT2;

    while (1);

    return 0;
}

#pragma vector = TIMER1_A1_VECTOR
__interrupt void Timer_A_ISR(void){
    switch (TA1IV)
        {
            case(TA1IV_TACCR1):
                    if (edge == 0){
                        risingEdge = TA1CCR1;
                        TA1CCTL1 &= ~CM_0; //dont want to wipe out the register
                        TA1CCTL1 |= CM_2;
                        edge = 1;
                    }
                    else if (edge == 1){
                        fallingEdge = TA1CCR1;
                        TA1CCTL1 &= ~CM_0; //dont want to wipe out the register
                        TA1CCTL1 |= CM_1;
                        edge = 0;
                        if (TA1CCR1 & BIT1){
                            pulseWidth  = fallingEdge - risingEdge + 0xFFFF;
                            TA1CCR1 &= ~BIT1;
                        }
                        else {
                            pulseWidth  = fallingEdge - risingEdge;
                        }
                    }


                    break;
            /*case(TA1IV_TACCR2):
                    break;*/
            default:
                    break;
        }
}
