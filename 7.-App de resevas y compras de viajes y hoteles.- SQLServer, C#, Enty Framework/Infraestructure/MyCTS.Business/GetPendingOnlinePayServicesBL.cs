using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetPendingOnlinePayServicesBL
    {
        public static List<CreditCardInfo> GetPendingOnlinePayServices(String sPNR)
        {
            return GetPendingOnlinePayServicesDAL.GetPendingOnlinePayServices(sPNR);
        }
    }
}
