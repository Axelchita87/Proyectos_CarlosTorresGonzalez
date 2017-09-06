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
    public class DeactivatedStarsDAL
    {
        public List<DeactivatedStar> GetDeactivatedStars(string dk, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.DeactivatedStarsResources.SP_GetDeactivatedStars);
            db.AddInParameter(dbCommand, Resources.DeactivatedStarsResources.PARAM_QUERY_DK, DbType.String, dk);
            
            List<DeactivatedStar> deactivatedStarList=new List<DeactivatedStar>();
            try
            {
                using (IDataReader dr = db.ExecuteReader(dbCommand))
                {
                    int _level1 = dr.GetOrdinal(Resources.DeactivatedStarsResources.PARAM_LEVEL1);
                    int _pcc = dr.GetOrdinal(Resources.DeactivatedStarsResources.PARAM_PCC);

                    while (dr.Read())
                    {
                        DeactivatedStar item = new DeactivatedStar();
                        item.Name = (dr[_level1] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_level1);
                        item.Pcc = (dr[_pcc] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_pcc);
                        item.Lines = GetLines(connectionName, item.Name, item.Pcc);
                        deactivatedStarList.Add(item);
                    }
                }
            }
            catch { }

            return deactivatedStarList;
        }


        private List<string> GetLines(string connectionName, string level1, string pcc)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.DeactivatedStarsResources.SP_GetLinesDeactivatedStars);
            db.AddInParameter(dbCommand, Resources.DeactivatedStarsResources.PARAM_QUERY_LEVEL1, DbType.String, level1);
            db.AddInParameter(dbCommand, Resources.DeactivatedStarsResources.PARAM_QUERY_PCC, DbType.String, pcc);
            List<string> lines = new List<string>();
            lines.Add("Perfil "+ level1+ " " + pcc);
            try
            {
                using (IDataReader dr = db.ExecuteReader(dbCommand))
                {
                    int _line = dr.GetOrdinal(Resources.DeactivatedStarsResources.PARAM_TEXT);

                    while (dr.Read())
                    {
                        string line = (dr[_line] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_line); ;

                        lines.Add(line);
                    }
                }
            }
            catch { }
            lines.Add("End");
            lines.Add("-----------------------");

            return lines; 
        }


        public List<string> GetLinesSecondLevel(string name, string level1,  string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.DeactivatedStarsResources.SP_GetDeactivatedStarSecondLevel);
            db.AddInParameter(dbCommand, Resources.DeactivatedStarsResources.PARAM_QUERY_NAME, DbType.String, name);
            db.AddInParameter(dbCommand, Resources.DeactivatedStarsResources.PARAM_QUERY_LEVEL1, DbType.String, level1);
            List<string> lines = new List<string>();
            lines.Add("Perfil " + name);
            try
            {
                using (IDataReader dr = db.ExecuteReader(dbCommand))
                {
                    int _line = dr.GetOrdinal(Resources.DeactivatedStarsResources.PARAM_TEXT);

                    while (dr.Read())
                    {
                        string line = (dr[_line] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_line); ;

                        lines.Add(line);
                    }
                }
            }
            catch { }
            lines.Add("End");
            lines.Add("-----------------------");

            return lines;
        }


        

    }
}
