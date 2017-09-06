using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PreviousReservationResume.PassangerResume
{
    public partial class ucVolarisPassangerTypeResume : UserControl
    {
        public ucVolarisPassangerTypeResume()
        {
            InitializeComponent();
        }

        public string PaxTypeString
        {
            get { return this.paxType.Text; }
            set { this.paxType.Text = value; }
        }

        public string PaxCounter
        {
            get { return this.paxCount.Text; }
            set { this.paxCount.Text = value; }
        }
    }
}
