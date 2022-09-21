
namespace Mech423Lab1Exercise4
{
    partial class SerialDemo
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
            this.comboBoxCOMPorts = new System.Windows.Forms.ComboBox();
            this.serialConnectButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bytesToReadOutput = new System.Windows.Forms.TextBox();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.stringLengthOutput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numQueueItems = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.serialStreamOutput = new System.Windows.Forms.TextBox();
            this.outputRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // comboBoxCOMPorts
            // 
            this.comboBoxCOMPorts.AllowDrop = true;
            this.comboBoxCOMPorts.FormattingEnabled = true;
            this.comboBoxCOMPorts.Location = new System.Drawing.Point(12, 12);
            this.comboBoxCOMPorts.Name = "comboBoxCOMPorts";
            this.comboBoxCOMPorts.Size = new System.Drawing.Size(138, 24);
            this.comboBoxCOMPorts.TabIndex = 0;
            // 
            // serialConnectButton
            // 
            this.serialConnectButton.Location = new System.Drawing.Point(156, 12);
            this.serialConnectButton.Name = "serialConnectButton";
            this.serialConnectButton.Size = new System.Drawing.Size(152, 23);
            this.serialConnectButton.TabIndex = 1;
            this.serialConnectButton.Text = "Connect Serial";
            this.serialConnectButton.UseVisualStyleBackColor = true;
            this.serialConnectButton.Click += new System.EventHandler(this.serialConnectButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Serial Bytes to Read";
            // 
            // bytesToReadOutput
            // 
            this.bytesToReadOutput.Location = new System.Drawing.Point(156, 52);
            this.bytesToReadOutput.Name = "bytesToReadOutput";
            this.bytesToReadOutput.ReadOnly = true;
            this.bytesToReadOutput.Size = new System.Drawing.Size(152, 22);
            this.bytesToReadOutput.TabIndex = 3;
            // 
            // serialPort
            // 
            this.serialPort.PortName = "COM10";
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // stringLengthOutput
            // 
            this.stringLengthOutput.Location = new System.Drawing.Point(156, 80);
            this.stringLengthOutput.Name = "stringLengthOutput";
            this.stringLengthOutput.ReadOnly = true;
            this.stringLengthOutput.Size = new System.Drawing.Size(152, 22);
            this.stringLengthOutput.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Temp String Length";
            // 
            // numQueueItems
            // 
            this.numQueueItems.Location = new System.Drawing.Point(156, 108);
            this.numQueueItems.Name = "numQueueItems";
            this.numQueueItems.ReadOnly = true;
            this.numQueueItems.Size = new System.Drawing.Size(152, 22);
            this.numQueueItems.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Items in Queue";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Serial Data Stream:";
            // 
            // serialStreamOutput
            // 
            this.serialStreamOutput.Location = new System.Drawing.Point(12, 171);
            this.serialStreamOutput.Multiline = true;
            this.serialStreamOutput.Name = "serialStreamOutput";
            this.serialStreamOutput.ReadOnly = true;
            this.serialStreamOutput.Size = new System.Drawing.Size(296, 267);
            this.serialStreamOutput.TabIndex = 9;
            // 
            // outputRefreshTimer
            // 
            this.outputRefreshTimer.Enabled = true;
            this.outputRefreshTimer.Tick += new System.EventHandler(this.refreshOutput);
            // 
            // SerialDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 450);
            this.Controls.Add(this.serialStreamOutput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numQueueItems);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.stringLengthOutput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bytesToReadOutput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serialConnectButton);
            this.Controls.Add(this.comboBoxCOMPorts);
            this.Name = "SerialDemo";
            this.Text = "Serial Demo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCOMPorts;
        private System.Windows.Forms.Button serialConnectButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox bytesToReadOutput;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.TextBox stringLengthOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox numQueueItems;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox serialStreamOutput;
        private System.Windows.Forms.Timer outputRefreshTimer;
    }
}

