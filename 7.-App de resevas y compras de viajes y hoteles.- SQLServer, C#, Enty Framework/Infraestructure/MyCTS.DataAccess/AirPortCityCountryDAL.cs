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
    public class AirPortCityCountryDAL
    {
        public List<AirPortCityCountry> GetAirPortCityCountry(string StrToSearch, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.AirPortCityCountryResources.SP_GetAirPortCityCountry);
            db.AddInParameter(dbCommand, Resources.AirPortCityCountryResources.PARAM_QUERY1, DbType.String,StrToSearch);
            List<AirPortCityCountry> airportCityCountry = new List<AirPortCityCountry>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _catcitid = dr.GetOrdinal(Resources.AirPortCityCountryResources.PARAM_CATCITID);
                int _catcitname = dr.GetOrdinal(Resources.AirPortCityCountryResources.PARAM_CATCITNAME);
                int _catcouid = dr.GetOrdinal(Resources.AirPortCityCountryResources.PARAM_CATCOUID);
                int _catcouname = dr.GetOrdinal(Resources.AirPortCityCountryResources.PARAM_CATCOUNAME);

                while (dr.Read())
                {
                    AirPortCityCountry item = new AirPortCityCountry();
                    item.CatCitId = dr.GetString(_catcitid);
                    item.CatCitName = dr.GetString(_catcitname);
                    item.CatCouId = dr.GetString(_catcouid);
                    item.CatCouName = (dr[_catcouname] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catcouname);
                    airportCityCountry.Add(item);
                }
            }

            return airportCityCountry;
            
        }

        public List<ListItem> GetAirPortCityCountry_Predictive(string StrToSearch)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetAirPortCityCountry_Predictive");
            db.AddInParameter(dbCommand, Resources.AirPortCityCountryResources.PARAM_QUERY1, DbType.String, StrToSearch);
            List<ListItem> airportCityCountry = new List<ListItem>();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _catcitid = dr.GetOrdinal(Resources.AirPortCityCountryResources.PARAM_CATCITID);
                int _catcitname = dr.GetOrdinal(Resources.AirPortCityCountryResources.PARAM_CATCITNAME);
                int _catcouid = dr.GetOrdinal(Resources.AirPortCityCountryResources.PARAM_CATCOUID);
                int _catcouname = dr.GetOrdinal(Resources.AirPortCityCountryResources.PARAM_CATCOUNAME);

                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Value = dr.GetString(_catcitid);
                    item.Text = string.Concat(dr.GetString(_catcitid), ' ', dr.GetString(_catcitname), ' ',
                        ((dr[_catcouname] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catcouname)));
                    airportCityCountry.Add(item);
                }
            }

            return airportCityCountry;

        }
    }
}
