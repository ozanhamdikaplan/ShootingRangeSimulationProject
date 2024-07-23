#include <msp430.h>
#include <stdint.h>
#include <string.h>
#include <stdlib.h>
#include <math.h>
#include <stdbool.h>
#include <stdio.h>
#include "I2C.h"
#include "UART.h"
#include "MPU6050.h"


#define HMC5883_ADDR            0x1E
#define CONFÝG_REG_A            0x00
#define CONFÝG_REG_B            0x01
#define MODE_REG                0x02
#define DATA_OUT_X_MSB          0x03

#define LAZER_LED               BIT0
#define ERROR_LED               BIT2

#define RX_PIN                  BIT1
#define TX_PIN                  BIT2

#define HC_05_STATES            BIT0
#define TRIGGER_BTN             BIT3
#define UNLOADING_BTN           BIT4
#define LOADING_BTN             BIT5

#define SCL_PIN                 BIT6
#define SDA_PIN                 BIT7

#define TRIGGER_BTN_WHO         0xB1
#define UNLOADING_BTN_WHO       0xB2
#define LOADING_BTN_WHO         0xB3
#define TRIGGER_DATA_LENGTH     16



void System_Init();
void GPIO_Init();
void Mpu6050_WakeUp();
void Mpu6050_States_OK();
void AssignRxValuestoArrayMPU();
void AssignRxValuestoArrayHMC();

void CheckSum();
void ReadAccelGyro();
void HMC5883L_Init();
void ReadHMC5883L();
void Handle_Buttons();
void DataSum();

bool CheckBluetoothConnection();

volatile unsigned char RxBuffer[14];  // Allocate 14 byte of RAM for MPU6050 readings

int16_t magX, magY, magZ;

uint8_t data[16];

int i,j;
int button_pressed_trigger=0;
int button_pressed_unloading=0;
int button_pressed_loading=0;




uint32_t lastUpdateTime = 0;  // Son ölçüm zamaný
uint32_t currentTime;  // Güncel zaman
uint32_t deltaTime;  // Zaman farký

int main(void) {

    System_Init();
    __delay_cycles(1000000);
    GPIO_Init();
    while(!CheckBluetoothConnection());
    P2OUT |= ERROR_LED;
    __delay_cycles(5000000);
    Mpu6050_WakeUp();

    HMC5883L_Init();
    __bis_SR_register(GIE);  // Enable interrupts globally

    //ReadHMC5883L();


    while(1) {

        P2OUT |= ERROR_LED;
        ReadAccelGyro();
        AssignRxValuestoArrayMPU();
        ReadHMC5883L();
        AssignRxValuestoArrayHMC();
        CheckSum();


        Handle_Buttons();
        __delay_cycles(67000);
        P2OUT &= ~ERROR_LED;

    }
}



void System_Init()
{
    WDTCTL = WDTPW + WDTHOLD;  // Watchdog'u durdur
    DCOCTL = 0;
    BCSCTL1 = CALBC1_1MHZ;     // DCO'yu 1MHz olarak ayarla
    DCOCTL = CALDCO_1MHZ;      // DCO'yu 1MHz olarak ayarla
}


void GPIO_Init()
{
        P1SEL  |= (RX_PIN | TX_PIN | SCL_PIN | SDA_PIN);
        P1SEL2 |= (RX_PIN | TX_PIN | SCL_PIN | SDA_PIN);
        P1SEL &= ~(TRIGGER_BTN | UNLOADING_BTN | LOADING_BTN | HC_05_STATES) ;
        P1SEL2 &= ~(TRIGGER_BTN | UNLOADING_BTN | LOADING_BTN | HC_05_STATES) ;
        P1DIR &= ~(TRIGGER_BTN | UNLOADING_BTN | LOADING_BTN | HC_05_STATES) ;
        P1REN |= (TRIGGER_BTN | UNLOADING_BTN | LOADING_BTN | HC_05_STATES);
        P1OUT |= (TRIGGER_BTN | UNLOADING_BTN | LOADING_BTN | HC_05_STATES) ;

        P2SEL &= ~( LAZER_LED | ERROR_LED);
        P2SEL2 &= ~( LAZER_LED | ERROR_LED);
        P2DIR |= (LAZER_LED | ERROR_LED);
        P2OUT |= LAZER_LED;
        P2OUT &= ~ERROR_LED;

}

void Mpu6050_States_OK()
{
    P2OUT |= ERROR_LED;
}

bool CheckBluetoothConnection()
{
    // HC-05 durum pininin hangi GPIO piniyle eþleþtiðini belirleyin
    if (P1IN & HC_05_STATES) {  // Örneðin,  baðlantý durum pinine baðlýysa
        return true;  // Baðlantý saðlandý
    }
    return false;  // Baðlantý saðlanmadý
}


void Mpu6050_WakeUp()
{

    Setup_TX(MPU6050_ADDR);
    Transmit(PWR_MGMT_1, 0x00 , NUM_BYTES_TX);
    while (UCB0CTL1 & UCTXSTP);

    Setup_TX(MPU6050_ADDR);
    Transmit(SMPLRT_DIV, 0x07,1);
    while (UCB0CTL1 & UCTXSTP);

    Setup_TX(MPU6050_ADDR);
    Transmit(ACCEL_CONFIG, 0x00 , 1);
    while (UCB0CTL1 & UCTXSTP);

    Setup_TX(MPU6050_ADDR);
    Transmit(GYRO_CONFIG, 0x00,1);
    while (UCB0CTL1 & UCTXSTP);

}

void HMC5883L_Init()
{

    Setup_TX(HMC5883_ADDR);
    Transmit(CONFÝG_REG_A, 0x70, NUM_BYTES_TX);
    while (UCB0CTL1 & UCTXSTP);

    Setup_TX(HMC5883_ADDR);
    Transmit(CONFÝG_REG_B, 0xA0, NUM_BYTES_TX);
    while (UCB0CTL1 & UCTXSTP);

    Setup_TX(HMC5883_ADDR);
    Transmit(MODE_REG, 0x00, NUM_BYTES_TX);
    while (UCB0CTL1 & UCTXSTP);

}


void ReadAccelGyro()
{

    Setup_TX(MPU6050_ADDR);
    TransmitOne(ACCEL_XOUT_H);
    while (UCB0CTL1 & UCTXSTP);

    Setup_RX(MPU6050_ADDR);
    Receive(NUM_BYTES_RX);
    while (UCB0CTL1 & UCTXSTP);

}

void ReadHMC5883L() {

    Setup_TX(HMC5883_ADDR);

    while (UCB0CTL1 & UCTXSTP);
    TransmitOne(DATA_OUT_X_MSB);
    while (UCB0CTL1 & UCTXSTP);

    Setup_RX(HMC5883_ADDR);
    Receive(NUM_BYTES_RX);
    while (UCB0CTL1 & UCTXSTP);

}

void AssignRxValuestoArrayMPU(){


       // uint16_t bitmask  = 0x3F3F; // 0011000000111111  GzL GzM GyL GyM GxL GxM  tempL(0) tempM(0) AzL AzM AyL AyM AxL AxM
        data[0] = TRIGGER_BTN_WHO;
        data[1] = TRIGGER_DATA_LENGTH;

        for(i=2,j=0; i<8 ;i++){

           data[i] = RxBuffer[j];
           j++;
        }

}
void AssignRxValuestoArrayHMC(){


        for(i=8,j=0; i<14 ;i++){

           data[i] = RxBuffer[j];
           j++;
        }

}

void CheckSum()
{
        uint16_t sum = 0;

        for(i=2;i<14;i++)
        {
            sum = sum + data[i];
        }

        // Toplamý 16-bit'e ayýr ve `data` dizisine ekle
        data[14] = (uint8_t)((sum >> 8) & 0xFF);  // Üst byte
        data[15] = (uint8_t)(sum & 0xFF);  // Alt byte

}

void Handle_Buttons()
{

        if ( !(P1IN & TRIGGER_BTN) ) {  // Buton basýlý

            if(!button_pressed_trigger){
                Setup_UART();
                for (i = 0; i < 16; i++)
                {
                    uart_send_hex(data[i]);
                }
                UART_Send_End_Of_Data();
                button_pressed_trigger = 1;

                P2OUT &= ~LAZER_LED;
            }
        }
        else{
            button_pressed_trigger = 0;
        }



        if ((P1IN & UNLOADING_BTN) == 0) {  // Buton basýlý

            if(!button_pressed_unloading){
                Setup_UART();
                uart_send_hex(UNLOADING_BTN_WHO);
                UART_Send_End_Of_Data();
                button_pressed_unloading = 1;
                }
            }
        else{
            button_pressed_unloading = 0;
        }

        if ((P1IN & LOADING_BTN) == 0) {  // Buton basýlý

            if(!button_pressed_loading){
                Setup_UART();
                uart_send_hex(LOADING_BTN_WHO);
                UART_Send_End_Of_Data();
                button_pressed_loading = 1;
                }
            }
        else{
            button_pressed_loading = 0;
        }
}

