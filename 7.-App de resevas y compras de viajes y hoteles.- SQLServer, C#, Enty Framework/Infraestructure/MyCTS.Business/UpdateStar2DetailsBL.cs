using System;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    class UpdateStar2DetailsBL
    {
        class UpdateStar2Details
        {
            public static void UpdateStars1Details(Star2Details s2Details)
            {
                var objUpdateStar2DetailsDAL = new UpdateStar2DetailsDAL();
                try
                {
                    try
                    {
                        objUpdateStar2DetailsDAL.UpdateS2Details(s2Details, CommonENT.MYCTSDBPROFILES_CONNECTION);
                    }
                    catch (Exception e)
                    {
                        objUpdateStar2DetailsDAL.UpdateS2Details(s2Details, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                    }
                }
                catch (Exception e){ }
            }
        }
    }
}
