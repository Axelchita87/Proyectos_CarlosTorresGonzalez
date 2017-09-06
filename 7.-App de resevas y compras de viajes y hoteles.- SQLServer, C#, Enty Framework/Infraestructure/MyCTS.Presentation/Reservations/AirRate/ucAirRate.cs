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


namespace MyCTS.Presentation
{

    public partial class ucAirRate : CustomUserControl
    {

        /// <summary>
        /// Descripción: User Control que permite la creacion de tarifa del segmento escogido
        ///              con varias opciones. Pertenece al flujo de reservaciones de la aplicación.
        /// Creación:    Diciembre 08 -Marzo 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        
        private string sabreAnswer;
        private string send;
        private string money;
        private string airline;
        private string bySegments;
        private string passPosition;
        private string passType;
        private string codeOrId;
        private string quarrelType;
        private string passTypeST;
        private string passTypeS;
        private string passTypeV;
        private bool isValid;
        private bool statusBySegments;
        private bool statusPassPosition;
        private bool statusPassType;
        
        private TextBox txt;

        //Arreglo tipo string para mantener valores provenientes de ucAvailability
        private string[] loadInfoAvailability;

        //Arreglo tipo string para enviar parametros a mascarillas del menu de cotización
        //aérea
        private string[] SendInfo;

        public ucAirRate()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = rdoSellOtherFly;
            this.LastControlFocus = btnAccept;
        }

 
        /// <summary>
        /// Carga user control ucAirRate con sus valores iniciales
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucAirRate_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            LoadInitialStateControls();
            UcAvailabilityInfo();
            CmbAirlineLoadInfo();
        }


        /// <summary>
        /// Funciones del user control al presionar el boton Aceptar
        /// </summary>
        /// <param name="sender">btnAccept</param>
        /// <param name="e"></param>
        private void btn1_Click(object sender, EventArgs e)
        {
            if (rdoSellOtherFly.Checked)
            {
                SellOtherFlyCommandsSend();
            }
            else if (rdoQuoItinerary.Checked)
            {
                
                if (!IsValidBusinessRules)
                {
                    QuoItineraryCommandsSend();
                    APIResponse();
                }
            }
            else if (rdoSaveRate.Checked)
            {
                if (!IsValidBusinessRules)
                {
                    SaveRateCommandsSend();
                    RateValidation(sabreAnswer);
                }
            }
            else if (rdoQuoCheapBut.Checked)
            {
                if (!IsValidBusinessRules)
                {
                    QuoCheapButCommandsSend();
                    APIResponse();
                }
            }
            else if (rdoQuoCheapNonavailable.Checked)
            {
                if (!IsValidBusinessRules)
                {
                    QuoCheapNonavailableCommandsSend();
                    APIResponse();
                }
            }
            else if (rdoChangeToMostCheap.Checked)
            {
                if (!IsValidBusinessRules)
                {
                    ChangeToMostCheapCommandsSend();
                    APIResponse();
                }
            }
            else if (rdoSearchFlights.Checked)
            {
                SearchFlightsCommandsSend();
            }
            else if (rdoManualRate.Checked)
            {
                ManualRateCommandsSend();
            }
            else if (rdoRateOptions.Checked)
            {
                RateOptionsCommandsSend();
            }
            else if (rdoBuildQuaDisplayed.Checked)
            {
                BuildQuaDisplayedCommandsSend();
                APIResponse();
            }
            else if (rdoQuaWeb.Checked)
            {
                QuaWebCommandsSend();
                APIResponse();
            }
            else if (rdoPhase35375.Checked)
            {
                Phase35375CommandsSend();
            }
        }


        #region ===== methodsClass =====

        /// <summary>
        /// Establece estado de los controles del user control al cargarlo.
        /// </summary>
        private void LoadInitialStateControls()
        {
            rdoSellOtherFly.Checked = true;
            rdoSellOtherFly.Focus();
            lbMoneyCode.BringToFront();
            lbMoneyCode.Visible = false;
            cmbAirline.Enabled = false;
            txtSegment1.Enabled = false;
            txtSegment2.Enabled = false;
            txtSegment3.Enabled = false;
            txtSegment4.Enabled = false;
            txtSegment5.Enabled = false;
            txtSegment6.Enabled = false;
            txtPassenger1.Enabled = false;
            txtPassenger2.Enabled = false;
            txtPassenger3.Enabled = false;
            txtPassenger4.Enabled = false;
            txtSegment1.BackColor = SystemColors.Control;
            txtSegment2.BackColor = SystemColors.Control;
            txtSegment3.BackColor = SystemColors.Control;
            txtSegment4.BackColor = SystemColors.Control;
            txtSegment5.BackColor = SystemColors.Control;
            txtSegment6.BackColor = SystemColors.Control;
            txtPassenger1.BackColor = SystemColors.Control;
            txtPassenger2.BackColor = SystemColors.Control;
            txtPassenger3.BackColor = SystemColors.Control;
            txtPassenger4.BackColor = SystemColors.Control;
            cmbPassType.SelectedIndex = 0;
            sabreAnswer = string.Empty;
        }



        #region ===== rdoSellOtherFly =====

        /// <summary>
        /// Habilita e inhabilita ciertos controles cuando la 
        /// opción de "Vende otro vuelo" es seleccionada
        /// </summary>
        private void SellOtherFlyEnableDisableControls()
        {
            DisableCommonControls(rdoSellOtherFly.Checked);
        }


        /// <summary>
        /// Carga el user control de Disponibilidad con o sin parametros
        /// cuando la opciön de "Vende otro vuelo" es seleccionada 
        /// </summary>
        private void SellOtherFlyCommandsSend()
        { 
            if (loadInfoAvailability == null)
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCAVAILABILITY);
            }
            else
            {
                SendInfo = new string[] { loadInfoAvailability[0], loadInfoAvailability[1] };
                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCAVAILABILITY, SendInfo);
            }

        }

        #endregion//End rdoSellOtherFly



        #region ===== rdoQuoItinerary =====

        /// <summary>
        /// Habilita e inhabilita ciertos controles cuando la 
        /// opción de "Cotiza itinerario" es seleccionada
        /// </summary>
        private void QuoItineraryEnableDisableControls()
        {
            txtMoneyCode.Enabled = true;
            txtMoneyCode.BackColor = Color.White;
            cmbAirline.Enabled = true;
            chkBySegments.Checked = false;
            chkBySegments.Enabled = true;
            chkPassPosition.Checked = false;
            chkPassPosition.Enabled = true;
            chkPassType.Checked = false;
            chkPassType.Enabled = true;
            txtCorporateId.Text = string.Empty;
            txtCorporateId.Enabled = true;
            txtCorporateId.BackColor = Color.White;
            txtAccountCode.Text = string.Empty;
            txtAccountCode.Enabled = true;
            txtAccountCode.BackColor = Color.White;
            chkPublic.Checked = false;
            chkPublic.Enabled = true;
            chkPrivate.Checked = false;
            chkPrivate.Enabled = true;
            chkXC.Enabled = true;
        }


        /// <summary>
        /// Arma el comando respectivo y lo envia a MySabre
        /// cuando la opción "Vende otro vuelo" y se da click en el boton Aceptar
        /// </summary> 
        private void QuoItineraryCommandsSend()
        {
            AditionalParametersValues();
            string quoItinerary;
            quoItinerary = Resources.Constants.COMMANDS_WP;
            send = string.Empty;
            send = string.Concat(quoItinerary,
            money,
            airline,
            bySegments,
            passPosition,
            passType,
            codeOrId,
            quarrelType);
            if ((string.IsNullOrEmpty(money)) && (send.Length > 2))
            {
                send = send.Remove(2, 1);
            }
            if (!string.IsNullOrEmpty(txtCorporateId.Text) ||
               !string.IsNullOrEmpty(txtAccountCode.Text))
            {
                if (chkXC.Checked)
                {
                    send = string.Concat(send, "¥XC");
                }
            }

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }
        }

        #endregion//End rdoQuoItinerary



        #region===== rdoSaveRate =====

        /// <summary>
        /// Habilita e inhabilita ciertos controles cuando la 
        /// opción de "Guarda y fin de venta" es seleccionada
        /// </summary>
        private void SaveRateEnableDisableControls()
        {
            DisableCommonControls(rdoSaveRate.Checked);
        }


        /// <summary>
        /// Arma el comando respectivo y lo envia a MySabre
        /// cuando la opción "Guarda y fin de venta" y se da click en el boton Aceptar
        /// </summary> 
        private void SaveRateCommandsSend()
        {
            send = Resources.Constants.COMMANDS_PQ;
            sabreAnswer = string.Empty;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }
        }

        /// <summary>
        /// Valida si se encontró una tarifa manual en el record
        /// y permite continuar con el flujo de reservaciones.
        /// </summary>
        /// <param name="result">cadena con respuesta de MySabre</param>
        private void RateValidation(string result)
        {
            int row = 0;
            int col = 0;
            CommandsQik.searchResponse(result, Resources.ErrorMessages.PRICE_QUOTE_RECORD_RETAINED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                string activeProfiles = ParameterBL.GetParameterValue(Resources.Profiles.Constants.ACTIVE_PROFILE_FLOW).Values;
                if (Convert.ToBoolean(activeProfiles))
                    setProfileModule();
                else
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCADD_DATA_PASSENGER);
            }
            else
            {
                row = 0;
                col = 0;
                sabreAnswer = string.Empty;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    sabreAnswer = objCommand.SendReceive(Resources.Constants.COMMANDS_AST_PQ);
                }
                CommandsQik.searchResponse(sabreAnswer, Resources.ErrorMessages.PRICE_QUOTE_RECORD_INDENT_DETAILS, ref row, ref col);
                if (row != 0 || col != 0)
                {
                    string activeProfiles = ParameterBL.GetParameterValue(Resources.Profiles.Constants.ACTIVE_PROFILE_FLOW).Values;
                    if (Convert.ToBoolean(activeProfiles))
                        setProfileModule();
                    else
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCADD_DATA_PASSENGER);
                }
                else
                {
                    MessageBox.Show(Resources.Reservations.NO_SE_PUEDE_COTIZAR_SIN_RESERVACION, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
                
            
                
            
        }

        private void setProfileModule()
        {
            frmProfiles frm = new frmProfiles();
            frm.StartPosition = FormStartPosition.Manual;
            frmProfiles.IsReservationFlow = true;
            frm.Left = this.ParentForm.Left + 740;
            frm.Top = this.Parent.Top + 98;
            frm.Height = 590;
            frm.Width = 630;
            frm.ShowDialog();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCADD_MORE_PASSENGER);
        }    


        #endregion//End rdoSaveRate



        #region===== rdoQuoCheapBut =====

        /// <summary>
        /// Habilita e inhabilita ciertos controles cuando la 
        /// opción de "Cotiza lo mas económico" es seleccionada
        /// </summary>
        private void QuoCheapButEnableDisableControls()
        {
            txtMoneyCode.Enabled = true;
            txtMoneyCode.BackColor = Color.White;
            cmbAirline.Enabled = true;
            chkBySegments.Checked = false;
            chkBySegments.Enabled = true;
            chkPassPosition.Checked = false;
            chkPassPosition.Enabled = true;
            chkPassType.Checked = false;
            chkPassType.Enabled = false;
            cmbPassType.Enabled = false;
            txtCorporateId.Text = string.Empty;
            txtCorporateId.Enabled = true;
            txtCorporateId.BackColor = Color.White;
            txtAccountCode.Text = string.Empty;
            txtAccountCode.Enabled = true;
            txtAccountCode.BackColor = Color.White;
            chkPublic.Checked = false;
            chkPublic.Enabled = true;
            chkPrivate.Checked = false;
            chkPrivate.Enabled = true;
        }


        /// <summary>
        /// Arma el comando respectivo y lo envia a MySabre
        /// cuando la opción "Cotiza lo mas económico" y se da click en el boton Aceptar
        /// </summary> 
        private void QuoCheapButCommandsSend()
        {

            string quoCheapBut;
            sabreAnswer = string.Empty;
            AditionalParametersValues();
            quoCheapBut = Resources.Constants.COMMANDS_WPNC;
            if (!string.IsNullOrEmpty(money))
            {
                money = string.Empty;
                money = string.Format(Resources.Constants.COMMANDS_CROSSLORAINE_M_AGENT,
                    txtMoneyCode.Text);
            }
            send = string.Empty;
            send = string.Concat(quoCheapBut,
                money, 
                airline,
                bySegments,
                passPosition, 
                codeOrId,
                quarrelType);
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }
        }

        #endregion//End rdoQuoCheapBut



        #region===== rdoCheapNonavailable =====

        /// <summary>
        /// Habilita e inhabilita ciertos controles cuando la 
        /// opción de "Cotiza lo mas económico no disponible" es seleccionada
        /// </summary>
        private void QuoCheapNonavailableEnableDisableControls()
        {
            txtMoneyCode.Enabled = true;
            txtMoneyCode.BackColor = Color.White;
            cmbAirline.Enabled = true;
            chkBySegments.Checked = false;
            chkBySegments.Enabled = true;
            chkPassPosition.Checked = false;
            chkPassPosition.Enabled = true;
            chkPassType.Checked = false;
            chkPassType.Enabled = false;
            cmbPassType.Enabled = false;
            txtCorporateId.Text = string.Empty;
            txtCorporateId.Enabled = false;
            txtCorporateId.BackColor = SystemColors.Control;
            txtAccountCode.Text = string.Empty;
            txtAccountCode.Enabled = false;
            txtAccountCode.BackColor = SystemColors.Control;
            chkPublic.Checked = false;
            chkPublic.Enabled = true;
            chkPrivate.Checked = false;
            chkPrivate.Enabled = true;
        }


        /// <summary>
        /// Arma el comando respectivo y lo envia a MySabre
        /// cuando la opción "Cotiza lo mas económico no dsiponible" y se da click en el boton Aceptar
        /// </summary> 
        private void QuoCheapNonavailableCommandsSend()
        {
            string quoCheapNonavailable;
            AditionalParametersValues();
            quoCheapNonavailable = Resources.Constants.COMMANDS_WPNCS;
            if (!string.IsNullOrEmpty(money))
            {
                money = string.Empty;
                money = string.Format(Resources.Constants.COMMANDS_CROSSLORAINE_M_AGENT,
                    txtMoneyCode.Text);
            }
            send = string.Empty;
            send = string.Concat(quoCheapNonavailable,
                money,
                airline,
                bySegments,
                passPosition,
                quarrelType);
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }
            
        }

        #endregion//End rdoQuoCheapNonavailable



        #region===== rdoChangeToMostCheap =====

        /// <summary>
        /// Habilita e inhabilita ciertos controles cuando la 
        /// opción de "Cambia a la tarifa mas económica" es seleccionada
        /// </summary>
        private void ChangeToMostCheapEnableDisableControls()
        {
            txtMoneyCode.Enabled = true;
            txtMoneyCode.BackColor = Color.White;
            cmbAirline.Enabled = true;
            chkBySegments.Checked = false;
            chkBySegments.Enabled = true;
            chkPassPosition.Checked = false;
            chkPassPosition.Enabled = true;
            chkPassType.Checked = false;
            chkPassType.Enabled = false;
            cmbPassType.Enabled = false;
            txtCorporateId.Text = string.Empty;
            txtCorporateId.Enabled = true;
            txtCorporateId.BackColor = Color.White; ;
            txtAccountCode.Text = string.Empty;
            txtAccountCode.Enabled = true;
            txtAccountCode.BackColor = Color.White;
            chkPublic.Checked = false;
            chkPublic.Enabled = true;
            chkPrivate.Checked = false;
            chkPrivate.Enabled = true;
        }


        /// <summary>
        /// Arma el comando respectivo y lo envia a MySabre
        /// cuando la opción "Cambia a la tarifa mas económica" y se da click en el boton Aceptar
        /// </summary> 
        private void ChangeToMostCheapCommandsSend()
        {
            string changeToMostCheap;
            AditionalParametersValues();
            changeToMostCheap = Resources.Constants.COMMANDS_WPNCB;
            if (!string.IsNullOrEmpty(money))
            {
                money = string.Empty;
                money = string.Format(Resources.Constants.COMMANDS_CROSSLORAINE_M_AGENT,
                    txtMoneyCode.Text);
            }
            send = string.Empty;
            send = string.Concat(changeToMostCheap,
                money,
                airline,
                bySegments,
                passPosition,
                codeOrId,
                quarrelType);
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }
        }

        #endregion// rdoChangeToMostCheap



        #region===== rdoSearchFlights =====

        /// <summary>
        /// Habilita e inhabilita ciertos controles cuando la 
        /// opción de "Buscar otros vuelos" es seleccionada
        /// </summary>
        private void SearchFlightsEnableDisableControls()
        {
            txtMoneyCode.Enabled = false;
            txtMoneyCode.BackColor = SystemColors.Control;
            cmbAirline.Text = Resources.Constants.AIRLINE_INITIAL_TEXT;
            cmbAirline.Enabled = false;
            chkBySegments.Checked = false;
            chkBySegments.Enabled = true;
            chkPassPosition.Checked = false;
            chkPassPosition.Enabled = true;
            chkPassType.Checked = false;
            chkPassType.Enabled = false;
            cmbPassType.Enabled = false;
            txtCorporateId.Text = string.Empty;
            txtCorporateId.Enabled = false;
            txtCorporateId.BackColor = SystemColors.Control;
            txtAccountCode.Text = string.Empty;
            txtAccountCode.Enabled = false;
            txtAccountCode.BackColor = SystemColors.Control;
            chkPublic.Checked = false;
            chkPublic.Enabled = true;
            chkPrivate.Checked = false;
            chkPrivate.Enabled = true;
        }


        /// <summary>
        /// Muestra la mascarilla de "Buscar otros vuelos"
        /// cuando la opción "Buscar otros vuelos" y se da click en el boton Aceptar
        /// </summary> 
        private void SearchFlightsCommandsSend()
        {
            AditionalParametersValues();
            SendInfo = new string[] { bySegments, passPosition, quarrelType };
            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCSEARCH_OTHER_FLIGHTS, SendInfo);
        }

        #endregion//End rdoSearchFlights



        #region===== rdoManualRate =====

        /// <summary>
        /// Habilita e inhabilita ciertos controles cuando la 
        /// opción de "Guarda tarifa manual" es seleccionada
        /// </summary>
        private void ManualRateEnableDisableControls()
        {
            txtMoneyCode.Enabled = true;
            txtMoneyCode.BackColor = Color.White;
            cmbAirline.Text = Resources.Constants.AIRLINE_INITIAL_TEXT;
            cmbAirline.Enabled = false;
            chkBySegments.Checked = false;
            chkBySegments.Enabled = false;
            chkPassPosition.Checked = false;
            chkPassPosition.Enabled = false;
            chkPassType.Checked = false;
            chkPassType.Enabled = false;
            cmbPassType.Enabled = false;
            txtCorporateId.Text = string.Empty;
            txtCorporateId.Enabled = false;
            txtCorporateId.BackColor = SystemColors.Control;
            txtAccountCode.Text = string.Empty;
            txtAccountCode.Enabled = false;
            txtAccountCode.BackColor = SystemColors.Control;
            chkPublic.Checked = false;
            chkPublic.Enabled = false;
            chkPrivate.Checked = false;
            chkPrivate.Enabled = false;
        }


        /// <summary>
        /// Muestra la mascarilla de "Guarda tarifa manual"
        /// cuando la opción "Guarda tarifa manual" y se da click en el boton Aceptar
        /// </summary> 
        private void ManualRateCommandsSend()
        {
            money = txtMoneyCode.Text;
            SendInfo = new string[] { money };
            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCMANUAL_RATE, SendInfo);
        }

        #endregion//End rdoManualRate



        #region===== rdoRateOptions =====

        /// <summary>
        /// Habilita e inhabilita ciertos controles cuando la 
        /// opción de "Ver opciones de cotización" es seleccionada
        /// </summary>
        private void RateOptionsEnableDisableControls()
        {
            txtMoneyCode.Enabled = true;
            txtMoneyCode.BackColor = Color.White;
            cmbAirline.Text = Resources.Constants.AIRLINE_INITIAL_TEXT;
            cmbAirline.Enabled = false;
            chkBySegments.Checked = false;
            chkBySegments.Enabled = true;
            chkPassPosition.Checked = false;
            chkPassPosition.Enabled = true;
            chkPassType.Checked = false;
            chkPassType.Enabled = false;
            cmbPassType.Enabled = false;
            txtCorporateId.Text = string.Empty;
            txtCorporateId.Enabled = false;
            txtCorporateId.BackColor = SystemColors.Control;
            txtAccountCode.Text = string.Empty;
            txtAccountCode.Enabled = false;
            txtAccountCode.BackColor = SystemColors.Control;
            chkPublic.Checked = false;
            chkPublic.Enabled = true;
            chkPrivate.Checked = false;
            chkPrivate.Enabled = true;
        }


        /// <summary>
        /// Muestra la mascarilla de Ver opciones de cotización
        /// cuando la opción "Ver opciones de cotización" y se da click en el boton Aceptar
        /// </summary> 
        private void RateOptionsCommandsSend()
        {
            AditionalParametersValues();
            SendInfo = new string[] { bySegments, passPosition, quarrelType, money };
            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCSHOW_RATE, SendInfo);
        }

        #endregion//End rdoRateOptions



        #region===== rdoBuildQuaDisplayed =====

        /// <summary>
        /// Habilita e inhabilita ciertos controles cuando la 
        /// opción de "Construcción de la tarifa desplegada" es seleccionada
        /// </summary>
        private void BuilQuaDisplayedEnableDisableControls()
        {
            DisableCommonControls(rdoBuildQuaDisplayed.Checked);
        }


        /// <summary>
        /// Arma el comando respectivo y lo envia a MySabre
        /// cuando la opción "Construcción de la tarifa desplegada" y se da click en el boton Aceptar
        /// </summary> 
        private void BuildQuaDisplayedCommandsSend()
        {
            string buildQuaDisplayed;
            send = string.Empty;
            buildQuaDisplayed = Resources.Constants.COMMANDS_WPDF;
            send = buildQuaDisplayed;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }
        }

        #endregion//End rdoBuildQuaDisplayed



        #region===== rdoQuaWeb =====

        /// <summary>
        /// Habilita e inhabilita ciertos controles cuando la 
        /// opción de "Cotiza tarifa web" es seleccionada
        /// </summary>
        private void QuaWebEnableDisableControls()
        {
            DisableCommonControls(rdoQuaWeb.Checked);
        }


        /// <summary>
        /// Arma el comando respectivo y lo envia a MySabre
        /// cuando la opción "Cotiza tarifa web" y se da click en el boton Aceptar
        /// </summary> 
        private void QuaWebCommandsSend()
        {
            string webQua;
            send = string.Empty;
            webQua = Resources.Constants.COMMANDS_WPNI;
            send = webQua;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }
        }

        #endregion//End rdoQuaWeb



        #region===== rdoPhase35375 =====

        /// <summary>
        /// 
        /// Habilita e inhabilita ciertos controles cuando la 
        /// opción de "Fase 3.5 y 3.75" es seleccionada
        /// </summary>
        private void Phase35375EnableDisableControls()
        {
            txtMoneyCode.Enabled = false;
            txtMoneyCode.BackColor = SystemColors.Control;
            cmbAirline.Text = Resources.Constants.AIRLINE_INITIAL_TEXT;
            cmbAirline.Enabled = false;
            chkBySegments.Checked = false;
            chkBySegments.Enabled = false;
            chkPassPosition.Enabled = true;
            chkPassType.Enabled = true;
            cmbPassType.Enabled = false;
            txtCorporateId.Text = string.Empty;
            txtCorporateId.Enabled = false;
            txtCorporateId.BackColor = SystemColors.Control;
            txtAccountCode.Text = string.Empty;
            txtAccountCode.Enabled = false;
            txtAccountCode.BackColor = SystemColors.Control;
            chkPublic.Enabled = false;
            chkPrivate.Enabled = false;
        }


        /// <summary>
        /// Muestra la mascarilla de "Fase 3.5 y 3.75"
        /// cuando la opción Fase 3.5 y 3.75" y se da click en el boton Aceptar
        /// </summary> 
        private void Phase35375CommandsSend()
        {
            AditionalParametersValues();
            SendInfo = new string[] { passType, passPosition };
            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCPHASE_35375, SendInfo);
        }

        #endregion//end rdoPhase35375


        /// <summary>
        /// Deshabilita o habilita ciertos controles dependiendo
        /// del estado de la opción adicional "Por segmentos" 
        /// </summary> 
        private void BySegmentsEnableDisableControls()
        {
            statusBySegments = chkBySegments.Checked;
            txtSegment1.Enabled = statusBySegments;
            txtSegment2.Enabled = statusBySegments;
            txtSegment3.Enabled = statusBySegments;
            txtSegment4.Enabled = statusBySegments;
            txtSegment5.Enabled = statusBySegments;
            txtSegment6.Enabled = statusBySegments;

            if (statusBySegments)
            {

                txtSegment1.BackColor = Color.White;
                txtSegment2.BackColor = Color.White;
                txtSegment3.BackColor = Color.White;
                txtSegment4.BackColor = Color.White;
                txtSegment5.BackColor = Color.White;
                txtSegment6.BackColor = Color.White;
            }
            else
            {
                txtSegment1.Text = string.Empty;
                txtSegment2.Text = string.Empty;
                txtSegment3.Text = string.Empty;
                txtSegment4.Text = string.Empty;
                txtSegment5.Text = string.Empty;
                txtSegment6.Text = string.Empty;
                txtSegment1.BackColor = SystemColors.Control;
                txtSegment2.BackColor = SystemColors.Control;
                txtSegment3.BackColor = SystemColors.Control;
                txtSegment4.BackColor = SystemColors.Control;
                txtSegment5.BackColor = SystemColors.Control;
                txtSegment6.BackColor = SystemColors.Control;
            }
        }


        /// <summary>
        /// Deshabilita o habilita ciertos controles dependiendo
        /// del estado de la opción adicional "Posición pax" 
        /// </summary> 
        private void PassPositionEnableDisableControls()
        {
            statusPassPosition = chkPassPosition.Checked;
            txtPassenger1.Enabled = statusPassPosition;
            txtPassenger2.Enabled = statusPassPosition;
            txtPassenger3.Enabled = statusPassPosition;
            txtPassenger4.Enabled = statusPassPosition;

            if (statusPassPosition)
            {
                txtPassenger1.BackColor = Color.White;
                txtPassenger2.BackColor = Color.White;
                txtPassenger3.BackColor = Color.White;
                txtPassenger4.BackColor = Color.White;
            }

            if (!statusPassPosition)
            {
                txtPassenger1.Text = string.Empty;
                txtPassenger2.Text = string.Empty;
                txtPassenger3.Text = string.Empty;
                txtPassenger4.Text = string.Empty;
                txtPassenger1.BackColor = SystemColors.Control;
                txtPassenger2.BackColor = SystemColors.Control;
                txtPassenger3.BackColor = SystemColors.Control;
                txtPassenger4.BackColor = SystemColors.Control;
            }
        }


        /// <summary>
        /// Deshabilita o habilita ciertos controles dependiendo
        /// del estado de la opción adicional "Por tarifa o pax" 
        /// </summary> 
        private void PassTypeEnableDisableControls()
        {
            statusPassType = chkPassType.Checked;
            cmbPassType.Text = Resources.Constants.PASSTYPE_INITIAL_TEXT;
            cmbPassType.Enabled = statusPassType;
        }




        /// <summary>
        /// Habilita o deshabilita ciertos controles. Metodo usado
        /// en varias opciones del menu de cotización Aérea
        /// </summary>
        /// <param name="enable">Estado de la opción seleccionada</param>
        private void DisableCommonControls(bool enable)
        {
            if (enable)
            {
                txtMoneyCode.Enabled = false;
                txtMoneyCode.BackColor = SystemColors.Control;
                cmbAirline.Text = Resources.Constants.AIRLINE_INITIAL_TEXT;
                cmbAirline.Enabled = false;
                chkBySegments.Checked = false;
                chkBySegments.Enabled = false;
                chkPassPosition.Checked = false;
                chkPassPosition.Enabled = false;
                chkPassType.Checked = false;
                chkPassType.Enabled = false;
                cmbPassType.Enabled = false;
                txtCorporateId.Text = string.Empty;
                txtCorporateId.Enabled = false;
                txtCorporateId.BackColor = SystemColors.Control;
                txtAccountCode.Text = string.Empty;
                txtAccountCode.Enabled = false;
                txtAccountCode.BackColor = SystemColors.Control;
                chkPublic.Checked = false;
                chkPublic.Enabled = false;
                chkPrivate.Checked = false;
                chkPrivate.Enabled = false;
                chkXC.Enabled = false;
            }


        }


       /// <summary>
       /// Asignación de parametros previos de la mascarilla de Disponibilidad
       /// 
       /// </summary>
        private void UcAvailabilityInfo()
        {
            if (this.Parameters != null)
            {
                loadInfoAvailability = new string[]{this.Parameters[0].ToString(), this.Parameters[1].ToString(),
                this.Parameters[2].ToString(), this.Parameters[3].ToString(), this.Parameters[4].ToString(),
                this.Parameters[5].ToString(), this.Parameters[6].ToString(), this.Parameters[7].ToString(),
                this.Parameters[8].ToString(), this.Parameters[9].ToString(), this.Parameters[10].ToString(),
                this.Parameters[11].ToString(), this.Parameters[12].ToString(), this.Parameters[13].ToString(),
                this.Parameters[14].ToString(), this.Parameters[15].ToString()};
            }
        }


        /// <summary>
        /// Carga de datos provenientes de base de datos del catalogo de 
        /// Aereolíneas en el combobox correspondiente
        /// </summary>
        private void CmbAirlineLoadInfo()
        {
            List<AirLinesFare> listAirlinesFare = AirLinesFareBL.GetAirLinesFare();
            bindingSource1.DataSource = listAirlinesFare;

            foreach (AirLinesFare AirlinesFareItem in listAirlinesFare)
            {
                ListItem litem = new ListItem();
                litem.Text = string.Format("{0} - {1}",
                    AirlinesFareItem.CatAirLinFarId,
                    AirlinesFareItem.CatAirLinFarName);
                litem.Value = AirlinesFareItem.CatAirLinFarId;
                cmbAirline.Items.Add(litem);

            }
        }

               

        #region ===== Commons =====

        /// <summary>
        /// Validaciones de Regla de Negocios de las opciones seleccionadas
        /// </summary>
        /// <returns></returns>
        private bool IsValidBusinessRules
        {
            get
            {
                isValid = true;
                string messageToSend;
                if ((!string.IsNullOrEmpty(txtMoneyCode.Text)) && (txtMoneyCode.Text.Length != 3))
                {
                    MessageBox.Show(Resources.Reservations.COD_MONEDA_DEBE_SER_TRES_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMoneyCode.Focus();
                }
                else if ((chkBySegments.Checked) &&
                    (string.IsNullOrEmpty(txtSegment1.Text)) &&
                    (string.IsNullOrEmpty(txtSegment2.Text)) &&
                    (string.IsNullOrEmpty(txtSegment3.Text)) &&
                    (string.IsNullOrEmpty(txtSegment4.Text)) &&
                    (string.IsNullOrEmpty(txtSegment5.Text)) &&
                    (string.IsNullOrEmpty(txtSegment6.Text)))
                {
                    MessageBox.Show(Resources.Reservations.ING_AL_MENOS_UN_SEGMENTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSegment1.Focus();
                }
                else if ((chkBySegments.Checked) &&
               (string.IsNullOrEmpty(txtSegment1.Text)) &&
               ((!string.IsNullOrEmpty(txtSegment2.Text)) ||
               (!string.IsNullOrEmpty(txtSegment3.Text)) ||
               (!string.IsNullOrEmpty(txtSegment4.Text)) ||
               (!string.IsNullOrEmpty(txtSegment5.Text)) ||
               (!string.IsNullOrEmpty(txtSegment6.Text))))
                {
                    MessageBox.Show(Resources.Reservations.DEBES_ING_PRIMER_SEG_PARA_ING_OTROS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSegment1.Focus();
                }
                else if ((chkPassPosition.Checked) &&
                (string.IsNullOrEmpty(txtPassenger1.Text)) &&
                (string.IsNullOrEmpty(txtPassenger2.Text)) &&
                (string.IsNullOrEmpty(txtPassenger3.Text)) &&
                (string.IsNullOrEmpty(txtPassenger4.Text)))
                {
                    MessageBox.Show(Resources.Reservations.ING_AL_MENOS_UNA_POS_PAS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassenger1.Focus();
                }
                else if ((chkPassPosition.Checked) &&
                (string.IsNullOrEmpty(txtPassenger1.Text)) &&
                ((!string.IsNullOrEmpty(txtPassenger2.Text)) ||
                (!string.IsNullOrEmpty(txtPassenger3.Text)) ||
                (!string.IsNullOrEmpty(txtPassenger4.Text))))
                {
                    messageToSend = string.Format(Resources.Reservations.DEBES_ING_PRIMER_POS_PAS_PARA_ING_OTRO, "\n");
                    MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassenger1.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtPassenger1.Text) && (!ValidateRegularExpression.ValidateOneorTwoPlusDecimalNumber(txtPassenger1.Text))))
                {
                    MessageBox.Show(Resources.Reservations.FORMATO_POSICION_PAX_INCORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassenger1.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtPassenger2.Text) && (!ValidateRegularExpression.ValidateOneorTwoPlusDecimalNumber(txtPassenger2.Text))))
                {
                    MessageBox.Show(Resources.Reservations.FORMATO_POSICION_PAX_INCORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassenger2.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtPassenger3.Text) && (!ValidateRegularExpression.ValidateOneorTwoPlusDecimalNumber(txtPassenger3.Text))))
                {
                    MessageBox.Show(Resources.Reservations.FORMATO_POSICION_PAX_INCORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassenger3.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtPassenger4.Text) && (!ValidateRegularExpression.ValidateOneorTwoPlusDecimalNumber(txtPassenger4.Text))))
                {
                    MessageBox.Show(Resources.Reservations.FORMATO_POSICION_PAX_INCORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassenger4.Focus();
                }
                else if ((chkPassType.Checked) && (cmbPassType.SelectedIndex.Equals(0)))
                {
                    MessageBox.Show(Resources.Reservations.SELECCIONA_TIPO_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbPassType.Focus();
                }
                else if (Regex.IsMatch(cmbPassType.Text, Resources.Constants.IDENT_IDENT_IDENT))
                {
                    MessageBox.Show(Resources.Reservations.SELECCIONA_TIPO_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbPassType.Focus();
                }
                else if ((chkPassType.Checked) &&
                ((chkPublic.Checked)
                || (chkPrivate.Checked)))
                {
                    messageToSend = string.Format(Resources.Reservations.OPCIONES_SELEC_NO_COMBINAN_CON_TARIFA_PUBLICA_O_PRIVADA, "\n");
                    MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chkPassType.Checked = false;
                    if (chkPassType.Checked)
                        chkPassType.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtCorporateId.Text) && (!ValidateRegularExpression.ValidateCorporateIdFormat(txtCorporateId.Text))))
                {
                    messageToSend = string.Format(Resources.Reservations.FORMATO_CORPORATE_ID_NO_ES_CORRECTO, "\n");
                    MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCorporateId.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtCorporateId.Text)) &&
                (!string.IsNullOrEmpty(txtAccountCode.Text)))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_CORPORATE_ID_O_ACCOUNT_CODE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAccountCode.Focus();
                }
                else if ((chkPublic.Checked) && (chkPrivate.Checked))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_TARIFA_PUBLICA_O_PRIVADA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chkPrivate.Checked = false;
                    chkPublic.Checked = false;
                    chkPublic.Focus();
                }
                else
                {
                    isValid = false;
                }

                return isValid;
            }
        }


        /// <summary>
        /// Verificación de posibles errores de MySabre al enviar un comando
        /// </summary>
        private void APIResponse()
        {
            ERR_AirRateMenu.err_AirRateMenu(sabreAnswer);
            if (ERR_AirRateMenu.Status == false)
            {
                
                if ((!ERR_AirRateMenu.Status) && (rdoSaveRate.Checked))
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCADD_DATA_PASSENGER);
            }
            else
            {
                MessageBox.Show(ERR_AirRateMenu.CustomUserMsg, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        /// <summary>
        /// Anexo de parametros adicionales al envio del comando de la opción seleccionada
        /// </summary>
        private void AditionalParametersValues()
        {
            string moneyCode = string.Empty;
            string segment1 = string.Empty; 
            string segment2 = string.Empty; 
            string segment3 = string.Empty; 
            string segment4 = string.Empty; 
            string segment5 = string.Empty; 
            string segment6 = string.Empty; 
            string passenger1 = string.Empty; 
            string passenger2 = string.Empty; 
            string passenger3 = string.Empty; 
            string passenger4 = string.Empty; 
            string corporateId = string.Empty; 
            string accountCode = string.Empty; 
            send = string.Empty;
            bySegments = string.Empty;
            passType = string.Concat(Resources.Constants.COMMANDS_CROSSLORAINE_P,
                passTypeV);
            corporateId = string.Concat(Resources.Constants.COMMANDS_CROSSLORAINE_I,
                txtCorporateId.Text);
            accountCode = string.Concat(Resources.Constants.COMMANDS_CROSSLORAINE_AC_AST,
                txtAccountCode.Text);
            if (string.IsNullOrEmpty(txtMoneyCode.Text))
            {
                money = string.Empty;
            }
            else
            {
                string[] arrMoneyCode = txtMoneyCode.Text.Split(new char[] {Convert.ToChar(Resources.Constants.INDENT)});
                moneyCode = arrMoneyCode[0];
                money = string.Concat(Resources.Constants.COMMANDS_M,
                    moneyCode);
            }

            if ((cmbAirline.Text.Equals(Resources.Constants.AIRLINE_INITIAL_TEXT)) ||
                    (string.IsNullOrEmpty(cmbAirline.Text)) || (cmbAirline.SelectedIndex == 0))
            {
                airline = string.Empty;

            }
            else
            {
                ListItem item = (ListItem)cmbAirline.SelectedItem;
                airline = string.Concat(Resources.Constants.COMMANDS_CROSSLORAINE_A,
                    item.Value);
            }
            if (!string.IsNullOrEmpty(txtSegment2.Text))
            {
                segment2 = string.Concat(Resources.Constants.INDENT,
                    txtSegment2.Text);
            }
            else
            {
                segment2 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtSegment3.Text))
            {
                segment3 = string.Concat(Resources.Constants.SLASH,
                    txtSegment3.Text);
            }
            else
            {
                segment3 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtSegment4.Text))
            {
                segment4 = string.Concat(Resources.Constants.SLASH,
                    txtSegment4.Text);
            }
            else
            {
                segment4 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtSegment5.Text))
            {
                segment5 = string.Concat(Resources.Constants.SLASH,
                    txtSegment5.Text);
            }
            else
            {
                segment5 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtSegment6.Text))
            {
                segment6 = string.Concat(Resources.Constants.SLASH,
                    txtSegment6.Text);
            }
            else
            {
                segment6 = string.Empty;
            }
            segment1 = txtSegment1.Text;
            bySegments = string.Concat(Resources.Constants.COMMANDS_CROSSLORAINE_S,
            segment1,
            segment2,
            segment3,
            segment4,
            segment5,
            segment6);
            if (chkBySegments.Checked == false)
            {
                bySegments = string.Empty;
            }

            if (!string.IsNullOrEmpty(txtPassenger2.Text))
            {
                passenger2 = string.Concat(Resources.Constants.INDENT,
                    txtPassenger2.Text);
            }
            else
            {
                passenger2 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtPassenger3.Text))
            {
                passenger3 = string.Concat(Resources.Constants.SLASH,
                    txtPassenger3.Text);
            }
            else
            {
                passenger3 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtPassenger4.Text))
            {
                passenger4 = string.Concat(Resources.Constants.SLASH,
                    txtPassenger4.Text);
            }
            else
            {
                passenger4 = string.Empty;
            }
            passenger1 = txtPassenger1.Text;
            passPosition = string.Concat(Resources.Constants.COMMANDS_CROSSLORAINE_N,
            passenger1,
            passenger2,
            passenger3,
            passenger4);
            if (chkPassPosition.Checked == false)
            {
                passPosition = string.Empty;
            }

            if (chkPassType.Checked == false)
            {
                passType = string.Empty;
            }

            if ((!string.IsNullOrEmpty(txtCorporateId.Text)) &&
                (string.IsNullOrEmpty(txtAccountCode.Text)))
            {
                codeOrId = string.Concat(Resources.Constants.COMMANDS_CROSSLORAINE_I,
                    txtCorporateId.Text);
            }
            else if ((string.IsNullOrEmpty(txtCorporateId.Text)) &&
                (!string.IsNullOrEmpty(txtAccountCode.Text)))
            {
                codeOrId = string.Concat(Resources.Constants.COMMANDS_CROSSLORAINE_AC_AST,
                    txtAccountCode.Text);
            }
            else if ((string.IsNullOrEmpty(txtCorporateId.Text)) &&
                (string.IsNullOrEmpty(txtAccountCode.Text)))
            {
                codeOrId = string.Empty;
            }
            if (txtCorporateId.Text == string.Empty)
            {
                corporateId = string.Empty;
            }
            if (txtAccountCode.Text == string.Empty)
            {
                accountCode = string.Empty;
            }

            if (chkPublic.Checked)
            {
                quarrelType = Resources.Constants.COMMANDS_CROSSLORAINE_PL;
            }
            else if (chkPrivate.Checked)
            {
                quarrelType = Resources.Constants.COMMANDS_CROSSLORAINE_PV;
            }
            else if ((!chkPublic.Checked) &&
           (!chkPrivate.Checked))
            {
                quarrelType = string.Empty;
            }
           
        }

        #endregion // End Commons


        #endregion //End MethodsClass



        #region===== Enable Disable Controls =====

        //Evento rdoSellOtherFly_CheckedChanged
        private void rdoSellOtherFly_CheckedChanged(object sender, EventArgs e)
        {
            SellOtherFlyEnableDisableControls();
        }


        //Evento rdoQuoItinerary_CheckedChanged
        private void rdoQuoItinerary_CheckedChanged(object sender, EventArgs e)
        {
            QuoItineraryEnableDisableControls();
        }


        //Evento rdoSaveRate_CheckedChanged
        private void rdoSaveRate_CheckedChanged(object sender, EventArgs e)
        {
            SaveRateEnableDisableControls();
        }

        //Evento rdoQuoCheapBut_CheckedChanged
        private void rdoQuoCheapBut_CheckedChanged(object sender, EventArgs e)
        {
            QuoCheapButEnableDisableControls();
        }


        //Evento rdoQuoCheapNonavailable_CheckedChanged
        private void rdoQuoCheapNonavailable_CheckedChanged(object sender, EventArgs e)
        {
            QuoCheapNonavailableEnableDisableControls();
        }


        //Evento rdoChangeToMostCheap_CheckedChanged
        private void rdoChangeToMostCheap_CheckedChanged(object sender, EventArgs e)
        {
            ChangeToMostCheapEnableDisableControls();
        }


        //Evento rdoSearchFlights_CheckedChanged
        private void rdoSearchFlights_CheckedChanged(object sender, EventArgs e)
        {
            SearchFlightsEnableDisableControls();
        }


        //Evento rdoManualRate_CheckedChanged
        private void rdoManualRate_CheckedChanged(object sender, EventArgs e)
        {
            ManualRateEnableDisableControls();
        }


        //Evento rdoRateOptions_CheckedChanged
        private void rdoRateOptions_CheckedChanged(object sender, EventArgs e)
        {
            RateOptionsEnableDisableControls();
        }


        //Evento rdoBuildQuaDisplayed_CheckedChanged
        private void rdoBuildQuaDisplayed_CheckedChanged(object sender, EventArgs e)
        {
            BuilQuaDisplayedEnableDisableControls();
        }


        //Evento rdoQuaWeb_CheckedChanged
        private void rdoQuaWeb_CheckedChanged(object sender, EventArgs e)
        {
            QuaWebEnableDisableControls();
        }


        //Evento rdoPhase35375_CheckedChanged
        private void rdoPhase35375_CheckedChanged(object sender, EventArgs e)
        {
            Phase35375EnableDisableControls();

        }


        //Evento chkBySegments_CheckedChanged
        private void chkBySegments_CheckedChanged(object sender, EventArgs e)
        {
            BySegmentsEnableDisableControls();
        }


        //Evento chkPassPosition_CheckedChanged
        private void chkPassPosition_CheckedChanged(object sender, EventArgs e)
        {
            PassPositionEnableDisableControls();
        }


        //Evento chkPassType_CheckedChanged
        private void chkPassType_CheckedChanged(object sender, EventArgs e)
        {
            PassTypeEnableDisableControls();
        }




        #endregion// End Enable Disable Controls



        #region===== ComboBox select index values =====

        /// <summary>
        /// Asigna el valor del código de tarifa o pasajero a la 
        /// variable PassTypeV
        /// </summary>
        /// <param name="sender">cmbPassType</param>
        /// <param name="e"></param>
        private void cmbPassType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            passTypeST = cmbPassType.Text;
            passTypeS = passTypeST.Substring(0, 3);
            passTypeV = passTypeS;
        }


        #endregion



        #region===== Change Focus when a Textbox is Full =====

        //Evento txtMoneyCode_TextChanged
        private void txtMoneyCode_TextChanged(object sender, EventArgs e)
        {
            txt = (TextBox)sender;
            Common.SetListBoxCurrenciesCountries(txt, lbMoneyCode);
        }

        //Evento txtSegment1_TextChanged
        private void txtSegment1_TextChanged(object sender, EventArgs e)
        {
            if (txtSegment1.Text.Length > 1)
            {
                txtSegment2.Focus();
            }
        }

        //Evento txtSegment2_TextChanged
        private void txtSegment2_TextChanged(object sender, EventArgs e)
        {
            if (txtSegment2.Text.Length > 1)
            {
                txtSegment3.Focus();
            }
        }

        //Evento txtSegment3_TextChanged
        private void txtSegment3_TextChanged(object sender, EventArgs e)
        {
            if (txtSegment3.Text.Length > 1)
            {
                txtSegment4.Focus();
            }
        }

        //Evento txtSegment4_TextChanged
        private void txtSegment4_TextChanged(object sender, EventArgs e)
        {
            if (txtSegment4.Text.Length > 1)
            {
                txtSegment5.Focus();
            }
        }

        //Evento txtSegment5_TextChanged
        private void txtSegment5_TextChanged(object sender, EventArgs e)
        {
            if (txtSegment5.Text.Length > 1)
            {
                txtSegment6.Focus();
            }
        }

        //Evento txtSegment6_TextChanged
        private void txtSegment6_TextChanged(object sender, EventArgs e)
        {
            if (txtSegment6.Text.Length > 1)
            {
                chkPassPosition.Focus();
            }
        }

        //Evento txtPassenger1_TextChanged
        private void txtPassenger1_TextChanged(object sender, EventArgs e)
        {
            if (txtPassenger1.Text.Length > 3)
            {
                txtPassenger2.Focus();
            }
        }

        //Evento txtPassenger2_TextChanged
        private void txtPassenger2_TextChanged(object sender, EventArgs e)
        {
            if (txtPassenger2.Text.Length > 3)
            {
                txtPassenger3.Focus();
            }
        }

        //Evento txtPassenger3_TextChanged
        private void txtPassenger3_TextChanged(object sender, EventArgs e)
        {
            if (txtPassenger3.Text.Length > 3)
            {
                txtPassenger4.Focus();
            }
        }

        //Evento txtPassenger4_TextChanged
        private void txtPassenger4_TextChanged(object sender, EventArgs e)
        {
            if (txtPassenger4.Text.Length > 3)
            {
                chkPassType.Focus();
            }

        }

        //Evento txtCorporateId_TextChanged
        private void txtCorporateId_TextChanged(object sender, EventArgs e)
        {
            if (txtCorporateId.Text.Length > 4)
            {
                txtAccountCode.Focus();
            }

        }

        //Evento txtAccountCode_TextChanged
        private void txtAccountCode_TextChanged(object sender, EventArgs e)
        {
            if (txtAccountCode.Text.Length > 14)
            {
                chkPublic.Focus();
            }

        }

        #endregion//End Enable Disable Controls



        #region ===== Back to a Previous Usercontrol or Validate Enter KeyDown =====

        /// <summary>
        /// Cambio de mascarilla o cancelacion de proceso al presionar la tecla
        /// ESC o ejecutar la instrucción al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData.Equals(Keys.Escape))
            {
                if (ucMenuReservations.AirRateFlag.Equals(1))
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
                else
                {
                    Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCAVAILABILITY, loadInfoAvailability);
                }

            }
            if (e.KeyData.Equals(Keys.Enter))
            {

                btn1_Click(sender, e);
            }

        }
        #endregion//End Back to a Previous Usercontrol or Validate Enter KeyDown



        #region===== lbMoneyCode Events =====


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
        /// cuando el txtmoneyCode tiene el foco
        /// </summary>
        /// <param name="sender">txtmoneyCode</param>
        /// <param name="e"></param>
        private void moneyCodeActions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            if (e.KeyData.Equals(Keys.Enter))
            {
                btn1_Click(sender, e);
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
        /// Escode el listbox al perder el foco
        /// </summary>
        /// <param name="sender">lbMoneyCode</param>
        /// <param name="e"></param>
        private void txtMoneyCodeControl_Leave(object sender, EventArgs e)
        {
            lbMoneyCode.Visible = false;
        }


        /// <summary>
        /// Selecciona algún elemento dentro de lbMoneyCode al hacer un click
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
        #endregion//End lbMoneyCode Events


        public static bool ReturnForMisc = false;


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                ReturnForMisc = false;
                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCAVAILABILITY, loadInfoAvailability);
                //Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCSELL_AIR_SEGMENT);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


    }
}

