/// <summary>
/// Descripcion: Permite avanzar un PNR en una Queue.
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
    public partial class ucAdvancePNRQueue : CustomUserControl
    {
        public static string AdvancePNRQueue = string.Empty;
        private bool validatebusinessrules = true;

        //Constructor
        public ucAdvancePNRQueue()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = rdoIgnoreRecord;
            this.LastControlFocus = btnAccept;
        }

        #region =====Events=====

        //Evento Load
        private void ucAdvancePNRQueue_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            rdoIgnoreRecord.Focus();
        }

        //Evento click para Boton Accept, valida la regla de negocios
        private void btnAccept_Click(object sender, EventArgs e)
        {
            validateBusinessRules();
            if (validatebusinessrules)
                commandsSend();
        }

        //Evento KeyDown para teclas Esc y Enter
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }

        //Evento CheckedChanged para radio boton rdoIgnoreRecord
        private void rdoIgnoreRecord_CheckedChanged(object sender, EventArgs e)
        {
            txtAhead.Focus();
        }

        //Evento CheckedChange para radio boton rdoFinalizeTransaction
        private void rdoFinalizeTransaction_CheckedChanged(object sender, EventArgs e)
        {
            txtAhead.Focus();
        }

        //Evento CheckedChange para radio boton rdoRemoveRecord
        private void rdoRemoveRecord_CheckedChanged(object sender, EventArgs e)
        {
            txtAhead.Focus();
        }
        #endregion

        #region =====Methods=====

        /// <summary>
        /// Reglas de negocio pertenecientes al user control de Avanzar Record en Queue
        /// </summary>
        private void validateBusinessRules()
        {
            //Si Adelante y Atras tienen valores, solicita que se indique solo uno
            if (!string.IsNullOrEmpty(txtAhead.Text) && !string.IsNullOrEmpty(txtForward.Text))
            {
                MessageBox.Show(Resources.Queues.Queues.DIAS_NO_COMBINABLES, Resources.Constants.MYCTS, MessageBoxButtons.OK);
                txtAhead.Focus();
                validatebusinessrules = false;
            }
            //Validacion de valores no cero
            else if (txtAhead.Text.Trim().Equals(Resources.Queues.Queues.CERO))
            {
                MessageBox.Show(Resources.Queues.Queues.CERO_NO_PERMITIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK);
                txtAhead.Focus();
                validatebusinessrules = false;
            }
            else if (txtForward.Text.Trim().Equals(Resources.Queues.Queues.CERO))
            {
                MessageBox.Show(Resources.Queues.Queues.CERO_NO_PERMITIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK);
                txtForward.Focus();
                validatebusinessrules = false;
            }
            else
            {
                AdvancePNRQueue = string.Empty;

                #region .:Ignorar Registro:.
                //Estableciendo el comando para ignorar registro
                if (rdoIgnoreRecord.Checked)
                {
                    //Establece Sabre a 'I'
                    AdvancePNRQueue = string.Concat(AdvancePNRQueue, Resources.Queues.Constants.COMMANDS_I);
                    if (!string.IsNullOrEmpty(txtAhead.Text))
                    {
                        AdvancePNRQueue = string.Empty;
                        AdvancePNRQueue = string.Concat(AdvancePNRQueue,
                                      Resources.Queues.Constants.COMMANDS_QBI,
                                      Resources.Queues.Constants.LORRAINE_CROSS,
                                      txtAhead.Text.Trim());
                    }
                    else if (!string.IsNullOrEmpty(txtForward.Text))
                    {
                        AdvancePNRQueue = string.Empty;
                        AdvancePNRQueue = string.Concat(AdvancePNRQueue,
                                      Resources.Queues.Constants.COMMANDS_QBI,
                                      Resources.Queues.Constants.INDENT,
                                      txtForward.Text.Trim());
                    }
                }
                #endregion

                #region .:Finalizar Transaccion:.
                //Establece el comando para finalizar la transaccion
                if (rdoFinalizeTransaction.Checked)
                {
                    //Establece Sabre a 'E'
                    AdvancePNRQueue = string.Concat(AdvancePNRQueue, Resources.Queues.Constants.COMMANDS_E);
                    if (!string.IsNullOrEmpty(txtAhead.Text))
                    {
                        AdvancePNRQueue = string.Empty;
                        AdvancePNRQueue = string.Concat(AdvancePNRQueue,
                                      Resources.Queues.Constants.COMMANDS_QBE,
                                      Resources.Queues.Constants.LORRAINE_CROSS,
                                      txtAhead.Text.Trim());
                    }
                    else if (!string.IsNullOrEmpty(txtForward.Text))
                    {
                        AdvancePNRQueue = string.Empty;
                        AdvancePNRQueue = string.Concat(AdvancePNRQueue,
                                      Resources.Queues.Constants.COMMANDS_QBE,
                                      Resources.Queues.Constants.INDENT,
                                      txtForward.Text.Trim());
                    }
                }
                #endregion

                #region .:Remover Registro:.
                //Establece el comando para remover registro
                if (rdoRemoveRecord.Checked)
                {
                    //Establece Sabre a 'QR'
                    AdvancePNRQueue = string.Concat(AdvancePNRQueue, Resources.Queues.Constants.COMMANDS_QR);
                    if (!string.IsNullOrEmpty(txtAhead.Text))
                    {
                        AdvancePNRQueue = string.Empty;
                        AdvancePNRQueue = string.Concat(AdvancePNRQueue,
                                      Resources.Queues.Constants.COMMANDS_QBR,
                                      Resources.Queues.Constants.LORRAINE_CROSS,
                                      txtAhead.Text.Trim());
                    }
                    else if (!string.IsNullOrEmpty(txtForward.Text))
                    {
                        AdvancePNRQueue = string.Empty;
                        AdvancePNRQueue = string.Concat(AdvancePNRQueue,
                                      Resources.Queues.Constants.COMMANDS_QBR,
                                      Resources.Queues.Constants.INDENT,
                                      txtForward.Text.Trim());
                    }
                }
                #endregion
            }
        }

        /// <summary>
        /// Manda comandos al emulador de sabre
        /// </summary>
        private void commandsSend()
        {
            //Envia el comando para avanzar el PNR en la Queue
            using (CommandsAPI objCommands = new CommandsAPI())
            {
                objCommands.SendReceive(AdvancePNRQueue);
            }
        }

        #endregion


    }
}
