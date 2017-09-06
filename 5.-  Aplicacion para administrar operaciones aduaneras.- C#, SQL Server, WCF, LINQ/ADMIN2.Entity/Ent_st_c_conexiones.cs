using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace ADMIN2.Entity
{
    public class lstst_c_conexiones : List<Ent_st_c_conexiones>
    { }

	[Serializable]
	public class Ent_st_c_conexiones
	{
		private string st_c_cn_id;
		private string st_c_cn_servidor;
		private string st_c_cn_pwd;
		private string st_c_cn_serial;
        private int st_c_cn_deshabilitado;

        
	#region Metodos
        // Identificador de la conexión
		public string St_c_cn_id {
			set { st_c_cn_id = value; }
			get { return st_c_cn_id; }
		}
        // Nombre del Servidor
		public string St_c_cn_servidor {
			set { st_c_cn_servidor = value; }
			get { return st_c_cn_servidor; }
		}
        // Ruta donde se encuentra instalado el producto
		public string St_c_cn_pwd {
			set { st_c_cn_pwd = value; }
			get { return st_c_cn_pwd; }
		}
        // Numero de serie del producto.
		public string St_c_cn_serial {
			set { st_c_cn_serial = value; }
			get { return st_c_cn_serial; }
		}

        // Conexion Habilitada
        public int St_c_cn_deshabilitado
        {
            get { return st_c_cn_deshabilitado; }
            set { st_c_cn_deshabilitado = value; }
        }

	#endregion
	#region Constructor
		public Ent_st_c_conexiones(){
            st_c_cn_id = string.Empty;
            st_c_cn_servidor = string.Empty;
            st_c_cn_pwd = string.Empty;
            st_c_cn_serial = string.Empty;
		}
		public Ent_st_c_conexiones(string vst_c_cn_id, string vst_c_cn_servidor, string vst_c_cn_ruta, string vst_c_cn_serial) {
			st_c_cn_id = vst_c_cn_id;
			st_c_cn_servidor = vst_c_cn_servidor;
			st_c_cn_pwd = vst_c_cn_ruta;
			st_c_cn_serial = vst_c_cn_serial;
		}
	#endregion
	}
}