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
    public class CatFareTypeCodesDAL
    {
        public List<CatFareTypeCodes> GetFareTypeCodes(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatFareTypeCodesResources.SP_GetCatalog_FareTypesCodes);

            List<CatFareTypeCodes> FareTypeCodesList = new List<CatFareTypeCodes>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _value = dr.GetOrdinal(Resources.CatFareTypeCodesResources.PARAM_VALUE);
                int _text = dr.GetOrdinal(Resources.CatFareTypeCodesResources.PARAM_TEXT);
                int _text2 = dr.GetOrdinal(Resources.CatFareTypeCodesResources.PARAM_TEXT2);

                while (dr.Read())
                {
                    CatFareTypeCodes item = new CatFareTypeCodes();
                    item.Value = (dr[_value] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_value);
                    item.Text = (dr[_text] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_text);
                    item.Text2 = (dr[_text2] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_text2);
                    FareTypeCodesList.Add(item);


                }
            }

            return FareTypeCodesList;
        }

    }
}
