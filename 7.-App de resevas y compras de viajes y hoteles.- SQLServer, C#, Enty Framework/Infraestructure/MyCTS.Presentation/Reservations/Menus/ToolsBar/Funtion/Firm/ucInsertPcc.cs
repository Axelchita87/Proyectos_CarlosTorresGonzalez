using System;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucInsertPcc : CustomUserControl
    {
        public ucInsertPcc()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            InitialControlFocus = txtPCC;
            LastControlFocus = btnAccept;
            txtPCC.Focus();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (ValidateBussinessRules)
            {
                string appId = string.Empty;
                if (cmbType.Text.Equals("CONSOLID"))
                    appId = "0c286646-e94e-4ecd-afc4-1b94180dcc11";
                else
                    appId = "e7221f42-03da-4dc9-84b2-b7c29f199010";

                string typebox = string.Empty;
                if (TypeBox.Text.Equals("OPERATIVO"))
                    typebox = "OPERATIVO";
                else if (TypeBox.Text.Equals("GETTHERE"))
                    typebox = "GETTHERE";
                else if (TypeBox.Text.Equals("IPCC"))
                    typebox = "IPCC";
                else if (TypeBox.Text.Equals("CONSOLIDADOR"))
                    typebox = "CONSOLIDADOR";
                else if (TypeBox.Text.Equals("BIZSITE"))
                    typebox = "BIZSITE";
                else if (TypeBox.Text.Equals("ROBOTICO"))
                    typebox = "ROBOTICO";
                else if (TypeBox.Text.Equals("CAPACITACION"))
                    typebox = "CAPACITACION";


                string toolbox = string.Empty;
                if (ToolBox.Text.Equals("ONLINE"))
                    toolbox = "ONLINE";
                else if (ToolBox.Text.Equals("OFFLINE"))
                    toolbox = "OFFLINE";

               


                string  gdsbox = string.Empty;
                if (GDSBox.Text.Equals("SABRE"))
                    gdsbox = "SABRE";
                else if (GDSBox.Text.Equals("AMADEUS"))
                    gdsbox = "AMADEUS";
                else if (GDSBox.Text.Equals("WORDLSPAN"))
                    gdsbox = "WORDLSPAN";

             
                
                if (InsertPccBL.InsertPcc(txtPCC.Text, txtName.Text, appId, typebox, toolbox, gdsbox))
                {
                    MessageBox.Show("Alta de PCC exitosa", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPCC.Text = string.Empty;
                    txtName.Text = string.Empty;
                    cmbType.Text = string.Empty;
                    TypeBox.Text = string.Empty;
                    ToolBox.Text = string.Empty;
                    GDSBox.Text = string.Empty;
                    txtPCC.Focus();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al dar de alta el PCC ", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public bool ValidateBussinessRules
        {
            get
            {
                bool isValid = true;

                if (string.IsNullOrEmpty(txtPCC.Text) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(cmbType.Text))
                {
                    MessageBox.Show("Requiere ingresar todos los datos", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isValid = false;
                    if (string.IsNullOrEmpty(txtName.Text))
                        txtName.Focus();
                    if (string.IsNullOrEmpty(cmbType.Text))
                        cmbType.Focus();
                    if (string.IsNullOrEmpty(txtPCC.Text))
                        txtPCC.Focus();
                }
                else
                {
                    PCC pcc = GetPccBL.GetPcc(txtPCC.Text);
                    if (!string.IsNullOrEmpty(pcc.PccCode))
                    {
                        MessageBox.Show("La TA ya existe en la base de datos", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        isValid = false;
                    }
                }

                if (txtPCC.Text.Length < 4)
                {
                    MessageBox.Show("El PCC debe tener 4 caractéres", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isValid = false;
                }
                return isValid;
            }
        }


        //KeyDown
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);

            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }

        

      

    }
}
