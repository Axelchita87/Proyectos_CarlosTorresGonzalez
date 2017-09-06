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
    public partial class ucSpecialServicesSSR : CustomUserControl
    {
        /// <summary>
        /// Descripción: User Control que permite agregar alguna descripción de 
        ///              servicios especiales aplicables a cierto pasajero o segmento del record
        /// Creación:    04 diciembre 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>

        public ucSpecialServicesSSR()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtAirline;
            this.LastControlFocus = btnAccept;
        }


        //Evento Load
        private void ucSpecialServicesSSR_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtAirline.Focus();
            LoadSSRCodes();
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
        /// Carga el catalogo de codigos SSR
        /// </summary>
        private void LoadSSRCodes()
        {
            List<ListItem> ListSSRCodes = CatSSRCodesBL.GetElementsSSRCodes();
            foreach (ListItem SSRCodesItem in ListSSRCodes)
            {
                ListItem litem = new ListItem();
                litem.Text = string.Format("{0} - {1}",
                    SSRCodesItem.Value,
                    SSRCodesItem.Text2);
                litem.Value = SSRCodesItem.Value;
                cmbCode.Items.Add(litem);

            }
            cmbCode.SelectedIndex = 0;
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
                if (cmbCode.SelectedIndex <= 0)
                {
                    MessageBox.Show(Resources.Reservations.SELECCIONA_CODIGO_SERVICIO_ESPECIAL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbCode.Focus();
                }
                else if (string.IsNullOrEmpty(txtPaxNumber.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_NUMERO_PASAJERO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPaxNumber.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtPaxNumber.Text) && (!ValidateRegularExpression.ValidateOneorTwoPlusDecimalNumber(txtPaxNumber.Text))))
                {
                    MessageBox.Show(Resources.Reservations.FORMATO_NUM_PAX_ES_INCORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPaxNumber.Focus();
                }
                else if (string.IsNullOrEmpty(txtDescription.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_DESCRIPCION_SERVICIO_ESPECIAL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDescription.Focus();
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

            if (!string.IsNullOrEmpty(txtAirline.Text) && txtAirline.Text.Equals(Resources.Constants.AMERICAN_AIRLINES_CODE))
                send = string.Concat(Resources.Constants.FOUR,
                    ((ListItem)cmbCode.SelectedItem).Value);
            else
                send = string.Concat(Resources.Constants.THREE,
                    ((ListItem)cmbCode.SelectedItem).Value);

            if (!string.IsNullOrEmpty(txtSegment.Text))
                send = string.Concat(send,
                    txtSegment.Text);

            send = string.Concat(send,
                Resources.Constants.SLASH,
                txtDescription.Text,
                Resources.Constants.INDENT,
                txtPaxNumber.Text);

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
