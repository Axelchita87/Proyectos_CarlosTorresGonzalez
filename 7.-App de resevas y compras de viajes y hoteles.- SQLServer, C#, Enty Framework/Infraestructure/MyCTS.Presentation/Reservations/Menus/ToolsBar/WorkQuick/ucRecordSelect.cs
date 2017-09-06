using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucRecordSelect : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite recuperar el Record por nombre, record localizador
        ///              número de boleto o número de vuelo,pertenece a Funciones 
        /// Creación:    Junio 09 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        private bool firstentrance;

        public ucRecordSelect()
        {
            ucAvailability.IsInterJetProcess = false;
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtRecordNumber;
            this.LastControlFocus = btnAccept;
        }

        //Control User Load 
        private void ucRecordSelect_Load(object sender, EventArgs e)
        {
            txtRecordNumber.Focus();
        }

        ///Button Accept
        /// <summary>
        /// Se realizan las validaciones despues de que el usuario ingresa datos, 
        /// se mandan los comandos y termina el proceso llamando a otro User Control 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!firstentrance)
            {
                if (IsValidateBusinessRules)
                {
                    CommandsSend();
                    ShowButton(true);
                    ChangeColor();
                }
            }
            else
            {
                if (btnYes.ForeColor == Color.OrangeRed)
                {
                    string send = string.Empty;
                    string sabreAnswer = string.Empty;
                    int row = 0;
                    int col = 0;
                    send = Resources.TicketEmission.Constants.COMMANDS_AST_P6;
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        sabreAnswer = objCommand.SendReceive(send);
                    }
                    CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.TA_SLASH, ref row, ref col, 1, 1, 15, 22);
                    if (row != 0 || col != 0)
                    {
                        send = Resources.TicketEmission.Constants.COMMANDS_XPG;
                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            objCommand.SendReceive(send);
                        }
                        MessageBox.Show(Resources.TicketEmission.Tickets.RECORD_CEDIDO_CERRAR_CERRAR_ANTES_BOLETEAR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
                else if (btnNo.ForeColor == Color.OrangeRed)
                {
                    ShowButton(false);
                    txtRecordNumber.Text = string.Empty;
                    txtRecordNumber.Enabled = true;
                    txtRecordNumber.Focus();
                }
            }
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

        //Event Click Button Yes
        private void btnYes_Click(object sender, EventArgs e)
        {
            ChangeColorYes();
        }

        //Event Click Button No
        private void btnNo_Click(object sender, EventArgs e)
        {
            ChangeColorNo();
        }

        #region ===== Change Tab =====

        private void btnYes_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
                ChangeColor();
            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }

        private void btnNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
                ChangeColor();
            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }

        private void btnAccept_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtRecordNumber.Enabled == false)
                this.InitialControlFocus = btnYes;
            else
                this.InitialControlFocus = txtRecordNumber;
        }

        #endregion

        #region ===== methodsClass =====

        /// <summary>
        /// Se validan que existan los datos que son obligatorios  
        /// </summary>
        private bool IsValidateBusinessRules
        {
            get
            {
                if (string.IsNullOrEmpty(txtRecordNumber.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESE_NUMERO_RECORD, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRecordNumber.Focus();
                    return false;
                }
                else
                    return true;
            }
        }

        /// <summary>
        /// Se envia el comando de acuerdo a los campos ingresados
        /// </summary>
        private void CommandsSend()
        {
            string send = string.Empty;
            send = Resources.Constants.AST + txtRecordNumber.Text;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }

        /// <summary>
        /// Asigna el Color a los controles
        /// </summary>
        private void ChangeColorYes()
        {
            btnYes.ForeColor = Color.OrangeRed;
            btnNo.ForeColor = Color.Black;
            btnNo.FlatAppearance.BorderColor = Color.White;
        }

        /// <summary>
        /// Asigna el Color a los controles
        /// </summary>
        private void ChangeColorNo()
        {
            btnNo.ForeColor = Color.OrangeRed;
            btnYes.ForeColor = Color.Black;
            btnYes.FlatAppearance.BorderColor = Color.White;
        }

        /// <summary>
        /// Asigna el Color a los controles
        /// </summary>
        private void ChangeColor()
        {
            btnNo.ForeColor = Color.Black;
            btnNo.FlatAppearance.BorderColor = Color.White;
            btnYes.ForeColor = Color.Black;
            btnYes.FlatAppearance.BorderColor = Color.White;
        }

        /// <summary>
        /// Oculta o muestra los controles
        /// </summary>
        /// <param name="show"></param>
        private void ShowButton(bool show)
        {
            firstentrance = show;
            lblRecord.Visible = show;
            btnNo.Visible = show;
            btnYes.Visible = show;
            btnYes.ForeColor = Color.OrangeRed;
            btnNo.ForeColor = Color.Black;
            btnNo.FlatAppearance.BorderColor = Color.White;
            txtRecordNumber.Enabled = false;
        }

        #endregion
    }
}
