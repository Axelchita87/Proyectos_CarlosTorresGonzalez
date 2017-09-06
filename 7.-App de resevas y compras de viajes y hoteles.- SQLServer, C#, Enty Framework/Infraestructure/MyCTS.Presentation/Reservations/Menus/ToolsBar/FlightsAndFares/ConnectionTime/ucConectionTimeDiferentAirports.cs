using System;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Entities;

namespace MyCTS.Presentation
{
    public partial class ucConectionTimeDiferentAirports : CustomUserControl
    {
        /// <summary>
        /// Descripción: User control que define el tiempo de
        ///              conexión con diferentes aeropuertos
        /// Creación:    29 de Enere 2010, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Angel Trejo Arizmendi
        /// </summary>  
        public ucConectionTimeDiferentAirports()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtCodeCity;
            this.LastControlFocus = btnAccept;
        }
        #region ===== Global Variables =====

        private TextBox txt;
        private bool statusParamReceived;

        #endregion // Global Variables

        private void ucConectionTimeDiferentAirports_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtCodeCity.Focus();
            HideListboxControls();
        }

        /// <summary>
        /// No permite el despliegue de predictivo cuando se
        /// carga la mascarilla
        /// </summary>
        private void HideListboxControls()
        {
            statusParamReceived = false;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidBussinesRules)
                BuilCommand();
        }

        #region===== METHODS CLASS =====

        /// <summary>
        /// Reglas aplicables a este user control
        /// </summary>
        private bool IsValidBussinesRules
        {
            get
            {
                bool isValid = false;
                if (string.IsNullOrEmpty(txtCodeCity.Text))
                {
                    MessageBox.Show("DEBE INGRESAR EL CÓDIGO DE CIUDAD", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCodeCity.Focus();
                }
                else if (string.IsNullOrEmpty(txtAirportArrival.Text))
                {
                    MessageBox.Show("DEBE INGRESAR AEROPUERTO DE LLEGADA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirportArrival.Focus();
                }
                else if (string.IsNullOrEmpty(txtAirportDeparture.Text))
                {
                    MessageBox.Show("DEBE INGRESAR EL AEROPUERTO DE SALIDA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirportDeparture.Focus();
                }
                else if (!string.IsNullOrEmpty(txtAirlineArrival.Text) && string.IsNullOrEmpty(txtAirlineDeparture.Text))
                {
                    MessageBox.Show("DEBE INGRESAR LA AEROLÍNEA DE SALIDA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirlineDeparture.Focus();
                }
                else if (!string.IsNullOrEmpty(txtAirlineDeparture.Text) && string.IsNullOrEmpty(txtAirlineArrival.Text))
                {
                    MessageBox.Show("DEBE INGRESAR LA AEROLÍNEA DE LLEGADA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirlineArrival.Focus();
                }
                else
                    isValid = true;
                return isValid;
            }
        }

        /// <summary>
        /// Armado del comando que se envia a sabre
        /// </summary>
        private void BuilCommand()
        {
            string send = string.Empty;
            string conexionType = string.Empty;
            if (rdoDomesticToDomestic.Checked)
                conexionType = "/DD/";
            else if (rdoDomesticToInternational.Checked)
                conexionType = "/DI/";
            else if (rdoInternationalToInternational.Checked)
                conexionType = "/II/";
            else if (rdoInternationalToDomestic.Checked)
                conexionType = "/ID/";
            else
                conexionType = string.Empty;
            send = string.Concat("T*CT-", txtCodeCity.Text);
            if (!string.IsNullOrEmpty(txtAirlineArrival.Text))
                send = string.Concat(send, "/",
                    txtAirlineArrival.Text,
                    txtAirlineDeparture.Text,
                    (string.IsNullOrEmpty(conexionType) ? "//" : conexionType),
                    txtAirportArrival.Text,
                    txtAirportDeparture.Text);
            else
                send = string.Concat(send,
                    (string.IsNullOrEmpty(conexionType) ? "///" : conexionType),
                   txtAirportArrival.Text,
                   txtAirportDeparture.Text);
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }

        #endregion //METHODS CLASS

        #region =====Back to a Previous Usercontrol or Validate Enter KeyDown=====

        /// <summary>
        /// Aborta el proceso al presionar la tecla ESC
        /// o ejecutar las funciones al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            if (e.KeyData.Equals(Keys.Enter))
                btnAccept_Click(sender, e);
        }

        #endregion //Back to a Previous Usercontrol or Validate Enter KeyDown

        #region=====Textbox Controls Text Change Events=====

        private void txtCodeCity_TextChanged(object sender, EventArgs e)
        {
            if (!statusParamReceived)
            {
                txt = (TextBox)sender;
                Common.SetListBoxCities(txt, lbCityCode);
            }
        }

        private void txtAirportArrival_TextChanged(object sender, EventArgs e)
        {
            if (!statusParamReceived)
            {
                txt = (TextBox)sender;
                Common.SetListBoxAirports(txt, lbAirportArrival);
            }
        }

        private void txtAirlineDeparture_TextChanged(object sender, EventArgs e)
        {
            if (!statusParamReceived)
            {
                txt = (TextBox)sender;
                Common.SetListBoxAirlines(txt, lbAirline);
            }
        }

        #endregion //Textbox Controls Text Change Events

        #region=====listbox Controls Events=====

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
        /// Asignación de acciones al presionar la tecla ENTER o ESC 
        /// cuando el lbAirportArrival tiene el foco
        /// </summary>
        /// <param name="sender">lbAirportArrival</param>
        /// <param name="e"></param>
        private void lbAirportArrival_KeyDown(object sender, KeyEventArgs e)
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
                lbAirportArrival.Visible = false;
                txt.Focus();
            }

        }

        /// <summary>
        /// Asignación de acciones al presionar la tecla ENTER o ESC 
        /// cuando el lbAirlines tiene el foco
        /// </summary>
        /// <param name="sender">lbAirlines</param>
        /// <param name="e"></param>
        private void lbAirline_KeyDown(object sender, KeyEventArgs e)
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
                lbAirline.Visible = false;
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
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
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
        /// Asignacion de acciones al presionar la tecla ENTER, ESC o DOWN
        /// cuando algún txt de aeropuertos tiene el foco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AirportArrivalActions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            if (e.KeyData == Keys.Enter)
            {
                btnAccept_Click(sender, e);
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lbAirportArrival.Items.Count > 0)
                {
                    lbAirportArrival.SelectedIndex = 0;
                    lbAirportArrival.Focus();
                    lbAirportArrival.Visible = true;
                    lbAirportArrival.Focus();
                }
            }

        }

        /// <summary>
        /// Asignacion de acciones al presionar la tecla ENTER, ESC o DOWN
        /// cuando algún txt de aereolínea tiene el foco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AirlineActions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            if (e.KeyData == Keys.Enter)
            {
                btnAccept_Click(sender, e);
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lbAirline.Items.Count > 0)
                {
                    lbAirline.SelectedIndex = 0;
                    lbAirline.Focus();
                    lbAirline.Visible = true;
                    lbAirline.Focus();
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
        #endregion //listbox Controls Events


    }
}
