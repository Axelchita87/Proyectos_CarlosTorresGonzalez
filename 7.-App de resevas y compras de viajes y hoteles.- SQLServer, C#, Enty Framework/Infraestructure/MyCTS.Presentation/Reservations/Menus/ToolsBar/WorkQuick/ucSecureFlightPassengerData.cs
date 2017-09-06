using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Forms.UI;

namespace MyCTS.Presentation
{
    public partial class ucSecureFlightPassengerData : CustomUserControl
    {
        string sex=string.Empty;
        string option = string.Empty;
        bool endReservation=false;
        bool ticketEmission = false;
        public static bool secureFlightPassenger=false;
        private string sabreAnswer = string.Empty;

        public ucSecureFlightPassengerData()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtSegmentAssign1;
            this.LastControlFocus = btnAccept;
        }

        private void ucSecureFlightPassengerData_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            if (ucEndReservation.EndReservation)
            {
                if (this.Parameters != null)
                {
                    option = this.Parameters[0];
                    endReservation = true;
                }
            }

            ucEndReservation.EndReservation = false;

            txtSegmentAssign1.Focus();   
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidateBusinessRules)
            {
                CommandsSend();
                if (endReservation)
                {
                    secureFlightPassenger = true;
                    string[] sendInfo = new string[] { option};
                    Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCENDRESERVATION, sendInfo);
                }
                else
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

        #region=======Change focus all controls=======

        /// <summary>
        /// Es el cambio de foco entre controles como tiene el mismo 
        /// Length se hizo un ciclo para el cambio entre cada uno de 
        /// los controles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOption_Changed(object sender, EventArgs e)
        {
            SmartTextBox txt = sender as SmartTextBox;
            if (txt.Text.Length > 1)
            {
                int indexControl = GetIndexControl(txt);
                SmartTextBox[] arrTextBox = new SmartTextBox[] { txtSegmentAssign1, txtSegmentAssign2, txtSegmentAssign3, txtSegmentAssign4, txtSegmentAssign5, txtSegmentAssign6, txtSegmentAssign7, txtSegmentAssign8};
                int numelements = arrTextBox.Length;
                string segmentsPendings = string.Empty;
                bool first = false;
                int firstElement = 0;
                for (int i = 0; i <= indexControl; i++)
                {
                    if (string.IsNullOrEmpty(arrTextBox[i].Text))
                    {
                        if (!first)
                            firstElement = i;
                        segmentsPendings += "Segmento " + (i + 1).ToString() + "\n";
                        first = true;
                    }
                }
                if (!string.IsNullOrEmpty(segmentsPendings))
                {
                    MessageBox.Show(string.Format("Para ingresar segmento {0} debes ingresar:\n\n{1}", (indexControl + 1).ToString(), segmentsPendings),
                        Resources.Constants.MYCTS,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    arrTextBox[indexControl].Text = string.Empty;
                    arrTextBox[firstElement].Focus();
                }
                else
                {
                    Control c = txt.NextControl;
                    if (c != null) c.Focus();
                }
            }
        }

        private int GetIndexControl(SmartTextBox txtCurrentControl)
        {
            SmartTextBox[] txt = new SmartTextBox[] { txtSegmentAssign1, txtSegmentAssign2, txtSegmentAssign3, txtSegmentAssign4, txtSegmentAssign5, txtSegmentAssign6, txtSegmentAssign7, txtSegmentAssign8};
            int numelements = txt.Length;

            for (int i = 0; i < numelements; i++)
            {
                if (txt[i].Name.Equals(txtCurrentControl.Name))
                    return i;
            }
            return 0;
        }

        private void txtSegmentAssign8_TextChanged(object sender, EventArgs e)
        {
            if (txtSegmentAssign8.Text.Length > 1)
                chkSegmentAll.Focus();
        }

        private void txtBirthday_TextChanged(object sender, EventArgs e)
        {
            if (txtBirthday.Text.Length > 6)
                rdoMale.Focus();
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            if (txtLastName.Text.Length > 19)
                txtLastName2.Focus();
        }

        private void txtLastName2_TextChanged(object sender, EventArgs e)
        {
             if(txtLastName2.Text.Length > 19)
                txtFirstName.Focus();
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            if (txtFirstName.Text.Length > 19)
                txtSecondName.Focus();
        }

        private void txtSecondName_TextChanged(object sender, EventArgs e)
        {
            if (txtSecondName.Text.Length > 19)
                txtPositionPassenger.Focus();
        }

        private void txtPositionPassenger_TextChanged(object sender, EventArgs e)
        {
            if (txtPositionPassenger.Text.Length > 3)
                chkAmericanAirLines.Focus();
        }

        private void rdoMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoMale.Checked)
                sex = "M";
        }

        private void rdoMaleInfant_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoMaleInfant.Checked)
                sex = "MI";
        }

        private void rdoFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoFemale.Checked)
                sex = "F";
        }

        private void rdoFemaleInfant_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoFemaleInfant.Checked)
                sex = "FI";
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
                bool isValid = false;
                string doublezero = Resources.Constants.DOUBLEZERO;
                string zero = Resources.Constants.ZERO;
                if (txtSegmentAssign1.Text.Equals(doublezero) | txtSegmentAssign2.Text.Equals(doublezero) |
                    txtSegmentAssign3.Text.Equals(doublezero) | txtSegmentAssign4.Text.Equals(doublezero) |
                    txtSegmentAssign5.Text.Equals(doublezero) | txtSegmentAssign6.Text.Equals(doublezero) |
                    txtSegmentAssign6.Text.Equals(doublezero) | txtSegmentAssign7.Text.Equals(doublezero) |
                    txtSegmentAssign8.Text.Equals(doublezero) |
                    txtSegmentAssign1.Text.Equals(zero) | txtSegmentAssign2.Text.Equals(zero) |
                    txtSegmentAssign3.Text.Equals(zero) | txtSegmentAssign4.Text.Equals(zero) |
                    txtSegmentAssign5.Text.Equals(zero) | txtSegmentAssign6.Text.Equals(zero) |
                    txtSegmentAssign6.Text.Equals(zero) | txtSegmentAssign7.Text.Equals(zero) |
                    txtSegmentAssign8.Text.Equals(zero))
                {
                    MessageBox.Show(Resources.Reservations.NO_PERMITEN_CEROS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (string.IsNullOrEmpty(txtSegmentAssign1.Text) &&
                            !chkSegmentAll.Checked)
                {
                    MessageBox.Show("REQUIERE INGRESAR LOS SEGMENTOS A ASIGNAR", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSegmentAssign1.Focus();
                }
                else if (string.IsNullOrEmpty(txtBirthday.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR FECHA DE NACIMIENTO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBirthday.Focus();
                }
                else if (!string.IsNullOrEmpty(txtBirthday.Text)&&
                    !ValidateRegularExpression.ValidateBirthDateFormat(txtBirthday.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR FORMATO DE FECHA DE NACIMIENTO VALIDO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBirthday.Focus();
                }
                else if (!rdoFemale.Checked && !rdoFemaleInfant.Checked &&
                         !rdoMale.Checked && !rdoMaleInfant.Checked)
                {
                    MessageBox.Show("REQUIERE INGRESAR SEXO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rdoMale.Focus();
                }
                else if (string.IsNullOrEmpty(txtLastName.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR APELLIDO PATERNO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLastName.Focus();
                }
                //else if (string.IsNullOrEmpty(txtLastName2.Text))
                //{
                //    MessageBox.Show("REQUIERE INGRESAR APELLIDO PATERNO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtLastName2.Focus();
                //}
                else if (string.IsNullOrEmpty(txtFirstName.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR PRIMER NOMBRE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFirstName.Focus();
                }
                else if (string.IsNullOrEmpty(txtPositionPassenger.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR POSICION DE PASAJERO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPositionPassenger.Focus();
                }
                else if (!string.IsNullOrEmpty(txtPositionPassenger.Text) &&
                    !ValidateRegularExpression.ValidateOneorTwoPlusDecimalNumber(txtPositionPassenger.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR POSICION DE PASAJERO VALIDO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPositionPassenger.Focus();
                }
                else
                    isValid = true;
                return isValid;
            }
        }

        private void CommandsSend()
        {
            string send = string.Empty;
            string segment = string.Empty;

            if (chkSegmentAll.Checked)
                segment = "A";
            else
            {
                if(!string.IsNullOrEmpty(txtSegmentAssign1.Text))
                segment = string.Concat(txtSegmentAssign1.Text);
                if (!string.IsNullOrEmpty(txtSegmentAssign2.Text))
                    segment = string.Concat(segment,",",txtSegmentAssign2.Text);
                if (!string.IsNullOrEmpty(txtSegmentAssign3.Text))
                    segment = string.Concat(segment, ",", txtSegmentAssign3.Text);
                if (!string.IsNullOrEmpty(txtSegmentAssign4.Text))
                    segment = string.Concat(segment, ",", txtSegmentAssign4.Text);
                if (!string.IsNullOrEmpty(txtSegmentAssign5.Text))
                    segment = string.Concat(segment, ",", txtSegmentAssign5.Text);
                if (!string.IsNullOrEmpty(txtSegmentAssign6.Text))
                    segment = string.Concat(segment, ",", txtSegmentAssign6.Text);
                if (!string.IsNullOrEmpty(txtSegmentAssign7.Text))
                    segment = string.Concat(segment, ",", txtSegmentAssign7.Text);
                if (!string.IsNullOrEmpty(txtSegmentAssign8.Text))
                    segment = string.Concat(segment, ",", txtSegmentAssign8.Text);
            }

            if (chkAmericanAirLines.Checked)
            {
                send = string.Concat("4DOCS", segment, "/DB/", txtBirthday.Text, "/", sex, "/");
                if (!string.IsNullOrEmpty(txtLastName.Text))
                        send=string.Concat(send,txtLastName.Text);
                send=string.Concat(send,txtLastName2.Text, "/", txtFirstName.Text);
                if (!string.IsNullOrEmpty(txtSecondName.Text))
                    send = string.Concat(send, "/", txtSecondName.Text);
                send = string.Concat(send, "-", txtPositionPassenger.Text);

            }
            else if (chkAAandOthers.Checked)
            {
                send = string.Concat("4DOCS", segment, "/DB/", txtBirthday.Text, "/", sex, "/", txtLastName.Text, txtLastName2.Text, "/", txtFirstName.Text);
                if (!string.IsNullOrEmpty(txtSecondName.Text))
                    send = string.Concat(send, "/", txtSecondName.Text);
                send = string.Concat(send, "-", txtPositionPassenger.Text);

                send = string.Concat(send, Resources.Constants.ENDIT, "3DOCS", segment, "/DB/", txtBirthday.Text, "/", sex, "/", txtLastName.Text, txtLastName2.Text, "/", txtFirstName.Text);
                if (!string.IsNullOrEmpty(txtSecondName.Text))
                    send = string.Concat(send, "/", txtSecondName.Text);
                send = string.Concat(send, "-", txtPositionPassenger.Text);
            }
            else
            {
                send = string.Concat("3DOCS", segment, "/DB/", txtBirthday.Text, "/", sex, "/", txtLastName.Text, txtLastName2.Text, "/", txtFirstName.Text);
                if (!string.IsNullOrEmpty(txtSecondName.Text))
                    send = string.Concat(send, "/", txtSecondName.Text);
                send = string.Concat(send, "-", txtPositionPassenger.Text);
            }
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }

        }
      
        #endregion
   }
}
