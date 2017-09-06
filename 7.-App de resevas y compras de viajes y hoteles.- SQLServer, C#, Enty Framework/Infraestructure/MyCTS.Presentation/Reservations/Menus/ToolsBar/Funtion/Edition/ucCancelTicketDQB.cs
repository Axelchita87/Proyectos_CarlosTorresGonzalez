using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using MyCTS.Presentation.Components;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Forms.UI;


namespace MyCTS.Presentation
{
    public partial class ucCancelTicketDQB : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite cancelar boletos por medio del número de boleto,pertenece a Funciones
        /// Creación:    Marzo-Abril 09 , Modificación:13-Julio 17-Sep-10
        /// Cambio:      Mandar un comando diferente,Mandar comand MD para busqueda de boletos
        ///              Quitar los remarks de 5</CNT TKT\>y solo dejar un historico
        ///              Solicito Guillermo
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        #region ====== Declation of Variable =======

        private bool firstentrance;
        private string dk;
        //private string xlmtktvoid;
        private string result;
        private string send;
        private int row = 0;
        private int col = 0;

        #endregion

        public ucCancelTicketDQB()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtNumberTicket;
            this.LastControlFocus = btnAccept;
        }

        //Control User Load
        /// <summary>
        /// Se le asigna el foco a el textbox de Numero de Boleto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucCancelTicketDQB_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtNumberTicket.Focus();
        }

        //Button Accept
        /// <summary>
        /// Se realizan las validaciones despues de que el usuario ingresa datos, 
        /// se mandan los comandos y termina el proceso llamando a otro User Control 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!firstentrance)
            {
                if (IsValidateBusinessRules)
                {
                    CommandsSend();
                    HideInformation();
                }
            }
            else
            {
                if (btnYes.ForeColor == Color.OrangeRed)
                {
                    CommandsSend2();
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
                else if (btnNo.ForeColor == Color.OrangeRed)
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
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

        //Change Focus all Controls
        /// <summary>
        /// Es el cambio de foco entre controles como tiene el mismo 
        /// Length se hizo un ciclo para el cambio entre cada uno de 
        /// los controles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumberLine_TextChanged(object sender, EventArgs e)
        {
            if (txtNumberTicket.Text.Length > 12)
                btnAccept.Focus();
        }

        //Event Click Button Yes
        private void btnYes_Click(object sender, EventArgs e)
        {
            ChangeColorYes();
        }

        //Event Click Button No
        private void btnNo_Click(object sender, EventArgs e)
        {
            ChangeColorNo();
        }

        #region ====== Hide Information ======

        /// <summary>
        /// Oculta algunos controles
        /// </summary>
        private void HideInformation()
        {
            txtNumberTicket.Enabled = false;
            lblCancelTicket.Visible = true;
            btnNo.Visible = true;
            btnYes.Visible = true;
            btnYes.ForeColor = Color.OrangeRed;
            btnNo.ForeColor = Color.Black;
            btnNo.FlatAppearance.BorderColor = Color.White;
            firstentrance = true;
        }

        #endregion

        #region ===== Change Tab =====

        /// <summary>
        /// El evento KeyUp se puso por que solo asi se logro controlar el 
        /// Tabindex de los botones y que pudieran hacer la opcion del enter
        /// para la función del boton Aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYes_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
                ChangeColor();

            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }

        /// <summary>
        /// Se le asigna el cambio del foco entre los controles
        /// de acuerdo a la condición especificada 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
                ChangeColor();

            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }



        private void btnAccept_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtNumberTicket.Enabled == false)
            {
                this.InitialControlFocus = btnYes;
            }
            else
            {
                this.InitialControlFocus = txtNumberTicket;
            }
        }

        #endregion

        #region ===== methodsClass =====

        /// <summary>
        /// Valido que los campos obligatorios no esten vacios y que no 
        /// contengan datos no permitidos.
        /// </summary>
        private bool IsValidateBusinessRules
        {
            get
            {
                string doublezero = Resources.Constants.DOUBLEZERO;
                string zero = Resources.Constants.ZERO;
                string triplezero = Resources.Constants.TRIPLEZERO;

                if (string.IsNullOrEmpty(txtNumberTicket.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_NÚMERO_BOLETO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberTicket.Focus();
                    return false;
                }
                else if (txtNumberTicket.Text.Length < 13)
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESE_MIN_13_DIG, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberTicket.Focus();
                    return false;
                }
                else if (txtNumberTicket.Text.Equals(doublezero) | txtNumberTicket.Text.Equals(zero) |
                   txtNumberTicket.Text.Equals(triplezero))
                {
                    MessageBox.Show(Resources.Reservations.NO_PERMITEN_CEROS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberTicket.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Se envia el comando de acuerdo a los campos ingresados
        /// </summary>
        private void CommandsSend()
        {
            send = Resources.Constants.COMMANDS_WETR_AST_T + txtNumberTicket.Text;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
            //CancelBoletage();
        }

        /// <summary>
        /// Se envia comando para vefificar se que borre el boleto
        /// </summary>
        private void CommandsSend2()
        {
            send = Resources.Constants.COMMANDS_WETRV;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
                objCommand.SendReceive(send);
            }
        }

        /// <summary>
        /// Este por el momento no se ocupa ya que le boleto se ingresa 
        /// en el textbox
        /// </summary>
        private void CancelBoletage()
        {
            CommandsQik.searchResponse(result, Resources.ErrorMessages.VOID_MSG_SENT_WITHIN_BSP_APPROVED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                DK();
                //List<LabelXMLRemarks> listXMLRemarks = LabelXMLRemarksBL.GetLabelXMLRemarks(dk, "Cancellation","01" , txtNumberTicket.Text);
                //xlmtktvoid = listXMLRemarks[0].XMLFutureLabel;
                GetAndSetAttribute1 Attribute = GetAndSetAttribute1BL.GetAttribute(dk);
                List<LabelXMLRemarks> listXMLRemarks =
                       LabelXMLRemarksBL.GetLabelXMLRemarks(Attribute.Attribute1.ToString(), "Cancellation", txtNumberTicket.Text);

                //using (CommandsAPI objCommand = new CommandsAPI())
                //{
                //    objCommand.SendReceive(xlmtktvoid, 0, 0);
                //}
                string[] sendInfo = new string[] { txtNumberTicket.Text };
                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCBOLETAGE_RECEIVED, sendInfo);
            }
        }

        /// <summary>
        /// En esta funcion extrae el DK, primero se manda un comando
        /// despues se buscada una frase y si la encuentra copia el DK
        /// pero por el momento tampoco se usa
        /// </summary>
        private void DK()
        {
            send = Resources.TicketEmission.Constants.COMMANDS_AST_PDK;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                result = objCommand.SendReceive(send, 0, 0);
            }
            CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.CUSTOMER_NUMBER, ref row, ref col, 1, 2, 1, 64);
            if (row != 0 || col != 0)
            {
                dk = string.Empty;
                CommandsQik.CopyResponse(result, ref dk, row, 19, 6);
            }
        }

        #region ===== Commons =====

        /// <summary>
        /// Esta funcion se encarga de cambiar los colores de los botones
        /// deacuerdo al que este seleccionado
        /// </summary>
        private void ChangeColorYes()
        {
            btnYes.ForeColor = Color.OrangeRed;
            btnNo.ForeColor = Color.Black;
            btnNo.FlatAppearance.BorderColor = Color.White;
        }

        /// <summary>
        /// Esta funcion se encarga de cambiar los colores de los botones
        /// deacuerdo al que este seleccionado
        /// </summary>
        private void ChangeColorNo()
        {
            btnNo.ForeColor = Color.OrangeRed;
            btnYes.ForeColor = Color.Black;
            btnYes.FlatAppearance.BorderColor = Color.White;
        }

        /// <summary>
        /// Esta funcion se encarga de cambiar los colores de los botones
        /// deacuerdo al que este seleccionado
        /// </summary>
        private void ChangeColor()
        {
            btnNo.ForeColor = Color.Black;
            btnNo.FlatAppearance.BorderColor = Color.White;
            btnYes.ForeColor = Color.Black;
            btnYes.FlatAppearance.BorderColor = Color.White;
        }

        #endregion 

        #endregion



    }
}
