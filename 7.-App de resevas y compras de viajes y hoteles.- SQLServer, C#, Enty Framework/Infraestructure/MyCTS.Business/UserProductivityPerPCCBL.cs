using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;


namespace MyCTS.Business
{
    public class UserProductivityPerPCCBL
    {
        public static List<UserProductivityPerPCC> GetUserProductivityPerPCC(string Agent, string ProductivityDate, int IdType)
        {
            List<UserProductivityPerPCC> listUserProductivityPerPCC = new List<UserProductivityPerPCC>();
            UserProductivityPerPCCDAL objProductivity = new UserProductivityPerPCCDAL();
            try
            {
                try
                {
                    listUserProductivityPerPCC = objProductivity.GetUserProductivityPerPCC(Agent, ProductivityDate, IdType, CommonENT.MYCTSDBPRODUCTIVITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listUserProductivityPerPCC = objProductivity.GetUserProductivityPerPCC(Agent, ProductivityDate,IdType, CommonENT.MYCTSDBPRODUCTIVITYBACKUP_CONNECTION);
                }

            }
            catch
            { }

            return listUserProductivityPerPCC;
        }

    }
}
