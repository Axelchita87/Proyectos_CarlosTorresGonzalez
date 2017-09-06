using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Forms.UI;


namespace MyCTS.Presentation
{
    public partial class ucDetailsAvailability : CustomUserControl
    {

        /// <summary>
        /// Descripcion: Permite ver los detalles de la Disponibilidad
        /// Creación:    Enero 28 -Enero 10 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        public ucDetailsAvailability()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtLine1;
            this.LastControlFocus = btnAccept;
        }

        //Load user Control Details Availability
        private void ucDetailsAvailability_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtLine1.Focus();
        }

        /// <summary>
        /// Valida el contenido y manda comando
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidBussinessRules)
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

        #region ===== methodsClass =====

        /// <summary>
        /// Valido que los campos obligatorios no esten vacios y que no 
        /// contengan datos no permitidos.
        /// </summary>
        private bool IsValidBussinessRules
        {
            get
            {
                bool isValid = false;

                if (string.IsNullOrEmpty(txtLine1.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_NÚMERO_LÍNEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLine1.Focus();
                 }
                else
                {
                    isValid = true;
                }
                return isValid;
            }
        }

        /// <summary>
        /// Se envia el comando de acuerdo a los campos ingresados
        /// </summary>
        private void CommandsSend()
        {
            string send = string.Empty;
            send = "VA*";
            if (!string.IsNullOrEmpty(txtLine1.Text))
            {
                send = string.Concat(send, txtLine1.Text);
                if (!string.IsNullOrEmpty(txtRange4.Text))
                    send = string.Concat(send, Resources.Constants.INDENT, txtRange4.Text);

                if (!string.IsNullOrEmpty(txtLine2.Text))
                    send = string.Concat(send, Resources.Constants.SLASH, txtLine2.Text);

                using (CommandsAPI objCommnads = new CommandsAPI())
                {
                     objCommnads.SendReceive(send);
                }
            }
        }

        #endregion
    }
}
