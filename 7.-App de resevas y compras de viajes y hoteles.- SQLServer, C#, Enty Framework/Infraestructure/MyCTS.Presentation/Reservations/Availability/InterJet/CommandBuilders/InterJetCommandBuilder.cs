using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Services.Contracts;
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.CommandBuilders
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class InterJetCommandBuilder
    {
        public static readonly string ENDIT = "Σ";

        /// <summary>
        /// Gets or sets the ticket.
        /// </summary>
        /// <value>
        /// The ticket.
        /// </value>
        public InterJetTicket Ticket
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        private InterJetApiComunicator _comunicator;

        /// <summary>
        /// Gets the comunicator.
        /// </summary>
        public InterJetApiComunicator Comunicator
        {
            get { return this._comunicator ?? (this._comunicator = new InterJetApiComunicator()); }
        }

        public string ErrorMessage { get; set; }

        public bool Success { get; set; }

        public string MessageOnBuilt { get; set; }
        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns></returns>
        public abstract string Build();

    }
}
