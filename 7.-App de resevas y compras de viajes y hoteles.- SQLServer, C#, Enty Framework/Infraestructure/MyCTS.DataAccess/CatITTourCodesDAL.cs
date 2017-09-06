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
using System.Collections.Specialized;

namespace MyCTS.DataAccess
{
    public class CatITTourCodesDAL
    {
        public List<CatITTourCodes> GetITTourCodes(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcommand = db.GetStoredProcCommand(Resources.CatITTourCodesResources.SP_GetITTourCodes);
            //Este StoredProcedure no lleva parametros
            //Lista de parametros

            List<CatITTourCodes> ITTourCodesList = new List<CatITTourCodes>();
            using (IDataReader dr = db.ExecuteReader(dbcommand))
            {
                int _commandit = dr.GetOrdinal(Resources.CatITTourCodesResources.PARAM_COMMANDIT);
                int _description = dr.GetOrdinal(Resources.CatITTourCodesResources.PARAM_DESCRIPTION);
                //No se ingresaron nullables por que las columnas de las tablas no aceptan nulos
                while (dr.Read())
                {
                    CatITTourCodes item = new CatITTourCodes();
                    item.CommandIT = (dr[_commandit] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_commandit);
                    item.Description = (dr[_description] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_description);
                    ITTourCodesList.Add(item);
                }

            }
            return ITTourCodesList;


        }
    }
}
