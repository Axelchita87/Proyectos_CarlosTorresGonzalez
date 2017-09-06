using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Presentation.Components;
using System.Diagnostics;

namespace MyCTS.Presentation
{
    public partial class frmProfiles : Form
    {
        /// <summary>
        /// Descripción: WinForm contenedor del modulo de perfiles
        /// Creación:    03 febrero 2010, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>

        public frmProfiles()
        {
            InitializeComponent();
        }
        #region Variables and Properties

        public static string strSearch { get; set; }
        public int MinWidth = 0;
        public int MinHeight = 0;
        private int MaxWidth = 510;
        private int MaxHeight = 710;
        public bool IsMinSize = false;
        public string Cont;
        public static bool IsReservationFlow = false;
        private string sTipoBusqueda = "";
        private string sTextoAnterior = "";
        private string sTextoActual;
        public static ucProfileSearch _ucProfileSearch = null;
        private Timer timerBusqueda;
        public static  bool  IsTicket ;
        private Stopwatch TimerTiempoBase = new Stopwatch();

        public void InitTimer()
        {
            timerBusqueda = new Timer();
            timerBusqueda.Tick += new EventHandler(timerBusqueda_Tick);
            timerBusqueda.Interval = 1000; // in miliseconds
            timerBusqueda.Start();
        }

        private void timerBusqueda_Tick(object sender, EventArgs e)
        {
            if (sTextoActual.Trim() == sTextoAnterior.Trim())
            {
                if (TimerTiempoBase.ElapsedMilliseconds > 1000)
                {
                    frmPreloading frm2 = new frmPreloading(this);
                   int iTotal = ProfileSearch.LoadProfileSearchResult(sTextoActual, sTipoBusqueda, true);
                    frm2.Show();
                    TxtContadorRegistros.Visible = true;
                    TxtContadorRegistros.Text = "Se han encontrado un total de " + iTotal + " registros en su busqueda";
                    TimerTiempoBase.Stop();
                    TimerTiempoBase = new Stopwatch();
                }
            }
            else
            {
                TimerTiempoBase.Start();
                sTextoAnterior = sTextoActual;
            }
        }

        private ucProfileSearch ProfileSearch
        {
            get
            {
                if (_ucProfileSearch == null)
                {
                    _ucProfileSearch = new ucProfileSearch();
                    pnlProfiles.Controls.Clear();
                    pnlProfiles.Controls.Add(_ucProfileSearch);
                }

                return _ucProfileSearch;
            }
        }

        #endregion

        //Evento frmProfiles_Load
        private void frmProfiles_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            frmPreloading fr = new frmPreloading(this);
            fr.Show();
            MinWidth = this.Width;
            MinHeight = this.Height;
            IsMinSize = true;
            Focus();
            InitialProcess();
            if (IsTicket)
            {
                LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_SECOND_LEVEL_PROFILES);
                TxtContadorRegistros.Visible = false;
            }
        }

        #region===== MethodsClass =====


        /// <summary>
        /// Carga el catalogo de perfiles por codigo y carga la primer pantalla dependiendo si es por flujo
        /// o por opcion del menu
        /// </summary>
        private void InitialProcess()
        {
            if (IsReservationFlow)
            {
                toolStripDropDownOptionProfiles.Enabled = false;
                pnlProfiles.TabIndex = 1;
                toolStripProfileMenu.TabIndex = 2;
                LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_WELCOME_PROFILES);
            }
            else
            {
                string activeProfiles = ParameterBL.GetParameterValue(Resources.Profiles.Constants.ACTIVE_PROFILES).Values;
                if (Convert.ToBoolean(activeProfiles))
                {
                    toolStriptxtSearch.Enabled = true;
                    toolStripTextDK.Enabled = true;
                    ToolStripMenuItemCreateProfile2ndLevel.Enabled = true;
                    ToolStripMenuItemNewProfile.Enabled = true;
                }
                else
                {
                    ToolStripMenuItemCreateProfile2ndLevel.Enabled = false;
                    ToolStripMenuItemNewProfile.Enabled = false;
                }
                LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_WELCOME_PROFILES);
            }
        }


        /// <summary>
        /// Muestra los valores resultantes de la busqueda deacuerdo al texto de busqueda
        /// de perfil ingresado
        /// </summary>
        /// <param name="sender">Item Seleccionado</param>
        private void LoadProfileSearchResult(object sender)
        {
            string strToSearch = ((ToolStripTextBox)sender).Text;

            if (strToSearch.Length > 4)
            {
                sTextoActual = strToSearch;
                InitTimer();
            }
            else
            {
                _ucProfileSearch = null;
                this.Width = MinWidth;
                this.Height = MinHeight;
                timerBusqueda.Tick -= new EventHandler(timerBusqueda_Tick);
                LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_WELCOME_PROFILES);
                TxtContadorRegistros.Visible = true;
                TxtContadorRegistros.Text = "";
            }
        }

        /// <summary>
        /// Carga user control para la busqueda avanzada de perfil
        /// </summary>
        private void LoadSearchProfileDetailed()
        {
            if (!IsMinSize)
            {
                this.Width = this.MinWidth;
                this.Height = this.MinHeight;
                //this.CenterForm();
                IsMinSize = true;
                frmPreloading frm2 = new frmPreloading(this);
                frm2.Show();
            }
            _ucProfileSearch = null;
            LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_SEARCH_PROFILE_DETAILED);
        }

        /// <summary>
        /// Posiciona el contenedor principal al centro de la pantalla
        /// </summary>
        public void CenterForm()
        {
            this.CenterToScreen();
        }

        /// <summary>
        /// Carga user control para crear un perfil de segundo nivel
        /// </summary>
        private void LoadCreate1stLevelProfile()
        {
            
            _ucProfileSearch = null;
            if (IsMinSize)
            {
                this.Width = MaxWidth;
                this.Height = MaxHeight;
                this.CenterToScreen();
                IsMinSize = false;
            }
            LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_FIRST_LEVEL_PROFILES);
            _ucProfileSearch = null;
        }


        private void LoadCreate2ndLevelProfile()
        {
            
            _ucProfileSearch = null;
            if (IsMinSize)
            {
                this.Width = MaxWidth;
                this.Height = MaxHeight;
                this.CenterToScreen();
                IsMinSize = false;
            }
            LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_SECOND_LEVEL_PROFILES);
            _ucProfileSearch = null;
        }
        #endregion//End MethodsClass


        #region===== pnlProfiles Events =====

        private void pnlProfiles_Enter(object sender, EventArgs e)
        {
            if (!IsReservationFlow)
                pnlProfiles.Controls[0].Focus();
        }

        #endregion


        #region===== MenuProfiles Buttons Click Events =====

        //Evento ToolStripMenuSearchDetailedProfile_Click
        private void ToolStripMenuSearchDetailedProfile_Click(object sender, EventArgs e)
        {

            LoadSearchProfileDetailed();
        }

        //Evento ToolStripMenuItemNewProfile_Click
        private void ToolStripMenuItemNewProfile_Click(object sender, EventArgs e)
        {
            LoadCreate1stLevelProfile();
        }


        //ToolStripMenuItemCreateProfile2ndLevel_Click
        private void ToolStripMenuItemCreateProfile2ndLevel_Click(object sender, EventArgs e)
        {
            LoadCreate2ndLevelProfile();
        }

        #endregion


        #region===== txtSearch TextChange =====

        //Evento toolStriptxtSearch_TextChanged
        private void toolStriptxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!IsMinSize)
            {
                this.Width = this.MinWidth;
                this.Height = this.MinHeight;
                //this.CenterForm();
                IsMinSize = true;
            }

            if (toolStriptxtSearch.Text.Length >= 5)
            {
                sTipoBusqueda = "APELLIDO";
                LoadProfileSearchResult(sender);
            }
            else
            {
                LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_WELCOME_PROFILES);
                _ucProfileSearch = null;
            }
        }

        private void toolStripTextDK_TextChanged(object sender, EventArgs e)
        {
            if (!IsMinSize)
            {
                this.Width = this.MinWidth;
                this.Height = this.MinHeight;
                //this.CenterForm();
                IsMinSize = true;
            }

            if (toolStripTextDK.Text.Length >= 5)
            {
                sTipoBusqueda = "DK";
                LoadProfileSearchResult(sender);
            }
            else
            {
                LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_WELCOME_PROFILES);
                _ucProfileSearch = null;
            }
        }

        #endregion

        private void frmProfiles_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsTicket = false;

            _ucProfileSearch = null;
        }

        private void toolStriptxtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            toolStripProfileMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            if (e.KeyChar == (char)13)
            {
                string sValorBuscar = ((ToolStripTextBox)sender).Text;
                frmPreloading frm2 = new frmPreloading(this);
                frm2.Show();
                int iTotal = ProfileSearch.LoadProfileSearchResult(sValorBuscar, sTipoBusqueda, true);
                TxtContadorRegistros.Visible = true;
                TxtContadorRegistros.Text = "Se han encontrado un total de " + iTotal + " registros en su busqueda";
            }
        }

        private void toolStripProfileMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
