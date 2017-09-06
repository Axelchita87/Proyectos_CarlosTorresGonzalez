using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Configuration;

namespace MyCTS.Components
{
    public class MyCTSAPI
    {
        [DllImport("User32")]
        private static extern int ShowWindow(int hwnd, int nCmdShow);

        [DllImport("User32")]
        private static extern bool ShowWindow(IntPtr hWnd, Int32 nCmdShow);

        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        [DllImport("User32.Dll")]
        private static extern void GetWindowText(int hWnd, StringBuilder str, int nMaxCount);

        [DllImport("User32.dll", EntryPoint = "SetForegroundWindow")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("User32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string strClassName, string strWindowName);

        [DllImport("user32.dll")]
        private static extern int GetWindowThreadProcessId(IntPtr hWnd, out int ProcessId);

        private static string usuario;

        public static string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private static string pwd;

        public static string Pwd
        {
            get { return pwd; }
            set { pwd = value; }
        }

        private static string pcc;

        public static string PCC
        {
            get { return pcc; }
            set { pcc = value; }
        }


        //SW_HIDE             0
        //SW_SHOWNORMAL       1
        //SW_NORMAL           1
        //SW_SHOWMINIMIZED    2
        //SW_SHOWMAXIMIZED    3
        //SW_MAXIMIZE         3
        //SW_SHOWNOACTIVATE   4
        //SW_SHOW             5
        //SW_MINIMIZE         6
        //SW_SHOWMINNOACTIVE  7
        //SW_SHOWNA           8
        //SW_RESTORE          9
        //SW_SHOWDEFAULT      10
        //SW_FORCEMINIMIZE    11
        //SW_MAX              11

        private const int SW_HIDE = 0;
        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOW = 5;
        private const int SW_RESTORE = 9;

        #region Refresh Desktop

        [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);

        [Flags]
        public enum ShellChangeNotificationEvents : uint
        {
            SHCNE_RENAMEITEM = 0x00000001,	// The name of a nonfolder item has changed. SHCNF_IDLIST or 
            // SHCNF_PATH must be specified in uFlags. dwItem1 contains the 
            // previous PIDL or name of the item. dwItem2 contains the new PIDL
            // or name of the item. 
            SHCNE_CREATE = 0x00000002,	// A nonfolder item has been created. SHCNF_IDLIST or SHCNF_PATH 
            // must be specified in uFlags. dwItem1 contains the item that was 
            // created. dwItem2 is not used and should be NULL. 
            SHCNE_DELETE = 0x00000004,	// A nonfolder item has been deleted. SHCNF_IDLIST or SHCNF_PATH
            // must be specified in uFlags. dwItem1 contains the item that was 
            // deleted. dwItem2 is not used and should be NULL. 
            SHCNE_MKDIR = 0x00000008,	// A folder has been created. SHCNF_IDLIST or SHCNF_PATH must be 
            // specified in uFlags. dwItem1 contains the folder that was 
            // created. dwItem2 is not used and should be NULL. 
            SHCNE_RMDIR = 0x00000010,	// A folder has been removed. SHCNF_IDLIST or SHCNF_PATH must be 
            // specified in uFlags. dwItem1 contains the folder that was 
            // removed. dwItem2 is not used and should be NULL. 
            SHCNE_MEDIAINSERTED = 0x00000020,	// Storage media has been inserted into a drive. SHCNF_IDLIST or
            // SHCNF_PATH must be specified in uFlags. dwItem1 contains the root
            // of the drive that contains the new media. dwItem2 is not used 
            // and should be NULL. 
            SHCNE_MEDIAREMOVED = 0x00000040,	// Storage media has been removed from a drive. SHCNF_IDLIST or 
            // SHCNF_PATH must be specified in uFlags. dwItem1 contains the root
            // of the drive from which the media was removed. dwItem2 is not 
            // used and should be NULL. 
            SHCNE_DRIVEREMOVED = 0x00000080,	// A drive has been removed. SHCNF_IDLIST or SHCNF_PATH must be 
            // specified in uFlags. dwItem1 contains the root of the drive that
            // was removed. dwItem2 is not used and should be NULL. 
            SHCNE_DRIVEADD = 0x00000100,	// A drive has been added. SHCNF_IDLIST or SHCNF_PATH must be 
            // specified in uFlags. dwItem1 contains the root of the drive that
            // was added. dwItem2 is not used and should be NULL. 
            SHCNE_NETSHARE = 0x00000200,	// A folder on the local computer is being shared via the network.
            // SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. dwItem1
            // contains the folder that is being shared. dwItem2 is not used and
            // should be NULL. 
            SHCNE_NETUNSHARE = 0x00000400,	// A folder on the local computer is no longer being shared via the
            // network. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. 
            // dwItem1 contains the folder that is no longer being shared. 
            // dwItem2 is not used and should be NULL. 
            SHCNE_ATTRIBUTES = 0x00000800,	// The attributes of an item or folder have changed. SHCNF_IDLIST
            // or SHCNF_PATH must be specified in uFlags. dwItem1 contains the
            // item or folder that has changed. dwItem2 is not used and should
            // be NULL. 
            SHCNE_UPDATEDIR = 0x00001000,	// The contents of an existing folder have changed, but the folder
            // still exists and has not been renamed. SHCNF_IDLIST or SHCNF_PATH
            // must be specified in uFlags. dwItem1 contains the folder that 
            // has changed. dwItem2 is not used and should be NULL. If a folder
            // has been created, deleted, or renamed, use SHCNE_MKDIR, 
            // SHCNE_RMDIR, or SHCNE_RENAMEFOLDER, respectively, instead. 
            SHCNE_UPDATEITEM = 0x00002000,	// An existing nonfolder item has changed, but the item still exists
            // and has not been renamed. SHCNF_IDLIST or SHCNF_PATH must be 
            // specified in uFlags. dwItem1 contains the item that has changed.
            // dwItem2 is not used and should be NULL. If a nonfolder item has 
            // been created, deleted, or renamed, use SHCNE_CREATE, 
            // SHCNE_DELETE, or SHCNE_RENAMEITEM, respectively, instead. 
            SHCNE_SERVERDISCONNECT = 0x00004000,	// The computer has disconnected from a server. SHCNF_IDLIST or 
            // SHCNF_PATH must be specified in uFlags. dwItem1 contains the 
            // server from which the computer was disconnected. dwItem2 is not
            // used and should be NULL.
            SHCNE_UPDATEIMAGE = 0x00008000,	// An image in the system image list has changed. SHCNF_DWORD must be 
            // specified in uFlags. dwItem1 contains the index in the system image 
            // list that has changed. dwItem2 is not used and should be NULL. 
            SHCNE_DRIVEADDGUI = 0x00010000,	// A drive has been added and the Shell should create a new window
            // for the drive. SHCNF_IDLIST or SHCNF_PATH must be specified in 
            // uFlags. dwItem1 contains the root of the drive that was added. 
            // dwItem2 is not used and should be NULL. 
            SHCNE_RENAMEFOLDER = 0x00020000,	// The name of a folder has changed. SHCNF_IDLIST or SHCNF_PATH must
            // be specified in uFlags. dwItem1 contains the previous pointer to
            // an item identifier list (PIDL) or name of the folder. dwItem2 
            // contains the new PIDL or name of the folder. 
            SHCNE_FREESPACE = 0x00040000,	// The amount of free space on a drive has changed. SHCNF_IDLIST or
            // SHCNF_PATH must be specified in uFlags. dwItem1 contains the root
            // of the drive on which the free space changed. dwItem2 is not used
            // and should be NULL. 
            SHCNE_EXTENDED_EVENT = 0x04000000,	// Not currently used. 
            SHCNE_ASSOCCHANGED = 0x08000000,	// A file type association has changed. SHCNF_IDLIST must be 
            // specified in the uFlags parameter. dwItem1 and dwItem2 are not
            // used and must be NULL. 
            SHCNE_DISKEVENTS = 0x0002381F,	// Specifies a combination of all of the disk event identifiers. 
            SHCNE_GLOBALEVENTS = 0x0C0581E0,	// Specifies a combination of all of the global event identifiers. 
            SHCNE_ALLEVENTS = 0x7FFFFFFF,	// All events have occurred. 
            SHCNE_INTERRUPT = 0x80000000	// The specified event occurred as a result of a system interrupt.
            // As this value modifies other event values, it cannot be used alone.
        }

        public enum ShellChangeNotificationFlags
        {
            SHCNF_IDLIST = 0x0000,	// dwItem1 and dwItem2 are the addresses of ITEMIDLIST structures that
            // represent the item(s) affected by the change. Each ITEMIDLIST must be 
            // relative to the desktop folder. 
            SHCNF_PATHA = 0x0001,	// dwItem1 and dwItem2 are the addresses of null-terminated strings of 
            // maximum length MAX_PATH that contain the full path names of the items 
            // affected by the change. 
            SHCNF_PRINTERA = 0x0002,	// dwItem1 and dwItem2 are the addresses of null-terminated strings that 
            // represent the friendly names of the printer(s) affected by the change. 
            SHCNF_DWORD = 0x0003,	// The dwItem1 and dwItem2 parameters are DWORD values. 
            SHCNF_PATHW = 0x0005,	// like SHCNF_PATHA but unicode string
            SHCNF_PRINTERW = 0x0006,	// like SHCNF_PRINTERA but unicode string
            SHCNF_TYPE = 0x00FF,
            SHCNF_FLUSH = 0x1000,	// The function should not return until the notification has been delivered 
            // to all affected components. As this flag modifies other data-type flags,
            // it cannot by used by itself.
            SHCNF_FLUSHNOWAIT = 0x2000	// The function should begin delivering notifications to all affected 
            // components but should return as soon as the notification process has
            // begun. As this flag modifies other data-type flags, it cannot by used 
            // by itself.
        }

        #endregion

        /// <summary>
        /// Actualiza el escritorio simulando F5
        /// </summary>
        public static void RefreshDesktop()
        {
            SHChangeNotify((uint)ShellChangeNotificationEvents.SHCNE_ASSOCCHANGED,
                                (uint)ShellChangeNotificationFlags.SHCNF_IDLIST,
                                IntPtr.Zero,
                                IntPtr.Zero);
        }
        /// <summary>
        /// Minimiza ventana por medio de su ID de proceso
        /// </summary>
        /// <param name="processID">Id de proceso</param>
        public static void MinimizeWindow(int processID)
        {
            WindowsMode(SW_SHOWMINIMIZED, processID);
        }

        /// <summary>
        /// Muestra ventana en modo normal por medio de su ID de proceso
        /// </summary>
        /// <param name="processID">Id de proceso</param>
        public static void NormalWindow(int processID)
        {
            WindowsMode(SW_SHOWNORMAL, processID);
        }

        private static void WindowsMode(int mode, int processID)
        {
            Process p = Process.GetProcessById(processID);

            if (p != null)
            {
                //int hWnd;
                //hWnd = p.MainWindowHandle.ToInt32();
                //ShowWindow(hWnd, mode);
                //ShowWindowAsync(new IntPtr(hWnd), mode);
                ShowWindowAsync(p.MainWindowHandle, mode);
            }

        }

        /// <summary>
        /// Habilita o deshabilita la página de mysabre.com editando el archivo hots
        /// </summary>
        /// <param name="habilita">True = habilita, False = Deshabilita</param>
        public static void EnabledBrowser(bool habilita)
        {
            bool bContainSABRE = false;
            string strFile = Environment.GetEnvironmentVariable("WINDIR") + "\\system32\\drivers\\etc\\hosts";
            string strFile_out = Environment.GetEnvironmentVariable("WINDIR") + "\\system32\\drivers\\etc\\hosts_temp";

            if (System.IO.File.Exists(strFile))
            {
                StreamReader sr = new StreamReader(strFile);
                StreamWriter sw = new StreamWriter(strFile_out);
                string linea;

                while (!sr.EndOfStream)
                {   //Lee las lineas del archivo
                    linea = sr.ReadLine();
                    //Verifica cada linea si tiene la palabra my.sabre
                    if (linea.ToLower().Contains("my.sabre"))
                    {
                        bContainSABRE = true;
                        //Si encuentra alguna incidencia se va a la primera posicion y verifica si tiene #
                        if (linea.Contains("#"))
                        {
                            if (!habilita)
                            {
                                //Remove the # from the line.
                                int intPos = linea.IndexOf("#");
                                intPos += 1;
                                linea = linea.Substring(intPos, (linea.Length - intPos));
                            }
                        }
                        else if (habilita)
                        {   //Write the # in the line.
                            linea = "#" + linea;
                        }
                    }
                    sw.WriteLine(linea);
                }
                sr.Close();

                if (!bContainSABRE)
                {
                    sw.WriteLine("#127.0.0.1	my.sabre");
                    sw.WriteLine("#127.0.0.1	my.sabre/");
                    sw.WriteLine("#127.0.0.1	my.sabre.com");
                    sw.WriteLine("#127.0.0.1	my.sabre.com/");
                    sw.WriteLine("#127.0.0.1	http://my.sabre.com");
                    sw.WriteLine("#127.0.0.1	https://my.sabre.com");
                }
                sw.Close();
                //Delete file and copy
                System.IO.File.Delete(strFile);
                System.IO.File.Move(strFile_out, strFile);
            }
        }

        /// <summary>
        /// Cambia el valor de una propiedad del archivo especificado por parametro.
        /// </summary>
        /// <param name="strFile">La ruta completa del archivo</param>
        /// <param name="strSearch">El nombre de la propiedad a buscar en minusculas.</param>
        /// <param name="strValue">El valor de la propiedad a cambiar.</param>
        public static void SetValueFile(string strFile, string strSearch, string strValue)
        {
            if (System.IO.File.Exists(strFile))
            {
                string strFile_out = strFile + "_temp";
                StreamReader sr = new StreamReader(strFile);
                StreamWriter sw = new StreamWriter(strFile_out);
                string linea;
                bool bFind = false;

                while (!sr.EndOfStream)
                {   //Lee las lineas del archivo
                    linea = sr.ReadLine();
                    //Verifica cada linea si tiene la palabra my.sabre
                    if (linea.ToLower().Contains(strSearch.ToLower()))
                    {
                        bFind = true;
                        //Si encuentra alguna incidencia reemplaza el valor anterior por el nuevo
                        int intPos = linea.IndexOf("=");
                        intPos += 1;
                        linea = linea.Replace(linea.Substring(intPos, (linea.Length - intPos)), strValue);
                    }
                    sw.WriteLine(linea);
                }
                if (!bFind)
                {
                    sw.WriteLine(strSearch + "=" + strValue);
                }
                sw.Close();
                sr.Close();

                //Delete file and copy
                System.IO.File.Delete(strFile);
                System.IO.File.Move(strFile_out, strFile);
            }
        }

        /// <summary>
        /// Envia el mensaje a la bitacora en la Base de Datos.
        /// </summary>
        /// <param name="strUser">Numero del Agente que realiza la operación.</param>
        /// <param name="dtDate">Fecha y hora de la operación.</param>
        /// <param name="strReserva">Clave de la reserva hecha por el Agente</param>
        public static void SendReservationLog(string strUser, string strPCC, string strReserva, int strStatus)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCTSDb"].ToString());
                cnn.Open();
                SqlCommand cmd = new SqlCommand("InsertReservationLog", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@strAgent", strUser);
                cmd.Parameters.AddWithValue("@strPCC", strPCC);
                cmd.Parameters.AddWithValue("@strReservation", strReserva);
                cmd.Parameters.AddWithValue("@Status", strStatus);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch { }
        }
    }
}
