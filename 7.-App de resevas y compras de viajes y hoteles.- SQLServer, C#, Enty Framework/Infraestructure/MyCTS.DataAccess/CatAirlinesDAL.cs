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
    public class CatAirlinesDAL
    {
        public List<CatAirlines> GetAirlines(string StrToSearch, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatAirLinesResource.SP_GetAirLines);
            db.AddInParameter(dbCommand, Resources.CatAirLinesResource.PARAM_QUERY, DbType.String, StrToSearch);
           
            List<CatAirlines> AirlinesList = new List<CatAirlines>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _catairlinalfaid = dr.GetOrdinal(Resources.CatAirLinesResource.PARAM_CATAIRLINALFAID);
                int _catairlinname = dr.GetOrdinal(Resources.CatAirLinesResource.PARAM_CATAIRLINNAME);

                while (dr.Read())
                {
                    CatAirlines item = new CatAirlines();
                    item.CatAirLinAlfaId = dr.GetString(_catairlinalfaid);
                    item.CatAirLinName = (dr[_catairlinname] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catairlinname);
                    AirlinesList.Add(item);


                }
            }

            return AirlinesList;
        }

        public List<ListItem> GetAirLines_Predictive(string StrToSearch)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetAirLines_Predictive");
            db.AddInParameter(dbCommand, Resources.CatAirLinesResource.PARAM_QUERY, DbType.String, StrToSearch);

            List<ListItem> AirlinesList = new List<ListItem>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _catairlinalfaid = dr.GetOrdinal(Resources.CatAirLinesResource.PARAM_CATAIRLINALFAID);
                int _catairlinname = dr.GetOrdinal(Resources.CatAirLinesResource.PARAM_CATAIRLINNAME);

                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Value = dr.GetString(_catairlinalfaid);
                    item.Text = string.Concat(dr.GetString(_catairlinalfaid), ' ',
                        (dr[_catairlinname] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catairlinname));
                    AirlinesList.Add(item);


                }
            }

            return AirlinesList;
        }
    }
}
