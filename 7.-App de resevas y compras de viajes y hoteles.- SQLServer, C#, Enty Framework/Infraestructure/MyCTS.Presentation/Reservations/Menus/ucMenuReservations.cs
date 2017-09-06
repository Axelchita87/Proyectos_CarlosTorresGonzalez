using System;
using System.IO;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Forms.UI;
using MyCTS.Presentation.Reservations.Menus.ToolsBar.Funtion.Edition;

namespace MyCTS.Presentation
{
    public partial class ucMenuReservations : CustomUserControl
    {

        #region ======== Declaration of variable ======

        public static int passenger;
        public static int AirRateFlag;
        public static bool ChargeService=false;
        public static bool BillingAdress = false;
        public static bool qualityControls = false;
        public static bool closeGroup = false;
        public static bool phaseIV = false;
        public static string airLine;
        private static string send;
        private string sabreAnswer;



        #endregion

        public ucMenuReservations()
        {
            InitializeComponent();
        }


        private void ucMenuReservations_Load(object sender, EventArgs e)
        {
            menuStrip1.Form = this;
            menuStrip1.LoadDynamicMenu(Login.Firm, Login.PCC);
        }

        public static bool EnabledMenu
        {
           set
           {
               
               if (value.Equals(true))
               {
                   
                   reloadMenu();
               }
               else
               {
                   foreach (ToolStripMenuItemExtended item in menuStrip1.Items)                   
                   {
                       if (item is ToolStripMenuItemExtended)
                       {
                           item.ShortcutKeys = Keys.None;
                           if (item.DropDownItems.Count > 0)
                           {
                               searchChildItems(item.DropDownItems);
                           }
                       }
                   }
               }
               menuStrip1.Enabled = value;
           }
    
        }

        private static void searchChildItems(ToolStripItemCollection item)
        {
            try
            {
                foreach (ToolStripMenuItemExtended itemChild in item)
                {
                    if (itemChild is ToolStripMenuItemExtended)
                    {
                        itemChild.ShortcutKeys = Keys.None;
                        if (itemChild.DropDownItems.Count > 0)
                        {
                            searchChildItems(itemChild.DropDownItems);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public static void reloadMenu()
        {
            menuStrip1.clearMenuStripItems();           
            menuStrip1.LoadDynamicMenu(Login.Firm, Login.PCC);
        }
        


        #region===== My Modules =====

        private void MenuItemOnClick_Itinerary(object sender, EventArgs e)
        {
            loadItineraryUserControl();
        }

        private void MenuItemOnClick_Schedules(object sender, EventArgs e)
        {
            loadScheduleUserControl();
        }

        private void MenuItemOnClick_Search(object sender, EventArgs e)
        {
            loadSearchUserControl();
        }

        #region===== Reservations =====

        //LoadClipboard
        public void loadSearchUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            //Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCITINERARY);
            //Loader.AddToPanel(Loader.Zone.Middle, this, "ucVolarisContactPassangerCaptureFormulario");
            //pruebas
            frmSearch clipboard = new frmSearch();

            try
            {
                Form frm = Application.OpenForms["frmSearch"];
                if (frm.Equals(null))
                {
                    clipboard.Show();
                    clipboard.BringToFront();
                }
            }
            catch
            {
                frmSearch newClipboard = new frmSearch();
                clipboard = newClipboard;
                clipboard.Show();
            }
        }

        public void loadScheduleUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            //Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCITINERARY);
            //Loader.AddToPanel(Loader.Zone.Middle, this, "ucVolarisContactPassangerCaptureFormulario");
            //pruebas
            frmSchedule clipboard = new frmSchedule();

            try
            {
                Form frm = Application.OpenForms["frmSchedule"];
                if (frm.Equals(null))
                {
                    clipboard.Show();
                    clipboard.BringToFront();
                }
            }
            catch
            {
                frmSchedule newClipboard = new frmSchedule();
                clipboard = newClipboard;
                clipboard.Show();
            }
        }

        public void loadItineraryUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            //Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCITINERARY);
            //Loader.AddToPanel(Loader.Zone.Middle, this, "ucVolarisContactPassangerCaptureFormulario");
            //pruebas
            frmItinerary clipboard = new frmItinerary();
            try
            {
                Form frm = Application.OpenForms["frmItinerary"];
                if (frm.Equals(null))
                {
                    clipboard.Show();
                    clipboard.BringToFront();
                }
            }
            catch
            {
                frmItinerary newClipboard = new frmItinerary();
                clipboard = newClipboard;
                clipboard.Show();
            }
        }

        //MenuItemOnClick_Reservation event 
        private void MenuItemOnClick_Reservation(object sender, EventArgs e)
        {

        }

        //MenuItemOnClick_Availability event 
        private void MenuItemOnClick_Availability(object sender, EventArgs e)
        {
           loadAvailabilityUserControl();
        }


        //MenuItemOnClick_Segments event 
        private void MenuItemOnClick_Segments(object sender, EventArgs e)
        {
            loadSellAirSegmentUserControl();
        }

        //MenuItemOnClick_AirRate event
        private void MenuItemOnClick_AirRate(object sender, EventArgs e)
        {
            loadAirRateUserControl();
        }


        //MenuItemOnClick_AddPassengers event 
        private void MenuItemOnClick_AddPassengers(object sender, EventArgs e)
        {
            loadAddDataPassengerUserControl();
        }


        //MenuItemOnClick_DefinePassengerType event 
        private void MenuItemOnClick_DefinePassengerType(object sender, EventArgs e)
        {
            loadDefinePassengerTypeUserControl();
        }


        //MenuItemOnClick_BoletageReceived event 
        private void MenuItemOnClick_BoletageReceived(object sender, EventArgs e)
        {
            loadBoletageReceivedUserControl();
        }

        //MenuItemOnClick_BoletageDate event 
        private void MenuItemOnClick_BoletageDate(object sender, EventArgs e)
        {
            loadBoletageDateUserControl();
        }


        //MenuItemOnClick_SetsMap_Click event
        private void MenuItemOnClick_SetsMap(object sender, EventArgs e)
        {
            loadSetsMapUserControl();
        }


        //MenuItemOnClick_ConcludeReservation event
        private void MenuItemOnClick_ConcludeReservation(object sender, EventArgs e)
        {
            loadConcludeReservationUserControl();
        }

        private void MenuItemOnClick_MPDVirtual(object sender, EventArgs e)
        {
            loadMPDVirtualUserControl();
        }

        #endregion//End Reservations

        #region===== Profiles =====

        //MenuItemOnClick_ChangeNumberPx
        private void MenuItemOnClick_ProfilesModule(object sender, EventArgs e)
        {
            frmProfiles.IsReservationFlow = false;
            load_ProfilesModule();
        }

        private void MenuItemOnClick_AddProfilesSecondLevelByFile(object sender, EventArgs e)
        {
            loadAddProfilesSecondLevelByFileUserControl();
        }

        #endregion

        #region===== Tickets =====

        #region===== Phase IV =====


        //MenuItemOnClick_PhaseIV event
        private void MenuItemOnClick_CreatePhaseIV(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            phaseIV = true;
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_PHASEIV_FIRST_STEPS);
        }

        //MenuItemOnClick_PhaseIV event
        private void MenuItemOnClick_CreatePhaseIVReviewed(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            phaseIV = false;
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_PHASEIV_FIRST_STEPS);
        }


        //MenuItemOnClick_DeletePhaseIV event
        private void MenuItemOnClick_DeletePhaseIV(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_PHASEIV_DELETE_MASK);
        }

        #endregion//End Phase IV

        //MenuItemOnClick_TicketEmission event
        private void MenuItemOnClick_TicketEmission(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            qualityControls = false;
            userControlsPreviousValues.Revisedcharge = null;
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCFIRST_VALIDATIONS);
        }


        //MenuItemOnClick_ETKTFunctions event
        private void MenuItemOnClick_ETKTFunctions(object sender, EventArgs e)
        {
            //SOLO PRUEBA... CONTROLES DE CALIDAD
            //qualityControls = true;
            //Loader.AddToPanel(Loader.Zone.Middle, this, "ucDBQReport");
        }


        //MenuItemOnClick_PhaseIV event
        private void MenuItemOnClick_PhaseIV(object sender, EventArgs e)
        {
            
        }


        //MenuItemOnClick_TKTCancelTicketVOID event 
        private void MenuItemOnClick_TKTCancelTicketVOID(object sender, EventArgs e)
        {
            loadCancelTicketdVOIDUserControl();
        }

        //MenuItemOnClick_GetDIX event
        private void MenuItemOnClick_GetDIX(object sender, EventArgs e)
        {
            LoadGetDIXUserControl();
        }

        //MenuItemOnClick_TicketDWLIST event
        private void MenuItemOnClick_TicketDWLIST(object sender, EventArgs e)
        {
            DWLISTUserControl();
        }


        //MenuItemOnClick_PrintInvoiceTicket event
        private void MenuItemOnClick_PrintInvoiceTicket(object sender, EventArgs e)
        {
            //SOLO PRUEBA...
            //Loader.AddToPanel(Loader.Zone.Middle, this, "ucTaxes");
        }


        //MenuItemOnClick_ReprintCoupon event
        private void MenuItemOnClick_ReprintCoupon(object sender, EventArgs e)
        {

        }


        //MenuItemOnClick_SalesReport event
        private void MenuItemOnClick_SalesReport(object sender, EventArgs e)
        {
            ReportSalesCommandsSend();
        }


        //MenuItemOnClick_AccountantsLines event
        private void MenuItemOnClick_AccountantsLines(object sender, EventArgs e)
        {

        }

        //MenuItemOnClick_qualityControls event
        private void MenuItemOnClick_qualityControls(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            qualityControls = true;
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCFIRST_VALIDATIONS);
        }

        private void MenuItemOnClick_sendTicketPrinter(object sender, EventArgs e)
        {
            LoadSendTicketPrinterUserControl();
        }

        #endregion//End Tickets

        #region===== Edit Itinerary =====

        //MenuItemOnClick_FrecuentFligher event
        private void MenuItemOnClick_ChangeSegStatus(object sender, EventArgs e)
        {
            loadChangeSegmentStatusUserControl();
        }


        //_ChangeClassofService event
        private void MenuItemOnClick_ChangeClassofService(object sender, EventArgs e)
        {
            loadChangeClassServiceUserControl();
        }

        //MenuItemOnClick_SplitRecord event
        private void MenuItemOnClick_SplitRecord(object sender, EventArgs e)
        {
            loadSplitRecordUserControl();
        }

        //MenuItemOnClick_SplitRecord event
        private void MenuItemOnClick_SplitedRecordFile(object sender, EventArgs e)
        {
            SplitedRecordFileCommandsSend();
        }

        //MenuItemOnClick_ChangeNumberPx
        private void MenuItemOnClick_ChangeNumbrerPx(object sender, EventArgs e)
        {
            loadChangeNumbrerPxUserControl();
        }

        #endregion//End Edit Itinerary

        #region===== Edit Record =====


        //MenuItemOnClick_FrecuentFligher event
        private void MenuItemOnClick_FrecuentFligher(object sender, EventArgs e)
        {
            loadFrecuentFligherUserControl();
        }

        private void MenuItemOnClick_AddPhones(object sender, EventArgs e)
        {
            loadAddPhonesUserControl();
        }



        #region===== OSI/SSR Messages =====

        #region===== Add =====

        private void MenuItemOnClick_SSRSpecialService(object sender, EventArgs e)
        {
            loadSpecialServicesSSRUserControl();
        }

        private void MenuItemOnClick_OtherServicesInfo(object sender, EventArgs e)
        {
            loadSpecialServicesInfoUserControl();
        }

        private void MenuItemOnClick_PaxInfoInterFlight(object sender, EventArgs e)
        {
            loadInternationalPaxInfoUserControl();
        }

        private void MenuItemOnClick_OSIFOIDMessage(object sender, EventArgs e)
        {
            loadOSIMessageFOIDUserControl();
        }

        private void MenuItemOnClick_APISPassportMessage(object sender, EventArgs e)
        {
            loadAPISPassportMessageUserControl();
        }

        private void MenuItemOnClick_APISVisaMessage(object sender, EventArgs e)
        {
            loadAPISVisaMessageUserControl();
        }

        private void MenuItemOnClick_APISRescidenceDest(object sender, EventArgs e)
        {
            loadAPISRescidenceDestUserControl();
        }

        private void MenuItemOnClick_SecurePassengerFlight(object sender, EventArgs e)
        {
            loadSecurePassengerFlightUserControl();
        }

        #endregion//End Add

        #region===== Delete =====

        private void MenuItemOnClick_AmericanAirlines(object sender, EventArgs e)
        {
            airLine = "4";
            AmericanAirlinesCommands();
        }

        private void MenuItemOnClick_OtherAirlines(object sender, EventArgs e)
        {
            airLine = "3";
            OtherAirlinesCommands();
        }


        #endregion// End Delete

        #endregion//OSI/SSR Messages

        #endregion//End Edit Record

        #region===== Queues =====


        //MenuItemOnClick_RecordAccountsQueues event 
        private void MenuItemOnClick_RecordAccountsQueues(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Queues.Constants.UC_ACCOUNTS_RECORD_QUEUES);
        }


        //MenuItemOnClick_EnterToQueue event 
        private void MenuItemOnClick_EnterToQueue(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Queues.Constants.UC_ENTER_TO_QUEUE);
        }


        //MenuItemOnClick_AdvancePNRQueue event 
        private void MenuItemOnClick_AdvancePNRQueue(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Queues.Constants.UC_ADVANCE_PNR_QUEUE);
        }


        //MenuItemOnClick_RemoveRecordQueue event 
        private void MenuItemOnClick_RemoveRecordQueue(object sender, EventArgs e)
        {
            RemoveRecordQueue();
        }


        //MenuItemOnClick_SignOutQueue event 
        private void MenuItemOnClick_SignOutQueue(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Queues.Constants.UC_EXIT_FROM_QUEUE);
        }


        //MenuItemOnClick_PlaceRecordQueue event 
        private void MenuItemOnClick_PlaceRecordQueue(object sender, EventArgs e)
        {
            //here
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Queues.Constants.UC_PLACE_RECORD_QUEUE);
        }


        //MenuItemOnClick_RecordListQueue event 
        private void MenuItemOnClick_RecordListQueue(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Queues.Constants.UC_LIST_RECORDS_QUEUE);
        }


        //MenuItemOnClick_MoveRecordsQueues event 
        private void MenuItemOnClick_MoveRecordsQueues(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Queues.Constants.UC_MOVE_RECORDS_TWEEN_QUEUES);
        }


        //MenuItemOnClick_RecordHistoryQueue event 
        private void MenuItemOnClick_RecordHistoryQueue(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Queues.Constants.UC_HISTORY_RECORD_IN_QUEUE);
        }


        //MenuItemOnClick_PicCodeReference event 
        private void MenuItemOnClick_PicCodeReference(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Queues.Constants.UC_HISTORY_RECORD_QUEUE);
        }

        //MenuItemOnClick_WorkingPNRinQueue event 
        private void MenuItemOnClick_WorkingPNRinQueue(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Queues.Constants.UC_WORKING_PNR_IN_QUEUE);
        }


        #endregion

        #region ====== Remarks ========

        private void MenuItemOnClick_ChargeService(object sender, EventArgs e)
        {
            loadChargeServiceUserControl();
        }

        private void MenuItemOnClick_IndependentChargeService(object sender, EventArgs e)
        {
            loadIndependentChargeServiceUserControl();
        }

        private void MenuItemOnClick_BillingAdress(object sender, EventArgs e)
        {
            loadBillingAdressUserControl();
        }


        private void MenuItemOnClick_AddItineraryRemarks(object sender, EventArgs e)
        {
            loadAddItineraryRemarksUserControl();
        }

        private void MenuItemOnClick_AddGenericsRemarks(object sender, EventArgs e)
        {
            loadAddGenericsRemarksUserControl();
        }

        private void MenuItemOnClick_AddHitoricalRemarks(object sender, EventArgs e)
        {
            loadAddHistoricalRemarksUserControl();
        }

        private void MenuItemOnClick_AddAccountingRemarks(object sender, EventArgs e)
        {
            loadAddAccountingRemarksUserControl();
        }

        private void MenuItemOnClick_AddAssociateSegmentRemarks(object sender, EventArgs e)
        {
            loadAddAssociateSegmentRemarksUserControl();
        }

        private void MenuItemOnClick_DeleteRemarks(object sender, EventArgs e)
        {
            loadDeleteRemarksUserControl();
        }


        #endregion

        #region =====Flights & Fares - Connection Time=====

        private void MenuItemOnClick_ConectionTimeDiferentAirports(object sender, EventArgs e)
        {
            loadConectionTimeDiferentAirportsUserControl();
        }

        private void MenuItemOnClick_ConectionTime(object sender, EventArgs e)
        {
            loadConnectionTimeUserControl();
        }

        private void MenuItemOnClick_TimeConnectionToCurrentItinerary(object sender, EventArgs e)
        {
            loadTimeConnectionToCurrentItineraryUserControl();
        }

        #endregion //Vuelos y tarifas - Tiempo de conexión

        #region====== Group ======

        private void MenuItemOnClick_DefineGroup(object sender, EventArgs e)
        {
            loadDefineGroupUserControl();
        }

        private void MenuItemOnClick_SellSegmentGK(object sender, EventArgs e)
        {
            loadSellSegmentGKUserControl();
        }

        private void MenuItemOnClick_CloseGroup(object sender, EventArgs e)
        {
            loadCloseGroupUserControl();
        }

        private void MenuItemOnClick_InsertDataPassenger(object sender, EventArgs e)
        {
            loadInsertDataPassengerUserControl();
        }

        private void MenuItemOnClick_RecoverdGroup(object sender, EventArgs e)
        {
            loadRecoverdGroupUserControl();
        }

        private void MenuItemOnClick_SabanaGroup(object sender, EventArgs e)
        {
            loadSabanaGroupUserControl();
        }



        #endregion
        
        #region ======= Flights and Fares =========

        private void MenuItemOnClick_FlightNumber(object sender, EventArgs e)
        {
            loadFlightNumberUserControl();
        }

        private void MenuItemOnClick_FlightInformation(object sender, EventArgs e)
        {
            loadFlightInformationUserControl();
        }

        private void MenuItemOnClick_DetailsAvailability(object sender, EventArgs e)
        {
            loadDetailsAvailabilityUserControl();
        }

        private void MenuItemOnClick_DetailsItinerary(object sender, EventArgs e)
        {
            commadsSendDetailsItinerary();
        }

        #region===== FaresConsult =====

        private void MenuItemOnClick_FareConsultByRate(object sender, EventArgs e)
        {
            loadFareConsultbyRateUserControl();
        }

        private void MenuItemOnClick_FareConsultByPax(object sender, EventArgs e)
        {
            loadFareConsultbyPaxUserControl();
        }

        #endregion//End FaresConsult


        #endregion

        #region====== SERVICE CHARGE ======

        private void MenuItemOnClick_NewFeeRule(object sender, EventArgs e)
        {
            loadNewFeeRuleUserControl();
        }

        private void MenuItemOnClick_ActivationFeeRule(object sender, EventArgs e)
        {
            loadActivationFeeRuleUserControl();
        }

        #endregion //SERVICE CHARGE

        #region ======= Rate Avobe =======

        private void MenuItemOnClick_RateAvobe(object sender, EventArgs e)
        {
            loadRateAvobeUserControl();
        }

        private void MenuItemOnClick_HistoricRules(object sender, EventArgs e)
        {
            loadHistoricRulesUserControl();
        }

        #endregion

        #region ====== Accounting Lines ======

        private void MenuItemOnClick_AirCountableLine(object sender, EventArgs e)
        {
            loadAirAccountingLineUserControl();
        }

        private void MenuItemOnClick_BusCountableLine(object sender, EventArgs e)
        {
            loadLandAccountingLineUserControl();
        }

        private void MenuItemOnClick_PTAMCOcountableLine(object sender, EventArgs e)
        {
            loadMCOPTAAccountingLineUserControl();
        }

        #endregion //Accounting Lines

        private void MenuItemOnClick_Exit(object sender, EventArgs e)
        {
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive("SO*");
            }
        }
        #endregion//End My Modules

        #region===== Functions =====


        #region ====== Open Record ======

        //MenuItemOnClick_RecoverdRecord event 
        private void MenuItemOnClick_RecoverdRecord(object sender, EventArgs e)
        {
            loadRecoverdRecordUserControl();
        }


        //MenuItemOnClick_ClaimItByLastName event 
        private void MenuItemOnClick_ClaimItByLastName(object sender, EventArgs e)
        {
            loadClaimItByLastNameUserControl();
        }


        //MenuItemOnClick_ClaimItByLocalizerRecord event
        private void MenuItemOnClick_ClaimItByLocalizerRecord(object sender, EventArgs e)
        {
            LoadClaimItByLocalizerRecordUserControl();
        }


        #endregion//End Open Record


        #region===== Close Record =====

        //MenuItemOnClick_ClosedRecord event 
        private void MenuItemOnClick_ClosedRecord(object sender, EventArgs e)
        {
            loadConcludeReservationUserControl();
        }


        //MenuItemOnClick_IgnoredReservation event
        private void MenuItemOnClick_IgnoredReservation(object sender, EventArgs e)
        {
            loadIgnoreRecordUserControl();
        }


        #endregion// end close record

        #region===== Print =====

        //MenuItemOnClick_HardCopy event 
        private void MenuItemOnClick_HardCopy(object sender, EventArgs e)
        {
            hardCopyCommandsSend();
        }


        //MenuItemOnClick_HardCopySaveRate event
        private void MenuItemOnClick_HardCopySaveRate(object sender, EventArgs e)
        {
            hardCopySaveRateCommandsSend();
        }


        //MenuItemOnClick_DWLIST event
        private void MenuItemOnClick_DWLIST(object sender, EventArgs e)
        {
            DWLISTUserControl();
        }

        //MenuItemOnClick_CouponReexpedition
        private void MenuItemOnClick_CouponReexpedition(object sender, EventArgs e)
        {
            CouponReexpeditionUserControl();
        }


        #endregion//End print

        #region ====== Record ======

        private void MenuItemOnClick_ClientNumber(object sender, EventArgs e)
        {
            loadDKClientUserControl();
        }

        #endregion

        #region===== Printers Control =====

        //MenuItemOnClick_assignNotAssignPrinters event
        private void MenuItemOnClick_AssignNotAssignPrinters(object sender, EventArgs e)
        {
            assignNotAssignPrintersUserControl();
        }


        //MenuItemOnClick_ShowPrinterStatus event 
        private void MenuItemOnClick_ShowPrinterStatus(object sender, EventArgs e)
        {
            showPrinterStatusCommandsSend();
        }

        //MenuItemOnClick_ShowAssignPrinters event
        private void MenuItemOnClick_ShowAssignPrinters(object sender, EventArgs e)
        {
            showAssignPrintersCommandsSend();
        }


        #endregion//End Printers Control

        #region ====== Edition ======

        //MenuItemOnClick_DeployRecord event
        private void MenuItemOnClick_DeployRecord(object sender, EventArgs e)
        {
            DeployRecordCommandsSend();

        }


        //MenuItemOnClick_CancelSegments event 
        private void MenuItemOnClick_CancelSegments(object sender, EventArgs e)
        {
            loadCancelSegmentsUserControl();
        }


        //MenuItemOnClick_CancelTicketdVOID event 
        private void MenuItemOnClick_CancelTicketVOID(object sender, EventArgs e)
        {
            loadCancelTicketdVOIDUserControl();
        }


        //MenuItemOnClick_CancelTicketDQB event
        private void MenuItemOnClick_CancelTicketDQB(object sender, EventArgs e)
        {
            loadCancelTicketDQBUserControl();
        }


        //MenuItemOnClick_segmentProtection event
        private void MenuItemOnClick_segmentProtection(object sender, EventArgs e)
        {
            segmentProtection();
        }

        //MenuItemOnClick_segmentProtection event
        private void MenuItemOnClick_OrderSegments(object sender, EventArgs e)
        {
            loadOrderSegmentsUserControl();
        }

        //MenuItemOnClick_segmentProtection event
        private void MenuItemOnClick_AltaReglasFull(object sender, EventArgs e)
        {
            loadCorporateAltaUserControl();
        }
        //MenuItemOnClic_bajaReglasFull event
        private void MenuItemOnClick_BajaReglasFull(object sender, EventArgs e)
        {
            loadCorporateBajaUserControl();
        }
        //MenuItemOnClick_ModificacionReglasFull event
        private void MenuItemOnClick_ModificacionReglasFull(object sender, EventArgs e)
        {
            loadCorporateModificacionControl();
        }
        //MenuItemOnClick_ConsultaReglasFull event
        private void MenuItemOnClick_ConsultaReglasFull(object sender, EventArgs e)
        {
            loadCorporateConsultaAllControl();
        }
        //MenuItemOnClick_ConsultaCorporativoAsignado event
        private void MenuItemOnClick_ConsultaCorporativoAsignado(object sender, EventArgs e)
        {
            loadCorporateConsultaAsignadoControl();
        }
        //MenuItemOnClick_AdministracionConsultores event
        private void MenuItemOnClick_AdministracionConsultores(object sender, EventArgs e)
        {
            loadCorporateConsultayCambiosAsignadoControl();
        }
        //MenuItemOnClick_AdminQueuesProceso event
        private void MenuItemOnClick_AdminQueuesProceso(object sender, EventArgs e)
        {
            loadAdminQueuesProceso();
        }

        #endregion

        #region ====== See ======

        //AirSegments
        private void MenuItemOnClick_AirSegments(object sender, EventArgs e)
        {
            AirSegmentsCommandsSend();
        }


        //HotelSegments
        private void MenuItemOnClick_HotelSegments(object sender, EventArgs e)
        {
            HotelSegmentsCommandsSend();
        }

        //CarSegments
        private void MenuItemOnClick_CarSegments(object sender, EventArgs e)
        {
            CarSegmentsCommnadsSend();
        }


        //LineAccountants
        private void MenuItemOnClick_LineAccountants(object sender, EventArgs e)
        {
            LineAccountantsCommandsSend();
        }

        //Tarifa Almacenada
        private void MenuItemOnClick_TariffsStored(object sender, EventArgs e)
        {
            TariffsStoredCommandsSend();
        }


        //TimeReservation
        private void MenuItemOnClick_TimeReservation(object sender, EventArgs e)
        {
            TimeReservationCommnadsSend();
        }


        //Email
        private void MenuItemOnClick_Email(object sender, EventArgs e)
        {
            EmailCommandsSend();
        }


        //SixReceived
        private void MenuItemOnClick_SixReceived(object sender, EventArgs e)
        {
            SixReceivedCommandsSend();
        }


        //AssingSegments
        private void MenuItemOnClick_AssingSegments(object sender, EventArgs e)
        {
            AssingSegmentsCommandsSend();
        }


        //TimeLimit
        private void MenuItemOnClick_TimeLimit(object sender, EventArgs e)
        {
            TimeLimitCommandsSend();
        }


        //OSI/SSR
        private void MenuItemOnClick_OSISSR(object sender, EventArgs e)
        {
            OSISSRCommandsSend();
        }


        //Remarks
        private void MenuItemOnClick_Remarks(object sender, EventArgs e)
        {
            RemarksCommandsSend();
        }


        //HistoryRecord
        private void MenuItemOnClick_HistoryRecord(object sender, EventArgs e)
        {
            HistoryRecordCommandsSend();
        }


        //HistoryRecordQueues
        private void MenuItemOnClick_HistoryRecordQueues(object sender, EventArgs e)
        {
            HistoryRecordQueuesCommandsSend();
        }


        //ListTcketCancel
        private void MenuItemOnClick_ListTcketCancel(object sender, EventArgs e)
        {
            ListTcketCancelCommandsSend();
        }


        //ReportSales
        private void MenuItemOnClick_ReportSales(object sender, EventArgs e)
        {
            ReportSalesCommandsSend();
        }


        //ShowTicketRecord
        private void MenuItemOnClick_ShowTicketRecord(object sender, EventArgs e)
        {
            ShowTicketRecordCommandsSend();
        }


        //StatusEtkt
        private void MenuItemOnClick_StatusEtkt(object sender, EventArgs e)
        {
            StatusEtktCommandsSend();
        }

        #endregion

        #region ====== Traffic ======

        private void MenuItemOnClick_SeeChangeType(object sender, EventArgs e)
        {
            loadSeeChangeTypeUserControl();
        }

        private void MenuItemOnClick_CancelAuthPending(object sender, EventArgs e)
        {
            LoaducCancelAuthPendingUserControl();
        }

        private void MenuItemOnClick_SeeStatusEtkt(object sender, EventArgs e)
        {
            SeeStatusEtktCommandsSend();
        }


        private void MenuItemOnClick_SeeCodeAgent(object sender, EventArgs e)
        {
            SeeCodeAgentCommandsSend();
        }

        private void MenuItemOnClick_SeeHistoryRecord(object sender, EventArgs e)
        {
            SeeHistoryRecordCommandsSend();
        }


        private void MenuItemOnClick_SeeTicketNumber(object sender, EventArgs e)
        {
            SeeTicketNumberCommandsSend();
        }


        private void MenuItemOnClick_SeeLineAccountants(object sender, EventArgs e)
        {
            SeeLineAccountantsCommandsSend();
        }


        private void MenuItemOnClick_SeeListCancelTickets(object sender, EventArgs e)
        {
            SeeListCancelTicketsCommandsSend();
        }


        private void MenuItemOnClick_ShowStatusPrint(object sender, EventArgs e)
        {
            ShowStatusPrintCommnadsSend();
        }


        private void MenuItemOnClick_ShowAssingPrint(object sender, EventArgs e)
        {
            ShowAssingPrintCommandsSend();
        }

        private void MenuItemOnClick_dqbReport(object sender, EventArgs e)
        {
            loadDQBReportUserControl();
        }

        private void MenuItemOnClick_ReportInterJet(object sender, EventArgs e)
        {
            loadDQBReportInterjetUserControl();
        }

        private void MenuItemOnClick_ReporteVolaris(object sender, EventArgs e)
        {
            loadDQBReportVolarisUserControl();
        }

        private void MenuItemOnClick_TicketsNotUsed(object sender, EventArgs e)
        {
            loadTicketsNotUsedUserControl();
        }

        private void MenuItemOnClick_RegenerateInvoice(object sender, EventArgs e)
        {
            loadRegenerateInvoice();
        }

        private void MenuItemOnClick_updateUrlComBoard(object sender, EventArgs e)
        {
            updateUrlComBoard();
        }


        
        #endregion

        #region==== Firm ======

        private void MenuItemOnClick_ConsultSignature(object sender, EventArgs e)
        {
            loadConsultSignatureUserControl();
        }

        private void MenuItemOnClick_CleanSignature(object sender, EventArgs e)
        {
            loadCleanSignatureUserControl();
        }

        private void MenuItemOnClick_CreateSignature(object sender, EventArgs e)
        {
            loadCreateSignatureUserControl();
        }

        private void MenuItemOnClick_AssignTemporalPass(object sender, EventArgs e)
        {
            loadAssignTemporalPassUserControl();
        }

        private void MenuItemOnClick_ChangeName(object sender, EventArgs e)
        {
            loadChangeNameUserControl();
        }

        private void MenuItemOnClick_ChangeAgentCode(object sender, EventArgs e)
        {
            loadChangeAgentCodeUserControl();
        }

        private void MenuItemOnClick_ChangeDutyCode(object sender, EventArgs e)
        {
            loadChangeDutyCodeUserControl();
        }

        private void MenuItemOnClick_ListFirm(object sender, EventArgs e)
        {
            loadListFirmUserControl();
        }

        private void MenuItemOnClick_AddDeleteKeyWords(object sender, EventArgs e)
        {
            loadAddRemoveKeyWordsUserControl();
        }

        private void MenuItemOnClick_EnableDisableFirm(object sender, EventArgs e)
        {
            loadEnableDisableFirmUserControl();
        }

        private void MenuItemOnClick_DeleteFirm(object sender, EventArgs e)
        {
            loadDeleteFirmUserControl();
        }

        private void MenuItemOnClick_ChangeFirmMyCTS(object sender, EventArgs e)
        {
            loadChangeFirmMyCTSUserControl();
        }

        private void MenuItemOnClick_ConsultingFirmRole(object sender, EventArgs e)
        {
            loadConsultingFirmRoleUserControl();
        }

        private void MenuItemOnClick_InsertFirmRole(object sender, EventArgs e)
        {
            loadInsertFirmRoleUserControl();
        }
        
        private void MenuItemOnClick_DeleteFirmRole(object sender, EventArgs e)
        {
            loadDeleteFirmRoleUserControl();
        }

        private void MenuItemOnClick_InsertTA(object sender, EventArgs e)
        {
            loadInsertTAUserControl();
        }

        private void MenuItemOnClick_InsertIATA(object sender, EventArgs e)
        {
            loadInsertIATAUserControl();
        }

        private void MenuItemOnClick_UpdateTA(object sender, EventArgs e)
        {
            loadUpdateTAUserControl();
        }

        private void MenuItemOnClick_UpdateIATA(object sender, EventArgs e)
        {
            loadUpdateIATAUserControl();
        }

        private void MenuItemOnClick_DeleteTA(object sender, EventArgs e)
        {
            loadDeleteTAUserControl();
        }

        private void MenuItemOnClick_DeleteIATA(object sender, EventArgs e)
        {
            loadDeleteIATAUserControl();
        }

        private void MenuItemOnClick_InsertPcc(object sender, EventArgs e)
        {
            loadInsertPccUserControl();
        }

        private void MenuItemOnClick_UpdatePcc(object sender, EventArgs e)
        {
            loadUpdatePccUserControl();
        }

        private void MenuItemOnClick_DeletePcc(object sender, EventArgs e)
        {
            loadDeletePccUserControl();
        }

        #endregion

        #region===== Queues =====
        private void MenuItemOnClick_AssignQueueSignature(object sender, EventArgs e)
        {
            loadAssignQueueSignatureUserControl();
        }

        private void MenuItemOnClick_CancelQueueSignature(object sender, EventArgs e)
        {
            loadCancelQueueSignatureUserControl();
        }

        private void MenuItemOnClick_QueuesList(object sender, EventArgs e)
        {
            loadQueuesListUserControl();
        }
        #endregion

        #region ======= MyCTS =======

        private void MenuItemOnClick_AddAirlineFare(object sender, EventArgs e)
        {
            loadAddAirlineFareUserControl();
        }

        private void MenuItemOnClick_DeleteAirlineFare(object sender, EventArgs e)
        {
            loadDeleteAirlineFareUserControl();
        }

        private void MenuItemOnClick_UpdateAirlineFare(object sender, EventArgs e)
        {
            loadUpdateAirlineFareUserControl();
        }

        private void MenuItemOnClick_ConsultingAirlineFare(object sender, EventArgs e)
        {
            loadConsultingAirlineFareUserControl();
        }

        private void MenuItemOnClick_AddAirport(object sender, EventArgs e)
        {
            loadAddAirportUserControl();
        }
        private void MenuItemOnClick_DeleteAirport(object sender, EventArgs e)
        {
            loadDeleteAirportUserControl();
        }
        private void MenuItemOnClick_UpdateAirport(object sender, EventArgs e)
        {
            loadUpdateAirportUserControl();
        }
        private void MenuItemOnClick_ConsultingAirport(object sender, EventArgs e)
        {
            loadConsultingAirportUserControl();
        }

        //private void MenuItemOnClick_AddPCC(object sender, EventArgs e)
        //{
        //    loadAddPCCUserControl();
        //}
        
        //private void MenuItemOnClick_UpdatePCC(object sender, EventArgs e)
        //{
        //    loadUpdatePCCUserControl();
        //}
        private void MenuItemOnClick_ConsultingPCC(object sender, EventArgs e)
        {
            loadConsultingPCCUserControl();
        }
        private void MenuItemOnClick_AddAlAgreements(object sender, EventArgs e)
        {
            loadAddAlAgreementsUserControl();
        }
        private void MenuItemOnClick_DeleteAlAgreements(object sender, EventArgs e)
        {
            loadDeleteAlAgreementsUserControl();
        }
        private void MenuItemOnClick_UpdateAlAgreements(object sender, EventArgs e)
        {
            loadUpdateAlAgreementsUserControl();
        }
        private void MenuItemOnClick_ConsultingAlAgreements(object sender, EventArgs e)
        {
            loadConsultingAlAgreementsUserControl();
        }

        private void MenuItemOnClick_UpdateImages(object sender, EventArgs e)
        {
            loadUpdateImagesUserControl();
        }


        private void MenuItemOnClick_consultingQC(object sender, EventArgs e)
        {
            loadConsultingQCUserControl();
        }

        private void MenuItemOnClick_addnewcatalogsQC(object sender, EventArgs e)
        {
            loadAddnewcatalogsQCUserControl();
        }

        private void MenuItemOnClick_addnewQC(object sender, EventArgs e)
        {
            loadAddnewQCUserControl();
        }
        private void MenuItemOnClick_consultingQCbyAttribute(object sender, EventArgs e)
        {
            loadConsultingQCbyAttributeUserControl();
        }
        private void MenuItemOnClick_adqcbyattribute1(object sender, EventArgs e)
        {
            loadAdqcbyattribute1UserControl();
        }

        private void MenuItemOnClick_UpdateQC(object sender, EventArgs e)
        {
            loadUpdateQCUserControl();
        }
        private void MenuItemOnClick_DeleteCatalogQC(object sender, EventArgs e)
        {
            loadDeleteCatalogQCUserControl();
        }

        #endregion

        #endregion//End Functions

        #region===== ShortCuts =====

        //MenuItemOnClick_CodeDecode event 
        private void MenuItemOnClick_CodeDecode(object sender, EventArgs e)
        {
            loadCodeDecodeUserControl();
        }


        //MenuItemOnClick_ChangeType event 
        private void MenuItemOnClick_ChangeType(object sender, EventArgs e)
        {
            PccChangeTypeCommandsSend();
        }


        //MenuItemOnClick_PccChange event
        private void MenuItemOnClick_PccChange(object sender, EventArgs e)
        {
            loadPccChangeUserControl();
        }


        #endregion//End ShortCuts

        #region  ===== Help Desk =======

        private void MenuItemOnClick_ChatOneLine(object sender, EventArgs e)
        {
            linkButtonChatOneLine();
        }

        private void MenuItemOnClick_FormatFinder(object sender, EventArgs e)
        {
            linkButtonFormatFinder();
        }

        private void MenuItemOnClick_FastGuides(object sender, EventArgs e)
        {
            linkButtonFastGuides();
        }


        #endregion

        #region ======== Productivity ========

        private void MenuItemOnClick_PersonalProductivity(object sender, EventArgs e)
        {
            loadPersonalProductivityUserControl();
        }
        private void MenuItemOnClick_ProductivityPCC(object sender, EventArgs e)
        {
            loadProductivityUserPerPCCControl();
        }
        private void MenuItemOnClick_RankingProductivityPerCorporative(object sender, EventArgs e)
        {
            loadRankingProductivityPerCorporative();
        }

        private void MenuItemOnClick_RankingProductivityPerPCC(object sender, EventArgs e)
        {
            loadRankingProductivityPerPCC();
        }
        private void MenuItemOnClick_ProductivityPCCVsCorporative(object sender, EventArgs e)
        {
            loadProductivityPerPCCVsCorporativeControl();
        }

        //private void MenuItemOnClick_ProductivityCorporativeManagement(object sender, EventArgs e)
        //{
        //    loadProductivityCorporativeManagementUserControl();
        //}


        //private void MenuItemOnClick_ProductivityPCCManagement(object sender, EventArgs e)
        //{
        //    loadProductivityPCCManagementUserControl();
        //}

        #endregion

        //SOLO PARA PROBAR USER CONTROLS
        private void MenuItemOnClick_marcos(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucTicketsEmissionInstructions");
        }
     
        //SOLO PARA PRUEBA
        private void MenuItemOnClick_jessica(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucDeleteAccountLine");
        }

        

        #region===== MethodsClass =====


        #region===== My Modules =====


        #region===== Reservations =====

        //Load Clipboard
        //public void loadSearchUserControl()
        //{
        //    ucAvailability.IsInterJetProcess = false;
        //    VolarisSession.Clean();
        //    //Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCITINERARY);
        //    //Loader.AddToPanel(Loader.Zone.Middle, this, "ucVolarisContactPassangerCaptureFormulario");
        //    //pruebas
        //    frmSearch clipboard = new frmSearch();

        //    try
        //    {
        //        Form frm = Application.OpenForms["frmSearch"];
        //        if (frm.Equals(null))
        //        {
        //            clipboard.Show();
        //            clipboard.BringToFront();
        //        }
        //    }
        //    catch
        //    {
        //        frmSearch newClipboard = new frmSearch();
        //        clipboard = newClipboard;
        //        clipboard.Show();
        //    }
        //}

        //public void loadScheduleUserControl()
        //{
        //    ucAvailability.IsInterJetProcess = false;
        //    VolarisSession.Clean();
        //    //Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCITINERARY);
        //    //Loader.AddToPanel(Loader.Zone.Middle, this, "ucVolarisContactPassangerCaptureFormulario");
        //    //pruebas
        //    frmSchedule clipboard = new frmSchedule();

        //    try
        //    {
        //        Form frm = Application.OpenForms["frmSchedule"];
        //        if (frm.Equals(null))
        //        {
        //            clipboard.Show();
        //            clipboard.BringToFront();
        //        }
        //    }
        //    catch
        //    {
        //        frmSchedule newClipboard = new frmSchedule();
        //        clipboard = newClipboard;
        //        clipboard.Show();
        //    }
        //}

        //public void loadItineraryUserControl()
        //{
        //    ucAvailability.IsInterJetProcess = false;
        //    VolarisSession.Clean();
        //    //Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCITINERARY);
        //    //Loader.AddToPanel(Loader.Zone.Middle, this, "ucVolarisContactPassangerCaptureFormulario");
        //    //pruebas
        //    frmItinerary clipboard = new frmItinerary();
        //    try
        //    {
        //        Form frm = Application.OpenForms["frmItinerary"];
        //        if (frm.Equals(null))
        //        {
        //            clipboard.Show();
        //            clipboard.BringToFront();
        //        }
        //    }
        //    catch
        //    {
        //        frmItinerary newClipboard = new frmItinerary();
        //        clipboard = newClipboard;
        //        clipboard.Show();
        //    }
        //}

        //Load ucAvailability
        public void loadAvailabilityUserControl()
        {
            Loader.AddToPanel(Loader.Zone.Middle, this, "UserControl1");
            return;
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
           // Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCAVAILABILITY);
            //Loader.AddToPanel(Loader.Zone.Middle, this, "ucVolarisContactPassangerCaptureFormulario");
        }


        //Load ucSellAirSegment
        public void loadSellAirSegmentUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCSELL_AIR_SEGMENT);
        }


        //Load ucAirRate
        public void loadAirRateUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCAIR_RATE);
            AirRateFlag = 1;
        }


        //Load ucDefinePassengerType
        public void loadDefinePassengerTypeUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCDEFINE_PASSENGER_TYPE);
        }


        //Load ucBoletageReceived
        public void loadBoletageReceivedUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCBOLETAGERECEIVED);
        }


        //Load ucBoletageDate
        public void loadBoletageDateUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCBOLETAGEDATE);
        }

        public void LoadSendTicketPrinterUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCSENDTICKETPRINTER);
        }
        #endregion//End Reservations

        #region===== Profiles =====

        frmProfiles profile = new frmProfiles();
        private void load_ProfilesModule()
        {
            try
            {

                MyCTS.Presentation.Reservations.Profiles.UcSecondLevelProfiles.ListObjStar2Dcpsl.Clear();
                profile.Show();
                profile.BringToFront();
            }
            catch
            {
                frmProfiles newProfile = new frmProfiles();
                profile = newProfile;
                profile.Show();
            }
        }

        #endregion

        #region===== Edit Itinerary ====

        private void loadChangeSegmentStatusUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UC_CHANGE_SEGMENT_STATUS);
        }


        private void loadChangeClassServiceUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UC_CHANGE_CLASS_SERVICE);
        }


        private void loadSplitRecordUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UC_SPLIT_RECORD);
        }

        private void SplitedRecordFileCommandsSend()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            send = string.Empty;
            send = Resources.Constants.COMMANDS_F;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }

        private void loadChangeNumbrerPxUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            int row = 0;
            int col = 0;
            string result = string.Empty;

            using (CommandsAPI objCommands = new CommandsAPI())
            {
                result = objCommands.SendReceive("*N*I");
            }


            CommandsQik.searchResponse(result, "NO ITIN", ref row, ref col);
            if (row != 0 || col != 0)
            {
                MessageBox.Show("NO EXISTE ITINERARIO PRESENTE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                row = 0;
                col = 0;
            }
            else
            {
                ucAvailability.IsInterJetProcess = false;
                VolarisSession.Clean();
                ListTaxesInterjet.ClearTaxIntejer();
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCDECREASESINCREASES);
            }
        }

        #endregion//End Edit Itinerary

        #region===== Edit Record =====

        // Load loadFrecuentFligherUserControl
        public void loadFrecuentFligherUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UC_FRECUENT_FLIGHER);
        }

        public void loadAddPhonesUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCTELEPHONE);
        }

        #region===== OSI/SSR Messages =====

        #region===== Add =====

        // Load loadFrecuentFligherUserControl
        public void loadSpecialServicesSSRUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UC_SPECIAL_SERVICES_SSR);
        }

        // Load loadSpecialServicesInfoUserControl
        public void loadSpecialServicesInfoUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UC_SPECIAL_SERVICES_INFO);
        }

        // Load loadInternationalPaxInfoUserControl
        public void loadInternationalPaxInfoUserControl()
        {
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UC_INTERNATIONAL_PAX_INFO);
        }

        // Load loadInternationalPaxInfoUserControl
        public void loadOSIMessageFOIDUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UC_OSI_MESSAGE_FOID);
        }


        public void loadAPISPassportMessageUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCAPISPASSPORTMESSAGE);
        }

        public void loadAPISVisaMessageUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCMESSAGEAPIVISA);
        }

        public void loadAPISRescidenceDestUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCAPISRESIDENCEDESTINATION);
        }
        public void loadSecurePassengerFlightUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            ucTaxes.emissionTicket = false;
            ucDefinitionTargetElements2.emissionTicket = false;
            ucCalculateServiceCharge.emissionTicket = false;
            ucEndReservation.EndReservation = false;
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCSECUREPASSENGERFLIGHT);
        }


        #endregion//End Add

        #region===== Delete =====

        private void AmericanAirlinesCommands()
        {
            send = "*P4";
            using (CommandsAPI objCommand = new CommandsAPI())
            {
               sabreAnswer= objCommand.SendReceive(send);
            }
            APIDeleteRequirements();
           // Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UC_FRECUENT_FLIGHER);
        }

        private void OtherAirlinesCommands()
        {
            send = "*P3";
            
            using (CommandsAPI objCommand = new CommandsAPI())
            {
               sabreAnswer= objCommand.SendReceive(send);
            }
            APIDeleteRequirements();
        }



        #endregion// End Delete

        #endregion//OSI/SSR Messages
    
        #endregion//End Edit Record

        #region===== Queues =====

        public void RemoveRecordQueue()
        {
            send = Resources.Queues.Constants.COMMANDS_QR;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }

        #endregion 

        #region ====== Remarks =======

        public void loadChargeServiceUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            ChargeService = true;
           Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCCHARGESERVICE);
        }

        public void loadIndependentChargeServiceUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            ChargeService = true;
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCINDEPENDENTCHARGESERVICE);
        }

        public void loadBillingAdressUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            ucEndReservation.EndReservation = false;
            BillingAdress = true;
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCBILLINGADRESS);
        }

        public void loadAddItineraryRemarksUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCADDITINERARYREMARKS);
        }

        public void loadAddGenericsRemarksUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCADDGENERICSREMARKS);
        }

        public void loadAddHistoricalRemarksUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCADDHITORICALREMARKS);
        }

        public void loadAddAccountingRemarksUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCADDACCOUNTINGREMARKS);
        }

        public void loadAddAssociateSegmentRemarksUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCADDASSOCIATESEGMENTREMARKS);
        }

        public void loadDeleteRemarksUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCDELETEREMARKS);
        }
     

        #endregion

        #region ======= Flights and Fares ========

        private void loadFlightNumberUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCFLIGHTNUMBER);
        }

        private void loadFlightInformationUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCFLIGHTINFORMATION);
        }

        private void loadDetailsAvailabilityUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCDETAILSAVAILABILITY);
        }

        private void commadsSendDetailsItinerary()
        {
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive("VI*");
            }

        }

        #region===== FaresConsult =====

        private void loadFareConsultbyRateUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UC_FARE_CONSULT_BY_RATE);
        }

        private void loadFareConsultbyPaxUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UC_FARE_CONSULT_BY_PAX);
        }

        #endregion// End FaresConsult

        #region =====QueryRules=====

        private void MenuItemOnClick_DisplayTaxesToFare(object sender, EventArgs e)
        {
            loadDisplaTaxesToFareUserControl();
        }

        private void MenuItemOnClick_LineRate(object sender, EventArgs e)
        {
            loadLineRateUserControl();
        }

        private void MenuItemOnClick_DisplayHistoricRules(object sender, EventArgs e)
        {
            loadDisplayHistoricRulesUserControl();
        }

        private void MenuItemOnClick_DisplayRulesByCategories(object sender, EventArgs e)
        {
            loadDisplayRulesByCategariesUserControl();
        }

        #endregion//QueryRules

        #endregion

        #region ====== CHARGE SERVICE ======

        private void loadNewFeeRuleUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UCNEWFEERULE, new[] { "1" });
        }

        private void loadActivationFeeRuleUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            //InputBoxDialog input = new InputBoxDialog();
            //input.FormPrompt = "Ingrese el Password";
            //input.FormCaption = "Activación  de regla de cargo por servicio";
            //input.DefaultValue = string.Empty;
            //input.ModeToShow = InputBoxDialog.ModeTextBox.Password;
            //input.ShowDialog();
            ////if (InputBoxDialog.Cancel)
            ////    return;
            //string psw = input.InputResponse;
            //input.Close();

            //Parameter objParameter = ParameterBL.GetParameterValue("PasswordActivationFeeRule");
            //if (psw.Equals(objParameter.Values))
            //{

                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCACTIVATIONFEERULE);
            //    input.Close();
            //}
            //else if (string.IsNullOrEmpty(psw))
            //{
            //    MessageBox.Show("DEBE INGRESAR LA CONTRASEÑA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    input.Close();
            //    loadActivationFeeRuleUserControl();
            //}
            //else
            //{
            //    MessageBox.Show("CONTRASEÑA INCORRECTA", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    input.Close();
            //    loadActivationFeeRuleUserControl();
            //}

        }

        #endregion //CHARGE SERVICE

        #region ======= Rate Avobe =======

        private void loadRateAvobeUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCRATEAVOBE);
        }

        private void loadHistoricRulesUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCHISTORICRULES);

        }

        #endregion

        //Load ucAddMorePassenger
        public void loadAddMorePassengerUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            passenger = 1;
            //este es temporal miestras se coloca en el menu correspondiente
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCDEFINE_PASSENGER_TYPE);
        }

        #region ====== Accounting Lines ======

        /// <summary>
        /// Load ucAirAccountingLines
        /// </summary>
        public void loadAirAccountingLineUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCPREAIRACCOUNTINGLINE);
        }

        public void loadLandAccountingLineUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCLANDACCOUNTINGLINE);
        }

        public void loadMCOPTAAccountingLineUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCMCOPTAACCOUNTINGLINE);
        }

        #endregion //Accounting Lines

        #endregion//End My Modules

        #region===== Functions =====


        #region===== Open Record =====

        //Load ucClaimItporApellido
        private void loadClaimItByLastNameUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCCLAIM_IT_LASTNAME);
        }

        //Load ucClaimItPorRecordLocalizador
        private void LoadClaimItByLocalizerRecordUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCCLAIM_IT_RECORD);
        }

        public void loadRecoverdRecordUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCRECOVERRECORD);
        }

        public void LoadGetDIXUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCGETDIX);
        }

        #endregion



        #region===== Close Record =====

        //load ucIgnoreRecord
        public void loadIgnoreRecordUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCIGNORE_RECORD);
        }

        #endregion//End Close Record



        #region===== Print =====

        //hardCopy send command
        public void hardCopyCommandsSend()
        {
            send = string.Empty;
            send = Resources.Constants.COMMANDS_PTR_AST_A_AST_AST_B_FF_AST_T;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }


        //hardCopySaveRate send command
        public void hardCopySaveRateCommandsSend()
        {
            send = string.Empty;
            send = Resources.Constants.COMMANDS_PTR_AST_A_AST_AST_B_FF_AST_T;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send, 0, 1);
                objCommand.SendReceive(Resources.Constants.COMMANDS_PTR_AST_PQ);
            }
            
        }


        public void DWLISTUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCDWLIST);
        }

        private void CouponReexpeditionUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCOUPON_REEXPEDITION);
        }
        #endregion//End print


        #region ====== Record ======

        public void loadDKClientUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            ucFirstValidations.DK = string.Empty;
            ucAvailability.IsInterJetProcess = false;
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCDKCLIENT);
        }

        #endregion



        #region===== Printers Control =====

        //Load ucAssignNotAssignPrinters 
        public void assignNotAssignPrintersUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCASSIGN_OR_NOT_PRINTERS);
        }


        //Show printer status send command
        public void showPrinterStatusCommandsSend()
        {
            send = string.Empty;
            send = Resources.Constants.COMMANDS_RL_SLASH_P_STATUS;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_B_STATUS);
                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_I_STATUS);
                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_P_STATUS);
            }
            
        }


        //Show assign printers send command
        public void showAssignPrintersCommandsSend()
        {
            send = string.Empty;
            send = Resources.Constants.COMMANDS_AST_S_AST_P;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }
        #endregion



        #region ====== Edition ======

        public static void DeployRecordCommandsSend()
        {
            send = string.Empty;
            send = Resources.Constants.COMMANDS_AST_A;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }


        public void loadCancelSegmentsUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCCANCEL_SEGMENTS);
        }


        public void loadCancelTicketdVOIDUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCCANCEL_TICKET);
        }


        public void loadCancelTicketDQBUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCCANCEL_TICKETDQB);
        }

        public void loadOrderSegmentsUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UC_ORDER_SEGMENTS);
        }

        public void loadCorporateAltaUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UC_CORPORATE_CRUD, Resources.Constants.CORPORATE_CRUD_HIGH);
        }

        public void loadCorporateBajaUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UC_CORPORATE_CRUD, Resources.Constants.CORPORAT_CRUD_DROP);
        }

        public void loadCorporateModificacionControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UC_CORPORATE_CRUD, Resources.Constants.CORPORATE_CRUD_MODIFICATION);

        }

        public void loadCorporateConsultaAllControl()
        {
            //Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UC_CORPORATECONSULTING, Resources.Constants.CORPORATECONSULTINGALL);
            frmProfiles.IsReservationFlow = false;
            frmCorporateConsulting.consultingAsignado = false;
            frmCorporateConsulting.consultingAll = true;
            load_CorporateConsultingModule();
        }

        public void loadCorporateConsultaAsignadoControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            //Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UC_CORPORATECONSULTING, Resources.Constants.CORPORATECONSULTINGASIGNADO);
            frmProfiles.IsReservationFlow = false;
            frmCorporateConsulting.consultingAll = false;
            frmCorporateConsulting.consultingAsignado = true;
            load_CorporateConsultingModule();
        }

        public void loadCorporateConsultayCambiosAsignadoControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.Constants.UC_CORPORATE_CRUD, Resources.Constants.CORPORATE_CONSULTA_CAMBIOS_ASIGNADO);
        }

        public void loadAdminQueuesProceso()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCADMINQUEUESPROCES);
        }

         public void segmentProtection()
        {
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(Resources.Constants.COMMANDS_AST_IO);
            }

            if ((!string.IsNullOrEmpty(sabreAnswer)))
            {
                ERR_ConcludeReservation.err_concludereservation(sabreAnswer);

                if (!ERR_ConcludeReservation.Segment)
                {
                    SegmentProtection();
                }
            }
             
            
        }

         private void  SegmentProtection()
        {
            string datefinal = string.Empty;
            DateTime lastDate = DateTime.Now.AddDays(300);

            datefinal = lastDate.ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();

            send = string.Format(Resources.Constants.COMMANDS_SEGMENT_PROTECTION,
                    datefinal);


            using (CommandsAPI objCommand = new CommandsAPI())
            {

                objCommand.SendReceive(Resources.Constants.COMMANDS_0A);
                objCommand.SendReceive(send);
            }
        }

         #region CorporateConsulting

         frmCorporateConsulting consulting = new frmCorporateConsulting();
         private void load_CorporateConsultingModule()
         {
             try
             {
                 consulting.Show();
                 consulting.BringToFront();
             }
             catch
             {
                 frmCorporateConsulting newConsulting = new frmCorporateConsulting();
                 consulting = newConsulting;
                 consulting.Show();
             }
         }
         #endregion

        #endregion

        #region ====== See ======

         public void AirSegmentsCommandsSend()
        {
            send = string.Empty;
            send = Resources.Constants.COMMANDS_AST_IA_AST_S_CROSSLORAINE_AST_B;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }


        public void HotelSegmentsCommandsSend()
        {
            send = string.Empty;
            send = Resources.Constants.COMMANDS_AST_IH_AST_CROSSLORAINE;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }


        public void CarSegmentsCommnadsSend()
        {
            send = string.Empty;
            send = Resources.Constants.COMMANDS_AST_IC_AST_CROSSLORAINE;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }


        public void LineAccountantsCommandsSend()
        {
            send = string.Empty;
            send = Resources.Constants.COMMANDS_AST_PAC;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }

        public void TariffsStoredCommandsSend()
        {
            send = string.Empty;
            send = Resources.Constants.COMMANDS_AST_PQ;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }


        public void TimeReservationCommnadsSend()
        {
            send = string.Empty;
            send = Resources.Constants.COMMANDS_AST_IAB;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send, 0, 1);
            }
        }


        public void EmailCommandsSend()
        {
            send = string.Empty;
            send = Resources.Constants.COMMANDS_AST_PE;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }


        public void SixReceivedCommandsSend()
        {
            send = string.Empty;
            send = Resources.Constants.COMMANDS_AST_P6;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }


        public void AssingSegmentsCommandsSend()
        {
            send = string.Empty;
            send = Resources.Constants.COMMANDS_AST_B;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }


        public void TimeLimitCommandsSend()
        {
            send = string.Empty;
            send = Resources.Constants.COMMANDS_AST_P7;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }


        public void OSISSRCommandsSend()
        {
            send = string.Empty;
            send = Resources.Constants.COMMANDS_AST_P3_AST_P4;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }


        public void RemarksCommandsSend()
        {
            send = string.Empty;
            send = Resources.Constants.COMMANDS_AST_P5;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }


        public void HistoryRecordCommandsSend()
        {
            send = string.Empty;
            send = Resources.Constants.COMMANDS_AST_H;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }


        public void HistoryRecordQueuesCommandsSend()
        {
            send = string.Empty;
            send = Resources.Constants.COMMANDS_AST_QH;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }


        public void ListTcketCancelCommandsSend()
        {
            send = string.Empty;
            send = Resources.Constants.COMMANDS_WV_AST;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }


        public void ReportSalesCommandsSend()
        {
            send = string.Empty;
            send = Resources.Constants.COMMANDS_DQB_AST;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }


        public void ShowTicketRecordCommandsSend()
        {
            send = string.Empty;
            send = Resources.Constants.COMMANDS_AST_T;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send, 0, 1);
            }
        }


        public void StatusEtktCommandsSend()
        {
            send = string.Empty;
            send = Resources.Constants.COMMANDS_AST_T;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }
            APIResponse();// necesita respuesta
        }



        #endregion

        #region ===== Traffic ======

        public void loadSeeChangeTypeUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCCHANGE_TYPE);
        }

        public void LoaducCancelAuthPendingUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UC_CANCEL_AUTH_PENDING);
        }

        public void SeeStatusEtktCommandsSend()
        {
            send = string.Empty;
            send = Resources.Constants.COMMANDS_AST_T;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }
            APIResponse(); 
        }


        public void SeeCodeAgentCommandsSend()
        {
            send = string.Empty;
            send = Resources.Constants.COMMANDS_AST_P6;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }


        public void SeeHistoryRecordCommandsSend()
        {
            send = string.Empty;
            send = Resources.Constants.COMMANDS_AST_H;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }


        public void SeeTicketNumberCommandsSend()
        {
            send = string.Empty;
            send = Resources.Constants.COMMANDS_AST_T;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }


        public void SeeLineAccountantsCommandsSend()
        {
            send = string.Empty;
            send = Resources.Constants.COMMANDS_AST_PAC;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }

        public void SeeListCancelTicketsCommandsSend()
        {
            send = string.Empty;
            send = Resources.Constants.COMMANDS_WV_AST;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }

        public void ShowStatusPrintCommnadsSend()
        {
            send = string.Empty;
            send = Resources.Constants.COMMANDS_RL_SLASH_T_STATUS;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_B_STATUS);
                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_I_STATUS);
                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_P_STATUS);
            }
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCSTATUSPRINTER);

        }


        public void ShowAssingPrintCommandsSend()
        {
            send = string.Empty;
            send = Resources.Constants.COMMANDS_AST_S_AST_P;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }

        private void loadDQBReportUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_DBQ_REPORT);
        }

        private void loadTicketsNotUsedUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCDQBETU_REPORT);
        }

        private void loadRegenerateInvoice()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UC_REGENERATEINVOICE);
        }

        private void updateUrlComBoard()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucChangeUrlComissionBoard");
        }

        private void loadDQBReportInterjetUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.uc_DQB_ReportInterjet);
        }

        private void loadDQBReportVolarisUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.uc_DQB_ReportVolaris);
        }
        

        #endregion

        #region ====== Firm ======

        private void loadConsultSignatureUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucConsultingFirm");
        }

        private void loadCleanSignatureUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucClearFirm");
        }

        private void loadCreateSignatureUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucCreateFirm");
        }

        private void loadAssignTemporalPassUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucPasscodeTemp");
        }


        private void loadChangeNameUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucChangeName");
        }

        private void loadChangeAgentCodeUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucChangeCode");
        }
        private void loadChangeDutyCodeUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucChangeDutyCode");
        }

        private void loadListFirmUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucFirmList");
        }

        private void loadEnableDisableFirmUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucEnableDisableFirm");
        }

        private void loadAddRemoveKeyWordsUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucEnableDisable");
        }

        private void loadDeleteFirmUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucDeleteFirm");
        }

        private void loadChangeFirmMyCTSUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucChangeFirmMyCTS");
        }

        private void loadConsultingFirmRoleUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucConsultingFirmRole");
        }

        private void loadInsertFirmRoleUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucInsertFirmRole");
        }

        private void loadDeleteFirmRoleUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucDeleteFirmRole");
        }

        private void loadInsertTAUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucInsertTA");
        }

        private void loadInsertIATAUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucInsertIATA");
        }

        private void loadUpdateTAUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucUpdateTA");
        }

        private void loadUpdateIATAUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucUpdateIATA");
        }

        private void loadDeleteTAUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucDeleteTA");
        }

        private void loadDeleteIATAUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucDeleteIATA");
        }

        private void loadInsertPccUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucInsertPcc");
        }

        private void loadUpdatePccUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucUpdatePcc");
        }

        private void loadDeletePccUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucDeletePcc");
        }


        #endregion

        #region===== Queues =====
        private void loadAssignQueueSignatureUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucAssignQueueSignature");
        }

        private void loadCancelQueueSignatureUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucCancelQueueSignature");
        }

        private void loadQueuesListUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucQueuesList");
        }
        #endregion

        #region ===== MyCTS =======

        private void loadAddAirlineFareUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucAddAirLinesFare");
        }
        private void loadDeleteAirlineFareUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucDeleteAirLinesFare");
        }
        private void loadUpdateAirlineFareUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucChangeAirLinesFare");
        }
        private void loadConsultingAirlineFareUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucConsultingAirLinesFare");
        }

        private void loadAddAirportUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucAddAirPort");
        }
        private void loadDeleteAirportUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucDeleteAirPort");
        }
        private void loadUpdateAirportUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucChangeAirPort");
        }
        private void loadConsultingAirportUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucConsultingAirPorts");

        }
        //private void loadAddPCCUserControl()
        //{
        //    Loader.AddToPanel(Loader.Zone.Middle, this, "ucAddPCCs");
        //}

       
        //private void loadUpdatePCCUserControl()
        //{
        //    Loader.AddToPanel(Loader.Zone.Middle, this, "ucChangePCCs");
        //}
        private void loadConsultingPCCUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucConsultingPCCs");
        }
        private void loadAddAlAgreementsUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucAddAlAgreements");
        }
        private void loadDeleteAlAgreementsUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucDeleteAlAgreements");
        }
        private void loadUpdateAlAgreementsUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucChangeAlAgreements");
        }
        private void loadConsultingAlAgreementsUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucConsultingAlAgreements");
        }

        private void loadUpdateImagesUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCUPDATEIMAGES);
        }

        private void loadConsultingQCUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucExistQC");
        }
        private void loadAddnewcatalogsQCUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucAddCatalogQC");
        }
        private void loadAddnewQCUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucAddQC");
        }
        private void loadConsultingQCbyAttributeUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucConsultingQualityControls");
        }
        private void loadAdqcbyattribute1UserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucActivateDeactivateQCbyAttribute");
        }
        private void loadUpdateQCUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucUpdateQC");
        }
        private void loadDeleteCatalogQCUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucDeleteCatalogQC");
        }
        #endregion

        #endregion//End Functions

        #region===== shortCuts =====

        //load cCode_Decode
        public void loadCodeDecodeUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCCODE_DECODE);
        }


        //pccChange send command
        public void PccChangeTypeCommandsSend()
        {
            string sabre = string.Empty;
            send = string.Empty;

            send = Resources.Constants.COMMANDS_DC_CROSSLORAINE_USD1_SLASH_MXN_AST;
            sabre = "DC*USD*";
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
                objCommand.SendReceive(sabre);
            }
        }


        //load ucPCC
        public void loadPccChangeUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCPCC);
        }

        #endregion

        #region=====Flights & Fare - Connectio Time=====

        public void loadConectionTimeDiferentAirportsUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UC_CONECTIONTIMEDIFERENTAIRPORTS);
        }

        public void loadConnectionTimeUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UC_CONNECTIONTIME);
        }

        public void loadTimeConnectionToCurrentItineraryUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UC_TIMECONNECTIONTOCURRENTITINERARY);
        }

        #endregion//Vuelos y tarifas - Tiempo de conexión

        #region =====QueryRules=====

        public void loadDisplaTaxesToFareUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucDisplayTaxesToFare");
        }

        public void loadLineRateUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucLineRate", new[] { "1" });
        }

        public void loadDisplayHistoricRulesUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucDisplayHistoricRules");
        }

        public void loadDisplayRulesByCategariesUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucLineRate", new[] { "2" });
        }

        #endregion

        #region====== Group ======

        public void loadDefineGroupUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Group.Constants.UC_DEFINEGROUP);
        }

        public void loadSellSegmentGKUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Group.Constants.UC_SELLSEGMENTGK);
        }

        public void loadCloseGroupUserControl()
        {
            send = string.Empty;

            send = Resources.Constants.COMMANDS_AST_PAD;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
               sabreAnswer= objCommand.SendReceive(send);
            }

            APIResponseCloseGroup();
        }

        public void loadInsertDataPassengerUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Group.Constants.UC_INSERTDATAPASSENGER);
        }

        public void loadRecoverdGroupUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Group.Constants.UC_RECOVERGROUP);
        }

        public void loadSabanaGroupUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCSABANAGROUP);
        }

        #endregion

        #region  ===== Help Desk =======

        public void linkButtonChatOneLine()
        {
            string url = ParameterBL.GetParameterValue("ChatOnlineURL").Values;
            System.Diagnostics.Process.Start(url);
        }

        public void linkButtonFormatFinder()
        {
            string url = ParameterBL.GetParameterValue("FormatFinderURL").Values;
            System.Diagnostics.Process.Start(url);
        }
        public void linkButtonFastGuides()
        {
            string url = ParameterBL.GetParameterValue("FastGuidesSabreURL").Values;
            System.Diagnostics.Process.Start(url);
        }




        #endregion

        #region ====== Productivity =======

        private void loadPersonalProductivityUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            //bool rol = RolesBL.IsUserInRole(Login.UserId, "[adminprod]");
            //if (rol)
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCPRODUCTIVITYREPORT);
            //else
            //Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCPRODUCTIVITYREPORT);
        }

        private void loadProductivityUserPerPCCControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            //bool rol = RolesBL.IsUserInRole(Login.UserId, "[adminprod]");
            //if (rol)
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCPRODUCTIVITYPCC);
            //else
            //Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCPRODUCTIVITYPCC);

        }

        private void loadRankingProductivityPerCorporative()
        {
            ucAvailability.IsInterJetProcess = false;
           VolarisSession.Clean();
           ListTaxesInterjet.ClearTaxIntejer();
           Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCPRODUCTIVITYRANKING);
        }

        private void loadRankingProductivityPerPCC()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCPRODUCTIVITYRANKINGPERPCC);
        }

        private void loadProductivityPerPCCVsCorporativeControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCPRODUCTIVITYPCCVSCOPORATIVE);
        }

        //private void loadProductivityCorporativeManagementUserControl()
        //{
        //    Loader.AddToPanel(Loader.Zone.Middle, this, "ucProductivityReportManager");
        //}
        //private void loadProductivityPCCManagementUserControl()
        //{
        //    Loader.AddToPanel(Loader.Zone.Middle, this, "ucProductivityPCCManager");
        //}

        #endregion

        #region===== Commons =====

        //load ucConcludeReservation
        public void loadConcludeReservationUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UC_CONCLUDERESERVATION);
        }


        //Load ucSetsMap
        public void loadSetsMapUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCSETS_MAP);
        }


        //Load ucAddDataPassenger
        public void loadAddDataPassengerUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this,Resources.Constants.UCADD_DATA_PASSENGER);
        }

        public void loadMPDVirtualUserControl()
        {
            ucAvailability.IsInterJetProcess = false;
            VolarisSession.Clean();
            ListTaxesInterjet.ClearTaxIntejer();
            Loader.AddToPanel(Loader.Zone.Middle, this, "ucMPDVirtual");
        }

        public void APIResponse()
        {
            if ((!string.IsNullOrEmpty(sabreAnswer)))
            {
                ERR_MnuSee.err_mnuSee(sabreAnswer);
                if (ERR_MnuSee.Status)
                {
                    MessageBox.Show(ERR_MnuSee.CustomUserMsg, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ucAvailability.IsInterJetProcess = false;
                    VolarisSession.Clean();
                    ListTaxesInterjet.ClearTaxIntejer();
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCSTATUSETKT);
                }
            }
            


        }

        public void APIResponseCloseGroup()
        {
            if ((!string.IsNullOrEmpty(sabreAnswer)))
            {
                ERR_MnuSee.err_mnuSee(sabreAnswer);
                if (ERR_MnuSee.Status)
                {
                    send = string.Empty;

                    send = Resources.Constants.COMMANDS_N_AST_ENDIT_NM;
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        objCommand.SendReceive(send);
                    }
                }
                   
                    closeGroup = true;
                    ucAvailability.IsInterJetProcess = false;
                    VolarisSession.Clean();
                    ListTaxesInterjet.ClearTaxIntejer();
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCBOLETAGE_RECEIVED);

                
            }
        }

        public void APIDeleteRequirements()
        {
            if ((!string.IsNullOrEmpty(sabreAnswer)))
            {
                ERR_MnuSee.err_mnuSee(sabreAnswer);
                if (ERR_MnuSee.Status)
                {
                    MessageBox.Show(ERR_MnuSee.CustomUserMsg, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ucAvailability.IsInterJetProcess = false;
                    VolarisSession.Clean();
                    ListTaxesInterjet.ClearTaxIntejer();
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCDELETESPECIALREQUERIMENTS);
                }
            }
        }

        private void loadAddProfilesSecondLevelByFileUserControl()
        {
            //Loader.AddToPanel(Loader.Zone.Middle, this, "ucAddProfilesSecondLevelByFile");
        }

        #endregion//End Commons


        #endregion//End MethodsClass
    }
}
