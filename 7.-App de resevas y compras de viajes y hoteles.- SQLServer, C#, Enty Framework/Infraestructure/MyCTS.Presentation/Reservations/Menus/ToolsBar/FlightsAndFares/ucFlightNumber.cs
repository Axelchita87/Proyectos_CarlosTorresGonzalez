using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Presentation.Components;
using MyCTS.Services;
using MyCTS.Services.Contracts;

namespace MyCTS.Presentation
{
    public partial class ucFlightNumber : CustomUserControl
    {

        /// <summary>
        /// Descripción: User Control que permite desplegar el número de vuelo
        /// Creación:    28 -Enero 10, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Jessica Gutierrez
        /// </summary>


        private TextBox txt;

        public ucFlightNumber()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtDate;
            this.LastControlFocus = btnAccept;
           
        }

        private void ucFlightNumber_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            CalendarStateBack();
            txtDate.Focus();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidBusinessRules)
            {
                CommandsSend();
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
        }

        private void txtAirLine_TextChanged(object sender, EventArgs e)
        {
            txt = (TextBox)sender;
            Common.SetListBoxAirlines(txt, lbAirlines);
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

        /// <summary>
        /// Verifica que se ingresen los datos obligatorios
        /// </summary>
        /// <returns></returns>
        private bool IsValidBusinessRules
        {
            get
            {
                bool isValid=false;

                if (!string.IsNullOrEmpty(txtDate.Text) && !ValidateRegularExpression.ValidateDateFormat(txtDate.Text))
                {
                    MessageBox.Show(Resources.Reservations.FORMAT_FECHA_DOS_NUM_TRES_ALFA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDate.Focus();
                }
                else if (string.IsNullOrEmpty(txtAirLine.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_COD_AEREOLINEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirLine.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtAirLine.Text)) && (txtAirLine.Text.Length != 2))
                {
                    MessageBox.Show(Resources.Reservations.COD_AEREOLINEA_DEBE_SER_DOS_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirLine.Focus();
                }
                else if (string.IsNullOrEmpty(txtFlightNumber.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_NÚEMRO_VUELO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFlightNumber.Focus();
                }
                else
                {
                    isValid = true;
                }
                return isValid;
            }
        }

        private void CommandsSend()
        {
            string send=string.Empty;
            string result=string.Empty;
            int row = 0;
            int col = 0;

            send = "2";
            send = string.Concat(send, txtAirLine.Text, txtFlightNumber.Text);
            if (!string.IsNullOrEmpty(txtDate.Text))
                send = string.Concat(send, Resources.Constants.SLASH, txtDate.Text);
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                result=objCommand.SendReceive(send);
            }


            CommandsQik.searchResponse(result, "@md", ref row, ref col);
            if (row != 0 || col != 0)
            {
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive("@md");
                }

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

        private void monthCalendar_KeyDown(object sender, KeyEventArgs e)
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
        private void monthCalendar_Leave(object sender, EventArgs e)
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
        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {

            DateTime dateSelected = monthCalendar1.SelectionStart;
            string date = dateSelected.ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
            txtDate.Text = date;
            
                monthCalendar1.SendToBack();

            
            monthCalendar1.Visible = false;

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
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }

            if (e.KeyCode == Keys.Down)
            {
                if (lbAirlines.Items.Count > 0)
                {
                    lbAirlines.SelectedIndex = 0;
                    lbAirlines.Focus();
                    lbAirlines.Visible = true;
                    lbAirlines.Focus();
                }
            }

        }

        #endregion//Back to a Previous Usercontrol or Validate Enter KeyDown

        #region===== listbox Controls Events=====

        /// <summary>
        /// Asignación de acciones al presionar la tecla ENTER o ESC 
        /// cuando el lbAirlines tiene el foco
        /// </summary>
        /// <param name="sender">lbAirlines</param>
        /// <param name="e"></param>
        private void lbAirlines_KeyDown(object sender, KeyEventArgs e)
        {
            ListBox ListBox = (ListBox)sender;
            if (e.KeyCode == Keys.Enter)
            {
                ListItem li = (ListItem)ListBox.SelectedItem;
                txtAirLine.Text = li.Value;
                ListBox.Visible = false;
                txtAirLine.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                lbAirlines.Visible = false;
                txtAirLine.Focus();
            }

            if (e.KeyCode == Keys.Down)
            {
                if (lbAirlines.Items.Count > 0)
                {
                    lbAirlines.SelectedIndex = 0;
                    lbAirlines.Focus();
                    lbAirlines.Visible = true;
                    lbAirlines.Focus();
                }
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
            txtAirLine.Text = li.Value;
            listBox.Visible = false;
            txtAirLine.Focus();
        }

        #endregion

        #region ======== Change Focus ========

        private void txtDate_TextChanged(object sender, EventArgs e)
        {
            if (txtDate.Text.Length > 4)
                txtAirLine.Focus();
        }

        private void txtFlightNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtFlightNumber.Text.Length > 4)
                btnAccept.Focus();
        }

        #endregion





    }
}
