using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADMIN2.Entity;
using System.Data;

namespace ADMIN2.DAL
{
    public class DalAdminsitracion :DALBase
    {
        public DalAdminsitracion()
        {
            db = DBHelper.GetInstance("conxAdm");
            conm = db.GetConnObject();
        }

        #region BitacoraCambios

        public List<EntBitacora> GetBitacoraCambios(EntBitacora Dobj)
        {
            List<EntBitacora> lst = new List<EntBitacora>();
            DBParameterCollection pcol = ParamAdminsitracion.LLenaBitacoraC(Dobj, Comunes.BUSCAR, "A");
            using (dr = db.ExecuteDataReader(Procedimientos.SpBitacora, pcol, conm, tranm, CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    EntBitacora obj = new EntBitacora();
                    if (dr["Usuario"] != DBNull.Value) obj.Usuario = (dr["Usuario"].ToString());
                    if (dr["Accion"] != DBNull.Value) obj.Accion = (dr["Accion"].ToString());
                    if (dr["Descripcion"] != DBNull.Value) obj.Descripcion = (dr["Descripcion"].ToString());
                    if (dr["FechaRegistro"] != DBNull.Value) obj.FechaRegistro = (dr["FechaRegistro"].ToString());
                    lst.Add(obj);
                }
            }
            return lst;
        }

        #endregion

    }
}
