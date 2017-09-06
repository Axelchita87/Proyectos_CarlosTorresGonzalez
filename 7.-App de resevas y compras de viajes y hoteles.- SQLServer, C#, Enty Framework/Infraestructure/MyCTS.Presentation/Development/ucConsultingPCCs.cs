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
    public partial class ucConsultingPCCs : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Consulta los datos de PCCs en la BdD
        /// Creación:    10-06-10 , 
        /// Cambio:      * , Solicito *
        /// Autor:       Jessica Gutierrez
        /// </summary>
        public ucConsultingPCCs()
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
        private void ucConsultingPCCs_Load(object sender, EventArgs e)
        {
            dataGridView1.MultiSelect = false;
            dataGridView1.ColumnCount = 15;

            dataGridView1.Columns[0].Name = "CatPccId";
            dataGridView1.Columns[1].Name = "CatPccName";
            dataGridView1.Columns[2].Name = "Status";
            dataGridView1.Columns[3].Name = "StandardClass";
            dataGridView1.Columns[4].Name = "SpecificClass";
            dataGridView1.Columns[5].Name = "Confirmation";
            dataGridView1.Columns[6].Name = "BusinessClass1";
            dataGridView1.Columns[7].Name = "BusinessClass2";
            dataGridView1.Columns[8].Name = "BusinessClass3";
            dataGridView1.Columns[9].Name = "BusinessClass4";
            dataGridView1.Columns[10].Name = "TYPE";
            dataGridView1.Columns[11].Name = "Tool";
            dataGridView1.Columns[12].Name = "GDS";
            dataGridView1.Columns[13].Name = "ActiveDate";
            dataGridView1.Columns[14].Name = "InactiveDate";


            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns[5].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns[6].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns[7].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns[8].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns[9].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns[10].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns[11].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns[12].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns[13].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns[14].SortMode = DataGridViewColumnSortMode.Automatic;

            dataGridView1.ColumnHeadersHeightSizeMode = 
            DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            dataGridView1.Columns["CatPccId"].HeaderText = "CatPccId";
            dataGridView1.Columns["CatPccName"].HeaderText = "CatPccName";
            dataGridView1.Columns["Status"].HeaderText = "Status";
            dataGridView1.Columns["StandardClass"].HeaderText = "StandardClass";
            dataGridView1.Columns["SpecificClass"].HeaderText = "SpecificClass";
            dataGridView1.Columns["Confirmation"].HeaderText = "Confirmation";
            dataGridView1.Columns["BusinessClass1"].HeaderText = "BusinessClass1";
            dataGridView1.Columns["BusinessClass2"].HeaderText = "BusinessClass2";
            dataGridView1.Columns["BusinessClass3"].HeaderText = "BusinessClass3";
            dataGridView1.Columns["BusinessClass4"].HeaderText = "BusinessClass4";
            dataGridView1.Columns["Type"].HeaderText = "Type";
            dataGridView1.Columns["Tool"].HeaderText = "Tool";
            dataGridView1.Columns["GDS"].HeaderText = "GDS";
            dataGridView1.Columns["ActiveDate"].HeaderText = "ActiveDate";
           // dataGridView1.Columns["InactiveDate"].HeaderText = "InactiveDate";


            List<AllPCCsComplet> list = AllPCCsCompletBL.GetAllPCCsComplet(Login.OrgId);

            foreach (AllPCCsComplet item in list)
            {
                if (string.IsNullOrEmpty(item.Status))
                    item.Status = "Null";
                if (string.IsNullOrEmpty(item.StandardClass))
                    item.StandardClass = "Null";
                if (string.IsNullOrEmpty(item.SpecificClass))
                    item.SpecificClass = "Null";
                if (string.IsNullOrEmpty(item.Confirmation))
                    item.Confirmation = "Null";
                if (string.IsNullOrEmpty(item.BusinessClass1))
                    item.BusinessClass1 = "Null";
                if (string.IsNullOrEmpty(item.BusinessClass2))
                    item.BusinessClass2 = "Null";
                if (string.IsNullOrEmpty(item.BusinessClass3))
                    item.BusinessClass3 = "Null";
                if (string.IsNullOrEmpty(item.BusinessClass4))
                    item.BusinessClass4 = "Null";
                if (string.IsNullOrEmpty(item.Type))
                    item.Type = "Null";
                if (string.IsNullOrEmpty(item.Tool))
                    item.Tool = "Null";
                if (string.IsNullOrEmpty(item.GDS))
                    item.GDS = "Null";
                
                //if (string .IsNullOrEmpty(item.ActiveDate))
                //    item.ActiveDate = "Null";

                //if (string.IsNullOrEmpty(item.InactiveDate))
                        item.InactiveDate = "Null";
               
                

                dataGridView1.Rows.Add(new object[] { item.CatPccId, item.CatPccName, item.Status, 
                 item.StandardClass, item.SpecificClass, item.Confirmation, item.BusinessClass1, 
                 item.BusinessClass2,item.BusinessClass3,item.BusinessClass4, item.Type, item.Tool,
                 item.GDS, item.ActiveDate,item.InactiveDate});
                 //, item.ActiveDate, item.InactiveDate 
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
