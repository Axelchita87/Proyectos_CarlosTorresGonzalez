using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Presentation.Base;
using MyCTS.Presentation.Reservations.Availability.Volaris.FlightConfirmation.BookingConfirmation.Builder;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.FlightConfirmation.BookingConfirmation.ContextBuilder
{
    public class VolarisContextSolverBookingConfirmationWinForms : IProcessContext<VolarisReservation>
    {
        #region Miembros de IProcessContext<VolarisReservation>

        public IDynamicBuilder<Control> DynamicBuilder { get; set; }


        private BackgroundWorker _builderWorker;

        public EventHandler OnCompleted { get; set; }
        
        public void Resolve(VolarisReservation reservation)
        {
            _builderWorker = new BackgroundWorker {};
            _builderWorker.DoWork += _builderWorker_DoWork;
            _builderWorker.RunWorkerCompleted += _builderWorker_RunWorkerCompleted;
            _builderWorker.RunWorkerAsync(reservation);

        }

        void _builderWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                
                if(OnCompleted != null)
                {
                    OnCompleted(e.Result, EventArgs.Empty);
                }
            }finally
            {
                _builderWorker.Dispose();
            }
        }

        void _builderWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var reservation = (VolarisReservation) e.Argument;
            DynamicBuilder = new VolarisDynamicBuilderBookingConfirmation
                                 {
                                     Reservation = reservation
                                 };
           e.Result = DynamicBuilder.Build();
        }

        #endregion
    }
}
