using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MyCTS.Presentation.Components;


namespace MyCTS.Presentation
{
    public partial class ucIgnoreRecord : CustomUserControl
    {
        /// <summary>
        /// Descripción: User Control que permite ignorar las acciones echas en MySabre
        ///              con una serie de opciones
        /// Creación:    Marzo - Abril 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        /// 
        public ucIgnoreRecord()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = rdoIgnore;
            this.LastControlFocus = btnAccept;

        }

        private string send;

        //Evento Load
        private void ucIgnoreRecord_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            rdoIgnore.Focus();
        }


        /// <summary>
        /// Ejecuta las funciones de la mascarilla al presionar el boton
        /// "Aceptar"
        /// </summary>
        /// <param name="sender">btnAccept</param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (rdoIgnore.Checked)
            {
                IgnoreCommandsSend();
            }
            else if (rdoIgnoreAndSave.Checked)
            {
                IgnoreAndSaveCommandsSend();
            }
            else if (rdoIgnoreAndClone.Checked)
            {
                IgnoreAndCloneCommandsSend();
            }
        }

        #region===== MethodsClass =====


        #region===== rdoIgnore =====

        /// <summary>
        /// Armado y envio del comando a MySabre cuando al opción
        /// "Ignorar" esta selccionada y se presiona el boton Aceptar
        /// </summary>
        public void IgnoreCommandsSend()
        {
            string ignore;
            ignore = Resources.Constants.IGNORE;
            send = ignore;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }


        #endregion//End rdoIgnore



        #region===== rdoIgnoreAndSave =====

        /// <summary>
        /// Armado y envio del comando a MySabre cuando al opción
        /// "Ignora y recupera" esta selccionada y se presiona el boton Aceptar
        /// </summary>
        public void IgnoreAndSaveCommandsSend()
        {
            string ignoreAndSave;
            ignoreAndSave = Resources.Constants.COMMANDS_IR;
            send = ignoreAndSave;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }


        #endregion//End rdoIgnoreAndSave



        #region=====rdoIgnoreAndClone =====

        /// <summary>
        /// Habilita ciertos controles cuando la opción "Ignora y clona"
        /// esta habilitada
        public void IgnoreAndCloneEnableDisableControls()
        {
            lblAvoidSegments.Visible = true;
            lblAvoidTheseSegments.Visible = true;
            lblChangeReservedSpaces.Visible = true;
            lblIforAll.Visible = true;
            txtAvoidSegments.Visible = true;
            txtChangeReservedSpaces.Visible = true;
            cmbSegments.Visible = true;
            chkCopyRecord.Visible = true;
        }


        /// <summary>
        /// Armado y envio del comando a MySabre cuando al opción
        /// "Ignora y recupera" esta selccionada y se presiona el boton Aceptar
        /// </summary>
        public void IgnoreAndCloneCommandsSend()
        {
            string avoidSegments;
            string segments;
            string changeReservedSpaces;
            string copyRecord;
            string ignoreAndClone;
            ignoreAndClone = Resources.Constants.COMMANDS_IC;
            send = string.Empty;
            if (!string.IsNullOrEmpty(txtAvoidSegments.Text))
            {
                avoidSegments = string.Concat(Resources.Constants.COMMANDS_X,
                    txtAvoidSegments.Text);
            }
            else
            {
                avoidSegments = string.Empty;
            }
            if (!string.IsNullOrEmpty(cmbSegments.Text))
            {
                if (!string.IsNullOrEmpty(txtAvoidSegments.Text))
                {
                    string[] SegmentCode = Regex.Split(cmbSegments.Text, Resources.Constants.INDENT);
                    segments = string.Concat(Resources.Constants.COMMANDS_COMA_X,
                        SegmentCode[0]);
                }
                else
                {
                    string[] SegmentCode = Regex.Split(cmbSegments.Text, Resources.Constants.INDENT);
                    segments = string.Concat(Resources.Constants.COMMANDS_X,
                        SegmentCode[0]);
                }

            }
            else
            {
                segments = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtChangeReservedSpaces.Text))
            {
                if ((string.IsNullOrEmpty(txtAvoidSegments.Text)) &&
                    (string.IsNullOrEmpty(cmbSegments.Text)))
                {
                    changeReservedSpaces = string.Concat(Resources.Constants.COMMANDS_B,
                        txtChangeReservedSpaces.Text);
                }
                else
                {
                    changeReservedSpaces = string.Concat(Resources.Constants.COMMANDS_COMA_B,
                        txtChangeReservedSpaces.Text);
                }

            }
            else
            {
                changeReservedSpaces = string.Empty;
            }
            if (chkCopyRecord.Checked)
            {
                if ((string.IsNullOrEmpty(txtAvoidSegments.Text)) &&
                   (string.IsNullOrEmpty(cmbSegments.Text)) &&
                   (string.IsNullOrEmpty(txtChangeReservedSpaces.Text)))
                {
                    copyRecord = Resources.Constants.COMMANDS_APD;
                }
                else
                {
                    copyRecord = Resources.Constants.COMMANDS_COMA_APD;
                }

            }
            else
            {
                copyRecord = string.Empty;
            }
            send = string.Concat(ignoreAndClone,
            avoidSegments,
            segments,
            changeReservedSpaces,
            copyRecord);
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }
        #endregion//End rdoIgnoreAndClone



        #region===== commons =====

        /// <summary>
        /// Inhabilita algunos controles cuando la opción "Ignora y clona"
        /// no esta habilitada
        /// </summary>
        /// <param name="enable"></param>
        public void EnableControls(bool enable)
        {
            if (enable)
            {
                lblAvoidSegments.Visible = false;
                lblAvoidTheseSegments.Visible = false;
                lblChangeReservedSpaces.Visible = false;
                lblIforAll.Visible = false;
                txtAvoidSegments.Visible = false;
                txtChangeReservedSpaces.Visible = false;
                cmbSegments.Visible = false;
                chkCopyRecord.Visible = false;
                txtAvoidSegments.Text = string.Empty;
                txtChangeReservedSpaces.Text = string.Empty;
                cmbSegments.Text = string.Empty;
                chkCopyRecord.Checked = false;
            }
        }


        #endregion//End commons



        #endregion//End MethodsClass



        #region===== Enable Disable controls =====

        //Evento rdoIgnore_CheckedChanged
        private void rdoIgnore_CheckedChanged(object sender, EventArgs e)
        {
            EnableControls(rdoIgnore.Checked);
        }


        //Evento rdoIgnoreAndSave_CheckedChanged
        private void rdoIgnoreAndSave_CheckedChanged(object sender, EventArgs e)
        {
            EnableControls(rdoIgnoreAndSave.Checked);
        }


        //Evento rdoIgnoreAndClone_CheckedChanged
        private void rdoIgnoreAndClone_CheckedChanged(object sender, EventArgs e)
        {
            IgnoreAndCloneEnableDisableControls();
        }

        #endregion//End Enable Disable controls



        #region=====Change focus When a Textbox is Full=====

        //Evento txtAvoidSegments_TextChanged 
        private void txtAvoidSegments_TextChanged(object sender, EventArgs e)
        {
            if (txtAvoidSegments.Text.Length > 4)
            {
                cmbSegments.Focus();
            }
        }

        //Evento txtChangeReservedSpaces_TextChanged 
        private void txtChangeReservedSpaces_TextChanged(object sender, EventArgs e)
        {
            if (txtChangeReservedSpaces.Text.Length > 0)
            {
                chkCopyRecord.Focus();
            }
        }


        #endregion//End Change focus When a Textbox is Full



        #region =====Back to a Previous Usercontrol or Validate Enter KeyDown=====


        /// <summary>
        /// Aborta el proceso al presionar la tecla ESC o ejecuta las 
        /// isntrucciones al presionar la tecla ENTER
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
