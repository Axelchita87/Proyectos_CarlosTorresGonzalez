using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.ProfileCreditCardSelector
{
    public partial class frmVolarisCreditCardsProfile : Form
    {
        public frmVolarisCreditCardsProfile()
        {
            InitializeComponent();
        }


        private VolarisProfile _profile;
        public void SetProfile(VolarisProfile profile)
        {
            if (profile != null)
            {
                _profile = profile;
                SetCards();
            }
        }

        private void SetCards()
        {

            if (_profile.CreditCards.HasFristLevelCards)
            {
                this.fristLevelCombo.DataSource = _profile.CreditCards.GetFirstLevelProfile();
                this.fristLevelCombo.DisplayMember = "FullProtectedCard";

            }
            else
            {
                this.fristLevelCombo.Enabled = false;
                this.fristLevelCheckBox.Enabled = false;
            }

            if (_profile.CreditCards.HasSecondLevelCards)
            {
                this.secondLevelCombo.DataSource = _profile.CreditCards.GetSecondLevelProfile();
                this.secondLevelCombo.DisplayMember = "FullProtectedCard";
            }
            else
            {
                this.secondLevelCombo.Enabled = false;
                this.secondLevelCheckBox.Enabled = false;
            }

        }

        public VolarisProfileCreditCard SelectedCreditCard { get; set; }

        public bool IsCardSelected
        {
            get { return SelectedCreditCard != null; }
        }


        private void confirmButton_Click(object sender, EventArgs e)
        {

            if (fristLevelCheckBox.Checked)
            {
                SelectedCreditCard = this.fristLevelCombo.SelectedItem as VolarisProfileCreditCard;
                this.Close();
            }

            if (secondLevelCheckBox.Checked)
            {
                SelectedCreditCard = this.secondLevelCombo.SelectedItem as VolarisProfileCreditCard;
                this.Close();
            }


        }

        private void denyButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fristLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void secondLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
