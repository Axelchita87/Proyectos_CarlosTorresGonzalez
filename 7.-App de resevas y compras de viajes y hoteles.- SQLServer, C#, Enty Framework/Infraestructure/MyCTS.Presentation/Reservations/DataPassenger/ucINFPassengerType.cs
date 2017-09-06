using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using System.Text.RegularExpressions;


namespace MyCTS.Presentation
{
    public partial class ucINFPassengerType : CustomUserControl
    {
        
        /// <summary>
        /// Descripcion: Permite ingresar datos del Infante y de la pesonas que se encuentre a cargo 
        ///              del Infante,pertenece al flujo de Reservaciones
        /// Creación:    Diciembre 08 -Marzo 09 , Modificación: 23-Octubre-09 Realizado por Angel Trejo
        /// Cambio:      Se cambio la edad en meses del infante por su fecha de nacimiento.
        ///              Se establecio el campo de "Adulto a cargo" como opcional.
        ///              Se ingreso un CheckBox para verificar si la aerolinea es AA y mandar a sabre
        ///              un 4INFT/ en vez de 3INFT/  ********* Cambio Angel Trejo
        /// Solicito:    Guillermo Granados   
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        private string result=string.Empty;

        public ucINFPassengerType()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtLastName;
            this.LastControlFocus = btnAccept;
            ucAvailability.IsInterJetProcess = false;
        }

        //User Control Load
        /// <summary>
        /// Se envia un comando para verificar los datos de los pasajeros
        /// y se asigna el foco a textbox de Apellido 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucINFPassengerType_Load(object sender, EventArgs e)
        {
            using (CommandsAPI objCommands = new CommandsAPI())
            {
                objCommands.SendReceive(Resources.Constants.COMMANDS_AST_N);
            }
            txtLastName.Focus();
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
            if (IsValidateBusinessRules)
            {
                CommandsSend();
                APIResponse();
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

        #region======Change focus all controls======

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            if (txtLastName.Text.Length == 30)
                txtName.Focus();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Length == 30)
                txtBirthDate.Focus();
        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {
            if (txtBirthDate.Text.Length == 7)
                txtAdultPosition.Focus();
        }

        private void txtAdultPosition_TextChanged(object sender, EventArgs e)
        {
            if (txtAdultPosition.Text.Length == 3)
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
                DateTime birthDate = new DateTime();
                bool aux = true;
                try
                {
                    if(ValidateRegularExpression.ValidateBirthDateFormat(txtBirthDate.Text))
                    birthDate = Convert.ToDateTime(txtBirthDate.Text);
                }
                catch
                {
                    //MessageBox.Show(Resources.Reservations.FECHA_NO_VALIDA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //txtBirthDate.Focus();
                    aux = false;
                }
                if (string.IsNullOrEmpty(txtLastName.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESE_APELLIDO_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLastName.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtName.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESE_NOMBRE_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtBirthDate.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESE_EDAD_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBirthDate.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtLastName.Text) &&
                string.IsNullOrEmpty(txtName.Text) &&
                string.IsNullOrEmpty(txtBirthDate.Text))
                {
                    MessageBox.Show(Resources.Reservations.NECESITA_INGRESAR_TODOS_DATOS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLastName.Focus();
                    return false;
                }
                else if (!string.IsNullOrEmpty(txtAdultPosition.Text)&&!ValidateRegularExpression.ValidateOneDecimalNumber(txtAdultPosition.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_FORMATO_CORRECTO_POSICION_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAdultPosition.Focus();
                    return false;
                }
                else if (!ValidateRegularExpression.ValidateBirthDateFormat(txtBirthDate.Text))
                {
                    MessageBox.Show(Resources.Reservations.FECHA_DEBE_TENER_7_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBirthDate.Focus();
                    return false;
                }
                else if (aux.Equals(false))
                {
                    MessageBox.Show(Resources.Reservations.FECHA_NO_VALIDA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBirthDate.Focus();
                    return false;
                }
                else if (birthDate >= DateTime.Now)
                {
                    MessageBox.Show(Resources.Reservations.FECHA_SELECCIONADA_MAYOR_ACTUAL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBirthDate.Focus();
                    return false;
                }
                else
                {
                    return true;
                }

                //else if (string.IsNullOrEmpty(txtAdultPosition.Text))
                //{
                //    MessageBox.Show(Resources.Reservations.INGRESE_ADULTO_CARGO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtAdultPosition.Focus();
                //    return false;
                //}
            }
        }

        /// <summary>
        /// Se envia el comando de acuerdo a los campos ingresados
        /// </summary>
        private void CommandsSend()
        {
            string send= string.Empty;

            if (!string.IsNullOrEmpty(txtAdultPosition.Text))
                send = txtLastName.Text + Resources.Constants.SLASH + txtName.Text + Resources.Constants.SLASH + txtBirthDate.Text + Resources.Constants.INDENT + txtAdultPosition.Text;
            else
                send = txtLastName.Text + Resources.Constants.SLASH + txtName.Text + Resources.Constants.SLASH + txtBirthDate.Text;

            if ((!string.IsNullOrEmpty(txtLastName.Text)) &&
                (!string.IsNullOrEmpty(txtName.Text)) &&
                (!string.IsNullOrEmpty(txtBirthDate.Text)))
            {
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    if (chkIsAA.Checked)
                        result = objCommands.SendReceive(Resources.Constants.COMMANDS_4INFT_SLASH + send);
                    else
                        result = objCommands.SendReceive(Resources.Constants.COMMANDS_3INFT_SLASH + send);
                }
            }
        }

        #region ===== Commons =====

        /// <summary>
        /// Busca errores en la clase de ERR_INFPassenger de acuerdo a las respuestas recibidas por el 
        /// Emulador de Sabre y de acuerdo a ellas se realizan ciertas acciones ya sea
        /// mandar un mensaje de error al usuario notificando del mismo o mandando a otro 
        /// User Control
        /// </summary>
        private void APIResponse()
        {
            if ((!string.IsNullOrEmpty(result)))
            {
                ERR_INFPassenger.err_infpassenger(result);
                if ((!ERR_INFPassenger.Status))
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCBOLETAGE_DATEANDRECEIVED);
                else
                    MessageBox.Show(ERR_INFPassenger.CustomUserMsg, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion // End Commons
       
        #endregion

    }
}

