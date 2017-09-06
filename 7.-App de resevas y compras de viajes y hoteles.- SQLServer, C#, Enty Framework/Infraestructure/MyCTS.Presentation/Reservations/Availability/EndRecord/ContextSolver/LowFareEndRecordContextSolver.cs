using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Presentation.Reservations.Availability.EndRecord.Services;
using System.ComponentModel;

namespace MyCTS.Presentation.Reservations.Availability.EndRecord.ContextSolver
{
    public class LowFareEndRecordContextSolver : IProcessContext<object>
    {
        #region Miembros de IProcessContext<object>

        public string RecordManagerType { get; set; }


        private readonly Dictionary<string, Func<TRecordManager>> _recordManagersFactory = new Dictionary
            <string, Func<TRecordManager>>
                                                                                      {
                                                                                          {
                                                                                              "Volaris",
                                                                                              () =>
                                                                                              new VolarisRecordManager()
                                                                                           },
                                                                                           {"InterJet" ,
                                                                                               () => new InterJetRecordManager()}                                                                                          

                                                                                      };

        private BackgroundWorker _recordWorker;
        private TRecordManager RecordManager { get; set; }

        public EventHandler<OnActionStartEventArg> OnActionStart { get; set; }
        public EventHandler<OnActionCompletedEventArgs> OnActionCompleted { get; set; }
        public EventHandler<OnRecordCompletedEventArgs> OnRecordCompleted { get; set; }

        public string Applicant { get; set; }
        public bool HasSpecifiedApplicant { get; set; }
        public void Resolve(object objectContext)
        {
            if (_recordManagersFactory.ContainsKey(RecordManagerType))
            {

                RecordManager = _recordManagersFactory["InterJet"]();
                RecordManager.Model = objectContext;
                RecordManager.OnActionStart += OnActionStarted;
                RecordManager.OnActionCompleted += OnActionComplete;
                RecordManager.OnRecordCompleted += OnRecordComplete;
                RecordManager.Applicant = this.Applicant;
         
                _recordWorker = new BackgroundWorker { WorkerReportsProgress = true };
                _recordWorker.DoWork += _recordWorker_DoWork;
                _recordWorker.RunWorkerCompleted += _recordWorker_RunWorkerCompleted;
                _recordWorker.ProgressChanged += _recordWorker_ProgressChanged;
                _recordWorker.RunWorkerAsync(RecordManager);
            }

        }

        private void OnRecordComplete(object sender, OnRecordCompletedEventArgs e)
        {
            _recordWorker.ReportProgress(10, e);
        }

        private void OnActionComplete(object sender, OnActionCompletedEventArgs e)
        {
            _recordWorker.ReportProgress(10, e);
        }

        private void OnActionStarted(object sender, OnActionStartEventArg e)
        {

            _recordWorker.ReportProgress(10, e);
        }

        void _recordWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is OnActionStartEventArg)
            {
                if (OnActionStart != null)
                {
                    OnActionStart(this, e.UserState as OnActionStartEventArg);
                }
            }

            if (e.UserState is OnActionCompletedEventArgs)
            {
                if (OnActionCompleted != null)
                {
                    OnActionCompleted(this, e.UserState as OnActionCompletedEventArgs);
                }
            }

            if (e.UserState is OnRecordCompletedEventArgs)
            {
                if (OnRecordCompleted != null)
                {
                    OnRecordCompleted(this, e.UserState as OnRecordCompletedEventArgs);
                }
            }


        }

        void _recordWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (OnRecordCompleted != null)
                {
                    OnRecordCompleted(this, new OnRecordCompletedEventArgs
                                                {
                                                    Success = !string.IsNullOrEmpty(RecordManager.ErrorMessage),
                                                    Message = RecordManager.ErrorMessage,
                                                    SabrePnr = RecordManager.SabrePnr,
                                                    IsInvoiced = RecordManager.IsInvoiced


                                                });
                }
            }
            finally
            {
                _recordWorker.Dispose();
            }
        }

        void _recordWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var recordManager = (TRecordManager)e.Argument;
            if (!recordManager.EndAndRecoverRecord())
            {
                e.Cancel = true;
            }
        }


        #endregion
    }
}
