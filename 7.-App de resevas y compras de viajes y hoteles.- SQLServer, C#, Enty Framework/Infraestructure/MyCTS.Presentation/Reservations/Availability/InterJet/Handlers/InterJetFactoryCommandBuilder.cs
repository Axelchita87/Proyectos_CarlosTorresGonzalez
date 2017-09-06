using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Reservations.Availability.InterJet.CommandBuilders;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetFactoryCommandBuilder
    {

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<BuilderType, Func<InterJetCommandBuilder>> _factory;

        /// <summary>
        /// Gets the factory.
        /// </summary>
        private Dictionary<BuilderType, Func<InterJetCommandBuilder>> Factory
        {
            get
            {

                if (this._factory == null)
                {
                    this._factory = new Dictionary<BuilderType, Func<InterJetCommandBuilder>>();
                    this._factory.Add(BuilderType.AddPassangersCommandBuilder, () => new InterJetAddPassangersCommand
                                                                                         {
                                                                                             MessageOnBuilt = "Agregando Pasajeros.."
                                                                                         });
                    this._factory.Add(BuilderType.AddItineraryCommandBuilder, () => new InterJetAddItineraryCommand
                                                                                        {
                                                                                            MessageOnBuilt = "Agreando Itinerario.."
                                                                                        });
                    this._factory.Add(BuilderType.AddStoreUserFeeCommandBuilder, () => new InterJetAddStoredUserFeeCommand
                                                                                           {
                                                                                               MessageOnBuilt = "Agregando tarifa..."
                                                                                           });
                    this._factory.Add(BuilderType.AddLimitTimeEntryCommandBuilder, () => new InterJetAddLimitTimeEntryCommand
                                                                                             {
                                                                                                 MessageOnBuilt = "Agregando tiempo limite.."
                                                                                             });
                    this._factory.Add(BuilderType.AddAccountingLineCommandBuilder, () => new InterJetAddAccountingLineCommand
                                                                                             {
                                                                                                 MessageOnBuilt = "Agregnado lineas contables ..."
                                                                                             });
                    this._factory.Add(BuilderType.AddBillingAddresCommandBuilder, () => new InterJetAddBillingAddressCommand());
                    this._factory.Add(BuilderType.AddChargeOfServiceCommandBuilder, () => new InterJetAddChargeOfServiceRemarkCommand());
                    this._factory.Add(BuilderType.AddQualityRemakrCommandBuilder, () => new InterJetAddQualityRemarkCommand());
                    this._factory.Add(BuilderType.AddInterJetSSRCommandBuilder, () => new InterJetAddSSRCommand());
                    this._factory.Add(BuilderType.AddInterJetAddQSortCommand, () => new InterJetAddQSortCommand());

                    this._factory.Add(BuilderType.InterJetAddContactPhoneCommand, () => new InterJetAddContactPhoneCommand());
                    this._factory.Add(BuilderType.DinCommand, () => new InterJetDinCommand());
                    this._factory.Add(BuilderType.RemarkCommand, () => new InterJetRemarkCommand
                                                                           {
                                                                               MessageOnBuilt = "Agregando remarks.."
                                                                           });
                }
                return this._factory;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private enum BuilderType
        {
            AddPassangersCommandBuilder = 1,
            AddItineraryCommandBuilder = 2,
            AddStoreUserFeeCommandBuilder = 3,
            AddLimitTimeEntryCommandBuilder = 4,
            AddAccountingLineCommandBuilder = 5,
            AddBillingAddresCommandBuilder = 6,
            AddChargeOfServiceCommandBuilder = 7,
            AddQualityRemakrCommandBuilder = 8,
            AddInterJetSSRCommandBuilder = 9,
            AddInterJetAddQSortCommand = 10,
            InterJetAddContactPhoneCommand = 11,
            DinCommand = 12,
            RemarkCommand = 13


        }



        /// <summary>
        /// Creates the add contact phone command.
        /// </summary>
        /// <returns></returns>
        public InterJetCommandBuilder CreateNewRemarkCommand()
        {

            return this.GetBuilder(BuilderType.RemarkCommand);

        }

        /// <summary>
        /// Creates the add contact phone command.
        /// </summary>
        /// <returns></returns>
        public InterJetCommandBuilder CreateAddContactPhoneCommand()
        {

            return this.GetBuilder(BuilderType.InterJetAddContactPhoneCommand);

        }

        /// <summary>
        /// Creates the add Q sort command.
        /// </summary>
        /// <returns></returns>
        public InterJetCommandBuilder CreateAddQSortCommand()
        {

            return this.GetBuilder(BuilderType.AddInterJetAddQSortCommand);

        }
        /// <summary>
        /// Creads the add quality remark command builder.
        /// </summary>
        /// <returns></returns>
        public InterJetCommandBuilder CreadAddQualityRemarkCommandBuilder()
        {
            return this.GetBuilder(BuilderType.AddQualityRemakrCommandBuilder);
        }

        /// <summary>
        /// Creates the add billing addres command builder.
        /// </summary>
        /// <returns></returns>
        public InterJetCommandBuilder CreateAddBillingAddresCommandBuilder()
        {
            return this.GetBuilder(BuilderType.AddBillingAddresCommandBuilder);
        }

        /// <summary>
        /// Creates the add charge of service command builder.
        /// </summary>
        /// <returns></returns>
        public InterJetCommandBuilder CreateAddChargeOfServiceCommandBuilder()
        {
            return this.GetBuilder(BuilderType.AddChargeOfServiceCommandBuilder);
        }

        public InterJetCommandBuilder CreateAddPassangerCommandBuilder()
        {
            return this.GetBuilder(BuilderType.AddPassangersCommandBuilder);
        }

        public InterJetCommandBuilder CreateAddItineraryCommandBuilder()
        {
            return this.GetBuilder(BuilderType.AddItineraryCommandBuilder);
        }

        /// <summary>
        /// Creates the add stored user fee command builder.
        /// </summary>
        /// <returns></returns>
        public InterJetCommandBuilder CreateAddStoredUserFeeCommandBuilder()
        {
            return this.GetBuilder(BuilderType.AddStoreUserFeeCommandBuilder);

        }

        /// <summary>
        /// Creates the add limit time entry command builder.
        /// </summary>
        /// <returns></returns>
        public InterJetCommandBuilder CreateAddLimitTimeEntryCommandBuilder()
        {
            return this.GetBuilder(BuilderType.AddLimitTimeEntryCommandBuilder);
        }

        public InterJetCommandBuilder CreateAddAccountingLineCommandBuilder()
        {
            return this.GetBuilder(BuilderType.AddAccountingLineCommandBuilder);
        }

        /// <summary>
        /// Creates the add SSR command builder.
        /// </summary>
        /// <returns></returns>
        public InterJetCommandBuilder CreateAddSSRCommandBuilder()
        {
            return GetBuilder(BuilderType.AddInterJetSSRCommandBuilder);
        }


        /// <summary>
        /// Gets the builder.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        private InterJetCommandBuilder GetBuilder(BuilderType type)
        {
            if (this.Factory.ContainsKey(type))
            {
                return this.Factory[type]();
            }
            else
            {
                return null;
            }


        }
    }
}
