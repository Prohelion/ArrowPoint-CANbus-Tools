using ArrowPointCANBusTool.Model;
using ArrowPointCANBusTool.Service;
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


        public BatteryViewerForm(UdpService udpService)
        {
            batteryService = new BatteryService(udpService);
            InitializeComponent();

            this.cmuBindingList = new BindingList<CMU>(new List<CMU>());
            this.cmuDataBindingSource.DataSource = cmuBindingList;

            // Move this logic to the receiver
            Timer timer = new Timer();
            timer.Interval = (100);
            timer.Tick += new EventHandler(timerTick);
            timer.Start();

        }


        private void timerTick(object sender, EventArgs e)
        {            

            try
            {
                CMU[] cmus = batteryService.GetBMU(0).GetCMUs();            
                cmuBindingList.Clear();

                foreach (CMU cmu in cmus)
                {
                    if (cmu.SerialNumber != 0)
                        cmuBindingList.Add(cmu);
                }
            }
            catch 
            {
            }
        }


        private void CMUdataGridView_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;

            if (null != gridView)
            {
                gridView.Rows[e.RowIndex].HeaderCell.Value = "CMU" + e.RowIndex;
            }
        }

       
    }
}
