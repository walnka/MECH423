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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
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
            this.textBoxUserConsole = new System.Windows.Forms.TextBox();
            this.timerRead = new System.Windows.Forms.Timer(this.components);
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDCPosition = new System.Windows.Forms.TextBox();
            this.textBoxDCSpeedRPM = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chartPosSpeed = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timerWrite = new System.Windows.Forms.Timer(this.components);
            this.buttonClearChart = new System.Windows.Forms.Button();
            this.textBoxDCSpeedHz = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.textBoxXPos = new System.Windows.Forms.TextBox();
            this.textBoxYPos = new System.Windows.Forms.TextBox();
            this.buttonTransmitXY = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonTransmitX = new System.Windows.Forms.Button();
            this.buttonTransmitY = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDCSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarStepperSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPosSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxCOMPorts
            // 
            this.comboBoxCOMPorts.FormattingEnabled = true;
            this.comboBoxCOMPorts.Location = new System.Drawing.Point(13, 16);
            this.comboBoxCOMPorts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxCOMPorts.Name = "comboBoxCOMPorts";
            this.comboBoxCOMPorts.Size = new System.Drawing.Size(121, 24);
            this.comboBoxCOMPorts.TabIndex = 0;
            // 
            // labelBaud
            // 
            this.labelBaud.AutoSize = true;
            this.labelBaud.Location = new System.Drawing.Point(140, 18);
            this.labelBaud.Name = "labelBaud";
            this.labelBaud.Size = new System.Drawing.Size(74, 16);
            this.labelBaud.TabIndex = 1;
            this.labelBaud.Text = "Baud Rate:";
            // 
            // textBoxBaud
            // 
            this.textBoxBaud.Location = new System.Drawing.Point(221, 16);
            this.textBoxBaud.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxBaud.Name = "textBoxBaud";
            this.textBoxBaud.Size = new System.Drawing.Size(100, 22);
            this.textBoxBaud.TabIndex = 2;
            this.textBoxBaud.Text = "9600";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(327, 15);
            this.buttonConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.labelPacketInput.Location = new System.Drawing.Point(12, 62);
            this.labelPacketInput.Name = "labelPacketInput";
            this.labelPacketInput.Size = new System.Drawing.Size(178, 35);
            this.labelPacketInput.TabIndex = 4;
            this.labelPacketInput.Text = "PACKET INPUT";
            // 
            // textBoxStart
            // 
            this.textBoxStart.Location = new System.Drawing.Point(13, 124);
            this.textBoxStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxStart.Name = "textBoxStart";
            this.textBoxStart.Size = new System.Drawing.Size(100, 22);
            this.textBoxStart.TabIndex = 5;
            this.textBoxStart.Text = "255";
            // 
            // labelStartByte
            // 
            this.labelStartByte.AutoSize = true;
            this.labelStartByte.Location = new System.Drawing.Point(13, 105);
            this.labelStartByte.Name = "labelStartByte";
            this.labelStartByte.Size = new System.Drawing.Size(96, 16);
            this.labelStartByte.TabIndex = 6;
            this.labelStartByte.Text = "Start Byte (255)";
            // 
            // labelCommandByte
            // 
            this.labelCommandByte.AutoSize = true;
            this.labelCommandByte.Location = new System.Drawing.Point(124, 105);
            this.labelCommandByte.Name = "labelCommandByte";
            this.labelCommandByte.Size = new System.Drawing.Size(99, 16);
            this.labelCommandByte.TabIndex = 8;
            this.labelCommandByte.Text = "Command Byte";
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.Location = new System.Drawing.Point(124, 124);
            this.textBoxCommand.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.Size = new System.Drawing.Size(100, 22);
            this.textBoxCommand.TabIndex = 7;
            // 
            // labelPWM1
            // 
            this.labelPWM1.AutoSize = true;
            this.labelPWM1.Location = new System.Drawing.Point(235, 105);
            this.labelPWM1.Name = "labelPWM1";
            this.labelPWM1.Size = new System.Drawing.Size(80, 16);
            this.labelPWM1.TabIndex = 10;
            this.labelPWM1.Text = "PWM Byte 1";
            // 
            // textBoxPWM1
            // 
            this.textBoxPWM1.Location = new System.Drawing.Point(235, 124);
            this.textBoxPWM1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPWM1.Name = "textBoxPWM1";
            this.textBoxPWM1.Size = new System.Drawing.Size(100, 22);
            this.textBoxPWM1.TabIndex = 9;
            this.textBoxPWM1.Text = "0";
            // 
            // labelPWM2
            // 
            this.labelPWM2.AutoSize = true;
            this.labelPWM2.Location = new System.Drawing.Point(347, 105);
            this.labelPWM2.Name = "labelPWM2";
            this.labelPWM2.Size = new System.Drawing.Size(80, 16);
            this.labelPWM2.TabIndex = 12;
            this.labelPWM2.Text = "PWM Byte 2";
            // 
            // textBoxPWM2
            // 
            this.textBoxPWM2.Location = new System.Drawing.Point(347, 124);
            this.textBoxPWM2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPWM2.Name = "textBoxPWM2";
            this.textBoxPWM2.Size = new System.Drawing.Size(100, 22);
            this.textBoxPWM2.TabIndex = 11;
            this.textBoxPWM2.Text = "0";
            // 
            // labelEscapeByte
            // 
            this.labelEscapeByte.AutoSize = true;
            this.labelEscapeByte.Location = new System.Drawing.Point(460, 105);
            this.labelEscapeByte.Name = "labelEscapeByte";
            this.labelEscapeByte.Size = new System.Drawing.Size(84, 16);
            this.labelEscapeByte.TabIndex = 14;
            this.labelEscapeByte.Text = "Escape Byte";
            // 
            // textBoxEscape
            // 
            this.textBoxEscape.Location = new System.Drawing.Point(460, 124);
            this.textBoxEscape.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxEscape.Name = "textBoxEscape";
            this.textBoxEscape.Size = new System.Drawing.Size(100, 22);
            this.textBoxEscape.TabIndex = 13;
            this.textBoxEscape.Text = "0";
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // buttonTransmit
            // 
            this.buttonTransmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTransmit.Location = new System.Drawing.Point(13, 153);
            this.buttonTransmit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonTransmit.Name = "buttonTransmit";
            this.buttonTransmit.Size = new System.Drawing.Size(547, 39);
            this.buttonTransmit.TabIndex = 15;
            this.buttonTransmit.Text = "Transmit to COM Port";
            this.buttonTransmit.UseVisualStyleBackColor = true;
            this.buttonTransmit.Click += new System.EventHandler(this.buttonTransmit_Click);
            // 
            // textBoxUserConsole
            // 
            this.textBoxUserConsole.AcceptsReturn = true;
            this.textBoxUserConsole.Location = new System.Drawing.Point(13, 198);
            this.textBoxUserConsole.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxUserConsole.Multiline = true;
            this.textBoxUserConsole.Name = "textBoxUserConsole";
            this.textBoxUserConsole.Size = new System.Drawing.Size(547, 56);
            this.textBoxUserConsole.TabIndex = 16;
            // 
            // timerRead
            // 
            this.timerRead.Interval = 50;
            this.timerRead.Tick += new System.EventHandler(this.timerRead_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 35);
            this.label1.TabIndex = 17;
            this.label1.Text = "SPEED CONTROL";
            // 
            // trackBarDCSpeed
            // 
            this.trackBarDCSpeed.LargeChange = 1000;
            this.trackBarDCSpeed.Location = new System.Drawing.Point(12, 322);
            this.trackBarDCSpeed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.labelDCSpeed.Location = new System.Drawing.Point(12, 302);
            this.labelDCSpeed.Name = "labelDCSpeed";
            this.labelDCSpeed.Size = new System.Drawing.Size(110, 16);
            this.labelDCSpeed.TabIndex = 19;
            this.labelDCSpeed.Text = "DC Motor Speed:";
            // 
            // labelStepperSpeed
            // 
            this.labelStepperSpeed.AutoSize = true;
            this.labelStepperSpeed.Location = new System.Drawing.Point(12, 381);
            this.labelStepperSpeed.Name = "labelStepperSpeed";
            this.labelStepperSpeed.Size = new System.Drawing.Size(139, 16);
            this.labelStepperSpeed.TabIndex = 21;
            this.labelStepperSpeed.Text = "Stepper Motor Speed:";
            // 
            // trackBarStepperSpeed
            // 
            this.trackBarStepperSpeed.LargeChange = 10;
            this.trackBarStepperSpeed.Location = new System.Drawing.Point(12, 400);
            this.trackBarStepperSpeed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.buttonStepCW.Location = new System.Drawing.Point(196, 62);
            this.buttonStepCW.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonStepCW.Name = "buttonStepCW";
            this.buttonStepCW.Size = new System.Drawing.Size(84, 33);
            this.buttonStepCW.TabIndex = 22;
            this.buttonStepCW.Text = "Step CW";
            this.buttonStepCW.UseVisualStyleBackColor = true;
            this.buttonStepCW.Click += new System.EventHandler(this.buttonStepCW_Click);
            // 
            // buttonStepCCW
            // 
            this.buttonStepCCW.Location = new System.Drawing.Point(286, 62);
            this.buttonStepCCW.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonStepCCW.Name = "buttonStepCCW";
            this.buttonStepCCW.Size = new System.Drawing.Size(87, 33);
            this.buttonStepCCW.TabIndex = 23;
            this.buttonStepCCW.Text = "Step CCW";
            this.buttonStepCCW.UseVisualStyleBackColor = true;
            this.buttonStepCCW.Click += new System.EventHandler(this.buttonStepCCW_Click);
            // 
            // DCSpeed
            // 
            this.DCSpeed.AutoSize = true;
            this.DCSpeed.Location = new System.Drawing.Point(133, 302);
            this.DCSpeed.Name = "DCSpeed";
            this.DCSpeed.Size = new System.Drawing.Size(0, 16);
            this.DCSpeed.TabIndex = 24;
            // 
            // StepperSpeed
            // 
            this.StepperSpeed.AutoSize = true;
            this.StepperSpeed.Location = new System.Drawing.Point(171, 381);
            this.StepperSpeed.Name = "StepperSpeed";
            this.StepperSpeed.Size = new System.Drawing.Size(0, 16);
            this.StepperSpeed.TabIndex = 25;
            // 
            // buttonStopDC
            // 
            this.buttonStopDC.Location = new System.Drawing.Point(379, 62);
            this.buttonStopDC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonStopDC.Name = "buttonStopDC";
            this.buttonStopDC.Size = new System.Drawing.Size(75, 33);
            this.buttonStopDC.TabIndex = 26;
            this.buttonStopDC.Text = "Stop DC";
            this.buttonStopDC.UseVisualStyleBackColor = true;
            this.buttonStopDC.Click += new System.EventHandler(this.buttonStopDC_Click);
            // 
            // buttonStopStepper
            // 
            this.buttonStopStepper.Location = new System.Drawing.Point(460, 62);
            this.buttonStopStepper.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonStopStepper.Name = "buttonStopStepper";
            this.buttonStopStepper.Size = new System.Drawing.Size(100, 33);
            this.buttonStopStepper.TabIndex = 27;
            this.buttonStopStepper.Text = "Stop Stepper";
            this.buttonStopStepper.UseVisualStyleBackColor = true;
            this.buttonStopStepper.Click += new System.EventHandler(this.buttonStopStepper_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 457);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 16);
            this.label2.TabIndex = 28;
            this.label2.Text = "DC Motor Position:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 485);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 16);
            this.label3.TabIndex = 29;
            this.label3.Text = "DC Motor Speed:";
            // 
            // textBoxDCPosition
            // 
            this.textBoxDCPosition.Location = new System.Drawing.Point(151, 454);
            this.textBoxDCPosition.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDCPosition.Name = "textBoxDCPosition";
            this.textBoxDCPosition.Size = new System.Drawing.Size(132, 22);
            this.textBoxDCPosition.TabIndex = 30;
            // 
            // textBoxDCSpeedRPM
            // 
            this.textBoxDCSpeedRPM.Location = new System.Drawing.Point(151, 481);
            this.textBoxDCSpeedRPM.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDCSpeedRPM.Name = "textBoxDCSpeedRPM";
            this.textBoxDCSpeedRPM.Size = new System.Drawing.Size(132, 22);
            this.textBoxDCSpeedRPM.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(292, 457);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 16);
            this.label4.TabIndex = 32;
            this.label4.Text = "mm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(292, 485);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 16);
            this.label5.TabIndex = 33;
            this.label5.Text = "RPM";
            // 
            // chartPosSpeed
            // 
            chartArea1.AxisX.Title = "Time [ms]";
            chartArea1.AxisX2.Title = "Speed [RPM]";
            chartArea1.AxisY.Title = "Position [mm]";
            chartArea1.AxisY2.Title = "Speed [RPM]";
            chartArea1.Name = "ChartArea1";
            this.chartPosSpeed.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.chartPosSpeed.Legends.Add(legend1);
            this.chartPosSpeed.Location = new System.Drawing.Point(583, 15);
            this.chartPosSpeed.Margin = new System.Windows.Forms.Padding(4);
            this.chartPosSpeed.Name = "chartPosSpeed";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Position";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Speed";
            series2.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.chartPosSpeed.Series.Add(series1);
            this.chartPosSpeed.Series.Add(series2);
            this.chartPosSpeed.Size = new System.Drawing.Size(592, 623);
            this.chartPosSpeed.TabIndex = 34;
            title1.Name = "Title1";
            title1.Text = "Data Plotting - Position & Speed vs Time";
            this.chartPosSpeed.Titles.Add(title1);
            // 
            // timerWrite
            // 
            this.timerWrite.Tick += new System.EventHandler(this.timerWrite_Tick);
            // 
            // buttonClearChart
            // 
            this.buttonClearChart.Location = new System.Drawing.Point(609, 30);
            this.buttonClearChart.Name = "buttonClearChart";
            this.buttonClearChart.Size = new System.Drawing.Size(92, 23);
            this.buttonClearChart.TabIndex = 35;
            this.buttonClearChart.Text = "Clear Chart";
            this.buttonClearChart.UseVisualStyleBackColor = true;
            this.buttonClearChart.Click += new System.EventHandler(this.buttonClearChart_Click);
            // 
            // textBoxDCSpeedHz
            // 
            this.textBoxDCSpeedHz.Location = new System.Drawing.Point(336, 481);
            this.textBoxDCSpeedHz.Name = "textBoxDCSpeedHz";
            this.textBoxDCSpeedHz.Size = new System.Drawing.Size(118, 22);
            this.textBoxDCSpeedHz.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(460, 484);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 16);
            this.label6.TabIndex = 37;
            this.label6.Text = "Hz";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 507);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(286, 35);
            this.label7.TabIndex = 38;
            this.label7.Text = "X-Y POSITION CONTROL";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(16, 552);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(18, 16);
            this.labelX.TabIndex = 39;
            this.labelX.Text = "X:";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(183, 552);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(19, 16);
            this.labelY.TabIndex = 40;
            this.labelY.Text = "Y:";
            // 
            // textBoxXPos
            // 
            this.textBoxXPos.Location = new System.Drawing.Point(40, 549);
            this.textBoxXPos.Name = "textBoxXPos";
            this.textBoxXPos.Size = new System.Drawing.Size(100, 22);
            this.textBoxXPos.TabIndex = 41;
            this.textBoxXPos.Text = "0";
            // 
            // textBoxYPos
            // 
            this.textBoxYPos.Location = new System.Drawing.Point(207, 549);
            this.textBoxYPos.Name = "textBoxYPos";
            this.textBoxYPos.Size = new System.Drawing.Size(100, 22);
            this.textBoxYPos.TabIndex = 42;
            this.textBoxYPos.Text = "0";
            // 
            // buttonTransmitXY
            // 
            this.buttonTransmitXY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTransmitXY.Location = new System.Drawing.Point(350, 537);
            this.buttonTransmitXY.Name = "buttonTransmitXY";
            this.buttonTransmitXY.Size = new System.Drawing.Size(210, 40);
            this.buttonTransmitXY.TabIndex = 43;
            this.buttonTransmitXY.Text = "Transmit X-Y Position";
            this.buttonTransmitXY.UseVisualStyleBackColor = true;
            this.buttonTransmitXY.Click += new System.EventHandler(this.buttonTransmitXY_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(147, 552);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 16);
            this.label8.TabIndex = 44;
            this.label8.Text = "mm";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(314, 552);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 16);
            this.label9.TabIndex = 45;
            this.label9.Text = "mm";
            // 
            // buttonTransmitX
            // 
            this.buttonTransmitX.Location = new System.Drawing.Point(12, 577);
            this.buttonTransmitX.Name = "buttonTransmitX";
            this.buttonTransmitX.Size = new System.Drawing.Size(157, 32);
            this.buttonTransmitX.TabIndex = 46;
            this.buttonTransmitX.Text = "Transmit X Position";
            this.buttonTransmitX.UseVisualStyleBackColor = true;
            this.buttonTransmitX.Click += new System.EventHandler(this.buttonTransmitX_Click);
            // 
            // buttonTransmitY
            // 
            this.buttonTransmitY.Location = new System.Drawing.Point(186, 577);
            this.buttonTransmitY.Name = "buttonTransmitY";
            this.buttonTransmitY.Size = new System.Drawing.Size(157, 32);
            this.buttonTransmitY.TabIndex = 47;
            this.buttonTransmitY.Text = "Transmit Y Position";
            this.buttonTransmitY.UseVisualStyleBackColor = true;
            this.buttonTransmitY.Click += new System.EventHandler(this.buttonTransmitY_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 652);
            this.Controls.Add(this.buttonTransmitY);
            this.Controls.Add(this.buttonTransmitX);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.buttonTransmitXY);
            this.Controls.Add(this.textBoxYPos);
            this.Controls.Add(this.textBoxXPos);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxDCSpeedHz);
            this.Controls.Add(this.buttonClearChart);
            this.Controls.Add(this.chartPosSpeed);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxDCSpeedRPM);
            this.Controls.Add(this.textBoxDCPosition);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
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
            this.Controls.Add(this.textBoxUserConsole);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Motor Controller";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDCSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarStepperSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPosSpeed)).EndInit();
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
        private System.Windows.Forms.TextBox textBoxUserConsole;
        private System.Windows.Forms.Timer timerRead;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDCPosition;
        private System.Windows.Forms.TextBox textBoxDCSpeedRPM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPosSpeed;
        private System.Windows.Forms.Timer timerWrite;
        private System.Windows.Forms.Button buttonClearChart;
        private System.Windows.Forms.TextBox textBoxDCSpeedHz;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.TextBox textBoxXPos;
        private System.Windows.Forms.TextBox textBoxYPos;
        private System.Windows.Forms.Button buttonTransmitXY;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonTransmitX;
        private System.Windows.Forms.Button buttonTransmitY;
    }
}

