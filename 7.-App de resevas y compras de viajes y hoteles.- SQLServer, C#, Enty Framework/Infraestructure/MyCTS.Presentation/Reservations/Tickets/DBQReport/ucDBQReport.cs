using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using System.IO;
using System.Diagnostics;

namespace MyCTS.Presentation
{
    public partial class ucDBQReport : CustomUserControl 
    {
        /// <summary>
        /// Descripción: User Control que crea un archivo .txt el cual contiene 
        ///              los registros de los DQB por fecha, tambien es posible
        ///              impimir el reporte DQB
        /// Creación:    07 Octubre 09
        /// Solicito:    Guillermo Granados
        /// Autor:       Angel Trejo/Marcos Ramirez
        /// </summary>
        /// 

        public ucDBQReport()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
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

        #endregion

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (isValidBussinesRules())
            {
                if (chkFileReport.Checked)
                {
                    createDBQTxt();
                }
                else if (chkPrintReport.Checked)
                {
                    printRBQ();
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
                else if (!chkFileReport.Checked && !chkPrintReport.Checked)
                {
                    DQBSendCommnand();
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
            }
        }

        #region===== Event´s Controls =====

        private void ucDBQReport_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            sabreConcat = string.Empty;
            monthCalendar1.Visible = false;
            chkFileReport.Checked = false;
            chkPrintReport.Checked = false;
            txtDate.Focus();
        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {
            if (txtDate.Text.Length > 6)
                chkFileReport.Focus();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            statusDate = false;
            DateTime dateSelected = monthCalendar1.SelectionStart;
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

        private void monthCalendar1_Leave(object sender, EventArgs e)
        {
            if (this.Contains(monthCalendar1))
            {
                monthCalendar1.SendToBack();
            }
            monthCalendar1.SendToBack();
        }

        private void picCalendar_Click(object sender, EventArgs e)
        {
            calendarStateFront();
        }

        #endregion


        #region===== MethodsClass =====


        /// <summary>
        /// Función que valida las reglas del negocio aplicadas
        /// para este user control
        /// </summary>
        private bool isValidBussinesRules()
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
            if (statusDate)
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.FECHA_DEBE_SER_MENOR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDate.Focus();
                statusDate = false;
                isValid = false;
            }
            return isValid;
        }

        /// <summary>
        /// Función que crea el archivo DBQReport, validando si existe
        /// el directorio en donde se alojara y si no es asi lo crea, ademas
        /// valida que el archivo no exista, de lo contrario lo elimina
        /// para crear uno nuevo
        /// </summary>
        private void createDBQTxt()
        {
            getDate();
            DQBSendCommnand();
            if (searchDQB())
            {
                reportDBQBucle();
                fixDBQReport();
                buildPNRLines();
                string pathDQB = string.Empty;
                if (Login.ByParameters)
                {
                    pathDQB = ConfigurationManager.AppSettings["PATH_DQB_FILE_SABRERED"];
                }
                else
                {
                    pathDQB = ConfigurationManager.AppSettings["PATH_DQB_FILE"];
                    pathDQB = pathDQB.Replace("FIRM", Login.Firm);
                }
                if (chkmpd.Checked)
                {
                    dbqFileReport = string.Concat(pathDQB + "\\DBQEMDReport");
                }
                else
                {
                    dbqFileReport = string.Concat(pathDQB + "\\DBQReport");
                }
                dbqFileReport = string.Concat(dbqFileReport, fecha, ".txt");
                int indexSlash = dbqFileReport.LastIndexOf("\\");
                int quantity = dbqFileReport.Length - indexSlash;
                if (!Directory.Exists(pathDQB))
                {
                    try
                    {

                        Directory.CreateDirectory(pathDQB);
                        using (StreamWriter w = File.AppendText(dbqFileReport))
                        {

                            string[] dqbLinesToWrite = pnrlinesToWrite.Split(new char[] { '\n' });
                            foreach (string line in dqbLinesToWrite)
                            {
                                w.WriteLine(line);
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

                            string[] dqbLinesToWrite = pnrlinesToWrite.Split(new char[] { '\n' });
                            foreach (string line in dqbLinesToWrite)
                            {
                                x.WriteLine(line);
                            }
                            x.Flush();
                            x.Close();
                        }
                        MessageBox.Show("El archivo " + dbqFileReport.Substring(indexSlash, quantity) + " se ha generado en la siguiente ruta " + pathDQB, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        using (StreamWriter w = File.AppendText(dbqFileReport))
                        {

                            string[] dqbLinesToWrite = pnrlinesToWrite.Split(new char[] { '\n' });
                            foreach (string line in dqbLinesToWrite)
                            {
                                w.WriteLine(line);
                            }
                            w.Flush();
                            w.Close();
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
        /// Función que valida si en sabre existen registros DQB
        /// para la fecha solicitada
        /// </summary>
        private bool searchDQB()
        {
            int row = 0;
            int col = 0;
            bool exixtingDQB = false;
            row = 0;
            col = 0;
            CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.DQB, ref row, ref col);
            if (row > 0)
            {
                exixtingDQB = true;
                sabreConcat = sabreAnswer;
            }
            CommandsQik.searchResponse(sabreAnswer, "EMD", ref row, ref col);
            if (row > 0)
            {
                exixtingDQB = true;
                sabreConcat = sabreAnswer;
            }
            else
            {
                MessageBox.Show(Resources.TicketEmission.Constants.NO_HAY_REGISTROS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDate.Focus();
                sabreConcat = string.Empty;
                exixtingDQB = false;
            }
            return exixtingDQB;
        }

        /// <summary>
        /// Función que imprime el reporte de los DQB
        /// para la fecha seleccionada
        /// </summary>
        private void printRBQ()
        {
            printDQBSendCommand();
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
                fecha = string.Concat(day, month, year);
            }

        }

        /// <summary>
        /// Función que imprime el reporte de los DQB
        /// para la fecha seleccionada
        /// </summary>
        private void printDQBSendCommand()
        {
            string send = string.Empty;

            sabreAnswer = string.Empty;
            if (!string.IsNullOrEmpty(txtDate.Text))
            {
                send = Resources.TicketEmission.Constants.COMMANDS_PTRDQB_AST;
                send = string.Concat(send,
                    txtDate.Text);
            }
            else
            {
                send = Resources.TicketEmission.Constants.COMMANDS_PTR_AST_DQB_AST;
            }

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }
        }

        /// <summary>
        /// Función que crea el reporte txt de los DQB
        /// para la fecha seleccionada
        /// </summary>
        private void DQBSendCommnand()
        {
            string send = string.Empty;

            sabreAnswer = string.Empty;
            if (!string.IsNullOrEmpty(txtDate.Text))
            {
                send = Resources.TicketEmission.Constants.COMMANDS_DQB_AST;
                if (chkmpd.Checked)
                {
                    send = string.Concat(send, "EMD/D");
                }
                send = string.Concat(send,
                    txtDate.Text);
            }
            else
            {
                send = Resources.TicketEmission.Constants.COMMANDS_DQB_AST;
                if (chkmpd.Checked)
                {
                    send = string.Concat(send, "EMD");
                }
            }

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }
        }


        private void reportDBQBucle()
        {
            sendScrollCommand();
            if (!searchEndScroll())
            {
                reportDBQBucle();
            }
        }

        private void sendScrollCommand()
        {
            string send = string.Empty;
            send = string.Empty;
            sabreAnswer = string.Empty;
            send = Resources.TicketEmission.Constants.COMMANDS_MD;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }
        }

        /// <summary>
        /// Valida el fin del despliegue de remarks contables en MySabre
        /// </summary>
        /// <returns></returns>
        private bool searchEndScroll()
        {
            bool endScroll = false;
            int row = 0;
            int col = 0;
            CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.SCROLL_CROSS_LORAINE, ref row, ref col);
            if (row != 0 && col >= 0)
            {
                endScroll = true;
            }
            else
            {
                sabreConcat = string.Concat(sabreConcat,
                    "\n",
                    sabreAnswer);
                endScroll = false;
            }
            return endScroll;
        }

        private void fixDBQReport()
        {
            string pnrBlock = string.Empty;
            string dqbReportEnd = string.Empty;
            int row = 0;
            int col = 0;
            int size = 1;
            int counter = 0;
            string name = string.Empty;
            sabreConcat = sabreConcat.Replace('‡', '\n');
            string[] DQBLines = sabreConcat.Split(new char[] { '\n' });
            //redimPNRBlock(size);
            if (chkmpd.Checked)
            {
                pnrBlock = string.Concat(DQBLines[1],
                    "\n",
                    DQBLines[2]);
            }
            else
            {
                pnrBlock = string.Concat(DQBLines[2],
                    "\n",
                    DQBLines[3]);
            }
            pnrBlockArray.Add(pnrBlock);
            size++;
            //pnrBlock = string.Empty;
            int j = 4;
            if (chkmpd.Checked)
            {
                j = 3;
            }
            for (int i = j; i < DQBLines.Length; i++)
            {
                if (!string.IsNullOrEmpty(DQBLines[i]))
                {
                    row = 0;
                    col = 0;
                    CommandsQik.searchResponse(DQBLines[i], Resources.TicketEmission.ValitationLabels.PNR, ref row, ref col, 1, 1, 1, 5);
                    if (row > 0)
                    {
                        if (!string.IsNullOrEmpty(pnrBlock))
                        {
                            counter = 0;
                            //redimPNRBlock(size);
                            //pnrBlockArray.Add(pnrBlock);
                            //name = string.Concat(DQBLines[i], "\n");
                            size++;
                            pnrBlock = string.Empty;
                            pnrBlock = string.Concat(DQBLines[i], "\n");
                        }
                        else
                        {
                            pnrBlock = string.Concat(DQBLines[i],
                                "\n");

                        }

                    }
                    else
                    {
                        row = 0;
                        col = 0;
                        CommandsQik.searchResponse(DQBLines[i], Resources.TicketEmission.ValitationLabels.TOTAL_DAILY_SALES, ref row, ref col);
                        if (row > 0)
                        {
                            if (!string.IsNullOrEmpty(pnrBlock))
                            {
                                counter = 0;
                                //redimPNRBlock(size);
                                //pnrBlockArray.Add(pnrBlock);
                                //size++;
                                pnrBlock = string.Empty;
                            }
                            dqbReportEnd = string.Concat(DQBLines[i],
                                "\n");
                            if (!string.IsNullOrEmpty(DQBLines[i + 1]))
                                dqbReportEnd = string.Concat(dqbReportEnd,
                                    DQBLines[i + 1]);
                            else
                                dqbReportEnd = string.Concat(dqbReportEnd,
                                    DQBLines[i + 2]);
                            //redimPNRBlock(size);
                            pnrBlockArray.Add(dqbReportEnd);
                            break;
                        }
                        else
                        {
                            counter++;
                            if (counter < 2)
                            {

                                pnrBlock = string.Concat(pnrBlock,
                                    DQBLines[i]);
                                name = pnrBlock.Remove(pnrBlock.Length - 21);
                                pnrBlockArray.Add(string.Concat(pnrBlock, "\n", " "));

                            }
                            else
                            {
                                if (!DQBLines[i].Contains("                                                  "))
                                {
                                    if (!DQBLines[i].Contains("TOTAL"))
                                    {
                                        pnrBlock = string.Concat(name,
                                            DQBLines[i].Trim());
                                        pnrBlockArray.Add(pnrBlock);
                                    }
                                }
                                else
                                    pnrBlockArray.Add(DQBLines[i]);
                            }

                        }
                    }
                }
            }
        }

        /// <summary>
        /// Función que construye cada linea por PNR
        /// </summary>
        private void buildPNRLines()
        {
            string lineToWrite = string.Empty;
            string temp = string.Empty;
            string pnrBlock = string.Empty;
            int counter = 1;
            //redim(counter);
            counter++;
            pnrBlock = pnrBlockArray[0];

            //Copia TICKET
            CommandsQik.CopyResponse(pnrBlock, ref temp, 1, 1, 11);
            lineToWrite = temp;
            temp = string.Empty;

            //copia COMMISSION   AGENT
            CommandsQik.CopyResponse(pnrBlock, ref temp, 1, 18, 33);
            lineToWrite = string.Concat(lineToWrite,
                temp);
            temp = string.Empty;

            //copia TICKET
            CommandsQik.CopyResponse(pnrBlock, ref temp, 1, 54, 6);
            lineToWrite = string.Concat(lineToWrite,
                temp);
            temp = string.Empty;

            //copia NUMBER
            CommandsQik.CopyResponse(pnrBlock, ref temp, 2, 1, 18);
            lineToWrite = string.Concat(lineToWrite,
                " ",
                temp);
            temp = string.Empty;

            //copia AMOUNT
            CommandsQik.CopyResponse(pnrBlock, ref temp, 2, 20, 9);
            lineToWrite = string.Concat(lineToWrite,
                temp);
            temp = string.Empty;

            //copia SINE
            CommandsQik.CopyResponse(pnrBlock, ref temp, 2, 32, 5);
            lineToWrite = string.Concat(lineToWrite,
                temp);
            temp = string.Empty;

            //copia TIME
            CommandsQik.CopyResponse(pnrBlock, ref temp, 2, 37, 10);
            lineToWrite = string.Concat(lineToWrite,
                temp);
            temp = string.Empty;

            //copia CURR
            CommandsQik.CopyResponse(pnrBlock, ref temp, 2, 47, 7);
            lineToWrite = string.Concat(lineToWrite,
                temp);
            temp = string.Empty;

            //copia AMOUNT
            CommandsQik.CopyResponse(pnrBlock, ref temp, 2, 54, 8);
            lineToWrite = string.Concat(lineToWrite,
                temp);
            temp = string.Empty;

            //pnrlinesToWrite = lineToWrite;

            for (int i = 0; i < pnrBlockArray.Count; i++)
            {
                string[] linesToConCat = pnrBlockArray[i].Split(new char[] { '\n' });
                if (linesToConCat.Length < 3)
                    if (i == pnrBlockArray.Count - 1)
                        if (!string.IsNullOrEmpty(pnrlinesToWrite))
                        {
                            if (linesToConCat.Length > 1)
                                pnrlinesToWrite = string.Concat(pnrlinesToWrite,
                                    "\n",
                                    linesToConCat[0],
                                    "\n",
                                    linesToConCat[1]);
                        }
                        else
                        {
                            if (linesToConCat.Length > 1)
                                pnrlinesToWrite = string.Concat(pnrlinesToWrite,
                                    "\n",
                                    linesToConCat[0],
                                    "\n",
                                    linesToConCat[1]);
                        }
                    else if (string.IsNullOrEmpty(pnrlinesToWrite))
                    {
                        pnrlinesToWrite = string.Concat(linesToConCat[0].Remove(47, 16),
                              linesToConCat[1]);
                    }
                    else
                        if (!linesToConCat[0].Contains("                                                               "))
                            pnrlinesToWrite = string.Concat(pnrlinesToWrite,
                                    "\n", linesToConCat[0].Remove(47, 16),
                                  linesToConCat[1]);
                        else
                            pnrlinesToWrite = string.Concat(pnrlinesToWrite,
                                 "\n", linesToConCat[0]);
                else
                    pnrlinesToWrite = string.Concat(pnrlinesToWrite,
                                "\n",
                        linesToConCat[0].Remove(47, 16),
                        linesToConCat[1]);
            }
        }

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
    }
}
