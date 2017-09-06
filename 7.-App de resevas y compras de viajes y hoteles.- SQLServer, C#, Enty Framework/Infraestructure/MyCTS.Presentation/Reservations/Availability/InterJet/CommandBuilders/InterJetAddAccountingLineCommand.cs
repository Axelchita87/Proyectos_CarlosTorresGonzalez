using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MyCTS.Entities;
using MyCTS.Business;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.CommandBuilders
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetAddAccountingLineCommand : InterJetCommandBuilder
    {
        LogTickets boleto = null;
        public const string ACCOUNT_LINE_STRING_TEMPLATE = "AC/4o/{0}/P01/{1}/{2}/d{3}/D{7}/ONE/{4} {5}/1/{6}";
        public const string ACCOUNT_LINE_STRING_TEMPLATE_VOLARIS = "AC/Y4/{0}/P01/{1}/{2}/d{3}/D{7}/ONE/{4} {5}/1/{6}";
        private int cont = 0;
        List<string> remark = null;
        decimal[] amountC11 = null;
        decimal[] amountC16 = null;
        string Boleto = string.Empty;
        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns></returns>
        public override string Build()
        {
            string[] sabreCommandsToSend = this.GetSabreCommands();

            foreach (string commandToSend in sabreCommandsToSend)
            {
                this.Comunicator.SendCommand(commandToSend);
                this.Ticket.PassangerNumberRecord.AccountingLines.Add(commandToSend);
            }
            Success = true;
            return "";
        }

        /// <summary>
        /// Gets the sabre commands.
        /// </summary>
        /// <returns></returns>
        private string[] GetSabreCommands()
        {

            var commands = new List<string>();

            if (VolarisSession.IsVolarisProcess)
            {
                amountC11 = new decimal[VolarisSession.ContAdult + VolarisSession.ContChild];
                amountC16 = new decimal[VolarisSession.ContAdult + VolarisSession.ContChild];
                foreach (VolarisFlight fly in VolarisSession.VolarisFlight)
                {
                    cont = 0;
                    commands.AddRange(this.GetSabreCommandVolaris(new List<VolarisFlight> { fly }));
                    break;
                }
            }
            else
            {
                InterjetQualityControleEighty.c80= new List<string>();

                amountC11 = new decimal[Ticket.Passangers.TotalAdults + Ticket.Passangers.TotalSenior + Ticket.Passangers.TotalChildren];
                amountC16 = new decimal[Ticket.Passangers.TotalAdults + Ticket.Passangers.TotalSenior + Ticket.Passangers.TotalChildren];
                foreach (InterJetFlight flight in this.Ticket.Flights.GetAllFlights())
                {
                    cont = 0;
                    commands.AddRange(this.GetSabreCommand(new List<InterJetFlight> { flight }));
                }
            }

            remark = new List<string>();
            for (int i = 0; i < amountC11.Count(); i++)
            {
                if (i.ToString().Length < 2)
                {
                    remark.Add("5.</C11-" + "0" + (i + 1) + "*" + amountC11[i].ToString("#") + "/>" + "</C12-" + "0" + (i + 1) + "*" + amountC11[i].ToString("#") + "/>" + "</C13-" + "0" + (i + 1) + "*" + amountC11[i].ToString("#") + "/>Σ" + "5.</C14-" + "0" + (i + 1) + "*" + amountC11[i].ToString("#") + "/>" + "</C15-" + "0" + (i + 1) + "*" + amountC11[i].ToString("#") + "/>");
                    remark.Add("5.</C16-" + "0" + (i + 1) + "*" + amountC16[i].ToString("#") + "/>" + "</C17-" + "0" + (i + 1) + "*" + amountC16[i].ToString("#") + "/>" + "</C18-" + "0" + (i + 1) + "*" + amountC16[i].ToString("#") + "/>Σ" + "5.</C19-" + "0" + (i + 1) + "*" + amountC16[i].ToString("#") + "/>" + "</C20-" + "0" + (i + 1) + "*" + amountC16[i].ToString("#") + "/>");
                }
                else
                {
                    remark.Add("5.</C11-" + (i + 1) + "*" + amountC11[i].ToString("#") + "/>" + "</C12-" + (i + 1) + "*" + amountC11[i].ToString("#") + "/>" + "</C13-" + (i + 1) + "*" + amountC11[i].ToString("#") + "/>Σ" + "5.</C14-" + (i + 1) + "*" + amountC11[i].ToString("#") + "/>" + "</C15-" + (i + 1) + "*" + amountC11[i].ToString("#") + "/>");
                    remark.Add("5.</C16-" + (i + 1) + "*" + amountC16[i].ToString("#") + "/>" + "</C17-" + (i + 1) + "*" + amountC16[i].ToString("#") + "/>" + "</C18-" + (i + 1) + "*" + amountC16[i].ToString("#") + "/>Σ" + "5.</C19-" + (i + 1) + "*" + amountC16[i].ToString("#") + "/>" + "</C20-" + (i + 1) + "*" + amountC16[i].ToString("#") + "/>");
                }
            }
            if (VolarisSession.IsVolarisProcess)
            {
                VolarisSession.Remarks.Add(remark);
            }
            else
            {
                Ticket.Remarks.Add(remark);
            }

            if(InterjetQualityControleEighty.c80 != null && InterjetQualityControleEighty.c80.Count > 0)
            {
                for( int g=0; g<InterjetQualityControleEighty.c80.Count; g++)
                {
                    Ticket.Remarks.Add(InterjetQualityControleEighty.c80[g]);
                }
            }

            return commands.ToArray();
        }

        /// <summary>
        /// Gets the sabre command.
        /// </summary>
        /// <param name="flights">The flights.</param>
        /// <returns></returns>
        private string[] GetSabreCommand(List<InterJetFlight> flights)
        {
            var commands = new List<string>();
            //quitar
            string comando = string.Empty;
            if (flights.Count > 0)
            {
                string currentFlightID = flights.FirstOrDefault().ID;
                InterJetFlight theFlight = flights.FirstOrDefault();

                if (this.Ticket.Passangers.HasAdults)
                {
                    int infante=1;

                    var adultCountingLine = new
                    {
                        TotalBasePriceSum = (flights.Sum(flight => flight.PriceDetail.Adult.BasePrice - flight.PriceDetail.Adult.Discount) / Ticket.Passangers.TotalAdults) * 100,
                        TotalTuaSum = (flights.Sum(flight => flight.PriceDetail.Adult.TUA) / Ticket.Passangers.TotalAdults) * 100,
                        TotalIVASuma = (flights.Sum(flight => flight.PriceDetail.Adult.IVA) / Ticket.Passangers.TotalAdults) * 100,
                        TotalExtraSum = (flights.Sum(flight => flight.PriceDetail.Adult.TotalExtraTaxes) / Ticket.Passangers.TotalAdults) * 100
                    };
                    foreach (InterJetAdultPassanger pax in this.Ticket.Passangers.GetAdultsPassangers())
                    {
                        if (this.Ticket.PaymentForm.StartsWith("CCA3"))
                        {
                            this.Ticket.PaymentForm = this.Ticket.PaymentForm.Replace("CCA3", "CCAX");
                        }

                        //boleto = LogTicketsBL.LogTicketsInterjet("7916309061"); //solo para pruebas
                        boleto = LogTicketsBL.LogTicketsInterjet(pax.UniqueID + currentFlightID[1]);
                        if (!string.IsNullOrEmpty(boleto.TicketNumber))
                        {
                            NewTicketInterjet(boleto.TicketNumber);
                        }
                        else
                        {
                            boleto.TicketNumber = pax.UniqueID + currentFlightID[1];
                        }

                        LogTicketsBL.LogTicketsInterjetInsert(boleto.TicketNumber, DateTime.Now, Ticket.RecordLocator, string.Empty);
                        string command = string.Format("AC/4o/{0}/P01/{1}/{2}/d{3}/D{7}/ONE/{4} {5}/1/{6}",
                                                       boleto.TicketNumber,
                                                       decimal.Truncate(adultCountingLine.TotalBasePriceSum),
                                                       decimal.Truncate(adultCountingLine.TotalTuaSum),
                                                       decimal.Truncate(adultCountingLine.TotalIVASuma),
                                                       this.Ticket.PaymentForm,
                                                       pax.AccountLineParameter,
                                                       theFlight.IsInternational ? "F" : "D",
                                                       decimal.Truncate(adultCountingLine.TotalExtraSum));

                        if (ListTaxesInterjet.Conexion)
                        {
                            string quality=string.Format("5.</C80-{0}*{1}/>",
                                boleto.TicketNumber,
                                ((Entities.InterJetSegment)theFlight.Segments.GetAll()[0]).Information.DepartureStation + "."+
                                ((Entities.InterJetSegment)theFlight.Segments.GetAll()[0]).Information.ArrivalStation + "." +
                                ((Entities.InterJetSegment)theFlight.Segments.GetAll()[1]).Information.ArrivalStation) ;

                            InterjetQualityControleEighty.c80.Add(quality);
                        }

                        string commandt = command.Trim();
                        commands.Add("" + commandt + "");

                        if (this.Ticket.Passangers.GetInfants().Count > 0 && infante <= this.Ticket.Passangers.GetInfants().Count
                            && PriceTotalResponseInterjet.totalPriceInfant > 0)
                        {
                            string command2 = string.Format("AC/4o/{0}/P01/{1}/{2}/d{3}/D{7}/ONE/{4} {5}/1/{6}/E-V-4o/P-SAL",
                                                       "88" + boleto.TicketNumber.Substring(2,8),
                                                       decimal.Truncate(PriceTotalResponseInterjet.totalPriceInfant * 100),
                                                       decimal.Truncate(0),
                                                       decimal.Truncate(0),
                                                       this.Ticket.PaymentForm,
                                                       pax.AccountLineParameter,
                                                       theFlight.IsInternational ? "F" : "D",
                                                       decimal.Truncate(0));

                            string commandt2 = command2.Trim();
                            commands.Add("" + commandt2 + "");
                            infante++;
                        }


                        //quitar
                        comando = comando + commandt;
                        decimal C11 = adultCountingLine.TotalBasePriceSum + adultCountingLine.TotalIVASuma + adultCountingLine.TotalTuaSum + adultCountingLine.TotalExtraSum;
                        amountC11[cont] = amountC11[cont] + C11;
                        amountC16[cont] = amountC16[cont] + adultCountingLine.TotalBasePriceSum;
                        cont++;
                    }
                }

                if (this.Ticket.Passangers.HasChildren)
                {
                    var childCountingLine = new
                    {
                        TotalBasePriceSum = (flights.Sum(flight => flight.PriceDetail.Child.BasePrice - flight.PriceDetail.Child.Discount) / Ticket.Passangers.TotalChildren) * 100,
                        TotalTuaSum = (flights.Sum(flight => flight.PriceDetail.Child.TUA) / Ticket.Passangers.TotalChildren) * 100,
                        TotalIVASuma = (flights.Sum(flight => flight.PriceDetail.Child.IVA) / Ticket.Passangers.TotalChildren) * 100,
                        TotalExtraSum = (flights.Sum(flight => flight.PriceDetail.Child.TotalExtraTaxes) / Ticket.Passangers.TotalChildren) * 100
                    };

                    foreach (InterJetChildPassanger pax in this.Ticket.Passangers.GetChildrenPassangers())
                    {
                        if (this.Ticket.PaymentForm.StartsWith("CCA3"))
                        {
                            this.Ticket.PaymentForm = this.Ticket.PaymentForm.Replace("CCA3", "CCAX");
                        }

                        boleto = LogTicketsBL.LogTicketsInterjet(pax.UniqueID + currentFlightID[1]);
                        if (!string.IsNullOrEmpty(boleto.TicketNumber))
                        {
                            NewTicketInterjet(boleto.TicketNumber);
                        }
                        else
                        {
                            boleto.TicketNumber = pax.UniqueID + currentFlightID[1];
                        }

                        LogTicketsBL.LogTicketsInterjetInsert(boleto.TicketNumber, DateTime.Now, Ticket.RecordLocator, string.Empty);

                        string command = string.Format(InterJetAddAccountingLineCommand.ACCOUNT_LINE_STRING_TEMPLATE,
                                                       boleto.TicketNumber,
                                                       decimal.Truncate(childCountingLine.TotalBasePriceSum),
                                                       decimal.Truncate(childCountingLine.TotalTuaSum),
                                                       decimal.Truncate(childCountingLine.TotalIVASuma),
                                                       this.Ticket.PaymentForm,
                                                       pax.AccountLineParameter,
                                                       theFlight.IsInternational ? "F" : "D",
                                                       decimal.Truncate(childCountingLine.TotalExtraSum));

                        if (ListTaxesInterjet.Conexion)
                        {
                            string quality = string.Format("5.</C80-{0}*{1}/>",
                                boleto.TicketNumber,
                                ((Entities.InterJetSegment)theFlight.Segments.GetAll()[0]).Information.DepartureStation + "." +
                                ((Entities.InterJetSegment)theFlight.Segments.GetAll()[0]).Information.ArrivalStation + "." +
                                ((Entities.InterJetSegment)theFlight.Segments.GetAll()[1]).Information.ArrivalStation);

                            InterjetQualityControleEighty.c80.Add(quality);
                        }

                        commands.Add(command);
                        comando = comando + " " + command;

                        decimal C11 = childCountingLine.TotalBasePriceSum + childCountingLine.TotalIVASuma + childCountingLine.TotalTuaSum + childCountingLine.TotalExtraSum;
                        amountC11[cont] = amountC11[cont] + C11;
                        amountC16[cont] = amountC16[cont] + childCountingLine.TotalBasePriceSum;
                        cont++;
                    }
                }

                if (this.Ticket.Passangers.HasSeniorAdult)
                {
                    var SeniorCountingLine = new
                    {
                        TotalBasePriceSum = (flights.Sum(flight => (flight.PriceDetail.Senior.BasePrice - flight.PriceDetail.Senior.Discount)) / Ticket.Passangers.TotalSenior) * 100,
                        TotalTuaSum = (flights.Sum(flight => flight.PriceDetail.Senior.TUA) / Ticket.Passangers.TotalSenior) * 100,
                        TotalIVASuma = (flights.Sum(flight => flight.PriceDetail.Senior.IVA) / Ticket.Passangers.TotalSenior) * 100,
                        TotalExtraSum = (flights.Sum(flight => flight.PriceDetail.Senior.TotalExtraTaxes) / Ticket.Passangers.TotalSenior) * 100
                    };

                    foreach (InterJetSeniorAdultPassanger pax in this.Ticket.Passangers.GetSeniorAdultsPassangers())
                    {
                        if (this.Ticket.PaymentForm.StartsWith("CCA3"))
                        {
                            this.Ticket.PaymentForm = this.Ticket.PaymentForm.Replace("CCA3", "CCAX");
                        }

                        boleto = LogTicketsBL.LogTicketsInterjet(pax.UniqueID + currentFlightID[1]);
                        if (!string.IsNullOrEmpty(boleto.TicketNumber))
                        {
                            NewTicketInterjet(boleto.TicketNumber);
                        }
                        else
                        {
                            boleto.TicketNumber = pax.UniqueID + currentFlightID[1];
                        }

                        LogTicketsBL.LogTicketsInterjetInsert(boleto.TicketNumber, DateTime.Now, Ticket.RecordLocator, string.Empty);

                        string command = string.Format(InterJetAddAccountingLineCommand.ACCOUNT_LINE_STRING_TEMPLATE,
                                                        boleto.TicketNumber,
                                                        decimal.Truncate(SeniorCountingLine.TotalBasePriceSum),
                                                        decimal.Truncate(SeniorCountingLine.TotalTuaSum),
                                                        decimal.Truncate(SeniorCountingLine.TotalIVASuma),
                                                        this.Ticket.PaymentForm,
                                                        pax.AccountLineParameter,
                                                         theFlight.IsInternational ? "F" : "D",
                                                         decimal.Truncate(SeniorCountingLine.TotalExtraSum));

                        if (ListTaxesInterjet.Conexion)
                        {
                            string quality = string.Format("5.</C80-{0}*{1}/>",
                                boleto.TicketNumber,
                                ((Entities.InterJetSegment)theFlight.Segments.GetAll()[0]).Information.DepartureStation + "." +
                                ((Entities.InterJetSegment)theFlight.Segments.GetAll()[0]).Information.ArrivalStation + "." +
                                ((Entities.InterJetSegment)theFlight.Segments.GetAll()[1]).Information.ArrivalStation);

                            InterjetQualityControleEighty.c80.Add(quality);
                        }


                        commands.Add(command);
                        comando = comando + " " + command;

                        decimal C11 = SeniorCountingLine.TotalBasePriceSum + SeniorCountingLine.TotalIVASuma + SeniorCountingLine.TotalTuaSum + SeniorCountingLine.TotalExtraSum;
                        amountC11[cont] = amountC11[cont] + C11;
                        amountC16[cont] = amountC16[cont] + SeniorCountingLine.TotalBasePriceSum;
                        cont++;
                    }
                }
            }
            //quitar
            ImpuestosBajoCosto.LineaContable = comando;
            ImpuestosBajoCostoBL.UpdateImpuestosBajoCosto(ImpuestosBajoCosto.Id, ImpuestosBajoCosto.ImpuestosObtenidos, ImpuestosBajoCosto.PNRBajoCosto, ImpuestosBajoCosto.ImpuestosMostrados, ImpuestosBajoCosto.LineaContable, string.Empty);
            return commands.ToArray();
        }

        private string[] GetSabreCommandVolaris(List<VolarisFlight> flights)
        {
            int infante = 1;

            if (VolarisSession.PagoVolaris.MetodoDePago == "MC")
            {
                VolarisSession.PagoVolaris.MetodoDePago = "CA";
            }
            VolarisSession.ContAdult = VolarisSession.contAdult;
            VolarisSession.BaseTotalPayAdult = 0;
            VolarisSession.IVATotalPayAdult = 0;
            VolarisSession.TUATotalPayAdult = 0;
            VolarisSession.OtrosTotalPayAdult = 0;

            VolarisSession.BaseTotalPayAdult = (VolarisSession.baseTotalPayAdult * VolarisSession.contAdult);
            VolarisSession.IVATotalPayAdult = (VolarisSession.ivaTotalPayAdult * VolarisSession.contAdult);
            VolarisSession.TUATotalPayAdult = (VolarisSession.tuaTotalPayAdult * VolarisSession.contAdult);
            VolarisSession.OtrosTotalPayAdult = (VolarisSession.otrosTotalPayAdult * VolarisSession.contAdult);
            VolarisSession.AdditionalAdult = VolarisSession.additionalAdult;
            //quitar
            string comando = string.Empty;

            var commands = new List<string>();

            for (int i = 0; i < flights.Count; i++)
            {
                string currentFlightID = "0" + 1;
                VolarisFlight theFlight = flights.FirstOrDefault();

                if (VolarisSession.ContAdult > 0)
                {
                    var adultCountingLine = new
                    {
                        TotalBasePriceSum = ((VolarisSession.BaseTotalPayAdult - VolarisSession.DiscountTotalPayAdult) / VolarisSession.ContAdult),
                        TotalIVASuma = (VolarisSession.IVATotalPayAdult / VolarisSession.ContAdult),
                        TotalTuaSum = (VolarisSession.TUATotalPayAdult / VolarisSession.ContAdult),
                        TotalExtraSum = (VolarisSession.OtrosTotalPayAdult / VolarisSession.ContAdult)
                    };
                    foreach (InterJetPassanger pax in VolarisSession.InterJetPassangers)
                    {                        
                        if (pax.IsAdult)                        
                        {
                            //boleto = LogTicketsBL.LogTicketsVolaris("7916309061"); //solo para pruebas
                            boleto = LogTicketsBL.LogTicketsVolaris(pax.UniqueID + currentFlightID[1]);
                            if (!string.IsNullOrEmpty(boleto.TicketNumber))
                            {
                                NewTicketVolais(boleto.TicketNumber);
                            }
                            else
                            {
                                boleto.TicketNumber = pax.UniqueID + currentFlightID[1];
                            }

                            LogTicketsBL.LogTicketsVolarisInsert(boleto.TicketNumber, DateTime.Now, VolarisSession.PNR, string.Empty);

                            string command = string.Format("AC/Y4/{0}/P01/{1}/{2}/D{3}/D{7}/ONE/{4} {5}/1/{6}",
                                                           boleto.TicketNumber,
                                                           decimal.Truncate(adultCountingLine.TotalBasePriceSum),
                                                           decimal.Truncate(adultCountingLine.TotalTuaSum),
                                                           decimal.Truncate(adultCountingLine.TotalIVASuma),
                                                           "CC" + VolarisSession.PagoVolaris.MetodoDePago + VolarisSession.PagoVolaris.NumeroTarjeta,
                                                           pax.AccountLineParameter,
                                                           VolarisSession.IsInternational ? "F" : "D",
                                                           decimal.Truncate(
                                                                   adultCountingLine.TotalExtraSum));
                            string commandt = command.Trim();
                            commands.Add("" + commandt + "");
                             //quitar la linea
                            comando= comando + commandt;

                            decimal C11 = adultCountingLine.TotalBasePriceSum + adultCountingLine.TotalIVASuma + adultCountingLine.TotalTuaSum + adultCountingLine.TotalExtraSum;
                            amountC11[cont] = amountC11[cont] + C11;
                            amountC16[cont] = amountC16[cont] + adultCountingLine.TotalBasePriceSum;
                            cont++;
                            foreach (AdditionalAccountingLine add in VolarisSession.AdditionalAdult)
                            {
                                if (add.Description == "11" && add.Amount > 0)
                                {
                                    string command11Percent = string.Format("AC/Y4/{0}/P0/{1}/{2}/D{3}/D{7}/ONE/{4} {5}/1/{6}/E-V-Y4/P-SAL",
                                                           string.Format("{0}{1}", "88" ,boleto.TicketNumber.Substring(2,8)),
                                                           decimal.Truncate((add.Amount * 100)),
                                                           decimal.Truncate(0),
                                                           decimal.Truncate((add.Iva * 100)),
                                                           "CC" + VolarisSession.PagoVolaris.MetodoDePago + VolarisSession.PagoVolaris.NumeroTarjeta,
                                                           pax.AccountLineParameter,
                                                           VolarisSession.IsInternational ? "F" : "D",
                                                           decimal.Truncate(0));
                                    commands.Add(command11Percent);
                                    comando= comando + "  " + command11Percent;
                                }
                                if (add.Description == "16" && add.Amount > 0)
                                {
                                    string command16Percent = string.Format("AC/Y4/{0}/P0/{1}/{2}/D{3}/D{7}/ONE/{4} {5}/1/{6}/E-V-Y4/P-SAL",
                                                           string.Format("{0}{1}", "99",boleto.TicketNumber.Substring(2,8)),
                                                           decimal.Truncate((add.Amount * 100)),
                                                           decimal.Truncate(0),
                                                           decimal.Truncate((add.Iva * 100)),
                                                           "CC" + VolarisSession.PagoVolaris.MetodoDePago + VolarisSession.PagoVolaris.NumeroTarjeta,
                                                           pax.AccountLineParameter,
                                                           VolarisSession.IsInternational ? "F" : "D",
                                                           decimal.Truncate(0));
                                    commands.Add(command16Percent);
                                    comando = comando + "  " + command16Percent;
                                }

                                if (VolarisSession.ContInfant > 0 && infante <= VolarisSession.ContInfant)
                                {
                                    string command11Percent = string.Format("AC/Y4/{0}/P0/{1}/{2}/D{3}/D{7}/ONE/{4} {5}/1/{6}/E-V-Y4/P-SAL",
                                                           string.Format("{0}{1}", "88", boleto.TicketNumber.Substring(2, 8)),
                                                           decimal.Truncate(((VolarisSession.Extra / VolarisSession.ContInfant) * 100)),
                                                           decimal.Truncate(0),
                                                           decimal.Truncate((0)),
                                                           "CC" + VolarisSession.PagoVolaris.MetodoDePago + VolarisSession.PagoVolaris.NumeroTarjeta,
                                                           pax.AccountLineParameter,
                                                           VolarisSession.IsInternational ? "F" : "D",
                                                           decimal.Truncate(0));
                                    commands.Add(command11Percent);
                                    comando = comando + "  " + command11Percent;
                                    infante++;
                                }
                            }
                        }
                    }

                }

                if (VolarisSession.ContChild > 0)
                {
                    VolarisSession.ContChild = VolarisSession.contChild;
                    VolarisSession.BaseTotalPayChild = 0;
                    VolarisSession.IVATotalPayChild = 0;
                    VolarisSession.TUATotalPayChild = 0;
                    VolarisSession.OtrosTotalPayChild = 0;

                    VolarisSession.BaseTotalPayChild = (VolarisSession.baseTotalPayChild * VolarisSession.ContChild);
                    VolarisSession.IVATotalPayChild = (VolarisSession.ivaTotalPayChild * VolarisSession.ContChild);
                    VolarisSession.TUATotalPayChild = (VolarisSession.tuaTotalPayChild * VolarisSession.ContChild);
                    VolarisSession.OtrosTotalPayChild = (VolarisSession.otrosTotalPayChild * VolarisSession.ContChild);
                    VolarisSession.AdditionalChild = VolarisSession.additionalChild;


                    var childCountingLine = new
                    {
                        TotalBasePriceSum = ((VolarisSession.BaseTotalPayChild - VolarisSession.DiscountTotalPayChild) / VolarisSession.ContChild),
                        TotalIVASuma = (VolarisSession.IVATotalPayChild / VolarisSession.ContChild),
                        TotalTuaSum = (VolarisSession.TUATotalPayChild / VolarisSession.ContChild),
                        TotalExtraSum = (VolarisSession.OtrosTotalPayChild / VolarisSession.ContChild)
                    };

                    foreach (InterJetPassanger pax in VolarisSession.InterJetPassangers)
                    {
                        if (pax.IsChild)
                        {
                            boleto = LogTicketsBL.LogTicketsVolaris(pax.UniqueID + currentFlightID[1]);
                            if (!string.IsNullOrEmpty(boleto.TicketNumber))
                            {
                                NewTicketVolais(boleto.TicketNumber);
                            }
                            else
                            {
                                boleto.TicketNumber = pax.UniqueID + currentFlightID[1];
                            }

                            LogTicketsBL.LogTicketsVolarisInsert(boleto.TicketNumber, DateTime.Now, VolarisSession.PNR, string.Empty);

                            string command = string.Format(InterJetAddAccountingLineCommand.ACCOUNT_LINE_STRING_TEMPLATE_VOLARIS,
                                                           boleto.TicketNumber,
                                                           decimal.Truncate(childCountingLine.TotalBasePriceSum),
                                                           decimal.Truncate(childCountingLine.TotalTuaSum),
                                                           decimal.Truncate(childCountingLine.TotalIVASuma),
                                                           "CC" + VolarisSession.PagoVolaris.MetodoDePago + VolarisSession.PagoVolaris.NumeroTarjeta,
                                                           pax.AccountLineParameter,
                                                           VolarisSession.IsInternational ? "F" : "D",
                                                           decimal.Truncate(childCountingLine.TotalExtraSum));
                            commands.Add(command);
                            decimal C11 = childCountingLine.TotalBasePriceSum + childCountingLine.TotalIVASuma + childCountingLine.TotalTuaSum + childCountingLine.TotalExtraSum;
                            amountC11[cont] = amountC11[cont] + C11;
                            amountC16[cont] = amountC16[cont] + childCountingLine.TotalBasePriceSum;
                            cont++;
                            //quitar la linea
                            comando = comando + "  " + command;

                            foreach (AdditionalAccountingLine add in VolarisSession.AdditionalChild)
                            {
                                if (add.Description == "11" && add.Amount > 0)
                                {
                                    string command11Percent = string.Format("AC/Y4/{0}/P0/{1}/{2}/D{3}/D{7}/ONE/{4} {5}/1/{6}/E-V-Y4/P-SAL",
                                                           string.Format("{0}{1}", "88", boleto.TicketNumber.Substring(2,8)),
                                                           decimal.Truncate((add.Amount * 100)),
                                                           decimal.Truncate(0),
                                                           decimal.Truncate((add.Iva * 100)),
                                                           "CC" + VolarisSession.PagoVolaris.MetodoDePago + VolarisSession.PagoVolaris.NumeroTarjeta,
                                                           pax.AccountLineParameter,
                                                           VolarisSession.IsInternational ? "F" : "D",
                                                           decimal.Truncate(0));
                                    commands.Add(command11Percent);
                                    comando = comando + "  " + command11Percent;
                                }
                                if (add.Description == "16" && add.Amount > 0)
                                {
                                    string command16Percent = string.Format("AC/Y4/{0}/P0/{1}/{2}/D{3}/D{7}/ONE/{4} {5}/1/{6}/E-V-Y4/P-SAL",
                                                           string.Format("{0}{1}", "99", boleto.TicketNumber.Substring(2,8)),
                                                           decimal.Truncate((add.Amount * 100)),
                                                           decimal.Truncate(0),
                                                           decimal.Truncate((add.Iva * 100)),
                                                           "CC" + VolarisSession.PagoVolaris.MetodoDePago + VolarisSession.PagoVolaris.NumeroTarjeta,
                                                           pax.AccountLineParameter,
                                                           VolarisSession.IsInternational ? "F" : "D",
                                                           decimal.Truncate(0));
                                    commands.Add(command16Percent);
                                    comando = comando + "  " + command16Percent;
                                }
                            }
                        }
                    }
                }
            }
            //quitar
            ImpuestosBajoCosto.LineaContable = comando;
            ImpuestosBajoCostoBL.UpdateImpuestosBajoCosto(ImpuestosBajoCosto.Id, ImpuestosBajoCosto.ImpuestosObtenidos, VolarisSession.PNR, ImpuestosBajoCosto.ImpuestosMostrados, ImpuestosBajoCosto.LineaContable, string.Empty);
            return commands.ToArray();
        }

        private void NewTicketInterjet(string oldTicket)
        {
            string num = oldTicket.Substring(2, 1);
            string num2 = (Convert.ToInt32(num) + 1).ToString();
            string newTicket = oldTicket.Substring(0, 2) + num2.Substring(0,1) + oldTicket.Substring(3, 7);

            boleto = LogTicketsBL.LogTicketsInterjet(newTicket);
            if (!string.IsNullOrEmpty(boleto.TicketNumber))
            {
                NewTicketInterjet(boleto.TicketNumber);
            }
            else
            {
                boleto.TicketNumber = newTicket;
            }
        }

        private void NewTicketVolais(string oldTicket)
        {
            string num = oldTicket.Substring(2, 1);
            string num2 = (Convert.ToInt32(num) + 1).ToString();
            string newTicket = oldTicket.Substring(0, 2) + num2.Substring(0, 1) + oldTicket.Substring(3, 7);

            boleto = LogTicketsBL.LogTicketsVolaris(newTicket);
            if (!string.IsNullOrEmpty(boleto.TicketNumber))
            {
                NewTicketVolais(boleto.TicketNumber);
            }
            else
            {
                boleto.TicketNumber = newTicket;
            }
        }

    }
}
