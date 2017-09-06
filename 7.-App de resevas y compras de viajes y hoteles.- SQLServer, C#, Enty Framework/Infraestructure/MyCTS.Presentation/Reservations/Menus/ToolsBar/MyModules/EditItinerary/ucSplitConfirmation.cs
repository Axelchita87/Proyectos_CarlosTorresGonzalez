using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using MyCTS.Forms.UI;

namespace MyCTS.Presentation
{
    public partial class ucSplitConfirmation : CustomUserControl
    {

        /// <summary>
        /// Descripción: User Control para confirmar la division de un record
        /// Creación:    29 diciembre 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        /// 

        public ucSplitConfirmation()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = rdoYes;
            this.LastControlFocus = btnAccept;
        }

        private void ucSplitConfirmation_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            rdoYes.Checked = true;
            rdoYes.Focus();
            string send = Resources.Constants.COMMANDS_F;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (rdoYes.Checked)
            {
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(Resources.Constants.COMMANDS_ER);
                }
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            else if (rdoNo.Checked)
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UC_SPLIT_RECORD);
            }
            
        }

        #region =====Back to a Previous Usercontrol or Validate Enter KeyDown=====


        /// <summary>
        /// Aborta el proceso al presionar la tecla ESC o ejecuta las 
        /// instrucciones al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData.Equals(Keys.Escape))
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);



            if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }


        }


        #endregion//End Back to a Previous Usercontrol or Validate Enter KeyDown
    }

   

}
