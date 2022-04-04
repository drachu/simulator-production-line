
using OpenHardwareMonitor.Hardware;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace Projekt3_symLiniiProdukcyjnej
{
    

    partial class FormSimulator
    {
        Random random = new Random();
        int chanceForAccident = 20;
        int randomizedNumber = 0;
        int randomAcccidentNumber = 0;

        int checkCounter = 0;
        int checkTime = 15;

        public static bool check = false;

        float tempCPU1 = 0;
        float tempCPU2 = 0;
        float tempCPU3 = 0;
        float tempCPU4 = 0;

        float loadCPU1 = 0;
        float loadCPU2 = 0;
        float loadCPU3 = 0;
        float loadCPU4 = 0;

        float tempCPU1AccidentValue = 0;
        float tempCPU2AccidentValue = 0;
        float tempCPU3AccidentValue = 0;
        float tempCPU4AccidentValue = 0;

        float loadCPU1AccidentValue = 0;
        float loadCPU2AccidentValue = 0;
        float loadCPU3AccidentValue = 0;
        float loadCPU4AccidentValue = 0;

        bool tempCPU1Accident = false;
        bool tempCPU2Accident = false;
        bool tempCPU3Accident = false;
        bool tempCPU4Accident = false;

        bool loadCPU1Accident = false;
        bool loadCPU2Accident = false;
        bool loadCPU3Accident = false;
        bool loadCPU4Accident = false;

        bool fan1 = false;
        bool fan2 = false;
        bool fan3 = false;
        bool fan4 = false;

        int fanLimit = 15;
        int fan1Count = 0;
        int fan2Count = 0;
        int fan3Count = 0;
        int fan4Count = 0;

        int tempLimit = 8;
        int tempCPU1Count = 0;
        int tempCPU2Count = 0;
        int tempCPU3Count = 0;
        int tempCPU4Count = 0;

        bool strainer1 = false;
        bool strainer2 = false;
        bool strainer3 = false;
        bool strainer4 = false;

        int strainingLoadValue = 5;
        int strainingValue = 15;
        float strainerCPU1Add = 0;
        float strainerCPU2Add = 0;
        float strainerCPU3Add = 0;
        float strainerCPU4Add = 0;

        int loadLimit = 8;
        int loadCPU1Count = 0;
        int loadCPU2Count = 0;
        int loadCPU3Count = 0;
        int loadCPU4Count = 0;

        Computer cGPU = new Computer()
        {
            GPUEnabled = true
        };
        Computer cCPU = new Computer()
        {
            CPUEnabled = true
        };
        Computer cFan = new Computer()
        {
            FanControllerEnabled = true
        };


        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelTemp1 = new System.Windows.Forms.Label();
            this.labelTemp2 = new System.Windows.Forms.Label();
            this.labelTemp3 = new System.Windows.Forms.Label();
            this.labelTemp4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupTemperature = new System.Windows.Forms.GroupBox();
            this.engineImage4Critical = new System.Windows.Forms.PictureBox();
            this.engineImage3Critical = new System.Windows.Forms.PictureBox();
            this.engineImage2Critical = new System.Windows.Forms.PictureBox();
            this.engineImage1Critical = new System.Windows.Forms.PictureBox();
            this.engineImage4Warning = new System.Windows.Forms.PictureBox();
            this.engineImage3Warning = new System.Windows.Forms.PictureBox();
            this.engineImage2Warning = new System.Windows.Forms.PictureBox();
            this.engineImage1Warning = new System.Windows.Forms.PictureBox();
            this.engineImage4 = new System.Windows.Forms.PictureBox();
            this.engineImage2 = new System.Windows.Forms.PictureBox();
            this.engineImage1 = new System.Windows.Forms.PictureBox();
            this.engineImage3 = new System.Windows.Forms.PictureBox();
            this.labelEngine4 = new System.Windows.Forms.Label();
            this.labelEngine3 = new System.Windows.Forms.Label();
            this.labelEngine2 = new System.Windows.Forms.Label();
            this.labelEngine1 = new System.Windows.Forms.Label();
            this.TemperatureImageCritical = new System.Windows.Forms.PictureBox();
            this.TemperatureImageWarning = new System.Windows.Forms.PictureBox();
            this.tempImage = new System.Windows.Forms.PictureBox();
            this.engine2bar1 = new System.Windows.Forms.PictureBox();
            this.engine4bar1 = new System.Windows.Forms.PictureBox();
            this.engine3bar1 = new System.Windows.Forms.PictureBox();
            this.engine2bar2 = new System.Windows.Forms.PictureBox();
            this.engine4bar2 = new System.Windows.Forms.PictureBox();
            this.engine3bar2 = new System.Windows.Forms.PictureBox();
            this.engine1bar1 = new System.Windows.Forms.PictureBox();
            this.engine1bar2 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelMachineState4 = new System.Windows.Forms.Label();
            this.labelMachineState3 = new System.Windows.Forms.Label();
            this.labelMachineState2 = new System.Windows.Forms.Label();
            this.labelMachineState1 = new System.Windows.Forms.Label();
            this.labelMachine4 = new System.Windows.Forms.Label();
            this.labelMachine3 = new System.Windows.Forms.Label();
            this.labelMachine2 = new System.Windows.Forms.Label();
            this.labelMachine1 = new System.Windows.Forms.Label();
            this.LoadImageWarning = new System.Windows.Forms.PictureBox();
            this.LoadImageCritical = new System.Windows.Forms.PictureBox();
            this.loadImage = new System.Windows.Forms.PictureBox();
            this.progressBarLoad4 = new System.Windows.Forms.ProgressBar();
            this.progressBarLoad3 = new System.Windows.Forms.ProgressBar();
            this.progressBarLoad2 = new System.Windows.Forms.ProgressBar();
            this.progressBarLoad1 = new System.Windows.Forms.ProgressBar();
            this.labelLoad1 = new System.Windows.Forms.Label();
            this.labelLoad3 = new System.Windows.Forms.Label();
            this.labelLoad2 = new System.Windows.Forms.Label();
            this.labelLoad4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.errorImageFan4 = new System.Windows.Forms.PictureBox();
            this.errorImageFan3 = new System.Windows.Forms.PictureBox();
            this.errorImageFan2 = new System.Windows.Forms.PictureBox();
            this.errorImageFan1 = new System.Windows.Forms.PictureBox();
            this.buttonFan4OFF = new System.Windows.Forms.Button();
            this.buttonFan4ON = new System.Windows.Forms.Button();
            this.labelFan4 = new System.Windows.Forms.Label();
            this.buttonFan3OFF = new System.Windows.Forms.Button();
            this.buttonFan3ON = new System.Windows.Forms.Button();
            this.labelFan3 = new System.Windows.Forms.Label();
            this.buttonFan2OFF = new System.Windows.Forms.Button();
            this.buttonFan2ON = new System.Windows.Forms.Button();
            this.labelFan2 = new System.Windows.Forms.Label();
            this.buttonFan1OFF = new System.Windows.Forms.Button();
            this.buttonFan1ON = new System.Windows.Forms.Button();
            this.labelFan1 = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.errorImageOverload = new System.Windows.Forms.PictureBox();
            this.labelOverload = new System.Windows.Forms.Label();
            this.overloadBar1 = new System.Windows.Forms.PictureBox();
            this.labelStrainerON4 = new System.Windows.Forms.Label();
            this.labelStrainerOFF4 = new System.Windows.Forms.Label();
            this.labelStrainerOFF3 = new System.Windows.Forms.Label();
            this.labelStrainerON3 = new System.Windows.Forms.Label();
            this.labelStrainerOFF2 = new System.Windows.Forms.Label();
            this.labelStrainerON2 = new System.Windows.Forms.Label();
            this.labelStrainerOFF1 = new System.Windows.Forms.Label();
            this.labelStrainerON1 = new System.Windows.Forms.Label();
            this.trackBarStrainer4 = new System.Windows.Forms.TrackBar();
            this.trackBarStrainer3 = new System.Windows.Forms.TrackBar();
            this.trackBarStrainer2 = new System.Windows.Forms.TrackBar();
            this.trackBarStrainer1 = new System.Windows.Forms.TrackBar();
            this.labelStrainer1 = new System.Windows.Forms.Label();
            this.labelStrainer3 = new System.Windows.Forms.Label();
            this.labelStrainer2 = new System.Windows.Forms.Label();
            this.labelStrainer4 = new System.Windows.Forms.Label();
            this.overloadBar2 = new System.Windows.Forms.PictureBox();
            this.groupBoxWorkMode = new System.Windows.Forms.GroupBox();
            this.radioButtonModeManual = new System.Windows.Forms.RadioButton();
            this.radioButtonModeAuto = new System.Windows.Forms.RadioButton();
            this.groupTemperature.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.engineImage4Critical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.engineImage3Critical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.engineImage2Critical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.engineImage1Critical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.engineImage4Warning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.engineImage3Warning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.engineImage2Warning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.engineImage1Warning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.engineImage4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.engineImage2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.engineImage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.engineImage3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TemperatureImageCritical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TemperatureImageWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.engine2bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.engine4bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.engine3bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.engine2bar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.engine4bar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.engine3bar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.engine1bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.engine1bar2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoadImageWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadImageCritical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadImage)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorImageFan4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorImageFan3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorImageFan2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorImageFan1)).BeginInit();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorImageOverload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overloadBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarStrainer4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarStrainer3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarStrainer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarStrainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overloadBar2)).BeginInit();
            this.groupBoxWorkMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(187, 662);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(141, 47);
            this.buttonExit.TabIndex = 0;
            this.buttonExit.Text = "Zakończ";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // labelTemp1
            // 
            this.labelTemp1.AutoSize = true;
            this.labelTemp1.Location = new System.Drawing.Point(83, 136);
            this.labelTemp1.Name = "labelTemp1";
            this.labelTemp1.Size = new System.Drawing.Size(58, 20);
            this.labelTemp1.TabIndex = 1;
            this.labelTemp1.Text = "Temp1";
            // 
            // labelTemp2
            // 
            this.labelTemp2.AutoSize = true;
            this.labelTemp2.Location = new System.Drawing.Point(296, 133);
            this.labelTemp2.Name = "labelTemp2";
            this.labelTemp2.Size = new System.Drawing.Size(58, 20);
            this.labelTemp2.TabIndex = 2;
            this.labelTemp2.Text = "Temp2";
            // 
            // labelTemp3
            // 
            this.labelTemp3.AutoSize = true;
            this.labelTemp3.Location = new System.Drawing.Point(83, 313);
            this.labelTemp3.Name = "labelTemp3";
            this.labelTemp3.Size = new System.Drawing.Size(58, 20);
            this.labelTemp3.TabIndex = 3;
            this.labelTemp3.Text = "Temp3";
            // 
            // labelTemp4
            // 
            this.labelTemp4.AutoSize = true;
            this.labelTemp4.Location = new System.Drawing.Point(296, 313);
            this.labelTemp4.Name = "labelTemp4";
            this.labelTemp4.Size = new System.Drawing.Size(58, 20);
            this.labelTemp4.TabIndex = 4;
            this.labelTemp4.Text = "Temp4";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupTemperature
            // 
            this.groupTemperature.Controls.Add(this.engineImage4Critical);
            this.groupTemperature.Controls.Add(this.engineImage3Critical);
            this.groupTemperature.Controls.Add(this.engineImage2Critical);
            this.groupTemperature.Controls.Add(this.engineImage1Critical);
            this.groupTemperature.Controls.Add(this.engineImage4Warning);
            this.groupTemperature.Controls.Add(this.engineImage3Warning);
            this.groupTemperature.Controls.Add(this.engineImage2Warning);
            this.groupTemperature.Controls.Add(this.engineImage1Warning);
            this.groupTemperature.Controls.Add(this.engineImage4);
            this.groupTemperature.Controls.Add(this.engineImage2);
            this.groupTemperature.Controls.Add(this.engineImage1);
            this.groupTemperature.Controls.Add(this.engineImage3);
            this.groupTemperature.Controls.Add(this.labelEngine4);
            this.groupTemperature.Controls.Add(this.labelEngine3);
            this.groupTemperature.Controls.Add(this.labelEngine2);
            this.groupTemperature.Controls.Add(this.labelEngine1);
            this.groupTemperature.Controls.Add(this.TemperatureImageCritical);
            this.groupTemperature.Controls.Add(this.TemperatureImageWarning);
            this.groupTemperature.Controls.Add(this.tempImage);
            this.groupTemperature.Controls.Add(this.labelTemp1);
            this.groupTemperature.Controls.Add(this.labelTemp3);
            this.groupTemperature.Controls.Add(this.labelTemp2);
            this.groupTemperature.Controls.Add(this.labelTemp4);
            this.groupTemperature.Controls.Add(this.engine2bar1);
            this.groupTemperature.Controls.Add(this.engine4bar1);
            this.groupTemperature.Controls.Add(this.engine3bar1);
            this.groupTemperature.Controls.Add(this.engine2bar2);
            this.groupTemperature.Controls.Add(this.engine4bar2);
            this.groupTemperature.Controls.Add(this.engine3bar2);
            this.groupTemperature.Controls.Add(this.engine1bar1);
            this.groupTemperature.Controls.Add(this.engine1bar2);
            this.groupTemperature.Location = new System.Drawing.Point(53, 51);
            this.groupTemperature.Name = "groupTemperature";
            this.groupTemperature.Size = new System.Drawing.Size(418, 577);
            this.groupTemperature.TabIndex = 7;
            this.groupTemperature.TabStop = false;
            this.groupTemperature.Text = "Temperatury silników";
            // 
            // engineImage4Critical
            // 
            this.engineImage4Critical.Image = global::Projekt3_symLiniiProdukcyjnej.Properties.Resources.engineRed;
            this.engineImage4Critical.Location = new System.Drawing.Point(300, 213);
            this.engineImage4Critical.Name = "engineImage4Critical";
            this.engineImage4Critical.Size = new System.Drawing.Size(87, 76);
            this.engineImage4Critical.TabIndex = 42;
            this.engineImage4Critical.TabStop = false;
            this.engineImage4Critical.Visible = false;
            // 
            // engineImage3Critical
            // 
            this.engineImage3Critical.Image = global::Projekt3_symLiniiProdukcyjnej.Properties.Resources.engineRed;
            this.engineImage3Critical.Location = new System.Drawing.Point(87, 213);
            this.engineImage3Critical.Name = "engineImage3Critical";
            this.engineImage3Critical.Size = new System.Drawing.Size(87, 76);
            this.engineImage3Critical.TabIndex = 41;
            this.engineImage3Critical.TabStop = false;
            this.engineImage3Critical.Visible = false;
            // 
            // engineImage2Critical
            // 
            this.engineImage2Critical.Image = global::Projekt3_symLiniiProdukcyjnej.Properties.Resources.engineRed;
            this.engineImage2Critical.Location = new System.Drawing.Point(300, 33);
            this.engineImage2Critical.Name = "engineImage2Critical";
            this.engineImage2Critical.Size = new System.Drawing.Size(87, 76);
            this.engineImage2Critical.TabIndex = 40;
            this.engineImage2Critical.TabStop = false;
            this.engineImage2Critical.Visible = false;
            // 
            // engineImage1Critical
            // 
            this.engineImage1Critical.Image = global::Projekt3_symLiniiProdukcyjnej.Properties.Resources.engineRed;
            this.engineImage1Critical.Location = new System.Drawing.Point(87, 33);
            this.engineImage1Critical.Name = "engineImage1Critical";
            this.engineImage1Critical.Size = new System.Drawing.Size(87, 76);
            this.engineImage1Critical.TabIndex = 39;
            this.engineImage1Critical.TabStop = false;
            this.engineImage1Critical.Visible = false;
            // 
            // engineImage4Warning
            // 
            this.engineImage4Warning.Image = global::Projekt3_symLiniiProdukcyjnej.Properties.Resources.engineYellow;
            this.engineImage4Warning.Location = new System.Drawing.Point(300, 213);
            this.engineImage4Warning.Name = "engineImage4Warning";
            this.engineImage4Warning.Size = new System.Drawing.Size(87, 76);
            this.engineImage4Warning.TabIndex = 38;
            this.engineImage4Warning.TabStop = false;
            this.engineImage4Warning.Visible = false;
            // 
            // engineImage3Warning
            // 
            this.engineImage3Warning.Image = global::Projekt3_symLiniiProdukcyjnej.Properties.Resources.engineYellow;
            this.engineImage3Warning.Location = new System.Drawing.Point(87, 213);
            this.engineImage3Warning.Name = "engineImage3Warning";
            this.engineImage3Warning.Size = new System.Drawing.Size(87, 76);
            this.engineImage3Warning.TabIndex = 37;
            this.engineImage3Warning.TabStop = false;
            this.engineImage3Warning.Visible = false;
            // 
            // engineImage2Warning
            // 
            this.engineImage2Warning.Image = global::Projekt3_symLiniiProdukcyjnej.Properties.Resources.engineYellow;
            this.engineImage2Warning.Location = new System.Drawing.Point(300, 32);
            this.engineImage2Warning.Name = "engineImage2Warning";
            this.engineImage2Warning.Size = new System.Drawing.Size(87, 76);
            this.engineImage2Warning.TabIndex = 36;
            this.engineImage2Warning.TabStop = false;
            this.engineImage2Warning.Visible = false;
            // 
            // engineImage1Warning
            // 
            this.engineImage1Warning.Image = global::Projekt3_symLiniiProdukcyjnej.Properties.Resources.engineYellow;
            this.engineImage1Warning.Location = new System.Drawing.Point(87, 34);
            this.engineImage1Warning.Name = "engineImage1Warning";
            this.engineImage1Warning.Size = new System.Drawing.Size(87, 76);
            this.engineImage1Warning.TabIndex = 35;
            this.engineImage1Warning.TabStop = false;
            this.engineImage1Warning.Visible = false;
            // 
            // engineImage4
            // 
            this.engineImage4.Image = global::Projekt3_symLiniiProdukcyjnej.Properties.Resources.engineGreen;
            this.engineImage4.Location = new System.Drawing.Point(300, 213);
            this.engineImage4.Name = "engineImage4";
            this.engineImage4.Size = new System.Drawing.Size(87, 76);
            this.engineImage4.TabIndex = 26;
            this.engineImage4.TabStop = false;
            // 
            // engineImage2
            // 
            this.engineImage2.Image = global::Projekt3_symLiniiProdukcyjnej.Properties.Resources.engineGreen;
            this.engineImage2.Location = new System.Drawing.Point(300, 33);
            this.engineImage2.Name = "engineImage2";
            this.engineImage2.Size = new System.Drawing.Size(87, 76);
            this.engineImage2.TabIndex = 25;
            this.engineImage2.TabStop = false;
            // 
            // engineImage1
            // 
            this.engineImage1.Image = global::Projekt3_symLiniiProdukcyjnej.Properties.Resources.engineGreen;
            this.engineImage1.Location = new System.Drawing.Point(87, 34);
            this.engineImage1.Name = "engineImage1";
            this.engineImage1.Size = new System.Drawing.Size(87, 76);
            this.engineImage1.TabIndex = 24;
            this.engineImage1.TabStop = false;
            // 
            // engineImage3
            // 
            this.engineImage3.Image = global::Projekt3_symLiniiProdukcyjnej.Properties.Resources.engineGreen;
            this.engineImage3.Location = new System.Drawing.Point(87, 213);
            this.engineImage3.Name = "engineImage3";
            this.engineImage3.Size = new System.Drawing.Size(87, 76);
            this.engineImage3.TabIndex = 19;
            this.engineImage3.TabStop = false;
            // 
            // labelEngine4
            // 
            this.labelEngine4.AutoSize = true;
            this.labelEngine4.Location = new System.Drawing.Point(296, 293);
            this.labelEngine4.Name = "labelEngine4";
            this.labelEngine4.Size = new System.Drawing.Size(77, 20);
            this.labelEngine4.TabIndex = 23;
            this.labelEngine4.Text = "Silnik nr 4";
            // 
            // labelEngine3
            // 
            this.labelEngine3.AutoSize = true;
            this.labelEngine3.Location = new System.Drawing.Point(83, 293);
            this.labelEngine3.Name = "labelEngine3";
            this.labelEngine3.Size = new System.Drawing.Size(77, 20);
            this.labelEngine3.TabIndex = 22;
            this.labelEngine3.Text = "Silnik nr 3";
            // 
            // labelEngine2
            // 
            this.labelEngine2.AutoSize = true;
            this.labelEngine2.Location = new System.Drawing.Point(296, 113);
            this.labelEngine2.Name = "labelEngine2";
            this.labelEngine2.Size = new System.Drawing.Size(77, 20);
            this.labelEngine2.TabIndex = 21;
            this.labelEngine2.Text = "Silnik nr 2";
            // 
            // labelEngine1
            // 
            this.labelEngine1.AutoSize = true;
            this.labelEngine1.Location = new System.Drawing.Point(83, 113);
            this.labelEngine1.Name = "labelEngine1";
            this.labelEngine1.Size = new System.Drawing.Size(77, 20);
            this.labelEngine1.TabIndex = 20;
            this.labelEngine1.Text = "Silnik nr 1";
            // 
            // TemperatureImageCritical
            // 
            this.TemperatureImageCritical.Image = global::Projekt3_symLiniiProdukcyjnej.Properties.Resources.problemRed;
            this.TemperatureImageCritical.Location = new System.Drawing.Point(255, 402);
            this.TemperatureImageCritical.Name = "TemperatureImageCritical";
            this.TemperatureImageCritical.Size = new System.Drawing.Size(80, 79);
            this.TemperatureImageCritical.TabIndex = 14;
            this.TemperatureImageCritical.TabStop = false;
            this.TemperatureImageCritical.Visible = false;
            // 
            // TemperatureImageWarning
            // 
            this.TemperatureImageWarning.Image = global::Projekt3_symLiniiProdukcyjnej.Properties.Resources.problemYellow;
            this.TemperatureImageWarning.Location = new System.Drawing.Point(255, 479);
            this.TemperatureImageWarning.Name = "TemperatureImageWarning";
            this.TemperatureImageWarning.Size = new System.Drawing.Size(80, 73);
            this.TemperatureImageWarning.TabIndex = 15;
            this.TemperatureImageWarning.TabStop = false;
            this.TemperatureImageWarning.Visible = false;
            // 
            // tempImage
            // 
            this.tempImage.Image = global::Projekt3_symLiniiProdukcyjnej.Properties.Resources.working;
            this.tempImage.Location = new System.Drawing.Point(118, 402);
            this.tempImage.Name = "tempImage";
            this.tempImage.Size = new System.Drawing.Size(161, 150);
            this.tempImage.TabIndex = 10;
            this.tempImage.TabStop = false;
            // 
            // engine2bar1
            // 
            this.engine2bar1.BackgroundImage = global::Projekt3_symLiniiProdukcyjnej.Properties.Resources.emptyBar;
            this.engine2bar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.engine2bar1.Location = new System.Drawing.Point(255, 32);
            this.engine2bar1.Name = "engine2bar1";
            this.engine2bar1.Size = new System.Drawing.Size(20, 120);
            this.engine2bar1.TabIndex = 33;
            this.engine2bar1.TabStop = false;
            // 
            // engine4bar1
            // 
            this.engine4bar1.BackgroundImage = global::Projekt3_symLiniiProdukcyjnej.Properties.Resources.emptyBar;
            this.engine4bar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.engine4bar1.Location = new System.Drawing.Point(255, 213);
            this.engine4bar1.Name = "engine4bar1";
            this.engine4bar1.Size = new System.Drawing.Size(20, 120);
            this.engine4bar1.TabIndex = 34;
            this.engine4bar1.TabStop = false;
            // 
            // engine3bar1
            // 
            this.engine3bar1.BackgroundImage = global::Projekt3_symLiniiProdukcyjnej.Properties.Resources.emptyBar;
            this.engine3bar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.engine3bar1.Location = new System.Drawing.Point(46, 213);
            this.engine3bar1.Name = "engine3bar1";
            this.engine3bar1.Size = new System.Drawing.Size(20, 120);
            this.engine3bar1.TabIndex = 31;
            this.engine3bar1.TabStop = false;
            // 
            // engine2bar2
            // 
            this.engine2bar2.BackgroundImage = global::Projekt3_symLiniiProdukcyjnej.Properties.Resources.fullBar;
            this.engine2bar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.engine2bar2.Location = new System.Drawing.Point(255, 32);
            this.engine2bar2.Name = "engine2bar2";
            this.engine2bar2.Size = new System.Drawing.Size(20, 120);
            this.engine2bar2.TabIndex = 28;
            this.engine2bar2.TabStop = false;
            // 
            // engine4bar2
            // 
            this.engine4bar2.BackgroundImage = global::Projekt3_symLiniiProdukcyjnej.Properties.Resources.fullBar;
            this.engine4bar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.engine4bar2.Location = new System.Drawing.Point(255, 213);
            this.engine4bar2.Name = "engine4bar2";
            this.engine4bar2.Size = new System.Drawing.Size(20, 120);
            this.engine4bar2.TabIndex = 29;
            this.engine4bar2.TabStop = false;
            // 
            // engine3bar2
            // 
            this.engine3bar2.BackgroundImage = global::Projekt3_symLiniiProdukcyjnej.Properties.Resources.fullBar;
            this.engine3bar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.engine3bar2.Location = new System.Drawing.Point(46, 213);
            this.engine3bar2.Name = "engine3bar2";
            this.engine3bar2.Size = new System.Drawing.Size(20, 120);
            this.engine3bar2.TabIndex = 30;
            this.engine3bar2.TabStop = false;
            // 
            // engine1bar1
            // 
            this.engine1bar1.BackgroundImage = global::Projekt3_symLiniiProdukcyjnej.Properties.Resources.emptyBar;
            this.engine1bar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.engine1bar1.Location = new System.Drawing.Point(46, 32);
            this.engine1bar1.Name = "engine1bar1";
            this.engine1bar1.Size = new System.Drawing.Size(20, 120);
            this.engine1bar1.TabIndex = 32;
            this.engine1bar1.TabStop = false;
            // 
            // engine1bar2
            // 
            this.engine1bar2.BackgroundImage = global::Projekt3_symLiniiProdukcyjnej.Properties.Resources.fullBar;
            this.engine1bar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.engine1bar2.Location = new System.Drawing.Point(46, 32);
            this.engine1bar2.Name = "engine1bar2";
            this.engine1bar2.Size = new System.Drawing.Size(20, 120);
            this.engine1bar2.TabIndex = 27;
            this.engine1bar2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelMachineState4);
            this.groupBox1.Controls.Add(this.labelMachineState3);
            this.groupBox1.Controls.Add(this.labelMachineState2);
            this.groupBox1.Controls.Add(this.labelMachineState1);
            this.groupBox1.Controls.Add(this.labelMachine4);
            this.groupBox1.Controls.Add(this.labelMachine3);
            this.groupBox1.Controls.Add(this.labelMachine2);
            this.groupBox1.Controls.Add(this.labelMachine1);
            this.groupBox1.Controls.Add(this.LoadImageWarning);
            this.groupBox1.Controls.Add(this.LoadImageCritical);
            this.groupBox1.Controls.Add(this.loadImage);
            this.groupBox1.Controls.Add(this.progressBarLoad4);
            this.groupBox1.Controls.Add(this.progressBarLoad3);
            this.groupBox1.Controls.Add(this.progressBarLoad2);
            this.groupBox1.Controls.Add(this.progressBarLoad1);
            this.groupBox1.Controls.Add(this.labelLoad1);
            this.groupBox1.Controls.Add(this.labelLoad3);
            this.groupBox1.Controls.Add(this.labelLoad2);
            this.groupBox1.Controls.Add(this.labelLoad4);
            this.groupBox1.Location = new System.Drawing.Point(513, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 577);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Obciążenie maszyn";
            // 
            // labelMachineState4
            // 
            this.labelMachineState4.AutoSize = true;
            this.labelMachineState4.ForeColor = System.Drawing.Color.Green;
            this.labelMachineState4.Location = new System.Drawing.Point(36, 355);
            this.labelMachineState4.Name = "labelMachineState4";
            this.labelMachineState4.Size = new System.Drawing.Size(92, 20);
            this.labelMachineState4.TabIndex = 34;
            this.labelMachineState4.Text = "W NORMIE";
            // 
            // labelMachineState3
            // 
            this.labelMachineState3.AutoSize = true;
            this.labelMachineState3.ForeColor = System.Drawing.Color.Green;
            this.labelMachineState3.Location = new System.Drawing.Point(36, 269);
            this.labelMachineState3.Name = "labelMachineState3";
            this.labelMachineState3.Size = new System.Drawing.Size(92, 20);
            this.labelMachineState3.TabIndex = 33;
            this.labelMachineState3.Text = "W NORMIE";
            // 
            // labelMachineState2
            // 
            this.labelMachineState2.AutoSize = true;
            this.labelMachineState2.ForeColor = System.Drawing.Color.Green;
            this.labelMachineState2.Location = new System.Drawing.Point(36, 185);
            this.labelMachineState2.Name = "labelMachineState2";
            this.labelMachineState2.Size = new System.Drawing.Size(92, 20);
            this.labelMachineState2.TabIndex = 32;
            this.labelMachineState2.Text = "W NORMIE";
            // 
            // labelMachineState1
            // 
            this.labelMachineState1.AutoSize = true;
            this.labelMachineState1.ForeColor = System.Drawing.Color.Green;
            this.labelMachineState1.Location = new System.Drawing.Point(36, 100);
            this.labelMachineState1.Name = "labelMachineState1";
            this.labelMachineState1.Size = new System.Drawing.Size(92, 20);
            this.labelMachineState1.TabIndex = 28;
            this.labelMachineState1.Text = "W NORMIE";
            // 
            // labelMachine4
            // 
            this.labelMachine4.AutoSize = true;
            this.labelMachine4.Location = new System.Drawing.Point(36, 305);
            this.labelMachine4.Name = "labelMachine4";
            this.labelMachine4.Size = new System.Drawing.Size(192, 20);
            this.labelMachine4.TabIndex = 31;
            this.labelMachine4.Text = "Maszyna produkcyjna nr 4";
            // 
            // labelMachine3
            // 
            this.labelMachine3.AutoSize = true;
            this.labelMachine3.Location = new System.Drawing.Point(36, 219);
            this.labelMachine3.Name = "labelMachine3";
            this.labelMachine3.Size = new System.Drawing.Size(192, 20);
            this.labelMachine3.TabIndex = 30;
            this.labelMachine3.Text = "Maszyna produkcyjna nr 3";
            // 
            // labelMachine2
            // 
            this.labelMachine2.AutoSize = true;
            this.labelMachine2.Location = new System.Drawing.Point(36, 135);
            this.labelMachine2.Name = "labelMachine2";
            this.labelMachine2.Size = new System.Drawing.Size(192, 20);
            this.labelMachine2.TabIndex = 29;
            this.labelMachine2.Text = "Maszyna produkcyjna nr 2";
            // 
            // labelMachine1
            // 
            this.labelMachine1.AutoSize = true;
            this.labelMachine1.Location = new System.Drawing.Point(36, 50);
            this.labelMachine1.Name = "labelMachine1";
            this.labelMachine1.Size = new System.Drawing.Size(192, 20);
            this.labelMachine1.TabIndex = 28;
            this.labelMachine1.Text = "Maszyna produkcyjna nr 1";
            // 
            // LoadImageWarning
            // 
            this.LoadImageWarning.Image = global::Projekt3_symLiniiProdukcyjnej.Properties.Resources.problemYellow;
            this.LoadImageWarning.Location = new System.Drawing.Point(269, 479);
            this.LoadImageWarning.Name = "LoadImageWarning";
            this.LoadImageWarning.Size = new System.Drawing.Size(80, 73);
            this.LoadImageWarning.TabIndex = 13;
            this.LoadImageWarning.TabStop = false;
            this.LoadImageWarning.Visible = false;
            // 
            // LoadImageCritical
            // 
            this.LoadImageCritical.Image = global::Projekt3_symLiniiProdukcyjnej.Properties.Resources.problemRed;
            this.LoadImageCritical.Location = new System.Drawing.Point(269, 402);
            this.LoadImageCritical.Name = "LoadImageCritical";
            this.LoadImageCritical.Size = new System.Drawing.Size(80, 79);
            this.LoadImageCritical.TabIndex = 12;
            this.LoadImageCritical.TabStop = false;
            this.LoadImageCritical.Visible = false;
            // 
            // loadImage
            // 
            this.loadImage.Image = global::Projekt3_symLiniiProdukcyjnej.Properties.Resources.working;
            this.loadImage.Location = new System.Drawing.Point(129, 402);
            this.loadImage.Name = "loadImage";
            this.loadImage.Size = new System.Drawing.Size(161, 150);
            this.loadImage.TabIndex = 11;
            this.loadImage.TabStop = false;
            // 
            // progressBarLoad4
            // 
            this.progressBarLoad4.Location = new System.Drawing.Point(40, 328);
            this.progressBarLoad4.Name = "progressBarLoad4";
            this.progressBarLoad4.Size = new System.Drawing.Size(269, 24);
            this.progressBarLoad4.TabIndex = 8;
            // 
            // progressBarLoad3
            // 
            this.progressBarLoad3.Location = new System.Drawing.Point(40, 242);
            this.progressBarLoad3.Name = "progressBarLoad3";
            this.progressBarLoad3.Size = new System.Drawing.Size(269, 24);
            this.progressBarLoad3.TabIndex = 7;
            // 
            // progressBarLoad2
            // 
            this.progressBarLoad2.Location = new System.Drawing.Point(40, 158);
            this.progressBarLoad2.Name = "progressBarLoad2";
            this.progressBarLoad2.Size = new System.Drawing.Size(269, 24);
            this.progressBarLoad2.TabIndex = 6;
            // 
            // progressBarLoad1
            // 
            this.progressBarLoad1.Location = new System.Drawing.Point(40, 73);
            this.progressBarLoad1.Name = "progressBarLoad1";
            this.progressBarLoad1.Size = new System.Drawing.Size(269, 24);
            this.progressBarLoad1.TabIndex = 5;
            // 
            // labelLoad1
            // 
            this.labelLoad1.AutoSize = true;
            this.labelLoad1.Location = new System.Drawing.Point(315, 77);
            this.labelLoad1.Name = "labelLoad1";
            this.labelLoad1.Size = new System.Drawing.Size(54, 20);
            this.labelLoad1.TabIndex = 1;
            this.labelLoad1.Text = "Load1";
            // 
            // labelLoad3
            // 
            this.labelLoad3.AutoSize = true;
            this.labelLoad3.Location = new System.Drawing.Point(315, 246);
            this.labelLoad3.Name = "labelLoad3";
            this.labelLoad3.Size = new System.Drawing.Size(54, 20);
            this.labelLoad3.TabIndex = 3;
            this.labelLoad3.Text = "Load3";
            // 
            // labelLoad2
            // 
            this.labelLoad2.AutoSize = true;
            this.labelLoad2.Location = new System.Drawing.Point(315, 162);
            this.labelLoad2.Name = "labelLoad2";
            this.labelLoad2.Size = new System.Drawing.Size(54, 20);
            this.labelLoad2.TabIndex = 2;
            this.labelLoad2.Text = "Load2";
            // 
            // labelLoad4
            // 
            this.labelLoad4.AutoSize = true;
            this.labelLoad4.Location = new System.Drawing.Point(315, 332);
            this.labelLoad4.Name = "labelLoad4";
            this.labelLoad4.Size = new System.Drawing.Size(54, 20);
            this.labelLoad4.TabIndex = 4;
            this.labelLoad4.Text = "Load4";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.errorImageFan4);
            this.groupBox2.Controls.Add(this.errorImageFan3);
            this.groupBox2.Controls.Add(this.errorImageFan2);
            this.groupBox2.Controls.Add(this.errorImageFan1);
            this.groupBox2.Controls.Add(this.buttonFan4OFF);
            this.groupBox2.Controls.Add(this.buttonFan4ON);
            this.groupBox2.Controls.Add(this.labelFan4);
            this.groupBox2.Controls.Add(this.buttonFan3OFF);
            this.groupBox2.Controls.Add(this.buttonFan3ON);
            this.groupBox2.Controls.Add(this.labelFan3);
            this.groupBox2.Controls.Add(this.buttonFan2OFF);
            this.groupBox2.Controls.Add(this.buttonFan2ON);
            this.groupBox2.Controls.Add(this.labelFan2);
            this.groupBox2.Controls.Add(this.buttonFan1OFF);
            this.groupBox2.Controls.Add(this.buttonFan1ON);
            this.groupBox2.Controls.Add(this.labelFan1);
            this.groupBox2.Location = new System.Drawing.Point(978, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(418, 266);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sterownia wentylatorów silnikowych";
            // 
            // errorImageFan4
            // 
            this.errorImageFan4.Image = global::Projekt3_symLiniiProdukcyjnej.Properties.Resources.problemRedSmall;
            this.errorImageFan4.Location = new System.Drawing.Point(364, 158);
            this.errorImageFan4.Name = "errorImageFan4";
            this.errorImageFan4.Size = new System.Drawing.Size(41, 56);
            this.errorImageFan4.TabIndex = 18;
            this.errorImageFan4.TabStop = false;
            this.errorImageFan4.Visible = false;
            // 
            // errorImageFan3
            // 
            this.errorImageFan3.Image = global::Projekt3_symLiniiProdukcyjnej.Properties.Resources.problemRedSmall;
            this.errorImageFan3.Location = new System.Drawing.Point(6, 158);
            this.errorImageFan3.Name = "errorImageFan3";
            this.errorImageFan3.Size = new System.Drawing.Size(41, 56);
            this.errorImageFan3.TabIndex = 17;
            this.errorImageFan3.TabStop = false;
            this.errorImageFan3.Visible = false;
            // 
            // errorImageFan2
            // 
            this.errorImageFan2.Image = global::Projekt3_symLiniiProdukcyjnej.Properties.Resources.problemRedSmall;
            this.errorImageFan2.Location = new System.Drawing.Point(364, 53);
            this.errorImageFan2.Name = "errorImageFan2";
            this.errorImageFan2.Size = new System.Drawing.Size(41, 56);
            this.errorImageFan2.TabIndex = 16;
            this.errorImageFan2.TabStop = false;
            this.errorImageFan2.Visible = false;
            // 
            // errorImageFan1
            // 
            this.errorImageFan1.Image = global::Projekt3_symLiniiProdukcyjnej.Properties.Resources.problemRedSmall;
            this.errorImageFan1.Location = new System.Drawing.Point(6, 53);
            this.errorImageFan1.Name = "errorImageFan1";
            this.errorImageFan1.Size = new System.Drawing.Size(41, 56);
            this.errorImageFan1.TabIndex = 14;
            this.errorImageFan1.TabStop = false;
            this.errorImageFan1.Visible = false;
            // 
            // buttonFan4OFF
            // 
            this.buttonFan4OFF.ForeColor = System.Drawing.Color.Red;
            this.buttonFan4OFF.Location = new System.Drawing.Point(305, 150);
            this.buttonFan4OFF.Name = "buttonFan4OFF";
            this.buttonFan4OFF.Size = new System.Drawing.Size(53, 45);
            this.buttonFan4OFF.TabIndex = 15;
            this.buttonFan4OFF.Text = "OFF";
            this.buttonFan4OFF.UseVisualStyleBackColor = true;
            this.buttonFan4OFF.Click += new System.EventHandler(this.buttonFan4OFF_Click);
            // 
            // buttonFan4ON
            // 
            this.buttonFan4ON.Location = new System.Drawing.Point(230, 150);
            this.buttonFan4ON.Name = "buttonFan4ON";
            this.buttonFan4ON.Size = new System.Drawing.Size(53, 45);
            this.buttonFan4ON.TabIndex = 14;
            this.buttonFan4ON.Text = "ON";
            this.buttonFan4ON.UseVisualStyleBackColor = true;
            this.buttonFan4ON.Click += new System.EventHandler(this.buttonFan4ON_Click);
            // 
            // labelFan4
            // 
            this.labelFan4.AutoSize = true;
            this.labelFan4.Location = new System.Drawing.Point(242, 198);
            this.labelFan4.Name = "labelFan4";
            this.labelFan4.Size = new System.Drawing.Size(116, 20);
            this.labelFan4.TabIndex = 13;
            this.labelFan4.Text = "Wentylator nr 4";
            // 
            // buttonFan3OFF
            // 
            this.buttonFan3OFF.ForeColor = System.Drawing.Color.Red;
            this.buttonFan3OFF.Location = new System.Drawing.Point(122, 150);
            this.buttonFan3OFF.Name = "buttonFan3OFF";
            this.buttonFan3OFF.Size = new System.Drawing.Size(53, 45);
            this.buttonFan3OFF.TabIndex = 12;
            this.buttonFan3OFF.Text = "OFF";
            this.buttonFan3OFF.UseVisualStyleBackColor = true;
            this.buttonFan3OFF.Click += new System.EventHandler(this.buttonFan3OFF_Click);
            // 
            // buttonFan3ON
            // 
            this.buttonFan3ON.Location = new System.Drawing.Point(47, 150);
            this.buttonFan3ON.Name = "buttonFan3ON";
            this.buttonFan3ON.Size = new System.Drawing.Size(53, 45);
            this.buttonFan3ON.TabIndex = 11;
            this.buttonFan3ON.Text = "ON";
            this.buttonFan3ON.UseVisualStyleBackColor = true;
            this.buttonFan3ON.Click += new System.EventHandler(this.buttonFan3ON_Click);
            // 
            // labelFan3
            // 
            this.labelFan3.AutoSize = true;
            this.labelFan3.Location = new System.Drawing.Point(59, 198);
            this.labelFan3.Name = "labelFan3";
            this.labelFan3.Size = new System.Drawing.Size(116, 20);
            this.labelFan3.TabIndex = 10;
            this.labelFan3.Text = "Wentylator nr 3";
            // 
            // buttonFan2OFF
            // 
            this.buttonFan2OFF.ForeColor = System.Drawing.Color.Red;
            this.buttonFan2OFF.Location = new System.Drawing.Point(305, 41);
            this.buttonFan2OFF.Name = "buttonFan2OFF";
            this.buttonFan2OFF.Size = new System.Drawing.Size(53, 45);
            this.buttonFan2OFF.TabIndex = 9;
            this.buttonFan2OFF.Text = "OFF";
            this.buttonFan2OFF.UseVisualStyleBackColor = true;
            this.buttonFan2OFF.Click += new System.EventHandler(this.buttonFan2OFF_Click);
            // 
            // buttonFan2ON
            // 
            this.buttonFan2ON.Location = new System.Drawing.Point(230, 41);
            this.buttonFan2ON.Name = "buttonFan2ON";
            this.buttonFan2ON.Size = new System.Drawing.Size(53, 45);
            this.buttonFan2ON.TabIndex = 8;
            this.buttonFan2ON.Text = "ON";
            this.buttonFan2ON.UseVisualStyleBackColor = true;
            this.buttonFan2ON.Click += new System.EventHandler(this.buttonFan2ON_Click);
            // 
            // labelFan2
            // 
            this.labelFan2.AutoSize = true;
            this.labelFan2.Location = new System.Drawing.Point(242, 89);
            this.labelFan2.Name = "labelFan2";
            this.labelFan2.Size = new System.Drawing.Size(116, 20);
            this.labelFan2.TabIndex = 7;
            this.labelFan2.Text = "Wentylator nr 2";
            // 
            // buttonFan1OFF
            // 
            this.buttonFan1OFF.ForeColor = System.Drawing.Color.Red;
            this.buttonFan1OFF.Location = new System.Drawing.Point(122, 41);
            this.buttonFan1OFF.Name = "buttonFan1OFF";
            this.buttonFan1OFF.Size = new System.Drawing.Size(53, 45);
            this.buttonFan1OFF.TabIndex = 6;
            this.buttonFan1OFF.Text = "OFF";
            this.buttonFan1OFF.UseVisualStyleBackColor = true;
            this.buttonFan1OFF.Click += new System.EventHandler(this.buttonFan1OFF_Click);
            // 
            // buttonFan1ON
            // 
            this.buttonFan1ON.Location = new System.Drawing.Point(47, 41);
            this.buttonFan1ON.Name = "buttonFan1ON";
            this.buttonFan1ON.Size = new System.Drawing.Size(53, 45);
            this.buttonFan1ON.TabIndex = 5;
            this.buttonFan1ON.Text = "ON";
            this.buttonFan1ON.UseVisualStyleBackColor = true;
            this.buttonFan1ON.Click += new System.EventHandler(this.buttonFan1ON_Click);
            // 
            // labelFan1
            // 
            this.labelFan1.AutoSize = true;
            this.labelFan1.Location = new System.Drawing.Point(59, 89);
            this.labelFan1.Name = "labelFan1";
            this.labelFan1.Size = new System.Drawing.Size(116, 20);
            this.labelFan1.TabIndex = 1;
            this.labelFan1.Text = "Wentylator nr 1";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.errorImageOverload);
            this.groupBox.Controls.Add(this.labelOverload);
            this.groupBox.Controls.Add(this.overloadBar1);
            this.groupBox.Controls.Add(this.labelStrainerON4);
            this.groupBox.Controls.Add(this.labelStrainerOFF4);
            this.groupBox.Controls.Add(this.labelStrainerOFF3);
            this.groupBox.Controls.Add(this.labelStrainerON3);
            this.groupBox.Controls.Add(this.labelStrainerOFF2);
            this.groupBox.Controls.Add(this.labelStrainerON2);
            this.groupBox.Controls.Add(this.labelStrainerOFF1);
            this.groupBox.Controls.Add(this.labelStrainerON1);
            this.groupBox.Controls.Add(this.trackBarStrainer4);
            this.groupBox.Controls.Add(this.trackBarStrainer3);
            this.groupBox.Controls.Add(this.trackBarStrainer2);
            this.groupBox.Controls.Add(this.trackBarStrainer1);
            this.groupBox.Controls.Add(this.labelStrainer1);
            this.groupBox.Controls.Add(this.labelStrainer3);
            this.groupBox.Controls.Add(this.labelStrainer2);
            this.groupBox.Controls.Add(this.labelStrainer4);
            this.groupBox.Controls.Add(this.overloadBar2);
            this.groupBox.Location = new System.Drawing.Point(978, 362);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(418, 347);
            this.groupBox.TabIndex = 9;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Sterownia obciążeniem maszyn";
            // 
            // errorImageOverload
            // 
            this.errorImageOverload.Image = global::Projekt3_symLiniiProdukcyjnej.Properties.Resources.problemRedSmall;
            this.errorImageOverload.Location = new System.Drawing.Point(364, 266);
            this.errorImageOverload.Name = "errorImageOverload";
            this.errorImageOverload.Size = new System.Drawing.Size(41, 56);
            this.errorImageOverload.TabIndex = 19;
            this.errorImageOverload.TabStop = false;
            this.errorImageOverload.Visible = false;
            // 
            // labelOverload
            // 
            this.labelOverload.AutoSize = true;
            this.labelOverload.Location = new System.Drawing.Point(129, 300);
            this.labelOverload.Name = "labelOverload";
            this.labelOverload.Size = new System.Drawing.Size(154, 20);
            this.labelOverload.TabIndex = 44;
            this.labelOverload.Text = "Poziom przeciążenia";
            // 
            // overloadBar1
            // 
            this.overloadBar1.BackgroundImage = global::Projekt3_symLiniiProdukcyjnej.Properties.Resources.emptyBarH;
            this.overloadBar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.overloadBar1.Location = new System.Drawing.Point(58, 266);
            this.overloadBar1.Name = "overloadBar1";
            this.overloadBar1.Size = new System.Drawing.Size(300, 30);
            this.overloadBar1.TabIndex = 43;
            this.overloadBar1.TabStop = false;
            // 
            // labelStrainerON4
            // 
            this.labelStrainerON4.AutoSize = true;
            this.labelStrainerON4.ForeColor = System.Drawing.Color.Green;
            this.labelStrainerON4.Location = new System.Drawing.Point(301, 150);
            this.labelStrainerON4.Name = "labelStrainerON4";
            this.labelStrainerON4.Size = new System.Drawing.Size(32, 20);
            this.labelStrainerON4.TabIndex = 16;
            this.labelStrainerON4.Text = "ON";
            this.labelStrainerON4.Visible = false;
            // 
            // labelStrainerOFF4
            // 
            this.labelStrainerOFF4.AutoSize = true;
            this.labelStrainerOFF4.ForeColor = System.Drawing.Color.Red;
            this.labelStrainerOFF4.Location = new System.Drawing.Point(301, 187);
            this.labelStrainerOFF4.Name = "labelStrainerOFF4";
            this.labelStrainerOFF4.Size = new System.Drawing.Size(41, 20);
            this.labelStrainerOFF4.TabIndex = 15;
            this.labelStrainerOFF4.Text = "OFF";
            // 
            // labelStrainerOFF3
            // 
            this.labelStrainerOFF3.AutoSize = true;
            this.labelStrainerOFF3.ForeColor = System.Drawing.Color.Red;
            this.labelStrainerOFF3.Location = new System.Drawing.Point(97, 187);
            this.labelStrainerOFF3.Name = "labelStrainerOFF3";
            this.labelStrainerOFF3.Size = new System.Drawing.Size(41, 20);
            this.labelStrainerOFF3.TabIndex = 14;
            this.labelStrainerOFF3.Text = "OFF";
            // 
            // labelStrainerON3
            // 
            this.labelStrainerON3.AutoSize = true;
            this.labelStrainerON3.ForeColor = System.Drawing.Color.Green;
            this.labelStrainerON3.Location = new System.Drawing.Point(97, 150);
            this.labelStrainerON3.Name = "labelStrainerON3";
            this.labelStrainerON3.Size = new System.Drawing.Size(32, 20);
            this.labelStrainerON3.TabIndex = 13;
            this.labelStrainerON3.Text = "ON";
            this.labelStrainerON3.Visible = false;
            // 
            // labelStrainerOFF2
            // 
            this.labelStrainerOFF2.AutoSize = true;
            this.labelStrainerOFF2.ForeColor = System.Drawing.Color.Red;
            this.labelStrainerOFF2.Location = new System.Drawing.Point(301, 91);
            this.labelStrainerOFF2.Name = "labelStrainerOFF2";
            this.labelStrainerOFF2.Size = new System.Drawing.Size(41, 20);
            this.labelStrainerOFF2.TabIndex = 12;
            this.labelStrainerOFF2.Text = "OFF";
            // 
            // labelStrainerON2
            // 
            this.labelStrainerON2.AutoSize = true;
            this.labelStrainerON2.ForeColor = System.Drawing.Color.Green;
            this.labelStrainerON2.Location = new System.Drawing.Point(301, 54);
            this.labelStrainerON2.Name = "labelStrainerON2";
            this.labelStrainerON2.Size = new System.Drawing.Size(32, 20);
            this.labelStrainerON2.TabIndex = 11;
            this.labelStrainerON2.Text = "ON";
            this.labelStrainerON2.Visible = false;
            // 
            // labelStrainerOFF1
            // 
            this.labelStrainerOFF1.AutoSize = true;
            this.labelStrainerOFF1.ForeColor = System.Drawing.Color.Red;
            this.labelStrainerOFF1.Location = new System.Drawing.Point(97, 91);
            this.labelStrainerOFF1.Name = "labelStrainerOFF1";
            this.labelStrainerOFF1.Size = new System.Drawing.Size(41, 20);
            this.labelStrainerOFF1.TabIndex = 10;
            this.labelStrainerOFF1.Text = "OFF";
            // 
            // labelStrainerON1
            // 
            this.labelStrainerON1.AutoSize = true;
            this.labelStrainerON1.ForeColor = System.Drawing.Color.Green;
            this.labelStrainerON1.Location = new System.Drawing.Point(97, 54);
            this.labelStrainerON1.Name = "labelStrainerON1";
            this.labelStrainerON1.Size = new System.Drawing.Size(32, 20);
            this.labelStrainerON1.TabIndex = 9;
            this.labelStrainerON1.Text = "ON";
            this.labelStrainerON1.Visible = false;
            // 
            // trackBarStrainer4
            // 
            this.trackBarStrainer4.Location = new System.Drawing.Point(264, 143);
            this.trackBarStrainer4.Maximum = 1;
            this.trackBarStrainer4.Name = "trackBarStrainer4";
            this.trackBarStrainer4.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarStrainer4.Size = new System.Drawing.Size(69, 73);
            this.trackBarStrainer4.TabIndex = 8;
            this.trackBarStrainer4.Scroll += new System.EventHandler(this.trackBarStrainer4_Scroll);
            // 
            // trackBarStrainer3
            // 
            this.trackBarStrainer3.Location = new System.Drawing.Point(60, 143);
            this.trackBarStrainer3.Maximum = 1;
            this.trackBarStrainer3.Name = "trackBarStrainer3";
            this.trackBarStrainer3.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarStrainer3.Size = new System.Drawing.Size(69, 73);
            this.trackBarStrainer3.TabIndex = 7;
            this.trackBarStrainer3.Scroll += new System.EventHandler(this.trackBarStrainer3_Scroll);
            // 
            // trackBarStrainer2
            // 
            this.trackBarStrainer2.Location = new System.Drawing.Point(264, 44);
            this.trackBarStrainer2.Maximum = 1;
            this.trackBarStrainer2.Name = "trackBarStrainer2";
            this.trackBarStrainer2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarStrainer2.Size = new System.Drawing.Size(69, 73);
            this.trackBarStrainer2.TabIndex = 6;
            this.trackBarStrainer2.Scroll += new System.EventHandler(this.trackBarStrainer2_Scroll);
            // 
            // trackBarStrainer1
            // 
            this.trackBarStrainer1.Location = new System.Drawing.Point(60, 44);
            this.trackBarStrainer1.Maximum = 1;
            this.trackBarStrainer1.Name = "trackBarStrainer1";
            this.trackBarStrainer1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarStrainer1.Size = new System.Drawing.Size(69, 73);
            this.trackBarStrainer1.TabIndex = 5;
            this.trackBarStrainer1.Scroll += new System.EventHandler(this.trackBarStrainer1_Scroll);
            // 
            // labelStrainer1
            // 
            this.labelStrainer1.AutoSize = true;
            this.labelStrainer1.Location = new System.Drawing.Point(56, 120);
            this.labelStrainer1.Name = "labelStrainer1";
            this.labelStrainer1.Size = new System.Drawing.Size(119, 20);
            this.labelStrainer1.TabIndex = 1;
            this.labelStrainer1.Text = "Odciążenie nr 1";
            // 
            // labelStrainer3
            // 
            this.labelStrainer3.AutoSize = true;
            this.labelStrainer3.Location = new System.Drawing.Point(56, 219);
            this.labelStrainer3.Name = "labelStrainer3";
            this.labelStrainer3.Size = new System.Drawing.Size(119, 20);
            this.labelStrainer3.TabIndex = 3;
            this.labelStrainer3.Text = "Odciążenie nr 3";
            // 
            // labelStrainer2
            // 
            this.labelStrainer2.AutoSize = true;
            this.labelStrainer2.Location = new System.Drawing.Point(260, 120);
            this.labelStrainer2.Name = "labelStrainer2";
            this.labelStrainer2.Size = new System.Drawing.Size(119, 20);
            this.labelStrainer2.TabIndex = 2;
            this.labelStrainer2.Text = "Odciążenie nr 2";
            // 
            // labelStrainer4
            // 
            this.labelStrainer4.AutoSize = true;
            this.labelStrainer4.Location = new System.Drawing.Point(260, 219);
            this.labelStrainer4.Name = "labelStrainer4";
            this.labelStrainer4.Size = new System.Drawing.Size(119, 20);
            this.labelStrainer4.TabIndex = 4;
            this.labelStrainer4.Text = "Odciążenie nr 4";
            // 
            // overloadBar2
            // 
            this.overloadBar2.BackgroundImage = global::Projekt3_symLiniiProdukcyjnej.Properties.Resources.fullBarH;
            this.overloadBar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.overloadBar2.Location = new System.Drawing.Point(58, 266);
            this.overloadBar2.Name = "overloadBar2";
            this.overloadBar2.Size = new System.Drawing.Size(300, 30);
            this.overloadBar2.TabIndex = 45;
            this.overloadBar2.TabStop = false;
            // 
            // groupBoxWorkMode
            // 
            this.groupBoxWorkMode.Controls.Add(this.radioButtonModeManual);
            this.groupBoxWorkMode.Controls.Add(this.radioButtonModeAuto);
            this.groupBoxWorkMode.Location = new System.Drawing.Point(513, 647);
            this.groupBoxWorkMode.Name = "groupBoxWorkMode";
            this.groupBoxWorkMode.Size = new System.Drawing.Size(418, 62);
            this.groupBoxWorkMode.TabIndex = 10;
            this.groupBoxWorkMode.TabStop = false;
            this.groupBoxWorkMode.Text = "Tryb pracy linii produkcyjnej";
            // 
            // radioButtonModeManual
            // 
            this.radioButtonModeManual.AutoSize = true;
            this.radioButtonModeManual.Checked = true;
            this.radioButtonModeManual.Location = new System.Drawing.Point(247, 26);
            this.radioButtonModeManual.Name = "radioButtonModeManual";
            this.radioButtonModeManual.Size = new System.Drawing.Size(102, 24);
            this.radioButtonModeManual.TabIndex = 1;
            this.radioButtonModeManual.TabStop = true;
            this.radioButtonModeManual.Text = "Manualny";
            this.radioButtonModeManual.UseVisualStyleBackColor = true;
            // 
            // radioButtonModeAuto
            // 
            this.radioButtonModeAuto.AutoSize = true;
            this.radioButtonModeAuto.Location = new System.Drawing.Point(64, 26);
            this.radioButtonModeAuto.Name = "radioButtonModeAuto";
            this.radioButtonModeAuto.Size = new System.Drawing.Size(134, 24);
            this.radioButtonModeAuto.TabIndex = 0;
            this.radioButtonModeAuto.Text = "Automatyczny";
            this.radioButtonModeAuto.UseVisualStyleBackColor = true;
            // 
            // FormSimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1441, 744);
            this.Controls.Add(this.groupBoxWorkMode);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupTemperature);
            this.Controls.Add(this.buttonExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormSimulator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Linia Produkcyjna";
            this.Load += new System.EventHandler(this.FormSimulator_Load);
            this.groupTemperature.ResumeLayout(false);
            this.groupTemperature.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.engineImage4Critical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.engineImage3Critical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.engineImage2Critical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.engineImage1Critical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.engineImage4Warning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.engineImage3Warning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.engineImage2Warning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.engineImage1Warning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.engineImage4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.engineImage2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.engineImage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.engineImage3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TemperatureImageCritical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TemperatureImageWarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.engine2bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.engine4bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.engine3bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.engine2bar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.engine4bar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.engine3bar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.engine1bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.engine1bar2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoadImageWarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadImageCritical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadImage)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorImageFan4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorImageFan3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorImageFan2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorImageFan1)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorImageOverload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overloadBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarStrainer4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarStrainer3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarStrainer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarStrainer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overloadBar2)).EndInit();
            this.groupBoxWorkMode.ResumeLayout(false);
            this.groupBoxWorkMode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelTemp1;
        private System.Windows.Forms.Label labelTemp2;
        private System.Windows.Forms.Label labelTemp3;
        private System.Windows.Forms.Label labelTemp4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupTemperature;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar progressBarLoad4;
        private System.Windows.Forms.ProgressBar progressBarLoad3;
        private System.Windows.Forms.ProgressBar progressBarLoad2;
        private System.Windows.Forms.ProgressBar progressBarLoad1;
        private System.Windows.Forms.Label labelLoad1;
        private System.Windows.Forms.Label labelLoad3;
        private System.Windows.Forms.Label labelLoad2;
        private System.Windows.Forms.Label labelLoad4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelFan1;
        private PictureBox tempImage;
        private GroupBox groupBox;
        private Label labelStrainer1;
        private Label labelStrainer3;
        private Label labelStrainer2;
        private Label labelStrainer4;
        private PictureBox loadImage;
        private PictureBox TemperatureImageCritical;
        private PictureBox TemperatureImageWarning;
        private PictureBox LoadImageWarning;
        private PictureBox LoadImageCritical;
        private Button buttonFan4OFF;
        private Button buttonFan4ON;
        private Label labelFan4;
        private Button buttonFan3OFF;
        private Button buttonFan3ON;
        private Label labelFan3;
        private Button buttonFan2OFF;
        private Button buttonFan2ON;
        private Label labelFan2;
        private Button buttonFan1OFF;
        private Button buttonFan1ON;
        private PictureBox errorImageFan1;
        private PictureBox errorImageFan4;
        private PictureBox errorImageFan3;
        private PictureBox errorImageFan2;
        private Label labelEngine2;
        private Label labelEngine1;
        private Label labelEngine4;
        private Label labelEngine3;
        private Label labelMachineState4;
        private Label labelMachineState3;
        private Label labelMachineState2;
        private Label labelMachineState1;
        private Label labelMachine4;
        private Label labelMachine3;
        private Label labelMachine2;
        private Label labelMachine1;
        private PictureBox engineImage3;
        private PictureBox engineImage4;
        private PictureBox engineImage2;
        private PictureBox engineImage1;
        private PictureBox engine4bar1;
        private PictureBox engine2bar1;
        private PictureBox engine1bar1;
        private PictureBox engine3bar1;
        private PictureBox engine3bar2;
        private PictureBox engine4bar2;
        private PictureBox engine2bar2;
        private PictureBox engine1bar2;
        private PictureBox engineImage4Critical;
        private PictureBox engineImage3Critical;
        private PictureBox engineImage2Critical;
        private PictureBox engineImage1Critical;
        private PictureBox engineImage4Warning;
        private PictureBox engineImage3Warning;
        private PictureBox engineImage2Warning;
        private PictureBox engineImage1Warning;
        private TrackBar trackBarStrainer1;
        private Label labelStrainerOFF1;
        private Label labelStrainerON1;
        private TrackBar trackBarStrainer4;
        private TrackBar trackBarStrainer3;
        private TrackBar trackBarStrainer2;
        private Label labelStrainerON4;
        private Label labelStrainerOFF4;
        private Label labelStrainerOFF3;
        private Label labelStrainerON3;
        private Label labelStrainerOFF2;
        private Label labelStrainerON2;
        private Label labelOverload;
        private PictureBox overloadBar1;
        private GroupBox groupBoxWorkMode;
        private PictureBox overloadBar2;
        private PictureBox errorImageOverload;
        private RadioButton radioButtonModeManual;
        private RadioButton radioButtonModeAuto;
    }
}