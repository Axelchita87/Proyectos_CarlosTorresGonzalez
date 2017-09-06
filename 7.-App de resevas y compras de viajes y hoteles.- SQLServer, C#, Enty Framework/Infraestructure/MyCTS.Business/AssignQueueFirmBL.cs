using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class AssignQueueFirmBL
    {
        public static bool AssignQueueFirm(string newQueue, string agent, string pcc)
        {
            bool change = true;
            AssignQueueFirmDAL objAssignQueue = new AssignQueueFirmDAL();
            try
            {
                objAssignQueue.AssignQueueFirm(newQueue, agent, pcc, CommonENT.MYCTSDBSECURITY_CONNECTION);
            }
            catch
            {
                change = false;
                objAssignQueue.AssignQueueFirm(newQueue, agent, pcc, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
            }

            return change;
        }
    }
}
