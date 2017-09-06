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
    public partial class ucCode_Decode : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite  ver los diversos codigos que existen en Sabre,pertenece a Funciones Rápidas
        /// Creación:    Marzo-Abril 09 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        #region ====== Declaration of Variable ========ç

        public string send;
        private bool validatebusinessrules;
        private TextBox txt;

        #endregion 

        public ucCode_Decode()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = rdoAerline;
            this.LastControlFocus = btnAccept;
        }

        //User Control Load
        /// <summary>
        /// Al cargar el User Control se oculta el panel y se coloca
        /// el foco en el radio button de Aerolinea
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucCode_Decode_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            panel1.Visible = false;
            rdoAerline.Focus();
        }

        //Button Accept
        /// <summary>
        /// Se realizan las validaciones despues de que el usuario ingresa datos, 
        /// se mandan los comandos y termina el proceso llamando a otro User Control 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (rdoAerline.Checked)
            {
                ValidateBusinessRulesFromAerline();
                if (validatebusinessrules)
                {
                    CommandsSendFromAerline();
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
            }
            else if (rdoAirplane.Checked)
            {
                ValidateBusinessRulesFromAirplane();
                if (validatebusinessrules)
                {
                    CommandsSendFromAirplane();
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
            }
            else if (rdoDigitVerifier.Checked)
            {
                ValidateBusinessRulesFromDigitVerifier();
                if (validatebusinessrules)
                {
                    CommandsSendFromDigitVerifier();
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
            }
            else if (rdoDistanceAirports.Checked)
            {
                ValidateBusinessRulesFromDistanceAirports();
                if (validatebusinessrules)
                {
                    CommandsSendFromDistanceAirports();
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
            }
            else if (rdoNearCitiesAirport.Checked)
            {
                ValidateBusinessRulesFromNearCitiesAirport();
                if (validatebusinessrules)
                {
                    CommandsSendFromNearCitiesAirport();
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
            }
            else if (rdoAgreementsTKT.Checked)
            {
                ValidateBusinessRulesFromAgreementsTKT();
                if (validatebusinessrules)
                    CommandsSendFromAgreementsTKT();
            }
            else if (rdoAgreementsFF.Checked)
            {
                send = Resources.Constants.COMMANDS_PT_AST + txtOption.Text;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(send);
                }
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            else if (rdoAirportNearCities.Checked)
            {
                send = Resources.Constants.COMMANDS_W_SLASH_INDENT_CY + txtAirportNearCities.Text;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(send);
                }
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            else
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }

        //Button Advance Page
        /// <summary>
        /// Se manda un comando para avanzar la pagina 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdvancePag_Click(object sender, EventArgs e)
        {
            using (CommandsAPI objCommands = new CommandsAPI())
            {
                objCommands.SendReceive(Resources.Constants.COMMANDS_MD);
            }
        }

        //Button Return Page
        /// <summary>
        /// Se manda un comando para regresar la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturnPag_Click(object sender, EventArgs e)
        {
            using (CommandsAPI objCommands = new CommandsAPI())
            {
                objCommands.SendReceive(Resources.Constants.COMMANDS_MU);
            }
        }

        ///KeyDown
        /// <summary>
        /// Este se usa para todos los controles en general si se oprime 
        /// Esc se manda a el User control de Welcome 
        /// Enter se manda la accion de botón de Aceptar
        /// KeyDown se manda el foco al listBox
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
                if (lbGeneric.Items.Count > 0)
                {
                    lbGeneric.SelectedIndex = 0;
                    lbGeneric.Focus();
                }
            }
        }

        //KeyDown LbGeneric
        /// <summary>
        /// Esta función permite selccionar un elemento del listbox y 
        /// oculta el ListBox al momento de seleccionarlo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbGeneric_KeyDown(object sender, KeyEventArgs e)
        {
            ListBox ListBox = (ListBox)sender;
            TextBox txt = (TextBox)txtOption;

            if (e.KeyCode == Keys.Enter)
            {
                ListItem li = (ListItem)ListBox.SelectedItem;
                txt.Text = li.Value;
                lbGeneric.Visible = false;
                txt.Focus();
            }
        }


        //Mouse Click
        /// <summary>
        /// Esta función es para permitir el Clic sobre un elemento del ListBox
        /// para seleccional el item y oculata el listBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_MouseClick(object sender, MouseEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            TextBox txt = (TextBox)txtOption;
            ListItem li = (ListItem)listBox.SelectedItem;
            txt.Text = li.Value;
            lbGeneric.Visible = false;
            txt.Focus();
        }

        /// <summary>
        /// Esta función te permite cargar el ListBox de acuerdo a la
        /// opción seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOption_TextChanged(object sender, EventArgs e)
        {
            txt = (TextBox)sender;

            if (rdoBus.Checked)
                Common.SetListBoxBus(txt, lbGeneric);
            else if (rdoHotels.Checked)
                Common.SetListBoxHotels(txt, lbGeneric);
            else if (rdoCountry.Checked)
                Common.SetListBoxCountries(txt, lbGeneric);
            else if (rdoCreditCard.Checked)
                Common.SetListBoxCreditCards(txt, lbGeneric);
            else if (rdoLineCruices.Checked)
                Common.SetListBoxSeaVendors(txt, lbGeneric);
            else if (rdoStatusCode.Checked)
                Common.SetListBoxStatusCodes(txt, lbGeneric);
            else if (rdoStates.Checked)
                Common.SetListBoxStatesUSA(txt, lbGeneric);
            else if (rdoCurrencies.Checked)
                Common.SetListBoxCurrenciesCountries(txt, lbGeneric);
            else if (rdoClassService.Checked)
                Common.SetListBoxLineClasses(txt, lbGeneric);
            else if (rdoCity.Checked)
                Common.SetListBoxCities(txt, lbGeneric);
            else if (rdoEatAir.Checked)
                Common.SetListBoxMealCodes(txt, lbGeneric);
            else if (rdoAirpot.Checked)
                Common.SetListBoxAirports(txt, lbGeneric);
            else if (rdoAgreementsFF.Checked)
                Common.SetListBoxAirlines(txt, lbGeneric);
            else if (rdoTypeCard.Checked)
                Common.SetListBoxCarTypeCodes(txt, lbGeneric);
            else if (rdoEquipment.Checked)
                Common.SetListBoxCarEquipmentCodes(txt, lbGeneric);
            else if (rdoVendorsCode.Checked)
                Common.SetListBoxCarVendorsCodes(txt, lbGeneric);
        }

        #region ========= Change Focus ===========

        /// <summary>
        /// Cambia el control de los focos de acuerdo al length de cada control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        private void txtAgreements1_TextChanged(object sender, EventArgs e)
        {
            if (txtAgreements1.Text.Length > 2)
                txtAgreements2.Focus();
        }

        private void txtAgreements2_TextChanged(object sender, EventArgs e)
        {
            if (txtAgreements2.Text.Length > 2)
                btnAccept.Focus();
        }

        private void txtAirportNearCities_TextChanged(object sender, EventArgs e)
        {
            if (txtAirportNearCities.Text.Length > 19)
                btnAccept.Focus();
        }

        #endregion

        #region===== Hide Box ======

        /// <summary>
        /// Muestra y oculta controles de acurdo a las opciones elegidad por el ususario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void rdoDistanceAirports_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDistanceAirports.Checked)
                panel1.Visible = false;
                lbGeneric.Visible = false; txtOption.Visible = false; 
            txtOption.Visible = false;
            txtAirportNearCities.Visible = false;
            txtAgreements1.Text = string.Empty;
            txtAgreements2.Text = string.Empty;
            txtAgreements1.Visible = true;
            txtAgreements2.Visible = true;
            txtAgreements1.Focus();
            lblComment.Visible = true;
            lblComment.Text = "Ingresar";
            lblOrigin.Text = "Origen";
            lblOrigin.Visible = true;
            lblDestiny.Visible = true;
            rdoEquipment.Visible = false;
            rdoVendorsCode.Visible = false;
            rdoTypeCard.Visible = false;
            btnAdvancePag.Visible = false;
            btnReturnPag.Visible = false;
        }

        private void rdoNearCitiesAirport_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNearCitiesAirport.Checked)
                panel1.Visible = false;
            txtAirportNearCities.Visible = false;
                lbGeneric.Visible = false;
            txtOption.Visible = false;
            txtAgreements2.Visible = false;
            txtAgreements1.Text = string.Empty;
            txtAgreements1.Visible = true;
            txtAgreements1.Focus();
            lblComment.Visible = true;
            lblComment.Text = "Ingresar";
            lblOrigin.Text = "Codigo de Ciudad";
            lblOrigin.Visible = true;
            lblDestiny.Visible = false;
            rdoEquipment.Visible = false;
            rdoVendorsCode.Visible = false;
            rdoTypeCard.Visible = false;
            btnAdvancePag.Visible = false;
            btnReturnPag.Visible = false;
        }

        private void rdoAgreementsTKT_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAgreementsTKT.Checked)
                panel1.Visible = false;
                lbGeneric.Visible = false; 
            txtOption.Visible = false;
            txtAirportNearCities.Visible = false;
            txtAgreements2.Visible = false;
            txtAgreements1.Text = string.Empty;
            txtAgreements1.Visible = true;
            txtAgreements1.Focus();
            lblComment.Visible = true;
            lblComment.Text = "Ingresa";
            lblOrigin.Text = "Código Aerolinea";
            lblOrigin.Visible = true;
            lblDestiny.Visible = false;
            rdoEquipment.Visible = false;
            rdoVendorsCode.Visible = false;
            rdoTypeCard.Visible = false;
            btnAdvancePag.Visible = true;
            btnReturnPag.Visible = true;
        }

        private void rdoAirportNearCities_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNearCitiesAirport.Checked)
                panel1.Visible = false;
            lbGeneric.Visible = false;
            txtOption.Visible = false;
            txtAgreements2.Visible = false;
            txtAgreements1.Text = string.Empty;
            txtAgreements1.Visible = false;
            txtAirportNearCities.Visible = true;
            txtAirportNearCities.Text = string.Empty;
            txtAirportNearCities.Focus();
            lblComment.Visible = true;
            lblComment.Text = "Ingresar";
            lblOrigin.Text = "Nombre de Ciudad";
            lblOrigin.Visible = true;
            lblDestiny.Visible = false;
            rdoEquipment.Visible = false;
            rdoVendorsCode.Visible = false;
            rdoTypeCard.Visible = false;
            btnAdvancePag.Visible = false;
            btnReturnPag.Visible = false;
        }

        #endregion

        #region ===== Show Box =====

        /// <summary>
        /// Muestra y oculta controles de acurdo a las opciones elegidad por el ususario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowTextBox_CheckedChanged(object sender, EventArgs e)
        {
            txtOption.Text = string.Empty;
            txtAirportNearCities.Visible = false;
            panel1.Visible = false;
            rdoTypeCard.Visible = false;
            rdoVendorsCode.Visible = false;
            rdoEquipment.Visible = false;
            lbGeneric.Visible = false;
            txtAgreements1.Visible = false;
            txtAgreements2.Visible = false;
            btnAdvancePag.Visible = false;
            btnReturnPag.Visible = false;
            txtOption.Visible = true;
            txtOption.Focus();
            lblDestiny.Visible = true;
            lblOrigin.Visible = false;
            lblDestiny.Visible = false;
            lblComment.Visible = true;

            if (rdoAerline.Checked)
                lblComment.Text = "Ingresa el código de Aerolinea o nombre";
            else if (rdoAirplane.Checked)
                lblComment.Text = "Ingresa el código de Avión";
            else if (rdoEatAir.Checked)
                lblComment.Text = "Ingresa el código de Comida o nombre";
            else if (rdoAirpot.Checked)
                lblComment.Text = "Ingresa el código de Aeropuerto o nombre";
            else if (rdoBus.Checked)
                lblComment.Text = "Ingresa el código de Autobus o nombre";
            else if (rdoDigitVerifier.Checked)
                lblComment.Text = "Ingresa número de boleto con aerolínea";
            else if (rdoCity.Checked)
                lblComment.Text = "Ingresa el código de Ciudad o nombre";
            else if (rdoClassService.Checked)
                lblComment.Text = "Ingresa el código de Clase o nombre";
            else if (rdoCountry.Checked)
                lblComment.Text = "Ingresa el código de País o nombre";
            else if (rdoCreditCard.Checked)
                lblComment.Text = "Ingresa el código de Tarjeta o nombre";
            else if (rdoHotels.Checked)
                lblComment.Text = "Ingresa el código de Hotel o nombre";
            else if (rdoLineCruices.Checked)
                lblComment.Text = "Ingresa el código de Naviera o nombre";
            else if (rdoStates.Checked)
                lblComment.Text = "Ingresa el código de Estado o nombre (USA)";
            else if (rdoStatusCode.Checked)
                lblComment.Text = "Ingresa el código de Estatus o nombre";
            else if (rdoCurrencies.Checked)
                lblComment.Text = "Ingresa el código de Moneda o nombre";
            else if (rdoAgreementsFF.Checked)
                lblComment.Text = "Ingresa";
        }
        
        #endregion

        #region ===== methodsClass =====

        /// <summary>
        /// Se validan que existan los datos que son obligatorios y que 
        /// sean los datos correctos
        /// </summary>
        private void ValidateBusinessRulesFromAerline()
        {
            validatebusinessrules = true;
            if (string.IsNullOrEmpty(txtOption.Text) |
                    txtOption.Text.Length == 1)
            {
                MessageBox.Show(Resources.Reservations.NECESITA_INGRESAR_2_CARAC_MIN, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOption.Focus();
                validatebusinessrules = false;
            }
        }

        /// <summary>
        /// Se validan que existan los datos que son obligatorios y que 
        /// sean los datos correctos
        /// </summary>
        private void ValidateBusinessRulesFromAirplane()
        {
            validatebusinessrules = true;

            if (string.IsNullOrEmpty(txtOption.Text) |
                    txtOption.Text.Length <= 2)
            {
                MessageBox.Show(Resources.Reservations.NECESITA_INGRESAR_3_CARAC_MIN, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOption.Focus();
                validatebusinessrules = false;
            }
        }

        /// <summary>
        /// Se validan que existan los datos que son obligatorios y que 
        /// sean los datos correctos
        /// </summary>
        private void ValidateBusinessRulesFromDigitVerifier()
        {
            validatebusinessrules = true;

            if (string.IsNullOrEmpty(txtOption.Text) | txtOption.Text.Length <= 9)
            {
                MessageBox.Show(Resources.Reservations.NECESITA_INGRESAR_10_CARAC_MIN, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOption.Focus();
                validatebusinessrules = false;
            }
        }

        /// <summary>
        /// Se validan que existan los datos que son obligatorios y que 
        /// sean los datos correctos
        /// </summary>
        private void ValidateBusinessRulesFromDistanceAirports()
        {
            validatebusinessrules = true;
            if ((txtAgreements1.Text.Length <= 2 | txtAgreements2.Text.Length <= 2) |
                   (string.IsNullOrEmpty(txtAgreements1.Text) |
                   string.IsNullOrEmpty(txtAgreements2.Text)))
            {
                MessageBox.Show(Resources.Reservations.NECESITA_INGRESAR_3_CARAC_MIN, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAgreements1.Focus();
                validatebusinessrules = false;
            }
        }

        /// <summary>
        /// Se validan que existan los datos que son obligatorios y que 
        /// sean los datos correctos
        /// </summary>
        private void ValidateBusinessRulesFromNearCitiesAirport()
        {
            validatebusinessrules = true;

            if (string.IsNullOrEmpty(txtAgreements1.Text) | txtAgreements1.Text.Length <= 2)
            {
                MessageBox.Show(Resources.Reservations.NECESITA_INGRESAR_3_CARAC_MIN, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAgreements1.Focus();
                validatebusinessrules = false;
            }
        }

        /// <summary>
        /// Se validan que existan los datos que son obligatorios y que 
        /// sean los datos correctos
        /// </summary>
        private void ValidateBusinessRulesFromAgreementsTKT()
        {
            validatebusinessrules = true;

            if (string.IsNullOrEmpty(txtAgreements1.Text) |
                   txtAgreements1.Text.Length == 1)
            {
                MessageBox.Show(Resources.Reservations.NECESITA_INGRESAR_2_CARACTERES, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAgreements1.Focus();
                validatebusinessrules = false;
            }
            else if (txtAgreements1.Text.Length != 2)
            {
                MessageBox.Show(Resources.Reservations.NECESITA_INGRESAR_2_CAR_MAX, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAgreements1.Focus();
                validatebusinessrules = false;
            }
        }

        /// <summary>
        /// Se envia el comando de acuerdo a los campos ingresados
        /// </summary>
        private void CommandsSendFromAerline()
        {
            if (txtOption.Text.Length == 1 | txtOption.Text.Length == 2)
            {
                send = Resources.Constants.COMMANDS_W_SLASH_AST + txtOption.Text;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(send);
                }
            }
            else
            {
                send = Resources.Constants.COMMADS_W_SLASH_INDENT_AL + txtOption.Text;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(send);
                }
            }
        }

        /// <summary>
        /// Se envia el comando de acuerdo a los campos ingresados
        /// </summary>
        private void CommandsSendFromAirplane()
        {
            send = Resources.Constants.COMMANDS_W_SLASH_EQ_AST + txtOption.Text;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }

        /// <summary>
        /// Se envia el comando de acuerdo a los campos ingresados
        /// </summary>
        private void CommandsSendFromDigitVerifier()
        {
            if (txtOption.Text.Length >= 10 && txtOption.Text.Length <= 13)
            {
                send = Resources.Constants.COMMANDS_W_SLASH_TATKT + txtOption.Text;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(send);
                }
            }
        }

        /// <summary>
        /// Se envia el comando de acuerdo a los campos ingresados
        /// </summary>
        private void CommandsSendFromDistanceAirports()
        {
            send = Resources.Constants.COMMANDS_W_SLASH_INDENT_AT + txtAgreements1.Text + 
                    Resources.Constants.COMMANDS_CROSSLORAINE_AT + txtAgreements2.Text;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }

        /// <summary>
        /// Se envia el comando de acuerdo a los campos ingresados
        /// </summary>
        private void CommandsSendFromNearCitiesAirport()
        {
            send = Resources.Constants.COMMANDS_W_SLASH_INDENT_AT + 
                    txtAgreements1.Text;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }

        /// <summary>
        /// Se envia el comando de acuerdo a los campos ingresados
        /// </summary>
        private void CommandsSendFromAgreementsTKT()
        {
            if (txtAgreements1.Text.Length == 2)
            {
                send = Resources.Constants.COMMANDS_WETP_AST + txtAgreements1.Text;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(send);
                }
            }
        }
    
        #endregion

        #region ======= Change Focus of Radious =======

        /// <summary>
        /// En estas funciones se hace el cambio del nombre de las etiquetas 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoVendorsCode_CheckedChanged(object sender, EventArgs e)
        {
            txtOption.Text = string.Empty;
            txtOption.Focus();
            lblComment.Visible = true;
            lblComment.Text = "Ingresa código de Arrendadora o nombre";
        }

        private void rdoTypeCard_CheckedChanged(object sender, EventArgs e)
        {
            txtOption.Text = string.Empty;
            txtOption.Focus();
            lblComment.Visible = true;
            lblComment.Text = "Ingresa código de Tipo de Auto o nombre";
        }

        private void rdoEquipment_CheckedChanged(object sender, EventArgs e)
        {
            txtOption.Text = string.Empty;
            txtOption.Focus();
            lblComment.Visible = true;
            lblComment.Text = "Ingresa código de Equipamento o nombre";
        }

        /// <summary>
        /// En esta función se activan y desactivan controles de acuerdo a las 
        /// opciones elegidas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoAutomobile_CheckedChanged(object sender, EventArgs e)
        {
            rdoVendorsCode.Checked = false;
            rdoTypeCard.Checked = false;
            rdoEquipment.Checked = false;
            txtAirportNearCities.Visible = false;
            btnAdvancePag.Visible = false;
            btnReturnPag.Visible = false;
            panel1.Visible = true;
            lblComment.Visible = false;
            rdoEquipment.Visible = true;
            rdoVendorsCode.Visible = true;
            rdoTypeCard.Visible = true;
            lbGeneric.Visible = false;
            txtAgreements1.Visible = false;
            txtAgreements2.Visible = false;
            txtOption.Visible = true;
            txtOption.Text = string.Empty;
            txtOption.Focus();
            lblDestiny.Visible = false;
            lblOrigin.Visible = false;
            lblDestiny.Visible = false;
        }

        #endregion
    }
}
