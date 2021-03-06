﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucAssignQueueSignature : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Asigna Queue a una Firma
        /// Creación:    10-Diciembre-2010 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Ivan Martínez
        /// </summary>        

        public ucAssignQueueSignature()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            InitialControlFocus = txtQueue;
            LastControlFocus = btnAccept;
        }

        #region ====Declarations====
        private bool statusValidPCC;
        private TextBox txt;
        #endregion

        private void ucAssignQueueSignature_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtQueue.Focus();
            lbPCC.BringToFront();
            lbPCC.Visible = false;
        }

        //Valida y llama el método de comandos 
        private void btnAccept_Click(object sender, EventArgs e)
        {
            List<ListItem> CatPccsList = CatPccsBL.GetPccs(txtPCC.Text, Login.OrgId);
            if (CatPccsList.Count.Equals(0))
                statusValidPCC = true;
            else
                statusValidPCC = false;

            if (IsValidBussinessRules)
            {
                CommandsSend();
            }
        }


        #region====Events====

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
            {
                VolarisSession.Clean();
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }

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

        //Despliega opciones y elige opción con la tecla Enter     
        private void lbPCC_KeyDown(object sender, KeyEventArgs e)
        {
            ListBox ListBox = (ListBox)sender;
            TextBox txt = (TextBox)txtPCC;

            if (e.KeyCode == Keys.Enter)
            {
                ListItem li = (ListItem)ListBox.SelectedItem;
                txt.Text = li.Value;
                lbPCC.Visible = false;
                txt.Focus();
            }
        }

        //Selecciona la opción de la Lista con el click del mouse
        private void ListBox_MouseClick(object sender, MouseEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            TextBox txt = (TextBox)txtPCC;

            ListItem li = (ListItem)listBox.SelectedItem;
            txt.Text = li.Value;
            lbPCC.Visible = false;
            txt.Focus();
        }

        //Crea el campo predictivo
        private void txtPCC_TextChanged(object sender, EventArgs e)
        {
            txt = (TextBox)sender;
            Common.SetListBoxPCCs(txt, lbPCC);
        }
        #endregion

        #region====MethodsClass====

        //Verifica si los datos obligatorios fueron ingresados
        private bool IsValidBussinessRules
        {
            get
            {
                bool isValid = false;
                if (string.IsNullOrEmpty(txtQueue.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR QUEUE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQueue.Focus();
                }
                else if (string.IsNullOrEmpty(txtPCC.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR PCC", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPCC.Focus();
                }
                else if (string.IsNullOrEmpty(txtAgentCode.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR CÓDIGO DE AGENTE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAgentCode.Focus();
                }
                else if (string.IsNullOrEmpty(txtFirm.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR FIRMA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFirm.Focus();
                }
                else
                    isValid = true;

                return isValid;
            }
        }


        //Envía las instrucciones a MySabre
        private void CommandsSend()
        {
            int row = 0;
            int col = 0;
            string send = string.Empty;
            string res = string.Empty;
            string sabre = "QS/";


            send = string.Concat(sabre, txtPCC.Text, txtQueue.Text, "/A-", txtAgentCode.Text);
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                res = objCommand.SendReceive(send);
            }
            CommandsQik.searchResponse(res, string.Concat("UPDATE PROCESSED"), ref row, ref col);
            if (row != 0 || col != 0)
            {
                User userData = UserBL.GetUser(txtFirm.Text, txtPCC.Text);

                if (AssignQueueFirmBL.AssignQueueFirm(txtQueue.Text, txtAgentCode.Text, txtPCC.Text))
                {
                    UpdateStatusAllFirmModulesBL.UpdateStatusQueue(txtQueue.Text);
                    UpdateStatusAllFirmModulesBL.UpdateUnassignStatusQueue(userData.Queue);
                    MessageBox.Show("QUEUE ASIGNADA CORRECTAMENTE", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("HA OCURRIDO UN ERROR EN LA ACTUALIZACIÓN", Resources.Constants.MYCTS, MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("ERROR EN LA CONEXIÓN CON MySABRE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}
