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
    public partial class frmSelTabExcel : Window
    {
        Var v = new Var();
        DataTable dtorg = new DataTable();
        EntTablaHist hist = null;
        public bool esnuevo;
        public bool TieneHist;

        public frmSelTabExcel()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
        private void frmSelTabExcel_Load(object sender, EventArgs e)
        {
            DataTable dt;
            try
            {
                if (v.TbActual == string.Empty)
                    throw new Exception("Nombre de Tabla incorrecto");
                if (esnuevo)
                {
                    ActDAL d = new ActDAL("org");
                    dt = d.LeerTabla(v.TbActual);
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            var bte = v.Tabencript.Where(x => x.Tabla == v.TbActual);
                            if (bte.ToList().Count == 1)
                                dt = Util.decriptTable(dt, bte.ToList().First());
                            dt.TableName = v.TbActual;
                        }

                    }
                }
                else
                {
                    var b = v.Modtables.Where(x => x.TableName == v.TbActual);
                    dt = b.ToList().First();
                }
                dtorg = dt;
                var bhist = v.TabHist.Where(x => x.Tabla == dt.TableName);
                if (bhist.ToList().Count == 1)
                    hist = bhist.ToList().First();

                dgTabla.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtorg != null)
                {
                    if (dtorg.Rows.Count > 0)
                    {
                        dgTabla.DataSource = dtorg;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnImportar_Click(object sender, RoutedEventArgs e)
        {
            string path = string.Empty;
            int colnum;
            try
            {
                if (DialogResult.OK == OpenD.ShowDialog())
                {
                    if (OpenD.OpenFile() != null)
                    {
                        Thread tv = new Thread(new ThreadStart(() =>
                        {
                            try
                            {
                                lblLoad.BeginInvoke(new Action(() =>
                                {
                                    lblLoad.Visible = true;
                                }));

                                path = OpenD.FileName;
                                txtPathExcel.BeginInvoke(new Action(() =>
                                {
                                    txtPathExcel.Text = path;
                                }));

                                ActDAL da = new ActDAL("org");
                                DataTable dt = da.LeerExcel(path);
                                if (hist != null)
                                {
                                    colnum = dt.Columns.Count;
                                    if (dt.Columns[colnum - 1].ColumnName.ToUpper() != "HISTORICO")
                                        throw new Exception("Error en la columna Historico");
                                }
                                dgTabla.BeginInvoke(new Action(() =>
                                {
                                    dgTabla.DataSource = dt;
                                }));

                                lblLoad.BeginInvoke(new Action(() =>
                                {
                                    lblLoad.Visible = false;
                                }));
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }));
                        tv.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            DataTable ddes = new DataTable();
            DataTable nhist = new DataTable();
            try
            {
                ddes = (DataTable)dgTabla.DataSource;
                ddes.TableName = v.TbActual;

                Thread tv = new Thread(new ThreadStart(() =>
                {
                    try
                    {
                        lblLoad.BeginInvoke(new Action(() =>
                        {
                            lblLoad.Visible = true;
                        }));

                        if (ddes != null)
                        {
                            if (dgTabla.Rows.Count > 0)
                            {

                                var bt = v.Tabencript.Where(x => x.Tabla == v.TbActual);
                                if (bt.ToList().Count == 1 && !chklinea.Checked)
                                    ddes = Util.encriptTable(ddes, bt.ToList().First());
                                if (hist != null)
                                {
                                    nhist = dtorg.Copy();
                                    nhist.Clear();
                                    nhist = Util.revisaCamposHist(nhist, hist.TablaHist);
                                    foreach (DataRow r in ddes.Rows)
                                    {
                                        if (r[dgTabla.Columns.Count - 1].ToString().ToUpper() == "S" || r[dgTabla.Columns.Count - 1].ToString().ToUpper() == "BS")
                                        {
                                            DataRow nr = nhist.NewRow();
                                            for (int i = 0; i < dtorg.Columns.Count; i++)
                                            {
                                                nr[i] = r[i];
                                                if (i + 1 == dtorg.Columns.Count)
                                                    nr[i + 1] = DateTime.Now;
                                            }
                                            if (r[dgTabla.Columns.Count - 1].ToString().ToUpper() == "BS")
                                                ddes.Rows.Remove(r);
                                            nhist.Rows.Add(nr);
                                        }
                                        else if (r[dgTabla.Columns.Count - 1].ToString().ToUpper() == "B")
                                            ddes.Rows.Remove(r);
                                    }
                                    nhist.TableName = hist.TablaHist;
                                    if (nhist.Rows.Count > 0)
                                    {
                                        var b = v.Modtables.Where(x => x.TableName == nhist.TableName);
                                        if (b.ToList().Count == 1)
                                        {
                                            DataTable t = b.ToList().First();
                                            t = nhist;
                                        }
                                        else
                                            v.Modtables.Add(nhist);
                                    }
                                }
                                if (ddes.Columns[ddes.Columns.Count - 1].ColumnName.ToUpper() == "HISTORICO")
                                    ddes.Columns.RemoveAt(ddes.Columns.Count - 1);
                                if (!esnuevo)
                                {
                                    var b = v.Modtables.Where(x => x.TableName == v.TbActual);
                                    if (b.ToList().Count == 1)
                                    {
                                        DataTable t = b.ToList().First();
                                        t = ddes;
                                    }
                                }
                                else
                                    v.Modtables.Add(ddes);
                            }
                        }

                        this.BeginInvoke(new Action(() =>
                        {
                            this.Close();
                        }));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));
                tv.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExportar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    Thread t1 = new Thread(new ThreadStart(() =>
                    {
                        lblLoad.BeginInvoke(new Action(() =>
                        {
                            lblLoad.Visible = true;
                        }));
                        string path = saveFile.FileName;
                        ActDAL d = new ActDAL("org");
                        d.ExpExcel(path, (DataTable)dgTabla.DataSource);
                        lblLoad.BeginInvoke(new Action(() =>
                        {
                            lblLoad.Visible = false;
                        }));
                    }));
                    t1.Start();

                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }            
        
    }
}
