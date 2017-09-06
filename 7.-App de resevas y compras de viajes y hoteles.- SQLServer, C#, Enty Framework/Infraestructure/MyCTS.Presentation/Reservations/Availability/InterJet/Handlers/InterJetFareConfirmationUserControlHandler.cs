using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using System.Windows.Forms;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetFareConfirmationUserControlHandler : InterJetUserControlHandler
    {

        public void Initialize()
        {


        }
        /// <summary>
        /// Sets the flight.
        /// </summary>
        /// <param name="flight">The flight.</param>
        public void SetFlight(InterJetFlight flight)
        {

            //totalPayLabel
            Label basePriceSegmentLabel = this.GetLabelByName("basePriceSegmentLabel");
            basePriceSegmentLabel.Text = flight.SegmentString;

            Label tuaSegmentLabel = this.GetLabelByName("tuaSegmentLabel");
            tuaSegmentLabel.Text = flight.SegmentString;

            Label ivaSegmentLabel = this.GetLabelByName("ivaSegmentLabel");
            ivaSegmentLabel.Text = flight.SegmentString;

            Label discountSegmentLabel = this.GetLabelByName("discountSegmentLabel");
            discountSegmentLabel.Text = flight.SegmentString;
            Label extraTaxesSegmentLabel = this.GetLabelByName("extraTaxesSegmentLabel");
            extraTaxesSegmentLabel.Text = flight.SegmentString;

            Label basePriceLabel = this.GetLabelByName("basePriceLabel");
            Label tuaLabel = this.GetLabelByName("tuaLabel");
            Label extraTaxesLabel = this.GetLabelByName("extraTaxesLabel");
            Label ivaLabel = this.GetLabelByName("ivaLabel");
            Label discountLabel = this.GetLabelByName("discountLabel");
            Label totalPayLabel = this.GetLabelByName("totalPayLabel");



            if (InterJetPreviousPrincingHandler.Conexion && ListTaxesInterjet.roud)
            {
                decimal a = ListTaxesInterjet.BasePriceList[ListTaxesInterjet.turning] + ListTaxesInterjet.TaxesList[ListTaxesInterjet.turningTaxes] + (PriceTotalResponseInterjet.totalPriceInfant/4);
                basePriceLabel.Text =ListTaxesInterjet.BasePriceList[ListTaxesInterjet.turning].ToString("c", new CultureInfo("es-MX"));
                tuaLabel.Text = ListTaxesInterjet.TUA[ListTaxesInterjet.turning].ToString("c", new CultureInfo("es-MX"));
                extraTaxesLabel.Text = ListTaxesInterjet.Extras[ListTaxesInterjet.turning].ToString("c", new CultureInfo("es-MX"));
                ivaLabel.Text = ListTaxesInterjet.IVA[ListTaxesInterjet.turning].ToString("c", new CultureInfo("es-MX"));
                discountLabel.Text = ListTaxesInterjet.DiscountList[ListTaxesInterjet.turning].ToString("c", new CultureInfo("es-MX"));
                totalPayLabel.Text = a.ToString("c", new CultureInfo("es-MX"));

                if (ListTaxesInterjet.turning < ListTaxesInterjet.BasePriceList.Count)
                {
                    ListTaxesInterjet.turning = ListTaxesInterjet.turning + 2;
                }

                if (ListTaxesInterjet.turning >= ListTaxesInterjet.BasePriceList.Count && ListTaxesInterjet.Fligth == 1)
                {
                    ListTaxesInterjet.turning = 0;
                }
                if (ListTaxesInterjet.turning >= ListTaxesInterjet.BasePriceList.Count && ListTaxesInterjet.Fligth == 2)
                {
                    ListTaxesInterjet.turning = 1;
                }

            }
            else
            {
                basePriceLabel.Text = flight.TotalBasePrice.ToString("c", new CultureInfo("es-MX"));
                tuaLabel.Text = flight.TUATotal.ToString("c", new CultureInfo("es-MX"));
                extraTaxesLabel.Text = flight.TotalExtraTaxes.ToString("c", new CultureInfo("es-MX"));
                ivaLabel.Text = flight.IvaTotal.ToString("c", new CultureInfo("es-MX"));
                discountLabel.Text = flight.TotalDiscount.ToString("c", new CultureInfo("es-MX"));
                totalPayLabel.Text = flight.TotalPayed.ToString("c", new CultureInfo("es-MX"));
                if (PriceTotalResponseInterjet.isInfant)
                {
                    var a = flight.TotalPayed + PriceTotalResponseInterjet.totalPriceInfant;
                    totalPayLabel.Text = a.ToString("c", new CultureInfo("es-MX"));
                }
            }
           
        }
    }
}
