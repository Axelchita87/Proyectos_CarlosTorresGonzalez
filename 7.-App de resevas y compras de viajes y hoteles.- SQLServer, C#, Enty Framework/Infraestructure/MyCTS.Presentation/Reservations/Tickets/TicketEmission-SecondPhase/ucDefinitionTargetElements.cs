using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Forms.UI;
using MyCTS.Entities;
using MyCTS.Business;

namespace MyCTS.Presentation
{
    public partial class ucDefinitionTargetElements : CustomUserControl
    {

        /// <summary>
        /// Descripcion: Ingresa de los targets para la nueva 
        /// regla de cargo por servicio por corporativo
        /// Creación:    Marzo 2010 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Angel Trejo
        /// </summary>

        #region ===== Global Variables =====

        private TextBox txt;
        private bool statusParamReceived;
        public static List<Targets> ListTargetsRules = null;

        public class Targets
        {
            public int IDTE;
            public string Value2;
        }
        private bool statusDate;
        private static int paxnum;
        public static int PaxNum
        {
            get { return paxnum; }
            set { paxnum = value; }
        }

        private static string locationdknotaccepted;
        public static string LocationDKNotAccepted
        {
            get { return locationdknotaccepted; }
            set { locationdknotaccepted = value; }
        }

        #endregion // Global Variables

        public ucDefinitionTargetElements()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtOrigin;
            this.LastControlFocus = btnAccept;
        }

        /// <summary>
        /// Carga los valores en las cajas de texto si la lista dinamica
        /// contiene dichos valores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucDefinitionTargetElements_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            HideListboxControls();
            LoadComboBox();
            cmbDays.SelectedIndex = 0;
            cmbTicketType.SelectedIndex = 0;
            cmbPaxType.SelectedIndex = 0;
            cmbLocationDK.SelectedIndex = 0;
            cmbLocationDKNoAllow.SelectedIndex = 0;
            if (!string.IsNullOrEmpty(locationdknotaccepted))
            {
                cmbLocationDKNoAllow.SelectedItem = locationdknotaccepted;
            }
            if (ListTargetsRules != null && ListTargetsRules.Count > 0)
            {
                for (int i = 0; i < ListTargetsRules.Count; i++)
                    foreach (Control txt in this.Controls)
                    {
                        if (txt is SmartTextBox && txt.TabIndex == ListTargetsRules[i].IDTE && txt.Name!="txtAgent")
                        {
                            txt.Text = ListTargetsRules[i].Value2;
                            break;
                        }
                        else if (txt is SmartTextBox && ListTargetsRules[i].IDTE==12 && txt.Name == "txtAgent")
                        {
                            txt.Text = ListTargetsRules[i].Value2;
                            break;
                        }
                        else if (txt is ComboBox && txt.TabIndex == ListTargetsRules[i].IDTE
                            && txt.TabIndex != 5)
                        {
                            ((ComboBox)txt).SelectedItem = ListTargetsRules[i].Value2;
                            break;
                        }
                        else if (txt is ComboBox && txt.TabIndex == ListTargetsRules[i].IDTE
                       && txt.TabIndex == 5)
                        {
                            ((ComboBox)txt).SelectedIndex = paxnum;
                            break;
                        }
                    }
            }
            //if (!string.IsNullOrEmpty(locationdknotaccepted))
            //    cmbLocationDKNoAllow.SelectedItem = locationdknotaccepted;
            txtOrigin.Focus();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidBussinesRules)
            {
                AddTargets();
            }
        }

        #region ====== Methods Class ======

        /// <summary>
        /// No permite el despliegue de predictivo cuando se
        /// carga la mascarilla
        /// </summary>
        private void HideListboxControls()
        {
            statusParamReceived = false;
        }

        /// <summary>
        /// Valida las reglas del negocio aplicables a este user control
        /// </summary>
        private bool IsValidBussinesRules
        {
            get
            {
                bool isValid = true;
                if (!string.IsNullOrEmpty(txtOrigin.Text) && txtOrigin.TextLength != 3)
                {
                    MessageBox.Show("EL FORMATO DE LA CIUDAD DE ORIGEN DEBE SER DE 3 CARACTERES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtOrigin.Focus();
                    isValid = false;
                    return isValid;
                }
                if (!string.IsNullOrEmpty(txtDestino.Text) && txtDestino.TextLength != 3)
                {
                    MessageBox.Show("EL FORMATO DE LA CIUDAD DE DESTINO DEBE SER DE 3 CARACTERES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDestino.Focus();
                    isValid = false;
                    return isValid;
                }
                if (!string.IsNullOrEmpty(txtTravelDate.Text) && !ValidateRegularExpression.ValidateBirthDateFormat(txtTravelDate.Text))
                {
                    MessageBox.Show("EL FORMATO DE LA FECHA VIAJE ES INCORRECTO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTravelDate.Focus();
                    isValid = false;
                    return isValid;
                }
                if (!string.IsNullOrEmpty(txtEmissionDate.Text) && !ValidateRegularExpression.ValidateBirthDateFormat(txtEmissionDate.Text))
                {
                    MessageBox.Show("EL FORMATO DE LA FECHA DE EMISIÓN ES INCORRECTO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmissionDate.Focus();
                    isValid = false;
                    return isValid;
                }
                if (!string.IsNullOrEmpty(txtTravelDate.Text))
                {
                    try
                    {
                        DateTime travelDate = Convert.ToDateTime(txtTravelDate.Text);
                    }
                    catch
                    {
                        MessageBox.Show("LA FECHA DE VIAJE ES INVALIDA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTravelDate.Focus();
                        isValid = false;
                        return isValid;
                    }
                }
                if (!string.IsNullOrEmpty(txtEmissionDate.Text))
                {
                    try
                    {
                        DateTime emissionDate = Convert.ToDateTime(txtEmissionDate.Text);
                    }
                    catch
                    {
                        MessageBox.Show("LA FECHA DE EMISIÓN ES INVALIDA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtEmissionDate.Focus();
                        isValid = false;
                        return isValid;
                    }
                }
                if (cmbLocationDK.SelectedIndex > 0 && cmbLocationDKNoAllow.SelectedIndex > 0)
                {
                    MessageBox.Show("NO SE PUEDE ESTABLECER UNA REGLA EXCLUSIVA PARA UN DK Y EXCLUYENTE PARA OTRO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbLocationDK.Focus();
                    isValid = false;
                    return isValid;
                }
                return isValid;
            }
        }

        /// <summary>
        /// Carga los valores de los DK's a los ComboBox correspondientes
        /// </summary>
        private void LoadComboBox()
        {
            cmbLocationDK.Items.Add("Seleccione el valor deseado:");
            cmbLocationDKNoAllow.Items.Add("Seleccione el valor deseado:");
            for (int i = 0; i < ucNewFeeRule.listAttribute1.Count; i++)
            {
                cmbLocationDK.Items.Add(ucNewFeeRule.listAttribute1[i].LocationDK);
                cmbLocationDKNoAllow.Items.Add(ucNewFeeRule.listAttribute1[i].LocationDK);
            }
        }     

        /// <summary>
        /// Añade los valores de las cajas de texto y de los ComboBox a una lista
        /// dinamica
        /// </summary>
        private void AddTargets()
        {
            ListTargetsRules = new List<Targets>();
            foreach (Control txt in this.Controls)
            {
                if (txt is SmartTextBox && !string.IsNullOrEmpty(txt.Text) && txt.Name!="txtAgent")
                {
                        Targets t = new Targets();
                        t.IDTE = txt.TabIndex;
                        t.Value2 = txt.Text;
                        ListTargetsRules.Add(t);
                }
                else if (txt is SmartTextBox && !string.IsNullOrEmpty(txt.Text) && txt.Name == "txtAgent")
                {
                    Targets t = new Targets();
                    t.IDTE = 12;
                    t.Value2 = txt.Text;
                    ListTargetsRules.Add(t);
                }
                else if (txt is ComboBox && ((ComboBox)txt).SelectedIndex > 0
                    && txt.TabIndex != 5 && txt.TabIndex!=12)
                {
                    Targets t = new Targets();
                    t.IDTE = txt.TabIndex;
                    t.Value2 = Convert.ToString(((ComboBox)txt).SelectedItem);
                    ListTargetsRules.Add(t);
                }
                else if (txt is ComboBox && ((ComboBox)txt).SelectedIndex > 0 && txt.TabIndex == 5
                    && Convert.ToString(((ComboBox)txt).SelectedItem).Substring(0, 3) != "---")
                {
                    Targets t = new Targets();
                    t.IDTE = txt.TabIndex;
                    t.Value2 = Convert.ToString(((ComboBox)txt).SelectedItem).Substring(0, 3);
                    ListTargetsRules.Add(t);
                    paxnum = ((ComboBox)txt).SelectedIndex;
                }
            }
            if (cmbLocationDKNoAllow.SelectedIndex > 0)
                locationdknotaccepted = Convert.ToString(cmbLocationDKNoAllow.SelectedItem);
            else
                locationdknotaccepted = string.Empty;
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCDEFINITIONTARGETELEMENTS2);      
        } 

        #endregion //Methods Class

        #region ====== Calendar ======

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            statusDate = false;
            DateTime dateSelected = monthCalendar1.SelectionStart;
            if (DateTime.Compare(dateSelected, DateTime.Today) > 0)
                statusDate = true;
            else
                statusDate = false;
            string date = dateSelected.ToString("ddMMMyy", new System.Globalization.CultureInfo("en-US")).ToUpper();
            txtTravelDate.Text = date;
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
            txtEmissionDate.Text = date;
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

        #endregion //Calendar

        #region ======Back to a Previous Usercontrol or Validate Enter KeyDown=====

        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData.Equals(Keys.Escape))
            {
                if (ucNewFeeRule.LoadUserWelcome)
                    Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCNEWFEERULE, new string[] { "1" });
                else
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCNEWFEERULE);
            }
            if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
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

        #region ====== Predictives ======

        private void txtOrigin_TextChanged(object sender, EventArgs e)
        {
            if (!statusParamReceived)
            {
                txt = (TextBox)sender;
                Common.SetListBoxCities(txt, lbCityCode);
            }
        }

        /// <summary>
        /// Asignación de acciones al presionar la tecla ENTER o ESC 
        /// cuando el lbCityCode tiene el foco
        /// </summary>
        /// <param name="sender">lbCityCode</param>
        /// <param name="e"></param>
        private void lbCityCode_KeyDown(object sender, KeyEventArgs e)
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
                lbCityCode.Visible = false;
                txt.Focus();
            }

        }


        /// <summary>
        /// Asignacion de acciones al presionar la tecla ENTER, ESC o DOWN
        /// cuando algún txt de ciudades tiene el foco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CityCodeActions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                if (ucNewFeeRule.LoadUserWelcome)
                    Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCNEWFEERULE, new string[] { "1" });
                else
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCNEWFEERULE);
            }
            if (e.KeyData == Keys.Enter)
            {
                btnAccept_Click(sender, e);
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lbCityCode.Items.Count > 0)
                {
                    lbCityCode.SelectedIndex = 0;
                    lbCityCode.Focus();
                    lbCityCode.Visible = true;
                    lbCityCode.Focus();
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
            txt.Text = li.Value;
            listBox.Visible = false;
            txt.Focus();
        }

        #endregion //Predictives

    }
}
