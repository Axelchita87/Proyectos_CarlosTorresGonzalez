using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Services.Contracts;
using MyCTS.Services.ValidateDKsAndCreditCards;

namespace MyCTS.Presentation
{
    public partial class ucQCHotels : CustomUserControl
    {
        private static string locatorrecord;
        public static string LocatorRecord
        {
            get { return locatorrecord; }
            set { locatorrecord = value; }
        }

        private static string attribute1;
        public static string Attribute1
        {
            get { return attribute1; }
            set { attribute1 = value; }
        }


        private static string pccbussinesunit;
        public static string PccBussinesUnit
        {
            get { return pccbussinesunit; }
            set { pccbussinesunit = value; }
        }

        public static string dk;
        public static string DK
        {
            get { return dk; }
            set { dk = value; }
        }

        private string send = string.Empty;
        private string sabreAnswer = string.Empty;
        private bool isMessageShown = false;
        private int row = 0;
        private int col = 0;

        string result = string.Empty;
        private int CCFlag;
        private int CDFlag;
        private int SMXFlag;
        private int CEFlag;
        private int CFFlag;
        private int CGFlag;
        private int CHFlag;
        private int C30Flag;
        private int C44Flag;
        private string Sabre;
        private string sabreConcat;
        private string sabreResult;
        List<string> remarkNumber = new List<string>();

        //Remarks contables
        //CC-
        public static string C3;
        public static string C2;
        public static string C1;
        public static string C24;
        string CCLine;

        //CD-
        public static string C9;
        public static string C31;
        public static string C4;
        public static string C32;
        string CDLine;

        //CE-
        public static string C5;
        public static string C6;
        public static string C7;
        public static string C8;
        string CELine;

        //CF-
        public static string C33;
        public static string C34;
        public static string C35;
        public static string C36;
        string CFLine;

        //CG-
        public static string C37;
        public static string C38;
        public static string C39;
        public static string C40;
        string CGLine;

        //CH-
        public static string C41;
        public static string C42;
        public static string C45;
        public static string C46;
        string CHLine;

        private List<QCControlsClients> dinamicQualityControlsList;
        public static List<ListItem> ClientRemarkNumber = new List<ListItem>();
        QCCustomRemarks customRemark = new QCCustomRemarks();


        //*******
        private string UC = string.Empty;
        frmPreloading frmPreloader;
        //*******

        public static List<MyCTS.Services.ValidateDKsAndCreditCards.CatCorporativeQualityControls> CorporativeQualityControls;
        public ucQCHotels()
        {
            InitializeComponent();
        }

        private void ucQCHotels_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            #region ====FirstValidations====
            TODO();
            #endregion

            #region ====RemoveRemarks====
            ClientRemarkNumber.Clear();
            SetClientRemarks();
            ClearPreviousValues();
            if (!ConsolidValidation)
            {
                SendInitialCommand();
                //if (SearchRemarks)
                //{
                    ucMenuReservations.qualityControls = true;
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_ALL_QUALITY_CONTROLS);
                //}
            }
            #endregion
           
        }


       
        #region===== MethodsClass FirstValidations =====


        private void TODO()
        {
            dk = string.Empty;
            ucAllQualityControls.globalPaxNumber = 0;
            ucAllQualityControls.counter = 0;
            ucAllQualityControls.chargePerService.Clear();
            ucAllQualityControls.remarksIntegra.Clear();
            ucAllQualityControls.passengerPositionValues.Clear();
            ucAllQualityControls.Origin = string.Empty;
            ucAllQualityControls.BusinessUnit = string.Empty;
            ucAllQualityControls.TicketsJustifications = string.Empty;
            ucAllQualityControls.workerNumberArray.Clear();
            ucTicketEmissionBuildCommand.commandSent = false;
            ucTicketsEmissionInstructions.OSI = string.Empty;
            userControlsPreviousValues.TicketsEmissionInstructionsParameters = null;
            ucQualitiesByPax.Passengers = string.Empty;
            ucQualitiesByPax.sabreConcat = string.Empty;
            //LoginEAreaValidation();
            if (!isMessageShown)
            {
                PresentRecordValidation();
                if (!isMessageShown)
                {
                    //NotInQueueValidation();
                    if (!isMessageShown)
                    {
                        if (GetLocatorRecord())
                        {
                            PreviousEmission();
                        }

                    }
                    else
                    {
                        //UC = "welcome";
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                    }
                }
                else
                {
                    //UC = "welcome";
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
            }
            else
            {
                //UC = "welcome";
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
        }


        /// <summary>
        ///  Validación de inicio de sesion en área E para agentes con 
        /// pseudo 3L64
        /// </summary>
        private void LoginEAreaValidation()
        {

            send = string.Empty;
            sabreAnswer = string.Empty;
            row = 0;
            col = 0;
            //locatorrecord = RecordLocalizer.GetRecordLocalizer();
            //LogProductivity.PNR = locatorrecord;
            if (Login.PCC.Equals(Resources.TicketEmission.Constants.PCC_3L64))
            {
                send = Resources.TicketEmission.Constants.COMMANDS_AST_S;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    sabreAnswer = objCommand.SendReceive(send);
                }

                CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.A, ref row, ref col, 1, 1, 15, 15);
                if (row != 0 || col != 0)
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.NECESITAS_ESTAR_AREA_E_EMITIR_ETKTS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isMessageShown = true;
                    return;
                }
                CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.B, ref row, ref col, 1, 1, 15, 15);
                if (row != 0 || col != 0)
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.NECESITAS_ESTAR_AREA_E_EMITIR_ETKTS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isMessageShown = true;
                    return;
                }
            }
        }


        /// <summary>
        ///  Validación de record presente en MySabre
        /// </summary>
        private void PresentRecordValidation()
        {
            if (!ucEndReservation.isFlowHotel)
            {
                send = string.Empty;
                sabreAnswer = string.Empty;
                send = Resources.TicketEmission.Constants.COMMANDS_AST_N_AST_IA;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    sabreAnswer = objCommand.SendReceive(send);
                }
                CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.NO_ITIN, ref row, ref col, 2, 3, 1, 64);
                if (row != 0 || col != 0)
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.NO_RECORD_PRESENTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isMessageShown = true;
                    return;
                }
                CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.NO_NAMES, ref row, ref col, 2, 3, 1, 64);
                if (row != 0 || col != 0)
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.NO_NOMBRES_PRESENTES, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isMessageShown = true;
                    return;
                }
            }
        }


        /// <summary>
        /// Valida que el record presente no se encuentre dentro de alguna Queue
        /// </summary>
        private void NotInQueueValidation()
        {
            isMessageShown = false;
            send = string.Empty;
            sabreAnswer = string.Empty;
            send = Resources.TicketEmission.Constants.COMMANDS_QXI;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }

            row = 0;
            col = 0;
            CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.CANNOT, ref row, ref col);
            if (row == 0)
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.DEBES_BOLETEAR_FUERA_QUEUE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isMessageShown = true;
                return;
            }
        }


        /// <summary>
        ///  Obtención de record localizador, >DK y carga de quality controls para 
        /// Corporativo
        /// </summary>
        private bool GetLocatorRecord()
        {
            bool IsValid = true;
            send = string.Empty;
            sabreAnswer = string.Empty;
            send = Resources.TicketEmission.Constants.COMMANDS_AST_A;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }
            sabreAnswer = sabreAnswer.Replace("‡", "\n");
            string[] sabreAnswerInfo = sabreAnswer.Split(new char[] { '\n' });
            if (sabreAnswerInfo[0].Length > 6)
                locatorrecord = string.Empty;
            else
            {
                locatorrecord = string.Empty;
                CommandsQik.CopyResponse(sabreAnswer, ref locatorrecord, 1, 1, 6);
            }
            //locatorrecord = "hola";//solo para pruebas sin cerrar record
            if (string.IsNullOrEmpty(locatorrecord))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.RECORD_NO_CERRADO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //UC = "welcome";
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                IsValid = false;
            }
            //pccbussinesunit = string.Empty;
            //CommandsQik.CopyResponse(sabreAnswer, ref pccbussinesunit, 2, 1, 4);
            //send = string.Empty;
            //sabreAnswer = string.Empty;
            //send = Resources.TicketEmission.Constants.COMMANDS_AST_PDK;
            //using (CommandsAPI objCommand = new CommandsAPI())
            //{
            //    sabreAnswer = objCommand.SendReceive(send);

            //}

            //col = 0;
            //row = 0;
            //CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.CUSTOMER_NUMBER, ref row, ref col, 1, 2, 1, 64);
            //if (row != 0 || col != 0)
            //{
            //    dk = string.Empty;
            //    CommandsQik.CopyResponse(sabreAnswer, ref dk, row, 19, 6);
            //}
            ////CommandsAPI2.send_MessageToEmulator(Resources.TicketEmission.Constants.MESSAGE_LOCATION_VALIDATION);
            //CommandsAPI2.send_MessageToEmulator(Resources.TicketEmission.Constants.MESSAGE_QUALITY_CONTROL_VALIDATION);

            dk = ucEndReservation.dK;

            WsMyCTS wsServ = new WsMyCTS();
            MyCTS.Services.ValidateDKsAndCreditCards.GetAttribute1 integraAttribute = null;
            MyCTS.Services.ValidateDKsAndCreditCards.GetAttribute1 integraAttribute1 = null;
            MyCTS.Services.ValidateDKsAndCreditCards.SetQCByAttribute1 Attribute1 = null;           
            if (!string.IsNullOrEmpty(dk))
            {
                try
                {
                    try
                    {
                        integraAttribute = wsServ.GetAttribute(dk, Login.OrgId);
                    }
                    catch
                    {
                        integraAttribute = wsServ.GetAttribute(dk, Login.OrgId);
                    }
                }
                catch
                {
                    IsValid = LocationValidationBackup();
                }
            }
            if (integraAttribute != null)
            {
                if (!string.IsNullOrEmpty(integraAttribute.Attribute1.ToString()) &&
                    (integraAttribute.Attribute1.Contains(Resources.TicketEmission.Constants.MESSAGE_NO_EXISTE_LOCATION)))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.NO_LOCATION_INTEGRA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //UC = "welcome";
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                    IsValid = false;
                }
                else if (!string.IsNullOrEmpty(integraAttribute.Attribute1.ToString()) &&
                    integraAttribute.Attribute1.Contains(Resources.TicketEmission.Constants.MESSAGE_INACTIVE))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.NUM_CLIENTE_O_LOCATION_INACTIVO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //UC = "welcome";
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                    IsValid = false;
                }
                else
                {
                    Attribute1 = wsServ.SetQCGetAttribute(integraAttribute.Location, integraAttribute.Status, integraAttribute.Status_Site);
                    //Attribute1 = SetQCByAttribute1BL.GetAttribute(integraAttribute.Attribute1, integraAttribute.Status, integraAttribute.Status_Site);
                    attribute1 = Attribute1.Attribute1.ToString();
                    activeStepsCorporativeQC.CorporativeQualityControls = null;
                    activeStepsCorporativeQC.loadQualityControlsList();
                    CorporativeQualityControls = activeStepsCorporativeQC.CorporativeQualityControls;
                }

            }
            else if (integraAttribute1 != null)
            {
                if (!string.IsNullOrEmpty(integraAttribute1.Attribute1.ToString()) &&
                    (integraAttribute1.Attribute1.Contains(Resources.TicketEmission.Constants.MESSAGE_NO_EXISTE_LOCATION)))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.NO_LOCATION_INTEGRA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //UC = "welcome";
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                    IsValid = false;
                }
                else if (!string.IsNullOrEmpty(integraAttribute1.Attribute1.ToString()) &&
                    integraAttribute1.Attribute1.Contains(Resources.TicketEmission.Constants.MESSAGE_INACTIVE))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.NUM_CLIENTE_O_LOCATION_INACTIVO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //UC = "welcome";
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                    IsValid = false;
                }
                else
                {
                    attribute1 = wsServ.SetQCGetAttribute(integraAttribute1.Location, integraAttribute1.Status, integraAttribute1.Status_Site).ToString();                   
                    //Attribute1 = SetQCByAttribute1BL.GetAttribute(integraAttribute1.Attribute1, integraAttribute1.Status, integraAttribute1.Status_Site);
                    attribute1 = Attribute1.Attribute1.ToString();
                    activeStepsCorporativeQC.CorporativeQualityControls = null;
                    activeStepsCorporativeQC.loadQualityControlsList();
                    CorporativeQualityControls = activeStepsCorporativeQC.CorporativeQualityControls;
                }

            }
            else
            {
                IsValid = LocationValidationBackup();

            }
            return IsValid;
        }

        /// <summary>
        /// Valida si hubo una emision del boleto previa del record
        /// </summary>
        private void PreviousEmission()
        {
            //row = 0; col = 0;
            //send = Resources.TicketEmission.Constants.COMMANDS_AST_PAC;
            //using (CommandsAPI objCommands = new CommandsAPI())
            //{
            //    sabreAnswer = objCommands.SendReceive(send);
            //}
            //CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.ACCOUNTING_DATA, ref row, ref col);
            //if (row != 0 || col != 0)
            //{
            //    send = Resources.TicketEmission.Constants.COMMANDS_AC_AT_ALL;
            //    using (CommandsAPI objCommands = new CommandsAPI())
            //    {
            //        objCommands.SendReceive(send);
            //    }
            //}
        }


        /// <summary>
        /// Valida el location si el procediemiento de validacion principal falla
        /// </summary>
        private bool LocationValidationBackup()
        {
            bool IsValid = true;
            GetAndSetAttributeBackup AttributeBackup = GetAndSetAttributeBackupBL.GetAttribute(dk, Login.OrgId);
            if (AttributeBackup.Attribute1 != null)
            {
                attribute1 = AttributeBackup.Attribute1.ToString(); //SOLO PRUEBAS
                //attribute1 = "dhl140";
                activeStepsCorporativeQC.CorporativeQualityControls = null;
                activeStepsCorporativeQC.loadQualityControlsList();
                CorporativeQualityControls = activeStepsCorporativeQC.CorporativeQualityControls;
                if (CorporativeQualityControls.Count.Equals(0))
                {
                    if (!string.IsNullOrEmpty(AttributeBackup.Attribute1.ToString()) &&
                    (AttributeBackup.Attribute1.Contains(Resources.TicketEmission.Constants.MESSAGE_NO_EXISTE_LOCATION)))
                    {
                        MessageBox.Show(Resources.TicketEmission.Tickets.NO_LOCATION_INTEGRA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //UC = "welcome";// 
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                        IsValid = false;
                    }
                    else if (!string.IsNullOrEmpty(AttributeBackup.Attribute1.ToString()) &&
                    AttributeBackup.Attribute1.Contains(Resources.TicketEmission.Constants.MESSAGE_INACTIVE))
                    {
                        MessageBox.Show(Resources.TicketEmission.Tickets.NUM_CLIENTE_O_LOCATION_INACTIVO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //UC = "welcome";// 
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                        IsValid = false;
                    }
                }
            }
            else
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.ERROR_VALIDACION_LOCATION, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //UC = "welcome";// 
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                IsValid = false;
            }
            return IsValid;

        }
        #endregion//End MethodsClass

        #region ===== MethodsClass RemoveRemarks=====


        /// <summary>
        /// Limpia los valores de las variables estaticas al iniciar la rutina
        /// </summary>
        private void ClearPreviousValues()
        {
            //CC-
            C3 = string.Empty;
            C2 = string.Empty;
            C1 = string.Empty;
            C24 = string.Empty;
            CCLine = string.Empty;
            CCFlag = 0;

            //CD-
            C9 = string.Empty;
            C31 = string.Empty;
            C4 = string.Empty;
            C32 = string.Empty;
            CDLine = string.Empty;
            CDFlag = 0;

            //CE-
            C5 = string.Empty;
            C6 = string.Empty;
            C7 = string.Empty;
            C8 = string.Empty;
            CELine = string.Empty;
            CEFlag = 0;

            //CF-
            C33 = string.Empty;
            C34 = string.Empty;
            C35 = string.Empty;
            C36 = string.Empty;
            CFLine = string.Empty;
            CFFlag = 0;

            //CG-
            C37 = string.Empty;
            C38 = string.Empty;
            C39 = string.Empty;
            C40 = string.Empty;
            CGLine = string.Empty;
            CGFlag = 0;

            //CH-

            C41 = string.Empty;
            C42 = string.Empty;
            C45 = string.Empty;
            C46 = string.Empty;
            CHLine = string.Empty;
            CHFlag = 0;


        }


        /// <summary>
        /// Verifica si el corporativo No es CONSOLID
        /// </summary>
        /// <returns></returns>
        private bool ConsolidValidation
        {
            get
            {
                bool consolidValidation = false;
                string ActiveRemoveRemarks = string.Empty;
                activeStepsCorporativeQC.loadQualityControlsHotelsList(attribute1);
                ActiveRemoveRemarks = activeStepsCorporativeQC.CorporativeQualityControls[0].DeleteAccountingRemarks;
                if (ActiveRemoveRemarks.Equals(Resources.TicketEmission.Constants.ACTIVE))
                    consolidValidation = false;
                else
                    consolidValidation = true;

                return consolidValidation;
            }

        }


        /// <summary>
        /// Manda el comando para desplegar los remarks contables en MySabre
        /// </summary>
        private void SendInitialCommand()
        {
            send = string.Empty;
            sabreResult = string.Empty;
            send = Resources.TicketEmission.Constants.COMMANDS_AST_P5;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreResult = objCommand.SendReceive(send);
            }

        }


        /// <summary>
        /// Valida que exista la leyenda remarks dentro de la respuesta de MySabre para continuar con el 
        /// flujo
        /// </summary>
        /// <returns></returns>
        private bool SearchRemarks
        {
            get
            {
                bool exixtingRemarks = false;
                row = 0;
                col = 0;
                CommandsQik.searchResponse(sabreResult, Resources.TicketEmission.ValitationLabels.REMARKS, ref row, ref col);
                if (row > 0)
                {
                    exixtingRemarks = true;
                    sabreConcat = string.Concat(sabreResult,
                        "?");
                }
                else
                {
                    exixtingRemarks = false;
                }
                return exixtingRemarks;
            }
        }


        /// <summary>
        /// reinicializa el proceso de buscar remarks contables
        /// </summary>
        private void BucleFindEndScroll()
        {
            SendScrollCommand();
            if (!SearchEndScroll())
            {
                BucleFindEndScroll();
            }

        }


        /// <summary>
        /// crea la rutina para eliminar los remarks contables de las diferentes respuestas
        /// de Mysabre
        /// </summary>
        private void DeleteRemarks()
        {
            string[] sabreAnswerCollection = sabreConcat.Split(new char[] { '?' });
            for (int i = 0; i < sabreAnswerCollection.Length; i++)
            {
                if (!string.IsNullOrEmpty(sabreAnswerCollection[i]))
                {
                    sabreAnswer = string.Empty;
                    sabreAnswer = sabreAnswerCollection[i];
                    RemoveRemarks();
                }
            }
            SendDeleteRemarkCommand();

        }


        /// <summary>
        /// Manda el comando para verificar si el record contiene mas remarks contables
        /// </summary>
        private void SendScrollCommand()
        {
            send = string.Empty;
            sabreResult = string.Empty;
            send = Resources.TicketEmission.Constants.COMMANDS_MD;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreResult = objCommand.SendReceive(send);
            }
        }


        /// <summary>
        /// Valida el fin del despliegue de remarks contables en MySabre
        /// </summary>
        /// <returns></returns>
        private bool SearchEndScroll()
        {
            bool endScroll = false;
            row = 0;
            col = 0;
            CommandsQik.searchResponse(sabreResult, "SCROLL‡", ref row, ref col);
            if (row != 0 && col >= 0)
            {
                endScroll = true;
            }
            else
            {
                sabreConcat = string.Concat(sabreConcat,
                    Resources.TicketEmission.ValitationLabels.REMARKS,
                    "\n",
                    sabreResult,
                    "?");
                endScroll = false;
            }
            return endScroll;
        }


        /// <summary>
        /// Elimina los remarks contables dentro del record menos .S*MX
        /// </summary>
        private void RemoveRemarks()
        {
            string line = string.Empty;
            row = 0;
            col = 0;
            sabreAnswer = sabreAnswer.Replace(" ‡ ", " \n ");
            string[] sabreAnswerInfo = sabreAnswer.Split(new char[] { '\n' });

            List<string> temp = new List<string>();
            for (int i = 1; i < sabreAnswerInfo.Length; i++)
            {
                int lastItem = i + 1;
                if (!lastItem.Equals(sabreAnswerInfo.Length))
                {
                    if (!string.IsNullOrEmpty(sabreAnswerInfo[i]) && !sabreAnswerInfo[i].StartsWith("    ") && sabreAnswerInfo[i + 1].StartsWith("    "))
                    {
                        if (sabreAnswerInfo[lastItem].StartsWith("    "))
                        {
                            string clearSpaces = sabreAnswerInfo[lastItem].TrimStart(new char[] { ' ' });
                            string fullRemark = string.Concat(sabreAnswerInfo[i],
                                clearSpaces);
                            temp.Add(fullRemark);
                        }

                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(sabreAnswerInfo[i]) && !sabreAnswerInfo[i].StartsWith("    "))
                            temp.Add(sabreAnswerInfo[i]);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(sabreAnswerInfo[i]) && !sabreAnswerInfo[i].StartsWith("    "))
                        temp.Add(sabreAnswerInfo[i]);
                }
            }

            foreach (string lines in temp)//Inicio linea1
            {

                CommandsQik.searchResponse(lines, ".</C30", ref row, ref col, 1, 1, 1, 20);
                if (row > 0)
                {
                    //Encontro valor
                    C30Flag = 1;
                    row = 0;
                    col = 0;
                }

                CommandsQik.searchResponse(lines, ".</C44", ref row, ref col, 1, 1, 1, 20);
                if (row > 0)
                {
                    //Encontro valor
                    C44Flag = 1;
                    row = 0;
                    col = 0;
                }

                CommandsQik.searchResponse(lines, ".S*MX", ref row, ref col, 1, 1, 1, 20);
                if (row > 0)
                {
                    //Encontro valor
                    SMXFlag = 1;
                    row = 0;
                    col = 0;
                }

                CommandsQik.searchResponse(lines, ".CC-", ref row, ref col, 1, 1, 1, 20);
                if (row > 0)
                {
                    //Encontro valor
                    //Asignacion de valores CC-
                    CCLine = string.Empty;
                    CommandsQik.CopyResponse(lines, ref CCLine, 1, 1, lines.Length);
                    CCLine = CCLine.Trim();

                    char[] sep = { '-' };
                    string[] arr = CCLine.Split(sep);

                    //C3 = arr[1];
                    //C2 = arr[2];
                    //C1 = arr[3];
                    //C24 = arr[4];
                    CCLine = string.Empty;
                    //Fin asignacion de valores CC-

                    CCFlag = 1;
                    row = 0;
                    col = 0;
                }


                CommandsQik.searchResponse(lines, ".CD-", ref row, ref col, 1, 1, 1, 20);
                if (row > 0)
                {
                    //Encontro valor

                    //Asignacion de valores CD-
                    CDLine = string.Empty;
                    CommandsQik.CopyResponse(lines, ref CDLine, 1, 1, lines.Length);
                    CDLine = CDLine.Trim();

                    char[] sep1 = { '-' };
                    string[] arr1 = CDLine.Split(sep1);

                    //C9 = arr1[1];
                    //C31 = arr1[2];
                    //C4 = arr1[3];
                    //C32 = arr1[4];
                    CDLine = string.Empty;
                    //Fin asignacion de valores CD-

                    CDFlag = 1;
                    row = 0;
                    col = 0;
                }

                CommandsQik.searchResponse(lines, ".CE-", ref row, ref col, 1, 1, 1, lines.Length);
                if (row > 0)
                {
                    //Encontro valor

                    //Asignacion de valores CE-
                    CELine = string.Empty;
                    CommandsQik.CopyResponse(lines, ref CELine, 1, 1, lines.Length);
                    CELine = CELine.Trim();

                    char[] sep2 = { '-' };
                    string[] arr2 = CELine.Split(sep2);

                    //C5 = arr2[1];
                    //C6 = arr2[2];
                    //C7 = arr2[3];
                    //C8 = arr2[4];
                    CELine = string.Empty;
                    //Fin asignacion de valores CD-

                    CEFlag = 1;
                    row = 0;
                    col = 0;
                }

                CommandsQik.searchResponse(lines, ".CF-", ref row, ref col, 1, 1, 1, 20);
                if (row > 0)
                {
                    //Encontro valor

                    //Asignacion de valores CF-
                    CFLine = string.Empty;
                    CommandsQik.CopyResponse(lines, ref CFLine, 1, 1, lines.Length);
                    CFLine = CFLine.Trim();

                    char[] sep3 = { '-' };
                    string[] arr3 = CFLine.Split(sep3);

                    //C33 = arr3[1];
                    //C34 = arr3[2];
                    //C35 = arr3[3];
                    //C36 = arr3[4];
                    CFLine = string.Empty;
                    //Fin asignacion de valores CF-

                    CFFlag = 1;
                    row = 0;
                    col = 0;
                }

                CommandsQik.searchResponse(lines, ".CG-", ref row, ref col, 1, 1, 1, 20);
                if (row > 0)
                {
                    //Encontro valor

                    //Asignacion de valores CG-
                    CGLine = string.Empty;
                    CommandsQik.CopyResponse(lines, ref CGLine, 1, 1, lines.Length);
                    CGLine = CGLine.Trim();

                    char[] sep4 = { '-' };
                    string[] arr4 = CGLine.Split(sep4);

                    //C37 = arr4[1];
                    //C38 = arr4[2];
                    //C39 = arr4[3];
                    //C40 = arr4[4];
                    CGLine = string.Empty;
                    //Fin asignacion de valores CG-

                    CGFlag = 1;
                    row = 0;
                    col = 0;
                }

                CommandsQik.searchResponse(lines, ".CH-", ref row, ref col, 1, 1, 1, 20);
                if (row > 0)
                {
                    //Encontro valor

                    //Asignacion de valores CH-
                    CHLine = string.Empty;
                    CommandsQik.CopyResponse(lines, ref CHLine, 1, 1, lines.Length);
                    CHLine = CHLine.Trim();

                    char[] sep5 = { '-' };
                    string[] arr5 = CHLine.Split(sep5);

                    //C41 = arr5[1];
                    //C42 = arr5[2];
                    //C45 = arr5[3];
                    //C46 = arr5[4];
                    CHLine = string.Empty;
                    //Fin asignacion de valores CH-

                    CHFlag = 1;
                    row = 0;
                    col = 0;
                }

                RecoverRemarksValues(lines);

                if (C30Flag == 0 && C44Flag == 0 && SMXFlag == 0 && CCFlag == 1 && CDFlag == 0 && CEFlag == 0 && CFFlag == 0 && CGFlag == 0 && CHFlag == 0)
                {
                    line = string.Empty;
                    CommandsQik.CopyResponse(lines, ref line, 1, 1, 3);
                    line = line.Trim();
                    remarkNumber.Add(line);
                    row = 0;
                    col = 0;
                }
                else if (C30Flag == 0 && C44Flag == 0 && SMXFlag == 0 && CCFlag == 0 && CDFlag == 1 && CEFlag == 0 && CFFlag == 0 && CGFlag == 0 && CHFlag == 0)
                {
                    line = string.Empty;
                    CommandsQik.CopyResponse(lines, ref line, 1, 1, 3);
                    line = line.Trim();
                    remarkNumber.Add(line);
                    row = 0;
                    col = 0;
                }
                else if (C30Flag == 0 && C44Flag == 0 && SMXFlag == 0 && CCFlag == 0 && CDFlag == 0 && CEFlag == 1 && CFFlag == 0 && CGFlag == 0 && CHFlag == 0)
                {
                    line = string.Empty;
                    CommandsQik.CopyResponse(lines, ref line, 1, 1, 3);
                    line = line.Trim();
                    remarkNumber.Add(line);
                    row = 0;
                    col = 0;
                }
                else if (C30Flag == 0 && C44Flag == 0 && SMXFlag == 0 && CCFlag == 0 && CDFlag == 0 && CEFlag == 0 && CFFlag == 1 && CGFlag == 0 && CHFlag == 0)
                {
                    line = string.Empty;
                    CommandsQik.CopyResponse(lines, ref line, 1, 1, 3);
                    line = line.Trim();
                    remarkNumber.Add(line);
                    row = 0;
                    col = 0;
                }

                else if (C30Flag == 0 && C44Flag == 0 && SMXFlag == 0 && CCFlag == 0 && CDFlag == 0 && CEFlag == 0 && CFFlag == 0 && CGFlag == 1 && CHFlag == 0)
                {
                    line = string.Empty;
                    CommandsQik.CopyResponse(lines, ref line, 1, 1, 3);
                    line = line.Trim();
                    remarkNumber.Add(line);
                    row = 0;
                    col = 0;
                }

                else if (C30Flag == 0 && C44Flag == 0 && SMXFlag == 0 && CCFlag == 0 && CDFlag == 0 && CEFlag == 0 && CFFlag == 0 && CGFlag == 0 && CHFlag == 1)
                {
                    line = string.Empty;
                    CommandsQik.CopyResponse(lines, ref line, 1, 1, 3);
                    line = line.Trim();
                    remarkNumber.Add(line);
                    row = 0;
                    col = 0;
                }
                else if (C30Flag == 0 && C44Flag == 0 && SMXFlag == 0 && CCFlag == 0 && CDFlag == 0 && CEFlag == 0 && CFFlag == 0 && CGFlag == 0 && CHFlag == 0)
                {

                    CommandsQik.searchResponse(lines, "..", ref row, ref col, 1, 1, 1, 6);
                    if (row > 0)
                    {
                        row = 0;
                        col = 0;
                        line = string.Empty;
                        CommandsQik.CopyResponse(lines, ref line, 1, 1, 3);
                        line = line.Trim();
                        remarkNumber.Add(line);
                        row = 0;
                        col = 0;
                    }
                }
                C30Flag = 0;
                C44Flag = 0;
                SMXFlag = 0;
                CCFlag = 0;
                CDFlag = 0;
                CEFlag = 0;
                CFFlag = 0;
                CGFlag = 0;
                CHFlag = 0;
                CDFlag = 0;

            }
        }


        /// <summary>
        /// Envia el comando de eliminación de remarks
        /// </summary>
        private void SendDeleteRemarkCommand()
        {
            if (!remarkNumber.Count.Equals(0))
            {
                List<int> TempNumber = new List<int>();
                foreach (string number in remarkNumber)
                {
                    try
                    {
                        TempNumber.Add(Convert.ToInt32(number));
                    }
                    catch { }
                }
                TempNumber.Sort();
                TempNumber.Reverse();
                foreach (int number in TempNumber)
                {
                    Sabre = Sabre + "5" + number.ToString().Trim() + "@Σ";
                }
            }

            if (!string.IsNullOrEmpty(Sabre))
            {
                send = string.Empty;
                Sabre = Sabre.TrimEnd(new char[] { 'Σ' });
                send = Sabre;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    sabreAnswer = objCommand.SendReceive(send);
                }

            }

        }

        private void RecoverRemarksValues(string line)
        {
            foreach (ListItem remarkNum in ClientRemarkNumber)
            {
                if (customRemark.RmrkType != null)
                {
                    string value = string.Empty;
                    string temp = (!string.IsNullOrEmpty(customRemark.RmrkPaxIdentyfier)) ? customRemark.RmrkPaxIdentyfier : customRemark.RmrkValueIdentyfier;
                    string remark = string.Concat(".",
                        customRemark.RmrkInitialLabel,
                        customRemark.RmrkIdentyfier,
                        remarkNum.Value,
                        temp);

                    int row = 0;
                    int col = 0;
                    CommandsQik.searchResponse(line, remark, ref row, ref col, 1, 1, 1, 20);
                    if (row > 0)
                    {
                        CommandsQik.CopyResponse(line, ref value, 1, 1, line.Length);
                        string remarkValue = string.Empty;

                        if (!string.IsNullOrEmpty(customRemark.RmrkValueIdentyfier))
                        {
                            remark = value.Replace(customRemark.RmrkValueIdentyfier, "|");
                            string[] values = remark.Split(new char[] { '|' });
                            if (values.Length > 2)
                            {
                                for (int i = 1; i < values.Length; i++)
                                {
                                    remarkNum.Text3 = string.Concat(remarkNum.Text3,
                                        values[i]);
                                }
                            }
                            else if (values.Length == 2)
                            {
                                remarkNum.Text3 = values[1];
                            }
                        }
                    }
                }
            }
        }

        private void SetClientRemarks()
        {
            dinamicQualityControlsList = QCControlsClientsBL.GetQCControls(Attribute1, Login.Firm, Login.PCC, Login.Agent);
            if (dinamicQualityControlsList.Count > 0)
            {
                if (!string.IsNullOrEmpty(dinamicQualityControlsList[28].CtrlDescription) &&
                  dinamicQualityControlsList[28].CtrlDescription != Login.Mail)
                    dinamicQualityControlsList[28].CtrlDescription = Login.Mail;

                foreach (QCControlsClients qualityControls in dinamicQualityControlsList)
                {
                    string[] QCValue = qualityControls.ActiveQCClient.Split(new char[] { '|' });
                    int index = 0;
                    if (QCValue.Length > 1)
                        index = 1;
                    if (!QCValue[index].Equals(Resources.TicketEmission.Constants.INACTIVE))
                    {
                        ListItem item = new ListItem();
                        item.Value = QCValue[0];
                        item.Text = qualityControls.CtrlName;
                        item.Text2 = qualityControls.ReservationCtrlType;
                        ClientRemarkNumber.Add(item);
                    }
                }
            }
            customRemark = QCCustomRemarksBL.GetQCustomRemarks(Attribute1);
        }

        private void QCRadius()
        {
            bool status = false;
            int row = 0;
            int col = 0;
            string QCAuthorized = CorporativeQualityControls[0].QCAuthorized;

            if (QCAuthorized.Equals(Resources.TicketEmission.Constants.ACTIVE))
            {
                string sLabelQC = CorporativeQualityControls[0].LabelQC;
                string send = string.Empty;


                send = Resources.TicketEmission.Constants.COMMANDS_AST_Q_CROSSLORRAINE;
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
                CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.RADIUS_QC_PASSED, ref row, ref col);
                if (row != 0 || col != 0)
                {
                    status = true;
                    row = 0;
                    col = 0;
                }
                if (!status)
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.NO_EXISTE_AUTORIZACION_CLIENTE_PARA_EMISION, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //UC = "welcome";// 
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
                else
                    //UC = "ratingActualFAre";// 
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_RATING_ACTUAL_FARE);
            }
            else
            {
                //UC = "ratingActualFAre";// 
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_RATING_ACTUAL_FARE);
            }
        }
        #endregion //End MethodsClass

    }
}
