using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture.ContactCapture;
using DevExpress.XtraEditors;
using MyCTS.Entities;

namespace MyCTS.Presentation
{
    public partial class ucVolarisContactInformationCapture : CustomUserControl, VolarisContactInformationView
    {
        public ucVolarisContactInformationCapture()
        {
            InitializeComponent();
        }

        #region Miembros de VolarisContactInformationView

        public string CellPhoneLada
        {
            get { return cellLada.Text; }
            set { cellLada.Text = value; }
        }

        public string CellPhone
        {
            get { return cellPhone.Text; }
            set { cellPhone.Text = value; }
        }

        public string TelePhone
        {
            get { return telephone.Text; }
            set { telephone.Text = value; }
        }

        public string TelePhoneLada
        {
            get { return telLada.Text; }
            set { telLada.Text = value; }
        }

        public string EmailConfirmation
        {
            get { return emailConfirmation.Text; }
            set { emailConfirmation.Text = value; }
        }

        public string Email
        {
            get { return email.Text; }
            set { email.Text = value; }
        }

        #endregion

        #region Miembros de IBaseView


        public void ValidateInput()
        {


            IsValid = EmptyControlValidator.Validate();
        }

        public bool IsValid { get; set; }

        #endregion

        private void telLada_TextChanged(object sender, EventArgs e)
        {

            RemoveWarning(sender as TextEdit);
        }

        private void telephone_TextChanged(object sender, EventArgs e)
        {
            RemoveWarning(sender as TextEdit);
        }

        private void email_TextChanged(object sender, EventArgs e)
        {
            RemoveWarning(sender as TextEdit);
        }

        private void emailConfirmation_TextChanged(object sender, EventArgs e)
        {
            RemoveWarning(sender as TextEdit);
        }

        private void RemoveWarning(TextEdit textEdit)
        {
            if (textEdit != null)
            {
                EmptyControlValidator.RemoveControlError(textEdit);
                EmailComparartor.RemoveControlError(textEdit);
            }
        }




        #region Miembros de VolarisContactInformationView




        #endregion

        private VolarisContactInformationPresenter _presenter;
        /// <summary>
        /// Handles the Load event of the ucVolarisContactInformationCapture control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ucVolarisContactInformationCapture_Load(object sender, EventArgs e)
        {
            _presenter = new VolarisContactInformationPresenter()
                             {

                                 View = this,
                                 Repository = new VolarisContactInformationRepository()
                             };
            _presenter.InitializeView();
            Email = Login.Mail.ToLower();
            EmailConfirmation = Login.Mail.ToLower();


        }

        #region Miembros de VolarisContactInformationView


        public VolarisContact Contact
        {
            get { return _presenter.GetContact(); }
        }

        #endregion
    }
}
