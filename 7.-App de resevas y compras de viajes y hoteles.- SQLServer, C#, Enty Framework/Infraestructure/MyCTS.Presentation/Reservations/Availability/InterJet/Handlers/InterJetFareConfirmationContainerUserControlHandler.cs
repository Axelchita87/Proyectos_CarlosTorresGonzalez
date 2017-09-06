using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using System.Drawing;
using System.Windows.Forms;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{
    public class InterJetFareConfirmationContainerUserControlHandler : InterJetUserControlHandler
    {

        public void Intialize()
        {

        }

        private GroupBox MainContainer
        {
            get
            {
                return this.GetGroupBoxByName("mainContainer");
            }
        }

        public void SetFlights(InterJetFlights flights)
        {
            int flightCounter = 0;
            Stack<ucInterJetFareConfirmationUserControl> controlStack = new Stack<ucInterJetFareConfirmationUserControl>();
            ListTaxesInterjet.Fligth = 0;

            foreach (InterJetFlight flight in flights.GetAllFlights())
            {
                ListTaxesInterjet.Fligth=ListTaxesInterjet.Fligth + 1;
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

                ucInterJetFareConfirmationUserControl newFareConfirmation = new ucInterJetFareConfirmationUserControl();
                newFareConfirmation.SetFlight(flight);
                if (flightCounter == 0)
                {
                    int xDefaultCoordinate = 15;
                    int yDefaultCoordinate = 19;
                    newFareConfirmation.Location = new Point(xDefaultCoordinate, yDefaultCoordinate);
                }
                else
                {
                    ucInterJetFareConfirmationUserControl previous = controlStack.Pop();
                    int yDisplacement = 120;
                    newFareConfirmation.Location = new Point(previous.Location.X, previous.Location.Y + yDisplacement);
                }
                this.MainContainer.Controls.Add(newFareConfirmation);
                controlStack.Push(newFareConfirmation);
                flightCounter += 1;
            }
        }
    }
}
