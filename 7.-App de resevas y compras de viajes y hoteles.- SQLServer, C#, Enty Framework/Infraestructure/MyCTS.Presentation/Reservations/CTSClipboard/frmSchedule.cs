using MyCTS.Presentation.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyCTS.Presentation
{
    public partial class frmSchedule : Form
    {
        public frmSchedule()
        {
            InitializeComponent();
        }

        private void frmSchedule_Load(object sender, EventArgs e)
        {
            string panelName = "mainPanel";
            string userControlName = "ucSchedule";
            Control[] controls = this.Controls.Find(panelName, true);
            if (controls[0].Controls.Count > 0)
            {
                if (controls[0].Controls[0] is CustomUserControl)
                    ((CustomUserControl)controls[0].Controls[0]).Dispose();
            }

            CustomUserControl cu = (CustomUserControl)Loader.GetReferenceUserControl(userControlName);
            controls[0].Controls.Add(cu);
        }

        private void frmSchedule_Shown(object sender, EventArgs e)
        {
            CustomUserControl clr = (CustomUserControl)((Control)mainPanel.Controls[0]);
            this.Width = clr.Width + 40;
            this.Height = clr.Height + 40;
            mainPanel.Width = clr.Width + 20;
            mainPanel.Height = clr.Height + 20;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainPanel.AutoSize = true;
            mainPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
    }
}
