using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using System.IO;

namespace MyCTS.Presentation
{
    public partial class ucAddAirLinesFare : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Inserta nuevas AirLines Fare en la BdD
        /// Creación:    10-06-10 
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez
        /// </summary>

        private bool exist = false;
        private Byte[] content;
        private string path;

        public ucAddAirLinesFare()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtCodeAirline;
            this.LastControlFocus = btnAccept;
        }

        //Coloca el foco y a los combos les pone un true por defautl
        private void ucAddAirLinesFare_Load(object sender, EventArgs e)
        {
            txtCodeAirline.Focus();
            cmbCash.SelectedIndex = 1;
            cmbCCAut.SelectedIndex = 1;
            cmbMan.SelectedIndex = 1;
            cmbMisce.SelectedIndex = 1;
            cmbPMix.SelectedIndex = 1;
            cmbOpManual.SelectedIndex = 2;
        }

        /// <summary>
        /// Verifica si existe la Aerolínea y manda a llamar los metodos
        /// de validación y envio de comando
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            List<AirLineFare> list = AirLineFareBL.GetAirLineFare(txtCodeAirline.Text);
            if (list.Count > 0)
                exist = true;
            else
                exist = false;

            if (IsValidBussinessRules)
            {
                Command();
            }
        }

        /// <summary>
        /// Realizar la accion de acuerdo a lo que presionaron
        /// Si es Esc manda a llamar el user Control de Welcome
        /// Si es Enter manda a llamar el evento clic de boton Aceptar
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

        #region ======= ChangeFocus ======
        //Cambia de foco
        private void txtCodeAirline_TextChanged(object sender, EventArgs e)
        {
            if (txtCodeAirline.Text.Length > 1)
                txtAirlineName.Focus();
        }

        private void txtAirlineName_TextChanged(object sender, EventArgs e)
        {
            if (txtAirlineName.Text.Length > 49)
                cmbCCAut.Focus();
        }
        //Deacuerdo a la letra typeada selecciona el index del combo
        private void cmbCCAut_TextChanged(object sender, EventArgs e)
        {
            if (cmbCCAut.Text.ToUpper() == "F")
                cmbCCAut.SelectedIndex = 2;
            else if (cmbCCAut.Text.ToUpper() == "T")
                cmbCCAut.SelectedIndex = 1;
        }

        private void cmbMan_TextChanged(object sender, EventArgs e)
        {
            if (cmbMan.Text.ToUpper() == "F")
                cmbMan.SelectedIndex = 2;
            else if (cmbMan.Text.ToUpper() == "T")
                cmbMan.SelectedIndex = 1;
        }

        private void cmbCash_TextChanged(object sender, EventArgs e)
        {
            if (cmbCash.Text.ToUpper() == "F")
                cmbCash.SelectedIndex = 2;
            else if (cmbCash.Text.ToUpper() == "T")
                cmbCash.SelectedIndex = 1;
        }

        private void cmbPMix_TextChanged(object sender, EventArgs e)
        {
            if (cmbPMix.Text.ToUpper() == "F")
                cmbPMix.SelectedIndex = 2;
            else if (cmbPMix.Text.ToUpper() == "T")
                cmbPMix.SelectedIndex = 1;
        }

        private void cmbMisce_TextChanged(object sender, EventArgs e)
        {
            if (cmbMisce.Text.ToUpper() == "F")
                cmbMisce.SelectedIndex = 2;
            else if (cmbMisce.Text.ToUpper() == "T")
                cmbMisce.SelectedIndex = 1;
        }

        #endregion

        #region ===== methodsClass =====

        //Valida los campos que son obligatorios
        private bool IsValidBussinessRules
        {
            get
            {
                bool isValid = false;
                if (string.IsNullOrEmpty(txtCodeAirline.Text) ||
                    txtCodeAirline.Text.Length<2)
                {
                    MessageBox.Show(Resources.Development.Development.REQUIERE_INGRESES_CÓDIGO_AEROLÍNEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCodeAirline.Focus();
                }
                if (string.IsNullOrEmpty(txtAirlineName.Text))
                {
                    MessageBox.Show(Resources.Development.Development.REQUIERE_INGRESES_NOMBRE_AEROLÍNEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirlineName.Focus();
                }
                else if (cmbCCAut.SelectedIndex<1)
                {
                    MessageBox.Show(Resources.Development.Development.REQUIERE_INGRESES_REQUIERE_TARJETA_CRÉDIT_AUTOMATICA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbCCAut.Focus();
                }
                else if (cmbMan.SelectedIndex<1)
                {
                    MessageBox.Show(Resources.Development.Development.REQUIERE_INGRESES_REQUIERE_TARJETA_CRÉDITO_MANUAL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbMan.Focus();
                }
                else if (cmbCash.SelectedIndex<1)
                {
                    MessageBox.Show(Resources.Development.Development.REQUIERE_INGRESES_REQUIERE_EFECTIVO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbCash.Focus();
                }
                else if (cmbPMix.SelectedIndex<1)
                {
                    MessageBox.Show(Resources.Development.Development.REQUIERE_INGRESES_REQUIERE_PAGO_MIXTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbPMix.Focus();
                }
                else if (cmbMisce.SelectedIndex<1)
                {
                    MessageBox.Show(Resources.Development.Development.REQUIERE_INGRESES_REQUIERE_PAGO_MISCELANEO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbMisce.Focus();
                }
                else if (cmbOpManual.SelectedIndex < 1)
                {
                    MessageBox.Show("REQUIERE INGRESES LA OPERATIVA MANUAL", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbOpManual.Focus();
                }
                else if (content == null)
                {
                    MessageBox.Show("REQUIERE INGRESES UN LA IMAGEN DEL LOGOTIPO DE LA AEROLINEA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSearchImage.Focus();
                }
                else if (exist)
                {
                    MessageBox.Show(Resources.Development.Development.AEROLINEA_YA_EXISTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCodeAirline.Focus();
                }
                else
                    isValid = true;

                return isValid;
            }
        }

        /// <summary>
        /// Inserta los datos en la BD y manda a llamar el metodo de 
        /// limpiar los controles
        /// </summary>
        private void Command()
        {
            try
            {
                SetAirLinesFareBL.SetAirLinesFare(txtCodeAirline.Text, txtAirlineName.Text,
                   Convert.ToBoolean(cmbCCAut.Text), Convert.ToBoolean(cmbMan.Text),
                   Convert.ToBoolean(cmbCash.Text), Convert.ToBoolean(cmbPMix.Text),
                   Convert.ToBoolean(cmbMisce.Text),content , Convert.ToBoolean(cmbOpManual.Text));
                MessageBox.Show("ALTA DE AEROLINEA EXITOSA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("NO SE LOGRO CONCRETAR LA ALTA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ClearControls(string.Empty);
        }

        //Limpia los controles
        private void ClearControls(string Empty)
        {
            txtCodeAirline.Text = Empty;
            txtAirlineName.Text = Empty;
            cmbCash.Text = Empty;
            cmbCCAut.Text = Empty;
            cmbMan.Text = Empty;
            cmbMisce.Text = Empty;
            cmbPMix.Text = Empty;
            cmbOpManual.Text = Empty;
            lblInfoNOImage.Text = Empty;
            
        }

        #endregion

        private void btnSearchImage_Click(object sender, EventArgs e)
        {
            bool status = false;
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            Microsoft.VisualBasic.Devices.Computer MyComputer = new Microsoft.VisualBasic.Devices.Computer();
            string initialDirectory = MyComputer.FileSystem.SpecialDirectories.MyPictures;
            openFileDialog1.InitialDirectory = initialDirectory;
            openFileDialog1.Filter = "Imágenes (*.jpg)|*.jpg";
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
                            path = openFileDialog1.FileName;
                            status = true;
                        }
                    }
                }
                catch { }
            }
            if (status)
            {
                try
                {
                    System.IO.FileStream fs = new FileStream(path, System.IO.FileMode.Open);
                    content = new byte[fs.Length];
                    fs.Read(content, 0, Convert.ToInt32(fs.Length));
                    fs.Close();
                    if (path.ToUpper().EndsWith(".JPG")
                        || path.ToUpper().EndsWith(".PNG")
                        || path.ToUpper().EndsWith(".GIF"))
                    {
                        MemoryStream image = new MemoryStream(content);
                        pictureBox1.BackgroundImage = Image.FromStream(image);
                        lblInfoNOImage.Visible = false;
                    }
                    else
                    {
                        pictureBox1.BackgroundImage = null;
                        lblInfoNOImage.Text = string.Concat("Archivo: ", path.Substring(path.LastIndexOf("\\") + 1, path.Length - path.LastIndexOf("\\") - 1));
                        lblInfoNOImage.Visible = true;
                    }
                    btnAccept.Visible = true;
                }
                catch
                {
                    MessageBox.Show("ERROR DE ACCESO, COMPRUEBE QUE AL ARCHIVO NO ESTE SIENDO USADO EN OTRO PROCESO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
