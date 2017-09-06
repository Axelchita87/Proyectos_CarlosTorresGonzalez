using System;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Forms.UI;

namespace MyCTS.Presentation
{
    public partial class ucDisplayHistoricRules : CustomUserControl
    {

        /// <summary>
        /// Descripción: User control que despliega la regla historicas
        ///              de tarifas
        /// Creación:    25 de Febrero 2010, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Angel Trejo Arizmendi
        /// </summary>  
        public ucDisplayHistoricRules()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
             ControlStyles.UserPaint |
             ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtOrigin;
            this.LastControlFocus = btnAccept;
        }

        private void ucDisplayHistoricRules_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtOrigin.Focus();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (isValidBussinesRules)
                BuildCommand();
        }

        #region =====METHODS CLASS=====

        /// <summary>
        /// Validación de la reglas de negocio aplicables para esta
        /// mascarilla
        /// </summary>
        private bool isValidBussinesRules
        {
            get 
            {
                bool isValid = false;
                if (string.IsNullOrEmpty(txtOrigin.Text))
                {
                    MessageBox.Show("DEBE INGRESAR EL ORIGEN", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtOrigin.Focus();
                }
                else if (string.IsNullOrEmpty(txtDestino.Text))
                {
                    MessageBox.Show("DEBE INGRESAR EL DESTINO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDestino.Focus();
                }
                else if (string.IsNullOrEmpty(txtDateBoletage.Text))
                {
                    MessageBox.Show("DEBE INGRESAR LA FECHA DE BOLETAJE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDateBoletage.Focus();
                }
                else if (!string.IsNullOrEmpty(txtDateBoletage.Text) && !ValidateRegularExpression.ValidateBirthDateFormat(txtDateBoletage.Text))
                {
                    MessageBox.Show("EL FORMATO DE FECHA DE BOLETAJE NO ES VALIDO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDateBoletage.Focus();
                }
                else if (string.IsNullOrEmpty(txtDateDeparture.Text))
                {
                    MessageBox.Show("DEBE INGRESAR LA FECHA DE SALIDA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDateDeparture.Focus();
                }
                else if (!string.IsNullOrEmpty(txtDateDeparture.Text) && !ValidateRegularExpression.ValidateBirthDateFormat(txtDateDeparture.Text))
                {
                    MessageBox.Show("EL FORMATO DE FECHA DE SALIDA NO ES VALIDO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDateDeparture.Focus();
                }
                else if (string.IsNullOrEmpty(txtAirline.Text))
                {
                    MessageBox.Show("DEBE INGRESAR EL CÓDIGO DE AEROLÍNEA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirline.Focus();
                }
                else if (string.IsNullOrEmpty(txtFareBasis.Text))
                {
                    MessageBox.Show("DEBE INGRESAR EL FARE BASIS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFareBasis.Focus();
                }
                else
                    isValid = true;
                return isValid;
            }
        }

        /// <summary>
        /// Armado del comando que se envia a sabre
        /// </summary>
        private void BuildCommand()
        {
            string send = string.Concat("RD", txtDateBoletage.Text, txtOrigin.Text, txtDestino.Text,
                txtDateDeparture.Text, txtFareBasis.Text, "-", txtAirline.Text);
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
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
                        {
                            txt.Focus();
                            break;
                        }

        }

        #endregion//End Change focus When a Textbox is Full

      
               
    }
}
