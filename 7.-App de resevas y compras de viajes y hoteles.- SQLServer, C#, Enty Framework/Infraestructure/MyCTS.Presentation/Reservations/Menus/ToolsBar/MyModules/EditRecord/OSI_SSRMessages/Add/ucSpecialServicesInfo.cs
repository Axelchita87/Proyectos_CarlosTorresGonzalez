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
    public partial class ucSpecialServicesInfo : CustomUserControl
    {
        /// <summary>
        /// Descripción: User control que ingresa solicitudes especiales para el 
        ///              servicio otorgado en el record
        /// Creación:    04 diciembre 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>

        public ucSpecialServicesInfo()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtAirline1;
            this.LastControlFocus = btnAccept;
        }


        //Evento Load
        private void ucSpecialServicesInfo_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtAirline1.Focus();
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
        /// Validaciones de Regla de Negocios de las opciones seleccionadas
        /// </summary>
        /// <returns></returns>
        private bool IsValidBusinessRules
        {
            get
            {
                bool isValid = true;
                if (string.IsNullOrEmpty(txtInformation1.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_REQUERIMIENTOS_A_ENVIAR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtInformation1.Focus();
                }
                else if (!string.IsNullOrEmpty(txtAirline2.Text) && string.IsNullOrEmpty(txtInformation2.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_DATOS_COMPLETOS_NUEVA_AEREOLINEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtInformation2.Focus();
                }
                else
                {
                    isValid = false;
                }

                return isValid;
            }
        }

        /// <summary>
        /// Envia el comando correspondiente a la descripción de servicios especiales a MySabre
        /// </summary>
        private void CommandsSend()
        {
            string send = string.Empty;

            if (!string.IsNullOrEmpty(txtAirline1.Text))
            {
                if (txtAirline1.Text.Equals(Resources.Constants.AMERICAN_AIRLINES_CODE))
                {
                    send = string.Concat(Resources.Constants.COMMANDS_4OSI,
                        " ",
                        txtAirline1.Text,
                        " ",
                        txtInformation1.Text);
                }
                else
                {
                    send = string.Concat(Resources.Constants.COMMANDS_3OSI,
                        " ",
                        txtAirline1.Text,
                        " ",
                        txtInformation1.Text);
                }
            }
            else
            {
                send = string.Concat(Resources.Constants.COMMANDS_3OSI,
                    " ",
                    Resources.Constants.COMMANDS_YY,
                    " ",
                    txtInformation1.Text);
            }


            if (!string.IsNullOrEmpty(txtInformation2.Text))
            {
                send = string.Concat(send,
                    Resources.Constants.ENDIT);

                if (!string.IsNullOrEmpty(txtAirline2.Text))
                {
                    if (txtAirline2.Text.Equals(Resources.Constants.AMERICAN_AIRLINES_CODE))
                    {
                        send = string.Concat(send,
                            Resources.Constants.COMMANDS_4OSI,
                            " ",
                            txtAirline2.Text,
                            " ",
                            txtInformation2.Text);
                    }
                    else
                    {
                        send = string.Concat(send,
                            Resources.Constants.COMMANDS_3OSI,
                            " ",
                            txtAirline2.Text,
                            " ",
                            txtInformation2.Text);
                    }
                }
                else
                {
                    send = string.Concat(send,
                        Resources.Constants.COMMANDS_3OSI,
                        " ",
                        Resources.Constants.COMMANDS_YY,
                        " ",
                        txtInformation2.Text);
                }

            }

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }

        #endregion//End MethodsClass


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
