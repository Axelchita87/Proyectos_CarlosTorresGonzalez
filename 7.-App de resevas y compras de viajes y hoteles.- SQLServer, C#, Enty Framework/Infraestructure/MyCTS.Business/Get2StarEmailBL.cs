using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class Get2StarEmailBL
    {
        public static List<Star2Details> Get2StarEmail(string searchEmail, string mail2)
        {
            List<Star2Details> star2List = new List<Star2Details>();
            Get2StarEmailDAL objGetEmail = new Get2StarEmailDAL();

            try
            {
                try
                {
                    star2List = objGetEmail.Get2StarEmail(searchEmail, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    star2List = objGetEmail.Get2StarEmail(searchEmail, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch { }

            return star2List;
        }
    }
}
