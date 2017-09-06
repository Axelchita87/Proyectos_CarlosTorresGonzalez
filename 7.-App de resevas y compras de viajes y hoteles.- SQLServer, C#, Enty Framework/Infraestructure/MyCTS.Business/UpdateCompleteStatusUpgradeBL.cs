using System;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class UpdateCompleteStatusUpgradeBL
    {
        public static void UpdateCompleteStatusUpgrade(Guid UserId)
        {
            UpdateCompleteStatusUpgradeDAL objUpdateCompleteStatusUpgrade = new UpdateCompleteStatusUpgradeDAL();
            {
                try
                {
                    try
                    {
                        objUpdateCompleteStatusUpgrade.UpdateCompleteStatusUpgrade(UserId, CommonENT.MYCTSDBSECURITY_CONNECTION);
                    }
                    catch (Exception ex)
                    {
                        new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                        objUpdateCompleteStatusUpgrade.UpdateCompleteStatusUpgrade(UserId, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                    }
                }
                catch { }
            }
        }
    }
}
