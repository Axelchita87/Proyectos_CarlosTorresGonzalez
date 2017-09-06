using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class UpdateStatusAllFirmModulesBL
    {
        public static bool UpdateStatusTA(string ta)
        {
            bool update = true;
            UpdateStatusAllFirmModulesDAL objUpdateStatus=new UpdateStatusAllFirmModulesDAL();

            try
            {
                try
                {
                    objUpdateStatus.UpdateStatusTA(ta, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch
                {
                    objUpdateStatus.UpdateStatusTA(ta, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                    update = false;
                }
            }
            catch 
            {
                update = false;
            }

            return update;
        }



        public static bool UpdateUnassignStatusTA(string ta)
        {
            bool update = true;
            UpdateStatusAllFirmModulesDAL objUpdateStatus = new UpdateStatusAllFirmModulesDAL();

            try
            {
                try
                {
                    objUpdateStatus.UpdateUnassignStatusTA(ta, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch
                {
                    objUpdateStatus.UpdateUnassignStatusTA(ta, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                    update = false;
                }
            }
            catch
            {
                update = false;
            }

            return update;
        }



        public static bool UpdateStatusQueue(string queue)
        {
            bool update = true;
            UpdateStatusAllFirmModulesDAL objUpdateStatus = new UpdateStatusAllFirmModulesDAL();

            try
            {
                try
                {
                    objUpdateStatus.UpdateStatusQueue(queue, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch
                {
                    objUpdateStatus.UpdateStatusQueue(queue, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                    update = false;
                }
            }
            catch
            {
                update = false;
            }

            return update;
        }



        public static bool UpdateUnassignStatusQueue(string queue)
        {
            bool update = true;
            UpdateStatusAllFirmModulesDAL objUpdateStatus = new UpdateStatusAllFirmModulesDAL();

            try
            {
                try
                {
                    objUpdateStatus.UpdateUnassignStatusQueue(queue, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch
                {
                    objUpdateStatus.UpdateUnassignStatusQueue(queue, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                    update = false;
                }
            }
            catch
            {
                update = false;
            }

            return update;
        }



        public static bool UpdateStatusAgent(string agent)
        {
            bool update = true;
            UpdateStatusAllFirmModulesDAL objUpdateStatus = new UpdateStatusAllFirmModulesDAL();

            try
            {
                try
                {
                    objUpdateStatus.UpdateStatusAgent(agent, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch
                {
                    objUpdateStatus.UpdateStatusAgent(agent, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                    update = false;
                }
            }
            catch
            {
                update = false;
            }

            return update;
        }



        public static bool UpdateUnassignStatusAgent(string agent)
        {
            bool update = true;
            UpdateStatusAllFirmModulesDAL objUpdateStatus = new UpdateStatusAllFirmModulesDAL();

            try
            {
                try
                {
                    objUpdateStatus.UpdateUnassignStatusAgent(agent, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch
                {
                    objUpdateStatus.UpdateUnassignStatusAgent(agent, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                    update = false;
                }
            }
            catch
            {
                update = false;
            }

            return update;
        }



        public static bool UpdateStatusFirm(string firm)
        {
            bool update = true;
            UpdateStatusAllFirmModulesDAL objUpdateStatus = new UpdateStatusAllFirmModulesDAL();

            try
            {
                try
                {
                    objUpdateStatus.UpdateStatusFirm(firm, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch
                {
                    objUpdateStatus.UpdateStatusFirm(firm, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                    update = false;
                }
            }
            catch
            {
                update = false;
            }

            return update;
        }



        public static bool UpdateUnassignStatusFirm(string firm)
        {
            bool update = true;
            UpdateStatusAllFirmModulesDAL objUpdateStatus = new UpdateStatusAllFirmModulesDAL();

            try
            {
                try
                {
                    objUpdateStatus.UpdateUnassignStatusFirm(firm, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch
                {
                    objUpdateStatus.UpdateUnassignStatusFirm(firm, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                    update = false;
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
