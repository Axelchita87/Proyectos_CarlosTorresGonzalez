using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Forms.UI;


namespace MyCTS.Presentation
{
    public partial class ucAdminQueuesProceso : CustomUserControl
    {

        /// <summary>
        /// Descripcion: Permite administrar la informacion de ToolsOnlineQueue
        /// Creación:   12/06/13 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        int i = 1;
        bool ExitName = false;
        
        public ucAdminQueuesProceso()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtQueue1;
            this.LastControlFocus = btnAccept;
        }
        //Extrae y coloca los datos de las Queues
        private void ucAdminQueuesProceso_Load(object sender, EventArgs e)
        {
            try
            {
                ComboPicCode();
                ComboPCC();
                List<OnlineToolsQueues> onlineQueue = new List<OnlineToolsQueues>();
                onlineQueue = OnlineToolsQueuesBL.GetOnlineToolsQueues();
                foreach (OnlineToolsQueues queue in onlineQueue)
                {
                    AsignarValoresQueues(queue, "txtQueue" + i, "cmbPCC" + i, "cmbPicCode" + i, queue.Queue.ToString(),queue.PCC,queue.PicCode.ToString());
                    ExitName = false;
                    ActivateDesactivateControls("txtQueue" + i, "cmbPCC" + i, "cmbPicCode" + i, "lblName" + i, "txtName" + i, "lblQueue" + i, "lblPCC" + i,
                        "lblPicCode" + i, "lblLine" + i, "chkDelete"+i, false, true);
                    if (i == 3)
                    {
                        lblName3.Text = queue.Description.Substring(0,1) + queue.Description.Substring(1,queue.Description.Length-1).ToLower();
                        lblName3.Visible = true;
                        txtName3.Visible = false;
                    }
                    else if (i == 4)
                    {
                        lblName4.Text = queue.Description.Substring(0, 1) + queue.Description.Substring(1, queue.Description.Length - 1).ToLower(); 
                        lblName4.Visible = true;
                        txtName4.Visible = false;
                    }
                    else if (i == 5)
                    {
                        lblName5.Text = queue.Description.Substring(0, 1) + queue.Description.Substring(1, queue.Description.Length - 1).ToLower(); 
                        lblName5.Visible = true;
                        txtName5.Visible = false;
                    }

                    i++;
                }
                
                txtQueue1.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //Asigna los valores a los campos correspondientes
        private void AsignarValoresQueues(OnlineToolsQueues queue, string nombretxtQueue, string nombrecmbPCC, string nombrecmbPicCode, string valorQueue, string valorPCC, string valorPicCode)
        {
            SmartTextBox txtQueueGenerico = (SmartTextBox)this.Controls.Find(nombretxtQueue, true)[0];
            ComboBox cmbPCCGenerico = (ComboBox)this.Controls.Find(nombrecmbPCC, true)[0];
            ComboBox cmbPicCodeGenerico = (ComboBox)this.Controls.Find(nombrecmbPicCode, true)[0];
            txtQueueGenerico.Text = valorQueue;
            cmbPCCGenerico.Text = valorPCC;
            cmbPicCodeGenerico.Text = valorPicCode;
        }
        //Activa y Desactiva los controles conforme a lo que se requiere
        private void ActivateDesactivateControls(string nombretxtQueue, string nombrecmbPCC, string nombrecmbPicCode,string nombrelblName,string nombretxtName,
            string nombrelblQueue, string nombrelblPCC, string nombrelblPicCode,string nombrelblLine, string chkDelete, bool visibleName, bool visibleControls)
        {
            SmartTextBox txtQueueGenerico = (SmartTextBox)this.Controls.Find(nombretxtQueue, true)[0];
            ComboBox cmbPCCGenerico = (ComboBox)this.Controls.Find(nombrecmbPCC, true)[0];
            ComboBox txtPicCodeGenerico = (ComboBox)this.Controls.Find(nombrecmbPicCode, true)[0];
            Label lblQueueGenerico = (Label)this.Controls.Find(nombrelblQueue, true)[0];
            Label lblPCCGenerico = (Label)this.Controls.Find(nombrelblPCC, true)[0];
            Label lblPicCodeGenerico = (Label)this.Controls.Find(nombrelblPicCode, true)[0];
            CheckBox chkDeleteGenerico = (CheckBox)this.Controls.Find(chkDelete, true)[0];
            if (i != 5)
            {
                Label lblLineGenerico = (Label)this.Controls.Find(nombrelblLine, true)[0];
                lblLineGenerico.Visible = visibleControls;
            }

            txtQueueGenerico.Visible = visibleControls;
            cmbPCCGenerico.Visible = visibleControls;
            txtPicCodeGenerico.Visible = visibleControls;
            lblQueueGenerico.Visible = visibleControls;
            lblPCCGenerico.Visible = visibleControls;
            lblPicCodeGenerico.Visible = visibleControls;
            chkDeleteGenerico.Visible = visibleControls;
 
            if (ExitName)
            {
                SmartTextBox txtNameGenerico = (SmartTextBox)this.Controls.Find(nombretxtName, true)[0];
                Label lblNameGenerico = (Label)this.Controls.Find(nombrelblName, true)[0];
                lblNameGenerico.Visible = visibleControls;
                txtNameGenerico.Visible = visibleName;
            }
        }
        //Agrega los botones
        private void btnAddQueue_Click(object sender, EventArgs e)
        {
            ExitName = true;
            try
            {
                ActivateDesactivateControls("txtQueue" + i, "cmbPCC" + i, "cmbPicCode" + i, "lblName" + i, "txtName" + i, "lblQueue" + i, "lblPCC" + i,
                    "lblPicCode" + i, "lblLine" + i, "chkDelete"+i, true, true);
                i++;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Agrega los datos de la nueva Queue
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (chkDelete1.Checked == false && chkDelete2.Checked == false && chkDelete3.Checked == false && chkDelete4.Checked == false && chkDelete5.Checked == false
                && Validation)
            {
                AddToolsOnlineQueues queueOnline = new AddToolsOnlineQueues();

                if (txtName3.Text != string.Empty)
                {
                    queueOnline.Descripcion = txtName3.Text;
                    queueOnline.Queue = Convert.ToInt32(txtQueue3.Text);
                    queueOnline.PCC = ((ListItem)cmbPCC3.SelectedItem).Value;
                    queueOnline.PicCode = Convert.ToInt32(((ListItem)cmbPicCode3.SelectedItem).Value);
                }
                else if (txtName4.Text != string.Empty)
                {
                    queueOnline.Descripcion = txtName4.Text;
                    queueOnline.Queue = Convert.ToInt32(txtQueue4.Text);
                    queueOnline.PCC = ((ListItem)cmbPCC4.SelectedItem).Value;
                    queueOnline.PicCode = Convert.ToInt32(((ListItem)cmbPicCode4.SelectedItem).Value);
                }
                else if (txtName5.Text != string.Empty)
                {
                    queueOnline.Descripcion = txtName5.Text;
                    queueOnline.Queue = Convert.ToInt32(txtQueue5.Text);
                    queueOnline.PCC = ((ListItem)cmbPCC5.SelectedItem).Value;
                    queueOnline.PicCode = Convert.ToInt32(((ListItem)cmbPicCode5.SelectedItem).Value);
                }
                try
                {
                    if (!string.IsNullOrEmpty(queueOnline.Descripcion) && !string.IsNullOrEmpty(queueOnline.PCC)
                        && !string.IsNullOrEmpty(queueOnline.PicCode.ToString()) && !string.IsNullOrEmpty(queueOnline.Queue.ToString()))
                    {
                        AddToolsOnlineQueuesBL.AddToolsOnlineQueues(queueOnline);
                        MessageBox.Show(Resources.Constants.ALTA_QUEUE_ADMIN, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                DeleteToolOnlineQueues delete = new DeleteToolOnlineQueues();
                if (chkDelete1.Checked)
                {
                    delete.Description = lblName1.Text;
                }
                else if (chkDelete2.Checked)
                {
                    delete.Description = lblName2.Text;
                }
                else if (chkDelete3.Checked)
                {
                    delete.Description = lblName3.Text;
                }
                else if (chkDelete4.Checked)
                {
                    delete.Description = lblName4.Text;
                }
                else if (chkDelete5.Checked)
                {
                    delete.Description = lblName5.Text;
                }
                DeleteToolOnlineQueuesBL.DeleteToolOnlineQueues(delete.Description);
                MessageBox.Show(Resources.Constants.ELIMINACION_SOLICITADA_SATISFACTORIA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
        }
        //Validacion de reglas
        private bool Validation
        {
            get
            {
                bool validation = false;
                if (string.IsNullOrEmpty(txtQueue1.Text) && !string.IsNullOrEmpty(cmbPCC1.Text))
                {
                    MessageBox.Show(Resources.Constants.INGRESE_LA_QUEUE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQueue1.Focus();
                }
                else if (!string.IsNullOrEmpty(txtQueue1.Text) && string.IsNullOrEmpty(cmbPCC1.Text))
                {
                    MessageBox.Show(Resources.Constants.INGRESA_PCC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbPCC1.Focus();
                }
                else if (string.IsNullOrEmpty(cmbPicCode1.Text) && !string.IsNullOrEmpty(cmbPCC1.Text))
                {
                    MessageBox.Show(Resources.Constants.INGRESE_EL_PICCODE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbPicCode1.Focus();
                }
                else if (string.IsNullOrEmpty(txtQueue2.Text) && !string.IsNullOrEmpty(cmbPCC2.Text))
                {
                    MessageBox.Show(Resources.Constants.INGRESE_LA_QUEUE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQueue2.Focus();
                }
                else if (!string.IsNullOrEmpty(txtQueue2.Text) && string.IsNullOrEmpty(cmbPCC2.Text))
                {
                    MessageBox.Show(Resources.Constants.INGRESA_PCC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbPCC2.Focus();
                }
                else if (string.IsNullOrEmpty(cmbPicCode2.Text) && !string.IsNullOrEmpty(cmbPCC2.Text))
                {
                    MessageBox.Show(Resources.Constants.INGRESE_EL_PICCODE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbPicCode2.Focus();
                }
                else if (string.IsNullOrEmpty(txtQueue3.Text) && !string.IsNullOrEmpty(cmbPCC3.Text))
                {
                    MessageBox.Show(Resources.Constants.INGRESE_LA_QUEUE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQueue3.Focus();
                }
                else if (!string.IsNullOrEmpty(txtQueue3.Text) && string.IsNullOrEmpty(cmbPCC3.Text))
                {
                    MessageBox.Show(Resources.Constants.INGRESA_PCC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbPCC3.Focus();
                }
                else if (string.IsNullOrEmpty(cmbPicCode3.Text) && !string.IsNullOrEmpty(cmbPCC3.Text))
                {
                    MessageBox.Show(Resources.Constants.INGRESE_EL_PICCODE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbPicCode3.Focus();
                }
                else if (string.IsNullOrEmpty(txtQueue4.Text) && !string.IsNullOrEmpty(cmbPCC4.Text))
                {
                    MessageBox.Show(Resources.Constants.INGRESE_LA_QUEUE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQueue4.Focus();
                }
                else if (!string.IsNullOrEmpty(txtQueue4.Text) && string.IsNullOrEmpty(cmbPCC4.Text))
                {
                    MessageBox.Show(Resources.Constants.INGRESA_PCC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbPCC4.Focus();
                }
                else if (string.IsNullOrEmpty(cmbPicCode4.Text) && !string.IsNullOrEmpty(cmbPCC4.Text))
                {
                    MessageBox.Show(Resources.Constants.INGRESE_EL_PICCODE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbPicCode4.Focus();
                }
                else if (string.IsNullOrEmpty(txtQueue5.Text) && !string.IsNullOrEmpty(cmbPCC5.Text))
                {
                    MessageBox.Show(Resources.Constants.INGRESE_LA_QUEUE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQueue5.Focus();
                }
                else if (!string.IsNullOrEmpty(txtQueue5.Text) && string.IsNullOrEmpty(cmbPCC5.Text))
                {
                    MessageBox.Show(Resources.Constants.INGRESA_PCC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbPCC5.Focus();
                }
                else if (string.IsNullOrEmpty(cmbPicCode5.Text) && !string.IsNullOrEmpty(cmbPCC5.Text))
                {
                    MessageBox.Show(Resources.Constants.INGRESE_EL_PICCODE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbPicCode5.Focus();
                }
                else
                {
                    validation = true;
                }
                return validation;
            }
        }
        //Llenado de Combo PicCode
        private void ComboPicCode()
        {
            List<CatOnlineToolsPicCodes> listOnlineToolsPicCode = CatOnlineToolsPicCodesBL.GetPicCodes();
            bindingSource1.DataSource = listOnlineToolsPicCode;
            foreach (CatOnlineToolsPicCodes onlineToolsItem in listOnlineToolsPicCode)
            {
                ListItem litem = new ListItem();
                litem.Text = string.Format("{0} - {1}",
                onlineToolsItem.PicCode, onlineToolsItem.Description);
                litem.Value = onlineToolsItem.PicCode.ToString();
                cmbPicCode1.Items.Add(litem);
                cmbPicCode2.Items.Add(litem);
                cmbPicCode3.Items.Add(litem);
                cmbPicCode4.Items.Add(litem);
                cmbPicCode5.Items.Add(litem);
            }
        }
        //Llenado de Combo PCC
        private void ComboPCC()
        {
            List<AllPCCsComplet> listPCCs= AllPCCsCompletBL.GetAllPCCsComplet(Login.OrgId);
            bindingSource2.DataSource = listPCCs;
            foreach (AllPCCsComplet pccItem in listPCCs)
            {
                ListItem litem = new ListItem();
                litem.Text = string.Format("{0} - {1}",
                  pccItem.CatPccId, pccItem.CatPccName);
                litem.Value = pccItem.CatPccId;
                cmbPCC1.Items.Add(litem);
                cmbPCC2.Items.Add(litem);
                cmbPCC3.Items.Add(litem);
                cmbPCC4.Items.Add(litem);
                cmbPCC5.Items.Add(litem);
            }
        }

        private void cmbPicCodeGeneric_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblName1.Focus();
        }
    }
}
