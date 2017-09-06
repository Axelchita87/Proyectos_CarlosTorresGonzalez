using System;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Forms.UI;

namespace MyCTS.Presentation
{
    public partial class ucDisplayTaxesToFare : CustomUserControl
    {

        /// <summary>
        /// Descripción: User control que despliega los impuestos
        ///              de una tarifa
        /// Creación:    26 de Febrero 2010, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Angel Trejo Arizmendi
        /// </summary> 
        public ucDisplayTaxesToFare()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
             ControlStyles.UserPaint |
             ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtLine;
            this.LastControlFocus = btnAccept;
        }

        private void ucDisplayTaxesToFare_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtLine.Focus();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidBussinesRules)
                BuildCommand();
        }

        #region =====METHODS CLASS=====

        /// <summary>
        /// Valida las reglas de negocio aplicables a esta mascarilla
        /// </summary>
        private bool IsValidBussinesRules
        {
            get 
            {
                bool isValid = false;
                if (string.IsNullOrEmpty(txtLine.Text))
                {
                    MessageBox.Show("DEBE INGRESAR LA LÍNEA DE LA LISTA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLine.Focus();
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
            string send = string.Concat("FT", txtLine.Text);
            if (!string.IsNullOrEmpty(txtAirline.Text))
                send = string.Concat(send, "-", txtAirline.Text);
            string sabreAnswer = string.Empty;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }
            int row = 0;
            int col = 0;
            CommandsQik.searchResponse(sabreAnswer, "REPEAT FQ ENTRY", ref row, ref col);
            if (row > 0)
            {
                MessageBox.Show("RE-DESPLIEGA CONSULTA DE TARIFAS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            txt.Focus();

        }

        #endregion//End Change focus When a Textbox is Full
    }
}
