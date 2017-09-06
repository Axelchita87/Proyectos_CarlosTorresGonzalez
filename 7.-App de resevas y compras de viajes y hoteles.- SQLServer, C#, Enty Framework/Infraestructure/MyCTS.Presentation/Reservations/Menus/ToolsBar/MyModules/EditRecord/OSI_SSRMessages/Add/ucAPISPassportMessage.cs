using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucAPISPassportMessage : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite mandar mensaje de pasaporte
        /// Creación:    Diciembre 04 -Diciembre 09 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez
        /// </summary>
        
        string sex = string.Empty;
        string result = string.Empty;

        public ucAPISPassportMessage()
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
        private void ucAPISPassportMessage_Load(object sender, EventArgs e)
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
                if (string.IsNullOrEmpty(txtSegment1.Text))
                {
                    MessageBox.Show("Debe de ingresar el Segmento", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSegment1.Focus();
                    return false;
                }
                else if(string.IsNullOrEmpty(txtCountryEmission.Text))
                {
                    MessageBox.Show("Debe de ingresar País de Emisión", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCountryEmission.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtPassportNumber.Text))
                {
                    MessageBox.Show("Debe de ingresar Número de Pasaporte", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassportNumber.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtNationality.Text))
                {
                    MessageBox.Show("Debe de ingresar Nacionalidad", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNationality.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtBirthday.Text))
                {
                    MessageBox.Show("Debe de ingresar Fecha de Nacimiento", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBirthday.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtExpiredDate.Text))
                {
                    MessageBox.Show("Debe de ingresar Fecha de Expiración", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtExpiredDate.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtLastName.Text))
                {
                    MessageBox.Show("Debe de ingresar Apellido", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLastName.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtFirstName.Text))
                {
                    MessageBox.Show("Debe de ingresar Primer Nombre", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFirstName.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtNumberPax.Text))
                {
                    MessageBox.Show("Debe de ingresar Número de Pasajero", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberPax.Focus();
                    return false;
                }
                else if (!(rdoFemale.Checked) &&
                        !(rdoMale.Checked))
                {
                    MessageBox.Show("Debe de ingresar el Sexo", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rdoFemale.Focus();
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
            send = "3DOCS";
            if (!string.IsNullOrEmpty(txtSegment1.Text))
                send = string.Concat(send, txtSegment1.Text);
            if (!string.IsNullOrEmpty(txtSegment2.Text))
                send = string.Concat(send, txtSegment2.Text);
            if (!string.IsNullOrEmpty(txtSegment3.Text))
                send = string.Concat(send, txtSegment3.Text);
            if (!string.IsNullOrEmpty(txtSegment4.Text))
                send = string.Concat(send, txtSegment4.Text);
            if (!string.IsNullOrEmpty(txtCountryEmission.Text))
            {
                send = string.Concat(send, "/P/", txtCountryEmission.Text,
                "/", txtPassportNumber.Text, "/", txtNationality.Text,
                "/", txtBirthday.Text, "/", sex, "/", txtExpiredDate.Text,
                "/", txtLastName.Text, "/", txtFirstName.Text);
            }
            if (!string.IsNullOrEmpty(txtSecondName.Text))
                send = string.Concat(send, "/", txtSecondName.Text);
            if (!string.IsNullOrEmpty(txtNumberPax.Text))
                send = string.Concat(send, "/H-", txtNumberPax.Text);

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                result = objCommand.SendReceive(send);
            }
        }

        #endregion

        #region ====== ChangeFocus ========

        private void txtSegment1_TextChanged(object sender, EventArgs e)
        {
            if (txtSegment1.Text.Length > 1)
                txtSegment2.Focus();
        }

        private void txtSegment2_TextChanged(object sender, EventArgs e)
        {
            if (txtSegment2.Text.Length > 1)
                txtSegment3.Focus();
        }

        private void txtSegment3_TextChanged(object sender, EventArgs e)
        {
            if (txtSegment3.Text.Length > 1)
                txtSegment4.Focus();
        }

        private void txtSegment4_TextChanged(object sender, EventArgs e)
        {
            if (txtSegment4.Text.Length > 1)
                txtCountryEmission.Focus();
        }

        private void txtCountryEmission_TextChanged(object sender, EventArgs e)
        {
            if (txtCountryEmission.Text.Length > 1)
                txtPassportNumber.Focus();
        }

        private void txtPassportNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtPassportNumber.Text.Length > 11)
                txtNationality.Focus();
        }

        private void txtNationality_TextChanged(object sender, EventArgs e)
        {
            if (txtNationality.Text.Length > 1)
                txtBirthday.Focus();
        }

        private void txtBirthday_TextChanged(object sender, EventArgs e)
        {
            if (txtBirthday.Text.Length > 6)
                rdoFemale.Focus();
        }

        private void txtExpiredDate_TextChanged(object sender, EventArgs e)
        {
            if (txtExpiredDate.Text.Length > 6)
                txtLastName.Focus();
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            if (txtLastName.Text.Length > 14)
                txtFirstName.Focus();
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            if (txtFirstName.Text.Length > 14)
                txtSecondName.Focus();
        }

        private void txtSecondName_TextChanged(object sender, EventArgs e)
        {
            if (txtFirstName.Text.Length > 0)
                txtNumberPax.Focus();
        }

        private void txtNumberPax_TextChanged(object sender, EventArgs e)
        {
            if (txtNumberPax.Text.Length > 3)
                btnAccept.Focus();
        }

        private void rdoFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoFemale.Checked)
                sex = "F";
        }

        private void rdoMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoMale.Checked)
                sex = "M";
        }

        private void rdoFemale_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                rdoMale.TabStop = true;
        }

        private void rdoMale_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                txtExpiredDate.Focus();
        }

        private void txtBirthday_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                rdoFemale.TabStop = true;
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
