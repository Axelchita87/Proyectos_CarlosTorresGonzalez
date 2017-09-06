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
    public partial class ucChangeCode : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite cambiar el código del agente
        /// Creación:    07-Mayo-10 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        bool statusValidPCC;
        TextBox txt;

        public ucChangeCode()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtNumberFirm;
            this.LastControlFocus = btnAccept;
        }

        //Extrae el agente y lo coloca en el textbox y coloca el foco
        private void ucChangeCode_Load(object sender, EventArgs e)
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
            txtNumberFirm.Focus();
        }

        //Vefifica que exista el PCC y manda a llamar los metodos de validación y comandos
        private void btnAccept_Click(object sender, EventArgs e)
        {
            List<ListItem> CatPccsList = CatPccsBL.GetPccs(txtPCC.Text,Login.OrgId);
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

        #region ===== Methods =======

        //Cambio de foco de acuerdo a el lenght permitido
        private void txtNumberFirm_TextChanged(object sender, EventArgs e)
        {
            if (txtNumberFirm.Text.Length > 3)
                txtPCC.Focus();
        }

        private void txtAuthorization_TextChanged(object sender, EventArgs e)
        {
            if (txtAuthorization.Text.Length > 19)
                txtAgentCode.Focus();
        }

        private void txtAgentCode_TextChanged(object sender, EventArgs e)
        {
            if (txtAgentCode.Text.Length > 1)
                btnAccept.Focus();
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
                else if (string.IsNullOrEmpty(txtAgentCode.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_CÓDIGO_AGENTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAgentCode.Focus();
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
            bool notcontinue = false;

            string send = string.Concat("HB", txtNumberFirm.Text);
            sabre = string.Concat("H/AUTH BY ", txtAuthorization.Text);
            change = string.Concat("HH/A", txtAgentCode.Text);
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                result = objCommand.SendReceive(send);
            }
            CommandsQik.searchResponse(result, "NEW EMPLOYEE", ref row, ref col);
            if (row != 0 || col != 0)
            {
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive("I");
                }
                MessageBox.Show(Resources.Reservations.LA_FIRMA_NO_EXISTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                notcontinue = true;
            }

            if (!notcontinue)
            {

                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(sabre);
                    result = objCommand.SendReceive(change);
                }


                CommandsQik.searchResponse(result, "DUP", ref row, ref col);
                if (row != 0 || col != 0)
                {
                    row = 0;
                    col = 0;
                    MessageBox.Show(Resources.Reservations.INICIALES_YA_EXISTEN_INGRESE_OTRAS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                CommandsQik.searchResponse(result, "DONE", ref row, ref col);
                if (row != 0 || col != 0)
                {
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        objCommand.SendReceive("I");
                    }
                    CommandsAPI2.send_MessageToEmulator(string.Concat(Resources.Reservations.CODIGO_CAMBIADO_CON_EXITO));
                    UpdateUsersBL.UpdateUsers(txtNumberFirm.Text, txtPCC.Text, txtAgentCode.Text, null, null);
                    MessageBox.Show(Resources.Reservations.CAMBIO_CODIGO_AGENTE_EXITOSO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
            }
        }

        #endregion


        private void lblNumberFirm_Click(object sender, EventArgs e)
        {

        }

        private void lblPCC_Click(object sender, EventArgs e)
        {

        }

        private void lblAuthorization_Click(object sender, EventArgs e)
        {

        }
    }
}
