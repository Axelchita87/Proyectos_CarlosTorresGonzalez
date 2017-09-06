using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucEndQueuePlace : CustomUserControl
    {
        /// <summary>
        /// Descripción: User Control que evalua un record y determina si pertenece al flujo de hoteles.
        ///              Parte del modulo de Queues
        /// Creación:    Enero 23, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Ivan Martínez Guerrero
        /// </summary>

        public ucEndQueuePlace()
        {
            InitializeComponent();
        }

        private bool resume = true;
        private string result = string.Empty;
        private string PNR = string.Empty;
        public static string param;
        public static bool isPlaceRecordQueue = false;
        private static bool conclude = false;
        public static List<OTATravelItineraryObjectHotel> objItineraryHotel = null;

        private void ucEndQueuePlace_Load(object sender, EventArgs e)
        {

        }

       
    }
}
