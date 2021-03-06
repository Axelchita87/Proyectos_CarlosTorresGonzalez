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
    public partial class ucOSIMessageFOID : CustomUserControl
    {

        /// <summary>
        /// Descripción: User control que ingresa datos del pasajero relacionados con requerimientos    
        ///              de las embajadas para investigacion de este o mensajes FOID
        /// Creación:    07 diciembre 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        /// 
        public ucOSIMessageFOID()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtEmisorCountry;
            this.LastControlFocus = btnAccept;
        }


        //Evento Load
        private void ucOSIMessageFOID_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtEmisorCountry.Focus();
        }


        //Evento btnAccept_Click
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!IsValidBusinessRules)
            {
                CommandsSend();
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
                if ((!string.IsNullOrEmpty(txtEmisorCountry.Text) && string.IsNullOrEmpty(txtPassport.Text)) ||
                    (string.IsNullOrEmpty(txtEmisorCountry.Text) && !string.IsNullOrEmpty(txtPassport.Text)))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_TODOS_LOS_DATOS_FOID_POR_PASAPORTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if(string.IsNullOrEmpty(txtEmisorCountry.Text))
                        txtEmisorCountry.Focus();
                    else if (string.IsNullOrEmpty(txtPassport.Text))
                        txtPassport.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtEmisorBank.Text) && string.IsNullOrEmpty(txtCardNumber.Text)) ||
                    (string.IsNullOrEmpty(txtEmisorBank.Text) && !string.IsNullOrEmpty(txtCardNumber.Text)))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_TODOS_LOS_DATOS_FOID_POR_TARJETA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrEmpty(txtEmisorBank.Text))
                        txtEmisorBank.Focus();
                    else if (string.IsNullOrEmpty(txtCardNumber.Text))
                        txtCardNumber.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtPaxNumber.Text) && (!ValidateRegularExpression.ValidateOneorTwoPlusDecimalNumber(txtPaxNumber.Text))))
                {
                    MessageBox.Show(Resources.Reservations.FORMATO_NUM_PAX_ES_INCORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPaxNumber.Focus();
                }
                else
                {
                    isValid = false;
                }

                return isValid;
            }
        }

        /// <summary>
        /// Envia el comando para ingresar mensajes FOID a MySabre
        /// </summary>
        private void CommandsSend()
        {
            string send = string.Empty;
            string sabreAnswer = string.Empty;

            if(!string.IsNullOrEmpty(txtEmisorCountry.Text) &&
                !string.IsNullOrEmpty(txtPassport.Text))
                send = string.Concat(Resources.Constants.COMMANDS_3FOID_SLASH_PP,
                   txtEmisorCountry.Text,
                   txtPassport.Text);

            if (!string.IsNullOrEmpty(txtPaxNumber.Text))
                send = string.Concat(send,
                    Resources.Constants.INDENT,
                    txtPaxNumber.Text);

            if (!string.IsNullOrEmpty(txtEmisorBank.Text) &&
                !string.IsNullOrEmpty(txtCardNumber.Text))
            {
                send = string.Concat(send,
                    Resources.Constants.ENDIT,
                    Resources.Constants.COMMANDS_3FOID_SLASH_CC,
                   txtEmisorBank.Text,
                   txtCardNumber.Text);

                if (!string.IsNullOrEmpty(txtPaxNumber.Text))
                    send = string.Concat(send,
                        Resources.Constants.INDENT,
                        txtPaxNumber.Text);
            }

            send = send.TrimStart(new char[] { 'Σ' });

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }

            APIRespose(sabreAnswer);
        }


        private void APIRespose(string result)
        {
            int row = 0;
            int col = 0; 
            CommandsQik.searchResponse(result, Resources.ErrorMessages.NO_VALID_SEGMENT_FOUND, ref row, ref col);
            if (row > 0)
                MessageBox.Show(Resources.Reservations.ERROR_INGRESAR_DATOS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
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
