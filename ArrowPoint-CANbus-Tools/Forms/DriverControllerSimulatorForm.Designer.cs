namespace ArrowPointCANBusTool.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DriverControllerSimulatorForm));
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
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // btnReverse
            // 
            resources.ApplyResources(this.btnReverse, "btnReverse");
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.UseVisualStyleBackColor = true;
            this.btnReverse.Click += new System.EventHandler(this.BtnReverse_Click);
            // 
            // btnNeutral
            // 
            resources.ApplyResources(this.btnNeutral, "btnNeutral");
            this.btnNeutral.Name = "btnNeutral";
            this.btnNeutral.UseVisualStyleBackColor = true;
            this.btnNeutral.Click += new System.EventHandler(this.BtnNeutral_Click);
            // 
            // btnDrive
            // 
            resources.ApplyResources(this.btnDrive, "btnDrive");
            this.btnDrive.Name = "btnDrive";
            this.btnDrive.UseVisualStyleBackColor = true;
            this.btnDrive.Click += new System.EventHandler(this.BtnDrive_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSolarCruise);
            this.groupBox2.Controls.Add(this.btnSpeedCruise);
            this.groupBox2.Controls.Add(this.btnSetpointCruise);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // btnSolarCruise
            // 
            resources.ApplyResources(this.btnSolarCruise, "btnSolarCruise");
            this.btnSolarCruise.Name = "btnSolarCruise";
            this.btnSolarCruise.UseVisualStyleBackColor = true;
            this.btnSolarCruise.Click += new System.EventHandler(this.BtnSolarCruise_Click);
            // 
            // btnSpeedCruise
            // 
            resources.ApplyResources(this.btnSpeedCruise, "btnSpeedCruise");
            this.btnSpeedCruise.Name = "btnSpeedCruise";
            this.btnSpeedCruise.UseVisualStyleBackColor = true;
            this.btnSpeedCruise.Click += new System.EventHandler(this.BtnSpeedCruise_Click);
            // 
            // btnSetpointCruise
            // 
            resources.ApplyResources(this.btnSetpointCruise, "btnSetpointCruise");
            this.btnSetpointCruise.Name = "btnSetpointCruise";
            this.btnSetpointCruise.UseVisualStyleBackColor = true;
            this.btnSetpointCruise.Click += new System.EventHandler(this.BtnSetpointCruise_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.trackBarThrottle);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // trackBarThrottle
            // 
            resources.ApplyResources(this.trackBarThrottle, "trackBarThrottle");
            this.trackBarThrottle.Maximum = 100;
            this.trackBarThrottle.Name = "trackBarThrottle";
            this.trackBarThrottle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TrackBarThrottle_MouseUp);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.trackBarRegen);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // trackBarRegen
            // 
            resources.ApplyResources(this.trackBarRegen, "trackBarRegen");
            this.trackBarRegen.Maximum = 100;
            this.trackBarRegen.Name = "trackBarRegen";
            this.trackBarRegen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TrackBarRegen_MouseUp);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnRightIndicator);
            this.groupBox5.Controls.Add(this.btnLeftIndicator);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // btnRightIndicator
            // 
            resources.ApplyResources(this.btnRightIndicator, "btnRightIndicator");
            this.btnRightIndicator.Name = "btnRightIndicator";
            this.btnRightIndicator.UseVisualStyleBackColor = true;
            this.btnRightIndicator.Click += new System.EventHandler(this.BtnRightIndicator_Click);
            // 
            // btnLeftIndicator
            // 
            resources.ApplyResources(this.btnLeftIndicator, "btnLeftIndicator");
            this.btnLeftIndicator.Name = "btnLeftIndicator";
            this.btnLeftIndicator.UseVisualStyleBackColor = true;
            this.btnLeftIndicator.Click += new System.EventHandler(this.BtnLeftIndicator_Click);
            // 
            // Cruise
            // 
            this.Cruise.Controls.Add(this.btnCruiseDecrease);
            this.Cruise.Controls.Add(this.btnCruiseIncrease);
            this.Cruise.Controls.Add(this.btnCruiseDeactivate);
            this.Cruise.Controls.Add(this.btnCruiseActivate);
            resources.ApplyResources(this.Cruise, "Cruise");
            this.Cruise.Name = "Cruise";
            this.Cruise.TabStop = false;
            // 
            // btnCruiseDecrease
            // 
            resources.ApplyResources(this.btnCruiseDecrease, "btnCruiseDecrease");
            this.btnCruiseDecrease.Name = "btnCruiseDecrease";
            this.btnCruiseDecrease.UseVisualStyleBackColor = true;
            this.btnCruiseDecrease.Click += new System.EventHandler(this.BtnCruiseDecrease_Click);
            // 
            // btnCruiseIncrease
            // 
            resources.ApplyResources(this.btnCruiseIncrease, "btnCruiseIncrease");
            this.btnCruiseIncrease.Name = "btnCruiseIncrease";
            this.btnCruiseIncrease.UseVisualStyleBackColor = true;
            this.btnCruiseIncrease.Click += new System.EventHandler(this.BtnCruiseIncrease_Click);
            // 
            // btnCruiseDeactivate
            // 
            resources.ApplyResources(this.btnCruiseDeactivate, "btnCruiseDeactivate");
            this.btnCruiseDeactivate.Name = "btnCruiseDeactivate";
            this.btnCruiseDeactivate.UseVisualStyleBackColor = true;
            this.btnCruiseDeactivate.Click += new System.EventHandler(this.BtnCruiseDeactivate_Click);
            // 
            // btnCruiseActivate
            // 
            resources.ApplyResources(this.btnCruiseActivate, "btnCruiseActivate");
            this.btnCruiseActivate.Name = "btnCruiseActivate";
            this.btnCruiseActivate.UseVisualStyleBackColor = true;
            this.btnCruiseActivate.Click += new System.EventHandler(this.BtnCruiseActivate_Click);
            // 
            // DriverControllerSimulatorForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Cruise);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DriverControllerSimulatorForm";
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