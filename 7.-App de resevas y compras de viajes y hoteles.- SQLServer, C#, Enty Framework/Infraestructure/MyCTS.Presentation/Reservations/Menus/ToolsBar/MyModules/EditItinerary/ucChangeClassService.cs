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
    public partial class ucChangeClassService : CustomUserControl
    {
        /// <summary>
        /// Descripción: User Control que permite modificar la clase de servicio
        ///              de los segmentos aereos presentes en el record
        /// Creación:    23 diciembre 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>

        public ucChangeClassService()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtSegment1;
            this.LastControlFocus = btnAccept;
        }
        //Evento Load
        private void ucChangeSegmentStatus_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            SendInitialCommand();
            txtSegment1.Focus();
        }


        //Evento btnAccept_Click
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!IsValidBusinessRules)
            {
                CommandsSend();
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }

        }


        #region===== MethodsClass =====

        /// <summary>
        /// Manda comando para desplegar los segmentos presentes en el record
        /// </summary>
        private void SendInitialCommand()
        {
            string send = Resources.Constants.COMMANDS_AST_IA;

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
            
        }



        /// <summary>
        /// Validaciones de Regla de Negocios de las opciones seleccionadas
        /// </summary>
        /// <returns></returns>
        private bool IsValidBusinessRules
        {
            get
            {
                bool isValid = true;
                if (string.IsNullOrEmpty(txtSegment1.Text) && (!string.IsNullOrEmpty(txtRange1.Text) || !string.IsNullOrEmpty(txtClass1.Text)))
                {
                    MessageBox.Show(Resources.Reservations.DEBES_INGRESAR_NUMERO_SEGMENTO_INICIALMENTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSegment1.Focus();
                }
                else if (string.IsNullOrEmpty(txtSegment2.Text) && (!string.IsNullOrEmpty(txtRange2.Text) || !string.IsNullOrEmpty(txtClass2.Text)))
                {
                    MessageBox.Show(Resources.Reservations.DEBES_INGRESAR_NUMERO_SEGMENTO_INICIALMENTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSegment2.Focus();
                }
                else if (string.IsNullOrEmpty(txtSegment3.Text) && (!string.IsNullOrEmpty(txtRange3.Text) || !string.IsNullOrEmpty(txtClass3.Text)))
                {
                    MessageBox.Show(Resources.Reservations.DEBES_INGRESAR_NUMERO_SEGMENTO_INICIALMENTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSegment3.Focus();
                }
                else if (string.IsNullOrEmpty(txtSegment4.Text) && (!string.IsNullOrEmpty(txtRange4.Text) || !string.IsNullOrEmpty(txtClass4.Text)))
                {
                    MessageBox.Show(Resources.Reservations.DEBES_INGRESAR_NUMERO_SEGMENTO_INICIALMENTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSegment4.Focus();
                }
                else
                    if (!string.IsNullOrEmpty(txtSegment1.Text) && string.IsNullOrEmpty(txtClass1.Text))
                    {
                        MessageBox.Show(Resources.Reservations.DEBES_INGRESAR_CLASE_DE_SERVICIO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtClass1.Focus();
                    }
                    else if (!string.IsNullOrEmpty(txtSegment2.Text) && string.IsNullOrEmpty(txtClass2.Text))
                    {
                        MessageBox.Show(Resources.Reservations.DEBES_INGRESAR_CLASE_DE_SERVICIO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtClass2.Focus();
                    }
                    else if (!string.IsNullOrEmpty(txtSegment3.Text) && string.IsNullOrEmpty(txtClass3.Text))
                    {
                        MessageBox.Show(Resources.Reservations.DEBES_INGRESAR_CLASE_DE_SERVICIO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtClass3.Focus();
                    }
                    else if (!string.IsNullOrEmpty(txtSegment4.Text) && string.IsNullOrEmpty(txtClass4.Text))
                    {
                        MessageBox.Show(Resources.Reservations.DEBES_INGRESAR_CLASE_DE_SERVICIO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtClass4.Focus();
                    }
                    else if (txtSegment1.Text.Equals(Resources.Constants.ZERO) || txtSegment1.Text.Equals(Resources.Constants.DOUBLEZERO))
                    {
                        MessageBox.Show(Resources.Reservations.CERO_NO_PERMITIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSegment1.Focus();
                    }
                    else if (txtSegment2.Text.Equals(Resources.Constants.ZERO) || txtSegment2.Text.Equals(Resources.Constants.DOUBLEZERO))
                    {
                        MessageBox.Show(Resources.Reservations.CERO_NO_PERMITIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSegment2.Focus();
                    }
                    else if (txtSegment3.Text.Equals(Resources.Constants.ZERO) || txtSegment3.Text.Equals(Resources.Constants.DOUBLEZERO))
                    {
                        MessageBox.Show(Resources.Reservations.CERO_NO_PERMITIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSegment3.Focus();
                    }
                    else if (txtSegment4.Text.Equals(Resources.Constants.ZERO) || txtSegment4.Text.Equals(Resources.Constants.DOUBLEZERO))
                    {
                        MessageBox.Show(Resources.Reservations.CERO_NO_PERMITIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSegment4.Focus();
                    }
                    else if (txtRange1.Text.Equals(Resources.Constants.ZERO) || txtRange1.Text.Equals(Resources.Constants.DOUBLEZERO))
                    {
                        MessageBox.Show(Resources.Reservations.CERO_NO_PERMITIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtRange1.Focus();
                    }
                    else if (txtRange2.Text.Equals(Resources.Constants.ZERO) || txtRange2.Text.Equals(Resources.Constants.DOUBLEZERO))
                    {
                        MessageBox.Show(Resources.Reservations.CERO_NO_PERMITIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtRange2.Focus();
                    }
                    else if (txtRange3.Text.Equals(Resources.Constants.ZERO) || txtRange3.Text.Equals(Resources.Constants.DOUBLEZERO))
                    {
                        MessageBox.Show(Resources.Reservations.CERO_NO_PERMITIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtRange3.Focus();
                    }
                    else if (txtRange4.Text.Equals(Resources.Constants.ZERO) || txtRange4.Text.Equals(Resources.Constants.DOUBLEZERO))
                    {
                        MessageBox.Show(Resources.Reservations.CERO_NO_PERMITIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtRange4.Focus();
                    }
                    else
                    {
                        isValid = false;
                    }

                return isValid;
            }
        }
        /// <summary>
        /// Manda el comando respectivo a Sabre para alterar el status del record
        /// </summary>
        private void CommandsSend()
        {
            string send = Resources.Constants.COMMANDS_WC;

            if (!string.IsNullOrEmpty(txtSegment1.Text))
                send = string.Concat(send,
                    txtSegment1.Text,
                    (!string.IsNullOrEmpty(txtRange1.Text)) ? Resources.Constants.INDENT + txtRange1.Text : string.Empty,
                    txtClass1.Text);

            if (send.Equals(Resources.Constants.COMMANDS_WC))
            {
                if (!string.IsNullOrEmpty(txtSegment2.Text))
                    send = string.Concat(send,
                        txtSegment2.Text,
                        (!string.IsNullOrEmpty(txtRange2.Text)) ? Resources.Constants.INDENT + txtRange2.Text : string.Empty,
                        txtClass2.Text);
            }
            else
            {
                if (!string.IsNullOrEmpty(txtSegment2.Text))
                    send = string.Concat(send,
                        Resources.Constants.SLASH,
                        txtSegment2.Text,
                        (!string.IsNullOrEmpty(txtRange2.Text)) ? Resources.Constants.INDENT + txtRange2.Text : string.Empty,
                        txtClass2.Text);
            }
            if (send.Equals(Resources.Constants.COMMANDS_WC))
            {
                if (!string.IsNullOrEmpty(txtSegment3.Text))
                    send = string.Concat(send,
                        txtSegment3.Text,
                        (!string.IsNullOrEmpty(txtRange3.Text)) ? Resources.Constants.INDENT + txtRange3.Text : string.Empty,
                        txtClass3.Text);
            }
            else
            {
                if (!string.IsNullOrEmpty(txtSegment3.Text))
                    send = string.Concat(send,
                        Resources.Constants.SLASH,
                        txtSegment3.Text,
                        (!string.IsNullOrEmpty(txtRange3.Text)) ? Resources.Constants.INDENT + txtRange3.Text : string.Empty,
                        txtClass3.Text);
            }
            if (send.Equals(Resources.Constants.COMMANDS_WC))
            {
                if (!string.IsNullOrEmpty(txtSegment4.Text))
                    send = string.Concat(send,
                        txtSegment4.Text,
                        (!string.IsNullOrEmpty(txtRange4.Text)) ? Resources.Constants.INDENT + txtRange4.Text : string.Empty,
                        txtClass4.Text);
            }
            else
            {
                if (!string.IsNullOrEmpty(txtSegment4.Text))
                    send = string.Concat(send,
                        Resources.Constants.SLASH,
                        txtSegment4.Text,
                        (!string.IsNullOrEmpty(txtRange4.Text)) ? Resources.Constants.INDENT + txtRange4.Text : string.Empty,
                        txtClass4.Text);
            }

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }
        

        #endregion//End MethodsClass


        #region=====Change focus When a Textbox is Full=====

        //Evento deleteTxtControls_TextChanged
        private void txtControls_TextChanged(object sender, EventArgs e)
        {
            if (sender is SmartTextBox)
            {
                if (((SmartTextBox)sender).Text.Length > ((SmartTextBox)sender).MaxLength - 1)
                {
                    foreach (Control txt in this.Controls)
                    {
                        if (txt.TabIndex.Equals(((SmartTextBox)(sender)).TabIndex + 1))
                        {
                            txt.Focus();
                        }

                    }
                }
            }

        }

        #endregion//End Change focus When a Textbox is Full


        #region =====Back to a Previous Usercontrol or Validate Enter KeyDown=====


        /// <summary>
        /// Aborta el proceso al presionar la tecla ESC o ejecuta las 
        /// instrucciones al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData.Equals(Keys.Escape))
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);



            if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }


        }


        #endregion//End Back to a Previous Usercontrol or Validate Enter KeyDown

        
    }
}
