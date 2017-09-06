using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetAllFirmModulesForNewUserBL
    {
        public static TA GetTA(string pcc)
        {
            TA ta = new TA();
            GetAllFirmModulesForNewUserDAL objGetTA = new GetAllFirmModulesForNewUserDAL();

            try
            {
                try
                {
                    ta = objGetTA.GetTA(pcc, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch
                {
                    ta = objGetTA.GetTA(pcc, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
            }
            catch
            {
            }

            return ta;
        }


        public IATA GetIATA()
        {
            IATA iata = new IATA();
            GetAllFirmModulesForNewUserDAL objGetIATA = new GetAllFirmModulesForNewUserDAL();

            try
            {
                try
                {
                    iata = objGetIATA.GetIATA(CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch
                {
                    iata = objGetIATA.GetIATA(CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
            }
            catch
            {
            }

            return iata;
        }

        public static Queue GetQueue()
        {
            Queue queue = new Queue();
            GetAllFirmModulesForNewUserDAL objGetQueue = new GetAllFirmModulesForNewUserDAL();

            try
            {
                try
                {
                    queue = objGetQueue.GetQUEUE(CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch
                {
                    queue = objGetQueue.GetQUEUE(CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
            }
            catch
            {
            }

            return queue;
        }


        public static Agent GetAgent()
        {
            Agent agent = new Agent();
            GetAllFirmModulesForNewUserDAL objGetAgent = new GetAllFirmModulesForNewUserDAL();

            try
            {
                try
                {
                    agent = objGetAgent.GetAgent(CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch
                {
                    agent = objGetAgent.GetAgent(CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
            }
            catch
            {
            }

            return agent;
        }


        public static Firm GetFirm()
        {
            Firm firm = new Firm();
            GetAllFirmModulesForNewUserDAL objGetFirm = new GetAllFirmModulesForNewUserDAL();

            try
            {
                try
                {
                    firm = objGetFirm.GetFirm(CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch
                {
                    firm = objGetFirm.GetFirm(CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
            }
            catch
            {
            }

            return firm;
        }
    }
}
