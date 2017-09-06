using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyCTS.Presentation.Components
{
    public partial class ucTotalPricing : UserControl
    {
        public ucTotalPricing()
        {
            InitializeComponent();
        }

        public decimal TotalToPay
        {
            set { this.price.Text = value.ToString("c", new CultureInfo("es-mx")); }
        }
    }
}
