using System;
using System.Linq;
using DevExpress.XtraEditors.Controls;
using MyCTS.Presentation.Base;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Presentation.Reservations.Availability.LowFareAvailability.ModifyFlightSearch;
using DevExpress.XtraEditors;
using MyCTS.Services.Contracts.Volaris;
using System.Collections.Generic;

namespace MyCTS.Presentation.Reservations.Availability.LowFareAvailability.Builder
{
    public class LowFareAvailabilityDynamicControlBuilder : IDynamicBuilder<Control>
    {

        public AvailabilityRequest Request { get; set; }
        public Flights Flights { get; set; }
        #region Miembros de IDynamicBuilder<Control>

        private const int Column = 0;
        private readonly TableLayoutPanel _table = new TableLayoutPanel()
        {
            AutoSize = true,
            Dock = DockStyle.Fill
        };
        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns></returns>
        public Control Build()
        {

            _table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            CreateAvailabilitySearch();
            CreateDepartureContainer();
            CreateReturningContainer();
            return _table;

        }

        /// <summary>
        /// Creates the availability search.
        /// </summary>
        private void CreateAvailabilitySearch()
        {


            int rowIndex = AddRow();
            var controll = new ucVolairsModifyFlightSearch
                               {
                                   ContainerControl = new LowFareAvailabilitySearch()
                                                          {

                                                              Request = Request
                                                          },


                                   Dock = DockStyle.Fill,
                                   AutoSize = true
                               };
            controll.PopUpControl.Popup += PopUpControl_Popup;
            controll.PopUpControl.CloseUp += PopUpControl_CloseUp;
            _table.Controls.Add(controll, Column, rowIndex);
        }

        void PopUpControl_CloseUp(object sender, CloseUpEventArgs e)
        {
            var popUpContainerEdit = sender as PopupContainerEdit;
            if (popUpContainerEdit != null)
            {
                const int extraSize = 51;
                int newSize = popUpContainerEdit.Size.Height + popUpContainerEdit.Properties.PopupControl.Size.Height +
                              extraSize;
                if (popUpContainerEdit.Parent != null)
                {
                    int rowIndex = _table.GetRow(popUpContainerEdit.Parent);
                    _table.RowStyles[rowIndex].SizeType = SizeType.Absolute;
                    _table.RowStyles[rowIndex].Height = extraSize;
                }
            }
        }

        void PopUpControl_Popup(object sender, EventArgs e)
        {

            var popUpContainerEdit = sender as PopupContainerEdit;
            if (popUpContainerEdit != null)
            {
                const int extraSize = 25;
                int newSize = popUpContainerEdit.Size.Height + popUpContainerEdit.Properties.PopupControl.Size.Height +
                              extraSize;
                if (popUpContainerEdit.Parent != null)
                {
                    int rowIndex = _table.GetRow(popUpContainerEdit.Parent);
                    _table.RowStyles[rowIndex].SizeType = SizeType.Absolute;
                    _table.RowStyles[rowIndex].Height = newSize;
                }
            }


        }

        /// <summary>
        /// Creates the departure container.
        /// </summary>
        private void CreateDepartureContainer()
        {

            int rowIndex = AddRow();
            var departureFlightsContainer = new ucLowFareAvailabilityContainer() { Dock = DockStyle.Right };

            departureFlightsContainer.SetFligths(Flights.GetDepartures());
            departureFlightsContainer.Itinerary = Request.DepartureItinerary;
            departureFlightsContainer.Date = Request.DepartureDateString;
            departureFlightsContainer.TypeItinerary = "salida";
            _table.Controls.Add(departureFlightsContainer, Column, rowIndex);


        }


        /// <summary>
        /// Creates the returning container.
        /// </summary>
        private void CreateReturningContainer()
        {
            if (Request.Type == AvailabilityRequestType.RoundTrip)
            {
                int rowIndex = AddRow();
                var returningFlightsContainer = new ucLowFareAvailabilityContainer() { Dock = DockStyle.Right };
                returningFlightsContainer.SetFligths(Flights.GetReturning());
                returningFlightsContainer.Itinerary = Request.ReturningItinerary;
                returningFlightsContainer.Date = Request.ReturningDateString;
                returningFlightsContainer.TypeItinerary = "regreso";
                _table.Controls.Add(returningFlightsContainer, Column, rowIndex);
            }
        }

        private int AddRow()
        {

            return _table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        }





        #endregion
    }
}
