using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Forms.UI;
using MyCTS.Services;
using MyCTS.Services.Contracts;

namespace MyCTS.Presentation
{
    public partial class ucDefinitionTargetElements2 : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Ingresa de los targets para la nueva 
        /// regla de cargo por servicio por corporativo
        /// Creación:    Marzo 2010 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Angel Trejo
        /// </summary>
        public ucDefinitionTargetElements2()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = cmbOriginOfSale;
            this.LastControlFocus = btnAccept;
        }

        #region ===== Global Variables =====

        public static bool emissionTicket = false;
        private TextBox txt;
        private bool statusParamReceived;
        private List<Targets> ListTargetsRules = null;
        private class Targets
        {
            public int IDTE;
            public string Value2;
        }

        #endregion // Global Variables           

        private void ucDefinitionTargetElements2_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            HideListboxControls();
            LoadSaleOrigin();
            LoadBussinesUnit();
            cmbOriginOfSale.SelectedIndex = 0;
            cmbPayForm.SelectedIndex = 0;
            cmbOperativeUnit.SelectedIndex = 0;
            cmbOriginOfSale.Focus();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if(IsValidBussinesRules)
                AddTargets();
        }

        #region ====== METHODS CLASS ======

        /// <summary>
        /// Carga los valores del catalogo origen de la venta
        /// </summary>
        private void LoadSaleOrigin()
        {
            List<CatOriginSales> OriginSales = CatOriginSalesBL.GetOriginSales();
            cmbOriginOfSale.DisplayMember = Resources.Constants.TEXT;
            cmbOriginOfSale.ValueMember = Resources.Constants.VALUE;

            foreach (CatOriginSales originSalesItem in OriginSales)
            {
                ListItem litem = new ListItem();
                litem.Text = originSalesItem.Text2;
                litem.Value = originSalesItem.Values;
                cmbOriginOfSale.Items.Add(litem);
            }

        }

        /// <summary>
        /// Carga los valores del catalogo de unidad operativa
        /// </summary>
        private void LoadBussinesUnit()
        {
            List<CatBusinessUnits> BusinessUnits = CatBusinessUnitsBL.GetBusinessUnits();
            cmbOperativeUnit.DisplayMember = Resources.Constants.TEXT;
            cmbOperativeUnit.ValueMember = Resources.Constants.VALUE;
            foreach (CatBusinessUnits businnesUnitItem in BusinessUnits)
            {
                ListItem litem = new ListItem();
                litem.Text = string.Format("{0} {1} {2}",
                    businnesUnitItem.IDIntegra,
                    Resources.TicketEmission.Constants.INDENT,
                    businnesUnitItem.Name);
                litem.Value = string.Concat(businnesUnitItem.IDBusinessUnits,
                    Resources.TicketEmission.Constants.INDENT,
                    businnesUnitItem.IDIntegra);
                cmbOperativeUnit.Items.Add(litem);
            }
        }

        /// <summary>
        /// No permite el despliegue de predictivo cuando se
        /// carga la mascarilla
        /// </summary>
        private void HideListboxControls()
        {
            statusParamReceived = false;
        }

        /// <summary>
        /// Valida las reglas del negocio aplicadas a este user control
        /// </summary>
        private bool IsValidBussinesRules
        {
            get
            {
                bool isValid = false;
                if (!string.IsNullOrEmpty(txtAirline.Text) && txtAirline.TextLength != 2)
                {
                    MessageBox.Show("EL CÓDIGO DE AEROLINEA DEBE SER DE 2 CARACTERES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirline.Focus();
                }
                else if (!string.IsNullOrEmpty(txtFareType.Text) && !(txtFareType.TextLength >= 2 && txtFareType.TextLength <= 4))
                {
                    MessageBox.Show("EL TIPO DE TARIFA DEBE SER DE 2 A 4 CARACTERES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFareType.Focus();
                }
                else if (!string.IsNullOrEmpty(txtBaseFare.Text) && string.IsNullOrEmpty(txtBaseFare2.Text))
                {
                    MessageBox.Show("DEBE INGRESAR EL MONTO DE LIMITE FINAL DE LA TARIFA BASE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBaseFare2.Focus();
                }
                else if (!string.IsNullOrEmpty(txtBaseFare2.Text) && string.IsNullOrEmpty(txtBaseFare.Text))
                {
                    MessageBox.Show("DEBE INGRESAR EL MONTO DE LIMITE INICIAL DE LA TARIFA BASE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBaseFare.Focus();
                }
                else if (!string.IsNullOrEmpty(txtBaseFare2.Text) && !string.IsNullOrEmpty(txtBaseFare.Text)
                    && Convert.ToDouble(txtBaseFare.Text) > Convert.ToDouble(txtBaseFare2.Text))
                {
                    MessageBox.Show("EL MONTO DE LIMITE INICIAL DEBE SER MENOR AL MONTO DE LIMITE FINAL", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBaseFare.Focus();
                }
                else if (!string.IsNullOrEmpty(txtHora1.Text) && string.IsNullOrEmpty(txtHora2.Text))
                {
                    MessageBox.Show("DEBE INGRESAR LA HORA DE FIN DE LA REGLA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtHora2.Focus();
                }
                else if (!string.IsNullOrEmpty(txtHora2.Text) && string.IsNullOrEmpty(txtHora1.Text))
                {
                    MessageBox.Show("DEBE INGRESAR LA HORA DE FIN DE LA REGLA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtHora1.Focus();
                }
                else if (!string.IsNullOrEmpty(txtHora1.Text) &&
                    !ValidateTime(txtHora1.Text))
                {
                    MessageBox.Show("EL FORMATO DE LA HORA DE INICIO ES INCORRECTO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtHora1.Focus();
                }
                else if (!string.IsNullOrEmpty(txtHora2.Text) &&
                    !ValidateTime(txtHora2.Text))
                {
                    MessageBox.Show("EL FORMATO DE LA HORA FINAL ES INCORRECTO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtHora2.Focus();
                }
                else
                    isValid = true;
                return isValid;
            }
        }

        /// <summary>
        /// Valida que se ingrese una hora valida
        /// </summary>
        /// <param name="time">Hora que se valida</param>
        /// <returns>Status de la validación</returns>
        private bool ValidateTime(string time)
        {
            try
            {
                DateTime aux = Convert.ToDateTime(time);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Agrega una nueva regla de cargo por servicio y sus targets 
        /// correspondientes
        /// </summary>
        private void AddTargets()
        {
            ListTargetsRules = new List<Targets>();
            foreach (Control txt in this.Controls)
            {
                if (txt is SmartTextBox && !string.IsNullOrEmpty(txt.Text) &&
                    !(txt.TabIndex.Equals(22)||txt.TabIndex.Equals(23) || txt.TabIndex.Equals(17)))
                {
                    Targets t = new Targets();
                    t.IDTE = txt.TabIndex;
                    t.Value2 = txt.Text;
                    ListTargetsRules.Add(t);

                }
            }
            if (cmbOriginOfSale.SelectedIndex > 0)
            {
                Targets t = new Targets();
                t.IDTE = cmbOriginOfSale.TabIndex;
                t.Value2 = Convert.ToString(cmbOriginOfSale.Text);
                ListTargetsRules.Add(t);
            }

            if (cmbOperativeUnit.SelectedIndex > 0)
            {
                Targets t = new Targets();
                t.IDTE = 23;
                t.Value2 = Convert.ToString(cmbOperativeUnit.Text);
                ListTargetsRules.Add(t);
            }
            if (cmbPayForm.SelectedIndex > 0)
            {
                Targets t = new Targets();
                t.IDTE = cmbPayForm.TabIndex;
                t.Value2 = Convert.ToString(cmbPayForm.SelectedItem);
                ListTargetsRules.Add(t);
            }
            if (!string.IsNullOrEmpty(txtHora1.Text) && !string.IsNullOrEmpty(txtHora2.Text))
            {
                Targets t1 = new Targets();
                t1.IDTE = 22;
                t1.Value2 = string.Concat(txtHora1.Text, " - ", txtHora2.Text);
                ListTargetsRules.Add(t1);
            }

            if (!string.IsNullOrEmpty(txtBaseFare2.Text) && !string.IsNullOrEmpty(txtBaseFare.Text))
            {
                Targets t17 = new Targets();
                t17.IDTE = 17;
                t17.Value2 = string.Concat(txtBaseFare.Text, " a ", txtBaseFare2.Text);
                ListTargetsRules.Add(t17);
            }

           
            string corp = string.Empty;
            string descripcion = string.Empty;
            string extendDescripcion = string.Empty;
            string porcentaje = string.Empty;
            string cantidad =string.Empty;
            string priority = string.Empty;
            string fechaInicio = string.Empty;
            string fechaFin = string.Empty;
            int numberRule = 0;
            for(int i =0; i<ucNewFeeRule.Criterios.Count; i++)
            {
                if(ucNewFeeRule.Criterios[i].numberCritery==1)
                    corp=ucNewFeeRule.Criterios[i].criterio;
                else if(ucNewFeeRule.Criterios[i].numberCritery==2)
                    descripcion=ucNewFeeRule.Criterios[i].criterio;
                else if(ucNewFeeRule.Criterios[i].numberCritery==3)
                    extendDescripcion=ucNewFeeRule.Criterios[i].criterio;
                else if(ucNewFeeRule.Criterios[i].numberCritery==4)
                    porcentaje=ucNewFeeRule.Criterios[i].criterio;
                else if(ucNewFeeRule.Criterios[i].numberCritery==5)
                    cantidad=ucNewFeeRule.Criterios[i].criterio;
                else if(ucNewFeeRule.Criterios[i].numberCritery==6)
                    priority=ucNewFeeRule.Criterios[i].criterio;
                else if(ucNewFeeRule.Criterios[i].numberCritery==7)
                    fechaInicio= ucNewFeeRule.Criterios[i].criterio;
                else if (ucNewFeeRule.Criterios[i].numberCritery==8)
                    fechaFin = ucNewFeeRule.Criterios[i].criterio;
            }
            DialogResult yesNo = MessageBox.Show("¿SEGURO QUE DESEA CREAR ESTA NUEVA REGLA PARA EL CORPORATIVO " + corp + "?", Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (yesNo.Equals(DialogResult.Yes))
            {
                if (!string.IsNullOrEmpty(ucNewFeeRule.Attribute1))
                    UpdatePriorityByAttribute1BL.UpdatePriorities(ucNewFeeRule.NewPriority, ucNewFeeRule.Attribute1);
                List<SetNewFeeRule> ListNumberRule = new List<SetNewFeeRule>();
                ListNumberRule = NewFeeRuleBL.SetNewFeeRule(corp, Convert.ToInt32(priority), descripcion, extendDescripcion,
                    (!string.IsNullOrEmpty(porcentaje)) ? Convert.ToDecimal(porcentaje) : 0, (!string.IsNullOrEmpty(cantidad)) ? Convert.ToDecimal(cantidad) : 0,
                    (ucNewFeeRule.MontoFijo) ? true : false, false, fechaInicio, fechaFin, Login.Agent);
                if (ListNumberRule.Count > 0)
                {
                    numberRule = ListNumberRule[0].IDRuleNumber;
                    if (ucDefinitionTargetElements.ListTargetsRules != null)
                        for (int i = 0; i < ucDefinitionTargetElements.ListTargetsRules.Count; i++)
                        {
                            if (ucDefinitionTargetElements.ListTargetsRules[i].IDTE == 3 ||
                                ucDefinitionTargetElements.ListTargetsRules[i].IDTE == 8)
                                ucDefinitionTargetElements.ListTargetsRules[i].Value2 = BuildDate(ucDefinitionTargetElements.ListTargetsRules[i].Value2);
                            SetNewTargetFeeRuleBL.AddNewTargetFeeRule(numberRule, ucDefinitionTargetElements.ListTargetsRules[i].IDTE,
                                ucDefinitionTargetElements.ListTargetsRules[i].Value2);
                        }
                    if (ListTargetsRules != null)
                        for (int j = 0; j < ListTargetsRules.Count; j++)
                            SetNewTargetFeeRuleBL.AddNewTargetFeeRule(numberRule, ListTargetsRules[j].IDTE,
                                ListTargetsRules[j].Value2);
                    if (!string.IsNullOrEmpty(ucDefinitionTargetElements.LocationDKNotAccepted))
                        SetLocationDKNotAcceptedBL.SetLocationDKNotAccepted(numberRule, ucDefinitionTargetElements.LocationDKNotAccepted);
                }

                ucDefinitionTargetElements.PaxNum = 0;
                ucNewFeeRule.Criterios.Clear();
                ucDefinitionTargetElements.ListTargetsRules.Clear();
                ucNewFeeRule.listAttribute1.Clear();
                ListTargetsRules.Clear();
                
                //GetMailByUser userMail = GetMailByUserBL.GetMail(Login.Agent);
                Parameter mailToValidate = ParameterBL.GetParameterValue("MailToValidateFeeRule");
                Parameter mailToSend = ParameterBL.GetParameterValue("MailThatSendFeeRule");
                Parameter mailPassword = ParameterBL.GetParameterValue("PasswordThatMailToSend");
                Parameter ccMailToValidate = ParameterBL.GetParameterValue("CC-MailToValidateFeeRule");
                Parameter displyName = ParameterBL.GetParameterValue("NameSendEmail");
                string body = string.Concat("Solicitud de Activación de Nueva Regla - Cargo por Servicio\n\n",
                    "Número de regla:  ", numberRule, "\n",
                    "Nombre:           ", descripcion, "\n",
                    "Solicitado por:  	", Login.Agent, " (", Login.NombreCompleto, ")", "\n",
                    "Corporativo:   	", corp, "\n",
                    "Fecha Sol.:    	", Convert.ToString(DateTime.Now).Substring(0, 10), "\n",
                    "Prioridad:        ", priority, "\n");
                List<GetInformationRuleApplied> listInfoRule = GetInformationRuleAppliedBL.GetInfoRule(numberRule, true);
                string targets = string.Empty;

                targets = "Los criterios para aplicación de la regla son los siguientes:\n\n";
                targets = string.Concat(targets, " -", "Porcentaje de la Tarifa Base: ".ToUpper().PadRight(35, ' '), (string.IsNullOrEmpty(porcentaje)) ? "0" : porcentaje, "\n\n");
                targets = string.Concat(targets, " -", "Cantidad fija: ".ToUpper().PadRight(35, ' '), "$", (string.IsNullOrEmpty(cantidad)) ? "0.00" : Convert.ToDecimal(cantidad).ToString("0.00"), "\n\n");
                targets = string.Concat(targets, " -", "Monto: ".ToUpper().PadRight(35, ' '), (ucNewFeeRule.MontoFijo) ? "No Negociable" : "Negociable", "\n\n");
                ucNewFeeRule.MontoFijo = false;
                if (!string.IsNullOrEmpty(fechaInicio))
                    targets = string.Concat(targets, " -", "Fecha de Inicio de la Regla: ".ToUpper().PadRight(35, ' '), fechaInicio, "\n\n");
                if (!string.IsNullOrEmpty(fechaFin))
                    targets = string.Concat(targets, " -", "Fecha de Expiración de la Regla: ".ToUpper().PadRight(35, ' '), fechaFin, "\n\n");
                for (int i = 0; i < listInfoRule.Count; i++)
                    targets = string.Concat(targets, " -", string.Concat(listInfoRule[i].Target, ": ").ToUpper().PadRight(35, ' '), listInfoRule[i].Value2, "\n\n");
                if (!string.IsNullOrEmpty(ucDefinitionTargetElements.LocationDKNotAccepted))
                    targets = string.Concat(targets, " -", "Location(DK) Excluyente: ".ToUpper().PadRight(35, ' '), ucDefinitionTargetElements.LocationDKNotAccepted, "\n\n");
                ucDefinitionTargetElements.LocationDKNotAccepted = string.Empty;
                body = string.Concat(body, "\n", targets);

                body = string.Concat(body, "\nFavor de evaluar dicha regla y activarla si es conveniente.");
                try
                {
                    SendMailAync(mailToSend.Values, mailPassword.Values, displyName.Values, mailToValidate.Values,
                            ccMailToValidate.Values, "Nueva regla de cargo por servicio", body);
                    SendMailAync(mailToSend.Values, mailPassword.Values, displyName.Values, Login.Mail, "", "Solucitud Nueva Regla Cargo por Servicio",
                        "Hola " + Login.NombreCompleto + "\n\nMyCTS te da las gracias por haber creado una nueva regla de Cargo por Servicio, " +
                        "te informamos que dicha regla fue creada con éxito con el número de regla " + numberRule + " para el corporativo " + corp +
                        "\n\nUna vez que sea evaluada por la Dirección de Operaciones estará disponible para su uso." +
                        "\n\nGracias");
                }
                catch { }
                MessageBox.Show("LA REGLA " + numberRule + " DE CARGO POR SERVICIO SE CREO CON EXITO, Y SE ENCUENTRA INACTIVA\n" +
                                "HASTA QUE SEA SUJETA A AUTORIZACIÓN POR LA DIRECIÓN DE OPERACIONES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (ucNewFeeRule.LoadUserWelcome)
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                else
                {
                  Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_TICKETEMISSION_CONFIRMATION);
                }
            }
            else
                cmbOriginOfSale.Focus();
 
        }
        
        /// <summary>
        /// Método asincrono que envía correo electrónico
        /// </summary>
        /// <param name="mailToSend">Direccion email de quien envía el correo</param>
        /// <param name="psw">Password de quien envía el correo</param>
        /// <param name="diplayName">Nombre de quien envia el correo</param>
        /// <param name="mailToValidate">Direcciones de email a quienes se les envia el correo</param>
        /// <param name="mailCC">Direcciones de email a quienes se les envia el correo con copia</param>
        /// <param name="subject">Asunto del correo</param>
        /// <param name="body">Texto que se envia el correo</param>
        private delegate void SendEmail(string mailToSend, string psw, string diplayName, string mailToValidate,
            string mailCC, string subject, string body);
        /// <summary>
        /// Método asincrono que envía correo electrónico
        /// </summary>
        /// <param name="mailToSend">Direccion email de quien envía el correo</param>
        /// <param name="psw">Password de quien envía el correo</param>
        /// <param name="diplayName">Nombre de quien envia el correo</param>
        /// <param name="mailToValidate">Direcciones de email a quienes se les envia el correo</param>
        /// <param name="mailCC">Direcciones de email a quienes se les envia el correo con copia</param>
        /// <param name="subject">Asunto del correo</param>
        /// <param name="body">Texto que se envia el correo</param>
        private void SendMailAync(string mailToSend, string psw, string diplayName, string mailToValidate,
            string mailCC, string subject, string body)
        {
            SendEmail se = new SendEmail(SendMail2);
            se.BeginInvoke(mailToSend, psw, diplayName, mailToValidate, mailCC, subject, body, null, null);
        }

        /// <summary>
        /// Método que envía correo electrónico
        /// </summary>
        /// <param name="mailToSend">Direccion email de quien envía el correo</param>
        /// <param name="psw">Password de quien envía el correo</param>
        /// <param name="diplayName">Nombre de quien envia el correo</param>
        /// <param name="mailToValidate">Direcciones de email a quienes se les envia el correo</param>
        /// <param name="mailCC">Direcciones de email a quienes se les envia el correo con copia</param>
        /// <param name="subject">Asunto del correo</param>
        /// <param name="body">Texto que se envia el correo</param>
        private void SendMail2(string mailToSend, string psw, string diplayName, string mailToValidate,
            string mailCC, string subject, string body)
        {
            try
            {
                MailProvider ws = new MailProvider();
                ws.SendEmail2(mailToSend, psw, diplayName, mailToValidate, mailCC, subject, body);
            }
            catch { }
        }

        /// <summary>
        /// Contruye la fecha en el formato que se requiere para ser evaluada
        /// </summary>
        /// <param name="fecha">Fecha a ser convertida</param>
        /// <returns>Fecha en el formato requerido</returns>
        private string BuildDate(string fecha)
        {
            DateTime auxi = new DateTime();
            auxi = Convert.ToDateTime(fecha);
            string month = (auxi.Month < 10) ? string.Concat("0", Convert.ToString(auxi.Month)) : Convert.ToString(auxi.Month);
            string fechaConvert = string.Concat(fecha.Substring(0, 2), "/", month, "/", auxi.Year);
            return fechaConvert;
        }

        #endregion //METHODS CLASS

        #region ======Back to a Previous Usercontrol or Validate Enter KeyDown=====

        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData.Equals(Keys.Escape))
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCDEFINITIONTARGETELEMENTS);
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

        #region =====PREDICTIVS=====

        private void txtAirline_TextChanged(object sender, EventArgs e)
        {
            if (!statusParamReceived)
            {
                txt = (TextBox)sender;
                Common.SetListBoxAirlines(txt, lbAirline);
            }
        }


        private void txtFareType_TextChanged(object sender, EventArgs e)
        {
            if (!statusParamReceived)
            {
                txt = (TextBox)sender;
                Common.SetListBoxFareType(txt, lbFareType);
            }
        }

        private void txtPCC_TextChanged(object sender, EventArgs e)
        {
            if (!statusParamReceived)
            {
                txt = (TextBox)sender;
                Common.SetListBoxPCCs(txt, lbPCCs);
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
        /// Asignación de acciones al presionar la tecla ENTER o ESC 
        /// cuando el lbFareType tiene el foco
        /// </summary>
        /// <param name="sender">lbFareType</param>
        /// <param name="e"></param>
        private void lbFareType_KeyDown(object sender, KeyEventArgs e)
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
                lbFareType.Visible = false;
                txt.Focus();
            }

        }

        /// <summary>
        /// Asignación de acciones al presionar la tecla ENTER o ESC 
        /// cuando el lbPCCs tiene el foco
        /// </summary>
        /// <param name="sender">lbPCCs</param>
        /// <param name="e"></param>
        private void lbPCCs_KeyDown(object sender, KeyEventArgs e)
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
                lbPCCs.Visible = false;
                txt.Focus();
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
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCDEFINITIONTARGETELEMENTS);
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
        /// Asignacion de acciones al presionar la tecla ENTER, ESC o DOWN
        /// cuando algún txt de aereolínea tiene el foco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FareTypeActions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCDEFINITIONTARGETELEMENTS);
            }
            if (e.KeyData == Keys.Enter)
            {
                btnAccept_Click(sender, e);
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lbFareType.Items.Count > 0)
                {
                    lbFareType.SelectedIndex = 0;
                    lbFareType.Focus();
                    lbFareType.Visible = true;
                    lbFareType.Focus();
                }
            }

        }


        /// <summary>
        /// Asignacion de acciones al presionar la tecla ENTER, ESC o DOWN
        /// cuando algún txt de PCC's tiene el foco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PCCActions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCDEFINITIONTARGETELEMENTS);
            }
            if (e.KeyData == Keys.Enter)
            {
                btnAccept_Click(sender, e);
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lbPCCs.Items.Count > 0)
                {
                    lbPCCs.SelectedIndex = 0;
                    lbPCCs.Focus();
                    lbPCCs.Visible = true;
                    lbPCCs.Focus();
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

        #endregion //PREDICTIVS       

    }
}
