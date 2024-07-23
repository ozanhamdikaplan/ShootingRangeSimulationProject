using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;
using InTheHand.Net.Sockets;
using InTheHand.Net.Bluetooth;
using System.Reflection.Emit;
using System.Xml.Linq;


namespace TigerShootingRange
{
    public partial class Form1 : Form
    {
        SerialPort srlPort = new SerialPort();

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            SetControlLocationsAndSizes();
            calibrateStartBTN.Enabled = false;
            StartBtn.Enabled = false;
            calibrateOkBTN.Enabled = false;
            string[] ports = SerialPort.GetPortNames(); bluetoothCMB.Items.Clear(); // ComboBox'u temizle

            foreach (string port in ports)
            {
                // Eðer port ismi COM10 ise, onu "Silah" olarak göster
                if (port == "COM10")
                {
                    bluetoothCMB.Items.Add("Silah");
                }
                else
                {
                    bluetoothCMB.Items.Add(port);
                }
            }
            youDoLBL.Text = "Select Bluetooth Port and Click Connect";


        }


        private StringBuilder buffer = new StringBuilder(); // Alýnan veriyi saklamak için bir StringBuilder kullanabilirsiniz
        ushort[] mpu6050_firstData = new ushort[6];
        short firstDataMg = 0;
        short firstDataAcc = 0;
        short firstDataMgUp = 0;
        short firstDataAccUp = 0;
        short firstDataMgDown = 0;
        short firstDataAccDown = 0;
        int firstTakedData = 0;
        //   float yaw = 0.0f;

        int formWidth;
        int formHeight;
        int logoTextWidth;
        int logoTextLocationX;
        int logoTextLocationY;
        int targetLocationX;
        int targetLocationY;
        int targetWidth;
        int targetHeight;
        int exitLocationX;
        int bulletWidth;
        int bulletLocationX;
        int bulletLocationY;
        int targetMinX;  // targetPB için minimum x sýnýrý
        int targetMaxX;  // targetPB için maksimum x sýnýrý
        int targetMinY;  // targetPB için minimum y sýnýrý
        int targetMaxY;  // targetPB için maksimum y sýnýrý

        int bulletCount = 0;
        int status = 0;
        int lbl2 = 0;

        double distance = 0;
        private void SrlPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string receivedData = srlPort.ReadExisting();
            buffer.Append(receivedData);


            if (buffer.ToString().Contains("\n")) // Eðer \n karakteri veride bulunuyorsa
            {
                // \n karakterini bulunduðu indeksten sonuna kadar olan kýsmý alarak veriyi ayýr
                string[] dataArray = buffer.ToString().Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);



                // Her bir veri parçasý üzerinde iþlem yapabilirsiniz
                foreach (string data in dataArray)
                {
                    byte firstByte = Convert.ToByte(data.Substring(0, 2), 16);
                    if (firstByte == 0xB1)
                    { // Ýlk byte 'B1' ise

                        this.Invoke(new Action(() => DisplayDataPark_event(data)));

                    }
                    else if (firstByte == 0xB2)
                    { // Ýlk byte 'B2' ise
                        this.Invoke(new Action(() => BulletFree()));
                    }
                    else if (firstByte == 0xB3)
                    { // Ýlk byte 'B3' ise
                        this.Invoke(new Action(() => BulletFull()));
                    }
                    // Alýnan veriyi form üzerinde güncellemek için Invoke ile DisplayDataPark_event metodunu çaðýr

                }

                // buffer'ý temizle
                buffer.Clear();
            }
        }

        private void BulletFull()
        {

            if (status == 2)
            {
                reloadGreenPB.Visible = true;
                status = 3;
                bulletCount = 7;
                bulletNumLbl.Text = bulletCount.ToString();

                youDoLBL.Text = "Push The Trigger Button";
            }
            else if (status == 1)
            {
                _ = MessageBox.Show("Lütfen Unloading Butonuna Basýnýz.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (status == 3)
            {
                _ = MessageBox.Show("Lütfen Trigger Butonuna Basýnýz.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (status == 6)
            {
                bulletCount = 7;
                bulletNumLbl.Text = bulletCount.ToString();
                status = 5;
            }
            else if (status == 5)
            {
                _ = MessageBox.Show("Lütfen Þarjörü Çýkartýnýz .", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }

        private void BulletFree()
        {
            if (status == 1)
            {
                unLoadGreenPB.Visible = true;
                status = 2;
                bulletCount = 0;

                youDoLBL.Text = "Push The Loading Button";
                bulletNumLbl.Text = bulletCount.ToString();
            }
            else if (status == 2)
            {
                _ = MessageBox.Show("Lütfen Loading Butonuna Basýnýz.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (status == 3)
            {
                _ = MessageBox.Show("Lütfen Trigger Butonuna Basýnýz.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (status == 5)
            {
                bulletCount = 0;
                status = 6;
                bulletNumLbl.Text = bulletCount.ToString();
            }
            else if (status == 6)
            {
                _ = MessageBox.Show("Lütfen Þarjörü Takýnýz.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }




        }

        private void DisplayDataPark_event(string data)
        {
            try
            {
                if (status == 1)
                {
                    _ = MessageBox.Show("Lütfen Unloading Butonuna Basýnýz.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (status == 2)
                {
                    _ = MessageBox.Show("Lütfen Loading Butonuna Basýnýz.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (status == 3 || status == 5)
                {

                    if (bulletCount > 0)
                    {

                        if (data.Length < 16) return;

                        byte[] bytes = new byte[16];

                        for (int i = 0; i < 16; i++)
                        {
                            bytes[i] = Convert.ToByte(data.Substring(i * 2, 2), 16); // Heksadesimal dönüþtür
                        }

                        ushort sum = 0;
                        for (int i = 2; i < 14; i++)
                        {
                            sum += bytes[i]; // Baytlarý topla
                        }

                        ushort receivedSum = (ushort)((bytes[14] << 8) | bytes[15]); // Son iki bayttan toplamý oluþtur
                        if (sum == receivedSum) // Toplamlar eþitse
                        {
                            // Verileri deðiþkenlere ata
                            float accSens = 16384.0f;

                            short rawAccelX = (short)((bytes[2] << 8) | bytes[3]);
                            short rawAccelY = (short)((bytes[4] << 8) | bytes[5]);
                            short rawAccelZ = (short)((bytes[6] << 8) | bytes[7]);

                            float accelX = (float)rawAccelX / accSens;
                            float accelY = (float)rawAccelY / accSens;
                            float accelZ = (float)rawAccelZ / accSens;

                            short mgX = (short)((bytes[8] << 8) | bytes[9]);
                            short mgY = (short)((bytes[10] << 8) | bytes[11]);
                            short mgZ = (short)((bytes[12] << 8) | bytes[13]);


                            double azimuthRadian = Math.Atan2(mgY, mgX);
                            azimuthRadian = azimuthRadian * (180.0 / Math.PI);


                            short azimuthDegrees = (short)azimuthRadian;


                            if (azimuthDegrees < 0)
                            {
                                azimuthDegrees += 360;
                            }






                            // Dönüþüm baþarýlýysa, hesaplama yap
                            double projection = 0;
                            int bulletLocationXz = bulletLocationX;
                            int bulletLocationYz = bulletLocationY;

                            distance = distanceTB.Value;


                            if (accelY < 1.5)
                            {
                                projection = (accelY / Math.Sqrt(accelX * accelX + accelZ * accelZ));

                            }
                            else
                            {

                                projection = ((accelY - 4) / Math.Sqrt(accelX * accelX + accelZ * accelZ));

                            }
                            double tanValue = projection;

                            // Radyan cinsinden açýyý hesapla
                            double angleRad = Math.Atan(tanValue);

                            // Açýyý dereceye çevir
                            double angleDeg = angleRad * (180.0 / Math.PI);


                            if (firstTakedData == 0)
                            {
                                firstDataMg = azimuthDegrees;
                                firstDataAcc = (short)angleDeg;
                                firstTakedData = 3;
                                // firstTakedData = 2;
                            }/*
                            else if (firstTakedData == 0)
                            { firstTakedData = 1; }*/
                            else if (firstTakedData == 3)
                            {
                                firstDataMgUp = azimuthDegrees;
                                firstDataAccUp = (short)angleDeg;
                                firstTakedData = 4;
                            }
                            else if (firstTakedData == 4)
                            {
                                firstDataMgDown = azimuthDegrees;
                                firstDataAccDown = (short)angleDeg;
                                firstTakedData = 2;
                            }

                            projection = angleDeg;


                            int mgdata = 0;
                            if (firstTakedData == 2)
                            {
                                if (angleDeg > firstDataAcc)
                                {
                                    mgdata = azimuthDegrees - (firstDataMg + ((short)(angleDeg) * ((firstDataMgUp - firstDataMg) / (firstDataAccUp - firstDataAcc))));
                                }
                                else if (angleDeg < firstDataAcc)
                                {
                                    mgdata = azimuthDegrees - (firstDataMg + ((short)(angleDeg) * ((firstDataMg - firstDataMgDown) / (firstDataAcc - firstDataAccDown))));

                                }
                                else
                                {
                                    mgdata = (int)((azimuthDegrees - firstDataMg));

                                }


                                bulletLocationYz -= (int)((projection - firstDataAcc) * distance);
                                bulletLocationXz += (int)(mgdata * 18);//* targetWidth/50
                                //bulletXLbl.Text = firstDataMg.ToString() + '\n' + firstDataMgUp.ToString() + '\n' + firstDataMgDown.ToString();
                                //bulletYLbl.Text = firstDataAcc.ToString() + '\n' + firstDataAccUp.ToString() + '\n' + firstDataAccDown.ToString();

                            }


                            bulletLocationXz = Math.Max(targetMinX, Math.Min(bulletLocationXz, targetMaxX));
                            bulletLocationYz = Math.Max(targetMinY, Math.Min(bulletLocationYz, targetMaxY));

                            bulletHolePB.Location = new Point(bulletLocationXz, bulletLocationYz);

                            /*yukarý aþaðý lbl */
                            // projectionLbl.Text = accelX.ToString() + '\n' + accelY.ToString() + '\n' + accelZ.ToString() + '\n' + angleDeg.ToString() + '\n' + projection.ToString();

                            /*sað sol lbl */
                            // xHmcLBL.Text = mgX.ToString() + '\n' + mgY.ToString() + '\n' + mgZ.ToString() + '\n' + azimuthRadian.ToString() + '\n' + azimuthDegrees.ToString();


                            triggerGreenPB.Visible = true;

                        }
                        if (status == 5)
                        {

                            bulletCount--;
                        }
                        else if (status == 3) { calibrateOkBTN.Enabled = true; }

                        bulletNumLbl.Text = bulletCount.ToString();
                        if (lbl2 == 0)
                        {

                            youDoLBL.Text = "If Calibration Finished, Click Calibration Stop";
                            lbl2++;
                        }

                    }
                    else
                    {

                        _ = MessageBox.Show("Yetersiz mermi, Þarjör deðiþtiriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (status == 3)
                        {
                            status = 1;
                        }
                    }
                }
                else if (status == 6)
                {
                    _ = MessageBox.Show("Yetersiz mermi, Þarjör deðiþtiriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception e)
            {
                _ = MessageBox.Show(e.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }



        private void SetControlLocationsAndSizes()
        {
            formWidth = this.Size.Width;
            formHeight = this.Size.Height;

            logoTextWidth = logoTextPB.Width;
            logoTextLocationX = (formWidth - logoTextWidth) / 2;
            logoTextLocationY = 2;

            targetLocationX = (formWidth / 4);
            targetLocationY = 142;
            targetWidth = formWidth / 2;
            targetHeight = formHeight - 200;

            exitLocationX = formWidth - exitPB.Width * 3 / 2;


            bulletWidth = 12;
            bulletLocationX = targetLocationX + (targetWidth - bulletWidth) / 2;
            bulletLocationY = targetLocationY + (targetHeight - bulletWidth) / 2;

            targetMinX = targetLocationX;
            targetMaxX = targetPB.Width + targetLocationX;
            targetMinY = targetLocationY;
            targetMaxY = targetPB.Height + targetLocationY;

            exitPB.Location = new Point(exitLocationX, logoTextLocationY);
            logoTextPB.Location = new Point(logoTextLocationX, logoTextLocationY);
            targetPB.Location = new Point(targetLocationX, targetLocationY);
            targetPB.Size = new System.Drawing.Size(targetWidth, targetHeight);
            bulletHolePB.Size = new System.Drawing.Size(bulletWidth, bulletWidth);
            bulletHolePB.Location = new Point(bulletLocationX, bulletLocationY);




        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!srlPort.IsOpen)
                {
                    string selectedPort = bluetoothCMB.SelectedItem.ToString() ?? "DefaultPort";

                    // Eðer seçilen öðe "Silah" ise, port ismini COM10 olarak deðiþtir
                    if (selectedPort == "Silah")
                    {
                        selectedPort = "COM10";
                    }
                    srlPort.PortName = selectedPort;
                    srlPort.DtrEnable = true;
                    srlPort.RtsEnable = true;
                    srlPort.Open();
                    calibrateStartBTN.Enabled = true;
                    conNotPB.Visible = false;
                    conOkPB.Visible = true;
                    youDoLBL.Text = "Click to Calibration Start";

                }
                srlPort.DataReceived += new SerialDataReceivedEventHandler(SrlPort_DataReceived);


            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, ("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void bluetoothCMB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConnectBtn.Enabled = true;
        }

        private void exitPB_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            SetControlLocationsAndSizes();

        }

        private void calibrateStartBTN_Click(object sender, EventArgs e)
        {
            unLoadRedPB.Visible = false;
            unloadRedGifPB.Visible = true;
            reloadRedPB.Visible = false;
            reloadRedGifPB.Visible = true;
            triggerRedPB.Visible = false;
            triggerRedGifPB.Visible = true;
            status = 1;
            youDoLBL.Text = "Push The Unloading Button";
        }

        private void calibrateOkBTN_Click(object sender, EventArgs e)
        {
            StartBtn.Enabled = true;
            calibrateStartBTN.Enabled = false;
            youDoLBL.Text = "If You Ready , Click Start";
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            calibrateOkBTN.Enabled = false;
            status = 5;
            youDoLBL.Text = " GOOD LUCK";
        }
    }
}

