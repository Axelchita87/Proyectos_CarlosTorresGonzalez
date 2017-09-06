using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucChangeDutyCode : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite cambiar el DutyCode
        /// Creación:    07-Mayo-10 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        public ucChangeDutyCode()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = rdoAgent;
            this.LastControlFocus = btnAccept;
        }

        //Coloca el foco en el radio
        private void ucChangeDutyCode_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            rdoAgent.Focus();
        }
        //Llama el metodo de commandsend
        private void btnAccept_Click(object sender, EventArgs e)
        {
            CommandsSend();
        }

        //KeyDown
        /// <summary>
        /// Este se usa para todos los controles en general si se oprime 
        /// Esc se manda a el User control de Welcome 
        /// Enter se manda la accion de botón de Aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }

        /// <summary>
        /// Se envia el comando de acuerdo a los campos ingresados
        /// </summary>
        private void CommandsSend()
        {
            int row = 0;
            int col = 0;
            string result = string.Empty;
            string send = string.Empty;
            send = "SI";
            if(rdoAgent.Checked)
                send = string.Concat(send, "*");
            if(rdoSupervisor.Checked)
                send = string.Concat(send, "9");
            if(rdoTrainee.Checked)
                send = string.Concat(send, "6");

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                result= objCommand.SendReceive(send);
            }

            CommandsQik.searchResponse(result, Resources.Reservations.THE_DUTYCODE_INVALID_ASSIGNED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                row = 0;
                col = 0;
                MessageBox.Show(Resources.Reservations.DUTYCODE_ASIGNADO_INVALIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(Resources.Reservations.ASIGNACION_DUTYCODE_EXITOSO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
        }
    }
}
