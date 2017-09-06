using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.ChargeOfServiceLowFare;
using MyCTS.Entities;
using MyCTS.Presentation.Reservations.Availability.ChargeOfServiceLowFare.PassangerChargeOfService;
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;
using MyCTS.Services.PagosMIT;
using MyCTS.Business;

namespace MyCTS.Presentation
{
    public partial class ucChargeOfServiceLowFare : CustomUserControl, IViewChargeOfServiceLowFare
    {
        private ChargeOfServiceLowFarePresenter _presenter;
        private TableLayoutPanel _table;
        private static bool UsuarioValidoParaCargosPorServicio = false;
        public static List<CreditCardInfo> lstDatosTarjeta = null;
        public static ChargesPerService.OrigenTipoCargo TipoCargo;
        
        public ucChargeOfServiceLowFare()
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

        //TODO: Agregar el caso cuando se recibe una session de Interjet para el cargo por servicio.
        private List<IPassanger> Passangers
        {
            get
            {
                try
                {
                    if (VolarisSession.IsVolarisProcess)
                    {
                        List<IPassanger> Pax = new List<IPassanger>();

                        for (int i = 0; i < VolarisSession.InterJetPassangers.Count; i++)
                        {
                            Pax.Add(VolarisSession.InterJetPassangers[i] as IPassanger);
                        }
                        return Pax;
                    }
                    if (Parameter is InterJetSession)
                    {
                        var session = (InterJetSession)Parameter;
                        var ticket = (InterJetTicket)session.Session["CurrentTicket"];
                        return ticket.Passangers.GetAll().Cast<IPassanger>().ToList();
                    }
                    return new List<IPassanger>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void ucChargeOfServiceLowFare_Load(object sender, EventArgs e)
        {
            _presenter = new ChargeOfServiceLowFarePresenter
                             {
                                 Repository = new ChargeOfServiceLowFareRepository(),
                                 View = this,
                                 OnComplete = OnCompleted
                             };

            _presenter.LoadChargeOfServiceComponents(Passangers);
            UsuarioValidoParaCargosPorServicio = ChargesPerService.ValidateTestingUsers(ChargesPerService.OrigenTipoCargo.BajoCosto);
            lblLeyendaIva.Visible = UsuarioValidoParaCargosPorServicio;
            //this.buttonPanel.Location = new Point(this.buttonPanel.Location.X,this.buttonPanel.Location.Y + (160 * VolarisSession.AddPassengerComplete.Count)+ 260);
        }

        private void OnCompleted(object sender, EventArgs eventArgs)
        {
            if (sender != null)
            {
                this.container.Controls.Add(sender as Control);

                if (sender is TableLayoutPanel)
                {
                    _table = (TableLayoutPanel)sender;
                    int rowIndex = _table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    this.buttonPanel.Dock = DockStyle.Right;
                    this.buttonPanel.Visible = true;
                    _table.Controls.Add(this.buttonPanel, 0, rowIndex);
                }
                this.waitingForControls1.Visible = false;
                this.container.Visible = true;
            }
        }

        #region Miembros de IBaseView


        public void ValidateInput()
        {

        }

        public bool IsValid { get; set; }

        #endregion

        private void continueButton_Click(object sender, EventArgs e)
        {
            if (VolarisSession.IsVolarisProcess)
            {
                if (!FillVolarisRemarks())
                {
                    Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucLowFareEndRecord", this.Parameter, new[] { "Volaris" });
                }
            }
            if (IsInterJet)
            {
                if (!FillInterJetRemarks())
                {
                    Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucLowFareEndRecord", this.Parameter, new[] { "InterJet" });
                }            
            }
        }

        private bool FillInterJetRemarks()
        {
            bool errores = false;
            int iNumeroPasajero = 1;
            var assignedPassangers = _table.Controls.OfType<ucPassangerChargeOfServiceLowFare>();
            if (assignedPassangers != null && assignedPassangers.Any())
            {
                if (assignedPassangers.All(c => c.IsValid))
                {
                    var interJetTicket = ((InterJetTicket)((InterJetSession)this.Parameter).Session["CurrentTicket"]);

                    if (interJetTicket != null)
                    {
                        ucServicesFeePayApply.lstDatosTarjeta = new List<CreditCardInfo>();
                        foreach (var assignaedPassangers in assignedPassangers)//no entra
                        {
                            if (assignaedPassangers.IsAssigned)
                            {
                                if (UsuarioValidoParaCargosPorServicio)
                                {
                                    string sNombresPasajeros = String.Empty;
                                    string sRemark = String.Empty;
                                    bool cargosAplicado = AplicarCargos(ref sNombresPasajeros, iNumeroPasajero, assignaedPassangers, ref sRemark);                                                                   
                                }
                                else
                                {
                                    interJetTicket.Remarks.Add(assignaedPassangers.ChargeOfServiceRemark);
                                }
                            }
                            iNumeroPasajero = iNumeroPasajero + 1;
                        }
                    }
                }
            }
            return errores;
        }

        private bool FillVolarisRemarks()
        {
            bool errores = false;
            int iNumeroPasajero = 1;
            var assignedPassangers = _table.Controls.OfType<ucPassangerChargeOfServiceLowFare>();
            if (assignedPassangers != null && assignedPassangers.Any())
            {
                if (assignedPassangers.All(c => c.IsValid))
                {
                    var reservation = VolarisSession.ItinerarioVolaris;
                    if (reservation != null)
                    {
                        ucServicesFeePayApply.lstDatosTarjeta = new List<CreditCardInfo>();
                        foreach (var assignaedPassangers in assignedPassangers)
                        {
                            if (assignaedPassangers.IsAssigned)
                            {
                                if (UsuarioValidoParaCargosPorServicio)
                                {
                                    string sNombresPasajeros = String.Empty;
                                    string sRemark = String.Empty;
                                    bool cargosAplicado = AplicarCargos(ref sNombresPasajeros, iNumeroPasajero, assignaedPassangers, ref sRemark);                                                                        
                                }
                                else
                                {
                                    VolarisSession.Remarks.Add(assignaedPassangers.ChargeOfServiceRemark);
                                }
                            }
                            iNumeroPasajero = iNumeroPasajero + 1;
                        }
                    }
                }
            }
            return errores;
        }

        private bool IsVolaris
        {
            get { return (this.Parameter != null && this.Parameter is VolarisReservation); }
        }

        private bool IsInterJet
        {
            get
            {
                return (this.Parameter != null && this.Parameter is InterJetSession);
            }
        }

        private bool AplicarCargos(ref string sNombresPasajeros, int iNumeroPasajero, ucPassangerChargeOfServiceLowFare assignaedPassangers, ref string sRemark)
        {
            bool bCargosFallidos = false;
            string recLoc = String.Empty;
            StringBuilder sb = new StringBuilder();
            if (UsuarioValidoParaCargosPorServicio)
            {
                CreditCardInfo info = new CreditCardInfo();                
                recLoc = lstDatosTarjeta[0].PNR;

                info.PNR = lstDatosTarjeta[0].PNR;
                info.Activo = true;
                info.OrigenVenta = "C";
                info.PaxNumber = iNumeroPasajero;

                info.AnioVencimiento = lstDatosTarjeta[0].AnioVencimiento;
                info.CodigoSeguridad = lstDatosTarjeta[0].CodigoSeguridad;
                info.MesVencimiento = lstDatosTarjeta[0].MesVencimiento;
                info.MontoCargo = lstDatosTarjeta[0].MontoCargo;
                info.NombreTitular = lstDatosTarjeta[0].NombreTitular;
                info.NumeroTarjeta = lstDatosTarjeta[0].NumeroTarjeta;
                info.TipoTarjeta = lstDatosTarjeta[0].TipoTarjeta;

                ucServicesFeePayApply.lstDatosTarjeta.Add(info);

            }
            else
            {
                for (int i = 0; i < lstDatosTarjeta.Count; i++)
                {
                    ChargesPerService.BuilCommandToSendOld(iNumeroPasajero, lstDatosTarjeta[i]);
                }
            }
            return bCargosFallidos;
        }       
    }
}
