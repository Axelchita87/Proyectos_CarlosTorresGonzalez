using System;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Forms.UI;

namespace MyCTS.Presentation
{
    public partial class ucDisplayRulesByCategories : CustomUserControl
    {

        /// <summary>
        /// Descripción: User control que despliega la regla de tarifa
        ///              por cotegorías
        /// Creación:    25 de Febrero 2010, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Angel Trejo Arizmendi
        /// </summary>  
        public ucDisplayRulesByCategories()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
             ControlStyles.UserPaint |
             ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtRule1;
            this.LastControlFocus = btnAccept;
        }

        private void ucDisplayRulesByCategories_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtRule1.Focus();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            BuildCommand();
        }

        #region =====METHODS CLASS=====

        /// <summary>
        /// Armado del comando que se envia a sabre
        /// </summary>
        private void BuildCommand()
        {
            string send = "RD*";
            bool status = false;
            if (!string.IsNullOrEmpty(txtRule1.Text))
            {
                send = string.Concat(send, txtRule1.Text);
                status = true;
            }
            if (!string.IsNullOrEmpty(txtRule2.Text))
            {
                if (status)
                    send = string.Concat(send, "/", txtRule2.Text);
                else
                {
                    send = string.Concat(send, txtRule2.Text);
                    status = true;
                }
            }
            if (!string.IsNullOrEmpty(txtRule3.Text))
            {
                if (status)
                    send = string.Concat(send, "/", txtRule3.Text);
                else
                {
                    send = string.Concat(send, txtRule3.Text);
                    status = true;
                }
            }
            if (!string.IsNullOrEmpty(txtRule4.Text))
            {
                if (status)
                    send = string.Concat(send, "/", txtRule4.Text);
                else
                {
                    send = string.Concat(send, txtRule4.Text);
                    status = true;
                }
            }
            if (!string.IsNullOrEmpty(txtRule5.Text))
            {
                if (status)
                    send = string.Concat(send, "/", txtRule5.Text);
                else
                {
                    send = string.Concat(send, txtRule5.Text);
                    status = true;
                }
            }
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }

        #endregion //METHODS CLASS

        #region =====Back to a Previous Usercontrol or Validate Enter KeyDown=====

        /// <summary>
        /// Aborta el proceso al presionar la tecla ESC
        /// o ejecutar las funciones al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            if (e.KeyData.Equals(Keys.Enter))
                btnAccept_Click(sender, e);
        }

        #endregion //Back to a Previous Usercontrol or Validate Enter KeyDown

        #region=====Change focus When a Textbox is Full=====

        //Evento txtControls_TextChanged
        private void txtControls_TextChanged(object sender, EventArgs e)
        {
            if (sender is SmartTextBox)
                if (((SmartTextBox)sender).Text.Length > ((SmartTextBox)sender).MaxLength - 1)
                    foreach (Control txt in this.Controls)
                        if (txt.TabIndex.Equals(((SmartTextBox)(sender)).TabIndex + 1))
                        {
                            txt.Focus();
                            break;
                        }

        }

        #endregion//End Change focus When a Textbox is Full
    }
}
