using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Business;

namespace MyCTS.Presentation.Components
{
    public partial class DialogBoxTickets : Form
    {
        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtSolicitorName;
        private string send = string.Empty;
        private string result = string.Empty;

        public DialogBoxTickets()
        {
            InitializeComponent();
        }

        private void DialogBoxTickets_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSolicitorName.Text))
            {
                MessageBox.Show("POR FAVOR INGRESE EL NOMBRE DEL SOLICITANTE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CommandsSend();
            DIN();

            this.FormClosing -= new FormClosingEventHandler(DialogBoxTickets_FormClosing);
            this.Close();
        }

        private void DialogBoxTickets_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        #region Private Variables
       
        #endregion

        #region Public Properties
       
        #endregion

        private void CommandsSend()
        {
            string agent = string.Empty;


            CatQueue item = CatQueueBL.GetQueue(Login.Firm, Login.PCC);
            if (!string.IsNullOrEmpty(item.Agent))
            {
                agent = item.Agent;
            }

            send = string.Concat(Resources.Constants.COMMANDS_6_NAME,
                 txtSolicitorName.Text.ToUpper() + Resources.Constants.SLASH + agent);
            using (CommandsAPI objCommands = new CommandsAPI())
            {
                objCommands.SendReceive(send);
            }
        }

        private void DIN()
        {
            send = Resources.Constants.COMMANDS_DIN;
            using (CommandsAPI objCommands = new CommandsAPI())
            {
                result = objCommands.SendReceive(send);
            }
            APIResponse();

            ucCancelTicket.CancelTicket = false;
        }

        /// <summary>
        /// Busca errores en la clase de ERR__BoletageDateAndReceived de acuerdo a las respuestas recibidas por el 
        /// Emulador de Sabre y de acuerdo a ellas se realizan ciertas acciones ya sea
        /// mandar un mensaje de error al usuario notificando del mismo o mandando a otro 
        /// User Control
        /// </summary>
        private void APIResponse()
        {
            if ((!string.IsNullOrEmpty(result)))
            {
                ERR__BoletageDateAndReceived.err_boletagedataandreceived(result);
                if (ERR__BoletageDateAndReceived.BoletageReceived)
                {
                    DIN();
                }
            }
        }
    }
}