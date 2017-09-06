using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Services.Contracts;
using MyCTS.Presentation.Components;
using MyCTS.Entities;
using MyCTS.Services.ValidateDKsAndCreditCards;

namespace MyCTS.Presentation
{
    public partial class frmGenericFOPCTS : Form
    {
        private int indexTypeControl = 0;
        private string paxPossition = string.Empty;
        List<ListItem> listFOP = new List<ListItem>();
        WsMyCTS wsServ = new WsMyCTS();

        public frmGenericFOPCTS(int frmIndexTypeControl, string frmPaxPossition)
        {
            InitializeComponent();
            indexTypeControl = frmIndexTypeControl;
            paxPossition = frmPaxPossition;
        }
                                
        private void frmGenericFOPCTS_Load(object sender, EventArgs e)
        {
            switch (indexTypeControl)
            {
                case 0:
                    this.Text = "MyCTS-Forma de Pago del Cliente a CTS";
                    break;
                case 1:
                    this.Text = "MyCTS-Forma de Pago para Cargo por Servicio";
                    break;
            }
            LoadFormPaymentCodes();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidateBusinessRules)
            {
                if (indexTypeControl.Equals(0))
                {
                    BuildRemarkFOPCTS();
                }
                else if (indexTypeControl.Equals(1))
                {
                    BuildRmkChargePerServiceByPax();
                }
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Methods  Class

        private void ShowCreditCard(int indexControlSelector)
        {
            if (ucFirstValidations.CreditCardsFirstLevel.Count > 0 || ucFirstValidations.CreditCardsSecondLevel.Count > 0)
            {
                frmProfilesCreditCards frm = new frmProfilesCreditCards(ucFirstValidations.CreditCardsFirstLevel, ucFirstValidations.CreditCardsSecondLevel, this.Controls, indexControlSelector);
                frm.ShowDialog();
            }
        }

        private bool IsValidateBusinessRules
        {
            get
            {                
                if (cmbTypeCard.SelectedIndex.Equals(0))                          
                {
                    MessageBox.Show("Requiere ingresar forma de pago del cliente a CTS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbTypeCard.Focus();
                    return false;
                }
                else if ((((ListItem)cmbTypeCard.SelectedItem).Value.Equals("TR") ||
                    ((ListItem)cmbTypeCard.SelectedItem).Value.Equals("CH")) && txtNumberCardCTS.Text.Length != 4)
                {
                    MessageBox.Show("El número de la tarjeta debe ser de 4 digitos. Reingrese", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberCardCTS.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtNumberCardCTS.Text)
                    && !((ListItem)cmbTypeCard.SelectedItem).Value.Equals("CASH"))
                {
                    MessageBox.Show("Requiere ingresar número de tarjeta o cuenta del cliente a CTS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberCardCTS.Focus();
                    return false;
                }
                else
                    return true;                
            }

        }

        private void BuildRemarkFOPCTS()
        {
            //string codeCTS = string.Empty;
            //switch (cmbTypeCard.SelectedValue.ToString())
            //{
            //    case "AX":
            //        codeCTS = "CCAC";
            //        break;
            //    case "CA":
            //        codeCTS = "CCPV";
            //        break;
            //    case "VI":
            //        codeCTS = "CCPV";
            //        break;
            //    case "TP":
            //        codeCTS = "CCTC";
            //        break;
            //     case "TR":
            //        codeCTS = "TR";
            //        break;
            //     case "CH":
            //        codeCTS = "CH";
            //        break;
            //    default:
            //        codeCTS = cmbTypeCard.SelectedValue.ToString();
            //        break;

            //}
            if (((ListItem)cmbTypeCard.SelectedItem).Value.Equals("CASH"))
            {
                ucFormPayment.C28 = string.Format("{0}-{1}", Resources.TicketEmission.ValitationLabels.CTS,
                   listFOP[cmbTypeCard.SelectedIndex  - 1].Text2);
            }
            else
            {
                ucFormPayment.C28 = string.Format("{0}-{1}-{2}", Resources.TicketEmission.ValitationLabels.CTS,
                    listFOP[cmbTypeCard.SelectedIndex - 1].Text2,
                    txtNumberCardCTS.Text);
            }
        }

        private void BuildRmkChargePerServiceByPax()
        {
            string remark = string.Format( "-{0}-{1}/>",
                    listFOP[cmbTypeCard.SelectedIndex - 1].Text2,                    
                    txtNumberCardCTS.Text);
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

        #endregion

        #region Manejo de controles para forma de pago

        private void btnShowCTS_Click(object sender, EventArgs e)
        {
            ShowCreditCard(1);
            btnShowCTS.Visible = false;
        }

        //private void txtCardTypeCTS_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txt2 = (TextBox)sender;
        //    lbFormaPagoCTS.BringToFront();
        //    Common.SetListBoxFormPaymentCTS(txt2, lbFormaPagoCTS);

        //}

        //private void lbFormaPagoCTS_KeyDown(object sender, KeyEventArgs e)
        //{
        //    ListBox ListBox = (ListBox)sender;
        //    TextBox txt = (TextBox)txtTypeCardCTS;
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        ListItem li = (ListItem)ListBox.SelectedItem;
        //        txt.Text = li.Value;
        ////        lbFormaPagoCTS.Visible = false;
        //        txt.Focus();
        //    }
        //}

        //private void lbFormaPagoCTS_MouseClick(object sender, MouseEventArgs e)
        //{
        //    ListBox listBox = (ListBox)sender;
        //    TextBox txt = (TextBox)txtTypeCardCTS;
        //    ListItem li = (ListItem)listBox.SelectedItem;
        //    txt.Text = li.Value;
        //    lbFormaPagoCTS.Visible = false;
        //    txt.Focus();
        //}

        //private void txtCardTypeCTS_KeyDown(object sender, KeyEventArgs e)
        //{            
        //    if (e.KeyData == Keys.Enter)
        //    {
        //        btnAccept_Click(sender, e);
        //    }
        //    else if (e.KeyCode == Keys.Down)
        //    {
        //        if (lbFormaPagoCTS.Items.Count > 0)
        //        {
        //            lbFormaPagoCTS.SelectedIndex = 0;
        //            lbFormaPagoCTS.Focus();
        //        }
        //    }
        //}

        //private void txtCardTypeCTS_Leave(object sender, EventArgs e)
        //{
        //    if (txtTypeCardCTS.Text.Equals("CA"))
        //    {
        //        txtNumberCardCTS.Text = string.Empty;
        //        txtNumberCardCTS.Visible = false;
        //        lblCardNumberCTS.Visible = false;
        //        btnShow.Visible = false;
        //    }
        //    else if (txtTypeCardCTS.Text.Equals("TR") || txtTypeCardCTS.Text.Equals("CH"))
        //    {
        //        btnShow.Visible = false;
        //        txtNumberCardCTS.MaxLength = 4;
        //        lblCardNumberCTS.Text = "Número de cuenta";
        //        OracleConnection oracle = new OracleConnection();
        //        txtNumberCardCTS.Text = oracle.GetTranferCheckNumber(ucFirstValidations.dk);
        //    }
        //    else
        //    {
        //        btnShow.Visible = true;
        //        lblCardNumberCTS.Text = "Número de tarjeta";
        //        txtNumberCardCTS.Visible = true;
        //        txtNumberCardCTS.MaxLength = 16;
        //    }
        //}

        private void txtCardNumberCTS_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNumberCardCTS.Text))
                {
                    string creditCard = wsServ.GetCreditCardNumberCTS(txtNumberCardCTS.Text);
                    //string creditCard = GetCreditCardNumberBL.GetCreditCardNumber(txtNumberCardCTS.Text);
                    if (!string.IsNullOrEmpty(creditCard))
                    {
                        MessageBox.Show("Debes ingresar un número de tarjeta diferente a una de CTS. Reingrese", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNumberCardCTS.Text = string.Empty;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al validar tarjeta. Reintente");
                txtNumberCardCTS.Text = string.Empty;
            }
        }

        private void LoadFormPaymentCodes()
        {
            listFOP = CatCreditCardsCodesBL.GetFOPCTSList();            

            foreach (ListItem  FOPItem in listFOP)
            {
                ListItem litem = new ListItem();
                litem.Text = string.Format("{0} - {1}",
                    FOPItem.Value,
                    FOPItem.Text);
                litem.Value = FOPItem.Value;
                litem.Text2 = FOPItem.Text2;
                cmbTypeCard.Items.Add(litem);

            }
            cmbTypeCard.SelectedIndex = 0;
        }
        #endregion

        private void cmbTypeCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTypeCard.SelectedIndex > 0)
            {
                txtNumberCardCTS.PasswordChar = new char();
                txtNumberCardCTS.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular);
                ListItem item = (ListItem)cmbTypeCard.SelectedItem;
                if (item.Value.Equals("CASH"))
                {
                    txtNumberCardCTS.Text = string.Empty;
                    txtNumberCardCTS.Visible = false;
                    lblCardNumberCTS.Visible = false;
                    btnShowCTS.Visible = false;
                }
                else if (item.Value.Equals("TR") || item.Value.Equals("CH"))
                {
                    btnShowCTS.Visible = false;
                    txtNumberCardCTS.MaxLength = 4;
                    lblCardNumberCTS.Text = "Número de cuenta";
                    lblCardNumberCTS.Visible = true;
                    MyCTS.Services.ValidateDKsAndCreditCards.GetTranferCheckNumber data = new MyCTS.Services.ValidateDKsAndCreditCards.GetTranferCheckNumber();
                    data = wsServ.GetTranferCheckNumberMyCTS(ucFirstValidations.DK);
                    txtNumberCardCTS.Text = data.ct_banc_cbr;
                    txtNumberCardCTS.Visible = true;
                    txtNumberCardCTS.PasswordChar = '·';
                    txtNumberCardCTS.Font = new Font("Symbol", 9F, FontStyle.Regular);
                }
                else
                {
                    btnShowCTS.Visible = true;
                    lblCardNumberCTS.Text = "Número de tarjeta";
                    txtNumberCardCTS.Visible = true;
                    lblCardNumberCTS.Visible = true;
                    txtNumberCardCTS.MaxLength = 16;
                    txtNumberCardCTS.PasswordChar = '·';
                    txtNumberCardCTS.Font = new Font("Symbol", 9F, FontStyle.Regular);
                }
            }
        }

        private void cmbTypeCard_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyData == Keys.Enter)
             {
                 btnAccept_Click(sender, e);
             }             
        }
                
    }
}
