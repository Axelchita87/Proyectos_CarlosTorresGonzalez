using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class UpdateAllFirmModulesBL
    {
        public static bool UpdateTA(string ta, string type, string pcc)
        {
            bool update = true;
            UpdateAllFirmModulesDAL objUpdate = new UpdateAllFirmModulesDAL();

            try
            {
                try
                {
                    objUpdate.UpdateTA(ta,type,pcc, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch
                {
                    update = false;
                    objUpdate.UpdateTA(ta, type, pcc, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }

            }
            catch
            {
                update = false;
            }

            return update;
        }


        public static bool UpdateIATA(string iata, string office, string pcc)
        {
            bool update = true;
            UpdateAllFirmModulesDAL objUpdate = new UpdateAllFirmModulesDAL();

            try
            {
                try
                {
                    objUpdate.UpdateIATA(iata, office, pcc, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch
                {
                    update = false;
                    objUpdate.UpdateIATA(iata, office, pcc, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }

            }
            catch
            {
                update = false;
            }

            return update;
        }
    }
}
