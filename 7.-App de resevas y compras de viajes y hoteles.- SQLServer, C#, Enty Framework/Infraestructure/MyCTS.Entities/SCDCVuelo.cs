using System;

namespace MyCTS.Entities
{
    public class SCDCVuelo
    {
        private int segmento;
        public int Segmento { get { return segmento; } set { segmento = value; } }

        private string aerolinea;
        public string Aerolinea { get { return aerolinea; } set { aerolinea = value; } }

        private string numVuelo;
        public string NumVuelo { get { return numVuelo; } set { numVuelo = value; } }

        private DateTime fechaSalida;
        public DateTime FechaSalida { get { return fechaSalida; } set { fechaSalida = value; } }

        private DateTime fechaRegreso;
        public DateTime FechaRegreso { get { return fechaRegreso; } set { fechaRegreso = value; } }

        private string origen;
        public string Origen { get { return origen; } set { origen = value; } }

        private string destino;
        public string Destino { get { return destino; } set { destino = value; } }

        private string clase;
        public string Clase { get { return clase; } set { clase = value; } }

        private string asientos;
        public string Asientos { get { return asientos; } set { asientos = value; } }

        private string conexion;
        public string Conexion { get { return conexion; } set { conexion = value; } }

        private string estatus;
        public string Estatus { get { return estatus; } set { estatus = value; } }

        private int espacios;
        public int Espacios { get { return espacios; } set { espacios = value; } }

        private string indicadorCon1;
        public string IndicadorCon1 { get { return indicadorCon1; } set { indicadorCon1 = value; } }

        private string indicadorCon2;
        public string IndicadorCon2 { get { return indicadorCon2; } set { indicadorCon2 = value; } }

        private int millas;
        public int Millas { get { return millas; } set { millas = value; } }

        private string tiempoVuelo;
        public string TiempoVuelo { get { return tiempoVuelo; } set { tiempoVuelo = value; } }

        private string avion;
        public string Avion { get { return avion; } set { avion = value; } }

        private string claveLa;
        public string ClaveLa { get { return claveLa; } set { claveLa = value; } }

        private int escalas;
        public int Escalas { get { return escalas; } set { escalas = value; } }
    }
}
