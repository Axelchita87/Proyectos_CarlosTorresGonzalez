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
    public class CurrenciesCountriesDAL
    {

        public List<ListItem> GetCurrenciesCountries(string StrToSearch)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CurrenciesCountriesResources.SP_GetCurrenciesCountries);
            db.AddInParameter(dbCommand, Resources.CurrenciesCountriesResources.PARAM_QUERY, DbType.String, StrToSearch);

            List<ListItem> CurrenciesCountriesList = new List<ListItem>();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _catcurcoucode = dr.GetOrdinal(Resources.CurrenciesCountriesResources.PARAM_CATCURCOUCODE);
                int _catcurcouname = dr.GetOrdinal(Resources.CurrenciesCountriesResources.PARAM_CATCURCOUNAME);
                int _catcouname = dr.GetOrdinal(Resources.CurrenciesCountriesResources.PARAM_CATCOUNAME);
                int _catcouid = dr.GetOrdinal(Resources.CurrenciesCountriesResources.PARAM_CATCOUID);

                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Value = dr.GetString(_catcurcoucode);
                    item.Text = string.Concat(dr.GetString(_catcurcoucode), ' ',dr.GetString(_catcurcouname),' ', dr.GetString(_catcouname), ' ' ,dr.GetString(_catcouid)) ;
                    CurrenciesCountriesList.Add(item);
                }
            }

            return CurrenciesCountriesList;
 
        }
    }
}
