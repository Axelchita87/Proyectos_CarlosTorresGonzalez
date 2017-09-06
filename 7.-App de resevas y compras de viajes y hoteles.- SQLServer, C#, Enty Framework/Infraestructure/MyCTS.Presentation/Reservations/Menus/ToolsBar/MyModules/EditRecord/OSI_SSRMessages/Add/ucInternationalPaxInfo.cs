using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using MyCTS.Forms.UI;

namespace MyCTS.Presentation
{
    public partial class ucInternationalPaxInfo : CustomUserControl
    {
        /// <summary>
        /// Descripción: User Control que permite agregar información del pasajero
        ///              cuando se trata de un vuelo internacional
        /// Creación:    04 diciembre 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        public ucInternationalPaxInfo()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtAirline;
            this.LastControlFocus = btnAccept;
        }


        //Evento Load           
        private void ucInternationalPaxInfo_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtAirline.Focus();
        }


        //Evento btnAccept_Click
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!IsValidBusinessRules)
            {
                CommandsSend();
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
        }

        #region===== MethodsClass =====

        /// <summary>
        /// Validaciones de Regla de Negocios de las opciones seleccionadas
        /// </summary>
        /// <returns></returns>
        private bool IsValidBusinessRules
        {
            get
            {
                bool isValid = true;
                if (string.IsNullOrEmpty(txtAirline.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_COD_AEREOLINEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirline.Focus();
                }
                else if (string.IsNullOrEmpty(txtSurname.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_APELLIDO_PAX, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSurname.Focus();
                }
                else if (string.IsNullOrEmpty(txtName.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_NOMBRE_PAX, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Focus();
                }
                else if (string.IsNullOrEmpty(txtPaxNumber.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_NUM_PAX, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPaxNumber.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtPaxNumber.Text) && (!ValidateRegularExpression.ValidateOneorTwoPlusDecimalNumber(txtPaxNumber.Text))))
                {
                    MessageBox.Show(Resources.Reservations.FORMATO_NUM_PAX_ES_INCORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPaxNumber.Focus();
                }
                else if (string.IsNullOrEmpty(txtBirthday.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_FECHA_NACIMIENTO_PAX, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBirthday.Focus();
                }
                else if (!string.IsNullOrEmpty(txtBirthday.Text) && !ValidateRegularExpression.ValidateBirthDateFormat(txtBirthday.Text))
                {
                    MessageBox.Show(Resources.Reservations.FORMATO_FECHA_NACIMIENTO_INCORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBirthday.Focus();
                }
                else if (string.IsNullOrEmpty(txtPassport.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_NUM_PASAPORTE_PAX, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassport.Focus();
                }
                else if (string.IsNullOrEmpty(txtNationality.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_COD_NACIONALIDAD_PAX, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNationality.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtFamiliarName.Text) && (string.IsNullOrEmpty(txtCountry.Text) || string.IsNullOrEmpty(txtPhone.Text))) ||
                   (!string.IsNullOrEmpty(txtCountry.Text) && (string.IsNullOrEmpty(txtFamiliarName.Text) || string.IsNullOrEmpty(txtPhone.Text))) ||
                   (!string.IsNullOrEmpty(txtPhone.Text) && (string.IsNullOrEmpty(txtCountry.Text) || string.IsNullOrEmpty(txtFamiliarName.Text))))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_DATOS_COMPLETOS_PARA_AGREGAR_REFERENCIAS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrEmpty(txtFamiliarName.Text))
                        txtFamiliarName.Focus();
                    else if (string.IsNullOrEmpty(txtCountry.Text))
                        txtCountry.Focus();
                    else if (string.IsNullOrEmpty(txtPhone.Text))
                        txtPhone.Focus();
                }
                else
                {
                    isValid = false;
                }

                return isValid;
            }
        }

        /// <summary>
        /// Envia el comando correspondiente para ingresar los datos del pasajero si es vuelo internacional
        /// </summary>
        private void CommandsSend()
        {
            string send = string.Empty;
            string nextSend = string.Empty;

            if (txtAirline.Text.Equals(Resources.Constants.AMERICAN_AIRLINES_CODE))
            {
                send = string.Concat(Resources.Constants.COMMANDS_4_PSPT,
                    Resources.Constants.SLASH,
                    txtPassport.Text,
                    Resources.Constants.SLASH,
                    txtNationality.Text,
                    Resources.Constants.SLASH,
                    txtBirthday.Text,
                    Resources.Constants.INDENT,
                    txtSurname.Text,
                    Resources.Constants.SLASH,
                    txtName.Text,
                    Resources.Constants.INDENT,
                    txtPaxNumber.Text);

                if (!string.IsNullOrEmpty(txtFamiliarName.Text))
                {
                    nextSend = string.Concat(Resources.Constants.COMMANDS_4PCTC,
                        txtFamiliarName.Text,
                        Resources.Constants.SLASH,
                        txtCountry.Text,
                        txtPhone.Text);
                }
                else
                    nextSend = string.Empty;
            }
            else
            {
                send = string.Concat(Resources.Constants.COMMANDS_3PCTC,
                    Resources.Constants.SLASH,
                    txtPassport.Text,
                    Resources.Constants.SLASH,
                    txtNationality.Text,
                    Resources.Constants.INDENT,
                    txtPaxNumber.Text);

                if (!string.IsNullOrEmpty(txtFamiliarName.Text))
                {
                    send = string.Concat(send,
                        Resources.Constants.ENDIT,
                        Resources.Constants.COMMANDS_3PCTC,
                        Resources.Constants.SLASH,
                        Resources.Constants.COMMANDS_CONTACT,
                        txtFamiliarName.Text,
                        Resources.Constants.SLASH,
                        txtCountry.Text,
                        txtPhone.Text);

                }
                else
                    nextSend = string.Empty;
            }

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);

                if (!string.IsNullOrEmpty(nextSend))
                    objCommand.SendReceive(nextSend);
            }
        }

        #endregion//End MethodsClass


        #region=====Change focus When a Textbox is Full=====

        //Evento txtControls_TextChanged
        private void txtControls_TextChanged(object sender, EventArgs e)
        {
            if (sender is SmartTextBox)
            {
                if (((SmartTextBox)sender).Text.Length > ((SmartTextBox)sender).MaxLength - 1)
                {
                    foreach (Control txt in this.Controls)
                    {
                        if (txt.TabIndex.Equals(((SmartTextBox)(sender)).TabIndex + 1))
                        {
                            txt.Focus();
                        }

                    }
                }
            }

        }

        #endregion//End Change focus When a Textbox is Full


        #region =====Back to a Previous Usercontrol or Validate Enter KeyDown=====


        /// <summary>
        /// Aborta el proceso al presionar la tecla ESC o ejecuta las 
        /// instrucciones al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData.Equals(Keys.Escape))
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);



            if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }


        }

        #endregion//End Back to a Previous Usercontrol or Validate Enter KeyDown
    }
}
