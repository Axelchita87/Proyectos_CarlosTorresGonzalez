using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyCTS.Presentation.Components
{
    public partial class WaitingForControls : UserControl
    {
        public WaitingForControls()
        {
            InitializeComponent();
        }


        public string MessageToShow 
        {get { return this.label1.Text; }
        set { this.label1.Text = value; }}
    }
}
