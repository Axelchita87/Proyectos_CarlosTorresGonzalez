using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucRevisedCharge : CustomUserControl
    {
        TextBox txt;
        public static string revised;
        bool statusValidAirline;
        

        public ucRevisedCharge()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            InitialControlFocus = txtBaseAmount;
            LastControlFocus = btnAccept;
        }

        //Establece el estado de los controles 
        private void ucRevisedCharge_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            if (!Convert.ToBoolean(ParameterBL.GetParameterValue("AllowDecimalNumbers").Values))
            {
                txtBaseAmount.CharsIncluded = null;
                txtTax1.CharsIncluded = null;
                txtTax2.CharsIncluded = null;
                txtTax3.CharsIncluded = null;
            }

            Previousvalues();
            lbGeneric.BringToFront();
            if (ucTicketsEmissionInstructions.WithCharge)
            {
                EnableDisableControls(true);
                txtBaseAmount.BackColor = Color.White;
                txtTax1.BackColor = Color.White;
                txtTax2.BackColor = Color.White;
                txtTax3.BackColor = Color.White;
                txtCode1.BackColor = Color.White;
                txtCode2.BackColor = Color.White;
                txtCode3.BackColor = Color.White;

                txtBaseAmount.Focus();
            }
            else if (ucTicketsEmissionInstructions.WithoutCharge)
            {
                EnableDisableControls(false);
                txtBaseAmount.BackColor = SystemColors.Control;
                txtTax1.BackColor = SystemColors.Control;
                txtTax2.BackColor = SystemColors.Control;
                txtTax3.BackColor = SystemColors.Control;
                txtCode1.BackColor = SystemColors.Control;
                txtCode2.BackColor = SystemColors.Control;
                txtCode3.BackColor = SystemColors.Control;

                txtAirlineTicket.Focus();
            }
            txtAirlineTicke2.BackColor = SystemColors.Control;
        }

        //Valida la aerolinea, llama los metodos de validación y envió de comando
        private void btnAccept_Click(object sender, EventArgs e)
        {
            List<ListItem> airLinesList = CatPAirlinesFareBL.GetAirLinesFare(txtAirline.Text);
            if (airLinesList.Count.Equals(0))
                statusValidAirline = true;
            else
                statusValidAirline = false;

            if (IsValidateBusinessRules)
            {
                LoadParametersValues();
                CommandSend();
                if (!ucTicketsEmissionInstructions.wayPayment.Equals("rdoMixPayment"))// || ucTicketsEmissionInstructions.cash || ucTicketsEmissionInstructions.WithoutCharge)
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCPHASE_35375_TICKETS);
                else
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCFORMPAYMENT);
            }
        }

        //KeyDown
        /// <summary>
        /// Este se usa para todos los controles en general si se oprime 
        /// Esc se manda a el User control de Welcome 
        /// Enter se manda la accion de botón de Aceptar
        /// KeyDown se manda el foco al listBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                LoadParametersValues();
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTICKETSEMISSIONINSTRUCTIONS);
            }

            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);

            if (e.KeyCode == Keys.Down)
            {
                if (lbGeneric.Items.Count > 0)
                {
                    lbGeneric.SelectedIndex = 0;
                    lbGeneric.Visible = true;
                    lbGeneric.Focus();
                }
            }
        }

        //Checked checkbox
        private void chkSecondRevised_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSecondRevised.Checked)
            {
                txtAirlineTicke2.Enabled = true;
                txtAirlineTicke2.BackColor = Color.White;
            }
            else
            {
                txtAirlineTicke2.Enabled = false;
                txtAirlineTicke2.BackColor = SystemColors.Control;
            }
        }

        #region ======== methodsClass ========

        /// <summary>
        /// Se validan que existan los datos que son obligatorios y que 
        /// sean los datos correctos
        /// </summary>
        private bool IsValidateBusinessRules
        {
            get
            {
                bool isValid = false;
                if (ucTicketsEmissionInstructions.WithCharge)
                {

                    bool decimalNumber = Convert.ToBoolean(ParameterBL.GetParameterValue("AllowDecimalNumbers").Values);
                    if (string.IsNullOrEmpty(txtBaseAmount.Text))
                    {
                        MessageBox.Show("REQUIERE INGRESAR MONTO BASE CARGO ADICIONAL", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtBaseAmount.Focus();
                        return isValid;
                    }

                    else if (!string.IsNullOrEmpty(txtTax1.Text) &&
                      string.IsNullOrEmpty(txtCode1.Text))
                    {
                        MessageBox.Show("REQUIERE INGRESAR EL CÓDIGO DEL IMPUESTO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCode1.Focus();
                        return isValid;
                    }
                    else if (!string.IsNullOrEmpty(txtCode1.Text) &&
                              string.IsNullOrEmpty(txtTax1.Text))
                    {
                        MessageBox.Show("REQUIERE INGRESAR EL IMPUESTO DEL CÓDIGO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTax1.Focus();
                        return isValid;
                    }
                    else if (!string.IsNullOrEmpty(txtTax2.Text) &&
                              string.IsNullOrEmpty(txtCode2.Text))
                    {
                        MessageBox.Show("REQUIERE INGRESAR EL CÓDIGO DEL IMPUESTO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCode2.Focus();
                        return isValid;
                    }
                    else if (!string.IsNullOrEmpty(txtCode2.Text) &&
                              string.IsNullOrEmpty(txtTax2.Text))
                    {
                        MessageBox.Show("REQUIERE INGRESAR EL IMPUESTO DEL CÓDIGO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTax2.Focus();
                        return isValid;
                    }
                    else if (!string.IsNullOrEmpty(txtTax3.Text) &&
                              string.IsNullOrEmpty(txtCode3.Text))
                    {
                        MessageBox.Show("REQUIERE INGRESAR EL CÓDIGO DEL IMPUESTO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCode3.Focus();
                        return isValid;
                    }
                    else if (!string.IsNullOrEmpty(txtCode3.Text) &&
                          string.IsNullOrEmpty(txtTax3.Text))
                    {
                        MessageBox.Show("REQUIERE INGRESAR EL IMPUESTO DEL CÓDIGO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTax3.Focus();
                        return isValid;
                    }
                    else if (!string.IsNullOrEmpty(txtBaseAmount.Text) &&
                        !ValidateRegularExpression.ValidateTwoDecimals(txtBaseAmount.Text)&&
                        decimalNumber)
                    {
                        MessageBox.Show("REQUIERE INGRESAR DOS DECIMALES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtBaseAmount.Focus();
                        return isValid;
                    }
                    else if (!string.IsNullOrEmpty(txtTax1.Text) &&
                        !ValidateRegularExpression.ValidateTwoDecimals(txtTax1.Text)&&
                        decimalNumber)
                    {
                        MessageBox.Show("REQUIERE INGRESAR DOS DECIMALES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTax1.Focus();
                        return isValid;
                    }
                    else if (!string.IsNullOrEmpty(txtTax2.Text) &&
                        !ValidateRegularExpression.ValidateTwoDecimals(txtTax2.Text)&&
                        decimalNumber)
                    {
                        MessageBox.Show("REQUIERE INGRESAR SOLO DOS DECIMALES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTax2.Focus();
                        return isValid;
                    }
                    else if (!string.IsNullOrEmpty(txtTax3.Text) &&
                        !ValidateRegularExpression.ValidateTwoDecimals(txtTax3.Text)&&
                        decimalNumber)
                    {
                        MessageBox.Show("REQUIERE INGRESAR SOLO DOS DECIMALES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTax3.Focus();
                        return isValid;
                    }
                    else if (((txtCode1.Text == txtCode2.Text) && (!string.IsNullOrEmpty(txtCode1.Text) && !string.IsNullOrEmpty(txtCode2.Text))) || 
                        ((txtCode1.Text == txtCode3.Text) && (!string.IsNullOrEmpty(txtCode1.Text) && !string.IsNullOrEmpty(txtCode3.Text))) ||
                        ((txtCode2.Text == txtCode3.Text) && (!string.IsNullOrEmpty(txtCode2.Text) && !string.IsNullOrEmpty(txtCode3.Text))))
                    {
                        MessageBox.Show("NO ES PERMITIDO REPETIR EL MISMO CÓDIGO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCode1.Focus();
                        return isValid;
                    }
                    else if ((txtCode1.Text == "XO" || txtCode1.Text == "MX") &&
                        ((txtCode2.Text == "XO" || txtCode2.Text == "MX") ||
                        (txtCode3.Text == "XO" || txtCode3.Text == "MX")))
                    {
                        MessageBox.Show("NO ES PERMITIDO EL CÓDIGO DE XO CON MX", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCode1.Focus();
                        return isValid;
                    }
                    else if ((txtCode2.Text == "XO" || txtCode2.Text == "MX") &&
                        (txtCode3.Text == "XO" || txtCode3.Text == "MX"))
                    {
                        MessageBox.Show("NO ES PERMITIDO EL CÓDIGO DE XO CON MX", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCode2.Focus();
                        return isValid;
                    }

                }
                if (string.IsNullOrEmpty(txtAirlineTicket.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR NÚMERO DE BOLETO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirlineTicket.Focus();
                }
                else if (!string.IsNullOrEmpty(txtAirlineTicket.Text) &&
                    txtAirlineTicket.Text.Length != 13)
                {
                    MessageBox.Show("REQUIERE INGRESAR NÚMERO DE BOLETO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirlineTicket.Focus();
                }
                else if (string.IsNullOrEmpty(txtStampstoReview.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR LOS CUPONES A REVISAR", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtStampstoReview.Focus();
                }
                else if (string.IsNullOrEmpty(txtEmissionDate.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR LA FECHA DE EMISIÓN", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmissionDate.Focus();
                }
                else if (!string.IsNullOrEmpty(txtEmissionDate.Text) &&
                        !ValidateRegularExpression.ValidateDateFormatYear(txtEmissionDate.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR LA FECHA CORRECTA DE EMISIÓN", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmissionDate.Focus();
                }
                else if (string.IsNullOrEmpty(txtEmisionCity.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR LA CIUDAD DE EMISIÓN", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmisionCity.Focus();
                }
                else if (!string.IsNullOrEmpty(txtEmisionCity.Text) &&
                    txtEmisionCity.Text.Length != 3)
                {
                    MessageBox.Show("REQUIERE INGRESAR LA CIUDAD DE EMISIÓN", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmisionCity.Focus();
                }
                else if (string.IsNullOrEmpty(txtIATA.Text) &&
                        string.IsNullOrEmpty(txtAirline.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR LA IATA O EL CÓDIGO DE AEROLINEA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmisionCity.Focus();
                }
                else if (!rdoCash.Checked && !rdoCreditCard.Checked)
                {
                    MessageBox.Show("REQUIERE INGRESAR FORMA DE PAGO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rdoCash.Focus();
                }
                else if (chkSecondRevised.Checked && string.IsNullOrEmpty(txtAirlineTicke2.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR NÚMERO DE BOLETO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirlineTicke2.Focus();
                }
                else if (!string.IsNullOrEmpty(txtAirlineTicke2.Text) &&
                txtAirlineTicke2.Text.Length != 13)
                {
                    MessageBox.Show("REQUIERE INGRESAR 13 DÍGITOS PARA EL NÚMERO DE BOLETO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirlineTicke2.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtIATA.Text)) &&
                    (txtIATA.Text.Length != 8))
                {
                    MessageBox.Show("REQUIERE INGRESAR 8 DÍGITOS PARA LA IATA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIATA.Focus();
                }
                else if (!string.IsNullOrEmpty(txtAirline.Text) &&
                    (txtAirline.Text.Length != 2 || statusValidAirline))
                {
                    MessageBox.Show("REQUIERE INGRESAR CÓDIGO DE AEROLINEA VÁLIDO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirline.Focus();
                }
                else if (!string.IsNullOrEmpty(txtSegment1.Text) &&
                        string.IsNullOrEmpty(txtDate1.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR FECHA DE VALIDEZ", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDate1.Focus();
                }
                else if (!string.IsNullOrEmpty(txtSegment2.Text) &&
                        string.IsNullOrEmpty(txtSegment1.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR EL SEGMENTO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSegment1.Focus();
                }
                else if (!string.IsNullOrEmpty(txtSegment3.Text) &&
                        string.IsNullOrEmpty(txtDate3.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR FECHA DE VALIDEZ", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDate3.Focus();
                }
                else if (!string.IsNullOrEmpty(txtSegment4.Text) &&
                    string.IsNullOrEmpty(txtSegment3.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR EL SEGMENTO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSegment3.Focus();
                }
                else if (!string.IsNullOrEmpty(txtSegment5.Text) &&
                        string.IsNullOrEmpty(txtDate5.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR FECHA DE VALIDEZ", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDate5.Focus();
                }
                else if (!string.IsNullOrEmpty(txtSegment6.Text) &&
                string.IsNullOrEmpty(txtSegment5.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR EL SEGMENTO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSegment5.Focus();
                }
                else if (!string.IsNullOrEmpty(txtSegment7.Text) &&
                        string.IsNullOrEmpty(txtDate7.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR FECHA DE VALIDEZ", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDate7.Focus();
                }
                else if (!string.IsNullOrEmpty(txtSegment8.Text) &&
                          string.IsNullOrEmpty(txtSegment7.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR EL SEGMENTO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSegment7.Focus();
                }
                else if (!string.IsNullOrEmpty(txtDate1.Text) &&
                    !ValidateRegularExpression.ValidateDateFormat(txtDate1.Text))
                {
                    MessageBox.Show("LA FECHA INGRESADA NO ES CORRECTA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDate1.Focus();
                }
                else if (!string.IsNullOrEmpty(txtDate2.Text) &&
                    !ValidateRegularExpression.ValidateDateFormat(txtDate2.Text))
                {
                    MessageBox.Show("LA FECHA INGRESADA NO ES CORRECTA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDate2.Focus();
                }
                else if (!string.IsNullOrEmpty(txtDate3.Text) &&
                    !ValidateRegularExpression.ValidateDateFormat(txtDate3.Text))
                {
                    MessageBox.Show("LA FECHA INGRESADA NO ES CORRECTA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDate3.Focus();
                }
                else if (!string.IsNullOrEmpty(txtDate4.Text) &&
                    !ValidateRegularExpression.ValidateDateFormat(txtDate4.Text))
                {
                    MessageBox.Show("LA FECHA INGRESADA NO ES CORRECTA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDate4.Focus();
                }
                else if (!string.IsNullOrEmpty(txtDate5.Text) &&
                    !ValidateRegularExpression.ValidateDateFormat(txtDate5.Text))
                {
                    MessageBox.Show("LA FECHA INGRESADA NO ES CORRECTA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDate5.Focus();
                }
                else if (!string.IsNullOrEmpty(txtDate6.Text) &&
                    !ValidateRegularExpression.ValidateDateFormat(txtDate6.Text))
                {
                    MessageBox.Show("LA FECHA INGRESADA NO ES CORRECTA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDate6.Focus();
                }
                else if (!string.IsNullOrEmpty(txtDate7.Text) &&
                    !ValidateRegularExpression.ValidateDateFormat(txtDate7.Text))
                {
                    MessageBox.Show("LA FECHA INGRESADA NO ES CORRECTA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDate7.Focus();
                }
                else if (!string.IsNullOrEmpty(txtDate8.Text) &&
                    !ValidateRegularExpression.ValidateDateFormat(txtDate8.Text))
                {
                    MessageBox.Show("LA FECHA INGRESADA NO ES CORRECTA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDate8.Focus();
                }
                else
                    isValid = true;


                return isValid;
            }
        }

        //Aramado de comando a enviar
        private void CommandSend()
        {
            revised = string.Empty;

            string sabre = string.Empty;
            if (ucTicketsEmissionInstructions.WithCharge)
            {
                sabre = string.Concat(sabre, "/", txtBaseAmount.Text);
                if (!string.IsNullOrEmpty(txtTax1.Text))
                    sabre = string.Concat(sabre, "/", txtTax1.Text, txtCode1.Text);
                if (!string.IsNullOrEmpty(txtTax2.Text))
                    sabre = string.Concat(sabre, "/", txtTax2.Text, txtCode2.Text);
                if (!string.IsNullOrEmpty(txtTax3.Text))
                    sabre = string.Concat(sabre, "/", txtTax3.Text, txtCode3.Text);
                if (rdoCash.Checked)
                    sabre = string.Concat(sabre, "*EFCASH");
                if (rdoCreditCard.Checked)
                    sabre = string.Concat(sabre, "*EFCC");
                sabre = string.Concat(sabre, "‡ET", txtAirlineTicket.Text, "/", txtStampstoReview.Text);

                if (!chkSecondRevised.Checked)
                {
                    sabre = string.Concat(sabre, "//", txtEmissionDate.Text, txtEmisionCity.Text, "/");
                    if (!string.IsNullOrEmpty(txtAirline.Text))
                        sabre = string.Concat(sabre, txtAirline.Text);
                    else
                        sabre = string.Concat(sabre, txtIATA.Text);
                }
                else
                {
                    sabre = string.Concat(sabre, "/", txtAirlineTicke2.Text, "/",
                        txtEmissionDate.Text, txtEmisionCity.Text, "/");
                    if (!string.IsNullOrEmpty(txtAirline.Text))
                        sabre = string.Concat(sabre, txtAirline.Text);
                    else
                        sabre = string.Concat(sabre, txtIATA.Text);
                }
            }
            else if (ucTicketsEmissionInstructions.WithoutCharge)
            {
                sabre = string.Concat(sabre, "‡ET", txtAirlineTicket.Text, "/", txtStampstoReview.Text);
                if (!chkSecondRevised.Checked)
                {
                    sabre = string.Concat(sabre, "//", txtEmissionDate.Text, txtEmisionCity.Text, "/");
                    if (!string.IsNullOrEmpty(txtAirline.Text))
                        sabre = string.Concat(sabre, txtAirline.Text, "‡FEF");
                    else
                        sabre = string.Concat(sabre, txtIATA.Text, "‡FEF");
                }
                else
                {
                    sabre = string.Concat(sabre, "/", txtAirlineTicke2.Text, "/", txtEmissionDate.Text, txtEmisionCity.Text, "/");
                    if (!string.IsNullOrEmpty(txtAirline.Text))
                        sabre = string.Concat(sabre, txtAirline.Text, "‡FEF");
                    else
                        sabre = string.Concat(sabre, txtIATA.Text, "‡FEF");
                }

                if (rdoCash.Checked)
                    sabre = string.Concat(sabre, "CA");
                if (rdoCreditCard.Checked)
                    sabre = string.Concat(sabre, "CC");
            }

            if (!string.IsNullOrEmpty(txtSegment1.Text))
                sabre = string.Concat(sabre, "‡V", txtSegment1.Text);
            if (!string.IsNullOrEmpty(txtSegment2.Text))
                sabre = string.Concat(sabre, "-", txtSegment2.Text);
            if (!string.IsNullOrEmpty(txtDate1.Text) ||
                !string.IsNullOrEmpty(txtDate2.Text))
                sabre = string.Concat(sabre, "*", txtDate1.Text, txtDate2.Text);

            if (!string.IsNullOrEmpty(txtSegment3.Text))
                sabre = string.Concat(sabre, "‡V", txtSegment3.Text);
            if (!string.IsNullOrEmpty(txtSegment4.Text))
                sabre = string.Concat(sabre, "-", txtSegment4.Text);
            if (!string.IsNullOrEmpty(txtDate3.Text) ||
                !string.IsNullOrEmpty(txtDate4.Text))
                sabre = string.Concat(sabre, "*", txtDate3.Text, txtDate4.Text);

            if (!string.IsNullOrEmpty(txtSegment5.Text))
                sabre = string.Concat(sabre, "‡V", txtSegment5.Text);
            if (!string.IsNullOrEmpty(txtSegment6.Text))
                sabre = string.Concat(sabre, "-", txtSegment6.Text);
            if (!string.IsNullOrEmpty(txtDate5.Text) ||
                !string.IsNullOrEmpty(txtDate6.Text))
                sabre = string.Concat(sabre, "*", txtDate5.Text, txtDate6.Text);

            if (!string.IsNullOrEmpty(txtSegment7.Text))
                sabre = string.Concat(sabre, "‡V", txtSegment7.Text);
            if (!string.IsNullOrEmpty(txtSegment8.Text))
                sabre = string.Concat(sabre, "-", txtSegment8.Text);
            if (!string.IsNullOrEmpty(txtDate8.Text) ||
                !string.IsNullOrEmpty(txtDate7.Text))
                sabre = string.Concat(sabre, "*", txtDate7.Text, txtDate8.Text);

            revised = sabre;

        }

        private void EnableDisableControls(bool show)
        {
            txtBaseAmount.Enabled = show;
            txtTax1.Enabled = show;
            txtTax2.Enabled = show;
            txtTax3.Enabled = show;
            txtCode1.Enabled = show;
            txtCode2.Enabled = show;
            txtCode3.Enabled = show;
        }

        /// <summary>
        /// Se carga el User Control con los valores anteriormente 
        /// ingresados
        /// </summary>
        private void Previousvalues()
        {
            if (userControlsPreviousValues.Revisedcharge != null)
            {
                txtBaseAmount.Text = userControlsPreviousValues.Revisedcharge[0];
                txtTax1.Text = userControlsPreviousValues.Revisedcharge[1];
                txtTax2.Text = userControlsPreviousValues.Revisedcharge[2];
                txtTax3.Text = userControlsPreviousValues.Revisedcharge[31];
                txtCode1.Text = userControlsPreviousValues.Revisedcharge[3];
                txtCode2.Text = userControlsPreviousValues.Revisedcharge[4];
                txtCode3.Text = userControlsPreviousValues.Revisedcharge[32];
                txtAirlineTicket.Text = userControlsPreviousValues.Revisedcharge[5];
                txtStampstoReview.Text = userControlsPreviousValues.Revisedcharge[6];
                txtEmissionDate.Text = userControlsPreviousValues.Revisedcharge[7];
                txtEmisionCity.Text = userControlsPreviousValues.Revisedcharge[8];
                txtIATA.Text = userControlsPreviousValues.Revisedcharge[9];
                txtAirline.Text = userControlsPreviousValues.Revisedcharge[10];
                //txtCurrencyCode.Text = userControlsPreviousValues.Revisedcharge[11];
                chkSecondRevised.Checked = (userControlsPreviousValues.Revisedcharge[11].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
                rdoCash.Checked = (userControlsPreviousValues.Revisedcharge[12].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
                rdoCreditCard.Checked = (userControlsPreviousValues.Revisedcharge[13].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
                txtAirlineTicke2.Text = userControlsPreviousValues.Revisedcharge[14];
                txtSegment1.Text = userControlsPreviousValues.Revisedcharge[15];
                txtSegment2.Text = userControlsPreviousValues.Revisedcharge[16];
                txtSegment3.Text = userControlsPreviousValues.Revisedcharge[17];
                txtSegment4.Text = userControlsPreviousValues.Revisedcharge[18];
                txtSegment5.Text = userControlsPreviousValues.Revisedcharge[19];
                txtSegment6.Text = userControlsPreviousValues.Revisedcharge[20];
                txtSegment7.Text = userControlsPreviousValues.Revisedcharge[21];
                txtSegment8.Text = userControlsPreviousValues.Revisedcharge[22];
                txtDate1.Text = userControlsPreviousValues.Revisedcharge[23];
                txtDate2.Text = userControlsPreviousValues.Revisedcharge[24];
                txtDate3.Text = userControlsPreviousValues.Revisedcharge[25];
                txtDate4.Text = userControlsPreviousValues.Revisedcharge[26];
                txtDate5.Text = userControlsPreviousValues.Revisedcharge[27];
                txtDate6.Text = userControlsPreviousValues.Revisedcharge[28];
                txtDate7.Text = userControlsPreviousValues.Revisedcharge[29];
                txtDate8.Text = userControlsPreviousValues.Revisedcharge[30];
                userControlsPreviousValues.Revisedcharge = null;
            }
        }

        /// <summary>
        /// Se guardan los valores ingresados en los TextBox
        /// </summary>
        private void LoadParametersValues()
        {
            string[] sendInfo = new [] {txtBaseAmount.Text,txtTax1.Text,txtTax2.Text,
                txtCode1.Text,txtCode2.Text,txtAirlineTicket.Text,txtStampstoReview.Text,
                txtEmissionDate.Text,txtEmisionCity.Text,txtIATA.Text,txtAirline.Text,
            chkSecondRevised.Checked.ToString(), rdoCash.Checked.ToString(),
            rdoCreditCard.Checked.ToString(),txtAirlineTicke2.Text,txtSegment1.Text,txtSegment2.Text,
            txtSegment3.Text,txtSegment4.Text,txtSegment5.Text,txtSegment6.Text,txtSegment7.Text,
            txtSegment8.Text,txtDate1.Text,txtDate2.Text,txtDate3.Text,txtDate4.Text,txtDate5.Text,
            txtDate6.Text,txtDate7.Text,txtDate8.Text,txtTax3.Text,txtCode3.Text};
            userControlsPreviousValues.Revisedcharge = sendInfo;
        }

        #endregion


        #region======= listbox Controls Events=====

        /// <summary>
        /// Asignación de acciones al presionar la tecla ENTER o ESC 
        /// cuando el lbCities tiene el foco
        /// </summary>
        /// <param name="sender">lbCities</param>
        /// <param name="e"></param>
        private void lbGeneric_KeyDown(object sender, KeyEventArgs e)
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
                lbGeneric.Visible = false;
                txt.Focus();
            }
        }

        /// <summary>
        /// Selecciona algún elemento dentro de algún listbox al hacer un click
        /// sobre el
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbGeneric_MouseClick(object sender, MouseEventArgs e)
        {
            ListBox listBox = (ListBox)sender;

            ListItem li = (ListItem)listBox.SelectedItem;
            txt.Text = li.Value;
            lbGeneric.Visible = false;
            txt.Focus();
        }

        //Predictivo de Aerolineas
        private void txtAirline_TextChanged(object sender, EventArgs e)
        {
            txt = (TextBox)sender;
            Common.SetListBoxAirlines(txt, lbGeneric);
        }

        //Predictivo de Moneda
        private void txtCurrencyCode_TextChanged(object sender, EventArgs e)
        {
            txt = (TextBox)sender;
            Common.SetListBoxCurrenciesCountries(txt, lbGeneric);
        }

        #endregion

        #region======== Change Focus ============

        private void txtBaseAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtBaseAmount.Text.Length > 7)
                txtTax1.Focus();
        }

        private void txtTax1_TextChanged(object sender, EventArgs e)
        {
            if (txtTax1.Text.Length > 6)
                txtCode1.Focus();
        }

        private void txtCode1_TextChanged(object sender, EventArgs e)
        {
            if (txtCode1.Text.Length > 1)
                txtTax2.Focus();
        }

        private void txtTax2_TextChanged(object sender, EventArgs e)
        {
            if (txtTax2.Text.Length > 6)
                txtCode2.Focus();
        }

        private void txtCode2_TextChanged(object sender, EventArgs e)
        {
            if (txtCode2.Text.Length > 1)
                txtTax3.Focus();
        }
        private void txtTax3_TextChanged(object sender, EventArgs e)
        {
            if (txtTax3.Text.Length > 6)
                txtCode3.Focus();
        }

        private void txtCode3_TextChanged(object sender, EventArgs e)
        {
            if (txtCode3.Text.Length > 1)
                txtAirlineTicket.Focus();
        }

        private void txtAirlineTicket_TextChanged(object sender, EventArgs e)
        {
            if (txtAirlineTicket.Text.Length > 12)
                txtStampstoReview.Focus();
        }

        private void txtStampstoReview_TextChanged(object sender, EventArgs e)
        {
            if (txtStampstoReview.Text.Length > 8)
                txtEmissionDate.Focus();
        }

        private void txtEmissionDate_TextChanged(object sender, EventArgs e)
        {
            if (txtEmissionDate.Text.Length > 6)
                txtEmisionCity.Focus();
        }

        private void txtEmisionCity_TextChanged(object sender, EventArgs e)
        {
            if (txtEmisionCity.Text.Length > 2)
                txtIATA.Focus();
        }

        private void txtIATA_TextChanged(object sender, EventArgs e)
        {
            if (txtIATA.Text.Length > 7)
                txtAirline.Focus();
        }

        private void txtAirlineTicke2_TextChanged(object sender, EventArgs e)
        {
            if (txtAirlineTicke2.Text.Length > 12)
                txtSegment1.Focus();
        }

        private void txtSegment1_TextChanged(object sender, EventArgs e)
        {
            if (txtSegment1.Text.Length > 1)
                txtSegment2.Focus();
        }

        private void txtSegment2_TextChanged(object sender, EventArgs e)
        {
            if (txtSegment2.Text.Length > 1)
                txtDate1.Focus();
        }

        private void txtDate1_TextChanged(object sender, EventArgs e)
        {
            if (txtDate1.Text.Length > 4)
                txtDate2.Focus();
        }

        private void txtDate2_TextChanged(object sender, EventArgs e)
        {
            if (txtDate2.Text.Length > 4)
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
                txtDate3.Focus();
        }

        private void txtDate3_TextChanged(object sender, EventArgs e)
        {
            if (txtDate3.Text.Length > 4)
                txtDate4.Focus();
        }

        private void txtDate4_TextChanged(object sender, EventArgs e)
        {
            if (txtDate4.Text.Length > 4)
                txtSegment5.Focus();
        }

        private void txtSegment5_TextChanged(object sender, EventArgs e)
        {
            if (txtSegment5.Text.Length > 1)
                txtSegment6.Focus();
        }

        private void txtSegment6_TextChanged(object sender, EventArgs e)
        {
            if (txtSegment6.Text.Length > 1)
                txtDate5.Focus();
        }

        private void txtDate5_TextChanged(object sender, EventArgs e)
        {
            if (txtDate5.Text.Length > 4)
                txtDate6.Focus();
        }

        private void txtDate6_TextChanged(object sender, EventArgs e)
        {
            if (txtDate6.Text.Length > 4)
                txtSegment7.Focus();
        }

        private void txtSegment7_TextChanged(object sender, EventArgs e)
        {
            if (txtSegment7.Text.Length > 1)
                txtSegment8.Focus();
        }

        private void txtSegment8_TextChanged(object sender, EventArgs e)
        {
            if (txtSegment8.Text.Length > 1)
                txtDate7.Focus();
        }

        private void txtDate7_TextChanged(object sender, EventArgs e)
        {
            if (txtDate7.Text.Length > 4)
                txtDate8.Focus();
        }

        private void txtDate8_TextChanged(object sender, EventArgs e)
        {
            if (txtDate8.Text.Length > 4)
                btnAccept.Focus();
        }

        #endregion

        //Radio Button checked coloca el estado de los controles
        private void rdoCash_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSecondRevised.Checked)
            {
                txtAirlineTicke2.Enabled = true;
                txtAirlineTicke2.BackColor = Color.White;
            }
            else
            {
                txtAirlineTicke2.Enabled = false;
                txtAirlineTicke2.BackColor = SystemColors.Control;
            }
        }

        //Radio Button checked coloca el estado de los controles
        private void rdoCreditCard_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSecondRevised.Checked)
            {
                txtAirlineTicke2.Enabled = true;
                txtAirlineTicke2.BackColor = Color.White;
            }
            else
            {
                txtAirlineTicke2.Enabled = false;
                txtAirlineTicke2.BackColor = SystemColors.Control;
            }
        }
    }
}
