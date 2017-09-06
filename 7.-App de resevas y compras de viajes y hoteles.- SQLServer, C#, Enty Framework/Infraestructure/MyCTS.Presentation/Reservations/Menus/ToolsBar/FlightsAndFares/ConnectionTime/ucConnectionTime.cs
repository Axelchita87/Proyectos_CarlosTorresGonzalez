using System;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Entities;

namespace MyCTS.Presentation
{
    public partial class ucConnectionTime : CustomUserControl
    {
        /// <summary>
        /// Descripción: User control que define el tiempo de
        ///              conexión mismo aeropuerto 
        /// Creación:    29 de Enere 2010, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Angel Trejo Arizmendi
        /// </summary>
        public ucConnectionTime()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtAirportCode;
            this.LastControlFocus = btnAccept;
        }

        #region ===== Global Variables =====

        private TextBox txt;
        private bool statusParamReceived;

        #endregion //Global Variables

        private void ucConnectionTime_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtAirportCode.Focus();
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
                BuildCommand();
        }
   

        #region ===== METHODS CLASS =====

        /// <summary>
        /// Reglas aplicables a este user control
        /// </summary>
        private bool IsValidBussinesRules
        {
            get
            {
                bool isValid = false;
                if (string.IsNullOrEmpty(txtAirportCode.Text))
                {
                    MessageBox.Show("DEBE INGRESAR EL CÓDIGO DE AEROPUERTO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirportCode.Focus();
                }
                else if (!string.IsNullOrEmpty(txtAirlineArrival.Text) && string.IsNullOrEmpty(txtAirlineDeparture.Text))
                {
                    MessageBox.Show("DEBE INGRESAR AEROLINEA DE SALIDA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirlineDeparture.Focus();
                }
                else if (!string.IsNullOrEmpty(txtAirlineDeparture.Text) && string.IsNullOrEmpty(txtAirlineArrival.Text))
                {
                    MessageBox.Show("DEBE INGRESAR AEROLINEA DE LLEGADA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirlineArrival.Focus();
                }
                else
                    isValid = true;
                return isValid;
            }
        }

        /// <summary>
        /// Armado del comando que se envia a Sabre
        /// </summary>
        private void BuildCommand()
        {
            string send = string.Empty;
            string conexionType = string.Empty;
            if (rdoDomesticToDomestic.Checked)
                conexionType = "/DD";
            else if (rdoDomesticToInternational.Checked)
                conexionType = "/DI";
            else if (rdoInternationalToInternational.Checked)
                conexionType = "/II";
            else if (rdoInternationalToDomestic.Checked)
                conexionType = "/ID";
            else
                conexionType = string.Empty;
            send = string.Concat("T*CT-", txtAirportCode.Text);
            if (!string.IsNullOrEmpty(txtAirlineArrival.Text))
                send = string.Concat(send, "/", txtAirlineArrival.Text, txtAirlineDeparture.Text, conexionType);
            else
                send = string.Concat(send, conexionType);
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }

        #endregion

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
        #endregion

        #region=====Textbox Controls Text Change Events=====

        private void txtAirportCode_TextChanged(object sender, EventArgs e)
        {
            if (!statusParamReceived)
            {
                txt = (TextBox)sender;
                Common.SetListBoxAirports(txt, lbAirport);
            }
        }

        private void txtAirlineArrival_TextChanged(object sender, EventArgs e)
        {
            if (!statusParamReceived)
            {
                txt = (TextBox)sender;
                Common.SetListBoxAirlines(txt, lbAirLine1);
            }
        }

        #endregion

        #region===== listbox Controls Events=====

        /// <summary>
        /// Asignación de acciones al presionar la tecla ENTER o ESC 
        /// cuando el lbAirport tiene el foco
        /// </summary>
        /// <param name="sender">lbAirport</param>
        /// <param name="e"></param>
        private void lbAirport_KeyDown(object sender, KeyEventArgs e)
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
                lbAirport.Visible = false;
                txt.Focus();
            }

        }

        /// <summary>
        /// Asignacion de acciones al presionar la tecla ENTER, ESC o DOWN
        /// cuando algún txt de aerepuerto tiene el foco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AirportActions_KeyDown(object sender, KeyEventArgs e)
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
                if (lbAirport.Items.Count > 0)
                {
                    lbAirport.SelectedIndex = 0;
                    lbAirport.Focus();
                    lbAirport.Visible = true;
                    lbAirport.Focus();
                }
            }

        }


        private void lbAirline1_KeyDown(object sender, KeyEventArgs e)
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
                lbAirLine1.Visible = false;
                txt.Focus();
            }
        }

        /// <summary>
        /// Asignacion de acciones al presionar la tecla ENTER, ESC o DOWN
        /// cuando algún txt de aereolínea tiene el foco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AirLine1Actions_KeyDown(object sender, KeyEventArgs e)
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
                if (lbAirLine1.Items.Count > 0)
                {
                    lbAirLine1.SelectedIndex = 0;
                    lbAirLine1.Focus();
                    lbAirLine1.Visible = true;
                    lbAirLine1.Focus();
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

        #endregion

        


    }
}
