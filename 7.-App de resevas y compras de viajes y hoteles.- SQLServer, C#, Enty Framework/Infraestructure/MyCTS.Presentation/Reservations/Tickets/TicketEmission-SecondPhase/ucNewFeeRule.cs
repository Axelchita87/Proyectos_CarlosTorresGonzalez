using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using MyCTS.Forms.UI;
using MyCTS.Components.NullableHelper;
using MyCTS.Services;
using MyCTS.Services.Contracts;
using MyCTS.Services.ValidateDKsAndCreditCards;

namespace MyCTS.Presentation
{
    public partial class ucNewFeeRule : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Ingresa una nueva regla de cargo por servicio por corporativo
        /// Creación:    Marzo 2010 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Angel Trejo
        /// </summary>
        public ucNewFeeRule()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtAttribute1;
            this.LastControlFocus = btnAccept;
        }

        #region ====== Globals Variables ======

        private static List<GetInfoFeeRuleByAttribute1> listInfoFeeRule = null;
        private bool statusDate;

        private static int numberRule;
        public static int NumberRule
        {
            get { return numberRule; }
            set { numberRule = value; }
        }

        private static bool possition;
        public static bool Possition
        {
            get { return possition; }
            set { possition = value; }
        }

        private static bool montofijo;
        public static bool MontoFijo
        {
            get { return montofijo; }
            set { montofijo = value; }
        }

        private static string infoattribute1;
        public static string InfoAttribute1
        {
            get { return infoattribute1; }
            set { infoattribute1 = value; }
        }

        private static string attribute1;
        public static string Attribute1
        {
            get { return attribute1; }
            set { attribute1 = value; }
        }

        private static int newpriority;
        public static int NewPriority
        {
            get { return newpriority; }
            set { newpriority = value; }
        }

        private static bool loaduserwelcome;
        public static bool LoadUserWelcome
        {
            get { return loaduserwelcome; }
            set { loaduserwelcome = value; }
        }

        public static List<Critery> Criterios = null;
        public static List<MyCTS.Entities.GetOnlyAttribute1> listAttribute1 = null;

        #endregion //Globals Variables

        public class Critery
        {
            public string criterio;
            public int numberCritery;
        }

        /// <summary>
        /// Cargo los valores de las variables estaticas de este user control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucNewFeeRule_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            if (this.Parameters != null && this.Parameters[0] == "1")
                loaduserwelcome = true;
            else
                loaduserwelcome = false;
            if (Criterios != null && Criterios.Count > 0)
            {
                for (int i = 0; i < Criterios.Count; i++)
                    foreach (Control txt in this.Controls)
                        if (txt is SmartTextBox && txt.Name != "txtInfoRuleByAttribute1" && txt.TabIndex == Criterios[i].numberCritery)
                        {
                            txt.Text = Criterios[i].criterio;
                            break;
                        }
                ShowContols(true);
            }
            else
                ShowContols(false);
            if (possition == true)
            {
                foreach (Control txt in this.Controls)
                {
                    if (!(txt.TabIndex.Equals(0) || txt.TabIndex.Equals(1) || txt.Name == "btnCorp" || txt.Name == "txtInfoRuleByAttribute1"))
                        txt.Location = new Point(txt.Location.X, txt.Location.Y - 100);
                }
            }
            if (!string.IsNullOrEmpty(infoattribute1))
            {
                string[] aux = infoattribute1.Split(new char[] { '\n' });
                txtInfoRuleByAttribute1.Lines = aux;
            }
            else
                txtInfoRuleByAttribute1.Visible = false;
            if (montofijo)
                chKMontoFijo.Checked = true;
            else
                chKMontoFijo.Checked = false;
            txtAttribute1.Focus();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidBussinesRules)
            {
                InsertNewRule();
            }
        }

        /// <summary>
        /// Valiada que el corporativo sea valido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCorp_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtAttribute1.Text))
            {
                MessageBox.Show("DEBE INGRESAR EL CORPORATIVO AL QUE SE LE APLICARA LA REGLA DE CARGO POR SERVICIO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAttribute1.Focus();
            }
            else
            {
                //string[] locationDK = null;
                WsMyCTS wsServ = new WsMyCTS();
                MyCTS.Services.ValidateDKsAndCreditCards.GetOnlyAttribute1[] locationDK = null;
                try
                {
                    locationDK = wsServ.GetLocationByAttribute1(txtAttribute1.Text);
                }
                catch
                {
                    CommandsAPI2.send_MessageToEmulator("VALIDANDO CORPORATIVO, FAVOR DE ESPERAR........");
                    listAttribute1 = new List<MyCTS.Entities.GetOnlyAttribute1>();
                    listAttribute1 = GetOnlyAttribute1BL.GetAttribute1(txtAttribute1.Text);
                }
                if ((locationDK != null && locationDK.Length > 0) ||
                    (listAttribute1 != null && listAttribute1.Count > 0))
                {
                    if (listAttribute1 == null || listAttribute1.Count.Equals(0))
                    {
                        listAttribute1 = new List<MyCTS.Entities.GetOnlyAttribute1>();
                        for (int i = 0; i < locationDK.Length; i++)
                        {
                            MyCTS.Entities.GetOnlyAttribute1 objAttribute1 = new MyCTS.Entities.GetOnlyAttribute1();
                            objAttribute1.LocationDK = locationDK[i].LocationDK;
                            listAttribute1.Add(objAttribute1);
                        }
                    }
                    listInfoFeeRule = GetInfoFeeRuleByAttribute1BL.GetInfoFeeRule(txtAttribute1.Text, 0, Login.OrgId);
                    if (listInfoFeeRule.Count > 0)
                    {
                        //mostrar info de lo que contenga la lista
                        string info = string.Empty;
                        info = string.Concat("El corporativo ", txtAttribute1.Text, " cuenta con las siguientes reglas:");
                        for (int i = 0; i < listInfoFeeRule.Count; i++)
                        {
                            info = string.Concat(info, "\n");
                            info = string.Concat(info, "\n", "Regla: ", listInfoFeeRule[i].RuleNumber);
                            info = string.Concat(info, "\n", "Nombre: ", listInfoFeeRule[i].Description);
                            info = string.Concat(info, "\n", "Prioridad: ", listInfoFeeRule[i].Priority);
                            info = string.Concat(info, "\n", "% De Tarifa Base: ", listInfoFeeRule[i].DefaultFee);
                            info = string.Concat(info, "\n", "Cantidad Fija: ", listInfoFeeRule[i].DefaultMount.ToString("0.00"));
                            info = string.Concat(info, "\n", "Monto: ", (listInfoFeeRule[i].Mandatory) ? "No Negociable" : "Negociable");
                            info = string.Concat(info, "\n", "Status: ", (listInfoFeeRule[i].ActivationSatate == true) ? "Activa" : "Inactiva");
                            if (listInfoFeeRule[i].StartDate != Types.DateNullValue)
                                info = string.Concat(info, "\n", "Inicio de regla: ", Convert.ToString(listInfoFeeRule[i].StartDate).Substring(0, 10));
                            if (listInfoFeeRule[i].ExpirationDate != Types.DateNullValue)
                                info = string.Concat(info, "\n", "Fin de regla: ", Convert.ToString(listInfoFeeRule[i].ExpirationDate).Substring(0, 10));
                        }
                        infoattribute1 = info;
                        string[] infoList = info.Split(new char[] { '\n' });
                        if (possition == true)
                        {
                            foreach (Control txt in this.Controls)
                            {
                                if (!(txt.TabIndex.Equals(0) || txt.TabIndex.Equals(1) || txt.Name == "btnCorp" || txt.Name == "txtInfoRuleByAttribute1"))
                                    txt.Location = new Point(txt.Location.X, txt.Location.Y + 100);
                            }
                        }
                        possition = false;
                        txtInfoRuleByAttribute1.Lines = infoList;
                        ShowContols(true);
                        txtDescription.Focus();
                    }
                    else
                    {
                        if (possition == false)
                        {
                            foreach (Control txt in this.Controls)
                            {
                                if (!(txt.TabIndex.Equals(0) || txt.TabIndex.Equals(1) || txt.Name == "btnCorp" || txt.Name == "txtInfoRuleByAttribute1"))
                                    txt.Location = new Point(txt.Location.X, txt.Location.Y - 100);
                            }
                        }
                        possition = true;
                        ShowContols(true);
                        txtInfoRuleByAttribute1.Visible = false;
                        txtDescription.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("EL CORPORATIVO NO EXISTE EN INTEGRA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAttribute1.Focus();
                    ShowContols(false);
                }
            }
        }

        /// <summary>
        /// Limpia los valores de las variables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (Criterios != null)
                Criterios.Clear();
            if (listAttribute1 != null)
                listAttribute1.Clear();
            infoattribute1 = string.Empty;
            ShowContols(false);
            chKMontoFijo.Checked = false;
            txtAttribute1.Text = string.Empty;
            txtDefaultFee.Text = string.Empty;
            txtDefaultMount.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtExpirationDate.Text = string.Empty;
            txtExtendedDescription.Text = string.Empty;
            txtPriority.Text = string.Empty;
            txtStartDate.Text = string.Empty;
            if (ucDefinitionTargetElements.ListTargetsRules != null)
                ucDefinitionTargetElements.ListTargetsRules.Clear();
            txtAttribute1.Focus();
        }

        #region ====== Methods Class ======

        /// <summary>
        /// Valida las reglas de negocio aplicables a este user control
        /// </summary>
        private bool IsValidBussinesRules
        {
            get
            {
                bool isValid = false;
                if (string.IsNullOrEmpty(txtDescription.Text))
                {
                    MessageBox.Show("DEBE INGRESAR UNA DESCRIPCIÓN PARA LE REGLA DE CARGO POR SERVICIO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDescription.Focus();
                }
                else if (string.IsNullOrEmpty(txtPriority.Text))
                {
                    MessageBox.Show("DEBE INDICAR EL NIVEL DE PRIORIDAD DE LA REGLA DE CARGO POR SERVICIO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPriority.Focus();
                }
                else if (string.IsNullOrEmpty(txtDefaultFee.Text) && string.IsNullOrEmpty(txtDefaultMount.Text))
                {
                    MessageBox.Show("DEBE INDICAR PORCENTAJE DE LA TARIFA BASE O CANTIDAD\n" +
                                    "       FIJA PARA LE REGLA DE CARGO POR SERVICIO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDefaultFee.Focus();
                }
                else if (!string.IsNullOrEmpty(txtStartDate.Text) && !ValidateRegularExpression.ValidateBirthDateFormat(txtStartDate.Text))
                {
                    MessageBox.Show("EL FORMATO DE LA FECHA DE INICIO ES INCORRECTO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtStartDate.Focus();
                }
                else if (!string.IsNullOrEmpty(txtExpirationDate.Text) && !ValidateRegularExpression.ValidateBirthDateFormat(txtExpirationDate.Text))
                {
                    MessageBox.Show("EL FORMATO DE LA FECHA DE EXPIRACIÓN ES INCORRECTO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtExpirationDate.Focus();
                }
                else
                    isValid = true;
                return isValid;
            }
        }

        /// <summary>
        /// Valida si la prioridad que pide el usuario ya esta asignada para ese corporativo
        /// </summary>
        private bool ValidatePriority
        {
            get
            {
                if (listInfoFeeRule == null)
                    return true;
                else
                {
                    for (int i = 0; i < listInfoFeeRule.Count; i++)
                        if (listInfoFeeRule[i].Priority == Convert.ToInt32(txtPriority.Text))
                            return false;
                    return true;
                }
            }
        }

        /// <summary>
        /// Inserta la nueva regla de cargo por servicio
        /// </summary>
        private void InsertNewRule()
        {
            if (IsVaidateDates)
            {

                int priority = Convert.ToInt32(txtPriority.Text);
                decimal defaultFee = 0;
                decimal defaultMount = 0;
                if (!string.IsNullOrEmpty(txtDefaultFee.Text))
                    defaultFee = Convert.ToDecimal(txtDefaultFee.Text);
                if (!string.IsNullOrEmpty(txtDefaultMount.Text))
                    defaultMount = Convert.ToDecimal(txtDefaultMount.Text);
                if (!ValidatePriority)
                {
                    DialogResult yesNo = MessageBox.Show("EL NÚMERO DE PRIORIDAD YA EXISTE PARA EL CORPORATIVO " + txtAttribute1.Text +
                        "\n¿DESEA SUSTITUIR EL NIVEL DE PRIORIDAD PARA ESTA NUEVA REGLA?", Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (yesNo.Equals(DialogResult.Yes))
                    {
                        newpriority = Convert.ToInt32(txtPriority.Text);
                        attribute1 = txtAttribute1.Text;
                    }
                    else
                    {
                        newpriority = 0;
                        attribute1 = string.Empty;
                        txtPriority.Focus();
                        return;
                    }
                }
                Criterios = new List<Critery>();
                foreach (Control txt in this.Controls)
                {
                    if (txt is SmartTextBox && !string.IsNullOrEmpty(txt.Text))
                    {
                        Critery c = new Critery();
                        c.criterio = txt.Text;
                        c.numberCritery = txt.TabIndex;
                        Criterios.Add(c);
                    }
                }
                if (chKMontoFijo.Checked)
                    montofijo = true;
                else
                    montofijo = false;
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCDEFINITIONTARGETELEMENTS);
            }

        }

        /// <summary>
        /// Valida las fechas para que sean validas
        /// </summary>
        private bool IsVaidateDates
        {
            get
            {
                if (!string.IsNullOrEmpty(txtStartDate.Text))
                {
                    try
                    {
                        DateTime startDate = Convert.ToDateTime(txtStartDate.Text);
                    }
                    catch
                    {
                        MessageBox.Show("LA FECHA DE INICIO ES INVALIDA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtStartDate.Focus();
                        return false;
                    }
                }
                if (!string.IsNullOrEmpty(txtExpirationDate.Text))
                {
                    try
                    {
                        DateTime expirationDate = Convert.ToDateTime(txtExpirationDate.Text);
                    }
                    catch
                    {
                        MessageBox.Show("LA FECHA DE EXPIRACIÓN ES INVALIDA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtExpirationDate.Focus();
                        return false;
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// Oculta o muestra los controles
        /// </summary>
        /// <param name="status">Especifica el valor de la propiedad visible de cada control</param>
        private void ShowContols(bool status)
        {
            txtDefaultFee.Visible = status;
            txtDefaultMount.Visible = status;
            txtDescription.Visible = status;
            txtExpirationDate.Visible = status;
            txtExtendedDescription.Visible = status;
            txtPriority.Visible = status;
            txtStartDate.Visible = status;
            label1.Visible = status;
            label2.Visible = status;
            label5.Visible = status;
            lblDefaultFee.Visible = status;
            lblDefaultMount.Visible = status;
            lblDescription.Visible = status;
            lblExtendedDescription.Visible = status;
            lblPriority.Visible = status;
            lblStartDate.Visible = status;
            btnAccept.Visible = status;
            picCalendar.Visible = status;
            pictureBox1.Visible = status;
            btnCorp.Visible = !status;
            txtAttribute1.ReadOnly = status;
            btnClear.Visible = status;
            txtInfoRuleByAttribute1.Visible = status;
            txtInfoRuleByAttribute1.ReadOnly = status;
            chKMontoFijo.Visible = status;
        }

        #endregion //Methods Class

        #region ======Back to a Previous Usercontrol or Validate Enter KeyDown=====

        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData.Equals(Keys.Escape))
            {
                btnClear_Click(sender, e);
                if (this.Parameters != null && this.Parameters[0] == "1")
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                else
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCCALCULATESERVICECHARGE);
            }
            if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }

        }

        private void BackEnterUserControl_KeyDown2(object sender, KeyEventArgs e)
        {

            if (e.KeyData.Equals(Keys.Escape))
            {
                btnClear_Click(sender, e);
                if (this.Parameters != null && this.Parameters[0] == "1")
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                else
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCCALCULATESERVICECHARGE);
            }
            if (e.KeyData.Equals(Keys.Enter))
            {
                if (btnAccept.Visible)
                    btnAccept_Click(sender, e);
                else
                    btnCorp_Click(sender, e);
            }

        }

        #endregion

        #region=====Change focus When a Textbox is Full=====

        /// <summary>
        /// Cambia el foco del los SmartTextBox cuando llegan a
        /// su MaxLengt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtControls_TextChanged(object sender, EventArgs e)
        {
            if (sender is SmartTextBox)
                if (((SmartTextBox)sender).Text.Length > ((SmartTextBox)sender).MaxLength - 1)
                    foreach (Control txt in this.Controls)
                        if (txt.TabIndex.Equals(((SmartTextBox)(sender)).TabIndex + 1))
                        {
                            txt.Focus();
                            break;
                        }
        }

        #endregion //Change focus When a Textbox is Full

        #region =====CALENDAR=====

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            statusDate = false;
            DateTime dateSelected = monthCalendar1.SelectionStart;
            if (DateTime.Compare(dateSelected, DateTime.Today) > 0)
                statusDate = true;
            else
                statusDate = false;
            string date = dateSelected.ToString("ddMMMyy", new System.Globalization.CultureInfo("en-US")).ToUpper();
            txtStartDate.Text = date;
            if (this.Contains(monthCalendar1))
            {
                monthCalendar1.SendToBack();

            }
            monthCalendar1.Visible = false;

        }

        private void monthCalendar1_DateSelected2(object sender, DateRangeEventArgs e)
        {
            statusDate = false;
            DateTime dateSelected = monthCalendar2.SelectionStart;
            if (DateTime.Compare(dateSelected, DateTime.Today) > 0)
                statusDate = true;
            else
                statusDate = false;
            string date = dateSelected.ToString("ddMMMyy", new System.Globalization.CultureInfo("en-US")).ToUpper();
            txtExpirationDate.Text = date;
            if (this.Contains(monthCalendar2))
            {
                monthCalendar2.SendToBack();

            }
            monthCalendar2.Visible = false;

        }

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

        private void monthCalendar2_KeyDown(object sender, KeyEventArgs e)
        {
            if (monthCalendar2.Focus())
            {
                if (e.KeyData == Keys.Escape)
                {
                    if (this.Contains(monthCalendar2))
                    {
                        monthCalendar2.SendToBack();

                    }
                    monthCalendar2.Visible = false;

                }
            }
        }

        private void monthCalendar1_Leave(object sender, EventArgs e)
        {
            if (this.Contains(monthCalendar1))
            {
                monthCalendar1.SendToBack();

            }
            monthCalendar1.SendToBack();
        }

        private void monthCalendar2_Leave(object sender, EventArgs e)
        {
            if (this.Contains(monthCalendar2))
            {
                monthCalendar2.SendToBack();

            }
            monthCalendar2.SendToBack();
        }

        private void picCalendar_Click(object sender, EventArgs e)
        {
            calendarStateFront();
        }
        private void picCalendar_Click2(object sender, EventArgs e)
        {
            calendarStateFront2();
        }
        /// <summary>
        /// Llevar el calendario hacia el frente
        /// y que se muestre
        /// </summary>
        public void calendarStateFront()
        {

            monthCalendar1.Visible = true;
            if (this.Contains(monthCalendar1))
            {
                monthCalendar1.BringToFront();
            }
            monthCalendar1.Focus();

        }

        /// <summary>
        /// Llevar el calendario hacia el frente
        /// y que se muestre
        /// </summary>
        public void calendarStateFront2()
        {

            monthCalendar2.Visible = true;
            if (this.Contains(monthCalendar2))
            {
                monthCalendar2.BringToFront();
            }
            monthCalendar2.Focus();

        }

        #endregion //CALENDAR

    }
}
