using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MyCTS.Presentation.Components;
using MyCTS.Business;

namespace MyCTS.Presentation
{
    public partial class ucUpdateImages : CustomUserControl
    {

        /// <summary>
        /// Descripcion: Actualización e insercción de nuevas imagenes empleadas en MyCTS
        /// Creación:    17/Agosto/2010 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Angel Trejo
        /// </summary>
        public ucUpdateImages()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = rdoUpdateImgTicket;
            this.LastControlFocus = btnAccept;
        }
      
        //*******Global Variables*************
        private string path;
        private Byte[] content;
        //************************************

     
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidBussinesRules)
            {
                if (rdoBanerImage.Checked)
                    InsertBannerImage();
                else if (rdoUpdateImgAirline.Checked)
                    UpdateImgAirline();
                else
                    UpdateImgTicketprinter();
            }
        }

        private void btnSearchImage_Click(object sender, EventArgs e)
        {
            bool status = false;
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            Microsoft.VisualBasic.Devices.Computer MyComputer = new Microsoft.VisualBasic.Devices.Computer();
            string initialDirectory = MyComputer.FileSystem.SpecialDirectories.MyPictures;
            openFileDialog1.InitialDirectory = initialDirectory;
            if (rdoBanerImage.Checked)
                openFileDialog1.Filter = "Todos los archivos(*.*)|*.*|Imágenes(*.jpg)|*jpg";
            else
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            content = null;
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }

        #region ====== METHODS CLASS ======

        /// <summary>
        /// Reglas del negocio aplicables a este user control
        /// </summary>
        private bool IsValidBussinesRules
        {
            get 
            {
                bool isValid = false;
                if (rdoUpdateImgAirline.Checked && string.IsNullOrEmpty(txtAirline.Text))
                {
                    MessageBox.Show("SE DEBE INGRESAR EL CÓDIGO DE AEROLÍNEA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirline.Focus();
                }
                else if (rdoUpdateImgAirline.Checked && !string.IsNullOrEmpty(txtAirline.Text)
                    && txtAirline.TextLength != 2)
                {
                    MessageBox.Show("EL CÓDIGO DE AEROLÍNEA DEBE SER DE 2 CARACTERES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirline.Focus();
                }
                else if (rdoBanerImage.Checked && string.IsNullOrEmpty(txtAirline.Text))
                {
                    MessageBox.Show("DEBE INGRESAR EL NÚMERO DE ACTIVACIÓN", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirline.Focus();
                }
                else
                    isValid = true;
                return isValid;
            }
        }

        /// <summary>
        /// Se limpian los controles
        /// </summary>
        private void ClearControls() 
        {
            txtAirline.Text = string.Empty;
            txtURL.Text = string.Empty;
            btnSearchImage.Visible = true;
            btnAccept.Visible = false;
            lblImage.Visible = true;
            pictureBox1.BackgroundImage = null;
            path = string.Empty;
            lblInfoNOImage.Visible = false;
        }

        /// <summary>
        /// Actualiza la imagen del baner para el ticket printer
        /// </summary>
        private void UpdateImgTicketprinter()
        {
            int rowsAfected = 0;
            rowsAfected = UpdateImagesBL.UpdateImgTicketPrinter(content);
            content = null;
            if (rowsAfected > 0)
                MessageBox.Show("SE ACTUALIZARON " + rowsAfected + " REGISTROS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("NO SE ACTUALIZO NINGÚN REGISTRO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }

        /// <summary>
        /// Inserta Imagen o archivo a BannerImage
        /// </summary>
        private void InsertBannerImage()
        {
            int rowsAfected = 0;
            rowsAfected = UpdateImagesBL.InsertBannerImage(content, path.Substring(path.LastIndexOf("\\") + 1, path.Length - path.LastIndexOf("\\") - 1),
                path.Substring(path.LastIndexOf("."), path.Length - path.LastIndexOf(".")), txtURL.Text, txtAirline.Text);
            content = null;
            if (rowsAfected > 0)
                MessageBox.Show("SE ACTUALIZARON " + rowsAfected + " REGISTROS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("NO SE ACTUALIZO NINGÚN REGISTRO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }

        /// <summary>
        /// Actualiza la imagen por aerolínea
        /// </summary>
        private void UpdateImgAirline()
        {
            int rowsAfected = 0;
            rowsAfected = UpdateImagesBL.UpdateImgAirlineCode(content, txtAirline.Text);
            content = null;
            if (rowsAfected > 0)
                MessageBox.Show("SE ACTUALIZARON " + rowsAfected + " REGISTROS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("NO SE ACTUALIZO NINGÚN REGISTRO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }

        #endregion //METHODS CLASS

        #region ====== RADIOBUTTONS CHECKED ======

        private void rdoUpdateImgTicket_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoUpdateImgTicket.Checked)
            {
                ClearControls();
                lblAirlineCode.Visible = false;
                lblURL.Visible = false;
                txtAirline.Visible = false;
                txtURL.Visible = false;
            }
        }

        private void rdoUpdateImgAirline_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoUpdateImgAirline.Checked)
            {
                ClearControls();
                lblAirlineCode.Text = "Codigo de Aerolínea (2 caracteres)";
                lblAirlineCode.Visible = true;
                txtAirline.Visible = true;
                txtAirline.MaxLength = 2;
                txtURL.Visible = false;
                lblURL.Visible = false;
                txtAirline.Focus();
            }
        }

        private void rdoBanerImage_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBanerImage.Checked)
            {
                ClearControls();
                lblAirlineCode.Text = "Número de activación";
                lblAirlineCode.Visible = true;
                txtAirline.Visible = true;
                txtAirline.MaxLength = 3;
                txtURL.Visible = true;
                lblURL.Visible = true;
                txtAirline.Focus();
            }
        }

        #endregion //RADIOBUTTONS CHECKED

        #region ======Back to a Previous Usercontrol or Validate Enter KeyDown=====

        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                content = null;
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            if (e.KeyData == Keys.Enter)
            {
                btnAccept_Click(sender, e);
            }
        }

        #endregion //Back to a Previous Usercontrol or Validate Enter KeyDown

        
    }
}
