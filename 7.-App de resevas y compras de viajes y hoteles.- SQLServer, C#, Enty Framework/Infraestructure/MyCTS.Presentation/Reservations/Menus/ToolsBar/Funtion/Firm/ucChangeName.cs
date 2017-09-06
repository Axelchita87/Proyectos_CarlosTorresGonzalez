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
    public partial class ucChangeName : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite crear firma en Sabre y en MyCTS
        /// Creación:    10-Mayo-10 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        bool statusValidPCC;
        TextBox txt;

        public ucChangeName()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtNumberFirm;
            this.LastControlFocus = btnAccept;
        }
        //Extrae el UserName y lo coloca en autorización y coloca el foco en el txt
        private void ucChangeName_Load(object sender, EventArgs e)
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
        //Verifica que el PCC sea valido y manda a llamar los metodos de Validación y envió de Comando
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

        #region ===== Change Focus ======

        private void txtNumberFirm_TextChanged(object sender, EventArgs e)
        {
            if (txtNumberFirm.Text.Length > 3)
                txtPCC.Focus();
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            if (txtLastName.Text.Length > 11)
                txtInitial.Focus();
        }

        private void txtInitial_TextChanged(object sender, EventArgs e)
        {
            if (txtInitial.Text.Length > 0)
                txtAuthorization.Focus();
        }

        private void txtAuthorization_TextChanged(object sender, EventArgs e)
        {
            if (txtAuthorization.Text.Length > 19)
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
                    MessageBox.Show("REQUIERE INGRESAR NUMERO DE FIRMA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                else if (string.IsNullOrEmpty(txtLastName.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR APELLIDO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLastName.Focus();
                }
                else if (string.IsNullOrEmpty(txtInitial.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR INICIAL", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtInitial.Focus();
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
            CommandsQik.searchResponse(result, "NOT ALLOWED IN", ref row, ref col);
            if (row != 0 || col != 0)
            {
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive("I");
                    result = objCommand.SendReceive(send);
                }
                CommandsQik.searchResponse(result, "NEW EMPLOYEE", ref row, ref col);
                if (row != 0 || col != 0)
                {
                    MessageBox.Show(Resources.Reservations.LA_FIRMA_NO_EXISTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            CommandsQik.searchResponse(result, "NEW EMPLOYEE", ref row, ref col);
            if (row != 0 || col != 0)
            {
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive("I");
                }
                MessageBox.Show(Resources.Reservations.LA_FIRMA_NO_EXISTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                row = 0;
                col = 0;
                send = string.Empty;
                send = string.Concat("H/AUTH BY ", txtAuthorization.Text);
                sabre = string.Concat("H/NAM@", txtLastName.Text, "/", txtInitial.Text);
                change = string.Concat("HE");

                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(send);
                    objCommand.SendReceive(sabre);
                    objCommand.SendReceive(change);
                    objCommand.SendReceive("I");
                }
                CommandsAPI2.send_MessageToEmulator(string.Concat(Resources.Reservations.CAMBIO_NOMBRE_SABRE_EXITOSO));
                name = string.Concat(txtInitial.Text, " ", txtLastName.Text);
                UpdateUsersBL.UpdateUsers(txtNumberFirm.Text, txtPCC.Text, null, name, name.ToLower());
                MessageBox.Show(Resources.Reservations.CAMBIO_NOMBRE_EXITOSO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
        }

        #endregion

        
    }
}
