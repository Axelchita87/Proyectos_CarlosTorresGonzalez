using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Business;
using MyCTS.Entities;

namespace MyCTS.Presentation
{
    public partial class ucPresentRecord : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Validamos si existe Fase IV,pertenece a Emitir Boleto
        /// Creación:    9/Junio/09 , Modificación:15/Junio/09
        /// Cambio:      Ya no verficiar si hay un Record Presente  , Solicito Guillermo
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        #region ======== Declaration of Variable =======

        private static string answer;
        public static string Answer
        {
            get { return answer; }
            set { answer = value; }
        }

        private static bool presentrecord;
        public static bool PresentRecord
        {
            get { return presentrecord; }
            set { presentrecord = value; }
        }

        private static bool phase_iv;
        public static bool Phase_IV
        {
            get { return phase_iv; }
            set { phase_iv = value; }
        }

        string send = string.Empty;
        string result = string.Empty;

        #endregion

        public ucPresentRecord()
        {
            InitializeComponent();
        }

        //User Control Load
        private void ucPresentRecord_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            validation_PhaseIV();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTICKETSEMISSIONINSTRUCTIONS);
        }

        /// <summary>
        /// Se envia un commando para verficiar si existe un Record Presente
        /// actualmente ya no se ocupa
        /// </summary>
        private void validation_recordPresent()
        {
            Answer = result;
            PresentRecord = false;
            int row = 0;
            int col = 0;
            send = Resources.TicketEmission.Constants.COMMANDS_AST_N_AST_IA_AST_INDENT;
            using (CommandsAPI objCommands = new CommandsAPI())
            {
                result = objCommands.SendReceive(send);
            }
            CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.NO_ITIN, ref row, ref col);
            if (row != 0 || col != 0)
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.NO_RECORD_PRESENTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PresentRecord = true;
                row = 0;
                col = 0;
            }
            CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.NO_NAMES, ref row, ref col);
            if (row != 0 || col != 0)
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.REQUIREN_NOMBRES_RECORD_EMITIR_BOLETO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PresentRecord = true;
                row = 0;
                col = 0;
            }
            if (PresentRecord)
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
        }

        /// <summary>
        /// Se envia un comando y se buscan dos etiquetas si no se encuentran
        /// es que existe Fase IV en el Record
        /// </summary>
        private void validation_PhaseIV()
        {
            Answer = result;
            phase_iv = true;
            int row = 0;
            int col = 0;

            send = Resources.TicketEmission.Constants.COMMANDS_AST_AST_W;
            using (CommandsAPI objCommands = new CommandsAPI())
            {
                result = objCommands.SendReceive(send);
            }
            CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.NO_TKT_REC_EXISTS, ref row, ref col);
            if (row != 0 || col != 0)
            {
                row = 0;
                col = 0;
                phase_iv =false;
            }
            CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.TKT_REC_PRINTED_DELETED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                row = 0;
                col = 0;
                phase_iv = false;
            }
        }
    }
}
