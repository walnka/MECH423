namespace MotorController
{
    partial class Form1
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
            this.labelBaud = new System.Windows.Forms.Label();
            this.textBoxBaud = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.labelPacketInput = new System.Windows.Forms.Label();
            this.textBoxStart = new System.Windows.Forms.TextBox();
            this.labelStartByte = new System.Windows.Forms.Label();
            this.labelCommandByte = new System.Windows.Forms.Label();
            this.textBoxCommand = new System.Windows.Forms.TextBox();
            this.labelPWM1 = new System.Windows.Forms.Label();
            this.textBoxPWM1 = new System.Windows.Forms.TextBox();
            this.labelPWM2 = new System.Windows.Forms.Label();
            this.textBoxPWM2 = new System.Windows.Forms.TextBox();
            this.labelEscapeByte = new System.Windows.Forms.Label();
            this.textBoxEscape = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.buttonTransmit = new System.Windows.Forms.Button();
            this.textBoxSerialDataStream = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.trackBarDCSpeed = new System.Windows.Forms.TrackBar();
            this.labelDCSpeed = new System.Windows.Forms.Label();
            this.labelStepperSpeed = new System.Windows.Forms.Label();
            this.trackBarStepperSpeed = new System.Windows.Forms.TrackBar();
            this.buttonStepCW = new System.Windows.Forms.Button();
            this.buttonStepCCW = new System.Windows.Forms.Button();
            this.DCSpeed = new System.Windows.Forms.Label();
            this.StepperSpeed = new System.Windows.Forms.Label();
            this.buttonStopDC = new System.Windows.Forms.Button();
            this.buttonStopStepper = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDCSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarStepperSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxCOMPorts
            // 
            this.comboBoxCOMPorts.FormattingEnabled = true;
            this.comboBoxCOMPorts.Location = new System.Drawing.Point(13, 16);
            this.comboBoxCOMPorts.Name = "comboBoxCOMPorts";
            this.comboBoxCOMPorts.Size = new System.Drawing.Size(121, 24);
            this.comboBoxCOMPorts.TabIndex = 0;
            // 
            // labelBaud
            // 
            this.labelBaud.AutoSize = true;
            this.labelBaud.Location = new System.Drawing.Point(140, 19);
            this.labelBaud.Name = "labelBaud";
            this.labelBaud.Size = new System.Drawing.Size(79, 17);
            this.labelBaud.TabIndex = 1;
            this.labelBaud.Text = "Baud Rate:";
            // 
            // textBoxBaud
            // 
            this.textBoxBaud.Location = new System.Drawing.Point(221, 16);
            this.textBoxBaud.Name = "textBoxBaud";
            this.textBoxBaud.Size = new System.Drawing.Size(100, 22);
            this.textBoxBaud.TabIndex = 2;
            this.textBoxBaud.Text = "9600";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(327, 15);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(120, 23);
            this.buttonConnect.TabIndex = 3;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // labelPacketInput
            // 
            this.labelPacketInput.AutoSize = true;
            this.labelPacketInput.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPacketInput.Location = new System.Drawing.Point(12, 61);
            this.labelPacketInput.Name = "labelPacketInput";
            this.labelPacketInput.Size = new System.Drawing.Size(178, 35);
            this.labelPacketInput.TabIndex = 4;
            this.labelPacketInput.Text = "PACKET INPUT";
            // 
            // textBoxStart
            // 
            this.textBoxStart.Location = new System.Drawing.Point(13, 124);
            this.textBoxStart.Name = "textBoxStart";
            this.textBoxStart.Size = new System.Drawing.Size(100, 22);
            this.textBoxStart.TabIndex = 5;
            this.textBoxStart.Leave += new System.EventHandler(this.textBoxStart_Leave);
            // 
            // labelStartByte
            // 
            this.labelStartByte.AutoSize = true;
            this.labelStartByte.Location = new System.Drawing.Point(13, 105);
            this.labelStartByte.Name = "labelStartByte";
            this.labelStartByte.Size = new System.Drawing.Size(108, 17);
            this.labelStartByte.TabIndex = 6;
            this.labelStartByte.Text = "Start Byte (255)";
            // 
            // labelCommandByte
            // 
            this.labelCommandByte.AutoSize = true;
            this.labelCommandByte.Location = new System.Drawing.Point(124, 105);
            this.labelCommandByte.Name = "labelCommandByte";
            this.labelCommandByte.Size = new System.Drawing.Size(103, 17);
            this.labelCommandByte.TabIndex = 8;
            this.labelCommandByte.Text = "Command Byte";
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.Location = new System.Drawing.Point(124, 124);
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.Size = new System.Drawing.Size(100, 22);
            this.textBoxCommand.TabIndex = 7;
            this.textBoxCommand.Leave += new System.EventHandler(this.textBoxCommand_Leave);
            // 
            // labelPWM1
            // 
            this.labelPWM1.AutoSize = true;
            this.labelPWM1.Location = new System.Drawing.Point(235, 105);
            this.labelPWM1.Name = "labelPWM1";
            this.labelPWM1.Size = new System.Drawing.Size(85, 17);
            this.labelPWM1.TabIndex = 10;
            this.labelPWM1.Text = "PWM Byte 1";
            // 
            // textBoxPWM1
            // 
            this.textBoxPWM1.Location = new System.Drawing.Point(235, 124);
            this.textBoxPWM1.Name = "textBoxPWM1";
            this.textBoxPWM1.Size = new System.Drawing.Size(100, 22);
            this.textBoxPWM1.TabIndex = 9;
            this.textBoxPWM1.Leave += new System.EventHandler(this.textBoxPWM1_Leave);
            // 
            // labelPWM2
            // 
            this.labelPWM2.AutoSize = true;
            this.labelPWM2.Location = new System.Drawing.Point(347, 105);
            this.labelPWM2.Name = "labelPWM2";
            this.labelPWM2.Size = new System.Drawing.Size(85, 17);
            this.labelPWM2.TabIndex = 12;
            this.labelPWM2.Text = "PWM Byte 2";
            // 
            // textBoxPWM2
            // 
            this.textBoxPWM2.Location = new System.Drawing.Point(347, 124);
            this.textBoxPWM2.Name = "textBoxPWM2";
            this.textBoxPWM2.Size = new System.Drawing.Size(100, 22);
            this.textBoxPWM2.TabIndex = 11;
            this.textBoxPWM2.Leave += new System.EventHandler(this.textBoxPWM2_Leave);
            // 
            // labelEscapeByte
            // 
            this.labelEscapeByte.AutoSize = true;
            this.labelEscapeByte.Location = new System.Drawing.Point(460, 105);
            this.labelEscapeByte.Name = "labelEscapeByte";
            this.labelEscapeByte.Size = new System.Drawing.Size(87, 17);
            this.labelEscapeByte.TabIndex = 14;
            this.labelEscapeByte.Text = "Escape Byte";
            // 
            // textBoxEscape
            // 
            this.textBoxEscape.Location = new System.Drawing.Point(460, 124);
            this.textBoxEscape.Name = "textBoxEscape";
            this.textBoxEscape.Size = new System.Drawing.Size(100, 22);
            this.textBoxEscape.TabIndex = 13;
            this.textBoxEscape.Leave += new System.EventHandler(this.textBoxEscape_Leave);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // buttonTransmit
            // 
            this.buttonTransmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTransmit.Location = new System.Drawing.Point(13, 153);
            this.buttonTransmit.Name = "buttonTransmit";
            this.buttonTransmit.Size = new System.Drawing.Size(547, 39);
            this.buttonTransmit.TabIndex = 15;
            this.buttonTransmit.Text = "Transmit to COM Port";
            this.buttonTransmit.UseVisualStyleBackColor = true;
            this.buttonTransmit.Click += new System.EventHandler(this.buttonTransmit_Click);
            // 
            // textBoxSerialDataStream
            // 
            this.textBoxSerialDataStream.Location = new System.Drawing.Point(13, 198);
            this.textBoxSerialDataStream.Multiline = true;
            this.textBoxSerialDataStream.Name = "textBoxSerialDataStream";
            this.textBoxSerialDataStream.Size = new System.Drawing.Size(547, 163);
            this.textBoxSerialDataStream.TabIndex = 16;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 376);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 35);
            this.label1.TabIndex = 17;
            this.label1.Text = "SPEED CONTROL";
            // 
            // trackBarDCSpeed
            // 
            this.trackBarDCSpeed.LargeChange = 1000;
            this.trackBarDCSpeed.Location = new System.Drawing.Point(12, 443);
            this.trackBarDCSpeed.Maximum = 65535;
            this.trackBarDCSpeed.Minimum = -65535;
            this.trackBarDCSpeed.Name = "trackBarDCSpeed";
            this.trackBarDCSpeed.Size = new System.Drawing.Size(548, 56);
            this.trackBarDCSpeed.SmallChange = 100;
            this.trackBarDCSpeed.TabIndex = 18;
            this.trackBarDCSpeed.TickFrequency = 100;
            this.trackBarDCSpeed.ValueChanged += new System.EventHandler(this.trackBarDCSpeed_ValueChanged);
            // 
            // labelDCSpeed
            // 
            this.labelDCSpeed.AutoSize = true;
            this.labelDCSpeed.Location = new System.Drawing.Point(12, 424);
            this.labelDCSpeed.Name = "labelDCSpeed";
            this.labelDCSpeed.Size = new System.Drawing.Size(116, 17);
            this.labelDCSpeed.TabIndex = 19;
            this.labelDCSpeed.Text = "DC Motor Speed:";
            // 
            // labelStepperSpeed
            // 
            this.labelStepperSpeed.AutoSize = true;
            this.labelStepperSpeed.Location = new System.Drawing.Point(12, 502);
            this.labelStepperSpeed.Name = "labelStepperSpeed";
            this.labelStepperSpeed.Size = new System.Drawing.Size(147, 17);
            this.labelStepperSpeed.TabIndex = 21;
            this.labelStepperSpeed.Text = "Stepper Motor Speed:";
            // 
            // trackBarStepperSpeed
            // 
            this.trackBarStepperSpeed.LargeChange = 10;
            this.trackBarStepperSpeed.Location = new System.Drawing.Point(12, 521);
            this.trackBarStepperSpeed.Maximum = 1000;
            this.trackBarStepperSpeed.Minimum = -1000;
            this.trackBarStepperSpeed.Name = "trackBarStepperSpeed";
            this.trackBarStepperSpeed.Size = new System.Drawing.Size(548, 56);
            this.trackBarStepperSpeed.SmallChange = 10;
            this.trackBarStepperSpeed.TabIndex = 20;
            this.trackBarStepperSpeed.TickFrequency = 10;
            this.trackBarStepperSpeed.ValueChanged += new System.EventHandler(this.trackBarStepperSpeed_ValueChanged);
            // 
            // buttonStepCW
            // 
            this.buttonStepCW.Location = new System.Drawing.Point(196, 61);
            this.buttonStepCW.Name = "buttonStepCW";
            this.buttonStepCW.Size = new System.Drawing.Size(75, 33);
            this.buttonStepCW.TabIndex = 22;
            this.buttonStepCW.Text = "Step CW";
            this.buttonStepCW.UseVisualStyleBackColor = true;
            this.buttonStepCW.Click += new System.EventHandler(this.buttonStepCW_Click);
            // 
            // buttonStepCCW
            // 
            this.buttonStepCCW.Location = new System.Drawing.Point(277, 61);
            this.buttonStepCCW.Name = "buttonStepCCW";
            this.buttonStepCCW.Size = new System.Drawing.Size(86, 33);
            this.buttonStepCCW.TabIndex = 23;
            this.buttonStepCCW.Text = "Step CCW";
            this.buttonStepCCW.UseVisualStyleBackColor = true;
            this.buttonStepCCW.Click += new System.EventHandler(this.buttonStepCCW_Click);
            // 
            // DCSpeed
            // 
            this.DCSpeed.AutoSize = true;
            this.DCSpeed.Location = new System.Drawing.Point(134, 424);
            this.DCSpeed.Name = "DCSpeed";
            this.DCSpeed.Size = new System.Drawing.Size(0, 17);
            this.DCSpeed.TabIndex = 24;
            // 
            // StepperSpeed
            // 
            this.StepperSpeed.AutoSize = true;
            this.StepperSpeed.Location = new System.Drawing.Point(171, 502);
            this.StepperSpeed.Name = "StepperSpeed";
            this.StepperSpeed.Size = new System.Drawing.Size(0, 17);
            this.StepperSpeed.TabIndex = 25;
            // 
            // buttonStopDC
            // 
            this.buttonStopDC.Location = new System.Drawing.Point(369, 61);
            this.buttonStopDC.Name = "buttonStopDC";
            this.buttonStopDC.Size = new System.Drawing.Size(75, 33);
            this.buttonStopDC.TabIndex = 26;
            this.buttonStopDC.Text = "Stop DC";
            this.buttonStopDC.UseVisualStyleBackColor = true;
            this.buttonStopDC.Click += new System.EventHandler(this.buttonStopDC_Click);
            // 
            // buttonStopStepper
            // 
            this.buttonStopStepper.Location = new System.Drawing.Point(450, 61);
            this.buttonStopStepper.Name = "buttonStopStepper";
            this.buttonStopStepper.Size = new System.Drawing.Size(110, 33);
            this.buttonStopStepper.TabIndex = 27;
            this.buttonStopStepper.Text = "Stop Stepper";
            this.buttonStopStepper.UseVisualStyleBackColor = true;
            this.buttonStopStepper.Click += new System.EventHandler(this.buttonStopStepper_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 598);
            this.Controls.Add(this.buttonStopStepper);
            this.Controls.Add(this.buttonStopDC);
            this.Controls.Add(this.StepperSpeed);
            this.Controls.Add(this.DCSpeed);
            this.Controls.Add(this.buttonStepCCW);
            this.Controls.Add(this.buttonStepCW);
            this.Controls.Add(this.labelStepperSpeed);
            this.Controls.Add(this.trackBarStepperSpeed);
            this.Controls.Add(this.labelDCSpeed);
            this.Controls.Add(this.trackBarDCSpeed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxSerialDataStream);
            this.Controls.Add(this.buttonTransmit);
            this.Controls.Add(this.labelEscapeByte);
            this.Controls.Add(this.textBoxEscape);
            this.Controls.Add(this.labelPWM2);
            this.Controls.Add(this.textBoxPWM2);
            this.Controls.Add(this.labelPWM1);
            this.Controls.Add(this.textBoxPWM1);
            this.Controls.Add(this.labelCommandByte);
            this.Controls.Add(this.textBoxCommand);
            this.Controls.Add(this.labelStartByte);
            this.Controls.Add(this.textBoxStart);
            this.Controls.Add(this.labelPacketInput);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.textBoxBaud);
            this.Controls.Add(this.labelBaud);
            this.Controls.Add(this.comboBoxCOMPorts);
            this.Name = "Form1";
            this.Text = "Motor Controller";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDCSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarStepperSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCOMPorts;
        private System.Windows.Forms.Label labelBaud;
        private System.Windows.Forms.TextBox textBoxBaud;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label labelPacketInput;
        private System.Windows.Forms.TextBox textBoxStart;
        private System.Windows.Forms.Label labelStartByte;
        private System.Windows.Forms.Label labelCommandByte;
        private System.Windows.Forms.TextBox textBoxCommand;
        private System.Windows.Forms.Label labelPWM1;
        private System.Windows.Forms.TextBox textBoxPWM1;
        private System.Windows.Forms.Label labelPWM2;
        private System.Windows.Forms.TextBox textBoxPWM2;
        private System.Windows.Forms.Label labelEscapeByte;
        private System.Windows.Forms.TextBox textBoxEscape;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button buttonTransmit;
        private System.Windows.Forms.TextBox textBoxSerialDataStream;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBarDCSpeed;
        private System.Windows.Forms.Label labelDCSpeed;
        private System.Windows.Forms.Label labelStepperSpeed;
        private System.Windows.Forms.TrackBar trackBarStepperSpeed;
        private System.Windows.Forms.Button buttonStepCW;
        private System.Windows.Forms.Button buttonStepCCW;
        private System.Windows.Forms.Label DCSpeed;
        private System.Windows.Forms.Label StepperSpeed;
        private System.Windows.Forms.Button buttonStopDC;
        private System.Windows.Forms.Button buttonStopStepper;
    }
}

