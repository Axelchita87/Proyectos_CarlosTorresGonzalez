using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using MyCTS.Business;
using MyCTS.Services;
using MyCTS.Services.Contracts;
using System.ComponentModel;
using MyCTS.Services.ValidateDKsAndCreditCards;
using MyCTS.Services.TravelItineraryProduction;
using MyCTS.Services.Contracts.Volaris;
using System.Collections;
using System.Text.RegularExpressions;
namespace MyCTS.Presentation
{
    public partial class ucFirstValidations : CustomUserControl, IProcessAsync
    {

        /// <summary>
        /// Descripción: User Control que valida la prescencia de un record cerrado con itinerario,
        ///              obtiene el record localizador y establece los quality controls aplicables a cada 
        ///              corporativo Pertenece al flujo de emisión de boleto de la aplicación.
        /// Creación:    Mayo - Junio 09, Modificación: 11 dicimebre 09
        /// Cambio:      Anexo validacion de boleto emitido el mismo dia  Solicito: Guillermo Granados
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
         
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

        public static string nameProfile;
        public static string NameProfile
        {
            get { return nameProfile; }
            set { nameProfile = value; }
        }

        public static string pcc;
        public static string PCC
        {
            get { return pcc; }
            set { pcc = value; }
        }

        public static string Warning;
        public static string Warnings
        {
            get { return Warning; }
            set { Warning = value; }
        }

        public static List<NewPassengerProfile> newProfile;
        public static List<string> CreditCardsFirstLevel;
        public static List<string> CreditCardsSecondLevel;

        private string send = string.Empty;
        private string sabreAnswer = string.Empty;
        private bool isMessageShown = false;
        private int row = 0;
        private int col = 0;

        //*******
        private string UC = string.Empty;
        frmPreloading frmPreloader;
        //*******
        public static List<MyCTS.Services.ValidateDKsAndCreditCards.CatCorporativeQualityControls> CorporativeQualityControls;

        public ucFirstValidations()
        {
            InitializeComponent();
        }

        //user control load
        private void ucFirstValidations_Load(object sender, EventArgs e)
        {
            //frmPreloader = new frmPreloading(this);
            //frmPreloader.Show();
            ucAvailability.IsInterJetProcess = false;
            TODO();
        }

        void IProcessAsync.InitProcess()
        {
            TODO();
        }

        void IProcessAsync.EndProcess()
        {
            if (UC.Equals("welcome"))
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            else if (UC.Equals("deleteAccountLineCommand"))
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_DELETE_ACCOUNT_LINE_COMMAND);
        }

        private void TODO()
        {
            dk = string.Empty;
            if (CreditCardsFirstLevel != null)
                CreditCardsFirstLevel.Clear();
            if (CreditCardsSecondLevel != null)
                CreditCardsSecondLevel.Clear();
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
            ucTicketsEmissionInstructions.xrCommand = false;
            userControlsPreviousValues.TicketsEmissionInstructionsParameters = null;
            ucQualitiesByPax.Passengers = string.Empty;
            ucQualitiesByPax.sabreConcat = string.Empty;
            //LoginEAreaValidation();
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive("IR");
            }

            PccValidation();
            GetPCC();
            getEmailsItinerary();
            if (!isMessageShown)
            {
                PresentRecordValidation();
                if (!isMessageShown)
                {
                    NotInQueueValidation();
                    if (!isMessageShown)
                    {
                        if (GetLocatorRecord())
                        {
                            ExecBackGround();
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

        private void ExecBackGround()
        {
            GetCreditCards();
        }


        #region===== MethodsClass =====

        /// <summary>
        /// Obtiene el PCC en el que se trabaja
        /// </summary>
        public void GetPCC()
        {
            send = string.Empty;
            sabreAnswer = string.Empty;
            row = 0;
            col = 0;
            //locatorrecord = RecordLocalizer.GetRecordLocalizer();
            //LogProductivity.PNR = locatorrecord;
            send = Resources.TicketEmission.Constants.COMMANDS_AST_S;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }

            CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.PCC_0AUC, ref row, ref col);
            if (row > 0 || col > 0)
            {
                PCC = Resources.TicketEmission.ValitationLabels.PCC_0AUC;
            }
            else
                PCC = string.Empty;
        }

        /// <summary>
        ///  Validación del pcc
        /// </summary>
        private void PccValidation()
        {
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                CommandsAPI2.send_MessageToEmulator(Resources.TicketEmission.Constants.PLEASE_WAIT);
                objCommand.SendReceive(Resources.Constants.COMMANDS_PPO, 0, 0);
                string res = objCommand.SendReceive("*S", 0, 0);
                if (res.Substring(0, 4).Equals("3L64"))
                {
                    objCommand.SendReceive(Resources.Constants.COMMANDS_PPS5, 0, 0);
                }
                else
                {
                    objCommand.SendReceive(Resources.Constants.COMMANDS_PPS1, 0, 0);
                }
            }
        }

        /// <summary>
        ///  Validación de inicio de sesion en área E para agentes con 
        /// pseudo 3L64
        /// </summary>
        private void LoginEAreaValidation()
        {
            //send = string.Empty;
            //sabreAnswer = string.Empty;
            //row = 0;
            //col = 0;
            ////locatorrecord = RecordLocalizer.GetRecordLocalizer();
            ////LogProductivity.PNR = locatorrecord;
            //if (Login.PCC.Equals(Resources.TicketEmission.Constants.PCC_3L64))
            //{
            //    send = Resources.TicketEmission.Constants.COMMANDS_AST_S;
            //    using (CommandsAPI objCommand = new CommandsAPI())
            //    {
            //        sabreAnswer = objCommand.SendReceive(send);
            //    }

            //    CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.A, ref row, ref col, 1, 1, 15, 15);
            //    if (row != 0 || col != 0)
            //    {
            //        MessageBox.Show(Resources.TicketEmission.Tickets.NECESITAS_ESTAR_AREA_E_EMITIR_ETKTS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        isMessageShown = true;
            //        return;
            //    }
            //    CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.B, ref row, ref col, 1, 1, 15, 15);
            //    if (row != 0 || col != 0)
            //    {
            //        MessageBox.Show(Resources.TicketEmission.Tickets.NECESITAS_ESTAR_AREA_E_EMITIR_ETKTS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        isMessageShown = true;
            //        return;
            //    }
            //}
        }

        private void NoItin(out bool shouldReturn)
        {
            shouldReturn = false;
            CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.NO_ITIN, ref row, ref col, 2, 3, 1, 64);
            if (row != 0 || col != 0)
            {

                MessageBox.Show(Resources.TicketEmission.Tickets.NO_RECORD_PRESENTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isMessageShown = true;
                shouldReturn = true;
            }
        }
        private void NoNames(out bool shouldReturn)
        {
            shouldReturn = false;
            CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.NO_NAMES, ref row, ref col, 2, 3, 1, 64);
            if (row != 0 || col != 0)
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.NO_NOMBRES_PRESENTES, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isMessageShown = true;
                shouldReturn = true;
            }
        }



        /// <summary>
        ///  Validación de record presente en MySabre
        /// </summary>
        private void PresentRecordValidation()
        {
            row = 0;
            col = 0;
            send = string.Empty;
            sabreAnswer = string.Empty;
            send = Resources.TicketEmission.Constants.COMMANDS_AST_N_AST_IA;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }

            bool shouldReturn = true;

            NoItin(out shouldReturn);
            if (shouldReturn)
                return;

            NoNames(out shouldReturn);
            if (shouldReturn)
                return;
            // metodo

            CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.WARNING, ref row, ref col, 2, 3, 1, 64);
            if (row != 0 || col != 0)
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.WARNING___PNR_MODIFICATION_IN_PROGRESS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //UC = "welcome";
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                return;

            }

            if (row == 0 && col == 0)
            {
                if (!sabreAnswer.Contains("2.1"))
                {
                    string[] parts = sabreAnswer.Split('\n');
                    if (parts[0].Contains("*"))
                    {
                        nameProfile = sabreAnswer.Substring(0, sabreAnswer.IndexOf("*"));
                        nameProfile = nameProfile.Replace("1.1", "");
                        nameProfile = nameProfile.TrimStart();
                        nameProfile = nameProfile.TrimEnd();
                    }
                    else
                    {
                        nameProfile = parts[0].Replace("1.1", "");
                        nameProfile = nameProfile.TrimStart();
                        nameProfile = nameProfile.TrimEnd();
                    }
                }
                else
                {
                    nameProfile = sabreAnswer.Substring(0, sabreAnswer.IndexOf("2.1"));
                    nameProfile = nameProfile.Replace("1.1", "");
                    nameProfile = nameProfile.TrimStart();
                    nameProfile = nameProfile.TrimEnd();
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
            sabreAnswer = sabreAnswer.Replace("", "\n");
            string[] sabreAnswerInfo = sabreAnswer.Split(new char[] { '\n' });
            if (sabreAnswerInfo[0].Length > 6)
                locatorrecord = string.Empty;
            else
            {
                locatorrecord = string.Empty;
                CommandsQik.CopyResponse(sabreAnswer, ref locatorrecord, 1, 1, 6);
            }
            send = Resources.TicketEmission.Constants.AST + locatorrecord;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }

            CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.WARNING, ref row, ref col, 2, 3, 1, 64);
            string[] sabreAnswerWar = sabreAnswer.Split('\n');
            if (sabreAnswerWar[0] == Resources.TicketEmission.ValitationLabels.WARNING)
            {

                MessageBox.Show(Resources.TicketEmission.Tickets.WARNING___PNR_MODIFICATION_IN_PROGRESS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //UC = "welcome";
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                IsValid = false;

            }

            else if (sabreAnswerWar[0] == Resources.TicketEmission.ValitationLabels.PNR_IGNORED_AND_REDISPLAYED)
            {

                MessageBox.Show(Resources.TicketEmission.Tickets.WARNING___PNR_MODIFICATION_IN_PROGRESS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //UC = "welcome";
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                IsValid = false;
            }
            else if (sabreAnswerWar[0] == Resources.TicketEmission.ValitationLabels.SIMULTANEOUS_CHANGES)
            {

                MessageBox.Show(Resources.TicketEmission.Tickets.WARNING___PNR_MODIFICATION_IN_PROGRESS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //UC = "welcome";
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                IsValid = false;
            }

            else
            {
                //locatorrecord = "hola";//solo para pruebas sin cerrar record
                if (string.IsNullOrEmpty(locatorrecord))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.RECORD_NO_CERRADO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //UC = "welcome";
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                    IsValid = false;
                }

                send = string.Empty;
                sabreAnswer = string.Empty;
                send = Resources.TicketEmission.Constants.COMMANDS_AST_PDK;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    sabreAnswer = objCommand.SendReceive(send);
                }

                col = 0;
                row = 0;
                CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.CUSTOMER_NUMBER, ref row, ref col, 1, 2, 1, 64);
                if (row != 0 || col != 0)
                {
                    dk = string.Empty;
                    CommandsQik.CopyResponse(sabreAnswer, ref dk, row, 19, 6);
                }
                CommandsAPI2.send_MessageToEmulator(Resources.TicketEmission.Constants.MESSAGE_QUALITY_CONTROL_VALIDATION);

                WsMyCTS wsServ = new WsMyCTS();
                MyCTS.Services.ValidateDKsAndCreditCards.GetAttribute1 integraAttribute = null;
                MyCTS.Services.ValidateDKsAndCreditCards.GetAttribute1 integraAttribute1 = null;

                MyCTS.Entities.SetQCByAttribute1 Attribute1 = null;
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
                         (integraAttribute.Attribute1.Contains("NO EXISTE LOCATION")))
                    {
                        MessageBox.Show(Resources.TicketEmission.Tickets.NO_LOCATION_INTEGRA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //UC = "welcome";
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                        IsValid = false;
                    }
                    else if (!string.IsNullOrEmpty(integraAttribute.Attribute1.ToString()) &&
                         integraAttribute.Attribute1.Contains("INACTIVO"))
                    {
                        MessageBox.Show(Resources.TicketEmission.Tickets.NUM_CLIENTE_O_LOCATION_INACTIVO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //UC = "welcome";
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                        IsValid = false;
                    }
                    else
                    {
                        Attribute1 = SetQCByAttribute1BL.GetAttribute(integraAttribute.Attribute1, integraAttribute.Status, integraAttribute.Status_Site);
                        attribute1 = Attribute1.Attribute1.ToString();
                        activeStepsCorporativeQC.CorporativeQualityControls = null;
                        activeStepsCorporativeQC.loadQualityControlsList();
                        CorporativeQualityControls = activeStepsCorporativeQC.CorporativeQualityControls;
                    }

                }
                else if (integraAttribute1 != null)
                {
                    if (!string.IsNullOrEmpty(integraAttribute1.Attribute1.ToString()) &&
                         (integraAttribute.Attribute1.Contains("NO EXISTE LOCATION")))
                    {
                        MessageBox.Show(Resources.TicketEmission.Tickets.NO_LOCATION_INTEGRA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //UC = "welcome";
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                        IsValid = false;
                    }
                    else if (!string.IsNullOrEmpty(integraAttribute1.Attribute1.ToString()) &&
                         integraAttribute.Attribute1.Contains("INACTIVO"))
                    {
                        MessageBox.Show(Resources.TicketEmission.Tickets.NUM_CLIENTE_O_LOCATION_INACTIVO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //UC = "welcome";
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                        IsValid = false;
                    }
                    else
                    {
                        Attribute1 = SetQCByAttribute1BL.GetAttribute(integraAttribute1.Attribute1, integraAttribute1.Status, integraAttribute1.Status_Site);
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
            }
            return IsValid;
        }

        /// <summary>
        /// Valida si hubo una emision del boleto previa del record
        /// </summary>
        private void PreviousEmission()
        {
            if (CorporativeQualityControls[0].verifyTicketEmission.Equals(Resources.TicketEmission.Constants.ACTIVE))
            {
                string dateToday = string.Empty;
                string dateTicketEmission = string.Empty;
                dateToday = DateTime.Today.ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
                send = string.Empty;
                sabreAnswer = string.Empty;
                send = Resources.TicketEmission.Constants.COMMANDS_AST_T;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    sabreAnswer = objCommand.SendReceive(send);
                }

                col = 0;
                row = 0;
                CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.T_INDENT, ref row, ref col, 2, 2, 1, 6);
                if (row > 0)
                {
                    CommandsQik.CopyResponse(sabreAnswer, ref dateTicketEmission, row, 7, 5);

                    if (!string.IsNullOrEmpty(dateTicketEmission))
                    {
                        if (dateTicketEmission.Equals(dateToday))
                        {
                            DialogResult YesNo = MessageBox.Show(Resources.TicketEmission.Tickets.EMISION_EXISTENTE_DESEAS_CONTINUAR, Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (YesNo.Equals(DialogResult.Yes))
                                //UC = "deleteAccountLineCommand";
                                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_DELETE_ACCOUNT_LINE_COMMAND);
                            else
                                // UC = "welcome";
                                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                        }
                        else
                        {
                            //UC = "deleteAccountLineCommand";
                            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_DELETE_ACCOUNT_LINE_COMMAND);
                        }
                    }
                    else
                        //    UC = "deleteAccountLineCommand";
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_DELETE_ACCOUNT_LINE_COMMAND);
                }
                else
                    //    UC = "deleteAccountLineCommand";//
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_DELETE_ACCOUNT_LINE_COMMAND);
            }
            else
            {   //UC = "deleteAccountLineCommand";//
                row = 0; col = 0;
                send = Resources.TicketEmission.Constants.COMMANDS_AST_PAC;
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    sabreAnswer = objCommands.SendReceive(send);
                }
                CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.ACCOUNTING_DATA, ref row, ref col);
                if (row != 0 || col != 0)
                {
                    send = Resources.TicketEmission.Constants.COMMANDS_AC_AT_ALL;
                    using (CommandsAPI objCommands = new CommandsAPI())
                    {
                        objCommands.SendReceive(send);
                        //Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_DELETE_ACCOUNT_LINE_COMMAND);
                    }
                }
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_DELETE_ACCOUNT_LINE_COMMAND);
            }
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



        /// <summary>
        /// Gets the credit cards.
        /// </summary>
        public static void GetCreditCards()
        {
            //va hacia el web services
            string[] fullNames;
            if (nameProfile.Contains("2"))
            {
                 fullNames = NameProfile.Split('2');
                fullNames = fullNames[0].Split('/');
            }
            else
            {
                fullNames = NameProfile.Split('/');
            }
            if (string.IsNullOrEmpty(ucFormPayment.secondLevel))
                ucFormPayment.secondLevel = NameProfile;

            WsMyCTS wsServ = new WsMyCTS();
            string[] templistCardsSecondLevel = null;


            templistCardsSecondLevel = wsServ.GetCreditCardsSecondLevel(fullNames[1], fullNames[0], DK);
            

            var listCardsFirstLevel = wsServ.GetCreditCardsFirstLevel(DK);
            string cc = string.Empty;
            var listCardsSecondLevel = templistCardsSecondLevel;
            var listCardsSecondLevelTemp = new List<string>();
            var listCardsFirstLevelTemp = new List<string>();
            foreach (string creditCard in listCardsSecondLevel)
            {
                //string[] items = creditCard.Split(new string[] { "*#*" }, System.StringSplitOptions.RemoveEmptyEntries);
                string[] items = creditCard.Split(new string[] { "*#*" }, System.StringSplitOptions.None);
                if (items.Length > 0)
                    if (!string.IsNullOrEmpty(items[0]))
                    {
                        cc = string.Concat(items[0], "-", items[1], " ", items[2], "/", items[3], "^", items.Length > 14 ? items[14] : "HTLsqvtsOdE=", "^", (items.Length > 4) ? items[4] : string.Empty);
                        //cc = string.Concat(items[0], "-", items[1], " ", items[2], "/", items[3]);// " ", items[14], "-" + items[4]);
                        //if (items.Length > 4)
                        listCardsSecondLevelTemp.Add(cc);
                        items = null;
                    }
            }

            foreach (string creditCard in listCardsFirstLevel.Where(s =>(!String.IsNullOrEmpty(s))).ToArray())
            {
                string[] items = creditCard.Split(new string[] { "*#*" }, System.StringSplitOptions.None);

                if (!items[0].Equals("*") && !string.IsNullOrEmpty(items[0].ToString()))
                {
                    var typeOfServ = (items.Length == 4) ? items[3].Split('*') : null;
                    cc = items[0].Replace('*', '-');
                    if (typeOfServ != null)
                    {
                        listCardsFirstLevelTemp.Add(string.Concat(cc, " ", items[1], "^", items[2] + " " + ((typeOfServ.Length == 4) ? ((typeOfServ[0] == "Y") ? "AIR" : "") + "^" + ((typeOfServ[1] == "Y") ? "CAR" : "") + "^" + ((typeOfServ[0] == "Y") ? "HTL" : "") + "^" + typeOfServ[3] : " ")));
                    }
                    else {
                        listCardsFirstLevelTemp.Add(string.Concat(cc, " ", items[1], "^", items[2]));
                    }
                }
            }

            CreditCardsFirstLevel = listCardsFirstLevelTemp;
            CreditCardsSecondLevel = listCardsSecondLevelTemp;
        }

        public void getEmailsItinerary()
        {
            try
            {
                List<string> listEmail = new List<string>();
                List<string> listPass = new List<string>();
                if(newProfile!= null)
                  newProfile.Clear();
                newProfile = new List<NewPassengerProfile>();
                bool userEmail = true;
                string sabreAnswer = string.Empty;
                string dk = string.Empty;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    sabreAnswer = objCommand.SendReceive(Resources.Constants.COMMANDS_AST_PDK);

                    if (!sabreAnswer.Contains("NO PSGR DATA") && !sabreAnswer.Contains("NOTHING"))
                    {
                        string[] splliDk = sabreAnswer.Replace(" ", "").Split('-');

                        dk = splliDk[1].Replace("\n", "");
                    }
                    
                    sabreAnswer = objCommand.SendReceive(Resources.Constants.COMMANDS_AST_PE);

                    sabreAnswer = sabreAnswer.Replace("\n", "").Trim();

                    string[] sabreSplit = sabreAnswer.Split('‡');

                    if (sabreSplit[1] == "NO PSGR DATA")
                        return;

                    foreach (string item in sabreSplit)
                    {
                        if (Regex.IsMatch(item, "@"))
                        {
                            //Excluye los correos de CTS
                            string email = item.Replace(" ", "");

                            string correosExcluir = System.Configuration.ConfigurationManager.AppSettings["ExcluirCorreos"];

                            string[] correosSplt = correosExcluir.Split(';');

                            for (int i = 0; i < correosSplt.Length; i++)
                            {
                                if (email.Contains(correosSplt[i]))
                                {
                                    userEmail = false;
                                    break;
                                }
                                else
                                    userEmail = true;
                            }

                            if (userEmail)
                                listEmail.Add(email);
                        }
                    }
                    sabreAnswer = objCommand.SendReceive(Resources.Constants.COMMANDS_AST_N);
                    sabreAnswer = readPassenger(sabreAnswer);
                    sabreSplit = sabreAnswer.Split('|');
                    Hashtable hsUsers = new Hashtable();

                    foreach (string item in sabreSplit)
                    {
                        string[] nameSplit = Regex.Split(item, "[0-9]");

                        foreach (string itemName in nameSplit)
                        {
                            if (!string.IsNullOrEmpty(itemName) && itemName != "."&&itemName!= " ")
                            {
                                listPass.Add(itemName);
                            }
                        }
                    }

                    Hashtable result = relatedEmails(listEmail, listPass);

                    foreach (DictionaryEntry item in result)
                    {
                        List<Star2Details> listProfiles = MyCTS.Business.Get2StarEmailBL.Get2StarEmail(item.Key.ToString(), "");
                        NewPassengerProfile profile = new NewPassengerProfile();
                        
                        if (!string.IsNullOrEmpty(listProfiles[0].Name))
                        {
                            profile.LastName = listProfiles[0].LastName;
                            profile.Name = listProfiles[0].Name;
                            profile.Email = item.Key.ToString();
                            profile.IsNewProfile = true;
                        }
                        else
                        {
                            profile.LastName = item.Value.ToString().Split('/')[0];
                            profile.Name = item.Value.ToString().Split('/')[1];
                            profile.Email = item.Key.ToString();
                            profile.IsNewProfile = false;
                        }
                        profile.DK = dk;
                        newProfile.Add(profile);
                    }
                }
            }
            catch (Exception err)
            {
                //throw new Exception();
            }
        }

        public string readPassenger(string sabreAnswer)
        {
            sabreAnswer = sabreAnswer.Replace("\n", "");
            //sabreAnswer = sabreAnswer.Replace(" ", "");
            sabreAnswer = sabreAnswer.Replace(".", "");
            sabreAnswer = sabreAnswer.Replace("0", "|");
            sabreAnswer = sabreAnswer.Replace("1", "|");
            sabreAnswer = sabreAnswer.Replace("2", "|");
            sabreAnswer = sabreAnswer.Replace("3", "|");
            sabreAnswer = sabreAnswer.Replace("4", "|");
            sabreAnswer = sabreAnswer.Replace("5", "|");
            sabreAnswer = sabreAnswer.Replace("6", "|");
            sabreAnswer = sabreAnswer.Replace("7", "|");
            sabreAnswer = sabreAnswer.Replace("8", "|");
            sabreAnswer = sabreAnswer.Replace("9", "|");
            return sabreAnswer;// = sabreAnswer.Split(' ');
        }

        //Relaciona los email's con alguna similitud con el nombre del pasajero
        public Hashtable relatedEmails(List<string> listEmail, List<string> listPass)
        {
            try
            {
                Hashtable result = new Hashtable();
                int i = 0;
                List<string> listEmailDelete = new List<string>();
                List<string> listPassDelete = new List<string>();
                foreach (string itemEmail in listEmail)
                {
                    List<Star2Details> listProfiles = MyCTS.Business.Get2StarEmailBL.Get2StarEmail(itemEmail, "");
                    
                    if (!string.IsNullOrEmpty(listProfiles[0].Name))
                    {
                        for (int j = 0; j < listPass.Count ; j++)
                        {
                            string name = listPass[j].Replace(" ", "") ;
                            if (listProfiles[0].Name == name)
                            {
                                listEmailDelete.Add(itemEmail);
                                listPassDelete.Add(listPass[j]);
                                result.Add(itemEmail, listPass[j]);
                                break;
                            }                            
                        }
                    }
                    else
                    {
                        foreach (string itemPass in listPass)
                        {
                            if (itemEmail.Contains(itemPass.Split('/')[0]))
                            {
                                var r = from s in listPassDelete
                                        where s == itemPass
                                        select s;
                                if (!r.Any())
                                {
                                    listPassDelete.Add(itemPass);
                                    listEmailDelete.Add(itemEmail);
                                    result.Add(itemEmail, itemPass);
                                }

                                break;
                            }
                            else if (itemPass.Contains('/'))
                            {
                                if (itemEmail.Contains(itemPass.Split('/')[1]))
                                {
                                    var r = from s in listPassDelete
                                            where s == itemPass
                                            select s;

                                    if (!r.Any())
                                    {
                                        listPassDelete.Add(itemPass);
                                        listEmailDelete.Add(itemEmail);
                                        result.Add(itemEmail, itemPass);
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                foreach (string item in listPassDelete)
                {
                    listPass.Remove(item);
                }
                foreach (string item in listEmailDelete)
                {
                    listEmail.Remove(item);
                }
                int flag = 0;

                foreach (var item in listEmail)
                {
                    if (listPass.Count > flag)
                    {
                        result.Add(item, listPass[flag]);
                        flag++;
                    }
                    else
                    {
                        result.Add(item, "");
                    }
                }
                return result;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return null;
            }
        }
        #endregion//End MethodsClassf
    }

}
