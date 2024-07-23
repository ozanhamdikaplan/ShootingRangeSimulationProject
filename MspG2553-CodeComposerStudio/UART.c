/*
 * UART.c
 *
 *  Created on: 26 Nis 2024
 *      Author: kapla
 */



#include "UART.h"


void Setup_UART() {
      _DINT();
      IE2 &= ~UCB0RXIE; // Disable USCI_B0 RX interrupt (I2C)
      IE2 &= ~UCB0TXIE; // Disable USCI_B0 TX interrupt (I2C)
      UCA0CTL1 |= UCSSEL_2; // Use SMCLK
      UCA0BR0 = 104;        // Set baud rate to 9600 with 1MHz clock (Data Sheet 15.3.13)
      UCA0BR1 = 0;          // Set baud rate to 9600 with 1MHz clock
      UCA0MCTL = UCBRS0;    // Modulation UCBRSx = 1
      UCA0CTL1 &= ~UCSWRST; // Initialize USCI state machine
      IE2 |= UCA0RXIE; // Enable USCI_A0 RX interrupt
}

void uart_send_char(unsigned char c) {

        while (!(IFG2 & UCA0TXIFG)); // TX tamponu boþ olana kadar bekle
        UCA0TXBUF = c; // TX tamponuna karakteri yükle

}

void uart_send_hex(uint8_t data) {
        uint8_t upper_nibble = (data >> 4) & 0x0F; // Üst 4 bit
        uint8_t lower_nibble = data & 0x0F; // Alt 4 bit

    // Üst 4 biti ASCII karaktere dönüþtür ve gönder
        if (upper_nibble < 10)
            uart_send_char(upper_nibble + '0');
        else
            uart_send_char(upper_nibble - 10 + 'A');

    // Alt 4 biti ASCII karaktere dönüþtür ve gönder
        if (lower_nibble < 10)
            uart_send_char(lower_nibble + '0');
        else
            uart_send_char(lower_nibble - 10 + 'A');
}
void UART_Send_End_Of_Data()
{
        __delay_cycles(10000);
        UCA0TXBUF = '\n';

}


