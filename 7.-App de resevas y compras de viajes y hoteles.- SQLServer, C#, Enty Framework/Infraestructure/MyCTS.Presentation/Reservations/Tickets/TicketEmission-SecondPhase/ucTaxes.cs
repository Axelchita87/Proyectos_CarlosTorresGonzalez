/// <summary>
/// Descripcion: Permite la excención o modificación de montos de impuestos.
/// Pertenece a: Reservaciones
/// Creación:    22-Mayo-2009
/// Autor:       Pedro Tomas Solis
/// </summary>

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Business;
using MyCTS.Entities;
using System.Text.RegularExpressions;
using MyCTS.Forms.UI;

namespace MyCTS.Presentation
{
    public partial class ucTaxes : CustomUserControl
    {
        //Declaracion de variables
        #region =====Variables=====
        private string send=string.Empty;
        private string result=string.Empty;
        private string TaxCode1 = string.Empty;
        private string TaxCode2 = string.Empty;
        private string TaxCode3 = string.Empty;
        private string TaxCode4 = string.Empty;
        private string TaxCode5 = string.Empty;
        private string TaxCode6 = string.Empty;
        public static string Taxes17 = string.Empty;
        public static string datos  = string.Empty;
        public static bool emissionTicket = false;
        #endregion

        // Constructor
        public ucTaxes()
        {
            InitializeComponent();
        }

        #region =====Eventos=====

        // Evento Load, si se eligio la opcion de impuestos en la emision, muestra la mascarilla
        // caso contrario, se va a la mascarilla de confirmacion de emision
        private void ucTaxes_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            if (ucTicketsEmissionInstructions.showUcTaxes)
            {
                //ReceiveParameters();

                rdoExention.Checked = true;
                //Paso 6. Taxes
                Taxes_StepSix();

            }
            else
            {
                //SendParameters();
                Taxes17 = string.Empty;
                if (!ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_CASH))
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCFORMPAYMENT);
                }
                if (!string.IsNullOrEmpty(ucAllQualityControls.tempChargeService) && ucAllQualityControls.counter < 10)
                    Loader.AddToPanel(Loader.Zone.Middle, this, "ucCalculateServiceCharge");
                else
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_TICKETEMISSION_CONFIRMATION);
                }
            }
        }

        // Boton de radio Excencion, activa las casillas de impuestos y las opciones de excención, 
        // desactiva las casillas de montos.
        private void rdoExention_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoExention.Checked)
                setControlValues(true);
            else
                setControlValues(false);
        }

        // Boton de radio Modificacion, activa las casillas de montos y desactiva las casillas de impuestos y excencion
        private void rdoModification_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoExention.Checked)
                setControlValues(true);
            else
                setControlValues(false);
        }

        /// Evento que se dispara al oprimir la tecla Enter o la tecla Esc
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTICKETSEMISSIONINSTRUCTIONS);
            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }

        /// Boton aceptar, aplica los impuestos o montos seleccionados
        private void btnAccept_Click(object sender, EventArgs e)
        {
            //Paso 17. Taxes
            if (validBussinesRules())
            {
                Taxes_StepSeventeen();
                if (!ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_CASH))
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCFORMPAYMENT);
                }
                else if (!string.IsNullOrEmpty(ucAllQualityControls.tempChargeService) && ucAllQualityControls.counter < 10)
                    Loader.AddToPanel(Loader.Zone.Middle, this, "ucCalculateServiceCharge");
                else
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_TICKETEMISSION_CONFIRMATION);
                }
            }
        }

        #endregion

        #region =====Metodos=====

        /// <summary>
        /// Verfifica los impuestos aplicables a la emision de boleto en curso, paso 6 
        /// </summary>
        private void Taxes_StepSix()
        {
            int row = 0;
            int col = 0;
            send = Resources.TicketEmission.Constants.COMMANDS_TXN_AST_MX;
            using (CommandsAPI objCommands = new CommandsAPI())
            {
              result = objCommands.SendReceive(send);
            }
            //TaxCode1
            CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.ONE, ref row, ref col);
            if (row != 0 || col != 0)
            {
                CommandsQik.CopyResponse(result, ref TaxCode1, row, 7, 2);
                txtTax1.Text = TaxCode1;
                row++;
                col = 0;
                //TaxCode2
                CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.TWO, ref row, ref col);
                if (row != row-1 || col != 0)
                {
                    CommandsQik.CopyResponse(result, ref TaxCode2, row, 7, 2);
                    txtTax2.Text = TaxCode2;
                    row++;
                    col = 0;
                    //TaxCode3
                    CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.THREE, ref row, ref col);
                    if (row != row - 1 || col != 0)
                    {
                        CommandsQik.CopyResponse(result, ref TaxCode3, row, 7, 2);
                        txtTax3.Text = TaxCode3;
                        row++;
                        col = 0;
                        //TaxCode4
                        CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.FOUR, ref row, ref col);
                        if (row != row - 1 || col != 0)
                        {
                            CommandsQik.CopyResponse(result, ref TaxCode4, row, 7, 2);
                            txtTax4.Text = TaxCode4;
                            row++;
                            col = 0;
                            //TaxCode5
                            CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.FIVE, ref row, ref col);
                            if (row != row - 1 || col != 0)
                            {
                                CommandsQik.CopyResponse(result, ref TaxCode5, row, 7, 2);
                                txtTax5.Text = TaxCode5;
                                row++;
                                col = 0;
                                //TaxCode6
                                CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.SIX, ref row, ref col);
                                if (row != row - 1 || col != 0)
                                {
                                    CommandsQik.CopyResponse(result, ref TaxCode6, row, 7, 2);
                                    txtTax6.Text = TaxCode6;
                                }
                            }
                        }
                    }
                }
            }
            
        }

        /// <summary>
        /// Aplica la excencion o modificación de impuestos seleccionadas en la mascarilla de Impuestos, paso 17
        /// </summary>
        private void Taxes_StepSeventeen()
        {
            Taxes17 = string.Empty;
            if (ucTicketsEmissionInstructions.showUcTaxes)
            {
                if (rdoExention.Checked)
                {
                    datos = string.Empty;
                    Taxes17 = string.Concat(Taxes17, Resources.TicketEmission.Constants.COMMANDS_LORRAINE_CROSS_TE_INDENT);
                    if (chbExent1.Checked && (!string.IsNullOrEmpty(txtTax1.Text)))
                    {
                        Taxes17 = string.Concat(Taxes17, txtTax1.Text.Trim());
                        datos = Resources.TicketEmission.Constants.EX;
                    }
                    if (chbExent2.Checked && (!string.IsNullOrEmpty(txtTax2.Text)))
                    {
                        if (!string.IsNullOrEmpty(datos))  //if datos concat Sabre+'/'
                            Taxes17 = string.Concat(Taxes17, Resources.TicketEmission.Constants.SLASH);
                        Taxes17 = string.Concat(Taxes17, txtTax2.Text.Trim()); //Concat Sabre+Tax2
                        datos = Resources.TicketEmission.Constants.EX;
                    }
                    if (chbExent3.Checked && (!string.IsNullOrEmpty(txtTax3.Text)))
                    {
                        if (!string.IsNullOrEmpty(datos))  //if datos concat Sabre+'/'
                            Taxes17 = string.Concat(Taxes17, Resources.TicketEmission.Constants.SLASH);
                        Taxes17 = string.Concat(Taxes17, txtTax3.Text.Trim()); //Concat Sabre+Tax3
                        datos = Resources.TicketEmission.Constants.EX;
                    }
                    if (chbExent4.Checked && (!string.IsNullOrEmpty(txtTax4.Text)))
                    {
                        if (!string.IsNullOrEmpty(datos))  //if datos concat Sabre+'/'
                            Taxes17 = string.Concat(Taxes17, Resources.TicketEmission.Constants.SLASH);
                        Taxes17 = string.Concat(Taxes17, txtTax4.Text.Trim()); //Concat Sabre+Tax4
                        datos = Resources.TicketEmission.Constants.EX;
                    }
                    if (chbExent5.Checked && (!string.IsNullOrEmpty(txtTax5.Text)))
                    {
                        if (!string.IsNullOrEmpty(datos))  //if datos concat Sabre+'/'
                            Taxes17 = string.Concat(Taxes17, Resources.TicketEmission.Constants.SLASH);
                        Taxes17 = string.Concat(Taxes17, txtTax5.Text.Trim()); //Concat Sabre+Tax5
                        datos = Resources.TicketEmission.Constants.EX;
                    }
                    if (chbExent6.Checked && (!string.IsNullOrEmpty(txtTax6.Text)))
                    {
                        if (!string.IsNullOrEmpty(datos))  //if datos concat Sabre+'/'
                            Taxes17 = string.Concat(Taxes17, Resources.TicketEmission.Constants.SLASH);
                        Taxes17 = string.Concat(Taxes17, txtTax6.Text.Trim()); //Concat Sabre+Tax6
                        datos = Resources.TicketEmission.Constants.EX;
                    }
                }
                if (rdoModification.Checked)
                {
                    datos = string.Empty;
                    Taxes17 = string.Concat(Taxes17, Resources.TicketEmission.Constants.COMMANDS_LORRAINE_CROSS_TXN);
                    //concat Sabre Monto1 Impuesto1_code
                    if (!string.IsNullOrEmpty(txtTax1.Text) && !string.IsNullOrEmpty(txtMount1.Text))
                    {
                        Taxes17 = string.Concat(Taxes17, txtMount1.Text.Trim(), txtTax1.Text.Trim());
                        datos = Resources.TicketEmission.Constants.EX;
                    }
                    //concat Sabre '/' Monto2 Impuesto2_code
                    if (!string.IsNullOrEmpty(txtTax2.Text) && !string.IsNullOrEmpty(txtMount2.Text))
                    {
                        if (!string.IsNullOrEmpty(datos))
                        {
                            Taxes17 = string.Concat(Taxes17, Resources.TicketEmission.Constants.SLASH);
                        }
                        Taxes17 = string.Concat(Taxes17, txtMount2.Text.Trim(), txtTax2.Text.Trim());
                        datos = Resources.TicketEmission.Constants.EX;
                    }
                    //concat Sabre '/' Monto3 Impuesto3_code
                    if (!string.IsNullOrEmpty(txtTax3.Text) && !string.IsNullOrEmpty(txtMount3.Text))
                    {
                        if (!string.IsNullOrEmpty(datos))
                        {
                            Taxes17 = string.Concat(Taxes17, Resources.TicketEmission.Constants.SLASH);
                        }
                        Taxes17 = string.Concat(Taxes17, txtMount3.Text.Trim(), txtTax3.Text.Trim());
                        datos = Resources.TicketEmission.Constants.EX;
                    }
                    //concat Sabre '/' Monto4 Impuesto4_code
                    if (!string.IsNullOrEmpty(txtTax4.Text) && !string.IsNullOrEmpty(txtMount4.Text))
                    {
                        if (!string.IsNullOrEmpty(datos))
                        {
                            Taxes17 = string.Concat(Taxes17, Resources.TicketEmission.Constants.SLASH);
                        }
                        Taxes17 = string.Concat(Taxes17, txtMount4.Text.Trim(), txtTax4.Text.Trim());
                        datos = Resources.TicketEmission.Constants.EX;
                    }
                    //concat Sabre '/' Monto5 Impuesto5_code
                    if (!string.IsNullOrEmpty(txtTax5.Text) && !string.IsNullOrEmpty(txtMount5.Text))
                    {
                        if (!string.IsNullOrEmpty(datos))
                        {
                            Taxes17 = string.Concat(Taxes17, Resources.TicketEmission.Constants.SLASH);
                        }
                        Taxes17 = string.Concat(Taxes17, txtMount5.Text.Trim(), txtTax5.Text.Trim());
                        datos = Resources.TicketEmission.Constants.EX;
                    }
                    //concat Sabre '/' Monto6 Impuesto6_code
                    if (!string.IsNullOrEmpty(txtTax6.Text) && !string.IsNullOrEmpty(txtMount6.Text))
                    {
                        if (!string.IsNullOrEmpty(datos))
                        {
                            Taxes17 = string.Concat(Taxes17, Resources.TicketEmission.Constants.SLASH);
                        }
                        Taxes17 = string.Concat(Taxes17, txtMount6.Text.Trim(), txtTax6.Text.Trim());
                        datos = Resources.TicketEmission.Constants.EX;
                    }
                    if (Taxes17.Equals("‡TXN"))
                        Taxes17 = string.Empty;
                }
            }
        }

        /// <summary>
        /// habilita o inhabilita las casillas de excencion o montos de impuestos
        /// </summary>
        /// <param name="Value"></param>
        private void setControlValues(bool Value)
        {
            chbExent1.Enabled = Value;
            chbExent2.Enabled = Value;
            chbExent3.Enabled = Value;
            chbExent4.Enabled = Value;
            chbExent5.Enabled = Value;
            chbExent6.Enabled = Value;
            txtMount1.Enabled = !Value;
            txtMount2.Enabled = !Value;
            txtMount3.Enabled = !Value;
            txtMount4.Enabled = !Value;
            txtMount5.Enabled = !Value;
            txtMount6.Enabled = !Value;
        }

        /// <summary>
        /// Guarda los valores actuales de los controles de la mascarilla de Impuestos
        /// </summary>
        private void SendParameters()
        {
            string[] sendInfo =
                new string[]{
                                rdoExention.Checked.ToString(),
                                rdoModification.Checked.ToString(),
                                txtTax1.Text,
                                txtTax2.Text,
                                txtTax3.Text,
                                txtTax4.Text,
                                txtTax5.Text,
                                txtTax6.Text,
                                chbExent1.Text,
                                chbExent2.Text,
                                chbExent3.Text,
                                chbExent4.Text,
                                chbExent5.Text,
                                chbExent6.Text,
                                txtMount1.Text,
                                txtMount2.Text,
                                txtMount3.Text,
                                txtMount4.Text,
                                txtMount5.Text,
                                txtMount6.Text
                            };
            userControlsPreviousValues.Taxes = sendInfo;
        }

        /// <summary>
        /// Establece valores previos a los controles de la mascarilla de Impuestos
        /// </summary>
        private void ReceiveParameters()
        {
            if (userControlsPreviousValues.Taxes != null)
            {
                rdoExention.Checked = userControlsPreviousValues.Taxes[0].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE);
                rdoModification.Checked = userControlsPreviousValues.Taxes[1].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE);
                txtTax1.Text = userControlsPreviousValues.Taxes[2];
                txtTax2.Text = userControlsPreviousValues.Taxes[3];
                txtTax3.Text = userControlsPreviousValues.Taxes[4];
                txtTax4.Text = userControlsPreviousValues.Taxes[5];
                txtTax5.Text = userControlsPreviousValues.Taxes[6];
                txtTax6.Text = userControlsPreviousValues.Taxes[7];
                chbExent1.Text = userControlsPreviousValues.Taxes[8];
                chbExent2.Text = userControlsPreviousValues.Taxes[9];
                chbExent3.Text = userControlsPreviousValues.Taxes[10];
                chbExent4.Text = userControlsPreviousValues.Taxes[11];
                chbExent5.Text = userControlsPreviousValues.Taxes[12];
                chbExent6.Text = userControlsPreviousValues.Taxes[13];
                txtMount1.Text = userControlsPreviousValues.Taxes[14];
                txtMount2.Text = userControlsPreviousValues.Taxes[15];
                txtMount3.Text = userControlsPreviousValues.Taxes[16];
                txtMount4.Text = userControlsPreviousValues.Taxes[17];
                txtMount5.Text = userControlsPreviousValues.Taxes[18];
                txtMount6.Text = userControlsPreviousValues.Taxes[19];
                userControlsPreviousValues.Taxes = null;
            }
        }

        private bool validBussinesRules()
        {
            bool isValid = false;

            if ((!string.IsNullOrEmpty(txtMount1.Text) && (!ValidateRegularExpression.ValidateTwoDecimals(txtMount1.Text))))
            {
                MessageBox.Show("EL MONTO DEBE INCLUIR DOS DECIMALES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMount1.Focus();
            }
            else if ((!string.IsNullOrEmpty(txtMount2.Text) && (!ValidateRegularExpression.ValidateTwoDecimals(txtMount2.Text))))
            {
                MessageBox.Show("EL MONTO DEBE INCLUIR DOS DECIMALES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMount2.Focus();
            }
            else if ((!string.IsNullOrEmpty(txtMount3.Text) && (!ValidateRegularExpression.ValidateTwoDecimals(txtMount3.Text))))
            {
                MessageBox.Show("EL MONTO DEBE INCLUIR DOS DECIMALES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMount3.Focus();
            }
            else if ((!string.IsNullOrEmpty(txtMount4.Text) && (!ValidateRegularExpression.ValidateTwoDecimals(txtMount4.Text))))
            {
                MessageBox.Show("EL MONTO DEBE INCLUIR DOS DECIMALES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMount4.Focus();
            }
            else if ((!string.IsNullOrEmpty(txtMount5.Text) && (!ValidateRegularExpression.ValidateTwoDecimals(txtMount5.Text))))
            {
                MessageBox.Show("EL MONTO DEBE INCLUIR DOS DECIMALES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMount5.Focus();
            }
            else if ((!string.IsNullOrEmpty(txtMount6.Text) && (!ValidateRegularExpression.ValidateTwoDecimals(txtMount6.Text))))
            {
                MessageBox.Show("EL MONTO DEBE INCLUIR DOS DECIMALES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMount6.Focus();
            }
            else
            {
                isValid = true;
            }

            return isValid;

        }

        #endregion

    }
}
