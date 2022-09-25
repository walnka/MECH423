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
    public partial class LightCycles : Form
    {
        static int playerSize = 5;
        int[] player1Direction = new int[2]; // X Direction, Y Direction
        int[] player2Direction = new int[2]; // X Direction, Y Direction
        Bitmap field = new Bitmap(@"C:\Users\willk\Documents\MECHA4\MECH423\Lab1\Mech423Lab1Exercise6\Mech423Lab1Exercise4\field.bmp", true);
        Color p1Color = Color.Yellow;
        Color p2Color = Color.Blue;
        int player1Left, player1Top, player2Left, player2Top;
        InputSelection inputSelection = new InputSelection();

        //Serial Interface
        public ConcurrentQueue<Int32> p1SerialQueue = new ConcurrentQueue<Int32>();
        public ConcurrentQueue<Int32> p2SerialQueue = new ConcurrentQueue<Int32>();
        public string p1State = "null";
        public string p2State = "null";
        public string p1AccelState = "0";
        public bool p1AccelStateChange = false;
        public string p2AccelState = "0";
        public bool p2AccelStateChange = false;
        public ConcurrentQueue<Int32> p1AxQueue = new ConcurrentQueue<Int32>();
        public ConcurrentQueue<Int32> p1AyQueue = new ConcurrentQueue<Int32>();
        public ConcurrentQueue<Int32> p1AzQueue = new ConcurrentQueue<Int32>();
        public ConcurrentQueue<Int32> p2AxQueue = new ConcurrentQueue<Int32>();
        public ConcurrentQueue<Int32> p2AyQueue = new ConcurrentQueue<Int32>();
        public ConcurrentQueue<Int32> p2AzQueue = new ConcurrentQueue<Int32>();
        string[] availableStatesP1 = new string[4];
        string[] availableStatesP2 = new string[4];


        //Accelerometer Values
        public int posMotionX = 190; //170
        public int negMotionX = 60; //60
        public int posMotionY = 190;
        public int negMotionY = 60;
        public int posMotionZ = 190;
        public int negMotionZ = 60;

        public LightCycles()
        {
            InitializeComponent();
            inputSelection.TheParent = this;
            inputSelection.ShowDialog();
            availableStatesP1[0] = inputSelection.p1UpADir; availableStatesP1[1] = inputSelection.p1DownADir; availableStatesP1[2] = inputSelection.p1LeftADir; availableStatesP1[3] = inputSelection.p1RightADir;
            availableStatesP2[0] = inputSelection.p2UpADir; availableStatesP2[1] = inputSelection.p2DownADir; availableStatesP2[2] = inputSelection.p2LeftADir; availableStatesP2[3] = inputSelection.p2RightADir;
            velocityTimer.Interval = 40;
            background.Left = 0;
            background.Top = 0;
            background.Margin = Padding.Empty;
            background.Image = field;
            startGame();
        }
        private void startGame()
        {
            player1Left = 20;
            player1Top = field.Height / 2;
            player2Left = field.Width - 20 - playerSize;
            player2Top = field.Height / 2 - playerSize;
            player1Direction[0] = 0;
            player1Direction[1] = playerSize;
            player2Direction[0] = 0;
            player2Direction[1] = -playerSize;

            for (int i = 0; i < field.Width; i++)
            {
                for (int j = 0; j < field.Height; j++)
                {
                    if (i <= playerSize || i >= field.Width - playerSize - 2 || j <= playerSize || j >= field.Height - playerSize - 2)
                    {
                        field.SetPixel(i, j, Color.White);
                    }
                    else
                    {
                        field.SetPixel(i, j, Color.Black);
                    }
                }
            }
            velocityTimer.Start();
            p1AccelState = inputSelection.p1DownADir;
            p2AccelState = inputSelection.p2UpADir;
        }

        private void velocityTimer_Tick(object sender, EventArgs e)
        {
            int loser = checkForCollision();

            //Draw Previous Player Spot
            for (int i = 0; i < playerSize; i++)
            {
                for (int j = 0; j < playerSize; j++)
                {
                    field.SetPixel(player1Left + j, player1Top + i, p1Color);
                    field.SetPixel(player2Left + j, player2Top + i, p2Color);
                }
            }
            background.Image = field;

            if (p1AccelStateChange)
            {
                p1AccelStateChange = false;
                if (inputSelection.p1UpADir == p1AccelState)
                {
                    player1Direction[0] = 0;
                    player1Direction[1] = -playerSize;
                }
                else if (inputSelection.p1DownADir == p1AccelState)
                {
                    player1Direction[0] = 0;
                    player1Direction[1] = playerSize;
                }
                else if (inputSelection.p1LeftADir == p1AccelState)
                {
                    player1Direction[0] = -playerSize;
                    player1Direction[1] = 0;
                }
                else if (inputSelection.p1RightADir == p1AccelState)
                {
                    player1Direction[0] = playerSize;
                    player1Direction[1] = 0;
                }
            }
            if (p2AccelStateChange)
            {
                p2AccelStateChange = false;
                if (inputSelection.p2UpADir == p2AccelState)
                {
                    player2Direction[0] = 0;
                    player2Direction[1] = -playerSize;
                }
                else if (inputSelection.p2DownADir == p2AccelState)
                {
                    player2Direction[0] = 0;
                    player2Direction[1] = playerSize;
                }
                else if (inputSelection.p2LeftADir == p2AccelState)
                {
                    player2Direction[0] = -playerSize;
                    player2Direction[1] = 0;
                }
                else if (inputSelection.p2RightADir == p2AccelState)
                {
                    player2Direction[0] = playerSize;
                    player2Direction[1] = 0;
                }
            }
            //Move Players
            player1Top += player1Direction[1];
            player1Left += player1Direction[0];
            player2Top += player2Direction[1];
            player2Left += player2Direction[0];

            if (loser != 0)
            {
                velocityTimer.Stop();
                if (loser == 3)
                {
                    MessageBox.Show("Your Art is Complete!");
                }
                else
                {
                    MessageBox.Show("Player " + loser + " lost!");
                }
                DialogResult result = MessageBox.Show("Retry or Cancel the game?", "Try Again?", MessageBoxButtons.RetryCancel);
                if (result == DialogResult.Retry)
                {
                    startGame();
                }
                else
                {
                    Close();
                }
            }
        }

        private int checkForCollision()
        {
            if (inputSelection.drawingModeCheck.Checked)
            {
                if ((player1Direction[0] == playerSize && field.GetPixel(player1Left + playerSize - 1 + player1Direction[0], player1Top).ToArgb() == Color.White.ToArgb()) || (player1Direction[0] == -playerSize && field.GetPixel(player1Left + player1Direction[0], player1Top).ToArgb() == Color.White.ToArgb()) || (player1Direction[1] == playerSize && field.GetPixel(player1Left, player1Top + playerSize - 1 + player1Direction[1]).ToArgb() == Color.White.ToArgb()) || (player1Direction[1] == -playerSize && field.GetPixel(player1Left, player1Top + player1Direction[1]).ToArgb() == Color.White.ToArgb()))
                {
                    return 3;
                }
                if ((player2Direction[0] == playerSize && field.GetPixel(player2Left + playerSize - 1 + player2Direction[0], player2Top).ToArgb() == Color.White.ToArgb()) || (player2Direction[0] == -playerSize && field.GetPixel(player2Left + player2Direction[0], player2Top).ToArgb() == Color.White.ToArgb()) || (player2Direction[1] == playerSize && field.GetPixel(player2Left, player2Top + playerSize - 1 + player2Direction[1]).ToArgb() == Color.White.ToArgb()) || (player2Direction[1] == -playerSize && field.GetPixel(player2Left, player2Top + player2Direction[1]).ToArgb() == Color.White.ToArgb()))
                {
                    return 3;
                }
            }
            else
            {
                if ((player1Direction[0] == playerSize && field.GetPixel(player1Left + playerSize - 1 + player1Direction[0], player1Top).ToArgb() != Color.Black.ToArgb()) || (player1Direction[0] == -playerSize && field.GetPixel(player1Left + player1Direction[0], player1Top).ToArgb() != Color.Black.ToArgb()) || (player1Direction[1] == playerSize && field.GetPixel(player1Left, player1Top + playerSize - 1 + player1Direction[1]).ToArgb() != Color.Black.ToArgb()) || (player1Direction[1] == -playerSize && field.GetPixel(player1Left, player1Top + player1Direction[1]).ToArgb() != Color.Black.ToArgb()))
                {
                    return 1;
                }
                else if ((player2Direction[0] == playerSize && field.GetPixel(player2Left + playerSize - 1 + player2Direction[0], player2Top).ToArgb() != Color.Black.ToArgb()) || (player2Direction[0] == -playerSize && field.GetPixel(player2Left + player2Direction[0], player2Top).ToArgb() != Color.Black.ToArgb()) || (player2Direction[1] == playerSize && field.GetPixel(player2Left, player2Top + playerSize - 1 + player2Direction[1]).ToArgb() != Color.Black.ToArgb()) || (player2Direction[1] == -playerSize && field.GetPixel(player2Left, player2Top + player2Direction[1]).ToArgb() != Color.Black.ToArgb()))
                {
                    return 2;
                }
            }
            return 0;
        }

        private void LightCycles_KeyDown(object sender, KeyEventArgs e)
        {
            if (inputSelection.player1InputKeyboard)
            {
                //Player 1 Keyboard Response
                if (e.KeyCode == inputSelection.p1LeftKey && player1Direction[0] == 0)
                {
                    player1Direction[0] = -playerSize;
                    player1Direction[1] = 0;
                }
                if (e.KeyCode == inputSelection.p1UpKey && player1Direction[1] == 0)
                {
                    player1Direction[0] = 0;
                    player1Direction[1] = -playerSize;
                }
                if (e.KeyCode == inputSelection.p1DownKey && player1Direction[1] == 0)
                {
                    player1Direction[0] = 0;
                    player1Direction[1] = playerSize;
                }
                if (e.KeyCode == inputSelection.p1RightKey && player1Direction[0] == 0)
                {
                    player1Direction[0] = playerSize;
                    player1Direction[1] = 0;
                }
            }
            //Player 2 Keyboard Response
            if (inputSelection.player2InputKeyboard)
            {
                if (e.KeyCode == inputSelection.p2LeftKey && player2Direction[0] == 0)
                {
                    player2Direction[0] = -playerSize;
                    player2Direction[1] = 0;
                }
                if (e.KeyCode == inputSelection.p2UpKey && player2Direction[1] == 0)
                {
                    player2Direction[0] = 0;
                    player2Direction[1] = -playerSize;
                }
                if (e.KeyCode == inputSelection.p2DownKey && player2Direction[1] == 0)
                {
                    player2Direction[0] = 0;
                    player2Direction[1] = playerSize;
                }
                if (e.KeyCode == inputSelection.p2RightKey && player2Direction[0] == 0)
                {
                    player2Direction[0] = playerSize;
                    player2Direction[1] = 0;
                }
            }
        }

        //Serial Port Stuff
        private void p1Serial_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int newByte = 0;
            int bytesToRead;

            bytesToRead = p1Serial.BytesToRead;
            while (bytesToRead != 0)
            {
                newByte = p1Serial.ReadByte();
                p1SerialQueue.Enqueue(newByte);
                bytesToRead = p1Serial.BytesToRead;
            }
        }

        private void p2Serial_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int newByte = 0;
            int bytesToRead;

            bytesToRead = p2Serial.BytesToRead;
            while (bytesToRead != 0)
            {
                newByte = p2Serial.ReadByte();
                p2SerialQueue.Enqueue(newByte);
                bytesToRead = p2Serial.BytesToRead;
            }
        }

        private void p1RefreshTimer_tick(object sender, EventArgs e)
        {
            // Check next byte axis
            int nextByte;
            while (p1SerialQueue.TryDequeue(out nextByte))
            {
                if (nextByte == 255 && p1State == "null")
                {
                    p1State = "Ax";
                }
                else if (p1State == "Ax")
                {
                    p1State = "Ay";
                    p1AxQueue.Enqueue(nextByte);
                    if (p1AxQueue.Count > 40)
                    {
                        p1AxQueue.TryDequeue(out int trash);
                    }
                    if (nextByte > posMotionX && p1AccelState != "+X" && p1AccelState != "-X" && !p1AccelStateChange)
                    {
                        string stateName = "+X";
                        if( !inputSelection.p1Ready.Checked || availableStatesP1[0] == stateName || availableStatesP1[1] == stateName || availableStatesP1[2] == stateName || availableStatesP1[3] == stateName)
                        {
                            p1AccelState = stateName;
                            p1AccelStateChange = true;
                        }
                    }
                    else if (nextByte < negMotionX && p1AccelState != "+X" && p1AccelState != "-X" && !p1AccelStateChange)
                    {
                        string stateName = "-X";
                        if (!inputSelection.p1Ready.Checked || availableStatesP1[0] == stateName || availableStatesP1[1] == stateName || availableStatesP1[2] == stateName || availableStatesP1[3] == stateName)
                        {
                            p1AccelState = stateName;
                            p1AccelStateChange = true;
                        }
                    }
                }
                else if (p1State == "Ay")
                {
                    p1State = "Az";
                    p1AyQueue.Enqueue(nextByte);
                    if (p1AyQueue.Count > 40)
                    {
                        p1AyQueue.TryDequeue(out int trash);
                    }
                    if (nextByte > posMotionY && p1AccelState != "+Y" && p1AccelState != "-Y" && !p1AccelStateChange)
                    {
                        string stateName = "+Y";
                        if (!inputSelection.p1Ready.Checked || availableStatesP1[0] == stateName || availableStatesP1[1] == stateName || availableStatesP1[2] == stateName || availableStatesP1[3] == stateName)
                        {
                            p1AccelState = stateName;
                            p1AccelStateChange = true;
                        }
                    }
                    else if (nextByte < negMotionY && p1AccelState != "+Y" && p1AccelState != "-Y" && !p1AccelStateChange)
                    {
                        string stateName = "-Y";
                        if (!inputSelection.p1Ready.Checked || availableStatesP1[0] == stateName || availableStatesP1[1] == stateName || availableStatesP1[2] == stateName || availableStatesP1[3] == stateName)
                        {
                            p1AccelState = stateName;
                            p1AccelStateChange = true;
                        }
                    }
                }
                else if (p1State == "Az")
                {
                    p1State = "null";
                    p1AzQueue.Enqueue(nextByte);
                    if (p1AzQueue.Count > 40)
                    {
                        p1AzQueue.TryDequeue(out int trash);
                    }
                    if (nextByte > posMotionZ && p1AccelState != "+Z" && p1AccelState != "-Z" && !p1AccelStateChange)
                    {
                        string stateName = "+Z";
                        if (!inputSelection.p1Ready.Checked || availableStatesP1[0] == stateName || availableStatesP1[1] == stateName || availableStatesP1[2] == stateName || availableStatesP1[3] == stateName)
                        {
                            p1AccelState = stateName;
                            p1AccelStateChange = true;
                        }
                    }
                    else if (nextByte < negMotionZ && p1AccelState != "+Z" && p1AccelState != "-Z" && !p1AccelStateChange)
                    {
                        string stateName = "-Z";
                        if (!inputSelection.p1Ready.Checked || availableStatesP1[0] == stateName || availableStatesP1[1] == stateName || availableStatesP1[2] == stateName || availableStatesP1[3] == stateName)
                        {
                            p1AccelState = stateName;
                            p1AccelStateChange = true;
                        }
                    }
                }
            }
        }

        private void p2RefreshTimer_tick(object sender, EventArgs e)
        {

            // Check next byte axis
            int nextByte;
            while (p2SerialQueue.TryDequeue(out nextByte))
            {
                if (nextByte == 255 && p2State == "null")
                {
                    p2State = "Ax";
                }
                else if (p2State == "Ax")
                {
                    p2State = "Ay";
                    p2AxQueue.Enqueue(nextByte);
                    if (p2AxQueue.Count > 40)
                    {
                        p2AxQueue.TryDequeue(out int trash);
                    }
                    if (nextByte > posMotionX && p2AccelState != "+X" && p2AccelState != "-X" && !p2AccelStateChange)
                    {
                        string stateName = "+X";
                        if (!inputSelection.p2Ready.Checked || availableStatesP2[0] == stateName || availableStatesP2[1] == stateName || availableStatesP2[2] == stateName || availableStatesP2[3] == stateName)
                        {
                            p2AccelState = stateName;
                            p2AccelStateChange = true;
                        }
                    }
                    else if (nextByte < negMotionX && p2AccelState != "+X" && p2AccelState != "-X" && !p2AccelStateChange)
                    {
                        string stateName = "-X";
                        if (!inputSelection.p2Ready.Checked || availableStatesP2[0] == stateName || availableStatesP2[1] == stateName || availableStatesP2[2] == stateName || availableStatesP2[3] == stateName)
                        {
                            p2AccelState = stateName;
                            p2AccelStateChange = true;
                        }
                    }
                }
                else if (p2State == "Ay")
                {
                    p2State = "Az";
                    p2AyQueue.Enqueue(nextByte);
                    if (p2AyQueue.Count > 40)
                    {
                        p2AyQueue.TryDequeue(out int trash);
                    }
                    if (nextByte > posMotionY && p2AccelState != "+Y" && p2AccelState != "-Y" && !p2AccelStateChange)
                    {
                        string stateName = "+Y";
                        if (!inputSelection.p2Ready.Checked || availableStatesP2[0] == stateName || availableStatesP2[1] == stateName || availableStatesP2[2] == stateName || availableStatesP2[3] == stateName)
                        {
                            p2AccelState = stateName;
                            p2AccelStateChange = true;
                        }
                    }
                    else if (nextByte < negMotionY && p2AccelState != "+Y" && p2AccelState != "-Y" && !p2AccelStateChange)
                    {
                        string stateName = "-Y";
                        if (!inputSelection.p2Ready.Checked || availableStatesP2[0] == stateName || availableStatesP2[1] == stateName || availableStatesP2[2] == stateName || availableStatesP2[3] == stateName)
                        {
                            p2AccelState = stateName;
                            p2AccelStateChange = true;
                        }
                    }
                }
                else if (p2State == "Az")
                {
                    p2State = "null";
                    p2AzQueue.Enqueue(nextByte);
                    if (p2AzQueue.Count > 40)
                    {
                        p2AzQueue.TryDequeue(out int trash);
                    }
                    if (nextByte > posMotionZ && p2AccelState != "+Z" && p2AccelState != "-Z" && !p2AccelStateChange)
                    {
                        string stateName = "+Z";
                        if (!inputSelection.p2Ready.Checked || availableStatesP2[0] == stateName || availableStatesP2[1] == stateName || availableStatesP2[2] == stateName || availableStatesP2[3] == stateName)
                        {
                            p2AccelState = stateName;
                            p2AccelStateChange = true;
                        }
                    }
                    else if (nextByte < negMotionZ && p2AccelState != "+Z" && p2AccelState != "-Z" && !p2AccelStateChange)
                    {
                        string stateName = "-Z";
                        if (!inputSelection.p2Ready.Checked || availableStatesP2[0] == stateName || availableStatesP2[1] == stateName || availableStatesP2[2] == stateName || availableStatesP2[3] == stateName)
                        {
                            p2AccelState = stateName;
                            p2AccelStateChange = true;
                        }
                    }
                }
            }
        }
    }
}
