using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture.ContactCapture
{
    public interface VolarisContactInformationView : IBaseView
    {
        /// <summary>
        /// Gets or sets the cell phone lada.
        /// </summary>
        /// <value>
        /// The cell phone lada.
        /// </value>
        string CellPhoneLada { get; set; }
        /// <summary>
        /// Gets or sets the cell phone.
        /// </summary>
        /// <value>
        /// The cell phone.
        /// </value>
        string CellPhone { get; set; }
        /// <summary>
        /// Gets or sets the tele phone.
        /// </summary>
        /// <value>
        /// The tele phone.
        /// </value>
        string TelePhone { get; set; }
        /// <summary>
        /// Gets or sets the tele phone lada.
        /// </summary>
        /// <value>
        /// The tele phone lada.
        /// </value>
        string TelePhoneLada { get; set; }
        /// <summary>
        /// Gets or sets the email confirmation.
        /// </summary>
        /// <value>
        /// The email confirmation.
        /// </value>
        string EmailConfirmation { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        string Email { get; set; }

        VolarisContact Contact { get;  }
    }
}
