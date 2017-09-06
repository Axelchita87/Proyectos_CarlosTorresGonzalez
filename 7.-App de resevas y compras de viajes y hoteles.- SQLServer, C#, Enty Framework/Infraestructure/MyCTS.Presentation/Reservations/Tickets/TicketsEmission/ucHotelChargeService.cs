using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using MyCTS.Services.Contracts;
using MyCTS.Services.ValidateDKsAndCreditCards;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace MyCTS.Presentation
{
    public partial class ucHotelChargeService : CustomUserControl
    {
        public static string RemarkPax1 { get; set; }
        public static string RemarkPax2 { get; set; }
        public static string RemarkPax3 { get; set; }
        public static string RemarkPax4 { get; set; }
        public static string RemarkPax5 { get; set; }
        public static string RemarkPax6 { get; set; }
        public static string RemarkPax7 { get; set; }
        public static string RemarkPax8 { get; set; }
        public static string RemarkPax9 { get; set; }
        public static string Remarks { get; set; }
        private static string chargeperservice;
        public static string ChargePerService
        {
            get { return chargeperservice; }
            set { chargeperservice = value; }
        }
        private static string c23;
        public static string C23
        {
            get { return c23; }
            set { c23 = value; }
        }
        public static bool emissionTicket = false;
        private delegate void SenderCallBack();
        private delegate void StopControlsDelegate();
        private delegate void HideMessagesDelegate();
        private delegate void SendMessagesDelegate(string m);
        private delegate bool AplicarCargosDelegate();
        private string recLoc = ucFirstValidations.LocatorRecord;
        private string bysegments = string.Empty;
        private string fireType = string.Empty;
        private string ticketType = string.Empty;
        private string formOfPayment = string.Empty;
        private string ticketIssuingCarrierTarget = string.Empty;
        private string lastDateToPurcahse = string.Empty;
        private string baseFare = string.Empty;
        private string information = string.Empty;
        int iCurrentPaxNumber = 1;
        public static List<CreditCardInfo> lstDatosTarjeta = null;
        public static int cmbFecMes = 0;
     
        private class RuleAndPassenger
        {
            public int Rule { get; set; }
            public string PaxNumber { get; set; }
        }

        private class Meses
        {
            public string Text { get; set; }
            public string Value { get; set; }
            public override string ToString()
            {
                return Text;
            }
        }

        public static ChargesPerService.OrigenTipoCargo TipoCargo;

        private bool IsValidBussinesRules
        {
            get
            {
                bool isValid = true;

                if (cmbTypeCard.SelectedIndex.Equals(0))
                {
                    this.Focus();
                    MessageBox.Show("REQUIERE INGRESAR LA FORMA DE PAGO DEL CARGO POR SERVICIO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else if (!validateCardNumber())
                {
                    this.Focus();
                    MessageBox.Show("REQUIERE INGRESAR EL NÚMERO DE TARJETA O CUENTA DEL CARGO POR SERVICIO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                    isValid = false;

                return isValid;
            }
        }


        private bool validateCardNumber()
        {
            if (string.IsNullOrEmpty(txtNumberCardCTS.Text)
                    && cmbTypeCard.SelectedIndex > 0)
            {
                if (!((ListItem)cmbTypeCard.SelectedItem).Text2.Equals("CA"))
                {
                    this.Focus();
                    MessageBox.Show("REQUIERE INGRESAR EL NÚMERO DE TARJETA O CUENTA DEL CARGO POR SERVICIO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberCardCTS.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        public ucHotelChargeService()
        {
            InitializeComponent();
        }

        private void ucHotelChargeService_Load(object sender, EventArgs e)
        {
            ChargesPerService.DKActual = string.Empty;

            CargaAnios();
            CargarMeses();
            LoadFormPaymentCodes();

            string nameSecondLevel = string.Empty;
            string level1 = string.Empty;

            if (string.IsNullOrEmpty(ucFirstValidations.LocatorRecord))
            {
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    string sabreAnswer = objCommand.SendReceive(ChargesPerService.PreguntasASabre.VERIFICAR_RESERVA);
                    CommandsQik.CopyResponse(sabreAnswer, ref nameSecondLevel, 2, 5, 50);
                    CommandsQik.CopyResponse(objCommand.SendReceive("*PDK"), ref level1, 1, 18, 50);
                    CommandsQik.CopyResponse(sabreAnswer, ref recLoc, 1, 1, 6);
                    char[] separadores = { '\n' };
                    string[] respuesta = sabreAnswer.Split(separadores, StringSplitOptions.RemoveEmptyEntries);                  
                }
            }

            //First Level
            List<Entities.InterJetProfileCreditCard> lstFirst = new InterJetProfileBL().GetProfileCreditCard(level1.Trim());

            string[] name = nameSecondLevel.Split('2');
            string fName = string.Empty;

            fName = name[0].Replace(" ", string.Empty);

            //Second Level
            Entities.InterJetProfile profile = new InterJetProfileBL().GetProfile(fName, level1.Trim());
            if (profile != null)
            {
                profile.CreditCards = profile.CreditCards != null ? profile.CreditCards : new Entities.InterJetProfileCreditCards();
                profile.CreditCards.Add(lstFirst);
            }
            else
            {
                profile = new Entities.InterJetProfile() { CreditCards = new Entities.InterJetProfileCreditCards() };
                profile.CreditCards.Add(lstFirst);
            }

            if (profile.CreditCards.HasCards)
            {
                using (var form = new MyCTS.Presentation.Reservations.Availability.InterJet.frmInterJetProfileCreditCards())
                {
                    form.SetProfile(profile);
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.ShowDialog();
                    form.Activate();
                    form.Focus();
                    var card = form.Handler.SelectedCreditCardCard.FullProtectedCard;
                    if (card.StartsWith("AX") || card.StartsWith("VI") || card.StartsWith("CA") || card.StartsWith("MC") || card.StartsWith("TP"))
                    {
                        cmbTypeCard.SelectedIndex = card.StartsWith("AX") ? cmbTypeCard.FindString("AX - TC AMEX") : card.StartsWith("VI") ? cmbTypeCard.FindString("VI - TC VISA") : (card.StartsWith("CA") || card.StartsWith("MC")) ? cmbTypeCard.FindString("CA - TC MASTERCARD") : card.StartsWith("TP") ? cmbTypeCard.FindString("TP") : 0;
                        //Número de Tarjeta. 
                        txtNumberCardCTS.Text = form.Handler.SelectedCreditCardCard.CreditCardNumber;
                        txtNumberCardCTS.PasswordChar = '·';
                        txtNumberCardCTS.Font = new Font("Symbol", 9F, FontStyle.Regular);
                        //Fecha de Expiración.
                        cmbMesVencimiento.SelectedIndex = DateTime.Parse(form.Handler.SelectedCreditCardCard.ExpirationDate.ToShortDateString()).Month - 1;
                        cmbAnioVencimiento.SelectedIndex = cmbAnioVencimiento.FindStringExact(DateTime.Parse(form.Handler.SelectedCreditCardCard.ExpirationDate.ToShortDateString()).Year.ToString());
                        //CVV dato con mascara.
                        txtDigitoSeguridad.Text = new string(Common.toDecrypt(form.Handler.SelectedCreditCardCard.CVV).Where(char.IsDigit).ToArray());
                        //Nombre del titular.
                        txtNombreTarjetahabiente.Text = form.Handler.SelectedCreditCardCard.titular;
                        //creditCard = true;
                    }
                    //SetSelectedCreditCardFromProfile(form.SelectedCreditCardCard);
                }
            }


        }

        private void CargarMeses()
        {
            for (int i = 1; i < 13; i++)
            {
                DateTime date = new DateTime(1900, i, 1);
                Meses mes = new Meses();
                mes.Text = char.ToUpper(date.ToString("MMMM")[0]) + date.ToString("MMMM").Substring(1); ;
                mes.Value = date.Month.ToString("00");
                cmbMesVencimiento.Items.Add(mes);
            }
            cmbMesVencimiento.SelectedIndex = 0;
        }

        private void CargaAnios()
        {
            for (int i = 0; i < 15; i++)
            {
                cmbAnioVencimiento.Items.Add(DateTime.Now.Year + i);
            }
            cmbAnioVencimiento.SelectedIndex = 0;
        }

        private void cmbGenerico_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveCurrentPaxFormPayment();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (TipoCargo != ChargesPerService.OrigenTipoCargo.Autos)
            {
                ucServicesFeePayApply.lstDatosTarjeta = new List<CreditCardInfo>();
                //ucServicesFeePayApply.lstDatosTarjeta2 = new List<CreditCardInfo>();
            }
            ContinueWithoutPay();
        }

        private void ContinueWithoutPay()
        {
            if (TipoCargo == ChargesPerService.OrigenTipoCargo.Autos)
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCCARCHARGESERVICE);
            }
            else
            {
                CleanRemarks();
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
        }

        private static void CleanRemarks()
        {
            RemarkPax1 = string.Empty;
            RemarkPax2 = string.Empty;
            RemarkPax3 = string.Empty;
            RemarkPax4 = string.Empty;
            RemarkPax5 = string.Empty;
            RemarkPax6 = string.Empty;
            RemarkPax7 = string.Empty;
            RemarkPax8 = string.Empty;
            RemarkPax9 = string.Empty;
        }

        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            //Validacion de existencia del PNR
            if (!ValidaExistenciaPNRActivo())
            {
                MessageBox.Show("No se pudo encontrar un PNR activo, favor de volver a ingresarlo", "No fue posible validar PNR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                return;
            }
            ValidacionFormasDePago();
        }

        private bool ValidaExistenciaPNRActivo()
        {
            bool ExistePNR = true;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                string sabreAnswer = objCommand.SendReceive(ChargesPerService.PreguntasASabre.VERIFICAR_RESERVA);
                CommandsQik.CopyResponse(sabreAnswer, ref recLoc, 1, 1, 6);
                char[] separadores = { '\n' };
                string[] respuesta = sabreAnswer.Split(separadores, StringSplitOptions.RemoveEmptyEntries);
                if (respuesta != null && respuesta.Length > 0 && respuesta[0] == "NO DATA")
                {
                    ExistePNR = false;
                }
            }
            return ExistePNR;
        }

        private void ValidacionFormasDePago()
        {
            switch (cmbTypeCard.Text)
            {
                case "TR - TRANSFERENCIA":
                case "CASH - EFECTIVO":
                case "CH - CHEQUE":
                    DeterminaValidacionGeneracionCargo();
                    break;
                case "TP - TC UATP":
                    ///Validación para la FoP TP - TC UATP para que al validar las tarjetas, no valide
                    ///todos los campos existentes en la plantilla aunque esten ocultos. Para cualquier
                    ///otro caso se validan todos los campos en la plantilla.
                    if (ValidateCreditCardNumber)
                    {
                    }
                    break;
                default:
                    if ((string.IsNullOrEmpty(cmbTypeCard.Text) || string.IsNullOrEmpty(txtDigitoSeguridad.Text) || string.IsNullOrEmpty(txtNombreTarjetahabiente.Text) || string.IsNullOrEmpty(cmbTypeCard.Text) || string.IsNullOrEmpty(cmbMesVencimiento.Text) || string.IsNullOrEmpty(cmbAnioVencimiento.Text) || string.IsNullOrEmpty(cmbTypeCard.Text)))
                    {
                        MessageBox.Show("¡Debes ingresar todos los campos!");
                        return;
                    }
                    //Se validan las fechas ingresadas por el usuario. No deben ser menor a los de la fecha actual
                    int cmboFecYear = Convert.ToInt32(DateTime.Now.Year);
                    int cmboFecMes = Convert.ToInt32(DateTime.Now.Month);
                    int cmbFecYear = Convert.ToInt32(cmbAnioVencimiento.Text);
                    if (cmbTypeCard.Text == "- Selecciona Forma de Pago -")
                    {
                        MessageBox.Show("¡Ingrese la Forma de Pago!", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    cmbFecMes = seleccionaMes();

                    if (cmbFecYear < cmboFecYear)
                    {
                        MessageBox.Show("¡Datos de vigencia de la tarjeta invalido, verifica el año!", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbAnioVencimiento.Focus();
                        return;
                    }
                    if (cmbFecMes < cmboFecMes & cmboFecYear == cmbFecYear)
                    {
                        MessageBox.Show("¡Datos de vigencia de la tarjeta invalido, verifica el mes!", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbMesVencimiento.Focus();
                        return;
                    }

                    if (string.IsNullOrEmpty(txtNumberCardCTS.Text))
                    {
                        MessageBox.Show("Debes ingresar un número de tarjeta. Ingrese", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNumberCardCTS.Text = string.Empty;
                        txtNumberCardCTS.Focus();
                        return;
                    }

                    ChargesPerService.RecuperarDK();
                    WsMyCTS wsServ = new WsMyCTS();
                    MyCTS.Services.ValidateDKsAndCreditCards.ClientCreditCard clientCreditCard = wsServ.GetClientCreditCardNumber(txtNumberCardCTS.Text, ChargesPerService.DKActual);

                    string creditCard = wsServ.GetCreditCardNumberCTS(txtNumberCardCTS.Text);
                    if (!string.IsNullOrEmpty(creditCard))
                    {
                        this.Focus();
                        MessageBox.Show("Debes ingresar un número de tarjeta diferente a una de CTS. Reingrese", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNumberCardCTS.Text = string.Empty;
                        txtNumberCardCTS.Focus();
                        return;
                    }
                    string clientCreditCardNumber = wsServ.GetClientCreditCardNumberATT(txtNumberCardCTS.Text);

                    if (string.IsNullOrEmpty(clientCreditCardNumber))
                    {
                        if (ValidateCreditCardNumber)
                        {
                            // No hace nada
                        }
                    }
                    else
                    {
                        if (clientCreditCard.CreditCardNumber != txtNumberCardCTS.Text)
                        {
                            MessageBox.Show("El número de tarjeta ingresado pertenece a un cliente diferente, ingrese un número de tarjeta válido", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtNumberCardCTS.Text = string.Empty;
                            txtNumberCardCTS.Focus();
                            return;
                        }
                    }                   

                    if (txtNumberCardCTS.Text == clientCreditCard.CreditCardNumber & ChargesPerService.DKActual == clientCreditCard.Client)
                    {
                        DeterminaValidacionGeneracionCargo();
                    }
                    break;
            }

            if (!VerificarCargoPrevio())
            {
                Pagar();
            }
            else
            {
                MessageBox.Show("Ya cuenta con un intento de cargo por servicio previo para hoteles, no es posible realizar un nuevo cargo por servicio para hoteles mediante la interfaz", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private bool VerificarCargoPrevio()
        {
            CxSHoteles datosTran = GetCxSHotelesBL.GetCxSHoteles(string.Concat(recLoc, "|HOTEL"));
            if (datosTran != null)
            {
                if (!string.IsNullOrEmpty(datosTran.FormaDePago))
                {
                    return true;
                }
            }
            return false;
        }

        private void Pagar()
        {
            ucServicesFeePayApply pago = new ucServicesFeePayApply();
            pago.tarjeta = new CreditCardInfo();
            pago.tarjeta.TipoTarjeta = ((ListItem)cmbTypeCard.SelectedItem).Text2;
            pago.tarjeta.NumeroTarjeta = txtNumberCardCTS.Text;
            pago.tarjeta.CodigoSeguridad = txtDigitoSeguridad.Text;
            pago.tarjeta.MesVencimiento = seleccionaMes().ToString("00");
            pago.tarjeta.AnioVencimiento = cmbAnioVencimiento.Text.Substring(2, 2);
            pago.tarjeta.NombreTitular = txtNombreTarjetahabiente.Text;
            pago.tarjeta.MontoCargo = Convert.ToDecimal(txtMontoCargo.Text);
            pago.tarjeta.OrigenVenta = "H";            
            pago.tarjeta.PNR = string.Concat(recLoc, "|HOTEL");
            pago.recLoc = recLoc;
            pago.PayServiceFee();
            //ucServicesFeePayApply.lstDatosTarjeta2.Add(pago.tarjeta);

            if (TipoCargo == ChargesPerService.OrigenTipoCargo.Autos)
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCCARCHARGESERVICE);
            }
            else
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCSERVICESFEEPAYAPPLY);
            }
        }

        private void txtNombreTarjetahabiente_Leave(object sender, EventArgs e)
        {
            SaveCurrentPaxFormPayment();
        }

        private void cmbAnioVencimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveCurrentPaxFormPayment();
        }

        private void cmbMesVencimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveCurrentPaxFormPayment();
        }

        private void cmbTypeCard_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int iCurrentPaxNumberMenosUno = iCurrentPaxNumber - 1;

            if (cmbTypeCard.SelectedIndex <= 0)
                return;
            btnAccept.Text = "Aceptar";
            ListItem item = (ListItem)cmbTypeCard.SelectedItem;
            CleanValues();
            HideAndShowCaptureControls(iCurrentPaxNumberMenosUno, item);
            SaveCurrentPaxFormPayment();
        }
        private void HideAndShowCaptureControls(int iCurrentPaxNumberMenosUno, ListItem item)
        {
            txtNumberCardCTS.PasswordChar = new char();
            switch (item.Value)
            {
                case "CASH":
                    txtNumberCardCTS.Text = string.Empty;
                    txtNumberCardCTS.Visible = false;
                    lblCardNumberCTS.Visible = false;

                    txtDigitoSeguridad.Visible = false;
                    cmbMesVencimiento.Visible = false;
                    cmbAnioVencimiento.Visible = false;
                    txtNombreTarjetahabiente.Visible = false;
                    lblDigitoSeguridad.Visible = false;
                    lblMesVencimiento.Visible = false;
                    lblAnioVencimiento.Visible = false;
                    lblNombreTarjetahabiente.Visible = false;
                    break;
                case "CH":
                case "TR":
                case "TP":
                    switch (item.Value)
                    {
                        case "TP":
                            lblCardNumberCTS.Text = "Número de tarjeta";
                            txtNumberCardCTS.MaxLength = 16;
                            txtNumberCardCTS.PasswordChar = '·';
                            txtNumberCardCTS.Font = new Font("Symbol", 9F, FontStyle.Regular);
                            break;
                        default:
                            lblCardNumberCTS.Text = "Número de cuenta";
                            txtNumberCardCTS.MaxLength = 4;
                            txtNumberCardCTS.PasswordChar = '·';
                            txtNumberCardCTS.Font = new Font("Symbol", 9F, FontStyle.Regular);
                            break;
                    }
                    lblCardNumberCTS.Visible = true;
                    if (item.Value != "TP")
                    {
                        if (string.IsNullOrEmpty(ChargesPerService.DKActual))
                        {
                            ChargesPerService.RecuperarDK();
                        }
                        WsMyCTS wsServ = new WsMyCTS();

                        MyCTS.Services.ValidateDKsAndCreditCards.GetTranferCheckNumber data = new MyCTS.Services.ValidateDKsAndCreditCards.GetTranferCheckNumber();
                        data = wsServ.GetTranferCheckNumberMyCTS(ChargesPerService.DKActual);
                        txtNumberCardCTS.Text = data.ct_banc_cbr;
                    }
                    else
                    {
                        txtNumberCardCTS.Text = String.Empty;
                    }
                    txtNumberCardCTS.Visible = true;
                    txtDigitoSeguridad.Visible = false;
                    cmbMesVencimiento.Visible = false;
                    cmbAnioVencimiento.Visible = false;
                    txtNombreTarjetahabiente.Visible = false;
                    lblDigitoSeguridad.Visible = false;
                    lblMesVencimiento.Visible = false;
                    lblAnioVencimiento.Visible = false;
                    lblNombreTarjetahabiente.Visible = false;
                    break;
                default:
                    lblCardNumberCTS.Text = "Número de tarjeta";
                    txtNumberCardCTS.Visible = true;
                    lblCardNumberCTS.Visible = true;
                    txtNumberCardCTS.PasswordChar = '·';
                    txtNumberCardCTS.Font = new Font("Symbol", 9F, FontStyle.Regular);

                   
                        txtDigitoSeguridad.Visible = true;
                        cmbMesVencimiento.Visible = true;
                        cmbAnioVencimiento.Visible = true;
                        txtNombreTarjetahabiente.Visible = true;
                        lblDigitoSeguridad.Visible = true;
                        lblMesVencimiento.Visible = true;
                        lblAnioVencimiento.Visible = true;
                        lblNombreTarjetahabiente.Visible = true;
                        btnAccept.Text = "Aplicar cargo en línea";
                  

                    switch (((ListItem)cmbTypeCard.SelectedItem).Value)
                    {
                        case "AX":
                            txtNumberCardCTS.MaxLength = 16;
                            txtDigitoSeguridad.MaxLength = 4;
                            txtNumberCardCTS.PasswordChar = '·';
                            txtNumberCardCTS.Font = new Font("Symbol", 9F, FontStyle.Regular);
                            break;
                        default:
                            txtNumberCardCTS.MaxLength = 16;
                            txtDigitoSeguridad.MaxLength = 3;
                            txtNumberCardCTS.PasswordChar = '·';
                            txtNumberCardCTS.Font = new Font("Symbol", 9F, FontStyle.Regular);
                            break;
                    }
                    break;
            }
        }

        private void CleanValues()
        {
            txtNumberCardCTS.Text = String.Empty;
            txtDigitoSeguridad.Text = String.Empty;
            txtNombreTarjetahabiente.Text = String.Empty;
        }

        private void txtDigitoSeguridad_Leave(object sender, EventArgs e)
        {
            SaveCurrentPaxFormPayment();
        }

        private void txtGenericoDatosTarjeta_Leave(object sender, EventArgs e)
        {
            if (cmbTypeCard.SelectedItem.ToString() != "- Selecciona Forma de Pago -")
            {
                if (((ListItem)cmbTypeCard.SelectedItem).Text2.Equals("CCAC") || ((ListItem)cmbTypeCard.SelectedItem).Text2.Equals("CCPV") || ((ListItem)cmbTypeCard.SelectedItem).Text2.Equals("CCTD"))
                {
                    if (ValidarTarjetaCTS(((TextBox)sender).Text, (TextBox)sender))
                    {
                        SaveCurrentPaxFormPayment();
                    }
                }
                else
                {
                    SaveCurrentPaxFormPayment();
                }
            }
            else
            {
                MessageBox.Show("Debe de seleccionar una forma de pago", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SaveCurrentPaxFormPayment()
        {
            int iCurrentPaxNumberMenosUno = iCurrentPaxNumber - 1;
            if (lstDatosTarjeta == null)
                return;

            if (lstDatosTarjeta.Count > iCurrentPaxNumberMenosUno)
            {
                if (cmbTypeCard.SelectedItem != null && cmbTypeCard.SelectedIndex > 0)
                    if (((ListItem)cmbTypeCard.SelectedItem).Text2 != null)
                    {
                        lstDatosTarjeta[iCurrentPaxNumberMenosUno].TipoTarjeta = ((ListItem)cmbTypeCard.SelectedItem).Text2;
                        lstDatosTarjeta[iCurrentPaxNumberMenosUno].TipoTarjetaSabre = ((ListItem)cmbTypeCard.SelectedItem).Value;
                    }

                if (lstDatosTarjeta[iCurrentPaxNumberMenosUno].TipoTarjeta == null)
                    return;

                if (!lstDatosTarjeta[iCurrentPaxNumberMenosUno].TipoTarjeta.Equals("CA"))
                {
                    lstDatosTarjeta[iCurrentPaxNumberMenosUno].NumeroTarjeta = txtNumberCardCTS.Text;

                    if (!lstDatosTarjeta[iCurrentPaxNumberMenosUno].TipoTarjeta.Equals("TR") && !lstDatosTarjeta[iCurrentPaxNumberMenosUno].TipoTarjeta.Equals("CH") && !lstDatosTarjeta[iCurrentPaxNumberMenosUno].TipoTarjeta.Equals("CCTC"))
                    {
                        if ((Meses)cmbMesVencimiento.SelectedItem != null)
                            lstDatosTarjeta[iCurrentPaxNumberMenosUno].MesVencimiento = ((Meses)cmbMesVencimiento.SelectedItem).Value;
                        if (cmbAnioVencimiento.SelectedItem != null)
                            lstDatosTarjeta[iCurrentPaxNumberMenosUno].AnioVencimiento = cmbAnioVencimiento.SelectedItem.ToString().Substring(2);

                        lstDatosTarjeta[iCurrentPaxNumberMenosUno].CodigoSeguridad = txtDigitoSeguridad.Text;
                        lstDatosTarjeta[iCurrentPaxNumberMenosUno].NombreTitular = txtNombreTarjetahabiente.Text;
                    }
                }
            }
        }


        private bool ValidarTarjetaCTS(string sNumberCardCTS, TextBox txtGenerico)
        {
            try
            {
                WsMyCTS wsServ = new WsMyCTS();
                BuildElectronicTicketContract getDK = new BuildElectronicTicketContract();
                GetInfoPassengerByPNR getPNR = new GetInfoPassengerByPNR();
                var respuesta = getPNR.GetInfoPassengerPNR(recLoc);
                ucFirstValidations.DK = respuesta.CustomerIdentifier;
                MyCTS.Services.ValidateDKsAndCreditCards.ClientCreditCard clientCreditCard = wsServ.GetClientCreditCardNumber(sNumberCardCTS, ucFirstValidations.DK);

                if (string.IsNullOrEmpty(sNumberCardCTS))
                {
                    this.Focus();
                    MessageBox.Show("Debes ingresar un número de tarjeta. Ingrese", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtGenerico.Text = string.Empty;
                    return false;
                }
                if (!string.IsNullOrEmpty(sNumberCardCTS))
                {
                    string creditCard = wsServ.GetCreditCardNumberCTS(txtNumberCardCTS.Text);
                    if (!string.IsNullOrEmpty(creditCard))
                    {
                        this.Focus();
                        MessageBox.Show("Debes ingresar un número de tarjeta diferente a una de CTS. Reingrese", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtGenerico.Text = string.Empty;
                        return false;
                    }

                    if (string.IsNullOrEmpty(creditCard))
                    {

                        string clientCreditCardNumber = wsServ.GetClientCreditCardNumberATT(txtNumberCardCTS.Text);
                        if (string.IsNullOrEmpty(clientCreditCardNumber))
                        {
                            if (ValidateCreditCardNumber)
                            {
                                // No hace nada
                            }
                        }
                        else
                            if (clientCreditCard.CreditCardNumber != txtNumberCardCTS.Text)
                            {
                                MessageBox.Show("El número de tarjeta ingresado pertenece a un cliente diferente, ingrese un número de tarjeta válido", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtNumberCardCTS.Focus();
                                return false;
                            }

                    }
                }
            }
            catch (Exception ex)
            {
                this.Focus();
                MessageBox.Show("Error al validar tarjeta. Reintente");
                txtGenerico.Text = string.Empty;
                return false;
            }
            return true;
        }

        private bool ValidateCreditCardNumber
        {
            get
            {
                var typoCard = "";
                WsMyCTS wsServ = new WsMyCTS();

                MyCTS.Services.ValidateDKsAndCreditCards.ClientCreditCard infoCreditCard = wsServ.GetClientCreditCardNumberByClient(ucFirstValidations.DK);

                cmbTypeCard.Text = cmbTypeCard.Text.Equals("AX - TC AMEX") ? "AX - TC AMEX" : "AIR";
                if (cmbTypeCard.Text == "AX - TC AMEX")
                {
                    typoCard = "AMEX";
                }

                if (!string.IsNullOrEmpty(infoCreditCard.CreditCardNumber))
                {
                    if (!infoCreditCard.CreditCardNumber.Equals(txtNumberCardCTS.Text))
                    {
                        string numberCardShow = infoCreditCard.CreditCardNumber.Substring(infoCreditCard.CreditCardNumber.Length - 4, 4).PadLeft(infoCreditCard.CreditCardNumber.Length, 'X');
                        if ((cmbTypeCard.Text.Equals("AX - TC AMEX") || cmbTypeCard.Text.Trim().Equals("VI - TC VISA") || cmbTypeCard.Text.Trim().Equals("VI - TD VISA") || cmbTypeCard.Text.Equals("CA - TC MASTERCARD") || cmbTypeCard.Text.Equals("CA - TD MASTERCARD")) && infoCreditCard.Type != "AIR")
                        {
                            typoCard = "EBTA";
                            DialogResult yesNo = MessageBox.Show("El número de tarjeta capturado no corresponde a la tarjeta de tipo " + typoCard +
                            " ligada al cliente DK: " + ucFirstValidations.DK + ".\nEl número de tarjeta correcto para la forma de pago " + infoCreditCard.Type +
                            " es: (" + numberCardShow + ").\n\n¿Desea continuar con la emisión?", Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (yesNo.Equals(DialogResult.Yes))
                            {
                                DeterminaValidacionGeneracionCargo();
                            }
                            else
                            {
                                txtNumberCardCTS.Text = string.Empty;
                                txtNumberCardCTS.Focus();
                                return false;
                            }
                        }
                        else
                        {
                            typoCard = "AIRPLUS";

                            MessageBox.Show("El número de tarjeta capturado no corresponde a la tarjeta de tipo " + typoCard +
                                " ligada al cliente DK: " + ucFirstValidations.DK + ".\nEl número de tarjeta correcto para la forma de pago " + typoCard +
                                " es: (" + numberCardShow + ").", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtNumberCardCTS.Focus();
                            return false;
                        }
                        return true;
                    }
                    else
                    {
                        DeterminaValidacionGeneracionCargo();
                    }
                }
                else
                    DeterminaValidacionGeneracionCargo();
                return true;
            }
        }

        private void DeterminaValidacionGeneracionCargo()
        {

            ucServicesFeePayApply.OrigenTipo = ChargesPerService.OrigenTipoCargo.Hoteles;

            if (!IsValidBussinesRules)
            {
                ucServicesFeePayApply.lstDatosTarjeta = new List<CreditCardInfo>();
                //ucServicesFeePayApply.lstDatosTarjeta2 = new List<CreditCardInfo>();
              
                    IsAmountZero();
                    if (!ValidarDatosTarjeta())
                    {
                        this.Focus();
                        MessageBox.Show("La forma de pago contiene algunos campos vacíos", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if (!ValidaLongitudTarjeta())
                    {
                        this.Focus();
                        MessageBox.Show("Una de las tarjetas ingresadas no contiene el numero de digitos necesario", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        //if (lstDatosTarjeta[i].Activo == true && lstDatosTarjeta[i].MontoCargo != 0)
                        //{
                        //    lstDatosTarjeta[i].OrigenVenta = "B";
                        //    lstDatosTarjeta[i].PNR = recLoc;
                        //    ucServicesFeePayApply.lstDatosTarjeta.Add(lstDatosTarjeta[i]);
                        //}
                    }
            }
        }

        private void IsAmountZero()
        {
            decimal dcMontoNoCero = 0;
            Decimal.TryParse(txtMontoCargo.Text, out dcMontoNoCero);
            txtMontoCargo.Text = dcMontoNoCero.ToString();
        }


        private bool ValidarDatosTarjeta()
        {
            ListItem tipoTarjeta = ((ListItem)cmbTypeCard.SelectedItem);

            if (((tipoTarjeta.Text2.Equals("CCAC") || tipoTarjeta.Text2.Equals("CCPV")) || tipoTarjeta.Text2.Equals("CCTD")) && (String.IsNullOrEmpty(txtNumberCardCTS.Text)))
            {
                return false;
            }
            return true;
        }

        private bool ValidaLongitudTarjeta()
        {
            ListItem tipoTarjeta = ((ListItem)cmbTypeCard.SelectedItem);

            if (Decimal.Parse(txtMontoCargo.Text) > 0)
            {
                if (tipoTarjeta.Text2.Equals("CCAC") || tipoTarjeta.Text2.Equals("CCPV") || tipoTarjeta.Text2.Equals("CCTD") || tipoTarjeta.Text2.Equals("CCTC"))
                {
                    if (txtNumberCardCTS.Text.Length < 15)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public int seleccionaMes()
        {
            int fechMes = 0;
            if (cmbMesVencimiento.Text == "Enero")
                fechMes = 1;
            if (cmbMesVencimiento.Text == "Febrero")
                fechMes = 2;
            if (cmbMesVencimiento.Text == "Marzo")
                fechMes = 3;
            if (cmbMesVencimiento.Text == "Abril")
                fechMes = 4;
            if (cmbMesVencimiento.Text == "Mayo")
                fechMes = 5;
            if (cmbMesVencimiento.Text == "Junio")
                fechMes = 6;
            if (cmbMesVencimiento.Text == "Julio")
                fechMes = 7;
            if (cmbMesVencimiento.Text == "Agosto")
                fechMes = 8;
            if (cmbMesVencimiento.Text == "Septiembre")
                fechMes = 9;
            if (cmbMesVencimiento.Text == "Octubre")
                fechMes = 10;
            if (cmbMesVencimiento.Text == "Noviembre")
                fechMes = 11;
            if (cmbMesVencimiento.Text == "Diciembre")
                fechMes = 12;
            return fechMes;
        }

        private void LoadFormPaymentCodes()
        {
            List<ListItem> listFOP = CatCreditCardsCodesBL.GetFOPCTSList();

            foreach (ListItem FOPItem in listFOP)
            {
                ListItem litem = new ListItem();
                litem.Text = string.Format("{0} - {1}", FOPItem.Value, FOPItem.Text);
                litem.Value = FOPItem.Value;
                litem.Text2 = FOPItem.Text2;
                cmbTypeCard.Items.Add(litem);

            }
            cmbTypeCard.SelectedIndex = 0;
        }       

    }
}
