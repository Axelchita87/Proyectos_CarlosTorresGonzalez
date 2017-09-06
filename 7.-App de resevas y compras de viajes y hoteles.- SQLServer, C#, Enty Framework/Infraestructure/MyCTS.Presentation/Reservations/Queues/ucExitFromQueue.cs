/// <summary>
/// Descripcion: Permite salir de una Queue.
/// Pertenece a: Queues
/// Creación:    04-Junio-2009
/// Autor:       Pedro Tomas Solis
/// </summary>

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Business;
using MyCTS.Entities;
using System.Text.RegularExpressions;
using MyCTS.Forms.UI;

namespace MyCTS.Presentation
{
    public partial class ucExitFromQueue : CustomUserControl
    {
        public static string ExitFromQueue = string.Empty;
        private bool validatebusinessrules = true;

        //Constructor
        public ucExitFromQueue()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = rdoFinalize;
            this.LastControlFocus = btnAccept;
        }

        #region =====Events=====

        // Evento Load de ucExitFromQueue
        private void ucExitFromQueue_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            rdoFinalize.Focus();
        }

        //Evento KeyDown para teclas Esc y Enter
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }

        //Evento click del Boton btnAccept
        private void btnAccept_Click(object sender, EventArgs e)
        {
            //Se aplican las reglas de negocios
            validateBusinessRules();
            //Si se cumplen las reglas de negocios,mandar el comando
            if (validatebusinessrules)
                commandsSend();
        }

        #endregion

        #region =====Methods=====

        /// <summary>
        /// Permite salir de una queue mediante la eleccion de las opciones finalizar, remover, ignorar, 
        /// finalizar y redesplegar, ignorar y redesplegar
        /// </summary>
        private void validateBusinessRules()
        {
            ExitFromQueue = string.Empty;
            //Si se escoge la opcion de Finalizar Queue
            if (rdoFinalize.Checked)
            {
                ExitFromQueue = string.Concat(ExitFromQueue, Resources.Queues.Constants.COMMANDS_QXE);
            }
            //Si se escoge la opcion de Remover Queue
            else if (rdoRemove.Checked)
            {
                ExitFromQueue = string.Concat(ExitFromQueue, Resources.Queues.Constants.COMMANDS_QXR);
            }
            //Si se escoge la opcion de Ignorar Queue
            else if (rdoIgnore.Checked)
            {
                ExitFromQueue = string.Concat(ExitFromQueue, Resources.Queues.Constants.COMMANDS_QXI);
            }
            //Si se escoge la opcion de Finalizar y redesplegar Queue
            else if (rdoFinalizeAndDisplay.Checked)
            {
                ExitFromQueue = string.Concat(ExitFromQueue, Resources.Queues.Constants.COMMANDS_QXER);
            }
            //Si se escoge la opcion de Ignorar y redesplegar Queue
            else if (rdoIgnoreAndDisplay.Checked)
            {
                ExitFromQueue = string.Concat(ExitFromQueue, Resources.Queues.Constants.COMMANDS_QXIR);
            }
            else
                validatebusinessrules = false;
        }

        /// <summary>
        /// Permite el envio de comandos hacia Sabre
        /// </summary>
        private void commandsSend()
        {
            if (!string.IsNullOrEmpty(ExitFromQueue))
            {
                //Envia el comando en la variable ExitFromQueue
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    objCommands.SendReceive(ExitFromQueue);
                }
            }
        }

        #endregion
    }
}
