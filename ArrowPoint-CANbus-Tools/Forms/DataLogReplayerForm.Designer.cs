namespace ArrowPointCANBusTool.Forms
{
    partial class DataLogReplayerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataLogReplayerForm));
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbFilterTo = new System.Windows.Forms.TextBox();
            this.toLbl = new System.Windows.Forms.Label();
            this.fromLbl = new System.Windows.Forms.Label();
            this.tbFilterFrom = new System.Windows.Forms.TextBox();
            this.lblDataSelection = new System.Windows.Forms.Label();
            this.rbIdExclude = new System.Windows.Forms.RadioButton();
            this.rbIdInclude = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(210, 224);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(154, 58);
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(12, 224);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(154, 58);
            this.btnStartStop.TabIndex = 6;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbFilterTo);
            this.groupBox1.Controls.Add(this.toLbl);
            this.groupBox1.Controls.Add(this.fromLbl);
            this.groupBox1.Controls.Add(this.tbFilterFrom);
            this.groupBox1.Controls.Add(this.lblDataSelection);
            this.groupBox1.Controls.Add(this.rbIdExclude);
            this.groupBox1.Controls.Add(this.rbIdInclude);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(352, 204);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Replayer Settings";
            // 
            // tbFilterTo
            // 
            this.tbFilterTo.Location = new System.Drawing.Point(161, 160);
            this.tbFilterTo.Margin = new System.Windows.Forms.Padding(4);
            this.tbFilterTo.Name = "tbFilterTo";
            this.tbFilterTo.Size = new System.Drawing.Size(121, 29);
            this.tbFilterTo.TabIndex = 12;
            // 
            // toLbl
            // 
            this.toLbl.AutoSize = true;
            this.toLbl.Location = new System.Drawing.Point(111, 164);
            this.toLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.toLbl.Name = "toLbl";
            this.toLbl.Size = new System.Drawing.Size(36, 25);
            this.toLbl.TabIndex = 11;
            this.toLbl.Text = "To";
            // 
            // fromLbl
            // 
            this.fromLbl.AutoSize = true;
            this.fromLbl.Location = new System.Drawing.Point(90, 116);
            this.fromLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fromLbl.Name = "fromLbl";
            this.fromLbl.Size = new System.Drawing.Size(57, 25);
            this.fromLbl.TabIndex = 10;
            this.fromLbl.Text = "From";
            // 
            // tbFilterFrom
            // 
            this.tbFilterFrom.Location = new System.Drawing.Point(161, 112);
            this.tbFilterFrom.Margin = new System.Windows.Forms.Padding(4);
            this.tbFilterFrom.Name = "tbFilterFrom";
            this.tbFilterFrom.Size = new System.Drawing.Size(121, 29);
            this.tbFilterFrom.TabIndex = 9;
            // 
            // lblDataSelection
            // 
            this.lblDataSelection.Location = new System.Drawing.Point(90, 38);
            this.lblDataSelection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataSelection.Name = "lblDataSelection";
            this.lblDataSelection.Size = new System.Drawing.Size(57, 28);
            this.lblDataSelection.TabIndex = 8;
            this.lblDataSelection.Text = "Filter";
            // 
            // rbIdExclude
            // 
            this.rbIdExclude.AutoSize = true;
            this.rbIdExclude.Location = new System.Drawing.Point(161, 75);
            this.rbIdExclude.Margin = new System.Windows.Forms.Padding(4);
            this.rbIdExclude.Name = "rbIdExclude";
            this.rbIdExclude.Size = new System.Drawing.Size(141, 29);
            this.rbIdExclude.TabIndex = 7;
            this.rbIdExclude.TabStop = true;
            this.rbIdExclude.Text = "Exclude IDs";
            this.rbIdExclude.UseVisualStyleBackColor = true;
            // 
            // rbIdInclude
            // 
            this.rbIdInclude.AutoSize = true;
            this.rbIdInclude.Location = new System.Drawing.Point(161, 38);
            this.rbIdInclude.Margin = new System.Windows.Forms.Padding(4);
            this.rbIdInclude.Name = "rbIdInclude";
            this.rbIdInclude.Size = new System.Drawing.Size(134, 29);
            this.rbIdInclude.TabIndex = 6;
            this.rbIdInclude.TabStop = true;
            this.rbIdInclude.Text = "Include IDs";
            this.rbIdInclude.UseVisualStyleBackColor = true;
            // 
            // DataLogReplayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 291);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStartStop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataLogReplayerForm";
            this.Text = "Log Replayer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDataSelection;
        private System.Windows.Forms.RadioButton rbIdExclude;
        private System.Windows.Forms.RadioButton rbIdInclude;
        private System.Windows.Forms.TextBox tbFilterTo;
        private System.Windows.Forms.Label toLbl;
        private System.Windows.Forms.Label fromLbl;
        private System.Windows.Forms.TextBox tbFilterFrom;
    }
}