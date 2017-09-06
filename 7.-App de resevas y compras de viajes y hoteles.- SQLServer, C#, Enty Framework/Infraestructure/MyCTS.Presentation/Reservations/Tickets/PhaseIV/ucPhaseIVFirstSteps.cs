using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucPhaseIVFirstSteps : CustomUserControl
    {

        /// <summary>
        /// Descripción: User control que realiza las primeras validaciones para la emisión de un boleto
        ///              de tipo fase IV por segmentos.
        /// Creación:    31 Agosto 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        /// 

        public ucPhaseIVFirstSteps()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Ejecucion de metodos para las primeras validaciones de la creacion de Fase IV
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucPhaseIVFirstSteps_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            if (!PresentRecordValidation)
            {
                ucPhaseIVCalculationLine.controlValues.Clear();
                ucPhaseIVCalculationLine_RVW.controlValues.Clear();
                ucPhaseIVBreakDown.previousValue = string.Empty;
                FindMaximum();
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_CREATE_PHASE_IV);
            }
            else
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }

        }

        #region===== MethodsClass =====

        /// <summary>
        ///  Validación de record presente en MySabre
        /// </summary>
        private bool PresentRecordValidation
        {
            get
            {
                bool isMessageShown = false;
                string send = string.Empty;
                string sabreAnswer = string.Empty;

                int col = 0;
                int row = 0;
                send = Resources.TicketEmission.Constants.COMMANDS_AST_N_AST_IA;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    sabreAnswer = objCommand.SendReceive(send);
                }

                CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.NO_NAMES, ref row, ref col);
                if (row != 0 || col != 0)
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.NO_NOMBRES_PRESENTES, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isMessageShown = true;
                    return isMessageShown;
                }

                CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.NO_ITIN, ref row, ref col);
                if (row != 0 || col != 0)
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.NO_RECORD_PRESENTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isMessageShown = true;
                    return isMessageShown;
                }

                return isMessageShown;
            }
        }


        /// <summary>
        /// Valida si existe la etiqueta MAXIMUM al enviar el comando WPNCS
        /// </summary>
        private void FindMaximum()
        {
            string send = string.Empty;
            string sabreAnswer = string.Empty;

            int col = 0;
            int row = 0;
            send = Resources.TicketEmission.Constants.COMMANDS_WPNCS;
            MyCTS.Presentation.Parameters.TimeExtendedAPI = true;
            try
            {
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    sabreAnswer = objCommand.SendReceive(send);
                }
            }
            catch { }
            MyCTS.Presentation.Parameters.TimeExtendedAPI = false;
            CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.MAXIMUM, ref row, ref col, 2, 3, 1, 64);
            if (row != 0 || col != 0)
            {
                send = Resources.TicketEmission.Constants.COMMANDS_WPNCS_CROSSLORAINE_S1_INDENT_16;
                MyCTS.Presentation.Parameters.TimeExtendedAPI = true;
                try
                {
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        objCommand.SendReceive(send);
                    }
                }
                catch { }
                MyCTS.Presentation.Parameters.TimeExtendedAPI = false;
            }
        }


        #endregion//End MethodsClass 


    }
}
