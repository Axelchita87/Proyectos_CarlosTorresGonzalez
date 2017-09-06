using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Forms.UI;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Resources.Profiles;
using System.Collections;
using System.IO;

namespace MyCTS.Presentation.Reservations.Profiles
{
    public partial class UcSecondLevelProfiles : CustomUserControl
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
        private bool flag = true;
        ProfilesMethods objProfilesMethods = new ProfilesMethods();
        public static List<Star2Details> ListObjStar2Dcpsl = new List<Star2Details>();
        public static Star2Details ObjStar2Dcpsl;
        public Form froS2;
        private int OperationType = 0;
        public static int ticketProfile = 0;
        private Boolean _isUpdate = false;
        private Boolean _isUpadateNewFormat = false;
        private Boolean _isNew = false;
        public Boolean ReloadProfiles = false;
        private List<Dynamic> listFields = null;
        private List<Dynamic> listFields2 = new List<Dynamic>();
        private Dynamic item2;
        private bool FieldsMandatory = false;
        public List<DocsSecondLevel> lst = new List<DocsSecondLevel>();
        public List<DocsSecondLevel> lstFisico = new List<DocsSecondLevel>();
        public static List<string> typeLine = new List<string>();

        public UcSecondLevelProfiles()
        {
            InitializeComponent();
            this.InitialControlFocus = txtProfileNameFirstLevel;
            this.LastControlFocus = btnAccept;
            setCreditCard();

        }

        private void setCreditCard()
        {
            //txtCreditCardNumber.PasswordChar = (char)183;
            //txtCreditCardNumber2.PasswordChar = (char)183;
            //txtCreditCardNumber3.PasswordChar = (char)183;
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

        //Evento Load
        private void ucCreateProfileSecondLevel_Load(object sender, EventArgs e)
        {
            //ucAvailability.IsInterJetProcess = false;
            FillCombo();
            lbProfileInfo.Visible = false;
            Parameter mandatory = ParameterBL.GetParameterValue("SecondLevelProfile");
            FieldsMandatory = Convert.ToBoolean(mandatory.Values);

            if (FieldsMandatory)
            {
                lblMountPreferred.ForeColor = Color.Black;
                lblPlacesPreference.ForeColor = Color.Black;
                lblWantInformation.ForeColor = Color.Black;
                lblBirthDay.ForeColor = Color.Black;
                lblDay.ForeColor = Color.Black;
                lblmonth2.ForeColor = Color.Black;
                lblYear2.ForeColor = Color.Black;
            }

            frmPreloading fr = new frmPreloading(this);
            fr.Show();

            ObjStar2Dcpsl = null;
            if (Parameters == null)
                Parameters = new string[4];

            listFields = FieldsDynamicsBL.GetStar2Details(Parameters[0], Parameters[1], Parameters[2]);

            switch (Parameters[3])
            {
                case "Update":
                    loadExtraFields();
                    ObjStar2Dcpsl = LoadStar2Details();
                    _isUpdate = true;
                    LoadDocuments(GetDynamicProperties("Id",listFields));
                    break;
                case "NewUpdate":
                    OperationType = 2;
                    ObjStar2Dcpsl = frmUpdateProfiles.ObjStar2Dfup;
                    loadExtraFields();
                    break;
                default:
                    loadExtraFields();
                    break;
            }

            ucProfileInfoDisplay.ObjStar2Dpid = null;
            froS2 = frmUpdateProfiles.parentForm;


            if (ObjStar2Dcpsl != null)
            {

                btnAccept.Text = @"Actualizar";
                if (ObjStar2Dcpsl.Id == null)
                    _isUpadateNewFormat = true;
                List<GetLogNewFormatProfiles> logList = GetLogNewFormatProfilesBL.GetLogNewFormatProfiles(ObjStar2Dcpsl.Pcc, ObjStar2Dcpsl.Level1, ObjStar2Dcpsl.Level2, 2);
                if (logList.Count > 0)
                {
                    foreach (GetLogNewFormatProfiles item in logList)
                    {
                        var itemLog = new ListViewItem(item.UserName);
                        itemLog.SubItems.Add(item.ModifiedDate.ToString());
                        listView1.Items.Add(itemLog);
                    }
                }
            }


            if (Parameters[3] == "Update")
                OperationType = 2;

            if (ObjStar2Dcpsl == null && Parameters[3] == "Update")
            {
                ObjStar2Dcpsl = frmUpdateProfiles.ObjStar2Dfup;
                OperationType = 3;
            }

            if (previousValues.Count > 0)
            {
                SetPreviousControlValues();
            }

            txtProfileNameFirstLevel.Focus();
            profileList.Clear();

            if (ListObjStar2Dcpsl.Count() != 0)
            {
                if (!string.IsNullOrEmpty(ListObjStar2Dcpsl[ticketProfile].OfficePhone))
                {
                    List<CatAllStars> StarsList = CatAllStarsBL.GetAllStars(Login.OrgId, ListObjStar2Dcpsl[ticketProfile].Name, "");
                    Parameters[0] = StarsList[0].PccId;
                    Parameters[1] = ListObjStar2Dcpsl[ticketProfile].Level1;
                    Parameters[2] = ListObjStar2Dcpsl[ticketProfile].Name;
                    Parameters[3] = "Update";
                    OperationType = 2;
                    listFields = FieldsDynamicsBL.GetStar2Details(Parameters[0], Parameters[1], Parameters[2]);

                    ObjStar2Dcpsl = LoadStar2Details();
                    txtProfileNameEmployee.Enabled  = false;
                    txtProfileNameFirstLevel.Enabled = false;
                    _isUpdate = true;
                    LoadDocuments(GetDynamicProperties("Id", listFields));
                }
                else
                {
                    txtProfileNameEmployee.Enabled = true;
                    txtProfileNameFirstLevel.Enabled = true;
                    ObjStar2Dcpsl = new Star2Details();
                    ObjStar2Dcpsl = ListObjStar2Dcpsl[ticketProfile];
                }
                
                //Carga de imagenes
                LoadFieldsInTemplate();
            }
            else if (Parameters[3] != null )
            {
                txtProfileNameEmployee.Enabled = false;
                txtProfileNameFirstLevel.Enabled = false;
                LoadFieldsInTemplate();
            }
               
            ComboFill();
        }
        private void FillCombo()
        {
            List<PreferencePlaces> listPlaces = PreferencePlacesBL.GetPreferencePlaces();
            foreach (PreferencePlaces place in listPlaces)
            {
                ListItem litem2 = new ListItem();
                litem2.Text = place.Places;
                litem2.Value = place.Places;
                cmbPlacesPreference.Items.Add(litem2);
            }
        }

        //Al editar rellena los datos del perfil en los campos de la mascarila 
        private void LoadFieldsInTemplate()
        {
            if (ObjStar2Dcpsl != null)
            {
                try
                {

                    txtPcc.Text = ObjStar2Dcpsl.Pcc;
                    pcc = txtPcc.Text;
                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.Level1))
                    {
                        txtProfileNameFirstLevel.Text = ObjStar2Dcpsl.Level1;
                    }
                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.Level2))
                    {
                        txtProfileNameEmployee.Text = ObjStar2Dcpsl.Level2;
                    }

                    cmbPhoneCode.SelectedItem = ObjStar2Dcpsl.DirectPhoneCode;

                    cmbOfficePhoneCode.SelectedItem = ObjStar2Dcpsl.OfficePhoneCode;

                    txtName.Text = ObjStar2Dcpsl.Name;
                    txtLastName.Text = ObjStar2Dcpsl.LastName;
                    txtOfficePhone.Text = ObjStar2Dcpsl.OfficePhone;
                    txtExt.Text = ObjStar2Dcpsl.Ext;
                    cmbOfficePhoneCode.SelectedItem = 1;
                    txtPhone.Text = ObjStar2Dcpsl.DirectPhone;
                    cmbPhoneCode.SelectedItem = 1;
                    txtEmail.Text = ObjStar2Dcpsl.Email;

                    cmbMonthPreferences.Text = ObjStar2Dcpsl.MonthPreferences;
                    cmbPlacesPreference.Text = ObjStar2Dcpsl.PlacePreferences;
                    cmbWantInformation.Text = ObjStar2Dcpsl.WantInformation;

                    txtMiddleName.Text = ObjStar2Dcpsl.MiddleName;
                    cmbGender.Text = ObjStar2Dcpsl.Gender;


                    String[] texts;
                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.FrequentFlyer1))
                    {
                        texts = ObjStar2Dcpsl.FrequentFlyer1.Split(new String[] { "*#*" }, 5, StringSplitOptions.None);
                        txtFFAirlineCode1.Text = texts[0];
                        txtFFCode1.Text = texts[1];
                        txtFFName1.Text = texts[2];
                    }

                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.FrequentFlyer2))
                    {
                        texts = ObjStar2Dcpsl.FrequentFlyer2.Split(new String[] { "*#*" }, 5, StringSplitOptions.None);
                        txtFFAirlineCode2.Text = texts[0];
                        txtFFCode2.Text = texts[1];
                        txtFFName2.Text = texts[2];
                    }

                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.FrequentFlyer3))
                    {
                        texts = ObjStar2Dcpsl.FrequentFlyer3.Split(new String[] { "*#*" }, 5, StringSplitOptions.None);
                        txtFFAirlineCode3.Text = texts[0];
                        txtFFCode3.Text = texts[1];
                        txtFFName3.Text = texts[2];
                    }

                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.FrequentFlyer4))
                    {
                        texts = ObjStar2Dcpsl.FrequentFlyer4.Split(new String[] { "*#*" }, 5, StringSplitOptions.None);
                        txtFFAirlineCode4.Text = texts[0];
                        txtFFCode4.Text = texts[1];
                        txtFFName4.Text = texts[2];
                    }

                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.FrequentFlyer5))
                    {
                        texts = ObjStar2Dcpsl.FrequentFlyer5.Split(new String[] { "*#*" }, 5, StringSplitOptions.None);
                        txtFFAirlineCode5.Text = texts[0];
                        txtFFCode5.Text = texts[1];
                        txtFFName5.Text = texts[2];
                    }
                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.Passport))
                    {
                        texts = ObjStar2Dcpsl.Passport.Split(new String[] { "*#*" }, 5, StringSplitOptions.None);
                        texts = acompletarArray(texts, 5);
                        txtPassportNum.Text = texts[0];
                        cmbPassportVigencyMonth.Text = texts[1];
                        cmbPassportVigencyYear.Text = texts[2];
                        txtCountry.Text = texts[3];
                        txtNameOn.Text = texts[4];
                    }
                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.Passport2))
                    {
                        texts = ObjStar2Dcpsl.Passport2.Split(new String[] { "*#*" }, 5, StringSplitOptions.None);
                        texts = acompletarArray(texts, 5);
                        txtPassportNum2.Text = texts[0];
                        cmbPassportVigencyMonth2.Text = texts[1];
                        cmbPassportVigencyYear2.Text = texts[2];
                        txtCountry2.Text = texts[3];
                        txtNameOn2.Text = texts[4];
                    }
                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.Passport3))
                    {
                        texts = ObjStar2Dcpsl.Passport3.Split(new String[] { "*#*" }, 5, StringSplitOptions.None);
                        texts = acompletarArray(texts, 5);
                        txtPassportNum3.Text = texts[0];
                        cmbPassportVigencyMonth3.Text = texts[1];
                        cmbPassportVigencyYear3.Text = texts[2];
                        txtCountry3.Text = texts[3];
                        txtNameOn3.Text = texts[4];
                    }
                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.Birthday))
                    {
                        texts = ObjStar2Dcpsl.Birthday.Split(new String[] { "*#*" }, 5, StringSplitOptions.None);
                        cmbBirthdayDay.Text = texts[0];
                        cmbBirthDayMonth.Text = texts[1];
                        cmbBirthDayYear.Text = texts[2];
                    }

                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.Visa))
                    {

                        texts = ObjStar2Dcpsl.Visa.Split(new String[] { "*#*" }, 5, StringSplitOptions.None);
                        texts = acompletarArray(texts, 5);
                        txtVisaNum.Text = texts[0];
                        cmbVigencyVisaMonth.Text = texts[1];
                        cmbVigencyVisaYear.Text = texts[2];
                        txtVisaCountry.Text = texts[3];
                    }

                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.ImmigrationForm))
                    {
                        texts = ObjStar2Dcpsl.ImmigrationForm.Split(new String[] { "*#*" }, 5, StringSplitOptions.None);
                        txtMigratoryForm.Text = texts[0];
                        txtMigratoryNum.Text = texts[1];
                    }

                    txtRFC.Text = ObjStar2Dcpsl.Rfc;

                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.CreditCar))
                    {
                        try
                        {
                            texts = ObjStar2Dcpsl.CreditCar.Split(new String[] { "*#*" }, 15, StringSplitOptions.None);
                            texts = acompletarArray(texts, 15);
                            cmbCreditCardCode.Text = texts[0];
                            txtCreditCardNumber.Text = texts[1];
                            cmbCreditCardMonth.Text = texts[2];
                            cmbCreditCardYear.Text = texts[3];
                            txtNameonCard.Text = texts[4];
                            txtHomeAddressCard.Text = texts[5];
                            txtCityCard.Text = texts[6];
                            txtStateCard.Text = texts[7];
                            txtCVV.Text = new string(Common.toDecrypt(texts[14]).Where(char.IsDigit).ToArray());
                            txtCountryCard.Text = texts[8];
                            txtZIPCard.Text = texts[9];
                            cmbDisplayName.Text = texts[10];
                            if (texts[11] == "Y")
                            {
                                chkAllowAir1.Checked = true;
                            }
                            if (texts[12] == "Y")
                            {
                                chkAllowCar1.Checked = true;
                            }
                            if (texts[13] == "Y")
                            {
                                chkAllowHtl1.Checked = true;
                            }

                        }
                        catch { }
                    }
                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.CreditCard2))
                    {
                        try
                        {

                            texts = ObjStar2Dcpsl.CreditCard2.Split(new String[] { "*#*" }, 15, StringSplitOptions.None);
                            texts = acompletarArray(texts, 15);
                            cmbCreditCardCode2.Text = texts[0];
                            txtCreditCardNumber2.Text = texts[1];
                            cmbCreditCardMonth2.Text = texts[2];
                            cmbCreditCardYear2.Text = texts[3];
                            txtNameonCard2.Text = texts[4];
                            txtHomeAddressCard2.Text = texts[5];
                            txtCityCard2.Text = texts[6];
                            txtStateCard2.Text = texts[7];
                            txtCVV2.Text = new string(Common.toDecrypt(texts[14]).Where(char.IsDigit).ToArray());
                            txtCountryCard2.Text = texts[8];
                            txtZIPCard2.Text = texts[9];
                            cmbDisplayName2.Text = texts[10];
                            if (texts[11] == "Y")
                            {
                                chkAllowAir2.Checked = true;
                            }
                            if (texts[12] == "Y")
                            {
                                chkAllowCar2.Checked = true;
                            }
                            if (texts[13] == "Y")
                            {
                                chkAllowHtl2.Checked = true;
                            }
                        }
                        catch { }
                    }
                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.CreditCard3))
                    {
                        try
                        {
                            texts = ObjStar2Dcpsl.CreditCard3.Split(new String[] { "*#*" }, 15, StringSplitOptions.None);
                            texts = acompletarArray(texts, 15);
                            cmbCreditCardCode3.Text = texts[0];
                            txtCreditCardNumber3.Text =texts[1];
                            cmbCreditCardMonth3.Text = texts[2];
                            cmbCreditCardYear3.Text = texts[3];
                            txtNameonCard3.Text = texts[4];
                            txtHomeAddressCard3.Text = texts[5];
                            txtCityCard3.Text = texts[6];
                            txtStateCard3.Text = texts[7];
                            txtCVV3.Text = new string(Common.toDecrypt(texts[14]).Where(char.IsDigit).ToArray());
                            txtCountryCard3.Text = texts[8];
                            txtZIPCard3.Text = texts[9];
                            cmbDisplayName3.Text = texts[10];
                            if (texts[11] == "Y")
                            {
                                chkAllowAir3.Checked = true;
                            }
                            if (texts[12] == "Y")
                            {
                                chkAllowCar3.Checked = true;
                            }
                            if (texts[13] == "Y")
                            {
                                chkAllowHtl3.Checked = true;
                            }
                        }
                        catch { }
                    }



                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.EmployeeID))
                    {
                        texts = ObjStar2Dcpsl.EmployeeID.Split(new String[] { "*#*" }, 7, StringSplitOptions.None);
                        texts = acompletarArray(texts, 7);
                        txtEmployeeID.Text = texts[0];
                        cmbEmployeeIDRMK1.Text = texts[1];
                        cmbEmployeeIDRMK2.Text = texts[2];
                        cmbEmployeeIDOSI.Text = texts[3];
                        txtPrefix1.Text = texts[4];
                        txtSuffix1.Text = texts[5];
                        cmbLine1.Text = texts[6];
                    }
                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.TravelClass))
                    {
                        //texts = ObjStar2Dcpsl.TravelClass.Split(new String[] { "*#*" }, 7, StringSplitOptions.None);
                        cmbTravelClass.Text = ObjStar2Dcpsl.TravelClass;
                        //cmbTravelClassRMK1.Text = texts[1];
                        //cmbTravelClassRMK2.Text = texts[2];
                        //cmbTravelClassOSI.Text = texts[3];
                        //txtPrefix2.Text = texts[4];
                        //txtSuffix2.Text = texts[5];
                        //cmbLine2.Text = texts[6];
                    }
                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.Division))
                    {
                        texts = ObjStar2Dcpsl.Division.Split(new String[] { "*#*" }, 7, StringSplitOptions.None);
                        texts = acompletarArray(texts, 7);
                        txtUnitDivision.Text = texts[0];
                        cmbDivisionRMK1.Text = texts[1];
                        cmbDivisionRMK2.Text = texts[2];
                        cmbDivisionOSI.Text = texts[3];
                        txtPrefix3.Text = texts[4];
                        txtSuffix3.Text = texts[5];
                        cmbLine3.Text = texts[6];
                    }
                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.CostCenter))
                    {
                        texts = ObjStar2Dcpsl.CostCenter.Split(new String[] { "*#*" }, 7, StringSplitOptions.None);
                        texts = acompletarArray(texts, 7);
                        txtCostCenter.Text = texts[0];
                        cmbCostCenterRMK1.Text = texts[1];
                        cmbCostCenterRMK2.Text = texts[2];
                        cmbCostCenterOSI.Text = texts[3];
                        txtPrefix4.Text = texts[4];
                        txtSuffix4.Text = texts[5];
                        cmbLine4.Text = texts[6];
                    }
                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.ManagerLoginID))
                    {
                        texts = ObjStar2Dcpsl.ManagerLoginID.Split(new String[] { "*#*" }, 7, StringSplitOptions.None);
                        texts = acompletarArray(texts, 7);
                        txtManagerLogin.Text = texts[0];
                        cmbLoginManagerIDRMK1.Text = texts[1];
                        cmbLoginManagerIDRMK2.Text = texts[2];
                        cmbLoginManagerIDOSI.Text = texts[3];
                        txtPrefix5.Text = texts[4];
                        txtSuffix5.Text = texts[5];
                        cmbLine5.Text = texts[6];
                    }
                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.Position_Title))
                    {
                        texts = ObjStar2Dcpsl.Position_Title.Split(new String[] { "*#*" }, 7, StringSplitOptions.None);
                        texts = acompletarArray(texts, 7);
                        txtPositionTitle.Text = texts[0];
                        cmbTitleRMK1.Text = texts[1];
                        cmbTitleRMK2.Text = texts[2];
                        cmbTitleOSI.Text = texts[3];
                        txtPrefix6.Text = texts[4];
                        txtSuffix6.Text = texts[5];
                        cmbLine6.Text = texts[6];
                    }
                    //if (!string.IsNullOrEmpty(ObjStar2Dcpsl.CustomerField1))
                    //{
                    //    texts = ObjStar2Dcpsl.CustomerField1.Split(new String[] { "*#*" }, 7, StringSplitOptions.None);
                    //    txtCustomeField1.Text = texts[0];
                    //    cmbCustomeField1RMK1.Text = texts[1];
                    //    cmbCustomeField1RMK2.Text = texts[2];
                    //    cmbCustomeField1OSI.Text = texts[3];
                    //    txtPrefix7.Text = texts[4];
                    //    txtSuffix7.Text = texts[5];
                    //    cmbLine7.Text = texts[6];
                    //}
                    //if (!string.IsNullOrEmpty(ObjStar2Dcpsl.CustomerField2))
                    //{
                    //    texts = ObjStar2Dcpsl.CustomerField2.Split(new String[] { "*#*" }, 7, StringSplitOptions.None);
                    //    txtCustomeField2.Text = texts[0];
                    //    cmbCustomeField2RMK1.Text = texts[1];
                    //    cmbCustomeField2RMK2.Text = texts[2];
                    //    cmbCustomeField2OSI.Text = texts[3];
                    //    txtPrefix8.Text = texts[4];
                    //    txtSuffix8.Text = texts[5];
                    //    cmbLine8.Text = texts[6];
                    //}
                    //if (!string.IsNullOrEmpty(ObjStar2Dcpsl.CustomerField3))
                    //{
                    //    texts = ObjStar2Dcpsl.CustomerField3.Split(new String[] { "*#*" }, 7, StringSplitOptions.None);
                    //    txtCustomeField3.Text = texts[0];
                    //    cmbCustomeField3RMK1.Text = texts[1];
                    //    cmbCustomeField3RMK2.Text = texts[2];
                    //    cmbCustomeField3OSI.Text = texts[3];
                    //    txtPrefix9.Text = texts[4];
                    //    txtSuffix9.Text = texts[5];
                    //    cmbLine9.Text = texts[6];
                    //}

                    //---------------------------------------------------------------------------------------------------------

                    txtStreetAndNumber.Text = ObjStar2Dcpsl.StreetAndNumber;
                    txtColony.Text = ObjStar2Dcpsl.Colony;
                    txtCP.Text = ObjStar2Dcpsl.PostalCode;
                    txtState.Text = ObjStar2Dcpsl.Estate;
                    txtCity.Text = ObjStar2Dcpsl.City;
                    txtNames.Text = ObjStar2Dcpsl.Name2;
                    txtNames2.Text = ObjStar2Dcpsl.LastName2;
                    txtLastNames.Text = ObjStar2Dcpsl.Paternal;
                    txtLastName2.Text = ObjStar2Dcpsl.Maternal;
                    txtOcupation.Text = ObjStar2Dcpsl.Occupation;
                    cmbSeat.Text = ObjStar2Dcpsl.Seat;

                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.Family1))
                    {
                        texts = ObjStar2Dcpsl.Family1.Split(new[] { "*#*" }, 5, StringSplitOptions.None);
                        txtFamiliarName1.Text = texts[0];
                        txtFamiliarLastname1.Text = texts[1];
                        txtPassengerType1.Text = texts[2];
                    }


                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.Family2))
                    {
                        texts = ObjStar2Dcpsl.Family2.Split(new[] { "*#*" }, 5, StringSplitOptions.None);
                        txtFamiliarName2.Text = texts[0];
                        txtFamiliarLastname2.Text = texts[1];
                        txtPassengerType2.Text = texts[2];
                    }

                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.Family3))
                    {
                        texts = ObjStar2Dcpsl.Family3.Split(new[] { "*#*" }, 5, StringSplitOptions.None);
                        txtFamiliarName3.Text = texts[0];
                        txtFamiliarLastname3.Text = texts[1];
                        txtPassengerType3.Text = texts[2];
                    }

                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.Family4))
                    {
                        texts = ObjStar2Dcpsl.Family4.Split(new[] { "*#*" }, 5, StringSplitOptions.None);
                        txtFamiliarName4.Text = texts[0];
                        txtFamiliarLastName4.Text = texts[1];
                        txtPassengerType4.Text = texts[2];
                    }

                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.Family5))
                    {
                        texts = ObjStar2Dcpsl.Family5.Split(new[] { "*#*" }, 5, StringSplitOptions.None);
                        txtFamiliarName5.Text = texts[0];
                        txtFamiliarLastName5.Text = texts[1];
                        txtPassengerType5.Text = texts[2];
                    }

                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.Family6))
                    {
                        texts = ObjStar2Dcpsl.Family6.Split(new[] { "*#*" }, 5, StringSplitOptions.None);
                        txtFamiliarName6.Text = texts[0];
                        txtFamiliarLastName6.Text = texts[1];
                        txtPassengerType6.Text = texts[2];
                    }

                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.Comments))
                        ucMultilineSmartTextBox2.Text = ObjStar2Dcpsl.Comments;



                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.HotelCreditCar))
                    {
                        //texts = ObjStar2Dcpsl.HotelCreditCar.Split(new[] { "*#*" }, 5, StringSplitOptions.None);
                        //cmbCreditCardCode2.Text = texts[0];
                        //txtCreditCardNumber2.Text = texts[1];
                        //txtCCVigencyMonth.Text = texts[2];
                        //txtCCVigencyYear.Text = texts[3];

                    }

                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.CadHotel1))
                    {
                        texts = ObjStar2Dcpsl.CadHotel1.Split(new[] { "*#*" }, 5, StringSplitOptions.None);
                        txtHotelCode1.Text = texts[0];
                        txtHotelNumber1.Text = texts[1];
                    }

                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.CadHotel2))
                    {
                        texts = ObjStar2Dcpsl.CadHotel2.Split(new[] { "*#*" }, 5, StringSplitOptions.None);
                        txtHotelCode2.Text = texts[0];
                        txtHotelNumber2.Text = texts[1];
                    }

                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.CadHotel3))
                    {
                        texts = ObjStar2Dcpsl.CadHotel3.Split(new[] { "*#*" }, 5, StringSplitOptions.None);
                        txtHotelCode3.Text = texts[0];
                        txtHotelNumber3.Text = texts[1];
                    }

                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.Leasing1))
                    {
                        texts = ObjStar2Dcpsl.Leasing1.Split(new[] { "*#*" }, 5, StringSplitOptions.None);
                        txtCarAgencyCode1.Text = texts[0];
                        txtCarAgencyNumber1.Text = texts[1];
                    }

                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.Leasing2))
                    {
                        texts = ObjStar2Dcpsl.Leasing2.Split(new[] { "*#*" }, 5, StringSplitOptions.None);
                        txtCarAgencyCode2.Text = texts[0];
                        txtCarAgencyNumber2.Text = texts[1];
                    }

                    if (!string.IsNullOrEmpty(ObjStar2Dcpsl.Leasing3))
                    {
                        texts = ObjStar2Dcpsl.Leasing3.Split(new[] { "*#*" }, 5, StringSplitOptions.None);
                        txtCarAgencyCode3.Text = texts[0];
                        txtCarAgencyNumber3.Text = texts[1];
                    }

                    string osi = GetDynamicProperties("Osi", listFields);
                    string remarks = GetDynamicProperties("Remarks", listFields);
                    string alternativeEmail = GetDynamicProperties("AlternativeEmail", listFields);
                    string historic = GetDynamicProperties("Historic", listFields);
                    string sabreFormats = GetDynamicProperties("SabreFormats", listFields);
                    string[] txtAndLineType;
                    int index = 0;
                    int count = 0;

                    string[] lines = osi.Split('#');
                    int numRows = lines.Length - 1;

                    Panel pnl1Osi = (Panel)ucMultiLineSmartTextOSI.Controls.Find("panel1", false)[0];
                    Button btn = (Button)ucMultiLineSmartTextOSI.Controls.Find("button1", false)[0];

                    int lastCtrlLocation = 60;
                    for (int i = 3; i < numRows; i++)
                    {
                        lastCtrlLocation += 29;
                        LineSmartText lineSmart = new LineSmartText();
                        lineSmart.Location = new System.Drawing.Point(1, lastCtrlLocation);
                        lineSmart.Focus();
                        pnl1Osi.Controls.Add(lineSmart);
                    }


                    foreach (Control ctrl in pnl1Osi.Controls)
                    {
                        try
                        {

                            txtAndLineType = lines[index].Split(',');
                            Panel pnlChild = (Panel)ctrl;
                            SmartTextBox txt = (SmartTextBox)ctrl.Controls[0];
                            ComboBox cmb = (ComboBox)ctrl.Controls[1];


                            txt.Text = txtAndLineType[0];
                            cmb.SelectedItem = txtAndLineType[1];
                            index += 1;
                        }
                        catch
                        {
                            try
                            {
                                Panel Panel = (Panel)ucMultiLineSmartTextOSI.Controls.Find("panel1", false)[0];

                                LineSmartText lineSmart = (LineSmartText)Panel.Controls.Find("LineSmartText", false)[count];

                                Panel pnlText = (Panel)lineSmart.Controls.Find("panel2", false)[0];

                                txtAndLineType = lines[index].Split(',');

                                SmartTextBox txt = (SmartTextBox)pnlText.Controls[0];
                                ComboBox cmb = (ComboBox)pnlText.Controls[1];

                                txt.Text = txtAndLineType[0];
                                cmb.SelectedItem = txtAndLineType[1];
                                index += 1;
                                count += 1;
                            }
                            catch { }
                        }

                    }

                    count = 0;
                    lines = remarks.Split('#');
                    numRows = lines.Length - 1;

                    Panel pnl1Remarks = (Panel)ucMultiTextRemarks1.Controls.Find("panel1", false)[0];
                    btn = (Button)ucMultiTextRemarks1.Controls.Find("button1", false)[0];

                    index = 0;
                    lastCtrlLocation = 62;
                    for (int i = 3; i < numRows; i++)
                    {
                        lastCtrlLocation += 29;
                        LineTextRemark lineSmart = new LineTextRemark();
                        lineSmart.Location = new System.Drawing.Point(1, lastCtrlLocation);
                        lineSmart.Focus();
                        pnl1Remarks.Controls.Add(lineSmart);
                    }


                    foreach (Control ctrl in pnl1Remarks.Controls)
                    {
                        try
                        {
                            txtAndLineType = lines[index].Split(',');
                            Panel pnlChild = (Panel)ctrl;
                            SmartTextBox txt = (SmartTextBox)ctrl.Controls[0];
                            ComboBox cmb = (ComboBox)ctrl.Controls[2];
                            ComboBox cmb2 = (ComboBox)ctrl.Controls[1];

                            txt.Text = txtAndLineType[0];
                            cmb.SelectedItem = txtAndLineType[1];
                            if (!string.IsNullOrEmpty(txtAndLineType[2]))
                            {
                                if (txtAndLineType[2].Equals("."))
                                    cmb2.SelectedItem = "Contable";
                                else if (txtAndLineType[2].Equals(Resources.Constants.CROSSLORAINE))
                                    cmb2.SelectedItem = "Itinerario";
                                else if (txtAndLineType[2].Equals("H-"))
                                    cmb2.SelectedItem = "Histórico";
                            }
                            else
                            {
                                cmb2.SelectedItem = null;
                            }
                            index += 1;
                        }
                        catch
                        {
                            try
                            {
                                Panel Panel = (Panel)ucMultiTextRemarks1.Controls.Find("panel1", false)[0];

                                LineTextRemark lineSmart = (LineTextRemark)Panel.Controls.Find("LineTextRemark", false)[count];

                                Panel pnlText = (Panel)lineSmart.Controls.Find("panel2", false)[0];

                                SmartTextBox txt = (SmartTextBox)pnlText.Controls[0];
                                ComboBox cmb = (ComboBox)pnlText.Controls[2];
                                ComboBox cmb2 = (ComboBox)pnlText.Controls[1];

                                txtAndLineType = lines[index].Split(',');

                                txt.Text = txtAndLineType[0];
                                cmb.SelectedItem = txtAndLineType[1];

                                if (!string.IsNullOrEmpty(txtAndLineType[2]))
                                {
                                    if (txtAndLineType[2].Equals("."))
                                        cmb2.SelectedItem = "Contable";
                                    else if (txtAndLineType[2].Equals(Resources.Constants.CROSSLORAINE))
                                        cmb2.SelectedItem = "Itinerario";
                                    else if (txtAndLineType[2].Equals("H-"))
                                        cmb2.SelectedItem = "Histórico";
                                }
                                else
                                {
                                    cmb2.SelectedItem = null;
                                }
                                index += 1;
                                count += 1;
                            }
                            catch { }
                        }
                    }

                    count = 0;
                    lines = alternativeEmail.Split('#');
                    numRows = lines.Length - 1;

                    Panel pnl1AlterEmail = (Panel)ucMultiLineSmartTextAlternativeEmail.Controls.Find("panel1", false)[0];
                    btn = (Button)ucMultiLineSmartTextAlternativeEmail.Controls.Find("button1", false)[0];

                    lastCtrlLocation = 60;
                    for (int i = 3; i < numRows; i++)
                    {
                        lastCtrlLocation += 29;
                        LineSmartText lineSmart = new LineSmartText();
                        lineSmart.Location = new System.Drawing.Point(1, lastCtrlLocation);
                        lineSmart.Focus();
                        pnl1AlterEmail.Controls.Add(lineSmart);
                    }

                    index = 0;
                    foreach (Control ctrl in pnl1AlterEmail.Controls)
                    {
                        try
                        {
                            txtAndLineType = lines[index].Split(',');
                            Panel pnlChild = (Panel)ctrl;
                            SmartTextBox txt = (SmartTextBox)ctrl.Controls[0];
                            ComboBox cmb = (ComboBox)ctrl.Controls[1];

                            txt.Text = txtAndLineType[0];
                            cmb.SelectedItem = txtAndLineType[1];
                            index += 1;
                        }
                        catch
                        {
                            try
                            {
                                Panel Panel = (Panel)ucMultiLineSmartTextAlternativeEmail.Controls.Find("panel1", false)[0];

                                LineSmartText lineSmart = (LineSmartText)Panel.Controls.Find("LineSmartText", false)[count];

                                Panel pnlText = (Panel)lineSmart.Controls.Find("panel2", false)[0];

                                txtAndLineType = lines[index].Split(',');

                                SmartTextBox txt = (SmartTextBox)pnlText.Controls[0];
                                ComboBox cmb = (ComboBox)pnlText.Controls[1];

                                txt.Text = txtAndLineType[0];
                                cmb.SelectedItem = txtAndLineType[1];
                                index += 1;
                                count += 1;
                            }
                            catch { }
                        }
                    }


                    count = 0;
                    lines = sabreFormats.Split('#');
                    numRows = lines.Length - 1;

                    Panel pnlSabreFormats = (Panel)ucMultiLineSmartTextSabreFormat.Controls.Find("panel1", false)[0];

                    lastCtrlLocation = 60;
                    for (int i = 3; i < numRows; i++)
                    {
                        lastCtrlLocation += 29;
                        LineSmartText lineSmart = new LineSmartText();
                        lineSmart.Location = new System.Drawing.Point(1, lastCtrlLocation);
                        lineSmart.Focus();
                        pnlSabreFormats.Controls.Add(lineSmart);
                    }

                    index = 0;
                    foreach (Control ctrl in pnlSabreFormats.Controls)
                    {
                        try
                        {
                            txtAndLineType = lines[index].Split(',');
                            Panel pnlChild = (Panel)ctrl;
                            SmartTextBox txt = (SmartTextBox)ctrl.Controls[0];
                            ComboBox cmb = (ComboBox)ctrl.Controls[1];

                            txt.Text = txtAndLineType[0];
                            cmb.SelectedItem = txtAndLineType[1];
                            index += 1;
                        }
                        catch
                        {
                            try
                            {
                                Panel Panel = (Panel)ucMultiLineSmartTextSabreFormat.Controls.Find("panel1", false)[0];

                                LineSmartText lineSmart = (LineSmartText)Panel.Controls.Find("LineSmartText", false)[count];

                                Panel pnlText = (Panel)lineSmart.Controls.Find("panel2", false)[0];

                                txtAndLineType = lines[index].Split(',');

                                SmartTextBox txt = (SmartTextBox)pnlText.Controls[0];
                                ComboBox cmb = (ComboBox)pnlText.Controls[1];

                                txt.Text = txtAndLineType[0];
                                cmb.SelectedItem = txtAndLineType[1];
                                index += 1;
                                count += 1;
                            }
                            catch { }
                        }
                    }

                    if (!string.IsNullOrEmpty(historic))
                    {
                        lvHistoric.Items.Clear();
                        string[] histLines = historic.Split('#');
                        for (int i = 1; i < histLines.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(histLines[i]))
                                lvHistoric.Items.Add(histLines[i]);
                        }
                        ColumnHeader header = new ColumnHeader();
                        header.Name = "Perfiles Históricos";

                        lvHistoric.View = System.Windows.Forms.View.Details;
                        lvHistoric.Columns.Add(header);
                    }
                }

                catch (Exception e)
                {
                    MessageBox.Show(
                        @"No se pudo cargar el perfil en la mascarilla por un error de incongruencia de datos",
                        @"Error al cargar el perfil");
                }
            }

            ComboFill();


        }

        private string[] acompletarArray(string[] entrada, int isalida)
        {
            string[] salida = new string[isalida];
            for (int i = 0; i < salida.Count(); i++)
            {
                salida[i] = "";
            }
            for (int i = 0; i < entrada.Count(); i++)
            {
                salida[i] = entrada[i];
            }
            return salida;
        }

        private void ComboFill()
        {
            cmbCreditCardYear.Items.Clear();
            for (int i = DateTime.Now.Year; i < DateTime.Now.Year + 15; i++)
            {
                string a = i.ToString().Substring(2, 2);
                cmbPassportVigencyYear.Items.Add(a);
                cmbPassportVigencyYear2.Items.Add(a);
                cmbPassportVigencyYear3.Items.Add(a);
                cmbVigencyVisaYear.Items.Add(a);
                cmbCreditCardYear.Items.Add(a);
                cmbCreditCardYear2.Items.Add(a);
                cmbCreditCardYear3.Items.Add(a);

            }

            for (int w = DateTime.Now.Year; w > DateTime.Now.Year - 100; w--)
            {
                string b = w.ToString().Substring(2, 2);
                cmbBirthDayYear.Items.Add(b);
            }
        }

        //Evento btnAccept_Click
        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                string email = string.Empty;
                if (!IsValidBusinessRules)
                {
                    int j = 0;

                    foreach (var d in lstFisico)
                    {
                        if(dataGridView.Rows.Count >0)
                        if (dataGridView.Rows[j].Cells["Documento"].Value == null)
                        {
                            MessageBox.Show("El nombre del documento no puede estar vacio", "MyCTS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            lstFisico[j].NameDocument = dataGridView.Rows[j].Cells["Documento"].Value.ToString();
                        }

                        j++;
                    }

                    foreach (var item in lst)
                    {
                        var nameDoc = from a in lstFisico
                                            where a.Name == item.Name && a.Image == item.Image
                                            select a.NameDocument;
                        foreach (var itemDoc in nameDoc)
                        {
                            item.NameDocument = itemDoc;
                        }
                           
                        
                    }

                    txtName.Text = txtName.Text.TrimStart();
                    txtLastName.Text = txtLastName.Text.TrimStart();
                    txtMiddleName.Text = txtMiddleName.Text.TrimStart();

                    typeLine.Add(cmbLine1.Text);
                    //typeLine.Add(cmbLine2.Text);
                    typeLine.Add(cmbLine3.Text);
                    typeLine.Add(cmbLine4.Text);
                    typeLine.Add(cmbLine5.Text);
                    typeLine.Add(cmbLine6.Text);
                    //typeLine.Add(cmbLine7.Text);
                    //typeLine.Add(cmbLine8.Text);
                    //typeLine.Add(cmbLine9.Text);

                    LoadFiels();

                    //GetPreviousControlValues();

                    DialogResult result;
                    if (_isUpdate)
                    {
                        List<Star2Details> star2list = Get2StarEmailBL.Get2StarEmail(txtEmail.Text, string.Concat("%", txtEmail.Text, "%"));
                        if (star2list.Count == 0 || (star2list.Count <= 1 && txtProfileNameEmployee.Text == star2list[0].Name) || string.IsNullOrEmpty(star2list[0].Name))
                            result =
                               MessageBox.Show(
                                   string.Concat(Constants.UPDATE_PROFILE_CONFIRMATION_SECOND_LEVEL, ":  \n",
                                                 ObjStar2Dcpsl.Level2), Resources.Constants.MYCTS, MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Information);
                        else
                        {
                            if (star2list[0].Name == txtProfileNameEmployee.Text)
                            {
                                result =
                               MessageBox.Show(
                                   string.Concat(Constants.UPDATE_PROFILE_CONFIRMATION_SECOND_LEVEL, ":  \n",
                                                 ObjStar2Dcpsl.Level2), Resources.Constants.MYCTS, MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Information);
                            }
                            else
                            {
                                string profiles = string.Empty;
                                for (int i = 0; i < star2list.Count; i++)
                                {
                                    profiles = string.Concat(profiles, star2list[i].Level1, "    ", star2list[i].Name, "    ", txtEmail.Text, "\n");
                                }
                                MessageBox.Show(Constants.EMAIL_EXIST + "\n\n" + profiles, Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                txtEmail.Focus();
                                result = DialogResult.No;
                            }
                        }
                    }
                    else
                    {
                        List<Star2Details> star2list = Get2StarEmailBL.Get2StarEmail(txtEmail.Text, string.Concat("%", txtEmail.Text, "%"));
                        _isNew = true;
                        if (star2list.Count == 0)
                            result =
                                MessageBox.Show(
                                    string.Concat(Constants.CREATE_PROFILE_CONFIRMATION, ":  \n",
                                                  ObjStar2Dcpsl.Level2), Resources.Constants.MYCTS, MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Information);
                        else if (!string.IsNullOrEmpty(star2list[0].Name))
                        {
                            string profiles = string.Empty;
                            for (int i = 0; i < star2list.Count; i++)
                            {
                                profiles = string.Concat(profiles, star2list[i].Level1, "    ", star2list[i].Name, "    ", txtEmail.Text, "\n");
                            }
                            MessageBox.Show(Constants.EMAIL_EXIST + "\n\n" + profiles, Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            txtEmail.Focus();
                            result = DialogResult.No;
                        }
                        else
                        {
                            result =
                                  MessageBox.Show(
                                      string.Concat(Constants.CREATE_PROFILE_CONFIRMATION, ":  \n",
                                                    ObjStar2Dcpsl.Level2), Resources.Constants.MYCTS, MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Information);
                        }
                    }


                    if (result.Equals(DialogResult.Yes))
                    {
                        FieldsDynamicsBL fd = new FieldsDynamicsBL();


                        if (_isUpdate && !_isUpadateNewFormat)
                        {
                            SetIndexDbTable();
                            fd.SetOrUpdateStar(listFields2, int.Parse(ObjStar2Dcpsl.Id), 2);
                            //fd.SetOrUpdateStar(ObjStar2Dcpsl, int.Parse(ObjStar2Dcpsl.Id), 2);
                            SetLogNewFormatProfilesBL.SetLogNewFormatProfiles(ObjStar2Dcpsl.Pcc, Login.NombreCompleto, ObjStar2Dcpsl.Level1, ObjStar2Dcpsl.Level2, DateTime.Now);

                            ucProfileSearch.star2Info = objProfilesMethods.FormatSabreProfile2L(ObjStar2Dcpsl);
                            foreach (Star2ndLevelInfo content in ucProfileSearch.star2Info)
                            {
                                SetStarsLevel2InfoBL.AddStarsLevel2Info(ObjStar2Dcpsl.Pcc, ObjStar2Dcpsl.Level1, ObjStar2Dcpsl.Level2, content.Type, content.Text, DateTime.Now, false);
                            }
                        }

                        else if (_isUpadateNewFormat)
                        {
                            SetIndexDbTable();
                            fd.SetOrUpdateStar(listFields2, null, 2);
                            SetLogNewFormatProfilesBL.SetLogNewFormatProfiles(ObjStar2Dcpsl.Pcc, Login.NombreCompleto, ObjStar2Dcpsl.Level1, ObjStar2Dcpsl.Level2, DateTime.Now);

                            ucProfileSearch.star2Info = objProfilesMethods.FormatSabreProfile2L(ObjStar2Dcpsl);
                            foreach (Star2ndLevelInfo content in ucProfileSearch.star2Info)
                            {
                                SetStarsLevel2InfoBL.AddStarsLevel2Info(ObjStar2Dcpsl.Pcc, ObjStar2Dcpsl.Level1, ObjStar2Dcpsl.Level2, content.Type, content.Text, DateTime.Now, false);
                            }
                        }
                        else
                        {
                            SetStarsLevel2BL.AddStarslevel2(pcc, ObjStar2Dcpsl.Level1, ObjStar2Dcpsl.Level2, true, ObjStar2Dcpsl.Email);
                            fd.SetOrUpdateStar(listFields2, null, 2);
                            SetLogNewFormatProfilesBL.SetLogNewFormatProfiles(ObjStar2Dcpsl.Pcc, Login.NombreCompleto, ObjStar2Dcpsl.Level1, ObjStar2Dcpsl.Level2, DateTime.Now);

                            ucProfileSearch.star2Info = objProfilesMethods.FormatSabreProfile2L(ObjStar2Dcpsl);
                            foreach (Star2ndLevelInfo content in ucProfileSearch.star2Info)
                            {
                                SetStarsLevel2InfoBL.AddStarsLevel2Info(ObjStar2Dcpsl.Pcc, ObjStar2Dcpsl.Level1, ObjStar2Dcpsl.Level2, content.Type, content.Text, DateTime.Now, false);
                            }
                        }

                        foreach (var d in lst)
                        {
                            if (d.ImageId >= 1)
                            {
                                bool success = MyCTS.Business.DocsSecondLevelBL.UpdateImage(d);
                            }
                            else
                            {
                                if (d.ProfileId == null || d.ProfileId == 0)
                                {
                                    List<Dynamic> listFields = FieldsDynamicsBL.GetStar2Details(ObjStar2Dcpsl.Pcc, ObjStar2Dcpsl.Level1, ObjStar2Dcpsl.Level2);
                                    d.ProfileId = int.Parse(GetDynamicProperties("id", listFields));
                                }
                                else
                                {
                                    d.ProfileId = int.Parse(ObjStar2Dcpsl.Id);
                                }
                                
                                bool success = MyCTS.Business.DocsSecondLevelBL.AddImage(d);
                            }
                        }
                        lst.Clear();
                        ticketProfile++;
                        bool open= false;

                        if (ListObjStar2Dcpsl.Count != 0)
                        {
                            if (ticketProfile != ListObjStar2Dcpsl.Count)
                            {
                                open = true;
                                MessageBox.Show("EL PERFIL HA SIDO ACTUALIZADO CON ÉXITO EN LA NUEVA ESTRUCTURA, YA PUEDES COMENZAR A TRABAJAR CON ÉL " + ObjStar2Dcpsl.Level2 + "\n    CONTINUARA CON EL SIGUIENTE PASAJERO .", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                                LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_SECOND_LEVEL_PROFILES);

                            }
                        }

                        if (!open)
                        {
                            ticketProfile = 0;
                            frmProfiles.IsTicket = false;
                            LoadUcProfileInfoDisplay();
                            ObjStar2Dcpsl = null;
                        }

                    }
                    // LoaderProfiles.AddToPanelWithParameters(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_PROFILE_SECOND_LEVEL_CONTINUE, parameters);
                }
            }
            catch (Exception Err)
            {
                frmProfiles.IsTicket = false;
                throw new Exception();
            }
        }



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
        private bool ExistEmailInProfiles(string eMail, int Operation)
        {
            var objStar2Profiles = new GetStar2ProfileByEmailBL();
            var listProfiles = objStar2Profiles.GetStar2LevelInfo(eMail);
            if (listProfiles.Count <= 1 && Operation > 1)
                return false;

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
                if (string.IsNullOrEmpty(pcc) && string.IsNullOrEmpty(Parameters[3]))
                {
                    MessageBox.Show(@"SELECCIONA LA ESTRELLA DE PRIMER NIVEL DEL PREDICTVO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtProfileNameFirstLevel.Focus();
                    return isValid;
                }
                else if (string.IsNullOrEmpty(txtProfileNameEmployee.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_NOMBRE_PERFIL_2DO_NIVEL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtProfileNameEmployee.Focus();
                    return isValid;
                }
                else if (!string.IsNullOrEmpty(txtProfileNameEmployee.Text) && !ValidateRegularExpression.ValidateProfile2ndLevelNameFormat(txtProfileNameEmployee.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.PERFIL_EMPLEADO_DEBE_CONTENER_DIAGONAL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtProfileNameEmployee.Focus();
                    return isValid;

                }
                else if (OperationType < 2 && !string.IsNullOrEmpty(txtProfileNameEmployee.Text) && !string.IsNullOrEmpty(txtProfileNameFirstLevel.Text) &&
                    IsValid2ndStarName)
                {
                    MessageBox.Show(Resources.Profiles.Profiles.NOMBRE_PERFIL_EXISTENTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtProfileNameEmployee.Focus();

                }
                else if (string.IsNullOrEmpty(txtName.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.DEBES_INGRESAR_NOMBRE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Focus();
                    return isValid;
                }
                else if (string.IsNullOrEmpty(txtLastName.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.DEBES_INGRESAR_APELLIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLastName.Focus();
                    return isValid;
                }
                else if (string.IsNullOrEmpty(txtOfficePhone.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.DEBES_INGRESAR_NUMERO_TELEFONICO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtOfficePhone.Focus();
                    return isValid;
                }
                else if (!string.IsNullOrEmpty(txtOfficePhone.Text) && !txtOfficePhone.Text.Length.Equals(10))
                {
                    MessageBox.Show("EL NÚMERO TELEFONICO DEBE SER DE 10 DÍGITOS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtOfficePhone.Focus();
                    return isValid;
                }
                else if (string.IsNullOrEmpty(cmbOfficePhoneCode.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_TIPO_TELEFONO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbOfficePhoneCode.Focus();
                    return isValid;
                }
                else if (!string.IsNullOrEmpty(txtPhone.Text) && !txtPhone.Text.Length.Equals(10))
                {
                    MessageBox.Show("EL NÚMERO TELEFONICO DEBE SER DE 10 DÍGITOS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPhone.Focus();
                    return isValid;
                }
                else if (string.IsNullOrEmpty(txtEmail.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_EMAIL_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmail.Focus();
                    return isValid;
                }
                else if (!string.IsNullOrEmpty(txtEmail.Text) && !ValidateRegularExpression.ValidateEmailFormat(txtEmail.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.FORMATO_CORREO_ELECT_INCORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmail.Focus();
                }
                else if (!string.IsNullOrEmpty(txtEmail.Text) && (txtEmail.Text.Contains("ANDANTE.COM") || txtEmail.Text.Contains("CTSMEX.COM")))
                {
                    MessageBox.Show("EL CORREO ELECTRÓNICO NO PUEDE SER INGRESADO CON DOMINIO:\n@CTSMEX.COM.MX\n@ANDANTE.COM.MX", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmail.Focus();
                    return isValid;
                }
                else if (ExistEmailInProfiles(remplace_(txtEmail.Text), OperationType))
                {
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
                else if (FieldsMandatory && string.IsNullOrEmpty(cmbBirthdayDay.Text) && string.IsNullOrEmpty(cmbBirthDayMonth.Text) && string.IsNullOrEmpty(cmbBirthDayYear.Text))
                {
                    MessageBox.Show(string.Concat("SE REQUIERE INGRESE", ":  \n", "LA FECHA DE NACIMIENTO", ":  \n", "Dentro de la pestaña de PERFIL DE PASAJERO"), Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbBirthdayDay.Focus();
                }
                else if ((!string.IsNullOrEmpty(cmbBirthdayDay.Text) || !string.IsNullOrEmpty(cmbBirthDayMonth.Text) || !string.IsNullOrEmpty(cmbBirthDayYear.Text)) && !ValidateRegularExpression.ValidateBirthDateFormat(string.Concat(cmbBirthdayDay.Text, cmbBirthDayMonth.Text, cmbBirthDayYear.Text)))
                {
                    MessageBox.Show("DEBES INGRESAR LA FECHA DE NACIMIENTO COMPLETA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbBirthdayDay.Focus();
                }
                else if (!string.IsNullOrEmpty(cmbBirthdayDay.Text) && !string.IsNullOrEmpty(cmbBirthDayMonth.Text) && !string.IsNullOrEmpty(cmbBirthDayYear.Text) && !TryToDate(string.Concat(cmbBirthdayDay.Text, cmbBirthDayMonth.Text, cmbBirthDayYear.Text), 1))
                {
                    MessageBox.Show("DEBES INGRESAR LA FECHA DE NACIMIENTO VÁLIDA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbBirthdayDay.Focus();
                }
                else if (!string.IsNullOrEmpty(txtVisaNum.Text) &&
               (string.IsNullOrEmpty(cmbVigencyVisaMonth.Text) || string.IsNullOrEmpty(cmbVigencyVisaYear.Text)))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_FECHA_VIGENCIA_VISA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrEmpty(cmbVigencyVisaMonth.Text))
                        cmbVigencyVisaMonth.Focus();
                    else if (string.IsNullOrEmpty(cmbVigencyVisaYear.Text))
                        cmbVigencyVisaYear.Focus();
                }
                else if (!string.IsNullOrEmpty(cmbVigencyVisaMonth.Text) && !string.IsNullOrEmpty(cmbVigencyVisaYear.Text) && !TryToDate(string.Concat(string.Empty, cmbVigencyVisaMonth.Text, cmbVigencyVisaYear.Text), 2))
                {
                    MessageBox.Show("DEBES INGRESAR LA FECHA DE VIGENCIA DE VISA VÁLIDA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbBirthdayDay.Focus();
                }

                if(!string.IsNullOrEmpty(txtCreditCardNumber.Text) && (string.IsNullOrEmpty(txtCVV.Text)))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_DATOS_TARJETA_CREDITO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return isValid;
                }

                if (!string.IsNullOrEmpty(txtCreditCardNumber2.Text) && (string.IsNullOrEmpty(txtCVV2.Text)))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_DATOS_TARJETA_CREDITO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return isValid;
                }
                if (!string.IsNullOrEmpty(txtCreditCardNumber3.Text) && (string.IsNullOrEmpty(txtCVV3.Text)))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_DATOS_TARJETA_CREDITO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return isValid;
                }
                 if ((!string.IsNullOrEmpty(cmbCreditCardCode.Text) || !string.IsNullOrEmpty(txtCreditCardNumber.Text) || !string.IsNullOrEmpty(cmbCreditCardMonth.Text) || !string.IsNullOrEmpty(cmbCreditCardYear.Text)) &&
               !(!string.IsNullOrEmpty(cmbCreditCardCode.Text) && !string.IsNullOrEmpty(txtCreditCardNumber.Text) && !string.IsNullOrEmpty(cmbCreditCardMonth.Text) && !string.IsNullOrEmpty(cmbCreditCardYear.Text)))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_DATOS_TARJETA_CREDITO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrEmpty(cmbCreditCardCode.Text))
                        cmbCreditCardCode.Focus();
                    else if (string.IsNullOrEmpty(txtCreditCardNumber.Text))
                        txtCreditCardNumber.Focus();
                    else if (string.IsNullOrEmpty(cmbCreditCardMonth.Text))
                        cmbCreditCardMonth.Focus();
                    else if (string.IsNullOrEmpty(cmbCreditCardYear.Text))
                        cmbCreditCardYear.Focus();
                    return isValid;
                }

                 if ((!string.IsNullOrEmpty(cmbCreditCardCode2.Text) || !string.IsNullOrEmpty(txtCreditCardNumber2.Text) || !string.IsNullOrEmpty(cmbCreditCardMonth2.Text) || !string.IsNullOrEmpty(cmbCreditCardYear2.Text)) &&
!(!string.IsNullOrEmpty(cmbCreditCardCode2.Text) && !string.IsNullOrEmpty(txtCreditCardNumber2.Text) && !string.IsNullOrEmpty(cmbCreditCardMonth2.Text) && !string.IsNullOrEmpty(cmbCreditCardYear2.Text)))
                 {
                     MessageBox.Show(Resources.Profiles.Profiles.INGRESA_DATOS_TARJETA_CREDITO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                     if (string.IsNullOrEmpty(cmbCreditCardCode2.Text))
                         cmbCreditCardCode2.Focus();
                     else if (string.IsNullOrEmpty(txtCreditCardNumber2.Text))
                         txtCreditCardNumber2.Focus();
                     else if (string.IsNullOrEmpty(cmbCreditCardMonth2.Text))
                         cmbCreditCardMonth2.Focus();
                     else if (string.IsNullOrEmpty(cmbCreditCardYear2.Text))
                         cmbCreditCardYear2.Focus();
                     return isValid;
                 }

                if ((!string.IsNullOrEmpty(cmbCreditCardCode3.Text) || !string.IsNullOrEmpty(txtCreditCardNumber3.Text) || !string.IsNullOrEmpty(cmbCreditCardMonth3.Text) || !string.IsNullOrEmpty(cmbCreditCardYear3.Text)) &&
               !(!string.IsNullOrEmpty(cmbCreditCardCode3.Text) && !string.IsNullOrEmpty(txtCreditCardNumber3.Text) && !string.IsNullOrEmpty(cmbCreditCardMonth3.Text) && !string.IsNullOrEmpty(cmbCreditCardYear3.Text)))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_DATOS_TARJETA_CREDITO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrEmpty(cmbCreditCardCode3.Text))
                        cmbCreditCardCode3.Focus();
                    else if (string.IsNullOrEmpty(txtCreditCardNumber3.Text))
                        txtCreditCardNumber3.Focus();
                    else if (string.IsNullOrEmpty(cmbCreditCardMonth3.Text))
                        cmbCreditCardMonth3.Focus();
                    else if (string.IsNullOrEmpty(cmbCreditCardYear3.Text))
                        cmbCreditCardYear3.Focus();
                    return isValid;
                }
                
                if (FieldsMandatory && string.IsNullOrEmpty(cmbMonthPreferences.Text))
                {
                    MessageBox.Show(string.Concat("SE REQUIERE INGRESE", ":  \n", "MES PREFERENTE PARA VACACIONAR", ":  \n", "Dentro de la pestaña de PERFIL DE PASAJERO"), Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbMonthPreferences.Focus();
                }
                else if (FieldsMandatory && string.IsNullOrEmpty(cmbPlacesPreference.Text))
                {
                    MessageBox.Show(string.Concat("SE REQUIERE INGRESE", ":  \n", "LUGAR DE PREFERENCIA PARA VACACIONAR", ":  \n", "Dentro de la pestaña de PERFIL DE PASAJERO"), Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbPlacesPreference.Focus();

                }
                else if (FieldsMandatory && string.IsNullOrEmpty(cmbWantInformation.Text))
                {
                    MessageBox.Show(string.Concat("SE REQUIERE INGRESE", ":  \n", "DESEA RECIBIR INFORMACION DE CTS", ":  \n", "Dentro de la pestaña de PERFIL DE PASAJERO"), Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbPlacesPreference.Focus();

                }
                else if (!string.IsNullOrEmpty(txtEmployeeID.Text) && string.IsNullOrEmpty(cmbEmployeeIDRMK1.Text) &&
                         string.IsNullOrEmpty(cmbEmployeeIDRMK2.Text) && string.IsNullOrEmpty(cmbEmployeeIDOSI.Text))
                {
                    //validaciones
                    MessageBox.Show(string.Concat("SE REQUIERE INGRESE", ":  \n", "REMARK U OSI", ":  \n", "Dentro de la pestaña de DATOS EXTRAS"), Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbEmployeeIDRMK1.Focus();
                }
                else if (!string.IsNullOrEmpty(txtUnitDivision.Text) && string.IsNullOrEmpty(cmbDivisionRMK1.Text) &&
                                string.IsNullOrEmpty(cmbDivisionRMK2.Text) && string.IsNullOrEmpty(cmbDivisionOSI.Text))
                {
                    MessageBox.Show(string.Concat("SE REQUIERE INGRESE", ":  \n", "REMARK U OSI", ":  \n", "Dentro de la pestaña de DATOS EXTRAS"), Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbDivisionRMK1.Focus();
                }
                else if (!string.IsNullOrEmpty(txtCostCenter.Text) && string.IsNullOrEmpty(cmbCostCenterRMK1.Text) &&
                         string.IsNullOrEmpty(cmbCostCenterRMK2.Text) && string.IsNullOrEmpty(cmbCostCenterOSI.Text))
                {
                    MessageBox.Show(string.Concat("SE REQUIERE INGRESE", ":  \n", "REMARK U OSI", ":  \n", "Dentro de la pestaña de DATOS EXTRAS"), Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbCostCenterRMK1.Focus();
                }
                else if (!string.IsNullOrEmpty(txtManagerLogin.Text) && string.IsNullOrEmpty(cmbLoginManagerIDRMK1.Text) &&
                        string.IsNullOrEmpty(cmbLoginManagerIDRMK2.Text) && string.IsNullOrEmpty(cmbLoginManagerIDOSI.Text))
                {
                    MessageBox.Show(string.Concat("SE REQUIERE INGRESE", ":  \n", "REMARK U OSI", ":  \n", "Dentro de la pestaña de DATOS EXTRAS"), Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbLoginManagerIDRMK1.Focus();
                }
                else if (!string.IsNullOrEmpty(txtPositionTitle.Text) && string.IsNullOrEmpty(cmbTitleRMK1.Text) &&
                        string.IsNullOrEmpty(cmbTitleRMK2.Text) && string.IsNullOrEmpty(cmbTitleOSI.Text))
                {
                    MessageBox.Show(string.Concat("SE REQUIERE INGRESE", ":  \n", "REMARK U OSI", ":  \n", "Dentro de la pestaña de DATOS EXTRAS"), Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbTitleRMK1.Focus();
                }
                //else if (!string.IsNullOrEmpty(txtCustomeField1.Text) && string.IsNullOrEmpty(cmbCustomeField1RMK1.Text) &&
                //        string.IsNullOrEmpty(cmbCustomeField1RMK2.Text) && string.IsNullOrEmpty(cmbCustomeField1OSI.Text))
                //{
                //    MessageBox.Show(string.Concat("SE REQUIERE INGRESE", ":  \n", "REMARK U OSI", ":  \n", "Dentro de la pestaña de DATOS EXTRAS"), Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    cmbCustomeField1RMK1.Focus();
                //}
                //else if (!string.IsNullOrEmpty(txtCustomeField2.Text) && string.IsNullOrEmpty(cmbCustomeField2RMK1.Text) &&
                //    string.IsNullOrEmpty(cmbCustomeField2RMK2.Text) && string.IsNullOrEmpty(cmbCustomeField2OSI.Text))
                //{
                //    MessageBox.Show(string.Concat("SE REQUIERE INGRESE", ":  \n", "REMARK U OSI", ":  \n", "Dentro de la pestaña de DATOS EXTRAS"), Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    cmbCustomeField2RMK1.Focus();
                //}
                //else if (!string.IsNullOrEmpty(txtCustomeField3.Text) && string.IsNullOrEmpty(cmbCustomeField3RMK1.Text) &&
                //string.IsNullOrEmpty(cmbCustomeField3RMK2.Text) && string.IsNullOrEmpty(cmbCustomeField3OSI.Text))
                //{
                //    MessageBox.Show(string.Concat("SE REQUIERE INGRESE", ":  \n", "REMARK U OSI", ":  \n", "Dentro de la pestaña de DATOS EXTRAS"), Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    cmbCustomeField3RMK1.Focus();
                //}
                /*
            else if (string.IsNullOrEmpty(cmbGender.Text))
            {
                MessageBox.Show(string.Concat("SE REQUIERE INGRESE", ":  \n", "GENERO", ":  \n", "Dentro de la pestaña de DATOS EXTRAS"), Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbPlacesPreference.Focus();
            }
                 * */
                else
                {
                    isValid = false;
                }
                Panel pnl1Osi = (Panel)ucMultiLineSmartTextOSI.Controls.Find("panel1", false)[0];
                foreach (Control ctrl in pnl1Osi.Controls)
                {
                    try
                    {
                        SmartTextBox txt = (SmartTextBox)ctrl.Controls[0];
                        ComboBox cmb = (ComboBox)ctrl.Controls[1];

                        if (!string.IsNullOrEmpty(txt.Text))
                        {
                            if (cmb.SelectedItem == null)
                            {
                                MessageBox.Show("Debes seleccionar el tipo de línea", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                                cmb.Focus();
                                return true;
                            }
                            else if (string.IsNullOrEmpty(cmb.SelectedItem.ToString()))
                            {
                                MessageBox.Show("Debes seleccionar el tipo de línea", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                                cmb.Focus();
                                return true;
                            }
                        }
                        else if (string.IsNullOrEmpty(txt.Text) && cmb.SelectedItem != null)
                        {
                            if (string.IsNullOrEmpty(cmb.SelectedItem.ToString()))
                            {
                                cmb.SelectedItem = null;
                            }
                            else
                            {
                                MessageBox.Show("Debes escribir la información", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
                                txt.Focus();
                                return true;
                            }
                        }
                    }
                    catch
                    {
                        try
                        {
                            Panel Panel = (Panel)ucMultiLineSmartTextOSI.Controls.Find("panel1", false)[0];

                            LineSmartText lineSmart = (LineSmartText)Panel.Controls.Find("LineSmartText", false)[0];

                            Panel pnlText = (Panel)lineSmart.Controls.Find("panel2", false)[0];


                            ComboBox cmb = (ComboBox)pnlText.Controls[1];
                            SmartTextBox txt = (SmartTextBox)pnlText.Controls[0];


                            if (!string.IsNullOrEmpty(txt.Text))
                            {
                                if (cmb.SelectedItem == null)
                                {
                                    MessageBox.Show("Debes seleccionar el tipo de línea", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                     MessageBoxIcon.Information);
                                    cmb.Focus();
                                    return true;
                                }
                                else if (string.IsNullOrEmpty(cmb.SelectedItem.ToString()))
                                {
                                    MessageBox.Show("Debes seleccionar el tipo de línea", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                     MessageBoxIcon.Information);
                                    cmb.Focus();
                                    return true;
                                }
                            }
                            else if (string.IsNullOrEmpty(txt.Text) && cmb.SelectedItem != null)
                            {
                                if (string.IsNullOrEmpty(cmb.SelectedItem.ToString()))
                                {
                                    cmb.SelectedItem = null;
                                }
                                else
                                {
                                    MessageBox.Show("Debes escribir la información", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                       MessageBoxIcon.Information);
                                    txt.Focus();
                                    return true;
                                }
                            }

                        }
                        catch { }
                    }

                }

                Panel pnl1Remarks = (Panel)ucMultiTextRemarks1.Controls.Find("panel1", false)[0];
                foreach (Control ctrl in pnl1Remarks.Controls)
                {
                    try
                    {
                        Panel pnlChild = (Panel)ctrl;
                        SmartTextBox txt = (SmartTextBox)ctrl.Controls[0];
                        ComboBox cmb = (ComboBox)ctrl.Controls[2];
                        ComboBox cmb2 = (ComboBox)ctrl.Controls[1];

                        if (!string.IsNullOrEmpty(txt.Text))
                        {
                            if (cmb.SelectedItem == null)
                            {
                                MessageBox.Show("Debes seleccionar el tipo de línea", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                                cmb.Focus();
                                return true;
                            }
                            else if (string.IsNullOrEmpty(cmb.SelectedItem.ToString()))
                            {
                                MessageBox.Show("Debes seleccionar el tipo de línea", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                                cmb.Focus();
                                return true;
                            }
                        }
                        else if (string.IsNullOrEmpty(txt.Text) && cmb.SelectedItem != null)
                        {
                            if (string.IsNullOrEmpty(cmb.SelectedItem.ToString()))
                            {
                                cmb.SelectedItem = null;
                            }
                            else
                            {
                                MessageBox.Show("Debes escribir la información", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
                                txt.Focus();
                                return true;
                            }
                        }
                    }
                    catch
                    {
                        Panel Panel = (Panel)ucMultiTextRemarks1.Controls.Find("panel1", false)[0];

                        LineTextRemark lineSmart = (LineTextRemark)Panel.Controls.Find("LineTextRemark", false)[0];

                        Panel pnlText = (Panel)lineSmart.Controls.Find("panel2", false)[0];


                        ComboBox cmb = (ComboBox)pnlText.Controls[2];
                        ComboBox cmb2 = (ComboBox)pnlText.Controls[1];
                        SmartTextBox txt = (SmartTextBox)pnlText.Controls[0];



                        if (!string.IsNullOrEmpty(txt.Text))
                        {
                            if (cmb.SelectedItem == null)
                            {
                                MessageBox.Show("Debes seleccionar el tipo de línea", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                                cmb.Focus();
                                return true;
                            }
                            else if (string.IsNullOrEmpty(cmb.SelectedItem.ToString()))
                            {
                                MessageBox.Show("Debes seleccionar el tipo de línea", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                                cmb.Focus();
                                return true;
                            }


                        }
                        else if (string.IsNullOrEmpty(txt.Text) && cmb.SelectedItem != null)
                        {
                            if (string.IsNullOrEmpty(cmb.SelectedItem.ToString()))
                            {
                                cmb.SelectedItem = null;
                            }
                            else
                            {
                                MessageBox.Show("Debes escribir la información", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
                                txt.Focus();
                                return true;
                            }
                        }
                    }
                }

                Panel pnl1AlterEmail = (Panel)ucMultiLineSmartTextAlternativeEmail.Controls.Find("panel1", false)[0];
                foreach (Control ctrl in pnl1AlterEmail.Controls)
                {
                    try
                    {
                        Panel pnlChild = (Panel)ctrl;
                        SmartTextBox txt = (SmartTextBox)ctrl.Controls[0];
                        ComboBox cmb = (ComboBox)ctrl.Controls[1];

                        if (!string.IsNullOrEmpty(txt.Text))
                        {
                            if (cmb.SelectedItem == null)
                            {
                                MessageBox.Show("Debes seleccionar el tipo de línea", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                                cmb.Focus();
                                return true;
                            }
                            else if (string.IsNullOrEmpty(cmb.SelectedItem.ToString()))
                            {
                                MessageBox.Show("Debes seleccionar el tipo de línea", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                                cmb.Focus();
                                return true;
                            }

                            if (!txt.Text.Contains('@'))
                            {
                                MessageBox.Show("El texto no contiene arroba", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                                                 MessageBoxIcon.Information);
                                txt.Focus();
                                return true;
                            }

                            if (txt.Text.Contains("ANDANTE.COM") || txt.Text.Contains("CTSMEX.COM"))
                            {
                                MessageBox.Show("EL CORREO ELECTRÓNICO NO PUEDE SER INGRESADO CON DOMINIO:\n@CTSMEX.COM.MX\n@ANDANTE.COM.MX", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txt.Focus();
                                return true;
                            }

                        }
                        else if (string.IsNullOrEmpty(txt.Text) && cmb.SelectedItem != null)
                        {
                            if (string.IsNullOrEmpty(cmb.SelectedItem.ToString()))
                            {
                                cmb.SelectedItem = null;
                            }
                            else
                            {
                                MessageBox.Show("Debes escribir la información", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
                                txt.Focus();
                                return true;
                            }
                        }
                    }
                    catch
                    {
                        Panel Panel = (Panel)ucMultiLineSmartTextAlternativeEmail.Controls.Find("panel1", false)[0];

                        LineSmartText lineSmart = (LineSmartText)Panel.Controls.Find("LineSmartText", false)[0];

                        Panel pnlText = (Panel)lineSmart.Controls.Find("panel2", false)[0];


                        ComboBox cmb = (ComboBox)pnlText.Controls[1];
                        SmartTextBox txt = (SmartTextBox)pnlText.Controls[0];


                        if (!string.IsNullOrEmpty(txt.Text))
                        {
                            if (cmb.SelectedItem == null)
                            {
                                MessageBox.Show("Debes seleccionar el tipo de línea", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                                cmb.Focus();
                                return true;
                            }
                            else if (string.IsNullOrEmpty(cmb.SelectedItem.ToString()))
                            {
                                MessageBox.Show("Debes seleccionar el tipo de línea", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                                cmb.Focus();
                                return true;
                            }

                            if (!txt.Text.Contains('@'))
                            {
                                MessageBox.Show("El texto no contiene arroba", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                                                 MessageBoxIcon.Information);
                                txt.Focus();
                                return true;
                            }

                            if (txt.Text.Contains("ANDANTE.COM") || txt.Text.Contains("CTSMEX.COM."))
                            {
                                MessageBox.Show("EL CORREO ELECTRÓNICO NO PUEDE SER INGRESADO CON DOMINIO:\n@CTSMEX.COM.MX\n@ANDANTE.COM.MX", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txt.Focus();
                                return true;
                            }
                        }
                        else if (string.IsNullOrEmpty(txt.Text) && cmb.SelectedItem != null)
                        {
                            if (string.IsNullOrEmpty(cmb.SelectedItem.ToString()))
                            {
                                cmb.SelectedItem = null;
                            }
                            else
                            {
                                MessageBox.Show("Debes escribir la información", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
                                txt.Focus();
                                return true;
                            }
                        }
                    }
                }
                if (!string.IsNullOrEmpty(cmbCreditCardCode.Text))
                {
                    foreach (var item in cmbCreditCardCode.Items)
                    {
                        if (cmbCreditCardCode.Text == item.ToString())
                        {
                            isValid = false;
                            break;
                        }
                        else
                        {

                            isValid = true;
                        }
                    }
                    
                }
                if (isValid){
                    MessageBox.Show("El código de tarjeta " + cmbCreditCardCode.Text + " no es valido, seleccione un código del combo.", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                             MessageBoxIcon.Information);
                    return isValid;
                }
                if (!string.IsNullOrEmpty(cmbCreditCardCode2.Text))
                {
                    foreach (var item in cmbCreditCardCode2.Items)
                    {
                        if (cmbCreditCardCode2.Text == item.ToString())
                        {
                            isValid = false;
                            break;
                        }
                        else
                        {

                            isValid = true;
                        }
                    }
                }
                if (isValid)
                {
                    MessageBox.Show("El código de tarjeta " + cmbCreditCardCode2.Text + " no es valido, seleccione un código del combo.", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                             MessageBoxIcon.Information);
                    return isValid;
                }
                if (!string.IsNullOrEmpty(cmbCreditCardCode3.Text))
                {
                    foreach (var item in cmbCreditCardCode3.Items)
                    {
                        if (cmbCreditCardCode3.Text == item.ToString())
                        {
                            isValid = false;
                            break;
                        }
                        else
                        {

                            isValid = true;
                        }
                    }
                }
                if (isValid)
                {
                    MessageBox.Show("El código de tarjeta " + cmbCreditCardCode3.Text + " no es valido, seleccione un código del combo.", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                             MessageBoxIcon.Information);
                    return isValid;
                }
                Panel pnlSabreFormats = (Panel)ucMultiLineSmartTextSabreFormat.Controls.Find("panel1", false)[0];
                foreach (Control ctrl in pnlSabreFormats.Controls)
                {
                    try
                    {
                        Panel pnlChild = (Panel)ctrl;

                        SmartTextBox txt = (SmartTextBox)ctrl.Controls[0];
                        ComboBox cmb = (ComboBox)ctrl.Controls[1];

                        if (!string.IsNullOrEmpty(txt.Text))
                        {
                            if (txt.Text.StartsWith("-"))
                            {
                                MessageBox.Show("No se permite ingresar comandos que inicien con el signo guión (-).", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                                txt.Focus();
                                return true;
                            }

                            if (cmb.SelectedItem == null)
                            {
                                MessageBox.Show("Debes seleccionar el tipo de línea", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                                cmb.Focus();
                                return true;
                            }
                            else if (string.IsNullOrEmpty(cmb.SelectedItem.ToString()))
                            {
                                MessageBox.Show("Debes seleccionar el tipo de línea", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                                cmb.Focus();
                                return true;
                            }
                        }
                        else if (string.IsNullOrEmpty(txt.Text) && cmb.SelectedItem != null)
                        {
                            if (string.IsNullOrEmpty(cmb.SelectedItem.ToString()))
                            {
                                cmb.SelectedItem = null;
                            }
                            else
                            {
                                MessageBox.Show("Debes escribir la información", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
                                txt.Focus();
                                return true;
                            }
                        }
                    }
                    catch
                    {
                        try
                        {
                            Panel Panel = (Panel)ucMultiLineSmartTextSabreFormat.Controls.Find("panel1", false)[0];

                            LineSmartText lineSmart = (LineSmartText)Panel.Controls.Find("LineSmartText", false)[0];

                            Panel pnlText = (Panel)lineSmart.Controls.Find("panel2", false)[0];


                            ComboBox cmb = (ComboBox)pnlText.Controls[1];
                            SmartTextBox txt = (SmartTextBox)pnlText.Controls[0];


                            if (!string.IsNullOrEmpty(txt.Text))
                            {
                                if (txt.Text.StartsWith("-"))
                                {
                                    MessageBox.Show("No se permite ingresar comandos que inicien con el signo guión (-).", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                     MessageBoxIcon.Information);
                                    txt.Focus();
                                    return true;
                                }

                                if (cmb.SelectedItem == null)
                                {
                                    MessageBox.Show("Debes seleccionar el tipo de línea", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                     MessageBoxIcon.Information);
                                    cmb.Focus();
                                    return true;
                                }
                                else if (string.IsNullOrEmpty(cmb.SelectedItem.ToString()))
                                {
                                    MessageBox.Show("Debes seleccionar el tipo de línea", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                     MessageBoxIcon.Information);
                                    cmb.Focus();
                                    return true;
                                }
                            }
                            else if (string.IsNullOrEmpty(txt.Text) && cmb.SelectedItem != null)
                            {
                                if (string.IsNullOrEmpty(cmb.SelectedItem.ToString()))
                                {
                                    cmb.SelectedItem = null;
                                }
                                else
                                {
                                    MessageBox.Show("Debes escribir la información", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                       MessageBoxIcon.Information);
                                    txt.Focus();
                                    return true;
                                }
                            }

                        }
                        catch { }
                    }

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
                List<CatAllStars> star = CatAllStarsBL.GetAllStarsDetailed_Profile(pcc, txtProfileNameFirstLevel.Text, txtProfileNameEmployee.Text, Login.OrgId);
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
                List<CatAllStars> ProfileList = CatAllStarsBL.GetAll2ndStarDetailed_Profile(string.Empty, txtProfileNameFirstLevel.Text, Login.OrgId);
                if (ProfileList.Count > 0)
                {
                    foreach (var Profile in ProfileList)
                    {
                        if (txtProfileNameEmployee.Text.Equals(Profile.StarName))
                            isValid = true;
                    }
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


        private void LoadFiels()
        {
            if (ObjStar2Dcpsl == null)
                ObjStar2Dcpsl = new Star2Details();

            ObjStar2Dcpsl.Pcc = pcc;
            ObjStar2Dcpsl.Level1 = txtProfileNameFirstLevel.Text;
            ObjStar2Dcpsl.Level2 = txtProfileNameEmployee.Text;
            ObjStar2Dcpsl.Name = txtName.Text;
            ObjStar2Dcpsl.LastName = txtLastName.Text;
            ObjStar2Dcpsl.MiddleName = txtMiddleName.Text;
            ObjStar2Dcpsl.OfficePhone = txtOfficePhone.Text;
            ObjStar2Dcpsl.Ext = txtExt.Text;
            ObjStar2Dcpsl.OfficePhoneCode = cmbOfficePhoneCode.Text;
            ObjStar2Dcpsl.DirectPhone = txtPhone.Text;
            ObjStar2Dcpsl.DirectPhoneCode = cmbPhoneCode.Text;
            ObjStar2Dcpsl.Email = txtEmail.Text;
            ObjStar2Dcpsl.FrequentFlyer1 = txtFFAirlineCode1.Text + "*#*" + txtFFCode1.Text + "*#*" + txtFFName1.Text;
            ObjStar2Dcpsl.FrequentFlyer2 = txtFFAirlineCode2.Text + "*#*" + txtFFCode2.Text + "*#*" + txtFFName2.Text;
            ObjStar2Dcpsl.FrequentFlyer3 = txtFFAirlineCode3.Text + "*#*" + txtFFCode3.Text + "*#*" + txtFFName3.Text;
            ObjStar2Dcpsl.FrequentFlyer4 = txtFFAirlineCode4.Text + "*#*" + txtFFCode4.Text + "*#*" + txtFFName4.Text;
            ObjStar2Dcpsl.FrequentFlyer5 = txtFFAirlineCode5.Text + "*#*" + txtFFCode5.Text + "*#*" + txtFFName5.Text;
            ObjStar2Dcpsl.Passport = txtPassportNum.Text + "*#*" + cmbPassportVigencyMonth.Text + "*#*" + cmbPassportVigencyYear.Text + "*#*" + txtCountry.Text + "*#*" + txtNameOn.Text;
            ObjStar2Dcpsl.Passport2 = txtPassportNum2.Text + "*#*" + cmbPassportVigencyMonth2.Text + "*#*" + cmbPassportVigencyYear2.Text + "*#*" + txtCountry2.Text + "*#*" + txtNameOn2.Text;
            ObjStar2Dcpsl.Passport3 = txtPassportNum3.Text + "*#*" + cmbPassportVigencyMonth3.Text + "*#*" + cmbPassportVigencyYear3.Text + "*#*" + txtCountry3.Text + "*#*" + txtNameOn3.Text;
            ObjStar2Dcpsl.Birthday = cmbBirthdayDay.Text + "*#*" + cmbBirthDayMonth.Text + "*#*" + cmbBirthDayYear.Text;
            ObjStar2Dcpsl.Visa = txtVisaNum.Text + "*#*" + cmbVigencyVisaMonth.Text + "*#*" + cmbVigencyVisaYear.Text + "*#*" + txtVisaCountry.Text;
            ObjStar2Dcpsl.ImmigrationForm = txtMigratoryForm.Text + "*#*" + txtMigratoryNum.Text;
            ObjStar2Dcpsl.Rfc = txtRFC.Text;
            //string displayName = (!string.IsNullOrEmpty(cmbDisplayName.Text)) ? cmbDisplayName.Text.Substring(0, 2) : cmbDisplayName.Text;
            //string displayName2 = (!string.IsNullOrEmpty(cmbDisplayName2.Text)) ? cmbDisplayName2.Text.Substring(0, 2) : cmbDisplayName2.Text;
            //string displayName3 = (!string.IsNullOrEmpty(cmbDisplayName3.Text)) ? cmbDisplayName3.Text.Substring(0, 2) : cmbDisplayName3.Text;
            //string allowAirCarHotel = (!string.IsNullOrEmpty(cmbAllowAirCarHotel.Text)) ? cmbAllowAirCarHotel.Text.Substring(0, 2) : cmbAllowAirCarHotel.Text;
            //string allowAirCarHotel2 = (!string.IsNullOrEmpty(cmbAllowAirCarHotel2.Text)) ? cmbAllowAirCarHotel2.Text.Substring(0, 2) : cmbAllowAirCarHotel2.Text;
            //string allowAirCarHotel3 = (!string.IsNullOrEmpty(cmbAllowAirCarHotel3.Text)) ? cmbAllowAirCarHotel3.Text.Substring(0, 2) : cmbAllowAirCarHotel3.Text;

            string displayName = cmbDisplayName.Text;
            string displayName2 = cmbDisplayName2.Text;
            string displayName3 = cmbDisplayName3.Text;
            string allowAir1 = (chkAllowAir1.Checked) ? "Y" : "N";
            string allowCar1 = (chkAllowCar1.Checked) ? "Y" : "N";
            string allowHtl1 = (chkAllowHtl1.Checked) ? "Y" : "N";
            string allowAir2 = (chkAllowAir2.Checked) ? "Y" : "N";
            string allowCar2 = (chkAllowCar2.Checked) ? "Y" : "N";
            string allowHtl2 = (chkAllowHtl2.Checked) ? "Y" : "N";
            string allowAir3 = (chkAllowAir3.Checked) ? "Y" : "N";
            string allowCar3 = (chkAllowCar3.Checked) ? "Y" : "N";
            string allowHtl3 = (chkAllowHtl3.Checked) ? "Y" : "N";





            ObjStar2Dcpsl.CreditCar = cmbCreditCardCode.Text.ToUpper() + "*#*" + txtCreditCardNumber.Text + "*#*" + cmbCreditCardMonth.Text + "*#*" + cmbCreditCardYear.Text + "*#*" + txtNameonCard.Text + "*#*" + txtHomeAddressCard.Text + "*#*" + txtCityCard.Text + "*#*" + txtStateCard.Text + "*#*" + txtCountryCard.Text + "*#*" + txtZIPCard.Text + "*#*" + displayName + "*#*" + allowAir1 + "*#*" + allowCar1 + "*#*" + allowHtl1 + "*#*" + MyCTS.Presentation.Components.Common.toEncrypt(!string.IsNullOrEmpty(txtCVV.Text) ? txtCVV.Text : " ");
            ObjStar2Dcpsl.CreditCard2 = cmbCreditCardCode2.Text.ToUpper() + "*#*" + txtCreditCardNumber2.Text + "*#*" + cmbCreditCardMonth2.Text + "*#*" + cmbCreditCardYear2.Text + "*#*" + txtNameonCard2.Text + "*#*" + txtHomeAddressCard2.Text + "*#*" + txtCityCard2.Text + "*#*" + txtStateCard2.Text + "*#*" + txtCountryCard2.Text + "*#*" + txtZIPCard2.Text + "*#*" + displayName2 + "*#*" + allowAir2 + "*#*" + allowCar2 + "*#*" + allowHtl2 + "*#*" + MyCTS.Presentation.Components.Common.toEncrypt(!string.IsNullOrEmpty(txtCVV2.Text) ? txtCVV2.Text : " ");
            ObjStar2Dcpsl.CreditCard3 = cmbCreditCardCode3.Text.ToUpper() + "*#*" + txtCreditCardNumber3.Text + "*#*" + cmbCreditCardMonth3.Text + "*#*" + cmbCreditCardYear3.Text + "*#*" + txtNameonCard3.Text + "*#*" + txtHomeAddressCard3.Text + "*#*" + txtCityCard3.Text + "*#*" + txtStateCard3.Text + "*#*" + txtCountryCard3.Text + "*#*" + txtZIPCard3.Text + "*#*" + displayName3 + "*#*" + allowAir3 + "*#*" + allowCar3 + "*#*" + allowHtl3 + "*#*" + MyCTS.Presentation.Components.Common.toEncrypt(!string.IsNullOrEmpty(txtCVV3.Text) ? txtCVV3.Text : " ");
            ObjStar2Dcpsl.StreetAndNumber = txtStreetAndNumber.Text;
            ObjStar2Dcpsl.Colony = txtColony.Text;
            ObjStar2Dcpsl.PostalCode = txtCP.Text;
            ObjStar2Dcpsl.Estate = txtState.Text;
            ObjStar2Dcpsl.City = txtCity.Text;
            ObjStar2Dcpsl.Name2 = txtNames.Text;
            ObjStar2Dcpsl.LastName2 = txtNames2.Text;
            ObjStar2Dcpsl.Paternal = txtLastNames.Text;
            ObjStar2Dcpsl.Maternal = txtLastName2.Text;
            ObjStar2Dcpsl.Occupation = txtOcupation.Text;
            //if(!string.IsNullOrEmpty(cmbSeat.Text))
            ObjStar2Dcpsl.Seat = (!string.IsNullOrEmpty(cmbSeat.Text)) ? cmbSeat.Text.Substring(0, 1) : cmbSeat.Text;
            ObjStar2Dcpsl.Family1 = txtFamiliarName1.Text + "*#*" + txtFamiliarLastname1.Text + "*#*" + txtPassengerType1.Text;
            ObjStar2Dcpsl.Family2 = txtFamiliarName2.Text + "*#*" + txtFamiliarLastname2.Text + "*#*" + txtPassengerType2.Text;
            ObjStar2Dcpsl.Family3 = txtFamiliarName3.Text + "*#*" + txtFamiliarLastname3.Text + "*#*" + txtPassengerType3.Text;
            ObjStar2Dcpsl.Family4 = txtFamiliarName4.Text + "*#*" + txtFamiliarLastName4.Text + "*#*" + txtPassengerType4.Text;
            ObjStar2Dcpsl.Family5 = txtFamiliarName5.Text + "*#*" + txtFamiliarLastName5.Text + "*#*" + txtPassengerType5.Text;
            ObjStar2Dcpsl.Family6 = txtFamiliarName6.Text + "*#*" + txtFamiliarLastName6.Text + "*#*" + txtPassengerType6.Text;
            ObjStar2Dcpsl.Comments = ucMultilineSmartTextBox2.Text;
            ObjStar2Dcpsl.CadHotel1 = txtHotelCode1.Text + "*#*" + txtHotelNumber1.Text;
            ObjStar2Dcpsl.CadHotel2 = txtHotelCode2.Text + "*#*" + txtHotelNumber2.Text;
            ObjStar2Dcpsl.CadHotel3 = txtHotelCode3.Text + "*#*" + txtHotelNumber3.Text;
            ObjStar2Dcpsl.Leasing1 = txtCarAgencyCode1.Text + "*#*" + txtCarAgencyNumber1.Text;
            ObjStar2Dcpsl.Leasing2 = txtCarAgencyCode2.Text + "*#*" + txtCarAgencyNumber2.Text;
            ObjStar2Dcpsl.Leasing3 = txtCarAgencyCode3.Text + "*#*" + txtCarAgencyNumber3.Text;
            //nuevos campos pedidos por Pablo
            ObjStar2Dcpsl.MonthPreferences = cmbMonthPreferences.Text;
            ObjStar2Dcpsl.PlacePreferences = cmbPlacesPreference.Text;
            ObjStar2Dcpsl.WantInformation = cmbWantInformation.Text;

            ObjStar2Dcpsl.EmployeeID = txtEmployeeID.Text + "*#*" + cmbEmployeeIDRMK1.Text + "*#*" + cmbEmployeeIDRMK2.Text + "*#*" + cmbEmployeeIDOSI.Text + "*#*" + txtPrefix1.Text + "*#*" + txtSuffix1.Text + "*#*" + cmbLine1.Text;
            ObjStar2Dcpsl.TravelClass = cmbTravelClass.Text;
            ObjStar2Dcpsl.Division = txtUnitDivision.Text + "*#*" + cmbDivisionRMK1.Text + "*#*" + cmbDivisionRMK2.Text + "*#*" + cmbDivisionOSI.Text + "*#*" + txtPrefix3.Text + "*#*" + txtSuffix3.Text + "*#*" + cmbLine3.Text;
            ObjStar2Dcpsl.CostCenter = txtCostCenter.Text + "*#*" + cmbCostCenterRMK1.Text + "*#*" + cmbCostCenterRMK2.Text + "*#*" + cmbCostCenterOSI.Text + "*#*" + txtPrefix4.Text + "*#*" + txtSuffix4.Text + "*#*" + cmbLine4.Text;
            ObjStar2Dcpsl.ManagerLoginID = txtManagerLogin.Text + "*#*" + cmbLoginManagerIDRMK1.Text + "*#*" + cmbLoginManagerIDRMK2.Text + "*#*" + cmbLoginManagerIDOSI.Text + "*#*" + txtPrefix5.Text + "*#*" + txtSuffix5.Text + "*#*" + cmbLine5.Text;
            ObjStar2Dcpsl.Position_Title = txtPositionTitle.Text + "*#*" + cmbTitleRMK1.Text + "*#*" + cmbTitleRMK2.Text + "*#*" + cmbTitleOSI.Text + "*#*" + txtPrefix6.Text + "*#*" + txtSuffix6.Text + "*#*" + cmbLine6.Text;
            //ObjStar2Dcpsl.CustomerField1 = txtCustomeField1.Text + "*#*" + cmbCustomeField1RMK1.Text + "*#*" + cmbCustomeField1RMK2.Text + "*#*" + cmbCustomeField1OSI.Text + "*#*" + txtPrefix7.Text + "*#*" + txtSuffix7.Text + "*#*" + cmbLine7.Text;
            //ObjStar2Dcpsl.CustomerField2 = txtCustomeField2.Text + "*#*" + cmbCustomeField2RMK1.Text + "*#*" + cmbCustomeField2RMK2.Text + "*#*" + cmbCustomeField2OSI.Text + "*#*" + txtPrefix8.Text + "*#*" + txtSuffix8.Text + "*#*" + cmbLine8.Text;
            //ObjStar2Dcpsl.CustomerField3 = txtCustomeField3.Text + "*#*" + cmbCustomeField3RMK1.Text + "*#*" + cmbCustomeField3RMK2.Text + "*#*" + cmbCustomeField3OSI.Text + "*#*" + txtPrefix9.Text + "*#*" + txtSuffix9.Text + "*#*" + cmbLine9.Text;
            ObjStar2Dcpsl.Gender = cmbGender.Text;

            string historic = string.Empty;
            if (Parameters[3] == "Update" || Parameters[3] == "NewUpdate")
                historic = GetHistoricData();

            string osi = string.Empty;
            string text = string.Empty;
            string typeLine = string.Empty;
            string remarks = string.Empty;
            string typeRemark = string.Empty;
            string alternativeEmail = string.Empty;
            string sabreFormats = string.Empty;
            int count = 0;

            Panel pnl1Osi = (Panel)ucMultiLineSmartTextOSI.Controls.Find("panel1", false)[0];
            foreach (Control ctrl in pnl1Osi.Controls)
            {
                try
                {
                    Panel pnlChild = (Panel)ctrl;

                    SmartTextBox txt = (SmartTextBox)ctrl.Controls[0];
                    ComboBox cmb = (ComboBox)ctrl.Controls[1];


                    text = txt.Text;
                    if (cmb.SelectedItem != null)
                        typeLine = cmb.SelectedItem.ToString();
                    else
                        typeLine = string.Empty;

                    osi += string.Concat(text, ",", typeLine, "#");

                }
                catch
                {
                    try
                    {
                        Panel Panel = (Panel)ucMultiLineSmartTextOSI.Controls.Find("panel1", false)[0];

                        LineSmartText lineSmart = (LineSmartText)Panel.Controls.Find("LineSmartText", false)[count];

                        Panel pnlText = (Panel)lineSmart.Controls.Find("panel2", false)[0];


                        ComboBox cmb = (ComboBox)pnlText.Controls[1];
                        SmartTextBox txt = (SmartTextBox)pnlText.Controls[0];



                        text = txt.Text;
                        if (cmb.SelectedItem != null)
                            typeLine = cmb.SelectedItem.ToString();
                        else
                            typeLine = string.Empty;


                        osi += string.Concat(text, ",", typeLine, "#");

                        count += 1;

                    }
                    catch { }
                }

            }

            count = 0;
            Panel pnl1Remarks = (Panel)ucMultiTextRemarks1.Controls.Find("panel1", false)[0];
            foreach (Control ctrl in pnl1Remarks.Controls)
            {
                try
                {
                    Panel pnlChild = (Panel)ctrl;
                    SmartTextBox txt = (SmartTextBox)ctrl.Controls[0];
                    ComboBox cmb = (ComboBox)ctrl.Controls[2];
                    ComboBox cmb2 = (ComboBox)ctrl.Controls[1];


                    if (cmb2.SelectedItem != null && !string.IsNullOrEmpty(cmb2.SelectedItem.ToString()))
                    {
                        if (cmb2.SelectedItem.Equals("Contable"))
                            typeRemark = ".";
                        else if (cmb2.SelectedItem.Equals("Itinerario"))
                            typeRemark = Resources.Constants.CROSSLORAINE;
                        else if (cmb2.SelectedItem.Equals("Histórico"))
                            typeRemark = "H-";
                    }
                    else
                    {
                        typeRemark = string.Empty;
                    }
                    text = txt.Text;
                    if (cmb.SelectedItem != null)
                        typeLine = cmb.SelectedItem.ToString();
                    else
                        typeLine = string.Empty;
                    remarks += string.Concat(text, ",", typeLine, ",", typeRemark, "#");

                }
                catch
                {
                    Panel Panel = (Panel)ucMultiTextRemarks1.Controls.Find("panel1", false)[0];

                    LineTextRemark lineSmart = (LineTextRemark)Panel.Controls.Find("LineTextRemark", false)[count];

                    Panel pnlText = (Panel)lineSmart.Controls.Find("panel2", false)[0];


                    ComboBox cmb = (ComboBox)pnlText.Controls[2];
                    ComboBox cmb2 = (ComboBox)pnlText.Controls[1];
                    SmartTextBox txt = (SmartTextBox)pnlText.Controls[0];

                    if (cmb2.SelectedItem != null && !string.IsNullOrEmpty(cmb2.SelectedItem.ToString()))
                    {
                        if (cmb2.SelectedItem.Equals("Contable"))
                            typeRemark = ".";
                        else if (cmb2.SelectedItem.Equals("Itinerario"))
                            typeRemark = Resources.Constants.CROSSLORAINE;
                        else if (cmb2.SelectedItem.Equals("Histórico"))
                            typeRemark = "H-";

                    }
                    else
                    {
                        typeRemark = string.Empty;
                    }
                    text = txt.Text;
                    if (cmb.SelectedItem != null)
                        typeLine = cmb.SelectedItem.ToString();
                    else
                        typeLine = string.Empty;
                    remarks += string.Concat(text, ",", typeLine, ",", typeRemark, "#");

                    count += 1;
                }
            }

            count = 0;
            Panel pnl1AlterEmail = (Panel)ucMultiLineSmartTextAlternativeEmail.Controls.Find("panel1", false)[0];
            foreach (Control ctrl in pnl1AlterEmail.Controls)
            {
                try
                {
                    Panel pnlChild = (Panel)ctrl;
                    SmartTextBox txt = (SmartTextBox)ctrl.Controls[0];
                    ComboBox cmb = (ComboBox)ctrl.Controls[1];

                    text = txt.Text;
                    if (cmb.SelectedItem != null)
                        typeLine = cmb.SelectedItem.ToString();
                    else
                        typeLine = string.Empty;
                    alternativeEmail += string.Concat(text, ",", typeLine, "#");
                }
                catch
                {
                    Panel Panel = (Panel)ucMultiLineSmartTextAlternativeEmail.Controls.Find("panel1", false)[0];

                    LineSmartText lineSmart = (LineSmartText)Panel.Controls.Find("LineSmartText", false)[count];

                    Panel pnlText = (Panel)lineSmart.Controls.Find("panel2", false)[0];


                    ComboBox cmb = (ComboBox)pnlText.Controls[1];
                    SmartTextBox txt = (SmartTextBox)pnlText.Controls[0];


                    text = txt.Text;
                    if (cmb.SelectedItem != null)
                        typeLine = cmb.SelectedItem.ToString();
                    else
                        typeLine = string.Empty;
                    alternativeEmail += string.Concat(text, ",", typeLine, "#");

                    count += 1;
                }
            }

            count = 0;
            Panel pnlSabreFormats = (Panel)ucMultiLineSmartTextSabreFormat.Controls.Find("panel1", false)[0];
            foreach (Control ctrl in pnlSabreFormats.Controls)
            {
                try
                {
                    Panel pnlChild = (Panel)ctrl;
                    SmartTextBox txt = (SmartTextBox)ctrl.Controls[0];
                    ComboBox cmb = (ComboBox)ctrl.Controls[1];

                    text = txt.Text;
                    if (cmb.SelectedItem != null)
                        typeLine = cmb.SelectedItem.ToString();
                    else
                        typeLine = string.Empty;
                    sabreFormats += string.Concat(text, ",", typeLine, "#");

                }
                catch
                {
                    Panel Panel = (Panel)ucMultiLineSmartTextSabreFormat.Controls.Find("panel1", false)[0];

                    LineSmartText lineSmart = (LineSmartText)Panel.Controls.Find("LineSmartText", false)[count];

                    Panel pnlText = (Panel)lineSmart.Controls.Find("panel2", false)[0];


                    ComboBox cmb = (ComboBox)pnlText.Controls[1];
                    SmartTextBox txt = (SmartTextBox)pnlText.Controls[0];


                    //if (!string.IsNullOrEmpty(txt.Text))
                    //{
                    //    if (cmb.SelectedItem != null)
                    //    {
                    text = txt.Text;
                    if (cmb.SelectedItem != null)
                        typeLine = cmb.SelectedItem.ToString();
                    else
                        typeLine = string.Empty;
                    sabreFormats += string.Concat(text, ",", typeLine, "#");
                    //    }
                    //}
                    count += 1;
                }
            }

            ObjStar2Dcpsl.Osi = osi;
            ObjStar2Dcpsl.Remarks = remarks;
            ObjStar2Dcpsl.AlternativeEmail = alternativeEmail;
            ObjStar2Dcpsl.SabreFormats = sabreFormats;
            ObjStar2Dcpsl.Historic = historic;

            SetDynamicProperties("Id", ObjStar2Dcpsl.Id);
            SetDynamicProperties("Pcc", ObjStar2Dcpsl.Pcc);
            SetDynamicProperties("Level1", ObjStar2Dcpsl.Level1);
            SetDynamicProperties("Level2", ObjStar2Dcpsl.Level2);
            SetDynamicProperties("Name", ObjStar2Dcpsl.Name);
            SetDynamicProperties("LastName", ObjStar2Dcpsl.LastName);
            SetDynamicProperties("OfficePhone", ObjStar2Dcpsl.OfficePhone);
            SetDynamicProperties("Ext", ObjStar2Dcpsl.Ext);
            SetDynamicProperties("OfficePhoneCode", ObjStar2Dcpsl.OfficePhoneCode);
            SetDynamicProperties("DirectPhone", ObjStar2Dcpsl.DirectPhone);
            SetDynamicProperties("DirectPhoneCode", ObjStar2Dcpsl.DirectPhoneCode);
            SetDynamicProperties("Email", ObjStar2Dcpsl.Email);
            SetDynamicProperties("FrequentFlyer1", ObjStar2Dcpsl.FrequentFlyer1);
            SetDynamicProperties("FrequentFlyer2", ObjStar2Dcpsl.FrequentFlyer2);
            SetDynamicProperties("FrequentFlyer3", ObjStar2Dcpsl.FrequentFlyer3);
            SetDynamicProperties("FrequentFlyer4", ObjStar2Dcpsl.FrequentFlyer4);
            SetDynamicProperties("FrequentFlyer5", ObjStar2Dcpsl.FrequentFlyer5);
            SetDynamicProperties("Passport", ObjStar2Dcpsl.Passport);
            SetDynamicProperties("Passport2", ObjStar2Dcpsl.Passport2);
            SetDynamicProperties("Passport3", ObjStar2Dcpsl.Passport3);


            SetDynamicProperties("Birthday", ObjStar2Dcpsl.Birthday);
            SetDynamicProperties("Visa", ObjStar2Dcpsl.Visa);
            SetDynamicProperties("ImmigrationForm", ObjStar2Dcpsl.ImmigrationForm);
            SetDynamicProperties("RFC", ObjStar2Dcpsl.Rfc);
            SetDynamicProperties("CreditCar", ObjStar2Dcpsl.CreditCar);
            SetDynamicProperties("PersonalCar", ObjStar2Dcpsl.PersonalCar);
            SetDynamicProperties("StreetAndNumber", ObjStar2Dcpsl.StreetAndNumber);
            SetDynamicProperties("Colony", ObjStar2Dcpsl.Colony);
            SetDynamicProperties("PostalCode", ObjStar2Dcpsl.PostalCode);
            SetDynamicProperties("Estate", ObjStar2Dcpsl.Estate);
            SetDynamicProperties("City", ObjStar2Dcpsl.City);
            SetDynamicProperties("Name2", ObjStar2Dcpsl.Name2);
            SetDynamicProperties("LastName2", ObjStar2Dcpsl.LastName2);
            SetDynamicProperties("Paternal", ObjStar2Dcpsl.Paternal);
            SetDynamicProperties("Maternal", ObjStar2Dcpsl.Maternal);
            SetDynamicProperties("Occupation", ObjStar2Dcpsl.Occupation);
            SetDynamicProperties("Seat", ObjStar2Dcpsl.Seat);
            SetDynamicProperties("Family1", ObjStar2Dcpsl.Family1);
            SetDynamicProperties("Family2", ObjStar2Dcpsl.Family2);
            SetDynamicProperties("Family3", ObjStar2Dcpsl.Family3);
            SetDynamicProperties("Family4", ObjStar2Dcpsl.Family4);
            SetDynamicProperties("Family5", ObjStar2Dcpsl.Family5);
            SetDynamicProperties("Family6", ObjStar2Dcpsl.Family6);
            SetDynamicProperties("Comments", ObjStar2Dcpsl.Comments);
            SetDynamicProperties("HotelCreditCar", ObjStar2Dcpsl.HotelCreditCar);
            SetDynamicProperties("CadHotel1", ObjStar2Dcpsl.CadHotel1);
            SetDynamicProperties("CadHotel2", ObjStar2Dcpsl.CadHotel2);
            SetDynamicProperties("CadHotel3", ObjStar2Dcpsl.CadHotel3);
            SetDynamicProperties("Leasing1", ObjStar2Dcpsl.Leasing1);
            SetDynamicProperties("Leasing2", ObjStar2Dcpsl.Leasing2);
            SetDynamicProperties("Leasing3", ObjStar2Dcpsl.Leasing3);
            SetDynamicProperties("Date", System.DateTime.Now.ToString());
            SetDynamicProperties("Osi", ObjStar2Dcpsl.Osi);
            SetDynamicProperties("Remarks", ObjStar2Dcpsl.Remarks);
            SetDynamicProperties("AlternativeEmail", ObjStar2Dcpsl.AlternativeEmail);
            SetDynamicProperties("SabreFormats", ObjStar2Dcpsl.SabreFormats);
            SetDynamicProperties("CreditCard3", ObjStar2Dcpsl.CreditCard3);
            SetDynamicProperties("CreditCard2", ObjStar2Dcpsl.CreditCard2);


            SetDynamicProperties("MonthPreferences", ObjStar2Dcpsl.MonthPreferences);
            SetDynamicProperties("PlacePreferences", ObjStar2Dcpsl.PlacePreferences);
            SetDynamicProperties("WantInformation", ObjStar2Dcpsl.WantInformation);

            SetDynamicProperties("MiddleName", ObjStar2Dcpsl.MiddleName);

            SetDynamicProperties("ModifyOrigin", ObjStar2Dcpsl.ModifyOrigin);
            SetDynamicProperties("DateModify", ObjStar2Dcpsl.DateModify);
            SetDynamicProperties("EmployeeID", ObjStar2Dcpsl.EmployeeID);
            SetDynamicProperties("TravelClass", ObjStar2Dcpsl.TravelClass);
            SetDynamicProperties("Division", ObjStar2Dcpsl.Division);
            SetDynamicProperties("CostCenter", ObjStar2Dcpsl.CostCenter);
            SetDynamicProperties("ManagerLoginID", ObjStar2Dcpsl.ManagerLoginID);
            SetDynamicProperties("Position_Title", ObjStar2Dcpsl.Position_Title);
            SetDynamicProperties("CustomerField1", ObjStar2Dcpsl.CustomerField1);
            SetDynamicProperties("CustomerField2", ObjStar2Dcpsl.CustomerField2);
            SetDynamicProperties("CustomerField3", ObjStar2Dcpsl.CustomerField3);
            SetDynamicProperties("Gender", ObjStar2Dcpsl.Gender);

            SetDynamicsControlsValues();
        }

        // End MethodsClass


        #region=====Change focus When a Textbox is Full=====

        //Evento txtControl_TextChanged

        #endregion//End Change focus When a Textbox is Full


        #region =====Back to a Previous Usercontrol or Validate Enter KeyDown=====



        #endregion//Back to a Previous Usercontrol or Validate Enter KeyDown


        #region===== Predictives =====

        //Evento txtProfileNameFirstLevel_TextChanged
        private void txtProfileNameFirstLevel_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Parameters[3]))
            {
                lbProfileInfo.Items.Clear();
                txtSender = (SmartTextBox)sender;
                Common.SetListBoxStarsFirstLevel(txtSender, lbProfileInfo, txtProfileNameFirstLevel.Text);
            }
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
                pcc = li.Text2;
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
            pcc = li.Text2;
            lbProfileInfo.Visible = false;
            lbProfileInfo.Items.Clear();
            txtSender.Focus();
        }


        /// <summary>
        /// inserta el perfil en la tabla indice
        /// </summary>
        private void SetIndexDbTable()
        {
            if (string.IsNullOrEmpty(pcc))
                pcc = Login.PCC;

            Update2ndLevelBL.Update2ndLevel(pcc, ObjStar2Dcpsl.Level1, Parameters[2], ObjStar2Dcpsl.Level2, ObjStar2Dcpsl.Email);
        }


        /// <summary>
        /// Carga el UserControl Profile_Info_Display
        /// </summary>
        private void LoadUcProfileInfoDisplay()
        {
            Update1stLevelBL.Update1stLevel(pcc, ObjStar2Dcpsl.Level1, string.Empty, 1);
            ucProfileSearch.star1Info = Star1stLevelInfoBL.GetStar1stLevelInfo(pcc, ObjStar2Dcpsl.Level1);
            listFields = FieldsDynamicsBL.GetStar2Details(Parameters[0], Parameters[1], Parameters[2]);
            ucProfileSearch.star2Info = objProfilesMethods.FormatSabreProfile2L(LoadStar2Details());

            frmProfiles._ucProfileSearch = null;

            var frm = this.ParentForm as frmProfiles;

            MessageBox.Show("EL PERFIL HA SIDO ACTUALIZADO CON ÉXITO EN LA NUEVA ESTRUCTURA, YA PUEDES COMENZAR A TRABAJAR CON ÉL " + ObjStar2Dcpsl.Level2, Resources.Constants.MYCTS, MessageBoxButtons.OK,
                MessageBoxIcon.Information);



            frmPreloading frm2 = new frmPreloading(this);
            frm2.Show();


            if (ParentForm != null)
                if (Parameters[3] != null)
                {
                    if (Parameters[3].Equals("Update"))
                    {
                        ParentForm.Close();
                        frmProfiles formProfiles = new frmProfiles();
                        formProfiles.Show();
                    }
                    else if (Parameters[3].Equals("NewUpdate"))
                    {
                        ParentForm.Close();
                    }
                }
                else
                {
                    ParentForm.Close();
                    frmProfiles formProfiles = new frmProfiles();
                    formProfiles.Show();
                }

            else
                ParentForm.Close();

        }

        private void hidePredictive(object sender, EventArgs e)
        {
            lbProfileInfo.Hide();
        }


        #endregion//End lbProfileInf Events

        private void lbProfileInfo_VisibleChanged(object sender, EventArgs e)
        {
            if (txtSender != null)
            {
                if (txtSender.Name.Equals(txtProfileNameFirstLevel.Name))
                {
                    if (lbProfileInfo.Visible && string.IsNullOrEmpty(this.Parameters[3]))
                        pcc = string.Empty;
                }
            }
        }

        private void loadExtraFields()
        {
            try
            {
                //Numero de columnas de la Tabla que NO son Datos Extas
                //var columns = 60;
                //var tableLayoutPanel1 = new TableLayoutPanel();
                //int num = listFields.Count - columns;
                //if (num == 0)
                //    return;
                //float percentRows = 100 / num;

                //tableLayoutPanel1.ColumnCount = 2;
                //tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
                //tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());

                //tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
                //tableLayoutPanel1.Name = "tableLayoutPanel1";
                //tableLayoutPanel1.RowCount = num;
                //for (int r = 0; r < num; r++)
                //{
                //    tableLayoutPanel1.RowStyles.Add(new RowStyle(System.Windows.Forms.SizeType.Absolute, percentRows + 15));
                //}

                ////tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
                //tableLayoutPanel1.AutoSize = true;

                //var propertiesList = new List<Dynamic>();
                //string propName = string.Empty;

                //int y = 0;
                //int i = 0;

                //foreach (Dynamic item in listFields)
                //{
                //    if (i >= columns)
                //    {
                //        var lbl = new Label();
                //        lbl.Location = new System.Drawing.Point(3, 3);
                //        lbl.Text = item.GetType().GetProperty(item.FieldName).Name;

                //        var txt = new SmartTextBox();
                //        txt.MaxLength = 60;
                //        txt.CharacterCasing = CharacterCasing.Upper;
                //        txt.Location = new System.Drawing.Point(141, 0);
                //        txt.Text = item.GetType().GetProperty(item.FieldName).GetValue(item, null).ToString();
                //        txt.Size = new System.Drawing.Size(357, 20);

                //        tableLayoutPanel1.Controls.Add(lbl, 0, y);
                //        tableLayoutPanel1.Controls.Add(txt, 1, y);
                //        y += 1;
                //    }

                //    i++;
                //}
                //pnlExtraData.Controls.Add(tableLayoutPanel1);
            }
            catch { }
        }

        private void SetDynamicProperties(string propName, String value)
        {
            item2 = new Dynamic();
            item2 = item2.Add(propName, value);
            item2.FieldName = propName;
            listFields2.Add(item2);
        }

        private void SetDynamicsControlsValues()
        {
            //foreach (TableLayoutPanel tlp in pnlExtraData.Controls.Find("tableLayoutPanel1", true))
            //{
            //    for (int i = 0; i < tlp.RowCount; i++)
            //    {
            //        item2 = new Dynamic();

            //        item2.FieldName = tlp.GetControlFromPosition(0, i).Text;
            //        if (item2.FieldName == "MonthPreferences")
            //        {
            //            item2 = item2.Add(tlp.GetControlFromPosition(0, i).Text, ObjStar2Dcpsl.MonthPreferences);
            //        }
            //        else if (item2.FieldName == "PlacePreferences")
            //        {
            //            item2 = item2.Add(tlp.GetControlFromPosition(0, i).Text, ObjStar2Dcpsl.PlacePreferences);
            //        }
            //        else if (item2.FieldName == "WantInformation")
            //        {
            //            item2 = item2.Add(tlp.GetControlFromPosition(0, i).Text, ObjStar2Dcpsl.WantInformation);
            //        }
            //        else
            //        {
            //            item2 = item2.Add(tlp.GetControlFromPosition(0, i).Text, tlp.GetControlFromPosition(1, i).Text);
            //        }
            //        listFields2.Add(item2);
            //    }
            //    break;
            //}
        }

        private Star2Details LoadStar2Details()
        {
            var s2 = new Star2Details
            {
                Id = GetDynamicProperties("Id", listFields),
                Pcc = GetDynamicProperties("Pcc", listFields),
                Level1 = GetDynamicProperties("Level1", listFields),
                Level2 = GetDynamicProperties("Level2", listFields),
                Name = GetDynamicProperties("Name", listFields),
                LastName = GetDynamicProperties("LastName", listFields),
                OfficePhone = GetDynamicProperties("OfficePhone", listFields),
                Ext = GetDynamicProperties("Ext", listFields),
                OfficePhoneCode = GetDynamicProperties("OfficePhoneCode", listFields),
                DirectPhone = GetDynamicProperties("DirectPhone", listFields),
                DirectPhoneCode = GetDynamicProperties("DirectPhoneCode", listFields),
                Email = GetDynamicProperties("Email", listFields),
                FrequentFlyer1 = GetDynamicProperties("FrequentFlyer1", listFields),
                FrequentFlyer2 = GetDynamicProperties("FrequentFlyer2", listFields),
                FrequentFlyer3 = GetDynamicProperties("FrequentFlyer3", listFields),
                FrequentFlyer4 = GetDynamicProperties("FrequentFlyer4", listFields),
                FrequentFlyer5 = GetDynamicProperties("FrequentFlyer5", listFields),
                Passport = GetDynamicProperties("Passport", listFields),
                Passport2 = GetDynamicProperties("Passport2", listFields),
                Passport3 = GetDynamicProperties("Passport3", listFields),

                Birthday = GetDynamicProperties("Birthday", listFields),
                Visa = GetDynamicProperties("Visa", listFields),
                ImmigrationForm = GetDynamicProperties("ImmigrationForm", listFields),
                Rfc = GetDynamicProperties("RFC", listFields),
                CreditCar = GetDynamicProperties("CreditCar", listFields),
                CreditCard3 = GetDynamicProperties("CreditCard3", listFields),
                CreditCard2 = GetDynamicProperties("CreditCard2", listFields),
                PersonalCar = GetDynamicProperties("PersonalCar", listFields),
                StreetAndNumber = GetDynamicProperties("StreetAndNumber", listFields),
                Colony = GetDynamicProperties("Colony", listFields),
                PostalCode = GetDynamicProperties("PostalCode", listFields),
                Estate = GetDynamicProperties("Estate", listFields),
                City = GetDynamicProperties("City", listFields),
                Name2 = GetDynamicProperties("Name2", listFields),
                LastName2 = GetDynamicProperties("LastName2", listFields),
                Paternal = GetDynamicProperties("Paternal", listFields),
                Maternal = GetDynamicProperties("Maternal", listFields),
                Occupation = GetDynamicProperties("Occupation", listFields),
                Seat = GetDynamicProperties("Seat", listFields),
                Family1 = GetDynamicProperties("Family1", listFields),
                Family2 = GetDynamicProperties("Family2", listFields),
                Family3 = GetDynamicProperties("Family3", listFields),
                Family4 = GetDynamicProperties("Family4", listFields),
                Family5 = GetDynamicProperties("Family5", listFields),
                Family6 = GetDynamicProperties("Family6", listFields),
                Comments = GetDynamicProperties("Comments", listFields),
                HotelCreditCar = GetDynamicProperties("HotelCreditCar", listFields),
                CadHotel1 = GetDynamicProperties("CadHotel1", listFields),
                CadHotel2 = GetDynamicProperties("CadHotel2", listFields),
                Leasing1 = GetDynamicProperties("Leasing1", listFields),
                Leasing2 = GetDynamicProperties("Leasing2", listFields),
                Osi = GetDynamicProperties("Osi", listFields),
                Remarks = GetDynamicProperties("Remarks", listFields),
                SabreFormats = GetDynamicProperties("SabreFormats", listFields),
                Historic = GetDynamicProperties("Historic", listFields),
                AlternativeEmail = GetDynamicProperties("AlternativeEmail", listFields),
                //nuevos campos
                MonthPreferences = GetDynamicProperties("MonthPreferences", listFields),
                PlacePreferences = GetDynamicProperties("PlacePreferences", listFields),
                WantInformation = GetDynamicProperties("WantInformation", listFields),
                CadHotel3 = GetDynamicProperties("CadHotel3", listFields),
                Leasing3 = GetDynamicProperties("Leasing3", listFields),
                MiddleName = GetDynamicProperties("MiddleName", listFields),
                ModifyOrigin = GetDynamicProperties("ModifyOrigin", listFields),
                DateModify = GetDynamicProperties("DateModify", listFields),
                EmployeeID = GetDynamicProperties("EmployeeID", listFields),
                TravelClass = GetDynamicProperties("TravelClass", listFields),
                Division = GetDynamicProperties("Division", listFields),
                CostCenter = GetDynamicProperties("CostCenter", listFields),
                ManagerLoginID = GetDynamicProperties("ManagerLoginID", listFields),
                Position_Title = GetDynamicProperties("Position_Title", listFields),
                CustomerField1 = GetDynamicProperties("CustomerField1", listFields),
                CustomerField2 = GetDynamicProperties("CustomerField2", listFields),
                CustomerField3 = GetDynamicProperties("CustomerField3", listFields),
                Gender = GetDynamicProperties("Gender", listFields),

            };

            return s2;
        }

        private String GetDynamicProperties(string propName, List<Dynamic> list)
        {
            string x = "";
            var item = new Dynamic();

            var prop = from p in list
                       where p.FieldName.ToLower() == propName.ToLower()
                       select p;
            item = (prop.Count() > 0) ? prop.First<Dynamic>() : null;
            if (item != null)

                x = item.GetType().GetProperty(item.FieldName).GetValue(item, null).ToString();
            return x;
        }

        private string GetHistoricData()
        {
            string lines = string.Empty;
            List<string> deactivatedStarsList = GetDeactivatedStarsBL.GetDeactivatedStarSecondLevel(txtProfileNameEmployee.Text, txtProfileNameFirstLevel.Text);
            if (deactivatedStarsList.Count > 0)
            {
                foreach (string item in deactivatedStarsList)
                {
                    if (item.Length > 2)
                    {
                        lines = string.Concat(lines, "#", item);
                    }
                }

            }
            return lines;
        }

        #region =====Change Focus When Textbox Is Full=====

        private void txtBirthdayDay_TextChanged(object sender, EventArgs e)
        {
            if (cmbBirthdayDay.Text.Length == 2)
            {
                cmbBirthDayMonth.Focus();
            }
        }

        private void txtBirthDayMonth_TextChanged(object sender, EventArgs e)
        {
            if (cmbBirthDayMonth.Text.Length == 3)
            {
                cmbBirthDayYear.Focus();
            }
        }

        private void txtBirthDayYear_TextChanged(object sender, EventArgs e)
        {
            if (cmbBirthDayYear.Text.Length == 2)
            {
                txtVisaNum.Focus();
            }
        }

        private void txtPassportVigencyMonth_TextChanged(object sender, EventArgs e)
        {
            //if (txtPassportVigencyMonth.Text.Length == 3)
            //{
            //    txtPassportVigencyYear.Focus();
            //}
        }

        private void txtPassportVigencyYear_TextChanged(object sender, EventArgs e)
        {
            //if (txtPassportVigencyYear.Text.Length == 2)
            //{
            //    txtCountry.Focus();
            //}
        }

        private void txtCountry_TextChanged_1(object sender, EventArgs e)
        {
            //if (txtCountry.Text.Length == 2)
            //{
            //    txtBirthdayDay.Focus();
            //}
        }

        private void txtVigencyVisaMonth_TextChanged(object sender, EventArgs e)
        {
            if (cmbVigencyVisaMonth.Text.Length == 3)
            {
                cmbVigencyVisaYear.Focus();
            }
        }

        private void txtVigencyVisaYear_TextChanged(object sender, EventArgs e)
        {
            if (cmbVigencyVisaYear.Text.Length == 2)
            {
                txtVisaCountry.Focus();
            }
        }

        private void txtVisaCountry_TextChanged(object sender, EventArgs e)
        {
            if (txtVisaCountry.Text.Length == 2)
            {
                txtRFC.Focus();
            }
        }




        private void txtHotelCode1_TextChanged(object sender, EventArgs e)
        {
            if (txtHotelCode1.Text.Length == 2)
            {
                txtHotelNumber1.Focus();
            }
        }

        private void txtCarAgencyCode1_TextChanged(object sender, EventArgs e)
        {
            if (txtCarAgencyCode1.Text.Length == 2)
            {
                txtCarAgencyNumber1.Focus();
            }
        }

        private void txtHotelCode2_TextChanged(object sender, EventArgs e)
        {
            if (txtHotelCode2.Text.Length == 2)
            {
                txtHotelNumber2.Focus();
            }
        }

        private void txtCarAgencyCode2_TextChanged(object sender, EventArgs e)
        {
            if (txtCarAgencyCode2.Text.Length == 2)
            {
                txtCarAgencyNumber2.Focus();
            }
        }

        private void txtCreditCardCode2_TextChanged(object sender, EventArgs e)
        {
            if (cmbCreditCardCode2.Text.Length == 2)
            {
                txtCreditCardNumber2.Focus();
            }
        }

        private void txtFFAirlineCode1_TextChanged(object sender, EventArgs e)
        {
            if (txtFFAirlineCode1.Text.Length == 2)
            {
                txtFFCode1.Focus();
            }
        }

        private void txtFFCode1_TextChanged(object sender, EventArgs e)
        {
            if (txtFFCode1.Text.Length == 20)
            {
                txtFFName1.Focus();
            }
        }

        private void txtFFName1_TextChanged(object sender, EventArgs e)
        {
            if (txtFFName1.Text.Length == 30)
            {
                txtFFAirlineCode2.Focus();
            }
        }

        private void txtFFAirlineCode2_TextChanged(object sender, EventArgs e)
        {
            if (txtFFAirlineCode2.Text.Length == 2)
            {
                txtFFCode2.Focus();
            }

            if (string.IsNullOrEmpty(txtFFAirlineCode1.Text))
            {
                MessageBox.Show("El campo del primer viajero frecuente esta vacio", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFFAirlineCode1.Focus();
            }
        }

        private void txtFFCode2_TextChanged(object sender, EventArgs e)
        {
            if (txtFFCode2.Text.Length == 20)
            {
                txtFFName2.Focus();
            }
        }

        private void txtFFName2_TextChanged(object sender, EventArgs e)
        {
            if (txtFFName2.Text.Length == 30)
            {
                txtFFAirlineCode3.Focus();
            }
        }

        private void txtFFAirlineCode3_TextChanged(object sender, EventArgs e)
        {
            if (txtFFAirlineCode3.Text.Length == 2)
            {
                txtFFCode3.Focus();
            }
            if (string.IsNullOrEmpty(txtFFAirlineCode2.Text))
            {
                MessageBox.Show("El campo del segundo viajero frecuente esta vacio", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFFAirlineCode2.Focus();
            }
        }

        private void txtFFCode3_TextChanged(object sender, EventArgs e)
        {
            if (txtFFCode3.Text.Length == 20)
            {
                txtFFName3.Focus();
            }
        }

        private void txtFFName3_TextChanged(object sender, EventArgs e)
        {
            if (txtFFName3.Text.Length == 30)
            {
                txtFFAirlineCode4.Focus();
            }
        }


        private void txtFFAirlineCode4_TextChanged(object sender, EventArgs e)
        {
            if (txtFFAirlineCode4.Text.Length == 2)
            {
                txtFFCode4.Focus();
            }
            if (string.IsNullOrEmpty(txtFFAirlineCode3.Text))
            {
                MessageBox.Show("El campo del tercer viajero frecuente esta vacio", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFFAirlineCode3.Focus();
            }
        }

        private void txtFFCode4_TextChanged(object sender, EventArgs e)
        {
            if (txtFFCode4.Text.Length == 20)
            {
                txtFFName4.Focus();
            }
        }

        private void txtFFName4_TextChanged(object sender, EventArgs e)
        {
            if (txtFFName4.Text.Length == 30)
            {
                txtFFAirlineCode5.Focus();
            }
        }

        private void txtFFAirlineCode5_TextChanged(object sender, EventArgs e)
        {
            if (txtFFAirlineCode5.Text.Length == 2)
            {
                txtFFCode5.Focus();
            }
            if (string.IsNullOrEmpty(txtFFAirlineCode4.Text))
            {
                MessageBox.Show("El campo del cuarto viajero frecuente esta vacio", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFFAirlineCode4.Focus();
            }
        }

        private void txtFFCode5_TextChanged(object sender, EventArgs e)
        {
            if (txtFFCode5.Text.Length == 20)
            {
                txtFFName5.Focus();
            }
        }

        private void txtFFName5_TextChanged(object sender, EventArgs e)
        {
            if (txtFFName5.Text.Length == 30)
            {
                //txtPassportNum.Focus();
            }
        }

        private void txtCreditCardCode_TextChanged(object sender, EventArgs e)
        {
            if (cmbCreditCardCode.Text.Length == 2)
            {
                txtCreditCardNumber.Focus();
            }
        }

        private void txtCreditCardNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtCreditCardNumber.Text.Length == 16)
            {
                cmbCreditCardMonth.Focus();
            }
        }

        private void txtCreditCardMonth_TextChanged(object sender, EventArgs e)
        {
            if (cmbCreditCardMonth.Text.Length == 2)
            {
                cmbCreditCardYear.Focus();
            }
        }

        private void txtCreditCardYear_TextChanged(object sender, EventArgs e)
        {
            if (cmbCreditCardYear.Text.Length == 2)
            {
                btnAccept.Focus();
            }
        }

        private void txtCreditCardNumber2_TextChanged(object sender, EventArgs e)
        {
            if (txtCreditCardNumber2.Text.Length == 16)
            {
                //txtCCVigencyMonth.Focus();
            }
        }

        //private void txtCCLastName_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtCCLastName.Text.Length == txtCCLastName.MaxLength)
        //    {
        //        txtHotelCode1.Focus();
        //    }
        //}

        private void txtStreetAndNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtStreetAndNumber.Text.Length == txtStreetAndNumber.MaxLength)
            {
                txtColony.Focus();
            }
        }

        private void txtColony_TextChanged(object sender, EventArgs e)
        {
            if (txtColony.Text.Length == txtColony.MaxLength)
            {
                txtCP.Focus();
            }
        }

        private void txtCP_TextChanged(object sender, EventArgs e)
        {
            if (txtCP.Text.Length == txtCP.MaxLength)
            {
                txtState.Focus();
            }
        }

        private void txtState_TextChanged(object sender, EventArgs e)
        {
            if (txtState.Text.Length == txtState.MaxLength)
            {
                txtCity.Focus();
            }
        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {
            if (txtCity.Text.Length == txtCity.MaxLength)
            {
                txtNames.Focus();
            }
        }

        private void txtNames_TextChanged(object sender, EventArgs e)
        {
            if (txtNames.Text.Length == txtNames.MaxLength)
            {
                txtNames2.Focus();
            }
        }

        private void txtNames2_TextChanged(object sender, EventArgs e)
        {
            if (txtNames2.Text.Length == txtNames2.MaxLength)
            {
                txtLastNames.Focus();
            }
        }

        private void txtLastNames_TextChanged(object sender, EventArgs e)
        {
            if (txtLastNames.Text.Length == txtLastNames.MaxLength)
            {
                txtLastName2.Focus();
            }
        }

        private void txtLastName2_TextChanged(object sender, EventArgs e)
        {
            if (txtLastName2.Text.Length == txtLastName2.MaxLength)
            {
                txtOcupation.Focus();
            }
        }

        private void txtOcupation_TextChanged(object sender, EventArgs e)
        {
            if (txtOcupation.Text.Length == txtOcupation.MaxLength)
            {
                cmbSeat.Focus();
            }
        }

        private void txtSeat_TextChanged(object sender, EventArgs e)
        {
            if (cmbSeat.Text.Length == cmbSeat.MaxLength)
            {
                txtFamiliarName1.Focus();
            }

        }

        private void txtFamiliarName1_TextChanged(object sender, EventArgs e)
        {
            if (txtFamiliarName1.Text.Length == txtFamiliarName1.MaxLength)
            {
                txtFamiliarLastname1.Focus();
            }
        }

        private void txtFamiliarLastname1_TextChanged(object sender, EventArgs e)
        {
            if (txtFamiliarLastname1.Text.Length == txtFamiliarLastname1.MaxLength)
            {
                txtPassengerType1.Focus();
            }
        }

        private void txtPassengerType1_TextChanged(object sender, EventArgs e)
        {
            if (txtPassengerType1.Text.Length == txtPassengerType1.MaxLength)
            {
                txtFamiliarName2.Focus();
            }
        }

        private void txtFamiliarName2_TextChanged(object sender, EventArgs e)
        {
            if (txtFamiliarName2.Text.Length == txtFamiliarName2.MaxLength)
            {
                txtFamiliarLastname2.Focus();
            }
        }

        private void txtFamiliarLastname2_TextChanged(object sender, EventArgs e)
        {
            if (txtFamiliarLastname2.Text.Length == txtFamiliarLastname2.MaxLength)
            {
                txtPassengerType2.Focus();
            }
        }

        private void txtPassengerType2_TextChanged(object sender, EventArgs e)
        {
            if (txtPassengerType2.Text.Length == txtPassengerType2.MaxLength)
            {
                txtFamiliarName3.Focus();
            }
        }

        private void txtFamiliarName3_TextChanged(object sender, EventArgs e)
        {
            if (txtFamiliarName3.Text.Length == txtFamiliarName3.MaxLength)
            {
                txtFamiliarLastname3.Focus();
            }
        }

        private void txtFamiliarLastname3_TextChanged(object sender, EventArgs e)
        {
            if (txtFamiliarLastname3.Text.Length == txtFamiliarLastname3.MaxLength)
            {
                txtPassengerType3.Focus();
            }
        }

        private void txtPassengerType3_TextChanged(object sender, EventArgs e)
        {
            if (txtPassengerType3.Text.Length == txtPassengerType3.MaxLength)
            {
                txtFamiliarName4.Focus();
            }
        }

        private void txtFamiliarName4_TextChanged(object sender, EventArgs e)
        {
            if (txtFamiliarName4.Text.Length == txtFamiliarName4.MaxLength)
            {
                txtFamiliarLastName4.Focus();
            }
        }

        private void txtFamiliarLastName4_TextChanged(object sender, EventArgs e)
        {
            if (txtFamiliarLastName4.Text.Length == txtFamiliarLastName4.MaxLength)
            {
                txtPassengerType4.Focus();
            }
        }

        private void txtPassengerType4_TextChanged(object sender, EventArgs e)
        {
            if (txtPassengerType4.Text.Length == txtPassengerType4.MaxLength)
            {
                txtFamiliarName5.Focus();
            }
        }

        private void txtFamiliarName5_TextChanged(object sender, EventArgs e)
        {
            if (txtFamiliarName5.Text.Length == txtFamiliarName5.MaxLength)
            {
                txtFamiliarLastName5.Focus();
            }
        }

        private void txtFamiliarLastName5_TextChanged(object sender, EventArgs e)
        {
            if (txtFamiliarLastName5.Text.Length == txtFamiliarLastName5.MaxLength)
            {
                txtPassengerType5.Focus();
            }
        }

        private void txtPassengerType5_TextChanged(object sender, EventArgs e)
        {
            if (txtPassengerType5.Text.Length == txtPassengerType5.MaxLength)
            {
                txtFamiliarName6.Focus();
            }
        }

        private void txtFamiliarName6_TextChanged(object sender, EventArgs e)
        {
            if (txtFamiliarName6.Text.Length == txtFamiliarName6.MaxLength)
            {
                txtFamiliarLastName6.Focus();
            }
        }

        private void txtFamiliarLastName6_TextChanged(object sender, EventArgs e)
        {
            if (txtFamiliarLastName6.Text.Length == txtFamiliarLastName6.MaxLength)
            {
                txtPassengerType6.Focus();
            }
        }

        private void txtPassengerType6_TextChanged(object sender, EventArgs e)
        {
            if (txtPassengerType6.Text.Length == txtPassengerType6.MaxLength)
            {
                ucMultilineSmartTextBox2.Focus();
            }
        }

        private void txtPassportNum_TextChanged(object sender, EventArgs e)
        {
            //if (txtPassportNum.Text.Length == txtPassportNum.MaxLength)
            //{
            //    txtPassportVigencyMonth.Focus();
            //}
        }

        private void txtVisaNum_TextChanged(object sender, EventArgs e)
        {
            if (txtVisaNum.Text.Length == txtVisaNum.MaxLength)
            {
                cmbVigencyVisaMonth.Focus();
            }
        }

        private void txtRFC_TextChanged(object sender, EventArgs e)
        {
            if (txtRFC.Text.Length == txtRFC.MaxLength)
            {
                txtMigratoryForm.Focus();
            }
        }

        private void txtMigratoryForm_TextChanged(object sender, EventArgs e)
        {
            if (txtMigratoryForm.Text.Length == txtMigratoryForm.MaxLength)
            {
                txtMigratoryNum.Focus();
            }
        }

        private void txtMigratoryNum_TextChanged(object sender, EventArgs e)
        {
            if (txtMigratoryNum.Text.Length == txtMigratoryNum.MaxLength)
            {
                cmbCreditCardCode.Focus();
            }
        }

        private void txtHotelNumber1_TextChanged(object sender, EventArgs e)
        {
            if (txtHotelNumber1.Text.Length == txtHotelNumber1.MaxLength)
            {
                txtCarAgencyCode1.Focus();
            }
        }

        private void txtCarAgencyNumber1_TextChanged(object sender, EventArgs e)
        {
            if (txtCarAgencyNumber1.Text.Length == txtCarAgencyNumber1.MaxLength)
            {
                txtHotelCode2.Focus();
            }
        }

        private void txtHotelNumber2_TextChanged(object sender, EventArgs e)
        {
            if (txtHotelNumber2.Text.Length == txtHotelNumber2.MaxLength)
            {
                txtCarAgencyCode2.Focus();
            }
        }

        private void txtCarAgencyNumber2_TextChanged(object sender, EventArgs e)
        {
            if (txtCarAgencyNumber2.Text.Length == txtCarAgencyNumber2.MaxLength)
            {
                btnAccept.Focus();
            }
        }

        private void txtCreditCardCode3_TextChanged(object sender, EventArgs e)
        {
            if (cmbCreditCardCode3.Text.Length == 2)
            {
                txtCreditCardNumber3.Focus();
            }
        }

        private void txtCreditCardNumber3_TextChanged(object sender, EventArgs e)
        {
            if (txtCreditCardNumber3.Text.Length == 16)
            {
                cmbCreditCardMonth3.Focus();
            }
        }

        private void txtCreditCardMonth3_TextChanged(object sender, EventArgs e)
        {
            if (cmbCreditCardMonth3.Text.Length == 2)
            {
                cmbCreditCardYear3.Focus();
            }
        }

        private void txtCreditCardYear3_TextChanged(object sender, EventArgs e)
        {
            if (cmbCreditCardYear3.Text.Length == 2)
            {
                //txtCreditCardCode4.Focus();
            }
        }

        private bool TryToDate(string DateString, int type)
        {
            try
            {
                DateTime myDate = new DateTime();
                switch (type)
                {
                    case 1:
                        myDate = DateTime.ParseExact(DateString, "ddMMMyy",
                                       System.Globalization.CultureInfo.InvariantCulture);
                        break;
                    case 2:
                        myDate = DateTime.ParseExact(DateString, "MMMyy",
                                       System.Globalization.CultureInfo.InvariantCulture);
                        break;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        private void txtPassportNum3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassportNum2.Text))
            {
                MessageBox.Show("El campo del segundo pasaporte esta vacio", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassportNum2.Focus();
            }
        }

        private void txtCreditCardCode_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtCreditCardCode2_TextChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbCreditCardCode.Text))
            {
                MessageBox.Show("El campo de la primer tarjeta de credito esta vacio", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbCreditCardCode.Focus();
            }
        }

        private void txtCreditCardCode3_TextChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbCreditCardCode2.Text))
            {
                MessageBox.Show("El campo de la segunda tarjeta de credito esta vacio", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbCreditCardCode2.Focus();
            }
        }

        private void lblVigency_Click(object sender, EventArgs e)
        {

        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count >= int.Parse(ParameterBL.GetParameterValue("NumDocs").Values))
            {
                MessageBox.Show("Solo se permite el uso de " + int.Parse(ParameterBL.GetParameterValue("NumDocs").Values) + " imagenes por perfil", "MyCTS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenFileDialog saveFileDialog = new OpenFileDialog();
            saveFileDialog.Filter = "JPEG Files(*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;
            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var item in lst)
                {
                    if (item.Name == saveFileDialog.SafeFileName)
                    {
                        MessageBox.Show("No se permiten imagenes con el mismo nombre en un perfil", "MyCTS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                Stream s = saveFileDialog.OpenFile();

                byte[] i = new byte[s.Length];
                s.Read(i,0,i.Length);

                int r = dataGridView.Rows.Add(new DataGridViewRow());

                lst.Add(new DocsSecondLevel() { Name = saveFileDialog.SafeFileName, Image = i, Enable = true });              
                DataGridViewCell cell = new DataGridViewTextBoxCell();
                cell.Value = saveFileDialog.SafeFileName;
                dataGridView.Rows[r].Cells["Imagen"] = cell;
                DataGridViewCell c = new DataGridViewTextBoxCell();
                c.Value = dataGridView.Rows.Count;
                dataGridView.Rows[r].Cells["No"] = c;
                DataGridViewCell btn = new DataGridViewImageCell();
                Icon deleteimg = Resources.Resources.delete;
                dataGridView.Rows[r].Cells["Delete"] = btn;
                dataGridView.Rows[r].Cells["Delete"].Value = deleteimg;
                dataGridView.Rows[r].Cells["Delete"].ToolTipText = "Click para Borrar";
                DataGridViewCell btnD = new DataGridViewImageCell();
                Icon updateimg = Resources.Resources.editar;
                dataGridView.Rows[r].Cells["Update"] = btnD;
                dataGridView.Rows[r].Cells["Update"].Value = updateimg;
                dataGridView.Rows[r].Cells["Update"].ToolTipText = "Click para actualizar";

            }
            lstFisico = (from sss in lst
                         where sss.Enable == true
                         select sss).ToList();
        }

        private void LoadDocuments(string profileId)
        {
            lst = DocsSecondLevelBL.getImageByProfileId(int.Parse(profileId));
            dataGridView.Rows.Clear();

            lstFisico = (from sss in lst
                         where sss.Enable == true
                         select sss).ToList();

            foreach (var item in lst)
            {
                int r = dataGridView.Rows.Add(new DataGridViewRow());
                DataGridViewCell cell = new DataGridViewTextBoxCell();
                cell.Value = item.Name;
                dataGridView.Rows[r].Cells["Imagen"] = cell;
                DataGridViewCell c = new DataGridViewTextBoxCell();
                c.Value = dataGridView.Rows.Count;
                dataGridView.Rows[r].Cells["No"] = c;
                DataGridViewCell btn = new DataGridViewImageCell();
                Icon deleteimg = Resources.Resources.delete;
                dataGridView.Rows[r].Cells["Delete"] = btn;
                dataGridView.Rows[r].Cells["Delete"].Value = deleteimg;
                DataGridViewCell btnD = new DataGridViewImageCell();
                Icon updateimg = Resources.Resources.editar;
                dataGridView.Rows[r].Cells["Update"] = btnD;
                dataGridView.Rows[r].Cells["Update"].Value = updateimg;

                DataGridViewCell btnDoc = new DataGridViewTextBoxCell();
                btnDoc.Value = item.NameDocument;
                dataGridView.Rows[r].Cells["Documento"] = btnDoc;
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            int row = e.RowIndex;
            if (col == 4)
            {
                OpenFileDialog saveFileDialog = new OpenFileDialog();
                saveFileDialog.Filter = "JPEG Files(*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Stream s = saveFileDialog.OpenFile();
                    byte[] i = new byte[s.Length];
                    s.Read(i, 0, i.Length);
                    lst[row].Image = i;
                    lst[row].Name = saveFileDialog.SafeFileName;
                    dataGridView.Rows[row].Cells["Documento"].Value = null;
                    int b = 1;
                    dataGridView.Rows.Clear();
                    lstFisico = (from sss in lst
                                 where sss.Enable == true
                                 select sss).ToList();
                    col = 1;
                    int p = 0;
                    foreach (var a in lst)
                    {
                        if (a != null && a.Enable == true)
                        {
                            int r = dataGridView.Rows.Add(new DataGridViewRow());
                            DataGridViewCell cell = new DataGridViewTextBoxCell();
                            cell.Value = a.Name;
                            dataGridView.Rows[r].Cells["Imagen"] = cell;
                            DataGridViewCell c = new DataGridViewTextBoxCell();
                            c.Value = dataGridView.Rows.Count;
                            dataGridView.Rows[r].Cells["No"] = c;
                            DataGridViewCell btn = new DataGridViewImageCell();
                            Icon deleteimg = Resources.Resources.delete;
                            dataGridView.Rows[r].Cells["Delete"] = btn;
                            dataGridView.Rows[r].Cells["Delete"].Value = deleteimg;
                            DataGridViewCell btnD = new DataGridViewImageCell();
                            Icon updateimg = Resources.Resources.editar;
                            dataGridView.Rows[r].Cells["Update"] = btnD;
                            dataGridView.Rows[r].Cells["Update"].Value = updateimg;
                            if(p != row)
                            {
                            DataGridViewCell btnDoc = new DataGridViewTextBoxCell();
                            btnDoc.Value = a.NameDocument;
                            dataGridView.Rows[r].Cells["Documento"] = btnDoc;
                            }
                            p++;
                        }
                    }
                }
            }
            else if (col == 3)
            {
                var s = from i in lst
                        where i.Name == dataGridView.Rows[row].Cells["Imagen"].Value.ToString()
                        select i;
                List<DocsSecondLevel> p = lst.ToList();
                foreach (var item in s)
                {
                    if (item.ImageId >= 1)
                    {
                        item.Enable = false;
                    }
                    else
                    {
                        p.Remove(item);
                    }
                }

                lst = p;

                //lst = lst.Where(x => x != null).ToList();
                lstFisico = (from sss in lst
                             where sss.Enable == true
                             select sss).ToList();

                dataGridView.Rows.Remove(dataGridView.Rows[row]);

                col = 1;
                foreach (var a in dataGridView.Rows)
                {
                    DataGridViewRow r = (DataGridViewRow)a;
                    r.Cells["No"].Value = col++;
                }
            }
        }
    }
}
