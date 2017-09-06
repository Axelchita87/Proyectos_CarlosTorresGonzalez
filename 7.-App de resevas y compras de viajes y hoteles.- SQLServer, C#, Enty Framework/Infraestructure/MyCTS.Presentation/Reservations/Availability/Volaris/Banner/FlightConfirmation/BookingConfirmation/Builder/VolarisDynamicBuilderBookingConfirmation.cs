using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Base;
using MyCTS.Entities;
using MyCTS.Presentation.Reservations.Availability.Volaris.FlightConfirmation.ContactInformation;
using MyCTS.Presentation.Reservations.Availability.Volaris.FlightConfirmation.PaymentInformation;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.FlightConfirmation.BookingConfirmation.Builder
{
    public class VolarisDynamicBuilderBookingConfirmation : IDynamicBuilder<Control>
    {


        public VolarisDynamicBuilderBookingConfirmation()
        {
            _table = new TableLayoutPanel
            {
                AutoSize = true
            };
            _table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        }

        #region Miembros de IDynamicBuilder<Control>

        public VolarisReservation Reservation { get; set; }
        private readonly TableLayoutPanel _table;
        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns></returns>
        public Control Build()
        {
            AddBookingStatus();
            AddPassangersConfirmation();
            AddFlightConfirmation();
            AddContactInformation();
            AddPaymentInformation();
            return _table;

        }




        /// <summary>
        /// Adds the row to table.
        /// </summary>
        /// <returns></returns>
        private int AddRowToTable()
        {
            return _table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        }
        /// <summary>
        /// Adds the passangers confirmation.
        /// </summary>
        private void AddPassangersConfirmation()
        {

            var passangers = Reservation.Passangers;
            var passangerControl = new ucVolarisPassangerConfirmation
                                       {
                                           Passangers = passangers
                                       };

            int passangersRowIndex = AddRowToTable();
            _table.Controls.Add(passangerControl, 0, passangersRowIndex);


        }

        private void AddFlightConfirmation()
        {

            var itinerary = Reservation.Itinerary;
            if (itinerary.Type == ItineraryType.RoundTrip)
            {
                var returningConfirmationControl = new ucVolarisPreviousFlightPricing
                {
                    ShowOnlySegments = true
                };
                returningConfirmationControl.Title = "Regreso";
                returningConfirmationControl.SetFlight(itinerary.Return);
                int arrivalRowIndex = AddRowToTable();
                _table.Controls.Add(returningConfirmationControl, 0, arrivalRowIndex);
            }


            var departureConfirmationControl = new ucVolarisPreviousFlightPricing
            {
                ShowOnlySegments = true
            };
            departureConfirmationControl.SetFlight(itinerary.Departure);
            int departureRowIndex = AddRowToTable();
            _table.Controls.Add(departureConfirmationControl, 0, departureRowIndex);

        }

        /// <summary>
        /// Adds the booking status.
        /// </summary>
        private void AddBookingStatus()
        {
            var bookingStatusControl = new ucVolarisBookingStatus
                                           {
                                               Reservation = Reservation
                                           };
            int bookingStatusRowIndex = AddRowToTable();
            _table.Controls.Add(bookingStatusControl, 0, bookingStatusRowIndex);


        }


        /// <summary>
        /// Adds the contact information.
        /// </summary>
        private void AddContactInformation()
        {
            var contact = Reservation.Contact;
            var contactInformation = new ucVolarisContactInformation
                                         {
                                             Contact = contact
                                         };
            int contactInformationRowIndex = AddRowToTable();
            _table.Controls.Add(contactInformation, 0, contactInformationRowIndex);



        }

        private void AddPaymentInformation()
        {

            var paymentInformationControl = new ucVolarisPaymentInformation
                                                {
                                                    Reservation = Reservation
                                                };
            int paymentInformationRowIndex = AddRowToTable();
            _table.Controls.Add(paymentInformationControl, 0, paymentInformationRowIndex);

        }

        #endregion
    }
}
