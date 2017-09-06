using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;

namespace MyCTS.Presentation.Productivity
{
    public partial class frmProductivity : Form
    {
        public frmProductivity()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Extrae la semana anterior y despues se manda ese dato
        /// para estraer los datos que corresponden a esa semana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmProductivity_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            string week = string.Empty;
            string date = string.Empty;
            List<ProductivityWeeks> listWeeks = ProductivityWeeksBL.GetProductivityWeeks();
            foreach (ProductivityWeeks weeksItem in listWeeks)
            {
                ListItem litem = new ListItem();
                litem.Text = string.Format("{0}", weeksItem.Weeks);
                litem.Value = weeksItem.Weeks;
                week = weeksItem.Weeks;
            }

            date = week.Substring(18, 10);
            List<UserProductivityPerPCC> listProductivity =
            UserProductivityPerPCCBL.GetUserProductivityPerPCC(Login.Agent, date, 1);
            if (listProductivity.Count > 0)
            {
                #region==== Extact Data =====
                label14.Text = week;
                lblAirSegment.Text = listProductivity[0].AirSegment1.ToString();
                lblAutoSegment.Text =listProductivity[0].AutoSegment1.ToString();
                lblHotel.Text = listProductivity[0].HotelSegment1.ToString();
                lblAvgAirSegment.Text = listProductivity[0].AvgAirSegment1.ToString();
                lblAvgHotelSegment.Text = listProductivity[0].AvgHotelSegment1.ToString();
                lblAvgAutoSegment.Text = listProductivity[0].AvgAutoSegment1.ToString();
                lblAirSegmentProductivity.Text = listProductivity[0].AirSegmentProductivity1.ToString();
                lblHotelSegmentProductivity.Text = listProductivity[0].HotelSegmentProductivity1.ToString();
                lblAutoSegmentProductivity.Text = listProductivity[0].AutoSegmentProductivity1.ToString();
                lblTotalPNR.Text = listProductivity[0].TotalPNR1.ToString();
                lblCancelledPNR.Text = listProductivity[0].CancelledPNR1.ToString();
                lblScansAverage.Text = listProductivity[0].ScansAverage1.ToString();
                lblAvgRecords.Text = listProductivity[0].AvgRecords1.ToString();
                lblAvgCancelledRecords.Text = listProductivity[0].AvgCancelledRecords1.ToString();
                lblAvgScanAvgPerRecord.Text = listProductivity[0].AvgScanAvgPerRecord1.ToString();
                lblRecordsProductivity.Text = listProductivity[0].RecordsProductivity1.ToString();
                lblCancelledRecordsProductivity.Text = listProductivity[0].CancelledRecordsProductivity.ToString();
                lblAvgScanPerRecordProductivity.Text =listProductivity[0].AvgScanPerRecordProductivity1.ToString();
                lblEmittedTKT.Text = listProductivity[0].EmittedTKT1.ToString();
                lblCancelledTKT.Text = listProductivity[0].CancelledTKT1.ToString();
                lblAvgEmittedTKT.Text = listProductivity[0].AvgEmittedTKT1.ToString();
                lblAvgCancelledTKT.Text = listProductivity[0].AvgCancelledTKT1.ToString();
                lblEmittedTKTProductivity.Text =listProductivity[0].EmittedTKTProductivity1.ToString();
                lblCancelledTKTProductivity.Text = listProductivity[0].CancelledTKTProductivity1.ToString();
                #endregion
            }
        }
    }
}