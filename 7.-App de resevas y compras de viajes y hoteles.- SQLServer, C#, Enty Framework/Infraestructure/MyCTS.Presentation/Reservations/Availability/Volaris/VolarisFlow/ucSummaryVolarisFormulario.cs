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
using MyCTS.Presentation.Reservations.Availability.Volaris.Handler;
using MyCTS.Services.Contracts.Volaris;
using MyCTS.Business;

namespace MyCTS.Presentation
{
    public partial class ucSummaryVolarisFormulario : CustomUserControl
    {
       
        public ucSummaryVolarisFormulario()
        {
            InitializeComponent();
        }

        private void ucSummaryVolarisFormulario_Load(object sender, EventArgs e)
        {
            try
            {
                VolarisServiceManager cliente = new VolarisServiceManager();
                cliente.ObtenerImpuestos();
                #region Datos Pasajero
                for (int i = 0; i < VolarisSession.AddPassengerComplete.Count; i++)
                {
                    lblPax.Text = lblPax.Text + "Pasajero:    " + VolarisSession.AddPassengerComplete[i].AddPassenger.Titulo + " "+ VolarisSession.AddPassengerComplete[i].AddPassenger.Nombres + " " + VolarisSession.AddPassengerComplete[i].AddPassenger.Apellidos + Environment.NewLine;
                }
                this.segmentContainer1.Location = new Point(this.segmentContainer1.Location.X, segmentContainer1.Location.Y + (11 * VolarisSession.AddPassengerComplete.Count));
                this.segmentContainer2.Location = new Point(this.segmentContainer2.Location.X, segmentContainer2.Location.Y + (11 * VolarisSession.AddPassengerComplete.Count));
                this.segmentContainer3.Location = new Point(this.segmentContainer3.Location.X, segmentContainer3.Location.Y + (11 * VolarisSession.AddPassengerComplete.Count));
                this.segmentContainer4.Location = new Point(this.segmentContainer4.Location.X, segmentContainer4.Location.Y + (11 * VolarisSession.AddPassengerComplete.Count));
                this.buttonPanel1.Location = new Point(this.buttonPanel1.Location.X, buttonPanel1.Location.Y + (11 * VolarisSession.AddPassengerComplete.Count));
                this.buttonPanel2.Location = new Point(this.buttonPanel2.Location.X, buttonPanel2.Location.Y + (11 * VolarisSession.AddPassengerComplete.Count));
                this.buttonPanel3.Location = new Point(this.buttonPanel3.Location.X, buttonPanel3.Location.Y + (11 * VolarisSession.AddPassengerComplete.Count));
                this.buttonPanel4.Location = new Point(this.buttonPanel4.Location.X, buttonPanel4.Location.Y + (11 * VolarisSession.AddPassengerComplete.Count));
                #endregion
 
                #region Datos de Vuelo
                string impuestos = string.Empty;

                for (int i = 0; i < VolarisSession.ItinerarioVolaris.Count; i++)
                {
                    if (i == 0)
                    {
                       

                        if (VolarisSession.ItinerarioVolaris.Count == 4)
                        {
                            lblDepartureItinerary1.Text = VolarisSession.ItinerarioVolaris[0].Itinerary + VolarisSession.ItinerarioVolaris[1].Itinerary.Substring(3, 4);
                            lblArrivalTime1.Text = VolarisSession.ItinerarioVolaris[1].FechaLlegada.ToString("t", CultureInfo.InvariantCulture) + "hrs";
                        }
                        else
                        {
                            lblDepartureItinerary1.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;
                            lblArrivalTime1.Text = VolarisSession.ItinerarioVolaris[i].FechaLlegada.ToString("t", CultureInfo.InvariantCulture) + "hrs";
                        }

                        lblDepartureTime1.Text = VolarisSession.ItinerarioVolaris[i].FechaInicio.ToString("t", CultureInfo.InvariantCulture) + "hrs";
                        

                        basePriceAdultl1.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].PrecioBaseAdult.ToString());
                        totalPayAdult1.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].PrecioTotalAdult.ToString());
                        lblNumberOfPaxAdult1.Text = VolarisSession.ContAdult.ToString();
                        ivaAdult1.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].IVAAdult.ToString());
                        tuaAdult1.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].TUAAdult.ToString());
                        discountAdult1.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].DiscountAdult.ToString()); 
                        extraTaxesAdult1.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].OtrosImpuestosAdult.ToString());

                        basePriceChild1.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].PrecioBaseChild.ToString());
                        totalPayChild1.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].PrecioTotalChild.ToString());
                        lblNumberOfPaxChild1.Text = VolarisSession.ContChild.ToString();
                        ivaChild1.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].IVAChild.ToString());
                        tuaChild1.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].TUAChild.ToString());
                        discountChild1.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].DiscountChild.ToString());
                        extraTaxesChild1.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].OtrosImpuestosChild.ToString());
                        totalPayInfant1.Text = TwoDecimal((VolarisSession.Extra / VolarisSession.TotalSegments).ToString());

                        if (VolarisSession.ContInfant > 0)
                        {
                            lblNumberOfPaxInfant1.Text = VolarisSession.ContInfant.ToString();

                            ShowInfant(true);
                        }
                        else
                        {
                            ShowInfant(false);
                        }


                        //quitar
                        impuestos = impuestos + "ADT" + basePriceAdultl1.Text + " " + ivaAdult1.Text + " " + extraTaxesAdult1.Text + " " + tuaAdult1.Text + " " + discountAdult1.Text;
                        impuestos = impuestos + "CHD" + basePriceChild1.Text + " " + ivaChild1.Text + " " + extraTaxesChild1.Text + " " + tuaChild1.Text + " " + discountChild1.Text;


                        lblTOTALPriceMount1.Text = (Convert.ToDecimal(totalPayAdult1.Text) + Convert.ToDecimal(totalPayChild1.Text) + Convert.ToDecimal(totalPayInfant1.Text)).ToString();

                        VolarisSession.BasePriceTotal = Convert.ToDecimal(basePriceAdultl1.Text) + Convert.ToDecimal(basePriceChild1.Text);
                        VolarisSession.PagoTotal = Convert.ToDecimal(lblTOTALPriceMount1.Text);
                        VolarisSession.TaxesTotal = VolarisSession.PagoTotal - VolarisSession.BasePriceTotal;

                        if (VolarisSession.ContChild == 0)
                        {
                            ShowChild1(false);
                            ShowChild2(false);
                            ShowChild3(false);
                            ShowChild4(false);
                        }
                        if (VolarisSession.ItinerarioVolaris.Count == 1)
                        {
                            buttonPanel1.Visible = true;
                            buttonPanel2.Visible = false;
                            buttonPanel3.Visible = false;
                            buttonPanel4.Visible = false;
                            ShowControls(false);
                            ShowControls2(false);
                            ShowControls3(false);
                        }

                    }
                    if (i == 1 || i==2)
                    {
                        lblDepartureItinerary2.Text = VolarisSession.ItinerarioVolaris[i].Itinerary;
                        lblArrivalTime2.Text = VolarisSession.ItinerarioVolaris[i].FechaLlegada.ToString("t", CultureInfo.InvariantCulture) + "hrs";

                        if (VolarisSession.ItinerarioVolaris.Count == 4)
                        {
                            lblDepartureItinerary2.Text = VolarisSession.ItinerarioVolaris[2].Itinerary + VolarisSession.ItinerarioVolaris[3].Itinerary.Substring(3, 4);
                            lblArrivalTime2.Text = VolarisSession.ItinerarioVolaris[2].FechaLlegada.ToString("t", CultureInfo.InvariantCulture) + "hrs";
                        }

                        lblDepartureTime2.Text = VolarisSession.ItinerarioVolaris[i].FechaInicio.ToString("t", CultureInfo.InvariantCulture) + "hrs";

                        basePriceAdultl2.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].PrecioBaseAdult.ToString());
                        totalPayAdult2.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].PrecioTotalAdult.ToString());
                        lblNumberOfPaxAdult2.Text = VolarisSession.ContAdult.ToString();
                        ivaAdult2.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].IVAAdult.ToString());
                        tuaAdult2.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].TUAAdult.ToString());
                        discountAdult2.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].DiscountAdult.ToString());
                        extraTaxesAdult2.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].OtrosImpuestosAdult.ToString());

                        basePriceChild2.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].PrecioBaseChild.ToString());
                        totalPayChild2.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].PrecioTotalChild.ToString());
                        lblNumberOfPaxChild2.Text = VolarisSession.ContChild.ToString();
                        ivaChild2.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].IVAChild.ToString());
                        tuaChild2.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].TUAChild.ToString());
                        discountChild2.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].DiscountChild.ToString());
                        extraTaxesChild2.Text = TwoDecimal(VolarisSession.ItinerarioVolaris[i].OtrosImpuestosChild.ToString());

                        lblNumberOfPaxInfant2.Text = VolarisSession.ContInfant.ToString();
                        totalPayInfant2.Text = TwoDecimal((VolarisSession.Extra / VolarisSession.TotalSegments).ToString());

                        lblNumberOfPaxInfant3.Text = VolarisSession.ContInfant.ToString();
                        totalPayInfant3.Text = TwoDecimal((VolarisSession.Extra / VolarisSession.TotalSegments).ToString());

                        lblNumberOfPaxInfant4.Text = VolarisSession.ContInfant.ToString();
                        totalPayInfant4.Text = TwoDecimal((VolarisSession.Extra / VolarisSession.TotalSegments).ToString());

                        //quitar
                        impuestos = impuestos + "ADT" + basePriceAdultl2.Text + " " + ivaAdult2.Text + " " + extraTaxesAdult2.Text + " " + tuaAdult2.Text + " " + discountAdult2.Text;
                        impuestos = impuestos + "CHD" + basePriceChild2.Text + " " + ivaChild2.Text + " " + extraTaxesChild2.Text + " " + tuaChild2.Text + " " + discountChild2.Text;

                        lblTOTALPriceMount2.Text = (Convert.ToDecimal(totalPayAdult2.Text) + Convert.ToDecimal(totalPayChild2.Text) + Convert.ToDecimal(totalPayInfant2.Text)).ToString();

                        VolarisSession.BasePriceTotal = VolarisSession.BasePriceTotal + Convert.ToDecimal(basePriceAdultl2.Text) + Convert.ToDecimal(basePriceChild2.Text);
                        VolarisSession.PagoTotal = VolarisSession.Venta;
                        VolarisSession.TaxesTotal = VolarisSession.PagoTotal - VolarisSession.BasePriceTotal;

                        buttonPanel1.Visible = false;
                        buttonPanel2.Visible = true;
                        buttonPanel3.Visible = false;
                        buttonPanel4.Visible = false;
                        ShowControls(true);
                        ShowControls2(false);
                        ShowControls3(false);
                    }
                }
                //quitar
                ImpuestosBajoCosto.ImpuestosMostrados = impuestos;
                ImpuestosBajoCostoBL.UpdateImpuestosBajoCosto(ImpuestosBajoCosto.Id, ImpuestosBajoCosto.ImpuestosObtenidos, string.Empty, ImpuestosBajoCosto.ImpuestosMostrados, string.Empty, string.Empty);

            #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string TwoDecimal(string cantidad)
        {
            string newCantidad = string.Empty;
            try
            {
                string[] decimales = cantidad.Split('.');
                newCantidad = decimales[0] + "." + decimales[1].Substring(0, 2);
                return newCantidad;
            }
            catch (Exception ex)
            {
                newCantidad = cantidad + ".00";
                return newCantidad;
            }
        }

        private void ShowControls(bool valor)
        {
            segmentContainer2.Visible = valor;
        }

        private void ShowControls2(bool valor)
        {
            segmentContainer3.Visible = valor;
        }

        private void ShowControls3(bool valor)
        {
            segmentContainer4.Visible = valor;
        }

        private void ShowChild1(bool valor)
        {
            lblNumberOfPaxChild1.Visible = valor;
            lblBasePriceChild1.Visible = valor;
            lblDiscountChild1.Visible = valor;
            lblExtraTaxesChild1.Visible = valor;
            lblIVAChild1.Visible = valor;
            lblPassangerChild1.Visible = valor;
            lblTotalChild1.Visible = valor;
            lblTUAChild1.Visible = valor;
            picPassengerChildIcon1.Visible = valor;
            basePriceChild1.Visible = valor;
            ivaChild1.Visible = valor;
            tuaChild1.Visible = valor;
            discountChild1.Visible = valor;
            extraTaxesChild1.Visible = valor;
            totalPayChild1.Visible = valor;
        }

        private void ShowChild2(bool valor)
        {
            lblNumberOfPaxChild2.Visible = valor;
            lblBasePriceChild2.Visible = valor;
            lblDiscountChild2.Visible = valor;
            lblExtraTaxesChild2.Visible = valor;
            lblIVAChild2.Visible = valor;
            lblPassangerChild2.Visible = valor;
            lblTotalChild2.Visible = valor;
            lblTUAChild2.Visible = valor;
            picPassengerChildIcon2.Visible = valor;
            basePriceChild2.Visible = valor;
            ivaChild2.Visible = valor;
            tuaChild2.Visible = valor;
            discountChild2.Visible = valor;
            extraTaxesChild2.Visible = valor;
            totalPayChild2.Visible = valor;
        }

        private void ShowChild3(bool valor)
        {
            lblNumberOfPaxChild3.Visible = valor;
            lblBasePriceChild3.Visible = valor;
            lblDiscountChild3.Visible = valor;
            lblExtraTaxesChild3.Visible = valor;
            lblIVAChild3.Visible = valor;
            lblPassangerChild3.Visible = valor;
            lblTotalChild3.Visible = valor;
            lblTUAChild3.Visible = valor;
            picPassengerChildIcon3.Visible = valor;
            basePriceChild3.Visible = valor;
            ivaChild3.Visible = valor;
            tuaChild3.Visible = valor;
            discountChild3.Visible = valor;
            extraTaxesChild3.Visible = valor;
            totalPayChild3.Visible = valor;

        }

        private void ShowChild4(bool valor)
        {
            lblNumberOfPaxChild4.Visible = valor;
            lblBasePriceChild4.Visible = valor;
            lblDiscountChild4.Visible = valor;
            lblExtraTaxesChild4.Visible = valor;
            lblIVAChild4.Visible = valor;
            lblPassangerChild4.Visible = valor;
            lblTotalChild4.Visible = valor;
            lblTUAChild4.Visible = valor;
            picPassengerChildIcon4.Visible = valor;
            basePriceChild4.Visible = valor;
            ivaChild4.Visible = valor;
            tuaChild4.Visible = valor;
            discountChild4.Visible = valor;
            extraTaxesChild4.Visible = valor;
            totalPayChild4.Visible = valor;
        }

        private void ShowInfant(bool valor)
        {
            lblNumberOfPaxInfant1.Visible = valor;
            picPassengerInfantIcon1.Visible = valor;
            lblPassangerInfant1.Visible = valor;
            lblTotalInfant1.Visible = valor;
            totalPayInfant1.Visible = valor;

            lblNumberOfPaxInfant2.Visible = valor;
            picPassengerInfantIcon2.Visible = valor;
            lblPassangerInfant2.Visible = valor;
            lblTotalInfant2.Visible = valor;
            totalPayInfant2.Visible = valor;

            lblNumberOfPaxInfant3.Visible = valor;
            picPassengerInfantIcon3.Visible = valor;
            lblPassangerInfant3.Visible = valor;
            lblTotalInfant3.Visible = valor;
            totalPayInfant3.Visible = valor;

            lblNumberOfPaxInfant4.Visible = valor;
            picPassengerInfantIcon4.Visible = valor;
            lblPassangerInfant4.Visible = valor;
            lblTotalInfant4.Visible = valor;
            totalPayInfant4.Visible = valor;

        }

        //Cierra la conexion del servicio y regresa al user control de Disponibilidad
        private void backToContactInformationGeneral_Click(object sender, EventArgs e)
        {
            VolarisServiceManager cliente = new VolarisServiceManager();
            cliente.CloseReservation();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCAVAILABILITY);
        }
        //Continua con el flujo del user control de DK
        private void continueToDKControlButtonGneral_Click(object sender, EventArgs e)
        {
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucDKClient");
        }
    }
}
