namespace TigerShootingRange
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            bluetoothCMB = new ComboBox();
            label1 = new Label();
            logoTextPB = new PictureBox();
            ConnectBtn = new Button();
            conOkPB = new PictureBox();
            conNotPB = new PictureBox();
            btnScan = new Button();
            listBoxDevices = new ListBox();
            targetPB = new PictureBox();
            exitPB = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            triggerRedGifPB = new PictureBox();
            calibrateStartBTN = new Button();
            unloadRedGifPB = new PictureBox();
            reloadRedGifPB = new PictureBox();
            unLoadRedPB = new PictureBox();
            reloadRedPB = new PictureBox();
            triggerRedPB = new PictureBox();
            unLoadGreenPB = new PictureBox();
            reloadGreenPB = new PictureBox();
            triggerGreenPB = new PictureBox();
            bulletHolePB = new PictureBox();
            ımageList1 = new ImageList(components);
            distanceTB = new TrackBar();
            StartBtn = new Button();
            label6 = new Label();
            bulletNumLbl = new Label();
            calibrateOkBTN = new Button();
            youDoLBL = new Label();
            ((System.ComponentModel.ISupportInitialize)logoTextPB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)conOkPB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)conNotPB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)targetPB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)exitPB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)triggerRedGifPB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)unloadRedGifPB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)reloadRedGifPB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)unLoadRedPB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)reloadRedPB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)triggerRedPB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)unLoadGreenPB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)reloadGreenPB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)triggerGreenPB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bulletHolePB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)distanceTB).BeginInit();
            SuspendLayout();
            // 
            // bluetoothCMB
            // 
            bluetoothCMB.FormattingEnabled = true;
            bluetoothCMB.Location = new Point(162, 64);
            bluetoothCMB.Name = "bluetoothCMB";
            bluetoothCMB.Size = new Size(178, 33);
            bluetoothCMB.TabIndex = 0;
            bluetoothCMB.SelectedIndexChanged += bluetoothCMB_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(1, 67);
            label1.Name = "label1";
            label1.Size = new Size(159, 25);
            label1.TabIndex = 1;
            label1.Text = "Bluetooth Port  :";
            // 
            // logoTextPB
            // 
            logoTextPB.AccessibleRole = AccessibleRole.None;
            logoTextPB.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            logoTextPB.Image = (Image)resources.GetObject("logoTextPB.Image");
            logoTextPB.Location = new Point(300, 2);
            logoTextPB.MaximumSize = new Size(555, 50);
            logoTextPB.MinimumSize = new Size(555, 50);
            logoTextPB.Name = "logoTextPB";
            logoTextPB.Size = new Size(555, 50);
            logoTextPB.SizeMode = PictureBoxSizeMode.StretchImage;
            logoTextPB.TabIndex = 2;
            logoTextPB.TabStop = false;
            // 
            // ConnectBtn
            // 
            ConnectBtn.BackColor = Color.PaleGreen;
            ConnectBtn.Enabled = false;
            ConnectBtn.Location = new Point(162, 103);
            ConnectBtn.Name = "ConnectBtn";
            ConnectBtn.Size = new Size(139, 33);
            ConnectBtn.TabIndex = 3;
            ConnectBtn.Text = "CONNECT";
            ConnectBtn.UseVisualStyleBackColor = false;
            ConnectBtn.Click += ConnectBtn_Click;
            // 
            // conOkPB
            // 
            conOkPB.Image = (Image)resources.GetObject("conOkPB.Image");
            conOkPB.Location = new Point(307, 103);
            conOkPB.Name = "conOkPB";
            conOkPB.Size = new Size(33, 33);
            conOkPB.SizeMode = PictureBoxSizeMode.StretchImage;
            conOkPB.TabIndex = 4;
            conOkPB.TabStop = false;
            conOkPB.Visible = false;
            // 
            // conNotPB
            // 
            conNotPB.Image = (Image)resources.GetObject("conNotPB.Image");
            conNotPB.Location = new Point(307, 103);
            conNotPB.Name = "conNotPB";
            conNotPB.Size = new Size(33, 33);
            conNotPB.SizeMode = PictureBoxSizeMode.StretchImage;
            conNotPB.TabIndex = 5;
            conNotPB.TabStop = false;
            // 
            // btnScan
            // 
            btnScan.Location = new Point(0, 0);
            btnScan.Name = "btnScan";
            btnScan.Size = new Size(75, 23);
            btnScan.TabIndex = 0;
            // 
            // listBoxDevices
            // 
            listBoxDevices.Location = new Point(0, 0);
            listBoxDevices.Name = "listBoxDevices";
            listBoxDevices.Size = new Size(120, 96);
            listBoxDevices.TabIndex = 0;
            // 
            // targetPB
            // 
            targetPB.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            targetPB.BackColor = Color.Transparent;
            targetPB.Image = (Image)resources.GetObject("targetPB.Image");
            targetPB.Location = new Point(300, 142);
            targetPB.Name = "targetPB";
            targetPB.Size = new Size(596, 470);
            targetPB.SizeMode = PictureBoxSizeMode.StretchImage;
            targetPB.TabIndex = 6;
            targetPB.TabStop = false;
            // 
            // exitPB
            // 
            exitPB.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            exitPB.Image = (Image)resources.GetObject("exitPB.Image");
            exitPB.Location = new Point(1128, 2);
            exitPB.Name = "exitPB";
            exitPB.Size = new Size(44, 43);
            exitPB.SizeMode = PictureBoxSizeMode.StretchImage;
            exitPB.TabIndex = 7;
            exitPB.TabStop = false;
            exitPB.Click += exitPB_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(12, 275);
            label2.Name = "label2";
            label2.Size = new Size(159, 25);
            label2.TabIndex = 8;
            label2.Text = "Trigger Button  :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(12, 175);
            label3.Name = "label3";
            label3.Size = new Size(159, 25);
            label3.TabIndex = 9;
            label3.Text = "Unload Button  :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(11, 225);
            label4.Name = "label4";
            label4.Size = new Size(160, 25);
            label4.TabIndex = 10;
            label4.Text = "Reload Button   :";
            // 
            // triggerRedGifPB
            // 
            triggerRedGifPB.BackColor = Color.FromArgb(38, 80, 115);
            triggerRedGifPB.Image = (Image)resources.GetObject("triggerRedGifPB.Image");
            triggerRedGifPB.Location = new Point(177, 270);
            triggerRedGifPB.Name = "triggerRedGifPB";
            triggerRedGifPB.Size = new Size(37, 34);
            triggerRedGifPB.SizeMode = PictureBoxSizeMode.StretchImage;
            triggerRedGifPB.TabIndex = 11;
            triggerRedGifPB.TabStop = false;
            triggerRedGifPB.Visible = false;
            // 
            // calibrateStartBTN
            // 
            calibrateStartBTN.BackColor = Color.FromArgb(154, 208, 194);
            calibrateStartBTN.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            calibrateStartBTN.Location = new Point(42, 328);
            calibrateStartBTN.Name = "calibrateStartBTN";
            calibrateStartBTN.Size = new Size(221, 51);
            calibrateStartBTN.TabIndex = 13;
            calibrateStartBTN.Text = "Calibration Start";
            calibrateStartBTN.UseVisualStyleBackColor = false;
            calibrateStartBTN.Click += calibrateStartBTN_Click;
            // 
            // unloadRedGifPB
            // 
            unloadRedGifPB.BackColor = Color.FromArgb(38, 80, 115);
            unloadRedGifPB.Image = (Image)resources.GetObject("unloadRedGifPB.Image");
            unloadRedGifPB.Location = new Point(177, 170);
            unloadRedGifPB.Name = "unloadRedGifPB";
            unloadRedGifPB.Size = new Size(37, 34);
            unloadRedGifPB.SizeMode = PictureBoxSizeMode.StretchImage;
            unloadRedGifPB.TabIndex = 14;
            unloadRedGifPB.TabStop = false;
            unloadRedGifPB.Visible = false;
            // 
            // reloadRedGifPB
            // 
            reloadRedGifPB.BackColor = Color.FromArgb(38, 80, 115);
            reloadRedGifPB.Image = (Image)resources.GetObject("reloadRedGifPB.Image");
            reloadRedGifPB.Location = new Point(177, 220);
            reloadRedGifPB.Name = "reloadRedGifPB";
            reloadRedGifPB.Size = new Size(37, 34);
            reloadRedGifPB.SizeMode = PictureBoxSizeMode.StretchImage;
            reloadRedGifPB.TabIndex = 15;
            reloadRedGifPB.TabStop = false;
            reloadRedGifPB.Visible = false;
            // 
            // unLoadRedPB
            // 
            unLoadRedPB.BackColor = Color.FromArgb(38, 80, 115);
            unLoadRedPB.Image = (Image)resources.GetObject("unLoadRedPB.Image");
            unLoadRedPB.Location = new Point(177, 170);
            unLoadRedPB.Name = "unLoadRedPB";
            unLoadRedPB.Size = new Size(37, 34);
            unLoadRedPB.SizeMode = PictureBoxSizeMode.StretchImage;
            unLoadRedPB.TabIndex = 16;
            unLoadRedPB.TabStop = false;
            // 
            // reloadRedPB
            // 
            reloadRedPB.BackColor = Color.FromArgb(38, 80, 115);
            reloadRedPB.Image = (Image)resources.GetObject("reloadRedPB.Image");
            reloadRedPB.Location = new Point(177, 220);
            reloadRedPB.Name = "reloadRedPB";
            reloadRedPB.Size = new Size(37, 34);
            reloadRedPB.SizeMode = PictureBoxSizeMode.StretchImage;
            reloadRedPB.TabIndex = 17;
            reloadRedPB.TabStop = false;
            // 
            // triggerRedPB
            // 
            triggerRedPB.BackColor = Color.FromArgb(38, 80, 115);
            triggerRedPB.Image = (Image)resources.GetObject("triggerRedPB.Image");
            triggerRedPB.Location = new Point(177, 270);
            triggerRedPB.Name = "triggerRedPB";
            triggerRedPB.Size = new Size(37, 34);
            triggerRedPB.SizeMode = PictureBoxSizeMode.StretchImage;
            triggerRedPB.TabIndex = 18;
            triggerRedPB.TabStop = false;
            // 
            // unLoadGreenPB
            // 
            unLoadGreenPB.BackColor = Color.FromArgb(38, 80, 115);
            unLoadGreenPB.Image = (Image)resources.GetObject("unLoadGreenPB.Image");
            unLoadGreenPB.Location = new Point(177, 170);
            unLoadGreenPB.Name = "unLoadGreenPB";
            unLoadGreenPB.Size = new Size(37, 34);
            unLoadGreenPB.SizeMode = PictureBoxSizeMode.StretchImage;
            unLoadGreenPB.TabIndex = 19;
            unLoadGreenPB.TabStop = false;
            unLoadGreenPB.Visible = false;
            // 
            // reloadGreenPB
            // 
            reloadGreenPB.BackColor = Color.FromArgb(38, 80, 115);
            reloadGreenPB.Image = (Image)resources.GetObject("reloadGreenPB.Image");
            reloadGreenPB.Location = new Point(177, 220);
            reloadGreenPB.Name = "reloadGreenPB";
            reloadGreenPB.Size = new Size(37, 34);
            reloadGreenPB.SizeMode = PictureBoxSizeMode.StretchImage;
            reloadGreenPB.TabIndex = 20;
            reloadGreenPB.TabStop = false;
            reloadGreenPB.Visible = false;
            // 
            // triggerGreenPB
            // 
            triggerGreenPB.BackColor = Color.FromArgb(38, 80, 115);
            triggerGreenPB.Image = (Image)resources.GetObject("triggerGreenPB.Image");
            triggerGreenPB.Location = new Point(177, 270);
            triggerGreenPB.Name = "triggerGreenPB";
            triggerGreenPB.Size = new Size(37, 34);
            triggerGreenPB.SizeMode = PictureBoxSizeMode.StretchImage;
            triggerGreenPB.TabIndex = 21;
            triggerGreenPB.TabStop = false;
            triggerGreenPB.Visible = false;
            // 
            // bulletHolePB
            // 
            bulletHolePB.BackColor = Color.DarkRed;
            bulletHolePB.Image = (Image)resources.GetObject("bulletHolePB.Image");
            bulletHolePB.Location = new Point(647, 175);
            bulletHolePB.Name = "bulletHolePB";
            bulletHolePB.Size = new Size(10, 10);
            bulletHolePB.SizeMode = PictureBoxSizeMode.StretchImage;
            bulletHolePB.TabIndex = 30;
            bulletHolePB.TabStop = false;
            // 
            // ımageList1
            // 
            ımageList1.ColorDepth = ColorDepth.Depth8Bit;
            ımageList1.ImageSize = new Size(16, 16);
            ımageList1.TransparentColor = Color.Transparent;
            // 
            // distanceTB
            // 
            distanceTB.Location = new Point(42, 397);
            distanceTB.Maximum = 50;
            distanceTB.Name = "distanceTB";
            distanceTB.Size = new Size(221, 45);
            distanceTB.TabIndex = 57;
            distanceTB.TickFrequency = 5;
            distanceTB.Value = 30;
            // 
            // StartBtn
            // 
            StartBtn.BackColor = Color.GreenYellow;
            StartBtn.Font = new Font("Arial Black", 18F, FontStyle.Bold, GraphicsUnit.Point);
            StartBtn.Location = new Point(42, 496);
            StartBtn.Name = "StartBtn";
            StartBtn.Size = new Size(221, 51);
            StartBtn.TabIndex = 58;
            StartBtn.Text = "Start";
            StartBtn.UseVisualStyleBackColor = false;
            StartBtn.Click += StartBtn_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(42, 559);
            label6.Name = "label6";
            label6.Size = new Size(104, 32);
            label6.TabIndex = 59;
            label6.Text = "Ammo :";
            // 
            // bulletNumLbl
            // 
            bulletNumLbl.AutoSize = true;
            bulletNumLbl.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            bulletNumLbl.Location = new Point(148, 559);
            bulletNumLbl.Name = "bulletNumLbl";
            bulletNumLbl.Size = new Size(28, 32);
            bulletNumLbl.TabIndex = 60;
            bulletNumLbl.Text = "0";
            // 
            // calibrateOkBTN
            // 
            calibrateOkBTN.BackColor = Color.FromArgb(154, 208, 194);
            calibrateOkBTN.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            calibrateOkBTN.Location = new Point(42, 439);
            calibrateOkBTN.Name = "calibrateOkBTN";
            calibrateOkBTN.Size = new Size(221, 51);
            calibrateOkBTN.TabIndex = 61;
            calibrateOkBTN.Text = "Calibration Stop";
            calibrateOkBTN.UseVisualStyleBackColor = false;
            calibrateOkBTN.Click += calibrateOkBTN_Click;
            // 
            // youDoLBL
            // 
            youDoLBL.AutoSize = true;
            youDoLBL.BackColor = Color.LightCoral;
            youDoLBL.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            youDoLBL.ForeColor = Color.Black;
            youDoLBL.Location = new Point(373, 64);
            youDoLBL.Name = "youDoLBL";
            youDoLBL.Size = new Size(96, 37);
            youDoLBL.TabIndex = 66;
            youDoLBL.Text = "label5";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(38, 80, 115);
            ClientSize = new Size(1184, 624);
            ControlBox = false;
            Controls.Add(youDoLBL);
            Controls.Add(calibrateOkBTN);
            Controls.Add(bulletNumLbl);
            Controls.Add(label6);
            Controls.Add(StartBtn);
            Controls.Add(distanceTB);
            Controls.Add(bulletHolePB);
            Controls.Add(targetPB);
            Controls.Add(triggerGreenPB);
            Controls.Add(reloadGreenPB);
            Controls.Add(unLoadGreenPB);
            Controls.Add(triggerRedPB);
            Controls.Add(reloadRedPB);
            Controls.Add(unLoadRedPB);
            Controls.Add(reloadRedGifPB);
            Controls.Add(unloadRedGifPB);
            Controls.Add(calibrateStartBTN);
            Controls.Add(triggerRedGifPB);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(exitPB);
            Controls.Add(conOkPB);
            Controls.Add(ConnectBtn);
            Controls.Add(label1);
            Controls.Add(bluetoothCMB);
            Controls.Add(logoTextPB);
            Controls.Add(conNotPB);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5);
            Name = "Form1";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tiger Shooting Calibration";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            SizeChanged += Form1_SizeChanged;
            ((System.ComponentModel.ISupportInitialize)logoTextPB).EndInit();
            ((System.ComponentModel.ISupportInitialize)conOkPB).EndInit();
            ((System.ComponentModel.ISupportInitialize)conNotPB).EndInit();
            ((System.ComponentModel.ISupportInitialize)targetPB).EndInit();
            ((System.ComponentModel.ISupportInitialize)exitPB).EndInit();
            ((System.ComponentModel.ISupportInitialize)triggerRedGifPB).EndInit();
            ((System.ComponentModel.ISupportInitialize)unloadRedGifPB).EndInit();
            ((System.ComponentModel.ISupportInitialize)reloadRedGifPB).EndInit();
            ((System.ComponentModel.ISupportInitialize)unLoadRedPB).EndInit();
            ((System.ComponentModel.ISupportInitialize)reloadRedPB).EndInit();
            ((System.ComponentModel.ISupportInitialize)triggerRedPB).EndInit();
            ((System.ComponentModel.ISupportInitialize)unLoadGreenPB).EndInit();
            ((System.ComponentModel.ISupportInitialize)reloadGreenPB).EndInit();
            ((System.ComponentModel.ISupportInitialize)triggerGreenPB).EndInit();
            ((System.ComponentModel.ISupportInitialize)bulletHolePB).EndInit();
            ((System.ComponentModel.ISupportInitialize)distanceTB).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox bluetoothCMB;
        private Label label1;
        private PictureBox logoTextPB;
        private Button ConnectBtn;
        private PictureBox conOkPB;
        private PictureBox conNotPB;
        private Button btnScan;
        private ListBox listBoxDevices;
        private PictureBox targetPB;
        private PictureBox exitPB;
        private Label label2;
        private Label label3;
        private Label label4;
        private PictureBox triggerRedGifPB;
        private Button calibrateStartBTN;
        private PictureBox unloadRedGifPB;
        private PictureBox reloadRedGifPB;
        private PictureBox unLoadRedPB;
        private PictureBox reloadRedPB;
        private PictureBox triggerRedPB;
        private PictureBox unLoadGreenPB;
        private PictureBox reloadGreenPB;
        private PictureBox triggerGreenPB;
        private PictureBox bulletHolePB;
        private ImageList ımageList1;
        private TrackBar distanceTB;
        private Button StartBtn;
        private Label label6;
        private Label bulletNumLbl;
        private Button calibrateOkBTN;
        private Label youDoLBL;
    }
}