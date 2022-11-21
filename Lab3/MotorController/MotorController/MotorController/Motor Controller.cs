using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotorController
{
    public partial class Form1 : Form
    {
        const int packetLength = 5;
        // Packet indices
        const int startIndex = 0, commandIndex = 1, MSBIndex = 2, LSBIndex = 3, escapeIndex = 4;
        // Command Byte command values
        const byte dcStop = 0, dcCW = 1, dcCCW = 2, stepCW = 3, stepCCW = 4, stepContCW = 5, stepContCCW = 6, stepStop = 7,
            xZero = 8, xTransmit = 9, yZero = 10, yTransmit = 11, xyTransmitY = 12, xyTransmitX = 13, velocity = 14;

        // For scaling DC and stepper motor trackbars
        const int dcTickMax = 65535;
        const int dcTick0 = 0;
        const int dcDeadzone = 500;
        const int stepTickMax = 55705; //60585;
        const int stepTick0 = 0; //30000;
        const int stepDeadzone = 200;

        // Motor and gantry parameters
        const int motorCPR = 48;
        const double gearRatio = 20.4;
        const double yAxisMaxLength = 123.2;
        const int toothPitch = 2;
        const int toothNumber = 20;
        const double Kd = (double)0xFFFF / yAxisMaxLength;

        // Timing
        int samplingPeriod = 100;
        int timeCount = 0;
        int prevTimeCount = 0;
        double lastCount = 0;

        // Flag for DC Motor and Stepper Motor Change
        bool motorSpeedChanged = false;

        byte[] output = new byte[packetLength];
        ConcurrentQueue<Int32> dataQueue = new ConcurrentQueue<Int32>();
        int dcLSB, dcMSB, stepLSB, stepMSB;

        public Form1()
        {
            InitializeComponent();
            output[startIndex] = 255;
            comboBoxCOMPorts.Items.Clear();
            comboBoxCOMPorts.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            if (comboBoxCOMPorts.Items.Count == 0)
                comboBoxCOMPorts.Text = "No COM ports!";
            else
            {
                comboBoxCOMPorts.SelectedIndex = 0;
            }
        }

        private void buttonZeroStepper_Click(object sender, EventArgs e)
        {
            output[commandIndex] = 10;
            output[MSBIndex] = 0;
            output[LSBIndex] = 0;
            output[escapeIndex] = 0;
            serialPort1.Write(output, startIndex, packetLength);
        }

        private void buttonZeroDC_Click(object sender, EventArgs e)
        {
            output[commandIndex] = 8;
            output[MSBIndex] = 0;
            output[LSBIndex] = 0;
            output[escapeIndex] = 0;
            serialPort1.Write(output, startIndex, packetLength);
        }


        private void buttonTransmitXY_Click(object sender, EventArgs e)
        {
            double xLength = Kd * Convert.ToDouble(textBoxXPos.Text);
            double yLength = Kd * Convert.ToDouble(textBoxYPos.Text);

            dcMSB = (Int32)xLength >> 8;
            dcLSB = (Int32)xLength & 0xFF;
            stepMSB = (Int32)yLength >> 8;
            stepLSB = (Int32)yLength & 0xFF;

            // Assign x-y control y transmit in command byte
            output[commandIndex] = xyTransmitY;

            // Check if either byte is 255 and assign escape byte accordingly
            output[escapeIndex] = 0;
            if (stepLSB == 255) { output[escapeIndex] = 1; stepLSB = 0; }
            if (stepMSB == 255) { output[escapeIndex] += 2; stepMSB = 0; }

            // Assign PWM bytes in buffer
            output[MSBIndex] = (byte)stepMSB;
            output[LSBIndex] = (byte)stepLSB;

            // Write ytransmit packet to serial port
            serialPort1.Write(output, startIndex, packetLength);

            // Assign x-y transmit x transmit in command byte
            output[commandIndex] = xyTransmitX;

            // Check if either byte is 255 and assign escape byte accordingly
            output[escapeIndex] = 0;
            if (dcLSB == 255) { output[escapeIndex] = 1; dcLSB = 0; }
            if (dcMSB == 255) { output[escapeIndex] += 2; dcMSB = 0; }

            // Assign PWM bytes in buffer
            output[MSBIndex] = (byte)dcMSB;
            output[LSBIndex] = (byte)dcLSB;

            System.Threading.Thread.Sleep(100);

            // Write xtransmit packet to serial port
            serialPort1.Write(output, startIndex, packetLength);
        }

        private void buttonTransmitY_Click(object sender, EventArgs e)
        {
            double newLength = Kd * Convert.ToDouble(textBoxYPos.Text);
            stepMSB = (Int32)newLength >> 8;
            stepLSB = (Int32)newLength & 0xFF;

            output[commandIndex] = yTransmit;

            // Check if either byte is 255 and assign escape byte accordingly
            output[escapeIndex] = 0;
            if (stepLSB == 255) { output[escapeIndex] = 1; stepLSB = 0; }
            if (stepMSB == 255) { output[escapeIndex] += 2; stepMSB = 0; }

            // Assign PWM bytes in buffer
            output[MSBIndex] = (byte)stepMSB;
            output[LSBIndex] = (byte)stepLSB;

            serialPort1.Write(output, startIndex, packetLength);
        }

        private void buttonTransmitX_Click(object sender, EventArgs e)
        {
            double newLength = Kd * Convert.ToDouble(textBoxXPos.Text);
            dcMSB = (Int32)newLength >> 8;
            dcLSB = (Int32)newLength & 0xFF;

            output[commandIndex] = xTransmit;

            // Check if either byte is 255 and assign escape byte accordingly
            output[escapeIndex] = 0;
            if (dcLSB == 255) { output[escapeIndex] = 1; dcLSB = 0; }
            if (dcMSB == 255) { output[escapeIndex] += 2; dcMSB = 0; }

            // Assign PWM bytes in buffer
            output[MSBIndex] = (byte)dcMSB;
            output[LSBIndex] = (byte)dcLSB;

            serialPort1.Write(output, startIndex, packetLength);
        }

        private void buttonClearChart_Click(object sender, EventArgs e)
        {
            timeCount = 0;
            chartPosSpeed.Series["Position"].Points.Clear();
            chartPosSpeed.Series["Speed"].Points.Clear();
        }

        private void timerWrite_Tick(object sender, EventArgs e)
        {
            if (motorSpeedChanged)
            {
                serialPort1.Write(output, startIndex, packetLength);
                motorSpeedChanged = false;
            }
        }

        private void timerRead_Tick(object sender, EventArgs e)
        // On timer tick, dequeues dataQueue and sends dequeued bytes to the position and speed textboxes
        {
            int state = 0;
            int MSB = 0;
            int LSB = 0;
            int instByte;
            double newCount;
            double position;
            double speed;
            int nextByte;
            while (dataQueue.TryDequeue(out nextByte))
            {
                if (nextByte == 255)
                {
                    state = 1;
                }
                else if (state == 1)
                {
                    instByte = nextByte;
                    if (instByte == 0) { samplingPeriod = 100; }
                    else if (instByte == 1) { samplingPeriod = 5; }
                    state = 2;
                }
                else if (state == 2)
                {
                    MSB = nextByte;
                    state = 3;
                }
                else if (state == 3)
                {
                    LSB = nextByte;
                    state = 4;
                }
                else if (state == 4)
                {
                    if (nextByte % 2 != 0) { LSB = 255; }
                    if (nextByte > 1) { MSB = 255; }

                    newCount = (4 * ((MSB << 8) | LSB));// - 0xA000;
                    position = (double)(newCount * toothPitch * toothNumber) / (double)(motorCPR * gearRatio);
                    speed = 1000 * (double)(newCount - lastCount) / (double)(samplingPeriod * motorCPR * gearRatio); // [Hz]

                    textBoxDCPosition.Text = position.ToString();
                    textBoxDCSpeedHz.Text = speed.ToString();
                    textBoxDCSpeedRPM.Text = (60 * speed).ToString();

                    timeCount = prevTimeCount + samplingPeriod;

                    chartPosSpeed.Series["Position"].Points.AddXY(timeCount, position);
                    chartPosSpeed.Series["Speed"].Points.AddXY(timeCount, 60 * speed);

                    prevTimeCount = timeCount;

                    lastCount = newCount;
                    state = 0;
                }
            }
        }

        
        private void getOutputPacketArray()
        {
            
            output[startIndex] = Convert.ToByte(textBoxStart.Text);
            output[commandIndex] = Convert.ToByte(textBoxCommand.Text);
            output[MSBIndex] = Convert.ToByte(textBoxPWM1.Text);
            output[LSBIndex] = Convert.ToByte(textBoxPWM2.Text);
            output[escapeIndex] = Convert.ToByte(textBoxEscape.Text);
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                buttonConnect.Text = "Connect";
                serialPort1.Close();
            }
            else
            {
                serialPort1.PortName = comboBoxCOMPorts.Text;
                buttonConnect.Text = "Disconnect";
                serialPort1.BaudRate = Convert.ToInt16(textBoxBaud.Text);
                serialPort1.Open();
                timerRead.Enabled = true;
                timerWrite.Enabled = true;
            }
        }

        private void buttonStopDC_Click(object sender, EventArgs e)
        {
            output[commandIndex] = dcStop;
            serialPort1.Write(output, startIndex, packetLength);
            trackBarDCSpeed.Value = 0;
        }

        private void buttonStopStepper_Click(object sender, EventArgs e)
        {
            output[commandIndex] = stepStop;
            serialPort1.Write(output, startIndex, packetLength);
            trackBarStepperSpeed.Value = 0;
        }

        private void buttonStepCW_Click(object sender, EventArgs e)
        {
            output[commandIndex] = stepCW;
            serialPort1.Write(output, startIndex, packetLength);
        }
        private void buttonStepCCW_Click(object sender, EventArgs e)
        {
            output[commandIndex] = stepCCW;
            serialPort1.Write(output, startIndex, packetLength);
        }

        private void buttonTransmit_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                getOutputPacketArray();
                serialPort1.Write(output, startIndex, packetLength);
            }
            else
            {
                textBoxUserConsole.AppendText("Serial port is closed\r\n");
            }
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        // On data receive, gets new bytes from serial port and queues them in dataQueue
        {
            int newByte = 0;
            int bytesToRead;
            bytesToRead = serialPort1.BytesToRead;

            while (bytesToRead != 0)
            {
                newByte = serialPort1.ReadByte();           // Gets new byte from serial port
                dataQueue.Enqueue(newByte);                 // Queues it in dataQueue
                bytesToRead = serialPort1.BytesToRead;      // Checks for more bytes
            }
        }

        private void trackBarDCSpeed_ValueChanged(object sender, EventArgs e)
        {
            // Check direction
            if (trackBarDCSpeed.Value > 0) { output[commandIndex] = dcCW; }
            else { output[commandIndex] = dcCCW; }

            // Display speed
            DCSpeed.Text = (100 * (double)trackBarDCSpeed.Value / (double)trackBarDCSpeed.Maximum).ToString();

            // Deadzone
            if (Math.Abs(trackBarDCSpeed.Value) < dcDeadzone)
            {
                dcLSB = 0;
                dcMSB = 0;
            }
            else
            {
                // Take abs value and scale
                dcLSB = Math.Abs(trackBarDCSpeed.Value) & 0xFF;
                dcMSB = Math.Abs(trackBarDCSpeed.Value) >> 8;
            }

            // Check if either byte is 255 and assign escape byte accordingly
            output[escapeIndex] = 0;
            if (dcLSB == 255) { output[escapeIndex] = 1; dcLSB = 0; }
            if (dcMSB == 255) { output[escapeIndex] += 2; dcMSB = 0; }

            // Assign PWM bytes in buffer
            output[MSBIndex] = Convert.ToByte(dcMSB);
            output[LSBIndex] = Convert.ToByte(dcLSB);

            // Flag motor speed changed
            motorSpeedChanged = true;
        }

        private void trackBarStepperSpeed_ValueChanged(object sender, EventArgs e)
        {
            // Check direction
            if (trackBarStepperSpeed.Value > 0) { output[commandIndex] = stepContCW; }
            else { output[commandIndex] = stepContCCW; }

            // Display speed
            StepperSpeed.Text = (100 * (double)trackBarStepperSpeed.Value / (double)trackBarStepperSpeed.Maximum).ToString();

            // Deadzone
            if (Math.Abs(trackBarStepperSpeed.Value) < stepDeadzone)
            {
                stepLSB = 0;
                stepMSB = 0;
            }
            else
            {
                // Take abs value and scale
                stepLSB = Math.Abs(trackBarStepperSpeed.Value * (stepTickMax - stepTick0) / trackBarStepperSpeed.Maximum + stepTick0) & 0xFF;
                stepMSB = Math.Abs(trackBarStepperSpeed.Value * (stepTickMax - stepTick0) / trackBarStepperSpeed.Maximum + stepTick0) >> 8;
            }

            // Check if either byte is 255 and assign escape byte accordingly
            output[escapeIndex] = 0;
            if (stepLSB == 255) { output[escapeIndex] = 1; }
            if (stepMSB == 255) { output[escapeIndex] += 2; }

            // Assign PWM bytes in buffer
            output[MSBIndex] = Convert.ToByte(stepMSB);
            output[LSBIndex] = Convert.ToByte(stepLSB);

            // Flag motor speed changed
            motorSpeedChanged = true;
        }
    }
}
