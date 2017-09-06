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
    public class ImpuestosBajoCostoDAL
    {
        public void InsertImpuestosBajoCosto(string id ,string impuestosObtenidos, string pnrBajoCosto, string impuestosMostrados,
            string lineaContable,string pnrSabre, string connectionName)
        {
            ImpuestosBajoCosto.FechaCreacion= DateTime.Now;
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcommand = db.GetStoredProcCommand("InsertImpuestoBajoCosto");
            db.AddInParameter(dbcommand, "@Id", DbType.String, id);
            db.AddInParameter(dbcommand, "@ImpuestosObtenidos", DbType.String, impuestosObtenidos);
            db.AddInParameter(dbcommand, "@PNRBajoCosto", DbType.String, pnrBajoCosto);
            db.AddInParameter(dbcommand, "@ImpuestosMostrados", DbType.String, impuestosMostrados);
            db.AddInParameter(dbcommand, "@LineaContable", DbType.String, lineaContable);
            db.AddInParameter(dbcommand, "@PNRSabre", DbType.String, pnrSabre);
            db.AddInParameter(dbcommand, "@Fecha_Creacion", DbType.DateTime, ImpuestosBajoCosto.FechaCreacion);
            try
            {
                db.ExecuteReader(dbcommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateImpuestosBajoCosto(string id, string impuestosObtenidos, string pnrBajoCosto, string impuestosMostrados,
            string lineaContable, string pnrSabre, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcommand = db.GetStoredProcCommand("UpdateImpuestoBajoCosto");
            db.AddInParameter(dbcommand, "@Id", DbType.String, id);
            db.AddInParameter(dbcommand, "@ImpuestosObtenidos", DbType.String, impuestosObtenidos);
            db.AddInParameter(dbcommand, "@PNRBajoCosto", DbType.String, pnrBajoCosto);
            db.AddInParameter(dbcommand, "@ImpuestosMostrados", DbType.String, impuestosMostrados);
            db.AddInParameter(dbcommand, "@LineaContable", DbType.String, lineaContable);
            db.AddInParameter(dbcommand, "@PNRSabre", DbType.String, pnrSabre);
            try
            {
                db.ExecuteReader(dbcommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
