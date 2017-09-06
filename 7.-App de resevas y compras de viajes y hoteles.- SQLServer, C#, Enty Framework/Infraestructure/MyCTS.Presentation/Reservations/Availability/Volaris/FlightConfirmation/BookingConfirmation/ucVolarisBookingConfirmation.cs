using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.Volaris.FlightConfirmation.BookingConfirmation;

namespace MyCTS.Presentation
{
    public partial class ucVolarisBookingConfirmation : CustomUserControl, IVolarisBookingConfirmationView
    {
        public ucVolarisBookingConfirmation()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            var processBlock = new ProcessBlocker();
            if (processBlock.HandleEvent(ref msg, keyData))
            {
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        #region Miembros de IVolarisBookingConfirmationView

        public VolarisReservation Reservation
        {
            get
            {
                if (Parameter != null)
                {

                    return (VolarisReservation)Parameter;

                }
                return null;
            }
        }

        #endregion

        #region Miembros de IBaseView


        public void ValidateInput()
        {

        }

        public bool IsValid { get; set; }


        private VolarisBookingConfirmationPresenter _presenter;
        #endregion

        private void ucVolarisBookingConfirmation_Load(object sender, EventArgs e)
        {
            _presenter = new VolarisBookingConfirmationPresenter
                             {
                                 View = this,
                                 Repository = new VolarisBookingConfirmationRepository(),
                                 OnComplete = OnComplete
                             };
            ucMenuReservations.EnabledMenu = false;
            _presenter.CreateBookingConfirmation();
        }

        private void OnComplete(object sender, EventArgs eventArgs)
        {
            if (sender != null && sender is Control)
            {
                this.container.Controls.Add(sender as Control);
            }

            var table = sender as TableLayoutPanel;
            if (table != null)
            {
                int rowIndex = table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                buttonsPanelToHide.Dock = DockStyle.Right;
                buttonsPanelToHide.Visible = true;
                table.Controls.Add(this.buttonsPanelToHide, 0, rowIndex);

            }
            this.waitingForControls1.Visible = false;
            this.container.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucVolarisBookingConfirmation", this.Reservation, null);
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            try
            {
                Reservations.Availability.ChargeOfServiceLowFare.AssignamentChargeOfService.ucChargeOfServiceAssign.sDK = Reservation.CustomerDk.Value;
                Reservations.Availability.ChargeOfServiceLowFare.AssignamentChargeOfService.ucChargeOfServiceAssign.sPNR = Reservation.RecordLocator.Record;
            }
            catch (Exception ex)
            {
                String sError = ex.Message;
            }

            if (Reservation.CustomerDk.IsEventual)
            {
                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucBillingAdressEmission", this.Reservation, null);
            }
            else
            {

                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucAllQualityControls", this.Reservation, null);
            }


        }
    }
}
