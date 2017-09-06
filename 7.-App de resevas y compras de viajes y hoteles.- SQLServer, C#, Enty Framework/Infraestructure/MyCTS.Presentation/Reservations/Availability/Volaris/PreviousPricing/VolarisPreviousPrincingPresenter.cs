using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Presentation.Base;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PreviousPricing
{
    /// <summary>
    /// 
    /// </summary>
    public class VolarisPreviousPrincingPresenter : IBasePresenter<VolarisPreviousPrincingView, VolarisPreviousPrincingRespository>
    {
        #region Miembros de IBasePresenter<VolarisPreviousPrincingView,VolarisPreviousPrincingRespository>

        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        /// <value>
        /// The view.
        /// </value>
        public VolarisPreviousPrincingView View { get; set; }

        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        public IProcessContext<VolarisReservation> Context { get; set; }

        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        /// <value>
        /// The repository.
        /// </value>
        public VolarisPreviousPrincingRespository Repository { get; set; }

        /// <summary>
        /// Initializes the view.
        /// </summary>
        public void InitializeView()
        {

        }

        public void UpdateView(object modelObject)
        {

        }


        public void BuildDynamicControls()
        {

            Context.Resolve(View.Reservation);
        }


        public void Initialize()
        {
            InitializeView();
        }
        #endregion
    }
}
