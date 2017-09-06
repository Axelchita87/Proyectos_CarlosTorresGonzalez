using System;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucInsertIATA : CustomUserControl
    {
        public ucInsertIATA()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            InitialControlFocus = txtIATA;
            LastControlFocus = btnAccept;
            txtIATA.Focus();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidBussinesRules)
            {
                if (SetAllFirmModulesBL.SetIATA(txtIATA.Text, txtOffice.Text, txtPCC.Text))
                {
                    MessageBox.Show("Los datos se han insertado correctamente", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtOffice.Text = string.Empty;
                    txtPCC.Text = string.Empty;
                    txtIATA.Text = string.Empty;
                    txtIATA.Focus();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        //KeyDown
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);

            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }


        //KeyDownListBox
        private void BackEnterUserControlListBox_KeyDown(object sender, KeyEventArgs e)
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
            TextBox txt = txtPCC;

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
            TextBox txt = txtPCC;

            ListItem li = (ListItem)listBox.SelectedItem;
            txt.Text = li.Value;
            lbPCC.Visible = false;
            txt.Focus();
        }

        /// <summary>
        /// Gets a value indicating whether this instance is valid bussines rules.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is valid bussines rules; otherwise, <c>false</c>.
        /// </value>
        public bool IsValidBussinesRules
        {
            get
            {
                bool isValid = true;

                if (string.IsNullOrEmpty(txtIATA.Text) || string.IsNullOrEmpty(txtOffice.Text) || string.IsNullOrEmpty(txtPCC.Text))
                {
                    MessageBox.Show("Requiere ingresar todos los datos", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isValid = false;
                    if (string.IsNullOrEmpty(txtIATA.Text))
                        txtIATA.Focus();
                    if (string.IsNullOrEmpty(txtOffice.Text))
                        txtOffice.Focus();
                    if (string.IsNullOrEmpty(txtPCC.Text))
                        txtPCC.Focus();
                }
                else
                {
                    IATA iata = GetAllFirmModulesBL.GetIATA(txtIATA.Text);
                    if (!string.IsNullOrEmpty(iata.Code))
                    {
                        MessageBox.Show("La TA ya existe en la base de datos", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        isValid = false;
                    }
                }

                if (txtIATA.Text.Length < 9)
                {
                    MessageBox.Show("El número IATA debe tener 9 números", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isValid = false;
                }
                return isValid;
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the txtPCC control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void txtPCC_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            Common.SetListBoxPCCs(txt, lbPCC);
        }
    }
}
