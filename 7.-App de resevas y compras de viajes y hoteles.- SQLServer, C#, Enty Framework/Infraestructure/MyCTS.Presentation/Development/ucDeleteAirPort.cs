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
    public partial class ucDeleteAirPort : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Elimina los datos de AirPort en la BdD
        /// Creación:    10-06-10 , 
        /// Cambio:      *   , Solicito *
        /// Autor:       Jessica Gutierrez
        /// </summary>
        
        public ucDeleteAirPort()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = rdoSearch;
            this.LastControlFocus = btnAccept;
        }

        //Coloca el foco en el txtbox
        private void ucDeleteAirPort_Load(object sender, EventArgs e)
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

        #region ======= Change Focus =======
        //Llama el metodo de limpiar controles
        private void rdoSearch_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoSearch.Checked)
            ClearControls(string.Empty);
        }

        //Coloca el foco de acuerdon a las las reglas 
        private void txtCodeAirport_TextChanged(object sender, EventArgs e)
        {
            if (txtCodeAirport.Text.Length > 2)
                txtNameAirport.Focus();
        }

        private void txtNameAirport_TextChanged(object sender, EventArgs e)
        {
            if (txtNameAirport.Text.Length > 49)
                txtCountryAirport.Focus();
        }

        private void txtCountryAirport_TextChanged(object sender, EventArgs e)
        {
            if (txtCountryAirport.Text.Length > 1)
                txtCountryName.Focus();
        }

        private void txtCountryName_TextChanged(object sender, EventArgs e)
        {
            if(txtCountryName.Text.Length>49)
                btnAccept.Focus();
        }

        #endregion

        #region ===== methodsClass =====

        //Valida los campos que son obligatorios
        private bool IsValidBussinessRules
        {
            get
            {
                bool isValid = false;
                if (string.IsNullOrEmpty(txtCodeAirport.Text)||
                    txtCodeAirport.Text.Length<3)
                {
                    MessageBox.Show(Resources.Development.Development.REQUIERE_INGRESES_CÓDIGO_AEROPUERTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCodeAirport.Focus();
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
                List<AirPort> list = AirPortBL.GetAirPort(txtCodeAirport.Text);
                if (list.Count > 0)
                {
                    txtCodeAirport.Text = list[0].CatCitId;
                    txtNameAirport.Text = list[0].CatCitName;
                    txtCountryAirport.Text = list[0].CatCouId;
                    txtCountryName.Text = list[0].CatCouName;
                }
                else
                {
                    ClearControls(string.Empty);
                    txtCodeAirport.Focus();
                }
            }
            else
            {
                DeleteAirPortBL.DeleteAirPort(txtCodeAirport.Text);
                MessageBox.Show("BAJA DE AEROPUERTO EXITOSO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearControls(string.Empty);
                txtCodeAirport.Focus();
            }
        }

        //Limpia los controles 
        private void ClearControls(string Empty)
        {
            txtCodeAirport.Text = Empty;
            txtCountryAirport.Text = Empty;
            txtNameAirport.Text = Empty;
            txtCountryName.Text = Empty;
        }

        #endregion

        
    }
}
