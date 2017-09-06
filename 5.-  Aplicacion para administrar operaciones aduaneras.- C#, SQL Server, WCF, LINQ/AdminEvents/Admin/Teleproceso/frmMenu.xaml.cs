using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration;
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
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        List<EntGeneralST> lsta = new List<EntGeneralST>();
        string paq, ctrl;
        List<EntGeneralST> scripts;
        public FileStream fs;
        string mergeFolder;
        List<string> Packets = new List<string>();
        string SaveFileFolder = @"c:\";

        public Menu()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                base.DragMove();
            }
            catch (Exception ex)
            {
                //Var.MenError.ShowM(ex);
            }
        }       

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                limpiadatos();
                lsta = new List<EntGeneralST>();
                btnSubir.IsEnabled = false;
                paq = string.Empty;
                ctrl = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void limpiadatos()
        {
            try
            {
                Var v = new Var();
                v.Modtables = new List<DataTable>();
                v.TbActual = string.Empty;
                dgTablas.ItemsSource = null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void frmMenu_Load(object sender, EventArgs e)
        {
            List<EntGeneral> lst = new List<EntGeneral>();
            try
            {
                string st = Util.encript("31/12/2016");
                ActDAL d = new ActDAL("org");
                Var v = new Var();
                lst = d.LeerTablas();
                v.Tables = lst;
                v.Modtables = new List<DataTable>();
                paq = string.Empty;
                ctrl = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAgrTabla_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                frmTipoTabla v = new frmTipoTabla();
                v.ShowDialog();
                ActGridTablas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuaTabla_Click(object sender, RoutedEventArgs e)
        {
            Var v = new Var();
            ActDAL d = new ActDAL("dest");
            string s = string.Empty;
            try
            {
                if (scripts == null)
                    scripts = new List<EntGeneralST>();
                d.begTran();
                foreach (DataTable dt in v.Modtables)
                {
                    s = string.Empty;
                    if (!d.ActTabla(dt, out s))
                        throw new Exception("Fallo de act de tabla" + dt.TableName);
                    else
                        scripts.Add(new EntGeneralST(dt.TableName, s));
                }
                d.commit();
                MessageBox.Show("Tablas correctamente Actualizadas");
            }
            catch (Exception ex)
            {
                scripts = new List<EntGeneralST>();
                d.roll_back();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                d.close();
            }
        }
        public void ArmaPaquete()
        {
            string path, pathg, arch, arch2, zipf, archctrl, swc, ver, tipo;
            path = pathg = arch2 = zipf = archctrl = swc = ver = tipo = string.Empty;
            Var v = new Var();
            try
            {
                ver = "0";
                if (txtVersion.Text != string.Empty)
                    ver = txtVersion.Text;
                path = ConfigurationManager.AppSettings["pathbase"].ToString();
                pathg = ConfigurationManager.AppSettings["pathdest"].ToString();
                zipf = pathg + txtNombreNum.Text + ".DIA";
                //archctrl = Application.StartupPath + "\\temp\\" + txtnombre.Text + txtNum.Text + ".ctrl";
                archctrl = pathg + txtNombreNum.Text + ".ctrl";
                if (File.Exists(archctrl))
                    File.Delete(archctrl);
                if (File.Exists(zipf))
                    File.Delete(zipf);
                StreamWriter sw = new StreamWriter(archctrl);
                swc = txtNombreNum.Text.Substring(4) + ";";
                var bb = scripts.Where(x => x.Id == "bitacora");
                if (bb.ToList().Count == 1)
                {
                    arch = pathg + "bitacora.sw7";
                    StreamWriter sws = new StreamWriter(arch);
                    //sw.Write(Util.encript(b.ToList().First().Descripcion));
                    sws.Write(bb.ToList().First().Descripcion);
                    sws.Close();
                    sws.Dispose();
                    swc += "bitacora.sw7|sw7|1;";
                    ComprimeArchivo(zipf, arch);
                }
                foreach (DataTable dt in v.Modtables)
                {
                    //arch = path + dt.TableName+".frm";
                    //arch2 = path + dt.TableName + ".ibd";
                    //if (File.Exists(arch) && File.Exists(arch2))
                    //{
                    //    ComprimeArchivo(zipf, arch);
                    //    swc+= dt.TableName + ".frm|DIADB|1;";
                    //    ComprimeArchivo(zipf, arch2);
                    //    swc+=dt.TableName + ".ibd|DIADB|1;";
                    //}
                    arch = pathg + dt.TableName + ".sw7";
                    var b = scripts.Where(x => x.Id == dt.TableName);
                    if (b.ToList().Count == 0)
                        throw new Exception("Error al buscar scripts");
                    StreamWriter sws = new StreamWriter(arch);
                    //sw.Write(Util.encript(b.ToList().First().Descripcion));
                    sws.Write(b.ToList().First().Descripcion);
                    sws.Close();
                    sws.Dispose();
                    swc += dt.TableName + ".sw7|sw7|1;";
                    ComprimeArchivo(zipf, arch);
                }
                foreach (EntGeneralST f in lsta)
                {
                    if (File.Exists(f.Descripcion))
                    {
                        //tipo = "|DIA|";
                        //if (!f.Id.ToUpper().Contains(".DLL") || !f.Id.ToUpper().Contains(".EXE") || !f.Id.ToUpper().Contains(".CONFIG"))
                        //    tipo = "|TEMP|";

                        if (f.Id.ToUpper().Contains(".DLL") || f.Id.ToUpper().Contains(".EXE") || f.Id.ToUpper().Contains(".CONFIG") || f.Id.ToUpper().Contains(".exe"))
                        {
                            tipo = "|DIA|";
                            swc += f.Id + tipo + ver + ";";
                        }
                        else if (f.Id.ToUpper().Contains(".SW7"))
                        {
                            swc += f.Id + "|sw7|1;";
                        }
                        else
                        {
                            tipo = "|TEMP|";
                            swc += f.Id + tipo + ver + ";";
                        }

                        ComprimeArchivo(zipf, f.Descripcion);
                        //swc+= f.Id+ tipo +ver+";";
                    }
                }
                swc = swc.Substring(0, swc.Length - 1);
                sw.WriteLine(swc);
                sw.Close();
                ctrl = swc;
                ComprimeArchivo(zipf, archctrl);
                paq = zipf;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ComprimeArchivo(string zipfile, string arch)
        {

            try
            {
                FileStream zipstr;
                ZipArchive archzip;
                if (!File.Exists(zipfile))
                {
                    zipstr = new FileStream(zipfile, FileMode.Create);
                    archzip = new ZipArchive(zipstr, ZipArchiveMode.Create);
                }
                else
                {
                    zipstr = new FileStream(zipfile, FileMode.Open);
                    archzip = new ZipArchive(zipstr, ZipArchiveMode.Update);
                }
                FileInfo fa = new FileInfo(arch);
                FileStream fsa = fa.OpenRead();
                ZipArchiveEntry ea = archzip.CreateEntry(fa.Name);
                Stream stra = ea.Open();
                fsa.CopyTo(stra);
                stra.Close();
                fsa.Close();
                archzip.Dispose();
                zipstr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ActGridTablas()
        {
            Var v = new Var();
            try
            {
                List<String> lstBusq = new List<String>();
                DataTable dt = new DataTable();
                dt.Columns.Add("nombre", typeof(string));
                if (v.Modtables.Count > 0)
                {
                    foreach (DataTable t in v.Modtables)
                        dt.Rows.Add(t.TableName);
                }
                dgTablas.DataContext = dt;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            string nserv = string.Empty;
            try
            {
                if (txtNombreNum.Text == string.Empty)
                    throw new Exception("Favor de capturar el nombre del archivo");
                if (lsta.Count() > 0)
                {
                    var ba = lsta.Where(x => x.Descripcion.ToLower().Contains(".dll") || x.Descripcion.ToLower().Contains(".exe"));
                    if (ba.ToList().Count > 0 && txtVersion.Text == string.Empty)
                        throw new Exception("Favor de capturar la Version");
                }
                //nserv = ConfigurationManager.AppSettings["serv"].ToString();
                //ServiceController smysql = new ServiceController(nserv);
                //smysql.Stop();
                //smysql.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromMilliseconds(25000));
                ArmaPaquete();
                btnSubir.IsEnabled = true;
                //smysql.Start();
                //smysql.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromMilliseconds(25000));
                MessageBox.Show("Paquete creado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdiTabla_Click(object sender, RoutedEventArgs e)
        {
            string t = string.Empty;
            try
            {
                //if (dgTablas.SelectedRows.Count == 1)
                //{
                //    DataGridViewRow r = dgTablas.SelectedRows[0];


                // //   Entidad ent =(enbtidad) dgTablas.selecteditem();
                //    t = r.Cells[0].Value.ToString();
                //    Var v = new Var();
                //    v.TbActual = t;
                //    frmActTablas ve = new frmActTablas();
                //    ve.esnuevo = false;
                //    ve.ShowDialog();
                //}
                if (dgTablas.SelectedItems.Count == 1)
                {
                 //   DataGridRow r = dgTablas.SelectedRows[0];
                 //   DataGridRow r = dgTablas.Items[0];
                   // object r = dgTablas.Items[0];
                  //  dgTablas.SelectedItem = r;
                    //DataGridRow row = dgTablas.ItemContainerGenerator.ContainerFromIndex(0);
                    DataGridRow row = (DataGridRow)dgTablas.ItemContainerGenerator
                                               .ContainerFromIndex(0);
                    DataRow r = (DataRow)row.DataContext;
                    t = r[0].ToString();
                    Var v = new Var();
                    v.TbActual = t;
                    frmActTablas ve = new frmActTablas();
                    ve.esnuevo = false;
                    ve.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliTabla_Click(object sender, RoutedEventArgs e)
        {
            string t = string.Empty;
            try
            {
                Var v = new Var();

                if (dgTablas.SelectedItems.Count == 1)
                {
                    DataGridRow row = (DataGridRow)dgTablas.ItemContainerGenerator
                                              .ContainerFromIndex(0);
                    DataRow r = (DataRow)row.DataContext;
                    t = r[0].ToString();
                    var b = v.Modtables.Where(x => x.TableName == t);
                    if (b.ToList().Count == 1)
                    {
                        DataTable dt = b.ToList().First();
                        v.Modtables.Remove(dt);
                        ActGridTablas();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAgrArch_Click(object sender, RoutedEventArgs e)
        {
            List<EntGeneralST> la = new List<EntGeneralST>();
            try
            {
                OfdArchivos.Multiselect = true;
                OfdArchivos.ShowDialog();
                if (OfdArchivos.FileNames.Count() > 0)
                {
                    la = new List<EntGeneralST>();
                    foreach (string f in OfdArchivos.FileNames)
                    {
                        EntGeneralST g = new EntGeneralST(f.Substring(f.LastIndexOf('\\') + 1, f.Length - f.LastIndexOf('\\') - 1), f);
                        la.Add(g);
                    }
                    foreach (EntGeneralST a in la)
                        lsta.Add(a);
                    refrestListaArch();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
                
        private void btnEliArch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lstArch.SelectedItem != null)
                {
                    lsta.Remove((EntGeneralST)lstArch.SelectedItem);
                    refrestListaArch();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void refrestListaArch()
        {
            try
            {
                lstArch.DataSource = null;
                lstArch.DataSource = lsta;
                lstArch.ValueMember = "Descripcion";
                lstArch.DisplayMember = "Id";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSubir_Click(object sender, RoutedEventArgs e)
        {
            int prod = 0;
            byte[] arch = null;
            string[] ftp;
            try
            {
                ftp = ConfigurationManager.AppSettings["ftpserv"].Split('|');
                //if (rdProd.Checked)
                //    prod = 1;
                //srvAct.DIASrvClient srv = new srvAct.DIASrvClient();
                //if (prod == 0)
                //{
                //    srv.Endpoint.Address = new System.ServiceModel.EndpointAddress(ConfigurationManager.AppSettings["preprod"]);
                //}
                //else 
                //{
                //    srv.Endpoint.Address = new System.ServiceModel.EndpointAddress(ConfigurationManager.AppSettings["prod"]);
                //}

                //srv.Open();
                if (txtNum.Text == string.Empty)
                    throw new Exception("Favor de Capturar el numero de Actualizacion");
                if (txtVersion.Text == string.Empty)
                    throw new Exception("Favor de Capturar La version de DIA");
                if (paq == string.Empty)
                {
                    string path = ConfigurationManager.AppSettings["pathdest"].ToString();
                    paq = path + txtnombre.Text + txtNum.Text + ".DIA";
                    if (ctrl == string.Empty && File.Exists(path + txtnombre.Text + txtNum.Text + ".ctrl"))
                    {
                        StreamReader sr = new StreamReader(path + txtnombre.Text + txtNum.Text + ".ctrl");
                        ctrl = sr.ReadToEnd();
                        sr.Close();
                        ctrl = ctrl.Replace("\r\n", string.Empty);
                    }
                }
                if (ctrl == string.Empty || !File.Exists(paq))
                    throw new Exception("Favor de Armar el paquete");
                arch = File.ReadAllBytes(paq);

                //Conexion a la BD
                string Conexion = ConfigurationManager.ConnectionStrings["cnxDirecta"].ConnectionString;

                using (var conn = new SqlConnection(Conexion))
                {

                    conn.Open();
                    string sql = "insert into DIAAct (Id,version,ctrl,Archivo,fecha,nomArch) values(@Id, @version, @ctrl, @Archivo, @fecha, @nomArch)";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        var param = cmd.Parameters.AddWithValue("Id", Convert.ToInt32(txtNum.Text));
                        param.DbType = DbType.Int32;

                        param = cmd.Parameters.AddWithValue("version", txtVersion.Text);
                        param.DbType = DbType.String;

                        param = cmd.Parameters.AddWithValue("ctrl", ctrl);
                        param.DbType = DbType.String;

                        param = cmd.Parameters.AddWithValue("Archivo", arch);
                        param.DbType = DbType.Binary;

                        param = cmd.Parameters.AddWithValue("fecha", DateTime.Now);
                        param.DbType = DbType.DateTime;

                        param = cmd.Parameters.AddWithValue("nomArch", Path.GetFileName(paq));
                        param.DbType = DbType.String;

                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                }

                //Conexion a la BD Respaldo
                string ConexionR = ConfigurationManager.ConnectionStrings["cnxDirectaR"].ConnectionString;

                using (var connR = new SqlConnection(ConexionR))
                {

                    connR.Open();
                    string sql = "insert into DIAAct (Id,version,ctrl,Archivo,fecha,nomArch) values(@Id, @version, @ctrl, @Archivo, @fecha, @nomArch)";
                    using (var cmdR = new SqlCommand(sql, connR))
                    {
                        var param = cmdR.Parameters.AddWithValue("Id", Convert.ToInt32(txtNum.Text));
                        param.DbType = DbType.Int32;

                        param = cmdR.Parameters.AddWithValue("version", txtVersion.Text);
                        param.DbType = DbType.String;

                        param = cmdR.Parameters.AddWithValue("ctrl", ctrl);
                        param.DbType = DbType.String;

                        param = cmdR.Parameters.AddWithValue("Archivo", arch);
                        param.DbType = DbType.Binary;

                        param = cmdR.Parameters.AddWithValue("fecha", DateTime.Now);
                        param.DbType = DbType.DateTime;

                        param = cmdR.Parameters.AddWithValue("nomArch", Path.GetFileName(paq));
                        param.DbType = DbType.String;

                        cmdR.ExecuteNonQuery();
                    }

                    connR.Close();
                }


                //string res=srv.subeAct("admin", "Acceso123", Convert.ToInt32(txtNum.Text), txtVersion.Text, ctrl, arch, Path.GetFileName(paq));

                //int res=srvd.InsUpdSDIServ(Convert.ToInt32(txtNum.Text), txtVersion.Text, ctrl, arch, Path.GetFileName(paq));
                //if (res != string.Empty)
                //    throw new Exception("Error en la comunicacion con el server de Actualizacion");
                //FTP
                //if (prod==1)
                //    SDIServDAL.FFTP(ftp[0], ftp[2],ftp[3],Convert.ToInt32(ftp[1]), "DIA", paq);
                MessageBox.Show("Paquete Cargado con exito al Servicio de Actualizacion");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtNombreNum_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string num = txtNombreNum.Text.Substring(4);
                string nom = txtNombreNum.Text.Substring(0,4);
                if (num != string.Empty && txtVersion.Text != string.Empty && nom != string.Empty)
                {
                    if (File.Exists("C:\\temp\\" + txtNombreNum.Text + ".DIA") && File.Exists("C:\\temp\\" + nom + num + ".ctrl"))
                    {
                        StreamReader sr = new StreamReader("C:\\temp\\" + nom + num + ".ctrl");
                        ctrl = sr.ReadToEnd();
                        sr.Close();
                        btnSubir.IsEnabled = true;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



    }
}
