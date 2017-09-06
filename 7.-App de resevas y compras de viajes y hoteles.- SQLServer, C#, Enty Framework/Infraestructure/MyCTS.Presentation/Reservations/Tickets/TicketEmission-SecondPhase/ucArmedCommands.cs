using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Presentation.Components;


namespace MyCTS.Presentation
{
    public partial class ucArmedCommands : CustomUserControl, IProcessAsync
    {

        private static string negotiatedRate;
        public static string NegotiatedRate
        {
            get { return negotiatedRate; }
            set { negotiatedRate = value; }
        }

        private static string airline;
        public static string Airline
        {
            get { return airline; }
            set { airline = value; }
        }

        public ucArmedCommands()
        {
            InitializeComponent();
        }

        private void ucArmedCommands_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            commands_NegotiatedRate();
            if (!string.IsNullOrEmpty(ucTicketsEmissionInstructions.Airline))
            {
                commands_Airline();
            }
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_TOUR_CODE);
        }

        void IProcessAsync.InitProcess()
        {
            commands_NegotiatedRate();
            if (!string.IsNullOrEmpty(ucTicketsEmissionInstructions.Airline))
            {
                commands_Airline();
            }
        }

        void IProcessAsync.EndProcess()
        {
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_TOUR_CODE);
        }





        #region===== MethodsClass =====

        private void commands_NegotiatedRate()
        {
            NegotiatedRate = string.Empty;
            if (!string.IsNullOrEmpty(ucTicketsEmissionInstructions.quaNegociated))
            {
                NegotiatedRate = string.Concat(NegotiatedRate, Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_P,
                    ucTicketsEmissionInstructions.quaNegociated);
            }
            else if (!string.IsNullOrEmpty(ucTicketsEmissionInstructions.corporateID))
            {
                NegotiatedRate = string.Concat(NegotiatedRate, Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_I,
                    ucTicketsEmissionInstructions.corporateID, ucTicketsEmissionInstructions.XC);
            }
            else if (!string.IsNullOrEmpty(ucTicketsEmissionInstructions.accountCode))
            {
                NegotiatedRate = string.Concat(NegotiatedRate, Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_AC_AST,
                 ucTicketsEmissionInstructions.accountCode, ucTicketsEmissionInstructions.XC);
            }
            else
            {
                NegotiatedRate = string.Empty;
            }
        }

        private void commands_Airline()
        {
            Airline = string.Empty;
            Airline = string.Concat(Airline, Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_A,
                ucTicketsEmissionInstructions.Airline);
        }

        #endregion

    }
}
