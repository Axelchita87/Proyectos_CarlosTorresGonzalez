using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Services.Contracts;
using MyCTS.Services.ValidateDKsAndCreditCards;

namespace MyCTS.Presentation
{
    public partial class ucDefineGroup : CustomUserControl
    {
        /// <summary>
        /// Descripcion:Permite definir un grupo
        /// al flujo de Reservaciones
        /// Creación: Septiembre 18 - 2009 , Modificación:*
        /// Cambio: *    , Solicito *
        /// Autor: Jessica Gutierrez 
        /// </summary>

        #region ====== Declaration of variable =====

        private string dateCalendar;
        private string day;
        private string month;
        private string year;
        private bool statusValidateAir;
        private bool statusValidateAirPort;
        private bool statusNoExistDK;
        private bool statusInactive;
        private TextBox txt;
        private string date;
        private string Attribute1;
        WsMyCTS wsServ = new WsMyCTS();

        #endregion

        public ucDefineGroup()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtPlaceReservation;
            this.LastControlFocus = btnAccept;
        }

        //User Control DefineGroup
        private void ucDefineGroup_Load(object sender, EventArgs e)
        {
            CalendarStateBack();
            txtPlaceReservation.Focus();
        }

        /// <summary>
        /// Validaciones y envio de comandos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            #region ====== Validation of predictive ====

            CommandsAPI2.send_MessageToEmulator(string.Concat(Resources.Reservations.ESPERE_FAVOR_VALIDANDO_DK_INTEGRA));
            statusNoExistDK = false;
            statusInactive = false;
            WsMyCTS wsServ = new WsMyCTS();
            MyCTS.Services.ValidateDKsAndCreditCards.GetAttribute1 integraAttribute = null;
            MyCTS.Services.ValidateDKsAndCreditCards.GetAttribute1 integraAttribute1 = null;

            //OracleConnection OracleConnection = new OracleConnection();
            //MyCTS.Services.MyCTSOracleConnection.GetAttribute1 integraAttribute = null;
            //MyCTS.Services.MyCTSOracleConnectionDev.GetAttribute1 integraAttribute1 = null;

            try
            {
                try
                {
                    integraAttribute = wsServ.GetAttribute(txtDK.Text, Login.OrgId);   
                    //integraAttribute = OracleConnection.GetAttribute1(txtDK.Text, Login.OrgId);
                }
                catch
                {
                    integraAttribute = wsServ.GetAttribute(txtDK.Text, Login.OrgId);   
                    //integraAttribute1 = OracleConnection.GetAttribute1Dev(txtDK.Text, Login.OrgId);
                }
            }
            catch
            {
                MyCTS.Services.ValidateDKsAndCreditCards.GetAttribute1 AttributeBackup = wsServ.GetAttribute(txtDK.Text, Login.OrgId);
                //GetAndSetAttributeBackup AttributeBackup = GetAndSetAttributeBackupBL.GetAttribute(txtDK.Text, Login.OrgId);
                if (AttributeBackup != null)
                {
                    if (!string.IsNullOrEmpty(AttributeBackup.Attribute1.ToString()) &&
                                        (AttributeBackup.Attribute1.Contains(Resources.Reservations.MESSAGE_NO)))
                        statusNoExistDK = true;
                    else if (!string.IsNullOrEmpty(AttributeBackup.Attribute1.ToString()) &&
                                        AttributeBackup.Attribute1.Contains(Resources.Reservations.MESSAGE_INACTIVO))
                        statusInactive = true;
                }
            }
            if (integraAttribute != null)
            {
                if (!string.IsNullOrEmpty(integraAttribute.Attribute1) &&
                    (integraAttribute.Attribute1.Contains(Resources.Reservations.MESSAGE_NO)))
                    statusNoExistDK = true;
                else if (!string.IsNullOrEmpty(integraAttribute.Attribute1) &&
                    integraAttribute.Attribute1.Contains(Resources.Reservations.MESSAGE_INACTIVO))
                    statusInactive = true;
                else
                {
                    MyCTS.Services.ValidateDKsAndCreditCards.SetQCByAttribute1 tempAttribute = new MyCTS.Services.ValidateDKsAndCreditCards.SetQCByAttribute1();
                    tempAttribute = wsServ.SetQCGetAttribute(integraAttribute.Attribute1, integraAttribute.Status, integraAttribute.Status_Site);
                    Attribute1 = tempAttribute.Attribute1;

                    //SetQCByAttribute1 tempAttribute = new SetQCByAttribute1();
                    //tempAttribute = SetQCByAttribute1BL.GetAttribute(integraAttribute.Attribute1, integraAttribute.Status, integraAttribute.Status_Site);
                    //Attribute1 = tempAttribute.Attribute1; 
                }
            }
            else if (integraAttribute1 != null)
            {
                if (!string.IsNullOrEmpty(integraAttribute1.Attribute1) &&
                    (integraAttribute1.Attribute1.Contains(Resources.Reservations.MESSAGE_NO)))
                    statusNoExistDK = true;
                else if (!string.IsNullOrEmpty(integraAttribute1.Attribute1) &&
                    integraAttribute1.Attribute1.Contains(Resources.Reservations.MESSAGE_INACTIVO))
                    statusInactive = true;
                else
                {

                    MyCTS.Services.ValidateDKsAndCreditCards.SetQCByAttribute1 tempAttribute = new MyCTS.Services.ValidateDKsAndCreditCards.SetQCByAttribute1();
                    tempAttribute = wsServ.SetQCGetAttribute(integraAttribute.Attribute1, integraAttribute.Status, integraAttribute.Status_Site);
                    Attribute1 = tempAttribute.Attribute1;

                    //SetQCByAttribute1 tempAttribute = new SetQCByAttribute1();
                    //tempAttribute = SetQCByAttribute1BL.GetAttribute(integraAttribute1.Attribute1, integraAttribute1.Status, integraAttribute1.Status_Site);
                    //Attribute1 = tempAttribute.Attribute1;
                }
            }
            else
            {
                MyCTS.Services.ValidateDKsAndCreditCards.GetAttribute1 AttributeBackup = wsServ.GetAttribute(txtDK.Text, Login.OrgId);

                //GetAndSetAttributeBackup AttributeBackup = GetAndSetAttributeBackupBL.GetAttribute(txtDK.Text, Login.OrgId);
                if (AttributeBackup != null)
                {
                    if (!string.IsNullOrEmpty(AttributeBackup.Attribute1.ToString()) &&
                                        (AttributeBackup.Attribute1.Contains(Resources.Reservations.MESSAGE_NO)))
                        statusNoExistDK = true;
                    else if (!string.IsNullOrEmpty(AttributeBackup.Attribute1.ToString()) &&
                                        AttributeBackup.Attribute1.Contains(Resources.Reservations.MESSAGE_INACTIVO))
                        statusInactive = true;
                }
            }

            List<CatAirlines> airList = CatAirlinesBL.GetAirlines(txtAirline.Text);
            if (airList.Count.Equals(0))
                statusValidateAir = true;
            else
                statusValidateAir = false;
            List<AirPortCityCountry> airPortList = AirPortCityCountryBL.GetAirPortCityCountry(txtOriginCity.Text);
            if (airPortList.Count.Equals(0))
                statusValidateAirPort = true;
            else
                statusValidateAirPort = false;

            #endregion

            if (IsValidateBusinessRules)
            {
                CommandsSend();
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
        }

        //Evento clic de Calendar
        private void Calendar_Click(object sender, EventArgs e)
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
            txtDate.Text = date;
            monthCalendar1.Visible = false;
            txtDate.Focus();
        
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
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            else if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
            else if (e.KeyCode == Keys.Down)
            {
                if (lbGeneric.Items.Count > 0)
                {
                    lbGeneric.SelectedIndex = 0;
                    lbGeneric.Focus();
                }
            }
        }

        #endregion

        //KeyDown LbGeneric
        /// <summary>
        /// Esta función permite selccionar un elemento del listbox y 
        /// oculta el ListBox al momento de seleccionarlo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbGeneric_KeyDown(object sender, KeyEventArgs e)
        {
            ListBox ListBox = (ListBox)sender;
            //if (!string.IsNullOrEmpty(txtDK.Text))
            //{
            //    TextBox txt = (TextBox)txtDK;
            //}
            if (!string.IsNullOrEmpty(txtOriginCity.Text))
            {
                TextBox txt = (TextBox)txtOriginCity;
            }
            else if (!string.IsNullOrEmpty(txtAirline.Text))
            {
                TextBox txt = (TextBox)txtAirline;
            }
            if (e.KeyCode == Keys.Enter)
            {
                ListItem li = (ListItem)ListBox.SelectedItem;
                txt.Text = li.Value;
                lbGeneric.Visible = false;
                txt.Focus();
            }
        }

        //Mouse Click
        /// <summary>
        /// Esta función es para permitir el Clic sobre un elemento del ListBox
        /// para seleccional el item y oculata el listBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_MouseClick(object sender, MouseEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            //if (!string.IsNullOrEmpty(txtDK.Text))
            //{
            //    TextBox txt = (TextBox)txtDK;
                
            //}
            if (!string.IsNullOrEmpty(txtOriginCity.Text))
            {
                TextBox txt = (TextBox)txtOriginCity;
            }
            else if (!string.IsNullOrEmpty(txtAirline.Text))
            {
                TextBox txt = (TextBox)txtAirline;
            }
            if (!string.IsNullOrEmpty(txtAirline.Text) ||
                !string.IsNullOrEmpty(txtDK.Text) ||
                !string.IsNullOrEmpty(txtOriginCity.Text))
            {
                ListItem li = (ListItem)listBox.SelectedItem;
                txt.Text = li.Value;
                lbGeneric.Visible = false;
                txt.Focus();
            }
        }

        #region ========= Change Focus ===========
       
        private void txtDK_TextChanged(object sender, EventArgs e)
        {
            if (txtDK.Text.Length > 6)
                txtOriginCity.Focus();
            //txt = (TextBox)sender;
            //Common.SetListBoxConfirmDK(txt, lbGeneric);
            //lbGeneric.BringToFront();
        }

        private void txtAirline_TextChanged(object sender, EventArgs e)
        {
            txt = (TextBox)sender;
            Common.SetListBoxAirlines(txt, lbGeneric);
            lbGeneric.BringToFront();
        }

        private void txtOriginCity_TextChanged(object sender, EventArgs e)
        {
            txt = (TextBox)sender;
            Common.SetListBoxAirports(txt, lbGeneric);
            lbGeneric.BringToFront();
        }

        private void txtPlaceReservation_TextChanged(object sender, EventArgs e)
        {
            if (txtPlaceReservation.Text.Length > 2)
                txtGroupName.Focus();
        }

        private void txtGroupName_TextChanged(object sender, EventArgs e)
        {
            if (txtGroupName.Text.Length > 49)
                txtCodeGroup.Focus();
        }

        private void txtCodeGroup_TextChanged(object sender, EventArgs e)
        {
            if (txtCodeGroup.Text.Length > 9)
                txtDK.Focus();
        }

        private void txtTimeDeparture_TextChanged(object sender, EventArgs e)
        {
            if (txtTimeDeparture.Text.Length > 2)
                txtDate.Focus();
        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {
            if (txtDate.Text.Length > 4)
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
        /// Valida que existan todos los datos
        /// </summary>
        private bool IsValidateBusinessRules
        {
            get
            {
                if (string.IsNullOrEmpty(txtPlaceReservation.Text))
                {
                    MessageBox.Show(Resources.Group.Group.REQUIERE_INGRESE_LUGAR_RESERVACION, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPlaceReservation.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtGroupName.Text))
                {
                    MessageBox.Show(Resources.Group.Group.REQUIERE_INGRESE_NOMBRE_GRUPO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtGroupName.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtCodeGroup.Text))
                {
                    MessageBox.Show(Resources.Group.Group.REQUIERES_INGRESE_CODIGO_GRUPO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCodeGroup.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtDK.Text))
                {
                    MessageBox.Show(Resources.Group.Group.REQUIERE_INGRESE_DK, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDK.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtOriginCity.Text))
                {
                    MessageBox.Show(Resources.Group.Group.REQUIERE_INGRESE_ORIGEN_CIUDAD, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtOriginCity.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtAirline.Text))
                {
                    MessageBox.Show(Resources.Group.Group.REQUIERE_INGRESE_AEROLINEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirline.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtTimeDeparture.Text))
                {
                    MessageBox.Show(Resources.Group.Group.REQUIERE_INGRESE_HORA_SALIDA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTimeDeparture.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtDate.Text))
                {
                    MessageBox.Show(Resources.Group.Group.REQUIERE_INGRESE_FECHA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDate.Focus();
                    return false;
                }
                if (statusNoExistDK)
                {
                    MessageBox.Show(Resources.Reservations.NO_EXISTE_LOCATIONDK_INTEGRA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDK.Focus();
                    return false;
                }
                else if (statusInactive)
                {
                    MessageBox.Show(Resources.Reservations.NUMERO_CLIENTE_LOCATIONDKINACTIVO_VERIFICAR_INTEGRA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDK.Focus();
                    return false;
                }
                else if (statusValidateAir)
                {
                    MessageBox.Show(Resources.Group.Group.REQUIERE_INGRESE_AEROLINEA_VALIDA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirline.Focus();
                    return false;
                }
                else if (statusValidateAirPort)
                {
                    MessageBox.Show(Resources.Group.Group.REQUIERE_INGRESE_CIUDAD_VALIDA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtOriginCity.Focus();
                    return false;
                }
                else if (!ValidateRegularExpression.ValidateDateFormat(txtDate.Text))
                {
                    date = string.Format(Resources.Reservations.FORMAT_FECHA_DOS_NUM_TRES_ALFA, "\n");
                    MessageBox.Show(date, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDate.Focus();
                    return false;
                }
                else
                    return true;
            }
        }

        /// <summary>
        /// Envio de comandos
        /// </summary>
        private void CommandsSend()
        {
            string send = string.Empty;
            string timelimit = string.Empty;
            string codeGroup = string.Empty;
            string commandA = string.Empty;
            string commnadDK;
            send = Resources.Group.Constants.COMMANDS_INDENT_B_SLASH;
            send = string.Concat(send, txtPlaceReservation.Text, txtGroupName.Text);
            List<LabelXMLRemarks> listXMLRemarks =
                   LabelXMLRemarksBL.GetLabelXMLRemarks(Attribute1, "GroupCode", txtCodeGroup.Text);
             if (listXMLRemarks.Count > 0)
             {
                 codeGroup = listXMLRemarks[0].XMLFutureLabel;
             }
             commnadDK = Resources.Group.Constants.COMMANDS_DK + txtDK.Text;
            timelimit = Resources.Group.Constants.COMMANDS_EIGHT;
            timelimit = string.Concat(timelimit, txtOriginCity.Text, Resources.Group.Constants.INDENT,
                txtAirline.Text, txtTimeDeparture.Text, Resources.Group.Constants.SLASH, txtDate.Text);
            commandA = Resources.Group.Constants.COMMANDS_AST_A;
            using (CommandsAPI objCommands = new CommandsAPI())
            {
                objCommands.SendReceive(send);
                objCommands.SendReceive(codeGroup);
                objCommands.SendReceive(commnadDK);
                objCommands.SendReceive(timelimit);
                objCommands.SendReceive(commandA);
            }
        }

        #endregion
    }

}

