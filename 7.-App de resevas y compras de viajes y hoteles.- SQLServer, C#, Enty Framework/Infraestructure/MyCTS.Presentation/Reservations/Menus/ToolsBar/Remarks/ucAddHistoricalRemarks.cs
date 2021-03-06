using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucAddHistoricalRemarks : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite Agregar Remarks Historicos
        /// Creación:    25-Ene-10 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez
        /// </summary>

        public ucAddHistoricalRemarks()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtLine1;
            this.LastControlFocus = btnAccept;
        }

        private void ucAddHistoricalRemarks_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtLine1.Focus();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLine1.Text) ||
               !string.IsNullOrEmpty(txtLine2.Text) ||
               !string.IsNullOrEmpty(txtLine3.Text) ||
               !string.IsNullOrEmpty(txtLine4.Text))
                CommandsSend();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }

        //KeyDown
        /// <summary>
        /// Este se usa para todos los controles en general si se oprime 
        /// Esc se manda a el User control de Welcome
        /// Enter se manda la accion de botón de Aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);

            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }

        #region ===== Change Focus ======

        private void txtLine1_TextChanged(object sender, EventArgs e)
        {
            if (txtLine1.Text.Length > 55)
                txtLine2.Focus();
        }

        private void txtLine2_TextChanged(object sender, EventArgs e)
        {
            if (txtLine2.Text.Length > 55)
                txtLine3.Focus();
        }

        private void txtLine3_TextChanged(object sender, EventArgs e)
        {
            if (txtLine3.Text.Length > 55)
                txtLine4.Focus();
        }

        private void txtLine4_TextChanged(object sender, EventArgs e)
        {
            if (txtLine4.Text.Length > 55)
                btnAccept.Focus();
        }

        #endregion

        #region ===== methodsClass =====

        /// <summary>
        /// Se envia el comando de acuerdo a los campos ingresados
        /// </summary>
        private void CommandsSend()
        {
            int flag = 0;
            string send = string.Empty;

            if (!string.IsNullOrEmpty(txtLine1.Text))
            {
                send = string.Concat(send, Resources.Constants.FIVE_H_INDENT, txtLine1.Text);
                flag = 1;
            }
            if (!string.IsNullOrEmpty(txtLine2.Text))
            {
                if (flag == 1)
                    send = string.Concat(send, Resources.Constants.END_ITEM_FIVE_H_INDENT, txtLine2.Text);
                else
                {
                    send = string.Concat(send, Resources.Constants.FIVE_H_INDENT, txtLine2.Text);
                    flag = 1;
                }
            }
            if (!string.IsNullOrEmpty(txtLine3.Text))
            {
                if (flag == 1)
                    send = string.Concat(send, Resources.Constants.END_ITEM_FIVE_H_INDENT, txtLine3.Text);
                else
                {
                    send = string.Concat(send, Resources.Constants.FIVE_H_INDENT, txtLine3.Text);
                    flag = 1;
                }
            }
            if (!string.IsNullOrEmpty(txtLine4.Text))
            {
                if (flag == 1)
                    send = string.Concat(send, Resources.Constants.END_ITEM_FIVE_H_INDENT, txtLine4.Text);
                else
                {
                    send = string.Concat(send, Resources.Constants.FIVE_H_INDENT, txtLine4.Text);
                    flag = 1;
                }
            }

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }

        #endregion

       



    }
}
