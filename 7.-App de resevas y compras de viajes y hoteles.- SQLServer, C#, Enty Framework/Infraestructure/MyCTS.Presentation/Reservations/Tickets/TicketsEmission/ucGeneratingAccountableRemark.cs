using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucGeneratingAccountableRemark : CustomUserControl, IProcessAsync
    {
        /// <summary>
        /// Descripción: User Control que convierte código de autorización a remark
        ///              contable. Solo valido para consolid
        ///              Pertenece al flujo de emisión de boleto de la aplicación.
        /// Creación:    Mayo - Junio 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        /// 

        //****************
        private string UC = string.Empty;
        //****************

        public ucGeneratingAccountableRemark()
        {
            InitializeComponent();
        }

        private void ucGeneratingAccountableRemark_Load(object sender, EventArgs e)
        {
            //frmPreloading fr = new frmPreloading(this);
            //fr.Show();
            ucAvailability.IsInterJetProcess = false;
            GeneratingAccountableRemark();

        }

        void IProcessAsync.InitProcess()
        {
            GeneratingAccountableRemark();
        }

        void IProcessAsync.EndProcess()
        {
            if (UC.Equals("billigAddress"))
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCBILLINGADRESS);
        }

        #region===== MethodsClass =====

        /// <summary>
        /// Generación de código de autorización a remark contable
        /// </summary>
        private void GeneratingAccountableRemark()
        {
            string active = activeStepsCorporativeQC.CorporativeQualityControls[0].RemarkContableAuthorization;
            if (active.Equals(Resources.TicketEmission.Constants.ACTIVE))
            {
                string send = string.Empty;
                string sabreAnswer = string.Empty;
                string tempChar = string.Empty;
                int row = 0;
                int col = 0;
                send = Resources.TicketEmission.Constants.COMMANDS_AST_P5;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    sabreAnswer = objCommand.SendReceive(send);
                }
                CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.DOT_W, ref row, ref col, 1, 18, 4, 7);
                if (row != 0 || col != 0)
                {
                    tempChar = string.Empty;
                    CommandsQik.CopyResponse(sabreAnswer, ref tempChar, row, 5, 10);
                }
                else
                {

                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        send = Resources.TicketEmission.Constants.COMMANDS_MD;
                        sabreAnswer = objCommand.SendReceive(send);
                    }
                    row = 0;
                    col = 0;
                    CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.NOTHING_TO_SCROLL, ref row, ref col);
                    if (row != 0 || col != 0)
                    {
                    }
                    else
                    {
                        CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.DOT_W, ref row, ref col, 1, 18, 4, 5);
                        if (row != 0 || col != 0)
                        {
                            tempChar = string.Empty;
                            CommandsQik.CopyResponse(sabreAnswer, ref tempChar, row, 5, 10);
                        }
                    }
                }
                if (!string.IsNullOrEmpty(tempChar))
                {
                    tempChar.Trim();
                    send = string.Concat(Resources.TicketEmission.Constants.COMMANDS_5_DOT,
                    tempChar);
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        objCommand.SendReceive(send);
                    }
                }
                //UC = "billigAddress";// 
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCBILLINGADRESS);

            }
            else
            {
                //UC = "billigAddress";// 
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCBILLINGADRESS);
            }
        }
        #endregion//End MethodsClass
    }
}
