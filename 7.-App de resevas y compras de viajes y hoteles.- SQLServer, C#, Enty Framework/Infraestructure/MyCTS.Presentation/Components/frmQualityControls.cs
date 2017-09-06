using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Presentation.Components;
using MyCTS.Forms.UI;

namespace MyCTS.Presentation.Components
{
    public partial class frmQualityControls : Form
    {

        /// <summary>
        /// Descripción: Formulario para insertar los nuevos datos 
        ///              de los quality controls
        /// Creación:    Diciembre 08 -Septiembre 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez/ Angel Trejo
        /// </summary>
        /// 
        #region Private Variables
        public string formPrompt = string.Empty;
        public string client = string.Empty;
        public string remarkLabelID = string.Empty;
        public string code = string.Empty;
        private string descriptionCode = string.Empty;
        #endregion
        

        public frmQualityControls()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carga de valores iniciales en la mascarilla 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmQualityControls_Load(object sender, EventArgs e)
        {
            lblPrompt.Text = formPrompt;
            txtInput.Focus();

        }
        /// <summary>
        /// Ejecuta la función que valida que contenga algun valor
        /// en el campo que vamos a ingresar
        /// </summary>
        /// <param name="sender">btnOK</param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!isValidBussinessRules())
            {
                insertvalue(client, remarkLabelID, code, txtInput.Text);
                this.Dispose();
            }

        }

        #region ===== Back to a Previous Usercontrol or Validate Enter KeyDown =====

        /// <summary>
        /// Sigue el flujo de emisión de boletos al presionar 
        /// la tecla ESC para pasar a la siguiente mascarilla
        /// o ejecutar las funciones al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Dispose();
            }
            if (e.KeyData.Equals(Keys.Enter))
            {
                btnOK_Click(sender, e);
            }


        }
        #endregion

        /// <summary>
        /// Validaciones de regla de negocio que se aplican en esta mascarilla
        /// </summary>
        /// <returns></returns>
        private bool isValidBussinessRules()
        { 
            bool isValid = true;
            if (string.IsNullOrEmpty(txtInput.Text))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_DESCRIPCION, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtInput.Focus();
            }
            else
            {
                isValid = false;
            }

            return isValid;
        }
        /// <summary>
        /// Función que inserta una nuevo valor(descripción) 
        /// al catalogo de Nextel
        /// </summary>
        /// <returns></returns>
        private void insertvalue(string Corporative, string LabelRemark, string ValueToInsert,string DescToInsert)
        {
            List<SetClientsCatalogsNextel> SetClientsCatalogsNextel = SetClientsCatalogsNextelBL.SetClientsCatalogsNextel(Corporative, LabelRemark, ValueToInsert, DescToInsert); 
        }
        /// <summary>
        /// Función que indica que hacer cuando la caja de texto cambia
        /// </summary>
        /// <returns></returns>
        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            if (txtInput.Text.Length > 59)
                btnOK.Focus();
        }
        /// <summary>
        /// Función que asigna color a la caja de texto
        /// </summary>
        /// <returns></returns>
        private void txtInput_Enter(object sender, EventArgs e)
        {
            txtInput.BackColor = Color.PaleGoldenrod;
        }
        /// <summary>
        /// Función que asigna color a la caja de texto
        /// </summary>
        /// <returns></returns>
        private void txtInput_Leave(object sender, EventArgs e)
        {
            txtInput.BackColor = Color.White;
        }

    }
}