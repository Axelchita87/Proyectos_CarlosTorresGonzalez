using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Business;
using MyCTS.Entities;
using System.Text.RegularExpressions;
using MyCTS.Forms.UI;


namespace MyCTS.Presentation
{
    public partial class ucBoletageDateAndReceived : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite  asignar una fecha para la reservación y agente
        ///              de quien se solicita la reservación,pertenece al flujo de Reservaciones
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
        private string result;
        public static bool PQ;
        public static bool WP;

        #endregion

        public ucBoletageDateAndReceived()
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
        /// Se oculata el calendario y se mandan comando para la extracción de 
        /// la fecha de la reservación menos 2 días.
        /// Se le asigna el foco a textbox de Fecha
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucBoletageDateAndReceived_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            CalendarStateBack();
            LookNewDate();
            txtDateSelected.Focus();
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
                btnAccept_Click(sender , e);
        }

       //ShowCalender
        /// <summary>
        /// Muestra el calendario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            monthCalendar1.Visible = false;
        }

        #endregion

        #region======= Extract Date ======

        /// <summary>
        /// Se divide la fecha que se encontro y se concatena el dia y mes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void frmCalend_frmCalendarUpdate(object sender, MyCTS.Presentation.Components.UpdateEventArgs e)
        {
            string dateReceived;
            string dayReceived;
            string monthReceived;
            string yearReceived;
            string dateSelected;
            dateReceived = e.Objets[0];
            dayReceived = dateReceived.Substring(0, 2);
            monthReceived = dateReceived.Substring(2, 3);
            yearReceived = dateReceived.Substring(5, 4);
            dateSelected = dayReceived + monthReceived;
            txtDateSelected.Text = dateSelected;
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
                txtSolicitorName.Focus();
        }


        private void txtDateSelected_TextChanged(object sender, EventArgs e)
        {
            if (txtDateSelected.Text.Length > 4)
                txtComment.Focus();
        }

        private void txtSolicitorName_TextChanged(object sender, EventArgs e)
        {
            if (txtSolicitorName.Text.Length > 34)
                btnAccept.Focus();
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
                    return false;
                }
                else if (string.IsNullOrEmpty(txtSolicitorName.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESE_NOMBRE_SOLICITANTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSolicitorName.Focus();
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
            string agent = string.Empty;
            CatQueue item = CatQueueBL.GetQueue(Login.Firm, Login.PCC);
            if (!string.IsNullOrEmpty(item.Agent))
                agent = item.Agent;
            if ((!string.IsNullOrEmpty(txtDateSelected.Text)) &&
                (!string.IsNullOrEmpty(txtSolicitorName.Text)) &&
                string.IsNullOrEmpty(txtComment.Text))
                {
                    send = Resources.Constants.COMMANDS_7TAW +
                    txtDateSelected.Text + Resources.Constants.COMMANDS_SLASH_END_IT_6 +
                    txtSolicitorName.Text + Resources.Constants.SLASH + agent;
                }
            else if ((!string.IsNullOrEmpty(txtDateSelected.Text)) &&
                (!string.IsNullOrEmpty(txtSolicitorName.Text)) &&
                (!string.IsNullOrEmpty(txtComment.Text)))
                {
                    send = Resources.Constants.COMMANDS_7TAW + txtDateSelected.Text +
                    Resources.Constants.SLASH + txtComment.Text +
                    Resources.Constants.COMMANDS_END_IT_6 +
                    txtSolicitorName.Text + Resources.Constants.SLASH + agent;
                }
            using (CommandsAPI objCommands = new CommandsAPI())
            {
                objCommands.SendReceive(send);
            }
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCSETS_MAP);
        }

        /// <summary>
        /// Esta función lo que hace es extraer una fecha 
        /// se manda un comando primero y busca la fecha en ERR__BoletageDateAndReceived, 
        /// sino la encuentra,se manda otro comando distinto igual se busca la fecha, 
        /// sino la vuelve a encontrar se manda un tercer comando y vuelve a buscar 
        /// la fecha si en esta no la vuelva a encontrar, se termina la busqueda y el 
        /// textbox de fecha se queda en blanco.
        /// </summary>
        private void LookNewDate()
        {
            string date;
            string dateinitial;
            string dateoptional;
            string dates_Suitable;
            string date_compare;
            int datefinal;
            int chagedate;
            DateTime today = DateTime.Today;
            using (CommandsAPI objCommands = new CommandsAPI())
            {
                result = objCommands.SendReceive(Resources.Constants.COMMANDS_AST_PQ);
                PQ = true;
            }
            ERR__BoletageDateAndReceived.err_boletagedataandreceived(result);
            PQ = false;
            if (ERR__BoletageDateAndReceived.Status)
            {
                date = ERR__BoletageDateAndReceived.Fecha;
                if (ValidateRegularExpression.ValidateDateFormat(date))
                {
                    dateinitial = (date.Substring(0, 2));
                    dateoptional = (date.Substring(2, 3));
                    datefinal = Convert.ToInt32(dateinitial);
                    chagedate = datefinal - 2;
                    if (chagedate == 00)
                        chagedate = 2;
                    if (chagedate == -1)
                        chagedate = 1;
                    dates_Suitable = chagedate + dateoptional;
                    if (dates_Suitable.Length < 5)
                        date_compare = Resources.Constants.ZERO + dates_Suitable;
                    else
                        date_compare = dates_Suitable;
                    if (Convert.ToDateTime(date_compare) >= today)
                        txtDateSelected.Text = date_compare;
                    else
                        txtDateSelected.Text = dateinitial + dateoptional;
                }
            }
            else
            {
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(Resources.Constants.COMMANDS_WP);
                    WP = true;
                }
                ERR__BoletageDateAndReceived.err_boletagedataandreceived(result);
                WP = false;
                ERR__BoletageDateAndReceived.IA = false;
                if (ERR__BoletageDateAndReceived.Status)
                {
                    date = ERR__BoletageDateAndReceived.Fecha;
                    if (ValidateRegularExpression.ValidateDateFormat(date))
                    {
                        dateinitial = (date.Substring(0, 2));
                        dateoptional = (date.Substring(2, 3));
                        datefinal = Convert.ToInt32(dateinitial);
                        chagedate = datefinal - 2;
                        if (chagedate == 00)
                            chagedate = 2;
                        if (chagedate == -1)
                            chagedate = 1;
                        dates_Suitable = chagedate + dateoptional;
                        if (dates_Suitable.Length < 5)
                            date_compare = Resources.Constants.ZERO + dates_Suitable;
                        else
                            date_compare = dates_Suitable;
                        if (Convert.ToDateTime(date_compare) >= today)
                            txtDateSelected.Text = date_compare;
                        else
                            txtDateSelected.Text = dateinitial + dateoptional;
                    }
                }
                else
                {
                    using (CommandsAPI objCommands = new CommandsAPI())
                    {
                        result = objCommands.SendReceive(Resources.Constants.COMMANDS_AST_IA);
                    }
                    ERR__BoletageDateAndReceived.err_boletagedataandreceived(result);
                    if (ERR__BoletageDateAndReceived.IA)
                    {
                        date = ERR__BoletageDateAndReceived.Fecha;
                        if (ValidateRegularExpression.ValidateDateFormat(date))
                        {
                            dateinitial = (date.Substring(0, 2));
                            dateoptional = (date.Substring(2, 3));
                            datefinal = Convert.ToInt32(dateinitial);
                            chagedate = datefinal - 2;
                            if (chagedate == 00)
                                chagedate = 2;
                            if (chagedate == -1)
                                chagedate = 1;
                            dates_Suitable = chagedate + dateoptional;
                            if (dates_Suitable.Length < 5)
                                date_compare = Resources.Constants.ZERO + dates_Suitable;
                            else
                                date_compare = dates_Suitable;
                            if (Convert.ToDateTime(date_compare) >= today)
                                txtDateSelected.Text = date_compare;
                            else
                                txtDateSelected.Text = dateinitial + dateoptional;
                        }
                    }
                }
            }
        }

        #endregion
    }
}
