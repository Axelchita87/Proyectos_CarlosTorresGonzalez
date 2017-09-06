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
    public partial class ucRenameProfile : CustomUserControl
    {

        /// <summary>
        /// Descripción: Renombra el perfil de primer o segundo nivel
        /// Creación:    19 febrero 2010, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        

        public ucRenameProfile()
        {
            InitializeComponent();
            this.LastControlFocus = btnUpdate;
        }


        //Evento Load
        private void ucRenameProfile_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            ActiveControls();
        }


        //Evento btnUpdate_Click
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!IsValidBusinessRules)
            {
                RenameProfile();
            }
        }
        #region===== MethodsClass =====


        /// <summary>
        /// Activa los controles y asigna valores por default dependiendo del tipo de estrella
        /// a renombrar
        /// </summary>
        private void ActiveControls()
        {
            if (this.Parameters != null)
            {
                if (this.Parameters.Length.Equals(2))
                {
                    txtPCC.Text = this.Parameters[0];
                    txtPCC.Enabled = false;
                    txtStar2Name.Enabled = false;
                    txtStar2Name.Visible = false;
                    lblStar2Name.Visible = false;
                    this.InitialControlFocus = txtStar1name;
                    lblDescription.Text = string.Format("{0} Primer Nivel {1}",
                        lblDescription.Text,
                        this.Parameters[1]);
                    txtStar1name.Focus();
                }
                else if (this.Parameters.Length.Equals(3))
                {
                    txtPCC.Text = this.Parameters[0];
                    txtPCC.Enabled = false;
                    txtStar1name.Text = this.Parameters[1];
                    txtStar1name.Enabled = false;
                    this.InitialControlFocus = txtStar2Name;
                    lblDescription.Text = string.Format("{0} Segundo Nivel {1}",
                        lblDescription.Text,
                        this.Parameters[2]);
                    txtStar2Name.Focus();
                }
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
                if (txtStar1name.Enabled && string.IsNullOrEmpty(txtStar1name.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_NUEVO_NOMBRE_PRIMER_NIVEL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtStar1name.Focus();
                }
                else if (!txtStar1name.Visible && string.IsNullOrEmpty(txtStar2Name.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.INGRESA_NUEVO_NOMBRE_SEGUNDO_NIVEL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtStar2Name.Focus();
                }
                else
                {
                    isValid = false;
                }

                return isValid;
            }
        }

        /// <summary>
        /// Renombra el nombre de la estrella
        /// </summary>
        private void RenameProfile()
        {
            if (this.Parameters != null)
            {
                if (this.Parameters.Length.Equals(2))
                {
                    DialogResult result = MessageBox.Show(Resources.Profiles.Constants.SAVE_CHANGES, Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.Yes))
                    {
                        Update1stLevelBL.Update1stLevel(this.Parameters[0], this.Parameters[1], txtStar1name.Text, 0);
                        SetProfileChangesBL.SetProfile(Login.PCC, Login.Agent, this.Parameters[1], string.Empty, DateTime.Now);
                        CatAllStarsBL.ListAllStars.Clear();
                        ucProfileSearch.star1Info.Clear();
                        ucProfileSearch.star1Info = Star1stLevelInfoBL.GetStar1stLevelInfo(this.Parameters[0], txtStar1name.Text);
                        frmProfiles._ucProfileSearch = null;
                        LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_PROFILE_INFO_DISPLAY);
                    }
                    else
                    {
                        frmProfiles._ucProfileSearch = null;
                        LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_WELCOME_PROFILES);
                    }

                }
                else if (this.Parameters.Length.Equals(3))
                {
                    DialogResult result = MessageBox.Show(Resources.Profiles.Constants.SAVE_CHANGES, Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.Yes))
                    {
                        //Update2ndLevelBL.Update2ndLevel(this.Parameters[0], this.Parameters[1], this.Parameters[2], txtStar2Name.Text);
                        SetProfileChangesBL.SetProfile(Login.PCC, Login.Agent, this.Parameters[1], this.Parameters[2], DateTime.Now);
                        CatAllStarsBL.ListAllStars.Clear();
                        ucProfileSearch.star1Info.Clear();
                        ucProfileSearch.star2Info.Clear();
                        ucProfileSearch.star1Info = Star1stLevelInfoBL.GetStar1stLevelInfo(this.Parameters[0], this.Parameters[1]);
                        ucProfileSearch.star2Info = Star2ndLevelInfoBL.GetStar2ndLevelInfo(this.Parameters[0], this.Parameters[1], txtStar2Name.Text);
                        frmProfiles._ucProfileSearch = null;
                        LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_PROFILE_INFO_DISPLAY);
                    }
                    else
                    {
                        frmProfiles._ucProfileSearch = null;
                        LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_WELCOME_PROFILES);
                    }
                }
            }
        }


        #endregion//End MethodsClass


        #region===== txtControls KeyDown =====

        //Evento txtControls_KeyDown
        private void txtControls_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Enter))
            {
                btnUpdate_Click(sender, e);
            }
            else if (e.KeyData.Equals(Keys.Escape))
            {
                frmProfiles._ucProfileSearch = null;
                LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_PROFILE_INFO_DISPLAY);
            }
        }

        #endregion//txtControls KeyDown


        
    }
}