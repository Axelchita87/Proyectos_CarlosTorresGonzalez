using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrightIdeasSoftware;
using DevExpress.XtraEditors.DXErrorProvider;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.LowFareAvailability.Container;

namespace MyCTS.Presentation
{
    public partial class ucLowFareAvailabilityContainer : CustomUserControl, ILowFareAvailabilityViewContainer
    {
        private readonly LowFareAvailabilityPresenterContainer _presenter;
        public ucLowFareAvailabilityContainer()
        {
            InitializeComponent();
            _presenter = new LowFareAvailabilityPresenterContainer();


        }

        /// <summary>
        /// Configures the object lis view.
        /// </summary>
        private void ConfigureObjectLisView()
        {

            var headerFormatStyle = new HeaderFormatStyle
            {
                Normal = new HeaderStateStyle
                             {
                                 Font = new Font("Calibri", 9F, FontStyle.Bold, GraphicsUnit.Point, 0)

                             }
            };
            container.HeaderFormatStyle = headerFormatStyle;
            container.CellToolTip.HasBorder = true;
            container.CellToolTip.IsBalloon = true;
            container.CellToolTip.InitialDelay = 0;
            container.CellToolTip.StandardIcon = ToolTipControl.StandardIcons.Info;
            container.CellToolTip.Title = "Detalles de vuelo";
            container.CellToolTip.Font = new Font("Microsoft Sans Serif", 7.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            
            CompanyName.ImageGetter += (row) =>
                                           {
                                               var flight = (IFlight)row;
                                               if (flight.OwnerCompany.Equals("InterJet"))
                                               {
                                                   return 0; // indice de posicion en el imageList
                                               }
                                               if (flight.OwnerCompany.Equals("Volaris"))
                                               {
                                                   return 1;// indice de posicion en el imageList
                                               }

                                               return "";

                                           };

            container.CellToolTipShowing += container_CellToolTipShowing;
        }



        /// <summary>
        /// Handles the CellToolTipShowing event of the container control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="BrightIdeasSoftware.ToolTipShowingEventArgs"/> instance containing the event data.</param>
        void container_CellToolTipShowing(object sender, ToolTipShowingEventArgs e)
        {
            var flight = (IFlight)e.Model;
            e.Text = flight.Segments.DescriptionForToolTip;


        }
        #region Miembros de ILowFareAvailabilityViewContainer

        public bool IsValid { get; set; }

        public static bool Valid { get; set; }

        public string Itinerary
        {
            get
            {
                return this.itinerary.Text;
            }
            set { this.itinerary.Text = value; }
        }

        public string Date
        {
            get
            {
                return this.dateString.Text;
            }
            set { this.dateString.Text = value; }
        }

        /// <summary>
        /// Gets or sets the fligths.
        /// </summary>
        /// <value>
        /// The fligths.
        /// </value>
        public List<IFlight> Fligths
        {
            get
            {

                var fligthsItems = (this.container.Objects as List<IFlight>);
                return fligthsItems;
            }
            set
            {
                if (value != null)
                {
                    this.container.SetObjects(value);
                    this.container.SortGroupItemsByPrimaryColumn = false;
                    this.container.Sorting = SortOrder.Ascending;
                }
            }
        }

        /// <summary>
        /// Gets or sets the selected flight.
        /// </summary>
        /// <value>
        /// The selected flight.
        /// </value>
        public IFlight SelectedFlight { get; set; }

        /// <summary>
        /// Filters the name of the by company.
        /// </summary>
        /// <param name="CompanyName">Name of the company.</param>
        public void FilterByCompanyName(string CompanyName)
        {
            container.ModelFilter = new ModelFilter((flight) => ((IFlight)flight).OwnerCompany.Equals(CompanyName));
        }



        /// <summary>
        /// Validates the input.
        /// </summary>
        public void ValidateInput()
        {
            ValidateSelectedFlight();
        }

        /// <summary>
        /// Validates the selected flight.
        /// </summary>
        private void ValidateSelectedFlight()
        {
            IsValid = SelectedFlight != null;

            if (!IsValid)
            {
                SetError(new Exception(string.Format("Por favor seleccióne un vuelo de {0}.", _typeItinerary)));
                Valid = true;
            }
        }



        public void SetError(string error)
        {
            SetError(new Exception(error));
            IsValid = false;
        }


        #endregion
        /// <summary>
        /// Handles the Load event of the ucLowFareAvailabilityContainer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ucLowFareAvailabilityContainer_Load(object sender, EventArgs e)
        {
            _presenter.View = this;
            _presenter.Repository = new LowFareAvailabilityRepositoryContainer();
            ConfigureObjectLisView();
            _presenter.Initialize();
            _presenter.SetFlights();
        }
        /// <summary>
        /// Sets the fligths.
        /// </summary>
        /// <param name="flights">The flights.</param>
        public void SetFligths(List<IFlight> flights)
        {
            _presenter.SetFligths(flights);

        }


        #region Miembros de ILowFareAvailabilityViewContainer


        public AvailabilityRequest AvailabilityRequest { get; set; }

        #endregion

        #region Miembros de ILowFareAvailabilityViewContainer


        private void SetControlError(Label label)
        {
            ErrorProvider.SetError(label, "Importante");
            ErrorProvider.SetIconAlignment(label, ErrorIconAlignment.TopLeft);

        }

        /// <summary>
        /// Sets the error.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public void SetError(Exception exception)
        {
            var errors = this.errorPanel.Controls.OfType<Label>();

            if (errors.Any())
            {

            }
            else
            {

                const int xDefaultPosition = 18;
                const int yDefaultPosition = 4;
                var label = new Label()
                                {
                                    Text = exception.Message,
                                    Location = new Point
                                                   {
                                                       X = xDefaultPosition,
                                                       Y = yDefaultPosition
                                                   },
                                    Font = new Font("Microsoft Sans Serif", 6.75F, FontStyle.Bold, GraphicsUnit.Point, 0),
                                    AutoSize = true
                                };
                SetControlError(label);
                errorPanel.Controls.Add(label);


            }


        }

        #endregion

        #region Miembros de ILowFareAvailabilityViewContainer


        public void CleanError()
        {
            var errors = errorPanel.Controls.OfType<Label>();
            if (errors.Any())
            {
                foreach (var errorControl in errors)
                {
                    errorControl.Dispose();

                }

            }
        }

        #endregion

        #region Miembros de ILowFareAvailabilityViewContainer

        private string _typeItinerary;
        public string TypeItinerary
        {
            get { return _typeItinerary; }
            set
            {
                _typeItinerary = value;
                if (value.Equals("salida"))
                {
                    pictureBox1.Image = Properties.Resources.newDeparture;
                    flightType.Text = "vuelos de ida".ToUpper();

                }

                if (value.Equals("regreso"))
                {

                    pictureBox1.Image = Properties.Resources.newReturning;
                    flightType.Text = "vuelos de regreso".ToUpper();
                }


            }
        }

        #endregion

        private void container_SubItemChecking(object sender, SubItemCheckingEventArgs e)
        {
            CleanError();
            SelectedFlight = e.RowObject as IFlight;
            foreach (var flight in this.container.Objects)
            {
                container.UncheckSubItem(flight, selectedColumn);
            }
            e.NewValue = CheckState.Checked;
            
            if (OnSelectedFlight != null)
            {
                OnSelectedFlight(e.RowObject, new EventArgs());
            }
        }

        private void container_FormatCell(object sender, FormatCellEventArgs e)
        {
            if (SelectedFlight == null)
                if ((e.RowIndex % 2) == 0)
                    e.SubItem.BackColor = Color.White;
                else
                    e.SubItem.BackColor = Color.LightGray;
        }

        #region Miembros de ILowFareAvailabilityViewContainer


        public EventHandler OnSelectedFlight { get; set; }

        #endregion
    }
}
