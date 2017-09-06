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
    public partial class ucConsultingAirPorts : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Consulta los datos de AirPort en la BdD
        /// Creación:    10-06-10 , 
        /// Cambio:      *   , Solicito *
        /// Autor:       Jessica Gutierrez
        /// </summary>
        
        public ucConsultingAirPorts()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtCodeAirPort;
            this.LastControlFocus = btnAccept;
        }

        //Coloca el foco en el txtbox
        private void ucConsultingAirPorts_Load(object sender, EventArgs e)
        {
            txtCodeAirPort.Focus();
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
        //Coloca el foco de acuerdon a las las reglas 

        private void txtCodeAirport_TextChanged(object sender, EventArgs e)
        {
            if (txtCodeAirPort.Text.Length > 2)
                txtCodeCountry.Focus();
        }

        private void txtCountryAirport_TextChanged(object sender, EventArgs e)
        {
            if (txtCodeCountry.Text.Length > 1)
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
                if (string.IsNullOrEmpty(txtCodeAirPort.Text) && 
                    string.IsNullOrEmpty(txtCodeCountry.Text))
                {
                    MessageBox.Show(Resources.Development.Development.REQUIERE_INGRESES_CÓDIGO_AEROPUERTO_PAÍS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCodeAirPort.Focus();
                }
                else if (!string.IsNullOrEmpty(txtCodeAirPort.Text) &&
                        !string.IsNullOrEmpty(txtCodeCountry.Text))
                {
                    MessageBox.Show(Resources.Development.Development.REQUIERE_INGRESES_CÓDIGO_AEROPUERTO_PAÍS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCodeAirPort.Focus();
                }
                else
                    isValid = true;

                return isValid;
            }
        }

        /// <summary>
        /// Extrae los datos en la BD y llena el DataGridView
        /// </summary>
        private void Command()
        {
            string strToSearch = string.Empty;
            strToSearch = string.Concat(txtCodeAirPort.Text, txtCodeCountry.Text).Trim();
            List<AirPorts> list= AirPortsBL.GetAirPorts(strToSearch);
           if (list.Count > 0)
           {
               dataGridView1.DataSource = list;
               dataGridView1.Visible = true;
           }
        }

        #endregion
    }
}
