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
    public class UpdateCorporateCRUDDAL
    {
        public void UpdateCorporateCRUD(UpdateCorporateCRUD updateCorporateCRUD, string connectionName)
        {

            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.UpdateCorporateCRUDResources.SP_UPDATETOOLONLINERULES);
            db.AddInParameter(dbcomand, Resources.UpdateCorporateCRUDResources.PARAM_CORPORATIVE, DbType.String, updateCorporateCRUD.Corporative);
            db.AddInParameter(dbcomand, Resources.UpdateCorporateCRUDResources.PARAM_TOOLONLINE, DbType.String, updateCorporateCRUD.ToolOnline);
            db.AddInParameter(dbcomand, Resources.UpdateCorporateCRUDResources.PARAM_ATTRIBUTE1, DbType.String, updateCorporateCRUD.Attribute1);
            db.AddInParameter(dbcomand, Resources.UpdateCorporateCRUDResources.PARAM_SUPERVISOR, DbType.String, updateCorporateCRUD.Supervisor);
            db.AddInParameter(dbcomand, Resources.UpdateCorporateCRUDResources.PARAM_SUPAGENT, DbType.Int32, updateCorporateCRUD.SupAgente);
            db.AddInParameter(dbcomand, Resources.UpdateCorporateCRUDResources.PARAM_PCC, DbType.String, updateCorporateCRUD.PCC);
            db.AddInParameter(dbcomand, Resources.UpdateCorporateCRUDResources.PARAM_SUPSTATUS, DbType.String, updateCorporateCRUD.SupStatus);
            db.AddInParameter(dbcomand, Resources.UpdateCorporateCRUDResources.PARAM_CONSULTOR1, DbType.String, updateCorporateCRUD.Consultores[0].Consultor);
            db.AddInParameter(dbcomand, Resources.UpdateCorporateCRUDResources.PARAM_CONAGENT1, DbType.Int32, updateCorporateCRUD.Consultores[0].Agent);
            db.AddInParameter(dbcomand, Resources.UpdateCorporateCRUDResources.PARAM_CONPCC1, DbType.String, updateCorporateCRUD.Consultores[0].PCC);
            db.AddInParameter(dbcomand, Resources.UpdateCorporateCRUDResources.PARAM_CONSTATUS1, DbType.String, updateCorporateCRUD.Consultores[0].Status);

            db.AddInParameter(dbcomand, Resources.UpdateCorporateCRUDResources.PARAM_CONSULTOR2, DbType.String, updateCorporateCRUD.Consultores[1].Consultor);
            db.AddInParameter(dbcomand, Resources.UpdateCorporateCRUDResources.PARAM_CONAGENT2, DbType.Int32, updateCorporateCRUD.Consultores[1].Agent);
            db.AddInParameter(dbcomand, Resources.UpdateCorporateCRUDResources.PARAM_CONPCC2, DbType.String, updateCorporateCRUD.Consultores[1].PCC);
            db.AddInParameter(dbcomand, Resources.UpdateCorporateCRUDResources.PARAM_CONSTATUS2, DbType.String, updateCorporateCRUD.Consultores[1].Status);

            db.AddInParameter(dbcomand, Resources.UpdateCorporateCRUDResources.PARAM_CONSULTOR3, DbType.String, updateCorporateCRUD.Consultores[2].Consultor);
            db.AddInParameter(dbcomand, Resources.UpdateCorporateCRUDResources.PARAM_CONAGENT3, DbType.Int32, updateCorporateCRUD.Consultores[2].Agent);
            db.AddInParameter(dbcomand, Resources.UpdateCorporateCRUDResources.PARAM_CONPCC3, DbType.String, updateCorporateCRUD.Consultores[2].PCC);
            db.AddInParameter(dbcomand, Resources.UpdateCorporateCRUDResources.PARAM_CONSTATUS3, DbType.String, updateCorporateCRUD.Consultores[2].Status);

            db.AddInParameter(dbcomand, Resources.UpdateCorporateCRUDResources.PARAM_CONSULTOR4, DbType.String, updateCorporateCRUD.Consultores[3].Consultor);
            db.AddInParameter(dbcomand, Resources.UpdateCorporateCRUDResources.PARAM_CONAGENT4, DbType.Int32, updateCorporateCRUD.Consultores[3].Agent);
            db.AddInParameter(dbcomand, Resources.UpdateCorporateCRUDResources.PARAM_CONPCC4, DbType.String, updateCorporateCRUD.Consultores[3].PCC);
            db.AddInParameter(dbcomand, Resources.UpdateCorporateCRUDResources.PARAM_CONSTATUS4, DbType.String, updateCorporateCRUD.Consultores[3].Status);

            db.AddInParameter(dbcomand, Resources.UpdateCorporateCRUDResources.PARAM_CONSULTOR5, DbType.String, updateCorporateCRUD.Consultores[4].Consultor);
            db.AddInParameter(dbcomand, Resources.UpdateCorporateCRUDResources.PARAM_CONAGENT5, DbType.Int32, updateCorporateCRUD.Consultores[4].Agent);
            db.AddInParameter(dbcomand, Resources.UpdateCorporateCRUDResources.PARAM_CONPCC5, DbType.String, updateCorporateCRUD.Consultores[4].PCC);
            db.AddInParameter(dbcomand, Resources.UpdateCorporateCRUDResources.PARAM_CONSTATUS5, DbType.String, updateCorporateCRUD.Consultores[4].Status);

            db.AddInParameter(dbcomand, Resources.UpdateCorporateCRUDResources.PARAM_FECHAINSERT, DbType.DateTime, updateCorporateCRUD.FechaInsert);
            db.AddInParameter(dbcomand, Resources.UpdateCorporateCRUDResources.PARAM_INSERTBY, DbType.Int32, updateCorporateCRUD.InsertBy);
            db.AddInParameter(dbcomand, Resources.UpdateCorporateCRUDResources.PARAM_FECHAUPDATE, DbType.DateTime, updateCorporateCRUD.FechaUpdate);
            db.AddInParameter(dbcomand, Resources.UpdateCorporateCRUDResources.PARAM_UPDATEBY, DbType.Int32, updateCorporateCRUD.UpdateBy);
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
