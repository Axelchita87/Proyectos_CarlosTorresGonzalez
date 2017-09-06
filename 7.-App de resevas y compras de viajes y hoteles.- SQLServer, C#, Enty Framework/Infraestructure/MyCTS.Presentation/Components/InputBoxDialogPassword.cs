using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Business;

namespace MyCTS.Presentation.Components
{
    public partial class InputBoxDialogPassword : Form
    {
        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtInput;


        public InputBoxDialogPassword()
        {
            InitializeComponent();
        }

        #region Private Variables
        string formCaption = string.Empty;
        string formPrompt = string.Empty;
        string inputResponse = string.Empty;
        string defaultValue = string.Empty;
        #endregion

        #region Public Properties
        public string FormCaption
        {
            get { return formCaption; }
            set { formCaption = value; }
        } // property FormCaption
        public string FormPrompt
        {
            get { return formPrompt; }
            set { formPrompt = value; }
        } // property FormPrompt
        public string InputResponse
        {
            get { return inputResponse; }
            set { inputResponse = value; }
        } // property InputResponse
        public string DefaultValue
        {
            get { return defaultValue; }
            set { defaultValue = value; }
        } // property DefaultValue

        public string firstStarName { get; set; }
        public string secondStarName { get; set; }
        public string pcc { get; set; }

        public enum ModeTextBox
        {
            Normal = 0,
            Password = 1
        }

        private ModeTextBox modetextbox;
        public ModeTextBox ModeToShow
        {
            get { return modetextbox; }
            set { modetextbox = value; }
        }
        #endregion

        #region Form and Control Events
        private void InputBox_Load(object sender, System.EventArgs e)
        {
            this.txtInput.Text = defaultValue;
            this.lblPrompt.Text = formPrompt;
            this.Text = formCaption;
            this.txtInput.SelectionStart = 0;
            this.txtInput.SelectionLength = this.txtInput.Text.Length;
            this.txtInput.Focus();

            if (modetextbox == ModeTextBox.Password)
                this.txtInput.UseSystemPasswordChar = true;
        }


        private void btnOK_Click(object sender, System.EventArgs e)
        {
            InputResponse = this.txtInput.Text;
            Parameter pass = ParameterBL.GetParameterValue("PasswordProfilesDelete");
            if (InputResponse.Equals(pass.Values))
            {
                if (!string.IsNullOrEmpty(firstStarName) && string.IsNullOrEmpty(secondStarName))
                {
                    DialogResult result = MessageBox.Show(string.Format("¿DESEAS BORRAR LA ESTRELLA DE PRIMER NIVEL {0}?", firstStarName), Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.Yes))
                    {
                        Delete1stLevelBL.Delete1stLevel(pcc, firstStarName);
                        //Active1stLevelBL.Active1stLevel(pcc, firstStarName);
                        SetProfileChangesBL.SetProfile(Login.PCC, Login.Agent, firstStarName, string.Empty, DateTime.Now);
                        CatAllStarsBL.ListAllStars.Clear();
                        LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_WELCOME_PROFILES);
                    }
                }
                else if (!string.IsNullOrEmpty(firstStarName) && !string.IsNullOrEmpty(secondStarName))
                {
                    DialogResult result = MessageBox.Show(string.Format("¿DESEAS BORRAR LA ESTRELLA DE SEGUNDO NIVEL {0}?", secondStarName), Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.Yes))
                    {
                        Delete2ndLevelBL.Delete2ndLevel(secondStarName);
                        //Active2ndLevelBL.Active2ndLevel(pcc, firstStarName, secondStarName);
                        SetProfileChangesBL.SetProfile(Login.PCC, Login.Agent, firstStarName, secondStarName, DateTime.Now);                        
                        bool noSecondStar = true;
                        List<CatAllStars> Star2Count = CatAllStarsBL.GetAll2ndStarDetailed_Profile(ucProfileSearch.star1Info[0].Pccid, ucProfileSearch.star1Info[0].Level1, Login.OrgId);
                        if (Star2Count != null)
                        {
                            foreach (CatAllStars item in Star2Count)
                            {
                                if (item.Active)
                                {
                                    noSecondStar = false;
                                    break;
                                }
                            }
                        }
                        if (noSecondStar)
                            Update1stLevelBL.Update1stLevel(pcc, firstStarName, string.Empty, 2);
                        LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_WELCOME_PROFILES);
                    }
                }
            }
            else
                MessageBox.Show(Resources.Profiles.Constants.PASSWORD_ERROR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.DialogResult = DialogResult.OK;
                btnOK_Click(sender, e);
            }
        }


    }
}
