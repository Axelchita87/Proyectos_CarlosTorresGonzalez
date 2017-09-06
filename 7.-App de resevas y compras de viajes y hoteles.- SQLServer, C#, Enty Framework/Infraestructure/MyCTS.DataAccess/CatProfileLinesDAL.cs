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
    public class CatProfileLinesDAL
    {
        public List<ListItem> GetProfileLines(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatProfileLinesResources.SP_GetCatProfileLines);

            List<ListItem> ProfileLines_List = new List<ListItem>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _value = dr.GetOrdinal(Resources.CatProfileLinesResources.PARAM_VALUE);
                int _text = dr.GetOrdinal(Resources.CatProfileLinesResources.PARAM_TEXT);
                int _text2 = dr.GetOrdinal(Resources.CatProfileLinesResources.PARAM_TEXT2);
                int _text3 = dr.GetOrdinal(Resources.CatProfileLinesResources.PARAM_TEXT3);

                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Value = (dr[_value] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_value);
                    item.Text = (dr[_text] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_text);
                    item.Text2 = (dr[_text2] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_text2);
                    item.Text3 = (dr[_text3] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_text3);

                    ProfileLines_List.Add(item);
                }
            }


            return ProfileLines_List;
        }
    
    }
}