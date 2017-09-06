using System;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Forms.UI;

namespace MyCTS.Presentation
{
    public partial class ucLineRate : CustomUserControl
    {
        /// <summary>
        /// Descripción: User control que despliega la regla de tarifa
        ///              por línea
        /// Creación:    25 de Febrero 2010, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Angel Trejo Arizmendi
        /// </summary>  
        public ucLineRate()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtLineRate;
            this.LastControlFocus = btnAccept;
        }

        private void ucLineRate_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            if (this.Parameters[0] == "2")
                lblTitle.Text = "Desplegar Reglas por Categorías";
            txtLineRate.Focus();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidBussinesRules)
                BuildCommand();
        }

        #region =====METHODS CLASS=====

        /// <summary>
        /// Valida reglas de negocio aplicables a esta mascarilla
        /// </summary>
        private bool IsValidBussinesRules
        {
            get 
            {
                bool isValid = false;
                if (string.IsNullOrEmpty(txtLineRate.Text))
                {
                    MessageBox.Show("DEBE INGRESAR LA LÍNEA DE LA TARIFA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLineRate.Focus();
                }
                else
                    isValid = true;
                return isValid;
            }
        }

        /// <summary>
        /// Envio del comando a sabre
        /// </summary>
        private void BuildCommand()
        {
            string send = string.Concat("RD", txtLineRate.Text);
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
            if (this.Parameters[0] == "2")
                Loader.AddToPanel(Loader.Zone.Middle, this, "ucDisplayRulesByCategories");
            else
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }
        #endregion //METHODS CLASS

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

        #endregion //Back to a Previous Usercontrol or Validate Enter KeyDown

        #region=====Change focus When a Textbox is Full=====

        //Evento txtControls_TextChanged
        private void txtControls_TextChanged(object sender, EventArgs e)
        {
            if (sender is SmartTextBox)
                if (((SmartTextBox)sender).Text.Length > ((SmartTextBox)sender).MaxLength - 1)
                    foreach (Control txt in this.Controls)
                        if (txt.TabIndex.Equals(((SmartTextBox)(sender)).TabIndex + 1))
                            txt.Focus();

        }

        #endregion//End Change focus When a Textbox is Full
    }
}
