using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace MyCTS.DataAccess
{
    public class ServiceMDDAL
    {
        public List<ServicesMD> GetServiceMD(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand("GetServicesMD");
            List<ServicesMD> ServiceMDList = new List<ServicesMD>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _service = dr.GetOrdinal("Service");
                while (dr.Read())
                {
                    ServicesMD item = new ServicesMD();
                    item.Service = dr.GetString(_service);
                    ServiceMDList.Add(item);
                }
            }
            return ServiceMDList;
        }
    }
}
