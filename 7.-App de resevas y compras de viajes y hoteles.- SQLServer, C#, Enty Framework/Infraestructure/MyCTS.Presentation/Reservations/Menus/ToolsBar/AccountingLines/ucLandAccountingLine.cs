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
    public partial class ucLandAccountingLine : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Armado del comando que se envia a sabre para las lineas
        ///              contables terrestres.
        /// Creación:    14/Abril/2010 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Angel Trejo
        /// </summary>
        public ucLandAccountingLine()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = rdoHotel;
            this.LastControlFocus = btnAccept;
        }

        //Global Variables**********************
        private TextBox txt;
        private bool statusParamReceived;
        //private bool allowDecimal = true;
        //**************************************

        private void ucLandAccountingLine_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            //if (!Convert.ToBoolean(ParameterBL.GetParameterValue("AllowDecimalNumbers").Values))
            //{
            //    txtBasisFare.Text = "0";
            //    txtBasisFare.CharsIncluded = null;
            //    txtIVA.Text = "0";
            //    txtIVA.CharsIncluded = null;
            //    txtOtherTaxes.Text = "0";
            //    txtOtherTaxes.CharsIncluded = null;
            //    allowDecimal = false;
            //}
            HideListboxControls();
            foreach (Control txt in this.Controls)
                if (txt is SmartTextBox && !txt.Enabled)
                    txt.BackColor = SystemColors.Control;              
            rdoHotel.Checked = true;
            rdoHotel.Focus();
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
        /// Reglas de negocio aplicables a este user control
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
                else if (!rdoVoucher.Checked && !rdoTotalPay.Checked && !rdoDeposit.Checked && !rdoFinalPay.Checked)
                {
                    MessageBox.Show("SE DEBE INDICAR EL TIPO DE FACTURA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtNumVoucher.Enabled && string.IsNullOrEmpty(txtNumVoucher.Text))
                {
                    MessageBox.Show("SE DEBE INGRESAR EL NÚMERO DE VOUCHER", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumVoucher.Focus();
                }
                else if (string.IsNullOrEmpty(txtBasisFare.Text))
                {
                    MessageBox.Show("SE DEBE INGRESAR LA TARIFA BASE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBasisFare.Focus();
                }
                else if (!string.IsNullOrEmpty(txtBasisFare.Text) && !ValidateRegularExpression.ValidateTwoDecimalNumbers(txtBasisFare.Text))
                {
                    MessageBox.Show("LA TARIFA BASE DEBE TENER 2 DECIMALES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBasisFare.Focus();
                }
                else if (string.IsNullOrEmpty(txtIVA.Text))
                {
                    MessageBox.Show("SE DEBE INGRESAR EL IVA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIVA.Focus();
                }
                else if (!string.IsNullOrEmpty(txtIVA.Text) && !ValidateRegularExpression.ValidateTwoDecimalNumbers(txtIVA.Text))
                {
                    MessageBox.Show("LA CANTIDAD DEL IVA DEBE TENER 2 DECIMALES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIVA.Focus();
                }
                else if (!string.IsNullOrEmpty(txtOtherTaxes.Text) && !ValidateRegularExpression.ValidateTwoDecimalNumbers(txtOtherTaxes.Text))
                {
                    MessageBox.Show("OTROS IMPUESTOS DEBEN TENER 2 DECIMALES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtOtherTaxes.Focus();
                }
                else if (string.IsNullOrEmpty(txtCommision.Text))
                {
                    MessageBox.Show("SE DEBE INGRESAR EL PORCENTAJE DE COMISIÓN", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCommision.Focus();
                }
                else if (!rdoOne.Checked && !rdoALL.Checked && !rdoPER.Checked)
                {
                    MessageBox.Show("SE DEBE INDICAR LA FORMA DE APLICACIÓN", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!rdoCA.Checked && !rdoCC2.Checked)
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
                else if (!string.IsNullOrEmpty(txtNumberCard.Text) && txtNumberCard.TextLength <15)
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
                else if (string.IsNullOrEmpty(txtNumDoctos.Text))
                {
                    MessageBox.Show("SE DEBE INGRESAR EL NÚMERO DE DOCUMENTOS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumDoctos.Focus();
                }
                else if (string.IsNullOrEmpty(txtPaxNumber.Text))
                {
                    MessageBox.Show("SE DEBE INGRESAR LA POSICIÓN DEL PASAJERO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPaxNumber.Focus();
                }
                else if (!string.IsNullOrEmpty(txtPaxNumber.Text) && !ValidateRegularExpression.ValidateOneorTwoPlusDecimalNumber(txtPaxNumber.Text))
                {
                    MessageBox.Show("LA POSICIÓN DEL PASAJERO DEBE TENER 1 DECIMAL", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPaxNumber.Focus();
                }
                else
                    status = true;
                return status;
            }
        }

        /// <summary>
        /// Armado del comando que se envia a sabre 
        /// </summary>
        private void BuildCommand()
        {
            string sabre = string.Empty;
            sabre = "AC";
            if (rdoHotel.Checked)
                sabre = string.Concat(sabre, "HHT");
            else if (rdoAuto.Checked)
                sabre = string.Concat(sabre, "CAR");
            else if(rdoOthers.Checked)
                sabre = string.Concat(sabre, "OTH");
            else if(rdoInsurance.Checked)
                sabre = string.Concat(sabre, "INS");
            else if(rdoTour.Checked)
                sabre = string.Concat(sabre, "TOR");
            else if(rdoCruise.Checked)
                sabre = string.Concat(sabre, "SEA");
            else if(rdoBus.Checked)
                sabre = string.Concat(sabre, "BUS");
            else
                sabre = string.Concat(sabre, "RAL");
            sabre = string.Concat(sabre, txtSegment.Text, "/SUPPLY/");
            if (rdoVoucher.Checked)
                sabre = string.Concat(sabre, "VCH", txtNumVoucher.Text);
            else if (rdoTotalPay.Checked)
                sabre = string.Concat(sabre, "FLP");
            else if (rdoDeposit.Checked)
                sabre = string.Concat(sabre, "DEP");
            else
                sabre = string.Concat(sabre, "FPT");
            if (string.IsNullOrEmpty(txtOtherTaxes.Text))
                txtOtherTaxes.Text = "0.00";
            sabre = string.Concat(sabre, "/P", txtCommision.Text, "/", txtBasisFare.Text,
                "/", txtIVA.Text, "/D", txtOtherTaxes.Text, "/");
            if(rdoOne.Checked)
                sabre = string.Concat(sabre, "ONE");
            else if(rdoALL.Checked)
                sabre = string.Concat(sabre, "ALL");
            else
                sabre = string.Concat(sabre, "PER");
            if (rdoCA.Checked)
                sabre = string.Concat(sabre, "/CA", " ", txtPaxNumber.Text, txtLastname.Text,
                    " ", txtInicialName.Text);
            else
                sabre = string.Concat(sabre, "/CC", txtCardCode.Text, txtNumberCard.Text,
                    " ", txtPaxNumber.Text, txtLastname.Text, " ", txtInicialName.Text);
            sabre = string.Concat(sabre, "/", txtNumDoctos.Text);
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(sabre);
            }
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }

        #endregion//METHODS CLASS

        #region ====== PREDICTIVES ======

        private void txtCardCode_TextChanged(object sender, EventArgs e)
        {
            if (!statusParamReceived)
            {
                txt = (TextBox)sender;
                Common.SetListBoxCreditCards(txt, lbCardCode);
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

        #endregion PREDICTIVES

        #region ====== RADIOBUTTONS CHANGES ======

        private void rdoCA_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCC2.Checked)
            {
                foreach (Control txt in this.Controls)
                    if (txt is SmartTextBox && txt.TabIndex >= 24 && txt.TabIndex <= 27)
                    {
                        txt.Enabled = true;
                        txt.BackColor = Color.White;
                        txt.Text = string.Empty;
                    }
            }
            else if(rdoCA.Checked)
            {
                foreach (Control txt in this.Controls)
                {
                    if (txt is SmartTextBox && txt.TabIndex >= 24 && txt.TabIndex <= 25)
                    {
                        txt.Enabled = false;
                        txt.BackColor = SystemColors.Control;
                        txt.Text = string.Empty;
                    }
                    else if (txt is SmartTextBox && txt.TabIndex >= 26 && txt.TabIndex <= 27)
                    {
                        txt.Enabled = true;
                        txt.BackColor = Color.White;
                        txt.Text = string.Empty;
                    }
                }
            }
        }
        private void rdoVoucher_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoVoucher.Checked)
            {
                txtNumVoucher.Enabled = true;
                txtNumVoucher.BackColor = Color.White;
                txtNumVoucher.Text = string.Empty;
            }
            else
            {
                txtNumVoucher.Enabled = false;
                txtNumVoucher.BackColor = SystemColors.Control;
                txtNumVoucher.Text = string.Empty;
            }
        }

        #endregion //RADIOBUTTONS CHANGES

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

        private void txtPaxNumber_TextChanged(object sender, EventArgs e)
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
