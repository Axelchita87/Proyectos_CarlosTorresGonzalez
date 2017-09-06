using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Entities;
using MyCTS.Forms.UI;
using MyCTS.Business;

namespace MyCTS.Presentation
{
    public partial class ucAirAccountingLine : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Armado del comando que se envia a sabre para las lineas
        ///              contables aéreas.
        /// Creación:    12/Abril/2010 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Angel Trejo
        /// </summary>
        public ucAirAccountingLine()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = rdoNormal;
            this.LastControlFocus = btnAccept;
        }
        #region ====== Global Variables ======

        private TextBox txt;
        private bool statusParamReceived;
        private bool statusDate;
        private bool allowDecimal = true;

        #endregion //Global Variables

        private void ucAirAccountingLine_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            if (!Convert.ToBoolean(ParameterBL.GetParameterValue("AllowDecimalNumbers").Values))
            {
                txtQuantity.CharsIncluded = null;
                txtBasisFare.Text = "0";
                txtBasisFare.CharsIncluded = null;
                txtOtherTaxes.Text = "0";
                txtOtherTaxes.CharsIncluded = null;
                txtIVA.Text = "0";
                txtIVA.CharsIncluded = null;
                txtTUA.Text = "0";
                txtTUA.CharsIncluded = null;
                allowDecimal = false;
            }
            HideListboxControls();
            foreach (Control txt in this.Controls)
            {
                if (txt is SmartTextBox && !txt.Enabled)
                    txt.BackColor = SystemColors.Control;
            }
            rdoNormal.Checked = true;
            rdoNormal.Focus();
        }
        
        
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidBussinesRules)
            {
                BuildCommand();
            }
        }

        #region ====== METHODS CLASS ======

        /// <summary>
        /// No permite el despliegue de predictivo cuando se
        /// carga la mascarilla
        /// </summary>
        private void HideListboxControls()
        {
            statusParamReceived = false;
        }

        /// <summary>
        /// Valida las reglas del negocio aplicables a este user control
        /// </summary>
        private bool IsValidBussinesRules
        {
            get
            {
                bool status = false;
                if (string.IsNullOrEmpty(txtAirLine.Text))
                {
                    MessageBox.Show("SE DEBE INGRESAR LA AEROLÍNEA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirLine.Focus();
                }
                else if (!string.IsNullOrEmpty(txtAirLine.Text) && txtAirLine.TextLength != 2)
                {
                    MessageBox.Show("EL CÓDIGO DE AEROLÍNEA DEBE SER DE 2 CARACTERES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirLine.Focus();
                }
                else if (string.IsNullOrEmpty(txtNumberTicket.Text))
                {
                    MessageBox.Show("SE DEBE INGRESAR EL NÚMERO DE BOLETO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberTicket.Focus();
                }
                else if (!string.IsNullOrEmpty(txtNumberTicket.Text) && txtNumberTicket.TextLength != 10)
                {
                    MessageBox.Show("EL NÚMERO DE BOLETO DEBE SER DE 10 DIGITOS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberTicket.Focus();
                }
                else if (string.IsNullOrEmpty(txtDigit.Text))
                {
                    MessageBox.Show("SE DEBE INGRESAR EL DIGITO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDigit.Focus();
                }
                else if (string.IsNullOrEmpty(txtCommision.Text) && string.IsNullOrEmpty(txtQuantity.Text))
                {
                    MessageBox.Show("SE DEBE INGRESAR EL PORCETAJE DE COMISIÓN O CANTIDAD", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCommision.Focus();
                }
                else if (!string.IsNullOrEmpty(txtCommision.Text) && !string.IsNullOrEmpty(txtQuantity.Text))
                {
                    MessageBox.Show("SE DEBE INGRESAR EL PORCETAJE DE COMISIÓN O CANTIDAD (SOLO UN DATO)", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCommision.Focus();
                }
                else if (allowDecimal && !string.IsNullOrEmpty(txtQuantity.Text) && !ValidateRegularExpression.ValidateTwoDecimalNumbers(txtQuantity.Text))
                {
                    MessageBox.Show("LA CANTIDAD DEBE TENER 2 DECIMALES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQuantity.Focus();
                }
                else if (string.IsNullOrEmpty(txtBasisFare.Text))
                {
                    MessageBox.Show("SE DEBE INGRESAR LA TARIFA BASE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBasisFare.Focus();
                }
                else if (allowDecimal && !string.IsNullOrEmpty(txtBasisFare.Text) && !ValidateRegularExpression.ValidateTwoDecimalNumbers(txtBasisFare.Text))
                {
                    MessageBox.Show("LA TARRIFA BASE DEBE TENER 2 DECIMALES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBasisFare.Focus();
                }
                else if (allowDecimal && !string.IsNullOrEmpty(txtOtherTaxes.Text) && !ValidateRegularExpression.ValidateTwoDecimalNumbers(txtOtherTaxes.Text))
                {
                    MessageBox.Show("OTROS IMPUESTOS DEBEN TENER 2 DECIMALES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtOtherTaxes.Focus();
                }
                else if (string.IsNullOrEmpty(txtIVA.Text))
                {
                    MessageBox.Show("SE DEBE INGRESAR EL IVA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIVA.Focus();
                }
                else if (allowDecimal && !string.IsNullOrEmpty(txtIVA.Text) && !ValidateRegularExpression.ValidateTwoDecimalNumbers(txtIVA.Text))
                {
                    MessageBox.Show("LA CANTIDAD DEL IVA DEBE TENER 2 DECIMALES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIVA.Focus();
                }
                else if (string.IsNullOrEmpty(txtTUA.Text))
                {
                    MessageBox.Show("SE DEBE INGRESAR EL TUA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTUA.Focus();
                }
                else if (allowDecimal && !string.IsNullOrEmpty(txtTUA.Text) && !ValidateRegularExpression.ValidateTwoDecimalNumbers(txtTUA.Text))
                {
                    MessageBox.Show("LA CANTIDAD DEL TUA DEBE TENER 2 DECIMALES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTUA.Focus();
                }
                else if (!rdoOne.Checked && !rdoALL.Checked && !rdoPER.Checked)
                {
                    MessageBox.Show("SE DEBE INDICAR LA SOLICITUD DE TARIFA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (string.IsNullOrEmpty(txtNumberDoctos.Text))
                {
                    MessageBox.Show("SE DEBE INGRESAR EL NÚMERO DE DOCUMENTOS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberDoctos.Focus();
                }
                else if (!rdoCA.Checked && !rdoCC.Checked && !rdoCX.Checked)
                {
                    MessageBox.Show("SE DEBE INDICAR LA FORMA DE PAGO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtCardCode.Enabled && string.IsNullOrEmpty(txtCardCode.Text))
                {
                    MessageBox.Show("SE DEBE INGRESAR EL CÓDIGO DE TARJETA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCardCode.Focus();
                }
                else if (!string.IsNullOrEmpty(txtCardCode.Text) && txtCardCode.TextLength != 2)
                {
                    MessageBox.Show("EL CÓDIGO DE TARJETA DEBE SER DE 2 CARACTERES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCardCode.Focus();
                }
                else if (txtNumberCard.Enabled && string.IsNullOrEmpty(txtNumberCard.Text))
                {
                    MessageBox.Show("SE DEBE INGRESAR EL NÚMERO DE TARJETA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberCard.Focus();
                }
                else if (!string.IsNullOrEmpty(txtNumberCard.Text) && (txtNumberCard.TextLength < 15))
                {
                    MessageBox.Show("EL NÚMERO DE TARJETA DEBE SER DE 15 Ó 16 DIGITOS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberCard.Focus();
                }
                else if (txtPaxNumber.Enabled && string.IsNullOrEmpty(txtPaxNumber.Text))
                {
                    MessageBox.Show("SE DEBE INGRESAR EL NÚMERO DE PASAJERO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPaxNumber.Focus();
                }
                else if (!string.IsNullOrEmpty(txtPaxNumber.Text) && !ValidateRegularExpression.ValidateOneorTwoPlusDecimalNumber(txtPaxNumber.Text))
                {
                    MessageBox.Show("EL NÚMERO DE PASAJERO DEBE TENER 1 DECIMAL", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPaxNumber.Focus();
                }
                else if (txtLastname.Enabled && string.IsNullOrEmpty(txtLastname.Text))
                {
                    MessageBox.Show("SE DEBE INGRESAR EL APELLIDO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLastname.Focus();
                }
                else if (txtInicialName.Enabled && string.IsNullOrEmpty(txtInicialName.Text))
                {
                    MessageBox.Show("SE DEBE INGRESAR LA INICIAL DEL NOMBRE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtInicialName.Focus();
                }
                else if (!rdoD.Checked && !rdoF.Checked && !rdoT.Checked)
                {
                    MessageBox.Show("SE DEBE INDICAR EL TIPO DE BOLETO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtDateTicketOriginal.Enabled && string.IsNullOrEmpty(txtDateTicketOriginal.Text))
                {
                    MessageBox.Show("SE DEBE INGRESAR LA FECHA DEL BOLETO ORIGINAL", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDateTicketOriginal.Focus();
                }
                else if (!string.IsNullOrEmpty(txtDateTicketOriginal.Text) && !ValidateRegularExpression.ValidateBirthDateFormat(txtDateTicketOriginal.Text))
                {
                    MessageBox.Show("EL FORAMTO DE LA FECHA DEBE SER DDMMMYY", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDateTicketOriginal.Focus();
                }
                else if (!string.IsNullOrEmpty(txtDateTicketOriginal.Text) && !ValidateDate(txtDateTicketOriginal.Text))
                {
                    MessageBox.Show("LA FECHA INGRESADA NO ES VALIDA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDateTicketOriginal.Focus();
                }
                else if (txtEmissionCity.Enabled && string.IsNullOrEmpty(txtEmissionCity.Text))
                {
                    MessageBox.Show("SE DEBE INGRESAR LA CIUDAD DE EMISIÓN", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmissionCity.Focus();
                }
                else if (!string.IsNullOrEmpty(txtEmissionCity.Text) && txtEmissionCity.TextLength != 3)
                {
                    MessageBox.Show("EL CÓDIGO DE CIUDAD DEBE SER DE 3 CARACTERES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmissionCity.Focus();
                }
                else if (txtNumberInvoice.Enabled && string.IsNullOrEmpty(txtNumberInvoice.Text))
                {
                    MessageBox.Show("SE DEBE INGRESAR EL NÚMERO DE FACTURA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberInvoice.Focus();
                }
                else if (txtNumberTicket2.Enabled && string.IsNullOrEmpty(txtNumberTicket2.Text))
                {
                    MessageBox.Show("SE DEBE INGRESAR EL NÚMERO DE AEROLÍNEA Y BOLETO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberTicket2.Focus();
                }
                else if (!string.IsNullOrEmpty(txtNumberTicket2.Text) && txtNumberTicket2.TextLength != 13)
                {
                    MessageBox.Show("EL NÚMERO DE AEROLÍNEA Y BOLETO DEBEN SUMAR 13 DIGITOS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberTicket2.Focus();
                }
                else if (txtCupons.Enabled && string.IsNullOrEmpty(txtCupons.Text))
                {
                    MessageBox.Show("SE DEBE INGRESAR LOS CUPONES A REVISAR", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCupons.Focus();
                }
                else if (rdoF2.Enabled && !rdoF2.Checked && !rdoP.Checked)
                {
                    MessageBox.Show("SE DEBE INDICAR EL TIPO DE REEMBOLSO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtCupons2.Enabled && string.IsNullOrEmpty(txtCupons2.Text))
                {
                    MessageBox.Show("SE DEBE INGRESAR LOS CUPONES A RECIBIDOS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCupons2.Focus();
                }
                else
                    status = true;
                return status;
            }
        }

        /// <summary>
        /// Verifica que la fecha ingresada sea valida
        /// </summary>
        /// <param name="dateToValidate">Fecha a validar</param>
        /// <returns>Status de la validación</returns>
        private bool ValidateDate(string dateToValidate)
        {
            try
            {
                DateTime aux = Convert.ToDateTime(dateToValidate);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Armado del comando que se envia a sabre
        /// </summary>
        private void BuildCommand()
        {
            string sabre = string.Empty;
            if (rdoNormal.Checked)
                sabre = "AC/";
            else if (rdoRevicedWithOutCharge.Checked)
                sabre = "ACE/";
            else if (rdoRevicedWithRembursement.Checked)
                sabre = "ACG/";
            else if (rdoRevisedWithCharge.Checked)
                sabre = "ACA/";
            else
                sabre = "ACR/";
            sabre = string.Concat(sabre, txtAirLine.Text, "/",
                txtNumberTicket.Text, txtDigit.Text, "/");
            if (!string.IsNullOrEmpty(txtCommision.Text))
                sabre = string.Concat(sabre, "P", txtCommision.Text);
            else
                sabre = string.Concat(sabre, txtQuantity.Text);
            if (string.IsNullOrEmpty(txtOtherTaxes.Text))
                txtOtherTaxes.Text = "0.00";
            sabre = string.Concat(sabre, "/", txtBasisFare.Text, "/",
                txtOtherTaxes.Text, "/D", txtIVA.Text, "/D", txtTUA.Text);
            if (rdoOne.Checked)
                sabre = string.Concat(sabre, "/ONE");
            else if (rdoALL.Checked)
                sabre = string.Concat(sabre, "/ALL");
            else
                sabre = string.Concat(sabre, "/PER");
            if (rdoCA.Checked)
                sabre = string.Concat(sabre, "/CA");
            else if (rdoCC.Checked)
                sabre = string.Concat(sabre, "/CC");
            else
                sabre = string.Concat(sabre, "/CX");
            if (rdoCC.Checked || rdoCX.Checked)
                sabre = string.Concat(sabre, txtCardCode.Text, txtNumberCard.Text);
            if (rdoOne.Checked)
                sabre = string.Concat(sabre, " ", txtPaxNumber.Text, txtLastname.Text, " ", txtInicialName.Text);
            sabre = string.Concat(sabre, "/", txtNumberDoctos.Text);
            if (rdoRevicedWithOutCharge.Checked || rdoRevisedWithCharge.Checked || rdoRevicedWithRembursement.Checked)
                sabre = string.Concat(sabre, "/E", txtNumberInvoice.Text);
            else if (rdoReimbursement.Checked)
            {
                sabre = string.Concat(sabre, "/", txtCupons2.Text);
                if (rdoF2.Checked)
                    sabre = string.Concat(sabre, "/F");
                else
                    sabre = string.Concat(sabre, "/P");
                sabre = string.Concat(sabre, txtNumberInvoice.Text);
            }
            if (rdoD.Checked)
                sabre = string.Concat(sabre, "/D");
            else if (rdoF.Checked)
                sabre = string.Concat(sabre, "/F");
            else
                sabre = string.Concat(sabre, "/T");
            if (rdoRevisedWithCharge.Checked || rdoRevicedWithOutCharge.Checked || rdoRevicedWithRembursement.Checked)
                sabre = string.Concat(sabre, "-@", txtNumberTicket2.Text, "/", txtCupons.Text,
                    "/", txtDateTicketOriginal.Text, txtEmissionCity.Text);
            if (!string.IsNullOrEmpty(txtComentarios.Text))
                sabre = string.Concat(sabre, "-", txtComentarios.Text);
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(sabre);
            }
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);

        }

        #endregion //METHODS CLASS

        #region ====== Predictives ======

        private void txtAirLine_TextChanged(object sender, EventArgs e)
        {
            if (!statusParamReceived)
            {
                txt = (TextBox)sender;
                Common.SetListBoxAirlines(txt, lbAirline);
            }
        }

        private void txtEmissionCity_TextChanged(object sender, EventArgs e)
        {
            if (!statusParamReceived)
            {
                txt = (TextBox)sender;
                Common.SetListBoxCities(txt, lbCityCode);
            }
        }

        private void txtCardCode_TextChanged(object sender, EventArgs e)
        {
            if (!statusParamReceived)
            {
                txt = (TextBox)sender;
                Common.SetListBoxCreditCards(txt, lbCardCode);
            }
        }

        private void lbAirline_KeyDown(object sender, KeyEventArgs e)
        {
            ListBox ListBox = (ListBox)sender;
            if (e.KeyCode == Keys.Enter)
            {
                ListItem li = (ListItem)ListBox.SelectedItem;
                txt.Text = li.Value;
                ListBox.Visible = false;
                txt.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                lbAirline.Visible = false;
                txt.Focus();
            }
        }

        private void lbCityCode_KeyDown(object sender, KeyEventArgs e)
        {
            ListBox ListBox = (ListBox)sender;
            if (e.KeyCode == Keys.Enter)
            {
                ListItem li = (ListItem)ListBox.SelectedItem;
                txt.Text = li.Value;
                ListBox.Visible = false;
                txt.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                lbCityCode.Visible = false;
                txt.Focus();
            }
        }

        private void lbCardCode_KeyDown(object sender, KeyEventArgs e)
        {
            ListBox ListBox = (ListBox)sender;
            if (e.KeyCode == Keys.Enter)
            {
                ListItem li = (ListItem)ListBox.SelectedItem;
                txt.Text = li.Value;
                ListBox.Visible = false;
                txt.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                lbCardCode.Visible = false;
                txt.Focus();
            }
        }

        private void txtAirLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            if (e.KeyData == Keys.Enter)
            {
                btnAccept_Click(sender, e);
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lbAirline.Items.Count > 0)
                {
                    lbAirline.SelectedIndex = 0;
                    lbAirline.Focus();
                    lbAirline.Visible = true;
                    lbAirline.Focus();
                }
            }
        }
        
        private void txtEmissionCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            if (e.KeyData == Keys.Enter)
            {
                btnAccept_Click(sender, e);
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lbCityCode.Items.Count > 0)
                {
                    lbCityCode.SelectedIndex = 0;
                    lbCityCode.Focus();
                    lbCityCode.Visible = true;
                    lbCityCode.Focus();
                }
            }
        }

        private void txtCardCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            if (e.KeyData == Keys.Enter)
            {
                btnAccept_Click(sender, e);
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lbCardCode.Items.Count > 0)
                {
                    lbCardCode.SelectedIndex = 0;
                    lbCardCode.Focus();
                    lbCardCode.Visible = true;
                    lbCardCode.Focus();
                }
            }
        }

        /// <summary>
        /// Selecciona algún elemento dentro de algún listbox al hacer un click
        /// sobre el
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_MouseClick(object sender, MouseEventArgs e)
        {
            ListBox listBox = (ListBox)sender;

            ListItem li = (ListItem)listBox.SelectedItem;
            txt.Text = li.Value;
            listBox.Visible = false;
            txt.Focus();
        }

        

        #endregion //Predictives

        #region ====== Calendar ======

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            calendarStateFront();
        }
       
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            statusDate = false;
            DateTime dateSelected = monthCalendar1.SelectionStart;
            if (DateTime.Compare(dateSelected, DateTime.Today) > 0)
                statusDate = true;
            else
                statusDate = false;
            string date = dateSelected.ToString("ddMMMyy", new System.Globalization.CultureInfo("en-US")).ToUpper();
            txtDateTicketOriginal.Text = date;
            if (this.Contains(monthCalendar1))
            {
                monthCalendar1.SendToBack();

            }
            monthCalendar1.Visible = false;

        }
        private void monthCalendar1_KeyDown(object sender, KeyEventArgs e)
        {
            if (monthCalendar1.Focus())
            {
                if (e.KeyData == Keys.Escape)
                {
                    if (this.Contains(monthCalendar1))
                    {
                        monthCalendar1.SendToBack();

                    }
                    monthCalendar1.Visible = false;

                }
            }
        }
        private void monthCalendar1_Leave(object sender, EventArgs e)
        {
            if (this.Contains(monthCalendar1))
            {
                monthCalendar1.SendToBack();

            }
            monthCalendar1.SendToBack();
        }
        /// <summary>
        /// Llevar el calendario hacia el frente
        /// y que se muestre
        /// </summary>
        public void calendarStateFront()
        {

            monthCalendar1.Visible = true;
            if (this.Contains(monthCalendar1))
            {
                monthCalendar1.BringToFront();
            }
            monthCalendar1.Focus();

        }

        #endregion //Calendar

        #region ====== RADiOBUTTON'S CHANGES ======

        private void rdoRevisedWithCharge_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoRevisedWithCharge.Checked || rdoRevicedWithOutCharge.Checked ||
                rdoRevicedWithRembursement.Checked)
            {
                foreach (Control txt in this.Controls)
                {
                    if (txt is SmartTextBox && (txt.TabIndex >= 31 && txt.TabIndex <= 38))
                    {
                        txt.Enabled = true;
                        txt.BackColor = Color.White;
                        txt.Text = string.Empty;
                    }
                }
                pictureBox1.Enabled = true;
                rdoF2.Enabled = false;
                rdoP.Enabled = false;
                rdoF2.Checked = false;
                rdoP.Checked = false;
                txtCupons2.Text = string.Empty;
                txtCupons2.BackColor = SystemColors.Control;
                txtCupons2.Enabled = false;
            }
            else if (rdoNormal.Checked)
            {
                foreach (Control txt in this.Controls)
                {
                    if (txt is SmartTextBox && (txt.TabIndex >= 31 && txt.TabIndex <= 38))
                    {
                        txt.Enabled = false;
                        txt.BackColor = SystemColors.Control;
                        txt.Text = string.Empty;

                    }
                }
                pictureBox1.Enabled = false;
                rdoF2.Enabled = false;
                rdoP.Enabled = false;
                rdoF2.Checked = false;
                rdoP.Checked = false;
            }
            else if (rdoReimbursement.Checked)
            {
                foreach (Control txt in this.Controls)
                {
                    if (txt is SmartTextBox && (txt.TabIndex >= 31 && txt.TabIndex <= 38) && txt.TabIndex!=33)
                    {
                        txt.Enabled = false;
                        txt.BackColor = SystemColors.Control;
                        txt.Text = string.Empty;
                    }
                }
                txtCupons2.Enabled = true;
                txtCupons2.Text = string.Empty;
                txtCupons2.BackColor = Color.White;
                txtNumberInvoice.Enabled = true;
                txtNumberInvoice.Text = string.Empty;
                txtNumberInvoice.BackColor = Color.White;
                pictureBox1.Enabled = false;
                rdoF2.Enabled = true;
                rdoP.Enabled = true;
                rdoF2.Checked = false;
                rdoP.Checked = false;

            }
        }

        private void rdoOne_CheckedChanged(object sender, EventArgs e)
        {
            if ((rdoALL.Checked || rdoPER.Checked || rdoOne.Checked) && rdoCA.Checked)
            {
                foreach (Control txt in this.Controls)
                {
                    if (txt is SmartTextBox && txt.TabIndex >= 22 && txt.TabIndex <= 26)
                    {
                        txt.Text = string.Empty;
                        txt.Enabled = false;
                        txt.BackColor = SystemColors.Control;
                    }
                    if (txt is SmartTextBox && txt.TabIndex >= 24 && txt.TabIndex <= 26)
                    {
                        txt.Text = string.Empty;
                        txt.Enabled = true;
                        txt.BackColor = Color.White;
                    }
                }
            }
            if (rdoOne.Checked && (rdoCC.Checked || rdoCX.Checked))
            {
                foreach (Control txt in this.Controls)
                {
                    if (txt is SmartTextBox && txt.TabIndex >= 22 && txt.TabIndex <= 26)
                    {
                        txt.Text = string.Empty;
                        txt.Enabled = false;
                        txt.BackColor = SystemColors.Control;
                    }
                    if (txt is SmartTextBox && txt.TabIndex >= 22 && txt.TabIndex <= 26)
                    {
                        txt.Text = string.Empty;
                        txt.Enabled = true;
                        txt.BackColor = Color.White;
                    }
                }
            }
            if ((rdoALL.Checked || rdoPER.Checked) && (rdoCC.Checked || rdoCX.Checked))
            {
                foreach (Control txt in this.Controls)
                {
                    if (txt is SmartTextBox && txt.TabIndex >= 22 && txt.TabIndex <= 26)
                    {
                        txt.Text = string.Empty;
                        txt.Enabled = false;
                        txt.BackColor = SystemColors.Control;
                    }
                    if (txt is SmartTextBox && txt.TabIndex >= 22 && txt.TabIndex <= 23)
                    {
                        txt.Text = string.Empty;
                        txt.Enabled = true;
                        txt.BackColor = Color.White;
                    }
                }
            }
        }

        #endregion //RADiOBUTTON'S CHANGES

        #region ======Back to a Previous Usercontrol or Validate Enter KeyDown=====

        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            if (e.KeyData == Keys.Enter)
            {
                btnAccept_Click(sender, e);
            }
        }

        #endregion //Back to a Previous Usercontrol or Validate Enter KeyDown

        #region=====Change focus When a Textbox is Full=====

        private void txtNumberTicket_TextChanged(object sender, EventArgs e)
        {
            if (sender is SmartTextBox)
                if (((SmartTextBox)sender).Text.Length > ((SmartTextBox)sender).MaxLength - 1)
                    foreach (Control txt in this.Controls)
                        if (!(txt is Label) && txt.TabIndex.Equals(((SmartTextBox)(sender)).TabIndex + 1))
                        {
                            txt.Focus();
                            break;
                        }
        }

        #endregion //Change focus When a Textbox is Full

    }
}
