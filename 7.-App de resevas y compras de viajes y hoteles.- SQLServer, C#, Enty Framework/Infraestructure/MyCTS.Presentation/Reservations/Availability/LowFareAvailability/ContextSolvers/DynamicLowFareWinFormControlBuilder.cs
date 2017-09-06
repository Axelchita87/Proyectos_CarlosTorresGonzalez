using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Presentation.Base;
using System.Windows.Forms;
using System.ComponentModel;
using MyCTS.Presentation.Reservations.Availability.LowFareAvailability.Builder;
using MyCTS.Presentation.Reservations.Availability.LowFareAvailability.EventArguments;
using System.Threading;

namespace MyCTS.Presentation.Reservations.Availability.LowFareAvailability.ContextSolvers
{
    public class DynamicLowFareWinFormControlBuilder : IProcessContext<Flights>
    {



        private BackgroundWorker _controlBuilderWorker;
        private IDynamicBuilder<Control> DynamicControl { get; set; }
        #region Miembros de IProcessContext<Flights>

        public void Resolve(Flights objectContext)
        {

            _controlBuilderWorker = new BackgroundWorker();
            _controlBuilderWorker.DoWork += _controlBuilderWorker_DoWork;
            _controlBuilderWorker.RunWorkerCompleted += _controlBuilderWorker_RunWorkerCompleted;
            _controlBuilderWorker.RunWorkerAsync(objectContext);

        }


        void _controlBuilderWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (OnDynamicControlsBuilt != null)
                {
                    OnDynamicControlsBuilt(null, new OnDynamicControlsBuiltEventArgs
                                                    {
                                                        Control = (Control)e.Result
                                                    });
                }
            }
            finally
            {
                _controlBuilderWorker.Dispose();
            }
        }

        void _controlBuilderWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(1000);
            DynamicControl = new LowFareAvailabilityDynamicControlBuilder()
                                 {
                                     Flights = (Flights)e.Argument
                                 };
            e.Result = DynamicControl.Build();
        }

        public EventHandler<OnDynamicControlsBuiltEventArgs> OnDynamicControlsBuilt { get; set; }

        #endregion
    }
}
