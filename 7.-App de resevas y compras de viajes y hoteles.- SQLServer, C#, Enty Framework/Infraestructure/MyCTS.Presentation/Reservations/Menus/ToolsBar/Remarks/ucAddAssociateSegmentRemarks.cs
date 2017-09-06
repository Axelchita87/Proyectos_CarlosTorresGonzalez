using System;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Forms.UI;

namespace MyCTS.Presentation
{
    public partial class ucAddAssociateSegmentRemarks : CustomUserControl
    {
        /// <summary>
        /// Descripción: User control que remarks asociados a segmentos
        /// Creación:    25 de Enere 2010, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Angel Trejo Arizmendi
        /// </summary>
        public ucAddAssociateSegmentRemarks()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtSegment1;
            this.LastControlFocus = btnAccept;
        }

        private void ucAddAssociateSegmentRemarks_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtSegment1.Focus();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidBussinesRules)
                BuildCommand();
        }

        #region ====== METHODS CLASS ======

        /// <summary>
        /// Bussines rules aplicadas a este user control
        /// </summary>
        private bool IsValidBussinesRules
        {
            get 
            {
                bool isValid = false;
                if (!rdoAccounting.Checked && !rdoItinerary.Checked)
                {
                    MessageBox.Show("DEBE SELECIONAR ALGUNA OPCIÓN DE REMARK", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rdoItinerary.Focus();
                }
                else if (!string.IsNullOrEmpty(txtSegment1.Text) && string.IsNullOrEmpty(txtLine1.Text))
                {
                    MessageBox.Show("DEBE INGRESAR REMARK PARA SEGMENTO 1", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLine1.Focus();
                }
                else if (!string.IsNullOrEmpty(txtLine1.Text) && string.IsNullOrEmpty(txtSegment1.Text))
                {
                    MessageBox.Show("DEBE INGRESAR EL NÚMERO DE SEGMENTO PARA REMARK 1", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSegment1.Focus();
                }
                else if (!string.IsNullOrEmpty(txtSegment2.Text) && string.IsNullOrEmpty(txtLine2.Text))
                {
                    MessageBox.Show("DEBE INGRESAR REMARK PARA SEGMENTO 2", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLine2.Focus();
                }
                else if (!string.IsNullOrEmpty(txtLine2.Text) && string.IsNullOrEmpty(txtSegment2.Text))
                {
                    MessageBox.Show("DEBE INGRESAR EL NÚMERO DE SEGMENTO PARA REMARK 2", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSegment2.Focus();
                }
                else if (!string.IsNullOrEmpty(txtSegment3.Text) && string.IsNullOrEmpty(txtLine3.Text))
                {
                    MessageBox.Show("DEBE INGRESAR REMARK PARA SEGMENTO 3", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLine3.Focus();
                }
                else if (!string.IsNullOrEmpty(txtLine3.Text) && string.IsNullOrEmpty(txtSegment3.Text))
                {
                    MessageBox.Show("DEBE INGRESAR EL NÚMERO DE SEGMENTO PARA REMARK 3", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSegment3.Focus();
                }
                else if (!string.IsNullOrEmpty(txtSegment4.Text) && string.IsNullOrEmpty(txtLine4.Text))
                {
                    MessageBox.Show("DEBE INGRESAR REMARK PARA SEGMENTO 4", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLine4.Focus();
                }
                else if (!string.IsNullOrEmpty(txtLine4.Text) && string.IsNullOrEmpty(txtSegment4.Text))
                {
                    MessageBox.Show("DEBE INGRESAR EL NÚMERO DE SEGMENTO PARA REMARK 4", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSegment4.Focus();
                }
                else
                    isValid = true;
                return isValid;
            }
        }

        /// <summary>
        /// Armado del comando que se debe enviar a sabre
        /// </summary>
        private void BuildCommand()
        {
            bool status = false;
            string send = string.Empty;
            if(!string.IsNullOrEmpty(txtLine1.Text))
            {
                send = string.Concat((rdoAccounting.Checked) ? "5.S" : "5‡S", txtSegment1.Text, txtLine1.Text);
                status = true;
            }
            if (!string.IsNullOrEmpty(txtLine2.Text))
                if (status)
                    send = string.Concat(send, (rdoAccounting.Checked) ? "?5.S" : "?5‡S", txtSegment2.Text, txtLine2.Text);
                else
                {
                    send = string.Concat((rdoAccounting.Checked) ? "5.S" : "5‡S", txtSegment2.Text, txtLine2.Text);
                    status = true;
                }
            if (!string.IsNullOrEmpty(txtLine3.Text))
                if (status)
                    send = string.Concat(send, (rdoAccounting.Checked) ? "?5.S" : "?5‡S", txtSegment3.Text, txtLine3.Text);
                else
                {
                    send = string.Concat((rdoAccounting.Checked) ? "5.S" : "5‡S", txtSegment3.Text, txtLine3.Text);
                    status = true;
                }
            if (!string.IsNullOrEmpty(txtLine4.Text))
                if (status)
                    send = string.Concat(send, (rdoAccounting.Checked) ? "?5.S" : "?5‡S", txtSegment4.Text, txtLine4.Text);
                else
                    send = string.Concat((rdoAccounting.Checked) ? "5.S" : "5‡S", txtSegment4.Text, txtLine4.Text);
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

        #endregion

    }
}
