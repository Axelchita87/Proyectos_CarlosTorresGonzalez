using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Forms.UI;
using MyCTS.Services.ValidateDKsAndCreditCards;

namespace MyCTS.Presentation
{
    public partial class frmFormOfPaypemt : Form
    {
        /// <summary>
        /// Descripcion: Especifica la forma de pago de los cargos por servicio
        ///              para cada pasajero
        /// Creación:    Mayo 20, 2010 , Modificación: *
        /// Cambio:      *   , Solicito: *
        /// Autor:       Angel Trejo
        /// </summary>
        /// 
        public frmFormOfPaypemt(string paxPossition, string userControl)
        {
            this.paxPossition = paxPossition;
            this.userControl = userControl;
            InitializeComponent();
        }

        //*********************
        //Globals Variables
        //*********************
        private TextBox txt;
        private string paxPossition;
        private string userControl;
        private bool statusParamReceived;

        private void frmFormOfPaypemt_Load(object sender, EventArgs e)
        {
            HideListboxControls();            
        }

        private void frmFormOfPaypemt_Shown(object sender, EventArgs e)
        {
            rdoAmericanExpress.Checked = false;
            rdoCash.Checked = false;
            rdoCreditCard.Checked = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidBussinesRules)
            {
                BuildRemarkByPax();
            }
        }

        #region ====== METHODS CLASS ======

        /// <summary>
        /// Valida las reglas de negocio aplicables a esta forma
        /// </summary>
        private bool IsValidBussinesRules
        {
            get
            {
                bool status = false;
                if (!rdoAmericanExpress.Checked && !rdoCash.Checked && !rdoCreditCard.Checked)
                {
                    MessageBox.Show("DEBE INDICAR LA FORMA DE PAGO DEL CARGO POR SERVICIO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtTypeCard.Visible && string.IsNullOrEmpty(txtTypeCard.Text))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_INGRESAR_TIPO_TARJETA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTypeCard.Focus();
                }
                else if (txtTypeCard.Visible && !string.IsNullOrEmpty(txtTypeCard.Text) && txtTypeCard.TextLength != 2)
                {
                    MessageBox.Show("EL CÓDIGO DE TARJETA DEBE SER DE 2 CARACTERES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTypeCard.Focus();
                }
                else if (!string.IsNullOrEmpty(txtTypeCard.Text) && rdoAmericanExpress.Checked &&
                        (!txtTypeCard.Text.Equals("AX") &&
                        !txtTypeCard.Text.Equals("TP") &&
                        !txtTypeCard.Text.Equals("DC")))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_INGRESAR_TIPO_TARJETA_VALIDA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTypeCard.Focus();
                }
                else if (!string.IsNullOrEmpty(txtTypeCard.Text) && rdoCreditCard.Checked
                        && !ValidateCredictCardCode(txtTypeCard.Text))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.TIPO_TARJETA_NO_VÁLIDA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTypeCard.Focus();
                }
                else if (txtNumberCard.Visible && string.IsNullOrEmpty(txtNumberCard.Text))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_INGRESAR_NUMERO_TARJETA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberCard.Focus();
                }
                else if (txtNumberCard.Visible && !string.IsNullOrEmpty(txtNumberCard.Text) && txtNumberCard.TextLength < 15)
                {
                    MessageBox.Show("EL NÚMERO DE TARJETA DEBE SER DE MAYOR A 14 DIGITOS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberCard.Focus();
                }
                else if (txtMonth.Visible && string.IsNullOrEmpty(txtMonth.Text))
                {
                    MessageBox.Show("SE DEBE INGRESER LOS DIGITOS DEL MES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMonth.Focus();
                }
                else if (txtMonth.Visible && !string.IsNullOrEmpty(txtMonth.Text) && (Convert.ToInt32(txtMonth.Text) > 12 || Convert.ToInt32(txtMonth.Text) < 1))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_MES_VALIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMonth.Focus();
                }
                else if (txtYear.Visible && string.IsNullOrEmpty(txtYear.Text))
                {
                    MessageBox.Show("DEBE INGRESAR LOS DIGITOS DEL AÑO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtYear.Focus();
                }
                else if (txtYear.Visible && !string.IsNullOrEmpty(txtYear.Text) && txtYear.TextLength != 2)
                {
                    MessageBox.Show("EL AÑO DEBE SER DE 2 DIGITOS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtYear.Focus();
                }
                else
                    status = true;
                return status;

            }
        }

        /// <summary>
        /// Muestro u oculta los controles 
        /// </summary>
        /// <param name="status">Estado de la propiedad visible para cada control</param>
        private void ShowControls(bool status)
        {
            txtTypeCard.Visible = status;
            txtMonth.Visible = status;
            txtNumberCard.Visible = status;
            txtYear.Visible = status;
            lblCardType.Visible = status;
            lblDateExpired.Visible = status;
            lblMonth.Visible = status;
            lblNumberCard.Visible = status;
            lblSlash.Visible = status;
            lblYear.Visible = status;
            btnShow.Visible = status;
        }

        private void BuildRemarkByPax()
        {
            string codeCTS = string.Empty;
            switch (txtTypeCard.Text)
            {
                case "AX":
                    codeCTS = "CCAC";
                    break;
                case "CA":
                    codeCTS = "CCPV";
                    break;
                case "VI":
                    codeCTS = "CCPV";
                    break;
                case "TP":
                    codeCTS = "CCTC";
                    break;
                default:
                    codeCTS = txtTypeCard.Text;
                    break;

            }            
            string remark = string.Format("-{0}-{1}/>",
                    codeCTS,
                    txtNumberCard.Text);
            if (paxPossition.Equals("1"))
                ucCalculateServiceCharge.RemarkPax1 = remark;
            else if (paxPossition.Equals("2"))
                ucCalculateServiceCharge.RemarkPax2 = remark;
            else if (paxPossition.Equals("3"))
                ucCalculateServiceCharge.RemarkPax3 = remark;
            else if (paxPossition.Equals("4"))
                ucCalculateServiceCharge.RemarkPax4 = remark;
            else if (paxPossition.Equals("5"))
                ucCalculateServiceCharge.RemarkPax5 = remark;
            else if (paxPossition.Equals("6"))
                ucCalculateServiceCharge.RemarkPax6 = remark;
            else if (paxPossition.Equals("7"))
                ucCalculateServiceCharge.RemarkPax7 = remark;
            else if (paxPossition.Equals("8"))
                ucCalculateServiceCharge.RemarkPax8 = remark;
            else if (paxPossition.Equals("9"))
                ucCalculateServiceCharge.RemarkPax9 = remark;

            this.Close();
        }

        /// <summary>
        /// Valida que se ingrese una aerlínea correcta
        /// </summary>
        /// <param name="code">código de aerolínea</param>
        /// <returns>Status</returns>
        private bool ValidateAirLineListCode(string code)
        {
            List<ListItem> airLinesList = CatPAirlinesFareBL.GetAirLinesFare(code);
            if (airLinesList.Count > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Valida que se ingrese una tarjeta correcta
        /// </summary>
        /// <param name="code">Código de tarjeta</param>
        /// <returns>Status</returns>
        private bool ValidateCredictCardCode(string code)
        {
            List<CatCreditCardsCodes> CreditCardsCodes = CatCreditCardsCodesBL.GetCreditCardsCodes(code);
            if (CreditCardsCodes.Count > 0)
                return true;
            else
                return false;
        }

        private void HideListboxControls()
        {
            statusParamReceived = false;
        }

        #endregion //METHODS CLASS

        #region ======== Mouse Click ========

        private void lbSystem_MouseClick(object sender, MouseEventArgs e)
        {
            string txt;
            txt = lbSystem.Text;
            txtTypeCard.Text = txt.Substring(0, 2);
            lbSystem.Visible = false;
            txtTypeCard.Focus();
        }

        private void lbTypeCard_MouseClick(object sender, MouseEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            ListItem li = (ListItem)listBox.SelectedItem;
            txt.Text = li.Value;
            listBox.Visible = false;
            txt.Focus();
        }

        #endregion 

        #region ====== PREDICTIVES ======

        private void txtTypeCard_TextChanged(object sender, EventArgs e)
        {
            txt = (TextBox)sender;
            if (rdoAmericanExpress.Checked)
            {
                if (!string.IsNullOrEmpty(txtTypeCard.Text) &&
                    (txtTypeCard.Text.Length < 2))
                {
                    lbSystem.Visible = true;
                    lbSystem.BringToFront();
                }
                else
                    lbSystem.Visible = false;
            }
            //else if (rdoMiscelaneous.Checked)
            //    Common.SetListBoxPAirlines(txt, lbTypeCard);
            else
                Common.SetListBoxCreditCards(txt, lbTypeCard);
        }

        private void lbSystem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string txt;
                txt = lbSystem.Text;
                txtTypeCard.Text = txt.Substring(0, 2);
                lbSystem.Visible = false;
                txtTypeCard.Focus();
            }
        }

        private void lbTypeCard_KeyDown(object sender, KeyEventArgs e)
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
                lbTypeCard.Visible = false;
                txt.Focus();
            }
        }

        private void txtTypeCard_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
                lbTypeCard.Visible = false;
        }

        private void txtTypeCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
            if (e.KeyCode == Keys.Down)
            {
                if (lbTypeCard.Items.Count > 0)
                {
                    lbTypeCard.SelectedIndex = 0;
                    lbTypeCard.Focus();
                }
                if (rdoAmericanExpress.Checked)
                {
                    lbSystem.SelectedIndex = 0;
                    lbSystem.Focus();
                }
            }
        }

        #endregion //PREDICTIVES

        #region=====Change focus When a Textbox is Full=====

        private void txtYear_TextChanged(object sender, EventArgs e)
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

        private void rdoAmericanExpress_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAmericanExpress.Checked || rdoCreditCard.Checked)
            {
                ShowControls(true);
            }
            else
                ShowControls(false);
        }

        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
            else if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowCreditCard(0);
            btnShow.Visible = false;
        }

        private void ShowCreditCard(int indexControlSelector)
        {
            if (ucFirstValidations.CreditCardsFirstLevel.Count > 0 || ucFirstValidations.CreditCardsSecondLevel.Count > 0)
            {
                frmProfilesCreditCards frm = new frmProfilesCreditCards(ucFirstValidations.CreditCardsFirstLevel, ucFirstValidations.CreditCardsSecondLevel, this.Controls, indexControlSelector);
                frm.ShowDialog();
            }
        }

        private void txtNumberCard_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNumberCard.Text))
            {
                WsMyCTS wsServ = new WsMyCTS();
                string creditCard = wsServ.GetCreditCardNumberCTS(txtNumberCard.Text);
                //string creditCard = GetCreditCardNumberBL.GetCreditCardNumber(txtNumberCard.Text);
                if (!string.IsNullOrEmpty(creditCard))
                {
                    MessageBox.Show("Debes ingresar un número de tarjeta diferente a una de CTS. Reingrese", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberCard.Text = string.Empty;
                }
            }
        }        
    }
}
