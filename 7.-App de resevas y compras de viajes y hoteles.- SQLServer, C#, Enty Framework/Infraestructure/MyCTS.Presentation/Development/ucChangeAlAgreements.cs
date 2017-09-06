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
    public partial class ucChangeAlAgreements : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Cambia los datos de AirLinesAgreements en la BdD
        /// Creación:    10-06-10 , 
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez
        /// </summary>

        public ucChangeAlAgreements()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = rdoSearch;
            this.LastControlFocus = btnAccept;
        }

        //Coloca el foco en el txtbox
        private void ucChangeAlAgreements_Load(object sender, EventArgs e)
        {
            rdoSearch.Focus();
        }

        /// <summary>
        /// Manda a llamar los metodos de validación y envio de comando
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

        #region====== Change Focus ======

        //Llama al metodo de limpiar controles
        private void rdoSearch_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSearch.Checked)
                ClearControls(string.Empty);
        }

        private void rdoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoUpdate.Checked)
                txtAgreementCode.Enabled = false;
        }

        //Coloca el foco deacuerdo a las reglas
        private void txtAgreementCode_TextChanged(object sender, EventArgs e)
        {
            if (txtAgreementCode.Text.Length > 1)
                txtInternationalComission.Focus();
        }

        private void txtInternationalComission_TextChanged(object sender, EventArgs e)
        {
            if (txtInternationalComission.Text.Length > 1)
                txtDomesticComission.Focus();
        }

        private void txtDomesticComission_TextChanged(object sender, EventArgs e)
        {
            if (txtDomesticComission.Text.Length > 1)
                txtTourCode.Focus();
        }

        private void txtTourCode_TextChanged(object sender, EventArgs e)
        {
            if (txtTourCode.Text.Length > 49)
                txtOSI.Focus();
        }

        private void txtOSI_TextChanged(object sender, EventArgs e)
        {
            if (txtOSI.Text.Length > 49)
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
                if (string.IsNullOrEmpty(txtAgreementCode.Text) ||
                    txtAgreementCode.Text.Length < 2)
                {
                    MessageBox.Show(Resources.Development.Development.REQUIERE_INGRESES_CÓDIGO_ACUERDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAgreementCode.Focus();
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
                if (string.IsNullOrEmpty(txtAgreementCode.Text) ||
                    txtAgreementCode.Text.Length < 2)
                {
                    MessageBox.Show(Resources.Development.Development.REQUIERE_INGRESES_CÓDIGO_ACUERDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAgreementCode.Focus();
                }
                else if (string.IsNullOrEmpty(txtInternationalComission.Text) ||
                        txtInternationalComission.Text.Length < 2)
                {
                    MessageBox.Show(Resources.Development.Development.REQUIERE_INGRESES_COMISION_INTERNACIONAL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtInternationalComission.Focus();
                }
                else if (string.IsNullOrEmpty(txtDomesticComission.Text) ||
                   txtDomesticComission.Text.Length < 2)
                {
                    MessageBox.Show(Resources.Development.Development.REQUIERE_INGRESES_COMISION_DOMESTICA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDomesticComission.Focus();
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
                List<GetAirLineAgreements> list = GetAirLineAgreementsBL.GetAirLineAgreements(txtAgreementCode.Text);
                if (list.Count > 0)
                {
                    txtAgreementCode.Text = list[0].IDAlCode;
                    txtDomesticComission.Text = list[0].DomesticComission;
                    txtInternationalComission.Text = list[0].InternationalComission;
                    txtOSI.Text = list[0].OSI;
                    txtTourCode.Text = list[0].TourCode;
                }
                else
                {
                    ClearControls(string.Empty);
                    txtAgreementCode.Focus();
                }
            }
            else if (rdoUpdate.Checked)
            {
                string tourcode = string.Empty;
                string osi = string.Empty;

                if (!string.IsNullOrEmpty(txtOSI.Text))
                    osi = txtOSI.Text;
                else
                    osi = null;
                if (!string.IsNullOrEmpty(txtTourCode.Text))
                    tourcode = txtTourCode.Text;
                else
                    tourcode = null;
                UpdateAlAgreementsBL.UpdateAlAgreements(txtAgreementCode.Text, txtInternationalComission.Text, txtDomesticComission.Text, tourcode, osi);
                MessageBox.Show("MODIFICACIÓN DE ACUERDO DE AEROLINEA EXITOSA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearControls(string.Empty);
                txtAgreementCode.Focus();
            }
        }

        //Limpia los controles 
        private void ClearControls(string Empty)
        {
            txtAgreementCode.Text = Empty;
            txtInternationalComission.Text = Empty;
            txtDomesticComission.Text = Empty;
            txtTourCode.Text = Empty;
            txtOSI.Text = Empty;
            txtAgreementCode.Enabled = true;
        }

        #endregion
    }
}
