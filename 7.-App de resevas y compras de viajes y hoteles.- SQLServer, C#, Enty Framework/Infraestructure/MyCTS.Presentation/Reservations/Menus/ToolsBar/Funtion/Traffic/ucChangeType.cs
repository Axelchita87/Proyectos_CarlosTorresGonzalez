using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucChangeType : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite ver el Tipo de Cambio de acuerdo a una fecha especifica,pertenece a Funciones
        /// Creación:    Marzo-Abril 09 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        #region ======= Declaration of variables ======

        private string dateCalendar;
        private string day;
        private string month;
        private string year;
        private bool comparisonDate;
        private bool calendar;

        #endregion

        public ucChangeType()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtDateSelect;
            this.LastControlFocus = btnAccept;
        }

        //Control User Load
        /// <summary>
        /// En esta función se oculta el calendario
        /// y se coloca el foco en el textbox de Seleción de fecha
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucChangeType_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtDateSelect.Focus();
            CalendarStateBack();
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
            if (string.IsNullOrEmpty(txtDateSelect.Text))
                CommandsSend();
            else
            {
                if (IsValidateBusinessRules)
                    CommandsSendwithDate();
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

        //Show Calender
        private void picCalender_Click(object sender, EventArgs e)
        {
            CalendarStateFront();
        }

        //Change Focus
        /// <summary>
        /// Cambia el foco de acuerdo a las opciones que se tienen 
        /// y muestra el calendario 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDateSelect_TextChanged(object sender, EventArgs e)
        {
            if (txtDateSelect.Text.Length > 6)
                btnAccept.Focus();
            if (comparisonDate)
            {
               comparisonDate = false;
               calendar = true;
            }
        }

        #region===== Select Date from MonthCalendar =====

        /// <summary>
        /// Es para validar la fecha del calendario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            comparisonDate = false;
            DateTime fecha = Convert.ToDateTime(monthCalendar1.SelectionStart);
            dateCalendar = String.Format("{0:ddMMyyyy}", fecha);
            day = dateCalendar.Substring(0, 2);
            month = dateCalendar.Substring(2, 2);
            year = dateCalendar.Substring(6, 2);

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
            comparisonDate = true;
            string date = day + month + year;
            txtDateSelect.Text = date;
            
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

        #region ===== methodsClass =====

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
        /// Valido que los campos obligatorios no esten vacios y que no 
        /// contengan datos no permitidos.
        /// </summary>
        private bool IsValidateBusinessRules
        {
            get
            {
                bool minDate = false;
                

                DateTime Date = new DateTime();
                DateTime today = DateTime.Today;
                if (ValidateRegularExpression.ValidateDateFormatYear(txtDateSelect.Text))
                {
                    Date = Convert.ToDateTime(txtDateSelect.Text);
                }
                if (DateTime.Compare(Date, today) < 0)
                    minDate = true;
                if (txtDateSelect.Text.Length < 7)
                {
                    MessageBox.Show(Resources.Reservations.FECHA_DEBE_TENER_7_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDateSelect.Focus();
                    return false;
                }
                else if (!calendar && minDate)
                {
                    MessageBox.Show(Resources.Reservations.FECHA_SELEC_MENOR_ACTUAL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDateSelect.Focus();
                    return false;
                }
                else
                    return true;
            }
        }

        /// <summary>
        /// Se envian el comando sin elegir una Fecha en especifico
        /// </summary>
        private void CommandsSend()
        {
            string send;
            send = Resources.Constants.COMMANDS_DC_CROSS_USD1_MXN;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
            Loader.AddToPanel(Loader.Zone.Middle, this,Resources.Constants.UCWELCOME);
        }

        /// <summary>
        /// Se envia el comando de acuerdo a los campos ingresados
        /// </summary>
        private void CommandsSendwithDate()
        {
            string send;
            send = Resources.Constants.COMMANDS_DC_CROSS_USD1_SLAHS_MXN_ + txtDateSelect.Text;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }

        #endregion

    }
}
