using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Presentation.Base;
using System.ComponentModel;
using MyCTS.Presentation.Reservations.Availability.Volaris.PreviousPricing.Builder;
using System.Threading;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PreviousPricing.ContextSolver
{
    public class DynamicPreviousPrincingWinFormControlBuilder : IProcessContext<VolarisReservation>
    {
        #region Miembros de IProcessContext<VolarisReservation>

        /// <summary>
        /// Gets or sets the dynamic builder.
        /// </summary>
        /// <value>
        /// The dynamic builder.
        /// </value>
        public IDynamicBuilder<Control> DynamicBuilder { get; set; }


        /// <summary>
        /// 
        /// </summary>
        private BackgroundWorker _worker;

        /// <summary>
        /// Resolves the specified reservation.
        /// </summary>
        /// <param name="reservation">The reservation.</param>
        public void Resolve(VolarisReservation reservation)
        {
            _worker = new BackgroundWorker()
                          {
                              WorkerReportsProgress = true
                          };
            _worker.ProgressChanged += _worker_ProgressChanged;
            _worker.DoWork += _worker_DoWork;
            _worker.RunWorkerCompleted += _worker_RunWorkerCompleted;
            _worker.RunWorkerAsync(reservation);
        }

        void _worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (ReportOnCreatingControls != null)
            {
                ReportOnCreatingControls(true, new EventArgs());
            }
        }

        /// <summary>
        /// Handles the RunWorkerCompleted event of the _worker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (OnWorkCompleted != null)
            {
                OnWorkCompleted(e.Result, new EventArgs());
            }
        }

        /// <summary>
        /// Handles the DoWork event of the _worker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(600);
            var reservation = (VolarisReservation)e.Argument;
            DynamicBuilder = new VolarisPreviousPrincingDynamicControlBuilder()
                                 {
                                     Reservation = reservation
                                 };
            _worker.ReportProgress(50);

            Thread.Sleep(600);
            e.Result = DynamicBuilder.Build();
        }

        public EventHandler OnWorkCompleted { get; set; }
        public EventHandler ReportOnCreatingControls { get; set; }


        #endregion
    }
}
