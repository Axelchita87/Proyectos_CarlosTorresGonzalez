using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;
using System.Drawing;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{
    public class InterJetPreviousFlightPricingControlHandler : InterJetUserControlHandler
    {


        public GroupBox MainContainer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        private ucInterJetPreviousItineraryControl _control;

        /// <summary>
        /// Gets the itinerary control.
        /// </summary>
        public ucInterJetPreviousItineraryControl ItineraryControl { get; set; }


        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {


        }

        /// <summary>
        /// Sets the flight.
        /// </summary>
        /// <param name="flight">The flight.</param>
        public void SetFlight(InterJetFlight flight, int seg)
        {
            ItineraryControl.SetFlight(flight, seg);
            bool hasAdultPassanger = flight.PreviousPrincig.Adult.TotalPax > 0;
            if (hasAdultPassanger)
            {
                this.LoadAdultPassangerControl(flight);
            }

            bool hasSeniorPassanger = flight.PreviousPrincig.Senior.TotalPax > 0;
            if (hasSeniorPassanger)
            {
                this.LoadSeniorPassangerControl(flight);
            }

            bool hasChildPassanger = flight.PreviousPrincig.Child.TotalPax > 0;
            if (hasChildPassanger)
            {
                this.LoadChildPassangerControl(flight);
            }

            bool hasInfantsPassanger = flight.PreviousPrincig.Infant.TotalPax > 0;
            if (hasInfantsPassanger)
            {
                this.LoadInfantPassangerControl(flight);
            }


        }

        /// <summary>
        /// Gets a value indicating whether this instance has added controls.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has added controls; otherwise, <c>false</c>.
        /// </value>
        private bool HasAddedControls
        {

            get { return MainContainer.Controls.OfType<ucInterJetPreviousPassangerPrincingControl>().Any(); }
        }

        /// <summary>
        /// Gets the lasted point.
        /// </summary>
        /// <returns></returns>
        private Point GetLastedPoint()
        {
            var controls = MainContainer.Controls.OfType<ucInterJetPreviousPassangerPrincingControl>();
            if (controls.Any())
            {
                const int xDefaultPosition = 91;
                int yPosition = controls.Sum(c => c.Size.Height);
                int sizeOfAnotherControl = 105;
                return new Point(xDefaultPosition, yPosition + sizeOfAnotherControl);
            }
            return new Point();

        }

        /// <summary>
        /// Gets the default point.
        /// </summary>
        /// <returns></returns>
        private Point GetDefaultPoint()
        {

            return new Point(90, 107);
        }



        /// <summary>
        /// Loads the adult passanger control.
        /// </summary>
        /// <param name="flight">The flight.</param>
        private void LoadAdultPassangerControl(InterJetFlight flight)
        {

            LoadControls(flight, InterJetPassangerType.Adult, flight.PreviousPrincig.Adult);
        }

        /// <summary>
        /// Loads the controls.
        /// </summary>
        /// <param name="flight">The flight.</param>
        /// <param name="type">The type.</param>
        /// <param name="paxprevious">The paxprevious.</param>
        private void LoadControls(InterJetFlight flight, InterJetPassangerType type, InterJetPassangerPreviousPricing paxprevious)
        {
            var passangerControl = new ucInterJetPreviousPassangerPrincingControl();
            passangerControl.PassangerType = type;
            passangerControl.PassangerPreviousPricing = paxprevious;
            passangerControl.BindPassangerPricing();
            if (!HasAddedControls)
            {
                passangerControl.Location = this.GetDefaultPoint();
            }
            else
            {
                passangerControl.Location = this.GetLastedPoint();
            }
            this.MainContainer.Controls.Add(passangerControl);

        }
        /// <summary>
        /// Loads the senior passanger control.
        /// </summary>
        /// <param name="flight">The flight.</param>
        private void LoadSeniorPassangerControl(InterJetFlight flight)
        {
            LoadControls(flight, InterJetPassangerType.Senior, flight.PreviousPrincig.Senior);

        }

        /// <summary>
        /// Loads the child passanger control.
        /// </summary>
        /// <param name="flight">The flight.</param>
        private void LoadChildPassangerControl(InterJetFlight flight)
        {
            LoadControls(flight, InterJetPassangerType.Child, flight.PreviousPrincig.Child);

        }


        /// <summary>
        /// Loads the infant passanger control.
        /// </summary>
        /// <param name="flight">The flight.</param>
        private void LoadInfantPassangerControl(InterJetFlight flight)
        {

            LoadControls(flight, InterJetPassangerType.Infant, flight.PreviousPrincig.Infant);
        }




    }
}
