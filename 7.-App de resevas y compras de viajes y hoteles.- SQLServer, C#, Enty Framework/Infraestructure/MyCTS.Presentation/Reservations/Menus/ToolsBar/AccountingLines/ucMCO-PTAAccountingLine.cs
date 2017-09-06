using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Forms.UI;
using MyCTS.Entities;
using MyCTS.Business;

namespace MyCTS.Presentation
{
    public partial class ucMCO_PTAAccountingLine : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Armado del comando que se envia a sabre para las lineas
        ///              contables MCO o PTA.
        /// Creación:    14/Abril/2010 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Angel Trejo
        /// </summary>
        public ucMCO_PTAAccountingLine()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = rdoMCO;
            this.LastControlFocus = btnAccept;

        }
        //Global Variables**************************        
        private TextBox txt;
        private bool statusParamReceived;
        private bool allowDecimal = true;
        //******************************************

        private void ucMCO_PTAAccountingLine_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            if (!Convert.ToBoolean(ParameterBL.GetParameterValue("AllowDecimalNumbers").Values))
            {
                txtQuantity.CharsIncluded = null;
                txtBasisFare.Text = "0";
                txtBasisFare.CharsIncluded = null;
                txtTaxe1.Text = "0";
                txtTaxe1.CharsIncluded = null;
                txtTaxe2.Text = "0";
                txtTaxe2.CharsIncluded = null;
                allowDecimal = false;
            }
            HideListboxControls();
            foreach (Control txt in this.Controls)
                if (txt is SmartTextBox && !txt.Enabled)
                    txt.BackColor = SystemColors.Control;
            rdoMCO.Checked = true;
            rdoMCO.Focus();
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
        /// Valida las reglas de negocio aplicables a este User Control
        /// </summary>
        private bool IsValidBussinesRules
        {
            get
            {
                bool status = false;
                if (string.IsNullOrEmpty(txtSegment.Text))
                {
                    MessageBox.Show("SE DEBE INGRESAR EL NÚMERO DE SEGMENTO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSegment.Focus();
                }
                else if (string.IsNullOrEmpty(txtAirLine.Text))
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
                    MessageBox.Show("SE DEBE INGRESAR EL PORCENTAJE DE COMISIÓN O MONTO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCommision.Focus();
                }
                else if (!string.IsNullOrEmpty(txtCommision.Text) && !string.IsNullOrEmpty(txtQuantity.Text))
                {
                    MessageBox.Show("SE DEBE INGRESAR EL PORCENTAJE DE COMISIÓN O MONTO (SOLO UN DATO)", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCommision.Focus();
                }
                else if (allowDecimal && !string.IsNullOrEmpty(txtQuantity.Text) && !ValidateRegularExpression.ValidateTwoDecimalNumbers(txtQuantity.Text))
                {
                    MessageBox.Show("EL MONTO DEBE TENER 2 DECIMALES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                else if (string.IsNullOrEmpty(txtTaxe1.Text))
                {
                    MessageBox.Show("SE DEBE INGRESAR EL IMPUESTO 1", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTaxe1.Focus();
                }
                else if (allowDecimal && !string.IsNullOrEmpty(txtTaxe1.Text) && !ValidateRegularExpression.ValidateTwoDecimalNumbers(txtTaxe1.Text))
                {
                    MessageBox.Show("EL IMPUESTO 1 DEBE TENER 2 DECIMALES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTaxe1.Focus();
                }
                else if (allowDecimal && !string.IsNullOrEmpty(txtTaxe2.Text) && !ValidateRegularExpression.ValidateTwoDecimalNumbers(txtTaxe2.Text))
                {
                    MessageBox.Show("EL IMPUESTO 2 DEBE TENER 2 DECIMALES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTaxe2.Focus();
                }
                else if (!rdoOne.Checked && !rdoALL.Checked && !rdoPER.Checked)
                {
                    MessageBox.Show("SE DEBE INDICAR LA APLICACIÓN", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                else if (!string.IsNullOrEmpty(txtNumberCard.Text) && txtNumberCard.TextLength < 15)
                {
                    MessageBox.Show("EL NÚMERO DE TARJETA DEBE SER DE 15 Ó 16 DIGITOS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberCard.Focus();
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
                else
                    status = true;
                return status;
            }
        }

        /// <summary>
        /// Armado del commando que se envia a sabre
        /// </summary>
        private void BuildCommand()
        {
            string sabre = "AC";
            if (rdoMCO.Checked)
                sabre = string.Concat(sabre, "MCO");
            else
                sabre = string.Concat(sabre, "PTA");
            sabre = string.Concat(sabre, txtSegment.Text,
                "/", txtAirLine.Text, "/", txtNumberTicket.Text, txtDigit.Text, "/");
            if (!string.IsNullOrEmpty(txtCommision.Text))
                sabre = string.Concat(sabre, "P", txtCommision.Text);
            else
                sabre = string.Concat(sabre, txtQuantity.Text);
            if (string.IsNullOrEmpty(txtTaxe2.Text))
                txtTaxe2.Text = "0.00";
            sabre = string.Concat(sabre, "/",txtBasisFare.Text,"/",
                txtTaxe1.Text,"/D",txtTaxe2.Text,"/");
            if(rdoOne.Checked)
                sabre = string.Concat(sabre, "ONE/");
            else if(rdoALL.Checked)
                sabre = string.Concat(sabre, "ALL/");
            else
                sabre = string.Concat(sabre, "PER/");   
            if(rdoCA.Checked)
                sabre = string.Concat(sabre, "CA");
            else if(rdoCC.Checked)
                sabre = string.Concat(sabre, "CC");
            else
                sabre = string.Concat(sabre, "CX");
            if (rdoCC.Checked || rdoCX.Checked)
                sabre = string.Concat(sabre, txtCardCode.Text, txtNumberCard.Text);
            if (rdoOne.Checked)
                sabre = string.Concat(sabre, " ", txtPaxNumber.Text, txtLastname.Text);
            sabre = string.Concat(sabre, "/", txtNumberDoctos.Text);
            if (!string.IsNullOrEmpty(txtComentarios.Text))
                sabre = string.Concat(sabre, "-", txtComentarios.Text);
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(sabre);
            }
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }

        #endregion //METHODS CLASS

        #region ====== PREDICTIVES ======

        private void txtAirLine_TextChanged(object sender, EventArgs e)
        {
            if (!statusParamReceived)
            {
                txt = (TextBox)sender;
                Common.SetListBoxAirlines(txt, lbAirline);
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

        #endregion//PREDICTIVES

        #region ====== RADIOBUTTONS CHANGES ======

        private void rdoOne_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOne.Checked && rdoCA.Checked)
            {
                foreach (Control txt in this.Controls)
                {
                    if (txt is SmartTextBox && txt.TabIndex >= 19 && txt.TabIndex <= 23)
                    {
                        txt.Enabled = false;
                        txt.BackColor = SystemColors.Control;
                        txt.Text = string.Empty;
                    }
                    if (txt is SmartTextBox && txt.TabIndex >= 21 && txt.TabIndex <= 23)
                    {
                        txt.Enabled = true;
                        txt.BackColor = Color.White;
                        txt.Text = string.Empty;
                    }
                }
            }
            else if (rdoOne.Checked && (rdoCC.Checked || rdoCX.Checked))
            {
                foreach (Control txt in this.Controls)
                {
                    //if (txt is SmartTextBox && txt.TabIndex >= 19 && txt.TabIndex <= 23)
                    //{
                    //    txt.Enabled = false;
                    //    txt.BackColor = SystemColors.Control;
                    //    txt.Text = string.Empty;
                    //}
                    if (txt is SmartTextBox && (txt.TabIndex >= 19 && txt.TabIndex <= 23))// || txt.TabIndex == 23))
                    {
                        txt.Enabled = true;
                        txt.BackColor = Color.White;
                        txt.Text = string.Empty;
                    }
                }
            }
            else if (rdoPER.Checked && rdoCA.Checked)
            {
                foreach (Control txt in this.Controls)
                {
                    if (txt is SmartTextBox && txt.TabIndex >= 19 && txt.TabIndex <= 23)
                    {
                        txt.Enabled = false;
                        txt.BackColor = SystemColors.Control;
                        txt.Text = string.Empty;
                    }
                    if (txt is SmartTextBox && (txt.TabIndex == 21 || txt.TabIndex == 22))
                    {
                        txt.Enabled = true;
                        txt.BackColor = Color.White;
                        txt.Text = string.Empty;
                    }
                }
            }
            else if (rdoALL.Checked && rdoCA.Checked)
            {
                foreach (Control txt in this.Controls)
                {
                    if (txt is SmartTextBox && txt.TabIndex >= 19 && txt.TabIndex <= 23)
                    {
                        txt.Enabled = false;
                        txt.BackColor = SystemColors.Control;
                        txt.Text = string.Empty;
                    }
                }
            }
            else if ((rdoALL.Checked || rdoPER.Checked) && (rdoCC.Checked || rdoCX.Checked))
            {
                foreach (Control txt in this.Controls)
                {
                    if (txt is SmartTextBox && txt.TabIndex >= 19 && txt.TabIndex <= 23)
                    {
                        txt.Enabled = false;
                        txt.BackColor = SystemColors.Control;
                        txt.Text = string.Empty;
                    }
                    if (txt is SmartTextBox && (txt.TabIndex == 19 || txt.TabIndex == 20))
                    {
                        txt.Enabled = true;
                        txt.BackColor = Color.White;
                        txt.Text = string.Empty;
                    }
                }
            }
        }

        #endregion//RADIOBUTTONS CHANGES

        #region ======Back to a Previous Usercontrol or Validate Enter KeyDown=====

        /// <summary>
        /// Regresa al ucWelcome cuando se presion la tecla Esc y ejecuta las acciones del
        /// boton aceptar cuando se presiona Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                VolarisSession.Clean();
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            if (e.KeyData == Keys.Enter)
            {
                btnAccept_Click(sender, e);
            }
        }

        #endregion //Back to a Previous Usercontrol or Validate Enter KeyDown

        private void txtSegment_TextChanged(object sender, EventArgs e)
        {
            if (sender is SmartTextBox)
                if (((SmartTextBox)sender).Text.Length > ((SmartTextBox)sender).MaxLength - 1)
                    foreach (Control txt in this.Controls)
                        if (txt.TabIndex.Equals(((SmartTextBox)(sender)).TabIndex + 1))
                        {
                            txt.Focus();
                            break;
                        }
        }
    }
}
