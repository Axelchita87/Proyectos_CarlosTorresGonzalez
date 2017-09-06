using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucAPISResidenceDestination : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite verificar la Residencia o destino
        /// Creación:    08 Diciembre   09 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez
        /// </summary>

        string domicile = string.Empty;
        string result = string.Empty;

        public ucAPISResidenceDestination()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtSegment1;
            this.LastControlFocus = btnAccept;
        }

        // User Control Load
        /// <summary>
        /// Solo pone el foco en el primer elemento que es Perfil de Compañia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucAPISResidenceDestination_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtSegment1.Focus();
        }

        //Button Accept
        /// <summary>
        /// Se realizan las validaciones despues de que el usuario ingresa datos, 
        /// se mandan los comandos y termina el proceso llamando a otro User Control 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidateBusinessRules)
            {
                CommandsSend();
                APIResponse();
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
        /// Valido que los campos obligatorios no esten vacios 
        /// </summary>
        private bool IsValidateBusinessRules
        {
            get
            {
                if (!(rdoDestination.Checked) &&
                    !(rdoResidence.Checked))
                {
                    MessageBox.Show("Debe de ingresar el Domicilio", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rdoDestination.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtCountry.Text))
                {
                    MessageBox.Show("Debe de ingresar País de Emisión", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCountry.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtStreet.Text))
                {
                    MessageBox.Show("Debe de ingresar la Calle", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtStreet.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtCity.Text))
                {
                    MessageBox.Show("Debe de ingresar Ciudad", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCity.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtZIP.Text))
                {
                    MessageBox.Show("Debe de ingresar Código Postal o ZIP", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtZIP.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtNumberPax.Text))
                {
                    MessageBox.Show("Debe de ingresar Número de Pasajero", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberPax.Focus();
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
            string send=string.Empty;
            send = "3DOCA";
            if (!string.IsNullOrEmpty(txtSegment1.Text))
                send = string.Concat(send, txtSegment1.Text);
            if(!string.IsNullOrEmpty(domicile))
                send = string.Concat(send, "/",domicile,"/", txtCountry.Text,
                    "/",txtStreet.Text,"/",txtCity.Text);
            if (!string.IsNullOrEmpty(txtState.Text))
                send = string.Concat(send, "/", txtState.Text);
            if (!string.IsNullOrEmpty(txtZIP.Text))
                send = string.Concat(send, "/", txtZIP.Text, "-", txtNumberPax.Text);

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                result = objCommand.SendReceive(send);
            }
        }

        #endregion

        #region ======= Change Tab =======

        private void rdoDestination_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                rdoResidence.TabStop = true;
        }

        private void rdoResidence_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                txtCountry.Focus();
        }

        private void txtSegment1_TextChanged(object sender, EventArgs e)
        {
            if (txtSegment1.Text.Length > 1)
                rdoDestination.Focus();
        }

        private void txtCountry_TextChanged(object sender, EventArgs e)
        {
            if (txtCountry.Text.Length > 1)
                txtStreet.Focus();
        }

        private void txtStreet_TextChanged(object sender, EventArgs e)
        {
            if (txtStreet.Text.Length > 19)
                txtCity.Focus();
        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {
            if (txtCity.Text.Length > 14)
                txtState.Focus();
        }

        private void txtState_TextChanged(object sender, EventArgs e)
        {
            if (txtState.Text.Length > 1)
                txtZIP.Focus();
        }

        private void txtZIP_TextChanged(object sender, EventArgs e)
        {
            if (txtZIP.Text.Length > 6)
                txtNumberPax.Focus();
        }

        private void txtNumberPax_TextChanged(object sender, EventArgs e)
        {
            if (txtNumberPax.Text.Length > 3)
                btnAccept.Focus();
        }

        private void txtSegment4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                rdoDestination.TabStop = true;
        }

        private void rdoDestination_CheckedChanged(object sender, EventArgs e)
        {
            domicile = "D";
        }

        private void rdoResidence_CheckedChanged(object sender, EventArgs e)
        {
            domicile = "R";
        }

        #endregion


        #region ===== Commons =====

        /// <summary>
        /// Busca errores en la clase de ERR_APISPassportMessage de acuerdo a las respuestas recibidas por el 
        /// Emulador de Sabre y de acuerdo a ellas se realizan ciertas acciones ya sea
        /// mandar un mensaje de error al usuario notificando del mismo o mandando a otro 
        /// User Control
        /// </summary>
        private void APIResponse()
        {
            if ((!string.IsNullOrEmpty(result)))
            {
                ERR_APISPassportMessage.err_apispassportmessage(result);

                if (ERR_APISPassportMessage.OtherMask)
                {
                    MessageBox.Show(ERR_APISPassportMessage.CustomUserMsg, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
                else if (ERR_APISPassportMessage.Status)
                    MessageBox.Show(ERR_APISPassportMessage.CustomUserMsg, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
        }

        #endregion

    }
}
