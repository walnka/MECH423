
namespace Mech423Lab1Exercise4
{
    partial class InputSelection
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.User1InputChoice = new System.Windows.Forms.ComboBox();
            this.User2InputChoice = new System.Windows.Forms.ComboBox();
            this.User1UpButton = new System.Windows.Forms.Button();
            this.User1InputCOMPortChoice = new System.Windows.Forms.ComboBox();
            this.User2InputCOMPortChoice = new System.Windows.Forms.ComboBox();
            this.User1LeftButton = new System.Windows.Forms.Button();
            this.User1RightButton = new System.Windows.Forms.Button();
            this.User1DownButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.InputTimer = new System.Windows.Forms.Timer(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.User2DownButton = new System.Windows.Forms.Button();
            this.User2RightButton = new System.Windows.Forms.Button();
            this.User2LeftButton = new System.Windows.Forms.Button();
            this.User2UpButton = new System.Windows.Forms.Button();
            this.p1Ready = new System.Windows.Forms.CheckBox();
            this.p2Ready = new System.Windows.Forms.CheckBox();
            this.p1ConnectCheck = new System.Windows.Forms.CheckBox();
            this.p2ConnectCheck = new System.Windows.Forms.CheckBox();
            this.drawingModeCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player 1 Input";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(303, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Player 2 Input";
            // 
            // User1InputChoice
            // 
            this.User1InputChoice.AllowDrop = true;
            this.User1InputChoice.FormattingEnabled = true;
            this.User1InputChoice.Items.AddRange(new object[] {
            "Keyboard",
            "Controller"});
            this.User1InputChoice.Location = new System.Drawing.Point(70, 78);
            this.User1InputChoice.Name = "User1InputChoice";
            this.User1InputChoice.Size = new System.Drawing.Size(121, 24);
            this.User1InputChoice.TabIndex = 2;
            this.User1InputChoice.TextChanged += new System.EventHandler(this.User1InputChoice_TextChanged);
            // 
            // User2InputChoice
            // 
            this.User2InputChoice.AllowDrop = true;
            this.User2InputChoice.FormattingEnabled = true;
            this.User2InputChoice.Items.AddRange(new object[] {
            "Keyboard",
            "Controller"});
            this.User2InputChoice.Location = new System.Drawing.Point(329, 78);
            this.User2InputChoice.Name = "User2InputChoice";
            this.User2InputChoice.Size = new System.Drawing.Size(121, 24);
            this.User2InputChoice.TabIndex = 3;
            this.User2InputChoice.TextChanged += new System.EventHandler(this.User2InputChoice_TextChanged);
            // 
            // User1UpButton
            // 
            this.User1UpButton.Location = new System.Drawing.Point(102, 174);
            this.User1UpButton.Name = "User1UpButton";
            this.User1UpButton.Size = new System.Drawing.Size(60, 60);
            this.User1UpButton.TabIndex = 4;
            this.User1UpButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.User1UpButton.UseVisualStyleBackColor = true;
            this.User1UpButton.Click += new System.EventHandler(this.User1UpButton_Click);
            this.User1UpButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.User1UpButton_KeyDown);
            // 
            // User1InputCOMPortChoice
            // 
            this.User1InputCOMPortChoice.AllowDrop = true;
            this.User1InputCOMPortChoice.Enabled = false;
            this.User1InputCOMPortChoice.FormattingEnabled = true;
            this.User1InputCOMPortChoice.Location = new System.Drawing.Point(70, 108);
            this.User1InputCOMPortChoice.Name = "User1InputCOMPortChoice";
            this.User1InputCOMPortChoice.Size = new System.Drawing.Size(121, 24);
            this.User1InputCOMPortChoice.TabIndex = 5;
            // 
            // User2InputCOMPortChoice
            // 
            this.User2InputCOMPortChoice.AllowDrop = true;
            this.User2InputCOMPortChoice.Enabled = false;
            this.User2InputCOMPortChoice.FormattingEnabled = true;
            this.User2InputCOMPortChoice.Location = new System.Drawing.Point(329, 108);
            this.User2InputCOMPortChoice.Name = "User2InputCOMPortChoice";
            this.User2InputCOMPortChoice.Size = new System.Drawing.Size(121, 24);
            this.User2InputCOMPortChoice.TabIndex = 6;
            // 
            // User1LeftButton
            // 
            this.User1LeftButton.Location = new System.Drawing.Point(40, 233);
            this.User1LeftButton.Name = "User1LeftButton";
            this.User1LeftButton.Size = new System.Drawing.Size(60, 60);
            this.User1LeftButton.TabIndex = 8;
            this.User1LeftButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.User1LeftButton.UseVisualStyleBackColor = true;
            this.User1LeftButton.Click += new System.EventHandler(this.User1LeftButton_Click);
            this.User1LeftButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.User1LeftButton_KeyDown);
            // 
            // User1RightButton
            // 
            this.User1RightButton.Location = new System.Drawing.Point(163, 233);
            this.User1RightButton.Name = "User1RightButton";
            this.User1RightButton.Size = new System.Drawing.Size(60, 60);
            this.User1RightButton.TabIndex = 9;
            this.User1RightButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.User1RightButton.UseVisualStyleBackColor = true;
            this.User1RightButton.Click += new System.EventHandler(this.User1RightButton_Click);
            this.User1RightButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.User1RightButton_KeyDown);
            // 
            // User1DownButton
            // 
            this.User1DownButton.Location = new System.Drawing.Point(102, 293);
            this.User1DownButton.Name = "User1DownButton";
            this.User1DownButton.Size = new System.Drawing.Size(60, 60);
            this.User1DownButton.TabIndex = 10;
            this.User1DownButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.User1DownButton.UseVisualStyleBackColor = true;
            this.User1DownButton.Click += new System.EventHandler(this.User1DownButton_Click);
            this.User1DownButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.User1DownButton_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(117, 179);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "UP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(51, 237);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "LEFT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(169, 240);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "RIGHT";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(107, 297);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "DOWN";
            // 
            // InputTimer
            // 
            this.InputTimer.Interval = 2000;
            this.InputTimer.Tick += new System.EventHandler(this.InputTimer_Tick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(363, 297);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 15);
            this.label7.TabIndex = 22;
            this.label7.Text = "DOWN";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(424, 240);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 15);
            this.label8.TabIndex = 21;
            this.label8.Text = "RIGHT";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(305, 237);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 15);
            this.label9.TabIndex = 20;
            this.label9.Text = "LEFT";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(375, 179);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 15);
            this.label10.TabIndex = 19;
            this.label10.Text = "UP";
            // 
            // User2DownButton
            // 
            this.User2DownButton.Location = new System.Drawing.Point(357, 293);
            this.User2DownButton.Name = "User2DownButton";
            this.User2DownButton.Size = new System.Drawing.Size(60, 60);
            this.User2DownButton.TabIndex = 18;
            this.User2DownButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.User2DownButton.UseVisualStyleBackColor = true;
            this.User2DownButton.Click += new System.EventHandler(this.User2DownButton_Click);
            this.User2DownButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.User2DownButton_KeyDown);
            // 
            // User2RightButton
            // 
            this.User2RightButton.Location = new System.Drawing.Point(418, 233);
            this.User2RightButton.Name = "User2RightButton";
            this.User2RightButton.Size = new System.Drawing.Size(60, 60);
            this.User2RightButton.TabIndex = 17;
            this.User2RightButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.User2RightButton.UseVisualStyleBackColor = true;
            this.User2RightButton.Click += new System.EventHandler(this.User2RightButton_Click);
            this.User2RightButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.User2RightButton_KeyDown);
            // 
            // User2LeftButton
            // 
            this.User2LeftButton.Location = new System.Drawing.Point(295, 233);
            this.User2LeftButton.Name = "User2LeftButton";
            this.User2LeftButton.Size = new System.Drawing.Size(60, 60);
            this.User2LeftButton.TabIndex = 16;
            this.User2LeftButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.User2LeftButton.UseVisualStyleBackColor = true;
            this.User2LeftButton.Click += new System.EventHandler(this.User2LeftButton_Click);
            this.User2LeftButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.User2LeftButton_KeyDown);
            // 
            // User2UpButton
            // 
            this.User2UpButton.Location = new System.Drawing.Point(357, 174);
            this.User2UpButton.Name = "User2UpButton";
            this.User2UpButton.Size = new System.Drawing.Size(60, 60);
            this.User2UpButton.TabIndex = 15;
            this.User2UpButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.User2UpButton.UseVisualStyleBackColor = true;
            this.User2UpButton.Click += new System.EventHandler(this.User2UpButton_Click);
            this.User2UpButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.User2UpButton_KeyDown);
            // 
            // p1Ready
            // 
            this.p1Ready.AutoSize = true;
            this.p1Ready.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.p1Ready.Location = new System.Drawing.Point(100, 242);
            this.p1Ready.Margin = new System.Windows.Forms.Padding(0);
            this.p1Ready.Name = "p1Ready";
            this.p1Ready.Size = new System.Drawing.Size(59, 38);
            this.p1Ready.TabIndex = 23;
            this.p1Ready.Text = "READY";
            this.p1Ready.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.p1Ready.UseVisualStyleBackColor = true;
            this.p1Ready.CheckedChanged += new System.EventHandler(this.p1Ready_CheckedChanged);
            // 
            // p2Ready
            // 
            this.p2Ready.AutoSize = true;
            this.p2Ready.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.p2Ready.Location = new System.Drawing.Point(356, 242);
            this.p2Ready.Margin = new System.Windows.Forms.Padding(0);
            this.p2Ready.Name = "p2Ready";
            this.p2Ready.Size = new System.Drawing.Size(59, 38);
            this.p2Ready.TabIndex = 24;
            this.p2Ready.Text = "READY";
            this.p2Ready.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.p2Ready.UseVisualStyleBackColor = true;
            this.p2Ready.CheckedChanged += new System.EventHandler(this.p2Ready_CheckedChanged);
            // 
            // p1ConnectCheck
            // 
            this.p1ConnectCheck.AutoSize = true;
            this.p1ConnectCheck.Enabled = false;
            this.p1ConnectCheck.Location = new System.Drawing.Point(90, 138);
            this.p1ConnectCheck.Name = "p1ConnectCheck";
            this.p1ConnectCheck.Size = new System.Drawing.Size(82, 21);
            this.p1ConnectCheck.TabIndex = 25;
            this.p1ConnectCheck.Text = "Connect";
            this.p1ConnectCheck.UseVisualStyleBackColor = true;
            this.p1ConnectCheck.CheckedChanged += new System.EventHandler(this.p1ConnectCheck_CheckedChanged);
            // 
            // p2ConnectCheck
            // 
            this.p2ConnectCheck.AutoSize = true;
            this.p2ConnectCheck.Enabled = false;
            this.p2ConnectCheck.Location = new System.Drawing.Point(346, 138);
            this.p2ConnectCheck.Name = "p2ConnectCheck";
            this.p2ConnectCheck.Size = new System.Drawing.Size(82, 21);
            this.p2ConnectCheck.TabIndex = 26;
            this.p2ConnectCheck.Text = "Connect";
            this.p2ConnectCheck.UseVisualStyleBackColor = true;
            this.p2ConnectCheck.CheckedChanged += new System.EventHandler(this.p2ConnectCheck_CheckedChanged);
            // 
            // drawingModeCheck
            // 
            this.drawingModeCheck.AutoSize = true;
            this.drawingModeCheck.Location = new System.Drawing.Point(203, 339);
            this.drawingModeCheck.Name = "drawingModeCheck";
            this.drawingModeCheck.Size = new System.Drawing.Size(120, 21);
            this.drawingModeCheck.TabIndex = 27;
            this.drawingModeCheck.Text = "Drawing Mode";
            this.drawingModeCheck.UseVisualStyleBackColor = true;
            // 
            // InputSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(546, 372);
            this.Controls.Add(this.drawingModeCheck);
            this.Controls.Add(this.p2ConnectCheck);
            this.Controls.Add(this.p1ConnectCheck);
            this.Controls.Add(this.p2Ready);
            this.Controls.Add(this.p1Ready);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.User2DownButton);
            this.Controls.Add(this.User2RightButton);
            this.Controls.Add(this.User2LeftButton);
            this.Controls.Add(this.User2UpButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.User1DownButton);
            this.Controls.Add(this.User1RightButton);
            this.Controls.Add(this.User1LeftButton);
            this.Controls.Add(this.User2InputCOMPortChoice);
            this.Controls.Add(this.User1InputCOMPortChoice);
            this.Controls.Add(this.User1UpButton);
            this.Controls.Add(this.User2InputChoice);
            this.Controls.Add(this.User1InputChoice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "InputSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Input Selection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox User1InputChoice;
        private System.Windows.Forms.ComboBox User2InputChoice;
        private System.Windows.Forms.Button User1UpButton;
        private System.Windows.Forms.ComboBox User1InputCOMPortChoice;
        private System.Windows.Forms.ComboBox User2InputCOMPortChoice;
        private System.Windows.Forms.Button User1LeftButton;
        private System.Windows.Forms.Button User1RightButton;
        private System.Windows.Forms.Button User1DownButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button User2DownButton;
        private System.Windows.Forms.Button User2RightButton;
        private System.Windows.Forms.Button User2LeftButton;
        private System.Windows.Forms.Button User2UpButton;
        public System.Windows.Forms.Timer InputTimer;
        private System.Windows.Forms.CheckBox p1ConnectCheck;
        private System.Windows.Forms.CheckBox p2ConnectCheck;
        public System.Windows.Forms.CheckBox p1Ready;
        public System.Windows.Forms.CheckBox p2Ready;
        public System.Windows.Forms.CheckBox drawingModeCheck;
    }
}