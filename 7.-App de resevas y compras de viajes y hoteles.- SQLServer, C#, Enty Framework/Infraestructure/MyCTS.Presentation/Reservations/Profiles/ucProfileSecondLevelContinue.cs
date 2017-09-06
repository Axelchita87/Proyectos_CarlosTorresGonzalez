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
using MyCTS.Forms.UI;

namespace MyCTS.Presentation
{
    public partial class ucProfileSecondLevelContinue : CustomUserControl
    {

        /// <summary>
        /// Descripción: User control que continua con la creacion del perfil de segundo nivel
        /// Creación:    26 febrero 2010, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>


        private string ProfileNameFirstLevel = string.Empty;
        private string ProfileNameSecondLevel = string.Empty;
        private string FamiliarLastName = string.Empty;
        private bool statusParamReceived = false;
        private string pcc = string.Empty;
        public static List<string> previousValues = new List<string>();

        public ucProfileSecondLevelContinue()
        {
            InitializeComponent();
            this.InitialControlFocus = txtStreetAndNumber;
            this.LastControlFocus = btnAccept;
        }


        //Evento Load
        private void ucProfileSecondLevelContinue_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            if (previousValues.Count > 0)
            {
                SetPreviousControlValues();
            }

            if (this.Parameters != null)
            {
                pcc = this.Parameters[0];
                ProfileNameFirstLevel = this.Parameters[1];
                ProfileNameSecondLevel = this.Parameters[2];
                FamiliarLastName = this.Parameters[3];
            }

            txtStreetAndNumber.Focus();
        }


        //Evento btnAccept_Click
        private void btnAccept_Click(object sender, EventArgs e)
        {
              DialogResult result = MessageBox.Show(string.Concat(Resources.Profiles.Constants.CREATE_PROFILE_CONFIRMATION, " ", ProfileNameSecondLevel), Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
              if (result.Equals(DialogResult.Yes))
              {
                  ContinueCreatingProfile();
                 
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
                for (int i = 0; i < 45; i++)
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
        /// Validaciones de Regla de Negocios de las opciones seleccionadas
        /// </summary>
        /// <returns></returns>
        private bool IsValidBusinessRules
        {
            get
            {
                bool isValid = true;
                if ((!string.IsNullOrEmpty(txtStreetAndNumber.Text) || !string.IsNullOrEmpty(txtColony.Text) || !string.IsNullOrEmpty(txtCP.Text) || !string.IsNullOrEmpty(txtState.Text) || !string.IsNullOrEmpty(txtCity.Text)) &&
                    !(!string.IsNullOrEmpty(txtStreetAndNumber.Text) && !string.IsNullOrEmpty(txtColony.Text) && !string.IsNullOrEmpty(txtCP.Text) && !string.IsNullOrEmpty(txtState.Text) && !string.IsNullOrEmpty(txtCity.Text)))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_CAMPOS_DIRECCION_PERSONAL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrEmpty(txtStreetAndNumber.Text))
                        txtStreetAndNumber.Focus();
                    else if (string.IsNullOrEmpty(txtColony.Text))
                        txtColony.Focus();
                    else if (string.IsNullOrEmpty(txtCP.Text))
                        txtCP.Focus();
                    else if (string.IsNullOrEmpty(txtState.Text))
                        txtState.Focus();
                    else if (string.IsNullOrEmpty(txtState.Text))
                        txtCity.Focus();
                }
                else if (!string.IsNullOrEmpty(txtNames.Text) && string.IsNullOrEmpty(txtLastName.Text))  
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_MINIMO_NOMBRE_APELLIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLastName.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtCreditCardCode.Text) || !string.IsNullOrEmpty(txtCreditCardNumber.Text) || !string.IsNullOrEmpty(txtCCVigencyMonth.Text) || !string.IsNullOrEmpty(txtCCVigencyYear.Text) || !string.IsNullOrEmpty(txtCCLastName.Text)) &&
                !(!string.IsNullOrEmpty(txtCreditCardCode.Text) && !string.IsNullOrEmpty(txtCreditCardNumber.Text) && !string.IsNullOrEmpty(txtCCVigencyMonth.Text) && !string.IsNullOrEmpty(txtCCVigencyYear.Text) && !string.IsNullOrEmpty(txtCCLastName.Text)))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_DATOS_TARJETA_CLIENTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrEmpty(txtCreditCardCode.Text))
                        txtCreditCardCode.Focus();
                    else if (string.IsNullOrEmpty(txtCreditCardNumber.Text))
                        txtCreditCardNumber.Focus();
                    else if (string.IsNullOrEmpty(txtCCVigencyMonth.Text))
                        txtCCVigencyMonth.Focus();
                    else if (string.IsNullOrEmpty(txtCCVigencyYear.Text))
                        txtCCVigencyYear.Focus();
                    else if (string.IsNullOrEmpty(txtLastName.Text))
                        txtLastName.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtHotelCode1.Text) && string.IsNullOrEmpty(txtHotelNumber1.Text)) ||
                   (string.IsNullOrEmpty(txtHotelCode1.Text) && !string.IsNullOrEmpty(txtHotelNumber1.Text)))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_CODIGO_HOTEL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrEmpty(txtHotelCode1.Text))
                        txtHotelCode1.Focus();
                    else if (string.IsNullOrEmpty(txtHotelNumber1.Text))
                        txtHotelNumber1.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtHotelCode2.Text) && string.IsNullOrEmpty(txtHotelNumber2.Text)) ||
                    (string.IsNullOrEmpty(txtHotelCode2.Text) && !string.IsNullOrEmpty(txtHotelNumber2.Text)))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_CODIGO_HOTEL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrEmpty(txtHotelCode2.Text))
                        txtHotelCode2.Focus();
                    else if (string.IsNullOrEmpty(txtHotelNumber2.Text))
                        txtHotelNumber2.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtCarAgencyCode1.Text) && string.IsNullOrEmpty(txtCarAgencyNumber1.Text)) ||
               (string.IsNullOrEmpty(txtCarAgencyCode1.Text) && !string.IsNullOrEmpty(txtCarAgencyNumber1.Text)))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_CODIGO_ARRENDADORA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrEmpty(txtCarAgencyCode1.Text))
                        txtCarAgencyCode1.Focus();
                    else if (string.IsNullOrEmpty(txtCarAgencyNumber1.Text))
                        txtCarAgencyNumber1.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtCarAgencyCode2.Text) && string.IsNullOrEmpty(txtCarAgencyNumber2.Text)) ||
               (string.IsNullOrEmpty(txtCarAgencyCode2.Text) && !string.IsNullOrEmpty(txtCarAgencyNumber2.Text)))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_CODIGO_ARRENDADORA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrEmpty(txtCarAgencyCode2.Text))
                        txtCarAgencyCode2.Focus();
                    else if (string.IsNullOrEmpty(txtCarAgencyNumber2.Text))
                        txtCarAgencyNumber2.Focus();
                }
                else
                {
                    isValid = false;
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
        /// Guarda los valores de la consulta realizada en el user control 
        /// </summary>
        private void GetPreviousControlValues()
        {

            for (int i = 0; i < 45; i++)
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
        /// Crea el perfil de primer nivel
        /// </summary>
        private void ContinueCreatingProfile()
        {
            //string send = "*S";
            //string sabreAnswer = string.Empty;
            string textValue = string.Empty;

            //using (CommandsAPI objCommand = new CommandsAPI())
            //{
            //    sabreAnswer = objCommand.SendReceive(send, 0, 0);
            //}


            //int col = 0;
            //int row = 0;
            //CommandsQik.searchResponse(sabreAnswer, ".", ref row, ref col);
            //if (row > 0)
            //{
            //    CommandsQik.CopyResponse(sabreAnswer, ref pcc, 1, 1, 4);
            //}

            if (string.IsNullOrEmpty(this.Parameters[0]))
                pcc = Login.PCC;
            else
                pcc = this.Parameters[0];


            //SetStarsLevel2BL.AddStarslevel2(pcc, ProfileNameFirstLevel, ProfileNameSecondLevel, true, );

            if (!string.IsNullOrEmpty(txtStreetAndNumber.Text))
            {
                textValue = string.Format("DIRECCIÓN PERSONAL: {0}, {1}, {2}, {3}, {4}",
                    txtStreetAndNumber.Text,
                    txtColony.Text,
                    txtCP.Text,
                    txtState.Text,
                    txtCity.Text);
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, textValue, ref ucCreateProfileSecondLevel.profileList);
            }

            if (!string.IsNullOrEmpty(txtNames.Text) && string.IsNullOrEmpty(txtLastName.Text))
            {
                textValue = string.Format("NOMBRE COMPLETO: {0} {1} {2} {3}",
                    txtNames.Text,
                    txtNames2.Text,
                    txtLastName.Text,
                    txtLastName2.Text);
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, textValue, ref ucCreateProfileSecondLevel.profileList);

            }

            if (!string.IsNullOrEmpty(txtOcupation.Text))
            {
                textValue = string.Format("OCUPACIÓN: {0}",
                    txtOcupation.Text);
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, textValue, ref ucCreateProfileSecondLevel.profileList);
            }


            if (!string.IsNullOrEmpty(txtSeat.Text))
            {
                textValue = string.Format("PREFERENCIA DE ASIENTO: {0}",
                    txtSeat.Text);
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, textValue, ref ucCreateProfileSecondLevel.profileList);
            }


            if (!string.IsNullOrEmpty(txtFamiliarName1.Text))
            {
                textValue = string.Format("FAMILIAR : {0} {1} {2}",
                    txtFamiliarName1.Text,
                    (!string.IsNullOrEmpty(txtFamiliarLastname1.Text)? txtFamiliarLastname1.Text : FamiliarLastName),
                    txtPassengerType1.Text);
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, textValue, ref ucCreateProfileSecondLevel.profileList);
            }

            if (!string.IsNullOrEmpty(txtFamiliarName2.Text))
            {
                textValue = string.Format("FAMILIAR : {0} {1} {2}",
                    txtFamiliarName2.Text,
                    (!string.IsNullOrEmpty(txtFamiliarLastname2.Text) ? txtFamiliarLastname2.Text : FamiliarLastName),
                    txtPassengerType2.Text);
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, textValue, ref ucCreateProfileSecondLevel.profileList);
            }

            if (!string.IsNullOrEmpty(txtFamiliarName3.Text))
            {
                textValue = string.Format("FAMILIAR : {0} {1} {2}",
                    txtFamiliarName3.Text,
                    (!string.IsNullOrEmpty(txtFamiliarLastname3.Text) ? txtFamiliarLastname3.Text : FamiliarLastName),
                    txtPassengerType3.Text);
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, textValue, ref ucCreateProfileSecondLevel.profileList);
            }

            if (!string.IsNullOrEmpty(txtFamiliarName4.Text))
            {
                textValue = string.Format("FAMILIAR : {0} {1} {2}",
                    txtFamiliarName4.Text,
                    (!string.IsNullOrEmpty(txtFamiliarLastName4.Text) ? txtFamiliarLastName4.Text : FamiliarLastName),
                    txtPassengerType4.Text);
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, textValue, ref ucCreateProfileSecondLevel.profileList);
            }

            if (!string.IsNullOrEmpty(txtFamiliarName5.Text))
            {
                textValue = string.Format("FAMILIAR : {0} {1} {2}",
                    txtFamiliarName5.Text,
                    (!string.IsNullOrEmpty(txtFamiliarLastName5.Text) ? txtFamiliarLastName5.Text : FamiliarLastName),
                    txtPassengerType5.Text);
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, textValue, ref ucCreateProfileSecondLevel.profileList);
            }

            if (!string.IsNullOrEmpty(txtComment1.Text))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, txtComment1.Text, ref ucCreateProfileSecondLevel.profileList);
            }

            if (!string.IsNullOrEmpty(txtComment2.Text))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, txtComment2.Text, ref ucCreateProfileSecondLevel.profileList);
            }

            if (!string.IsNullOrEmpty(txtComment3.Text))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, txtComment3.Text, ref ucCreateProfileSecondLevel.profileList);
            }

            if (!string.IsNullOrEmpty(txtCreditCardNumber.Text))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("TARJETA DE CREDITO PARA AUTO/HOTEL: {0}{1} {2}-{3} {4}", txtCreditCardCode.Text, txtCreditCardNumber.Text, txtCCVigencyMonth.Text, txtCCVigencyYear.Text, txtCCLastName.Text), ref ucCreateProfileSecondLevel.profileList);
            }

            if (!string.IsNullOrEmpty(txtHotelNumber1.Text))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("PREFERENCIA HOTEL: {0}{1}", txtHotelCode1.Text, txtHotelNumber1.Text), ref ucCreateProfileSecondLevel.profileList);
            }

            if (!string.IsNullOrEmpty(txtHotelNumber2.Text))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("PREFERENCIA HOTEL: {0}{1}", txtHotelCode2.Text, txtHotelNumber2.Text), ref ucCreateProfileSecondLevel.profileList);
            }

            if (!string.IsNullOrEmpty(txtCarAgencyNumber1.Text))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("PREFERENCIA ARRENDADORA: {0}{1}", txtCarAgencyCode1.Text, txtCarAgencyNumber1.Text), ref ucCreateProfileSecondLevel.profileList);
            }

            if (!string.IsNullOrEmpty(txtCarAgencyNumber2.Text))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("PREFERENCIA ARRENDADORA: {0}{1}", txtCarAgencyCode2.Text, txtCarAgencyNumber2.Text), ref ucCreateProfileSecondLevel.profileList);
            }
            DateTime date = DateTime.Now;

            foreach (ListItem Content in ucCreateProfileSecondLevel.profileList)
            {
                SetStarsLevel2InfoBL.AddStarsLevel2Info(pcc, ProfileNameFirstLevel, ProfileNameSecondLevel, Content.Value, Content.Text, date, false);
            }
            Update1stLevelBL.Update1stLevel(pcc, ProfileNameFirstLevel, string.Empty, 1);
            ucProfileSearch.star1Info = Star1stLevelInfoBL.GetStar1stLevelInfo(pcc, ProfileNameFirstLevel);
            ucProfileSearch.star2Info = Star2ndLevelInfoBL.GetStar2ndLevelInfo(pcc, ProfileNameFirstLevel, ProfileNameSecondLevel);
            frmProfiles._ucProfileSearch = null;

            frmProfiles frm = this.ParentForm as frmProfiles;
            frm.Width = frm.MinWidth;
            frm.Height = frm.MinHeight;
            frm.CenterForm();
            frm.IsMinSize = true;

            CatAllStarsBL.ListAllStars.Clear();

            LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_PROFILE_INFO_DISPLAY);
        }


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
                GetPreviousControlValues();
                LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_CREATE_PROFILE_SECOND_LEVEL);
            }
            else if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }

        }

        #endregion//Back to a Previous Usercontrol or Validate Enter KeyDown


        


    }
}
