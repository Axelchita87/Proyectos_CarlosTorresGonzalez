using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Entities;
using MyCTS.Business;



namespace MyCTS.Presentation
{
    public partial class ucFirmList : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite extraer la lista de firmas
        /// Creación:    06-Mayo-10 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        string pcc = string.Empty;

        public ucFirmList()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer, true);
            InitialControlFocus =txtFirm;
            LastControlFocus = btnAccept;

        }

        //Colocar el foco el textbox de firma
        private void ucFirmList_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtFirm.Focus();
        }

        //Llamar a los metodos de validación y envio de comandos
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidBussinessRules)
                SendCommand();
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

        #region ======= Methods ========
        //Valida que los campos obligatorios no esten vacios
        private bool IsValidBussinessRules
        {
            get
            {
                bool isVaid = false;
                if (!string.IsNullOrEmpty(txtFirm.Text) && !string.IsNullOrEmpty(txtAgent.Text))
                {
                    // ReSharper disable LocalizableElement
                    MessageBox.Show("REQUIERE INGRESAR SOLO UN DATO, NÚMERO DE FIRMA O AGENTE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // ReSharper restore LocalizableElement
                    txtFirm.Focus();
                }
                else if (string.IsNullOrEmpty(txtFirm.Text) && string.IsNullOrEmpty(txtAgent.Text))
                {
                    // ReSharper disable LocalizableElement
                    MessageBox.Show("REQUIERE INGRESAR UN DATO, NÚMERO DE FIRMA O AGENTE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // ReSharper restore LocalizableElement
                    txtFirm.Focus();
                }
                else
                {
                    isVaid = true;
                }
                return isVaid;
            }
        }

        //Manda comando o muestra los datos deacuerdo a la opción elegida
        private void SendCommand()
        {
            int row = 0;
            bool uno = true;
            string result = string.Empty;
            string sabre = string.Empty;
            string send = string.Empty;

            sabre = string.Concat("*S");

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive("I");
                result = objCommand.SendReceive(sabre);
            }
            row = row + 1;
            CommandsQik.CopyResponse(result, ref pcc, row, 1, 4);
            sabre = "H*CST";
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                result = objCommand.SendReceive(sabre);
            }

            row = 0;
            int col = 0;

            if (!string.IsNullOrEmpty(txtFirm.Text))
            {
                while (uno)
                {
                    CommandsQik.searchResponse(result, txtFirm.Text, ref row, ref col, 1, 19, 2, 6);
                    if (row != 0 || col != 0)
                    {
                        row = 0;
                        col = 0;

                        send = "MD";
                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            result = objCommand.SendReceive(send);
                        }
                    }
                    CommandsQik.searchResponse(result, "END OF SCROLL", ref row, ref col);
                    if (row != 0 || col != 0)
                    {
                        MessageBox.Show(Resources.Reservations.NUMERO_FIRMA_NO_ENCONTRADA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        row = 0;
                        col = 0;
                        break;
                    }
                    CommandsQik.searchResponse(result, "RESTRICTED", ref row, ref col);
                    if (row != 0 || col != 0)
                    {
                        break;
                    }
                }

                ShowList();
            }
            else
            {
                while (uno)
                {
                    CommandsQik.searchResponse(result, txtAgent.Text, ref row, ref col);
                    if (row != 0 || col != 0)
                    {
                        row = 0;
                        col = 0;
                   
                        send = "MD";
                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            result = objCommand.SendReceive(send);
                        }
                    }

                    CommandsQik.searchResponse(result, "END OF SCROLL", ref row, ref col);
                    if (row != 0 || col != 0)
                    {
                        MessageBox.Show(Resources.Reservations.CODIGO_AGENTE_NO_ENCONTRADO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        row = 0;
                        col = 0;
                        break;
                    }

                    CommandsQik.searchResponse(result, "RESTRICTED", ref row, ref col);
                    if (row != 0 || col != 0)
                    {
                        break;
                    }
                }
                ShowList();
            }

        }

        //Extrae la lista de la BdD
        private void ShowList()
        {
            List<UsersSelectByPCC> list = UsersSelectByPCCBL.GetUsersSelectByPCC(pcc);
            if (list.Count > 0)
            {
                bindingSource1.DataSource = list;
                dgvFirm.Visible = true;
                dgvFirm.Focus();
                if (!string.IsNullOrEmpty(txtFirm.Text))
                {
                    if (dgvFirm.Columns[0].HeaderText == "Firm")
                    {
                        for (int i = 0; i <= dgvFirm.RowCount - 1; i++)
                        {
                            if (dgvFirm.Rows[i].Cells[0].Value.ToString() == txtFirm.Text)
                            {
                                dgvFirm.CurrentCell = dgvFirm.Rows[i].Cells[0];
                                break;
                            }
                            else
                                i++;
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(txtAgent.Text))
                {
                    if (dgvFirm.Columns[1].HeaderText == "Agent")
                    {
                        for (int i = 0; i <= dgvFirm.RowCount - 1; i++)
                        {
                            if (dgvFirm.Rows[i].Cells[1].Value.ToString() == txtAgent.Text)
                            {
                                dgvFirm.CurrentCell = dgvFirm.Rows[i].Cells[1];
                                break;
                            }
                            else
                                i++;
                        }
                    }
                }
            }
        }

        #endregion
    }
}
