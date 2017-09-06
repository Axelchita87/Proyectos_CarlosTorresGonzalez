using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using System.Windows.Forms;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetFlightDetailPriceUserControlHandler : InterJetUserControlHandler
    {


        public const string TITLE_CONTAINER = "Vuelo :{0}";

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
        }


        /// <summary>
        /// Sets the information.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <param name="flight">The flight.</param>
        public void SetInformation(InterJetTicket ticket, InterJetFlight flight)
        {
            this.SetDestinationsAndTime(flight);
            this.SetPassangerTaxVisibility(ticket, flight);


        }

        private GroupBox MainContainer
        {
            get
            {

                return this.GetGroupBoxByName("groupBoxContainer");
            }
        }

        /// <summary>
        /// Sets the destinations and time.
        /// </summary>
        /// <param name="flight">The flight.</param>
        private void SetDestinationsAndTime(InterJetFlight flight)
        {
            if (!InterJetPreviousPrincingHandler.Conexion)
            {
                Label departureTimeLabel = this.GetLabelByName("departureTimeLabel");
                departureTimeLabel.Text = string.Format("{0} hrs", flight.DepartureTime.ToString("HH:mm"));
                Label arrivalTimeLabel = this.GetLabelByName("label1");
                arrivalTimeLabel.Text = string.Format("{0} hrs", flight.ArrivalDateTime.ToString("HH:mm"));
                Label departureAndArrivalLabel = this.GetLabelByName("departureAndArrivalLabel");
                departureAndArrivalLabel.Text = string.Format("{0}-{1}", flight.DepartureStation, flight.ArrivalStation);
                GroupBox groupContainer = this.GetGroupBoxByName("groupBoxContainer");
                groupContainer.Text = string.Format(InterJetFlightDetailPriceUserControlHandler.TITLE_CONTAINER, flight.DepartureTime.ToString("dd/MM/yyyy"));
            }
            else
            {
                Label departureTimeLabel = this.GetLabelByName("departureTimeLabel");
                departureTimeLabel.Text = string.Format("{0} hrs", flight.Segments.GetAll()[InterJetFlightsPricesDetailsUserControlHandler.Somite].DepartureTime.ToString("HH:mm"));
                Label arrivalTimeLabel = this.GetLabelByName("label1");
                arrivalTimeLabel.Text = string.Format("{0} hrs", flight.Segments.GetAll()[InterJetFlightsPricesDetailsUserControlHandler.Somite].ArrivalTime.ToString("HH:mm"));
                Label departureAndArrivalLabel = this.GetLabelByName("departureAndArrivalLabel");
                departureAndArrivalLabel.Text = string.Format("{0}-{1}", flight.Segments.GetAll()[InterJetFlightsPricesDetailsUserControlHandler.Somite].DepartureStation, flight.Segments.GetAll()[InterJetFlightsPricesDetailsUserControlHandler.Somite].ArrivalStation);
                GroupBox groupContainer = this.GetGroupBoxByName("groupBoxContainer");
                groupContainer.Text = string.Format(InterJetFlightDetailPriceUserControlHandler.TITLE_CONTAINER, flight.Segments.GetAll()[InterJetFlightsPricesDetailsUserControlHandler.Somite].DepartureTime.ToString("dd/MM/yyyy"));

            }
        }

        /// <summary>
        /// Sets the total.
        /// </summary>
        public void SetTotal()
        {
            List<ucInterJetTaxFlightDetail> controls = this.MainContainer.Controls.OfType<ucInterJetTaxFlightDetail>().ToList();
            decimal total = 0;
            if (controls.Count > 0)
            {
                total = controls.Sum(e => e.Total);
            }
            total = total + PriceTotalResponseInterjet.totalPriceInfant;
            Label totalLabel = this.GetLabelByName("totalPriceLabel");
            totalLabel.Text = total.ToString("c");
        }

        /// <summary>
        /// Sets the taxes.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <param name="flight">The flight.</param>
        /// <param name="paxType">Type of the pax.</param>
        private void SetTaxes(InterJetTicket ticket, InterJetFlight flight, InterJetPassangerType paxType)
        {
            if (paxType == InterJetPassangerType.Adult)
            {
                var adultTaxDetail = this.GetControlByName("adultTaxDetailControl") as ucInterJetTaxFlightDetail;
                adultTaxDetail.PassangerType = InterJetPassangerType.Adult;
                adultTaxDetail.PassangerCount = ticket.Passangers.TotalAdults;
                adultTaxDetail.SetInformation(ticket, flight);

            }
           
            if (paxType == InterJetPassangerType.Child)
            {
                var childTaxDetail = this.GetControlByName("childTaxDetailControl") as ucInterJetTaxFlightDetail;
                childTaxDetail.PassangerType = InterJetPassangerType.Child;
                childTaxDetail.PassangerCount = ticket.Passangers.TotalChildren;
                childTaxDetail.SetInformation(ticket, flight);
            }

            if (paxType == InterJetPassangerType.Senior)
            {
                var seniorTaxDetail = this.GetControlByName("seniorTaxDetailControl") as ucInterJetTaxFlightDetail;
                seniorTaxDetail.PassangerType = InterJetPassangerType.Senior;
                seniorTaxDetail.PassangerCount = ticket.Passangers.TotalSenior;
                seniorTaxDetail.SetInformation(ticket, flight);
            }

            if (paxType == InterJetPassangerType.Infant)
            {

                //var infantTaxDetail = this.GetControlByName("infantTaxDetailControl") as ucInterJetTaxFlightDetail;
                //infantTaxDetail.PassangerType = InterJetPassangerType.Infant;
                //infantTaxDetail.PassangerCount = ticket.Passangers.GetInfants().Count;
                //infantTaxDetail.SetInformation(ticket, flight);
            }

        }

        /// <summary>
        /// Sets the passanger tax visibility.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <param name="flight">The flight.</param>
        private void SetPassangerTaxVisibility(InterJetTicket ticket, InterJetFlight flight)
        {
            this.ShowAdultTaxDetail(false);
            this.ShowChildTaxDetail(false);
            this.ShowSeniorTaxDetail(false);
            this.ShowInfantTaxDetail(false,1);

            if (ticket.Passangers.HasAdults)
            {
                this.ShowAdultTaxDetail(true);
                this.SetTaxes(ticket, flight, InterJetPassangerType.Adult);
            }

            if (ticket.Passangers.HasSeniorAdult)
            {
                this.ShowSeniorTaxDetail(true);
                this.SetTaxes(ticket, flight, InterJetPassangerType.Senior);
            }
            if (ticket.Passangers.HasChildren)
            {
                this.ShowChildTaxDetail(true);
                this.SetTaxes(ticket, flight, InterJetPassangerType.Child);
            }

            if (ticket.Passangers.HasInfants)
            {
                this.ShowInfantTaxDetail(true, flight.Segments.GetAll().Count);
                //this.SetTaxes(ticket, flight, InterJetPassangerType.Infant);
            }
        }


        /// <summary>
        /// Shows the adult tax detail.
        /// </summary>
        /// <param name="show">if set to <c>true</c> [show].</param>
        private void ShowAdultTaxDetail(bool show)
        {
            Control adultControl = this.GetControlByName("adultTaxDetailControl");
            adultControl.Visible = show;

        }

        /// <summary>
        /// Shows the senior tax detail.
        /// </summary>
        /// <param name="show">if set to <c>true</c> [show].</param>
        private void ShowSeniorTaxDetail(bool show)
        {

            Control seniorControl = this.GetControlByName("seniorTaxDetailControl");
            seniorControl.Visible = show;
        }

        /// <summary>
        /// Shows the child tax detail.
        /// </summary>
        /// <param name="show">if set to <c>true</c> [show].</param>
        private void ShowChildTaxDetail(bool show)
        {
            Control childControl = this.GetControlByName("childTaxDetailControl");
            childControl.Visible = show;
        }

        /// <summary>
        /// Shows the infant tax detail.
        /// </summary>
        /// <param name="show">if set to <c>true</c> [show].</param>
        private void ShowInfantTaxDetail(bool show, int seg)
        {
            Label lblInfante = this.GetLabelByName("lblInfante");
            lblInfante.Visible = show;
            Label lblInfantExtra = this.GetLabelByName("lblInfantExtra");
            lblInfantExtra.Visible = show;
            Label lblinfantPrice = this.GetLabelByName("lblinfantPrice");
            lblinfantPrice.Visible = show;
            lblinfantPrice.Text = (PriceTotalResponseInterjet.totalPriceInfant/seg).ToString("#.00");
            //Control infantControl = this.GetControlByName("infantTaxDetailControl");
            //infantControl.Visible = show;
        } 

    }
}
