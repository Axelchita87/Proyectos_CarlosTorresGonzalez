using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;

namespace MyCTS.Presentation
{
    public partial class ucProductivityReportManager : CustomUserControl
    {

        /// <summary>
        /// Descripcion: Permite desplegar la productividad por cada Agente
        /// Creación:    23 -Marzo 10 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez
        /// </summary>

        #region ======== Declaration of Variable =======

        //Datos
        private string workingDays = string.Empty;
        private string workingDays2 = string.Empty;
        private string initialDate = string.Empty;
        private string finalDate = string.Empty;
        //Datos2
        private string workingDays3 = string.Empty;
        private string workingDays4 = string.Empty;
        private string initialDate2 = string.Empty;
        private string finalDate2 = string.Empty;
        //Datos3
        private string workingDays5 = string.Empty;
        private string workingDays6 = string.Empty;
        private string initialDate3 = string.Empty;
        private string finalDate3 = string.Empty;

        #endregion

        private delegate void SenderCallBack();
        private delegate void StopControlsDelegate();
        TextBox txt;
        private string week;
        private string month;
        bool rol;

        public ucProductivityReportManager()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtAgent;
            this.LastControlFocus = btnAccept;
        }

        //Carga los combos con las semanas y meses transcurridos
        private void ucProductivityReportManager_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            FillWeeks();
            FillMonths();
            lbAgent.BringToFront();
            rol = RolesBL.IsUserInRole(Login.UserId, Resources.Constants.ADMINPROD);
            if (rol)
            {
                lblAgent.Visible = true;
                txtAgent.Visible = true;
                txtAgent.Focus();
            }
            else
                rdoWeek.Focus();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidateBusinessRules)
            {
                timer1.Enabled = true;
                progressBar1.Visible = true;
                lblLoader.Visible = true;
                SenderCallBack scb = new SenderCallBack(Generation);
                AsyncCallback callback = new AsyncCallback(OnCompleted);
                scb.BeginInvoke(callback, null);
            }
        }

        //Asigna el porcentage para el progressBar1 
        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Percentage = 10; //Set Next Value
            progressBar1.SetProgComplete(progressBar1.Percentage);
        }

        //Valida los campos obligatorios y manda un proceso asincrono para generar un excel
        /// <summary>
        /// Permite notificar que el proceso asíncrono ha terminado
        /// </summary>
        /// <param name="asyncResult">Objeto con referencia de tipo AsyncCallback</param>
        private void OnCompleted(IAsyncResult asyncResult)
        {
            AsyncResult result = (AsyncResult)asyncResult;
            SenderCallBack scb = (SenderCallBack)result.AsyncDelegate;
            scb.EndInvoke(asyncResult);
            LoadUserControl();
        }

        /// <summary>
        /// Carga user control de inicio
        /// </summary>
        private void LoadUserControl()
        {
            if (this.InvokeRequired)
            {
                SenderCallBack scb = new SenderCallBack(LoadUserControl);
                this.Invoke(scb);
            }
            else
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }

        #region ======= Change Focus ======

        //Estable la visibilidad de controles
        private void rdoWeek_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoWeek.Checked)
            {
                cmbWeek.Visible = true;
                cmbMonth.Visible = false;
            }
        }

        //Estable la visibilidad de controles
        private void rdoMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoMonth.Checked)
            {
                cmbMonth.Visible = true;
                cmbWeek.Visible = false;
            }
        }

        //Extrae la fecha en formato (dd/mm/yyyy)
        private void cmbWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbWeek.SelectedIndex > 0)
            {
                if (cmbWeek.Text.Length == 39)
                {
                    week = cmbWeek.Text;
                    week = week.Substring(17, 10);
                }
                else
                {
                    week = cmbWeek.Text;
                    week = week.Substring(18, 10);
                }
            }
        }

        //Extrae la fecha en formato (dd/mm/yyyy)
        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbMonth.SelectedIndex > 0)
            {
                string today;
                string year = string.Empty;
                today = cmbMonth.Text.Trim();
                month = today.Substring(4, 3);
                year = today.Substring((today.Length - 4), 4).Trim();

                if (month == "Ene")
                    month = "01-01-" + year;
                else if (month == "Feb")
                    month = "01-02-" + year;
                else if (month == "Mar")
                    month = "01-03-" + year;
                else if (month == "Abr")
                    month = "01-04-" + year;
                else if (month == "May")
                    month = "01-05-" + year;
                else if (month == "Jun")
                    month = "01-06-" + year;
                else if (month == "Jul")
                    month = "01-07-" + year;
                else if (month == "Ago")
                    month = "01-08-" + year;
                else if (month == "Sep")
                    month = "01-09-" + year;
                else if (month == "Oct")
                    month = "01-10-" + year;
                else if (month == "Nov")
                    month = "01-11-" + year;
                else if (month == "Dic")
                    month = "01-12-" + year;
            }
        }

        #endregion

        #region ===== Back to a Previous Usercontrol or Validate Enter KeyDown =====

        /// <summary>
        /// Este se usa para todos los controles en general si se oprime 
        /// Esc se manda a el User control de  Welcome
        /// Enter se manda la accion de botón de Aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }

            if (e.KeyData == Keys.Enter)
            {
                btnAccept_Click(sender, e);
            }
            
            if (e.KeyCode == Keys.Down)
            {
                if (lbAgent.Items.Count > 0)
                {
                    lbAgent.SelectedIndex = 0;
                    lbAgent.Focus();
                }
            }
        }

        #endregion

        #region===== MethodsClass =====

        /// <summary>
        /// Valida los campos que son obligatorios 
        /// </summary>
        private bool IsValidateBusinessRules
        {
            get
            {
                if (rol && string.IsNullOrEmpty(txtAgent.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESE_AGENTE_PARA_GENERAR_REPORTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAgent.Focus();
                    return false;
                }
                else if (rdoMonth.Checked == false &&
                    rdoWeek.Checked == false)
                {
                    MessageBox.Show(Resources.Reservations.SELECCIONE_ALGUNA_OPCIÓN, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rdoWeek.Focus();
                    return false;
                }
                else if (cmbWeek.SelectedIndex <= 0 && cmbMonth.SelectedIndex <= 0)
                {
                    MessageBox.Show(Resources.Reservations.INDIQUE_FECHAS_REPORTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbWeek.Focus();
                    return false;
                }
                else
                    return true;
            }
        }

        /// <summary>
        /// Extrae la lista de los dias de las semanas que han transcurrido
        /// </summary>
        private void FillWeeks()
        {
            List<ProductivityWeeks> listWeeks = ProductivityWeeksBL.GetProductivityWeeks();
            bindingSource1.DataSource = listWeeks;
            foreach (ProductivityWeeks weeksItem in listWeeks)
            {
                ListItem litem = new ListItem();
                litem.Text = string.Format("{0}", weeksItem.Weeks);
                cmbWeek.Items.Add(litem);
            }
        }

        /// <summary>
        /// Extrae la lista de los meses que han transcurrido
        /// </summary>
        private void FillMonths()
        {
            List<ProductivityMonths> listMonths = ProductivityMonthsBL.GetProductivityMonths();
            bindingSource2.DataSource = listMonths;
            foreach (ProductivityMonths monthsItem in listMonths)
            {
                ListItem litem = new ListItem();
                litem.Text = string.Format("{0}", monthsItem.Months);
                litem.Value = monthsItem.Months;
                cmbMonth.Items.Add(litem);
            }
        }

        //Llama los metodos de Extracción y Creación del Excel
        private void Generation()
        {
            DataExtract();
        }

        //Extrae los Datos de la semana, mes o acumulado 
        private void DataExtract()
        {
            List<UserProductivityGeneric> listProductivity = null;
            List<UserProductivityGeneric> listProductivity2 = null;
            if (rdoWeek.Checked)
            {
                if (rol)
                {
                    listProductivity =
                    UserProductivityGenericBL.GetUserProductivityPerWeek(txtAgent.Text, week);
                }
                else
                {
                    listProductivity =
                    UserProductivityGenericBL.GetUserProductivityPerWeek(Login.Agent, week);
                }
                if (listProductivity.Count > 0)
                {
                    initialDate = string.Concat(initialDate, "Del  ", listProductivity[0].InitialDate1, "  Al  ", listProductivity[0].FinalDate1);
                    finalDate = string.Concat(finalDate, "Del  ", listProductivity[0].InitialDate2, "  Al  ", listProductivity[0].FinalDate2);
                    workingDays = string.Concat(workingDays, "*Los días laborables considerados para esta semana son: ", Convert.ToString(listProductivity[0].LabourDays1));
                    workingDays2 = string.Concat(workingDays2, "**Los días laborables considerados para esta semana son: ", Convert.ToString(listProductivity[0].LabourDays2));
                }
            }
            else if (rdoMonth.Checked)
            {
                if (rol)
                {
                    listProductivity2 =
                    UserProductivityGenericBL.GetUserProductivityPerMonth(txtAgent.Text, month);
                }
                else
                {
                    listProductivity2 =
                    UserProductivityGenericBL.GetUserProductivityPerMonth(Login.Agent, month);
                }
                if (listProductivity2.Count > 0)
                {
                    initialDate2 = string.Concat(initialDate2, "Del  ", listProductivity2[0].InitialDate1, "  Al  ", listProductivity2[0].FinalDate1);
                    finalDate2 = string.Concat(finalDate2, "Del  ", listProductivity2[0].InitialDate2, "  Al  ", listProductivity2[0].FinalDate2);
                    workingDays3 = string.Concat(workingDays3, "*Los días laborables considerados para este mes son: ", Convert.ToString(listProductivity2[0].LabourDays1));
                    workingDays4 = string.Concat(workingDays4, "**Los días laborables considerados para este mes son: ", Convert.ToString(listProductivity2[0].LabourDays2));
                }
            }

            //Por ahorita no se ocupa es comparativo del año
            List<UserProductivityGeneric> listProductivity3 = null;
            // UserProductivityGenericBL.GetUserProductivityPerAccumulated(Login.Agent);

            #region ===== Extact =====

            //if (listProductivity3.Count > 0)
            //{
            //    initialDate3 = string.Concat(initialDate3, "Del  ", listProductivity3[0].InitialDate1, "  Al  ", listProductivity3[0].FinalDate1);
            //    finalDate3 = string.Concat(finalDate3, "Del  ", listProductivity3[0].InitialDate2, "  Al  ", listProductivity3[0].FinalDate2);
            //    workingDays5 = string.Concat(workingDays5, "*Los días laborables considerados para este acumulativo son: ", Convert.ToString(listProductivity3[0].LabourDays1));
            //    workingDays6 = string.Concat(workingDays6, "**Los días laborables considerados para este acumulativo son: ", Convert.ToString(listProductivity3[0].LabourDays2));
            //}

            #endregion

            if (listProductivity != null && listProductivity.Count > 0 ||
                listProductivity2 != null && listProductivity2.Count > 0 ||
                listProductivity3 != null && listProductivity3.Count > 0)
                    CreateExcel(listProductivity, listProductivity2, listProductivity3);
            else
            {
                AsyncCallback callback = new AsyncCallback(OnCompleted);
            }
        }

        //Crea el archivo de Excel
        private void CreateExcel(List<UserProductivityGeneric> listProductivity, List<UserProductivityGeneric> listProductivity2,
                                 List<UserProductivityGeneric> listProductivity3)
        {
            Microsoft.VisualBasic.Devices.Computer MyComputer = new Microsoft.VisualBasic.Devices.Computer();
            string fileName = string.Empty; //Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);

            #region ===== Generating Excel Document ======

            using (Components.MyCTSExcel MyCTSExcel = new Components.MyCTSExcel())
            {
                if (rdoWeek.Checked)
                {
                    //objExcel.CreateExcelObject(new string[] { "MyCTSProductividadAcumulativa", "MyCTSProductividadSemanal" });
                    MyCTSExcel.CreateExcelObject("MyCTSProductividadSemanal");
                }
                else
                {
                    //objExcel.CreateExcelObject(new string[] { "MyCTSProductividadAcumulativa", "MyCTSProductividadMensual" });
                    MyCTSExcel.CreateExcelObject("MyCTSProductividadMensual");
                }
                if (MyCTSExcel.IsObjectCreated)
                {
                    string date = Convert.ToString(DateTime.Now).Substring(0, 10);
                    MyCTSExcel.Cell cell = null;
                    fileName = MyComputer.FileSystem.SpecialDirectories.Temp;
                    fileName = fileName + string.Format("\\TempFile_{0}.xls", Guid.NewGuid().ToString());

                    if (rdoWeek.Checked)
                    {
                        #region ===== Headers ======

                        cell = new MyCTSExcel.Cell(1, 4, "REPORTE DE PRODUCTIVIDAD DE RESERVACIONES HECHAS EN MyCTS");
                        cell.FontColor = Color.Blue;
                        cell.ShowBorder = false;
                        cell.Bold = true;
                        cell.Wide = 6;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(2, 1, "Agente evaluado:");
                        cell.FontSize = 11;
                        cell.ShowBorder = false;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(2, 2, listProductivity[0].FamilyName);
                        cell.FontSize = 11;
                        cell.ShowBorder = false;
                        cell.Wide = 3;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(3, 1, "Fecha de Elaboración:");
                        cell.FontSize = 11;
                        cell.ShowBorder = false;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(3, 2, date);
                        cell.ShowBorder = false;
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(4, 2, initialDate);
                        cell.ShowBorder = false;
                        cell.FontColor = Color.Blue;
                        cell.Wide = 3;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(5, 2, "Semana Actual");
                        cell.Bold = true;
                        cell.ShowBorder = false;
                        cell.FontColor = Color.Brown;
                        cell.Wide = 3;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(6, 1, "Categoria por Segmentos");
                        cell.Bold = true;
                        cell.ShowBorder = false;
                        cell.FontColor = Color.Blue;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(7, 1, "Segmentos Aereos");
                        cell.ShowBorder = false;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(8, 1, "Segmentos Hotel");
                        cell.ShowBorder = false;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(9, 1, "Segmentos Auto");
                        cell.ShowBorder = false;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(10, 1, "Total de Segmentos");
                        cell.ShowBorder = false;
                        cell.Bold = true;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(13, 1, "Categoria por Recods");
                        cell.ShowBorder = false;
                        cell.Bold = true;
                        cell.FontColor = Color.Blue;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(14, 1, "Records Creados");
                        cell.ShowBorder = false;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(15, 1, "Records Cancelados");
                        cell.ShowBorder = false;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(16, 1, "Scans Promedio por record");
                        cell.ShowBorder = false;
                        cell.Bold = true;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(18, 1, "Categoria por Boleto");
                        cell.ShowBorder = false;
                        cell.Bold = true;
                        cell.FontColor = Color.Blue;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(19, 1, "Boletos Emitidos");
                        cell.ShowBorder = false;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(20, 1, "Boletos Cancelados");
                        cell.ShowBorder = false;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(22, 1, "Efectividad Record Vs Boleto");
                        cell.ShowBorder = false;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(6, 2, "Cantidad");
                        cell.Bold = true;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(6, 3, "Promedio \n" + "Corporativo");
                        cell.Bold = true;
                        cell.WrapText = false;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(6, 4, "%Productividad Vs \n" + "Promedio Corporativo \n");
                        cell.Bold = true;
                        cell.Wide = 1;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(4, 7, finalDate);
                        cell.FontColor = Color.Blue;
                        cell.ShowBorder = false;
                        cell.Wide = 3;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(5, 7, "Semana Anterior");
                        cell.Bold = true;
                        cell.ShowBorder = false;
                        cell.FontColor = Color.Brown;
                        cell.Wide = 3;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(6, 7, "Cantidad");
                        cell.Bold = true;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(6, 8, "Promedio \n" + "Corporativo");
                        cell.Bold = true;
                        cell.WrapText = true;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(6, 9, "%Productividad Vs \n" + "Promedio Corporativo \n");
                        cell.Bold = true;
                        cell.Wide = 1;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(13, 2, "Cantidad");
                        cell.Bold = true;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(13, 3, "Promedio \n" + "Corporativo");
                        cell.Bold = true;
                        cell.WrapText = true;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(13, 4, "%Productividad Vs \n" + "Promedio Corporativo \n");
                        cell.Bold = true;
                        cell.Wide = 1;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(13, 7, "Cantidad");
                        cell.Bold = true;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(13, 8, "Promedio \n" + "Corporativo");
                        cell.Bold = true;
                        cell.WrapText = true;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(13, 9, "%Productividad Vs \n" + "Promedio Corporativo \n");
                        cell.Bold = true;
                        cell.Wide = 1;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(18, 2, "Cantidad");
                        cell.Bold = true;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(18, 3, "Promedio \n" + "Corporativo");
                        cell.Bold = true;
                        cell.WrapText = true;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);


                        cell = new MyCTSExcel.Cell(18, 4, "%Productividad Vs \n" + "Promedio Corporativo \n");
                        cell.Bold = true;
                        cell.Wide = 1;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(18, 7, "Cantidad");
                        cell.Bold = true;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(18, 8, "Promedio \n" + "Corporativo");
                        cell.Bold = true;
                        cell.WrapText = true;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(18, 9, "%Productividad Vs \n" + "Promedio Corporativo \n");
                        cell.Bold = true;
                        cell.Wide = 1;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(6, 12, "%Productividad \n  semana actual Vs \n" + "semana anterior \n");
                        cell.WrapText = true;
                        cell.Bold = true;
                        cell.Wide = 1;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(13, 12, "%Productividad \n semana actual Vs \n" + "semana anterior \n");
                        cell.WrapText = true;
                        cell.Bold = true;
                        cell.Wide = 1;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(18, 12, "%Productividad \n semana actual Vs \n" + "semana anterior \n");
                        cell.WrapText = true;
                        cell.Bold = true;
                        cell.Wide = 1;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(24, 2, workingDays);
                        cell.Bold = true;
                        cell.ShowBorder = false;
                        cell.FontSize = 8;
                        cell.Wide = 4;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(24, 7, workingDays2);
                        cell.Bold = true;
                        cell.ShowBorder = false;
                        cell.FontSize = 8;
                        cell.Wide = 4;
                        MyCTSExcel.CreateCell(cell);

                        #endregion

                        #region ====== Elements =====

                        //Segmentos
                        cell = new MyCTSExcel.Cell(7, 2, Convert.ToString(listProductivity[0].AirSegment1));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(8, 2, Convert.ToString(listProductivity[0].HotelSegment1));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(9, 2, Convert.ToString(listProductivity[0].AutoSegment1));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(10, 2, Convert.ToString(listProductivity[0].TotalSegment1));
                        cell.Bold = true;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(7, 3, Convert.ToString(listProductivity[0].AvgAirSegment1));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(8, 3, Convert.ToString(listProductivity[0].AvgHotelSegment1));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(9, 3, Convert.ToString(listProductivity[0].AvgAutoSegment1));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(10, 3, Convert.ToString(listProductivity[0].AvgTotalSegment1));
                        cell.Bold = true;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(7, 4, Convert.ToString(listProductivity[0].AirSegmentProductivity1 + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(8, 4, Convert.ToString(listProductivity[0].HotelSegmentProductivity1 + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(9, 4, Convert.ToString(listProductivity[0].AutoSegmentProductivity1 + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(10, 4, Convert.ToString(listProductivity[0].TotalSegmentProductivity1 + "%"));
                        cell.Bold = true;
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(7, 7, Convert.ToString(listProductivity[0].AirSegment2));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(8, 7, Convert.ToString(listProductivity[0].HotelSegment2));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(9, 7, Convert.ToString(listProductivity[0].AutoSegment2));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(10, 7, Convert.ToString(listProductivity[0].TotalSegment2));
                        cell.Bold = true;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(7, 8, Convert.ToString(listProductivity[0].AvgAirSegment2));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(8, 8, Convert.ToString(listProductivity[0].AvgHotelSegment2));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(9, 8, Convert.ToString(listProductivity[0].AvgAutoSegment2));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(10, 8, Convert.ToString(listProductivity[0].AvgTotalSegment2));
                        cell.Bold = true;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(7, 9, Convert.ToString(listProductivity[0].AirSegmentProductivity2 + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(8, 9, Convert.ToString(listProductivity[0].HotelSegmentProductivity2 + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(9, 9, Convert.ToString(listProductivity[0].AutoSegmentProductivity2 + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(10, 9, Convert.ToString(listProductivity[0].TotalSegmentProductivity2 + "%"));
                        cell.Bold = true;
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);

                        //Records
                        cell = new MyCTSExcel.Cell(14, 2, Convert.ToString(listProductivity[0].TotalPNR1));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(15, 2, Convert.ToString(listProductivity[0].CancelledPNR1));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(16, 2, Convert.ToString(listProductivity[0].ScansAverage1));
                        cell.Bold = true;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(14, 3, Convert.ToString(listProductivity[0].AvgRecords1));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(15, 3, Convert.ToString(listProductivity[0].AvgCancelledRecords1));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(16, 3, Convert.ToString(listProductivity[0].AvgScanAvgPerRecord1));
                        cell.Bold = true;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(14, 4, Convert.ToString(listProductivity[0].RecordsProductivity1 + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(15, 4, Convert.ToString(listProductivity[0].CancelledRecordsProductivity1 + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(16, 4, Convert.ToString(listProductivity[0].AvgScanPerRecordProductivity1 + "%"));
                        cell.Bold = true;
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(14, 7, Convert.ToString(listProductivity[0].TotalPNR2));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(15, 7, Convert.ToString(listProductivity[0].CancelledPNR2));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(16, 7, Convert.ToString(listProductivity[0].ScansAverage2));
                        cell.Bold = true;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(14, 8, Convert.ToString(listProductivity[0].AvgRecords2));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(15, 8, Convert.ToString(listProductivity[0].AvgCancelledRecords2));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(16, 8, Convert.ToString(listProductivity[0].AvgScanAvgPerRecord2));
                        cell.Bold = true;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(14, 9, Convert.ToString(listProductivity[0].RecordsProductivity2 + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(15, 9, Convert.ToString(listProductivity[0].CancelledRecordsProductivity2 + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(16, 9, Convert.ToString(listProductivity[0].AvgScanPerRecordProductivity2 + "%"));
                        cell.Bold = true;
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);

                        //Boletos Emitidos
                        cell = new MyCTSExcel.Cell(19, 2, Convert.ToString(listProductivity[0].EmittedTKT1));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(20, 2, Convert.ToString(listProductivity[0].CancelledTKT1));
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(19, 3, Convert.ToString(listProductivity[0].AvgEmittedTKT1));
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(20, 3, Convert.ToString(listProductivity[0].AvgCancelledTKT1));
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(19, 4, Convert.ToString(listProductivity[0].EmittedTKTProductivity1 + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(20, 4, Convert.ToString(listProductivity[0].CancelledTKTProductivity1 + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(19, 7, Convert.ToString(listProductivity[0].EmittedTKT2));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(20, 7, Convert.ToString(listProductivity[0].CancelledTKT2));
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(19, 8, Convert.ToString(listProductivity[0].AvgEmittedTKT2));
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(20, 8, Convert.ToString(listProductivity[0].AvgCancelledTKT2));
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(19, 9, Convert.ToString(listProductivity[0].EmittedTKTProductivity2 + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(20, 9, Convert.ToString(listProductivity[0].CancelledTKTProductivity2 + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);

                        //Efectividad
                        cell = new MyCTSExcel.Cell(22, 2, Convert.ToString(listProductivity[0].RecordVsTicket1 + "%"));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(22, 3, Convert.ToString(listProductivity[0].AvgRecordVsTicket1 + "%"));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(22, 4, Convert.ToString(listProductivity[0].TotalRecordVsTKTProductivity1 + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(22, 7, Convert.ToString(listProductivity[0].RecordVsTicket2 + "%"));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(22, 8, Convert.ToString(listProductivity[0].AvgRecordVsTicket2 + "%"));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(22, 9, Convert.ToString(listProductivity[0].TotalRecordVsTKTProductivity2 + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);

                        //Productividad entre semanas
                        cell = new MyCTSExcel.Cell(7, 12, Convert.ToString(listProductivity[0].AirSegmentProductivity + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(8, 12, Convert.ToString(listProductivity[0].HotelSegmentProductivity + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(9, 12, Convert.ToString(listProductivity[0].AutoSegmentProductivity + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(10, 12, Convert.ToString(listProductivity[0].TotalSegmentProductivity + "%"));
                        cell.Bold = true;
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(14, 12, Convert.ToString(listProductivity[0].TotalRecordsProductivity + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(15, 12, Convert.ToString(listProductivity[0].CancelledRecordsProductivity + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(16, 12, Convert.ToString(listProductivity[0].ScansAverageProductivity + "%"));
                        cell.Bold = true;
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(19, 12, Convert.ToString(listProductivity[0].EmittedTKTProductivity + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(20, 12, Convert.ToString(listProductivity[0].CancelledTKTProductivity + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(22, 12, Convert.ToString(listProductivity[0].RecordVsTKTProductivity + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);

                        #endregion
                    }
                    else
                    {
                        #region ===== Headers ======

                        cell = new MyCTSExcel.Cell(1, 4, "REPORTE DE PRODUCTIVIDAD DE RESERVACIONES HECHAS EN MyCTS");
                        cell.FontColor = Color.Blue;
                        cell.ShowBorder = false;
                        cell.Bold = true;
                        cell.Wide = 6;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(2, 1, "Agente evaluado:");
                        cell.FontSize = 11;
                        cell.ShowBorder = false;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(2, 2, listProductivity2[0].FamilyName);
                        cell.FontSize = 11;
                        cell.ShowBorder = false;
                        cell.Wide = 3;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(3, 1, "Fecha de Elaboración:");
                        cell.FontSize = 11;
                        cell.ShowBorder = false;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(3, 2, date);
                        cell.ShowBorder = false;
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(4, 2, initialDate2);
                        cell.ShowBorder = false;
                        cell.FontColor = Color.Blue;
                        cell.Wide = 3;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(5, 2, "Mes Actual");
                        cell.Bold = true;
                        cell.ShowBorder = false;
                        cell.FontColor = Color.Brown;
                        cell.Wide = 3;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(6, 1, "Categoria por Segmentos");
                        cell.Bold = true;
                        cell.ShowBorder = false;
                        cell.FontColor = Color.Blue;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(7, 1, "Segmentos Aereos");
                        cell.ShowBorder = false;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(8, 1, "Segmentos Hotel");
                        cell.ShowBorder = false;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(9, 1, "Segmentos Auto");
                        cell.ShowBorder = false;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(10, 1, "Total de Segmentos");
                        cell.ShowBorder = false;
                        cell.Bold = true;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(13, 1, "Categoria por Recods");
                        cell.ShowBorder = false;
                        cell.Bold = true;
                        cell.FontColor = Color.Blue;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(14, 1, "Records Creados");
                        cell.ShowBorder = false;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(15, 1, "Records Cancelados");
                        cell.ShowBorder = false;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(16, 1, "Scans Promedio por record");
                        cell.ShowBorder = false;
                        cell.Bold = true;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(18, 1, "Categoria por Boleto");
                        cell.ShowBorder = false;
                        cell.Bold = true;
                        cell.FontColor = Color.Blue;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(19, 1, "Boletos Emitidos");
                        cell.ShowBorder = false;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(20, 1, "Boletos Cancelados");
                        cell.ShowBorder = false;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(22, 1, "Efectividad Record Vs Boleto");
                        cell.ShowBorder = false;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(6, 2, "Cantidad");
                        cell.Bold = true;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(6, 3, "Promedio \n" + "Corporativo");
                        cell.Bold = true;
                        cell.WrapText = false;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(6, 4, "%Productividad Vs \n" + "Promedio Corporativo \n");
                        cell.Bold = true;
                        cell.Wide = 1;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(4, 7, finalDate2);
                        cell.FontColor = Color.Blue;
                        cell.ShowBorder = false;
                        cell.Wide = 3;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(5, 7, "Mes Anterior");
                        cell.Bold = true;
                        cell.ShowBorder = false;
                        cell.FontColor = Color.Brown;
                        cell.Wide = 3;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(6, 7, "Cantidad");
                        cell.Bold = true;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(6, 8, "Promedio \n" + "Corporativo");
                        cell.Bold = true;
                        cell.WrapText = true;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(6, 9, "%Productividad Vs \n" + "Promedio Corporativo \n");
                        cell.Bold = true;
                        cell.Wide = 1;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(13, 2, "Cantidad");
                        cell.Bold = true;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(13, 3, "Promedio \n" + "Corporativo");
                        cell.Bold = true;
                        cell.WrapText = true;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(13, 4, "%Productividad Vs \n" + "Promedio Corporativo \n");
                        cell.Bold = true;
                        cell.Wide = 1;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(13, 7, "Cantidad");
                        cell.Bold = true;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(13, 8, "Promedio \n" + "Corporativo");
                        cell.Bold = true;
                        cell.WrapText = true;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(13, 9, "%Productividad Vs \n" + "Promedio Corporativo \n");
                        cell.Bold = true;
                        cell.Wide = 1;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(18, 2, "Cantidad");
                        cell.Bold = true;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(18, 3, "Promedio \n" + "Corporativo");
                        cell.Bold = true;
                        cell.WrapText = true;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);


                        cell = new MyCTSExcel.Cell(18, 4, "%Productividad Vs \n" + "Promedio Corporativo \n");
                        cell.Bold = true;
                        cell.Wide = 1;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(18, 7, "Cantidad");
                        cell.Bold = true;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(18, 8, "Promedio \n" + "Corporativo");
                        cell.Bold = true;
                        cell.WrapText = true;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(18, 9, "%Productividad Vs \n" + "Promedio Corporativo \n");
                        cell.Bold = true;
                        cell.Wide = 1;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(6, 12, "%Productividad \n  mes actual Vs \n" + "mes anterior \n");
                        cell.Bold = true;
                        cell.Wide = 1;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(13, 12, "%Productividad \n  mes actual Vs \n" + "mes anterior \n");
                        cell.Bold = true;
                        cell.Wide = 1;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(18, 12, "%Productividad \n  mes actual Vs \n" + "mes anterior \n");
                        cell.Bold = true;
                        cell.Wide = 1;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(24, 2, workingDays3);
                        cell.Bold = true;
                        cell.ShowBorder = false;
                        cell.FontSize = 8;
                        cell.Wide = 4;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(24, 7, workingDays4);
                        cell.Bold = true;
                        cell.ShowBorder = false;
                        cell.FontSize = 8;
                        cell.Wide = 4;
                        MyCTSExcel.CreateCell(cell);

                        #endregion

                        #region ====== Elements =====

                        //Segmentos
                        cell = new MyCTSExcel.Cell(7, 2, Convert.ToString(listProductivity2[0].AirSegment1));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(8, 2, Convert.ToString(listProductivity2[0].HotelSegment1));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(9, 2, Convert.ToString(listProductivity2[0].AutoSegment1));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(10, 2, Convert.ToString(listProductivity2[0].TotalSegment1));
                        cell.Bold = true;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(7, 3, Convert.ToString(listProductivity2[0].AvgAirSegment1));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(8, 3, Convert.ToString(listProductivity2[0].AvgHotelSegment1));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(9, 3, Convert.ToString(listProductivity2[0].AvgAutoSegment1));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(10, 3, Convert.ToString(listProductivity2[0].AvgTotalSegment1));
                        cell.Bold = true;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(7, 4, Convert.ToString(listProductivity2[0].AirSegmentProductivity1 + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(8, 4, Convert.ToString(listProductivity2[0].HotelSegmentProductivity1 + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(9, 4, Convert.ToString(listProductivity2[0].AutoSegmentProductivity1 + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(10, 4, Convert.ToString(listProductivity2[0].TotalSegmentProductivity1 + "%"));
                        cell.Bold = true;
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(7, 7, Convert.ToString(listProductivity2[0].AirSegment2));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(8, 7, Convert.ToString(listProductivity2[0].HotelSegment2));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(9, 7, Convert.ToString(listProductivity2[0].AutoSegment2));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(10, 7, Convert.ToString(listProductivity2[0].TotalSegment2));
                        cell.Bold = true;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(7, 8, Convert.ToString(listProductivity2[0].AvgAirSegment2));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(8, 8, Convert.ToString(listProductivity2[0].AvgHotelSegment2));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(9, 8, Convert.ToString(listProductivity2[0].AvgAutoSegment2));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(10, 8, Convert.ToString(listProductivity2[0].AvgTotalSegment2));
                        cell.Bold = true;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(7, 9, Convert.ToString(listProductivity2[0].AirSegmentProductivity2 + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(8, 9, Convert.ToString(listProductivity2[0].HotelSegmentProductivity2 + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(9, 9, Convert.ToString(listProductivity2[0].AutoSegmentProductivity2 + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(10, 9, Convert.ToString(listProductivity2[0].TotalSegmentProductivity2 + "%"));
                        cell.Bold = true;
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);

                        //Records
                        cell = new MyCTSExcel.Cell(14, 2, Convert.ToString(listProductivity2[0].TotalPNR1));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(15, 2, Convert.ToString(listProductivity2[0].CancelledPNR1));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(16, 2, Convert.ToString(listProductivity2[0].ScansAverage1));
                        cell.Bold = true;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(14, 3, Convert.ToString(listProductivity2[0].AvgRecords1));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(15, 3, Convert.ToString(listProductivity2[0].AvgCancelledRecords1));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(16, 3, Convert.ToString(listProductivity2[0].AvgScanAvgPerRecord1));
                        cell.Bold = true;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(14, 4, Convert.ToString(listProductivity2[0].RecordsProductivity1 + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(15, 4, Convert.ToString(listProductivity2[0].CancelledRecordsProductivity1 + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(16, 4, Convert.ToString(listProductivity2[0].AvgScanPerRecordProductivity1 + "%"));
                        cell.Bold = true;
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(14, 7, Convert.ToString(listProductivity2[0].TotalPNR2));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(15, 7, Convert.ToString(listProductivity2[0].CancelledPNR2));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(16, 7, Convert.ToString(listProductivity2[0].ScansAverage2));
                        cell.Bold = true;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(14, 8, Convert.ToString(listProductivity2[0].AvgRecords2));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(15, 8, Convert.ToString(listProductivity2[0].AvgCancelledRecords2));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(16, 8, Convert.ToString(listProductivity2[0].AvgScanAvgPerRecord2));
                        cell.Bold = true;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(14, 9, Convert.ToString(listProductivity2[0].RecordsProductivity2 + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(15, 9, Convert.ToString(listProductivity2[0].CancelledRecordsProductivity2 + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(16, 9, Convert.ToString(listProductivity2[0].AvgScanPerRecordProductivity2 + "%"));
                        cell.Bold = true;
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);

                        //Boletos Emitidos
                        cell = new MyCTSExcel.Cell(19, 2, Convert.ToString(listProductivity2[0].EmittedTKT1));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(20, 2, Convert.ToString(listProductivity2[0].CancelledTKT1));
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(19, 3, Convert.ToString(listProductivity2[0].AvgEmittedTKT1));
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(20, 3, Convert.ToString(listProductivity2[0].AvgCancelledTKT1));
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(19, 4, Convert.ToString(listProductivity2[0].EmittedTKTProductivity1 + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(20, 4, Convert.ToString(listProductivity2[0].CancelledTKTProductivity1 + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(19, 7, Convert.ToString(listProductivity2[0].EmittedTKT2));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(20, 7, Convert.ToString(listProductivity2[0].CancelledTKT2));
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(19, 8, Convert.ToString(listProductivity2[0].AvgEmittedTKT2));
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(20, 8, Convert.ToString(listProductivity2[0].AvgCancelledTKT2));
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(19, 9, Convert.ToString(listProductivity2[0].EmittedTKTProductivity2 + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(20, 9, Convert.ToString(listProductivity2[0].CancelledTKTProductivity2 + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);

                        //Efectividad
                        cell = new MyCTSExcel.Cell(22, 2, Convert.ToString(listProductivity2[0].RecordVsTicket1 + "%"));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(22, 3, Convert.ToString(listProductivity2[0].AvgRecordVsTicket1 + "%"));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(22, 4, Convert.ToString(listProductivity2[0].TotalRecordVsTKTProductivity1 + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(22, 7, Convert.ToString(listProductivity2[0].RecordVsTicket2 + "%"));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(22, 8, Convert.ToString(listProductivity2[0].AvgRecordVsTicket2 + "%"));
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(22, 9, Convert.ToString(listProductivity2[0].TotalRecordVsTKTProductivity2 + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);

                        //Productividad entre semanas
                        cell = new MyCTSExcel.Cell(7, 12, Convert.ToString(listProductivity2[0].AirSegmentProductivity + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(8, 12, Convert.ToString(listProductivity2[0].HotelSegmentProductivity + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(9, 12, Convert.ToString(listProductivity2[0].AutoSegmentProductivity + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(10, 12, Convert.ToString(listProductivity2[0].TotalSegmentProductivity + "%"));
                        cell.Bold = true;
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(14, 12, Convert.ToString(listProductivity2[0].TotalRecordsProductivity + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(15, 12, Convert.ToString(listProductivity2[0].CancelledRecordsProductivity + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(16, 12, Convert.ToString(listProductivity2[0].ScansAverageProductivity + "%"));
                        cell.Bold = true;
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(19, 12, Convert.ToString(listProductivity2[0].EmittedTKTProductivity + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(20, 12, Convert.ToString(listProductivity2[0].CancelledTKTProductivity + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(22, 12, Convert.ToString(listProductivity2[0].RecordVsTKTProductivity + "%"));
                        cell.Wide = 1;
                        MyCTSExcel.CreateCell(cell);

                        #endregion
                    }
                    
                    #region===== Por ahorita no se ocupa Comparativo año =======

                    //#region ===== Headers ======

                    //objExcel.WorkSheetIndex = 2;
                    //objExcel.CreateCell2(1, 1, 4, "REPORTE DE PRODUCTIVIDAD DE RESERVACIONES HECHAS EN MyCTS", true, 6, -1, 10);
                    //objExcel.CreateCell(1, 2, 1, "Agente evaluado:", 11, -1);
                    //objExcel.CreateCell2(1, 2, 2, listProductivity3[0].FamilyName, false, 2, -1, 11);
                    //objExcel.CreateCell(1, 3, 1, "Fecha de Elaboración:", 11, -1);
                    //objExcel.CreateCell2(1, 3, 2, listProductivity3[0].ReportDate, false, 1, -1, 10);

                    //objExcel.CreateCell2(5, 4, 2, initialDate3, false, 3, -1, 10);
                    //objExcel.CreateCell2(9, 5, 2, "Acumulativo Actual", true, 3, -1, 10);

                    //objExcel.CreateCell(5, 6, 1, "Categoria por Segmentos", true, -1);
                    //objExcel.CreateCell(1, 7, 1, "Segmentos Aereos", false, -1);
                    //objExcel.CreateCell(1, 8, 1, "Segmentos Hotel", false, -1);
                    //objExcel.CreateCell(1, 9, 1, "Segmentos Auto", false, -1);
                    ////objExcel.CreateCell(1, 10, 1, "Segmentos Otros", false, -1);
                    //objExcel.CreateCell(1, 10, 1, "Total de Segmentos", true, -1);


                    //objExcel.CreateCell(5, 13, 1, "Categoria por Recods", true, -1);
                    //objExcel.CreateCell(1, 14, 1, "Records", false, -1);
                    //objExcel.CreateCell(1, 15, 1, "Records Cancelados", false, -1);
                    //objExcel.CreateCell(1, 16, 1, "Scans Promedio por record", true, -1);

                    //objExcel.CreateCell(5, 18, 1, "Categoria por Boleto", true, -1);
                    //objExcel.CreateCell(1, 19, 1, "Boletos Emitidos", false, -1);
                    //objExcel.CreateCell(1, 20, 1, "Boletos Cancelados", false, -1);

                    //objExcel.CreateCell(1, 22, 1, "Efectividad Record Vs Boleto", false, -1);


                    //objExcel.CreateCell(1, 6, 2, "Cantidad", true);
                    //objExcel.CreateCell(1, 6, 3, "Promedio" + "\n" + "Corporativo", true);
                    //objExcel.CreateCell2(1, 6, 4, "%Productividad Vs" + "\n" + "Promedio Corporativo", true, 1, 10);

                    //objExcel.CreateCell2(5, 4, 7, finalDate3, false, 3, -1, 10);
                    //objExcel.CreateCell2(9, 5, 7, "Acumulativo Anterior", true, 3, -1, 10);
                    //objExcel.CreateCell(1, 6, 7, "Cantidad", true);
                    //objExcel.CreateCell(1, 6, 8, "Promedio" + "\n" + "Corporativo", true);
                    //objExcel.CreateCell2(1, 6, 9, "%Productividad Vs" + "\n" + "Promedio Corporativo", true, 1, 10);

                    //objExcel.CreateCell(1, 13, 2, "Cantidad", true);
                    //objExcel.CreateCell(1, 13, 3, "Promedio" + "\n" + "Corporativo", true);
                    //objExcel.CreateCell2(1, 13, 4, "%Productividad Vs" + "\n" + "Promedio Corporativo", true, 1, 10);

                    //objExcel.CreateCell(1, 13, 7, "Cantidad", true);
                    //objExcel.CreateCell(1, 13, 8, "Promedio" + "\n" + "Corporativo", true);
                    //objExcel.CreateCell2(1, 13, 9, "%Productividad Vs" + "\n" + "Promedio Corporativo", true, 1, 10);


                    //objExcel.CreateCell(1, 18, 2, "Cantidad", true);
                    //objExcel.CreateCell(1, 18, 3, "Promedio" + "\n" + "Corporativo", true);
                    //objExcel.CreateCell2(1, 18, 4, "%Productividad Vs" + "\n" + "Promedio Corporativo", true, 1, 10);

                    //objExcel.CreateCell(1, 18, 7, "Cantidad", true);
                    //objExcel.CreateCell(1, 18, 8, "Promedio" + "\n" + "Corporativo", true);
                    //objExcel.CreateCell2(1, 18, 9, "%Productividad Vs" + "\n" + "Promedio Corporativo", true, 1, 10);

                    //objExcel.CreateCell2(1, 6, 12, "%Productividad acumulado actual" + "\n" + "Vs semana anterior", true, 1, 10);
                    //objExcel.CreateCell2(1, 13, 12, "%Productividad acumulado actual" + "\n" + "Vs semana anterior", true, 1, 10);
                    //objExcel.CreateCell2(1, 18, 12, "%Productividad acumulado actual" + "\n" + "Vs semana anterior", true, 1, 10);


                    //objExcel.CreateCell2(1, 24, 2, workingDays5, true, 3, -1, 8);
                    //objExcel.CreateCell2(1, 24, 7, workingDays6, true, 3, -1, 8);


                    //#endregion

                    //#region ====== Elements =====

                    ////Segmentos
                    //objExcel.CreateCell(1, 7, 2, Convert.ToString(listProductivity3[0].AirSegment1));
                    //objExcel.CreateCell(1, 8, 2, Convert.ToString(listProductivity3[0].HotelSegment1));
                    //objExcel.CreateCell(1, 9, 2, Convert.ToString(listProductivity3[0].AutoSegment1));
                    //objExcel.CreateCell(1, 10, 2, Convert.ToString(listProductivity3[0].TotalSegment1), true);

                    //objExcel.CreateCell(1, 7, 3, Convert.ToString(listProductivity3[0].AvgAirSegment1));
                    //objExcel.CreateCell(1, 8, 3, Convert.ToString(listProductivity3[0].AvgHotelSegment1));
                    //objExcel.CreateCell(1, 9, 3, Convert.ToString(listProductivity3[0].AvgAutoSegment1));
                    //objExcel.CreateCell(1, 10, 3, Convert.ToString(listProductivity3[0].AvgTotalSegment1), true);

                    //objExcel.CreateCell2(1, 7, 4, Convert.ToString(listProductivity3[0].AirSegmentProductivity1 + "%"), false, 1, 10);
                    //objExcel.CreateCell2(1, 8, 4, Convert.ToString(listProductivity3[0].HotelSegmentProductivity1 + "%"), false, 1, 10);
                    //objExcel.CreateCell2(1, 9, 4, Convert.ToString(listProductivity3[0].AutoSegmentProductivity1 + "%"), false, 1, 10);
                    //objExcel.CreateCell2(1, 10, 4, Convert.ToString(listProductivity3[0].TotalSegmentProductivity1 + "%"), true, 1, 10);

                    //objExcel.CreateCell(1, 7, 7, Convert.ToString(listProductivity3[0].AirSegment2));
                    //objExcel.CreateCell(1, 8, 7, Convert.ToString(listProductivity3[0].HotelSegment2));
                    //objExcel.CreateCell(1, 9, 7, Convert.ToString(listProductivity3[0].AutoSegment2));
                    //objExcel.CreateCell(1, 10, 7, Convert.ToString(listProductivity3[0].TotalSegment2), true);

                    //objExcel.CreateCell(1, 7, 8, Convert.ToString(listProductivity3[0].AvgAirSegment2));
                    //objExcel.CreateCell(1, 8, 8, Convert.ToString(listProductivity3[0].AvgHotelSegment2));
                    //objExcel.CreateCell(1, 9, 8, Convert.ToString(listProductivity3[0].AvgAutoSegment2));
                    //objExcel.CreateCell(1, 10, 8, Convert.ToString(listProductivity3[0].AvgTotalSegment2), true);

                    //objExcel.CreateCell2(1, 7, 9, Convert.ToString(listProductivity3[0].AirSegmentProductivity2 + "%"), false, 1, 10);
                    //objExcel.CreateCell2(1, 8, 9, Convert.ToString(listProductivity3[0].HotelSegmentProductivity2 + "%"), false, 1, 10);
                    //objExcel.CreateCell2(1, 9, 9, Convert.ToString(listProductivity3[0].AutoSegmentProductivity2 + "%"), false, 1, 10);
                    //objExcel.CreateCell2(1, 10, 9, Convert.ToString(listProductivity3[0].TotalSegmentProductivity2 + "%"), true, 1, 10);


                    ////Records
                    //objExcel.CreateCell(1, 14, 2, Convert.ToString(listProductivity3[0].TotalPNR1));
                    //objExcel.CreateCell(1, 15, 2, Convert.ToString(listProductivity3[0].CancelledPNR1));
                    //objExcel.CreateCell(1, 16, 2, Convert.ToString(listProductivity3[0].ScansAverage1), true);

                    //objExcel.CreateCell(1, 14, 3, Convert.ToString(listProductivity3[0].AvgRecords1));
                    //objExcel.CreateCell(1, 15, 3, Convert.ToString(listProductivity3[0].AvgCancelledRecords1));
                    //objExcel.CreateCell(1, 16, 3, Convert.ToString(listProductivity3[0].AvgScanAvgPerRecord1), true);

                    //objExcel.CreateCell2(1, 14, 4, Convert.ToString(listProductivity3[0].RecordsProductivity1 + "%"), false, 1, 10);
                    //objExcel.CreateCell2(1, 15, 4, Convert.ToString(listProductivity3[0].CancelledRecordsProductivity1 + "%"), false, 1, 10);
                    //objExcel.CreateCell2(1, 16, 4, Convert.ToString(listProductivity3[0].AvgScanPerRecordProductivity1 + "%"), true, 1, 10);

                    //objExcel.CreateCell(1, 14, 7, Convert.ToString(listProductivity3[0].TotalPNR2));
                    //objExcel.CreateCell(1, 15, 7, Convert.ToString(listProductivity3[0].CancelledPNR2));
                    //objExcel.CreateCell(1, 16, 7, Convert.ToString(listProductivity3[0].ScansAverage2), true);

                    //objExcel.CreateCell(1, 14, 8, Convert.ToString(listProductivity3[0].AvgRecords2));
                    //objExcel.CreateCell(1, 15, 8, Convert.ToString(listProductivity3[0].AvgCancelledRecords2));
                    //objExcel.CreateCell(1, 16, 8, Convert.ToString(listProductivity3[0].AvgScanAvgPerRecord2), true);

                    //objExcel.CreateCell2(1, 14, 9, Convert.ToString(listProductivity3[0].RecordsProductivity2 + "%"), false, 1, 10);
                    //objExcel.CreateCell2(1, 15, 9, Convert.ToString(listProductivity3[0].CancelledRecordsProductivity2 + "%"), false, 1, 10);
                    //objExcel.CreateCell2(1, 16, 9, Convert.ToString(listProductivity3[0].AvgScanPerRecordProductivity2 + "%"), true, 1, 10);

                    ////Boletos Emitidos
                    //objExcel.CreateCell(1, 19, 2, Convert.ToString(listProductivity3[0].EmittedTKT1));
                    //objExcel.CreateCell(1, 20, 2, Convert.ToString(listProductivity3[0].CancelledTKT1));

                    //objExcel.CreateCell(1, 19, 3, Convert.ToString(listProductivity3[0].AvgEmittedTKT1));
                    //objExcel.CreateCell(1, 20, 3, Convert.ToString(listProductivity3[0].AvgCancelledTKT1));

                    //objExcel.CreateCell2(1, 19, 4, Convert.ToString(listProductivity3[0].EmittedTKTProductivity1 + "%"), false, 1, 10);
                    //objExcel.CreateCell2(1, 20, 4, Convert.ToString(listProductivity3[0].CancelledTKTProductivity1 + "%"), false, 1, 10);

                    //objExcel.CreateCell(1, 19, 7, Convert.ToString(listProductivity3[0].EmittedTKT2));
                    //objExcel.CreateCell(1, 20, 7, Convert.ToString(listProductivity3[0].CancelledTKT2));

                    //objExcel.CreateCell(1, 19, 8, Convert.ToString(listProductivity3[0].AvgEmittedTKT2));
                    //objExcel.CreateCell(1, 20, 8, Convert.ToString(listProductivity3[0].AvgCancelledTKT2));

                    //objExcel.CreateCell2(1, 19, 9, Convert.ToString(listProductivity3[0].EmittedTKTProductivity2 + "%"), false, 1, 10);
                    //objExcel.CreateCell2(1, 20, 9, Convert.ToString(listProductivity3[0].CancelledTKTProductivity2 + "%"), false, 1, 10);

                    ////Efectividad
                    //objExcel.CreateCell(1, 22, 2, Convert.ToString(listProductivity3[0].RecordVsTicket1 + "%"));
                    //objExcel.CreateCell(1, 22, 3, Convert.ToString(listProductivity3[0].AvgRecordVsTicket1 + "%"));
                    //objExcel.CreateCell2(1, 22, 4, Convert.ToString(listProductivity3[0].TotalRecordVsTKTProductivity1 + "%"), false, 1, 10);
                    //objExcel.CreateCell(1, 22, 7, Convert.ToString(listProductivity3[0].RecordVsTicket2 + "%"));
                    //objExcel.CreateCell(1, 22, 8, Convert.ToString(listProductivity3[0].AvgRecordVsTicket2 + "%"));
                    //objExcel.CreateCell2(1, 22, 9, Convert.ToString(listProductivity3[0].TotalRecordVsTKTProductivity2 + "%"), false, 1, 10);

                    ////Productividad entre semanas
                    //objExcel.CreateCell2(1, 7, 12, Convert.ToString(listProductivity3[0].AirSegmentProductivity + "%"), false, 1, 10);
                    //objExcel.CreateCell2(1, 8, 12, Convert.ToString(listProductivity3[0].HotelSegmentProductivity + "%"), false, 1, 10);
                    //objExcel.CreateCell2(1, 9, 12, Convert.ToString(listProductivity3[0].AutoSegmentProductivity + "%"), false, 1, 10);
                    //objExcel.CreateCell2(1, 10, 12, Convert.ToString(listProductivity3[0].TotalSegmentProductivity + "%"), true, 1, 10);

                    //objExcel.CreateCell2(1, 14, 12, Convert.ToString(listProductivity3[0].TotalRecordsProductivity + "%"), false, 1, 10);
                    //objExcel.CreateCell2(1, 15, 12, Convert.ToString(listProductivity3[0].CancelledRecordsProductivity + "%"), false, 1, 10);
                    //objExcel.CreateCell2(1, 16, 12, Convert.ToString(listProductivity3[0].ScansAverageProductivity + "%"), true, 1, 10);

                    //objExcel.CreateCell2(1, 19, 12, Convert.ToString(listProductivity3[0].EmittedTKTProductivity + "%"), false, 1, 10);
                    //objExcel.CreateCell2(1, 20, 12, Convert.ToString(listProductivity3[0].CancelledTKTProductivity + "%"), false, 1, 10);

                    //objExcel.CreateCell2(1, 22, 12, Convert.ToString(listProductivity3[0].RecordVsTKTProductivity + "%"), false, 1, 10);

                    //#endregion

                    #endregion
                    
                    MyCTSExcel.SaveFile(fileName);
                }
            }
            if (!string.IsNullOrEmpty(fileName))
            {
                Process proc = new Process();
                proc.StartInfo.Arguments = "\"" + fileName + "\"";
                proc.StartInfo.FileName = "EXCEL.EXE";
                proc.Start();
            }

            #endregion
        }

        //Lanza un proceso asincrono para detener el proceso del progressBar1 y timer1
        private void StopControls()
        {
            if (this.InvokeRequired)
            {
                StopControlsDelegate smd = new StopControlsDelegate(StopControls);
                this.Invoke(smd);
            }
            else
            {
                progressBar1.Visible = false;
                timer1.Enabled = false;
            }
        }

        #endregion//End MethodsClass

        #region ===== Events =====

        //Mouse Click
        /// <summary>
        /// Esta función es para permitir el Clic sobre el ListBox
        /// para seleccional el item y oculata el listBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_MouseClick(object sender, MouseEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            TextBox txt = (TextBox)txtAgent;
            ListItem li = (ListItem)listBox.SelectedItem;
            txt.Text = li.Value;
            lbAgent.Visible = false;
            txt.Focus();
        }

        //TextChange DK
        /// <summary>
        /// Esta función se encarga de hacer el llenado del ListBox
        /// con la tabla de DK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAgent_TextChanged(object sender, EventArgs e)
        {
            txt = (TextBox)sender;
            Common.SetListBoxAgents(txt, lbAgent);
        }

        /// <summary>
        /// Esta función se encarga de mandar el foco hacia la opción
        /// deseada y al elegir se oculata el ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbAgent_KeyDown(object sender, KeyEventArgs e)
        {
            ListBox ListBox = (ListBox)sender;
            TextBox txt = (TextBox)txtAgent;
            if (e.KeyCode == Keys.Enter)
            {
                ListItem li = (ListItem)ListBox.SelectedItem;
                txt.Text = li.Value;
                lbAgent.Visible = false;
                txt.Focus();
            }
        }

        #endregion 
    }
}

