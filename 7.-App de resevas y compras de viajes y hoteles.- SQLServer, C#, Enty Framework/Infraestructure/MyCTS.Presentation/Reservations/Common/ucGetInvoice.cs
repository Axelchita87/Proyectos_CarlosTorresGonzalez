using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using MyCTS.Forms.UI;
using System.Net;
using System.IO;
using System.Diagnostics;
using MyCTS.Services.Contracts;

namespace MyCTS.Presentation
{
    public partial class ucGetInvoice : CustomUserControl
    {

        /// <summary>
        /// Descripción: User Control que permite revisar la factura de un boleto
        ///              y también el boleto electrónico por medio de virtually there
        /// Creación:    Diciembre 22, 2009. Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Angel Trejo
        /// </summary>
        /// 
        
        private List<GetLinkByTkt> indexList = new List<GetLinkByTkt>();
        private string linkInvoice = string.Empty;

        public ucGetInvoice()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtInvoice;
            this.LastControlFocus = btnAccept;

        }
        
        private void ucGetInvoice_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            if (this.Parameters[0] == "2")
                lblChargePerService.Text = "Recibo de boleto electrónico";
            txtInvoice.Focus();
        }
        
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidBussinesRules)
            {
                if (this.Parameters[0] == "1")
                    SendURL();
                if(this.Parameters[0] == "2")
                    GetLinkVirtualyThere();
            }
        }

        #region====== Methods Class ======

        /// <summary>
        /// Valida las reglas de negocio aplicables a este user control
        /// </summary>                
        private bool IsValidBussinesRules
        {
            get 
            {
                bool isValid = false;
                if (string.IsNullOrEmpty(txtInvoice.Text))
                {
                    MessageBox.Show("DEBES INGRESAR EL NÚMERO DE BOLETO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtInvoice.Focus();
                }
                else if (txtInvoice.MaxLength != txtInvoice.TextLength)
                {
                    MessageBox.Show("EL FORMATO DE NÚMERO DE BOLETO DEBE SER DE 10 DÍGITOS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtInvoice.Focus();
                }
                else
                {
                    isValid = true;
                }
                return isValid;
            }
        }

        private void SendURL()
        {
            BuildElectronicTicketContract ws = new BuildElectronicTicketContract();
            string request = ws.Encrypt(string.Concat(txtInvoice.Text, ";", Login.Firm, ";", Login.passWord, ";", Login.PCC));
            string url = string.Concat("http://201.149.13.14/Login.aspx?byPass=", request);
            Process.Start(url);
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }

        /// <summary>
        /// Obtiene la factura de un boleto en formato PDF y la guarda en 
        /// archivos temporales del usuario
        /// </summary>
        private void GetInvoice()
        {
            linkInvoice = string.Empty;
            indexList.Clear();
            GridViewFacturas.Visible = false;
            lblInfoFacturas.Visible = false;
            indexList = GetLinkByTktBL.GetLinkByTkt(txtInvoice.Text, Login.OrgId);
            if (indexList.Count > 0)
            {
                if (!string.IsNullOrEmpty(indexList[0].LinkInvoice) && indexList.Count == 1)
                {
                    linkInvoice = indexList[0].LinkInvoice;
                    Microsoft.VisualBasic.Devices.Computer MyComputer = new Microsoft.VisualBasic.Devices.Computer();
                    string fileName = string.Empty;
                    fileName = MyComputer.FileSystem.SpecialDirectories.Temp;
                    fileName = fileName + string.Format("\\TempFile_{0}.pdf", Guid.NewGuid().ToString());
                    if (DownloadFile(linkInvoice, fileName))
                    {
                        try
                        {
                            Process.Start(fileName);
                            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);

                        }
                        catch
                        {
                            MessageBox.Show("NO CUENTA CON EL PROGRAMA CORRECTO PARA ABRIR ESTE ARCHIVO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                        }
                    }
                }
                else if (string.IsNullOrEmpty(indexList[0].LinkInvoice))
                {
                    CommandsAPI2.send_MessageToEmulator("BUSCANDO FACTURA, FAVOR DE ESPERAR.................");
                    Parameter timeOut = ParameterBL.GetParameterValue("TimeOutInvoice");
                    int time = Convert.ToInt32(timeOut.Values);
                    AddLinksInvoicesPerTicketBL.AddLinksInvoicesPerTicket(txtInvoice.Text, time);
                    indexList.Clear();
                    indexList = GetLinkByTktBL.GetLinkByTkt(txtInvoice.Text, Login.OrgId);
                    if (string.IsNullOrEmpty(indexList[0].LinkInvoice))
                    {
                        MessageBox.Show("LA INTERFASE AUN NO HA PROCESADO SU FACTURA, FAVOR DE VERIFICARLO MAS TARDE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                    }
                    else if (!string.IsNullOrEmpty(indexList[0].LinkInvoice) && indexList.Count == 1)
                    {
                        linkInvoice = indexList[0].LinkInvoice;
                        Microsoft.VisualBasic.Devices.Computer MyComputer = new Microsoft.VisualBasic.Devices.Computer();
                        string fileName = string.Empty;
                        fileName = MyComputer.FileSystem.SpecialDirectories.Temp;
                        fileName = fileName + string.Format("\\TempFile_{0}.pdf", Guid.NewGuid().ToString());
                        if (DownloadFile(linkInvoice, fileName))
                        {
                            try
                            {
                                Process.Start(fileName);
                                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);

                            }
                            catch
                            {
                                MessageBox.Show("NO CUENTA CON EL PROGRAMA CORRECTO PARA ABRIR ESTE ARCHIVO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                            }
                        }
                    }
                    else if (!string.IsNullOrEmpty(indexList[0].LinkInvoice) && indexList.Count > 1)
                    {
                        GridViewFacturas.Visible = true;
                        GridViewFacturas.Rows.Clear();
                        int index = 0;
                        int index2 = 0;
                        for (int i = 0; i < indexList.Count; i++)
                        {
                            index = indexList[i].LinkInvoice.LastIndexOf(".");
                            index2 = indexList[i].LinkInvoice.LastIndexOf("/");
                            GridViewFacturas.Rows.Add(indexList[i].LinkInvoice.Substring(54, (index - index2 - 1)), indexList[i].DescriptionType);
                        }
                        GridViewFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        lblInfoFacturas.Visible = true;
                    }
                }
                else if (!string.IsNullOrEmpty(indexList[0].LinkInvoice) && indexList.Count > 1)
                {
                    GridViewFacturas.Visible = true;
                    GridViewFacturas.Rows.Clear();
                    int index = 0;
                    int index2 = 0;
                    for (int i = 0; i < indexList.Count; i++)
                    {
                        index = indexList[i].LinkInvoice.LastIndexOf(".");
                        index2 = indexList[i].LinkInvoice.LastIndexOf("/");
                        GridViewFacturas.Rows.Add(indexList[i].LinkInvoice.Substring(54,(index-index2-1)), indexList[i].DescriptionType);
                    }
                    GridViewFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    lblInfoFacturas.Visible = true;
                }
                
            }
            else
            {
                
                MessageBox.Show("EL NÚMERO DE BOLETO NO EXISTE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
        }

        /// <summary>
        /// Abre los archivos PDF indicados por el GridView
        /// </summary>
        private void OpenFilesPDF()
        {
            linkInvoice = string.Empty;
            int item = GridViewFacturas.CurrentCell.RowIndex;
            linkInvoice = indexList[item].LinkInvoice;
            Microsoft.VisualBasic.Devices.Computer MyComputer = new Microsoft.VisualBasic.Devices.Computer();
            string fileName = string.Empty;
            fileName = MyComputer.FileSystem.SpecialDirectories.Temp;
            fileName = fileName + string.Format("\\TempFile_{0}.pdf", Guid.NewGuid().ToString());
            if (DownloadFile(linkInvoice, fileName))
            {
                try
                {
                    Process.Start(fileName);
                }
                catch
                {
                    MessageBox.Show("NO CUENTA CON EL PROGRAMA CORRECTO PARA ABRIR ESTE ARCHIVO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
            }
        }


       
        /// <summary>
        /// Obtiene el link que permite revisar un boleto electrónico por medio
        /// de virtually there y abre la pagina web que lo contiene
        /// </summary>
        private void GetLinkVirtualyThere()
        {
            string linkVirtually = string.Empty;
            List<GetLinkByTkt> indexList = new List<GetLinkByTkt>();
            indexList = GetLinkByTktBL.GetLinkByTkt(txtInvoice.Text, Login.OrgId);
            if (indexList.Count > 0)
            {
                if (!string.IsNullOrEmpty(indexList[0].LinkVirtuallyThere))
                {
                    linkVirtually = indexList[0].LinkVirtuallyThere;
                    try
                    {
                        Process.Start(linkVirtually);
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                    }
                    catch
                    {
                        MessageBox.Show("EXISTE UN PROBLEMA CON LA RED, INTENTELO MÁS TARDE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                    }
                }
                else
                {
                    MessageBox.Show("NO EXISTE RECIBO ELECTRÓNICO PARA ESTE BOLETO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
            }
            else
            {
                MessageBox.Show("EL NÚMERO DE BOLETO NO EXISTE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
        }

        /// <summary>
        /// Descargar y escribe el archivo especificado en la carpeta temporales
        /// de cada usuario
        /// </summary>
        /// <param name="file">Archivo PDF a descargar de internet</param>
        /// <param name="localFileName">Localización en donde se guardara el archivo</param>
        /// <returns></returns>
        private bool DownloadFile(string file, string localFileName)
        {
            bool status = true;
            int bytesProcessed = 0;
            int index = file.LastIndexOf(".");
            int index2 = file.LastIndexOf("/");
            Stream remoteStream = null;
            Stream localStream = null;
            WebResponse response = null;
            try
            {
                WebRequest request = WebRequest.Create(file);
                if (request != null)
                {
                    response = request.GetResponse();
                    if (response != null)
                    {
                        remoteStream = response.GetResponseStream();
                        localStream = File.Create(localFileName);
                        byte[] buffer = new byte[1024];
                        int bytesRead;
                        do
                        {
                            bytesRead = remoteStream.Read(buffer, 0, buffer.Length);
                            localStream.Write(buffer, 0, bytesRead);
                            bytesProcessed += bytesRead;
                        } 
                        while (bytesRead > 0);
                    }
                }
            }
            catch 
            {
                status = false;
                MessageBox.Show(string.Concat("SU FACTURA ", file.Substring(54, index - index2 - 1), " ESTA EN PROCESO DE GENERACIÓN, FAVOR DE INTENTARLO MAS TARDE"), Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            finally
            {
                if (response != null) response.Close();
                if (remoteStream != null) remoteStream.Close();
                if (localStream != null) localStream.Close();
            }
            return status;

        }
        #endregion

        #region===== GridView Events =====

        //Evento GridViewFacturas_Click
        private void GridViewFacturas_Click(object sender, DataGridViewCellEventArgs e)
        {
            OpenFilesPDF();
        }
        
        #endregion

        #region=====Change focus When a Textbox is Full=====

        //Evento txtControls_TextChanged
        private void txtControls_TextChanged(object sender, EventArgs e)
        {
            if (sender is SmartTextBox)
                if (((SmartTextBox)sender).Text.Length > ((SmartTextBox)sender).MaxLength - 1)
                    foreach (Control txt in this.Controls)
                        if (txt.TabIndex.Equals(((SmartTextBox)(sender)).TabIndex + 1))
                            txt.Focus();
                      
        }

        #endregion//End Change focus When a Textbox is Full

        #region =====Back to a Previous Usercontrol or Validate Enter KeyDown=====

        /// <summary>
        /// Regresa al user cotrol welcome cuando se presiona ESC o ejecuta
        /// la acción del botón aceptar cuando se presiona Enter
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

        #endregion // Back to a Previous Usercontrol or Validate Enter KeyDown

       
    }
}
