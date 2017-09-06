using MyCTS.DataAccess;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Business
{
    public class DeleteToolOnlineRulesBL
    {
        public static void DeleteToolOnlineRules(string attribute)
        {
            DeleteToolOnlineRulesDAL objDeleteRules = new DeleteToolOnlineRulesDAL();
            try
            {
              objDeleteRules.DeleteRules(attribute, CommonENT.MYCTSDB_CONNECTION);
            }
            catch
            {
              objDeleteRules.DeleteRules(attribute, CommonENT.MYCTSDBBACKUP_CONNECTION);
            }
        }
    }
}
