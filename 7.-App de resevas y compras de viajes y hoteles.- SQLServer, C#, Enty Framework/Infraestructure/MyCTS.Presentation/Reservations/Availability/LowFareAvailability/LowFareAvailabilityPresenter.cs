using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Presentation.Base;
using MyCTS.Presentation.Reservations.Availability.LowFareAvailability.ContextSolvers;
using MyCTS.Presentation.Reservations.Availability.LowFareAvailability.EventArguments;
using MyCTS.Presentation.Reservations.Availability.LowFareAvailability.Services;
using MyCTS.Presentation.Components;
using MyCTS.Services.Contracts;

namespace MyCTS.Presentation.Reservations.Availability.LowFareAvailability
{
    public class LowFareAvailabilityPresenter : IBasePresenter<LowFareAvailabilityView, LowFareAvailabilityRepository>
    {



        /// <summary>
        /// Initializes a new instance of the <see cref="LowFareAvailabilityPresenter"/> class.
        /// </summary>
        public LowFareAvailabilityPresenter()
        {

            ServiceHandler = new LowFareWinFormServiceHandler
                                 {


                                 };

        }
        #region Miembros de IBasePresenter<LowFareAvailabilityView,LowFareAvailabilityRepository>

        public IProcessContext<Flights> Context { get; set; }

        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        /// <value>
        /// The repository.
        /// </value>
        public LowFareAvailabilityRepository Repository { get; set; }

        /// <summary>
        /// Gets or sets the service handler.
        /// </summary>
        /// <value>
        /// The service handler.
        /// </value>
        public Base.IServiceHandler<Flights> ServiceHandler { get; set; }


        /// <summary>
        /// Initializes the view.
        /// </summary>
        public void InitializeView()
        {

        }

        /// <summary>
        /// Calls the service.
        /// </summary>
        public void CallService()
        {
            ServiceHandler.CallService();
        }

        /// <summary>
        /// Updates the view.
        /// </summary>
        /// <param name="modelObject">The model object.</param>
        public void UpdateView(object modelObject)
        {

        }


        public void BuildDynamicControls(Flights flights)
        {

            Context = new DynamicLowFareWinFormControlBuilder()
                          {
                              OnDynamicControlsBuilt = OnDynamicControlsBuiltDelegate
                          };
            Context.Resolve(flights);

        }

        private void OnDynamicControlsBuiltDelegate(object sender, OnDynamicControlsBuiltEventArgs e)
        {
            if (OnDynamicControlsBuilt != null)
            {
                OnDynamicControlsBuilt(sender, e);
            }
        }


        /// <summary>
        /// Nexts the step.
        /// </summary>
        public void NextStep()
        {

            View.ValidateInput();
            if (View.IsValid)
            {
                View.GoToNextStep();
            }
        }

        /// <summary>
        /// Goes the back.
        /// </summary>
        public void GoBack()
        {

        }
        #endregion

        #region Miembros de IBasePresenter<LowFareAvailabilityView,LowFareAvailabilityRepository>

        public LowFareAvailabilityView View { get; set; }
        public EventHandler<OnDynamicControlsBuiltEventArgs> OnDynamicControlsBuilt { get; set; }

        #endregion
    }
}
