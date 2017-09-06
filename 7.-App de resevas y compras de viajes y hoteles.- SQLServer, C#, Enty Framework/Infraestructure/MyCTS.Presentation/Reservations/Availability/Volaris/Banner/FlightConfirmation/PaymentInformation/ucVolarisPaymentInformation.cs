using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.FlightConfirmation.PaymentInformation
{

    public partial class ucVolarisPaymentInformation : CustomUserControl, IVolarisPaymentInformationView
    {

        private readonly VolarisPaymentInformationPresenter _presenter;
        public ucVolarisPaymentInformation()
        {
            InitializeComponent();
            _presenter = new VolarisPaymentInformationPresenter();
        }



        #region Miembros de IBaseView


        public void ValidateInput()
        {

        }

        public bool IsValid { get; set; }

        #endregion

        #region Miembros de IVolarisPaymentInformationView

        public VolarisReservation Reservation
        {
            get { return _presenter.GetReservation(); }
            set
            {
                _presenter.SetReservation(value);
            }
        }

        #endregion

        private void ucVolarisPaymentInformation_Load(object sender, EventArgs e)
        {
            _presenter.View = this;
            _presenter.Repository = new VolarisPaymentInformationRepository();
            _presenter.SetValues();

        }

        #region Miembros de IVolarisPaymentInformationView


        public string FullProtectedCard
        {
            get { return this.protectedCardLabel.Text; }
            set { protectedCardLabel.Text = value; }
        }

        private readonly Dictionary<VolarisCreditCardType, Bitmap> _cardImages = new Dictionary<VolarisCreditCardType, Bitmap>
                                                                            {
                                                                                {VolarisCreditCardType.Visa, Properties.Resources._1327945295_visa},
                                                                                {VolarisCreditCardType.AmericanExpress, Properties.Resources._1327945757_amex},
                                                                                {VolarisCreditCardType.MasterCard, Properties.Resources._1327945807_mastercard}
                                                                            };

        private VolarisCreditCardType _cardType;
        public VolarisCreditCardType CardType
        {
            get { return _cardType; }
            set
            {

                _cardType = value;
                if(_cardImages.ContainsKey(value))
                {
                    this.pictureBox1.Image = _cardImages[value];
                }
            }
        }

        public decimal SubTotal
        {
            get { return Convert.ToDecimal(this.subTotalLabel.Text); }
            set { this.subTotalLabel.Text = value.ToString("c", new CultureInfo("es-MX")); }
        }

        public decimal Taxes
        {
            get { return Convert.ToDecimal(this.taxesLabel.Text); }
            set { this.taxesLabel.Text = value.ToString("c", new CultureInfo("es-MX")); }
        }

        public decimal Total
        {
            get { return Convert.ToDecimal(this.totalLabel.Text); }
            set { this.totalLabel.Text = value.ToString("c", new CultureInfo("es-MX")); }
        }

        #endregion
    }
}
