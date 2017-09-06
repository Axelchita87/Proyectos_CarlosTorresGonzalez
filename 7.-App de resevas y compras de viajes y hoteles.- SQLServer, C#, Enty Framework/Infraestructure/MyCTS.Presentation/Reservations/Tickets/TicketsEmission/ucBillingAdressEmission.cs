using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;
using MyCTS.Services.Contracts;
using MyCTS.Forms.UI;
using MyCTS.Services.ValidateDKsAndCreditCards;

namespace MyCTS.Presentation
{
    public partial class ucBillingAdressEmission : CustomUserControl
    {

        /// <summary>
        /// Descripcion: Permite ingresar la dirección de Facturación,pertenece a Emitir Boleto
        /// Creación:    2/Junio/09 , Modificación:31-Agosto-2010
        /// Cambio:      Cambiar comando en el envio de Razon social- 
        /// Cambiar num int-ext a Alfanumerico y poner tooltip de RFC Generico
        /// Extraer la información mandando */ para colocar los datos en los textbox
        /// Solicito: Guillermo-Pablo, Guillermo
        /// Autor:      Jessica Gutierrez 
        /// </summary>

        #region ====== Declaration of Variables ======

        public static string addAdress;
        public static string descripcionExtend;

        private TextBox txtSender;
        public static string result;
        public static string ren;
        public static string ren1;
        public static string ren2;
        public static string ren3;
        public static string ren4;
        public static string ren5;
        public static string ren6;
        public static string send;
        public static string socialReason;
        public static string street;
        public static string numberExt;
        public static string numberInt;
        public static string delegation;
        public static string city;
        public static string colony;
        public static string state;
        public static string cp;
        public static string rfc1;
        public static string rfc2;
        public static string rfc3;
        public static string description1;
        public static string description2;
        public static bool validatebusinessRules;
        public bool main;
        private string dk;
        private bool endreservation;
        private static bool isMexCountry = false;
        public static bool isRemarks = false;
        string option;
        public static bool billingAdress = false;
        public static string country = string.Empty;

        List<string> remarkNumber = new List<string>();
        public static string sabreConcat = string.Empty;
        private static string sabreResult;
        private string sabreAnswer = string.Empty;
        public static string Sabre;

        private static string c43;
        public static string C43
        {
            get { return c43; }
            set { c43 = value; }
        }

        private static string c44;
        public static string C44
        {
            get { return c44; }
            set { c44 = value; }
        }

        private static string c45;
        public static string C45
        {
            get { return c45; }
            set { c45 = value; }
        }

        private static string c46;
        public static string C46
        {
            get { return c46; }
            set { c46 = value; }
        }

        private static string c47;
        public static string C47
        {
            get { return c47; }
            set { c47 = value; }
        }

        private static string c48;
        public static string C48
        {
            get { return c48; }
            set { c48 = value; }
        }

        private static string c49;
        public static string C49
        {
            get { return c49; }
            set { c49 = value; }
        }


        public static string InterJetBillAddress
        {
            get
            {
                return send;
            }
        }

        #endregion

        public ucBillingAdressEmission()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            InitialControlFocus = txtSocialReason;
            LastControlFocus = btnAcept;
        }

        private InterJetProcessObserver _processObserver;

        /// <summary>
        /// Gets the process observer.
        /// </summary>
        private InterJetProcessObserver ProcessObserver
        {
            get
            {
                return _processObserver ?? (_processObserver = new InterJetProcessObserver
                {
                    UserControl = this

                });
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="msg">A <see cref="T:System.Windows.Forms.Message"/>, passed by reference, that represents the window message to process.</param>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys"/> values that represents the key to process.</param>
        /// <returns>
        /// true if the character was processed by the control; otherwise, false.
        /// </returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (ProcessObserver.HandleEvent(ref msg, keyData))
            {
                return true;

            }

            return base.ProcessCmdKey(ref msg, keyData);
        }



        /// <summary>
        /// Se extrae el DK, este User Control solo se aplica para los 990
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucBillingAdressEmission_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtRFC1, "RFC Generico XAXX010101000");
            toolTip1.SetToolTip(txtRFC2, "RFC Generico XAXX010101000");
            toolTip1.SetToolTip(txtRFC3, "RFC Generico XAXX010101000");
            ClearRemarksIntegraValues();
            dk = ucFirstValidations.DK;
            if (!string.IsNullOrEmpty(dk))
            {
                dk = dk.Substring(3, 3);
                if (dk != Resources.TicketEmission.ValitationLabels.NUMBER_990)
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_QUALITIES_BY_PAX);
                else
                {
                    if (SearchRemarks)
                    {
                        CopyAdress();
                        BucleFindEndScroll();
                        isRemarks = true;
                    }
                    else
                    {
                        try
                        {
                            ExistAndLoadLocationInformation();
                        }
                        catch
                        {
                            ExistLoadLocationInfoBackup();
                        }
                    }
                }
            }

            if (string.IsNullOrEmpty(txtRFC1.Text))
            {
                txtRFC1.Text = "XAXX";
                txtRFC2.Text = "010101";
                txtRFC3.Text = "000";
            }

            txtSocialReason.Focus();
        }

        private bool IsVolaris
        {
            get { return (this.Parameter != null && Parameter is VolarisReservation); }
        }

        public static bool IsVolarisStaticFlag { get; set; }

        private void btnAcept_Click(object sender, EventArgs e)
        {
            if (IsValidateBusinessRules)
            {
                socialReason = txtSocialReason.Text;
                street = txtStreet.Text;
                numberExt = txtNumberExt.Text;
                numberInt = txtNumberInt.Text;
                delegation = txtDelegation.Text;
                city = txtCity.Text;
                colony = txtColony.Text;
                state = txtState.Text;
                cp = txtCP.Text;
                rfc1 = txtRFC1.Text;
                rfc2 = txtRFC2.Text;
                rfc3 = txtRFC3.Text;
                description1 = txtDescription1.Text;
                description2 = txtDescription2.Text;
                country = txtCountry.Text;

                if (VolarisSession.IsVolarisProcess)
                {
                    IsVolarisStaticFlag = true;
                }

                if (Parameter is InterJetSession)
                {
                    InterJetStaticFlag = true;
                    if (isRemarks)
                        Remarks();

                    commandsBuild();
                }
                else
                {
                    if (isRemarks)
                        Remarks();
                }

                if (!SendCommandsBuild())
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.WARNING___PNR_MODIFICATION_IN_PROGRESS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                    return;
                }

                if (!ucAvailability.IsInterJetProcess && !VolarisSession.IsVolarisProcess)
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_QUALITIES_BY_PAX);
                }
                else
                {
                    if (VolarisSession.IsVolarisProcess)
                    {

                        //var reservation = (VolarisReservation)this.Parameter;// preguntar a LUIS
                        string billingAddresRemark = RemarksOfBillingAddres;
                        VolarisSession.Remarks = new VolarisRemarks();
                        VolarisSession.Remarks.Add(billingAddresRemark);
                        //reservation.Remarks.Add(billingAddresRemark);
                        IsVolarisStaticFlag = false;
                        RemarksOfBillingAddres = string.Empty;
                        Loader.AddToPanel(Loader.Zone.Middle, this, "ucAllQualityControls");
                    }
                    else if (ucAvailability.IsInterJetProcess)
                    {
                        if (Parameter is InterJetSession)
                        {

                            var session = (InterJetSession)Parameter;
                            if (session.Session.ContainsKey("CurrentTicket"))
                            {
                                var ticket = (InterJetTicket)session.Session["CurrentTicket"];
                                string billingAddresRemark = RemarksOfBillingAddres;
                                ticket.Remarks.Add(billingAddresRemark);
                            }
                        }
                        InterJetStaticFlag = false;
                        RemarksOfBillingAddres = string.Empty;
                        ucMenuReservations.ChargeService = false;

                        Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucAllQualityControls", Parameter,
                                                        Parameters);
                    }

                }
            }
        }


        //KeyDown
        /// <summary>
        /// Si oprimen Esc. Primero extraemos los controles de calidad para saber que user Control se va activar
        /// de acuerdo a que controles de calidad se encuentren activos.
        /// Si oprimen Enter se va a la función del clic del boton Aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            if (e.KeyData == Keys.Enter)
                btnAcept_Click(sender, e);
        }

        #region ======== Change Focus ========

        private void txtSocialReason_TextChanged(object sender, EventArgs e)
        {
            if (txtSocialReason.Text.Length == 65)
            {
                txtStreet.Focus();
                ErrorProvider error = new ErrorProvider();
                error.SetError(txtSocialReason, "Si tu razón social es mayor, deberás solicitar la alta del DK");
            }
        }

        private void txtStreet_TextChanged(object sender, EventArgs e)
        {
            if (txtStreet.Text.Length > 20)
                txtNumberExt.Focus();
        }

        private void txtNumberExt_TextChanged(object sender, EventArgs e)
        {
            if (txtNumberExt.Text.Length > 4)
                txtNumberInt.Focus();
        }

        private void txtNumberInt_TextChanged(object sender, EventArgs e)
        {
            if (txtNumberInt.Text.Length > 4)
                txtColony.Focus();
        }

        private void txtColony_TextChanged(object sender, EventArgs e)
        {
            if (txtColony.Text.Length > 29)
                txtCountry.Focus();
        }

        private void txtDelegation_TextChanged(object sender, EventArgs e)
        {
            if (txtDelegation.Text.Length > 14)
                txtCity.Focus();
        }

        private void txtCP_TextChanged(object sender, EventArgs e)
        {
            if (txtCP.Text.Length > 5)
                txtDelegation.Focus();
        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {
            if (txtCity.Text.Length > 19)
                txtState.Focus();
        }

        private void txtState_TextChanged(object sender, EventArgs e)
        {
            if (txtState.Text.Length > 17)
                txtRFC1.Focus();
        }

        private void txtRFC1_TextChanged(object sender, EventArgs e)
        {
            if (txtRFC1.Text.Length > 3)
                txtRFC2.Focus();
        }

        private void txtRFC2_TextChanged(object sender, EventArgs e)
        {
            if (txtRFC2.Text.Length > 5)
                txtRFC3.Focus();
        }

        private void txtRFC3_TextChanged(object sender, EventArgs e)
        {
            if (txtRFC3.Text.Length > 2)
                txtDescription1.Focus();
        }

        private void txtDescription1_TextChanged(object sender, EventArgs e)
        {
            if (txtDescription1.Text.Length > 49)
                txtDescription2.Focus();
        }

        private void txtDescription2_TextChanged(object sender, EventArgs e)
        {
            if (txtDescription2.Text.Length > 49)
                btnAcept.Focus();
        }

        #endregion

        #region===== MethodsClass =====

        /// <summary>
        /// Se valida que los campos que son obligatorios sean llenados
        /// </summary>
        private bool IsValidateBusinessRules
        {
            get
            {
                bool isvalid = false;

                if (string.IsNullOrEmpty(txtSocialReason.Text) | txtSocialReason.Text == ".")
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_INGRESAR_RAZON_SOCIAL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSocialReason.Focus();
                }
                else if (string.IsNullOrEmpty(txtStreet.Text))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIRE_INGRESAR_CALLE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtStreet.Focus();
                }
                else if (string.IsNullOrEmpty(txtNumberExt.Text))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_INGRESAR_NUMERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberExt.Focus();
                }
                else if (string.IsNullOrEmpty(txtColony.Text))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_INGRESAR_COLONIA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtColony.Focus();
                }

                else if (string.IsNullOrEmpty(txtCP.Text))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_INGRESAR_CODIGO_POSTAL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCP.Focus();
                }

                else if (string.IsNullOrEmpty(txtRFC1.Text) | string.IsNullOrEmpty(txtRFC2.Text) | string.IsNullOrEmpty(txtRFC3.Text))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_INGRESAR_RFC_COMPLETO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRFC1.Focus();
                }
                else if (txtRFC1.Text.Length < 3)
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_INGRESAR_RFC_COMPLETO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRFC1.Focus();
                }
                else if (txtRFC2.Text.Length < 6)
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_INGRESAR_RFC_COMPLETO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRFC2.Focus();
                }
                else if (txtRFC3.Text.Length < 3)
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_INGRESAR_RFC_COMPLETO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRFC3.Focus();
                }
                else if (string.IsNullOrEmpty(txtCountry.Text))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_INGRESAR_PAIS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCountry.Focus();
                }
                else
                    isvalid = true;

                string SearchCountry = GetCountryBL.GetCountry(txtCountry.Text);
                if (string.IsNullOrEmpty(SearchCountry))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.SELECCIONAR_PAIS_LISTA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCountry.Focus();
                    isvalid = false;
                }


                if (txtCountry.Text.Trim() == "MEXICO")
                {
                    if (string.IsNullOrEmpty(txtDelegation.Text))
                    {
                        MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_INGRESAR_DELEGACION, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDelegation.Focus();
                        isvalid = false;
                    }

                    if (string.IsNullOrEmpty(txtState.Text))
                    {
                        MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_INGRESAR_ESTADO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtState.Focus();
                        isvalid = false;
                    }

                    if (string.IsNullOrEmpty(txtCity.Text))
                    {
                        MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_INGRESAR_DIUDAD, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCity.Focus();
                        isvalid = false;
                    }
                }
                return isvalid;
            }
        }


        public static string RemarksOfBillingAddres { get; set; }

        public static bool InterJetStaticFlag
        {
            get;
            set;
        }


        public static bool SendCommandsBuild()
        {
            int row = 0; int col = 0;
            String Warning = string.Empty;
            bool status = true;

            send = Resources.TicketEmission.Constants.COMMANDS_FIVE_SLASH;
            if (!string.IsNullOrEmpty(socialReason))
            {
                send = string.Concat(send, socialReason,
                    Resources.TicketEmission.Constants.COMMADS_END_IT_FIVE_SLASH);
            }
            else
                send = string.Concat(send, Resources.TicketEmission.Constants.COMMADS_END_IT_FIVE_SLASH);
            if (!string.IsNullOrEmpty(street))
            {
                if (!string.IsNullOrEmpty(numberExt) && !string.IsNullOrEmpty(numberInt))
                {
                    send = string.Concat(send, street, Resources.TicketEmission.Constants.AST, numberExt,
                        Resources.TicketEmission.Constants.AST, numberInt, ",", colony,
                        Resources.TicketEmission.Constants.COMMADS_END_IT_FIVE_SLASH);
                }
                else if (!string.IsNullOrEmpty(numberExt) && string.IsNullOrEmpty(numberInt))
                {
                    send = string.Concat(send, street, Resources.TicketEmission.Constants.AST, numberExt,
                    ",", colony, Resources.TicketEmission.Constants.COMMADS_END_IT_FIVE_SLASH);
                }
            }
            else
                send = string.Concat(send, Resources.TicketEmission.Constants.COMMANDS_POINT_END_IT_FIVE_SLASH);

            send = string.Concat(send, delegation, ",", city, ",", state,
                        Resources.TicketEmission.Constants.COMMADS_END_IT_FIVE_SLASH);

            if (!string.IsNullOrEmpty(cp))
            {
                send = string.Concat(send, cp, '*', country,
                    Resources.TicketEmission.Constants.COMMADS_END_IT_FIVE_SLASH);
            }
            else
            {
                send = string.Concat(send, Resources.TicketEmission.Constants.COMMANDS_POINT_END_IT_FIVE_SLASH);
            }
            if (!string.IsNullOrEmpty(rfc1))
            {
                send = send = string.Concat(send, rfc1, rfc2,
                    rfc3);
            }
            else
            {
                send = string.Concat(send, Resources.TicketEmission.Constants.POINT);
            }
            using (CommandsAPI objCommands = new CommandsAPI())
            {

                if (!ucAvailability.IsInterJetProcess && !IsVolarisStaticFlag)
                {
                    Warning = send;

                    CommandsQik.searchResponse(Warning, Resources.TicketEmission.ValitationLabels.AST_SIMULTANEOUS_CHANGES, ref row, ref col, 2, 3, 1, 64);
                    string[] sabreAnswerWar = Warning.Split('\n');

                    if (sabreAnswerWar[0] == Resources.TicketEmission.ValitationLabels.AST_SIMULTANEOUS_CHANGES)
                    {
                        return false;
                    }
                }
                //return false;
                if (IsVolarisStaticFlag || InterJetStaticFlag)
                {
                    addAdress = send;
                }
            }

            if (!string.IsNullOrEmpty(description1) | (!string.IsNullOrEmpty(description2)))
            {
                send = string.Empty;
                send = Resources.TicketEmission.Constants.COMMANDS_FIVE_POINT;
                if (!string.IsNullOrEmpty(description1))
                {
                    send = string.Concat(send, Resources.TicketEmission.Constants.COMMANDS_DES01_IDENT,
                        description1);
                    if (!string.IsNullOrEmpty(description2))
                    {
                        send = string.Concat(send, Resources.TicketEmission.Constants.COMMANDS_ENDIT_5_DES02_INDENT,
                            description2);
                    }
                }

                else if (!string.IsNullOrEmpty(description2))
                {
                    send = string.Concat(send, Resources.TicketEmission.Constants.COMMANDS_DES02_INDENT,
                        description2);
                }
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    if (!ucAvailability.IsInterJetProcess && !IsVolarisStaticFlag)
                    {
                        objCommands.SendReceive(send);
                    }
                    else
                    {
                        if(string.IsNullOrEmpty(RemarksOfBillingAddres))
                        descripcionExtend = send;
                    }
                }
            }
            RemarksOfBillingAddres = addAdress;
            if (!string.IsNullOrEmpty(descripcionExtend))
                RemarksOfBillingAddres = RemarksOfBillingAddres + "Σ" + descripcionExtend;

            sabreConcat = string.Empty;
            return status;

        }


        /// <summary>
        /// Se arma el comando de acuredo a los Controles que se encuentren 
        /// con datos y guardan en una variable 
        /// </summary>
        public static void commandsBuild()
        {
            send = Resources.TicketEmission.Constants.COMMANDS_FIVE_SLASH;
            if (!string.IsNullOrEmpty(socialReason))
            {
                send = string.Concat(send, socialReason,
                    Resources.TicketEmission.Constants.COMMADS_END_IT_FIVE_SLASH);
            }
            else
                send = string.Concat(send, Resources.TicketEmission.Constants.COMMADS_END_IT_FIVE_SLASH);
            if (!string.IsNullOrEmpty(street))
            {
                if (!string.IsNullOrEmpty(numberExt) && !string.IsNullOrEmpty(numberInt))
                {
                    send = string.Concat(send, street, Resources.TicketEmission.Constants.AST, numberExt,
                        Resources.TicketEmission.Constants.AST, numberInt, ",", colony,
                        Resources.TicketEmission.Constants.COMMADS_END_IT_FIVE_SLASH);
                }
                else if (!string.IsNullOrEmpty(numberExt) && string.IsNullOrEmpty(numberInt))
                {
                    send = string.Concat(send, street, Resources.TicketEmission.Constants.AST, numberExt,
                    ",", colony, Resources.TicketEmission.Constants.COMMADS_END_IT_FIVE_SLASH);
                }
            }
            else
                send = string.Concat(send, Resources.TicketEmission.Constants.COMMANDS_POINT_END_IT_FIVE_SLASH);

            send = string.Concat(send, delegation, ",", city, ",", state,
                        Resources.TicketEmission.Constants.COMMADS_END_IT_FIVE_SLASH);

            if (!string.IsNullOrEmpty(cp))
            {
                send = string.Concat(send, cp, '*', country,
                    Resources.TicketEmission.Constants.COMMADS_END_IT_FIVE_SLASH);
            }
            else
            {
                send = string.Concat(send, Resources.TicketEmission.Constants.COMMANDS_POINT_END_IT_FIVE_SLASH);
            }
            if (!string.IsNullOrEmpty(rfc1))
            {
                send = send = string.Concat(send, rfc1, rfc2,
                    rfc3);
            }
            else
            {
                send = string.Concat(send, Resources.TicketEmission.Constants.POINT);
            }
            using (CommandsAPI objCommands = new CommandsAPI())
            {

                if (!ucAvailability.IsInterJetProcess && !IsVolarisStaticFlag)
                {
                    objCommands.SendReceive(send);
                }

                if (IsVolarisStaticFlag || InterJetStaticFlag)
                {
                    //RemarksOfBillingAddres = send;
                    addAdress = send;
                }
            }

            if (!string.IsNullOrEmpty(description1) | (!string.IsNullOrEmpty(description2)))
            {
                send = string.Empty;
                send = Resources.TicketEmission.Constants.COMMANDS_FIVE_POINT;
                if (!string.IsNullOrEmpty(description1))
                {
                    send = string.Concat(send, Resources.TicketEmission.Constants.COMMANDS_DES01_IDENT,
                        description1);
                    if (!string.IsNullOrEmpty(description2))
                    {
                        send = string.Concat(send, Resources.TicketEmission.Constants.COMMANDS_ENDIT_5_DES02_INDENT,
                            description2);
                    }
                }

                else if (!string.IsNullOrEmpty(description2))
                {
                    send = string.Concat(send, Resources.TicketEmission.Constants.COMMANDS_DES02_INDENT,
                        description2);
                }
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    if (!ucAvailability.IsInterJetProcess && !IsVolarisStaticFlag)
                    {
                        objCommands.SendReceive(send);
                    }
                    else
                    {
                        //RemarksOfBillingAddres = send;
                        descripcionExtend = send;
                    }
                }
            }
            RemarksOfBillingAddres = addAdress;
            if (!string.IsNullOrEmpty(descripcionExtend))
                RemarksOfBillingAddres = RemarksOfBillingAddres + "Σ" + descripcionExtend;

            sabreConcat = string.Empty;
        }

        /// <summary>
        /// borra valores de los remarks de INTEGRA anteriores
        /// </summary>
        private void ClearRemarksIntegraValues()
        {
            c43 = string.Empty;
            c44 = string.Empty;
            c45 = string.Empty;
            c46 = string.Empty;
            c47 = string.Empty;
            c48 = string.Empty;
            c49 = string.Empty;
        }

        private void SetIntegraValues()
        {
            c43 = socialReason;
            if (!string.IsNullOrEmpty(numberInt))
            {
                c44 = string.Concat(street,
                    ",",
                    numberInt,
                    ",",
                    numberExt,
                    ",",
                    colony);
            }
            else
            {
                c44 = string.Concat(street,
                    ",",
                    numberExt,
                    ",",
                    colony);
            }
            c45 = string.Concat(delegation,
                ",",
                city,
                ",",
                state);
            c46 = string.Concat(cp, "*", country);
            c47 = string.Concat(rfc1,
                rfc2,
                rfc3);
        }

        /// <summary>
        /// Valida que exista la leyenda remarks dentro de la respuesta de MySabre para continuar con el 
        /// flujo
        /// </summary>
        /// <returns></returns>
        public static bool SearchRemarks
        {
            get
            {
                bool exixtingRemarks = false;
                int row = 0;
                int col = 0;
                send = Resources.TicketEmission.Constants.COMMANDS_AST_SLASH;
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
                CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.REMARKS, ref row, ref col);
                if (row > 0)
                {
                    exixtingRemarks = true;
                    sabreConcat = string.Concat(result, "\n");
                }
                else
                    exixtingRemarks = false;
                return exixtingRemarks;
            }
        }

        /// <summary>
        /// Copia la dirección que contiene el remark
        /// en las cajas te texto
        /// </summary>
        private void CopyAdress()
        {
            int row = 0;
            int col = 0;
            int numext = 0;
            int numint = 0;
            int delega = 0;

            string socialreason = string.Empty;
            string adress = string.Empty;
            int adresslenght = 0;
            string street = string.Empty;
            string numberext = string.Empty;
            string numberint = string.Empty;
            string colony = string.Empty;

            string native = string.Empty;
            int nativelenght = 0;
            string delegation = string.Empty;
            string city = string.Empty;
            string state = string.Empty;

            string cp = string.Empty;

            string rfc1 = string.Empty;
            string rfc2 = string.Empty;
            string rfc3 = string.Empty;

            CommandsQik.CopyResponse(result, ref socialreason, 2, 6, 55);
            socialreason = socialreason.Trim();
            CommandsQik.CopyResponse(result, ref adress, 3, 6, 64);
            adress = adress.Trim();

            CommandsQik.searchResponse(adress, "*", ref row, ref col);
            if (row != 0 || col != 0)
            {
                CommandsQik.CopyResponse(adress, ref street, row, 1, col);
                numext = col;
                adresslenght = ((adress.Length) - (col + 1));
                adress = adress.Substring((col + 1), adresslenght);
                row = 0;
                col = 0;
            }
            if (!string.IsNullOrEmpty(street))
            {
                CommandsQik.searchResponse(adress, "*", ref row, ref col);
                if (col > 0)
                {
                    CommandsQik.CopyResponse(adress, ref numberext, row, 1, col);
                    numint = col;
                    col = 0;
                    row = 0;
                }

                CommandsQik.searchResponse(adress, ",", ref row, ref col, 1, 1, numint + 2, 64);
                if (col > 0)
                {
                    if (numint > 0)
                        CommandsQik.CopyResponse(adress, ref numberint, row, numint + 2, (col - (numint + 1)));
                    else
                        CommandsQik.CopyResponse(adress, ref numberext, row, 1, col);

                    CommandsQik.CopyResponse(adress, ref colony, row, col + 2, 30);
                    colony = colony.Trim();
                }
            }
            else
            {
                adresslenght = adress.Length;
                street = adress.Substring(0, adresslenght);
            }
            col = 0;
            row = 0;
            CommandsQik.CopyResponse(result, ref native, 4, 6, 55);
            native = native.Trim();
            CommandsQik.searchResponse(native, ",", ref row, ref col);
            if (row != 0 || col != 0)
            {
                CommandsQik.CopyResponse(native, ref delegation, row, 1, col);
                nativelenght = (native.Length - (col + 1));
                native = native.Substring((col + 1), nativelenght);
                delega = col;
                row = 0;
                col = 0;
                CommandsQik.searchResponse(native, ",", ref row, ref col);
                if (col > 0)
                {
                    CommandsQik.CopyResponse(native, ref city, row, 1, col);
                    CommandsQik.CopyResponse(native, ref state, row, col + 2, 18);
                    state = state.Trim();
                }
            }
            else
            {
                nativelenght = native.Length;
                delegation = native.Substring(0, nativelenght);
            }
            CommandsQik.CopyResponse(result, ref cp, 5, 6, 6);
            cp = cp.Replace('*', ' ').Trim();
            CommandsQik.CopyResponse(result, ref rfc1, 6, 6, 4);
            CommandsQik.CopyResponse(result, ref rfc2, 6, 10, 6);
            rfc2 = rfc2.Trim();
            CommandsQik.CopyResponse(result, ref rfc3, 6, 16, 3);

            if (socialreason.Length > 55)
                socialreason = socialreason.Remove(55);
            if (street.Length > 21)
                street = street.Remove(21);
            if (numberext.Length > 5)
                numberext = numberext.Remove(5);
            if (numberint.Length > 5)
                numberint = numberint.Remove(5);
            if (colony.Length > 30)
                colony = colony.Remove(30);
            if (delegation.Length > 15)
                delegation = delegation.Remove(15);
            if (cp.Length > 6)
                cp = cp.Remove(6);
            if (city.Length > 20)
                city = city.Remove(20);
            if (state.Length > 18)
                state = state.Remove(18);
            if (rfc1.Length > 4)
                rfc1 = rfc1.Remove(4);
            if (rfc2.Length > 6)
                rfc2 = rfc2.Remove(6);
            if (rfc3.Length > 3)
                rfc3 = rfc3.Remove(3);

            string rfcComplete = rfc1 + rfc2 + rfc3;

            if (rfcComplete.Length == 12)
            {
                rfc1 = rfcComplete.Substring(0, 3);
                rfc2 = rfcComplete.Substring(3, 6);
                rfc3 = rfcComplete.Substring(9, 3);
            }
            else if (rfcComplete.Length == 13)
            {
                rfc1 = rfcComplete.Substring(0, 4);
                rfc2 = rfcComplete.Substring(4, 6);
                rfc3 = rfcComplete.Substring(10, 3);
            }

            if (ValidateRegularExpression.ValidateCharacter(socialreason))
                txtSocialReason.Text = socialreason;
            if (ValidateRegularExpression.ValidateCharacter(street))
                txtStreet.Text = street;
            if (ValidateRegularExpression.ValidateCharacter(numberint))
                txtNumberInt.Text = numberint;
            if (ValidateRegularExpression.ValidateCharacter(numberext))
                txtNumberExt.Text = numberext;
            if (ValidateRegularExpression.ValidateCharacter(colony))
                txtColony.Text = colony;
            if (ValidateRegularExpression.ValidateCharacter(city))
                txtCity.Text = city;
            if (ValidateRegularExpression.ValidateCharacter(state))
                txtState.Text = state;
            if (ValidateRegularExpression.ValidateCharacter(delegation))
                txtDelegation.Text = delegation;
            if (ValidateRegularExpression.ValidateNumbers(cp))
                txtCP.Text = cp;
            if (ValidateRegularExpression.ValidateNumberandLetters(rfc1))
                txtRFC1.Text = rfc1;
            if (ValidateRegularExpression.ValidateNumberandLetters(rfc2))
                txtRFC2.Text = rfc2;
            if (ValidateRegularExpression.ValidateNumberandLetters(rfc3))
                txtRFC3.Text = rfc3;
        }

        /// <summary>
        /// reinicializa el proceso de buscar remarks contables
        /// </summary>
        public static void BucleFindEndScroll()
        {
            SendScrollCommand();
            if (!SearchEndScroll())
            {
                BucleFindEndScroll();
            }

        }

        /// <summary>
        /// Manda el comando para verificar si el record contiene mas remarks contables
        /// </summary>
        private static void SendScrollCommand()
        {
            send = string.Empty;
            sabreResult = string.Empty;
            send = Resources.TicketEmission.Constants.COMMANDS_MD;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreResult = objCommand.SendReceive(send);
            }
        }

        /// <summary>
        /// Valida el fin del despliegue de remarks contables en MySabre
        /// </summary>
        /// <returns></returns>
        private static bool SearchEndScroll()
        {
            bool endScroll = false;
            int row = 0;
            int col = 0;
            CommandsQik.searchResponse(sabreResult, "SCROLL‡", ref row, ref col);
            if (row != 0 && col >= 0)
            {
                endScroll = true;
            }
            else
            {
                sabreConcat = string.Concat(sabreConcat.Trim(),
                    "\n",
                    sabreResult,
                    "\n");
                endScroll = false;
            }
            sabreConcat = sabreConcat.Replace('‡', '\n');
            sabreConcat = sabreConcat.Trim();
            return endScroll;
        }

        /// <summary>
        /// crea la rutina para eliminar los remarks contables de las diferentes respuestas
        /// de Mysabre
        /// </summary>
        public static void Remarks()
        {
            string ren = string.Empty;
            string ren1 = string.Empty;
            string five = Resources.TicketEmission.Constants.COMMANDS_FIVE;
            int lenght = 0;
            Sabre = string.Empty;
            string[] sabreAnswerInfo = sabreConcat.Split(new[] { '\n' });
            lenght = sabreAnswerInfo.Length;

            for (int i = lenght; i >= 2; i--)
            {
                CommandsQik.CopyResponse(sabreConcat, ref ren, i, 4, 2);
                if (ren == Resources.TicketEmission.Constants.COMMADNS_DOT_SLASH)
                {
                    CommandsQik.CopyResponse(sabreConcat, ref ren1, i, 1, 3);
                    ren1 = ren1.Trim();
                    Sabre = string.Concat(Sabre, five, ren1, Resources.TicketEmission.Constants.AT, "Σ");
                }
            }

            if (!string.IsNullOrEmpty(Sabre))
            {
                send = string.Empty;
                Sabre = Sabre.TrimEnd(new[] { 'Σ' });
                send = Sabre;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(send);
                }

            }
        }

        /// <summary>
        /// Carga informacion a la mascarilla por Location
        /// </summary>
        private Boolean ExistAndLoadLocationInformation()
        {

            string location = ucFirstValidations.DK;
            WsMyCTS wsServ = new WsMyCTS();
            MyCTS.Services.ValidateDKsAndCreditCards.Cat1stStarInfoByLocation star1InfoByLocation = null;

            try
            {
                star1InfoByLocation = wsServ.GetProfileInfo(location);
            }
            catch { }

            if (star1InfoByLocation != null)
            {
                if (!string.IsNullOrEmpty(star1InfoByLocation.CustomerName))
                {
                    string customer = star1InfoByLocation.CustomerName.ToString();
                    customer = customer.Replace("(", "");
                    customer = customer.Replace(")", "");
                    txtSocialReason.Text = customer.Replace(',', ' ');
                }

                if (!string.IsNullOrEmpty(star1InfoByLocation.Address1))
                    txtStreet.Text = star1InfoByLocation.Address1.Replace(',', ' '); ;

                if (!string.IsNullOrEmpty(star1InfoByLocation.Address2))
                {
                    star1InfoByLocation.Address2 = star1InfoByLocation.Address2.Replace("#", "");
                    star1InfoByLocation.Address2 = star1InfoByLocation.Address2.TrimStart().Replace(',', ' '); ;

                    txtNumberExt.Text = star1InfoByLocation.Address2;
                }
                if (!string.IsNullOrEmpty(star1InfoByLocation.Address3))
                {
                    star1InfoByLocation.Address3 = star1InfoByLocation.Address3.Replace("#", "");
                    star1InfoByLocation.Address3 = star1InfoByLocation.Address3.TrimStart().Replace(',', ' ');
                    txtNumberInt.Text = star1InfoByLocation.Address3;
                }
                if (!string.IsNullOrEmpty(star1InfoByLocation.Address4))
                    txtColony.Text = star1InfoByLocation.Address4;

                if (star1InfoByLocation.Address4 == "")
                    txtColony.Enabled = true;


                if (!string.IsNullOrEmpty(star1InfoByLocation.Municipality))
                {
                    txtDelegation.Text = star1InfoByLocation.Municipality.Replace(',', ' ');
                }


                if (!string.IsNullOrEmpty(star1InfoByLocation.PostalCode))
                {
                    txtCP.Text = star1InfoByLocation.PostalCode;
                }

                if (!string.IsNullOrEmpty(star1InfoByLocation.City))
                {
                    txtCity.Text = star1InfoByLocation.City.Replace(',', ' ');
                }


                if (!string.IsNullOrEmpty(star1InfoByLocation.State))
                {
                    txtState.Text = star1InfoByLocation.State.Replace(',', ' ');
                }


                if (!string.IsNullOrEmpty(star1InfoByLocation.RFC))
                {
                    bool IsRFC = ValidateRegularExpression.ValidateRFCFormat(star1InfoByLocation.RFC);
                    if (IsRFC)
                    {
                        if (star1InfoByLocation.RFC.Length.Equals(13))
                        {
                            txtRFC1.Text = star1InfoByLocation.RFC.Substring(0, 4);
                            txtRFC2.Text = star1InfoByLocation.RFC.Substring(4, 6);
                            txtRFC3.Text = star1InfoByLocation.RFC.Substring(10, 3);
                        }


                        else if (star1InfoByLocation.RFC.Length.Equals(12))
                        {
                            txtRFC1.Text = star1InfoByLocation.RFC.Substring(0, 3);
                            txtRFC2.Text = star1InfoByLocation.RFC.Substring(3, 6);
                            txtRFC3.Text = star1InfoByLocation.RFC.Substring(9, 3);
                        }
                    }
                }
                return true;
            }

            return true;
        }


        /// <summary>
        /// Carga informacion a la mascarilla por Location si falla el metodo principal
        /// </summary>
        private Boolean ExistLoadLocationInfoBackup()
        {
            string location = ucFirstValidations.DK;
            MyCTS.Entities.Cat1stStarInfoByLocation starFirstInfoByLocation = Cat1stStarInfoByLocationBL.Get1stStarInfoByLocation(location);
            if (starFirstInfoByLocation != null)
            {
                if (!string.IsNullOrEmpty(starFirstInfoByLocation.CustomerName))
                {
                    string customer = starFirstInfoByLocation.CustomerName.ToString();
                    customer = customer.Replace("(", "");
                    customer = customer.Replace(")", "");
                    txtSocialReason.Text = customer.Replace(',', ' ');
                }

                if (!string.IsNullOrEmpty(starFirstInfoByLocation.Address1))
                    txtStreet.Text = starFirstInfoByLocation.Address1.Replace(',', ' ');

                if (!string.IsNullOrEmpty(starFirstInfoByLocation.Address2))
                {
                    starFirstInfoByLocation.Address2 = starFirstInfoByLocation.Address2.Replace("#", "");
                    starFirstInfoByLocation.Address2 = starFirstInfoByLocation.Address2.TrimStart();

                    txtNumberExt.Text = starFirstInfoByLocation.Address2.Replace(',', ' ');

                }
                if (!string.IsNullOrEmpty(starFirstInfoByLocation.Address3))
                {
                    starFirstInfoByLocation.Address3 = starFirstInfoByLocation.Address3.Replace("#", "");
                    starFirstInfoByLocation.Address3 = starFirstInfoByLocation.Address3.TrimStart();
                    txtNumberInt.Text = starFirstInfoByLocation.Address3;
                }
                if (!string.IsNullOrEmpty(starFirstInfoByLocation.Address4))
                    txtColony.Text = starFirstInfoByLocation.Address4.Replace(',', ' ');

                if (!string.IsNullOrEmpty(starFirstInfoByLocation.Municipality))
                    txtDelegation.Text = starFirstInfoByLocation.Municipality.Replace(',', ' ');

                if (!string.IsNullOrEmpty(starFirstInfoByLocation.PostalCode))
                    txtCP.Text = starFirstInfoByLocation.PostalCode;

                if (!string.IsNullOrEmpty(starFirstInfoByLocation.City))
                    txtCity.Text = starFirstInfoByLocation.City.Replace(',', ' ');

                if (!string.IsNullOrEmpty(starFirstInfoByLocation.State))
                    txtState.Text = starFirstInfoByLocation.State.Replace(',', ' ');

                if (!string.IsNullOrEmpty(starFirstInfoByLocation.RFC))
                {
                    bool IsRFC = ValidateRegularExpression.ValidateRFCFormat(starFirstInfoByLocation.RFC);
                    if (IsRFC)
                    {
                        if (starFirstInfoByLocation.RFC.Length.Equals(13))
                        {
                            txtRFC1.Text = starFirstInfoByLocation.RFC.Substring(0, 4);
                            txtRFC2.Text = starFirstInfoByLocation.RFC.Substring(4, 6);
                            txtRFC3.Text = starFirstInfoByLocation.RFC.Substring(10, 3);
                        }
                        else if (starFirstInfoByLocation.RFC.Length.Equals(12))
                        {
                            txtRFC1.Text = starFirstInfoByLocation.RFC.Substring(0, 3);
                            txtRFC2.Text = starFirstInfoByLocation.RFC.Substring(3, 6);
                            txtRFC3.Text = starFirstInfoByLocation.RFC.Substring(9, 3);
                        }
                    }
                }
                return true;
            }

            return true;
        }


        #endregion


        #region===== Events =====

        private void txtCountry_TextChanged(object sender, EventArgs e)
        {
            lbCountries.Items.Clear();
            txtSender = (SmartTextBox)sender;
            Common.SetListBoxCountries(txtSender, lbCountries);
        }


        /// <summary>
        /// Esta función se encarga de mandar el foco hacia la opción
        /// deseada y al elegir se oculata el ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbCountries_KeyDown(object sender, KeyEventArgs e)
        {
            ListBox ListBox = (ListBox)sender;
            TextBox txt = (TextBox)txtCountry;
            if (e.KeyCode == Keys.Enter)
            {
                ListItem li = (ListItem)ListBox.SelectedItem;
                txt.Text = li.Text2;
                lbCountries.Visible = false;
                txt.Focus();
            }
        }

        ////KeyDown lbCountries
        ///// <summary>
        ///// Esta función permite selccionar un elemento del listbox y 
        ///// oculta el ListBox al momento de seleccionarlo
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void lbCountries_KeyDown(object sender, KeyEventArgs e)
        //{
        //    ListBox ListBox = (ListBox)sender;
        //    TextBox txt = (TextBox)txtCountry;

        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        ListItem li = (ListItem)ListBox.SelectedItem;
        //        txt.Text = li.Text2;
        //        country = li.Text2;
        //        if (li.Value == "MX")
        //        {
        //            isMexCountry = true;
        //        }
        //        else
        //            isMexCountry = false;
        //        lbCountries.Visible = false;
        //        txt.Focus();
        //    }
        //}

        //Mouse Click
        /// <summary>
        /// Esta función es para permitir el Clic sobre un elemento del ListBox
        /// para seleccional el item y oculta el listBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbCountries_MouseClick(object sender, MouseEventArgs e)
        {

            ListBox listBox = (ListBox)sender;
            TextBox txt = (TextBox)txtCountry;
            ListItem li = (ListItem)listBox.SelectedItem;
            txt.Text = li.Text2;
            lbCountries.Visible = false;
            txt.Focus();
        }



        /// <summary>
        /// Asignacion de acciones al presionar la tecla ENTER, ESC o DOWN
        /// cuando el txt origen, destino o conexiones tiene el foco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCountry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            if (e.KeyData == Keys.Enter)
            {
                btnAcept_Click(sender, e);
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lbCountries.Items.Count > 0)
                {
                    lbCountries.SelectedIndex = 0;
                    //lbCountries.Focus();
                    lbCountries.Visible = true;
                    lbCountries.Focus();
                }
            }
        }
        #endregion

    }
}