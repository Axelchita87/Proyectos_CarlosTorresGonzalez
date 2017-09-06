/// <summary>
/// Descripcion: Permite mover Records de una Queue a otra.
/// Pertenece a: Queues
/// Creación:    05-Junio-2009
/// Autor:       Pedro Tomas Solis
/// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Forms.UI;
using MyCTS.Presentation.Components;
using MyCTS.Services;
using MyCTS.Services.Contracts;
using MyCTS.Services.PagosMIT;
using MyCTS.Services.ValidateDKsAndCreditCards;


namespace MyCTS.Presentation
{
    public partial class ucMoveRecordsTweenQueues : CustomUserControl
    {
        public static string MoveRecordsTweenQueues = string.Empty;
        private bool validatebusinessrules = true;

        //Constructor
        public ucMoveRecordsTweenQueues()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtOriginQueue;
            this.LastControlFocus = btnAccept;
        }

        #region=====Eventos=====
        
        //Evento Load de ucMoveRecordsTweenQueues
        private void ucMoveRecordsTweenQueues_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtOriginQueue.Focus();
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
            if( validatebusinessrules )
                commandsSend();
        }
        #endregion

        #region =====Metodos=====

        /// <summary>
        /// Permite mover los Records de una Queue a otra Queue permitiendo especificar el PCC en cada una de ellas.
        /// </summary>
        private void validateBusinessRules()
        {
            MoveRecordsTweenQueues = string.Empty;
            //Verificar si Queue1 y Queue2 no estan vacias
            if (!string.IsNullOrEmpty(txtOriginQueue.Text.Trim()) && !string.IsNullOrEmpty(txtDestinyQueue.Text.Trim()))
            {
                //Concatenar Sabre con QMOV/
                MoveRecordsTweenQueues = string.Concat(MoveRecordsTweenQueues, Resources.Queues.Constants.COMMANDS_QMOV_SLASH);
                //Si existe PCC de origen, concatenar Sabre + PCC + Queue; de otra forma concatenar Sabre + Queue
                if (!string.IsNullOrEmpty(txtPCCOrigin.Text))
                    MoveRecordsTweenQueues = string.Concat(MoveRecordsTweenQueues, txtPCCOrigin.Text.Trim(), txtOriginQueue.Text.Trim());
                else
                    MoveRecordsTweenQueues = string.Concat(MoveRecordsTweenQueues, txtOriginQueue.Text.Trim());
                //Si existe PCC destino, concatenar Sabre + PCC + Queue; de otra forma concatenar Sabre + Queue
                if (!string.IsNullOrEmpty(txtPCCDestiny.Text))
                    MoveRecordsTweenQueues = string.Concat(MoveRecordsTweenQueues, Resources.Queues.Constants.SLASH, txtPCCDestiny.Text.Trim(), txtDestinyQueue.Text.Trim());
                else
                    MoveRecordsTweenQueues = string.Concat(MoveRecordsTweenQueues, Resources.Queues.Constants.SLASH, txtDestinyQueue.Text.Trim());
            }
            else
            {
                //Indica que las Queues son obligatorias
                MessageBox.Show(Resources.Queues.Queues.QUEUES_OBLIGATORIAS, Resources.Constants.MYCTS, MessageBoxButtons.OK);
                validatebusinessrules = false;
            }
        }

        /// <summary>
        /// Permite el envio de comandos hacia Sabre
        /// </summary>
        private void commandsSend()
        {
            if (!string.IsNullOrEmpty(MoveRecordsTweenQueues))
            {
                //Envia el comando contenido en la variable MoveRecordsTweenQueues
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    objCommands.SendReceive(MoveRecordsTweenQueues);
                }
            }
        }

        #endregion
    }
}
