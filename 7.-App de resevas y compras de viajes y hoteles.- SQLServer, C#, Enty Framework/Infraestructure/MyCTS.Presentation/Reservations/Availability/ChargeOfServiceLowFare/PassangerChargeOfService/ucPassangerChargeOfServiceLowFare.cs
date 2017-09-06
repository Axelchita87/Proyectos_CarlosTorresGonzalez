using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MyCTS.Entities;
using DevExpress.XtraEditors;

namespace MyCTS.Presentation.Reservations.Availability.ChargeOfServiceLowFare.PassangerChargeOfService
{
    public partial class ucPassangerChargeOfServiceLowFare : UserControl, IViewPassangerChargeOfServiceLowFare
    {
        private readonly PassangerChargeOfServicePresenter _presenter;
        public ucPassangerChargeOfServiceLowFare()
        {
            InitializeComponent();
            _presenter = new PassangerChargeOfServicePresenter();
            IsValid = true;

        }

        #region Miembros de IViewPassangerChargeOfServiceLowFare

        public string PassangerName
        {
            get { return passangerNameLabel.Text; }
            set { passangerNameLabel.Text = value; }
        }

        public decimal Amount
        {
            get { return Convert.ToDecimal(amountTextBox.Text); }
            set { amountTextBox.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public bool ApplyChargeOfServce
        {
            get { return applyChargeOfServiceCheck.Checked; }
            set { applyChargeOfServiceCheck.Checked = value; }
        }

        public bool IsAssigned { get; set; }

        public string NumeroTarjeta { get; set; }


        private BackgroundWorker _animateWorker;
        public void Animate()
        {
            this.groupControl1.Visible = false;
            this.progressPanel1.Visible = true;
            _animateWorker = new BackgroundWorker { };
            _animateWorker.DoWork += _animateWorker_DoWork;
            _animateWorker.RunWorkerCompleted += _animateWorker_RunWorkerCompleted;
            _animateWorker.RunWorkerAsync();
        }

        void _animateWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            try
            {
                this.progressPanel1.Visible = false;
                this.groupControl1.Visible = true;
                this.chargeOfServiceApply.Visible = true;


            }
            finally
            {
                _animateWorker.Dispose();

            }

        }

        void _animateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(1500);

        }

        #endregion

        #region Miembros de IBaseView


        public void ValidateInput()
        {

        }

        public bool IsValid { get; set; }

        #endregion

        #region Miembros de IViewPassangerChargeOfServiceLowFare


        public MyCTS.Entities.IPassanger Passanger
        {
            get { return _presenter.GetPassanger(); }
            set
            {
                _presenter.SetPassanger(value);
            }
        }

        #endregion

        private void ucPassangerChargeOfServiceLowFare_Load(object sender, EventArgs e)
        {
            _presenter.View = this;
            _presenter.Repository = new PassangerChargeOfServiceLowFareRepository();
            _presenter.LoadPassanger();
        }

        #region Miembros de IViewPassangerChargeOfServiceLowFare



        private readonly Dictionary<GenericFormOfPayment, Bitmap> _imageConverter = new Dictionary
            <GenericFormOfPayment, Bitmap>
                                                                                {
                                                                                    {GenericFormOfPayment.Visa,Properties.Resources._1327945295_visa},
                                                                                    {GenericFormOfPayment.AmericanExpress, Properties.Resources._1327945757_amex},
                                                                                    {GenericFormOfPayment.MasterCard,Properties.Resources._1327945807_mastercard},
                                                                                    {GenericFormOfPayment.Cash, Properties.Resources._cash},
                                                                                    {GenericFormOfPayment.Check, Properties.Resources._cash},
                                                                                    {GenericFormOfPayment.Transfer, Properties.Resources._cash},
                                                                                    {GenericFormOfPayment.UniversalTravelPlan,Properties.Resources._32x24_uatpSmall}
                                                                                };


        private readonly Dictionary<GenericFormOfPayment, string> _cardConverter = new Dictionary
        <GenericFormOfPayment, string>
                                                                                {
                                                                                    {GenericFormOfPayment.Visa,"CCPV"},
                                                                                    {GenericFormOfPayment.AmericanExpress, "CCAC"},
                                                                                    {GenericFormOfPayment.MasterCard,"CCPV"},
                                                                                    {GenericFormOfPayment.Cash, "CA"},
                                                                                    {GenericFormOfPayment.Check, "CH"},
                                                                                    {GenericFormOfPayment.Transfer, "TR"},
                                                                                    {GenericFormOfPayment.UniversalTravelPlan, "CCTC"}
                                                                                };
        private FormOfPayment _creditCard;
        public FormOfPayment GenericCreditCard
        {
            get { return _creditCard; }
            set
            {
                if (value != null)
                {
                    _creditCard = value;
                    this.creditCardNumberTextBox.Text = MascaraNumeroTarjeta(value.CrediCardNumber,"X");
                    if (_imageConverter.ContainsKey(value.Type))
                    {
                        this.cardTypePicture.Image = _imageConverter[value.Type];
                        this.chargeOfServiceApply.Visible = true;
                        chargeOfServiceAssigned.Visible = true;
                        IsAssigned = true;
                    }
                }
            }
        }

        #endregion

        private void applyChargeOfServiceCheck_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = (CheckEdit)sender;

            if (checkBox != null && checkBox.Checked)
            {
                this.amountTextBox.Text = "0.00";
                this.creditCardNumberTextBox.Text = "N/A";
                IsAssigned = false;
                this.chargeOfServiceApply.Visible = false;
                this.cardTypePicture.Image = Properties.Resources.unkwonCard;
            }
        }
        
        private static string MascaraNumeroTarjeta(string NumeroTarjeta, string LetraSuplantadora)
        {
            if (string.IsNullOrEmpty(NumeroTarjeta))
            {
                return String.Empty;
            }

            if (string.IsNullOrEmpty(LetraSuplantadora))
            {
                LetraSuplantadora = "X";
            }

            if (NumeroTarjeta.Length > 10)
            {
                Int32 iDigitosInvisibles = NumeroTarjeta.Length;
                string NumeroTarjetaIzquierda = NumeroTarjeta.Substring(0, 6);
                string NumeroTarjetaDerecha = NumeroTarjeta.Substring(iDigitosInvisibles - 4, 4);
                NumeroTarjeta = NumeroTarjetaIzquierda.PadRight(NumeroTarjeta.Length - 4, Char.Parse(LetraSuplantadora.Substring(0, 1))) + NumeroTarjetaDerecha;
            }

            return NumeroTarjeta;
        }

        #region Miembros de IViewPassangerChargeOfServiceLowFare


        public bool UseCreditCard { get {
            return !(this.GenericCreditCard.Type == GenericFormOfPayment.Cash);
        } }

        public bool UseCash {
            get {
                return (this.GenericCreditCard.Type == GenericFormOfPayment.Cash);
        } }

        #endregion

        #region Miembros de IViewPassangerChargeOfServiceLowFare


        private string GetRemark()
        {

            if (UseCreditCard)
            {
                return string.Format(@"5.</C23-0{3}*{0}-{1}-{2}/>",
                                     this.Amount.ToString("0.00", new CultureInfo("es-mx")),
                                      this._cardConverter[this.GenericCreditCard.Type],
                                      this.GenericCreditCard.CrediCardNumber,
                                 
                                      this.Passanger.ID
                                     );
            }

            if (UseCash)
            {
                return string.Format(@"5.</C23-0{2}*{0}-{1}/>",
                                     this.Amount.ToString("0.00", new CultureInfo("es-mx")),
                                     this._cardConverter[this.GenericCreditCard.Type],
                                     this.Passanger.ID
                                      );
            }
            return string.Empty;

        }

        public string GetRemarkChargeForService(string Operacion, string Autorizacion)
        {
            return string.Format(@"5.</C23-0{0}*{1}-{2}-{3}-{4}-{5}/>", this.Passanger.ID, this.Amount.ToString("0.00", new CultureInfo("es-mx")), this._cardConverter[this.GenericCreditCard.Type], NumeroTarjeta, Operacion, Autorizacion);
        }

        public string GetRemarkChargeForService(string Remark)
        {
            return string.Format(Remark);
        }

        public string ChargeOfServiceRemark
        {
            get { return this.GetRemark(); }
            set
            {

            }
        }

        #endregion
    }
}
