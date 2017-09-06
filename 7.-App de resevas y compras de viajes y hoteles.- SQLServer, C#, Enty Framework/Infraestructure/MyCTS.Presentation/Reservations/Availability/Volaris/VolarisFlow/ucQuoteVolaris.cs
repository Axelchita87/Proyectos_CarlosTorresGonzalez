using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Entities;
using System.Globalization;
using MyCTS.Services.Contracts.Volaris;

namespace MyCTS.Presentation
{
    public partial class ucQuoteVolaris : CustomUserControl
    {
        public ucQuoteVolaris()
        {
            InitializeComponent();
        }

        private void ucQuoteVolaris_Load(object sender, EventArgs e)
        {
            VolarisSession.AddPassengerComplete = new List<DatosPasajerosVolaris>();
            try
            {

                for (int i = 0; i < VolarisSession.ItinerarioVolaris.Count; i++)
                {
                    if (i == 0)
                    {
                        lblDateFly1.Text = VolarisSession.ItinerarioVolaris[i].FechaInicio.ToString("dd MMM yyyy").ToUpper();
                        lblSegmentNumber1.Text = VolarisSession.ItinerarioVolaris[i].NumeroVuelo;
                        lblDepartureItinerary1.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;
                        lblDepartureTime1.Text = VolarisSession.ItinerarioVolaris[i].FechaInicio.ToString("t", CultureInfo.InvariantCulture) + "hrs";
                        lblArrivalTime1.Text = VolarisSession.ItinerarioVolaris[i].FechaLlegada.ToString("t", CultureInfo.InvariantCulture) + "hrs";
                        lblNumberOfPax1.Text = VolarisSession.ContAdult.ToString();
                        lblBasePriceTotal1.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].PrecioBaseAdult.ToString());
                        lblTotalTaxes1.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].TaxAdult.ToString());
                        lblTotalCotizacion1.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].PrecioTotalAdult.ToString());
                        if (VolarisSession.ContChild > 0)
                        {
                            lblBasePriceTotalChild1.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].PrecioBaseChild.ToString(("#.00")));
                            lblTotalTaxesChild1.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].TaxChild.ToString(("#.00")));
                            lblTotalCotizacionChild1.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].PrecioTotalChild.ToString(("#.00")));
                            lblNumberOfPaxChild1.Text = VolarisSession.ContChild.ToString();
                        }
                        if (VolarisSession.ContInfant > 0)
                        {
                            lblBasePriceTotalInfant1.Text = "0.0";
                            lblTotalTaxesInfant1.Text = ((VolarisSession.Extra / VolarisSession.TotalSegments)).ToString(("#.00"));
                            lblTotalCotizacionInfant1.Text = ((VolarisSession.Extra / VolarisSession.TotalSegments)).ToString(("#.00"));
                            lblNumberOfPaxInfant1.Text = VolarisSession.ContInfant.ToString();
                        }
                        
                        if (VolarisSession.ContInfant > 0 && VolarisSession.ContChild == 0)
                        {
                            picPassengerChildIcon1.Image = global::MyCTS.Presentation.Properties.Resources.babySmall;
                            lblBasePriceTotalChild1.Text = "0.0";
                            lblTotalTaxesChild1.Text = ((VolarisSession.Extra / VolarisSession.TotalSegments)).ToString(("#.00"));
                            lblTotalCotizacionChild1.Text = ((VolarisSession.Extra / VolarisSession.TotalSegments)).ToString(("#.00"));
                            lblNumberOfPaxChild1.Text = VolarisSession.ContInfant.ToString();

                            ShowInfant(false);
                        }
                        if (VolarisSession.ContChild == 0 && VolarisSession.ContInfant == 0)
                        {
                            ShowChild(false);
                            ShowInfant(false);

                        }

                        ShowControls(false);
                        ShowControls2(false);
                        ShowControls3(false);
                        if (VolarisSession.ItinerarioVolaris.Count == 1)
                        {
                            lblPriceTotalMount1.Text = TwoDecimal((VolarisSession.Venta + VolarisSession.Extra).ToString());
                            ShowPanel1(true);
                        }
                        else
                        {
                            ShowPanel1(false);
                        }
                    }
                    if (i == 1)
                    {
                        lblDateFly2.Text = VolarisSession.ItinerarioVolaris[i].FechaInicio.ToString("dd MMM yyyy").ToUpper();
                        lblSegmentNumber2.Text = VolarisSession.ItinerarioVolaris[i].NumeroVuelo;
                        lblDepartureItinerary2.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;
                        lblDepartureTime2.Text = VolarisSession.ItinerarioVolaris[i].FechaInicio.ToString("t", CultureInfo.InvariantCulture) + "hrs";
                        lblArrivalTime2.Text = VolarisSession.ItinerarioVolaris[i].FechaLlegada.ToString("t", CultureInfo.InvariantCulture) + "hrs";
                        lblBasePriceTotal2.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].PrecioBaseAdult.ToString());
                        lblTotalTaxes2.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].TaxAdult.ToString());
                        lblTotalCotizacion2.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].PrecioTotalAdult.ToString());
                        lblNumberOfPax2.Text = VolarisSession.ContAdult.ToString();
                        if (VolarisSession.ContChild > 0)
                        {
                            lblBasePriceTotalChild2.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].PrecioBaseChild.ToString(("#.00")));
                            lblTotalTaxesChild2.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].TaxChild.ToString(("#.00")));
                            lblTotalCotizacionChild2.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].PrecioTotalChild.ToString(("#.00")));
                            lblNumberOfPaxChild2.Text = VolarisSession.ContChild.ToString();
                        }
                        if (VolarisSession.ContInfant > 0)
                        {
                            lblBasePriceTotalInfant2.Text = "0.0";
                            lblTotalTaxesInfant2.Text = ((VolarisSession.Extra / VolarisSession.TotalSegments)).ToString(("#.00"));
                            lblTotalCotizacionInfant2.Text = ((VolarisSession.Extra / VolarisSession.TotalSegments)).ToString(("#.00"));
                            lblNumberOfPaxInfant2.Text = VolarisSession.ContInfant.ToString();
                        }
                        if (VolarisSession.ContInfant > 0 && VolarisSession.ContChild == 0)
                        {
                            picPassengerChildIcon2.Image = global::MyCTS.Presentation.Properties.Resources.babySmall;
                            lblBasePriceTotalChild2.Text = "0.0";
                            lblTotalTaxesChild2.Text = ((VolarisSession.Extra / VolarisSession.TotalSegments)).ToString(("#.00"));
                            lblTotalCotizacionChild2.Text = ((VolarisSession.Extra / VolarisSession.TotalSegments)).ToString(("#.00"));
                            lblNumberOfPaxChild2.Text = VolarisSession.ContInfant.ToString();

                        }


                        ShowControls(true);
                        if (VolarisSession.ItinerarioVolaris.Count == 2)
                        {
                            ShowControls2(false);
                            ShowControls3(false);
                            lblPriceTotalMount2.Text = TwoDecimal((VolarisSession.Venta + VolarisSession.Extra).ToString());
                            ShowPanel2(true);
                        }
                        else
                        {
                            ShowPanel2(false);
                        }
                    }
                    if (i == 2)
                    {
                        lblDateFly3.Text = VolarisSession.ItinerarioVolaris[i].FechaInicio.ToString("dd MMM yyyy").ToUpper();
                        lblSegmentNumber3.Text = VolarisSession.ItinerarioVolaris[i].NumeroVuelo;
                        lblDepartureItinerary3.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;
                        lblDepartureTime3.Text = VolarisSession.ItinerarioVolaris[i].FechaInicio.ToString("t", CultureInfo.InvariantCulture) + "hrs";
                        lblArrivalTime3.Text = VolarisSession.ItinerarioVolaris[i].FechaLlegada.ToString("t", CultureInfo.InvariantCulture) + "hrs";
                        lblBasePriceTotal3.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].PrecioBaseAdult.ToString());
                        lblTotalTaxes3.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].TaxAdult.ToString());
                        lblTotalCotizacion3.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].PrecioTotalAdult.ToString());
                        lblNumberOfPax3.Text = VolarisSession.ContAdult.ToString();
                        if (VolarisSession.ContChild > 0)
                        {
                            lblBasePriceTotalChild3.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].PrecioBaseChild.ToString(("#.00")));
                            lblTotalTaxesChild3.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].TaxChild.ToString(("#.00")));
                            lblTotalCotizacionChild3.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].PrecioTotalChild.ToString(("#.00")));
                            lblNumberOfPaxChild3.Text = VolarisSession.ContChild.ToString();
                        }
                        if (VolarisSession.ContInfant > 0)
                        {
                            lblBasePriceTotalInfant3.Text = "0.0";
                            lblTotalTaxesInfant3.Text = ((VolarisSession.Extra / VolarisSession.TotalSegments)).ToString(("#.00"));
                            lblTotalCotizacionInfant3.Text = ((VolarisSession.Extra / VolarisSession.TotalSegments)).ToString(("#.00"));
                            lblNumberOfPaxInfant3.Text = VolarisSession.ContInfant.ToString();
                        }
                        if (VolarisSession.ContInfant > 0 && VolarisSession.ContChild == 0)
                        {
                            picPassengerChildIcon3.Image = global::MyCTS.Presentation.Properties.Resources.babySmall;
                            lblBasePriceTotalChild3.Text = "0.0";
                            lblTotalTaxesChild3.Text = ((VolarisSession.Extra / VolarisSession.TotalSegments)).ToString(("#.00"));
                            lblTotalCotizacionChild3.Text = ((VolarisSession.Extra / VolarisSession.TotalSegments)).ToString(("#.00"));
                            lblNumberOfPaxChild3.Text = VolarisSession.ContInfant.ToString();

                        }

                        ShowControls2(true);
                        ShowControls3(false);
                        if (VolarisSession.ItinerarioVolaris.Count == 3)
                        {
                            ShowPanel3(true);
                            lblPriceTotalMount3.Text = TwoDecimal((VolarisSession.Venta + VolarisSession.Extra).ToString());
                        }
                        else
                        {
                            ShowPanel3(false);
                        }
                    }
                    if (i == 3)
                    {
                        lblDateFly4.Text = VolarisSession.ItinerarioVolaris[i].FechaInicio.ToString("dd MMM yyyy").ToUpper();
                        lblSegmentNumber4.Text = VolarisSession.ItinerarioVolaris[i].NumeroVuelo;
                        lblDepartureItinerary4.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;
                        lblDepartureTime4.Text = VolarisSession.ItinerarioVolaris[i].FechaInicio.ToString("t", CultureInfo.InvariantCulture) + "hrs";
                        lblArrivalTime4.Text = VolarisSession.ItinerarioVolaris[i].FechaLlegada.ToString("t", CultureInfo.InvariantCulture) + "hrs";
                        lblBasePriceTotal4.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].PrecioBaseAdult.ToString());
                        lblTotalTaxes4.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].TaxAdult.ToString());
                        lblTotalCotizacion4.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].PrecioTotalAdult.ToString());
                        lblNumberOfPax4.Text = VolarisSession.ContAdult.ToString();
                        if (VolarisSession.ContChild > 0)
                        {
                            lblBasePriceTotalChild4.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].PrecioBaseChild.ToString(("#.00")));
                            lblTotalTaxesChild4.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].TaxChild.ToString(("#.00")));
                            lblTotalCotizacionChild4.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].PrecioTotalChild.ToString(("#.00")));
                            lblNumberOfPaxChild4.Text = VolarisSession.ContChild.ToString();
                        }
                        if (VolarisSession.ContInfant > 0)
                        {
                            lblBasePriceTotalInfant4.Text = "0.0";
                            lblTotalTaxesInfant4.Text = ((VolarisSession.Extra / VolarisSession.TotalSegments)).ToString(("#.00"));
                            lblTotalCotizacionInfant4.Text = ((VolarisSession.Extra / VolarisSession.TotalSegments)).ToString(("#.00"));
                            lblNumberOfPaxInfant4.Text = VolarisSession.ContInfant.ToString();
                        }
                        if (VolarisSession.ContInfant > 0 && VolarisSession.ContChild == 0)
                        {
                            picPassengerChildIcon4.Image = global::MyCTS.Presentation.Properties.Resources.babySmall;
                            lblBasePriceTotalChild4.Text = "0.0";
                            lblTotalTaxesChild4.Text = ((VolarisSession.Extra / VolarisSession.TotalSegments)).ToString(("#.00"));
                            lblTotalCotizacionChild4.Text = ((VolarisSession.Extra / VolarisSession.TotalSegments)).ToString(("#.00"));
                            lblNumberOfPaxChild4.Text = VolarisSession.ContInfant.ToString();

                        }

                        ShowControls3(true);
                        ShowPanel4(true);
                        lblPriceTotalMount4.Text = TwoDecimal((VolarisSession.Venta + VolarisSession.Extra).ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ShowControls(bool valor)
        {
            FlyGroupBox2.Visible = valor;
        }

        private void ShowControls2(bool valor)
        {
            FlyGroupBox3.Visible = valor;
        }

        private void ShowControls3(bool valor)
        {
            FlyGroupBox4.Visible = valor;
        }

        private void ShowPanel1(bool valor)
        {
            lblPriceTotal1.Visible = valor;
            lblPriceTotalMount1.Visible = valor;
            continueToPassangerControl1.Visible = valor;
            goBackButton1.Visible = valor;
        }

        private void ShowPanel2(bool valor)
        {
            lblPriceTotal2.Visible = valor;
            lblPriceTotalMount2.Visible = valor;
            continueToPassangerControl2.Visible = valor;
            goBackButton2.Visible = valor;
        }

        private void ShowPanel3(bool valor)
        {
            lblPriceTotal3.Visible = valor;
            lblPriceTotalMount3.Visible = valor;
            continueToPassangerControl3.Visible = valor;
            goBackButton3.Visible = valor;
        }

        private void ShowPanel4(bool valor)
        {
            lblPriceTotal4.Visible = valor;
            lblPriceTotalMount4.Visible = valor;
            continueToPassangerControl4.Visible = valor;
            goBackButton4.Visible = valor;
        }

        private void ShowChild(bool valor)
        {
            lblTotalCotizacionChild1.Visible = valor;
            lblBasePriceTotalChild1.Visible = valor;
            lblTotalChild1.Visible = valor;
            lblPriceBaseChild1.Visible = valor;
            lblTaxesChild1.Visible = valor;
            lblTotalTaxesChild1.Visible = valor;
            lblNumberOfPaxChild1.Visible = valor;
            picPassengerChildIcon1.Visible = valor;
            lblPassangerChild1.Visible = valor;

            lblTotalCotizacionChild2.Visible = valor;
            lblBasePriceTotalChild2.Visible = valor;
            lblTotalChild2.Visible = valor;
            lblPriceBaseChild2.Visible = valor;
            lblTaxesChild2.Visible = valor;
            lblTotalTaxesChild2.Visible = valor;
            lblNumberOfPaxChild2.Visible = valor;
            picPassengerChildIcon2.Visible = valor;
            lblPassangerChild2.Visible = valor;

            lblTotalCotizacionChild3.Visible = valor;
            lblBasePriceTotalChild3.Visible = valor;
            lblTotalChild3.Visible = valor;
            lblPriceBaseChild3.Visible = valor;
            lblTaxesChild3.Visible = valor;
            lblTotalTaxesChild3.Visible = valor;
            lblNumberOfPaxChild3.Visible = valor;
            picPassengerChildIcon3.Visible = valor;
            lblPassangerChild3.Visible = valor;

            lblTotalCotizacionChild4.Visible = valor;
            lblBasePriceTotalChild4.Visible = valor;
            lblTotalChild4.Visible = valor;
            lblPriceBaseChild4.Visible = valor;
            lblTaxesChild4.Visible = valor;
            lblTotalTaxesChild4.Visible = valor;
            lblNumberOfPaxChild4.Visible = valor;
            picPassengerChildIcon4.Visible = valor;
            lblPassangerChild4.Visible = valor;
        }

        private void ShowInfant(bool valor)
        {
            lblTotalCotizacionInfant1.Visible = valor;
            lblBasePriceTotalInfant1.Visible = valor;
            lblTotalInfant1.Visible = valor;
            lblPriceBaseInfant1.Visible = valor;
            lblTaxesInfant1.Visible = valor;
            lblTotalTaxesInfant1.Visible = valor;
            lblNumberOfPaxInfant1.Visible = valor;
            picPassengerInfantIcon1.Visible = valor;
            lblPassangerInfant1.Visible = valor;

            lblTotalCotizacionInfant2.Visible = valor;
            lblBasePriceTotalInfant2.Visible = valor;
            lblTotalInfant2.Visible = valor;
            lblPriceBaseInfant2.Visible = valor;
            lblTaxesInfant2.Visible = valor;
            lblTotalTaxesInfant2.Visible = valor;
            lblNumberOfPaxInfant2.Visible = valor;
            picPassengerInfantIcon2.Visible = valor;
            lblPassangerInfant2.Visible = valor;

            lblTotalCotizacionInfant3.Visible = valor;
            lblBasePriceTotalInfant3.Visible = valor;
            lblTotalInfant3.Visible = valor;
            lblPriceBaseInfant3.Visible = valor;
            lblTaxesInfant3.Visible = valor;
            lblTotalTaxesInfant3.Visible = valor;
            lblNumberOfPaxInfant3.Visible = valor;
            picPassengerInfantIcon3.Visible = valor;
            lblPassangerInfant3.Visible = valor;

            lblTotalCotizacionInfant4.Visible = valor;
            lblBasePriceTotalInfant4.Visible = valor;
            lblTotalInfant4.Visible = valor;
            lblPriceBaseInfant4.Visible = valor;
            lblTaxesInfant4.Visible = valor;
            lblTotalTaxesInfant4.Visible = valor;
            lblNumberOfPaxInfant4.Visible = valor;
            picPassengerInfantIcon4.Visible = valor;
            lblPassangerInfant4.Visible = valor;
        }


        private void continueToGeneral_Click(object sender, EventArgs e)
        {
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucVolarisPassangerCaptureFormulario");
        }
  
        private void goBackGeneral_Click(object sender, EventArgs e)
        {
            VolarisServiceManager cliente = new VolarisServiceManager();
            cliente.CloseReservation();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCAVAILABILITY);
        }

        private string TwoDecimal(string cantidad)
        {
            try
            {
                if (!string.IsNullOrEmpty(cantidad))
                {
                    return String.Format("{0:0.00}", Convert.ToDouble(cantidad));
                }
                else
                    return String.Format("{0:0.00}", 0);
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
