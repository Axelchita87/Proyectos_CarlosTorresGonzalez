using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Business;
using MyCTS.Entities;


namespace MyCTS.Presentation
{
    public partial class frmSearchCurrencyCode : Form
    {
        public delegate void CurrencyCountryEventHandler(object sender, UpdateEventArgs e);
        public event CurrencyCountryEventHandler CurrencyCountryUpdate;
        private string paramquery;
        private string paramquery2;

        public frmSearchCurrencyCode()
        {
            InitializeComponent();
        }

        #region=====frmSearchCurrencyCode Load=====
        private void frmSearchCurrencyCode_Load(object sender, EventArgs e)
        {
            txtCurrencyNameCountryName.Focus();
            ucAvailability.IsInterJetProcess = false;
        }
        #endregion

        #region=====Load Database Information in dgvCodeCurrency with Search Button Clicked=====
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (rdoCountryCode.Checked)
            {
                paramquery = "Countries.CountryID";
                paramquery2 = "Countries.CountryID";
            }
            else if (rdoCountry.Checked)
            {           
                paramquery = "CountryName";
                paramquery2 = "CountryName";
            }

            else if (rdoCurrencyName.Checked)
            {
                paramquery = "CurrencyName";
                paramquery2 = "CurrencyName";
            }
            List<CurrencyCountry> listCurrencyCountry = CurrencyCountryBL.GetCurrencyCountry(paramquery, paramquery2, txtCurrencyNameCountryName.Text);
            bindingSource1.DataSource = listCurrencyCountry;
        }
        #endregion
        
        #region=====Select an Option from dgvCodeCurrency When Cell is Double Clicked=====
        private void dgvCodeCurrency_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            CurrencyCountry currencyCountry = (CurrencyCountry)dgvCodeCurrency.SelectedRows[0].DataBoundItem;
            UpdateEventArgs updateeventargs = new UpdateEventArgs(currencyCountry.CountryID);
            CurrencyCountryUpdate(this, updateeventargs);
            this.Close();
        }
        #endregion
                
        #region =====Close frmSearchCurrencyCode or Enter Validate=====

        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {

                btnSearch_Click(sender, e);
            }

            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }


        }
        #endregion

        #region =====Accept Text Only=====
        private void Validation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }
        #endregion

        #region=====Change txtCurrencyName MaxLength=====
        private void rdoCountryCode_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCountryCode.Checked == true)
            {
                txtCurrencyNameCountryName.Text = string.Empty;
                txtCurrencyNameCountryName.MaxLength = 2;
            }
        }

        private void rdoCountry_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCountry.Checked)
            {
                txtCurrencyNameCountryName.Text = string.Empty;
                txtCurrencyNameCountryName.MaxLength = 20;
            }
        }

        private void rdoCurrencyName_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCurrencyName.Checked)
            {
                txtCurrencyNameCountryName.Text = string.Empty;
                txtCurrencyNameCountryName.MaxLength = 12;
            }
        }
        #endregion

    }
}

      

        
    

