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
    public partial class ucChangeFirmMyCTS : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite crear firma en Sabre y en MyCTS
        /// Creación:    19-Mayo-10 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        private TextBox txt;
        private bool statusValidPCC = false;

        public ucChangeFirmMyCTS()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = rdoSearch;
            this.LastControlFocus = btnAccept;
        }

        //Coloca el foco en el radio button y manda el listbox hacia el frente
        private void ucChangeFirmMyCTS_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            rdoSearch.Focus();
            lbPCC.BringToFront();
        }

       //Verifica el PCC y realiza las acciones de acuerdo a las peticiones
        private void btnAccept_Click(object sender, EventArgs e)
        {
            List<ListItem> CatPccsList = CatPccsBL.GetPccs(txtPCC.Text,Login.OrgId);
            if (CatPccsList.Count.Equals(0))
                statusValidPCC = true;
            else
                statusValidPCC = false;
            if (rdoSearch.Checked)
            {
                if (isValidateBussinessRules)
                {
                    List<UserSelectByPCC> list = UserSelectByPCCBL.GetUsersSelectByPCC(txtNumberFirm.Text, txtPCC.Text);
                    if (list.Count > 0)
                    {
                        txtUserId.Text = list[0].UserId;
                        txtCodeAgent.Text = list[0].Agent;
                        txtEmail.Text = list[0].UserMail;
                        txtQueue.Text = list[0].Queue;
                        txtTA.Text = list[0].TA;
                        txtName.Text = list[0].FamilyName;
                        txtLastName.Text = list[0].UserName;
                    }
                }
            }
            else
            {
                if (isValidateModify)
                {
                    UpdateUserBL.UpdateUser(txtNumberFirm.Text, txtPCC.Text,
                     txtCodeAgent.Text, txtLastName.Text, txtLastName.Text.ToLower(), txtUserId.Text,
                     txtEmail.Text.ToLower(), txtTA.Text, txtQueue.Text);
                    MessageBox.Show(Resources.Reservations.DATOS_FUERON_CAMBIADO_CORRECTAMENTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                    //   MessageBox.Show("OCURRIO UN ERROR, VERIFIQUE LOS DATOS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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

        #region ====== ChangeFocus =======

        private void txtNumberFirm_TextChanged(object sender, EventArgs e)
        {
            if (txtNumberFirm.Text.Length > 3)
                txtPCC.Focus();
        }

        private void txtUserId_TextChanged(object sender, EventArgs e)
        {
            if (txtUserId.Text.Length > 39)
                txtQueue.Focus();
        }

        private void txtQueue_TextChanged(object sender, EventArgs e)
        {
            if (txtQueue.Text.Length > 2)
                txtCodeAgent.Focus();
        }

        private void txtCodeAgent_TextChanged(object sender, EventArgs e)
        {
            if (txtCodeAgent.Text.Length > 1)
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
                btnAccept.Focus();
        }

        #endregion

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

        private void rdoChange_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisable(false);  
        }

        private void rdoSearch_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisable(true);
        }

 
        #endregion

        #region ======= Methods ========

        private bool isValidateBussinessRules
        {
            get
            {
                bool isValid = false;

                if (string.IsNullOrEmpty(txtNumberFirm.Text) &&
                    string.IsNullOrEmpty(txtPCC.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_NÚMERO_FIRMA_PCC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberFirm.Focus();
                }
                else if (string.IsNullOrEmpty(txtNumberFirm.Text))
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

                else
                {
                    isValid = true;
                }
                return isValid;
            }
        }

        private bool isValidateModify
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
                else if (string.IsNullOrEmpty(txtUserId.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_ID_USUARIO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUserId.Focus();
                }
                else if (string.IsNullOrEmpty(txtQueue.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_QUEUE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQueue.Focus();
                }
                else if (string.IsNullOrEmpty(txtCodeAgent.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_CÓDIGO_AGENTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCodeAgent.Focus();
                }
                else if (string.IsNullOrEmpty(txtTA.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_TA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTA.Focus();
                }
                else if (string.IsNullOrEmpty(txtLastName.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_USER_NAME, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLastName.Focus();
                }
                else if (string.IsNullOrEmpty(txtName.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_FAMILY_NAME, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Focus();
                }
                else if (string.IsNullOrEmpty(txtEmail.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_EMAIL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmail.Focus();
                }
                else
                {
                    isValid = true;
                }
                return isValid;
            }
        }

        private void EnableDisable(bool show)
        {
            txtNumberFirm.Enabled = show;
            txtUserId.Enabled = show;
        }
        
        #endregion

    }
}
