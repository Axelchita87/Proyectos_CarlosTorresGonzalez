using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Entities;

namespace MyCTS.DataAccess
{
    public class GetCxSHotelesDAL
    {
        public CxSHoteles GetCxSHoteles(string pnr, string connectionName)
        {
            CxSHoteles registroCxSHotel = new CxSHoteles();
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand("GetCxSHoteles_MYCTS");
            db.AddInParameter(dbCommand, "fcPNR", DbType.String, pnr);
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int fechaRegistro = dr.GetOrdinal("fdtFechaRegistro");
                int transaccionId = dr.GetOrdinal("fcTransaccionId");
                int reservacion = dr.GetOrdinal("fcReservacion");
                int factura = dr.GetOrdinal("fcFactura");
                int serie = dr.GetOrdinal("fcSerie");
                int facturaCargo = dr.GetOrdinal("fcFacturaCargo");
                int serieCargo = dr.GetOrdinal("fcSerieCargo");
                int organizacionId = dr.GetOrdinal("fiOrgId");
                int id = dr.GetOrdinal("Id");
                int autorization = dr.GetOrdinal("fcAutorization");
                int operation = dr.GetOrdinal("fcOperation");
                int numeroTarjeta = dr.GetOrdinal("fcNumeroTarjeta");
                int formaDePago = dr.GetOrdinal("fcFormaDePago");
                int monto = dr.GetOrdinal("fdMonto");

                while (dr.Read())
                {
                    registroCxSHotel = new CxSHoteles();
                    registroCxSHotel.FechaRegistro = Convert.ToDateTime(dr[fechaRegistro]);
                    registroCxSHotel.TransaccionId = Convert.ToString(dr[transaccionId]);
                    registroCxSHotel.Reservacion = Convert.ToString(dr[reservacion]);
                    registroCxSHotel.Factura = Convert.ToString(dr[factura]);
                    registroCxSHotel.Serie = Convert.ToString(dr[serie]);
                    registroCxSHotel.FacturaCargo = Convert.ToString(dr[facturaCargo]);
                    registroCxSHotel.SerieCargo = Convert.ToString(dr[serieCargo]);
                    registroCxSHotel.OrganizacionId = Convert.ToInt32(dr[organizacionId]);
                    registroCxSHotel.Id = Convert.ToInt32(dr[id]);
                    registroCxSHotel.Autorization = Convert.ToString(dr[autorization]);
                    registroCxSHotel.Operation = Convert.ToString(dr[operation]);
                    registroCxSHotel.NumeroTarjeta = Convert.ToString(dr[numeroTarjeta]);
                    registroCxSHotel.FormaDePago = Convert.ToString(dr[formaDePago]);
                    registroCxSHotel.Monto = Convert.ToDecimal(dr[monto]);
                }
            }
            return registroCxSHotel;
        }
    }
}
