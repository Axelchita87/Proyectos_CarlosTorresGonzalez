using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MyCTS.Presentation.Reservations.Availability.LowFareAvailability.ModifyFlightSearch
{
    public partial class ucVolairsModifyFlightSearch : UserControl
    {
        public ucVolairsModifyFlightSearch()
        {
            InitializeComponent();
        }

        public PopupContainerEdit PopUpControl { get { return this.popupContainerEdit1; } }

        public LowFareAvailabilitySearch ContainerControl
        {
            
            get
            {

                var control = this.popupContainerControl1.Controls.OfType<LowFareAvailabilitySearch>().FirstOrDefault();
                if (control != null)
                {
                    return control;
                }
                return new LowFareAvailabilitySearch();
            }
            set
            {

                if (value != null)
                {
                    popupContainerControl1.AutoSize = true;
                    value.Dock = DockStyle.Fill;
                    
                    this.popupContainerControl1.Controls.Add(value);
                }
            }
        }

    }
}
