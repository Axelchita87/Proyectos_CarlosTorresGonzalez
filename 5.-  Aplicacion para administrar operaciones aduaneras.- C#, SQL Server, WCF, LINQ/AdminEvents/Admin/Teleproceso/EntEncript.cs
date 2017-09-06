using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace AdminEvents
{
	[Serializable]
	public class EntEncript
	{
		private string tabla;
		private List<int> campos;
		private List<string> descampo;
		private List<string> descampoenc;

	#region Metodos

		public string Tabla {
			set { tabla = value; }
			get { return tabla; }
		}

		public List<int> Campos {
			set { campos = value; }
			get { return campos; }
		}

		public List<string> DesCampo {
			set { descampo = value; }
			get { return descampo; }
		}

		public List<string> DesCampoEnc {
			set { descampoenc = value; }
			get { return descampoenc; }
		}


	#endregion
	#region Constructor
		public EntEncript(){
		}
		public EntEncript(string vtabla, List<int> vcampos) {

			tabla = vtabla;
			campos = vcampos;
		}
	#endregion
	}
}