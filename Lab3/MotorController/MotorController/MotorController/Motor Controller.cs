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
        const Byte dcStop = 0, dcCW = 1, dcCCW = 2, stepCW = 3, stepCCW = 4, stepContCW = 5, stepContCCW = 6, stepStop = 7;

        // For scaling DC and stepper motor trackbars
        const int dcTickMax = 65535;
        const int dcTick0 = 0;
        const int dcDeadzone = 500;
        const int stepTickMax = 65345;
        const int stepTick0 = 53760;
        const int stepDeadzone = 5;

        // Motor and gantry parameters
        int motorCPR = 48;
        double gearRatio = 20.4;
        double yAxisMaxLength = 123.2;
        int toothPitch = 2;
        int toothNumber = 20;
        int samplingPeriod = 100;
        int timeCount = 0;
        double lastCount = 0;

        // Flag for DC Motor and Stepper Motor Change
        bool motorSpeedChanged = false;

        Byte[] output = new byte[packetLength];
        ConcurrentQueue<Int32> dataQueue = new ConcurrentQueue<Int32>();
        int dcLSB, dcMSB, stepLSB, stepMSB;

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
                    timeCount++;
                    LSB = nextByte;
                    state = 4;
                }
                else if (state == 4)
                {
                    if (nextByte % 2 != 0) { LSB = 255; }
                    if (nextByte > 1) { MSB = 255; }

                    newCount = (4 * ((MSB << 8) | LSB));// - 0xA000;
                    position = (double)(newCount * toothPitch * toothNumber) / (double)(motorCPR * gearRatio);
                    speed = 1000 * 60 * (double)(newCount - lastCount) / (double)(samplingPeriod * motorCPR * gearRatio);

                    textBoxDCPosition.Text = position.ToString();
                    textBoxDCSpeed.Text = speed.ToString();

                    chartPosSpeed.Series["Position"].Points.AddXY(timeCount * samplingPeriod, position);
                    chartPosSpeed.Series["Speed"].Points.AddXY(timeCount * samplingPeriod, speed);

                    lastCount = newCount;
                    state = 0;
                }
            }
        }

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

        private void getOutputPacketArray()
        {
            
            output[startIndex] = Convert.ToByte(textBoxStart.Text);
            output[commandIndex] = Convert.ToByte(textBoxCommand.Text);
            output[MSBIndex] = Convert.ToByte(textBoxPWM1.Text);
            output[LSBIndex] = Convert.ToByte(textBoxPWM2.Text);
            output[escapeIndex] = Convert.ToByte(textBoxEscape.Text);
            //if (output[commandIndex] > 8)
            //{
            //    double newLength;
            //    newLength = (output[MSBIndex] << 8 | output[LSBIndex]) * 0xFFFF / yAxisMaxLength;
            //    output[MSBIndex] = (newLength) >> 8;
            //}
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
            if (dcLSB == 255) { output[escapeIndex] = 1; }
            if (dcMSB == 255) { output[escapeIndex] += 2; }

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
                stepLSB = (Math.Abs(trackBarStepperSpeed.Value) * (stepTickMax - stepTick0) / trackBarStepperSpeed.Maximum + stepTick0) & 0xFF;
                stepMSB = (Math.Abs(trackBarStepperSpeed.Value) * (stepTickMax - stepTick0) / trackBarStepperSpeed.Maximum + stepTick0) >> 8;
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
