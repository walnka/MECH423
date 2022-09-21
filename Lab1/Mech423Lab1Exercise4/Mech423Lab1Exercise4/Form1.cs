using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Concurrent;

namespace Mech423Lab1Exercise4
{
    public partial class SerialDemo : Form
    {
        ConcurrentQueue<Int32> dataQueue = new ConcurrentQueue<Int32>();

        public SerialDemo()
        {
            InitializeComponent();
            comboBoxCOMPorts.Items.Clear();
            comboBoxCOMPorts.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            if (comboBoxCOMPorts.Items.Count == 0)
                comboBoxCOMPorts.Text = "No COM ports!";
            else
                comboBoxCOMPorts.SelectedIndex = 0;
        }

        private void serialConnectButton_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
                serialConnectButton.Text = "Connect Serial";
            }
            else
            {
                serialPort.PortName = comboBoxCOMPorts.Text;
                try
                {
                    serialPort.Open();
                }
                catch (Exception connectError)
                {
                    MessageBox.Show("Serial Port Connection Failed.\r\nTry a different port\r\n", "Failed Connection To Serial Port");
                }
                if (serialPort.IsOpen)
                {
                    serialConnectButton.Text = "Disconnect Serial";
                }
            }
        }

        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int newByte = 0;
            int bytesToRead;

            bytesToRead = serialPort.BytesToRead;
            while (bytesToRead != 0)
            {
                newByte = serialPort.ReadByte();
                dataQueue.Enqueue(newByte);
                bytesToRead = serialPort.BytesToRead;
            }
        }

        private void refreshOutput(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
               bytesToReadOutput.Text = serialPort.BytesToRead.ToString();
            numQueueItems.Text = dataQueue.Count.ToString();
            int nextByte;
            while (dataQueue.TryDequeue(out nextByte))
            {
                serialStreamOutput.AppendText(nextByte.ToString() + ", ");
            }
        }
    }
}
