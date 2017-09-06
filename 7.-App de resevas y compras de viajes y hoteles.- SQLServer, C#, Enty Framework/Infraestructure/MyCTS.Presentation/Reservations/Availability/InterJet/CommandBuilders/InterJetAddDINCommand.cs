using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Presentation.Reservations.Availability.InterJet.Mailer;
using MyCTS.Business;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.CommandBuilders
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetAddDINCommand : InterJetCommandBuilder
    {
        private LogInterJetBL _service;

        /// <summary>
        /// Gets the service.
        /// </summary>
        private LogInterJetBL Service
        {
            get { return _service ?? (_service = new LogInterJetBL()); }
        }


        /// <summary>
        /// Logs the inter jet reservation.
        /// </summary>
        /// <param name="reservationCodeInterJet">The reservation code inter jet.</param>
        /// <param name="sabreReservationCode">The sabre reservation code.</param>
        private void LogInterJetReservation(string reservationCodeInterJet, string sabreReservationCode)
        {
            Service.InvoiceRecord(reservationCodeInterJet);
            Service.InsertSabreRecord(reservationCodeInterJet, sabreReservationCode);

        }
        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns>El comando que sera enviado al API</returns>
        public override string Build()
        {
            var mailer = new InterJetMailer();
            if(VolarisSession.IsVolarisProcess)
            Ticket.RecordSabre = VolarisSession.PNRSabre;
            else
            Ticket.RecordSabre = RecordLocalizer.GetRecordLocalizer();

            if (string.IsNullOrEmpty(Ticket.RecordSabre))
            {
                string responseFromApi = this.Comunicator.SendCommand("*A");
                string sabrePnr = responseFromApi.Split('\n')[0];
                Ticket.RecordSabre = sabrePnr;
            }
            mailer.Ticket = Ticket;
            string responseFromAPI = Comunicator.SendCommand(GetSabreCommand());
            if (!string.IsNullOrEmpty(responseFromAPI))
            {
                if (responseFromAPI.ToLower().Contains("*pac to verify"))
                {
                    string newResponse = Comunicator.SendCommand(GetSabreCommand());
                    if (newResponse.Contains("INVOICED"))
                    {
                        mailer.SendConfirmationMail();

                        LogInterJetReservation(Ticket.RecordLocator, Ticket.RecordSabre);

                        return "OK";
                    }
                }
                if (responseFromAPI.Contains("INVOICED"))
                {
                    LogInterJetReservation(Ticket.RecordLocator, Ticket.RecordSabre);
                    mailer.SendConfirmationMail();
                    return "OK";
                }
            }
            InterJetHelper.DestroyTicket();
            return "FAIL";

        }



        /// <summary>
        /// Gets the sabre command.
        /// </summary>
        /// <returns>el comando DIN</returns>
        private string GetSabreCommand()
        {
            return "DIN";
        }
    }
}
