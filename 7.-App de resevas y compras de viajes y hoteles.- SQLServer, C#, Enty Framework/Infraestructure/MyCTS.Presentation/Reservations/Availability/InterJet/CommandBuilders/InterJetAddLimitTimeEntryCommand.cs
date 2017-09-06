using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.CommandBuilders
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetAddLimitTimeEntryCommand : InterJetCommandBuilder
    {
        /// <summary>
        /// Builds this instance.7TAW
        /// </summary>
        /// <returns></returns>
        public override string Build()
        {
            //Cambio del Tiempo Limite petición por Guillermo Granados 30/05/2014
            //string sabreCommandToSend = string.Format("7TAW{0}{1}/", DateTime.Now.Day <= 9 ? string.Format("0{0}", DateTime.Now.Day) : DateTime.Now.Day.ToString(), DateTime.Now.ToString("MMM", new CultureInfo("en-US")));
            string sabreCommandToSend = "7T-A";
            string responseFromSabreAPI = this.Comunicator.SendCommand(sabreCommandToSend);
            if (VolarisSession.IsVolarisProcess)
            {
                VolarisSession.ItineraryCommand = sabreCommandToSend;
            }
            else
            {
                this.Ticket.PassangerNumberRecord.ItineraryCommand = sabreCommandToSend;
            }
            Success = true;
            return responseFromSabreAPI;

        }
    }
}
