using System;
using System.Collections.Generic;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{

    public class FieldsDynamicsBL
    {
        public List<Dynamic> GetStar1Details(String pcc, string level1)
        {
            var listFieldsDynamics = new List<Dynamic>();
            var objFieldsDynamics = new FieldsDinamicsDAL();
            try
            {
                try
                {
                    listFieldsDynamics = objFieldsDynamics.GetStar1Profile(pcc, level1, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    //new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listFieldsDynamics = objFieldsDynamics.GetStar1Profile(pcc, level1, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch { }
            return listFieldsDynamics;
        }

        public static List<Dynamic> GetStar2Details(String email)
        {
            var listFieldsDynamics = new List<Dynamic>();
            var objFieldsDynamics = new FieldsDinamicsDAL();
            try
            {
                try
                {
                    listFieldsDynamics = objFieldsDynamics.GetStar2Profile(email, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    //new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listFieldsDynamics = objFieldsDynamics.GetStar2Profile(email, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch { }
            return listFieldsDynamics;
        }

        public static List<Dynamic> GetStar2Details(String pcc, String level1,String level2)
        {
            var listFieldsDynamics = new List<Dynamic>();
            var objFieldsDynamics = new FieldsDinamicsDAL();
            try
            {
                try
                {
                    listFieldsDynamics = objFieldsDynamics.GetStar2Profile(pcc, level1, level2, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    //new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listFieldsDynamics = objFieldsDynamics.GetStar2Profile(pcc, level1, level2, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch { }
            return listFieldsDynamics;
        }

        public void SetOrUpdateStar(List<Dynamic> objDynamic, int? id, int level)
        {

            var objFieldsDynamics = new FieldsDinamicsDAL();
            try
            {
                try
                {
                    objFieldsDynamics.SetOrUpdateStarProfile(objDynamic, id, level, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objFieldsDynamics.SetOrUpdateStarProfile(objDynamic, id, level, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch (Exception e) { e.ToString(); }


        }
    }
}
