using System;
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
using MyCTS.Services;
using MyCTS.Services.Contracts;
using MyCTS.Services.ValidateDKsAndCreditCards;

namespace MyCTS.Presentation
{
    public partial class ucCalculateServiceCharge : CustomUserControl
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
        private static bool UsuarioValidoParaCargosPorServicio = false;
        private int indexImage = 0;
        int iCurrentPaxNumber = 1;
        int iCurrentPosicion = 1;
        private Parameter activateFormOfPaymentCS = null;
        private Parameter activateOldRemarkCS = null;
        private List<RuleAndPassenger> RuleAndPax = null;
        private List<GetCorporativeFeesRules> indexList = null;
        private List<BannerImage> imageList = null;
        public static List<CreditCardInfo> lstDatosTarjeta = null;
        OTATravelItinerary.OTATravelItineraryObject myObject = null;
        public static ChargesPerService.OrigenTipoCargo TipoCargo;
        public static bool flags = false;
        public static int cmbFecMes = 0;

        public static string ChargePerService { get; set; }
        public static string C23 { get; set; }

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

        /// <summary>
        /// Descripcion: Calcula el cargo por servicio en base a los 
        ///              corporativos y sus DK's
        /// Creación:    Noviembre-Diciembre 09 , Modificación: 20-05-2010
        /// Cambio:      Forma de pago para cadad monto   , Solicito: Guillermo Granados
        /// Autor:       Angel Trejo
        /// </summary>
        public ucCalculateServiceCharge()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            this.LastControlFocus = btnAccept;

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
        private void ucCalculateServiceCharge_Load(object sender, EventArgs e)
        {
            CommandsAPI2.send_MessageToEmulator("CALCULANDO EL MONTO DEL CARGO POR SERVICIO, FAVOR DE ESPERAR...");
            DeterminaValidacionPreviaGeneralCargo();
        }

        public static void Clean()
        {
            if (lstDatosTarjeta != null)
            {
                if (lstDatosTarjeta.Count > 0)
                {
                    lstDatosTarjeta.Clear();
                }
            }
        }

        /// <summary>
        /// Funciones que se extraen los datos para calcular el monto del cargo 
        /// por servicio
        /// </summary>
        private void LoadData()
        {
            try
            {
                GetValuesWebServices();
                GetLastDateToPurchase();
                if (ucTicketsEmissionInstructions.wayPayment.Equals(Resources.TicketEmission.Constants.PAYMENT_CASH))
                    GetBaseFare();
                else
                    baseFare = ucFormPayment.BaseFare;

                GetValuesFromTicketEmissionInstructions();
                SetColorTextBox();
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
            HideStart();
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
                LimpiarLista();

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
                    PictureBoxBanner.Visible = false;
                    JustificationRule();
                }
                else
                {
                    ShowImages();
                }
                LoadFormPaymentCodes();
                setFOPChargeService();
            }
        }

        private static void LimpiarLista()
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
                    PictureBoxBanner.Image = Image.FromStream(image);
                    PictureBoxBanner.SizeMode = PictureBoxSizeMode.StretchImage;
                    PictureBoxBanner.Visible = true;
                    toolTipBanner.SetToolTip(this.PictureBoxBanner, "Doble clic sobre la imagen para ver los detalles");
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
        /// Se validan la tarjetas ingresadas para el cobro de cargo por servicio
        /// </summary>
        public void ValidaTarjetas()
        {

            //Se realiza la validación de todos los campos que no vayan vacíos
            if ((!string.IsNullOrEmpty(txtPax1.Text) || !string.IsNullOrEmpty(txtPax2.Text) ||
                 !string.IsNullOrEmpty(txtPax3.Text) || !string.IsNullOrEmpty(txtPax4.Text) ||
                 !string.IsNullOrEmpty(txtPax5.Text) || !string.IsNullOrEmpty(txtPax6.Text) ||
                 !string.IsNullOrEmpty(txtPax7.Text) || !string.IsNullOrEmpty(txtPax8.Text) ||
                 !string.IsNullOrEmpty(txtPax9.Text)))
            {
                if (cmbTypeCard.Text == "- Selecciona Forma de Pago -")
                {
                    MessageBox.Show("¡Ingrese la forma de pago!", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (string.IsNullOrEmpty(txtNumberCardCTS.Text))
                {
                    MessageBox.Show("¡Ingrese el numero de tarjeta!", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ///Valida si se ingreso el numero de tarjeta, si se ingreso se valida que la tarjeta no pertenezca a otro cliente, que el tipo
                    ///de la tarjeta sea la correcta, que la tarjeta no pertenezca a CTS en caso de que marque la casilla de Clientes...
                    if (!string.IsNullOrEmpty(txtNumberCardCTS.Text))
                    {
                        ///Llama al webServices ValidateDKsAndCreditCards para buscar la tarjeta ingresada en la base de datos
                        WsMyCTS wsServ = new WsMyCTS();
                        MyCTS.Services.ValidateDKsAndCreditCards.ClientCreditCard clientCreditCard = wsServ.GetClientCreditCardNumber(txtNumberCardCTS.Text, ucFirstValidations.dk);

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
                                        MyCTS.Services.ValidateDKsAndCreditCards.ClientCreditCard infoCreditCard = wsServ.GetClientCreditCardNumberByClient(ucFirstValidations.dk);

                                        if (infoCreditCard.CreditCardNumber != txtNumberCardCTS.Text && (infoCreditCard.Client == ucFirstValidations.dk && infoCreditCard.Type != cmbTypeCard.Text))
                                        {
                                            if (infoCreditCard.Type == "AIR")
                                            {
                                                infoCreditCard.Type = "AIRPLUS";
                                            }
                                            else if (infoCreditCard.Type == "AMEX")
                                            {
                                                infoCreditCard.Type = "EBTA";
                                            }
                                            MessageBox.Show("El número de tarjeta capturado no corresponde a la tarjeta de tipo " + infoCreditCard.Type +
                                            " ligada al cliente DK: " + ucFirstValidations.DK, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            txtNumberCardCTS.Text = string.Empty;
                                            txtNumberCardCTS.Focus();
                                        }
                                    }
                                }
                                else if (clientCreditCardNumber != txtNumberCardCTS.Text)
                                {
                                    MessageBox.Show("El número de tarjeta ingresado pertenece a un cliente diferente, ingrese un número de tarjeta válido", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    txtNumberCardCTS.Text = string.Empty;
                                    txtNumberCardCTS.Focus();
                                }
                                else
                                {
                                    DeterminaValidacionGeneracionCargo();
                                }
                            }
                        }
                        if (txtNumberCardCTS.Text == clientCreditCard.CreditCardNumber & ucFirstValidations.DK == clientCreditCard.Client)
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
            else
            {
                ucServicesFeePayApply.lstDatosTarjeta = new List<CreditCardInfo>();
                //ucServicesFeePayApply.lstDatosTarjeta2 = new List<CreditCardInfo>();
                ContinueWithoutPay();
            }
        }


        /// <summary>
        /// Acciones que se ejecutan al dar click en el boton Aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
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
                            ValidaTarjetas();
                        }
                        else
                        {
                            ///Se realiza la validación de todos los campos que no vayan vacíos...
                            if ((string.IsNullOrEmpty(cmbTypeCard.Text) || string.IsNullOrEmpty(txtDigitoSeguridad.Text) ||
                               string.IsNullOrEmpty(txtNombreTarjetahabiente.Text) || string.IsNullOrEmpty(cmbTypeCard.Text) ||
                               string.IsNullOrEmpty(cmbMesVencimiento.Text) || string.IsNullOrEmpty(cmbAnioVencimiento.Text) ||
                               string.IsNullOrEmpty(cmbTypeCard.Text)))
                            {
                                MessageBox.Show("¡Debes ingresar todos los campos!", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                ///Se realiza la validación de todos los campos que no vayan vacíos
                                if ((!string.IsNullOrEmpty(txtPax1.Text) || !string.IsNullOrEmpty(txtPax2.Text) ||
                                     !string.IsNullOrEmpty(txtPax3.Text) || !string.IsNullOrEmpty(txtPax4.Text) ||
                                     !string.IsNullOrEmpty(txtPax5.Text) || !string.IsNullOrEmpty(txtPax6.Text) ||
                                     !string.IsNullOrEmpty(txtPax7.Text) || !string.IsNullOrEmpty(txtPax8.Text) ||
                                     !string.IsNullOrEmpty(txtPax9.Text)))
                                {
                                    int cmboFecYear = Convert.ToInt32(DateTime.Now.Year);
                                    int cmboFecMes = Convert.ToInt32(DateTime.Now.Month);
                                    int cmbFecYear = Convert.ToInt32(cmbAnioVencimiento.Text);
                                    if (cmbTypeCard.Text == "- Selecciona Forma de Pago -")
                                    {
                                        MessageBox.Show("¡Ingrese la Forma de Pago!", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        ///Se validan la fechas ingresadas por el usuario. No deben ser menores a la fecha actual.
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
                                                ///Llama al WebServices ValidateDKsAndCreditCards para buscar la tarjeta ingresada en la base de datos.
                                                WsMyCTS wsServ = new WsMyCTS();
                                                MyCTS.Services.ValidateDKsAndCreditCards.ClientCreditCard clientCreditCard = wsServ.GetClientCreditCardNumber(txtNumberCardCTS.Text, ucFirstValidations.DK);

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
                                                            }
                                                        }
                                                        else if (clientCreditCard.CreditCardNumber != txtNumberCardCTS.Text)
                                                        {
                                                            MessageBox.Show("El número de tarjeta ingresado pertenece a un cliente diferente, ingrese un número de tarjeta válido", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            txtNumberCardCTS.Text = string.Empty;
                                                            txtNumberCardCTS.Focus();
                                                        }
                                                        else
                                                        {
                                                            DeterminaValidacionGeneracionCargo();
                                                        }
                                                    }
                                                }
                                                if (txtNumberCardCTS.Text == clientCreditCard.CreditCardNumber & ucFirstValidations.DK == clientCreditCard.Client)
                                                {
                                                    DeterminaValidacionGeneracionCargo();
                                                }
                                                else
                                                    if (!string.IsNullOrEmpty(clientCreditCard.CreditCardNumber) & !string.IsNullOrEmpty(clientCreditCard.Client))
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

        /// <summary>
        /// Aplicars the cargos.
        /// </summary>
        /// <returns></returns>
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
                        if (!ValidarDatosTarjeta(lstDatosTarjeta[i]))
                        {
                            this.Focus();
                            MessageBox.Show("La forma de pago del PAX " + (i + 1) + ".1 contiene algunos campos vacíos", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                        else if (!ValidaLongitudTarjeta(lstDatosTarjeta[i]))
                        {
                            this.Focus();
                            MessageBox.Show("Una de las tarjetas ingresadas no contiene el numero de digitos necesario", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                        else
                        {
                            if (lstDatosTarjeta[i].Activo == true)
                            {
                                lstDatosTarjeta[i].OrigenVenta = "A";
                                ucServicesFeePayApply.lstDatosTarjeta.Add(lstDatosTarjeta[i]);
                            }
                        }
                    }
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_TICKETEMISSION_CONFIRMATION);
                }
            }
            return true;
        }

        private bool ValidarCamposVacios()
        {
            if (cmbTypeCard.SelectedIndex > 0)
            {
                ListItem lstTipoTarjeta = (ListItem)cmbTypeCard.SelectedItem;

                if (lstTipoTarjeta.Text2.Equals("CCAC") || lstTipoTarjeta.Text2.Equals("CCPV") || lstTipoTarjeta.Text2.Equals("CCTD"))
                {
                    if (String.IsNullOrEmpty(txtNumberCardCTS.Text))
                    {
                        return false;
                    }
                    if (UsuarioValidoParaCargosPorServicio)
                    {
                        if (String.IsNullOrEmpty(txtDigitoSeguridad.Text))
                        {
                            return false;
                        }
                        if (String.IsNullOrEmpty(txtNombreTarjetahabiente.Text))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private bool ValidarDatosTarjeta(CreditCardInfo dtsTarjeta)
        {
            if (dtsTarjeta.MontoCargo > 0)
            {
                if (dtsTarjeta == null)
                    return false;

                if (dtsTarjeta.TipoTarjeta == null)
                    return false;

                if (dtsTarjeta.TipoTarjeta.Equals("CCAC") || dtsTarjeta.TipoTarjeta.Equals("CCPV") || dtsTarjeta.TipoTarjeta.Equals("CCTD"))
                {
                    if (String.IsNullOrEmpty(dtsTarjeta.NumeroTarjeta))
                    {
                        return false;
                    }
                    if (UsuarioValidoParaCargosPorServicio)
                    {
                        if (String.IsNullOrEmpty(dtsTarjeta.CodigoSeguridad))
                        {
                            return false;
                        }
                        if (String.IsNullOrEmpty(dtsTarjeta.NombreTitular))
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
            string location_dk = ucFirstValidations.DK;
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

            if (temp != null)
            {
                foreach (string tempcount in temp)
                {
                    if (temp[count].Length > 1)
                    {
                        temp[count] = tempcount.Substring(0, 2);
                        temp[count] = (temp[count].Trim(new char[] { '.' }));
                        count++;
                    }
                }
            }

            int i = 0;
            int sPoSicionPax = 0;

            if (ucAllQualityControls.paxNumberLabel.Count == ucAllQualityControls.globalPaxNumber)
            {
                if (ucAllQualityControls.paxNumberLabel.Count > 0)
                {
                    sPoSicionPax = ucAllQualityControls.paxNumberLabel.Count;

                    if (ucAllQualityControls.paxNumberLabel != null)
                        if (ucAllQualityControls.paxNumberLabel.Count > 1)
                            chkSameForAll.Visible = true;
                        else
                            chkSameForAll.Visible = false;
                }
            }
            else
            {
                sPoSicionPax = ucAllQualityControls.globalPaxNumber;

                if (ucAllQualityControls.globalPaxNumber != null)
                    if (ucAllQualityControls.globalPaxNumber > 1)
                        chkSameForAll.Visible = true;
                    else
                        chkSameForAll.Visible = false;
            }

            for (int x = sPoSicionPax; x > 0; x--)
            {
                if (temp != null)
                    i = Convert.ToInt32(temp[x - 1]);
                else
                    i = x;

                try
                {
                    distributionChanel = ucAllQualityControls.originOfSale[x - 1];
                    bussinesUnit = ucAllQualityControls.ListBussinesUnit[x - 1];
                }
                catch (Exception ex)
                {
                    distributionChanel = ucAllQualityControls.originOfSale[ucAllQualityControls.originOfSale.Count - 1];
                    bussinesUnit = ucAllQualityControls.ListBussinesUnit[ucAllQualityControls.originOfSale.Count - 1];
                    string sError = ex.Message;
                }

                try
                {
                    if (myObject != null && myObject.PassengerTypeList != null && myObject.PassengerTypeList.Count > 0)
                        typePax = myObject.PassengerTypeList[i - 1];
                    else
                        typePax = string.Empty;
                }
                catch { typePax = string.Empty; }

                indexList = new List<GetCorporativeFeesRules>();

                if (!string.IsNullOrEmpty(baseFare))
                {
                    try
                    {
                        if (myObject != null)
                            indexList = GetCorporativeFeesRulesBL.GetCorporativeFeesRules(location_dk, ucFirstValidations.Attribute1, Convert.ToDouble(baseFare), (myObject.DepartureAirportList != null && myObject.DepartureAirportList.Count > 0) ? myObject.DepartureAirportList[0] : null, (myObject.ArrivalAirportList != null && myObject.ArrivalAirportList.Count > 0) ? myObject.ArrivalAirportList[0] : null, (myObject.DepartureAirportList != null && myObject.DepartureAirportList.Count > 0) ? Convert.ToDateTime(myObject.DepartureDateList[0]).ToString("dd/MM/yyyy") : null, location_dk, typePax, myObject.SegmentType, "SABRE", dayTime, advancedPurchase, wekDay, ticketType, ticketIssuer, distributionChanel, fireType, myObject.FareBasis, ticketIssuingCarrierTarget, baseFare, formOfPayment, (string.IsNullOrEmpty(bysegments)) ? myObject.SegmentCount : bysegments, marketingAirline, myObject.PCC, bussinesUnit);
                        else
                            indexList = GetCorporativeFeesRulesBL.GetCorporativeFeesRules(location_dk, ucFirstValidations.Attribute1, Convert.ToDouble(baseFare), null, null, null, location_dk, typePax, null, "SABRE", dayTime, advancedPurchase, wekDay, ticketType, ticketIssuer, distributionChanel, fireType, null, ticketIssuingCarrierTarget, baseFare, formOfPayment, bysegments, marketingAirline, Login.PCC, bussinesUnit);
                    }
                    catch { }
                }

                if (temp != null)
                {
                    if (ucAllQualityControls.paxNumberLabel.Count > 0)
                        CalculateChargeControl(i, ucAllQualityControls.paxNumberLabel[x - 1], x);
                    else
                        CalculateChargeControl(i, i + ".1", x);
                }
                else
                    CalculateChargeControl(i, i + ".1", x);
            }
        }

        private void CalculateChargeControl(int iPax, string sNumberLabel, int Posicion)
        {
            TextBox txtCtrl = (TextBox)this.Controls.Find("txtPax" + Posicion, true)[0];
            //Label lblCtrl = (Label)this.Controls.Find("lblInfo1", true)[0];
            Label LabelPaxCtrl = (Label)this.Controls.Find("lblPax" + Posicion, true)[0];
            txtCtrl.Enabled = true;
            this.InitialControlFocus = txtCtrl;
            txtCtrl.BackColor = Color.White;
            txtCtrl.Focus();
            LabelPaxCtrl.Text = string.Concat("Pax ", sNumberLabel, ":");

            lstDatosTarjeta[Posicion - 1].PaxNumber = iPax;
            lstDatosTarjeta[Posicion - 1].Activo = true;

            if (indexList.Count <= 0)
                return;
            if (indexList[0].ActivationState && ValidateStartAndExpirationDate(Convert.ToString(indexList[0].StartDate), Convert.ToString(indexList[0].ExpirationDate)))
            {
                if (ValidateTimeRange && ValidateBaseFare(baseFare))
                {
                    RuleAndPassenger p = new RuleAndPassenger();
                    p.Rule = indexList[0].RuleNumber;
                    p.PaxNumber = sNumberLabel;
                    RuleAndPax.Add(p);
                    txtCtrl.Text = indexList[0].CantidadCalculada.ToString("0.00");
                }
            }
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
            smartTextBox1.Lines = informe;
            smartTextBox1.Visible = true;
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
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTICKETSEMISSIONINSTRUCTIONS);
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
            txtDigitoSeguridad.Text = ucFormPayment.SecurityCode;
            if (frmProfilesCreditCards.selectCreditCard != null)
            {
                string[] creditcardParts = frmProfilesCreditCards.selectCreditCard.Split(' ');
                string[] creditcardPartsName = frmProfilesCreditCards.selectCreditCard.Split('^');
                string nameClient = (creditcardPartsName.Length > 2) ? creditcardPartsName[2] : string.Empty;
                txtNombreTarjetahabiente.Text = nameClient;
            }
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
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTICKETSEMISSIONINSTRUCTIONS);
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
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_TICKETEMISSION_CONFIRMATION);
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

        private void ClearCurrentPayormPayment()
        {
            //cmbTypeCard
            //txtNumberCardCTS
            //txtDigitoSeguridad
            //cmbMesVencimiento
            //cmbAnioVencimiento
            //txtNombreTarjetahabiente
        }

        private void SaveCurrentPaxFormPayment()
        {
            int iCurrentPaxNumberMenosUno = iCurrentPosicion - 1;
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
                                if (((ListItem)cmbTypeCard.Items[i]).Value.Equals(lstDatosTarjeta[iPaxNumber].TipoTarjetaSabre))
                                {
                                    cmbTypeCard.SelectedIndex = i;
                                    HideAndShowCaptureControls(i, (ListItem)cmbTypeCard.Items[i]);
                                    break;
                                }
                            }

                            if (lstDatosTarjeta[iPaxNumber].TipoTarjeta == null)
                                return;

                            if (!lstDatosTarjeta[iPaxNumber].TipoTarjeta.Equals("CA"))
                            {
                                txtNumberCardCTS.Text = lstDatosTarjeta[iPaxNumber].NumeroTarjeta;
                                if (!lstDatosTarjeta[iPaxNumber].TipoTarjeta.Equals("TR") && !lstDatosTarjeta[iPaxNumber].TipoTarjeta.Equals("CH") && !lstDatosTarjeta[iPaxNumber].TipoTarjeta.Equals("CCTC"))
                                {
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
                    //string creditCard = GetCreditCardNumberBL.GetCreditCardNumber(sNumberCardCTS);
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
                                //MyCTS.Services.ValidateDKsAndCreditCards.ClientCreditCard infoCreditCard = wsServ.GetClientCreditCardNumberByClient(ucFirstValidations.DK);

                                //if (infoCreditCard.CreditCardNumber == txtNumberCardCTS.Text && (infoCreditCard.Client == ucFirstValidations.DK && infoCreditCard.Type != cmbTypeCard.Text))
                                //{
                                //    MessageBox.Show("El número de tarjeta capturado no corresponde a la tarjeta de tipo " + cmbTypeCard +
                                //    " ligada al cliente DK: " + ucFirstValidations.DK, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //    txtNumberCardCTS.Focus();
                                //    return false;
                                //}
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
                //ShowControls(true);
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
                            CargaControlesCargoIndependiente();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                this.Focus();
                MessageBox.Show(ex.Message);
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
                    if (ChargesPerService.ValidacionPrevioCargoIndependiente())
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
                MessageBox.Show("Debe de capturar todos los campos para poder continuar con la operación", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void ValidaGeneracionCargoIndependiente()
        {
        }

        public void AplicarCargoIndependiente()
        {
            //Paso 1: Realizar cargo
            //Paso 2: Ingresar remarks
            //Paso 3: "DIN"
            //Si respuesta es  *PAC to Verify
            if (ChargesPerService.ExisteCadenaEnRespuestasSabre(ChargesPerService.PreguntasASabre.DIN, ChargesPerService.RespuestasSabre.PAC_TO_VERIFY))
            {
                // DIN
                ChargesPerService.ExisteCadenaEnRespuestasSabre(ChargesPerService.PreguntasASabre.DIN, "");
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTICKETEMISSIONBUILDCOMMAND);
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
                                sCargosPreviosAplicados += "PAX: " + lstDatosTarjeta[i].PaxNumber + " Autorización: " + lstDatosTarjeta[i].NumeroAutorizacion + " - Operación: " + lstDatosTarjeta[i].NumeroOperacion + Environment.NewLine;
                            }
                        }
                    }
                }
                if (sCargosPreviosAplicados != String.Empty)
                    // Si tiene un cargo previo aplicado le indicamos si desea aplicar el pago anterior
                    if (UsuarioValidoParaCargosPorServicio)
                    {
                        if (!MessageBox.Show("El PNR actual ya cuenta con Cargos por Servicio previos aplicados" + Environment.NewLine + Environment.NewLine + sCargosPreviosAplicados + Environment.NewLine + "¿Desea realizar nuevos Cargos por Servicio? ", Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information).Equals(DialogResult.Yes))
                        {
                            LimpiarLista();
                            for (int i = 0; i < lstDatosTarjeta.Count; i++)
                            {
                                lstDatosTarjeta[i].Pagado = true;
                            }
                            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_TICKETEMISSION_CONFIRMATION);
                            return false;
                        }
                        else
                        {
                            Clean();
                        }
                    }
                    else
                    {
                        Clean();
                    }
            }
            return true;
        }

        /// <summary>
        /// Valida el tipo de Tarjeta ingresado con el que esta ligado al DK actual
        /// </summary>
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
                        " ligada al cliente DK: " + ucFirstValidations.DK + ".\nEl número de tarjeta correcto para la forma de pago " + typoCard +
                        " es: (" + numberCardShow + ").\n\n¿Desea continuar con la emisión?", Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (yesNo.Equals(DialogResult.Yes))
                        {
                            DeterminaValidacionGeneracionCargo();
                        }
                        else
                        {
                            txtNumberCardCTS.Text = string.Empty;
                            txtNumberCardCTS.Focus();
                            flags = true;
                            return false;
                        }
                    }
                    else
                    {
                        typoCard = "AIRPLUS";
                        MessageBox.Show("El número de tarjeta capturado no corresponde a la tarjeta de tipo " + typoCard +
                            " ligada al cliente DK: " + ucFirstValidations.DK + ".\nEl número de tarjeta correcto para la forma de pago " + typoCard +
                            " es: (" + numberCardShow + ").", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNumberCardCTS.Text = string.Empty;
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
            try
            {
                int iPaxFrontNumber = iPaxNumber + 1;
                TextBox txtCtrl = (TextBox)this.Controls.Find("txtPax" + iPaxFrontNumber, true)[0];
                decimal dcMontoNoCero = 0;
                Decimal.TryParse(txtCtrl.Text, out dcMontoNoCero);
                dtsTarjeta.MontoCargo = dcMontoNoCero;
            }
            catch (Exception ex)
            {
                string sError = ex.Message;
            }
        }

        private void cmbTypeCard_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int iCurrentPaxNumberMenosUno = iCurrentPosicion - 1;

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
            txtNumberCardCTS.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular);
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
                        ///Se conecta con el WebService de ValidateDKsAndCreditCards y extrae el num. de cuenta
                        ///del DK Actual...
                        WsMyCTS wsServ = new WsMyCTS();
                        MyCTS.Services.ValidateDKsAndCreditCards.GetTranferCheckNumber data = new MyCTS.Services.ValidateDKsAndCreditCards.GetTranferCheckNumber();
                        data = wsServ.GetTranferCheckNumberMyCTS(ucFirstValidations.DK);
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
            bool Status = ChargesPerService.ValidateTestingUsers(ChargesPerService.OrigenTipoCargo.FlujoAereo);
            lblLeyendaIva.Visible = Status;
            return Status;
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

        private void HideStart()
        {
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
        }

        public static bool ReturnForMisc = false;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                ReturnForMisc = false;

                if (MessageBox.Show("¿Esta seguro que desea regresar sin aplicar ningún cargo?", Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information).Equals(DialogResult.Yes))
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTICKETSEMISSIONINSTRUCTIONS);
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
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
        private void cmbGenerico_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveCurrentPaxFormPayment();
        }

        private void txtNombreTarjetahabiente_Leave(object sender, EventArgs e)
        {
            SaveCurrentPaxFormPayment();
        }
    }
}

