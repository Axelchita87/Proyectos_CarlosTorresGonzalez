using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucBusinessUnit : CustomUserControl
    {

        private static string businessunit;
        public static string BusinessUnit
        {
            get { return businessunit; }
            set { businessunit = value; }
        }
        private static string origin;
        public static string Origin
        {
            get { return origin; }
            set { origin = value; }
        }


        private string IDBusinessUnit;


        public ucBusinessUnit()
        {
            ucAvailability.IsInterJetProcess = false;
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = dgvJustifications;
            this.LastControlFocus = btnAccept;
        }
        

        //User Control Load
        private void ucBusinessUnit_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = CatBusinessUnitsBL.GetBusinessUnits();
            dgvJustifications.Focus();
            rdoEnterpricePolicy.Checked = true;
        }


        //Button Accept
        private void btnAccept_Click(object sender, EventArgs e)
        {
            string send=Resources.TicketEmission.Constants.COMMANDS_FIVE_DOT_OV_INDENT;
            IDBusinessUnit = string.Empty;
            BusinessUnit = string.Empty;
            origin = string.Empty;

            int index = dgvJustifications.CurrentCell.RowIndex;
            CatBusinessUnits obj = dgvJustifications.Rows[index].DataBoundItem as CatBusinessUnits;
            IDBusinessUnit = obj.IDBusinessUnits.ToString();

            BusinessUnit = Resources.TicketEmission.Constants.COMMANDS_FIVE_DOT_UN_INDENT + IDBusinessUnit; //+


           if (rdoEnterpricePolicy.Checked)
               send= string.Concat(send,Resources.TicketEmission.Constants.COMMANDS_POLEM);
           if (rdoTouristBulletin.Checked)
               send = string.Concat(send, Resources.TicketEmission.Constants.COMMANDS_BOLETIN);
           if (rdoEmail.Checked)
               send = string.Concat(send, Resources.TicketEmission.Constants.COMMANDS_CORREO);
           if (rdoCustomerRecommendation.Checked)
               send = string.Concat(send, Resources.TicketEmission.Constants.COMMANDS_RECO);
           if (rdoHumanResources.Checked)
               send = string.Concat(send, Resources.TicketEmission.Constants.COMMANDS_RH);
           origin = send;

           Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCPRESENT_RECORD);

        }

        //Double Click
        private void dgvJustifications_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvJustifications.CurrentCell.RowIndex;
            CatBusinessUnits obj = dgvJustifications.Rows[index].DataBoundItem as CatBusinessUnits;
            IDBusinessUnit = obj.IDBusinessUnits.ToString();
        }
        //dgvJustifications_KeyDown event
        private void dgvJustificationsTab_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                string dk = ucFirstValidations.DK;
                dk = dk.Substring(3, 3);
                string Corporative = activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1;
                string chargePerService = activeStepsCorporativeQC.CorporativeQualityControls[0].ChargePerService;
                string FareSoldJustification = activeStepsCorporativeQC.CorporativeQualityControls[0].FareJustification;
                if (dk == Resources.TicketEmission.ValitationLabels.NUMBER_990)
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCBILLINGADRESS);
                }
                else if (!Corporative.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_RADIUS))
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_COSTCENTER);
                }
                else if (chargePerService.Equals(Resources.TicketEmission.Constants.ACTIVE))
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_CHARGESERVICE);
                }
                else if (FareSoldJustification.Equals(Resources.TicketEmission.Constants.ACTIVE))
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_FARE_SOLD_JUSTIFICATION);
                }
                else
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
            }
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }

            if (e.KeyCode.Equals(Keys.Tab))
            {
                rdoEnterpricePolicy.Focus();
            }
        }

        //dgvJustifications_KeyDown event
        private void dgvJustifications_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                string dk = ucFirstValidations.DK;
                dk = dk.Substring(3, 3);
                string Corporative = activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1;
                string chargePerService = activeStepsCorporativeQC.CorporativeQualityControls[0].ChargePerService;
                string FareSoldJustification = activeStepsCorporativeQC.CorporativeQualityControls[0].FareJustification;
                if (dk == Resources.TicketEmission.ValitationLabels.NUMBER_990)
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCBILLINGADRESS);
                }
                else if (!Corporative.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_RADIUS))
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_COSTCENTER);
                }
                else if (chargePerService.Equals(Resources.TicketEmission.Constants.ACTIVE))
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_CHARGESERVICE);
                }
                else if (FareSoldJustification.Equals(Resources.TicketEmission.Constants.ACTIVE))
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_FARE_SOLD_JUSTIFICATION);
                }
                else
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
            }
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }
        }

        
    }
}
