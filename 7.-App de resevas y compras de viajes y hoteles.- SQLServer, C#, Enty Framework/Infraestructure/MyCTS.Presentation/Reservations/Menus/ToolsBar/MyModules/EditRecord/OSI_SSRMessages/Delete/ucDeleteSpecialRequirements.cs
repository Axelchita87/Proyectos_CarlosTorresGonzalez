using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucDeleteSpecialRequirements : CustomUserControl
    {

        /// <summary>
        /// Descripcion: Permite borrar requerimientos de aerolineas
        /// Creación:    09 - Diciembre 09 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez
        /// </summary>

        public ucDeleteSpecialRequirements()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtLine1;
            this.LastControlFocus = btnAccept;
        }

        private void ucDeleteSpecialRequirements_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtLine1.Focus();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidateBusinessRules)
            {
                CommandsSend();
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
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


        #region ===== Chage Focus ========

        private void txtLine1_TextChanged(object sender, EventArgs e)
        {
            if (txtLine1.Text.Length > 2)
                txtRange4.Focus();
        }

        private void txtRange4_TextChanged(object sender, EventArgs e)
        {
            if (txtRange4.Text.Length > 2)
                txtLine1.Focus();
        }

        #endregion


        #region ===== methodsClass =====

        /// <summary>
        /// Valido que los campos obligatorios no esten vacios 
        /// </summary>
        private bool IsValidateBusinessRules
        {
            get
            {
                if (string.IsNullOrEmpty(txtLine1.Text))
                {
                    MessageBox.Show("Debe de ingresar la Línea", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLine1.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Se envia el comando de acuerdo a los campos ingresados
        /// </summary>
        private void CommandsSend()
        {
            string send = string.Empty;
            send = string.Concat(ucMenuReservations.airLine, txtLine1.Text);
            if (!string.IsNullOrEmpty(txtRange4.Text))
                send = string.Concat(send, "-", txtRange4.Text);

            send = string.Concat(send, "@");

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }

        #endregion


    }
}
