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
     public class AddCorporateCRUDDAL
    {
         public void AddCorporateCRUD(AddCorporateCRUD addCorporateCRUD, string connectionName)
        {
             
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.AddCorporateCRUDResources.SP_ADDTOOLONLINERULES);
            db.AddInParameter(dbcomand, Resources.AddCorporateCRUDResources.PARAM_CORPORATIVE, DbType.String,addCorporateCRUD.Corporative);
            db.AddInParameter(dbcomand, Resources.AddCorporateCRUDResources.PARAM_TOOLONLINE, DbType.String, addCorporateCRUD.ToolOnline);
            db.AddInParameter(dbcomand, Resources.AddCorporateCRUDResources.PARAM_ATTRIBUTE1, DbType.String, addCorporateCRUD.Attribute1);
            db.AddInParameter(dbcomand, Resources.AddCorporateCRUDResources.PARAM_SUPERVISOR, DbType.String, addCorporateCRUD.Supervisor);
            db.AddInParameter(dbcomand, Resources.AddCorporateCRUDResources.PARAM_SUPAGENT, DbType.Int32, addCorporateCRUD.SupAgente);
            db.AddInParameter(dbcomand, Resources.AddCorporateCRUDResources.PARAM_PCC, DbType.String, addCorporateCRUD.PCC);
            db.AddInParameter(dbcomand, Resources.AddCorporateCRUDResources.PARAM_SUPSTATUS, DbType.String, addCorporateCRUD.SupStatus);
            db.AddInParameter(dbcomand, Resources.AddCorporateCRUDResources.PARAM_CONSULTOR1, DbType.String, addCorporateCRUD.Consultores[0].Consultor);
            db.AddInParameter(dbcomand, Resources.AddCorporateCRUDResources.PARAM_CONAGENT1, DbType.Int32,addCorporateCRUD.Consultores[0].Agent);
            db.AddInParameter(dbcomand, Resources.AddCorporateCRUDResources.PARAM_CONPCC1, DbType.String, addCorporateCRUD.Consultores[0].PCC);
            db.AddInParameter(dbcomand, Resources.AddCorporateCRUDResources.PARAM_CONSTATUS1, DbType.String,addCorporateCRUD.Consultores[0].Status);

            db.AddInParameter(dbcomand, Resources.AddCorporateCRUDResources.PARAM_CONSULTOR2, DbType.String,addCorporateCRUD.Consultores[1].Consultor);
            db.AddInParameter(dbcomand, Resources.AddCorporateCRUDResources.PARAM_CONAGENT2, DbType.Int32, addCorporateCRUD.Consultores[1].Agent);
            db.AddInParameter(dbcomand, Resources.AddCorporateCRUDResources.PARAM_CONPCC2, DbType.String, addCorporateCRUD.Consultores[1].PCC);
            db.AddInParameter(dbcomand, Resources.AddCorporateCRUDResources.PARAM_CONSTATUS2, DbType.String, addCorporateCRUD.Consultores[1].Status);

            db.AddInParameter(dbcomand, Resources.AddCorporateCRUDResources.PARAM_CONSULTOR3, DbType.String, addCorporateCRUD.Consultores[2].Consultor);
            db.AddInParameter(dbcomand, Resources.AddCorporateCRUDResources.PARAM_CONAGENT3, DbType.Int32, addCorporateCRUD.Consultores[2].Agent);
            db.AddInParameter(dbcomand, Resources.AddCorporateCRUDResources.PARAM_CONPCC3, DbType.String, addCorporateCRUD.Consultores[2].PCC);
            db.AddInParameter(dbcomand, Resources.AddCorporateCRUDResources.PARAM_CONSTATUS3, DbType.String, addCorporateCRUD.Consultores[2].Status);

            db.AddInParameter(dbcomand, Resources.AddCorporateCRUDResources.PARAM_CONSULTOR4, DbType.String, addCorporateCRUD.Consultores[3].Consultor);
            db.AddInParameter(dbcomand, Resources.AddCorporateCRUDResources.PARAM_CONAGENT4, DbType.Int32, addCorporateCRUD.Consultores[3].Agent);
            db.AddInParameter(dbcomand, Resources.AddCorporateCRUDResources.PARAM_CONPCC4, DbType.String, addCorporateCRUD.Consultores[3].PCC);
            db.AddInParameter(dbcomand, Resources.AddCorporateCRUDResources.PARAM_CONSTATUS4, DbType.String, addCorporateCRUD.Consultores[3].Status);

            db.AddInParameter(dbcomand, Resources.AddCorporateCRUDResources.PARAM_CONSULTOR5, DbType.String, addCorporateCRUD.Consultores[4].Consultor);
            db.AddInParameter(dbcomand, Resources.AddCorporateCRUDResources.PARAM_CONAGENT5, DbType.Int32, addCorporateCRUD.Consultores[4].Agent);
            db.AddInParameter(dbcomand, Resources.AddCorporateCRUDResources.PARAM_CONPCC5, DbType.String, addCorporateCRUD.Consultores[4].PCC);
            db.AddInParameter(dbcomand, Resources.AddCorporateCRUDResources.PARAM_CONSTATUS5, DbType.String, addCorporateCRUD.Consultores[4].Status);

            db.AddInParameter(dbcomand, Resources.AddCorporateCRUDResources.PARAM_FECHAINSERT, DbType.DateTime,addCorporateCRUD.FechaInsert);
            db.AddInParameter(dbcomand, Resources.AddCorporateCRUDResources.PARAM_INSERTBY, DbType.Int32,addCorporateCRUD.InsertBy);
            db.AddInParameter(dbcomand, Resources.AddCorporateCRUDResources.PARAM_FECHAUPDATE, DbType.DateTime, addCorporateCRUD.FechaUpdate);
            db.AddInParameter(dbcomand, Resources.AddCorporateCRUDResources.PARAM_UPDATEBY, DbType.Int32, addCorporateCRUD.UpdateBy);
            db.ExecuteNonQuery(dbcomand);
        }
    }
}
