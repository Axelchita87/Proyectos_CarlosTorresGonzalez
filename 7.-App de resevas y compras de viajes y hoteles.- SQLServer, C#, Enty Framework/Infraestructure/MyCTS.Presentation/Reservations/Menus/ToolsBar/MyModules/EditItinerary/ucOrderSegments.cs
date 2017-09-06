using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Forms.UI;

namespace MyCTS.Presentation

{
    public partial class ucOrderSegments : CustomUserControl
    {
        /// <summary>
        /// Descripción: User control que ordena los segmentos de un record localizador,
        ///              validando que exista itinerario
        /// Creación:    29 Diciembre 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Angel Trejo Arizmendi
        /// </summary>
        public ucOrderSegments()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtInsert;
            this.LastControlFocus = btnAccept;
        }

        private void ucOrderSegments_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtInsert.Focus();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidateBussinesRules)
            {
                BuildCommand();
 
            }
        }

        #region ===== Methods Class =====

        /// <summary>
        /// Valida las reglas de negocio aplicables a esta mascarilla
        /// </summary>
        private bool IsValidateBussinesRules
        {
            get 
            {
                bool isValid = false;
                if (string.IsNullOrEmpty(txtInsert.Text))
                {
                    MessageBox.Show("DEBES INGRESAR EL NÚMERO DE SEGMENTO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtInsert.Focus();
                }
                else
                    isValid = true;
                return isValid;
 
            }
        }

        /// <summary>
        /// Armado del comando que se envia a sabre
        /// </summary>
        private void BuildCommand()
        {
            bool status = false;
            string sabreAnswer = string.Empty;
            string send = string.Empty;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive("*I");
            }
            int row = 0;
            int col = 0;
            CommandsQik.searchResponse(sabreAnswer, "NO ITIN", ref row, ref col, 1, 5, 1, 64);
            if (row > 0)
            {
                MessageBox.Show("NO EXISTE ITINERARIO PRESENTE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            else 
            {
                send = string.Concat("/", txtInsert.Text);
                if (!string.IsNullOrEmpty(txtSegment1.Text) || !string.IsNullOrEmpty(txtSegment2.Text) ||
                   !string.IsNullOrEmpty(txtSegment3.Text) || !string.IsNullOrEmpty(txtSegment4.Text) ||
                   !string.IsNullOrEmpty(txtSegment5.Text))
                {
                    send = string.Concat(send, "/");
                    if (!string.IsNullOrEmpty(txtSegment1.Text))
                    {
                        send = string.Concat(send, txtSegment1.Text);
                        if (!string.IsNullOrEmpty(txtRange.Text))
                            send = string.Concat(send, "-", txtRange.Text);
                        status = true;
                    }
                    if (!string.IsNullOrEmpty(txtSegment2.Text))
                        if (status)
                            send = string.Concat(send, Resources.Constants.COMMANDS_COMMA, txtSegment2.Text);
                        else
                        {
                            send = string.Concat(send, txtSegment2.Text);
                            status = true;
                        }
                    if (!string.IsNullOrEmpty(txtSegment3.Text))
                        if (status)
                            send = string.Concat(send, Resources.Constants.COMMANDS_COMMA, txtSegment3.Text);
                        else
                        {
                            send = string.Concat(send, txtSegment3.Text);
                            status = true;
                        }
                    if (!string.IsNullOrEmpty(txtSegment4.Text))
                        if (status)
                            send = string.Concat(send, Resources.Constants.COMMANDS_COMMA, txtSegment4.Text);
                        else
                        {
                            send = string.Concat(send, txtSegment4.Text);
                            status = true;
                        }
                    if (!string.IsNullOrEmpty(txtSegment5.Text))
                        if (status)
                            send = string.Concat(send, Resources.Constants.COMMANDS_COMMA, txtSegment5.Text);
                        else
                            send = string.Concat(send, txtSegment5.Text);
                }
                else
                    send = string.Concat(send, "a");
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(send);
                }

                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                    
            }


        }
        #endregion

        #region=====Change focus When a Textbox is Full=====

        //Evento txtControls_TextChanged
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
                            break;
                        }

                    }
                }
            }

        }

        #endregion//End Change focus When a Textbox is Full

        #region =====Back to a Previous Usercontrol or Validate Enter KeyDown=====

        /// <summary>
        /// Regresa al user cotrol welcome cuando se presiona ESC o ejecuta
        /// la acción del botón aceptar cuando se presiona Enter
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

        #endregion // Back to a Previous Usercontrol or Validate Enter KeyDown

        
        
    }
}
