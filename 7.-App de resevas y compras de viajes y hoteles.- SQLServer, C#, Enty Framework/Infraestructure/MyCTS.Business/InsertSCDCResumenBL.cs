using MyCTS.DataAccess;
using MyCTS.Entities;
using System;

namespace MyCTS.Business
{
    public class InsertSCDCResumenBL
    {
        public string InsertSDCResumen(SCDCResumen resumen)
        {
            string result = string.Empty;

            try
            {
                InsertSCDCResumenDAL objResumen = new InsertSCDCResumenDAL();

                try
                {
                    result = objResumen.InsertSCDCResumen(resumen, CommonENT.MYCTSDB_CONNECTION);

                    if (result == "1")
                    {
                        DeleteSCDCVuelosDAL objdelete = new DeleteSCDCVuelosDAL();

                        result = objdelete.DeleteSCDCVuelo(resumen.RecLoc, CommonENT.MYCTSDB_CONNECTION);

                        if (result == "1")
                        {
                            InsertSCDCVueloDAL objVuelo = new InsertSCDCVueloDAL();

                            for (int i = 0; i < (resumen.Vuelos != null ? resumen.Vuelos.Count : 0); i++)
                            {
                                result = objVuelo.InsertSCDCVuelo(resumen, i, CommonENT.MYCTSDB_CONNECTION);
                            }
                        }
                        else
                        {
                            throw (new ArgumentException("Fallo el ingreso de datos a la tabla Resumen de SCDC. Revise el PA deleteResumen"));
                        }
                    }
                    else
                    {
                        throw (new ArgumentException("Fallo el ingreso de datos a la tabla Resumen de SCDC. Revise el PA insertResumen"));
                    }
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    result = objResumen.InsertSCDCResumen(resumen, CommonENT.MYCTSDBBACKUP_CONNECTION);

                    if (result == "1")
                    {
                        DeleteSCDCVuelosDAL objdelete = new DeleteSCDCVuelosDAL();

                        result = objdelete.DeleteSCDCVuelo(resumen.RecLoc, CommonENT.MYCTSDBBACKUP_CONNECTION);

                        if (result == "1")
                        {

                            InsertSCDCVueloDAL objVuelo = new InsertSCDCVueloDAL();

                            for (int i = 0; i < (resumen.Vuelos != null ? resumen.Vuelos.Count : 0); i++)
                            {
                                result = objVuelo.InsertSCDCVuelo(resumen, i, CommonENT.MYCTSDBBACKUP_CONNECTION);
                            }
                        }
                        else
                        {
                            throw (new ArgumentException("Fallo el ingreso de datos a la tabla Resumen de SCDC. Revise el PA deleteResumen"));
                        }
                    }
                    else
                    {
                        throw (new ArgumentException("Fallo el ingreso de datos a la tabla Resumen de SCDC. Revise el PA insertResumen"));
                    }
                }
            }
            catch { }

            return result;
        }
    }
}
