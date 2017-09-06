using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

namespace MyCTS.DataAccess
{ 
    public class GetEquipmentCarByCodeDAL
    {
        public string GetEquipmentCarByCode(string code, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetEquipmentCarByCodeResources.SP_GETEQUIPMENTBYCODE);
            db.AddInParameter(dbCommand, Resources.GetEquipmentCarByCodeResources.PARAM_CODE, DbType.String, code);
            string vendCodeName = string.Empty;
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _vendCodeName = dr.GetOrdinal(Resources.GetEquipmentCarByCodeResources.PARAM_EQUIPMENT);
                if (dr.Read())
                {
                    vendCodeName = dr.GetString(_vendCodeName);
                }
            }
            return vendCodeName;
        }
    }
}
