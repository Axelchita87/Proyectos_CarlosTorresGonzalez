using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using System.Diagnostics;

namespace MyCTS.Presentation
{
    public partial class ucSabanaGroup : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Genera sabana de grupo
        /// Creación:    Enero 2010 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Angel Trejo
        /// </summary>
        public ucSabanaGroup()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = rdoPNR;
            this.LastControlFocus = btnAccept;
        }
        //****************Global Constans*****************************
        private TextBox txt;
        private bool statusParamReceived;
        private List<InfoGroup> InfoGroupList = null;
        private class InfoGroup
        {
            public string Name;
            public string Origin;
            public string Destination;
            public string DepartureTime;
            public string ArrivalTime;
            public string AirlineCode;
            public string AirlineRef;
            public string FlightNumber;
            public string DepartureDate;
            public string PaxNumber;
            public string RecLoc;

        }
        //************************************************************


        private void ucSabanaGroup_Load(object sender, EventArgs e)
        {
            txtPNR.Visible = false;
            txtGroup.Visible = false;
            label1.Visible = false;
            HideListboxControls();
        }

        /// <summary>
        /// No permite el despliegue de predictivo cuando se
        /// carga la mascarilla
        /// </summary>
        private void HideListboxControls()
        {
            statusParamReceived = false;
        }

        private void btnSabana_Click(object sender, EventArgs e)
        {
            if (IsValidBussinesRules)
            {
                BuildSabana();
            }
        }

        #region ====== Methods Class ======

        /// <summary>
        /// Reglas de negocio aplicables a este user control
        /// </summary>
        private bool IsValidBussinesRules
        {
            get
            {
                bool status = false;
                if (!rdoGroup.Checked && !rdoPNR.Checked)
                    MessageBox.Show("SELECCIONE LA FORMA DE GENERAR EL REPORTE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (rdoPNR.Checked && string.IsNullOrEmpty(txtPNR.Text))
                {
                    MessageBox.Show("INGRESE EL RECORD LOCALIZADOR MAESTRO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPNR.Focus();
                }
                else if (rdoPNR.Checked && txtPNR.TextLength < txtPNR.MaxLength)
                {
                    MessageBox.Show("EL RECORD DEBE CONTENER 6 LETRAS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPNR.Focus();
                }
                else if (rdoGroup.Checked && string.IsNullOrEmpty(txtGroup.Text))
                {
                    MessageBox.Show("INGRESE EL ID DEL GRUPO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtGroup.Focus();
                }
                else
                    status = true;
                return status;

            }
        }

        /// <summary>
        /// Genera el archivo excel que contiene la información de la sabana de vuelo
        /// </summary>
        private void BuildSabana()
        {
            List<GetInfoGroup> indexList = new List<GetInfoGroup>();
            if (rdoPNR.Checked)
                indexList = GetInfoGroupBL.GetInfoGroup(txtPNR.Text, Login.OrgId);
            else
                indexList = GetInfoGroupByIDGroupBL.GetInfoGroup(txtGroup.Text, Login.OrgId);
            if (indexList.Count > 0)
            {
                CommandsAPI2.send_MessageToEmulator("GENERANDO SABANA DE VUELO, FAVOR DE ESPERAR.........");
                InfoGroupList = new List<InfoGroup>();
                progressBar1.Maximum = indexList.Count;
                for (int i = 0; i < indexList.Count; i++)
                {
                    InfoGroup info = new InfoGroup();
                    info.Name = string.Concat(indexList[i].PaxName, " ", indexList[i].PaxLastName);
                    info.Origin = indexList[i].Origin;
                    info.Destination = indexList[i].Destination;
                    info.DepartureTime = indexList[i].DepartureTime;
                    info.ArrivalTime = indexList[i].ArrivalTime;
                    info.AirlineCode = indexList[i].AirlineCode;
                    info.AirlineRef = indexList[i].AirlineRef;
                    info.FlightNumber = indexList[i].FlightNumber;
                    info.DepartureDate = Convert.ToString(indexList[i].DepartureDate);
                    info.PaxNumber = Convert.ToString(indexList[i].PaxNumber);
                    info.RecLoc = indexList[i].RecLoc;

                    InfoGroupList.Add(info);
                }
                Microsoft.VisualBasic.Devices.Computer MyComputer = new Microsoft.VisualBasic.Devices.Computer();
                string fileName = string.Empty; //Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);
                int count = 7;
                int j = 3;

                using (MyCTSExcel objExcel = new MyCTSExcel())
                {
                    objExcel.CreateExcelObject("MyCTS");
                    if (objExcel.IsObjectCreated)
                    {
                        fileName = MyComputer.FileSystem.SpecialDirectories.Temp;
                        fileName = fileName + string.Format("\\TempFile_{0}.xls", Guid.NewGuid().ToString());
                        MyCTSExcel.Cell cell = null;
                        cell = new MyCTSExcel.Cell(2, 2, string.Concat("SABANA DE VUELO ", indexList[0].IDGroup, " / RECORD MAESTRO: ", indexList[0].MasterPNR));
                        cell.Wide = 8;
                        cell.Bold = true;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        objExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(3, 2, string.Concat("REPORTE EMITIDO EL ",
                            DateTime.Now.ToString("dd/MMM/yyyy").ToUpper(), " a las ", DateTime.Now.ToString("HH:mm"), " Hrs."));
                        cell.Wide = 8;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        objExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(5, 3, "SEGMENTO 1");
                        cell.Wide = 7;
                        cell.Bold = true;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        objExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(6, 2, "Nombre");
                        cell.Bold = true;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        objExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(6, 3, "Origen");
                        cell.Bold = true;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        objExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(6, 4, "Destino");
                        cell.Bold = true;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        objExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(6, 5, "Salida");
                        cell.Bold = true;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        objExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(6, 6, "LLegada");
                        cell.Bold = true;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        objExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(6, 7, "LA");
                        cell.Bold = true;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        objExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(6, 8, "Vuelo");
                        cell.Bold = true;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        objExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(6, 9, "Fecha");
                        cell.Bold = true;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        objExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(6, 10, "Clave Aerolínea");
                        cell.Bold = true;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        objExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(6, 11, "Clave Aerolínea");
                        cell.Bold = true;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        objExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(count, 2, InfoGroupList[0].Name);
                        objExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(count, 3, InfoGroupList[0].Origin);
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        objExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(count, 4, InfoGroupList[0].Destination);
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        objExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(count, 5, InfoGroupList[0].DepartureTime);
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        objExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(count, 6, InfoGroupList[0].ArrivalTime);
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        objExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(count, 7, InfoGroupList[0].AirlineCode);
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        objExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(count, 8, InfoGroupList[0].FlightNumber);
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        objExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(count, 9, InfoGroupList[0].DepartureDate.Substring(0, 10));
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        objExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(count, 10, InfoGroupList[0].AirlineRef);
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        objExcel.CreateCell(cell);
                        cell = new MyCTSExcel.Cell(count, 11, InfoGroupList[0].RecLoc);
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        objExcel.CreateCell(cell);
                        progressBar1.Visible = true;
                        progressBar1.Value = 1;
                        int barValue = 1;
                        int count2 = 0;
                        int max = 0;
                        int aux = 0;
                        for (int i = 1; i < InfoGroupList.Count; i++)
                        {
                            if (InfoGroupList[i].PaxNumber == InfoGroupList[i - 1].PaxNumber)
                            {
                                j = j + 8;
                                cell = new MyCTSExcel.Cell(count, j, InfoGroupList[i].Origin);
                                cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                                objExcel.CreateCell(cell);
                                cell = new MyCTSExcel.Cell(count, j + 1, InfoGroupList[i].Destination);
                                cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                                objExcel.CreateCell(cell);
                                cell = new MyCTSExcel.Cell(count, j + 2, InfoGroupList[i].DepartureTime);
                                cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                                objExcel.CreateCell(cell);
                                cell = new MyCTSExcel.Cell(count, j + 3, InfoGroupList[i].ArrivalTime);
                                cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                                objExcel.CreateCell(cell);
                                cell = new MyCTSExcel.Cell(count, j + 4, InfoGroupList[i].AirlineCode);
                                cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                                objExcel.CreateCell(cell);
                                cell = new MyCTSExcel.Cell(count, j + 5, InfoGroupList[i].FlightNumber);
                                cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                                objExcel.CreateCell(cell);
                                cell = new MyCTSExcel.Cell(count, j + 6, InfoGroupList[i].DepartureDate.Substring(0, 10));
                                cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                                objExcel.CreateCell(cell);
                                cell = new MyCTSExcel.Cell(count, j + 7, InfoGroupList[i].AirlineRef);
                                cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                                objExcel.CreateCell(cell);
                                cell = new MyCTSExcel.Cell(count, j + 8, InfoGroupList[i].RecLoc);
                                cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                                objExcel.CreateCell(cell);
                                count2++;
                                if (barValue % 19 == 0)
                                    CommandsAPI2.send_MessageToEmulator("GENERANDO SABANA DE VUELO, FAVOR DE ESPERAR.........");
                                barValue++;
                                progressBar1.Value = barValue;
                            }
                            else
                            {
                                aux = count2;
                                if (aux > max)
                                    max = aux;
                                else
                                    max = count2;
                                count2 = 0;
                                j = 3;
                                count++;
                                cell = new MyCTSExcel.Cell(count, 2, InfoGroupList[i].Name);
                                objExcel.CreateCell(cell);
                                cell = new MyCTSExcel.Cell(count, 3, InfoGroupList[i].Origin);
                                cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                                objExcel.CreateCell(cell);
                                cell = new MyCTSExcel.Cell(count, 4, InfoGroupList[i].Destination);
                                cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                                objExcel.CreateCell(cell);
                                cell = new MyCTSExcel.Cell(count, 5, InfoGroupList[i].DepartureTime);
                                cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                                objExcel.CreateCell(cell);
                                cell = new MyCTSExcel.Cell(count, 6, InfoGroupList[i].ArrivalTime);
                                cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                                objExcel.CreateCell(cell);
                                cell = new MyCTSExcel.Cell(count, 7, InfoGroupList[i].AirlineCode);
                                cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                                objExcel.CreateCell(cell);
                                cell = new MyCTSExcel.Cell(count, 8, InfoGroupList[i].FlightNumber);
                                cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                                objExcel.CreateCell(cell);
                                cell = new MyCTSExcel.Cell(count, 9, InfoGroupList[i].DepartureDate.Substring(0, 10));
                                cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                                objExcel.CreateCell(cell);
                                cell = new MyCTSExcel.Cell(count, 10, InfoGroupList[i].AirlineRef);
                                cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                                objExcel.CreateCell(cell);
                                cell = new MyCTSExcel.Cell(count, 11, InfoGroupList[i].RecLoc);
                                cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                                objExcel.CreateCell(cell);
                                if (barValue % 19 == 0)
                                    CommandsAPI2.send_MessageToEmulator("GENERANDO SABANA DE VUELO, FAVOR DE ESPERAR.........");
                                barValue++;
                                progressBar1.Value = barValue;
                            }
                        }
                        aux = count2;
                        if (aux > max)
                            max = aux;
                        else
                            max = count2;
                        aux = 11;
                        for (int k = 0; k < max; k++)
                        {
                            cell = new MyCTSExcel.Cell(5, aux, string.Concat(" SEGMENTO ", k + 2, " "));
                            cell.Wide = 7;
                            cell.Bold = true;
                            cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                            objExcel.CreateCell(cell);
                            cell = new MyCTSExcel.Cell(6, aux, " Origen ");
                            cell.Bold = true;
                            cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                            objExcel.CreateCell(cell);
                            cell = new MyCTSExcel.Cell(6, aux + 1, " Destino ");
                            cell.Bold = true;
                            cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                            objExcel.CreateCell(cell);
                            cell = new MyCTSExcel.Cell(6, aux + 2, " Salida ");
                            cell.Bold = true;
                            cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                            objExcel.CreateCell(cell);
                            cell = new MyCTSExcel.Cell(6, aux + 3, " Llegada ");
                            cell.Bold = true;
                            cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                            objExcel.CreateCell(cell);
                            cell = new MyCTSExcel.Cell(6, aux + 4, " LA ");
                            cell.Bold = true;
                            cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                            objExcel.CreateCell(cell);
                            cell = new MyCTSExcel.Cell(6, aux + 5, " Vuelo ");
                            cell.Bold = true;
                            cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                            objExcel.CreateCell(cell);
                            cell = new MyCTSExcel.Cell(6, aux + 6, " Fecha ");
                            cell.Bold = true;
                            cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                            objExcel.CreateCell(cell);
                            cell = new MyCTSExcel.Cell(6, aux + 7, " Clave Aerolínea ");
                            cell.Bold = true;
                            cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                            objExcel.CreateCell(cell);
                            aux = aux + 8;
                        }
                        cell = new MyCTSExcel.Cell(6, aux, " Record ");
                        cell.Bold = true;
                        cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                        objExcel.CreateCell(cell);
                    }
                    objExcel.SaveFile(fileName);
                }
                if (!string.IsNullOrEmpty(fileName))
                {
                    Process proc = new Process();
                    proc.StartInfo.Arguments = "\"" + fileName + "\"";
                    proc.StartInfo.FileName = "EXCEL.EXE";
                    proc.Start();
                }
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            else
            {
                if (rdoPNR.Checked)
                    MessageBox.Show("EL RECORD LOCALIZADOR NO VALIDO O INEXISTENTE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (!GetInfoGroupByIDGroupBL.Status)
                    MessageBox.Show("EL NOMBRE DE GRUPO NO EXISTE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("EL GRUPO AUN NO CONTIENE PASAJEROS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }

        }

        #endregion //Methods Class

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
                btnSabana_Click(sender, e);
        }


        #endregion//Back to a Previous Usercontrol or Validate Enter KeyDown


        /// <summary>
        /// Acciones que se ejecutan cuando cambia el check de un radiobutton 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoPNR_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Ingrese el record maestro";
            label1.Visible = true;
            txtPNR.Visible = true;
            txtGroup.Visible = false;
        }
        /// <summary>
        /// Acciones que se ejecutan cuando cambia el check de un radiobutton 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoGroup_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Ingrese el nombre del grupo";
            label1.Visible = true;
            txtGroup.Visible = true;
            txtPNR.Visible = false;
        }

        #region ====== Predictives ======

        /// <summary>
        /// Activación del predictivo al presentarse un cambio en la caja de texto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtGroup_TextChanged(object sender, EventArgs e)
        {
            if (!statusParamReceived)
            {
                txt = (TextBox)sender;
                Common.SetListBoxIDGroup(txt, lbIDGroup);
            }
        }

        /// <summary>
        /// Asignacion de acciones al presionar ESC 
        /// cuando el listbox tiene el foco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbIDGroup_KeyDown(object sender, KeyEventArgs e)
        {
            ListBox ListBox = (ListBox)sender;
            if (e.KeyCode == Keys.Enter)
            {
                ListItem li = (ListItem)ListBox.SelectedItem;
                txt.Text = li.Value;
                ListBox.Visible = false;
                txt.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {

                lbIDGroup.Visible = false;
                txt.Focus();
            }
        }

        /// <summary>
        /// Asignacion de acciones al presionar la tecla ENTER, ESC o DOWN
        /// cuando algún txt de ciudades tiene el foco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IDGroupActions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            if (e.KeyData == Keys.Enter)
            {
                btnSabana_Click(sender, e);
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lbIDGroup.Items.Count > 0)
                {
                    lbIDGroup.SelectedIndex = 0;
                    lbIDGroup.Focus();
                    lbIDGroup.Visible = true;
                    lbIDGroup.Focus();
                }
            }

        }

        /// <summary>
        /// Selecciona algún elemento dentro de algún listbox al hacer un click
        /// sobre el
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_MouseClick(object sender, MouseEventArgs e)
        {
            ListBox listBox = (ListBox)sender;

            ListItem li = (ListItem)listBox.SelectedItem;
            txt.Text = li.Value;
            listBox.Visible = false;
            txt.Focus();
        }

        #endregion //Predictives

    }
}
