using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Presentation.Reservations.Availability.ChargeOfServiceLowFare.AssignamentChargeOfService;
using MyCTS.Presentation.Reservations.Availability.ChargeOfServiceLowFare.EventArguments;
using MyCTS.Presentation.Reservations.Availability.ChargeOfServiceLowFare.PassangerChargeOfService;
using System.Threading;

namespace MyCTS.Presentation.Reservations.Availability.ChargeOfServiceLowFare.DynamicBuilder
{
    public class ChargeOfServiceLowFareDynamicBuilder : IDynamicBuilder<Control>
    {
        #region Miembros de IDynamicBuilder<Control>


        public List<IPassanger> Passangers { get; set; }

        public ChargeOfServiceLowFareDynamicBuilder()
        {
            _table = new TableLayoutPanel
                        {

                            AutoSize = true
                        };
            _table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));


        }

        private readonly TableLayoutPanel _table;

        public Control Build()
        {
            Thread.Sleep(2000);
            CreateChargeOfServiceAssign();
            CreatePassangerChargeOfService();
            return _table;
        }


        private void CreateChargeOfServiceAssign()
        {
            var chargeAssign = new ucChargeOfServiceAssign
                                   {

                                       Passangers = new List<IPassanger>() { }
                                       //Passangers = Passangers
                                   };
            chargeAssign.OnAssignatePassanger += OnAssignatePassanger;

            int chargeRowIndex = AddRow();
            _table.Controls.Add(chargeAssign, 0, chargeRowIndex);


        }

        private void OnAssignatePassanger(object sender, AssignChargeOfServiceEventArgs e)
        {
            if (e.Passanger.IsNotAPassanger)
            {

                AssignateChargeOfService(true, e);
            }
            else
            {
                AssignateChargeOfService(false, e);
            }
        }

        //TODO: Agregar la busqueda pasajeros dada la selección del pasajero en la asignación del cargo por servicio
        //
        private void AssignateChargeOfService(bool assignateToAll, AssignChargeOfServiceEventArgs e)
        {

            if (assignateToAll)
            {
                AssignateToAllPassangers(e);


            }
            else
            {
                AssignateToSinglePassanger(e);
            }

        }

        //TODO: 08/Mayo Agregar el dictionario de equivalencias de imagenes.
        //TODO: 08/Mayo Agregar el panel de botones para continuar con el proceso
        //TODO 08/MAYO generar las etiquetas C23 del control por cada pasajero
        //TODO: 08/Mayo Diseñar los objetos necesarios para la generacion de los segmentos pasivos.
        /// <summary>
        /// Assignates to single passanger.
        /// </summary>
        /// <param name="e">The <see cref="MyCTS.Presentation.Reservations.Availability.ChargeOfServiceLowFare.EventArguments.AssignChargeOfServiceEventArgs"/> instance containing the event data.</param>
        private void AssignateToSinglePassanger(AssignChargeOfServiceEventArgs e)
        {
            var passangersChargeOfService = _table.Controls.OfType<ucPassangerChargeOfServiceLowFare>();

            var passangerControlToSet =
                passangersChargeOfService.FirstOrDefault(
                    c => c.Passanger != null && c.Passanger.ID.Equals(e.Passanger.ID));


            if (passangerControlToSet != null)
            {

                passangerControlToSet.Animate();
                passangerControlToSet.GenericCreditCard = e.FormOfPayment;
                //passangerControlToSet.UseCash = e.IsChargeFromCash;
                //passangerControlToSet.UseCreditCard = e.IsChargeFromCreditCard;
                passangerControlToSet.Amount = e.Amount;

            }

        }

        /// <summary>
        /// Assignates to all passangers.
        /// </summary>
        /// <param name="e">The <see cref="MyCTS.Presentation.Reservations.Availability.ChargeOfServiceLowFare.EventArguments.AssignChargeOfServiceEventArgs"/> instance containing the event data.</param>
        private void AssignateToAllPassangers(AssignChargeOfServiceEventArgs e)
        {

            var passangersChargeOfService = _table.Controls.OfType<ucPassangerChargeOfServiceLowFare>();

            if (passangersChargeOfService.Any())
            {
                foreach (var passangerControl in passangersChargeOfService)
                {
                    passangerControl.Animate();
                    passangerControl.GenericCreditCard = e.FormOfPayment;
                    passangerControl.Amount = e.Amount;
                    //passangerControl.UseCash = e.IsChargeFromCash;
                    //passangerControl.UseCreditCard = e.IsChargeFromCreditCard;

                }
            }

        }



        private void CreatePassangerChargeOfService()
        {

            foreach (var passanger in Passangers)
            {
                var paxControl = new ucPassangerChargeOfServiceLowFare
                                      {
                                          Passanger = passanger
                                      };
                int paxControlRowIndex = AddRow();
                _table.Controls.Add(paxControl, 0, paxControlRowIndex);
            }

        }

        private int AddRow()
        {

            return _table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        }




        #endregion


    }
}
