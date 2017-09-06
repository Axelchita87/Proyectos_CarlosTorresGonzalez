using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Presentation.Base;
using System.Windows.Forms;
using System.ComponentModel;
using MyCTS.Presentation.Reservations.Availability.ChargeOfServiceLowFare.DynamicBuilder;
using MyCTS.Presentation.Reservations.Availability.LowFareAvailability.Builder;

namespace MyCTS.Presentation.Reservations.Availability.ChargeOfServiceLowFare.ContextSolver
{

    public class ChargeOfServiceContextSolverWinForms : IProcessContext<List<IPassanger>>
    {
        #region Miembros de IProcessContext<List<IPassanger>>


        public IDynamicBuilder<Control> DynamicBuilder { get; set; }

        public EventHandler OnCompleted { get; set; }


        private BackgroundWorker _backgroundWorker;
        public void Resolve(List<IPassanger> passangers)
        {
            _backgroundWorker = new BackgroundWorker
                                    {

                                    };
            _backgroundWorker.DoWork += _backgroundWorker_DoWork;
            _backgroundWorker.RunWorkerCompleted += _backgroundWorker_RunWorkerCompleted;
            _backgroundWorker.RunWorkerAsync(passangers);
        }

        void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            try
            {
                if(OnCompleted != null)
                {
                    OnCompleted(e.Result, EventArgs.Empty);
                }

            }
            finally
            {
                _backgroundWorker.Dispose();
            }
        }

        void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var passangers = (List<IPassanger>) e.Argument;
            DynamicBuilder = new ChargeOfServiceLowFareDynamicBuilder
                                 {
                                     Passangers = passangers
                                 };
            e.Result = DynamicBuilder.Build();

        }

        #endregion


       
    }
}
