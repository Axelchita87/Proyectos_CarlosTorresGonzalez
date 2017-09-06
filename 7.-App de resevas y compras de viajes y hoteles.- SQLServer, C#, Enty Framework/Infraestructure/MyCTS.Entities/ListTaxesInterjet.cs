using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public static class ListTaxesInterjet
    {
        //Status de vuelos Redondos
        public static bool roud { get; set; }

        public static bool Conexion { get; set; }
        //saber cuantos vuelos existen
        public static int Fligth { get; set; }
        public static int turning { get; set; }
        public static int turn { get; set; }

        public static int mit { get; set; }
        //Saber si existen segmentos impares
        public static bool Odd { get; set; }

        public static int turningTaxes { get; set; }
        /// <summary>
        /// Gets or sets the base price.
        /// </summary>
        /// <value>
        /// The base price.
        /// </value>
        public static List<decimal> BasePriceList { get; set; }
        /// <summary>
        /// Gets or sets the taxes.
        /// </summary>
        /// <value>
        /// The taxes.
        /// </value>
        public static List<decimal> TaxesList { get; set; }

        public static decimal TotalPay { get; set; }


        public static string Status { get; set; }

        /// <summary>
        /// Gets or sets the discount.
        /// </summary>
        /// <value>
        /// The discount.
        /// </value>
        public static List<decimal> DiscountList { get; set; }

        public static List<decimal> IVA { get; set; }
        public static List<decimal> TUA { get; set; }
        public static List<decimal> Extras { get; set; }
        public static List<decimal> TotalPrice { get; set; }
        public static decimal TotalRound { get; set; }

        public static void ClearTaxIntejer()
        {
            roud = false;
            BasePriceList = new List<decimal>();
            TaxesList = new List<decimal>();
            DiscountList = new List<decimal>();
            IVA = new List<decimal>();
            TUA = new List<decimal>();
            TotalPrice = new List<decimal>();
            TotalRound = 0;
            TotalPay = 0;
            Status = string.Empty;
        }

    }
}
