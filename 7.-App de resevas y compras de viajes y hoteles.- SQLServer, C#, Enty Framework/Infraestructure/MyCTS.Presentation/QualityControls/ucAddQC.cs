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

namespace MyCTS.Presentation
{
    public partial class ucAddQC : CustomUserControl
    {
        private bool exist = false;

        public ucAddQC()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtDescription;
            this.LastControlFocus = btnAccept;
        }

        //Llena el combo y coloca el foco
        private void AddQC_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            toolTip1.SetToolTip(this.txtDescription, "Nombre de Quality Controls");
            toolTip2.SetToolTip(this.txtCtrlDescription, "Descripción de funcionalidad de QC");
            FullCombo();
            txtDescription.Focus();
        }

        //Extrae la lista de los QC y manda a llamar los metodos de validación y comando
        private void btnAccept_Click(object sender, EventArgs e)
        {
            List<GetQCIDCtrl> list = GetQCIDCtrlBL.GetQCIDCtrl(txtNumberLabel.Text);
            if (list.Count > 0)
                exist = true;
            else
                exist = false;

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

        //Valida texto de combo y coloca el index correspondiente
        private void cmbAllowInsertValues_TextChanged(object sender, EventArgs e)
        {
            if (cmbAllowInsertValues.Text.ToUpper() == "F")
                cmbAllowInsertValues.SelectedIndex = 2;
            else if (cmbAllowInsertValues.Text.ToUpper() == "T")
                cmbAllowInsertValues.SelectedIndex = 1;
        }

        #region====== Methods class=======

        //Valida los campos mandatorios
        private bool IsValidBussinessRules
        {
            get
            {
                bool isValid = false;
                if (string.IsNullOrEmpty(txtDescription.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR DESCRIPCIÓN", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDescription.Focus();
                }
                else if (string.IsNullOrEmpty(txtNumberLabel.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR NUMERO DE ETIQUETA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberLabel.Focus();
                }
                else if (string.IsNullOrEmpty(txtCtrlDescription.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR DESCRIPCIÓN DE CONTROL", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCtrlDescription.Focus();
                }
                else if (string.IsNullOrEmpty(txtCtrlLen.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR EL TAMAÑO DEL CONTROL", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCtrlLen.Focus();
                }
                else if (cmbCtrlCurrentCriteria.SelectedIndex < 1)
                {
                    MessageBox.Show("REQUIERE INGRESAR CRITERIOS DEL CONTROL", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbCtrlCurrentCriteria.Focus();
                }
                else if (string.IsNullOrEmpty(txtCtrlCatalogues.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR NOMBRE DE CATALOGO AL QUE PERTENCE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCtrlCatalogues.Focus();
                }
                else if (cmbAllowInsertValues.SelectedIndex < 1)
                {
                    MessageBox.Show("REQUIERE INGRESAR ALLOW INSERT VALUES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbAllowInsertValues.Focus();
                }
                else if (exist)
                {
                    MessageBox.Show("EL NUMERO DE ETIQUETA YA EXISTE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberLabel.Focus();
                }
                else
                    isValid = true;
                return isValid;
            }
        }

        //Envia los datos para dar de alta los Quality Controls
        private void Commands()
        {
            string ctrlName=string.Empty;
            string ctrlType = string.Empty;

            if (cmbCtrlType.SelectedIndex > 0)
            {
                if (cmbCtrlType.Text == "Textbox")
                    ctrlName = string.Concat("txt", txtNumberLabel.Text);
                else if (cmbCtrlType.Text == "Combobox")
                    ctrlName = string.Concat("cmb", txtNumberLabel.Text);
                ctrlType = cmbCtrlType.Text;
            }
            else
            {
                ctrlName = null;
                ctrlType = null;
            }
            SetQualityCotrolsBL.SetQualityCotrols(txtCtrlDescription.Text, txtNumberLabel.Text,
                ctrlType, ctrlName, txtCtrlDescription.Text, Convert.ToInt32(txtCtrlLen.Text), cmbCtrlCurrentCriteria.Text,
                txtCtrlCatalogues.Text, Convert.ToBoolean(cmbAllowInsertValues.Text));
            MessageBox.Show("ALTA DE QUALITY CONTROLS EXITOSA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearControls(string.Empty);
        }

        //Extrae los datos para llenar el combo
        private void FullCombo()
        {
            List<GetCtrlCatalogues> listType = GetCtrlCataloguesBL.GetCtrlCatalogues("type");
            if (listType.Count > 0)
            {
                bindingSource1.DataSource = listType;

                foreach (GetCtrlCatalogues item in listType)
                {
                    ListItem litem = new ListItem();
                    litem.Text = string.Format("{0}", item.ctrlName);
                    litem.Value = item.ctrlName;
                    cmbCtrlType.Items.Add(litem);
                }
            }

            List<GetCtrlCatalogues> list = GetCtrlCataloguesBL.GetCtrlCatalogues("currentCriteria");
            if (list.Count > 0)
            {
                bindingSource1.DataSource = list;

                foreach (GetCtrlCatalogues item in list)
                {
                    ListItem litem = new ListItem();
                    litem.Text = string.Format("{0}", item.ctrlName);
                    litem.Value = item.ctrlName;
                    cmbCtrlCurrentCriteria.Items.Add(litem);
                }
            }
        }

        //Limpoa los controles
        private void ClearControls(string Empty)
        {
            txtDescription.Text = Empty;
            txtNumberLabel.Text = Empty;
            txtCtrlLen.Text = Empty;
            txtCtrlDescription.Text = Empty;
            txtCtrlCatalogues.Text = Empty;
            cmbCtrlType.Text = Empty;
            cmbCtrlCurrentCriteria.Text = Empty;
            cmbAllowInsertValues.Text = Empty;
        }

        #endregion
    }
}
