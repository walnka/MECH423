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
        const Byte dcCW = 1, dcCCW = 2, stepCW = 5, stepCCW = 6;

        Byte[] output = new byte[packetLength];
        ConcurrentQueue<Int32> dataQueue = new ConcurrentQueue<Int32>();

        int dcLSB, dcMSB, stepLSB, stepMSB;
        public Form1()
        {
            InitializeComponent();
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

            if (Math.Abs(trackBarDCSpeed.Value) < 500)
            {
                dcLSB = 0;
                dcMSB = 0;
            }
            else
            {
                dcLSB = Math.Abs(trackBarDCSpeed.Value) & 0xFF;
                dcMSB = (Math.Abs(trackBarDCSpeed.Value) >> 8) & 0xFF;
            }

            output[escapeIndex] = 0;
            if (dcLSB == 255) { output[escapeIndex] = 1; }
            if (dcMSB == 255) { output[escapeIndex] += 2; }

            output[MSBIndex] = Convert.ToByte(dcMSB);
            output[LSBIndex] = Convert.ToByte(dcLSB);
            serialPort1.Write(output, startIndex, packetLength);
        }

        private void trackBarStepperSpeed_ValueChanged(object sender, EventArgs e)
        {
            // Check direction
            if (trackBarStepperSpeed.Value > 0) { output[commandIndex] = stepCW; }
            else { output[commandIndex] = stepCCW; }

            if (Math.Abs(trackBarStepperSpeed.Value) < 500)
            {
                stepLSB = 0;
                stepMSB = 0;
            }
            else
            {
                stepLSB = Math.Abs(trackBarStepperSpeed.Value) & 0xFF;
                stepMSB = (Math.Abs(trackBarStepperSpeed.Value) >> 8) & 0xFF;
            }

            output[escapeIndex] = 0;
            if (stepLSB == 255) { output[escapeIndex] = 1; }
            if (stepMSB == 255) { output[escapeIndex] += 2; }

            output[MSBIndex] = Convert.ToByte(stepMSB);
            output[LSBIndex] = Convert.ToByte(stepLSB);
            serialPort1.Write(output, startIndex, packetLength);
        }
    }
}
