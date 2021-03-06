using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucAccountingInformation : CustomUserControl
    {
        #region ======== Declaration of variables ========

        public string send;
        private string command;
        private string commandstandardrate;
        private string commandeconomyrate;
        private string result;
        private string standardrate;
        private string total;
        private string optionSelected;
        private bool economyrate;

        #endregion 

        public ucAccountingInformation()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus =txtCostCenter;
            this.LastControlFocus = btnAccept;
        }

        //User Control Load
        private void ucAccountingInformation_Load(object sender, EventArgs e)
        {
            txtCostCenter.Focus();
            if (this.Parameters != null)
                optionSelected = this.Parameters[0].ToString();
        }

        //Button Accept
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidateBusinessRules)
                CommandsSend();
        }

        //KeyDown
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {

           if (e.KeyData == Keys.Escape)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }

        #region ===== methodsClass =====

        private bool IsValidateBusinessRules
        {
            get
            {
                if (string.IsNullOrEmpty(txtCostCenter.Text))
                {
                    MessageBox.Show("REQUIERE INGRESES EL CENTRO DE COSTOS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCostCenter.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtEmployesNumber.Text))
                {
                    MessageBox.Show("REQUIERE INGRESES EL CENTRO DE COSTOS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCostCenter.Focus();
                    return false;
                }
                else
                    return true;
            }
        }

        private void CommandsSend()
        {
            command = Resources.Constants.COMMANDS_5U99_CC_SLASH +
                    txtCostCenter.Text + Resources.Constants.COMMANDS_END_IT_5U99_ID_SLASH + 
                    txtEmployesNumber.Text;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                result = objCommand.SendReceive(Resources.Constants.COMMANDS_WPOC_BY);
            }
            APIResponse();
            if (!string.IsNullOrEmpty(standardrate))
            {
                commandstandardrate = Resources.Constants.COMMANDS_5U99_HF_SLASH + standardrate;
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(Resources.Constants.COMMANDS_WPNCS_CROSSLORAINE_MMXN);
                   economyrate = true;
                }
                if (economyrate)
                {
                    commandeconomyrate = Resources.Constants.COMMANDS_5U99_LF_SLASH + standardrate;
                    send = command + Resources.Constants.END_ITEM + commandstandardrate + 
                        Resources.Constants.END_ITEM + commandeconomyrate + 
                        Resources.Constants.END_ITEM;
                    string[] sendInfo = new string[] { Resources.Reservations.MCAFEE, send, optionSelected };
                    Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCJUSTIFICATIONS,sendInfo);
                }
            }
        }

        #region ===== Commons =====

        private void APIResponse()
        {
            if ((!string.IsNullOrEmpty(result)))
            {
                ERR_AccountingInformation.err_accountinginformation(result);
                if (ERR_AccountingInformation.Status)
                {
                    total = ERR_AccountingInformation.Total;
                    total = total.Replace(Resources.TicketEmission.Constants.MXN, Resources.TicketEmission.Constants.SPACE);
                    total = total.Trim();
                    standardrate = total;
                }
            }
        }

        #endregion

       #endregion
    }
}
