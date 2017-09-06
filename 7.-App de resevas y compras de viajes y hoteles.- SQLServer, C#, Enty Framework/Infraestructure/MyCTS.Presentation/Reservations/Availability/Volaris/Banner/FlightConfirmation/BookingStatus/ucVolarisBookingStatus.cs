using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.Volaris.FlightConfirmation.BookingStatus;
using MyCTS.Entities;

namespace MyCTS.Presentation
{
    public partial class ucVolarisBookingStatus : CustomUserControl, IVolarisBookingStatusView
    {

        private VolarisBookingStatusPresenter _presenter;

        public ucVolarisBookingStatus()
        {
            InitializeComponent();
        }

        #region Miembros de IVolarisBookingStatusView

        public VolarisReservation Reservation { get; set; }

        #endregion

        #region Miembros de IBaseView


        public void ValidateInput()
        {

        }

        public bool IsValid { get; set; }

        #endregion

        private void ucVolarisBookingStatus_Load(object sender, EventArgs e)
        {
            _presenter = new VolarisBookingStatusPresenter
                             {
                                 Repository = new VolarisBookingStatusRepository(),
                                 View = this
                             };

            _presenter.SetBookingStatus();

        }

        #region Miembros de IVolarisBookingStatusView


        public string RecordLocator
        {
            get { return this.recordLocatorTextBox.Text; }
            set { this.recordLocatorTextBox.Text = value; }
        }


        private VolarisReservationStatus _status;
        public VolarisReservationStatus Status
        {
            get { return _status; }
            set
            {
                if (_statusConverter.ContainsKey(value))
                {
                    statusTextBox.Text = _statusConverter[value];
                    _status = value;
                }
            }
        }

        private readonly Dictionary<VolarisReservationStatus, string> _statusConverter = new Dictionary
            <VolarisReservationStatus, string>
                                                                                    {
                                                                                        {VolarisReservationStatus.Accepted, "Confirmado"},
                                                                                        {VolarisReservationStatus.NotAccepted, "Sin Confirmar"},
                                                                                        {VolarisReservationStatus.None, "Ninguno"},
                                                                                        
                                                                                    };


        public DateTime PurchaseDate
        {
            get { return DateTime.Now; }
            set { purchaseDateTextBox.Text = value.ToString("dd MMMM yyyy"); }
        }

        #endregion
    }
}
