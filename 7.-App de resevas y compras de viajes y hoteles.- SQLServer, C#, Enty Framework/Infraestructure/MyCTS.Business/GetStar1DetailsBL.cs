using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetStar1DetailsBL
    {
        public Star1Details GetStar1Details(string pcc, string profileName)
        {
            var listStar1Details = new Star1Details();
            var objStar1Details = new GetStar1DetailsDAL();
            try
            {
                try
                {
                    listStar1Details = objStar1Details.ObjGetStar1Details(pcc,profileName, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listStar1Details = objStar1Details.ObjGetStar1Details(pcc, profileName, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch{ }
            return listStar1Details;
        }
    }
}
