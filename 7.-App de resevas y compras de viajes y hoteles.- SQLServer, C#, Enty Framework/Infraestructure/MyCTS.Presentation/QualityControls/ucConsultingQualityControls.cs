using System;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using MyCTS.Presentation.Components;
using MyCTS.Business;
using MyCTS.Entities;
using System.Collections.Generic;
using MyCTS.Services.Contracts;

namespace MyCTS.Presentation
{
    public partial class ucConsultingQualityControls : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Extrae los QualityControls por Atributo 
        /// Creación:    18-Junio-2010 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        public ucConsultingQualityControls()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtAttribute;
            this.LastControlFocus = btnAccept;
            ucAvailability.IsInterJetProcess = false;
        }

        //Coloca el foco en el textbox
        private void ConsultingQualityControls_Load(object sender, EventArgs e)
        {
            txtAttribute.Focus();
        }

        //Llama a los metodos de validación y comando
        private void btnAccept_Click(object sender, EventArgs e)
        {
            ShowControls(false);
            if (IsValidBussinessRules)
                Commands();
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

        //Cambia el foco 
        private void txtAttribute_TextChanged(object sender, EventArgs e)
        {
            if (txtAttribute.Text.Length > 5)
                btnAccept.Focus();
        }

        #region======MethodsClass======

        //Verifica si los datos obligatorios fueron ingresados
        private bool IsValidBussinessRules
        {
            get
            {
                bool isValid=false;
                if (string.IsNullOrEmpty(txtAttribute.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR ATRIBUTO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAttribute.Focus();
                }
                else
                    isValid = true;
                return isValid;
            }
        }

        //Extrae los datos de la BdD de la tabla de QualityControls
        private void Commands()
        {
            List<GetQCbyAttribute1> list = GetQCbyAttribute1BL.GetAttribute(txtAttribute.Text);
            if (list.Count > 0)
            {
                dataGridView1.DataSource = list;
                ShowControls(true);
                txtAttribute.Focus();
            }
            else
            {
                MessageBox.Show("EL ATRIBUTO NO EXISTE, INGRESE OTRO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAttribute.Focus();
            }
        }

        //Muestra u Oculta los controles
        private void ShowControls(bool show)
        {
            dataGridView1.Visible = show;
            lblInformation.Visible = show;
        }

        #endregion
    }
}
