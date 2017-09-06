using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;

namespace MyCTS.Presentation
{
    public partial class ucJustifications : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite mostrar las justificaciones por Coorporativo,pertenece a Funciones
        /// Creación:    Marzo-Abril 09 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        private string DKToSearch;
        private string optionSelected;
        private string command;
        private string send;

        public ucJustifications()
        {
            InitializeComponent();
        }

        //ucJustifications Load event
        private void ucJustifications_Load(object sender, EventArgs e)
        {
            
            initialStatements();
        }


        private InterJetProcessObserver _processObserver;

        /// <summary>
        /// Gets the process observer.
        /// </summary>
        private InterJetProcessObserver ProcessObserver
        {
            get
            {
                return _processObserver ?? (_processObserver = new InterJetProcessObserver
                {
                    UserControl = this

                });
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="msg">A <see cref="T:System.Windows.Forms.Message"/>, passed by reference, that represents the window message to process.</param>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys"/> values that represents the key to process.</param>
        /// <returns>
        /// true if the character was processed by the control; otherwise, false.
        /// </returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (ProcessObserver.HandleEvent(ref msg, keyData))
            {
                return true;

            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        //dgvJustifications_CellDoubleClick event
        private void dgvJustifications_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            justificationCodeSelected();
        }

        //dgvJustifications_KeyDown event
        /// <summary>
        /// Este se usa para todos los controles en general si se oprime 
        /// Esc se manda a el User control de Welcome 
        /// Enter se manda la accion de botón de Aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvJustifications_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);   
            if (e.KeyCode.Equals(Keys.Enter))
                justificationCodeSelected();
        }

        #region===== MethodsClass =====

        //Load DataSource with database values and dgvJustifications get focus
        /// <summary>
        /// Si existen parametros que vienen de otro User Control
        /// se asignas esos parametros a variables y se carga el dataGridView 
        /// de acuerdo al DK
        /// </summary>
        public void initialStatements()
        {
            if (this.Parameters != null)
            {
                if (this.Parameters.Length == 3)
                {
                    DKToSearch = this.Parameters[0];
                    command = this.Parameters[1];
                    optionSelected = this.Parameters[2];
                }
                else
                {
                    DKToSearch = this.Parameters[0];
                    optionSelected = this.Parameters[1];
                }

                GetAndSetAttribute1 Attribute = GetAndSetAttribute1BL.GetAttribute(DKToSearch);
                bindingSource1.DataSource = DKTempBL.GetDKTemp(Attribute.Attribute1.ToString(), false);
            }
            dgvJustifications.Focus();
        }

        //Assign justification code and load ucAccountingInformation
        /// <summary>
        /// Se selecciona la justificación y despues de eso de acuerdo al DK 
        /// es la forma en que continua el flujo y manda comandos
        /// </summary>
        public void justificationCodeSelected()
        {
            int index = dgvJustifications.CurrentCell.RowIndex;
            DKTemp obj = dgvJustifications.Rows[index].DataBoundItem as DKTemp;
            string commandreasonjustify = obj.Code.ToString();
            ucEndReservation.interrupt = false;
            if (!string.IsNullOrEmpty(DKToSearch))
            {
                if (DKToSearch.Equals(Resources.Reservations.MCAFEE))
                {
                    send = command + Resources.Constants.COMMANDS_5U99_RC_SLASH + commandreasonjustify;
                    using (CommandsAPI objCommands = new CommandsAPI())
                    {
                        objCommands.SendReceive(send);
                    }
                    string[] sendInfo = new string[] { Resources.Reservations.CONTINUE_RADIUS, optionSelected };
                    Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCENDRESERVATION, sendInfo);
                }
                else
                {
                    string[] sendInfo = new string[] { Resources.Reservations.CONTINUE_SANTANDER, commandreasonjustify, optionSelected };
                    Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCENDRESERVATION, sendInfo);
                }
            }

        }
        
        #endregion //End MethodsClass

        //Button Accept
        private void btnAccept_Click(object sender, EventArgs e)
        {
            justificationCodeSelected();
        }
    }
}
