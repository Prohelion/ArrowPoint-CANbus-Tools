namespace ArrowWareDiagnosticTool.Forms
{
    partial class DataLoggerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataLoggerForm));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDataSelection = new System.Windows.Forms.Label();
            this.rbDataParsed = new System.Windows.Forms.RadioButton();
            this.rbDataRaw = new System.Windows.Forms.RadioButton();
            this.btnStop = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(12, 140);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(154, 58);
            this.btnStartStop.TabIndex = 2;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDataSelection);
            this.groupBox1.Controls.Add(this.rbDataParsed);
            this.groupBox1.Controls.Add(this.rbDataRaw);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(352, 120);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Logger Settings";
            // 
            // lblDataSelection
            // 
            this.lblDataSelection.Location = new System.Drawing.Point(10, 37);
            this.lblDataSelection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataSelection.Name = "lblDataSelection";
            this.lblDataSelection.Size = new System.Drawing.Size(143, 28);
            this.lblDataSelection.TabIndex = 8;
            this.lblDataSelection.Text = "Data To Log";
            // 
            // rbDataParsed
            // 
            this.rbDataParsed.AutoSize = true;
            this.rbDataParsed.Location = new System.Drawing.Point(161, 75);
            this.rbDataParsed.Margin = new System.Windows.Forms.Padding(4);
            this.rbDataParsed.Name = "rbDataParsed";
            this.rbDataParsed.Size = new System.Drawing.Size(145, 29);
            this.rbDataParsed.TabIndex = 7;
            this.rbDataParsed.TabStop = true;
            this.rbDataParsed.Text = "Parsed Data";
            this.rbDataParsed.UseVisualStyleBackColor = true;
            this.rbDataParsed.CheckedChanged += new System.EventHandler(this.rbDataParsed_CheckedChanged);
            // 
            // rbDataRaw
            // 
            this.rbDataRaw.AutoSize = true;
            this.rbDataRaw.Location = new System.Drawing.Point(161, 38);
            this.rbDataRaw.Margin = new System.Windows.Forms.Padding(4);
            this.rbDataRaw.Name = "rbDataRaw";
            this.rbDataRaw.Size = new System.Drawing.Size(169, 29);
            this.rbDataRaw.TabIndex = 6;
            this.rbDataRaw.TabStop = true;
            this.rbDataRaw.Text = "Raw CAN Data";
            this.rbDataRaw.UseVisualStyleBackColor = true;
            this.rbDataRaw.CheckedChanged += new System.EventHandler(this.rbDataRaw_CheckedChanged);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(211, 140);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(154, 58);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // DataLoggerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 206);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnStartStop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataLoggerForm";
            this.Text = "Data Logger";
            this.Load += new System.EventHandler(this.DataLoggerForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbDataParsed;
        private System.Windows.Forms.RadioButton rbDataRaw;
        private System.Windows.Forms.Label lblDataSelection;
        private System.Windows.Forms.Button btnStop;
    }
}