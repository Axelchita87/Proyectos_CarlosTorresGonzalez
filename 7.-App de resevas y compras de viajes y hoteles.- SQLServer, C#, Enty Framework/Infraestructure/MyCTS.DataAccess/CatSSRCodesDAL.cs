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
    public class CatSSRCodesDAL
    {
        public List<CatSSRCodes> GetSSRCodes(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatSSRCodesResources.SP_GetCatalog_SSRCodes);

            List<CatSSRCodes> SSRCodesList = new List<CatSSRCodes>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _value = dr.GetOrdinal(Resources.CatSSRCodesResources.PARAM_VALUE);
                int _text = dr.GetOrdinal(Resources.CatSSRCodesResources.PARAM_TEXT);
                int _text2 = dr.GetOrdinal(Resources.CatSSRCodesResources.PARAM_TEXT2);

                while (dr.Read())
                {
                    CatSSRCodes item = new CatSSRCodes();
                    item.Value = (dr[_value] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_value);
                    item.Text = (dr[_text] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_text);
                    item.Text2 = (dr[_text2] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_text2);
                    SSRCodesList.Add(item);


                }
            }

            return SSRCodesList;
        }

    }
}
