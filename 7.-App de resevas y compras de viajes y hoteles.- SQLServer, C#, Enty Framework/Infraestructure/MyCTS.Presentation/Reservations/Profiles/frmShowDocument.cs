using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyCTS.Presentation.Reservations.Profiles
{
    public partial class frmShowDocument : Form
    {
        public frmShowDocument( int imageId)
        {
            InitializeComponent();
            showImage( imageId);
        }

        private void showImage( int imageId)
        {
            try
            {

                MyCTS.Entities.DocsSecondLevel docs = MyCTS.Business.DocsSecondLevelBL.getImageById( imageId);

                if (docs.ImageId == 0)
                {
                    MyCTS.Entities.DocsFirstLevel d = MyCTS.Business.DocsFirstLevelBL.getImageById(imageId);
                    System.Drawing.Image newImage;

                    MemoryStream ms = new MemoryStream(d.Image);
                    Image imagenNueva = Image.FromStream(ms);
                    ms.Close();
                    int w = imagenNueva.Width;
                    int h = imagenNueva.Height;
                    if (w > 500)
                    {
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                    }
                    pictureBox1.Image = imagenNueva;
                    lbTitle.Text = docs.Name;
                    label1.Text = docs.NameDocument;
                }
                else
                {
                    System.Drawing.Image newImage;

                    MemoryStream ms = new MemoryStream(docs.Image);
                    Image imagenNueva = Image.FromStream(ms);
                    ms.Close();
                    int w = imagenNueva.Width;
                    int h = imagenNueva.Height;
                    if (w > 500)
                    {
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                    }
                    pictureBox1.Image = imagenNueva;
                    lbTitle.Text = docs.Name;
                    label1.Text = docs.NameDocument;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void frmShowDocument_Load(object sender, EventArgs e)
        {

        }
    }
}
