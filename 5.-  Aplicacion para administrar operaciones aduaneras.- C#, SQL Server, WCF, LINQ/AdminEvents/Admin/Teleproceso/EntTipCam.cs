using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace AdminEvents
{
	[Serializable]
	public class EntTipCam
	{
		private int id;
		private DateTime fecdof;
		private decimal tipocambio;
		private DateTime fecdia;

	#region Metodos

		public int Id {
			set { id = value; }
			get { return id; }
		}

		public DateTime FecDOF {
			set { fecdof = value; }
			get { return fecdof; }
		}

		public decimal TipoCambio {
			set { tipocambio = value; }
			get { return tipocambio; }
		}

		public DateTime FecDIA {
			set { fecdia = value; }
			get { return fecdia; }
		}


	#endregion
	#region Constructor
		public EntTipCam(){
		}
		public EntTipCam(int vid, DateTime vfecdof, decimal vtipocambio, DateTime vfecdia) {

			id = vid;
			fecdof = vfecdof;
			tipocambio = vtipocambio;
			fecdia = vfecdia;
		}
	#endregion
	}
}