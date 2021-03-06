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
    public partial class ucFrecuentFligher : CustomUserControl
    {

        /// <summary>
        /// Descripción: User Control que permite agregar o eliminar números 
        ///              de viajero frecuente al record. pertenece al menu de Edita
        ///              Record.
        /// Creación:    03 diciembre 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>

        public ucFrecuentFligher()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = rdoAdd;
            this.LastControlFocus = btnAccept;
        }


        //Evento ucFrecuentFligher_Load
        private void ucFrecuentFligher_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            InitialControlStates();
        }

        //Evento btnAccept_Click
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!IsValidBusinessRules)
            {
                if (rdoAdd.Checked.Equals(true))
                {
                    AddFligherSendCommand();
                }
                else if (rdoDelete.Checked.Equals(true))
                    DeleteFligherCommandsSend();
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
        }
        

        #region===== MethodsClass =====


        /// <summary>
        /// Establece los valores iniciales de los controles de esta mascarilla
        /// </summary>
        private void InitialControlStates()
        {
            rdoAdd.Focus();
            ActiveInactiveControls(2, false);
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
                if (rdoDelete.Checked.Equals(true) &&
                   !string.IsNullOrEmpty(txtRange.Text) &&
                   string.IsNullOrEmpty(txtLineNumber.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_NUM_LINEA_INICIO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLineNumber.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtAirline1.Text) && (string.IsNullOrEmpty(txtFFnumber1.Text) || string.IsNullOrEmpty(txtPaxNumber1.Text))) ||
                    (!string.IsNullOrEmpty(txtFFnumber1.Text) && (string.IsNullOrEmpty(txtAirline1.Text) || string.IsNullOrEmpty(txtPaxNumber1.Text))) ||
                    (!string.IsNullOrEmpty(txtPaxNumber1.Text) && (string.IsNullOrEmpty(txtAirline1.Text) || string.IsNullOrEmpty(txtFFnumber1.Text))))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_COD_AEREOLINEA_FF_NUM_PAX_POR_LINEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrEmpty(txtAirline1.Text))
                        txtAirline1.Focus();
                    else if (string.IsNullOrEmpty(txtFFnumber1.Text))
                        txtFFnumber1.Focus();
                    else
                        txtPaxNumber1.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtAirline2.Text) && (string.IsNullOrEmpty(txtFFnumber2.Text) || string.IsNullOrEmpty(txtPaxNumber2.Text))) ||
               (!string.IsNullOrEmpty(txtFFnumber2.Text) && (string.IsNullOrEmpty(txtAirline2.Text) || string.IsNullOrEmpty(txtPaxNumber2.Text))) ||
               (!string.IsNullOrEmpty(txtPaxNumber2.Text) && (string.IsNullOrEmpty(txtAirline2.Text) || string.IsNullOrEmpty(txtFFnumber2.Text))))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_COD_AEREOLINEA_FF_NUM_PAX_POR_LINEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrEmpty(txtAirline2.Text))
                        txtAirline2.Focus();
                    else if (string.IsNullOrEmpty(txtFFnumber2.Text))
                        txtFFnumber2.Focus();
                    else
                        txtPaxNumber2.Focus();
                }
                 else if ((!string.IsNullOrEmpty(txtAirline3.Text) && (string.IsNullOrEmpty(txtFFnumber3.Text) || string.IsNullOrEmpty(txtPaxNumber3.Text))) ||
               (!string.IsNullOrEmpty(txtFFnumber3.Text) && (string.IsNullOrEmpty(txtAirline3.Text) || string.IsNullOrEmpty(txtPaxNumber3.Text))) ||
               (!string.IsNullOrEmpty(txtPaxNumber3.Text) && (string.IsNullOrEmpty(txtAirline3.Text) || string.IsNullOrEmpty(txtFFnumber3.Text))))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_COD_AEREOLINEA_FF_NUM_PAX_POR_LINEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrEmpty(txtAirline3.Text))
                        txtAirline3.Focus();
                    else if (string.IsNullOrEmpty(txtFFnumber3.Text))
                        txtFFnumber3.Focus();
                    else
                        txtPaxNumber3.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtPaxNumber1.Text) && (!ValidateRegularExpression.ValidateOneorTwoPlusDecimalNumber(txtPaxNumber1.Text))))
                {
                    MessageBox.Show(Resources.Reservations.FORMATO_NUM_PAX_ES_INCORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPaxNumber1.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtPaxNumber2.Text) && (!ValidateRegularExpression.ValidateOneorTwoPlusDecimalNumber(txtPaxNumber2.Text))))
                {
                    MessageBox.Show(Resources.Reservations.FORMATO_NUM_PAX_ES_INCORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPaxNumber2.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtPaxNumber3.Text) && (!ValidateRegularExpression.ValidateOneorTwoPlusDecimalNumber(txtPaxNumber3.Text))))
                {
                    MessageBox.Show(Resources.Reservations.FORMATO_NUM_PAX_ES_INCORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPaxNumber3.Focus();
                }
                else
                {
                    isValid = false;
                }

                return isValid;
            }
        }


        /// <summary>
        /// Manda comando a MySabre para agregar un codigo de viajero frecuente
        /// </summary>
        private void AddFligherSendCommand()
        {
            string send = string.Empty;
            string frecuentFligher1 = string.Empty;
            string frecuentFligher2 = string.Empty;
            string frecuentFligher3 = string.Empty;

            
            if (!string.IsNullOrEmpty(txtAirline1.Text))
            {
                frecuentFligher1 = string.Concat(Resources.Constants.COMMANDS_FF,
                    txtAirline1.Text,
                    txtFFnumber1.Text);

                if (!string.IsNullOrEmpty(txtOtherAirline1.Text))
                {
                    frecuentFligher1 = string.Concat(frecuentFligher1,
                        Resources.Constants.SLASH,
                        txtOtherAirline1.Text);
                }

                frecuentFligher1 = string.Concat(frecuentFligher1,
                    Resources.Constants.INDENT,
                    txtPaxNumber1.Text);
            }
            else
                frecuentFligher1 = string.Empty;


            if (!string.IsNullOrEmpty(txtAirline2.Text))
            {
                frecuentFligher2 = string.Concat(Resources.Constants.COMMANDS_FF,
                    txtAirline2.Text,
                    txtFFnumber2.Text);

                if (!string.IsNullOrEmpty(txtOtherAirline2.Text))
                {
                    frecuentFligher2 = string.Concat(frecuentFligher2,
                        Resources.Constants.SLASH,
                        txtOtherAirline2.Text);
                }

                frecuentFligher2 = string.Concat(frecuentFligher2,
                    Resources.Constants.INDENT,
                    txtPaxNumber2.Text);
            }
            else
                frecuentFligher2 = string.Empty;


            if (!string.IsNullOrEmpty(txtAirline3.Text))
            {
                frecuentFligher3 = string.Concat(Resources.Constants.COMMANDS_FF,
                    txtAirline3.Text,
                    txtFFnumber3.Text);

                if (!string.IsNullOrEmpty(txtOtherAirLine3.Text))
                {
                    frecuentFligher3 = string.Concat(frecuentFligher3,
                        Resources.Constants.SLASH,
                        txtOtherAirLine3.Text);
                }

                frecuentFligher3 = string.Concat(frecuentFligher3,
                    Resources.Constants.INDENT,
                    txtPaxNumber3.Text);
            }
            else
                frecuentFligher3 = string.Empty;

            send = string.Concat(frecuentFligher1,
                Resources.Constants.ENDIT,
                frecuentFligher2,
                Resources.Constants.ENDIT,
                frecuentFligher3);

            send = send.TrimStart(new char[] {'Σ'});
            send = send.TrimStart(new char[] {'Σ'});
            send = send.TrimEnd(new char[] { 'Σ' });
            send = send.TrimEnd(new char[] { 'Σ' });
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }


        /// <summary>
        /// Manda comando a MySabre para agregar un codigo de viajero frecuente
        /// </summary>
        private void DeleteFligherCommandsSend()
        {
            string send = string.Empty;
            send = Resources.Constants.COMMANDS_FF;

            if (string.IsNullOrEmpty(txtLineNumber.Text) &&
                string.IsNullOrEmpty(txtRange.Text))
                send = string.Concat(send,
                    Resources.Constants.COMMANDS_CHANGE_ALL);
            else
            {
                send = string.Concat(send,
                    txtLineNumber.Text);
                if (!string.IsNullOrEmpty(txtRange.Text))
                    send = string.Concat(send,
                        Resources.Constants.INDENT,
                        txtRange.Text);
                send = string.Concat(send,
                    Resources.Constants.CHANGE);


            }

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }

        /// <summary>
        /// Activa o desactiva las opciones secundarias deacuerdo al estado
        /// del radiobutton al que pertenece
        /// </summary>
        /// <param name="status">Estado actual del RadioButton que envia la petición de la función</param>
        private void ActiveInactiveControls(int optionId, bool status)
        {
            if (optionId.Equals(1))
            {
                foreach (Control control in pnlAdd.Controls)
                {
                    if (control is TextBox)
                    {
                        if (status)
                        {
                            ((TextBox)control).Enabled = true;
                            ((TextBox)control).BackColor = Color.White;
                        }
                        else
                        {
                           ((TextBox)control).Enabled = false;
                            ((TextBox)control).BackColor = SystemColors.Control;
                            ((TextBox)control).Text = string.Empty;
                        }
                    }

                    if (control is CheckBox)
                        if (status)
                        {
                            ((CheckBox)control).Enabled = true;
                        }
                        else
                        {
                            ((CheckBox)control).Enabled = false;
                            ((CheckBox)control).Checked = false;
                        }

                }
            }
            else if(optionId.Equals(2))
            {
                foreach(Control control in pnlDelete.Controls)
                {
                    if (control is TextBox)
                    {
                        if (status)
                        {
                            this.InitialControlFocus = rdoDelete;
                            ((TextBox)control).Enabled = true;
                            ((TextBox)control).BackColor = Color.White;
                        }
                        else
                        {
                            this.InitialControlFocus = rdoAdd;
                            ((TextBox)control).Enabled = false;
                            ((TextBox)control).BackColor = SystemColors.Control;
                            ((TextBox)control).Text = string.Empty;

                        }
                    }
                }
            }
        }

        #endregion//End MethodsClass



        #region===== EnableDisableControls Events =====

        //Evento rdoDelete_CheckedChanged
        private void rdoDelete_CheckedChanged(object sender, EventArgs e)
        {
            ActiveInactiveControls(2, rdoDelete.Checked);
        }

        //Evento rdoAdd_CheckedChanged
        private void rdoAdd_CheckedChanged(object sender, EventArgs e)
        {
            ActiveInactiveControls(1, rdoAdd.Checked);
        }

        #endregion//End EnableDisableControls Events


        #region=====Change focus When a Textbox is Full=====

        //Evento AddTxtControls_TextChanged
        private void AddTxtControls_TextChanged(object sender, EventArgs e)
        {
            if (sender is SmartTextBox)
            {
                if (((SmartTextBox)sender).Text.Length > ((SmartTextBox)sender).MaxLength - 1)
                {
                    foreach (Control txt in pnlAdd.Controls)
                    {
                        if (txt.TabIndex.Equals(((SmartTextBox)(sender)).TabIndex + 1))
                        {
                            txt.Focus();
                        }

                    }
                }
            }

        }


        //Evento deleteTxtControls_TextChanged
        private void DeleteTxtControls_TextChanged(object sender, EventArgs e)
        {
            if (sender is SmartTextBox)
            {
                if (((SmartTextBox)sender).Text.Length > ((SmartTextBox)sender).MaxLength - 1)
                {
                    foreach (Control txt in pnlDelete.Controls)
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
