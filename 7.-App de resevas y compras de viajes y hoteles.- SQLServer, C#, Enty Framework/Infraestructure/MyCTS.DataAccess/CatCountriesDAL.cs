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
    public class CatCountriesDAL
    {
        public List<ListItem> GetCountries(string StrToSearch)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatCountriesResource.SP_GetCountries);
            db.AddInParameter(dbCommand, Resources.CatCountriesResource.PARAM_QUERY, DbType.String, StrToSearch);
            List<ListItem> CatCountriesList = new List<ListItem>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _catcouid = dr.GetOrdinal(Resources.CatCountriesResource.PARAM_CATCOUID);
                int _catcouname = dr.GetOrdinal(Resources.CatCountriesResource.PARAM_CATCOUNAME);


                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Value = dr.GetString(_catcouid);
                    item.Text = string.Concat(dr.GetString(_catcouid), ' ', ((dr[_catcouname] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catcouname)));
                    CatCountriesList.Add(item);
                }
            }

            return CatCountriesList;

        }
        public List<ListItem> GetCountries()
        {
            Database dataBase = DatabaseFactory.CreateDatabase(CommonENT.MYCTSDB_CONNECTION);
            DbCommand command = dataBase.GetStoredProcCommand("GetCatalog_CountriesInterJet");
            List<ListItem> result = new List<ListItem>();
            using (IDataReader dataReader = dataBase.ExecuteReader(command))
            {
                int id = dataReader.GetOrdinal(Resources.CatCountriesResource.PARAM_CATCOUID);
                int value = dataReader.GetOrdinal(Resources.CatCountriesResource.PARAM_CATCOUNAME);
                while (dataReader.Read())
                {
                    ListItem newItem = new ListItem();
                    newItem.Text = dataReader.GetString(value);
                    newItem.Value = dataReader.GetString(id);
                    result.Add(newItem);
                }

            }
            return result;

        }
    }
}
