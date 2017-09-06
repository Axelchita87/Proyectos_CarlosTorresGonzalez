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
    public partial class ucAddAirPort : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Inserta nuevas AirPort en la BdD
        /// Creación:    10-06-10 
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez
        /// </summary>

        private bool exist = false;

        public ucAddAirPort()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus =txtCodeAirport ;
            this.LastControlFocus = btnAccept;
        }

        //Coloca el foco en el textbox
        private void ucAddAirPort_Load(object sender, EventArgs e)
        {
            txtCodeAirport.Focus();
        }

        /// <summary>
        /// Verifica si existe la Aeropuerto y manda a llamar los metodos
        /// de validación y envio de comando
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            List<AirPorts> list = AirPortsBL.GetAirPorts(txtCodeAirport.Text);
            if (list.Count > 0)
                exist = true;
            else
                exist = false;
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
        /// <summary>
        /// Verifica que cumpla con la longitud y cambia el foco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    txtCodeAirport.Text.Length < 3)
                {
                    MessageBox.Show(Resources.Development.Development.REQUIERE_INGRESES_CÓDIGO_AEROPUERTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCodeAirport.Focus();
                }
                else if (string.IsNullOrEmpty(txtNameAirport.Text))
                {
                    MessageBox.Show(Resources.Development.Development.REQUIERE_INGRESES_NOMBRE_AEROPUERTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNameAirport.Focus();
                }
                else if (string.IsNullOrEmpty(txtCountryAirport.Text)||
                        txtCountryAirport.Text.Length<2)
                {
                    MessageBox.Show(Resources.Development.Development.REQUIERE_INGRESES_CÓDIGO_PAÍS_AEROPUERTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCountryAirport.Focus();
                }
                else if (string.IsNullOrEmpty(txtCountryName.Text))
                {
                    MessageBox.Show(Resources.Development.Development.REQUIERE_INGRESES_NOMBRE_PAÍS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCountryName.Focus();
                }
                else if (exist)
                {
                    MessageBox.Show(Resources.Development.Development.EXISTE_AEROPUERTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCodeAirport.Focus();
                }
                else
                    isValid = true;

                return isValid;
            }
        }

        /// <summary>
        /// Inserta los datos en la BD y manda a llamar el metodo de 
        /// limpiar los controles
        /// </summary>
        private void Command()
        {
            SetAirPortBL.SetAirPorts(txtCodeAirport.Text, txtNameAirport.Text, txtCountryAirport.Text,txtCountryName.Text);
            MessageBox.Show("ALTA DE AEROPUERTO EXITOSA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearControls(string.Empty);
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
