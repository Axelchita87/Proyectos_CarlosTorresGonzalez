using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Entities;
using MyCTS.Business;

namespace MyCTS.Presentation
{
    public partial class ucEnableDisable : CustomUserControl
    {
        string Keyword1 = string.Empty;
        string Keyword2 = string.Empty;
        string Keyword3 = string.Empty;
        string Keyword4 = string.Empty;
        string Keyword5 = string.Empty;

        public ucEnableDisable()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtNumberFirm;
            this.LastControlFocus = btnAccept;
        }

        private void ucEnableDisable_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            string agent = string.Empty;
            CatQueue item = CatQueueBL.GetQueue(Login.Firm, Login.PCC);
            if (!string.IsNullOrEmpty(item.Agent))
            {
                agent = item.Agent;
            }
            txtAuthorization.Text = agent;
            rdoAdd.Focus();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidateBusinessRules)
                CommandsSend();
        }

        //KeyDown
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

        #region ===== Keywords ======

        private void cmbKeyWord8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKeyWord8.SelectedIndex > 0)
                Keyword1 = cmbKeyWord8.Text.Substring(0, 6);
        }

        private void cmbKeyWord9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKeyWord9.SelectedIndex > 0)
                Keyword2 = cmbKeyWord9.Text.Substring(0, 6);
        }

        private void cmbKeyWord10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKeyWord10.SelectedIndex > 0)
                Keyword3 = cmbKeyWord10.Text.Substring(0, 6);
        }

        private void cmbKeyWord11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKeyWord11.SelectedIndex > 0)
                Keyword4 = cmbKeyWord11.Text.Substring(0, 6);
        }

        private void cmbKeyWord12_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKeyWord12.SelectedIndex > 0)
                Keyword5 = cmbKeyWord12.Text.Substring(0, 6);
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
                if (rdoAdd.Checked && rdoDelete.Checked)
                {
                    MessageBox.Show("REQUIERE ELEGIR ALGUNA OPCIÓN", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rdoAdd.Focus();
                }
                else if (string.IsNullOrEmpty(txtNumberFirm.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR NUMERO DE FIRMA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberFirm.Focus();
                }
                else if (string.IsNullOrEmpty(txtAuthorization.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR AUTORIZADO POR", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAuthorization.Focus();
                }
                else if (cmbKeyWord8.SelectedIndex < 1 &&
                         cmbKeyWord9.SelectedIndex < 1 &&
                         cmbKeyWord10.SelectedIndex < 1 &&
                         cmbKeyWord11.SelectedIndex < 1 &&
                         cmbKeyWord12.SelectedIndex < 1)
                {
                    MessageBox.Show("REQUIERE INGRESAR KEYWORD", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbKeyWord8.Focus();
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
            int flag = 0;
            bool notcontinue = false;
            string result = string.Empty;
            string sabre = string.Empty;
            string change = string.Empty;

            string send = string.Concat("HB", txtNumberFirm.Text);
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                result = objCommand.SendReceive(send);
            }
            CommandsQik.searchResponse(result, "NEW EMPLOYEE", ref row, ref col);
            if (row != 0 || col != 0)
            {
                row = 0;
                col = 0;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive("I");
                }
                MessageBox.Show(Resources.Reservations.LA_FIRMA_NO_EXISTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNumberFirm.Focus();
                notcontinue = true;
            }
            if (!notcontinue)
            {

                sabre = string.Concat("H/AUTH BY ", txtAuthorization.Text);
                if (rdoAdd.Checked)
                {
                    change = string.Concat("H/UAT/A-");
                }
                else
                {
                    change = string.Concat("H/UAT/D-");
                }

                if (!string.IsNullOrEmpty(Keyword1))
                {
                    change = string.Concat(change, Keyword1);
                    flag = 1;
                }
                if (!string.IsNullOrEmpty(Keyword2))
                {
                    if (flag == 1)
                    {
                        change = string.Concat(change, ",", Keyword2);
                    }
                    else
                    {
                        change = string.Concat(change, Keyword2);
                        flag = 1;
                    }
                }
                if (!string.IsNullOrEmpty(Keyword3))
                {
                    if (flag == 1)
                    {
                        change = string.Concat(change, ",", Keyword3);
                    }
                    else
                    {
                        change = string.Concat(change, Keyword3);
                        flag = 1;
                    }
                }
                if (!string.IsNullOrEmpty(Keyword4))
                {
                    if (flag == 1)
                    {
                        change = string.Concat(change, ",", Keyword4);
                    }
                    else
                    {
                        change = string.Concat(change, Keyword4);
                        flag = 1;
                    }
                }
                if (!string.IsNullOrEmpty(Keyword5))
                {
                    if (flag == 1)
                    {
                        change = string.Concat(change, ",", Keyword5);
                    }
                    else
                    {
                        change = string.Concat(change, Keyword5);
                        flag = 1;
                    }
                }

                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(sabre);
                    result = objCommand.SendReceive(change);
                }
                CommandsQik.searchResponse(result, "*", ref row, ref col);
                if (row != 0 || col != 0)
                {
                    row = 0;
                    col = 0;
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        result = objCommand.SendReceive("HE");
                                 objCommand.SendReceive("I");
                    }
                    CommandsQik.searchResponse(result, "DONE", ref row, ref col);
                    if (row != 0 || col != 0)
                    {
                        row = 0;
                        col = 0;
                        CommandsAPI2.send_MessageToEmulator(string.Concat(Resources.Reservations.KEYWORDS_MODIFICADOS_EXITO));
                        MessageBox.Show(Resources.Reservations.FIRMA_MODIFICADA_EXITO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(Resources.Reservations.PRESENTO_ERROR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            objCommand.SendReceive("I");
                        }
                    }
                }
                else
                {
                    MessageBox.Show(Resources.Reservations.PRESENTO_ERROR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        objCommand.SendReceive("I");
                    }
                }
            }
        }

        #endregion
    }
}
