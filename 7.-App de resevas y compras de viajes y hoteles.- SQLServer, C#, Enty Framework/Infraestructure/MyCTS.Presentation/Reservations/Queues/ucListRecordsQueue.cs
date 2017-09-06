using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MyCTS.Presentation.Components;


namespace MyCTS.Presentation
{
    public partial class ucListRecordsQueue : CustomUserControl
    {
        /// <summary>
        /// Descripción: User Control que permite desplegar la lista de records
        ///              dentro de una Queue en especifico
        ///              Parte del modulo de Queues
        /// Creación:    Junio 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Jessica Gutierrez
        /// </summary>


        public ucListRecordsQueue()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtQueue;
            this.LastControlFocus = btnAccept;
        }

        //Evento Load
        private void ucListRecordsQueue_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtQueue.Focus();
        }

        /// <summary>
        /// Ejecuta las funciones de la mascarilla de "Lista de Records en Queue"
        /// al presionar el boton Aceptar
        /// </summary>
        /// <param name="sender">btnAccept</param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidateBusinessRules)
                CommandsSend();
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

        //Evento txtQueue_TextChanged
        private void txtQueue_TextChanged(object sender, EventArgs e)
        {
            if (txtQueue.Text.Length > 2)
                txtpcc.Focus();
        }

        //Evento txtpcc_TextChanged
        private void txtpcc_TextChanged(object sender, EventArgs e)
        {
            if (txtpcc.Text.Length > 3)
                btnAccept.Focus();
        }

        #endregion

        #region ===== methodsClass =====

        /// <summary>
        /// Validación de reglas de negocio correspondientes a esta mascarilla
        /// </summary>
        private bool IsValidateBusinessRules
        {
            get
            {
                if (string.IsNullOrEmpty(txtQueue.Text))
                {
                    MessageBox.Show(Resources.Queues.Queues.REQUIERE_INGRESAR_QUEUE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQueue.Focus();
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
            string sabre = string.Empty;
            sabre = Resources.Queues.Constants.COMMANDS_Q_SLASH;

            if (!string.IsNullOrEmpty(txtpcc.Text))
            {
                sabre = string.Concat(sabre, txtpcc.Text, txtQueue.Text,
                    Resources.Queues.Constants.COMMANDS_SLASH_L);
            }
            else
            {
                sabre = string.Concat(sabre, txtQueue.Text,
                    Resources.Queues.Constants.COMMANDS_SLASH_L);
            }
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(sabre);
            }

            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }

        #endregion
    }
}
