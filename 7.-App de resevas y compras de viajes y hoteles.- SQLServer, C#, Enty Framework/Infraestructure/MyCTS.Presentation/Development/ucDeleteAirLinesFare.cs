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
    public partial class ucDeleteAirLinesFare : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Elimina los datos de AirLineFare en la BdD
        /// Creación:    10-06-10 , 
        /// Cambio:      *   , Solicito *
        /// Autor:       Jessica Gutierrez
        /// </summary>
        
        public ucDeleteAirLinesFare()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = rdoSearch;
            this.LastControlFocus = btnAccept;
        }

        //Coloca el foco en el txtbox
        private void ucDeleteAirLinesFare_Load(object sender, EventArgs e)
        {
            rdoSearch.Focus();
        }

        //Llama los metodos de validación y envio de comando
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidBussinessRules)
                Command();
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

        //Llama el metodo de limpiar controles
        private void rdoSearch_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSearch.Checked)
                ClearControls(string.Empty);
        }

        //Coloca el foco de acuerdon a las las reglas 
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

        //Coloca el index del combo deacuerdo a lo escrito
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

        /// <summary>
        /// Busca los datos para ser eliminados y manda a  
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
            else if (rdoDelete.Checked)
            {
                DeleteAirLinesFareBL.DeleteAirLinesFare(txtCodeAirline.Text);
                MessageBox.Show("AEROLÍNEA ELIMINADA CORRECTAMENTE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearControls(string.Empty);
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

        #endregion
    }
}
