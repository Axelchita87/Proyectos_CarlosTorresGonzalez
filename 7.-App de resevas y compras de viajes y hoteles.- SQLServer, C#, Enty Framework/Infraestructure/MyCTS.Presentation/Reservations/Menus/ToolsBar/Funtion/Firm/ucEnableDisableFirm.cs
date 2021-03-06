using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Entities;
using MyCTS.Business;

namespace MyCTS.Presentation
{
    public partial class ucEnableDisableFirm : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite habilitar y deshabilitar firma 
        /// Creaci�n:    10-Mayo-10 , Modificaci�n:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        bool statusValidPCC;
        TextBox txt;

        public ucEnableDisableFirm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = rdoEnable;
            this.LastControlFocus = btnAccept;
        }

        //Coloca el foco en el textbox de firma
        private void ucEnableDisableFirm_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            string agent = string.Empty;
            CatQueue item = CatQueueBL.GetQueue(Login.Firm, Login.PCC);
            if (!string.IsNullOrEmpty(item.Agent))
            {
                agent = item.Agent;
            }
            txtAuthorization.Text = agent;
            lbPCC.BringToFront();
            rdoEnable.Focus();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            List<ListItem> CatPccsList = CatPccsBL.GetPccs(txtPCC.Text, Login.OrgId);
            if (CatPccsList.Count.Equals(0))
                statusValidPCC = true;
            else
                statusValidPCC = false;
            if (IsValidateBusinessRules)
                CommandsSend();
        }

        //KeyDown
        /// <summary>
        /// Este se usa para todos los controles en general si se oprime 
        /// Esc se manda a el User control de Welcome 
        /// Enter se manda la accion de bot�n de Aceptar
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
        }

        //KeyDow ListBox
        private void lbPCC_KeyDown(object sender, KeyEventArgs e)
        {
            ListBox ListBox = (ListBox)sender;
            TextBox txt = (TextBox)txtPCC;

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
            TextBox txt = (TextBox)txtPCC;

            ListItem li = (ListItem)listBox.SelectedItem;
            txt.Text = li.Value;
            lbPCC.Visible = false;
            txt.Focus();
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
                else if (string.IsNullOrEmpty(txtAuthorization.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_AUTORIZADO_POR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAuthorization.Focus();
                }
                else if (string.IsNullOrEmpty(txtPasswordTemp.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_PASSCODE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPasswordTemp.Focus();
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
            string result = string.Empty;
            string sabre = string.Empty;
            string change = string.Empty;
            string name = string.Empty;

            string send = string.Concat("HB", txtNumberFirm.Text);
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                result = objCommand.SendReceive(send);
            }
            CommandsQik.searchResponse(result, "STATUS", ref row, ref col);
            if (row != 0 || col != 0)
            {
                row = 0;
                col = 0;
                send = string.Empty;
                sabre = string.Concat("H/PASS", txtPasswordTemp.Text);
                send = string.Concat("H/AUTH BY ", txtAuthorization.Text);

                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(sabre);
                    objCommand.SendReceive(send);
                }

                if (rdoEnable.Checked)
                {
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        result = objCommand.SendReceive("HX ACTIVE");
                    }
                    CommandsQik.searchResponse(result, Resources.Reservations.STATUS_ALREADY_ACTIVE, ref row, ref col);
                    if (row != 0 || col != 0)
                    {
                        MessageBox.Show(Resources.Reservations.FIRMA_YA_ESTABA_ACTIVA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            result = objCommand.SendReceive("I");
                        }
                    }
                    CommandsQik.searchResponse(result, "DONE", ref row, ref col);
                    if (row != 0 || col != 0)
                    {
                        MessageBox.Show(Resources.Reservations.FIRMA_HA_QUEDADO_ACTIVA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EnableDisableFirmBL.EnableDisableFirm(txtNumberFirm.Text+"_IN",txtPCC.Text, 1);
                    }
                }
                else if (rdoDisable.Checked)
                {
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        result = objCommand.SendReceive("HX INACTIVE");
                    }
                    CommandsQik.searchResponse(result, Resources.Reservations.STATUS_ALREADY_INACTIVE, ref row, ref col);
                    if (row != 0 || col != 0)
                    {
                        MessageBox.Show(Resources.Reservations.FIRMA_YA_ESTABA_INACTIVA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            result = objCommand.SendReceive("I");
                        }
                    }
                    CommandsQik.searchResponse(result, "DONE", ref row, ref col);
                    if (row != 0 || col != 0)
                    {
                        MessageBox.Show(Resources.Reservations.FIRMA_HA_QUEDADO_ACTIVA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EnableDisableFirmBL.EnableDisableFirm(txtNumberFirm.Text,txtPCC.Text, 2);
                    }
                }
            }
            else
            {
                MessageBox.Show(Resources.Reservations.LA_FIRMA_NO_EXISTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    result = objCommand.SendReceive("I");
                }
            }
        }

        #endregion
    }
}
