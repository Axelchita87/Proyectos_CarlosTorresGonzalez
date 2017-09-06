using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucHistoryRecordQueue : CustomUserControl
    {
        /// <summary>
        /// Descripción: User Control que permite realizar una serie de opciones
        ///              a ejcutar con los códigos personalizados del agente dentro de una Queue
        ///              dentro de una Queue en especifico
        ///              Parte del modulo de Queues
        /// Creación:    Junio 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Jessica Gutierrez
        /// </summary>

        public ucHistoryRecordQueue()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = rdoDisplaySistemCode;
            this.LastControlFocus = btnAccept;
        }

        //Evento Load
        private void ucHistoryRecordQueue_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            rdoDisplaySistemCode.Focus();
        }

        /// <summary>
        /// Ejecuta las funciones de la mascarilla de "Referencias de Pic Codes"
        /// al presionar el boton Aceptar
        /// </summary>
        /// <param name="sender">btnAccept</param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidateBusinessRules)
            {
                CommandsSend();
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
        }

        /// <summary>
        /// Aborta el proceso al presionar la tecla ESC o ejecuta
        /// las funciones al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }

        #region ======== Change Focus =======

        //Evento txtPCC_TextChanged
        private void txtPCC_TextChanged(object sender, EventArgs e)
        {
            if (txtPCC.Text.Length > 3)
                btnAccept.Focus();
        }

        //Evento txtCode_TextChanged
        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            if (txtCode.Text.Length > 2)
                txtText.Focus();
        }

        //Evento txtText_TextChanged
        private void txtText_TextChanged(object sender, EventArgs e)
        {
            if (txtText.Text.Length > 49)
                btnAccept.Focus();
        }

        #endregion

        #region ===== methodsClass =====

        /// <summary>
        /// Reglas de negocio aplicables para esta mascarilla
        /// </summary>
        private bool IsValidateBusinessRules
        {
            get
            {
                if (txtCode.Visible && string.IsNullOrEmpty(txtCode.Text))
                {
                    MessageBox.Show(Resources.Queues.Queues.NECESITA_INGRESAR_CODIGO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCode.Focus();
                    return false;
                }
                else if (txtText.Visible && string.IsNullOrEmpty(txtText.Text))
                {
                    MessageBox.Show(Resources.Queues.Queues.NECESITA_INGRESAR_TEXTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtText.Focus();
                    return false;
                }
                else
                    return true;
            }
        }

        /// <summary>
        /// Armado y envio del comando a mySabre
        /// </summary>
        private void CommandsSend()
        {
            string sabre=string.Empty;
            if (rdoDisplaySistemCode.Checked)
                sabre = Resources.Queues.Constants.COMMANDS_QI_AST_S_AST;
            else if (rdoDeployCustomCode.Checked)
            {
                sabre = Resources.Queues.Constants.COMMANDS_QI_AST;
                if(!string.IsNullOrEmpty(txtPCC.Text))
                    sabre=string.Concat(sabre,txtPCC.Text);
                else
                    sabre=string.Concat(sabre,
                        Resources.Queues.Constants.COMMANDS_SYS);
            }
            else if (rdoAddCustomCode.Checked)
            {
                sabre = Resources.Queues.Constants.COMMANDS_QI_SLASH +
                    txtCode.Text + Resources.Queues.Constants.COMMANDS_SLASH_A_INDENT +
                    txtText.Text;
            }
            else if (rdoCustomCodeChange.Checked)
            {
                sabre = Resources.Queues.Constants.COMMANDS_QI_SLASH +
                     txtCode.Text + Resources.Queues.Constants.COMMANDS_SLASH_C_INDENT +
                    txtText.Text;
            }
            else if (rdoDeleteCustomCode.Checked)
            {
                sabre = Resources.Queues.Constants.COMMANDS_QI_SLASH +
                    txtCode.Text + Resources.Queues.Constants.COMMANDS_SLASH_DELETE;
            }
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(sabre);
            }
        }

            #region ===== Commons ======

            /// <summary>
            /// Muestra controles cuando algunas opciones estan activadas
            /// </summary>
            /// <param name="show">bandera de estado activada por varias opciones</param>
            private void ShowCode(bool show)
            {
                txtCode.Visible = show;
                txtText.Visible = show;
                lblCode.Visible = show;
                lblText.Visible = show;
            }

            /// <summary>
            /// Esconde controles cuando algunas opciones estan activadas
            /// </summary>
            /// <param name="show">bandera de estado activada por varias opciones</param>
            private void Hide(bool show)
            {
                txtCode.Visible = show;
                txtText.Visible = show;
                txtPCC.Visible = show;
                lblText.Visible = show;
                lblText.Visible = show;
                lblPCC.Visible = show;
                lblCode.Visible = show;
            }

            #endregion

        #endregion

        #region ====== Change Radious ======

        //evento rdoDisplaySistemCode_CheckedChanged
        private void rdoDisplaySistemCode_CheckedChanged(object sender, EventArgs e)
        {
            Hide(false);
        }

        //evento rdoDeployCustomCode_CheckedChanged
        private void rdoDeployCustomCode_CheckedChanged(object sender, EventArgs e)
        {
            ShowCode(false);
            txtPCC.Visible = true;
            lblPCC.Visible = true;
            txtPCC.Focus();
        }

        //evento rdoAddCustomCode_CheckedChanged
        private void rdoAddCustomCode_CheckedChanged(object sender, EventArgs e)
        {
            ShowCode(true);
            txtPCC.Visible = false;
            lblPCC.Visible = false;
            txtCode.Focus();
        }

        //evento rdoCustomCodeChange_CheckedChanged
        private void rdoCustomCodeChange_CheckedChanged(object sender, EventArgs e)
        {
            ShowCode(true);
            txtPCC.Visible = false;
            lblPCC.Visible = false;
            txtCode.Focus();
        }

        //evento rdoDeleteCustomCode_CheckedChanged
        private void rdoDeleteCustomCode_CheckedChanged(object sender, EventArgs e)
        {
            Hide(false);
            txtCode.Visible = true;
            lblCode.Visible = true;
            txtCode.Focus();
        }

        #endregion
    }
}
