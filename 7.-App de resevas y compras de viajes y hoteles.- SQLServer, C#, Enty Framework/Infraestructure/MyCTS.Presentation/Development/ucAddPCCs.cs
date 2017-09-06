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
    public partial class ucAddPCCs : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Inserta nuevas PCC en la BdD
        /// Creación:    10-06-10 
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez
        /// </summary>
        
        private bool statusValidPCC = false;

        public ucAddPCCs()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus =txtPCC;
            this.LastControlFocus = btnAccept;
        }

        //Coloca el foco en el txtbox y envia llena los combos con datos de BD
        private void ucAddPCCs_Load(object sender, EventArgs e)
        {
            FillAirlineClass();
            txtPCC.Focus();
        }

        /// <summary>
        /// Verifica si existe la AirLineAgreements y manda a llamar los metodos
        /// de validación y envio de comando
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            List<ListItem> CatPccsList = CatPccsBL.GetPccs(txtPCC.Text, Login.OrgId);
            if (CatPccsList.Count>(0))
                statusValidPCC = true;
            else
                statusValidPCC = false;

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

        #region======= changeFocus ======
        //Coloca el foco de acuerdon a las las reglas 

        private void txtPCC_TextChanged(object sender, EventArgs e)
        {
            if (txtPCC.Text.Length > 3)
                txtPCCName.Focus();
        }
        private void txtPCCName_TextChanged(object sender, EventArgs e)
        {
            if (txtPCCName.Text.Length > 49)
                cmbEstatus.Focus();
        }


        #endregion

        #region ===== methodsClass =====

        //Valida los campos que son obligatorios
        private bool IsValidBussinessRules
        {
            get
            {
                bool isValid = false;
                if (string.IsNullOrEmpty(txtPCC.Text)||
                    txtPCC.Text.Length<4)
                {
                    MessageBox.Show(Resources.Development.Development.REQUIERE_INGRESES_PCC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPCC.Focus();
                }
                else if (string.IsNullOrEmpty(txtPCCName.Text))
                {
                    MessageBox.Show(Resources.Development.Development.REQUIERE_INGRESES_NOMBRE_PCC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPCCName.Focus();
                }
                else if (statusValidPCC)
                {
                    MessageBox.Show(Resources.Development.Development.EXISTE_PCC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPCC.Focus();
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
            string status = string.Empty;
            string standar = string.Empty;
            string specific = string.Empty;
            string confirmation = string.Empty;
            string bussiness1 = string.Empty;
            string bussiness2 = string.Empty;
            string bussiness3 = string.Empty;
            string bussiness4 = string.Empty;

            #region====Assignment Value=====
            if (string.IsNullOrEmpty(cmbEstatus.Text))
                status = null;
            else
                status = cmbEstatus.Text.ToUpper();
            if (string.IsNullOrEmpty(cmbStandardClass.Text))
                standar = null;
            else
                standar = cmbStandardClass.Text.ToUpper();
            if (string.IsNullOrEmpty(cmbSpecificClass.Text))
                specific = null;
            else
                specific = cmbSpecificClass.Text.ToUpper();
            if (string.IsNullOrEmpty(cmbConfirmation.Text))
                confirmation = null;
            else
                confirmation = cmbConfirmation.Text.ToUpper();
            if (string.IsNullOrEmpty(cmbBussinessClass1.Text))
                bussiness1 = null;
            else
                bussiness1 = cmbBussinessClass1.Text.ToUpper();
            if (string.IsNullOrEmpty(cmbBussinessClass2.Text))
                bussiness2 = null;
            else
                bussiness2 = cmbBussinessClass2.Text.ToUpper();
            if (string.IsNullOrEmpty(cmbBussinessClass3.Text))
                bussiness3 = null;
            else
                bussiness3 = cmbBussinessClass3.Text.ToUpper();
            if (string.IsNullOrEmpty(cmbBussinessClass4.Text))
                bussiness4 = null;
            else
                bussiness4 = cmbBussinessClass4.Text.ToUpper();
            #endregion

            SetPCCsBL.SetPCCs(txtPCC.Text, txtPCCName.Text, status, standar,
               specific, confirmation, bussiness1, bussiness2,bussiness3, bussiness4,Login.OrgId);
            MessageBox.Show("ALTA DE PCC EXITOSA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearControls(string.Empty);
            txtPCC.Focus();
        }

        //Limpia los controles 
        private void ClearControls(string Empty)
        {
            cmbSpecificClass.Text = Empty;
            cmbStandardClass.Text = Empty;
            cmbEstatus.Text = Empty;
            cmbBussinessClass1.Text = Empty;
            cmbBussinessClass2.Text = Empty;
            cmbBussinessClass3.Text = Empty;
            cmbBussinessClass4.Text = Empty;
            cmbConfirmation.Text = Empty;
            txtPCC.Text = Empty;
            txtPCCName.Text = Empty;
        }

        //Fill combobox ClassOfService with DB information
        /// <summary>
        /// Llena el combo con Clase de Servicio
        /// </summary>
        private void FillAirlineClass()
        {
            List<AirLinesClass> listAirLinesClass = AirLinesClassBL.GetCatAirLinesClass();
            bindingSource1.DataSource = listAirLinesClass;

            foreach (AirLinesClass airelineclassItem in listAirLinesClass)
            {
                ListItem litem = new ListItem();
                litem.Text = string.Format("{0}", airelineclassItem.CatAirLinClaID, airelineclassItem.CatAirLinClaName);
                litem.Value = airelineclassItem.CatAirLinClaID;
                cmbStandardClass.Items.Add(litem);
                cmbSpecificClass.Items.Add(litem);
                cmbBussinessClass1.Items.Add(litem);
                cmbBussinessClass2.Items.Add(litem);
                cmbBussinessClass3.Items.Add(litem);
                cmbBussinessClass4.Items.Add(litem);
            }
        }

        #endregion
    }
}
