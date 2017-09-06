using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucChangeUrlComissionBoard : CustomUserControl
    {
        public ucChangeUrlComissionBoard()
        {
            InitializeComponent();
            txtUrl.CharacterCasing = CharacterCasing.Normal;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUrl.Text))
            {
                try
                {
                    System.Diagnostics.Process.Start(txtUrl.Text);
                }
                catch
                {
                    MessageBox.Show(
                         "La URL ingresada no es válida", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
                    txtUrl.Text = string.Empty;
                    return;
                }
                DialogResult result =
                       MessageBox.Show(
                         "¿Se desplego Correctamente el archivo?", Resources.Constants.MYCTS, MessageBoxButtons.YesNo,
                           MessageBoxIcon.Information);                
                if (result.Equals(DialogResult.Yes))
                {
                    ParameterBL.UpdateComissionBoardURL("TablaComisiones", txtUrl.Text);
                    MessageBox.Show(
                         "Actualización Completada", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
                else
                {
                    MessageBox.Show(
                         "Vuelva a ingresar la URL", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
                    txtUrl.Text = string.Empty;
                }
                              
            }
        }

        private void ucChangeUrlComissionBoard_Load(object sender, EventArgs e)
        {

        }
    }
}
