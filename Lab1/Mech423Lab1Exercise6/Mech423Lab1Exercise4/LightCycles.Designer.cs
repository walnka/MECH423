
namespace Mech423Lab1Exercise4
{
    partial class LightCycles
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.background = new System.Windows.Forms.PictureBox();
            this.velocityTimer = new System.Windows.Forms.Timer(this.components);
            this.p1Serial = new System.IO.Ports.SerialPort(this.components);
            this.p2Serial = new System.IO.Ports.SerialPort(this.components);
            this.p1RefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.p2RefreshTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.background)).BeginInit();
            this.SuspendLayout();
            // 
            // background
            // 
            this.background.BackColor = System.Drawing.Color.Transparent;
            this.background.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.background.Location = new System.Drawing.Point(9, 9);
            this.background.Margin = new System.Windows.Forms.Padding(0);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(750, 750);
            this.background.TabIndex = 0;
            this.background.TabStop = false;
            // 
            // velocityTimer
            // 
            this.velocityTimer.Interval = 10;
            this.velocityTimer.Tick += new System.EventHandler(this.velocityTimer_Tick);
            // 
            // p1Serial
            // 
            this.p1Serial.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.p1Serial_DataReceived);
            // 
            // p2Serial
            // 
            this.p2Serial.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.p2Serial_DataReceived);
            // 
            // p1RefreshTimer
            // 
            this.p1RefreshTimer.Tick += new System.EventHandler(this.p1RefreshTimer_tick);
            // 
            // p2RefreshTimer
            // 
            this.p2RefreshTimer.Tick += new System.EventHandler(this.p2RefreshTimer_tick);
            // 
            // LightCycles
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(770, 762);
            this.Controls.Add(this.background);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LightCycles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LightCycles";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LightCycles_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.background)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox background;
        private System.Windows.Forms.Timer velocityTimer;
        public System.IO.Ports.SerialPort p1Serial;
        public System.IO.Ports.SerialPort p2Serial;
        public System.Windows.Forms.Timer p1RefreshTimer;
        public System.Windows.Forms.Timer p2RefreshTimer;
    }
}