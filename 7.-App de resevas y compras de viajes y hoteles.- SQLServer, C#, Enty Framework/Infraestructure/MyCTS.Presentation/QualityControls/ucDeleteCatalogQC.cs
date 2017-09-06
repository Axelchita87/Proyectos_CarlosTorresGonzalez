using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.DataAccess;
using MyCTS.Entities;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucDeleteCatalogQC : CustomUserControl
    {

        /// <summary>
        /// Descripcion: Eliminar Catálogos en ClientsCatalogs
        /// Creación:    06-Diciembre-2010 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Ivan Martínez 
        /// </summary>

        public ucDeleteCatalogQC()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtAttribute;
            this.LastControlFocus = btnAccept;
        }

        #region ====Declarations====
        private bool isValid;
        #endregion

        //Coloca el foco en el textbox inicial
        private void ucDeleteCatalogQC_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtAttribute.Focus();
        }

        //Invoca los métodos de validación y ejecución
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidBussinessRules)
                Commands(txtAttribute.Text, txtRemark.Text);
        }

        #region ====Events====

        //Cambia el foco 
        private void txtAttribute_TextChanged(object sender, EventArgs e)
        {
            if (txtAttribute.Text.Length > 6)
                txtRemark.Focus();
        }

        //Cambia el foco 
        private void txtRemark_TextChanged(object sender, EventArgs e)
        {
            if (txtRemark.Text.Length > 3)
                btnAccept.Focus();
        }


        //KeyDown
        /// <summary>
        /// Este se usa para todos los controles en general si se oprime 
        /// Esc se manda a el User control de Welcome 
        /// Enter se manda la accion de botón de Aceptar
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

        #endregion


        #region ====MethodsClass====

        //Valida la información proporcionada
        private bool IsValidBussinessRules
        {
            get
            {
                if (string.IsNullOrEmpty(txtAttribute.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR ATRIBUTO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAttribute.Focus();
                }
                else if (string.IsNullOrEmpty(txtRemark.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR REMARK", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRemark.Focus();
                }
                else
                    isValid = true;

                return isValid;
            }
        }


        //Elimina los datos de la Base de Datos
        private void Commands(string attribute, string remark)
        {
            try
            {
                DeleteCatalogQCBL.DeleteCatalogQC(attribute, remark);
                MessageBox.Show("CATÁLOGO ELIMINADO CORRECTAMENTE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("NO SE PUDO BORRAR EL CATÁLOGO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion
    }
}
