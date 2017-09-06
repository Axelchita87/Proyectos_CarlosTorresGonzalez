using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture.PassangerCaptureForm;
using MyCTS.Entities;
using DevExpress.XtraEditors;

namespace MyCTS.Presentation
{
    public partial class ucVolarisPassangerCaptureForm : CustomUserControl, IVolarisPassangerCaptureFormView
    {

        private readonly VolarisPassangerCaptureFormPresenter _presenter;
        public ucVolarisPassangerCaptureForm()
        {
            InitializeComponent();
            _presenter = new VolarisPassangerCaptureFormPresenter()
                             {
                             };

        }

        public string SkinName
        {
            set { this.groupControl1.LookAndFeel.SkinName = value; }
        }

        private void ucVolarisPassangerCaptureForm_Load(object sender, EventArgs e)
        {
            _presenter.View = this;
            _presenter.Repository = new VolarisPassangerCaptureFormRepository();
            LoadSpecialService();
            _presenter.SetPassanger();
        


        }

        /// <summary>
        /// Loads the special service.
        /// </summary>
        private void LoadSpecialService()
        {
            var wheelChair = new VolarisPassangerSpecialService
                                 {
                                     Name = "Silla de Ruedas",
                                     Type =  VolarisSepecialServiceType.WheelChair
                                 };

            var paxMostBeGuided = new VolarisPassangerSpecialService
                                      {
                                          Name = "Pasajero debe ser acompañado",
                                          Type = VolarisSepecialServiceType.PassangerMostBeGuided
                                      };

            var none = new VolarisPassangerSpecialService
            {
                Name = "--Seleccione--",
                Type = VolarisSepecialServiceType.None
            };

            this.specialServiceComboBox.Properties.Items.AddRange(new List<VolarisPassangerSpecialService>
                                                                      {
                                                                          none,
                                                                          wheelChair,
                                                                          paxMostBeGuided
                                                                      });
            this.specialServiceComboBox.SelectedIndex = 0;

        }




        #region Miembros de IVolarisPassangerCaptureFormView

        private void LoadChildrenAndInfantTitles()
        {

            this.titleComboBox.Properties.Items.Add(VolarisPassangerTitleType.Menor);
            this.titleComboBox.SelectedIndex = 0;
        }
        private void LoadAdultsTitles()
        {

            this.titleComboBox.Properties.Items.Add(VolarisPassangerTitleType.Sr);
            this.titleComboBox.Properties.Items.Add(VolarisPassangerTitleType.Sra);
            this.titleComboBox.Properties.Items.Add(VolarisPassangerTitleType.Srita);
            this.titleComboBox.SelectedIndex = 0;
        }

        public void ShowLoadingProfile()
        {
            this.loadingProfile1.Visible = true;
            this.groupControl1.Visible = false;
        }

        public void HideLoadingProfile()
        {
            this.loadingProfile1.Visible = false;

            this.groupControl1.Visible = true;
        }


        /// <summary>
        /// Sets the infant view.
        /// </summary>
        public void SetInfantView()
        {
            GenderComboBox();
            LoadChildrenAndInfantTitles();

        }

        /// <summary>
        /// Sets the adult view.
        /// </summary>
        public void SetAdultView()
        {
            GenderComboBox();
            LoadAdultsTitles();
        }
        public void SetChildView()
        {
            GenderComboBox();
            LoadChildrenAndInfantTitles();
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public VolarisPassangerTitleType Title
        {
            get
            {
                return (VolarisPassangerTitleType)this.titleComboBox.SelectedItem;
            }
            set
            {
                titleComboBox.SelectedItem = value;
            }
        }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        public VolarisPassangerGenderType Gender
        {
            get { return (VolarisPassangerGenderType)this.genderTextBox.SelectedItem; }
            set { this.genderTextBox.SelectedItem = value; }
        }

        public string PaxName
        {
            get { return nameTextBox.Text; }
            set { nameTextBox.Text = value; }
        }

        public string LastName
        {
            get { return this.lastNameTextBox.Text; }
            set { this.lastNameTextBox.Text = value; }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return this.ucVolarisDateOfBirthControl1.BirthDay;
            }
            set
            {
                ucVolarisDateOfBirthControl1.BirthDay = value;
            }
        }


        public VolarisPassangerSpecialService SpecialService
        {
            get { return this.specialServiceComboBox.SelectedItem as VolarisPassangerSpecialService; }
            set { this.specialServiceComboBox.SelectedItem = value; }
        }

        #endregion

        #region Miembros de IBaseView


        public void ValidateInput()
        {
            IsValid = passangerValidator.Validate();

        }

        public bool IsValid { get; set; }





        public IVolarisPassanger Passanger
        {
            get { return _presenter.GetPassanger(); }
            set
            {
                _presenter.SetPassanger(value);
                if(_presenter.IsInfant)
                {
                    this.specialServiceComboBox.Enabled = false;
                }
            }
        }

        private void GenderComboBox()
        {
            this.genderTextBox.Properties.Items.Add(VolarisPassangerGenderType.Hombre);
            this.genderTextBox.Properties.Items.Add(VolarisPassangerGenderType.Mujer);
            this.genderTextBox.SelectedIndex = 0;
        }





        /// <summary>
        /// Sets the list of passangers number.
        /// </summary>
        /// <param name="passangersNumber">The passangers number.</param>
        public void SetListOfPassangersNumber(List<VolarisAdultPassanger> passangersNumber)
        {
            if (passangersNumber.Any())
            {
                this.travelWith.Properties.Items.AddRange(passangersNumber);
                this.travelWith.SelectedIndex = 0;
            }

        }

        #endregion

        #region Miembros de IVolarisPassangerCaptureFormView


        public string Header
        {
            get { return this.groupControl1.Text; }
            set { this.groupControl1.Text = value; }
        }

        public bool ShowInfantsPanel
        {
            get { return true; }
            set
            {
                labelControl6.Visible = value;
                this.travelWith.Visible = value;
                label5.Visible = value;
            }
        }



        public IVolarisPassanger TravelWithPassanger
        {
            get { return this.travelWith.EditValue as IVolarisPassanger; }
            set { this.travelWith.EditValue = value; }
        }

        #endregion



        #region Miembros de IVolarisPassangerCaptureFormView


        public void SetProfile(VolarisProfile profile)
        {
            _presenter.SetProfile(profile);
            profileAsignedPanel.Visible = true;
        }

        public void RemoveProfile()
        {
            _presenter.RemoveProfile();
            profileAsignedPanel.Visible = false;
        }

        #endregion

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {

            RemoveWarning(sender as TextEdit);
        }

        private void RemoveWarning(TextEdit textEdit)
        {

            if (textEdit != null)
            {
                this.passangerValidator.RemoveControlError(textEdit);
            }
        }

        private void lastNameTextBox_TextChanged(object sender, EventArgs e)
        {
            RemoveWarning(sender as TextEdit);
        }


    }
}
