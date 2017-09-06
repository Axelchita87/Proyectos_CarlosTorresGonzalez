using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class UserProductivityGenericBL
    {
        public static List<UserProductivityGeneric> GetUserProductivityPerWeek(string Agent, string ProductivityDate)
        {
            List<UserProductivityGeneric> listUserProductivityPerWeek = new List<UserProductivityGeneric>();
            UserProductivityGenericDAL objProductivity = new UserProductivityGenericDAL();
            try
            { 
                try
                {
                    listUserProductivityPerWeek = objProductivity.GetUserProductivityPerWeek(Agent, ProductivityDate, CommonENT.MYCTSDBPRODUCTIVITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listUserProductivityPerWeek = objProductivity.GetUserProductivityPerWeek(Agent, ProductivityDate, CommonENT.MYCTSDBPRODUCTIVITYBACKUP_CONNECTION);
                }

            }
            catch
            { }

            return listUserProductivityPerWeek;
        }

        public static List<UserProductivityGeneric> GetUserProductivityPerMonth(string Agent, string ProductivityDate)
        {
            List<UserProductivityGeneric> listUserProductivityPerMonth = new List<UserProductivityGeneric>();
            UserProductivityGenericDAL objProductivity = new UserProductivityGenericDAL();
            try
            {
                try
                {
                    listUserProductivityPerMonth = objProductivity.GetUserProductivityPerMonth(Agent,ProductivityDate, CommonENT.MYCTSDBPRODUCTIVITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listUserProductivityPerMonth = objProductivity.GetUserProductivityPerMonth(Agent,ProductivityDate, CommonENT.MYCTSDBPRODUCTIVITYBACKUP_CONNECTION);
                }

            }
            catch
            { }

            return listUserProductivityPerMonth;
        }

        public static List<UserProductivityGeneric> GetUserProductivityPerAccumulated(string Agent)
        {
            List<UserProductivityGeneric> listUserProductivityPerAccumulated = new List<UserProductivityGeneric>();
            UserProductivityGenericDAL objProductivity = new UserProductivityGenericDAL();
            try
            {
                try
                {
                    listUserProductivityPerAccumulated = objProductivity.GetUserProductivityPerAccumulated(Agent, CommonENT.MYCTSDBPRODUCTIVITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listUserProductivityPerAccumulated = objProductivity.GetUserProductivityPerAccumulated(Agent, CommonENT.MYCTSDBPRODUCTIVITYBACKUP_CONNECTION);
                }
            }
            catch
            { }

            return listUserProductivityPerAccumulated;
        }


    }
}
