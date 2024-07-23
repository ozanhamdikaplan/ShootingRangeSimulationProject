/*
 * I2C.c
 *
 *  Created on: 26 Nis 2024
 *      Author: kapla
 */


#include "I2C.h"


int RXByteCtr;
extern volatile unsigned char RxBuffer[14];
unsigned char *PRxData;                // Pointer to RX data
unsigned char TXByteCtr, RX = 0;
unsigned char MSData[2];

void Setup_TX(unsigned char Dev_ID) {
    RX = 0;
    IE2 &= ~UCB0RXIE;                       // Disable USCI_B0 RX interrupt (I2C)
    while (UCB0CTL1 & UCTXSTP);             // Ensure stop condition got sent
    UCB0CTL1 |= UCSWRST;                    // Enable SW reset
    UCB0CTL0 = UCMST + UCMODE_3 + UCSYNC;   // I2C Master, synchronous mode
    UCB0CTL1 = UCSSEL_2 + UCSWRST;          // Use SMCLK, keep SW reset
    UCB0BR0 = 12;                           // fSCL = SMCLK/12 = ~100kHz
    UCB0BR1 = 0;
    UCB0I2CSA = Dev_ID;                     // Slave Address
    UCB0CTL1 &= ~UCSWRST;                   // Clear SW reset, resume operation
    IE2 |= UCB0TXIE;                        // Enable TX interrupt
}


void Setup_RX(unsigned char Dev_ID) {
    RX = 1;
    IE2 &= ~UCB0TXIE;                       // Disable USCI_B0 TX interrupt (I2C)
    UCB0CTL1 |= UCSWRST;                    // Enable SW reset
    UCB0CTL0 = UCMST + UCMODE_3 + UCSYNC;   // I2C Master, synchronous mode
    UCB0CTL1 = UCSSEL_2 + UCSWRST;          // Use SMCLK, keep SW reset
    UCB0BR0 = 12;                           // fSCL = SMCLK/12 = ~100kHz
    UCB0BR1 = 0;
    UCB0I2CSA = Dev_ID;                     // Slave Address
    UCB0CTL1 &= ~UCSWRST;                   // Clear SW reset, resume operation
    IE2 |= UCB0RXIE;                        // Enable RX interrupt
}


void Transmit(unsigned char Reg_ADD, unsigned char Reg_DAT, int txByte_count) {
    MSData[1] = Reg_ADD;
    MSData[0] = Reg_DAT;
    TXByteCtr = txByte_count;               // Load TX byte counter
    while (UCB0CTL1 & UCTXSTP);             // Ensure stop condition got sent
    UCB0CTL1 |= UCTR + UCTXSTT;             // I2C TX, start condition
    __bis_SR_register(CPUOFF + GIE);        // Enter LPM0 with interrupts
}

void TransmitOne(unsigned char Reg_ADD) {
    MSData[0] = Reg_ADD;
    TXByteCtr = 1;                          // Load TX byte counter
    while (UCB0CTL1 & UCTXSTP);             // Ensure stop condition got sent
    UCB0CTL1 |= UCTR + UCTXSTT;             // I2C TX, start condition
    __bis_SR_register(CPUOFF + GIE);        // Enter LPM0 with interrupts
}

void Receive(int rxByte_count) {
    PRxData = (unsigned char *)RxBuffer;    // Start of RX buffer
    RXByteCtr = rxByte_count;               // Load RX byte counter
    while (UCB0CTL1 & UCTXSTP);             // Ensure stop condition got sent
    UCB0CTL1 |= UCTXSTT;                    // I2C start condition
    __bis_SR_register(CPUOFF + GIE);        // Enter LPM0 with interrupts
}

#pragma vector = USCIAB0TX_VECTOR
__interrupt void USCIAB0TX_ISR(void) {
    if (RX == 1) {  // Master Receive
        RXByteCtr--;  // Decrement RX byte counter
        if (RXByteCtr) {
            *PRxData++ = UCB0RXBUF;  // Move RX data to address PRxData
        } else {
            UCB0CTL1 |= UCTXSTP;  // No Repeated Start: stop condition
            *PRxData++ = UCB0RXBUF;  // Move final RX data to PRxData
            __bic_SR_register_on_exit(CPUOFF);  // Exit LPM0
        }
    } else {  // Master Transmit
        if (TXByteCtr) {  // Check TX byte counter
            TXByteCtr--;  // Decrement TX byte counter
            UCB0TXBUF = MSData[TXByteCtr];  // Load TX buffer
        } else {
            UCB0CTL1 |= UCTXSTP;  // I2C stop condition
            IFG2 &= ~UCB0TXIFG;  // Clear USCI_B0 TX int flag
            __bic_SR_register_on_exit(CPUOFF);  // Exit LPM0
        }
    }
}
