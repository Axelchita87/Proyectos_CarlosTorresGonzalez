using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Services.Protocols;
using MyCTS.Business;
using MyCTS.Entities;
#if (VOLARIS_PRODUCTION)
using MyCTS.Services.AirPriceProduction;
#else

using MyCTS.Services.AirPriceTest;
#endif

namespace MyCTS.Services.Contracts.Volaris
{
    public class AirPriceService : ISabreService
    {
        #region Miembros de ISabreService

        public string SecurityToken { get; set; }

        public string ConversationID { set; get; }
        public VolarisReservation Reservation { get; set; }
        public bool Success { get; set; }

        public string ErrorMessage { get; set; }

        #endregion

        #region Miembros de IService
        private MessageHeader GetMessageHeader()
        {

            var messageHeader = new MessageHeader
            {
                ConversationId = "CurrentSession",
                From = new From
                {
                    PartyId = new[]
                          {
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
            messageHeader.Action = "OTA_AirPriceLLSRQ";
            messageHeader.Service = new Service
            {
                Value = "OTA_AirPriceLLSRQ"
            };

            messageHeader.MessageData = new MessageData
            {
                MessageId = "mid:20001209-133003-2333@clientofsabre.com",
                Timestamp = string.Format("{0}Z", DateTime.Now.ToString("s"))
            };



            return messageHeader;
        }

        public void Call()
        {
            try
            {
                var request = new OTA_AirPriceRQ()
                                  {
                                      POS = new OTA_AirPriceRQPOS()
                                                {
                                                    Source = new OTA_AirPriceRQPOSSource()
                                                                 {
                                                                     PseudoCityCode = VolarisResources.PseudoCodeCity
                                                                 }
                                                },
                                      Version = VolarisResources.AirPriceServiceVersion
                                  };
                request.PriceRequestInformation = new OTA_AirPriceRQPriceRequestInformation()
                                                      {

                                                          Retain = true,
                                                          OptionalQualifiers = new OTA_AirPriceRQPriceRequestInformationOptionalQualifiers()
                                                                                   {
                                                                                       PricingQualifiers = new OTA_AirPriceRQPriceRequestInformationOptionalQualifiersPricingQualifiers()
                                                                                                               {
                                                                                                                   CurrencyCode = "MXN"
                                                                                                               }
                                                                                   }
                                                      };
                var service = new OTA_AirPriceService()
                                  {
                                      MessageHeaderValue = this.GetMessageHeader(),
                                      SecurityValue = new Security()
                                                          {

                                                              BinarySecurityToken = this.SecurityToken
                                                          }
                                  };
                Serializer.Serialize("OTA_AirPriceLLSRQ", request);
                var response = service.OTA_AirPriceRQ(request);
                Serializer.Serialize("OTA_AirPriceLLSRS", response);
                if (response.Success != null && response.Errors == null)
                {


                    //TODO : Separar las tarifas bases que serviran para crear las lineas contables de las tarifas totales.
                    //TODO:  Crear las actividades del lunes y martes.
                    ResetPrices(response);

                    var totalAmount = response.PricedItinerary.TotalAmount;
                    if (totalAmount > Reservation.Itinerary.TotalPrice)
                    {
                        Success = false;
                        ErrorMessage = "Los precios han cambiado a la ultima cotización debido a que el tipo de clase se agoto en el transcurso de la operación, por favor realice de nuevo la reserva para evitar conflictos con la aerolinea.";
                        return;
                    }
                    Success = true;
                }
                else
                {
                    LogError(response.Errors.Error.ErrorInfo.Message);
                    Success = false;
                    ErrorMessage = "No se pudo retener el precio.";
                }

            }
            catch (Exception exe)
            {
                Success = false;
                ErrorMessage = exe.Message;
                LogError(exe.Message);
            }

        }

        private void LogError(string errorMessage)
        {
            var errorLog = new LowFareAirLinesError
            {
                Agent = Reservation.Agent.ID,
                AirLine = LowFareAirLinesErrorLogger.Volaris,
                Date = DateTime.Now,
                ServiceName = "AirPriceService",
                ErrorMessage = errorMessage
            };
            LowFareAirLinesErrorLogger.Instance.Log(errorLog);
        }

        private void ResetPrices(OTA_AirPriceRS response)
        {
            Reservation.Itinerary.UseFinalItineraryPrice = true;
            if (response.PricedItinerary != null)
            {
                var pricedItinerary = response.PricedItinerary;
                //Reservation.Itinerary.TotalFare.TotalAmount = pricedItinerary.TotalAmount;
                var airPriceInfo = pricedItinerary.AirItineraryPricingInfo.FirstOrDefault();
                if (airPriceInfo != null)
                {

                    int totalPassangers = Convert.ToInt32(airPriceInfo.PassengerTypeQuantity.Quantity);

                    Reservation.Itinerary.TotalFinalPrice = pricedItinerary.TotalAmount;
                    Reservation.Itinerary.TotalFinalTaxes = airPriceInfo.ItinTotalFare.Taxes.Sum(t => t.Amount) *
                                                            totalPassangers;
             
                    Reservation.Itinerary.BaseFare.TotalAmount =
                                              Convert.ToDecimal(airPriceInfo.ItinTotalFare.TotalFare.Amount);

                    //Busca el iva y tua internacional
                    if (Reservation.Itinerary.IsInternational)
                    {
                        Reservation.Itinerary.TotalFinalBasePrice =
                        Convert.ToDecimal(airPriceInfo.ItinTotalFare.EquivFare.Amount) * totalPassangers;
                        Reservation.Itinerary.BaseFare.Iva = GetTaxes(new[] { "XO" }, airPriceInfo);
                        Reservation.Itinerary.BaseFare.Tua = GetTaxes(new[] { "XD", "US2" }, airPriceInfo);
                        Reservation.Itinerary.BaseFare.ExtraTaxes = GetExtraTaxes(new[] { "XO", "XD", "US2", "SOV", "SNV", "SCV", "SBV"}, airPriceInfo);
                        Reservation.Itinerary.BaseFare.TotalBasePrice = Convert.ToDecimal(airPriceInfo.ItinTotalFare.EquivFare.Amount);
                        Reservation.Itinerary.BaseFare.IVAMonto11 = GetTax("SOV", airPriceInfo);
                        Reservation.Itinerary.BaseFare.IVA11 = GetTax("SNV", airPriceInfo);
                        Reservation.Itinerary.BaseFare.IVAMonto16 = GetTax("SCV", airPriceInfo);
                        Reservation.Itinerary.BaseFare.IVA16 = GetTax("SBV", airPriceInfo);
                    }
                    else
                    {
                        //Busca el iva y tua nacional
                        Reservation.Itinerary.TotalFinalBasePrice =
                        Convert.ToDecimal(airPriceInfo.ItinTotalFare.BaseFare.Amount) * totalPassangers;
                        Reservation.Itinerary.BaseFare.Iva = GetTax("MX", airPriceInfo);
                        Reservation.Itinerary.BaseFare.Tua = GetTax("XV", airPriceInfo);
                        Reservation.Itinerary.BaseFare.ExtraTaxes = GetExtraTaxes(new[] { "MX", "XV", "SOV", "SNV", "SCV", "SBV" }, airPriceInfo);
                        Reservation.Itinerary.BaseFare.TotalBasePrice = Convert.ToDecimal(airPriceInfo.ItinTotalFare.BaseFare.Amount);
                        Reservation.Itinerary.BaseFare.IVAMonto11 = GetTax("SOV", airPriceInfo);
                        Reservation.Itinerary.BaseFare.IVA11 = GetTax("SNV", airPriceInfo);
                        Reservation.Itinerary.BaseFare.IVAMonto16 = GetTax("SCV", airPriceInfo);
                        Reservation.Itinerary.BaseFare.IVA16 = GetTax("SBV", airPriceInfo);

                    }
                }
            }
        }

        private decimal GetTaxes(IEnumerable<string> taxesToSearch, OTA_AirPriceRSPricedItineraryAirItineraryPricingInfo pricingInfo)
        {
            var taxes = pricingInfo.ItinTotalFare.Taxes;
            return taxes.Where(t => taxesToSearch.Contains(t.TaxCode)).Sum(t => t.Amount);
        }

        private decimal GetExtraTaxes(IEnumerable<string> taxesToIgnore, OTA_AirPriceRSPricedItineraryAirItineraryPricingInfo pricingInfo)
        {
            var taxes = pricingInfo.ItinTotalFare.Taxes;
            return taxes.Where(t => !taxesToIgnore.Contains(t.TaxCode)).Sum(t => t.Amount);
        }

        private decimal GetTax(string taxCode, OTA_AirPriceRSPricedItineraryAirItineraryPricingInfo pricingInfo)
        {
            return GetTaxes(new[] { taxCode }, pricingInfo);
        }

        #endregion
    }
}
