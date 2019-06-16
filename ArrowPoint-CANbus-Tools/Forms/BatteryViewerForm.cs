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
        private Timer timer;
        private int activeBMUId = 0;

        public BatteryViewerForm(CanService canService)
        {
            batteryService = new BatteryService(canService);
            InitializeComponent();            
        }

        private void BatteryViewerForm_Load(object sender, EventArgs e)
        {
            // Setup BMU Data
            DataGridViewRow sysStatus = new DataGridViewRow();
            sysStatus.CreateCells(BMUdataGridView);            
            sysStatus.Cells[0].Value = "Sys Status";
            BMUdataGridView.Rows.Add(sysStatus);

            DataGridViewRow secondHeader = new DataGridViewRow();
            secondHeader.CreateCells(BMUdataGridView);
            secondHeader.Cells[7].Value = "Fan Speed (rpm)";
            secondHeader.Cells[8].Value = "SOC/BAL (Ah)";
            secondHeader.Cells[9].Value = "SOC/BAL (%)";
            secondHeader.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            BMUdataGridView.Rows.Add(secondHeader);

            DataGridViewRow prechgStatus = new DataGridViewRow();
            prechgStatus.CreateCells(BMUdataGridView);
            prechgStatus.Cells[0].Value = "Prechg Status";            
            BMUdataGridView.Rows.Add(prechgStatus);

            DataGridViewRow flags = new DataGridViewRow();
            flags.CreateCells(BMUdataGridView);
            flags.Cells[0].Value = "Flags";            
            BMUdataGridView.Rows.Add(flags);

            activeBMUId = 0;
            BMUmenuStrip.Items[activeBMUId].BackColor = Color.LightBlue;

            // Move this logic to the receiver
            timer = new Timer
            {
                Interval = (100)
            };
            timer.Tick += new EventHandler(TimerTick);            
            timer.Start();
        }


        private void BMUmenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string bmuNumber = e.ClickedItem.Name.Substring(3);
            activeBMUId = int.Parse(bmuNumber) - 1;

            foreach (ToolStripMenuItem item in BMUmenuStrip.Items)
            {
                item.BackColor = BMUmenuStrip.BackColor;
            }

            e.ClickedItem.BackColor = Color.LightBlue;
        }


        private void BatteryViewerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
        }

        private void TimerTick(object sender, EventArgs e)
        {

            try
            {
                // Setup the BMU Panel

                BMU activeBMU = batteryService.BatteryData.GetBMU(activeBMUId);

                // Sys status
                DataGridViewRow sysStatus = BMUdataGridView.Rows[0];
                sysStatus.Cells[1].Value = activeBMU.MinCellVoltage;
                sysStatus.Cells[2].Value = activeBMU.MaxCellVoltage;
                sysStatus.Cells[3].Value = (double)activeBMU.MinCellTemp / 10;
                sysStatus.Cells[4].Value = (double)activeBMU.MaxCellTemp / 10;
                sysStatus.Cells[5].Value = activeBMU.BatteryVoltage;
                sysStatus.Cells[6].Value = activeBMU.BatteryCurrent;
                sysStatus.Cells[7].Value = activeBMU.BalanceVoltageThresholdRising;
                sysStatus.Cells[8].Value = activeBMU.BalanceVoltageThresholdFalling;
                sysStatus.Cells[9].Value = activeBMU.CMUCount;

                // preChgStatus
                DataGridViewRow prechgStatus = BMUdataGridView.Rows[2];
                prechgStatus.Cells[1].Value = activeBMU.PrechargeStateText;
                prechgStatus.Cells[7].Value = activeBMU.FanSpeed0RPM;
                prechgStatus.Cells[8].Value = Math.Round(activeBMU.SOCAh,2);
                prechgStatus.Cells[9].Value = activeBMU.SOCPercentage * 100;

                // Flags
                DataGridViewRow flags = BMUdataGridView.Rows[3];
                flags.Cells[1].Value = activeBMU.StateMessage;
                flags.Cells[7].Value = activeBMU.FanSpeed1RPM;

                CMU[] cmus = batteryService.BatteryData.GetBMU(activeBMUId).GetCMUs();
         
                for (int cmuIndex = 0; cmuIndex < cmus.Length; cmuIndex++)
                {
                    if (cmus[cmuIndex].SerialNumber != 0)
                    {
                        if (CMUdataGridView.Rows.Count <= cmuIndex)
                            CMUdataGridView.Rows.Add(new DataGridViewRow());

                        DataGridViewRow cmuRow = CMUdataGridView.Rows[cmuIndex];
                        cmuRow.Cells[0].Value = "CMU " + (cmuIndex + 1);
                        cmuRow.Cells[1].Value = cmus[cmuIndex].SerialNumber;
                        cmuRow.Cells[2].Value = cmus[cmuIndex].PCBTemp;
                        cmuRow.Cells[3].Value = cmus[cmuIndex].CellTemp;
                        cmuRow.Cells[4].Value = cmus[cmuIndex].Cell0mV;
                        cmuRow.Cells[5].Value = cmus[cmuIndex].Cell1mV;
                        cmuRow.Cells[6].Value = cmus[cmuIndex].Cell2mV;
                        cmuRow.Cells[7].Value = cmus[cmuIndex].Cell3mV;
                        cmuRow.Cells[8].Value = cmus[cmuIndex].Cell4mV;
                        cmuRow.Cells[9].Value = cmus[cmuIndex].Cell5mV;
                        cmuRow.Cells[10].Value = cmus[cmuIndex].Cell6mV;
                        cmuRow.Cells[11].Value = cmus[cmuIndex].Cell7mV;

                        for (int cellIndex = 0; cellIndex <= 7; cellIndex++)
                            FormatCell(cmuRow.Cells[cellIndex+4], cmuIndex, cellIndex );
                        
                    }
                }
            }
            catch
            {
            }
        }

        private void BMUdataGridView_SelectionChanged(object sender, EventArgs e)
        {
            BMUdataGridView.ClearSelection();
        }

        private void CMUdataGridView_SelectionChanged(object sender, EventArgs e)
        {
            CMUdataGridView.ClearSelection();
        }

        private void FormatCell(DataGridViewCell cell, int cmuNo, int cellNo)
        {                        

            DataGridViewCellStyle defaultStyle = new DataGridViewCellStyle
            {
                Font = new Font(CMUdataGridView.Font, FontStyle.Regular),
                BackColor = Color.White
            };

            cell.Style = defaultStyle;

            DataGridViewCellStyle boldStyle = new DataGridViewCellStyle
            {
                Font = new Font(CMUdataGridView.Font, FontStyle.Bold)
            };

            DataGridViewCellStyle blueBackground = new DataGridViewCellStyle
            {
                BackColor = Color.LightBlue
            };

            DataGridViewCellStyle italicStyle = new DataGridViewCellStyle
            {
                Font = new Font(CMUdataGridView.Font, FontStyle.Italic)
            };
         
            if (cmuNo + 1 == batteryService.BatteryData.GetBMU(0).CMUNumberMinCell && cellNo == batteryService.BatteryData.GetBMU(0).CellNumberMinCell)                
                cell.Style.ApplyStyle(boldStyle);

            if (cmuNo + 1 == batteryService.BatteryData.GetBMU(0).CMUNumberMaxCell && cellNo == batteryService.BatteryData.GetBMU(0).CellNumberMaxCell)
                cell.Style.ApplyStyle(boldStyle);

            int.TryParse((string)cell.Value.ToString(), out int cellValue);

            BMU activeBMU = batteryService.BatteryData.GetBMU(activeBMUId);

            if (cellValue > activeBMU.BalanceVoltageThresholdFalling) cell.Style.ApplyStyle(blueBackground);
            if (cellValue > activeBMU.BalanceVoltageThresholdRising) cell.Style.ApplyStyle(italicStyle);


        }

    }
}
