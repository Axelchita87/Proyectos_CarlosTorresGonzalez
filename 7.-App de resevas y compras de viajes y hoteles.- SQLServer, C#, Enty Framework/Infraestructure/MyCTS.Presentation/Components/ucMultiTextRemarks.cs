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
    public partial class ucMultiTextRemarks : UserControl
    {
        public ucMultiTextRemarks()
        {
            InitializeComponent();
        }

        private int lastCtrlLocation = 60+29;

        private void button1_Click(object sender, EventArgs e)
        {
            LineTextRemark lineSmart = new LineTextRemark();
            Panel pnl1 = (Panel)this.Controls.Find("panel1", false)[0];
            lineSmart.Location = new System.Drawing.Point(1, lastCtrlLocation);
            lineSmart.Focus();
            panel1.Controls.Add(lineSmart);

            //lastCtrlLocation += 29;
        }
    }
}
