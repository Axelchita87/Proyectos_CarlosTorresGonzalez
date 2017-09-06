using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;


namespace MyCTS.Presentation
{
    public partial class ucPCC : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite cambiar PCC,pertenece a Funciones Rapidas
        /// Creación:    Marzo-Abril 09 , Modificación:7/Julio/09
        /// Cambio:      Predictivo    , Solicito Eduardo
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        private TextBox txt;
        private bool statusValidPCC;

        public ucPCC()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtPCC;
            this.LastControlFocus = btnAccept;
        }

        //User Control Load
        private void ucPCC_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtPCC.Focus();
            lbPCC.BringToFront();
            lbPCC.Visible = false;
        }


        //Button Accept
        /// <summary>
        /// Verifica que el PCC escrito coincida con los que se encuentran en la Base de Datos
        /// Se realizan las validaciones despues de que el usuario ingresa datos, 
        /// se mandan los comandos y termina el proceso llamando a otro User Control 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            List<ListItem> CatPccsList = CatPccsBL.GetPccs(txtPCC.Text,Login.OrgId);
            if (CatPccsList.Count.Equals(0))
                statusValidPCC = true;
            else
                statusValidPCC = false;
            if (IsValidateBusinessRules)
               CommandsSend();
        }

        //KeyDown
        /// <summary>
        /// Este se usa para todos los controles en general si se oprime 
        /// Esc se manda a el User control de Welcome 
        /// Enter se manda la accion de botón de Aceptar
        /// KeyDown se manda el foco al listBox
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
            TextBox txt = (TextBox)txtPCC;

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
            TextBox txt = (TextBox)txtPCC;

            ListItem li = (ListItem)listBox.SelectedItem;
            txt.Text = li.Value;
            lbPCC.Visible = false;
            txt.Focus();
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
                if (string.IsNullOrEmpty(txtPCC.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESE_PCC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPCC.Focus();
                    return false;
                }
                else if (!string.IsNullOrEmpty(txtPCC.Text) && txtPCC.Text.Length < 4)
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_PCC_CORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPCC.Focus();
                    return false;
                }
                else if (statusValidPCC)
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_PCC_CORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPCC.Focus();
                    return false;
                }
                else
                    return true;
            }
        }

        /// <summary>
        /// Se envia el comando de acuerdo a los campos ingresados
        /// </summary>
        private void CommandsSend()
        {
            string extract;
            string send;
            extract = txtPCC.Text;
                send = Resources.Constants.COMMANDS_AAA + extract.Substring(0, 4);
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(send);
                }
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }

        #endregion
    }
}
