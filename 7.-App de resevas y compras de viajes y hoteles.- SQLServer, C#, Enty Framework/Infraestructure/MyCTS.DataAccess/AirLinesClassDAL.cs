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
    public class AirLinesClassDAL
    {
        public List<AirLinesClass> GetCatAirLinesClass(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcommand = db.GetStoredProcCommand(Resources.AirLinesClassResources.SP_GetCatAirLinesClass);
            //Este StoredProcedure no lleva parametros
            //Lista de parametros

            List<AirLinesClass> airLinesClassList = new List<AirLinesClass>();
            using (IDataReader dr = db.ExecuteReader(dbcommand))
            {
                int _airlineclassid = dr.GetOrdinal(Resources.AirLinesClassResources.PARAM_CATAIRLINCLAID);
                int _airlinenameclass = dr.GetOrdinal(Resources.AirLinesClassResources.PARAM_CATAIRLINCLANAME);
                //No se ingresaron nullables por que las columnas de las tablas no aceptan nulos
                while (dr.Read())
                {
                    AirLinesClass item = new AirLinesClass();
                    item.CatAirLinClaID = dr.GetString(_airlineclassid);
                    item.CatAirLinClaName = dr.GetString(_airlinenameclass);
                    airLinesClassList.Add(item);
                }

            }
            return airLinesClassList;


        }
    }
}

