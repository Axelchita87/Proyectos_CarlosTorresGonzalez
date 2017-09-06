using System;
using System.Collections.Generic;

namespace MyCTS.Entities
{
    public class SCDCResumen
    {
        private string recLoc;
        public string RecLoc { get { return recLoc; } set { recLoc = value; } }

        private DateTime fechaCreacion;
        public DateTime FechaCreacion { get { return fechaCreacion; } set { fechaCreacion = value; } }

        private DateTime fechaTrans;
        public DateTime FechaTrans { get { return fechaTrans; } set { fechaTrans = value; } }

        private string cantPax;
        public string CantPax { get { return cantPax; } set { cantPax = value; } }

        private string apellido;
        public string Apellido { get { return apellido; } set { apellido = value; } }

        private string nombre;
        public string Nombre { get { return nombre; } set { nombre = value; } }

        private string dk;
        public string Dk { get { return dk; } set { dk = value; } }

        private DateTime fechaInicio;
        public DateTime FechaInicio { get { return fechaInicio; } set { fechaInicio = value; } }

        private string fechaFin;
        public string FechaFin { get { return fechaFin; } set { fechaFin = value; } }

        private string ruta;
        public string Ruta { get { return ruta; } set { ruta = value; } }

        private string tarifaBase;
        public string TarifaBase { get { return tarifaBase; } set { tarifaBase = value; } }

        private string impuestos;
        public string Impuestos { get { return impuestos; } set { impuestos = value; } }

        private string tarifaTotal;
        public string TarifaTotal { get { return tarifaTotal; } set { tarifaTotal = value; } }

        private string boleto;
        public string Boleto { get { return boleto; } set { boleto = value; } }

        private string hotel;
        public string Hotel { get { return hotel; } set { hotel = value; } }

        private string auto;
        public string Auto { get { return auto; } set { auto = value; } }

        private DateTime fechaMod;
        public DateTime FechaMod { get { return fechaMod; } set { fechaMod = value; } }

        private string internacional;
        public string Internacional { get { return internacional; } set { internacional = value; } }

        private string lcTarifaBase;
        public string LcTarifaBase { get { return lcTarifaBase; } set { lcTarifaBase = value; } }

        private string lcImpuesto1;
        public string LcImpuesto1 { get { return lcImpuesto1; } set { lcImpuesto1 = value; } }

        private string lcImpuesto2;
        public string LcImpuesto2 { get { return lcImpuesto2; } set { lcImpuesto2 = value; } }

        private string lcImpuesto3;
        public string LcImpuesto3 { get { return lcImpuesto3; } set { lcImpuesto3 = value; } }

        private string lcComision;
        public string LcComision { get { return lcComision; } set { lcComision = value; } }

        private string recibido;
        public string Recibido { get { return recibido; } set { recibido = value; } }

        private string pccCrea;
        public string PccCrea { get { return pccCrea; } set { pccCrea = value; } }

        private string pccFirma;
        public string PccFirma { get { return pccFirma; } set { pccFirma = value; } }

        private DateTime lastDay;
        public DateTime LastDay { get { return lastDay; } set { lastDay = value; } }

        private string agente;
        public string Agente { get { return agente; } set { agente = value; } }

        private string linContAerea;
        public string LinContAerea { get { return linContAerea; } set { linContAerea = value; } }

        private string vuelosHist;
        public string VuelosHist { get { return vuelosHist; } set { vuelosHist = value; } }

        private string revision;
        public string Revision { get { return revision; } set { revision = value; } }

        private string pccLectura;
        public string PccLectura { get { return pccLectura; } set { pccLectura = value; } }

        private string queueLectura;
        public string QueueLectura { get { return queueLectura; } set { queueLectura = value; } }

        private string bsgGrupo;
        public string BsgGrupo { get { return bsgGrupo; } set { bsgGrupo = value; } }

        private string bsgNombre;
        public string BsgNombre { get { return bsgNombre; } set { bsgNombre = value; } }

        private int bsgEspaciosReservados;
        public int BsgEspaciosReservados { get { return bsgEspaciosReservados; } set { bsgEspaciosReservados = value; } }

        private int bsgEspaciosLibres;
        public int BsgEspaciosLibres { get { return bsgEspaciosLibres; } set { bsgEspaciosLibres = value; } }

        private int millas;
        public int Millas { get { return millas; } set { millas = value; } }

        private string tarifaMoneda;
        public string TarifaMoneda { get { return tarifaMoneda; } set { tarifaMoneda = value; } }

        private string txCasilla1;
        public string TxCasilla1 { get { return txCasilla1; } set { txCasilla1 = value; } }

        private string txCasilla2;
        public string TxCasilla2 { get { return txCasilla2; } set { txCasilla2 = value; } }

        private string txCasilla3;
        public string TxCasilla3 { get { return txCasilla3; } set { txCasilla3 = value; } }

        private List<SCDCVuelo> vuelos;
        public List<SCDCVuelo> Vuelos { get { return vuelos; } set { vuelos = value; } }

        public SCDCResumen()
        {
            this.vuelos = new List<SCDCVuelo>();
        }

    }
}
