using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PreviousReservationResume.PassangerResume
{
    public partial class ucVolarisPreviousPassangersResume : CustomUserControl, IVolarisPreviousPassangersResumeView
    {
        private readonly VolarisPreviousPassangerResumePresenter _presenter;
        public ucVolarisPreviousPassangersResume()
        {
            InitializeComponent();
            _presenter = new VolarisPreviousPassangerResumePresenter()
                             {
                                 Repository = new ucVolarisPreviousPassangersResumeRepository(),
                                 View = this
                             };

        }

        #region Miembros de IVolarisPreviousPassangersResumeView

        /// <summary>
        /// Sets the passanger.
        /// </summary>
        /// <param name="passangers">The passangers.</param>
        /// <param name="paxWithNames">if set to <c>true</c> [pax with names].</param>
        public void SetPassanger(VolarisPassangers passangers,bool paxWithNames)
        {
            if (!paxWithNames)
            {
                _presenter.SetPassanger(passangers);
            }else
            {
                SetPassangerNames(passangers);
            }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <param name="pax">The pax.</param>
        /// <returns></returns>
        private string GetType(IVolarisPassanger pax)
        {
            if(pax is VolarisAdultPassanger)
            {
                return "ADT";
            }
            if(pax is VolarisChildPassanger)
            {
                return "Menor";
            }

            if(pax is VolarisInfantPassanger)
            {
                return "Inf";
            }
            return string.Empty;
        }

        /// <summary>
        /// Sets the passanger names.
        /// </summary>
        /// <param name="passangers">The passangers.</param>
        private void SetPassangerNames(VolarisPassangers passangers)
        {

            if (passangers.GetAll().Any())
            {
                foreach (var pax in passangers.GetAll())
                {
                    int columnIndex = container.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                    container.Controls.Add(new ucVolarisPassangerTypeResume
                    {
                        PaxCounter = string.Empty,
                        PaxTypeString = pax.FullName
                    }, columnIndex, 0);
                }
            }
        }




        #endregion

        #region Miembros de IBaseView


        public void ValidateInput()
        {

        }

        public bool IsValid { get; set; }

        #endregion




        #region Miembros de IVolarisPreviousPassangersResumeView


        /// <summary>
        /// Sets the adult passanger.
        /// </summary>
        /// <param name="passangerCount">The passanger count.</param>
        public void SetAdultPassanger(int passangerCount)
        {
            SetPassanger(passangerCount, "Adulto(s)");

        }

        /// <summary>
        /// Sets the passanger.
        /// </summary>
        /// <param name="passangerCounter">The passanger counter.</param>
        /// <param name="passangerType">Type of the passanger.</param>
        private void SetPassanger(int passangerCounter, string passangerType)
        {

            int columnIndex = container.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            container.Controls.Add(new ucVolarisPassangerTypeResume
            {
                PaxCounter = passangerCounter.ToString(CultureInfo.InvariantCulture),
                PaxTypeString = passangerType
            }, columnIndex, 0);


        }

        /// <summary>
        /// Sets the child passanger.
        /// </summary>
        /// <param name="passangerCount">The passanger count.</param>
        public void SetChildPassanger(int passangerCount)
        {
            SetPassanger(passangerCount, "Menor(es)");
        }

        /// <summary>
        /// Sets the infant passanger.
        /// </summary>
        /// <param name="passangerCount">The passanger count.</param>
        public void SetInfantPassanger(int passangerCount)
        {
            SetPassanger(passangerCount, "Infante(s)");
        }

        #endregion
    }
}
