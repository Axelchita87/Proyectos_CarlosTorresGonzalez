using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation.Reservations.Profiles
{
    public partial class frmUpdateProfiles : Form
    {
        private string _level;
        List<Star1stLevelInfo> star1Info = new List<Star1stLevelInfo>();
        public static Star1Details ObjStar1Dfup;
        public static Star2Details ObjStar2Dfup;
        public static Form parentForm;

        public frmUpdateProfiles(Form form, string level)
        {
            parentForm = form;
            _level = level;
            InitializeComponent();
            ucAvailability.IsInterJetProcess = false;

        }

        private void SearchProfileParameters1L()
        {
            star1Info = ucProfileSearch.star1Info;
            ObjStar1Dfup = new Star1Details();
            ObjStar1Dfup.Id = null;
            foreach (Star1stLevelInfo lines in ucProfileSearch.star1Info)
            {
                ObjStar1Dfup.ProfileName = lines.Level1;
                ObjStar1Dfup.Pcc = lines.Pccid;
                try
                {
                    if (lines.Type == "A" && Regex.IsMatch(lines.Text, "^DK[A-Z]{3}[0-9]{3}$", RegexOptions.IgnoreCase))
                        ObjStar1Dfup.CustomerDk = lines.Text.Substring(2);
                    if (lines.Type == "A" && Regex.IsMatch(lines.Text, "^5CONTACTO-", RegexOptions.IgnoreCase))
                        ObjStar1Dfup.ContactCompany = lines.Text.Substring(10);
                    if (lines.Type == "N" && Regex.IsMatch(lines.Text, "^5PASSWORD*", RegexOptions.IgnoreCase))
                        ObjStar1Dfup.Password = lines.Text.Substring(10);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), @"Error");
                }
            }
        }


        private void SearchProfileParameters2L()
        {
            star1Info = ucProfileSearch.star1Info;
            ObjStar2Dfup = new Star2Details();

            string[] texts;
            string text=string.Empty;


            foreach (Star2ndLevelInfo lines in ucProfileSearch.star2Info)
            {
                try
                {
                    ObjStar2Dfup.Pcc = lines.Pccid;
                    ObjStar2Dfup.Level1 = lines.Level1;
                    ObjStar2Dfup.Level2 = lines.Level2;



                    if (lines.Type == "A" && Regex.IsMatch(lines.Text, "^9[0-9]*X[0-9]*-", RegexOptions.IgnoreCase))
                    {
                        texts = lines.Text.Split(new String[] { "X", "-" }, 5, StringSplitOptions.None);
                        ObjStar2Dfup.OfficePhone = texts[0].Substring(1);
                        ObjStar2Dfup.Ext = texts[1];
                        ObjStar2Dfup.OfficePhoneCode = texts[2];
                    }

                    if (lines.Type == "A" && Regex.IsMatch(lines.Text, "^9[0-9]*-[A-Z]$", RegexOptions.IgnoreCase))
                    {
                        ObjStar2Dfup.OfficePhone = lines.Text.Substring(1);
                    }

                    if (lines.Type == "O" && Regex.IsMatch(lines.Text, "^9[0-9]*-[A-Z]$", RegexOptions.IgnoreCase))
                    {
                        ObjStar2Dfup.DirectPhone = lines.Text.Substring(1);
                    }


                    if ((lines.Type == "A" || lines.Type == "O") && Regex.IsMatch(lines.Text, "^PE‡", RegexOptions.IgnoreCase))
                    {
                        texts = lines.Text.Split(new String[] { "PE‡", "‡" }, 5, StringSplitOptions.None);
                        ObjStar2Dfup.Email = texts[1];
                    }


                    if ((lines.Type == "A" || lines.Type == "O") && Regex.IsMatch(lines.Text, "^FF", RegexOptions.IgnoreCase))
                    {
                        ObjStar2Dfup.FrequentFlyer1 = "*#**#*";
                        ObjStar2Dfup.FrequentFlyer2 = "*#**#*";
                        ObjStar2Dfup.FrequentFlyer3 = "*#**#*";
                        ObjStar2Dfup.FrequentFlyer4 = "*#**#*";
                        ObjStar2Dfup.FrequentFlyer5 = "*#**#*";

                        texts = lines.Text.Split(new String[] { "FF", "-" }, 5, StringSplitOptions.RemoveEmptyEntries);
                        
                        if (texts.Length > 1)
                        text = texts[0].Substring(0, 2) + "*#*" + texts[0].Substring(2) + "*#*" + texts[1];

                        if (ObjStar2Dfup.FrequentFlyer1 == "*#**#*")
                        {
                            ObjStar2Dfup.FrequentFlyer1 = text;
                            break;
                        }

                        if (ObjStar2Dfup.FrequentFlyer1 != "*#**#*")
                        {
                            ObjStar2Dfup.FrequentFlyer2 = text;
                            break;
                        }

                        if (ObjStar2Dfup.FrequentFlyer2 != "*#**#*")
                        {
                            ObjStar2Dfup.FrequentFlyer3 = text;
                            break;
                        }

                        if (ObjStar2Dfup.FrequentFlyer3 != "*#**#*")
                        {
                            ObjStar2Dfup.FrequentFlyer4 = text;
                            break;
                        }

                        if (ObjStar2Dfup.FrequentFlyer4 != "*#**#*")
                        {
                            ObjStar2Dfup.FrequentFlyer5 = text;
                            break;
                        }

                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), @"Error");
                }
            }
        }

        private void frmUpdateProfiles_Load(object sender, EventArgs e)
        {

            var parameters = new string[4];

            frmPreloading fr = new frmPreloading(this);
            fr.Show();

            parameters[3] = "NewUpdate";

            if (_level == "First")
            {
                SearchProfileParameters1L();
                parameters[0] = ObjStar1Dfup.Pcc;
                parameters[1] = ObjStar1Dfup.ProfileName;
                parameters[2] = null;

                LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Left, this, Resources.Profiles.Constants.UC_PROFILE_INFO_DISPLAY);
                LoaderProfiles.AddToPanelWithParameters(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_FIRST_LEVEL_PROFILES, parameters);
            }

            if (_level == "Second")
            {
                SearchProfileParameters2L();
                parameters[0] = ObjStar2Dfup.Pcc;
                parameters[1] = ObjStar2Dfup.Level1;
                parameters[2] = ObjStar2Dfup.Level2;

                LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Left, this, Resources.Profiles.Constants.UC_PROFILE_INFO_DISPLAY);
                LoaderProfiles.AddToPanelWithParameters(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_SECOND_LEVEL_PROFILES, parameters);
            }
        }

        private void frmUpdateProfiles_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                parentForm.Close();
            }
            catch { }

            try
            {

                MyCTS.Presentation.Reservations.Profiles.UcSecondLevelProfiles.ListObjStar2Dcpsl.Clear();
                frmProfiles form =new frmProfiles();
                form.Show();
            }
            catch { }
        }
    }
}