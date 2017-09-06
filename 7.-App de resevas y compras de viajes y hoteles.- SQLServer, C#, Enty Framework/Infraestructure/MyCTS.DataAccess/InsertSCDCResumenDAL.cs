using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Components.NullableHelper;
using MyCTS.Entities;
using System;
using System.Data;
using System.Data.Common;

namespace MyCTS.DataAccess
{
    public class InsertSCDCResumenDAL
    {
        public string InsertSCDCResumen(SCDCResumen resumen, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.InsertSCDCResumenResources.SP_insertaresumen);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_RECLOC, DbType.String, resumen.RecLoc);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_FECHACREACION, DbType.DateTime, resumen.FechaCreacion);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_FECHATRANS, DbType.DateTime, resumen.FechaTrans);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_CANTPAX, DbType.String, resumen.CantPax);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_APELLIDO, DbType.String, resumen.Apellido);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_NOMBRE, DbType.String, resumen.Nombre);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_DK, DbType.String, resumen.Dk);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_FECHAINICIO, DbType.DateTime, resumen.FechaInicio);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_FECHAFIN, DbType.String, resumen.FechaFin);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_RUTA, DbType.String, resumen.Ruta);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_TARIFABASE, DbType.String, resumen.TarifaBase);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_IMPUESTOS, DbType.String, resumen.Impuestos);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_TARIFATOTAL, DbType.String, resumen.TarifaTotal);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_BOLETO, DbType.String, resumen.Boleto);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_HOTEL, DbType.String, resumen.Hotel);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_AUTO, DbType.String, resumen.Auto);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_FECHAMOD, DbType.DateTime, resumen.FechaMod);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_INTERNACIONAL, DbType.String, resumen.Internacional);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_LCTARIFABASE, DbType.String, resumen.LcTarifaBase);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_LCIMPUESTO1, DbType.String, resumen.LcImpuesto1);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_LCIMPUESTO2, DbType.String, resumen.LcImpuesto2);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_LCIMPUESTO3, DbType.String, resumen.LcImpuesto3);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_LCCOMISION, DbType.String, resumen.LcComision);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_RECIBIDO, DbType.String, resumen.Recibido);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_PCCCREA, DbType.String, resumen.PccCrea);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_PCCFIRMA, DbType.String, resumen.PccFirma);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_LASTDAY, DbType.DateTime, resumen.LastDay);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_AGENTE, DbType.String, resumen.Agente);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_LINCONTAEREA, DbType.String, resumen.LinContAerea);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_VUELOSHIST, DbType.String, resumen.VuelosHist);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_REVISION, DbType.String, resumen.Revision);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_PCCLECTURA, DbType.String, resumen.PccLectura);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_QUEUELECTURA, DbType.String, resumen.QueueLectura);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_BSGGRUPO, DbType.String, resumen.BsgGrupo);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_BSGNOMBRE, DbType.String, resumen.BsgNombre);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_BSGESPACIOSRESERVADOS, DbType.Int32, resumen.BsgEspaciosReservados);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_BSGESPACIOSLIBRES, DbType.Int32, resumen.BsgEspaciosLibres);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_MILLAS, DbType.Int32, resumen.Millas);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_TARIFAMONEDA, DbType.String, resumen.TarifaMoneda);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_TXCASILLA1, DbType.String, resumen.TxCasilla1);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_TXCASILLA2, DbType.String, resumen.TxCasilla2);
            db.AddInParameter(dbCommand, Resources.InsertSCDCResumenResources.PARAM_TXCASILLA3, DbType.String, resumen.TxCasilla3);
            
            string registros = string.Empty;
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _registros = dr.GetOrdinal(Resources.InsertSCDCResumenResources.PARAM_REGISTROS);
                while (dr.Read())
                {
                    registros = (dr[_registros] == DBNull.Value) ? Types.StringNullValue : dr.GetInt32(_registros).ToString();
                }
            }

            return registros;
        }
    }
}
