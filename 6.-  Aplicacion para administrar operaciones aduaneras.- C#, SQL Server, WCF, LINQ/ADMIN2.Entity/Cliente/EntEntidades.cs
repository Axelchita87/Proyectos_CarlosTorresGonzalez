using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMIN2.Entity
{
    [Serializable]
    public class EntEntidades
    {
        private string opc;

        public string Opc
        {
            get { return opc; }
            set { opc = value; }
        }
        private int idCodigo;

        public int IdCodigo
        {
            get { return idCodigo; }
            set { idCodigo = value; }
        }
        private int idMunicipio;

        public int IdMunicipio
        {
            get { return idMunicipio; }
            set { idMunicipio = value; }
        }
        private int idEstado;

        public int IdEstado
        {
            get { return idEstado; }
            set { idEstado = value; }
        }


        private string d_codigo;

        public string D_codigo
        {
            get { return d_codigo; }
            set { d_codigo = value; }
        }

        private string d_asenta;

        public string D_asenta
        {
            get { return d_asenta; }
            set { d_asenta = value; }
        }

       private string d_estado;

        public string D_estado
        {
            get { return d_estado; }
            set { d_estado = value; }
        }

        private string d_mnpio;

        public string D_mnpio
        {
            get { return d_mnpio; }
            set { d_mnpio = value; }
        }

        #region Constructores

        public EntEntidades(EntEntidades Vop)
        {
            opc = Vop.opc;
            d_codigo = Vop.D_codigo;
            d_asenta = Vop.D_asenta;
            d_estado = Vop.D_estado;
            d_mnpio = Vop.D_mnpio;
            idCodigo = Vop.idCodigo;
            idEstado = Vop.idEstado;
            idMunicipio = Vop.idMunicipio;
        }

        public EntEntidades()
        {
            opc = string.Empty;
            d_codigo = string.Empty;
            d_asenta = string.Empty;
            d_estado = string.Empty;
            d_mnpio = string.Empty;
            idCodigo = 0;
            idEstado = 0;
            idMunicipio = 0;
        }

        #endregion
    }
}
