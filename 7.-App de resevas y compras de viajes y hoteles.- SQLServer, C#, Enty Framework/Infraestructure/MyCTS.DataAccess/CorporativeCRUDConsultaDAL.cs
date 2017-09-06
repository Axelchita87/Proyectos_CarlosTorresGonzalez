using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Components.NullableHelper;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace MyCTS.DataAccess
{
    public class CorporativeCRUDConsultaDAL
    {
        public List<CorporativeCRUDConsulta> ReportCorporateConsulting(string attribute1, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.CorporativeCRUDConsultaResources.SP_Get_ToolOnlineRules);
            db.AddInParameter(dbcomand, Resources.CorporativeCRUDConsultaResources.PARAM_QUERY, DbType.String, attribute1);
            db.ExecuteNonQuery(dbcomand);
            List<CorporativeCRUDConsulta> listCorporativeCRUD = new List<CorporativeCRUDConsulta>();

            using (IDataReader dr = db.ExecuteReader(dbcomand))
            {

                int _Corporative = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CORPORATIVE);
                int _ToolOnline = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_TOOLONLINE);
                int _Attribute1 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_ATTRIBUTE1);
                int _Supervisor = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_SUPERVISOR);
                int _SupAgente = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_SUPAGENT);
                int _PCC = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_PCC);
                int _SupStatus = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_SUPSTATUS);
                int _Consultor1 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSULTOR1);
                int _ConAgent1 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONAGENT1);
                int _PCC1 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_PCC1);
                int _ConStatus1 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSTATUS1);
                int _Consultor2 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSULTOR2);
                int _ConAgent2 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONAGENT2);
                int _PCC2 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_PCC2);
                int _ConStatus2 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSTATUS2);
                int _Consultor3 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSULTOR3);
                int _ConAgent3 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONAGENT3);
                int _PCC3 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_PCC3);
                int _ConStatus3 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSTATUS3);
                int _Consultor4 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSULTOR4);
                int _ConAgent4 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONAGENT4);
                int _PCC4 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_PCC4);
                int _ConStatus4 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSTATUS4);
                int _Consultor5 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSULTOR5);
                int _ConAgent5 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONAGENT5);
                int _PCC5 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_PCC5);
                int _ConStatus5 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSTATUS5);
                int _FechaInsert = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_FECHAINSERT);
                int _InsertBy = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_INSERTBY);
                int _FechaUpdate = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_FECHAUPDATE);
                int _UpdateBy = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_UPDATEBY);

                while (dr.Read())
                {
                    CorporativeCRUDConsulta item = new CorporativeCRUDConsulta();
                    item.Corporative = (dr[_Corporative] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_Corporative));
                    item.ToolOnline = (dr[_ToolOnline] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_ToolOnline));
                    item.Attribute1 = (dr[_Attribute1] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_Attribute1));
                    item.Supervisor = (dr[_Supervisor] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_Supervisor));
                    item.SupAgente = (dr[_SupAgente] == DBNull.Value) ? Types.IntegerNullValue : (dr.GetInt32(_SupAgente));
                    item.PCC = (dr[_PCC] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_PCC));
                    item.SupStatus = (dr[_SupStatus] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_SupStatus));
                    item.Consultor1 = (dr[_Consultor1] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_Consultor1));
                    item.ConAgent1 = (dr[_ConAgent1] == DBNull.Value) ? Types.IntegerNullValue : (dr.GetInt32(_ConAgent1));
                    item.PCC1 = (dr[_PCC1] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_PCC1));
                    item.ConStatus1 = (dr[_ConStatus1] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_ConStatus1));
                    item.Consultor2 = (dr[_Consultor2] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_Consultor2));
                    item.ConAgent2 = (dr[_ConAgent2] == DBNull.Value) ? Types.IntegerNullValue : (dr.GetInt32(_ConAgent2));
                    item.PCC2 = (dr[_PCC2] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_PCC2));
                    item.ConStatus2 = (dr[_ConStatus2] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_ConStatus2));
                    item.Consultor3 = (dr[_Consultor3] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_Consultor3));
                    item.ConAgent3 = (dr[_ConAgent3] == DBNull.Value) ? Types.IntegerNullValue : (dr.GetInt32(_ConAgent3));
                    item.PCC3 = (dr[_PCC3] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_PCC3));
                    item.ConStatus3 = (dr[_ConStatus3] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_ConStatus3));
                    item.Consultor4 = (dr[_Consultor4] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_Consultor4));
                    item.ConAgent4 = (dr[_ConAgent4] == DBNull.Value) ? Types.IntegerNullValue : (dr.GetInt32(_ConAgent4));
                    item.PCC4 = (dr[_PCC4] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_PCC4));
                    item.ConStatus4 = (dr[_ConStatus4] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_ConStatus4));
                    item.Consultor5 = (dr[_Consultor5] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_Consultor5));
                    item.ConAgent5 = (dr[_ConAgent5] == DBNull.Value) ? Types.IntegerNullValue : (dr.GetInt32(_ConAgent5));
                    item.PCC5 = (dr[_PCC5] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_PCC5));
                    item.ConStatus5 = (dr[_ConStatus5] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_ConStatus5));
                    item.FechaInsert = (dr[_FechaInsert] == DBNull.Value) ? Types.DateNullValue : (dr.GetDateTime(_FechaInsert));
                    item.InsertBy = (dr[_InsertBy] == DBNull.Value) ? Types.IntegerNullValue : (dr.GetInt32(_InsertBy));
                    item.FechaUpdate = (dr[_FechaUpdate] == DBNull.Value) ? Types.DateNullValue : (dr.GetDateTime(_FechaUpdate));
                    item.UpdateBy = (dr[_UpdateBy] == DBNull.Value) ? Types.IntegerNullValue : (dr.GetInt32(_UpdateBy));

                    listCorporativeCRUD.Add(item);
                }
            }
            return listCorporativeCRUD;
        }

        public List<CorporativeCRUDConsulta> ReportCorporateConsulting(int firm, string attribute1, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.CorporativeCRUDConsultaResources.SP_ConsultaCorporativePorAgente);
            db.AddInParameter(dbcomand, Resources.CorporativeCRUDConsultaResources.PARAM_QUERY2, DbType.String, firm);
            db.AddInParameter(dbcomand, Resources.CorporativeCRUDConsultaResources.PARAM_QUERY3, DbType.String, attribute1);

            db.ExecuteNonQuery(dbcomand); 
            List<CorporativeCRUDConsulta> listCorporativeCRUD = new List<CorporativeCRUDConsulta>();
            using (IDataReader dr = db.ExecuteReader(dbcomand))
            {

                int _Corporative = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CORPORATIVE);
                int _ToolOnline = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_TOOLONLINE);
                int _Attribute1 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_ATTRIBUTE1);
                int _Supervisor = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_SUPERVISOR);
                int _SupAgente = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_SUPAGENT);
                int _PCC = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_PCC);
                int _SupStatus = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_SUPSTATUS);
                int _Consultor1 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSULTOR1);
                int _ConAgent1 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONAGENT1);
                int _PCC1 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_PCC1);
                int _ConStatus1 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSTATUS1);
                int _Consultor2 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSULTOR2);
                int _ConAgent2 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONAGENT2);
                int _PCC2 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_PCC2);
                int _ConStatus2 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSTATUS2);
                int _Consultor3 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSULTOR3);
                int _ConAgent3 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONAGENT3);
                int _PCC3 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_PCC3);
                int _ConStatus3 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSTATUS3);
                int _Consultor4 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSULTOR4);
                int _ConAgent4 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONAGENT4);
                int _PCC4 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_PCC4);
                int _ConStatus4 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSTATUS4);
                int _Consultor5 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSULTOR5);
                int _ConAgent5 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONAGENT5);
                int _PCC5 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_PCC5);
                int _ConStatus5 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSTATUS5);
                int _FechaInsert = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_FECHAINSERT);
                int _InsertBy = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_INSERTBY);
                int _FechaUpdate = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_FECHAUPDATE);
                int _UpdateBy = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_UPDATEBY);

                while (dr.Read())
                {
                    CorporativeCRUDConsulta item = new CorporativeCRUDConsulta();
                    item.Corporative = (dr[_Corporative] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_Corporative));
                    item.ToolOnline = (dr[_ToolOnline] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_ToolOnline));
                    item.Attribute1 = (dr[_Attribute1] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_Attribute1));
                    item.Supervisor = (dr[_Supervisor] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_Supervisor));
                    item.SupAgente = (dr[_SupAgente] == DBNull.Value) ? Types.IntegerNullValue : (dr.GetInt32(_SupAgente));
                    item.PCC = (dr[_PCC] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_PCC));
                    item.SupStatus = (dr[_SupStatus] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_SupStatus));
                    item.Consultor1 = (dr[_Consultor1] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_Consultor1));
                    item.ConAgent1 = (dr[_ConAgent1] == DBNull.Value) ? Types.IntegerNullValue : (dr.GetInt32(_ConAgent1));
                    item.PCC1 = (dr[_PCC1] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_PCC1));
                    item.ConStatus1 = (dr[_ConStatus1] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_ConStatus1));
                    item.Consultor2 = (dr[_Consultor2] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_Consultor2));
                    item.ConAgent2 = (dr[_ConAgent2] == DBNull.Value) ? Types.IntegerNullValue : (dr.GetInt32(_ConAgent2));
                    item.PCC2 = (dr[_PCC2] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_PCC2));
                    item.ConStatus2 = (dr[_ConStatus2] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_ConStatus2));
                    item.Consultor3 = (dr[_Consultor3] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_Consultor3));
                    item.ConAgent3 = (dr[_ConAgent3] == DBNull.Value) ? Types.IntegerNullValue : (dr.GetInt32(_ConAgent3));
                    item.PCC3 = (dr[_PCC3] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_PCC3));
                    item.ConStatus3 = (dr[_ConStatus3] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_ConStatus3));
                    item.Consultor4 = (dr[_Consultor4] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_Consultor4));
                    item.ConAgent4 = (dr[_ConAgent4] == DBNull.Value) ? Types.IntegerNullValue : (dr.GetInt32(_ConAgent4));
                    item.PCC4 = (dr[_PCC4] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_PCC4));
                    item.ConStatus4 = (dr[_ConStatus4] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_ConStatus4));
                    item.Consultor5 = (dr[_Consultor5] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_Consultor5));
                    item.ConAgent5 = (dr[_ConAgent5] == DBNull.Value) ? Types.IntegerNullValue : (dr.GetInt32(_ConAgent5));
                    item.PCC5 = (dr[_PCC5] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_PCC5));
                    item.ConStatus5 = (dr[_ConStatus5] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_ConStatus5));
                    item.FechaInsert = (dr[_FechaInsert] == DBNull.Value) ? Types.DateNullValue : (dr.GetDateTime(_FechaInsert));
                    item.InsertBy = (dr[_InsertBy] == DBNull.Value) ? Types.IntegerNullValue : (dr.GetInt32(_InsertBy));
                    item.FechaUpdate = (dr[_FechaUpdate] == DBNull.Value) ? Types.DateNullValue : (dr.GetDateTime(_FechaUpdate));
                    item.UpdateBy = (dr[_UpdateBy] == DBNull.Value) ? Types.IntegerNullValue : (dr.GetInt32(_UpdateBy));

                    listCorporativeCRUD.Add(item);
                }
            }
            return listCorporativeCRUD;
        }

        public List<CorporativeConsultaGrid> ReportCorporateConsulting(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.CorporativeCRUDConsultaResources.SP_AllGetToolOnlineRules);
            db.ExecuteNonQuery(dbcomand);
            List<CorporativeConsultaGrid> listCorporativeCRUD = new List<CorporativeConsultaGrid>();

            using (IDataReader dr = db.ExecuteReader(dbcomand))
            {
                int _Corporative = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CORPORATIVE);
                int _ToolOnline = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_TOOLONLINE);
                int _Attribute1 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_ATTRIBUTE1);
                int _Supervisor = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_SUPERVISOR);
                int _SupAgente = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_SUPAGENT);
                int _PCC = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_PCC);
                int _SupStatus = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_SUPSTATUS);
                int _Consultor1 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSULTOR1);
                int _ConAgent1 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONAGENT1);
                int _PCC1 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_PCC1);
                int _ConStatus1 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSTATUS1);
                int _Consultor2 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSULTOR2);
                int _ConAgent2 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONAGENT2);
                int _PCC2 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_PCC2);
                int _ConStatus2 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSTATUS2);
                int _Consultor3 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSULTOR3);
                int _ConAgent3 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONAGENT3);
                int _PCC3 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_PCC3);
                int _ConStatus3 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSTATUS3);
                int _Consultor4 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSULTOR4);
                int _ConAgent4 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONAGENT4);
                int _PCC4 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_PCC4);
                int _ConStatus4 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSTATUS4);
                int _Consultor5 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSULTOR5);
                int _ConAgent5 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONAGENT5);
                int _PCC5 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_PCC5);
                int _ConStatus5 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSTATUS5);

                while (dr.Read())
                {
                    CorporativeConsultaGrid item = new CorporativeConsultaGrid();
                    item.Corporative = (dr[_Corporative] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_Corporative));
                    item.ToolOnline = (dr[_ToolOnline] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_ToolOnline));
                    item.Attribute1 = (dr[_Attribute1] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_Attribute1));
                    item.Supervisor = (dr[_Supervisor] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_Supervisor));
                    item.SupAgente = (dr[_SupAgente] == DBNull.Value) ? Types.IntegerNullValue : (dr.GetInt32(_SupAgente));
                    item.PCC = (dr[_PCC] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_PCC));
                    item.SupStatus = (dr[_SupStatus] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_SupStatus));
                    item.Consultor1 = (dr[_Consultor1] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_Consultor1));
                    item.ConAgent1 = (dr[_ConAgent1] == DBNull.Value) ? (int?)null : (dr.GetInt32(_ConAgent1));
                    item.PCC1 = (dr[_PCC1] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_PCC1));
                    item.ConStatus1 = (dr[_ConStatus1] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_ConStatus1));
                    item.Consultor2 = (dr[_Consultor2] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_Consultor2));
                    item.ConAgent2 = (dr[_ConAgent2] == DBNull.Value) ? (int?)null : (dr.GetInt32(_ConAgent2));
                    item.PCC2 = (dr[_PCC2] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_PCC2));
                    item.ConStatus2 = (dr[_ConStatus2] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_ConStatus2));
                    item.Consultor3 = (dr[_Consultor3] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_Consultor3));
                    item.ConAgent3 = (dr[_ConAgent3] == DBNull.Value) ? (int?)null : (dr.GetInt32(_ConAgent3));
                    item.PCC3 = (dr[_PCC3] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_PCC3));
                    item.ConStatus3 = (dr[_ConStatus3] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_ConStatus3));
                    item.Consultor4 = (dr[_Consultor4] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_Consultor4));
                    item.ConAgent4 = (dr[_ConAgent4] == DBNull.Value) ? (int?)null : (dr.GetInt32(_ConAgent4));
                    item.PCC4 = (dr[_PCC4] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_PCC4));
                    item.ConStatus4 = (dr[_ConStatus4] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_ConStatus4));
                    item.Consultor5 = (dr[_Consultor5] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_Consultor5));
                    item.ConAgent5 = (dr[_ConAgent5] == DBNull.Value) ? (int?)null : (dr.GetInt32(_ConAgent5));
                    item.PCC5 = (dr[_PCC5] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_PCC5));
                    item.ConStatus5 = (dr[_ConStatus5] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_ConStatus5));

                    listCorporativeCRUD.Add(item);
                }
            }
            return listCorporativeCRUD;
        }

        public List<CorporativeConsultaGrid> ReportCorporateConsultingGrid(int firm, string grid, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.CorporativeCRUDConsultaResources.SP_ConsultaCorporativePorAgente_Firma);
                        db.AddInParameter(dbcomand, Resources.CorporativeCRUDConsultaResources.PARAM_QUERY2, DbType.String, firm);

            db.ExecuteNonQuery(dbcomand);
            List<CorporativeConsultaGrid> listCorporativeCRUD = new List<CorporativeConsultaGrid>();

            using (IDataReader dr = db.ExecuteReader(dbcomand))
            {
                int _Corporative = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CORPORATIVE);
                int _ToolOnline = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_TOOLONLINE);
                int _Attribute1 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_ATTRIBUTE1);
                int _Supervisor = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_SUPERVISOR);
                int _SupAgente = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_SUPAGENT);
                int _PCC = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_PCC);
                int _SupStatus = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_SUPSTATUS);
                int _Consultor1 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSULTOR1);
                int _ConAgent1 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONAGENT1);
                int _PCC1 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_PCC1);
                int _ConStatus1 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSTATUS1);
                int _Consultor2 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSULTOR2);
                int _ConAgent2 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONAGENT2);
                int _PCC2 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_PCC2);
                int _ConStatus2 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSTATUS2);
                int _Consultor3 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSULTOR3);
                int _ConAgent3 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONAGENT3);
                int _PCC3 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_PCC3);
                int _ConStatus3 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSTATUS3);
                int _Consultor4 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSULTOR4);
                int _ConAgent4 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONAGENT4);
                int _PCC4 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_PCC4);
                int _ConStatus4 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSTATUS4);
                int _Consultor5 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSULTOR5);
                int _ConAgent5 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONAGENT5);
                int _PCC5 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_PCC5);
                int _ConStatus5 = dr.GetOrdinal(Resources.CorporativeCRUDConsultaResources.PARAM_CONSTATUS5);


                while (dr.Read())
                {
                    CorporativeConsultaGrid item = new CorporativeConsultaGrid();
                    item.Corporative = (dr[_Corporative] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_Corporative));
                    item.ToolOnline = (dr[_ToolOnline] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_ToolOnline));
                    item.Attribute1 = (dr[_Attribute1] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_Attribute1));
                    item.Supervisor = (dr[_Supervisor] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_Supervisor));
                    item.SupAgente = (dr[_SupAgente] == DBNull.Value) ? Types.IntegerNullValue : (dr.GetInt32(_SupAgente));
                    item.PCC = (dr[_PCC] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_PCC));
                    item.SupStatus = (dr[_SupStatus] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_SupStatus));
                    item.Consultor1 = (dr[_Consultor1] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_Consultor1));
                    item.ConAgent1 = (dr[_ConAgent1] == DBNull.Value) ? (int?)null : (dr.GetInt32(_ConAgent1));
                    item.PCC1 = (dr[_PCC1] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_PCC1));
                    item.ConStatus1 = (dr[_ConStatus1] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_ConStatus1));
                    item.Consultor2 = (dr[_Consultor2] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_Consultor2));
                    item.ConAgent2 = (dr[_ConAgent2] == DBNull.Value) ? (int?)null : (dr.GetInt32(_ConAgent2));
                    item.PCC2 = (dr[_PCC2] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_PCC2));
                    item.ConStatus2 = (dr[_ConStatus2] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_ConStatus2));
                    item.Consultor3 = (dr[_Consultor3] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_Consultor3));
                    item.ConAgent3 = (dr[_ConAgent3] == DBNull.Value) ? (int?)null : (dr.GetInt32(_ConAgent3));
                    item.PCC3 = (dr[_PCC3] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_PCC3));
                    item.ConStatus3 = (dr[_ConStatus3] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_ConStatus3));
                    item.Consultor4 = (dr[_Consultor4] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_Consultor4));
                    item.ConAgent4 = (dr[_ConAgent4] == DBNull.Value) ? (int?)null : (dr.GetInt32(_ConAgent4));
                    item.PCC4 = (dr[_PCC4] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_PCC4));
                    item.ConStatus4 = (dr[_ConStatus4] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_ConStatus4));
                    item.Consultor5 = (dr[_Consultor5] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_Consultor5));
                    item.ConAgent5 = (dr[_ConAgent5] == DBNull.Value) ? (int?)null : (dr.GetInt32(_ConAgent5));
                    item.PCC5 = (dr[_PCC5] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_PCC5));
                    item.ConStatus5 = (dr[_ConStatus5] == DBNull.Value) ? Types.StringNullValue : (dr.GetString(_ConStatus5));


                    listCorporativeCRUD.Add(item);
                }
            }
            return listCorporativeCRUD;
        }
    }
}
