using System;
using System.Collections.Generic;
using MyCTS.Entities;
#if (VOLARIS_PRODUCTION)
using TravelItinerary = MyCTS.Services.com.sabre.webservices.TravelItinerary2;
using TravelItinerary2 = MyCTS.Services.com.sabre.webservices.TravelItinerary2;
#else
using TravelItinerary = MyCTS.Services.com.sabre.webservices.TravelItinerary2.dev;
using TravelItinerary2 = MyCTS.Services.com.sabre.webservices.TravelItinerary2.dev;
#endif
using MyCTS.Business;
using System.Configuration;
using System.Xml;

namespace MyCTS.Services.Contracts
{
    public class OTATravelItineraryHotels
    {
        #region propertis

        public List<string> remarobj = null;
        private string[] divide;
        private string status;
        private int index;
        private string chainCodeCancel;

        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        #endregion


        /// <summary>
        /// Gets the num cancel rec close.
        /// </summary>
        /// <param name="resp">The resp.</param>
        /// <param name="itineraryObject">The itinerary object.</param>
        /// <param name="recLog">The rec log.</param>
        public void getNumCancelRecClose(TravelItinerary.TravelItineraryReadRS resp, OTATravelItineraryObjectHotel itineraryObject, string recLog)
        {
            List<string> lstCancelRecClose = new List<string>();
            for (int k = 0; k < (resp.TravelItinerary.SpecialServiceInfo != null ? resp.TravelItinerary.SpecialServiceInfo.Length : 0); k++)
            {
                if (resp.TravelItinerary.SpecialServiceInfo[k].Service.Text.Length > 7)
                {
                    if (resp.TravelItinerary.SpecialServiceInfo[k].Service.Text[0].Substring(3, 3).ToString() == "HHL")
                    {
                        if (resp.TravelItinerary.SpecialServiceInfo[k].Service.SSR_Code == "OSI")
                        {
                            index = resp.TravelItinerary.SpecialServiceInfo[k].Service.Text[0].IndexOf("/CX-");
                        }
                        if (index > 0)
                        {
                            chainCodeCancel = resp.TravelItinerary.SpecialServiceInfo[k].Service.Text[0].Split(' ')[2].ToString();
                            itineraryObject.Status = "1";
                            itineraryObject.CancelNumberList.Add(chainCodeCancel + "/" + resp.TravelItinerary.SpecialServiceInfo[k].Service.Text[0].Split('/')[1].ToString());
                            itineraryObject.Record = string.IsNullOrEmpty(resp.TravelItinerary.ItineraryRef.ID) ? recLog : resp.TravelItinerary.ItineraryRef.ID;
                        }
                    }
                }

            }
            itineraryObject.Status = "1";
            itineraryObject.Record = string.IsNullOrEmpty(resp.TravelItinerary.ItineraryRef.ID) ? recLog : resp.TravelItinerary.ItineraryRef.ID;
        }

        public List<OTATravelItineraryObjectHotel> getHotelValues(string convid, string ipcc, string securitytoken, string RecLoc, string sixReceived, string agente, string mail, string RFC, List<string> lstcommission, string PNRDataHotel, string PNRDataCar)
        {
            List<OTATravelItineraryObjectHotel> myObect = new List<OTATravelItineraryObjectHotel>();
            OTATravelItineraryObjectHotel itineraryObject = null;
            string errorMessage = string.Empty;
            try
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

                XmlDocument doc = Serialize(resp);
                doc = Serialize(req);

                //Retrieve data from the resp object, such as flight number and airline code, and display
                //it on standard output. the client can retrieve other data from the response the same wayi.

                #endregion

                string typeCar = string.Empty; ;
                string codeCityIti = string.Empty;
                string codeCityDB = string.Empty;
                chainCodeCancel = string.Empty;
                TimeSpan ts = new TimeSpan();

                //////////////////////////////////////////////////////////////
                //Validacion de errores en al conexion del web service//
                //////////////////////////////////////////////////////////////
                if (resp.ApplicationResults.Error == null)
                {
                    //////////////////////////////////////////////////////////////
                    //Se obtine infomacion del PNR//
                    //////////////////////////////////////////////////////////////

                    if (resp.TravelItinerary.ItineraryInfo.ReservationItems != null)
                    {
                        for (int i = 0; i < resp.TravelItinerary.ItineraryInfo.ReservationItems.Length; i++)
                        {
                            itineraryObject = new OTATravelItineraryObjectHotel();
                            itineraryObject.CancelNumberList = new List<string>();
                            getNumCancelRecClose(resp, itineraryObject, string.IsNullOrEmpty(resp.TravelItinerary.ItineraryRef.ID) ? RecLoc : resp.TravelItinerary.ItineraryRef.ID);

                            string commision = string.Empty;

                            if (lstcommission.Count > 1)
                                commision = lstcommission[i];
                            else
                                commision = "10";

                            itineraryObject.Prov_Direct_Pay = true;

                            string dk = string.Empty;

                            dk = resp.TravelItinerary.ItineraryRef.CustomerIdentifier.ToUpper();

                            string phone = string.Empty;

                            foreach (TravelItinerary2.TravelItineraryReadRSTravelItineraryCustomerInfoContactNumber contactNumber in resp.TravelItinerary.CustomerInfo.ContactNumbers)
                            {
                                if (!string.IsNullOrEmpty(phone))
                                {
                                    phone = string.Concat(phone, ", ");
                                }
                                phone = string.Concat(phone, contactNumber.Phone);
                            }

                            string passengerType = string.Empty;
                            int passengerNum = 0;

                            for (int cusNum = 0; cusNum < resp.TravelItinerary.CustomerInfo.PersonName.Length; cusNum++)
                            {
                                if (!string.IsNullOrEmpty(resp.TravelItinerary.CustomerInfo.PersonName[cusNum].PassengerType))
                                {

                                    if (resp.TravelItinerary.CustomerInfo.PersonName[cusNum].PassengerType.Length > 0)
                                    {
                                        passengerType = "|" + resp.TravelItinerary.CustomerInfo.PersonName[cusNum].PassengerType;
                                        passengerNum = cusNum + 1;

                                    }
                                    else
                                        passengerType = string.Empty; //numero de pasajeros
                                }
                                else
                                {
                                    passengerType = string.Empty;
                                }

                            }

                            string passengerName = string.Empty;
                            string title = string.Empty;

                            divide = resp.TravelItinerary.CustomerInfo.PersonName[0].GivenName.Split("".ToCharArray());

                            if (divide.Length > 1)
                            {
                                passengerName = resp.TravelItinerary.CustomerInfo.PersonName[0].GivenName.Substring(0, resp.TravelItinerary.CustomerInfo.PersonName[0].GivenName.Length - 3);
                                title = divide[divide.Length - 1];
                            }
                            else
                            {
                                passengerName = resp.TravelItinerary.CustomerInfo.PersonName[0].GivenName;
                                title = string.Empty;
                            }

                            string passengerSurname = string.Empty;

                            passengerSurname = resp.TravelItinerary.CustomerInfo.PersonName[0].Surname;

                            if (resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Hotel != null && string.IsNullOrEmpty(PNRDataHotel))
                            {

                                if (resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Hotel.Status == "HK" || resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Hotel.Status == "GK")
                                {
                                    itineraryObject = GetHotel(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Hotel, commision, dk, phone, RFC, agente, mail,
                                        sixReceived, passengerType, passengerNum, passengerName, title, passengerSurname, itineraryObject.Status, itineraryObject.CancelNumberList);
                                    itineraryObject.Record = string.IsNullOrEmpty(resp.TravelItinerary.ItineraryRef.ID) ? string.Concat(RecLoc, "|HOTEL") : string.Concat(resp.TravelItinerary.ItineraryRef.ID, "|HOTEL");
                                }
                                else
                                {
                                    errorMessage = string.Concat("Error MyCTS: Segmento ", resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Hotel.SegmentNumber, " en status ", resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Hotel.Status);
                                }

                            }
                            else if (resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle != null && string.IsNullOrEmpty(PNRDataCar))
                            {
                                if (resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.Status == "HK" || resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.Status == "GK")
                                {
                                    itineraryObject = GetCars(resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle, commision, dk, phone, RFC, agente, mail,
                                        sixReceived, passengerType, passengerNum, passengerName, title, passengerSurname, itineraryObject.Status, itineraryObject.CancelNumberList);
                                    itineraryObject.Record = string.IsNullOrEmpty(resp.TravelItinerary.ItineraryRef.ID) ? string.Concat(RecLoc, "|CAR") : string.Concat(resp.TravelItinerary.ItineraryRef.ID, "|CAR");
                                }
                                else
                                {
                                    errorMessage = string.Concat("Error MyCTS: Segmento ", resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.SegmentNumber, " en status ", resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle.Status);
                                }
                            }
                            else
                            {
                                if (itineraryObject != null)
                                {
                                    if (itineraryObject.CancelNumberList.Count < 0)//cuando el records es nuevo y no tiene cancelaciones
                                    {
                                        if (!string.IsNullOrEmpty(itineraryObject.Confirmation_Number))//valida si la clave de confirmacion del hotel no fue asignada al segmento

                                            myObect.Add(itineraryObject);
                                    }
                                    else
                                        if (myObect.Count == 0)//itinerario basio solo para leera el estatus y los numeros de cancelacion
                                        {
                                            if (!string.IsNullOrEmpty(itineraryObject.Confirmation_Number))
                                                myObect.Add(itineraryObject);
                                        }

                                }
                            }

                            if (resp.TravelItinerary.ItineraryInfo.ReservationItems.Length > 0 &&//cuando el record tiene cancelaciones
                            resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Hotel != null)
                            {
                                if (!string.IsNullOrEmpty(itineraryObject.Confirmation_Number))
                                    myObect.Add(itineraryObject);
                            }
                            else if (resp.TravelItinerary.ItineraryInfo.ReservationItems.Length > 0 &&//cuando el record tiene cancelaciones
                          resp.TravelItinerary.ItineraryInfo.ReservationItems[i].Vehicle != null)
                            {
                                if (!string.IsNullOrEmpty(itineraryObject.Confirmation_Number))
                                    myObect.Add(itineraryObject);
                            }
                        }

                    }
                }
                else
                {
                    foreach (TravelItinerary2.ProblemInformation error in resp.ApplicationResults.Error)
                    {
                        foreach (TravelItinerary2.SystemSpecificResults systemSpecificResults in error.SystemSpecificResults)
                        {
                            foreach (TravelItinerary2.MessageCondition message in systemSpecificResults.Message)
                            {
                                if (!string.IsNullOrEmpty(errorMessage))
                                {
                                    errorMessage = string.Concat(errorMessage, ", ");
                                }
                                else
                                {
                                    errorMessage = "Error MyCTS: ";
                                }
                                errorMessage = string.Concat(errorMessage, message.Value);
                            }
                        }
                    }
                }
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    itineraryObject = new OTATravelItineraryObjectHotel();
                    itineraryObject.errorWSSabre = errorMessage;
                    myObect.Add(itineraryObject);
                }
            }
            catch (Exception e)
            {
                itineraryObject = new OTATravelItineraryObjectHotel();

                itineraryObject.errorWSSabre = string.Concat("Error MyCTS: ", e.ToString());
                myObect.Add(itineraryObject);
            }

            return myObect;
        }

        private OTATravelItineraryObjectHotel GetHotel(TravelItinerary.TravelItineraryReadRSTravelItineraryItineraryInfoItemHotel hotel, string commission, string dk,
            string phone, string rfc, string agent, string mail, string sixReceived, string passengerType, int passengerNum, string passengerName, string title,
            string passengerSurname, string lastStatus, List<string> cancelNumberList)
        {
            OTATravelItineraryObjectHotel itineraryObject = new OTATravelItineraryObjectHotel();

            itineraryObject.Provider_Commission = commission;
            itineraryObject.Prov_Direct_Pay = true;
            itineraryObject.DK = dk;
            itineraryObject.Phone = phone.ToUpper();
            itineraryObject.RFC = rfc;
            itineraryObject.User = agent;
            itineraryObject.Mail = mail;
            itineraryObject.Request = sixReceived;
            itineraryObject.Passenger_Type = passengerType;
            itineraryObject.Passenger_Num = passengerNum;
            itineraryObject.Passenger_Name = passengerName;
            itineraryObject.Title = title;
            itineraryObject.Surname = passengerSurname;
            itineraryObject.CancelNumberList = cancelNumberList;
            itineraryObject.StatusSabre = hotel.Status;

            string typeCar = string.Empty;

            typeCar = hotel.Guarantee.Replace("DPST", string.Empty);
            itineraryObject.Payment_Form = typeCar.Length > 2 ? typeCar.Substring(0, 2) : string.Empty;
            itineraryObject.Car_Number = Convert.ToInt32(typeCar.Length > 2 ? typeCar.Substring(typeCar.IndexOf("EXP") - 4, 4) : "0");
            itineraryObject.Sales_Source = hotel.BasicPropertyInfo.HotelCityCode;
            itineraryObject.Provider = "3318";//OBTENER DE CONSULTA
            itineraryObject.Site = "5475";//OBTENER DE CONSULTA
            itineraryObject.Room = hotel.NumberOfUnits;
            itineraryObject.City = hotel.BasicPropertyInfo.HotelCityCode;
            itineraryObject.In_Date = DateTime.ParseExact(hotel.TimeSpan.Start, "MM-dd", System.Globalization.CultureInfo.CurrentCulture);
            itineraryObject.Out_Date = DateTime.ParseExact(hotel.TimeSpan.End, "MM-dd", System.Globalization.CultureInfo.CurrentCulture);

            if (itineraryObject.Passenger_Num > 1)
                itineraryObject.Room_Type = "Double";
            else
                itineraryObject.Room_Type = "Single";

            string codeCityIti = string.Empty;

            codeCityIti = hotel.BasicPropertyInfo.HotelCityCode;

            List<ListItem> lstCodCity = new List<ListItem>();

            lstCodCity = CatCitiesBL.GetCodeCities(codeCityIti);

            string country = GetCountryBL.GetCountryByCity(lstCodCity.Count > 0 ? lstCodCity[0].Value : string.Empty);
            string codeCityDB = string.Empty;

            if (country.Equals("MX") || string.IsNullOrEmpty(country))
                codeCityDB = "H1";
            else
                codeCityDB = "H2";

            itineraryObject.Service_Type = codeCityDB;
            itineraryObject.Number_Nights = Convert.ToInt32(hotel.TimeSpan.Duration ?? 1.ToString());
            status = hotel.BasicPropertyInfo.HotelCode;
            itineraryObject.Hotel = hotel.BasicPropertyInfo.HotelCode + "|" +
                                    hotel.BasicPropertyInfo.HotelName;
            itineraryObject.Rate = "VENTA";
            itineraryObject.Currency = hotel.RoomRates.Rate.CurrencyCode;
            itineraryObject.Cost = Convert.ToDouble(hotel.RoomRates.Rate.Amount.Substring(0, hotel.RoomRates.Rate.Amount.IndexOf('.') + 3));
            itineraryObject.Price = itineraryObject.Cost * Convert.ToInt32(itineraryObject.Number_Nights);
            itineraryObject.Status = lastStatus;
            itineraryObject.P_Rate = "N/A";
            itineraryObject.P_Currency = "N/A";
            itineraryObject.P_IVA = "N/A";
            itineraryObject.P_ISH = "N/A";
            itineraryObject.P_Total = "N/A";

            if (hotel.BasicPropertyInfo.ConfirmationNumber != null)
                if (!string.IsNullOrEmpty(hotel.BasicPropertyInfo.ConfirmationNumber[0].ToString()))
                    itineraryObject.Confirmation_Number = hotel.BasicPropertyInfo.ConfirmationNumber[0].ToString();

            itineraryObject.ChainCode = hotel.BasicPropertyInfo.ChainCode;

            DateTime DateIn = DateTime.ParseExact(hotel.TimeSpan.Start, "MM-dd", System.Globalization.CultureInfo.CurrentCulture);
            TimeSpan ts = new TimeSpan();

            if (DateIn == DateTime.Now)
                itineraryObject.Time_Limit = DateTime.Now;
            else
                ts = TimeSpan.FromDays(2);
            itineraryObject.Time_Limit = DateIn.Subtract(ts);
            itineraryObject =(itineraryObject != null) ? itineraryObject : new OTATravelItineraryObjectHotel();

            return itineraryObject;
        }

        private OTATravelItineraryObjectHotel GetCars(TravelItinerary.TravelItineraryReadRSTravelItineraryItineraryInfoItemVehicle car, string commission, string dk,
            string phone, string rfc, string agent, string mail, string sixReceived, string passengerType, int passengerNum, string passengerName, string title,
            string passengerSurname, string lastStatus, List<string> cancelNumberList)
        {
            OTATravelItineraryObjectHotel obj = new OTATravelItineraryObjectHotel();

            obj.Provider_Commission = commission;
            obj.Prov_Direct_Pay = true;
            obj.DK = dk;
            obj.Phone = phone;
            obj.RFC = rfc;
            obj.User = agent;
            obj.Mail = mail;
            obj.Request = sixReceived;
            obj.CancelNumberList = cancelNumberList;
            obj.StatusSabre = car.Status;

            string typeCar = string.Empty;

            typeCar = car.VehVendorAvail.VehResCore.VehicleCharges.VehicleCharge.GuaranteeInd == null ? string.Empty : car.VehVendorAvail.VehResCore.VehicleCharges.VehicleCharge.GuaranteeInd.Replace("DPST", string.Empty);

            if (!string.IsNullOrEmpty(typeCar))
            {
                obj.Payment_Form = typeCar.Substring(0, 2).ToUpper();
                obj.Car_Number = Convert.ToInt32(typeCar.Substring(typeCar.IndexOf("EXP") - 4, 4));
            }
            else
            {
                obj.Payment_Form = string.Empty;
                obj.Car_Number = 0;
            }

            obj.Sales_Source = car.VehRentalCore.LocationDetails.LocationCode.ToUpper();
            obj.Provider = "3318";//OBTENER DE CONSULTA
            obj.Site = "5475";//OBTENER DE CONSULTA
            double total = 0d;
            double semanal = 0d;

            foreach (TravelItinerary2.TravelItineraryReadRSTravelItineraryItineraryInfoItemVehicleVehVendorAvailVehResCoreVehicleChargesVehicleChargeApproximateTotalCharge chargeDetails in car.VehVendorAvail.VehResCore.VehicleCharges.VehicleCharge.ChargeDetails == null ? new TravelItinerary2.TravelItineraryReadRSTravelItineraryItineraryInfoItemVehicleVehVendorAvailVehResCoreVehicleChargesVehicleChargeApproximateTotalCharge[0] : car.VehVendorAvail.VehResCore.VehicleCharges.VehicleCharge.ChargeDetails)
            {
                if (chargeDetails.RateType == "APPROXIMATE TOTAL PRICE")
                {
                    //obj.Number_Nights = Convert.ToInt32(chargeDetails.NumDays);
                    total = Convert.ToDouble(chargeDetails.Amount);
                }

                if (chargeDetails.RateType == "DAILY RATE")
                {
                    obj.Cost = Convert.ToDouble(chargeDetails.Amount);
                }

                if (chargeDetails.RateType == "WEEKLY RATE")
                {
                    semanal = Convert.ToDouble(chargeDetails.Amount);
                }

            }

            obj.Number_Nights = (total / 1.16) / obj.Cost;
            obj.City = car.VehRentalCore.LocationDetails.LocationCode.ToUpper();
            obj.In_Date = DateTime.ParseExact(car.VehRentalCore.PickUpDateTime, car.VehRentalCore.PickUpDateTime.Length > 5 ? "MM-ddTHH:mm" : "MM-dd", System.Globalization.CultureInfo.CurrentCulture);
            obj.Out_Date = DateTime.ParseExact(car.VehRentalCore.ReturnDateTime, car.VehRentalCore.ReturnDateTime.Length > 5 ? "MM-ddTHH:mm" : "MM-dd", System.Globalization.CultureInfo.CurrentCulture);

            if (obj.Cost.Equals(0))
            {
                if (semanal.Equals(0))
                {
                    TimeSpan timespan = obj.Out_Date - obj.In_Date;
                    obj.Number_Nights = timespan.TotalDays;
                    obj.Cost = (total / 1.16) / obj.Number_Nights;
                }
                else
                {
                    obj.Cost = semanal / 7;
                    obj.Number_Nights = (total / 1.16) / obj.Cost;
                }
            }
            else
            {
                obj.Number_Nights = (total / 1.16) / obj.Cost;
            }
            string codeCityIti = string.Empty;

            codeCityIti = car.VehRentalCore.LocationDetails.LocationCode;

            List<ListItem> lstCodCity = new List<ListItem>();

            lstCodCity = CatCitiesBL.GetCodeCities(codeCityIti);

            string country = GetCountryBL.GetCountryByCity(lstCodCity[0].Value);
            string codeCityDB = string.Empty;

            if (country.Equals("MX"))
                codeCityDB = "AU";
            else
                codeCityDB = "AI";

            obj.Service_Type = codeCityDB.ToUpper();
            obj.Passenger_Type = passengerType.ToUpper();
            obj.Passenger_Num = passengerNum;
            obj.Passenger_Name = passengerName.ToUpper();
            obj.Title = title.ToUpper();
            obj.Surname = passengerSurname;
            obj.Room = "1";
            status = car.VehVendorAvail.Vendor.Code.ToUpper();
            if (string.IsNullOrEmpty(car.VehRentalCore.LocationDetails.LocationName))
            {
                obj.Hotel = string.Concat(car.VehRentalCore.LocationDetails.LocationCode.ToUpper(), car.VehVendorAvail.Vendor.Code.ToUpper(), "|",
                                        GetVendorByCodeBL.GetVendorByCode(car.VehVendorAvail.Vendor.Code.ToUpper()).ToUpper());
            }
            else
            {
                string cit = car.VehRentalCore.LocationDetails.LocationName.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0].Substring(0, 3);
                if (car.VehRentalCore.LocationDetails.LocationName.Length > 3)
                {
                    string cod = car.VehRentalCore.LocationDetails.LocationName.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0].Substring(3, 1);
                    int numcod = Int32.Parse(Int32.TryParse(car.VehRentalCore.LocationDetails.LocationName.Split(
                        new string[] { " " }, StringSplitOptions.RemoveEmptyEntries
                        )[0].Substring(
                        4, car.VehRentalCore.LocationDetails.LocationName.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0].Length - 4
                        ), out numcod) ? car.VehRentalCore.LocationDetails.LocationName.Split(
                        new string[] { " " }, StringSplitOptions.RemoveEmptyEntries
                        )[0].Substring(
                        4, car.VehRentalCore.LocationDetails.LocationName.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0].Length - 4
                        ) : "0");

                    obj.Hotel = string.Concat(cit, car.VehVendorAvail.Vendor.Code.ToUpper(), cod, numcod.ToString("000"), "|",
                        GetVendorByCodeBL.GetVendorByCode(car.VehVendorAvail.Vendor.Code.ToUpper()).ToUpper());
                }
                else
                {
                    obj.Hotel = string.Concat(cit, car.VehVendorAvail.Vendor.Code.ToUpper(), "|",
                        GetVendorByCodeBL.GetVendorByCode(car.VehVendorAvail.Vendor.Code.ToUpper()).ToUpper());
                }
            }

            obj.Rate = "VENTA";
            obj.Currency = car.VehVendorAvail.VehResCore.VehicleCharges.VehicleCharge.Mileage != null ? car.VehVendorAvail.VehResCore.VehicleCharges.VehicleCharge.Mileage.CurrencyCode.ToUpper() : string.Empty;
            obj.Price = obj.Cost * Convert.ToInt32(obj.Number_Nights);
            obj.Status = lastStatus;
            obj.P_Rate = "N/A";
            obj.P_Currency = "N/A";
            obj.P_IVA = "N/A";
            obj.P_ISH = "N/A";
            obj.P_Total = "N/A";

            if (car.ConfirmationNumber != null)
                if (!string.IsNullOrEmpty(car.ConfirmationNumber.ToString()))
                    obj.Confirmation_Number = car.ConfirmationNumber.ToString().ToUpper();

            obj.ChainCode = car.VehVendorAvail.Vendor.Code.ToUpper();

            DateTime DateIn = DateTime.ParseExact(car.VehRentalCore.PickUpDateTime, car.VehRentalCore.PickUpDateTime.Length > 5 ? "MM-ddTHH:mm" : "MM-dd", System.Globalization.CultureInfo.CurrentCulture);
            TimeSpan ts = new TimeSpan();

            if (DateIn == DateTime.Now)
                obj.Time_Limit = DateTime.Now;
            else
                ts = TimeSpan.FromDays(2);

            obj.Time_Limit = DateIn.Subtract(ts);
            obj.In_City = car.VehVendorAvail.VehResCore.CollectionDeliveryInfo != null ?
                car.VehVendorAvail.VehResCore.CollectionDeliveryInfo.CollectionInfo.Address.CityName.ToUpper() : obj.City;
            obj.Out_City = car.VehVendorAvail.VehResCore.CollectionDeliveryInfo != null ?
                car.VehVendorAvail.VehResCore.CollectionDeliveryInfo.DeliveryInfo.Address.CityName.ToUpper() : obj.City;

            string description = string.Empty;
            string tipoVehiculo = GetTypesCarByCodeBL.GetTypesCarByCode(car.VehVendorAvail.VehResCore.RentalRate.Vehicle.VehType);
            string equipo = string.Empty;
            string arrendadora = obj.Hotel.Split('|')[1];
            string in_City = GetCityNameBL.GetCityName(obj.In_City);
            string out_City = GetCityNameBL.GetCityName(obj.Out_City);

            if (car.VehVendorAvail.VehResCore.PricedEquip.Equipment.SpecialEquipConfirmed == "Y")
            {
                equipo = GetEquipmentCarByCodeBL.GetEquipmentCarByCode(car.VehVendorAvail.VehResCore.PricedEquip.Equipment.SpecialEquip).ToUpper();
            }

            description = string.Concat(tipoVehiculo, "|", equipo, "|", arrendadora, "|", in_City, "|",
                obj.In_Date.ToString(@"dd \de MMMM yyyy HH:mm \HRS", new System.Globalization.CultureInfo("es-MX")), "|", out_City, "|",
                obj.Out_Date.ToString(@"dd \de MMMM yyyy HH:mm \HRS", new System.Globalization.CultureInfo("es-MX")));
            //description = string.Concat("RENTA DE ", !tipoVehiculo.Contains("AUTO") ? "AUTO " : string.Empty, tipoVehiculo, !string.IsNullOrEmpty(equipo) ? " CON " : string.Empty, equipo, " EN ", arrendadora, ");
            //description = string.Concat(description, "RECIBE: \t", obj.In_Date.ToString(@"dd \de MMMM yyyy HH:mm \HRS", new System.Globalization.CultureInfo("es-MX")), " EN ", arrendadora, " ", in_City, "\n");
            //description = string.Concat(description, "ENTREGA:\t", obj.Out_Date.ToString(@"dd \de MMMM yyyy HH:mm \HRS", new System.Globalization.CultureInfo("es-MX")), " EN ", arrendadora, " ", out_City);
            obj.Description = description.ToUpper();

            return obj;
        }

        private XmlDocument Serialize(object res)
        {
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(res.GetType());
            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            x.Serialize(stringWriter, res);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(stringWriter.ToString().Replace(@"<?xml version=""1.0"" encoding=""utf-16""?>", "").Replace(@"<Itinerary xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">", @"<Itinerary>"));
            return xmlDoc;
        }
    }
}