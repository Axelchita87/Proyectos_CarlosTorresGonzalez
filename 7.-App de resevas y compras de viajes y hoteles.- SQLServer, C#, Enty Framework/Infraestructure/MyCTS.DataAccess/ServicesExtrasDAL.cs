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
    public class ServicesExtrasDAL
    {
        public List<ServicesExtras> ServicesExtras(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.ServicesExtrasResources.SP_SelectALLFromCatServicesExtras);
            List<ServicesExtras> listServicios = new List<Entities.ServicesExtras>();
            try
            {
                using (IDataReader dr = db.ExecuteReader(dbCommand))
                {
                    int _nombreservicio = dr.GetOrdinal(Resources.ServicesExtrasResources.PARAM_NombreServicio);
                    int _codigoservicio = dr.GetOrdinal(Resources.ServicesExtrasResources.PARAM_CodigoServicio);
                    while(dr.Read())
                    {
                        ServicesExtras servicio = new ServicesExtras();
                        servicio.NombreServicio = dr.GetString(_nombreservicio);
                        servicio.CodigoServicio = dr.GetString(_codigoservicio);
                        listServicios.Add(servicio);
                    }
                }
            }
            catch { }

            return listServicios;
        }
    }
}
