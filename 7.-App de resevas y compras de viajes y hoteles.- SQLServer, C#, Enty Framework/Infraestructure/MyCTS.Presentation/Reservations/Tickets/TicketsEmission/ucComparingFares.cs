using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucComparingFares : CustomUserControl
    {
        /// <summary>
        /// Descripción: User Control que establece si se vendio la tarifa mas economica
        ///              en la variable samefare que sera utilizada posteriormente en el flujo de emision
        ///              de boleto
        ///              Pertenece al flujo de emisión de boleto de la aplicación.
        /// Creación:    Mayo - Junio 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        /// 
        private static bool samefare;
        public static bool sameFare
        {
            get { return samefare; }
            set { samefare = value; }
        }

        public ucComparingFares()
        {
            InitializeComponent();
        }

        private void ucComparingFares_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            ComparingFares();
        }

        #region===== MethodsClass =====

        /// <summary>
        ///  Compara variables provenientes de otros user controls para establecer
        /// la variable samefare en true o false dependiendo el resultado
        /// </summary>
        private void ComparingFares()
        {
            double fareWithoutTaxesSold;
            double fareWithoutTaxesLowND;
            double calculateFareDifference;
            string active = activeStepsCorporativeQC.CorporativeQualityControls[0].ComparativeSoldFareVSMoreEconomicFareNotAvailable;
            if (active.Equals(Resources.TicketEmission.Constants.ACTIVE))
            {
                if (string.IsNullOrEmpty(ucRatingActualFare.fareWithoutTaxesSold))
                    ucRatingActualFare.fareWithoutTaxesSold = Resources.TicketEmission.Constants.Zero;
                if (string.IsNullOrEmpty(ucRatingActualFare.fareWithTaxesSold))
                    ucRatingActualFare.fareWithTaxesSold = Resources.TicketEmission.Constants.Zero;
                if (string.IsNullOrEmpty(ucComparisonRates.rate_SinImp_Low_ND))
                    ucComparisonRates.rate_SinImp_Low_ND = Resources.TicketEmission.Constants.Zero;

                fareWithoutTaxesSold = Convert.ToDouble(ucRatingActualFare.fareWithoutTaxesSold);
                fareWithoutTaxesLowND = Convert.ToDouble(ucComparisonRates.rate_SinImp_Low_ND);
                calculateFareDifference = fareWithoutTaxesLowND - fareWithoutTaxesSold;
                if (calculateFareDifference.Equals(0))
                {
                    samefare = true;
                }
                else
                {
                    samefare = false;
                }
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCREMARKS_CLASS);
            }
            else
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCREMARKS_CLASS);
            }
        }
        #endregion//EndMethodsClass 
    }
}
