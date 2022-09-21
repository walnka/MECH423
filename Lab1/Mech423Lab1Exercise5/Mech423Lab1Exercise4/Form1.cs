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
using System.IO;

namespace Mech423Lab1Exercise4
{
    public partial class SerialDemo : Form
    {
        ConcurrentQueue<Int32> dataQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> AXdataQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> AYdataQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> AZdataQueue = new ConcurrentQueue<Int32>();
        string nextState = "null";
        int orientationTolerance = 5;
        int posOrientation = 152;
        int negOrientation = 102;
        int zeroOrientation = 127;
        bool record = false;
        StreamWriter outputFile;

        //Gesture Variables
        int posMotionX = 210;
        int negMotionX = 70;
        int posMotionY = 170;
        int negMotionY = 50;
        int posMotionZ = 170;
        int negMotionZ = 60;
        string gestureState = "0";
        int gestureMotionCounter = 0;
        int gestureMotionCap = 5; //Caps the number of consecutives movements to 5
        string[] gestureHistory = new string[5];
        IDictionary<string[], string> gestureNames = new Dictionary<string[], string>();

        public SerialDemo()
        {
            InitializeComponent();
            orientationOutput.Text = "Unknown";
            axOutput.Text = "0";
            ayOutput.Text = "0";
            azOutput.Text = "0";
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
                    serialPort.Write("A");
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

        private bool checkInTolerance(int input, int target, int tolerance)
        {
            // Function that checks if the input is within target +- tolerance
            return (input >= target - tolerance) && (input <= target + tolerance);
        }

        private void refreshOutput(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
               bytesToReadOutput.Text = serialPort.BytesToRead.ToString();
            numQueueItems.Text = dataQueue.Count.ToString();

            // Check next byte axis
            int nextByte;
            while (dataQueue.TryDequeue(out nextByte))
            {
                serialStreamOutput.AppendText(nextByte.ToString() + ", ");
                if (nextByte == 255 && nextState == "null")
                {
                    nextState = "Ax";
                    if (saveToFileOption.Checked && !record)
                    {
                        record = true;
                        outputFile = new StreamWriter(filenameOutput.Text);
                    }
                    else if (!saveToFileOption.Checked && record)
                    {
                        record = false;
                        outputFile.Close();
                    }
                }
                else if (nextState == "Ax")
                {
                    nextState = "Ay";
                    AXdataQueue.Enqueue(nextByte);
                    axOutput.Text = nextByte.ToString();
                    if (record)
                    {
                        outputFile.Write(nextByte.ToString() + ",");
                    }
                    if (AXdataQueue.Count > 40)
                    {
                        AXdataQueue.TryDequeue(out int trash);
                    }
                    axQueueItemsOutput.Text = AXdataQueue.Count.ToString();
                }
                else if (nextState == "Ay")
                {
                    nextState = "Az";
                    AYdataQueue.Enqueue(nextByte);
                    ayOutput.Text = nextByte.ToString();
                    if (record)
                    {
                        outputFile.Write(nextByte.ToString() + ",");
                    }
                    if (AYdataQueue.Count > 40)
                    {
                        AYdataQueue.TryDequeue(out int trash);
                    }
                    ayQueueItemsOutput.Text = AYdataQueue.Count.ToString();
                }
                else if (nextState == "Az")
                {
                    nextState = "null";
                    AZdataQueue.Enqueue(nextByte);
                    azOutput.Text = nextByte.ToString();
                    if (record)
                    {
                        outputFile.Write(nextByte.ToString() + "," + (DateTimeOffset)DateTime.UtcNow + "\n");
                    }
                    if (AZdataQueue.Count > 40)
                    {
                        AZdataQueue.TryDequeue(out int trash);
                    }
                    azQueueItemsOutput.Text = AZdataQueue.Count.ToString();

                    // Checks most recent addition to queue for gestures
                    // Check for motions for gestures
                    bool motionRecorded = true;
                    if (Convert.ToInt32(axOutput.Text) >= posMotionX && gestureState != "+X" && gestureState != "-X")
                    {
                        gestureState = "+X";
                    }
                    else if (Convert.ToInt32(axOutput.Text) <= negMotionX && gestureState != "-X" && gestureState != "+X")
                    {
                        gestureState = "-X";
                    }
                    else if (Convert.ToInt32(ayOutput.Text) >= posMotionY && gestureState != "+Y" && gestureState != "-Y")
                    {
                        gestureState = "+Y";
                    }
                    else if (Convert.ToInt32(ayOutput.Text) <= negMotionY && gestureState != "-Y" && gestureState != "+Y")
                    {
                        gestureState = "-Y";
                    }
                    else if (Convert.ToInt32(azOutput.Text) >= posMotionZ && gestureState != "+Z" && gestureState != "-Z")
                    {
                        gestureState = "+Z";
                    }
                    else if (Convert.ToInt32(azOutput.Text) <= negMotionZ && gestureState != "-Z" && gestureState != "+Z")
                    {
                        gestureState = "-Z";
                    }
                    else
                    {
                        motionRecorded = false;
                    }

                    if (motionRecorded && gestureMotionCounter < gestureMotionCap)
                    {
                        gestureHistory[gestureMotionCounter] = gestureState;
                        gestureMotionCounter++;
                        stateTimer.Start();
                    }
                }
            }


            // Deduce Orientation from Acceleration
            int[] accelerationArray = { Convert.ToInt32(axOutput.Text), Convert.ToInt32(ayOutput.Text), Convert.ToInt32(azOutput.Text)};
            int?[] orientationArray = { null, null, null};

            for (int axis = 0; axis < 3; axis++)
            {
                if (checkInTolerance(accelerationArray[axis], posOrientation, orientationTolerance))
                {
                    orientationArray[axis] = 1;
                }
                else if (checkInTolerance(accelerationArray[axis], negOrientation, orientationTolerance))
                {
                    orientationArray[axis] = -1;
                }
                else if (checkInTolerance(accelerationArray[axis], zeroOrientation, orientationTolerance))
                {
                    orientationArray[axis] = 0;
                }
                else
                {
                    orientationArray[axis] = null;
                }
            }

            if (orientationArray[0] == 1 && orientationArray[1] == 0 && orientationArray[2] == 0)
            {
                orientationOutput.Text = "Positive X";
            }
            else if (orientationArray[0] == -1 && orientationArray[1] == 0 && orientationArray[2] == 0)
            {
                orientationOutput.Text = "Negative X";
            }
            else if (orientationArray[0] == 0 && orientationArray[1] == 1 && orientationArray[2] == 0)
            {
                orientationOutput.Text = "Positive Y";
            }
            else if (orientationArray[0] == 0 && orientationArray[1] == -1 && orientationArray[2] == 0)
            {
                orientationOutput.Text = "Negative Y";
            }
            else if (orientationArray[0] == 0 && orientationArray[1] == 0 && orientationArray[2] == 1)
            {
                orientationOutput.Text = "Positive Z";
            }
            else if (orientationArray[0] == 0 && orientationArray[1] == 0 && orientationArray[2] == -1)
            {
                orientationOutput.Text = "Negative Z";
            }
            else
            {
                orientationOutput.Text = "Unknown";
            }
        }

        private void selectFileButton_Click(object sender, EventArgs e)
        {
            saveFileDialog.Title = "Save csv Files";
            saveFileDialog.DefaultExt = "csv";
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 2;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filenameOutput.Text = saveFileDialog.FileName;
            }
        }

        private void saveToFileOption_CheckedChanged(object sender, EventArgs e)
        {
            if (saveToFileOption.Checked && !saveFileDialog.CheckFileExists && !serialPort.IsOpen)
            {
                MessageBox.Show("You need to choose a file to save to and be connected to a COM port to begin recording.", "No File Chosen or COM Port Disconnected");
                saveToFileOption.CheckState = CheckState.Unchecked;
            }
        }

        private void stateTimer_Tick(object sender, EventArgs e)
        {
            //Resets gestureState to 0 and clears currentGesture
            gestureState = "0";
            string currentGesture = "";

            for (int i = gestureMotionCounter; i < gestureMotionCap; i++)
            {
                gestureHistory[i] = "0";
            }

            //Prints gesture sequence in display Boxes
            motion1Output.Text = gestureHistory[0];
            motion2Output.Text = gestureHistory[1];
            motion3Output.Text = gestureHistory[2];
            motion4Output.Text = gestureHistory[3];
            motion5Output.Text = gestureHistory[4];

            //Checks gesture history and returns name of gesture
            foreach (KeyValuePair<string[], string> kvp in gestureNames)
            {
                //string[] dictKey = kvp.Key;
                if (gestureHistory[0] == kvp.Key[0] && gestureHistory[1] == kvp.Key[1] && gestureHistory[2] == kvp.Key[2] && gestureHistory[3] == kvp.Key[3] && gestureHistory[4] == kvp.Key[4])//gestureHistory.SequenceEqual(kvp.Key))
                {
                    currentGesture = kvp.Value;
                    // gestureNameOutput.Text = currentGesture;
                    serialStreamOutput.AppendText("same old");
                    break;
                }
            }
            if (currentGesture == "")
            {
                currentGesture = "Unknown: Try again or define a new gesture";
            }
            gestureNameOutput.Text = currentGesture;

            //Resets motion counter to read new gesture and stops timer
            gestureMotionCounter = 0;
            stateTimer.Stop();
        }

        private void defineGestureButton_Click(object sender, EventArgs e)
        {
            string[] local_gestureHistory = new string[5];
            gestureHistory.CopyTo(local_gestureHistory, 0);
            gestureNames.Add(local_gestureHistory, gestureNameOutput.Text);
        }
    }
}
