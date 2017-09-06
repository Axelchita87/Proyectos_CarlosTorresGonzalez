using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Entities;
using System.Data.SqlClient;

namespace MyCTS.DataAccess
{
    public class FieldsDinamicsDAL
    {
        public List<Dynamic> GetStar1Profile(string pcc, string level1, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.FieldsDynamics.SP_GetStar1);
            db.AddInParameter(dbCommand, Resources.FieldsDynamics.PARAM_Pcc, DbType.String, pcc);
            db.AddInParameter(dbCommand, Resources.FieldsDynamics.PARAM_Level1, DbType.String, level1);
            

            var listItem = new List<Dynamic>();
            Dynamic item = null;

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                if (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        item = new Dynamic();

                        item = item.Add(dr.GetName(i), dr.GetValue(i));
                        item.FieldName = dr.GetName(i);

                        listItem.Add(item);
                    }
                }
            }

            return listItem;
        }

        public List<Dynamic> GetStar2Profile(string email, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.FieldsDynamics.GetStar2ByEmail);
            db.AddInParameter(dbCommand, Resources.FieldsDynamics.PARAM_Email, DbType.String, email);

            var listItem = new List<Dynamic>();
            Dynamic item = null;

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                if (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        item = new Dynamic();

                        item = item.Add(dr.GetName(i), dr.GetValue(i));
                        item.FieldName = dr.GetName(i);

                        listItem.Add(item);
                    }
                }
            }

            return listItem;
        }

        public List<Dynamic> GetStar2Profile(string pcc, string level1, string level2, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.FieldsDynamics.SP_GetStar2);
            db.AddInParameter(dbCommand, Resources.FieldsDynamics.PARAM_Pcc, DbType.String, pcc);
            db.AddInParameter(dbCommand, Resources.FieldsDynamics.PARAM_Level1, DbType.String, level1);
            db.AddInParameter(dbCommand, Resources.FieldsDynamics.PARAM_Level2, DbType.String, level2);

            var listItem = new List<Dynamic>();
            Dynamic item = null;

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                if (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        item = new Dynamic();

                        item = item.Add(dr.GetName(i), dr.GetValue(i));
                        item.FieldName = dr.GetName(i);

                        listItem.Add(item);
                    }
                }
            }

            return listItem;
        }

        public void SetOrUpdateStarProfile(List<Dynamic> objListDynamic, int? id, int level, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            
            foreach (var dynamic in objListDynamic)
            {
                string value;
                if(!string.IsNullOrEmpty(dynamic.FieldName)  )
                {
                    var field = dynamic.GetType().GetProperty(dynamic.FieldName).Name;
                    value = dynamic.GetType().GetProperty(dynamic.FieldName).GetValue(dynamic, null) != null ? dynamic.GetType().GetProperty(dynamic.FieldName).GetValue(dynamic, null).ToString() : "";
                    var dbCommand = db.GetStoredProcCommand(Resources.FieldsDynamics.SP_SetOrUpadateStar);
                    db.AddInParameter(dbCommand, Resources.FieldsDynamics.PARAM_Id, DbType.Int32, id);
                    db.AddInParameter(dbCommand, Resources.FieldsDynamics.PARAM_Field, DbType.String, field);
                    db.AddInParameter(dbCommand, Resources.FieldsDynamics.PARAM_Value, DbType.String, value);
                    db.AddInParameter(dbCommand, Resources.FieldsDynamics.PARAM_Level, DbType.String, level);

                    if (id != null)
                        db.ExecuteNonQuery(dbCommand);
                    else
                    {
                        using (IDataReader dr = db.ExecuteReader(dbCommand))
                        {
                            if (dr.Read())
                            id = dr.GetInt32(0);
                        }
                    }
                }
            }
            
        }
    }


}

