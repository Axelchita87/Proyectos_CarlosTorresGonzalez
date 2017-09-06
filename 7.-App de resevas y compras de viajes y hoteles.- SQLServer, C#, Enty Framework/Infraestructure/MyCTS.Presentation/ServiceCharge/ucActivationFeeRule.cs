using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Components.NullableHelper;
using MyCTS.Services.Contracts;


namespace MyCTS.Presentation
{
    public partial class ucActivationFeeRule : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Activación de las reglas de cargo por servicio
        /// Creación:    Marzo 2010 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Angel Trejo
        /// </summary>
        public ucActivationFeeRule()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtRuleNumber;
            this.LastControlFocus = btnAccept;
        }
        private bool statusButtons = false;
        private string attribute1 = string.Empty;
        private string agent = string.Empty;
        private string corp = string.Empty;
        private int aux = 0;
        private List<GetInformationRuleApplied> listInformationRule = null;
        private List<SetLocationDKNotAccepted> listLocationDK = null;
        List<GetInfoFeeRuleByAttribute1> listInfoFeeRule = null;
        private void ucActivationFeeRule_Load(object sender, EventArgs e)
        {
            txtRuleNumber.Focus();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRuleNumber.Text))
            {
                MessageBox.Show("DEBE INGRESAR EL NÚMERO DE REGLA DE CARGO POR SERVICIO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRuleNumber.Focus();
            }
            else
                ShowInformation();
        }

        #region ====== Methods Class ======

        /// <summary>
        /// Muestra resumen de la regla que se desea activar asi como las demas reglas pertenecientes
        /// al mismo corporativo si es que existen
        /// </summary>
        private void ShowInformation()
        {
            listInfoFeeRule = GetInfoFeeRuleByAttribute1BL.GetInfoFeeRule(null, Convert.ToInt32(txtRuleNumber.Text),Login.OrgId);
            if (listInfoFeeRule.Count == 0)
            {
                MessageBox.Show("EL NÚMERO DE REGLA DE CARGO POR SERVICIO NO EXISTE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRuleNumber.Focus();
            }
            else if (listInfoFeeRule.Count > 1)
            {
                for (int i = 0; i < listInfoFeeRule.Count; i++)
                {
                    if (listInfoFeeRule[i].RuleNumber.Equals(Convert.ToInt32(txtRuleNumber.Text)))
                    {
                        aux = i;
                        agent = listInfoFeeRule[i].Agent;
                        corp = listInfoFeeRule[i].Attribute1;
                        break;
                    }
                }
                if (listInfoFeeRule[aux].ActivationSatate)
                {
                    MessageBox.Show("EL NÚMERO DE REGLA DE CARGO POR SERVICIO YA SE ENCUENTRA ACTIVA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
                else
                {
                    btnAccept.Visible = false;
                    lblInfoRuleByAttribute.Text = string.Concat("La regla ", txtRuleNumber.Text, " pertenece al corporativo ", listInfoFeeRule[0].Attribute1,
                        " el cual contiene las siguientes\nreglas:");
                    attribute1 = listInfoFeeRule[0].Attribute1;
                    string info = string.Empty;
                    int indexRuleNumber = 0;
                    for (int i = 0; i < listInfoFeeRule.Count; i++)
                    {
                        if (listInfoFeeRule[i].RuleNumber == Convert.ToInt32(txtRuleNumber.Text))
                            indexRuleNumber = i;
                        info = string.Concat(info, "Regla: ", listInfoFeeRule[i].RuleNumber);
                        info = string.Concat(info, "\n", "Descripción: ", listInfoFeeRule[i].Description);
                        info = string.Concat(info, "\n", "Prioridad: ", listInfoFeeRule[i].Priority);
                        info = string.Concat(info, "\n", "% De Tarifa Base: ", listInfoFeeRule[i].DefaultFee);
                        info = string.Concat(info, "\n", "Cantidad Fija: ", listInfoFeeRule[i].DefaultMount.ToString("0.00"));
                        info = string.Concat(info, "\n", "Monto: ", (listInfoFeeRule[i].Mandatory) ? "No Negociable" : "Negociable");
                        info = string.Concat(info, "\n", "Status: ", (listInfoFeeRule[i].ActivationSatate == true) ? "Activa" : "Inactiva", "\n");
                        if (listInfoFeeRule[i].StartDate != Types.DateNullValue)
                            info = string.Concat(info, "Inicio de regla: ", listInfoFeeRule[i].StartDate.ToString("dd-MM-yyyy"), "\n");
                        if (listInfoFeeRule[i].ExpirationDate != Types.DateNullValue)
                            info = string.Concat(info, "Fin de regla: ", listInfoFeeRule[i].ExpirationDate.ToString("dd-MM-yyyy"), "\n");
                        info = string.Concat(info, "\n");
                    }
                    string[] infoList = info.Split(new char[] { '\n' });
                    txtInfoRuleByAttribute1.Lines = infoList;
                    lblInfoRuleByAttribute.Visible = true;
                    txtInfoRuleByAttribute1.Visible = true;
                    lblInfoActivationRule.Text = string.Concat("La regla ", txtRuleNumber.Text, " aplica bajo los siguientes criterios:");
                    listInformationRule = GetInformationRuleAppliedBL.GetInfoRule(Convert.ToInt32(txtRuleNumber.Text), false);
                    string info2 = string.Empty;
                    info2 = string.Concat("% DE LA TARIFA BASE: ", listInformationRule[0].DefaultFee, "\n");
                    info2 = string.Concat(info2, "Cantidad Fija: $", listInformationRule[0].DefaultMount.ToString("0.00"), "\n");
                    info2 = string.Concat(info2, "Monto: ", (listInformationRule[0].Mandatory) ? "No Negociable" : "Negociable", "\n");
                    if (listInfoFeeRule[indexRuleNumber].StartDate != Types.DateNullValue)
                        info2 = string.Concat(info2, "Inicio de regla: ", listInfoFeeRule[indexRuleNumber].StartDate.ToString("dd-MM-yyyy"), "\n");
                    if (listInfoFeeRule[indexRuleNumber].ExpirationDate != Types.DateNullValue)
                        info2 = string.Concat(info2, "Fin de regla: ", listInfoFeeRule[indexRuleNumber].ExpirationDate.ToString("dd-MM-yyyy"), "\n");
                    if (!string.IsNullOrEmpty(listInformationRule[0].Value2) && !string.IsNullOrEmpty(listInformationRule[0].Target))
                        for (int i = 0; i < listInformationRule.Count; i++)
                        {
                            info2 = string.Concat(info2,
                                                listInformationRule[i].Target,
                                                ": ",
                                                listInformationRule[i].Value2,
                                                "\n");
                        }
                    listLocationDK = SetLocationDKNotAcceptedBL.SetLocationDKNotAccepted(Convert.ToInt32(txtRuleNumber.Text), null);
                    string locationDKNotAccepted = string.Empty;
                    if (listLocationDK.Count > 0)
                    {
                        for (int j = 0; j < listLocationDK.Count; j++)
                            locationDKNotAccepted = string.Concat(locationDKNotAccepted, listLocationDK[j].LocationDK, ", ");
                        locationDKNotAccepted = locationDKNotAccepted.Trim().TrimEnd(new char[] { ',' });
                        info2 = string.Concat(info2, "LocationDK Excluyente: ", locationDKNotAccepted, "\n");
                    }
                    string[] infoList2 = info2.Split(new char[] { '\n' });
                    txtInfoRuleNumber.Lines = infoList2;
                    txtInfoRuleNumber.Visible = true;
                    lblInfoActivationRule.Visible = true;
                    if (statusButtons)
                    {
                        btnActivation.Location = new Point(btnActivation.Location.X, btnActivation.Location.Y + 180);
                        btnClear.Location = new Point(btnClear.Location.X, btnClear.Location.Y + 180);
                        statusButtons = false;
                    }
                    btnActivation.Visible = true;
                    btnClear.Visible = true;
                    txtRuleNumber.ReadOnly = true;
                    btnActivation.Focus();
                }
            }
            else if (listInfoFeeRule.Count == 1)
            {
                if (listInfoFeeRule[0].ActivationSatate)
                {
                    MessageBox.Show("EL NÚMERO DE REGLA DE CARGO POR SERVICIO YA SE ENCUENTRA ACTIVA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
                else
                {
                    agent = listInfoFeeRule[0].Agent;
                    corp = listInfoFeeRule[0].Attribute1;
                    btnAccept.Visible = false;
                    lblInfoRuleByAttribute.Text = string.Concat("La regla ", txtRuleNumber.Text, " pertenece al corporativo ", listInfoFeeRule[0].Attribute1,
                        " y se aplica bajo los siguientes\ncriterios:");
                    attribute1 = listInfoFeeRule[0].Attribute1;
                    listInformationRule = GetInformationRuleAppliedBL.GetInfoRule(Convert.ToInt32(txtRuleNumber.Text), false);
                    string info = string.Empty;
                    info = string.Concat("% DE LA TARIFA BASE: ", listInformationRule[0].DefaultFee, "\n");
                    info = string.Concat(info, "Cantidad Fija: $", listInformationRule[0].DefaultMount.ToString("0.00"), "\n");
                    info = string.Concat(info, "Monto: ", (listInformationRule[0].Mandatory) ? "No Negociable" : "Negociable", "\n");
                    if (listInfoFeeRule[0].StartDate != Types.DateNullValue)
                        info = string.Concat(info, "Inicio de regla: ", listInfoFeeRule[0].StartDate.ToString("dd-MM-yyyy"), "\n");
                    if (listInfoFeeRule[0].ExpirationDate != Types.DateNullValue)
                        info = string.Concat(info, "Fin de regla: ", listInfoFeeRule[0].ExpirationDate.ToString("dd-MM-yyyy"), "\n");
                    if (!string.IsNullOrEmpty(listInformationRule[0].Value2) && !string.IsNullOrEmpty(listInformationRule[0].Target))
                        for (int i = 0; i < listInformationRule.Count; i++)
                        {
                            info = string.Concat(info,
                                                listInformationRule[i].Target,
                                                ": ",
                                                listInformationRule[i].Value2,
                                                "\n");
                        }
                    listLocationDK = SetLocationDKNotAcceptedBL.SetLocationDKNotAccepted(Convert.ToInt32(txtRuleNumber.Text), null);
                    string locationDKNotAccepted = string.Empty;
                    if (listLocationDK.Count > 0)
                    {
                        for (int j = 0; j < listLocationDK.Count; j++)
                            locationDKNotAccepted = string.Concat(locationDKNotAccepted, listLocationDK[j].LocationDK, ", ");
                        locationDKNotAccepted = locationDKNotAccepted.Trim().TrimEnd(new char[] { ',' });
                        info = string.Concat(info, "LocationDK Excluyente: ", locationDKNotAccepted, "\n");
                    }
                    string[] infoList = info.Split(new char[] { '\n' });
                    txtInfoRuleByAttribute1.Lines = infoList;
                    lblInfoRuleByAttribute.Visible = true;
                    txtInfoRuleByAttribute1.Visible = true;
                    if (!statusButtons)
                    {
                        btnActivation.Location = new Point(btnActivation.Location.X, btnActivation.Location.Y - 180);
                        btnClear.Location = new Point(btnClear.Location.X, btnClear.Location.Y - 180);
                        statusButtons = true;
                    }
                    btnActivation.Visible = true;
                    btnClear.Visible = true;
                    txtRuleNumber.ReadOnly = true;
                    btnActivation.Focus();
                }

            }

        }

        #endregion //Methods Class

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtRuleNumber.Text = string.Empty;
            txtRuleNumber.ReadOnly = false;
            btnAccept.Visible = true;
            btnClear.Visible = false;
            btnActivation.Visible = false;
            txtInfoRuleNumber.Visible = false;
            txtInfoRuleByAttribute1.Visible = false;
            lblInfoActivationRule.Visible = false;
            lblInfoRuleByAttribute.Visible = false;

        }

        private void btnActivation_Click(object sender, EventArgs e)
        {
            DialogResult yesNo = MessageBox.Show("¿SEGURO QUE DESEA ACTIVAR LA REGLA " + txtRuleNumber.Text + " PARA EL CORPORATIVO " + attribute1 + "?", Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (yesNo.Equals(DialogResult.Yes))
            {
                ActivationFeeRuleBL.ActivationFeeRule(Convert.ToInt32(txtRuleNumber.Text));
                try
                {
                    List<GetMailByUser> mailAndUserList = GetMailByUserBL.GetMailAndUser(agent);
                    string info = string.Concat("Hola ",
                        mailAndUserList[0].FamilyName, "\n\n",
                        "MyCTS te informa que la regla de cargo por servicio número ",
                        txtRuleNumber.Text, " ya se encuentra activa para el corporativo ",
                        corp, "\n\n",
                        "Te recordamos que los criterios para su aplicación son los siguientes:", "\n\n");
                    info = string.Concat(info, "  -", "PORCENTAJE DE LA TARIFA BASE: ".ToUpper().PadRight(35, ' '), listInformationRule[0].DefaultFee, "\n\n");
                    info = string.Concat(info, "  -", "Cantidad Fija:".ToUpper().PadRight(35, ' '), "$", listInformationRule[0].DefaultMount.ToString("0.00"), "\n\n");
                    info = string.Concat(info, "  -", "Monto: ".ToUpper().PadRight(35, ' '), (listInformationRule[0].Mandatory) ? "No Negociable" : "Negociable", "\n\n");
                    if (listInfoFeeRule[aux].StartDate != Types.DateNullValue)
                        info = string.Concat(info, "  -", "Inicio de regla: ".ToUpper().PadRight(35, ' '), listInfoFeeRule[aux].StartDate.ToString("dd-MM-yyyy"), "\n\n");
                    if (listInfoFeeRule[aux].ExpirationDate != Types.DateNullValue)
                        info = string.Concat(info, "  -", "Fin de regla: ".ToUpper().PadRight(35, ' '), listInfoFeeRule[aux].ExpirationDate.ToString("dd-MM-yyyy"), "\n\n");
                    if (!string.IsNullOrEmpty(listInformationRule[0].Value2) && !string.IsNullOrEmpty(listInformationRule[0].Target))
                        for (int i = 0; i < listInformationRule.Count; i++)
                        {
                            info = string.Concat(info, "  -", string.Concat(
                                                listInformationRule[i].Target,
                                                ": ").ToUpper().PadRight(35, ' '),
                                                listInformationRule[i].Value2,
                                                "\n\n");
                        }
                    if (listLocationDK.Count > 0)
                    {
                        string locationDKNotAccepted = string.Empty;
                        for (int j = 0; j < listLocationDK.Count; j++)
                            locationDKNotAccepted = string.Concat(locationDKNotAccepted, listLocationDK[j].LocationDK, ", ");
                        locationDKNotAccepted = locationDKNotAccepted.Trim().TrimEnd(new char[] { ',' });
                        info = string.Concat(info, "  -", "Location(DK) Excluyente:".ToUpper().PadRight(35, ' '), locationDKNotAccepted, "\n");
                    }
                    info = string.Concat(info, "\n\n", "Gracias por haber creado esta regla");
                    Parameter mailToSend = ParameterBL.GetParameterValue("MailThatSendFeeRule");
                    Parameter mailPassword = ParameterBL.GetParameterValue("PasswordThatMailToSend");
                    Parameter displyName = ParameterBL.GetParameterValue("NameSendEmail");
                    MailProvider ws = new MailProvider();
                    ws.SendEmail2(mailToSend.Values, mailPassword.Values, displyName.Values,
                        mailAndUserList[0].UserMail, null, "Activación de Regla Cargo por Servicio", info);
                }
                catch { }
                MessageBox.Show("LA REGLA " + txtRuleNumber.Text + " QUEDO ACTIVA PARA EL CORPORATIVO " + attribute1, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            else
                btnClear.Focus();
        }



        #region =====Back to a Previous Usercontrol or Validate Enter KeyDown=====

        /// <summary>
        /// Regresa al user cotrol welcome cuando se presiona ESC o ejecuta
        /// la acción del botón aceptar cuando se presiona Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData.Equals(Keys.Escape))
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            if (e.KeyData.Equals(Keys.Enter))
            {
                if (btnAccept.Visible)
                    btnAccept_Click(sender, e);
                else
                    btnActivation_Click(sender, e);
            }
        }

        #endregion // Back to a Previous Usercontrol or Validate Enter KeyDown

        private void txtRuleNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtRuleNumber.TextLength == txtRuleNumber.MaxLength)
                btnAccept.Focus();
        }


    }
}
