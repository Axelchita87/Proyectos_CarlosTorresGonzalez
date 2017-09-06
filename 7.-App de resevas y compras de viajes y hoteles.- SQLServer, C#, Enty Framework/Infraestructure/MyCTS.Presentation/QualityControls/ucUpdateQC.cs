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
    public partial class ucUpdateQC : CustomUserControl
    {
        public ucUpdateQC()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = rdoSearch;
            this.LastControlFocus = btnAccept;
        }

        private void ucUpdateQC_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            toolTip1.SetToolTip(this.txtDescription, "Nombre de Quality Controls");
            toolTip2.SetToolTip(this.txtCtrlDescription, "Descripción de funcionalidad de QC");
            FullCombo();
            rdoSearch.Focus();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (rdoSearch.Checked)
            {
                if (IsValidSearch)
                    Search();
            }
            else if (rdoUpdate.Checked)
            {
                if (IsValidBussinessRules)
                    Commands();
            }
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

        #region====== Methods class=======

        private bool IsValidSearch
        {
            get
            {
                bool isValid = false;
                if (string.IsNullOrEmpty(txtNumberLabel.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR NUMERO DE ETIQUETA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberLabel.Focus();
                }
                else
                    isValid = true;
                return isValid;
            }
        }

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
                else
                    isValid = true;
                return isValid;
            }
        }

        private void Search()
        {
            List<GetQualityCotrols> list = GetQualityCotrolsBL.GetQualityCotrols(txtNumberLabel.Text);
            if (list.Count > 0)
            {
                txtDescription.Text = list[0].Description;
                txtCtrlLen.Text = list[0].CtrlLen.ToString();
                txtCtrlCatalogues.Text = list[0].CtrlCatalogues;
                txtCtrlDescription.Text = list[0].CtrlDescription;
                cmbAllowInsertValues.Text = list[0].AllowInsertValues.ToString();
                cmbCtrlCurrentCriteria.Text = list[0].CtrlCurrentCriteria;
                cmbCtrlType.Text = list[0].CtrlType;
            }
            else
                MessageBox.Show("NO EXISTE QUALITY CONTROLS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Envia los datos para dar de alta los Quality Controls
        private void Commands()
        {
            string ctrlName = string.Empty;
            string ctrlType = string.Empty;

            if (cmbCtrlType.SelectedIndex > 0 ||
                string.IsNullOrEmpty(cmbCtrlType.Text))
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

            if (string.IsNullOrEmpty(txtCtrlLen.Text))
                txtCtrlLen.Text = null;
            if (string.IsNullOrEmpty(txtCtrlDescription.Text))
                txtCtrlDescription.Text = null;
            if (string.IsNullOrEmpty(txtCtrlCatalogues.Text))
                txtCtrlCatalogues.Text = null;
            if (string.IsNullOrEmpty(cmbCtrlType.Text))
                cmbCtrlType.Text = null;
            if (string.IsNullOrEmpty(cmbCtrlCurrentCriteria.Text))
                cmbCtrlCurrentCriteria.Text = null;
            if (string.IsNullOrEmpty(cmbAllowInsertValues.Text))
                cmbAllowInsertValues.Text = null;
            UpdateQualityControlsBL.UpdateQualityControls(txtCtrlDescription.Text, txtNumberLabel.Text,
            ctrlType, ctrlName, txtCtrlDescription.Text, Convert.ToInt32(txtCtrlLen.Text), cmbCtrlCurrentCriteria.Text,
            txtCtrlCatalogues.Text, Convert.ToBoolean(cmbAllowInsertValues.Text));
            MessageBox.Show("MODIFICACIÓN DE QUALITY CONTROLS EXITOSA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);


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

        private void rdoSearch_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSearch.Checked)
            {
                ClearControls(string.Empty);
                txtNumberLabel.Enabled = true;
                txtNumberLabel.Focus();
            }
        }

        private void rdoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoUpdate.Checked)
                txtNumberLabel.Enabled = false;
        }
    }
}
