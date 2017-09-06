using System;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //Obtener datos del usuario
            User usuarioDto = null;
            if (!string.IsNullOrEmpty(Login.Firm))
            {
                usuarioDto = ValidaUsuario(usuarioDto, Login.Firm, Login.PCC);
            }
            else
            {
                if (string.IsNullOrEmpty(txtUserId.Text))
                {
                    MessageBox.Show("INGRESA TU NÚMERO DE FIRMA", "MyCTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUserId.Focus();
                }
                else if (string.IsNullOrEmpty(txtSabrePass.Text))
                {
                    MessageBox.Show("INGRESA TU PASSWORD", "MyCTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSabrePass.Focus();
                }
                else if (string.IsNullOrEmpty(txtPCC.Text))
                {
                    MessageBox.Show("INGRESA EL PCC", "MyCTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPCC.Focus();
                }
                else
                {
                    usuarioDto = ValidaUsuario(usuarioDto, txtUserId.Text, txtPCC.Text);
                }
            }
        }

        private User ValidaUsuario(User usuarioDto, String sUsuario, String Pcc)
        {
                usuarioDto = UserBL.GetUser(sUsuario, Pcc);

            
            if (usuarioDto == null || usuarioDto.StatusFirm.Contains("I"))
            {
                
                MessageBox.Show("El usuario no existe  o es inactivo en MyCTS, por favor verifiquelo con el administrador del sistema.", "MyCTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnStart.Focus();
            }
            else
            {
                this.Visible = false;
                //*********Carga el contexto del Log************
                Common.LogApplicationItem.UserName = usuarioDto.UserName;
                Common.LogApplicationItem.Firm = usuarioDto.Firm;
                Splash s = new Splash(usuarioDto, txtSabrePass.Text);
                s.Show();
            }
            return usuarioDto;
        }

        public void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        #region ===== Validate Enter KeyDown =====
        private void enterControls_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnStart_Click(sender, e);
            }

        }
        #endregion

        private void frmLogin_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "Versión: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + " - Julio, 2010";
            //Cambio Version Sabre Red
            if (!string.IsNullOrEmpty(Login.Firm))
            {
                this.Visible = false;
                btnStart_Click(new object(), null);
            }
        }

        void LinkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            this.Dispose();
        }


    }
}


