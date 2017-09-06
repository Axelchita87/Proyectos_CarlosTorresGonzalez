using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Business;
using MyCTS.Entities;
using System.Text.RegularExpressions;
using MyCTS.Forms.UI;
using System.Diagnostics;

namespace MyCTS.Presentation
{
    public partial class ucSellAirSegment : CustomUserControl
    {
        /// <summary>
        /// Descripcion:Permite la reservación de los segmentos elegidos,pertenece
        /// al flujo de Reservaciones
        /// Creación: Diciembre 08 -Marzo 09 , Modificación:*
        /// Cambio: *    , Solicito *
        /// Autor: Jessica Gutierrez - Marcos Q. Ramírez
        /// </summary>

        #region====== Declaration of variables =======

        public string[] parametersreceived;
        private string day;
        private string month;
        private string year;
        private string dateCalendar;
        private string result;
        private bool statusDate;
        ListItem oneclass;
        ListItem twoclass;
        ListItem threeclass;

        #endregion

        public ucSellAirSegment()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtSpaceReserve;
            this.LastControlFocus = btnAccept;
            
        }

        //User Control Load
        /// <summary>
        /// Primero se carga el calendario, si contiene parametros los carga
        /// Se llena el combo con la Clase de Aerolínea y se manda el foco al primer elemento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucSellAirSegment_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            ucMenuReservations.AirRateFlag = 0;
            CalendarStateBack();
            ParametersReceived();
            FillAirlineClass();
            txtSpaceReserve.Focus();
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
            if ((!string.IsNullOrEmpty(txtDateSelected.Text)))
            {
                if (IsValidateBusinessRulesOnlyDate)
                    CommandsSendOnlyDate();

                txtDateSelected.Text = string.Empty;
            }
            else
            {
                if (IsValidateBusinessRulesNoDate)
                {
                    CommandsSendNoDate();
                    APIResponse();
                }
            }
        }

        //Show Clendar
        private void Calendar_Click(object sender, EventArgs e)
        {
            CalendarStateFront();
        }

        #region===== More Function Buttons =====

        /// <summary>
        /// En MoreFlight solo manda un comando para mostrar mas vuelos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMoreFlights_Click(object sender, EventArgs e)
        {
            //áplica coloreo
            string Moreflight;
            Moreflight = Resources.Constants.COMMANDS_ONE_AST;
            using (CommandsAPI objCommands = new CommandsAPI())
            {
                result = objCommands.SendReceive(Moreflight);
            }
        }

        /// <summary>
        /// En Original Flight manda un comando en donde nos muestra los primeros vuelos 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOriginalFlight_Click(object sender, EventArgs e)
        {
            //aplica coloreo
            string Originalflights;
            Originalflights = Resources.Constants.COMMANDS_ONE_AST_OA;
            using (CommandsAPI objCommands = new CommandsAPI())
            {
                result = objCommands.SendReceive(Originalflights);
            }
        }

        /// <summary>
        /// More Class manda un comando para mostrar mas clases
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMoreClass_Click(object sender, EventArgs e)
        {
            string Moreclass;
            Moreclass = Resources.Constants.COMMANDS_ONE_AST_C;
            using (CommandsAPI objCommands = new CommandsAPI())
            {
                objCommands.SendReceive(Moreclass);
            }
        }

        /// <summary>
        /// Original Class manda un comando para ver las clases originales
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOriginalClass_Click(object sender, EventArgs e)
        {
            string Originalclass;
            Originalclass = Resources.Constants.COMMANDS_ONE_AST_R;
            using (CommandsAPI objCommands = new CommandsAPI())
            {
                objCommands.SendReceive(Originalclass);
            }
        }

        /// <summary>
        /// Arunk envia un comando en donde agrega un Arunk
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddArunk_Click(object sender, EventArgs e)
        {
            string Addarunk;
            Addarunk = Resources.Constants.COMMANDS_0A;
            using (CommandsAPI objCommands = new CommandsAPI())
            {
                objCommands.SendReceive(Addarunk);
            }
        }

        #endregion

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

        #region ===== Back to a Previous Usercontrol or Validate Enter KeyDown =====

        /// <summary>
        /// Este se usa para todos los controles en general si se oprime 
        /// Esc se manda a el User control de Availability 
        /// Enter se manda la accion de botón de Aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCAVAILABILITY, parametersreceived);

            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }

        #endregion

        #region===== Change focus When a Textbox is Full =====

        /// <summary>
        /// Es para el cambio de Foco entre cada control 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void txtLine1_TextChanged(object sender, EventArgs e)
        {
            if (txtLine1.Text.Length > 1)
                chkSellConnectionSameClass.Focus();
        }

        private void txtLine2_TextChanged(object sender, EventArgs e)
        {
            if (txtLine2.Text.Length > 1)
                cmbBussinesClass3.Focus();
        }

        private void txtLine3_TextChanged(object sender, EventArgs e)
        {
            if (txtLine3.Text.Length > 1)
                txtStatus.Focus();
        }

        private void txtSpaceReserve_TextChanged(object sender, EventArgs e)
        {
            if (txtSpaceReserve.Text.Length > 0)
                cmbBussinesClass1.Focus();
        }

        private void txtDateSelected_TextChanged(object sender, EventArgs e)
        {
            if (txtDateSelected.Text.Length > 4)
                btnAccept.Focus();    
        }

        private void txtStatus_TextChanged(object sender, EventArgs e)
        {
            if (txtStatus.Text.Length > 1)
                txtDateSelected.Focus();
        }

        private void cmbBussinesClass1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBussinesClass1.Text.Length > 2)
                txtLine1.Focus();
        }

        private void cmbBussinesClass2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBussinesClass2.Text.Length > 2)
                txtLine2.Focus();
        }

        private void cmbBussinesClass3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBussinesClass3.Text.Length > 2)
                txtLine3.Focus();
        }
        private void txtDateSelected_TextChanged_1(object sender, EventArgs e)
        {
            if (txtDateSelected.Text.Length > 4)
                btnAccept.Focus();
        }

        private void txtStatus_TextChanged_1(object sender, EventArgs e)
        {
            if (txtStatus.Text.Length > 1)
                btnAccept.Focus();
        }

        #endregion

        #region===== Disable Controls When chkSellConnectionsSameClass Checked ===== 

        /// <summary>
        /// Este es para mostrar los combos de acuerdo a la opcion del checkSell
        /// si esta checada se muestran los otros 2 combos y textbox y si no desaparecen
        /// y se limpian los combos y los textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSellConnectionSameClass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSellConnectionSameClass.Checked == false)
            {
                cmbBussinesClass2.Visible = true;
                cmbBussinesClass3.Visible = true;
                txtLine2.Visible = true;
                txtLine3.Visible = true;
            }
            else
            {
                cmbBussinesClass2.Visible = false;
                cmbBussinesClass3.Visible = false;
                txtLine2.Visible = false;
                txtLine3.Visible = false;
                cmbBussinesClass3.Text = string.Empty;
                cmbBussinesClass2.Text = string.Empty;
                txtLine2.Text = string.Empty;
                txtLine3.Text = string.Empty;
            }
        }

        #endregion

        #region ===== MethodsClass =====

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
        /// Si el user Control regresa con parametros entonces estos se mostraran
        /// en el orden en que se guardaron.
        /// </summary>
        private void ParametersReceived()
        {
            if (this.Parameters != null)
            {
                parametersreceived = new string[]{this.Parameters[0].ToString(), this.Parameters[1].ToString(),
               this.Parameters[2].ToString(), this.Parameters[3].ToString(), this.Parameters[4].ToString(),
               this.Parameters[5].ToString(), this.Parameters[6].ToString(), this.Parameters[7].ToString(),
               this.Parameters[8].ToString(), this.Parameters[9].ToString(), this.Parameters[10].ToString(),
               this.Parameters[11].ToString(), this.Parameters[12].ToString(), this.Parameters[13].ToString(),
               this.Parameters[14].ToString(), this.Parameters[15].ToString()};
            }
            txtSpaceReserve.Focus();
        }

        //Fill combobox ClassOfService with DB information
        /// <summary>
        /// Llena el combo con Clase de Servicio
        /// </summary>
        private void FillAirlineClass()
        {
            List<AirLinesClass> listAirLinesClass = AirLinesClassBL.GetCatAirLinesClass();
            bindingSource1.DataSource = listAirLinesClass;

            foreach (AirLinesClass airelineclassItem in listAirLinesClass)
            {
                ListItem litem = new ListItem();
                litem.Text = string.Format("{0}", airelineclassItem.CatAirLinClaID);
                litem.Value = airelineclassItem.CatAirLinClaID;
                cmbBussinesClass1.Items.Add(litem);
                cmbBussinesClass2.Items.Add(litem);
                cmbBussinesClass3.Items.Add(litem);
            }
        }

        /// <summary>
        /// Valida solo la Fecha que no sea menor ni y que contenga los caracteres correctos
        /// </summary>
        private bool IsValidateBusinessRulesOnlyDate
        {
            get
            {
                string date = string.Empty;

                if (statusDate == true)
                {
                    date = string.Format(Resources.Reservations.FECHA_SELEC_MENOR_ACTUAL, "\n");
                    MessageBox.Show(date, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    statusDate = false;
                    return false;
                }
                else if (!ValidateRegularExpression.ValidateDateFormat(txtDateSelected.Text))
                {
                    date = string.Format(Resources.Reservations.FORMAT_FECHA_DOS_NUM_TRES_ALFA, "\n");
                    MessageBox.Show(date, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                   return true;
                }
            }
        }

        /// <summary>
        /// Valido que los campos obligatorios no esten vacios 
        /// </summary>
        private bool IsValidateBusinessRulesNoDate
        {
            get
            {
                string zero = Resources.Constants.ZERO;

                if (string.IsNullOrEmpty(txtSpaceReserve.Text) &&
                string.IsNullOrEmpty(cmbBussinesClass1.Text) &&
                string.IsNullOrEmpty(txtLine1.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_ESPACIOS_RESERVAR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSpaceReserve.Focus();
                    return false;
                }
                else if ((!string.IsNullOrEmpty(txtSpaceReserve.Text)) &&
                    string.IsNullOrEmpty(cmbBussinesClass1.Text) &&
                    string.IsNullOrEmpty(txtLine1.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_CLASE_SERVICIO_REQUIERE_NÚMERO_LÍNEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbBussinesClass1.Focus();
                    return false;
                }
                else if ((!string.IsNullOrEmpty(txtSpaceReserve.Text)) &&
                        (cmbBussinesClass1.SelectedIndex > 1) &&
                        string.IsNullOrEmpty(txtLine1.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_NÚMERO_LÍNEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLine1.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtSpaceReserve.Text) &&
                        (cmbBussinesClass1.SelectedIndex > 1) &&
                        (!string.IsNullOrEmpty(txtLine1.Text)))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_ESPACIOS_RESERVAR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSpaceReserve.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtSpaceReserve.Text) &&
                   (string.IsNullOrEmpty(cmbBussinesClass1.Text)) &&
                   (!string.IsNullOrEmpty(txtLine1.Text)))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_ESPACIOS_RESERVAR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSpaceReserve.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtSpaceReserve.Text) &&
                   (cmbBussinesClass1.SelectedIndex > 1) &&
                   (string.IsNullOrEmpty(txtLine1.Text)))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_ESPACIOS_RESERVAR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSpaceReserve.Focus();
                    return false;
                }
                else if ((!string.IsNullOrEmpty(txtSpaceReserve.Text)) &&
                        string.IsNullOrEmpty(cmbBussinesClass1.Text) &&
                        (!string.IsNullOrEmpty(txtLine1.Text)))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_CLASE_SERVICIO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbBussinesClass1.Focus();
                    return false;
                }
                else if ((!string.IsNullOrEmpty(txtSpaceReserve.Text)) &&
                        (cmbBussinesClass1.SelectedIndex > 1) &&
                        (!string.IsNullOrEmpty(txtLine1.Text)) &&
                        (cmbBussinesClass2.SelectedIndex > 1) &&
                        string.IsNullOrEmpty(txtLine2.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_NÚMERO_LÍNEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLine2.Focus();
                    return false;
                }
                else if ((!string.IsNullOrEmpty(txtSpaceReserve.Text)) &&
                        (cmbBussinesClass1.SelectedIndex > 1) &&
                        (!string.IsNullOrEmpty(txtLine1.Text)) &&
                        (cmbBussinesClass2.SelectedIndex < 1) &&
                        (!string.IsNullOrEmpty(txtLine2.Text)))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_CLASE_SERVICIO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbBussinesClass2.Focus();
                    return false;
                }
                else if ((!string.IsNullOrEmpty(txtSpaceReserve.Text)) &&
                        (cmbBussinesClass3.SelectedIndex > 1) &&
                        string.IsNullOrEmpty(txtLine3.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_NÚMERO_LÍNEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLine3.Focus();
                    return false;
                }
                else if ((!string.IsNullOrEmpty(txtSpaceReserve.Text)) &&
                        (cmbBussinesClass3.SelectedIndex < 1) &&
                        (!string.IsNullOrEmpty(txtLine3.Text)))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_CLASE_SERVICIO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbBussinesClass3.Focus();
                    return false;
                }

                else if (chkSellConnectionSameClass.Checked == false &&
                   (cmbBussinesClass2.SelectedIndex < 1) &&
                   string.IsNullOrEmpty(txtLine2.Text) &&
                   (cmbBussinesClass3.SelectedIndex < 1) &&
                   string.IsNullOrEmpty(txtLine3.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_CLASE_SERVICIO_REQUIERE_NÚMERO_LÍNEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbBussinesClass2.Focus();
                    return false;
                }
                else if (txtSpaceReserve.Text.Equals(zero))
                {
                    MessageBox.Show(Resources.Reservations.CERO_NO_PERMITIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSpaceReserve.Focus();
                    return false;

                }
                else if (txtLine1.Text.Equals(zero))
                {
                    MessageBox.Show(Resources.Reservations.CERO_NO_PERMITIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLine1.Focus();
                    return false;
                }
                else if (txtLine2.Text.Equals(zero))
                {
                    MessageBox.Show(Resources.Reservations.CERO_NO_PERMITIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLine2.Focus();
                    return false;
                }
                else if (txtLine3.Text.Equals(zero))
                {
                    MessageBox.Show(Resources.Reservations.CERO_NO_PERMITIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLine3.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Envio el comando para la Fecha
        /// </summary>
        private void CommandsSendOnlyDate()
        {
            string send;
            send = 1 + txtDateSelected.Text;
            using (CommandsAPI objCommands = new CommandsAPI())
            {
               objCommands.SendReceive(send);
            }
        }

        /// <summary>
        /// Envio el comando de acuerdo a los campos ingresados
        /// </summary>
        private void CommandsSendNoDate()
        {
            string bussinesClass1=string.Empty;
            string bussinesClass2=string.Empty;
            string bussinesClass3=string.Empty;
            string send=string.Empty;

            if (!cmbBussinesClass1.SelectedIndex.Equals(0))
            {
                oneclass = (ListItem)cmbBussinesClass1.SelectedItem;
                bussinesClass1 = oneclass.Value;
            }
            
            if((!chkSellConnectionSameClass.Checked))
            {
                if (!cmbBussinesClass2.SelectedIndex.Equals(0) &&
                    !cmbBussinesClass2.SelectedIndex.Equals(-1))
                {
                    twoclass = (ListItem)cmbBussinesClass2.SelectedItem;
                    bussinesClass2 = twoclass.Value;
                }
                
                if (!cmbBussinesClass3.SelectedIndex.Equals(0)&&
                    !cmbBussinesClass3.SelectedIndex.Equals(-1))
                {
                    threeclass = (ListItem)cmbBussinesClass3.SelectedItem;
                    bussinesClass3 = threeclass.Value;
                }
            }
            
            if (!string.IsNullOrEmpty(txtSpaceReserve.Text))
                send = Resources.Constants.ZERO + txtSpaceReserve.Text;
            if (cmbBussinesClass1.SelectedIndex >= 1 &&
               !string.IsNullOrEmpty(txtLine1.Text))
                send = string.Concat(send, bussinesClass1, txtLine1.Text);
            if (cmbBussinesClass2.SelectedIndex >= 1 &&
               !string.IsNullOrEmpty(txtLine2.Text))
                send = string.Concat(send, bussinesClass2, txtLine2.Text);
            if (cmbBussinesClass3.SelectedIndex >= 1 &&
               !string.IsNullOrEmpty(txtLine3.Text))
                send = string.Concat(send, bussinesClass3, txtLine3.Text);
            if(!string.IsNullOrEmpty(txtStatus.Text))
                send=string.Concat(send, txtStatus.Text);

            if (chkSellConnectionSameClass.Checked)
                send = string.Concat(send, '*');
             using (CommandsAPI objCommand = new CommandsAPI())
             {
                 result = objCommand.SendReceive(send);
             }

           }

            #region ===== Commons =====

            /// <summary>
            /// Busca errores en la clase de ERR_SellAirSegment de acuerdo a las respuestas recibidas por el 
            /// Emulador de Sabre y de acuerdo a ellas se realizan ciertas acciones ya sea
            /// mandar un mensaje de error al usuario notificando del mismo o mandando a otro 
            /// User Control
            /// </summary>
            private void APIResponse()
            {
                if (!String.IsNullOrEmpty(result))
                {
                    ERR_SellAirSegment.err_SellAirSegment(result);
                    if ((!ERR_SellAirSegment.Status))
                        Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCAIR_RATE, parametersreceived);
                    else if (ERR_SellAirSegment.ShowUserControl)
                        Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCAVAILABILITY);
                    else
                        MessageBox.Show(ERR_SellAirSegment.CustomUserMsg, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
             }

            #endregion // End Commons

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://201.149.13.14:5498/BrandedFaresAM/BrandedFaresAM.html");
        }

        #endregion

        public static bool ReturnForMisc = false;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                ReturnForMisc = false;
                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCAVAILABILITY, parametersreceived);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void tblLayoutMain_Paint(object sender, PaintEventArgs e)
        {

        }

     }
}
