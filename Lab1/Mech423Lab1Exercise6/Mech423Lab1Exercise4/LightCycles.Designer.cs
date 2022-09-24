
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
            this.player1 = new System.Windows.Forms.PictureBox();
            this.player2 = new System.Windows.Forms.PictureBox();
            this.velocityTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.background)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2)).BeginInit();
            this.SuspendLayout();
            // 
            // background
            // 
            this.background.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.background.BackColor = System.Drawing.Color.White;
            this.background.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.background.Location = new System.Drawing.Point(0, 0);
            this.background.Margin = new System.Windows.Forms.Padding(0);
            this.background.MaximumSize = new System.Drawing.Size(500, 500);
            this.background.MinimumSize = new System.Drawing.Size(500, 500);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(500, 500);
            this.background.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.background.TabIndex = 0;
            this.background.TabStop = false;
            // 
            // player1
            // 
            this.player1.BackColor = System.Drawing.Color.Yellow;
            this.player1.Location = new System.Drawing.Point(86, 290);
            this.player1.Margin = new System.Windows.Forms.Padding(0);
            this.player1.Name = "player1";
            this.player1.Size = new System.Drawing.Size(10, 10);
            this.player1.TabIndex = 1;
            this.player1.TabStop = false;
            // 
            // player2
            // 
            this.player2.BackColor = System.Drawing.Color.Blue;
            this.player2.Location = new System.Drawing.Point(393, 241);
            this.player2.Margin = new System.Windows.Forms.Padding(0);
            this.player2.Name = "player2";
            this.player2.Size = new System.Drawing.Size(10, 10);
            this.player2.TabIndex = 2;
            this.player2.TabStop = false;
            // 
            // velocityTimer
            // 
            this.velocityTimer.Interval = 10;
            this.velocityTimer.Tick += new System.EventHandler(this.velocityTimer_Tick);
            // 
            // LightCycles
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(532, 523);
            this.Controls.Add(this.player2);
            this.Controls.Add(this.player1);
            this.Controls.Add(this.background);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LightCycles";
            this.Text = "LightCycles";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LightCycles_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.background)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox background;
        private System.Windows.Forms.PictureBox player1;
        private System.Windows.Forms.PictureBox player2;
        private System.Windows.Forms.Timer velocityTimer;
    }
}