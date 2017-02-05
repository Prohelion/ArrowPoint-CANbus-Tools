namespace ArrowWareDiagnosticTool.Forms
{
    partial class DriverControllerSimulatorForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReverse = new System.Windows.Forms.Button();
            this.btnNeutral = new System.Windows.Forms.Button();
            this.btnDrive = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSolarCruise = new System.Windows.Forms.Button();
            this.btnSpeedCruise = new System.Windows.Forms.Button();
            this.btnSetpointCruise = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.trackBarThrottle = new System.Windows.Forms.TrackBar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.trackBarRegen = new System.Windows.Forms.TrackBar();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnRightIndicator = new System.Windows.Forms.Button();
            this.btnLeftIndicator = new System.Windows.Forms.Button();
            this.Cruise = new System.Windows.Forms.GroupBox();
            this.btnCruiseDecrease = new System.Windows.Forms.Button();
            this.btnCruiseIncrease = new System.Windows.Forms.Button();
            this.btnCruiseDeactivate = new System.Windows.Forms.Button();
            this.btnCruiseActivate = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThrottle)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRegen)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.Cruise.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReverse);
            this.groupBox1.Controls.Add(this.btnNeutral);
            this.groupBox1.Controls.Add(this.btnDrive);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 236);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Drive Mode";
            // 
            // btnReverse
            // 
            this.btnReverse.Location = new System.Drawing.Point(5, 164);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(150, 65);
            this.btnReverse.TabIndex = 2;
            this.btnReverse.Text = "Reverse";
            this.btnReverse.UseVisualStyleBackColor = true;
            this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
            // 
            // btnNeutral
            // 
            this.btnNeutral.Location = new System.Drawing.Point(5, 96);
            this.btnNeutral.Name = "btnNeutral";
            this.btnNeutral.Size = new System.Drawing.Size(150, 65);
            this.btnNeutral.TabIndex = 1;
            this.btnNeutral.Text = "Neutral";
            this.btnNeutral.UseVisualStyleBackColor = true;
            this.btnNeutral.Click += new System.EventHandler(this.btnNeutral_Click);
            // 
            // btnDrive
            // 
            this.btnDrive.Location = new System.Drawing.Point(5, 28);
            this.btnDrive.Name = "btnDrive";
            this.btnDrive.Size = new System.Drawing.Size(150, 65);
            this.btnDrive.TabIndex = 0;
            this.btnDrive.Text = "Drive";
            this.btnDrive.UseVisualStyleBackColor = true;
            this.btnDrive.Click += new System.EventHandler(this.btnDrive_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSolarCruise);
            this.groupBox2.Controls.Add(this.btnSpeedCruise);
            this.groupBox2.Controls.Add(this.btnSetpointCruise);
            this.groupBox2.Location = new System.Drawing.Point(497, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(160, 236);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cruise Mode";
            // 
            // btnSolarCruise
            // 
            this.btnSolarCruise.Location = new System.Drawing.Point(5, 164);
            this.btnSolarCruise.Name = "btnSolarCruise";
            this.btnSolarCruise.Size = new System.Drawing.Size(150, 65);
            this.btnSolarCruise.TabIndex = 2;
            this.btnSolarCruise.Text = "Solar";
            this.btnSolarCruise.UseVisualStyleBackColor = true;
            this.btnSolarCruise.Click += new System.EventHandler(this.btnSolarCruise_Click);
            // 
            // btnSpeedCruise
            // 
            this.btnSpeedCruise.Location = new System.Drawing.Point(5, 96);
            this.btnSpeedCruise.Name = "btnSpeedCruise";
            this.btnSpeedCruise.Size = new System.Drawing.Size(150, 65);
            this.btnSpeedCruise.TabIndex = 1;
            this.btnSpeedCruise.Text = "Speed";
            this.btnSpeedCruise.UseVisualStyleBackColor = true;
            this.btnSpeedCruise.Click += new System.EventHandler(this.btnSpeedCruise_Click);
            // 
            // btnSetpointCruise
            // 
            this.btnSetpointCruise.Location = new System.Drawing.Point(5, 28);
            this.btnSetpointCruise.Name = "btnSetpointCruise";
            this.btnSetpointCruise.Size = new System.Drawing.Size(150, 65);
            this.btnSetpointCruise.TabIndex = 0;
            this.btnSetpointCruise.Text = "Setpoint";
            this.btnSetpointCruise.UseVisualStyleBackColor = true;
            this.btnSetpointCruise.Click += new System.EventHandler(this.btnSetpointCruise_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.trackBarThrottle);
            this.groupBox3.Location = new System.Drawing.Point(179, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(312, 115);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Throttle";
            // 
            // trackBarThrottle
            // 
            this.trackBarThrottle.Location = new System.Drawing.Point(6, 28);
            this.trackBarThrottle.Maximum = 100;
            this.trackBarThrottle.Name = "trackBarThrottle";
            this.trackBarThrottle.Size = new System.Drawing.Size(300, 80);
            this.trackBarThrottle.TabIndex = 0;
            this.trackBarThrottle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarThrottle_MouseUp);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.trackBarRegen);
            this.groupBox4.Location = new System.Drawing.Point(179, 134);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(312, 115);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Regen";
            // 
            // trackBarRegen
            // 
            this.trackBarRegen.Location = new System.Drawing.Point(6, 28);
            this.trackBarRegen.Maximum = 100;
            this.trackBarRegen.Name = "trackBarRegen";
            this.trackBarRegen.Size = new System.Drawing.Size(300, 80);
            this.trackBarRegen.TabIndex = 0;
            this.trackBarRegen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarRegen_MouseUp);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnRightIndicator);
            this.groupBox5.Controls.Add(this.btnLeftIndicator);
            this.groupBox5.Location = new System.Drawing.Point(18, 255);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(312, 100);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Indicators";
            // 
            // btnRightIndicator
            // 
            this.btnRightIndicator.Location = new System.Drawing.Point(161, 28);
            this.btnRightIndicator.Name = "btnRightIndicator";
            this.btnRightIndicator.Size = new System.Drawing.Size(150, 65);
            this.btnRightIndicator.TabIndex = 1;
            this.btnRightIndicator.Text = "Right";
            this.btnRightIndicator.UseVisualStyleBackColor = true;
            this.btnRightIndicator.Click += new System.EventHandler(this.btnRightIndicator_Click);
            // 
            // btnLeftIndicator
            // 
            this.btnLeftIndicator.Location = new System.Drawing.Point(5, 28);
            this.btnLeftIndicator.Name = "btnLeftIndicator";
            this.btnLeftIndicator.Size = new System.Drawing.Size(150, 65);
            this.btnLeftIndicator.TabIndex = 0;
            this.btnLeftIndicator.Text = "Left";
            this.btnLeftIndicator.UseVisualStyleBackColor = true;
            this.btnLeftIndicator.Click += new System.EventHandler(this.btnLeftIndicator_Click);
            // 
            // Cruise
            // 
            this.Cruise.Controls.Add(this.btnCruiseDecrease);
            this.Cruise.Controls.Add(this.btnCruiseIncrease);
            this.Cruise.Controls.Add(this.btnCruiseDeactivate);
            this.Cruise.Controls.Add(this.btnCruiseActivate);
            this.Cruise.Location = new System.Drawing.Point(336, 255);
            this.Cruise.Name = "Cruise";
            this.Cruise.Size = new System.Drawing.Size(321, 170);
            this.Cruise.TabIndex = 5;
            this.Cruise.TabStop = false;
            this.Cruise.Text = "Cruise";
            // 
            // btnCruiseDecrease
            // 
            this.btnCruiseDecrease.Location = new System.Drawing.Point(165, 99);
            this.btnCruiseDecrease.Name = "btnCruiseDecrease";
            this.btnCruiseDecrease.Size = new System.Drawing.Size(150, 65);
            this.btnCruiseDecrease.TabIndex = 3;
            this.btnCruiseDecrease.Text = "Decrease";
            this.btnCruiseDecrease.UseVisualStyleBackColor = true;
            this.btnCruiseDecrease.Click += new System.EventHandler(this.btnCruiseDecrease_Click);
            // 
            // btnCruiseIncrease
            // 
            this.btnCruiseIncrease.Location = new System.Drawing.Point(5, 99);
            this.btnCruiseIncrease.Name = "btnCruiseIncrease";
            this.btnCruiseIncrease.Size = new System.Drawing.Size(150, 65);
            this.btnCruiseIncrease.TabIndex = 2;
            this.btnCruiseIncrease.Text = "Increase";
            this.btnCruiseIncrease.UseVisualStyleBackColor = true;
            this.btnCruiseIncrease.Click += new System.EventHandler(this.btnCruiseIncrease_Click);
            // 
            // btnCruiseDeactivate
            // 
            this.btnCruiseDeactivate.Location = new System.Drawing.Point(165, 28);
            this.btnCruiseDeactivate.Name = "btnCruiseDeactivate";
            this.btnCruiseDeactivate.Size = new System.Drawing.Size(150, 65);
            this.btnCruiseDeactivate.TabIndex = 1;
            this.btnCruiseDeactivate.Text = "Deactivate";
            this.btnCruiseDeactivate.UseVisualStyleBackColor = true;
            this.btnCruiseDeactivate.Click += new System.EventHandler(this.btnCruiseDeactivate_Click);
            // 
            // btnCruiseActivate
            // 
            this.btnCruiseActivate.Location = new System.Drawing.Point(5, 28);
            this.btnCruiseActivate.Name = "btnCruiseActivate";
            this.btnCruiseActivate.Size = new System.Drawing.Size(150, 65);
            this.btnCruiseActivate.TabIndex = 0;
            this.btnCruiseActivate.Text = "Activate";
            this.btnCruiseActivate.UseVisualStyleBackColor = true;
            this.btnCruiseActivate.Click += new System.EventHandler(this.btnCruiseActivate_Click);
            // 
            // DriverControllerSimulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 437);
            this.Controls.Add(this.Cruise);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "DriverControllerSimulatorForm";
            this.Text = "DriverControllerSimulatorForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThrottle)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRegen)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.Cruise.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.Button btnNeutral;
        private System.Windows.Forms.Button btnDrive;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSolarCruise;
        private System.Windows.Forms.Button btnSpeedCruise;
        private System.Windows.Forms.Button btnSetpointCruise;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TrackBar trackBarThrottle;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TrackBar trackBarRegen;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnRightIndicator;
        private System.Windows.Forms.Button btnLeftIndicator;
        private System.Windows.Forms.GroupBox Cruise;
        private System.Windows.Forms.Button btnCruiseDecrease;
        private System.Windows.Forms.Button btnCruiseIncrease;
        private System.Windows.Forms.Button btnCruiseDeactivate;
        private System.Windows.Forms.Button btnCruiseActivate;
    }
}