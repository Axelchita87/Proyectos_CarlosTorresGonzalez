using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using System.Windows.Forms;
using System.Drawing;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{
    public class InterJetPassangerConfirmationContainerUserControlHandler : InterJetUserControlHandler
    {

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {


        }

        /// <summary>
        /// Gets the main container.
        /// </summary>
        private GroupBox MainContainer
        {
            get
            {
                return this.GetGroupBoxByName("paxContainer");

            }
        }

        /// <summary>
        /// Sets the passangers.
        /// </summary>
        /// <param name="passangers">The passangers.</param>
        public void SetPassangers(InterJetPassangers passangers)
        {

            int paxCounter = 0;
            var controlsStack = new Stack<ucInterJetPassangerConfirmationUserControl>();
            foreach (InterJetPassanger pax in passangers.GetAll())
            {
                var newPaxConfirmation = new ucInterJetPassangerConfirmationUserControl();
                if (paxCounter == 0)
                {
                    int X_DefaultCoordinate = 16;
                    int Y_DefaultCoordinate = 19;
                    newPaxConfirmation.Location = new Point(X_DefaultCoordinate, Y_DefaultCoordinate);
                }
                else
                {
                    var previousControl = controlsStack.Pop();
                    int yDisplacement = 30;// deberia ser 38
                    newPaxConfirmation.Location = new Point(previousControl.Location.X, previousControl.Location.Y + yDisplacement);
                }
                newPaxConfirmation.SetPassanger(pax);
                this.MainContainer.Controls.Add(newPaxConfirmation);
                controlsStack.Push(newPaxConfirmation);
                paxCounter += 1;
            }


        }
    }
}
