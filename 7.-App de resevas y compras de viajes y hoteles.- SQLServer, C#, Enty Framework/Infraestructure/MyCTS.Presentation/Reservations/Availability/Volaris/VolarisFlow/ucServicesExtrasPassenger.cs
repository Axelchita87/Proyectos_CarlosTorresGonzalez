using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Entities;
using MyCTS.Presentation.Reservations.Availability.Volaris.Handler;

namespace MyCTS.Presentation
{
    public partial class ucServicesExtrasPassenger : CustomUserControl
    {
        private VolarisServicesExtrasUserControlHandler _handler;

        /// <summary>
        /// Gets the handler.
        /// </summary>
        private VolarisServicesExtrasUserControlHandler Handler
        {
            get
            {
                return this._handler ?? (this._handler = new VolarisServicesExtrasUserControlHandler
                {
                    UserControl = this,

                });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private InterJetPassangerType _paxType;
        /// <summary>
        /// Gets or sets the type of the passanger.
        /// </summary>
        /// <value>
        /// The type of the passanger.
        /// </value>
        public InterJetPassangerType PassangerType
        {
            get
            {
                return this._paxType;
            }
            set
            {
                this._paxType = value;
                if (this._paxType == InterJetPassangerType.Child)
                {
                    this.IsAChild = true;
                }
            }
        }

        private VolarisServicesExtras _servicioExtra;

        public VolarisServicesExtras ServicioExtra
        {
            get { return _servicioExtra; }
            set { _servicioExtra = value; }
        }

        public bool IsAChild
        {
            get;
            set;
        }

        public string PassangerID
        {
            get;
            set;
        }

        public string GroupBoxTitle
        {
            set
            {
                this.groupBoxServicesExtras.Text = value;
            }
            get
            {
                return this.groupBoxServicesExtras.Text;
            }
        }

        public string LabelDeparture
        {
            set
            {
                this.lblDepartureRute.Text = value;
            }
            get
            {
                return this.lblDepartureRute.Text;
            }
        }

        public string LabelArrival
        {
            set
            {
                this.lblArrivalRute.Text = value;
            }
            get
            {
                return this.lblArrivalRute.Text;
            }
        }

        public string TextPax
        {
            set
            {
                this.lblPax.Text = value;
            }
            get
            {
                return this.lblPax.Text;
            }
        }

        public ucServicesExtrasPassenger()
        {
            InitializeComponent();
        }

        public KeyEventHandler KeyEventHandler
        {
            set
            {
                this.chkDeparture.KeyDown += value;
                this.chkArrival.KeyDown += value;
            }
        }

        //private InterJetPassanger passanger;
        /// <summary>
        /// Gets or sets the passanger.
        /// </summary>
        /// <value>
        /// The passanger.
        /// </value>
        //public InterJetPassanger Passanger
        //{
        //    get
        //    {
        //        this.passanger = this.Handler.GetServicesExtras();
        //        return this.passanger;
        //    }
        //    set
        //    {
        //        if (value != null)
        //        {
        //            this.passanger = value;
        //            this.Handler.SetInterJetPassanger(this.passanger);
        //        }
        //    }
        //}

        private VolarisServicesExtras extras;
        public VolarisServicesExtras Extras
        {
            get
            {
                this.extras = this.Handler.GetServicesExtras();
                return this.extras;
            }
            set
            {
                if (value != null)
                {
                    this.extras = value;
                    //this.Handler.SetInterJetPassanger(this.extras);
                }
            }
        }

        private void ucServicesExtrasPassenger_Load(object sender, EventArgs e)
        {
           this.Handler.Initialize();
        }
    }
}
