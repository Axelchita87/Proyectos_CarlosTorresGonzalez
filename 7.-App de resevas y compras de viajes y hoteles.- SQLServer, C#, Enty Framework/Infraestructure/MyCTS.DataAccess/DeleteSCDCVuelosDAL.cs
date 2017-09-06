using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Components.NullableHelper;
using MyCTS.Entities;
using System;
using System.Data;
using System.Data.Common;

namespace MyCTS.DataAccess
{
    public class DeleteSCDCVuelosDAL
    {
        public string DeleteSCDCVuelo(string pnr, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.DeleteSCDCVueloResources.SP_eliminavuelos);

            db.AddInParameter(dbCommand, Resources.DeleteSCDCVueloResources.PARAM_RECLOC, DbType.String, pnr);

            string registros = string.Empty;

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _registros = dr.GetOrdinal(Resources.DeleteSCDCVueloResources.PARAM_REGISTROS);

                while (dr.Read())
                {
                    registros = (dr[_registros] == DBNull.Value) ? Types.StringNullValue : dr.GetInt32(_registros).ToString();
                }
            }

            return registros;
        }

    }
}
