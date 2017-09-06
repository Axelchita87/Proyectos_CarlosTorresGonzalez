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
    public class InterJetPassangerConfirmationUserControlHandler : InterJetUserControlHandler
    {


        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {

        }

        /// <summary>
        /// Sets the passanger.
        /// </summary>
        /// <param name="pax">The pax.</param>
        public void SetPassanger(InterJetPassanger pax)
        {
            this.SetPassangerName(pax);
        }

        /// <summary>
        /// Sets the name of the passanger.
        /// </summary>
        /// <param name="pax">The pax.</param>
        private void SetPassangerName(InterJetPassanger pax)
        {
            Label nameLabel = this.GetLabelByName("paxNameLabel");
            nameLabel.Text = pax.FullName;

        }
    }
}
