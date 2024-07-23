/*
 * I2C.h
 *
 *  Created on: 26 Nis 2024
 *      Author: kapla
 */

#ifndef I2C_H_
#define I2C_H_

#include <msp430.h>
#include <stdint.h>



void Setup_TX(unsigned char Dev_ID);
void Setup_RX(unsigned char Dev_ID);
void Transmit(unsigned char Reg_ADD, unsigned char Reg_DAT, int txByte_count);
void TransmitOne(unsigned char Reg_ADD);
void Receive(int rxByte_count);
void Receive6(unsigned char Reg_AD, volatile unsigned char rBuffer[6]);


#endif /* I2C_H_ */
