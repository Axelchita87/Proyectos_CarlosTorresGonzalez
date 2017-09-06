using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucDeleteAccountLine : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite borrar las líneas contables,pertenece a Emitir Boleto
        /// Creación:    4/Junio/09 , Modificación: 22 diciembre 2009 (por Marcos Q. Ramirez)
        /// Cambio:      Anexo borrado por linea o por rango , Solicito: Guillermo Granados
        /// Autor:       Jessica Gutierrez 
        /// </summary>
        
        public ucDeleteAccountLine()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = chkDeleteAcountLine;
            this.LastControlFocus = btnAccept;
        }


        //Load User Control
        private void ucDeleteAccountLine_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            chkDeleteAcountLine.Focus();
        }

        //Button Accept
        /// <summary>
        /// Se hace la validación de checkbox si esta checado entonces
        /// se manda el comando y se va al siguient User Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!IsValidBusinessRules)
            {
                string send = string.Empty;
                if (chkDeleteAcountLine.Checked)
                {
                    send = Resources.TicketEmission.Constants.COMMANDS_AC_AT_ALL;
                    using (CommandsAPI objCommands = new CommandsAPI())
                    {
                        objCommands.SendReceive(send);
                    }
                }
                else if (!string.IsNullOrEmpty(txtLineNumber.Text))
                {
                    send = string.Concat(Resources.TicketEmission.Constants.COMMANDS_AC_CHANGE,
                        txtLineNumber.Text);

                    if (!string.IsNullOrEmpty(txtRange.Text))
                        send = string.Concat(send,
                            Resources.TicketEmission.Constants.INDENT,
                            txtRange.Text);
                    using (CommandsAPI objCommands = new CommandsAPI())
                    {
                        objCommands.SendReceive(send);
                    }
                }
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_REMOVEREMARKS);
            }
        }

        /// <summary>
        /// Validaciones de Regla de Negocios de las opciones seleccionadas
        /// </summary>
        /// <returns></returns>
        private bool IsValidBusinessRules
        {
            get
            {
                bool isValid = true;
                if (!string.IsNullOrEmpty(txtRange.Text) &&
                   string.IsNullOrEmpty(txtLineNumber.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_NUM_LINEA_INICIO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLineNumber.Focus();
                }
                else
                    isValid = false;
                return isValid;
            }
        }

        //KeyDown
        /// <summary>
        /// Si oprimen Esc. Primero extraemos los controles de calidad para saber que user Control se va activar
        /// de acuerdo a que controles de calidad se encuentren activos.
        /// Si oprimen Enter se va a la función del clic del boton Aceptar
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

        private void chkDeleteAcountLine_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeleteAcountLine.Checked)
            {
                lblLineNumber.Visible = false;
                lblRange.Visible = false;
                lblIndent.Visible = false;
                txtLineNumber.Visible = false;
                txtRange.Visible = false;
                txtLineNumber.Text = string.Empty;
                txtRange.Text = string.Empty;
            }
            else
            {
                lblLineNumber.Visible = true;
                lblRange.Visible = true;
                lblIndent.Visible = true;
                txtLineNumber.Visible = true;
                txtRange.Visible = true;
            }
        }
    }
}
