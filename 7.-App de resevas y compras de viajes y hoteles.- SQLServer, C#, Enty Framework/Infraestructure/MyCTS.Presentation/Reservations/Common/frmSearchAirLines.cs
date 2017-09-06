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
    public partial class frmSearchAirLines : Form
    {
        public delegate void AirlineEventHandler(object sender, UpdateEventArgs e);
        public event AirlineEventHandler AirlineUpdate;
        private string paramquery;
        private string paramquery2;

        public frmSearchAirLines()
        {
            InitializeComponent();
        }

        #region=====frmSearchAirlines Load=====
        private void frmSearchAirLines_Load(object sender, EventArgs e)
        {
            rdoNameAerLine.Focus();
        }
        #endregion

        #region=====Load Database Information in dgvCodesAirlines with Search Button Clicked=====
        private void button2_Click(object sender, EventArgs e)
        {
            if (rdoCodeAirLine.Checked)
            {
                paramquery = "AirlineAlfaID";
                paramquery2 = "AirlineAlfaID";
            }
            else
            {
                paramquery = "AirlineName";
                paramquery2 = "AirlineName";
            }

            List<AirLines> listAirLines = AirLinesBL.GetAirLinesCodesAll(paramquery, paramquery2, txtCodeAirLineNameAirline.Text);

            bindingSource1.DataSource = listAirLines;
        }
        #endregion

        #region=====Select an Option from dgvCodeCurrency When Cell is Double Clicked=====
        private void dgvCodesAirLines_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AirLines airline = (AirLines)dgvCodesAirLines.SelectedRows[0].DataBoundItem;
            UpdateEventArgs updateeventargs = new UpdateEventArgs(airline.AirlineAlfaID);
            AirlineUpdate(this, updateeventargs);
            this.Close();
        }
        #endregion

        #region =====Close frmSearchAirlines or Enter Validate=====

        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {

                button2_Click(sender, e);
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
            
    }
}
