using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class LowFareAirLinesErrorLogger
    {


        public static string Volaris = "Volaris";
        public static string InterJet = "InterJet";
        private static LowFareAirLinesErrorLogger _logger;


        private static LowFareAirLinesErrorLoggerDAL _dataAcces;
        private static LowFareAirLinesErrorLoggerDAL DataAccess
        {
            get { return _dataAcces ?? (_dataAcces = new LowFareAirLinesErrorLoggerDAL()); }
        }


        public static LowFareAirLinesErrorLogger Instance
        {
            get { return _logger ?? (_logger = new LowFareAirLinesErrorLogger()); }
        }

        public void Log(LowFareAirLinesError error)
        {
            DataAccess.Log(error);
        }

        public void Log(string agent, string errorMessage, string airLine, DateTime date)
        {
            Log(new LowFareAirLinesError
                    {
                        Agent = agent,
                        ErrorMessage = errorMessage,
                        AirLine = airLine,
                        Date = date
                    });
        }

    }
}
