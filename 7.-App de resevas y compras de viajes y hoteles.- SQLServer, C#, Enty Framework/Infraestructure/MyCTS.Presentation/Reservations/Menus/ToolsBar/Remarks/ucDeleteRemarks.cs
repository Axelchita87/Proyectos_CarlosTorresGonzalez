using System;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Forms.UI;

namespace MyCTS.Presentation
{
    public partial class ucDeleteRemarks : CustomUserControl
    {
        /// <summary>
        /// Descripción: User control que elimina los remarks 
        /// Creación:    25 de Enere 2010, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Angel Trejo Arizmendi
        /// </summary>
        public ucDeleteRemarks()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtLine1;
            this.LastControlFocus = btnAccept;
        }

        private void ucDeleteRemarks_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtLine1.Focus();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidBussinesRules)
                BuildCommand();
        }

        #region ====== METHODS CLASS ======

        /// <summary>
        /// Bussines rules aplicadas a este user control
        /// </summary>
        private bool IsValidBussinesRules
        {
            get 
            {
                bool isValid = false;
                if (string.IsNullOrEmpty(txtLine1.Text))
                {
                    MessageBox.Show("DEBE INGRESAR LA PRIMER LÍNEA A BORRAR", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLine1.Focus();
                }
                else
                    isValid = true;
                return isValid;
            }
        }

        /// <summary>
        /// Armado del comando que se envia a Sabre
        /// </summary>
        private void BuildCommand()
        {
            string send = string.Empty;
            if (!string.IsNullOrEmpty(txtRange.Text))
                send = string.Concat(txtLine1.Text, "-", txtRange.Text);
            else
                send = txtLine1.Text;
            if (!string.IsNullOrEmpty(txtLine2.Text))
                send = string.Concat(send, "/", txtLine2.Text);
            if (!string.IsNullOrEmpty(txtLine3.Text))
                send = string.Concat(send, "/", txtLine3.Text);
            if (!string.IsNullOrEmpty(txtLine4.Text))
                send = string.Concat(send, "/", txtLine4.Text);
            using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(string.Concat("5", send, "¤"));
                }
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);

        }

        #endregion

        #region =====Back to a Previous Usercontrol or Validate Enter KeyDown=====

        /// <summary>
        /// Aborta el proceso al presionar la tecla ESC
        /// o ejecutar las funciones al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            if (e.KeyData.Equals(Keys.Enter))
                btnAccept_Click(sender, e);
        }

        #endregion

        #region=====Change focus When a Textbox is Full=====

        //Evento txtControls_TextChanged
        private void txtControls_TextChanged(object sender, EventArgs e)
        {
            if (sender is SmartTextBox)
                if (((SmartTextBox)sender).Text.Length > ((SmartTextBox)sender).MaxLength - 1)
                    foreach (Control txt in this.Controls)
                        if (txt.TabIndex.Equals(((SmartTextBox)(sender)).TabIndex + 1))
                        {
                            txt.Focus();
                            break;
                        }
        }

        #endregion
    }
}
