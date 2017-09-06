using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using System.Text.RegularExpressions;

namespace MyCTS.Presentation
{
    public partial class ucBoletageDate : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite asignar una fecha para la reservación,pertenece a Reservaciones
        /// Creación:    Diciembre 08 -Marzo 09 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        #region ======= Declaration of variables ======

        private bool statusDate;
        private string dateCalendar;
        private string day;
        private string month;
        private string year;
        private string send;
        private string optionSelected;
        public static bool boletageDate;
        //private string result; no lo ocupamos por ahorita
        #endregion

        public ucBoletageDate()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtDateSelected;
            this.LastControlFocus = btnAccept;
        }

        //User Control Load
        /// <summary>
        /// Se oculta el calendario y se asigna el foco en el Textbox 
        /// de fecha
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucBoletageDate_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            CalendarStateBack();
            txtDateSelected.Focus();
            if (this.Parameters != null && ucEndReservation.EndReservation)
                optionSelected = this.Parameters[0];
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
                    CommandsSend();
                if (this.Parameters != null && ucEndReservation.EndReservation)
                {
                    boletageDate = true;
                    string[] sendInfo = new string[] { optionSelected };
                    Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCENDRESERVATION, sendInfo);
                }
                else
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }

      //Show Calendar
        private void picCalendar_Click(object sender, EventArgs e)
        {
            CalendarStateFront();
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
            txtDateSelected.Text = date;
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
            monthCalendar1.SendToBack();
        }

        #endregion

        #region ===== Return to previous UserControl or been worth Enter =====

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

        #endregion

        #region ===== Change focus all controls =====

        /// <summary>
        /// Es para el cambio de Foco entre cada control 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtComment_TextChanged(object sender, EventArgs e)
        {
            if (txtComment.Text.Length > 24)
                btnAccept.Focus();
        }

        private void txtDateSelected_TextChanged(object sender, EventArgs e)
        {
            if (txtDateSelected.Text.Length > 4)
                txtComment.Focus();
        }

        #endregion

        #region ===== methodsClass =====

        /// <summary>
        /// Ocultar el calendario
        /// </summary>
        private void CalendarStateBack()
        {
            monthCalendar1.BackColor = GetCalendarColor;
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
        /// Valido que los campos obligatorios no esten vacios y que no 
        /// contengan datos no permitidos.
        /// </summary>
        private bool IsValidateBusinessRules
        {
            get
            {
                string date = string.Empty;

                if (string.IsNullOrEmpty(txtDateSelected.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESE_FECHA_TIEMPO_LIMITE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDateSelected.Focus();
                    return false;
                }
                else if (statusDate)
                {
                    date = string.Format(Resources.Reservations.FECHA_SELEC_MENOR_ACTUAL, "\n");
                    MessageBox.Show(date, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDateSelected.Focus();
                    return false;
                }
                else if (!ValidateRegularExpression.ValidateDateFormat(txtDateSelected.Text))
                {
                    date = string.Format(Resources.Reservations.FORMAT_FECHA_DOS_NUM_TRES_ALFA, "\n");
                    MessageBox.Show(date, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDateSelected.Focus();
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
            if ((!string.IsNullOrEmpty(txtDateSelected.Text)) &&
                (string.IsNullOrEmpty(txtComment.Text)))
                {
                    send = Resources.Constants.COMMANDS_7TAW + 
                    txtDateSelected.Text + Resources.Constants.SLASH;
                }
            else if ((!string.IsNullOrEmpty(txtDateSelected.Text)) &&
                (!string.IsNullOrEmpty(txtComment.Text)))
                {
                    send = Resources.Constants.COMMANDS_7TAW + 
                    txtDateSelected.Text + Resources.Constants.SLASH +
                    txtComment.Text + Resources.Constants.SLASH;
                }
            using (CommandsAPI objCommands = new CommandsAPI())
            {
                objCommands.SendReceive(send);
            }
        }

        #endregion
    }
}
