using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class SetStarsLevel2InfoBL
    {
        public static void AddStarsLevel2Info(string Pccid, string Level1, string Level2, string Type, string Text, DateTime Date, bool Purged)
        {
            SetStarsLevel2InfoDAL objSetStarsLevel2Info = new SetStarsLevel2InfoDAL();
            try
            {
                try
                {
                    objSetStarsLevel2Info.AddStarsLevel2Info(Pccid, Level1, Level2, Type, Text, Date, Purged, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objSetStarsLevel2Info.AddStarsLevel2Info(Pccid, Level1, Level2, Type, Text, Date, Purged, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch { }
        }
    }
}
