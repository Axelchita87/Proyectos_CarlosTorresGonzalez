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
    public partial class ucDeletePCCs : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Elimina los datos de PCCs en la BdD
        /// Creaci�n:    10-06-10 , 
        /// Cambio:      *   , Solicito *
        /// Autor:       Jessica Gutierrez
        /// </summary>
        public ucDeletePCCs()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = rdoSearch;
            this.LastControlFocus = btnAccept;
        }

        //Coloca el foco en el txtbox
        private void ucDeletePCCs_Load(object sender, EventArgs e)
        {
            FillAirlineClass();
            rdoSearch.Focus();
        }

        //Llama los metodos de validaci�n y envio de comando
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

        #region======= changeFocus ======

        //Llama el metodo de limpiar controles
        private void rdoSearch_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSearch.Checked)
                Clear(string.Empty);
        }

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
                List<AllPccs> list = AllPccsBL.GetAllPccs(txtPCC.Text, Login.OrgId);
                if (list.Count > 0)
                {
                    txtPCC.Text = list[0].CatPccId;
                    txtPCCName.Text = list[0].CatPccName;
                    cmbEstatus.Text = list[0].Status;
                    cmbStandardClass.Text = list[0].StandardClass;
                    cmbSpecificClass.Text = list[0].SpecificClass;
                    cmbConfirmation.Text = list[0].Confirmation;
                    cmbBussinessClass1.Text = list[0].BusinessClass1;
                    cmbBussinessClass2.Text = list[0].BusinessClass2;
                    cmbBussinessClass3.Text = list[0].BusinessClass3;
                    cmbBussinessClass4.Text = list[0].BusinessClass4;
                }
                else
                {
                    Clear(string.Empty);
                    txtPCC.Focus();
                }
            }
            else if(rdoDelete.Checked)
            {
                DeletePccsBL.DeletePccs(txtPCC.Text);
                MessageBox.Show("BAJA DE PCC EXITOSA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear(string.Empty);
                txtPCC.Focus();
            }
        }

        //Limpia los controles 
        private void Clear(string Empty)
        {
            txtPCC.Text = Empty;
            txtPCCName.Text = Empty;
            cmbSpecificClass.Text = Empty;
            cmbStandardClass.Text = Empty;
            cmbEstatus.Text = Empty;
            cmbBussinessClass1.Text = Empty;
            cmbBussinessClass2.Text = Empty;
            cmbBussinessClass3.Text = Empty;
            cmbBussinessClass4.Text = Empty;
            cmbConfirmation.Text = Empty;
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
