using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Components.NullableHelper;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace MyCTS.DataAccess
{
    public class ClientUsersInterjetDAL
    {
        public void GetClientesUserInterjet(string user, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand("GetClientUserInterjet");
            db.AddInParameter(dbCommand, "@User", DbType.String, user.ToLower());

            try
            {
                using (IDataReader dr = db.ExecuteReader(dbCommand))
                {
                    int _numberPurse = dr.GetOrdinal("NumberPurse");
                    while (dr.Read())
                    {
                        CostumerAccountInterJet.NumberPurche = (dr[_numberPurse] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_numberPurse);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
