using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace MyCTS.DataAccess
{
    public class AddToolOnlineRulesDeleteDAL
    {
        public void AddCorporateDelete(AddToolOnlineRulesDelete addCorporateDelete, string connectionName)
        {

            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.AddToolOnlineRulesDeleteResources.SP_ADDTOOLONLINERULESDELETE);
            db.AddInParameter(dbcomand, Resources.AddToolOnlineRulesDeleteResources.PARAM_CORPORATIVE, DbType.String, addCorporateDelete.Corporative);
            db.AddInParameter(dbcomand, Resources.AddToolOnlineRulesDeleteResources.PARAM_TOOLONLINE, DbType.String, addCorporateDelete.ToolOnline);
            db.AddInParameter(dbcomand, Resources.AddToolOnlineRulesDeleteResources.PARAM_ATTRIBUTE1, DbType.String, addCorporateDelete.Attribute1);
            db.AddInParameter(dbcomand, Resources.AddToolOnlineRulesDeleteResources.PARAM_PCC, DbType.String, addCorporateDelete.PCC);
            db.AddInParameter(dbcomand, Resources.AddToolOnlineRulesDeleteResources.PARAM_SUPERVISOR, DbType.String, addCorporateDelete.Supervisor);
            db.AddInParameter(dbcomand, Resources.AddToolOnlineRulesDeleteResources.PARAM_SUPAGENT, DbType.Int32, addCorporateDelete.SupAgente);
            db.AddInParameter(dbcomand, Resources.AddToolOnlineRulesDeleteResources.PARAM_SUPSTATUS, DbType.String, addCorporateDelete.SupStatus);
            db.AddInParameter(dbcomand, Resources.AddToolOnlineRulesDeleteResources.PARAM_CONSULTOR1, DbType.String, addCorporateDelete.Consultores[0].Consultor);
            db.AddInParameter(dbcomand, Resources.AddToolOnlineRulesDeleteResources.PARAM_CONAGENT1, DbType.Int32, addCorporateDelete.Consultores[0].Agent);
            db.AddInParameter(dbcomand, Resources.AddToolOnlineRulesDeleteResources.PARAM_CONPCC1, DbType.String, addCorporateDelete.Consultores[0].PCC);
            db.AddInParameter(dbcomand, Resources.AddToolOnlineRulesDeleteResources.PARAM_CONSTATUS1, DbType.String, addCorporateDelete.Consultores[0].Status);
            db.AddInParameter(dbcomand, Resources.AddToolOnlineRulesDeleteResources.PARAM_CONSULTOR2, DbType.String, addCorporateDelete.Consultores[1].Consultor);
            db.AddInParameter(dbcomand, Resources.AddToolOnlineRulesDeleteResources.PARAM_CONAGENT2, DbType.Int32, addCorporateDelete.Consultores[1].Agent);
            db.AddInParameter(dbcomand, Resources.AddToolOnlineRulesDeleteResources.PARAM_CONPCC2, DbType.String, addCorporateDelete.Consultores[1].PCC);
            db.AddInParameter(dbcomand, Resources.AddToolOnlineRulesDeleteResources.PARAM_CONSTATUS2, DbType.String, addCorporateDelete.Consultores[1].Status);
            db.AddInParameter(dbcomand, Resources.AddToolOnlineRulesDeleteResources.PARAM_CONSULTOR3, DbType.String, addCorporateDelete.Consultores[2].Consultor);
            db.AddInParameter(dbcomand, Resources.AddToolOnlineRulesDeleteResources.PARAM_CONAGENT3, DbType.Int32, addCorporateDelete.Consultores[2].Agent);
            db.AddInParameter(dbcomand, Resources.AddToolOnlineRulesDeleteResources.PARAM_CONPCC3, DbType.String, addCorporateDelete.Consultores[2].PCC);
            db.AddInParameter(dbcomand, Resources.AddToolOnlineRulesDeleteResources.PARAM_CONSTATUS3, DbType.String, addCorporateDelete.Consultores[2].Status);
            db.AddInParameter(dbcomand, Resources.AddToolOnlineRulesDeleteResources.PARAM_CONSULTOR4, DbType.String, addCorporateDelete.Consultores[3].Consultor);
            db.AddInParameter(dbcomand, Resources.AddToolOnlineRulesDeleteResources.PARAM_CONAGENT4, DbType.Int32, addCorporateDelete.Consultores[3].Agent);
            db.AddInParameter(dbcomand, Resources.AddToolOnlineRulesDeleteResources.PARAM_CONPCC4, DbType.String, addCorporateDelete.Consultores[3].PCC);
            db.AddInParameter(dbcomand, Resources.AddToolOnlineRulesDeleteResources.PARAM_CONSTATUS4, DbType.String, addCorporateDelete.Consultores[3].Status);
            db.AddInParameter(dbcomand, Resources.AddToolOnlineRulesDeleteResources.PARAM_CONSULTOR5, DbType.String, addCorporateDelete.Consultores[4].Consultor);
            db.AddInParameter(dbcomand, Resources.AddToolOnlineRulesDeleteResources.PARAM_CONAGENT5, DbType.Int32, addCorporateDelete.Consultores[4].Agent);
            db.AddInParameter(dbcomand, Resources.AddToolOnlineRulesDeleteResources.PARAM_CONPCC5, DbType.String, addCorporateDelete.Consultores[4].PCC);
            db.AddInParameter(dbcomand, Resources.AddToolOnlineRulesDeleteResources.PARAM_CONSTATUS5, DbType.String, addCorporateDelete.Consultores[4].Status);
            db.AddInParameter(dbcomand, Resources.AddToolOnlineRulesDeleteResources.PARAM_FECHAINSERT, DbType.DateTime, addCorporateDelete.FechaInsert);
            db.AddInParameter(dbcomand, Resources.AddToolOnlineRulesDeleteResources.PARAM_INSERTBY, DbType.Int32, addCorporateDelete.InsertBy);
            db.AddInParameter(dbcomand, Resources.AddToolOnlineRulesDeleteResources.PARAM_FECHAUPDATE, DbType.DateTime, addCorporateDelete.FechaUpdate);
            db.AddInParameter(dbcomand, Resources.AddToolOnlineRulesDeleteResources.PARAM_UPDATEBY, DbType.Int32, addCorporateDelete.UpdateBy);
            db.AddInParameter(dbcomand, Resources.AddToolOnlineRulesDeleteResources.PARAM_FECHADELETE, DbType.DateTime, addCorporateDelete.FechaDelete);
            db.AddInParameter(dbcomand, Resources.AddToolOnlineRulesDeleteResources.PARAM_DELETEBY, DbType.Int32, addCorporateDelete.DeleteBy);
        
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
