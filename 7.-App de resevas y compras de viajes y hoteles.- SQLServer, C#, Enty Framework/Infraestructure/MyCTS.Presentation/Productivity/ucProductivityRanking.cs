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
    public partial class ucProductivityRanking : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite desplegar la productividad por cada PCC
        /// Creación:    11 -Marzo 10 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez
        /// </summary>
       
        #region ======== Declaration of Variable =======

        private delegate void SenderCallBack();
        private delegate void StopControlsDelegate();
        private string date=string.Empty;
        private string week;
        private string month;
        int count = 0;

        #endregion

        public ucProductivityRanking()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = rdoWeek;
            this.LastControlFocus = btnAccept;
        }

        //Carga los combos con las fechas correspondientes
        private void ucProductivityRanking_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            FillWeeks();
            FillMonths();
        }

        /// <summary>
        /// Valida los campos y se llama un proceso de forma asincrona
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidateBusinessRules)
            {
                timer1.Enabled = true;
                progressBar1.Visible = true;
                lblLoader.Visible = true;
                SenderCallBack scb = new SenderCallBack(createExcel);
                AsyncCallback callback = new AsyncCallback(OnCompleted);
                scb.BeginInvoke(callback, null);
            }
        }

        //Muestra el porcentje del progess Bar
        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Percentage = 10; //Set Next Value
            progressBar1.SetProgComplete(progressBar1.Percentage);
        }

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
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }

        #endregion
   
        #region===== MethodsClass =====

        //Valida los campos obligatorios
        private bool IsValidateBusinessRules
        {
            get
            {
                if (!rdoMonth.Checked &&
                    !rdoWeek.Checked &&
                    !rdoAccumulated.Checked)
                {
                    MessageBox.Show(Resources.Reservations.SELECCIONE_ALGUNA_OPCIÓN, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rdoWeek.Focus();
                    return false;
                }
                else if (cmbWeek.SelectedIndex == 0 || cmbMonth.SelectedIndex == 0)
                {
                    MessageBox.Show(Resources.Reservations.INDIQUE_FECHAS_REPORTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbWeek.Focus();
                    return false;
                }
                else
                    return true;
            }
        }
    
        //Extrae los datos para la creación del Excel
        private void createExcel()
        {
            List<ProductivityRankingPerCorporative> listProductivity = null;
            count = 5;

            Microsoft.VisualBasic.Devices.Computer MyComputer = new Microsoft.VisualBasic.Devices.Computer();
            string fileName = string.Empty; //Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);

            #region ===== Generating Excel Document ======

            using (Components.MyCTSExcel MyCTSExcel = new Components.MyCTSExcel())
            {
                if (rdoWeek.Checked)
                {
                    listProductivity = ProductivityRankingPerCorporativeBL.GetProductivityRankingPerCorporative(1, week);
                    MyCTSExcel.CreateExcelObject("MyCTSProductividadSemanal");
                }
                else if (rdoMonth.Checked)
                {
                    listProductivity = ProductivityRankingPerCorporativeBL.GetProductivityRankingPerCorporative(2, month);
                    MyCTSExcel.CreateExcelObject("MyCTSProductividadMensual");
                }
                else
                {
                    string acumulative;
                    DateTime today= new DateTime();
                    today = DateTime.Now;
                    acumulative = Convert.ToString(today);
                    acumulative = acumulative.Substring(0, 10);
                    listProductivity = ProductivityRankingPerCorporativeBL.GetProductivityRankingPerCorporative(3, "02-02-2010");
                    MyCTSExcel.CreateExcelObject("MyCTSProductividadAcumulativa");
                }
                if (listProductivity.Count > 0)
                {
                    if (MyCTSExcel.IsObjectCreated)
                    {
                        MyCTSExcel.Cell cell = null;
                        fileName = MyComputer.FileSystem.SpecialDirectories.Temp;
                        fileName = fileName + string.Format("\\TempFile_{0}.xls", Guid.NewGuid().ToString());


                        #region ===== Headers ======

                        date = string.Concat(date, "Del  ", listProductivity[0].InitialDate, "  Al  ", listProductivity[0].FinalDate);

                        cell = new MyCTSExcel.Cell(1, 5, "REPORTE DE PRODUCTIVIDAD CORPORATIVA DE RESERVACIONES HECHAS EN MyCTS");
                        cell.Bold = true;
                        cell.FontSize = 11;
                        cell.ShowBorder = false;
                        cell.Wide = 8;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(2, 7, date);
                        cell.FontColor = Color.Blue;
                        cell.Wide = 4;
                        cell.ShowBorder = false;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(3, 3, "%Productividad Vs \n" + "Promedio Corporativo \n" + "Segmentos \n");
                        cell.Bold = true;
                        cell.FontColor = Color.Blue;
                        cell.Wide = 2;
                        cell.ShowBorder = false;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(3, 7, "%Productividad Vs \n" + "Promedio Corporativo \n" + "Records \n");
                        cell.FontColor = Color.Blue;
                        cell.Bold = true;
                        cell.Wide = 2;
                        cell.ShowBorder = false;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(3, 11, "%Productividad Vs \n" + "Promedio Corporativo \n" + "Boletos \n");
                        cell.FontColor = Color.Blue;
                        cell.Bold = true;
                        cell.Wide = 1;
                        cell.ShowBorder = false;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(3, 14, "Efectividad");
                        cell.FontColor = Color.Blue;
                        cell.Bold = true;
                        cell.ShowBorder = false;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(4, 1, "Agente");
                        cell.FontColor = Color.Coral;
                        MyCTSExcel.CreateCell(cell);

                        cell = new MyCTSExcel.Cell(4, 2, "Nombre");
                        cell.FontColor = Color.Coral;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(4, 3, "Aereos");
                        cell.FontColor = Color.Coral;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(4, 4, "Hotel");
                        cell.FontColor = Color.Coral;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(4, 5, "Auto");
                        cell.FontColor = Color.Coral;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(4, 7, "Creados");
                        cell.FontColor = Color.Coral;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(4, 8, "Cancelados");
                        cell.FontColor = Color.Coral;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(4, 9, "Scans Promedio");
                        cell.FontColor = Color.Coral;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(4, 11, "Emitidos");
                        cell.FontColor = Color.Coral;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(4, 12, "Cancelados");
                        cell.FontColor = Color.Coral;
                        MyCTSExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(4, 14, "Records Vs Boletos");
                        cell.FontColor = Color.Coral;
                        MyCTSExcel.CreateCell(cell);

                        #endregion

                        #region ====== Elements =====

                        foreach (ProductivityRankingPerCorporative p in listProductivity)
                        {

                            cell = new MyCTSExcel.Cell(count, 1, p.Agent);
                            MyCTSExcel.CreateCell(cell);

                            cell = new MyCTSExcel.Cell(count, 2, p.FamilyName);
                            MyCTSExcel.CreateCell(cell);

                            //Segmentos
                            cell = new MyCTSExcel.Cell(count, 3, Convert.ToString(p.AirProductivity + "%"));
                            MyCTSExcel.CreateCell(cell);
                            cell = new MyCTSExcel.Cell(count, 4, Convert.ToString(p.HotelProductivity + "%"));
                            MyCTSExcel.CreateCell(cell);
                            cell = new MyCTSExcel.Cell(count, 5, Convert.ToString(p.AutoProductivity + "%"));
                            MyCTSExcel.CreateCell(cell);

                            //Records
                            cell = new MyCTSExcel.Cell(count, 7, Convert.ToString(p.PNRProductivity + "%"));
                            MyCTSExcel.CreateCell(cell);
                            cell = new MyCTSExcel.Cell(count, 8, Convert.ToString(p.CancelledPNRProductivity + "%"));
                            MyCTSExcel.CreateCell(cell);
                            cell = new MyCTSExcel.Cell(count, 9, Convert.ToString(p.AvgScanPerPNRProductivity + "%"));
                            MyCTSExcel.CreateCell(cell);

                            //Boletos Emitidos
                            cell = new MyCTSExcel.Cell(count, 11, Convert.ToString(p.EmittedTKTProductivity + "%"));
                            MyCTSExcel.CreateCell(cell);
                            cell = new MyCTSExcel.Cell(count, 12, Convert.ToString(p.CancelledTKTProductivity + "%"));
                            MyCTSExcel.CreateCell(cell);

                            //Efectividad
                            cell = new MyCTSExcel.Cell(count, 14, Convert.ToString(p.TotalPNRVsTKTProductivity + "%"));
                            MyCTSExcel.CreateCell(cell);

                            count++;
                        }
                        #endregion

                        MyCTSExcel.SaveFile(fileName);
                    }
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
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
        }

        //Llena el combo de las semanas
        private void FillWeeks()
        {
            List<ProductivityWeeks> listWeeks = ProductivityWeeksBL.GetProductivityWeeks();
            bindingSource1.DataSource = listWeeks;

            foreach (ProductivityWeeks weeksItem in listWeeks)
            {
                ListItem litem = new ListItem();
                litem.Text = string.Format("{0}", weeksItem.Weeks);
                litem.Value = weeksItem.Weeks;
                cmbWeek.Items.Add(litem);
            }
        }

        //Llena el combo de los meses
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

        #endregion

        #region===== Events =======

        private void rdoWeek_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                rdoMonth.TabStop = true;
        }

        private void rdoMonth_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                rdoAccumulated.TabStop = true;
        }

        private void rdoWeek_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoWeek.Checked)
            {
                cmbWeek.Visible = true;
                cmbMonth.Visible = false;
            }
        }

        private void rdoMonth_CheckedChanged(object sender, EventArgs e)
         {
            if (rdoMonth.Checked)
            {
                cmbMonth.Visible = true;
                cmbWeek.Visible = false;
            }
         }

        private void rdoAccumulated_CheckedChanged(object sender, EventArgs e)
        {
            cmbMonth.Visible = false;
            cmbWeek.Visible = false;
        }

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
    }
}
