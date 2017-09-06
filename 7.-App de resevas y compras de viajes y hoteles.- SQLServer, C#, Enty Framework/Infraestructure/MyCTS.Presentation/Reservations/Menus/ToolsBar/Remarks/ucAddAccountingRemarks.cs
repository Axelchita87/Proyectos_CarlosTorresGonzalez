using System;
using System.Windows.Forms;
using MyCTS.Presentation.Components;


namespace MyCTS.Presentation
{
    public partial class ucAddAccountingRemarks : CustomUserControl
    {
        /// <summary>
        /// Descripción: User control que agrega los remarks contables
        /// Creación:    25 de Enere 2010, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Angel Trejo Arizmendi
        /// </summary>
        public ucAddAccountingRemarks()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtLine1;
            this.LastControlFocus = btnAccept;
        }

        private void ucAddAccountingRemarks_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtLine1.Focus();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            BuildCommand();
        }

        #region ====== METHODS CLASS ======

        /// <summary>
        /// Armado del comando enviado a Sabre 
        /// </summary>
        private void BuildCommand()
        {
            bool status = false;
            string send = string.Empty;
            if (!string.IsNullOrEmpty(txtLine1.Text))
            {
                send = string.Concat("5.", txtLine1.Text);
                status = true;
            }
            if (!string.IsNullOrEmpty(txtLine2.Text))
                if (status)
                    send = string.Concat(send, Resources.Constants.ENDIT, "5", txtLine2.Text);
                else
                {
                    send = string.Concat("5.", txtLine2.Text);
                    status = true;
                }
            if (!string.IsNullOrEmpty(txtLine3.Text))
                if (status)
                    send = string.Concat(send, Resources.Constants.ENDIT, "5", txtLine3.Text);
                else
                {
                    send = string.Concat("5.", txtLine3.Text);
                    status = true;
                }
            if (!string.IsNullOrEmpty(txtLine4.Text))
                if (status)
                    send = string.Concat(send, Resources.Constants.ENDIT, "5", txtLine4.Text);
                else
                    send = string.Concat("5.", txtLine4.Text);
            if (!string.IsNullOrEmpty(send))
            {
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(send);
                }
            }
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }

        #endregion

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

        #endregion

       
    }
}
