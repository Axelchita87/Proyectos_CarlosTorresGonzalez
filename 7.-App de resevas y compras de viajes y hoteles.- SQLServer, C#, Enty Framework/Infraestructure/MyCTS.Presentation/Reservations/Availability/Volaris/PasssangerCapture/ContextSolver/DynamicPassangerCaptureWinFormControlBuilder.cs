using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;
using System.Windows.Forms;
using System.ComponentModel;
using MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture.Builder;
using System.Threading;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture.ContextSolver
{
    public class DynamicPassangerCaptureWinFormControlBuilder : IProcessContext<VolarisReservation>
    {

        public IDynamicBuilder<Control> DynamicBuilder { get; set; }
        #region Miembros de IProcessContext<VolarisReservation>


        private BackgroundWorker Worker { get; set; }
        /// <summary>
        /// Resolves the specified object context.
        /// </summary>
        /// <param name="objectContext">The object context.</param>
        public void Resolve(VolarisReservation objectContext)
        {
            Worker = new BackgroundWorker()
                         {
                             WorkerReportsProgress = true
                         };
            Worker.DoWork += new DoWorkEventHandler(Worker_DoWork);
            Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Worker_RunWorkerCompleted);
            Worker.RunWorkerAsync(objectContext);
        }

        void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (OnWorkCompleted != null)
                {

                    OnWorkCompleted(e.Result, new EventArgs());
                }
            }
            finally
            {

                Worker.Dispose();
            }
        }

        void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var reservation = (VolarisReservation)e.Argument;
            if (reservation != null)
            {

                DynamicBuilder = new VolarisPassangerCaptureDynamicControlBuilder()
                                     {
                                         Reservation = reservation
                                     };
                e.Result = DynamicBuilder.Build();
            }
            Thread.Sleep(3000);

        }

        public EventHandler OnWorkCompleted { get; set; }
        public EventHandler ReporStatus { get; set; }

        #endregion
    }
}
