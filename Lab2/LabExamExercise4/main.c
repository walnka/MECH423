#include <msp430.h> 


/**
 * main.c
 */

unsigned volatile char x = 'x';
unsigned volatile char xStore = 'x';
#define BUFFER_SIZE 16
unsigned volatile char buffer[BUFFER_SIZE];
unsigned volatile char* head = &buffer[0];
unsigned volatile char* tail = &buffer[0];
unsigned volatile char* fullMessage = "Buffer is Full";
unsigned volatile char* emptyMessage = "Buffer is Empty";
unsigned volatile int averageAccel = 0;

int main(void)
{
	WDTCTL = WDTPW | WDTHOLD;	// stop watchdog timer
	// Setup Clock Source
    CSCTL0_H = 0xA5;
    CSCTL1 = DCOFSEL0 + DCOFSEL1;
    CSCTL2 = SELM_3 + SELA_3 + SELS_3;
    CSCTL3 = DIVA_3 + DIVS_3 + DIVM_3;

    // Setup Timer
    TA1CTL |= MC__UP + TASSEL__SMCLK + TACLR;
    TA1CCTL0 |= CCIE + OUTMOD_3;
    TA1CCR0 = 10000;
//    TA0CCTL1 = OUTMOD_7;
//    TA0CCR1 = 10000;
//    TB1CCR1 = 500;
//    TB1CCR2 = 250;


    // Setup Timer B
    TB1CTL = TBSSEL_2 + MC_1 + TBCLR;
    TB1CCTL1 = OUTMOD_7;
    TB1CCR0 = 0x00FF;
    TB1CCR1 = 0;

    // Configure P3.4 and P3.5
    P3DIR |= BIT4;
    P3SEL0 |= BIT4;

    // Pin 2.7 output High for ADC
        P2DIR |= BIT7;
        P2OUT |= BIT7;

    // Setup ADC
        ADC10CTL0 &= ~ADC10ON;     // Turn off for editing
        ADC10CTL0 |= ADC10SHT_2;     // Set as 10bit (1024)
        ADC10CTL1 |= ADC10SHP;
        ADC10MCTL0 |= ADC10INCH_12;

    //Setup Output pin for Timer A
    P1DIR |= BIT0;
    P1SEL0 |= BIT0;

    // Start Conversions
    ADC10CTL0 |= ADC10ON + ADC10ENC + ADC10SC;
    TA1CCTL0 &= ~CCIFG;
    ADC10IE |= BIT0;
    ADC10IFG &= ~ADC10IFG0;

    _EINT();

    while(1);
}

#pragma vector = TIMER1_A0_VECTOR
__interrupt void ISR_TA1_CCR0(void)
{
    // Assign Next Tail
    unsigned volatile char* nextTail;
    if (tail == &buffer[BUFFER_SIZE-1]){
        nextTail = &buffer[0];
    }
    else{
        nextTail = tail + 1;
    }
    *tail = x;
    tail = nextTail;

    averageAccel = 0;
    int i = 0;
    for(i = 0; i < BUFFER_SIZE; i++){
        averageAccel += buffer[i];
    }
    averageAccel = averageAccel/16;
    TB1CCR1 = averageAccel;
    TA1CCTL0 &= ~CCIFG;
}

//ADC ISR
#pragma vector = ADC10_VECTOR
__interrupt void ISR_ADC10_B(void)
{
    //ADC10CTL0 &= ~ADC10ENC;
    x = ADC10MEM0>>2;
    //ADC10CTL0 |= ADC10ENC + ADC10SC;
    ADC10IFG &= ~ADC10IFG0; //RESET FLAG
}
