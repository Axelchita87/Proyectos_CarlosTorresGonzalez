using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Presentation.Components;
using MyCTS.Services;
using MyCTS.Services.Contracts;


namespace MyCTS.Presentation
{
    public partial class ucRateAvobe : CustomUserControl
    {
        /// <summary>
        /// Descripción: Muestra las tarifas de fechas anteriores de un itinerario
        /// Creación:    29 -Enero 10, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Jessica Gutiérrez
        /// </summary>

        private TextBox txt;
        private bool pic1;
        private bool pic2;

        public ucRateAvobe()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtTicketsDate;
            this.LastControlFocus = btnAccept;
        }

        //Load user Control Rate Avobe
        private void ucRateAvobe_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            CalendarStateBack();
            txtTicketsDate.Focus();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidBussinessRules)
            {
                commandsSend();
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
        }

        #region ==== MethodsClass =====

        /// <summary>
        /// Escode el calendario grafico
        /// </summary>
        private void CalendarStateBack()
        {
            monthCalendar1.BackColor = GetCalendarColor;
            monthCalendar1.BackColor = GetCalendarColor;
            monthCalendar1.Visible = false;
            monthCalendar1.SendToBack();
        }

        /// <summary>
        /// Muestra el calendario grafico cuando es llamado
        /// </summary>
        private void CalendarStateFront()
        {
            monthCalendar1.Visible = true;
            monthCalendar1.BringToFront();
            monthCalendar1.Focus();
        }

        private bool IsValidBussinessRules
        {
            get
            {
                bool isValid = false;

                if (string.IsNullOrEmpty(txtTicketsDate.Text))
                {
                    MessageBox.Show(Resources.Reservations.NECESITAS_INGRESAR_FECHA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTicketsDate.Focus();
                }
                else if (string.IsNullOrEmpty(txtDepartureDate.Text))
                {
                    MessageBox.Show(Resources.Reservations.NECESITAS_INGRESAR_FECHA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDepartureDate.Focus();
                }
                else if (!string.IsNullOrEmpty(txtTicketsDate.Text) && txtTicketsDate.Text.Length > 7)
                {
                    MessageBox.Show(Resources.Reservations.FECHA_DEBE_TENER_7_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTicketsDate.Focus();
                }
                else if (!string.IsNullOrEmpty(txtDepartureDate.Text) && txtDepartureDate.Text.Length > 7)
                {
                    MessageBox.Show(Resources.Reservations.FECHA_DEBE_TENER_7_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDepartureDate.Focus();
                }
                else if (string.IsNullOrEmpty(txtOriginCity.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_CÓDIGO_CIUDAD, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtOriginCity.Focus();
                }
                else if (!string.IsNullOrEmpty(txtOriginCity.Text) && txtOriginCity.Text.Length>3)
                {
                    MessageBox.Show(Resources.Reservations.COD_CUIDAD_ORIGEN_TRES_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtOriginCity.Focus();
                }
                else if (string.IsNullOrEmpty(txtDestinationCity.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_CÓDIGO_CIUDAD, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDestinationCity.Focus();
                }
                else if (!string.IsNullOrEmpty(txtDestinationCity.Text) && txtDestinationCity.Text.Length > 3)
                {
                    MessageBox.Show(Resources.Reservations.COD_CUIDAD_DESTINO_TRES_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDestinationCity.Focus();
                }
                else if (string.IsNullOrEmpty(txtAirLine.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_COD_AEREOLINEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirLine.Focus();
                }
                else if (!string.IsNullOrEmpty(txtAirLine.Text) && txtAirLine.Text.Length>2)
                {
                    MessageBox.Show(Resources.Reservations.CÓDIGO_AEROLÍNEA_DEBE_TENER_2_DÍG, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirLine.Focus();
                }
                else if (!string.IsNullOrEmpty(txtCurrency.Text) && txtCurrency.Text.Length > 4)
                {
                    MessageBox.Show(Resources.Reservations.COD_MONEDA_DEBE_SER_TRES_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCurrency.Focus();
                }
                else if (!ValidateRegularExpression.ValidateDateFormatYear(txtDepartureDate.Text))
                {
                    MessageBox.Show(Resources.Reservations.FECHA_DEBE_TENER_7_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDepartureDate.Focus();
                }
                else if (!ValidateRegularExpression.ValidateDateFormatYear(txtTicketsDate.Text))
                {
                    MessageBox.Show(Resources.Reservations.FECHA_DEBE_TENER_7_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTicketsDate.Focus();
                }
                else
                    isValid = true;

                return isValid;
            }
        }

        private void commandsSend()
        {
            string send=string.Empty;

            send = "FQ";
            send = string.Concat(send, txtTicketsDate.Text, txtOriginCity.Text,
                txtDestinationCity.Text, txtDepartureDate.Text, Resources.Constants.INDENT,
                txtAirLine.Text);
            if(!string.IsNullOrEmpty(txtCurrency.Text))
                send=string.Concat(send,Resources.Constants.SLASH, txtCurrency.Text);

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                 objCommand.SendReceive(send);
            }
        }

        #endregion

        #region=====Show MonthCalendar=====

        /// <summary>
        /// Ejecuta la función calendarStateFront() cuando se presiona el 
        /// picture box picCalendar
        /// </summary>
        /// <param name="sender">picCalendar</param>
        /// <param name="e"></param>
         
        private void picCalender_Click(object sender, EventArgs e)
        {
            pic1 = true;
            CalendarStateFront();
        }

        private void picCalendar2_Click(object sender, EventArgs e)
        {
            pic2 = true;
            CalendarStateFront();
        }
        
        #endregion//End Show MonthCalendar

        #region=====Hide MonthCalendar With Key Escape=====

        /// <summary>
        /// Esconde el calendario grafico al presionar la tecla ESC cuando
        /// este tiene el foco
        /// </summary>
        /// <param name="sender">monthCalendar1</param>
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

        #endregion//End Hide MonthCalendar With Key Escape

        #region=====Hide monthCalendar When the Focus Leave it=====

        /// <summary>
        /// Esconde el calendario grafico cuando este no tiene el foco
        /// </summary>
        /// <param name="sender">monthCalendar1</param>
        /// <param name="e"></param>
        private void monthCalendar1_Leave(object sender, EventArgs e)
        {
            monthCalendar1.SendToBack();
            monthCalendar1.Visible = false;
        }
        #endregion//End Hide monthCalendar When the Focus Leave it

        #region=====Select Date from MonthCalendar=====

        /// <summary>
        /// Selección de fecha por calendario grafico y validación de
        /// fecha no menor a la actual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
           string dateCalendar;
           string month;
           string year;
           string day;

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
            DateTime today = DateTime.Today;
            //Fecha a enviar
            string date = day + month + year;
            if (pic1)
            {
                txtTicketsDate.Text = date;
                txtTicketsDate.Focus();
            }
            if (pic2)
            {
                txtDepartureDate.Text = date;
                txtDepartureDate.Focus();
            }

            monthCalendar1.SendToBack();

            monthCalendar1.Visible = false;
            pic1 = false;
            pic2 = false;

        }

        #endregion//End Select Date from MonthCalendar

        #region =====Back to a Previous Usercontrol or Validate Enter KeyDown=====

        /// <summary>
        /// Aborta el proceso enviando a la mascarilla de welcome
        /// al presionar la tecla ESC o ejecuta las funciones al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            if (e.KeyData.Equals(Keys.Enter))
                btnAccept_Click(sender, e);
            if (e.KeyCode == Keys.Down)
            {
                if (lbGeneric.Items.Count > 0)
                {
                    lbGeneric.SelectedIndex = 0;
                    lbGeneric.Focus();
                    lbGeneric.Visible = true;
                    lbGeneric.Focus();
                }
            }
        }

        #endregion//Back to a Previous Usercontrol or Validate Enter KeyDown

        #region===== listbox Controls Events=====

        /// <summary>
        /// Asignación de acciones al presionar la tecla ENTER o ESC 
        /// cuando el lbGeneric tiene el foco
        /// </summary>
        /// <param name="sender">lbGeneric</param>
        /// <param name="e"></param>
        private void lbGeneric_KeyDown(object sender, KeyEventArgs e)
        {
            ListBox ListBox = (ListBox)sender;
            if (e.KeyCode == Keys.Enter)
            {
                ListItem li = (ListItem)ListBox.SelectedItem;
                txt.Text = li.Value;
                ListBox.Visible = false;
                txt.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                lbGeneric.Visible = false;
                txt.Focus();
            }
        }

        /// <summary>
        /// Selecciona algún elemento dentro de algún listbox al hacer un click
        /// sobre el
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_MouseClick(object sender, MouseEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            ListItem li = (ListItem)listBox.SelectedItem;
            txt.Text = li.Value;
            listBox.Visible = false;
            txt.Focus();
        }

        #endregion//End lbControls events  

        #region ====== Change Focus ========

        private void txtOriginCity_TextChanged(object sender, EventArgs e)
        {
                txt = (TextBox)sender;
                Common.SetListBoxAirports(txt, lbGeneric);
        }

        private void txtDestinationCity_TextChanged(object sender, EventArgs e)
        {
                txt = (TextBox)sender;
                Common.SetListBoxAirports(txt, lbGeneric);
        }

        private void txtAirLine_TextChanged(object sender, EventArgs e)
        {
                txt = (TextBox)sender;
                Common.SetListBoxAirlines(txt, lbGeneric);
        }

        private void txtCurrency_TextChanged(object sender, EventArgs e)
        {
            txt = (TextBox)sender;
            Common.SetListBoxCurrenciesCountries(txt, lbGeneric);
        }

        private void txtTicketsDate_TextChanged(object sender, EventArgs e)
        {
            if (txtTicketsDate.Text.Length > 6)
                txtDepartureDate.Focus();
        }

        private void txtDepartureDate_TextChanged(object sender, EventArgs e)
        {
            if (txtDepartureDate.Text.Length > 6)
                txtOriginCity.Focus();
        }

        #endregion
    }
}
