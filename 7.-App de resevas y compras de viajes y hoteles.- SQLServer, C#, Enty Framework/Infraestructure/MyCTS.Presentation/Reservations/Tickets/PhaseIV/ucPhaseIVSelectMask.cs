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
    public partial class ucPhaseIVSelectMask : CustomUserControl
    {
        /// <summary>
        /// Descripción: Selección de mascarilla para la continuacion de la creacion de 
        ///              Fase IV
        /// Creación:    11 Sep 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        /// 

        private static string masknumber;
        public static string maskNumber
        {
            get { return masknumber; }
            set { masknumber = value; }
        }

        private string sabreAnswer;

        public ucPhaseIVSelectMask()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = dgvSelectMask;
            this.LastControlFocus = btnAccept;
        }


        /// <summary>
        /// Ejecuta los metodos aplicables en la carga de la mascarilla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucPhaseIVSelectMask_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            SendInitialCommand();
        }


        /// <summary>
        /// Ejecuta los metodos correspondientes al presionar el boton Aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            SetMaskNumber();
        }


        #region===== MethodsClass =====


        /// <summary>
        /// Manda el comando inicial al emulador de MySabre para desplegar 
        /// las mascarillas del record
        /// </summary>
        private void SendInitialCommand()
        {
            string send = string.Empty;
            sabreAnswer = string.Empty;
            send = ucCreatePhaseIV.Command;
            if (ucCreatePhaseIV.bySegments)
                send = string.Concat(send,
                    ucPhaseIVBySegments.commandBySegments);
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }
            APIResponse();
            
        }

        /// <summary>
        /// Validación de errores posibles en la respuesta de MySabre
        /// </summary>
        private void APIResponse()
        {
            ERR_PhaseIV.err_phaseIVErrors(sabreAnswer);
            if (!ERR_PhaseIV.Status)
            {
                FullPhaseIVList();
            }
            else
            {
                MessageBox.Show(ERR_PhaseIV.CustomUserMsg, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_CREATE_PHASE_IV);
            }
        }

        /// <summary>
        /// Valida la existencia de fases IV en el record y despliega la lista de estas al usuario
        /// </summary>
        private void FullPhaseIVList()
        {
            int row = 0;
            int col = 0;
            CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.TKT_LIST, ref row, ref col);
            if (row != 0 || col != 0)
            {
                string[] sabreAnswerLines = sabreAnswer.Split(new char[] { '\n' });


                for (int i = 1; i < sabreAnswerLines.Length; i++)
                {
                    string number = string.Empty;
                    string maskInfo = string.Empty;
                    if (!string.IsNullOrEmpty(sabreAnswerLines[i]))
                    {
                        CommandsQik.CopyResponse(sabreAnswerLines[i], ref maskInfo, 1, 4, 20);
                        CommandsQik.CopyResponse(sabreAnswerLines[i], ref number, 1, 1, 2);
                        number = number.Trim();
                        dgvSelectMask.Rows.Add(number, maskInfo);
                    }
                }
                dgvSelectMask.Focus();
            }
            else
            {
                masknumber = string.Empty;
                if (ucMenuReservations.phaseIV)
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_PHASEIV_CALCULATION_LINE);
                else
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_PHASEIV_CALCULATION_LINE_RWD);
            }

        }

        /// <summary>
        /// Carga el valor del número de mascara para ser utilizado posteriormente;
        /// </summary>
        private void SetMaskNumber()
        {
            masknumber = string.Empty;
            int rowIndex = dgvSelectMask.CurrentCell.RowIndex;
            masknumber = dgvSelectMask[0, rowIndex].Value.ToString();
            if(ucMenuReservations.phaseIV)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_PHASEIV_CALCULATION_LINE);
            else
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_PHASEIV_CALCULATION_LINE_RWD);
        }

        #endregion//End MethodsClass


        #region===== GridView Events =====

        //Evento dgvSelectMask_CellDoubleClick
        private void dgvSelectMask_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SetMaskNumber();
        }

        #endregion//End GridView Events


        #region ===== Back to a Previous Usercontrol or Validate Enter KeyDown =====

        /// <summary>
        /// Aborta el proceso de fase IV al presionar la tecla ESC
        /// o continua con el flujo de la creación de fase IV al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Escape)
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }

        }

       

        #endregion//End Back to a Previous Usercontrol or Validate Enter KeyDown

        
    }
}
