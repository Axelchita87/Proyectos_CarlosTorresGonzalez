using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
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
    public partial class frmBitacora : Window
    {
        Var v = new Var();
        List<EntGeneralST> gbit;
        public frmBitacora()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
        private void frmMenu_Load(object sender, EventArgs e)
        {
            try
            {
                v.Bitacora = string.Empty;
                gbit = new List<EntGeneralST>();
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
                dgAnt.ItemsSource = null;
                ActDAL da = new ActDAL("dest");
                DataTable dt = da.LeerTabla("bitacora");
                dgAnt.ItemsSource = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            string sql = string.Empty;

            try
            {
                dgNuevo.DataSource = null;
                string conx = ConfigurationManager.ConnectionStrings["cnxDiadest"].ConnectionString;
                MySqlConnection con = new MySqlConnection(conx);
                con.Open();
                if (txtDes.Text == string.Empty)
                    throw new Exception("favor de capturar el texto");
                EntGeneralST g = new EntGeneralST(dtfecha.Value.ToShortDateString(), txtDes.Text);
                sql = "INSERT INTO bitacora VALUES('" + dtfecha.Value.ToString("yyyyMMdd") + "','" + txtDes.Text + "','S','7','N')";
                MySqlCommand com = new MySqlCommand(sql, con);
                com.ExecuteNonQuery();
                v.Bitacora += sql + ";\r\n";
                gbit.Add(g);
                dtfecha.Value = DateTime.Now;
                txtDes.Text = string.Empty;
                dgNuevo.DataSource = gbit;
                com.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            string conx = ConfigurationManager.ConnectionStrings["cnxDiadest"].ConnectionString;
            MySqlConnection con = new MySqlConnection(conx);
            con.Open();
            try
            {


                if (dgAnt.SelectedRows.Count > 0)
                {
                    DataGridViewRow r = dgAnt.SelectedRows[0];
                    string fec = r.Cells[0].Value.ToString();
                    if (fec != string.Empty)
                    {
                        string sql = "Delete from bitacora WHERE fecha='" + Convert.ToDateTime(fec).ToString("yyyyMMdd") + "'";
                        MySqlCommand com = new MySqlCommand(sql, con);
                        com.ExecuteNonQuery();
                        com.Dispose();
                        v.Bitacora += sql + ";\r\n";
                    }
                }

                llenadatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
              
    }
}
