using ArrowPointCANBusTool.Model;
using ArrowPointCANBusTool.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrowPointCANBusTool.Forms
{
    public partial class BatteryViewerForm : Form
    {

        private BatteryService batteryService;
        private BindingList<CMU> cmuBindingList;


        public BatteryViewerForm(CanService udpService)
        {
            batteryService = new BatteryService(udpService);
            InitializeComponent();

            this.cmuBindingList = new BindingList<CMU>(new List<CMU>());
            this.cmuDataBindingSource.DataSource = cmuBindingList;

            // Setup BMU Data
            DataGridViewRow sysStatus = new DataGridViewRow();
            sysStatus.CreateCells(BMUdataGridView);
            sysStatus.HeaderCell.Value = "Sys Status";
            BMUdataGridView.Rows.Add(sysStatus);

            DataGridViewRow secondHeader = new DataGridViewRow();
            secondHeader.CreateCells(BMUdataGridView);            
            secondHeader.Cells[6].Value = "Fan Speed (rpm)";
            secondHeader.Cells[7].Value = "SOC/BAL (Ah)";
            secondHeader.Cells[8].Value = "SOC/BAL (%)";
            BMUdataGridView.Rows.Add(secondHeader);            

            DataGridViewRow prechgStatus = new DataGridViewRow();
            prechgStatus.CreateCells(BMUdataGridView);
            sysStatus.HeaderCell.Value = "Prechg Status";
            BMUdataGridView.Rows.Add(prechgStatus);

            DataGridViewRow flags = new DataGridViewRow();
            flags.CreateCells(BMUdataGridView);
            sysStatus.HeaderCell.Value = "Flags";
            BMUdataGridView.Rows.Add(flags);

            // Move this logic to the receiver
            Timer timer = new Timer
            {
                Interval = (100)
            };
            timer.Tick += new EventHandler(TimerTick);
            timer.Start();

        }


        private void TimerTick(object sender, EventArgs e)
        {            

            try
            {
                // Setup the BMU Panel

                BMU activeBMU = batteryService.GetBMU(0);

                // Sys status
                DataGridViewRow sysStatus = BMUdataGridView.Rows[0];
                sysStatus.Cells[0].Value = activeBMU.MinCellVoltage;
                sysStatus.Cells[1].Value = activeBMU.MaxCellVoltage;
                sysStatus.Cells[2].Value = activeBMU.MinCellTemp;
                sysStatus.Cells[3].Value = activeBMU.MaxCellTemp;
                sysStatus.Cells[4].Value = activeBMU.BatteryVoltage;
                sysStatus.Cells[5].Value = activeBMU.BatteryCurrent;
                sysStatus.Cells[6].Value = activeBMU.BalanceVoltageThresholdRising;
                sysStatus.Cells[7].Value = activeBMU.BalanceVoltageThresholdFalling;
                sysStatus.Cells[8].Value = activeBMU.CMUCount;

                // preChgStatus
                DataGridViewRow prechgStatus = BMUdataGridView.Rows[2];
                prechgStatus.Cells[0].Value = activeBMU.PrechargeState;
                prechgStatus.Cells[6].Value = activeBMU.FanSpeed0RPM;
                prechgStatus.Cells[7].Value = activeBMU.SOCAh;
                prechgStatus.Cells[8].Value = activeBMU.SOCPercentage;

                // Flags
                DataGridViewRow flags = BMUdataGridView.Rows[3];
                prechgStatus.Cells[0].Value = activeBMU.StatusFlags;
                prechgStatus.Cells[6].Value = activeBMU.FanSpeed1RPM;

                CMU[] cmus = batteryService.GetBMU(0).GetCMUs();            
                cmuBindingList.Clear();

                for (int i = 0; i < cmus.Length; i++)
                {
                    if (cmus[i].SerialNumber != 0)                        
                        cmuBindingList.Add(cmus[i]);
                }
            }
            catch 
            {
            }
        }

        
       private void CMUdataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;

            for (int i = 0; i < this.CMUdataGridView.Rows.Count; i++)
            {
                this.CMUdataGridView.Rows[i].HeaderCell.Value = "CMU " + i;
            }

            // Set the bold colors
            int minCell = batteryService.GetBMU(0).CellNumberMinCell;
            int minCMU = batteryService.GetBMU(0).CMUNumberMinCell;

            int maxCell = batteryService.GetBMU(0).CellNumberMaxCell;
            int maxCMU = batteryService.GetBMU(0).CMUNumberMaxCell;

            DataGridViewCellStyle boldStyle = new DataGridViewCellStyle
            {
                Font = new Font(CMUdataGridView.Font, FontStyle.Bold)
            };

            if (this.CMUdataGridView.Rows.Count > minCMU)
                this.CMUdataGridView.Rows[minCMU].Cells[minCell + 3].Style.ApplyStyle(boldStyle);

            if (this.CMUdataGridView.Rows.Count > maxCMU)
                this.CMUdataGridView.Rows[maxCMU].Cells[maxCell + 3].Style.ApplyStyle(boldStyle);
        }
     
    }
}
