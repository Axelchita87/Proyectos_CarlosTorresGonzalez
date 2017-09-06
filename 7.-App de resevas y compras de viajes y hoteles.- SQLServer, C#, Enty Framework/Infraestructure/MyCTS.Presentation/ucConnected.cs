using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Productivity;

namespace MyCTS.Presentation
{
    public partial class ucConnected : CustomUserControl
    {
        public ucConnected()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Determina si el dia es Lunes y muestra el formulario
        /// de Productividad resumen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucConnected_Load(object sender, EventArgs e)
        {
            if (DateTime.Today.DayOfWeek == DayOfWeek.Monday)
            {
                //frmProductivity frmproductivity = new frmProductivity();
                //frmproductivity.ShowDialog();
            }
        }
    }
}

