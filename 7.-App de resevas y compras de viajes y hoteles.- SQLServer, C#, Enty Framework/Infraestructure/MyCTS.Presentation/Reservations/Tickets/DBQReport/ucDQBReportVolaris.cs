using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using System.Configuration;
using System.IO;
using System.Diagnostics;
using MyCTS.Business;
using MyCTS.DataAccess;
using MyCTS.Entities;
using System.Data.SqlClient;
using System.Data.Sql;

namespace MyCTS.Presentation
{
    public partial class ucDQBReportVolaris : CustomUserControl
    {

        /// <summary>
        /// Descripción: User Control que crea un archivo .txt el cual contiene 
        ///              los registros de los DQB por fecha, tambien es posible
        ///              impimir el reporte DQB
        /// Creación:    14 diciembre 12
        /// Solicito:    Guillermo Granados
        /// Autor:       Eduardo Vázquez
        /// </summary>
        /// 
        public ucDQBReportVolaris()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtDate;
            this.LastControlFocus = btnAccept;
        }

        #region ===== Variables Globales =====

        /// <summary>
        /// Variables globales empleadas para el user control
        /// </summary>
        private string fecha = string.Empty;
        private string dbqFileReport = string.Empty;
        private string sabreAnswer;
        private string sabreConcat;
        private List<string> pnrBlockArray = new List<string>();
        string pnrlinesToWrite = string.Empty;
        private string day;
        private string month;
        private string year;
        private bool statusDate;
        public decimal amoun;
        public DateTime dateSelected;
        #endregion

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (isValidBussinesRules())
            {
                if (chkFileReport.Checked)
                {
                    chkPrintReport.Checked = false;
                    createDBQTxt();
                }
                else if (chkPrintReport.Checked)
                {
                    chkFileReport.Checked = false;

                    llenaGrid();
                }
                else if (!chkFileReport.Checked && !chkPrintReport.Checked)
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
            }
        }

        #region===== Event´s Controls =====

        private void ucDQBReportVolaris_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            sabreConcat = string.Empty;
            monthCalendar1.Visible = false;
            chkFileReport.Checked = false;
            chkPrintReport.Checked = true;
            txtDate.Focus();
            dataGridView1.Visible = false;
        }

        private void monthCalendar1_KeyDown(object sender, KeyEventArgs e)
        {
            if (monthCalendar1.Focus())
            {
                if (e.KeyData == Keys.Escape)
                {
                    if (this.Contains(monthCalendar1))
                    {
                        monthCalendar1.SendToBack();
                    }
                    monthCalendar1.Visible = false;
                }
            }
        }


        public void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            dataGridView1.Visible = false;
            chkFileReport.Checked = false;
            amoun = 0;
            statusDate = false;
            dateSelected = monthCalendar1.SelectionStart;
            if (DateTime.Compare(dateSelected, DateTime.Today) > 0)
                statusDate = true;
            else
                statusDate = false;
            string date = dateSelected.ToString("ddMMMyy", new System.Globalization.CultureInfo("en-US")).ToUpper();
            txtDate.Text = date;
            if (this.Contains(monthCalendar1))
            {
                monthCalendar1.SendToBack();
            }
            monthCalendar1.Visible = false;
        }

        private void picCalendar_Click(object sender, EventArgs e)
        {
            calendarStateFront();
        }

        private void monthCalendar1_Leave(object sender, EventArgs e)
        {
            if (this.Contains(monthCalendar1))
            {
                monthCalendar1.SendToBack();
            }
            monthCalendar1.SendToBack();
        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {
            if (txtDate.Text.Length > 6)
                chkFileReport.Focus();
        }


        #endregion

        #region===== MethodsClass =====

        /// <summary>
        /// Función que valida las reglas del negocio aplicadas
        /// para este user control
        /// </summary>
        public bool isValidBussinesRules()
        {
            bool isValid = true;
            if (chkFileReport.Checked && chkPrintReport.Checked)
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.NO_ES_POSIBLE_DOS_OPCIONES, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                chkFileReport.Focus();
                chkFileReport.Checked = false;
                chkPrintReport.Checked = false;
                isValid = false;
            }

            if (dateSelected > DateTime.Today)
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.FECHA_DEBE_SER_MENOR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDate.Focus();
                statusDate = false;
                isValid = false;
            }
            return isValid;
        }

        /// <summary>
        /// Función que valida si existen registros
        /// para la fecha solicitada
        /// </summary>
        private bool searchDQB()
        {
            bool exixtingDQB = false;
            DateTime Fecha;
            fecha = txtDate.Text;
            Fecha = DateTime.Parse(fecha);
            List<ReportVolaris> countList = ReportVolarisBL.ReportVolaris(Fecha);
            //foreach (ReportVolaris lista2 in countList)
            //{
            //    amoun = amoun + Convert.ToDecimal(lista2.Amount);
            //}
            int cantRes = countList.Count;
            if (cantRes != 0)
            {
                exixtingDQB = true;
            }
            else
            {
                MessageBox.Show(Resources.TicketEmission.Constants.NO_HAY_REGISTROS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDate.Focus();
            }
            return exixtingDQB;
        }


        /// <summary>
        /// Función que crea el archivo DBQReport, validando si existe
        /// el directorio en donde se alojara y si no es asi lo crea, ademas
        /// valida que el archivo no exista, de lo contrario lo elimina
        /// para crear uno nuevo
        /// </summary>
        private void createDBQTxt()
        {
            if (searchDQB())
            {
                getDate();
                string pathDQB = string.Empty;
                pathDQB = ConfigurationManager.AppSettings["PATH_DQB_FILE_SABRERED"];
                pathDQB = ConfigurationManager.AppSettings["PATH_DQB_FILE_SABRERED_VOLARIS"];
                pathDQB = pathDQB.Replace("FIRM", Login.Firm);

                dbqFileReport = string.Concat(pathDQB + "\\DBQReport");
                dbqFileReport = string.Concat(dbqFileReport, fecha, ".txt");
                int indexSlash = dbqFileReport.LastIndexOf("\\");
                int quantity = dbqFileReport.Length - indexSlash;
                if (!Directory.Exists(pathDQB)) //Si no existe el directorio o carpeta
                {
                    try
                    {

                        Directory.CreateDirectory(pathDQB);
                        using (StreamWriter w = File.AppendText(dbqFileReport))
                        {
                            w.WriteLine("Fecha" + "\t\t\t\t" + "PNR" + "\t\t\t" + "Amount");
                            DateTime Fecha;
                            fecha = txtDate.Text;
                            Fecha = DateTime.Parse(fecha);
                            //DateTime fechas = Fecha.ToUniversalTime();

                            ucAvailability.IsInterJetProcess = false;

                            List<ReportVolaris> reportList = ReportVolarisBL.ReportVolaris(Fecha);
                            if (!reportList.Count.Equals(0))
                            {
                                foreach (ReportVolaris lista in reportList)
                                {
                                    string fec;
                                    string VolPNR;
                                    string amount;
                                    fecha = lista.Fecha;
                                    VolPNR = lista.VolarisPNR;
                                    amount = lista.Amount;
                                    w.WriteLine(fecha + "\t" + VolPNR + "\t\t\t" + amount);
                                }
                                List<ReportVolaris> countList = ReportVolarisBL.ReportVolaris(Fecha);
                                foreach (ReportVolaris lista2 in countList)
                                {
                                    amoun = amoun + Convert.ToDecimal(lista2.Amount);
                                }
                                int cantRes = reportList.Count;
                                w.WriteLine("Total Reservaciones: " + cantRes + "\t\t    " + "Total: " + amoun);
                            }
                            w.Flush();
                            w.Close();
                        }
                        MessageBox.Show("El archivo " + dbqFileReport.Substring(indexSlash, quantity) + " se ha generado en la siguiente ruta " + pathDQB, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dbqFileReport.Trim(new char[] { '.' });
                        Process.Start("notepad", dbqFileReport);
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                    }
                    catch
                    {
                        MessageBox.Show(Resources.TicketEmission.Tickets.RUTA_NO_VALIDA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                    }
                }
                else
                {
                    if (File.Exists(dbqFileReport))
                    {
                        File.Delete(dbqFileReport);
                        using (StreamWriter x = File.AppendText(dbqFileReport))
                        {
                            x.WriteLine("Fecha" + "\t\t\t\t" + "PNR" + "\t\t\t" + "Amount");
                            DateTime Fecha;
                            fecha = txtDate.Text;
                            Fecha = DateTime.Parse(fecha);
                            //DateTime fechas = Fecha.ToUniversalTime();
                            ucAvailability.IsInterJetProcess = false;

                            List<ReportVolaris> reportList = ReportVolarisBL.ReportVolaris(Fecha);
                            if (!reportList.Count.Equals(0))
                            {
                                foreach (ReportVolaris lista in reportList)
                                {
                                    string fec;
                                    string VolPNR;
                                    string amount;
                                    fecha = lista.Fecha;
                                    VolPNR = lista.VolarisPNR;
                                    amount = lista.Amount;
                                    x.WriteLine(fecha + "\t" + VolPNR + "\t\t\t" + amount);
                                }
                                List<ReportVolaris> countList = ReportVolarisBL.ReportVolaris(Fecha);
                                foreach (ReportVolaris lista2 in countList)
                                {
                                    amoun = amoun + Convert.ToDecimal(lista2.Amount);
                                }
                                int cantRes = reportList.Count;
                                x.WriteLine("Total Reservaciones: " + cantRes + "\t\t    " + "Total: " + amoun);

                            }
                            x.Flush();
                            x.Close();
                        }
                        MessageBox.Show("El archivo " + dbqFileReport.Substring(indexSlash, quantity) + " se ha generado en la siguiente ruta " + pathDQB, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        using (StreamWriter x = File.AppendText(dbqFileReport))
                        {
                            x.WriteLine("Fecha" + "\t\t\t\t" + "PNR" + "\t\t\t" + "Amount");
                            DateTime Fecha;
                            fecha = txtDate.Text;
                            Fecha = DateTime.Parse(fecha);
                            //DateTime fechas = Fecha.ToUniversalTime();
                            ucAvailability.IsInterJetProcess = false;

                            List<ReportVolaris> reportList = ReportVolarisBL.ReportVolaris(Fecha);
                            if (!reportList.Count.Equals(0))
                            {
                                foreach (ReportVolaris lista in reportList)
                                {
                                    string fec;
                                    string VolPNR;
                                    string amount;
                                    fecha = lista.Fecha;
                                    VolPNR = lista.VolarisPNR;
                                    amount = lista.Amount;
                                    x.WriteLine(fecha + "\t" + VolPNR + "\t\t\t" + amount);
                                }
                                List<ReportVolaris> countList = ReportVolarisBL.ReportVolaris(Fecha);
                                foreach (ReportVolaris lista2 in countList)
                                {
                                    amoun = amoun + Convert.ToDecimal(lista2.Amount);
                                }
                                int cantRes = reportList.Count;
                                x.WriteLine("Total Reservaciones: " + cantRes + "\t\t    " + "Total: " + amoun);

                            }
                            x.Flush();
                            x.Close();
                        }
                        MessageBox.Show("El archivo " + dbqFileReport.Substring(indexSlash, quantity) + " se ha generado en la siguiente ruta " + pathDQB, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    dbqFileReport.Trim(new char[] { '.' });
                    Process.Start("notepad", dbqFileReport);
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);

                }
            }
        }


        /// <summary>
        /// Función que valida si se ingreso alguna fecha, de lo
        /// contrario asigna la fecha actual
        /// </summary>
        private void getDate()
        {
            fecha = txtDate.Text;

            if (string.IsNullOrEmpty(fecha))
            {
                fecha = Convert.ToString(DateTime.Now);
                day = fecha.Substring(0, 2);
                month = fecha.Substring(3, 2);
                year = fecha.Substring(8, 2);
                if (month == "01")
                    month = "ENE";
                if (month == "02")
                    month = "FEB";
                if (month == "03")
                    month = "MAR";
                if (month == "04")
                    month = "ABR";
                if (month == "05")
                    month = "MAY";
                if (month == "06")
                    month = "JUN";
                if (month == "07")
                    month = "JUL";
                if (month == "08")
                    month = "AGO";
                if (month == "09")
                    month = "SEP";
                if (month == "10")
                    month = "OCT";
                if (month == "11")
                    month = "NOV";
                if (month == "12")
                    month = "DIC";
            }
            fecha = string.Concat(day, month, year);
        }


        ///// <summary>
        ///// Función que construye cada linea por PNR
        ///// </summary>
        //private void buildPNRLines()
        //{
        //    string lineToWrite = string.Empty;
        //    string temp = string.Empty;
        //    string pnrBlock = string.Empty;
        //    int counter = 1;
        //    //redim(counter);
        //    counter++;
        //    pnrBlock = pnrBlockArray[0];

        //    //Copia TICKET
        //    CommandsQik.CopyResponse(pnrBlock, ref temp, 1, 1, 11);
        //    lineToWrite = temp;
        //    temp = string.Empty;

        //    //copia COMMISSION   AGENT
        //    CommandsQik.CopyResponse(pnrBlock, ref temp, 1, 18, 33);
        //    lineToWrite = string.Concat(lineToWrite, temp);
        //    temp = string.Empty;

        //    //copia TICKET
        //    CommandsQik.CopyResponse(pnrBlock, ref temp, 1, 54, 6);
        //    lineToWrite = string.Concat(lineToWrite, temp);
        //    temp = string.Empty;

        //    //copia NUMBER
        //    CommandsQik.CopyResponse(pnrBlock, ref temp, 2, 1, 18);
        //    lineToWrite = string.Concat(lineToWrite, " ",
        //        temp);
        //    temp = string.Empty;

        //    //copia AMOUNT
        //    CommandsQik.CopyResponse(pnrBlock, ref temp, 2, 20, 9);
        //    lineToWrite = string.Concat(lineToWrite, temp);
        //    temp = string.Empty;

        //    //copia SINE
        //    CommandsQik.CopyResponse(pnrBlock, ref temp, 2, 32, 5);
        //    lineToWrite = string.Concat(lineToWrite, temp);
        //    temp = string.Empty;

        //    //copia TIME
        //    CommandsQik.CopyResponse(pnrBlock, ref temp, 2, 37, 10);
        //    lineToWrite = string.Concat(lineToWrite, temp);
        //    temp = string.Empty;

        //    //copia CURR
        //    CommandsQik.CopyResponse(pnrBlock, ref temp, 2, 47, 7);
        //    lineToWrite = string.Concat(lineToWrite, temp);
        //    temp = string.Empty;

        //    //copia AMOUNT
        //    CommandsQik.CopyResponse(pnrBlock, ref temp, 2, 54, 8);
        //    lineToWrite = string.Concat(lineToWrite, temp);
        //    temp = string.Empty;

        //    //pnrlinesToWrite = lineToWrite;

        //    for (int i = 0; i < pnrBlockArray.Count; i++)
        //    {
        //        string[] linesToConCat = pnrBlockArray[i].Split(new char[] { '\n' });
        //        if (linesToConCat.Length < 3)
        //            if (i == pnrBlockArray.Count - 1)
        //                if (!string.IsNullOrEmpty(pnrlinesToWrite))
        //                {
        //                    if (linesToConCat.Length > 1)
        //                        pnrlinesToWrite = string.Concat(pnrlinesToWrite,
        //                            "\n",
        //                            linesToConCat[0],
        //                            "\n",
        //                            linesToConCat[1]);
        //                }
        //                else
        //                {
        //                    if (linesToConCat.Length > 1)
        //                        pnrlinesToWrite = string.Concat(pnrlinesToWrite,
        //                            "\n",
        //                            linesToConCat[0],
        //                            "\n",
        //                            linesToConCat[1]);
        //                }
        //            else if (string.IsNullOrEmpty(pnrlinesToWrite))
        //            {
        //                pnrlinesToWrite = string.Concat(linesToConCat[0].Remove(47, 16),
        //                      linesToConCat[1]);
        //            }
        //            else
        //                if (!linesToConCat[0].Contains("                                                               "))
        //                    pnrlinesToWrite = string.Concat(pnrlinesToWrite,
        //                            "\n", linesToConCat[0].Remove(47, 16),
        //                          linesToConCat[1]);
        //                else
        //                    pnrlinesToWrite = string.Concat(pnrlinesToWrite,
        //                         "\n", linesToConCat[0]);
        //        else
        //            pnrlinesToWrite = string.Concat(pnrlinesToWrite,
        //                        "\n",
        //                linesToConCat[0].Remove(47, 16),
        //                linesToConCat[1]);
        //    }
        //}

        /// <summary>
        /// Llevar el calendario hacia el frente
        /// y que se muestre
        /// </summary>
        public void calendarStateFront()
        {
            monthCalendar1.Visible = true;
            if (this.Contains(monthCalendar1))
            {
                monthCalendar1.BringToFront();
            }
            monthCalendar1.Focus();
        }

        #endregion

        public void llenaGrid()
        {
            if (searchDQB())
            {
                DateTime Fecha;
                fecha = txtDate.Text;
                Fecha = DateTime.Parse(fecha);
                //DateTime fechas = Fecha.ToUniversalTime();
                ucAvailability.IsInterJetProcess = false;
                dataGridView1.Visible = true;
                dataGridView1.Rows.Clear();
                dataGridView1.MultiSelect = true;
                dataGridView1.ColumnCount = 7;

                // Set the properties of the DataGridView columns.
                dataGridView1.Columns[0].Name = "Fecha";
                dataGridView1.Columns[1].Name = "PNRVolaris";
                dataGridView1.Columns[2].Name = "Amount";
                dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.Automatic;

                dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

                dataGridView1.Columns["Fecha"].HeaderText = "Fecha";
                dataGridView1.Columns["PNRVolaris"].HeaderText = "PNR";
                dataGridView1.Columns["Amount"].HeaderText = "Amount";

                List<ReportVolaris> reportList = ReportVolarisBL.ReportVolaris(Fecha);
                foreach (ReportVolaris lista in reportList)
                {
                    dataGridView1.Rows.Add(new object[] { lista.Fecha, lista.VolarisPNR, lista.Amount });
                    amoun = amoun + Convert.ToDecimal(lista.Amount);
                }
                int cantRes = reportList.Count;
                dataGridView1.Rows.Add("Total Reservaciones: " + cantRes, " ", "Total: " + amoun);
            }
        }

        #region =====Back to a Previous Usercontrol or Validate Enter KeyDown=====

        /// <summary>
        /// Aborta el proceso enviando a la mascarilla de welcome
        /// al presionar la tecla ESC o ejecuta las funciones al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }
        }

        #endregion//Back to a Previous Usercontrol or Validate Enter KeyDown

        private void ucDQBReportVolaris_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }
        }

        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }
        }

        private void chkPrintReport_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
