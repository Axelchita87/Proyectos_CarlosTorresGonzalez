using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class UserControl1 : CustomUserControl
    {
        private string sabreAnswer;
        private string send;
        public UserControl1()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            LaunchDefaultBehavior();

        }
        
        private void LaunchDefaultBehavior()
        {
            try
            {                
                
                    AvailabilityCommandsSend();
                    APIResponse();
                
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "error"/*Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information*/);
            }
            Common.EndManualCommandsTransactions();
        }


        private void AvailabilityCommandsSend()
        {


            send ="I";
             
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }           
        }

        private void APIResponse()
            {
                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "UserControl2");
               
            }   
    }
}
