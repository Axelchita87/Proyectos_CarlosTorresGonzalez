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
using MyCTS.Forms.UI;

namespace MyCTS.Presentation
{
    public partial class ucPhaseIVSendCommands : CustomUserControl
    {
        /// <summary>
        /// Descripción: Envio de los comandos de la creacion de faseIV
        /// Creación:    11 Sep 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        /// 

        private string sabreAnswer;

        private bool firstOK = false;
        private bool secondOK = false;
        private bool thirdOK = false;

        public ucPhaseIVSendCommands()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Ejecuta el metodo de envio de comandos a MySabre al cargar la mascarilla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucPhaseIVSendCommands_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            CommandSend();
        }

        #region===== MethodsClass =====

        /// <summary>
        /// Envia y verifica la respuesta de los comandos enviados a MySabre
        /// </summary>
        private void CommandSend()
        {
            BaseFareCommandSend();
            if (APIResponse())
            {
                firstOK = false;
                BreakDownCommandSend();
                if (APIResponse())
                {
                    firstOK = false;
                    secondOK = false;
                    CalculationLinesCommandsend();
                    if (APIResponse())
                    {
                        
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                    }
                }
                
            }
            
        }


        /// <summary>
        /// Envia el comando de tarifa base e impuestos
        /// </summary>
        private void BaseFareCommandSend()
        {
            firstOK = true;
            string send = string.Empty;
            sabreAnswer = string.Empty;
            if(ucMenuReservations.phaseIV)
                send = ucPhaseIVCalculationLine.sabreCommandBaseFare;
            else
                send = ucPhaseIVCalculationLine_RVW.sabreCommandBaseFare;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }
        }



        /// <summary>
        /// Envia el comando de linea contable
        /// </summary>
        private void BreakDownCommandSend()
        {
            secondOK = true;
            string send = string.Empty;
            sabreAnswer = string.Empty;
            if (ucMenuReservations.phaseIV)
                send = string.Concat(ucPhaseIVBreakDown.breakDown,
                ucPhaseIVCalculationLine.sabreCommandFareCalculation);
            else
                send = string.Concat(ucPhaseIVBreakDown.breakDown,
                ucPhaseIVCalculationLine_RVW.sabreCommandFareCalculation);
            
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }
        }



        /// <summary>
        /// Envia el comando de lineas contables
        /// </summary>
        private void CalculationLinesCommandsend()
        {
            thirdOK = true;
            string send = string.Empty;
            sabreAnswer = string.Empty;
            if(ucMenuReservations.phaseIV)
                send = ucPhaseIVCalculationLine.sabreCommandLinesCalculation;
            else
                send = ucPhaseIVCalculationLine_RVW.sabreCommandLinesCalculation;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }
        }


        /// <summary>
        /// Validación de errores posibles en la respuesta de MySabre
        /// </summary>
        private bool APIResponse()
        {
            bool isValid = true;
            isValid = IsOK;
            if (!isValid)
            {
                return isValid;
            }
            else
            {
                ERR_PhaseIV.err_phaseIVErrors(sabreAnswer);
                if (!ERR_PhaseIV.Status)
                {
                    return isValid;
                }
                else
                {
                    if (!string.IsNullOrEmpty(ERR_PhaseIV.CustomUserMsg))
                    {
                        MessageBox.Show(ERR_PhaseIV.CustomUserMsg, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    if (ucMenuReservations.phaseIV)
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_PHASEIV_CALCULATION_LINE);
                    else
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_PHASEIV_CALCULATION_LINE_RWD);
                    isValid = false;
                    return isValid;
                }
            }
        }


    
        /// <summary>
        /// Verifica si la respuesta de MySabre es la buscada
        /// </summary>
        /// <returns></returns>
        private bool IsOK
        {
            get
            {
                int row = 0;
                int col = 0;
                bool isValid = false;
                CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.OK, ref row, ref col, 1, 1, 1, 64);
                if (row != 0 || col != 0)
                {

                    isValid = true;
                    return isValid;
                }
                else
                {
                    if (firstOK)
                    {
                        MessageBox.Show(Resources.TicketEmission.Tickets.ERROR_INGRESO_CANTIDADES, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        firstOK = false;
                    }
                    else if (secondOK)
                    {
                        MessageBox.Show(Resources.TicketEmission.Tickets.ERROR_INGRESO_LINEA_CALCULO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        secondOK = false;
                    }
                    else if (thirdOK)
                    {
                        MessageBox.Show(Resources.TicketEmission.Tickets.ERROR_INGRESO_CANTIDADES, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        thirdOK = false;
                    }

                    return isValid;
                }

            }

        }
        #endregion//End MethodsClass 
    }
}
