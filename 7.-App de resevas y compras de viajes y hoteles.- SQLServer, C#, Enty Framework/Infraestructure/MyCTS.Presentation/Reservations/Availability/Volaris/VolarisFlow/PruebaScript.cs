using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.VolarisFlow
{
    public partial class PruebaScript : Form
    {
        public PruebaScript()
        {
            InitializeComponent();
            webBrowser1.Navigate(@"http://201.149.13.14:5498/MyCTS/volaris.html");
        }

        private void PruebaScript_Load(object sender, EventArgs e)
        {
            if (webBrowser1.Document != null)
            {
                HtmlDocument doc = webBrowser1.Document;
                String str = doc.InvokeScript("GetFingerPrint").ToString();
                VolarisSession.PagoVolaris.BlackBox = str;
            }
        }
    }
}
