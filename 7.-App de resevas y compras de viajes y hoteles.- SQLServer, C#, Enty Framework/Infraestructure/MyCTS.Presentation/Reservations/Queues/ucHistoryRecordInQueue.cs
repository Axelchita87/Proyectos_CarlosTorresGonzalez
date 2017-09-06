/// <summary>
/// Descripcion: Permite ver la Historia de Record en Queue
/// Pertenece a: Queues
/// Creación:    17-Junio-09
/// Autor:       Pedro Tomas Solis
/// </summary>

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
    public partial class ucHistoryRecordInQueue : CustomUserControl
    {
        public static string HistoryRecordInQueue = string.Empty;
        private bool validatebusinessrules = true;

        //Constructor
        public ucHistoryRecordInQueue()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = rdoActualInOrderByQueue;
            this.LastControlFocus = btnAccept;
        }

        #region =====Eventos=====

        //Evento Load de ucHistoryRecordInQueue
        private void ucHistoryRecordInQueue_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            rdoActualInOrderByQueue.Focus();
        }

        //Evento KeyDown para teclas Esc y Enter
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }

        //Evento click del Boton btnAccept
        private void btnAccept_Click(object sender, EventArgs e)
        {
            //Se aplican las reglas de negocios
            validateBusinessRules();
            //Si se cumplen las reglas de negocios,mandar el comando
            if (validatebusinessrules)
                commandsSend();
        }

        #endregion

        #region =====Metodos=====

        /// <summary>
        /// Muestra la historia de un Record en una Queue; ordenado por actual, fecha, archiado y por archivo
        /// </summary>
        private void validateBusinessRules()
        {
            HistoryRecordInQueue = string.Empty;
            //Verificar que una opción sea seleccionada
            if (!rdoActualInOrderByQueue.Checked && !rdoActualInOrderByDate.Checked && !rdoInFile.Checked && !rdoOrderedByFile.Checked)
            {
                MessageBox.Show(Resources.Queues.Queues.DEBE_SELECCONAR_OPCION, Resources.Constants.MYCTS, MessageBoxButtons.OK);
                validatebusinessrules = false;
            }
            else 
            {
                HistoryRecordInQueue = string.Concat(HistoryRecordInQueue, Resources.Queues.Constants.COMMANDS_AST_Q);
                //Actual en orden por Queue
                if(rdoActualInOrderByQueue.Checked)
                    HistoryRecordInQueue = string.Concat(HistoryRecordInQueue, Resources.Queues.Constants.COMMANDS_H_SLASH_S);
                //Actual en orden por fecha
                if(rdoActualInOrderByDate.Checked)
                    HistoryRecordInQueue = string.Concat(HistoryRecordInQueue, Resources.Queues.Constants.COMMANDS_H);
                //Archivado
                if(rdoInFile.Checked)
                    HistoryRecordInQueue = string.Concat(HistoryRecordInQueue, Resources.Queues.Constants.COMMANDS_H_SLASH_A);
                //Ordenada por Archivo
                if(rdoOrderedByFile.Checked)
                    HistoryRecordInQueue = string.Concat(HistoryRecordInQueue, Resources.Queues.Constants.COMMANDS_H_SLASH_A_COMMA_S);
            }
        }

        /// <summary>
        /// Permite el envio de comandos hacia Sabre
        /// </summary>
        private void commandsSend()
        {
            if (!string.IsNullOrEmpty(HistoryRecordInQueue))
            {
                //Envia el comando contenido en la variable HistoryRecordInQueue
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    objCommands.SendReceive(HistoryRecordInQueue);
                }
            }
        }
        
        #endregion

       
    }
}
