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
    public partial class ucAddAlAgreements : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Inserta nuevas AirLineAgreements en la BdD
        /// Creación:    10-06-10  
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez
        /// </summary>
        
        private bool exist=false;
        private TextBox txt;

        public ucAddAlAgreements()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtAgreementCode;
            this.LastControlFocus = btnAccept;
        }

        //Coloca el foco en el txtbox y envia hacia el frente el Listbox
        private void ucAddAlAgreements_Load(object sender, EventArgs e)
        {
            lbAirLine.BringToFront();
            txtAgreementCode.Focus();
        }

        /// <summary>
        /// Verifica si existe la AirLineAgreements y manda a llamar los metodos
        /// de validación y envio de comando
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            List<GetAirLineAgreements> list = GetAirLineAgreementsBL.GetAirLineAgreements(txtAgreementCode.Text);
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
        /// Si es KeyDown despliega la lista del ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
            if (e.KeyCode == Keys.Down)
            {
                if (lbAirLine.Items.Count > 0)
                {
                    lbAirLine.SelectedIndex = 0;
                    lbAirLine.Focus();
                    lbAirLine.Visible = true;
                    lbAirLine.Focus();
                }
            }
        }

        #region====== Change Focus ======
        //Cambio de foco de acuerdo al length

        private void txtAgreementCode_TextChanged(object sender, EventArgs e)
        {
            //if (txtAgreementCode.Text.Length > 1)
            //    txtInternationalComission.Focus();
            txt = (TextBox)sender;
            Common.SetListBoxAirlines(txt, lbAirLine);

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

        #region===== Events ListBox ========

        /// <summary>
        /// Asignación de acciones al presionar la tecla ENTER o ESC 
        /// cuando el lbAirLine tiene el foco
        /// </summary>
        /// <param name="sender">lbAirLine</param>
        /// <param name="e"></param>
        private void lbAirLine_KeyDown(object sender, KeyEventArgs e)
        {
            ListBox ListBox = (ListBox)sender;
            if (e.KeyCode == Keys.Enter)
            {
                ListItem li = (ListItem)ListBox.SelectedItem;
                txt.Text = li.Value;
                ListBox.Visible = false;
                txt.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                lbAirLine.Visible = false;
                txt.Focus();
            }

        }

        /// <summary>
        /// Selecciona algún elemento dentro de algún listbox al hacer un click
        /// sobre el
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_MouseClick(object sender, MouseEventArgs e)
        {
            ListBox listBox = (ListBox)sender;

            ListItem li = (ListItem)listBox.SelectedItem;
            txt.Text = li.Value;
            listBox.Visible = false;
            txt.Focus();
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
                    txtAgreementCode.Text.Length != 2)
                {
                    MessageBox.Show(Resources.Development.Development.REQUIERE_INGRESES_CÓDIGO_ACUERDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAgreementCode.Focus();
                }
                else if (string.IsNullOrEmpty(txtInternationalComission.Text)||
                        txtInternationalComission.Text.Length<2)
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
                else if (exist)
                {
                    MessageBox.Show(Resources.Development.Development.EXISTE_ACUERDO_AEROLINEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAgreementCode.Focus();
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

            SetAirLineAgreementsBL.SetAirLineAgreements(txtAgreementCode.Text, txtInternationalComission.Text, txtDomesticComission.Text, tourcode, osi);
            MessageBox.Show("ALTA DE ACUERDO DE AEROLINEA EXITOSA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearControls(string.Empty);
            txtAgreementCode.Focus();
        }

        //Limpia los controles 
        private void ClearControls(string Empty)
        {
            txtAgreementCode.Text = Empty;
            txtInternationalComission.Text = Empty;
            txtDomesticComission.Text = Empty;
            txtTourCode.Text= Empty;
            txtOSI.Text = Empty;
        }

        #endregion
    }
}
        