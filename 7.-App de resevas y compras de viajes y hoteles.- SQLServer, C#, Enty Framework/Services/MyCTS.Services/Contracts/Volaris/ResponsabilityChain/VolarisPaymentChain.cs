using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Services.Contracts.Volaris.EventArguments;

namespace MyCTS.Services.Contracts.Volaris.ResponsabilityChain
{
    public class VolarisPaymentChain
    {

        public EventHandler<OnWebServiceCallStartEventArg> OnWebServiceCallStart { get; set; }
        /// <summary>
        /// Gets or sets the on web service call completed.
        /// </summary>
        /// <value>
        /// The on web service call completed.
        /// </value>
        public EventHandler<OnWebServiceCallCompletedEventArg> OnWebServiceCallCompleted { get; set; }

        public void AmericanExpressPayment(VolarisReservation reservation)
        {
            var openSession = new VolarisOpenSessionResponsabilityHandler()
            {
                OnWebServiceCallCompleted = OnWebServiceCallCompleted,
                OnWebServiceCallStart = OnWebServiceCallStart,
                MessageToSend = "Conectado con volaris..."
            };

            var sabreCommand = new VolarisSabreCommandResponsabilityHandler()
                                   {
                                       OnWebServiceCallCompleted = OnWebServiceCallCompleted,
                                       OnWebServiceCallStart = OnWebServiceCallStart
                                   };
            var designatePrinter = new VolarisDesignatePrinterResponsabilityHandler()
                                       {
                                           OnWebServiceCallCompleted = OnWebServiceCallCompleted,
                                           OnWebServiceCallStart = OnWebServiceCallStart
                                       };

            var itineraryRead = new VolarisItineraryReadResponsabilityHandler()
                                    {
                                        OnWebServiceCallCompleted = OnWebServiceCallCompleted,
                                        OnWebServiceCallStart = OnWebServiceCallStart,
                                        MessageToSend = "Comprobando tarjeta...."
                                    };


            var airTicket = new VolarisAirTicketResponsabilityHandler()
                                {
                                    OnWebServiceCallCompleted = OnWebServiceCallCompleted,
                                    OnWebServiceCallStart = OnWebServiceCallStart
                                };

            var fraudCheck = new VolarisFraudCheckResponsabilityHandler()
                                 {
                                     OnWebServiceCallCompleted = OnWebServiceCallCompleted,
                                     OnWebServiceCallStart = OnWebServiceCallStart,

                                 };


            var addRemark = new VolarisAddRemarkResponsabilityHandler()
                                {
                                    OnWebServiceCallCompleted = OnWebServiceCallCompleted,
                                    OnWebServiceCallStart = OnWebServiceCallStart
                                };

            var travelReadItinerary = new VolarisItineraryReadResponsabilityHandler()
                                          {
                                              OnWebServiceCallCompleted = OnWebServiceCallCompleted,
                                              OnWebServiceCallStart = OnWebServiceCallStart,
                                              MessageToSend = "Tarjeta aceptada..."
                                          };
            var endTransactionForRecord = new VolarisEndTransactionResponsabilityHandler()
            {
                OnWebServiceCallCompleted = OnWebServiceCallCompleted,
                OnWebServiceCallStart = OnWebServiceCallStart
            };

            var endTransactionForRemark = new VolarisEndTransactionResponsabilityHandler()
            {
                OnWebServiceCallCompleted = OnWebServiceCallCompleted,
                OnWebServiceCallStart = OnWebServiceCallStart
            };


            var closeSession = new VolarisSessionCloseResponsabilityHandler()
            {
                OnWebServiceCallCompleted = OnWebServiceCallCompleted,
                OnWebServiceCallStart = OnWebServiceCallStart
            };


            openSession.SetSuccesor(sabreCommand);
            sabreCommand.SetSuccesor(designatePrinter);
            designatePrinter.SetSuccesor(itineraryRead);
            itineraryRead.SetSuccesor(airTicket);
            airTicket.SetSuccesor(endTransactionForRecord);
            endTransactionForRecord.SetSuccesor(travelReadItinerary);
            travelReadItinerary.SetSuccesor(fraudCheck);
            fraudCheck.SetSuccesor(addRemark);
            addRemark.SetSuccesor(endTransactionForRemark);
            endTransactionForRemark.SetSuccesor(closeSession);
            openSession.Execute(reservation, "");


        }

        public void VisaOrMasterCardPayment(VolarisReservation reservation)
        {

            var openSession = new VolarisOpenSessionResponsabilityHandler()
            {
                OnWebServiceCallCompleted = OnWebServiceCallCompleted,
                OnWebServiceCallStart = OnWebServiceCallStart,
                MessageToSend = "Conectado con volaris..."
            };

            var sabreCommand = new VolarisSabreCommandResponsabilityHandler()
            {
                OnWebServiceCallCompleted = OnWebServiceCallCompleted,
                OnWebServiceCallStart = OnWebServiceCallStart
            };
            var designatePrinter = new VolarisDesignatePrinterResponsabilityHandler()
            {
                OnWebServiceCallCompleted = OnWebServiceCallCompleted,
                OnWebServiceCallStart = OnWebServiceCallStart
            };

            var itineraryRead = new VolarisItineraryReadResponsabilityHandler()
            {
                OnWebServiceCallCompleted = OnWebServiceCallCompleted,
                OnWebServiceCallStart = OnWebServiceCallStart,
                MessageToSend = "Comprobando tarjeta...."
            };


            var airTicket = new VolarisAirTicketResponsabilityHandler()
            {
                OnWebServiceCallCompleted = OnWebServiceCallCompleted,
                OnWebServiceCallStart = OnWebServiceCallStart
            };

            var fraudCheck = new VolarisFraudCheckResponsabilityHandler()
            {
                OnWebServiceCallCompleted = OnWebServiceCallCompleted,
                OnWebServiceCallStart = OnWebServiceCallStart,

            };


            var addRemark = new VolarisAddRemarkResponsabilityHandler()
            {
                OnWebServiceCallCompleted = OnWebServiceCallCompleted,
                OnWebServiceCallStart = OnWebServiceCallStart
            };

            var travelReadItinerary = new VolarisItineraryReadResponsabilityHandler()
            {
                OnWebServiceCallCompleted = OnWebServiceCallCompleted,
                OnWebServiceCallStart = OnWebServiceCallStart,
                MessageToSend = "Tarjeta aceptada..."
            };
            var endTransactionForRecord = new VolarisEndTransactionResponsabilityHandler()
            {
                OnWebServiceCallCompleted = OnWebServiceCallCompleted,
                OnWebServiceCallStart = OnWebServiceCallStart
            };

            var endTransactionForRemark = new VolarisEndTransactionResponsabilityHandler()
            {
                OnWebServiceCallCompleted = OnWebServiceCallCompleted,
                OnWebServiceCallStart = OnWebServiceCallStart
            };


            var closeSession = new VolarisSessionCloseResponsabilityHandler()
            {
                OnWebServiceCallCompleted = OnWebServiceCallCompleted,
                OnWebServiceCallStart = OnWebServiceCallStart
            };


            var paymentRq = new VolarisPaymentRQResponsabilityHandler()
                                {
                                    OnWebServiceCallCompleted = OnWebServiceCallCompleted,
                                    OnWebServiceCallStart = OnWebServiceCallStart
                                };

            openSession.SetSuccesor(sabreCommand);
            sabreCommand.SetSuccesor(designatePrinter);
            designatePrinter.SetSuccesor(itineraryRead);
            itineraryRead.SetSuccesor(paymentRq);

            paymentRq.SetSuccesor(addRemark);

            addRemark.SetSuccesor(airTicket);
            airTicket.SetSuccesor(endTransactionForRecord);
            endTransactionForRecord.SetSuccesor(travelReadItinerary);
            travelReadItinerary.SetSuccesor(fraudCheck);

            fraudCheck.SetSuccesor(endTransactionForRemark);

            endTransactionForRemark.SetSuccesor(closeSession);
            openSession.Execute(reservation, "");


        }

    }
}
