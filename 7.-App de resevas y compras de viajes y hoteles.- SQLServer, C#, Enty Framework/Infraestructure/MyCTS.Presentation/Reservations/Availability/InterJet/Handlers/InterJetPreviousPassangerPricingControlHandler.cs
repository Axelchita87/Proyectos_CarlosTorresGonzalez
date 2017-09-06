using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{
    public class InterJetPreviousPassangerPricingControlHandler : InterJetUserControlHandler
    {

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {

        }

        /// <summary>
        /// Gets or sets the passanger previous pricing.
        /// </summary>
        /// <value>
        /// The passanger previous pricing.
        /// </value>
        public InterJetPassangerPreviousPricing PassangerPreviousPricing
        {
            get;
            set;
        }


        /// <summary>
        /// 
        /// </summary>
        private InterJetPassangerType _paxType;
        /// <summary>
        /// Gets or sets the type of the passanger.
        /// </summary>
        /// <value>
        /// The type of the passanger.
        /// </value>
        public InterJetPassangerType PassangerType
        {
            set { _paxType = value; }
            get { return _paxType; }
        }

        /// <summary>
        /// Gets or sets the passanger icon.
        /// </summary>
        /// <value>
        /// The passanger icon.
        /// </value>
        public PictureBox PassangerIcon
        {
            get;
            set;
        }

        /// <summary>
        /// Sets the adult passanger icon.
        /// </summary>
        private void SetAdultPassangerIcon()
        {
            this.PassangerIcon.Image = global::MyCTS.Presentation.Properties.Resources.newPax;
            this.PassangerIcon.Location = new System.Drawing.Point(44, 14);
            this.PassangerIcon.Name = "passangerIcon";
            this.PassangerIcon.Size = new System.Drawing.Size(34, 32);
            this.PassangerIcon.TabIndex = 1;
            this.PassangerIcon.TabStop = false;
        }

        /// <summary>
        /// Sets the child passanger icon.
        /// </summary>
        private void SetChildPassangerIcon()
        {
            this.PassangerIcon.Image = global::MyCTS.Presentation.Properties.Resources.newPaxChild;
            this.PassangerIcon.Location = new System.Drawing.Point(44, 14);
            this.PassangerIcon.Name = "passangerIcon";
            this.PassangerIcon.Size = new System.Drawing.Size(34, 32);
            this.PassangerIcon.TabIndex = 1;
            this.PassangerIcon.TabStop = false;

        }


        /// <summary>
        /// Sets the infant passaanger icon.
        /// </summary>
        private void SetInfantPassaangerIcon()
        {
            this.PassangerIcon.Image = global::MyCTS.Presentation.Properties.Resources.babySmall;
            this.PassangerIcon.Location = new System.Drawing.Point(44, 14);
            this.PassangerIcon.Name = "passangerIcon";
            this.PassangerIcon.Size = new System.Drawing.Size(34, 32);
            this.PassangerIcon.TabIndex = 1;
            this.PassangerIcon.TabStop = false;



        }

        private Dictionary<InterJetPassangerType, Action<InterJetPassangerPreviousPricing>> _actions;
        private Dictionary<InterJetPassangerType, Action<InterJetPassangerPreviousPricing>> Action
        {
            get
            {

                if (_actions == null)
                {
                    _actions = new Dictionary<InterJetPassangerType, Action<InterJetPassangerPreviousPricing>>();
                    _actions.Add(InterJetPassangerType.Adult, SetAdultPrincing);
                    _actions.Add(InterJetPassangerType.Senior, SetSeniorPricing);
                    _actions.Add(InterJetPassangerType.Child, SetChildPrincing);
                    _actions.Add(InterJetPassangerType.Infant, SetInfantPrincing);

                }
                return _actions;
            }
        }

        /// <summary>
        /// Sets the pax pricing.
        /// </summary>
        /// <param name="paxPrincing">The pax princing.</param>
        private void SetPaxPricing(InterJetPassangerPreviousPricing paxPrincing, string pax)
        {
            if (ListTaxesInterjet.roud && InterJetPreviousPrincingHandler.Conexion && pax!= "INF")
            {
                try
                {
                    Label numberOfPax = this.GetLabelByName("numberOfPaxLabel");
                    numberOfPax.Text = paxPrincing.TotalPax.ToString(CultureInfo.InvariantCulture);
                    Label basePrice = this.GetLabelByName("basePriceTotal");
                    basePrice.Text = (ListTaxesInterjet.BasePriceList[ListTaxesInterjet.turning] * paxPrincing.TotalPax).ToString("c", new CultureInfo("es-MX"));
                    Label taxes = this.GetLabelByName("totalTaxesLabel");
                    taxes.Text = (ListTaxesInterjet.TaxesList[ListTaxesInterjet.turning] * paxPrincing.TotalPax).ToString("c", new CultureInfo("es-MX"));
                    Label totalPriceLabel = this.GetLabelByName("totalPriceLabel");
                    ListTaxesInterjet.TotalPrice.Add((ListTaxesInterjet.BasePriceList[ListTaxesInterjet.turning] + ListTaxesInterjet.TaxesList[ListTaxesInterjet.turning]) * paxPrincing.TotalPax);
                    totalPriceLabel.Text = ((ListTaxesInterjet.BasePriceList[ListTaxesInterjet.turning] + ListTaxesInterjet.TaxesList[ListTaxesInterjet.turning]) * paxPrincing.TotalPax).ToString("c", new CultureInfo("es-MX"));
                    ListTaxesInterjet.TotalRound = ListTaxesInterjet.TotalRound + ((ListTaxesInterjet.BasePriceList[ListTaxesInterjet.turning] + ListTaxesInterjet.TaxesList[ListTaxesInterjet.turning]) * paxPrincing.TotalPax);

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
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                Label numberOfPax = this.GetLabelByName("numberOfPaxLabel");
                numberOfPax.Text = paxPrincing.TotalPax.ToString(CultureInfo.InvariantCulture);
                Label basePrice = this.GetLabelByName("basePriceTotal");
                basePrice.Text = (paxPrincing.BasePrice * paxPrincing.TotalPax).ToString("c", new CultureInfo("es-MX"));

                Label taxes = this.GetLabelByName("totalTaxesLabel");
                taxes.Text = (paxPrincing.Taxes * paxPrincing.TotalPax).ToString("c", new CultureInfo("es-MX"));

                Label totalPriceLabel = this.GetLabelByName("totalPriceLabel");
                totalPriceLabel.Text = paxPrincing.Total.ToString("c", new CultureInfo("es-MX"));
            }
        }

        /// <summary>
        /// Sets the adult princing.
        /// </summary>
        /// <param name="paxPrincing">The pax princing.</param>
        private void SetAdultPrincing(InterJetPassangerPreviousPricing paxPrincing)
        {

            SetPaxPricing(paxPrincing, "ADT");
            this.SetAdultPassangerIcon();
            Label passangerTypeLabel = this.GetLabelByName("passangerTypeLabel");
            passangerTypeLabel.Text = "Adulto(s)";

        }

        /// <summary>
        /// Sets the senior pricing.
        /// </summary>
        /// <param name="paxPrincing">The pax princing.</param>
        private void SetSeniorPricing(InterJetPassangerPreviousPricing paxPrincing)
        {

            SetPaxPricing(paxPrincing,"SRM");
            this.SetAdultPassangerIcon();
            Label passangerTypeLabel = this.GetLabelByName("passangerTypeLabel");
            passangerTypeLabel.Text = "Adulto(s) Mayor(es)";

        }

        /// <summary>
        /// Sets the child princing.
        /// </summary>
        /// <param name="paxPrincing">The pax princing.</param>
        private void SetChildPrincing(InterJetPassangerPreviousPricing paxPrincing)
        {
            this.SetChildPassangerIcon();
            SetPaxPricing(paxPrincing,"CHD");

            Label passangerTypeLabel = this.GetLabelByName("passangerTypeLabel");
            passangerTypeLabel.Text = "Menor(es)";
        }

        /// <summary>
        /// Sets the child princing.
        /// </summary>
        /// <param name="paxPrincing">The pax princing.</param>
        private void SetInfantPrincing(InterJetPassangerPreviousPricing paxPrincing)
        {
            SetInfantPassaangerIcon();
            SetPaxPricing(paxPrincing, "INF");

            Label passangerTypeLabel = this.GetLabelByName("passangerTypeLabel");
            passangerTypeLabel.Text = "Infante(s)";
        }

        /// <summary>
        /// Binds this instance.
        /// </summary>
        public void BindPassanger()
        {
            if (PassangerType != null && this.PassangerPreviousPricing != null)
            {
                if (this.Action.ContainsKey(this.PassangerType))
                {

                    this.Action[this.PassangerType](this.PassangerPreviousPricing);

                }
            }

        }



    }
}
