using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADMIN2.Entity;

namespace ADMIN2.DAL
{
    public class ParamAdminsitracion
    {

        #region BitacoraCambios

        public static DBParameterCollection LLenaBitacoraC(EntBitacora obj, string opc, string ptipo)
        {
            DBParameter p1 = new DBParameter("popc", opc, System.Data.DbType.String);
            DBParameter p2 = new DBParameter("poptipo", ptipo, System.Data.DbType.String);
            DBParameter p3 = new DBParameter("IdSistema", obj.IdSistema, System.Data.DbType.Int32);

            DBParameter[] parms = new DBParameter[] { p1, p2, p3 };
            DBParameterCollection pcol = new DBParameterCollection();
            pcol.AddRange(parms);
            return pcol;
        }

        #endregion

    }
}
