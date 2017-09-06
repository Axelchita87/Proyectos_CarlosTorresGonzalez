using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class SetStarsLevel1InfoBL
    {
        public static void AddStarslevel1Info(string Pccid, string Level1, string Type, string Text, DateTime Date, bool Purged)
        {
            SetStarsLevel1InfoDAL objSetStarsLevel1Info = new SetStarsLevel1InfoDAL();
            try
            {
                try
                {
                    objSetStarsLevel1Info.AddStarsLevel1Info(Pccid, Level1, Type, Text, Date, Purged, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objSetStarsLevel1Info.AddStarsLevel1Info(Pccid, Level1, Type, Text, Date, Purged, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch { }
        }
    }
}
