using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.Volaris.Handler;
using MyCTS.Entities;
using MyCTS.Business;

namespace MyCTS.Presentation
{
    public partial class ucServicesExtrasFormulario : CustomUserControl
    {
        private GroupBox ServicesGroupBox
        {
            get
            {
                return this.groupBoxServicesAdd;
            }
        }

        private Panel ServicesPanel
        {
            get
            {
                return null;
            }
        }

        private Panel AdultsPanel
        {
            get
            {
                return null;
            }
        }

        private Panel FlowButtonPanel
        {
            get
            {
                return this.buttonsPanel;
            }
        }

        VolarisServicesExtras servicesExtras = null;

        private VolarisServicesExtrasCaptureFormHandler _interJetServicesExtrasCaptureFormHandler;
        /// <summary>
        /// 
        /// </summary>
        private VolarisServicesExtrasCaptureFormHandler InterJetServicesExtrasCaptureFormHandler
        {
            get
            {
                if (this._interJetServicesExtrasCaptureFormHandler == null)
                {
                    this._interJetServicesExtrasCaptureFormHandler = new VolarisServicesExtrasCaptureFormHandler
                    {
                        ServicesPanel = this.ServicesPanel,
                        AdultsPanel = AdultsPanel,
                        FlowButtonPanel = this.FlowButtonPanel,
                        CurrentForm = this,
                        PassangerGroupBox = this.ServicesGroupBox,
                        ContinueToCaptureContactButton = this.continueToPaymentButton,
                        BackToAvailabilityButton = this.backToAvailabilityButton,
                    };
                }
                return this._interJetServicesExtrasCaptureFormHandler;
            }
        }

        public ucServicesExtrasFormulario()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer, true);
        }

        private void ucServicesExtrasFormulario_Load(object sender, EventArgs e)
        {
            try
            {
                servicesExtras = new VolarisServicesExtras();
                VolarisSession.ExtrasServices = new List<VolarisServicesExtras>();
                lblTimeDeparture.Text = VolarisSession.ItinerarioVolaris[0].FechaInicio.ToString("dd MMM yyyy").ToUpper();
                lblFlyDeparture.Text = VolarisSession.DepartureRoute;
                if (!string.IsNullOrEmpty(VolarisSession.ArrivalRoute))
                {
                    lblTimeArrival.Text = VolarisSession.ItinerarioVolaris[VolarisSession.ItinerarioVolaris.Count - 1].FechaLlegada.ToString("dd MMM yyyy").ToUpper();
                    lblFlyArrival.Text = VolarisSession.ArrivalRoute;
                }
                else
                {
                    lblTimeArrival.Text = VolarisSession.ItinerarioVolaris[0].FechaInicio.ToString("dd MMM yyyy").ToUpper(); ;
                    lblFlyArrival.Text = VolarisSession.DepartureRoute;
                }
                FillComboBox();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillComboBox()
        {
            List<ServicesExtras> listServicios = ServicesExtrasBL.ServicesExtras(); ;
            bindingSource1.DataSource = listServicios;
            foreach (ServicesExtras servicesExtraItem in listServicios)
           {
               ListItem litem = new ListItem();
               litem.Text = string.Format("{0} - {1}",
                   servicesExtraItem.NombreServicio,
                   servicesExtraItem.CodigoServicio);
               litem.Value = servicesExtraItem.CodigoServicio;
               cmbServiciosExtras.Items.Add(litem);
           }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string[] tipo = cmbServiciosExtras.Text.Split('-');

            if (cmbServiciosExtras.SelectedIndex > -1)
            {
                if (VolarisSession.ExtrasServices.Count > 0)
                {
                    bool existe = false;

                    foreach (VolarisServicesExtras b in VolarisSession.ExtrasServices)
                    {
                        if (b.TipoServicio == tipo[0])
                        {
                            existe = true;
                            break;
                        }
                    }
                    if (!existe)
                    {
                        VolarisServicesExtras servExt = new VolarisServicesExtras();
                        servExt.TipoServicio = tipo[0];
                        VolarisSession.ExtrasServices.Add(servExt);
                        this.InterJetServicesExtrasCaptureFormHandler.Initialize();
                    }
                    else
                    {
                        MessageBox.Show("Ya existe el servicio extra",Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    servicesExtras.TipoServicio = tipo[0];
                    VolarisSession.ExtrasServices.Add(servicesExtras);
                    this.InterJetServicesExtrasCaptureFormHandler.Initialize();
                }
            }
        }

        private void continueToPaymentButton_Click(object sender, EventArgs e)
        {
            if (cmbServiciosExtras.SelectedIndex>0)
            {
                this.InterJetServicesExtrasCaptureFormHandler.DisplayContactPassangerForm();
            }
            else
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, "ucSummaryVolarisFormulario");
            }
        }

        private void backToAvailabilityButton_Click(object sender, EventArgs e)
        {
            VolarisSession.BackServicesExtras = true;
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucVolarisPassangerCaptureFormulario");
        }
    }
}
