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
    public class CatCitiesDAL
    {
        public List<ListItem> GetCities(string StrToSearch, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatCitiesResources.SP_GetCities);
            db.AddInParameter(dbCommand, Resources.CatCitiesResources.PARAM_QUERY, DbType.String, StrToSearch);

            List<ListItem> CitiesList = new List<ListItem>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _catcitid = dr.GetOrdinal(Resources.CatCitiesResources.PARAM_CATCITID);
                int _catcitname = dr.GetOrdinal(Resources.CatCitiesResources.PARAM_CATCITNAME);

                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Value = dr.GetString(_catcitid);
                    item.Text = string.Concat(dr.GetString(_catcitid),' ', dr.GetString(_catcitname));
                    CitiesList.Add(item);
                }
            }

            return CitiesList;
        }

        public List<ListItem> GetCodeCities(string StrToSearch, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatCitiesResources.SP_GetCatCitiCouID);
            db.AddInParameter(dbCommand, Resources.CatCitiesResources.PARAM_StrToSearch, DbType.String, StrToSearch);

            List<ListItem> CitiesList = new List<ListItem>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _citiCouID = dr.GetOrdinal(Resources.CatCitiesResources.PARAM_CITCOUID);


                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Value = dr.GetString(_citiCouID);
                    CitiesList.Add(item);
                }
            }

            return CitiesList;
        }
    }
}
