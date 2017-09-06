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
    public partial class WarningMessage : UserControl
    {
        public WarningMessage()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Visible = !pictureBox1.Visible;
        }

        private void WarningMessage_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        public string Record
        {
            set { record.Text = value; }
        }
    }
}
