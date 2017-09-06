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
    public partial class ucPhaseIVDeleteMask : CustomUserControl
    {
        /// <summary>
        /// Descripción: Borra las fases IV dentro de una reservación
        /// Creación:    21 septiembre 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        /// 


        private static string masknumber;
        public static string maskNumber
        {
            get { return masknumber; }
            set { masknumber = value; }
        }

        public ucPhaseIVDeleteMask()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtMaskNumber;
            this.LastControlFocus = btnAccept;
        }

        /// <summary>
        /// Ejecuta las acciones del userControl al ser cargado
        /// </summary>
        private void ucPhaseIVDeleteMask_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            FirstValidations();
        }

        /// <summary>
        /// Ejecuta los metodos correspondientes al hacer click en el boton Aceptar
        /// </summary>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!IsValidBusinessRules)
            {
                SetMaskNumber();
            }
            
        }


        #region===== MethodsClass =====


        /// <summary>
        /// Verifica la existencia de fase IV en el record
        /// </summary>
        private void FirstValidations()
        {
            string send = string.Empty;
            string sabreAnswer = string.Empty;
            int row = 0;
            int col = 0;

            send = Resources.TicketEmission.Constants.COMMANDS_AST_AST_W;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }

            CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.NO_TKT_REC_EXISTS, ref row, ref col, 1, 3, 1, 64);
            if (row != 0 || col != 0)
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.NO_EXISTE_FASE_IV, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                return;
            }

            row = 0;
            col = 0;
            CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.TKT_LIST, ref row, ref col, 1, 3, 1, 64);
            if (!(row == 0 || col == 0))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.NO_EXISTE_FASE_IV, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                return;
            }
        }

        /// <summary>
        /// Validaciones de regla de negocio aplicables a esta mascarilla
        /// </summary>
        /// <returns></returns>
        private bool IsValidBusinessRules
        {
            get
            {
                bool isValid = true;

                if ((!string.IsNullOrEmpty(txtMaskNumber.Text)) && (txtMaskNumber.Text.Equals(Resources.Constants.ZERO)) || (txtMaskNumber.Text.Equals(Resources.Constants.DOUBLEZERO)))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.CERO_NO_PERMITIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaskNumber.Focus();

                }
                else
                {
                    isValid = false;
                }
                return isValid;
            }
        }

        /// <summary>
        /// Carga el numero de mascarilla a borrar
        /// </summary>
        private void SetMaskNumber()
        {
            masknumber = txtMaskNumber.Text;
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_PHASEIV_DELETE_MASK_CONFIRMATION);

        }


        #endregion//End MethodsClass


        #region ===== Back to a Previous Usercontrol or Validate Enter KeyDown =====

        /// <summary>
        ///  Aborta el proceso al presionar la tecla ESC o ejecuta la confirmación
        ///  de borrado de fase IV al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData.Equals(Keys.Escape))
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            if (e.KeyData.Equals(Keys.Enter))
            {

                btnAccept_Click(sender, e);

            }
        }
        #endregion//End Back to a Previous Usercontrol or Validate Enter KeyDown


        #region=====Change focus When a Textbox is Full=====


        //Evento maskNumber_TextChanged
        private void maskNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtMaskNumber.Text.Length > 1)
                btnAccept.Focus();
        }

        #endregion//End Change focus When a Textbox is Full
    }
}
