using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Business;
using MyCTS.Entities;

namespace MyCTS.Presentation
{
    public partial class ucRecoverGroup : CustomUserControl
    {

        /// <summary>
        /// Descripcion:Permite recuperar grupo
        /// al flujo de Reservaciones
        /// Creación: Septiembre 23 - 2009 , Modificación:*
        /// Cambio: *    , Solicito *
        /// Autor: Jessica Gutierrez 
        /// </summary>

        private string result;

        public ucRecoverGroup()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtNameGroup;
            this.LastControlFocus = btnAccept;
        }

        // coloca el foco en el primer campo
        private void ucRecoverGroup_Load(object sender, EventArgs e)
        {
            txtNameGroup.Focus();
        }

        /// <summary>
        /// Realiza la validación y envio de comando verificando respuestas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidateBusinessRules)
            {
                CommandsSend();
                APIResponse();
            }
        }

        /// <summary>
        /// Este se usa para todos los controles en general si se oprime 
        /// Esc se manda a el User control de welcome 
        /// Enter se manda la accion de botón de Aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            else if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }

        // Cambio de foco
        private void txtNameGroup_TextChanged(object sender, EventArgs e)
        {
            if (txtNameGroup.Text.Length > 49)
                btnAccept.Focus();
        }

        #region ===== methodsClass =====

        /// <summary>
        /// Valida que existan todos los datos
        /// </summary>
        private bool IsValidateBusinessRules
         {
             get
             {
                 if (string.IsNullOrEmpty(txtNameGroup.Text))
                 {
                     MessageBox.Show(Resources.Group.Group.REQUIERE_INGRESE_NOMBRE_GRUPO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                     txtNameGroup.Focus();
                     return false;
                 }
                 else
                     return true;
             }
         }

        /// <summary>
         /// Envio de comandos
         /// </summary>
        private void CommandsSend()
        {
            string send=string.Empty;
            send = Resources.Group.Constants.COMMANDS_AST_INDENT_B_SLASH;
            send = string.Concat(send, txtNameGroup.Text);
            using (CommandsAPI objCommands = new CommandsAPI())
            {
               result=objCommands.SendReceive(send);
            }
        }

        /// <summary>
        /// Verifica respuesta
        /// </summary>
        private void APIResponse()
        {
            int col = 0;
            int row = 0;
            if ((!string.IsNullOrEmpty(result)))
            {
                CommandsQik.searchResponse(result, Resources.ErrorMessages.ONE, ref col, ref row, 1, 2);
                if (row == 2 && col == 1)
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCRECORDSELECT);
                else
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
        }
        #endregion
    }
}
