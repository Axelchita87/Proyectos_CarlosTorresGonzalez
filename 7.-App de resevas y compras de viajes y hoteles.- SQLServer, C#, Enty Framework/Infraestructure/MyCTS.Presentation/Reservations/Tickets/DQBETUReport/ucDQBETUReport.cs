using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Forms.UI;
using System.Diagnostics;

namespace MyCTS.Presentation
{
    public partial class ucDQBETUReport : CustomUserControl
    {

        /// <summary>
        /// Descripción: User Control que permite desplegar el número de los boletos
        /// no utilizados en MySabre con la opción de pasar la informacion a un archivo
        /// de tipo excel
        /// Creación:    15 de octubre 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez / Angel F. Trejo
        /// </summary>
        /// 
        public ucDQBETUReport()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = chkreportByDate;
            this.LastControlFocus = btnAccept;
        }

        /// <summary>
        /// Variables globales utilizadas para por el user control
        /// </summary>
        /// 
        private string sabreAnswer = string.Empty;
        private string dateBegin = string.Empty;
        private string dateEnd = string.Empty;
        private string dk = string.Empty;
        private string airline = string.Empty;
        private string sabreConcat = string.Empty;
        private string titulo = string.Empty;
        private List<Passenger> PassengerList = null;

        private class Passenger
        {
            public string Item;
            public string Name;
            public string TKTNumber;
            public string DKNumber;
            public string Original;
            public string DateAdd;
            public string DateToBe;
        }


        //Evento Load
        private void ucDQBETUReport_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            chkreportByDate.Checked = false;
            chkPeportByDK.Checked = false;
            chkReportByAirline.Checked = false;
            chkGenerateExcel.Checked = false;
            txtDateBegin.Enabled = false;
            txtDateBegin.BackColor = SystemColors.Control;
            txtDateEnd.Enabled = false;
            txtDateEnd.BackColor = SystemColors.Control;
            txtReportByDK.Enabled = false;
            txtReportByDK.BackColor = SystemColors.Control;
            txtReportbyAirline.Enabled = false;
            txtReportbyAirline.BackColor = SystemColors.Control;
            chkreportByDate.Focus();
            sabreConcat = string.Empty;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

            if (!IsValidBusinessRules)
            {
                if (!chkPeportByDK.Checked && !chkReportByAirline.Checked && !chkreportByDate.Checked)
                    DQBETUSendCommand();
                else if (chkreportByDate.Checked)
                    DQBETUSendCommandDate();
                else if (chkPeportByDK.Checked)
                    DQBETUSendCommandDK();
                else if (chkReportByAirline.Checked)
                    DQBETUSendCommandAirline();

            }

        }


        #region===== MethodsClass =====

        /// <summary>
        /// Validaciones de regla de negocio aplicables a esta mascarilla
        /// </summary>
        /// <returns></returns>
        private bool IsValidBusinessRules
        {
            get
            {
                bool isValid = true;

                if (chkreportByDate.Checked &&
                   string.IsNullOrEmpty(txtDateBegin.Text))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_FECHA_INICIO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDateBegin.Focus();
                }

                else if (chkreportByDate.Checked &&
                   !string.IsNullOrEmpty(txtDateEnd.Text) &&
                    string.IsNullOrEmpty(txtDateBegin.Text))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_FECHA_INICIO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDateBegin.Focus();
                }
                else if (!string.IsNullOrEmpty(txtDateBegin.Text) && !ValidateRegularExpression.ValidateDateFormat(txtDateBegin.Text))
                {
                    string messageToSend = string.Format(Resources.Reservations.FORMAT_FECHA_DOS_NUM_TRES_ALFA, "\n");
                    MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDateBegin.Focus();
                }
                else if (!string.IsNullOrEmpty(txtDateEnd.Text) && !ValidateRegularExpression.ValidateDateFormat(txtDateEnd.Text))
                {
                    string messageToSend = string.Format(Resources.Reservations.FORMAT_FECHA_DOS_NUM_TRES_ALFA, "\n");
                    MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDateEnd.Focus();
                }
                else if (chkPeportByDK.Checked &&
                   string.IsNullOrEmpty(txtReportByDK.Text))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_DK, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtReportByDK.Focus();
                }
                else if (chkReportByAirline.Checked &&
                   string.IsNullOrEmpty(txtReportbyAirline.Text))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_AEROLINEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtReportbyAirline.Focus();
                }
                else
                {
                    isValid = false;
                }
                return isValid;

            }

        }

        /// <summary>
        /// Armado de las listas que se agregaran al archivo excel
        /// </summary>
        /// <returns></returns>
        private void FixDQBETUReport()
        {
            PassengerList = new List<Passenger>();
            sabreConcat = sabreConcat.Replace('‡', '\n');
            string[] DQBLines = sabreConcat.Split(new char[] { '\n' });
            titulo = DQBLines[0];
            int count = 0;
            string date1 = string.Empty;
            string date2 = string.Empty;
            foreach (string item in DQBLines)
            {
                if (item.Length >= 28)
                {
                    if (item.Substring(0, 20) == "DATE ADDED TO REPORT")
                        date1 = string.Concat("'", DQBLines[count].Substring(21, 7));
                    if (item.Substring(0, 29) == "DATE TO BE PURGED FROM REPORT")
                        date2 = string.Concat("'", DQBLines[count].Substring(30, 7));
                }

                if (item.Length >= 4)
                {
                    if (item.Substring(3, 1) == " "
                        && item.Substring(4, 1) != " "
                        && item.Substring(0, 3) != "ITM"
                        && item.Substring(4, 6) != "ON/OFF")
                    {
                        Passenger p = new Passenger();
                        p.Item = string.Concat("'", item.Substring(0, 3));
                        p.Name = item.Substring(4, 23);
                        p.TKTNumber = string.Concat("'", item.Substring(27, 13));
                        p.DKNumber = item.Substring(41, 6);
                        p.Original = string.Concat("'", item.Substring(53, 7));
                        p.DateAdd = date1;
                        p.DateToBe = date2;
                        PassengerList.Add(p);
                    }
                }
                count++;
            }
        }

        /// <summary>
        /// Verifica si existe respuesta de sabre para la entrada
        /// seleccionada
        /// </summary>
        /// <returns>exixtingDQB</returns>
        private bool SearchDQBAstETU
        {
            get
            {
                int row = 0;
                int col = 0;
                bool exixtingDQB = false;
                row = 0;
                col = 0;
                CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.UNUSED_ELECTRONIC_TICKET, ref row, ref col);
                if (row > 0)
                {
                    sabreConcat = sabreAnswer;
                    exixtingDQB = true;

                }
                else
                {
                    MessageBox.Show(Resources.TicketEmission.Constants.NO_EXISTE_DQB_AST_ETU, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDateBegin.Focus();
                    sabreConcat = string.Empty;
                    exixtingDQB = false;
                }
                return exixtingDQB;
            }
        }


        /// <summary>
        /// Envio de comando DQB*ETU cuando el usuario
        /// no ingresa ningun dato
        /// </summary>
        /// 
        private void DQBETUSendCommand()
        {
            //if (chkGenerateExcel.Checked)
            //{
            //    MessageBox.Show(Resources.TicketEmission.Tickets.NO_GENERA_EXCEL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            string send = string.Empty;
            sabreAnswer = string.Empty;
            send = Resources.TicketEmission.Constants.COMMANDS_DQB_AST_ETU;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }
            CreateExcel();
            //Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            //}

        }

        /// <summary>
        /// Envio del comando DQB*ETU agregandole la fecha
        /// que ingresa el usuario
        /// </summary>
        /// 
        private void DQBETUSendCommandDate()
        {
            string send = string.Empty;
            sabreAnswer = string.Empty;
            if (!string.IsNullOrEmpty(txtDateBegin.Text) && string.IsNullOrEmpty(txtDateEnd.Text))
            {
                dateBegin = txtDateBegin.Text;
                if (IsValidDate(dateBegin))
                {
                    send = string.Concat(Resources.TicketEmission.Constants.COMMANDS_DQB_AST_ETU, "/", dateBegin);
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        sabreAnswer = objCommand.SendReceive(send);
                    }
                    if (chkGenerateExcel.Checked)
                    {
                        CreateExcel();
                    }
                    else
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
            }
            if (!string.IsNullOrEmpty(txtDateBegin.Text) && !string.IsNullOrEmpty(txtDateEnd.Text))
            {
                dateBegin = txtDateBegin.Text;
                dateEnd = txtDateEnd.Text;
                if (IsValidDate(dateBegin) && IsValidDate(dateEnd))
                {
                    send = string.Concat(Resources.TicketEmission.Constants.COMMANDS_DQB_AST_ETU, "/", dateBegin, "-", dateEnd);
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        sabreAnswer = objCommand.SendReceive(send);
                    }
                    if (chkGenerateExcel.Checked)
                    {
                        CreateExcel();
                    }
                    else
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
            }


        }


        /// <summary>
        /// Envio del comando DQB*ETU agregandole el dk
        /// que ingresa el usuario
        /// </summary>
        /// 
        private void DQBETUSendCommandDK()
        {
            string send = string.Empty;
            sabreAnswer = string.Empty;
            dk = txtReportByDK.Text;
            send = string.Concat(Resources.TicketEmission.Constants.COMMANDS_DQB_AST_ETU, "/DK", dk);
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }
            if (chkGenerateExcel.Checked)
            {
                CreateExcel();
            }
            else
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }


        /// <summary>
        /// Envio del comando DQB*ETU agregandole el codigo
        /// de la airolinea que ingresa el usuario
        /// </summary>
        /// 
        private void DQBETUSendCommandAirline()
        {
            string send = string.Empty;
            sabreAnswer = string.Empty;
            airline = txtReportbyAirline.Text;
            send = string.Concat(Resources.TicketEmission.Constants.COMMANDS_DQB_AST_ETU, "/A", airline);
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }
            if (chkGenerateExcel.Checked)
            {
                CreateExcel();
            }
            else
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }

        /// <summary>
        /// Valida que la fecha sea correcta
        /// </summary>
        /// <param name="date">Dia que valida</param>
        /// <returns>isValide</returns>
        private bool IsValidDate(string date)
        {
            bool isValide = true;
            DateTime nuevo = new DateTime();
            try
            {
                nuevo = Convert.ToDateTime(date);
                //if (DateTime.Now < nuevo)
                //{
                //    MessageBox.Show(Resources.TicketEmission.Tickets.FECHA_NO_VALIDA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    chkreportByDate.Focus();
                //    isValide = false;
                //}
            }
            catch
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.FECHA_NO_EXISTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                chkreportByDate.Focus();
                isValide = false;
            }
            return isValide;

        }

        /// <summary>
        /// Envio del comando MD siempre y cuando la respuesta de 
        /// sabre no sea SCROLL‡
        /// </summary>
        private void ReportDBQBucle()
        {
            SendScrollCommand();
            if (!SearchEndScroll)
            {
                ReportDBQBucle();
            }
        }

        /// <summary>
        /// Función que envia el comando MD 
        /// </summary>
        private void SendScrollCommand()
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
        private bool SearchEndScroll
        {
            get
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
        }

        #endregion//End MethodsClass



        #region=====Create file excel=====

        /// <summary>
        /// Armado del archivo excel(encabezado y contenido) y guardado en 
        /// temporales
        /// </summary>
        private void CreateExcel()
        {
            if (SearchDQBAstETU)
            {
                ReportDBQBucle();
                FixDQBETUReport();
                Microsoft.VisualBasic.Devices.Computer MyComputer = new Microsoft.VisualBasic.Devices.Computer();
                string fileName = string.Empty;
                int count = 0;

                #region Generacion documento Excel

                using (MyCTSExcel objExcel = new MyCTSExcel())
                {
                    objExcel.CreateExcelObject("MyCTS");
                    if (objExcel.IsObjectCreated)
                    {
                        fileName = MyComputer.FileSystem.SpecialDirectories.Temp;
                        fileName = fileName + string.Format("\\TempFile_{0}.xls", Guid.NewGuid().ToString());

                        MyCTSExcel.Cell cell = null;
                        cell = new MyCTSExcel.Cell(2, 2, titulo);
                        cell.Bold = true;
                        cell.Wide = 6;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        objExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(3, 2, "ITM");
                        cell.Bold = true;
                        objExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(3, 3, "PASSENGER NAME");
                        cell.Bold = true;
                        objExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(3, 4, "TKT NUMBER");
                        cell.Bold = true;
                        objExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(3, 5, "DK NUMBER");
                        cell.Bold = true;
                        objExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(3, 6, "ORIGINAL DATE ISSUE");
                        cell.Bold = true;
                        objExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(3, 7, "DATE ADDED TO REPORT");
                        cell.Bold = true;
                        objExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(3, 8, "DATE TO BE PURGED FROM REPORT");
                        cell.Bold = true;
                        objExcel.CreateCell(cell);

                        #region Elementos2

                        count = 4;
                        int numberPassengers = PassengerList.Count;
                        progressBar1.Visible = true;
                        progressBar1.Maximum = numberPassengers;
                        progressBar1.Value = 0;
                        CommandsAPI2.send_MessageToEmulator(Resources.TicketEmission.Constants.GENERATING_FILE_EXCEL);

                        foreach (Passenger p in PassengerList)
                        {
                            cell = new MyCTSExcel.Cell(count, 2, p.Item);
                            objExcel.CreateCell(cell);
                            cell = new MyCTSExcel.Cell(count, 3, p.Name);
                            objExcel.CreateCell(cell);
                            cell = new MyCTSExcel.Cell(count, 4, p.TKTNumber);
                            objExcel.CreateCell(cell);
                            cell = new MyCTSExcel.Cell(count, 5, p.DKNumber);
                            objExcel.CreateCell(cell);
                            cell = new MyCTSExcel.Cell(count, 6, p.Original);
                            objExcel.CreateCell(cell);
                            cell = new MyCTSExcel.Cell(count, 7, p.DateAdd);
                            objExcel.CreateCell(cell);
                            cell = new MyCTSExcel.Cell(count, 8, p.DateToBe);
                            objExcel.CreateCell(cell);
                            progressBar1.Value = count - 3;
                            if (count % 20 == 0)
                                CommandsAPI2.send_MessageToEmulator(Resources.TicketEmission.Constants.GENERATING_FILE_EXCEL);
                            count++;

                        }

                        #endregion

                        objExcel.SaveFile(fileName);

                    }
                }
                if (!string.IsNullOrEmpty(fileName))
                {
                    Process proc = new Process();
                    proc.StartInfo.Arguments = "\"" + fileName + "\"";
                    proc.StartInfo.FileName = "EXCEL.EXE";
                    proc.Start();
                }
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);

                #endregion

            }

        }



        #endregion



        #region=====Change focus When a Textbox is Full=====

        //Evento txtControl_TextChanged
        private void txtControl_TextChanged(object sender, EventArgs e)
        {
            if (sender is SmartTextBox)
            {
                if (((SmartTextBox)sender).Text.Length > ((SmartTextBox)sender).MaxLength - 1)
                {
                    foreach (Control txt in this.Controls)
                    {
                        if (txt.TabIndex.Equals(((SmartTextBox)(sender)).TabIndex + 1))
                        {
                            txt.Focus();
                        }

                    }
                }
            }
            if (txtDateBegin.Text.Length == 5 && txtDateEnd.Text.Length == 5)
                btnAccept.Focus();
            if (txtReportByDK.Text.Length == 6)
                btnAccept.Focus();
            if (txtReportbyAirline.Text.Length == 2)
                btnAccept.Focus();

        }

        #endregion//End Change focus When a Textbox is Full


        #region =====Back to a Previous Usercontrol or Validate Enter KeyDown=====


        /// <summary>
        /// Aborta el proceso al presionar la tecla ESC
        /// o ejecutar las funciones al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData.Equals(Keys.Escape))
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }
        }


        #endregion//Back to a Previous Usercontrol or Validate Enter KeyDown


        #region===== Enable Disable Controls =====

        private void chkreportByDate_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkreportByDate.Checked)
            {

                txtDateBegin.Text = string.Empty;
                txtDateEnd.Text = string.Empty;
                txtDateBegin.Enabled = false;
                txtDateBegin.BackColor = SystemColors.Control;
                txtDateEnd.Enabled = false;
                txtDateEnd.BackColor = SystemColors.Control;

            }
            else
            {
                chkReportByAirline.Checked = false;
                chkPeportByDK.Checked = false;
                txtDateBegin.Enabled = true;
                //txtDateBegin.BackColor = Color.White;
                txtDateEnd.Enabled = true;
                txtDateEnd.BackColor = Color.White;
                txtDateBegin.Focus();

            }


        }

        private void chkPeportByDK_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkPeportByDK.Checked)
            {
                txtReportByDK.Text = string.Empty;
                txtReportByDK.Enabled = false;
                txtReportByDK.BackColor = SystemColors.Control;

            }
            else
            {
                chkReportByAirline.Checked = false;
                chkreportByDate.Checked = false;
                txtReportByDK.Enabled = true;
                //txtReportByDK.BackColor = Color.White;
                txtReportByDK.Focus();
            }
        }

        private void chkReportByAirline_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkReportByAirline.Checked)
            {
                txtReportbyAirline.Text = string.Empty;
                txtReportbyAirline.Enabled = false;
                txtReportbyAirline.BackColor = SystemColors.Control;

            }
            else
            {
                chkPeportByDK.Checked = false;
                chkreportByDate.Checked = false;
                txtReportbyAirline.Enabled = true;
                //txtReportbyAirline.BackColor = Color.White;
                txtReportbyAirline.Focus();

            }
        }

        #endregion// End Enable Disable controls





    }
}

