using System;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucUpdateIATA : CustomUserControl
    {
        public ucUpdateIATA()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            InitialControlFocus = txtIATA;
            LastControlFocus = btnAccept;
            txtIATA.Focus();
        }


        /// <summary>
        /// Handles the Click event of the btnAccept control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (ValidateBussinessRules)
            {
                if (UpdateAllFirmModulesBL.UpdateIATA(txtIATA.Text, txtOffice.Text, txtPCC.Text))
                {
                    MessageBox.Show("Los datos de la IATA han sido actualizados", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIATA.Text=string.Empty;
                    txtOffice.Text=string.Empty;
                    txtPCC.Text = string.Empty;
                    txtIATA.Enabled = true;
                    txtIATA.Focus();
                }
                else
                {
                    MessageBox.Show("Hubo un error al actualizar, reportarlo a sistemas", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIATA.Text = string.Empty;
                    txtOffice.Text = string.Empty;
                    txtPCC.Text = string.Empty;
                    txtIATA.Enabled = true;
                    txtIATA.Focus();
                }
            }
        }


        /// <summary>
        /// Gets a value indicating whether [validate bussiness rules].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [validate bussiness rules]; otherwise, <c>false</c>.
        /// </value>
        public bool ValidateBussinessRules
        {
            get
            {
                bool isValid = true;

                if (string.IsNullOrEmpty(txtPCC.Text) || string.IsNullOrEmpty(txtOffice.Text))
                {
                    isValid = false;

                    if (string.IsNullOrEmpty(txtPCC.Text))
                    {
                        MessageBox.Show("Ingrese el PCC", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPCC.Focus();
                    }
                    if (string.IsNullOrEmpty(txtOffice.Text))
                    {
                        MessageBox.Show("Ingrese la oficina de la IATA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtOffice.Focus();
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

        #region ==== Events ====


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

        private void txtIATA_TextChanged(object sender, EventArgs e)
        {
            if (txtIATA.Text.Length == 9)
            {
                IATA iata = GetAllFirmModulesBL.GetIATA(txtIATA.Text);

                if (!string.IsNullOrEmpty(iata.Code))
                {
                    txtIATA.Text = iata.Code;
                    txtIATA.Enabled = true;
                    txtOffice.Text = iata.Office;
                    txtPCC.Text = iata.Pcc;
                    txtOffice.Focus();
                }
                else
                {
                    MessageBox.Show("El número de IATA no existe, debe ser dado de alta", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIATA.Text = string.Empty;
                    txtOffice.Text = string.Empty;
                    txtPCC.Text = string.Empty;
                    txtIATA.Enabled = true;
                    txtIATA.Focus();
                }
            }
        }

        private void txtPCC_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            Common.SetListBoxPCCs(txt, lbPCC);
        }


        #endregion

        
    }
}
