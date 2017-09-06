using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace MyCTS.Presentation.Reservations.Menus.ToolsBar.Funtion.Edition
{
    public partial class frmCorporateConsulting : Form
    {
        /// <summary>
        /// Descripción: WinForm contenedor del Consulta de Corporativo
        /// Creación:    24 junio 2013, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Jessica Gutierrez
        /// </summary>
        /// 
        public frmCorporateConsulting()
        {
            InitializeComponent();
        }
        #region ===========Variable========
        int cntr = 0; 
        public int MinWidth = 0;
        public int MinHeight = 0;
        private int MaxWidth = 510;
        private int MaxHeight = 600;
        public bool IsMinSize = false;
        public static bool consultingAll=false;
        public static bool consultingAsignado = false;
        List<CorporativeConsultaGrid> consulta = null;
        #endregion

        //Se indica los parametros de ancho y alto
        private void frmCorporateConsulting_Load(object sender, EventArgs e)
        {
            frmPreloading fr = new frmPreloading(this);
            fr.Show();
            MinWidth = this.Width;
            MinHeight = this.Height;
            IsMinSize = true;
            Focus();
            InitialProcess();
        }
        //Obtener informacion para llenado de DataGridView
        private void InitialProcess()
        {
            if (consultingAll)
            {
                dgvConsultaCorporativo.DataSource = Consulta();
                RowGrid();

            }
            else if (consultingAsignado)
            {
                dgvConsultaCorporativo.DataSource = ConsultaAsignado(Convert.ToInt32(ConfigurationManager.AppSettings["DatosContacto"].Split('|')[1]), string.Empty);
                RowGrid();
            }
        }
        // Extrae la informacion completa de ToolsOnlineRules
        private List<CorporativeConsultaGrid> Consulta()
        {
            consulta = new List<CorporativeConsultaGrid>();
            try
            {
                consulta = CorporativeCRUDConsultaBL.ReportCorporateConsulting();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return consulta;
        }
        //Extrae la informacion solo perteneciente del usuario firmado para ToolsOnlineRules
        private List<CorporativeConsultaGrid> ConsultaAsignado(int firm, string grid)
        {
            consulta = new List<CorporativeConsultaGrid>();
            try
            {
                consulta = CorporativeCRUDConsultaBL.ReportCorporateConsultingGrid(firm, grid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return consulta;
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
        //Ordenamiento de columnas
        private void dgvConsultaCorporativo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CorporativeConsultaGrid tipoDatoOrdenamiento = new CorporativeConsultaGrid();
            List<CorporativeConsultaGrid> orderList = new List<CorporativeConsultaGrid>();
            switch (dgvConsultaCorporativo.Columns[e.ColumnIndex].Name)
            {
                case "Corporative":
                    orderList = (cntr % 2).Equals(0) ? Consulta().OrderBy(c => c.Corporative).ToList() : Consulta().OrderByDescending(c => c.Corporative).ToList();
                    break;
                case "Attribute1":
                    orderList = (cntr % 2).Equals(0) ? Consulta().OrderBy(c => c.Attribute1).ToList() : Consulta().OrderByDescending(c => c.Attribute1).ToList();
                    break;
                case "ToolOnline":
                    orderList = (cntr % 2).Equals(0) ? Consulta().OrderBy(c => c.ToolOnline).ToList() : Consulta().OrderByDescending(c => c.ToolOnline).ToList();
                    break;
                case "Supervisor":
                    orderList = (cntr % 2).Equals(0) ? Consulta().OrderBy(c => c.Supervisor).ToList() : Consulta().OrderByDescending(c => c.Supervisor).ToList();
                    break;
                case "SupAgente":
                    orderList = (cntr % 2).Equals(0) ? Consulta().OrderBy(c => c.SupAgente).ToList() : Consulta().OrderByDescending(c => c.SupAgente).ToList();
                    break;
                case "PCC":
                    orderList = (cntr % 2).Equals(0) ? Consulta().OrderBy(c => c.PCC).ToList() : Consulta().OrderByDescending(c => c.PCC).ToList();
                    break;
                case "SupStatus":
                    orderList = (cntr % 2).Equals(0) ? Consulta().OrderBy(c => c.SupStatus).ToList() : Consulta().OrderByDescending(c => c.SupStatus).ToList();
                    break;
                case "Consultor1":
                    orderList = (cntr % 2).Equals(0) ? Consulta().OrderBy(c => c.Consultor1).ToList() : Consulta().OrderByDescending(c => c.Consultor1).ToList();
                    break;
                case "ConAgent1":
                    orderList = (cntr % 2).Equals(0) ? Consulta().OrderBy(c => c.ConAgent1).ToList() : Consulta().OrderByDescending(c => c.ConAgent1).ToList();
                    break;
                case "PCC1":
                    orderList = (cntr % 2).Equals(0) ? Consulta().OrderBy(c => c.PCC1).ToList() : Consulta().OrderByDescending(c => c.PCC1).ToList();
                    break;
                case "ConStatus1":
                    orderList = (cntr % 2).Equals(0) ? Consulta().OrderBy(c => c.ConStatus1).ToList() : Consulta().OrderByDescending(c => c.ConStatus1).ToList();
                    break;
                case "Consultor2":
                    orderList = (cntr % 2).Equals(0) ? Consulta().OrderBy(c => c.Consultor2).ToList() : Consulta().OrderByDescending(c => c.Consultor2).ToList();
                    break;
                case "ConAgent2":
                    orderList = (cntr % 2).Equals(0) ? Consulta().OrderBy(c => c.ConAgent2).ToList() : Consulta().OrderByDescending(c => c.ConAgent2).ToList();
                    break;
                case "PCC2":
                    orderList = (cntr % 2).Equals(0) ? Consulta().OrderBy(c => c.PCC2).ToList() : Consulta().OrderByDescending(c => c.PCC2).ToList();
                    break;
                case "ConStatus2":
                    orderList = (cntr % 2).Equals(0) ? Consulta().OrderBy(c => c.ConStatus2).ToList() : Consulta().OrderByDescending(c => c.ConStatus2).ToList();
                    break;
                case "Consultor3":
                    orderList = (cntr % 2).Equals(0) ? Consulta().OrderBy(c => c.Consultor3).ToList() : Consulta().OrderByDescending(c => c.Consultor3).ToList();
                    break;
                case "ConAgent3":
                    orderList = (cntr % 2).Equals(0) ? Consulta().OrderBy(c => c.ConAgent3).ToList() : Consulta().OrderByDescending(c => c.ConAgent3).ToList();
                    break;
                case "PCC3":
                    orderList = (cntr % 2).Equals(0) ? Consulta().OrderBy(c => c.PCC3).ToList() : Consulta().OrderByDescending(c => c.PCC3).ToList();
                    break;
                case "ConStatus3":
                    orderList = (cntr % 2).Equals(0) ? Consulta().OrderBy(c => c.ConStatus3).ToList() : Consulta().OrderByDescending(c => c.ConStatus3).ToList();
                    break;
                case "Consultor4":
                    orderList = (cntr % 2).Equals(0) ? Consulta().OrderBy(c => c.Consultor4).ToList() : Consulta().OrderByDescending(c => c.Consultor4).ToList();
                    break;
                case "ConAgent4":
                    orderList = (cntr % 2).Equals(0) ? Consulta().OrderBy(c => c.ConAgent4).ToList() : Consulta().OrderByDescending(c => c.ConAgent4).ToList();
                    break;
                case "PCC4":
                    orderList = (cntr % 2).Equals(0) ? Consulta().OrderBy(c => c.PCC4).ToList() : Consulta().OrderByDescending(c => c.PCC4).ToList();
                    break;
                case "ConStatus4":
                    orderList = (cntr % 2).Equals(0) ? Consulta().OrderBy(c => c.ConStatus4).ToList() : Consulta().OrderByDescending(c => c.ConStatus4).ToList();
                    break;
                case "Consultor5":
                    orderList = (cntr % 2).Equals(0) ? Consulta().OrderBy(c => c.Consultor5).ToList() : Consulta().OrderByDescending(c => c.Consultor5).ToList();
                    break;
                case "ConAgent5":
                    orderList = (cntr % 2).Equals(0) ? Consulta().OrderBy(c => c.ConAgent5).ToList() : Consulta().OrderByDescending(c => c.ConAgent5).ToList();
                    break;
                case "PCC5":
                    orderList = (cntr % 2).Equals(0) ? Consulta().OrderBy(c => c.PCC5).ToList() : Consulta().OrderByDescending(c => c.PCC5).ToList();
                    break;
                case "ConStatus5":
                    orderList = (cntr % 2).Equals(0) ? Consulta().OrderBy(c => c.ConStatus5).ToList() : Consulta().OrderByDescending(c => c.ConStatus5).ToList();
                    break;
                default:
                    MessageBox.Show("HA OCURRIDO UN ERROR AL TRATAR DE ORDENAR");
                    break;
            }


            dgvConsultaCorporativo.DataSource = orderList;
            RowGrid();
            cntr++;
            
        }    
       
    }
}
