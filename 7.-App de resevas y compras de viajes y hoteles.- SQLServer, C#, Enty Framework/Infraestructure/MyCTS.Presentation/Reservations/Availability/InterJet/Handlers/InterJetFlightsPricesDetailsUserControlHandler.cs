using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;
using System.Collections;
using System.Drawing;
using MyCTS.Presentation.Components;
using MyCTS.Services.Contracts;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetFlightsPricesDetailsUserControlHandler : InterJetUserControlHandler
    {

        public ucInterJetPassangerConfirmationContainerControl PassangerContainer { get; set; }
        public static int Somite = 0;

        /// <summary>
        /// 
        /// </summary>
        private InterJetServiceManager _interJetServiceManager;

        /// <summary>
        /// Gets the inter jet service manager.
        /// </summary>
        public InterJetServiceManager InterJetServiceManager
        {
            get
            {
                InterJetServiceManager.AgentEmail = Login.Mail;
                return new InterJetServiceManager();
            }
        }

        /// <summary>
        /// Gets the main container.
        /// </summary>
        private Panel MainContainer
        {
            get
            {

                return this.GetPanelByName("mainContainer");
            }
        }

        /// <summary>
        /// Gets the current user control.
        /// </summary>
        private ucInterJetFlightsPricesDetailsForm CurrentUserControl
        {
            get
            {
                return this.UserControl as ucInterJetFlightsPricesDetailsForm;
            }
        }

        /// <summary>
        /// Gets the current ticket.
        /// </summary>
        private InterJetTicket CurrentTicket
        {
            get
            {
                return this.Session.ContainsKey("CurrentTicket") ? (InterJetTicket)this.Session["CurrentTicket"] : new InterJetTicket();
            }
        }

        /// <summary>
        /// Gets the session.
        /// </summary>
        private Hashtable Session
        {
            get
            {
                var session = (InterJetSession)this.CurrentUserControl.Parameter;
                return session != null ? session.Session : new Hashtable();
            }
        }



        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            LogProductivity.LogTransaction(Login.Agent, "5-Desplego Cotzación a detalle--InterJet");
            AddPassangerControl();
            this.AddControls();
            this.ResizeControls();
            SetToolTips();
        }

        public decimal GetAvailableCretid()
        {
            decimal credit = 0;
            credit = InterJetServiceManager.SeeNumber();
            return credit;
        }

        private void AddPassangerControl()
        {
            this.PassangerContainer.SetPassanger(this.CurrentTicket.Passangers);
        }

        /// <summary>
        /// Gets the default starting point.
        /// </summary>
        /// <returns></returns>
        private Point GetDefaultStartingPoint()
        {

            var paxContainer =
                this.MainContainer.Controls.OfType<ucInterJetPassangerConfirmationContainerControl>().FirstOrDefault();

            if (paxContainer != null)
            {

                int ydisplacement = 20;
                int defaultXCoordinate = 3;
                return new Point(defaultXCoordinate, paxContainer.Size.Height + ydisplacement);
            }
            return new Point();
        }

        /// <summary>
        /// Adds the controls.
        /// </summary>
        private void AddControls()
        {
            int flightCounter = 0;
            ListTaxesInterjet.Fligth = 0;
            var controlsStack = new Stack<ucInterJetFlightDetailPriceControl>();
            foreach (InterJetFlight flight in this.CurrentTicket.Flights.GetAllFlights())
            {

                ListTaxesInterjet.Fligth++;
                if (flight.Segments.GetAll().Count == 1)
                {
                    var newFlightDetail = new ucInterJetFlightDetailPriceControl();
                    if (flightCounter == 0)
                    {
                        int defaultXCoordinate = 17;
                        int defaultYCoordinate = 13;
                        newFlightDetail.Location = GetDefaultStartingPoint();
                    }
                    else
                    {
                        ucInterJetFlightDetailPriceControl previousControl = controlsStack.Pop();
                        int y_Displacement = previousControl.Size.Height;
                        newFlightDetail.Location = new Point(previousControl.Location.X, previousControl.Location.Y + y_Displacement);
                    }
                    newFlightDetail.SetInformation(this.CurrentTicket, flight);
                    this.MainContainer.Controls.Add(newFlightDetail);
                    controlsStack.Push(newFlightDetail);
                    flightCounter += 1;
                }
                else
                {
                    Somite = 0;
                    if (ListTaxesInterjet.Fligth == 1)
                    {
                        ListTaxesInterjet.turning = 0;
                        ListTaxesInterjet.turningTaxes = 0;

                    }
                    else
                    {
                        ListTaxesInterjet.turning = ListTaxesInterjet.mit;
                        ListTaxesInterjet.turningTaxes = ListTaxesInterjet.mit;
                    }
                    foreach (ISegment seg in flight.Segments.GetAll())
                    {
                        var newFlightDetail = new ucInterJetFlightDetailPriceControl();
                        if (flightCounter == 0)
                        {
                            int defaultXCoordinate = 17;
                            int defaultYCoordinate = 13;
                            newFlightDetail.Location = GetDefaultStartingPoint();
                        }
                        else
                        {

                            ucInterJetFlightDetailPriceControl previousControl = controlsStack.Pop();
                            int y_Displacement = previousControl.Size.Height;
                            newFlightDetail.Location = new Point(previousControl.Location.X, previousControl.Location.Y + y_Displacement);

                        }
                        newFlightDetail.SetInformation(this.CurrentTicket, flight);
                        this.MainContainer.Controls.Add(newFlightDetail);
                        controlsStack.Push(newFlightDetail);
                        flightCounter += 1;
                        Somite += 1;
                    }
                }
            }

        }

        /// <summary>
        /// Resizes the controls.
        /// </summary>
        private void ResizeControls()
        {

            var paxCotainer =
                MainContainer.Controls.OfType<ucInterJetPassangerConfirmationContainerControl>().FirstOrDefault();

            int yDisplacement = 0;
            if (paxCotainer != null)
            {
                yDisplacement += paxCotainer.Size.Height;
            }

            if (MainContainer.Controls.OfType<ucInterJetFlightDetailPriceControl>().Any())
            {
                yDisplacement +=
                    MainContainer.Controls.OfType<ucInterJetFlightDetailPriceControl>().Sum(c => c.Size.Height);
                int controlsCount = MainContainer.Controls.OfType<ucInterJetFlightDetailPriceControl>().Count();

            }
            Panel buttonPanel = this.GetPanelByName("buttonPanel");
            int xLocation = 170;
            yDisplacement += 30;
            buttonPanel.Location = new Point(xLocation, yDisplacement);







        }

        public Button ContinueButton { get; set; }
        public Button ReturnButton { get; set; }

        private void SetToolTips()
        {

            if (this.Session["GoToPayment"] != null)
            {
                this.ToolTiper.SetToolTip(ContinueButton, "Continuar con la forma de pago".ToUpper());
            }
            else
            {
                this.ToolTiper.SetToolTip(ContinueButton, "Continuar con la captura de la información de pago".ToUpper());
            }


            if (this.HasInfants)
            {

                this.ToolTiper.SetToolTip(ReturnButton, "Regresar a la captura de infantes".ToUpper());
            }
            else
            {

                this.ToolTiper.SetToolTip(ReturnButton, "Regresar a la captura de la información de contacto".ToUpper());
            }

        }

        /// <summary>
        /// Backs to payment form.
        /// </summary>
        public void BackToPaymentForm()
        {
            this.Session["IsAlreadyPriced"] = true;

            if (this.Session["GoToPayment"] != null)
            {
                this.Session["GoToPayment"] = null;
                this.Session["ShowProfilesCreditCards"] = true;
                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this.CurrentUserControl, "ucInterJetPaymentForm", this.CurrentUserControl.Parameter, null);

            }
            else
            {

                //Loader.AddToPanelWithParameters(Loader.Zone.Middle, this.CurrentUserControl, "ucInterJetPaymentForm", this.CurrentUserControl.Parameter, null);
                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this.CurrentUserControl, "ucDKClient",
                                                this.CurrentUserControl.Parameter, null);
            }


        }


        /// <summary>
        /// Backs to contact or infant.
        /// </summary>
        public void BackToContactOrInfant()
        {

            this.Session["IsAlreadyPriced"] = null;
            if (this.HasInfants)
            {

                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this.CurrentUserControl, "ucInterJetInfantCaptureForm", this.CurrentUserControl.Parameter, null);
            }
            else
            {

                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this.CurrentUserControl, "ucInterJetContactPassangerCaptureForm", this.CurrentUserControl.Parameter, null);
            }



        }

        /// <summary>
        /// Gets a value indicating whether this instance has infants.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has infants; otherwise, <c>false</c>.
        /// </value>
        private bool HasInfants
        {
            get
            {

                return this.Session["Infants"] != null;
            }
        }








    }
}
