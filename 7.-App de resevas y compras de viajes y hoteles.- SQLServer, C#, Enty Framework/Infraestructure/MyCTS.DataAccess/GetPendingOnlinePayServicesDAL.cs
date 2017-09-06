using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace MyCTS.DataAccess
{
    public class GetPendingOnlinePayServicesDAL
    {
        public static List<CreditCardInfo> GetPendingOnlinePayServices(String sPNR)
        {  
            List<CreditCardInfo> listaInfoTarjetas = new  List<CreditCardInfo>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.LogOnlinePayServices.SP_GetPendingOnlinePayServices);
            db.AddInParameter(dbCommand, Resources.LogOnlinePayServices.PARAM_fcPNR, DbType.String, sPNR);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _FormTypeCodeFOP = dr.GetOrdinal(Resources.LogOnlinePayServices.PARAM_fcFormTypeCodeFOP);
                int _PaxNumber = dr.GetOrdinal(Resources.LogOnlinePayServices.PARAM_fiPaxNumber);
                int _PNR = dr.GetOrdinal(Resources.LogOnlinePayServices.PARAM_fcPNR);
                int _Autorization = dr.GetOrdinal(Resources.LogOnlinePayServices.PARAM_fcAutorization);
                int _Operation = dr.GetOrdinal(Resources.LogOnlinePayServices.PARAM_fcOperation);
                int _Tarjeta = dr.GetOrdinal(Resources.LogOnlinePayServices.PARAM_fcTarjeta);
                int _Monto = dr.GetOrdinal(Resources.LogOnlinePayServices.PARAM_fdMonto);

                while (dr.Read())
                {
                    CreditCardInfo item = new CreditCardInfo();

                    item.TipoTarjeta= (dr[_FormTypeCodeFOP] == DBNull.Value) ? String.Empty : dr.GetString(_FormTypeCodeFOP);
                    item.PaxNumber =(dr[_PaxNumber] == DBNull.Value) ? 0 : dr.GetInt32(_PaxNumber);
                    item.PNR = (dr[_PNR] == DBNull.Value) ? String.Empty : dr.GetString(_PNR);
                    item.NumeroAutorizacion = (dr[_Autorization] == DBNull.Value) ? String.Empty : dr.GetString(_Autorization);
                    item.NumeroOperacion = (dr[_Operation] == DBNull.Value) ? String.Empty : dr.GetString(_Operation);
                    item.NumeroTarjeta = (dr[_Tarjeta] == DBNull.Value) ? String.Empty : dr.GetString(_Tarjeta);
                    item.MontoCargo = (dr[_Monto] == DBNull.Value) ? 0 : dr.GetDecimal(_Monto);
                    
                    listaInfoTarjetas.Add(item);
                }
            }
            return listaInfoTarjetas;
        }
    }
}
