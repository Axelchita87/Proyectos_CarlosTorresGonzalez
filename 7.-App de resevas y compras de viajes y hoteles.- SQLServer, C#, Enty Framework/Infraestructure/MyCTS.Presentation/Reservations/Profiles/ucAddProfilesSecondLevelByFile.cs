using System;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using MyCTS.Presentation.Components;
using MyCTS.Business;
using MyCTS.Entities;
using Excel = Microsoft.Office.Interop.Excel;

namespace MyCTS.Presentation
{
    public partial class ucAddProfilesSecondLevelByFile : CustomUserControl
    {
        
        public ucAddProfilesSecondLevelByFile()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            InitialControlFocus = txtDirectory;
            LastControlFocus = btnAccept;
            ucAvailability.IsInterJetProcess = false;
        }

        string path = string.Empty;

        /// <summary>
        /// Abre el dialog en la Ruta C y si seleccionan el archivo 
        /// se despliga la ruta en el textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picSearch_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            txtDirectory.Text = openFileDialog1.FileName;
                            path = openFileDialog1.FileName;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Error: No se pudo leer el archivo desde el disco original");
                }
            }
        }

        //KeyDown
        /// <summary>
        /// Este se usa para todos los controles en general si se oprime 
        /// Esc se manda a el User control de Welcome 
        /// Enter se manda la accion de botón de Aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);

            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }


        /// <summary>
        /// Handles the Click event of the btnAccept control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidBussinessRules)
            {
                if (File.Exists(path))
                {
                    //Procesar(new FileInfo(path));
                }
            }
        }


        //Valida campos obligatiorios 
        private bool IsValidBussinessRules
        {
            get
            {
                bool isValid = false;
                if (string.IsNullOrEmpty(txtDirectory.Text))
                {
                    MessageBox.Show("REQUIERES INGRESAR LA RUTA DEL ARCHIVO", Resources.Constants.MYCTS,
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDirectory.Focus();
                }
                else
                    isValid = true;
                return isValid;
            }
        }
    }
}
