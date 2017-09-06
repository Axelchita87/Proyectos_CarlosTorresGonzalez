using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using MyCTS.Entities;

namespace MyCTS.DataAccess
{
    public class GetAllBanksDAL
    {
        public List<Bank> GetAllBanks(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetAllBanksResources.SP_GetAllBanks);
            List<Bank> listBanks = new List<Bank>();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _bank = dr.GetOrdinal(Resources.GetAllBanksResources.PARAM_BANK);
                int _id = dr.GetOrdinal(Resources.GetAllBanksResources.PARAM_ID);

                while (dr.Read())
                {
                    Bank item = new Bank();
                    item.Id = dr.GetInt32(_id);
                    item.BankName = dr.GetString(_bank);
                    listBanks.Add(item);
                        
                }
            }

            return listBanks;
        }
    }
}
