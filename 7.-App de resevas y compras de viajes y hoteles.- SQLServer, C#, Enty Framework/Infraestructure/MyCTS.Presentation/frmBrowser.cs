using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MyCTS.Presentation
{
    public partial class frmBrowser : Form
    {
        #region variables

        /// <summary>
        /// Maximizes the specified window.
        /// Estas variables son utilizadas para realizar la redimension de una aplicacion externa
        /// como lo es Sabre Red.
        /// </summary>
        public const int SW_MAXIMIZE = 3;
        /// <summary>
        /// Minimizes the specified window and activates the next top-level window in the Z order.
        /// </summary>
        public Boolean flag = false;
        public IntPtr handleSabre;
        public const string SABRE_RED_WORKSPACE = "Sabre® Red™ Workspace - Sabre Travel Network";
        public const string MYCTS_PROCESO = "MyCTS.Presentation";
        public const string SABRE_RED_WORKSPACE_PROCESO = "mysabre";
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "ShowWindow")]
        public static extern IntPtr ShowWindow(IntPtr hWnd, long nCmdShow);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "GetSystemMenu")]
        private static extern IntPtr GetSystemMenu(IntPtr hwnd, int revert);
        [DllImport("user32.dll", EntryPoint = "GetMenuItemCount")]
        private static extern int GetMenuItemCount(IntPtr hmenu);
        [DllImport("user32.dll", EntryPoint = "RemoveMenu")]
        private static extern int RemoveMenu(IntPtr hmenu, int npos, int wflags);
        [DllImport("user32.dll", EntryPoint = "DrawMenuBar")]
        private static extern int DrawMenuBar(IntPtr hwnd);
        private const int MF_BYPOSITION = 0x0400;
        private const int MF_DISABLED = 0x0002;

        /// <summary>
        /// Activates the window and displays it as a maximized window.
        /// </summary>
        private const int SW_SHOWMAXIMIZED = 3;


        public static IntPtr hWndSabre = IntPtr.Zero;
        public IntPtr hWndSabres = IntPtr.Zero;

        #endregion

        public frmBrowser()
        {
            InitializeComponent();
        }

        public void frmBrowser_Load(object sender, EventArgs e)
        {
            int w = this.Parent.Width / 2;

            this.Top = this.Parent.Top;
            this.Left = this.Parent.Left;
            this.Height = this.Parent.Height - 10;
            this.Width = w + 80;
            //if (!Login.ByParameters)
            //{
            //    string webBrowserPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            //    string nameEXE = System.IO.Path.GetFileName(Application.ExecutablePath);
            //    string webBrowserPath_temp = webBrowserPath.Substring(0, webBrowserPath.Length - nameEXE.Length) + "WebBrowser\\MyCTSBrowser.exe";

            //    Process p1 = new Process();
            //    p1.StartInfo.FileName = webBrowserPath_temp;
            //    p1.StartInfo.EnvironmentVariables.Add("myCTS_user", Login.Firm);
            //    p1.StartInfo.EnvironmentVariables.Add("myCTS_pwd", Login.passWord);
            //    p1.StartInfo.EnvironmentVariables.Add("myCTS_pcc", Login.PCC);
            //    p1.StartInfo.EnvironmentVariables.Add("mycts_processid", Process.GetCurrentProcess().Id.ToString());
            //    p1.StartInfo.UseShellExecute = false;
            //    p1.Start();
            //}
            timer1.Enabled = true;

            Process[] proce = Process.GetProcessesByName(SABRE_RED_WORKSPACE_PROCESO);
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = SABRE_RED_WORKSPACE_PROCESO;

            System.Diagnostics.Process[] Processes = System.Diagnostics.Process.GetProcessesByName(SABRE_RED_WORKSPACE_PROCESO);

            hWndSabre = FindWindow(null, SABRE_RED_WORKSPACE);
            if (flag == true)
            {
                int Ancho = panelBrowser.Size.Width;
                int Alto = panelBrowser.Size.Height;
                Redimensionar(Alto, Ancho);
            }

        }

        public void Redimensionar(int ancho, int alto)
        {
            Process[] proce = Process.GetProcessesByName(SABRE_RED_WORKSPACE_PROCESO);

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = SABRE_RED_WORKSPACE_PROCESO;
            if (hWndSabre.ToInt32() > 0)
            {
                WinApi.MoveWindow(hWndSabre, 0, 0, ancho, alto, 1);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            flag = false;
            System.IntPtr winParent;
            System.IntPtr x;
            string lblAppName = "Sabre® Red™ Workspace - Sabre Travel Network";

            //Se obtiene el proceso de Sabre con el nombre que contiene la variable lblAppName
            System.IntPtr winHandle = Usr32.FindWindowByCaption(IntPtr.Zero, lblAppName);
            if (winHandle != System.IntPtr.Zero)
            {
                winParent = Usr32.GetParent(winHandle);
                x = Usr32.SetParent(winHandle, this.panelBrowser.Handle);
                x = Usr32.SetWindowPos(winHandle, 1, 1, 1, panelBrowser.Size.Width, panelBrowser.Size.Height, 0);
                this.timer1.Enabled = false;
            }

            IntPtr hmenu = GetSystemMenu(winHandle, 0);
            int cnt = GetMenuItemCount(hmenu);

            // Deshabilita el boton de cerrar de Sabre
            RemoveMenu(hmenu, cnt - 1, MF_DISABLED | MF_BYPOSITION);

            // Elimina la linea extra del menu de Sabre
            RemoveMenu(hmenu, cnt - 2, MF_DISABLED | MF_BYPOSITION);
            //Redibuja el Menu de Sabre
            DrawMenuBar(winHandle);
        }
    }

    public class Usr32
    {
        #region Class Variables
        public const int SM_CXSCREEN = 0;
        public const int SM_CYSCREEN = 1;
        #endregion

        #region Class Functions
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWin(string lpClassName, IntPtr lpWindowName);

        [DllImport("user32.dll", EntryPoint = "SetParent")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", EntryPoint = "GetParent")]
        public static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        [DllImport("user32.dll", EntryPoint = "ShowWindow")]
        public static extern IntPtr ShowWindow(IntPtr hWnd, long nCmdShow);

        [DllImport("user32.dll", EntryPoint = "CloseWindow")]
        public static extern IntPtr CloseWindow(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "DestroyWindow")]
        public static extern IntPtr DestroyWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd, out IntPtr ProcessId);

        #endregion
    }
}