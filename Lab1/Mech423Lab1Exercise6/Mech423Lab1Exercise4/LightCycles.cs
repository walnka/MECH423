using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mech423Lab1Exercise4
{
    public partial class LightCycles : Form
    {
        int[] player1Direction = { 0, 1 }; // X Direction, Y Direcion
        int[] player2Direction = { 0, -1 }; //X Direction, Y Direction
        Bitmap field = new Bitmap(@"C:\Users\willk\Documents\MECHA4\MECH423\Lab1\Mech423Lab1Exercise6\Mech423Lab1Exercise4\field.bmp", true);
        Color p1Color = Color.Yellow;
        Color p2Color = Color.Blue;

        public LightCycles()
        {
            InitializeComponent();
            background.Width = 500;
            background.Height = 500;
            background.Image = field;
            player1.Left = 20;
            player1.Top = field.Height / 2;
            player2.Left = field.Width - 30;
            player2.Top = field.Height / 2 - 10;

            for (int i = 0; i < field.Width; i++)
            {
                for (int j = 0; j < field.Height; j++)
                {
                    if (i == 0 || i == field.Width - 1|| j == 0 || j == field.Height - 1)
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

        }

        private void velocityTimer_Tick(object sender, EventArgs e)
        {
            int loser = checkForCollision();

            //Draw Previous Player Spot
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    field.SetPixel(player1.Left + j, player1.Top + i, p1Color);
                    field.SetPixel(player2.Left + j, player2.Top + i, p2Color);
                }
            }
            background.Image = field;

            //Move Players
            player1.Top += player1Direction[1];
            player1.Left += player1Direction[0];
            player2.Top += player2Direction[1];
            player2.Left += player2Direction[0];

            if (loser != 0)
            {
                velocityTimer.Stop();
                MessageBox.Show("Player " + loser + " lost!");
            }
        }

        private int checkForCollision()
        {
            if ((player1Direction[0] == 1 && field.GetPixel(player1.Right + 1, player1.Top).ToArgb() != Color.Black.ToArgb()) || (player1Direction[0] == -1 && field.GetPixel(player1.Left - 1, player1.Top).ToArgb() != Color.Black.ToArgb()) || (player1Direction[1] == 1 && field.GetPixel(player1.Left, player1.Bottom + 1).ToArgb() != Color.Black.ToArgb()) || (player1Direction[1] == -1 && field.GetPixel(player1.Left, player1.Top - 1).ToArgb() != Color.Black.ToArgb()))
            {
                return 1;
            }
            else if ((player2Direction[0] == 1 && field.GetPixel(player2.Right + 1, player2.Top).ToArgb() != Color.Black.ToArgb()) || (player2Direction[0] == -1 && field.GetPixel(player2.Left - 1, player2.Top).ToArgb() != Color.Black.ToArgb()) || (player2Direction[1] == 1 && field.GetPixel(player2.Left, player2.Bottom + 1).ToArgb() != Color.Black.ToArgb()) || (player2Direction[1] == -1 && field.GetPixel(player2.Left, player2.Top - 1).ToArgb() != Color.Black.ToArgb()))
            {
                return 2;
            }
            return 0;
        }

        private void LightCycles_KeyDown(object sender, KeyEventArgs e)
        {
            //Player 1 Keyboard Response
            if (e.KeyCode == Keys.A && player1Direction[0] == 0)
            {
                player1Direction[0] = -1;
                player1Direction[1] = 0;
            }
            if (e.KeyCode == Keys.W && player1Direction[1] == 0)
            {
                player1Direction[0] = 0;
                player1Direction[1] = -1;
            }
            if (e.KeyCode == Keys.S && player1Direction[1] == 0)
            {
                player1Direction[0] = 0;
                player1Direction[1] = 1;
            }
            if (e.KeyCode == Keys.D && player1Direction[0] == 0)
            {
                player1Direction[0] = 1;
                player1Direction[1] = 0;
            }

            //Player 2 Keyboard Response
            if (e.KeyCode == Keys.J && player2Direction[0] == 0)
            {
                player2Direction[0] = -1;
                player2Direction[1] = 0;
            }
            if (e.KeyCode == Keys.I && player2Direction[1] == 0)
            {
                player2Direction[0] = 0;
                player2Direction[1] = -1;
            }
            if (e.KeyCode == Keys.K && player2Direction[1] == 0)
            {
                player2Direction[0] = 0;
                player2Direction[1] = 1;
            }
            if (e.KeyCode == Keys.L && player2Direction[0] == 0)
            {
                player2Direction[0] = 1;
                player2Direction[1] = 0;
            }
        }
    }
}
