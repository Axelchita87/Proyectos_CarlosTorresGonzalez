using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MyCTS.Presentation.Components;


namespace MyCTS.Presentation
{
    public partial class ucClaimItLastName : CustomUserControl
    {

        /// <summary>
        /// Descripcion: Permite jalar un Record por medio del Apellido,pertenece a Funciones
        /// Creación:    Marzo-Abril 09 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        #region====== Declaration of variables =======

        private string day;
        private string month;
        private string year;
        private string dateCalendar;
        private string send;
        private bool statusDate;
        private bool firstentrance;
        
        #endregion


        public ucClaimItLastName()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtLastName;
            this.LastControlFocus = btnAccept;
        }


        //User Control Load
        /// <summary>
        /// Oculata el calendario y se coloca el foco en Apellido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucClaimItLastName_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            CalendarStateBack();
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
                else if (btnNo.ForeColor==Color.OrangeRed)
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

        //Show Calendar
        private void picCalender_Click(object sender, EventArgs e)
        {
            CalendarStateFront();
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

        #region===== Select Date from MonthCalendar =====

        /// <summary>
        /// Es para validar la fecha del calendario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            statusDate = false;
            DateTime fecha = Convert.ToDateTime(monthCalendar1.SelectionStart);
            dateCalendar = String.Format("{0:ddMMyyyy}", fecha);
            day = dateCalendar.Substring(0, 2);
            month = dateCalendar.Substring(2, 2);
            year = dateCalendar.Substring(4, 4);

            if (month == "01")
                month = "JAN";
            else if (month == "02")
                month = "FEB";
            else if (month == "03")
                month = "MAR";
            else if (month == "04")
                month = "APR";
            else if (month == "05")
                month = "MAY";
            else if (month == "06")
                month = "JUN";
            else if (month == "07")
                month = "JUL";
            else if (month == "08")
                month = "AUG";
            else if (month == "09")
                month = "SEP";
            else if (month == "10")
                month = "OCT";
            else if (month == "11")
                month = "NOV";
            else if (month == "12")
                month = "DEC";
            DateTime today = DateTime.Today;
            if (DateTime.Compare(fecha, today) < 0)
                statusDate = true;
            else
                statusDate = false;
            //Fecha a enviar
            string date = day + month;
            txtDataExit.Text = date;
            if (tblLayoutMain.Contains(monthCalendar1))
                monthCalendar1.SendToBack();

            monthCalendar1.Visible = false;
        }

        #endregion

        #region===== Hide MonthCalendar With Key Escape =====

        /// <summary>
        /// En el calendario cuando oprimen Esc. para ocultar el calendario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monthCalendar1_KeyDown(object sender, KeyEventArgs e)
        {
            if (monthCalendar1.Focus())
            {
                if (e.KeyData == Keys.Escape)
                {
                    if (tblLayoutMain.Contains(monthCalendar1))
                        monthCalendar1.SendToBack();
                   
                    monthCalendar1.Visible = false;
                }
            }
        }

        #endregion

        #region===== Hide monthCalendar When the Focus Leave it =====

        /// <summary>
        /// En esta oculatamos el calendario 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monthCalendar1_Leave(object sender, EventArgs e)
        {
            if (tblLayoutMain.Contains(monthCalendar1))
                monthCalendar1.SendToBack();

            monthCalendar1.Visible = false;
        }

        #endregion

        #region ===== Change all Focus Control ======

        /// <summary>
        /// Es para el cambio de Foco entre cada control 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            if (txtLastName.Text.Length > 19)
                txtName.Focus();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 19)
                txtDataExit.Focus();
        }

        private void txtDataExit_TextChanged(object sender, EventArgs e)
        {
            if (txtDataExit.Text.Length > 4)
                txtNumberFlight.Focus();
        }

        private void txtNumberFlight_TextChanged(object sender, EventArgs e)
        {
            if (txtNumberFlight.Text.Length > 3)
                txtAeroline.Focus();
        }

        private void txtAeroline_TextChanged(object sender, EventArgs e)
        {
            if (txtAeroline.Text.Length > 1)
                txtCity.Focus();
        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {
            if (txtCity.Text.Length > 2)
                btnAccept.Focus();
        }

        #endregion

        #region ====== Hide Information ======

        /// <summary>
        /// Oculta controles 
        /// </summary>
        private void HideInformation()
        {
            txtLastName.Enabled = false;
            txtName.Enabled = false;
            txtDataExit.Enabled = false;
            txtAeroline.Enabled = false;
            txtCity.Enabled = false;
            txtNumberFlight.Enabled = false;

            lblRecord.Visible = true;
            btnNo.Visible = true;
            btnYes.Visible = true;
            btnYes.ForeColor = Color.OrangeRed;
            btnNo.ForeColor = Color.Black;
            btnNo.FlatAppearance.BorderColor = Color.White;
            btnYes.Focus();
            firstentrance = true;
        }

        #endregion

        #region ===== Change Tab =====

        /// <summary>
        /// Se ocpa para que los botones contengan la funcionalidad del
        /// Tabulador para cambiar los colores y del Enter para el clic del 
        /// boton de Acpetar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            if (txtLastName.Enabled == false)
                this.InitialControlFocus = btnYes;
            else
                this.InitialControlFocus = txtLastName;
        }
        
        #endregion

        #region ===== MethodsClass =====

        /// <summary>
        /// Ocultar el calendario
        /// </summary>
        private void CalendarStateBack()
        {
            monthCalendar1.BackColor = Color.FromArgb(255, 255, 192);
            monthCalendar1.Visible = false;
            if (tblLayoutMain.Contains(monthCalendar1))
                monthCalendar1.SendToBack();
        }

        /// <summary>
        /// Llevar el calendario hacia el frente
        /// y que se muestre
        /// </summary>
        private void CalendarStateFront()
        {

            monthCalendar1.Visible = true;
            if (tblLayoutMain.Contains(monthCalendar1))
                monthCalendar1.BringToFront();
            
            monthCalendar1.Focus();
        }

        /// <summary>
        /// Se validan que existan los datos que son obligatorios y que 
        /// sean los datos correctos
        /// </summary>
        private bool IsValidateBusinessRules
        {
            get
            {
                string doublezero = Resources.Constants.DOUBLEZERO;
                string zero = Resources.Constants.ZERO;
                string triplezero = Resources.Constants.TRIPLEZERO;
                string date = string.Empty;

                if (string.IsNullOrEmpty(txtLastName.Text) &&
                    string.IsNullOrEmpty(txtName.Text) &&
                    string.IsNullOrEmpty(txtDataExit.Text) &&
                    string.IsNullOrEmpty(txtNumberFlight.Text) &&
                    string.IsNullOrEmpty(txtAeroline.Text) &&
                    string.IsNullOrEmpty(txtCity.Text))
                {
                    MessageBox.Show(Resources.Reservations.NECESITA_INGRESAR_TODOS_DATOS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLastName.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtLastName.Text))
                {
                    MessageBox.Show(Resources.Reservations.NECESITAS_INGRESAR_APELLIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLastName.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtName.Text))
                {
                    MessageBox.Show(Resources.Reservations.NECESITAS_INGRESAR_NOMBRE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtDataExit.Text))
                {
                    MessageBox.Show(Resources.Reservations.NECESITAS_INGRESAR_FECHA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDataExit.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtNumberFlight.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_NÚEMRO_VUELO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberFlight.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtAeroline.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_CÓDIGO_AEROLÍNEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAeroline.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtCity.Text))
                {
                    MessageBox.Show(Resources.Reservations.NECESITAS_INGRESAR_CIUDAD, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCity.Focus();
                    return false;
                }
                else if (!ValidateRegularExpression.ValidateDateFormat(txtDataExit.Text))
                {
                    date = string.Format(Resources.Reservations.FORMAT_FECHA_DOS_NUM_TRES_ALFA, "\n");
                    MessageBox.Show(date, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if (statusDate)
                {
                    date = string.Format(Resources.Reservations.FECHA_SELEC_MENOR_ACTUAL, "\n");
                    MessageBox.Show(date, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDataExit.Focus();
                    return false;
                }
                else if (txtNumberFlight.Text.Equals(zero) | txtNumberFlight.Text.Equals(doublezero) |
                   txtNumberFlight.Text.Equals(triplezero))
                {
                    MessageBox.Show(Resources.Reservations.CERO_NO_PERMITIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberFlight.Focus();
                    return false;
                }
                else
                    return true;
            }
        }

        /// <summary>
        /// Se manda el comando con los datos previamente ingreados por el 
        /// usuario
        /// </summary>
        private void CommandsSend()
        {
            send = Resources.Constants.COMMANDS_AT_Q + txtAeroline.Text + Resources.Constants.COMMANDS_SLASH_AST + txtNumberFlight.Text +
               Resources.Constants.SLASH + txtDataExit.Text + txtCity.Text +Resources.Constants.INDENT + txtLastName.Text +
                Resources.Constants.SLASH + txtName.Text;
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
