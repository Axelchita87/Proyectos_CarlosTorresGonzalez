using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Presentation.Reservations.Availability.EndRecord.ContextSolver;
using MyCTS.Presentation.Reservations.Availability.EndRecord.Services;

namespace MyCTS.Presentation.Reservations.Availability.EndRecord
{
    public class LowFareEndRecordPresenter : IBasePresenter<ILowFareEndRecordView, LowFareEndRecordRepository>
    {
        #region Miembros de IBasePresenter<ILowFareEndRecordView,LowFareEndRecordRepository>

        public ILowFareEndRecordView View { get; set; }

        public LowFareEndRecordRepository Repository { get; set; }


        public IProcessContext<object> Context { get; set; }
        public EventHandler<OnActionStartEventArg> OnActionStart { get; set; }
        public EventHandler<OnActionCompletedEventArgs> OnActionCompleted { get; set; }
        public EventHandler<OnRecordCompletedEventArgs> OnRecordCompleted { get; set; }
        public string RecordManagerType { get; set; }

        public void EndAndCloseRecord(object model, string applicant)
        {
            Context = new LowFareEndRecordContextSolver
                          {
                              OnActionStart = OnActionStarted,
                              OnActionCompleted = OnActionComplete,
                              OnRecordCompleted = OnRecordComplete,
                              RecordManagerType = RecordManagerType,
                              Applicant = applicant
                          };
            Context.Resolve(model);
        }

        private void OnRecordComplete(object sender, OnRecordCompletedEventArgs e)
        {
            if (OnRecordCompleted != null)
            {
                OnRecordCompleted(sender, e);
            }
        }

        private void OnActionComplete(object sender, OnActionCompletedEventArgs e)
        {
            if (OnActionCompleted != null)
            {
                OnActionCompleted(sender, e);
            }
        }

        private void OnActionStarted(object sender, OnActionStartEventArg e)
        {
            if (OnActionStart != null)
            {
                OnActionStart(sender, e);
            }
        }

        public void InitializeView()
        {

        }

        public void UpdateView(object modelObject)
        {

        }

        #endregion
    }
}
