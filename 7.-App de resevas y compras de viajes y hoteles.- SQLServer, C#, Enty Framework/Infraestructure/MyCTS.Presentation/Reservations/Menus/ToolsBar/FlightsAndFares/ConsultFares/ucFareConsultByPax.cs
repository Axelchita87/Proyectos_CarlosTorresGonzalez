using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using MyCTS.Forms.UI;

namespace MyCTS.Presentation
{
    public partial class ucFareConsultByPax : CustomUserControl
    {
        /// <summary>
        /// Descripción: User Control que permite consaultar tarifas por tipo de esta
        /// Creación:    29 enero 10, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        /// 

        private string picCalendarId = string.Empty;
        //private bool statusDate = false;
        private TextBox txtSender;
        private bool statusParamReceived = false;

        private static List<string> FareByPaxControlValues = new List<string>();

        public ucFareConsultByPax()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtDateSelected;
            this.LastControlFocus = btnAccept;
        }

        //Evento Load
        private void ucFareConsultByRate_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            CalendarStateBack();
            txtDateSelected.Focus();
            cmbPaxType.SelectedIndex = 0;
            SetPreviousControlValues();
        }


        //Evento btnAccept_Click
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!IsValidBusinessRules)
            {
                CommandsSend();
                GetPreviousControlValues();
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
        }

        #region===== MethodsClass =====

        /// <summary>
        /// Ingresa los valores de una consulta previamente realizada en el user control 
        /// </summary>
        private void SetPreviousControlValues()
        {
            if (!FareByPaxControlValues.Count.Equals(0))
            {
                statusParamReceived = true;
                for (int i = 0; i < 25; i++)
                {
                    foreach (Control ctrl in this.Controls)
                    {
                    
                        if (ctrl.TabIndex.Equals(i + 1))
                        {
                            if (ctrl is SmartTextBox)
                            {
                                //string name = ((SmartTextBox)(ctrl)).Name;//= FareByPaxControlValues[i];
                                ((SmartTextBox)(ctrl)).Text = FareByPaxControlValues[i];

                            }

                            else if (ctrl is ComboBox)
                            {
                                ((ComboBox)(ctrl)).SelectedIndex = Convert.ToInt32(FareByPaxControlValues[i]);
                            }

                            else if (ctrl is Panel)//no hay validacion para el panel
                            {
                            }

                            else if (ctrl is CheckBox)
                            {
                                if (FareByPaxControlValues[i].Equals(Resources.Constants.TRUE))
                                    ((CheckBox)(ctrl)).Checked = true;
                                else
                                    ((CheckBox)(ctrl)).Checked = false;

                            }
                        }
                    }

                    foreach (Control ctrl in pnlFareType.Controls)
                    {

                        if (ctrl.TabIndex.Equals(i + 1))
                        {
                            if (ctrl is CheckBox)
                            {
                                if (FareByPaxControlValues[i].Equals(Resources.Constants.TRUE))
                                    ((CheckBox)(ctrl)).Checked = true;
                                else
                                    ((CheckBox)(ctrl)).Checked = false;
                            }
                        }

                    }

                    foreach (Control ctrl in pnlOptions.Controls)
                    {

                        if (ctrl.TabIndex.Equals(i + 1))
                        {

                            if (ctrl is CheckBox)
                            {
                                if (FareByPaxControlValues[i].Equals(Resources.Constants.TRUE))
                                    ((CheckBox)(ctrl)).Checked = true;
                                else
                                    ((CheckBox)(ctrl)).Checked = false;
                            }
                        }

                    }
                }
            
                FareByPaxControlValues.Clear();
                statusParamReceived = false;
            }
        }

        /// <summary>
        /// Guarda los valores de la consulta realizada en el user control 
        /// </summary>
        private void GetPreviousControlValues()
        {

            for (int i = 0; i < 25; i++)
            {
                foreach (Control ctrl in this.Controls)
                {
                
                    if (ctrl.TabIndex.Equals(i + 1))
                    {
                        if (ctrl is SmartTextBox)
                        {
                            FareByPaxControlValues.Add(((SmartTextBox)(ctrl)).Text);
                        }

                        else if (ctrl is ComboBox)
                        {
                            FareByPaxControlValues.Add(((ComboBox)(ctrl)).SelectedIndex.ToString());
                        }

                        else if (ctrl is Panel)
                        {
                            FareByPaxControlValues.Add(string.Empty);
                        }

                        else if (ctrl is CheckBox)
                        {
                            FareByPaxControlValues.Add(((CheckBox)(ctrl)).Checked.ToString());
                        }
                    }

                }

                foreach (Control ctrl in pnlFareType.Controls)
                {

                    if (ctrl.TabIndex.Equals(i + 1))
                    {
                     
                        if (ctrl is CheckBox)
                        {
                            FareByPaxControlValues.Add(((CheckBox)(ctrl)).Checked.ToString());
                        }
                    }

                }

                foreach (Control ctrl in pnlOptions.Controls)
                {

                    if (ctrl.TabIndex.Equals(i + 1))
                    {

                        if (ctrl is CheckBox)
                        {
                            FareByPaxControlValues.Add(((CheckBox)(ctrl)).Checked.ToString());
                        }
                    }

                }
           
            }
        }

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
        /// Validaciones de Regla de Negocios de las opciones seleccionadas
        /// </summary>
        /// <returns></returns>
        private bool IsValidBusinessRules
        {
            get
            {
                bool isValid = true;
                if ((string.IsNullOrEmpty(txtDateSelected.Text)) ||
                    (string.IsNullOrEmpty(txtOrigin.Text)) ||
                    (string.IsNullOrEmpty(txtDestination.Text)))
                {
                    MessageBox.Show(Resources.Reservations.REQ_ORIGEN_FECHA_DEST, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrEmpty(txtDateSelected.Text))
                        txtDateSelected.Focus();
                    else if (string.IsNullOrEmpty(txtOrigin.Text))
                        txtOrigin.Focus();
                    else if (string.IsNullOrEmpty(txtDestination.Text))
                        txtDestination.Focus();
                }
                else if (!ValidateRegularExpression.ValidateDateFormat(txtDateSelected.Text))
                {
                    string messageToSend = string.Format(Resources.Reservations.FORMAT_FECHA_DOS_NUM_TRES_ALFA, "\n");
                    MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDateSelected.Focus();
                }
                //else if (statusDate)
                //{
                //    MessageBox.Show(Resources.Reservations.FECHA_SELECCIONADA_MAYOR_ACTUAL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    if (picCalendarId.Equals(picCalendar.Name))
                //        txtDateSelected.Focus();
                //    else if (picCalendarId.Equals(picCalendar2.Name))
                //        txtDateReturn.Focus();
                //    statusDate = false;
                //}
                else if ((!string.IsNullOrEmpty(txtOrigin.Text)) && (txtOrigin.Text.Length != 3))
                {
                    MessageBox.Show(Resources.Reservations.COD_CUIDAD_ORIGEN_TRES_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtOrigin.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtDestination.Text)) && (txtDestination.Text.Length != 3))
                {
                    MessageBox.Show(Resources.Reservations.COD_CUIDAD_DESTINO_TRES_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDestination.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtAirLine1.Text)) && (txtAirLine1.Text.Length != 2))
                {
                    MessageBox.Show(Resources.Reservations.COD_AEREOLINEA_DEBE_SER_DOS_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirLine1.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtAirLine2.Text)) && (txtAirLine2.Text.Length != 2))
                {
                    MessageBox.Show(Resources.Reservations.COD_AEREOLINEA_DEBE_SER_DOS_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirLine2.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtAirLine3.Text)) && (txtAirLine3.Text.Length != 2))
                {
                    MessageBox.Show(Resources.Reservations.COD_AEREOLINEA_DEBE_SER_DOS_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirLine3.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtAirLine4.Text)) && (txtAirLine4.Text.Length != 2))
                {
                    MessageBox.Show(Resources.Reservations.COD_AEREOLINEA_DEBE_SER_DOS_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirLine4.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtAirLine5.Text)) && (txtAirLine5.Text.Length != 2))
                {
                    MessageBox.Show(Resources.Reservations.COD_AEREOLINEA_DEBE_SER_DOS_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirLine5.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtAirLine6.Text)) && (txtAirLine6.Text.Length != 2))
                {
                    MessageBox.Show(Resources.Reservations.COD_AEREOLINEA_DEBE_SER_DOS_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirLine6.Focus();
                }
                else if (AirlinesNotEquals)
                {
                    MessageBox.Show(Resources.Reservations.NO_PER_COD_AEREOLINEA_REPETIDOS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!string.IsNullOrEmpty(txtDateReturn.Text) && !ValidateRegularExpression.ValidateDateFormat(txtDateReturn.Text))
                {
                    string messageToSend = string.Format(Resources.Reservations.FORMAT_FECHA_DOS_NUM_TRES_ALFA, "\n");
                    MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDateReturn.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtMoneyCode.Text)) && (txtMoneyCode.Text.Length != 3))
                {
                    MessageBox.Show(Resources.Reservations.COD_MONEDA_DEBE_SER_TRES_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMoneyCode.Focus();
                }
                else
                {
                    isValid = false;
                }

                return isValid;
            }
        }


        /// <summary>
        /// Valida que los codigos de Aereolínea no sean repetidos
        /// </summary>
        private bool AirlinesNotEquals
        {
            get
            {
                bool statusSameAirline = false;
                if (!string.IsNullOrEmpty(txtAirLine1.Text))
                {
                    if ((txtAirLine1.Text.Equals(txtAirLine2.Text)) ||
                    (txtAirLine1.Text.Equals(txtAirLine3.Text)) ||
                    (txtAirLine1.Text.Equals(txtAirLine4.Text)) ||
                    (txtAirLine1.Text.Equals(txtAirLine5.Text)) ||
                    (txtAirLine1.Text.Equals(txtAirLine6.Text)))
                    {
                        statusSameAirline = true;
                        txtAirLine1.Focus();
                    }
                }
                if (!string.IsNullOrEmpty(txtAirLine2.Text))
                {
                    if ((txtAirLine2.Text.Equals(txtAirLine1.Text)) ||
                    (txtAirLine2.Text.Equals(txtAirLine3.Text)) ||
                    (txtAirLine2.Text.Equals(txtAirLine4.Text)) ||
                    (txtAirLine2.Text.Equals(txtAirLine5.Text)) ||
                    (txtAirLine2.Text.Equals(txtAirLine6.Text)))
                    {
                        statusSameAirline = true;
                        txtAirLine2.Focus();
                    }
                }
                if (!string.IsNullOrEmpty(txtAirLine3.Text))
                {
                    if ((txtAirLine3.Text.Equals(txtAirLine1.Text)) ||
                    (txtAirLine3.Text.Equals(txtAirLine2.Text)) ||
                    (txtAirLine3.Text.Equals(txtAirLine4.Text)) ||
                    (txtAirLine3.Text.Equals(txtAirLine5.Text)) ||
                    (txtAirLine3.Text.Equals(txtAirLine6.Text)))
                    {
                        statusSameAirline = true;
                        txtAirLine3.Focus();
                    }
                }
                if (!string.IsNullOrEmpty(txtAirLine4.Text))
                {
                    if ((txtAirLine4.Text.Equals(txtAirLine1.Text)) ||
                    (txtAirLine4.Text.Equals(txtAirLine2.Text)) ||
                    (txtAirLine4.Text.Equals(txtAirLine3.Text)) ||
                    (txtAirLine4.Text.Equals(txtAirLine5.Text)) ||
                    (txtAirLine4.Text.Equals(txtAirLine6.Text)))
                    {
                        statusSameAirline = true;
                        txtAirLine4.Focus();
                    }
                }
                if (!string.IsNullOrEmpty(txtAirLine5.Text))
                {
                    if ((txtAirLine5.Text.Equals(txtAirLine1.Text)) ||
                    (txtAirLine5.Text.Equals(txtAirLine2.Text)) ||
                    (txtAirLine5.Text.Equals(txtAirLine3.Text)) ||
                    (txtAirLine5.Text.Equals(txtAirLine4.Text)) ||
                    (txtAirLine5.Text.Equals(txtAirLine6.Text)))
                    {
                        statusSameAirline = true;
                        txtAirLine5.Focus();
                    }
                }
                if (!string.IsNullOrEmpty(txtAirLine6.Text))
                {
                    if ((txtAirLine6.Text.Equals(txtAirLine1.Text)) ||
                    (txtAirLine6.Text.Equals(txtAirLine2.Text)) ||
                    (txtAirLine6.Text.Equals(txtAirLine3.Text)) ||
                    (txtAirLine6.Text.Equals(txtAirLine4.Text)) ||
                    (txtAirLine6.Text.Equals(txtAirLine5.Text)))
                    {
                        statusSameAirline = true;
                        txtAirLine1.Focus();
                    }
                }
                return statusSameAirline;
            }
        }      


        /// <summary>
        /// Envia comando a MySabre para consultar tarifa por tipo de esta
        /// </summary>
        private void CommandsSend()
        {
            string send = string.Empty;
            send = string.Concat("FQ",
                txtOrigin.Text,
                txtDestination.Text,
                txtDateSelected.Text);

            if (!string.IsNullOrEmpty(txtDateReturn.Text))
                send = string.Concat(send,
                    "‡R",
                    txtDateReturn.Text);

            if (!string.IsNullOrEmpty(txtAirLine1.Text))
                send = string.Concat(send,
                    Resources.Constants.INDENT,
                    txtAirLine1.Text);

            if (!string.IsNullOrEmpty(txtAirLine2.Text))
                send = string.Concat(send,
                    Resources.Constants.INDENT,
                    txtAirLine2.Text);

            if (!string.IsNullOrEmpty(txtAirLine3.Text))
                send = string.Concat(send,
                    Resources.Constants.INDENT,
                    txtAirLine3.Text);

            if (!string.IsNullOrEmpty(txtAirLine4.Text))
                send = string.Concat(send,
                    Resources.Constants.INDENT,
                    txtAirLine4.Text);

            if (!string.IsNullOrEmpty(txtAirLine5.Text))
                send = string.Concat(send,
                    Resources.Constants.INDENT,
                    txtAirLine5.Text);

            if (!string.IsNullOrEmpty(txtAirLine6.Text))
                send = string.Concat(send,
                    Resources.Constants.INDENT,
                    txtAirLine6.Text);

            if (!string.IsNullOrEmpty(txtMoneyCode.Text))
                send = string.Concat(send,
                    Resources.Constants.SLASH,
                    txtMoneyCode.Text);

            if (chkNoAdvPurchase.Checked.Equals(true))
                send = string.Concat(send,
                    "ΣXA");
            else if (chkNoPenalties.Checked.Equals(true))
                send = string.Concat(send,
                    "ΣXP");
            else if (chkNoMinMaxStay.Checked.Equals(true))
                send = string.Concat(send,
                    "ΣXS");
            else if (chkNoRestrictions.Checked.Equals(true))
                send = string.Concat(send,
                    "ΣXR");
            else if (chkClassifiedFare.Checked.Equals(true))
                send = string.Concat(send,
                    "*PVT");
            else if (chkNUC.Checked.Equals(true))
                send = string.Concat(send,
                    "‡HR");
            else if (chkOneWay.Checked.Equals(true))
                send = string.Concat(send,
                    "‡OW");
            else if (chkRoundTrip.Checked.Equals(true))
                send = string.Concat(send,
                    "‡RT");

            if (!cmbPaxType.SelectedIndex.Equals(0) &&
                !string.IsNullOrEmpty(cmbPaxType.Text) &&
                !cmbPaxType.Text.Contains("----"))
            {
                string[] PaxTypeCode = cmbPaxType.Text.Split(new char[]{' '});
                send = string.Concat(send,
                    Resources.Constants.COMMANDS_CROSSLORAINE_P,
                    PaxTypeCode[0]);
            }


            if (chkPublic.Checked.Equals(true))
                send = string.Concat(send,
                    Resources.Constants.COMMANDS_CROSSLORAINE_PL);
            else if (chkPrivate.Checked.Equals(true))
                send = string.Concat(send,
                    Resources.Constants.COMMANDS_CROSSLORAINE_PL);

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }




           
        }

        #endregion//End MethodsClass


        #region=====Change focus When a Textbox is Full=====

        //Evento deleteTxtControls_TextChanged
        private void txtControls_TextChanged(object sender, EventArgs e)
        {
           // statusDate = false;
            if (sender is SmartTextBox)
            {
                if (((SmartTextBox)sender).Text.Length > ((SmartTextBox)sender).MaxLength - 1)
                {
                    foreach (Control txt in this.Controls)
                    {
                        if (txt.TabIndex.Equals(((SmartTextBox)(sender)).TabIndex + 1))
                        {
                            txt.Focus();
                        }

                    }
                }
            }

        }

        #endregion//End Change focus When a Textbox is Full


        #region=====Predictives=====

        private void txtCities_TextChanged(object sender, EventArgs e)
        {
            if (!statusParamReceived)
            {
                lbPredictives.Items.Clear();
                txtSender = (TextBox)sender;
                Common.SetListBoxAirports((TextBox)sender, lbPredictives);
            }
        }

        private void txtAirLine_TextChanged(object sender, EventArgs e)
        {
            if (!statusParamReceived)
            {
                lbPredictives.Items.Clear();
                txtSender = (TextBox)sender;
                Common.SetListBoxAirlines((TextBox)sender, lbPredictives);
            }
        }


        private void txtMoney_TextChanged(object sender, EventArgs e)
        {
            if (!statusParamReceived)
            {
                lbPredictives.Items.Clear();
                txtSender = (TextBox)sender;
                Common.SetListBoxCurrenciesCountries((TextBox)sender, lbPredictives);
            }
        }

        #endregion//End Predictives


        #region =====Back to a Previous Usercontrol or Validate Enter KeyDown=====

        /// <summary>
        /// Aborta el proceso al presionar la tecla ESC o ejecuta las 
        /// instrucciones al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData.Equals(Keys.Escape))
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);



            if (e.KeyData.Equals(Keys.Enter))
            {
                
                btnAccept_Click(sender, e);
            }


        }


        /// <summary>
        /// Aborta el proceso al presionar la tecla ESC o ejecuta las 
        /// instrucciones al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControlPredictives_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData.Equals(Keys.Escape))
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);



            if (e.KeyData.Equals(Keys.Enter))
            {

                btnAccept_Click(sender, e);
            }

            if (e.KeyCode == Keys.Down)
            {

                if (lbPredictives.Items.Count > 0)
                {

                    lbPredictives.SelectedIndex = 0;
                    lbPredictives.Focus();
                    lbPredictives.Visible = true;
                    lbPredictives.Focus();
                }
            }


        }



        #endregion//End Back to a Previous Usercontrol or Validate Enter KeyDown


        #region=====Show MonthCalendar picCalendar Click=====


        private void picCalendar_Click(object sender, EventArgs e)
        {
            picCalendarId = ((PictureBox)(sender)).Name;
            monthCalendar1.Location = new Point(((PictureBox)(sender)).Location.X, ((PictureBox)(sender)).Location.Y + 19);
            CalendarStateFront();
        }

        #endregion//End Show MonthCalendar picCalendar Click


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
                    if (this.Contains(monthCalendar1))
                    {
                        monthCalendar1.SendToBack();

                    }
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
           // statusDate = false;
            DateTime dateSelected = monthCalendar1.SelectionStart;
            //if (DateTime.Compare(dateSelected, DateTime.Today) > 0)
            //    statusDate = true;
            //else
            //    statusDate = false;
            string date = dateSelected.ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
            if (picCalendarId.Equals(picCalendar.Name))
            {
                txtDateSelected.Text = date;
                txtDateSelected.Focus();
            }
            else if (picCalendarId.Equals(picCalendar2.Name))
            {
                txtDateReturn.Text = date;
                txtDateReturn.Focus();
            }
            if (this.Contains(monthCalendar1))
            {
                monthCalendar1.SendToBack();

            }
            monthCalendar1.Visible = false;

        }
        #endregion//End Select Date from MonthCalendar


        #region===== Listbox Events =====

        //Evento lbPredictives_MouseClick
        private void lbPredictives_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox txt = txtSender;
            ListBox listBox = (ListBox)sender;
            ListItem li = (ListItem)listBox.SelectedItem;
            txt.Text = li.Value;
            lbPredictives.Visible = false;
            lbPredictives.Items.Clear();
            txt.Focus();
        }

        //Evento lbPredictives_KeyDown
        private void lbPredictives_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = txtSender;
            ListBox listBox = (ListBox)sender;

            if (e.KeyCode == Keys.Enter)
            {
                ListItem li = (ListItem)listBox.SelectedItem;
                txt.Text = li.Value;
                lbPredictives.Visible = false;
                txt.Focus();
                lbPredictives.Items.Clear();

            }

            if (e.KeyCode == Keys.Escape)
            {
                lbPredictives.Hide();
                lbPredictives.Items.Clear();
            }

        }



        private void hidePredictive(object sender, EventArgs e)
        {
            lbPredictives.Hide();
        }


        #endregion//End Listbox Events


        #region=====CheckBox Checked Changed=====

        private void optionsToSelect_CheckedChanged(object sender, EventArgs e)
        {
            foreach(Control chk in pnlOptions.Controls)
            {
                if (chk is CheckBox)
                {
                    if (((CheckBox)(sender)).Checked.Equals(true))
                    {
                        if (!chk.Name.Equals(((CheckBox)(sender)).Name))
                            ((CheckBox)(chk)).Checked = false;
                    }
                }
            }
        }


        private void FareType_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CheckBox chk in pnlFareType.Controls)
            {
                    if (((CheckBox)(sender)).Checked.Equals(true))
                    {
                        if (!chk.Name.Equals(((CheckBox)(sender)).Name))
                            ((CheckBox)(chk)).Checked = false;
                    }
            }
        }

        #endregion//End CheckBox Checked Changed

    }
}
