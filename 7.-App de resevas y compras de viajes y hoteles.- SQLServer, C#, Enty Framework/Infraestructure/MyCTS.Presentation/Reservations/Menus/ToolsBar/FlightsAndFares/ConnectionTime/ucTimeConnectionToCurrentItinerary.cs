using System;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Forms.UI;

namespace MyCTS.Presentation
{
    public partial class ucTimeConnectionToCurrentItinerary : CustomUserControl
    {

        /// <summary>
        /// Descripción: User control que define el tiempo de
        ///              conexión para el itinerario actual 
        /// Creación:    29 de Enere 2010, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Angel Trejo Arizmendi
        /// </summary>
    
        public ucTimeConnectionToCurrentItinerary()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtSegment1;
            this.LastControlFocus = btnAccept;
        }

        private void ucTimeConnectionToCurrentItinerary_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtSegment1.Focus();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if(IsValidBussinesRules)
                BuildCommand();
        }

        #region ===== METHODS CLASS =====

        /// <summary>
        /// Valida las reglas de negocio aplicadas para este user control
        /// </summary>
        private bool IsValidBussinesRules
        {
            get 
            {
                bool isValid = false;
                if (!string.IsNullOrEmpty(txtRange1.Text) && string.IsNullOrEmpty(txtSegment1.Text))
                {
                    MessageBox.Show("DEBES INGRESAR UN SEGMENTO PARA PODER INGRESAR EL RANGO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSegment1.Focus();
                }
                else if (!string.IsNullOrEmpty(txtRange2.Text) && string.IsNullOrEmpty(txtSegment2.Text))
                {
                    MessageBox.Show("DEBES INGRESAR UN SEGMENTO PARA PODER INGRESAR EL RANGO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSegment2.Focus();
                }
                else if (!string.IsNullOrEmpty(txtRange3.Text) && string.IsNullOrEmpty(txtSegment3.Text))
                {
                    MessageBox.Show("DEBES INGRESAR UN SEGMENTO PARA PODER INGRESAR EL RANGO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSegment3.Focus();
                }
                else if (!string.IsNullOrEmpty(txtRange4.Text) && string.IsNullOrEmpty(txtSegment4.Text))
                {
                    MessageBox.Show("DEBES INGRESAR UN SEGMENTO PARA PODER INGRESAR EL RANGO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSegment4.Focus();
                }
                else
                    isValid = true;
                return isValid;
            }
        }

        /// <summary>
        /// Armado del comando que se va enviar a Sabre
        /// </summary>
        private void BuildCommand()
        {
            string send = string.Empty;
            string type = string.Empty;
            send = "VCT*";
            if (!string.IsNullOrEmpty(txtSegment1.Text))
                if (!string.IsNullOrEmpty(txtRange1.Text))
                {
                    send = string.Concat(send, txtSegment1.Text, "-", txtRange1.Text);
                    type = "Range";
                }
                else
                {
                    send = string.Concat(send, txtSegment1.Text);
                    type = "Segment";
                }
            if (!string.IsNullOrEmpty(txtSegment2.Text))
                if (!string.IsNullOrEmpty(txtRange2.Text))
                    if (!string.IsNullOrEmpty(type))
                    {
                        send = string.Concat(send, ",", txtSegment2.Text, "-", txtRange2.Text);
                        type = "Range";
                    }
                    else
                    {
                        send = string.Concat(send, txtSegment2.Text, "-", txtRange2.Text);
                        type = "Range";
                    }
                else
                    if (type.Equals("Segment"))
                        send = string.Concat(send, "/", txtSegment2.Text);
                    else if (type.Equals("Range"))
                    {
                        send = string.Concat(send, ",", txtSegment2.Text);
                        type = "Segment";
                    }
                    else
                    {
                        send = string.Concat(send, txtSegment2.Text);
                        type = "Segment";
                    }
            if (!string.IsNullOrEmpty(txtSegment3.Text))
                if (!string.IsNullOrEmpty(txtRange3.Text))
                    if (!string.IsNullOrEmpty(type))
                    {
                        send = string.Concat(send, ",", txtSegment3.Text, "-", txtRange3.Text);
                        type = "Range";
                    }
                    else
                    {
                        send = string.Concat(send, txtSegment3.Text, "-", txtRange3.Text);
                        type = "Range";
                    }
                else
                    if (type.Equals("Segment"))
                        send = string.Concat(send, "/", txtSegment3.Text);
                    else if (type.Equals("Range"))
                    {
                        send = string.Concat(send, ",", txtSegment3.Text);
                        type = "Segment";
                    }
                    else
                    {
                        send = string.Concat(send, txtSegment3.Text);
                        type = "Segment";
                    }
            if (!string.IsNullOrEmpty(txtSegment4.Text))
                if (!string.IsNullOrEmpty(txtRange4.Text))
                    if (!string.IsNullOrEmpty(type))
                        send = string.Concat(send, ",", txtSegment4.Text, "-", txtRange4.Text);
                    else
                        send = string.Concat(send, txtSegment4.Text, "-", txtRange4.Text);
                else
                    if (type.Equals("Segment"))
                        send = string.Concat(send, "/", txtSegment4.Text);
                    else if (type.Equals("Range"))
                        send = string.Concat(send, ",", txtSegment4.Text);
                    else
                        send = string.Concat(send, txtSegment4.Text);
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }

        #endregion //METHODS CLASS

        #region =====Back to a Previous Usercontrol or Validate Enter KeyDown=====

        /// <summary>
        /// Aborta el proceso al presionar la tecla ESC
        /// o ejecutar las funciones al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            if (e.KeyData.Equals(Keys.Enter))
                btnAccept_Click(sender, e);
        }
        #endregion //Back to a Previous Usercontrol or Validate Enter KeyDown

        #region=====Change focus When a Textbox is Full=====

        /// <summary>
        /// Cambia el foco del los SmartTextBox cuando llegan a
        /// su MaxLengt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtControls_TextChanged(object sender, EventArgs e)
        {
            if (sender is SmartTextBox)
                if (((SmartTextBox)sender).Text.Length > ((SmartTextBox)sender).MaxLength - 1)
                    foreach (Control txt in this.Controls)
                        if (txt.TabIndex.Equals(((SmartTextBox)(sender)).TabIndex + 1))
                        {
                            txt.Focus();
                            break;
                        }
        }

        #endregion //Change focus When a Textbox is Full



    }
}
