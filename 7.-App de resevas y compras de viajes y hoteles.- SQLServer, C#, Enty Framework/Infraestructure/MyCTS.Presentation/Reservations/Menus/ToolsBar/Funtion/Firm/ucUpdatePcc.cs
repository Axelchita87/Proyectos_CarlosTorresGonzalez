using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucUpdatePcc : CustomUserControl
    {
        public ucUpdatePcc()
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

                if (UpdatePccInfoBL.UpdatePcc(txtPCC.Text, txtName.Text, TypeBox.Text,  ToolBox.Text, GDSBox.Text,  appId))
                {
                    MessageBox.Show("Los datos se han actualizado correctamente.", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPCC.Text=string.Empty;
                    txtName.Text=string.Empty;
                    cmbType.Text = string.Empty;
                    TypeBox.Text = string.Empty;
                    ToolBox.Text = string.Empty;
                    GDSBox.Text = string.Empty;
                    txtPCC.Focus();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error durante la actualización.", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPCC.Text = string.Empty;
                    txtName.Text = string.Empty;
                    cmbType.Text = string.Empty;
                    TypeBox.Text = string.Empty;
                    ToolBox.Text = string.Empty;
                    GDSBox.Text = string.Empty;
                    txtPCC.Focus();
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

        //KeyDownListBox
        private void BackEnterUserControlListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);

            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);

            if (e.KeyCode == Keys.Down)
            {
                if (lbPCC.Items.Count > 0)
                {
                    lbPCC.SelectedIndex = 0;
                    lbPCC.Focus();
                }
            }
        }

        //Despliega opciones y elige opción con la tecla Enter     
        private void lbPCC_KeyDown(object sender, KeyEventArgs e)
        {
            ListBox ListBox = (ListBox)sender;
            TextBox txt = txtPCC;

            if (e.KeyCode == Keys.Enter)
            {
                ListItem li = (ListItem)ListBox.SelectedItem;
                txt.Text = li.Value;
                lbPCC.Visible = false;
                txt.Focus();
            }
        }

        private void ListBox_MouseClick(object sender, EventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            TextBox txt = txtPCC;

            ListItem li = (ListItem)listBox.SelectedItem;
            txt.Text = li.Value;
            lbPCC.Visible = false;
            txt.Focus();
        }


        private void txtPCC_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
               Common.SetDeleteListBoxPCCs(txt, lbPCC);

            if (txtPCC.Text.Length==4)
            {
               PCC objPcc= GetPccBL.GetPcc(txtPCC.Text);

                if (!string.IsNullOrEmpty(objPcc.PccCode))
                {
                    txtPCC.Text = objPcc.PccCode;
                    txtPCC.Enabled = true;
                    txtName.Text = objPcc.Name;


                    if (objPcc.Type.Equals("0c286646-e94e-4ecd-afc4-1b94180dcc11"))
                        cmbType.Text = "CONSOLID";
                    else
                        cmbType.Text = "CTS";



                    if (objPcc.Tipo.Equals("OPERATIVO"))
                        TypeBox.Text = "OPERATIVO";
                    else if (objPcc.Tipo.Equals("GETTHERE"))
                        TypeBox.Text = "GETTHERE";
                    else if (objPcc.Tipo.Equals("GETTHERE"))
                        TypeBox.Text = "GETTHERE";
                    else if (objPcc.Tipo.Equals("IPCC"))
                        TypeBox.Text = "IPCC";
                    else if (objPcc.Tipo.Equals("CONSOLIDADOR"))
                        TypeBox.Text = "CONSOLIDADOR";
                    else if (objPcc.Tipo.Equals("BIZSITE"))
                        TypeBox.Text = "BIZSITE";
                    else if (objPcc.Tipo.Equals("ROBOTICO"))
                        TypeBox.Text = "ROBOTICO";
                    else if (objPcc.Tipo.Equals("CAPACITACION"))
                        TypeBox.Text = "CAPACITACION";

                    if (objPcc.Tool.Equals("ONLINE              "))
                        ToolBox.Text = "ONLINE";
                    else if (objPcc.Tool.Equals("OFFLINE             "))
                        ToolBox.Text = "OFFLINE";
                    else if (objPcc.Tool.Equals("ONLINE"))
                        ToolBox.Text = "ONLINE";
                    else if (objPcc.Tool.Equals("OFFLINE"))
                        ToolBox.Text = "ONLINE";


                    if (objPcc.GDS.Equals("SABRE"))
                        GDSBox.Text = ("SABRE");
                    else if (objPcc.GDS.Equals("AMADEUS"))
                        GDSBox.Text = ("AMADEUS");
                    else if (objPcc.GDS.Equals("WORLDSPAN"))
                        GDSBox.Text = ("WORLDSPAN");
                                      
                    


                }
                else
                {
                    txtPCC.Text = string.Empty;
                    txtPCC.Enabled = true;
                    txtName.Text = string.Empty;
                    cmbType.Text = string.Empty;
                    TypeBox.Text = string.Empty;
                    ToolBox.Text = string.Empty;
                    GDSBox.Text = string.Empty;
                }
            }
        }
    }
}
