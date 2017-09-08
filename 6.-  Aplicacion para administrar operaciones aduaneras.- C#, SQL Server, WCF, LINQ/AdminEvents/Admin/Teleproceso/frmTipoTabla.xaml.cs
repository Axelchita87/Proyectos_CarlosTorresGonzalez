using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AdminEvents.Admin.Teleproceso
{
    /// <summary>
    /// Lógica de interacción para frmTablas.xaml
    /// </summary>
    public partial class frmTipoTabla : Window
    {
        Var v = new Var();
        public frmTipoTabla()
        {
            InitializeComponent();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
        private void frmSelTabExcel_Load(object sender, EventArgs e)
        {

            try
            {
                v.TbActual = string.Empty;
                if (v.Tables.Count == 0)
                    throw new Exception("Error al leer tablas");
                cmboTablas.DataSource = v.Tables;
                cmboTablas.DisplayMember = "Descripcion";
                cmboTablas.ValueMember = "Id";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAceps_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmboTablas.SelectedIndex < 0)
                    throw new Exception("Favor de seleccionar una tabla");
                v.TbActual = ((EntGeneral)cmboTablas.SelectedItem).Descripcion;
                if (rdGrid.Checked)
                {
                    frmActTablas at = new frmActTablas();
                    at.esnuevo = true;
                    at.ShowDialog();
                }
                else
                {
                    frmActTablaExcel at = new frmActTablaExcel();
                    at.esnuevo = true;
                    at.ShowDialog();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
                
    }
}
