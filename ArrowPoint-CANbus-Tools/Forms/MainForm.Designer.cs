namespace ArrowPointCANBusTool
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
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.connectedStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.batteryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batteryViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dashboardToolStripMenuItem,
            this.monitoringToolStripMenuItem,
            this.simualtorsToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.batteryMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1266, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dashboardToolStripMenuItem
            // 
            this.dashboardToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.canbusOverviewToolStripMenuItem});
            this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            this.dashboardToolStripMenuItem.Size = new System.Drawing.Size(81, 22);
            this.dashboardToolStripMenuItem.Text = "Dashboards";
            // 
            // canbusOverviewToolStripMenuItem
            // 
            this.canbusOverviewToolStripMenuItem.Name = "canbusOverviewToolStripMenuItem";
            this.canbusOverviewToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.canbusOverviewToolStripMenuItem.Text = "Canbus Overview";
            this.canbusOverviewToolStripMenuItem.Click += new System.EventHandler(this.CanbusOverviewToolStripMenuItem_Click);
            // 
            // monitoringToolStripMenuItem
            // 
            this.monitoringToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rawDataToolStripMenuItem,
            this.sendCanPacketsToolStripMenuItem,
            this.dataLoggerToolStripMenuItem,
            this.logReplayerToolStripMenuItem});
            this.monitoringToolStripMenuItem.Name = "monitoringToolStripMenuItem";
            this.monitoringToolStripMenuItem.Size = new System.Drawing.Size(47, 22);
            this.monitoringToolStripMenuItem.Text = "Tools";
            // 
            // rawDataToolStripMenuItem
            // 
            this.rawDataToolStripMenuItem.Name = "rawDataToolStripMenuItem";
            this.rawDataToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.rawDataToolStripMenuItem.Text = "Receive CanPackets";
            this.rawDataToolStripMenuItem.Click += new System.EventHandler(this.RawDataToolStripMenuItem_Click);
            // 
            // sendCanPacketsToolStripMenuItem
            // 
            this.sendCanPacketsToolStripMenuItem.Name = "sendCanPacketsToolStripMenuItem";
            this.sendCanPacketsToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.sendCanPacketsToolStripMenuItem.Text = "Send CanPackets";
            this.sendCanPacketsToolStripMenuItem.Click += new System.EventHandler(this.SendCanPacketsToolStripMenuItem_Click);
            // 
            // dataLoggerToolStripMenuItem
            // 
            this.dataLoggerToolStripMenuItem.Name = "dataLoggerToolStripMenuItem";
            this.dataLoggerToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.dataLoggerToolStripMenuItem.Text = "Data Logger";
            this.dataLoggerToolStripMenuItem.Click += new System.EventHandler(this.DataLoggerToolStripMenuItem_Click);
            // 
            // logReplayerToolStripMenuItem
            // 
            this.logReplayerToolStripMenuItem.Name = "logReplayerToolStripMenuItem";
            this.logReplayerToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.logReplayerToolStripMenuItem.Text = "Data Log Replayer";
            this.logReplayerToolStripMenuItem.Click += new System.EventHandler(this.LogReplayerToolStripMenuItem_Click);
            // 
            // simualtorsToolStripMenuItem
            // 
            this.simualtorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.driverControllerToolStripMenuItem,
            this.motorControllerToolStripMenuItem});
            this.simualtorsToolStripMenuItem.Name = "simualtorsToolStripMenuItem";
            this.simualtorsToolStripMenuItem.Size = new System.Drawing.Size(75, 22);
            this.simualtorsToolStripMenuItem.Text = "Simulators";
            // 
            // driverControllerToolStripMenuItem
            // 
            this.driverControllerToolStripMenuItem.Name = "driverControllerToolStripMenuItem";
            this.driverControllerToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.driverControllerToolStripMenuItem.Text = "Driver Controller";
            this.driverControllerToolStripMenuItem.Click += new System.EventHandler(this.DriverControllerToolStripMenuItem_Click);
            // 
            // motorControllerToolStripMenuItem
            // 
            this.motorControllerToolStripMenuItem.Name = "motorControllerToolStripMenuItem";
            this.motorControllerToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.motorControllerToolStripMenuItem.Text = "Motor Controller";
            this.motorControllerToolStripMenuItem.Click += new System.EventHandler(this.MotorControllerToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectedStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 477);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1266, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // connectedStatusLabel
            // 
            this.connectedStatusLabel.BackColor = System.Drawing.Color.Red;
            this.connectedStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.connectedStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectedStatusLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.connectedStatusLabel.Margin = new System.Windows.Forms.Padding(10, 3, 10, 2);
            this.connectedStatusLabel.Name = "connectedStatusLabel";
            this.connectedStatusLabel.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.connectedStatusLabel.Size = new System.Drawing.Size(111, 17);
            this.connectedStatusLabel.Text = "Not Connected";
            this.connectedStatusLabel.Click += new System.EventHandler(this.connectedStatusLabel_Click);
            // 
            // batteryMenuItem
            // 
            this.batteryMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.batteryViewerToolStripMenuItem});
            this.batteryMenuItem.Name = "batteryMenuItem";
            this.batteryMenuItem.Size = new System.Drawing.Size(56, 22);
            this.batteryMenuItem.Text = "Battery";
            // 
            // batteryViewerToolStripMenuItem
            // 
            this.batteryViewerToolStripMenuItem.Name = "batteryViewerToolStripMenuItem";
            this.batteryViewerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.batteryViewerToolStripMenuItem.Text = "Battery Viewer";
            this.batteryViewerToolStripMenuItem.Click += new System.EventHandler(this.batteryViewerToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1266, 499);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.Text = "ArrowPoint CANBus Tools";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem monitoringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rawDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendCanPacketsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simualtorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem motorControllerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem canbusOverviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem driverControllerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataLoggerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logReplayerToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel connectedStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem batteryMenuItem;
        private System.Windows.Forms.ToolStripMenuItem batteryViewerToolStripMenuItem;
    }
}