using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.FlightConfirmation.PassangerConfirmation
{
    public partial class ucVolarisPasssangerName : UserControl
    {
        public ucVolarisPasssangerName()
        {
            InitializeComponent();
        }

        public string PassangerName
        {
            get { return this.labelControl1.Text; }
            set { this.labelControl1.Text = value.ToUpper(); }
        }
    }
}
