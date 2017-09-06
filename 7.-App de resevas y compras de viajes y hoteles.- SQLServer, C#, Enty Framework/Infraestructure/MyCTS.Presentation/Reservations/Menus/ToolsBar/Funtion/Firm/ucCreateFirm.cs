using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Services.Contracts;

namespace MyCTS.Presentation
{
    public partial class ucCreateFirm : CustomUserControl
    {

        /// <summary>
        /// Descripcion: Permite crear firma en Sabre y en MyCTS
        /// Creación:    30-Abril-10 , Modificación:18-06-10
        /// Cambio:        Asignar con copia para  , Solicito Roberto Aviles
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        private TextBox txt;
        private bool statusValidPCC = false;
        private bool onlyagent = false;
        private string body = string.Empty;
        string key8;
        string key9;
        string key10;
        string key11;
        string key12;

        public ucCreateFirm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            InitialControlFocus = txtNumberFirm;
            LastControlFocus = btnAccept;
        }

        //Extrae el UserName y lo asigna, coloca el foco en el txt 
        private void ucCreateFirm_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            string agent = string.Empty;
            CatQueue item = CatQueueBL.GetQueue(Login.Firm, Login.PCC);
            if (!string.IsNullOrEmpty(item.Agent))
            {
                agent = item.Agent;
            }
            txtAuthorization.Text = agent;
            txtNumberFirm.Focus();
            lbPCC.BringToFront();
            txtCodeAgent.Text = GetAllFirmModulesForNewUserBL.GetAgent().AgentCode;
            txtNumberFirm.Text = GetAllFirmModulesForNewUserBL.GetFirm().FirmNumber;
            

            DialogResult result = MessageBox.Show("¿Este usuario utiliza queue genérica?", Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.Yes))
            {
                txtQueue.Text = "152";
            }
            else
                txtQueue.Text = GetAllFirmModulesForNewUserBL.GetQueue().QueueCode;
        }

        //Valida si el PCC es correcto y manda a llamar los metodos de validación y envió de comando
        private void btnAccept_Click(object sender, EventArgs e)
        {
            List<ListItem> CatPccsList = CatPccsBL.GetPccs(txtPCC.Text,Login.OrgId);
            if (CatPccsList.Count.Equals(0))
                statusValidPCC = true;
            else
                statusValidPCC = false;
            if (IsValidateBusinessRules)
            {
                CommandsSend();

               
            }

        }

        //KeyDown
        /// <summary>
        /// Este se usa para todos los controles en general si se oprime 
        /// Esc se manda a el User control de Welcome 
        /// Enter se manda la accion de botón de Aceptar
        /// KeyDown se manda el foco al listBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
            if (e.KeyCode == Keys.Down)
            {
                if (lbPCC.Items.Count > 0)
                {
                    lbPCC.SelectedIndex = 0;
                    lbPCC.Focus();
                }
            }
        }

        #region ====== Events ====

        //Show ListBox
        private void txtPCC_TextChanged(object sender, EventArgs e)
        {
            txt = (TextBox)sender;
            Common.SetListBoxPCCs(txt, lbPCC);
            if (txtPCC.Text.Length == 4)
            {
                txtTA.Text = GetAllFirmModulesForNewUserBL.GetTA(txtPCC.Text).Code;
            }
        }

        //KeyDow ListBox
        private void lbPCC_KeyDown(object sender, KeyEventArgs e)
        {
            ListBox ListBox = (ListBox)sender;
            TextBox txt = txtPCC;

            if (e.KeyCode == Keys.Enter)
            {
                ListItem li = (ListItem)ListBox.SelectedItem;
                txt.Text = li.Value;
                lbPCC.Visible = false;
                txt.Focus();
            }
        }

        //Mouse Click
        private void ListBox_MouseClick(object sender, MouseEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            TextBox txt = txtPCC;

            ListItem li = (ListItem)listBox.SelectedItem;
            txt.Text = li.Value;
            lbPCC.Visible = false;
            txt.Focus();
        }


        private void cmbKeyWord8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKeyWord8.SelectedIndex > 1)
                key8 = cmbKeyWord8.Text.Substring(0, 6);
        }

        private void cmbKeyWord9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKeyWord9.SelectedIndex > 1)
                key9 = cmbKeyWord9.Text.Substring(0, 6);
        }

        private void cmbKeyWord10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKeyWord10.SelectedIndex > 1)
                key10 = cmbKeyWord10.Text.Substring(0, 6);
        }

        private void cmbKeyWord11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKeyWord11.SelectedIndex > 1)
                key11 = cmbKeyWord11.Text.Substring(0, 6);
        }

        private void cmbKeyWord12_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKeyWord12.SelectedIndex > 1)
                key12 = cmbKeyWord12.Text.Substring(0, 6);
        }

        #endregion

        #region ====== Change Focus =====

        private void txtNumberFirm_TextChanged(object sender, EventArgs e)
        {
            if (txtNumberFirm.Text.Length > 3)
                txtCodeAgent.Focus();
        }

        private void txtCodeAgent_TextChanged(object sender, EventArgs e)
        {
            if (txtCodeAgent.Text.Length > 1)
                txtPCC.Focus();
        }

        private void txtPassCode_TextChanged(object sender, EventArgs e)
        {
            if (txtPassCode.Text.Length > 7)
                txtQueue.Focus();
        }

        private void txtQueue_TextChanged(object sender, EventArgs e)
        {
            if (txtQueue.Text.Length > 2)
                txtTA.Focus();
        }

        private void txtTA_TextChanged(object sender, EventArgs e)
        {
            if (txtTA.Text.Length > 5)
                txtLastName.Focus();
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            if (txtLastName.Text.Length > 11)
                txtInitial.Focus();
        }

        private void txtInitial_TextChanged(object sender, EventArgs e)
        {
            if (txtInitial.Text.Length > 0)
                txtName.Focus();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 39)
                txtEmail.Focus();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (txtEmail.Text.Length > 49)
                textAgentMail.Focus();
        }

        private void textAgentMail_TextChanged(object sender, EventArgs e)
        {
            if ( textAgentMail.Text.Length > 49)
                txtName.Focus();

        }



        private void txtAuthorization_TextChanged(object sender, EventArgs e)
        {
            if (txtAuthorization.Text.Length > 19)
                chkMINIOPR.Focus();
        }

        #endregion

        #region ===== methodsClass =====

        /// <summary>
        /// Se validan que existan los datos que son obligatorios y que 
        /// sean los datos correctos
        /// </summary>
        private bool IsValidateBusinessRules
        {
            get
            {
                bool isValid = false;

                if (string.IsNullOrEmpty(txtNumberFirm.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_NUMERO_FIRMA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberFirm.Focus();
                }
                else if (string.IsNullOrEmpty(txtCodeAgent.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_CÓDIGO_AGENTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCodeAgent.Focus();
                }
                else if (string.IsNullOrEmpty(txtPCC.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESE_PCC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPCC.Focus();
                }
                else if (!string.IsNullOrEmpty(txtPCC.Text) && txtPCC.Text.Length < 4)
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_PCC_CORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPCC.Focus();
                }
                else if (statusValidPCC)
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_PCC_CORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPCC.Focus();
                }
                else if (string.IsNullOrEmpty(txtPassCode.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_PASSCODE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassCode.Focus();
                }
                else if (string.IsNullOrEmpty(txtQueue.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_QUEUE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQueue.Focus();
                }
                else if (string.IsNullOrEmpty(txtTA.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_TA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTA.Focus();
                }
                else if (string.IsNullOrEmpty(txtLastName.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_APELLIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLastName.Focus();
                }
                else if (string.IsNullOrEmpty(txtInitial.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_INICIAL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtInitial.Focus();
                }
                else if (string.IsNullOrEmpty(txtName.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_NOMBRE_COMPLETO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Focus();
                }
                else if (string.IsNullOrEmpty(txtEmail.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_MAIL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmail.Focus();
                }

                else if (!string.IsNullOrEmpty(textAgentMail.Text) && !ValidateRegularExpression.ValidateEmailFormat(textAgentMail.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.FORMATO_CORREO_ELECT_INCORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textAgentMail.Focus();
                }

                else if (string.IsNullOrEmpty(txtAuthorization.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_AUTORIZADO_POR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAuthorization.Focus();
                }
                else if (rbnSabre.Checked == false && rbnMyCTS.Checked == false && rbnBoth.Checked == false)
                {
                    MessageBox.Show("REQUIERE SELECCIONAR EL LUGAR DE CREACIÓN", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    isValid = true;
                }
                return isValid;
            }
        }

        /// <summary>
        /// Se envia el comando de acuerdo a los campos ingresados
        /// </summary>
        private void CommandsSend()
        {
            int row = 0;
            int col = 0;
            string sendPCC = string.Empty;
            string res = string.Empty;
            bool conected = false;

            

            if (rbnBoth.Checked)
            {
                sendPCC = string.Concat(sendPCC, "AAA", txtPCC.Text);
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    res = objCommand.SendReceive(sendPCC);
                }
                CommandsQik.searchResponse(res, txtPCC.Text, ref row, ref col);
                if (row != 0 || col != 0)
                {
                    conected = true;
                }
                else
                    MessageBox.Show("ERROR EN LA CONEXIÓN CON MySABRE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (conected)
                {
                
                    string result = string.Empty;
                    string send = string.Empty;
                    string sabre = string.Empty;
                    string authorization = string.Empty;
                    string keywords = string.Empty;
                    string pass = string.Empty;
                    string codeagent = string.Empty;
                    row = 0;
                    col = 0;

                    if (!onlyagent)
                    {
                        send = string.Concat(send, "HB", txtNumberFirm.Text);
                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            result = objCommand.SendReceive(send);
                        }
                        CommandsQik.searchResponse(result, "NEW EMPLOYEE", ref row, ref col);
                        if (row != 0 || col != 0)
                        {
                            row = 0;
                            col = 0;
                            send = string.Empty;
                            send = string.Concat("H/NAM", txtLastName.Text, "/", txtInitial.Text);
                            sabre = "H/DTY6*/";
                            if (chkDutyCode.Checked)
                                sabre = string.Concat(sabre, "9");
                            authorization = string.Concat(authorization, "H/AUTH BY", txtAuthorization.Text);
                            keywords = "H/UAT/A-24TIME,SUBAAA,PFKAGT,PTRAGT";
                            if (chkMINIOPR.Checked)
                                keywords = string.Concat(keywords, ",MINOPR");
                            if (chkCreate.Checked)
                                keywords = string.Concat(keywords, ",CREATE");
                            if (chkAccess.Checked)
                                keywords = string.Concat(keywords, ",ACCESS");
                            if (chkCIIMGR.Checked)
                                keywords = string.Concat(keywords, ",CIIMGR");
                            if (chkSUBMGR.Checked)
                                keywords = string.Concat(keywords, ",SUBMGR");
                            if (chkPNRREL.Checked)
                                keywords = string.Concat(keywords, ",PNRREL");
                            if (chkSUBACC.Checked)
                                keywords = string.Concat(keywords, ",SUBACC");
                            if (cmbKeyWord8.SelectedIndex > 0)
                                keywords = string.Concat(keywords, ",", cmbKeyWord8.Text);
                            if (cmbKeyWord9.SelectedIndex > 0)
                                keywords = string.Concat(keywords, ",", cmbKeyWord9.Text);
                            if (cmbKeyWord10.SelectedIndex > 0)
                                keywords = string.Concat(keywords, ",", cmbKeyWord10.Text);
                            if (cmbKeyWord11.SelectedIndex > 0)
                                keywords = string.Concat(keywords, ",", cmbKeyWord11.Text);
                            if (cmbKeyWord12.SelectedIndex > 0)
                                keywords = string.Concat(keywords, ",", cmbKeyWord12.Text);

                            pass = string.Concat(pass, "H/PASS", txtPassCode.Text);
                            codeagent = string.Concat(codeagent, "HH/A", txtCodeAgent.Text);
                            using (CommandsAPI objCommand = new CommandsAPI())
                            {
                                objCommand.SendReceive(send);
                                objCommand.SendReceive(sabre);
                                objCommand.SendReceive("H/ASO240");
                                objCommand.SendReceive(authorization);
                                objCommand.SendReceive(keywords);
                                objCommand.SendReceive(pass);
                                result = objCommand.SendReceive(codeagent);
                            }
                        }
                        else
                        {
                            MessageBox.Show("LA FIRMA YA EXISTE, INGRESE AL MODULO DE MODIFICACIONES PARA CAMBIOS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            using (CommandsAPI objCommand = new CommandsAPI())
                            {
                                result = objCommand.SendReceive("I");
                            }
                            CommandsQik.searchResponse(result, "IGN", ref row, ref col);
                        }
                    }
                    else
                    {
                        codeagent = string.Concat(codeagent, "HH/A", txtCodeAgent.Text);
                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            result = objCommand.SendReceive(codeagent);
                        }
                    }
                    CommandsQik.searchResponse(result, "DUP", ref row, ref col);
                    if (row != 0 || col != 0)
                    {
                        MessageBox.Show("EL CODIGO DE AGENTE YA EXISTE, INGRESE OTRO!", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCodeAgent.Focus();
                        onlyagent = true;
                        row = 0;
                        col = 0;
                    }
                    CommandsQik.searchResponse(result, "DONE", ref row, ref col);
                    if (row != 0 || col != 0)
                    {
                        row = 0;
                        col = 0;
                        sabre = string.Empty;
                        sabre = string.Concat("QS/", txtPCC.Text, txtQueue.Text, "/A-", txtCodeAgent.Text);
                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            result = objCommand.SendReceive(sabre);
                        }
                        CommandsQik.searchResponse(result, "ITEM ALREADY IN TABLE", ref row, ref col);
                        if (row != 0 || col != 0)
                        {
                            MessageBox.Show("FIRMA CREADA CORRECTAMENTE, ERROR EN LA ASIGNACIÓN DE LA QUEUE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("FIRMA CREADA Y ASIGNACION A LA QUEUE CON EXITO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }


                        string username = string.Concat(txtInitial.Text, " ", txtLastName.Text);
                        string cc = string.Empty;
                        Parameter copy = ParameterBL.GetParameterValue("MailToCreateFirm");
                        cc = copy.Values;

                        AddNewUserBL.AddNewUser(username, username.ToLower(), txtEmail.Text.ToLower(), textAgentMail.Text.ToLower(), DateTime.Today.ToString().Substring(0, 10), txtNumberFirm.Text,
                                            txtPassCode.Text, txtName.Text.ToLower(), txtCodeAgent.Text, txtQueue.Text, txtPCC.Text, txtTA.Text, "SA");
                        SendEMail(cc);
                        if (!txtQueue.Text.Equals("152"))
                        {
                            DialogResult yesNo =
                                MessageBox.Show("Este usuario recibirá reporte de productividad semanal?",
                                                Resources.Constants.MYCTS, MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Information);
                            if (yesNo.Equals(DialogResult.Yes))
                            {
                                SetProductivityMailStatusBL setStatus = new SetProductivityMailStatusBL();
                                setStatus.SetProductivityMailStatus(txtNumberFirm.Text, txtPCC.Text);
                            }
                        }

                        UpdateStatusAllFirmModulesBL.UpdateStatusTA(txtTA.Text);
                        UpdateStatusAllFirmModulesBL.UpdateStatusQueue(txtQueue.Text);
                        UpdateStatusAllFirmModulesBL.UpdateStatusAgent(txtCodeAgent.Text);
                        UpdateStatusAllFirmModulesBL.UpdateStatusFirm(txtNumberFirm.Text);
                        MessageBox.Show("CUENTA DE MyCTS CREADA EXITOSAMENTE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        row = 0;
                        col = 0;
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                    }
                }
            }

                else if (rbnMyCTS.Checked)
                {
                    try
                    {
                        User usuarioDto = null;
                        User ValidAgentMail = null;

                        usuarioDto = UserBL.GetUser(txtNumberFirm.Text, txtPCC.Text);

                        ValidAgentMail = UserBL.ValidAgentMail(textAgentMail.Text);




                        if (usuarioDto == null)
                        {
                            if (ValidAgentMail == null)
                            {
                                string username = string.Concat(txtInitial.Text, " ", txtLastName.Text);
                                string cc = string.Empty;


                                Parameter copy = ParameterBL.GetParameterValue("MailToCreateFirm");
                                cc = copy.Values;



                                AddNewUserBL.AddNewUser(username, username.ToLower(), txtEmail.Text.ToLower(), textAgentMail.Text.ToLower(), DateTime.Today.ToString().Substring(0, 10), txtNumberFirm.Text,
                                                    txtPassCode.Text, txtName.Text.ToLower(), txtCodeAgent.Text, txtQueue.Text, txtPCC.Text, txtTA.Text, "SA");

                                SendEMail(cc);
                                if (!txtQueue.Text.Equals("152"))
                                {
                                    DialogResult yesNo =
                                        MessageBox.Show("Este usuario recibirá reporte de productividad semanal?",
                                                        Resources.Constants.MYCTS, MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Information);
                                    if (yesNo.Equals(DialogResult.Yes))
                                    {
                                        SetProductivityMailStatusBL setStatus = new SetProductivityMailStatusBL();
                                        setStatus.SetProductivityMailStatus(txtNumberFirm.Text, txtPCC.Text);
                                    }
                                }
                                UpdateStatusAllFirmModulesBL.UpdateStatusTA(txtTA.Text);
                                UpdateStatusAllFirmModulesBL.UpdateStatusQueue(txtQueue.Text);
                                UpdateStatusAllFirmModulesBL.UpdateStatusAgent(txtCodeAgent.Text);
                                UpdateStatusAllFirmModulesBL.UpdateStatusFirm(txtNumberFirm.Text);
                                MessageBox.Show("CUENTA DE MyCTS CREADA EXITOSAMENTE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);

                            }
                            else
                            {
                                MessageBox.Show("EL AGENTMAIL YA EXISTE EN MyCTS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else { MessageBox.Show("EL USUARIO YA EXISTE EN MyCTS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information); }

                    }
                    catch { }
                }


                else if (rbnSabre.Checked)
                {
                    try
                    {
                        string result = string.Empty;
                        string send = string.Empty;
                        string sabre = string.Empty;
                        string authorization = string.Empty;
                        string keywords = string.Empty;
                        string pass = string.Empty;
                        string codeagent = string.Empty;
                        body = string.Empty;
                        row = 0;
                        col = 0;

                        sendPCC = string.Concat(sendPCC, "AAA", txtPCC.Text);
                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            res = objCommand.SendReceive(sendPCC);
                        }
                        CommandsQik.searchResponse(res, txtPCC.Text, ref row, ref col);
                        if (row != 0 || col != 0)
                        {
                            conected = true;
                        }
                        else
                            MessageBox.Show("ERROR EN LA CONEXIÓN CON MySABRE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (conected)
                        {



                            if (!onlyagent)
                            {
                                send = string.Concat(send, "HB", txtNumberFirm.Text);
                                using (CommandsAPI objCommand = new CommandsAPI())
                                {
                                    result = objCommand.SendReceive(send);
                                }
                                CommandsQik.searchResponse(result, "NEW EMPLOYEE", ref row, ref col);
                                if (row != 0 || col != 0)
                                {
                                    row = 0;
                                    col = 0;
                                    send = string.Empty;
                                    send = string.Concat("H/NAM", txtLastName.Text, "/", txtInitial.Text);
                                    sabre = "H/DTY6*/";
                                    if (chkDutyCode.Checked)
                                        sabre = string.Concat(sabre, "9");
                                    authorization = string.Concat(authorization, "H/AUTH BY", txtAuthorization.Text);
                                    keywords = "H/UAT/A-24TIME,SUBAAA,PFKAGT,PTRAGT";
                                    if (chkMINIOPR.Checked)
                                        keywords = string.Concat(keywords, ",MINOPR");
                                    if (chkCreate.Checked)
                                        keywords = string.Concat(keywords, ",CREATE");
                                    if (chkAccess.Checked)
                                        keywords = string.Concat(keywords, ",ACCESS");
                                    if (chkCIIMGR.Checked)
                                        keywords = string.Concat(keywords, ",CIIMGR");
                                    if (chkSUBMGR.Checked)
                                        keywords = string.Concat(keywords, ",SUBMGR");
                                    if (chkPNRREL.Checked)
                                        keywords = string.Concat(keywords, ",PNRREL");
                                    if (chkSUBACC.Checked)
                                        keywords = string.Concat(keywords, ",SUBACC");
                                    if (cmbKeyWord8.SelectedIndex > 0)
                                        keywords = string.Concat(keywords, ",", cmbKeyWord8.Text);
                                    if (cmbKeyWord9.SelectedIndex > 0)
                                        keywords = string.Concat(keywords, ",", cmbKeyWord9.Text);
                                    if (cmbKeyWord10.SelectedIndex > 0)
                                        keywords = string.Concat(keywords, ",", cmbKeyWord10.Text);
                                    if (cmbKeyWord11.SelectedIndex > 0)
                                        keywords = string.Concat(keywords, ",", cmbKeyWord11.Text);
                                    if (cmbKeyWord12.SelectedIndex > 0)
                                        keywords = string.Concat(keywords, ",", cmbKeyWord12.Text);

                                    pass = string.Concat(pass, "H/PASS", txtPassCode.Text);
                                    codeagent = string.Concat(codeagent, "HH/A", txtCodeAgent.Text);
                                    using (CommandsAPI objCommand = new CommandsAPI())
                                    {
                                        objCommand.SendReceive(send);
                                        objCommand.SendReceive(sabre);
                                        objCommand.SendReceive("H/ASO240");
                                        objCommand.SendReceive(authorization);
                                        objCommand.SendReceive(keywords);
                                        objCommand.SendReceive(pass);
                                        result = objCommand.SendReceive(codeagent);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("LA FIRMA YA EXISTE, INGRESE AL MODULO DE MODIFICACIONES PARA CAMBIOS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    using (CommandsAPI objCommand = new CommandsAPI())
                                    {
                                        result = objCommand.SendReceive("I");
                                    }
                                    //CommandsQik.searchResponse(result, "IGN", ref row, ref col);
                                }
                            }
                            else
                            {
                                codeagent = string.Concat(codeagent, "HH/A", txtCodeAgent.Text);
                                using (CommandsAPI objCommand = new CommandsAPI())
                                {
                                    result = objCommand.SendReceive(codeagent);
                                }
                            }
                            CommandsQik.searchResponse(result, "DUP", ref row, ref col);
                            if (row != 0 || col != 0)
                            {
                                MessageBox.Show("EL CODIGO DE AGENTE YA EXISTE, INGRESE OTRO!", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtCodeAgent.Focus();
                                onlyagent = true;
                                row = 0;
                                col = 0;
                            }
                            CommandsQik.searchResponse(result, "DONE", ref row, ref col);
                            if (row != 0 || col != 0)
                            {
                                row = 0;
                                col = 0;
                                sabre = string.Empty;
                                sabre = string.Concat("QS/", txtPCC.Text, txtQueue.Text, "/A-", txtCodeAgent.Text);
                                using (CommandsAPI objCommand = new CommandsAPI())
                                {
                                    result = objCommand.SendReceive(sabre);
                                }
                                CommandsQik.searchResponse(result, "ITEM ALREADY IN TABLE", ref row, ref col);
                                if (row != 0 || col != 0)
                                {
                                    MessageBox.Show("FIRMA CREADA CORRECTAMENTE, ERROR EN LA ASIGNACIÓN DE LA QUEUE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("FIRMA CREADA Y ASIGNACION A LA QUEUE CON EXITO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                    catch { }
                }
            }

        //Crea y envía el correo de información de la firma creada
        private void SendEMail(string cc)
        {
            string body = string.Empty;
            body = string.Concat(body, "MyCTS le da la bienvenida, a continuación se anexan los datos de su firma:\n", "\n",
                          "Status: ALTA \n", "\n",
                          "Firma:  ", txtNumberFirm.Text, "\n",
                          "Agent:  ", txtCodeAgent.Text, "\n",
                          "Queue:  ", txtQueue.Text, "\n",
                          "PCC:    ", txtPCC.Text, "\n",
                          "TA:     ", txtTA.Text, "\n",
                          "Contraseña:    tmp1234 (Al ingresar por primera vez, se te solicitara asignar una nueva contraseña)\n",
                          "Nombre Sabre: ", txtInitial.Text, " ", txtLastName.Text, "\n",
                          "Usuario:      ", txtName.Text.ToLower(), "\n",
                          "Correo:       ", txtEmail.Text.ToLower(), "\n", "\n",
                          "   **La contraseña debe contener un mínimo de 7 caracteres y un máximo 8.", "\n",
                          "   Debe contener por lo menos 1 carácter alfabético y 1 numérico.", "\n",
                          "   No se permiten las letras Q ni Z.", "\n",
                          "   No se permiten usar las últimas 4 contraseñas de esta firma.", "\n",
                          "   No se permite repetir más de 3 caracteres Ej. AAAA", "\n",
                          "   No se permite usar nombres de ciudades Ej. DALLAS", "\n",
                          "   La contraseña se debe cambiar cada 90 días", "\n",
                          "   Después de 6 intentos la contraseña se bloqueará por 30 minutos.", "\n",
                          "Para cualquier problema con la firma llamar el área de Mesa de Servicio", "\n", "\n",
                          "Mesa de Servicio", "\n",
                          "Corporate Travel Services", "\n",
                          "Tel. 85252222 Ext. 9999");
            MailProvider ws = new MailProvider();
            ws.SendEmail2("mycts_admin@ctsmex.com.mx", "not", null,
            txtEmail.Text.ToLower(), cc, "MyCTS Informa - Creación de Firma", body);
        }
        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }

       

       
    }
}

