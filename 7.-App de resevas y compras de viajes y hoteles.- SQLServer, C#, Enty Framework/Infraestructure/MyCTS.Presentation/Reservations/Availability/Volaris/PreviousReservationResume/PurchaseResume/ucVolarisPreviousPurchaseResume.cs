using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PreviousReservationResume.PurchaseResume
{
    public partial class ucVolarisPreviousPurchaseResume : CustomUserControl, IVolarisPreviousPurchaseResumeView
    {
        private readonly VolarisPreviousPurchaseResumePresenter _presenter;
        public ucVolarisPreviousPurchaseResume()
        {
            InitializeComponent();
            _presenter = new VolarisPreviousPurchaseResumePresenter()
                             {
                                 Repository = new VolarisPreviousPurchaseResumeRepository(),
                                 View = this
                             };
        }

        #region Miembros de IVolarisPreviousPurchaseResumeView

        public void SetReservation(Entities.VolarisReservation reservation)
        {
            _presenter.SetReservation(reservation);
        }

        public decimal Price
        {
            get { return Convert.ToDecimal(price.Text); }
            set { price.Text = value.ToString("c", new CultureInfo("es-mx")); }

        }

        public decimal Tax
        {
            get
            {
                return Convert.ToDecimal(taxes.Text);
            }
            set
            {
                taxes.Text = value.ToString("c", new CultureInfo("es-mx"));
            }
        }

        public decimal TotalToPay
        {
            get
            {
                return Convert.ToDecimal(totalToPay.Text);
            }
            set
            {
                totalToPay.Text = value.ToString("c", new CultureInfo("es-mx"));
            }
        }

        #endregion

        #region Miembros de IBaseView


        public void ValidateInput()
        {
           
        }

        public bool IsValid { get; set; }

        #endregion
    }
}
