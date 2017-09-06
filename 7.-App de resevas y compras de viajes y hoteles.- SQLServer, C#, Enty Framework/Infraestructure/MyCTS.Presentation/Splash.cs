using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using MyCTS.Components;
using System.Xml;
using MyCTS.Entities;
using MyCTS.Business;
using System.Collections;
using System.Text.RegularExpressions;
using MyCTS.Presentation.Components;
using System.Configuration;
using Ionic.Zip;

namespace MyCTS.Presentation
{
    public partial class Splash : Form
    {
        private User m_userDto;
        private string m_password;
        private int iTotalArchivos = 1;
        private int iArchivoActual = 1;

        public Splash(User usuarioDto, string password)
        {
            m_userDto = usuarioDto;
            m_password = password;
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            progressBar1.Percentage = 1;
            lblVersion.Text = "Versión: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + " - Junio 02, 2009";
        }

        /// <summary>
        /// Elimina los archivos de la carpeta del usuario (a excepción de los catálogos)
        /// </summary>
        private void DeleteInitialFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(GlobalConstants.PATH_SABRE_USER);
            if (dir.Exists)
            {
                FileInfo[] finfo = dir.GetFiles();
                foreach (FileInfo f in finfo)
                {
                    try
                    {
                        f.Delete();
                    }
                    catch { }
                }
            }
        }

        /// <summary>
        /// Carga los archivos necesarios de configuración de sabre
        /// </summary>
        /// <returns></returns>
        private bool SetSettingsUser()
        {
            if (!Directory.Exists(GlobalConstants.PATH_SABRE_USER))
                Directory.CreateDirectory(GlobalConstants.PATH_SABRE_USER);


            List<GetFilesLocalEntity> lstValores = new List<GetFilesLocalEntity>();

            lstValores.Add(new GetFilesLocalEntity(Environment.GetEnvironmentVariable("WINDIR"), "emuapi.dll", false));
            lstValores.Add(new GetFilesLocalEntity(GlobalConstants.PATH_SABRE_USER, "jniWin.dll", false));
            lstValores.Add(new GetFilesLocalEntity(GlobalConstants.PATH_SABRE_USER, "quickkey.properties", true));
            lstValores.Add(new GetFilesLocalEntity(GlobalConstants.PATH_SABRE_COMPILED, "CREAPNR.SSC", false));
            lstValores.Add(new GetFilesLocalEntity(GlobalConstants.PATH_SABRE_COMPILED, "PASIVOS.SSC", false));
            lstValores.Add(new GetFilesLocalEntity(GlobalConstants.PATH_SABRE_COMPILED, "ACCTKT.SSC", false));
            lstValores.Add(new GetFilesLocalEntity(GlobalConstants.PATH_SABRE_COMPILED, "NAVEGA.SSC", false));

            for (int i = 0; i < lstValores.Count; i++)
            {
                try
                {
                    GetFilesBD(lstValores[i].sPath, lstValores[i].sFileName, lstValores[i].bOverWrite);
                }
                catch (Exception ex)
                {
                }
            }

            //Agregar nuevos archivos SSC
            CopyInitialProperties();

            //Crea directorios temporales
            if (!Directory.Exists(GlobalConstants.QUEUE_FILES))
                Directory.CreateDirectory(GlobalConstants.QUEUE_FILES);
            if (!Directory.Exists(GlobalConstants.TEMP_FILES))
                Directory.CreateDirectory(GlobalConstants.TEMP_FILES);
            else
            {
                //En caso de que exista el directorio mover los archivos existentes a queue
                string[] tempfiles = Directory.GetFiles(GlobalConstants.TEMP_FILES);
                foreach (string f in tempfiles)
                    File.Move(f, GlobalConstants.QUEUE_FILES + "\\" + Path.GetFileName(f));
            }
            return true;
        }

        private void CopyInitialProperties()
        {
            string pathProperties = GlobalConstants.PATH_SABRE_USER + "\\emulator.properties";
            string sourcefile = string.Format(@"{0}\emulator.properties", GlobalConstants.PATH_SABRE_USER);
            string content = string.Empty;

            if (!File.Exists(pathProperties))
            {
                GetFilesBD(GlobalConstants.PATH_SABRE_USER, "emulator.properties", true);
                using (StreamReader sr = new StreamReader(sourcefile, System.Text.Encoding.UTF8))
                {
                    content = sr.ReadToEnd();
                    content = content.Replace("[**AGENT_ID**]", Login.Firm);
                }

                using (StreamWriter sw = new StreamWriter(pathProperties, false, System.Text.Encoding.UTF8))
                {
                    sw.Write(content);
                }
            }
            if (!File.Exists(GlobalConstants.PATH_SABRE_COMPILED + "\\AutomatedHotelPrompt_SP.SSC"))
            {
                List<BannerImage> BannerImageList = GetBannerImageBL.GetBannerImageList("4");
                if (BannerImageList.Count > 0)
                {
                    Byte[] doc = BannerImageList[0].Content;
                    File.WriteAllBytes(GlobalConstants.PATH_SABRE_COMPILED + "\\AutomatedHotelPrompt_SP.SSC", doc);
                }
            }                      
        }

        /// <summary>
        /// Obtiene un archivo de la base de datos y lo crea fisicamente en disco.
        /// </summary>
        /// <param name="strPath">Ruta donde se creara el archivo fisicamente.</param>
        /// <param name="strFileName">Nombre del archivo</param>
        /// <param name="overWrite">True, Si existe el archivo lo sobreescribe.</param>
        private void GetFilesBD(string strPath, string strFileName, bool overWrite)
        {
            string fullFileName = strPath + "\\" + strFileName;

            if (overWrite)
                if (File.Exists(fullFileName))
                    File.Delete(fullFileName);
            else
                if (File.Exists(fullFileName))
                    return;

            Documents item = DocumentsBL.GetSingleDocument(strFileName);

            if (item != null)
            {
                string sFile = item.FileName;
                byte[] buffer = item.Content;

                DirectoryInfo strDirPath = new DirectoryInfo(strPath);
                if (!strDirPath.Exists)
                    strDirPath.Create();

                using (FileStream fs = new FileStream(fullFileName, FileMode.Create))
                {
                    fs.Write(buffer, 0, buffer.Length);
                }
            }
        }

        private void ChangeTurboSABREFile(string strPathTurbo)
        {
            //Move the file and copy
            if (System.IO.File.Exists(strPathTurbo))
            {
                System.IO.File.Delete(strPathTurbo);
            }
        }

        private string GetTAUserMachine(string pathFile)
        {
            string Pathstr = string.Empty;
            if (System.IO.File.Exists(pathFile))
            {
                String pattern = Resources.Constants.TASEARCH;
                Regex regExp = new Regex(pattern, RegexOptions.RightToLeft);
                StreamReader sr = new StreamReader(pathFile);
                String InputFile = sr.ReadToEnd().ToLower();
                sr.Close();
                Match M = regExp.Match(InputFile);
                if (M.Groups[1].Success)
                {
                    Pathstr = M.Groups[1].Value;
                }
            }
            return Pathstr.ToUpper();
        }

        private void LoadMissingCatalogs()
        {
            string pathCatalogs = GlobalConstants.PATH_SABRE_USER + "\\xml";
            DirectoryInfo dir = new DirectoryInfo(pathCatalogs);
            if (!dir.Exists)
                dir.Create();

            string filesToLoad = string.Empty;
            string logicalFileTemp = string.Empty;
            string physicalFileTemp1 = string.Empty;
            List<string> filesNamesToLoad = new List<string>();
            bool isLoaded = false;
            int len = GlobalConstants.FilesDBList.Count;

            //busca los archivos que tenga cargados el usuario en su máquina
            //para cargar solamente aquellos que no tengan o sean versiones anteriores            
            for (int i = 0; i < len; i++)
            {
                logicalFileTemp = GlobalConstants.FilesDBList[i];
                if (string.IsNullOrEmpty(logicalFileTemp))
                    break;
                //elimina la nomenclatura para identificar la version (yyyyMMdd) y guión bajo
                logicalFileTemp = logicalFileTemp.Substring(0, logicalFileTemp.Length - 8);
                FileInfo[] singleFile = dir.GetFiles(logicalFileTemp + "*.xml");

                //si no encuentro el archivo fisicamente en el cliente lo cargo
                foreach (FileInfo f in singleFile)
                {
                    physicalFileTemp1 = f.Name.ToLower().Replace(".xml", string.Empty);
                    logicalFileTemp = GlobalConstants.FilesDBList[i];

                    if (!physicalFileTemp1.Equals(logicalFileTemp))
                    {
                        filesToLoad += "'" + logicalFileTemp + "',";
                        filesNamesToLoad.Add(logicalFileTemp); //guarda el nombre original de la base de datos para escribirlo                        
                        f.Delete();
                    }
                    isLoaded = true;
                }

                if (!isLoaded)
                {
                    logicalFileTemp = GlobalConstants.FilesDBList[i];
                    filesToLoad += "'" + logicalFileTemp + "',";
                    filesNamesToLoad.Add(logicalFileTemp);
                }
                isLoaded = false;
            }

            if (!string.IsNullOrEmpty(filesToLoad))
            {
                filesToLoad += "''";
                ArrayList catalogsCollection = CatalogsBL.GetMissingCatalog(filesToLoad);
                if (catalogsCollection != null)
                {
                    len = catalogsCollection.Count;
                    for (int i = 0; i < len; i++)
                    {
                        List<ListItem> catalogs = catalogsCollection[i] as List<ListItem>;
                        string pathfile = pathCatalogs + "\\" + filesNamesToLoad[i];
                        WriteXMLFile(catalogs, pathfile);
                    }
                }
            }
        }

        private void WriteXMLFile(List<ListItem> list, string fileName)
        {
            fileName = fileName + ".xml";
            using (Stream sr = new FileStream(fileName, System.IO.FileMode.Create))
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.NewLineOnAttributes = true;
                XmlWriter w = XmlWriter.Create(sr, settings);

                w.WriteStartDocument();
                w.WriteStartElement("Catalogs");

                foreach (ListItem li in list)
                {
                    w.WriteStartElement("Object");
                    w.WriteAttributeString("Value", li.Value);
                    w.WriteAttributeString("Text", li.Text);
                    w.WriteAttributeString("Text2", li.Text2);
                    w.WriteAttributeString("Text3", li.Text3);
                    w.WriteAttributeString("Text5", li.Text5);
                    w.WriteAttributeString("Text6", li.Text6);
                    w.WriteAttributeString("Text7", li.Text7);
                    w.WriteAttributeString("Text8", li.Text8);
                    w.WriteEndElement();
                }
                w.WriteEndElement();
                w.WriteEndDocument();
                w.Flush();
            }
        }

        private void LoadControl()
        {
            //Carga el nombre del Splash en caso de que ocurra un 
            //error para registrarlo en el log
            Common.LogApplicationItem.UserControlName = "Splash";

            #region Datos Usuario
            User usuarioDto = m_userDto;
            string password = m_password;
            Login.Firm = usuarioDto.Firm;
            Login.passWord = password;
            Login.PCC = usuarioDto.PCC;
            Login.TA = usuarioDto.TA;
            Login.UserId = usuarioDto.UserId;
            Login.Queue = usuarioDto.Queue;
            Login.Mail = usuarioDto.UserMail;
            Login.NombreCompleto = usuarioDto.FamilyName;
            Login.IsMySabreBlocked = usuarioDto.IsMySabreBlocked;
            Login.Agent = usuarioDto.Agent;
            Login.IsFramework35Installed = usuarioDto.IsFramework35Installed;
            Login.ProfileAllAccess = usuarioDto.ProfileAllAccess;
            Login.ApplicationName = usuarioDto.ApplicationName;
            Login.OrgId = usuarioDto.OrgId;
            UserBL.OrgIdBL = usuarioDto.OrgId;
            Login.Supervisor = usuarioDto.Supervisor;
            Login.UpgradeStatus = usuarioDto.UpgradeStatus;
            //Crear perfil de properties de mySABRE por default
            #endregion


            if (Login.UpgradeStatus.Equals(0) && Login.ByParameters)
            {
                MessageBox.Show("Acción Cancelada. Ejecutar la aplicación MyCTS que se encuentra en el escritorio.");
                CloseApp();
            }
            else if (Login.UpgradeStatus.Equals(0) && !Login.ByParameters)
            {
                GlobalConstants.PATH_SABRE_USER = string.Format(ConfigurationManager.AppSettings["PATH_MYSABRE_USER"] + "{0}", Login.Firm);
                GlobalConstants.PATH_SABRE_COMPILED = ConfigurationManager.AppSettings["PATH_MYSABRE_COMPILED"];
            }
            else if (Login.UpgradeStatus.Equals(2) && !Login.ByParameters)
            {                   
                bool exists = File.Exists(Path.Combine(ConfigurationManager.AppSettings["PATH_SABRERED_USER"], @"Profiles\3L64_1571\mysabre.exe"));
                if (!exists)
                {
                    MessageBox.Show("Su usuario no puede trabajar con la versión instalada en este equipo, se empezara a actualizar a MyCTS2");
                    Login.UpgradeStatus = 1;                                                      
                    UpdateSRW();
                }
            }

            GlobalConstants.PATH_SABRE_USER = ConfigurationManager.AppSettings["PATH_SABRERED_USER"];
            GlobalConstants.PATH_SABRE_COMPILED = ConfigurationManager.AppSettings["PATH_SABRERED_COMPILED"];

            try
            {
                SendMessages("Inicializando . . .");

                Parameters.ServerDateTime = MyCTS.Services.Contracts.Productivity.GetCurrentDateTime();
                Parameters.LocalDateTime = DateTime.Now;     

                //Verifica que el usuario tenga framework 3.5 instalado
                if (usuarioDto.InstallFramework35)
                    SilentInstaller.CheckFrameworkVersion();

                DeleteInitialFiles();
                GlobalConstants.FilesDBList = CatalogsBL.GetCatalogsFileNames();
                try
                {
                    MyCTSAPI.EnabledBrowser(true);
                }
                catch{}

                // Actualizar a SRW
                UpdateSRW();

                //Tiempos de respuesta del API para comandos manuales y comandos extendidos
                try
                {
                    Parameters.CurrentTimeAPINormal = ParameterBL.GetParameterValue("CurrentTimeAPINormal").Values;
                    Parameters.CurrentTimeAPIExtended = ParameterBL.GetParameterValue("CurrentTimeAPIExtended").Values;
                }
                catch
                {
                    Parameters.CurrentTimeAPINormal = "29";
                    Parameters.CurrentTimeAPIExtended = "240";
                }
                Parameters.TimeExtendedAPI = false;
            }
            catch { }

            #region Verificando configuración . . .
 
            string[] driversPath = new string[] { "c:\\", "d:\\" };
            string strPath = string.Empty;
            string strPathTurbo = string.Empty;
            string strTA = null;

            try
            {

                SendMessages("Verificando configuración . . .");
                if (string.IsNullOrEmpty(usuarioDto.TA))
                {

                    Login.IsFirstTime = true;
                    foreach (string myDrive in driversPath)
                    {
                        //Obtener la TA de cada maquina.
                        strPath = myDrive + Resources.Constants.PATH_TA_FILE;
                        strTA = GetTAUserMachine(strPath);
                        usuarioDto.TA = strTA;
                        if (!string.IsNullOrEmpty(strTA)) break;
                    }
                }
                //Update la TA
                UserBL.UpdateUser(usuarioDto.ApplicationId, usuarioDto.UserId, usuarioDto.UserName, usuarioDto.LoweredUserName, usuarioDto.UserMail,
                                        DateTime.Now, usuarioDto.Firm, password, usuarioDto.FamilyName, usuarioDto.Agent, usuarioDto.Queue, usuarioDto.PCC, usuarioDto.TA);

                //Obtiene el profile del usuario.
                Profile profileDto = m_userDto.ProfileUser;

                //Cambiar el nombre del archivo de TurboSABRE
                if (profileDto != null)
                {
                    string bannerText = Common.GetProfileElement("BANNER", profileDto.PropertyNames, profileDto.PropertyValuesString);
                    if (string.IsNullOrEmpty(bannerText))
                        bannerText = Resources.Constants.BANNER_TEXT;
                    Login.BannerText = bannerText;
                    Login.UserProfile = profileDto;

                    if (!profileDto.LastUpdatedDate.Equals(DateTime.MinValue))
                    {
                        foreach (string myDrive in driversPath)
                        {
                            //Obtener la TA de cada maquina.
                            strPathTurbo = myDrive + Resources.Constants.PATH_TURBO_FILE;
                            ChangeTurboSABREFile(strPathTurbo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.AddMessageToLog(ex);
                MessageBox.Show("No ha sido posible verificar la información del perfil, por favor contacte con el área de soporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                CloseApp();
            }
            #endregion

            ActualizaVersionDeMyCTS();

            #region Creando datos del perfil . . .
            SendMessages("Cargando datos del perfil . . .");
            try
            {
                SetSettingsUser();
            }
            catch (Exception ex)
            {
                Common.AddMessageToLog(ex);
                MessageBox.Show("No ha sido posible copiar los archivos de configuración, por favor contacte con el área de soporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                CloseApp();
            }

            #endregion

            #region Cargando archivos de inicio . . .
            SendMessages("Cargando archivos de inicio . . .");
            try
            {
                LoadMissingCatalogs();
            }
            catch (Exception ex)
            {
                Common.AddMessageToLog(ex);
                MessageBox.Show("No ha sido posible descargar la información, por favor contacte con el área de soporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                CloseApp();
            }
            #endregion

            //Obtiene la contraseña para poder ingresar comandos de forma manual
            Parameter parameter = ParameterBL.GetParameterValue("ManualCommands");
            Parameters.PasswordManualCommands = (parameter != null) ? parameter.Values : string.Empty;

            parameter = ParameterBL.GetParameterValue("SecondsLogs");
            Parameters.SecondsLogs = (parameter != null) ? parameter.Values : "60000";

            parameter = ParameterBL.GetParameterValue("NumCommandsToInsertLogs");
            Parameters.NumCommandsToInsertLogs = (parameter != null) ? parameter.Values : "15";

            CloseThisWin();
        }

        private void CloseApp()
        {
            if (this.InvokeRequired)
                this.Invoke(new SenderLoadControl(CloseApp));
            else
            {
                try
                {
                    Application.Exit();
                }
                catch { }
                finally{ }
            }
        }

        private void CloseThisWin()
        {
            if (this.InvokeRequired)
                this.Invoke(new SenderLoadControl(CloseThisWin));
            else
            {
                try
                {
                    frmParent frm = new frmParent();
                    frm.Show();
                    this.Dispose();
                }
                catch { }
                finally { }
            }
        }

        private delegate void SenderLoadControl();
        private void Splash_Shown(object sender, EventArgs e)
        {
            SenderLoadControl slc = new SenderLoadControl(LoadControl);
            slc.BeginInvoke(null, null);
        }

        private delegate void SendMessagesDelegate(string m);
        private void SendMessages(string message)
        {
            if (this.lblStatus.InvokeRequired)
            {
                SendMessagesDelegate smd = new SendMessagesDelegate(SendMessages);
                this.Invoke(smd, new object[] { message });
            }
            else
                this.lblStatus.Text = message;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Percentage = 10; //Set Next Value
            progressBar1.SetProgComplete(progressBar1.Percentage);//Apply!
        }

        /// <summary>
        /// Metodo que sirve para traer los archivos de la instalacion de Sabre Workspace
        /// </summary>
        private void UpdateSRW()
        {
            try
            {
                if (Login.UpgradeStatus == 2)
                {
                    bool exists = File.Exists(Path.Combine(ConfigurationManager.AppSettings["PATH_SABRERED_USER"], @"Profiles\3L64_1571\mysabre.exe"));
                    if(!exists)
                    {          
                        Login.UpgradeStatus = 1;
                    }
                }
                // Validar el estatus de la accion a realizar si es 1 descargar los archivos
                if (Login.UpgradeStatus == 1)
                {
                    CreateSRWFile();
                    // Obtener lista de archivos a descargar
                    List<UpgradeFileSRW> fileList = GetListUpgradeFilesSRWBL.GetListUpgradeFilesSRW();
                    // Si esta marcada la actualizacion descargar los archivos y sobreescribir los existentes  
                    DescargarActualizarSRW(fileList);
                    // Descomprimir archivos
                    SendMessages("Descomprimiendo puede tardar varios minutos. Espere... ");
                    foreach (UpgradeFileSRW t in from t in fileList let fArchivo = new FileInfo(Path.Combine(ConfigurationManager.AppSettings["PATH_SABRERED_USER"], t.NombreDoc)) where fArchivo.Extension == ".zip" || fArchivo.Extension == ".rar" select t)
                    {
                        Descomprimir(Path.Combine(ConfigurationManager.AppSettings["PATH_SABRERED_USER"], t.NombreDoc), ConfigurationManager.AppSettings["PATH_SABRERED_USER"]);
                        break;
                    }
                    // Si fue exitoso eliminar archivos de instalacion
                    LimpiarArchivosInstalacion(fileList);
                    // Cambiar estatus a migrado
                    UpdateCompleteStatusUpgradeBL.UpdateCompleteStatusUpgrade(Login.UserId);
                    SendMessages("Migración completada");
                    if (MessageBox.Show("Actualización finalizada, la aplicación se va a reiniciar.", "Actualización finalizada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                        // Se lanza instalacion de ClicOnce
                        CallSetupMyCTSDos();
                        // Actualiza version de MyCTS
                        ActualizaVersionDeMyCTS();
                        // Se cierra la aplicacion   
                        Environment.Exit(0);
                    }
                }
            }
            catch (Exception ex)
            {
                SendMessages("Problema realizando la actualización . . . ");
            }
        }

        private void CreateSRWFile()
        {
            try
            {
                string pathDirectory = @"C:\Windows";
                DirectoryInfo strDirPath = new DirectoryInfo(pathDirectory);
                if (strDirPath.Exists)
                {
                    string filename = ".sabreredworkspace.locator";
                    FileInfo[] file = strDirPath.GetFiles(filename);
                    if (file.Length.Equals(0))
                    {
                        string fullFileName = string.Concat(pathDirectory, "\\", filename);
                        using (FileStream fs = new FileStream(fullFileName, FileMode.Create))
                        {
                            Documents item = DocumentsBL.GetSingleDocument(filename);
                            byte[] buffer = item.Content;
                            fs.Write(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
            catch { }
        }

        private static void LimpiarArchivosInstalacion(List<UpgradeFileSRW> fileList)
        {
            DirectoryInfo dir = new DirectoryInfo(ConfigurationManager.AppSettings["PATH_SABRERED_USER"]);
            if (!dir.Exists)
                return;

            FileInfo[] finfo = dir.GetFiles();
            foreach (FileInfo f in finfo)
            {
                try
                {
                    FileInfo f1 = f;
                    foreach (UpgradeFileSRW t in fileList.Where(t => f1.Name == t.NombreDoc))
                    {
                        f.Delete();
                    }
                }
                catch
                {
                }
            }
        }

        private void DescargarActualizarSRW(List<UpgradeFileSRW> fileList)
        {
            for (int i = 0; i < fileList.Count; i++)
            {
                SendMessages("Descargando archivo " + (i + 1) + " de " + fileList.Count);
                Documents item = DocumentsBL.GetSingleDocument(fileList[i].NombreDoc);

                if (item == null) continue;
                DirectoryInfo strDirPath = new DirectoryInfo(ConfigurationManager.AppSettings["PATH_SABRERED_USER"]);
                if (!strDirPath.Exists)
                    strDirPath.Create();

                byte[] buffer = item.Content;

                using (
                    FileStream fs =
                        new FileStream(
                            Path.Combine(ConfigurationManager.AppSettings["PATH_SABRERED_USER"], fileList[i].NombreDoc),
                            FileMode.Create))
                {
                    fs.Write(buffer, 0, buffer.Length);
                }
            }
        }

        private void Descomprimir(string sZipFile, string sUnpackDir)
        {
            try
            {
                using (ZipFile zip = ZipFile.Read(sZipFile))
                {
                    zip.ExtractProgress += new EventHandler<ExtractProgressEventArgs>(zip_ExtractProgress);
                    zip.StatusMessageTextWriter = System.Console.Out;

                    foreach (ZipEntry e in zip)
                    {
                        e.Extract(sUnpackDir, ExtractExistingFileAction.OverwriteSilently);
                        SendMessages(String.Format("Descomprimiendo: {0:0.00} %", Math.Round((100.0 / (iTotalArchivos + 1) * iArchivoActual), 2)));
                        iArchivoActual++;
                    }
                }
            }
            catch (Exception ex)
            {
                string error = "";
            }
        }

        void zip_ExtractProgress(object sender, ExtractProgressEventArgs e)
        {
            try
            {
                ZipFile Archivo = (ZipFile)sender;
                iTotalArchivos = Archivo.Entries.Count;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }

        void FindAndCreateIcon()
        {
            try
            {
                string sEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string sAplicacionEnEscritorio = sEscritorio + "\\MyCTS2" + ".lnk";
                string sAplicacionSabreRed = Path.Combine(ConfigurationManager.AppSettings["PATH_SABRERED_USER"],
                                                          @"CTSBridge\MyCTS2.lnk");

                if (File.Exists(sAplicacionEnEscritorio)) return;

                if (!File.Exists(sAplicacionSabreRed))
                {
                    CreateIconFileMyCTS2();
                }

                File.Copy(sAplicacionSabreRed, sAplicacionEnEscritorio);
            }
            catch
            {
                
            }
        }

        private void CreateIconFileMyCTS2()
        {
            try
            {
                string pathDirectory = Path.Combine(ConfigurationManager.AppSettings["PATH_SABRERED_USER"], "CTSBridge");
                DirectoryInfo strDirPath = new DirectoryInfo(pathDirectory);
                if (strDirPath.Exists)
                {
                    string filename = "MyCTS2.lnk";
                    FileInfo[] file = strDirPath.GetFiles(filename);
                    if (file.Length.Equals(0))
                    {
                        string fullFileName = string.Concat(pathDirectory, "\\", filename);
                        using (FileStream fs = new FileStream(fullFileName, FileMode.Create))
                        {
                            Documents item = DocumentsBL.GetSingleDocument(filename);
                            byte[] buffer = item.Content;
                            fs.Write(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
            catch { }
        }

        void ActualizaVersionDeMyCTS()
        {
            try
            {
                //Ingresa el número de versión en la base de datos de cada usuario
                string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();//lblVersion.Text.Substring(8, lblVersion.Text.IndexOf("-") - 8);
                MyCTSVersionBL.SetMyCTSVersion(Login.Firm, Login.PCC, version.Trim());
            }
            catch { }
        }

        void CallSetupMyCTSDos()
        {
            Process p = new Process();
            ProcessStartInfo info = new ProcessStartInfo("IEXPLORE.EXE");
            try
            {                                
                info.Arguments = ConfigurationManager.AppSettings["RutaMyCTSDos"];
                info.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo = info;
                p.Start();
            }
            catch 
            {
                info.Arguments = ConfigurationManager.AppSettings["RutaMyCTSDosDev"];
                info.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo = info;
                p.Start();
            }
        }
    }

    class GetFilesLocalEntity
    {
        public string sPath { get; set; }
        public string sFileName { get; set; }
        public bool bOverWrite { get; set; }

        public GetFilesLocalEntity(string Path, string FileName, bool OverWrite)
        {
            sPath = Path;
            sFileName = FileName;
            bOverWrite = OverWrite;
        }
    }
}
