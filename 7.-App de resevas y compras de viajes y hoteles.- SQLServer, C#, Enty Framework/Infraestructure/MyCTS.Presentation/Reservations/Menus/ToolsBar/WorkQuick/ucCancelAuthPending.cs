using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucCancelAuthPending : CustomUserControl
    {
        public ucCancelAuthPending()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            InitialControlFocus = txtPNR;
            LastControlFocus = btnAccept;
        }

        private void ucCancelAuthPending_Load(object sender, EventArgs e)
        {

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (ValidBussinesRules)
            {
                AuthCode codeAuth = GetAuthCodeBL.GetAuthCode(txtPNR.Text);

                if (!string.IsNullOrEmpty(codeAuth.PNR))
                {
                    DialogResult result = MessageBox.Show("Desea CANCELAR éste código de autorización" + "\n\n CÖDIGO: " + codeAuth.Code + "\n TARJETA: " + codeAuth.CardType + "\n BANCO: " + codeAuth.Bank.ToUpper() + "\n MONTO: " + codeAuth.Amount + "\n FORMATO DE COTIZACIÓN: " + codeAuth.CommandWP,
                            Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (result.Equals(DialogResult.Yes))
                    {
                        UpdateAuthCodeBL.UpdateAuthCode(codeAuth.PNR, codeAuth.Code, string.Concat("CANCEL - AUTH - ", DateTime.Now.ToString()));
                        MessageBox.Show("La autorización se ha cancelado con éxito",
                            Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("La autorización no se ha cancelado",
                            Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró ninguna autorización pendiente",
                            Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                txtPNR.Text = string.Empty;
            }
        }

        private bool ValidBussinesRules
        {
            get
            {
                if (string.IsNullOrEmpty(txtPNR.Text))
                {
                    MessageBox.Show("Debes colocar el Record Localizador",
                                      Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if (txtPNR.Text.Length < 6)
                {
                    MessageBox.Show("El Record Localizador está incompleto",
                                      Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                    return true;
            }
        }

        private void txtPNR_TextChanged(object sender, EventArgs e)
        {
            if (txtPNR.Text.Length == 6)
            {
                btnAccept.Focus();
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
            
        }
    }
}
