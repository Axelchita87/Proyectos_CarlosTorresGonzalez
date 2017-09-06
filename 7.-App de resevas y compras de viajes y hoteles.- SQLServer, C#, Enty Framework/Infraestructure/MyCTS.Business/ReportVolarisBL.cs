using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class ReportVolarisBL
    {
        public static List<ReportVolaris> GetReportList = new List<ReportVolaris>();
        public static List<ReportVolaris> reportList = new List<ReportVolaris>();
        public static List<ReportVolaris> ReportVolaris(DateTime Fecha)
        {
            ReportVolarisDAL objReportVolarisDal = new ReportVolarisDAL();
            try
            {
                try
                {
                    reportList = objReportVolarisDal.ReportVolaris(Fecha, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    reportList = objReportVolarisDal.ReportVolaris(Fecha, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            {
            }

            return reportList;
        }
    }
}
