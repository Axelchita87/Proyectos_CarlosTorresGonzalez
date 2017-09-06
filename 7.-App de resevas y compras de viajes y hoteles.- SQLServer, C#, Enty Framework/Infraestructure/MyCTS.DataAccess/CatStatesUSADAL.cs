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
    public class CatStatesUSADAL
    {
        public List<ListItem> GetStatesUSA(string StrToSearch, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatStatesUSAResources.SP_GetStatesUSA);
            db.AddInParameter(dbCommand, Resources.CatStatesUSAResources.PARAM_QUERY, DbType.String, StrToSearch);

            List<ListItem> StatesUSAList = new List<ListItem>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _catstausacode = dr.GetOrdinal(Resources.CatStatesUSAResources.PARAM_CATSTAUSACODE);
                int _catstausaname = dr.GetOrdinal(Resources.CatStatesUSAResources.PARAM_CATSTAUSANAME);

                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Value = (dr[_catstausacode] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catstausacode);
                    item.Text = string.Concat(((dr[_catstausacode] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catstausacode)), ' ',
                    ((dr[_catstausaname] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catstausaname)));
                    StatesUSAList.Add(item);


                }
            }

            return StatesUSAList;
        }

        public List<CatStatesUSA> GetStateUSA()
        {
            try
            {
                Database dataBase = DatabaseFactory.CreateDatabase(CommonENT.MYCTSDB_CONNECTION);
                DbCommand dbCommand = dataBase.GetStoredProcCommand("GetCatalog_StatesUSAInterjet");
                List<CatStatesUSA> states = new List<CatStatesUSA>();
                using (IDataReader dataReader = dataBase.ExecuteReader(dbCommand))
                {
                    int _catstausacode = dataReader.GetOrdinal(Resources.CatStatesUSAResources.PARAM_CATSTAUSACODE);
                    int _catstausaname = dataReader.GetOrdinal(Resources.CatStatesUSAResources.PARAM_CATSTAUSANAME);
                    while (dataReader.Read())
                    {
                        CatStatesUSA state = new CatStatesUSA();
                        state.CatStaUSACode = dataReader.GetString(_catstausacode);
                        state.CatStaUSAName = dataReader.GetString(_catstausaname);
                        states.Add(state);

                    }


                }
                return states;
            }catch(Exception ex)
            {
                return new List<CatStatesUSA>();
            }
        }
    }
}
