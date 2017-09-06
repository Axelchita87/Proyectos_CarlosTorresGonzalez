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
    public partial class ucSearchProfileDetailed : CustomUserControl
    {

        /// <summary>
        /// Descripción: Carga los resultados de la busqueda avanzada de perfil
        /// Creación:    03 febrero 2010, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>

        List<CatAllStars> StarsList = new List<CatAllStars>();

        public ucSearchProfileDetailed()
        {
            InitializeComponent();
            this.InitialControlFocus = txtPCC;
            this.LastControlFocus = listViewProfiles;
        }


        //Evento Load
        private void ucSearchProfileDetailed_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            CatAllStarsBL.ListAllStars.Clear();
            CatAllStarsBL.GetElements(ref CatAllStarsBL.ListAllStars, Login.OrgId);
            if (frmProfiles.IsReservationFlow)
            {
                this.Height = 545;
            }
            txtPCC.Focus();
        }


        #region===== MethodsClass =====

        /// <summary>
        /// Carga el resultado de la busqueda de perfil en el listview
        /// </summary>
        private void LoadProfileSearchResult()
        {
            listViewProfiles.Items.Clear();
            listViewProfiles.Enabled = true;

            listViewProfiles.LargeImageList = imageProfileList;
            listViewProfiles.SmallImageList = imageProfileList;
            StarsList = CatAllStarsBL.GetAllStarsDetailed_Profile(txtPCC.Text, txtStar1name.Text, txtStar2Name.Text, Login.OrgId);
            if (StarsList.Count != 0)
            {
                listViewProfiles.View = View.Details;
                for (int i = 0; i < StarsList.Count; i++)
                {
                    if (StarsList[i].Active)
                    {
                        if (StarsList[i].Level.Equals(Resources.Profiles.Constants.STAR_LEVEL_ONE))
                        {
                            ListViewItem itemStar = new ListViewItem(string.Concat(StarsList[i].StarName, " ", StarsList[i].PccId), 0);
                            itemStar.SubItems.Add(StarsList[i].Level);
                            listViewProfiles.Items.Add(itemStar);

                        }
                        else
                        {
                            ListViewItem itemStar = new ListViewItem(string.Concat(StarsList[i].StarName, " ", StarsList[i].PccId), 1);
                            itemStar.SubItems.Add(StarsList[i].Level);
                            listViewProfiles.Items.Add(itemStar);
                        }
                    }
                }
            }
            else
            {
                ListViewItem itemStar = new ListViewItem(Resources.Profiles.Constants.NO_RESULTS_TRY_AGAIN);
                itemStar.SubItems.Add("");
                listViewProfiles.Items.Add(itemStar);
                listViewProfiles.Enabled = false;
            }

            

        }


        /// <summary>
        /// Carga informacion de perfil elegido por el usuario
        /// </summary>
        private void SetProfileInfo()
        {
            int indexProfile = listViewProfiles.SelectedIndices[0];
            if (StarsList[indexProfile].Level.Equals(Resources.Profiles.Constants.STAR_LEVEL_ONE))
            {
                ucProfileSearch.star1Info.Clear();
                ucProfileSearch.star2Info.Clear();
                ucProfileSearch.star1Info = Star1stLevelInfoBL.GetStar1stLevelInfo(StarsList[indexProfile].PccId, StarsList[indexProfile].StarName);
                AccessProfile(ucProfileSearch.star1Info[0].Level1);
            }
            else if (StarsList[indexProfile].Level.Equals(Resources.Profiles.Constants.STAR_LEVEL_TWO))
            {
                ucProfileSearch.star1Info.Clear();
                ucProfileSearch.star2Info.Clear();
                ucProfileSearch.star1Info = Star1stLevelInfoBL.GetStar1stLevelInfo(StarsList[indexProfile].PccId, StarsList[indexProfile].Star1Ref);
                ucProfileSearch.star2Info = Star2ndLevelInfoBL.GetStar2ndLevelInfo(StarsList[indexProfile].PccId, StarsList[indexProfile].Star1Ref, StarsList[indexProfile].StarName);
                AccessProfile(ucProfileSearch.star2Info[0].Level2);
            }
        }

        #endregion//End MethodsClass


        #region===== listViewProfiles Events =====

        //Evento listViewProfiles_DoubleClick
        private void listViewProfiles_DoubleClick(object sender, EventArgs e)
        {
            SetProfileInfo();
        }

        //Evento ucSearchProfileDetailed_KeyDown
        private void ucSearchProfileDetailed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Enter))
            {
                SetProfileInfo();
            }
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


        #region===== txtControls KeyDown =====

        //Evento txtControls_KeyDown
        private void txtControls_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                if (frmProfiles.IsReservationFlow)
                {                    
                    this.ParentForm.Close();
                }
                else
                {
                    frmProfiles._ucProfileSearch = null;
                    LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_WELCOME_PROFILES);
                }
            }
        }


        /// <summary>
        /// Verifica la contraseña del perfil para tener acceso a la información
        /// </summary>
        private void AccessProfile(string Profile)
        {
            string pwdProfile = string.Empty;
            if (ucProfileSearch.star1Info.Count > 0)
            {

                if (!(!string.IsNullOrEmpty(Login.ProfileAllAccess) && Login.ProfileAllAccess.Equals("A")))
                {
                    foreach (Star1stLevelInfo line in ucProfileSearch.star1Info)
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
                    InputBoxDialog ib = new InputBoxDialog();
                    ib.FormPrompt = Resources.Profiles.Constants.INTRODUCE_PASSWORD;
                    ib.FormCaption = string.Concat(Resources.Profiles.Constants.MODAL_PWD_TITLE, " ", Profile);
                    ib.DefaultValue = string.Empty;
                    ib.ModeToShow = InputBoxDialog.ModeTextBox.Password;
                    ib.ShowDialog();

                    string s = ib.InputResponse.ToUpper();
                    ib.Close();

                    if (s.Equals(pwdProfile))
                    {
                        frmProfiles._ucProfileSearch = null;
                        LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_PROFILE_INFO_DISPLAY);
                    }
                    else
                        MessageBox.Show(Resources.Profiles.Constants.PASSWORD_ERROR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    frmProfiles._ucProfileSearch = null;
                    LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_PROFILE_INFO_DISPLAY);
                }
            }
        }

        #endregion//txtControls KeyDown


        #region ===== txtControls text changed Events =====

        //Evento txtPCC_TextChanged
        private void txtPCC_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtPCC.Text))
                LoadProfileSearchResult();
        }


        //txtStar1name_TextChanged
        private void txtStar1name_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPCC.Text) && !string.IsNullOrEmpty(txtStar1name.Text))
                LoadProfileSearchResult();
        }


        //txtStar2Name_TextChanged
        private void txtStar2Name_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPCC.Text) && 
                !string.IsNullOrEmpty(txtStar1name.Text) && 
                !string.IsNullOrEmpty(txtStar2Name.Text))
                LoadProfileSearchResult();
        }


        #endregion//End txtControls text changed Events

        
    }
}
