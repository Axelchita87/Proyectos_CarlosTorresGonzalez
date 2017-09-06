using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;


namespace MyCTS.Presentation
{
    public partial class ucCostCenter : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite ingresar el Centro de Costos,el departamento, la división, y el área,pertenece a Emitir Boleto
        /// Creación:    6/Mayo/09 , Modificación:7/Julio/09
        /// Cambio:      Cambiar Predictivo , Solicito Eduardo
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        #region ======= Variable Static =======

        private static string costcenterprevious;
        public static string CostCenterPrevious
        {
            get { return costcenterprevious; }
            set { costcenterprevious = value; }
        }

        private static string costcenter;
        public static string CostCenter
        {
            get { return costcenter; }
            set { costcenter = value; }
        }

        private string Corporative;
        string send;

        #endregion 

        public ucCostCenter()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtCostCenter;
            this.LastControlFocus = btnAccept;
        }

        //Load User Control
        /// <summary>
        /// Extraemos el Coorporativo de acuerdo a el se realizan ciertas 
        /// instrucciones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucCostCenter_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            Corporative = activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1;
            if (Corporative.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_RADIUS))
            {
                costcenterprevious = string.Empty;
                costcenter = string.Empty;
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCBILLINGADRESS);
            }
            if (Corporative == Resources.TicketEmission.Constants.CORPORATIVE_CFE)
            {
                ShowLine();
                txtCostCenter.Focus();
            }
            else
                txtCostCenter.Focus();
        }

        //Button Accept
        /// <summary>
        /// Se realizan las validaciones despues de que el usuario ingresa datos, 
        /// se mandan los comandos y termina el proceso llamando a otro User Control 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAcept_Click(object sender, EventArgs e)
        {
            CommandsSendPrevius();
            if (txtDate1.Visible)
            {
                send = string.Empty;
                CommandsVisibleText();
            }
            else
                costcenter = string.Empty;
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCBILLINGADRESS);
        }

        //KeyDown
        /// <summary>
        /// Si oprimen Esc. Primero extraemos los controles de calidad para saber que user Control se va activar
        /// de acuerdo a que controles de calidad se encuentren activos.
        /// Si oprimen Enter se va a la función del clic del boton Aceptar
        /// Si oprimen Down mostrara el ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                string chargePerService = activeStepsCorporativeQC.CorporativeQualityControls[0].ChargePerService;
                string FareSoldJustification = activeStepsCorporativeQC.CorporativeQualityControls[0].FareJustification;
                if (chargePerService.Equals(Resources.TicketEmission.Constants.ACTIVE))
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_CHARGESERVICE);
                else if (FareSoldJustification.Equals(Resources.TicketEmission.Constants.ACTIVE))
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_FARE_SOLD_JUSTIFICATION);
                else
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            if (e.KeyData == Keys.Enter)
                btnAcept_Click(sender, e);
            if (e.KeyCode == Keys.Down)
            {
                if (lbCostCenter.Items.Count > 0)
                {
                    lbCostCenter.SelectedIndex = 0;
                    lbCostCenter.Focus();
                }
            }
        }

        //KeyDown lbCostCenter
        /// <summary>
        /// Oculta el ListBox  al darle enter y seleccionando un Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbCostCenter_KeyDown(object sender, KeyEventArgs e)
        {
            ListBox ListBox = (ListBox)sender;
            TextBox txt = (TextBox)txtCostCenter;
            if (e.KeyCode == Keys.Enter)
            {
                ListItem li = (ListItem)ListBox.SelectedItem;
                txt.Text = li.Value;
                lbCostCenter.Visible = false;
                txt.Focus();
            }
        }

        //MouseClick LbCostCenter
        /// <summary>
        /// Oculta el ListBox  al darle clic y seleccionando un Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_MouseClick(object sender, MouseEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            TextBox txt = (TextBox)txtCostCenter;
            ListItem li = (ListItem)listBox.SelectedItem;
            txt.Text = li.Value;
            lbCostCenter.Visible = false;
            txt.Focus();
        }

        #region ====== Change Focus =======

        /// <summary>
        /// Se llena el ListBox con los datos del archivo plano generado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCostCenter_TextChanged(object sender, EventArgs e)
        {
          TextBox txt = (TextBox)sender;
           Common.SetListCostCenter(txt, lbCostCenter);
        }

        private void txtDepartment_TextChanged(object sender, EventArgs e)
        {
            if (txtDepartment.Text.Length > 9)
                txtDivision.Focus();
        }

        private void txtDivision_TextChanged(object sender, EventArgs e)
        {
            if (txtDivision.Text.Length > 9)
                txtArea.Focus();
        }

        private void txtArea_TextChanged(object sender, EventArgs e)
        {
            if (txtArea.Text.Length > 9)
                btnAccept.Focus();
        }

        private void txtDate1_TextChanged(object sender, EventArgs e)
        {
            if (txtDate1.Text.Length > 19)
                txtDate2.Focus();
        }

        private void txtDate2_TextChanged(object sender, EventArgs e)
        {
            if (txtDate2.Text.Length > 9)
                txtDate3.Focus();
        }

        private void txtDate3_TextChanged(object sender, EventArgs e)
        {
            if (txtDate3.Text.Length > 9)
                txtDate4.Focus();
        }

        private void txtDate4_TextChanged(object sender, EventArgs e)
        {
            if (txtDate4.Text.Length > 9)
                btnAccept.Focus();
        }

        #endregion 

        #region ===== methodsClass =====

        /// <summary>
        /// Se hace el armado del comando de acuerdo a los campos ingresados
        /// por el usuario estos son los 4 controles que estan visibles por default
        /// </summary>
        private void CommandsSendPrevius()
        {
            send = Resources.TicketEmission.Constants.COMMANDS_5_CC_INDENT;
            if (!string.IsNullOrEmpty(txtCostCenter.Text))
            {
                send = string.Concat(send, txtCostCenter.Text, 
                    Resources.TicketEmission.Constants.INDENT);
            }
            else
            {
                send = string.Concat(send, Resources.TicketEmission.Constants.COMMANDS_ZERO,
                    Resources.TicketEmission.Constants.INDENT);
            }
            if (!string.IsNullOrEmpty(txtDepartment.Text))
            {
                send = string.Concat(send, txtDepartment.Text,
                    Resources.TicketEmission.Constants.INDENT);
            }
            else
            {
                send = string.Concat(send, Resources.TicketEmission.Constants.COMMANDS_ZERO,
                    Resources.TicketEmission.Constants.INDENT);
            }
            if (!string.IsNullOrEmpty(txtDivision.Text))
            {
                send = string.Concat(send,txtDivision.Text,
                    Resources.TicketEmission.Constants.INDENT);
            }
            else
            {
                send = string.Concat(send,Resources.TicketEmission.Constants.COMMANDS_ZERO,
                    Resources.TicketEmission.Constants.INDENT);
            }
            if (!string.IsNullOrEmpty(txtArea.Text))
                send = string.Concat(send, txtArea.Text);
            else
            {
                send = string.Concat(send,
                    Resources.TicketEmission.Constants.COMMANDS_ZERO);
            }
            costcenterprevious = send;
        }

        /// <summary>
        /// Se arma el comando de acuerdo a los datos ingresados por el usuario
        /// Estos son para los 4 controles restantes 
        /// </summary>
        private void CommandsVisibleText()
        {
            send = Resources.TicketEmission.Constants.COMMANDS_5_CD_INDENT;
            if (!string.IsNullOrEmpty(txtDate1.Text))
            {
                send = string.Concat(send, txtDate1.Text,
                    Resources.TicketEmission.Constants.INDENT);
            }
            else
                send = string.Concat(send, Resources.TicketEmission.Constants.COMMANDS_ZERO);
            if (!string.IsNullOrEmpty(txtDate2.Text))
            {
                send = string.Concat(send, txtDate2.Text,
                    Resources.TicketEmission.Constants.INDENT);
            }
            else
                send = string.Concat(send, Resources.TicketEmission.Constants.Zero);
            if (!string.IsNullOrEmpty(txtDate3.Text))
            {
                send = string.Concat(send, txtDate3.Text,
                    Resources.TicketEmission.Constants.INDENT);
            }
            else
            {
                send = string.Concat(send,Resources.TicketEmission.Constants.INDENT,
                    Resources.TicketEmission.Constants.Zero);
            }
            if (!string.IsNullOrEmpty(txtDate4.Text))
                send = string.Concat(send, txtDate4.Text);
            else
            {
                send = string.Concat(send, Resources.TicketEmission.Constants.INDENT,
                    Resources.TicketEmission.Constants.Zero);
            }
            costcenter = send;
        }

        /// <summary>
        /// Muestra los controles 
        /// </summary>
        private void ShowLine()
        {
            txtDate1.Visible = true;
            txtDate2.Visible = true;
            txtDate3.Visible = true;
            txtDate4.Visible = true;
            lblDate1.Visible = true;
            lblDate2.Visible = true;
            lblDate3.Visible = true;
            lblDate4.Visible = true;
        }
     
        #region ===== Preparate Combo =======
        //private void commandsSend()
        //{
        //    if (cmbCostCenter.SelectedIndex >= 1)
        //    {
        //        ListItem item = (ListItem)cmbCostCenter.SelectedItem;
        //        costCenter = item.Value;
        //    }
        //    else
        //    {
        //        costCenter = cmbCostCenter.Text;
        //        //CharacterCasing.Upper.ToString(costCenter);
        //    }

        //    send = Resources.TicketEmission.Constants.COMMANDS_5_CC_INDENT + costCenter;
        //    using (CommandsAPI objCommands = new CommandsAPI())
        //    {
        //       objCommands.SendReceive(send);
        //    }

        //}
        //private void fillComboBox()
        //{
        //    List<CatCostCenter> listCatCostCenter = CatCostCenterBL.GetCostCenters(ucFirstValidations.DK , txtCostCenter.Text);
        //    bindingSource1.DataSource = listCatCostCenter;

        //    foreach (CatCostCenter costcenterItem in listCatCostCenter)
        //    {
        //        ListItem litem = new ListItem();
        //        litem.Text = string.Format("{0}-{1}", costcenterItem.IDCC, costcenterItem.CCName);
        //        litem.Value = costcenterItem.IDCC;
        //        lbCostCenter.Items.Add(litem);
        //    }

        //}
        #endregion

        #endregion












    }
}
