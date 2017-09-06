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
    public partial class ucSetsMap : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite asignar los asientos a reservar,pertenece a Reservaciones
        /// Creación:    Diciembre 08 -Marzo 09 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        #region====== Declaration of variables=======
        
        private bool numbersegment;
        public string send;
        private string[] segmentAssign = new string[10];
        private string result; 
        private bool next;
        private Color LIGHTGOLDENRODYELLOW = Color.LightGoldenrodYellow;
        private Color WHITE = Color.White;

        #endregion

        public ucSetsMap()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtSegmentAssign1;
            this.LastControlFocus = btnAccept;
        }

        //User Control Load
        /// <summary>
        /// Se manda un comando para verificar la reservación
        /// se coloca el foco en la asignación de asiento 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucSetsMap_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            using (CommandsAPI objCommands = new CommandsAPI())
            {
                objCommands.SendReceive(Resources.Constants.COMMANDS_AST_N_AST_IA);
            }
            txtSegmentAssign1.Focus();
        }

        //AdvancePag
        /// <summary>
        /// Se manda un comando para avanzar la página del mapa de asientos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdvancePag_Click(object sender, EventArgs e)
        {
            using (CommandsAPI objCommands = new CommandsAPI())
            {
                objCommands.SendReceive(Resources.Constants.COMMANDS_AT_MD);
            }
        }

        //ReturnPag
        /// <summary>
        /// Se manda un comando para regresa la página del mapa de asientos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturnPag_Click(object sender, EventArgs e)
        {
            using (CommandsAPI objCommands = new CommandsAPI())
            {
                objCommands.SendReceive(Resources.Constants.COMMANDS_AT_MU);
            }
        }

        //Button Accept
        /// <summary>
        /// Se realizan las validaciones despues de que el usuario ingresa datos, 
        /// se mandan los comandos y termina el proceso llamando a otro User Control 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSegmentAssign1.Text))
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UC_CONCLUDERESERVATION);
            else
            {
                if (IsValidateBusinessRules)
                {
                    CommandsSendReceive();
                    APIResponse();
                }
            }
         }

         /// <summary>
         /// Es para el cambio de Foco entre cada control 
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
         {
             if (txtSegmentAssign1.Text.Length > 1)
                 txtSegmentAssign2.Focus();
         }

         //KeyDown
         /// <summary>
         /// Este se usa para todos los controles en general si se oprime 
         /// Esc se manda a el User control de Availability 
         /// Enter se manda la accion de botón de Aceptar
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                #region ======= Process of Flow ====
                TextBox[] arrTextBox = new TextBox[] { txtSegmentAssign1, txtSegmentAssign2, txtSegmentAssign3, txtSegmentAssign4, 
                    txtSegmentAssign5,txtSegmentAssign6,txtSegmentAssign7,txtSegmentAssign8,txtSegmentAssign9,txtSegmentAssign10 };
                bool _isOK = false;
                for (int i = 0; i < arrTextBox.Length; i++)
                {
                    if (arrTextBox[i].BackColor == LIGHTGOLDENRODYELLOW
                        && (!string.IsNullOrEmpty(arrTextBox[i + 1].Text)))
                    {
                        using (CommandsAPI objCommands = new CommandsAPI())
                        {
                            objCommands.SendReceive(Resources.Constants.COMMANDS_NI + arrTextBox[i + 1].Text);
                            objCommands.SendReceive(Resources.Constants.COMMANDS_4G + arrTextBox[i + 1].Text + Resources.Constants.AST);
                        }
                        arrTextBox[i + 1].BackColor = LIGHTGOLDENRODYELLOW;
                        arrTextBox[i].BackColor = WHITE;
                        APIResponse();
                        _isOK = true;
                        break;
                    }
                }

                #region oldCode
                //if (txtSegmentAssign1.BackColor == Color.LightGoldenrodYellow &&
                //    !string.IsNullOrEmpty(txtSegmentAssign2.Text))
                //{
                //    using (CommandsAPI objCommands = new CommandsAPI())
                //    {
                //        objCommands.SendReceive(Resources.Constants.COMMANDS_NI + txtSegmentAssign2.Text);
                //        objCommands.SendReceive(Resources.Constants.COMMANDS_4G + txtSegmentAssign2.Text + Resources.Constants.AST);
                //    }
                //    txtSegmentAssign2.BackColor = Color.LightGoldenrodYellow;
                //    txtSegmentAssign1.BackColor = Color.White;
                //}
                //else if (txtSegmentAssign2.BackColor == Color.LightGoldenrodYellow &&
                //    !string.IsNullOrEmpty(txtSegmentAssign3.Text))
                //{
                //    using (CommandsAPI objCommands = new CommandsAPI())
                //    {
                //        objCommands.SendReceive(Resources.Constants.COMMANDS_NI + txtSegmentAssign3.Text);
                //        objCommands.SendReceive(Resources.Constants.COMMANDS_4G + txtSegmentAssign3.Text + Resources.Constants.AST);
                //    }

                //    txtSegmentAssign3.BackColor = Color.LightGoldenrodYellow;
                //    txtSegmentAssign2.BackColor = Color.White;
                //}
                //else if (txtSegmentAssign3.BackColor == Color.LightGoldenrodYellow &&
                //        !string.IsNullOrEmpty(txtSegmentAssign4.Text))
                //{
                //    using (CommandsAPI objCommands = new CommandsAPI())
                //    {
                //        objCommands.SendReceive(Resources.Constants.COMMANDS_NI + txtSegmentAssign4.Text);
                //        objCommands.SendReceive(Resources.Constants.COMMANDS_4G + txtSegmentAssign4.Text + Resources.Constants.AST);
                //    }

                //    txtSegmentAssign4.BackColor = Color.LightGoldenrodYellow;
                //    txtSegmentAssign3.BackColor = Color.White;
                //}
                //else if (txtSegmentAssign4.BackColor == Color.LightGoldenrodYellow &&
                //        !string.IsNullOrEmpty(txtSegmentAssign5.Text))
                //{
                //    using (CommandsAPI objCommands = new CommandsAPI())
                //    {
                //        objCommands.SendReceive(Resources.Constants.COMMANDS_NI + txtSegmentAssign5.Text);
                //        objCommands.SendReceive(Resources.Constants.COMMANDS_4G + txtSegmentAssign5.Text + Resources.Constants.AST);
                //    }

                //    txtSegmentAssign5.BackColor = Color.LightGoldenrodYellow;
                //    txtSegmentAssign4.BackColor = Color.White;
                //}
                //else if (txtSegmentAssign5.BackColor == Color.LightGoldenrodYellow &&
                //        !string.IsNullOrEmpty(txtSegmentAssign6.Text))
                //{
                //    using (CommandsAPI objCommands = new CommandsAPI())
                //    {
                //        objCommands.SendReceive(Resources.Constants.COMMANDS_NI + txtSegmentAssign6.Text);
                //        objCommands.SendReceive(Resources.Constants.COMMANDS_4G + txtSegmentAssign6.Text + Resources.Constants.AST);
                //    }

                //    txtSegmentAssign6.BackColor = Color.LightGoldenrodYellow;
                //    txtSegmentAssign5.BackColor = Color.White;
                //}
                //else if (txtSegmentAssign6.BackColor == Color.LightGoldenrodYellow &&
                //        !string.IsNullOrEmpty(txtSegmentAssign7.Text))
                //{
                //    using (CommandsAPI objCommands = new CommandsAPI())
                //    {
                //        objCommands.SendReceive(Resources.Constants.COMMANDS_NI + txtSegmentAssign7.Text);
                //        objCommands.SendReceive(Resources.Constants.COMMANDS_4G + txtSegmentAssign7.Text + Resources.Constants.AST);
                //    }

                //    txtSegmentAssign7.BackColor = Color.LightGoldenrodYellow;
                //    txtSegmentAssign6.BackColor = Color.White;
                //}
                //else if (txtSegmentAssign7.BackColor == Color.LightGoldenrodYellow &&
                //        !string.IsNullOrEmpty(txtSegmentAssign8.Text))
                //{
                //    using (CommandsAPI objCommands = new CommandsAPI())
                //    {
                //        objCommands.SendReceive(Resources.Constants.COMMANDS_NI + txtSegmentAssign8.Text);
                //        objCommands.SendReceive(Resources.Constants.COMMANDS_4G + txtSegmentAssign8.Text + Resources.Constants.AST);
                //    }

                //    txtSegmentAssign8.BackColor = Color.LightGoldenrodYellow;
                //    txtSegmentAssign7.BackColor = Color.White;
                //}
                //else if (txtSegmentAssign8.BackColor == Color.LightGoldenrodYellow &&
                //        !string.IsNullOrEmpty(txtSegmentAssign9.Text))
                //{
                //    using (CommandsAPI objCommands = new CommandsAPI())
                //    {
                //        objCommands.SendReceive(Resources.Constants.COMMANDS_NI + txtSegmentAssign9.Text);
                //        objCommands.SendReceive(Resources.Constants.COMMANDS_4G + txtSegmentAssign9.Text + Resources.Constants.AST);
                //    }

                //    txtSegmentAssign9.BackColor = Color.LightGoldenrodYellow;
                //    txtSegmentAssign8.BackColor = Color.White;
                //}
                //else if (txtSegmentAssign9.BackColor == Color.LightGoldenrodYellow &&
                //        !string.IsNullOrEmpty(txtSegmentAssign10.Text))
                //{
                //    using (CommandsAPI objCommands = new CommandsAPI())
                //    {
                //        objCommands.SendReceive(Resources.Constants.COMMANDS_NI + txtSegmentAssign10.Text);
                //        objCommands.SendReceive(Resources.Constants.COMMANDS_4G + txtSegmentAssign10.Text + Resources.Constants.AST);
                //    }

                //    txtSegmentAssign9.BackColor = Color.White;
                //    txtSegmentAssign10.BackColor = Color.LightGoldenrodYellow;
                //}
                #endregion
                if (!_isOK)
                {
                    if ((txtSegmentAssign1.BackColor == LIGHTGOLDENRODYELLOW &&
                       string.IsNullOrEmpty(txtSegmentAssign2.Text)) |
                       (txtSegmentAssign2.BackColor == Color.LightGoldenrodYellow &&
                       string.IsNullOrEmpty(txtSegmentAssign3.Text)) |
                       (txtSegmentAssign3.BackColor == Color.LightGoldenrodYellow &&
                       string.IsNullOrEmpty(txtSegmentAssign4.Text)) |
                       (txtSegmentAssign4.BackColor == Color.LightGoldenrodYellow &&
                       string.IsNullOrEmpty(txtSegmentAssign5.Text)) |
                       (txtSegmentAssign5.BackColor == Color.LightGoldenrodYellow &&
                        string.IsNullOrEmpty(txtSegmentAssign6.Text)) |
                       (txtSegmentAssign6.BackColor == Color.LightGoldenrodYellow &&
                        string.IsNullOrEmpty(txtSegmentAssign7.Text)) |
                       (txtSegmentAssign7.BackColor == Color.LightGoldenrodYellow &&
                        string.IsNullOrEmpty(txtSegmentAssign8.Text)) |
                       (txtSegmentAssign8.BackColor == Color.LightGoldenrodYellow &&
                       string.IsNullOrEmpty(txtSegmentAssign9.Text)) |
                       (txtSegmentAssign9.BackColor == Color.LightGoldenrodYellow &&
                       string.IsNullOrEmpty(txtSegmentAssign10.Text)))
                            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UC_CONCLUDERESERVATION);
                    else if (string.IsNullOrEmpty(txtSegmentAssign1.Text))
                            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UC_CONCLUDERESERVATION);
                }
               // CommandsSendReceive();

                #endregion
            }
               // Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);

            if (e.KeyData == Keys.Enter)
            {
                btnAccept_Click(sender, e);
            }
        }

        #region====== DisableControls =======

        /// <summary>
        /// Habilita y desabilita controles de acuerdo a lo elegido
        /// </summary>
        private void DisableControls()
        {
            txtSegmentAssign1.Enabled = false;
            txtSegmentAssign2.Enabled = false;
            txtSegmentAssign3.Enabled = false;
            txtSegmentAssign4.Enabled = false;
            txtSegmentAssign5.Enabled = false;
            txtSegmentAssign6.Enabled = false;
            txtSegmentAssign7.Enabled = false;
            txtSegmentAssign8.Enabled = false;
            txtSegmentAssign9.Enabled = false;
            txtSegmentAssign10.Enabled = false;
            txtNumberSeatAssign.Visible = true;
            lblNumberSeatAssign.Visible = true;
            lblGenericsAssign.Visible = true;
            chkAssignMoreSeatSegment.Visible = true;
            btnAdvancePag.Visible = true;
            btnReturnPag.Visible = true;
            txtNumberSeatAssign.Focus();
            txtSegmentAssign1.BackColor = Color.LightGoldenrodYellow;
        }

        #endregion 
       
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
                SmartTextBox[] arrTextBox = new SmartTextBox[] { txtSegmentAssign1, txtSegmentAssign2, txtSegmentAssign3, txtSegmentAssign4, txtSegmentAssign5, txtSegmentAssign6, txtSegmentAssign7, txtSegmentAssign8, txtSegmentAssign9, txtSegmentAssign10 };
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
            SmartTextBox[] txt = new SmartTextBox[] { txtSegmentAssign1, txtSegmentAssign2, txtSegmentAssign3, txtSegmentAssign4, txtSegmentAssign5, txtSegmentAssign6, txtSegmentAssign7, txtSegmentAssign8, txtSegmentAssign9, txtSegmentAssign10 };
            int numelements = txt.Length;

            for (int i = 0; i < numelements; i++)
            {
                if (txt[i].Name.Equals(txtCurrentControl.Name))
                    return i;
            }
            return 0;
        }

        private void txtSegmentAssign10_TextChanged(object sender, EventArgs e)
        {
            if (txtSegmentAssign10.Text.Length > 1)
                btnAccept.Focus();
        }

        private void txtNumberSeatAssign_TextChanged(object sender, EventArgs e)
        {
            if (txtNumberSeatAssign.Text.Length > 5)
                btnAccept.Focus();
        }

        #endregion

        #region======= Change Tab ========

        private void btnAccept_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSegmentAssign1.Enabled == true)
            {
                if (e.KeyData == Keys.Tab)
                    this.InitialControlFocus = txtSegmentAssign1;
            }
            else if (txtSegmentAssign1.Enabled == false)
            {
                if (e.KeyData == Keys.Tab)
                    this.InitialControlFocus = txtNumberSeatAssign;
            }
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
                string doublezero = Resources.Constants.DOUBLEZERO;
                string zero = Resources.Constants.ZERO;
                if (txtSegmentAssign1.Text.Equals(doublezero) | txtSegmentAssign2.Text.Equals(doublezero) |
                    txtSegmentAssign3.Text.Equals(doublezero) | txtSegmentAssign4.Text.Equals(doublezero) |
                    txtSegmentAssign5.Text.Equals(doublezero) | txtSegmentAssign6.Text.Equals(doublezero) |
                    txtSegmentAssign6.Text.Equals(doublezero) | txtSegmentAssign7.Text.Equals(doublezero) |
                    txtSegmentAssign8.Text.Equals(doublezero) | txtSegmentAssign9.Text.Equals(doublezero) |
                    txtSegmentAssign10.Text.Equals(doublezero) | txtNumberSeatAssign.Text.Equals(doublezero) |
                    txtSegmentAssign1.Text.Equals(zero) | txtSegmentAssign2.Text.Equals(zero) |
                    txtSegmentAssign3.Text.Equals(zero) | txtSegmentAssign4.Text.Equals(zero) |
                    txtSegmentAssign5.Text.Equals(zero) | txtSegmentAssign6.Text.Equals(zero) |
                    txtSegmentAssign6.Text.Equals(zero) | txtSegmentAssign7.Text.Equals(zero) |
                    txtSegmentAssign8.Text.Equals(zero) | txtSegmentAssign9.Text.Equals(zero) |
                    txtSegmentAssign10.Text.Equals(zero) | txtNumberSeatAssign.Text.Equals(zero) |
                    txtNumberSeatAssign.Text == Resources.Constants.TRIPLEZERO)
                {
                    MessageBox.Show(Resources.Reservations.NO_PERMITEN_CEROS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                #region Validacion de segmentos
                //if (string.IsNullOrEmpty(txtSegmentAssign1.Text))
                //{
                //    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UC_CONCLUDERESERVATION);

                //    MessageBox.Show(Resources.Reservations.POR_FAVOR_INGRESA_SEGMENTO_1, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtSegmentAssign1.Focus();
                //    validatebusinessrules = false;
                //    return;

                //}
                #endregion
                else if (string.IsNullOrEmpty(txtNumberSeatAssign.Text) &&
                               numbersegment == true)
                {
                    MessageBox.Show(Resources.Reservations.INGRESE_NÚMERO_ASIENTO_ASIGNARSE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberSeatAssign.Focus();
                    return false;
                }
                else
                    return true;
            }
        }

        /// <summary>
        /// Se envia el comando de acuerdo a los campos ingresados
        /// </summary>
        private void CommandsSendReceive()
        {
            segmentAssign[0] = txtSegmentAssign1.Text;
            segmentAssign[1] = txtSegmentAssign2.Text;
            segmentAssign[2] = txtSegmentAssign3.Text;
            segmentAssign[3] = txtSegmentAssign4.Text;
            segmentAssign[4] = txtSegmentAssign5.Text;
            segmentAssign[5] = txtSegmentAssign6.Text;
            segmentAssign[6] = txtSegmentAssign7.Text;
            segmentAssign[7] = txtSegmentAssign8.Text;
            segmentAssign[8] = txtSegmentAssign9.Text;
            segmentAssign[9] = txtSegmentAssign10.Text;
            if (string.IsNullOrEmpty(txtNumberSeatAssign.Text) &&
                numbersegment == false)
            {
                DisableControls();
                send = Resources.Constants.COMMANDS_4G + txtSegmentAssign1.Text + Resources.Constants.AST;
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    objCommands.SendReceive(send);
                }
                numbersegment = true;
            }
            else if ((!string.IsNullOrEmpty(segmentAssign[0])) &&
                      string.IsNullOrEmpty(segmentAssign[1]) &&
                      (!string.IsNullOrEmpty(txtNumberSeatAssign.Text)) &&
                      txtSegmentAssign1.Enabled == true &&
                      chkAssignMoreSeatSegment.Checked == false)
            {
                send = Resources.Constants.COMMANDS_4G + segmentAssign[0] + Resources.Constants.SLASH + txtNumberSeatAssign.Text;
                txtSegmentAssign1.Enabled = false;
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
                next = true;
            }
            else if (txtSegmentAssign1.Enabled == false &&
                    string.IsNullOrEmpty(segmentAssign[1]) &&
                    (!string.IsNullOrEmpty(txtNumberSeatAssign.Text)) &&
                    chkAssignMoreSeatSegment.Checked == false)
            {
                send = Resources.Constants.COMMANDS_4G + segmentAssign[0] + Resources.Constants.SLASH + txtNumberSeatAssign.Text;
                txtSegmentAssign1.Enabled = false;
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
                next = true;
            }
            else if (txtSegmentAssign2.BackColor == Color.LightGoldenrodYellow &&
                    (!string.IsNullOrEmpty(txtNumberSeatAssign.Text)) &&
                    chkAssignMoreSeatSegment.Checked == true)
            {
                send = Resources.Constants.COMMANDS_4G + segmentAssign[1] + Resources.Constants.SLASH + txtNumberSeatAssign.Text;
                txtNumberSeatAssign.Text = string.Empty;
                txtSegmentAssign2.Enabled = false;
                txtNumberSeatAssign.Focus();
                chkAssignMoreSeatSegment.Checked = false;
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
            }
            else if (txtSegmentAssign3.BackColor == Color.LightGoldenrodYellow &&
                    (!string.IsNullOrEmpty(txtNumberSeatAssign.Text)) &&
                    chkAssignMoreSeatSegment.Checked == true)
            {
                send = Resources.Constants.COMMANDS_4G + segmentAssign[2] + Resources.Constants.SLASH + txtNumberSeatAssign.Text;
                txtNumberSeatAssign.Text = string.Empty;
                txtSegmentAssign3.Enabled = false;
                txtNumberSeatAssign.Focus();
                chkAssignMoreSeatSegment.Checked = false;
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
            }
            else if (txtSegmentAssign4.BackColor == Color.LightGoldenrodYellow &&
                    (!string.IsNullOrEmpty(txtNumberSeatAssign.Text)) &&
                    chkAssignMoreSeatSegment.Checked == true)
            {
                send = Resources.Constants.COMMANDS_4G + segmentAssign[3] + Resources.Constants.SLASH + txtNumberSeatAssign.Text;
                txtNumberSeatAssign.Text = string.Empty;
                txtSegmentAssign4.Enabled = false;
                txtNumberSeatAssign.Focus();
                chkAssignMoreSeatSegment.Checked = false;
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
            }
            else if (txtSegmentAssign5.BackColor == Color.LightGoldenrodYellow &&
                  (!string.IsNullOrEmpty(txtNumberSeatAssign.Text)) &&
                  chkAssignMoreSeatSegment.Checked == true)
            {
                send = Resources.Constants.COMMANDS_4G + segmentAssign[4] + Resources.Constants.SLASH + txtNumberSeatAssign.Text;
                txtNumberSeatAssign.Text = string.Empty;
                txtSegmentAssign5.Enabled = false;
                txtNumberSeatAssign.Focus();
                chkAssignMoreSeatSegment.Checked = false;
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
            }
            else if (txtSegmentAssign6.BackColor == Color.LightGoldenrodYellow &&
                    (!string.IsNullOrEmpty(txtNumberSeatAssign.Text)) &&
                     chkAssignMoreSeatSegment.Checked == true)
            {
                send = Resources.Constants.COMMANDS_4G + segmentAssign[5] + Resources.Constants.SLASH + txtNumberSeatAssign.Text;
                txtNumberSeatAssign.Text = string.Empty;
                txtSegmentAssign6.Enabled = false;
                txtNumberSeatAssign.Focus();
                chkAssignMoreSeatSegment.Checked = false;
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
            }
            else if (txtSegmentAssign7.BackColor == Color.LightGoldenrodYellow &&
                    (!string.IsNullOrEmpty(txtNumberSeatAssign.Text)) &&
                    chkAssignMoreSeatSegment.Checked == true)
            {
                send = Resources.Constants.COMMANDS_4G + segmentAssign[6] + Resources.Constants.SLASH + txtNumberSeatAssign.Text;
                txtNumberSeatAssign.Text = string.Empty;
                txtSegmentAssign7.Enabled = false;
                txtNumberSeatAssign.Focus();
                chkAssignMoreSeatSegment.Checked = false;
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
            }
            else if (txtSegmentAssign8.BackColor == Color.LightGoldenrodYellow &&
                    (!string.IsNullOrEmpty(txtNumberSeatAssign.Text)) &&
                    chkAssignMoreSeatSegment.Checked == true)
            {
                send = Resources.Constants.COMMANDS_4G + segmentAssign[7] + Resources.Constants.SLASH + txtNumberSeatAssign.Text;
                txtNumberSeatAssign.Text = string.Empty;
                txtSegmentAssign8.Enabled = false;
                txtNumberSeatAssign.Focus();
                chkAssignMoreSeatSegment.Checked = false;
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
            }
            else if (txtSegmentAssign9.BackColor == Color.LightGoldenrodYellow &&
                    (!string.IsNullOrEmpty(txtNumberSeatAssign.Text)) &&
                    chkAssignMoreSeatSegment.Checked == true)
            {
                send = Resources.Constants.COMMANDS_4G + segmentAssign[8] + Resources.Constants.SLASH + txtNumberSeatAssign.Text;
                txtNumberSeatAssign.Text = string.Empty;
                txtSegmentAssign9.Enabled = false;
                txtNumberSeatAssign.Focus();
                chkAssignMoreSeatSegment.Checked = false;
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
            }
            else if (txtSegmentAssign10.BackColor == Color.LightGoldenrodYellow &&
                    (!string.IsNullOrEmpty(txtNumberSeatAssign.Text)) &&
                    chkAssignMoreSeatSegment.Checked == true)
            {
                send = Resources.Constants.COMMANDS_4G + segmentAssign[9] + Resources.Constants.SLASH + txtNumberSeatAssign.Text;
                txtNumberSeatAssign.Text = string.Empty;
                txtSegmentAssign10.Enabled = false;
                txtNumberSeatAssign.Focus();
                chkAssignMoreSeatSegment.Checked = false;
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
            }
            else if ((!string.IsNullOrEmpty(segmentAssign[0])) &&
                    (!string.IsNullOrEmpty(txtNumberSeatAssign.Text)) &&
                    chkAssignMoreSeatSegment.Checked == true &&
                    txtSegmentAssign1.Enabled == true)
            {
                send = Resources.Constants.COMMANDS_4G + segmentAssign[0] + Resources.Constants.SLASH + txtNumberSeatAssign.Text;
                txtNumberSeatAssign.Text = string.Empty;
                txtSegmentAssign1.Enabled = false;
                txtNumberSeatAssign.Focus();
                chkAssignMoreSeatSegment.Checked = false;
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
            }
            else if (txtSegmentAssign1.Enabled == false &&
                     chkAssignMoreSeatSegment.Checked == true &&
                     (!string.IsNullOrEmpty(txtNumberSeatAssign.Text)))
            {
                send = Resources.Constants.COMMANDS_4G + segmentAssign[0] + Resources.Constants.SLASH + txtNumberSeatAssign.Text;
                txtNumberSeatAssign.Text = string.Empty;
                txtNumberSeatAssign.Focus();
                chkAssignMoreSeatSegment.Checked = false;
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
            }
            else if (txtSegmentAssign2.BackColor == Color.LightGoldenrodYellow &&
                    (!string.IsNullOrEmpty(txtNumberSeatAssign.Text)) &&
                    (!string.IsNullOrEmpty(segmentAssign[2])) &&
                    chkAssignMoreSeatSegment.Checked == false)
            {
                send = Resources.Constants.COMMANDS_4G + segmentAssign[1] + Resources.Constants.SLASH + txtNumberSeatAssign.Text;
                txtSegmentAssign2.Enabled = false;
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                    objCommands.SendReceive(Resources.Constants.COMMANDS_NI + txtSegmentAssign3.Text);
                    objCommands.SendReceive(Resources.Constants.COMMANDS_4G + txtSegmentAssign3.Text + Resources.Constants.AST);
                }
                txtSegmentAssign2.BackColor = Color.White;
                txtSegmentAssign3.BackColor = Color.LightGoldenrodYellow;
                txtNumberSeatAssign.Text = string.Empty;
                txtNumberSeatAssign.Focus();
            }
            else if (txtSegmentAssign2.BackColor == Color.LightGoldenrodYellow &&
                    (!string.IsNullOrEmpty(txtNumberSeatAssign.Text)) &&
                    chkAssignMoreSeatSegment.Checked == false)
            {
                send = Resources.Constants.COMMANDS_4G + segmentAssign[1] + Resources.Constants.SLASH + txtNumberSeatAssign.Text;
                txtNumberSeatAssign.Text = string.Empty;
                txtSegmentAssign2.Enabled = false;
                txtNumberSeatAssign.Focus();
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
                next = true;
            }
            else if (txtSegmentAssign3.BackColor == Color.LightGoldenrodYellow &&
                    (!string.IsNullOrEmpty(txtNumberSeatAssign.Text)) &&
                    (!string.IsNullOrEmpty(segmentAssign[3])) &&
                    chkAssignMoreSeatSegment.Checked == false)
            {
                send = Resources.Constants.COMMANDS_4G + segmentAssign[2] + Resources.Constants.SLASH + txtNumberSeatAssign.Text;
                txtSegmentAssign3.Enabled = false;
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                    objCommands.SendReceive(Resources.Constants.COMMANDS_NI + txtSegmentAssign4.Text);
                    objCommands.SendReceive(Resources.Constants.COMMANDS_4G + txtSegmentAssign4.Text + Resources.Constants.AST);
                }
                txtSegmentAssign3.BackColor = Color.White;
                txtSegmentAssign4.BackColor = Color.LightGoldenrodYellow;
                txtNumberSeatAssign.Text = string.Empty;
                txtNumberSeatAssign.Focus();
            }
            else if (txtSegmentAssign3.BackColor == Color.LightGoldenrodYellow &&
                    (!string.IsNullOrEmpty(txtNumberSeatAssign.Text)) &&
                    chkAssignMoreSeatSegment.Checked == false)
            {
                send = Resources.Constants.COMMANDS_4G + segmentAssign[2] + Resources.Constants.SLASH + txtNumberSeatAssign.Text;
                txtNumberSeatAssign.Text = string.Empty;
                txtSegmentAssign3.Enabled = false;
                txtNumberSeatAssign.Focus();
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
                next = true;
            }
            else if (txtSegmentAssign4.BackColor == Color.LightGoldenrodYellow &&
                          (!string.IsNullOrEmpty(txtNumberSeatAssign.Text)) &&
                          (!string.IsNullOrEmpty(segmentAssign[4])) &&
                          chkAssignMoreSeatSegment.Checked == false)
            {
                send = Resources.Constants.COMMANDS_4G + segmentAssign[3] + Resources.Constants.SLASH + txtNumberSeatAssign.Text;
                txtSegmentAssign4.Enabled = false;
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);

                    objCommands.SendReceive(Resources.Constants.COMMANDS_NI + txtSegmentAssign5.Text);
                    objCommands.SendReceive(Resources.Constants.COMMANDS_4G + txtSegmentAssign5.Text + Resources.Constants.AST);
                }
                txtSegmentAssign4.BackColor = Color.White;
                txtSegmentAssign5.BackColor = Color.LightGoldenrodYellow;
                txtNumberSeatAssign.Text = string.Empty;
                txtNumberSeatAssign.Focus();
           }
           else if (txtSegmentAssign4.BackColor == Color.LightGoldenrodYellow &&
                   (!string.IsNullOrEmpty(txtNumberSeatAssign.Text)) &&
                   chkAssignMoreSeatSegment.Checked == false)
            {
                send = Resources.Constants.COMMANDS_4G + segmentAssign[3] + Resources.Constants.SLASH + txtNumberSeatAssign.Text;
                txtNumberSeatAssign.Text = string.Empty;
                txtSegmentAssign4.Enabled = false;
                txtNumberSeatAssign.Focus();
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
                next = true;
            }
            else if (txtSegmentAssign5.BackColor == Color.LightGoldenrodYellow &&
                    (!string.IsNullOrEmpty(txtNumberSeatAssign.Text)) &&
                    (!string.IsNullOrEmpty(segmentAssign[5])) &&
                    chkAssignMoreSeatSegment.Checked == false)
            {
                send = Resources.Constants.COMMANDS_4G + segmentAssign[4] + Resources.Constants.SLASH + txtNumberSeatAssign.Text;
                txtSegmentAssign5.Enabled = false;
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                    objCommands.SendReceive(Resources.Constants.COMMANDS_NI + txtSegmentAssign6.Text);
                    objCommands.SendReceive(Resources.Constants.COMMANDS_4G + txtSegmentAssign6.Text + Resources.Constants.AST);
                }
                txtSegmentAssign5.BackColor = Color.White;
                txtSegmentAssign6.BackColor = Color.LightGoldenrodYellow;
                txtNumberSeatAssign.Text = string.Empty;
                txtNumberSeatAssign.Focus();
            }
            else if (txtSegmentAssign5.BackColor == Color.LightGoldenrodYellow &&
                    (!string.IsNullOrEmpty(txtNumberSeatAssign.Text)) &&
                    chkAssignMoreSeatSegment.Checked == false)
            {
                send = Resources.Constants.COMMANDS_4G + segmentAssign[4] + Resources.Constants.SLASH + txtNumberSeatAssign.Text;
                txtNumberSeatAssign.Text = string.Empty;
                txtSegmentAssign5.Enabled = false;
                txtNumberSeatAssign.Focus();
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
                next = true;
            }
            else if (txtSegmentAssign6.BackColor == Color.LightGoldenrodYellow &&
                    (!string.IsNullOrEmpty(txtNumberSeatAssign.Text)) &&
                    (!string.IsNullOrEmpty(segmentAssign[6])) &&
                    chkAssignMoreSeatSegment.Checked == false)
            {
                send = Resources.Constants.COMMANDS_4G + segmentAssign[5] + Resources.Constants.SLASH + txtNumberSeatAssign.Text;
                txtSegmentAssign6.Enabled = false;
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                    objCommands.SendReceive(Resources.Constants.COMMANDS_NI + txtSegmentAssign7.Text);
                    objCommands.SendReceive(Resources.Constants.COMMANDS_4G + txtSegmentAssign7.Text + Resources.Constants.AST);
                }
                txtSegmentAssign6.BackColor = Color.White;
                txtSegmentAssign7.BackColor = Color.LightGoldenrodYellow;
                txtNumberSeatAssign.Text = string.Empty;
                txtNumberSeatAssign.Focus();
            }

            else if (txtSegmentAssign6.BackColor == Color.LightGoldenrodYellow &&
                    (!string.IsNullOrEmpty(txtNumberSeatAssign.Text)) &&
                    chkAssignMoreSeatSegment.Checked == false)
            {
                send = Resources.Constants.COMMANDS_4G + segmentAssign[5] + Resources.Constants.SLASH + txtNumberSeatAssign.Text;
                txtNumberSeatAssign.Text = string.Empty;
                txtSegmentAssign6.Enabled = false;
                txtNumberSeatAssign.Focus();
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
                next = true;

            }


            else if (txtSegmentAssign7.BackColor == Color.LightGoldenrodYellow &&
                     (!string.IsNullOrEmpty(txtNumberSeatAssign.Text)) &&
                     (!string.IsNullOrEmpty(segmentAssign[7])) &&
                     chkAssignMoreSeatSegment.Checked == false)
            {
                send = Resources.Constants.COMMANDS_4G + segmentAssign[6] + Resources.Constants.SLASH + txtNumberSeatAssign.Text;
                txtSegmentAssign7.Enabled = false;
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                    objCommands.SendReceive(Resources.Constants.COMMANDS_NI + txtSegmentAssign8.Text);
                    objCommands.SendReceive(Resources.Constants.COMMANDS_4G + txtSegmentAssign8.Text + Resources.Constants.AST);
                }
                txtSegmentAssign7.BackColor = Color.White;
                txtSegmentAssign8.BackColor = Color.LightGoldenrodYellow;
                txtNumberSeatAssign.Text = string.Empty;
                txtNumberSeatAssign.Focus();


            }

            else if (txtSegmentAssign7.BackColor == Color.LightGoldenrodYellow &&
                    (!string.IsNullOrEmpty(txtNumberSeatAssign.Text)) &&
                    chkAssignMoreSeatSegment.Checked == false)
            {
                send = Resources.Constants.COMMANDS_4G + segmentAssign[6] + Resources.Constants.SLASH + txtNumberSeatAssign.Text;
                txtNumberSeatAssign.Text = string.Empty;
                txtSegmentAssign7.Enabled = false;
                txtNumberSeatAssign.Focus();
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
                next = true;

            }


            else if (txtSegmentAssign8.BackColor == Color.LightGoldenrodYellow &&
                  (!string.IsNullOrEmpty(txtNumberSeatAssign.Text)) &&
                  (!string.IsNullOrEmpty(segmentAssign[8])) &&
                  chkAssignMoreSeatSegment.Checked == false)
            {
                send = Resources.Constants.COMMANDS_4G + segmentAssign[7] + Resources.Constants.SLASH + txtNumberSeatAssign.Text;
                txtSegmentAssign8.Enabled = false;
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                    objCommands.SendReceive(Resources.Constants.COMMANDS_NI + txtSegmentAssign9.Text);
                    objCommands.SendReceive(Resources.Constants.COMMANDS_4G + txtSegmentAssign9.Text + Resources.Constants.AST);
                }
                txtSegmentAssign8.BackColor = Color.White;
                txtSegmentAssign9.BackColor = Color.LightGoldenrodYellow;
                txtNumberSeatAssign.Text = string.Empty;
                txtNumberSeatAssign.Focus();


            }

            else if (txtSegmentAssign8.BackColor == Color.LightGoldenrodYellow &&
                    (!string.IsNullOrEmpty(txtNumberSeatAssign.Text)) &&
                    chkAssignMoreSeatSegment.Checked == false)
            {
                send = Resources.Constants.COMMANDS_4G + segmentAssign[7] + Resources.Constants.SLASH + txtNumberSeatAssign.Text;
                txtNumberSeatAssign.Text = string.Empty;
                txtSegmentAssign8.Enabled = false;
                txtNumberSeatAssign.Focus();
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
                next = true;

            }
            else if (txtSegmentAssign9.BackColor == Color.LightGoldenrodYellow &&
                  (!string.IsNullOrEmpty(txtNumberSeatAssign.Text)) &&
                  (!string.IsNullOrEmpty(segmentAssign[9])) &&
                  chkAssignMoreSeatSegment.Checked == false)
            {
                send = Resources.Constants.COMMANDS_4G + segmentAssign[8] + Resources.Constants.SLASH + txtNumberSeatAssign.Text;
                txtSegmentAssign9.Enabled = false;
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                    objCommands.SendReceive(Resources.Constants.COMMANDS_NI + txtSegmentAssign10.Text);
                    objCommands.SendReceive(Resources.Constants.COMMANDS_4G + txtSegmentAssign10.Text + Resources.Constants.AST);
                }
                txtSegmentAssign9.BackColor = Color.White;
                txtSegmentAssign10.BackColor = Color.LightGoldenrodYellow;
                txtNumberSeatAssign.Text = string.Empty;
                txtNumberSeatAssign.Focus();

           }

            else if (txtSegmentAssign9.BackColor == Color.LightGoldenrodYellow &&
                (!string.IsNullOrEmpty(txtNumberSeatAssign.Text)) &&
                chkAssignMoreSeatSegment.Checked == false)
            {
                send = Resources.Constants.COMMANDS_4G + segmentAssign[8] + Resources.Constants.SLASH + txtNumberSeatAssign.Text;
                txtNumberSeatAssign.Text = string.Empty;
                txtSegmentAssign9.Enabled = false;
                txtNumberSeatAssign.Focus();
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
                next = true;

            }

            else if (txtSegmentAssign10.BackColor == Color.LightGoldenrodYellow &&
                   (!string.IsNullOrEmpty(txtNumberSeatAssign.Text)) &&
                   chkAssignMoreSeatSegment.Checked == false)
            {
                send = Resources.Constants.COMMANDS_4G + segmentAssign[9] + Resources.Constants.SLASH + txtNumberSeatAssign.Text;
                txtNumberSeatAssign.Text = string.Empty;
                txtSegmentAssign10.Enabled = false;
                txtNumberSeatAssign.Focus();
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
                next = true;

            }


            else if (txtSegmentAssign1.Enabled == false &&
                        chkAssignMoreSeatSegment.Checked == false &&
                        (!string.IsNullOrEmpty(segmentAssign[1])) &&
                        (!string.IsNullOrEmpty(txtNumberSeatAssign.Text)))
            {
                send = Resources.Constants.COMMANDS_4G + segmentAssign[0] + Resources.Constants.SLASH + txtNumberSeatAssign.Text;
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                    objCommands.SendReceive(Resources.Constants.COMMANDS_NI + txtSegmentAssign2.Text);
                    objCommands.SendReceive(Resources.Constants.COMMANDS_4G + txtSegmentAssign2.Text + Resources.Constants.AST);
                }
                txtSegmentAssign1.BackColor = Color.White;
                txtSegmentAssign2.BackColor = Color.LightGoldenrodYellow;
                txtNumberSeatAssign.Text = string.Empty;
                txtNumberSeatAssign.Focus();


            }


            

        }


        #region ===== Commons =====

        /// <summary>
        /// Busca errores en la clase de ERR_SetsMap de acuerdo a las respuestas recibidas por el 
        /// Emulador de Sabre y de acuerdo a ellas se realizan ciertas acciones ya sea
        /// mandar un mensaje de error al usuario notificando del mismo o mandando a otro 
        /// User Control
        /// </summary>
        private void APIResponse()
        {
            if ((!string.IsNullOrEmpty(result)))
            {
                ERR_SetsMap.err_errsetsmap(result);

                if ((!ERR_SetsMap.Refused))
                {
                    if (next)
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UC_CONCLUDERESERVATION);
                }
                else
                {
                    MessageBox.Show(ERR_SetsMap.CustomUserMsg, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }


        #endregion // End Commons


        #endregion

      }
}