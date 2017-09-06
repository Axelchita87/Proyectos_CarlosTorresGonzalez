using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.CommandBuilders
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetAddStoredUserFeeCommand : InterJetCommandBuilder
    {
        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns></returns>
        public override string Build()
        {

            string sabreCommandToSend = this.GetSabreCommand();
            string responseFromAPI = this.Comunicator.SendCommand(sabreCommandToSend);
            if (VolarisSession.IsVolarisProcess)
            {
                VolarisSession.StoredUserFeeCommand = sabreCommandToSend;
            }
            else
            {
                this.Ticket.PassangerNumberRecord.StoredUserFeeCommand = sabreCommandToSend;
            }
            Success = true;
            return responseFromAPI;

        }

        /// <summary>
        /// Gets the sabre command.
        /// </summary>
        /// <returns></returns>
        private string GetSabreCommand()
        {
            string sabreCommand = string.Empty;
            if (VolarisSession.IsVolarisProcess)
            {
                sabreCommand = string.Format("PQM-TARIFA MANUAL DE VOLARIS {0}-{1}", DateTime.Now.ToString("ddMMMyy",
                                                                            new CultureInfo("en-US")),
                                                                            VolarisSession.PagoTotal.ToString("0.00"));

            }
            else
            {
                sabreCommand = string.Format("PQM-TARIFA MANUAL DE INTERJET {0}-{1}", DateTime.Now.ToString("ddMMMyy",
                                                                                            new CultureInfo("en-US")),
                                                                                            this.Ticket.BalanceToPay.ToString("0.00"));
            }
            return sabreCommand;
        }
    }
}
