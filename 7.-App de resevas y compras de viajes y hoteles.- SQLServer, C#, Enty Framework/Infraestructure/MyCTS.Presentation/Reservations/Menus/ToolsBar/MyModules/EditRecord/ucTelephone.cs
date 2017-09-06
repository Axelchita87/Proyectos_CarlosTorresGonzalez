using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using MyCTS.Forms.UI;

namespace MyCTS.Presentation//.Reservations.Menus.ToolsBar.MyModules.EditRecord
{
    public partial class ucTelephone : CustomUserControl
    {
        /// <summary>
        /// Descripción: User control que agrega telefonos con tipo y extención, 
        ///              y borra linea por rango especificado
        /// Creación:    07 diciembre 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Angel Trejo Arizmendi
        /// </summary>
       
        private string send = string.Empty;

        public ucTelephone()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = rdoAdd;
            this.LastControlFocus = btnAccept;
        }

        private void ucTelephone_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtPhone1.Focus();
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(Resources.Constants.COMMANDS_AST_P9);
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidBussinesRules)
            {
                if(rdoAdd.Checked)
                    BuildCommandAdd();
                else
                    BuildCommandDelete();
                SendCommand();
            }
        }
        #region=====Methods Class=====

        /// <summary>
        /// Valida las reglas de negocio aplicadas a este
        /// user control
        /// </summary>
        private bool IsValidBussinesRules
        {
            get
            {
                bool isValid = false;
                if (rdoAdd.Checked && !string.IsNullOrEmpty(txtPhone1.Text)
                    && string.IsNullOrEmpty(txtType1.Text))
                {
                    MessageBox.Show(Resources.Reservations.DEBES_ING_TIPO_TELEFONO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtType1.Focus();
                }
                else if (rdoAdd.Checked && !string.IsNullOrEmpty(txtPhone2.Text)
                    && string.IsNullOrEmpty(txtType2.Text))
                {
                    MessageBox.Show(Resources.Reservations.DEBES_ING_TIPO_TELEFONO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtType2.Focus();
                }
                else if (rdoAdd.Checked && !string.IsNullOrEmpty(txtPhone3.Text)
                    && string.IsNullOrEmpty(txtType3.Text))
                {
                    MessageBox.Show(Resources.Reservations.DEBES_ING_TIPO_TELEFONO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtType3.Focus();
                }
                else if (rdoAdd.Checked && !string.IsNullOrEmpty(txtPhone4.Text)
                    && string.IsNullOrEmpty(txtType4.Text))
                {
                    MessageBox.Show(Resources.Reservations.DEBES_ING_TIPO_TELEFONO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtType4.Focus();
                }
                else if (rdoAdd.Checked && !string.IsNullOrEmpty(txtType1.Text)
                    && string.IsNullOrEmpty(txtPhone1.Text))
                {
                    MessageBox.Show(Resources.Reservations.DEBES_ING_NUM_TELEFONO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPhone1.Focus();
                }
                else if (rdoAdd.Checked && !string.IsNullOrEmpty(txtType2.Text)
                    && string.IsNullOrEmpty(txtPhone2.Text))
                {
                    MessageBox.Show(Resources.Reservations.DEBES_ING_NUM_TELEFONO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPhone2.Focus();
                }
                else if (rdoAdd.Checked && !string.IsNullOrEmpty(txtType3.Text)
                    && string.IsNullOrEmpty(txtPhone3.Text))
                {
                    MessageBox.Show(Resources.Reservations.DEBES_ING_NUM_TELEFONO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPhone3.Focus();
                }
                else if (rdoAdd.Checked && !string.IsNullOrEmpty(txtType4.Text)
                    && string.IsNullOrEmpty(txtPhone4.Text))
                {
                    MessageBox.Show(Resources.Reservations.DEBES_ING_NUM_TELEFONO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPhone4.Focus();
                }
                else if (rdoAdd.Checked && string.IsNullOrEmpty(txtPhone1.Text)
                    && string.IsNullOrEmpty(txtPhone2.Text) && string.IsNullOrEmpty(txtPhone3.Text)
                    && string.IsNullOrEmpty(txtPhone4.Text))
                {
                    MessageBox.Show(Resources.Reservations.DEBES_ING_ALGUN_NUM_TELEFONO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPhone1.Focus();
                }
                else if (rdoDelete.Checked && string.IsNullOrEmpty(txtLine.Text))
                {
                    MessageBox.Show(Resources.Reservations.DEBES_ING_LINEA_BORRAR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLine.Focus();
                }
                else
                    isValid = true;
                return isValid;
            }
        }

        /// <summary>
        /// Constucción del comando para agregar telefonos
        /// </summary>
        private void BuildCommandAdd()
        {
            bool content = false;
            send = string.Empty;
            send = Resources.Constants.NINE;
            if (!string.IsNullOrEmpty(txtPhone1.Text))
            {
                if(!string.IsNullOrEmpty(txtExt1.Text))
                    send = string.Concat(send, txtPhone1.Text, "x", txtExt1.Text, Resources.Constants.INDENT, txtType1.Text);
                else
                    send = string.Concat(send, txtPhone1.Text, Resources.Constants.INDENT, txtType1.Text);
                content = true;
            }
            if (!string.IsNullOrEmpty(txtPhone2.Text))
            {
                if (content)
                    send = string.Concat(send, Resources.Constants.ENDIT_NINE);
                else
                    content = true;
                if(!string.IsNullOrEmpty(txtExt2.Text))
                    send = string.Concat(send, txtPhone2.Text, "x", txtExt2.Text, Resources.Constants.INDENT, txtType2.Text);
                else
                    send = string.Concat(send, txtPhone2.Text, Resources.Constants.INDENT, txtType2.Text);
            }
            if (!string.IsNullOrEmpty(txtPhone3.Text))
            {
                if (content)
                    send = string.Concat(send, Resources.Constants.ENDIT_NINE);
                else
                    content = true;
                if (!string.IsNullOrEmpty(txtExt3.Text))
                    send = string.Concat(send, txtPhone3.Text, "x", txtExt3.Text, Resources.Constants.INDENT, txtType3.Text);
                else
                    send = string.Concat(send, txtPhone3.Text, Resources.Constants.INDENT, txtType3.Text);
            }
            if (!string.IsNullOrEmpty(txtPhone4.Text))
            {
                if (content)
                    send = string.Concat(send, Resources.Constants.ENDIT_NINE);
                else
                    content = true;
                if (!string.IsNullOrEmpty(txtExt4.Text))
                    send = string.Concat(send, txtPhone4.Text, "x", txtExt4.Text, Resources.Constants.INDENT, txtType4.Text);
                else
                    send = string.Concat(send, txtPhone4.Text, Resources.Constants.INDENT, txtType4.Text);
            }
            
        }
        
        /// <summary>
        /// Construcción del comando para borrar 
        /// lineas telefónicas
        /// </summary>
        private void BuildCommandDelete()
        {
            send = string.Empty;
            send = string.Concat(Resources.Constants.NINE, txtLine.Text, Resources.Constants.COMMANDS_AT);
            if (!string.IsNullOrEmpty(txtRange.Text))
                send = string.Concat(send, Resources.Constants.INDENT, txtRange.Text);
        }

        /// <summary>
        /// Envío del comando al emulador
        /// </summary>
        private void SendCommand()
        {
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }
        #endregion //Methods Class

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
