using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class SetTABL
    {
        public static void SetTa(string firm ,string ta)
        {
            SetTADAL obj = new SetTADAL();
            try
            {
                obj.SetTea(firm, ta, CommonENT.MYCTSDBSECURITY_CONNECTION);
            }
            catch (Exception ex)
            {
                new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                obj.SetTea(firm, ta, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
            }
 
        }
    }
}
