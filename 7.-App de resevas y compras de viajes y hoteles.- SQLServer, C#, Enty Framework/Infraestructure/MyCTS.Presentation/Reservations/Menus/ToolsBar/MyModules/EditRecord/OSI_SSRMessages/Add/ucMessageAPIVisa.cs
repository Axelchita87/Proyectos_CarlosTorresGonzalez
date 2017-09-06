using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using MyCTS.Forms.UI;


namespace MyCTS.Presentation

{
    public partial class ucMessageAPIVisa : CustomUserControl
    {
        /// <summary>
        /// Descripción: User control que agrega mensajes Api visa que detalla
        ///              el usuario por tipo de pasajero
        /// Creación:    07 diciembre 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Angel Trejo Arizmendi
        /// </summary>
        
        #region=====Declaration of variables=====

        private string send = string.Empty;
        private string sabreAnswer = string.Empty;
        private string segment1 = string.Empty;
        private string segment2 = string.Empty;
        private string segment3 = string.Empty;
        private string segment4 = string.Empty;
        private string birthPlace = string.Empty;
        private string visaNumber = string.Empty;
        private string cityBroadcast = string.Empty;
        private string dateBroadcast = string.Empty;
        private string countryApplicable = string.Empty;
        private string paxNumber = string.Empty;

        #endregion //Declaration of variable

        public ucMessageAPIVisa()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtSegment1;
            this.LastControlFocus = btnAccept;
        }

        private void ucMessageAPIVisa_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            send = string.Empty;
            sabreAnswer = string.Empty;
            segment1 = string.Empty;
            segment2 = string.Empty;
            segment3 = string.Empty;
            segment4 = string.Empty;
            birthPlace = string.Empty;
            visaNumber = string.Empty;
            cityBroadcast = string.Empty;
            dateBroadcast = string.Empty;
            countryApplicable = string.Empty;
            paxNumber = string.Empty;
            txtSegment1.Focus();
            rdoAdult.Checked = true;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidBussinesRules && IsValidDate)
            {
                BuildCommand();
                SendCommand();
            }
        }

        #region======Methods Class=====

        /// <summary>
        /// Validación de las reglas de negocio que aplican para este
        /// user control
        /// </summary>
        private bool IsValidBussinesRules
        {
            get
            {
                bool isValid = false;
                if (string.IsNullOrEmpty(txtSegment1.Text))
                {
                    MessageBox.Show(Resources.Reservations.DEBES_ING_PRIMER_SEGEMEMTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSegment1.Focus();
                }
                else if (string.IsNullOrEmpty(txtBirthPlace.Text) && !rdoInfant.Checked)
                {
                    MessageBox.Show(Resources.Reservations.DEBES_ING_LUGAR_NACIMIENTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBirthPlace.Focus();
                }
                else if (string.IsNullOrEmpty(txtNumberOfVisa.Text))
                {
                    MessageBox.Show(Resources.Reservations.DEBES_ING_NUM_VISA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberOfVisa.Focus();
                }
                else if (string.IsNullOrEmpty(txtCityBrodcast.Text))
                {
                    MessageBox.Show(Resources.Reservations.DEBES_ING_CIUDAD_EMISION, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCityBrodcast.Focus();
                }
                else if (string.IsNullOrEmpty(txtDateBrodcast.Text))
                {
                    MessageBox.Show(Resources.Reservations.DEBES_ING_FECHA_EMISION, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDateBrodcast.Focus();
                }
                else if (!ValidateRegularExpression.ValidateBirthDateFormat(txtDateBrodcast.Text))
                {
                    MessageBox.Show(Resources.Reservations.FORMATO_FECHA_EMISION_NO_VALIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDateBrodcast.Focus();
                }
                else if (!rdoAdult.Checked && !rdoBoy.Checked && !rdoInfant.Checked)
                {
                    MessageBox.Show(Resources.Reservations.DEBES_INDICAR_TIPO_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rdoAdult.Focus();
                }
                else if (string.IsNullOrEmpty(txtCountryWhereApplicable.Text)&&!rdoBoy.Checked)
                {
                    MessageBox.Show(Resources.Reservations.DEBES_INDICAR_PAIS_DONDE_APLICA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCountryWhereApplicable.Focus();
                }
                else if (string.IsNullOrEmpty(txtPaxNumber.Text)&&!rdoAdult.Checked)
                {
                    MessageBox.Show(Resources.Reservations.DEBES_ING_NUM_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPaxNumber.Focus();
                }
                else if (!ValidateRegularExpression.ValidateOneorTwoPlusDecimalNumber(txtPaxNumber.Text) && !rdoAdult.Checked)
                {
                    MessageBox.Show(Resources.Reservations.NUM_PASAJERO_NO_VALIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPaxNumber.Focus();
                }
                else
                    isValid = true;
                return isValid;
            }
        }

        /// <summary>
        /// Validación para la fecha ingresada
        /// </summary>
        private bool IsValidDate
        {
            get
            {
                bool isValid = false;
                dateBroadcast = txtDateBrodcast.Text;
                DateTime broadcast = new DateTime();
                try
                {
                    broadcast = Convert.ToDateTime(dateBroadcast);
                    isValid = true;
                }
                catch
                {
                    MessageBox.Show(Resources.Reservations.FECHA_EMISION_NO_VALIDA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDateBrodcast.Focus();
                }
                return isValid;
            }
        }

        /// <summary>
        /// Armado del comando que se envia al API
        /// </summary>
        private void BuildCommand()
        {
            segment1 = txtSegment1.Text;
            segment2 = txtSegment2.Text;
            segment3 = txtSegment3.Text;
            segment4 = txtSegment4.Text;
            birthPlace = txtBirthPlace.Text;
            visaNumber = txtNumberOfVisa.Text;
            cityBroadcast = txtCityBrodcast.Text;
            countryApplicable = txtCountryWhereApplicable.Text;
            paxNumber = txtPaxNumber.Text;
            send = string.Concat(Resources.Constants.COMMANDS_THREE_DOCO, segment1);
            if (!string.IsNullOrEmpty(segment2))
                send = string.Concat(send, Resources.Constants.COMMANDS_COMMA, segment2);
            if (!string.IsNullOrEmpty(segment3))
                send = string.Concat(send, Resources.Constants.COMMANDS_COMMA, segment3);
            if (!string.IsNullOrEmpty(segment4))
                send = string.Concat(send, Resources.Constants.COMMANDS_COMMA, segment4);
            if (rdoBoy.Checked)
                send = string.Concat(send, Resources.Constants.SLASH, birthPlace, Resources.Constants.SLASH_V_SLASH,
                visaNumber, Resources.Constants.SLASH, cityBroadcast, Resources.Constants.SLASH, dateBroadcast,
                Resources.Constants.SLASH, Resources.Constants.COMMANDS_CH, Resources.Constants.INDENT, paxNumber);
            if (rdoInfant.Checked)
                send = string.Concat(send, Resources.Constants.SLASH, Resources.Constants.SLASH_V_SLASH,
                visaNumber, Resources.Constants.SLASH, cityBroadcast, Resources.Constants.SLASH, dateBroadcast,
                Resources.Constants.SLASH,countryApplicable,Resources.Constants.SLASH, Resources.Constants.COMMANDS_I, Resources.Constants.INDENT, paxNumber);
            if (rdoAdult.Checked)
                send = string.Concat(send, Resources.Constants.SLASH, birthPlace, Resources.Constants.SLASH_V_SLASH,
                visaNumber, Resources.Constants.SLASH, cityBroadcast, Resources.Constants.SLASH, dateBroadcast,
                Resources.Constants.SLASH, countryApplicable);
               


        }

        /// <summary>
        /// Envio del camando armado al emulador
        /// </summary>
        private void SendCommand()
        {
            bool status = true;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }
            int row = 0;
            int col = 0;
            CommandsQik.searchResponse(sabreAnswer, Resources.ErrorMessages.SEGMENT_NUMBER_NOT_VALID, ref row, ref col);
            if(row > 0)
            {
                MessageBox.Show(Resources.Reservations.ERROR_NUM_SEGMENTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSegment1.Focus();
                status = false;

            }
            row = 0;
            col = 0;
            CommandsQik.searchResponse(sabreAnswer, Resources.ErrorMessages.INVALID_SSR_CODE, ref row, ref col);
            if (row > 0)
            {
                MessageBox.Show(Resources.Reservations.LINEA_AEREA_NO_REQ_INFORMACION, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                status = false;
            }
            if(status)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);


        }

        #endregion // Methods Class

       
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
        /// Regresa al user cotrol welcome cuando se presiona ESC o ejecuta
        /// la acción del botón aceptar cuando se presiona Enter
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

        #endregion // Back to a Previous Usercontrol or Validate Enter KeyDown
    }
}
