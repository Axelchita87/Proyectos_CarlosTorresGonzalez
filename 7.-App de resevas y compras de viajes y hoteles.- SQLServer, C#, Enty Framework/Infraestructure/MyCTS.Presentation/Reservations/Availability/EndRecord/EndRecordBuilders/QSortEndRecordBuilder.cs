using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Reservations.Availability.EndRecord.Services;

namespace MyCTS.Presentation.Reservations.Availability.EndRecord.EndRecordBuilders
{
    public class QSortEndRecordBuilder : IEndRecordBuilder
    {
        public QSortEndRecordBuilder()
        {
            _qsortActions = new Dictionary<string, Action>
                              {
                                  {"NONE\n",GetQSortWithQueue}
                              };


            Comunicator = new EndRecordAPIComunicator();
        }

        public static readonly string QSortCommand = @"QSORT*";
        public static readonly string QSortWithQueueCommand = @"QSORT/-{0}";

        private string[] _successResponses = new[] { "" };
        private readonly Dictionary<string, Action> _qsortActions;
        public void Build()
        {
            var response = Comunicator.SendCommand(QSortCommand);
            Success = true;
            ExecuteAction(response);

        }

        private void ExecuteAction(string response)
        {
            if (_qsortActions.ContainsKey(response))
            {
                _qsortActions[response]();
            }

        }
        private void GetQSortWithQueue()
        {
            var command = string.Format(QSortEndRecordBuilder.QSortWithQueueCommand, AgentQueue);
            var response = Comunicator.SendCommand(command);

            //TODO controloar error
            ExecuteAction(response);

        }

        public EndRecordAPIComunicator Comunicator { get; set; }

        public bool Success { get; set; }

        public bool IsInvoiced { get; set; }

        public string SabrePnr { get; set; }
        public bool HasPnr { get; set; }

        public string AgentQueue
        {
            get;
            set;
        }

        public string AgentFullName
        {
            get;
            set;
        }

        public string PseudoCityCode { get; set; }

        public string MessageOnProgress { get; set; }

        public string ErrorMessage { get; set; }
    }
}
