using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using System.ComponentModel;

namespace MyCTS.Presentation
{
    public partial class ucConsultingAirLinesFare : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Consulta los datos de AirLinesFare en la BdD
        /// Creación:    Diciembre 10-06-10 , 
        /// Cambio:      Codigo manual para ordenar filas   , Solicito Memo
        /// Autor:       Jessica Gutierrez
        /// </summary>
        
        public ucConsultingAirLinesFare()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  Se definen las columnas, los nombres y el orden automatico
        ///  Se les asigna el Texto de cabecera, se extrae la lista con los datos
        ///  de la BD y se hace el llenado del DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucConsultingAirLinesFare_Load(object sender, EventArgs e)
        {
            dataGridView1.MultiSelect = false;
            dataGridView1.ColumnCount = 7;

            // Set the properties of the DataGridView columns.
            dataGridView1.Columns[0].Name = "CatAirLinFarId";
            dataGridView1.Columns[1].Name = "CatAirLinFarName";
            dataGridView1.Columns[2].Name = "CCAut";
            dataGridView1.Columns[3].Name = "CCMan";
            dataGridView1.Columns[4].Name = "Cash";
            dataGridView1.Columns[5].Name = "PMix";
            dataGridView1.Columns[6].Name = "Misc";
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns[5].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns[6].SortMode = DataGridViewColumnSortMode.Automatic;

            dataGridView1.ColumnHeadersHeightSizeMode =
            DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            dataGridView1.Columns["CatAirLinFarId"].HeaderText = "CatAirLinFarId";
            dataGridView1.Columns["CatAirLinFarName"].HeaderText = "CatAirLinFarName";
            dataGridView1.Columns["CCAut"].HeaderText = "CCAut";
            dataGridView1.Columns["CCMan"].HeaderText = "CCMan";
            dataGridView1.Columns["Cash"].HeaderText = "Cash";
            dataGridView1.Columns["PMix"].HeaderText = "PMix";
            dataGridView1.Columns["Misc"].HeaderText = "Misc";

            List<AirLinesFare> list = AirLinesFareBL.GetAirLinesFare();

            foreach (AirLinesFare item in list)
            {
                dataGridView1.Rows.Add(new object[] { item.CatAirLinFarId, item.CatAirLinFarName, item.CCAut, item.CCMan, item.Cash, item.PMix, item.Misc });
            }          
        }

        //Valida si la tecla presionada es Esc y manda a llamar el UCWELCOME
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }
                
    }
}
