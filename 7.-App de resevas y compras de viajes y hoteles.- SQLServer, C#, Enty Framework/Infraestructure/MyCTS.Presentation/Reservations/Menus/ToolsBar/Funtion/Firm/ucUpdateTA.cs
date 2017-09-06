using System;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucUpdateTA : CustomUserControl
    {
        public ucUpdateTA()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            InitialControlFocus = txtTA;
            LastControlFocus = btnAccept;
            txtTA.Focus();
        }

        /// <summary>
        /// Handles the TextChanged event of the txtTA control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event<see cref="System.EventArgs"/> instance containing the event data.</param>
        private void txtTA_TextChanged(object sender, EventArgs e)
        {
            if (txtTA.Text.Length ==6)
            {
                TA ta = GetAllFirmModulesBL.GetTA(txtTA.Text);

                if (!string.IsNullOrEmpty(ta.Code))
                {
                    txtTA.Text = ta.Code;
                    cmbType.Text = ta.Type;
                    txtPCC.Text = ta.Pcc;
                    cmbType.Focus();
                }
                else
                {
                    MessageBox.Show("El número de TA no existe, debe ser dado de alta", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTA.Text = string.Empty;
                    cmbType.Text = string.Empty;
                    txtPCC.Text = string.Empty;
                    cmbType.Focus();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnAccept control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event<see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if(ValidateBussinessRules)
            {
                if (UpdateAllFirmModulesBL.UpdateTA(txtTA.Text, cmbType.Text, txtPCC.Text))
                {
                    MessageBox.Show("Los datos de la TA han sido actualizados", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTA.Text = string.Empty;
                    cmbType.Text = string.Empty;
                    txtPCC.Text = string.Empty;
                    txtTA.Focus();
                }
                else
                {
                    MessageBox.Show("Hubo un error al actualizar, reportarlo a sistemas", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                if (string.IsNullOrEmpty(txtPCC.Text) || string.IsNullOrEmpty(cmbType.Text))
                {
                    isValid = false;

                    if (string.IsNullOrEmpty(txtPCC.Text))
                    {
                        MessageBox.Show("Ingrese el PCC", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPCC.Focus();
                    }
                    if (string.IsNullOrEmpty(cmbType.Text))
                    {
                        MessageBox.Show("Ingrese el Tipo de TA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbType.Focus();
                    }
                }

                if (txtTA.Text.Length < 6)
                {
                    MessageBox.Show("El número TA debe tener 6 números", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void txtPCC_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            Common.SetListBoxPCCs(txt, lbPCC);
        }

        #endregion

        

    }
}
