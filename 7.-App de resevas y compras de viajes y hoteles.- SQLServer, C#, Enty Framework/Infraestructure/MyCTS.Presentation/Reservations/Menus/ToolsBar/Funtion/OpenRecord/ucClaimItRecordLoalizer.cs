using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MyCTS.Presentation.Components;


namespace MyCTS.Presentation
{
    public partial class ucClaimItRecordLoalizer : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite jalar un Record por medio del Record Localizador,pertenece a Funciones
        /// Creación:    Marzo-Abril 09 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez 
        /// </summary>
        
        private bool firstentrance;
        private string send;

        public ucClaimItRecordLoalizer()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtRecordLocalizer;
            this.LastControlFocus = btnAccept;
        }

        //User Control Load 
        /// <summary>
        /// Se coloca el foco en el textbox del Record Localizador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucClaimItRecordLoalizer_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtRecordLocalizer.Focus();
        }

        //Button Accept
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
                    HideInformation();
                }
            }
            else
            {
                if (btnYes.ForeColor == Color.OrangeRed)
                {
                    send = Resources.Constants.COMMANDS_AT_Q + txtAeroline.Text + Resources.Constants.COMMANDS_SLAHS_CLM;
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        objCommand.SendReceive(send, 0, 1);
                    }
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
                else if (btnNo.ForeColor == Color.OrangeRed)
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
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

        #region ====== Hide Information ======

        /// <summary>
        /// Muestra los controles que se encuentran ocultos
        /// y se asigna los colores para los botones
        /// </summary>
        private void HideInformation()
        {
            btnYes.ForeColor = Color.OrangeRed;
            btnNo.ForeColor = Color.Black;
            btnNo.FlatAppearance.BorderColor = Color.White;

            txtRecordLocalizer.Enabled = false;
            txtAeroline.Enabled = false;

            lblRecord.Visible = true;
            btnNo.Visible = true;
            btnYes.Visible = true;
            firstentrance = true;
        }

        #endregion

        #region ===== Change all Focus Control ======

        private void txtRecordLocalizer_TextChanged(object sender, EventArgs e)
        {
            if (txtRecordLocalizer.Text.Length > 5)
                txtAeroline.Focus();
        }

        private void txtAeroline_TextChanged(object sender, EventArgs e)
        {
            if (txtAeroline.Text.Length > 1)
                btnAccept.Focus();
        }

        #endregion

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
            if (txtRecordLocalizer.Enabled == false)
                this.InitialControlFocus = btnYes;
            else
                this.InitialControlFocus = txtRecordLocalizer;
        }

        #endregion

        #region ===== methodsClass =====

        /// <summary>
        /// Se validan que existan los datos que son obligatorios y que 
        /// sean los datos correctos
        /// </summary>
        private bool IsValidateBusinessRules
        {
            get
            {
                if (string.IsNullOrEmpty(txtRecordLocalizer.Text) &&
                    string.IsNullOrEmpty(txtAeroline.Text))
                {
                    MessageBox.Show(Resources.Reservations.NECESITA_INGRESAR_TODOS_DATOS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRecordLocalizer.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtRecordLocalizer.Text))
                {
                    MessageBox.Show(Resources.Reservations.NECESITAS_INGRESAR_RECORD_LOCALIZADOR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRecordLocalizer.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtAeroline.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_CÓDIGO_AEROLÍNEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAeroline.Focus();
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
            send = Resources.Constants.COMMANDS_AT_Q + txtAeroline.Text + Resources.Constants.COMMANDS_SLASH_AST + txtRecordLocalizer.Text;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }

        #region ===== Commons =====

        /// <summary>
        /// Esta funcion se encarga de cambiar los colores de los botones
        /// deacuerdo al que este seleccionado
        /// </summary>
        private void ChangeColorYes()
        {
            btnYes.ForeColor = Color.OrangeRed;
            btnNo.ForeColor = Color.Black;
            btnNo.FlatAppearance.BorderColor = Color.White;
        }

        /// <summary>
        /// Esta funcion se encarga de cambiar los colores de los botones
        /// deacuerdo al que este seleccionado
        /// </summary>
        private void ChangeColorNo()
        {
            btnNo.ForeColor = Color.OrangeRed;
            btnYes.ForeColor = Color.Black;
            btnYes.FlatAppearance.BorderColor = Color.White;
        }

        /// <summary>
        /// Esta funcion se encarga de cambiar los colores de los botones
        /// deacuerdo al que este seleccionado
        /// </summary>
        private void ChangeColor()
        {
            btnNo.ForeColor = Color.Black;
            btnNo.FlatAppearance.BorderColor = Color.White;
            btnYes.ForeColor = Color.Black;
            btnYes.FlatAppearance.BorderColor = Color.White;
        }

        #endregion 

        #endregion
    }
}
