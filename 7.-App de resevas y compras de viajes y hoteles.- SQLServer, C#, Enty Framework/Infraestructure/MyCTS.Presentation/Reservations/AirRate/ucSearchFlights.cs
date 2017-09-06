using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Presentation.Components;


namespace MyCTS.Presentation
{
    public partial class ucSearchFlights : CustomUserControl
    {
        /// <summary>
        /// Descripción: User Control que permite buscar mas opciones de vuelos
        ///              con diferentes aereolíneas, determinar el numero de conexiones y buscar 
        ///              tarifas por tipo de moneda
        /// Creación:    Diciembre 08 -Marzo 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        /// 
        private string sabreAnswer;
        private bool isValid;
        private bool statusSameAirline;
        private TextBox txt;

        public ucSearchFlights()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = chkSearchInOthersAirports;
            this.LastControlFocus = btnAccept;
        }

        //Evento Load
        private void ucSearchFlights_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            chkSearchInOthersAirports.Focus();
            HideListboxControls();
        }


        /// <summary>
        /// Ejecución de funciones de la mascarilla de "Buscar otros vuelos" 
        /// al presionar el boton click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!IsValidBusinessRules)
            {
                CommandsSend();
                APIResponse();
            }
        }

        #region===== MethodsClass =====

       /// <summary>
       /// Oculta el control lbAirlines y lbMoneyCode
       /// </summary>
        private void HideListboxControls()
        {
            lbAirlines.BringToFront();
            lbAirlines.Visible = false;
            lbMoneyCode.BringToFront();
            lbMoneyCode.Visible = false;
        }
              
       /// <summary>
       /// Reglas de negocio correspondientes la pantalla de "Buscar otros vuelos"
       /// </summary>
       /// <returns></returns>
        private bool IsValidBusinessRules
        {
            get
            {
                isValid = true;
                statusSameAirline = false;
                AirlinesNotEquals();
                if (statusSameAirline)
                {
                    MessageBox.Show(Resources.Reservations.NO_PER_COD_AEREOLINEA_REPETIDOS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtConnections.Text = Resources.Constants.ONE;
                    statusSameAirline = false;
                    if (!string.IsNullOrEmpty(txtAirline1.Text))
                        txtAirline1.Focus();
                    else if (!string.IsNullOrEmpty(txtAirline2.Text))
                        txtAirline2.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtAirline1.Text)) && (txtAirline1.Text.Length != 2))
                {
                    MessageBox.Show(Resources.Reservations.COD_AEREOLINEA_DEBE_SER_DOS_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirline1.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtAirline2.Text)) && (txtAirline2.Text.Length != 2))
                {
                    MessageBox.Show(Resources.Reservations.COD_AEREOLINEA_DEBE_SER_DOS_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirline2.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtAirline3.Text)) && (txtAirline3.Text.Length != 2))
                {
                    MessageBox.Show(Resources.Reservations.COD_AEREOLINEA_DEBE_SER_DOS_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirline3.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtConnections.Text)) &&
                          (Convert.ToInt32(txtConnections.Text) > 3) &&
                          (!statusSameAirline))
                {
                    MessageBox.Show(Resources.Reservations.NUM_MAX_CONEXIONES_3, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtConnections.Text = Resources.Constants.ONE;
                    isValid = true;
                    txtConnections.Focus();
                }
                else if (string.IsNullOrEmpty(txtConnections.Text))
                {
                    MessageBox.Show(Resources.Reservations.DEBES_ING_NUM_CONEXIONES, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtConnections.Text = Resources.Constants.ONE;
                    isValid = true;
                    txtConnections.Focus();
                }
                else if (txtConnections.Text.Equals(Resources.Constants.ZERO))
                {
                    MessageBox.Show(Resources.Reservations.CERO_NO_PERMITIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtConnections.Text = Resources.Constants.ONE;
                    isValid = true;
                    txtConnections.Focus();
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
        /// Armado y envio de comando a MySabre
        /// </summary>
        private void CommandsSend()
        {
            string send = string.Empty;
            string moneyCode = string.Empty; 
            string money = string.Empty; 
            string searchFlights = string.Empty; 
            string otherAirports = string.Empty; 
            string airlines = string.Empty; ;
            string connections = string.Empty; 
            string obligatoryParameter = string.Empty; 
            string passPosition = string.Empty; 
            string bySegments = string.Empty;
            string quarrelType = string.Empty;
            bool statusSearchInOthersAirports;


            statusSearchInOthersAirports = chkSearchInOthersAirports.Checked;
            statusSameAirline = false;
            searchFlights = Resources.Constants.COMMANDS_WPNI;
            otherAirports = Resources.Constants.COMMANDS_N;
            airlines = string.Concat(Resources.Constants.COMMANDS_SLA_A,
                txtAirline1.Text,
                txtAirline2.Text,
                txtAirline3.Text);
            connections = string.Concat(Resources.Constants.COMMANDS_SLA_K,
                txtConnections.Text);
            obligatoryParameter = Resources.Constants.COMMANDS_CROSSLORAINE_Z19;
            moneyCode = txtMoneyCode.Text;
            money = string.Format(Resources.Constants.COMMANDS_CROSSLORAINE_M_AGENT,
                moneyCode);
            if (!statusSearchInOthersAirports)
            {
                otherAirports = string.Empty;
            }
            if (airlines.Equals(Resources.Constants.COMMANDS_SLA_A))
            {
                airlines = string.Empty;
            }
            if (this.Parameters != null)
            {
                bySegments = this.Parameters[0];
                passPosition = this.Parameters[1];
                quarrelType = this.Parameters[2];
            }
            else
            {
                bySegments = string.Empty;
                passPosition = string.Empty;
                quarrelType = string.Empty;
            }
            if (string.IsNullOrEmpty(txtMoneyCode.Text))
            {
                money = string.Empty;
            }
            send = string.Concat(searchFlights,
                otherAirports,
                airlines,
                connections,
                obligatoryParameter,
                money,
                bySegments,
                passPosition,
                quarrelType);
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }
        }

        /// <summary>
        /// Validación de posibles errores en la respuesta de MySabre
        /// </summary>
        private void APIResponse()
        {
            ERR_AirRateMenu.err_AirRateMenu(sabreAnswer);
            if (ERR_AirRateMenu.Status == false)
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCSELL_OPTION);
            }
            else
            {
                MessageBox.Show(ERR_AirRateMenu.CustomUserMsg, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }


        /// <summary>
        /// Validación de códigos de Aereolínea no repetidos
        /// ingresados en la mascarilla de "Buscar otros vuelos"
        /// </summary>
        private void AirlinesNotEquals()
        {
            if (!string.IsNullOrEmpty(txtAirline1.Text))
            {
                if ((txtAirline1.Text.Equals(txtAirline2.Text)) ||
                (txtAirline1.Text.Equals(txtAirline3.Text)))
                    statusSameAirline = true;
            }
            if (!string.IsNullOrEmpty(txtAirline2.Text))
            {
                if ((txtAirline2.Text.Equals(txtAirline1.Text)) ||
                (txtAirline2.Text.Equals(txtAirline3.Text)))
                    statusSameAirline = true;
            }
            if (!string.IsNullOrEmpty(txtAirline3.Text))
            {
                if ((txtAirline3.Text.Equals(txtAirline1.Text)) ||
                (txtAirline3.Text.Equals(txtAirline2.Text)))
                    statusSameAirline = true;
            }
        }


        #endregion//End MethodsClass



        #region =====Back to a Previous Usercontrol or Validate Enter KeyDown=====

        /// <summary>
        /// Regreso a la mascarilla de "Cotizacíon Aérea" al presionar la tecla ESC
        /// o ejecutar las funciones al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData.Equals(Keys.Escape))
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCAIR_RATE);



            if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }


        }
        #endregion//End Back to a Previous Usercontrol or Validate Enter KeyDown



        #region===== Textbox Controls Text Change Events =====

        /// <summary>
        /// Activación de predictivo de aereolínea al cambiar los datos ingresados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAirline_TextChanged(object sender, EventArgs e)
        {
            txt = (TextBox)sender;
            Common.SetListBoxAirlines(txt, lbAirlines);
        }

        /// <summary>
        /// Cambio de foco al siguiente control cuando txtConnections esta lleno
        /// </summary>
        /// <param name="sender">txtConnections</param>
        /// <param name="e"></param>
        private void txtConnections_TextChanged(object sender, EventArgs e)
        {
            if ((txtConnections.Text.Length > 0) && (txtConnections.Text != Resources.Constants.ONE))
            {
                txtMoneyCode.Focus();
            }
        }


        /// <summary>
        /// Activación de predictivo de moneda al cambiar los datos ingresados
        /// </summary>
        /// <param name="sender">txtMoneyCode</param>
        /// <param name="e"></param>
        private void txtMoneyCode_TextChanged(object sender, EventArgs e)
        {
            txt = (TextBox)sender;
            Common.SetListBoxCurrenciesCountries(txt, lbMoneyCode);
        }

        #endregion//Textbox Controls Text Change Events



        #region===== listbox Controls Events=====

        /// <summary>
        /// Asignacion de acciones al presionar la tecla ENTER o ESC 
        /// cuando el lbAirlines tiene el foco
        /// </summary>
        /// <param name="sender">lbMoneyCode</param>
        /// <param name="e"></param>
        private void lbAirlines_KeyDown(object sender, KeyEventArgs e)
        {
            ListBox ListBox = (ListBox)sender;
            if (e.KeyCode.Equals(Keys.Enter))
            {
                ListItem li = (ListItem)ListBox.SelectedItem;
                txt.Text = li.Value;
                ListBox.Visible = false;
                txt.Focus();
            }
            if (e.KeyCode.Equals(Keys.Escape))
            {
                lbAirlines.Visible = false;
                txt.Focus();
            }

        }


        /// <summary>
        /// Esconde el listbox al perder el foco
        /// </summary>
        /// <param name="sender">lbAirlines</param>
        /// <param name="e"></param>
        private void HideListbox_Airlines(object sender, EventArgs e)
        {
            lbAirlines.Visible = false;
        }


        /// <summary>
        /// Asignacion de acciones al presionar la tecla ENTER, ESC o DOWN
        /// cuando algún txt de aereolínea tiene el foco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AirlinesActions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }
            if (e.KeyCode.Equals(Keys.Down))
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
        /// Escode el listbox al perder el foco
        /// </summary>
        /// <param name="sender">lbAirlines</param>
        /// <param name="e"></param>
        private void txtAirlinesControls_Leave(object sender, EventArgs e)
        {
            lbAirlines.Visible = false;
        }


        /// <summary>
        /// Asignacion de acciones al presionar la tecla ENTER o ESC 
        /// cuando el lbMoneyCode tiene el foco
        /// </summary>
        /// <param name="sender">lbMoneyCode</param>
        /// <param name="e"></param>
        private void lbMoneyCode_KeyDown(object sender, KeyEventArgs e)
        {
            ListBox ListBox = (ListBox)sender;
            if (e.KeyCode.Equals(Keys.Enter))
            {
                ListItem li = (ListItem)ListBox.SelectedItem;
                txt.Text = li.Value;
                ListBox.Visible = false;
                txt.Focus();
            }
            if (e.KeyCode.Equals(Keys.Escape))
            {
                lbMoneyCode.Visible = false;
                txt.Focus();
            }
        }


        /// <summary>
        /// Esconde el listbox al perder el foco
        /// </summary>
        /// <param name="sender">lbMoneyCode</param>
        /// <param name="e"></param>
        private void HideListbox_MoneyCode(object sender, EventArgs e)
        {
            lbMoneyCode.Visible = false;

        }


        /// <summary>
        /// Asignacion de acciones al presionar la tecla ENTER, ESC o DOWN
        /// cuando txtMoneyCode tiene el foco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void moneyCodeActions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                if (lbMoneyCode.Items.Count > 0)
                {
                    lbMoneyCode.SelectedIndex = 0;
                    lbMoneyCode.Focus();
                    lbMoneyCode.Visible = true;
                    lbMoneyCode.Focus();
                }
            }

        }


        /// <summary>
        /// Esconde el listbox al perder el foco
        /// </summary>
        /// <param name="sender">lbMoneyCode</param>
        /// <param name="e"></param>
        private void txtMoneyCodeControl_Leave(object sender, EventArgs e)
        {
            lbMoneyCode.Visible = false;
        }


        /// <summary>
        /// Selecciona algún elemento dentro de algún listbox al hacer un click
        /// sobre el
        /// </summary>
        /// <param name="sender">lbMOneyCode</param>
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


    }
}
