using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{
    public class InterJetCalculateServiceChargeHandler : InterJetFormHandler
    {








        /// <summary>
        /// Gets or sets the hiden panel.
        /// </summary>
        /// <value>
        /// The hiden panel.
        /// </value>
        public PictureBox HidenPanel { get; set; }

        /// <summary>
        /// Gets or sets the create rule button.
        /// </summary>
        /// <value>
        /// The create rule button.
        /// </value>
        public Button CreateRuleButton { get; set; }

        /// <summary>
        /// Gets or sets the create reservation button.
        /// </summary>
        /// <value>
        /// The create reservation button.
        /// </value>
        public Button CreateReservationButton { get; set; }

        /// <summary>
        /// Gets or sets the main panel.
        /// </summary>
        /// <value>
        /// The main panel.
        /// </value>
        public Panel MainPanel { get; set; }

        /// <summary>
        /// Gets or sets the loading label.
        /// </summary>
        /// <value>
        /// The loading label.
        /// </value>
        public Label LoadingLabel { get; set; }
        /// <summary>
        /// Gets or sets the loading picture box.
        /// </summary>
        /// <value>
        /// The loading picture box.
        /// </value>
        public PictureBox LoadingPictureBox { get; set; }

        /// <summary>
        /// Gets or sets the image reservation.
        /// </summary>
        /// <value>
        /// The image reservation.
        /// </value>
        public PictureBox ImageReservation { get; set; }





        /// <summary>
        /// Gets the session.
        /// </summary>
        private Hashtable Session
        {
            get
            {
                var interJetSession = (InterJetSession)(this.CurrentUserControl.Parameter);
                if (interJetSession != null)
                {
                    return interJetSession.Session;
                }
                return new Hashtable();
            }
        }

        /// <summary>
        /// Gets the profile.
        /// </summary>
        private InterJetCreditCardFields Credentials
        {
            get
            {
                if (this.Session["Credentials"] != null)
                {
                    return (InterJetCreditCardFields)this.Session["Credentials"];
                }
                return new InterJetCreditCardFields();

            }
        }






        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            SetToolTips();
            HideControlsForInterJet();

        }

        /// <summary>
        /// Sets the tool tips.
        /// </summary>
        private void SetToolTips()
        {
            this.DefaultToolTipController.SetToolTipIconType(this.CreateReservationButton, ToolTipIconType.Information);
            this.DefaultToolTipController.SetToolTip(this.CreateReservationButton, "Empezar a crear la reserva de interjet vía sabre".ToUpper());


        }

        /// <summary>
        /// Hides the controls for inter jet.
        /// </summary>
        private void HideControlsForInterJet()
        {

            this.CreateRuleButton.Visible = false;
            this.HidenPanel.Visible = false;

        }










        /// <summary>
        /// Recovers from error.
        /// </summary>
        public override void RecoverFromError()
        {
            throw new NotImplementedException();
        }



    }
}
