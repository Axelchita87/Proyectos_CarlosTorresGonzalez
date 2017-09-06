using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Business;
using MyCTS.Entities;
using System.Text.RegularExpressions;
using MyCTS.Forms.UI;

namespace MyCTS.Presentation
{
    public partial class ucQCperClient : CustomUserControl, IProcessAsync
    {
        //private string DKToSearch;
        string result = string.Empty;
        //******
        private string UC = string.Empty;
        //*****
        public ucQCperClient()
        {
            InitializeComponent();
        }

        private void ucQCperClient_Load(object sender, EventArgs e)
        {
            //frmPreloading fr = new frmPreloading(this);
            //fr.Show();
            ucAvailability.IsInterJetProcess = false;
            TODO();
        }

        void IProcessAsync.InitProcess()
        {
            TODO();
        }

        void IProcessAsync.EndProcess()
        {
            if (UC.Equals("ratingActualFAre"))
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_RATING_ACTUAL_FARE);
            else if (UC.Equals("welcome"))
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }

        private void TODO()
        {
            string corporativeqc = ucFirstValidations.CorporativeQualityControls[0].Attribute1;
            //if (corporativeqc.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_RADIUS))
            if (corporativeqc.Equals("TLM100") || corporativeqc.Equals("ADE100"))
                QCRadius();
            //else if (corporativeqc.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_DANONE))
            //    QCDanone();
            else
            {
                if (!string.IsNullOrEmpty(ucFirstValidations.PCC))
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_COMPARING_FARES);
                }
                else
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_RATING_ACTUAL_FARE);
                }
            }
            //else
            // UC = "ratingActualFAre";// 
            //Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_RATING_ACTUAL_FARE);
        }

        //Quality Controls for RADIUS
        private void QCRadius()
        {
            bool status = false;
            int row = 0;
            int col = 0;
            string QCAuthorized = ucFirstValidations.CorporativeQualityControls[0].QCAuthorized;

            if (QCAuthorized.Equals(Resources.TicketEmission.Constants.ACTIVE))
            {
                string sLabelQC = ucFirstValidations.CorporativeQualityControls[0].LabelQC;
                string send = string.Empty;


                send = Resources.TicketEmission.Constants.COMMANDS_AST_Q_CROSSLORRAINE;
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
                CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.RADIUS_QC_PASSED, ref row, ref col);
                if (row != 0 || col != 0)
                {
                    status = true;
                    row = 0;
                    col = 0;
                }
                if (!status)
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.NO_EXISTE_AUTORIZACION_CLIENTE_PARA_EMISION, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //UC = "welcome";// 
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
                //else
                //   //UC = "ratingActualFAre";// 
                //    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_RATING_ACTUAL_FARE);
                else
                {
                    if (!string.IsNullOrEmpty(ucFirstValidations.PCC))
                    {
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_COMPARING_FARES);
                    }
                    else
                    {
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_RATING_ACTUAL_FARE);
                    }
                }
            }
            else
            {
                //UC = "ratingActualFAre";// 
                //Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_RATING_ACTUAL_FARE);
                if (!string.IsNullOrEmpty(ucFirstValidations.PCC))
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_COMPARING_FARES);
                }
                else
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_RATING_ACTUAL_FARE);
                }
            }
        }
    }
}
