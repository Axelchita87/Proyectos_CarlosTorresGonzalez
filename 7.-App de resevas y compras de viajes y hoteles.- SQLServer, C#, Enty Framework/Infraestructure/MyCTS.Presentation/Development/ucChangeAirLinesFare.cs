using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucChangeAirLinesFare : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Cambia los datos de AirLinesFare en la BdD
        /// Creación:    10-06-10 , 
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez
        /// </summary>
        
        public ucChangeAirLinesFare()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = rdoSearch;
            this.LastControlFocus = btnAccept;
        }

        //Coloca el foco en el txtbox
        private void ucChangeAirLinesFare_Load(object sender, EventArgs e)
        {
            rdoSearch.Focus();
        }

        /// <summary>
        /// manda a llamar los metodos de validación y envio de comando
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (rdoSearch.Checked)
            {
                if (IsValidBussinessRules)
                    Command();
            }
            else
            {
                if (IsValidUpdate)
                    Command();
            }
        }

        /// <summary>
        /// Realizar la accion de acuerdo a lo que presionaron
        /// Si es Esc manda a llamar el user Control de Welcome
        /// Si es Enter manda a llamar el evento clic de boton Aceptar
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

        #region ======= ChangeFocus ======
        //Limpia los controles y Activa el control
        private void rdoSearch_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSearch.Checked)
            {
                ClearControls(string.Empty);
                Active(true);
            }
        }

        private void rdoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoUpdate.Checked)
                Active(false);
        }
        //Cambio de foco
        private void txtCodeAirline_TextChanged(object sender, EventArgs e)
        {
            if (txtCodeAirline.Text.Length > 1)
                txtAirlineName.Focus();
        }

        private void txtAirlineName_TextChanged(object sender, EventArgs e)
        {
            if (txtAirlineName.Text.Length > 49)
                cmbCCAut.Focus();
        }

        //Coloca el index del combo de acuerdo al texto ingresado
        private void cmbCCAut_TextChanged(object sender, EventArgs e)
        {
            if (cmbCCAut.Text.ToUpper() == "F")
                cmbCCAut.SelectedIndex = 2;
            else if (cmbCCAut.Text.ToUpper() == "T")
                cmbCCAut.SelectedIndex = 1;
        }

        private void cmbMan_TextChanged(object sender, EventArgs e)
        {
            if (cmbMan.Text.ToUpper() == "F")
                cmbMan.SelectedIndex = 2;
            else if (cmbMan.Text.ToUpper() == "T")
                cmbMan.SelectedIndex = 1;
        }

        private void cmbCash_TextChanged(object sender, EventArgs e)
        {
            if (cmbCash.Text.ToUpper() == "F")
                cmbCash.SelectedIndex = 2;
            else if (cmbCash.Text.ToUpper() == "T")
                cmbCash.SelectedIndex = 1;
        }

        private void cmbPMix_TextChanged(object sender, EventArgs e)
        {
            if (cmbPMix.Text.ToUpper() == "F")
                cmbPMix.SelectedIndex = 2;
            else if (cmbPMix.Text.ToUpper() == "T")
                cmbPMix.SelectedIndex = 1;
        }

        private void cmbMisce_TextChanged(object sender, EventArgs e)
        {
            if (cmbMisce.Text.ToUpper() == "F")
                cmbMisce.SelectedIndex = 2;
            else if (cmbMisce.Text.ToUpper() == "T")
                cmbMisce.SelectedIndex = 1;
        }

        #endregion

        #region ===== methodsClass =====

        //Valida los campos que son obligatorios
        private bool IsValidBussinessRules
        {
            get
            {
                bool isValid = false;
                if (string.IsNullOrEmpty(txtCodeAirline.Text)||
                     txtCodeAirline.Text.Length < 2)
                {
                    MessageBox.Show(Resources.Development.Development.REQUIERE_INGRESES_CÓDIGO_AEROLÍNEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCodeAirline.Focus();
                }
                else
                    isValid = true;

                return isValid;
            }
        }

        //Valida los campos que son obligatorios
        private bool IsValidUpdate
        {
            get
            {
                bool isValid = false;
                if (string.IsNullOrEmpty(txtCodeAirline.Text)||
                     txtCodeAirline.Text.Length<2)
                {
                    MessageBox.Show(Resources.Development.Development.REQUIERE_INGRESES_CÓDIGO_AEROLÍNEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCodeAirline.Focus();
                }
                else if (string.IsNullOrEmpty(txtAirlineName.Text))
                {
                    MessageBox.Show(Resources.Development.Development.REQUIERE_INGRESES_NOMBRE_AEROLÍNEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirlineName.Focus();
                }
                else if (string.IsNullOrEmpty(cmbCCAut.Text))
                {
                    MessageBox.Show(Resources.Development.Development.REQUIERE_INGRESES_REQUIERE_TARJETA_CRÉDIT_AUTOMATICA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbCCAut.Focus();
                }
                else if (string.IsNullOrEmpty(cmbMan.Text))
                {
                    MessageBox.Show(Resources.Development.Development.REQUIERE_INGRESES_REQUIERE_TARJETA_CRÉDITO_MANUAL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbMan.Focus();
                }
                else if (string.IsNullOrEmpty(cmbCash.Text))
                {
                    MessageBox.Show(Resources.Development.Development.REQUIERE_INGRESES_REQUIERE_EFECTIVO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbCash.Focus();
                }
                else if (string.IsNullOrEmpty(cmbPMix.Text))
                {
                    MessageBox.Show(Resources.Development.Development.REQUIERE_INGRESES_REQUIERE_PAGO_MIXTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbPMix.Focus();
                }
                else if (string.IsNullOrEmpty(cmbMisce.Text))
                {
                    MessageBox.Show(Resources.Development.Development.REQUIERE_INGRESES_REQUIERE_PAGO_MISCELANEO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbMisce.Focus();
                }
                else
                    isValid = true;

                return isValid;
            }
        }

        /// <summary>
        /// Busca los datos para ser modificados y manda a  
        /// llamar el metodo de limpiar los controles
        /// </summary>
        private void Command()
        {
            if (rdoSearch.Checked)
            {
                List<AirLineFare> list = AirLineFareBL.GetAirLineFare(txtCodeAirline.Text);
                if (list.Count > 0)
                {
                    txtCodeAirline.Text = list[0].CatAirLinFarId;
                    txtAirlineName.Text = list[0].CatAirLinFarName;
                    cmbCCAut.Text = list[0].CCAut.ToString();
                    cmbMan.Text = list[0].CCMan.ToString();
                    cmbCash.Text = list[0].Cash.ToString();
                    cmbPMix.Text = list[0].PMix.ToString();
                    cmbMisce.Text = list[0].Misc.ToString();
                }
                else
                {
                    ClearControls(string.Empty);
                    txtCodeAirline.Focus();
                }
            }
            else if (rdoUpdate.Checked)
            {
                UpdateAirLineFareBL.UpdateAirLinesFare(txtCodeAirline.Text, txtAirlineName.Text,
                   Convert.ToBoolean(cmbCCAut.Text), Convert.ToBoolean(cmbMan.Text),
                   Convert.ToBoolean(cmbCash.Text), Convert.ToBoolean(cmbPMix.Text),
                   Convert.ToBoolean(cmbMisce.Text));
                MessageBox.Show("LA AEROLÍNEA SE HA MODIFICADO CORRECTAMENTE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearControls(string.Empty);
                txtCodeAirline.Focus();
            }
        }

        //Limpia los controles 
        private void ClearControls(string Empty)
        {
            txtCodeAirline.Text = Empty;
            txtAirlineName.Text = Empty;
            cmbCCAut.Text = Empty;
            cmbMan.Text = Empty;
            cmbCash.Text = Empty;
            cmbPMix.Text = Empty;
            cmbMisce.Text = Empty;
        }

        //Activa o desactiva la escritura en el textbox
        private void Active(bool show)
        {
            txtCodeAirline.Enabled = show;
        }

        #endregion
    }
}
