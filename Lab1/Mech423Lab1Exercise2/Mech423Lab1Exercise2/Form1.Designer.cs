
namespace Mech423Lab1Exercise2
{
    partial class QueueTest
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
            this.components = new System.ComponentModel.Container();
            this.EnqueueButton = new System.Windows.Forms.Button();
            this.DequeueButton = new System.Windows.Forms.Button();
            this.AverageButton = new System.Windows.Forms.Button();
            this.ItemsInQueueLabel = new System.Windows.Forms.Label();
            this.NLabel = new System.Windows.Forms.Label();
            this.ContentsLabel = new System.Windows.Forms.Label();
            this.AverageLable = new System.Windows.Forms.Label();
            this.ContentsOutput = new System.Windows.Forms.TextBox();
            this.QueueInput = new System.Windows.Forms.TextBox();
            this.QueueOutput = new System.Windows.Forms.TextBox();
            this.NInput = new System.Windows.Forms.TextBox();
            this.QueueLengthOutput = new System.Windows.Forms.TextBox();
            this.AverageOutput = new System.Windows.Forms.TextBox();
            this.UpdateQueueTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // EnqueueButton
            // 
            this.EnqueueButton.Location = new System.Drawing.Point(12, 12);
            this.EnqueueButton.Name = "EnqueueButton";
            this.EnqueueButton.Size = new System.Drawing.Size(140, 29);
            this.EnqueueButton.TabIndex = 0;
            this.EnqueueButton.Text = "Enqueue";
            this.EnqueueButton.UseVisualStyleBackColor = true;
            this.EnqueueButton.Click += new System.EventHandler(this.EnqueueButton_Click);
            // 
            // DequeueButton
            // 
            this.DequeueButton.Location = new System.Drawing.Point(12, 47);
            this.DequeueButton.Name = "DequeueButton";
            this.DequeueButton.Size = new System.Drawing.Size(140, 29);
            this.DequeueButton.TabIndex = 1;
            this.DequeueButton.Text = "Dequeue";
            this.DequeueButton.UseVisualStyleBackColor = true;
            this.DequeueButton.Click += new System.EventHandler(this.DequeueButton_Click);
            // 
            // AverageButton
            // 
            this.AverageButton.Location = new System.Drawing.Point(12, 128);
            this.AverageButton.Name = "AverageButton";
            this.AverageButton.Size = new System.Drawing.Size(374, 29);
            this.AverageButton.TabIndex = 2;
            this.AverageButton.Text = "Dequeue and Average First N Data Points";
            this.AverageButton.UseVisualStyleBackColor = true;
            this.AverageButton.Click += new System.EventHandler(this.AverageButton_Click);
            // 
            // ItemsInQueueLabel
            // 
            this.ItemsInQueueLabel.AutoSize = true;
            this.ItemsInQueueLabel.Location = new System.Drawing.Point(27, 90);
            this.ItemsInQueueLabel.Name = "ItemsInQueueLabel";
            this.ItemsInQueueLabel.Size = new System.Drawing.Size(108, 20);
            this.ItemsInQueueLabel.TabIndex = 3;
            this.ItemsInQueueLabel.Text = "Items in Queue";
            // 
            // NLabel
            // 
            this.NLabel.AutoSize = true;
            this.NLabel.Location = new System.Drawing.Point(12, 180);
            this.NLabel.Name = "NLabel";
            this.NLabel.Size = new System.Drawing.Size(23, 20);
            this.NLabel.TabIndex = 4;
            this.NLabel.Text = "N:";
            // 
            // ContentsLabel
            // 
            this.ContentsLabel.AutoSize = true;
            this.ContentsLabel.Location = new System.Drawing.Point(12, 225);
            this.ContentsLabel.Name = "ContentsLabel";
            this.ContentsLabel.Size = new System.Drawing.Size(114, 20);
            this.ContentsLabel.TabIndex = 5;
            this.ContentsLabel.Text = "Queue Contents";
            // 
            // AverageLable
            // 
            this.AverageLable.AutoSize = true;
            this.AverageLable.Location = new System.Drawing.Point(170, 180);
            this.AverageLable.Name = "AverageLable";
            this.AverageLable.Size = new System.Drawing.Size(67, 20);
            this.AverageLable.TabIndex = 6;
            this.AverageLable.Text = "Average:";
            // 
            // ContentsOutput
            // 
            this.ContentsOutput.Location = new System.Drawing.Point(12, 248);
            this.ContentsOutput.Multiline = true;
            this.ContentsOutput.Name = "ContentsOutput";
            this.ContentsOutput.ReadOnly = true;
            this.ContentsOutput.Size = new System.Drawing.Size(374, 190);
            this.ContentsOutput.TabIndex = 7;
            // 
            // QueueInput
            // 
            this.QueueInput.Location = new System.Drawing.Point(158, 12);
            this.QueueInput.Name = "QueueInput";
            this.QueueInput.Size = new System.Drawing.Size(228, 27);
            this.QueueInput.TabIndex = 8;
            // 
            // QueueOutput
            // 
            this.QueueOutput.Location = new System.Drawing.Point(158, 49);
            this.QueueOutput.Name = "QueueOutput";
            this.QueueOutput.ReadOnly = true;
            this.QueueOutput.Size = new System.Drawing.Size(228, 27);
            this.QueueOutput.TabIndex = 9;
            // 
            // NInput
            // 
            this.NInput.Location = new System.Drawing.Point(41, 177);
            this.NInput.Name = "NInput";
            this.NInput.Size = new System.Drawing.Size(111, 27);
            this.NInput.TabIndex = 10;
            // 
            // QueueLengthOutput
            // 
            this.QueueLengthOutput.Location = new System.Drawing.Point(158, 87);
            this.QueueLengthOutput.Name = "QueueLengthOutput";
            this.QueueLengthOutput.ReadOnly = true;
            this.QueueLengthOutput.Size = new System.Drawing.Size(228, 27);
            this.QueueLengthOutput.TabIndex = 11;
            // 
            // AverageOutput
            // 
            this.AverageOutput.Location = new System.Drawing.Point(243, 177);
            this.AverageOutput.Name = "AverageOutput";
            this.AverageOutput.ReadOnly = true;
            this.AverageOutput.Size = new System.Drawing.Size(143, 27);
            this.AverageOutput.TabIndex = 12;
            // 
            // UpdateQueueTimer
            // 
            this.UpdateQueueTimer.Enabled = true;
            this.UpdateQueueTimer.Tick += new System.EventHandler(this.UpdateQueue);
            // 
            // QueueTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 450);
            this.Controls.Add(this.AverageOutput);
            this.Controls.Add(this.QueueLengthOutput);
            this.Controls.Add(this.NInput);
            this.Controls.Add(this.QueueOutput);
            this.Controls.Add(this.QueueInput);
            this.Controls.Add(this.ContentsOutput);
            this.Controls.Add(this.AverageLable);
            this.Controls.Add(this.ContentsLabel);
            this.Controls.Add(this.NLabel);
            this.Controls.Add(this.ItemsInQueueLabel);
            this.Controls.Add(this.AverageButton);
            this.Controls.Add(this.DequeueButton);
            this.Controls.Add(this.EnqueueButton);
            this.Name = "QueueTest";
            this.Text = "QueueTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EnqueueButton;
        private System.Windows.Forms.Button DequeueButton;
        private System.Windows.Forms.Button AverageButton;
        private System.Windows.Forms.Label ItemsInQueueLabel;
        private System.Windows.Forms.Label NLabel;
        private System.Windows.Forms.Label ContentsLabel;
        private System.Windows.Forms.Label AverageLable;
        private System.Windows.Forms.TextBox ContentsOutput;
        private System.Windows.Forms.TextBox QueueInput;
        private System.Windows.Forms.TextBox QueueOutput;
        private System.Windows.Forms.TextBox NInput;
        private System.Windows.Forms.TextBox QueueLengthOutput;
        private System.Windows.Forms.TextBox AverageOutput;
        private System.Windows.Forms.Timer UpdateQueueTimer;
    }
}

