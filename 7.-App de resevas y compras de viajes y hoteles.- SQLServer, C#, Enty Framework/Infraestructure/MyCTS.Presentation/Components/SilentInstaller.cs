using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Net;
using Microsoft.Win32;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace MyCTS.Presentation
{
    public class SilentInstaller
    {
        private static string dotnetfx35setup = "dotnetfx35setup";
        /// <summary>
        /// Obtiene la ruta temporal de descarga del archivo setup
        /// del framework
        /// </summary>
        private static string PathSetupFile
        {
            get
            {
                string tempFolder = System.IO.Path.GetTempPath();
                return string.Concat(tempFolder, dotnetfx35setup, ".exe");
            }
        }

        /// <summary>
        /// Verifica la version del framwork que tiene el usuario
        /// </summary>
        public static void CheckFrameworkVersion()
        {
            if (!IsFrameworkInstalled())
            {
                if (File.Exists(PathSetupFile))
                {
                    string pName = string.Empty;

                    Process[] process = Process.GetProcessesByName(dotnetfx35setup);

                    if (!(process.Length > 0))
                    {
                        ProcessStartInfo info = new ProcessStartInfo();
                        info.Arguments = "/q /norestart";
                        info.FileName = PathSetupFile;
                        Process.Start(info);
                    }
                }
                else
                {
                    WebClient webClient = new WebClient();
                    webClient.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(webClient_DownloadFileCompleted);
                    webClient.DownloadFileAsync(new Uri("http://201.149.13.14:5498/MyCTS/dotnetfx35setup.exe"), PathSetupFile);
                }
            }
        }

        static void webClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (File.Exists(PathSetupFile))
            {
                string pName = string.Empty;

                Process[] process = Process.GetProcessesByName(dotnetfx35setup);

                if (!(process.Length > 0))
                {
                    ProcessStartInfo info = new ProcessStartInfo();
                    info.Arguments = "/q /norestart";
                    info.FileName = PathSetupFile;
                    Process.Start(info);
                }
            }
        }

        /// <summary>
        /// Actualiza en base de datos que el usuario tiene instalada
        /// la version 3.5 SP1 del framework
        /// </summary>
        private static void UpdateVersionFramework()
        {
            //Si la maquina del usuario ya tiene framework instalado no es necesario actualizar en base de datos el status
            if (Login.IsFramework35Installed)
                return;

            string sql = @"update users 
                          set IsFramework35Installed = {0} 
                          where firm = '{1}' and pcc = '{2}'";

            sql = string.Format(sql, 1, Login.Firm, Login.PCC);
            SqlConnection oConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCTSSecurityDB"].ConnectionString);
            SqlCommand oCmd = new SqlCommand(sql, oConn);

            try
            {
                oConn.Open();
                oCmd.ExecuteNonQuery();
            }
            catch
            { }
            finally
            {
                if (oConn.State == System.Data.ConnectionState.Open)
                    oConn.Close();
            }
        }

        /// <summary>
        /// Verifica en el registro de windows que tenga instalado
        /// framework 3.5 SP1
        /// </summary>
        /// <returns></returns>
        private static bool IsFrameworkInstalled()
        {
            string version = string.Empty;
            string servicePack = string.Empty;
            const string name = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v3.5";

            RegistryKey subKey = null;
            try
            {
                subKey = Registry.LocalMachine.OpenSubKey(name);
            }
            catch { }

            try
            {
                version = subKey.GetValue("Version").ToString();
            }
            catch { }

            try
            {
                servicePack = subKey.GetValue("SP").ToString();
            }
            catch { }

            if (string.IsNullOrEmpty(version) && string.IsNullOrEmpty(servicePack))
            {
                return false;
            }
            else
            {
                UpdateVersionFramework();
            }

            return true;
        }
    }
}
