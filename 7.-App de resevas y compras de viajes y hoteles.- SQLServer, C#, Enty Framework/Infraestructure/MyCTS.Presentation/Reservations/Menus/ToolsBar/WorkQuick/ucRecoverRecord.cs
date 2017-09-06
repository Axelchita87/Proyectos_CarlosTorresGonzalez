using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucRecoverRecord : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite recuperar el Record por nombre, record localizador
        ///              número de boleto o número de vuelo,pertenece a Funciones 
        /// Creación:    Marzo-Abril 09 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        #region ====== Declaration of variables =======

        public string send;
        private string dateCalendar;
        private string day;
        private string month;
        private string year;
        private string result;
        private bool statusDate;
        private bool validatebusinessrules;
        int row;
        int col;

        #endregion

        public ucRecoverRecord()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = rdoName;
            this.LastControlFocus = btnAccept;
        }

        //User Control Load
        private void ucRecoverRecord_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            CalendarStateBack();
            rdoName.Focus();
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
            if (rdoName.Checked == true)
            {
                ValidateBusinessRulesForName();
                if (validatebusinessrules)
                {
                    CommandsSendForName();
                    APIResponse();
                }
            }
            if (rdoRecorLocalizer.Checked == true)
            {
                ValidateBusinessRulesForRecorLocalizer();
                if (validatebusinessrules)
                {
                    CommandsSendForRecorLocalizer();
                    VerifyYieldedRecord();
                }
            }
            if (rdoNumberTicket.Checked == true)
            {
                ValidateBusinessRulesForNumberTicket();

                if (validatebusinessrules)
                {
                    CommandsSendForNumberTicket();
                    VerifyYieldedRecord();

                }
            }
            if (rdoNumberFlight.Checked == true)
            {
                ValidateBusinessRulesForNumberFlight();
                if (validatebusinessrules)
                {
                    CommandsSendForNumberFlight();
                    VerifyYieldedRecord();
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
            monthCalendar1.SendToBack();
        }

        #endregion

        #region====== Change focus all controls =======

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            if (txtLastName.Text.Length == 15)
                txtName.Focus();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Length == 16)
                txtPCC.Focus();
        }

        private void txtPCC_TextChanged(object sender, EventArgs e)
        {
            if (txtPCC.Text.Length == 4)
                btnAccept.Focus();
        }

        private void txtRecordLocalizer_TextChanged(object sender, EventArgs e)
        {
            if (txtRecordLocalizer.Text.Length == 6)
                btnAccept.Focus();
        }

        private void txtNumberTicket_TextChanged(object sender, EventArgs e)
        {
            if (txtNumberTicket.Text.Length == 10)
                btnAccept.Focus();
        }

        private void txtDataExit_TextChanged(object sender, EventArgs e)
        {
            if (txtDataExit.Text.Length == 5)
                txtCity.Focus();
        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {
            if (txtCity.Text.Length == 3)
                txtAeroline.Focus();
        }

        private void txtAeroline_TextChanged(object sender, EventArgs e)
        {
            if (txtAeroline.Text.Length == 2)
                txtNumberFlight.Focus();
        }

        private void txtNumberFlight_TextChanged(object sender, EventArgs e)
        {
            if (txtNumberFlight.Text.Length == 4)
                txtLastName1.Focus();
        }

        private void txtLastName1_TextChanged(object sender, EventArgs e)
        {
            if (txtLastName1.Text.Length == 15)
                btnAccept.Focus();
        }

        #endregion

        #region====== Hide and Show Text ======

        /// <summary>
        /// Se muestran y ocultan controles de acuerdo a lo elegido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void rdoName_CheckedChanged(object sender, EventArgs e)
        {
            ShowandHideForName();
            TabStopRdo();
        }

        private void rdoRecorLocalizer_CheckedChanged(object sender, EventArgs e)
        {
            ShowandHideForRecorLocalizer();
            TabStopRdo();
        }

        private void rdoNumberTicket_CheckedChanged(object sender, EventArgs e)
        {
            ShowandHideForNumberTicket();
            TabStopRdo();
        }

        private void rdoNumberFlight_CheckedChanged(object sender, EventArgs e)
        {
            ShowandHideForNumberFlight();
            TabStopRdo();
        }

        #endregion

        #region ====== TabStop =======
        /// <summary>
        /// Esta función se encarga de que el Tab tenga la funcionalidad
        /// de ir pasando entre los controles
        /// </summary>
        public void TabStopRdo()
        {
            rdoName.TabStop = true;
            rdoNumberFlight.TabStop = true;
            rdoNumberTicket.TabStop = true;
            rdoRecorLocalizer.TabStop = true;
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
        /// Muestra controles, oculata otros controles y 
        /// limpiar controles 
        /// </summary>
        private void ShowandHideForName()
        {
            lblLastName.Visible = true;
            lblName.Visible = true;
            lblPCC.Visible = true;
            txtLastName.Visible = true;
            txtName.Visible = true;
            txtPCC.Visible = true;
            lblDateExit.Visible = false;
            lblCity.Visible = false;
            lblAeroline.Visible = false;
            lblLastName1.Visible = false;
            txtDataExit.Visible = false;
            txtCity.Visible = false;
            txtAeroline.Visible = false;
            txtLastName1.Visible = false;
            txtRecordLocalizer.Visible = false;
            txtNumberTicket.Visible = false;
            txtNumberFlight.Visible = false;
            lblNumberFlight.Visible = false;
            picCalender.Visible = false;
            txtAeroline.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtDataExit.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtLastName1.Text = string.Empty;
            txtName.Text = string.Empty;
            txtNumberTicket.Text = string.Empty;
            txtRecordLocalizer.Text = string.Empty;
            txtNumberFlight.Text = string.Empty;
            txtLastName.Focus();
        }

        /// <summary>
        /// Muestra controles, oculata otros controles y 
        /// limpiar controles 
        /// </summary>
        private void ShowandHideForRecorLocalizer()
        {
            txtRecordLocalizer.Visible = true;
            lblDateExit.Visible = false;
            lblCity.Visible = false;
            lblAeroline.Visible = false;
            lblLastName1.Visible = false;
            txtDataExit.Visible = false;
            txtCity.Visible = false;
            txtAeroline.Visible = false;
            txtLastName1.Visible = false;
            txtNumberTicket.Visible = false;
            lblLastName.Visible = false;
            lblName.Visible = false;
            lblPCC.Visible = false;
            txtLastName.Visible = false;
            txtName.Visible = false;
            txtPCC.Visible = false;
            txtNumberFlight.Visible = false;
            lblNumberFlight.Visible = false;
            picCalender.Visible = false;
            txtAeroline.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtDataExit.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtLastName1.Text = string.Empty;
            txtName.Text = string.Empty;
            txtNumberTicket.Text = string.Empty;
            txtRecordLocalizer.Text = string.Empty;
            txtNumberFlight.Text = string.Empty;
            txtPCC.Text = string.Empty;
            txtRecordLocalizer.Focus();
        }

        /// <summary>
        /// Muestra controles, oculata otros controles y 
        /// limpiar controles 
        /// </summary>
        private void ShowandHideForNumberTicket()
        {
            rdoRecorLocalizer.TabStop = true;
            txtNumberTicket.Visible = true;
            lblDateExit.Visible = false;
            lblCity.Visible = false;
            lblAeroline.Visible = false;
            lblLastName1.Visible = false;
            txtDataExit.Visible = false;
            txtCity.Visible = false;
            txtAeroline.Visible = false;
            txtLastName1.Visible = false;
            txtRecordLocalizer.Visible = false;
            lblLastName.Visible = false;
            lblName.Visible = false;
            lblPCC.Visible = false;
            txtLastName.Visible = false;
            txtName.Visible = false;
            txtPCC.Visible = false;
            txtNumberFlight.Visible = false;
            lblNumberFlight.Visible = false;
            picCalender.Visible = false;
            txtAeroline.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtDataExit.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtLastName1.Text = string.Empty;
            txtName.Text = string.Empty;
            txtNumberTicket.Text = string.Empty;
            txtRecordLocalizer.Text = string.Empty;
            txtNumberTicket.Text = string.Empty;
            txtPCC.Text = string.Empty;
            txtNumberTicket.Focus();
        }

        /// <summary>
        /// Muestra controles, oculata otros controles y 
        /// limpiar controles 
        /// </summary>
        private void ShowandHideForNumberFlight()
        {
            rdoRecorLocalizer.TabStop = true;
            rdoNumberTicket.TabStop = true;
            lblDateExit.Visible = true;
            lblCity.Visible = true;
            lblAeroline.Visible = true;
            lblLastName1.Visible = true;
            txtDataExit.Visible = true;
            txtCity.Visible = true;
            txtAeroline.Visible = true;
            txtLastName1.Visible = true;
            txtNumberFlight.Visible = true;
            lblNumberFlight.Visible = true;
            picCalender.Visible = true;
            lblLastName.Visible = false;
            lblName.Visible = false;
            lblPCC.Visible = false;
            txtLastName.Visible = false;
            txtName.Visible = false;
            txtPCC.Visible = false;
            txtRecordLocalizer.Visible = false;
            txtNumberTicket.Visible = false;
            txtAeroline.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtDataExit.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtLastName1.Text = string.Empty;
            txtName.Text = string.Empty;
            txtNumberTicket.Text = string.Empty;
            txtRecordLocalizer.Text = string.Empty;
            txtPCC.Text = string.Empty;
            txtDataExit.Focus();
        }

        /// <summary>
        /// Se validan que existan los datos que son obligatorios y que 
        /// sean los datos correctos
        /// </summary>
        private void ValidateBusinessRulesForName()
        {
            validatebusinessrules = true;
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                MessageBox.Show(Resources.Reservations.INGRESE_APELLIDO_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLastName.Focus();
                validatebusinessrules = false;
            }
            //if (string.IsNullOrEmpty(txtName.Text))
            //{
            //    MessageBox.Show(Resources.Reservations.INGRESE_NOMBRE_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtName.Focus();
            //}
        }

        /// <summary>
        /// Se validan que existan los datos que son obligatorios y que 
        /// sean los datos correctos
        /// </summary>
        private void ValidateBusinessRulesForRecorLocalizer()
        {
            validatebusinessrules = false;
            if (string.IsNullOrEmpty(txtRecordLocalizer.Text))
            {
                MessageBox.Show(Resources.Reservations.INGRESA_RECORD_LOCALIZADOR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRecordLocalizer.Focus();
            }
            else if (txtRecordLocalizer.Text.Length <= 5)
            {
                MessageBox.Show(Resources.Reservations.RECORD_LOCALIZADOR_DEBE_TENER_6_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRecordLocalizer.Focus();
            }
            else
                validatebusinessrules = true;
        }

        /// <summary>
        /// Se validan que existan los datos que son obligatorios y que 
        /// sean los datos correctos
        /// </summary>
        private void ValidateBusinessRulesForNumberTicket()
        {
            validatebusinessrules = false;
            if (string.IsNullOrEmpty(txtNumberTicket.Text))
            {
                MessageBox.Show(Resources.Reservations.INGRESA_NÚMERO_BOLETO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNumberTicket.Focus();
            }
            else if (txtNumberTicket.Text.Length <= 9)
            {
                MessageBox.Show(Resources.Reservations.NÚMERO_BOLETO_DEBE_TENER_10_DÍGITOS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNumberTicket.Focus();
            }
            else
                validatebusinessrules = true;
        }

        /// <summary>
        /// Se validan que existan los datos que son obligatorios y que 
        /// sean los datos correctos
        /// </summary>
        private void ValidateBusinessRulesForNumberFlight()
        {
            validatebusinessrules = false;
            if (string.IsNullOrEmpty(txtDataExit.Text))
            {
                MessageBox.Show(Resources.Reservations.INGRESA_FECHA_SALIDA_VUELO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDataExit.Focus();
            }
            else if (string.IsNullOrEmpty(txtCity.Text))
            {
                MessageBox.Show(Resources.Reservations.INGRESA_CÓDIGO_CIUDAD, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCity.Focus();
            }
            else if (txtCity.Text.Length <= 2)
            {
                MessageBox.Show(Resources.Reservations.CIUDAD_DEBE_TENER_3_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCity.Focus();
            }
            else if (string.IsNullOrEmpty(txtAeroline.Text))
            {
                MessageBox.Show(Resources.Reservations.INGRESA_CÓDIGO_AEROLÍNEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAeroline.Focus();
            }
            else if (txtAeroline.Text.Length <= 1)
            {
                MessageBox.Show(Resources.Reservations.CÓDIGO_AEROLÍNEA_DEBE_TENER_2_DÍG, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAeroline.Focus();
            }
            else if (string.IsNullOrEmpty(txtNumberFlight.Text))
            {
                MessageBox.Show(Resources.Reservations.INGRESA_NÚEMRO_VUELO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNumberFlight.Focus();
            }
            else if (string.IsNullOrEmpty(txtLastName1.Text))
            {
                MessageBox.Show(Resources.Reservations.INGRESE_APELLIDO_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLastName1.Focus();
            }
            else if (!ValidateRegularExpression.ValidateDateFormat(txtDataExit.Text))
            {
                MessageBox.Show(Resources.Reservations.FORMAT_FECHA_DOS_NUM_TRES_ALFA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDataExit.Focus();
            }
            else if (statusDate)
            {
                MessageBox.Show(Resources.Reservations.FECHA_SELEC_MENOR_ACTUAL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDataExit.Focus();
            }
            else
                validatebusinessrules = true;
        }

        /// <summary>
        /// Se envia el comando de acuerdo a los campos ingresados
        /// </summary>
        private void CommandsSendForName()
        {
            if ((!string.IsNullOrEmpty(txtLastName.Text)) &&
                (!string.IsNullOrEmpty(txtName.Text))&&
                string.IsNullOrEmpty(txtPCC.Text))
            {
                send = Resources.Constants.COMMANDS_AST_INDENT + 
                        txtLastName.Text + Resources.Constants.SLASH + 
                        txtName.Text;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                  result= objCommand.SendReceive(send);
                }
            }
            else if ((!string.IsNullOrEmpty(txtLastName.Text)) &&
                (!string.IsNullOrEmpty(txtName.Text)) &&
                (!string.IsNullOrEmpty(txtPCC.Text)))
            {
                send = Resources.Constants.COMMANDS_AST_INDENT + 
                        txtPCC.Text + Resources.Constants.INDENT + 
                        txtLastName.Text + Resources.Constants.SLASH +
                        txtName.Text;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                  result= objCommand.SendReceive(send);
                }
            }

            else if ((!string.IsNullOrEmpty(txtLastName.Text)) &&
                (string.IsNullOrEmpty(txtName.Text)) &&
                string.IsNullOrEmpty(txtPCC.Text))
            {
                send = Resources.Constants.COMMANDS_AST_INDENT +
                        txtLastName.Text;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                   result= objCommand.SendReceive(send);
                }
            }
            else if ((!string.IsNullOrEmpty(txtLastName.Text)) &&
                (string.IsNullOrEmpty(txtName.Text)) &&
                (!string.IsNullOrEmpty(txtPCC.Text)))
            {
                send = Resources.Constants.COMMANDS_AST_INDENT +
                        txtPCC.Text + Resources.Constants.INDENT +
                        txtLastName.Text;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                  result=  objCommand.SendReceive(send);
                }
            }
        }

        /// <summary>
        /// Se envia el comando de acuerdo a los campos ingresados
        /// </summary>
        private void CommandsSendForRecorLocalizer()
        {
            send = Resources.Constants.AST + txtRecordLocalizer.Text;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }

        /// <summary>
        /// Se envia el comando de acuerdo a los campos ingresados
        /// </summary>
        private void CommandsSendForNumberTicket()
        {
            send = Resources.Constants.COMMANDS_AST_TKT + txtNumberTicket.Text;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
               objCommand.SendReceive(send);
            }
        }

        /// <summary>
        /// Se envia el comando de acuerdo a los campos ingresados
        /// </summary>
        private void CommandsSendForNumberFlight()
        {
            if ((!string.IsNullOrEmpty(txtLastName1.Text)) &&
                (!string.IsNullOrEmpty(txtDataExit.Text)) &&
                (!string.IsNullOrEmpty(txtCity.Text)) &&
                (!string.IsNullOrEmpty(txtAeroline.Text)) &&
                (!string.IsNullOrEmpty(txtNumberFlight.Text)))
            {
                send = Resources.Constants.AST + txtAeroline.Text + 
                    txtNumberFlight.Text + Resources.Constants.SLASH +
                    txtDataExit.Text + txtCity.Text + Resources.Constants.INDENT + 
                    txtLastName1.Text;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(send);
                }
            }
        }

        /// <summary>
        /// Verifica respuesta
        /// </summary>
        private void APIResponse()
        {
            if ((!string.IsNullOrEmpty(result)))
            {
                CommandsQik.searchResponse(result, Resources.ErrorMessages.ONE,ref col,ref row, 1, 2);
                if (row == 2 && col == 1)
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCRECORDSELECT);
                else
                    VerifyYieldedRecord();
            }
        }

        /// <summary>
        /// Vefirica el Record
        /// </summary>
        private void VerifyYieldedRecord()
        {
            string send = string.Empty;
            string sabreAnswer = string.Empty;
            int row = 0;
            int col = 0;
            send = Resources.TicketEmission.Constants.COMMANDS_AST_P6;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }
            CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.TA_SLASH, ref row, ref col, 1, 1, 15, 22);
            if (row != 0 || col != 0)
            {
                send = Resources.TicketEmission.Constants.COMMANDS_XPG;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(send);
                }
                MessageBox.Show(Resources.TicketEmission.Tickets.RECORD_CEDIDO_CERRAR_CERRAR_ANTES_BOLETEAR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }

        #endregion
    }
}
