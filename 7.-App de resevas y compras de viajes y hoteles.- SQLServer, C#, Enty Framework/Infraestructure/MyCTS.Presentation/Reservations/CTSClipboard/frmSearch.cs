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
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            string panelName = "mainPanel";
            string userControlName = "ucSearch";
            Control[] controls = this.Controls.Find(panelName, true);
            if (controls[0].Controls.Count > 0)
            {
                if (controls[0].Controls[0] is CustomUserControl)
                    ((CustomUserControl)controls[0].Controls[0]).Dispose();
            }

            CustomUserControl cu = (CustomUserControl)Loader.GetReferenceUserControl(userControlName);
            controls[0].Controls.Add(cu);
        }

        private void frmSearch_Shown(object sender, EventArgs e)
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
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                         (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
        }
    }
}
