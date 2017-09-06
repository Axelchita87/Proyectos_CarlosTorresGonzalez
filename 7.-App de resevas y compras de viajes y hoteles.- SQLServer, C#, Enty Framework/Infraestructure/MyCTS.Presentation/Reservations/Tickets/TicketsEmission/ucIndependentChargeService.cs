using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Forms.UI;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;
using MyCTS.Services;
using MyCTS.Services.Contracts;
using MyCTS.Services.ValidateDKsAndCreditCards;
using System.Linq;

namespace MyCTS.Presentation
{
    public partial class ucIndependentChargeService : CustomUserControl
    {
        public static string nameSecondLevel = string.Empty;
        public static string level1 = string.Empty;
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
        private int indexImage = 0;
        int iCurrentPaxNumber = 1;
        private Parameter activateFormOfPaymentCS = null;
        private Parameter activateOldRemarkCS = null;
        private List<RuleAndPassenger> RuleAndPax = null;
        private List<GetCorporativeFeesRules> indexList = null;
        private List<BannerImage> imageList = null;
        public static List<CreditCardInfo> lstDatosTarjeta = null;
        private static bool UsuarioValidoParaCargosPorServicio = false;
        OTATravelItinerary.OTATravelItineraryObject myObject = null;
        public static int cmbFecMes = 0;
        public static List<string> Boletos=null;
        public static bool bajoCosto = false;
        private bool paxNum = false;
        private InterJetProcessObserver _processObserver;
        private InterJetBillEmissionFormHandler _handler;
        private bool creditCard = false;

        private Hashtable Session
        {
            get
            {
                if (this.Parameter != null)
                {
                    InterJetSession session = (InterJetSession)this.Parameter;
                    return session.Session;
                }
                else
                {
                    return new Hashtable();
                }
            }
        }

        private InterJetTicket CurrentTicket
        {
            get
            {
                if (this.Session.Count > 0)
                {
                    InterJetTicket ticket = (InterJetTicket)this.Session["CurrentTicket"];
                    return ticket;
                }
                else
                {
                    return new InterJetTicket();
                }
            }
        }

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

        private InterJetBillEmissionFormHandler Handler
        {
            get
            {
                this._handler = new InterJetBillEmissionFormHandler
                {
                    CurrentUserControl = this,
                    Timer = this.timer1,
                    Loading = this.loadingPictureBox,
                };
                return this._handler;
            }
        }

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

        /// <summary>
        /// Descripcion: Calcula el cargo por servicio en base a los 
        ///              corporativos y sus DK's
        /// Creación:    Noviembre-Diciembre 09 , Modificación: 20-05-2010
        /// Cambio:      Forma de pago para cadad monto   , Solicito: Guillermo Granados
        /// Autor:       Angel Trejo
        /// </summary>
        public ucIndependentChargeService()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            this.LastControlFocus = btnAccept;
            TipoCargo = ChargesPerService.OrigenTipoCargo.Independiente;

            try
            {
                lstDatosTarjeta.Clear();
            }
            catch (Exception ex)
            {
                string sError = ex.Message;
            }

            UsuarioValidoParaCargosPorServicio = UsuarioValidoCargosPorServicio();

            if (!UsuarioValidoParaCargosPorServicio)
            {
                btnAccept.Text = "Aceptar";
                btnContinue.Visible = false;
            }
        }

        /// <summary>
        /// Calcula el cargo por servicio con los parametros de la emision
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucIndependentChargeService_Load(object sender, EventArgs e)
        {
            CommandsAPI2.send_MessageToEmulator("REALIZANDO VALIDACIONES, FAVOR DE ESPERAR...");
            DeterminaValidacionPreviaGeneralCargo();
            ChargesPerService.DKActual = string.Empty;



            ////va hacia el web services
            //string[] names = nameSecondLevel.Split('/');

            //WsMyCTS wsServ = new WsMyCTS();
            //string[] templistCardsSecondLevel = null;
            //if (names[1].Contains(" "))
            //{
            //    string[] tempnames = names[1].Split(' ');
            //    templistCardsSecondLevel = wsServ.GetCreditCardsSecondLevel(tempnames[0], names[0], level1.Trim());
            //}
            //else
            //{
            //    templistCardsSecondLevel = wsServ.GetCreditCardsSecondLevel(names[1], names[0], level1.Trim());
            //}
            //var listCardsFirstLevel = wsServ.GetCreditCardsFirstLevel(level1.Trim());
            //string cc = string.Empty;
            //var listCardsSecondLevel = templistCardsSecondLevel;
            //var listCardsSecondLevelTemp = new List<string>();
            //var listCardsFirstLevelTemp = new List<string>();
            //foreach (string creditCard in listCardsSecondLevel)
            //{
            //    try
            //    {
            //        string[] items = creditCard.Split(new string[] { "*#*" }, System.StringSplitOptions.RemoveEmptyEntries);
            //        if (items.Length > 0)
            //            if (!string.IsNullOrEmpty(items[0]))
            //            {
            //                cc = string.Concat(items[0], "-", items[1], " ", items[2], "/", items[3], " ", items[14], "-" + items[4]);
            //                listCardsSecondLevelTemp.Add(cc);
            //                items = null;
            //            }
            //    }
            //    catch { }
            //}

            //foreach (string creditCard in listCardsFirstLevel)
            //{
            //    try
            //    {
            //        string[] items = creditCard.Split(new string[] { "*#*" }, System.StringSplitOptions.RemoveEmptyEntries);

            //        if (!items[0].Equals("*"))
            //        {
            //            cc = items[0].Replace('*', '-');
            //            listCardsFirstLevelTemp.Add(string.Concat(cc, " ", items[1]));
            //        }
            //    }
            //    catch { }
            //}

            //List<string> CreditCardsFirstLevel = listCardsFirstLevelTemp;
            // List<string> CreditCardsSecondLevel = listCardsSecondLevelTemp;

            //FirstLevel
            //new InterJetProfileBL().GetProfileCreditCard();

            //First Level
            List<Entities.InterJetProfileCreditCard> lstFirst = new InterJetProfileBL().GetProfileCreditCard(level1.Trim());
            
            string[] name = nameSecondLevel.Split('2');
            string fName = string.Empty;

            fName = name[0].Replace(" ", string.Empty);

            //Second Level
            Entities.InterJetProfile profile = new InterJetProfileBL().GetProfile(fName, level1.Trim());
            if(profile != null)
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
                        cmbMesVencimiento.SelectedIndex = DateTime.Parse(form.Handler.SelectedCreditCardCard.ExpirationDate.ToShortDateString()).Month -1;
                        cmbAnioVencimiento.SelectedIndex = cmbAnioVencimiento.FindStringExact(DateTime.Parse(form.Handler.SelectedCreditCardCard.ExpirationDate.ToShortDateString()).Year.ToString());
                        //CVV dato con mascara.
                        txtDigitoSeguridad.Text = new string( Common.toDecrypt(form.Handler.SelectedCreditCardCard.CVV).Where(char.IsDigit).ToArray()) ;
                        //Nombre del titular.
                        txtNombreTarjetahabiente.Text = form.Handler.SelectedCreditCardCard.titular;
                        creditCard = true;
                    }
                    //SetSelectedCreditCardFromProfile(form.SelectedCreditCardCard);
                }
            }


            //frmProfilesCreditCards.flag = true;
            //frmProfilesCreditCards pCreditCards = new frmProfilesCreditCards(lstFirst,profile);
            //pCreditCards.Focus();
            //pCreditCards.Show();
        }

        /// <summary...,.->
        /// Funciones que se extraen los datos para calcular el monto del cargo 
        /// por servicio
        /// </summary>
        private void LoadData()
        {
            try
            {
                activateFormOfPaymentCS = ParameterBL.GetParameterValue("ActivateFormOfPaymentCS");
                activateOldRemarkCS = ParameterBL.GetParameterValue("ActivateOldRemarkCS");
                if (!ucMenuReservations.ChargeService)
                {
                    string chargePerService = activeStepsCorporativeQC.CorporativeQualityControls[0].ChargePerService;
                    if (chargePerService.Equals(Resources.TicketEmission.Constants.ACTIVE))
                    {
                        txtPax1.Focus();
                    }
                    else if (ucQREX.Qrex)
                    {
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTICKETEMISSIONBUILDCOMMAND);
                    }
                    else
                    {
                        chargeperservice = string.Empty;
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCBILLINGADRESS);
                    }
                }
                else
                {
                    txtPax1.Focus();
                }
            }
            catch (Exception ex)
            {
                string sError = ex.Message;
            }
        }

        /// <summary>
        /// Muestra u oculta los controles
        /// </summary>
        /// <param name="status">Estado de la propiedad visible de los controles</param>
        private void ShowControls(bool status)
        {
            foreach (Control kontrol in this.Controls)
            {
                if (kontrol.Name != "lblChargePerService" &&
                    kontrol.Name != "smartTextBox1" &&
                    kontrol.Name != "loadingPictureBox" &&
                    kontrol.Name != "lblEsperar")
                    kontrol.Visible = status;
                if (status && kontrol.TabIndex == 72)
                    kontrol.Visible = !status;
            }

        }

        /// <summary>
        /// Permite notificar que el proceso asíncrono ha terminado
        /// </summary>
        /// <param name="asyncResult">Objeto con referencia de tipo AsyncCallback</param>
        private void OnCompleted(IAsyncResult asyncResult)
        {
            AsyncResult result = (AsyncResult)asyncResult;
            SenderCallBack scb = (SenderCallBack)result.AsyncDelegate;
            scb.EndInvoke(asyncResult);
            ActivateCalculateChargeService();
        }

        /// <summary>
        /// Activa la funcion que calcula el cargo por servicio
        /// </summary>
        private void ActivateCalculateChargeService()
        {
            if (this.InvokeRequired)
            {
                SenderCallBack scb = new SenderCallBack(ActivateCalculateChargeService);
                this.Invoke(scb);
            }
            else
            {
                for (int j = 0; j < 9; j++)
                {
                    if (lstDatosTarjeta != null)
                        if (lstDatosTarjeta.Count > 8)
                            break;

                    CreditCardInfo nvoDatoTarjeta = new CreditCardInfo();
                    nvoDatoTarjeta.Activo = false;
                    if (lstDatosTarjeta == null)
                    {
                        lstDatosTarjeta = new List<CreditCardInfo>();
                    }
                    lstDatosTarjeta.Add(nvoDatoTarjeta);
                }

                timer1.Enabled = false;
                lblEsperar.Visible = false;
                loadingPictureBox.Visible = false;
                ShowControls(true);

                if (!UsuarioValidoParaCargosPorServicio)
                {
                    btnAccept.Text = "Aceptar";
                    btnContinue.Visible = false;
                }

                activateFormOfPaymentCS = ParameterBL.GetParameterValue("ActivateFormOfPaymentCS");
                activateOldRemarkCS = ParameterBL.GetParameterValue("ActivateOldRemarkCS");
                CalculateChargeService();

                if (RuleAndPax.Count > 0)
                {
                    JustificationRule();
                    if (ucTicketsEmissionInstructions.wayPayment.Equals("rdoMiscelaneous")
                    || ucTicketsEmissionInstructions.wayPayment.Equals("rdoMixPayment"))
                    {
                        foreach (Control rdo in this.Controls)
                        {
                            if (rdo is TableLayoutPanel)
                            {
                                rdo.Visible = true;
                            }
                            else if (rdo is Label && rdo.TabIndex.Equals(72))
                            {
                                rdo.Location = new Point(rdo.Location.X + 60, rdo.Location.Y);
                            }
                        }
                    }
                }
                else
                {
                    ShowImages();
                }
                LoadFormPaymentCodes();
                setFOPChargeService();
            }
        }

        private void ShowImages()
        {
            try
            {
                imageList = new List<BannerImage>();
                imageList = GetBannerImageBL.GetBannerImageList("2");
                if (imageList.Count > 0)
                {
                    byte[] buffer = imageList[indexImage].Content;
                    MemoryStream image = new MemoryStream(buffer);
                    TimerBanerImages.Interval = 5000;
                    TimerBanerImages.Enabled = true;
                    if (indexImage == imageList.Count - 1)
                        indexImage = 0;
                    else
                        indexImage++;
                }
            }
            catch { }
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


        /// <summary>
        /// Acciones que se ejecutan al dar click en el boton Aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            //Validacion de existencia del PNR
            if (!ValidaExistenciaPNRActivo())
            {
                MessageBox.Show("No se pudo encontrar un PNR activo, favor de volver a ingresarlo", "No fue posible validar PNR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                return;
            }
            //Comparativo de PNR Coincida con el ingresado al principio

            //Validacion formas de pago
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
            if (cmbTypeCard.Text == "TR - TRANSFERENCIA")
            {
                DeterminaValidacionGeneracionCargo();
            }
            else
            {
                if (cmbTypeCard.Text == "CASH - EFECTIVO")
                {
                    DeterminaValidacionGeneracionCargo();
                }
                else
                {
                    if (cmbTypeCard.Text == "CH - CHEQUE")
                    {
                        DeterminaValidacionGeneracionCargo();
                    }
                    else
                    {
                        ///Validación para la FoP TP - TC UATP para que al validar las tarjetas, no valide
                        ///todos los campos existentes en la plantilla aunque esten ocultos. Para cualquier
                        ///otro caso se validan todos los campos en la plantilla.
                        if (cmbTypeCard.Text == "TP - TC UATP")
                        {
                            if (ValidateCreditCardNumber)
                            {
                            }
                        }
                        else
                        {

                            if ((string.IsNullOrEmpty(cmbTypeCard.Text) || string.IsNullOrEmpty(txtDigitoSeguridad.Text) ||
                               string.IsNullOrEmpty(txtNombreTarjetahabiente.Text) || string.IsNullOrEmpty(cmbTypeCard.Text) ||
                               string.IsNullOrEmpty(cmbMesVencimiento.Text) || string.IsNullOrEmpty(cmbAnioVencimiento.Text) ||
                               string.IsNullOrEmpty(cmbTypeCard.Text) || string.IsNullOrEmpty(ddlNumBoleto.Text)))
                            {
                                MessageBox.Show("¡Debes ingresar todos los campos!");
                            }
                            else
                            {
                                if ((!string.IsNullOrEmpty(txtPax1.Text) || !string.IsNullOrEmpty(txtPax2.Text) ||
                                     !string.IsNullOrEmpty(txtPax3.Text) || !string.IsNullOrEmpty(txtPax4.Text) ||
                                     !string.IsNullOrEmpty(txtPax5.Text) || !string.IsNullOrEmpty(txtPax6.Text) ||
                                     !string.IsNullOrEmpty(txtPax7.Text) || !string.IsNullOrEmpty(txtPax8.Text) ||
                                     !string.IsNullOrEmpty(txtPax9.Text)))
                                {
                                    //Se validan las fechas ingresadas por el usuario. No deben ser menor a los de la fecha actual
                                    int cmboFecYear = Convert.ToInt32(DateTime.Now.Year);
                                    int cmboFecMes = Convert.ToInt32(DateTime.Now.Month);
                                    int cmbFecYear = Convert.ToInt32(cmbAnioVencimiento.Text);
                                    if (cmbTypeCard.Text == "- Selecciona Forma de Pago -")
                                    {
                                        MessageBox.Show("¡Ingrese la Forma de Pago!", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        cmbFecMes = seleccionaMes();
                                        if (cmbFecYear < cmboFecYear)
                                        {
                                            MessageBox.Show("¡Datos de vigencia de la tarjeta invalido, verifica el año!", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            cmbAnioVencimiento.Focus();

                                        }
                                        else if (cmbFecMes < cmboFecMes & cmboFecYear == cmbFecYear)
                                        {
                                            MessageBox.Show("¡Datos de vigencia de la tarjeta invalido, verifica el mes!", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            cmbMesVencimiento.Focus();
                                        }
                                        else
                                        {
                                            //Valida las tarjetas ingresadas
                                            if (!string.IsNullOrEmpty(txtNumberCardCTS.Text))
                                            {
                                                ChargesPerService.RecuperarDK();
                                                //Llama al webServices ValidateDKsAndCreditCards para buscar la tarjeta ingresada en la base de datos
                                                WsMyCTS wsServ = new WsMyCTS();

                                                MyCTS.Services.ValidateDKsAndCreditCards.ClientCreditCard clientCreditCard = wsServ.GetClientCreditCardNumber(txtNumberCardCTS.Text, ChargesPerService.DKActual);

                                                if (string.IsNullOrEmpty(txtNumberCardCTS.Text))
                                                {
                                                    MessageBox.Show("Debes ingresar un número de tarjeta. Ingrese", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    txtNumberCardCTS.Text = string.Empty;
                                                    txtNumberCardCTS.Focus();
                                                }
                                                if (!string.IsNullOrEmpty(txtNumberCardCTS.Text))
                                                {
                                                    string creditCard = wsServ.GetCreditCardNumberCTS(txtNumberCardCTS.Text);
                                                    if (!string.IsNullOrEmpty(creditCard))
                                                    {
                                                        this.Focus();
                                                        MessageBox.Show("Debes ingresar un número de tarjeta diferente a una de CTS. Reingrese", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        txtNumberCardCTS.Text = string.Empty;
                                                        txtNumberCardCTS.Focus();
                                                    }

                                                    if (string.IsNullOrEmpty(creditCard))
                                                    {
                                                        string clientCreditCardNumber = wsServ.GetClientCreditCardNumberATT(txtNumberCardCTS.Text);
                                                        if (string.IsNullOrEmpty(clientCreditCardNumber))
                                                        {
                                                            if (ValidateCreditCardNumber)
                                                            {
                                                                 //No hace nada
                                                            }
                                                        }
                                                        else
                                                            if (clientCreditCard.CreditCardNumber != txtNumberCardCTS.Text)
                                                            {
                                                                MessageBox.Show("El número de tarjeta ingresado pertenece a un cliente diferente, ingrese un número de tarjeta válido", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                txtNumberCardCTS.Text = string.Empty;
                                                                txtNumberCardCTS.Focus();
                                                            }
                                                    }
                                                }
                                                if (txtNumberCardCTS.Text == clientCreditCard.CreditCardNumber & ChargesPerService.DKActual == clientCreditCard.Client)
                                                {
                                                    DeterminaValidacionGeneracionCargo();
                                                }
                                            }
                                            else if (string.IsNullOrEmpty(txtNumberCardCTS.Text))
                                            {
                                                MessageBox.Show("Debes ingresar un número de tarjeta. Ingrese", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                txtNumberCardCTS.Text = string.Empty;
                                                txtNumberCardCTS.Focus();
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    ucServicesFeePayApply.lstDatosTarjeta = new List<CreditCardInfo>();
                                    //ucServicesFeePayApply.lstDatosTarjeta2 = new List<CreditCardInfo>();
                                    ContinueWithoutPay();
                                }
                            }
                        }
                    }
                }
            }
        }

        private bool AplicarCargos()
        {
            if (this.lblEsperar.InvokeRequired)
            {
                AplicarCargosDelegate aplicar = new AplicarCargosDelegate(AplicarCargos);
                this.Invoke(aplicar, null);
            }
            else
            {
                if (!IsValidBussinesRules)
                {
                    ucServicesFeePayApply.lstDatosTarjeta = new List<CreditCardInfo>();
                    for (int i = 0; i < lstDatosTarjeta.Count; i++)
                    {
                        IsAmountZero(lstDatosTarjeta[i], i);
                        //if (!ValidarDatosTarjeta(lstDatosTarjeta[i]) && lstDatosTarjeta[i].Activo == true)
                        //{
                        //    this.Focus();
                        //    MessageBox.Show("La forma de pago del PAX " + (i + 1) + ".1 contiene algunos campos vacíos", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    return false;
                        //}

                        if (!ValidaLongitudTarjeta(lstDatosTarjeta[i]))
                        {
                            this.Focus();
                            MessageBox.Show("Una de las tarjetas ingresadas no contiene el numero de digitos necesario", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;

                        }
                        else
                        {
                            if (lstDatosTarjeta[i].Activo == true && lstDatosTarjeta[i].MontoCargo != 0)
                            {
                                lstDatosTarjeta[i].OrigenVenta = "B";
                                lstDatosTarjeta[i].PNR = recLoc;
                                ucServicesFeePayApply.lstDatosTarjeta.Add(lstDatosTarjeta[i]);
                            }
                        }
                    }
                    ApplyServicesFee();
                }
            }
            return true;
        }

        private bool ValidarCamposVacios()
        {
            if (cmbTypeCard.SelectedIndex > 0)
            {
                ListItem lstTipoTarjeta = (ListItem)cmbTypeCard.SelectedItem;

                if (String.IsNullOrEmpty(ddlNumBoleto.Text))
                    return false;

                if (lstTipoTarjeta.Text2.Equals("CCAC") || lstTipoTarjeta.Text2.Equals("CCPV") || lstTipoTarjeta.Text2.Equals("CCTD"))
                {
                    if (String.IsNullOrEmpty(txtNumberCardCTS.Text))
                        return false;

                    if (UsuarioValidoParaCargosPorServicio)
                    {
                        if (String.IsNullOrEmpty(txtDigitoSeguridad.Text))
                            return false;
                        if (String.IsNullOrEmpty(txtNombreTarjetahabiente.Text))
                            return false;
                    }
                }
            }
            return true;
        }

        private bool ValidarDatosTarjeta(CreditCardInfo dtsTarjeta)
        {
            if (dtsTarjeta == null)
                return false;

            if (dtsTarjeta.TipoTarjeta == null)
                return false;

            if (dtsTarjeta.MontoCargo > 0)
            {
                if (dtsTarjeta.TipoTarjeta.Equals("CCAC") || dtsTarjeta.TipoTarjeta.Equals("CCPV") || dtsTarjeta.TipoTarjeta.Equals("CCTD"))
                {
                    if (String.IsNullOrEmpty(dtsTarjeta.NumeroTarjeta))
                    {
                        return false;
                    }
                    if (UsuarioValidoParaCargosPorServicio)
                    {
                        if (String.IsNullOrEmpty(dtsTarjeta.CodigoSeguridad) || String.IsNullOrEmpty(dtsTarjeta.NombreTitular))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private bool ValidaLongitudTarjeta(CreditCardInfo dtsTarjeta)
        {
            if (dtsTarjeta.MontoCargo > 0)
            {
                if (dtsTarjeta.TipoTarjeta.Equals("CCAC") || dtsTarjeta.TipoTarjeta.Equals("CCPV") || dtsTarjeta.TipoTarjeta.Equals("CCTC") || dtsTarjeta.TipoTarjeta.Equals("CCTD"))
                {
                    if (dtsTarjeta.NumeroTarjeta.Length < 15)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Acciones que se ejecutan al dar click en el boton Crear Nueva Regla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateNewRule_Click(object sender, EventArgs e)
        {
            if (!IsValidBussinesRules)
            {
                CreditCardInfo dtTarjeta = new CreditCardInfo();
                ChargesPerService.BuilCommandToSend("", "", 0, dtTarjeta, TipoCargo, recLoc);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCNEWFEERULE);
            }
        }

        #region=====Methods Class=====

        /// <summary>
        /// Llamado al servicio web que va extraer los datos del
        /// record localizador del cual se este emitiendo un boleto
        /// </summary>
        public void GetValuesWebServices()
        {
            using (WSSessionSabre obj = new WSSessionSabre())
            {
                obj.OpenConnection();
                if (obj.IsConnected)
                {
                    myObject = new OTATravelItinerary().TravelItineraryMethod(obj.ConversationId, obj.IPcc, obj.SecurityToken, recLoc);
                    if (myObject != null)
                        if (myObject.Status)
                            InsertDetailsPNR();
                }
            }
        }

        /// <summary>
        /// Inserta en la tabla DetailsPNR los datos obtenidos por 
        /// el WEBSTERD
        /// </summary>
        private void InsertDetailsPNR()
        {
            for (int i = 0; i < myObject.PaxNumberList.Count; i++)
                for (int j = 0; j < myObject.DepartureAirportList.Count; j++)
                {
                    SetDetailsPNRBL.AddDetailsPNR(recLoc, myObject.DepartureAirportList[j], myObject.ArrivalAirportList[j],
                        myObject.DepartureDateTimeList[j], myObject.ArrivalDateTimeList[j], myObject.MarketingAirlineList[j], myObject.FlightNumberList[j],
                        Convert.ToDateTime(myObject.DepartureDateList[j]), myObject.AirlineRefList[j], myObject.DepartureDateList[0], myObject.Location_DK, Convert.ToDecimal(myObject.PaxNumberList[i]),
                        myObject.PassengerTypeList[i], myObject.GivenNameList[i], myObject.SurnameList[i],
                        myObject.SegmentType, myObject.FareBasis, myObject.PCC, myObject.IDGroup, null);
                }
        }

        /// <summary>
        /// Obtiene el Target LastDateToPurchase via API 
        /// </summary>
        private void GetLastDateToPurchase()
        {
            string sabreAnswer = string.Empty;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive("WPNCS", 0, 0);
            }
            int row = 0;
            int col = 0;
            CommandsQik.searchResponse(sabreAnswer, "LAST DAY TO PURCHASE", ref row, ref col);
            if (row > 0)
            {
                CommandsQik.CopyResponse(sabreAnswer, ref lastDateToPurcahse, row, 47, 5);
            }
        }

        /// <summary>
        /// Obtinen el monto de los boletos que se van a emitir de acuerdo al
        /// numero de segmentos, aerolínea con que se emite y otros aspectos; 
        /// esto se hace via API
        /// </summary>
        private void GetBaseFare()
        {
            string send = string.Empty;
            string sabreAnswer = string.Empty;
            string tarifa = string.Empty;
            string tourCode = string.Empty;
            string phase35375 = string.Empty;

            if (ucTicketsEmissionInstructions.ticketType == "rdoPhase35375")
                phase35375 = ucPhase35375Tickets.Phase35375;
            else
                phase35375 = string.Empty;

            if (!string.IsNullOrEmpty(ucTicketsEmissionInstructions.quaNegociated))
                tarifa = string.Concat(Resources.Constants.CROSSLORAINE, "P", ucTicketsEmissionInstructions.quaNegociated);
            else if (!string.IsNullOrEmpty(ucTicketsEmissionInstructions.corporateID))
                tarifa = string.Concat(Resources.Constants.CROSSLORAINE, "I", ucTicketsEmissionInstructions.corporateID);
            else if (!string.IsNullOrEmpty(ucTicketsEmissionInstructions.accountCode))
                tarifa = string.Concat(Resources.Constants.CROSSLORAINE, "AC*", ucTicketsEmissionInstructions.accountCode);

            if (!string.IsNullOrEmpty(ucTicketsEmissionInstructions.tourCodeAgreements))
                tourCode = string.Concat(Resources.Constants.CROSSLORAINE, ucTicketsEmissionInstructions.tourCodeAgreements, ucTicketsEmissionInstructions.tourCode);

            if (string.IsNullOrEmpty(ucTicketsEmissionInstructions.bySegments) && string.IsNullOrEmpty(ucTicketsEmissionInstructions.byNames) && (string.IsNullOrEmpty(tarifa) && string.IsNullOrEmpty(phase35375) && string.IsNullOrEmpty(tourCode)))
                send = string.Concat(Resources.Constants.COMMANDS_WP, "A", ucTicketsEmissionInstructions.Airline, tarifa, tourCode, ucTicketsEmissionInstructions.byNames, ucTicketsEmissionInstructions.bySegments, ucTicketsEmissionInstructions.quarrelType, phase35375);
            else
                send = string.Concat(Resources.Constants.COMMANDS_WP, "A", ucTicketsEmissionInstructions.Airline, tarifa, tourCode, ucTicketsEmissionInstructions.byNames, ucTicketsEmissionInstructions.bySegments, ucTicketsEmissionInstructions.quarrelType, phase35375);

            int row = 0;
            int col = 0;
            MyCTS.Presentation.Parameters.TimeExtendedAPI = true;

            try
            {
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    sabreAnswer = objCommand.SendReceive(send);
                }
            }
            catch { }

            MyCTS.Presentation.Parameters.TimeExtendedAPI = false;
            CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.BASE_FARE, ref row, ref col);

            if (row != 0 || col != 0)
            {
                CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.TOTAL, ref row, ref col, 1, 4, 30, 64);

                if (row != 0 || col != 0)
                {
                    row = row + 1;
                    CommandsQik.CopyResponse(sabreAnswer, ref baseFare, row, 5, 14);
                    baseFare = baseFare.Replace(Resources.TicketEmission.Constants.MXN, Resources.TicketEmission.Constants.SPACE).Trim();
                }

                row = 0;
                col = 0;
                CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.EQUIV_AMT, ref row, ref col, 1, 4, 15, 40);

                if (row != 0 || col != 0)
                {
                    row = row + 1;
                    baseFare = string.Empty;
                    CommandsQik.CopyResponse(sabreAnswer, ref baseFare, row, 19, 14);
                    baseFare = baseFare.Replace(Resources.TicketEmission.Constants.MXN, Resources.TicketEmission.Constants.SPACE).Trim();
                }
                else
                {
                    CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.BASE_FARE, ref row, ref col, 1, 4, 1, 20);

                    if (row != 0 || col != 0)
                    {
                        row = row + 1;
                        baseFare = string.Empty;
                        CommandsQik.CopyResponse(sabreAnswer, ref baseFare, row, 5, 14);
                        baseFare = baseFare.Replace(Resources.TicketEmission.Constants.MXN, Resources.TicketEmission.Constants.SPACE).Trim();
                    }
                }
            }
        }

        /// <summary>
        /// Obtiene los valores que ingresa el usuario al momento que va a emitir 
        /// un boleto
        /// </summary>
        private void GetValuesFromTicketEmissionInstructions()
        {
            ticketType = ucTicketsEmissionInstructions.ticketType;
            formOfPayment = ucTicketsEmissionInstructions.wayPayment;
            fireType = ucTicketsEmissionInstructions.fareType;
            ticketIssuingCarrierTarget = ucTicketsEmissionInstructions.Airline;

            switch (ticketType)
            {
                case "rdoNormalTicket":
                    ticketType = "Boleto Normal";
                    break;
                case "rdoPhase35375":
                    ticketType = "Fase 3.5 y 3.75";
                    break;
                case "rdoPhaseIV":
                    ticketType = "Fase IV";
                    break;
            }

            switch (formOfPayment)
            {
                case "rdoAmericanExpress":
                    formOfPayment = "Tarjeta de crédito (Aut. Sistema).";
                    break;
                case "rdoCreditCard":
                    formOfPayment = "Tarjeta de crédito (Aut. Manual).";
                    break;
                case "rdoMixPayment":
                    formOfPayment = "Pago Mixto.";
                    break;
                case "rdoMiscelaneous":
                    formOfPayment = "Miscelaneo o Electrónico.";
                    break;
                case "rdoCash":
                    formOfPayment = "Efectivo.";
                    break;
            }

            bysegments = ucTicketsEmissionInstructions.bySegments;

            if (!string.IsNullOrEmpty(bysegments))
            {
                string[] aux = bysegments.Split(new char[] { '/' });
                string[] aux2 = aux[0].Split(new char[] { '-' });
                aux2[0] = aux2[0].Replace("‡S", "");
                int segment = 0;
                int totalSegment = 0;

                if (aux2.Length == 2)
                {
                    if (Convert.ToInt32(aux2[0]) > Convert.ToInt32(aux2[1]))
                    {
                        int auxiliar = Convert.ToInt32(aux2[0]);
                        aux2[0] = aux2[1];
                        aux2[1] = Convert.ToString(auxiliar);
                    }
                    segment = (Convert.ToInt32(aux2[1]) - Convert.ToInt32(aux2[0]) + 1);
                    segment = segment + aux.Length - 1;
                    totalSegment = segment;
                }
                else
                {
                    totalSegment = aux.Length;
                }

                bysegments = Convert.ToString(totalSegment);
            }
        }

        /// <summary>
        /// Establece los colores iniciales para los SmartTextBox
        /// </summary>
        private void SetColorTextBox()
        {
            txtPax1.BackColor = SystemColors.Control;
            txtPax2.BackColor = SystemColors.Control;
            txtPax3.BackColor = SystemColors.Control;
            txtPax4.BackColor = SystemColors.Control;
            txtPax5.BackColor = SystemColors.Control;
            txtPax6.BackColor = SystemColors.Control;
            txtPax7.BackColor = SystemColors.Control;
            txtPax8.BackColor = SystemColors.Control;
            txtPax9.BackColor = SystemColors.Control;
        }

        /// <summary>
        /// Se obtiene el monto del cargo por servicio conforme a la información 
        /// extraida del web service y la que proporciona el usuario
        /// </summary>
        /// <summary>
        /// Se obtiene el monto del cargo por servicio conforme a la información 
        /// extraida del web service y la que proporciona el usuario
        /// </summary>
        private void CalculateChargeService()
        {
            string location_dk = ChargesPerService.DKActual;
            string[] temp = ucQualitiesByPax.arraypassengers;
            string ticketIssuer = Login.Agent;
            string typePax = string.Empty;
            string dayTime = ucQualitiesByPax.DayTime.ToString("dd/MM/yyyy");
            string wekDay = Convert.ToString(ucQualitiesByPax.DayTime.DayOfWeek);

            switch (wekDay)
            {
                case "Sunday":
                    wekDay = "Domingo";
                    break;
                case "Monday":
                    wekDay = "Lunes";
                    break;
                case "Tuesday":
                    wekDay = "Martes";
                    break;
                case "Wednesday":
                    wekDay = "Miércoles";
                    break;
                case "Thursday":
                    wekDay = "Jueves";
                    break;
                case "Friday":
                    wekDay = "Viernes";
                    break;
                case "Saturday":
                    wekDay = "Sábado";
                    break;
            }

            string distributionChanel = string.Empty;
            string bussinesUnit = string.Empty;
            string advancedPurchase = string.Empty;
            string marketingAirline = string.Concat(ucTicketsEmissionInstructions.tourCode, " ", ucTicketsEmissionInstructions.tourCodeAgreements);

            try
            {
                if (myObject != null
                    && myObject.DepartureDateList != null
                    && myObject.DepartureDateList.Count > 0
                    && !string.IsNullOrEmpty(lastDateToPurcahse))
                    advancedPurchase = (Convert.ToString(Convert.ToDateTime(myObject.DepartureDateList[0]) - Convert.ToDateTime(lastDateToPurcahse)).Substring(0, 2)).TrimEnd(new char[] { '.' });
            }
            catch { }

            int count = 0;
            RuleAndPax = new List<RuleAndPassenger>();

            int sPoSicionPax = 9;

            // aqui definimos el tamaño maximo
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                string sabreAnswer = objCommand.SendReceive("TN");
                char[] charSeparators = new char[] { '\n' };
                string[] sConteoPasajeros = sabreAnswer.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                if (sConteoPasajeros.Length - 1 < 9)
                {
                    sPoSicionPax = sConteoPasajeros.Length - 1;
                }
            }

            for (int i = 0; i < sPoSicionPax; i++)
            {
                int PosicionEnfrente = i + 1;
                CalculateChargeControl(PosicionEnfrente, PosicionEnfrente + ".1");
            }
            txtPax1.Focus();
        }

        private void CalculateChargeControl(int iPax, string sNumberLabel)
        {
            string[] sNumeroPasagero = sNumberLabel.Split('.');
            int iPasajeroPosicion = iPax - 1;
            TextBox txtCtrl = new TextBox();
            Label LabelPaxCtrl = new Label();
            try
            {
                txtCtrl = (TextBox)this.Controls.Find("txtPax" + iPax, true)[0];
                LabelPaxCtrl = (Label)this.Controls.Find("lblPax" + iPax, true)[0];
                LabelPaxCtrl.Text = string.Concat("Pax ", sNumberLabel, ":");
            }
            catch (Exception)
            {
            }
            txtCtrl.Enabled = true;
            this.InitialControlFocus = txtCtrl;
            txtCtrl.BackColor = Color.White;
            txtCtrl.Focus();

            lstDatosTarjeta[iPasajeroPosicion].PaxNumber = iPax;
            lstDatosTarjeta[iPasajeroPosicion].Activo = true;
        }

        /// <summary>
        /// Valida el rango de las fecha para verificar si la regla esta
        /// en el rango para ser emitida
        /// </summary>
        /// <param name="start">Fecha de inicio de regla</param>
        /// <param name="expiration">fecha de expiracion de la regla</param>
        /// <returns></returns>
        private bool ValidateStartAndExpirationDate(string start, string expiration)
        {
            String dtInitialDate = "01/01/1753 12:00:00 a.m.";

            if (start == dtInitialDate)
                start = string.Empty;
            if (expiration == dtInitialDate)
                expiration = string.Empty;

            if (!string.IsNullOrEmpty(start) && Convert.ToDateTime(start) > ucQualitiesByPax.DayTime)
                return false;

            if (!string.IsNullOrEmpty(expiration) && Convert.ToDateTime(expiration) < ucQualitiesByPax.DayTime)
                return false;

            return true;
        }

        /// <summary>
        /// Valida que el monto se encuentre en el rango especificado por la 
        /// regla de cargo por servicio
        /// </summary>
        /// <param name="baseFare">Monto</param>
        /// <returns></returns>
        private bool ValidateBaseFare(string baseFare)
        {
            if (string.IsNullOrEmpty(indexList[0].BaseFare))
                return true;
            else
            {
                try
                {
                    string[] fares = indexList[0].BaseFare.Split(new char[] { 'a' });
                    fares[0] = fares[0].Trim();
                    fares[1] = fares[1].Trim();
                    if (Convert.ToDouble(fares[0]) <= Convert.ToDouble(baseFare) && Convert.ToDouble(fares[1]) >= Convert.ToDouble(baseFare))
                        return true;
                    else
                        return false;
                }
                catch
                { return true; }
            }
        }

        /// <summary>
        /// Valida el la hora en que se esta emitiendo
        /// </summary>
        private bool ValidateTimeRange
        {
            get
            {
                if (string.IsNullOrEmpty(indexList[0].TimeRange))
                    return true;
                else
                {
                    try
                    {
                        string timeRange = indexList[0].TimeRange;
                        string[] times = timeRange.Split(new char[] { '-' });
                        times[0] = times[0].Trim();
                        times[1] = times[1].Trim();
                        DateTime time1 = Convert.ToDateTime(times[0]);
                        DateTime time2 = Convert.ToDateTime(times[1]);
                        TimeSpan diference = time2 - time1;
                        string totalMinutes = Convert.ToString(diference);
                        int rol = 0;
                        if (totalMinutes.Substring(0, 1) == "-")
                            rol = 1440 - ((Convert.ToInt32(totalMinutes.Substring(1, 2)) * 60) + Convert.ToInt32(totalMinutes.Substring(4, 2)));
                        else
                            rol = (Convert.ToInt32(totalMinutes.Substring(0, 2)) * 60) + Convert.ToInt32(totalMinutes.Substring(3, 2));

                        List<string> horas = new List<string>();
                        horas.Add(times[0]);
                        int hora = time1.Hour;
                        int minuto = time1.Minute;
                        string strHora = string.Empty;
                        string strMinuto = string.Empty;

                        for (int i = 0; i < rol; i++)
                        {
                            if (minuto == 59)
                            {
                                minuto = 0;
                                if (hora == 23)
                                    hora = 0;
                                else
                                    hora = hora + 1;
                            }
                            else
                                minuto = minuto + 1;

                            if (hora < 10)
                                strHora = string.Concat("0", Convert.ToString(hora));
                            else
                                strHora = Convert.ToString(hora);

                            if (minuto < 10)
                                strMinuto = string.Concat("0", Convert.ToString(minuto));
                            else
                                strMinuto = Convert.ToString(minuto);

                            horas.Add(string.Concat(strHora, ":", strMinuto));
                        }

                        string search = ucQualitiesByPax.DayTime.ToString("HH:mm");

                        foreach (string timeToSearch in horas)
                        {
                            if (timeToSearch == search)
                            {
                                return true;
                            }
                        }
                        return false;
                    }
                    catch
                    {
                        return true;
                    }
                }
            }
        }

        /// <summary>
        /// Muetra un resumen de la regla que se ha empleado
        /// </summary>
        private void JustificationRule()
        {
            string aux = string.Empty;
            string aux2 = string.Empty;
            for (int j = 0; j < RuleAndPax.Count; j++)
            {
                aux2 = string.Concat("[", RuleAndPax[j].Rule, "]");
                if (!aux.Contains(aux2))
                    aux = string.Concat(aux, aux2);
            }
            aux = aux.Replace("[", "/");
            aux = aux.Replace("]", "/");
            string[] rules = aux.Split(new char[] { '/' });
            List<string> listAux = new List<string>();
            for (int k = 0; k < rules.Length; k++)
                if (!string.IsNullOrEmpty(rules[k]))
                    listAux.Add(rules[k]);

            string[] pax = new string[listAux.Count];

            for (int j = 0; j < listAux.Count; j++)
            {
                for (int i = 0; i < RuleAndPax.Count; i++)
                {
                    if (listAux[j] == Convert.ToString(RuleAndPax[i].Rule))
                    {
                        if (!string.IsNullOrEmpty(pax[j]))
                            pax[j] = string.Concat(pax[j], ", ", RuleAndPax[i].PaxNumber);
                        else
                            pax[j] = RuleAndPax[i].PaxNumber;
                    }
                }
            }

            for (int m = 0; m < listAux.Count; m++)
            {
                List<GetInformationRuleApplied> listInformation = new List<GetInformationRuleApplied>();
                listInformation = GetInformationRuleAppliedBL.GetInfoRule(Convert.ToInt32(listAux[m]), false);

                if (!string.IsNullOrEmpty(information))
                    information = string.Concat(information, "\n", "\n");

                information = string.Concat(information, "Se aplicó la regla ", listAux[m], " para los pasajeros ", pax[m], " por los siguientes criterios:", "\n", "\n", "Corporativo: ", ucFirstValidations.Attribute1);

                if (!string.IsNullOrEmpty(listInformation[0].Value2) && !string.IsNullOrEmpty(listInformation[0].Target))
                    for (int i = 0; i < listInformation.Count; i++)
                        information = string.Concat(information, "\n", listInformation[i].Target, ": ", listInformation[i].Value2);

                information = string.Concat(information, "\n", "\n", "El monto se calculó a partir de un ", listInformation[0].DefaultFee, "% de la tarifa base más $", listInformation[0].DefaultMount.ToString("0.00"), " adicionales.");
            }
            information = string.Concat(information, "\n\n", "Si la cantidad es negociable puede cambiarla por la que usted decida", " y puede especificar el monto para los pasajeros que no contengan dicho dato");
            string[] informe = information.Split(new char[] { '\n' });
        }

        /// <summary>
        /// Reglas del negocio aplicadas a este user control
        /// </summary>
        private bool IsValidBussinesRules
        {
            get
            {
                bool isValid = true;

                for (int i = 1; i < 10; i++)
                {
                    SmartTextBox txtCtrl = (SmartTextBox)this.Controls.Find("txtPax" + i, true)[0];
                    if (CurrencyFormats.ValidaDecimales(txtCtrl.Text))
                        return false;
                }

                if (cmbTypeCard.SelectedIndex.Equals(0) && (!string.IsNullOrEmpty(txtPax1.Text) || !string.IsNullOrEmpty(txtPax1.Text) ||
                    !string.IsNullOrEmpty(txtPax2.Text) || !string.IsNullOrEmpty(txtPax3.Text) || !string.IsNullOrEmpty(txtPax4.Text) ||
                    !string.IsNullOrEmpty(txtPax5.Text) || !string.IsNullOrEmpty(txtPax6.Text) || !string.IsNullOrEmpty(txtPax7.Text) ||
                    !string.IsNullOrEmpty(txtPax8.Text) || !string.IsNullOrEmpty(txtPax9.Text)))
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

        /// <summary>
        /// Envio del comando de cargo por servicio con los montos correspondientes
        /// </summary>
        private void OrderChargeForService()
        {
            string numPax = string.Empty;
            string mount = string.Empty;
            string sabreCommand = "5.";
            int aux = 0;
            int counter = 0;

            foreach (Control txt in this.Controls)
            {
                if (txt is TextBox && ((TextBox)txt).Enabled && !string.IsNullOrEmpty(((TextBox)txt).Text) && txt.Name != "smartTextBox1")
                {
                    mount = txt.Text;
                    foreach (Control lbl in this.Controls)
                    {
                        if (lbl is Label && ((Label)lbl).TabIndex == txt.TabIndex + 10)
                        {
                            aux = lbl.Text.LastIndexOf(".");
                            numPax = lbl.Text.Substring(aux - 2, 2);
                            numPax = numPax.Trim();
                            aux = Convert.ToInt32(numPax);
                            numPax = (aux < 10) ? string.Concat("0", Convert.ToString(aux)) : Convert.ToString(aux);
                            break;
                        }
                    }
                    counter++;
                    if (counter == 4 || counter == 7)
                        sabreCommand = string.Concat(sabreCommand, ";5.</C23-", numPax, "*", mount, "/>");
                    else
                        sabreCommand = string.Concat(sabreCommand, "</C23-", numPax, "*", mount, "/>");
                }
            }
            string[] sabreSend = null;
            if (!string.IsNullOrEmpty(sabreCommand) && !sabreCommand.Equals("5."))
            {
                sabreSend = sabreCommand.Split(new char[] { ';' });
                foreach (string send in sabreSend)
                {
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        objCommand.SendReceiveEmission(send);
                    }
                }
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

        #endregion

        private void PictureBoxBanner_DoubleClick(object sender, EventArgs e)
        {
            if (imageList.Count <= 0)
                return;
            try
            {
                System.Diagnostics.Process.Start(imageList[indexImage].Url);
            }
            catch { }
        }

        private void TimerBanerImages_Tick(object sender, EventArgs e)
        {
            ShowImages();
        }

        #region ====== TEXTBOX CHANGED ======

        private void cmbTypeCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnAccept_Click(sender, e);
            }
            else if (e.KeyData == Keys.Escape)
            {
                CleanRemarks();
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
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

        #endregion //TEXTBOX CHANGED

        private void setFOPChargeService()
        {
            if (string.IsNullOrEmpty(ucFormPayment.C28))
                return;
            if (!ucFormPayment.C28.Contains("CLIENTE"))
                return;
            if (!MessageBox.Show("¿Deseas ingresar la misma forma de pago del boleto para el cargo por servicio?", Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information).Equals(DialogResult.Yes))
                return;

            for (int i = 1; i < cmbTypeCard.Items.Count - 1; i++)
            {
                if (((ListItem)cmbTypeCard.Items[i]).Value.Equals(ucFormPayment.creditCardName))
                {
                    cmbTypeCard.SelectedIndex = i;
                    HideAndShowCaptureControls(i, (ListItem)cmbTypeCard.Items[i]);
                    break;
                }
            }

            txtNumberCardCTS.Text = ucFormPayment.NumberCard;
            if (!String.IsNullOrEmpty(ucFormPayment.DateExpired))
            {
                int iMes = Convert.ToInt32(ucFormPayment.DateExpired.PadLeft(4, '0').Substring(0, 2));
                int iAnio = Convert.ToInt32(ucFormPayment.DateExpired.PadLeft(4, '0').Substring(2, 2));

                for (int i = 0; i < cmbMesVencimiento.Items.Count; i++)
                {
                    Meses ComboMes = (Meses)cmbMesVencimiento.Items[i];
                    if (ComboMes.Value == iMes.ToString("00"))
                    {
                        cmbMesVencimiento.SelectedIndex = i;
                    }
                }

                for (int i = 0; i < cmbAnioVencimiento.Items.Count; i++)
                {
                    if (cmbAnioVencimiento.Items[i].Equals((2000 + iAnio)))
                    {
                        cmbAnioVencimiento.SelectedIndex = i;
                    }
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

        private void CargaNumeroDeBoletos()
        {
            try
            {
                ddlNumBoleto.DataSource = GetTicketsPNR.GetTicketsByPNR(recLoc);
            }
            catch (Exception ex)
            {
                String sError = ex.Message;
            }
        }

        private static void RegresaMonto(ref List<Decimal> lstMontos, string sMonto)
        {
            Decimal dcValorPaso = new Decimal();
            Decimal.TryParse(sMonto, out dcValorPaso);

            if (dcValorPaso > 0)
            {
                lstMontos.Add(dcValorPaso);
            }
        }

        private void txtNombreTarjetahabiente_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            ucServicesFeePayApply.lstDatosTarjeta = new List<CreditCardInfo>();
            //ucServicesFeePayApply.lstDatosTarjeta2 = new List<CreditCardInfo>();
            ContinueWithoutPay();
        }

        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                if (MessageBox.Show("¿Esta seguro que desea regresar sin aplicar ningún cargo?", Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information).Equals(DialogResult.Yes))
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
            }
            if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }
        }

        private void ContinueWithoutPay()
        {
            CleanRemarks();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }

        private void txtGenerico_GotFocus(object sender, EventArgs e)
        {
            TextBox t;
            t = (TextBox)this.ActiveControl;

            if (t.Name.StartsWith("txtPax"))
            {
                iCurrentPaxNumber = int.Parse(t.Name.Substring(t.Name.Length - 1, 1));
                GetCurrentPaxNumber(iCurrentPaxNumber - 1);
                lblImport.Text = "Cargo por servicio Pax " + iCurrentPaxNumber + ".1";

                foreach (Control kontrol in this.Controls)
                {
                    if (kontrol.Name.StartsWith("txtPax"))
                    {
                        kontrol.GotFocus -= new System.EventHandler(this.txtGenerico_GotFocus);
                    }
                }

                foreach (Control kontrol in this.Controls)
                {
                    if (kontrol.Name.StartsWith("txtPax"))
                    {
                        if (!kontrol.Name.Equals(t.Name))
                        {
                            kontrol.GotFocus += new System.EventHandler(this.txtGenerico_GotFocus);
                        }
                    }
                }
            }
        }

        private void txtGenerico_LostFocus(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (t.Name.StartsWith("txtPax"))
            {
                t.Text = CurrencyFormats.AgregaDosDecimales(t.Text);

                foreach (Control kontrol in this.Controls)
                {
                    if (kontrol.Name.StartsWith("txtPax"))
                    {
                        kontrol.LostFocus -= new System.EventHandler(this.txtGenerico_LostFocus);
                    }
                }

                foreach (Control kontrol in this.Controls)
                {
                    if (kontrol.Name.StartsWith("txtPax"))
                    {
                        if (!kontrol.Name.Equals(t.Name))
                        {
                            kontrol.LostFocus += new System.EventHandler(this.txtGenerico_LostFocus);
                        }
                    }
                }
            }
        }

        private void cmbGenerico_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveCurrentPaxFormPayment();
        }

        private void chkSameForAll_Click(object sender, EventArgs e)
        {
            CheckBox chkSame = (CheckBox)sender;

            if (!chkSame.Checked)
            {
                if (lstDatosTarjeta != null)
                {
                    if (lstDatosTarjeta.Count > 0)
                    {
                        if (MessageBox.Show("Todos los datos seran borrados ¿Deseas continuar?", Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information).Equals(DialogResult.Yes))
                        {
                            for (int i = 0; i < lstDatosTarjeta.Count; i++)
                            {
                                lstDatosTarjeta[i] = new CreditCardInfo();
                            }
                            GetCurrentPaxNumber(0);
                        }
                    }
                }
            }
            else
            {
                if (lstDatosTarjeta != null)
                {
                    if (lstDatosTarjeta.Count > 0)
                    {
                        if (MessageBox.Show("Esta operación sobrescribirá los demás datos capturados ¿Deseas continuar?", Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information).Equals(DialogResult.Yes))
                        {
                            FillPaxFormPaymentList();
                            GetCurrentPaxNumber(0);
                        }
                    }
                }
            }
        }

        private void FillPaxFormPaymentList()
        {
            if (chkSameForAll.Checked)
            {
                for (int i = 0; i < lstDatosTarjeta.Count; i++)
                {
                    if (lstDatosTarjeta[0].TipoTarjeta != null && lstDatosTarjeta[0].TipoTarjeta != "- Selecciona Forma de Pago -")
                    {
                        lstDatosTarjeta[i].TipoTarjeta = lstDatosTarjeta[0].TipoTarjeta;
                        lstDatosTarjeta[i].TipoTarjetaSabre = lstDatosTarjeta[0].TipoTarjetaSabre;
                        lstDatosTarjeta[i].NumeroTarjeta = lstDatosTarjeta[0].NumeroTarjeta;
                        lstDatosTarjeta[i].CodigoSeguridad = lstDatosTarjeta[0].CodigoSeguridad;
                        lstDatosTarjeta[i].MesVencimiento = lstDatosTarjeta[0].MesVencimiento;
                        lstDatosTarjeta[i].AnioVencimiento = lstDatosTarjeta[0].AnioVencimiento;
                        lstDatosTarjeta[i].NombreTitular = lstDatosTarjeta[0].NombreTitular;
                    }
                    else
                    {
                        this.Focus();
                        MessageBox.Show("Debe de seleccionar una forma de pago, para el Pax 1.1", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        chkSameForAll.Checked = false;
                        break;
                    }
                }
            }
            else
            {
                this.Focus();
                chkSameForAll.Checked = false;
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

                lstDatosTarjeta[iCurrentPaxNumberMenosUno].Ticket = ddlNumBoleto.Text;

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

        private void GetCurrentPaxNumber(int iPaxNumber)
        {
            try
            {
                if (lstDatosTarjeta != null)
                {
                    if (lstDatosTarjeta.Count > 0 && lstDatosTarjeta.Count >= iPaxNumber)
                    {
                        if (lstDatosTarjeta[iPaxNumber].TipoTarjeta == null)
                        {
                            cmbTypeCard.SelectedIndex = 0;
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
                        }
                        else
                        {
                            for (int i = 1; i < cmbTypeCard.Items.Count; i++)
                            {
                                if (((ListItem)cmbTypeCard.Items[i]).Value.Equals(lstDatosTarjeta[iPaxNumber].TipoTarjetaSabre) && ((ListItem)cmbTypeCard.Items[i]).Text2.Equals(lstDatosTarjeta[iPaxNumber].TipoTarjeta))
                                {
                                    cmbTypeCard.SelectedIndex = i;
                                    HideAndShowCaptureControls(i, (ListItem)cmbTypeCard.Items[i]);
                                    break;
                                }
                            }

                            if (lstDatosTarjeta[iPaxNumber].TipoTarjeta == null)
                                return;

                            // Se tiene que buscar el valor dentro del combo
                            cleanNumBoleto();
                            for (int a = 0; a < Boletos.Count; a++)
                            {
                                if (Boletos[a].Contains("."))
                                {
                                    string boleto = string.Empty;
                                    boleto = Boletos[a].Substring(6, Boletos[a].Length - 6);
                                    ddlNumBoleto.Items.Add(boleto);
                                }
                                else
                                {
                                    ddlNumBoleto.Items.Add(Boletos[a]);
                                }

                            }
                            ddlNumBoleto.Text = lstDatosTarjeta[iPaxNumber].Ticket;

                            if (!lstDatosTarjeta[iPaxNumber].TipoTarjeta.Equals("CA"))
                            {
                                txtNumberCardCTS.Text = lstDatosTarjeta[iPaxNumber].NumeroTarjeta;
                                if (!lstDatosTarjeta[iPaxNumber].TipoTarjeta.Equals("TR") && !lstDatosTarjeta[iPaxNumber].TipoTarjeta.Equals("CH") && !lstDatosTarjeta[iPaxNumber].TipoTarjeta.Equals("CCTC"))
                                {
                                    txtDigitoSeguridad.Text = (creditCard) ? txtDigitoSeguridad.Text.Trim() : lstDatosTarjeta[iPaxNumber].CodigoSeguridad;
                                    txtNombreTarjetahabiente.Text = (creditCard) ? txtNombreTarjetahabiente.Text : lstDatosTarjeta[iPaxNumber].NombreTitular;
                                    if (creditCard)
                                        return;
                                    for (int i = 0; i < cmbMesVencimiento.Items.Count; i++)
                                    {
                                        Meses ComboMes = (Meses)cmbMesVencimiento.Items[i];
                                        if (ComboMes.Value == lstDatosTarjeta[iPaxNumber].MesVencimiento)
                                        {
                                            cmbMesVencimiento.SelectedIndex = i;
                                            break;
                                        }
                                    }

                                    for (int i = 0; i < cmbAnioVencimiento.Items.Count; i++)
                                    {
                                        if (((int)cmbAnioVencimiento.Items[i] - 2000).ToString() == lstDatosTarjeta[iPaxNumber].AnioVencimiento)
                                        {
                                            cmbAnioVencimiento.SelectedIndex = i;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                this.Focus();
                MessageBox.Show("Ha ocurrido un error al tratar de realizar la carga de los datos", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void txtGenericoDatosTarjeta_Leave(object sender, EventArgs e)
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

                if (!string.IsNullOrEmpty(infoCreditCard.CreditCardNumber) && !infoCreditCard.CreditCardNumber.Equals(txtNumberCardCTS.Text))
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
                    DeterminaValidacionGeneracionCargo();
                return true;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private readonly BackgroundWorker _waitingBackGroundWorker = new BackgroundWorker();

        /// <summary>
        /// Gets the waiting back ground worker.
        /// </summary>
        private BackgroundWorker WaitingBackGroundWorker
        {
            get { return _waitingBackGroundWorker; }
        }

        /// <summary>
        /// Handles the DoWork event of the WaitingBackGroundWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        private void WaitingBackGroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        /// <summary>
        /// Handles the RunWorkerCompleted event of the WaitingBackGroundWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void WaitingBackGroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.StopWatingBackGround();
            this.WaitingBackGroundWorker.Dispose();
        }

        /// <summary>
        /// Stops the wating back ground.
        /// </summary>
        public void StopWatingBackGround()
        {
            lblEsperar.Visible = false;
            loadingPictureBox.Visible = false;
            StopAnimation();
            this.WaitingBackGroundWorker.DoWork -= WaitingBackGroundWorker_DoWork;
            this.WaitingBackGroundWorker.RunWorkerCompleted -= WaitingBackGroundWorker_RunWorkerCompleted;
        }

        public void StopAnimation()
        {
            if (this.lblEsperar.InvokeRequired)
            {
                HideMessagesDelegate SendMessage = new HideMessagesDelegate(StopAnimation);
                this.Invoke(SendMessage, null);
            }
            else
            {
                lblEsperar.Visible = false;
                loadingPictureBox.Visible = false;
                this.lblEsperar.Text = String.Empty;
            }
        }

        public void HideControls()
        {
            if (this.lblEsperar.InvokeRequired)
            {
                HideMessagesDelegate hide = new HideMessagesDelegate(HideControls);
                this.Invoke(hide, null);
            }
            else
            {
                ShowControls(false);
                lblEsperar.Visible = true;
                loadingPictureBox.Visible = true;
            }
        }

        private void DeterminaValidacionPreviaGeneralCargo()
        {
            try
            {
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    string sabreAnswer = objCommand.SendReceive(ChargesPerService.PreguntasASabre.VERIFICAR_RESERVA);
                    CommandsQik.CopyResponse(sabreAnswer, ref nameSecondLevel, 2, 5, 50);
                    CommandsQik.CopyResponse(objCommand.SendReceive("*PDK"), ref level1, 1, 18, 50);
                    CommandsQik.CopyResponse(sabreAnswer, ref recLoc, 1, 1, 6);
                }

                switch (TipoCargo)
                {
                    case ChargesPerService.OrigenTipoCargo.FlujoAereo:
                        if (ValidacionPrevioCargoFlujoEmiteBoleto())
                        {
                            MuestraControlesCargoFlujo();
                        }
                        break;
                    case ChargesPerService.OrigenTipoCargo.BajoCosto:
                        if (ValidacionPrevioCargoBajoCosto())
                        {
                            //Muestra mascarilla CxS
                        }
                        break;
                    case ChargesPerService.OrigenTipoCargo.Independiente:
                        if (ChargesPerService.ValidacionPrevioCargoIndependiente())
                        {
                            BorrarRemarksContables borrar = new BorrarRemarksContables();

                            CargaControlesCargoIndependiente();

                            try
                            {
                                //string[] sBoletos = GetTicketsPNR.GetTicketsByPNR(recLoc);
                                //if (sBoletos.Length > 0)
                                //{
                                //    //ddlNumBoleto.DataSource = sBoletos;
                                //}
                                //else
                                //{
                                List<string> sBoletosBajoCosto = new List<string>();
                                Boletos = new List<string>();
                                int a = 1;
                                string nomBoleto = string.Empty;
                                bool cruzLorena = false;

                                // Cargamos los boletos de bajo costo
                                using (CommandsAPI objCommand = new CommandsAPI())
                                {
                                    // obtenemos lista de bolestos utilizando el *PAC
                                    string sabreAnswer = objCommand.SendReceive(ChargesPerService.PreguntasASabre.VERIFICAR_LINEA_CONTABLE);
                                    char[] cCaracterSeparador = { '\n' };
                                    string[] sRespuestaBajoCosto = sabreAnswer.Split(cCaracterSeparador, StringSplitOptions.RemoveEmptyEntries);
                                    bajoCosto = false;
                                    for (int i = 0; i < sRespuestaBajoCosto.Length; i++)
                                    {
                                        string[] sRespuestaBoletos = sRespuestaBajoCosto[i].Split('/');

                                        if (sRespuestaBoletos.Length > 1)
                                        {
                                            if (sRespuestaBoletos[0].Contains("4o") || sRespuestaBoletos[0].Contains("4O")
                                                || sRespuestaBoletos[0].Contains("Y4") || bajoCosto)
                                            {
                                                if (!sRespuestaBoletos[1].StartsWith("88") && !sRespuestaBoletos[1].StartsWith("99") 
                                                    && !sRespuestaBoletos[1].StartsWith("98"))
                                                {
                                                    if (ValidateRegularExpression.ValidateTenNumbers(sRespuestaBoletos[a]))
                                                        sBoletosBajoCosto.Add(sRespuestaBoletos[a]);
                                                    else
                                                    {
                                                        string[] nombre = sRespuestaBoletos[a].TrimStart().Split(' ');
                                                        if (nombre.Length > 1 && nombre[1].Contains("."))
                                                            sRespuestaBoletos[a] = nombre[1].Substring(0, 3) + " - ";
                                                    }
                                                    nomBoleto = sRespuestaBoletos[a] + nomBoleto;
                                                    if (a == 0)
                                                    {
                                                        if (nomBoleto.Count() > 7)
                                                        {
                                                            Boletos.Add(nomBoleto);
                                                        }
                                                        nomBoleto = string.Empty;
                                                        a++;
                                                    }
                                                    else
                                                    {
                                                        a = 0;
                                                    }
                                                }
                                                else
                                                {
                                                    if (a == 0)
                                                    {
                                                        a++;
                                                    }
                                                    else
                                                    {
                                                        a = 0;
                                                    }
                                                }
                                                bajoCosto = true;
                                            }
                                            else
                                            {
                                                bajoCosto = false;
                                                if (sRespuestaBoletos[0].Contains("‡"))
                                                {
                                                    string[] boleto = sRespuestaBoletos[0].Split('‡');
                                                    nomBoleto = boleto[1] + nomBoleto;
                                                }
                                                else if(cruzLorena)
                                                {
                                                    string[] nombre = sRespuestaBoletos[0].TrimStart().Split(' ');
                                                    if (nombre.Length > 1 && nombre[1].Contains("."))
                                                    {
                                                        sRespuestaBoletos[0] = nombre[1].Substring(0, 3) + " - ";
                                                        nomBoleto = sRespuestaBoletos[0] + nomBoleto;
                                                    }
                                                    Boletos.Add(nomBoleto);
                                                    nomBoleto = string.Empty;
                                                    cruzLorena = false;
                                                }
                                                else if (!cruzLorena)
                                                {
                                                    if (ValidateRegularExpression.ValidateTenNumbers(sRespuestaBoletos[1]))
                                                        nomBoleto = sRespuestaBoletos[1];
                                                    else
                                                    {
                                                        string[] nombre = sRespuestaBoletos[0].TrimStart().Split(' ');
                                                        if (nombre.Length > 1 && nombre[1].Contains("."))
                                                        {
                                                            sRespuestaBoletos[0] = nombre[1].Substring(0, 3) + " - ";
                                                            nomBoleto = sRespuestaBoletos[0] + nomBoleto;
                                                        }
                                                        if (nomBoleto.Count() > 7)
                                                        {
                                                            Boletos.Add(nomBoleto);
                                                            nomBoleto = string.Empty;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    int r = 0;
                                    int z = 0;
                                    for (int s = 0; s < Boletos.Count; s++)
                                    {

                                        if (Boletos[s].Contains("."))
                                            r++;
                                        else
                                            z++;

                                    }
                                    if (r != Boletos.Count && r > 0)
                                    {
                                        for (int c = 0; c < Boletos.Count; c++)
                                        {
                                            if (Boletos[c].Contains("."))
                                            {
                                                string boleto = Boletos[c].Substring(6, Boletos[c].Length - 6);
                                                Boletos[c] = boleto;
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                String sError = ex.Message;
                            }

                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                this.Focus();
                MessageBox.Show(ex.Message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
        }

        private void DeterminaValidacionGeneracionCargo()
        {
            switch (TipoCargo)
            {
                case ChargesPerService.OrigenTipoCargo.FlujoAereo:
                    if (ValidaGeneracionCargoFlujoEmiteBoleto())
                    {
                        AplicarCargoFlujoEmiteBoleto();
                    }
                    break;
                case ChargesPerService.OrigenTipoCargo.BajoCosto:
                    if (ValidaGeneracionCargoBajoCosto())
                    {
                        AplicarCargoBajoCosto();
                    }
                    break;
                case ChargesPerService.OrigenTipoCargo.Independiente:
                    if (ValidaGeneracionCargoIndependiente())
                    {
                        AplicarCargoIndependiente();
                    }
                    break;
            }
        }

        private bool ValidacionPrevioCargoFlujoEmiteBoleto()
        {
            return ValidacionPrevioCargoFlujo();
        }

        private bool ValidaGeneracionCargoFlujoEmiteBoleto()
        {
            string sabreAnswer = string.Empty;
            frmPreloading frm2 = new frmPreloading(this);
            frm2.Show();

            if (!ValidarCamposVacios())
            {
                this.Focus();
                return false;
            }
            SaveCurrentPaxFormPayment();

            return true;
        }

        private void AplicarCargoFlujoEmiteBoleto()
        {
            bool bCargosFallidos = AplicarCargos();
            if (bCargosFallidos == false)
            {
                loadingPictureBox.Visible = false;
                lblEsperar.Visible = true;
                lblEsperar.ForeColor = Color.Red;
            }
        }

        private bool ValidaGeneracionCargoIndependiente()
        {
            string sabreAnswer = string.Empty;
            frmPreloading frm2 = new frmPreloading(this);
            frm2.Show();

            if (!ValidarCamposVacios())
            {
                this.Focus();
                return false;
            }
            SaveCurrentPaxFormPayment();

            return true;
        }

        private void AplicarCargoIndependiente()
        {
            bool bCargosFallidos = AplicarCargos();
            if (bCargosFallidos == false)
            {
                loadingPictureBox.Visible = false;
                lblEsperar.Visible = true;
                lblEsperar.ForeColor = Color.Red;
            }
        }

        private bool ValidacionPrevioCargoBajoCosto()
        {
            return ValidacionPrevioCargoFlujo();
        }

        private bool ValidaGeneracionCargoBajoCosto()
        {
            return ValidacionPrevioCargoFlujo();
        }

        private void AplicarCargoBajoCosto()
        {
        }

        private bool ValidacionPrevioCargoFlujo()
        {
            int iRespuesta = 0;
            lstDatosTarjeta = GetPendingOnlinePayServicesBL.GetPendingOnlinePayServices(recLoc);

            if (lstDatosTarjeta.Count > 0)
            {
                String sCargosPreviosAplicados = String.Empty;

                string[] temp = ucQualitiesByPax.arraypassengers;
                int iTotalPsajeros = 0;
                if (temp == null)
                {
                    iTotalPsajeros = ucAllQualityControls.globalPaxNumber;
                }
                else
                {
                    iTotalPsajeros = temp.Length;
                }

                // Valida si alguno de los cargos previos realizados 
                for (int i = 0; i < lstDatosTarjeta.Count; i++)
                {
                    for (int j = 0; j < iTotalPsajeros; j++)
                    {
                        if (temp == null)
                        {
                            if (lstDatosTarjeta[i].PaxNumber == j + 1)
                            {
                                sCargosPreviosAplicados += "Pasajero: " + lstDatosTarjeta[i].PaxNumber + " Autorización: " + lstDatosTarjeta[i].NumeroAutorizacion + " Operación: " + lstDatosTarjeta[i].NumeroOperacion + Environment.NewLine;
                            }
                        }
                        else
                        {
                            if (lstDatosTarjeta[i].PaxNumber == Convert.ToInt32(temp[j].Substring(0, 1)))
                            {
                                sCargosPreviosAplicados += "Pasajero: " + lstDatosTarjeta[i].PaxNumber + " Autorización: " + lstDatosTarjeta[i].NumeroAutorizacion + " Operación: " + lstDatosTarjeta[i].NumeroOperacion + Environment.NewLine;
                            }
                        }
                    }
                }

                if (sCargosPreviosAplicados != String.Empty)
                    // Si tiene un cargo previo aplicado le indicamos si desea aplicar el pago anterior   
                    if (UsuarioValidoParaCargosPorServicio)
                    {
                        if (!MessageBox.Show("El PNR actual ya cuenta con cargos previos aplicados" + Environment.NewLine + "¿Desea realizar nuevos cargos? " + Environment.NewLine + sCargosPreviosAplicados, Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information).Equals(DialogResult.Yes))
                        {
                            // Si desea aplicarlo revisamos si se hizo para todos los pasarajeros
                            for (int i = 0; i < lstDatosTarjeta.Count; i++)
                            {
                                if (lstDatosTarjeta[i].NumeroAutorizacion == String.Empty)
                                {
                                    // En caso de que venga algun cargo con numero de autorizacion vacio bloquear los pasajeros que tengan cargo previo aplicado
                                    lstDatosTarjeta[i].Activo = true;
                                }
                                else
                                {
                                    lstDatosTarjeta[i].Activo = false;
                                    iRespuesta++;
                                }
                            }

                            for (int i = 0; i < lstDatosTarjeta.Count; i++)
                            {
                                if (lstDatosTarjeta[i].Activo == false)
                                {
                                    // Si estan todos se generan los remarks de sabre y se lanza a la pantalla de generacion de boletos
                                    ChargesPerService.BuilCommandToSend(lstDatosTarjeta[i].NumeroOperacion, lstDatosTarjeta[i].NumeroAutorizacion, lstDatosTarjeta[i].PaxNumber, lstDatosTarjeta[i], TipoCargo, recLoc);

                                    CleanRemarks();
                                }
                            }
                        }
                    }
                    else
                    {
                        Clean();
                    }
            }
            if (iRespuesta == lstDatosTarjeta.Count && iRespuesta > 0)
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void Clean()
        {
            if (lstDatosTarjeta != null)
            {
                if (lstDatosTarjeta.Count > 0)
                {
                    for (int j = 0; j < lstDatosTarjeta.Count; j++)
                    {
                        lstDatosTarjeta[j] = new CreditCardInfo();
                    }
                }
            }
        }

        public void MuestraControlesCargoFlujo()
        {
            lblEsperar.Visible = true;
            loadingPictureBox.Visible = true;
            ShowControls(false);
            timer1.Enabled = true;
            SenderCallBack scb = new SenderCallBack(LoadData);
            AsyncCallback callback = new AsyncCallback(OnCompleted);
            scb.BeginInvoke(callback, null);
            CargaAnios();
            CargarMeses();
        }

        public void CargaControlesCargoIndependiente()
        {
            lblEsperar.Visible = true;
            loadingPictureBox.Visible = true;
            ShowControls(false);
            timer1.Enabled = true;
            SenderCallBack scb = new SenderCallBack(LoadData);
            AsyncCallback callback = new AsyncCallback(OnCompleted);
            scb.BeginInvoke(callback, null);
            CargaAnios();
            CargarMeses();
        }

        private void IsAmountZero(CreditCardInfo dtsTarjeta, int iPaxNumber)
        {
            int iPaxFrontNumber = iPaxNumber + 1;
            TextBox txtCtrl = (TextBox)this.Controls.Find("txtPax" + iPaxFrontNumber, true)[0];
            decimal dcMontoNoCero = 0;
            Decimal.TryParse(txtCtrl.Text, out dcMontoNoCero);
            dtsTarjeta.MontoCargo = dcMontoNoCero;
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

        private void CleanValues()
        {
            txtNumberCardCTS.Text = String.Empty;
            txtDigitoSeguridad.Text = String.Empty;
            txtNombreTarjetahabiente.Text = String.Empty;
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

                    if (UsuarioValidoParaCargosPorServicio)
                    {
                        txtDigitoSeguridad.Visible = true;
                        cmbMesVencimiento.Visible = true;
                        cmbAnioVencimiento.Visible = true;
                        txtNombreTarjetahabiente.Visible = true;
                        lblDigitoSeguridad.Visible = true;
                        lblMesVencimiento.Visible = true;
                        lblAnioVencimiento.Visible = true;
                        lblNombreTarjetahabiente.Visible = true;
                        btnAccept.Text = "Aplicar cargo en línea";
                    }

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

        private bool UsuarioValidoCargosPorServicio()
        {
            bool Status = ChargesPerService.ValidateTestingUsers(ChargesPerService.OrigenTipoCargo.Independiente);
            lblLeyendaIva.Visible = Status;
            return Status;
        }

        private void ApplyServicesFee()
        {
            ucServicesFeePayApply.OrigenTipo = ChargesPerService.OrigenTipoCargo.Independiente;
            ucServicesFeePayApply pago = new ucServicesFeePayApply();
            pago.PayServiceFee();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCSERVICESFEEPAYAPPLY);
        }

        private void txtNumberCardCTS_Leave(object sender, EventArgs e)
        {
            SaveCurrentPaxFormPayment();
        }

        private void txtDigitoSeguridad_Leave(object sender, EventArgs e)
        {
            SaveCurrentPaxFormPayment();
        }

        private void cmbMesVencimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveCurrentPaxFormPayment();
        }

        private void cmbAnioVencimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveCurrentPaxFormPayment();
        }

        private void txtNombreTarjetahabiente_Leave(object sender, EventArgs e)
        {
            SaveCurrentPaxFormPayment();
        }

        private void cleanNumBoleto()
        {
            ddlNumBoleto.Text = string.Empty;
            ddlNumBoleto.Items.Clear();
        }

        private void ddlNumBoleto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlNumBoleto.Text.Contains("."))
            {
                string boleto = string.Empty;
                boleto = ddlNumBoleto.Text.Substring(6, ddlNumBoleto.Text.Length - 6);
                cleanNumBoleto();
                ddlNumBoleto.Items.Add(boleto);
                ddlNumBoleto.Text = boleto;

            }
        }

        private void txtPax1_Enter(object sender, EventArgs e)
        {
            if (lstDatosTarjeta[0].Ticket == null)
            {
                cleanNumBoleto();
                for (int a = 0; a < Boletos.Count; a++)
                {
                    if (!string.IsNullOrEmpty(Boletos[a]) &&
                        Boletos[a].Length > 8 &&
                        Boletos[a].Substring(0, 3) == "1.1")
                    {
                        if (!ddlNumBoleto.Items.Contains(Boletos[a]))
                            ddlNumBoleto.Items.Add(Boletos[a]);
                        paxNum = true;
                    }
                }
                if (paxNum == false)
                {
                    for (int a = 0; a < Boletos.Count; a++)
                    {
                        ddlNumBoleto.Items.Add(Boletos[a]);
                    }
                }
            }
        }

        private void txtPax2_Enter(object sender, EventArgs e)
        {
            if (lstDatosTarjeta[1].Ticket == null)
            {
                cleanNumBoleto();
                for (int a = 0; a < Boletos.Count; a++)
                {
                    if (!string.IsNullOrEmpty(Boletos[a]) &&
                            Boletos[a].Length > 8 &&
                            Boletos[a].Substring(0, 3) == "2.1")
                    {
                        if (!ddlNumBoleto.Items.Contains(Boletos[a]))
                            ddlNumBoleto.Items.Add(Boletos[a]);
                        paxNum = true;
                    }
                }

                if (paxNum == false)
                {
                    for (int a = 0; a < Boletos.Count; a++)
                    {
                        ddlNumBoleto.Items.Add(Boletos[a]);
                    }

                }
            }
        }

        private void txtPax3_Enter(object sender, EventArgs e)
        {
            if (lstDatosTarjeta[2].Ticket == null)
            {
                cleanNumBoleto();
                for (int a = 0; a < Boletos.Count; a++)
                {
                    if (!string.IsNullOrEmpty(Boletos[a]) &&
                        Boletos[a].Length > 8 &&
                        Boletos[a].Substring(0, 3) == "3.1")
                    {
                        if (!ddlNumBoleto.Items.Contains(Boletos[a]))
                            ddlNumBoleto.Items.Add(Boletos[a]);
                        paxNum = true;
                    }
                }
                if (paxNum == false)
                {
                    for (int a = 0; a < Boletos.Count; a++)
                    {
                        ddlNumBoleto.Items.Add(Boletos[a]);
                    }
                }
            }
        }

        private void txtPax4_Enter(object sender, EventArgs e)
        {
            if (lstDatosTarjeta[3].Ticket == null)
            {
                cleanNumBoleto();
                for (int a = 0; a < Boletos.Count; a++)
                {
                    if (!string.IsNullOrEmpty(Boletos[a]) &&
                        Boletos[a].Length > 8 &&
                        Boletos[a].Substring(0, 3) == "4.1")
                    {
                        if (!ddlNumBoleto.Items.Contains(Boletos[a]))
                            ddlNumBoleto.Items.Add(Boletos[a]);
                        paxNum = true;
                    }
                }
                if (paxNum == false)
                {
                    for (int a = 0; a < Boletos.Count; a++)
                    {
                        ddlNumBoleto.Items.Add(Boletos[a]);
                    }
                }
            }
        }

        private void txtPax5_Enter(object sender, EventArgs e)
        {
            if (lstDatosTarjeta[4].Ticket == null)
            {
                cleanNumBoleto();
                for (int a = 0; a < Boletos.Count; a++)
                {
                    if (!string.IsNullOrEmpty(Boletos[a]) &&
                        Boletos[a].Length > 8 &&
                        Boletos[a].Substring(0, 3) == "5.1")
                    {
                        if (!ddlNumBoleto.Items.Contains(Boletos[a]))
                            ddlNumBoleto.Items.Add(Boletos[a]);
                        paxNum = true;
                    }
                }
                if (paxNum == false)
                {
                    for (int a = 0; a < Boletos.Count; a++)
                    {
                        ddlNumBoleto.Items.Add(Boletos[a]);
                    }
                }
            }
        }

        private void txtPax6_Enter(object sender, EventArgs e)
        {
            if (lstDatosTarjeta[5].Ticket == null)
            {
                cleanNumBoleto();
                for (int a = 0; a < Boletos.Count; a++)
                {
                    if (!string.IsNullOrEmpty(Boletos[a]) &&
                        Boletos[a].Length > 8 &&
                        Boletos[a].Substring(0, 3) == "6.1")
                    {
                        if (!ddlNumBoleto.Items.Contains(Boletos[a]))
                            ddlNumBoleto.Items.Add(Boletos[a]);
                        paxNum = true;
                    }
                }
                if (paxNum == false)
                {
                    for (int a = 0; a < Boletos.Count; a++)
                    {
                        ddlNumBoleto.Items.Add(Boletos[a]);
                    }
                }
            }
        }

        private void txtPax7_Enter(object sender, EventArgs e)
        {
            if (lstDatosTarjeta[6].Ticket == null)
            {
                cleanNumBoleto();
                for (int a = 0; a < Boletos.Count; a++)
                {
                    if (!string.IsNullOrEmpty(Boletos[a]) &&
                        Boletos[a].Length > 8 &&
                        Boletos[a].Substring(0, 3) == "7.1")
                    {
                        if (!ddlNumBoleto.Items.Contains(Boletos[a]))
                            ddlNumBoleto.Items.Add(Boletos[a]);
                        paxNum = true;
                    }
                }
                if (paxNum == false)
                {
                    for (int a = 0; a < Boletos.Count; a++)
                    {
                        ddlNumBoleto.Items.Add(Boletos[a]);
                    }
                }
            }
        }

        private void txtPax8_Enter(object sender, EventArgs e)
        {
            if (lstDatosTarjeta[7].Ticket == null)
            {
                cleanNumBoleto();
                for (int a = 0; a < Boletos.Count; a++)
                {
                    if (!string.IsNullOrEmpty(Boletos[a]) &&
                        Boletos[a].Length > 8 &&
                        Boletos[a].Substring(0, 3) == "8.1")
                    {
                        if (!ddlNumBoleto.Items.Contains(Boletos[a]))
                            ddlNumBoleto.Items.Add(Boletos[a]);
                        paxNum = true;
                    }
                }
                if (paxNum == false)
                {
                    for (int a = 0; a < Boletos.Count; a++)
                    {
                        ddlNumBoleto.Items.Add(Boletos[a]);
                    }
                }
            }
        }

        private void txtPax9_Enter(object sender, EventArgs e)
        {
            if (lstDatosTarjeta[8].Ticket == null)
            {
                cleanNumBoleto();
                for (int a = 0; a < Boletos.Count; a++)
                {
                    if (!string.IsNullOrEmpty(Boletos[a]) &&
                        Boletos[a].Length > 8 &&
                        Boletos[a].Substring(0, 3) == "9.1")
                    {
                        if (!ddlNumBoleto.Items.Contains(Boletos[a]))
                            ddlNumBoleto.Items.Add(Boletos[a]);
                        paxNum = true;
                    }
                }
                if (paxNum == false)
                {
                    for (int a = 0; a < Boletos.Count; a++)
                    {
                        ddlNumBoleto.Items.Add(Boletos[a]);
                    }
                }
            }
        }
    }



    class BorrarRemarksContables
    {
        private string send = string.Empty;
        private string sabreAnswer = string.Empty;
        private int row = 0;
        private int col = 0;
        private int CCFlag;
        private int CDFlag;
        private int SMXFlag;
        private int CEFlag;
        private int CFFlag;
        private int CGFlag;
        private int CHFlag;
        private int C30Flag;
        private int C44Flag;
        private string Sabre;
        private string sabreConcat;
        private string sabreResult;
        List<string> remarkNumber = new List<string>();

        //Remarks contables
        //CC-
        public static string C3;
        public static string C2;
        public static string C1;
        public static string C24;
        string CCLine;

        //CD-
        public static string C9;
        public static string C31;
        public static string C4;
        public static string C32;
        string CDLine;

        //CE-
        public static string C5;
        public static string C6;
        public static string C7;
        public static string C8;
        string CELine;

        //CF-
        public static string C33;
        public static string C34;
        public static string C35;
        public static string C36;
        string CFLine;

        //CG-
        public static string C37;
        public static string C38;
        public static string C39;
        public static string C40;
        string CGLine;

        //CH-
        public static string C41;
        public static string C42;
        public static string C45;
        public static string C46;
        string CHLine;

        private List<QCControlsClients> dinamicQualityControlsList;
        public static List<ListItem> ClientRemarkNumber = new List<ListItem>();
        QCCustomRemarks customRemark = new QCCustomRemarks();

        public BorrarRemarksContables()
        {
            ucAvailability.IsInterJetProcess = false;
            ClientRemarkNumber.Clear();
            SetClientRemarks();
            ClearPreviousValues();
            try
            {
                SendInitialCommand();
                if (SearchRemarks)
                {
                    BucleFindEndScroll();
                    DeleteRemarks();
                }
            }
            catch (Exception ex)
            {
                String sError = ex.Message;

            }
        }

        private bool ConsolidValidation
        {
            get
            {
                bool consolidValidation = false;
                string ActiveRemoveRemarks = string.Empty;
                ActiveRemoveRemarks = activeStepsCorporativeQC.CorporativeQualityControls[0].DeleteAccountingRemarks;
                if (ActiveRemoveRemarks.Equals(Resources.TicketEmission.Constants.ACTIVE))
                    consolidValidation = false;
                else
                    consolidValidation = true;

                return consolidValidation;
            }

        }

        private void ClearPreviousValues()
        {
            //CC-
            C3 = string.Empty;
            C2 = string.Empty;
            C1 = string.Empty;
            C24 = string.Empty;
            CCLine = string.Empty;
            CCFlag = 0;

            //CD-
            C9 = string.Empty;
            C31 = string.Empty;
            C4 = string.Empty;
            C32 = string.Empty;
            CDLine = string.Empty;
            CDFlag = 0;

            //CE-
            C5 = string.Empty;
            C6 = string.Empty;
            C7 = string.Empty;
            C8 = string.Empty;
            CELine = string.Empty;
            CEFlag = 0;

            //CF-
            C33 = string.Empty;
            C34 = string.Empty;
            C35 = string.Empty;
            C36 = string.Empty;
            CFLine = string.Empty;
            CFFlag = 0;

            //CG-
            C37 = string.Empty;
            C38 = string.Empty;
            C39 = string.Empty;
            C40 = string.Empty;
            CGLine = string.Empty;
            CGFlag = 0;

            //CH-

            C41 = string.Empty;
            C42 = string.Empty;
            C45 = string.Empty;
            C46 = string.Empty;
            CHLine = string.Empty;
            CHFlag = 0;


        }

        private void SendInitialCommand()
        {
            send = string.Empty;
            sabreResult = string.Empty;
            send = Resources.TicketEmission.Constants.COMMANDS_AST_P5;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreResult = objCommand.SendReceive(send);
            }

        }

        private bool SearchRemarks
        {
            get
            {
                bool exixtingRemarks = false;
                row = 0;
                col = 0;
                CommandsQik.searchResponse(sabreResult, Resources.TicketEmission.ValitationLabels.REMARKS, ref row, ref col);
                if (row > 0)
                {
                    exixtingRemarks = true;
                    sabreConcat = string.Concat(sabreResult,
                        "?");
                }
                else
                {
                    exixtingRemarks = false;
                }
                return exixtingRemarks;
            }
        }

        private void BucleFindEndScroll()
        {
            SendScrollCommand();
            if (!SearchEndScroll())
            {
                BucleFindEndScroll();
            }

        }

        private void DeleteRemarks()
        {
            string[] sabreAnswerCollection = sabreConcat.Split(new char[] { '?' });
            for (int i = 0; i < sabreAnswerCollection.Length; i++)
            {
                if (!string.IsNullOrEmpty(sabreAnswerCollection[i]))
                {
                    sabreAnswer = string.Empty;
                    sabreAnswer = sabreAnswerCollection[i];
                    RemoveRemarks();
                }
            }
            SendDeleteRemarkCommand();

        }

        private void SendScrollCommand()
        {
            send = string.Empty;
            sabreResult = string.Empty;
            send = Resources.TicketEmission.Constants.COMMANDS_MD;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreResult = objCommand.SendReceive(send);
            }
        }

        private bool SearchEndScroll()
        {
            bool endScroll = false;
            row = 0;
            col = 0;
            CommandsQik.searchResponse(sabreResult, "SCROLL‡", ref row, ref col);
            if (row != 0 && col >= 0)
            {
                endScroll = true;
            }
            else
            {
                sabreConcat = string.Concat(sabreConcat,
                    Resources.TicketEmission.ValitationLabels.REMARKS,
                    "\n",
                    sabreResult,
                    "?");
                endScroll = false;
            }
            return endScroll;
        }

        private void RemoveRemarks()
        {
            string line = string.Empty;
            row = 0;
            col = 0;
            sabreAnswer = sabreAnswer.Replace(" ‡ ", " \n ");
            string[] sabreAnswerInfo = sabreAnswer.Split(new char[] { '\n' });

            List<string> temp = new List<string>();
            for (int i = 1; i < sabreAnswerInfo.Length; i++)
            {
                int lastItem = i + 1;
                if (!lastItem.Equals(sabreAnswerInfo.Length))
                {
                    if (!string.IsNullOrEmpty(sabreAnswerInfo[i]) && !sabreAnswerInfo[i].StartsWith("    ") && sabreAnswerInfo[i + 1].StartsWith("    "))
                    {
                        if (sabreAnswerInfo[lastItem].StartsWith("    "))
                        {
                            string clearSpaces = sabreAnswerInfo[lastItem].TrimStart(new char[] { ' ' });
                            string fullRemark = string.Concat(sabreAnswerInfo[i],
                                clearSpaces);
                            temp.Add(fullRemark);
                        }

                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(sabreAnswerInfo[i]) && !sabreAnswerInfo[i].StartsWith("    "))
                            temp.Add(sabreAnswerInfo[i]);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(sabreAnswerInfo[i]) && !sabreAnswerInfo[i].StartsWith("    "))
                        temp.Add(sabreAnswerInfo[i]);
                }
            }

            foreach (string lines in temp)//Inicio linea1
            {

                CommandsQik.searchResponse(lines, ".</C30", ref row, ref col, 1, 1, 1, 20);
                if (row > 0)
                {
                    //Encontro valor
                    C30Flag = 1;
                    row = 0;
                    col = 0;
                }

                CommandsQik.searchResponse(lines, ".</C44", ref row, ref col, 1, 1, 1, 20);
                if (row > 0)
                {
                    //Encontro valor
                    C44Flag = 1;
                    row = 0;
                    col = 0;
                }

                CommandsQik.searchResponse(lines, ".S*MX", ref row, ref col, 1, 1, 1, 20);
                if (row > 0)
                {
                    //Encontro valor
                    SMXFlag = 1;
                    row = 0;
                    col = 0;
                }

                CommandsQik.searchResponse(lines, ".CC-", ref row, ref col, 1, 1, 1, 20);
                if (row > 0)
                {
                    //Encontro valor
                    //Asignacion de valores CC-
                    CCLine = string.Empty;
                    CommandsQik.CopyResponse(lines, ref CCLine, 1, 1, lines.Length);
                    CCLine = CCLine.Trim();

                    char[] sep = { '-' };
                    string[] arr = CCLine.Split(sep);

                    //C3 = arr[1];
                    //C2 = arr[2];
                    //C1 = arr[3];
                    //C24 = arr[4];
                    CCLine = string.Empty;
                    //Fin asignacion de valores CC-

                    CCFlag = 1;
                    row = 0;
                    col = 0;
                }


                CommandsQik.searchResponse(lines, ".CD-", ref row, ref col, 1, 1, 1, 20);
                if (row > 0)
                {
                    //Encontro valor

                    //Asignacion de valores CD-
                    CDLine = string.Empty;
                    CommandsQik.CopyResponse(lines, ref CDLine, 1, 1, lines.Length);
                    CDLine = CDLine.Trim();

                    char[] sep1 = { '-' };
                    string[] arr1 = CDLine.Split(sep1);

                    //C9 = arr1[1];
                    //C31 = arr1[2];
                    //C4 = arr1[3];
                    //C32 = arr1[4];
                    CDLine = string.Empty;
                    //Fin asignacion de valores CD-

                    CDFlag = 1;
                    row = 0;
                    col = 0;
                }

                CommandsQik.searchResponse(lines, ".CE-", ref row, ref col, 1, 1, 1, lines.Length);
                if (row > 0)
                {
                    //Encontro valor

                    //Asignacion de valores CE-
                    CELine = string.Empty;
                    CommandsQik.CopyResponse(lines, ref CELine, 1, 1, lines.Length);
                    CELine = CELine.Trim();

                    char[] sep2 = { '-' };
                    string[] arr2 = CELine.Split(sep2);

                    //C5 = arr2[1];
                    //C6 = arr2[2];
                    //C7 = arr2[3];
                    //C8 = arr2[4];
                    CELine = string.Empty;
                    //Fin asignacion de valores CD-

                    CEFlag = 1;
                    row = 0;
                    col = 0;
                }

                CommandsQik.searchResponse(lines, ".CF-", ref row, ref col, 1, 1, 1, 20);
                if (row > 0)
                {
                    //Encontro valor

                    //Asignacion de valores CF-
                    CFLine = string.Empty;
                    CommandsQik.CopyResponse(lines, ref CFLine, 1, 1, lines.Length);
                    CFLine = CFLine.Trim();

                    char[] sep3 = { '-' };
                    string[] arr3 = CFLine.Split(sep3);

                    CFLine = string.Empty;
                    //Fin asignacion de valores CF-

                    CFFlag = 1;
                    row = 0;
                    col = 0;
                }

                CommandsQik.searchResponse(lines, ".CG-", ref row, ref col, 1, 1, 1, 20);
                if (row > 0)
                {
                    //Encontro valor

                    //Asignacion de valores CG-
                    CGLine = string.Empty;
                    CommandsQik.CopyResponse(lines, ref CGLine, 1, 1, lines.Length);
                    CGLine = CGLine.Trim();

                    char[] sep4 = { '-' };
                    string[] arr4 = CGLine.Split(sep4);

                    CGLine = string.Empty;
                    //Fin asignacion de valores CG-

                    CGFlag = 1;
                    row = 0;
                    col = 0;
                }

                CommandsQik.searchResponse(lines, ".CH-", ref row, ref col, 1, 1, 1, 20);
                if (row > 0)
                {
                    //Encontro valor

                    //Asignacion de valores CH-
                    CHLine = string.Empty;
                    CommandsQik.CopyResponse(lines, ref CHLine, 1, 1, lines.Length);
                    CHLine = CHLine.Trim();

                    char[] sep5 = { '-' };
                    string[] arr5 = CHLine.Split(sep5);

                    CHLine = string.Empty;
                    //Fin asignacion de valores CH-

                    CHFlag = 1;
                    row = 0;
                    col = 0;
                }

                RecoverRemarksValues(lines);

                if (C30Flag == 0 && C44Flag == 0 && SMXFlag == 0 && CCFlag == 1 && CDFlag == 0 && CEFlag == 0 && CFFlag == 0 && CGFlag == 0 && CHFlag == 0)
                {
                    line = string.Empty;
                    CommandsQik.CopyResponse(lines, ref line, 1, 1, 3);
                    line = line.Trim();
                    remarkNumber.Add(line);
                    row = 0;
                    col = 0;
                }
                else if (C30Flag == 0 && C44Flag == 0 && SMXFlag == 0 && CCFlag == 0 && CDFlag == 1 && CEFlag == 0 && CFFlag == 0 && CGFlag == 0 && CHFlag == 0)
                {
                    line = string.Empty;
                    CommandsQik.CopyResponse(lines, ref line, 1, 1, 3);
                    line = line.Trim();
                    remarkNumber.Add(line);
                    row = 0;
                    col = 0;
                }
                else if (C30Flag == 0 && C44Flag == 0 && SMXFlag == 0 && CCFlag == 0 && CDFlag == 0 && CEFlag == 1 && CFFlag == 0 && CGFlag == 0 && CHFlag == 0)
                {
                    line = string.Empty;
                    CommandsQik.CopyResponse(lines, ref line, 1, 1, 3);
                    line = line.Trim();
                    remarkNumber.Add(line);
                    row = 0;
                    col = 0;
                }
                else if (C30Flag == 0 && C44Flag == 0 && SMXFlag == 0 && CCFlag == 0 && CDFlag == 0 && CEFlag == 0 && CFFlag == 1 && CGFlag == 0 && CHFlag == 0)
                {
                    line = string.Empty;
                    CommandsQik.CopyResponse(lines, ref line, 1, 1, 3);
                    line = line.Trim();
                    remarkNumber.Add(line);
                    row = 0;
                    col = 0;
                }

                else if (C30Flag == 0 && C44Flag == 0 && SMXFlag == 0 && CCFlag == 0 && CDFlag == 0 && CEFlag == 0 && CFFlag == 0 && CGFlag == 1 && CHFlag == 0)
                {
                    line = string.Empty;
                    CommandsQik.CopyResponse(lines, ref line, 1, 1, 3);
                    line = line.Trim();
                    remarkNumber.Add(line);
                    row = 0;
                    col = 0;
                }

                else if (C30Flag == 0 && C44Flag == 0 && SMXFlag == 0 && CCFlag == 0 && CDFlag == 0 && CEFlag == 0 && CFFlag == 0 && CGFlag == 0 && CHFlag == 1)
                {
                    line = string.Empty;
                    CommandsQik.CopyResponse(lines, ref line, 1, 1, 3);
                    line = line.Trim();
                    remarkNumber.Add(line);
                    row = 0;
                    col = 0;
                }
                else if (C30Flag == 0 && C44Flag == 0 && SMXFlag == 0 && CCFlag == 0 && CDFlag == 0 && CEFlag == 0 && CFFlag == 0 && CGFlag == 0 && CHFlag == 0)
                {

                    CommandsQik.searchResponse(lines, "..", ref row, ref col, 1, 1, 1, 6);
                    if (row > 0)
                    {
                        row = 0;
                        col = 0;
                        line = string.Empty;
                        CommandsQik.CopyResponse(lines, ref line, 1, 1, 3);
                        line = line.Trim();
                        remarkNumber.Add(line);
                        row = 0;
                        col = 0;
                    }
                }
                C30Flag = 0;
                C44Flag = 0;
                SMXFlag = 0;
                CCFlag = 0;
                CDFlag = 0;
                CEFlag = 0;
                CFFlag = 0;
                CGFlag = 0;
                CHFlag = 0;
                CDFlag = 0;

            }
        }

        private void SendDeleteRemarkCommand()
        {
            if (!remarkNumber.Count.Equals(0))
            {
                List<int> TempNumber = new List<int>();
                foreach (string number in remarkNumber)
                {
                    try
                    {
                        TempNumber.Add(Convert.ToInt32(number));
                    }
                    catch { }
                }
                TempNumber.Sort();
                TempNumber.Reverse();
                foreach (int number in TempNumber)
                {
                    Sabre = Sabre + "5" + number.ToString().Trim() + "@Σ";
                }
            }

            if (!string.IsNullOrEmpty(Sabre))
            {
                send = string.Empty;
                Sabre = Sabre.TrimEnd(new char[] { 'Σ' });
                send = Sabre;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    sabreAnswer = objCommand.SendReceive(send);
                }

            }

        }

        private void RecoverRemarksValues(string line)
        {
            foreach (ListItem remarkNum in ClientRemarkNumber)
            {
                if (customRemark.RmrkType != null)
                {
                    string value = string.Empty;
                    string temp = (!string.IsNullOrEmpty(customRemark.RmrkPaxIdentyfier)) ? customRemark.RmrkPaxIdentyfier : customRemark.RmrkValueIdentyfier;
                    string remark = string.Concat(".",
                        customRemark.RmrkInitialLabel,
                        customRemark.RmrkIdentyfier,
                        remarkNum.Value,
                        temp);

                    int row = 0;
                    int col = 0;
                    CommandsQik.searchResponse(line, remark, ref row, ref col, 1, 1, 1, 20);
                    if (row > 0)
                    {
                        CommandsQik.CopyResponse(line, ref value, 1, 1, line.Length);
                        string remarkValue = string.Empty;

                        if (!string.IsNullOrEmpty(customRemark.RmrkValueIdentyfier))
                        {
                            remark = value.Replace(customRemark.RmrkValueIdentyfier, "|");
                            string[] values = remark.Split(new char[] { '|' });
                            if (values.Length > 2)
                            {
                                for (int i = 1; i < values.Length; i++)
                                {
                                    remarkNum.Text3 = string.Concat(remarkNum.Text3,
                                        values[i]);
                                }
                            }
                            else if (values.Length == 2)
                            {
                                remarkNum.Text3 = values[1];
                            }
                        }
                    }
                }
            }
        }

        private void SetClientRemarks()
        {
            dinamicQualityControlsList = QCControlsClientsBL.GetQCControls(ChargesPerService.DKActual, Login.Firm, Login.PCC, Login.Agent);
            if (dinamicQualityControlsList.Count > 0)
            {
                if (!string.IsNullOrEmpty(dinamicQualityControlsList[28].CtrlDescription) &&
                    dinamicQualityControlsList[28].CtrlDescription != Login.Mail)
                    dinamicQualityControlsList[28].CtrlDescription = Login.Mail;
                foreach (QCControlsClients qualityControls in dinamicQualityControlsList)
                {
                    string[] QCValue = qualityControls.ActiveQCClient.Split(new char[] { '|' });
                    int index = 0;
                    if (QCValue.Length > 1)
                        index = 1;
                    if (!QCValue[index].Equals(Resources.TicketEmission.Constants.INACTIVE))
                    {
                        ListItem item = new ListItem();
                        item.Value = QCValue[0];
                        item.Text = qualityControls.CtrlName;
                        item.Text2 = qualityControls.ReservationCtrlType;
                        ClientRemarkNumber.Add(item);
                    }
                }
            }
            customRemark = QCCustomRemarksBL.GetQCustomRemarks(ChargesPerService.DKActual);
        }
    }
}
