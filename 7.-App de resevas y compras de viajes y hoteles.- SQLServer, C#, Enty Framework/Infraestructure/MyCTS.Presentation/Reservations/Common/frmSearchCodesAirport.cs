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
    public partial class frmSearchCodesAirport : Form

    {
        public delegate void CodesAirportEventHandler(object sender, UpdateEventArgs e);
        public event CodesAirportEventHandler CodesAirportUpdate;
        // checar nombre de variable
        private string paramquery;
        private string paramquery2;

        public frmSearchCodesAirport()
        {
            InitializeComponent();
            ucAvailability.IsInterJetProcess = false;
        }

        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (rdoCity.Checked)
            {
                paramquery = "CityName";
                paramquery2 = "CityName";
            }
            else
            {
                paramquery = "CountryName";
                paramquery2 = "CountryName";
            }

            List<AirportCodes> listAirportCodes = AirportCodesBL.GetAirportCodes(paramquery, paramquery2, txtCityNameCountryName.Text);
           
            bindingSource1.DataSource = listAirportCodes;
            
        }

        //Grid Select
        private void dgvCodesAirport_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AirportCodes airporCodes = (AirportCodes)dgvCodesAirport.SelectedRows[0].DataBoundItem;
            UpdateEventArgs updateeventargs = new UpdateEventArgs(airporCodes.CityID);
            CodesAirportUpdate(this, updateeventargs);
            this.Close();
        }

        #region ===== Cambios de color al obtener el foco =====

        private void txtCityNameCountryName_Enter(object sender, EventArgs e)
        {
            txtCityNameCountryName.BackColor = Color.Beige;
        }

        private void txtCityNameCountryName_Leave(object sender, EventArgs e)
        {
            txtCityNameCountryName.BackColor = Color.White;
        }

        

        #endregion

        private void txtCityNameCountryName_TextChanged(object sender, EventArgs e)
        {

        }
          #region =====Regresar al UserControl anterior o valida Enter=====

        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {

                btnSearch_Click(sender, e);
            }


        }
        #endregion

        private void txtCodeAirLineNameAirline_TextChanged(object sender, EventArgs e)
        {

        }

   
        
    }
}



    
