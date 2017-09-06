using System;
using System.Collections.Generic;
using System.Text;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class CatCCDHLBL
    {
        public static List<CatCCDHL> GetCCDHL()
        {
            List<CatCCDHL> CatCCDHLList = new List<CatCCDHL>();
            try
            {
                CatCCDHLDAL objCCDHL = new CatCCDHLDAL();
                CatCCDHLList = objCCDHL.GetCCDHL();
            }
            catch
            { }
            return CatCCDHLList;

        }
    }
}
