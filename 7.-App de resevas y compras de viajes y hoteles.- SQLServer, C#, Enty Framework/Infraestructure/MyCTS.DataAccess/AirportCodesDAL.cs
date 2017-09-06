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
    public class AirportCodesDAL
    {
        public List<AirportCodes> GetAirportCodes(string fieldName, string fieldName2, string fieldValue, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.AirportCodesResources.SP_GetAirportCodes);
            db.AddInParameter(dbCommand, Resources.AirportCodesResources.PARAM_QUERY, DbType.String, fieldName);
            db.AddInParameter(dbCommand, Resources.AirportCodesResources.PARAM_QUERRY2, DbType.String, fieldName2);    
            db.AddInParameter(dbCommand, Resources.AirportCodesResources.PARAM_VALUE, DbType.String, fieldValue);

            List<AirportCodes> airportCodesList = new List<AirportCodes>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _cityid = dr.GetOrdinal(Resources.AirportCodesResources.PARAM_CITYID);
                int _cityname = dr.GetOrdinal(Resources.AirportCodesResources.PARAM_CITYNAME);
                int _countryid = dr.GetOrdinal(Resources.AirportCodesResources.PARAM_COUNTRYID);
                int _countryname = dr.GetOrdinal(Resources.AirportCodesResources.PARAM_COUNTRYNAME);
                //No se ingresaron nullables por que las columnas de las tablas no aceptan nulos
                while (dr.Read())
                {
                    AirportCodes item = new AirportCodes();
                    item.CityID = dr.GetString(_cityid);
                    item.CityName = dr.GetString(_cityname);
                    item.CountryID = dr.GetString(_countryid);
                    item.CountryName = dr.GetString(_countryname);
                    airportCodesList.Add(item);

                }
            
            }

            return airportCodesList;
        
        }
    }
}
