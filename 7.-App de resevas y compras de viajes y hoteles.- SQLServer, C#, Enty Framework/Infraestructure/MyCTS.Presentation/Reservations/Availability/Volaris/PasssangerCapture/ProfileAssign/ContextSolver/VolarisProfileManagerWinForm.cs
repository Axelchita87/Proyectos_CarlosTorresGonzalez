using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Presentation.Base;
using MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture.EventArguments;
using MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture.ProfileAssign.EventArguments;
using System.ComponentModel;
using System.Threading;
using MyCTS.Business;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture.ProfileAssign.ContextSolver
{
    public class VolarisProfileManagerWinForm : IProcessContext<SearchProfileEventArgument>
    {

        private VolarisProfileBL _service;
        private VolarisProfileBL Service
        {
            get { return _service ?? (_service = new VolarisProfileBL()); }
        }
        public EventHandler<OnSearchingProfileCompletedEventArgs> OnSearchingProfileCompleted { get; set; }

        #region Miembros de IProcessContext<SearchProfileEventArgument>

        private readonly BackgroundWorker _worker = new BackgroundWorker()
                                                        {

                                                        };

        public void Resolve(SearchProfileEventArgument objectContext)
        {

            _worker.DoWork += _worker_DoWork;
            _worker.RunWorkerCompleted += _worker_RunWorkerCompleted;
            _worker.RunWorkerAsync(objectContext);
        }

        private void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                var helper = (VolarisProfileWithPassanger)e.Result;
                if (OnSearchingProfileCompleted != null)
                {

                    var eventArgument = new OnSearchingProfileCompletedEventArgs
                                            {

                                                Profile = helper.Profile,
                                                Passanger = helper.Passanger
                                            };
                    OnSearchingProfileCompleted(this, eventArgument);
                }

            }
            finally
            {
                _worker.Dispose();
            }
        }

        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var argumentsSend = (SearchProfileEventArgument)e.Argument;

            var result = new VolarisProfileWithPassanger
            {

                Passanger = argumentsSend.Passanger,
                Profile = Service.GetProfile(argumentsSend.SecondLevelProfile, argumentsSend.FristLevelProfile)
            };
            e.Result = result;
        }




        #endregion
    }

    public class VolarisProfileWithPassanger
    {
        public VolarisProfile Profile { get; set; }
        public IVolarisPassanger Passanger { get; set; }
    }
}
