using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Presentation.Reservations.Availability.InterJet.CommandBuilders;
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;

namespace MyCTS.Presentation.Reservations.Availability.EndRecord.Services
{
    public class InterJetRecordManager : TRecordManager
    {
        /// </summary>
        /// 

        private InterJetTicket Ticket
        {
            get
            {
                if (Model is InterJetSession)
                {
                    var session = ((InterJetSession)Model).Session;

                    return (InterJetTicket)session["CurrentTicket"];

                }
                return new InterJetTicket();
            }
        }

        private InterJetFactoryCommandBuilder _commandFactory;
        private InterJetFactoryCommandBuilder CommandFactory
        {
            get
            {
                return this._commandFactory ?? (this._commandFactory = new InterJetFactoryCommandBuilder());
            }
        }

        private readonly List<InterJetCommandBuilder> _builders = new List<InterJetCommandBuilder>();

        public override bool GenerateRecord()
        {

            //var passangerBuilder = CommandFactory.CreateAddPassangerCommandBuilder();
            _builders.Add(new InterJetCustomerCommand
            {
                MessageOnBuilt = "Agregando cliente.."
            });
            _builders.Add(new InterJetPassangersCommands
                              {
                                  MessageOnBuilt = "Agregando pasajeros.."
                              });

            var itineraryBuilder = CommandFactory.CreateAddItineraryCommandBuilder();
            _builders.Add(itineraryBuilder);

            var storedFeeBuilder = CommandFactory.CreateAddStoredUserFeeCommandBuilder();
            _builders.Add(storedFeeBuilder);

            var timeLimiteBuilder = CommandFactory.CreateAddLimitTimeEntryCommandBuilder();
            _builders.Add(timeLimiteBuilder);

            var contanctAndPhomeBuilder = CommandFactory.CreateAddContactPhoneCommand();
            _builders.Add(contanctAndPhomeBuilder);

            var accountingLineBuilder = CommandFactory.CreateAddAccountingLineCommandBuilder();
            _builders.Add(accountingLineBuilder);

            var remarkCommand = CommandFactory.CreateNewRemarkCommand();
            _builders.Add(remarkCommand);
            //checar vuelos internacionales
            if (Ticket.Passangers.HasInfants || Ticket.Flights.HasInternationalSegments)
            {
                _builders.Add(new InterJetSpecialServicesCommands
                                  {
                                      MessageOnBuilt = "Agreando servicios especiales.."
                                  });
            }
            this.AgentName = Login.NombreCompleto;
            this.Queue = Login.Queue;
            this.PseudoCityCode = Login.PCC;
            foreach (var builder in _builders)
            {

                builder.Ticket = Ticket;
                //if (VolarisSession.IsVolarisProcess)
                //    builder.Ticket =null;

                if (OnActionStart != null && OnActionCompleted != null)
                {//entra
                    OnActionStart(this, new OnActionStartEventArg
                                            {
                                                Message = builder.MessageOnBuilt
                                            });
                    builder.Build();
                    OnActionCompleted(this, new OnActionCompletedEventArgs
                                               {
                                                   Message = builder.MessageOnBuilt
                                               });

                }

                if (!builder.Success)
                {
                    this.ErrorMessage = builder.ErrorMessage;
                    return false;
                }

            }

            return true;
        }
    }
}
