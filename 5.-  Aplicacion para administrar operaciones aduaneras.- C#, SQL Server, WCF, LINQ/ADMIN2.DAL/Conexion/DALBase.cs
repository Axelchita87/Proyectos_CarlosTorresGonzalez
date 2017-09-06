using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ADMIN2.Entity;

namespace ADMIN2.DAL
{
    public class DALBase
    {
        protected DBHelper db = null;
        protected IDbConnection conm = null;
        protected IDbTransaction tranm = null;
        protected IDataReader dr = null;
        protected IDataReader drAux = null;
        protected DBHelper db2 = null;
        protected IDbConnection conm2 = null;
        public bool begTran()
        {
            bool ini = false;
            try
            {
                if (conm != null)
                    tranm = conm.BeginTransaction();
                else
                    tranm = conm2.BeginTransaction();
                ini = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ini;
        }

        public void roll_back()
        {
            try
            {
                tranm.Rollback();
                if (conm!= null)
                    conm.Close();
                else
                    conm2.Close();
                if (conm != null)
                    conm.Dispose();
                else
                    conm2.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void commit()
        {
            try
            {
                tranm.Commit();
                if (conm != null && conm.State == ConnectionState.Open)
                {
                    conm.Close();
                    conm.Dispose();
                }
                else if (conm2 != null && conm2.State == ConnectionState.Open)
                {
                    conm2.Close();
                    conm2.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void close()
        {
            if (conm != null && conm.State == ConnectionState.Open)
            {
                conm.Close();
                conm.Dispose();
            }
            else if (conm2 != null && conm2.State == ConnectionState.Open)
            {
                conm2.Close();
                conm2.Dispose();
            }
            
        }

        protected static Respuesta<int> ExisteError(IDataReader dr)
        {
            Respuesta<int> respuesta = new Respuesta<int>();
            int error = 0;
            int idc = 0;
            string descError = string.Empty;
            if (dr[0] != DBNull.Value) error = Convert.ToInt32(dr[0]);
            if (dr[1] != DBNull.Value) descError = dr[1].ToString();
            if (dr[2] != DBNull.Value) idc = Convert.ToInt32(dr[2]);
            if (error > 0) respuesta.MensajeUsuario = descError;
            else
            {
                respuesta.EsExitoso = true;
                respuesta.TotalRegistros = idc;
            }
            return respuesta;
        }

        //public string GetDescEtapa(decimal etapa, List<Ent_Etapas> lstEtapas)
        //{
        //    Ent_Etapas search = lstEtapas.Find(s => s.Id_ceetapa == etapa);
        //    if (search != null)
        //        return search.Catetapa;
        //    return string.Empty;
        //}

        //public string GetDocumento(decimal doc, List<Ent_Documento_Trafi> lstDocs)
        //{
        //    Ent_Documento_Trafi search = lstDocs.Find(s => s.Id_docum == doc);
        //    if (search != null)
        //        return search.Documento;
        //    return string.Empty;
        //}

        //public string GetTipoAduana(string p)
        //{
        //    switch (p)
        //    {
        //        case "1":
        //            return "Aerea";
        //        case "2":
        //            return "Maritima";
        //        case "3":
        //            return "Terrestre";
        //    }

        //    return string.Empty;
        //}

        //public string GetTipoOperacion(string p)
        //{
        //    return p == "1" ? "Importación" : "Exportación";
        //}
    }
}
