using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucInsertDataPassenger2 : CustomUserControl
    {
        /// <summary>
        /// Descripcion:Permite Ingresar Datos del Pasajero
        /// al flujo de Reservaciones
        /// Creación: Septiembre 22 - 2009 , Modificación:*
        /// Cambio: *    , Solicito *
        /// Autor: Jessica Gutierrez 
        /// </summary>

        #region======= Declation of variables ======

        private string firstName;
        private string secondName;
        private string thirdName;
        private string fourthName;
        private string fifthName;
        private string sixthName;
        private string seventhName;
        private string eighthName;
        private string nine;
        private string ten;
        public string send;

        #endregion

        public ucInsertDataPassenger2()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtLastName1;
            this.LastControlFocus = btnAccept;
        }

        //Load de User Control InsertDataPassenger
        private void ucInsertDataPassenger2_Load(object sender, EventArgs e)
        {
            txtLastName1.Focus();
        }

        /// <summary>
        /// Validaciones y envio de comando
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidateBusinessRules)
            {
                CommandsSend();
                if (chkMoreNames.Checked)
                    ShowText();
                else
                {
                    using (CommandsAPI objCommands = new CommandsAPI())
                    {
                        objCommands.SendReceive(Resources.Group.Constants.COMMANDS_AST_A);
                    }
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Group.Constants.UC_MANUALRATEGROUP);
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

        /// <summary>
        /// Valido que los campos obligatorios no esten vacios y que no 
        /// contengan datos no permitidos.
        /// </summary>
        private bool IsValidateBusinessRules
        {
            get
            {
                if (string.IsNullOrEmpty(txtLastName1.Text) &&
                    string.IsNullOrEmpty(txtName1.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESE_APELLIDO_NOMBRE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLastName1.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtLastName1.Text) &&
                        (!string.IsNullOrEmpty(txtName1.Text)))
                {
                    MessageBox.Show(Resources.Reservations.INGRESE_APELLIDO_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLastName1.Focus();
                    return false;
                }
                else if ((!string.IsNullOrEmpty(txtLastName1.Text)) &&
                           string.IsNullOrEmpty(txtName1.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESE_NOMBRE_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName1.Focus();
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
                else if ((!string.IsNullOrEmpty(txtLastName9.Text)) &&
                          string.IsNullOrEmpty(txtName9.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESE_NOMBRE_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName9.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtLastName9.Text) &&
                        (!string.IsNullOrEmpty(txtName9.Text)))
                {
                    MessageBox.Show(Resources.Reservations.INGRESE_APELLIDO_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLastName9.Focus();
                    return false;
                }
                else if ((!string.IsNullOrEmpty(txtLastName10.Text)) &&
                          string.IsNullOrEmpty(txtName10.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESE_NOMBRE_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName10.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtLastName10.Text) &&
                        (!string.IsNullOrEmpty(txtName10.Text)))
                {
                    MessageBox.Show(Resources.Reservations.INGRESE_APELLIDO_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLastName10.Focus();
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
            firstName = Resources.Constants.INDENT + txtLastName1.Text + Resources.Constants.SLASH + txtName1.Text;
            secondName = Resources.Constants.END_ITEM_INDENT + txtLastName2.Text + Resources.Constants.SLASH + txtName2.Text;
            thirdName = Resources.Constants.END_ITEM_INDENT + txtLastName3.Text + Resources.Constants.SLASH + txtName3.Text;
            fourthName = Resources.Constants.END_ITEM_INDENT + txtLastName4.Text + Resources.Constants.SLASH + txtName4.Text;
            fifthName = Resources.Constants.END_ITEM_INDENT + txtLastName5.Text + Resources.Constants.SLASH + txtName5.Text;
            sixthName = Resources.Constants.END_ITEM_INDENT + txtLastName6.Text + Resources.Constants.SLASH + txtName6.Text;
            seventhName = Resources.Constants.END_ITEM_INDENT + txtLastName7.Text + Resources.Constants.SLASH + txtName7.Text;
            eighthName = Resources.Constants.END_ITEM_INDENT + txtLastName8.Text + Resources.Constants.SLASH + txtName8.Text;
            nine = Resources.Constants.END_ITEM_INDENT + txtLastName9.Text + Resources.Constants.SLASH + txtName9.Text;
            ten = Resources.Constants.END_ITEM_INDENT + txtLastName10.Text + Resources.Constants.SLASH + txtName10.Text;
            if ((!string.IsNullOrEmpty(txtLastName1.Text)) &&
               (!string.IsNullOrEmpty(txtName1.Text)))
                    send = firstName;
            if (!string.IsNullOrEmpty(txtLastName2.Text) &&
               (!string.IsNullOrEmpty(txtName2.Text)))
                    send = string.Concat(send, secondName);
            if (!string.IsNullOrEmpty(txtLastName3.Text) &&
               (!string.IsNullOrEmpty(txtName3.Text)))
                    send = string.Concat(send, thirdName);
            if (!string.IsNullOrEmpty(txtLastName4.Text) &&
                (!string.IsNullOrEmpty(txtName4.Text)))
                    send = string.Concat(send, fourthName);
            if (!string.IsNullOrEmpty(txtLastName5.Text) &&
               (!string.IsNullOrEmpty(txtName5.Text)))
                    send = string.Concat(send, fifthName);
            if (!string.IsNullOrEmpty(txtLastName6.Text) &&
               (!string.IsNullOrEmpty(txtName6.Text)))
                    send = string.Concat(send, sixthName);
            if (!string.IsNullOrEmpty(txtLastName7.Text) &&
               (!string.IsNullOrEmpty(txtName7.Text)))
                    send = string.Concat(send, seventhName);
            if (!string.IsNullOrEmpty(txtLastName8.Text) &&
               (!string.IsNullOrEmpty(txtName8.Text)))
                    send = string.Concat(send, eighthName);
            if (!string.IsNullOrEmpty(txtLastName9.Text) &&
               (!string.IsNullOrEmpty(txtName9.Text)))
                    send = string.Concat(send, nine);
            if (!string.IsNullOrEmpty(txtLastName10.Text) &&
               (!string.IsNullOrEmpty(txtName10.Text)))
                    send = string.Concat(send, ten);
              using (CommandsAPI objCommands = new CommandsAPI())
              {
                  objCommands.SendReceive(send);
              }
        }

        /// <summary>
        /// Mostrar textbox
        /// </summary>
        private void ShowText()
        {
            send = string.Empty;
            firstName = string.Empty;
            secondName = string.Empty;
            thirdName = string.Empty;
            fourthName = string.Empty;
            fifthName = string.Empty;
            sixthName = string.Empty;
            seventhName = string.Empty;
            eighthName = string.Empty;
            nine = string.Empty;
            ten = string.Empty;
            txtLastName1.Text = string.Empty;
            txtLastName2.Text = string.Empty;
            txtLastName3.Text = string.Empty;
            txtLastName4.Text = string.Empty;
            txtLastName5.Text = string.Empty;
            txtLastName6.Text = string.Empty;
            txtLastName7.Text = string.Empty;
            txtLastName8.Text = string.Empty;
            txtLastName9.Text = string.Empty;
            txtLastName10.Text = string.Empty;
            txtName1.Text = string.Empty;
            txtName2.Text = string.Empty;
            txtName3.Text = string.Empty;
            txtName4.Text = string.Empty;
            txtName5.Text = string.Empty;
            txtName6.Text = string.Empty;
            txtName7.Text = string.Empty;
            txtName8.Text = string.Empty;
            txtName9.Text = string.Empty;
            txtName10.Text = string.Empty;
            chkMoreNames.Checked = false;
            txtLastName1.Focus();
        }
    }
}
