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
using System.Threading;
using System.Configuration;
using System.ComponentModel;
using System.Globalization;
using System.IO;

namespace ADMIN2
{
    /// <summary>
    /// Lógica de interacción para Splash.xaml
    /// </summary>
    public partial class Splash : Window
    {
        int confini;
        //Var VarGlob = new Var();
        avisosis messageBox = new avisosis();
        List<string> archtot = new List<string>();
        public Splash()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Thread.CurrentThread.CurrentCulture.Name == "en-US")
            {
                CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture("es-MX");
                CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.CreateSpecificCulture("es-MX");
            }

            confini = Convert.ToInt32(ConfigurationManager.AppSettings["ConfIni"].ToString());
            if (confini == 0)
            {
                this.Hide();
                //frmConfIniSql v = new frmConfIniSql();
                //v.ShowDialog();
                //App.Current.Shutdown();
            }
            else
            {
                if (ConfigurationManager.AppSettings["Bloqueo"] == "1")
                {
                    messageBox = new avisosis("En este momento algún usuario está actualizando el sistema. No es posible iniciar SITA, espere unos minutos y vuelva a intentarlo.", "Actualizando...", MessageBoxButton.OK, MessageBoxImage.Warning); messageBox.ShowDialog();
                    App.Current.Shutdown();
                }

                //if (System.IO.File.Exists(Environment.CurrentDirectory + "\\proxy.sw8"))
                //{
                //    VarGlob.Ipproxy = ConfigurationManager.AppSettings["ProxyIP"];
                //    VarGlob.Portproxy = ConfigurationManager.AppSettings["ProxyPort"];
                //    VarGlob.Domainproxy = ConfigurationManager.AppSettings["ProxyDomain"];
                //    VarGlob.Userproxy = ConfigurationManager.AppSettings["ProxyUser"];
                //    VarGlob.Passproxy = ConfigurationManager.AppSettings["ProxyPass"];
                //}

                //#region Elimina archivos de control de usuario no utilizados
                //if (!System.IO.Directory.Exists(Environment.CurrentDirectory + "\\USU"))
                //{
                //    System.IO.Directory.CreateDirectory(Environment.CurrentDirectory + "\\USU");
                //}

                //string RutaUsu = Environment.CurrentDirectory + "\\USU";
                //string[] archd = Directory.GetFiles(RutaUsu);
                //archtot = archd.Where(x => x.ToUpper().Contains(".USU")).OrderBy(x => x).ToList();
                
                //int UsuCon = 0;
                ////Recorriendo los archivos de control de usuario
                //foreach (string act in archtot)
                //{
                //    string NomArch = System.IO.Path.GetFileName(act);

                //    try
                //    {
                //       System.IO.File.Delete(RutaUsu + "\\" + NomArch);
                //    }
                //    catch (System.IO.IOException k)
                //    {
                //        UsuCon++;
                //    }
                //}

                ////Recorriendo los archivos de permisos de Cuenta de Gastos
                //archtot = archd.Where(x => x.ToUpper().Contains(".CTA")).OrderBy(x => x).ToList();                
                //foreach (string act in archtot)
                //{
                //    string NomArch = System.IO.Path.GetFileName(act);

                //    try
                //    {
                //        System.IO.File.Delete(RutaUsu + "\\" + NomArch);
                //    }
                //    catch (System.IO.IOException k)
                //    {
                //        UsuCon++;
                //    }                
                //}
                ////string ruta = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                ////Configuration confi = ConfigurationManager.OpenExeConfiguration(ruta + "\\SITA.exe");
                ////confi.AppSettings.Settings["PermisoCtaGtos"].Value = "0";
                ////confi.Save();

                //#endregion


                BackgroundWorker bc = new BackgroundWorker();
                bc.DoWork += Cargaventanas;
                bc.RunWorkerCompleted += CargaVenCompleted;
                bc.RunWorkerAsync();
            }
        }

        private void Cargaventanas(object sender, DoWorkEventArgs e)
        {

            try
            {
                Thread.Sleep(1000);
            }
            catch (Exception)
            {
                //Var.MenError.ShowM(ex);
            }
        }

        private void CargaVenCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                MainWindow m = new MainWindow();
                //ADMIN2.Configuración.FrmPerfiles m = new ADMIN2.Configuración.FrmPerfiles();                
                m.Show();
                this.Close();
            }
            catch (Exception)
            {
                //Var.MenError.ShowM(ex);
            }
        }

    }
}
