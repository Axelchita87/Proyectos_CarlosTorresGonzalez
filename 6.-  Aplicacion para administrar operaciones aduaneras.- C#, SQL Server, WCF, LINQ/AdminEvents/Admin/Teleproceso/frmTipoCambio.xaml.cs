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
    public partial class frmTipoCambio : Window
    {
        public frmTipoCambio()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
        private void frmTipoCambio_Load(object sender, EventArgs e)
        {
            try
            {
                llenadatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void llenadatos()
        {
            try
            {
                srvTipoC.EntTipCam[] lstc;
                srvTipoC.ServTipoCambioClient srv = new srvTipoC.ServTipoCambioClient();
                lstc = srv.GetTipoCambios();
                dgTipoCambio.DataSource = lstc;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            decimal tc = 0;
            try
            {
                if (txttc.Text == string.Empty)
                    throw new Exception("Favor de capturar el tipo de cambio");
                decimal.TryParse(txttc.Text, out tc);
                if (tc == 0)
                    throw new Exception("Valor no valido para tipo de cambio");
                //srvTipoC.EntTipCam ec = new srvTipoC.EntTipCam();
                //ec.fecdia = dtdia.Value;
                //ec.fecdof = dtdof.Value;
                //ec.tipocambio = tc;
                string t = "0|" + dtdof.Value.ToShortDateString() + "|" + tc.ToString() + "|" + dtdia.Value.ToShortDateString();
                t = Util.encript(t);
                srvAct.DIASrvClient srv = new srvAct.DIASrvClient();
                srv.InsTipoCambio(t);
                txttc.Text = string.Empty;
                dtdof.Value = dtdia.Value = DateTime.Now;
                llenadatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSuprimir_Click(object sender, RoutedEventArgs e)
        {

        }   
        
    }
}
