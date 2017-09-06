using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucAccountsRecordQueues : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permiete ver las Queue presentes,pertenece a Queue
        /// Creación:    17/Junio/09 , Modificación:*
        /// Cambio:      * , Solicito*
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        public ucAccountsRecordQueues()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
             ControlStyles.UserPaint |
             ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtQueue;
            this.LastControlFocus = btnAccept;
        }


        //Use Control Load 
        private void ucAccountsRecordQueues_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtQueue.Focus();
        }

        //Button Accept
        /// <summary>
        /// Se verifica que la tarjeta de credito seleccionada este dentro de la 
        /// Base de Datos y despues se hacen las validaciones y se envian los commandos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidateBusinessRules)
                CommandsSend();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }

        //KeyDown
        /// <summary>
        /// Este se usa para todos los controles en general si se oprime 
        /// Esc se manda a el User control de Welcome 
        /// Enter se manda la accion de botón de Aceptar
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

        // Cambia de Foco entre cada Control
        private void txtQueue_TextChanged(object sender, EventArgs e)
        {
            if (txtQueue.Text.Length > 2)
                txtRange.Focus();
        }

        private void txtRange_TextChanged(object sender, EventArgs e)
        {
            if (txtRange.Text.Length > 2)
                txtQueue2.Focus();
        }

        private void txtQueue2_TextChanged(object sender, EventArgs e)
        {
            if (txtQueue2.Text.Length > 2)
                txtCodePseudoCity.Focus();

        }

        private void txtCodePseudoCity_TextChanged(object sender, EventArgs e)
        {
            if (txtCodePseudoCity.Text.Length > 3)
                btnAccept.Focus();
        }

        #endregion 

        #region ===== methodsClass =====

        /// <summary>
        /// Se validan que existan los datos que son obligatorios
        /// </summary>
        private bool IsValidateBusinessRules
        {
            get
            {
                if (!string.IsNullOrEmpty(txtRange.Text) && !string.IsNullOrEmpty(txtQueue2.Text))
                {
                    MessageBox.Show(Resources.Queues.Queues.COMBINACIÓN_INVALIDA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQueue2.Focus();
                    return false;
                }
                else
                    return true;
            }
        }

        /// <summary>
        /// Se envia el commando de acuerdo a los datos que contiene
        /// los TextBox 
        /// </summary>
        private void CommandsSend()
        {
            string sabre = string.Empty;
            sabre = Resources.Queues.Constants.COMMANDS_QC_SLASH;

            if (!string.IsNullOrEmpty(txtCodePseudoCity.Text))
                sabre = string.Concat(sabre, txtCodePseudoCity.Text);
            if (!string.IsNullOrEmpty(txtQueue.Text))
            {
                sabre=string.Concat(sabre, txtQueue.Text);
                 if(!string.IsNullOrEmpty(txtRange.Text))
                     sabre=string.Concat(sabre,Resources.Queues.Constants.INDENT,
                         txtRange.Text);
            }
            if (!string.IsNullOrEmpty(txtQueue2.Text))
            {
                sabre = string.Concat(sabre, Resources.Queues.Constants.SLASH,
                    txtQueue2.Text);
            }
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(sabre);
            }
        }

        #endregion
    }
}
