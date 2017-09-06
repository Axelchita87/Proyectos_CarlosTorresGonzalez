using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;


namespace MyCTS.Presentation
{
    public partial class ucAddDataPassenger : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite ingresar datos del pasajero,pertenece
        ///              al flujo de Reservaciones
        /// Creación:    Diciembre 08 -Marzo 09 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez
        /// </summary>


        #region ======== Declaration of Variable =======
        // public string password; por el momento no se ocupa
        private string send;
        private string result = string.Empty;

        #endregion


        public ucAddDataPassenger()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtProfileCompany;
            this.LastControlFocus = btnAccept;
        }


        // User Control Load
        /// <summary>
        /// Solo pone el foco en el primer elemento que es Perfil de Compañia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucAddDataPassenger_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            setProfileModule();
            txtProfileCompany.Focus();
        }

        //Button ListCompany
        private void btnListCompany_Click(object sender, EventArgs e)
        {
            ListCompany();
        }

        //Button ListEmployes
        private void btnListEmployes_Click(object sender, EventArgs e)
        {
            ListEmployes();
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


        #region ===== Change focus all controls =====

        private void txtProfileCompany_TextChanged(object sender, EventArgs e)
        {

            if (txtProfileCompany.Text.Length > 24)
                txtProfileEmployee.Focus();
        }


        private void txtProfileEmployee_TextChanged(object sender, EventArgs e)
        {
            if (txtProfileEmployee.Text.Length > 29)
                // txtPasswordProfile.Focus();
                btnAccept.Focus();
        }


        private void txtPasswordProfile_TextChanged_1(object sender, EventArgs e)
        {
            if (txtPasswordProfile.Text.Length > 7)
                btnAccept.Focus();
        }

        #endregion


        #region ===== methodsClass =====

        /// <summary>
        /// Valido que los campos obligatorios no esten vacios 
        /// </summary>
        private bool IsValidateBusinessRules
        {
            get
            {
                if (string.IsNullOrEmpty(txtProfileCompany.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESE_PERFIL_COMPAÑÍA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtProfileCompany.Focus();
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
            if ((!string.IsNullOrEmpty(txtProfileCompany.Text)) &&
                string.IsNullOrEmpty(txtProfileEmployee.Text) &&
                string.IsNullOrEmpty(txtPasswordProfile.Text))
            {
                send = Resources.Constants.COMMANDS_N_AST + txtProfileCompany.Text;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    result = objCommand.SendReceive(send);
                }
            }


            if ((!string.IsNullOrEmpty(txtProfileCompany.Text)) &&
               !string.IsNullOrEmpty(txtProfileEmployee.Text))
            {
                send = Resources.Constants.COMMANDS_N_AST + txtProfileCompany.Text + Resources.Constants.INDENT + txtProfileEmployee.Text;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    result = objCommand.SendReceive(send);
                }
            }
        }


        /// <summary>
        /// Inicia el formulario de Perfiles
        /// </summary>
        private void setProfileModule()
        {
            frmProfiles frm = new frmProfiles();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frmProfiles.IsReservationFlow = true;
            //frm.Left = this.ParentForm.Left + 10;
            //frm.Top = this.Parent.Top + 110;
            frm.Height = 600;
            frm.Width = 650;
            frm.ShowDialog();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCADD_MORE_PASSENGER);
        }


        /// <summary>
        /// Envia un comando que muestra la lista de los empleados
        /// </summary>
        private void ListEmployes()
        {
            String listemployes;
            if (string.IsNullOrEmpty(txtProfileCompany.Text))
            {
                MessageBox.Show(Resources.Reservations.REQUIERE_INGRESE_PERFIL_COMPAÑÍA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProfileCompany.Focus();
            }

            else if (string.IsNullOrEmpty(txtProfileEmployee.Text) &&
               (!string.IsNullOrEmpty(txtProfileCompany.Text)))
            {
                listemployes = Resources.Constants.COMMANDS_NU + txtProfileCompany.Text;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(listemployes);
                }
            }
            else
            {
                listemployes = Resources.Constants.COMMANDS_NU + txtProfileCompany.Text + "-" + txtProfileEmployee.Text;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(listemployes);
                }
            }
        }

        /// <summary>
        ///Envia un comando y muestra la lista de la compañia
        /// </summary>
        private void ListCompany()
        {
            String listcompany;
            if (txtProfileCompany.Text.Equals(string.Empty))
            {
                listcompany = Resources.Constants.COMMANDS_NLIST_SLA_ALL;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(listcompany);
                }
            }
            else
            {
                listcompany = Resources.Constants.COMMANDS_NLIST_SLA + txtProfileCompany.Text;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(listcompany);
                }
            }
        }

        #region ===== Commons =====

        /// <summary>
        /// Busca errores en la clase de ERR_AddDataPassenger de acuerdo a las respuestas recibidas por el 
        /// Emulador de Sabre y de acuerdo a ellas se realizan ciertas acciones ya sea
        /// mandar un mensaje de error al usuario notificando del mismo o mandando a otro 
        /// User Control
        /// </summary>
        private void APIResponse()
        {
            if ((!string.IsNullOrEmpty(result)))
            {
                ERR_AddDataPassenger.err_addatapassenger(result);
                if (ERR_AddDataPassenger.Status)
                {
                    MessageBox.Show(ERR_AddDataPassenger.CustomUserMsg, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (ERR_AddDataPassenger.Showmask)
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCADD_DATA_PASSENGER2);
            }
        }

        #endregion

        #endregion

    }
}
