using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Business;
using MyCTS.Entities;

namespace MyCTS.Presentation
{
    public partial class ucInsertDataPassenger : CustomUserControl
    {
       /// <summary>
        /// Descripcion:Permite Ingresar Datos del Pasajero
        /// al flujo de Reservaciones
        /// Creación: Septiembre 22 - 2009 , Modificación:18-Feb-10
        /// Cambio: Forma de llamar Etiqueta   , Solicito Guillermo
        /// Autor: Jessica Gutierrez 
        /// </summary>

        #region ====== Declaration of variable =====

        private string send;
        private string day;
        private string month;
        private string year;
        private string dk;
        private string date;

        private static string masterpnr;
        public static string MasterPNR
        {
            get { return masterpnr; }
            set { masterpnr = value; }
        }

        #endregion

        public ucInsertDataPassenger()
        {
            InitializeComponent();
             this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtRecordLocalizer;
            this.LastControlFocus = btnAccept;
        }

        //Load de user Control InsertDataPassenger 
        private void ucInsertDataPassenger_Load(object sender, EventArgs e)
        {
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive("I");
            }
            CalendarStateBack();
            txtRecordLocalizer.Focus();
        }

        /// <summary>
        /// Validación de campos y envio de comandos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidateBussinessRules)
            {
                CommandsSend();
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Group.Constants.UC_INSERTDATAPASSENGER2);
            }
        }

        //Evento clic de Calendar
        private void Calendar_Click(object sender, EventArgs e)
        {
            CalendarStateFront();
        }

        /// <summary>
        /// Este se usa para todos los controles en general si se oprime 
        /// Esc se manda a el User control de welcome 
        /// Enter se manda la accion de botón de Aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            else if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }

        #region===== Select Date from MonthCalendar =====

        /// <summary>
        /// Es para validar la fecha del calendario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            string dateCalendar;
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
            //Fecha a enviar
            string date = day + month;
            txtTimeLimit.Text = date;
            monthCalendar1.Visible = false;
            txtTimeLimit.Focus();
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
            monthCalendar1.SendToBack();
            monthCalendar1.Visible = false;
        }

        #endregion

        #region ========= Change Focus ===========

        private void txtTimeLimit_TextChanged(object sender, EventArgs e)
        {
            if (txtTimeLimit.Text.Length > 4)
                txtCodeGroup.Focus();
        }
        private void txtRecordLocalizer_TextChanged(object sender, EventArgs e)
        {
            if (txtRecordLocalizer.Text.Length > 5)
                txtPlaceReserve.Focus();
        }

        private void txtPlaceReserve_TextChanged(object sender, EventArgs e)
        {
            if (txtPlaceReserve.Text.Length > 2)
                txtTimeLimit.Focus();
        }

        private void txtCodeGroup_TextChanged(object sender, EventArgs e)
        {
            if (txtCodeGroup.Text.Length > 9)
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
            monthCalendar1.SendToBack();
        }

        /// <summary>
        /// Llevar el calendario hacia el frente
        /// y que se muestre
        /// </summary>
        private void CalendarStateFront()
        {
            monthCalendar1.Visible = true;
            monthCalendar1.BringToFront();
            monthCalendar1.Focus();
        }

        /// <summary>
        /// Validacion de Reglas de negocio
        /// </summary>
        private bool IsValidateBussinessRules
        {
            get
            {
                if (string.IsNullOrEmpty(txtRecordLocalizer.Text))
                {
                    MessageBox.Show(Resources.Group.Group.REQUIERE_INGRESE_RECORDLOCALIZADOR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRecordLocalizer.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtPlaceReserve.Text))
                {
                    MessageBox.Show(Resources.Group.Group.REQUIERE_INGRESE_LUGARESRESERVAR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPlaceReserve.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtTimeLimit.Text))
                {
                    MessageBox.Show(Resources.Group.Group.REQUIERE_INGRESE_TIEMPOLIMITE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTimeLimit.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtCodeGroup.Text))
                {
                    MessageBox.Show(Resources.Group.Group.REQUIERES_INGRESE_CODIGO_GRUPO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCodeGroup.Focus();
                    return false;
                }
                else if (!ValidateRegularExpression.ValidateDateFormat(txtTimeLimit.Text))
                {
                    date = string.Format(Resources.Reservations.FORMAT_FECHA_DOS_NUM_TRES_ALFA, "\n");
                    MessageBox.Show(date, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTimeLimit.Focus();
                    return false;
                }
                else
                    return true;
            }
        }

        /// <summary>
        /// Envio de comando
        /// </summary>
        private void CommandsSend()
        {
            string timeLimit=string.Empty;
            string codeGroup= string.Empty;
            //DK();
            //if(string.IsNullOrEmpty(dk))
            //{
            //    dk = "SAB003";
            //}
            masterpnr = txtRecordLocalizer.Text;
            send = Resources.Group.Constants.COMMANDS_ZERO_AST;
            send = string.Concat(send, txtRecordLocalizer.Text,
                Resources.Group.Constants.COMMANDS_NN,
                txtPlaceReserve.Text);
            timeLimit= Resources.Group.Constants.COMMANDS_7TAW +
                txtTimeLimit.Text + Resources.Group.Constants.SLASH;
            List<GroupCodeLabel> listXMLRemarks =
                   GroupCodeLabelBL.GetLabelXMLRemarks(txtCodeGroup.Text);
            if (listXMLRemarks.Count > 0)
                codeGroup = listXMLRemarks[0].XMLFutureLabel;
              using (CommandsAPI objCommands = new CommandsAPI())
              {
                  objCommands.SendReceive(send);
                  objCommands.SendReceive(timeLimit);
                  objCommands.SendReceive(codeGroup);
              }
        }

        /// <summary>
        /// En esta funcion extrae el DK, primero se manda un comando
        /// despues se buscada una frase y si la encuentra copia el DK
        /// </summary>
        private void DK()
        {
            string result;
            int col = 0;
            int row = 0;
            send = Resources.TicketEmission.Constants.COMMANDS_AST_PDK;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                result = objCommand.SendReceive(send, 0, 0);

            }
            CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.CUSTOMER_NUMBER, ref row, ref col, 1, 2, 1, 64);
            if (row != 0 || col != 0)
            {
                dk = string.Empty;
                CommandsQik.CopyResponse(result, ref dk, row, 19, 6);
            }
        }

        #endregion
    }
}
