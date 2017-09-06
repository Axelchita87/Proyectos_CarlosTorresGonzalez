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
    public partial class ucPhaseIVBySegments : CustomUserControl
    {
        /// <summary>
        /// Descripción: Continuación para realizar la emisión de un boleto de tipo
        ///              fase IV por segmentos.
        /// Creación:    21 Septiembre 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        /// 

        private static string commandbysegments;
        public static string commandBySegments
        {
            get { return commandbysegments; }
            set { commandbysegments = value; }
        }


        private static string segments;
        public static string Segments
        {
            get { return segments; }
            set { segments = value; }
        }

        public ucPhaseIVBySegments()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtSegment1;
            this.LastControlFocus = btnAccept;
        }

        /// <summary>
        /// Realiza las acciones que se deben realizar al cargar el user control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucPhaseIVBySegments_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            SendInitialCommand();
        }

        /// <summary>
        /// Ejecuta las funciones para continuar con el flujo de fase IV
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidBusinessRules)
            {
                BuildSabreCommand();
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_PHASEIV_SELECT_MASK);
                
            }
        }

        #region===== MethodsClass =====

        /// <summary>
        /// Manda el comando inicial al emulador de MySabre para desplegar 
        /// los segmentos del record
        /// </summary>
        private void SendInitialCommand()
        {
            string send = string.Empty;
            send = Resources.TicketEmission.Constants.COMMANDS_AST_I;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
            txtSegment1.Focus();
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
                foreach (Control txt in this.Controls)
                {
                    if (txt is TextBox)
                    {
                        if (!string.IsNullOrEmpty(txt.Text) && txt.TabIndex > 1)
                        {
                            foreach (Control txtnext in this.Controls)
                            {
                                if ((txtnext is TextBox) &&
                                    (txtnext.TabIndex.Equals(txt.TabIndex - 1)) &&
                                    (string.IsNullOrEmpty(txtnext.Text)))
                                {
                                    MessageBox.Show(Resources.TicketEmission.Tickets.NO_ES_POSIBLE_SALTARSE_CAMPOS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    txtnext.Focus();
                                    isValid = false;
                                    return isValid;

                                }
                            }
                        }

                    }
                }
                return isValid;
            }
        }


        /// <summary>
        /// Construye y envia el comando principal del user control al emulador
        /// de MySabre
        /// </summary>
        private void BuildSabreCommand()
        {
            commandbysegments = string.Empty;
            segments = string.Empty;
            string send = string.Empty;
            if (!string.IsNullOrEmpty(txtSegment1.Text))
            {
                send = string.Concat(send,
                    Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_S,
                    txtSegment1.Text);
                segments = txtSegment1.Text.Trim(new char[] { '0' });;

            }

            if (!string.IsNullOrEmpty(txtSegment2.Text))
            {
                send = string.Concat(send,
                    Resources.TicketEmission.Constants.SLASH,
                    txtSegment2.Text);
                segments = string.Concat(segments,
                    Resources.TicketEmission.Constants.PLUS,
                    txtSegment2.Text.Trim(new char[] { '0' }));
            }

            if (!string.IsNullOrEmpty(txtSegment3.Text))
            {
                send = string.Concat(send,
                    Resources.TicketEmission.Constants.SLASH,
                    txtSegment3.Text);
                segments = string.Concat(segments,
                    Resources.TicketEmission.Constants.PLUS,
                    txtSegment3.Text.Trim(new char[] { '0' }));
            }

            if (!string.IsNullOrEmpty(txtSegment4.Text))
            {
                send = string.Concat(send,
                    Resources.TicketEmission.Constants.SLASH,
                    txtSegment4.Text);
                segments = string.Concat(segments,
                    Resources.TicketEmission.Constants.PLUS,
                    txtSegment4.Text.Trim(new char[] { '0' }));
            }

            if (!string.IsNullOrEmpty(txtSegment5.Text))
            {
                send = string.Concat(send,
                    Resources.TicketEmission.Constants.SLASH,
                    txtSegment5.Text);
                segments = string.Concat(segments,
                    Resources.TicketEmission.Constants.PLUS,
                    txtSegment5.Text.Trim(new char[] { '0' }));
            }

            if (!string.IsNullOrEmpty(txtSegment6.Text))
            {
                send = string.Concat(send,
                    Resources.TicketEmission.Constants.SLASH,
                    txtSegment6.Text);
                segments = string.Concat(segments,
                    Resources.TicketEmission.Constants.PLUS,
                    txtSegment6.Text.Trim(new char[] { '0' }));
            }

            if (!string.IsNullOrEmpty(txtSegment7.Text))
            {
                send = string.Concat(send,
                    Resources.TicketEmission.Constants.SLASH,
                    txtSegment7.Text);
                segments = string.Concat(segments,
                    Resources.TicketEmission.Constants.PLUS,
                    txtSegment7.Text.Trim(new char[] { '0' }));
            }

            if (!string.IsNullOrEmpty(txtSegment8.Text))
            {
                send = string.Concat(send,
                    Resources.TicketEmission.Constants.SLASH,
                    txtSegment8.Text);
                segments = string.Concat(segments,
                    Resources.TicketEmission.Constants.PLUS,
                    txtSegment8.Text.Trim(new char[] { '0' }));
            }

            if (!string.IsNullOrEmpty(txtSegment9.Text))
            {
                send = string.Concat(send,
                    Resources.TicketEmission.Constants.SLASH,
                    txtSegment9.Text);
                segments = string.Concat(segments,
                    Resources.TicketEmission.Constants.PLUS,
                    txtSegment9.Text.Trim(new char[] { '0' }));
            }

            if (!string.IsNullOrEmpty(txtSegment10.Text))
            {
                send = string.Concat(send,
                    Resources.TicketEmission.Constants.SLASH,
                    txtSegment10.Text);
                segments = string.Concat(segments,
                    Resources.TicketEmission.Constants.PLUS,
                    txtSegment10.Text.Trim(new char[] { '0' }));
            }

            if (!string.IsNullOrEmpty(txtSegment11.Text))
            {
                send = string.Concat(send,
                    Resources.TicketEmission.Constants.SLASH,
                    txtSegment11.Text);
                segments = string.Concat(segments,
                    Resources.TicketEmission.Constants.PLUS,
                    txtSegment11.Text.Trim(new char[] { '0' }));
            }

            if (!string.IsNullOrEmpty(txtSegment12.Text))
            {
                send = string.Concat(send,
                    Resources.TicketEmission.Constants.SLASH,
                    txtSegment12.Text);
                segments = string.Concat(segments,
                    Resources.TicketEmission.Constants.PLUS,
                    txtSegment12.Text.Trim(new char[] { '0' }));
            }

            if (!string.IsNullOrEmpty(txtSegment13.Text))
            {
                send = string.Concat(send,
                    Resources.TicketEmission.Constants.SLASH,
                    txtSegment13.Text);
                segments = string.Concat(segments,
                    Resources.TicketEmission.Constants.PLUS,
                    txtSegment13.Text.Trim(new char[] { '0' }));
            }

            if (!string.IsNullOrEmpty(txtSegment14.Text))
            {
                send = string.Concat(send,
                    Resources.TicketEmission.Constants.SLASH,
                    txtSegment14.Text);
                segments = string.Concat(segments,
                    Resources.TicketEmission.Constants.PLUS,
                    txtSegment14.Text.Trim(new char[] { '0' }));
            }

            if (!string.IsNullOrEmpty(txtSegment15.Text))
            {
                send = string.Concat(send,
                    Resources.TicketEmission.Constants.SLASH,
                    txtSegment15.Text);
                segments = string.Concat(segments,
                    Resources.TicketEmission.Constants.PLUS,
                    txtSegment15.Text.Trim(new char[] { '0' }));
            }

            if (!string.IsNullOrEmpty(txtSegment16.Text))
            {
                send = string.Concat(send,
                    Resources.TicketEmission.Constants.SLASH,
                    txtSegment16.Text);
                segments = string.Concat(segments,
                    Resources.TicketEmission.Constants.PLUS,
                    txtSegment16.Text.Trim(new char[] { '0' }));
            }

            commandbysegments = send;
            
           
        }


        #endregion//End MethodsClass


        #region ===== Back to a Previous Usercontrol or Validate Enter KeyDown =====

        /// <summary>
        ///  Aborta el proceso al presionar la tecla ESC o continua con el flujo 
        /// de emision de boleto al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData.Equals(Keys.Escape))
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_CREATE_PHASE_IV);
            }
            if (e.KeyData.Equals(Keys.Enter))
            {

                btnAccept_Click(sender, e);

            }
        }
        #endregion//End Back to a Previous Usercontrol or Validate Enter KeyDown


        #region=====Change focus When a Textbox is Full=====
        //evento txtSegment_TextChanged
        private void txtSegment_TextChanged(object sender, EventArgs e)
        {
            SmartTextBox txt = sender as SmartTextBox;
            if (txt.Text.Length > 1)
            {
                foreach (Control control in this.Controls)
                {
                    if (control.TabIndex.Equals(txt.TabIndex + 1))
                    {
                        control.Focus();
                    }
                }
            }
        }

        #endregion//End Change focus When a Textbox is Full



    }
}
