using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Profiles;
using MyCTS.Services;
using MyCTS.Forms.UI;

namespace MyCTS.Presentation
{
    public partial class ucProfileSearch : CustomUserControl
    {

        /// <summary>
        /// Descripción: User control que despliega los resultados de la busqueda rapida
        ///              de perfiles 
        /// Creación:    03 febrero 2010, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>

        public ucProfileSearch()
        {
            InitializeComponent();
        }

        public string Contdor;
        public static List<Star1stLevelInfo> star1Info = new List<Star1stLevelInfo>();
        public static List<Star2ndLevelInfo> star2Info = new List<Star2ndLevelInfo>();
        public static Star1Details ObjStar1Details = new Star1Details();
        public static Star2Details ObjStar2Details = new Star2Details();
        public static Boolean newFormat;
        private List<Dynamic> listFields;
        public static Boolean isMessageUpdateShow;



        Star1Details _objStar1Details = new Star1Details();

        private List<CatAllStars> StarsList = new List<CatAllStars>();

        ProfilesMethods objProfilesMethods = new ProfilesMethods();
        private string[] _parametersReceived;
        private Star2Details _star2D;

        //Evento Load
        private void ucProfileSearch_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            SetInitialValues();
        }

        #region===== MethodsClass =====


        /// <summary>
        /// Limpia valores de listas estaticas y asigna lista de imagenes a listViewProfiles
        /// </summary>
        private void SetInitialValues()
        {
            isMessageUpdateShow = false;
            star1Info.Clear();
            star2Info.Clear();
            listViewProfiles.LargeImageList = imageProfileList;
            listViewProfiles.SmallImageList = imageProfileList;
        }


        /// <summary>
        /// Carga el resultado de la busqueda de perfil en el listview
        /// </summary>
        public int LoadProfileSearchResult(string strToSearch, string sTipoBusqueda, Boolean refresh)
        {
            listViewProfiles.Items.Clear();
            listViewProfiles.Enabled = true;
            StarsList = CatAllStarsBL.GetAllStars(Login.OrgId, strToSearch, sTipoBusqueda);

            int starsCount = StarsList.Count;
            if (starsCount > 0)
            {
                listViewProfiles.View = View.Details;
                for (int i = 0; i < starsCount; i++)
                {
                    if (StarsList[i].Active)
                    {
                        var itemStar = new ListViewItem(StarsList[i].ToString(), (StarsList[i].Level.Equals(Resources.Profiles.Constants.STAR_LEVEL_ONE)) ? 0 : 1);
                        //itemStar.ToolTipText = StarsList[i].Star1Ref;
                        itemStar.SubItems.Add(StarsList[i].Level);
                        itemStar.SubItems.Add(StarsList[i].Star1Ref);
                        itemStar.SubItems.Add(StarsList[i].Email);
                        listViewProfiles.Items.Add(itemStar);
                    }
                }
                return starsCount;
            }
            else
            {
                try
                {
                    var itemStar = new ListViewItem(string.Concat(Resources.Profiles.Constants.NO_RESULTS_FOR, " ", strToSearch));
                    itemStar.SubItems.Add("");
                    listViewProfiles.Items.Add(itemStar);
                    listViewProfiles.Columns[0].Width = 250;
                    listViewProfiles.Enabled = false;
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                }
            }

            return 0;
        }


        private String GetDynamicProperties(string propName)
        {
            string x = "";
            var item = new Dynamic();
            try
            {
                var prop = from p in listFields
                           where p.FieldName.ToLower() == propName.ToLower()
                           select p;

                item = (prop.Count() > 0) ? prop.First<Dynamic>() : null;
                if (item != null)

                    x = item.GetType().GetProperty(item.FieldName).GetValue(item, null).ToString();
                return x;
            }
            catch (Exception ex)
            {
                new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
            }
            return x;
        }


        private Star1Details Getprofile1Level(String pcc, string level1)
        {
            var s1 = new Star1Details();
            var fd = new FieldsDynamicsBL();
            listFields = fd.GetStar1Details(pcc, level1);
            s1.ProfileName = GetDynamicProperties("ProfileName");
            s1.Pcc = GetDynamicProperties("PCC");
            s1.CustomerDk = GetDynamicProperties("CustomerDK");
            s1.CompanyName = GetDynamicProperties("CompanyName");
            s1.Phone = GetDynamicProperties("Telephone");
            s1.Ext = GetDynamicProperties("Ext");
            s1.TravelPolicies = GetDynamicProperties("TravelPolicies");
            s1.SocialReason = GetDynamicProperties("SocialReason");
            s1.Street = GetDynamicProperties("Street");
            s1.OutsideNumber = GetDynamicProperties("OutsideNumber");
            s1.InternalNumber = GetDynamicProperties("InternalNumber");
            s1.Colony = GetDynamicProperties("Colony");
            s1.Municipality = GetDynamicProperties("Municipality");
            s1.PostalCode = GetDynamicProperties("PostalCode");
            s1.City = GetDynamicProperties("City");
            s1.State = GetDynamicProperties("State");
            s1.Rfc = GetDynamicProperties("RFC");
            s1.CreditCard = GetDynamicProperties("CreditCard");
            s1.CVV1 = GetDynamicProperties("CVV1");
            s1.ExpirationDate = GetDynamicProperties("ExpirationDate");
            s1.ContactCompany = GetDynamicProperties("ContactCompany");
            s1.Email = GetDynamicProperties("Email");
            s1.Comments = GetDynamicProperties("Comments");
            s1.CreatedBy = GetDynamicProperties("CreatedBy");
            s1.Password = GetDynamicProperties("Password");
            s1.Id = GetDynamicProperties("Id");
            s1.Osi = GetDynamicProperties("Osi");
            s1.Remarks = GetDynamicProperties("Remarks");
            s1.AlternativeEmail = GetDynamicProperties("AlternativeEmail");
            s1.SabreFormats = GetDynamicProperties("SabreFormats");
            s1.CreditCard2 = GetDynamicProperties("CreditCard2");
            s1.CVV2 = GetDynamicProperties("CVV2");
            s1.ExpirationDate2 = GetDynamicProperties("ExpirationDate2");
            s1.CreditCard3 = GetDynamicProperties("CreditCard3");
            s1.CVV3 = GetDynamicProperties("CVV3");
            s1.ExpirationDate3 = GetDynamicProperties("ExpirationDate3");
            s1.CreditCard4 = GetDynamicProperties("CreditCard4");
            s1.ExpirationDate4 = GetDynamicProperties("ExpirationDate4");
            s1.CreditCard5 = GetDynamicProperties("CreditCard5");
            s1.ExpirationDate5 = GetDynamicProperties("ExpirationDate5");
            s1.SyncStatus = GetDynamicProperties("SyncStatus");
            return s1;
        }

        private Star2Details Getprofile2Level(string email, string dk)
        {
            var s2 = new Star2Details();
            try
            {
                listFields = FieldsDynamicsBL.GetStar2Details(email);
                s2.Id = GetDynamicProperties("Id");
                s2.Pcc = GetDynamicProperties("Pcc");
                s2.Level1 = GetDynamicProperties("Level1");
                s2.Level2 = GetDynamicProperties("Level2");
                s2.Name = GetDynamicProperties("Name");
                s2.LastName = GetDynamicProperties("LastName");
                s2.OfficePhone = GetDynamicProperties("OfficePhone");
                s2.Ext = GetDynamicProperties("Ext");
                s2.OfficePhoneCode = GetDynamicProperties("OfficePhoneCode");
                s2.DirectPhone = GetDynamicProperties("DirectPhone");
                s2.DirectPhoneCode = GetDynamicProperties("DirectPhoneCode");
                s2.Email = GetDynamicProperties("Email");
                s2.FrequentFlyer1 = GetDynamicProperties("FrequentFlyer1");
                s2.FrequentFlyer2 = GetDynamicProperties("FrequentFlyer2");
                s2.FrequentFlyer3 = GetDynamicProperties("FrequentFlyer3");
                s2.FrequentFlyer4 = GetDynamicProperties("FrequentFlyer4");
                s2.FrequentFlyer5 = GetDynamicProperties("FrequentFlyer5");
                s2.Passport = GetDynamicProperties("Passport");
                s2.Passport2 = GetDynamicProperties("Passport2");
                s2.Passport3 = GetDynamicProperties("Passport3");

                s2.Birthday = GetDynamicProperties("Birthday");
                s2.Visa = GetDynamicProperties("Visa");
                s2.ImmigrationForm = GetDynamicProperties("ImmigrationForm");
                s2.Rfc = GetDynamicProperties("RFC");
                s2.CreditCar = GetDynamicProperties("CreditCar");
                s2.PersonalCar = GetDynamicProperties("PersonalCar");
                s2.StreetAndNumber = GetDynamicProperties("StreetAndNumber");
                s2.Colony = GetDynamicProperties("Colony");
                s2.PostalCode = GetDynamicProperties("PostalCode");
                s2.Estate = GetDynamicProperties("Estate");
                s2.City = GetDynamicProperties("City");
                s2.Name2 = GetDynamicProperties("Name2");
                s2.LastName2 = GetDynamicProperties("LastName2");
                s2.Paternal = GetDynamicProperties("Paternal");
                s2.Maternal = GetDynamicProperties("Maternal");
                s2.Occupation = GetDynamicProperties("Occupation");
                s2.Seat = GetDynamicProperties("Seat");
                s2.Family1 = GetDynamicProperties("Family1");
                s2.Family2 = GetDynamicProperties("Family2");
                s2.Family3 = GetDynamicProperties("Family3");
                s2.Family4 = GetDynamicProperties("Family4");
                s2.Family5 = GetDynamicProperties("Family5");
                s2.Family6 = GetDynamicProperties("Family6");
                s2.Comments = GetDynamicProperties("Comments");
                s2.HotelCreditCar = GetDynamicProperties("HotelCreditCar");
                s2.CadHotel1 = GetDynamicProperties("CadHotel1");
                s2.CadHotel2 = GetDynamicProperties("CadHotel2");
                s2.Leasing1 = GetDynamicProperties("Leasing1");
                s2.Leasing2 = GetDynamicProperties("Leasing2");
                s2.Osi = GetDynamicProperties("Osi");
                s2.Remarks = GetDynamicProperties("Remarks");
                s2.AlternativeEmail = GetDynamicProperties("AlternativeEmail");
                s2.SabreFormats = GetDynamicProperties("SabreFormats");
                s2.CreditCard3 = GetDynamicProperties("CreditCard3");
                s2.CreditCard2 = GetDynamicProperties("CreditCard2");
                //nuevos campos
                s2.MonthPreferences = GetDynamicProperties("MonthPreferences");
                s2.PlacePreferences = GetDynamicProperties("PlacePreferences");
                s2.WantInformation = GetDynamicProperties("WantInformation");

                s2.MiddleName = GetDynamicProperties("MiddleName");
                s2.EmployeeID = GetDynamicProperties("EmployeeID");
                s2.TravelClass = GetDynamicProperties("TravelClass");
                s2.Division = GetDynamicProperties("Division");
                s2.CostCenter = GetDynamicProperties("CostCenter");
                s2.ManagerLoginID = GetDynamicProperties("ManagerLoginID");
                s2.Position_Title = GetDynamicProperties("Position_Title");
                s2.CustomerField1 = GetDynamicProperties("CustomerField1");
                s2.CustomerField2 = GetDynamicProperties("CustomerField2");
                s2.CustomerField3 = GetDynamicProperties("CustomerField3");
                s2.Gender = GetDynamicProperties("Gender");


                return s2;
            }
            catch (Exception ex)
            {
                new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
            }
            return s2;
        }

        private Star2Details Getprofile2Level(string pcc, string level1, string level2, string dk)
        {
            var s2 = new Star2Details();
            try
            {
                listFields = FieldsDynamicsBL.GetStar2Details(pcc, level1, level2);
                s2.Id = GetDynamicProperties("Id");
                s2.Pcc = GetDynamicProperties("Pcc");
                s2.Level1 = GetDynamicProperties("Level1");
                s2.Level2 = GetDynamicProperties("Level2");
                s2.Name = GetDynamicProperties("Name");
                s2.LastName = GetDynamicProperties("LastName");
                s2.OfficePhone = GetDynamicProperties("OfficePhone");
                s2.Ext = GetDynamicProperties("Ext");
                s2.OfficePhoneCode = GetDynamicProperties("OfficePhoneCode");
                s2.DirectPhone = GetDynamicProperties("DirectPhone");
                s2.DirectPhoneCode = GetDynamicProperties("DirectPhoneCode");
                s2.Email = GetDynamicProperties("Email");
                s2.FrequentFlyer1 = GetDynamicProperties("FrequentFlyer1");
                s2.FrequentFlyer2 = GetDynamicProperties("FrequentFlyer2");
                s2.FrequentFlyer3 = GetDynamicProperties("FrequentFlyer3");
                s2.FrequentFlyer4 = GetDynamicProperties("FrequentFlyer4");
                s2.FrequentFlyer5 = GetDynamicProperties("FrequentFlyer5");
                s2.Passport = GetDynamicProperties("Passport");
                s2.Passport2 = GetDynamicProperties("Passport2");
                s2.Passport3 = GetDynamicProperties("Passport3");

                s2.Birthday = GetDynamicProperties("Birthday");
                s2.Visa = GetDynamicProperties("Visa");
                s2.ImmigrationForm = GetDynamicProperties("ImmigrationForm");
                s2.Rfc = GetDynamicProperties("RFC");
                s2.CreditCar = GetDynamicProperties("CreditCar");
                s2.PersonalCar = GetDynamicProperties("PersonalCar");
                s2.StreetAndNumber = GetDynamicProperties("StreetAndNumber");
                s2.Colony = GetDynamicProperties("Colony");
                s2.PostalCode = GetDynamicProperties("PostalCode");
                s2.Estate = GetDynamicProperties("Estate");
                s2.City = GetDynamicProperties("City");
                s2.Name2 = GetDynamicProperties("Name2");
                s2.LastName2 = GetDynamicProperties("LastName2");
                s2.Paternal = GetDynamicProperties("Paternal");
                s2.Maternal = GetDynamicProperties("Maternal");
                s2.Occupation = GetDynamicProperties("Occupation");
                s2.Seat = GetDynamicProperties("Seat");
                s2.Family1 = GetDynamicProperties("Family1");
                s2.Family2 = GetDynamicProperties("Family2");
                s2.Family3 = GetDynamicProperties("Family3");
                s2.Family4 = GetDynamicProperties("Family4");
                s2.Family5 = GetDynamicProperties("Family5");
                s2.Family6 = GetDynamicProperties("Family6");
                s2.Comments = GetDynamicProperties("Comments");
                s2.HotelCreditCar = GetDynamicProperties("HotelCreditCar");
                s2.CadHotel1 = GetDynamicProperties("CadHotel1");
                s2.CadHotel2 = GetDynamicProperties("CadHotel2");
                s2.Leasing1 = GetDynamicProperties("Leasing1");
                s2.Leasing2 = GetDynamicProperties("Leasing2");
                s2.Osi = GetDynamicProperties("Osi");
                s2.Remarks = GetDynamicProperties("Remarks");
                s2.AlternativeEmail = GetDynamicProperties("AlternativeEmail");
                s2.SabreFormats = GetDynamicProperties("SabreFormats");
                s2.CreditCard3 = GetDynamicProperties("CreditCard3");
                s2.CreditCard2 = GetDynamicProperties("CreditCard2");
                //nuevos campos
                s2.MonthPreferences = GetDynamicProperties("MonthPreferences");
                s2.PlacePreferences = GetDynamicProperties("PlacePreferences");
                s2.WantInformation = GetDynamicProperties("WantInformation");
                s2.CadHotel3 = GetDynamicProperties("CadHotel3");
                s2.Leasing3 = GetDynamicProperties("Leasing3");
                s2.MiddleName = GetDynamicProperties("MiddleName");
                s2.EmployeeID = GetDynamicProperties("EmployeeID");
                s2.TravelClass = GetDynamicProperties("TravelClass");
                s2.Division = GetDynamicProperties("Division");
                s2.CostCenter = GetDynamicProperties("CostCenter");
                s2.ManagerLoginID = GetDynamicProperties("ManagerLoginID");
                s2.Position_Title = GetDynamicProperties("Position_Title");
                s2.CustomerField1 = GetDynamicProperties("CustomerField1");
                s2.CustomerField2 = GetDynamicProperties("CustomerField2");
                s2.CustomerField3 = GetDynamicProperties("CustomerField3");
                s2.Gender = GetDynamicProperties("Gender");
                s2.Documents = GetDynamicProperties("Documents");
                return s2;
            }
            catch (Exception ex)
            {
                new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
            }
            return s2;
        }

        /// <summary>
        /// Carga informacion de perfil elegido por el usuario
        /// </summary>
        private void SetProfileInfo()
        {
            int indexProfile = 0;
            if (listViewProfiles.SelectedIndices.Count > 0)
            {
                indexProfile = listViewProfiles.SelectedIndices[0];
            }

            var objGetStar1DetailsBL = new GetStar1DetailsBL();

            // Swhichea entre el obtener el perfil en el esquema anterior y el nuevo
            if (StarsList[indexProfile].Level.Equals(Resources.Profiles.Constants.STAR_LEVEL_ONE))
            {
                if (StarsList[indexProfile].IsNew)
                {
                    _objStar1Details = Getprofile1Level(StarsList[indexProfile].PccId, StarsList[indexProfile].StarName);
                    star1Info = objProfilesMethods.FormatSabreProfile1L(_objStar1Details);
                    AccessProfile(star1Info[0].Level1);
                }
                else
                {
                    star1Info = Star1stLevelInfoBL.GetStar1stLevelInfo(StarsList[indexProfile].PccId, StarsList[indexProfile].StarName);

                    DialogResult result = MessageBox.Show("Para usar este perfil es necesario actualizarlo al nuevo módulo de perfiles \n¿Desea continuar?",
                                                           @"Actualizacion de perfil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        isMessageUpdateShow = true;
                        newFormat = true;
                        if (AccessProfile(star1Info[0].Level1))
                        {
                            var uProfiles = new frmUpdateProfiles(this.ParentForm, "First");
                            uProfiles.ShowDialog();

                        }

                        return;
                    }
                }
            }

            else if (StarsList[indexProfile].Level.Equals(Resources.Profiles.Constants.STAR_LEVEL_TWO))
            {


                _objStar1Details = Getprofile1Level(StarsList[indexProfile].PccId, StarsList[indexProfile].Star1Ref);
                star1Info = objProfilesMethods.FormatSabreProfile1L(_objStar1Details);



                if (StarsList[indexProfile].IsNew)
                {

                    _star2D = Getprofile2Level(StarsList[indexProfile].PccId, StarsList[indexProfile].Star1Ref, StarsList[indexProfile].StarName, StarsList[indexProfile].DK);
                    //_star2D = Getprofile2Level(StarsList[indexProfile].Email, StarsList[indexProfile].DK);
                    ObjStar2Details = _star2D;
                    star2Info = objProfilesMethods.FormatSabreProfile2L(_star2D);
                    AccessProfile(star2Info[0].Level2);

                }
                else
                {
                    if (!GetStar1stLevelByStar2LevelBL.GetStar1stLevelByStar2Level(StarsList[indexProfile].Star1Ref, StarsList[indexProfile].PccId))
                    {
                        MessageBox.Show("No es posible actualizar este perfil ya que el perfil de primer nivel al que pertenece " + StarsList[indexProfile].Star1Ref + " aún no está actualizado", "No es posible Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        star2Info = Star2ndLevelInfoBL.GetStar2ndLevelInfo(StarsList[indexProfile].PccId, StarsList[indexProfile].Star1Ref, StarsList[indexProfile].StarName);

                        DialogResult result = MessageBox.Show("Para usar este perfil es necesario actualizarlo al nuevo módulo de perfiles \n¿Desea continuar?",
                                                              @"Actualizacion de perfil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            newFormat = true;
                            isMessageUpdateShow = true;
                            if (AccessProfile(star2Info[0].Level2))
                            {
                                var frm = this.ParentForm as frmProfiles;
                                newFormat = true;
                                var fe = new frmUpdateProfiles(this.ParentForm, "Second");
                                fe.ShowDialog();

                            }
                            return;
                        }
                    }
                }
            }

        }


        /// <summary>
        /// Verifica la contraseña del perfil para tener acceso a la información
        /// </summary>
        private Boolean AccessProfile(string Profile)
        {
            Boolean isValid = true;
            string pwdProfile = string.Empty;
            if (ucProfileSearch.star1Info.Count > 0)
            {
                if (!(!string.IsNullOrEmpty(Login.ProfileAllAccess) && Login.ProfileAllAccess.Equals("A")))
                {
                    foreach (Star1stLevelInfo line in star1Info)
                    {
                        if (line.Type.Equals(Resources.Profiles.Constants.LINE_TYPE_N) && line.Text.Contains(Resources.Profiles.Constants.PWD_ID))
                        {
                            string[] password = line.Text.Split(new char[] { '*' });
                            pwdProfile = password[1];
                            break;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(pwdProfile))
                {
                    var ib = new InputBoxDialog();
                    ib.FormPrompt = Resources.Profiles.Constants.INTRODUCE_PASSWORD;
                    ib.FormCaption = string.Concat(Resources.Profiles.Constants.MODAL_PWD_TITLE, " ", Profile);
                    ib.DefaultValue = string.Empty;
                    ib.ModeToShow = InputBoxDialog.ModeTextBox.Password;
                    ib.Text = pwdProfile;
                    ib.ShowDialog();

                    string s = ib.InputResponse.ToUpper();
                    if (ib.DialogResult == DialogResult.Cancel)
                    {
                        ib.Close();
                        return false;
                    }
                    if ((Login.Supervisor) && (s.Equals(pwdProfile) || s.Equals(Login.passWord)))
                    {
                        frmProfiles._ucProfileSearch = null;
                        if (!newFormat)
                            LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_PROFILE_INFO_DISPLAY);
                        return true;
                    }
                    else if (s.Equals(pwdProfile))
                    {
                        frmProfiles._ucProfileSearch = null;
                        if (!newFormat)
                            LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_PROFILE_INFO_DISPLAY);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show(Resources.Profiles.Constants.PASSWORD_ERROR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    frmProfiles._ucProfileSearch = null;
                    if (!newFormat)
                        LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_PROFILE_INFO_DISPLAY);
                }
            }
            return isValid;
        }


        #endregion//end MethodsClass


        #region===== listViewProfiles Events =====

        //Evento listViewProfiles_DoubleClick
        private void listViewProfiles_DoubleClick(object sender, EventArgs e)
        {
            SetProfileInfo();
        }


        //Evento listViewProfiles_KeyDown
        private void listViewProfiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Enter) &&
                listViewProfiles.SelectedItems.Count > 0)
            {
                SetProfileInfo();
            }
        }

        #endregion//listViewProfiles Events
    }
}
