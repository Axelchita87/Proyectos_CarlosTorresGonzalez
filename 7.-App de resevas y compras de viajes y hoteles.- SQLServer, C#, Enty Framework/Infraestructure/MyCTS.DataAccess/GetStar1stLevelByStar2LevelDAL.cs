using System;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MyCTS.DataAccess
{
    public class GetStar1stLevelByStar2LevelDAL
    {
        public Boolean GetStar1stLevelByStar2Level(string level1, string pcc, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetStar1stLevelByStar2LevelResources.Sp_GetStar1stLevelByStar2Level);
            db.AddInParameter(dbCommand, Resources.GetStar1stLevelByStar2LevelResources.PARAM_LEVEL1, DbType.String, level1);
            db.AddInParameter(dbCommand, Resources.GetStar1stLevelByStar2LevelResources.PARAM_PCC, DbType.String, pcc);

            bool isNew = false;

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _isNew = dr.GetOrdinal(Resources.GetStar1stLevelByStar2LevelResources.PARAM_IS_NEW);
                if (dr.Read())
                {
                    isNew = (dr[_isNew] == DBNull.Value) ? false : dr.GetBoolean(_isNew);
                }
            }

            return isNew;
        }
    }
}
