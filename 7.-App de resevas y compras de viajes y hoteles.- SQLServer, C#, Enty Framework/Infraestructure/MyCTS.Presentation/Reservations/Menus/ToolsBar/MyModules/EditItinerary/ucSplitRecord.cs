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
    public partial class ucSplitRecord : CustomUserControl
    {

        /// <summary>
        /// Descripción: User Control que permite dividir el record por numero de 
        ///              pasajero
        /// Creación:    29 diciembre 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        /// 
        public ucSplitRecord()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtPassenger1;
            this.LastControlFocus = btnAccept;
        }

        public static bool IsSplitRecord = false;

        //Evento Load
        private void ucSplitRecord_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            
            if (!InitialValidation())
            {
                txtPassenger1.Focus();
            }
            else
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            
        }



        //Evento btnAccept_Click
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!IsValidBusinessRules)
            {
                CommandsSend();
                SegmentProtectionValidation();
                IsSplitRecord = true;
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCBOLETAGE_RECEIVED);
                
            }
        }

        #region===== MethodsClass =====

        private bool InitialValidation()
        {
            string send = string.Empty;
            string sabreAnswer = string.Empty;
            int col = 0;
            int row = 0;
            bool isMessageShown = false;
            send = Resources.Constants.COMMANDS_AST_N_AST_I;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }


            CommandsQik.searchResponse(sabreAnswer, "NO ITIN", ref row, ref col, 1, 5, 1, 64);
            if (row != 0 || col != 0)
            {
                MessageBox.Show("NO EXISTE ITINERARIO PRESENTE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isMessageShown = true;
                return isMessageShown;
            }

            CommandsQik.searchResponse(sabreAnswer, "NO NAMES", ref row, ref col, 1, 5, 1, 64);
            if (row != 0 || col != 0)
            {
                MessageBox.Show("NO EXITEN NOMBRES EN EL RECORD", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isMessageShown = true;
                return isMessageShown;
            }
            CommandsQik.searchResponse(sabreAnswer, "NO DATA", ref row, ref col, 1, 5, 1, 64);
            if (row != 0 || col != 0)
            {
                MessageBox.Show("NO EXISTE ITINERARIO PRESENTE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isMessageShown = true;
                return isMessageShown;
            }
            return isMessageShown;

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
                if (string.IsNullOrEmpty(txtPassenger1.Text) &&
                    string.IsNullOrEmpty(txtPassenger2.Text) &&
                    string.IsNullOrEmpty(txtPassenger3.Text) &&
                    string.IsNullOrEmpty(txtPassenger4.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_SIQUIERA_POS_PAX, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassenger1.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtPassenger1.Text) && (!ValidateRegularExpression.ValidateOneorTwoPlusDecimalNumber(txtPassenger1.Text))))
                {
                    MessageBox.Show(Resources.Reservations.FORMATO_POSICION_PAX_INCORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassenger1.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtPassenger2.Text) && (!ValidateRegularExpression.ValidateOneorTwoPlusDecimalNumber(txtPassenger2.Text))))
                {
                    MessageBox.Show(Resources.Reservations.FORMATO_POSICION_PAX_INCORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassenger2.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtPassenger3.Text) && (!ValidateRegularExpression.ValidateOneorTwoPlusDecimalNumber(txtPassenger3.Text))))
                {
                    MessageBox.Show(Resources.Reservations.FORMATO_POSICION_PAX_INCORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassenger3.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtPassenger4.Text) && (!ValidateRegularExpression.ValidateOneorTwoPlusDecimalNumber(txtPassenger4.Text))))
                {
                    MessageBox.Show(Resources.Reservations.FORMATO_POSICION_PAX_INCORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassenger4.Focus();
                }
                else
                {
                    isValid = false;
                }

                return isValid;
            }
        }


        private void CommandsSend()
        {
            string send = Resources.Constants.COMMANDS_D;

            if (!string.IsNullOrEmpty(txtPassenger1.Text))
                send = string.Concat(send,
                    txtPassenger1.Text);

            if (!string.IsNullOrEmpty(txtPassenger2.Text))
                send = string.Concat(send,
                    Resources.Constants.AST,
                    txtPassenger2.Text);

            if (!string.IsNullOrEmpty(txtPassenger3.Text))
                send = string.Concat(send,
                    Resources.Constants.AST,
                    txtPassenger3.Text);

            if (!string.IsNullOrEmpty(txtPassenger4.Text))
                send = string.Concat(send,
                    Resources.Constants.AST,
                    txtPassenger4.Text);

            if (send[1].Equals('*'))
                send = send.Remove(1, 1);
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }


        /// <summary>
        /// Inserta segmento de proteccion
        /// </summary>
        public void SegmentProtectionValidation()
        {
            string sabreAnswer = string.Empty;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(Resources.Constants.COMMANDS_AST_IO);
            }

            if ((!string.IsNullOrEmpty(sabreAnswer)))
            {
                ERR_ConcludeReservation.err_concludereservation(sabreAnswer);

                if (!ERR_ConcludeReservation.Segment)
                {
                    SegmentProtection();
                }
            }
        }



        /// <summary>
        /// Calcula la fecha del segmento de proteccion
        /// </summary>
        private void SegmentProtection()
        {
            string send = string.Empty;
            string datefinal = string.Empty;
            DateTime lastDate = DateTime.Now.AddDays(300);

            datefinal = lastDate.ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();

            send = string.Format(Resources.Constants.COMMANDS_SEGMENT_PROTECTION,
                    datefinal);


            using (CommandsAPI objCommand = new CommandsAPI())
            {
                string result = objCommand.SendReceive(Resources.Constants.COMMANDS_AST_I, 0, 0);
                string[] temp = result.Split(new char[]{'\n'});
                for (int i = temp.Length - 1; i >= temp.Length - 2; i--)
                {
                    if (!string.IsNullOrEmpty(temp[i]) && 
                        !temp[i].Contains(Resources.TicketEmission.ValitationLabels.ARUNK))
                    {
                        objCommand.SendReceive(Resources.Constants.COMMANDS_0A);
                        return;
                    }
                }
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
