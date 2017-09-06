using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using MyCTS.Business;
using MyCTS.Entities;
#if (VOLARIS_PRODUCTION)
using MyCTS.Services.AirLowFareSearch;
#else
using MyCTS.Services.LowFareSearchTest;
#endif



namespace MyCTS.Services.Contracts.Volaris
{
    /// <summary>
    /// 
    /// </summary>
    public class VolarisAvialabiltyService : ISabreService<List<IFlight>>
    {

        public AvailabilityRequest AvailabilityRequest { get; set; }
        #region Miembros de ISabreService<Flights>


        /// <summary>
        /// Gets the type of the passenger.
        /// </summary>
        /// <returns></returns>
        private OTA_AirLowFareSearchRQPriceRequestInformationOptionalQualifiersPricingQualifiersPassengerType[] GetPassengerType()
        {
            var passengerType =
                new List<OTA_AirLowFareSearchRQPriceRequestInformationOptionalQualifiersPricingQualifiersPassengerType>();
            if (AvailabilityRequest != null)
            {
                if (AvailabilityRequest.HasAdultOrSenior)
                {
                    passengerType.Add(new OTA_AirLowFareSearchRQPriceRequestInformationOptionalQualifiersPricingQualifiersPassengerType
                                          {
                                              Code = "ADT",
                                              Quantity =
                                                  AvailabilityRequest.TotalAdults.ToString(
                                                      CultureInfo.InvariantCulture)
                                          });
                }

                if (AvailabilityRequest.HasChild)
                {
                    passengerType.Add(new OTA_AirLowFareSearchRQPriceRequestInformationOptionalQualifiersPricingQualifiersPassengerType
                    {
                        Code = "CNN",
                        Quantity =
                            AvailabilityRequest.Pasengers.Child.Count.ToString(
                                CultureInfo.InvariantCulture)
                    });
                }

                if (AvailabilityRequest.HasInfant)
                {
                    passengerType.Add(new OTA_AirLowFareSearchRQPriceRequestInformationOptionalQualifiersPricingQualifiersPassengerType
                    {
                        Code = "INF",
                        Quantity =
                            AvailabilityRequest.Pasengers.Infant.Count.ToString(
                                CultureInfo.InvariantCulture)
                    });
                }
            }
            return passengerType.ToArray();
        }

        /// <summary>
        /// Creates the request.
        /// </summary>
        /// <returns></returns>
        private OTA_AirLowFareSearchRQ CreateRequest()
        {
            var request = new OTA_AirLowFareSearchRQ
            {
                POS = new OTA_AirLowFareSearchRQPOS
                {
                    Source = new OTA_AirLowFareSearchRQPOSSource
                    {
                        PseudoCityCode = VolarisResources.PseudoCodeCity
                    }
                },
                TimeStamp = DateTime.Now.ToString("s"),
                Version = VolarisResources.LowSearchFareServiceVersion,
                PriceRequestInformation = new OTA_AirLowFareSearchRQPriceRequestInformation()

            };
            return request;
        }

        /// <summary>
        /// Creates the optional qualifiers.
        /// </summary>
        /// <returns></returns>
        private OTA_AirLowFareSearchRQPriceRequestInformationOptionalQualifiers CreateOptionalQualifiers()
        {
            var qualifiers = new OTA_AirLowFareSearchRQPriceRequestInformationOptionalQualifiers
            {
                PricingQualifiers =
                    new OTA_AirLowFareSearchRQPriceRequestInformationOptionalQualifiersPricingQualifiers
                    {
                        CurrencyCode = "MXN",
                        PassengerType = GetPassengerType()
                    }
            };
            return qualifiers;
        }

        /// <summary>
        /// Generates the segments.
        /// </summary>
        /// <returns></returns>
        private OTA_AirLowFareSearchRQFlightSegment[] GenerateSegments()
        {
            var segmentToSearch = new OTA_AirLowFareSearchRQFlightSegment();
            segmentToSearch.ConnectionInd = "O";
            string dateTime = AvailabilityRequest.DepartureDateTime.ToString("MM-dd");
            string timeOfDay = AvailabilityRequest.DepartureDateTime.ToString("HH:mm:ss");
            segmentToSearch.DepartureDateTime = string.Format("{0}T{1}", dateTime, timeOfDay);
            segmentToSearch.ResBookDesigCode = "Y";

            segmentToSearch.OriginLocation = new OTA_AirLowFareSearchRQFlightSegmentOriginLocation { LocationCode = AvailabilityRequest.DepartureStation };
            segmentToSearch.DestinationLocation = new OTA_AirLowFareSearchRQFlightSegmentDestinationLocation { LocationCode = AvailabilityRequest.ArrivalStation };

            return new[] { segmentToSearch };
        }
        /// <summary>
        /// Calls this instance.
        /// </summary>
        /// <returns></returns>
        public List<IFlight> Call()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.ConversationID) && !string.IsNullOrEmpty(this.SecurityToken))
                {
                    var request = CreateRequest();
                    request.PriceRequestInformation.OptionalQualifiers = CreateOptionalQualifiers();
                    request.OriginDestinationInformation = GenerateSegments();

                    var service = new OTA_AirLowFareSearchService
                                      {
                                          MessageHeaderValue = this.GetMessageHeader(),
                                          SecurityValue = new Security
                                                              {
                                                                  BinarySecurityToken = this.SecurityToken
                                                              }
                                      };
                    Serializer.Serialize("OTA_AirLowFareSearchLLSRQ", request);
                    var response = service.OTA_AirLowFareSearchRQ(request);
                    Serializer.Serialize("OTA_AirLowFareSearchLLSRS", response);
                    if (response.Errors != null)
                    {
                        Success = false;
                        LogError(response.Errors.Error.ErrorInfo.Message);
                        ErrorMessage = "No se encontraron vuelos para esta ruta.";
                        return new List<IFlight>();
                    }
                    Success = true;
                    var flights = GetFlights(response);
                    return flights;
                }

            }
            catch (Exception exe)
            {
                Success = false;
                LogError(exe.Message);
                ErrorMessage = "No se encontraron vuelos para esta ruta.";
            }
            return new List<IFlight>();
        }

        private void LogError(string errorMessage)
        {
            var errorLog = new LowFareAirLinesError
            {
                Agent = "N/A",
                AirLine = LowFareAirLinesErrorLogger.Volaris,
                Date = DateTime.Now,
                ServiceName = "LowSearchService",
                ErrorMessage = errorMessage

            };
            LowFareAirLinesErrorLogger.Instance.Log(errorLog);
        }


        /// <summary>
        /// Gets the flight and segment.
        /// </summary>
        /// <param name="itinerary">The itinerary.</param>
        /// <returns></returns>
        private VolarisFlight GetFlightAndSegment(OTA_AirLowFareSearchRSPricedItinerary itinerary)
        {
            var volarisFlight = new VolarisFlight();
            volarisFlight.OwnerCompany = "Volaris";
            volarisFlight.DepartureStation = AvailabilityRequest.DepartureStation;
            volarisFlight.ArrivalStation = AvailabilityRequest.ArrivalStation;
            volarisFlight.TotalPrice = itinerary.TotalAmount;
            if (itinerary.AirItinerary != null)
            {
                var originsAndDestionations = itinerary.AirItinerary.OriginDestinationOptions;
                if (originsAndDestionations.Any())
                {
                    var pricingInfo =
                        itinerary.AirItineraryPricingInfo.FirstOrDefault(i => i.PassengerTypeQuantity.Code.Equals("ADT"));

                    if (pricingInfo != null)
                    {
                        if (pricingInfo.ItinTotalFare.EquivFare != null)
                        {

                            volarisFlight.BasePrice = Convert.ToDecimal(pricingInfo.ItinTotalFare.EquivFare.Amount);
                            volarisFlight.IsInternational = true;
                        }
                        else
                        {
                            volarisFlight.BasePrice = Convert.ToDecimal(pricingInfo.ItinTotalFare.BaseFare.Amount);
                        }
                    }
                    var segments = originsAndDestionations.SelectMany(o => o.FlightSegment);
                    if (segments.Any())
                    {

                        if (segments.Count() == 1)
                        {
                            var flightNumber = segments.FirstOrDefault().FlightNumber;
                            volarisFlight.ID = flightNumber;

                        }
                        foreach (var segment in segments)
                        {
                            if (DateTime.Now.Month - (Convert.ToInt32(segment.DepartureDateTime.Substring(0, 2))) <= 0)
                            {
                                volarisFlight.Segments.Add(new VolarisSegment
                                {
                                    ArrivalStation = segment.DestinationLocation.LocationCode,
                                    ArrivalTime = DateTime.ParseExact(segment.ArrivalDateTime, "MM-ddTHH:mm:ss", new CultureInfo("es-MX")),
                                    DepartureStation = segment.OriginLocation.LocationCode,
                                    DepartureTime = DateTime.ParseExact(segment.DepartureDateTime, "MM-ddTHH:mm:ss", new CultureInfo("es-MX")),
                                    ID = segment.FlightNumber,
                                    ClassOfService = segment.ResBookDesigCode,
                                    NumberInParty = AvailabilityRequest.TotalOfPassangers,
                                    Type = SegmentType.Normal,
                                });
                            }
                            else
                            {
                                volarisFlight.Segments.Add(new VolarisSegment
                                {
                                    ArrivalStation = segment.DestinationLocation.LocationCode,
                                    ArrivalTime = DateTime.ParseExact(segment.ArrivalDateTime, "MM-ddTHH:mm:ss", new CultureInfo("es-MX")).AddYears(1),
                                    DepartureStation = segment.OriginLocation.LocationCode,
                                    DepartureTime = (DateTime.ParseExact(segment.DepartureDateTime, "MM-ddTHH:mm:ss", new CultureInfo("es-MX"))).AddYears(1),
                                    ID = segment.FlightNumber,
                                    ClassOfService = segment.ResBookDesigCode,
                                    NumberInParty = AvailabilityRequest.TotalOfPassangers,
                                    Type = SegmentType.Normal,
                                });
                            }

                        }


                    }
                }

            }

            return volarisFlight;
        }

        /// <summary>
        /// Gets the passanger fares.
        /// </summary>
        /// <param name="itinerary">The itinerary.</param>
        /// <param name="volarisFlight"> </param>
        /// <returns></returns>
        private VolarisPassangerFares GetPassangerFares(OTA_AirLowFareSearchRSPricedItinerary itinerary, VolarisFlight volarisFlight)
        {
            var passangerFares = new VolarisPassangerFares();
            if (AvailabilityRequest.HasAdults)
            {
                SetPassangerFare(itinerary, passangerFares.Adult, "ADT", volarisFlight.IsInternational);
            }

            if (AvailabilityRequest.HasChild)
            {
                SetPassangerFare(itinerary, passangerFares.Child, "CNN", volarisFlight.IsInternational);
            }
            if (AvailabilityRequest.HasInfant)
            {
                passangerFares.Infant.Iva.Total = 0;
                passangerFares.Infant.Tua.Total = 0;
                passangerFares.Infant.Extra.Total = 0;
                passangerFares.Infant.Total = 0;
                passangerFares.Infant.Discount.Total = 0;
                passangerFares.Infant.PassangerType = VolarisPassangerType.Infant;
                passangerFares.Infant.Count = AvailabilityRequest.Pasengers.Infant.Count;
                //SetPassangerFare(itinerary, passangerFares.Infant, "INF", volarisFlight.IsInternational);passangerFares.Infant

            }
            return passangerFares;
        }

        private Dictionary<string, VolarisPassangerType> _passangerTypesContainer;
        /// <summary>
        /// Gets the passanger types container.
        /// </summary>
        private Dictionary<string, VolarisPassangerType> PassangerTypesContainer
        {
            get
            {
                return _passangerTypesContainer = (_passangerTypesContainer = new Dictionary<string, VolarisPassangerType>()
                                                                                  {
                                                                                      {"ADT",VolarisPassangerType.Adult},
                                                                                       {"CNN",VolarisPassangerType.Child},
                                                                                       {"INF",VolarisPassangerType.Infant},
                                                                                  });
            }
        }

        /// <summary>
        /// Sets the passanger fare.
        /// TODO: Verificar los impuestos por pasajeros para internacionales y nacionales.
        /// </summary>
        /// <param name="itinerary"> </param>
        /// <param name="passangerFare">The passanger fare.</param>
        /// <param name="passangerType">Type of the passanger.</param>
        /// <param name="isInternational"> </param>
        private void SetPassangerFare(OTA_AirLowFareSearchRSPricedItinerary itinerary, VolarisPassangerFare passangerFare, string passangerType, bool isInternational)
        {
            var itineraryPricingInfo =
                itinerary.AirItineraryPricingInfo.FirstOrDefault(
                    itin => itin.PassengerTypeQuantity.Code.Equals(passangerType));
            if (itineraryPricingInfo != null)
            {

                passangerFare.Count = Convert.ToInt16(itineraryPricingInfo.PassengerTypeQuantity.Quantity);
                var ivaTaxCodes = new[] { "MX" };
                var tuaTaxCodes = new[] { "XV" };
                var montoiva11TaxCodes = new[] { "SOV" };
                var iva11TaxCodes = new[] { "SNV" };
                var montoiva16TaxesCodes = new[] { "SCV" };
                var iva16TaxCodes = new[] { "SBV" };
                var taxCodeToIgnore = new[] { "MX", "XV", "SOV", "SNV", "SCV", "SBV" };
                if (isInternational)
                {

                    ivaTaxCodes = new[] { "XO" };
                    tuaTaxCodes = new[] { "XD", "US2" };
                    montoiva11TaxCodes = new[] { "SOV" };
                    iva11TaxCodes = new[] { "SNV" };
                    montoiva16TaxesCodes = new[] { "SCV" };
                    iva16TaxCodes = new[] { "SBV" };
                    taxCodeToIgnore = new[] { "XO", "XD", "US2", "SOV", "SNV", "SCV", "SBV" };
                    passangerFare.BasePrice.Total = Convert.ToDecimal(itineraryPricingInfo.ItinTotalFare.EquivFare.Amount) *
                                   passangerFare.Count;
                }
                else
                {
                    passangerFare.BasePrice.Total = Convert.ToDecimal(itineraryPricingInfo.ItinTotalFare.BaseFare.Amount) *
                                   passangerFare.Count;
                }
                var taxes = itineraryPricingInfo.ItinTotalFare.Taxes;
                passangerFare.Iva.Total = GetTaxes(ivaTaxCodes, taxes) * passangerFare.Count;
                passangerFare.Tua.Total = GetTaxes(tuaTaxCodes, taxes) * passangerFare.Count;
                passangerFare.Extra.Total = GetExtraTax(taxCodeToIgnore, taxes) * passangerFare.Count;
                passangerFare.TotalTaxes = taxes.Sum(tax => tax.Amount) * passangerFare.Count;
                passangerFare.MontoIVA11.Total = GetTaxes(montoiva11TaxCodes, taxes) * passangerFare.Count;
                passangerFare.IVA11.Total = GetTaxes(iva11TaxCodes, taxes) * passangerFare.Count;
                passangerFare.MontoIVA16.Total = GetTaxes(montoiva16TaxesCodes, taxes) * passangerFare.Count;
                passangerFare.IVA16.Total = GetTaxes(iva16TaxCodes, taxes) * passangerFare.Count;
                passangerFare.Total = Convert.ToDecimal(itineraryPricingInfo.ItinTotalFare.TotalFare.Amount) *
                      passangerFare.Count;

                if (PassangerTypesContainer.ContainsKey(passangerType))
                {
                    passangerFare.PassangerType = PassangerTypesContainer[passangerType];
                }

            }
        }
        /// <summary>
        /// Gets the tax.
        /// </summary>
        /// <param name="taxCode">The tax code.</param>
        /// <param name="taxes">The taxes.</param>
        /// <returns></returns>
        private decimal GetTax(string taxCode, IEnumerable<OTA_AirLowFareSearchRSPricedItineraryAirItineraryPricingInfoItinTotalFareTax> taxes)
        {
            var taxToSerch = taxes.FirstOrDefault(tax => tax.TaxCode.Equals(taxCode));

            if (taxToSerch != null)
            {
                return taxToSerch.Amount;

            }
            return 0;
        }

        private decimal GetTaxes(IEnumerable<string> taxesToSearch, IEnumerable<OTA_AirLowFareSearchRSPricedItineraryAirItineraryPricingInfoItinTotalFareTax> taxes)
        {
            return taxes.Where(t => taxesToSearch.Contains(t.TaxCode)).Sum(t => t.Amount);
        }
        /// <summary>
        /// Gets the tax.
        /// </summary>
        /// <param name="taxesToIgnore">The taxes to ignore.</param>
        /// <param name="taxes">The taxes.</param>
        /// <returns></returns>
        private decimal GetExtraTax(IEnumerable<string> taxesToIgnore, IEnumerable<OTA_AirLowFareSearchRSPricedItineraryAirItineraryPricingInfoItinTotalFareTax> taxes)
        {
            var taxesToSum = from tax in taxes
                             where !(from taxToIgnore in taxesToIgnore
                                     select taxToIgnore
                                    ).Contains(tax.TaxCode)
                             select tax;
            if (taxesToSum.Any())
            {
                return taxesToSum.Sum(t => t.Amount);
            }

            return 0;
        }
        /// <summary>
        /// Gets the flights.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns></returns>
        private List<IFlight> GetFlights(OTA_AirLowFareSearchRS response)
        {
            var volarisFlights = new List<IFlight>();
            if (response.PricedItineraries.Any())
            {
                foreach (var itinerary in response.PricedItineraries)
                {
                    var volarisFlight = GetFlightAndSegment(itinerary);
                    if (volarisFlight != null)
                    {
                        volarisFlight.PassangerFares = GetPassangerFares(itinerary, volarisFlight);
                        volarisFlights.Add(volarisFlight);
                    }
                }

            }
            return volarisFlights;
        }

        #endregion

        #region Miembros de ISabreService<Flights>
        /// <summary>
        /// Gets the message header.
        /// </summary>
        /// <returns></returns>
        private MessageHeader GetMessageHeader()
        {

            var messageHeader = new MessageHeader
            {
                ConversationId = "CurrentSession",
                From = new From
                {
                    PartyId = new[] {
                        new PartyId
                            {
                                 Value = "9999"
                            }
                                                                              
                    }
                },
                To = new To
                {

                    PartyId = new[]
                                                                    {
                                                                        new PartyId
                                                                            {
                                                                                Value = "123123"
                                                                            }
                                                                    }
                }
            };

            messageHeader.CPAId = "Y4";
            messageHeader.Action = "OTA_AirLowFareSearchLLSRQ";
            messageHeader.Service = new Service
            {
                Value = "OTA_AirLowFareSearchLLSRQ"
            };
            messageHeader.MessageData = new MessageData
            {
                MessageId = "mid:20001209-133003-2333@clientofsabre.com",
                Timestamp = string.Format("{0}", DateTime.Now.ToString("s"))
            };
            return messageHeader;
        }

        public string SecurityToken { get; set; }

        public string ConversationID { get; set; }

        #endregion

        #region Miembros de ISabreService<List<IFlight>>
        public bool Success { get; set; }

        public string ErrorMessage { get; set; }

        #endregion
    }
}
