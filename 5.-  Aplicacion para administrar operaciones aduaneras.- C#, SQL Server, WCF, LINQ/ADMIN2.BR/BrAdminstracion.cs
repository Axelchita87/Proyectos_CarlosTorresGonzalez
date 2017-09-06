using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADMIN2.Entity;
using ADMIN2.DAL;

namespace ADMIN2.BR
{
    public class BrAdminstracion
    {

        #region BitacoraCambios

        public Respuesta<List<EntBitacora>> GetBitacoraCambios(EntBitacora obj)
        {
            DalAdminsitracion usu = new DalAdminsitracion();
            Respuesta<List<EntBitacora>> respuesta = new Respuesta<List<EntBitacora>>();

            try
            {
                respuesta.Resultado = usu.GetBitacoraCambios(obj);
                if (respuesta.Resultado != null && respuesta.Resultado.Count() > 0)
                {
                    respuesta.EsExitoso = true;
                    respuesta.TotalRegistros = respuesta.Resultado.Count();

                }
                else
                {
                    respuesta.EsExitoso = false;
                    respuesta.TotalRegistros = respuesta.Resultado.Count();
                }
            }
            catch (Exception ex)
            {
                respuesta.InicializaError(excepcion: ex);
            }
            return respuesta;
        }

        #endregion
    }
}
