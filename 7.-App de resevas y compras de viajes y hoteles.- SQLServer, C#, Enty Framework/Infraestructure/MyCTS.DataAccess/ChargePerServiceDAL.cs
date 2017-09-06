using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.IO;
using System.Data;
using System.Data.Common;
using MyCTS.Entities;
using MyCTS.Components.NullableHelper;

namespace MyCTS.DataAccess
{
    public class ChargePerServiceDAL
    {
        public List<ChargePerService> GetChargePerService(string StrToSearch, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.ChargePerServiceResouces.SP_GETCHARGEPERSERVICE);
            db.AddInParameter(dbCommand, Resources.ChargePerServiceResouces.PARAM_QUERY, DbType.String, StrToSearch);

            List<ChargePerService> ChargePerServiceList = new List<ChargePerService>();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _idpaymentform = dr.GetOrdinal(Resources.ChargePerServiceResouces.PARAM_IDPAYMENTFORM);
                int _description = dr.GetOrdinal(Resources.ChargePerServiceResouces.PARAM_DESCRIPTION);
                int _import = dr.GetOrdinal(Resources.ChargePerServiceResouces.PARAM_IMPORT);
               

                while (dr.Read())
                {
                    ChargePerService item = new ChargePerService();
                    item.Import = (dr[_import] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_import);
                    item.IDPaymentForm = dr.GetString(_idpaymentform);
                    item.Description = (dr[_description] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_description);

                    ChargePerServiceList.Add(item);
                }
            }
            return ChargePerServiceList;
        }
    }
}
