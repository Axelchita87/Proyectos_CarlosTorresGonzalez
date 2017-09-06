#if (VOLARIS_PRODUCTION)
using MyCTS.Services.com.sabre.webservices.TravelItinerary2;
#else
using MyCTS.Services.com.sabre.webservices.TravelItinerary2.dev;
#endif
using System;
using System.Collections.Generic;

namespace MyCTS.Services.Contracts
{

    public class OTATravelItinerary
    {

        #region ====== ClassObject ======

        public class OTATravelItineraryObject
        {
            private string response;
            public string Response
            {
                get { return response; }
                set { response = value; }
            }

            private string segmentcount;
            public string SegmentCount
            {
                get { return segmentcount; }
                set { segmentcount = value; }
            }

            private string farebasis;
            public string FareBasis
            {
                get { return farebasis; }
                set { farebasis = value; }
            }

            private string location_dk;
            public string Location_DK
            {
                get { return location_dk; }
                set { location_dk = value; }
            }

            private string pcc;
            public string PCC
            {
                get { return pcc; }
                set { pcc = value; }
            }

            private string segmenttype;
            public string SegmentType
            {
                get { return segmenttype; }
                set { segmenttype = value; }
            }

            private string idgroup;
            public string IDGroup
            {
                get { return idgroup; }
                set { idgroup = value; }
            }

            private bool status;
            public bool Status
            {
                get { return status; }
                set { status = value; }
            }

            public List<string> DepartureAirportList = null;
            public List<string> ArrivalAirportList = null;
            public List<string> DepartureDateTimeList = null;
            public List<string> ArrivalDateTimeList = null;
            public List<string> MarketingAirlineList = null;
            public List<string> FlightNumberList = null;
            public List<string> DepartureDateList = null;
            public List<string> AirlineRefList = null;
            public List<string> FareBasisCodeList = null;
            public List<string> PassengerTypeList = null;
            public List<string> GivenNameList = null;
            public List<string> SurnameList = null;
            public List<string> PaxNumberList = null;

        }

        #endregion

        #region ====== Method which obtains PNR's information ======

        /// <summary>
        /// Realiza la conexón al servicio web que despliega los detalles de un record
        /// y obtiene los valores necasarios para el cálculo de cargo por servicio y para 
        /// la sabana de vuelo
        /// </summary>
        /// <param name="convid">Id de convención</param>
        /// <param name="ipcc">Pseudo que demanda el servicio</param>
        /// <param name="securitytoken">Codogo que permite el consumo del Web service</param>
        /// <param name="RecLoc">PNR a documentar</param>
        /// <returns></returns>
        public OTATravelItineraryObject TravelItineraryMethod(string convid, string ipcc, string securitytoken, string RecLoc)
        {
            //Objeto que contien toda la infomación que se requiere para el cargo por servicio 
            //y para la sabana de vuelo
            OTATravelItineraryObject itineraryObject = new OTATravelItineraryObject();

            try
            {
                #region ====== Connection with web service ======

                itineraryObject.Status = true;
                DateTime dt = DateTime.UtcNow;
                string tstamp = dt.ToString("s") + "Z";

                MessageHeader msgHeader = new MessageHeader();
                msgHeader.ConversationId = convid;		// Put ConversationId in req header

                From from = new From();
                PartyId fromPartyId = new PartyId();
                PartyId[] fromPartyIdArr = new PartyId[1];
                fromPartyId.Value = "99999";
                fromPartyIdArr[0] = fromPartyId;
                from.PartyId = fromPartyIdArr;
                msgHeader.From = from;

                To to = new To();
                PartyId toPartyId = new PartyId();
                PartyId[] toPartyIdArr = new PartyId[1];
                toPartyId.Value = "123123";
                toPartyIdArr[0] = toPartyId;
                to.PartyId = toPartyIdArr;
                msgHeader.To = to;

                msgHeader.CPAId = ipcc;
                msgHeader.Action = "TravelItineraryReadLLSRQ";
                Service service = new Service();
                service.Value = "Travel Itinerary Read";
                msgHeader.Service = service;


                MessageData msgData = new MessageData();
                msgData.MessageId = "mid:20001209-133003-2333@clientofsabre.com";
                msgData.Timestamp = tstamp;
                msgHeader.MessageData = msgData;
                Security1 security = new Security1();
                security.BinarySecurityToken = securitytoken;	// Put BinarySecurityToken in req header

                TravelItineraryReadRQMessagingDetails messageDetails = new TravelItineraryReadRQMessagingDetails();
                messageDetails.Transaction = new TravelItineraryReadRQMessagingDetailsTransaction[]{
                    new TravelItineraryReadRQMessagingDetailsTransaction(){
                        Code = TravelItineraryReadRQMessagingDetailsTransactionCode.PNR
                    }
                };

                //Create the request object req and the value for the IPCC in the payload of the request.

                TravelItineraryReadRQ req = new TravelItineraryReadRQ();
                //OTA_TravelItineraryReadRQ req2 = new OTA_TravelItineraryReadRQ();
                //OTA_TravelItineraryReadRQPOS pos = new OTA_TravelItineraryReadRQPOS();
                //OTA_TravelItineraryReadRQPOSSource source = new OTA_TravelItineraryReadRQPOSSource();
                //source.PseudoCityCode = ipcc;
                //pos.Source = source;
                //req.POS = pos;
                req.Version = "2.2.0";	// Specify the service version

                //OTA_TravelItineraryReadRQTPA_Extensions tpa = new OTA_TravelItineraryReadRQTPA_Extensions();
                //OTA_TravelItineraryReadRQTPA_ExtensionsMessagingDetails msj = new OTA_TravelItineraryReadRQTPA_ExtensionsMessagingDetails();
                //OTA_TravelItineraryReadRQTPA_ExtensionsMessagingDetailsMDRSubset code = new OTA_TravelItineraryReadRQTPA_ExtensionsMessagingDetailsMDRSubset();

                //code.Code = "PN43";
                //msj.MDRSubset = code;
                //tpa.MessagingDetails = msj;
                //req.TPA_Extensions = tpa;

                TravelItineraryReadRQUniqueID uniqueID = new TravelItineraryReadRQUniqueID();
                uniqueID.ID = RecLoc;
                req.UniqueID = uniqueID;
                req.MessagingDetails = messageDetails;
                req.TimeStamp = DateTime.Now;
                req.TimeStampSpecified = true;

                TravelItineraryReadService serviceObj = new TravelItineraryReadService();
                serviceObj.MessageHeaderValue = msgHeader;
                serviceObj.Security = security;
                //Call the service and assign the response object.
                TravelItineraryReadRS resp = serviceObj.TravelItineraryReadRQ(req);		// Send the request.

                //Retrieve data from the resp object, such as flight number and airline code, and display
                //it on standard output. the client can retrieve other data from the response the same way.

                #endregion

                #region ======== Parsing of the information ======

                if (resp.ApplicationResults.Error != null)
                {
                    foreach (ProblemInformation error in resp.ApplicationResults.Error)
                    {
                        foreach (SystemSpecificResults systemSpecificResults in error.SystemSpecificResults)
                        {
                            foreach (MessageCondition message in systemSpecificResults.Message)
                            {
                                if (!string.IsNullOrEmpty(itineraryObject.Response))
                                {
                                    itineraryObject.Response = string.Concat(itineraryObject.Response, ", ");
                                }

                                itineraryObject.Response = string.Concat(itineraryObject.Response, message.Value);
                                itineraryObject.Status = false;
                            }
                        }
                    }
                }

                else
                {
                    #region ====== Instanciar Variables ======

                    itineraryObject.DepartureAirportList = new List<string>();
                    itineraryObject.ArrivalAirportList = new List<string>();
                    itineraryObject.DepartureDateTimeList = new List<string>();
                    itineraryObject.ArrivalDateTimeList = new List<string>();
                    itineraryObject.MarketingAirlineList = new List<string>();
                    itineraryObject.FlightNumberList = new List<string>();
                    itineraryObject.DepartureDateList = new List<string>();
                    itineraryObject.AirlineRefList = new List<string>();
                    itineraryObject.PassengerTypeList = new List<string>();
                    itineraryObject.FareBasisCodeList = new List<string>();
                    itineraryObject.GivenNameList = new List<string>();
                    itineraryObject.SurnameList = new List<string>();
                    itineraryObject.PaxNumberList = new List<string>();

                    #endregion

                    //////////////////////////////////////////////////////////////
                    //Se obtine infomacion de los segmentos contenidos en el PNR//
                    //////////////////////////////////////////////////////////////
                    if (resp.TravelItinerary.ItineraryInfo.ReservationItems != null)
                        for (int i = 0; i < resp.TravelItinerary.ItineraryInfo.ReservationItems.Length; i++)
                        {
                            if (resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment != null)
                            {
                                if (string.IsNullOrEmpty(itineraryObject.SegmentType))
                                    itineraryObject.SegmentType = "Air";
                                else if (!itineraryObject.SegmentType.Contains("Air"))
                                    itineraryObject.SegmentType = string.Concat(itineraryObject.SegmentType, " ", "Air");
                                itineraryObject.DepartureAirportList.Add(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].OriginLocation.LocationCode);
                                itineraryObject.ArrivalAirportList.Add(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].DestinationLocation.LocationCode);
                                itineraryObject.DepartureDateTimeList.Add(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].DepartureDateTime.Substring(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].DepartureDateTime.Length - 5, 5));
                                itineraryObject.ArrivalDateTimeList.Add(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].ArrivalDateTime.Substring(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].ArrivalDateTime.Length - 5, 5));
                                itineraryObject.MarketingAirlineList.Add(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].MarketingAirline.Code);
                                itineraryObject.FlightNumberList.Add(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].FlightNumber);
                                itineraryObject.DepartureDateList.Add(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].DepartureDateTime);
                                try
                                {
                                    if (resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].SupplierRef.ID.Contains("*"))
                                        itineraryObject.AirlineRefList.Add(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].SupplierRef.ID.Substring(5, 6));
                                    else
                                        itineraryObject.AirlineRefList.Add(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].SupplierRef.ID);
                                }
                                catch
                                {
                                    itineraryObject.AirlineRefList.Add(null);
                                }

                            }
                            else if (resp.TravelItinerary.ItineraryInfo.ReservationItems[i].AirTaxi != null)
                            {
                                if (string.IsNullOrEmpty(itineraryObject.SegmentType))
                                    itineraryObject.SegmentType = "AirTaxi";
                                else if (!itineraryObject.SegmentType.Contains("AirTaxi"))
                                    itineraryObject.SegmentType = string.Concat(itineraryObject.SegmentType, " ", "AirTaxi");
                            }
                            else if (resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Cruise != null)
                            {
                                if (string.IsNullOrEmpty(itineraryObject.SegmentType))
                                    itineraryObject.SegmentType = "Cruise";
                                else if (!itineraryObject.SegmentType.Contains("Cruise"))
                                    itineraryObject.SegmentType = string.Concat(itineraryObject.SegmentType, " ", "Cruise");
                            }
                            else if (resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Hotel != null)
                            {
                                if (string.IsNullOrEmpty(itineraryObject.SegmentType))
                                    itineraryObject.SegmentType = "Hotel";
                                else if (!itineraryObject.SegmentType.Contains("Hotel"))
                                    itineraryObject.SegmentType = string.Concat(itineraryObject.SegmentType, " ", "Hotel");
                            }
                            else if (resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Insurance != null)
                            {
                                if (string.IsNullOrEmpty(itineraryObject.SegmentType))
                                    itineraryObject.SegmentType = "Insurance";
                                else if (!itineraryObject.SegmentType.Contains("Insurance"))
                                    itineraryObject.SegmentType = string.Concat(itineraryObject.SegmentType, " ", "Insurance");
                            }
                            else if (resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Rail != null)
                            {
                                if (string.IsNullOrEmpty(itineraryObject.SegmentType))
                                    itineraryObject.SegmentType = "Rail";
                                else if (!itineraryObject.SegmentType.Contains("Rail"))
                                    itineraryObject.SegmentType = string.Concat(itineraryObject.SegmentType, " ", "Rail");
                            }
                            else if (resp.TravelItinerary.ItineraryInfo.ReservationItems[i].RPH != null)
                            {
                                if (string.IsNullOrEmpty(itineraryObject.SegmentType))
                                    itineraryObject.SegmentType = "RPH";
                                else if (!itineraryObject.SegmentType.Contains("RPH"))
                                    itineraryObject.SegmentType = string.Concat(itineraryObject.SegmentType, " ", "RPH");
                            }
                            else if (resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Surface != null)
                            {
                                if (string.IsNullOrEmpty(itineraryObject.SegmentType))
                                    itineraryObject.SegmentType = "Surface";
                                else if (!itineraryObject.SegmentType.Contains("Surface"))
                                    itineraryObject.SegmentType = string.Concat(itineraryObject.SegmentType, " ", "Surface");
                            }
                            else if (resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Tour != null)
                            {
                                if (string.IsNullOrEmpty(itineraryObject.SegmentType))
                                    itineraryObject.SegmentType = "Tour";
                                else if (!itineraryObject.SegmentType.Contains("Tour"))
                                    itineraryObject.SegmentType = string.Concat(itineraryObject.SegmentType, " ", "Tour");
                            }
                            else if (resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle != null)
                            {
                                if (string.IsNullOrEmpty(itineraryObject.SegmentType))
                                    itineraryObject.SegmentType = "Vehicle";
                                else if (!itineraryObject.SegmentType.Contains("Vehicle"))
                                    itineraryObject.SegmentType = string.Concat(itineraryObject.SegmentType, " ", "Vehicle");
                            }

                        }

                    ///////////////////////////////////////////////////////////
                    //Se obtiene el número de segmentos en el Record//
                    ///////////////////////////////////////////////////////////
                    itineraryObject.SegmentCount = Convert.ToString(itineraryObject.DepartureAirportList.Count);

                    ///////////////////////////////////////
                    //Se obtiene el fare basis code//
                    ///////////////////////////////////////
                    try
                    {
                        for (int k = 0; k < resp.TravelItinerary.ItineraryInfo.ItineraryPricing.PriceQuote.Length; k++)
                        {
                            if (resp.TravelItinerary.ItineraryInfo.ItineraryPricing.PriceQuote[k].PricedItinerary[0].AirItineraryPricingInfo.PTC_FareBreakdown[0].FareBasis != null)
                                itineraryObject.FareBasisCodeList.Add(Convert.ToString(resp.TravelItinerary.ItineraryInfo.ItineraryPricing.PriceQuote[k].PricedItinerary[0].AirItineraryPricingInfo.PTC_FareBreakdown[0].FareBasis[0]));
                        }
                    }
                    catch { }

                    if (itineraryObject.FareBasisCodeList.Count > 0)
                    {
                        int auxiliar = itineraryObject.FareBasisCodeList.Count - 1;
                        string[] fare = itineraryObject.FareBasisCodeList[auxiliar].Split(new char[] { ('/') });
                        for (int a = 0; a < fare.Length - 1; a++)
                            for (int k = a + 1; k < fare.Length; k++)
                                if ((fare[a] == ""))
                                    break;
                                else if (fare[a] == fare[k])
                                    fare[k] = "";

                        foreach (string auxi in fare)
                            if (!string.IsNullOrEmpty(auxi))
                                itineraryObject.FareBasis = string.Concat(itineraryObject.FareBasis, " ", auxi).Trim();

                    }

                    ///////////////////////////////////////////
                    //Se obtiene información de los pasajeros//
                    ///////////////////////////////////////////
                    string temp = string.Empty;
                    if (resp.TravelItinerary.CustomerInfo.PersonName[0].GroupInfo != null
                        && resp.TravelItinerary.CustomerInfo.PersonName[0].GroupInfo.Name != null)
                    {
                        itineraryObject.IDGroup = resp.TravelItinerary.CustomerInfo.PersonName[0].GroupInfo.Name;
                        for (int j = 1; j < resp.TravelItinerary.CustomerInfo.PersonName.Length; j++)
                        {
                            try
                            {
                                itineraryObject.PassengerTypeList.Add(Convert.ToString(resp.TravelItinerary.CustomerInfo.PersonName[j].PassengerType));
                            }
                            catch
                            {
                                itineraryObject.PassengerTypeList.Add(string.Empty);
                            }
                            itineraryObject.GivenNameList.Add(resp.TravelItinerary.CustomerInfo.PersonName[j].GivenName);
                            itineraryObject.SurnameList.Add(resp.TravelItinerary.CustomerInfo.PersonName[j].Surname);
                            try
                            {
                                temp = resp.TravelItinerary.CustomerInfo.PersonName[j].NameNumber.Replace(".01", ".1");
                            }
                            catch
                            {
                                temp = string.Concat(Convert.ToString(j), ".1");
                            }
                            itineraryObject.PaxNumberList.Add(temp.TrimStart(new char[] { '0' }));
                        }

                    }
                    else
                        for (int j = 0; j < resp.TravelItinerary.CustomerInfo.PersonName.Length; j++)
                        {
                            itineraryObject.PassengerTypeList.Add(Convert.ToString(resp.TravelItinerary.CustomerInfo.PersonName[j].PassengerType));
                            itineraryObject.GivenNameList.Add(resp.TravelItinerary.CustomerInfo.PersonName[j].GivenName);
                            itineraryObject.SurnameList.Add(resp.TravelItinerary.CustomerInfo.PersonName[j].Surname);
                            try
                            {
                                temp = resp.TravelItinerary.CustomerInfo.PersonName[j].NameNumber.Replace(".01", ".1");
                                itineraryObject.PaxNumberList.Add(temp.TrimStart(new char[] { '0' }));
                            }
                            catch
                            {
                                itineraryObject.PaxNumberList.Add(string.Concat(Convert.ToString(j + 1), ".1"));
                            }
                        }


                    ///////////////////////
                    //Se obtiene DK y PCC//
                    ///////////////////////
                    itineraryObject.Location_DK = resp.TravelItinerary.ItineraryRef.CustomerIdentifier;
                    itineraryObject.PCC = resp.TravelItinerary.ItineraryRef.Source.PseudoCityCode;
                }

                #endregion

            }
            catch
            {
                itineraryObject.Status = false;
            }

            return itineraryObject;
        }

        #endregion
    }
}