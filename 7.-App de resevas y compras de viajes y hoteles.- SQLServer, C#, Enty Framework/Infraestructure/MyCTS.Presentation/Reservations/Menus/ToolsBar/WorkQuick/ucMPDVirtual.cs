using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Forms.UI;
using MyCTS.Entities;
using MyCTS.Business;

namespace MyCTS.Presentation
{
    public partial class ucMPDVirtual : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Se ingresan los cargos adicionales
        /// Creación:    15-Abril 10 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez 
        /// </summary>
        
        public ucMPDVirtual()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = cmbServices;
            this.LastControlFocus = btnAccept;
        }
        
        //Asigna el foco y el texto de una etiqueta
        private void ucMPDVirtual_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            cmbServices.Focus();
            lblMXNorKG.Text = "Tarifa MXN";
            LlenarCombo();
        }

        private void LlenarCombo()
        {
            List<ServicesMD> listService = ServiceMDBL.GetServiceMD();
            foreach (ServicesMD serviceItem in listService)
            {
                ListItem litem2 = new ListItem();
                litem2.Text = serviceItem.Service.ToString();
                litem2.Value = serviceItem.Service.ToString();
                cmbServices.Items.Add(litem2);
            }
        }
            



        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidBussinessRules)
            {
                CommandSend();
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
        }

        #region ====== Events ======

        ///KeyDown
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

       


        private void cmbServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbServices.Text == "Equipaje")
            {
                lblMXNorKG.Text = "Costo por KG";
                lblTicketorKilos.Text = "Kilos en Exceso";
                lblTicketorKilos.Visible = true;
                txtTicketorKilos.Visible = true;
            }
            else
            {
                lblMXNorKG.Text = "Tarifa MXN";
                lblTicketorKilos.Text = "Num.Boleto";
                lblTicketorKilos.Visible = true;
                txtTicketorKilos.Visible = true;
            }
        }

        private void rdoInternational_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoInternational.Checked)
            {
                ShowControls(true);
                txtMXNorKG.Focus();
                foreach (Control txt in this.Controls)
                {
                    if (txt is SmartTextBox && !txt.Enabled)
                        txt.BackColor = SystemColors.Control;
                    else if (txt is SmartTextBox && txt.Enabled)
                        txt.BackColor = Color.White;
                }
            }
        }

        private void rdoNational_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNational.Checked)
            {
                ShowControls(false);
                foreach (Control txt in this.Controls)
                {
                    if (txt is SmartTextBox && !txt.Enabled)
                        txt.BackColor = SystemColors.Control;
                    else if (txt is SmartTextBox && txt.Enabled)
                        txt.BackColor = Color.White;
                }
            }
        }

       
        #endregion

        #region====== Change Focus =====

        private void txtMXNorKG_TextChanged(object sender, EventArgs e)
        {
            if (txtMXNorKG.Text.Length > 7)
            {
                if (txtUSD.Enabled == true)
                    txtUSD.Focus();
                else
                    cmbTypeCard.Focus();
            }
        }
       
        private void txtUSD_TextChanged(object sender, EventArgs e)
        {
            if (txtUSD.Text.Length > 6)
                txtExchangeRate.Focus();
        }

        private void txtExchangeRate_TextChanged(object sender, EventArgs e)
        {
            if (txtExchangeRate.Text.Length > 8)
                txtIVA.Focus();
        }

        private void txtTicketorKilos_TextChanged(object sender, EventArgs e)
        {
            if (txtTicketorKilos.Text.Length > 12)
                cmbTypeCard.Focus();
        }

        private void txtIVA_TextChanged(object sender, EventArgs e)
        {
            if (txtIVA.Text.Length > 6)
            {
                if (txtTicketorKilos.Visible == true)
                    txtTicketorKilos.Focus();
                else
                    cmbTypeCard.Focus();
            }
        }
      

        private void txtNumberCard_TextChanged(object sender, EventArgs e)
        {
            if (txtNumberCard.Text.Length > 19)
                txtExpiration.Focus();
        }

        private void txtExpiration_TextChanged(object sender, EventArgs e)
        {
            if (txtExpiration.Text.Length > 19)
                txtIssuingBank.Focus();
        }


        private void txtIssuingBank_TextChanged(object sender, EventArgs e)
        {
            if (txtIssuingBank.Text.Length > 19)
                txtOffers.Focus();
        }

        private void txtOffers_TextChanged(object sender, EventArgs e)
        {
            if (txtOffers.Text.Length > 29)
                txtRequest.Focus();
        }

        private void txtRequest_TextChanged(object sender, EventArgs e)
        {
            if (txtRequest.Text.Length > 39)
                txtMail.Focus();
        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {
            if (txtMail.Text.Length > 39)
                btnAccept.Focus();
        }

        private void rdoExPostinDecimals_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                rdoInternational.Focus();
        }

        private void txtIVA3_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Tab)
            //    rdoCash.Focus();
        }
        private void rdoInternational_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                txtMXNorKG.Focus();
        }

        private void rdoCash_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                txtRequest.Focus();
        }

        #endregion

        #region ===== methodsClass =====

        private bool IsValidBussinessRules
        {
            get
            {
                bool isValid = false;
                if (!rdoNational.Checked && !rdoInternational.Checked)
                {
                    MessageBox.Show(Resources.Reservations.SELECCIONE_NACIONAL_INTERNACIONAL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rdoNational.Focus();
                }
                else if (string.IsNullOrEmpty(txtMXNorKG.Text) && lblMXNorKG.Text == "Tarifa MXN")
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_TARIFA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMXNorKG.Focus();
                }
                else if (string.IsNullOrEmpty(txtMXNorKG.Text) && lblMXNorKG.Text == "Costo por KG:")
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_COSTO_KG, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMXNorKG.Focus();
                }
                else if (string.IsNullOrEmpty(txtIVA.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGESE_IVA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIVA.Focus();
                }
                else if (txtUSD.Enabled == true && string.IsNullOrEmpty(txtUSD.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_TARIFA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUSD.Focus();
                }
                else if (txtExchangeRate.Enabled == true && string.IsNullOrEmpty(txtExchangeRate.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_TIPO_CAMBIO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtExchangeRate.Focus();
                }
                else if (cmbTypeCard.Text== string.Empty)
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_SELECCIONAR_FORMA_PAGO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbTypeCard.Focus();
                }
                else if (string.IsNullOrEmpty(txtNumberCard.Text) && 
                    txtNumberCard.Enabled==true)
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESE_TIPO_TARJETA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberCard.Focus();
                }
                else if (string.IsNullOrEmpty(txtExpiration.Text) &&
                    txtExpiration.Enabled==true)
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_VENCIMIENTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtExpiration.Focus();
                }
                else if (string.IsNullOrEmpty(txtIssuingBank.Text) &&
                    txtIssuingBank.Enabled==true)
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_CODIGO_SEGURIDAD, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIssuingBank.Focus();
                }
                else if (string.IsNullOrEmpty(txtRequest.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_QUIEN_SOLICITA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRequest.Focus();
                }
                else if (string.IsNullOrEmpty(txtMail.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_MAIL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMail.Focus();
                }
                else if (string.IsNullOrEmpty(txtTicketorKilos.Text) && 
                        txtTicketorKilos.Visible == true &&
                        cmbServices.Text == "Equipaje")
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_KILOS_EXCESO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTicketorKilos.Focus();
                }
                //else if (!string.IsNullOrEmpty(txtMXNorKG.Text) && 
                //         !ValidateRegularExpression.ValidateTwoDecimalNumbers(txtMXNorKG.Text))
                //{
                //    MessageBox.Show(Resources.Reservations.TARIFA_BASE_DEBE_TENER_DOS_DECIMALES, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtMXNorKG.Focus();
                //}
                //else if (!string.IsNullOrEmpty(txtIVA.Text) &&
                //         !ValidateRegularExpression.ValidateTwoDecimalNumbers(txtIVA.Text))
                //{
                //    MessageBox.Show(Resources.Reservations.IVA_DEBE_TENER_DOS_DECIMALES, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtIVA.Focus();
                //}
                //else if (!string.IsNullOrEmpty(txtTax1.Text) &&
                //         !ValidateRegularExpression.ValidateTwoDecimalNumbers(txtTax1.Text))
                //{
                //    MessageBox.Show(Resources.Reservations.IMPUESTO_DEBE_TENER_DOS_DECIMALES, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtTax1.Focus();
                //}
                //else if (!string.IsNullOrEmpty(txtTax2.Text) &&
                //        !ValidateRegularExpression.ValidateTwoDecimalNumbers(txtTax2.Text))
                //{
                //    MessageBox.Show(Resources.Reservations.IMPUESTO_DEBE_TENER_DOS_DECIMALES, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtTax2.Focus();
                //}
                //else if (!string.IsNullOrEmpty(txtUSD.Text) &&
                //        !ValidateRegularExpression.ValidateTwoDecimalNumbers(txtUSD.Text))
                //{
                //    MessageBox.Show(Resources.Reservations.TARIFA_USD_DEBE_TENER_DOS_DECIMALES, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtUSD.Focus();
                //}
                else if (!string.IsNullOrEmpty(txtExchangeRate.Text) &&
                        !ValidateRegularExpression.ValidateFourDecimalNumbers(txtExchangeRate.Text))
                {
                    MessageBox.Show("El tipo de cambio debe de tener cuatro decimales", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtExchangeRate.Focus();
                }
                else if (rdoInternational.Checked &&  cmbRate.Text == string.Empty)
                {
                    MessageBox.Show("Debe elegir un tipo de tarifa Internacional", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbRate.Focus();
                }
                //else if (!string.IsNullOrEmpty(txtNumberCard.Text) &&
                //         rdoAMEX.Checked &&
                //        txtNumberCard.Text.Length != 15)
                //{
                //    MessageBox.Show(Resources.Reservations.TARJETA_DEBE_TENER_15_DIGITOS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtNumberCard.Focus();
                //}
                //else if (!string.IsNullOrEmpty(txtNumberCard.Text) &&
                //        rdoCreditCard.Checked &&
                //        txtNumberCard.Text.Length != 16)
                //{
                //    MessageBox.Show(Resources.Reservations.TARJETA_DEBE_TENER_16_DIGITOS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtNumberCard.Focus();
                //}
                else
                {
                    isValid = true;
                }
                return isValid;
            }
        }

        private void CommandSend()
        {
            string format = string.Empty;
            string format1 = string.Empty;
            string sabre = string.Empty;

            format = "5H-";
            format1 = "5H-**FORMA DE PAGO-";

            format = string.Concat(format, "**", cmbServices.Text, "Σ5H-**TTL,MXN-", txtMXNorKG.Text,
                        ",IVA-", txtIVA.Text);

            if (rdoInternational.Checked)
            {
                format = string.Concat(format,"Σ5H-**TTL,", cmbRate.Text, "-", txtUSD.Text, ",TC-", txtExchangeRate.Text);
            }
            if (cmbTypeCard.Text == "EFECTIVO")
            {
                format1 = string.Concat(format1, cmbTypeCard.Text);
            }
            else if (cmbTypeCard.Text != "EFECTIVO")
            {
                format1 = string.Concat(format1, cmbTypeCard.Text, txtNumberCard.Text, ",VIG-", txtExpiration.Text);
            }
            else if(!string.IsNullOrEmpty(txtOffers.Text))
            {
                format1 = string.Concat(format1,"PROM-", txtOffers.Text);
            }
            if (!string.IsNullOrEmpty(txtTicketorKilos.Text) &&
                cmbServices.Text == "Equipaje")
            {
                format = string.Concat(format, "Σ5H-**KILOS EN EXCESO-",txtTicketorKilos.Text,"KG");
            }
            format1 = string.Concat(format1,"Σ5H-**SOLICITA-", txtRequest.Text,",", txtMail.Text);

            sabre = "QP/3L64182/11";
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(format);
                objCommand.SendReceive(format1);
                objCommand.SendReceive(sabre);
            }
        }

        private void ShowControls(bool show)
        {
            txtUSD.Enabled = show;
            txtExchangeRate.Enabled = show;
        }

        private void ShowControls1(bool show2)
        {
            txtNumberCard.Enabled = show2;
            txtExpiration.Enabled = show2;
            txtIssuingBank.Enabled = show2;
            txtOffers.Enabled = show2;
        }
 
        #endregion

        private void cmbTypeCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTypeCard.Text == "EFECTIVO")
            {
                ShowControls1(false);
            }
            else
            {
                ShowControls1(true);
            }
        }

        

    }
}
