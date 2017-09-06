using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Services.ValidateDKsAndCreditCards;
using System.Linq;
using System.Text;
using System.Configuration;
using DevExpress.Utils.OAuth.Provider;
using System.Diagnostics;

namespace MyCTS.Presentation
{
    public partial class ucCorporateConsulting : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite consultar la informacion de ToolsOnlineRules
        /// Creación:   12/06/13 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez 
        /// </summary>
        public const string SABRE_RED_WORKSPACE_PROCESO = "mysabre";
        public static IntPtr hWndSabre = IntPtr.Zero;
        //public int xAncho;
        //public int xAlto;
        private System.Windows.Forms.Panel panelBrowser;

        public ucCorporateConsulting()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = dgvConsultaCorporativo;
            this.LastControlFocus = dgvConsultaCorporativo;
        }
        //Extrae la información para llenado del Gridview
        private void ucCorporateConsulting_Load(object sender, EventArgs e)
        {
            panelBrowser = new Panel();
            int Ancho = panelBrowser.Size.Width;
            int Alto = panelBrowser.Size.Height;
            frmBrowser browser = new frmBrowser();
            browser.Redimensionar(Ancho,Alto);
            //ucCorporateConsulting uc = new ucCorporateConsulting();
            //uc.Location = new System.Drawing.Point(Ancho - 400,Alto -80);
            //dgvConsultaCorporativo.Location = new System.Drawing.Point(Ancho - 200 ,Alto -80);
            //uc.Width();

            if (this.Parameters[0].ToString() == Resources.Constants.CORPORATECONSULTINGALL)
            {
                dgvConsultaCorporativo.DataSource = Consulta();
                RowGrid();
                
            }
            else if (this.Parameters[0].ToString() == Resources.Constants.CORPORATECONSULTINGASIGNADO)
            {
               dgvConsultaCorporativo.DataSource= ConsultaAsignado(Convert.ToInt32(ConfigurationManager.AppSettings["DatosContacto"].Split('|')[1]), string.Empty);
               RowGrid();
            }
        }
        // Extrae la informacion completa de ToolsOnlineRules
        private List<CorporativeConsultaGrid> Consulta()
        {
           List<CorporativeConsultaGrid> consulta = new List<CorporativeConsultaGrid>();
           try
           {
               consulta = CorporativeCRUDConsultaBL.ReportCorporateConsulting();
           }
           catch(Exception ex)
           {
               throw ex;
           }
            return consulta;
        }
        //Extrae la informacion solo perteneciente del usuario firmado para ToolsOnlineRules
        private List<CorporativeConsultaGrid> ConsultaAsignado(int firm , string grid)
        {
            List<CorporativeConsultaGrid> consultaList = new List<CorporativeConsultaGrid>();
            try
            {
                consultaList = CorporativeCRUDConsultaBL.ReportCorporateConsultingGrid(firm, grid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return consultaList;
        }
       //Asignar los nombres de las columnas
        private void RowGrid()
        {
            dgvConsultaCorporativo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsultaCorporativo.Columns["Corporative"].HeaderText = "Corporativo";
            dgvConsultaCorporativo.Columns["ToolOnLine"].HeaderText = "Herramienta";
            dgvConsultaCorporativo.Columns["Attribute1"].HeaderText = "DKCorporativo";
            dgvConsultaCorporativo.Columns["Supervisor"].HeaderText = "Nombre Supervisor";
            dgvConsultaCorporativo.Columns["SupAgente"].HeaderText = "Firma Supervisor";
            dgvConsultaCorporativo.Columns["PCC"].HeaderText = "PCC";
            dgvConsultaCorporativo.Columns["SupStatus"].HeaderText = "Disponible";
            dgvConsultaCorporativo.Columns["Consultor1"].HeaderText = "Nombre Consultor1";
            dgvConsultaCorporativo.Columns["ConAgent1"].HeaderText = "Firma Consultor1";
            dgvConsultaCorporativo.Columns["PCC1"].HeaderText = "PCC1";
            dgvConsultaCorporativo.Columns["ConStatus1"].HeaderText = "Disponible";
            dgvConsultaCorporativo.Columns["Consultor2"].HeaderText = "Nombre Consultor2";
            dgvConsultaCorporativo.Columns["ConAgent2"].HeaderText = "Firma Consultor2";
            dgvConsultaCorporativo.Columns["PCC2"].HeaderText = "PCC2";
            dgvConsultaCorporativo.Columns["ConStatus2"].HeaderText = "Disponible";
            dgvConsultaCorporativo.Columns["Consultor3"].HeaderText = "Nombre Consultor3";
            dgvConsultaCorporativo.Columns["ConAgent3"].HeaderText = "Firma Consultor3";
            dgvConsultaCorporativo.Columns["PCC3"].HeaderText = "PCC3";
            dgvConsultaCorporativo.Columns["ConStatus3"].HeaderText = "Disponible";
            dgvConsultaCorporativo.Columns["Consultor4"].HeaderText = "Nombre Consultor4";
            dgvConsultaCorporativo.Columns["ConAgent4"].HeaderText = "Firma Consultor4";
            dgvConsultaCorporativo.Columns["PCC4"].HeaderText = "PCC4";
            dgvConsultaCorporativo.Columns["ConStatus4"].HeaderText = "Disponible";
            dgvConsultaCorporativo.Columns["Consultor5"].HeaderText = "Nombre Consultor5";
            dgvConsultaCorporativo.Columns["ConAgent5"].HeaderText = "Firma Consultor5";
            dgvConsultaCorporativo.Columns["PCC5"].HeaderText = "PCC5";
            dgvConsultaCorporativo.Columns["ConStatus5"].HeaderText = "Disponible";
        }
       
        

    }
}
