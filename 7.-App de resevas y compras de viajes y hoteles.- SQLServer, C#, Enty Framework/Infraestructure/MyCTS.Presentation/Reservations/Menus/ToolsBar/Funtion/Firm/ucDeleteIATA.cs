using System;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucDeleteIATA : CustomUserControl
    {
        public ucDeleteIATA()
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
            if (ValidateBussinessRules)
            {
                if (DeleteAllFirmModulesBL.DeleteIATA(txtIATA.Text))
                {
                    MessageBox.Show("El número de IATA ha sido eliminado", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIATA.Text = string.Empty;
                    txtIATA.Focus();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error favor de reportarlo a sistemas", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                if (txtIATA.Text.Length < 9)
                {
                    MessageBox.Show("El número IATA debe tener 9 números", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isValid = false;
                }
                else
                {
                    IATA iata = GetAllFirmModulesBL.GetIATA(txtIATA.Text);

                    if (!string.IsNullOrEmpty(iata.Code))
                    {
                        txtIATA.Text = iata.Code;
                    }
                    else
                    {
                        MessageBox.Show("El número de TA no existe, debe ser dado de alta", Resources.Constants.MYCTS,
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        isValid = false;
                    }
                }
                return isValid;
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

       
    }
}
