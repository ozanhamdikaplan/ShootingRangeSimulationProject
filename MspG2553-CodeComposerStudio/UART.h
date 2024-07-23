/*
 * UART.h
 *
 *  Created on: 26 Nis 2024
 *      Author: kapla
 */

#ifndef UART_H_
#define UART_H_

#include <msp430.h>
#include <stdint.h>

void Setup_UART();
void uart_send_hex(uint8_t data);
void uart_send_char(unsigned char c);
void UART_Send_End_Of_Data();

#endif /* UART_H_ */
