using MyCTS.Entities;
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using MyCTS.Presentation.Reservations.Availability.Volaris.VolarisFlow;
using MyCTS.Presentation.Components;
using System.Collections;
using MyCTS.Services.Contracts.Volaris;


namespace MyCTS.Presentation.Reservations.Availability.Volaris.Handler
{
    public class VolarisServicesExtrasCaptureFormHandler : InterJetFormHandler
    {
        public GroupBox PassangerGroupBox
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the flow button panel.
        /// </summary>
        /// <value>
        /// The flow button panel.
        /// </value>
        public Panel FlowButtonPanel
        {
            get;
            set;
        }
        
        private VolarisControlFactory _factory;

        /// <summary>
        /// Gets the inter jet control factory.
        /// </summary>
        private VolarisControlFactory VolarisControlFactory
        {
            get
            {
                if (this._factory == null)
                {
                    this._factory = new VolarisControlFactory
                    {
                        VolarisServicesExtrasCaptureFormHandler = this
                    };
                }
                return this._factory;
            }
        }

        /// <summary>
        /// Gets or sets the user control.
        /// </summary>
        /// <value>
        /// The user control.
        /// </value>
        public CustomUserControl UserControl
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the current form.
        /// </summary>
        /// <value>
        /// The current form.
        /// </value>
        public CustomUserControl CurrentForm
        {
            get;
            set;
        }

        public Panel ServicesPanel
        {
            get;
            set;
        }

        public Panel AdultsPanel
        {
            get;
            set;
        }

        public Button ContinueToCaptureContactButton { get; set; }
        public Button BackToAvailabilityButton { get; set; }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            //TODO: en caso de regresar verificar los pasajeros en session
            this.CreateDynamicPanels();
        }

        /// <summary>
        /// Gets a value indicating whether this instance has passangers.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has passangers; otherwise, <c>false</c>.
        /// </value>
        public bool HasPassangers
        {
            get
            {
                return this.Session["Passangers"] != null;
            }
        }

        /// <summary>
        /// Gets the session.
        /// </summary>
        public Hashtable Session
        {
            get
            {
                ucAvailability.IsInterJetProcess = true;
                if (CurrentForm.Parameter is InterJetSession)
                {
                    var session = (InterJetSession)this.CurrentForm.Parameter;
                    return session.Session;
                }
                return new Hashtable();
            }
        }

        private void CreateDynamicPanels()
        {
            int contAdult = 0;
            int contChildren = 0;
            int contGeneral = 0;
            if (VolarisSession.ListaTipoPassenger.Count > 0)
            {
                foreach (TiposVolaris.PassengerType a in VolarisSession.ListaTipoPassenger)
                {

                    if (a.ToString() == "Adult")
                    {
                        contAdult = contAdult + 1;
                    }
                    if (a.ToString() == "Children")
                    {
                        contChildren = contChildren + 1;
                    }
                }
                contGeneral = contAdult + contChildren;

                if (contGeneral > 0)
                    this.VolarisControlFactory.LoadServicesExtrasUserControl(this.PassangerGroupBox, contGeneral, this.KeyDownHandler);
            }

            Control lastPanel = VolarisControlFactory.CurrentStack.Pop();
            int y_displacement = 180;
            this.FlowButtonPanel.Location = new Point(this.FlowButtonPanel.Location.X, lastPanel.Location.Y + y_displacement);
            VolarisControlFactory.CurrentStack.Clear();
        }

        /// <summary>
        /// Keys down handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void KeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    //this.DisplayContactPassangerForm();
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                //this.DisplayInterJetAvailabilityForm();
            }
        }

        public void DisplayContactPassangerForm()
        {
            this.GetServicesExtras();
            Loader.AddToPanel(Loader.Zone.Middle, this.CurrentForm, "ucSummaryVolarisFormulario");
        }

        public void GetServicesExtras()
        {
            var extras = new List<VolarisServicesExtras>();
            extras.AddRange(this.GetExtras(this.PassangerGroupBox));
            var valores = this.PassangerGroupBox;
            VolarisSession.ExtrasServices = new List<VolarisServicesExtras>();

            for (int i = 0; i < extras.Count; i++)
            {
                if (extras[i].TipoServicio != "")
                {
                    VolarisServicesExtras extra = new VolarisServicesExtras();
                    extra.NamePax = extras[i].NamePax;
                    extra.Departure = extras[i].Departure;
                    extra.DepartureService = extras[i].DepartureService;
                    extra.Arrival = extras[i].Arrival;
                    extra.ArrivalService = extras[i].ArrivalService;
                    extra.TipoServicio = extras[i].TipoServicio;
                    VolarisSession.ExtrasServices.Add(extra);
                }
            }

            int paxCont=1;
            VolarisSession.VolarisExtras = new List<ExtrasViajeVolaris>();
            ExtrasViajeVolaris volarisExtra = null;


            for (int i = 0; i < VolarisSession.ExtrasServices.Count; i++)
            {

                if(paxCont >VolarisSession.ContPax)
                {
                    paxCont=1;
                }
                string codigoSSR= ConvertType(VolarisSession.ExtrasServices[i].TipoServicio);
                if (VolarisSession.ExtrasServices[i].DepartureService)
                {
                    volarisExtra = new ExtrasViajeVolaris();
                    string[] vuelo = VolarisSession.ExtrasServices[i].Departure.Split('-');
                    volarisExtra.CodigoSSR = codigoSSR;
                    volarisExtra.Destino = vuelo[0];
                    volarisExtra.NumeroPasajero = paxCont;
                    volarisExtra.Origen = vuelo[1];
                    VolarisSession.VolarisExtras.Add(volarisExtra);
                }
                if (VolarisSession.ExtrasServices[i].ArrivalService)
                {
                    volarisExtra = new ExtrasViajeVolaris();
                    string[] vuelo = VolarisSession.ExtrasServices[i].Arrival.Split('-');
                    volarisExtra.CodigoSSR = codigoSSR;
                    volarisExtra.Destino = vuelo[0];
                    volarisExtra.NumeroPasajero = paxCont;
                    volarisExtra.Origen = vuelo[1];
                    VolarisSession.VolarisExtras.Add(volarisExtra);
                }
                paxCont++;
            }

            VolarisServiceManager cliente = new VolarisServiceManager();
           decimal cantidad = cliente.ServiciosExtras(VolarisSession.VolarisExtras , VolarisSession.Signature);

        }

        public string ConvertType(string nombreTipo)
        {
            string codigoSSR = string.Empty;
            if (nombreTipo.Trim() == "10 Kilos Extras")
            {
                codigoSSR = "BG10";
            }
            else if (nombreTipo.Trim() == "15 Kilos Extras")
            {
                codigoSSR = "BG15";
            }
            else if (nombreTipo.Trim() == "20 Kilos Extras")
            {
                codigoSSR = "BG20";
            }
            else if (nombreTipo.Trim() == "Silla de Ruedas")
            {
                codigoSSR = "WCHR";
            }
            else if (nombreTipo.Trim() == "Mas Velocidad")
            {
                codigoSSR = "VOIR";
            }
            else if (nombreTipo.Trim() == "Adulto Mayor")
            {
                codigoSSR = "USCR";
            }

            return codigoSSR;
        }

        private List<VolarisServicesExtras> GetExtras(GroupBox mainGroupBox)
        {
            var extras = new List<VolarisServicesExtras>();
            var panels = mainGroupBox.Controls.OfType<Panel>();
            var userControlsExtras = panels.Select(e => e.Controls.OfType<ucServicesExtrasPassenger>().FirstOrDefault()).ToList();
            if (userControlsExtras.Any())
            {
                extras = userControlsExtras.Where(userControl => userControl != null).Select(uc => uc.Extras).ToList();
            }
            return extras;
        }

        /// <summary>
        /// Gets the current user control.
        /// </summary>
        private ucServicesExtrasPassenger CurrentUserControl
        {
            get
            {
                return this.UserControl as ucServicesExtrasPassenger;
            }
        }

        public override void RecoverFromError()
        {
            base.RecoverFromError("Fallo de obtencion de datos de Volaris");
        }
       
    }
}
