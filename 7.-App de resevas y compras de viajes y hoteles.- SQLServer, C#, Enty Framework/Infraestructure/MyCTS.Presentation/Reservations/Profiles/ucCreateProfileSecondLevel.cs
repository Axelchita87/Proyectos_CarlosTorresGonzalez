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
using MyCTS.Forms.UI;
using MyCTS.Presentation.Components;
using MyCTS.Services;

namespace MyCTS.Presentation
{
    public partial class ucCreateProfileSecondLevel : CustomUserControl
    {

        /// <summary>
        /// Descripción: User control que crea perfil de segundo nivel
        /// Creación:    23 febrero 2010, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>

        private TextBox txtSender;
        private string pcc = string.Empty;
        public static List<ListItem> profileList = new List<ListItem>();
        private bool statusParamReceived = false;
        public static List<string> previousValues = new List<string>();
        private bool flag=true;

        public ucCreateProfileSecondLevel()
        {
            InitializeComponent();
            this.InitialControlFocus = txtProfileNameFirstLevel;
            this.LastControlFocus = btnAccept;

        }


        //Evento Load
        private void ucCreateProfileSecondLevel_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            if (previousValues.Count > 0)
            {
                SetPreviousControlValues();
            }
            cmbPhoneCode.SelectedIndex = 0;
            cmbOfficePhoneCode.SelectedIndex = 0;
            txtProfileNameFirstLevel.Focus();
            profileList.Clear();
        }


        //Evento btnAccept_Click
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!IsValidBusinessRules)
            {
                GetPreviousControlValues();
                CreateProfile();
            }
        }



        #region===== MethodsClass ======


        /// <summary>
        /// Ingresa los valores de una consulta previamente realizada en el user control 
        /// </summary>
        private void SetPreviousControlValues()
        {
            if (!previousValues.Count.Equals(0))
            {
                statusParamReceived = true;
                for (int i = 0; i < 46; i++)
                {
                    foreach (Control ctrl in this.Controls)
                    {

                        if (ctrl.TabIndex.Equals(i + 1))
                        {
                            if (ctrl is SmartTextBox)
                            {
                                ((SmartTextBox)(ctrl)).Text = previousValues[i];

                            }

                            else if (ctrl is ComboBox)
                            {
                                ((ComboBox)(ctrl)).SelectedIndex = Convert.ToInt32(previousValues[i]);
                            }

                            else if (ctrl is CheckBox)
                            {
                                if (previousValues[i].Equals(Resources.Constants.TRUE))
                                    ((CheckBox)(ctrl)).Checked = true;
                                else
                                    ((CheckBox)(ctrl)).Checked = false;

                            }
                        }
                    }


                }

                previousValues.Clear();
                statusParamReceived = false;
            }
        }
        /// <summary>
        /// Comprueba si el email ingresado ya esta en algun perfil
        /// </summary>
        /// <returns></returns>
        private bool ExistEmailInProfiles(string eMail)
        {
            var objStar2Profiles = new GetStar2ProfileByEmailBL();
            var listProfiles = objStar2Profiles.GetStar2LevelInfo(eMail);
            if (listProfiles.Count > 0)
            {
                string prefiles = "";
                foreach (var prefil in listProfiles)
                {
                    prefiles = prefiles + "    * " + prefil.Level2 + "\n";
                }
                MessageBox.Show("Este Email no puede ser utilizado en la creación del perfil\n" +
                    "debido a que ya pertenece a los siguientes perfiles:\n\n" + prefiles, "Validación Email",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Remplaza el caracter "_" por los caracteres "=="
        /// </summary>
        /// <returns></returns>
        private string remplace_(string text)
        {
            text = text.Replace('_', ' ');
            text = text.Replace(" ", "==");
            return text;
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
                if (string.IsNullOrEmpty(txtProfileNameFirstLevel.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_NOMBRE_PERFIL_1ER_NIVEL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtProfileNameFirstLevel.Focus();
                }
                if (string.IsNullOrEmpty(pcc))
                {
                    MessageBox.Show("SELECCIONA LA ESTRELLA DE PRIMER NIVEL DEL PREDICTVO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtProfileNameFirstLevel.Focus();
                }
                else if (string.IsNullOrEmpty(txtProfileNameEmployee.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_NOMBRE_PERFIL_2DO_NIVEL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtProfileNameEmployee.Focus();
                }
                else if (!string.IsNullOrEmpty(txtProfileNameEmployee.Text) && !ValidateRegularExpression.ValidateProfile2ndLevelNameFormat(txtProfileNameEmployee.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.PERFIL_EMPLEADO_DEBE_CONTENER_DIAGONAL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtProfileNameEmployee.Focus();

                }
                else if (!string.IsNullOrEmpty(txtProfileNameEmployee.Text) &&
                    !string.IsNullOrEmpty(txtProfileNameFirstLevel.Text) &&
                    IsValid2ndStarName)
                {
                    MessageBox.Show(Resources.Profiles.Profiles.NOMBRE_PERFIL_EXISTENTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtProfileNameEmployee.Focus();

                }
                else if (string.IsNullOrEmpty(txtName.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.DEBES_INGRESAR_NOMBRE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Focus();
                }
                else if (string.IsNullOrEmpty(txtLastName.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.DEBES_INGRESAR_APELLIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLastName.Focus();
                }
                else if (string.IsNullOrEmpty(txtOfficePhone.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.DEBES_INGRESAR_NUMERO_TELEFONICO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtOfficePhone.Focus();
                }
                else if (string.IsNullOrEmpty(txtEmail.Text))
                {

                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_EMAIL_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmail.Focus();
                }
                else if (!string.IsNullOrEmpty(txtEmail.Text) && !ValidateRegularExpression.ValidateEmailFormat(txtEmail.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.FORMATO_CORREO_ELECT_INCORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmail.Focus();
                }
                else if (ExistEmailInProfiles(remplace_(txtEmail.Text)))
                {
                    txtEmail.Focus();
                }
                else if (string.IsNullOrEmpty(txtBirthdayDay.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_DIA_NACIMIENTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmail.Focus();
                }
                else if (string.IsNullOrEmpty(txtBirthDayMonth.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_MES_NACIMIENTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmail.Focus();
                }
                else if (string.IsNullOrEmpty(txtBirthDayYear.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_ANIO_NACIMIENTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmail.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtFFAirlineCode1.Text) || !string.IsNullOrEmpty(txtFFCode1.Text) || !string.IsNullOrEmpty(txtFFName1.Text)) &&
                    !(!string.IsNullOrEmpty(txtFFAirlineCode1.Text) && !string.IsNullOrEmpty(txtFFCode1.Text) && !string.IsNullOrEmpty(txtFFName1.Text)))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_AEROLINEA_FF_NOMBRE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrEmpty(txtFFAirlineCode1.Text))
                        txtFFAirlineCode1.Focus();
                    else if (string.IsNullOrEmpty(txtFFCode1.Text))
                        txtFFCode1.Focus();
                    else if (string.IsNullOrEmpty(txtFFName1.Text))
                        txtFFName1.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtFFAirlineCode2.Text) || !string.IsNullOrEmpty(txtFFCode2.Text) || !string.IsNullOrEmpty(txtFFName2.Text)) &&
                    !(!string.IsNullOrEmpty(txtFFAirlineCode2.Text) && !string.IsNullOrEmpty(txtFFCode2.Text) && !string.IsNullOrEmpty(txtFFName2.Text)))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_AEROLINEA_FF_NOMBRE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrEmpty(txtFFAirlineCode2.Text))
                        txtFFAirlineCode2.Focus();
                    else if (string.IsNullOrEmpty(txtFFCode2.Text))
                        txtFFCode2.Focus();
                    else if (string.IsNullOrEmpty(txtFFName2.Text))
                        txtFFName2.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtFFAirlineCode3.Text) || !string.IsNullOrEmpty(txtFFCode3.Text) || !string.IsNullOrEmpty(txtFFName3.Text)) &&
                   !(!string.IsNullOrEmpty(txtFFAirlineCode3.Text) && !string.IsNullOrEmpty(txtFFCode3.Text) && !string.IsNullOrEmpty(txtFFName3.Text)))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_AEROLINEA_FF_NOMBRE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrEmpty(txtFFAirlineCode3.Text))
                        txtFFAirlineCode3.Focus();
                    else if (string.IsNullOrEmpty(txtFFCode3.Text))
                        txtFFCode3.Focus();
                    else if (string.IsNullOrEmpty(txtFFName3.Text))
                        txtFFName3.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtFFAirlineCode4.Text) || !string.IsNullOrEmpty(txtFFCode4.Text) || !string.IsNullOrEmpty(txtFFName4.Text)) &&
                   !(!string.IsNullOrEmpty(txtFFAirlineCode4.Text) && !string.IsNullOrEmpty(txtFFCode4.Text) && !string.IsNullOrEmpty(txtFFName4.Text)))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_AEROLINEA_FF_NOMBRE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrEmpty(txtFFAirlineCode4.Text))
                        txtFFAirlineCode4.Focus();
                    else if (string.IsNullOrEmpty(txtFFCode4.Text))
                        txtFFCode4.Focus();
                    else if (string.IsNullOrEmpty(txtFFName4.Text))
                        txtFFName4.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtFFAirlineCode5.Text) || !string.IsNullOrEmpty(txtFFCode5.Text) || !string.IsNullOrEmpty(txtFFName5.Text)) &&
                    !(!string.IsNullOrEmpty(txtFFAirlineCode5.Text) && !string.IsNullOrEmpty(txtFFCode5.Text) && !string.IsNullOrEmpty(txtFFName5.Text)))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_AEROLINEA_FF_NOMBRE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrEmpty(txtFFAirlineCode5.Text))
                        txtFFAirlineCode5.Focus();
                    else if (string.IsNullOrEmpty(txtFFCode5.Text))
                        txtFFCode5.Focus();
                    else if (string.IsNullOrEmpty(txtFFName5.Text))
                        txtFFName5.Focus();
                }

                else if (!string.IsNullOrEmpty(txtPassportNum.Text) &&
                    (string.IsNullOrEmpty(txtPassportVigencyMonth.Text) || string.IsNullOrEmpty(txtPassportVigencyYear.Text)))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_FECHA_VIGENCIA_PASAPORTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrEmpty(txtPassportVigencyMonth.Text))
                        txtPassportVigencyMonth.Focus();
                    else if (string.IsNullOrEmpty(txtPassportVigencyYear.Text))
                        txtPassportVigencyYear.Focus();
                }
                else if (!((string.IsNullOrEmpty(txtBirthdayDay.Text) && string.IsNullOrEmpty(txtBirthDayMonth.Text) && string.IsNullOrEmpty(txtBirthDayYear.Text)) ||
                    (!string.IsNullOrEmpty(txtBirthdayDay.Text) && !string.IsNullOrEmpty(txtBirthDayMonth.Text) && !string.IsNullOrEmpty(txtBirthDayYear.Text))))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_FECHA_NACIMIENTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrEmpty(txtBirthdayDay.Text))
                        txtBirthdayDay.Focus();
                    else if (string.IsNullOrEmpty(txtBirthDayMonth.Text))
                        txtBirthDayMonth.Focus();
                    else if (string.IsNullOrEmpty(txtBirthDayYear.Text))
                        txtBirthDayYear.Focus();
                }
                else if (!string.IsNullOrEmpty(txtVisaNum.Text) &&
               (string.IsNullOrEmpty(txtVigencyVisaMonth.Text) || string.IsNullOrEmpty(txtVigencyVisaYear.Text)))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_FECHA_VIGENCIA_VISA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrEmpty(txtVigencyVisaMonth.Text))
                        txtVigencyVisaMonth.Focus();
                    else if (string.IsNullOrEmpty(txtVigencyVisaYear.Text))
                        txtVigencyVisaYear.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtCreditCardCode.Text) || !string.IsNullOrEmpty(txtCreditCardNumber.Text) || !string.IsNullOrEmpty(txtCreditCardMonth.Text) || !string.IsNullOrEmpty(txtCreditCardYear.Text)) &&
               !(!string.IsNullOrEmpty(txtCreditCardCode.Text) && !string.IsNullOrEmpty(txtCreditCardNumber.Text) && !string.IsNullOrEmpty(txtCreditCardMonth.Text) && !string.IsNullOrEmpty(txtCreditCardYear.Text)))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_DATOS_TARJETA_CREDITO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrEmpty(txtCreditCardCode.Text))
                        txtCreditCardCode.Focus();
                    else if (string.IsNullOrEmpty(txtCreditCardNumber.Text))
                        txtCreditCardNumber.Focus();
                    else if (string.IsNullOrEmpty(txtCreditCardMonth.Text))
                        txtCreditCardMonth.Focus();
                    else if (string.IsNullOrEmpty(txtCreditCardYear.Text))
                        txtCreditCardYear.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtCreditCardPerCode.Text) || !string.IsNullOrEmpty(txtCreditCardPerNumber.Text) || !string.IsNullOrEmpty(txtCreditCardPerMonth.Text) || !string.IsNullOrEmpty(txtCreditCardPerYear.Text)) &&
                !(!string.IsNullOrEmpty(txtCreditCardPerCode.Text) && !string.IsNullOrEmpty(txtCreditCardPerNumber.Text) && !string.IsNullOrEmpty(txtCreditCardPerMonth.Text) && !string.IsNullOrEmpty(txtCreditCardPerYear.Text)))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_DATOS_TARJETA_CREDITO_CLIENTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrEmpty(txtCreditCardPerCode.Text))
                        txtCreditCardPerCode.Focus();
                    else if (string.IsNullOrEmpty(txtCreditCardPerNumber.Text))
                        txtCreditCardPerNumber.Focus();
                    else if (string.IsNullOrEmpty(txtCreditCardPerMonth.Text))
                        txtCreditCardPerMonth.Focus();
                    else if (string.IsNullOrEmpty(txtCreditCardPerYear.Text))
                        txtCreditCardPerYear.Focus();
                }
                else
                {
                    isValid = false;
                }

                return isValid;
            }
        }


        /// <summary>
        /// VALIDA SI EL NOMBRE DE LA ESTRELLA YA EXISTE EN LA BASE DE DATOS
        /// </summary>
        private bool IsStarExist
        {
            get
            {
                bool isValid = false;
                List<CatAllStars> star = CatAllStarsBL.GetAllStarsDetailed_Profile(pcc, txtProfileNameFirstLevel.Text, txtProfileNameEmployee.Text,Login.OrgId);
                if (star.Count > 0)
                    isValid = true;
                return isValid;
            }

        }


        /// <summary>
        /// Guarda los valores de la consulta realizada en el user control 
        /// </summary>
        private void GetPreviousControlValues()
        {

            for (int i = 0; i < 46; i++)
            {
                foreach (Control ctrl in this.Controls)
                {

                    if (ctrl.TabIndex.Equals(i + 1))
                    {
                        if (ctrl is SmartTextBox)
                        {
                            previousValues.Add(((SmartTextBox)(ctrl)).Text);
                        }

                        else if (ctrl is ComboBox)
                        {
                            previousValues.Add(((ComboBox)(ctrl)).SelectedIndex.ToString());
                        }

                        else if (ctrl is CheckBox)
                        {
                            previousValues.Add(((CheckBox)(ctrl)).Checked.ToString());
                        }
                    }

                }

            }
        }


        /// <summary>
        /// Valida si el nombre de perfil de primer nivel existe en la base de datos
        /// </summary>
        private bool IsValid2ndStarName
        {
            get
            {
                bool isValid = false;
                List<CatAllStars> ProfileList = CatAllStarsBL.GetAllStarsDetailed_Profile(pcc, txtProfileNameFirstLevel.Text, txtProfileNameEmployee.Text, Login.OrgId);
                if (ProfileList.Count > 0)
                {
                    isValid = true;
                }
                return isValid;
            }
        }


        /// <summary>
        /// Asigna valores de linea del perfil a la lista contenedora
        /// </summary>
        /// <param name="value">Valor del elemento</param>
        /// <param name="text">Texto del elemento</param>
        /// <param name="profileList">Referencia de lista</param>
        private void SetCategoryValue(string value, string text, ref List<ListItem> profileList)
        {
            if (!string.IsNullOrEmpty(text))
            {
                ListItem item = new ListItem();
                item.Value = value;
                item.Text = text;
                profileList.Add(item);
            }
        }


        /// <summary>
        /// Crea el perfil de primer nivel
        /// </summary>
        private void CreateProfile()
        {
            string textValue = string.Empty;

            SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_A, string.Concat(Resources.Constants.INDENT, txtLastName.Text.TrimEnd(), Resources.Constants.SLASH, txtName.Text.TrimEnd()), ref profileList);
            SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_A, string.Concat(Resources.Profiles.Constants.COMMAND_NINE, txtOfficePhone.Text, (!string.IsNullOrEmpty(txtExt.Text)) ? string.Concat(Resources.Profiles.Constants.COMMAND_X, txtExt.Text) : string.Empty, (cmbOfficePhoneCode.SelectedIndex > 0) ? string.Concat(Resources.Constants.INDENT, cmbOfficePhoneCode.Text.Substring(0, 1)) : string.Empty), ref profileList);

            if (!string.IsNullOrEmpty(txtPhone.Text))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_O, string.Concat(Resources.Profiles.Constants.COMMAND_NINE, txtPhone.Text, (cmbPhoneCode.SelectedIndex > 0) ? string.Concat(Resources.Constants.INDENT, cmbPhoneCode.Text.Substring(0, 1)) : string.Empty), ref profileList);
            }

            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_A, string.Concat(Resources.Profiles.Constants.COMMAND_PE_CROSS_LORAINE, remplace_(txtEmail.Text).ToUpper(), Resources.Profiles.Constants.COMMAND_CROSS_LORAINE), ref profileList);
            }

            if (!string.IsNullOrEmpty(txtFFAirlineCode1.Text) &&
                !string.IsNullOrEmpty(txtFFCode1.Text) &&
                !string.IsNullOrEmpty(txtFFName1.Text))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_A, string.Format("FF{0}{1}-{2}", txtFFAirlineCode1.Text, txtFFCode1.Text, txtFFName1.Text), ref profileList);

            }

            if (!string.IsNullOrEmpty(txtFFAirlineCode2.Text) &&
                !string.IsNullOrEmpty(txtFFCode2.Text) &&
                !string.IsNullOrEmpty(txtFFName2.Text))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_A, string.Format("FF{0}{1}-{2}", txtFFAirlineCode2.Text, txtFFCode2.Text, txtFFName2.Text), ref profileList);
            }

            if (!string.IsNullOrEmpty(txtFFAirlineCode3.Text) &&
                !string.IsNullOrEmpty(txtFFCode3.Text) &&
                !string.IsNullOrEmpty(txtFFName3.Text))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_A, string.Format("FF{0}{1}-{2}", txtFFAirlineCode3.Text, txtFFCode3.Text, txtFFName3.Text), ref profileList);
            }

            if (!string.IsNullOrEmpty(txtFFAirlineCode4.Text) &&
                !string.IsNullOrEmpty(txtFFCode4.Text) &&
                !string.IsNullOrEmpty(txtFFName4.Text))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_A, string.Format("FF{0}{1}-{2}", txtFFAirlineCode4.Text, txtFFCode4.Text, txtFFName4.Text), ref profileList);
            }

            if (!string.IsNullOrEmpty(txtFFAirlineCode5.Text) &&
                !string.IsNullOrEmpty(txtFFCode5.Text) &&
                !string.IsNullOrEmpty(txtFFName5.Text))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("FF{0}{1}-{2}", txtFFAirlineCode5.Text, txtFFCode5.Text, txtFFName5.Text), ref profileList);
            }

            if (!string.IsNullOrEmpty(txtPassportNum.Text))
            {
                string passportVigency = string.Format("{0} - {1} {2}",
                    txtPassportVigencyMonth.Text,
                    txtPassportVigencyYear.Text,
                    txtCountry.Text);
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("NÚMERO DE PASAPORTE: {0} {1}", txtPassportNum.Text, passportVigency), ref profileList);
            }

            if (!string.IsNullOrEmpty(txtBirthdayDay.Text) &&
                !string.IsNullOrEmpty(txtBirthDayMonth.Text) &&
                !string.IsNullOrEmpty(txtBirthDayYear.Text))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("FECHA DE NACIMIENTO: {0}-{1}-{2}", txtBirthdayDay.Text, txtBirthDayMonth.Text, txtBirthDayYear.Text), ref profileList);
            }

            if (!string.IsNullOrEmpty(txtVisaNum.Text))
            {
                string visaVigency = string.Format("{0} - {1} {2}",
                    txtVigencyVisaMonth.Text,
                    txtVigencyVisaYear.Text,
                    txtVisaCountry.Text);
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("NÚMERO DE VISA: {0} {1}", txtVisaNum.Text, visaVigency), ref profileList);
            }

            if (!string.IsNullOrEmpty(txtMigratoryForm.Text))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("FORMA MIGRATORIA: {0}", txtMigratoryForm.Text), ref profileList);
            }

            if (!string.IsNullOrEmpty(txtMigratoryNum.Text))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("NÚMERO MIGRATORIO: {0}", txtMigratoryNum.Text), ref profileList);
            }

            if (!string.IsNullOrEmpty(txtRFC.Text))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("RFC: {0}", txtRFC.Text), ref profileList);
            }

            if (!string.IsNullOrEmpty(txtCreditCardNumber.Text))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("TARJETA DE CREDITO: {0}{1} {2}-{3}", txtCreditCardCode.Text, "XXXX-XXXX-XXXX-" + txtCreditCardPerNumber.Text.Substring(txtCreditCardPerNumber.Text.Length - 3, 4), txtCreditCardMonth.Text, txtCreditCardYear.Text), ref profileList);
            }

            if (!string.IsNullOrEmpty(txtCreditCardPerNumber.Text))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("TARJETA DE CREDITO CLIENTE: {0}{1} {2}-{3}", txtCreditCardPerCode.Text, "XXXX-XXXX-XXXX-"+txtCreditCardPerNumber.Text.Substring(txtCreditCardPerNumber.Text.Length-3,4), txtCreditCardPerMonth.Text, txtCreditCardPerYear.Text), ref profileList);
            }

            LoaderProfiles.AddToPanelWithParameters(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_PROFILE_SECOND_LEVEL_CONTINUE, new string[] { pcc, txtProfileNameFirstLevel.Text, txtProfileNameEmployee.Text, txtLastName.Text });
        }


        //private void SetStarsName()
        //{
        //    cmbProfileNameFirstLevel.Items.Add("Selecciona el Perfil de primer nivel deseado:");
        //    List<CatStars1stLevel> stars = CatStars1stLevelBL.GetStars1stLevel();
        //    foreach (CatStars1stLevel starList in stars)
        //    {
        //        ListItem item = new ListItem();
        //        item.Text = string.Concat(starList.Star1Name, " - ", starList.Pccid);
        //        item.Text2 = starList.Pccid;
        //        item.Value = starList.Star1Name;
        //        cmbProfileNameFirstLevel.Items.Add(item);
        //    }
        //    cmbProfileNameFirstLevel.SelectedIndex = 0;
        //}

        #endregion// End MethodsClass


        #region=====Change focus When a Textbox is Full=====

        //Evento txtControl_TextChanged
        private void txtControl_TextChanged(object sender, EventArgs e)
        {
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


        #region =====Back to a Previous Usercontrol or Validate Enter KeyDown=====


        /// <summary>
        /// aborta el proceso al presionar la tecla ESC
        /// o ejecutar las funciones al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData.Equals(Keys.Escape))
            {
                frmProfiles frm = this.ParentForm as frmProfiles;
                frm.Width = frm.MinWidth;
                frm.Height = frm.MinHeight;
                frm.CenterForm();
                frm.IsMinSize = true;
                LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_WELCOME_PROFILES);
            }
            else if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }

        }


        #endregion//Back to a Previous Usercontrol or Validate Enter KeyDown


        #region===== Predictives =====

        //Evento txtProfileNameFirstLevel_TextChanged
        private void txtProfileNameFirstLevel_TextChanged(object sender, EventArgs e)
        {
            lbProfileInfo.Items.Clear();
            txtSender = (SmartTextBox)sender;
            Common.SetListBoxStarsFirstLevel(txtSender, lbProfileInfo, txtProfileNameFirstLevel.Text); 
        }


        //Evento txtCountry_TextChanged
        private void txtCountry_TextChanged(object sender, EventArgs e)
        {
            lbProfileInfo.Items.Clear();
            txtSender = (SmartTextBox)sender;
            Common.SetListBoxCountries(txtSender, lbProfileInfo);
        }


        private void txtFFAirlineCode_TextChanged(object sender, EventArgs e)
        {
            lbProfileInfo.Items.Clear();
            txtSender = (SmartTextBox)sender;
            Common.SetListBoxAirlines(txtSender, lbProfileInfo);
        }

        #endregion//End Predictives


        #region===== lbProfileInfo Events =====

        private void txtProfileNameFirstLevel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                frmProfiles frm = this.ParentForm as frmProfiles;
                frm.Width = frm.MinWidth;
                frm.Height = frm.MinHeight;
                frm.CenterForm();
                frm.IsMinSize = true;
                LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_WELCOME_PROFILES);
            }
            else if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Down)
            {

                if (lbProfileInfo.Items.Count > 0)
                {

                    lbProfileInfo.SelectedIndex = 0;
                    lbProfileInfo.Focus();
                    lbProfileInfo.Visible = true;
                    lbProfileInfo.Focus();
                    flag = true;
                }
            }
        }


        private void lbProfileInfo_KeyDown(object sender, KeyEventArgs e)
        {
            ListBox listBox = (ListBox)sender;

            if (e.KeyCode == Keys.Enter)
            {
                ListItem li = (ListItem)listBox.SelectedItem;
                txtSender.Text = li.Value;
                if (flag)
                {
                    pcc = li.Text2;
                    flag = false;
                }
                lbProfileInfo.Visible = false;
                txtSender.Focus();
                lbProfileInfo.Items.Clear();

            }

            if (e.KeyCode == Keys.Escape)
            {
                lbProfileInfo.Hide();
                lbProfileInfo.Items.Clear();
            }
        }


        private void lbProfileInfo_MouseClick(object sender, MouseEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            ListItem li = (ListItem)listBox.SelectedItem;
            txtSender.Text = li.Value;
            if (flag)
            {
                pcc = li.Text2;
                flag = false;
            }
            lbProfileInfo.Visible = false;
            lbProfileInfo.Items.Clear();
            txtSender.Focus();
        }


        private void hidePredictive(object sender, EventArgs e)
        {
            lbProfileInfo.Hide();
        }


        #endregion//End lbProfileInf Events

        private void txtProfileNameFirstLevel_Leave(object sender, EventArgs e)
        {

        }

        private void lbProfileInfo_VisibleChanged(object sender, EventArgs e)
        {
            if (txtSender != null)
            {
                if (txtSender.Name.Equals(txtProfileNameFirstLevel.Name))
                {
                    if (lbProfileInfo.Visible)
                        pcc = string.Empty;
                }
            }
        }



    }
}
