using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;
using System.Globalization;
using MyCTS.Presentation.Components;
using System.Security.Permissions;

namespace MyCTS.Presentation
{
    public partial class ucConfirmPurchase : CustomUserControl
    {
        public ucConfirmPurchase()
        {
            InitializeComponent();
        }
        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            var processBlock = new ProcessBlocker();
            if (processBlock.HandleEvent(ref msg, keyData))
            {
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void ucConfirmPurchase_Load(object sender, EventArgs e)
        {
            try
            {
                ucMenuReservations.EnabledMenu = false;
                #region Datos Pasajero
                for (int i = 0; i < VolarisSession.AddPassengerComplete.Count; i++)
                {
                    lblPax.Text = lblPax.Text + "Pasajero:    " + VolarisSession.AddPassengerComplete[i].AddPassenger.Titulo + " " + VolarisSession.AddPassengerComplete[i].AddPassenger.Nombres + " " + VolarisSession.AddPassengerComplete[i].AddPassenger.Apellidos + Environment.NewLine;
                }
                this.segmentContainer1.Location = new Point(this.segmentContainer1.Location.X, segmentContainer1.Location.Y + (11 * VolarisSession.AddPassengerComplete.Count));
                this.gpbRate.Location = new Point(this.gpbRate.Location.X, gpbRate.Location.Y + (11 * VolarisSession.AddPassengerComplete.Count));
                this.panelButton.Location = new Point(this.panelButton.Location.X, panelButton.Location.Y + (11 * VolarisSession.AddPassengerComplete.Count));
                #endregion
                #region Datos Vuelo
                for (int i = 0; i < VolarisSession.ItinerarioVolaris.Count; i++)
                {
                    if (i == 0)
                    {
                        lblReservationCode.Text = VolarisSession.PNR;
                        if (VolarisSession.ItinerarioVolaris.Count == 4)
                        {
                            lblDepartureItinerary1.Text = VolarisSession.ItinerarioVolaris[i].Itinerary.Substring(0, 3) + VolarisSession.ItinerarioVolaris[1].Itinerary.Substring(3, 4);
                            lblItineraryDeparture1.Text = VolarisSession.ItinerarioVolaris[i].Itinerary.Substring(0, 3) + VolarisSession.ItinerarioVolaris[1].Itinerary.Substring(3, 4);
                            lblItineraryDeparture3.Text = VolarisSession.ItinerarioVolaris[i].Itinerary.Substring(0, 3) + VolarisSession.ItinerarioVolaris[1].Itinerary.Substring(3, 4);
                            lblItineraryDeparture4.Text = VolarisSession.ItinerarioVolaris[i].Itinerary.Substring(0, 3) + VolarisSession.ItinerarioVolaris[1].Itinerary.Substring(3, 4);
                            lblItineraryDeparture5.Text = VolarisSession.ItinerarioVolaris[i].Itinerary.Substring(0, 3) + VolarisSession.ItinerarioVolaris[1].Itinerary.Substring(3, 4);
                            lblItineraryDeparture6.Text = VolarisSession.ItinerarioVolaris[i].Itinerary.Substring(0, 3) + VolarisSession.ItinerarioVolaris[1].Itinerary.Substring(3, 4);
                            lblItineraryDeparture7.Text = VolarisSession.ItinerarioVolaris[i].Itinerary.Substring(0, 3) + VolarisSession.ItinerarioVolaris[1].Itinerary.Substring(3, 4);
                            lblNumeberFlyDeparture1.Text = VolarisSession.ItinerarioVolaris[i].NumeroVuelo + VolarisSession.ItinerarioVolaris[1].NumeroVuelo;

                            lblSecondhourDeparture1.Text = VolarisSession.ItinerarioVolaris[1].FechaLlegada.ToString("t", CultureInfo.InvariantCulture) + "hrs";
                        }
                        else
                        {
                            lblDepartureItinerary1.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;
                            lblItineraryDeparture1.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;
                            lblItineraryDeparture3.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;
                            lblItineraryDeparture4.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;
                            lblItineraryDeparture5.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;
                            lblItineraryDeparture6.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;
                            lblItineraryDeparture7.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;
                            lblNumeberFlyDeparture1.Text = VolarisSession.ItinerarioVolaris[i].NumeroVuelo;

                            lblSecondhourDeparture1.Text = VolarisSession.ItinerarioVolaris[i].FechaLlegada.ToString("t", CultureInfo.InvariantCulture) + "hrs";
                        }

                        
                        lblDateDeparture1.Text = VolarisSession.ItinerarioVolaris[i].FechaInicio.ToString("d", CultureInfo.InvariantCulture);
                        lblOnehourDeparture1.Text = VolarisSession.ItinerarioVolaris[i].FechaInicio.ToString("t", CultureInfo.InvariantCulture) + "hrs";

                        lblDepartureBasePrice1.Text = TwoDecimal((VolarisSession.ItinerarioVolaris[i].PrecioBaseAdult + VolarisSession.ItinerarioVolaris[i].PrecioBaseChild).ToString());
                        lblDepartureIva1.Text = TwoDecimal((VolarisSession.ItinerarioVolaris[i].IVAAdult + VolarisSession.ItinerarioVolaris[i].IVAChild).ToString());
                        lblDepartureTua1.Text = TwoDecimal((VolarisSession.ItinerarioVolaris[i].TUAAdult + VolarisSession.ItinerarioVolaris[i].TUAChild).ToString());
                        lblDepartureDiscount1.Text = TwoDecimal((VolarisSession.ItinerarioVolaris[i].DiscountAdult + VolarisSession.ItinerarioVolaris[i].DiscountChild).ToString()); 
                        lblDepartureExtraTaxes1.Text = TwoDecimal((VolarisSession.ItinerarioVolaris[i].OtrosImpuestosAdult + VolarisSession.ItinerarioVolaris[i].OtrosImpuestosChild + (VolarisSession.Extra/ VolarisSession.TotalSegments)).ToString());
                        lblDepartureTotalPay1.Text = TwoDecimal((VolarisSession.ItinerarioVolaris[i].PrecioTotalAdult + VolarisSession.ItinerarioVolaris[i].PrecioTotalChild + (VolarisSession.Extra / VolarisSession.TotalSegments)).ToString());

                        ShowControls1(false);
                        ShowControls2(false);
                        ShowControls3(false);
                    }
                    if (i == 1 || i == 2)
                    {
                        if (VolarisSession.ItinerarioVolaris.Count == 4)
                        {

                            lblArrivalItinerary1.Text = VolarisSession.ItinerarioVolaris[i].Itinerary.Substring(0, 3) + VolarisSession.ItinerarioVolaris[3].Itinerary.Substring(3, 4);
                            lblItineraryArrival1.Text = VolarisSession.ItinerarioVolaris[i].Itinerary.Substring(0, 3) + VolarisSession.ItinerarioVolaris[3].Itinerary.Substring(3, 4);

                            lblItineraryArrival3.Text = VolarisSession.ItinerarioVolaris[i].Itinerary.Substring(0, 3) + VolarisSession.ItinerarioVolaris[3].Itinerary.Substring(3, 4);
                            lblItineraryArrival4.Text = VolarisSession.ItinerarioVolaris[i].Itinerary.Substring(0, 3) + VolarisSession.ItinerarioVolaris[3].Itinerary.Substring(3, 4);
                            lblItineraryArrival5.Text = VolarisSession.ItinerarioVolaris[i].Itinerary.Substring(0, 3) + VolarisSession.ItinerarioVolaris[3].Itinerary.Substring(3, 4);
                            lblItineraryArrival6.Text = VolarisSession.ItinerarioVolaris[i].Itinerary.Substring(0, 3) + VolarisSession.ItinerarioVolaris[3].Itinerary.Substring(3, 4);
                            lblItineraryArrival7.Text = VolarisSession.ItinerarioVolaris[i].Itinerary.Substring(0, 3) + VolarisSession.ItinerarioVolaris[3].Itinerary.Substring(3, 4);

                            lblNumeberFlyArrival1.Text = VolarisSession.ItinerarioVolaris[i].NumeroVuelo + VolarisSession.ItinerarioVolaris[3].NumeroVuelo;
                            lblSecondhourArrival1.Text = VolarisSession.ItinerarioVolaris[3].FechaLlegada.ToString("t", CultureInfo.InvariantCulture) + "hrs";

                        }
                        else
                        {
                            lblArrivalItinerary1.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;
                            lblItineraryArrival1.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;

                            lblItineraryArrival3.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;
                            lblItineraryArrival4.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;
                            lblItineraryArrival5.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;
                            lblItineraryArrival6.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;
                            lblItineraryArrival7.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;

                            lblNumeberFlyArrival1.Text = VolarisSession.ItinerarioVolaris[i].NumeroVuelo;
                            lblSecondhourArrival1.Text = VolarisSession.ItinerarioVolaris[i].FechaLlegada.ToString("t", CultureInfo.InvariantCulture) + "hrs";

                        }

                        
                        lblDateArrival1.Text = VolarisSession.ItinerarioVolaris[i].FechaInicio.ToString("d", CultureInfo.InvariantCulture);
                        lblOnehourArrival1.Text = VolarisSession.ItinerarioVolaris[i].FechaInicio.ToString("t", CultureInfo.InvariantCulture) + "hrs";

                        lblArrivalBasePrice1.Text = TwoDecimal((VolarisSession.ItinerarioVolaris[i].PrecioBaseAdult + VolarisSession.ItinerarioVolaris[i].PrecioBaseChild).ToString());
                        lblArrivalIva1.Text = TwoDecimal((VolarisSession.ItinerarioVolaris[i].IVAAdult + VolarisSession.ItinerarioVolaris[i].IVAChild).ToString());
                        lblArrivalTua1.Text = TwoDecimal((VolarisSession.ItinerarioVolaris[i].TUAAdult + VolarisSession.ItinerarioVolaris[i].TUAChild).ToString());
                        lblArrivalDiscount1.Text = TwoDecimal((VolarisSession.ItinerarioVolaris[i].DiscountAdult + VolarisSession.ItinerarioVolaris[i].DiscountChild).ToString());
                        lblArrivalExtraTaxes1.Text = TwoDecimal((VolarisSession.ItinerarioVolaris[i].OtrosImpuestosAdult + VolarisSession.ItinerarioVolaris[i].OtrosImpuestosChild + (VolarisSession.Extra / VolarisSession.TotalSegments)).ToString());
                        lblArrivalTotalPay1.Text = TwoDecimal((VolarisSession.ItinerarioVolaris[i].PrecioTotalAdult + VolarisSession.ItinerarioVolaris[i].PrecioTotalChild + (VolarisSession.Extra / VolarisSession.TotalSegments)).ToString());

                        ShowControls1(true);
                        ShowControls2(false);
                        ShowControls3(false);
                    }
                    #region Esto ya no se ocupa
                    //if (i == 2)
                    //{
                    //    lblDepartureItinerary2.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;
                    //    lblItineraryDeparture2.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;
                    //    lblNumeberFlyDeparture2.Text = VolarisSession.ItinerarioVolaris[i].NumeroVuelo;
                    //    lblDateDeparture2.Text = VolarisSession.ItinerarioVolaris[i].FechaInicio.ToString("d", CultureInfo.InvariantCulture);
                    //    lblOnehourDeparture2.Text = VolarisSession.ItinerarioVolaris[i].FechaInicio.ToString("t", CultureInfo.InvariantCulture) + "hrs";
                    //    lblSecondhourDeparture2.Text = VolarisSession.ItinerarioVolaris[i].FechaLlegada.ToString("t", CultureInfo.InvariantCulture) + "hrs";

                    //    lblItineraryDeparture8.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;
                    //    lblItineraryDeparture9.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;
                    //    lblItineraryDeparture10.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;
                    //    lblItineraryDeparture11.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;
                    //    lblItineraryDeparture12.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;

                    //    lblDepartureBasePrice2.Text = TwoDecimal((VolarisSession.ItinerarioVolaris[i].PrecioBaseAdult + VolarisSession.ItinerarioVolaris[i].PrecioBaseChild).ToString());
                    //    lblDepartureIva2.Text = TwoDecimal((VolarisSession.ItinerarioVolaris[i].IVAAdult + VolarisSession.ItinerarioVolaris[i].IVAChild).ToString());
                    //    lblDepartureTua2.Text = TwoDecimal((VolarisSession.ItinerarioVolaris[i].TUAAdult + VolarisSession.ItinerarioVolaris[i].TUAChild).ToString());
                    //    lblDepartureDiscount2.Text = "0.00";
                    //    lblDepartureExtraTaxes2.Text = TwoDecimal((VolarisSession.ItinerarioVolaris[i].OtrosImpuestosAdult + VolarisSession.ItinerarioVolaris[i].OtrosImpuestosChild).ToString());
                    //    lblDepartureTotalPay2.Text = TwoDecimal((VolarisSession.ItinerarioVolaris[i].PrecioTotalAdult + VolarisSession.ItinerarioVolaris[i].PrecioTotalChild).ToString());
                    //    ShowControls1(true);
                    //    ShowControls2(true);
                    //    ShowControls3(false);
                    //}
                    //if (i == 3)
                    //{
                    //    lblArrivalItinerary2.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;
                    //    lblItineraryArrival2.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;
                    //    lblNumeberFlyArrival2.Text = VolarisSession.ItinerarioVolaris[i].NumeroVuelo;
                    //    lblDateArrival2.Text = VolarisSession.ItinerarioVolaris[i].FechaInicio.ToString("d", CultureInfo.InvariantCulture);
                    //    lblOnehourArrival2.Text = VolarisSession.ItinerarioVolaris[i].FechaInicio.ToString("t", CultureInfo.InvariantCulture) + "hrs";
                    //    lblSecondhourArrival2.Text = VolarisSession.ItinerarioVolaris[i].FechaLlegada.ToString("t", CultureInfo.InvariantCulture) + "hrs";

                    //    lblItineraryArrival8.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;
                    //    lblItineraryArrival9.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;
                    //    lblItineraryArrival10.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;
                    //    lblItineraryArrival11.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;
                    //    lblItineraryArrival12.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;

                    //    lblArrivalBasePrice2.Text = TwoDecimal((VolarisSession.ItinerarioVolaris[i].PrecioBaseAdult + VolarisSession.ItinerarioVolaris[i].PrecioBaseChild).ToString());
                    //    lblArrivalIva2.Text = TwoDecimal((VolarisSession.ItinerarioVolaris[i].IVAAdult + VolarisSession.ItinerarioVolaris[i].IVAChild).ToString());
                    //    lblArrivalTua2.Text = TwoDecimal((VolarisSession.ItinerarioVolaris[i].TUAAdult + VolarisSession.ItinerarioVolaris[i].TUAChild).ToString());
                    //    lblArrivalDiscount2.Text = "0.00";
                    //    lblArrivalExtraTaxes2.Text = TwoDecimal((VolarisSession.ItinerarioVolaris[i].OtrosImpuestosAdult + VolarisSession.ItinerarioVolaris[i].OtrosImpuestosChild).ToString());
                    //    lblArrivalTotalPay2.Text = TwoDecimal((VolarisSession.ItinerarioVolaris[i].PrecioTotalAdult + VolarisSession.ItinerarioVolaris[i].PrecioTotalChild).ToString());
                    //    ShowControls1(true);
                    //    ShowControls2(true);
                    //    ShowControls3(true);
                    //}
                    #endregion
                }
                #endregion
            }
            catch(Exception ex)
            {
                throw ex;
            }
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

        private void ShowControls1(bool value)
        {
            lblLine2.Visible = value;
            lblArrivalItinerary1.Visible= value;
            lblItineraryArrival1.Visible= value;
            lblNumeberFlyArrival1.Visible= value;
            lblDateArrival1.Visible= value;
            lblOnehourArrival1.Visible= value;
            lblSecondhourArrival1.Visible= value;

            lblItineraryArrival3.Visible= value;
            lblItineraryArrival4.Visible= value;
            lblItineraryArrival5.Visible= value;
            lblItineraryArrival6.Visible= value;
            lblItineraryArrival7.Visible= value;

            lblArrivalBasePrice1.Visible= value;
            lblArrivalIva1.Visible= value;
            lblArrivalTua1.Visible= value;
            lblArrivalDiscount1.Visible= value;
            lblArrivalExtraTaxes1.Visible= value;
            lblArrivalTotalPay1.Visible = value;

            lblSegmentArrival1.Visible = value;
            lblFlyArrival1.Visible = value;
            lblDateArrivalLabel1.Visible = value;
            lblScheduleArrival1.Visible = value;

            lblBasePriceArrival1.Visible = value;
            lblIVAArrival1.Visible = value;
            lblTUAArrival1.Visible = value;
            lblDiscountArrival1.Visible = value;
            lblExtraTaxesArrival1.Visible = value;
            lblTotaArrival1.Visible = value;

        }

        private void ShowControls2(bool value)
        {
            lblLine3.Visible = value;
            lblDepartureItinerary2.Visible = value;
            lblItineraryDeparture2.Visible = value;
            lblNumeberFlyDeparture2.Visible = value;
            lblDateDeparture2.Visible = value;
            lblOnehourDeparture2.Visible = value;
            lblSecondhourDeparture2.Visible = value;
            lblItineraryDeparture8.Visible = value;
            lblItineraryDeparture9.Visible = value;
            lblItineraryDeparture10.Visible = value;
            lblItineraryDeparture11.Visible = value;
            lblItineraryDeparture12.Visible = value;
            lblDepartureBasePrice2.Visible = value;
            lblDepartureIva2.Visible = value;
            lblDepartureTua2.Visible = value;
            lblDepartureDiscount2.Visible = value;
            lblDepartureExtraTaxes2.Visible = value;
            lblDepartureTotalPay2.Visible = value;
            lblSegmentDeparture2.Visible = value;
            lblFlyDeparture2.Visible = value;
            lblDateDepartureLabel2.Visible = value;
            lblScheduleDeparture2.Visible = value;
            lblBasePriceDeparture2.Visible = value;
            lblIVADeparture2.Visible = value;
            lblTUADeparture2.Visible = value;
            lblDiscountDeparture2.Visible = value;
            lblExtraTaxesDeparture2.Visible = value;
            lblTotalDeparture2.Visible = value;

        }

        private void ShowControls3(bool value)
        {
            lblLine4.Visible = value;
            lblArrivalBasePrice2.Visible = value;
            lblArrivalIva2.Visible = value;
            lblArrivalTua2.Visible = value;
            lblArrivalDiscount2.Visible = value;
            lblArrivalExtraTaxes2.Visible = value;
            lblArrivalTotalPay2.Visible = value;
            lblSegmentArrival2.Visible = value;
            lblFlyArrival2.Visible = value;
            lblDateArrivalLabel2.Visible = value;
            lblScheduleArrival2.Visible = value;
            lblArrivalItinerary2.Visible = value;
            lblItineraryArrival2.Visible = value;
            lblNumeberFlyArrival2.Visible = value;
            lblDateArrival2.Visible = value;
            lblOnehourArrival2.Visible = value;
            lblSecondhourArrival2.Visible = value;
            lblItineraryArrival8.Visible = value;
            lblItineraryArrival9.Visible = value;
            lblItineraryArrival10.Visible = value;
            lblItineraryArrival11.Visible = value;
            lblItineraryArrival12.Visible = value;
            lblBasePriceArrival2.Visible = value;
            lblIVAArrival2.Visible = value;
            lblTUAArrival2.Visible = value;
            lblDiscountArrival2.Visible = value;
            lblExtraTaxesArrival2.Visible = value;
            lblTotaArrival2.Visible = value;

        }

        private void continueToDKControlButton4_Click(object sender, EventArgs e)
        {
            if (VolarisSession.DK.Substring(3, 3) == "990")
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, "ucBillingAdressEmission");
            }
            else
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, "ucAllQualityControls");
            }
        }
       
    }
}
