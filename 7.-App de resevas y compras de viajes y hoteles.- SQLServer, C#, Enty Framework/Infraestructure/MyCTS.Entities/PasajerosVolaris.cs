using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class PasajerosVolaris
    {
        public int NumeroPasajero { get; set; }
        public TiposVolaris.FirstTittle Titulo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public TiposVolaris.Gender Genero { get; set; }
        public TiposVolaris.PassengerType TipoPasajero { get; set; }
        public string Nacionalidad { get; set; }
        public string Pais { get; set; }
        public string City { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int TipoDeViajeInfante { get; set; }


        public PasajerosVolaris()
        {
        }

        public PasajerosVolaris(TiposVolaris.FirstTittle titulo, string nombres, string apellidos, TiposVolaris.Gender genero, TiposVolaris.PassengerType tipoPasajero, DateTime fechaNacimiento, string nacionalidad, string pais)
        {
            Titulo = titulo;
            Nombres = nombres;
            Apellidos = apellidos;
            Genero = genero;
            TipoPasajero = tipoPasajero;
            Nacionalidad = nacionalidad;
            Pais = pais;
            FechaNacimiento = fechaNacimiento;
        }

        public PasajerosVolaris(TiposVolaris.FirstTittle titulo, string nombres, string apellidos, TiposVolaris.Gender genero, TiposVolaris.PassengerType tipoPasajero, DateTime fechaNacimiento, string nacionalidad, string pais, int tipoDeViajeInfante)
        {
            Titulo = titulo;
            Nombres = nombres;
            Apellidos = apellidos;
            Genero = genero;
            TipoPasajero = tipoPasajero;
            Nacionalidad = nacionalidad;
            Pais = pais;
            FechaNacimiento = fechaNacimiento;
            TipoDeViajeInfante = tipoDeViajeInfante;
        }
    }
}
