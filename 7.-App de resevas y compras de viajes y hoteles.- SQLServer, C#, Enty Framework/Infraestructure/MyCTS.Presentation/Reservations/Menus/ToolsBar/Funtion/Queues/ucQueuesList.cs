using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.DataAccess;
using MyCTS.Entities;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucQueuesList : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Realiza una búsqueda de Queue o de Agente
        /// Creación:    10-Diciembre-2010 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Ivan Martínez
        /// </summary>        


        public ucQueuesList()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtQueue;
            this.LastControlFocus = btnAccept;
        }

        private void ucQueuesList_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtQueue.Focus();
        }


        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidBussinessRules)
            {
                CommandsSend();
            }
        }

        #region====Events====

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
            {
                VolarisSession.Clean();
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }

            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }


        #endregion

        #region====MethodsClass====

        //Verifica si los datos obligatorios fueron ingresados
        private bool IsValidBussinessRules
        {
            get
            {
                bool isValid;
                isValid = true;

                return isValid;
            }
        }

        //Envía las instrucciones a MySabre
        private void CommandsSend()
        {
            int row = 0;
            int col = 0;
            string send = string.Empty;
            string res = string.Empty;

            send = "I";
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                res = objCommand.SendReceive(send);
            }

            send = "QS*Q";
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                res = objCommand.SendReceive(send);
                res = res.Replace('‡', '\n');
            }

            if (txtQueue.Text.Length > 0)
            {
                while (row <= 1)
                {
                    CommandsQik.searchResponse(res, txtQueue.Text, ref row, ref col);
                    if (row != 0)
                    {
                        break;
                    }
                    else
                    {
                        send = "MD";
                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            res = objCommand.SendReceive(send);
                            res = res.Replace('‡', '\n');
                        }
                        CommandsQik.searchResponse(res, "END OF SCROLL", ref row, ref col);
                        if (row != 0)
                        {
                            MessageBox.Show("NÚMERO DE QUEUE NO ENCONTRADO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                }
            }

            else if (txtAgentCode.Text.Length > 0)
            {
                while (row <= 1)
                {
                    CommandsQik.searchResponse(res, txtAgentCode.Text, ref row, ref col);
                    if (row != 0)
                    {
                        break;
                    }
                    else
                    {
                        send = "MD";
                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            res = objCommand.SendReceive(send);
                            res = res.Replace('‡', '\n');
                        }
                        CommandsQik.searchResponse(res, "END OF SCROLL", ref row, ref col);
                        if (row != 0)
                        {
                            MessageBox.Show("NÚMERO DE AGENTE NO ENCONTRADO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                }
            }
        }

        #endregion

    }
}
