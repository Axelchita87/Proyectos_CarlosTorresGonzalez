using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Components.NullableHelper;
using MyCTS.Entities;
using System;
using System.Data;
using System.Data.Common;

namespace MyCTS.DataAccess
{
    public class InsertSCDCBoletoDAL
    {
        public string InsertSCDCBoleto(SCDCBoleto boleto, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.InsertSCDCBoletoResources.SP_generaboleto);

            db.AddInParameter(dbCommand, Resources.InsertSCDCBoletoResources.PARAM_RECLOC, DbType.String, boleto.RecLoc);
            db.AddInParameter(dbCommand, Resources.InsertSCDCBoletoResources.PARAM_FECHACREA, DbType.DateTime, boleto.FechaCreacion);
            db.AddInParameter(dbCommand, Resources.InsertSCDCBoletoResources.PARAM_SEGMENTO, DbType.String, boleto.Segmento);
            db.AddInParameter(dbCommand, Resources.InsertSCDCBoletoResources.PARAM_NUMBOLETO, DbType.String, boleto.NumeroBoleto);
            db.AddInParameter(dbCommand, Resources.InsertSCDCBoletoResources.PARAM_NOMBRE, DbType.String, boleto.Nombre);
            db.AddInParameter(dbCommand, Resources.InsertSCDCBoletoResources.PARAM_FECHAEMISION, DbType.DateTime, boleto.FechaEmision);
            db.AddInParameter(dbCommand, Resources.InsertSCDCBoletoResources.PARAM_FECHA, DbType.DateTime, boleto.Fecha);
            db.AddInParameter(dbCommand, Resources.InsertSCDCBoletoResources.PARAM_BOLETOELECTRONICO, DbType.String, boleto.BoletoElectronico);
            db.AddInParameter(dbCommand, Resources.InsertSCDCBoletoResources.PARAM_INDICADOR, DbType.String, boleto.Indicador);
            db.AddInParameter(dbCommand, Resources.InsertSCDCBoletoResources.PARAM_PAIS, DbType.String, boleto.Pais);
            db.AddInParameter(dbCommand, Resources.InsertSCDCBoletoResources.PARAM_INDICADOR2, DbType.String, boleto.Indicador2);
            db.AddInParameter(dbCommand, Resources.InsertSCDCBoletoResources.PARAM_PCC, DbType.String, boleto.Pcc);

            string registros = string.Empty;
            
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _registros = dr.GetOrdinal(Resources.InsertSCDCBoletoResources.PARAM_REGISTROS);

                while (dr.Read())
                {
                    registros = (dr[_registros] == DBNull.Value) ? Types.StringNullValue : dr.GetInt32(_registros).ToString();
                }
            }

            return registros;
        }
    }
}
