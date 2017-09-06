using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PreviousPricing.Passanger
{
    /// <summary>
    /// 
    /// </summary>
    public class VolarisPreviousPassangerPricingPresenter : IBasePresenter<VolarisPreviousPassangerPricingView, VolarisPreviousPassangerRepository>
    {
        #region Miembros de IBasePresenter<VolarisPreviousPassangerPricingView,VolarisPreviousPassangerRepository>

        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        /// <value>
        /// The view.
        /// </value>
        public VolarisPreviousPassangerPricingView View { get; set; }

        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        /// <value>
        /// The repository.
        /// </value>
        public VolarisPreviousPassangerRepository Repository { get; set; }

        /// <summary>
        /// Initializes the view.
        /// </summary>
        public void InitializeView()
        {

        }

        public void UpdateView(object modelObject)
        {

        }

        /// <summary>
        /// Sets the passanger.
        /// </summary>
        public void SetFare(VolarisPassangerFare fare)
        {
            View.BasePrice = fare.BasePrice.Total;
            View.PassangerCount = fare.Count.ToString(CultureInfo.InvariantCulture);
            View.Taxes = fare.TotalTaxes;
            View.PassangerType = fare.PassangerType;
            View.Total = fare.Total;


        }

        #endregion
    }
}
