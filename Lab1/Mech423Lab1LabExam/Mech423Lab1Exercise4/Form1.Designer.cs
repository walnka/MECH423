
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
            this.axQueueItemsOutput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numQueueItems = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.serialStreamOutput = new System.Windows.Forms.TextBox();
            this.outputRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.axOutput = new System.Windows.Forms.TextBox();
            this.ayOutput = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.azOutput = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.orientationOutput = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.saveToFileOption = new System.Windows.Forms.CheckBox();
            this.selectFileButton = new System.Windows.Forms.Button();
            this.filenameOutput = new System.Windows.Forms.TextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.ayQueueItemsOutput = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.azQueueItemsOutput = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.stateTimer = new System.Windows.Forms.Timer(this.components);
            this.motion1Output = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.motion2Output = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.motion3Output = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.motion4Output = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.motion5Output = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.gestureNameOutput = new System.Windows.Forms.TextBox();
            this.defineGestureButton = new System.Windows.Forms.Button();
            this.detectNewBox = new System.Windows.Forms.CheckBox();
            this.maxAzOutput = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.maxAyOutput = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.maxAxOutput = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.magAccelAverageOutput = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.RefreshGestureTimer = new System.Windows.Forms.Timer(this.components);
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
            // axQueueItemsOutput
            // 
            this.axQueueItemsOutput.Location = new System.Drawing.Point(66, 80);
            this.axQueueItemsOutput.Name = "axQueueItemsOutput";
            this.axQueueItemsOutput.ReadOnly = true;
            this.axQueueItemsOutput.Size = new System.Drawing.Size(37, 22);
            this.axQueueItemsOutput.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ax Items";
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
            this.serialStreamOutput.Size = new System.Drawing.Size(296, 238);
            this.serialStreamOutput.TabIndex = 9;
            // 
            // outputRefreshTimer
            // 
            this.outputRefreshTimer.Enabled = true;
            this.outputRefreshTimer.Tick += new System.EventHandler(this.refreshOutput);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 419);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Ax";
            // 
            // axOutput
            // 
            this.axOutput.Location = new System.Drawing.Point(38, 416);
            this.axOutput.Name = "axOutput";
            this.axOutput.ReadOnly = true;
            this.axOutput.Size = new System.Drawing.Size(63, 22);
            this.axOutput.TabIndex = 11;
            // 
            // ayOutput
            // 
            this.ayOutput.Location = new System.Drawing.Point(144, 416);
            this.ayOutput.Name = "ayOutput";
            this.ayOutput.ReadOnly = true;
            this.ayOutput.Size = new System.Drawing.Size(63, 22);
            this.ayOutput.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(115, 419);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Ay";
            // 
            // azOutput
            // 
            this.azOutput.Location = new System.Drawing.Point(245, 416);
            this.azOutput.Name = "azOutput";
            this.azOutput.ReadOnly = true;
            this.azOutput.Size = new System.Drawing.Size(63, 22);
            this.azOutput.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(216, 419);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Az";
            // 
            // orientationOutput
            // 
            this.orientationOutput.Location = new System.Drawing.Point(149, 507);
            this.orientationOutput.Name = "orientationOutput";
            this.orientationOutput.ReadOnly = true;
            this.orientationOutput.Size = new System.Drawing.Size(122, 22);
            this.orientationOutput.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(44, 510);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Orientation Up";
            // 
            // saveToFileOption
            // 
            this.saveToFileOption.AutoSize = true;
            this.saveToFileOption.Location = new System.Drawing.Point(343, 191);
            this.saveToFileOption.Name = "saveToFileOption";
            this.saveToFileOption.Size = new System.Drawing.Size(109, 21);
            this.saveToFileOption.TabIndex = 18;
            this.saveToFileOption.Text = "Save To File";
            this.saveToFileOption.UseVisualStyleBackColor = true;
            this.saveToFileOption.CheckedChanged += new System.EventHandler(this.saveToFileOption_CheckedChanged);
            // 
            // selectFileButton
            // 
            this.selectFileButton.Location = new System.Drawing.Point(343, 218);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(127, 23);
            this.selectFileButton.TabIndex = 19;
            this.selectFileButton.Text = "Select Filename";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.selectFileButton_Click);
            // 
            // filenameOutput
            // 
            this.filenameOutput.Location = new System.Drawing.Point(475, 218);
            this.filenameOutput.Name = "filenameOutput";
            this.filenameOutput.Size = new System.Drawing.Size(166, 22);
            this.filenameOutput.TabIndex = 20;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.CreatePrompt = true;
            this.saveFileDialog.RestoreDirectory = true;
            // 
            // ayQueueItemsOutput
            // 
            this.ayQueueItemsOutput.Location = new System.Drawing.Point(170, 80);
            this.ayQueueItemsOutput.Name = "ayQueueItemsOutput";
            this.ayQueueItemsOutput.ReadOnly = true;
            this.ayQueueItemsOutput.Size = new System.Drawing.Size(37, 22);
            this.ayQueueItemsOutput.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(108, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 17);
            this.label9.TabIndex = 21;
            this.label9.Text = "Ay Items";
            // 
            // azQueueItemsOutput
            // 
            this.azQueueItemsOutput.Location = new System.Drawing.Point(273, 80);
            this.azQueueItemsOutput.Name = "azQueueItemsOutput";
            this.azQueueItemsOutput.ReadOnly = true;
            this.azQueueItemsOutput.Size = new System.Drawing.Size(37, 22);
            this.azQueueItemsOutput.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(211, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 17);
            this.label10.TabIndex = 23;
            this.label10.Text = "Az Items";
            // 
            // stateTimer
            // 
            this.stateTimer.Interval = 2000;
            this.stateTimer.Tick += new System.EventHandler(this.stateTimer_Tick);
            // 
            // motion1Output
            // 
            this.motion1Output.Location = new System.Drawing.Point(336, 31);
            this.motion1Output.Name = "motion1Output";
            this.motion1Output.ReadOnly = true;
            this.motion1Output.Size = new System.Drawing.Size(35, 22);
            this.motion1Output.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(377, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 17);
            this.label11.TabIndex = 26;
            this.label11.Text = "+";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(449, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 17);
            this.label12.TabIndex = 27;
            this.label12.Text = "Motions";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(440, 34);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 17);
            this.label13.TabIndex = 29;
            this.label13.Text = "+";
            // 
            // motion2Output
            // 
            this.motion2Output.Location = new System.Drawing.Point(399, 31);
            this.motion2Output.Name = "motion2Output";
            this.motion2Output.ReadOnly = true;
            this.motion2Output.Size = new System.Drawing.Size(35, 22);
            this.motion2Output.TabIndex = 28;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(503, 34);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(16, 17);
            this.label14.TabIndex = 31;
            this.label14.Text = "+";
            // 
            // motion3Output
            // 
            this.motion3Output.Location = new System.Drawing.Point(462, 31);
            this.motion3Output.Name = "motion3Output";
            this.motion3Output.ReadOnly = true;
            this.motion3Output.Size = new System.Drawing.Size(35, 22);
            this.motion3Output.TabIndex = 30;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(566, 34);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(16, 17);
            this.label15.TabIndex = 33;
            this.label15.Text = "+";
            // 
            // motion4Output
            // 
            this.motion4Output.Location = new System.Drawing.Point(525, 31);
            this.motion4Output.Name = "motion4Output";
            this.motion4Output.ReadOnly = true;
            this.motion4Output.Size = new System.Drawing.Size(35, 22);
            this.motion4Output.TabIndex = 32;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(630, 36);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(0, 17);
            this.label16.TabIndex = 35;
            // 
            // motion5Output
            // 
            this.motion5Output.Location = new System.Drawing.Point(588, 31);
            this.motion5Output.Name = "motion5Output";
            this.motion5Output.ReadOnly = true;
            this.motion5Output.Size = new System.Drawing.Size(35, 22);
            this.motion5Output.TabIndex = 34;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(429, 80);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(100, 17);
            this.label17.TabIndex = 36;
            this.label17.Text = "Gesture Name";
            // 
            // gestureNameOutput
            // 
            this.gestureNameOutput.Location = new System.Drawing.Point(336, 100);
            this.gestureNameOutput.Name = "gestureNameOutput";
            this.gestureNameOutput.Size = new System.Drawing.Size(294, 22);
            this.gestureNameOutput.TabIndex = 37;
            this.gestureNameOutput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gestureNameOutput.TextChanged += new System.EventHandler(this.gestureNameOutput_TextChanged);
            // 
            // defineGestureButton
            // 
            this.defineGestureButton.Location = new System.Drawing.Point(462, 144);
            this.defineGestureButton.Name = "defineGestureButton";
            this.defineGestureButton.Size = new System.Drawing.Size(127, 23);
            this.defineGestureButton.TabIndex = 38;
            this.defineGestureButton.Text = "Define New Gesture";
            this.defineGestureButton.UseVisualStyleBackColor = true;
            this.defineGestureButton.Click += new System.EventHandler(this.defineGestureButton_Click);
            // 
            // detectNewBox
            // 
            this.detectNewBox.AutoSize = true;
            this.detectNewBox.Location = new System.Drawing.Point(343, 146);
            this.detectNewBox.Name = "detectNewBox";
            this.detectNewBox.Size = new System.Drawing.Size(102, 21);
            this.detectNewBox.TabIndex = 39;
            this.detectNewBox.Text = "Detect New";
            this.detectNewBox.UseVisualStyleBackColor = true;
            // 
            // maxAzOutput
            // 
            this.maxAzOutput.Location = new System.Drawing.Point(259, 450);
            this.maxAzOutput.Name = "maxAzOutput";
            this.maxAzOutput.ReadOnly = true;
            this.maxAzOutput.Size = new System.Drawing.Size(49, 22);
            this.maxAzOutput.TabIndex = 45;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(209, 453);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 17);
            this.label18.TabIndex = 44;
            this.label18.Text = "Max Az";
            // 
            // maxAyOutput
            // 
            this.maxAyOutput.Location = new System.Drawing.Point(156, 450);
            this.maxAyOutput.Name = "maxAyOutput";
            this.maxAyOutput.ReadOnly = true;
            this.maxAyOutput.Size = new System.Drawing.Size(51, 22);
            this.maxAyOutput.TabIndex = 43;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(106, 453);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 17);
            this.label19.TabIndex = 42;
            this.label19.Text = "Max Ay";
            // 
            // maxAxOutput
            // 
            this.maxAxOutput.Location = new System.Drawing.Point(47, 450);
            this.maxAxOutput.Name = "maxAxOutput";
            this.maxAxOutput.ReadOnly = true;
            this.maxAxOutput.Size = new System.Drawing.Size(54, 22);
            this.maxAxOutput.TabIndex = 41;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(-2, 453);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(52, 17);
            this.label20.TabIndex = 40;
            this.label20.Text = "Max Ax";
            // 
            // magAccelAverageOutput
            // 
            this.magAccelAverageOutput.Location = new System.Drawing.Point(148, 480);
            this.magAccelAverageOutput.Name = "magAccelAverageOutput";
            this.magAccelAverageOutput.ReadOnly = true;
            this.magAccelAverageOutput.Size = new System.Drawing.Size(122, 22);
            this.magAccelAverageOutput.TabIndex = 47;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(20, 483);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(128, 17);
            this.label21.TabIndex = 46;
            this.label21.Text = "Magnitude of Accel";
            // 
            // RefreshGestureTimer
            // 
            this.RefreshGestureTimer.Interval = 1000;
            this.RefreshGestureTimer.Tick += new System.EventHandler(this.RefreshGestureTimer_Tick);
            // 
            // SerialDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 554);
            this.Controls.Add(this.magAccelAverageOutput);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.maxAzOutput);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.maxAyOutput);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.maxAxOutput);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.detectNewBox);
            this.Controls.Add(this.defineGestureButton);
            this.Controls.Add(this.gestureNameOutput);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.motion5Output);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.motion4Output);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.motion3Output);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.motion2Output);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.motion1Output);
            this.Controls.Add(this.azQueueItemsOutput);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ayQueueItemsOutput);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.filenameOutput);
            this.Controls.Add(this.selectFileButton);
            this.Controls.Add(this.saveToFileOption);
            this.Controls.Add(this.orientationOutput);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.azOutput);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ayOutput);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.axOutput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.serialStreamOutput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numQueueItems);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.axQueueItemsOutput);
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
        private System.Windows.Forms.TextBox axQueueItemsOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox numQueueItems;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox serialStreamOutput;
        private System.Windows.Forms.Timer outputRefreshTimer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox axOutput;
        private System.Windows.Forms.TextBox ayOutput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox azOutput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox orientationOutput;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox saveToFileOption;
        private System.Windows.Forms.Button selectFileButton;
        private System.Windows.Forms.TextBox filenameOutput;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TextBox ayQueueItemsOutput;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox azQueueItemsOutput;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Timer stateTimer;
        private System.Windows.Forms.TextBox motion1Output;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox motion2Output;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox motion3Output;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox motion4Output;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox motion5Output;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox gestureNameOutput;
        private System.Windows.Forms.Button defineGestureButton;
        private System.Windows.Forms.CheckBox detectNewBox;
        private System.Windows.Forms.TextBox maxAzOutput;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox maxAyOutput;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox maxAxOutput;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox magAccelAverageOutput;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Timer RefreshGestureTimer;
    }
}

