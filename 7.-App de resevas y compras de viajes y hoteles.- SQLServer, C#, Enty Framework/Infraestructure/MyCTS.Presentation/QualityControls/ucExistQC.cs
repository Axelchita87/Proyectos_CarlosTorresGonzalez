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
    public partial class ucExistQC : CustomUserControl
    {
        public ucExistQC()
        {
            InitializeComponent();
        }

        //Extrae la lista de los Quality Controls Existentes
        private void ucExistQC_Load(object sender, EventArgs e)
        {
            //List<QCExist> list = QCExistBL.GetQCExist();
            //if (list.Count > 0)
            //{
            //    dataGridView1.DataSource = list;
            //}
            ucAvailability.IsInterJetProcess = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.ColumnCount = 2;

            dataGridView1.Columns[0].Name = "QCDescription";
            dataGridView1.Columns[1].Name = "QCLabel";

            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.Automatic;

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;


            dataGridView1.Columns["QCDescription"].HeaderText = "QCDescription";
            dataGridView1.Columns["QCLabel"].HeaderText = "QCLabel";

            List<QCExist> list = QCExistBL.GetQCExist();

            foreach (QCExist item in list)
            {
                if (string.IsNullOrEmpty(item.QCLabel))
                    item.QCLabel = "Null";

                dataGridView1.Rows.Add(new object[] { item.QCDescription, item.QCLabel });
            }  
        }

        //KeyDown
        /// <summary>
        /// Este se usa para todos los controles en general si se oprime 
        /// Esc se manda a el User control de Welcome 
        /// Enter se manda la accion de botón de Aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }
    }
}
