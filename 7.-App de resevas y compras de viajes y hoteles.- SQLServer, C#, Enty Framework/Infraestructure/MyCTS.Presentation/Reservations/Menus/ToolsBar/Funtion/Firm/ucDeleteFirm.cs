using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Entities;
using MyCTS.Business;

namespace MyCTS.Presentation
{
    public partial class ucDeleteFirm : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite habilitar y deshabilitar firma 
        /// Creación:    10-Mayo-10 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        bool statusValidPCC;
        TextBox txt;

        public ucDeleteFirm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer, true);
            InitialControlFocus = txtNumberFirm;
            LastControlFocus = btnAccept;
        }

        //Extrae agente y coloca foco en textbox
        private void ucDeleteFirm_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            string agent = string.Empty;
            CatQueue item = CatQueueBL.GetQueue(Login.Firm, Login.PCC);
            if (!string.IsNullOrEmpty(item.Agent))
            {
                agent = item.Agent;
            }
            txtAuthorization.Text = agent;
            lbPCC.BringToFront();
            txtNumberFirm.Focus();
            rbnBoth.Select();
        }

        //Valida el PCC y manda a llamar el metodo de validación y envió de comando
        private void btnAccept_Click(object sender, EventArgs e)
        {
            List<ListItem> CatPccsList = CatPccsBL.GetPccs(txtPCC.Text, Login.OrgId);
            if (CatPccsList.Count.Equals(0))
                statusValidPCC = true;
            else
                statusValidPCC = false;
            if (IsValidateBusinessRules)
                CommandsSend();
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
            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
            if (e.KeyCode == Keys.Down)
            {
                if (lbPCC.Items.Count > 0)
                {
                    lbPCC.SelectedIndex = 0;
                    lbPCC.Focus();
                }
            }
        }

        #region ====== Events ====

        //Show ListBox
        private void txtPCC_TextChanged(object sender, EventArgs e)
        {
            txt = (TextBox)sender;
            Common.SetListBoxPCCs(txt, lbPCC);
        }

        //KeyDow ListBox
        private void lbPCC_KeyDown(object sender, KeyEventArgs e)
        {
            ListBox ListBox = (ListBox)sender;
            TextBox txt = txtPCC;

            if (e.KeyCode == Keys.Enter)
            {
                ListItem li = (ListItem)ListBox.SelectedItem;
                txt.Text = li.Value;
                lbPCC.Visible = false;
                txt.Focus();
            }
        }

        //Mouse Click
        private void ListBox_MouseClick(object sender, MouseEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            TextBox txt = txtPCC;

            ListItem li = (ListItem)listBox.SelectedItem;
            txt.Text = li.Value;
            lbPCC.Visible = false;
            txt.Focus();
        }

        private void txtNumberFirm_TextChanged(object sender, EventArgs e)
        {
            if (txtNumberFirm.Text.Length > 3)
                txtQueue.Focus();
        }

        private void txtQueue_TextChanged(object sender, EventArgs e)
        {
            if (txtQueue.Text.Length > 2)
                txtAgent.Focus();
        }

        private void txtAgent_TextChanged(object sender, EventArgs e)
        {
            if (txtAgent.Text.Length > 1)
                txtPCC.Focus();
        }

        private void txtAuthorization_TextChanged(object sender, EventArgs e)
        {
            if (txtAuthorization.Text.Length > 14)
                btnAccept.Focus();
        }

        #endregion

        #region ===== methodsClass =====

        /// <summary>
        /// Se validan que existan los datos que son obligatorios y que 
        /// sean los datos correctos
        /// </summary>
        private bool IsValidateBusinessRules
        {
            get
            {
                bool isValid = false;

                if (string.IsNullOrEmpty(txtNumberFirm.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_NUMERO_FIRMA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberFirm.Focus();
                }
                else if (string.IsNullOrEmpty(txtQueue.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_QUEUE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQueue.Focus();
                }
                else if (string.IsNullOrEmpty(txtAgent.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_CÓDIGO_AGENTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAgent.Focus();
                }
                else if (string.IsNullOrEmpty(txtPCC.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESE_PCC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPCC.Focus();
                }
                else if (!string.IsNullOrEmpty(txtPCC.Text) && txtPCC.Text.Length < 4)
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_PCC_CORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPCC.Focus();
                }
                else if (statusValidPCC)
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_PCC_CORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPCC.Focus();
                }
                else if (string.IsNullOrEmpty(txtAuthorization.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_AUTORIZADO_POR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAuthorization.Focus();
                }
                else
                {
                    isValid = true;
                }
                return isValid;
            }
        }

        /// <summary>
        /// Se envia el comando de acuerdo a los campos ingresados
        /// </summary>
        private void CommandsSend()
        {
            User usuarioDto = null;
            usuarioDto = UserBL.GetUser(txtNumberFirm.Text, txtPCC.Text);

            
            if (rbnBoth.Checked)
            {
                int row = 0;
                int col = 0;
                string result = string.Empty;
                string sabre = string.Empty;

                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(string.Concat("QMOV/", usuarioDto.PCC, usuarioDto.Queue, "/", usuarioDto.PCC, "152"));
                }

                string send = string.Concat("HB", txtNumberFirm.Text);
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    result = objCommand.SendReceive(send);
                }
                CommandsQik.searchResponse(result, "NEW EMPLOYEE", ref row, ref col);
                if (row != 0 || col != 0)
                {
                    row = 0;
                    col = 0;
                    MessageBox.Show(Resources.Reservations.LA_FIRMA_NO_EXISTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        result = objCommand.SendReceive("I");
                    }
                }
                else
                {
                    send = string.Concat("H/AUTH BY ", txtAuthorization.Text);
                    sabre = string.Concat("HX*REUSE");

                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        objCommand.SendReceive(send);
                        result = objCommand.SendReceive(sabre);
                    }

                    CommandsQik.searchResponse(result, "DONE", ref row, ref col);
                    if (row != 0 || col != 0)
                    {
                        send = string.Concat("QS/", txtPCC.Text, txtQueue.Text, "/D-", txtAgent.Text);
                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            objCommand.SendReceive(send);
                        }

                        CommandsAPI2.send_MessageToEmulator(string.Concat(Resources.Reservations.FIRMA_ELIMINADA_EXITO));
                        //DeleteUsersBL.DeleteUsers(txtNumberFirm.Text, txtPCC.Text);
                        EnableDisableFirmBL.EnableDisableFirm(txtNumberFirm.Text, txtPCC.Text, 2);
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                        MessageBox.Show(Resources.Reservations.FIRMA_FUE_ELIMINADA_EXITO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(Resources.Reservations.PRESENTO_ERROR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            objCommand.SendReceive("I");
                        }
                    }

                }

                if (!string.IsNullOrEmpty(usuarioDto.Firm))
                {
                    UpdateStatusAllFirmModulesBL.UpdateUnassignStatusTA(usuarioDto.TA);
                    UpdateStatusAllFirmModulesBL.UpdateUnassignStatusQueue(usuarioDto.Queue);
                    UpdateStatusAllFirmModulesBL.UpdateUnassignStatusAgent(usuarioDto.Agent);
                    //UpdateStatusAllFirmModulesBL.UpdateUnassignStatusFirm(usuarioDto.Firm);
                }
                MessageBox.Show("FIRMA ELIMINADA CORRECTAMENTE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            if (rbnMyCTS.Checked)
            {
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(string.Concat("QMOV/",usuarioDto.PCC, usuarioDto.Queue,"/", usuarioDto.PCC, " 152"));
                }
                //DeleteUsersBL.DeleteUsers(txtNumberFirm.Text, txtPCC.Text);
                EnableDisableFirmBL.EnableDisableFirm(txtNumberFirm.Text, txtPCC.Text, 2);
                if (!string.IsNullOrEmpty(usuarioDto.Firm))
                {
                    UpdateStatusAllFirmModulesBL.UpdateUnassignStatusTA(usuarioDto.TA);
                    UpdateStatusAllFirmModulesBL.UpdateUnassignStatusQueue(usuarioDto.Queue);
                    UpdateStatusAllFirmModulesBL.UpdateUnassignStatusAgent(usuarioDto.Agent);
                    //UpdateStatusAllFirmModulesBL.UpdateUnassignStatusFirm(usuarioDto.Firm);
                }
                MessageBox.Show("LA FIRMA FUE ELIMINADA CON ÉXITO DE MyCTS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }


            if (rbnSabre.Checked)
            {
                int row = 0;
                int col = 0;
                string result = string.Empty;
                string sabre = string.Empty;

                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(string.Concat("QMOV/", usuarioDto.PCC, usuarioDto.Queue, "/", usuarioDto.PCC, " 152"));
                }

                string send = string.Concat("HB", txtNumberFirm.Text);
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    result = objCommand.SendReceive(send);
                }
                CommandsQik.searchResponse(result, "NEW EMPLOYEE", ref row, ref col);
                if (row != 0 || col != 0)
                {
                    row = 0;
                    col = 0;
                    MessageBox.Show(Resources.Reservations.LA_FIRMA_NO_EXISTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        result = objCommand.SendReceive("I");
                    }
                }
                else
                {
                    send = string.Concat("H/AUTH BY ", txtAuthorization.Text);
                    sabre = string.Concat("HX*REUSE");

                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        objCommand.SendReceive(send);
                        result = objCommand.SendReceive(sabre);
                    }

                    CommandsQik.searchResponse(result, "DONE", ref row, ref col);
                    if (row != 0 || col != 0)
                    {
                        send = string.Concat("QS/", txtPCC.Text, txtQueue.Text, "/D-", txtAgent.Text);
                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            objCommand.SendReceive(send);
                        }

                        CommandsAPI2.send_MessageToEmulator(string.Concat(Resources.Reservations.FIRMA_ELIMINADA_EXITO));
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                    }
                    else
                    {
                        MessageBox.Show(Resources.Reservations.PRESENTO_ERROR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            objCommand.SendReceive("I");
                        }
                    }

                }
                MessageBox.Show("FIRMA ELIMINADA CORRECTAMENTE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion
    }
}
