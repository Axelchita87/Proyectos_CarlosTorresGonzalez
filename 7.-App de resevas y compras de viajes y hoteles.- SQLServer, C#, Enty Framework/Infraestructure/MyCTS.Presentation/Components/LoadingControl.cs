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
    public partial class LoadingControl : UserControl
    {
        public LoadingControl()
        {
            InitializeComponent();
        }

        public Image ImageToShow
        {
            get { return this.airPlaneLoadingPicture.Image; }
            set { this.airPlaneLoadingPicture.Image = value; }
        }

        public string MessageToShow
        {

            get { return this.msgToShowLabel.Text; }
            set { this.msgToShowLabel.Text = value; }
        }


    }
}
