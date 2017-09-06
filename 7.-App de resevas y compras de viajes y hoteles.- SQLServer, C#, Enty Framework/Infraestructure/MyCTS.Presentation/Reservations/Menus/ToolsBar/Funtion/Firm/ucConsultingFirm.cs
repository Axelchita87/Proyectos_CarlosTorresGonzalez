using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Entities;
using MyCTS.Business;
using System.Threading;

namespace MyCTS.Presentation
{
    public partial class ucConsultingFirm : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite consultar firma en Sabre y en MyCTS
        /// Creación:    29-Abril-10 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez 
        /// </summary>
        
        int i = 0;
        string agent;
        string familyName;
        string firm;
        string myCTSVersion;
        string password;
        string pCC;
        string queue;
        string tA;
        string SF;
        string statusF;
        string userMail;
        string agentMail;
        string userName;
        string isMySabreBlocked;

        public ucConsultingFirm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            InitialControlFocus = txtFirmNumber;
            LastControlFocus = btnAccept;
        }
        //Carga el user Control y coloca el foco en el txtFirmNumber
        private void ucConsultingFirm_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtFirmNumber.Focus();
        }

        //Llama los metdos de validación y envio de comando
        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.tabControl1.TabPages.Clear();
            if (IsValidBussinessRules)
                SendCommand();
        }

        
        /// <summary>
        /// Este se usa para todos los controles en general si se oprime 
        /// Esc se manda a el User control de Welcome
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

        #region ====== Events =======

        private void rdoBoth_CheckedChanged(object sender, EventArgs e)
        {
            ShowControls(false);
        }

        private void rdoSabre_CheckedChanged(object sender, EventArgs e)
        {
            ShowControls(false);
        }

        private void rdoMyCTS_CheckedChanged(object sender, EventArgs e)
        {
            ShowControls(false);
        }

        private void txtFirmNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtFirmNumber.Text.Length > 3)
                rdoBoth.Focus();
        }

        #endregion

        #region ======= Methods ========
        //Valida que los campos obligatorios no esten vacios
        private bool IsValidBussinessRules
        {
            get
            {
                bool isVaid = false;
                if (string.IsNullOrEmpty(txtFirmNumber.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_NUMERO_FIRMA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFirmNumber.Focus();
                }
                else if (!rdoBoth.Checked && !rdoMyCTS.Checked && !rdoSabre.Checked)
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_ELEGIR_ALGUNA_OPCIONES, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rdoBoth.Focus();
                }
                else
                {
                    isVaid= true;
                }
                return isVaid;
            }
        }

        //Manda comando o muestra los datos deacuerdo a la opción elegida
        private void SendCommand()
        {
            string send=string.Empty;
            send = string.Concat(send, "H*", txtFirmNumber.Text);

            if (rdoBoth.Checked || rdoSabre.Checked)
            {
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(send);
                }
            }
            if (rdoBoth.Checked || rdoMyCTS.Checked)
            {
                List<ConsultingFirm> firmList = ConsultingFirmBL.GetConsultingFirm(txtFirmNumber.Text);
                if (firmList.Count > 0)
                {
                    foreach (ConsultingFirm list in firmList)
                    {
                        agent = firmList[i].Agent;
                        familyName = firmList[i].FamilyName;
                        firm = firmList[i].Firm;
                        isMySabreBlocked = firmList[i].IsMySabreBlocked.ToString();
                        myCTSVersion = firmList[i].MyCTSVersion;
                        password = firmList[i].Password;
                        pCC = firmList[i].PCC;
                        queue = firmList[i].Queue;
                        tA = firmList[0].TA;
                        userMail = firmList[i].UserMail;
                        agentMail = firmList[i].AgentMail;
                        userName = firmList[i].UserName;
                        SF = firmList[i].StatusFirm;
                        AddControlsInTabPages();
                        ShowControls(true);
                        i++;
                    }
                    i = 0;
                }
            }
        }

        //Ocualta o muestra los controles
        private void ShowControls(bool show)
        {
            tabControl1.Visible = show;
        }
        
        ///Agregar CheckBox1 en tabPage1 y button1 en TabPage2
        private void AddControlsInTabPages()
        {
            //System.Windows.Forms.TabControl tabControl1 = new System.Windows.Forms.TabControl();
            string title = "Firma " + (tabControl1.TabCount+1).ToString();
            TabPage myTabPage = new TabPage(title);
            tabControl1.TabPages.Add(myTabPage);
            myTabPage.BackColor = System.Drawing.Color.White;
            // 
            // lblDataName
            // 
            System.Windows.Forms.Label lblDataName = new System.Windows.Forms.Label();
            lblDataName.AutoSize = true;
            lblDataName.Location = new System.Drawing.Point(60, 5);
            lblDataName.Name = "lblDataName";
            lblDataName.Size = new System.Drawing.Size(91, 13);
            lblDataName.TabIndex = 136;
            lblDataName.Text = "Nombre del Campo";
            lblDataName.Visible = true;
            myTabPage.Controls.Add(lblDataName);
            // 
            // lblShowName
            // 
            System.Windows.Forms.Label lblShowName = new System.Windows.Forms.Label();
            lblShowName.AutoSize = true;
            lblShowName.Location = new System.Drawing.Point(180, 5);
            lblShowName.Name = "lblShowName";
            lblShowName.Size = new System.Drawing.Size(91, 13);
            lblShowName.TabIndex = 137;
            lblShowName.Text = "Nombre a Mostrar";
            lblShowName.Visible = true;
            myTabPage.Controls.Add(lblShowName);
            // 
            // lblLine
            // 
            System.Windows.Forms.Label lblLine = new System.Windows.Forms.Label();
            lblLine.AutoSize = true;
            lblLine.Location = new System.Drawing.Point(60, 15);
            lblLine.Name = "lblLine";
            lblLine.Size = new System.Drawing.Size(100, 13);
            lblLine.TabIndex = 138;
            lblLine.Text = "-------------------------------";
            lblLine.Visible = true;
            myTabPage.Controls.Add(lblLine);
            // 
            // lblLine2
            // 
            System.Windows.Forms.Label lblLine2 = new System.Windows.Forms.Label();
            lblLine2.AutoSize = true;
            lblLine2.Location = new System.Drawing.Point(180, 15);
            lblLine2.Name = "lblLine2";
            lblLine2.Size = new System.Drawing.Size(100, 13);
            lblLine2.TabIndex = 139;
            lblLine2.Text = "-----------------------------";
            lblLine2.Visible = true;
            myTabPage.Controls.Add(lblLine2);
            // 
            // lblFirm
            // 
            System.Windows.Forms.Label lblFirm = new System.Windows.Forms.Label();
            lblFirm.AutoSize = true;
            lblFirm.Location = new System.Drawing.Point(60, 30);
            lblFirm.Name = "lblFirm";
            lblFirm.Size = new System.Drawing.Size(26, 13);
            lblFirm.TabIndex = 141;
            lblFirm.Text = "Firm";
            lblFirm.Visible = true;
            myTabPage.Controls.Add(lblFirm);
            // 
            // lblF
            // 
            System.Windows.Forms.Label lblF = new System.Windows.Forms.Label();
            lblF.AutoSize = true;
            lblF.Location = new System.Drawing.Point(180, 30);
            lblF.Name = "lblF";
            lblF.Size = new System.Drawing.Size(26, 13);
            lblF.TabIndex = 140;
            lblF.Text = firm;
            lblF.Visible = true;
            myTabPage.Controls.Add(lblF);
            // 
            // lblPassword
            // 
            System.Windows.Forms.Label lblPassword = new System.Windows.Forms.Label();
            lblPassword.AutoSize = true;
            lblPassword.Location = new System.Drawing.Point(60, 45);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new System.Drawing.Size(53, 13);
            lblPassword.TabIndex = 143;
            lblPassword.Text = "Password";
            lblPassword.Visible = true;
            myTabPage.Controls.Add(lblPassword);
            // 
            // lblP
            // 
            System.Windows.Forms.Label lblP = new System.Windows.Forms.Label();
            lblP.AutoSize = true;
            lblP.Location = new System.Drawing.Point(180, 45);
            lblP.Name = "lblP";
            lblP.Size = new System.Drawing.Size(53, 13);
            lblP.TabIndex = 142;
            lblP.Text = password;
            lblP.Visible = true;
            myTabPage.Controls.Add(lblP);
            // 
            // lblFamilyName
            // 
            System.Windows.Forms.Label lblFamilyName = new System.Windows.Forms.Label();
            lblFamilyName.AutoSize = true;
            lblFamilyName.Location = new System.Drawing.Point(60, 60);
            lblFamilyName.Name = "lblFamilyName";
            lblFamilyName.Size = new System.Drawing.Size(64, 13);
            lblFamilyName.TabIndex = 145;
            lblFamilyName.Text = "FamilyName";
            lblFamilyName.Visible = true;
            myTabPage.Controls.Add(lblFamilyName);
            // 
            // lblFN
            // 
            System.Windows.Forms.Label lblFN = new System.Windows.Forms.Label();
            lblFN.AutoSize = true;
            lblFN.Location = new System.Drawing.Point(180, 60);
            lblFN.Name = "lblFN";
            lblFN.Size = new System.Drawing.Size(64, 13);
            lblFN.TabIndex = 144;
            lblFN.Text = familyName;
            lblFN.Visible = true;
            myTabPage.Controls.Add(lblFN);
            // 
            // lblUserName
            // 
            System.Windows.Forms.Label lblUserName = new System.Windows.Forms.Label();
            lblUserName.AutoSize = true;
            lblUserName.Location = new System.Drawing.Point(60, 75);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new System.Drawing.Size(57, 13);
            lblUserName.TabIndex = 147;
            lblUserName.Text = "UserName";
            lblUserName.Visible = true;
            myTabPage.Controls.Add(lblUserName);
            // 
            // lblUN
            // 
            System.Windows.Forms.Label lblUN = new System.Windows.Forms.Label();
            lblUN.AutoSize = true;
            lblUN.Location = new System.Drawing.Point(180, 75);
            lblUN.Name = "lblUN";
            lblUN.Size = new System.Drawing.Size(57, 13);
            lblUN.TabIndex = 146;
            lblUN.Text = userName;
            lblUN.Visible = true;
            myTabPage.Controls.Add(lblUN);
            // 
            // lblUserMail
            // 
            System.Windows.Forms.Label lblUserMail = new System.Windows.Forms.Label();
            lblUserMail.AutoSize = true;
            lblUserMail.Location = new System.Drawing.Point(60, 90);
            lblUserMail.Name = "lblUserMail";
            lblUserMail.Size = new System.Drawing.Size(48, 13);
            lblUserMail.TabIndex = 149;
            lblUserMail.Text = "UserMail";
            lblUserMail.Visible = true;
            myTabPage.Controls.Add(lblUserMail);
            // 
            // lblUM
            // 
            System.Windows.Forms.Label lblUM = new System.Windows.Forms.Label();
            lblUM.AutoSize = true;
            lblUM.Location = new System.Drawing.Point(180, 90);
            lblUM.Name = "lblUM";
            lblUM.Size = new System.Drawing.Size(48, 13);
            lblUM.TabIndex = 148;
            lblUM.Text = userMail;
            lblUM.Visible = true;
            myTabPage.Controls.Add(lblUM);
            //
            //lblAgentMail
            //
            System.Windows.Forms.Label lblAgentMail = new System.Windows.Forms.Label();
            lblAgentMail.AutoSize = true;
            lblAgentMail.Location = new System.Drawing.Point(60, 105);
            lblAgentMail.Name = "lblAgentMail";
            lblAgentMail.Size = new System.Drawing.Size(48, 13);
            lblAgentMail.TabIndex = 151;
            lblAgentMail.Text = "AgentMail";
            lblAgentMail.Visible = true;
            myTabPage.Controls.Add(lblAgentMail);
            // 
            // lblAM
            // 
            System.Windows.Forms.Label lblAM = new System.Windows.Forms.Label();
            lblAM.AutoSize = true;
            lblAM.Location = new System.Drawing.Point(180, 105);
            lblAM.Name = "lblAM";
            lblAM.Size = new System.Drawing.Size(48, 13);
            lblAM.TabIndex = 150;
            lblAM.Text = agentMail;
            lblAM.Visible = true;
            myTabPage.Controls.Add(lblAM);
            // 
            // lblAgent
            // 
            System.Windows.Forms.Label lblAgent = new System.Windows.Forms.Label();
            lblAgent.AutoSize = true;
            lblAgent.Location = new System.Drawing.Point(60, 120);
            lblAgent.Name = "lblAgent";
            lblAgent.Size = new System.Drawing.Size(35, 13);
            lblAgent.TabIndex = 153;
            lblAgent.Text = "Agent";
            lblAgent.Visible = true;
            myTabPage.Controls.Add(lblAgent);
            // 
            // lblA
            // 
            System.Windows.Forms.Label lblA = new System.Windows.Forms.Label();
            lblA.AutoSize = true;
            lblA.Location = new System.Drawing.Point(180, 120);
            lblA.Name = "lblA";
            lblA.Size = new System.Drawing.Size(35, 13);
            lblA.TabIndex = 152;
            lblA.Text = agent;
            lblA.Visible = true;
            myTabPage.Controls.Add(lblA);
            // 
            // lblQueue
            // 
            System.Windows.Forms.Label lblQueue = new System.Windows.Forms.Label();
            lblQueue.AutoSize = true;
            lblQueue.Location = new System.Drawing.Point(60, 135);
            lblQueue.Name = "lblQueue";
            lblQueue.Size = new System.Drawing.Size(39, 13);
            lblQueue.TabIndex = 155;
            lblQueue.Text = "Queue";
            lblQueue.Visible = true;
            myTabPage.Controls.Add(lblQueue);
            // 
            // lblQ
            // 
            System.Windows.Forms.Label lblQ = new System.Windows.Forms.Label();
            lblQ.AutoSize = true;
            lblQ.Location = new System.Drawing.Point(180, 135);
            lblQ.Name = "lblQ";
            lblQ.Size = new System.Drawing.Size(39, 13);
            lblQ.TabIndex = 154;
            lblQ.Text = queue;
            lblQ.Visible = true;
            myTabPage.Controls.Add(lblQ);
            // 
            // lblPCC
            // 
            System.Windows.Forms.Label lblPCC = new System.Windows.Forms.Label();
            lblPCC.AutoSize = true;
            lblPCC.Location = new System.Drawing.Point(60, 150);
            lblPCC.Name = "lblPCC";
            lblPCC.Size = new System.Drawing.Size(28, 13);
            lblPCC.TabIndex = 157;
            lblPCC.Text = "PCC";
            lblPCC.Visible = true;
            myTabPage.Controls.Add(lblPCC);
            // 
            // lblPC
            // 
            System.Windows.Forms.Label lblPC = new System.Windows.Forms.Label();
            lblPC.AutoSize = true;
            lblPC.Location = new System.Drawing.Point(180, 150);
            lblPC.Name = "lblPC";
            lblPC.Size = new System.Drawing.Size(28, 13);
            lblPC.TabIndex = 156;
            lblPC.Text = pCC;
            lblPC.Visible = true;
            myTabPage.Controls.Add(lblPC);
            // 
            // lblTA
            // 
            System.Windows.Forms.Label lblTA = new System.Windows.Forms.Label();
            lblTA.AutoSize = true;
            lblTA.Location = new System.Drawing.Point(60, 165);
            lblTA.Name = "lblTA";
            lblTA.Size = new System.Drawing.Size(21, 13);
            lblTA.TabIndex = 159;
            lblTA.Text = "TA";
            lblTA.Visible = true;
            myTabPage.Controls.Add(lblTA);
            // 
            // lblT
            // 
            System.Windows.Forms.Label lblT = new System.Windows.Forms.Label();
            lblT.AutoSize = true;
            lblT.Location = new System.Drawing.Point(180, 165);
            lblT.Name = "lblT";
            lblT.Size = new System.Drawing.Size(21, 13);
            lblT.TabIndex = 158;
            lblT.Text = tA;
            lblT.Visible = true;
            myTabPage.Controls.Add(lblT);


            // 
            // lblStatusFirm
            // 
            System.Windows.Forms.Label lblStatusFirm = new System.Windows.Forms.Label();
            lblStatusFirm.AutoSize = true;
            lblStatusFirm.Location = new System.Drawing.Point(60, 180);
            lblStatusFirm.Name = "lblStatusFirm";
            lblStatusFirm.Size = new System.Drawing.Size(21, 13);
            lblStatusFirm.TabIndex = 161;
            lblStatusFirm.Text = "StatusFirm";
            lblStatusFirm.Visible = true;
            myTabPage.Controls.Add(lblStatusFirm);
            //// 
            //// lblSF
            //// 

            if (SF == "A")
            {
                statusF = "Active";
            }
            else 
            {
                statusF = "Inactive";
            }
            System.Windows.Forms.Label lblSF = new System.Windows.Forms.Label();
            lblSF.AutoSize = true;
            lblSF.Location = new System.Drawing.Point(180, 180);
            lblSF.Name = "lblSF";
            lblSF.Size = new System.Drawing.Size(21, 13);
            lblSF.TabIndex = 160;
            lblSF.Text = statusF;
            lblSF.Visible = true;
            myTabPage.Controls.Add(lblSF);

            // 
            // lblMyCTSVersion
            // 
            System.Windows.Forms.Label lblMyCTSVersion = new System.Windows.Forms.Label();
            lblMyCTSVersion.AutoSize = true;
            lblMyCTSVersion.Location = new System.Drawing.Point(60, 195);
            lblMyCTSVersion.Name = "lblMyCTSVersion";
            lblMyCTSVersion.Size = new System.Drawing.Size(77, 13);
            lblMyCTSVersion.TabIndex = 163;
            lblMyCTSVersion.Text = "MyCTSVersion";
            lblMyCTSVersion.Visible = true;
            myTabPage.Controls.Add(lblMyCTSVersion);
            // 
            // lblV
            // 
            System.Windows.Forms.Label lblV = new System.Windows.Forms.Label();
            lblV.AutoSize = true;
            lblV.Location = new System.Drawing.Point(180, 195);
            lblV.Name = "lblV";
            lblV.Size = new System.Drawing.Size(77, 13);
            lblV.TabIndex = 162;
            lblV.Text = myCTSVersion;
            lblV.Visible = true;
            myTabPage.Controls.Add(lblV);
            //
            // lblIsMySabreBlocked
            // 
            System.Windows.Forms.Label lblIsMySabreBlocked = new System.Windows.Forms.Label();
            lblIsMySabreBlocked.AutoSize = true;
            lblIsMySabreBlocked.Location = new System.Drawing.Point(60, 210);
            lblIsMySabreBlocked.Name = "lblIsMySabreBlocked";
            lblIsMySabreBlocked.Size = new System.Drawing.Size(96, 13);
            lblIsMySabreBlocked.TabIndex = 1;
            lblIsMySabreBlocked.Text = "IsMySabreBlocked";
            lblIsMySabreBlocked.Visible = true;
            myTabPage.Controls.Add(lblIsMySabreBlocked);
            // 
            // lblS
            // 
            System.Windows.Forms.Label lblS = new System.Windows.Forms.Label();
            lblS.AutoSize = true;
            lblS.Location = new System.Drawing.Point(180, 210);
            lblS.Name = "lblS";
            lblS.Size = new System.Drawing.Size(96, 13);
            lblS.TabIndex = 164;
            lblS.Text = isMySabreBlocked;
            lblS.Visible = true;
            myTabPage.Controls.Add(lblS);

            


            
        }

        #endregion

    }
}
