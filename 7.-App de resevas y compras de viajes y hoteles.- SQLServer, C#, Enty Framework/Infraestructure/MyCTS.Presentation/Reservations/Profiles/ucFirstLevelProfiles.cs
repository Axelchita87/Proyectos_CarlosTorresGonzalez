using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Forms.UI;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Resources.Profiles;
using MyCTS.Services.ValidateDKsAndCreditCards;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyCTS.Presentation.Reservations.Profiles

{
    public partial class ucFirstLevelProfiles : CustomUserControl
    {

        /// <summary>
        /// Descripción: User control que crea perfil de primer nivel
        /// Creación:    22 febrero 2010, Modificación: 15 Julio 2011
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// Modifico:    a. Chargoy
        /// </summary>

        private bool InitialFocus = true;
        private List<Dynamic> listFields; //En esta lista se almacena los datos procedentes de la BD y solo sirve para mostrarlos en el Formulario
        private List<Dynamic> listFields2 = new List<Dynamic>();//En esta lista se almacena los datos recuperados del formulario para ser guardados en la BD
        private Dynamic item2;
        private int? profileId = null;
        private Boolean _isNew= false;


        public List<DocsFirstLevel> lst = new List<DocsFirstLevel>();
        public List<DocsFirstLevel> lstFisico = new List<DocsFirstLevel>();


        ProfilesMethods objProfilesMethods = new ProfilesMethods();
        private Star1Details s1Details;
        public ucFirstLevelProfiles()
        {
            InitializeComponent();
            InitialControlFocus = txtProfileName;
            LastControlFocus = btnAccept;
            SetPasswordFormat();
        }

        //Evento btnAccept_Click
        private void btnAccept_Click(object sender, EventArgs e)
        {

            if(Parameters == null)
                Parameters = new string[4];

            var df = new FieldsDynamicsBL();
            if (txtDK.Text.Length.Equals(6) && txtDK.Text != @"INSTOP")
            {
                if (ExistDkInProfiles(txtDK.Text, Parameters[3]))
                    return;
                if (!ExistLocationInformation())
                    return;

                txtDK.Focus();
            }

            if (!IsValidBusinessRules)
            {
                var objGetStar1DetailsBL = new GetStar1DetailsBL();

                //Si en el objeto s1Deatails existe un Id se considera que se va actualizar el perfil
                //de lo contrario se creara un perfil nuevo
                if(profileId == null)
                {
                    DialogResult result = MessageBox.Show(string.Concat(Constants.NOMBRE_DK,"\n","\n",string.Format( Constants.UPDATE_PROFILE_CONFIRMATION_FIRST_LEVEL,
                                          txtProfileName.Text, txtDK.Text)), Resources.Constants.MYCTS, MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.Yes))
                    {
                        LoadFiels();
                        //s1Details.Historic = GetHistoricData();
                        if (Parameters[3] == "NewUpdate")
                        {
                            Update1stLevelBL.Update1stLevel(s1Details.Pcc, txtProfileName.Text, txtDK.Text,0);
                        }
                        else
                            SetStarsLevel1BL.AddStarslevel1(s1Details.Pcc, txtDK.Text, false, true);
                        
                        df.SetOrUpdateStar(listFields2,null,1);//Crea un perfil
                        
                        if (Parameters[1] != txtProfileName.Text)
                            Update1stLevelBL.Update1stLevel(s1Details.Pcc, Parameters[1], txtDK.Text, 0);

                        

                       
                        SetLogNewFormatProfilesBL.SetLogNewFormatProfiles(s1Details.Pcc, Login.NombreCompleto, txtDK.Text, null, DateTime.Now);
                        
                        LoadUcProfileSearch(LoadStar1Details(s1Details.Pcc, txtDK.Text));
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show(string.Concat(Constants.UPDATE_PROFILE_CONFIRMATION_SECOND_LEVEL, " ",
                                          txtProfileName.Text), Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.Yes))
                    {
                        LoadFiels();
                        df.SetOrUpdateStar(listFields2,profileId,1); //Actualiza el perfil

                        // Update de imagenes
                        int j = 0;
                        foreach (var d in lstFisico)
                        {
                            if (dataGridView.Rows.Count > 0)
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

                        foreach (var d in lst)
                        {
                            if (d.ImageId >= 1)
                            {
                                bool success = MyCTS.Business.DocsFirstLevelBL.UpdateImage(d);
                            }
                            else
                            {

                                bool success = MyCTS.Business.DocsFirstLevelBL.AddImage(d);
                            }
                        }
                        lst.Clear();


                        if (Parameters[1] != txtProfileName.Text)
                            Update1stLevelBL.Update1stLevel(s1Details.Pcc, Parameters[1], txtProfileName.Text, 0);
                        
                       
                        
                        SetLogNewFormatProfilesBL.SetLogNewFormatProfiles(s1Details.Pcc, Login.NombreCompleto, txtDK.Text, null, DateTime.Now);
                        LoadUcProfileSearch(LoadStar1Details(s1Details.Pcc, txtDK.Text));
                        
                    }
                }
            }
        }


        #region ===== MethodsClass ======
        /// <summary>
        ///   Muestra solo los ultimos 4 digitos de la tarjeta.
        /// </summary>
        /// <returns> </returns>
        public static string MascaraNumeroTarjeta(string NumeroTarjeta, string LetraSuplantadora)
        {
            //if (string.IsNullOrEmpty(NumeroTarjeta))
            //{
            //    return String.Empty;
            //}

            //if (string.IsNullOrEmpty(LetraSuplantadora))
            //{
            //    LetraSuplantadora = "X";
            //}

            //if (NumeroTarjeta.Length > 10)
            //{
            //    Int32 iDigitosInvisibles = NumeroTarjeta.Length;
            //    string NumeroTarjetaIzquierda = NumeroTarjeta.Substring(0, 4);
            //    string NumeroTarjetaDerecha = NumeroTarjeta.Substring(iDigitosInvisibles - 4, 4);
            //    NumeroTarjeta = NumeroTarjetaIzquierda.PadRight(NumeroTarjeta.Length - 4, Char.Parse(LetraSuplantadora.Substring(0, 1))) + NumeroTarjetaDerecha;
            //}

            return NumeroTarjeta;
        }

        private void SetPasswordFormat()
        {
            txtPassword.Font = new Font("Symbol", 12, FontStyle.Bold);
            txtPassword.PasswordChar = (char)183;
        }
        private void SetSmartTextBoxSecurityFormat(SmartTextBox txt)
        {
            txt.Font = new Font("Symbol", 12, FontStyle.Bold);
            txt.PasswordChar = (char)183;
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
                if (string.IsNullOrEmpty(txtProfileName.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_NOMBRE_PERFIL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtProfileName.Focus();
                }
                else if (string.IsNullOrEmpty(txtDK.Text) || txtDK.Text.Length < 6)
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_COD_LOCATION_EMPRESA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDK.Focus();
                }
                else if (string.IsNullOrEmpty(txtPCC.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.DEBES_INGRESAR_PCC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPCC.Focus();
                }
                else if (!string.IsNullOrEmpty(txtProfileName.Text) && !string.IsNullOrEmpty(txtPCC.Text) && profileId == null  && IsStarExist && Parameters[3] != "NewUpdate")
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
                else if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_PASSWORD, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassword.Focus();
                }
                else if (!string.IsNullOrEmpty(txtPhone.Text) && !ValidateRegularExpression.ValidatePhoneNumber(txtPhone.Text))
                {
                    MessageBox.Show("El formato de telefono solo debe de ser de 10 números.", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPhone.Focus();
                }
                //else if (string.IsNullOrEmpty(txtSocialReason.Text) && txtDK.Text != @"INSTOP")
                //{
                //    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_RAZON_SOCIAL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtSocialReason.Focus();
                //}
                //else if (string.IsNullOrEmpty(txtStreet.Text) && txtDK.Text != @"INSTOP")
                //{
                //    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_CAMPO_CALLE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtStreet.Focus();
                //}
                //else if (string.IsNullOrEmpty(txtNumberExt.Text) && txtDK.Text != @"INSTOP")
                //{
                //    MessageBox.Show(Resources.Profiles.Profiles.PROPORCIONA_NUMERO_EXT, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtNumberExt.Focus();
                //}
                //else if (string.IsNullOrEmpty(txtColony.Text) && txtDK.Text != @"INSTOP")
                //{
                //    MessageBox.Show(Resources.Profiles.Profiles.CAMPO_COLONIA_NO_INGRESADO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtColony.Focus();
                //}
                //else if (string.IsNullOrEmpty(txtDelorMunicipality.Text) && txtDK.Text != @"INSTOP")
                //{
                //    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_DEL_O_MUNICIPIO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtDelorMunicipality.Focus();
                //}
                //else if (string.IsNullOrEmpty(txtPostalCode.Text) && txtDK.Text != @"INSTOP")
                //{
                //    MessageBox.Show(Resources.Profiles.Profiles.PROPORCIONA_CODIGO_POSTAL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtPostalCode.Focus();
                //}
                //else if (string.IsNullOrEmpty(txtCity.Text) && txtDK.Text != @"INSTOP")
                //{
                //    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_CAMPO_CIUDAD, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtCity.Focus();
                //}
                //else if (string.IsNullOrEmpty(txtState.Text) && txtDK.Text != @"INSTOP")
                //{
                //    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_CAMPO_ESTADO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtState.Focus();
                //}
                //else if ((string.IsNullOrEmpty(txtRFC1.Text) ||
                //    string.IsNullOrEmpty(txtRFC2.Text) ||
                //    string.IsNullOrEmpty(txtRFC3.Text)) && txtDK.Text != @"INSTOP")
                //{
                //    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_RFC_COMPLETO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtRFC1.Focus();
                //}
                else if (string.IsNullOrEmpty(txtEnterpriseContact.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_NOMBRE_CONTACTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEnterpriseContact.Focus();
                }
                else if (string.IsNullOrEmpty(txtEmailContact.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_EMAIL_CONTACTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmailContact.Focus();
                }
                else if (!IsValidEmail(txtEmailContact.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.DIRECCION_EMAIL_NO_VALIDA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmailContact.Focus();
                }

                else if (string.IsNullOrEmpty(txtCreateBy.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_CAMPO_CREADO_POR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCreateBy.Focus();
                }
           //     else if ((!string.IsNullOrEmpty(txtCreditCardCode.Text) || !string.IsNullOrEmpty(txtCreditCardNumber.Text) || !string.IsNullOrEmpty(txtExpirationDateMonth.Text) || !string.IsNullOrEmpty(txtExpirationDateYear.Text)) &&
           //!(!string.IsNullOrEmpty(txtCreditCardCode.Text) && !string.IsNullOrEmpty(txtCreditCardNumber.Text) && !string.IsNullOrEmpty(txtExpirationDateMonth.Text) && !string.IsNullOrEmpty(txtExpirationDateYear.Text)))
           //     {
           //         MessageBox.Show(Resources.Profiles.Profiles.INGRESA_DATOS_TARJETA_CREDITO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
           //         if (string.IsNullOrEmpty(txtCreditCardCode.Text))
           //             txtCreditCardCode.Focus();
           //         else if (string.IsNullOrEmpty(txtCreditCardNumber.Text))
           //             txtCreditCardNumber.Focus();
           //         else if (string.IsNullOrEmpty(txtExpirationDateMonth.Text))
           //             txtExpirationDateMonth.Focus();
           //         else if (string.IsNullOrEmpty(txtExpirationDateYear.Text))
           //             txtExpirationDateYear.Focus();
           //     }
                else if ((!string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode.Text) || !string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC.Password) || !string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM.Password) || !string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY.Password)) &&
               !(!string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode.Text) && !string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC.Password) && !string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM.Password) && !string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY.Password)))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_DATOS_TARJETA_CREDITO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode.Text))
                        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode.Focus();
                    else if (string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC.Password))
                        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC.Focus();
                    else if (string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM.Password))
                        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM.Focus();
                    else if (string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY.Password))
                        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY.Focus();
                }
               // else if ((!string.IsNullOrEmpty(txtCreditCardCode2.Text) || !string.IsNullOrEmpty(txtCreditCardNumber2.Text) || !string.IsNullOrEmpty(txtExpirationDateMonth2.Text) || !string.IsNullOrEmpty(txtExpirationDateYear2.Text)) &&
               //!(!string.IsNullOrEmpty(txtCreditCardCode2.Text) && !string.IsNullOrEmpty(txtCreditCardNumber2.Text) && !string.IsNullOrEmpty(txtExpirationDateMonth2.Text) && !string.IsNullOrEmpty(txtExpirationDateYear2.Text)))
               // {
               //     MessageBox.Show(Resources.Profiles.Profiles.INGRESA_DATOS_TARJETA_CREDITO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
               //     if (string.IsNullOrEmpty(txtCreditCardCode2.Text))
               //         txtCreditCardCode2.Focus();
               //     else if (string.IsNullOrEmpty(txtCreditCardNumber2.Text))
               //         txtCreditCardNumber2.Focus();
               //     else if (string.IsNullOrEmpty(txtExpirationDateMonth2.Text))
               //         txtExpirationDateMonth2.Focus();
               //     else if (string.IsNullOrEmpty(txtExpirationDateYear2.Text))
               //         txtExpirationDateYear2.Focus();
               // }
                else if ((!string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode2.Text) || !string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC2.Password) || !string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM2.Password) || !string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY2.Password)) &&
          !(!string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode2.Text) && !string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC2.Password) && !string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM2.Password) && !string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY2.Password)))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_DATOS_TARJETA_CREDITO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode2.Text))
                        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode2.Focus();
                    else if (string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC2.Password))
                        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC2.Focus();
                    else if (string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM2.Password))
                        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM2.Focus();
                    else if (string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY2.Password))
                        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY2.Focus();
                }
               // else if ((!string.IsNullOrEmpty(txtCreditCardCode3.Text) || !string.IsNullOrEmpty(txtCreditCardNumber3.Text) || !string.IsNullOrEmpty(txtExpirationDateMonth3.Text) || !string.IsNullOrEmpty(txtExpirationDateYear3.Text)) &&
               //!(!string.IsNullOrEmpty(txtCreditCardCode3.Text) && !string.IsNullOrEmpty(txtCreditCardNumber3.Text) && !string.IsNullOrEmpty(txtExpirationDateMonth3.Text) && !string.IsNullOrEmpty(txtExpirationDateYear3.Text)))
               // {
               //     MessageBox.Show(Resources.Profiles.Profiles.INGRESA_DATOS_TARJETA_CREDITO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
               //     if (string.IsNullOrEmpty(txtCreditCardCode3.Text))
               //         txtCreditCardCode3.Focus();
               //     else if (string.IsNullOrEmpty(txtCreditCardNumber3.Text))
               //         txtCreditCardNumber3.Focus();
               //     else if (string.IsNullOrEmpty(txtExpirationDateMonth3.Text))
               //         txtExpirationDateMonth3.Focus();
               //     else if (string.IsNullOrEmpty(txtExpirationDateYear3.Text))
               //         txtExpirationDateYear3.Focus();
               // }
                else if ((!string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode3.Text) || !string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC3.Password) || !string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM3.Password) || !string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY3.Password)) &&
     !(!string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode3.Text) && !string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC3.Password) && !string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM3.Password) && !string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY3.Password)))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_DATOS_TARJETA_CREDITO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode3.Text))
                        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode3.Focus();
                    else if (string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC3.Password))
                        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC3.Focus();
                    else if (string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM3.Password))
                        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM3.Focus();
                    else if (string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY3.Password))
                        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY3.Focus();
                }
               // else if ((!string.IsNullOrEmpty(txtCreditCardCode4.Text) || !string.IsNullOrEmpty(txtCreditCardNumber4.Text) || !string.IsNullOrEmpty(txtExpirationDateMonth4.Text) || !string.IsNullOrEmpty(txtExpirationDateYear4.Text)) &&
               //!(!string.IsNullOrEmpty(txtCreditCardCode4.Text) && !string.IsNullOrEmpty(txtCreditCardNumber4.Text) && !string.IsNullOrEmpty(txtExpirationDateMonth4.Text) && !string.IsNullOrEmpty(txtExpirationDateYear4.Text)))
               // {
               //     MessageBox.Show(Resources.Profiles.Profiles.INGRESA_DATOS_TARJETA_CREDITO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
               //     if (string.IsNullOrEmpty(txtCreditCardCode4.Text))
               //         txtCreditCardCode4.Focus();
               //     else if (string.IsNullOrEmpty(txtCreditCardNumber4.Text))
               //         txtCreditCardNumber4.Focus();
               //     else if (string.IsNullOrEmpty(txtExpirationDateMonth4.Text))
               //         txtExpirationDateMonth4.Focus();
               //     else if (string.IsNullOrEmpty(txtExpirationDateYear4.Text))
               //         txtExpirationDateYear4.Focus();
               // }
                else if ((!string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode4.Text) || !string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC4.Password) || !string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM4.Password) || !string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY4.Password)) &&
 !(!string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode4.Text) && !string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC4.Password) && !string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM4.Password) && !string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY4.Password)))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_DATOS_TARJETA_CREDITO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode4.Text))
                        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode4.Focus();
                    else if (string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC4.Password))
                        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC4.Focus();
                    else if (string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM4.Password))
                        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM4.Focus();
                    else if (string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY4.Password))
                        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY4.Focus();
                }
               // else if ((!string.IsNullOrEmpty(txtCreditCardCode5.Text) || !string.IsNullOrEmpty(txtCreditCardNumber5.Text) || !string.IsNullOrEmpty(txtExpirationDateMonth5.Text) || !string.IsNullOrEmpty(txtExpirationDateYear5.Text)) &&
               //!(!string.IsNullOrEmpty(txtCreditCardCode5.Text) && !string.IsNullOrEmpty(txtCreditCardNumber5.Text) && !string.IsNullOrEmpty(txtExpirationDateMonth5.Text) && !string.IsNullOrEmpty(txtExpirationDateYear5.Text)))
               // {
               //     MessageBox.Show(Resources.Profiles.Profiles.INGRESA_DATOS_TARJETA_CREDITO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
               //     if (string.IsNullOrEmpty(txtCreditCardCode5.Text))
               //         txtCreditCardCode5.Focus();
               //     else if (string.IsNullOrEmpty(txtCreditCardNumber5.Text))
               //         txtCreditCardNumber5.Focus();
               //     else if (string.IsNullOrEmpty(txtExpirationDateMonth5.Text))
               //         txtExpirationDateMonth5.Focus();
               //     else if (string.IsNullOrEmpty(txtExpirationDateYear5.Text))
               //         txtExpirationDateYear5.Focus();
               // }
                else if ((!string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode5.Text) || !string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC5.Password) || !string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM5.Password) || !string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY5.Password)) &&
!(!string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode5.Text) && !string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC5.Password) && !string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM5.Password) && !string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY5.Password)))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_DATOS_TARJETA_CREDITO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode5.Text))
                        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode5.Focus();
                    else if (string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC5.Password))
                        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC5.Focus();
                    else if (string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM5.Password))
                        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM5.Focus();
                    else if (string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY5.Password))
                        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY5.Focus();
                }
                else
                {
                    isValid = false;
                }

                Panel pnl1Osi = (Panel)ucMultiLineSmartTextOSI.Controls.Find("panel1", false)[0];
                foreach (Control ctrl in pnl1Osi.Controls)
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
        /// Valida si el email esta en un formato valido
        /// </summary>
        private static Boolean IsValidEmail(String email)
        {
            const string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
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
                List<CatAllStars> star = CatAllStarsBL.GetAll1stStarDetailed_Profile(txtPCC.Text, txtProfileName.Text, Login.OrgId);
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
        /// Abre el ucProfileSearch con el nuevo perfil creado
        /// </summary>
        private void LoadUcProfileSearch(Star1Details objStar1Details)
        {
            ucProfileSearch.star2Info.Clear();
            ucProfileSearch.star1Info = objProfilesMethods.FormatSabreProfile1L(objStar1Details);  //Star1stLevelInfoBL.GetStar1stLevelInfo(pcc, txtProfileName.Text);
            frmProfiles._ucProfileSearch = null;
            if (Parameters == null)
                Parameters = new string[4];


            var frm = this.ParentForm as frmProfiles;


            MessageBox.Show("EL PERFIL HA SIDO ACTUALIZADO CON ÉXITO EN LA NUEVA ESTRUCTURA, YA PUEDES COMENZAR A TRABAJAR CON ÉL " + objStar1Details.CustomerDk, Resources.Constants.MYCTS, MessageBoxButtons.OK,
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


        private Star1Details LoadStar1Details(string pcc, string level1)
        {
            var fd = new FieldsDynamicsBL();
            var list = fd.GetStar1Details(pcc, level1);
            string syncStatus = string.Empty;

            try
            {
                syncStatus = GetDynamicProperties("SyncStatus",list);
            }
            catch(Exception ex)
            {
                syncStatus = "0";
                ex.ToString();
            }

            s1Details = new Star1Details
            {
                Id = GetDynamicProperties("Id",list),
                ProfileName = GetDynamicProperties("ProfileName",list),
                Pcc = GetDynamicProperties("Pcc",list),
                CustomerDk = GetDynamicProperties("CustomerDk",list),
                CompanyName = GetDynamicProperties("CompanyName",list),
                Phone = GetDynamicProperties("Telephone",list),
                Ext = GetDynamicProperties("Ext",list),
                TravelPolicies = GetDynamicProperties("TravelPolicies",list),
                SocialReason = GetDynamicProperties("SocialReason",list),
                Street = GetDynamicProperties("Street",list),
                OutsideNumber = GetDynamicProperties("OutsideNumber",list),
                InternalNumber = GetDynamicProperties("InternalNumber",list),
                Colony = GetDynamicProperties("Colony",list),
                Municipality = GetDynamicProperties("Municipality",list),
                PostalCode = GetDynamicProperties("PostalCode",list),
                City = GetDynamicProperties("City",list),
                State = GetDynamicProperties("State",list),
                Rfc = GetDynamicProperties("Rfc",list),
                CreditCard = GetDynamicProperties("CreditCard",list),
                ExpirationDate = GetDynamicProperties("ExpirationDate",list),
                ContactCompany = GetDynamicProperties("ContactCompany",list),
                Email = GetDynamicProperties("Email",list),
                Comments = GetDynamicProperties("Comments",list),
                CreatedBy = GetDynamicProperties("CreatedBy",list),
                Password = GetDynamicProperties("Password",list),
                Osi=GetDynamicProperties("Osi",list),
                Remarks=GetDynamicProperties("Remarks",list),
                AlternativeEmail=GetDynamicProperties("AlternativeEmail",list),
                Historic=GetDynamicProperties("Historic", list),
                SabreFormats=GetDynamicProperties("SabreFormats", list),
                CreditCard2 = GetDynamicProperties("CreditCard2", list),
                CreditCard3 = GetDynamicProperties("CreditCard3", list),
                CreditCard4 = GetDynamicProperties("CreditCard4", list),
                CreditCard5 = GetDynamicProperties("CreditCard5", list),
                ExpirationDate2 = GetDynamicProperties("ExpirationDate2", list),
                ExpirationDate3 = GetDynamicProperties("ExpirationDate3", list),
                ExpirationDate4 = GetDynamicProperties("ExpirationDate4", list),
                ExpirationDate5 = GetDynamicProperties("ExpirationDate5", list),
                SyncStatus = syncStatus
            };

            return s1Details;
        }


        /// <summary>
        /// Carga todos los campos del formulario en la variable
        /// </summary>
        private void LoadFiels()
        {
            string pcc = txtPCC.Text;
            string osi = string.Empty;
            string text = string.Empty;
            string typeLine = string.Empty;
            string remarks = string.Empty;
            string sabreFormats = string.Empty;
            string typeRemark = string.Empty;
            string alternativeEmail = string.Empty;
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


                    text = txt.Text;
                    if (cmb.SelectedItem != null)
                        typeLine = cmb.SelectedItem.ToString();
                    else
                        typeLine = string.Empty;
                    sabreFormats += string.Concat(text, ",", typeLine, "#");
                    count += 1;
                }
            }
             
            if (string.IsNullOrEmpty(pcc))
                pcc = Login.PCC;

            string historic=string.Empty;

            if (Parameters[3] == "Update" || Parameters[3] == "NewUpdate")
            historic=GetHistoricData();

            s1Details = new Star1Details
                            {
                                ProfileName = txtDK.Text,
                                Pcc = txtPCC.Text,
                                CustomerDk = txtDK.Text,
                                CompanyName = txtEnterpriseName.Text,
                                Phone = txtPhone.Text,
                                Ext = txtExt.Text,
                                TravelPolicies = ucMultilineSmartTextBox1.Text,
                                SocialReason = txtSocialReason.Text,
                                Street = txtStreet.Text,
                                OutsideNumber = txtNumberExt.Text,
                                InternalNumber = txtNumberInt.Text,
                                Colony = txtColony.Text,
                                Municipality = txtDelorMunicipality.Text,
                                PostalCode = txtPostalCode.Text,
                                City = txtCity.Text,
                                State = txtState.Text,
                                Rfc = txtRFC1.Text + "/" + txtRFC2.Text + "/" + txtRFC3.Text,
                                //CreditCard = txtCreditCardCode.Text + "*" + txtCreditCardNumber.Text,
                                CreditCard = ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode.Text + "*" + ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC.Password,
                                //ExpirationDate = txtExpirationDateMonth.Text + "/" + txtExpirationDateYear.Text,
                                ExpirationDate = ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM.Password + "/" + ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY.Password,
                                TypeOfService1 = ((((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).chkAir.IsChecked == true) ? "Y" : "N") + "*" + ((((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).chkCar.IsChecked == true) ? "Y" : "N") +
                 "*" + ((((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).chkHtl.IsChecked == true) ? "Y" : "N") + "*" + (((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).txtSpecificUse.Text),
                                ContactCompany = txtEnterpriseContact.Text,
                                Email = txtEmailContact.Text,
                                Comments = ucMultilineSmartTextBox2.Text,
                                CreatedBy = txtCreateBy.Text,
                                Password = txtPassword.Text,
                                Id = profileId.ToString(),
                                Osi = osi,
                                Remarks = remarks,
                                AlternativeEmail = alternativeEmail,
                                Historic = historic,
                                SabreFormats = sabreFormats,
                                //CreditCard2 = txtCreditCardCode2.Text + "*" + txtCreditCardNumber2.Text,
                                CreditCard2 = ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode2.Text + "*" + ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC2.Password,
                                //ExpirationDate2 = txtExpirationDateMonth2.Text + "/" + txtExpirationDateYear2.Text,
                                ExpirationDate2 = ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM2.Password + "/" + ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY2.Password,
                                TypeOfService2 = ((((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).chkAir2.IsChecked == true) ? "Y" : "N") + "*" + ((((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).chkCar2.IsChecked == true) ? "Y" : "N") +
                 "*" + ((((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).chkHtl2.IsChecked == true) ? "Y" : "N") + "*" + (((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).txtSpecificUse2.Text),
                                //CreditCard3 = txtCreditCardCode3.Text + "*" + txtCreditCardNumber3.Text,
                                CreditCard3 = ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode3.Text + "*" + ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC3.Password,
                                //ExpirationDate3 = txtExpirationDateMonth3.Text + "/" + txtExpirationDateYear3.Text,
                                ExpirationDate3 = ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM3.Password + "/" + ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY3.Password,
                                TypeOfService3 = ((((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).chkAir3.IsChecked == true) ? "Y" : "N") + "*" + ((((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).chkCar3.IsChecked == true) ? "Y" : "N") +
                 "*" + ((((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).chkHtl3.IsChecked == true) ? "Y" : "N") + "*" + (((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).txtSpecificUse3.Text),
                                //CreditCard4 = txtCreditCardCode4.Text + "*" + txtCreditCardNumber4.Text,
                                CreditCard4 = ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode4.Text + "*" + ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC4.Password,
                                //ExpirationDate4 = txtExpirationDateMonth4.Text + "/" + txtExpirationDateYear4.Text,
                                ExpirationDate4 = ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM4.Password + "/" + ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY4.Password,
                                TypeOfService4 = ((((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).chkAir4.IsChecked == true) ? "Y" : "N") + "*" + ((((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).chkCar4.IsChecked == true) ? "Y" : "N") +
                 "*" + ((((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).chkHtl4.IsChecked == true) ? "Y" : "N") + "*" + (((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).txtSpecificUse4.Text),
                                //CreditCard5 = txtCreditCardCode5.Text + "*" + txtCreditCardNumber5.Text,
                                CreditCard5 = ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode5.Text + "*" + ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC5.Password,
                                //ExpirationDate5 = txtExpirationDateMonth5.Text + "/" + txtExpirationDateYear5.Text,
                                ExpirationDate5 = ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM5.Password + "/" + ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY5.Password,
                                TypeOfService5 = ((((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).chkAir5.IsChecked == true) ? "Y" : "N") + "*" + ((((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).chkCar5.IsChecked == true) ? "Y" : "N") +
                 "*" + ((((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).chkHtl5.IsChecked == true) ? "Y" : "N") + "*" + (((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).txtSpecificUse5.Text),
                                SyncStatus = (chkSync.Checked) ? "1" : "0"
                            };
               
            SetDynamicProperties("ProfileName",txtDK.Text ) ;
            SetDynamicProperties("Pcc" , txtPCC.Text);
            SetDynamicProperties("CustomerDk" , txtDK.Text);
            SetDynamicProperties("CompanyName" , txtEnterpriseName.Text);
            SetDynamicProperties("Telephone", txtPhone.Text);
            SetDynamicProperties("Ext", txtExt.Text);
            SetDynamicProperties("TravelPolicies" , ucMultilineSmartTextBox1.Text);
            SetDynamicProperties("SocialReason" , txtSocialReason.Text);
            SetDynamicProperties("Street" , txtStreet.Text);
            SetDynamicProperties("OutsideNumber" , txtNumberExt.Text);
            SetDynamicProperties("InternalNumber" , txtNumberInt.Text);
            SetDynamicProperties("Colony" , txtColony.Text);
            SetDynamicProperties("Municipality" , txtDelorMunicipality.Text);
            SetDynamicProperties("PostalCode" , txtPostalCode.Text);
            SetDynamicProperties("City" , txtCity.Text);
            SetDynamicProperties("State" , txtState.Text);
            SetDynamicProperties("Rfc" , txtRFC1.Text + "/" + txtRFC2.Text + "/" + txtRFC3.Text);
            //SetDynamicProperties("CreditCard" , txtCreditCardCode.Text + "*" + txtCreditCardNumber.Text);
            SetDynamicProperties("CreditCard", ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode.Text + "*" + ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC.Password);
            SetDynamicProperties("TypeOfService1", ((((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).chkAir.IsChecked == true) ? "Y" : "N") + "*" + ((((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).chkCar.IsChecked == true) ? "Y" : "N") +
                 "*" + ((((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).chkHtl.IsChecked == true) ? "Y" : "N") + "*" + (((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).txtSpecificUse.Text));
            SetDynamicProperties("CVV1", Common.toEncrypt(!string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).Code.Password) ? ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).Code.Password : " "));
            SetDynamicProperties("ExpirationDate", ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM.Password + "/" + ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY.Password);
            SetDynamicProperties("ContactCompany" , txtEnterpriseContact.Text);
            SetDynamicProperties("Email" , txtEmailContact.Text);
            SetDynamicProperties("Comments" , ucMultilineSmartTextBox2.Text);
            SetDynamicProperties("CreatedBy" , txtCreateBy.Text);
            SetDynamicProperties("Password" , txtPassword.Text);
            SetDynamicProperties("Date", DateTime.Now.ToShortDateString());
            SetDynamicProperties("Purgued", "0");
            SetDynamicProperties("Osi", osi);
            SetDynamicProperties("Remarks", remarks);
            SetDynamicProperties("AlternativeEmail", alternativeEmail);
            SetDynamicProperties("SabreFormats", sabreFormats);
            SetDynamicProperties("Historic",historic);
            //SetDynamicProperties("CreditCard2",txtCreditCardCode2.Text + "*" + txtCreditCardNumber2.Text);
            SetDynamicProperties("CreditCard2", ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode2.Text + "*" + ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC2.Password);
            SetDynamicProperties("TypeOfService2", ((((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).chkAir2.IsChecked == true) ? "Y" : "N") + "*" + ((((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).chkCar2.IsChecked == true) ? "Y" : "N") +
                 "*" + ((((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).chkHtl2.IsChecked == true) ? "Y" : "N") + "*" + (((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).txtSpecificUse2.Text));
            //SetDynamicProperties("CVV2", Common.toEncrypt(!string.IsNullOrEmpty(smartTextBox2.Text) ? smartTextBox2.Text : " "));
            SetDynamicProperties("CVV2", Common.toEncrypt(!string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).Code2.Password) ? ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).Code2.Password : " "));
            //SetDynamicProperties("ExpirationDate2", txtExpirationDateMonth2.Text + "/" + txtExpirationDateYear2.Text);
            SetDynamicProperties("ExpirationDate2", ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM2.Password + "/" + ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY2.Password);
            //SetDynamicProperties("CreditCard3", txtCreditCardCode3.Text + "*" + txtCreditCardNumber3.Text);
            SetDynamicProperties("CreditCard3", ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode3.Text + "*" + ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC3.Password);
            SetDynamicProperties("TypeOfService3", ((((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).chkAir3.IsChecked == true) ? "Y" : "N") + "*" + ((((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).chkCar3.IsChecked == true) ? "Y" : "N") +
                 "*" + ((((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).chkHtl3.IsChecked == true) ? "Y" : "N") + "*" + (((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).txtSpecificUse3.Text));
            //SetDynamicProperties("CVV3", Common.toEncrypt(!string.IsNullOrEmpty(smartTextBox3.Text) ? smartTextBox3.Text : " "));
            SetDynamicProperties("CVV3", Common.toEncrypt(!string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).Code3.Password) ? ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).Code3.Password : " "));
            //SetDynamicProperties("ExpirationDate3", txtExpirationDateMonth3.Text + "/" + txtExpirationDateYear3.Text);
            SetDynamicProperties("ExpirationDate3", ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM3.Password + "/" + ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY3.Password);
            //SetDynamicProperties("CreditCard4", txtCreditCardCode4.Text + "*" + txtCreditCardNumber4.Text);
            SetDynamicProperties("CreditCard4", ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode4.Text + "*" + ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC4.Password);
            SetDynamicProperties("TypeOfService4", ((((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).chkAir4.IsChecked == true) ? "Y" : "N") + "*" + ((((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).chkCar4.IsChecked == true) ? "Y" : "N") +
                 "*" + ((((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).chkHtl4.IsChecked == true) ? "Y" : "N") + "*" + (((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).txtSpecificUse4.Text));
            SetDynamicProperties("CVV4", Common.toEncrypt(!string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).Code4.Password) ? ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).Code4.Password : " "));
            //SetDynamicProperties("ExpirationDate4", txtExpirationDateMonth4.Text + "/" + txtExpirationDateYear4.Text);
            SetDynamicProperties("ExpirationDate4", ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM4.Password + "/" + ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY4.Password);
            //SetDynamicProperties("CreditCard5", txtCreditCardCode5.Text + "*" + txtCreditCardNumber5.Text);
            SetDynamicProperties("CreditCard5", ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode5.Text + "*" + ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC5.Password);
            SetDynamicProperties("TypeOfService5", ((((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).chkAir5.IsChecked == true) ? "Y" : "N") + "*" + ((((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).chkCar5.IsChecked == true) ? "Y" : "N") +
                 "*" + ((((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).chkHtl5.IsChecked == true) ? "Y" : "N") + "*" + (((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).txtSpecificUse5.Text));
            SetDynamicProperties("CVV5", Common.toEncrypt(!string.IsNullOrEmpty(((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).Code5.Password) ? ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).Code5.Password : " "));
            //SetDynamicProperties("ExpirationDate5", txtExpirationDateMonth5.Text + "/" + txtExpirationDateYear5.Text);
            SetDynamicProperties("ExpirationDate5", ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM5.Password + "/" + ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY5.Password);
            SetDynamicProperties("SyncStatus", (chkSync.Checked) ? "1" : "0");
            //SetDynamicsControlsValues();
        }

        /// <summary>
        /// Busca si existe el DK
        /// </summary>
        /// 
        private Boolean ExistLocationInformation()
        {

            string location = txtDK.Text;
            WsMyCTS wsServ = new WsMyCTS();
            MyCTS.Services.ValidateDKsAndCreditCards.GetAttribute1 star1InfoByLocation = null;
            MyCTS.Services.ValidateDKsAndCreditCards.GetAttribute1 star1InfoByLocation1 = null;

            try
            {
                star1InfoByLocation = wsServ.GetAttribute(location, Login.OrgId);
                return true;
            }
            catch
            {
                star1InfoByLocation1 = wsServ.GetAttribute(location, Login.OrgId);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Carga informacion a la mascarilla por Location
        /// </summary>
        private Boolean ExistAndLoadLocationInformation()
        {

            string location = txtDK.Text;
            //string location = txtDK.Text;
            WsMyCTS wsServ = new WsMyCTS();
            MyCTS.Services.ValidateDKsAndCreditCards.Cat1stStarInfoByLocation star1InfoByLocation = null;
            MyCTS.Services.ValidateDKsAndCreditCards.Cat1stStarInfoByLocation star1InfoByLocation1 = null;
            try
            {
                star1InfoByLocation = wsServ.GetProfileInfo(location);
            }
            catch
            {
                star1InfoByLocation1 = wsServ.GetProfileInfo(location);
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
                    if (string.IsNullOrEmpty(txtPhone.Text))
                    {
                        string phone = star1InfoByLocation.MainPhone.Replace('(', ' ');
                        phone = phone.Replace(')', ' ');
                        phone = phone.TrimEnd();
                        phone = phone.TrimStart();
                        txtPhone.Text = phone;
                        txtPhone.Enabled = true;
                    }
                    else
                    {
                        txtPhone.Enabled = true;
                    }

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
                }
                else
                    txtNumberInt.Enabled = true;

                if (string.IsNullOrEmpty(txtColony.Text))
                {
                    if (!string.IsNullOrEmpty(star1InfoByLocation.Address4))
                        txtColony.Text = star1InfoByLocation.Address4;

                    if (star1InfoByLocation.Address4 == "")
                        txtColony.Enabled = true;
                    else
                        txtColony.Enabled = false;
                }
                else
                    txtColony.Enabled = false;

                if (string.IsNullOrEmpty(txtDelorMunicipality.Text))
                {
                    if (!string.IsNullOrEmpty(star1InfoByLocation.Municipality))
                    {
                        txtDelorMunicipality.Text = star1InfoByLocation.Municipality;
                        if (!string.IsNullOrEmpty(txtDelorMunicipality.Text))
                        txtDelorMunicipality.Enabled = false;
                    }
                    else
                        txtDelorMunicipality.Enabled = true;
                }
                else
                    txtDelorMunicipality.Enabled = false;

                if (!string.IsNullOrEmpty(star1InfoByLocation.PostalCode))
                {
                    txtPostalCode.Text = star1InfoByLocation.PostalCode;
                    txtPostalCode.Enabled = false;
                }
                else
                    txtPostalCode.Enabled = true;

                if (string.IsNullOrEmpty(txtCity.Text))
                {
                    if (!string.IsNullOrEmpty(star1InfoByLocation.City))
                    {
                        txtCity.Text = star1InfoByLocation.City;
                        if (!string.IsNullOrEmpty(txtCity.Text))
                        txtCity.Enabled = false;
                    }
                    else
                        txtCity.Enabled = true;
                }
                else
                    txtCity.Enabled = false;

                if (string.IsNullOrEmpty(txtState.Text))
                {
                    if (!string.IsNullOrEmpty(star1InfoByLocation.State))
                    {
                        txtState.Text = star1InfoByLocation.State;
                        if (!string.IsNullOrEmpty(txtCity.Text))
                        txtState.Enabled = false;
                    }
                    else
                        txtState.Enabled = true;
                }
                else
                    txtState.Enabled = false;

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
                    else
                    {
                        txtRFC1.Enabled = true;
                        txtRFC2.Enabled = true;
                        txtRFC3.Enabled = true;
                    }
                }
                else
                {
                    txtRFC1.Enabled = true;
                    txtRFC2.Enabled = true;
                    txtRFC3.Enabled = true;
 
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
                    if (string.IsNullOrEmpty(txtPhone.Text))
                    {
                        string phone = star1InfoByLocation1.MainPhone.Replace('(', ' ');
                        phone = phone.Replace(')', ' ');
                        phone = phone.TrimEnd();
                        phone = phone.TrimStart();
                        txtPhone.Text = phone;
                        txtPhone.Enabled = true;
                        
                    }
                    else
                    {
                        txtPhone.Enabled = true;
                    }
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


                if (string.IsNullOrEmpty(txtDelorMunicipality.Text))
                {
                    if (!string.IsNullOrEmpty(star1InfoByLocation1.Municipality))
                    {
                        txtDelorMunicipality.Text = star1InfoByLocation1.Municipality;
                        if (!string.IsNullOrEmpty(txtDelorMunicipality.Text))
                            txtDelorMunicipality.Enabled = false;
                    }
                    else
                        txtDelorMunicipality.Enabled = true;
                }
                else
                    txtDelorMunicipality.Enabled = false;

                if (!string.IsNullOrEmpty(star1InfoByLocation1.PostalCode))
                    txtPostalCode.Text = star1InfoByLocation1.PostalCode;

                if (string.IsNullOrEmpty(txtCity.Text))
                {
                    if (!string.IsNullOrEmpty(star1InfoByLocation1.City))
                    {
                        txtCity.Text = star1InfoByLocation1.City;
                        if (!string.IsNullOrEmpty(txtCity.Text))
                            txtCity.Enabled = false;
                    }
                    else
                        txtCity.Enabled = true;
                }
                else
                    txtCity.Enabled = false;

                if (string.IsNullOrEmpty(txtState.Text))
                {
                    if (!string.IsNullOrEmpty(star1InfoByLocation1.State))
                    {
                        txtState.Text = star1InfoByLocation1.State;
                        if (!string.IsNullOrEmpty(txtCity.Text))
                            txtState.Enabled = false;
                    }
                    else
                        txtState.Enabled = true;
                }
                else
                    txtState.Enabled = false;
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
                MessageBox.Show("El DK ingresado no existe, Contactar a Cuentas por Cobrar", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

        }


        /// <summary>
        /// Carga informacion a la mascarilla por Location si falla el metodo principal
        /// </summary>
        private Boolean ExistLoadLocationInfoBackup()
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
                    if (string.IsNullOrEmpty(txtPhone.Text))
                    {
                        string phone = starFirstInfoByLocation.MainPhone.Replace('(', ' ');
                        phone = phone.Replace(')', ' ');
                        phone = phone.TrimEnd();
                        phone = phone.TrimStart();
                        txtPhone.Text = phone;
                        txtPhone.Enabled = true;
                    }
                    else
                    {
                        txtPhone.Enabled = true;
                    }
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

                if (string.IsNullOrEmpty(txtDelorMunicipality.Text))
                {
                    if (!string.IsNullOrEmpty(starFirstInfoByLocation.Municipality))
                    {
                        txtDelorMunicipality.Text = starFirstInfoByLocation.Municipality;
                        if (!string.IsNullOrEmpty(txtDelorMunicipality.Text))
                            txtDelorMunicipality.Enabled = false;
                    }
                    else
                        txtDelorMunicipality.Enabled = true;
                }
                else
                    txtDelorMunicipality.Enabled = false;

                if (!string.IsNullOrEmpty(starFirstInfoByLocation.PostalCode))
                    txtPostalCode.Text = starFirstInfoByLocation.PostalCode;

                if (string.IsNullOrEmpty(txtCity.Text))
                {
                    if (!string.IsNullOrEmpty(starFirstInfoByLocation.City))
                    {
                        txtCity.Text = starFirstInfoByLocation.City;
                        if (!string.IsNullOrEmpty(txtCity.Text))
                            txtCity.Enabled = false;
                    }
                    else
                        txtCity.Enabled = true;
                }
                else
                    txtCity.Enabled = false;

                if (string.IsNullOrEmpty(txtState.Text))
                {
                    if (!string.IsNullOrEmpty(starFirstInfoByLocation.State))
                    {
                        txtState.Text = starFirstInfoByLocation.State;
                        if (!string.IsNullOrEmpty(txtCity.Text))
                            txtState.Enabled = false;
                    }
                    else
                        txtState.Enabled = true;
                }
                else
                    txtState.Enabled = false;

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
                MessageBox.Show(@"El DK ingresado no existe, Contactar a Cuentas por Cobrar", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        foreach (Control txt in this.pnlRemarks.TabPages)
                        {
                            foreach (Control txt2 in txt.Controls)
                            {
                                if (txt2.TabIndex.Equals(((SmartTextBox) (sender)).TabIndex + 1))
                                {
                                    txt2.Focus();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void txtControlCreditCard_TextChanged(object sender, EventArgs e)
        {
            if (!InitialFocus)
            {
                if (sender is SmartTextBox)
                {
                    //SetSmartTextBoxSecurityFormat((SmartTextBox)sender);
                    if (((SmartTextBox)sender).Text.Length > ((SmartTextBox)sender).MaxLength - 1)
                    {
                        foreach (Control txt in this.pnlRemarks.TabPages)
                        {
                            foreach (Control txt2 in txt.Controls)
                            {
                                if (txt2.TabIndex.Equals(((SmartTextBox)(sender)).TabIndex + 1))
                                {
                                    txt2.Focus();
                                }
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
                if(Parameters == null)
                    Parameters = new string[4];
                try
                {
                    ExistAndLoadLocationInformation();
                    if (!ExistDkInProfiles(txtDK.Text, Parameters[3]))
                    {
                        if (Parameters[3]==null)
                            txtProfileName.Text = txtDK.Text;
                    }
                }
                catch
                {
                    
                    ExistLoadLocationInfoBackup();
                    bool existDK = ExistDkInProfiles(txtDK.Text, Parameters[3]);
                    //if (existDK)
                    //{

                    //}
                }

            }
            if (txtDK.Text == @"INSTOP")
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

        private void ucFirstLevelProfiles_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            frmPreloading fr = new frmPreloading(this);
            fr.Show();

            s1Details = frmUpdateProfiles.ObjStar1Dfup;

            frmUpdateProfiles.ObjStar1Dfup = null;
            string[] sd;
            txtProfileName.Enabled = false;
            txtCreateBy.Text = Login.NombreCompleto;
            txtCreateBy.Enabled = false;

            if (s1Details != null)
            {
                //loadExtraFields("","");
                if (Parameters[3] == "Update")
                    SetLogNewFormatProfilesBL.SetLogNewFormatProfiles(s1Details.Pcc, Login.NombreCompleto, txtDK.Text, null, DateTime.Now);

                List<GetLogNewFormatProfiles> logList = GetLogNewFormatProfilesBL.GetLogNewFormatProfiles(s1Details.Pcc, s1Details.ProfileName, "", 1);
                if (logList.Count > 0)
                {
                    foreach (GetLogNewFormatProfiles item in logList)
                    {
                        var itemLog = new ListViewItem(item.UserName);
                        itemLog.SubItems.Add(item.ModifiedDate.ToString());
                        listView1.Items.Add(itemLog);
                    }
                }
                txtPCC.Text = Login.PCC;
                InitialFocus = false;
                txtProfileName.Focus();
                txtProfileName.Text = s1Details.ProfileName;
                txtPCC.Text = s1Details.Pcc;
                txtEnterpriseName.Text = s1Details.CompanyName;
                txtPhone.Text = s1Details.Phone;
                txtExt.Text = s1Details.Ext;
                if (s1Details.TravelPolicies != null)
                    ucMultilineSmartTextBox1.Text = s1Details.TravelPolicies;
                txtSocialReason.Text = s1Details.SocialReason;
                txtStreet.Text = s1Details.Street;
                txtNumberExt.Text = s1Details.OutsideNumber;
                txtNumberInt.Text = s1Details.InternalNumber;
                txtColony.Text = s1Details.Colony;
                txtDelorMunicipality.Text = s1Details.Municipality;
                txtPostalCode.Text = s1Details.PostalCode;
                txtCity.Text = s1Details.City;
                txtState.Text = s1Details.State;

                if (s1Details.Rfc != null)
                {
                    sd = s1Details.Rfc.Split(new String[] { "/" }, 5, StringSplitOptions.RemoveEmptyEntries);
                    if (sd.Length > 0)
                        txtRFC1.Text = sd[0];
                    if (sd.Length > 1)
                        txtRFC2.Text = sd[1];
                    if (sd.Length > 2)
                        txtRFC3.Text = sd[2];
                }
                //Credit Cards
                //if (s1Details.CreditCard != null)
                //{

                //    sd = s1Details.CreditCard.Split(new String[] { "*" }, 5, StringSplitOptions.RemoveEmptyEntries);
                //    if (sd.Length > 0)
                //        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode.Text = sd[0];
                //    if (sd.Length > 1)
                //        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC.Password = sd[1];
                //}

                //if (s1Details.ExpirationDate != null)
                //{
                //    sd = s1Details.ExpirationDate.Split(new String[] { "/" }, 5, StringSplitOptions.RemoveEmptyEntries);
                //    if (sd.Length > 0)
                //        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM.Password = sd[0];
                //    if (sd.Length > 1)
                //        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY.Password = sd[1];
                //}

                //try
                //{
                //    if (s1Details.CreditCard2 != null)
                //    {
                //        sd = s1Details.CreditCard2.Split(new String[] { "*" }, 5, StringSplitOptions.RemoveEmptyEntries);
                //        if (sd.Length > 0)
                //            ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode2.Text = sd[0];
                //        if (sd.Length > 1)
                //            ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC2.Password = sd[1];
                //    }

                //    if (s1Details.ExpirationDate2 != null)
                //    {
                //        sd = s1Details.ExpirationDate2.Split(new String[] { "/" }, 5, StringSplitOptions.RemoveEmptyEntries);
                //        if (sd.Length > 0)
                //            ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM2.Password = sd[0];
                //        if (sd.Length > 1)
                //            ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY2.Password = sd[1];
                //    }
                //}
                //catch{}

                //try
                //{
                //    if (s1Details.CreditCard3 != null)
                //    {
                //        sd = s1Details.CreditCard3.Split(new String[] { "*" }, 5, StringSplitOptions.RemoveEmptyEntries);
                //        if (sd.Length > 0)
                //            ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode3.Text = sd[0];
                //        if (sd.Length > 1)
                //            ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC3.Password = sd[1];
                //    }

                //    if (s1Details.ExpirationDate3 != null)
                //    {
                //        sd = s1Details.ExpirationDate3.Split(new String[] { "/" }, 5, StringSplitOptions.RemoveEmptyEntries);
                //        if (sd.Length > 0)
                //            ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM3.Password = sd[0];
                //        if (sd.Length > 1)
                //            ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY3.Password = sd[1];
                //    }
                //}
                //catch { }

                //try
                //{
                //    if (s1Details.CreditCard4 != null)
                //    {
                //        sd = s1Details.CreditCard4.Split(new String[] { "*" }, 5, StringSplitOptions.RemoveEmptyEntries);
                //        if (sd.Length > 0)
                //            ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode4.Text = sd[0];
                //        if (sd.Length > 1)
                //            ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC4.Password = sd[1];
                //    }


                //    if (s1Details.ExpirationDate4 != null)
                //    {
                //        sd = s1Details.ExpirationDate4.Split(new String[] { "/" }, 5, StringSplitOptions.RemoveEmptyEntries);
                //        if (sd.Length > 0)
                //            ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM4.Password = sd[0];
                //        if (sd.Length > 1)
                //            ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY4.Password = sd[1];
                //    }
                //}
                //catch { }

                //try
                //{
                //    if (s1Details.CreditCard5 != null)
                //    {
                //        sd = s1Details.CreditCard5.Split(new String[] { "*" }, 5, StringSplitOptions.RemoveEmptyEntries);
                //        if (sd.Length > 0)
                //            ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode5.Text = sd[0];
                //        if (sd.Length > 1)
                //            ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC5.Password = sd[1];
                //    }

                //    if (s1Details.ExpirationDate5 != null)
                //    {
                //        sd = s1Details.ExpirationDate5.Split(new String[] { "/" }, 5, StringSplitOptions.RemoveEmptyEntries);
                //        if (sd.Length > 0)
                //            ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM5.Password = sd[0];
                //        if (sd.Length > 1)
                //            ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY5.Password = sd[1];
                //    }
                //}
                //catch { }

                txtEnterpriseContact.Text = s1Details.ContactCompany;
                txtEmailContact.Text = s1Details.Email;
                if (s1Details.Comments != null)
                    ucMultilineSmartTextBox2.Text = s1Details.Comments;
                txtCreateBy.Text = Login.NombreCompleto;
                txtCreateBy.Enabled = false;
                txtPassword.Text = s1Details.Password;
                txtDK.Text = s1Details.CustomerDk;
            }
            else
            {
                try
                {
                    if (Parameters != null)
                        loadExtraFields(Parameters[0], Parameters[1]);
                    else
                        loadExtraFields("", "");

                    txtPCC.Text = Login.PCC;
                    InitialFocus = false;
                    txtProfileName.Focus();

                    if (GetDynamicProperties("Id", listFields) == "0")// El perfil con Id 0 tendra valores nulos y se utiliza para obtener los campos
                        profileId = null;
                    else
                        profileId = int.Parse(GetDynamicProperties("Id", listFields));
                    txtProfileName.Text = GetDynamicProperties("ProfileName", listFields);
                    txtPCC.Text = GetDynamicProperties("Pcc", listFields);
                    txtEnterpriseName.Text = GetDynamicProperties("CompanyName", listFields);
                    txtPhone.Text = GetDynamicProperties("Telephone", listFields);
                    txtExt.Text = GetDynamicProperties("Ext", listFields);
                    ucMultilineSmartTextBox1.Text = GetDynamicProperties("TravelPolicies", listFields);
                    txtSocialReason.Text = GetDynamicProperties("SocialReason", listFields);
                    txtStreet.Text = GetDynamicProperties("Street", listFields);
                    txtNumberExt.Text = GetDynamicProperties("OutsideNumber", listFields);
                    txtNumberInt.Text = GetDynamicProperties("InternalNumber", listFields);
                    txtColony.Text = GetDynamicProperties("Colony", listFields);
                    txtDelorMunicipality.Text = GetDynamicProperties("Municipality", listFields);
                    txtPostalCode.Text = GetDynamicProperties("PostalCode", listFields);
                    txtCity.Text = GetDynamicProperties("City", listFields);
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
                
                //Codigo nuevo
                try
                {
                    chkSync.Checked = (int.Parse(GetDynamicProperties("SyncStatus", listFields)) == 0) ? false : true;

                }
                    catch(Exception ex)
                {
                        ex.ToString();
                }
                //codigo nuevo
                if (!string.IsNullOrEmpty(txtCity.Text))
                {
                    txtCity.Enabled = false;
                }
                txtState.Text = GetDynamicProperties("State", listFields);
                if (!string.IsNullOrEmpty(txtState.Text))
                {
                    txtCity.Enabled = false;
                }
                if (GetDynamicProperties("RFC", listFields) != null)
                {
                    sd = GetDynamicProperties("RFC", listFields).Split(new String[] { "/" }, 5,
                                                                       StringSplitOptions.RemoveEmptyEntries);
                    if (sd.Length > 0)
                        txtRFC1.Text = sd[0];
                    if (sd.Length > 1)
                        txtRFC2.Text = sd[1];
                    if (sd.Length > 2)
                        txtRFC3.Text = sd[2];
                }

                try
                {
                    this.elmtHostCCFirstLevel.Child = new UsrCtrlCCardsFirstLevel(listFields);
                    //if (GetDynamicProperties("CreditCard", listFields) != null)
                    //{
                    //    // Aqui desencriptamos la cadena ya que son los datos que trae de la consulta
                    //    sd = GetDynamicProperties("CreditCard", listFields).Split(new String[] { "*" }, 5,
                    //                                                              StringSplitOptions.RemoveEmptyEntries);
                    //    // Aqui ya modificamos la tarjeta para que se muestre con X entre los 
                    //    if (sd.Length > 0)
                    //        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode.Text = sd[0];
                    //    if (sd.Length > 1)
                    //        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC.Password = sd[1];
                    //    var c = new string(Common.toDecrypt(GetDynamicProperties("CVV1", listFields)).Where(char.IsDigit).ToArray());
                    //    ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).Code.Password = (!string.IsNullOrEmpty(c)) ? c : string.Empty;
                    //}


                    //if (GetDynamicProperties("ExpirationDate", listFields) != null)
                    //{
                    //    // Aqui desencriptamos la cadena ya que son los datos que trae de la consulta
                    //    sd = GetDynamicProperties("ExpirationDate", listFields).Split(new String[] { "/" }, 5,
                    //                                                                  StringSplitOptions.RemoveEmptyEntries);
                    //    if (sd.Length > 0)
                    //        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM.Password = sd[0];
                    //    if (sd.Length > 1)
                    //        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY.Password = sd[1];
                    //}
                }
                catch { }

                try
                {
                    //if (GetDynamicProperties("CreditCard2", listFields) != null)
                    //{
                    //    sd = GetDynamicProperties("CreditCard2", listFields).Split(new String[] { "*" }, 5,
                    //                                                              StringSplitOptions.RemoveEmptyEntries);
                    //    if (sd.Length > 0)
                    //        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode2.Text = sd[0];
                    //    if (sd.Length > 1)
                    //        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC2.Password = sd[1];
                    //    var c = new string(Common.toDecrypt(GetDynamicProperties("CVV2", listFields)).Where(char.IsDigit).ToArray());
                    //    ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).Code2.Password = (!string.IsNullOrEmpty(c)) ? c : string.Empty;
                    //}


                    //if (GetDynamicProperties("ExpirationDate2", listFields) != null)
                    //{
                    //    sd = GetDynamicProperties("ExpirationDate2", listFields).Split(new String[] { "/" }, 5,
                    //                                                                  StringSplitOptions.RemoveEmptyEntries);
                    //    if (sd.Length > 0)
                    //        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM2.Password = sd[0];
                    //    if (sd.Length > 1)
                    //        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY2.Password = sd[1];
                    //}
                }
                catch { }

                try
                {
                    //if (GetDynamicProperties("CreditCard3", listFields) != null)
                    //{
                    //    sd = GetDynamicProperties("CreditCard3", listFields).Split(new String[] { "*" }, 5,
                    //                                                              StringSplitOptions.RemoveEmptyEntries);
                    //    if (sd.Length > 0)
                    //        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode3.Text = sd[0];
                    //    if (sd.Length > 1)
                    //        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC3.Password = sd[1];
                    //    var c = new string(Common.toDecrypt(GetDynamicProperties("CVV3", listFields)).Where(char.IsDigit).ToArray());
                    //    ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).Code3.Password = (!string.IsNullOrEmpty(c)) ? c : string.Empty;
                    //}


                    //if (GetDynamicProperties("ExpirationDate3", listFields) != null)
                    //{
                    //    sd = GetDynamicProperties("ExpirationDate3", listFields).Split(new String[] { "/" }, 5,
                    //                                                                  StringSplitOptions.RemoveEmptyEntries);
                    //    if (sd.Length > 0)
                    //        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM3.Password = sd[0];
                    //    if (sd.Length > 1)
                    //        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY3.Password = sd[1];
                    //}
                }
                catch { }

                try
                {
                    //if (GetDynamicProperties("CreditCard4", listFields) != null)
                    //{
                    //    sd = GetDynamicProperties("CreditCard4", listFields).Split(new String[] { "*" }, 5,
                    //                                                              StringSplitOptions.RemoveEmptyEntries);
                    //    if (sd.Length > 0)
                    //        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode4.Text = sd[0];
                    //    if (sd.Length > 1)
                    //        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC4.Password = sd[1];
                    //}


                    //if (GetDynamicProperties("ExpirationDate4", listFields) != null)
                    //{
                    //    sd = GetDynamicProperties("ExpirationDate4", listFields).Split(new String[] { "/" }, 5,
                    //                                                                  StringSplitOptions.RemoveEmptyEntries);
                    //    if (sd.Length > 0)
                    //        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM4.Password = sd[0];
                    //    if (sd.Length > 1)
                    //        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY4.Password = sd[1];
                    //}
                }
                catch { }

                try
                {
                    //if (GetDynamicProperties("CreditCard5", listFields) != null)
                    //{
                    //    sd = GetDynamicProperties("CreditCard5", listFields).Split(new String[] { "*" }, 5,
                    //                                                              StringSplitOptions.RemoveEmptyEntries);
                    //    if (sd.Length > 0)
                    //        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CCCode5.Text = sd[0];
                    //    if (sd.Length > 1)
                    //        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).CC5.Password = sd[1];
                    //}


                    //if (GetDynamicProperties("ExpirationDate5", listFields) != null)
                    //{
                    //    sd = GetDynamicProperties("ExpirationDate5", listFields).Split(new String[] { "/" }, 5,
                    //                                                                  StringSplitOptions.RemoveEmptyEntries);
                    //    if (sd.Length > 0)
                    //        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).MM5.Password = sd[0];
                    //    if (sd.Length > 1)
                    //        ((UsrCtrlCCardsFirstLevel)elmtHostCCFirstLevel.Child).YY5.Password = sd[1];
                    //}
                }
                catch { }
                if (profileId != null)
                    LoadDocuments(profileId.ToString());

                txtEnterpriseContact.Text = GetDynamicProperties("ContactCompany", listFields);
                txtEmailContact.Text = GetDynamicProperties("Email", listFields);
                ucMultilineSmartTextBox2.Text = GetDynamicProperties("Comments", listFields);
                //txtCreateBy.Text = GetDynamicProperties("CreatedBy", listFields);
                txtCreateBy.Enabled = false;
                txtPassword.Text = GetDynamicProperties("Password", listFields);
                txtDK.Text = GetDynamicProperties("CustomerDK", listFields);

                List<GetLogNewFormatProfiles> logList = GetLogNewFormatProfilesBL.GetLogNewFormatProfiles(GetDynamicProperties("Pcc", listFields), GetDynamicProperties("ProfileName", listFields), "", 1);
                if (logList.Count > 0)
                {
                    foreach (GetLogNewFormatProfiles item in logList)
                    {
                        var itemLog = new ListViewItem(item.UserName);
                        itemLog.SubItems.Add(item.ModifiedDate.ToString());
                        listView1.Items.Add(itemLog);
                    }
                }

                string osi = GetDynamicProperties("Osi", listFields);
                string remarks = GetDynamicProperties("Remarks", listFields);
                string alternativeEmail = GetDynamicProperties("AlternativeEmail", listFields);
                string historic = GetDynamicProperties("Historic", listFields);
                string sabreFormats = GetDynamicProperties("SabreFormats", listFields);
                int count = 0;
                int lastCtrlLocation = 60;

                string[] txtAndLineType;
                int index = 0;

                string[] lines = osi.Split('#');
                int numRows = lines.Length - 1;

                Panel pnl1Osi = (Panel)ucMultiLineSmartTextOSI.Controls.Find("panel1", false)[0];
                Button btn = (Button)ucMultiLineSmartTextOSI.Controls.Find("button1", false)[0];

                
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


                lines = remarks.Split('#');
                numRows = lines.Length - 1;

                Panel pnl1Remarks = (Panel)ucMultiTextRemarks1.Controls.Find("panel1", false)[0];
                btn = (Button)ucMultiTextRemarks1.Controls.Find("button1", false)[0];
                count = 0;
                index = 0;
                lastCtrlLocation = 60;

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
                            count += 1;
                            index += 1;
                        }
                        catch { }
                    }
                }


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
                count = 0;
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
                            //Panel Panel = (Panel)pnl1AlterEmail.Controls.Find("panel1", false)[0];

                            LineSmartText lineSmart = (LineSmartText)pnl1AlterEmail.Controls.Find("LineSmartText", false)[count];

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
                count = 0;
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

                if (!string.IsNullOrEmpty(Parameters[3]))
                {
                    if (Parameters[3].Equals("Update"))
                    {
                        txtDK.Enabled = false;
                        txtPCC.Enabled = false;
                        txtProfileName.Enabled = false;
                    }
                }
            }
        }
        

        private void loadExtraFields(string pcc, string level1)
        {
            try {
            //Numero de columnas de la Tabla que NO son Datos Extas
            var columns = 51;
            var fd = new FieldsDynamicsBL();
            listFields = fd.GetStar1Details(pcc, level1);
            var tableLayoutPanel1 = new TableLayoutPanel();
            int num = listFields.Count - columns;
            if (num == 0)
                return;
            float percentRows = 100 / num;

            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());

            tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = num;
            for (int r = 0; r < num; r++)
            {
                tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, percentRows + 15));
            }

            //tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.AutoSize = true;

            var propertiesList = new List<Dynamic>();
            string propName = string.Empty;

            int y = 0;
            int i = 0;

            foreach (Dynamic item in listFields)
            {

                if (i >= columns)
                {
                    var lbl = new Label();
                    lbl.Location = new System.Drawing.Point(3, 3);
                    lbl.Text = item.GetType().GetProperty(item.FieldName).Name;

                    var txt = new SmartTextBox();
                    txt.MaxLength = 60;
                    txt.CharacterCasing = CharacterCasing.Upper;
                    txt.Location = new System.Drawing.Point(141, 0);
                    txt.Text = item.GetType().GetProperty(item.FieldName).GetValue(item, null).ToString();
                    txt.Size = new System.Drawing.Size(357, 20);

                    tableLayoutPanel1.Controls.Add(lbl, 0, y);
                    tableLayoutPanel1.Controls.Add(txt, 1, y);
                    y += 1;
                }
                
                i++;
            }
            pnlExtraData.Controls.Add(tableLayoutPanel1);
        }
            catch {}
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

        private void SetDynamicProperties(string propName, String value)
        {
         item2 = new Dynamic();
         item2 = item2.Add(propName, value);
         item2.FieldName = propName;
         listFields2.Add(item2); 
        }

        private void SetDynamicsControlsValues()
        {
            foreach (TableLayoutPanel tlp in pnlExtraData.Controls.Find("tableLayoutPanel1",true))
            {
                for (int i = 0; i < tlp.RowCount; i++)
                {
                    item2 = new Dynamic();
                    item2 = item2.Add(tlp.GetControlFromPosition(0, i).Text, tlp.GetControlFromPosition(1, i).Text);
                    item2.FieldName = tlp.GetControlFromPosition(0, i).Text;
                    listFields2.Add(item2);
                }
                break;
            }
        }

        //
        private string GetHistoricData()
        {
            string lines=string.Empty;
            List<DeactivatedStar> deactivatedStarsList = GetDeactivatedStarsBL.GetDeactivatedStars(txtDK.Text);
            if (deactivatedStarsList.Count > 0)
            {
                foreach (DeactivatedStar item in deactivatedStarsList)
                {
                    if (item.Lines.Count > 2)
                    {
                        foreach (string line in item.Lines)
                        {
                            lines = string.Concat(lines, "#", line);
                        }
                    }
                }

            }
            return lines;
        }

        private void tabPage1_Click(object sender, EventArgs e)
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
                s.Read(i, 0, i.Length);

                int r = dataGridView.Rows.Add(new DataGridViewRow());

                lst.Add(new DocsFirstLevel() { ProfileId = (profileId != null) ? profileId.ToString() : string.Empty, Name = saveFileDialog.SafeFileName, Image = i, Enable = true });
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
                            if (p != row)
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
                List<DocsFirstLevel> p = lst.ToList();
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

        private void LoadDocuments(string profileId)
        {
            lst = DocsFirstLevelBL.getImageByProfileId(profileId);
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
    }
}