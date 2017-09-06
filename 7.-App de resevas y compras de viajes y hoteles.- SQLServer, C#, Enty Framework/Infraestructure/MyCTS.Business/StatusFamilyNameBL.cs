using MyCTS.DataAccess;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Business
{
    public class StatusFamilyNameBL
    {
        public static StatusFamilyName StautsFamilyName(string firm)
        {
            StatusFamilyName statusFamilyName = new StatusFamilyName();
            StatusFamilyNameDAL objGetStatusFamilyName = new StatusFamilyNameDAL();
            try
            {
                try
                {
                    statusFamilyName = objGetStatusFamilyName.StautsFamilyName(firm, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    statusFamilyName = objGetStatusFamilyName.StautsFamilyName(firm, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }

            }
            catch
            { }
            return statusFamilyName;
        }
        public static StatusFamilyName StautsFamilyName(string firm, string pcc)
        {
            StatusFamilyName statusFamilyName = new StatusFamilyName();
            StatusFamilyNameDAL objGetStatusFamilyName = new StatusFamilyNameDAL();
            try
            {
                try
                {
                    statusFamilyName = objGetStatusFamilyName.StautsFamilyName(firm,pcc, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    statusFamilyName = objGetStatusFamilyName.StautsFamilyName(firm,pcc, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }

            }
            catch
            { }
            return statusFamilyName;
        }
    }
}
