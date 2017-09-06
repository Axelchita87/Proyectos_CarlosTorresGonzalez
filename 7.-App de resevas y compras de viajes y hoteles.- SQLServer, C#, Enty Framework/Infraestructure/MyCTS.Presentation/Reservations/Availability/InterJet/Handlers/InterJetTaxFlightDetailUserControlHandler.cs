using System.Globalization;
using MyCTS.Entities;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using MyCTS.Business;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetTaxFlightDetailUserControlHandler : InterJetUserControlHandler
    {

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {

        }

        /// <summary>
        /// Sets the adult icon.
        /// </summary>
        private void SetAdultIcon()
        {
            this.PassangerIcon.Image = global::MyCTS.Presentation.Properties.Resources.newPax;
            this.PassangerIcon.Location = new System.Drawing.Point(48, 3);
            this.PassangerIcon.Name = "pictureBox1";
            this.PassangerIcon.Size = new System.Drawing.Size(27, 37);
            this.PassangerIcon.TabIndex = 14;
            this.PassangerIcon.TabStop = false;
        }

        /// <summary>
        /// Sets the child icon.
        /// </summary>
        private void SetChildIcon()
        {

            this.PassangerIcon.Image = global::MyCTS.Presentation.Properties.Resources.newPaxChild;
            this.PassangerIcon.Location = new System.Drawing.Point(49, 3);
            this.PassangerIcon.Name = "pictureBox1";
            this.PassangerIcon.Size = new System.Drawing.Size(27, 27);
            this.PassangerIcon.TabIndex = 14;
            this.PassangerIcon.TabStop = false;
        }

        private void SetInfantIcon()
        {

            this.PassangerIcon.Image = global::MyCTS.Presentation.Properties.Resources.babySmall;
            this.PassangerIcon.Location = new System.Drawing.Point(50, 3);
            this.PassangerIcon.Name = "pictureBox1";
            this.PassangerIcon.Size = new System.Drawing.Size(27, 17);
            this.PassangerIcon.TabIndex = 14;
            this.PassangerIcon.TabStop = false;
        }

        /// <summary>
        /// Gets the current user control.
        /// </summary>
        private ucInterJetTaxFlightDetail CurrentUserControl
        {
            get
            {

                return this.UserControl as ucInterJetTaxFlightDetail;
            }
        }


        public decimal TotalPrice
        {
            get;
            set;
        }

        public PictureBox PassangerIcon
        {
            get;
            set;
        }

        private int cont;


        /// <summary>
        /// Sets the information.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <param name="flight">The flight.</param>
        public void SetInformation(InterJetTicket ticket, InterJetFlight flight)
        {
            this.TotalPrice = flight.TotalPayed;
            string impuestos = string.Empty;

            if (CurrentUserControl.PassangerType == InterJetPassangerType.Adult)
            {
                SetAdultIcon();
                decimal basePrice = flight.PriceDetail.Adult.BasePrice;
                decimal ivaTotal = flight.PriceDetail.Adult.IVA;
                decimal tuaTotal = flight.PriceDetail.Adult.TUA;
                decimal extraTaxes = flight.PriceDetail.Adult.TotalExtraTaxes; // TODO: total de impuestos en caso de sea internacionale
                decimal discount = flight.PriceDetail.Adult.Discount;
                decimal totalPrice = flight.PriceDetail.Adult.Total;
                this.TotalPrice = totalPrice;

                if (ListTaxesInterjet.roud && InterJetPreviousPrincingHandler.Conexion)
                {
                    cont = ListTaxesInterjet.BasePriceList.Count / 2;
                    ListTaxesInterjet.mit = cont / 2;
                    decimal a = ListTaxesInterjet.BasePriceList[ListTaxesInterjet.turning] + ListTaxesInterjet.TaxesList[ListTaxesInterjet.turningTaxes] - ListTaxesInterjet.DiscountList[ListTaxesInterjet.turning];
                    this.TotalPrice = a;
                    this.SetFare(ListTaxesInterjet.BasePriceList[ListTaxesInterjet.turning], ListTaxesInterjet.IVA[ListTaxesInterjet.turning], ListTaxesInterjet.TUA[ListTaxesInterjet.turning], ListTaxesInterjet.Extras[ListTaxesInterjet.turning], a, ListTaxesInterjet.DiscountList[ListTaxesInterjet.turning], 0, 0, flight.IsInternational);
                    if (ListTaxesInterjet.turning < ListTaxesInterjet.BasePriceList.Count)
                    {
                        ListTaxesInterjet.turning = ListTaxesInterjet.turning + 1;
                    }

                    if (ListTaxesInterjet.turning > ListTaxesInterjet.mit - 1 && ListTaxesInterjet.Fligth == 1)
                    {
                        ListTaxesInterjet.turning = 0;
                    }
                    if (ListTaxesInterjet.turning > cont - 1 && ListTaxesInterjet.Fligth == 2)
                    {
                        ListTaxesInterjet.turning = ListTaxesInterjet.mit;
                    }

                    impuestos = impuestos + ListTaxesInterjet.BasePriceList[ListTaxesInterjet.turning] + ListTaxesInterjet.IVA[ListTaxesInterjet.turning] + ListTaxesInterjet.TUA[ListTaxesInterjet.turning] + ListTaxesInterjet.Extras[ListTaxesInterjet.turning];
                }
                else
                {
                    //Quitar
                    impuestos = basePrice.ToString("#.00") + " " + ivaTotal.ToString("#.00") + " " + tuaTotal.ToString("#.00") + " " + discount.ToString("#.00") + " " + extraTaxes.ToString("#.00");

                    this.SetFare(basePrice, ivaTotal, tuaTotal, extraTaxes, totalPrice, discount, 0, 0, flight.IsInternational);
                }
            }

            if (CurrentUserControl.PassangerType == InterJetPassangerType.Child)
            {
                SetChildIcon();
                decimal basePrice = flight.PriceDetail.Child.BasePrice;
                decimal ivaTotal = flight.PriceDetail.Child.IVA;
                decimal tuaTotal = flight.PriceDetail.Child.TUA;
                decimal extraTaxes = flight.PriceDetail.Child.TotalExtraTaxes; // TODO: total de impuestos en caso de sea internacionale

                decimal discount = flight.PriceDetail.Child.Discount;
                decimal totalPrice = flight.PriceDetail.Child.Total;
                this.TotalPrice = totalPrice;

                if (ListTaxesInterjet.roud && InterJetPreviousPrincingHandler.Conexion)
                {
                    cont = ListTaxesInterjet.BasePriceList.Count / 2;
                    ListTaxesInterjet.mit = cont / 2;
                    decimal a = ListTaxesInterjet.BasePriceList[ListTaxesInterjet.turning] + ListTaxesInterjet.TaxesList[ListTaxesInterjet.turningTaxes] - ListTaxesInterjet.DiscountList[ListTaxesInterjet.turning];
                    this.TotalPrice = a;
                    this.SetFare(ListTaxesInterjet.BasePriceList[ListTaxesInterjet.turning], ListTaxesInterjet.IVA[ListTaxesInterjet.turning], ListTaxesInterjet.TUA[ListTaxesInterjet.turning], ListTaxesInterjet.Extras[ListTaxesInterjet.turning], a, ListTaxesInterjet.DiscountList[ListTaxesInterjet.turning], 0, 0, flight.IsInternational);

                    //ListTaxesInterjet.turningTaxes++;

                    if (ListTaxesInterjet.turning < ListTaxesInterjet.BasePriceList.Count)
                    {
                        ListTaxesInterjet.turning = ListTaxesInterjet.turning + 1;
                    }

                    if (ListTaxesInterjet.turning > ListTaxesInterjet.mit - 1 && ListTaxesInterjet.Fligth == 1)
                    {
                        ListTaxesInterjet.turning = 0;
                    }
                    if (ListTaxesInterjet.turning > cont - 1 && ListTaxesInterjet.Fligth == 2)
                    {
                        ListTaxesInterjet.turning = ListTaxesInterjet.mit;
                    }

                    impuestos = impuestos + ListTaxesInterjet.BasePriceList[ListTaxesInterjet.turning] + ListTaxesInterjet.IVA[ListTaxesInterjet.turning] + ListTaxesInterjet.TUA[ListTaxesInterjet.turning] + ListTaxesInterjet.Extras[ListTaxesInterjet.turning];

                }
                else
                {
                    impuestos = impuestos + " " + basePrice.ToString("#.00") + " " + ivaTotal.ToString("#.00") + " " + tuaTotal.ToString("#.00") + " " + discount.ToString("#.00") + " " + extraTaxes.ToString("#.00");

                    this.SetFare(basePrice, ivaTotal, tuaTotal, extraTaxes, totalPrice, discount, 0, 0, flight.IsInternational);
                }
            }

            if (CurrentUserControl.PassangerType == InterJetPassangerType.Senior)
            {

                SetAdultIcon();
                decimal basePrice = flight.PriceDetail.Senior.BasePrice;
                decimal ivaTotal = flight.PriceDetail.Senior.IVA;
                decimal tuaTotal = flight.PriceDetail.Senior.TUA;
                decimal extraTaxes = flight.PriceDetail.Senior.TotalExtraTaxes; // TODO: total de impuestos en caso de sea internacionale

                decimal discount = flight.PriceDetail.Senior.Discount;
                decimal totalPrice = flight.PriceDetail.Senior.Total;
                this.TotalPrice = totalPrice;

                if (ListTaxesInterjet.roud && InterJetPreviousPrincingHandler.Conexion)
                {
                    cont = ListTaxesInterjet.BasePriceList.Count / 2;
                    ListTaxesInterjet.mit = cont / 2;

                    decimal a = ListTaxesInterjet.BasePriceList[ListTaxesInterjet.turning] + ListTaxesInterjet.TaxesList[ListTaxesInterjet.turningTaxes] - ListTaxesInterjet.DiscountList[ListTaxesInterjet.turning];
                    this.TotalPrice = a;
                    this.SetFare(ListTaxesInterjet.BasePriceList[ListTaxesInterjet.turning], ListTaxesInterjet.IVA[ListTaxesInterjet.turning], ListTaxesInterjet.TUA[ListTaxesInterjet.turning], ListTaxesInterjet.Extras[ListTaxesInterjet.turning], a, ListTaxesInterjet.DiscountList[ListTaxesInterjet.turning], 0, 0, flight.IsInternational);

                    if (ListTaxesInterjet.turning < ListTaxesInterjet.BasePriceList.Count)
                    {
                        ListTaxesInterjet.turning = ListTaxesInterjet.turning + 1;
                    }

                    if (ListTaxesInterjet.turning > ListTaxesInterjet.mit - 1 && ListTaxesInterjet.Fligth == 1)
                    {
                        ListTaxesInterjet.turning = 0;
                    }
                    if (ListTaxesInterjet.turning > cont - 1 && ListTaxesInterjet.Fligth == 2)
                    {
                        ListTaxesInterjet.turning = ListTaxesInterjet.mit;
                    }

                    impuestos = impuestos + ListTaxesInterjet.BasePriceList[ListTaxesInterjet.turning] + ListTaxesInterjet.IVA[ListTaxesInterjet.turning] + ListTaxesInterjet.TUA[ListTaxesInterjet.turning] + ListTaxesInterjet.Extras[ListTaxesInterjet.turning];
                }
                else
                {
                    impuestos = impuestos + " " + basePrice.ToString("#.00") + " " + ivaTotal.ToString("#.00") + " " + tuaTotal.ToString("#.00") + " " + discount.ToString("#.00") + " " + extraTaxes.ToString("#.00");
                    this.SetFare(basePrice, ivaTotal, tuaTotal, extraTaxes, totalPrice, discount, 0, 0, flight.IsInternational);
                }
            }

            //if (CurrentUserControl.PassangerType == InterJetPassangerType.Infant)
            //{
            //    this.SetFare(PriceTotalResponseInterjet.totalPriceInfant, 0, 0, 0, PriceTotalResponseInterjet.totalPriceInfant, 0, 0, 0, flight.IsInternational);

            //}

            //Quitar
            ImpuestosBajoCosto.ImpuestosMostrados = impuestos + " ";
            ImpuestosBajoCostoBL.UpdateImpuestosBajoCosto(ImpuestosBajoCosto.Id, ImpuestosBajoCosto.ImpuestosObtenidos, string.Empty, ImpuestosBajoCosto.ImpuestosMostrados, string.Empty, string.Empty);

        }

        /// <summary>
        /// Sets the fare.
        /// </summary>
        /// <param name="basePrice">The base price.</param>
        /// <param name="iva">The iva.</param>
        /// <param name="tua">The tua.</param>
        /// <param name="extraTaxes">The extra taxes.</param>
        /// <param name="totalPrice">The total price.</param>
        /// <param name="discount">The discount.</param>
        /// <param name="internationalIVa">The international I va.</param>
        /// <param name="tuaInternational">The tua international.</param>
        /// <param name="IsInternational">if set to <c>true</c> [is international].</param>
        private void SetFare(decimal basePrice, decimal iva, decimal tua, decimal extraTaxes, decimal totalPrice, decimal discount, decimal internationalIVa, decimal tuaInternational,
           bool IsInternational)
        {

            Label basePricelabel = this.GetLabelByName("totalBasePriceLabel");
            Label ivaLabel = this.GetLabelByName("totalIVAlabel");
            Label tuaLabel = this.GetLabelByName("label2");
            Label extraTaxesLabel = this.GetLabelByName("totalTaxesLabel");
            Label total = this.GetLabelByName("totalToPayLabel");
            Label discountLabel = this.GetLabelByName("discountTotalLabel");

            basePricelabel.Text = basePrice.ToString("c",new CultureInfo("es-MX"));
            //if (IsInternational)
            //{
            //    ivaLabel.Text = internationalIVa.ToString("c");
            //    tuaLabel.Text = tuaInternational.ToString("c");
            //}
            //else
            //{
            ivaLabel.Text = iva.ToString("c", new CultureInfo("es-MX"));
            tuaLabel.Text = tua.ToString("c", new CultureInfo("es-MX"));
            //}

            extraTaxesLabel.Text = extraTaxes.ToString("c", new CultureInfo("es-MX"));
            total.Text = totalPrice.ToString("c", new CultureInfo("es-MX"));
            discountLabel.Text = string.Format("-{0}", discount.ToString("c", new CultureInfo("es-MX")));

        }
        /// <summary>
        /// Sets the passanger count.
        /// </summary>
        /// <param name="paxNumber">The pax number.</param>
        public void SetPassangerCount(int paxNumber)
        {

            Label paxCounLabel = this.GetLabelByName("numberOfPaxLabel");

            paxCounLabel.Text = paxNumber.ToString();

        }




        /// <summary>
        /// Sets the type of the passanger.
        /// </summary>
        /// <param name="paxType">Type of the pax.</param>
        public void SetPassangerType(InterJetPassangerType paxType)
        {
            Label paxTypeLabel = this.GetLabelByName("paxTypeLabel");

            if (paxType == InterJetPassangerType.Adult)
            {
                paxTypeLabel.Text = "Adulto(s)";
            }

            if (paxType == InterJetPassangerType.Senior)
            {
                paxTypeLabel.Text = "Adulto Mayor(es)";
            }

            if (paxType == InterJetPassangerType.Child)
            {
                paxTypeLabel.Text = "Menor(es)";
            }

        }
    }
}
