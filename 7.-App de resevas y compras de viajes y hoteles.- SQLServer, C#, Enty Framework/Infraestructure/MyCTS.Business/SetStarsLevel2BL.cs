using System;
using MyCTS.Entities;
using MyCTS.DataAccess;
namespace MyCTS.Business
{
    public class SetStarsLevel2BL
    {
        public static void AddStarslevel2(string Pccid, string Star1id, string Star2Name, bool Active, string Email)
        {
            SetStarsLevel2DAL objSetStarsLevel2 = new SetStarsLevel2DAL();
            try
            {
                try
                {
                    objSetStarsLevel2.AddStarsLevel2(Pccid, Star1id, Star2Name, Active, Email, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objSetStarsLevel2.AddStarsLevel2(Pccid, Star1id, Star2Name, Active, Email, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch { }
        }

    }
}