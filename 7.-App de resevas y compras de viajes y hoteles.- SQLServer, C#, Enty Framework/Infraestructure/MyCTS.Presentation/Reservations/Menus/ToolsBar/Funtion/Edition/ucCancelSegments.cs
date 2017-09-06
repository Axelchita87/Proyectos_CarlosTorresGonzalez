using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MyCTS.Presentation.Components;


namespace MyCTS.Presentation
{
    public partial class ucCancelSegments : CustomUserControl
    {

        /// <summary>
        /// Descripcion: Permite cancelar segmentos de los boletos emitidos,pertenece a Funciones
        /// Creación:    Marzo-Abril 09 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        private string result;

        public ucCancelSegments()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = btnYes;
            this.LastControlFocus = btnAccept;
        }

        //User Control Load
        /// <summary>
        /// Se asignas los colores a los Botones de Si y No
        /// Se asigna el foco al Boton principal No
        /// Se manda un comando para verificar si existen segmentos que borrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucCancelSegments_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            btnYes.Focus();
            btnYes.ForeColor = Color.OrangeRed;
            btnNo.FlatAppearance.BorderColor = Color.White;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                result = objCommand.SendReceive(Resources.Constants.COMMANDS_AST_I);
            }
            APIResponse();
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
            if (btnNo.ForeColor == Color.OrangeRed)
            {
                if (IsValidateBusinessRules)
                {
                    CommandsSend();
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
            }
            else if (btnYes.ForeColor == Color.OrangeRed)
            {
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(Resources.Constants.COMMANDS_XI);
                }
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

        //Event Click No
        private void btnNo_Click(object sender, EventArgs e)
        {
            ShowInformation();
        }

        //Event Click Yes
        private void btnYes_Click(object sender, EventArgs e)
        {
            HideInformation();
        }

        #region ======= TabIndex Change ========

       /// <summary>
       /// El evento KeyUp se puso por que solo asi se logro controlar el 
       /// Tabindex de los botones y que pudieran hacer la opcion del enter
       /// para la función del boton Aceptar
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void btnYes_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyData==Keys.Tab)
                HideInformation();

            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }
        
        private void btnNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
                ShowInformation();

            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }

        #endregion 

        #region ====== Change Focus =======

        /// <summary>
        /// Es el cambio de foco entre controles como tiene el mismo 
        /// Length se hizo un ciclo para el cambio entre cada uno de 
        /// los controles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSegmentInitial_TextChanged(object sender, EventArgs e)
        {
            if (txtSegmentInitial.Text.Length > 1)
                txtSegmentFinish.Focus();
        }

        private void txtSegmentFinish_TextChanged(object sender, EventArgs e)
        {
            if (txtSegmentFinish.Text.Length > 1)
                btnAccept.Focus();
        }

        #endregion

        #region ===== methodsClass =====

        /// <summary>
        /// Valido que los campos obligatorios no esten vacios y que no 
        /// contengan datos no permitidos.
        /// </summary>
        private bool IsValidateBusinessRules
        {
            get
            {
                string doublezero = Resources.Constants.DOUBLEZERO;
                string zero = Resources.Constants.ZERO;

                if (string.IsNullOrEmpty(txtSegmentInitial.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESE_SEGMENTO_INICIAL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSegmentInitial.Focus();
                    return false;
                }

                else if (txtSegmentInitial.Text.Equals(zero) | txtSegmentInitial.Text.Equals(doublezero) |
                    txtSegmentFinish.Text.Equals(zero) | txtSegmentFinish.Text.Equals(doublezero))
                {
                    MessageBox.Show(Resources.Reservations.NO_PERMITEN_CEROS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSegmentInitial.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Se envia el comando de acuerdo a los campos ingresados
        /// </summary>
        private void CommandsSend()
        {
            string send;
            if (!string.IsNullOrEmpty(txtSegmentInitial.Text) && string.IsNullOrEmpty(txtSegmentFinish.Text))
            {
                send = Resources.Constants.COMMANDS_X + txtSegmentInitial.Text;

            }
            else
            {
                send = Resources.Constants.COMMANDS_X + txtSegmentInitial.Text + Resources.Constants.INDENT + txtSegmentFinish.Text;
            }

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }

        #region ===== Commons =====

        /// <summary>
        /// Oculta algunos controles
        /// </summary>
        private void HideInformation()
        {
            btnYes.ForeColor = Color.OrangeRed;
            btnNo.ForeColor = Color.Black;
            btnNo.FlatAppearance.BorderColor = Color.White;
            txtSegmentInitial.Text = string.Empty;
            txtSegmentFinish.Text = string.Empty;
            lblAl.Visible = false;
            lblCancelSegment.Visible = false;
            txtSegmentFinish.Visible = false;
            txtSegmentInitial.Visible = false;
        }

        /// <summary>
        ///Muestra algunos controles
        /// </summary>
        private void ShowInformation()
        {
            btnNo.ForeColor = Color.OrangeRed;
            btnYes.ForeColor = Color.Black;
            btnYes.FlatAppearance.BorderColor = Color.White;
            lblAl.Visible = true;
            lblCancelSegment.Visible = true;
            txtSegmentFinish.Visible = true;
            txtSegmentInitial.Visible = true;
            txtSegmentInitial.Focus();
        }

        /// <summary>
        /// Busca errores en la clase de ERR_CancelSegments de acuerdo a las respuestas recibidas por el 
        /// Emulador de Sabre y de acuerdo a ellas se manda a otro User Control
        /// </summary>
        private void APIResponse()
        {
            if ((!string.IsNullOrEmpty(result)))
            {
                ERR_CancelSegments.err_cancelsegments(result);

                if (ERR_CancelSegments.Status)
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
        }

        #endregion

        #endregion


        

    }
}
