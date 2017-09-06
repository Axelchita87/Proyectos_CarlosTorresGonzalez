using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.FlightConfirmation.ContactInformation
{
    public partial class ucVolarisContactInformation : UserControl, IVolarisContactInformationView
    {
        private readonly VolarisContactInformationPresenter _presenter;
        public ucVolarisContactInformation()
        {
            InitializeComponent();
            _presenter = new VolarisContactInformationPresenter {};
        }

        private void ucVolarisContactInformation_Load(object sender, EventArgs e)
        {
            _presenter.View = this;
            _presenter.Repository = new VolarisContactInformationRepository();
            emailLabel.Text = _presenter.GetPrimaryEmail();
            phoneLabel.Text = _presenter.GetPrimaryPhone();
        }

        #region Miembros de IBaseView


        public void ValidateInput()
        {

        }

        public bool IsValid { get; set; }

        #endregion

        #region Miembros de IVolarisContactInformationView

        public VolarisContact Contact
        {
            get { return _presenter.GetContact(); }
            set
            {
                _presenter.SetContanct(value);
            }
        }



        #endregion
    }
}
