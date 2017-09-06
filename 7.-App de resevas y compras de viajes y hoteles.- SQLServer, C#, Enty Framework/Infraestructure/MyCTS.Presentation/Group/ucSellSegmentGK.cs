using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Business;
using MyCTS.Entities;

namespace MyCTS.Presentation
{
    public partial class ucSellSegmentGK : CustomUserControl
    {
        /// <summary>
        /// Descripcion:Venta de segmento GK
        /// Creación: Septiembre 23 - 2009 , Modificación:*
        /// Cambio: *    , Solicito *
        /// Autor: Jessica Gutierrez 
        /// </summary>

        private string send;
        private string result;

        public ucSellSegmentGK()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtReservationSpace;
            this.LastControlFocus = btnAccept;
        }

        //Load User Control VentaSegmentoGK
        private void ucVentaSegmentoGK_Load(object sender, EventArgs e)
        {
            txtReservationSpace.Focus();
        }

        /// <summary>
        /// Validación de datos y envio de commando
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidateBussinessRules)
            {
                CommandsSend();
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
        }

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
            else if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }

        /// <summary>
        /// Veficación de datos por cada control
        /// </summary>
        /// <param name="pnlName"></param>
        /// <returns></returns>
        private bool IsValidPanel(Panel pnlName)
        {
            bool _isEmpty = true;
            foreach (Control c in pnlName.Controls)
            {
                TextBox txt = c as TextBox;
                if (!string.IsNullOrEmpty(txt.Text))
                {
                    _isEmpty = false;
                    break;
                }
            }
            if (!_isEmpty)
            {
                foreach (Control c in pnlName.Controls)
                {
                    TextBox txt = c as TextBox;
                    if (string.IsNullOrEmpty(txt.Text))
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Validacion de Reglas de negocio
        /// </summary>
        private bool IsValidateBussinessRules
        {
            get
            {
                Panel[] pnlList = new Panel[] { panel1, panel2, panel3, panel4, panel5, panel6, panel7, panel8, panel9, panel10, panel11, panel12 };
                string comments = string.Empty;
                string error = string.Empty;
                foreach (Panel p in pnlList)
                {
                    if (!IsValidPanel(p))
                    {
                        comments = p.Name;
                        comments = comments.Substring(5, 1);
                    }
                }
                if (string.IsNullOrEmpty(txtReservationSpace.Text))
                {
                    MessageBox.Show(Resources.Group.Group.REQUIERE_INGRESE_ESPACIOS_RESERVAR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtReservationSpace.Focus();
                    return false;
                }
                else if (!string.IsNullOrEmpty(comments))
                {
                    error = Resources.Group.Group.VERIFIQUE_RENGLONES + " " + comments;
                    MessageBox.Show(error);
                    if (comments == "1")
                        txtAL1.Focus();
                    else if (comments == "2")
                        txtAL2.Focus();
                    else if (comments == "3")
                        txtAL3.Focus();
                    else if (comments == "4")
                        txtAL4.Focus();
                    else if (comments == "5")
                        txtAL5.Focus();
                    else if (comments == "6")
                        txtAL6.Focus();
                    else if (comments == "7")
                        txtAL7.Focus();
                    else if (comments == "8")
                        txtAL8.Focus();
                    else if (comments == "9")
                        txtAL9.Focus();
                    else if (comments == "10")
                        txtAL10.Focus();
                    else if (comments == "11")
                        txtAL11.Focus();
                    else if (comments == "12")
                        txtAL12.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtAL1.Text) &&
                    string.IsNullOrEmpty(txtNo_VIo1.Text) &&
                    string.IsNullOrEmpty(txtClass1.Text) &&
                    string.IsNullOrEmpty(txtDate1.Text) &&
                    string.IsNullOrEmpty(txtOrigin1.Text) &&
                    string.IsNullOrEmpty(txtDestiny1.Text) &&
                    string.IsNullOrEmpty(txtStatus1.Text))
                {
                    MessageBox.Show(Resources.Group.Group.REQUIERE_INGRESE_CAMPOS_OBLIGATORIOS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAL1.Focus();
                    return false;
                }
                else
                    return true;
            }
        }

        /// <summary>
        /// Envio de comando
        /// </summary>
        private void CommandsSend()
        {
            //if (txtAL1.Text == "A")
            //{
            //    send = Resources.Group.Constants.COMMANDS_0A;
            //}
            if (!string.IsNullOrEmpty(txtAL1.Text))
            {
                send = Resources.Group.Constants.COMMANDS_ZERO;
                send = string.Concat(send, txtAL1.Text, txtNo_VIo1.Text, txtClass1.Text,
                    txtDate1.Text, txtOrigin1.Text, txtDestiny1.Text, txtStatus1.Text, 
                    txtReservationSpace.Text);
                if (!string.IsNullOrEmpty(txtConfirm1.Text))
                {
                    send = string.Concat(send, Resources.Group.Constants.COMMANDS_AST,
                        txtConfirm1.Text);
                }
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
            }
            if (!string.IsNullOrEmpty(txtAL2.Text))
            {
                send = string.Empty;
                send = Resources.Group.Constants.COMMANDS_ZERO;
                send = string.Concat(send, txtAL2.Text, txtNo_VIo2.Text, txtClass2.Text,
                    txtDate2.Text, txtOrigin2.Text, txtDestiny2.Text, txtStatus2.Text,
                    txtReservationSpace.Text);
                if (!string.IsNullOrEmpty(txtConfirm2.Text))
                {
                    send = string.Concat(send, Resources.Group.Constants.COMMANDS_AST,
                        txtConfirm2.Text);
                }
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
            }
            if (!string.IsNullOrEmpty(txtAL3.Text))
            {
                send = string.Empty;
                send = Resources.Group.Constants.COMMANDS_ZERO;
                send = string.Concat(send, txtAL3.Text, txtNo_VIo3.Text, txtClass3.Text,
                    txtDate3.Text, txtOrigin3.Text, txtDestiny3.Text, txtStatus3.Text,
                    txtReservationSpace.Text);
                if (!string.IsNullOrEmpty(txtConfirm3.Text))
                {
                    send = string.Concat(send, Resources.Group.Constants.COMMANDS_AST,
                        txtConfirm3.Text);
                }
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
            }
            if (!string.IsNullOrEmpty(txtAL4.Text))
            {
                send = string.Empty;
                send = Resources.Group.Constants.COMMANDS_ZERO;
                send = string.Concat(send, txtAL4.Text, txtNo_VIo4.Text, txtClass4.Text,
                    txtDate4.Text, txtOrigin4.Text, txtDestiny4.Text, txtStatus4.Text,
                    txtReservationSpace.Text);
                if (!string.IsNullOrEmpty(txtConfirm4.Text))
                {
                    send = string.Concat(send, Resources.Group.Constants.COMMANDS_AST,
                        txtConfirm4.Text);
                }
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
            }
            if (!string.IsNullOrEmpty(txtAL5.Text))
            {
                send = string.Empty;
                send = Resources.Group.Constants.COMMANDS_ZERO;
                send = string.Concat(send, txtAL5.Text, txtNo_VIo5.Text, txtClass5.Text,
                    txtDate5.Text, txtOrigin5.Text, txtDestiny5.Text, txtStatus5.Text,
                    txtReservationSpace.Text);
                if (!string.IsNullOrEmpty(txtConfirm5.Text))
                {
                    send = string.Concat(send, Resources.Group.Constants.COMMANDS_AST,
                        txtConfirm5.Text);
                }
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
            }
            if (!string.IsNullOrEmpty(txtAL6.Text))
            {
                send = string.Empty;
                send = Resources.Group.Constants.COMMANDS_ZERO;
                send = string.Concat(send, txtAL6.Text, txtNo_VIo6.Text, txtClass6.Text,
                    txtDate6.Text, txtOrigin6.Text, txtDestiny6.Text, txtStatus6.Text,
                    txtReservationSpace.Text);
                if (!string.IsNullOrEmpty(txtConfirm6.Text))
                {
                    send = string.Concat(send, Resources.Group.Constants.COMMANDS_AST,
                        txtConfirm6.Text);
                }
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
            }
            if (!string.IsNullOrEmpty(txtAL7.Text))
            {
                send = string.Empty;
                send = Resources.Group.Constants.COMMANDS_ZERO;
                send = string.Concat(send, txtAL7.Text, txtNo_VIo7.Text, txtClass7.Text,
                    txtDate5.Text, txtOrigin7.Text, txtDestiny7.Text, txtStatus7.Text,
                    txtReservationSpace.Text);
                if (!string.IsNullOrEmpty(txtConfirm7.Text))
                {
                    send = string.Concat(send, Resources.Group.Constants.COMMANDS_AST,
                        txtConfirm7.Text);
                }
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
            }
            if (!string.IsNullOrEmpty(txtAL8.Text))
            {
                send = string.Empty;
                send = Resources.Group.Constants.COMMANDS_ZERO;
                send = string.Concat(send, txtAL8.Text, txtNo_VIo8.Text, txtClass8.Text,
                    txtDate8.Text, txtOrigin8.Text, txtDestiny8.Text, txtStatus8.Text,
                    txtReservationSpace.Text);
                if (!string.IsNullOrEmpty(txtConfirm8.Text))
                {
                    send = string.Concat(send, Resources.Group.Constants.COMMANDS_AST,
                        txtConfirm8.Text);
                }
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
            }
            if (!string.IsNullOrEmpty(txtAL9.Text))
            {
                send = string.Empty;
                send = Resources.Group.Constants.COMMANDS_ZERO;
                send = string.Concat(send, txtAL9.Text, txtNo_VIo9.Text, txtClass9.Text,
                    txtDate9.Text, txtOrigin9.Text, txtDestiny9.Text, txtStatus9.Text,
                    txtReservationSpace.Text);
                if (!string.IsNullOrEmpty(txtConfirm9.Text))
                {
                    send = string.Concat(send, Resources.Group.Constants.COMMANDS_AST,
                        txtConfirm9.Text);
                }
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
            }
            if (!string.IsNullOrEmpty(txtAL10.Text))
            {
                send = string.Empty;
                send = Resources.Group.Constants.COMMANDS_ZERO;
                send = string.Concat(send, txtAL10.Text, txtNo_VIo10.Text, txtClass10.Text,
                    txtDate10.Text, txtOrigin10.Text, txtDestiny10.Text, txtStatus10.Text,
                    txtReservationSpace.Text);
                if (!string.IsNullOrEmpty(txtConfirm10.Text))
                {
                    send = string.Concat(send, Resources.Group.Constants.COMMANDS_AST,
                        txtConfirm10.Text);
                }
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
            }
            if (!string.IsNullOrEmpty(txtAL11.Text))
            {
                send = string.Empty;
                send = Resources.Group.Constants.COMMANDS_ZERO;
                send = string.Concat(send, txtAL11.Text, txtNo_VIo11.Text, txtClass11.Text,
                    txtDate11.Text, txtOrigin11.Text, txtDestiny11.Text, txtStatus11.Text,
                    txtReservationSpace.Text);
                if (!string.IsNullOrEmpty(txtConfirm11.Text))
                {
                    send = string.Concat(send, Resources.Group.Constants.COMMANDS_AST,
                        txtConfirm11.Text);
                }
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
            }
            if (!string.IsNullOrEmpty(txtAL12.Text))
            {
                send = string.Empty;
                send = Resources.Group.Constants.COMMANDS_ZERO;
                send = string.Concat(send, txtAL12.Text, txtNo_VIo12.Text, txtClass12.Text,
                    txtDate12.Text, txtOrigin12.Text, txtDestiny12.Text, txtStatus12.Text,
                    txtReservationSpace.Text);
                if (!string.IsNullOrEmpty(txtConfirm12.Text))
                {
                    send = string.Concat(send, Resources.Group.Constants.COMMANDS_AST,
                        txtConfirm12.Text);
                }
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
            }

            APIResponse();
        }

        /// <summary>
        /// Verificación de respuesta
        /// </summary>
        private void APIResponse()
        {
            if ((!string.IsNullOrEmpty(result)))
            {
                ERR_SellSegmentGK.err_boletagedataandreceived(result);
                if (ERR_SellSegmentGK.Status)
                    MessageBox.Show(Resources.Group.Group.ERROR_VENDER_VUELO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #region ===== TextChange AL =======

        private void txtAL1_TextChanged(object sender, EventArgs e)
        {
            if (txtAL1.Text.Length > 1)
                txtNo_VIo1.Focus();
        }

        private void txtAL2_TextChanged(object sender, EventArgs e)
        {
            if (txtAL2.Text.Length > 1)
                txtNo_VIo2.Focus();
        }

        private void txtAL3_TextChanged(object sender, EventArgs e)
        {
            if (txtAL3.Text.Length > 1)
                txtNo_VIo3.Focus();
        }

        private void txtAL4_TextChanged(object sender, EventArgs e)
        {
            if (txtAL4.Text.Length > 1)
                txtNo_VIo4.Focus();
        }

        private void txtAL5_TextChanged(object sender, EventArgs e)
        {
            if (txtAL5.Text.Length > 1)
                txtNo_VIo5.Focus();
        }

        private void txtAL6_TextChanged(object sender, EventArgs e)
        {
            if (txtAL6.Text.Length > 1)
                txtNo_VIo6.Focus();
        }

        private void txtAL7_TextChanged(object sender, EventArgs e)
        {
            if (txtAL7.Text.Length > 1)
                txtNo_VIo7.Focus();
        }

        private void txtAL8_TextChanged(object sender, EventArgs e)
        {
            if (txtAL8.Text.Length > 1)
                txtNo_VIo8.Focus();
        }

        private void txtAL9_TextChanged(object sender, EventArgs e)
        {
            if (txtAL9.Text.Length > 1)
                txtNo_VIo9.Focus();
        }

        private void txtAL10_TextChanged(object sender, EventArgs e)
        {
            if (txtAL10.Text.Length > 1)
                txtNo_VIo10.Focus();
        }

        private void txtAL11_TextChanged(object sender, EventArgs e)
        {
            if (txtAL11.Text.Length > 1)
                txtNo_VIo11.Focus();
        }

        private void txtAL12_TextChanged(object sender, EventArgs e)
        {
            if (txtAL12.Text.Length > 1)
                txtNo_VIo12.Focus();
        }

        #endregion

        #region ====== TextChange No_VI =======

        private void txtNo_VIo1_TextChanged(object sender, EventArgs e)
        {
            if (txtNo_VIo1.Text.Length > 3)
                txtClass1.Focus();
        }

        private void txtNo_VIo2_TextChanged(object sender, EventArgs e)
        {
            if (txtNo_VIo2.Text.Length > 3)
                txtClass2.Focus();
        }

        private void txtNo_VIo3_TextChanged(object sender, EventArgs e)
        {
            if (txtNo_VIo3.Text.Length > 3)
                txtClass3.Focus();
        }

        private void txtNo_VIo4_TextChanged(object sender, EventArgs e)
        {
            if (txtNo_VIo4.Text.Length > 3)
                txtClass4.Focus();
        }

        private void txtNo_VIo5_TextChanged(object sender, EventArgs e)
        {
            if (txtNo_VIo5.Text.Length > 3)
                txtClass5.Focus();
        }

        private void txtNo_VIo6_TextChanged(object sender, EventArgs e)
        {
            if (txtNo_VIo6.Text.Length > 3)
                txtClass6.Focus();
        }

        private void txtNo_VIo7_TextChanged(object sender, EventArgs e)
        {
            if (txtNo_VIo7.Text.Length > 3)
                txtClass7.Focus();
        }

        private void txtNo_VIo8_TextChanged(object sender, EventArgs e)
        {
            if (txtNo_VIo8.Text.Length > 3)
                txtClass8.Focus();
        }

        private void txtNo_VIo9_TextChanged(object sender, EventArgs e)
        {
            if (txtNo_VIo9.Text.Length > 3)
                txtClass9.Focus();
        }

        private void txtNo_VIo10_TextChanged(object sender, EventArgs e)
        {
            if (txtNo_VIo10.Text.Length > 3)
                txtClass10.Focus();
        }

        private void txtNo_VIo11_TextChanged(object sender, EventArgs e)
        {
            if (txtNo_VIo11.Text.Length > 3)
                txtClass11.Focus();
        }

        private void txtNo_VIo12_TextChanged(object sender, EventArgs e)
        {
            if (txtNo_VIo12.Text.Length > 3)
                txtClass12.Focus();
        }

        #endregion

        #region ===== TextChange Class ======

        private void txtClass1_TextChanged(object sender, EventArgs e)
        {
            if (txtClass1.Text.Length > 0)
                txtDate1.Focus();
        }

        private void txtClass2_TextChanged(object sender, EventArgs e)
        {
            if (txtClass2.Text.Length > 0)
                txtDate2.Focus();
        }

        private void txtClass3_TextChanged(object sender, EventArgs e)
        {
            if (txtClass3.Text.Length > 0)
                txtDate3.Focus();
        }

        private void txtClass4_TextChanged(object sender, EventArgs e)
        {
            if (txtClass4.Text.Length > 0)
                txtDate4.Focus();
        }

        private void txtClass5_TextChanged(object sender, EventArgs e)
        {
            if (txtClass5.Text.Length > 0)
                txtDate5.Focus();
        }

        private void txtClass6_TextChanged(object sender, EventArgs e)
        {
            if (txtClass6.Text.Length > 0)
                txtDate6.Focus();
        }

        private void txtClass7_TextChanged(object sender, EventArgs e)
        {
            if (txtClass7.Text.Length > 0)
                txtDate7.Focus();

        }

        private void txtClass8_TextChanged(object sender, EventArgs e)
        {
            if (txtClass8.Text.Length > 0)
                txtDate8.Focus();
        }

        private void txtClass9_TextChanged(object sender, EventArgs e)
        {
            if (txtClass9.Text.Length > 0)
                txtDate9.Focus();
        }

        private void txtClass10_TextChanged(object sender, EventArgs e)
        {
            if (txtClass10.Text.Length > 0)
                txtDate10.Focus();
        }

        private void txtClass11_TextChanged(object sender, EventArgs e)
        {
            if (txtClass11.Text.Length > 0)
                txtDate11.Focus();
        }

        private void txtClass12_TextChanged(object sender, EventArgs e)
        {
            if (txtClass12.Text.Length > 0)
                txtDate12.Focus();
        }

        #endregion

        #region ====== TextChange Date ======

        private void txtDate1_TextChanged(object sender, EventArgs e)
        {
            if (txtDate1.Text.Length > 4)
                txtOrigin1.Focus();
        }

        private void txtDate2_TextChanged(object sender, EventArgs e)
        {
            if (txtDate2.Text.Length > 4)
                txtOrigin2.Focus();
        }

        private void txtDate3_TextChanged(object sender, EventArgs e)
        {
            if (txtDate3.Text.Length > 4)
                txtOrigin3.Focus();
        }

        private void txtDate4_TextChanged(object sender, EventArgs e)
        {
            if (txtDate4.Text.Length > 4)
                txtOrigin4.Focus();
        }

        private void txtDate5_TextChanged(object sender, EventArgs e)
        {
            if (txtDate5.Text.Length > 4)
                txtOrigin5.Focus();
        }

        private void txtDate6_TextChanged(object sender, EventArgs e)
        {
            if (txtDate6.Text.Length > 4)
                txtOrigin6.Focus();
        }

        private void txtDate7_TextChanged(object sender, EventArgs e)
        {
            if (txtDate7.Text.Length > 4)
                txtOrigin7.Focus();
        }

        private void txtDate8_TextChanged(object sender, EventArgs e)
        {
            if (txtDate8.Text.Length > 4)
                txtOrigin8.Focus();
        }

        private void txtDate9_TextChanged(object sender, EventArgs e)
        {
            if (txtDate9.Text.Length > 4)
                txtOrigin9.Focus();
        }

        private void txtDate10_TextChanged(object sender, EventArgs e)
        {
            if (txtDate10.Text.Length > 4)
                txtOrigin10.Focus();
        }

        private void txtDate11_TextChanged(object sender, EventArgs e)
        {
            if (txtDate11.Text.Length > 4)
                txtOrigin11.Focus();
        }

        private void txtDate12_TextChanged(object sender, EventArgs e)
        {
            if (txtDate12.Text.Length > 4)
                txtOrigin12.Focus();
        }

        #endregion

        #region====== TextChange Origin ======

        private void txtOrigin1_TextChanged(object sender, EventArgs e)
        {
            if (txtOrigin1.Text.Length > 2)
                txtDestiny1.Focus();
        }

        private void txtOrigin2_TextChanged(object sender, EventArgs e)
        {
            if (txtOrigin2.Text.Length > 2)
                txtDestiny2.Focus();
        }

        private void txtOrigin3_TextChanged(object sender, EventArgs e)
        {
            if (txtOrigin3.Text.Length > 2)
                txtDestiny3.Focus();
        }

        private void txtOrigin4_TextChanged(object sender, EventArgs e)
        {
            if (txtOrigin4.Text.Length > 2)
                txtDestiny4.Focus();
        }

        private void txtOrigin5_TextChanged(object sender, EventArgs e)
        {
            if (txtOrigin5.Text.Length > 2)
                txtDestiny5.Focus();
        }

        private void txtOrigin6_TextChanged(object sender, EventArgs e)
        {
            if (txtOrigin6.Text.Length > 2)
                txtDestiny6.Focus();
        }

        private void txtOrigin7_TextChanged(object sender, EventArgs e)
        {
            if (txtOrigin7.Text.Length > 2)
                txtDestiny7.Focus();
        }

        private void txtOrigin8_TextChanged(object sender, EventArgs e)
        {
            if (txtOrigin8.Text.Length > 2)
                txtDestiny8.Focus();
        }

        private void txtOrigin9_TextChanged(object sender, EventArgs e)
        {
            if (txtOrigin9.Text.Length > 2)
                txtDestiny9.Focus();
        }

        private void txtOrigin10_TextChanged(object sender, EventArgs e)
        {
            if (txtOrigin10.Text.Length > 2)
                txtDestiny10.Focus();
        }

        private void txtOrigin11_TextChanged(object sender, EventArgs e)
        {
            if (txtOrigin11.Text.Length > 2)
                txtDestiny11.Focus();
        }

        private void txtOrigin12_TextChanged(object sender, EventArgs e)
        {
            if (txtOrigin12.Text.Length > 2)
                txtDestiny12.Focus();
        }

        #endregion

        #region ====== TextChange Destiny ======

        private void txtDestiny1_TextChanged(object sender, EventArgs e)
        {
            if (txtDestiny1.Text.Length > 2)
                txtStatus1.Focus();
        }

        private void txtDestiny2_TextChanged(object sender, EventArgs e)
        {
            if (txtDestiny2.Text.Length > 2)
                txtStatus2.Focus();
        }

        private void txtDestiny3_TextChanged(object sender, EventArgs e)
        {
            if (txtDestiny3.Text.Length > 2)
                txtStatus3.Focus();
        }

        private void txtDestiny4_TextChanged(object sender, EventArgs e)
        {
            if (txtDestiny4.Text.Length > 2)
                txtStatus4.Focus();
        }

        private void txtDestiny5_TextChanged(object sender, EventArgs e)
        {
            if (txtDestiny5.Text.Length > 2)
                txtStatus5.Focus();
        }

        private void txtDestiny6_TextChanged(object sender, EventArgs e)
        {
            if (txtDestiny6.Text.Length > 2)
                txtStatus6.Focus();
        }

        private void txtDestiny7_TextChanged(object sender, EventArgs e)
        {
            if (txtDestiny7.Text.Length > 2)
                txtStatus7.Focus();
        }

        private void txtDestiny8_TextChanged(object sender, EventArgs e)
        {
            if (txtDestiny8.Text.Length > 2)
                txtStatus8.Focus();
        }

        private void txtDestiny9_TextChanged(object sender, EventArgs e)
        {
            if (txtDestiny9.Text.Length > 2)
                txtStatus9.Focus();
        }

        private void txtDestiny10_TextChanged(object sender, EventArgs e)
        {
            if (txtDestiny10.Text.Length > 2)
                txtStatus10.Focus();
        }

        private void txtDestiny11_TextChanged(object sender, EventArgs e)
        {
            if (txtDestiny11.Text.Length > 2)
                txtStatus11.Focus();
        }

        private void txtDestiny12_TextChanged(object sender, EventArgs e)
        {
            if (txtDestiny12.Text.Length > 2)
                txtStatus12.Focus();
        }

        #endregion

        #region ====== TextChange Status ======

        private void txtStatus1_TextChanged(object sender, EventArgs e)
        {
            if (txtStatus1.Text.Length > 1)
                txtConfirm1.Focus();
        }

        private void txtStatus2_TextChanged(object sender, EventArgs e)
        {
            if (txtStatus2.Text.Length > 1)
                txtConfirm2.Focus();
        }

        private void txtStatus3_TextChanged(object sender, EventArgs e)
        {
            if (txtStatus3.Text.Length > 1)
                txtConfirm3.Focus();
        }

        private void txtStatus4_TextChanged(object sender, EventArgs e)
        {
            if (txtStatus4.Text.Length > 1)
                txtConfirm4.Focus();
        }

        private void txtStatus5_TextChanged(object sender, EventArgs e)
        {
            if (txtStatus5.Text.Length > 1)
                txtConfirm5.Focus();
        }

        private void txtStatus6_TextChanged(object sender, EventArgs e)
        {
            if (txtStatus6.Text.Length > 1)
                txtConfirm6.Focus();
        }

        private void txtStatus7_TextChanged(object sender, EventArgs e)
        {
            if (txtStatus7.Text.Length > 1)
                txtConfirm7.Focus();
        }

        private void txtStatus8_TextChanged(object sender, EventArgs e)
        {
            if (txtStatus8.Text.Length > 1)
                txtConfirm8.Focus();
        }

        private void txtStatus9_TextChanged(object sender, EventArgs e)
        {
            if (txtStatus9.Text.Length > 1)
                txtConfirm9.Focus();
        }

        private void txtStatus10_TextChanged(object sender, EventArgs e)
        {
            if (txtStatus10.Text.Length > 1)
                txtConfirm10.Focus();
        }

        private void txtStatus11_TextChanged(object sender, EventArgs e)
        {
            if (txtStatus11.Text.Length > 1)
                txtConfirm11.Focus();
        }

        private void txtStatus12_TextChanged(object sender, EventArgs e)
        {
            if (txtStatus12.Text.Length > 1)
                txtConfirm12.Focus();
        }

        #endregion

        #region ======= TextChange Confirm ======

        private void txtConfirm1_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirm1.Text.Length > 7)
                txtAL2.Focus();
        }

        private void txtConfirm2_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirm2.Text.Length > 7)
                txtAL3.Focus();
        }

        private void txtConfirm3_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirm3.Text.Length > 7)
                txtAL4.Focus();
        }

        private void txtConfirm4_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirm4.Text.Length > 7)
                txtAL5.Focus();
        }

        private void txtConfirm5_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirm5.Text.Length > 7)
                txtAL6.Focus();
        }

        private void txtConfirm6_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirm6.Text.Length > 7)
                txtAL7.Focus();
        }

        private void txtConfirm7_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirm7.Text.Length > 7)
                txtAL8.Focus();
        }

        private void txtConfirm8_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirm8.Text.Length > 7)
                txtAL9.Focus();
        }

        private void txtConfirm9_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirm9.Text.Length > 7)
                txtAL10.Focus();
        }

        private void txtConfirm10_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirm10.Text.Length > 7)
                txtAL11.Focus();
        }

        private void txtConfirm11_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirm11.Text.Length > 7)
                txtAL10.Focus();
        }

        private void txtConfirm12_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirm12.Text.Length > 7)
                btnAccept.Focus();
        }

        #endregion
    }
}
