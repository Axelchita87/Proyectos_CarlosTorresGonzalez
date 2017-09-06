using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using MyCTS.Services;
using MyCTS.Services.Contracts;
using MyCTS.Services.MyCTSGEAComunication;

namespace MyCTS.Presentation
{
    public partial class ucPlaceRecordQueue : CustomUserControl
    {
        /// <summary>
        /// Descripción: User Control que permite ingresar un record a Queue.
        ///              Parte del modulo de Queues
        /// Creación:    Junio 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>


        public ucPlaceRecordQueue()
        {
            InitializeComponent();
        }



        private void ucPlaceRecordQueue_Load(object sender, EventArgs e)
        {
            string sabreAnswer = String.Empty;
            string QueueBritish = ParameterBL.GetParameterValue("QueueBritish").Values;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(QueueBritish);
                CommandsQik.CopyResponse(sabreAnswer, ref ucFirstValidations.dk, 1, 19, 6);
            }

            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);

        }
       
    }
}
