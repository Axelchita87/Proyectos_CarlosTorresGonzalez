using System;
using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class ReportInterjetBL
    {
        public static List<InterJetReport> GetReportList = new List<InterJetReport>();
        public static List<InterJetReport> reportList = new List<InterJetReport>();
        public static List<InterJetReport> ReportInterjet(DateTime Fecha)
        {

            ReportInterjetDAL objReportInterJetDal = new ReportInterjetDAL();
            try
            {
                try
                {
                    reportList = objReportInterJetDal.ReportInterjet(Fecha, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    reportList = objReportInterJetDal.ReportInterjet(Fecha, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            {
            }

            return reportList;
        }
    }
}
