using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;
using MyCTS.Components;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Presentation.Components;
using System.IO;

namespace MyCTS.Presentation
{
    public partial class ucWelcome : CustomUserControl
    {

        private static List<BannerImage> BannerImageList = new List<BannerImage>();
        private static string activeBanner;
        private int imageLoadedIndex;

        public ucWelcome()
        {
            InitializeComponent();
        }

        private void ucWelcome_Load(object sender, EventArgs e)
        {
            InitialValidations();
           
        }

        #region===== MethodsClass =====

        private void InitialValidations()
        {
            try
            {
                if (this.Parameters != null)
                {
                    if (this.Parameters.Length.Equals(1))
                    {
                        lblTA.Text = this.Parameters[0];
                        BannerImageList.Clear();
                        lblStateConection.Text = "No Conectado";
                        lblStateConection.ForeColor = Color.Red;
                        string sabreAnswer = string.Empty;
                        string ta = string.Empty;
                        string send = "‡J";
                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            sabreAnswer = objCommand.SendReceive(send);
                        }

                        CommandsQik.CopyResponse(sabreAnswer, ref ta, 1, 21, 6);
                        SetTABL.SetTa(Login.Firm, ta);
                    }
                    else if (this.Parameters.Length.Equals(3))
                    {
                        lblTA.Text = this.Parameters[0];
                        lblBienvenido.Text = this.Parameters[1];
                        lblInformacion.Text = this.Parameters[2];
                        lblStateConection.Visible = false;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(activeBanner))
                        activeBanner = ParameterBL.GetParameterValue("ActiveBanner").Values;
                    if (Convert.ToBoolean(activeBanner))
                    {
                        try
                        {
                            if (BannerImageList != null)
                            {
                                if (BannerImageList.Count.Equals(0))
                                    BannerImageList = GetBannerImageBL.GetBannerImageList("1");
                                if (BannerImageList.Count > 0)
                                {

                                    SetDinamicImages();
                                }
                            }

                        }
                        catch
                        { }
                    }
                }
            }
            catch { }
        }

        private void SetDinamicImages()
        {
            if (BannerImageList.Count > 0)
            {

                Random index = new Random();
                int imageIndex = index.Next(BannerImageList.Count);
                byte[] buffer = BannerImageList[imageIndex].Content;
                imageLoadedIndex = imageIndex;
                MemoryStream image = new MemoryStream(buffer);
                BannerBox.Image = Image.FromStream(image);
                //BannerBox.Image.Save(string.Concat("c:/imagenBanner", imageIndex, ".jpg"));
                BannerBox.SizeMode = PictureBoxSizeMode.StretchImage;
                BannerBox.Visible = true;
                toolTipBannerBox.SetToolTip(this.BannerBox, "Da Doble Click Sobre la Imagen para ver los Detalles");
                timerImages.Interval = 7000;
                timerImages.Enabled = true;
            }
        }

        #endregion//End MethodsClass

        //Evento BannerBox_DoubleClick
        private void BannerBox_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string url = BannerImageList[imageLoadedIndex].Url;
                System.Diagnostics.Process.Start(url);
            }
            catch { }
        }

        //Evento timerImages_Tick
        private void timerImages_Tick(object sender, EventArgs e)
        {
            SetDinamicImages();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
