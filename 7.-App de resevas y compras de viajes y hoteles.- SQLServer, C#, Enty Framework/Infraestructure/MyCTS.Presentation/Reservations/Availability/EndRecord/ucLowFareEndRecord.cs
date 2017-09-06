using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.EndRecord;
using MyCTS.Presentation.Reservations.Availability.EndRecord.Services;
using MyCTS.Entities;
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;
using MyCTS.Presentation.Reservations.Availability.InterJet.Mailer;
using MyCTS.Presentation.Reservations.Availability.Volaris.CommandsBuilder;
using MyCTS.Presentation.Reservations.Availability.Volaris.Mailer;

namespace MyCTS.Presentation
{
    public partial class ucLowFareEndRecord : CustomUserControl
    {
        public ucLowFareEndRecord()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            var processBlock = new ProcessBlocker();
            if (processBlock.HandleEvent(ref msg, keyData))
            {
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private string RecordManagerType
        {
            get
            {
                if (this.Parameters != null)
                {
                    return Parameters.FirstOrDefault();
                }
                return string.Empty;
            }
        }

        private LowFareEndRecordPresenter _presenter;
        private void ucLowFareEndRecord_Load(object sender, EventArgs e)
        {
            _presenter = new LowFareEndRecordPresenter
                             {
                                 Repository = new LowFareEndRecordRepository(),
                                 OnActionStart = OnActionStart,
                                 OnActionCompleted = OnActionCompleted,
                                 OnRecordCompleted = OnRecordCompleted,
                                 RecordManagerType = RecordManagerType
                             };

        }

        private bool IsVolaris
        {
            get { return this.Parameter is VolarisReservation; }
        }
        private bool IsInterJet
        {
            get { return this.Parameter is InterJetSession; }
        }


        private InterJetTicket InterJetTicket
        {
            get
            {

                if (this.Parameter is InterJetSession)
                {
                    var session = (InterJetSession)this.Parameter;
                    return (InterJetTicket)session.Session["CurrentTicket"];
                }
                return new InterJetTicket();

            }
        }

        private void OnRecordCompleted(object sender, OnRecordCompletedEventArgs e)
        {
            if (VolarisSession.IsVolarisProcess)
            {
                var reservation = (VolarisReservation)this.Parameter;//preguntar a Luis 
                VolarisSession.ReservationStatus= VolarisReservationStatus.Accepted;
                ucServicesFeePayApply.PNRBajoCostoAerolinea = VolarisSession.PNR;
                ucServicesFeePayApply.PNRBajoCostoSabre = String.Empty;
                ChargesPerService.DKActualBajoCosto = VolarisSession.DK;
                ucServicesFeePayApply.OrigenTipo = ChargesPerService.OrigenTipoCargo.BajoCosto;

                if (!string.IsNullOrEmpty(e.SabrePnr) && e.SabrePnr.Length == 6 && ValidateRegularExpression.ValidatePNR(e.SabrePnr))
                {
                    LogTicketsBL.LogTicketsVolarisUpdate(VolarisSession.PNR, e.SabrePnr);
                    VolarisSession.PNRSabre = e.SabrePnr;
                    ucServicesFeePayApply.PNRBajoCostoSabre = e.SabrePnr;
                    //quitar
                    ImpuestosBajoCostoBL.UpdateImpuestosBajoCosto(ImpuestosBajoCosto.Id, ImpuestosBajoCosto.ImpuestosObtenidos, VolarisSession.PNR, ImpuestosBajoCosto.ImpuestosMostrados, ImpuestosBajoCosto.LineaContable, VolarisSession.PNRSabre);

                    var mailer = new VolarisMailer
                    {
                        Reservation = reservation
                    };
                    mailer.SendTest();
                    if (e.IsInvoiced)
                    {
                        VolarisSession.ReservationStatus = VolarisReservationStatus.Invoiced;
                        VolarisLogger.UpdateReservation(VolarisSession.PNR,
                                                        VolarisSession.PNRSabre, VolarisSession.ReservationStatus);
                        ucServicesFeePayApply.OrigenTipo = ChargesPerService.OrigenTipoCargo.BajoCosto;
                        ucServicesFeePayApply pago = new ucServicesFeePayApply();
                        pago.PayServiceFee();
                        Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucEndRecordSuccess",
                                                        null);
                    }
                }
                else
                {
                    MessageBox.Show("No ha sido posible generar la factura para el servicio aéreo,\n por tal motivo los cargos por servicio en linea\n no pudieron ser completados", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (IsInterJet)
            {
                ucServicesFeePayApply.PNRBajoCostoAerolinea = InterJetTicket.RecordLocator;
                ucServicesFeePayApply.PNRBajoCostoSabre = String.Empty;
                ucServicesFeePayApply.OrigenTipo = ChargesPerService.OrigenTipoCargo.BajoCosto;

                if (!string.IsNullOrEmpty(e.SabrePnr) && e.SabrePnr.Length==6 && ValidateRegularExpression.ValidatePNR(e.SabrePnr))
                {
                    //quitar
                    ImpuestosBajoCostoBL.UpdateImpuestosBajoCosto(ImpuestosBajoCosto.Id, ImpuestosBajoCosto.ImpuestosObtenidos, ImpuestosBajoCosto.PNRBajoCosto, ImpuestosBajoCosto.ImpuestosMostrados, ImpuestosBajoCosto.LineaContable, e.SabrePnr);

                    LogTicketsBL.LogTicketsInterjetUpdate(InterJetTicket.RecordLocator, e.SabrePnr);

                    InterJetTicket.RecordSabre = e.SabrePnr;
                    ucServicesFeePayApply.PNRBajoCostoSabre = e.SabrePnr;
                    var mailer = new InterJetMailer { Ticket = InterJetTicket };
                    mailer.SendConfirmationMail();
                    if (e.IsInvoiced)
                    {
                        InterJetTicket.IsFactured = e.IsInvoiced;
                        var service = new LogInterJetBL();
                        service.InvoiceRecord(InterJetTicket.RecordLocator);
                        MyCTS.Presentation.Reservations.Availability.ChargeOfServiceLowFare.AssignamentChargeOfService.ucChargeOfServiceAssign.sPNR = InterJetTicket.RecordLocator;
                        service.InsertSabreRecord(InterJetTicket.RecordLocator, InterJetTicket.RecordSabre);
                        ucMenuReservations.EnabledMenu = true;
                        ucServicesFeePayApply.OrigenTipo = ChargesPerService.OrigenTipoCargo.BajoCosto;
                        ucServicesFeePayApply pago = new ucServicesFeePayApply();
                        pago.PayServiceFee();
                        Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucEndRecordSuccess",
                                                        null);
                    }
                }
                else
                {
                    MessageBox.Show("No ha sido posible generar la factura para el servicio aéreo,\n por tal motivo los cargos por servicio en linea\n no pudieron ser completados", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

            this.errrorMessageContainer.Visible = e.Success;
            this.errorMessage.Text = e.Message;
            ucMenuReservations.EnabledMenu = true;
            this._group.Visible = true;
            this.loadingControl1.Visible = false;

        }

        private void OnActionCompleted(object sender, OnActionCompletedEventArgs e)
        {
            this.loadingControl1.MessageToShow = e.Message;
        }

        private void OnActionStart(object sender, OnActionStartEventArg e)
        {
            this.loadingControl1.MessageToShow = e.Message;
        }

        private BackgroundWorker _validationWorker;

        private void StartValidationWorker()
        {
            _validationWorker = new BackgroundWorker();
            _validationWorker.DoWork += _validationWorker_DoWork;
            _validationWorker.RunWorkerCompleted += ValidationWorkerOnRunWorkerCompleted;
            _validationWorker.RunWorkerAsync();
        }


        private void OnOpenReservation()
        {
            var comunnicator = new VolarisAPICommunicator();
            this.errorMessage.Text = "Existe una reservación actualmente abierta";
            this.errrorMessageContainer.Visible = true;
            this._group.Visible = true;
            this.loadingControl1.Visible = false;
            this.errrorMessageContainer.Visible = true;
            string sAerolinea = String.Empty;

            if (VolarisSession.IsVolarisProcess)
            {
                sAerolinea = "Volaris";             
            }
            else
            {
                sAerolinea = "Interjet";
               
            }

            DialogResult result =
              MessageBox.Show(
                  "Actualmente cuenta con una reservación abierta.\n¿Desea que el sistema ignore y continue con la emision de " + sAerolinea  + "?\n"
                      .ToUpper(), Resources.Constants.MYCTS, MessageBoxButtons.YesNo,
                  MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                comunnicator.SendCommand("I");
                this._group.Visible = false;
                this.loadingControl1.Visible = true;
                this.errrorMessageContainer.Visible = false;
                this.errorMessage.Text = string.Empty;
                _presenter.EndAndCloseRecord(Parameter, this.txtApplicant.Text);
            }
        }
        private void ValidationWorkerOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                if (e.Error == null)
                {
                    if (e.Result == null)
                    {
                        this._group.Visible = false;
                        this.loadingControl1.Visible = true;
                        this.errrorMessageContainer.Visible = false;
                        this.errorMessage.Text = string.Empty;
                        _presenter.EndAndCloseRecord(Parameter, this.txtApplicant.Text);
                    }                   
                }
                else
                {
                    if (e.Error != null && e.Error.Message.Equals("OpenReservation"))
                    {
                        OnOpenReservation();
                    }
                }
            }
            finally
            {
                _validationWorker.Dispose();
            }
        }


        private void OnInvalidIata()
        {
            this.errorMessage.Text = "Para realizar venta de vuelos de Bajo Costo, es necesario contar con una IATA dentro del PCC, de lo contrario emúlate a matriz con el formato AAA3L64 y llama de nuevo el proceso.";
            this._group.Visible = true;
            this.loadingControl1.Visible = false;
            this.errrorMessageContainer.Visible = true;


        }
        private string GetCurrentPCC(string response)
        {
            if (!string.IsNullOrEmpty(response))
            {

                return response.Substring(0, 4);
            }
            return string.Empty;

        }
        void _validationWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var comunnicator = new VolarisAPICommunicator();

            var responseFromApi = comunnicator.SendCommand("*A");
            if (!responseFromApi.Contains("NO DATA"))
            {

                throw new Exception("OpenReservation");
            }
        }



        private void endRecordButton_Click(object sender, EventArgs e)
        {

            StartValidationWorker();
            this.errorMessage.Text = string.Empty;
            this._group.Visible = false;
            this.loadingControl1.Visible = true;
            this.loadingControl1.MessageToShow = "Verificando credenciales....";
            this.errrorMessageContainer.Visible = false;
            this.errorMessage.Text = string.Empty;
        }



    }
}
