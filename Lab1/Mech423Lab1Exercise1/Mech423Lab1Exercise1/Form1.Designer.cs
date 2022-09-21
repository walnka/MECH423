
namespace Mech423Lab1Exercise1
{
    partial class MouseSensor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.YLoc = new System.Windows.Forms.TextBox();
            this.ClickRecorder = new System.Windows.Forms.TextBox();
            this.XLoc = new System.Windows.Forms.TextBox();
            this.MouseZone = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.MouseZone)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Recorded Clicks";
            // 
            // YLoc
            // 
            this.YLoc.Location = new System.Drawing.Point(52, 24);
            this.YLoc.Name = "YLoc";
            this.YLoc.ReadOnly = true;
            this.YLoc.Size = new System.Drawing.Size(82, 27);
            this.YLoc.TabIndex = 3;
            // 
            // ClickRecorder
            // 
            this.ClickRecorder.Location = new System.Drawing.Point(9, 96);
            this.ClickRecorder.Multiline = true;
            this.ClickRecorder.Name = "ClickRecorder";
            this.ClickRecorder.ReadOnly = true;
            this.ClickRecorder.Size = new System.Drawing.Size(125, 350);
            this.ClickRecorder.TabIndex = 4;
            // 
            // XLoc
            // 
            this.XLoc.Location = new System.Drawing.Point(52, 0);
            this.XLoc.Name = "XLoc";
            this.XLoc.ReadOnly = true;
            this.XLoc.Size = new System.Drawing.Size(82, 27);
            this.XLoc.TabIndex = 5;
            // 
            // MouseZone
            // 
            this.MouseZone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MouseZone.Location = new System.Drawing.Point(133, 0);
            this.MouseZone.Name = "MouseZone";
            this.MouseZone.Size = new System.Drawing.Size(381, 446);
            this.MouseZone.TabIndex = 6;
            this.MouseZone.TabStop = false;
            this.MouseZone.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseZone_MouseClick);
            this.MouseZone.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseZone_MouseMove);
            // 
            // MouseSensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 450);
            this.Controls.Add(this.MouseZone);
            this.Controls.Add(this.XLoc);
            this.Controls.Add(this.ClickRecorder);
            this.Controls.Add(this.YLoc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MouseSensor";
            this.Text = "MouseSensor";
            ((System.ComponentModel.ISupportInitialize)(this.MouseZone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox YLoc;
        private System.Windows.Forms.TextBox ClickRecorder;
        private System.Windows.Forms.TextBox XLoc;
        private System.Windows.Forms.PictureBox MouseZone;
    }
}

