using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Services.Contracts;

namespace MyCTS.Presentation
{
    public partial class ucRegenerateInvoice : CustomUserControl
    {

        /// <summary>
        /// Descripción: User Control que solicita la regeneración de una
        ///              factura actualizando un campo en oracle(CORPP)
        /// Creación:    Agosto 03, 2010. Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Angel Trejo
        /// </summary>
        /// 

        public ucRegenerateInvoice()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = cmbTypeInvoice;
            this.LastControlFocus = btnAccept;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidBussinesRules)
            {
                OracleConnection ws = new OracleConnection();
                if (ws.RegenerateInvoice(cmbTypeInvoice.SelectedItem.ToString().Substring(0, 3), txtNumberInvoice.Text, Login.OrgId))
                    MessageBox.Show("SU SOLICITUD DE REGENERACIÓN FUE ENVIADA CON ÉXITO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("EL NÚMERO DE FACTURA NO EXISTE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
        }

        /// <summary>
        /// Valida las reglas de negocio aplicadas a este user control
        /// </summary>
        private bool IsValidBussinesRules
        {
            get 
            {
                bool status = false;
                if (cmbTypeInvoice.SelectedIndex.Equals(0))
                {
                    MessageBox.Show("DEBES SELECCIONAR EL TIPO DE FACTURA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbTypeInvoice.Focus();
                }
                else if (string.IsNullOrEmpty(txtNumberInvoice.Text))
                {
                    MessageBox.Show("DEBES INGRESAR EL NÚMERO DE FACTURA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberInvoice.Focus();
                }
                else
                    status = true;
                return status;
            }
        }

        private void ucRegenerateInvoice_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            cmbTypeInvoice.SelectedIndex = 0;
            cmbTypeInvoice.Focus();
        }

        #region =====Back to a Previous Usercontrol or Validate Enter KeyDown=====

        /// <summary>
        /// Regresa al user cotrol welcome cuando se presiona ESC o ejecuta
        /// la acción del botón aceptar cuando se presiona Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            if (e.KeyData.Equals(Keys.Enter))
                btnAccept_Click(sender, e);
        }

        #endregion // Back to a Previous Usercontrol or Validate Enter KeyDown
             
    }
}
