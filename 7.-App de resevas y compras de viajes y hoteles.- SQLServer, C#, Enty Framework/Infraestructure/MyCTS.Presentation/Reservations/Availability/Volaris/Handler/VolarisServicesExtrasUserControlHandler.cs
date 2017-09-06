using MyCTS.Entities;
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.Handler
{
    public class VolarisServicesExtrasUserControlHandler : InterJetUserControlHandler
    {
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            SetTooltips();

        }

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<InterJetPassangerType, Func<InterJetPassanger>> _passangerFactory;

        /// <summary>
        /// Gets the passanger factory.
        /// </summary>
        private Dictionary<InterJetPassangerType, Func<InterJetPassanger>> PassangerFactory
        {
            get
            {
                if (this._passangerFactory == null)
                {
                    this._passangerFactory = new Dictionary<InterJetPassangerType, Func<InterJetPassanger>>();
                    this._passangerFactory.Add(InterJetPassangerType.Adult, () => new InterJetAdultPassanger());
                    this._passangerFactory.Add(InterJetPassangerType.Child, () => new InterJetChildPassanger());
                    this._passangerFactory.Add(InterJetPassangerType.Senior, () => new InterJetSeniorAdultPassanger());

                }
                return this._passangerFactory;
            }
        }

        /// <summary>
        /// Gets the current user control.
        /// </summary>
        private ucServicesExtrasPassenger CurrentUserControl
        {
            get
            {
                return this.UserControl as ucServicesExtrasPassenger;
            }
        }

        /// <summary>
        /// Gets the session.
        /// </summary>
        private Hashtable Session
        {
            get
            {
                var session = (InterJetSession)this.CurrentUserControl.Parameter;
                if (session != null)
                {
                    return session.Session;
                }
                return new Hashtable();
            }
        }

        /// <summary>
        /// OBtiene el pasajero y valida la selección.
        /// </summary>
        /// <returns></returns>
        //public InterJetPassanger GetPassanger()
        //{
        //    InterJetPassanger pax = this.PassangerFactory[this.CurrentUserControl.PassangerType]();

        //    CheckBox chkDeparture = this.GetCheckBoxByName("Departure");
        //    pax.Departure = chkDeparture.Checked;


        //    CheckBox chkArrival = this.GetCheckBoxByName("Arrival");
        //    pax.Arrival = chkArrival.Checked;

        //    return pax;
        //}

        public VolarisServicesExtras GetServicesExtras()
        {
            VolarisServicesExtras extra = new VolarisServicesExtras();
            Label nameLabel = this.GetLabelByName("lblPax");
            extra.NamePax = nameLabel.Text;

            Label departureLabel = this.GetLabelByName("lblDepartureRute");
            extra.Departure = departureLabel.Text;

            CheckBox departureBox = this.GetCheckBoxByName("chkDeparture");
            extra.DepartureService = departureBox.Checked;

            Label arrivalLabel = this.GetLabelByName("lblArrivalRute");
            extra.Arrival = arrivalLabel.Text;

            CheckBox arrivalCheckBox = this.GetCheckBoxByName("chkArrival");
            extra.ArrivalService = arrivalCheckBox.Checked;

            GroupBox tipoExtra = this.GetGroupBoxByName("groupBoxServicesExtras");
            extra.TipoServicio = tipoExtra.Text;

            return extra;
        }

        /// <summary>
        /// Gets the passanger ID.
        /// </summary>
        private string PassangerID
        {
            get
            {
                return this.CurrentUserControl.PassangerID;
            }
        }

        /// <summary>
        /// Sets the inter jet passanger.
        /// </summary>
        /// <param name="passanger">The passanger.</param>
        public void SetInterJetPassanger(InterJetPassanger passanger)
        {
            CheckBox chkDeparture = this.GetCheckBoxByName("Departure");
            chkDeparture.Checked = passanger.Departure;

            CheckBox chkArrival = this.GetCheckBoxByName("Arrival");
            chkArrival.Checked = passanger.Arrival;

        }

        /// <summary>
        /// Sets the tooltips.
        /// </summary>
        private void SetTooltips()
        {
            CheckBox chkDeparture = this.GetCheckBoxByName("Departure");
            CheckBox chkArrival = this.GetCheckBoxByName("Arrival");
        }
    }
}
