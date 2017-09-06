using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.ReservationPreviewExpander
{
    public partial class ucVolarisReservationExpander : CustomUserControl
    {
        public ucVolarisReservationExpander()
        {
            InitializeComponent();

        }

        public Control ControlToDisplay
        {

            set
            {
                this.popupContainerControl1.Controls.Add(value);
            }
        }
        public DevExpress.XtraEditors.Controls.CloseUpEventHandler CloseUpEventHandler
        {
            get { return null; }
            set { popupContainerEdit1.CloseUp += value; }
        }

        public EventHandler PopupEventHandler
        {
            get { return null; }
            set { popupContainerEdit1.Popup += value; }
        }
    }
}
