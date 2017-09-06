using System;
using System.Globalization;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.Volaris.PreviousPricing.Passanger;

using System.Collections.Generic;
using System.Drawing;

namespace MyCTS.Presentation
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ucVolarisPreviousPassangerPricing : CustomUserControl, VolarisPreviousPassangerPricingView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ucVolarisPreviousPassangerPricing"/> class.
        /// </summary>
        public ucVolarisPreviousPassangerPricing()
        {
            InitializeComponent();
            _presenter = new VolarisPreviousPassangerPricingPresenter()
            {
                View = this,
                Repository = new VolarisPreviousPassangerRepository()
            };
            _type = VolarisPassangerType.None;
        }


        public void ucVolarisPreviousPassangerPricing_Load(object sender, EventArgs args)
        {

            _presenter.InitializeView();

        }


        private VolarisPreviousPassangerPricingPresenter _presenter;


        #region Miembros de VolarisPreviousPassangerPricingView


        /// <summary>
        /// Gets or sets the base price.
        /// </summary>
        /// <value>
        /// The base price.
        /// </value>
        public decimal BasePrice
        {
            get
            {

                return Convert.ToDecimal(basePrice.Text);

            }
            set
            {
                basePrice.Text = value.ToString("c", new CultureInfo("es-MX"));
            }

        }

        /// <summary>
        /// Gets or sets the taxes.
        /// </summary>
        /// <value>
        /// The taxes.
        /// </value>
        public decimal Taxes
        {
            get { return Convert.ToDecimal(taxes.Text); }
            set { taxes.Text = value.ToString("c", new CultureInfo("es-MX")); }
        }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>
        /// The total.
        /// </value>
        public decimal Total
        {
            get { return Convert.ToDecimal(total.Text); }
            set { total.Text = value.ToString("c", new CultureInfo("es-MX")); }
        }

        /// <summary>
        /// Gets or sets the passanger count.
        /// </summary>
        /// <value>
        /// The passanger count.
        /// </value>
        public string PassangerCount
        {
            get { return passangerCount.Text; }
            set { passangerCount.Text = value; }
        }


        private Dictionary<VolarisPassangerType, string> _passangerTypDescriptorDispatcher;
        private Dictionary<VolarisPassangerType, string> PassangerTypDescriptorDispatcher
        {
            get
            {
                return _passangerTypDescriptorDispatcher ??
                       (_passangerTypDescriptorDispatcher = new Dictionary<VolarisPassangerType, string>()
                                                                {
                                                                      {VolarisPassangerType.Adult, "Adulto(s)"},
                                                                         {VolarisPassangerType.Child,"Menor(es)"},
                                                                         {VolarisPassangerType.Infant,"Infante(s)"}

                                                                });
            }
        }


        private Dictionary<VolarisPassangerType, Bitmap> _passangersImage;
        /// <summary>
        /// Gets the passanger image container.
        /// </summary>
        private Dictionary<VolarisPassangerType, Bitmap> PassangerImageContainer
        {

            get
            {
                return _passangersImage ?? (_passangersImage = new Dictionary<VolarisPassangerType, Bitmap>()
                                                                     {
                                                                         {VolarisPassangerType.Adult, Properties.Resources.newPax},
                                                                         {VolarisPassangerType.Child,Properties.Resources.newPaxChild},
                                                                         {VolarisPassangerType.Infant,Properties.Resources.babySmall}
                                                                     });
            }
        }



        /// <summary>
        /// 
        /// </summary>
        private readonly VolarisPassangerType _type;
        /// <summary>
        /// Gets or sets the type of the passanger.
        /// </summary>
        /// <value>
        /// The type of the passanger.
        /// </value>
        public VolarisPassangerType PassangerType
        {
            get { return _type; }
            set
            {
                if (PassangerImageContainer.ContainsKey(value))
                {
                    pictureBox1.Image = PassangerImageContainer[value];
                }

                if (PassangerTypDescriptorDispatcher.ContainsKey(value))
                {
                    this.passangerType.Text = PassangerTypDescriptorDispatcher[value];
                }
            }
        }

        #endregion

        #region Miembros de IBaseView


        /// <summary>
        /// Validates the input.
        /// </summary>
        public void ValidateInput()
        {

        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        public bool IsValid { get; set; }

        #endregion

        #region Miembros de VolarisPreviousPassangerPricingView

        public void SetFare(VolarisPassangerFare fare)
        {
            _presenter.SetFare(fare);
        }

        #endregion
    }
}
