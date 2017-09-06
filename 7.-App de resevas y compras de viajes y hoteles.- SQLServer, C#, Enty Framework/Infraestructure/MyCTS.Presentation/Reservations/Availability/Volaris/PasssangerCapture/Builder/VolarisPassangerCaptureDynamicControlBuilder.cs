using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.Controls;
using MyCTS.Presentation.Base;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Presentation.Reservations.Availability.Volaris.Banner;
using MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture.ContactCapture;
using MyCTS.Presentation.Reservations.Availability.Volaris.ReservationPreviewExpander;
using DevExpress.XtraEditors;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture.Builder
{
    public class VolarisPassangerCaptureDynamicControlBuilder : IDynamicBuilder<Control>
    {

        public VolarisReservation Reservation { get; set; }

        #region Miembros de IDynamicBuilder<Control>

        private readonly Panel _container = new Panel()
                                      {
                                          AutoSize = true,

                                      };

        private readonly TableLayoutPanel _table = new TableLayoutPanel()
                                                       {
                                                           AutoSize = true
                                                       };
        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns></returns>
        public Control Build()
        {

            int x = 0;
            int y = 0;

            _container.Location = new Point(x, y);


            var mainColumnIndex = _table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            var reservationExpanderControl = CreateReservationResumeControl();
            var expanderRowIndex = _table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            _table.Controls.Add(reservationExpanderControl, mainColumnIndex, expanderRowIndex);

            var profileControlRowIndex = _table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            var profileAssigmentControl = CreateProfileAssignmentControl();
            _table.Controls.Add(profileAssigmentControl, mainColumnIndex, profileControlRowIndex);

            CreatePassangerCapture();

            CreateContactControl();

            _container.Controls.Add(_table);
            return _container;
        }

        /// <summary>
        /// Creates the passanger capture.
        /// </summary>
        public void CreatePassangerCapture()
        {

            const int column = 0;
            int currentTabIndex = 3;
            foreach (var passanger in Reservation.Passangers.GetAll())
            {
                var newRowIndex = AddNewRow();
                var newPassangerCapture = new ucVolarisPassangerCaptureForm()
                                              {
                                                  TabIndex = currentTabIndex
                                              };
                newPassangerCapture.Passanger = passanger;
                var filteredList = Reservation.Passangers.GetAdults().Where(p => p.Number != passanger.Number).ToList();
                newPassangerCapture.SetListOfPassangersNumber(filteredList);
                _table.Controls.Add(newPassangerCapture, column, newRowIndex);
                currentTabIndex += 1;
            }
            paxLastTabIndex = currentTabIndex;
        }

        private int paxLastTabIndex;

        /// <summary>
        /// Adds the new row.
        /// </summary>
        /// <returns></returns>
        private int AddNewRow()
        {

            return _table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        }

        /// <summary>
        /// Creates the profile assignment control.
        /// </summary>
        /// <returns></returns>
        private ucVolarisProfileAssign CreateProfileAssignmentControl()
        {
            var profileAssingerControl = new ucVolarisProfileAssign() { TabIndex = 1};
            profileAssingerControl.PassangerList = Reservation.Passangers.GetAdults();
            return profileAssingerControl;
        }

        /// <summary>
        /// Creates the reservation resume control.
        /// </summary>
        /// <returns></returns>
        private Control CreateReservationResumeControl()
        {
            var reservationResumeControl = new ucVolarisPreviousReservationResume()
            {
                TabIndex = 0
            };
    
            reservationResumeControl.SetReservation(Reservation);

            var reservationExpanderControl = new ucVolarisReservationExpander();
            reservationExpanderControl.CloseUpEventHandler += CloseUpEventHandler;
            reservationExpanderControl.PopupEventHandler += PopupEventHandler;
            reservationExpanderControl.ControlToDisplay = reservationResumeControl;
            return reservationExpanderControl;
        }

        private void CreateContactControl()
        {
            var contactControl = new ucVolarisContactInformationCapture()
                                     {
                                         TabIndex = paxLastTabIndex + 1
                                     };
            var rowIndex = AddNewRow();
            const int column = 0;
            _table.Controls.Add(contactControl, column, rowIndex);

        }

        /// <summary>
        /// Popups the event handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void PopupEventHandler(object sender, EventArgs eventArgs)
        {
            var popContainerEdit = sender as PopupContainerEdit;
            _table.SuspendLayout();
            if (popContainerEdit != null)
            {
                const int extraHeight = 40;
                var newSize = popContainerEdit.Properties.PopupControl.Size.Height + popContainerEdit.Size.Height +
                              extraHeight;

                var rowIndex = _table.GetRow(popContainerEdit.Parent);
                _table.RowStyles[rowIndex].SizeType = SizeType.Absolute;
                _table.RowStyles[rowIndex].Height = newSize;

            }
            _table.ResumeLayout();
        }

        /// <summary>
        /// Closes up event handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="closeUpEventArgs">The <see cref="DevExpress.XtraEditors.Controls.CloseUpEventArgs"/> instance containing the event data.</param>
        private void CloseUpEventHandler(object sender, CloseUpEventArgs closeUpEventArgs)
        {
            var popContainerEdit = sender as PopupContainerEdit;
            _table.SuspendLayout();
            if (popContainerEdit != null)
            {

                var newSize = popContainerEdit.Size.Height;
                var rowIndex = _table.GetRow(popContainerEdit.Parent);
                _table.RowStyles[rowIndex].SizeType = SizeType.Absolute;
                _table.RowStyles[rowIndex].Height = 35;

            }
            _table.ResumeLayout();
        }

        #endregion
    }
}
