using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Services.AirLowFareSearch;

namespace MyCTS.Services.Contracts
{
    public class AirLowFareSearch
    {
        public OTA_AirLowFareSearchRS AirLowFareSearchMethod(string convid, string ipcc, string securitytoken, string origin, string destination, string FechaSalida, string sCurrency)
        {
            OTA_AirLowFareSearchRS resp = new OTA_AirLowFareSearchRS();
            try
            {
                OTA_AirLowFareSearchService serviceObj = new OTA_AirLowFareSearchService() { MessageHeaderValue = new MessageHeader { From = new From { PartyId = new PartyId[] { new PartyId { Value = "WebServiceClient" } } }, To = new To { PartyId = new PartyId[] { new PartyId { Value = "WebServiceSupplier" } } }, ConversationId = convid, CPAId = ipcc, Action = "OTA_AirLowFareSearchLLSRQ", Service = new Service { Value = "AirLowFareSearch" }, MessageData = new MessageData { MessageId = "mid:20001209-133003-2333@clientofsabre.com1", Timestamp = DateTime.UtcNow.ToString("s") } }, SecurityValue = new Security { BinarySecurityToken = securitytoken } };
                OTA_AirLowFareSearchRQ req = new OTA_AirLowFareSearchRQ() { POS = new OTA_AirLowFareSearchRQPOS { Source = new OTA_AirLowFareSearchRQPOSSource { PseudoCityCode = ipcc } }, Version = "1.14.1", OriginDestinationInformation = new OTA_AirLowFareSearchRQFlightSegment[] { new OTA_AirLowFareSearchRQFlightSegment { OriginLocation = new OTA_AirLowFareSearchRQFlightSegmentOriginLocation { LocationCode = origin }, DestinationLocation = new OTA_AirLowFareSearchRQFlightSegmentDestinationLocation { LocationCode = destination }, DepartureDateTime = FechaSalida, ConnectionInd = "O", ResBookDesigCode = "Y", RPH = "1" } }, PriceRequestInformation = new OTA_AirLowFareSearchRQPriceRequestInformation { OptionalQualifiers = new OTA_AirLowFareSearchRQPriceRequestInformationOptionalQualifiers { PricingQualifiers = new OTA_AirLowFareSearchRQPriceRequestInformationOptionalQualifiersPricingQualifiers { CurrencyCode = sCurrency, PassengerType = new OTA_AirLowFareSearchRQPriceRequestInformationOptionalQualifiersPricingQualifiersPassengerType[] { new OTA_AirLowFareSearchRQPriceRequestInformationOptionalQualifiersPricingQualifiersPassengerType { Quantity = "1", Code = "ADT" } }, Taxes = new OTA_AirLowFareSearchRQPriceRequestInformationOptionalQualifiersPricingQualifiersTaxes { NoTax = true } }, TimeQualifiers = new OTA_AirLowFareSearchRQPriceRequestInformationOptionalQualifiersTimeQualifiers { NumHours = "9", } } }, TimeStamp = DateTime.UtcNow.ToString("s") };
                resp = serviceObj.OTA_AirLowFareSearchRQ(req);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
                //OTA_AirLowFareSearchService serviceObj = new OTA_AirLowFareSearchService() { MessageHeaderValue = new MessageHeader { From = new From { PartyId = new PartyId[] { new PartyId { Value = "WebServiceClient" } } }, To = new To { PartyId = new PartyId[] { new PartyId { Value = "WebServiceSupplier" } } }, ConversationId = convid, CPAId = ipcc, Action = "OTA_AirLowFareSearchLLSRQ", Service = new Service { Value = "AirLowFareSearch" }, MessageData = new MessageData { MessageId = "mid:20001209-133003-2333@clientofsabre.com1", Timestamp = DateTime.UtcNow.ToString("s") } }, SecurityValue = new Security { BinarySecurityToken = securitytoken } };
                //OTA_AirLowFareSearchRQ req = new OTA_AirLowFareSearchRQ() { POS = new OTA_AirLowFareSearchRQPOS { Source = new OTA_AirLowFareSearchRQPOSSource { PseudoCityCode = ipcc } }, Version = "1.14.1", OriginDestinationInformation = new OTA_AirLowFareSearchRQFlightSegment[] { new OTA_AirLowFareSearchRQFlightSegment { OriginLocation = new OTA_AirLowFareSearchRQFlightSegmentOriginLocation { LocationCode = origin }, DestinationLocation = new OTA_AirLowFareSearchRQFlightSegmentDestinationLocation { LocationCode = destination }, DepartureDateTime = FechaSalida, ConnectionInd = "O", ResBookDesigCode = "Y", RPH = "1" } }, PriceRequestInformation = new OTA_AirLowFareSearchRQPriceRequestInformation { OptionalQualifiers = new OTA_AirLowFareSearchRQPriceRequestInformationOptionalQualifiers { PricingQualifiers = new OTA_AirLowFareSearchRQPriceRequestInformationOptionalQualifiersPricingQualifiers { CurrencyCode = sCurrency, PassengerType = new OTA_AirLowFareSearchRQPriceRequestInformationOptionalQualifiersPricingQualifiersPassengerType[] { new OTA_AirLowFareSearchRQPriceRequestInformationOptionalQualifiersPricingQualifiersPassengerType { Quantity = "1", Code = "ADT" } }, Taxes = new OTA_AirLowFareSearchRQPriceRequestInformationOptionalQualifiersPricingQualifiersTaxes { NoTax = true } }, TimeQualifiers = new OTA_AirLowFareSearchRQPriceRequestInformationOptionalQualifiersTimeQualifiers { NumHours = "9", } } }, TimeStamp = DateTime.UtcNow.ToString("s") };
                //resp = serviceObj.OTA_AirLowFareSearchRQ(req);
            }
            return resp;
        }
    }
}
