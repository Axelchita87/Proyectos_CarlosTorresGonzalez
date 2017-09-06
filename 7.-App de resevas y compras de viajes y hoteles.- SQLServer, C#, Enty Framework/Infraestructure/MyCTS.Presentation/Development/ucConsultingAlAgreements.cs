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
    public partial class ucConsultingAlAgreements : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Consulta los datos de AirLinesAgreements en la BdD
        /// Creación:     10-06-10 , 
        /// Cambio:      * , Solicito *
        /// Autor:       Jessica Gutierrez
        /// </summary>
        
        public ucConsultingAlAgreements()
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
        private void ucConsultingAlAgreements_Load(object sender, EventArgs e)
        {
            dataGridView1.MultiSelect = false;
            dataGridView1.ColumnCount = 5;

            // Set the properties of the DataGridView columns.
            dataGridView1.Columns[0].Name = "IDAlCode";
            dataGridView1.Columns[1].Name = "InternationalComission";
            dataGridView1.Columns[2].Name = "DomesticComission";
            dataGridView1.Columns[3].Name = "TourCode";
            dataGridView1.Columns[4].Name = "OSI";
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.Automatic;

            dataGridView1.ColumnHeadersHeightSizeMode =
            DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            dataGridView1.Columns["IDAlCode"].HeaderText = "IDAlCode";
            dataGridView1.Columns["InternationalComission"].HeaderText = "InternationalComission";
            dataGridView1.Columns["DomesticComission"].HeaderText = "DomesticComission";
            dataGridView1.Columns["TourCode"].HeaderText = "TourCode";
            dataGridView1.Columns["OSI"].HeaderText = "OSI";

            List<ALAgreements> list = ALAgreementsBL.ALAgreements();

            foreach (ALAgreements item in list)
            {
                if (string.IsNullOrEmpty(item.TourCode))
                    item.TourCode = "Null";
                if (string.IsNullOrEmpty(item.OSI))
                    item.OSI = "Null";
                dataGridView1.Rows.Add(new object[] { item.IDAlCode, item.InternationalComission, item.DomesticComission, item.TourCode, item.OSI});
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
