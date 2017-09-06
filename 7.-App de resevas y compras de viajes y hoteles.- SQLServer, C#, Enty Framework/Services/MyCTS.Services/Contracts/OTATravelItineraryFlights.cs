using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
#if (VOLARIS_PRODUCTION)
using TravelItinerary = MyCTS.Services.com.sabre.webservices.TravelItinerary2;
using TravelItinerary2 = MyCTS.Services.com.sabre.webservices.TravelItinerary2;
#else
using TravelItinerary = MyCTS.Services.com.sabre.webservices.TravelItinerary2;
using TravelItinerary2 = MyCTS.Services.com.sabre.webservices.TravelItinerary2;
#endif
namespace MyCTS.Services.Contracts
{
    public class OTATravelItineraryFlights
    {
        public SCDCResumen getResumen(string convid, string ipcc, string securitytoken, string RecLoc, string pcc)
        {
            SCDCResumen resumen = null;
            string errorMessage = string.Empty;
            try
            {
                TravelItinerary2.TravelItineraryReadRS resp = getResponseService(convid, ipcc, securitytoken, RecLoc);

                if (resp.ApplicationResults.Error == null)
                {
                    resumen = new SCDCResumen();
                    resumen.RecLoc = RecLoc;
                    resumen.FechaCreacion = DateTime.ParseExact(resp.TravelItinerary.ItineraryRef.Source.CreateDateTime, "yyyy-MM-ddTHH:mm", System.Globalization.CultureInfo.CurrentCulture);
                    resumen.FechaTrans = DateTime.Now;
                    resumen.Apellido = resp.TravelItinerary.CustomerInfo.PersonName[0].Surname;
                    resumen.Nombre = resp.TravelItinerary.CustomerInfo.PersonName[0].GivenName;
                    resumen.BsgEspaciosLibres = Int32.Parse(resp.TravelItinerary.CustomerInfo.PersonName[0].GroupInfo != null ? resp.TravelItinerary.CustomerInfo.PersonName[0].GroupInfo.NumSeatsRemaining : "0");
                    resumen.BsgGrupo = resp.TravelItinerary.CustomerInfo.PersonName[0].GroupInfo != null ? "y" : "n";
                    resumen.BsgNombre = resp.TravelItinerary.CustomerInfo.PersonName[0].GroupInfo != null ? resp.TravelItinerary.CustomerInfo.PersonName[0].GroupInfo.Name : string.Empty;
                    resumen.Dk = resp.TravelItinerary.ItineraryRef.CustomerIdentifier ?? string.Empty;
                    resumen.FechaInicio = DateTime.Now.AddYears(3);

                    DateTime fechaFin = DateTime.Now.AddYears(-3);
                    List<string> departure = new List<string>();
                    List<string> arrival = new List<string>();

                    #region Busqueda de fechafin y fechainicio

                    foreach (TravelItinerary2.TravelItineraryReadRSTravelItineraryItineraryInfoItem item in resp.TravelItinerary.ItineraryInfo.ReservationItems)
                    {
                        foreach (TravelItinerary2.TravelItineraryReadRSTravelItineraryItineraryInfoItemFlightSegment flightSegment in item.FlightSegment == null ? new TravelItinerary2.TravelItineraryReadRSTravelItineraryItineraryInfoItemFlightSegment[0] : item.FlightSegment)
                        {
                            departure.Add(flightSegment.OriginLocation.LocationCode);
                            arrival.Add(flightSegment.DestinationLocation.LocationCode);

                            if (resumen.FechaInicio >= DateTime.ParseExact(flightSegment.DepartureDateTime, "yyyy-MM-ddTHH:mm", System.Globalization.CultureInfo.CurrentCulture))
                            {
                                resumen.FechaInicio = DateTime.ParseExact(flightSegment.DepartureDateTime, "yyyy-MM-ddTHH:mm", System.Globalization.CultureInfo.CurrentCulture);
                            }

                            if (fechaFin <= DateTime.ParseExact(flightSegment.ArrivalDateTime, "MM-ddTHH:mm", System.Globalization.CultureInfo.CurrentCulture))
                            {
                                fechaFin = DateTime.ParseExact(flightSegment.ArrivalDateTime, "MM-ddTHH:mm", System.Globalization.CultureInfo.CurrentCulture);
                                resumen.FechaFin = fechaFin.ToString("MMM dd yyyy HH:mm tt", new System.Globalization.CultureInfo("es-MX"));
                            }
                        }

                        //if (item.AirTaxi != null)
                        //{
                        //    if (resumen.FechaInicio >= DateTime.ParseExact(item.AirTaxi.DepartureDateTime, "yyyy-MM-ddTHH:mm", System.Globalization.CultureInfo.CurrentCulture))
                        //    {
                        //        resumen.FechaInicio = DateTime.ParseExact(item.AirTaxi.DepartureDateTime, "yyyy-MM-ddTHH:mm", System.Globalization.CultureInfo.CurrentCulture);
                        //    }

                        //    if (fechaFin <= DateTime.ParseExact(item.AirTaxi.DepartureDateTime, "yyyy-MM-ddTHH:mm", System.Globalization.CultureInfo.CurrentCulture))
                        //    {
                        //        fechaFin = DateTime.ParseExact(item.AirTaxi.DepartureDateTime, "yyyy-MM-ddTHH:mm", System.Globalization.CultureInfo.CurrentCulture);
                        //        resumen.FechaFin = fechaFin.ToString("MMM dd yyyy HH:mm tt", new System.Globalization.CultureInfo("es-MX"));
                        //    }
                        //}

                        if (item.Hotel != null)
                        {
                            departure.Add(item.Hotel.BasicPropertyInfo.ChainCode);
                            arrival.Add(item.Hotel.BasicPropertyInfo.ChainCode);
                            if (resumen.FechaInicio >= DateTime.ParseExact(item.Hotel.TimeSpan.Start, "MM-dd", System.Globalization.CultureInfo.CurrentCulture))
                            {
                                resumen.FechaInicio = DateTime.ParseExact(item.Hotel.TimeSpan.Start, "MM-dd", System.Globalization.CultureInfo.CurrentCulture);
                            }

                            if (fechaFin <= DateTime.ParseExact(item.Hotel.TimeSpan.End, "MM-dd", System.Globalization.CultureInfo.CurrentCulture))
                            {
                                fechaFin = DateTime.ParseExact(item.Hotel.TimeSpan.End, "MM-dd", System.Globalization.CultureInfo.CurrentCulture);
                                resumen.FechaFin = fechaFin.ToString("MMM dd yyyy HH:mm tt", new System.Globalization.CultureInfo("es-MX"));
                            }
                        }

                        //if (item.Insurance != null)
                        //{
                        //    if (resumen.FechaInicio >= DateTime.ParseExact(item.Insurance.InsuranceDetails.Start, "MM-dd", System.Globalization.CultureInfo.CurrentCulture))
                        //    {
                        //        resumen.FechaInicio = DateTime.ParseExact(item.Insurance.InsuranceDetails.Start, "MM-dd", System.Globalization.CultureInfo.CurrentCulture);
                        //    }

                        //    if (fechaFin <= DateTime.ParseExact(item.Insurance.InsuranceDetails.End, "MM-dd", System.Globalization.CultureInfo.CurrentCulture))
                        //    {
                        //        fechaFin = DateTime.ParseExact(item.Insurance.InsuranceDetails.End, "MM-dd", System.Globalization.CultureInfo.CurrentCulture);
                        //        resumen.FechaFin = fechaFin.ToString("MMM dd yyyy HH:mm tt", new System.Globalization.CultureInfo("es-MX"));
                        //    }
                        //}

                        //if (item.MiscSegment != null)
                        //{
                        //    if (resumen.FechaInicio >= DateTime.ParseExact(item.MiscSegment.DepartureDateTime, "MM-dd", System.Globalization.CultureInfo.CurrentCulture))
                        //    {
                        //        resumen.FechaInicio = DateTime.ParseExact(item.MiscSegment.DepartureDateTime, "MM-dd", System.Globalization.CultureInfo.CurrentCulture);
                        //    }

                        //    if (fechaFin <= DateTime.ParseExact(item.MiscSegment.DepartureDateTime, "MM-dd", System.Globalization.CultureInfo.CurrentCulture))
                        //    {
                        //        fechaFin = DateTime.ParseExact(item.MiscSegment.DepartureDateTime, "MM-dd", System.Globalization.CultureInfo.CurrentCulture);
                        //        resumen.FechaFin = fechaFin.ToString("MMM dd yyyy HH:mm tt", new System.Globalization.CultureInfo("es-MX"));
                        //    }
                        //}

                        //if (item.Surface != null)
                        //{
                        //    if (resumen.FechaInicio >= DateTime.ParseExact(item.Surface.DepartureDateTime, "yyyy-MM-ddTHH:mm", System.Globalization.CultureInfo.CurrentCulture))
                        //    {
                        //        resumen.FechaInicio = DateTime.ParseExact(item.Surface.DepartureDateTime, "yyyy-MM-ddTHH:mm", System.Globalization.CultureInfo.CurrentCulture);
                        //    }

                        //    if (fechaFin <= DateTime.ParseExact(item.Surface.DepartureDateTime, "yyyy-MM-ddTHH:mm", System.Globalization.CultureInfo.CurrentCulture))
                        //    {
                        //        fechaFin = DateTime.ParseExact(item.Surface.DepartureDateTime, "yyyy-MM-ddTHH:mm", System.Globalization.CultureInfo.CurrentCulture);
                        //        resumen.FechaFin = fechaFin.ToString("MMM dd yyyy HH:mm tt", new System.Globalization.CultureInfo("es-MX"));
                        //    }
                        //}

                        //if (item.Tour != null)
                        //{
                        //    if (resumen.FechaInicio >= DateTime.ParseExact(item.Tour.DepartureDateTime, "yyyy-MM-ddTHH:mm", System.Globalization.CultureInfo.CurrentCulture))
                        //    {
                        //        resumen.FechaInicio = DateTime.ParseExact(item.Tour.DepartureDateTime, "yyyy-MM-ddTHH:mm", System.Globalization.CultureInfo.CurrentCulture);
                        //    }

                        //    if (fechaFin <= DateTime.ParseExact(item.Tour.DepartureDateTime, "yyyy-MM-ddTHH:mm", System.Globalization.CultureInfo.CurrentCulture))
                        //    {
                        //        fechaFin = DateTime.ParseExact(item.Tour.DepartureDateTime, "yyyy-MM-ddTHH:mm", System.Globalization.CultureInfo.CurrentCulture);
                        //        resumen.FechaFin = fechaFin.ToString("MMM dd yyyy HH:mm tt", new System.Globalization.CultureInfo("es-MX"));
                        //    }
                        //}

                        if (item.Vehicle != null)
                        {
                            departure.Add(item.Vehicle.VehVendorAvail.Vendor.Code);
                            arrival.Add(item.Vehicle.VehVendorAvail.Vendor.Code);

                            if (resumen.FechaInicio >= DateTime.ParseExact(item.Vehicle.VehRentalCore.PickUpDateTime, item.Vehicle.VehRentalCore.PickUpDateTime.Length > 5 ? "MM-ddTHH:mm" : "MM-dd", System.Globalization.CultureInfo.CurrentCulture))
                            {
                                resumen.FechaInicio = DateTime.ParseExact(item.Vehicle.VehRentalCore.PickUpDateTime, item.Vehicle.VehRentalCore.PickUpDateTime.Length > 5 ? "MM-ddTHH:mm" : "MM-dd", System.Globalization.CultureInfo.CurrentCulture);
                            }

                            if (fechaFin <= DateTime.ParseExact(item.Vehicle.VehRentalCore.ReturnDateTime, item.Vehicle.VehRentalCore.ReturnDateTime.Length > 5 ? "MM-ddTHH:mm" : "MM-dd", System.Globalization.CultureInfo.CurrentCulture))
                            {
                                fechaFin = DateTime.ParseExact(item.Vehicle.VehRentalCore.ReturnDateTime, item.Vehicle.VehRentalCore.ReturnDateTime.Length > 5 ? "MM-ddTHH:mm" : "MM-dd", System.Globalization.CultureInfo.CurrentCulture);
                                resumen.FechaFin = fechaFin.ToString("MMM dd yyyy HH:mm tt", new System.Globalization.CultureInfo("es-MX"));
                            }
                        }
                    }

                    #endregion

                    for (int i = 0; i < departure.Count; i++)
                    {
                        if (string.IsNullOrEmpty(resumen.Ruta))
                        {
                            resumen.Ruta = string.Concat(departure[i], '-', arrival[i]);
                        }
                        else if ((departure[i] != arrival[i - 1]) && departure[i].Length <= 3)
                        {
                            resumen.Ruta = string.Concat(resumen.Ruta, '-', departure[i], '-', arrival[i]);
                        }
                        else
                        {
                            resumen.Ruta = string.Concat(resumen.Ruta, '-', arrival[i]);
                        }
                    }

                    if (string.IsNullOrEmpty(resumen.Ruta))
                    {
                        resumen.Ruta = "NA";
                    }

                    int cantPax = 0;
                    resumen.TarifaBase = 0.ToString();
                    resumen.Impuestos = 0.ToString();
                    resumen.TarifaTotal = 0.ToString();
                    resumen.LcTarifaBase = 0.ToString();
                    resumen.LcImpuesto1 = 0.ToString();
                    resumen.LcImpuesto2 = "0";
                    resumen.LcImpuesto3 = "0";
                    resumen.LcComision = 0.ToString();
                    resumen.TarifaMoneda = "MXN";

                    if (resp.TravelItinerary.ItineraryInfo.ItineraryPricing != null)
                    {

                        TravelItinerary2.TravelItineraryReadRSTravelItineraryItineraryInfoItineraryPricing itineraryPricing = resp.TravelItinerary.ItineraryInfo.ItineraryPricing;

                        foreach (TravelItinerary2.TravelItineraryReadRSTravelItineraryItineraryInfoItineraryPricingPriceQuote priceQuote in itineraryPricing.PriceQuote)
                        {
                            foreach (TravelItinerary2.TravelItineraryReadRSTravelItineraryItineraryInfoItineraryPricingPriceQuotePricedItinerary pricedItinerary in priceQuote.PricedItinerary)
                            {
                                foreach (TravelItinerary2.TravelItineraryReadRSTravelItineraryItineraryInfoItineraryPricingPriceQuotePricedItineraryAirItineraryPricingInfoPassengerTypeQuantity passengerTypeQuantity in pricedItinerary.AirItineraryPricingInfo.PassengerTypeQuantity)
                                {
                                    cantPax += Int32.Parse(passengerTypeQuantity.Quantity);
                                }
                                foreach (TravelItinerary2.TravelItineraryReadRSTravelItineraryItineraryInfoItineraryPricingPriceQuotePricedItineraryAirItineraryPricingInfoItinTotalFare itinTotalFare in pricedItinerary.AirItineraryPricingInfo.ItinTotalFare ?? new TravelItinerary2.TravelItineraryReadRSTravelItineraryItineraryInfoItineraryPricingPriceQuotePricedItineraryAirItineraryPricingInfoItinTotalFare[0])
                                {
                                    resumen.TarifaBase = (float.Parse(string.IsNullOrEmpty(resumen.TarifaBase) ? "0" : resumen.TarifaBase) + float.Parse(itinTotalFare.BaseFare.Amount)).ToString();
                                    resumen.Impuestos = (float.Parse(string.IsNullOrEmpty(resumen.Impuestos) ? "0" : resumen.Impuestos) + float.Parse(itinTotalFare.Taxes.Tax.Amount)).ToString();
                                    resumen.TarifaTotal = (float.Parse(string.IsNullOrEmpty(resumen.TarifaTotal) ? "0" : resumen.TarifaTotal) + float.Parse(itinTotalFare.TotalFare.Amount)).ToString();
                                    resumen.LcTarifaBase = (float.Parse(string.IsNullOrEmpty(resumen.LcTarifaBase) ? "0" : resumen.LcTarifaBase) + float.Parse(itinTotalFare.Totals != null ? itinTotalFare.Totals.TotalFare.Amount : itinTotalFare.TotalFare.Amount)).ToString();
                                    resumen.LcImpuesto1 = (float.Parse(string.IsNullOrEmpty(resumen.LcImpuesto1) ? "0" : resumen.LcImpuesto1) + float.Parse(itinTotalFare.Totals != null ? itinTotalFare.Totals.Taxes.Tax.Amount : itinTotalFare.Taxes.Tax.Amount)).ToString();
                                    resumen.LcImpuesto2 = "0";
                                    resumen.LcImpuesto3 = "0";
                                    resumen.TarifaMoneda = itinTotalFare.TotalFare.CurrencyCode;
                                }
                            }
                        }

                        foreach (TravelItinerary2.TravelItineraryReadRSTravelItineraryItineraryInfoItineraryPricingPhaseIVInfo phaseIVInfo in itineraryPricing.PhaseIVInfo != null ? itineraryPricing.PhaseIVInfo : new TravelItinerary2.TravelItineraryReadRSTravelItineraryItineraryInfoItineraryPricingPhaseIVInfo[0])
                        {
                            resumen.LcComision = (float.Parse(string.IsNullOrEmpty(resumen.LcComision) ? "0" : resumen.LcComision) + float.Parse(phaseIVInfo.Record.ItinTotalFare.Commission.Amount)).ToString();
                        }
                    }

                    resumen.Boleto = "n";

                    resumen.CantPax = cantPax.ToString("00");
                    foreach (TravelItinerary2.TravelItineraryReadRSTravelItineraryAccountingInfo accountInfo in resp.TravelItinerary.AccountingInfo != null ? resp.TravelItinerary.AccountingInfo : new TravelItinerary2.TravelItineraryReadRSTravelItineraryAccountingInfo[0])
                    {
                        resumen.Boleto = string.IsNullOrEmpty(accountInfo.TicketingInfo.OriginalTicketNumber != null ? accountInfo.TicketingInfo.OriginalTicketNumber[0] : string.Empty) ? "n" : "y";
                        break;
                    }

                    resumen.FechaMod = DateTime.Now;
                    resumen.Hotel = "n";
                    resumen.Auto = "n";
                    resumen.Millas = 0;

                    foreach (TravelItinerary2.TravelItineraryReadRSTravelItineraryItineraryInfoItem reservationItem in resp.TravelItinerary.ItineraryInfo.ReservationItems)
                    {
                        if (reservationItem.Hotel != null)
                        {
                            resumen.Hotel = "y";
                            continue;
                        }
                        else if (reservationItem.Vehicle != null)
                        {
                            resumen.Auto = "y";
                            continue;
                        }
                        else if (reservationItem.FlightSegment != null)
                        {
                            foreach (TravelItinerary2.TravelItineraryReadRSTravelItineraryItineraryInfoItemFlightSegment flightSegment in reservationItem.FlightSegment)
                            {
                                if (resumen.Vuelos == null)
                                {
                                    resumen.Vuelos = new List<SCDCVuelo>();
                                }

                                resumen.Vuelos.Add(MappingVuelo(flightSegment));
                                resumen.Millas += string.IsNullOrEmpty(flightSegment.AirMilesFlown) ? 0 : Int32.Parse(flightSegment.AirMilesFlown);
                            }
                        }
                        else if (reservationItem.Seats != null)
                        {
                            foreach (TravelItinerary2.TravelItineraryReadRSTravelItineraryItineraryInfoItemSeat seat in reservationItem.Seats)
                            {
                                for (int i = 0; i < resumen.Vuelos.Count; i++)
                                {
                                    if (resumen.Vuelos[i].Segmento == Int32.Parse(seat.SegmentNumber))
                                    {
                                        resumen.Vuelos[i].Asientos = "Y";
                                        break;
                                    }
                                }
                            }
                            continue;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    resumen.Internacional = ".";

                    foreach (TravelItinerary2.TravelItineraryReadRSTravelItineraryItineraryInfoTicketing ticketing in resp.TravelItinerary.ItineraryInfo.Ticketing ?? new TravelItinerary2.TravelItineraryReadRSTravelItineraryItineraryInfoTicketing[0])
                    {

                        if (string.IsNullOrEmpty(ticketing.eTicketNumber))
                        {
                            resumen.Internacional = ".";
                        }
                        else if (!ticketing.eTicketNumber.Contains("-MX"))
                        {
                            resumen.Internacional = "I";
                        }
                        else
                        {
                            resumen.Internacional = "N";
                            break;
                        }
                    }

                    resumen.LinContAerea = "n";

                    if (resumen.Internacional != ".")
                    {
                        resumen.LinContAerea = "y";
                    }

                    resumen.Recibido = resp.TravelItinerary.ItineraryRef.Source.ReceivedFrom;
                    resumen.PccCrea = resp.TravelItinerary.ItineraryRef.Source.HomePseudoCityCode;
                    resumen.PccFirma = resp.TravelItinerary.ItineraryRef.Source.PseudoCityCode;
                    resumen.PccLectura = resp.TravelItinerary.ItineraryRef.Source.AAA_PseudoCityCode;
                    //resumen.LastDay = null;

                    resumen.Agente = resp.TravelItinerary.ItineraryRef.Source.CreationAgent.Substring(1);
                    resumen.VuelosHist = string.Empty;
                    resumen.Revision = "CTS";
                    resumen.QueueLectura = string.Empty;

                    foreach (TravelItinerary2.TravelItineraryReadRSTravelItineraryPlacement queueInfo in resp.TravelItinerary.QueueInfo != null ? resp.TravelItinerary.QueueInfo : new TravelItinerary2.TravelItineraryReadRSTravelItineraryPlacement[0])
                    {
                        resumen.QueueLectura = queueInfo.Value.Split('/')[1].Split('-')[1];
                        resumen.LastDay = DateTime.ParseExact(queueInfo.Value.Split('/')[0].Substring(3), "ddMMM", new System.Globalization.CultureInfo("en-US"));
                        break;
                    }

                    if (resumen.LastDay == new DateTime(1, 1, 1))
                    {
                        resumen.LastDay = resumen.FechaInicio.AddDays(-1);
                    }

                    resumen.TxCasilla1 = "0.00";
                    resumen.TxCasilla2 = "0.00";
                    resumen.TxCasilla3 = resumen.Impuestos;
                }
            }
            catch { }

            return resumen;
        }

        public List<SCDCBoleto> getBoleto(string convid, string ipcc, string securitytoken, string RecLoc, string pcc)
        {
            List<SCDCBoleto> boletos = new List<SCDCBoleto>();
            try
            {
                TravelItinerary2.TravelItineraryReadRS resp = getResponseService(convid, ipcc, securitytoken, RecLoc);

                foreach (TravelItinerary2.TravelItineraryReadRSTravelItineraryItineraryInfoTicketing ticketing in resp.TravelItinerary.ItineraryInfo.Ticketing)
                {
                    if (!string.IsNullOrEmpty(ticketing.eTicketNumber))
                    {
                        foreach (TravelItinerary2.TravelItineraryReadRSTravelItinerarySpecialServiceInfo specialServiceInfo in resp.TravelItinerary.SpecialServiceInfo)
                        {
                            if (specialServiceInfo.Service.SSR_Type == "TKNE")
                            {
                                if (specialServiceInfo.Service.Text[0].Contains(ticketing.eTicketNumber.Split(' ')[1].Split('-')[0].Split('/')[0]))
                                {
                                    foreach (TravelItinerary2.TravelItineraryReadRSTravelItineraryItineraryInfoItem reservationItem in resp.TravelItinerary.ItineraryInfo.ReservationItems)
                                    {
                                        foreach (TravelItinerary2.TravelItineraryReadRSTravelItineraryItineraryInfoItemFlightSegment flightSegment in reservationItem.FlightSegment != null ? reservationItem.FlightSegment : new TravelItinerary2.TravelItineraryReadRSTravelItineraryItineraryInfoItemFlightSegment[0])
                                        {
                                            if (Int32.Parse(flightSegment.FlightNumber) == Int32.Parse(specialServiceInfo.Service.Text[0].Split(' ')[1].Substring(6, 4)))
                                            {
                                                SCDCBoleto boleto = new SCDCBoleto();
                                                boleto.RecLoc = resp.TravelItinerary.ItineraryRef.ID;
                                                boleto.FechaCreacion = DateTime.ParseExact(resp.TravelItinerary.ItineraryRef.Source.CreateDateTime, "yyyy-MM-ddTHH:mm", System.Globalization.CultureInfo.CurrentCulture);
                                                boleto.Segmento = Int32.Parse(flightSegment.SegmentNumber).ToString();
                                                boleto.NumeroBoleto = ticketing.eTicketNumber.Split(' ')[1].Split('-')[0].Split('/')[0];
                                                boleto.Nombre = ticketing.eTicketNumber.Split(' ')[2];
                                                boleto.Fecha = DateTime.ParseExact(ticketing.eTicketNumber.Split(' ')[4].Substring(0, 10), "HHmm/ddMMM", new System.Globalization.CultureInfo("en-US"));
                                                boleto.FechaEmision = boleto.Fecha;
                                                boleto.BoletoElectronico = ticketing.eTicketNumber.Split(' ')[0] == "TE" ? "y" : "n";
                                                boleto.Indicador = ticketing.eTicketNumber.Split(' ')[0];
                                                boleto.Pais = ticketing.eTicketNumber.Split(' ')[1].Split('-')[1];
                                                boleto.Indicador2 = ticketing.eTicketNumber.Split(' ').Length == 5 ? ticketing.eTicketNumber.Split(' ')[4].Split('*')[1] : ticketing.eTicketNumber.Split(' ')[5];
                                                boleto.Pcc = ticketing.eTicketNumber.Split(' ')[3].Split('*')[0];
                                                boletos.Add(boleto);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch { }

            return boletos;
        }

        private SCDCVuelo MappingVuelo(TravelItinerary2.TravelItineraryReadRSTravelItineraryItineraryInfoItemFlightSegment segment)
        {
            SCDCVuelo vuelo = new SCDCVuelo();

            vuelo.Segmento = Int32.Parse(segment.SegmentNumber);
            vuelo.Aerolinea = segment.MarketingAirline.Code;
            vuelo.NumVuelo = segment.FlightNumber;
            vuelo.FechaSalida = DateTime.ParseExact(segment.DepartureDateTime, "yyyy-MM-ddTHH:mm", System.Globalization.CultureInfo.CurrentCulture);
            vuelo.FechaRegreso = DateTime.ParseExact(segment.ArrivalDateTime, "MM-ddTHH:mm", System.Globalization.CultureInfo.CurrentCulture);
            vuelo.Origen = segment.OriginLocation.LocationCode;
            vuelo.Destino = segment.DestinationLocation.LocationCode;
            vuelo.Clase = segment.ResBookDesigCode;
            vuelo.Asientos = "N";
            vuelo.Conexion = segment.ConnectionInd == null ? string.Empty : segment.ConnectionInd.Length > 1 ? segment.ConnectionInd.Substring(0, 1) : segment.ConnectionInd;
            vuelo.Estatus = segment.Status;
            vuelo.Espacios = Int32.Parse(segment.NumberInParty);
            vuelo.IndicadorCon1 = ((segment.MarriageGrp != null) ? segment.MarriageGrp.Ind != "O" ? segment.MarriageGrp.Sequence : string.Empty : string.Empty) == "1" ? "*" : string.Empty;
            vuelo.IndicadorCon2 = ((segment.MarriageGrp != null) ? segment.MarriageGrp.Ind != "O" ? segment.MarriageGrp.Sequence : string.Empty : string.Empty) == "2" ? "*" : string.Empty;
            vuelo.Millas = Int32.Parse(string.IsNullOrEmpty(segment.AirMilesFlown) ? "0" : segment.AirMilesFlown);
            vuelo.TiempoVuelo = segment.ElapsedTime;
            vuelo.Avion = segment.Equipment.AirEquipType;
            vuelo.ClaveLa = segment.SupplierRef != null ? segment.SupplierRef.ID : string.Empty;
            vuelo.Escalas = Int32.Parse(string.IsNullOrEmpty(segment.StopQuantity) ? "0" : segment.StopQuantity);

            return vuelo;
        }

        private TravelItinerary.TravelItineraryReadRS getResponseService(string convid, string ipcc, string securitytoken, string RecLoc)
        {
            #region ====== Connection with web service ======

            //itineraryObject.Status = true;
            DateTime dt = DateTime.UtcNow;
            string tstamp = dt.ToString("s") + "Z";

            TravelItinerary.MessageHeader msgHeader = new TravelItinerary.MessageHeader();
            msgHeader.ConversationId = convid;		// Put ConversationId in req header

            TravelItinerary.From from = new TravelItinerary.From();
            TravelItinerary.PartyId fromPartyId = new TravelItinerary.PartyId();
            TravelItinerary.PartyId[] fromPartyIdArr = new TravelItinerary.PartyId[1];
            fromPartyId.Value = "99999";
            fromPartyIdArr[0] = fromPartyId;
            from.PartyId = fromPartyIdArr;
            msgHeader.From = from;

            TravelItinerary.To to = new TravelItinerary.To();
            TravelItinerary.PartyId toPartyId = new TravelItinerary.PartyId();
            TravelItinerary.PartyId[] toPartyIdArr = new TravelItinerary.PartyId[1];
            toPartyId.Value = "123123";
            toPartyIdArr[0] = toPartyId;
            to.PartyId = toPartyIdArr;
            msgHeader.To = to;

            msgHeader.CPAId = ipcc;
            msgHeader.Action = "TravelItineraryReadLLSRQ";
            TravelItinerary.Service service = new TravelItinerary.Service();
            service.Value = "Travel Itinerary Read";
            msgHeader.Service = service;


            TravelItinerary.MessageData msgData = new TravelItinerary.MessageData();
            msgData.MessageId = "mid:20001209-133003-2333@clientofsabre.com";
            msgData.Timestamp = tstamp;
            msgHeader.MessageData = msgData;
            TravelItinerary.Security1 security = new TravelItinerary.Security1();
            security.BinarySecurityToken = securitytoken;	// Put BinarySecurityToken in req header

            //Create the request object req and the value for the IPCC in the payload of the request.
            string GEAServices = ConfigurationManager.AppSettings["ServiciosGEA"];

            TravelItinerary.TravelItineraryReadRQMessagingDetails messagingDetails = new TravelItinerary2.TravelItineraryReadRQMessagingDetails();

            messagingDetails.Transaction = new TravelItinerary2.TravelItineraryReadRQMessagingDetailsTransaction[1];
            messagingDetails.Transaction[0] = new TravelItinerary2.TravelItineraryReadRQMessagingDetailsTransaction();
            messagingDetails.Transaction[0].Code = TravelItinerary2.TravelItineraryReadRQMessagingDetailsTransactionCode.PNR;


            //for (int i = 0; i < GEAServices.Split('|').Length; i++)
            //{
            //    if (GEAServices.Split('|')[i] == "HOT")
            //    {
            //        messagingDetails.Transaction[i] = new TravelItinerary2.TravelItineraryReadRQMessagingDetailsTransaction();
            //        messagingDetails.Transaction[i].Code = TravelItinerary2.TravelItineraryReadRQMessagingDetailsTransactionCode.HOT;
            //    }
            //    else if (GEAServices.Split('|')[i] == "CAR")
            //    {
            //        messagingDetails.Transaction[i] = new TravelItinerary2.TravelItineraryReadRQMessagingDetailsTransaction();
            //        messagingDetails.Transaction[i].Code = TravelItinerary2.TravelItineraryReadRQMessagingDetailsTransactionCode.CAR;
            //    }
            //}

            TravelItinerary.TravelItineraryReadRQ req = new TravelItinerary.TravelItineraryReadRQ();
            //TravelItinerary.OTA_TravelItineraryReadRQPOS pos = new TravelItinerary.OTA_TravelItineraryReadRQPOS();
            //TravelItinerary.OTA_TravelItineraryReadRQPOSSource source = new TravelItinerary.OTA_TravelItineraryReadRQPOSSource();
            //source.PseudoCityCode = ipcc;
            //pos.Source = source;
            //req.POS = pos;
            req.TimeStamp = DateTime.Now;
            req.TimeStampSpecified = true;
            req.MessagingDetails = messagingDetails;
            req.Version = "2.2.0";	// Specify the service version

            //TravelItinerary.OTA_TravelItineraryReadRQTPA_Extensions tpa = new TravelItinerary.OTA_TravelItineraryReadRQTPA_Extensions();
            //TravelItinerary.OTA_TravelItineraryReadRQTPA_ExtensionsMessagingDetails msj = new TravelItinerary.OTA_TravelItineraryReadRQTPA_ExtensionsMessagingDetails();
            //TravelItinerary.OTA_TravelItineraryReadRQTPA_ExtensionsMessagingDetailsMDRSubset code = new TravelItinerary.OTA_TravelItineraryReadRQTPA_ExtensionsMessagingDetailsMDRSubset();

            //code.Code = "PN43";
            //msj.MDRSubset = code;
            //tpa.MessagingDetails = msj;
            //req.TPA_Extensions = tpa;

            TravelItinerary.TravelItineraryReadRQUniqueID uniqueID = new TravelItinerary.TravelItineraryReadRQUniqueID();
            uniqueID.ID = RecLoc;
            req.UniqueID = uniqueID;


            TravelItinerary.TravelItineraryReadService serviceObj = new TravelItinerary.TravelItineraryReadService();
            serviceObj.MessageHeaderValue = msgHeader;
            serviceObj.Security = security;

            //System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(req.GetType());
            //System.IO.StreamWriter file = new System.IO.StreamWriter(@"c:\RESP\otatravelItineraryHotelReq " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
            //writer.Serialize(file, req);
            //file.Close();


            //Call the service and assign the response object.
            TravelItinerary.TravelItineraryReadRS resp = serviceObj.TravelItineraryReadRQ(req);		// Send the request.

            //Retrieve data from the resp object, such as flight number and airline code, and display
            //it on standard output. the client can retrieve other data from the response the same wayi.

            #endregion
            return resp;
        }
    }
}