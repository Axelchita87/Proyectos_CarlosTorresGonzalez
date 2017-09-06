using MyCTS.DataAccess;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Business
{
    public class PreferencePlacesBL
    {
        public static List<PreferencePlaces> GetPreferencePlaces()
        {
            List<PreferencePlaces> parameter = new List<PreferencePlaces>();
            PreferencePlacesDAL objParameter = new PreferencePlacesDAL();
            try
            {
                try
                {
                    parameter = objParameter.GetPreferencePlaces(CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    parameter = objParameter.GetPreferencePlaces(CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }

            }
            catch
            { }

            return parameter;
        }
    }
}
