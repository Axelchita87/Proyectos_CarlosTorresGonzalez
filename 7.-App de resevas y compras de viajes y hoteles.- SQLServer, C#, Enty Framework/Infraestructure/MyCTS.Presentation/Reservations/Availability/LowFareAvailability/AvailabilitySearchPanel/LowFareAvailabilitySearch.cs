using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.LowFareAvailability.AvailabilitySearchPanel;
using MyCTS.Entities;
using DevExpress.XtraEditors;
using MyCTS.Services.Contracts.Volaris;

namespace MyCTS.Presentation
{
    public partial class LowFareAvailabilitySearch : CustomUserControl, ILowFareAvailabilitySearchView
    {
        public LowFareAvailabilitySearch()
        {
            InitializeComponent();
        }





        #region Miembros de ILowFareAvailabilitySearchView

        public AvailabilityRequest Request
        {
            get
            {

                var request = new AvailabilityRequest();
                request.ArrivalStation = this.arrivalStationTextBox.Text;
                request.DepartureStation = this.departureStationTextBox.Text;
                request.DepartureDateTime = (DateTime)departureDateEdit.EditValue;
                request.Pasengers = this.Passangers;
                if (singleFlightCheckBox.Checked)
                {
                    request.BecomeSingleTrip();
                }
                else
                {
                    request.BecomeRoundTrip();
                    request.ReturningDateTime = (DateTime?)this.returningDateEdit.EditValue;
                }
                return request;
            }
            set
            {

                if (value != null)
                {
                    this.singleFlightCheckBox.Checked = true;
                    this.departureDateEdit.EditValue = value.DepartureDateTime;
                    this.departureStationTextBox.Text = value.DepartureStation;
                    this.arrivalStationTextBox.Text = value.ArrivalStation;
                    Passangers = value.Pasengers;
                    if (value.Type == AvailabilityRequestType.RoundTrip)
                    {
                        singleFlightCheckBox.Checked = false;
                        roundTripCheckBox.Checked = true;
                        returningDateEdit.EditValue = value.ReturningDateTime;

                    }



                }


            }
        }

        private RequestedPassengers Passangers { get; set; }

        #endregion

        #region Miembros de IBaseView


        public void ValidateInput()
        {


            IsValid = this.ControlEmptyNessValidator.Validate();
            if (!singleFlightCheckBox.Checked)
            {
                IsValid = DateRangeValidator.Validate();
            }

        }

        public bool IsValid { get; set; }

        #endregion

        private void singleFlightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var singleFlightCheckBox_ = sender as CheckEdit;
            if (singleFlightCheckBox_ != null)
            {
                if (singleFlightCheckBox_.Checked)
                {
                    roundTripCheckBox.Checked = false;
                    returningDatePanel.Visible = false;
                }

            }

        }

        private void roundTripCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var roundFlightCheckBox = sender as CheckEdit;
            if (roundFlightCheckBox != null)
            {
                if (roundFlightCheckBox.Checked)
                {
                    singleFlightCheckBox.Checked = false;
                    returningDatePanel.Visible = true;
                }

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!departureDateEdit.IsPopupOpen)
            {
                departureDateEdit.ShowPopup();
            }
        }

        /// <summary>
        /// Handles the Click event of the pictureBox2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (!returningDateEdit.IsPopupOpen)
            {
                returningDateEdit.ShowPopup();
            }

        }

        /// <summary>
        /// Handles the TextChanged event of the departureStationTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void departureStationTextBox_TextChanged(object sender, EventArgs e)
        {
            this.FillPredictive(sender as TextEdit, departurePredictive);
            RemoveError(sender as Control);
        }

        /// <summary>
        /// Handles the TextChanged event of the arrivalStationTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void arrivalStationTextBox_TextChanged(object sender, EventArgs e)
        {
            this.FillPredictive(sender as TextEdit, this.arrivalPredictive);
            RemoveError(sender as Control);
        }


        private void HandlePredective(ListBox predective, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                predective.Visible = false;
                if (predective.Items.Count > 0)
                {
                    predective.Items.Clear();
                }

            }

            if (e.KeyCode == Keys.Down)
            {
                if (predective.Items.Count > 0)
                {
                    predective.Visible = true;
                    predective.Focus();
                    predective.SelectedIndex = 0;
                }
            }

            if (e.KeyCode == Keys.Tab)
            {
                if (predective.Items.Count > 0)
                {
                    predective.Items.Clear();

                }
                predective.Visible = false;
            }
        }
        /// <summary>
        /// Handles the predictive.
        /// </summary>
        /// <param name="textEdit">The text edit.</param>
        /// <param name="predicitiveListBox">The predicitive list box.</param>
        private void FillPredictive(TextEdit textEdit, ListBox predicitiveListBox)
        {

            if (textEdit != null)
            {
                textEdit.Text = textEdit.Text.ToUpper();
                Common.SetListBoxAirports(textEdit, predicitiveListBox);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            VolarisServiceManager.ciclo = false;
            VolarisServiceManager.dispVolaris = new List<Services.APIVolaris.VueloDisponible>();
            VolarisServiceManager.volarisVuelos = new List<VueloDisponibleMyCTS>();

            this.ValidateInput();
            if (IsValid)
            {
                if (OnSearchFlights != null)
                {
                    OnSearchFlights(this, e);
                }
            }

        }
        private void HandlePredictiveEvent(ListBox predictive, TextEdit profileTextBox, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                SetSelectionOnPredective(predictive, profileTextBox);
            }

            if (e.KeyCode == Keys.Tab)
            {
                SetSelectionOnPredective(predictive, profileTextBox);
            }

        }

        public EventHandler OnSearchFlights { get; set; }

        private void departureDateEdit_EditValueChanged(object sender, EventArgs e)
        {


            RemoveError(sender as Control);
        }


        private void RemoveError(Control control)
        {
            if (control != null)
            {
                this.DateRangeValidator.RemoveControlError(control);
                this.ControlEmptyNessValidator.RemoveControlError(control);
            }
        }

        private void returningDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            RemoveError(sender as Control);
        }

        private void departureDateEdit_MouseClick(object sender, MouseEventArgs e)
        {
            RemoveError(sender as Control);
        }

        private void returningDateEdit_MouseClick(object sender, MouseEventArgs e)
        {
            RemoveError(sender as Control);
        }



        private void lbAirlines_MouseClick(object sender, MouseEventArgs e)
        {

            
                SetSelectionOnPredective(this.departurePredictive, departureStationTextBox);
       
        }

        private void SetSelectionOnPredective(ListBox predictive, TextEdit profileTextBox)
        {
            var selectedItem = predictive.SelectedItem as ListItem;
            if (selectedItem != null)
            {
                profileTextBox.Text = selectedItem.Value;
                predictive.Visible = false;
                if (predictive.Items.Count > 0)
                {
                    predictive.Items.Clear();

                }
                profileTextBox.Focus();
            }
        }

        private void departureStationTextBox_KeyDown(object sender, KeyEventArgs e)
        {

            HandlePredective(departurePredictive, e);

        }

        private void arrivalStationTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            HandlePredective(this.arrivalPredictive, e);

        }

        private void lbAirlines_KeyDown(object sender, KeyEventArgs e)
        {

            HandlePredictiveEvent(departurePredictive, departureStationTextBox, e);
        }

        private void arrivalPredictive_KeyDown(object sender, KeyEventArgs e)
        {
            HandlePredictiveEvent(this.arrivalPredictive, arrivalStationTextBox, e);
        }

        private void arrivalPredictive_MouseClick(object sender, MouseEventArgs e)
        {
            SetSelectionOnPredective(this.arrivalPredictive, arrivalStationTextBox);
        }
    }
}
