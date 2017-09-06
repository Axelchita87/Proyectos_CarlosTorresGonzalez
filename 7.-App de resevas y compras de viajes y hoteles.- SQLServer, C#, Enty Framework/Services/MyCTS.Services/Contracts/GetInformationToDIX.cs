#if (VOLARIS_PRODUCTION)
using MyCTS.Services.com.sabre.webservices.TravelItinerary2;
#else
using MyCTS.Services.com.sabre.webservices.TravelItinerary2.dev;
#endif

using System;
using System.Collections.Generic;


namespace MyCTS.Services.Contracts
{
    public class GetInformationToDIX
    {
        public class GetInformationToDIXObject
        {
            private string response;
            public string Response
            {
                get { return response; }
                set { response = value; }
            }
            private string locationdk;
            public string LocationDK
            {
                get { return locationdk; }
                set { locationdk = value; }
            }
            private string agent;
            public string Agent
            {
                get { return agent; }
                set { agent = value; }
            }
            private bool status;
            public bool Status
            {
                get { return status; }
                set { status = value; }
            }
            public List<InformationItinerary> listItineraryInfo = null;
            public class InformationItinerary
            {
                public string segment;
                public string airline;
                public string origin;
                public string destination;
                public DateTime dateFlight;
                public DateTime dateArrival;
                public string timeArrival;
                public string timeDeparture;
                public string dayFlight;
                public string flightNumber;
                public bool escala;
                public string durationFlight;
                public string equipment;
                public string airlineRef;
                public string codeMeal;
                public string operatingAirline;
                public string terminalArrival;
                public string terminalDeparture;
                public string resBookDesigCode;
                public List<InformationSeatsPassenger> seatsNumber = null;

            }
            public List<InformationHotel> hotelList = null;
            public class InformationHotel
            {
                public string hotelName;
                public string hotelCityCode;
                public string chainCode;
                public List<string> address;
                public string phone;
                public string fax;
                public string confirmationNumber;
                public DateTime startDate;
                public string endDate;
                public string duration;
                public string roomNumbers;
                public string daysBeforeCancel;
                public string amount;
                public string correncyCode;
                public string shortText;
                public string specialPrefs;
                public string textAmount;
            }
            public List<InformationAuto> autoList = null;
            public class InformationAuto
            {
                public DateTime dateRent;
                public string locationCode;
                public string vendorCode;
                public string hourStart;
                public string dateReturnCar;
                public string mileage;
                public string confirmationNumber;
                public string equipType;
                public string kilometraje;
                public string amount1;
                public string amount2;
                public string corporateID;
                public string clientID;
                public string passengerName;
                public string specialEquip;
                public string phoneNumber;
            }
            public List<InformationPassenger> namePassengerList = null;
            public class InformationPassenger
            {
                public string paxNumber;
                public string paxName;
                public string paxRef;
                public List<string> custLoyalty;
            }
            public class InformationSeatsPassenger
            {
                public string paxNumber;
                public string seatNumber;
            }
            public List<InformationRemarks> remarksList = null;
            public class InformationRemarks
            {
                public string remark;
                public string segmentNumber;
            }
            public List<string> remarkInvoicesList = null;
            public List<InformationSegmentProtection> segmentProtectionList = null;
            public class InformationSegmentProtection
            {
                public string dateSegment;
                public string daySegment;
                public string locationCode;
                public string textSegment;
            }


        }

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
        public GetInformationToDIXObject TravelItineraryMethod(string convid, string ipcc, string securitytoken, string RecLoc)
        {
            //Objeto que contien toda la infomación que se requiere para el cargo por servicio 
            //y para la sabana de vuelo
            GetInformationToDIXObject itineraryObject = new GetInformationToDIXObject();

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
                    if (resp.TravelItinerary.CustomerInfo.PersonName[0].GroupInfo != null
                        && resp.TravelItinerary.CustomerInfo.PersonName[0].GroupInfo.Name != null)
                    //if (resp.TravelItinerary.CustomerInfos.CustomerInfo.Customer.PersonName[0].PassengerType == null)
                    {
                        itineraryObject.Response = "PNR OF GROUP";
                        return itineraryObject;
                    }
                    else
                    {
                        itineraryObject.namePassengerList = new List<GetInformationToDIXObject.InformationPassenger>();
                        for (int i = 0; i < resp.TravelItinerary.CustomerInfo.PersonName.Length; i++)
                        {
                            GetInformationToDIXObject.InformationPassenger item = new GetInformationToDIXObject.InformationPassenger();
                            item.custLoyalty = new List<string>();
                            item.paxName = string.Concat(resp.TravelItinerary.CustomerInfo.PersonName[i].Surname,
                                                        "/",
                                                        resp.TravelItinerary.CustomerInfo.PersonName[i].GivenName);
                            try
                            {
                                if (resp.TravelItinerary.CustomerInfo.PersonName[i].NameReference != null)
                                    item.paxRef = resp.TravelItinerary.CustomerInfo.PersonName[i].NameReference;
                                else
                                    item.paxRef = string.Empty;
                            }
                            catch
                            {
                                item.paxRef = string.Empty;
                            }
                            try
                            {
                                item.paxNumber = resp.TravelItinerary.CustomerInfo.PersonName[i].NameNumber;
                            }
                            catch
                            {
                                item.paxNumber = string.Concat(Convert.ToString(i + 1), ".1");
                            }
                            try
                            {
                                if (resp.TravelItinerary.CustomerInfo.CustLoyalty != null)
                                {
                                    for (int k = 0; k < resp.TravelItinerary.CustomerInfo.CustLoyalty.Length; k++)
                                        if (resp.TravelItinerary.CustomerInfo.CustLoyalty[k].NameNumber == item.paxNumber)
                                            item.custLoyalty.Add(string.Concat(resp.TravelItinerary.CustomerInfo.CustLoyalty[k].TravelingCarrierCode,
                                                "-", resp.TravelItinerary.CustomerInfo.CustLoyalty[k].MembershipID));
                                }
                            }
                            catch { }
                            itineraryObject.namePassengerList.Add(item);
                        }

                    }
                    itineraryObject.LocationDK = resp.TravelItinerary.ItineraryRef.CustomerIdentifier;
                    itineraryObject.Agent = resp.TravelItinerary.ItineraryRef.Source.CreationAgent.Substring(1, 2);

                    itineraryObject.listItineraryInfo = new List<GetInformationToDIXObject.InformationItinerary>();
                    itineraryObject.segmentProtectionList = new List<GetInformationToDIXObject.InformationSegmentProtection>();
                    itineraryObject.autoList = new List<GetInformationToDIXObject.InformationAuto>();
                    itineraryObject.hotelList = new List<GetInformationToDIXObject.InformationHotel>();
                    if (resp.TravelItinerary.ItineraryInfo.ReservationItems != null)
                    {
                        for (int i = 0; i < resp.TravelItinerary.ItineraryInfo.ReservationItems.Length; i++)
                        {
                            if (resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment != null)
                            {
                                GetInformationToDIXObject.InformationItinerary item = new GetInformationToDIXObject.InformationItinerary();
                                item.segment = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].SegmentNumber.TrimStart(new char[] { '0' });
                                item.airline = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].MarketingAirline.Code;
                                try
                                {
                                    if (resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].SupplierRef.ID.Contains("*"))
                                        item.airlineRef = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].SupplierRef.ID.Substring(5, 6);
                                    else
                                        item.airlineRef = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].SupplierRef.ID;
                                }
                                catch
                                {
                                    item.airlineRef = string.Empty;
                                }
                                if (resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].Meal != null)
                                {
                                    for (int j = 0; j < resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].Meal.Length; j++)
                                        if (!string.IsNullOrEmpty(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].Meal[j].Code))
                                            item.codeMeal = string.Concat(item.codeMeal, resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].Meal[j].Code).Trim();
                                }
                                else
                                    item.codeMeal = string.Empty;
                                item.dateFlight = Convert.ToDateTime(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].DepartureDateTime);
                                item.dayFlight = Convert.ToString(Convert.ToDateTime(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].DepartureDateTime).DayOfWeek);
                                item.dateArrival = DateTime.ParseExact(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].ArrivalDateTime, "MM-ddTHH:mm", System.Globalization.CultureInfo.CurrentCulture);
                                item.destination = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].DestinationLocation.LocationCode;
                                if (resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].ElapsedTime != null)
                                    item.durationFlight = string.Concat(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].ElapsedTime.Substring(0, 2),
                                        "HR ",
                                        resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].ElapsedTime.Substring(3, 2),
                                        "MIN");
                                else
                                    item.durationFlight = string.Empty;
                                if (resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].Equipment != null)
                                    item.equipment = string.Concat("EQP: ", resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].Equipment.AirEquipType);
                                else
                                    item.equipment = string.Empty;
                                if (resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].StopQuantity != null)
                                    item.escala = (resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].StopQuantity == "00") ? false : true;
                                else
                                    item.escala = false;
                                item.flightNumber = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].FlightNumber;
                                if (resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].OperatingAirline != null)
                                    item.operatingAirline = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].OperatingAirline[0].CompanyShortName;
                                else
                                    item.operatingAirline = string.Empty;
                                item.origin = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].OriginLocation.LocationCode;
                                item.resBookDesigCode = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].ResBookDesigCode;
                                item.terminalArrival = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].DestinationLocation.Terminal;
                                item.terminalDeparture = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].OriginLocation.Terminal;
                                item.timeArrival = DateTime.ParseExact(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].ArrivalDateTime, "MM-ddTHH:mm", System.Globalization.CultureInfo.CurrentCulture).ToString("HH:mm");
                                item.timeDeparture = Convert.ToDateTime(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].FlightSegment[0].DepartureDateTime).ToString("HH:mm");
                                itineraryObject.listItineraryInfo.Add(item);

                            }
                            else if (resp.TravelItinerary.ItineraryInfo.ReservationItems[i].MiscSegment != null)
                            {
                                GetInformationToDIXObject.InformationSegmentProtection item = new GetInformationToDIXObject.InformationSegmentProtection();
                                item.dateSegment = DateTime.ParseExact(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].MiscSegment.DepartureDateTime, "MM-dd", System.Globalization.CultureInfo.CurrentCulture).ToString("dd-MMM-yyyy").ToUpper();
                                item.daySegment = Convert.ToString(DateTime.ParseExact(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].MiscSegment.DepartureDateTime, "MM-dd", System.Globalization.CultureInfo.CurrentCulture).DayOfWeek);
                                item.locationCode = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].MiscSegment.OriginLocation.LocationCode;
                                if (resp.TravelItinerary.ItineraryInfo.ReservationItems[i].MiscSegment.Text != null)
                                    item.textSegment = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].MiscSegment.Text[0];
                                else
                                    item.textSegment = string.Empty;
                                itineraryObject.segmentProtectionList.Add(item);
                            }
                            else if (resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle != null)
                            {
                                GetInformationToDIXObject.InformationAuto item = new GetInformationToDIXObject.InformationAuto();
                                try
                                {
                                    item.dateRent = DateTime.ParseExact(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.VehRentalCore.PickUpDateTime, resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.VehRentalCore.PickUpDateTime.Length == 5 ? "MM-dd" : "MM-ddTHH:mm", System.Globalization.CultureInfo.CurrentCulture);
                                    if (item.dateRent.TimeOfDay.TotalSeconds == 0.0)
                                    {
                                        string aux = item.dateRent.ToString("dd-MM-yyyy");
                                        aux = string.Concat(aux, " 11:59:59");
                                        item.dateRent = Convert.ToDateTime(aux);
                                    }
                                }
                                catch
                                {
                                    item.dateRent = Convert.ToDateTime(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.VehRentalCore.PickUpDateTime.Substring(0, 10));
                                    if (item.dateRent.TimeOfDay.TotalSeconds == 0.0)
                                    {
                                        string aux = item.dateRent.ToString("dd-MM-yyyy");
                                        aux = string.Concat(aux, " 11:59:59");
                                        item.dateRent = Convert.ToDateTime(aux);
                                    }
                                }
                                try
                                {
                                    item.hourStart = DateTime.ParseExact(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.VehRentalCore.PickUpDateTime, resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.VehRentalCore.PickUpDateTime.Length == 5 ? "MM-dd" : "MM-ddTHH:mm", System.Globalization.CultureInfo.CurrentCulture).ToString("HH:mm");
                                }
                                catch
                                {
                                    try
                                    {
                                        item.hourStart = Convert.ToDateTime(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.VehRentalCore.PickUpDateTime.Substring(0, 19)).ToString("HH:mm");
                                    }
                                    catch
                                    {
                                        try
                                        {
                                            item.hourStart = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.VehRentalCore.PickUpDateTime.Substring(12, 3);
                                        }
                                        catch
                                        {
                                            item.hourStart = string.Empty;
                                        }
                                    }
                                }


                                item.locationCode = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.VehRentalCore.LocationDetails.LocationCode;
                                item.vendorCode = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.VehVendorAvail.Vendor.Code;
                                //item.hourStart = Convert.ToDateTime(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.VehRentalCore.PickUpDateTime).ToString("HH:mm");
                                item.dateReturnCar = string.Concat(DateTime.ParseExact(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.VehRentalCore.ReturnDateTime, resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.VehRentalCore.ReturnDateTime.Length == 5 ? "MM-dd" : "MM-ddTHH:mm", System.Globalization.CultureInfo.CurrentCulture).ToString("dd-MMM").ToUpper(),
                                    "/",
                                    DateTime.ParseExact(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.VehRentalCore.ReturnDateTime, resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.VehRentalCore.ReturnDateTime.Length == 5 ? "MM-dd" : "MM-ddTHH:mm", System.Globalization.CultureInfo.CurrentCulture).ToString("HH:mm"));
                                item.equipType = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.VehVendorAvail.VehResCore.PricedEquip.Equipment.EquipType;
                                item.confirmationNumber = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.ConfirmationNumber;
                                try
                                {
                                    item.mileage = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.VehVendorAvail.VehResCore.VehicleCharges.VehicleCharge.Mileage.ExtraMileageCharge;
                                }
                                catch
                                {
                                    item.mileage = string.Empty;
                                }
                                try
                                {
                                    for (int j = 0; j < resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.VehVendorAvail.VehResCore.VehicleCharges.VehicleCharge.ChargeDetails.Length; j++)
                                    {
                                        if (resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.VehVendorAvail.VehResCore.VehicleCharges.VehicleCharge.ChargeDetails[j].RateType == "WEEKLY RATE"
                                            || resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.VehVendorAvail.VehResCore.VehicleCharges.VehicleCharge.ChargeDetails[j].RateType == "DAILY RATE")
                                        {
                                            item.kilometraje = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.VehVendorAvail.VehResCore.VehicleCharges.VehicleCharge.ChargeDetails[j].Amount;
                                            break;
                                        }
                                    }
                                }
                                catch
                                {
                                    item.kilometraje = string.Empty;
                                }
                                try
                                {
                                    for (int j = 0; j < resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.VehVendorAvail.VehResCore.VehicleCharges.VehicleCharge.ChargeDetails.Length; j++)
                                    {
                                        if (resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.VehVendorAvail.VehResCore.VehicleCharges.VehicleCharge.ChargeDetails[j].RateType == "EXTRA DAY")
                                        {
                                            item.amount1 = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.VehVendorAvail.VehResCore.VehicleCharges.VehicleCharge.ChargeDetails[j].Amount;
                                            break;
                                        }
                                    }
                                }
                                catch
                                {
                                    item.amount1 = string.Empty;
                                }
                                try
                                {
                                    for (int j = 0; j < resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.VehVendorAvail.VehResCore.VehicleCharges.VehicleCharge.ChargeDetails.Length; j++)
                                    {
                                        if (resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.VehVendorAvail.VehResCore.VehicleCharges.VehicleCharge.ChargeDetails[j].RateType == "EXTRA HOUR")
                                        {
                                            item.amount2 = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.VehVendorAvail.VehResCore.VehicleCharges.VehicleCharge.ChargeDetails[j].Amount;
                                            break;
                                        }
                                    }
                                }
                                catch
                                {
                                    item.amount2 = string.Empty;
                                }
                                try
                                {
                                    item.corporateID = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.VehVendorAvail.VehResCore.RentalRate.Corporate.ID;
                                }
                                catch
                                {
                                    item.corporateID = string.Empty;
                                }
                                try
                                {
                                    item.clientID = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.VehVendorAvail.VehResCore.RentalRate.Client.ID;
                                }
                                catch
                                {
                                    item.clientID = string.Empty;
                                }
                                try
                                {
                                    foreach (TravelItineraryReadRSTravelItineraryCustomerInfoPersonName personname in resp.TravelItinerary.CustomerInfo.PersonName)
                                    {
                                        if (!string.IsNullOrEmpty(item.passengerName))
                                        {
                                            item.passengerName = string.Concat(item.passengerName, ", ");
                                        }

                                        item.passengerName = string.Concat(item.passengerName, personname.GivenName, " ", personname.Surname).Trim();
                                    }
                                }
                                catch
                                {
                                    item.passengerName = string.Empty;
                                }
                                try
                                {
                                    item.specialEquip = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.VehVendorAvail.VehResCore.PricedEquip.Equipment.SpecialEquip;
                                }
                                catch
                                {
                                    item.specialEquip = string.Empty;
                                }
                                try
                                {
                                    foreach (TravelItineraryReadRSTravelItineraryCustomerInfoContactNumber contactNumbers in resp.TravelItinerary.CustomerInfo.ContactNumbers)
                                    {
                                        if (!string.IsNullOrEmpty(item.phoneNumber))
                                        {
                                            item.phoneNumber = string.Concat(item.phoneNumber, ", ");
                                        }

                                        item.phoneNumber = string.Concat(item.phoneNumber, contactNumbers.Phone);
                                    }
                                }
                                catch
                                {
                                    item.phoneNumber = string.Empty;
                                }
                                itineraryObject.autoList.Add(item);
                            }
                            else if (resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Hotel != null)
                            {
                                GetInformationToDIXObject.InformationHotel item = new GetInformationToDIXObject.InformationHotel();
                                item.startDate = DateTime.ParseExact(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Hotel.TimeSpan.Start, "MM-dd", System.Globalization.CultureInfo.CurrentCulture);
                                if (item.startDate.TimeOfDay.TotalSeconds == 0.0)
                                {
                                    string aux = item.startDate.ToString("dd-MM-yyyy");
                                    aux = string.Concat(aux, " 11:59:59");
                                    item.startDate = Convert.ToDateTime(aux);
                                }
                                item.hotelCityCode = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Hotel.BasicPropertyInfo.HotelCityCode;
                                if (resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Hotel.BasicPropertyInfo.HotelName != null)
                                    item.hotelName = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Hotel.BasicPropertyInfo.HotelName;
                                else
                                    item.hotelName = string.Empty;
                                item.chainCode = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Hotel.BasicPropertyInfo.ChainCode;
                                item.endDate = DateTime.ParseExact(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Hotel.TimeSpan.End, "MM-dd", System.Globalization.CultureInfo.CurrentCulture).ToString("dd-MMM").ToUpper();
                                try
                                {
                                    item.duration = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Hotel.TimeSpan.Duration.TrimStart(new char[] { '0' });
                                }
                                catch
                                {
                                    DateTime start = DateTime.ParseExact(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Hotel.TimeSpan.Start, "MM-dd", System.Globalization.CultureInfo.CurrentCulture);
                                    DateTime end = DateTime.ParseExact(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Hotel.TimeSpan.End, "MM-dd", System.Globalization.CultureInfo.CurrentCulture);
                                    TimeSpan diference = end - start;
                                    item.duration = Convert.ToString(diference.Days);
                                }
                                if (resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Hotel.NumberOfUnits != null)
                                    item.roomNumbers = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Hotel.NumberOfUnits;
                                else
                                    item.roomNumbers = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Hotel.RoomRates.Rate.AdditionalGuestAmounts.NumExtraPersons.Length.ToString();
                                item.shortText = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Hotel.RoomRates.Rate.RoomTypeCode;
                                item.address = new List<string>();
                                try
                                {
                                    for (int j = 0; j < resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Hotel.BasicPropertyInfo.Address.AddressLine.Length; j++)
                                        item.address.Add(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Hotel.BasicPropertyInfo.Address.AddressLine[j]);
                                }
                                catch { }
                                try
                                {
                                    item.confirmationNumber = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Hotel.BasicPropertyInfo.ConfirmationNumber[0];
                                }
                                catch
                                {
                                    item.confirmationNumber = string.Empty;
                                }
                                item.amount = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Hotel.RoomRates.Rate.Amount;
                                try
                                {
                                    item.correncyCode = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Hotel.RoomRates.Rate.CurrencyCode;
                                }
                                catch
                                {
                                    item.correncyCode = string.Empty;
                                }
                                try
                                {
                                    item.daysBeforeCancel = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Hotel.BasicPropertyInfo.CancelPenalty[0].PolicyCode;
                                }
                                catch
                                {
                                    item.daysBeforeCancel = string.Empty;
                                }
                                try
                                {
                                    item.phone = string.Concat("FONE ", resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Hotel.BasicPropertyInfo.ContactNumbers.ContactNumber.Phone);
                                }
                                catch
                                {
                                    item.phone = string.Empty;
                                }
                                try
                                {
                                    item.fax = string.Concat("FAX  ", resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Hotel.BasicPropertyInfo.ContactNumbers.ContactNumber.Fax);
                                }
                                catch
                                {
                                    item.fax = string.Empty;
                                }
                                try
                                {
                                    item.specialPrefs = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Hotel.SpecialPrefs[0];
                                }
                                catch
                                {
                                    item.specialPrefs = string.Empty;
                                }
                                try
                                {
                                    item.textAmount = resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Hotel.Text[0];
                                }
                                catch
                                {
                                    item.textAmount = string.Empty;
                                }
                                itineraryObject.hotelList.Add(item);
                            }

                        }
                    }

                    foreach (TravelItineraryReadRSTravelItineraryItineraryInfoItem reservationItem in resp.TravelItinerary.ItineraryInfo.ReservationItems)
                    {
                        if (reservationItem.Seats != null)
                        {
                            foreach (TravelItineraryReadRSTravelItineraryItineraryInfoItemSeat seat in reservationItem.Seats)
                            {
                                for (int i = 0; i < itineraryObject.listItineraryInfo.Count; i++)
                                {
                                    if (seat.SegmentNumber.TrimStart(new char[] { '0' }) == itineraryObject.listItineraryInfo[i].segment)
                                    {
                                        GetInformationToDIXObject.InformationSeatsPassenger seatPax = new GetInformationToDIXObject.InformationSeatsPassenger();
                                        seatPax.paxNumber = seat.NameNumber;
                                        seatPax.seatNumber = seat.Number;
                                        if (itineraryObject.listItineraryInfo[i].seatsNumber == null)
                                        {
                                            itineraryObject.listItineraryInfo[i].seatsNumber = new List<GetInformationToDIXObject.InformationSeatsPassenger>();
                                        }
                                        itineraryObject.listItineraryInfo[i].seatsNumber.Add(seatPax);
                                        break;
                                    }
                                }
                            }
                        }
                    }

                    itineraryObject.remarksList = new List<GetInformationToDIXObject.InformationRemarks>();
                    itineraryObject.remarkInvoicesList = new List<string>();
                    if (resp.TravelItinerary.RemarkInfo != null)
                    {
                        for (int i = 0; i < resp.TravelItinerary.RemarkInfo.Length; i++)
                        {
                            if (resp.TravelItinerary.RemarkInfo[i].Type == "Itinerary")
                            {
                                GetInformationToDIXObject.InformationRemarks item =
                                    new GetInformationToDIXObject.InformationRemarks();
                                item.remark = resp.TravelItinerary.RemarkInfo[i].Text;
                                try
                                {
                                    item.segmentNumber = resp.TravelItinerary.RemarkInfo[i].SegmentNumber;
                                }
                                catch
                                {
                                    item.segmentNumber = string.Empty;
                                }
                                itineraryObject.remarksList.Add(item);
                            }
                            else if (resp.TravelItinerary.RemarkInfo[i].Type == "Client Address")
                            {
                                itineraryObject.remarkInvoicesList.Add(resp.TravelItinerary.RemarkInfo[i].Text);
                            }

                        }
                        if (itineraryObject.remarkInvoicesList.Count == 0)
                            for (int j = 0; j < resp.TravelItinerary.RemarkInfo.Length; j++)
                                if (resp.TravelItinerary.RemarkInfo[j].Type == "Delivery")
                                    itineraryObject.remarkInvoicesList.Add(resp.TravelItinerary.RemarkInfo[j].Text);
                    }


                }
                #endregion //Parsing of the information

            }
            catch
            {
                itineraryObject.Response = "ERROR EN LA LECTURA DEL RECORD, FAVOR DE REPORTARLO A SISTEMAS";
                itineraryObject.Status = false;
            }
            return itineraryObject;
        }
        #endregion //Method which obtains PNR's information
    }
}
