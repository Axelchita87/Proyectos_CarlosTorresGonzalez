using System;
using System.Collections.Generic;
using System.Text;
using MyCTS.Services.com.sabre.webservices.AirAva;

namespace MyCTS.Services.Contracts
{
    public class AirAvail
    {
        public string AirAvailMethod(string convid, string ipcc, string securitytoken, string origin, string destination)
        {
            string response = string.Empty;

            try
            {
                DateTime dt = DateTime.UtcNow;
                string tstamp = dt.ToString("s") + "Z";

                //Create the message header. Provide the value for the conversation ID, the action code of the Web
                //service being called, and the value for wsse:BinarySecurityToken that was returned with
                //the SessionCreateRS message.
                //This sample calls the OTA_AirAvailLLSRQ Service, and the action code that corresponds to 
                //this service is OTA_AirAvailLLSRQ.

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
                msgHeader.Action = "OTA_AirAvailLLSRQ";
                Service service = new Service();
                service.Value = "AirAvail";
                msgHeader.Service = service;


                MessageData msgData = new MessageData();
                msgData.MessageId = "mid:20001209-133003-2333@clientofsabre.com";
                msgData.Timestamp = tstamp;
                msgHeader.MessageData = msgData;
                Security security = new Security();
                security.BinarySecurityToken = securitytoken;	// Put BinarySecurityToken in req header

                //Create the request object req and the value for the IPCC in the payload of the request.

                OTA_AirAvailRQ req = new OTA_AirAvailRQ();

                OTA_AirAvailRQPOS pos = new OTA_AirAvailRQPOS();
                OTA_AirAvailRQPOSSource source = new OTA_AirAvailRQPOSSource();
                source.PseudoCityCode = ipcc;
                pos.Source = source;
                req.POS = pos;

                req.Version = "2003A.TsabreXML1.1.1";	// Specify the service version

                //Set the request data.			
                OTA_AirAvailRQOriginDestinationInformation origDestInf = new OTA_AirAvailRQOriginDestinationInformation();
                OTA_AirAvailRQOriginDestinationInformationDepartureDateTime departTime = new OTA_AirAvailRQOriginDestinationInformationDepartureDateTime();
                string dateRngStart = DateTime.Now.AddDays(45).ToString("s");	//45 days in future
                departTime.DateTime = dateRngStart;
                origDestInf.DepartureDateTime = departTime;

                OTA_AirAvailRQOriginDestinationInformationOriginLocation originLoc = new OTA_AirAvailRQOriginDestinationInformationOriginLocation();
                originLoc.LocationCode = origin;//"LAX";
                originLoc.CodeContext = "IATA";
                origDestInf.OriginLocation = originLoc;

                OTA_AirAvailRQOriginDestinationInformationDestinationLocation destLoc = new OTA_AirAvailRQOriginDestinationInformationDestinationLocation();
                destLoc.LocationCode = destination; //"NYC";
                destLoc.CodeContext = "IATA";
                origDestInf.DestinationLocation = destLoc;

                req.OriginDestinationInformation = origDestInf;

                OTA_AirAvailRQSpecificFlightInfo specFlt = new OTA_AirAvailRQSpecificFlightInfo();
                OTA_AirAvailRQSpecificFlightInfoTPA_Extensions specFltTpa = new OTA_AirAvailRQSpecificFlightInfoTPA_Extensions();
                OTA_AirAvailRQSpecificFlightInfoTPA_ExtensionsAdditionalAvail addlAvail = new OTA_AirAvailRQSpecificFlightInfoTPA_ExtensionsAdditionalAvail();
                // NOTE:
                // To request additional availability (1*), set Ind=true.
                // To request additional class availability (1*C), set Ind=true and ClassInd=true.
                addlAvail.Ind = false;
                addlAvail.ClassInd = false;
                specFltTpa.AdditionalAvail = addlAvail;
                specFlt.TPA_Extensions = specFltTpa;
                req.SpecificFlightInfo = specFlt;


                OTA_AirAvailService serviceObj = new OTA_AirAvailService();
                serviceObj.MessageHeaderValue = msgHeader;
                serviceObj.SecurityValue = security;

                //Call the service and assign the response object.
                OTA_AirAvailRS resp = serviceObj.OTA_AirAvailRQ(req);		// Send the request.
                //Retrieve data from the resp object, such as flight number and airline code, and display
                //it on standard output. the client can retrieve other data from the response the same way.

                response = string.Concat(response, "*********************************************" + "\n");
                response = string.Concat(response, "Response of OTA_AirAvail Service" + "\n");

                if (resp.Errors != null && resp.Errors.Error != null)
                {
                    response = string.Concat(response, "Error : " + resp.Errors.Error.ErrorInfo.Message + "\n");
                }

                else
                {
                    response = string.Concat(response, "Requested " + originLoc.LocationCode + " to " + destLoc.LocationCode + "\n");
                    int ondSize = resp.OriginDestinationOptions.Length;
                    response = string.Concat(response, "Number of itineraries returned : " + ondSize + "\n");
                    for (int i1 = 0; i1 < ondSize; i1++)
                    {
                        int segSize = resp.OriginDestinationOptions[i1].FlightSegment.Length;
                        for (int s1 = 0; s1 < segSize; s1++)
                        {
                            if (originLoc.LocationCode != resp.OriginDestinationOptions[i1].FlightSegment[s1].DepartureAirport.LocationCode)
                            {
                                response = string.Concat(response, "Departure Airport : " + resp.OriginDestinationOptions[i1].FlightSegment[s1].DepartureAirport.LocationCode + "\n");
                            }
                            if (destLoc.LocationCode != resp.OriginDestinationOptions[i1].FlightSegment[s1].ArrivalAirport.LocationCode)
                            {
                                response = string.Concat(response, "Arrival Airport   : " + resp.OriginDestinationOptions[i1].FlightSegment[s1].ArrivalAirport.LocationCode + "\n");
                            }
                            response = string.Concat(response, "Marketing Carrier : " + resp.OriginDestinationOptions[i1].FlightSegment[s1].MarketingAirline.Code + "\n");
                            response = string.Concat(response, "Flight number     : " + resp.OriginDestinationOptions[i1].FlightSegment[s1].FlightNumber + "\n");
                            response = string.Concat(response, "Departure         : " + resp.OriginDestinationOptions[i1].FlightSegment[s1].DepartureDateTime + "\n");
                            response = string.Concat(response, "Arrival           : " + resp.OriginDestinationOptions[i1].FlightSegment[s1].ArrivalDateTime + "\n");
                            response = string.Concat(response, "Timezone Diff     : " + resp.OriginDestinationOptions[i1].TPA_Extensions.TimeZoneDifference.Code + "\n");
                        }
                    }

                    response = string.Concat(response, "Host command : " + resp.TPA_Extensions.HostCommand + "\n");
                }
                response = string.Concat(response, "********************************************" + "\n");
                //Console.Read();
            }

//Catch exceptions and parse the error and stack trace.
            catch (Exception e)
            {
                response = string.Concat(response, "Exception Message : " + e.Message + "\n");
                response = string.Concat(response, "Exception Stack Trace : " + e.StackTrace + "\n");
                //Console.Read();
            }

            return response;
        }
    }
}
