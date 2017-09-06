using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Entities;

namespace MyCTS.Presentation
{
    public partial class ucEndRecordSuccess : CustomUserControl
    {
        public ucEndRecordSuccess()
        {
            InitializeComponent();
        }

        private void finalizeButton_Click(object sender, EventArgs e)
        {  
            ucServicesFeePayApply.OrigenTipo = ChargesPerService.OrigenTipoCargo.BajoCosto;
            VolarisSession.Clean();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCSERVICESFEEPAYAPPLY);
        }

        private void suggestButton_Click(object sender, EventArgs e)
        {
            VolarisSession.Clean();
            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucWelcome", null);
        }
    }
}
