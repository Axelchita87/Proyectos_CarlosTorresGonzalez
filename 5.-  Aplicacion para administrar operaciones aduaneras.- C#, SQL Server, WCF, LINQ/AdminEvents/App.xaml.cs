using ADMIN2.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AdminEvents
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static int IdUsuario { get; set; }
        public static string NombreUsuario { get; set; }
        public static bool Admin { get; set; }
        public static int IdArea { get; set; }
        public static string CorreoElectronico { get; set; }
        public static int IdPerfil { get; set; }
        public static int IdSistema { get; set; }
        public static List<EntPerfil> ListaAccesoPantalla { get; set; }
        public static int IdPermiso { get; set; }
    }
}
