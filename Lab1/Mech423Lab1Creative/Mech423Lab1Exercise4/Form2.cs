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
    public partial class InputSelection : Form
    {
        public bool player1InputKeyboard, player2InputKeyboard = false; // true is Keyboard, false is Controller
        public Keys p1UpKey, p1DownKey, p1LeftKey, p1RightKey = Keys.None;
        public Keys p2UpKey, p2DownKey, p2LeftKey, p2RightKey = Keys.None;
        public string p1UpADir, p1DownADir, p1LeftADir, p1RightADir = "0";
        public string p2UpADir, p2DownADir, p2LeftADir, p2RightADir = "0";
        public string setState = "0";
        public LightCycles TheParent;
        public bool waitingForInput = false;

        public InputSelection()
        {
            this.Location = Screen.AllScreens[1].WorkingArea.Location;
            InitializeComponent();
        }

        private void User1InputChoice_TextChanged(object sender, EventArgs e)
        {
            if (User1InputChoice.Text == "Controller")
            {
                User1InputCOMPortChoice.Enabled = true;
                p1ConnectCheck.Enabled = true;
                User1InputCOMPortChoice.Items.Clear();
                User1InputCOMPortChoice.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
                if (User1InputCOMPortChoice.Items.Count == 0)
                {
                    User1InputCOMPortChoice.Text = "No COM ports!";
                }
                else
                    User1InputCOMPortChoice.SelectedIndex = 0;
                player1InputKeyboard = false;
            }
            else
            {
                User1InputCOMPortChoice.Enabled = false;
                p1ConnectCheck.Enabled = false;
                player1InputKeyboard = true;
            }
        }

        private void User2InputChoice_TextChanged(object sender, EventArgs e)
        {
            if (User2InputChoice.Text == "Controller")
            {
                User2InputCOMPortChoice.Enabled = true;
                p2ConnectCheck.Enabled = true;
                User2InputCOMPortChoice.Items.Clear();
                User2InputCOMPortChoice.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
                if (User2InputCOMPortChoice.Items.Count == 0)
                {
                    User2InputCOMPortChoice.Text = "No COM ports!";
                }
                else
                    User2InputCOMPortChoice.SelectedIndex = 0;
                player2InputKeyboard = false;

            }
            else
            {
                User2InputCOMPortChoice.Enabled = false;
                player2InputKeyboard = true;
                p2ConnectCheck.Enabled = false;
            }
        }

        private void User1UpButton_Click(object sender, EventArgs e)
        {
            setState = "1U";
            User1UpButton.Text = "";
            p1UpADir = "0";
            InputTimer.Stop();
            prepFirstSpike(1);
            InputTimer.Start();
            waitingForInput = true;
        }
        private void User1LeftButton_Click(object sender, EventArgs e)
        {
            setState = "1L";
            User1LeftButton.Text = "";
            p1LeftADir = "0";
            InputTimer.Stop();
            prepFirstSpike(1);
            InputTimer.Start();
            waitingForInput = true;
        }

        private void User1RightButton_Click(object sender, EventArgs e)
        {
            setState = "1R";
            User1RightButton.Text = "";
            p1RightADir = "0";
            InputTimer.Stop();
            prepFirstSpike(1);
            InputTimer.Start();
            waitingForInput = true;
        }
        private void User1DownButton_Click(object sender, EventArgs e)
        {
            setState = "1D";
            User1DownButton.Text = "";
            p1DownADir = "0";
            InputTimer.Stop();
            prepFirstSpike(1);
            InputTimer.Start();
            waitingForInput = true;
        }
        private void User1UpButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (player1InputKeyboard)
            {
                User1UpButton.Text = e.KeyCode.ToString();
                p1UpKey = e.KeyCode;
                InputTimer.Stop();
            }
        }
        private void User1LeftButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (player1InputKeyboard)
            {
                User1LeftButton.Text = e.KeyCode.ToString();
                p1LeftKey = e.KeyCode;
                InputTimer.Stop();
            }
        }
        private void User1RightButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (player1InputKeyboard)
            {
                User1RightButton.Text = e.KeyCode.ToString();
                p1RightKey = e.KeyCode;
                InputTimer.Stop();
            }
        }
        private void User1DownButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (player1InputKeyboard)
            {
                User1DownButton.Text = e.KeyCode.ToString();
                p1DownKey = e.KeyCode;
                InputTimer.Stop();
            }
        }

        private void p1ConnectCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (p1ConnectCheck.Checked)
            {
                TheParent.p1Serial.Close();
                TheParent.p1Serial.PortName = User1InputCOMPortChoice.Text;
                try
                {
                    TheParent.p1Serial.Open();
                }
                catch (Exception connectError)
                {
                    MessageBox.Show("Serial Port Connection Failed.\r\nTry a different port\r\n", "Failed Connection To Serial Port");
                    p1ConnectCheck.Checked = false;
                }
            }
            else
            {
                TheParent.p1Serial.Close();
                p1Ready.Checked = false;
            }
        }

        private void p2ConnectCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (p2ConnectCheck.Checked)
            {
                TheParent.p2Serial.Close();
                TheParent.p2Serial.PortName = User2InputCOMPortChoice.Text;
                try
                {
                    TheParent.p2Serial.Open();
                }
                catch (Exception connectError)
                {
                    MessageBox.Show("Serial Port Connection Failed.\r\nTry a different port\r\n", "Failed Connection To Serial Port");
                    p2ConnectCheck.Checked = false;
                }
            }
            else
            {
                TheParent.p2Serial.Close();
                p2Ready.Checked = false;
            }
        }

        private void User2UpButton_Click(object sender, EventArgs e)
        {
            setState = "2U";
            User2UpButton.Text = "";
            p2UpADir = "0";
            InputTimer.Stop();
            prepFirstSpike(2);
            InputTimer.Start();
            waitingForInput = true;
        }
        private void User2LeftButton_Click(object sender, EventArgs e)
        {
            setState = "2L";
            User2LeftButton.Text = "";
            p2LeftADir = "0";
            InputTimer.Stop();
            prepFirstSpike(2);
            InputTimer.Start();
            waitingForInput = true;
        }

        private void User2RightButton_Click(object sender, EventArgs e)
        {
            setState = "2R";
            User2RightButton.Text = "";
            p2RightADir = "0";
            InputTimer.Stop();
            prepFirstSpike(2);
            InputTimer.Start();
            waitingForInput = true;
        }
        private void User2DownButton_Click(object sender, EventArgs e)
        {
            setState = "2D";
            User2DownButton.Text = "";
            p2DownADir = "0";
            InputTimer.Stop();
            prepFirstSpike(2);
            InputTimer.Start();
            waitingForInput = true;
        }
        private void User2UpButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (player2InputKeyboard)
            {
                User2UpButton.Text = e.KeyCode.ToString();
                p2UpKey = e.KeyCode;
                InputTimer.Stop();
            }
        }
        private void User2LeftButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (player2InputKeyboard)
            {
                User2LeftButton.Text = e.KeyCode.ToString();
                p2LeftKey = e.KeyCode;
                InputTimer.Stop();
            }
        }
        private void User2RightButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (player2InputKeyboard)
            {
                User2RightButton.Text = e.KeyCode.ToString();
                p2RightKey = e.KeyCode;
                InputTimer.Stop();
            }
        }
        private void User2DownButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (player2InputKeyboard)
            {
                User2DownButton.Text = e.KeyCode.ToString();
                p2DownKey = e.KeyCode;
                InputTimer.Stop();
            }
        }
        private void p1Ready_CheckedChanged(object sender, EventArgs e)
        {
            if (p1Ready.Checked && ((player1InputKeyboard && (p1UpKey == Keys.None || p1DownKey == Keys.None || p1LeftKey == Keys.None || p1RightKey == Keys.None)) || (!player1InputKeyboard && (!p1ConnectCheck.Checked || p1UpADir == "0" || p1DownADir == "0" || p1LeftADir == "0" || p1RightADir == "0"))))
            {
                p1Ready.Checked = false;
            }
            if (p2Ready.Checked && p1Ready.Checked)
            {
                if (!player1InputKeyboard)
                {
                    TheParent.p1RefreshTimer.Start();
                }
                if (!player2InputKeyboard)
                {
                    TheParent.p2RefreshTimer.Start();
                }
                Hide();
            }
        }
        private void p2Ready_CheckedChanged(object sender, EventArgs e)
        {
            if (p2Ready.Checked && ((player2InputKeyboard && (p2UpKey == Keys.None || p2DownKey == Keys.None || p2LeftKey == Keys.None || p2RightKey == Keys.None)) || (!player2InputKeyboard && (!p2ConnectCheck.Checked || p2UpADir == "0" || p2DownADir == "0" || p2LeftADir == "0" || p2RightADir == "0"))))
            {
                p2Ready.Checked = false;
            }

            if (p2Ready.Checked && p1Ready.Checked)
            {
                if (!player1InputKeyboard)
                {
                    TheParent.p1RefreshTimer.Start();
                }
                if (!player2InputKeyboard)
                {
                    TheParent.p2RefreshTimer.Start();
                }
                Hide();
            }
        }
        private void InputTimer_Tick(object sender, EventArgs e)
        {
            waitingForInput = false;
            string motionState = "0";

            if (setState[0] == '1')
            {
                motionState = checkFirstSpike(TheParent.p1AxQueue, TheParent.p1AyQueue, TheParent.p1AzQueue);
            }
            else if (setState[0] == '2')
            {
                motionState = checkFirstSpike(TheParent.p2AxQueue, TheParent.p2AyQueue, TheParent.p2AzQueue);
            }

            if (motionState != "0")
            {
                if (setState == "1U")
                {
                    p1UpADir = motionState;
                    User1UpButton.Text = motionState;
                }
                else if (setState == "1D")
                {
                    p1DownADir = motionState;
                    User1DownButton.Text = motionState;

                }
                else if (setState == "1L")
                {
                    p1LeftADir = motionState;
                    User1LeftButton.Text = motionState;
                }
                else if (setState == "1R")
                {
                    p1RightADir = motionState;
                    User1RightButton.Text = motionState;
                }
                else if (setState == "2U")
                {
                    p2UpADir = motionState;
                    User2UpButton.Text = motionState;
                }
                else if (setState == "2D")
                {
                    p2DownADir = motionState;
                    User2DownButton.Text = motionState;

                }
                else if (setState == "2L")
                {
                    p2LeftADir = motionState;
                    User2LeftButton.Text = motionState;
                }
                else if (setState == "2R")
                {
                    p2RightADir = motionState;
                    User2RightButton.Text = motionState;
                }
                else
                {
                    MessageBox.Show("No Input Detected: Try Again", "No Input Detected");
                }
            }
            else
            {
                MessageBox.Show("No Input Detected: Try Again", "No Input Detected");
            }
            InputTimer.Stop();
        }

        public void prepFirstSpike(int player)
        {
            if (player == 1)
            {
                TheParent.p1RefreshTimer.Stop();
                TheParent.p1AccelState = "0";
                while (TheParent.p1AxQueue.TryDequeue(out int trash)) ;
                while (TheParent.p1AyQueue.TryDequeue(out int trash)) ;
                while (TheParent.p1AzQueue.TryDequeue(out int trash)) ;
                TheParent.p1RefreshTimer.Start();
            }
            else if (player == 2)
            {
                TheParent.p2RefreshTimer.Stop();
                TheParent.p2AccelState = "0";
                while (TheParent.p2AxQueue.TryDequeue(out int trash)) ;
                while (TheParent.p2AyQueue.TryDequeue(out int trash)) ;
                while (TheParent.p2AzQueue.TryDequeue(out int trash)) ;
                TheParent.p2RefreshTimer.Start();
            }
        }

        private string checkFirstSpike(ConcurrentQueue<Int32> axQ, ConcurrentQueue<Int32> ayQ, ConcurrentQueue<Int32> azQ)
        {
            int Ax, Ay, Az;
            while (axQ.TryDequeue(out Ax) && ayQ.TryDequeue(out Ay) && azQ.TryDequeue(out Az))
            {
                if (Ax > TheParent.posMotionX)
                {
                    return "+X";
                }
                else if (Ax < TheParent.negMotionX)
                {
                    return "-X";
                }
                else if (Ay > TheParent.posMotionY)
                {
                    return "+Y";
                }
                else if (Ay < TheParent.negMotionY)
                {
                    return "-Y";
                }
                else if (Az > TheParent.posMotionZ)
                {
                    return "+Z";
                }
                else if (Az < TheParent.negMotionZ)
                {
                    return "-Z";
                }
            }
            return "0";
        }
    }
}
