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
    public class ParameterDAL
    {
        public Parameter GetParameterValue(string ParameterName, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcommand = db.GetStoredProcCommand(Resources.ParameterResources.SP_GetParameterValue);
            //Lista de parametros
            db.AddInParameter(dbcommand, Resources.ParameterResources.PARAM_QUERY, DbType.String, ParameterName);

            Parameter item = null;
            using (IDataReader dr = db.ExecuteReader(dbcommand))
            {
                int _values = dr.GetOrdinal(Resources.ParameterResources.PARAM_VALUES);
                //No se ingresaron nullables por que las columnas de las tablas no aceptan nulos
                if (dr.Read())
                {
                    item = new Parameter();
                    item.Values = (dr[_values] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_values);
                }

            }

            return item;
        }

        public void UpdateComissionBoardUrl(string url, string parameterName, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.ParameterResources.SP_UpdateCommisionBoardURL);
            db.AddInParameter(dbcomand, Resources.ParameterResources.PARAM_URL, DbType.String, url);
            db.AddInParameter(dbcomand, Resources.ParameterResources.PARAM_PARAMETER_NAME, DbType.String, parameterName);          
            db.ExecuteNonQuery(dbcomand);
        }

    }
}
