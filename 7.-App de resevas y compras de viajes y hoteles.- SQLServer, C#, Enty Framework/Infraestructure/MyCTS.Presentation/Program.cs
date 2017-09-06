using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using MyCTS.Components;
using System.Reflection;
using System.Deployment.Application;
using MyCTS.Presentation.Components;
using System.Configuration;
using System.IO;

namespace MyCTS.Presentation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] Parameters)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-MX");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-MX");
            string[] credentials = null;
            try
            {
                string temp = AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData[0];                
                if(temp.Contains("parameter"))
                {
                    temp = temp.Replace("%22", "");
                    string[] splitTemp = temp.Split(new char[]{'='});
                    if(splitTemp.Length > 1)
                    {
                        credentials = splitTemp[1].Split(new char[] { '_' });
                    }                    
                    Login.ByParameters = true;
                }                
            }
            catch(Exception ex)
            {
                credentials = new string[2];
                credentials[0] = string.Empty;
                credentials[1] = string.Empty;
            }

            try
            {
                EncryptConnectionStrings();
            }
            catch { }
            //Asignacion de parametros de URL
            Parameters = new string[2];
            Parameters[0] = credentials[0];
            Parameters[1] = credentials[1];
            //
            if (!UpdateApp())
            {
                CheckForShortcut();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                if (string.IsNullOrEmpty(Parameters[0]))
                {
                    Application.Run(new frmLogin());
                }
                else
                {
                    frmLogin frm = new frmLogin();
                    frm.WindowState = FormWindowState.Minimized;
                    frm.Visible = false;
                    Login.Firm = Parameters[0];
                    Login.PCC = Parameters[1];
                    Application.Run(frm);
                }
            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            try
            {
                Common.AddMessageToLog(e.Exception);
                try
                {
                    new EventsManager.EventsManager(e.Exception, EventsManager.EventsManager.OrigenError.CapaDePresentacion);
                }
                catch (Exception)
                {
                    new EventsManager.EventsManager(System.Diagnostics.EventLogEntryType.Error, e.Exception);
                }                
            }
            catch { }

            MessageBox.Show("Ha ocurrido un error. El error será notificado para su seguimiento.\n Si se presenta de nuevo por favor contacta a la Mesa de Servicio", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            Loader.AddToPanel(Loader.Zone.Middle, Form.ActiveForm , Resources.Constants.UCWELCOME);
        }

        private static void client_Disconnect()
        {
            int IsDisconnected;
            IsDisconnected = MySabreAPI.clientDisconnect();
        }

        private static void unload_DLL()
        {
            string emuapi = "emuapi";
            int hVal = MySabreAPI.GetModuleHandle(ref emuapi);
            if (hVal != 0)
            {
                while (MySabreAPI.FreeLibrary(hVal))
                { }
            }
        }

        /// <summary>
        /// Verifica si existe una nueva version de la aplicacion a través de ClickOnce
        /// </summary>
        /// <returns>True = Existe nueva version</returns>
        private static bool UpdateApp()
        {
            bool result = false;
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                try
                {
                    ApplicationDeployment updateCheck = ApplicationDeployment.CurrentDeployment;
                    UpdateCheckInfo info = updateCheck.CheckForDetailedUpdate();

                    if (info.UpdateAvailable)
                    {
                        result = true;
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new frmProgressBar());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return result;
        }

        /// <summary>
        /// This will create a Application Reference file on the users desktop
        /// if they do not already have one when the program is loaded.
        /// Check for them running the deployed version before doing this,
        /// so it doesn't kick it when you're running it from Visual Studio.
        /// </summary
        static void CheckForShortcut()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
                if (ad.IsFirstRun)  //first time user has run the app since installation or update
                {
                    Assembly code = Assembly.GetExecutingAssembly();

                    string title = string.Empty;
                    if (Attribute.IsDefined(code, typeof(AssemblyTitleAttribute)))
                    {
                        AssemblyTitleAttribute asmTitle =
                            (AssemblyTitleAttribute)Attribute.GetCustomAttribute(code,
                            typeof(AssemblyTitleAttribute));
                        title = asmTitle.Title;
                    }

                    if (title != string.Empty)
                    {
                        string desktopPath = string.Empty;
                        string shortcutName = string.Empty;

                        desktopPath = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "\\", title, ".appref-ms");
                        shortcutName = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Programs), "\\", title, "\\", title, ".appref-ms");

                        if (!File.Exists(desktopPath))
                        {
                            FileInfo fShortCut = new FileInfo(shortcutName);
                            if (fShortCut.Exists)
                                fShortCut.CopyTo(desktopPath, true);

                            //Si no existe el icono de MyCTS lo coloca en el escritorio y realiza un refresh para mostrarlo
                            MyCTSAPI.RefreshDesktop();
                        }

                        //Copy the fix MyCTS on the programs bar
                        string webBrowserPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                        string nameEXE = System.IO.Path.GetFileName(Application.ExecutablePath);
                        string webBrowserPath_temp = webBrowserPath.Substring(0, webBrowserPath.Length - nameEXE.Length) + "WebBrowser\\UninstallMyCTS.exe";
                        string destino = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Programs), "\\", title, "\\", "UninstallMyCTS.exe");

                        if (File.Exists(destino))
                            File.Delete(destino);

                        System.IO.File.Copy(webBrowserPath_temp, destino, true);
                    }
                }
            }

            #region Old Code
            //if (ApplicationDeployment.IsNetworkDeployed)
            //{
            //    ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
            //    if (ad.IsFirstRun)  //first time user has run the app since installation or update
            //    {
            //        Assembly code = Assembly.GetExecutingAssembly();
            //        string company = string.Empty;
            //        string description = string.Empty;
            //        if (Attribute.IsDefined(code, typeof(AssemblyCompanyAttribute)))
            //        {
            //            AssemblyCompanyAttribute ascompany =
            //                (AssemblyCompanyAttribute)Attribute.GetCustomAttribute(code,
            //                typeof(AssemblyCompanyAttribute));
            //            company = ascompany.Company;
            //        }
            //        if (Attribute.IsDefined(code, typeof(AssemblyDescriptionAttribute)))
            //        {
            //            AssemblyDescriptionAttribute asdescription =
            //                (AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(code,
            //                typeof(AssemblyDescriptionAttribute));
            //            description = asdescription.Description;
            //        }
            //        if (company != string.Empty && description != string.Empty)
            //        {
            //            string desktopPath = string.Empty;
            //            desktopPath = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "\\", description, ".appref-ms");
            //            string shortcutName = string.Empty;
            //            shortcutName = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Programs), "\\", company, "\\", description, ".appref-ms");
            //            //Restart computer
            //            if (System.IO.File.Exists(desktopPath))
            //                MyCTSAPI.Reiniciar();

            //            if (System.IO.File.Exists(shortcutName))
            //                System.IO.File.Copy(shortcutName, desktopPath, true);

            //            //Copy the fix MyCTS on the programs bar
            //            string webBrowserPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            //            string nameEXE = System.IO.Path.GetFileName(Application.ExecutablePath);
            //            string webBrowserPath_temp = webBrowserPath.Substring(0, webBrowserPath.Length - nameEXE.Length) + "WebBrowser\\UninstallMyCTS.exe";
            //            string destino = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Programs), "\\", company, "\\", "UninstallMyCTS.exe");

            //            System.IO.File.Copy(webBrowserPath_temp, destino, true);
            //        }
            //    }
            //}
            #endregion
            
        }

        /// <summary>
        /// Encripta la información que aparece en los appsettings de la aplicacion 
        /// </summary>
        static void EncryptConnectionStrings()
        {
            Configuration config = ConfigurationManager.
                  OpenExeConfiguration
                  (ConfigurationUserLevel.None);
            ConfigurationSection section =
                config.GetSection("connectionStrings");
            if (section != null)
            {
                if (!section.IsReadOnly())
                {
                    if (!section.SectionInformation.IsProtected)
                    {
                        section.SectionInformation.ProtectSection
                       ("DataProtectionConfigurationProvider");
                        section.SectionInformation.
                              ForceSave = true;
                        config.Save(ConfigurationSaveMode.Full);
                    }
                }
            }
        }
    }
}
