using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Utils;
using MyCTS.Services.Contracts;
using MyCTS.Presentation.Components;
using MyCTS.Entities;
using System.Windows.Forms;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class InterJetFormHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InterJetFormHandler"/> class.
        /// </summary>
        protected InterJetFormHandler()
        {
        }



        public DefaultToolTipController DefaultToolTipController { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InterJetFormHandler"/> class.
        /// </summary>
        /// <param name="userControl">The user control.</param>
        protected InterJetFormHandler(CustomUserControl userControl)
        {

            this.CurrentUserControl = userControl;
        }

        /// <summary>
        /// 
        /// </summary>
        private ToolTip _tooltiper;

        /// <summary>
        /// Gets the tool tiper.
        /// </summary>
        public ToolTip ToolTiper
        {
            get
            {
                return _tooltiper ?? (_tooltiper = new ToolTip
                                                       {
                                                           InitialDelay = 0
                                                       });
            }
        }

        private ErrorProvider _errorProvideer;
        public ErrorProvider ErrorProvider
        {
            get { return _errorProvideer ?? (_errorProvideer = new ErrorProvider()); }
        }


        /// <summary>
        /// Gets or sets the current user control.
        /// </summary>
        /// <value>
        /// The current user control.
        /// </value>
        public CustomUserControl CurrentUserControl
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the current form.
        /// </summary>
        /// <value>
        /// The current form.
        /// </value>
        public Form CurrentForm
        {
            get;
            set;
        }

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
        /// Returns to availability control.
        /// </summary>
        public void ReturnToAvailabilityControl()
        {
            ucMenuReservations.EnabledMenu = true;
            Loader.AddToPanel(Loader.Zone.Middle, this.CurrentUserControl, "ucAvailability");

        }

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="error">The error.</param>
        public void LogError(string error)
        {

            this.LogError(error, true);
        }

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <param name="showMessage">if set to <c>true</c> [show message].</param>
        public void LogError(string error, bool showMessage)
        {
            if (showMessage)
            {
                MessageBox.Show(InterJetConstant.GENERIC_ERROR_INTERJET, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Common.AddMessageToLog(new Exception(error));
        }


        /// <summary>
        /// Recovers from error.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <param name="showMessage">if set to <c>true</c> [show message].</param>
        public void RecoverFromError(string error, bool showMessage)
        {
            LogError(error, showMessage);
            this.ReturnToAvailabilityControl();
        }

        /// <summary>
        /// Recovers from error.
        /// </summary>
        /// <param name="error">The error.</param>
        public void RecoverFromError(string error)
        {
            this.RecoverFromError(error, true);
        }



        /// <summary>
        /// Recovers from error.
        /// </summary>
        public abstract void RecoverFromError();

    }
}
