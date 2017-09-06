using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetFlightConfirmationContainerUserControlHandler : InterJetUserControlHandler
    {


        public void Intialize()
        {

        }

        private GroupBox MainContainer
        {
            get
            {

                return this.GetGroupBoxByName("segmentContainer");
            }
        }


        /// <summary>
        /// Sets the flights.
        /// </summary>
        /// <param name="flights">The flights.</param>
        public void SetFlights(InterJetFlights flights)
        {

            int flightCounter = 0;
            var controlStack = new Stack<Control>();
            foreach (InterJetFlight flight in flights.GetAllFlights())
            {

                var flightConfirmation = new ucInterJetFlightConfirmationUserControl();
                flightConfirmation.SetFlight(flight);
                if (flightCounter == 0)
                {
                    int xDefaultCoordinate = 19;
                    int yDefaultCoordinate = 19;
                    flightConfirmation.Location = new Point(xDefaultCoordinate, yDefaultCoordinate);
                }
                else
                {

                    Control previousControl = controlStack.Pop();
                    int yDisplacement = 100;
                    flightConfirmation.Location = new Point(previousControl.Location.X, previousControl.Location.Y + yDisplacement);

                }
                this.MainContainer.Controls.Add(flightConfirmation);
                controlStack.Push(flightConfirmation);
                flightCounter += 1;

            }
        }

    }
}
