using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucFareSoldJustification : CustomUserControl
    {
        public ucFareSoldJustification()
        {
            InitializeComponent();
        }

        private void ucFareSoldJustification_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            string CorporativeQC = activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1;
            string FareSoldJustification = activeStepsCorporativeQC.CorporativeQualityControls[0].FareJustification;
            if (FareSoldJustification.Equals(Resources.TicketEmission.Constants.ACTIVE))
            {
                if (CorporativeQC.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_DANONE) || CorporativeQC.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_RADIUS))
                {
                    LoadJustifications();
                }
                else //if (CorporativeQC.Substring(0, 3).Equals("CTS"))
                {
                    if (!ucComparingFares.sameFare)
                    {
                        LoadJustificationsCTS();
                    }
                    else
                    {
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_CHARGESERVICE);
                    }
                }
                
            }
            else if (FareSoldJustification.Equals(Resources.TicketEmission.Constants.INACTIVE))
            {
                ucTicketsJustifications.TicketsJustifications = string.Empty;
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_CHARGESERVICE);
            }

        }
        private void LoadJustifications()
        {
            string ActualDK = ucFirstValidations.DK;
            List<DKTemp> listDKTemp = DKTempBL.GetDKTemp(ActualDK,false);
            string[] sendInfo = new string[] { ActualDK };
            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_TICKETS_JUSTIFICATIONS, sendInfo);
        }

        private void LoadJustificationsCTS()
        {
            string ActualDK = Resources.TicketEmission.Constants.DK_CTS_API_100;
            List<DKTemp> listDKTemp = DKTempBL.GetDKTemp(ActualDK, false);
            string[] sendInfo = new string[] { ActualDK };
            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_TICKETS_JUSTIFICATIONS, sendInfo);
        }
    }
}
