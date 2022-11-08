using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotorController
{
    public partial class Form1 : Form
    {
        const int packetLength = 5;
        const int startIndex = 0, commandIndex = 1, MSBIndex = 2, LSBIndex = 3, escapeIndex = 4;
        const Byte dcStop = 0, dcCW = 1, dcCCW = 2, stepCW = 3, stepCCW = 4, stepContCW = 5, stepContCCW = 6, stepStop = 7;

        const int dcTickMax = 65535;
        const int stepTickMax = 65345;
        const int dcTick0 = 0;
        const int stepTick0 = 53760;
        const int dcDeadzone = 500;
        const int stepperDeadzone = 5;

        Byte[] output = new byte[packetLength];
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
                timer1.Enabled = true;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                output[commandIndex] = stepStop;
                serialPort1.Write(output, startIndex, packetLength);
                trackBarDCSpeed.Value = 0;
                output[commandIndex] = stepStop;
                serialPort1.Write(output, startIndex, packetLength);
                trackBarStepperSpeed.Value = 0;
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
                serialPort1.Write(output, startIndex, packetLength);
            }
        }

        private void textBoxStart_Leave(object sender, EventArgs e)
        {
            output[startIndex] = Convert.ToByte(textBoxStart.Text);
        }

        private void textBoxCommand_Leave(object sender, EventArgs e)
        {
            output[commandIndex] = Convert.ToByte(textBoxCommand.Text);
        }

        private void textBoxPWM1_Leave(object sender, EventArgs e)
        {
            output[MSBIndex] = Convert.ToByte(textBoxPWM1.Text);
        }

        private void textBoxPWM2_Leave(object sender, EventArgs e)
        {
            output[LSBIndex] = Convert.ToByte(textBoxPWM2.Text);
        }

        private void textBoxEscape_Leave(object sender, EventArgs e)
        {
            output[escapeIndex] = Convert.ToByte(textBoxEscape.Text);
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int newByte = 0;
            int bytesToRead;
            bytesToRead = serialPort1.BytesToRead;

            while (bytesToRead != 0)
            {
                newByte = serialPort1.ReadByte();
                dataQueue.Enqueue(newByte);
                bytesToRead = serialPort1.BytesToRead;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int nextByte;
            while (dataQueue.TryDequeue(out nextByte))
            {
                textBoxSerialDataStream.AppendText(nextByte.ToString());
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

            // Assign PWM bytes in buffer and transmit to serial port
            output[MSBIndex] = Convert.ToByte(dcMSB);
            output[LSBIndex] = Convert.ToByte(dcLSB);
            serialPort1.Write(output, startIndex, packetLength);
        }

        private void trackBarStepperSpeed_ValueChanged(object sender, EventArgs e)
        {
            // Check direction
            if (trackBarStepperSpeed.Value > 0) { output[commandIndex] = stepContCW; }
            else { output[commandIndex] = stepContCCW; }

            // Display speed
            StepperSpeed.Text = (100 * (double)trackBarStepperSpeed.Value / (double)trackBarStepperSpeed.Maximum).ToString();

            // Deadzone
            if (Math.Abs(trackBarStepperSpeed.Value) < stepperDeadzone)
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

            // Assign PWM bytes in buffer and transmit to serial port
            output[MSBIndex] = Convert.ToByte(stepMSB);
            output[LSBIndex] = Convert.ToByte(stepLSB);
            serialPort1.Write(output, startIndex, packetLength);
        }
    }
}
