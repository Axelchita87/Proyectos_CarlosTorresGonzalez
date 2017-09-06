using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucTicketsJustifications : CustomUserControl
    {
        private static string ticketsjustifications;
        public static string TicketsJustifications
        {
            get { return ticketsjustifications; }
            set { ticketsjustifications = value; }
        }
        private string Corporative;
        private string DKToSearch;
        private string send;
        private string optionSelected;

        public ucTicketsJustifications()
        {
            InitializeComponent();
        }

        //ucJustifications Load event
        private void ucTicketsJustifications_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            initialStatements();
        }

        //dgvJustifications_CellDoubleClick event
        private void dgvJustifications_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            justificationCodeSelected();
        }

        //dgvJustifications_KeyDown event
        private void dgvJustifications_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            if (e.KeyCode.Equals(Keys.Enter))
            {
                justificationCodeSelected();
            }
        }


        //Button Accept
        private void btnAccept_Click(object sender, EventArgs e)
        {
            justificationCodeSelected();
        }


        #region===== MethodsClass =====

        //Load DataSource with database values and dgvJustifications get focus
        public void initialStatements()
        {
            string labelCTS = string.Empty;
            if (activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_DANONE))
            {
                chkClass.Visible = true;
            }
            lblCTS.Text = string.Format("{0} {1}",
                Resources.TicketEmission.Constants.JUSTIFICATIONS_OF,
                activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1);
            if (activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.Substring(0, 3).Equals(Resources.TicketEmission.Constants.CTS))
            {
                labelCTS = ucFirstValidations.CorporativeQualityControls[0].Attribute1.Substring(0, 3);
                lblCTS.Text = string.Format("{0} {1}",
                    Resources.TicketEmission.Constants.JUSTIFICATIONS_OF,
                    labelCTS);
            }
                
                if (this.Parameters.Length == 1)
                {
                    Corporative = activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1;

                    DKToSearch = this.Parameters[0];
                    dgvJustifications.DataSource = DKTempBL.GetDKTemp(DKToSearch,false);
                    dgvJustifications.Focus();
                }
        }

        //Assign justification code and load ucAccountingInformation
        public void justificationCodeSelected()
        {
            int index = dgvJustifications.CurrentCell.RowIndex;
            DKTemp obj = dgvJustifications.Rows[index].DataBoundItem as DKTemp;
            optionSelected = obj.Code.ToString();
            if (!string.IsNullOrEmpty(Corporative))
            {
                if (Corporative.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_DANONE))
                {
                    lblCTS.Visible = false;
                    chkClass.Visible = true;
                    
                    send = Resources.TicketEmission.Constants.COMMANDS_5_S_AST_FJ + optionSelected;
                    if (chkClass.Checked)
                        send += Resources.TicketEmission.Constants.COMMANDS_ENDITEM_5_S_AST_TT_INDENT_B;
                    else
                        send += Resources.TicketEmission.Constants.COMMANDS_ENDITEM_5_S_AST_TT_INDENT_C;

                    //using (CommandsAPI objCommands = new CommandsAPI())
                    //{
                    //    objCommands.SendReceive(send);
                    //}

                    ticketsjustifications = send;
                }
                else if (Corporative.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_RADIUS))
                {
                    lblCTS.Visible = false;
                    send = Resources.TicketEmission.Constants.COMMANDS_5_U99_INDENT_RC_SLASH + optionSelected;

                    //using (CommandsAPI objCommands = new CommandsAPI())
                    //{
                    //    objCommands.SendReceive(send);
                    //}

                    ticketsjustifications = send;
                }
                else //if (Corporative.Substring(0,3).Equals(Resources.TicketEmission.Constants.CTS))
                {
                    lblCTS.Visible = true;
                    send = Resources.TicketEmission.Constants.COMMANDS_5_S_AST_FJ + optionSelected;
                    //using (CommandsAPI objCommands = new CommandsAPI())
                    //{
                    //    objCommands.SendReceive(send);
                    //}

                    ticketsjustifications = send;
                }
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_CHARGESERVICE);
            }
        }
        #endregion
    }
}
