using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using MyCTS.Business;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.Banner
{
    public partial class VolarisBanner : UserControl
    {
        public VolarisBanner()
        {
            InitializeComponent();

        }

        void timer1_Tick(object sender, EventArgs e)
        {
            if (StopWatch.Elapsed.Seconds > 4)
            {
                if (messageBanner.Location.Y < 0)
                {
                    messageBanner.Location = new Point(41, 36);
                    messageBanner.Text = GetRandomMessage();
                }
                else
                {
                    messageBanner.Location = new Point(41, messageBanner.Location.Y - 6);
                    if (messageBanner.Location.X == 41 && messageBanner.Location.Y == 18)
                    {
                        StopWatch.Reset();
                        StopWatch.Start();

                    }


                }

            }
        }

        private Stopwatch StopWatch { get; set; }


        private List<string> messageList = new List<string>();

        private void FillList()
        {


            var parameter = ParameterBL.GetParameterValue("VolarisMessage");
            if (parameter != null && !string.IsNullOrEmpty(parameter.Values))
            {
                messageList = parameter.Values.Split('|').ToList();
            }

        }

        private string GetRandomMessage()
        {
            if (messageList.Any())
            {
                var random = new Random();
                var maxValue = messageList.Count - 1;
                if (maxValue < 0)
                {
                    maxValue = 1;
                }
                var index = random.Next(0, maxValue);

                return messageList[index];
            }
            return "Nueva Interfaz de MyCTS con Volaris";

        }

        private void VolarisBanner_Load(object sender, EventArgs e)
        {
            timer1.Tick += timer1_Tick;
            this.timer1.Interval = 100;
            this.timer1.Enabled = true;
            this.timer1.Start();
            FillList();
            messageBanner.Text = GetRandomMessage();
            StopWatch = new Stopwatch();

            StopWatch.Start();
        }


    }
}
