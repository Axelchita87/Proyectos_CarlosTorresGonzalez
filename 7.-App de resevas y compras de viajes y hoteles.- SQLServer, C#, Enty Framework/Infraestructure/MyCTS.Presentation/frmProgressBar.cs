using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Reflection;
using System.Deployment.Application;
using System.Windows.Forms;

namespace MyCTS.Presentation
{
    public partial class frmProgressBar : Form
    {
        public frmProgressBar()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i <= prbUpdate.Maximum; i++)
            {
                prbUpdate.Value = i;
                System.Threading.Thread.Sleep(10);
            }
            prbUpdate.Value = 0;
        }
        /// <summary>
        /// Actualiza la Version mediante la API de ClickOnce
        /// </summary>
        private void UpdateVersion()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment updateCheck = ApplicationDeployment.CurrentDeployment;
                UpdateCheckInfo info = updateCheck.CheckForDetailedUpdate();
                if (info.UpdateAvailable)
                {
                    updateCheck.Update();
                    CloseThisWin();
                }
            }
        }

        private void CloseThisWin()
        {
            if (this.InvokeRequired)
                this.Invoke(new SenderShowForm(CloseThisWin));
            else
            {
                try
                {
                    Application.Restart();
                }
                catch { }
                finally
                {

                }
            }
        }

        private delegate void SenderShowForm();
        private void frmProgressBar_Shown(object sender, EventArgs e)
        {
            SenderShowForm slc = new SenderShowForm(UpdateVersion);
            slc.BeginInvoke(null, null);
        }

    }
}