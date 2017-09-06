using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.CommandsBuilder
{
    public class VolarisAccountingLineCommandBuilder : IVolarisCommandBuilder
    {
        private List<string> remark = new List<string>();
        public VolarisAccountingLineCommandBuilder()
        {
            Communicator = new VolarisAPICommunicator();
        }

        #region Miembros de IVolarisCommandBuilder

        public VolarisAPICommunicator Communicator { get; set; }

        public MyCTS.Entities.VolarisReservation Reservation { get; set; }
        private readonly Dictionary<string, string> _errorDictionary = new Dictionary<string, string>
                                                                           {
                                                                               {"‡INVLD - TICKET NUMBER IN USE\n","Ocurrió un detalle al generar las líneas contables, por favor contacte a soporte."}
                                                                           };
        public void Build()
        {
            string remarkc11 = string.Empty;
            string remarkc16 = string.Empty;

            if (Reservation.Passangers.GetAdultsAndChildren().Any(p => string.IsNullOrEmpty(p.eTicket)))
            {
                ErrorMessage = "Ocurrió un problema en la generación de los tickets de pasajeros.Por favor pongase en contacto con soporte.";
                Success = false;
                return;
            }
            //var accountLine = "AC/Y4/{0}/P01/{1}/{2}/d{3}/D{7}/ONE/{4} {5}/1/{6}";
            var commands = new List<string>();
            foreach (var pax in Reservation.Passangers.GetAdultsAndChildren())
            {
                var command = string.Format("AC/Y4/{0}/P01/{1}/{2}/d{3}/D{7}/ONE/{4} {5}/1/{6}",
                                                    pax.eTicket,
                                                    Reservation.Itinerary.BaseFare.TotalBasePrice,
                                                    Reservation.Itinerary.BaseFare.Tua,
                                                    (Reservation.Itinerary.BaseFare.Iva != 0) ? (Reservation.Itinerary.BaseFare.Iva) : 000,
                                                    Reservation.Payment.CreditCardInformation.AccountingLineCard,
                                                    pax.PassangerNameInAccountingLine,
                                                    Reservation.Itinerary.IsInternational ? "F" : "D",
                                                    Reservation.Itinerary.BaseFare.ExtraTaxes
                                                     );
                commands.Add(command);
                decimal C11 = Reservation.Itinerary.BaseFare.TotalBasePrice + Reservation.Itinerary.BaseFare.Tua + Reservation.Itinerary.BaseFare.Iva + Reservation.Itinerary.BaseFare.ExtraTaxes;
                if (pax.Number.ToString().Length < 2)
                {
                    remarkc11 = "5.</C11-" + "0" + pax.Number.ToString() + "*" + C11.ToString("#");
                    remarkc16 = "5.</C16-" + "0" + pax.Number.ToString() + "*" + Reservation.Itinerary.BaseFare.TotalBasePrice.ToString("#");
                }
                else
                {
                    remarkc11 = "5.</C11-" + pax.Number.ToString() + "*" + C11.ToString("#");
                    remarkc16 = "5.</C16-" + pax.Number.ToString() + "*" + Reservation.Itinerary.BaseFare.TotalBasePrice.ToString("#");
                }

                remark.Add(remarkc11);
                remark.Add(remarkc16);

            }
            Reservation.Remarks.Add(remark);

            if (Reservation.Itinerary.BaseFare.IVAMonto11 != 0)
            {
                foreach (var pax in Reservation.Passangers.GetAdultsAndChildren())
                {
                    var command11Percent = string.Format("AC/Y4/{0}/P0/{1}/{2}/d{3}/D{7}/ONE/{4} {5}/1/{6}/E-V-Y4/P-SAL",
                                                         "88" + pax.eTicket.Substring(2, pax.eTicket.Length -2),
                                                        (Reservation.Itinerary.BaseFare.IVAMonto11 * 100) ,
                                                        "0",
                                                        (Reservation.Itinerary.BaseFare.IVA11 != 0) ? (Reservation.Itinerary.BaseFare.IVA11 * 100) : 000,
                                                        Reservation.Payment.CreditCardInformation.AccountingLineCard,
                                                        pax.PassangerNameInAccountingLine,
                                                        Reservation.Itinerary.IsInternational ? "F" : "D",
                                                        "0"
                                                         );
                    commands.Add(command11Percent);
                }
            }
            if (Reservation.Itinerary.BaseFare.IVAMonto16 != 0)
            {
                foreach (var pax in Reservation.Passangers.GetAdultsAndChildren())
                {
                    var command16Percent = string.Format("AC/Y4/{0}/P0/{1}/{2}/d{3}/D{7}/ONE/{4} {5}/1/{6}/E-V-Y4/P-SAL",
                                                        "99" + pax.eTicket.Substring(2, pax.eTicket.Length -2),
                                                        (Reservation.Itinerary.BaseFare.IVAMonto16 * 100),
                                                        "0",
                                                        (Reservation.Itinerary.BaseFare.IVA16 != 0) ? (Reservation.Itinerary.BaseFare.IVA16 *100) : 000,
                                                        Reservation.Payment.CreditCardInformation.AccountingLineCard,
                                                        pax.PassangerNameInAccountingLine,
                                                        Reservation.Itinerary.IsInternational ? "F" : "D",
                                                        "0"
                                                         );
                    commands.Add(command16Percent);
                }
            }

            foreach (var command in commands)
            {
                var response = Communicator.SendCommand(command);
                if (_errorDictionary.ContainsKey(response))
                {
                    Success = false;
                    Communicator.SendCommand("I");
                    ErrorMessage = _errorDictionary[response];
                    return;
                }
            }
            Success = true;
        }

        #endregion

        #region Miembros de IVolarisCommandBuilder


        public string ErrorMessage { get; set; }

        public bool Success { get; set; }

        #endregion

        #region Miembros de IVolarisCommandBuilder


        public string MessageOnBuilt { get; set; }

        #endregion
    }
}
