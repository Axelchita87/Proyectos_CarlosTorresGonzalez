using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Configuration;
using System.IO;

namespace MyCTS.Presentation
{
    public delegate void CheckStatusDelegate(object sender, FormClosingEventArgs e);

    public partial class frmParent : Form
    {
        #region variables
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        public IntPtr hWndSabres = IntPtr.Zero;
        private const string SABRE_RED_WORKSPACE = "Sabre® Red Workspace - Sabre Travel Network";
        private const string MYCTS_PROCESO = "MyCTS.Presentation";
        private const string SABRE_RED_WORKSPACE_PROCESO = "mysabre";
        private const int SW_SHOWNORMAL = 1;
        public const int SW_MAXIMIZE = 3;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;
        public static string AppName = "MyCTS2";
        private bool esFormControlMenu = true;
        public long handleMod;
        private IntPtr hWndApp = IntPtr.Zero;
        public IntPtr HWndApp = IntPtr.Zero;
        private IntPtr hWndSabre = IntPtr.Zero;
        private bool m_TextPasted = false;
        private bool m_TextCopied = false;
        //public bool IsSigned = false;
        public string fileName = @"C:\SabreRed\ConfigSplitContainer\TamañoSplitContainer.txt";
        public string SplitContainerFile = string.Empty;
        public int xAncho;
        public int xAlto;
        public string linea;
        public string linea1;
        public string pathSpC = string.Empty;

        #endregion

        public frmParent()
        {
            InitializeComponent();
        }

        public void frmParent_Load(object sender, EventArgs e)
        {
            MdiClient ctlMDI;

            foreach (Control ctl in this.Controls)
            {
                try
                {
                    ctlMDI = (MdiClient)ctl;
                    ctlMDI.BackColor = this.BackColor;
                }
                catch (InvalidCastException exc)
                {
                }
            }
            int w = Screen.AllScreens[0].WorkingArea.Width;

            this.Top = Screen.AllScreens[0].WorkingArea.Top;
            this.Left = Screen.AllScreens[0].WorkingArea.Left;
            this.Height = Screen.AllScreens[0].WorkingArea.Height;
            this.Width = w;

            #region Se crea SplitContainer para contener a sabre y MyCTS
            frmMain Main = new frmMain();
            Main.TopLevel = false;
            Main.Dock = DockStyle.Fill;
            this.splitContainer1.Panel2.Controls.Add(Main);
            Main.AutoSize = true;
            Main.Show();

            frmBrowser Browser = new frmBrowser();
            Browser.TopLevel = false;
            Browser.Dock = DockStyle.Fill;
            this.splitContainer1.Panel1.Controls.Add(Browser);
            Browser.AutoSize = true;
            Browser.Show();
            #endregion

            Main.CheckStatus = new CheckStatusDelegate(frmParent_FormClosing);

            #region Lee el archivo TamañoSplitContainer.txt

            pathSpC = ConfigurationManager.AppSettings["PATH_DQB_FILE_SPLITCONTAINER"];
            SplitContainerFile = string.Concat(pathSpC + "\\ConfigSplitContainer");
            SplitContainerFile = string.Concat(SplitContainerFile, ".txt");
            if (System.IO.File.Exists(SplitContainerFile))
            {


                StreamReader sr = new StreamReader(SplitContainerFile);
                //Leo la primera linea
                linea = sr.ReadLine();
                linea1 = sr.ReadLine();
                xAncho = Convert.ToInt32(linea);
                xAlto = Convert.ToInt32(linea1);
                sr.Close();
                this.splitContainer1.SplitterDistance = xAncho;
            }

            #endregion

        }

        public CheckStatusDelegate CheckStatus;

        private void frmParent_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro que deseas salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                if (frmMain.IsSigned)
                {
                    MessageBox.Show("Antes de cerrar MyCTS debe desfirmarse!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
            if (!e.Cancel)
            {
                frmLogin frm = (frmLogin)Application.OpenForms["frmLogin"];
                if (frm != null)
                    frm.Dispose();

            }

            createSplitDistancia();
        }

        public void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            SplitContainer control = (SplitContainer)sender;
            frmBrowser Browser = new frmBrowser();
            xAncho = control.Panel1.Width;
            xAlto = control.Panel1.Height;

            Browser.Redimensionar(xAncho, xAlto);
        }

        #region Crea el archivo de configuracion TamañoSplitContainer

        /// <summary>
        /// Crea el archivo de configuracion TamañoSplitContainer y 
        /// la carpeta contenedora en la Carpeta SabreRed
        /// </summary>
        public void createSplitDistancia()
        {
            pathSpC = ConfigurationManager.AppSettings["PATH_DQB_FILE_SPLITCONTAINER"];
            SplitContainerFile = string.Concat(pathSpC + "\\ConfigSplitContainer");
            SplitContainerFile = string.Concat(SplitContainerFile, ".txt");

            int indexSlash = SplitContainerFile.LastIndexOf("\\");
            int quantity = SplitContainerFile.Length - indexSlash;
            if (!Directory.Exists(pathSpC))
            {
                Directory.CreateDirectory(pathSpC);
                using (StreamWriter w = File.AppendText(SplitContainerFile))
                {
                    w.WriteLine(xAncho);
                    w.WriteLine(xAlto);
                    w.Flush();
                    w.Close();
                }
            }
            else
            {
                if (File.Exists(SplitContainerFile))
                {
                    File.Delete(SplitContainerFile);
                    using (StreamWriter w = File.AppendText(SplitContainerFile))
                    {
                        w.WriteLine(xAncho);
                        w.WriteLine(xAlto);
                        w.Flush();
                        w.Close();
                    }
                }
                else
                {
                    using (StreamWriter w = File.AppendText(SplitContainerFile))
                    {
                        w.WriteLine(xAncho);
                        w.WriteLine(xAlto);
                        w.Flush();
                        w.Close();
                    }
                }
            }

        }
        #endregion
    }

      public class WinApi
    {

        #region Class Functions
        [DllImport("user32.dll", EntryPoint = "ShowWindow")]
        public static extern IntPtr ShowWindow(IntPtr hWnd, long nCmdShow);
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "SetParent")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", EntryPoint = "GetParent")]
        public static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        [DllImport("user32.dll", EntryPoint = "CloseWindow")]
        public static extern IntPtr CloseWindow(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "DestroyWindow")]
        public static extern IntPtr DestroyWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd, out IntPtr ProcessId);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public extern static int MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, int bRepaint);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern IntPtr GetSystemMenu(int hWnd, bool bRevert);

        #endregion
    }


    #region constantes

    public class ShowWindowConsts
    {
        // Reference: http://msdn.microsoft.com/en-us/library/ms633548(VS.85).aspx

        /// <summary>
        /// Minimizes a window, even if the thread that owns the window is not responding. 
        /// This flag should only be used when minimizing windows from a different thread.
        /// </summary>
        public const int SW_FORCEMINIMIZE = 11;

        /// <summary>
        /// Hides the window and activates another window.
        /// </summary>
        public const int SW_HIDE = 0;

        /// <summary>
        /// Maximizes the specified window.
        /// </summary>
        public const int SW_MAXIMIZE = 3;

        /// <summary>
        /// Minimizes the specified window and activates the next top-level window in the Z order.
        /// </summary>
        public const int SW_MINIMIZE = 6;

        /// <summary>
        /// Activates and displays the window. 
        /// If the window is minimized or maximized, the system restores it to 
        /// its original size and position. 
        /// An application should specify this flag when restoring a minimized window.
        /// </summary>
        public const int SW_RESTORE = 9;

        /// <summary>
        /// Activates the window and displays it in its current size and position.
        /// </summary>
        public const int SW_SHOW = 5;

        /// <summary>
        /// Sets the show state based on the public const long SW_ value specified in 
        /// the STARTUPINFO structure passed to the CreateProcess function by 
        /// the program that started the application.
        /// </summary>
        public const int SW_SHOWDEFAULT = 10;

        /// <summary>
        /// Activates the window and displays it as a maximized window.
        /// </summary>
        public const int SW_SHOWMAXIMIZED = 3;

        /// <summary>
        /// Activates the window and displays it as a minimized window.
        /// </summary>
        public const int SW_SHOWMINIMIZED = 2;

        /// <summary>
        /// Displays the window as a minimized window. 
        /// This value is similar to public const long SW_SHOWMINIMIZED, 
        /// except the window is not activated.
        /// </summary>
        public const int SW_SHOWMINNOACTIVE = 7;

        /// <summary>
        /// Displays the window in its current size and position. 
        /// This value is similar to public const long SW_SHOW, except that the window is not activated.
        /// </summary>
        public const int SW_SHOWNA = 8;

        /// <summary>
        /// Displays a window in its most recent size and position. 
        /// This value is similar to public const long SW_SHOWNORMAL, 
        /// except that the window is not activated.
        /// </summary>
        public const int SW_SHOWNOACTIVATE = 4;

        public const int SW_SHOWNORMAL = 1;
    }
    #endregion

}