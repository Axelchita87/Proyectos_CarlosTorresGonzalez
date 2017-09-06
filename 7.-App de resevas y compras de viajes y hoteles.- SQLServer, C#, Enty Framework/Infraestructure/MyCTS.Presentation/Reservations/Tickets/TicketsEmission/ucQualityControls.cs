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

namespace MyCTS.Presentation
{
    public partial class ucQualityControls : CustomUserControl
    {
        /// <summary>
        /// Descripción: User Control que permite ingresar valores por parte del agente
        ///              para la creacion de remarks aplicables para ICAAV e INTEGRA por corporativo
        ///              Pertenece al flujo de emisión de boleto de la aplicación.
        /// Creación:    Julio 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        /// 

        private static string ticketsjustifications;
        public static string TicketsJustifications
        {
            get { return ticketsjustifications; }
            set { ticketsjustifications = value; }
        }

        private string justificationsDescription;

        private static string businessunit;
        public static string BusinessUnit
        {
            get { return businessunit; }
            set { businessunit = value; }
        }
        private static string origin;
        public static string Origin
        {
            get { return origin; }
            set { origin = value; }
        }

        private static string icaavremarkcc;
        public static string icaavRemarkCC
        {
            get { return icaavremarkcc; }
            set { icaavremarkcc = value; }
        }

        private static string icaavremarkcd;
        public static string icaavRemarkCD
        {
            get { return icaavremarkcd; }
            set { icaavremarkcd = value; }
        }

        private static string icaavremarkce;
        public static string icaavRemarkCE
        {
            get { return icaavremarkce; }
            set { icaavremarkce = value; }
        }

        private static string icaavremarkcf;
        public static string icaavRemarkCF
        {
            get { return icaavremarkcf; }
            set { icaavremarkcf = value; }
        }

        private static string icaavremarkcg;
        public static string icaavRemarkCG
        {
            get { return icaavremarkcg; }
            set { icaavremarkcg = value; }
        }

        private static string icaavremarkch;
        public static string icaavRemarkCH
        {
            get { return icaavremarkch; }
            set { icaavremarkch = value; }
        }

        private static string c1;
        public static string C1
        {
            get { return c1; }
            set { c1 = value; }
        }

        private static string c2;
        public static string C2
        {
            get { return c2; }
            set { c2 = value; }
        }

        private static string c3;
        public static string C3
        {
            get { return c3; }
            set { c3 = value; }
        }

        private static string c4;
        public static string C4
        {
            get { return c4; }
            set { c4 = value; }
        }

        private static string c5;
        public static string C5
        {
            get { return c5; }
            set { c5 = value; }
        }

        private static string c6;
        public static string C6
        {
            get { return c6; }
            set { c6 = value; }
        }

        private static string c7;
        public static string C7
        {
            get { return c7; }
            set { c7 = value; }
        }

        private static string c8;
        public static string C8
        {
            get { return c8; }
            set { c8 = value; }
        }

        private static string c9;
        public static string C9
        {
            get { return c9; }
            set { c9 = value; }
        }

        private static string c10;
        public static string C10
        {
            get { return c10; }
            set { c10 = value; }
        }

        private static string c21;
        public static string C21
        {
            get { return c21; }
            set { c21 = value; }
        }

        private static string c22;
        public static string C22
        {
            get { return c22; }
            set { c22 = value; }
        }

        private static string c24;
        public static string C24
        {
            get { return c24; }
            set { c24 = value; }
        }

        private static string c29;
        public static string C29
        {
            get { return c29; }
            set { c29 = value; }
        }

        private static string c31;
        public static string C31
        {
            get { return c31; }
            set { c31 = value; }
        }

        private static string c32;
        public static string C32
        {
            get { return c32; }
            set { c32 = value; }
        }

        private static string c33;
        public static string C33
        {
            get { return c33; }
            set { c33 = value; }
        }

        private static string c34;
        public static string C34
        {
            get { return c34; }
            set { c34 = value; }
        }

        private static string c35;
        public static string C35
        {
            get { return c35; }
            set { c35 = value; }
        }

        private static string c36;
        public static string C36
        {
            get { return c36; }
            set { c36 = value; }
        }

        private static string c37;
        public static string C37
        {
            get { return c37; }
            set { c37 = value; }
        }

        private static string c38;
        public static string C38
        {
            get { return c38; }
            set { c38 = value; }
        }

        private static string c39;
        public static string C39
        {
            get { return c39; }
            set { c39 = value; }
        }

        private static string c40;
        public static string C40
        {
            get { return c40; }
            set { c40 = value; }
        }

        private static string c41;
        public static string C41
        {
            get { return c41; }
            set { c41 = value; }
        }

        private static string c42;
        public static string C42
        {
            get { return c42; }
            set { c42 = value; }
        }

        private string positionOneCF;
        private string positionTwoCF;
        private string positionThreeCF; 
        private string positionFourCF;

        private string positionOneCG;
        private string positionTwoCG;

        private bool isValid;
        List<CatValuesCorporativeQualityControls> qualityControlsList;

        public ucQualityControls()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtCostCenter;
            this.LastControlFocus = btnAccept;
        }


        /// <summary>
        /// Establecimiento de valores iniciales al cargar la mascarilla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucQualityControls_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            clearQualityControlsValues();
            lblTitle.Text = string.Format("{0} {1}",
                lblTitle.Text,
                activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1);
            cmbJustifications.SelectedIndex = 0;
            cmbBusinessUnit.SelectedIndex = 0;
            cmbSaleOrigin.SelectedIndex = 0;
            cmbCompany.SelectedIndex = 0;
            cmbCostCenterDHL.SelectedIndex = 0;
            cmbCustomer.SelectedIndex = 0;
            cmbAccount.SelectedIndex = 0;
            cmbActivity.SelectedIndex = 0;
            cmbSubactivity.SelectedIndex = 0;
            activeInactiveQualityControls();
            activeInactiveJustifications();
            loadBusinessUnit();
            loadDHLInformation();
            previousRemarkICAAVValues();
            focusAssign();
        }

        /// <summary>
        /// Ejecución de funciones de la mascarilla al presionar el boton
        /// Aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!isValidBusinessRules())
            {
                justificationsValues();
                BusinessUnitValues();
                remarkICAAVValues();
                remarkIntegraValues();
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCPRESENT_RECORD);
            }
            
        }

        #region===== MethodsClass =====

        /// <summary>
        /// Llenado de controles con valores de los remark contables eliminados 
        /// en pasos previos
        /// </summary>
        private void previousRemarkICAAVValues()
        {
            bool exitingItem = false;
            string prevValue = string.Empty;
            txtCostCenter.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C3)) ? ucRemoveRemarks.C3 : string.Empty;
            txtDepartment.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C2)) ? ucRemoveRemarks.C2 : string.Empty;
            txtDivision.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C1)) ? ucRemoveRemarks.C1 : string.Empty;
            txtArea.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C24)) ? ucRemoveRemarks.C24 : string.Empty;

            txtInvoicePosition.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C9)) ? ucRemoveRemarks.C9 : string.Empty;
            txtcontractPosition.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C31)) ? ucRemoveRemarks.C31 : string.Empty;
            txtNumber.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C4)) ? ucRemoveRemarks.C4 : string.Empty;
            txtSolicitator.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C32)) ? ucRemoveRemarks.C32 : string.Empty;

            txtAuthorization.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C5)) ? ucRemoveRemarks.C5 : string.Empty;
            txtWorkerNumber.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C6)) ? ucRemoveRemarks.C6 : string.Empty;
            txtSociety.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C7)) ? ucRemoveRemarks.C7 : string.Empty;
            txtManageCenter.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C8)) ? ucRemoveRemarks.C8 : string.Empty;

            positionOneCF = (!string.IsNullOrEmpty(ucRemoveRemarks.C33)) ? ucRemoveRemarks.C33 : string.Empty;
            positionTwoCF = (!string.IsNullOrEmpty(ucRemoveRemarks.C34)) ? ucRemoveRemarks.C34 : string.Empty;
            positionThreeCF = (!string.IsNullOrEmpty(ucRemoveRemarks.C35)) ? ucRemoveRemarks.C35 : string.Empty;
            positionFourCF = (!string.IsNullOrEmpty(ucRemoveRemarks.C36)) ? ucRemoveRemarks.C36 : string.Empty;

            positionOneCG = (!string.IsNullOrEmpty(ucRemoveRemarks.C37)) ? ucRemoveRemarks.C37 : string.Empty;
            positionTwoCG = (!string.IsNullOrEmpty(ucRemoveRemarks.C38)) ? ucRemoveRemarks.C38 : string.Empty;
            txtLegalEntity.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C39)) ? ucRemoveRemarks.C39 : string.Empty;
            txtOnlineBookingIndicator.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C40)) ? ucRemoveRemarks.C40 : string.Empty;

            txtFareIndicator.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C41)) ? ucRemoveRemarks.C41 : string.Empty;
            txtRealFare.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C42)) ? ucRemoveRemarks.C42 : string.Empty;

            if (!string.IsNullOrEmpty(positionOneCF))
            {
                for (int i = 1; i <= cmbCompany.Items.Count-1; i++)
                {
                    
                    if (((ListItem)cmbCompany.Items[i]).Value.Equals(positionOneCF))
                    {
                        exitingItem = true;
                        cmbCompany.SelectedIndex = i;
                        return;
                    }
                }
                if (!exitingItem)
                {
                    cmbCompany.Items.Add(positionOneCF);
                    cmbCompany.SelectedIndex = cmbCompany.Items.Count - 1;
                }

            }

            //
            exitingItem = false;
            if (!string.IsNullOrEmpty(positionTwoCF))
            {
                for (int i = 1; i <= cmbCostCenterDHL.Items.Count-1; i++)
                {
                    if (((ListItem)cmbCostCenterDHL.Items[i]).Value.Equals(positionTwoCF))
                    {
                        exitingItem = true;
                        cmbCostCenterDHL.SelectedIndex = i;
                        return;
                    }
                }
                if (!exitingItem)
                {
                    cmbCostCenterDHL.Items.Add(positionTwoCF);
                    cmbCostCenterDHL.SelectedIndex = cmbCostCenterDHL.Items.Count - 1;
                }

            }

            //
            exitingItem = false;
            if (!string.IsNullOrEmpty(positionThreeCF))
            {
                for (int i = 1; i <= cmbCustomer.Items.Count - 1; i++)
                {
                    if (((ListItem)cmbCustomer.Items[i]).Value.Equals(positionThreeCF))
                    {
                        exitingItem = true;
                        cmbCustomer.SelectedIndex = i;
                        return;
                    }
                }
                if (!exitingItem)
                {
                    cmbCustomer.Items.Add(positionThreeCF);
                    cmbCustomer.SelectedIndex = cmbCustomer.Items.Count - 1;
                }

            }

            //
            exitingItem = false;
            if (!string.IsNullOrEmpty(positionFourCF))
            {
                for (int i = 1; i <= cmbAccount.Items.Count - 1; i++)
                {
                    if (((ListItem)cmbAccount.Items[i]).Value.Equals(positionFourCF))
                    {
                        exitingItem = true;
                        cmbAccount.SelectedIndex = i;
                        return;
                    }
                }
                if (!exitingItem)
                {
                    cmbAccount.Items.Add(positionFourCF);
                    cmbAccount.SelectedIndex = cmbAccount.Items.Count - 1;
                }

            }

            //
            exitingItem = false;
            if (!string.IsNullOrEmpty(positionOneCG))
            {
                for (int i = 1; i <= cmbActivity.Items.Count - 1; i++)
                {
                    if (((ListItem)cmbActivity.Items[i]).Value.Equals(positionOneCG))
                    {
                        exitingItem = true;
                        cmbActivity.SelectedIndex = i;
                        return;
                    }
                }
                if (!exitingItem)
                {
                    cmbActivity.Items.Add(positionOneCG);
                    cmbActivity.SelectedIndex = cmbActivity.Items.Count - 1;
                }

            }

            //
            exitingItem = false;
            if (!string.IsNullOrEmpty(positionTwoCG))
            {
                for (int i = 1; i <= cmbSubactivity.Items.Count - 1; i++)
                {
                    if (((ListItem)cmbSubactivity.Items[i]).Value.Equals(positionTwoCG))
                    {
                        exitingItem = true;
                        cmbSubactivity.SelectedIndex = i;
                        return;
                    }
                }
                if (!exitingItem)
                {
                    cmbSubactivity.Items.Add(positionTwoCG);
                    cmbSubactivity.SelectedIndex = cmbSubactivity.Items.Count - 1;
                }

            }
        }

        /// <summary>
        /// Creación de remarks correspondientes a ICAAV
        /// </summary>
        private void remarkICAAVValues()
        {
            string remarkCC = Resources.TicketEmission.Constants.COMMANDS_5_CC_INDENT;
            string remarkCD = Resources.TicketEmission.Constants.COMMANDS_5_CD_INDENT;
            string remarkCE = Resources.TicketEmission.Constants.COMMANDS_5_CE_INDENT;
            string remarkCF = Resources.TicketEmission.Constants.COMMANDS_5_CF_INDENT;
            string remarkCG = Resources.TicketEmission.Constants.COMMANDS_5_CG_INDENT;
            string remarkCH = Resources.TicketEmission.Constants.COMMANDS_5_CH_INDENT;

            string positionOneCC = (!string.IsNullOrEmpty(txtCostCenter.Text)) ? txtCostCenter.Text : Resources.TicketEmission.Constants.Zero;
            string positionTwoCC = (!string.IsNullOrEmpty(txtDepartment.Text)) ? txtDepartment.Text : Resources.TicketEmission.Constants.Zero;
            string positionThreeCC = (!string.IsNullOrEmpty(txtDivision.Text)) ? txtDivision.Text : Resources.TicketEmission.Constants.Zero;
            string positionFourCC = (!string.IsNullOrEmpty(txtArea.Text)) ? txtArea.Text : Resources.TicketEmission.Constants.Zero;

            string positionOneCD = (!string.IsNullOrEmpty(txtInvoicePosition.Text)) ? txtInvoicePosition.Text : Resources.TicketEmission.Constants.Zero;
            string positionTwoCD = (!string.IsNullOrEmpty(txtcontractPosition.Text)) ? txtcontractPosition.Text : Resources.TicketEmission.Constants.Zero;
            string positionThreeCD = (!string.IsNullOrEmpty(txtNumber.Text)) ? txtNumber.Text : Resources.TicketEmission.Constants.Zero;
            string positionFourCD = (!string.IsNullOrEmpty(txtSolicitator.Text)) ? txtSolicitator.Text : Resources.TicketEmission.Constants.Zero;

            string positionOneCE = (!string.IsNullOrEmpty(txtAuthorization.Text)) ? txtAuthorization.Text : Resources.TicketEmission.Constants.Zero;
            string positionTwoCE = (!string.IsNullOrEmpty(txtWorkerNumber.Text)) ? txtWorkerNumber.Text : Resources.TicketEmission.Constants.Zero;
            string positionThreeCE = (!string.IsNullOrEmpty(txtSociety.Text)) ? txtSociety.Text : Resources.TicketEmission.Constants.Zero;
            string positionFourCE = (!string.IsNullOrEmpty(txtManageCenter.Text)) ? txtManageCenter.Text : Resources.TicketEmission.Constants.Zero;

            if(string.IsNullOrEmpty(positionOneCF))
                positionOneCF = (!cmbCompany.SelectedIndex.Equals(0)) ? cmbCompany.Text : Resources.TicketEmission.Constants.Zero;
            if (string.IsNullOrEmpty(positionTwoCF))
                positionTwoCF = (!cmbCostCenterDHL.SelectedIndex.Equals(0)) ? cmbCostCenterDHL.Text : Resources.TicketEmission.Constants.Zero;
            if (string.IsNullOrEmpty(positionThreeCF))
                positionThreeCF = (!cmbCustomer.SelectedIndex.Equals(0)) ? cmbCustomer.Text : Resources.TicketEmission.Constants.Zero;
            if (string.IsNullOrEmpty(positionFourCF))
                positionFourCF = (!cmbAccount.SelectedIndex.Equals(0)) ? cmbAccount.Text : Resources.TicketEmission.Constants.Zero;

            if (string.IsNullOrEmpty(positionOneCG))
                positionOneCG = (!cmbActivity.SelectedIndex.Equals(0)) ? cmbActivity.Text : Resources.TicketEmission.Constants.Zero;
            if (string.IsNullOrEmpty(positionTwoCG))
                positionTwoCG = (!cmbSubactivity.SelectedIndex.Equals(0)) ? cmbSubactivity.Text : Resources.TicketEmission.Constants.Zero;

            string positionThreeCG = (!string.IsNullOrEmpty(txtLegalEntity.Text)) ? txtLegalEntity.Text : Resources.TicketEmission.Constants.Zero;
            string positionFourCG = (!string.IsNullOrEmpty(txtOnlineBookingIndicator.Text)) ? txtOnlineBookingIndicator.Text : Resources.TicketEmission.Constants.Zero;

            string positionOneCH = (!string.IsNullOrEmpty(txtFareIndicator.Text)) ? txtFareIndicator.Text : Resources.TicketEmission.Constants.Zero;
            string positionTwoCH = (!string.IsNullOrEmpty(txtRealFare.Text)) ? txtRealFare.Text : Resources.TicketEmission.Constants.Zero;
            string positionThreeCH = Resources.TicketEmission.Constants.Zero;
            string positionFourCH = Resources.TicketEmission.Constants.Zero;

            if (positionOneCC.Equals(Resources.TicketEmission.Constants.Zero) &&
                positionTwoCC.Equals(Resources.TicketEmission.Constants.Zero) &&
                positionThreeCC.Equals(Resources.TicketEmission.Constants.Zero) &&
                positionTwoCC.Equals(Resources.TicketEmission.Constants.Zero))
            {
                icaavremarkcc = string.Empty;
            }
            else
            {
                icaavremarkcc = string.Concat(remarkCC,
                    positionOneCC,
                    Resources.TicketEmission.Constants.INDENT,
                    positionTwoCC,
                    Resources.TicketEmission.Constants.INDENT,
                    positionThreeCC,
                    Resources.TicketEmission.Constants.INDENT,
                    positionFourCC);
            }

            if (positionOneCD.Equals(Resources.TicketEmission.Constants.Zero) &&
                positionTwoCD.Equals(Resources.TicketEmission.Constants.Zero) &&
                positionThreeCD.Equals(Resources.TicketEmission.Constants.Zero) &&
                positionTwoCD.Equals(Resources.TicketEmission.Constants.Zero))
            {
                icaavremarkcd = string.Empty;
            }
            else
            {
                icaavremarkcd = string.Concat(remarkCD,
                    positionOneCD,
                    Resources.TicketEmission.Constants.INDENT,
                    positionTwoCD,
                    Resources.TicketEmission.Constants.INDENT,
                    positionThreeCD,
                    Resources.TicketEmission.Constants.INDENT,
                    positionFourCD);
            }

            if (positionOneCE.Equals(Resources.TicketEmission.Constants.Zero) &&
                positionTwoCE.Equals(Resources.TicketEmission.Constants.Zero) &&
                positionThreeCE.Equals(Resources.TicketEmission.Constants.Zero) &&
                positionTwoCE.Equals(Resources.TicketEmission.Constants.Zero))
            {
                icaavremarkce = string.Empty;
            }
            else
            {
                icaavremarkce = string.Concat(remarkCE,
                    positionOneCE,
                    Resources.TicketEmission.Constants.INDENT,
                    positionTwoCE,
                    Resources.TicketEmission.Constants.INDENT,
                    positionThreeCE,
                    Resources.TicketEmission.Constants.INDENT,
                    positionFourCE);
            }

            if (positionOneCF.Equals(Resources.TicketEmission.Constants.Zero) &&
                positionTwoCF.Equals(Resources.TicketEmission.Constants.Zero) &&
                positionThreeCF.Equals(Resources.TicketEmission.Constants.Zero) &&
                positionTwoCF.Equals(Resources.TicketEmission.Constants.Zero))
            {
                icaavremarkcf = string.Empty;
            }
            else
            {
                icaavremarkcf = string.Concat(remarkCF,
                    positionOneCF,
                    Resources.TicketEmission.Constants.INDENT,
                    positionTwoCF,
                    Resources.TicketEmission.Constants.INDENT,
                    positionThreeCF,
                    Resources.TicketEmission.Constants.INDENT,
                    positionFourCF);
            }

            if (positionOneCG.Equals(Resources.TicketEmission.Constants.Zero) &&
                positionTwoCG.Equals(Resources.TicketEmission.Constants.Zero) &&
                positionThreeCG.Equals(Resources.TicketEmission.Constants.Zero) &&
                positionTwoCG.Equals(Resources.TicketEmission.Constants.Zero))
            {
                icaavremarkcg = string.Empty;
            }
            else
            {
                icaavremarkcg = string.Concat(remarkCG,
                    positionOneCG,
                    Resources.TicketEmission.Constants.INDENT,
                    positionTwoCG,
                    Resources.TicketEmission.Constants.INDENT,
                    positionThreeCG,
                    Resources.TicketEmission.Constants.INDENT,
                    positionFourCG);
            }

            if (positionOneCH.Equals(Resources.TicketEmission.Constants.Zero) &&
                positionTwoCH.Equals(Resources.TicketEmission.Constants.Zero) &&
                positionThreeCH.Equals(Resources.TicketEmission.Constants.Zero) &&
                positionTwoCH.Equals(Resources.TicketEmission.Constants.Zero))
            {
                icaavremarkch = string.Empty;
            }
            else
            {
                icaavremarkch = string.Concat(remarkCH,
                    positionOneCH,
                    Resources.TicketEmission.Constants.INDENT,
                    positionTwoCH,
                    Resources.TicketEmission.Constants.INDENT,
                    positionThreeCH,
                    Resources.TicketEmission.Constants.INDENT,
                    positionFourCH);
            }

            
 
        }

        /// <summary>
        /// carga de valores aplicables para el corporativo DHL
        /// </summary>
        private void loadDHLInformation()
        {
            string CorporativeQC = activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1;
            if (CorporativeQC.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_DHL))
            {
               
                //
                List<CiaDHL> companyList = CiaDHLBL.GetCiaDHL();
                bindingSource1.DataSource = companyList;

                cmbCompany.DisplayMember = Resources.Constants.TEXT;
                cmbCompany.ValueMember = Resources.Constants.VALUE;

                foreach (CiaDHL companyItem in companyList)
                {
                    ListItem litem = new ListItem();
                    litem.Text = companyItem.Cia;
                    litem.Value = companyItem.Cia;
                    cmbCompany.Items.Add(litem);//Cambiar al listitem cuando se herede del item
                }

                //
                List<SiteDHL> siteList = SiteDHLBL.GetSiteDHL();
                bindingSource1.DataSource = siteList;

                cmbCostCenterDHL.DisplayMember = Resources.Constants.TEXT;
                cmbCostCenterDHL.ValueMember = Resources.Constants.VALUE;

                foreach (SiteDHL siteItem in siteList)
                {
                    ListItem litem = new ListItem();
                    litem.Text = siteItem.Site;
                    litem.Value = siteItem.Site;
                    cmbCostCenterDHL.Items.Add(litem);
                }

                //
                List<CteDHL> cteList = CteDHLBL.GetCteDHL();
                bindingSource1.DataSource = cteList;

                cmbCustomer.DisplayMember = Resources.Constants.TEXT;
                cmbCustomer.ValueMember = Resources.Constants.VALUE;

                foreach (CteDHL cteItem in cteList)
                {
                    ListItem litem = new ListItem();
                    litem.Text = cteItem.Cte;
                    litem.Value = cteItem.Cte;
                    cmbCustomer.Items.Add(litem);
                }

                //
                List<CtaDHL> ctaList = CtaDHLBL.GetCtaDHL();
                bindingSource1.DataSource = ctaList;

                cmbAccount.DisplayMember = Resources.Constants.TEXT;
                cmbAccount.ValueMember = Resources.Constants.VALUE;

                foreach (CtaDHL ctaItem in ctaList)
                {
                    ListItem litem = new ListItem();
                    litem.Text = ctaItem.Cta;
                    litem.Value = ctaItem.Cta;
                    cmbAccount.Items.Add(litem);
                }

                //
                List<ActDHL> actList = ActDHLBL.GetActDHL();
                bindingSource1.DataSource = actList;

                cmbActivity.DisplayMember = Resources.Constants.TEXT;
                cmbActivity.ValueMember = Resources.Constants.VALUE;

                foreach (ActDHL actItem in actList)
                {
                    ListItem litem = new ListItem();
                    litem.Text = actItem.Act;
                    litem.Value = actItem.Act;
                    cmbActivity.Items.Add(litem);
                }

                //
                List<SubDHL> subList = SubDHLBL.GetSubDHL();
                bindingSource1.DataSource = subList;

                cmbSubactivity.DisplayMember = Resources.Constants.TEXT;
                cmbSubactivity.ValueMember = Resources.Constants.VALUE;

                foreach (SubDHL subItem in subList)
                {
                    ListItem litem = new ListItem();
                    litem.Text = subItem.Sub;
                    litem.Value = subItem.Sub;
                    cmbSubactivity.Items.Add(litem);
                }
            }
        }

        /// <summary>
        /// Borrado de valores anteriores de variables correspondientes
        /// a la creacion de remarks ICAAV e INTEGRA
        /// </summary>
        private void clearQualityControlsValues()
        {
            c1 = string.Empty;
            c2 = string.Empty;
            c3 = string.Empty;
            c4 = string.Empty;
            c5 = string.Empty;
            c6 = string.Empty;
            c7 = string.Empty;
            c8 = string.Empty;
            c9 = string.Empty;
            c10 = string.Empty;
            c21 = string.Empty;
            c22 = string.Empty;
            c24 = string.Empty;
            c29 = string.Empty;
            c31 = string.Empty;
            c32 = string.Empty;
            c33 = string.Empty;
            c34 = string.Empty;
            c35 = string.Empty;
            c36 = string.Empty;
            c37 = string.Empty;
            c38 = string.Empty;
            c39 = string.Empty;
            c40 = string.Empty;
            c41 = string.Empty;
            c42 = string.Empty;

            icaavremarkcc = string.Empty;
            icaavremarkcd = string.Empty;
            icaavremarkce = string.Empty;
            icaavremarkcf = string.Empty;
            icaavremarkcg = string.Empty;
            icaavremarkch = string.Empty;

            
            
        }

        /// <summary>
        /// Activación de QualityControls por corporativo de forma opcional u obligatoria
        /// </summary>
        private void activeInactiveQualityControls()
        {
            
            qualityControlsList = CatValuesCorporativeQualityControlsBL.GetValuesQualityControls(ucFirstValidations.DK, Login.Firm, Login.PCC);
            c29 = qualityControlsList[0].C29;
            c29 = c29.Replace("@", "¥");
            c29 = c29.ToUpper();

            if (qualityControlsList[0].C1.Equals(Resources.TicketEmission.Constants.INACTIVE))
            {
                txtDivision.Enabled = false;
                txtDivision.BackColor = SystemColors.Control;
            }
            if (qualityControlsList[0].C2.Equals(Resources.TicketEmission.Constants.INACTIVE))
            {
                txtDepartment.BackColor = SystemColors.Control;
                txtDepartment.Enabled = false;
            }
            if (qualityControlsList[0].C3.Equals(Resources.TicketEmission.Constants.INACTIVE))
            {
                txtCostCenter.BackColor = SystemColors.Control;
                txtCostCenter.Enabled = false;
            }
            if (qualityControlsList[0].C4.Equals(Resources.TicketEmission.Constants.INACTIVE))
            {
                txtNumber.Enabled = false;
                txtNumber.BackColor = SystemColors.Control;
            }
            if (qualityControlsList[0].C5.Equals(Resources.TicketEmission.Constants.INACTIVE))
            {
                txtAuthorization.Enabled = false;
                txtAuthorization.BackColor = SystemColors.Control;
            }
            if (qualityControlsList[0].C6.Equals(Resources.TicketEmission.Constants.INACTIVE))
            {
                txtWorkerNumber.Enabled = false;
                txtWorkerNumber.BackColor = SystemColors.Control;
            }
            if (qualityControlsList[0].C7.Equals(Resources.TicketEmission.Constants.INACTIVE))
            {
                txtSociety.Enabled = false;
                txtSociety.BackColor = SystemColors.Control;
            }
            if (qualityControlsList[0].C8.Equals(Resources.TicketEmission.Constants.INACTIVE))
            {
                txtManageCenter.Enabled = false;
                txtManageCenter.BackColor = SystemColors.Control;
            }
            if (qualityControlsList[0].C9.Equals(Resources.TicketEmission.Constants.INACTIVE))
            {
                txtInvoicePosition.Enabled = false;
                txtInvoicePosition.BackColor = SystemColors.Control;
            }
            if (qualityControlsList[0].C10.Equals(Resources.TicketEmission.Constants.INACTIVE))
            {
                cmbJustifications.Enabled = false;
            }
            if (qualityControlsList[0].C24.Equals(Resources.TicketEmission.Constants.INACTIVE))
            {
                txtArea.Enabled = false;
                txtArea.BackColor = SystemColors.Control;
            }
            if (qualityControlsList[0].C21.Equals(Resources.TicketEmission.Constants.INACTIVE))
            {
                cmbSaleOrigin.Enabled = false;
            }
            if (qualityControlsList[0].C31.Equals(Resources.TicketEmission.Constants.INACTIVE))
            {
                txtcontractPosition.Enabled = false;
                txtcontractPosition.BackColor = SystemColors.Control;
            }
            if (qualityControlsList[0].C32.Equals(Resources.TicketEmission.Constants.INACTIVE))
            {
                txtSolicitator.Enabled = false;
                txtSolicitator.BackColor = SystemColors.Control;
            }
            if (qualityControlsList[0].C33.Equals(Resources.TicketEmission.Constants.INACTIVE))
            {
                cmbCompany.Enabled = false;
            }
            if (qualityControlsList[0].C34.Equals(Resources.TicketEmission.Constants.INACTIVE))
            {
                cmbCostCenterDHL.Enabled = false;
            }
            if (qualityControlsList[0].C35.Equals(Resources.TicketEmission.Constants.INACTIVE))
            {
                cmbCustomer.Enabled = false;
            }
            if (qualityControlsList[0].C36.Equals(Resources.TicketEmission.Constants.INACTIVE))
            {
                cmbAccount.Enabled = false;
            }
            if (qualityControlsList[0].C37.Equals(Resources.TicketEmission.Constants.INACTIVE))
            {
                cmbActivity.Enabled = false;
            }
            if (qualityControlsList[0].C38.Equals(Resources.TicketEmission.Constants.INACTIVE))
            {
                cmbSubactivity.Enabled = false;
            }
            if (qualityControlsList[0].C39.Equals(Resources.TicketEmission.Constants.INACTIVE))
            {
                txtLegalEntity.Enabled = false;
                txtLegalEntity.BackColor = SystemColors.Control;
            }
            if (qualityControlsList[0].C40.Equals(Resources.TicketEmission.Constants.INACTIVE))
            {
                txtOnlineBookingIndicator.Enabled = false;
                txtOnlineBookingIndicator.BackColor = SystemColors.Control;
            }
            if (qualityControlsList[0].C41.Equals(Resources.TicketEmission.Constants.INACTIVE))
            {
                txtFareIndicator.Enabled = false;
                txtFareIndicator.BackColor = SystemColors.Control;
            }
            if (qualityControlsList[0].C42.Equals(Resources.TicketEmission.Constants.INACTIVE))
            {
                txtRealFare.Enabled = false;
                txtRealFare.BackColor = SystemColors.Control;
            }



            if (qualityControlsList[0].C1.Equals(Resources.TicketEmission.Constants.ACTIVE_OPTIONAL))
            {
                lblDivision.ForeColor = Color.DarkCyan;
            }
            if (qualityControlsList[0].C2.Equals(Resources.TicketEmission.Constants.ACTIVE_OPTIONAL))
            {
                lblDepartment.ForeColor = Color.DarkCyan;
            }
            if (qualityControlsList[0].C3.Equals(Resources.TicketEmission.Constants.ACTIVE_OPTIONAL))
            {
                lblCenterCosts.ForeColor = Color.DarkCyan; 
            }
            if (qualityControlsList[0].C4.Equals(Resources.TicketEmission.Constants.ACTIVE_OPTIONAL))
            {
                lblNumber.ForeColor = Color.DarkCyan;
            }
            if (qualityControlsList[0].C5.Equals(Resources.TicketEmission.Constants.ACTIVE_OPTIONAL))
            {
                lblAuthorization.ForeColor = Color.DarkCyan;
            }
            if (qualityControlsList[0].C6.Equals(Resources.TicketEmission.Constants.ACTIVE_OPTIONAL))
            {
                lblWorkerNumber.ForeColor = Color.DarkCyan;
            }
            if (qualityControlsList[0].C7.Equals(Resources.TicketEmission.Constants.ACTIVE_OPTIONAL))
            {
                lblSociety.ForeColor = Color.DarkCyan;
            }
            if (qualityControlsList[0].C8.Equals(Resources.TicketEmission.Constants.ACTIVE_OPTIONAL))
            {
                lblManagerCenter.ForeColor = Color.DarkCyan; 
            }
            if (qualityControlsList[0].C9.Equals(Resources.TicketEmission.Constants.ACTIVE_OPTIONAL))
            {
                lblInvoicePosition.ForeColor = Color.DarkCyan; 
            }
            if (qualityControlsList[0].C10.Equals(Resources.TicketEmission.Constants.ACTIVE_OPTIONAL))
            {
                lblJustifications.ForeColor = Color.DarkCyan; 
            }
            if (qualityControlsList[0].C24.Equals(Resources.TicketEmission.Constants.ACTIVE_OPTIONAL))
            {
                lblArea.ForeColor = Color.DarkCyan;
            }
            if (qualityControlsList[0].C31.Equals(Resources.TicketEmission.Constants.ACTIVE_OPTIONAL))
            {
                lblcontractPosition.ForeColor = Color.DarkCyan;
            }
            if (qualityControlsList[0].C32.Equals(Resources.TicketEmission.Constants.ACTIVE_OPTIONAL))
            {
                lblSolicitator.ForeColor = Color.DarkCyan;
            }
            if (qualityControlsList[0].C33.Equals(Resources.TicketEmission.Constants.ACTIVE_OPTIONAL))
            {
                lblCompany.ForeColor = Color.DarkCyan;
            }
            if (qualityControlsList[0].C34.Equals(Resources.TicketEmission.Constants.ACTIVE_OPTIONAL))
            {
                lblCostCenterDHL.ForeColor = Color.DarkCyan;
            }
            if (qualityControlsList[0].C35.Equals(Resources.TicketEmission.Constants.ACTIVE_OPTIONAL))
            {
                lblCustomer.ForeColor = Color.DarkCyan;
            }
            if (qualityControlsList[0].C36.Equals(Resources.TicketEmission.Constants.ACTIVE_OPTIONAL))
            {
                lblAccount.ForeColor = Color.DarkCyan;
            }
            if (qualityControlsList[0].C37.Equals(Resources.TicketEmission.Constants.ACTIVE_OPTIONAL))
            {
                lblActivity.ForeColor = Color.DarkCyan;
            }
            if (qualityControlsList[0].C38.Equals(Resources.TicketEmission.Constants.ACTIVE_OPTIONAL))
            {
                lblSubactivity.ForeColor = Color.DarkCyan;
            }
            if (qualityControlsList[0].C39.Equals(Resources.TicketEmission.Constants.ACTIVE_OPTIONAL))
            {
                lblLegalEntity.ForeColor = Color.DarkCyan;
            }
            if (qualityControlsList[0].C40.Equals(Resources.TicketEmission.Constants.ACTIVE_OPTIONAL))
            {
                lblOnlineBookingIndicator.ForeColor = Color.DarkCyan;
            }
            if (qualityControlsList[0].C41.Equals(Resources.TicketEmission.Constants.ACTIVE_OPTIONAL))
            {
                lblFareIndicator.ForeColor = Color.DarkCyan;
            }
            if (qualityControlsList[0].C42.Equals(Resources.TicketEmission.Constants.ACTIVE_OPTIONAL))
            {
                lblRealFare.ForeColor = Color.DarkCyan;
            }
        }


        /// <summary>
        /// Reglas de negocio aplicables para esta mascarilla
        /// </summary>
        /// <returns></returns>
        private bool isValidBusinessRules()
        {
            isValid = true;
            if (qualityControlsList[0].C1.Equals(Resources.TicketEmission.Constants.ACTIVE_STRONG) && string.IsNullOrEmpty(txtDivision.Text))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.INGRESAR_CODIGO_DIVISION, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDivision.Focus();
            }
            else if (qualityControlsList[0].C2.Equals(Resources.TicketEmission.Constants.ACTIVE_STRONG) && string.IsNullOrEmpty(txtDepartment.Text))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.INGRESAR_CODIGO_DEPARTAMENTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDepartment.Focus();
            }
            else if (qualityControlsList[0].C3.Equals(Resources.TicketEmission.Constants.ACTIVE_STRONG) && string.IsNullOrEmpty(txtCostCenter.Text))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.INGRESAR_CODIGO_CENTRO_COSTOS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCostCenter.Focus();
            }
            else if (qualityControlsList[0].C4.Equals(Resources.TicketEmission.Constants.ACTIVE_STRONG) && string.IsNullOrEmpty(txtNumber.Text))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.INGRESAR_CODIGO_FOLIO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNumber.Focus();
            }
            else if (qualityControlsList[0].C5.Equals(Resources.TicketEmission.Constants.ACTIVE_STRONG) && string.IsNullOrEmpty(txtAuthorization.Text))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.INGRESAR_CODIGO_AUTORIZACION, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAuthorization.Focus();
            }
            else if (qualityControlsList[0].C6.Equals(Resources.TicketEmission.Constants.ACTIVE_STRONG) && string.IsNullOrEmpty(txtWorkerNumber.Text))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.INGRESAR_NUM_EMPLEADO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtWorkerNumber.Focus();
            }
            else if (qualityControlsList[0].C7.Equals(Resources.TicketEmission.Constants.ACTIVE_STRONG) && string.IsNullOrEmpty(txtSociety.Text))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.INGRESAR_CODIGO_SOCIEDAD, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSociety.Focus();
            }
            else if (qualityControlsList[0].C8.Equals(Resources.TicketEmission.Constants.ACTIVE_STRONG) && string.IsNullOrEmpty(txtManageCenter.Text))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.INGRESAR_COD_CENTRO_GESTOR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtManageCenter.Focus();
            }
            else if (qualityControlsList[0].C9.Equals(Resources.TicketEmission.Constants.ACTIVE_STRONG) && string.IsNullOrEmpty(txtInvoicePosition.Text))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.INGRESAR_COD_POS_PRESUPUESTAL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtInvoicePosition.Focus();
            }  
            else if ((cmbJustifications.Enabled) &&
                ((string.IsNullOrEmpty(cmbJustifications.Text)) ||
                (cmbJustifications.SelectedIndex.Equals(0))))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.INGRESAR_JUSTIFICACION_ADECUADA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbJustifications.Focus();
            }
            else if ((cmbBusinessUnit.Enabled) &&
                (cmbBusinessUnit.SelectedIndex.Equals(0)))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.INGRESAR_UNIDAD_NEGOCIO_REQ, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbBusinessUnit.Focus();
            }
            else if ((cmbSaleOrigin.Enabled) &&
                (cmbSaleOrigin.SelectedIndex.Equals(0)))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.SELECCIONAR_ORIGEN_VENTA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbSaleOrigin.Focus();
            }
            else if (qualityControlsList[0].C24.Equals(Resources.TicketEmission.Constants.ACTIVE_STRONG) && string.IsNullOrEmpty(txtArea.Text))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.INGRESAR_COD_AREA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtArea.Focus();
            }
            else if (txtcontractPosition.Visible && qualityControlsList[0].C31.Equals(Resources.TicketEmission.Constants.ACTIVE_STRONG) && string.IsNullOrEmpty(txtcontractPosition.Text))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.DEBES_INGRESAR_COD_POS_CONTRATO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtcontractPosition.Focus();
            }
            else if (txtSolicitator.Visible && qualityControlsList[0].C32.Equals(Resources.TicketEmission.Constants.ACTIVE_STRONG) && string.IsNullOrEmpty(txtSolicitator.Text))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.DEBES_INGRESAR_COD_SOLICITANTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSolicitator.Focus();
            }
            else if ((cmbCompany.Enabled) &&
                (cmbCompany.SelectedIndex.Equals(0)))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.SELEC_COD_COMPANY_REQ, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbCompany.Focus();
            }
            else if ((cmbCostCenterDHL.Enabled) &&
                (cmbCostCenterDHL.SelectedIndex.Equals(0)))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.SELEC_COD_COSTCENTER_REQ, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbCostCenterDHL.Focus();
            }
            else if ((cmbCustomer.Enabled) &&
                (cmbCustomer.SelectedIndex.Equals(0)))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.SELEC_COD_CUSTOMER_REQ, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbCustomer.Focus();
            }
            else if ((cmbAccount.Enabled) &&
                (cmbAccount.SelectedIndex.Equals(0)))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.SELEC_COD_ACCOUNT_REQ, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbAccount.Focus();
            }
            else if ((cmbActivity.Enabled) &&
                   (cmbActivity.SelectedIndex.Equals(0)))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.SELEC_COD_ACTIVITY_REQ, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbActivity.Focus();
            }
            else if ((cmbSubactivity.Enabled) &&
                   (cmbSubactivity.SelectedIndex.Equals(0)))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.SELEC_COD_SUBACTIVITY_REQ, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbSubactivity.Focus();
            }
            else if (txtLegalEntity.Visible && qualityControlsList[0].C39.Equals(Resources.TicketEmission.Constants.ACTIVE_STRONG) && string.IsNullOrEmpty(txtLegalEntity.Text))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.INGRESA_COD_LEGAL_ENTITY, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLegalEntity.Focus();
            }
            else if (txtOnlineBookingIndicator.Visible && qualityControlsList[0].C40.Equals(Resources.TicketEmission.Constants.ACTIVE_STRONG) && string.IsNullOrEmpty(txtOnlineBookingIndicator.Text))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.INGRESA_COD_ONLINE_B_INDICATOR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOnlineBookingIndicator.Focus();
            }
            else if (txtFareIndicator.Visible && qualityControlsList[0].C41.Equals(Resources.TicketEmission.Constants.ACTIVE_STRONG) && string.IsNullOrEmpty(txtFareIndicator.Text))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.INGRESA_COD_FARE_INDICATOR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFareIndicator.Focus();
            }
            else if (txtRealFare.Visible && qualityControlsList[0].C42.Equals(Resources.TicketEmission.Constants.ACTIVE_STRONG) && string.IsNullOrEmpty(txtRealFare.Text))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.INGRESA_COD_TARIFA_REAL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRealFare.Focus();
            }
            else
            {
                isValid = false;
            }
            return isValid;
            
            
        }

        /// <summary>
        /// Carga de valores en variables estaticas para la creacion 
        /// de remarks INTEGRA
        /// </summary>
        private void remarkIntegraValues()
        {
            if (!string.IsNullOrEmpty(txtDivision.Text))
                c1 = txtDivision.Text;
            else
                c1 = string.Empty;

            if (!string.IsNullOrEmpty(txtDepartment.Text))
                c2 = txtDepartment.Text;
            else
                c2 = string.Empty;

            if (!string.IsNullOrEmpty(txtCostCenter.Text))
                c3 = txtCostCenter.Text;
            else
                c3 = string.Empty;

            if (!string.IsNullOrEmpty(txtNumber.Text))
                c4 = txtNumber.Text;
            else
                c4 = string.Empty;

            if (!string.IsNullOrEmpty(txtAuthorization.Text))
                c5 = txtAuthorization.Text;
            else
                c5 = string.Empty;

            if (!string.IsNullOrEmpty(txtWorkerNumber.Text))
                c6 = txtWorkerNumber.Text;
            else
                c6 = string.Empty;

            if (!string.IsNullOrEmpty(txtSociety.Text))
                c7 = txtSociety.Text;
            else
                c7= string.Empty;

            if (!string.IsNullOrEmpty(txtManageCenter.Text))
                c8 = txtManageCenter.Text;
            else
                c8 = string.Empty;

            if (!string.IsNullOrEmpty(txtInvoicePosition.Text))
                c9 = txtInvoicePosition.Text;
            else
                c9 = string.Empty;

            c10 = justificationsDescription;


            if (!string.IsNullOrEmpty(txtArea.Text))
                c24 = txtArea.Text;
            else
                c24 = string.Empty;

            if (!string.IsNullOrEmpty(txtcontractPosition.Text))
                c31 = txtcontractPosition.Text;
            else
                c31 = string.Empty;

            if (!string.IsNullOrEmpty(txtSolicitator.Text))
                c32 = txtSolicitator.Text;
            else
                c32 = string.Empty;

            if (cmbCompany.Enabled)
                c33 = cmbCompany.Text;
            else
                c33 = string.Empty;

            if (cmbCostCenterDHL.Enabled)
                c34 = cmbCostCenterDHL.Text;
            else
                c34 = string.Empty;

            if (cmbCustomer.Enabled)
                c35 = cmbCustomer.Text;
            else
                c35 = string.Empty;

            if (cmbAccount.Enabled)
                c36 = cmbAccount.Text;
            else
                c36 = string.Empty;

            if (cmbActivity.Enabled)
                c37 = cmbActivity.Text;
            else
                c37 = string.Empty;

            if (cmbSubactivity.Enabled)
                c38 = cmbSubactivity.Text;
            else
                c38 = string.Empty;

            if (!string.IsNullOrEmpty(txtLegalEntity.Text))
                c39 = txtLegalEntity.Text;
            else
                c39 = string.Empty;

            if (!string.IsNullOrEmpty(txtOnlineBookingIndicator.Text))
                c40 = txtOnlineBookingIndicator.Text;
            else
                c40 = string.Empty;

            if (!string.IsNullOrEmpty(txtFareIndicator.Text))
                c41 = txtFareIndicator.Text;
            else
                c41 = string.Empty;

            if (!string.IsNullOrEmpty(txtRealFare.Text))
                c42 = txtRealFare.Text;
            else
                c42 = string.Empty;

        }

        /// <summary>
        /// Asignación de foco al cargar la mascarilla dependiendo
        /// de que control este habilitado y quede como primer elemento
        /// </summary>
        private void focusAssign()
        {
            if (txtCostCenter.Enabled)
            {
                this.InitialControlFocus = txtCostCenter;
                txtCostCenter.Focus();
            }
            else if (txtDivision.Enabled)
            {
                this.InitialControlFocus = txtDivision;
                txtDivision.Focus();
            }
            else if (txtDepartment.Enabled)
            {
                this.InitialControlFocus = txtDepartment;
                txtDepartment.Focus();
            }
            else if (txtArea.Enabled)
            {
                this.InitialControlFocus = txtArea;
                txtArea.Focus();
            }
            else if (txtNumber.Enabled)
            {
                this.InitialControlFocus = txtNumber;
                txtNumber.Focus();
            }
            else if (txtAuthorization.Enabled)
            {
                this.InitialControlFocus = txtAuthorization;
                txtAuthorization.Focus();
            }
            else if (txtWorkerNumber.Enabled)
            {
                this.InitialControlFocus = txtWorkerNumber;
                txtWorkerNumber.Focus();
            }
            else if (txtSociety.Enabled)
            {
                this.InitialControlFocus = txtSociety;
                txtSociety.Focus();
            }
            else if (txtManageCenter.Enabled)
            {
                this.InitialControlFocus = txtManageCenter;
                txtManageCenter.Focus();
            }
            else if (txtInvoicePosition.Enabled)
            {
                this.InitialControlFocus = txtInvoicePosition;
                txtInvoicePosition.Focus();
            }
            else if (cmbJustifications.Enabled)
            {
                this.InitialControlFocus = cmbJustifications;
                cmbJustifications.Focus();
            }
            else if (cmbSaleOrigin.Enabled)
            {
                this.InitialControlFocus = cmbSaleOrigin;
                cmbSaleOrigin.Focus();
            }
        }

        #region===== Justifications =====

        /// <summary>
        /// Armado de remark de justificaciones de tarifa
        /// </summary>
        private void justificationsValues()
        {
            string send = string.Empty;
            string optionSelected = cmbJustifications.Text.Substring(0, 2);
            string Corporative = activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1;
            if (cmbJustifications.Enabled)
            {
                if (Corporative.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_DANONE))
                {
                    send = string.Concat(Resources.TicketEmission.Constants.COMMANDS_5_S_AST_FJ,
                        optionSelected);
                    if (chkClass.Checked)
                    {
                            send = string.Concat(send, 
                            Resources.TicketEmission.Constants.COMMANDS_ENDITEM_5_S_AST_TT_INDENT_B);
                            ticketsjustifications = send;
                    }
                    else
                    {
                        send = string.Concat(send, 
                            Resources.TicketEmission.Constants.COMMANDS_ENDITEM_5_S_AST_TT_INDENT_C);
                        ticketsjustifications = send;
                    }
                }
                else if (Corporative.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_RADIUS))
                {
                    send = Resources.TicketEmission.Constants.COMMANDS_5_U99_INDENT_RC_SLASH + optionSelected;
                    ticketsjustifications = send;
                }
                else 
                {
                    send = Resources.TicketEmission.Constants.COMMANDS_5_S_AST_FJ + optionSelected;
                    ticketsjustifications = send;
                }
            
                justificationsDescription = cmbJustifications.Text.Substring(5, cmbJustifications.Text.Length - 5);
            }
            else
            {
                ticketsjustifications = string.Empty;
                justificationsDescription = string.Empty;
            }
        }

        /// <summary>
        /// Carga de catalogo de justificaciones de tarifa dependiendo del corporativo
        /// </summary>
        private void activeInactiveJustifications()
        {
            string CorporativeQC = activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1;
            string FareSoldJustification = activeStepsCorporativeQC.CorporativeQualityControls[0].FareJustification;

            if (FareSoldJustification.Equals(Resources.TicketEmission.Constants.ACTIVE))
            {
                if (activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_DANONE))
                {
                    chkClass.Visible = true;
                }
                if (CorporativeQC.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_DANONE) || CorporativeQC.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_RADIUS))
                {
                    LoadJustifications();
                }
                else
                {
                    if (!ucComparingFares.sameFare)
                    {
                        cmbJustifications.Enabled = true;
                        if (CorporativeQC.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_DHL))
                        {
                            LoadJustifications();
                        }
                        else
                        {
                            LoadJustificationsCTS();
                        }
                    }
                    else
                    {
                        cmbJustifications.Enabled = false;
                    }
                }

            }
            else
            {
                cmbJustifications.Enabled = false;
            }
        }

        /// <summary>
        /// carga de catalogo de justificaciones de tarifa aplicable a cualquier
        /// corporativo que cuente con sus propias justificaciones
        /// </summary>
        private void LoadJustifications()
        {
            List<DKTemp> Justifications = DKTempBL.GetDKTemp(ucFirstValidations.DK,false);
            bindingSource1.DataSource = Justifications;

            cmbJustifications.DisplayMember = Resources.Constants.TEXT;
            cmbJustifications.ValueMember = Resources.Constants.VALUE;

            foreach (DKTemp justificationsItem in Justifications)
            {
                ListItem litem = new ListItem();
                litem.Text = string.Format("{0} - {1}",
                    justificationsItem.Code,
                    justificationsItem.Description);
                litem.Value = justificationsItem.Description;
                cmbJustifications.Items.Add(litem);
            }
            
        }

        /// <summary>
        /// Carga de justificaciones de tarifa de CTS aplicables a todo corporativo
        /// que no cuente con sus propias justificaciones
        /// </summary>
        private void LoadJustificationsCTS()
        {
            List<DKTemp> Justifications = DKTempBL.GetDKTemp(Resources.TicketEmission.Constants.DK_CTS_API_100, false);
            bindingSource1.DataSource = Justifications;

            cmbJustifications.DisplayMember = Resources.Constants.TEXT;
            cmbJustifications.ValueMember = Resources.Constants.VALUE;

            foreach (DKTemp justificationsItem in Justifications)
            {
                ListItem litem = new ListItem();
                litem.Text = string.Format("{0} - {1}",
                    justificationsItem.Code,
                    justificationsItem.Description);
                litem.Value = justificationsItem.Description;
                cmbJustifications.Items.Add(litem);
            }
        }
        #endregion //End Justifications


        #region===== CostCenter =====       

        #region===== lbCostCenter Events=====

        //KeyDown lbCostCenter
        private void lbCostCenter_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = (TextBox)txtCostCenter;
            ListBox ListBox = (ListBox)sender;

            if (e.KeyCode == Keys.Enter)
            {
                ListItem li = (ListItem)ListBox.SelectedItem;
                txt.Text = li.Value;
                lbCostCenter.Visible = false;
                txt.Focus();
            }

        }

        //MouseClick LbCostCenter
        private void ListBox_MouseClick(object sender, MouseEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            TextBox txt = (TextBox)txtCostCenter;

            ListItem li = (ListItem)listBox.SelectedItem;
            txt.Text = li.Value;
            lbCostCenter.Visible = false;
            txt.Focus();
        }
        #endregion //End lbCostCenter Events

        #endregion//End CostCenter


        #region===== BusinessUnit =====

        /// <summary>
        /// Carga de catalogo de unidades operativas
        /// </summary>
        private void loadBusinessUnit()
        {
            CatBusinessUnitsBL.GetBusinessUnits();
            List<CatBusinessUnits> BusinessUnits = CatBusinessUnitsBL.GetBusinessUnits();
            bindingSource2.DataSource = BusinessUnits;
            cmbBusinessUnit.DisplayMember = Resources.Constants.TEXT;
            cmbBusinessUnit.ValueMember = Resources.Constants.VALUE;

            foreach (CatBusinessUnits businnesUnitItem in BusinessUnits)
            {
                ListItem litem = new ListItem();
                litem.Text = businnesUnitItem.Name;
                litem.Value = businnesUnitItem.IDBusinessUnits;
                cmbBusinessUnit.Items.Add(litem);
            }
        }

        /// <summary>
        /// Armado de comando de unidades operativas para ICAAV e INTEGRA
        /// </summary>
        private void BusinessUnitValues()
        {
            string remarkOrigin = string.Empty;
            string send = Resources.TicketEmission.Constants.COMMANDS_FIVE_DOT_OV_INDENT;
            string IDBusinessUnit = (string.IsNullOrEmpty(cmbBusinessUnit.Text)) ? string.Empty : ((ListItem)cmbBusinessUnit.SelectedItem).Value;
            BusinessUnit = string.Empty;
            origin = string.Empty;
            BusinessUnit = Resources.TicketEmission.Constants.COMMANDS_FIVE_DOT_UN_INDENT + IDBusinessUnit; //+


            if (cmbSaleOrigin.SelectedIndex.Equals(1))
            {
                send = string.Concat(send, Resources.TicketEmission.Constants.COMMANDS_POLEM);
                remarkOrigin = Resources.TicketEmission.Constants.COMMANDS_POLEM;
            }
            if (cmbSaleOrigin.SelectedIndex.Equals(2))
            {
                send = string.Concat(send, Resources.TicketEmission.Constants.COMMANDS_BOLETIN);
                remarkOrigin = Resources.TicketEmission.Constants.COMMANDS_BOLETIN;
            }
            if (cmbSaleOrigin.SelectedIndex.Equals(3))
            {
                send = string.Concat(send, Resources.TicketEmission.Constants.COMMANDS_CORREO);
                remarkOrigin = Resources.TicketEmission.Constants.COMMANDS_CORREO;
            }
            if (cmbSaleOrigin.SelectedIndex.Equals(4))
            {
                send = string.Concat(send, Resources.TicketEmission.Constants.COMMANDS_RECO);
                remarkOrigin = Resources.TicketEmission.Constants.COMMANDS_RECO;
            }
            if (cmbSaleOrigin.SelectedIndex.Equals(5))
            {
                send = string.Concat(send, Resources.TicketEmission.Constants.COMMANDS_RH);
                remarkOrigin = Resources.TicketEmission.Constants.COMMANDS_RH;
            }
            origin = send;
            c21 = remarkOrigin;
            c22 = IDBusinessUnit;

        }
        #endregion//End BusinessUnit


        #endregion //End MethodsClass


        #region ====== Change Focus CostCenter=======

        //Evento txtCostCenter_TextChanged
        private void txtCostCenter_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            Common.SetListCostCenter(txt, lbCostCenter);
            //SetListCostCenter(txt);

        }

        //Evento txtDivision_TextChanged
        private void txtDivision_TextChanged(object sender, EventArgs e)
        {
            if (txtDivision.Text.Length > 9)
                txtDepartment.Focus();
        }

        //Evento txtDepartment_TextChanged
        private void txtDepartment_TextChanged(object sender, EventArgs e)
        {
            if (txtDepartment.Text.Length > 9)
                txtArea.Focus();
        }

        //Evento txtArea_TextChanged
        private void txtArea_TextChanged(object sender, EventArgs e)
        {
            if (txtArea.Text.Length > 9)
                txtNumber.Focus();  
        }

        //Evento txtNumber_TextChanged
        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtNumber.Text.Length > 9)
                txtAuthorization.Focus();
        }

        //Evento txtAuthorization_TextChanged
        private void txtAuthorization_TextChanged(object sender, EventArgs e)
        {
            if (txtAuthorization.Text.Length > 9)
                txtWorkerNumber.Focus();
        }

        //Evento txtWorkerNumber_TextChanged
        private void txtWorkerNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtWorkerNumber.Text.Length > 9)
                txtSociety.Focus();
        }

        //Evento txtSociety_TextChanged
        private void txtSociety_TextChanged(object sender, EventArgs e)
        {
            if (txtSociety.Text.Length > 9)
                txtManageCenter.Focus();
        }

        //Evento txtManageCenter_TextChanged
        private void txtManageCenter_TextChanged(object sender, EventArgs e)
        {
            if (txtManageCenter.Text.Length > 9)
                txtInvoicePosition.Focus();
        }

        //Evento txtInvoicePosition_TextChanged
        private void txtInvoicePosition_TextChanged(object sender, EventArgs e)
        {
            if (txtInvoicePosition.Text.Length > 9)
                cmbJustifications.Focus();
        }

        //Evento txtcontractPosition_TextChanged
        private void txtcontractPosition_TextChanged(object sender, EventArgs e)
        {
            if (txtcontractPosition.Text.Length > 19)
                txtSolicitator.Focus();
        }

        //Evento txtSolicitator_TextChanged
        private void txtSolicitator_TextChanged(object sender, EventArgs e)
        {
            if (txtSolicitator.Text.Length > 9)
                cmbCompany.Focus();
        }

        //Evento txtLegalEntity_TextChanged
        private void txtLegalEntity_TextChanged(object sender, EventArgs e)
        {
            if (txtLegalEntity.Text.Length > 9)
                txtOnlineBookingIndicator.Focus();
        }

        //Evento txtOnlineBookingIndicator_TextChanged
        private void txtOnlineBookingIndicator_TextChanged(object sender, EventArgs e)
        {
            if (txtOnlineBookingIndicator.Text.Length > 9)
                txtFareIndicator.Focus();
        }

        //Evento txtFareIndicator_TextChanged
        private void txtFareIndicator_TextChanged(object sender, EventArgs e)
        {
            if (txtFareIndicator.Text.Length > 9)
                txtRealFare.Focus();
        }

        //Evento txtRealFare_TextChanged
        private void txtRealFare_TextChanged(object sender, EventArgs e)
        {
            if (txtRealFare.Text.Length > 9)
                btnAccept.Focus();
        }
        #endregion 


        #region ===== Back to a Previous Usercontrol or Validate Enter KeyDown =====

        /// <summary>
        /// Regreso a mascarilla anterior al presionar la tecla ESC
        /// o continua con el flujo de emision de boleto al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Escape)
            {
                string chargePerService = activeStepsCorporativeQC.CorporativeQualityControls[0].ChargePerService;
                string dk = ucFirstValidations.DK;
                dk = dk.Substring(3, 3);
                if (dk == Resources.TicketEmission.ValitationLabels.NUMBER_990)
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCBILLINGADRESS);
                }
                else if (chargePerService.Equals(Resources.TicketEmission.Constants.ACTIVE))
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_CHARGESERVICE);
                }
                else
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
            }
            if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }

        }

        /// <summary>
        /// seleccion de predictivo al presionar la tecla DOWN
        /// Oculta el predictivo al presionar la tecla ESC o ingresa codigo de opcion 
        ///  seleccionada al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControlCostcenter_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Escape)
            {
                string chargePerService = activeStepsCorporativeQC.CorporativeQualityControls[0].ChargePerService;
                string dk = ucFirstValidations.DK;
                dk = dk.Substring(3, 3);
                if (dk == Resources.TicketEmission.ValitationLabels.NUMBER_990)
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCBILLINGADRESS);
                }
                else if (chargePerService.Equals(Resources.TicketEmission.Constants.ACTIVE))
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_CHARGESERVICE);
                }
                else
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
            }
            if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }

            if (e.KeyCode == Keys.Down)
            {
                if (lbCostCenter.Items.Count > 0)
                {
                    lbCostCenter.SelectedIndex = 0;
                    lbCostCenter.Focus();
                    lbCostCenter.Visible = true;
                    lbCostCenter.Focus();
                }
            }
        }
        #endregion//End Back to a Previous Usercontrol or Validate Enter KeyDown

        /// <summary>
        /// Regreso a mascarilla anterior al presionar la tecla ESC
        /// o continua con el flujo de emision de boleto al presionar la tecla ENTER
        /// Este método funciona con el redimensionamiento..
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                string chargePerService = activeStepsCorporativeQC.CorporativeQualityControls[0].ChargePerService;
                string dk = ucFirstValidations.DK;
                dk = dk.Substring(3, 3);
                if (dk == Resources.TicketEmission.ValitationLabels.NUMBER_990)
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCBILLINGADRESS);
                }
                else if (chargePerService.Equals(Resources.TicketEmission.Constants.ACTIVE))
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_CHARGESERVICE);
                }
                else
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        
    }
}
