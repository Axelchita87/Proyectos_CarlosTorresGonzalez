using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Services.Contracts.Volaris.EventArguments;
using MyCTS.Entities;

namespace MyCTS.Services.Contracts.Volaris.ResponsabilityChain
{
    public class VolarisReservationChain
    {


        public EventHandler<OnWebServiceCallStartEventArg> OnWebServiceCallStart { get; set; }
        public EventHandler<OnWebServiceCallCompletedEventArg> OnWebServiceCallCompleted { get; set; }

        public void Execute(VolarisReservation reservation)
        {
            var openSession = new VolarisOpenSessionResponsabilityHandler()
                                  {
                                      OnWebServiceCallCompleted = OnWebServiceCallCompleted,
                                      OnWebServiceCallStart = OnWebServiceCallStart,
                                      MessageToSend = "Conectando con volaris...."
                                  };
            var airBook = new VolarisAirBookingResponsabilityHandler()
                              {

                                  OnWebServiceCallCompleted = OnWebServiceCallCompleted,
                                  OnWebServiceCallStart = OnWebServiceCallStart,
                                  MessageToSend ="Procesando informacion...."

                              };

            var airPrice = new VolarisAirPricingResponsabilityHandler()
                               {
                                   OnWebServiceCallCompleted = OnWebServiceCallCompleted,
                                   OnWebServiceCallStart = OnWebServiceCallStart
                               };

            var travelItinerary = new VolarisTravelItineraryAddInformationResponsabilityHandler()
                                      {
                                          OnWebServiceCallCompleted = OnWebServiceCallCompleted,
                                          OnWebServiceCallStart = OnWebServiceCallStart
                                      };

            var specialService = new VolarisSpecialServiceResponsabilityHandler()
                                     {
                                         OnWebServiceCallCompleted = OnWebServiceCallCompleted,
                                         OnWebServiceCallStart = OnWebServiceCallStart
                                     };

            var endTransaction = new VolarisEndTransactionResponsabilityHandler()
                                     {
                                         OnWebServiceCallCompleted = OnWebServiceCallCompleted,
                                         OnWebServiceCallStart = OnWebServiceCallStart
                                     };

            var closeSession = new VolarisSessionCloseResponsabilityHandler()
                                   {
                                       OnWebServiceCallCompleted = OnWebServiceCallCompleted,
                                       OnWebServiceCallStart = OnWebServiceCallStart
                                   };


            openSession.SetSuccesor(airBook);
            airBook.SetSuccesor(airPrice);
            airPrice.SetSuccesor(travelItinerary);
            travelItinerary.SetSuccesor(specialService);
            specialService.SetSuccesor(endTransaction);
            endTransaction.SetSuccesor(closeSession);
            openSession.Execute(reservation, "");


        }

    }
}
