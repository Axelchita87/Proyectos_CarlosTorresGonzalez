using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyCTS.Presentation.Components
{
    public partial class frmManualCommands : Form
    {
        public frmManualCommands()
        {
            InitializeComponent();
        }

        private void frmManualCommands_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCommand_Click(object sender, EventArgs e)
        {
            SendCommand();
        }

        private void SendCommand()
        {
            string command = txtCommand.Text;
            string result = string.Empty;

            if (string.IsNullOrEmpty(command))
                return;

            using (CommandsAPI commandsApi = new CommandsAPI())
            {
                result = commandsApi.SendReceive(command);
            }

            txtCommand.SelectAll();
        }

        private void txtCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SendCommand();
        }
    }
}