using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Presentation.Components;
using MyCTS.Services;
using MyCTS.Services.Contracts;
using MyCTS.Services.MyCTSOracleConnection;
using MyCTS.Forms.UI;
using MyCTS.Services.ValidateDKsAndCreditCards;
using System.Linq;

namespace MyCTS.Presentation
{
    public partial class ucCreateProfileFirstLevel : CustomUserControl
    {

        /// <summary>
        /// Descripción: User control que crea perfil de primer nivel
        /// Creación:    22 febrero 2010, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>

        private bool InitialFocus = true;

        public ucCreateProfileFirstLevel()
        {
            InitializeComponent();
            this.InitialControlFocus = txtProfileName;
            this.LastControlFocus = btnAccept;
            SetPasswordFormat();

        }
            

        //Evento Load
        private void ucCreateProfileFirsLevel_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtPCC.Text = Login.PCC;
            InitialFocus = false;
            txtProfileName.Focus();
        }

        private void SetPasswordFormat()
        {
            txtPassword.Font = new Font("Symbol", 12, FontStyle.Bold);
            txtPassword.PasswordChar = (char)183;
        }

        //Evento btnAccept_Click
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (txtDK.Text.Length.Equals(6) && txtDK.Text != @"INSTOP")
            {
                if (ExistDkInProfiles(txtDK.Text))
                    return;
                if (!ExistLocationInformation())
                    return;

                txtDK.Focus();
            }
            if (!IsValidBusinessRules)
            {
                DialogResult result = MessageBox.Show(string.Concat(Resources.Profiles.Constants.CREATE_PROFILE_CONFIRMATION, " ", txtProfileName.Text), Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.Yes))
                {
                    CreateProfile();
                }
            }
        }


        #region===== MethodsClass ======

        /// <summary>
        /// Validaciones de Regla de Negocios de las opciones seleccionadas
        /// </summary>
        /// <returns></returns>
        private bool IsValidBusinessRules
        {
            get
            {
                bool isValid = true;
                if (string.IsNullOrEmpty(txtProfileName.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_NOMBRE_PERFIL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtProfileName.Focus();
                }
                else if (string.IsNullOrEmpty(txtDK.Text) || txtDK.Text.Length <6)
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_COD_LOCATION_EMPRESA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDK.Focus();
                }
                else if (string.IsNullOrEmpty(txtPCC.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.DEBES_INGRESAR_PCC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPCC.Focus();
                }
                else if (!string.IsNullOrEmpty(txtProfileName.Text) &&
                !string.IsNullOrEmpty(txtPCC.Text) &&
                 IsStarExist)
                {
                    MessageBox.Show(Resources.Profiles.Profiles.NOMBRE_PERFIL_EXISTENTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEnterpriseName.Focus();
                }
                else if (string.IsNullOrEmpty(txtEnterpriseName.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_NOMBRE_EMPRESA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEnterpriseName.Focus();
                }
                else if (string.IsNullOrEmpty(txtPhone.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_TELEFONO_EMPRESA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPhone.Focus();
                }
                else if (string.IsNullOrEmpty(txtSocialReason.Text) && txtDK.Text != @"INSTOP")
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_RAZON_SOCIAL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSocialReason.Focus();
                }
                else if (string.IsNullOrEmpty(txtStreet.Text) && txtDK.Text != @"INSTOP")
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_CAMPO_CALLE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtStreet.Focus();
                }
                else if (string.IsNullOrEmpty(txtNumberExt.Text) && txtDK.Text != @"INSTOP")
                {
                    MessageBox.Show(Resources.Profiles.Profiles.PROPORCIONA_NUMERO_EXT, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberExt.Focus();
                }
                else if (string.IsNullOrEmpty(txtColony.Text) && txtDK.Text != @"INSTOP")
                {
                    MessageBox.Show(Resources.Profiles.Profiles.CAMPO_COLONIA_NO_INGRESADO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtColony.Focus();
                }
                else if (string.IsNullOrEmpty(txtDelorMunicipality.Text) && txtDK.Text != @"INSTOP")
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_DEL_O_MUNICIPIO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDelorMunicipality.Focus();
                }
                else if (string.IsNullOrEmpty(txtPostalCode.Text) && txtDK.Text != @"INSTOP")
                {
                    MessageBox.Show(Resources.Profiles.Profiles.PROPORCIONA_CODIGO_POSTAL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPostalCode.Focus();
                }
                else if (string.IsNullOrEmpty(txtCity.Text) && txtDK.Text != @"INSTOP")
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_CAMPO_CIUDAD, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCity.Focus();
                }
                else if (string.IsNullOrEmpty(txtState.Text) && txtDK.Text != @"INSTOP")
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_CAMPO_ESTADO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtState.Focus();
                }
                else if ((string.IsNullOrEmpty(txtRFC1.Text) ||
                    string.IsNullOrEmpty(txtRFC2.Text) ||
                    string.IsNullOrEmpty(txtRFC3.Text)) && txtDK.Text != @"INSTOP")
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_RFC_COMPLETO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRFC1.Focus();
                }
                else if (string.IsNullOrEmpty(txtEnterpriseContact.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_NOMBRE_CONTACTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEnterpriseContact.Focus();
                }
                else if (string.IsNullOrEmpty(txtEmailContact.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_EMAIL_CONTACTO , Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmailContact.Focus();        
                }
                else if (!IsValidEmail( txtEmailContact.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.DIRECCION_EMAIL_NO_VALIDA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmailContact.Focus();   
                }

                else if (string.IsNullOrEmpty(txtCreateBy.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_CAMPO_CREADO_POR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCreateBy.Focus();
                }
                else if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_PASSWORD, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassword.Focus();
                }
                else
                {
                    isValid = false;
                }

                return isValid;
            }
        }


        /// <summary>
        /// Valida si el email esta en un formato valido
        /// </summary>
        private Boolean IsValidEmail(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
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
                List<CatAllStars> star = CatAllStarsBL.GetAll1stStarDetailed_Profile(txtPCC.Text, txtProfileName.Text,Login.OrgId);
                if (star.Count > 0)
                    isValid = true;
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
            //string send = "*S";
            //string sabreAnswer = string.Empty;
            string pcc = string.Empty;
            string textValue = string.Empty;
            List<ListItem> profileList = new List<ListItem>();
            
            //using (CommandsAPI objCommand = new CommandsAPI())
            //{
            //    sabreAnswer = objCommand.SendReceive(send);
            //}


            //int col = 0;
            //int row = 0;
            //CommandsQik.searchResponse(sabreAnswer, ".", ref row, ref col);
            //if (row > 0)
            //{
            //    CommandsQik.CopyResponse(sabreAnswer, ref pcc, 1, 1, 4);
            //}

            pcc = txtPCC.Text;

            if (string.IsNullOrEmpty(txtPCC.Text))
                pcc = Login.PCC;

            SetStarsLevel1BL.AddStarslevel1(pcc, txtProfileName.Text, false, true);

            SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_S, txtEnterpriseName.Text, ref profileList);
            SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_A, string.Concat(Resources.Profiles.Constants.COMMAND_NINE, txtPhone.Text, (!string.IsNullOrEmpty(txtExt.Text)) ? string.Concat(Resources.Profiles.Constants.COMMAND_X, txtExt.Text) : string.Empty), ref profileList);
            SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_A, string.Concat(Resources.Profiles.Constants.COMMAND_DK, txtDK.Text), ref profileList);
            SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_P, txtTravelPolicy1.Text, ref profileList);
            SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_P, txtTravelPolicy2.Text, ref profileList);
            SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_P, txtTravelPolicy3.Text, ref profileList);

            if (txtDK.Text != @"INSTOP")
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_A, string.Concat(Resources.Profiles.Constants.COMMAND_FIVE_SLASH, txtSocialReason.Text), ref profileList);

                textValue = string.Format("5/{0}{1}{2},{3}",
                    txtStreet.Text,
                    string.Concat(Resources.Profiles.Constants.AST, txtNumberExt.Text),
                    (!string.IsNullOrEmpty(txtNumberInt.Text)) ? string.Concat(Resources.Profiles.Constants.AST, txtNumberInt.Text) : string.Empty,
                    txtColony.Text);
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_A, textValue, ref profileList);
        
                textValue = string.Format("5/{0}, {1}, {2}",
                    txtDelorMunicipality.Text,
                    txtCity.Text,
                    txtState.Text);
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_A, textValue, ref profileList);
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_A, string.Concat(Resources.Profiles.Constants.COMMAND_FIVE_SLASH, txtPostalCode.Text), ref profileList);
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_A, string.Concat(Resources.Profiles.Constants.COMMAND_FIVE_SLASH, txtRFC1.Text, txtRFC2.Text, txtRFC3.Text), ref profileList);
            }


            if (!string.IsNullOrEmpty(txtCreditCardCode.Text) &&
               !string.IsNullOrEmpty(txtCreditCardNumber.Text))
            {
                textValue = (!string.IsNullOrEmpty(txtExpirationDateMonth.Text) && !string.IsNullOrEmpty(txtExpirationDateYear.Text)) ? string.Format("-{0}/{1}", txtExpirationDateMonth.Text, txtExpirationDateYear.Text) : string.Empty;
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Concat(txtCreditCardCode.Text, txtCreditCardNumber.Text, textValue), ref profileList);
            }


            SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Concat("CONTACTO EMPRESA:", " ", txtEnterpriseContact.Text), ref profileList);

            SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Concat("EMAIL CONTACTO:", " ", txtEmailContact.Text), ref profileList);

            if (!string.IsNullOrEmpty(txtComment1.Text))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, txtComment1.Text, ref profileList);
            }

            if (!string.IsNullOrEmpty(txtComment2.Text))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, txtComment2.Text, ref profileList);
            }

            if (!string.IsNullOrEmpty(txtComment3.Text))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, txtComment3.Text, ref profileList);
            }

            SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Concat(Resources.Profiles.Constants.LABEL_PROFILE_CREATED_BY, " ", txtCreateBy.Text), ref profileList);

            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Concat(Resources.Profiles.Constants.LABEL_PASSWORD, txtPassword.Text), ref profileList);
            }
            DateTime date = DateTime.Now;

            foreach (ListItem Content in profileList)
            {
                SetStarsLevel1InfoBL.AddStarslevel1Info(pcc, txtProfileName.Text, Content.Value, Content.Text, date, false);
            }
            ucProfileSearch.star2Info.Clear();
            ucProfileSearch.star1Info = Star1stLevelInfoBL.GetStar1stLevelInfo(pcc, txtProfileName.Text);
            frmProfiles._ucProfileSearch = null;

            frmProfiles frm = this.ParentForm as frmProfiles;
            frm.Width = frm.MinWidth;
            frm.Height = frm.MinHeight;
            frm.CenterForm();
            frm.IsMinSize = true;
            CatAllStarsBL.ListAllStars.Clear();
            LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_PROFILE_INFO_DISPLAY);
        }

        /// <summary>
        /// Busca si el DK ingresado ya se encuentra en algún perfil guardado
        /// </summary>
        private Boolean  ExistDkInProfiles(string customerDk)
        {
            WsMyCTS wsServ = new WsMyCTS();
            var listProfiles = wsServ.GetStar1ByDk(customerDk).ToList();

            //var listProfiles = GetStar1ProfileByDkBL.GetStar1ByDk(customerDk);
            if(listProfiles.Count > 0)
            {
                string prefiles = "";
                foreach (var prefil in listProfiles )
                {
                    prefiles = prefiles + "    * " + prefil.Level1 + "\n";
                }
                MessageBox.Show("Este DK no puede ser utilizado en la creación del perfil\n"+"debido a que ya pertenece a los siguientes perfiles:\n\n" + prefiles , "Validación DK",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Busca si existe el DK
        /// </summary>
        /// 
        private Boolean ExistLocationInformation()
                {

                    string location = txtDK.Text;
                    WsMyCTS wsServ = new WsMyCTS();
                    MyCTS.Services.ValidateDKsAndCreditCards.Cat1stStarInfoByLocation star1InfoByLocation = null;
                    MyCTS.Services.ValidateDKsAndCreditCards.Cat1stStarInfoByLocation star1InfoByLocation1 = null;
                    //OracleConnection GetProfile = new OracleConnection();
                    //MyCTS.Services.MyCTSOracleConnection.Cat1stStarInfoByLocation star1InfoByLocation = null;
                    //MyCTS.Services.MyCTSOracleConnectionDev.Cat1stStarInfoByLocation star1InfoByLocation1 = null;

                    try
                    {
                        star1InfoByLocation = wsServ.Get1stStarInfoByLocation(location);
                        return true;
                    }
                    catch
                    {
                        star1InfoByLocation = wsServ.Get1stStarInfoByLocation(location);
                        return true;
                    }
            return false;
                }

        /// <summary>
        /// Carga informacion a la mascarilla por Location
        /// </summary>
        private Boolean  ExistAndLoadLocationInformation( )
        {
           
            string location = txtDK.Text;
            WsMyCTS wsServ = new WsMyCTS();
            MyCTS.Services.ValidateDKsAndCreditCards.Cat1stStarInfoByLocation star1InfoByLocation = null;
            MyCTS.Services.ValidateDKsAndCreditCards.Cat1stStarInfoByLocation star1InfoByLocation1 = null;

            try
            {
                star1InfoByLocation = wsServ.Get1stStarInfoByLocation(location);
            }
            catch
            {
                star1InfoByLocation = wsServ.Get1stStarInfoByLocation(location);
            }

            if (star1InfoByLocation != null)
            {
                if (!string.IsNullOrEmpty(star1InfoByLocation.CustomerName))
                {
                    string customer = star1InfoByLocation.CustomerName.ToString();
                    customer = customer.Replace("(", "");
                    customer = customer.Replace(")", "");
                    txtEnterpriseName.Text = customer;
                    txtSocialReason.Text = customer;
                    if (customer == "")
                    {
                        txtEnterpriseName.Enabled = true;
                        txtSocialReason.Enabled = true;
                    }
                    else
                    {
                        txtEnterpriseName.Enabled = false;
                        txtSocialReason.Enabled = false;
                    }
                }

                if (!string.IsNullOrEmpty(star1InfoByLocation.MainPhone) && !star1InfoByLocation.MainPhone.Equals("()"))
                {
                    string phone = star1InfoByLocation.MainPhone.Trim(new char[] { '(', ')' });
                    phone = phone.TrimEnd();
                    phone = phone.TrimStart();
                    txtPhone.Text = phone;
                    if(phone == "")
                        txtPhone.Enabled = true;
                    else
                        txtPhone.Enabled = false;
                    
                }
                if (!string.IsNullOrEmpty(star1InfoByLocation.Address1))
                    txtStreet.Text = star1InfoByLocation.Address1;
                if (star1InfoByLocation.Address1 == "")
                    txtStreet.Enabled = true;
                else
                    txtStreet.Enabled = false;

                if (!string.IsNullOrEmpty(star1InfoByLocation.Address2))
                {
                    star1InfoByLocation.Address2 = star1InfoByLocation.Address2.Replace("#", "");
                    star1InfoByLocation.Address2 = star1InfoByLocation.Address2.TrimStart();
                    
                    txtNumberExt.Text = star1InfoByLocation.Address2;
                    if (star1InfoByLocation.Address2 == "")
                        txtNumberExt.Enabled = true;
                    else
                        txtNumberExt.Enabled = false;
                }
                if (!string.IsNullOrEmpty(star1InfoByLocation.Address3))
                {
                    star1InfoByLocation.Address3 = star1InfoByLocation.Address3.Replace("#", "");
                    star1InfoByLocation.Address3 = star1InfoByLocation.Address3.TrimStart();
                    txtNumberInt.Text = star1InfoByLocation.Address3;
                    txtNumberInt.Enabled = false;
                }else
                    txtNumberInt.Enabled = true;


                if (!string.IsNullOrEmpty(star1InfoByLocation.Address4))
                    txtColony.Text = star1InfoByLocation.Address4;

                if (star1InfoByLocation.Address4 == "")
                    txtColony.Enabled = true;
                else
                    txtColony.Enabled = false;

                if (!string.IsNullOrEmpty(star1InfoByLocation.Municipality))
                {
                    txtDelorMunicipality.Text = star1InfoByLocation.Municipality;
                    txtDelorMunicipality.Enabled = false;
                }
                else
                    txtDelorMunicipality.Enabled = true;


                if (!string.IsNullOrEmpty(star1InfoByLocation.PostalCode))
                {
                    txtPostalCode.Text = star1InfoByLocation.PostalCode;
                    txtPostalCode.Enabled = false;
                }
                else
                    txtPostalCode.Enabled = true;

                if (!string.IsNullOrEmpty(star1InfoByLocation.City))
                {
                    txtCity.Text = star1InfoByLocation.City;
                    txtCity.Enabled = false;
                }else
                    txtCity.Enabled = true;

                if (!string.IsNullOrEmpty(star1InfoByLocation.State))
                {
                    txtState.Text = star1InfoByLocation.State;
                    txtState.Enabled = false;
                }
                else
                    txtState.Enabled = true;

                if (!string.IsNullOrEmpty(star1InfoByLocation.RFC))
                {
                    bool IsRFC = ValidateRegularExpression.ValidateRFCFormat(star1InfoByLocation.RFC);
                    if (IsRFC)
                    {
                        if (star1InfoByLocation.RFC.Length.Equals(13))
                        {
                            txtRFC1.Text = star1InfoByLocation.RFC.Substring(0, 4);
                            txtRFC2.Text = star1InfoByLocation.RFC.Substring(4, 6);
                            txtRFC3.Text = star1InfoByLocation.RFC.Substring(10, 3);
                        }
                       

                        else if (star1InfoByLocation.RFC.Length.Equals(12))
                        {
                            txtRFC1.Text = star1InfoByLocation.RFC.Substring(0, 3);
                            txtRFC2.Text = star1InfoByLocation.RFC.Substring(3, 6);
                            txtRFC3.Text = star1InfoByLocation.RFC.Substring(9, 3);
                        }
                    }
                }
                return true;
            }
            else if (star1InfoByLocation1 != null)
            {
                if (!string.IsNullOrEmpty(star1InfoByLocation1.CustomerName))
                {
                    string customer = star1InfoByLocation1.CustomerName.ToString();
                    customer = customer.Replace("(", "");
                    customer = customer.Replace(")", "");
                    txtEnterpriseName.Text = customer;
                    txtSocialReason.Text = customer;
                }

                if (!string.IsNullOrEmpty(star1InfoByLocation1.MainPhone) && !star1InfoByLocation1.MainPhone.Equals("()"))
                {
                    string phone = star1InfoByLocation1.MainPhone.Trim(new char[] { '(', ')' });
                    phone = phone.TrimEnd();
                    phone = phone.TrimStart();
                    txtPhone.Text = phone;
                }
                if (!string.IsNullOrEmpty(star1InfoByLocation1.Address1))
                    txtStreet.Text = star1InfoByLocation1.Address1;

                if (!string.IsNullOrEmpty(star1InfoByLocation1.Address2))
                {
                    star1InfoByLocation1.Address2 = star1InfoByLocation1.Address2.Replace("#", "");
                    star1InfoByLocation1.Address2 = star1InfoByLocation1.Address2.TrimStart();

                    txtNumberExt.Text = star1InfoByLocation1.Address2;

                }
                if (!string.IsNullOrEmpty(star1InfoByLocation1.Address3))
                {
                    star1InfoByLocation1.Address3 = star1InfoByLocation1.Address3.Replace("#", "");
                    star1InfoByLocation1.Address3 = star1InfoByLocation1.Address3.TrimStart();
                    txtNumberInt.Text = star1InfoByLocation1.Address3;
                }
                if (!string.IsNullOrEmpty(star1InfoByLocation1.Address4))
                    txtColony.Text = star1InfoByLocation1.Address4;

                if (!string.IsNullOrEmpty(star1InfoByLocation1.Municipality))
                    txtDelorMunicipality.Text = star1InfoByLocation1.Municipality;

                if (!string.IsNullOrEmpty(star1InfoByLocation1.PostalCode))
                    txtPostalCode.Text = star1InfoByLocation1.PostalCode;

                if (!string.IsNullOrEmpty(star1InfoByLocation1.City))
                    txtCity.Text = star1InfoByLocation1.City;

                if (!string.IsNullOrEmpty(star1InfoByLocation1.State))
                    txtState.Text = star1InfoByLocation1.State;

                if (!string.IsNullOrEmpty(star1InfoByLocation1.RFC))
                {
                    bool IsRFC = ValidateRegularExpression.ValidateRFCFormat(star1InfoByLocation1.RFC);
                    if (IsRFC)
                    {
                        if (star1InfoByLocation1.RFC.Length.Equals(13))
                        {
                            txtRFC1.Text = star1InfoByLocation1.RFC.Substring(0, 4);
                            txtRFC2.Text = star1InfoByLocation1.RFC.Substring(4, 6);
                            txtRFC3.Text = star1InfoByLocation1.RFC.Substring(10, 3);
                        }
                        else if (star1InfoByLocation1.RFC.Length.Equals(12))
                        {
                            txtRFC1.Text = star1InfoByLocation1.RFC.Substring(0, 3);
                            txtRFC2.Text = star1InfoByLocation1.RFC.Substring(3, 6);
                            txtRFC3.Text = star1InfoByLocation1.RFC.Substring(9, 3);
                        }
                    }
                }
                return true;
            }
            else
            {
                MessageBox.Show("El DK ingresado no existe", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
                 
        }


        /// <summary>
        /// Carga informacion a la mascarilla por Location si falla el metodo principal
        /// </summary>
        private Boolean  ExistLoadLocationInfoBackup()
        {
            string location = txtDK.Text;
            WsMyCTS wsServ = new WsMyCTS();
            MyCTS.Services.ValidateDKsAndCreditCards.Cat1stStarInfoByLocation starFirstInfoByLocation;
            starFirstInfoByLocation = wsServ.Get1stStarInfoByLocation(location);

            //MyCTS.Entities.Cat1stStarInfoByLocation starFirstInfoByLocation = Cat1stStarInfoByLocationBL.Get1stStarInfoByLocation(location);
            if (starFirstInfoByLocation != null)
            {
                if (!string.IsNullOrEmpty(starFirstInfoByLocation.CustomerName))
                {
                    string customer = starFirstInfoByLocation.CustomerName.ToString();
                    customer = customer.Replace("(", "");
                    customer = customer.Replace(")", "");
                    txtEnterpriseName.Text = customer;
                    txtSocialReason.Text = customer;
                }

                if (!string.IsNullOrEmpty(starFirstInfoByLocation.MainPhone) && !starFirstInfoByLocation.MainPhone.Equals("()"))
                {
                    string phone = starFirstInfoByLocation.MainPhone.Trim(new char[] { '(', ')' });
                    phone = phone.TrimEnd();
                    phone = phone.TrimStart();
                    txtPhone.Text = phone;
                }
                if (!string.IsNullOrEmpty(starFirstInfoByLocation.Address1))
                    txtStreet.Text = starFirstInfoByLocation.Address1;

                if (!string.IsNullOrEmpty(starFirstInfoByLocation.Address2))
                {
                    starFirstInfoByLocation.Address2 = starFirstInfoByLocation.Address2.Replace("#", "");
                    starFirstInfoByLocation.Address2 = starFirstInfoByLocation.Address2.TrimStart();

                    txtNumberExt.Text = starFirstInfoByLocation.Address2;

                }
                if (!string.IsNullOrEmpty(starFirstInfoByLocation.Address3))
                {
                    starFirstInfoByLocation.Address3 = starFirstInfoByLocation.Address3.Replace("#", "");
                    starFirstInfoByLocation.Address3 = starFirstInfoByLocation.Address3.TrimStart();
                    txtNumberInt.Text = starFirstInfoByLocation.Address3;
                }
                if (!string.IsNullOrEmpty(starFirstInfoByLocation.Address4))
                    txtColony.Text = starFirstInfoByLocation.Address4;

                if (!string.IsNullOrEmpty(starFirstInfoByLocation.Municipality))
                    txtDelorMunicipality.Text = starFirstInfoByLocation.Municipality;

                if (!string.IsNullOrEmpty(starFirstInfoByLocation.PostalCode))
                    txtPostalCode.Text = starFirstInfoByLocation.PostalCode;

                if (!string.IsNullOrEmpty(starFirstInfoByLocation.City))
                    txtCity.Text = starFirstInfoByLocation.City;

                if (!string.IsNullOrEmpty(starFirstInfoByLocation.State))
                    txtState.Text = starFirstInfoByLocation.State;

                if (!string.IsNullOrEmpty(starFirstInfoByLocation.RFC))
                {
                    bool IsRFC = ValidateRegularExpression.ValidateRFCFormat(starFirstInfoByLocation.RFC);
                    if (IsRFC)
                    {
                        if (starFirstInfoByLocation.RFC.Length.Equals(13))
                        {
                            txtRFC1.Text = starFirstInfoByLocation.RFC.Substring(0, 4);
                            txtRFC2.Text = starFirstInfoByLocation.RFC.Substring(4, 6);
                            txtRFC3.Text = starFirstInfoByLocation.RFC.Substring(10, 3);
                        }
                        else if (starFirstInfoByLocation.RFC.Length.Equals(12))
                        {
                            txtRFC1.Text = starFirstInfoByLocation.RFC.Substring(0, 3);
                            txtRFC2.Text = starFirstInfoByLocation.RFC.Substring(3, 6);
                            txtRFC3.Text = starFirstInfoByLocation.RFC.Substring(9, 3);
                        }
                    }
                }
                return true;
            }
            else
            {
                MessageBox.Show("El DK ingresado no existe", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        #endregion// End MethodsClass


        #region=====Change focus When a Textbox is Full=====

        //Evento txtControl_TextChanged
        private void txtControl_TextChanged(object sender, EventArgs e)
        {
            if (!InitialFocus)
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
            if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }


        }


        #endregion//Back to a Previous Usercontrol or Validate Enter KeyDown


        #region===== Load Values By Location =====

        //Evento txtDK_TextChanged
        private void txtDK_TextChanged(object sender, EventArgs e)
        {
            if (txtDK.Text.Length.Equals(6) && txtDK.Text != @"INSTOP")
            {
                try
                {
                    ExistDkInProfiles(txtDK.Text);
                    ExistAndLoadLocationInformation();
                }
                catch
                {
                   ExistDkInProfiles(txtDK.Text);
                    ExistLoadLocationInfoBackup();
                }

            }
                if(txtDK.Text == @"INSTOP")
                {
                    txtEnterpriseName.Enabled = true;
                    txtPhone.Enabled = true;
                    txtExt.Enabled = true;
                }

            else if (txtDK.Text.Length == 6)
            {
                txtEnterpriseName.Focus();
            }
        }

        #endregion//End Load Values By Location

        
    }
}

