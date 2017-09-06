using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Components.NullableHelper;
using MyCTS.Entities;
using System;
using System.Data;
using System.Data.Common;

namespace MyCTS.DataAccess
{
    public class InsertSCDCVueloDAL
    {
        public string InsertSCDCVuelo(SCDCResumen resumen, int vueloid, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.InsertSCDCVueloResources.SP_insertvuelos);

            db.AddInParameter(dbCommand, Resources.InsertSCDCVueloResources.PARAM_RECLOC, DbType.String, resumen.RecLoc);
            db.AddInParameter(dbCommand, Resources.InsertSCDCVueloResources.PARAM_FECHACREACION, DbType.DateTime, resumen.FechaCreacion);
            db.AddInParameter(dbCommand, Resources.InsertSCDCVueloResources.PARAM_SEGMENTO, DbType.Int32, resumen.Vuelos[vueloid].Segmento);
            db.AddInParameter(dbCommand, Resources.InsertSCDCVueloResources.PARAM_AEROLINEA, DbType.String, resumen.Vuelos[vueloid].Aerolinea);
            db.AddInParameter(dbCommand, Resources.InsertSCDCVueloResources.PARAM_NUMVUELO, DbType.String, resumen.Vuelos[vueloid].NumVuelo);
            db.AddInParameter(dbCommand, Resources.InsertSCDCVueloResources.PARAM_FECHA, DbType.DateTime, resumen.Vuelos[vueloid].FechaSalida);
            db.AddInParameter(dbCommand, Resources.InsertSCDCVueloResources.PARAM_FECHAREG, DbType.DateTime, resumen.Vuelos[vueloid].FechaRegreso);
            db.AddInParameter(dbCommand, Resources.InsertSCDCVueloResources.PARAM_ORIGEN, DbType.String, resumen.Vuelos[vueloid].Origen);
            db.AddInParameter(dbCommand, Resources.InsertSCDCVueloResources.PARAM_DESTINO, DbType.String, resumen.Vuelos[vueloid].Destino);
            db.AddInParameter(dbCommand, Resources.InsertSCDCVueloResources.PARAM_CLASE, DbType.String, resumen.Vuelos[vueloid].Clase);
            db.AddInParameter(dbCommand, Resources.InsertSCDCVueloResources.PARAM_ASIENTOS, DbType.String, resumen.Vuelos[vueloid].Asientos);
            db.AddInParameter(dbCommand, Resources.InsertSCDCVueloResources.PARAM_CONEXION, DbType.String, resumen.Vuelos[vueloid].Conexion);
            db.AddInParameter(dbCommand, Resources.InsertSCDCVueloResources.PARAM_ESTATUS, DbType.String, resumen.Vuelos[vueloid].Estatus);
            db.AddInParameter(dbCommand, Resources.InsertSCDCVueloResources.PARAM_ESPACIOS, DbType.Int32, resumen.Vuelos[vueloid].Espacios);
            db.AddInParameter(dbCommand, Resources.InsertSCDCVueloResources.PARAM_INDICADORCON1, DbType.String, resumen.Vuelos[vueloid].IndicadorCon1);
            db.AddInParameter(dbCommand, Resources.InsertSCDCVueloResources.PARAM_INDICADORCON2, DbType.String, resumen.Vuelos[vueloid].IndicadorCon2);
            db.AddInParameter(dbCommand, Resources.InsertSCDCVueloResources.PARAM_MILLAS, DbType.Int32, resumen.Vuelos[vueloid].Millas);
            db.AddInParameter(dbCommand, Resources.InsertSCDCVueloResources.PARAM_TIEMPOVUELO, DbType.String, resumen.Vuelos[vueloid].TiempoVuelo);
            db.AddInParameter(dbCommand, Resources.InsertSCDCVueloResources.PARAM_AVION, DbType.String, resumen.Vuelos[vueloid].Avion);
            db.AddInParameter(dbCommand, Resources.InsertSCDCVueloResources.PARAM_CLAVELA, DbType.String, resumen.Vuelos[vueloid].ClaveLa);
            db.AddInParameter(dbCommand, Resources.InsertSCDCVueloResources.PARAM_ESCALAS, DbType.Int32, resumen.Vuelos[vueloid].Escalas);

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
