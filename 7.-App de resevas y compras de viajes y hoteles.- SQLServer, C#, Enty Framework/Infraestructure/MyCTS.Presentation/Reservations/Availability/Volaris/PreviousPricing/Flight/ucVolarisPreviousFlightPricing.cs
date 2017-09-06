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
using MyCTS.Presentation.Reservations.Availability.Volaris.PreviousPricing.Flight;

namespace MyCTS.Presentation.Reservations
{
    public partial class ucVolarisPreviousFlightPricing : CustomUserControl, VolarisPreviousFlightPrincingView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ucVolarisPreviousFlightPricing"/> class.
        /// </summary>
        public ucVolarisPreviousFlightPricing()
        {
            InitializeComponent();
        }

        #region Miembros de VolarisPreviousFlightPrincingView

        /// <summary>
        /// Sets the flight.
        /// </summary>
        /// <param name="flight">The flight.</param>
        public void SetFlight(VolarisFlight flight)
        {
            SetSegment(flight);
            if (!ShowOnlySegments)
            {
                SetPassangerFare(flight);
            }
        }

        public string Title
        {
            set { this.groupControl1.Text = value; }
        }

        public bool ShowOnlySegments
        {
            get;
            set;
        }


        private void SetFlightTitle(VolarisFlight flight)
        {

        }
        /// <summary>
        /// Sets the segment.
        /// </summary>
        /// <param name="flight">The flight.</param>
        private void SetSegment(VolarisFlight flight)
        {
            int segmentCounter = 0;
            if (container.RowCount != 1)
            {
                segmentCounter = container.RowCount;
            }
            foreach (var segment in flight.Segments.GetAll().Cast<VolarisSegment>())
            {
                var newSegmentControl = new ucVolarisPreviousSegmentPricing();
                newSegmentControl.Dock = DockStyle.Top;
                newSegmentControl.SetSegment(segment);
                container.Controls.Add(newSegmentControl, 0, segmentCounter);
                segmentCounter += 1;
            }
        }

        /// <summary>
        /// Sets the passanger fare.
        /// </summary>
        /// <param name="flight">The flight.</param>
        private void SetPassangerFare(VolarisFlight flight)
        {
            int fareCounter = container.RowCount + 1;
            foreach (var fare in flight.PassangerFares.GetPassangerFares())
            {
                var newPassangerFareControl = new ucVolarisPreviousPassangerPricing();
                newPassangerFareControl.Dock = DockStyle.Top;
                newPassangerFareControl.SetFare(fare);
                container.Controls.Add(newPassangerFareControl, 0, fareCounter);
                fareCounter += 1;
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
