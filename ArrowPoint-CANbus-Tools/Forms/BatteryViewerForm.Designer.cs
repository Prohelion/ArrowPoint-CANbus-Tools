namespace ArrowPointCANBusTool.Forms
{
    partial class BatteryViewerForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatteryViewerForm));
            this.bmuTelemetry = new System.Windows.Forms.GroupBox();
            this.BMUdataGridView = new System.Windows.Forms.DataGridView();
            this.header = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinmV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Max_mV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Min_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Max_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pack_mV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pack_mA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BalancePositive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BalanceNegative = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMU_Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmuTelemetry = new System.Windows.Forms.GroupBox();
            this.CMUdataGridView = new System.Windows.Forms.DataGridView();
            this.CellNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PCBTemperature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CellTemperature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CellVoltage0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cell1Voltage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cell2Voltage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cell3Voltage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cell4Voltage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cell5Voltage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cell6Voltage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cell7Voltage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BMUmenuStrip = new System.Windows.Forms.MenuStrip();
            this.BMU1 = new System.Windows.Forms.ToolStripMenuItem();
            this.BMU2 = new System.Windows.Forms.ToolStripMenuItem();
            this.TwelveVoltSystem = new System.Windows.Forms.GroupBox();
            this.TwelveVoltDataGridView = new System.Windows.Forms.DataGridView();
            this.SerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CellTemp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cell0mV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cell1mV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cell2mV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cell3mV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Net12vCurrent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HVDc2DcCurrent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusFlags = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusEvents = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bmuTelemetry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BMUdataGridView)).BeginInit();
            this.cmuTelemetry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CMUdataGridView)).BeginInit();
            this.BMUmenuStrip.SuspendLayout();
            this.TwelveVoltSystem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TwelveVoltDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // bmuTelemetry
            // 
            this.bmuTelemetry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bmuTelemetry.AutoSize = true;
            this.bmuTelemetry.Controls.Add(this.BMUdataGridView);
            this.bmuTelemetry.Location = new System.Drawing.Point(12, 27);
            this.bmuTelemetry.Name = "bmuTelemetry";
            this.bmuTelemetry.Size = new System.Drawing.Size(1116, 130);
            this.bmuTelemetry.TabIndex = 0;
            this.bmuTelemetry.TabStop = false;
            this.bmuTelemetry.Text = "BMU Telemetry";
            // 
            // BMUdataGridView
            // 
            this.BMUdataGridView.AllowUserToAddRows = false;
            this.BMUdataGridView.AllowUserToDeleteRows = false;
            this.BMUdataGridView.AllowUserToResizeColumns = false;
            this.BMUdataGridView.AllowUserToResizeRows = false;
            this.BMUdataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BMUdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BMUdataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BMUdataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.BMUdataGridView.ColumnHeadersHeight = 22;
            this.BMUdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.header,
            this.MinmV,
            this.Max_mV,
            this.Min_C,
            this.Max_C,
            this.Pack_mV,
            this.Pack_mA,
            this.BalancePositive,
            this.BalanceNegative,
            this.CMU_Count});
            this.BMUdataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.BMUdataGridView.EnableHeadersVisualStyles = false;
            this.BMUdataGridView.Location = new System.Drawing.Point(3, 16);
            this.BMUdataGridView.MultiSelect = false;
            this.BMUdataGridView.Name = "BMUdataGridView";
            this.BMUdataGridView.ReadOnly = true;
            this.BMUdataGridView.RowHeadersVisible = false;
            this.BMUdataGridView.RowHeadersWidth = 100;
            this.BMUdataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.BMUdataGridView.ShowEditingIcon = false;
            this.BMUdataGridView.Size = new System.Drawing.Size(1107, 110);
            this.BMUdataGridView.TabIndex = 3;
            this.BMUdataGridView.SelectionChanged += new System.EventHandler(this.BMUdataGridView_SelectionChanged);
            // 
            // header
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.header.DefaultCellStyle = dataGridViewCellStyle1;
            this.header.HeaderText = "";
            this.header.Name = "header";
            this.header.ReadOnly = true;
            // 
            // MinmV
            // 
            this.MinmV.HeaderText = "Min mV";
            this.MinmV.Name = "MinmV";
            this.MinmV.ReadOnly = true;
            this.MinmV.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Max_mV
            // 
            this.Max_mV.HeaderText = "Max mV";
            this.Max_mV.Name = "Max_mV";
            this.Max_mV.ReadOnly = true;
            this.Max_mV.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Min_C
            // 
            this.Min_C.HeaderText = "Min C";
            this.Min_C.Name = "Min_C";
            this.Min_C.ReadOnly = true;
            this.Min_C.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Max_C
            // 
            this.Max_C.HeaderText = "Max C";
            this.Max_C.Name = "Max_C";
            this.Max_C.ReadOnly = true;
            this.Max_C.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Pack_mV
            // 
            this.Pack_mV.HeaderText = "Pack mV";
            this.Pack_mV.Name = "Pack_mV";
            this.Pack_mV.ReadOnly = true;
            this.Pack_mV.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Pack_mA
            // 
            this.Pack_mA.HeaderText = "Pack mA";
            this.Pack_mA.Name = "Pack_mA";
            this.Pack_mA.ReadOnly = true;
            this.Pack_mA.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // BalancePositive
            // 
            this.BalancePositive.HeaderText = "Balance +";
            this.BalancePositive.Name = "BalancePositive";
            this.BalancePositive.ReadOnly = true;
            this.BalancePositive.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // BalanceNegative
            // 
            this.BalanceNegative.HeaderText = "Balance -";
            this.BalanceNegative.Name = "BalanceNegative";
            this.BalanceNegative.ReadOnly = true;
            this.BalanceNegative.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // CMU_Count
            // 
            this.CMU_Count.HeaderText = "CMU Count";
            this.CMU_Count.Name = "CMU_Count";
            this.CMU_Count.ReadOnly = true;
            this.CMU_Count.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // cmuTelemetry
            // 
            this.cmuTelemetry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmuTelemetry.AutoSize = true;
            this.cmuTelemetry.Controls.Add(this.CMUdataGridView);
            this.cmuTelemetry.Location = new System.Drawing.Point(12, 168);
            this.cmuTelemetry.Name = "cmuTelemetry";
            this.cmuTelemetry.Size = new System.Drawing.Size(1116, 213);
            this.cmuTelemetry.TabIndex = 1;
            this.cmuTelemetry.TabStop = false;
            this.cmuTelemetry.Text = "CMU Telemetry";
            // 
            // CMUdataGridView
            // 
            this.CMUdataGridView.AllowUserToAddRows = false;
            this.CMUdataGridView.AllowUserToDeleteRows = false;
            this.CMUdataGridView.AllowUserToResizeColumns = false;
            this.CMUdataGridView.AllowUserToResizeRows = false;
            this.CMUdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CMUdataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CMUdataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CMUdataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.CMUdataGridView.ColumnHeadersHeight = 22;
            this.CMUdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CellNumber,
            this.Serial,
            this.PCBTemperature,
            this.CellTemperature,
            this.CellVoltage0,
            this.Cell1Voltage,
            this.Cell2Voltage,
            this.Cell3Voltage,
            this.Cell4Voltage,
            this.Cell5Voltage,
            this.Cell6Voltage,
            this.Cell7Voltage});
            this.CMUdataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CMUdataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.CMUdataGridView.EnableHeadersVisualStyles = false;
            this.CMUdataGridView.Location = new System.Drawing.Point(3, 16);
            this.CMUdataGridView.MultiSelect = false;
            this.CMUdataGridView.Name = "CMUdataGridView";
            this.CMUdataGridView.ReadOnly = true;
            this.CMUdataGridView.RowHeadersVisible = false;
            this.CMUdataGridView.RowHeadersWidth = 100;
            this.CMUdataGridView.RowTemplate.ReadOnly = true;
            this.CMUdataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CMUdataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CMUdataGridView.Size = new System.Drawing.Size(1110, 194);
            this.CMUdataGridView.TabIndex = 3;
            this.CMUdataGridView.SelectionChanged += new System.EventHandler(this.CMUdataGridView_SelectionChanged);
            // 
            // CellNumber
            // 
            this.CellNumber.HeaderText = "";
            this.CellNumber.Name = "CellNumber";
            this.CellNumber.ReadOnly = true;
            // 
            // Serial
            // 
            this.Serial.DataPropertyName = "SerialNumber";
            this.Serial.HeaderText = "Serial";
            this.Serial.Name = "Serial";
            this.Serial.ReadOnly = true;
            this.Serial.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // PCBTemperature
            // 
            this.PCBTemperature.DataPropertyName = "PCBTemp";
            this.PCBTemperature.HeaderText = "PCB (C)";
            this.PCBTemperature.Name = "PCBTemperature";
            this.PCBTemperature.ReadOnly = true;
            this.PCBTemperature.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // CellTemperature
            // 
            this.CellTemperature.DataPropertyName = "CellTemp";
            this.CellTemperature.HeaderText = "Cell (C)";
            this.CellTemperature.Name = "CellTemperature";
            this.CellTemperature.ReadOnly = true;
            this.CellTemperature.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // CellVoltage0
            // 
            this.CellVoltage0.DataPropertyName = "Cell0mV";
            dataGridViewCellStyle3.NullValue = null;
            this.CellVoltage0.DefaultCellStyle = dataGridViewCellStyle3;
            this.CellVoltage0.HeaderText = "Cell 0 mV";
            this.CellVoltage0.Name = "CellVoltage0";
            this.CellVoltage0.ReadOnly = true;
            this.CellVoltage0.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Cell1Voltage
            // 
            this.Cell1Voltage.DataPropertyName = "Cell1mV";
            this.Cell1Voltage.HeaderText = "Cell 1 mV";
            this.Cell1Voltage.Name = "Cell1Voltage";
            this.Cell1Voltage.ReadOnly = true;
            this.Cell1Voltage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Cell2Voltage
            // 
            this.Cell2Voltage.DataPropertyName = "Cell2mV";
            this.Cell2Voltage.HeaderText = "Cell 2 mV";
            this.Cell2Voltage.Name = "Cell2Voltage";
            this.Cell2Voltage.ReadOnly = true;
            this.Cell2Voltage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Cell3Voltage
            // 
            this.Cell3Voltage.DataPropertyName = "Cell3mV";
            this.Cell3Voltage.HeaderText = "Cell 3 mV";
            this.Cell3Voltage.Name = "Cell3Voltage";
            this.Cell3Voltage.ReadOnly = true;
            this.Cell3Voltage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Cell4Voltage
            // 
            this.Cell4Voltage.DataPropertyName = "Cell4mV";
            this.Cell4Voltage.HeaderText = "Cell 4 mV";
            this.Cell4Voltage.Name = "Cell4Voltage";
            this.Cell4Voltage.ReadOnly = true;
            this.Cell4Voltage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Cell5Voltage
            // 
            this.Cell5Voltage.DataPropertyName = "Cell5mV";
            this.Cell5Voltage.HeaderText = "Cell 5 mV";
            this.Cell5Voltage.Name = "Cell5Voltage";
            this.Cell5Voltage.ReadOnly = true;
            this.Cell5Voltage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Cell6Voltage
            // 
            this.Cell6Voltage.DataPropertyName = "Cell6mV";
            this.Cell6Voltage.HeaderText = "Cell 6 mV";
            this.Cell6Voltage.Name = "Cell6Voltage";
            this.Cell6Voltage.ReadOnly = true;
            this.Cell6Voltage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Cell7Voltage
            // 
            this.Cell7Voltage.DataPropertyName = "Cell7mV";
            this.Cell7Voltage.HeaderText = "Cell 7 mV";
            this.Cell7Voltage.Name = "Cell7Voltage";
            this.Cell7Voltage.ReadOnly = true;
            this.Cell7Voltage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // BMUmenuStrip
            // 
            this.BMUmenuStrip.AllowMerge = false;
            this.BMUmenuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BMUmenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BMU1,
            this.BMU2});
            this.BMUmenuStrip.Location = new System.Drawing.Point(0, 0);
            this.BMUmenuStrip.Name = "BMUmenuStrip";
            this.BMUmenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.BMUmenuStrip.Size = new System.Drawing.Size(1140, 24);
            this.BMUmenuStrip.TabIndex = 2;
            this.BMUmenuStrip.Text = "menuStrip";
            this.BMUmenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.BMUmenuStrip_ItemClicked);
            // 
            // BMU1
            // 
            this.BMU1.Name = "BMU1";
            this.BMU1.Size = new System.Drawing.Size(54, 20);
            this.BMU1.Text = "BMU 1";
            // 
            // BMU2
            // 
            this.BMU2.Name = "BMU2";
            this.BMU2.Size = new System.Drawing.Size(54, 20);
            this.BMU2.Text = "BMU 2";
            // 
            // TwelveVoltSystem
            // 
            this.TwelveVoltSystem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TwelveVoltSystem.Controls.Add(this.TwelveVoltDataGridView);
            this.TwelveVoltSystem.Location = new System.Drawing.Point(12, 387);
            this.TwelveVoltSystem.Name = "TwelveVoltSystem";
            this.TwelveVoltSystem.Size = new System.Drawing.Size(1116, 68);
            this.TwelveVoltSystem.TabIndex = 3;
            this.TwelveVoltSystem.TabStop = false;
            this.TwelveVoltSystem.Text = "12v System";
            // 
            // TwelveVoltDataGridView
            // 
            this.TwelveVoltDataGridView.AllowUserToAddRows = false;
            this.TwelveVoltDataGridView.AllowUserToDeleteRows = false;
            this.TwelveVoltDataGridView.AllowUserToResizeColumns = false;
            this.TwelveVoltDataGridView.AllowUserToResizeRows = false;
            this.TwelveVoltDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TwelveVoltDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TwelveVoltDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TwelveVoltDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.TwelveVoltDataGridView.ColumnHeadersHeight = 22;
            this.TwelveVoltDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SerialNumber,
            this.CellTemp,
            this.Cell0mV,
            this.Cell1mV,
            this.Cell2mV,
            this.Cell3mV,
            this.Net12vCurrent,
            this.HVDc2DcCurrent,
            this.StatusFlags,
            this.StatusEvents});
            this.TwelveVoltDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.TwelveVoltDataGridView.EnableHeadersVisualStyles = false;
            this.TwelveVoltDataGridView.Location = new System.Drawing.Point(3, 16);
            this.TwelveVoltDataGridView.MultiSelect = false;
            this.TwelveVoltDataGridView.Name = "TwelveVoltDataGridView";
            this.TwelveVoltDataGridView.ReadOnly = true;
            this.TwelveVoltDataGridView.RowHeadersVisible = false;
            this.TwelveVoltDataGridView.RowHeadersWidth = 100;
            this.TwelveVoltDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TwelveVoltDataGridView.ShowEditingIcon = false;
            this.TwelveVoltDataGridView.Size = new System.Drawing.Size(1110, 44);
            this.TwelveVoltDataGridView.TabIndex = 0;
            this.TwelveVoltDataGridView.SelectionChanged += new System.EventHandler(this.TwelveVoltDataGridView_SelectionChanged);
            // 
            // SerialNumber
            // 
            this.SerialNumber.HeaderText = "Serial Number";
            this.SerialNumber.Name = "SerialNumber";
            this.SerialNumber.ReadOnly = true;
            // 
            // CellTemp
            // 
            this.CellTemp.HeaderText = "Cell Temp C";
            this.CellTemp.Name = "CellTemp";
            this.CellTemp.ReadOnly = true;
            // 
            // Cell0mV
            // 
            this.Cell0mV.HeaderText = "Cell 0 mV";
            this.Cell0mV.Name = "Cell0mV";
            this.Cell0mV.ReadOnly = true;
            // 
            // Cell1mV
            // 
            this.Cell1mV.HeaderText = "Cell 1 mV";
            this.Cell1mV.Name = "Cell1mV";
            this.Cell1mV.ReadOnly = true;
            // 
            // Cell2mV
            // 
            this.Cell2mV.HeaderText = "Cell 2 mV";
            this.Cell2mV.Name = "Cell2mV";
            this.Cell2mV.ReadOnly = true;
            // 
            // Cell3mV
            // 
            this.Cell3mV.HeaderText = "Cell 3 mV";
            this.Cell3mV.Name = "Cell3mV";
            this.Cell3mV.ReadOnly = true;
            // 
            // Net12vCurrent
            // 
            this.Net12vCurrent.HeaderText = "Net 12V mA";
            this.Net12vCurrent.Name = "Net12vCurrent";
            this.Net12vCurrent.ReadOnly = true;
            // 
            // HVDc2DcCurrent
            // 
            this.HVDc2DcCurrent.HeaderText = "DC 2 DC mA";
            this.HVDc2DcCurrent.Name = "HVDc2DcCurrent";
            this.HVDc2DcCurrent.ReadOnly = true;
            // 
            // StatusFlags
            // 
            this.StatusFlags.HeaderText = "Status Flags";
            this.StatusFlags.Name = "StatusFlags";
            this.StatusFlags.ReadOnly = true;
            // 
            // StatusEvents
            // 
            this.StatusEvents.HeaderText = "Status Events";
            this.StatusEvents.Name = "StatusEvents";
            this.StatusEvents.ReadOnly = true;
            // 
            // BatteryViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 465);
            this.Controls.Add(this.TwelveVoltSystem);
            this.Controls.Add(this.cmuTelemetry);
            this.Controls.Add(this.bmuTelemetry);
            this.Controls.Add(this.BMUmenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BatteryViewerForm";
            this.Text = "Battery Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BatteryViewerForm_FormClosing);
            this.Load += new System.EventHandler(this.BatteryViewerForm_Load);
            this.bmuTelemetry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BMUdataGridView)).EndInit();
            this.cmuTelemetry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CMUdataGridView)).EndInit();
            this.BMUmenuStrip.ResumeLayout(false);
            this.BMUmenuStrip.PerformLayout();
            this.TwelveVoltSystem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TwelveVoltDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox bmuTelemetry;
        private System.Windows.Forms.GroupBox cmuTelemetry;
        private System.Windows.Forms.DataGridView CMUdataGridView;
        private System.Windows.Forms.DataGridView BMUdataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn header;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinmV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Max_mV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Min_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn Max_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pack_mV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pack_mA;
        private System.Windows.Forms.DataGridViewTextBoxColumn BalancePositive;
        private System.Windows.Forms.DataGridViewTextBoxColumn BalanceNegative;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMU_Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn CellNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial;
        private System.Windows.Forms.DataGridViewTextBoxColumn PCBTemperature;
        private System.Windows.Forms.DataGridViewTextBoxColumn CellTemperature;
        private System.Windows.Forms.DataGridViewTextBoxColumn CellVoltage0;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cell1Voltage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cell2Voltage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cell3Voltage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cell4Voltage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cell5Voltage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cell6Voltage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cell7Voltage;
        private System.Windows.Forms.MenuStrip BMUmenuStrip;
        private System.Windows.Forms.ToolStripMenuItem BMU1;
        private System.Windows.Forms.ToolStripMenuItem BMU2;
        private System.Windows.Forms.GroupBox TwelveVoltSystem;
        private System.Windows.Forms.DataGridView TwelveVoltDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn CellTemp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cell0mV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cell1mV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cell2mV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cell3mV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Net12vCurrent;
        private System.Windows.Forms.DataGridViewTextBoxColumn HVDc2DcCurrent;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusFlags;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusEvents;
    }
}