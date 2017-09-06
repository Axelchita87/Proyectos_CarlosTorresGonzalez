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
    public partial class ucPhaseIVBreakDown : CustomUserControl
    {
        /// <summary>
        /// Descripción: Ingreso de la linea de calculo para fase IV
        /// Creación:    21 Septiembre 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        /// 

        private static string breakdown;
        public static string breakDown
        {
            get { return breakdown; }
            set { breakdown = value; }
        }

        public static string previousValue = string.Empty;

        public ucPhaseIVBreakDown()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtCalculationLine;
            this.LastControlFocus = btnAccept;
        }


        /// <summary>
        /// Carga metodos iniciales de la mascarilla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucPhaseIVBreakDown_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            if (!string.IsNullOrEmpty(previousValue))
                txtCalculationLine.Text = previousValue;
            txtCalculationLine.Focus();
            
        }


        /// <summary>
        /// Ejecuta los metodos necesarios al dar click en el boton Aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidBusinessRules)
            {
                BuildCommand();
                previousValue = txtCalculationLine.Text;
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_PHASEIV_SEND_COMMANDS);
                
            }
        }


        #region===== MethodsClass =====


        /// <summary>
        /// Armado del comando de linea contable
        /// </summary>
        private void BuildCommand()
        {
            string send = string.Empty;
            breakdown = string.Empty;
            send = Resources.TicketEmission.Constants.COMMANDS_W_CROSSLORAINE_I;
            if (!string.IsNullOrEmpty(ucPhaseIVSelectMask.maskNumber))
                send = string.Concat(send,
                    ucPhaseIVSelectMask.maskNumber);
            send = string.Concat(send,
                Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_C,
                txtCalculationLine.Text);

            if (string.IsNullOrEmpty(ucPhaseIVCalculationLine.sabreCommandFareCalculation))
            {
                send = string.Concat(send,
                    ucPhaseIVCalculationLine.sabreCommandFareCalculation);
            }
            breakdown = send;
        }


        /// <summary>
        ///Validacion de reglas de negocio para esta mascarilla
        /// </summary>
        /// <returns></returns>
        private bool IsValidBusinessRules
        {
            get
            {
                bool isValid = true;

                if (string.IsNullOrEmpty(txtCalculationLine.Text))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.DEBES_INGRESAR_LINEA_CALCULO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isValid = false;
                }

                return isValid;
            }
        }
        #endregion//End MethodsClass

        #region =====Back to a Previous Usercontrol or Validate Enter KeyDown=====


        /// <summary>
        /// Regreso a la mascarilla de "Linea de calculo" al presionar la tecla ESC
        /// o ejecutar las funciones al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData.Equals(Keys.Escape))
                if (ucMenuReservations.phaseIV)
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_PHASEIV_CALCULATION_LINE);
                else
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_PHASEIV_CALCULATION_LINE_RWD);
            if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }
        }


        #endregion//Back to a Previous Usercontrol or Validate Enter KeyDown



        #region=====Change focus When a Textbox is Full=====

        //Evento txtControl_TextChanged
        private void txtControl_TextChanged(object sender, EventArgs e)
        {
            if (txtCalculationLine.Text.Length > 499)
            {
                btnAccept.Focus();
            }
        }

        #endregion//End Change focus When a Textbox is Full


    }
}