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
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbIdNone = new System.Windows.Forms.RadioButton();
            this.tbFilterTo = new System.Windows.Forms.TextBox();
            this.toLbl = new System.Windows.Forms.Label();
            this.fromLbl = new System.Windows.Forms.Label();
            this.tbFilterFrom = new System.Windows.Forms.TextBox();
            this.lblDataSelection = new System.Windows.Forms.Label();
            this.rbIdExclude = new System.Windows.Forms.RadioButton();
            this.rbIdInclude = new System.Windows.Forms.RadioButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.checkBoxLoop = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(115, 178);
            this.btnStop.Margin = new System.Windows.Forms.Padding(2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(84, 31);
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(7, 178);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(84, 31);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Select Log";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbIdNone);
            this.groupBox1.Controls.Add(this.tbFilterTo);
            this.groupBox1.Controls.Add(this.toLbl);
            this.groupBox1.Controls.Add(this.fromLbl);
            this.groupBox1.Controls.Add(this.tbFilterFrom);
            this.groupBox1.Controls.Add(this.lblDataSelection);
            this.groupBox1.Controls.Add(this.rbIdExclude);
            this.groupBox1.Controls.Add(this.rbIdInclude);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(192, 144);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter Settings";
            // 
            // rbIdNone
            // 
            this.rbIdNone.AutoSize = true;
            this.rbIdNone.Checked = true;
            this.rbIdNone.Location = new System.Drawing.Point(105, 21);
            this.rbIdNone.Margin = new System.Windows.Forms.Padding(2);
            this.rbIdNone.Name = "rbIdNone";
            this.rbIdNone.Size = new System.Drawing.Size(51, 17);
            this.rbIdNone.TabIndex = 14;
            this.rbIdNone.TabStop = true;
            this.rbIdNone.Text = "None";
            this.rbIdNone.UseVisualStyleBackColor = true;
            this.rbIdNone.CheckedChanged += new System.EventHandler(this.RbIdNone_CheckedChanged);
            // 
            // tbFilterTo
            // 
            this.tbFilterTo.Location = new System.Drawing.Point(105, 107);
            this.tbFilterTo.Margin = new System.Windows.Forms.Padding(2);
            this.tbFilterTo.Name = "tbFilterTo";
            this.tbFilterTo.Size = new System.Drawing.Size(62, 20);
            this.tbFilterTo.TabIndex = 12;
            // 
            // toLbl
            // 
            this.toLbl.AutoSize = true;
            this.toLbl.Location = new System.Drawing.Point(39, 110);
            this.toLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.toLbl.Name = "toLbl";
            this.toLbl.Size = new System.Drawing.Size(62, 13);
            this.toLbl.TabIndex = 11;
            this.toLbl.Text = "To ID (Hex)";
            this.toLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fromLbl
            // 
            this.fromLbl.AutoSize = true;
            this.fromLbl.Location = new System.Drawing.Point(29, 86);
            this.fromLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fromLbl.Name = "fromLbl";
            this.fromLbl.Size = new System.Drawing.Size(72, 13);
            this.fromLbl.TabIndex = 10;
            this.fromLbl.Text = "From ID (Hex)";
            this.fromLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbFilterFrom
            // 
            this.tbFilterFrom.Location = new System.Drawing.Point(105, 83);
            this.tbFilterFrom.Margin = new System.Windows.Forms.Padding(2);
            this.tbFilterFrom.Name = "tbFilterFrom";
            this.tbFilterFrom.Size = new System.Drawing.Size(62, 20);
            this.tbFilterFrom.TabIndex = 9;
            // 
            // lblDataSelection
            // 
            this.lblDataSelection.Location = new System.Drawing.Point(37, 21);
            this.lblDataSelection.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDataSelection.Name = "lblDataSelection";
            this.lblDataSelection.Size = new System.Drawing.Size(64, 17);
            this.lblDataSelection.TabIndex = 8;
            this.lblDataSelection.Text = "Filter Type";
            this.lblDataSelection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rbIdExclude
            // 
            this.rbIdExclude.AutoSize = true;
            this.rbIdExclude.Location = new System.Drawing.Point(105, 62);
            this.rbIdExclude.Margin = new System.Windows.Forms.Padding(2);
            this.rbIdExclude.Name = "rbIdExclude";
            this.rbIdExclude.Size = new System.Drawing.Size(82, 17);
            this.rbIdExclude.TabIndex = 7;
            this.rbIdExclude.Text = "Exclude IDs";
            this.rbIdExclude.UseVisualStyleBackColor = true;
            this.rbIdExclude.CheckedChanged += new System.EventHandler(this.RbIdExclude_CheckedChanged);
            // 
            // rbIdInclude
            // 
            this.rbIdInclude.AutoSize = true;
            this.rbIdInclude.Location = new System.Drawing.Point(105, 41);
            this.rbIdInclude.Margin = new System.Windows.Forms.Padding(2);
            this.rbIdInclude.Name = "rbIdInclude";
            this.rbIdInclude.Size = new System.Drawing.Size(79, 17);
            this.rbIdInclude.TabIndex = 6;
            this.rbIdInclude.Text = "Include IDs";
            this.rbIdInclude.UseVisualStyleBackColor = true;
            this.rbIdInclude.CheckedChanged += new System.EventHandler(this.RbIdInclude_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusText});
            this.statusStrip1.Location = new System.Drawing.Point(0, 214);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(205, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "StatusStrip";
            // 
            // toolStripStatusText
            // 
            this.toolStripStatusText.Name = "toolStripStatusText";
            this.toolStripStatusText.Size = new System.Drawing.Size(26, 17);
            this.toolStripStatusText.Text = "Idle";
            // 
            // checkBoxLoop
            // 
            this.checkBoxLoop.AutoSize = true;
            this.checkBoxLoop.Location = new System.Drawing.Point(7, 156);
            this.checkBoxLoop.Name = "checkBoxLoop";
            this.checkBoxLoop.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxLoop.Size = new System.Drawing.Size(114, 17);
            this.checkBoxLoop.TabIndex = 14;
            this.checkBoxLoop.Text = "Loop replay log file";
            this.checkBoxLoop.UseVisualStyleBackColor = true;
            this.checkBoxLoop.CheckedChanged += new System.EventHandler(this.checkBoxLoop_CheckedChanged);
            // 
            // DataLogReplayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 236);
            this.Controls.Add(this.checkBoxLoop);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataLogReplayerForm";
            this.Text = "Log Replayer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataLogReplayerForm_FormClosing);
            this.Load += new System.EventHandler(this.DataLogReplayerForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDataSelection;
        private System.Windows.Forms.RadioButton rbIdExclude;
        private System.Windows.Forms.RadioButton rbIdInclude;
        private System.Windows.Forms.TextBox tbFilterTo;
        private System.Windows.Forms.Label toLbl;
        private System.Windows.Forms.Label fromLbl;
        private System.Windows.Forms.TextBox tbFilterFrom;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusText;
        private System.Windows.Forms.RadioButton rbIdNone;
        private System.Windows.Forms.CheckBox checkBoxLoop;
    }
}