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
    public partial class ucAddProfileInfo : CustomUserControl
    {

        /// <summary>
        /// Descripción: Ingresa nuevas lineas a perfiles de primer o segundo nivel
        /// Creación:    18 febrero 2010, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>

        public ucAddProfileInfo()
        {
            InitializeComponent();
            this.InitialControlFocus = cmbLineType;
            this.LastControlFocus = btnAccept;
        }


        //Evento Load
        private void ucAddProfileInfo_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            LoadCatProfileLines();
            cmbLineType.Focus();
            cmbLineType.SelectedIndex = 0;
        }


        //Evento btnAccept_Click
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!IsValidBusinessRules)
            {
                CreateNewProfileLine();
            }
        }

        //Evento btnAddChange_Click
        private void btnAddChange_Click(object sender, EventArgs e)
        {
            AddChange();
        }

        //Evento btnAddCross_Click
        private void btnAddCross_Click(object sender, EventArgs e)
        {
            AddCrossLoraine();
        }

        #region===== MethodsClass =====

        /// <summary>
        /// Carga el catalogo de tipo de lineas en el combo
        /// </summary>
        private void LoadCatProfileLines()
        {
            cmbLineType.Items.Add(Resources.Profiles.Constants.MESSAGE_LINE_TYPE);
            List<ListItem> listProfileLines = CatProfileLinesBL.GetProfileLines();
            foreach (ListItem ProfileLinesItem in listProfileLines)
            {
                if (!ProfileLinesItem.Value.Equals(Resources.Profiles.Constants.LINE_TYPE_S))
                {
                    ListItem litem = new ListItem();
                    litem.Text = ProfileLinesItem.Text;
                    litem.Value = ProfileLinesItem.Value;
                    cmbLineType.Items.Add(litem);
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
                if (cmbLineType.SelectedIndex < 1)
                {
                    MessageBox.Show(Resources.Profiles.Profiles.SELECCIONA_TIPO_LINEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbLineType.Focus();
                }
                else if (string.IsNullOrEmpty(txtDescription.Text))
                {
                    MessageBox.Show(Resources.Profiles.Profiles.PROPORCIONA_DATO_A_INGRESAR_PERFIL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDescription.Focus();
                }
                else
                {
                    isValid = false;
                }

                return isValid;
            }
        }



        private void CreateNewProfileLine()
        {
            if (this.Parameters != null)
            {
                if (this.Parameters.Length.Equals(4))
                {
                    SetStarsLevel1InfoBL.AddStarslevel1Info(this.Parameters[0], this.Parameters[1], ((ListItem)(cmbLineType.SelectedItem)).Value.ToString(), txtDescription.Text, Convert.ToDateTime(this.Parameters[2]), Convert.ToBoolean(this.Parameters[3]));
                    SetProfileChangesBL.SetProfile(Login.PCC, Login.Agent, this.Parameters[1], string.Empty, DateTime.Now);
                    ucProfileSearch.star1Info.Clear();
                    ucProfileSearch.star1Info = Star1stLevelInfoBL.GetStar1stLevelInfo(this.Parameters[0], this.Parameters[1]);
                    frmProfiles._ucProfileSearch = null;
                    LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_PROFILE_INFO_DISPLAY);
                }
                else if (this.Parameters.Length.Equals(5))
                {
                    SetStarsLevel2InfoBL.AddStarsLevel2Info(this.Parameters[0], this.Parameters[1], this.Parameters[2], ((ListItem)(cmbLineType.SelectedItem)).Value.ToString(), txtDescription.Text, Convert.ToDateTime(this.Parameters[3]), Convert.ToBoolean(this.Parameters[4]));
                    SetProfileChangesBL.SetProfile(Login.PCC, Login.Agent, this.Parameters[1], this.Parameters[2], DateTime.Now);
                    ucProfileSearch.star1Info.Clear();
                    ucProfileSearch.star2Info.Clear();
                    ucProfileSearch.star1Info = Star1stLevelInfoBL.GetStar1stLevelInfo(this.Parameters[0], this.Parameters[1]);
                    ucProfileSearch.star2Info = Star2ndLevelInfoBL.GetStar2ndLevelInfo(this.Parameters[0], this.Parameters[1], this.Parameters[2]);
                    frmProfiles._ucProfileSearch = null;
                    LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_PROFILE_INFO_DISPLAY);
                }
            }
        }

        //Agrega un change al texto de la nueva linea
        private void AddChange()
        {
            if (!string.IsNullOrEmpty(txtDescription.Text))
                txtDescription.Text = string.Concat(txtDescription.Text, Resources.Constants.CHANGE);
            else
            {
                txtDescription.Text = Resources.Constants.CHANGE;
            }
        }

        //Agrega una cruz de lorena al texto de la nueva linea
        private void AddCrossLoraine()
        {
            if (!string.IsNullOrEmpty(txtDescription.Text))
                txtDescription.Text = string.Concat(txtDescription.Text, Resources.Constants.CROSSLORAINE);
            else
            {
                txtDescription.Text = Resources.Constants.CROSSLORAINE;
            }
        }

        #endregion//End MethodsClass


        #region===== txtControls KeyDown =====

        //Evento txtControls_KeyDown
        private void txtControls_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }
            else if (e.KeyData.Equals(Keys.Escape))
            {
                frmProfiles._ucProfileSearch = null;
                LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_PROFILE_INFO_DISPLAY);
            }
        }

        #endregion
    }
}
