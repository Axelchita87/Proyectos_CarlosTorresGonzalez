using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.Volaris.PreviousPricing.Segment;
using MyCTS.Entities;

namespace MyCTS.Presentation
{
    public partial class ucVolarisPreviousSegmentPricing : CustomUserControl, VolarisPreviousSegmentPrincingView
    {
        public ucVolarisPreviousSegmentPricing()
        {
            InitializeComponent();
        }

        private VolarisPreviousSegmentPrincingPresenter _presenter;
        /// <summary>
        /// Gets the presenter.
        /// </summary>
        private VolarisPreviousSegmentPrincingPresenter Presenter
        {
            get
            {
                return _presenter ?? (_presenter = new VolarisPreviousSegmentPrincingPresenter
                                                       {
                                                           Repository = new VolarisPreviousSegmentPricingRepository(),
                                                           View = this


                                                       });

            }
        }

        public void ucVolarisPreviousSegmentPricing_Load(object sender, EventArgs args)
        {
            Presenter.InitializeView();
            toolTipController1.Rounded = true;


        }

        #region Miembros de IBaseView


        public void ValidateInput()
        {

        }

        public bool IsValid { get; set; }

        #endregion

        #region Miembros de VolarisPreviousSegmentPrincingView

        /// <summary>
        /// Gets or sets the segment.
        /// </summary>
        /// <value>
        /// The segment.
        /// </value>


        /// <summary>
        /// Gets or sets the flight number.
        /// </summary>
        /// <value>
        /// The flight number.
        /// </value>
        public string FlightNumber
        {
            get { return segmentNumber.Text; }
            set { segmentNumber.Text = value; }
        }


        /// <summary>
        /// Gets or sets the departure station.
        /// </summary>
        /// <value>
        /// The departure station.
        /// </value>
        public string DepartureStation
        {
            get { return departureStationFullName.Text; }
            set { departureStationFullName.Text = value; }
        }

        /// <summary>
        /// Gets or sets the arrival station.
        /// </summary>
        /// <value>
        /// The arrival station.
        /// </value>
        public string ArrivalStation
        {
            get { return arrivalStationFullName.Text; }
            set { arrivalStationFullName.Text = value; }
        }

        /// <summary>
        /// Gets or sets the departure time.
        /// </summary>
        /// <value>
        /// The departure time.
        /// </value>
        public string DepartureTime
        {
            get { return departureTime.Text; }
            set { departureTime.Text = value; }
        }

        /// <summary>
        /// Gets or sets the arrival time.
        /// </summary>
        /// <value>
        /// The arrival time.
        /// </value>
        public string ArrivalTime
        {
            get { return arrivalTime.Text; }
            set { arrivalTime.Text = value; }
        }


        public void SetSegment(VolarisSegment segment)
        {
            Presenter.SetSegment(segment);
        }

        #endregion


        #region Miembros de VolarisPreviousSegmentPrincingView


        public string DepartureStationToolTip
        {
            set
            {
                toolTipController1.SetToolTip(this.departureStationFullName, value);
                toolTipController1.SetToolTipIconType(this.departureStationFullName, ToolTipIconType.None);
                toolTipController1.SetTitle(this.departureStationFullName, "Aeropuerto");
            }
        }

        public string ArrivalStationToolTip
        {
            set
            {
                toolTipController1.SetToolTip(this.arrivalStationFullName, value);
                toolTipController1.SetToolTipIconType(this.arrivalStationFullName, ToolTipIconType.None);
                toolTipController1.SetTitle(this.arrivalStationFullName, "Aeropuerto");


            }
        }

        #endregion

        #region Miembros de VolarisPreviousSegmentPrincingView


        public string DateOfDeparture
        {
            get { return this.departureFormattedDate.Text; }
            set { departureFormattedDate.Text = value; }
        }

        #endregion
    }
}
