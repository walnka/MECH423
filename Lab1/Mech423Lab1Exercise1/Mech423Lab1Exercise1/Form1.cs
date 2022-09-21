using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mech423Lab1Exercise1
{
    public partial class MouseSensor : Form
    {
        public MouseSensor()
        {
            InitializeComponent();
        }

        private void MouseZone_MouseClick(object sender, MouseEventArgs e)
        {
            int ClickX = e.X;
            int ClickY = e.Y;
            string recordedClickStr = "(" + ClickX.ToString() + ", " + ClickY.ToString() + ")\r\n";
            ClickRecorder.AppendText(recordedClickStr);
        }

        private void MouseZone_MouseMove(object sender, MouseEventArgs e)
        {
            int MouseX = e.X;
            int MouseY = e.Y;
            XLoc.Text = MouseX.ToString();
            YLoc.Text = MouseY.ToString();
        }
    }
}
