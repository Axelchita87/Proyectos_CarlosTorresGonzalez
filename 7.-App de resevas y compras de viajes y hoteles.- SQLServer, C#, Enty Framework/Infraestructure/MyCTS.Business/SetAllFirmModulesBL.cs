using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class SetAllFirmModulesBL
    {
        public static bool SetTA(string type, string pcc, string ta)
        {
            bool isInserted = false;
            SetAllFirmModulesDAL obj = new SetAllFirmModulesDAL();
            try
            {
                try
                {
                    obj.SetTA(type, pcc, ta, CommonENT.MYCTSDBSECURITY_CONNECTION);
                    isInserted = true;
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    isInserted = false;
                    obj.SetTA(type, pcc, ta, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
            }
            catch{ isInserted = false; }

            return isInserted;
        }

        public static bool SetIATA(string iata, string office, string pcc)
        {
            bool isInserted = false;
            SetAllFirmModulesDAL obj = new SetAllFirmModulesDAL();
            try
            {
                try
                {
                    obj.SetIATA(iata, office, pcc, CommonENT.MYCTSDBSECURITY_CONNECTION);
                    isInserted = true;
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    isInserted = false;
                    obj.SetIATA(iata, office, pcc, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
            }
            catch { isInserted = false; }

            return isInserted;
        }
    }
}
