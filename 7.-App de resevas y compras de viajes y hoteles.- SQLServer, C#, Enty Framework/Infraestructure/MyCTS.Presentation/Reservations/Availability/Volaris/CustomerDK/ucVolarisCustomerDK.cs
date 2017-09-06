using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.Volaris.CustomerDK;

namespace MyCTS.Presentation
{
    public partial class ucVolarisCustomerDK : CustomUserControl, IVolarisCustomerDKView
    {

        private VolarisCustomerDKPresenter _presenter;
        public ucVolarisCustomerDK()
        {
            InitializeComponent();
        }

        public void ucVolarisCustomerDK_Load(object sender, EventArgs e)
        {
            ClearText();
            _presenter = new VolarisCustomerDKPresenter
                             {
                                 View = this,
                                 Repository = new VolarisCustomerDKRepository()
                             };
            _presenter.OnSearchCustomerDkCompleted += OnSearchCustomerDkCompleted;
            LogProductivity.LogTransaction(Login.Agent, "4-Desplego captura de DK de volaris.--Volaris");
        }

        private void ShowControlsOnError()
        {
            this.waitingForControls1.Visible = false;
            this.container.Visible = true;
        }

        /// <summary>
        /// Called when [search customer dk completed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnSearchCustomerDkCompleted(object sender, EventArgs eventArgs)
        {
            if (!Reservation.CustomerDk.Exist)
            {
                this.errorContainer.Visible = true;
                this.errorLabel.Text = string.Format("El DK {0} no se encuentra en el sistema.\nPor favor verifique la información.", Reservation.CustomerDk.Value.ToUpper());
                ShowControlsOnError();

            }
            if (Reservation.CustomerDk.Exist && !Reservation.CustomerDk.IsActive)
            {
                this.errorContainer.Visible = true;
                this.errorLabel.Text = string.Format("El DK {0} no se encuentra activo en el sistema.\nPor favor verifique la información.", Reservation.CustomerDk.Value.ToUpper());
                ShowControlsOnError();
            }

            if (Reservation.CustomerDk.Exist && Reservation.CustomerDk.IsActive)
            {
                ucFirstValidations.DK = Reservation.CustomerDk.Value;
                ucFirstValidations.Attribute1 = Reservation.CustomerDk.Attribute;
                activeStepsCorporativeQC.CorporativeQualityControls = null;
                activeStepsCorporativeQC.loadQualityControlsList();
                ucFirstValidations.CorporativeQualityControls = activeStepsCorporativeQC.CorporativeQualityControls;
                ucAllQualityControls.globalPaxNumber = Reservation.Passangers.GetTotalOfPassanger();
                ucQualitiesByPax.Pax = Reservation.Passangers.GetTotalOfPassanger();
                builtExtendedDescription();
                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucVolarisPaymentForm", Reservation, null);
            }
        }

        private VolarisReservation Reservation
        {
            get
            {
                if (Parameter != null)
                {

                    return (VolarisReservation)Parameter;
                }
                return null;
            }
        }

        #region Miembros de IVolarisCustomerDKView

        public VolarisCustomerDk CustomerDk { get; set; }

        #endregion

        #region Miembros de IBaseView


        public void ValidateInput()
        {
            IsValid = dkValidator.Validate();
        }

        public bool IsValid { get; set; }

        #endregion

        private void btnAccept_Click(object sender, EventArgs e)
        {
            ValidateInput();
            if (IsValid)
            {
                container.Visible = false;
                waitingForControls1.MessageToShow = "Validando DK..";
                this.waitingForControls1.Visible = true;
                ChargesPerService.DKActualBajoCosto = this.customerDkTextBox.Text;
                _presenter.SearchForCustomerDK(this.customerDkTextBox.Text, Login.OrgId, Reservation);

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucVolarisCustomerDK", this.Reservation, null);
        }

        private void customerDkTextBox_Properties_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnAccept_Click(sender, EventArgs.Empty);

            }
        }

        private void customerDkTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(customerDkTextBox.Text))
            {
                if (customerDkTextBox.Text.EndsWith("990"))
                {
                    hideExtendedDescriptionFields(false);
                    txtDescription1.Text = string.Empty;
                    txtDescription2.Text = string.Empty;
                }
                else
                {
                    hideExtendedDescriptionFields(true);
                }
            }
        }

        private void ClearText()
        {
            txtDescription1.Text = string.Empty;
            txtDescription2.Text = string.Empty;
        }

        private void builtExtendedDescription()
        {
            string description1 = txtDescription1.Text;
            string description2 = txtDescription2.Text;
            string send = string.Empty;
            if (!string.IsNullOrEmpty(description1) | (!string.IsNullOrEmpty(description2)))
            {

                send = Resources.TicketEmission.Constants.COMMANDS_FIVE_POINT;
                if (!string.IsNullOrEmpty(description1))
                {
                    send = string.Concat(send, Resources.TicketEmission.Constants.COMMANDS_DES01_IDENT,
                        description1);
                    if (!string.IsNullOrEmpty(description2))
                    {
                        send = string.Concat(send, Resources.TicketEmission.Constants.COMMANDS_ENDIT_5_DES02_INDENT,
                            description2);
                    }
                }

                else if (!string.IsNullOrEmpty(description2))
                {
                    send = string.Concat(send, Resources.TicketEmission.Constants.COMMANDS_DES02_INDENT,
                        description2);
                }

            }
            if (!string.IsNullOrEmpty(send))
            {
                Reservation.Remarks.Add(send);
            }
        }

        private void hideExtendedDescriptionFields(bool show)
        {
            container2.Visible = show;
        }

        private void txtDescription1_TextChanged(object sender, EventArgs e)
        {
            if (txtDescription1.Text.Length > 49)
                txtDescription2.Focus();
        }

        private void txtDescription2_TextChanged(object sender, EventArgs e)
        {
            if (txtDescription2.Text.Length > 49)
                btnAccept.Focus();
        }

    }
}
