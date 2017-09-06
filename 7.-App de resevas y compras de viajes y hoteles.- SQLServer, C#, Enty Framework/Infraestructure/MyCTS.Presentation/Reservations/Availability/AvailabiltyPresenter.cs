using MyCTS.Presentation.Base;

namespace MyCTS.Presentation.Reservations.Availability
{
    public class AvailabiltyPresenter : IBasePresenter<IAvailabilityView, AvailabilityRepository>
    {

        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        /// <value>
        /// The view.
        /// </value>
        public IAvailabilityView View { get; set; }

        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        /// <value>
        /// The repository.
        /// </value>
        public AvailabilityRepository Repository { get; set; }

        /// <summary>
        /// Initializes the view.
        /// </summary>
        public void InitializeView()
        {

        }

        /// <summary>
        /// Updates the view.
        /// </summary>
        /// <param name="modelObject">The model object.</param>
        public void UpdateView(object modelObject)
        {

        }

        /// <summary>
        /// Searches the flights.
        /// </summary>
        public void SearchFlights()
        {
            View.ValidateInput();
            if (View.IsValid)
            {
                View.GotToNexStep();
            }

        }




    }
}
