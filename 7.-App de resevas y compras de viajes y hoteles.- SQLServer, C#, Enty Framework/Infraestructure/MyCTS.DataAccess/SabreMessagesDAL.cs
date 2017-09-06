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
    public class SabreMessagesDAL
    {

        public SabreMessages GetSingleSabreMessage(string apiMessage, int moduleId, string connectionName)
        {

            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.SabreMessageResources.SP_GetSingleSabreMessage);

            db.AddInParameter(dbCommand, Resources.SabreMessageResources.PARAM_APIMESSAGE, DbType.String, apiMessage);
            db.AddInParameter(dbCommand, Resources.SabreMessageResources.PARAM_MODULEID, DbType.Int32, moduleId);

            SabreMessages item = null;

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _id = dr.GetOrdinal(Resources.SabreMessageResources.PARAM_ID);
                int _moduleid = dr.GetOrdinal(Resources.SabreMessageResources.PARAM_MODULEID);
                int _apimessage = dr.GetOrdinal(Resources.SabreMessageResources.PARAM_APIMESSAGE);
                int _usermessage = dr.GetOrdinal(Resources.SabreMessageResources.PARAM_USERMESSAGE);
                int _showcontrol = dr.GetOrdinal(Resources.SabreMessageResources.PARAM_SHOWCONTROL);
                int _isconditional = dr.GetOrdinal(Resources.SabreMessageResources.PARAM_ISCONDITIONAL);

                if (dr.Read())
                {
                    item = new SabreMessages();
                    item.ID = dr.GetInt32(_id);
                    item.ModuleID = dr.GetInt32(_moduleid);
                    item.APIMessage = dr.GetString(_apimessage);
                    item.UserMessage = dr.GetString(_usermessage);
                    item.ShowControl = dr.GetBoolean(_showcontrol);
                    item.IsConditional = dr.GetBoolean(_isconditional);
                }
            }

            return item;
 
        }
       
        public List<SabreMessages> GetSabreMessages(int moduleId, bool includeConditionals)
        { 
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.SabreMessageResources.SP_GetSabreMessages);

            db.AddInParameter(dbCommand, Resources.SabreMessageResources.PARAM_MODULEID, DbType.Int32, moduleId);
            db.AddInParameter(dbCommand, Resources.SabreMessageResources.PARAM_INCLUDECONDITIONALS, DbType.Boolean, includeConditionals);

            List<SabreMessages> sabreMessageList = new List<SabreMessages>();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _id = dr.GetOrdinal(Resources.SabreMessageResources.PARAM_ID);
                int _moduleid = dr.GetOrdinal(Resources.SabreMessageResources.PARAM_MODULEID);
                int _apimessage = dr.GetOrdinal(Resources.SabreMessageResources.PARAM_APIMESSAGE);
                int _usermessage = dr.GetOrdinal(Resources.SabreMessageResources.PARAM_USERMESSAGE);
                int _showcontrol = dr.GetOrdinal(Resources.SabreMessageResources.PARAM_SHOWCONTROL);
                int _isconditional = dr.GetOrdinal(Resources.SabreMessageResources.PARAM_ISCONDITIONAL);

                while (dr.Read())
                {
                    SabreMessages item = new SabreMessages();
                    item.ID = dr.GetInt32(_id);
                    item.ModuleID = dr.GetInt32(_moduleid);
                    item.APIMessage = dr.GetString(_apimessage);
                    item.UserMessage = dr.GetString(_usermessage);
                    item.ShowControl = dr.GetBoolean(_showcontrol);
                    item.IsConditional = dr.GetBoolean(_isconditional);
                    sabreMessageList.Add(item);
                }
            }

            return sabreMessageList;
        }
        
    }
}
