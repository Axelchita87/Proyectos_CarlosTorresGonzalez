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
    public partial class frmSerchAirLinesFare : Form
    {
        public delegate void AirLinesFareEventHandler(object sender, UpdateEventArgs e);
        public event AirLinesFareEventHandler AirLinesFareUpdate;
        public frmSerchAirLinesFare()
        {
            InitializeComponent();
            ucAvailability.IsInterJetProcess = false;
        }

        private void frmSerchAirLinesFare_Load(object sender, EventArgs e)
        {
            List<AirLinesFare> listAirLinesFare = AirLinesFareBL.GetAirLinesFare();
            bindingSource1.DataSource = listAirLinesFare;

            foreach (AirLinesFare airelineItem in listAirLinesFare)
            {
                ListItem litem = new ListItem();
                litem.Text = string.Format("Algo {0} - {1}", airelineItem.CatAirLinFarName, airelineItem.CatAirLinFarId);
                litem.Value = airelineItem.CatAirLinFarId;
                comboBox1.Items.Add(litem);
            }
        }

        private void dgvCodesAirLines_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AirLinesFare airlinesfare = (AirLinesFare)dgvCodesAirLines.SelectedRows[0].DataBoundItem;
            UpdateEventArgs updateeventargs = new UpdateEventArgs(airlinesfare.CatAirLinFarId);
            AirLinesFareUpdate(this, updateeventargs);
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem item = (ListItem)comboBox1.SelectedItem;
            MessageBox.Show("Valor = " + item.Value + " Texto = " + item.Text);
        }

        private void lblHeader_Click(object sender, EventArgs e)
        {

        }


    }
}
