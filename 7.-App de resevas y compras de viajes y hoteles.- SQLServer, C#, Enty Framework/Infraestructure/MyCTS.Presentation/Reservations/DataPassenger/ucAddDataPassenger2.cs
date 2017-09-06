using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Forms.UI;

namespace MyCTS.Presentation
{
    public partial class ucAddDataPassenger2 : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite borrar lineas contables,pertenece al flujo de Reservaciones
        /// Creación:    Diciembre 08 -Marzo 09 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        #region======= Declaration of Variable =======

        private string send;
        private string result; 
        public static bool error = false;
        private bool enter;

        #endregion

        public ucAddDataPassenger2()
        {

            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = btnNo;
            this.LastControlFocus = btnAccept;
        }

        //User Control Load
        /// <summary>
        /// Se asignas los colores a los Botones de Si y No
        /// Se asigna el foco al Boton principal No
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucAddDataPassenger2_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            btnNo.ForeColor = Color.OrangeRed;
            btnYes.FlatAppearance.BorderColor = Color.White;
            btnNo.Focus();
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
                send = Resources.Constants.COMMANDS_NM;
                using (CommandsAPI objCommnads = new CommandsAPI())
                {
                    result = objCommnads.SendReceive(send);
                }
                APIResponse();
            }

            if (btnYes.ForeColor == Color.OrangeRed)
            {
                if (IsValidateBusinessRules)
                {
                    CommandsSend();
                    APIResponse();
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

        //LinkClicked
        private void btnYes_Click(object sender, EventArgs e)
        {
            ShowLine_Range();
        }
        
        //LinkClicked
        private void btnNo_Click(object sender, EventArgs e)
        {
            HideLine_Range();
        }
        

        #region ===== Change focus all controls =====
        /// <summary>
        /// Es el cambio de foco entre controles como tiene el mismo 
        /// Length se hizo un ciclo para el cambio entre cada uno de 
        /// los controles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOption_Changed(object sender, EventArgs e)
        {
            SmartTextBox txt = sender as SmartTextBox;
            if (txt.Text.Length > 2)
            {
                int indexControl = GetIndexControl(txt);

                SmartTextBox[] arrTextBox = new SmartTextBox[] { txtLine1, txtLine2, txtLine3, txtRange4, txtRange5, txtRange6 };
                int numelements = arrTextBox.Length;
                string segmentsPendings = string.Empty;
                int firstElement = 0;
                if (!string.IsNullOrEmpty(segmentsPendings))
                {
                    arrTextBox[indexControl].Text = string.Empty;
                    arrTextBox[firstElement].Focus();
                }
                else
                {
                    Control c = txt.NextControl;
                    if (c != null) c.Focus();
                }
            }
        }

        /// <summary>
        /// Para asignar el Index al Control siguiente
        /// </summary>
        /// <param name="txtCurrentControl"></param>
        /// <returns></returns>
        private int GetIndexControl(SmartTextBox txtCurrentControl)
        {
            SmartTextBox[] txt = new SmartTextBox[] { txtLine1, txtLine2, txtLine3, txtRange4, txtRange5, txtRange6 };
            int numelements = txt.Length;

            for (int i = 0; i < numelements; i++)
            {
                if (txt[i].Name.Equals(txtCurrentControl.Name))
                    return i;
            }
            return 0;
        }

        #endregion

        #region ===== Change Tab =====

        private void txtRange6_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
                btnAccept.TabStop = true;
        }

        private void btnAccept_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
                btnAccept.TabStop = false;
        }

        private void btnYes_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                ShowLine_Range();
            else if (e.KeyCode == Keys.Tab)
                ShowLine_Range();
        }

        private void btnNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                HideLine_Range();
            else if (e.KeyCode == Keys.Tab)
                HideLine_Range();

            else if (e.KeyCode == Keys.Enter && enter)
                    btnAccept_Click(sender, e);
                enter = true;
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
                string triplezero = Resources.Constants.TRIPLEZERO;

                if (txtLine1.Text.Equals(zero) | txtLine2.Text.Equals(zero) | txtLine3.Text.Equals(zero) |
                       txtRange4.Text.Equals(zero) | txtRange5.Text.Equals(zero) | txtRange6.Text.Equals(zero) |
                       txtLine1.Text.Equals(doublezero) | txtLine2.Text.Equals(doublezero) | txtLine3.Text.Equals(doublezero) |
                       txtRange4.Text.Equals(doublezero) | txtRange5.Text.Equals(doublezero) | txtRange6.Text.Equals(doublezero) |
                       txtLine1.Text.Equals(triplezero) | txtLine2.Text.Equals(triplezero) | txtLine3.Text.Equals(triplezero) |
                       txtRange4.Text.Equals(triplezero) | txtRange5.Text.Equals(triplezero) | txtRange6.Text.Equals(triplezero))
                {
                    MessageBox.Show(Resources.Reservations.CERO_NO_PERMITIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if (string.IsNullOrEmpty(txtLine1.Text) && string.IsNullOrEmpty(txtLine2.Text) &&
                        string.IsNullOrEmpty(txtLine3.Text) && string.IsNullOrEmpty(txtRange4.Text) &&
                        string.IsNullOrEmpty(txtRange5.Text) && string.IsNullOrEmpty(txtRange6.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_NÚMERO_LÍNEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLine1.Focus();
                    return false;
                }

                else if (txtLine1.Text == string.Empty)
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_NÚMERO_LÍNEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLine1.Focus();
                    return false;

                }
                else if (txtLine1.Text == string.Empty & txtRange4.Text != string.Empty)
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_NÚMERO_LÍNEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLine1.Focus();
                    return false;
                }
                else if (txtLine2.Text == string.Empty & txtRange5.Text != string.Empty)
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_NÚMERO_LÍNEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLine2.Focus();
                    return false;
                }
                else if (txtLine3.Text == string.Empty & txtRange6.Text != string.Empty)
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_NÚMERO_LÍNEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLine3.Focus();
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
            send=string.Empty;
            send=Resources.Constants.COMMANDS_NM;

            if (!string.IsNullOrEmpty(txtLine1.Text))
                send = string.Concat(send, txtLine1.Text);
            if (!string.IsNullOrEmpty(txtRange4.Text))
                send = string.Concat(send, Resources.Constants.INDENT,txtRange4.Text);
            if (!string.IsNullOrEmpty(txtLine2.Text))
                send = string.Concat(send, Resources.Constants.END_ITEM + txtLine2.Text);
            if (!string.IsNullOrEmpty(txtRange5.Text))
                send = string.Concat(send, Resources.Constants.INDENT, txtRange5.Text);
            if (!string.IsNullOrEmpty(txtLine3.Text))
                send = string.Concat(send, Resources.Constants.END_ITEM + txtLine3.Text);
            if (!string.IsNullOrEmpty(txtRange6.Text))
                send = string.Concat(send, Resources.Constants.INDENT, txtRange6.Text);

            using (CommandsAPI objCommnads = new CommandsAPI())
            {
                result = objCommnads.SendReceive(send);
            }
        }

            #region ===== Commons =====

            /// <summary>
            /// Busca errores en la clase de ERR_AddDataPassenger2 de acuerdo a las respuestas recibidas por el 
            /// Emulador de Sabre y de acuerdo a ellas se realizan ciertas acciones ya sea
            /// mandar un mensaje de error al usuario notificando del mismo o mandando a otro 
            /// User Control
            /// </summary>
            private void APIResponse()
            {
                if ((!string.IsNullOrEmpty(result)))
                {
                    ERR_AddDataPassenger2.err_addatapassenger(result);

                    if (!ERR_AddDataPassenger2.Status && !ERR_AddDataPassenger2.Othershowmask)
                    {
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCADD_MORE_PASSENGER);
                    }
                    else if (ERR_AddDataPassenger2.Othershowmask && !ERR_AddDataPassenger2.Status)
                    {
                        MessageBox.Show(ERR_AddDataPassenger2.CustomUserMsg, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCADD_DATA_PASSENGER);
                    }
                    else
                    {
                        MessageBox.Show(ERR_AddDataPassenger2.CustomUserMsg, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            /// <summary>
            /// Se muestran los texbox de acuerdo a la opción seleccionada 
            /// en el User Control (button Si)
            /// </summary>
            private void ShowLine_Range()
            {
                btnYes.FlatAppearance.BorderColor = Color.Black;
                btnYes.ForeColor = Color.OrangeRed;
                btnNo.ForeColor = Color.Black;
                btnNo.FlatAppearance.BorderColor = Color.White;

                using (CommandsAPI objCommnads = new CommandsAPI())
                {
                    result = objCommnads.SendReceive(Resources.Constants.COMMANDS_N_AST_AST_O, 0, 1);
                }
                lblLine.Visible = true;
                lblRange.Visible = true;
                lblscript.Visible = true;
                txtLine1.Visible = true;
                txtLine2.Visible = true;
                txtLine3.Visible = true;
                txtRange4.Visible = true;
                txtRange5.Visible = true;
                txtRange6.Visible = true;
                txtLine1.Focus();
            }

            /// <summary>
            /// Se ocultan los textbox de acuerdo a la opción 
            /// seleccionada (si el button es No)
            /// </summary>
            private void HideLine_Range()
            {
                btnNo.ForeColor = Color.OrangeRed;
                btnNo.FlatAppearance.BorderColor = Color.Black;
                btnYes.ForeColor = Color.Black;
                btnYes.FlatAppearance.BorderColor = Color.White;

                lblLine.Visible = false;
                lblRange.Visible = false;
                lblscript.Visible = false;
                txtLine1.Visible = false;
                txtLine2.Visible = false;
                txtLine3.Visible = false;
                txtRange4.Visible = false;
                txtRange5.Visible = false;
                txtRange6.Visible = false;

                txtLine2.Text = string.Empty;
                txtLine3.Text = string.Empty;
                txtRange4.Text = string.Empty;
                txtRange5.Text = string.Empty;
                txtRange6.Text = string.Empty;
                txtLine1.Text = string.Empty;
            }

            #endregion // End Commons

        #endregion

        






        }
}
