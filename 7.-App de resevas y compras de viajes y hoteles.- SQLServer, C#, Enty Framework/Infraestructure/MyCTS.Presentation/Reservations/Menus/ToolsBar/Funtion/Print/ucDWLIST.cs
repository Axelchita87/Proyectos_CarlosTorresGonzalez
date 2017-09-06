using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Entities;

namespace MyCTS.Presentation
{
    public partial class ucDWLIST : CustomUserControl
    {
        /// <summary>
        /// Descripción: User Control que permite reemprimir documento DWLIST con una 
        ///              serie de opciones
        /// Creación:    MArzo - Abril 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        /// 
        private string sabreAnswer;
        private string send;
        private string dateNow;
        private bool isValid;
        private bool statusDate;
        private bool statusFirstClick;
        private bool firstCommandSend;

        public ucDWLIST()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtLocalizerRecord;
            this.LastControlFocus = btnAccept;
        }


        /// <summary>
        /// Se carga la mascarilla de "Imprimir documento DWLIST"
        /// y asignación de valores iniciales
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucDWLIST_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            CalendarStateBack();
            InitialStateControls();
        }


        /// <summary>
        /// Ejecuta las funciones de la mascarilla al presionar el boton
        /// "Aceptar"
        /// </summary>
        /// <param name="sender">btnAccept</param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!statusFirstClick)
            {
                if (!FirstValidateBusinessRules)
                {
                    FirstCommandsSend();
                    APIResponse();
                }
            }
            else
            {
                if (!SecondValidateBusinessRules)
                {
                    SecondCommandsSend();
                    APIResponse();
                }
            }

        }


        /// <summary>
        /// Ejecuta la función pageMoveUp() al presionar el boton
        /// Reg.Pag
        /// </summary>
        /// <param name="sender">btnMoveUp</param>
        /// <param name="e"></param>
        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            PageMoveUp();
        }


        /// <summary>
        /// Ejecuta la función pageMoveDown() al presionar el boton
        /// Av.Pag
        /// </summary>
        /// <param name="sender">btnMoveDown</param>
        /// <param name="e"></param>
        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            PageMoveDown();
        }

        #region===== MethodsClass =====


        /// <summary>
        /// Establece los estados de los controles al cargar la mascarilla
        /// </summary>
        private void InitialStateControls()
        {
            firstCommandSend = false;
            DateTime today = DateTime.Now;
            dateNow = today.ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
            txtDateSelected.Text = dateNow;
            lblItemtoPrint.Visible = false;
            txtItemToPrint.Visible = false;
            statusFirstClick = false;
            btnMoveUp.Visible = false;
            btnMoveUp.Enabled = false;
            btnMoveDown.Visible = false;
            btnMoveDown.Enabled = false;
            txtLocalizerRecord.Focus();
        }



        #region===== First Command Methods =====


        /// <summary>
        /// Reglas de negocio correspondientes a esta mascarilla del primer comando
        /// </summary>
        /// <returns></returns>
        private bool FirstValidateBusinessRules
        {
            get
            {
                isValid = true;
                if ((!string.IsNullOrEmpty(txtLocalizerRecord.Text)) &&
                    (txtLocalizerRecord.Text.Length != 6))
                {
                    MessageBox.Show(Resources.Reservations.CODIGO_RESERVA_DEBE_SER_SEIS_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLocalizerRecord.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtLocalizerRecord.Text)) &&
                    (Regex.IsMatch(txtLocalizerRecord.Text, " ")))
                {
                    MessageBox.Show(Resources.Reservations.NO_ESPACIOS_CODIGO_RESERVA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLocalizerRecord.Focus();
                }
                else if ((!ValidateRegularExpression.ValidateDateFormat(txtDateSelected.Text)) &&
                    (!string.IsNullOrEmpty(txtDateSelected.Text)))
                {
                    MessageBox.Show(Resources.Reservations.FORMAT_FECHA_DOS_NUM_TRES_ALFA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDateSelected.Focus();
                }
                else if (statusDate)
                {
                    MessageBox.Show(Resources.Reservations.FECHA_SELECCIONADA_MAYOR_ACTUAL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDateSelected.Focus();
                    statusDate = false;
                }
                else
                {
                    isValid = false;
                }
                return isValid;
            }
        }


        /// <summary>
        /// Armado y envio del comando a MySabre por primera vez
        /// </summary>
        private void FirstCommandsSend()
        {
            string dateSelected;
            string localizerRecord;
            string dWLIST;
            send = string.Empty;
            localizerRecord = Resources.Constants.COMMANDS_MD_SLASH;
            dWLIST = Resources.Constants.COMMANDS_DWLIST;
            if ((txtDateSelected.Text.Equals(dateNow)) ||
                (string.IsNullOrEmpty(txtDateSelected.Text)))
            {
                dateSelected = string.Empty;
            }
            else
            {
                dateSelected = string.Concat(Resources.Constants.SLASH,
                    txtDateSelected.Text);
            }
            send = string.Concat(dWLIST,
                dateSelected);
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }
            firstCommandSend = true;
            send = string.Empty;
            if (!string.IsNullOrEmpty(txtLocalizerRecord.Text))
            {
                send = string.Concat(localizerRecord,
                    txtLocalizerRecord.Text);
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(send);
                }
            }
            else
            {
                btnMoveUp.Visible = true;
                btnMoveUp.Enabled = true;
                btnMoveDown.Visible = true;
                btnMoveDown.Enabled = true;
            }
            this.InitialControlFocus = txtItemToPrint;
            txtItemToPrint.Focus();
            txtLocalizerRecord.Enabled = false;
            txtLocalizerRecord.BackColor = SystemColors.Control;
            txtDateSelected.Enabled = false;
            txtDateSelected.BackColor = SystemColors.Control;
            picCalendar.Enabled = false;
            lblItemtoPrint.Visible = true;
            txtItemToPrint.Visible = true;
            statusFirstClick = true;
        }


        #endregion// End First Command



        #region===== Second Command Methods =====


        /// <summary>
        /// Reglas de negocio correspondientes a esta mascarilla para el segundo comando
        /// </summary>
        private bool SecondValidateBusinessRules
        {
            get
            {
                isValid = true;
                if (string.IsNullOrEmpty(txtItemToPrint.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_NUMERO_ITEM, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLocalizerRecord.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtItemToPrint.Text)) &&
                    (Regex.IsMatch(txtItemToPrint.Text, " ")))
                {
                    MessageBox.Show(Resources.Reservations.NO_ESPACIOS_ITEM_A_IMPRIMIR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLocalizerRecord.Focus();
                }
                else
                {
                    isValid = false;
                }
                return isValid;
            }
        }


        /// <summary>
        /// Armado y envio del comando a MySabre por segunda vez
        /// </summary>
        private void SecondCommandsSend()
        {
            string item;
            item = Resources.Constants.COMMANDS_DPONE_SLASH_THREE;
            send = string.Empty;
            send = string.Concat(item,
                Resources.Constants.SLASH,
                txtItemToPrint.Text);

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }

        }


       /// <summary>
       /// Validación de las probables respuesta erroneas de MySabre
       /// </summary>
        private void APIResponse()
        {
            ERR_DWLIST.err_DWLIST(sabreAnswer);
            if ((ERR_DWLIST.Status == false) && (firstCommandSend))
            {
                return;
            }
            if (ERR_DWLIST.Status == false)
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            else if ((ERR_DWLIST.Status == true) && (ERR_DWLIST.StatusPrinter == true))
            {

                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                MessageBox.Show(ERR_DWLIST.CustomUserMsg, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                send = Resources.Constants.IGNORE;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(send, 0, 0);
                }
            }
            else
            {
                MessageBox.Show(ERR_DWLIST.CustomUserMsg, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }

        }
        #endregion// End Second Command Methods


        /// <summary>
        /// Descripcion: Esconde el calendario grafico
        /// </summary>
        private void CalendarStateBack()
        {
            monthCalendar1.BackColor = Color.FromArgb(255, 255, 192);
            monthCalendar1.Visible = false;
            if (tblLayoutMain.Contains(monthCalendar1))
            {
                monthCalendar1.SendToBack();
            }

        }


        /// <summary>
        /// Muestra el calendario grafico
        /// </summary>
        private void CalendarStateFront()
        {
            monthCalendar1.Visible = true;
            if (tblLayoutMain.Contains(monthCalendar1))
            {
                monthCalendar1.BringToFront();
            }
            monthCalendar1.Focus();
        }


        /// <summary>
        /// Esconde el calendario grafico al presionar la tecla ESC cuando
        /// tiene el foco
        /// </summary>
        /// <param name="e"></param>
        private void HideMonthCalendar(KeyEventArgs e)
        {
            if (monthCalendar1.Focus())
            {
                if (e.KeyData.Equals(Keys.Escape))
                {
                    if (tblLayoutMain.Contains(monthCalendar1))
                    {
                        monthCalendar1.SendToBack();

                    }
                    monthCalendar1.Visible = false;

                }
            }
        }


        /// <summary>
        /// Esconde el calendario grafico cuando este pierde el foco
        /// </summary>
        private void HideMonthCalendarLoseFocus()
        {
            if (tblLayoutMain.Contains(monthCalendar1))
            {
                monthCalendar1.SendToBack();

            }
            monthCalendar1.Visible = false;
        }


        /// <summary>
        /// Selecciona fecha del calendario grafico y valida que esta 
        /// no sea menor a la actual
        /// </summary>
        private void SelectDate()
        {
            statusDate = false;
            DateTime fecha = Convert.ToDateTime(monthCalendar1.SelectionStart);
            string date = fecha.ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
            DateTime today = DateTime.Today;
            if (DateTime.Compare(fecha, today) > 0)
            {
                statusDate = true;
            }
            else
            {
                statusDate = false;
            }
            txtDateSelected.Text = date;
            if (tblLayoutMain.Contains(monthCalendar1))
            {
                monthCalendar1.SendToBack();

            }
            monthCalendar1.Visible = false;
        }


        /// <summary>
        /// Regresa a las opciones previas mostradas en MYSabre al enviar
        /// el comando MU
        /// </summary>
        private void PageMoveUp()
        {
            string send;
            send = Resources.Constants.COMMANDS_MU;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }


        /// <summary>
        /// Muestra las opciones en MySabre al enviar el comando MD
        /// </summary>
        private void PageMoveDown()
        {
            string send;
            send = Resources.Constants.COMMANDS_MD;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }

        }


        #endregion//End MethodsClass



        #region=====Show MonthCalendar=====

        /// <summary>
        /// Ejecuta la función calendarStateFront()  al dar click en el pictureBox
        /// </summary>
        /// <param name="sender">picCalendar</param>
        /// <param name="e"></param>
        private void picCalendar_Click(object sender, EventArgs e)
        {
            CalendarStateFront();
        }
        #endregion//End Show MonthCalendar



        #region=====Hide MonthCalendar With Key Escape=====

        /// <summary>
        /// Ejecuta la función hideMonthCalendar(e)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monthCalendar1_KeyDown(object sender, KeyEventArgs e)
        {
            HideMonthCalendar(e);
        }

        #endregion//End Hide MonthCalendar With Key Escape



        #region=====Hide monthCalendar When the Focus Leave it=====

        /// <summary>
        /// Ejecuta la función hideMonthCalendarLoseFocus()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monthCalendar1_Leave(object sender, EventArgs e)
        {
            HideMonthCalendarLoseFocus();
        }
        #endregion//End Hide monthCalendar When the Focus Leave it



        #region=====Select Date from MonthCalendar=====

        /// <summary>
        /// ejecuta la función selectDate()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
 
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            SelectDate();
        }


        #endregion//End Select Date from MonthCalendar



        #region =====Back to a Previous Usercontrol or Validate Enter KeyDown=====


        /// <summary>
        /// Aborta el proceso al presionar la tecla ESC o ejecuta las 
        /// isntrucciones al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData.Equals(Keys.Escape))
            {
                VolarisSession.Clean();
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }

            if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }
        }


        #endregion//Back to a Previous Usercontrol or Validate Enter KeyDown



        #region=====Change focus When a Textbox is Full=====

        //Evento txtLocalizerRecord_TextChanged
        private void txtLocalizerRecord_TextChanged(object sender, EventArgs e)
        {
            if (txtLocalizerRecord.Text.Length > 5)
            {
                txtDateSelected.Focus();
            }
        }

        //Evento txtDateSelected_TextChanged
        private void txtDateSelected_TextChanged(object sender, EventArgs e)
        {
            if (txtDateSelected.Text.Length > 4)
            {
                btnAccept.Focus();
            }
        }

        //Evento txtItemToPrint_TextChanged
        private void txtItemToPrint_TextChanged(object sender, EventArgs e)
        {
            if (txtItemToPrint.Text.Length > 3)
            {
                btnAccept.Focus();
            }
        }
        #endregion//End Change focus When a Textbox is Full



    }
}
