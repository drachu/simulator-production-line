using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using OpenHardwareMonitor.Hardware;
using OpenHardwareMonitor;

namespace Projekt3_symLiniiProdukcyjnej
{
    public partial class FormSimulator : Form
    {

        public FormSimulator()
        {
            InitializeComponent();
            this.CenterToScreen();
            timer1.Start();
            cCPU.Open();
            cFan.Open();

        }
        private void FormSimulator_Load(object sender, EventArgs e)
        {


        }
        private void CheckFan(ref bool fan, ref int fancount, ref PictureBox fanImage)
        {
            if (fan == true && fancount < fanLimit / 2)
            {
                fancount++;
            }
            else if (fan && fancount >= fanLimit / 2 && fancount <= fanLimit)
            {
                fanImage.Visible = true;
                fancount++;
            }
            else if (fan && fancount > fanLimit)
            {
                timer1.Stop();
                MessageBox.Show("Nastąpiło przegrzanie wentylatorów. Nastąpi teraz wylogowanie ze względów bezpieczeństwa!");
                System.Windows.Forms.Application.Exit();
            }
            else if (!fan)
            {
                fancount = 0;
                fanImage.Visible = false;
            }
        }
        private void CheckStrainer(ref bool strainer, ref float LoadValue, ref float AccidentLoadValue, ref float strainerAdd)
        {
            if (strainer)
            {
                overloadBar1.Width -= 5;
                overloadBar1.Location = new Point(overloadBar1.Location.X + 5, overloadBar1.Location.Y);
            }
            if (!strainer1 && !strainer2 && !strainer3 && !strainer4 && overloadBar1.Width < 200)
            {
                overloadBar1.Width += 5;
                overloadBar1.Location = new Point(overloadBar1.Location.X - 5, overloadBar1.Location.Y);
            }
            if (overloadBar1.Width < 50)
            {
                errorImageOverload.Visible = true;
            }
            else
            {
                errorImageOverload.Visible = false;
            }
            if (overloadBar1.Width <= 0)
            {
                timer1.Stop();
                MessageBox.Show("System odciążania maszyn produkcyjnych uległ przeciążeniu. Nastąpi teraz wylogowanie ze względów bezpieczeństwa!");
                System.Windows.Forms.Application.Exit();
            }
        }
        private void CheckEngine(ref float TempValue, ref float AccidentTempValue, ref int AccidentTempCount)
        {
            if (TempValue + AccidentTempValue >= 80 && AccidentTempCount <= tempLimit)
            {
                AccidentTempCount++;
            }
            else if (AccidentTempCount > tempLimit)
            {
                timer1.Stop();
                MessageBox.Show("Nastąpiło przegrzanie silników. Nastąpi teraz wylogowanie ze względów bezpieczeństwa!");
                System.Windows.Forms.Application.Exit();
            }
            else if (TempValue + AccidentTempValue < 80)
            {
                AccidentTempCount = 0;
            }
        }
        private void CheckMachine(ref float LoadValue, ref float AccidentLoadValue, ref int AccidentLoadCound)
        {
            if (LoadValue + AccidentLoadValue >= 80 && AccidentLoadCound <= loadLimit)
            {
                AccidentLoadCound++;
            }
            else if (AccidentLoadCound > loadLimit)
            {
                timer1.Stop();
                MessageBox.Show("Maszyny uległy zniszczeniu, ze względu na zbyt długotrwałe wysokie obciążenie. Nastąpi teraz wylogowanie ze względów bezpieczeństwa!");
                System.Windows.Forms.Application.Exit();
            }
            else if (LoadValue + AccidentLoadValue < 80)
            {
                AccidentLoadCound = 0;
            }
        }
        private void CheckForAccident()
        {
            randomizedNumber = random.Next(0, 100);
            if (randomizedNumber < chanceForAccident)
            {
                randomizedNumber = random.Next(0, 8);
                if (randomizedNumber == 1) { tempCPU1Accident = true; }
                if (randomizedNumber == 2) { tempCPU2Accident = true; }
                if (randomizedNumber == 3) { tempCPU3Accident = true; }
                if (randomizedNumber == 4) { tempCPU4Accident = true; }
                if (randomizedNumber == 5) { loadCPU1Accident = true; }
                if (randomizedNumber == 6) { loadCPU2Accident = true; }
                if (randomizedNumber == 7) { loadCPU3Accident = true; }
                if (randomizedNumber == 8) { loadCPU4Accident = true; }
            }
        }
        private void AccidentProgress(ref bool accident, ref bool accidentHelper, ref float dataTempLoadValue, ref float dataTempLoadAccidentValue)
        {
            if (accident == true && accidentHelper == false)
            {
                if (dataTempLoadAccidentValue+dataTempLoadValue+10 <= 100)
                {
                    dataTempLoadAccidentValue += 10;
                }
                else
                {
                    dataTempLoadAccidentValue -= 10;
                }
            }
            if (accident == true && accidentHelper == true)
            {
                dataTempLoadAccidentValue -= 10;
            }
            if (dataTempLoadAccidentValue <= 0 && accidentHelper == true)
            {
                accident = false;
                dataTempLoadAccidentValue = 0;
            }
            while (dataTempLoadAccidentValue + dataTempLoadValue > 100)
            {
                dataTempLoadAccidentValue -= 5;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ReceiveHardwareData();

            CheckStrainer(ref strainer1, ref loadCPU1, ref loadCPU1AccidentValue, ref strainerCPU1Add);
            CheckStrainer(ref strainer2, ref loadCPU2, ref loadCPU2AccidentValue, ref strainerCPU2Add);
            CheckStrainer(ref strainer3, ref loadCPU3, ref loadCPU3AccidentValue, ref strainerCPU3Add);
            CheckStrainer(ref strainer4, ref loadCPU4, ref loadCPU4AccidentValue, ref strainerCPU4Add);

            CheckForAccident();

            AccidentProgress(ref tempCPU1Accident, ref fan1, ref tempCPU1, ref tempCPU1AccidentValue);
            AccidentProgress(ref tempCPU2Accident, ref fan2, ref tempCPU2, ref tempCPU2AccidentValue);
            AccidentProgress(ref tempCPU3Accident, ref fan3, ref tempCPU3, ref tempCPU3AccidentValue);
            AccidentProgress(ref tempCPU4Accident, ref fan4, ref tempCPU4, ref tempCPU4AccidentValue);

            AccidentProgress(ref loadCPU1Accident, ref strainer1, ref loadCPU1, ref loadCPU1AccidentValue);
            AccidentProgress(ref loadCPU2Accident, ref strainer2, ref loadCPU2, ref loadCPU2AccidentValue);
            AccidentProgress(ref loadCPU3Accident, ref strainer3, ref loadCPU3, ref loadCPU3AccidentValue);
            AccidentProgress(ref loadCPU4Accident, ref strainer4, ref loadCPU4, ref loadCPU4AccidentValue);

            CheckFan(ref fan1, ref fan1Count, ref errorImageFan1);
            CheckFan(ref fan2, ref fan2Count, ref errorImageFan2);
            CheckFan(ref fan3, ref fan3Count, ref errorImageFan3);
            CheckFan(ref fan4, ref fan4Count, ref errorImageFan4);

            CheckEngine(ref tempCPU1, ref tempCPU1AccidentValue, ref tempCPU1Count);
            CheckEngine(ref tempCPU2, ref tempCPU2AccidentValue, ref tempCPU2Count);
            CheckEngine(ref tempCPU3, ref tempCPU3AccidentValue, ref tempCPU3Count);
            CheckEngine(ref tempCPU4, ref tempCPU4AccidentValue, ref tempCPU4Count);

            CheckMachine(ref loadCPU1, ref loadCPU1AccidentValue, ref loadCPU1Count);
            CheckMachine(ref loadCPU2, ref loadCPU2AccidentValue, ref loadCPU2Count);
            CheckMachine(ref loadCPU3, ref loadCPU3AccidentValue, ref loadCPU3Count);
            CheckMachine(ref loadCPU4, ref loadCPU4AccidentValue, ref loadCPU4Count);

            labelTemp1.Text = (tempCPU1 + tempCPU1AccidentValue).ToString() + "°C";
            labelTemp2.Text = (tempCPU2 + tempCPU2AccidentValue).ToString() + "°C";
            labelTemp3.Text = (tempCPU3 + tempCPU3AccidentValue).ToString() + "°C";
            labelTemp4.Text = (tempCPU4 + tempCPU4AccidentValue).ToString() + "°C";

            engine1bar1.Height = 78 - Convert.ToInt32((tempCPU1 + tempCPU1AccidentValue) * 0.78);
            engine2bar1.Height = 78 - Convert.ToInt32((tempCPU2 + tempCPU2AccidentValue) * 0.78);
            engine3bar1.Height = 78 - Convert.ToInt32((tempCPU3 + tempCPU3AccidentValue) * 0.78);
            engine4bar1.Height = 78 - Convert.ToInt32((tempCPU4 + tempCPU4AccidentValue) * 0.78);

            labelLoad1.Text = Math.Round(loadCPU1 + loadCPU1AccidentValue, 2).ToString() + "%";
            labelLoad2.Text = Math.Round(loadCPU2 + loadCPU2AccidentValue, 2).ToString() + "%";
            labelLoad3.Text = Math.Round(loadCPU3 + loadCPU3AccidentValue, 2).ToString() + "%";
            labelLoad4.Text = Math.Round(loadCPU4 + loadCPU4AccidentValue, 2).ToString() + "%";

            progressBarLoad1.Value = Convert.ToInt32(Math.Round(loadCPU1 + loadCPU1AccidentValue));
            progressBarLoad2.Value = Convert.ToInt32(Math.Round(loadCPU2 + loadCPU2AccidentValue));
            progressBarLoad3.Value = Convert.ToInt32(Math.Round(loadCPU3 + loadCPU3AccidentValue));
            progressBarLoad4.Value = Convert.ToInt32(Math.Round(loadCPU4 + loadCPU4AccidentValue));

            TemperatureCheckImages();
            TemperatureCheckErrors();

            LoadCheckLabels();
            LoadCheckErrors();

            if (radioButtonModeAuto.Checked)
            {
                AutoRegulations();
                if (checkCounter == checkTime)
                {
                    FormSimulator.check = true;
                    Form3 checkBox = new Form3();
                    checkBox.Show();
                }
                if (FormSimulator.check == true)
                {
                    checkCounter = 0;
                }
                else if (!FormSimulator.check)
                {
                    checkCounter++;
                }
                
            }

        }
        private void AutoRegulations()
        {
            if (tempCPU1 + tempCPU1AccidentValue >= 80)
            {
                buttonFan1ON.PerformClick();
            }
            else if (tempCPU1AccidentValue <= 0)
            {
                buttonFan1OFF.PerformClick();
            }
            if (tempCPU2 + tempCPU2AccidentValue >= 80)
            {
                buttonFan2ON.PerformClick();
            }
            else if (tempCPU2AccidentValue <= 0)
            {
                buttonFan2OFF.PerformClick();
            }
            if (tempCPU3 + tempCPU3AccidentValue >= 80)
            {
                buttonFan3ON.PerformClick();
            }
            else if (tempCPU3AccidentValue <= 0)
            {
                buttonFan3OFF.PerformClick();
            }
            if (tempCPU4 + tempCPU4AccidentValue >= 80)
            {
                buttonFan4ON.PerformClick();
            }
            else if (tempCPU4AccidentValue <= 0)
            {
                buttonFan4OFF.PerformClick();
            }



            if (loadCPU1 + loadCPU1AccidentValue >= 80)
            {
                trackBarStrainer1.Value = 1;
                checkTrackBar1();
            }
            else if (loadCPU1AccidentValue <= 0)
            {
                trackBarStrainer1.Value = 0;
                checkTrackBar1();
            }
            if (loadCPU2 + loadCPU2AccidentValue >= 80)
            {
                trackBarStrainer2.Value = 1;
                checkTrackBar2();
            }
            else if (loadCPU2AccidentValue <= 0)
            {
                trackBarStrainer2.Value = 0;
                checkTrackBar2();
            }
            if (loadCPU3 + loadCPU3AccidentValue >= 80)
            {
                trackBarStrainer3.Value = 1;
                checkTrackBar3();
            }
            else if (loadCPU3AccidentValue <= 0)
            {
                trackBarStrainer3.Value = 0;
                checkTrackBar3();
            }
            if (loadCPU4 + loadCPU4AccidentValue >= 80)
            {
                trackBarStrainer4.Value = 1;
                checkTrackBar4();
            }
            else if (loadCPU4AccidentValue <= 0)
            {
                trackBarStrainer4.Value = 0;
                checkTrackBar4();
            }
        }
        private void ReceiveHardwareData()
        {
            byte countTemp = 0;
            byte countLoad = 0;

            foreach (var hardware in cCPU.Hardware)
            {
                if (hardware.HardwareType == HardwareType.CPU)
                {
                    hardware.Update();
                    foreach (IHardware subHardware in hardware.SubHardware)
                    {
                        subHardware.Update();
                    }
                    foreach (var sensor in hardware.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Temperature)
                        {
                            countTemp++;
                            switch (countTemp)
                            {
                                case 1:
                                    tempCPU1 = sensor.Value.Value;
                                    break;
                                case 2:
                                    tempCPU2 = sensor.Value.Value;
                                    break;
                                case 3:
                                    tempCPU3 = sensor.Value.Value;
                                    break;
                                case 4:
                                    tempCPU4 = sensor.Value.Value;
                                    break;
                            }
                        }
                        else if (sensor.SensorType == SensorType.Load)
                        {
                            countLoad++;
                            switch (countLoad)
                            {
                                case 1:
                                    loadCPU1 = sensor.Value.Value;
                                    break;
                                case 2:
                                    loadCPU2 = sensor.Value.Value;
                                    break;
                                case 3:
                                    loadCPU3 = sensor.Value.Value;
                                    break;
                                case 4:
                                    loadCPU4 = sensor.Value.Value;
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private void buttonFan1ON_Click(object sender, EventArgs e)
        {
            fan1 = true;
            buttonFan1ON.ForeColor = Color.Green;
            buttonFan1OFF.ForeColor = Color.Black;
        }

        private void buttonFan1OFF_Click(object sender, EventArgs e)
        {
            fan1 = false;
            buttonFan1ON.ForeColor = Color.Black;
            buttonFan1OFF.ForeColor = Color.Red;
        }

        private void buttonFan2ON_Click(object sender, EventArgs e)
        {
            fan2 = true;
            buttonFan2ON.ForeColor = Color.Green;
            buttonFan2OFF.ForeColor = Color.Black;
        }

        private void buttonFan2OFF_Click(object sender, EventArgs e)
        {
            fan2 = false;
            buttonFan2ON.ForeColor = Color.Black;
            buttonFan2OFF.ForeColor = Color.Red;
        }

        private void buttonFan3ON_Click(object sender, EventArgs e)
        {
            fan3 = true;
            buttonFan3ON.ForeColor = Color.Green;
            buttonFan3OFF.ForeColor = Color.Black;
        }

        private void buttonFan3OFF_Click(object sender, EventArgs e)
        {
            fan3 = false;
            buttonFan3ON.ForeColor = Color.Black;
            buttonFan3OFF.ForeColor = Color.Red;
        }

        private void buttonFan4ON_Click(object sender, EventArgs e)
        {
            fan4 = true;
            buttonFan4ON.ForeColor = Color.Green;
            buttonFan4OFF.ForeColor = Color.Black;
        }

        private void buttonFan4OFF_Click(object sender, EventArgs e)
        {
            fan4 = false;
            buttonFan4ON.ForeColor = Color.Black;
            buttonFan4OFF.ForeColor = Color.Red;
        }
        private void TemperatureCheckImages()
        {
            if (tempCPU1AccidentValue <= 0)
            {
                engineImage1Warning.Visible = false;
                engineImage1Critical.Visible = false;
            }
            else if (tempCPU1AccidentValue > 0 && tempCPU1 + tempCPU1AccidentValue < 80)
            {
                engineImage1Warning.Visible = true;
                engineImage1Critical.Visible = false;
            }
            else if (tempCPU1 + tempCPU1AccidentValue >= 80)
            {
                engineImage1Warning.Visible = false;
                engineImage1Critical.Visible = true;
            }
            if (tempCPU2AccidentValue <= 0)
            {
                engineImage2Warning.Visible = false;
                engineImage2Critical.Visible = false;
            }
            else if (tempCPU2AccidentValue > 0 && tempCPU2 + tempCPU2AccidentValue < 80)
            {
                engineImage2Warning.Visible = true;
                engineImage2Critical.Visible = false;
            }
            else if (tempCPU2 + tempCPU2AccidentValue >= 80)
            {
                engineImage2Warning.Visible = false;
                engineImage2Critical.Visible = true;
            }
            if (tempCPU3AccidentValue <= 0)
            {
                engineImage3Warning.Visible = false;
                engineImage3Critical.Visible = false;
            }
            else if (tempCPU3AccidentValue > 0 && tempCPU3 + tempCPU3AccidentValue < 80)
            {
                engineImage3Warning.Visible = true;
                engineImage3Critical.Visible = false;
            }
            else if (tempCPU3 + tempCPU3AccidentValue >= 80)
            {
                engineImage3Warning.Visible = false;
                engineImage3Critical.Visible = true;
            }
            if (tempCPU4AccidentValue <= 0)
            {
                engineImage4Warning.Visible = false;
                engineImage4Critical.Visible = false;
            }
            else if (tempCPU4AccidentValue > 0 && tempCPU4 + tempCPU4AccidentValue < 80)
            {
                engineImage4Warning.Visible = true;
                engineImage4Critical.Visible = false;
            }
            else if (tempCPU4 + tempCPU4AccidentValue >= 80)
            {
                engineImage4Warning.Visible = false;
                engineImage4Critical.Visible = true;
            }
        }
        private void LoadCheckLabels()
        {
            if (loadCPU1AccidentValue <= 0)
            {
                LabelEditNormal(labelMachineState1);
            }
            else if (loadCPU1AccidentValue > 0 && loadCPU1 + loadCPU1AccidentValue < 80)
            {
                LabelEditAboveTheNorm(labelMachineState1);
            }
            else if (loadCPU1 + loadCPU1AccidentValue >= 80)
            {
                LabelEditDanger(labelMachineState1);
            }
            if (loadCPU2AccidentValue <= 0)
            {
                LabelEditNormal(labelMachineState2);
            }
            else if (loadCPU2AccidentValue > 0 && loadCPU2 + loadCPU2AccidentValue < 80)
            {
                LabelEditAboveTheNorm(labelMachineState2);
            }
            else if (loadCPU2 + loadCPU2AccidentValue >= 80)
            {
                LabelEditDanger(labelMachineState2);
            }
            if (loadCPU3AccidentValue <= 0)
            {
                LabelEditNormal(labelMachineState3);
            }
            else if (loadCPU3AccidentValue > 0 && loadCPU3 + loadCPU3AccidentValue < 80)
            {
                LabelEditAboveTheNorm(labelMachineState3);
            }
            else if (loadCPU3 + loadCPU3AccidentValue >= 80)
            {
                LabelEditDanger(labelMachineState3);
            }
            if (loadCPU4AccidentValue <= 0)
            {
                LabelEditNormal(labelMachineState4);
            }
            else if (loadCPU4AccidentValue > 0 && loadCPU4 + loadCPU4AccidentValue < 80)
            {
                LabelEditAboveTheNorm(labelMachineState4);
            }
            else if (loadCPU4 + loadCPU4AccidentValue >= 80)
            {
                LabelEditDanger(labelMachineState4);
            }
        }
        private void LabelEditNormal(Label label)
        {
            label.Text = "W NORMIE";
            label.ForeColor = Color.Green;
        }
        private void LabelEditAboveTheNorm(Label label)
        {
            label.Text = "PONAD NORMĄ";
            label.ForeColor = Color.Orange;
        }
        private void LabelEditDanger(Label label)
        {
            label.Text = "NIEBEZPIECZEŃSTWO!";
            label.ForeColor = Color.Red;
        }
        private void checkTrackBar1()
        {
            if (trackBarStrainer1.Value == 1)
            {
                strainer1 = true;
                labelStrainerOFF1.Visible = false;
                labelStrainerON1.Visible = true;
            }
            else
            {
                strainer1 = false;
                labelStrainerOFF1.Visible = true;
                labelStrainerON1.Visible = false;
            }
        }
        private void checkTrackBar2()
        {
            if (trackBarStrainer2.Value == 1)
            {
                strainer2 = true;
                labelStrainerOFF2.Visible = false;
                labelStrainerON2.Visible = true;
            }
            else
            {
                strainer2 = false;
                labelStrainerOFF2.Visible = true;
                labelStrainerON2.Visible = false;
            }
        }
        private void checkTrackBar3()
        {
            if (trackBarStrainer3.Value == 1)
            {
                strainer3 = true;
                labelStrainerOFF3.Visible = false;
                labelStrainerON3.Visible = true;
            }
            else
            {
                strainer3 = false;
                labelStrainerOFF3.Visible = true;
                labelStrainerON3.Visible = false;
            }
        }
        private void checkTrackBar4()
        {
            if (trackBarStrainer4.Value == 1)
            {
                strainer4 = true;
                labelStrainerOFF4.Visible = false;
                labelStrainerON4.Visible = true;
            }
            else
            {
                strainer4 = false;
                labelStrainerOFF4.Visible = true;
                labelStrainerON4.Visible = false;
            }
        }
        private void TemperatureCheckErrors()
        {
            if (tempCPU1AccidentValue > 0 || tempCPU2AccidentValue > 0 || tempCPU3AccidentValue > 0 || tempCPU4AccidentValue > 0)
            {
                TemperatureImageWarning.Visible = true;
            }
            else
            {
                TemperatureImageWarning.Visible = false;
            }
            if (tempCPU1 + tempCPU1AccidentValue >= 80 || tempCPU2 + tempCPU2AccidentValue >= 80 || tempCPU3 + tempCPU3AccidentValue >= 80 || tempCPU4 + tempCPU4AccidentValue >= 80)
            {
                TemperatureImageCritical.Visible = true;
            }
            else
            {
                TemperatureImageCritical.Visible = false;
            }
        }
        private void LoadCheckErrors()
        {
            if (loadCPU1AccidentValue > 0 || loadCPU2AccidentValue > 0 || loadCPU3AccidentValue > 0 || loadCPU4AccidentValue > 0)
            {
                LoadImageWarning.Visible = true;
            }
            else
            {
                LoadImageWarning.Visible = false;
            }
            if (loadCPU1AccidentValue >= 80 || loadCPU2AccidentValue >= 80 || loadCPU3AccidentValue >= 80 || loadCPU4AccidentValue >= 80)
            {
                LoadImageCritical.Visible = true;
            }
            else
            {
                LoadImageCritical.Visible = false;
            }
        }

        private void trackBarStrainer1_Scroll(object sender, EventArgs e)
        {
            checkTrackBar1();
        }

        private void trackBarStrainer2_Scroll(object sender, EventArgs e)
        {
            checkTrackBar2();
        }

        private void trackBarStrainer3_Scroll(object sender, EventArgs e)
        {
            checkTrackBar3();
        }

        private void trackBarStrainer4_Scroll(object sender, EventArgs e)
        {
            checkTrackBar4();
        }
    }
}
