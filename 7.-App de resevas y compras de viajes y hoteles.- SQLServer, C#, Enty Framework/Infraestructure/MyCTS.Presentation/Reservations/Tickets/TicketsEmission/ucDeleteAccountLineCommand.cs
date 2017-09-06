using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucDeleteAccountLineCommand : CustomUserControl, IProcessAsync
    {
        /// <summary>
        /// Descripcion: Permite borrar las líneas contables,pertenece a Emitir Boleto
        /// Creación:    5/Junio/09 , Modificación:*
        /// Cambio:      * , Solicito*
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        #region ====== Declaration of Variable =======

        private static string answer;
        public static string Answer
        {
            get { return answer; }
            set { answer = value; }
        }

        private static bool status;
        public static bool Status
        {
            get { return status; }
            set { status = value; }
        }

        string result = string.Empty;
        int row = 0;
        int col = 0;

        #endregion
        //**********
        private string UC = string.Empty;
        frmPreloading frmPreloader;
        //*********
        public ucDeleteAccountLineCommand()
        {
            InitializeComponent();
        }

        //User Control Load
        /// <summary>
        /// Se extrae de la Base de Datos si esta activo el borrar lineas contables
        /// Si es asi se hace el armado de comando 
        /// si no se va al siguiente User Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucDeleteAccountLineCommand_Load(object sender, EventArgs e)
        {
            //frmPreloader = new frmPreloading(this);
            //frmPreloader.Show();
            ucAvailability.IsInterJetProcess = false;
            TODO();
        }

        private void TODO()
        {
            string deleteaccountinglines = activeStepsCorporativeQC.CorporativeQualityControls[0].DeleteAccountingLines;
            if (deleteaccountinglines == Resources.TicketEmission.Constants.ACTIVE)
                Validation_deleteaccountline();
            else
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_REMOVEREMARKS);
                //UC = "removeRemarks";
        }

        void IProcessAsync.InitProcess()
        {
            TODO();
        }

        void IProcessAsync.EndProcess()
        {
            if (UC.Equals("removeRemarks"))
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_REMOVEREMARKS);
            else if (UC.Equals("deleteAccountLine"))
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_DELETEACCOUNTLINE);
        }
        #region===== MethodsClass =====

        /// <summary>
        /// Se manda un commando en el cual se busca si existe linea contable
        /// si es asi te manda al user Control que te permite borrar
        /// la linea contable, si no te manda al siguiente User Control
        /// </summary>
        private void Validation_deleteaccountline()
        {
            Answer = result;
            status = false;
            string send = string.Empty;
            send = Resources.TicketEmission.Constants.COMMANDS_AST_PAC;
            using (CommandsAPI objCommands = new CommandsAPI())
            {
                result = objCommands.SendReceive(send);
            }
            CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.ACCOUNTING_DATA, ref row, ref col);
            if (row != 0 || col != 0)
            {
                Status = true;
                row = 0;
                col = 0;
            }
            if (Status)
                //UC = "deleteAccountLine";
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_DELETEACCOUNTLINE);
            else
                //UC = "removeRemarks";
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_REMOVEREMARKS);
        }

        #endregion
    }
}
