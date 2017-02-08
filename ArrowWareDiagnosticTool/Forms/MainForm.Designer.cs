namespace ArrowWareDiagnosticTool
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canbusOverviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monitoringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rawDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendCanPacketsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataLoggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logReplayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simualtorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driverControllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.motorControllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dashboardToolStripMenuItem,
            this.monitoringToolStripMenuItem,
            this.simualtorsToolStripMenuItem,
            this.testingToolStripMenuItem,
            this.connectionSettingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1072, 38);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dashboardToolStripMenuItem
            // 
            this.dashboardToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.canbusOverviewToolStripMenuItem});
            this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            this.dashboardToolStripMenuItem.Size = new System.Drawing.Size(135, 34);
            this.dashboardToolStripMenuItem.Text = "Dashboards";
            // 
            // canbusOverviewToolStripMenuItem
            // 
            this.canbusOverviewToolStripMenuItem.Name = "canbusOverviewToolStripMenuItem";
            this.canbusOverviewToolStripMenuItem.Size = new System.Drawing.Size(265, 34);
            this.canbusOverviewToolStripMenuItem.Text = "Canbus Overview";
            this.canbusOverviewToolStripMenuItem.Click += new System.EventHandler(this.canbusOverviewToolStripMenuItem_Click);
            // 
            // monitoringToolStripMenuItem
            // 
            this.monitoringToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rawDataToolStripMenuItem,
            this.sendCanPacketsToolStripMenuItem,
            this.dataLoggerToolStripMenuItem,
            this.logReplayerToolStripMenuItem});
            this.monitoringToolStripMenuItem.Name = "monitoringToolStripMenuItem";
            this.monitoringToolStripMenuItem.Size = new System.Drawing.Size(72, 34);
            this.monitoringToolStripMenuItem.Text = "Tools";
            // 
            // rawDataToolStripMenuItem
            // 
            this.rawDataToolStripMenuItem.Name = "rawDataToolStripMenuItem";
            this.rawDataToolStripMenuItem.Size = new System.Drawing.Size(286, 34);
            this.rawDataToolStripMenuItem.Text = "Receive CanPackets";
            this.rawDataToolStripMenuItem.Click += new System.EventHandler(this.rawDataToolStripMenuItem_Click);
            // 
            // sendCanPacketsToolStripMenuItem
            // 
            this.sendCanPacketsToolStripMenuItem.Name = "sendCanPacketsToolStripMenuItem";
            this.sendCanPacketsToolStripMenuItem.Size = new System.Drawing.Size(286, 34);
            this.sendCanPacketsToolStripMenuItem.Text = "Send CanPackets";
            this.sendCanPacketsToolStripMenuItem.Click += new System.EventHandler(this.sendCanPacketsToolStripMenuItem_Click);
            // 
            // dataLoggerToolStripMenuItem
            // 
            this.dataLoggerToolStripMenuItem.Name = "dataLoggerToolStripMenuItem";
            this.dataLoggerToolStripMenuItem.Size = new System.Drawing.Size(286, 34);
            this.dataLoggerToolStripMenuItem.Text = "Data Logger";
            this.dataLoggerToolStripMenuItem.Click += new System.EventHandler(this.dataLoggerToolStripMenuItem_Click);
            // 
            // logReplayerToolStripMenuItem
            // 
            this.logReplayerToolStripMenuItem.Name = "logReplayerToolStripMenuItem";
            this.logReplayerToolStripMenuItem.Size = new System.Drawing.Size(286, 34);
            this.logReplayerToolStripMenuItem.Text = "Data Log Replayer";
            this.logReplayerToolStripMenuItem.Click += new System.EventHandler(this.logReplayerToolStripMenuItem_Click);
            // 
            // simualtorsToolStripMenuItem
            // 
            this.simualtorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.driverControllerToolStripMenuItem,
            this.motorControllerToolStripMenuItem});
            this.simualtorsToolStripMenuItem.Name = "simualtorsToolStripMenuItem";
            this.simualtorsToolStripMenuItem.Size = new System.Drawing.Size(122, 34);
            this.simualtorsToolStripMenuItem.Text = "Simualtors";
            // 
            // driverControllerToolStripMenuItem
            // 
            this.driverControllerToolStripMenuItem.Name = "driverControllerToolStripMenuItem";
            this.driverControllerToolStripMenuItem.Size = new System.Drawing.Size(259, 34);
            this.driverControllerToolStripMenuItem.Text = "Driver Controller";
            this.driverControllerToolStripMenuItem.Click += new System.EventHandler(this.driverControllerToolStripMenuItem_Click);
            // 
            // motorControllerToolStripMenuItem
            // 
            this.motorControllerToolStripMenuItem.Name = "motorControllerToolStripMenuItem";
            this.motorControllerToolStripMenuItem.Size = new System.Drawing.Size(259, 34);
            this.motorControllerToolStripMenuItem.Text = "Motor Controller";
            this.motorControllerToolStripMenuItem.Click += new System.EventHandler(this.motorControllerToolStripMenuItem_Click);
            // 
            // testingToolStripMenuItem
            // 
            this.testingToolStripMenuItem.Name = "testingToolStripMenuItem";
            this.testingToolStripMenuItem.Size = new System.Drawing.Size(70, 34);
            this.testingToolStripMenuItem.Text = "Tests";
            // 
            // connectionSettingsToolStripMenuItem
            // 
            this.connectionSettingsToolStripMenuItem.Name = "connectionSettingsToolStripMenuItem";
            this.connectionSettingsToolStripMenuItem.Size = new System.Drawing.Size(99, 34);
            this.connectionSettingsToolStripMenuItem.Text = "Settings";
            this.connectionSettingsToolStripMenuItem.Click += new System.EventHandler(this.connectionSettingsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(82, 34);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1072, 710);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.Text = "ArrowWare Diagnostic Tool";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem monitoringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rawDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendCanPacketsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simualtorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem motorControllerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem canbusOverviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem driverControllerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataLoggerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logReplayerToolStripMenuItem;
    }
}