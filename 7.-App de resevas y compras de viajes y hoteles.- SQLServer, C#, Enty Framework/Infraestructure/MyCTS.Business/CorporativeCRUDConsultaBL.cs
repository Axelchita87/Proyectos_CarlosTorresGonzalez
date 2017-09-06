using MyCTS.DataAccess;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Business
{
    public class CorporativeCRUDConsultaBL
    {
        public static List<CorporativeCRUDConsulta> ReportCorporateConsulting(string Attribute1)
        {
            CorporativeCRUDConsultaDAL objReportListDal = new CorporativeCRUDConsultaDAL();
            List<CorporativeCRUDConsulta> listReportCorporative = new List<CorporativeCRUDConsulta>();
            try
            {
                try
                {
                    listReportCorporative = objReportListDal.ReportCorporateConsulting(Attribute1, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listReportCorporative = objReportListDal.ReportCorporateConsulting(Attribute1, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch{ }
            return listReportCorporative;
        }

        public static List<CorporativeCRUDConsulta> ReportCorporateConsulting(int Firm, string attribute1)
        {
            CorporativeCRUDConsultaDAL objReportListDal = new CorporativeCRUDConsultaDAL();
            List<CorporativeCRUDConsulta> listReportCorporative = new List<CorporativeCRUDConsulta>();
            try
            {
                try
                {
                    listReportCorporative = objReportListDal.ReportCorporateConsulting(Firm,attribute1, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listReportCorporative = objReportListDal.ReportCorporateConsulting(Firm, attribute1, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
            return listReportCorporative;
        }

        public static List<CorporativeConsultaGrid> ReportCorporateConsulting()
        {
            CorporativeCRUDConsultaDAL objReportListDal = new CorporativeCRUDConsultaDAL();
            List<CorporativeConsultaGrid> listReportCorporative = new List<CorporativeConsultaGrid>();
            try
            {
                try
                {
                    listReportCorporative = objReportListDal.ReportCorporateConsulting(CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listReportCorporative = objReportListDal.ReportCorporateConsulting( CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
            return listReportCorporative;
        }

        public static List<CorporativeConsultaGrid> ReportCorporateConsultingGrid(int firm, string grid)
        {
            CorporativeCRUDConsultaDAL objReportListDal = new CorporativeCRUDConsultaDAL();
            List<CorporativeConsultaGrid> listReportCorporative = new List<CorporativeConsultaGrid>();
            try
            {
                try
                {
                    listReportCorporative = objReportListDal.ReportCorporateConsultingGrid(firm, grid, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listReportCorporative = objReportListDal.ReportCorporateConsultingGrid(firm, grid, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
            return listReportCorporative;
        }

    }
}
