using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetDeactivatedStarsBL
    {
        public static List<DeactivatedStar> GetDeactivatedStars(string dk)
        {
            List<DeactivatedStar> deactivatedStarsList = new List<DeactivatedStar>();
            DeactivatedStarsDAL objDeactivated = new DeactivatedStarsDAL();
            try
            {
                try
                {
                    deactivatedStarsList = objDeactivated.GetDeactivatedStars(dk, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    deactivatedStarsList = objDeactivated.GetDeactivatedStars(dk, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch { }
            return deactivatedStarsList;
        }

        public static List<string> GetDeactivatedStarSecondLevel(string name, string level1)
        {
            DeactivatedStarsDAL objDeactivated = new DeactivatedStarsDAL();
            List<string> historic = new List<string>();
            try
            {
                try
                {
                    historic = objDeactivated.GetLinesSecondLevel(name, level1, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    historic = objDeactivated.GetLinesSecondLevel(name, level1, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch { }

            return historic;
        }
    }
}
