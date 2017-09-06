using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.DataAccess;
using MyCTS.Entities;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucConsultingFirmRole : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Extrae los Roles por Firma
        /// Creación:    19-Noviembre-2010 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Ivan Martínez
        /// </summary>        

        //Inicia componentes, crea el control del foco.
        public ucConsultingFirmRole()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtFirm;
            this.LastControlFocus = btnAccept;
        }

        #region ====Declarations====
        User UserExist;
        private bool statusValidPCC;
        private TextBox txt;
        #endregion


        //Coloca el foco en el textbox
        private void ucConsultingFirmRole_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtFirm.Focus();
            lbPCC.BringToFront();
            lbPCC.Visible = false;
        }

        #region ====== Events ====



        //Cambia el foco 
        private void txtFirm_TextChanged(object sender, EventArgs e)
        {
            if (txtFirm.Text.Length > 4)
                txtPCC.Focus();
        }

        //Genera el campo predictivo
        private void txtPCC_TextChanged(object sender, EventArgs e)
        {
            txt = (TextBox)sender;
            Common.SetListBoxPCCs(txt, lbPCC);
        }


        //Valida la Firma y el PCC
        private void btnAccept_Click(object sender, EventArgs e)
        {
            List<ListItem> CatPccsList = CatPccsBL.GetPccs(txtPCC.Text, Login.OrgId);
            if (CatPccsList.Count.Equals(0))
                statusValidPCC = true;
            else
                statusValidPCC = false;

            if (IsValidBussinessRules)
            {
                ShowControls(true);
                Commands();
            }
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

        //Despliega opciones y elige opción con la tecla Enter     
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

        //Selecciona la opción de la Lista con el click del mouse
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

        #region======MethodsClass======

        //Verifica si los datos obligatorios fueron ingresados
        private bool IsValidBussinessRules
        {
            get
            {
                UserExist = UserBL.GetUser(txtFirm.Text, txtPCC.Text);
                bool isValid = false;
                if (string.IsNullOrEmpty(txtFirm.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR FIRMA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFirm.Focus();
                }
                else if (string.IsNullOrEmpty(txtPCC.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR PCC", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPCC.Focus();
                }
                else if (UserExist == null)
                {
                    MessageBox.Show("EL USUARIO NO EXISTE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowControls(false);
                    txtFirm.Text = string.Empty;
                    txtPCC.Text = string.Empty;
                    txtFirm.Focus();
                }

                else
                    isValid = true;

                return isValid;
            }
        }

        //Extrae los datos de la BdD
        private void Commands()
        {
            List<ConsultingFirmRole> list = ConsultingFirmRoleBL.GetConsultingFirmRole(txtFirm.Text, txtPCC.Text);
            if (list.Count > 0)
            {
                dataGridView1.DataSource = list;
                ShowControls(true);
                txtFirm.Focus();
            }
            else
            {
                MessageBox.Show("NO SE ENCONTRARON COINCIDENCIAS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFirm.Focus();
                ShowControls(false);
                txtFirm.Focus();
            }
        }


        //Muestra u Oculta los controles      
        private void ShowControls(bool show)
        {
            dataGridView1.Visible = show;
        }


        #endregion

    }
}

