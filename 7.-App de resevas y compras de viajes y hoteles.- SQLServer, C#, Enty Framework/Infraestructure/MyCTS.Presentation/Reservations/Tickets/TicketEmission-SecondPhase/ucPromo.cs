using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using MyCTS.Services.Contracts;

namespace MyCTS.Presentation
{
    public partial class ucPromo : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite la lectura y validación de las promociones aplicables a una tarjeta.
        /// Creación: 8/Agosto/11
        /// Modificación: *
        /// Cambio: *
        /// Solicito: *
        /// Autor: Ivan Martínez Guerrero
        /// </summary>

        private static string promoCode;
        public static string PromoCode
        {
            get { return promoCode; }
            set { promoCode = value; }
        }

        bool checkedRdoPromo = false;
        private int tabIndex = 1;


        public ucPromo()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);

            this.LastControlFocus = btnAccept;
        }

        private void ucPromo_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            int y = 180;
            string[] months;
            lblPromo.Text = ucFormPayment.Promo.Description;
            lblPromo.AutoSize = true;
            rdoPromoNot.Visible = false;
            string name = string.Empty;
            if (!string.IsNullOrEmpty(ucFormPayment.Promo.MonthsWithoutInterest))
            {
                months = ucFormPayment.Promo.MonthsWithoutInterest.Split(',');
                name = string.Concat("rdoMonth", months[0]);
                if (months.Length > 0)
                {
                    rdoPromoNot.Visible = true;

                    for (int i = 0; i < months.Length; i++)
                    {
                        RadioButton rdoControl = new RadioButton();
                        rdoControl.Name = string.Concat("rdoMonth", months[i]);
                        rdoControl.Text = string.Concat(months[i], " meses sin intereses");
                        rdoControl.Visible = true;
                        rdoControl.Location = new Point(150, y);
                        rdoControl.AutoSize = true;
                        rdoControl.KeyDown += new KeyEventHandler(BackEnterUserControl_KeyDown);
                        rdoControl.TabIndex = tabIndex;
                        this.Controls.Add(rdoControl);
                        tabIndex++;
                        y = y + 40;
                    }
                }
            }

            if (!string.IsNullOrEmpty(ucFormPayment.Promo.MonthsWithInterest))
            {
                months = ucFormPayment.Promo.MonthsWithInterest.Split(',');
                if (months.Length > 0)
                {
                    rdoPromoNot.Visible = true;

                    for (int i = 0; i < months.Length; i++)
                    {
                        RadioButton rdoControl = new RadioButton();
                        rdoControl.Name = string.Concat("rdoMonth", months[i]);
                        rdoControl.Text = string.Concat(months[i], " meses con intereses");
                        rdoControl.Visible = true;
                        rdoControl.Location = new Point(150, y);
                        rdoControl.AutoSize = true;
                        rdoControl.KeyDown += new KeyEventHandler(BackEnterUserControl_KeyDown);
                        rdoControl.TabIndex = tabIndex;
                        this.Controls.Add(rdoControl);
                        tabIndex++;
                        y = y + 40;
                    }
                }
            }

            rdoPromoNot.Location = new Point(150, y);
            rdoPromoNot.TabIndex = tabIndex;
            this.Controls.Add(rdoPromoNot);
            tabIndex++;
            btnAccept.TabIndex = tabIndex;
            AssignInitialControl();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string radioText = string.Empty;
            if (rdoPromoNot.Checked)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCCALCULATESERVICECHARGE);
            else
            {
                foreach (Control control in this.Controls)
                {
                    if (control is RadioButton)
                    {
                        RadioButton rdoButton = (RadioButton)control;
                        if (rdoButton.Checked)
                        {
                            checkedRdoPromo = true;
                            radioText = rdoButton.Text.Substring(0, 2);
                            radioText = radioText.Trim();
                            if (radioText.Length == 1)
                            {
                                radioText = string.Concat("0", radioText);
                            }
                        }
                    }
                }
            }

            if (checkedRdoPromo)
            {
                if (ValidateBussinesRules)
                {
                    if (!string.IsNullOrEmpty(radioText))
                    {
                        PromoCode = string.Concat("EP", radioText);
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCCALCULATESERVICECHARGE);
                    }
                    else
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCCALCULATESERVICECHARGE);
                }
            }
        }



        #region ====MethodsClass=====

        private bool ValidateBussinesRules
        {
            get
            {
                if (!rdoPromoNot.Checked && !checkedRdoPromo)
                {
                    MessageBox.Show("Dedes seleccionar una opción", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                return true;
            }
        }



        #endregion

        #region =====Events=====

        //Regresa al Control de Usuario Welcome o Valida Enter
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTICKETSEMISSIONINSTRUCTIONS);

            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }

        #endregion


        private void AssignInitialControl()
        {
            int index = 0;
            bool getFocus = false;
            btnAccept.TabIndex = tabIndex + 1;
            index = btnAccept.TabIndex;
            this.Controls.Add(rdoPromoNot);
            for (int i = 1; i <= index; i++)
            {
                foreach (Control ctrl in this.Controls)
                {


                    if (ctrl.TabIndex == i && ctrl.Enabled)
                    {
                        if (ctrl is RadioButton)
                        {
                            this.InitialControlFocus = ctrl;
                            ctrl.Focus();
                            getFocus = true;
                            break;
                        }
                    }

                }
                if (getFocus)
                    break;
            }

        }

    }
}
