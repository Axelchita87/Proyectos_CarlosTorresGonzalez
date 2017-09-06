using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetAllFirmModulesBL
    {
        public static TA GetTA(string ta)
        {
            TA objTA=new TA();
            GetAllFirmModulesDAL objGet = new GetAllFirmModulesDAL();

            try
            {
                try
                {
                    objTA = objGet.GetTA(ta, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch
                {
                    objTA = objGet.GetTA(ta, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
            }
            catch {}

            return objTA;
        }

        public static IATA GetIATA(string ta)
        {
            IATA objIATA = new IATA();
            GetAllFirmModulesDAL objGet = new GetAllFirmModulesDAL();

            try
            {
                try
                {
                    objIATA = objGet.GetIATA(ta, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch
                {
                    objIATA = objGet.GetIATA(ta, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
            }
            catch { }

            return objIATA;
        }
    }
}
