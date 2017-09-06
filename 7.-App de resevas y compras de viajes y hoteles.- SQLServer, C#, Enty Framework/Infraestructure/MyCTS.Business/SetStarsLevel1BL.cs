using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class SetStarsLevel1BL
    {
        public static void AddStarslevel1(string Pccid, string Star1Name, bool StarL2Exist, bool Active)
        {
            SetStarsLevel1DAL objSetStarsLevel1 = new SetStarsLevel1DAL();
            try
            {
                try
                {
                    objSetStarsLevel1.AddStarsLevel1(Pccid, Star1Name, StarL2Exist, Active, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objSetStarsLevel1.AddStarsLevel1(Pccid, Star1Name, StarL2Exist, Active, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch { }
        }
    }
}
