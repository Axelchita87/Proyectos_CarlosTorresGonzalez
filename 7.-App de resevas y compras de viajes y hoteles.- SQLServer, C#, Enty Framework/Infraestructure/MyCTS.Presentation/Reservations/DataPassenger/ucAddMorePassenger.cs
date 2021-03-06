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
    public partial class ucAddMorePassenger : CustomUserControl
    {

        /// <summary>
        /// Descripcion: Permite agregar mas pasajeros para la reservación,pertenece al flujo de Reservaciones
        /// Creación:    Diciembre 08 -Marzo 09 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        #region======= Declation of variables ======

        public string send;
        private bool enter;

        #endregion

        public ucAddMorePassenger()
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
        private void ucAddMorePassenger_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            if (ucMenuReservations.passenger == 0)
            {
                btnNo.Focus();
                btnNo.ForeColor = Color.OrangeRed;
                btnYes.FlatAppearance.BorderColor = Color.White;
            }
            if (ucMenuReservations.passenger == 1)
                btnYes.Focus();
        }

        //Button Accept
        /// <summary>
        /// Se realizan las validaciones despues de que el usuario ingresa datos, 
        /// se mandan los comandos y termina el proceso llamando a otro User Control 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bntAccept_Click(object sender, EventArgs e)
        {
            if (btnYes.ForeColor == Color.OrangeRed)
            {
                if (IsValidateBusinessRules)
                {
                    CommandsSend();
                    addEmails();

                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCDEFINE_PASSENGER_TYPE);
                }
            }
            else if (btnNo.ForeColor == Color.OrangeRed)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCDEFINE_PASSENGER_TYPE);
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
                bntAccept_Click(sender, e);
        }

        //LinkClicked
        private void btnYes_Click(object sender, EventArgs e)
        {
            ShowLine();
        }

        //LinkClicked
        private void btnNo_Click(object sender, EventArgs e)
        {
            HideLine();
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
            if (txt.Text.Length > 24)
            {
                int indexControl = GetIndexControl(txt);

                SmartTextBox[] arrTextBox = new SmartTextBox[] { txtLastName1A, txtName1B, txtEmail1c, txtLastName2, txtName2, txtEmail2c, txtName3, txtLastName2, txtEmail3c, txtLastName4, txtName4, txtEmail4c, txtLastName5, txtName5, txtEmail5c, txtLastName6, txtName6, txtEmail6c, txtLastName7, txtName7, txtEmail7c, txtLastName8, txtName8, txtEmail8c };
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
            SmartTextBox[] txt = new SmartTextBox[] { txtLastName1A, txtName1B, txtEmail1c, txtLastName2, txtName2, txtEmail2c, txtName3, txtLastName2, txtEmail3c, txtLastName4, txtName4, txtEmail4c, txtLastName5, txtName5, txtEmail5c, txtLastName6, txtName6, txtEmail6c, txtLastName7, txtName7, txtEmail7c, txtLastName8, txtName8, txtEmail8c };
            int numelements = txt.Length;

            for (int i = 0; i < numelements; i++)
            {
                if (txt[i].Name.Equals(txtCurrentControl.Name))
                    return i;
            }
            return 0;
        }

        #endregion

        #region ===== Stop Tabindex =====

        private void txtName16_KeyUp(object sender, KeyEventArgs e)
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
                ShowLine();
            else if (e.KeyCode == Keys.Tab)
                ShowLine();
        }

        private void btnNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                HideLine();
            else if (e.KeyCode == Keys.Tab)
                HideLine();
            else if (e.KeyCode == Keys.Enter && enter)
                bntAccept_Click(sender, e);
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
                if (string.IsNullOrEmpty(txtLastName1A.Text) &&
                        string.IsNullOrEmpty(txtName1B.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESE_APELLIDO_NOMBRE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLastName1A.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtLastName1A.Text) &&
                            (!string.IsNullOrEmpty(txtName1B.Text)))
                {
                    MessageBox.Show(Resources.Reservations.INGRESE_APELLIDO_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLastName1A.Focus();
                    return false;
                }
                else if ((!string.IsNullOrEmpty(txtLastName1A.Text)) &&
                        string.IsNullOrEmpty(txtName1B.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESE_NOMBRE_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName1B.Focus();
                    return false;
                }

                else if ((!string.IsNullOrEmpty(txtLastName2.Text)) &&
                        string.IsNullOrEmpty(txtName2.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESE_NOMBRE_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName2.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtLastName2.Text) &&
                        (!string.IsNullOrEmpty(txtName2.Text)))
                {
                    MessageBox.Show(Resources.Reservations.INGRESE_APELLIDO_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLastName2.Focus();
                    return false;
                }
                else if ((!string.IsNullOrEmpty(txtLastName3.Text)) &&
                        string.IsNullOrEmpty(txtName3.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESE_NOMBRE_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName3.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtLastName3.Text) &&
                        (!string.IsNullOrEmpty(txtName3.Text)))
                {
                    MessageBox.Show(Resources.Reservations.INGRESE_APELLIDO_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLastName3.Focus();
                    return false;
                }

                else if ((!string.IsNullOrEmpty(txtLastName4.Text)) &&
                        string.IsNullOrEmpty(txtName4.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESE_NOMBRE_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName4.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtLastName4.Text) &&
                        (!string.IsNullOrEmpty(txtName4.Text)))
                {
                    MessageBox.Show(Resources.Reservations.INGRESE_APELLIDO_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLastName4.Focus();
                    return false;
                }

                else if ((!string.IsNullOrEmpty(txtLastName5.Text)) &&
                        string.IsNullOrEmpty(txtName5.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESE_NOMBRE_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName5.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtLastName5.Text) &&
                        (!string.IsNullOrEmpty(txtName5.Text)))
                {
                    MessageBox.Show(Resources.Reservations.INGRESE_APELLIDO_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLastName5.Focus();
                    return false;
                }
                else if ((!string.IsNullOrEmpty(txtLastName6.Text)) &&
                        string.IsNullOrEmpty(txtName6.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESE_NOMBRE_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName6.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtLastName6.Text) &&
                        (!string.IsNullOrEmpty(txtName6.Text)))
                {
                    MessageBox.Show(Resources.Reservations.INGRESE_APELLIDO_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLastName6.Focus();
                    return false;
                }
                else if ((!string.IsNullOrEmpty(txtLastName7.Text)) &&
                        string.IsNullOrEmpty(txtName7.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESE_NOMBRE_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName7.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtLastName7.Text) &&
                        (!string.IsNullOrEmpty(txtName7.Text)))
                {
                    MessageBox.Show(Resources.Reservations.INGRESE_APELLIDO_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLastName7.Focus();
                    return false;
                }
                else if ((!string.IsNullOrEmpty(txtLastName8.Text)) &&
                        string.IsNullOrEmpty(txtName8.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESE_NOMBRE_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName8.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtLastName8.Text) &&
                   (!string.IsNullOrEmpty(txtName8.Text)))
                {
                    MessageBox.Show(Resources.Reservations.INGRESE_APELLIDO_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLastName8.Focus();
                    return false;
                }

                else
                {
                    return true;
                }
            }
        }
        #endregion

        /// <summary>
        /// Se envia el comando de acuerdo a los campos ingresados
        /// </summary>
        private void CommandsSend()
        {
            string firstName;
            string secondName;
            string thirdName;
            string fourthName;
            string fifthName;
            string sixthName;
            string seventhName;
            string eighthName;



            firstName = Resources.Constants.INDENT + txtLastName1A.Text + Resources.Constants.SLASH + txtName1B.Text;
            secondName = Resources.Constants.END_ITEM_INDENT + txtLastName2.Text + Resources.Constants.SLASH + txtName2.Text;
            thirdName = Resources.Constants.END_ITEM_INDENT + txtLastName3.Text + Resources.Constants.SLASH + txtName3.Text;
            fourthName = Resources.Constants.END_ITEM_INDENT + txtLastName4.Text + Resources.Constants.SLASH + txtName4.Text;
            fifthName = Resources.Constants.END_ITEM_INDENT + txtLastName5.Text + Resources.Constants.SLASH + txtName5.Text;
            sixthName = Resources.Constants.END_ITEM_INDENT + txtLastName6.Text + Resources.Constants.SLASH + txtName6.Text;
            seventhName = Resources.Constants.END_ITEM_INDENT + txtLastName7.Text + Resources.Constants.SLASH + txtName7.Text;
            eighthName = Resources.Constants.END_ITEM_INDENT + txtLastName8.Text + Resources.Constants.SLASH + txtName8.Text;



            if ((!string.IsNullOrEmpty(txtLastName1A.Text)) && (!string.IsNullOrEmpty(txtName1B.Text)))
                send = firstName;
            if (!string.IsNullOrEmpty(txtLastName2.Text) && (!string.IsNullOrEmpty(txtName2.Text)))
                send = string.Concat(send, secondName);
            if (!string.IsNullOrEmpty(txtLastName3.Text) && (!string.IsNullOrEmpty(txtName3.Text)))
                send = string.Concat(send, thirdName);
            if (!string.IsNullOrEmpty(txtLastName4.Text) && (!string.IsNullOrEmpty(txtName4.Text)))
                send = string.Concat(send, fourthName); 
            if (!string.IsNullOrEmpty(txtLastName5.Text) && (!string.IsNullOrEmpty(txtName5.Text)))
                send = string.Concat(send, fifthName);
            if (!string.IsNullOrEmpty(txtLastName6.Text) && (!string.IsNullOrEmpty(txtName6.Text)))
                send = string.Concat(send, sixthName);
            if (!string.IsNullOrEmpty(txtLastName7.Text) && (!string.IsNullOrEmpty(txtName7.Text)))
                send = string.Concat(send, seventhName);
            if (!string.IsNullOrEmpty(txtLastName8.Text) && (!string.IsNullOrEmpty(txtName8.Text)))
                send = string.Concat(send, eighthName);

            using (CommandsAPI objCommands = new CommandsAPI())
            {
                objCommands.SendReceive(send);
            }
        }

       


        #region ===== Commons =====

        /// <summary>
        /// Muestro los texbox de acuerdo a la opción seleccionada 
        /// en el User Control (button Si)
        /// </summary>
        private void ShowLine()
        {
            btnYes.FlatAppearance.BorderColor = Color.Black;
            btnYes.ForeColor = Color.OrangeRed;
            btnNo.ForeColor = Color.Black;
            btnNo.FlatAppearance.BorderColor = Color.White;
            txtLastName1A.Visible = true;
            txtLastName2.Visible = true;
            txtLastName3.Visible = true;
            txtLastName4.Visible = true;
            txtLastName5.Visible = true;
            txtLastName6.Visible = true;
            txtLastName7.Visible = true;
            txtLastName8.Visible = true;
            txtName2.Visible = true;
            txtName3.Visible = true;
            txtName4.Visible = true;
            txtName5.Visible = true;
            txtName6.Visible = true;
            txtName7.Visible = true;
            txtName8.Visible = true;
            txtName1B.Visible = true;
            txtEmail1c.Visible = true;
            txtEmail2c.Visible = true;
            txtEmail3c.Visible = true;
            txtEmail4c.Visible = true;
            txtEmail5c.Visible = true;
            txtEmail6c.Visible = true;
            txtEmail7c.Visible = true;
            txtEmail8c.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            lblName.Visible = true;
            lblLastName.Visible = true;
            txtLastName1A.Focus();
        }

        /// <summary>
        /// Se ocultan los textbox de acuerdo a la opción 
        /// seleccionada (si el button es No)
        /// </summary>
        private void HideLine()
        {
            btnNo.ForeColor = Color.OrangeRed;
            btnNo.FlatAppearance.BorderColor = Color.Black;
            btnYes.ForeColor = Color.Black;
            btnYes.FlatAppearance.BorderColor = Color.White;
            txtLastName1A.Visible = false;
            txtLastName2.Visible = false;
            txtLastName3.Visible = false;
            txtLastName4.Visible = false;
            txtLastName5.Visible = false;
            txtLastName6.Visible = false;
            txtLastName7.Visible = false;
            txtLastName8.Visible = false;
            txtName2.Visible = false;
            txtName3.Visible = false;
            txtName4.Visible = false;
            txtName5.Visible = false;
            txtName6.Visible = false;
            txtName7.Visible = false;
            txtName8.Visible = false;
            txtName1B.Visible = false;

            txtEmail1c.Visible = false;
            txtEmail2c.Visible = false;
            txtEmail3c.Visible = false;
            txtEmail4c.Visible = false;
            txtEmail5c.Visible = false;
            txtEmail6c.Visible = false;
            txtEmail7c.Visible = false;
            txtEmail8c.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            lblName.Visible = false;
            lblLastName.Visible = false;
            

            txtLastName1A.Text = string.Empty;
            txtLastName2.Text = string.Empty;
            txtLastName3.Text = string.Empty;
            txtLastName4.Text = string.Empty;
            txtLastName5.Text = string.Empty;
            txtLastName6.Text = string.Empty;
            txtLastName7.Text = string.Empty;
            txtLastName8.Text = string.Empty;
            txtName2.Text = string.Empty;
            txtName3.Text = string.Empty;
            txtName4.Text = string.Empty;
            txtName5.Text = string.Empty;
            txtName6.Text = string.Empty;
            txtName7.Text = string.Empty;
            txtName8.Text = string.Empty;
            txtName1B.Text = string.Empty;
        }

        #endregion // End Commons

        private void lblAddPassenger1_Click(object sender, EventArgs e)
        {

        }

        public void addEmails()
        {
            
            string email1 = string.Empty;
            string email2 = string.Empty;
            string email3 = string.Empty;
            string email4 = string.Empty;
            string email5 = string.Empty;
            string email6 = string.Empty;
            string email7 = string.Empty;
            string email8 = string.Empty;

            try
            {
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    if (!string.IsNullOrEmpty(txtEmail1c.Text))
                    {
                        email1 = "PE" + Resources.Constants.CROSSLORAINE + txtEmail1c.Text + Resources.Constants.CROSSLORAINE;
                        objCommands.SendReceiveEmail(email1, 1, 1, false);
                    }
                    if (!string.IsNullOrEmpty(txtEmail2c.Text))
                    {
                        email2 = "PE" + Resources.Constants.CROSSLORAINE + txtEmail2c.Text + Resources.Constants.CROSSLORAINE;
                        objCommands.SendReceiveEmail(email2, 1, 1, false);
                    }
                    if (!string.IsNullOrEmpty(txtEmail3c.Text))
                    {
                        email3 = "PE" + Resources.Constants.CROSSLORAINE + txtEmail3c.Text + Resources.Constants.CROSSLORAINE;
                        objCommands.SendReceiveEmail(email3, 1, 1, false);
                    }
                    if (!string.IsNullOrEmpty(txtEmail4c.Text))
                    {
                        email4 = "PE" + Resources.Constants.CROSSLORAINE + txtEmail4c.Text + Resources.Constants.CROSSLORAINE;
                        objCommands.SendReceiveEmail(email4, 1, 1, false);
                    }
                    if (!string.IsNullOrEmpty(txtEmail5c.Text))
                    {
                        email5 = "PE" + Resources.Constants.CROSSLORAINE + txtEmail5c.Text + Resources.Constants.CROSSLORAINE;
                        objCommands.SendReceiveEmail(email5, 1, 1, false);
                    }
                    if (!string.IsNullOrEmpty(txtEmail6c.Text))
                    {
                        email6 = "PE" + Resources.Constants.CROSSLORAINE + txtEmail6c.Text + Resources.Constants.CROSSLORAINE;
                        objCommands.SendReceiveEmail(email6, 1, 1, false);
                    }
                    if (!string.IsNullOrEmpty(txtEmail7c.Text))
                    {
                        email7 = "PE" + Resources.Constants.CROSSLORAINE + txtEmail7c.Text + Resources.Constants.CROSSLORAINE;
                        objCommands.SendReceiveEmail(email7, 1, 1, false);
                    }
                    if (!string.IsNullOrEmpty(txtEmail8c.Text))
                    {
                        email8 = "PE" + Resources.Constants.CROSSLORAINE + txtEmail8c.Text + Resources.Constants.CROSSLORAINE;
                        objCommands.SendReceiveEmail(email8, 1, 1, false);
                    }
                    objCommands.SendReceive(Resources.Constants.COMMANDS_AST_PE);
                }
            }
            catch (Exception Err)
            {
                throw new Exception() ;
            }
        }
    }
}
