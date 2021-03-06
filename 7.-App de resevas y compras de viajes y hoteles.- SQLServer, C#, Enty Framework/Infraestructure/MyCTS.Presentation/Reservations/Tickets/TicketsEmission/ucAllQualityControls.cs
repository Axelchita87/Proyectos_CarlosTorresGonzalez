using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Presentation.Components;
using MyCTS.Forms.UI;
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;
using System.Linq;

namespace MyCTS.Presentation
{

    public partial class ucAllQualityControls : CustomUserControl
    {
        /// <summary>
        /// Descripción: User Control que permite ingresar valores por parte del agente
        ///              para la creacion de remarks aplicables para ICAAV e INTEGRA por corporativo
        ///              de forma dinamica por pasajero.
        ///              Pertenece al flujo de emisión de boleto de la aplicación.
        /// Creación:    23 Julio 09, Modificación: 26 Octubre 09  - 01/Octubre/10
        /// Cambio:      modificaciones para creacion de qualityControls Dinamicos al 100%
        ///              modificacion en justificación de tarifa para TM100  
        /// Modificado por: Jessica Gutierrez
        /// Solicito:    Guillermo Granados
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        /// 

        public MyCTS.Entities.VolarisReservation Reservation { get; set; }
        public InterJetTicket Ticket { get; set; }

        private static string ticketsjustifications;
        public static string TicketsJustifications
        {
            get { return ticketsjustifications; }
            set { ticketsjustifications = value; }
        }

        private static string businessunit;
        public static string BusinessUnit
        {
            get { return businessunit; }
            set { businessunit = value; }
        }

        private static string origin;
        public static string Origin
        {
            get { return origin; }
            set { origin = value; }
        }

        private static string icaavremarkcc;
        public static string icaavRemarkCC
        {
            get { return icaavremarkcc; }
            set { icaavremarkcc = value; }
        }

        private static string icaavremarkcd;
        public static string icaavRemarkCD
        {
            get { return icaavremarkcd; }
            set { icaavremarkcd = value; }
        }

        private static string icaavremarkce;
        public static string icaavRemarkCE
        {
            get { return icaavremarkce; }
            set { icaavremarkce = value; }
        }

        private static string icaavremarkcf;
        public static string icaavRemarkCF
        {
            get { return icaavremarkcf; }
            set { icaavremarkcf = value; }
        }

        private static string icaavremarkcg;
        public static string icaavRemarkCG
        {
            get { return icaavremarkcg; }
            set { icaavremarkcg = value; }
        }

        private static string icaavremarkch;
        public static string icaavRemarkCH
        {
            get { return icaavremarkch; }
            set { icaavremarkch = value; }
        }

        private static string tempchargeservice;
        public static string tempChargeService
        {
            get { return tempchargeservice; }
            set { tempchargeservice = value; }
        }

        private static string qc28value;
        public static string QC28Value
        {
            get { return qc28value; }
            set { qc28value = value; }
        }

        private bool statusParamReceived;
        private static bool IsCatalogExist;
        private string justificationsDescription;
        private string positionOneCF;
        private string positionTwoCF;
        private string positionThreeCF;
        private string positionFourCF;
        private string positionOneCG;
        private string positionTwoCG;
        private string passengerNumber;
        private string messageToSend;
        private string sabreConcat;
        private string c29;
        private int qcNameX = 0;
        private int qcNameY = 0;
        private int qcInputX = 0;
        private int qcInputY = 0;
        private int tabIndex = 0;
        private bool IncluirCargoPorServicio = false;
        private bool IncluirCargoPorServicioAuto = false;
        private int verticalPosition = 0;
        public static int globalPaxNumber = 0;
        public static int counter = 0;
        public static List<string> chargePerService = new List<string>();
        public static List<string> workerNumberArray = new List<string>();
        public static List<string> remarksIntegra = new List<string>();
        public static List<string> remarksClients = new List<string>();
        public static List<string> arrayValues = new List<string>();
        public static List<string> paxNumberLabel = new List<string>();
        public static List<string> originOfSale = new List<string>();
        public static List<string> ListBussinesUnit = new List<string>();
        public static string[] labelRemarksCValues = new string[100];
        public static List<Array> passengerPositionValues = new List<Array>();
        public static string remarksHotels = string.Empty;
        public static string operativeUnit = string.Empty;
        public static string origenSales = string.Empty;
        public static bool isClientPayProvider = false;
        public static bool isDocumentNow = false;
        private string LabelC10 = string.Empty;
        private TextBox txtSender;
        public static List<QCControlsClients> dinamicQualityControlsList;

        private static bool escKeyDown = false;

        private InterJetProcessObserver _processObserver;

        /// <summary>
        /// Gets the process observer.
        /// </summary>
        private InterJetProcessObserver ProcessObserver
        {
            get
            {
                return _processObserver ?? (_processObserver = new InterJetProcessObserver
                {
                    UserControl = this

                });
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="msg">A <see cref="T:System.Windows.Forms.Message"/>, passed by reference, that represents the window message to process.</param>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys"/> values that represents the key to process.</param>
        /// <returns>
        /// true if the character was processed by the control; otherwise, false.
        /// </returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (ProcessObserver.HandleEvent(ref msg, keyData))
            {
                return true;

            }
            if (keyData == (Keys.Escape))
            {
                counter--;
                escKeyDown = true;
                if (counter >= 0)
                {
                    originOfSale.RemoveAt(counter);
                    ListBussinesUnit.RemoveAt(counter);
                    Loader.AddToPanel(Loader.Zone.Middle, this,
                                      Resources.TicketEmission.Constants.UC_ALL_QUALITY_CONTROLS);
                }
                else
                {
                    counter = 0;
                    globalPaxNumber = 0;
                    escKeyDown = false;
                    if (!ucEndReservation.isFlowHotel)
                        Loader.AddToPanel(Loader.Zone.Middle, this,
                                          Resources.TicketEmission.Constants.UC_QUALITIES_BY_PAX);
                    else
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
                //Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_QUALITIES_BY_PAX);
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        public ucAllQualityControls()
        {
            InitializeComponent();
            LastControlFocus = btnAccept;
        }



        /// <summary>
        /// Establecimiento de valores iniciales 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucAllQualityControls_Load(object sender, EventArgs e)
        {
            if (ucEndReservation.isFlowHotel)
            {
                ucMenuReservations.EnabledMenu = false;
            }
            CounterValueValidation();
            ClearValues();
            TitleByCorporativeId();
            ActiveQualityControls();
            SetOptionalQualityControls();
            LoadComboboxValues();
            ComboBoxInitialValue();
            AssignInitialControl();
            InitialControlBackcolor();
            ControlEventsAssing();
            IcavComboboxvalues();
            LoadValues();
            ValidateCorporative();
            LoadPredictiveLists();
            AddQCValues();
            Parameter param = ParameterBL.GetParameterValue("RecoverCTSRemarks");
            if (param.Values.Equals("A"))
            {
                AddCTSQCValues();
            }
            SetClientValues();

        }

        private void LimpiarControles()
        {
            CatValuesXMLQualityControls a = new CatValuesXMLQualityControls();
            a.C1 = string.Empty;
            a.C10 = string.Empty;
            a.C100 = string.Empty;
            a.C11 = string.Empty;
            a.C12 = string.Empty;
            a.C13 = string.Empty;
            a.C14 = string.Empty;
            a.C15 = string.Empty;
            a.C16 = string.Empty;
            a.C17 = string.Empty;
            a.C18 = string.Empty;
            a.C19 = string.Empty;
            a.C2 = string.Empty;
            a.C20 = string.Empty;
            a.C21 = string.Empty;
            a.C22 = string.Empty;
            a.C23 = string.Empty;
            a.C24 = string.Empty;
            a.C25 = string.Empty;
            a.C26 = string.Empty;
            a.C27 = string.Empty;
            a.C28 = string.Empty;
            a.C29 = string.Empty;
            a.C3 = string.Empty;
            a.C30 = string.Empty;
            a.C31 = string.Empty;
            a.C32 = string.Empty;
            a.C33 = string.Empty;
            a.C34 = string.Empty;
            a.C35 = string.Empty;
            a.C36 = string.Empty;
            a.C37 = string.Empty;
            a.C38 = string.Empty;
            a.C39 = string.Empty;
            a.C4 = string.Empty;
            a.C40 = string.Empty;
            a.C41 = string.Empty;
            a.C42 = string.Empty;
            a.C43 = string.Empty;
            a.C44 = string.Empty;
            a.C45 = string.Empty;
            a.C46 = string.Empty;
            a.C47 = string.Empty;
            a.C48 = string.Empty;
            a.C49 = string.Empty;
            a.C5 = string.Empty;
            a.C50 = string.Empty;
            a.C51 = string.Empty;
            a.C52 = string.Empty;
            a.C53 = string.Empty;
            a.C54 = string.Empty;
            a.C55 = string.Empty;
            a.C56 = string.Empty;
            a.C57 = string.Empty;
            a.C58 = string.Empty;
            a.C59 = string.Empty;
            a.C6 = string.Empty;
            a.C60 = string.Empty;
            a.C61 = string.Empty;
            a.C62 = string.Empty;
            a.C63 = string.Empty;
            a.C64 = string.Empty;
            a.C65 = string.Empty;
            a.C66 = string.Empty;
            a.C67 = string.Empty;
            a.C68 = string.Empty;
            a.C69 = string.Empty;
            a.C7 = string.Empty;
            a.C70 = string.Empty;
            a.C71 = string.Empty;
            a.C72 = string.Empty;
            a.C73 = string.Empty;
            a.C74 = string.Empty;
            a.C75 = string.Empty;
            a.C76 = string.Empty;
            a.C77 = string.Empty;
            a.C78 = string.Empty;
            a.C79 = string.Empty;
            a.C8 = string.Empty;
            a.C80 = string.Empty;
            a.C81 = string.Empty;
            a.C82 = string.Empty;
            a.C83 = string.Empty;
            a.C84 = string.Empty;
            a.C85 = string.Empty;
            a.C86 = string.Empty;
            a.C87 = string.Empty;
            a.C88 = string.Empty;
            a.C89 = string.Empty;
            a.C9 = string.Empty;
            a.C90 = string.Empty;
            a.C91 = string.Empty;
            a.C91 = string.Empty;
            a.C92 = string.Empty;
            a.C93 = string.Empty;
            a.C94 = string.Empty;
            a.C95 = string.Empty;
            a.C96 = string.Empty;
            a.C97 = string.Empty;
            a.C98 = string.Empty;
            a.C99 = string.Empty;

        }

        /// <summary>
        /// Reglas de negocio y asignación de valores para la creacion de remarks
        /// contables ICAAV e INTEGRA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            remarksHotels = string.Empty;
            try
            {
                if (!IsValidBusinessRules)
                {
                    counter++;
                    RemarkIntegraValues();
                    RemarkICAAVValues();
                    JustificationsValues();
                    BusinessUnitValues();
                    SalesOrigin();

                    if (ucEndReservation.isFlowHotel && counter == 1)
                    {
                        for (int i = 0; i < labelRemarksCValues.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(labelRemarksCValues[i]))
                            {
                                string remark = string.Concat("C", i + 1, "-", labelRemarksCValues[i]);
                                remarksHotels = string.Concat(remarksHotels, "|", remark);
                                if (i + 1 == 22)
                                {
                                    operativeUnit = labelRemarksCValues[i];
                                }
                                if (i + 1 == 21)
                                {
                                    origenSales = labelRemarksCValues[i];
                                }
                            }
                        }

                        string cxsHotel = string.Empty;
                        string cxsCar = string.Empty;
                        string cxsProveedor = string.Empty;
                        string errorWSSabre = string.Empty;

                        if (ucEndReservation.isFlowHotel == true)
                        {
                            foreach (OTATravelItineraryObjectHotel objItineraryHotel in ucEndReservation.objItineraryHotel)
                            {
                                if ((objItineraryHotel.Service_Type == "H1" || objItineraryHotel.Service_Type == "H2") && string.IsNullOrEmpty(cxsHotel) && objItineraryHotel.StatusSabre == "HK")
                                {
                                    cxsHotel = "¿Desea cobrar un cargo por servicio en línea para los servicios de Hotel?";
                                }
                                else if ((objItineraryHotel.Service_Type == "AU" || objItineraryHotel.Service_Type == "AI") && string.IsNullOrEmpty(cxsCar) && objItineraryHotel.StatusSabre == "HK")
                                {
                                    cxsCar = "¿Desea cobrar un cargo por servicio en línea para los servicios de Autos?";
                                }

                                if (!string.IsNullOrEmpty(objItineraryHotel.errorWSSabre))
                                {
                                    if (!string.IsNullOrEmpty(errorWSSabre))
                                    {
                                        errorWSSabre = string.Concat(errorWSSabre, '\n');
                                    }

                                    errorWSSabre = string.Concat(errorWSSabre, objItineraryHotel.errorWSSabre);
                                }
                            }
                        }

                        if (string.IsNullOrEmpty(cxsHotel) && string.IsNullOrEmpty(cxsCar))
                        {
                            errorWSSabre = string.IsNullOrEmpty(errorWSSabre) ? "Solo existen segmentos GK en tu itinerario." : string.Concat(errorWSSabre, '\n'.ToString(), "Solo existen segmentos GK en tu itinerario.");
                        }

                        if (string.IsNullOrEmpty(errorWSSabre))
                        {
                            DialogResult result;

                            if (!string.IsNullOrEmpty(cxsCar) && !string.IsNullOrEmpty(cxsHotel))
                            {
                                cxsProveedor = "Para efectos de la reservación de Hotel y Auto \n\n ¿El Cliente pagara Directo al Proveedor?";
                            }
                            else if (!string.IsNullOrEmpty(cxsCar))
                            {
                                cxsProveedor = "Para efectos de la reservación de Auto \n\n ¿El Cliente pagara Directo al Proveedor?";
                            }
                            else
                            {
                                cxsProveedor = "Para efectos de la reservación de Hotel \n\n ¿El Cliente pagara Directo al Proveedor?";
                            }

                            result = MessageBox.Show(cxsProveedor, "MyCTS", MessageBoxButtons.YesNo);

                            if (result.Equals(DialogResult.Yes))
                            {
                                isClientPayProvider = true;
                                result = MessageBox.Show("El PNR se documentará en GEA un día después de la fecha de ingreso del pasajero. \n\n ¿Deseas que se emita la documentación hoy mismo?", Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (result.Equals(DialogResult.Yes))
                                {
                                    isDocumentNow = true;

                                    result = MessageBox.Show("Una vez emitida  la factura no  se podrá  modificar  el documento, \n los cambios los debes  realizar de forma manual directamente en GEA . \n\n ¿Deseas continuar con la emisión?", "MyCTS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                                    if (result.Equals(DialogResult.Yes))
                                    {
                                        isDocumentNow = true;
                                    }
                                    else
                                    {
                                        isDocumentNow = false;
                                    }
                                }
                                else
                                {
                                    isDocumentNow = false;
                                }

                                if (ucEndReservation.isFlowHotel == true)
                                {
                                    if (!string.IsNullOrEmpty(cxsHotel))
                                    {
                                        result = MessageBox.Show("¿Desea cobrar un cargo por servicio en línea para los servicios de Hotel?", "MyCTS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                                        if (result.Equals(DialogResult.Yes))
                                        {
                                            IncluirCargoPorServicio = true;
                                        }
                                    }

                                    if (!string.IsNullOrEmpty(cxsCar))
                                    {
                                        result = MessageBox.Show("¿Desea cobrar un cargo por servicio en línea para los servicios de Auto?", "MyCTS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                                        if (result.Equals(DialogResult.Yes))
                                        {
                                            IncluirCargoPorServicioAuto = true;
                                        }
                                    }

                                    //foreach (OTATravelItineraryObjectHotel objItineraryHotel in ucEndReservation.objItineraryHotel)
                                    //{
                                    //    if (objItineraryHotel.Service_Type == "H1" || objItineraryHotel.Service_Type == "H2")
                                    //    {
                                    //        result = MessageBox.Show("¿Desea cobrar un cargo por servicio en línea para los servicios de Hotel?", "MyCTS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                                    //        if (result.Equals(DialogResult.Yes))
                                    //        {
                                    //            IncluirCargoPorServicio = true;
                                    //        }
                                    //        break;
                                    //    }
                                    //}

                                    //foreach (OTATravelItineraryObjectHotel objItineraryHotel in ucEndReservation.objItineraryHotel)
                                    //{
                                    //    if (objItineraryHotel.Service_Type == "AU" || objItineraryHotel.Service_Type == "AI")
                                    //    {
                                    //        result = MessageBox.Show("¿Desea cobrar un cargo por servicio en línea para los servicios de Autos?", "MyCTS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                                    //        if (result.Equals(DialogResult.Yes))
                                    //        {
                                    //            IncluirCargoPorServicioAuto = true;
                                    //        }
                                    //        break;
                                    //    }
                                    //}
                                }
                            }
                            else
                            {
                                isClientPayProvider = false;
                                isDocumentNow = true;
                            }

                            string salesOrigin = GetIdSalesOriginBL.GetIdSalesOrigin(origenSales);
                            DateTime date = DateTime.Now;
                            if (ucEndReservation.objItineraryHotel != null &&
                                ucEndReservation.objItineraryHotel.Count > 0)
                            {
                                for (int i = 0; i < ucEndReservation.objItineraryHotel.Count; i++)
                                {
                                    ucEndReservation.objItineraryHotel[i].Remarks = remarksHotels;
                                    ucEndReservation.objItineraryHotel[i].Operational_Unit = operativeUnit;
                                    ucEndReservation.objItineraryHotel[i].Sales_Source = salesOrigin;
                                    ucEndReservation.objItineraryHotel[i].Prov_Direct_Pay = isClientPayProvider;
                                    if (isDocumentNow)
                                    {
                                        ucEndReservation.objItineraryHotel[i].Time_Limit = date;
                                    }
                                    else
                                    {
                                        ucEndReservation.objItineraryHotel[i].Time_Limit = ucEndReservation.objItineraryHotel[i].In_Date.AddDays(1);
                                    }
                                    ucEndReservation.objItineraryHotel[i].IVA = 16;
                                    ucEndReservation.objItineraryHotel[i].C_Date = date;
                                    ucEndReservation.objItineraryHotel[i].OrgId = Login.OrgId;
                                }
                                if (OTATravelItineraryHotelsBL.InsertItineraryHotel(ucEndReservation.objItineraryHotel))
                                {
                                    LogProductivity.LogTransaction(Login.Agent, "Registro de Hoteles Satifactorio en DetailsPNRHotel");
                                }
                                else
                                {
                                    LogProductivity.LogTransaction(Login.Agent, string.Concat("Error al insertar Registro de Hoteles en DetailsPNRHotel Record: ", ucEndReservation.objItineraryHotel[0].Record.Contains("|") ? ucEndReservation.objItineraryHotel[0].Record.Split('|')[0] : ucEndReservation.objItineraryHotel[0].Record));
                                }
                            }

                            if (!isClientPayProvider)
                            {
                                MessageBox.Show("Tu reservación será documentada en GEA, puedes realizar la búsqueda con la clave del PNR.", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                if (isDocumentNow)
                                {
                                    MessageBox.Show("La reservación ha sido documentada en GEA, de acuerdo a tu indicación será facturada el día de hoy y en breve se enviara la relación de servicio a tu cuenta de correo electrónico.", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    MessageBox.Show("La reservación ha sido documentada en GEA, de acuerdo a tu indicación será facturada el día posterior al inicio de la estancia y hasta ese día será enviada la Relación de Servicio a tu cuenta de correo electrónico.", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }

                            if (ucConcludeReservation.optionSelected.Equals("rdoClosecopyitinerary"))
                            {
                                string send;
                                if (!string.IsNullOrEmpty(ucBoletageReceived.param6Received))
                                {
                                    send = string.Concat("6", ucBoletageReceived.param6Received);
                                }
                                else
                                {
                                    send = string.Concat("6", Login.NombreCompleto);
                                }

                                using (CommandsAPI objCommand = new CommandsAPI())
                                {
                                    objCommand.SendReceive(send);
                                    objCommand.SendReceive("EC");
                                }
                            }
                        }
                    }
                    #region flujo normal de emision
                    if (!LoadXMLIntegraValues)
                    {//entra
                        LoadXMLClientsValues();
                        LoadFormValuesByPax();
                        LoadNextUcControl();
                    }
                    else
                    {

                        if (!ucAvailability.IsInterJetProcess)
                        {
                            QueueAgent();
                            using (CommandsAPI objCommand = new CommandsAPI())
                            {
                                objCommand.SendReceive(string.Concat(Resources.Constants.AST, ucEndReservation.objItineraryHotel[0].Record.Contains("|") ? ucEndReservation.objItineraryHotel[0].Record.Split('|')[0] : ucEndReservation.objItineraryHotel[0].Record));
                            }
                            activeStepsCorporativeQC.CorporativeQualityControls = null;

                            remarksHotels = string.Empty;
                            isDocumentNow = false;
                            ucMenuReservations.EnabledMenu = true;
                            ucEndReservation.objItineraryHotel = null;
                            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                        }
                    }
                    ucEndReservation.isFlowHotel = false;
                    #endregion flujo normal de emision
                }
            }
            catch (Exception ex)
            {
                if (ucEndReservation.isConfirmationNumberNull)
                {
                    MessageBox.Show("PNR no cuenta con clave de confirmación, favor de redesplegar PNR y volver a intentar.", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al cargar hotel, favor de volver a intentar.", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ucMenuReservations.EnabledMenu = true;
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }

        }


        #region===== MethodsClass =====

        private void QueueAgent()
        {
            string queueClient = string.Empty;
            string queue = string.Empty;
            string personalQueue = string.Empty;
            string queueAgent = string.Empty;
            string send = string.Empty;
            CatQueue item = CatQueueBL.GetQueue(Login.Firm, Login.PCC);
            if (!string.IsNullOrEmpty(item.Queue))
            {
                queue = item.Queue;
                if (!string.IsNullOrEmpty(queue))
                {
                    queueAgent = string.Format(Resources.Constants.COMMANDS_QP_SLA_AGENT_SLA_11,
                        queue);
                }
            }


            //GetAndSetAttribute1 Attribute = GetAndSetAttribute1BL.GetAttribute(dk)
            //List<DKTemp> listDKTemp = DKTempBL.GetDKTemp(Attribute.Attribute1.ToString(), false);
            List<DKTemp> listDKTemp = DKTempBL.GetDKTemp(ucEndReservation.dK, false);
            if (!listDKTemp.Count.Equals(0))
            {
                queueClient = listDKTemp[0].Queue;
                if (!string.IsNullOrEmpty(queueClient))
                    personalQueue = string.Format(Resources.Constants.COMMANDS_CROSSLORAINE_CLIENT_SLA_11,
                        queueClient);
            }
            string resp = string.Empty;
            if (!string.IsNullOrEmpty(queueAgent) && !string.IsNullOrEmpty(queueClient))
            {
                if (ucConcludeReservation.optionSelected.Equals("rdoPlaceQueue"))
                {
                    string CRQueuePlace = ucConcludeReservation.sendPlaceQueue;
                    CRQueuePlace = CRQueuePlace.Replace("QP/", Resources.Constants.CROSSLORAINE);
                    send = string.Concat(send, CRQueuePlace);
                }
                send = queueAgent + personalQueue;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    resp = objCommand.SendReceive(send);
                }


            }
            else if (!string.IsNullOrEmpty(queueAgent) && string.IsNullOrEmpty(queueClient))
            {
                if (ucConcludeReservation.optionSelected.Equals("rdoPlaceQueue"))
                {
                    string CRQueuePlace = ucConcludeReservation.sendPlaceQueue;
                    CRQueuePlace = CRQueuePlace.Replace("QP/", Resources.Constants.CROSSLORAINE);
                    queueAgent = string.Concat(queueAgent, CRQueuePlace);
                }
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    resp = objCommand.SendReceive(queueAgent);
                }
            }
        }


        /// <summary>
        /// Valida si el valor de la variable counter esta en cero y asigna valor del numero de pasajero 
        /// </summary>
        private void CounterValueValidation()
        {
            if (VolarisSession.IsVolarisProcess)
            {
                globalPaxNumber = VolarisSession.ContAdult + VolarisSession.ContChild;
            }
            if (globalPaxNumber.Equals(0))
            {
                globalPaxNumber = ucQualitiesByPax.Pax;
                statusParamReceived = false;
                if (chargePerService != null)
                    chargePerService.Clear();
                if (remarksIntegra != null)
                    remarksIntegra.Clear();
                if (passengerPositionValues != null)
                    passengerPositionValues.Clear();
                if (workerNumberArray != null)
                    workerNumberArray.Clear();
                if (remarksClients != null)
                    remarksClients.Clear();

            }

            if (!string.IsNullOrEmpty(ucQualitiesByPax.Passengers))
            {
                int counter = 0;
                paxNumberLabel = null;
                paxNumberLabel = new List<string>(ucQualitiesByPax.Passengers.Split(new char[] { '+' }));
                double[] temp = new double[paxNumberLabel.Count];
                foreach (string value in paxNumberLabel)
                {
                    temp[counter] = Convert.ToDouble(value);
                    counter++;
                }
                Array.Sort(temp);
                for (int i = 0; i < temp.Length; i++)
                {
                    paxNumberLabel[i] = temp[i].ToString();
                }


            }
            else
            {
                passengerNumber = string.Concat(counter + 1,
                    Resources.TicketEmission.Constants.DOT_ONE);
            }

            if (ucEndReservation.isFlowHotel)
            {
                globalPaxNumber = 1;
                passengerNumber = string.Concat(counter + 1,
                    Resources.TicketEmission.Constants.DOT_ONE);
            }
        }

        /// <summary>
        /// Establece valores de variables estaticas a vacio
        /// </summary>
        private void ClearValues()
        {
            if (counter.Equals(0))
            {
                icaavremarkcc = string.Empty;
                icaavremarkcd = string.Empty;
                icaavremarkce = string.Empty;
                icaavremarkcf = string.Empty;
                icaavremarkcg = string.Empty;
                icaavremarkch = string.Empty;
                tempchargeservice = string.Empty;
                IsCatalogExist = false;
            }
            for (int i = 0; i < labelRemarksCValues.Length; i++)
            {

                labelRemarksCValues[i] = string.Empty;
            }

            CatClientsCatalogsBL.ListClientsCatalogs = null;

        }

        /// <summary>
        /// Establece el nombre del corporativo en el titulo de la mascarilla 
        /// </summary>
        private void TitleByCorporativeId()
        {
            if (string.IsNullOrEmpty(ucQualitiesByPax.Passengers))
            {
                lblTitle.Text = string.Format("{0} {1} ",
                    Resources.TicketEmission.Constants.LABEL_TITLE_TEXT,
                    activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1);
                lblQualityControls.Text = string.Format(Resources.TicketEmission.Constants.LABEL_QUALITY_CONTROL_TEXT,
                    passengerNumber);
            }
            else
            {
                lblTitle.Text = string.Format("{0} {1} ",
                    Resources.TicketEmission.Constants.LABEL_TITLE_TEXT,
                    activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1);
                lblQualityControls.Text = string.Format(Resources.TicketEmission.Constants.LABEL_QUALITY_CONTROL_TEXT,
                    paxNumberLabel[counter]);
            }

        }

        /// <summary>
        /// Crea los controles necesarios dependiendo de los quality controls activos
        /// </summary>
        private void ActiveQualityControls()
        {
            qcNameX = 2;
            qcNameY = 53;
            qcInputX = 140;
            qcInputY = 50;
            tabIndex = 1;
            verticalPosition = 46;
            if (!ucEndReservation.isFlowHotel)
            {
                dinamicQualityControlsList = QCControlsClientsBL.GetQCControls(ucFirstValidations.Attribute1, Login.Firm, Login.PCC, Login.Agent);
                if (!ucFirstValidations.CorporativeQualityControls[0].EmissionSendQCClient.Equals(Resources.TicketEmission.Constants.ACTIVE))
                {
                    if (dinamicQualityControlsList[28].QCId.Equals(Resources.TicketEmission.Constants.QC_ID_C29))
                    {
                        dinamicQualityControlsList[28].CtrlType = string.Empty;
                    }
                }
            }
            else
            {
                ucQCHotels.CorporativeQualityControls = activeStepsCorporativeQC.CorporativeQualityControls;
                dinamicQualityControlsList = QCControlsClientsBL.GetQCControls(ucQCHotels.Attribute1, Login.Firm, Login.PCC, Login.Agent);
                if (ucQCHotels.CorporativeQualityControls[0].EmissionSendQCClient.Equals(Resources.TicketEmission.Constants.ACTIVE))
                {
                    if (dinamicQualityControlsList[28].QCId.Equals(Resources.TicketEmission.Constants.QC_ID_C29))
                    {
                        dinamicQualityControlsList[28].CtrlType = string.Empty;
                    }
                }
            }
            qc28value = string.Empty;
            qc28value = dinamicQualityControlsList[27].QCValue;
            if (dinamicQualityControlsList.Count > 0)
            {
                foreach (QCControlsClients qualityControls in dinamicQualityControlsList)
                {
                    //Desactiva la generación de cargo por servicio
                    if (qualityControls.QCId.Equals(Resources.TicketEmission.Constants.QC_ID_C23))
                    {
                        if (qualityControls.QCValue != "I")
                        {
                            tempchargeservice = qualityControls.QCValue;
                            qualityControls.QCValue = "I";
                        }
                    }                    //cambio unidad operativa vacia

                    if (!qualityControls.QCValue.Equals(Resources.TicketEmission.Constants.INACTIVE))
                    {
                        if (!string.IsNullOrEmpty(qualityControls.CtrlType))
                        {
                            if (ucEndReservation.isFlowHotel)
                            {
                                if (qualityControls.QCId.Equals(Resources.TicketEmission.Constants.QC_ID_C29))
                                {
                                    //BuildControls(qualityControls.QCDescription, qcNameX, qcNameY, Resources.TicketEmission.Constants.QC_CONTROL_TYPE_LABEL, qualityControls.CtrlLen, qualityControls.CtrlCurrentCriteria);
                                    //BuildControls(qualityControls.CtrlName, qcInputX, qcInputY, qualityControls.CtrlType, qualityControls.CtrlLen, qualityControls.CtrlCurrentCriteria);
                                }
                                else
                                {
                                    BuildControls(qualityControls.QCDescription, qcNameX, qcNameY, Resources.TicketEmission.Constants.QC_CONTROL_TYPE_LABEL, qualityControls.CtrlLen, qualityControls.CtrlCurrentCriteria);
                                    BuildControls(qualityControls.CtrlName, qcInputX, qcInputY, qualityControls.CtrlType, qualityControls.CtrlLen, qualityControls.CtrlCurrentCriteria);
                                }
                            }
                            else
                            {
                                BuildControls(qualityControls.QCDescription, qcNameX, qcNameY, Resources.TicketEmission.Constants.QC_CONTROL_TYPE_LABEL, qualityControls.CtrlLen, qualityControls.CtrlCurrentCriteria);
                                BuildControls(qualityControls.CtrlName, qcInputX, qcInputY, qualityControls.CtrlType, qualityControls.CtrlLen, qualityControls.CtrlCurrentCriteria);
                            }


                            if (qualityControls.QCId.Equals(Resources.TicketEmission.Constants.QC_ID_C10) &&
                                (activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_DANONE) ||
                                activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_DANONE2)))
                            {
                                qcNameY = qcNameY + 30;
                                BuildControls(qualityControls.CtrlDescription, qcInputX, qcInputY, Resources.TicketEmission.Constants.QC_CONTROL_TYPE_CHECKBOX, qualityControls.CtrlLen, qualityControls.CtrlCurrentCriteria);
                            }
                            else if (qualityControls.QCId.Equals(Resources.TicketEmission.Constants.QC_ID_C23))
                            {
                                //qcNameX = qcNameX + 30;
                                BuildControls("CANTIDADES SIN IVA", qcInputX + 100, qcInputY - 28, Resources.TicketEmission.Constants.QC_CONTROL_TYPE_LABEL, qualityControls.CtrlLen, qualityControls.CtrlCurrentCriteria);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Establece que opciones son opcionales
        /// </summary>
        private void SetOptionalQualityControls()
        {
            if (dinamicQualityControlsList.Count > 0)
            {
                foreach (QCControlsClients qualityControls in dinamicQualityControlsList)
                {
                    if (qualityControls.QCValue.Equals(Resources.TicketEmission.Constants.ACTIVE_OPTIONAL))
                    {
                        foreach (Control qcName in this.Controls)
                        {
                            if (qcName is Label)
                            {
                                if (qcName.Text.Equals(qualityControls.QCDescription))
                                {
                                    qcName.ForeColor = Color.DarkCyan;
                                }
                                else if (qcName.Text.Contains("CANTIDADES"))
                                {
                                    qcName.ForeColor = Color.Blue;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Asigna el foco y control de tabulación inicial
        /// </summary>
        private void AssignInitialControl()
        {
            int index = 0;
            bool getFocus = false;
            btnAccept.TabIndex = tabIndex + 1;
            index = btnAccept.TabIndex;
            for (int i = 1; i <= index; i++)
            {
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl.TabIndex == i && ctrl.Enabled)
                    {
                        this.InitialControlFocus = ctrl;
                        ctrl.Focus();
                        getFocus = true;
                        break;
                    }

                }
                if (getFocus)
                    break;
            }

        }

        /// <summary>
        ///Establece color de fondo del primer control en caso de que sea un Textbox
        /// </summary>
        private void InitialControlBackcolor()
        {
            if (this.InitialControlFocus is TextBox)
                this.InitialControlFocus.BackColor = Color.PaleGoldenrod;
        }

        /// <summary>
        /// Crea los controles deacuerdo al tipo establecido en la base de datos por
        /// quality control
        /// </summary>
        /// <param name="controlName">Nombre del control a crear</param>
        /// <param name="x">Posición x del control a crear dentro del user control</param>
        /// <param name="y">Posición y del control a crear dentro del user control</param>
        /// <param name="controlType">Tipo de control a crear</param>
        private void BuildControls(string controlName, int x, int y, string controlType, int lenght, string currentCriteria)
        {

            if (controlType.Equals(Resources.TicketEmission.Constants.QC_CONTROL_TYPE_COMBOBOX))
            {
                ComboBox generic = new ComboBox();
                generic.Name = controlName;
                ListItem item = new ListItem();
                item.Value = string.Empty;
                item.Text = Resources.TicketEmission.Constants.COMBOBOX_FIRST_ITEM_TEXT;
                generic.Items.Add(item);
                generic.Location = new Point(x, y);
                generic.DropDownStyle = ComboBoxStyle.DropDownList;
                generic.TabIndex = tabIndex;
                generic.Width = 250;
                generic.AutoCompleteSource = AutoCompleteSource.ListItems;
                generic.AutoCompleteMode = AutoCompleteMode.Suggest;

                this.Controls.Add(generic);
                qcInputY = y + 30;
                tabIndex++;
            }

            else if (controlType.Equals(Resources.TicketEmission.Constants.QC_CONTROL_TYPE_LABEL))
            {
                Label generic = new Label();
                generic.Name = Resources.TicketEmission.Constants.LABEL_GENERIC_NAME;
                generic.TabIndex = 0;
                generic.Text = controlName;
                generic.Location = new Point(x, y);
                generic.Width = 126;
                this.Controls.Add(generic);
                qcNameY = y + 30;

                btnAccept.Location = new Point(288, verticalPosition);
                verticalPosition = qcNameY + 50;
                if (verticalPosition > this.Height)
                {
                    this.Height = this.Height + 50;
                }

            }
            else if (controlType.Equals(Resources.TicketEmission.Constants.QC_CONTROL_TYPE_TEXTBOX))
            {
                SmartTextBox generic = new SmartTextBox();
                generic.Name = controlName;
                generic.Text = string.Empty;
                generic.Location = new Point(x, y);
                generic.Height = 23;
                generic.Width = 200;
                generic.MaxLength = (!lenght.Equals(null)) ? lenght : 20;
                generic.TabIndex = tabIndex;
                generic.AllowBlankSpaces = true;
                if (currentCriteria == SmartTextBox.CriteriaFields.OnlyNumbers.ToString())
                {
                    generic.CurrentCriteria = SmartTextBox.CriteriaFields.OnlyNumbers;
                }
                else if (currentCriteria == SmartTextBox.CriteriaFields.NumbersOrLetters.ToString())
                {
                    generic.CurrentCriteria = SmartTextBox.CriteriaFields.NumbersOrLetters;
                }
                else if (currentCriteria == SmartTextBox.CriteriaFields.OnlyLetters.ToString())
                {
                    generic.CurrentCriteria = SmartTextBox.CriteriaFields.OnlyLetters;
                }
                this.Controls.Add(generic);
                qcInputY = y + 30;
                tabIndex++;

            }

            else if (controlType.Equals(Resources.TicketEmission.Constants.QC_CONTROL_TYPE_CHECKBOX))
            {
                CheckBox generic = new CheckBox();
                generic.Name = controlName;
                generic.Text = controlName;
                generic.Location = new Point(x, y);
                generic.Width = 200;
                generic.TabIndex = tabIndex;
                this.Controls.Add(generic);
                qcInputY = y + 30;
                tabIndex++;
            }
        }

        /// <summary>
        /// Carga valores iniciales en controles tipo combobox
        /// </summary>
        private void LoadComboboxValues()
        {
            if (dinamicQualityControlsList.Count > 0)
            {
                foreach (QCControlsClients qualityControl in dinamicQualityControlsList)
                {
                    foreach (Control cmbcontrol in this.Controls)
                    {
                        if (cmbcontrol is ComboBox)
                        {
                            if (qualityControl.CtrlName.Equals(cmbcontrol.Name))
                            {
                                if (!string.IsNullOrEmpty(qualityControl.CtrlCatalogues))
                                {
                                    if (qualityControl.CtrlCatalogues.Equals(Resources.TicketEmission.Constants.QC_CATALOGUE_NAME_JUSTIFICATIONS))
                                    {
                                        ActiveInactiveJustifications((ComboBox)cmbcontrol);
                                    }
                                    else if (qualityControl.CtrlCatalogues.Equals(Resources.TicketEmission.Constants.QC_CATALOGUE_NAME_BUSINESSUNITS))
                                    {
                                        LoadBusinessUnit((ComboBox)cmbcontrol);
                                    }
                                    else if (qualityControl.CtrlCatalogues.Equals(Resources.TicketEmission.Constants.QC_CATALOGUE_NAME_SALEORIGIN))
                                    {
                                        LoadSaleOrigin((ComboBox)cmbcontrol);
                                    }
                                    else if (qualityControl.CtrlCatalogues.Equals(Resources.TicketEmission.Constants.QC_CATALOGUE_EVENT_CODE))
                                        if (!ucEndReservation.isFlowHotel)
                                        {
                                            if (ucFirstValidations.dk.Contains("990"))
                                            {
                                                LoadEventCode((ComboBox)cmbcontrol, ucFirstValidations.DK, 1);
                                            }
                                            else
                                            {
                                                LoadEventCode((ComboBox)cmbcontrol, ucFirstValidations.Attribute1, 2);
                                            }
                                        }
                                        else
                                        {
                                            if (ucQCHotels.dk.Contains("990"))
                                            {
                                                LoadEventCode((ComboBox)cmbcontrol, ucQCHotels.DK, 1);
                                            }
                                            else
                                            {
                                                LoadEventCode((ComboBox)cmbcontrol, ucQCHotels.Attribute1, 2);
                                            }
                                        }








                                    else
                                    {
                                        LoadComboBoxCatalog((ComboBox)cmbcontrol, qualityControl.QCId);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Carga de catalogo de justificaciones de tarifa dependiendo del corporativo
        /// </summary>
        private void ActiveInactiveJustifications(ComboBox cmbJustifications)
        {



            if (!dinamicQualityControlsList[9].QCValue.Equals(Resources.TicketEmission.Constants.INACTIVE))
            {

                if ((activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_DANONE) ||
                     activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_DANONE2)) ||
                     activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_RADIUS))
                {
                    LoadJustifications(cmbJustifications);
                }
                else
                {
                    if (!ucComparingFares.sameFare)
                    {
                        cmbJustifications.Enabled = true;
                        LoadJustifications(cmbJustifications);

                    }
                    else
                    {
                        cmbJustifications.Enabled = false;
                    }
                }

            }
            else
            {
                cmbJustifications.Enabled = false;
            }
        }

        /// <summary>
        /// carga de catalogo de justificaciones de tarifa aplicable a cualquier
        /// corporativo que cuente con sus propias justificaciones
        /// </summary>
        private void LoadJustifications(ComboBox cmbJustifications)
        {
            List<DKTemp> Justifications;
            if (!ucEndReservation.isFlowHotel)
                Justifications = DKTempBL.GetDKTemp(ucFirstValidations.Attribute1, false);
            else
                Justifications = DKTempBL.GetDKTemp(ucQCHotels.Attribute1, false);

            bindingSource1.DataSource = Justifications;

            cmbJustifications.DisplayMember = Resources.Constants.TEXT;
            cmbJustifications.ValueMember = Resources.Constants.VALUE;

            foreach (DKTemp justificationsItem in Justifications)
            {
                ListItem litem = new ListItem();
                litem.Text = string.Format("{0} - {1}",
                    justificationsItem.Code,
                    justificationsItem.Description);
                litem.Value = justificationsItem.Description;
                cmbJustifications.Items.Add(litem);
            }
            if (string.IsNullOrEmpty(Justifications[0].Code))
            {
                Justifications.Clear();
                Justifications = DKTempBL.GetDKTemp(Resources.TicketEmission.Constants.DK_CTS_API_100, false);
                bindingSource1.DataSource = Justifications;
                cmbJustifications.Items.Clear();
                cmbJustifications.Items.Add(Resources.TicketEmission.Constants.COMBOBOX_FIRST_ITEM_TEXT);
                cmbJustifications.DisplayMember = Resources.Constants.TEXT;
                cmbJustifications.ValueMember = Resources.Constants.VALUE;

                foreach (DKTemp justificationsItem in Justifications)
                {
                    ListItem litem = new ListItem();
                    litem.Text = string.Format("{0} - {1}",
                        justificationsItem.Code,
                        justificationsItem.Description);
                    litem.Value = justificationsItem.Description;
                    cmbJustifications.Items.Add(litem);
                }
            }
        }

        /// <summary>
        /// Carga de justificaciones de tarifa de CTS aplicables a todo corporativo
        /// que no cuente con sus propias justificaciones
        /// </summary>
        /// <param name="cmbJustifications">combobox respectivo</param>
        private void LoadJustificationsCTS(ComboBox cmbJustifications)
        {
            List<DKTemp> Justifications = DKTempBL.GetDKTemp(Resources.TicketEmission.Constants.DK_CTS_API_100, false);
            bindingSource1.DataSource = Justifications;

            cmbJustifications.DisplayMember = Resources.Constants.TEXT;
            cmbJustifications.ValueMember = Resources.Constants.VALUE;
            cmbJustifications.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach (DKTemp justificationsItem in Justifications)
            {
                ListItem litem = new ListItem();
                litem.Text = string.Format("{0} - {1}",
                    justificationsItem.Code,
                    justificationsItem.Description);
                litem.Value = justificationsItem.Description;
                cmbJustifications.Items.Add(litem);
            }
        }

        /// <summary>
        /// carga datos del catalogo CatBusinessUnits
        /// </summary>
        /// <param name="cmbBusinessUnit"></param>
        private void LoadBusinessUnit(ComboBox cmbBusinessUnit)
        {
            List<CatBusinessUnits> BusinessUnits = CatBusinessUnitsBL.GetBusinessUnits();
            bindingSource2.DataSource = BusinessUnits;
            cmbBusinessUnit.DisplayMember = Resources.Constants.TEXT;
            cmbBusinessUnit.ValueMember = Resources.Constants.VALUE;
            cmbBusinessUnit.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach (CatBusinessUnits businnesUnitItem in BusinessUnits)
            {
                ListItem litem = new ListItem();
                litem.Text = string.Format("{0} {1} {2}",
                    businnesUnitItem.IDIntegra,
                    Resources.TicketEmission.Constants.INDENT,
                    businnesUnitItem.Name);
                litem.Value = string.Concat(businnesUnitItem.IDBusinessUnits,
                    Resources.TicketEmission.Constants.INDENT,
                    businnesUnitItem.IDIntegra);
                cmbBusinessUnit.Items.Add(litem);
            }
        }

        /// <summary>
        /// Carga datos predeterminados al combobox 
        /// </summary>
        /// <param name="cmbSaleOrigin">Combobox respectivo</param>
        private void LoadSaleOrigin(ComboBox cmbSaleOrigin)
        {
            List<CatOriginSales> OriginSales = CatOriginSalesBL.GetOriginSales();
            bindingSource2.DataSource = OriginSales;
            cmbSaleOrigin.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSaleOrigin.DisplayMember = Resources.Constants.TEXT;
            cmbSaleOrigin.ValueMember = Resources.Constants.VALUE;

            foreach (CatOriginSales originSalesItem in OriginSales)
            {
                ListItem litem = new ListItem();
                litem.Text = originSalesItem.Text2;
                litem.Value = originSalesItem.Values;
                cmbSaleOrigin.Items.Add(litem);
            }
        }

        private void LoadEventCode(ComboBox cmbEventCode, string Location, int type)
        {
            List<ListItem> EventCodes = CatEventCodeBL.GetEventCodes(Location, type);
            cmbEventCode.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEventCode.DisplayMember = Resources.Constants.TEXT;
            cmbEventCode.ValueMember = Resources.Constants.VALUE;

            foreach (ListItem eventCodeItem in EventCodes)
            {
                ListItem litem = new ListItem();
                litem.Text = eventCodeItem.Text2;
                litem.Value = eventCodeItem.Value;
                cmbEventCode.Items.Add(litem);
            }
        }

        /// <summary>
        /// Establece el valor inicial de cada combobox creado
        /// </summary>
        private void ComboBoxInitialValue()
        {
            foreach (Control cmbcontrol in this.Controls)
            {
                if (cmbcontrol is ComboBox)
                    ((ComboBox)cmbcontrol).SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Llenado de controles con valores de los remark contables eliminados 
        /// en pasos previos
        /// </summary>
        private void PreviousRemarkICAAVValues()
        {
            bool exitingItem = false;
            foreach (Control txtcontrol in this.Controls)
            {
                if (txtcontrol is TextBox)
                {
                    if (txtcontrol.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_ONE))
                    {
                        if (!activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_SERFSANT) &&
                            !activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_MOVISTAR))
                        {
                            txtcontrol.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C1)) ? ucRemoveRemarks.C1 : string.Empty;
                        }

                    }
                    else if (txtcontrol.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_TWO))
                    {
                        if (!activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_SERFSANT) &&
                            !activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_MOVISTAR))
                        {
                            txtcontrol.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C2)) ? ucRemoveRemarks.C2 : string.Empty;
                        }
                    }
                    else if (txtcontrol.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_THREE))
                    {
                        txtcontrol.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C3)) ? ucRemoveRemarks.C3 : string.Empty;
                    }
                    else if (txtcontrol.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_FOUR))
                    {
                        if (activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.Equals(Resources.TicketEmission.Constants.CORPORATIVE_CFE))
                        {
                            txtcontrol.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C32)) ? ucRemoveRemarks.C32 : string.Empty;
                        }
                        else
                        {
                            txtcontrol.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C4)) ? ucRemoveRemarks.C4 : string.Empty;
                        }

                    }
                    else if (txtcontrol.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_FIVE))
                    {
                        if (activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.Equals(Resources.TicketEmission.Constants.CORPORATIVE_CFE))
                        {
                            txtcontrol.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C4)) ? ucRemoveRemarks.C4 : string.Empty;
                        }
                        else
                        {
                            txtcontrol.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C5)) ? ucRemoveRemarks.C5 : string.Empty;
                        }
                        txtcontrol.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C4)) ? ucRemoveRemarks.C4 : string.Empty;
                    }
                    else if (txtcontrol.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_SIX))
                    {
                        if (!activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_MOVISTAR))
                        {
                            txtcontrol.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C6)) ? ucRemoveRemarks.C6 : string.Empty;
                        }
                        else
                        {
                            txtcontrol.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C24)) ? ucRemoveRemarks.C24 : string.Empty;
                        }
                    }
                    else if (txtcontrol.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_SEVEN))
                    {
                        txtcontrol.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C7)) ? ucRemoveRemarks.C7 : string.Empty;
                    }
                    else if (txtcontrol.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_EIGHT))
                    {
                        txtcontrol.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C8)) ? ucRemoveRemarks.C8 : string.Empty;
                    }
                    else if (txtcontrol.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_NINE))
                    {
                        txtcontrol.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C9)) ? ucRemoveRemarks.C9 : string.Empty;
                    }
                    else if (txtcontrol.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_TWENTY_FOUR))
                    {
                        if (!activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_SERFSANT) &&
                            !activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_MOVISTAR) &&
                            !activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_NATURA))
                        {
                            txtcontrol.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C24)) ? ucRemoveRemarks.C24 : string.Empty;
                        }
                    }
                    else if (txtcontrol.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_TWENTY_FIVE))
                    {
                        txtcontrol.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C24)) ? ucRemoveRemarks.C24 : string.Empty;
                    }
                    else if (txtcontrol.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_TWENTY_SIX))
                    {
                        txtcontrol.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C1)) ? ucRemoveRemarks.C1 : string.Empty;
                    }
                    else if (txtcontrol.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_THIRTY_ONE))
                    {
                        txtcontrol.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C31)) ? ucRemoveRemarks.C31 : string.Empty;
                    }
                    else if (txtcontrol.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_THIRTY_TWO))
                    {
                        if (activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_SERFSANT) ||
                            activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_MOVISTAR))
                        {
                            txtcontrol.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C2)) ? ucRemoveRemarks.C2 : string.Empty;

                        }
                    }
                    else if (txtcontrol.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_THIRTY_NINE))
                    {
                        txtcontrol.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C39)) ? ucRemoveRemarks.C39 : string.Empty;
                    }
                    else if (txtcontrol.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_FORTY))
                    {
                        txtcontrol.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C40)) ? ucRemoveRemarks.C40 : string.Empty;
                    }
                    else if (txtcontrol.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_FORTY_ONE))
                    {
                        txtcontrol.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C41)) ? ucRemoveRemarks.C41 : string.Empty;
                    }
                    else if (txtcontrol.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_FORTY_TWO))
                    {
                        txtcontrol.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C42)) ? ucRemoveRemarks.C42 : string.Empty;
                    }
                    else if (txtcontrol.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_FORTY_FIVE))
                    {
                        if (!activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_MOVISTAR))
                        {
                            txtcontrol.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C45)) ? ucRemoveRemarks.C45 : string.Empty;
                        }
                        else
                        {
                            txtcontrol.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C1)) ? ucRemoveRemarks.C1 : string.Empty;
                        }
                    }
                    else if (txtcontrol.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_FORTY_SIX))
                    {
                        txtcontrol.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C46)) ? ucRemoveRemarks.C46 : string.Empty;
                    }
                    else if (txtcontrol.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_FORTY_SEVEN))
                    {
                        txtcontrol.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C24)) ? ucRemoveRemarks.C24 : string.Empty;
                    }
                    else if (txtcontrol.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_FORTY_EIGHT))
                    {
                        txtcontrol.Text = (!string.IsNullOrEmpty(ucRemoveRemarks.C2)) ? ucRemoveRemarks.C2 : string.Empty;
                    }

                }

            }
            positionOneCF = (!string.IsNullOrEmpty(ucRemoveRemarks.C33)) ? ucRemoveRemarks.C33 : string.Empty;
            positionTwoCF = (!string.IsNullOrEmpty(ucRemoveRemarks.C34)) ? ucRemoveRemarks.C34 : string.Empty;
            positionThreeCF = (!string.IsNullOrEmpty(ucRemoveRemarks.C35)) ? ucRemoveRemarks.C35 : string.Empty;
            positionFourCF = (!string.IsNullOrEmpty(ucRemoveRemarks.C36)) ? ucRemoveRemarks.C36 : string.Empty;

            positionOneCG = (!string.IsNullOrEmpty(ucRemoveRemarks.C37)) ? ucRemoveRemarks.C37 : string.Empty;
            positionTwoCG = (!string.IsNullOrEmpty(ucRemoveRemarks.C38)) ? ucRemoveRemarks.C38 : string.Empty;

            foreach (Control cmbControl in this.Controls)
            {
                if (cmbControl is ComboBox)
                {
                    if (cmbControl.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_THIRTY_THREE))
                    {
                        if (!string.IsNullOrEmpty(positionOneCF))
                        {
                            for (int i = 1; i <= ((ComboBox)cmbControl).Items.Count - 1; i++)
                            {

                                if (((ListItem)((ComboBox)cmbControl).Items[i]).Value.Equals(positionOneCF))
                                {
                                    exitingItem = true;
                                    ((ComboBox)cmbControl).SelectedIndex = i;
                                    break;
                                }
                            }
                            if (!exitingItem)
                            {
                                ((ComboBox)cmbControl).Items.Add(positionOneCF);
                                ((ComboBox)cmbControl).SelectedIndex = ((ComboBox)cmbControl).Items.Count - 1;
                            }

                        }

                    }

                    exitingItem = false;
                    if (cmbControl.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_THIRTY_FOUR))
                    {
                        if (!string.IsNullOrEmpty(positionTwoCF))
                        {
                            for (int i = 1; i <= ((ComboBox)cmbControl).Items.Count - 1; i++)
                            {
                                if (((ListItem)((ComboBox)cmbControl).Items[i]).Value.Equals(positionTwoCF))
                                {
                                    exitingItem = true;
                                    ((ComboBox)cmbControl).SelectedIndex = i;
                                    break;
                                }
                            }
                            if (!exitingItem)
                            {
                                ((ComboBox)cmbControl).Items.Add(positionTwoCF);
                                ((ComboBox)cmbControl).SelectedIndex = ((ComboBox)cmbControl).Items.Count - 1;
                            }

                        }
                    }

                    //
                    exitingItem = false;
                    if (cmbControl.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_THIRTY_FIVE))
                    {
                        if (!string.IsNullOrEmpty(positionThreeCF))
                        {
                            for (int i = 1; i <= ((ComboBox)cmbControl).Items.Count - 1; i++)
                            {
                                if (((ListItem)((ComboBox)cmbControl).Items[i]).Value.Equals(positionThreeCF))
                                {
                                    exitingItem = true;
                                    ((ComboBox)cmbControl).SelectedIndex = i;
                                    break;
                                }
                            }
                            if (!exitingItem)
                            {
                                ((ComboBox)cmbControl).Items.Add(positionThreeCF);
                                ((ComboBox)cmbControl).SelectedIndex = ((ComboBox)cmbControl).Items.Count - 1;
                            }

                        }
                    }

                    //
                    exitingItem = false;
                    if (cmbControl.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_THIRTY_SIX))
                    {
                        if (!string.IsNullOrEmpty(positionFourCF))
                        {
                            for (int i = 1; i <= ((ComboBox)cmbControl).Items.Count - 1; i++)
                            {
                                if (((ListItem)((ComboBox)cmbControl).Items[i]).Value.Equals(positionFourCF))
                                {
                                    exitingItem = true;
                                    ((ComboBox)cmbControl).SelectedIndex = i;
                                    break;
                                }
                            }
                            if (!exitingItem)
                            {
                                ((ComboBox)cmbControl).Items.Add(positionFourCF);
                                ((ComboBox)cmbControl).SelectedIndex = ((ComboBox)cmbControl).Items.Count - 1;
                            }

                        }
                    }

                    //
                    exitingItem = false;
                    if (cmbControl.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_THIRTY_SEVEN))
                    {
                        if (!string.IsNullOrEmpty(positionOneCG))
                        {
                            for (int i = 1; i <= ((ComboBox)cmbControl).Items.Count - 1; i++)
                            {
                                if (((ListItem)((ComboBox)cmbControl).Items[i]).Value.Equals(positionOneCG))
                                {
                                    exitingItem = true;
                                    ((ComboBox)cmbControl).SelectedIndex = i;
                                    break;
                                }
                            }
                            if (!exitingItem)
                            {
                                ((ComboBox)cmbControl).Items.Add(positionOneCG);
                                ((ComboBox)cmbControl).SelectedIndex = ((ComboBox)cmbControl).Items.Count - 1;
                            }

                        }
                    }

                    //
                    exitingItem = false;
                    if (cmbControl.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_THIRTY_EIGHT))
                    {
                        if (!string.IsNullOrEmpty(positionTwoCG))
                        {
                            for (int i = 1; i <= ((ComboBox)cmbControl).Items.Count - 1; i++)
                            {
                                if (((ListItem)((ComboBox)cmbControl).Items[i]).Value.Equals(positionTwoCG))
                                {
                                    exitingItem = true;
                                    ((ComboBox)cmbControl).SelectedIndex = i;
                                    break;
                                }
                            }
                            if (!exitingItem)
                            {
                                ((ComboBox)cmbControl).Items.Add(positionTwoCG);
                                ((ComboBox)cmbControl).SelectedIndex = ((ComboBox)cmbControl).Items.Count - 1;
                            }

                        }
                    }
                }
            }
        }

        /// <summary>
        /// Asigna los eventos necesarios para cada control dinamico
        /// </summary>
        private void ControlEventsAssing()
        {

            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    foreach (QCControlsClients qualityControl in dinamicQualityControlsList)
                    {
                        if (control.Name.Equals(qualityControl.CtrlName) && control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_TWENTY_THREE))
                        {
                            control.KeyDown += new KeyEventHandler(BackEnterUserControlPredictive_KeyDown);
                            control.TextChanged += new EventHandler(txtchargePerService_TextChanged);
                            control.Enter += new EventHandler(txtControl_Enter);
                            control.Leave += new EventHandler(txtControl_Leave);
                        }
                        else if (control.Name.Equals(qualityControl.CtrlName) && !string.IsNullOrEmpty(qualityControl.CtrlCatalogues))
                        {
                            control.KeyDown += new KeyEventHandler(BackEnterUserControlPredictive_KeyDown);
                            control.TextChanged += new EventHandler(txtClientsCatalogs_TextChanged);
                            control.Enter += new EventHandler(txtControl_Enter);
                            control.Leave += new EventHandler(txtControl_Leave);
                        }
                        else if (control.Name.Equals(qualityControl.CtrlName) && string.IsNullOrEmpty(qualityControl.CtrlCatalogues))
                        {
                            control.KeyDown += new KeyEventHandler(BackEnterUserControl_KeyDown);
                            control.Enter += new EventHandler(txtControl_Enter);
                            control.Leave += new EventHandler(txtControl_Leave);
                        }
                    }
                }

                else if (control is ComboBox)
                {
                    control.KeyDown += new KeyEventHandler(BackEnterUserControl_KeyDown);
                    control.Enter += new EventHandler(control_Enter);
                }

                else if (control is CheckBox)
                {
                    control.KeyDown += new KeyEventHandler(BackEnterUserControl_KeyDown);
                    control.Enter += new EventHandler(control_Enter);
                }
            }
        }

        /// <summary>
        /// Reglas de negocio aplicables para esta mascarilla
        /// </summary>
        /// <returns></returns>
        private bool IsValidBusinessRules
        {
            get
            {
                bool isValid = false;
                bool existingItem = false;
                if (dinamicQualityControlsList.Count > 0)
                {
                    foreach (QCControlsClients QCcontrols in dinamicQualityControlsList)
                    {
                        if (QCcontrols.QCValue.Equals(Resources.TicketEmission.Constants.ACTIVE_STRONG) &&
                            QCcontrols.CtrlType.Equals(Resources.TicketEmission.Constants.QC_CONTROL_TYPE_TEXTBOX))
                        {
                            foreach (Control txtcontrol in this.Controls)
                            {
                                if (txtcontrol is TextBox)
                                {
                                    if (!isValid && QCcontrols.CtrlName.Equals(txtcontrol.Name) && string.IsNullOrEmpty(txtcontrol.Text))
                                    {
                                        string message = string.Format(Resources.TicketEmission.Constants.QC_MESSAGE_VALIDATION,
                                            QCcontrols.QCDescription.ToUpper());
                                        MessageBox.Show(message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        txtcontrol.Focus();
                                        isValid = true;

                                    }
                                    else if (!isValid && txtcontrol.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_TWENTY_NINE) &&
                                    !string.IsNullOrEmpty(txtcontrol.Text) && !ValidateRegularExpression.ValidateEmailFormat(txtcontrol.Text))
                                    {

                                        MessageBox.Show("EL CORREO ELECTRÓNICO NO TIENE EL FORMATO CORRECTO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        txtcontrol.Focus();
                                        isValid = true;
                                    }


                                }
                            }
                        }
                        else if (QCcontrols.QCValue.Equals(Resources.TicketEmission.Constants.ACTIVE_OPTIONAL) &&
                        QCcontrols.CtrlType.Equals(Resources.TicketEmission.Constants.QC_CONTROL_TYPE_TEXTBOX))
                        {
                            foreach (Control txtcontrol in this.Controls)
                            {
                                if (txtcontrol is TextBox)
                                {
                                    if (!isValid && txtcontrol.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_TWENTY_THREE) &&
                                    !string.IsNullOrEmpty(txtcontrol.Text) && !ValidateRegularExpression.ValidateCharPerService(txtcontrol.Text))
                                    {

                                        MessageBox.Show("LA CANTIDAD DE CARGO POR SERVICIO DEBE TENER 2 DECIMALES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        txtcontrol.Focus();
                                        isValid = true;
                                    }

                                }
                            }
                        }
                        else if (QCcontrols.QCValue.Equals(Resources.TicketEmission.Constants.ACTIVE_STRONG) &&
                            QCcontrols.CtrlType.Equals(Resources.TicketEmission.Constants.QC_CONTROL_TYPE_COMBOBOX))
                        {
                            foreach (Control cmbcontrol in this.Controls)
                            {
                                existingItem = false;
                                if (cmbcontrol is ComboBox)
                                {
                                    if ((!isValid && QCcontrols.CtrlName.Equals(cmbcontrol.Name) && ((ComboBox)cmbcontrol).SelectedIndex.Equals(0)))
                                    {
                                        if (cmbcontrol.Enabled)
                                        {
                                            string message = string.Format(Resources.TicketEmission.Constants.QC_MESSAGE_VALIDATION,
                                                    QCcontrols.QCDescription.ToUpper());
                                            MessageBox.Show(message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            cmbcontrol.Focus();
                                            isValid = true;
                                            break;
                                        }
                                    }
                                    else if ((!isValid && QCcontrols.CtrlName.Equals(cmbcontrol.Name) && string.IsNullOrEmpty(cmbcontrol.Text)))
                                    {

                                        string message = string.Format(Resources.TicketEmission.Constants.QC_MESSAGE_VALIDATION,
                                                QCcontrols.QCDescription.ToUpper());
                                        MessageBox.Show(message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        cmbcontrol.Focus();
                                        isValid = true;
                                        break;

                                    }
                                    else if (!isValid &&
                                        QCcontrols.CtrlName.Equals(cmbcontrol.Name) &&
                                        QCcontrols.CtrlName.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_TEN) &&
                                        ((ComboBox)cmbcontrol).SelectedIndex < 0)
                                    {
                                        if (cmbcontrol.Enabled)
                                        {
                                            for (int i = 1; i <= ((ComboBox)cmbcontrol).Items.Count - 1; i++)
                                            {

                                                if (((ListItem)((ComboBox)cmbcontrol).Items[i]).Text.StartsWith(cmbcontrol.Text))
                                                {
                                                    existingItem = true;
                                                    ((ComboBox)cmbcontrol).SelectedIndex = i;
                                                    break;
                                                }
                                            }
                                            if (!existingItem)
                                            {
                                                string message = string.Format(Resources.TicketEmission.Tickets.DEBES_INGRESAR_COD_QC_VALIDO,
                                                       QCcontrols.QCDescription.ToUpper());
                                                MessageBox.Show(message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                cmbcontrol.Focus();
                                                isValid = true;
                                                break;
                                            }

                                        }
                                    }
                                    else if (!isValid &&
                                        QCcontrols.CtrlName.Equals(cmbcontrol.Name) &&
                                        QCcontrols.CtrlName.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_TWENTY_ONE) &&
                                        ((ComboBox)cmbcontrol).SelectedIndex < 0)
                                    {
                                        for (int i = 1; i <= ((ComboBox)cmbcontrol).Items.Count - 1; i++)
                                        {

                                            if (((ListItem)((ComboBox)cmbcontrol).Items[i]).Value.Equals(cmbcontrol.Text))
                                            {
                                                existingItem = true;
                                                ((ComboBox)cmbcontrol).SelectedIndex = i;
                                                break;
                                            }
                                        }
                                        if (!existingItem)
                                        {
                                            string message = string.Format(Resources.TicketEmission.Tickets.DEBES_INGRESAR_COD_QC_VALIDO,
                                                   QCcontrols.QCDescription.ToUpper());
                                            MessageBox.Show(message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            cmbcontrol.Focus();
                                            isValid = true;
                                            break;
                                        }
                                    }
                                    else if (!isValid &&
                               QCcontrols.CtrlName.Equals(cmbcontrol.Name) &&
                                         QCcontrols.CtrlName.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_TWENTY_TWO) &&
                                    ((ComboBox)cmbcontrol).SelectedIndex < 0)
                                    {
                                        for (int i = 1; i <= ((ComboBox)cmbcontrol).Items.Count - 1; i++)
                                        {

                                            if (((ListItem)((ComboBox)cmbcontrol).Items[i]).Value.Equals(cmbcontrol.Text))
                                            {
                                                existingItem = true;
                                                ((ComboBox)cmbcontrol).SelectedIndex = i;
                                                break;
                                            }
                                        }
                                        if (!existingItem)
                                        {
                                            string message = string.Format(Resources.TicketEmission.Tickets.DEBES_INGRESAR_COD_QC_VALIDO,
                                                   QCcontrols.QCDescription.ToUpper());
                                            MessageBox.Show(message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            cmbcontrol.Focus();
                                            isValid = true;
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                        if (isValid)
                            break;
                    }
                }

                return isValid;
            }


        }

        /// <summary>
        /// Armado de remark de justificaciones de tarifa
        /// </summary>
        private void JustificationsValues()
        {
            foreach (Control cmbcontrol in this.Controls)
            {
                if (cmbcontrol is ComboBox)
                {
                    if (cmbcontrol.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_TEN))
                    {

                        string send = string.Empty;
                        string optionSelected = cmbcontrol.Text.Substring(0, 2);
                        string Corporative = activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1;
                        if (cmbcontrol.Enabled)
                        {
                            if (Corporative.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_DANONE) ||
                                activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_DANONE2))
                            {
                                send = string.Concat(Resources.TicketEmission.Constants.COMMANDS_5_S_AST_FJ,
                                    optionSelected);
                                foreach (Control chkcontrol in this.Controls)
                                {
                                    if (chkcontrol is CheckBox)
                                    {
                                        if (chkcontrol.Text.Equals(Resources.TicketEmission.Constants.QC_TEN_DANONE_CHK_TEXT))
                                        {
                                            if (((CheckBox)chkcontrol).Checked)
                                            {
                                                send = string.Concat(send,
                                                    Resources.TicketEmission.Constants.COMMANDS_ENDITEM_5_S_AST_TT_INDENT_B);
                                                if (counter.Equals(1))
                                                {
                                                    ticketsjustifications = send;
                                                }
                                            }
                                            else
                                            {
                                                send = string.Concat(send,
                                                    Resources.TicketEmission.Constants.COMMANDS_ENDITEM_5_S_AST_TT_INDENT_C);
                                                if (counter.Equals(1))
                                                {
                                                    ticketsjustifications = send;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else if (Corporative.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_RADIUS))
                            {
                                send = Resources.TicketEmission.Constants.COMMANDS_5_U99_INDENT_RC_SLASH + optionSelected;
                                if (counter.Equals(1))
                                {
                                    ticketsjustifications = send;
                                }
                            }
                            else
                            {
                                send = Resources.TicketEmission.Constants.COMMANDS_5_S_AST_FJ + optionSelected;
                                if (counter.Equals(1))
                                {
                                    ticketsjustifications = send;
                                }
                            }

                            justificationsDescription = cmbcontrol.Text.Substring(5, cmbcontrol.Text.Length - 5);
                            if (!string.IsNullOrEmpty(LabelC10))
                                labelRemarksCValues[9] = LabelC10;
                            else
                                labelRemarksCValues[9] = justificationsDescription;

                            //string Attribute = activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1;
                            //if (!Attribute.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_TLM))
                            //{
                            //    justificationsDescription = cmbcontrol.Text.Substring(5, cmbcontrol.Text.Length - 5);
                            //    labelRemarksCValues[9] = justificationsDescription;
                            //}
                            //else
                            //{
                            //    labelRemarksCValues[9] = cmbcontrol.Text;
                            //}
                        }
                        else
                        {
                            justificationsDescription = string.Empty;
                        }


                    }
                }
            }
        }

        /// <summary>
        /// Armado de comando de unidades operativas para ICAAV e INTEGRA
        /// </summary>
        private void BusinessUnitValues()
        {
            string[] businessValues = null;
            string IDBusinessUnit = string.Empty;
            foreach (Control cmbcontrol in this.Controls)
            {
                if (cmbcontrol is ComboBox)
                {
                    if (cmbcontrol.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_TWENTY_TWO))
                    {
                        if (!((ComboBox)cmbcontrol).SelectedIndex.Equals(0))
                        {
                            IDBusinessUnit = (string.IsNullOrEmpty(cmbcontrol.Text)) ? string.Empty : ((ListItem)((ComboBox)cmbcontrol).SelectedItem).Value;
                            businessValues = IDBusinessUnit.Split(new char[] { '-' });
                            if (counter.Equals(1))
                            {
                                BusinessUnit = string.Concat(Resources.TicketEmission.Constants.COMMANDS_FIVE_DOT_UN_INDENT,
                                    businessValues[0]);
                                BusinessUnit = BusinessUnit.ToUpper();
                            }

                            labelRemarksCValues[21] = businessValues[1];
                            labelRemarksCValues[21] = labelRemarksCValues[21].ToUpper();
                            ListBussinesUnit.Add(cmbcontrol.Text);
                        }
                        else
                        {
                            IDBusinessUnit = string.Empty;
                        }
                    }
                }
            }


        }

        /// <summary>
        /// Arma los remarks correspondientes a ICAAV y asigna los valores correspondientes a los remarks 
        /// de INTEGRA del  quality control origen de la venta
        /// </summary>
        private void SalesOrigin()
        {
            string send = string.Empty;
            string remarkOrigin = string.Empty;
            foreach (Control cmbcontrol in this.Controls)
            {
                if (cmbcontrol is ComboBox)
                {
                    if (!((ComboBox)cmbcontrol).SelectedIndex.Equals(0))
                    {
                        if (cmbcontrol.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_TWENTY_ONE))
                        {
                            send = (string.IsNullOrEmpty(cmbcontrol.Text)) ? string.Empty : string.Concat(send, ((ListItem)((ComboBox)cmbcontrol).SelectedItem).Value);
                            remarkOrigin = (string.IsNullOrEmpty(cmbcontrol.Text)) ? string.Empty : cmbcontrol.Text;
                            break;
                        }
                    }
                    else
                    {
                        send = string.Empty;
                        remarkOrigin = string.Empty;
                    }
                }

            }
            if (counter.Equals(1))
            {
                origin = string.Concat(Resources.TicketEmission.Constants.COMMANDS_FIVE_DOT_OV_INDENT,
                 send);
            }
            originOfSale.Add(labelRemarksCValues[20]);
            labelRemarksCValues[20] = remarkOrigin;
            labelRemarksCValues[20] = labelRemarksCValues[20].ToUpper();
        }

        /// <summary>
        /// Crea los  remarks correspondientes a ICAAV
        /// </summary>
        private void RemarkICAAVValues()
        {
            if (counter.Equals(1))
            {
                string remarkCC = Resources.TicketEmission.Constants.COMMANDS_5_CC_INDENT;
                string remarkCD = Resources.TicketEmission.Constants.COMMANDS_5_CD_INDENT;
                string remarkCE = Resources.TicketEmission.Constants.COMMANDS_5_CE_INDENT;
                string remarkCF = Resources.TicketEmission.Constants.COMMANDS_5_CF_INDENT;
                string remarkCG = Resources.TicketEmission.Constants.COMMANDS_5_CG_INDENT;
                string remarkCH = Resources.TicketEmission.Constants.COMMANDS_5_CH_INDENT;

                string positionOneCC = Resources.TicketEmission.Constants.Zero;
                string positionTwoCC = Resources.TicketEmission.Constants.Zero;
                string positionThreeCC = Resources.TicketEmission.Constants.Zero;
                string positionFourCC = Resources.TicketEmission.Constants.Zero;

                string positionOneCD = Resources.TicketEmission.Constants.Zero;
                string positionTwoCD = Resources.TicketEmission.Constants.Zero;
                string positionThreeCD = Resources.TicketEmission.Constants.Zero;
                string positionFourCD = Resources.TicketEmission.Constants.Zero;

                string positionOneCE = Resources.TicketEmission.Constants.Zero;
                string positionTwoCE = Resources.TicketEmission.Constants.Zero;
                string positionThreeCE = Resources.TicketEmission.Constants.Zero;
                string positionFourCE = Resources.TicketEmission.Constants.Zero;

                string positionThreeCG = Resources.TicketEmission.Constants.Zero;
                string positionFourCG = Resources.TicketEmission.Constants.Zero;

                string positionOneCH = Resources.TicketEmission.Constants.Zero;
                string positionTwoCH = Resources.TicketEmission.Constants.Zero;
                string positionThreeCH = Resources.TicketEmission.Constants.Zero;
                string positionFourCH = Resources.TicketEmission.Constants.Zero;

                foreach (Control control in this.Controls)
                {
                    if (control is TextBox)
                    {
                        if (control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_THREE))
                        {
                            positionOneCC = (!string.IsNullOrEmpty(control.Text)) ? control.Text : Resources.TicketEmission.Constants.Zero;
                        }
                        else if (control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_TWO))
                        {
                            if (!activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_SERFSANT) ||
                                !activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_MOVISTAR))
                            {
                                positionTwoCC = (!string.IsNullOrEmpty(control.Text)) ? control.Text : Resources.TicketEmission.Constants.Zero;
                            }

                        }
                        else if (control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_ONE))
                        {
                            if (!activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_SERFSANT) ||
                               !activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_MOVISTAR))
                            {
                                positionThreeCC = (!string.IsNullOrEmpty(control.Text)) ? control.Text : Resources.TicketEmission.Constants.Zero;
                            }

                        }
                        else if (control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_TWENTY_FOUR))
                        {
                            if (!activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_SERFSANT) ||
                               !activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_MOVISTAR) ||
                               !activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_NATURA))
                            {
                                positionFourCC = (!string.IsNullOrEmpty(control.Text)) ? control.Text : Resources.TicketEmission.Constants.Zero;
                            }

                        }
                        else if (control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_TWENTY_FIVE))
                        {
                            positionFourCC = (!string.IsNullOrEmpty(control.Text)) ? control.Text : Resources.TicketEmission.Constants.Zero;
                        }
                        else if (control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_TWENTY_SIX))
                        {
                            positionThreeCC = (!string.IsNullOrEmpty(control.Text)) ? control.Text : Resources.TicketEmission.Constants.Zero;
                        }
                        //else if (control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_TWENTY_SEVEN))
                        //{
                        //    positionTwoCC = (!string.IsNullOrEmpty(control.Text)) ? control.Text : Resources.TicketEmission.Constants.Zero;
                        //}
                        else if (control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_NINE))
                        {
                            positionOneCD = (!string.IsNullOrEmpty(control.Text)) ? control.Text : Resources.TicketEmission.Constants.Zero;
                        }
                        else if (control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_THIRTY_ONE))
                        {
                            positionTwoCD = (!string.IsNullOrEmpty(control.Text)) ? control.Text : Resources.TicketEmission.Constants.Zero;
                        }
                        else if (control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_FOUR))
                        {
                            positionThreeCD = (!string.IsNullOrEmpty(control.Text)) ? control.Text : Resources.TicketEmission.Constants.Zero;
                        }
                        else if (control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_THIRTY_TWO))
                        {
                            if (!activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_SERFSANT) &&
                              !activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_MOVISTAR))
                            {
                                positionFourCD = (!string.IsNullOrEmpty(control.Text)) ? control.Text : Resources.TicketEmission.Constants.Zero;
                            }
                            else
                            {
                                positionTwoCC = (!string.IsNullOrEmpty(control.Text)) ? control.Text : Resources.TicketEmission.Constants.Zero;
                            }

                        }

                        else if (control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_FIVE))
                        {
                            positionOneCE = (!string.IsNullOrEmpty(control.Text)) ? control.Text : Resources.TicketEmission.Constants.Zero;
                        }
                        else if (control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_SIX))
                        {
                            positionTwoCE = (!string.IsNullOrEmpty(control.Text)) ? control.Text : Resources.TicketEmission.Constants.Zero;

                        }
                        else if (control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_SEVEN))
                        {
                            positionThreeCE = (!string.IsNullOrEmpty(control.Text)) ? control.Text : Resources.TicketEmission.Constants.Zero;
                        }
                        else if (control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_EIGHT))
                        {
                            positionFourCE = (!string.IsNullOrEmpty(control.Text)) ? control.Text : Resources.TicketEmission.Constants.Zero;
                        }

                        else if (control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_THIRTY_NINE))
                        {
                            positionThreeCG = (!string.IsNullOrEmpty(control.Text)) ? control.Text : Resources.TicketEmission.Constants.Zero;
                        }
                        else if (control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_FORTY))
                        {
                            positionFourCG = (!string.IsNullOrEmpty(control.Text)) ? control.Text : Resources.TicketEmission.Constants.Zero;
                        }
                        else if (control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_FORTY_ONE))
                        {
                            positionOneCH = (!string.IsNullOrEmpty(control.Text)) ? control.Text : Resources.TicketEmission.Constants.Zero;
                        }
                        else if (control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_FORTY_TWO))
                        {
                            positionTwoCH = (!string.IsNullOrEmpty(control.Text)) ? control.Text : Resources.TicketEmission.Constants.Zero;
                        }
                        else if (control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_FORTY_FIVE))
                        {
                            if (!activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.Equals(Resources.TicketEmission.Constants.CORPORATIVEID_NATURA))
                            {
                                positionThreeCH = (!string.IsNullOrEmpty(control.Text)) ? control.Text : Resources.TicketEmission.Constants.Zero;
                            }
                            else
                            {
                                positionThreeCC = (!string.IsNullOrEmpty(control.Text)) ? control.Text : Resources.TicketEmission.Constants.Zero;
                            }
                        }
                        else if (control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_FORTY_SIX))
                        {
                            positionFourCH = (!string.IsNullOrEmpty(control.Text)) ? control.Text : Resources.TicketEmission.Constants.Zero;
                        }
                        //else if (control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_FORTY_THREE))
                        //{
                        //    positionThreeCC = (!string.IsNullOrEmpty(control.Text)) ? control.Text : Resources.TicketEmission.Constants.Zero;
                        //}
                        else if (control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_FORTY_SEVEN))
                        {
                            positionFourCC = (!string.IsNullOrEmpty(control.Text)) ? control.Text : Resources.TicketEmission.Constants.Zero;
                        }
                        else if (control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_FORTY_EIGHT))
                        {
                            positionTwoCC = (!string.IsNullOrEmpty(control.Text)) ? control.Text : Resources.TicketEmission.Constants.Zero;
                        }

                    }

                    else if (control is ComboBox)
                    {
                        if (control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_THIRTY_THREE))
                        {
                            if (string.IsNullOrEmpty(positionOneCF) || !string.IsNullOrEmpty(control.Text))
                                try
                                {
                                    positionOneCF = (((ComboBox)control).SelectedIndex != 0) ? control.Text.Substring(0, (control.Text.IndexOf("-"))).Trim() : Resources.TicketEmission.Constants.Zero;
                                }
                                catch
                                {
                                    positionOneCF = (((ComboBox)control).SelectedIndex != 0) ? control.Text : Resources.TicketEmission.Constants.Zero;
                                }
                        }
                        else if (control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_THIRTY_FOUR))
                        {
                            if (string.IsNullOrEmpty(positionTwoCF) || !string.IsNullOrEmpty(control.Text))
                                try
                                {
                                    positionTwoCF = (((ComboBox)control).SelectedIndex != 0) ? control.Text.Substring(0, (control.Text.IndexOf("-"))).Trim() : Resources.TicketEmission.Constants.Zero;
                                }
                                catch
                                {
                                    positionTwoCF = (((ComboBox)control).SelectedIndex != 0) ? control.Text : Resources.TicketEmission.Constants.Zero;
                                }
                        }
                        else if (control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_THIRTY_FIVE))
                        {
                            if (string.IsNullOrEmpty(positionThreeCF) || !string.IsNullOrEmpty(control.Text))
                            {
                                try
                                {
                                    positionThreeCF = (((ComboBox)control).SelectedIndex != 0) ? control.Text.Substring(0, (control.Text.IndexOf("-"))).Trim() : Resources.TicketEmission.Constants.Zero;
                                }
                                catch
                                {
                                    positionThreeCF = (((ComboBox)control).SelectedIndex != 0) ? control.Text : Resources.TicketEmission.Constants.Zero;
                                }
                            }
                        }
                        else if (control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_THIRTY_SIX))
                        {
                            if (string.IsNullOrEmpty(positionFourCF) || !string.IsNullOrEmpty(control.Text))
                                try
                                {
                                    positionFourCF = (((ComboBox)control).SelectedIndex != 0) ? control.Text.Substring(0, (control.Text.IndexOf("-"))).Trim() : Resources.TicketEmission.Constants.Zero;
                                }
                                catch
                                {
                                    positionFourCF = (((ComboBox)control).SelectedIndex != 0) ? control.Text : Resources.TicketEmission.Constants.Zero;
                                }
                        }
                        else if (control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_THIRTY_SEVEN))
                        {
                            if (string.IsNullOrEmpty(positionOneCG) || !string.IsNullOrEmpty(control.Text))
                                try
                                {
                                    positionOneCG = (((ComboBox)control).SelectedIndex != 0) ? control.Text.Substring(0, (control.Text.IndexOf("-"))).Trim() : Resources.TicketEmission.Constants.Zero;
                                }
                                catch
                                {
                                    positionOneCG = (((ComboBox)control).SelectedIndex != 0) ? control.Text : Resources.TicketEmission.Constants.Zero;
                                }
                        }
                        else if (control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_THIRTY_EIGHT))
                        {
                            if (string.IsNullOrEmpty(positionTwoCG) || !string.IsNullOrEmpty(control.Text))
                                try
                                {
                                    positionTwoCG = (((ComboBox)control).SelectedIndex != 0) ? control.Text.Substring(0, (control.Text.IndexOf("-"))).Trim() : Resources.TicketEmission.Constants.Zero;
                                }
                                catch
                                {
                                    positionTwoCG = (((ComboBox)control).SelectedIndex != 0) ? control.Text : Resources.TicketEmission.Constants.Zero;
                                }
                        }
                    }
                }


                if (string.IsNullOrEmpty(positionOneCF))
                    positionOneCF = Resources.TicketEmission.Constants.Zero;

                if (string.IsNullOrEmpty(positionTwoCF))
                    positionTwoCF = Resources.TicketEmission.Constants.Zero;

                if (string.IsNullOrEmpty(positionThreeCF))
                    positionThreeCF = Resources.TicketEmission.Constants.Zero;

                if (string.IsNullOrEmpty(positionFourCF))
                    positionFourCF = Resources.TicketEmission.Constants.Zero;

                if (string.IsNullOrEmpty(positionOneCG))
                    positionOneCG = Resources.TicketEmission.Constants.Zero;

                if (string.IsNullOrEmpty(positionTwoCG))
                    positionTwoCG = Resources.TicketEmission.Constants.Zero;


                if (positionThreeCC.Equals(Resources.TicketEmission.Constants.Zero))
                    positionThreeCC = (!string.IsNullOrEmpty(ucRemoveRemarks.C1)) ? ucRemoveRemarks.C1 : Resources.TicketEmission.Constants.Zero;

                if (positionTwoCC.Equals(Resources.TicketEmission.Constants.Zero))
                    positionTwoCC = (!string.IsNullOrEmpty(ucRemoveRemarks.C2)) ? ucRemoveRemarks.C2 : Resources.TicketEmission.Constants.Zero;

                if (positionOneCC.Equals(Resources.TicketEmission.Constants.Zero))
                    positionOneCC = (!string.IsNullOrEmpty(ucRemoveRemarks.C3)) ? ucRemoveRemarks.C3 : Resources.TicketEmission.Constants.Zero;

                if (positionThreeCD.Equals(Resources.TicketEmission.Constants.Zero))
                    positionThreeCD = (!string.IsNullOrEmpty(ucRemoveRemarks.C4)) ? ucRemoveRemarks.C4 : Resources.TicketEmission.Constants.Zero;

                if (positionOneCE.Equals(Resources.TicketEmission.Constants.Zero))
                    positionOneCE = (!string.IsNullOrEmpty(ucRemoveRemarks.C5)) ? ucRemoveRemarks.C5 : Resources.TicketEmission.Constants.Zero;

                if (positionTwoCE.Equals(Resources.TicketEmission.Constants.Zero))
                    positionTwoCE = (!string.IsNullOrEmpty(ucRemoveRemarks.C6)) ? ucRemoveRemarks.C6 : Resources.TicketEmission.Constants.Zero;

                if (positionThreeCE.Equals(Resources.TicketEmission.Constants.Zero))
                    positionThreeCE = (!string.IsNullOrEmpty(ucRemoveRemarks.C7)) ? ucRemoveRemarks.C7 : Resources.TicketEmission.Constants.Zero;

                if (positionFourCE.Equals(Resources.TicketEmission.Constants.Zero))
                    positionFourCE = (!string.IsNullOrEmpty(ucRemoveRemarks.C8)) ? ucRemoveRemarks.C8 : Resources.TicketEmission.Constants.Zero;

                if (positionOneCD.Equals(Resources.TicketEmission.Constants.Zero))
                    positionOneCD = (!string.IsNullOrEmpty(ucRemoveRemarks.C9)) ? ucRemoveRemarks.C9 : Resources.TicketEmission.Constants.Zero;

                if (positionFourCC.Equals(Resources.TicketEmission.Constants.Zero))
                    positionFourCC = (!string.IsNullOrEmpty(ucRemoveRemarks.C24)) ? ucRemoveRemarks.C24 : Resources.TicketEmission.Constants.Zero;

                if (positionTwoCD.Equals(Resources.TicketEmission.Constants.Zero))
                    positionTwoCD = (!string.IsNullOrEmpty(ucRemoveRemarks.C31)) ? ucRemoveRemarks.C31 : Resources.TicketEmission.Constants.Zero;

                if (positionFourCD.Equals(Resources.TicketEmission.Constants.Zero))
                    positionFourCD = (!string.IsNullOrEmpty(ucRemoveRemarks.C32)) ? ucRemoveRemarks.C32 : Resources.TicketEmission.Constants.Zero;

                if (positionOneCF.Equals(Resources.TicketEmission.Constants.Zero))
                    positionOneCF = (!string.IsNullOrEmpty(ucRemoveRemarks.C33)) ? ucRemoveRemarks.C33 : Resources.TicketEmission.Constants.Zero;

                if (positionTwoCF.Equals(Resources.TicketEmission.Constants.Zero))
                    positionTwoCF = (!string.IsNullOrEmpty(ucRemoveRemarks.C34)) ? ucRemoveRemarks.C34 : Resources.TicketEmission.Constants.Zero;

                if (positionThreeCF.Equals(Resources.TicketEmission.Constants.Zero))
                    positionThreeCF = (!string.IsNullOrEmpty(ucRemoveRemarks.C35)) ? ucRemoveRemarks.C35 : Resources.TicketEmission.Constants.Zero;

                if (positionFourCF.Equals(Resources.TicketEmission.Constants.Zero))
                    positionFourCF = (!string.IsNullOrEmpty(ucRemoveRemarks.C36)) ? ucRemoveRemarks.C36 : Resources.TicketEmission.Constants.Zero;

                if (positionOneCG.Equals(Resources.TicketEmission.Constants.Zero))
                    positionOneCG = (!string.IsNullOrEmpty(ucRemoveRemarks.C37)) ? ucRemoveRemarks.C37 : Resources.TicketEmission.Constants.Zero;

                if (positionTwoCG.Equals(Resources.TicketEmission.Constants.Zero))
                    positionTwoCG = (!string.IsNullOrEmpty(ucRemoveRemarks.C38)) ? ucRemoveRemarks.C38 : Resources.TicketEmission.Constants.Zero;

                if (positionThreeCG.Equals(Resources.TicketEmission.Constants.Zero))
                    positionThreeCG = (!string.IsNullOrEmpty(ucRemoveRemarks.C39)) ? ucRemoveRemarks.C39 : Resources.TicketEmission.Constants.Zero;

                if (positionFourCG.Equals(Resources.TicketEmission.Constants.Zero))
                    positionFourCG = (!string.IsNullOrEmpty(ucRemoveRemarks.C40)) ? ucRemoveRemarks.C40 : Resources.TicketEmission.Constants.Zero;

                if (positionOneCH.Equals(Resources.TicketEmission.Constants.Zero))
                    positionOneCH = (!string.IsNullOrEmpty(ucRemoveRemarks.C41)) ? ucRemoveRemarks.C41 : Resources.TicketEmission.Constants.Zero;

                if (positionTwoCH.Equals(Resources.TicketEmission.Constants.Zero))
                    positionTwoCH = (!string.IsNullOrEmpty(ucRemoveRemarks.C42)) ? ucRemoveRemarks.C42 : Resources.TicketEmission.Constants.Zero;

                if (positionThreeCH.Equals(Resources.TicketEmission.Constants.Zero))
                    positionThreeCH = (!string.IsNullOrEmpty(ucRemoveRemarks.C45)) ? ucRemoveRemarks.C45 : Resources.TicketEmission.Constants.Zero;

                if (positionFourCH.Equals(Resources.TicketEmission.Constants.Zero))
                    positionFourCH = (!string.IsNullOrEmpty(ucRemoveRemarks.C46)) ? ucRemoveRemarks.C46 : Resources.TicketEmission.Constants.Zero;



                if (positionOneCC.Equals(Resources.TicketEmission.Constants.Zero) &&
                    positionTwoCC.Equals(Resources.TicketEmission.Constants.Zero) &&
                    positionThreeCC.Equals(Resources.TicketEmission.Constants.Zero) &&
                    positionFourCC.Equals(Resources.TicketEmission.Constants.Zero))
                {
                    icaavremarkcc = string.Empty;
                }
                else
                {
                    icaavremarkcc = string.Concat(remarkCC,
                        positionOneCC,
                        Resources.TicketEmission.Constants.INDENT,
                        positionTwoCC,
                        Resources.TicketEmission.Constants.INDENT,
                        positionThreeCC,
                        Resources.TicketEmission.Constants.INDENT,
                        positionFourCC);
                }

                if (positionOneCD.Equals(Resources.TicketEmission.Constants.Zero) &&
                    positionTwoCD.Equals(Resources.TicketEmission.Constants.Zero) &&
                    positionThreeCD.Equals(Resources.TicketEmission.Constants.Zero) &&
                    positionFourCD.Equals(Resources.TicketEmission.Constants.Zero))
                {
                    icaavremarkcd = string.Empty;
                }
                else
                {
                    icaavremarkcd = string.Concat(remarkCD,
                        positionOneCD,
                        Resources.TicketEmission.Constants.INDENT,
                        positionTwoCD,
                        Resources.TicketEmission.Constants.INDENT,
                        positionThreeCD,
                        Resources.TicketEmission.Constants.INDENT,
                        positionFourCD);
                }

                if (positionOneCE.Equals(Resources.TicketEmission.Constants.Zero) &&
                    positionTwoCE.Equals(Resources.TicketEmission.Constants.Zero) &&
                    positionThreeCE.Equals(Resources.TicketEmission.Constants.Zero) &&
                    positionFourCE.Equals(Resources.TicketEmission.Constants.Zero))
                {
                    icaavremarkce = string.Empty;
                }
                else
                {
                    icaavremarkce = string.Concat(remarkCE,
                        positionOneCE,
                        Resources.TicketEmission.Constants.INDENT,
                        positionTwoCE,
                        Resources.TicketEmission.Constants.INDENT,
                        positionThreeCE,
                        Resources.TicketEmission.Constants.INDENT,
                        positionFourCE);
                }

                if (positionOneCF.Equals(Resources.TicketEmission.Constants.Zero) &&
                    positionTwoCF.Equals(Resources.TicketEmission.Constants.Zero) &&
                    positionThreeCF.Equals(Resources.TicketEmission.Constants.Zero) &&
                    positionFourCF.Equals(Resources.TicketEmission.Constants.Zero))
                {
                    icaavremarkcf = string.Empty;
                }
                else
                {
                    icaavremarkcf = string.Concat(remarkCF,
                        positionOneCF,
                        Resources.TicketEmission.Constants.INDENT,
                        positionTwoCF,
                        Resources.TicketEmission.Constants.INDENT,
                        positionThreeCF,
                        Resources.TicketEmission.Constants.INDENT,
                        positionFourCF);
                }

                if (positionOneCG.Equals(Resources.TicketEmission.Constants.Zero) &&
                    positionTwoCG.Equals(Resources.TicketEmission.Constants.Zero) &&
                    positionThreeCG.Equals(Resources.TicketEmission.Constants.Zero) &&
                    positionFourCG.Equals(Resources.TicketEmission.Constants.Zero))
                {
                    icaavremarkcg = string.Empty;
                }
                else
                {
                    icaavremarkcg = string.Concat(remarkCG,
                        positionOneCG,
                        Resources.TicketEmission.Constants.INDENT,
                        positionTwoCG,
                        Resources.TicketEmission.Constants.INDENT,
                        positionThreeCG,
                        Resources.TicketEmission.Constants.INDENT,
                        positionFourCG);
                }

                if (positionOneCH.Equals(Resources.TicketEmission.Constants.Zero) &&
                    positionTwoCH.Equals(Resources.TicketEmission.Constants.Zero) &&
                    positionThreeCH.Equals(Resources.TicketEmission.Constants.Zero) &&
                    positionFourCH.Equals(Resources.TicketEmission.Constants.Zero))
                {
                    icaavremarkch = string.Empty;
                }
                else
                {
                    icaavremarkch = string.Concat(remarkCH,
                        positionOneCH,
                        Resources.TicketEmission.Constants.INDENT,
                        positionTwoCH,
                        Resources.TicketEmission.Constants.INDENT,
                        positionThreeCH,
                        Resources.TicketEmission.Constants.INDENT,
                        positionFourCH);
                }

            }

            foreach (Control control in Controls)
            {
                if (control is TextBox && control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_TWENTY_THREE))
                {
                    if (counter <= 9)
                    {
                        try
                        {
                            try
                            {
                                chargePerService[counter - 1] = (!string.IsNullOrEmpty(control.Text)) ? string.Format(Resources.TicketEmission.Constants.COMMANDS_5_DOT_CS0_AGENT_AGENT, paxNumberLabel[counter - 1].Substring(0, 1), control.Text) : string.Empty;
                            }
                            catch
                            {
                                chargePerService[counter - 1] = (!string.IsNullOrEmpty(control.Text)) ? string.Format(Resources.TicketEmission.Constants.COMMANDS_5_DOT_CS0_AGENT_AGENT, counter, control.Text) : string.Empty;
                            }

                        }
                        catch
                        {
                            try
                            {
                                chargePerService.Add((!string.IsNullOrEmpty(control.Text)) ? string.Format(Resources.TicketEmission.Constants.COMMANDS_5_DOT_CS0_AGENT_AGENT, paxNumberLabel[counter - 1].Substring(0, 1), control.Text) : string.Empty);
                            }
                            catch
                            {
                                chargePerService.Add((!string.IsNullOrEmpty(control.Text)) ? string.Format(Resources.TicketEmission.Constants.COMMANDS_5_DOT_CS0_AGENT_AGENT, counter, control.Text) : string.Empty);
                            }
                        }

                    }
                    else
                        try
                        {
                            chargePerService[counter - 1] = (!string.IsNullOrEmpty(control.Text)) ? string.Format(Resources.TicketEmission.Constants.COMMANDS_5_DOT_CS_AGENT_AGENT, counter, control.Text) : string.Empty;
                        }
                        catch
                        {
                            chargePerService.Add((!string.IsNullOrEmpty(control.Text)) ? string.Format(Resources.TicketEmission.Constants.COMMANDS_5_DOT_CS_AGENT_AGENT, counter, control.Text) : string.Empty);
                        }
                }

                else if (control is TextBox && control.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_SIX))
                {


                    if (counter <= 9)
                    {
                        try
                        {
                            try
                            {
                                workerNumberArray[counter - 1] = (!string.IsNullOrEmpty(control.Text)) ? string.Format(Resources.TicketEmission.Constants.COMMANDS_5_DOT_TL_INDENT_N0_AGENT_SLASH_AGENT, paxNumberLabel[counter - 1].Substring(0, 1), control.Text) : string.Empty;
                            }
                            catch
                            {
                                workerNumberArray[counter - 1] = (!string.IsNullOrEmpty(control.Text)) ? string.Format(Resources.TicketEmission.Constants.COMMANDS_5_DOT_TL_INDENT_N0_AGENT_SLASH_AGENT, counter, control.Text) : string.Empty;
                            }
                        }
                        catch
                        {
                            try
                            {
                                workerNumberArray.Add((!string.IsNullOrEmpty(control.Text)) ? string.Format(Resources.TicketEmission.Constants.COMMANDS_5_DOT_TL_INDENT_N0_AGENT_SLASH_AGENT, paxNumberLabel[counter - 1].Substring(0, 1), control.Text) : string.Empty);
                            }
                            catch
                            {
                                workerNumberArray.Add((!string.IsNullOrEmpty(control.Text)) ? string.Format(Resources.TicketEmission.Constants.COMMANDS_5_DOT_TL_INDENT_N0_AGENT_SLASH_AGENT, counter, control.Text) : string.Empty);
                            }
                        }


                    }
                    else
                    {
                        try
                        {
                            workerNumberArray[counter - 1] = (!string.IsNullOrEmpty(control.Text)) ? string.Format(Resources.TicketEmission.Constants.COMMANDS_5_DOT_TL_INDENT_N_AGENT_SLASH_AGENT, counter, control.Text) : string.Empty;
                        }
                        catch
                        {
                            workerNumberArray.Add((!string.IsNullOrEmpty(control.Text)) ? string.Format(Resources.TicketEmission.Constants.COMMANDS_5_DOT_TL_INDENT_N_AGENT_SLASH_AGENT, counter, control.Text) : string.Empty);
                        }

                    }
                }
            }

        }

        /// <summary>
        /// Carga de valores en variables estaticas para la creacion 
        /// de remarks INTEGRA
        /// </summary>
        private void RemarkIntegraValues()
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox)
                {
                    for (int i = 0; i < labelRemarksCValues.Length; i++)
                    {
                        if (control.Name.Equals("txtC" + Convert.ToString(i + 1)))
                        {

                            if (!string.IsNullOrEmpty(control.Text))
                            {
                                labelRemarksCValues[i] = control.Text.ToUpper();
                                InsertNewValues(control);
                            }
                            else
                                labelRemarksCValues[i] = string.Empty;
                        }

                    }
                }

                else if (control is ComboBox)
                {
                    if (control.Enabled)
                    {
                        for (int i = 0; i < labelRemarksCValues.Length; i++)
                        {
                            if (control.Name.Equals("cmbC" + Convert.ToString(i + 1)))
                            {
                                if (((ComboBox)control).SelectedIndex > 0 && !string.IsNullOrEmpty(((ComboBox)control).Text))
                                {
                                    if (((ComboBox)control).Text.Contains("-"))
                                    {
                                        string[] codevalue = ((ComboBox)control).Text.ToUpper().Split(new char[] { '-' });
                                        codevalue[0] = codevalue[0].TrimEnd();
                                        labelRemarksCValues[i] = codevalue[0];
                                        InsertNewValues(control);
                                    }
                                    else
                                    {
                                        if (((ListItem)((ComboBox)control).SelectedItem).Value != null)
                                        {
                                            labelRemarksCValues[i] = ((ListItem)((ComboBox)control).SelectedItem).Value.ToString();
                                            InsertNewValues(control);
                                        }

                                    }
                                }
                                else
                                {
                                    labelRemarksCValues[i] = string.Empty;
                                }
                            }
                        }
                    }
                }
            }

            labelRemarksCValues[10] = (string.IsNullOrEmpty(ucComparisonRates.rate_ConImp_Low_D)) ? string.Empty : (ucComparisonRates.rate_ConImp_Low_D.Equals(Resources.Constants.ZERO)) ? ucRatingActualFare.fareWithTaxesSold : ucComparisonRates.rate_ConImp_Low_D;
            labelRemarksCValues[11] = (string.IsNullOrEmpty(ucComparisonRates.rate_ConImp_Low_ND)) ? string.Empty : (ucComparisonRates.rate_ConImp_Low_ND.Equals(Resources.Constants.ZERO)) ? ucRatingActualFare.fareWithTaxesSold : ucComparisonRates.rate_ConImp_Low_ND;
            labelRemarksCValues[12] = (string.IsNullOrEmpty(ucComparisonRates.rate_ConImp_Busi)) ? string.Empty : (ucComparisonRates.rate_ConImp_Busi.Equals(Resources.Constants.ZERO)) ? ucRatingActualFare.fareWithTaxesSold : ucComparisonRates.rate_ConImp_Busi;
            labelRemarksCValues[13] = (string.IsNullOrEmpty(ucComparisonRates.rate_ConImp_Espe)) ? string.Empty : (ucComparisonRates.rate_ConImp_Espe.Equals(Resources.Constants.ZERO)) ? ucRatingActualFare.fareWithTaxesSold : ucComparisonRates.rate_ConImp_Espe;
            labelRemarksCValues[14] = (string.IsNullOrEmpty(ucComparisonRates.rate_ConImp_Stan)) ? string.Empty : (ucComparisonRates.rate_ConImp_Stan.Equals(Resources.Constants.ZERO)) ? ucRatingActualFare.fareWithTaxesSold : ucComparisonRates.rate_ConImp_Stan;
            labelRemarksCValues[15] = (string.IsNullOrEmpty(ucComparisonRates.rate_SinImp_Low_D)) ? string.Empty : (ucComparisonRates.rate_SinImp_Low_D.Equals(Resources.Constants.ZERO)) ? ucRatingActualFare.fareWithoutTaxesSold : ucComparisonRates.rate_SinImp_Low_D;
            labelRemarksCValues[16] = (string.IsNullOrEmpty(ucComparisonRates.rate_SinImp_Low_ND)) ? string.Empty : (ucComparisonRates.rate_SinImp_Low_ND.Equals(Resources.Constants.ZERO)) ? ucRatingActualFare.fareWithoutTaxesSold : ucComparisonRates.rate_SinImp_Low_ND;
            labelRemarksCValues[17] = (string.IsNullOrEmpty(ucComparisonRates.rate_SinImp_Busi)) ? string.Empty : (ucComparisonRates.rate_SinImp_Busi.Equals(Resources.Constants.ZERO)) ? ucRatingActualFare.fareWithoutTaxesSold : ucComparisonRates.rate_SinImp_Busi;
            labelRemarksCValues[18] = (string.IsNullOrEmpty(ucComparisonRates.rate_SinImp_Espe)) ? string.Empty : (ucComparisonRates.rate_SinImp_Espe.Equals(Resources.Constants.ZERO)) ? ucRatingActualFare.fareWithoutTaxesSold : ucComparisonRates.rate_SinImp_Espe;
            labelRemarksCValues[19] = (string.IsNullOrEmpty(ucComparisonRates.rate_SinImp_Stan)) ? string.Empty : (ucComparisonRates.rate_SinImp_Stan.Equals(Resources.Constants.ZERO)) ? ucRatingActualFare.fareWithoutTaxesSold : ucComparisonRates.rate_SinImp_Stan;

            if (!string.IsNullOrEmpty(labelRemarksCValues[22]))
            {

                List<ChargePerService> chargePerServiceList = ChargePerServiceBL.GetChargePerService(labelRemarksCValues[22]);
                if (!chargePerServiceList.Count.Equals(0))
                {
                    labelRemarksCValues[22] = chargePerServiceList[0].Import;
                    labelRemarksCValues[22] = labelRemarksCValues[22].Replace("$", "");
                    if (!string.IsNullOrEmpty(labelRemarksCValues[22]))
                    {
                        labelRemarksCValues[22] = labelRemarksCValues[22].Remove(0, 1).ToUpper();
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(labelRemarksCValues[22]))
                    {
                        labelRemarksCValues[22] = labelRemarksCValues[22].Replace("$", "");
                    }
                    else
                    {
                        labelRemarksCValues[22] = string.Empty;
                    }
                }

            }
            else
            {
                labelRemarksCValues[22] = string.Empty;
            }



            if (counter.Equals(1))
            {
                if (!string.IsNullOrEmpty(dinamicQualityControlsList[28].CtrlDescription))
                {
                    c29 = string.Empty;
                    if (dinamicQualityControlsList[28].CtrlDescription == Login.Mail)
                        c29 = dinamicQualityControlsList[28].CtrlDescription;
                    else
                        c29 = Login.Mail;

                    c29 = c29.Replace("@", "¥");
                    c29 = c29.ToUpper();
                    c29 = c29.ToUpper();
                }
                else
                {
                    c29 = string.Empty;
                }
                if (!string.IsNullOrEmpty(labelRemarksCValues[28]) &&
                    labelRemarksCValues[28] == Login.Mail)
                    labelRemarksCValues[28] = labelRemarksCValues[28].Replace("@", "¥");
                else if (!string.IsNullOrEmpty(labelRemarksCValues[28]))
                    labelRemarksCValues[28] = Login.Mail.Replace("@", "¥");
            }
            else
            {
                c29 = string.Empty;
                labelRemarksCValues[28] = string.Empty;
            }

        }


        /// <summary>
        /// Crea las etiquetas de INTEGRA e ingresa los valores en el arreglo remarksIntegra
        /// para ser ingresadas posteriormente en el record
        /// </summary>
        private bool LoadXMLIntegraValues
        {
            get
            {
                bool ExistRemarks = false;
                string numberPax = string.Empty;
                int numberPaxId = 0;
                int i = 0;
                if (!string.IsNullOrEmpty(ucQualitiesByPax.Passengers))
                {
                    string number = paxNumberLabel[counter - 1].Substring(0, 2);
                    number = number.Trim(new char[] { '.' });
                    numberPaxId = Convert.ToInt32(number);
                    if (numberPaxId < 10)
                    {
                        numberPax = string.Concat(Resources.TicketEmission.Constants.COMMANDS_ZERO,
                            numberPaxId.ToString());
                    }
                    else
                    {
                        numberPax = numberPaxId.ToString();
                    }
                }
                else
                {
                    if (counter < 10)
                    {
                        numberPax = string.Concat(Resources.TicketEmission.Constants.COMMANDS_ZERO,
                            counter.ToString());
                    }
                    else
                    {
                        numberPax = counter.ToString();
                    }
                }



                List<CatValuesXMLQualityControls> xmlQualityControls = null;

                if (!ucEndReservation.isFlowHotel)
                {
                    xmlQualityControls = CatValuesXMLQualityControlsBL.GetValuesXMLQualityControls(
                        ucFirstValidations.Attribute1,
                        numberPax,
                        labelRemarksCValues[0],
                        labelRemarksCValues[1],
                        labelRemarksCValues[2],
                        labelRemarksCValues[3],
                        labelRemarksCValues[4],
                        labelRemarksCValues[5],
                        labelRemarksCValues[6],
                        labelRemarksCValues[7],
                        labelRemarksCValues[8],
                        labelRemarksCValues[9],
                        labelRemarksCValues[10],
                        labelRemarksCValues[11],
                        labelRemarksCValues[12],
                        labelRemarksCValues[13],
                        labelRemarksCValues[14],
                        labelRemarksCValues[15],
                        labelRemarksCValues[16],
                        labelRemarksCValues[17],
                        labelRemarksCValues[18],
                        labelRemarksCValues[19],
                        labelRemarksCValues[20],
                        labelRemarksCValues[21],
                        labelRemarksCValues[22],
                        labelRemarksCValues[23],
                        labelRemarksCValues[24],
                        labelRemarksCValues[25],
                        labelRemarksCValues[26],
                        labelRemarksCValues[27],
                        c29,
                        labelRemarksCValues[29],
                        labelRemarksCValues[30],
                        labelRemarksCValues[31],
                        labelRemarksCValues[32],
                        labelRemarksCValues[33],
                        labelRemarksCValues[34],
                        labelRemarksCValues[35],
                        labelRemarksCValues[36],
                        labelRemarksCValues[37],
                        labelRemarksCValues[38],
                        labelRemarksCValues[39],
                        labelRemarksCValues[40],
                        labelRemarksCValues[41],
                        labelRemarksCValues[42],
                        labelRemarksCValues[43],
                        labelRemarksCValues[44],
                        labelRemarksCValues[45],
                        labelRemarksCValues[46],
                        labelRemarksCValues[47],
                        labelRemarksCValues[48],
                        labelRemarksCValues[49],
                        labelRemarksCValues[50],
                        labelRemarksCValues[51],
                        labelRemarksCValues[52],
                        labelRemarksCValues[53],
                        labelRemarksCValues[54],
                        labelRemarksCValues[55],
                        labelRemarksCValues[56],
                        labelRemarksCValues[57],
                        labelRemarksCValues[58],
                        labelRemarksCValues[59],
                        labelRemarksCValues[60],
                        labelRemarksCValues[61],
                        labelRemarksCValues[62],
                        labelRemarksCValues[63],
                        labelRemarksCValues[64],
                        labelRemarksCValues[65],
                        labelRemarksCValues[66],
                        labelRemarksCValues[67],
                        labelRemarksCValues[68],
                        labelRemarksCValues[69],
                        labelRemarksCValues[70],
                        labelRemarksCValues[71],
                        labelRemarksCValues[72],
                        labelRemarksCValues[73],
                        labelRemarksCValues[74],
                        labelRemarksCValues[75],
                        labelRemarksCValues[76],
                        labelRemarksCValues[77],
                        labelRemarksCValues[78],
                        labelRemarksCValues[79],
                        labelRemarksCValues[80],
                        labelRemarksCValues[81],
                        labelRemarksCValues[82],
                        labelRemarksCValues[83],
                        labelRemarksCValues[84],
                        labelRemarksCValues[85],
                        labelRemarksCValues[86],
                        labelRemarksCValues[87],
                        labelRemarksCValues[88],
                        labelRemarksCValues[89],
                        labelRemarksCValues[90],
                        labelRemarksCValues[91],
                        labelRemarksCValues[92],
                        labelRemarksCValues[93],
                        labelRemarksCValues[94],
                        labelRemarksCValues[95],
                        labelRemarksCValues[96],
                        labelRemarksCValues[97],
                        labelRemarksCValues[98],
                        labelRemarksCValues[99]);
                }
                else
                {
                    xmlQualityControls = CatValuesXMLQualityControlsBL.GetValuesXMLQualityControls(
                    ucQCHotels.Attribute1,
                    numberPax,
                    labelRemarksCValues[0],
                    labelRemarksCValues[1],
                    labelRemarksCValues[2],
                    labelRemarksCValues[3],
                    labelRemarksCValues[4],
                    labelRemarksCValues[5],
                    labelRemarksCValues[6],
                    labelRemarksCValues[7],
                    labelRemarksCValues[8],
                    labelRemarksCValues[9],
                    labelRemarksCValues[10],
                    labelRemarksCValues[11],
                    labelRemarksCValues[12],
                    labelRemarksCValues[13],
                    labelRemarksCValues[14],
                    labelRemarksCValues[15],
                    labelRemarksCValues[16],
                    labelRemarksCValues[17],
                    labelRemarksCValues[18],
                    labelRemarksCValues[19],
                    labelRemarksCValues[20],
                    labelRemarksCValues[21],
                    labelRemarksCValues[22],
                    labelRemarksCValues[23],
                    labelRemarksCValues[24],
                    labelRemarksCValues[25],
                    labelRemarksCValues[26],
                    labelRemarksCValues[27],
                    c29,
                    labelRemarksCValues[29],
                    labelRemarksCValues[30],
                    labelRemarksCValues[31],
                    labelRemarksCValues[32],
                    labelRemarksCValues[33],
                    labelRemarksCValues[34],
                    labelRemarksCValues[35],
                    labelRemarksCValues[36],
                    labelRemarksCValues[37],
                    labelRemarksCValues[38],
                    labelRemarksCValues[39],
                    labelRemarksCValues[40],
                    labelRemarksCValues[41],
                    labelRemarksCValues[42],
                    labelRemarksCValues[43],
                    labelRemarksCValues[44],
                    labelRemarksCValues[45],
                    labelRemarksCValues[46],
                    labelRemarksCValues[47],
                    labelRemarksCValues[48],
                    labelRemarksCValues[49],
                    labelRemarksCValues[50],
                    labelRemarksCValues[51],
                    labelRemarksCValues[52],
                    labelRemarksCValues[53],
                    labelRemarksCValues[54],
                    labelRemarksCValues[55],
                    labelRemarksCValues[56],
                    labelRemarksCValues[57],
                    labelRemarksCValues[58],
                    labelRemarksCValues[59],
                    labelRemarksCValues[60],
                    labelRemarksCValues[61],
                    labelRemarksCValues[62],
                    labelRemarksCValues[63],
                    labelRemarksCValues[64],
                    labelRemarksCValues[65],
                    labelRemarksCValues[66],
                    labelRemarksCValues[67],
                    labelRemarksCValues[68],
                    labelRemarksCValues[69],
                    labelRemarksCValues[70],
                    labelRemarksCValues[71],
                    labelRemarksCValues[72],
                    labelRemarksCValues[73],
                    labelRemarksCValues[74],
                    labelRemarksCValues[75],
                    labelRemarksCValues[76],
                    labelRemarksCValues[77],
                    labelRemarksCValues[78],
                    labelRemarksCValues[79],
                    labelRemarksCValues[80],
                    labelRemarksCValues[81],
                    labelRemarksCValues[82],
                    labelRemarksCValues[83],
                    labelRemarksCValues[84],
                    labelRemarksCValues[85],
                    labelRemarksCValues[86],
                    labelRemarksCValues[87],
                    labelRemarksCValues[88],
                    labelRemarksCValues[89],
                    labelRemarksCValues[90],
                    labelRemarksCValues[91],
                    labelRemarksCValues[92],
                    labelRemarksCValues[93],
                    labelRemarksCValues[94],
                    labelRemarksCValues[95],
                    labelRemarksCValues[96],
                    labelRemarksCValues[97],
                    labelRemarksCValues[98],
                    labelRemarksCValues[99]);
                }


                if (xmlQualityControls.Count.Equals(0))
                {
                    CommandsAPI2.send_MessageToEmulator(Resources.TicketEmission.Constants.MESSAGE_DK_INTEGRA_NONE);
                    ExistRemarks = true;
                    return ExistRemarks;
                }
                else
                {

                    string stringRemarksIntegra = string.Concat(xmlQualityControls[0].C1,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C2,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C3,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C4,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C5,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C6,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C7,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C8,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C9,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C10,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C11,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C12,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C13,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C14,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C15,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C16,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C17,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C18,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C19,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C20,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C21,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C22,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C23,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C24,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C25,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C26,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C27,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C28,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C29,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C30,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C31,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C32,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C33,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C34,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C35,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C36,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C37,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C38,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C39,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C40,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C41,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C42,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C43,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C44,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C45,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C46,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C47,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C48,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C49,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C50,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C51,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C52,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C53,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C54,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C55,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C56,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C57,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C58,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C59,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C60,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C61,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C62,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C63,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C64,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C65,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C66,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C67,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C68,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C69,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C70,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C71,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C72,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C73,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C74,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C75,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C76,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C77,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C78,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C79,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C80,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C81,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C82,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C83,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C84,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C85,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C86,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C87,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C88,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C89,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C90,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C91,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C92,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C93,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C94,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C95,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C96,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C97,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C98,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C99,
                        Resources.TicketEmission.Constants.PLUS,
                        xmlQualityControls[0].C100);

                    try
                    {
                        if (!string.IsNullOrEmpty(LabelC10))
                            stringRemarksIntegra = stringRemarksIntegra.Replace(LabelC10, justificationsDescription);

                        remarksIntegra.Add(stringRemarksIntegra);
                    }
                    catch
                    {
                        remarksIntegra[counter - 1] = stringRemarksIntegra;
                    }
                    ExistRemarks = false;
                    return ExistRemarks;
                }
            }
        }

        /// <summary>
        /// Crea las etiquetas customizadas por cliente para ser ingresadas posteriormente al record
        /// </summary>
        private void LoadXMLClientsValues()
        {
            if (counter.Equals(1))
            {
                if (!ucEndReservation.isFlowHotel)
                {
                    if (!string.IsNullOrEmpty(ucFirstValidations.CorporativeQualityControls[0].EmissionSendQCClient)
                    && ucFirstValidations.CorporativeQualityControls[0].EmissionSendQCClient.Equals(Resources.TicketEmission.Constants.ACTIVE))
                    {
                        List<CatValuesXMLQualityControlsClients> xmlQualityControlsClients = CatValuesXMLQualityControlsClientsBL.GetValuesXMLQualityControls(
                                ucFirstValidations.Attribute1,
                                string.Empty,
                                labelRemarksCValues[0],
                                labelRemarksCValues[1],
                                labelRemarksCValues[2],
                                labelRemarksCValues[3],
                                labelRemarksCValues[4],
                                labelRemarksCValues[5],
                                labelRemarksCValues[6],
                                labelRemarksCValues[7],
                                labelRemarksCValues[8],
                                labelRemarksCValues[9],
                                labelRemarksCValues[10],
                                labelRemarksCValues[11],
                                labelRemarksCValues[12],
                                labelRemarksCValues[13],
                                labelRemarksCValues[14],
                                labelRemarksCValues[15],
                                labelRemarksCValues[16],
                                labelRemarksCValues[17],
                                labelRemarksCValues[18],
                                labelRemarksCValues[19],
                                labelRemarksCValues[20],
                                labelRemarksCValues[21],
                                labelRemarksCValues[22],
                                labelRemarksCValues[23],
                                labelRemarksCValues[24],
                                labelRemarksCValues[25],
                                labelRemarksCValues[26],
                                labelRemarksCValues[27],
                                labelRemarksCValues[28],
                                labelRemarksCValues[29],
                                labelRemarksCValues[30],
                                labelRemarksCValues[31],
                                labelRemarksCValues[32],
                                labelRemarksCValues[33],
                                labelRemarksCValues[34],
                                labelRemarksCValues[35],
                                labelRemarksCValues[36],
                                labelRemarksCValues[37],
                                labelRemarksCValues[38],
                                labelRemarksCValues[39],
                                labelRemarksCValues[40],
                                labelRemarksCValues[41],
                                labelRemarksCValues[42],
                                labelRemarksCValues[43],
                                labelRemarksCValues[44],
                                labelRemarksCValues[45],
                                labelRemarksCValues[46],
                                labelRemarksCValues[47],
                                labelRemarksCValues[48],
                                labelRemarksCValues[49],
                                labelRemarksCValues[50],
                                labelRemarksCValues[51],
                                labelRemarksCValues[52],
                                labelRemarksCValues[53],
                                labelRemarksCValues[54],
                                labelRemarksCValues[55],
                                labelRemarksCValues[56],
                                labelRemarksCValues[57],
                                labelRemarksCValues[58],
                                labelRemarksCValues[59],
                                labelRemarksCValues[60],
                                labelRemarksCValues[61],
                                labelRemarksCValues[62],
                                labelRemarksCValues[63],
                                labelRemarksCValues[64],
                                labelRemarksCValues[65],
                                labelRemarksCValues[66],
                                labelRemarksCValues[67],
                                labelRemarksCValues[68],
                                labelRemarksCValues[69],
                                labelRemarksCValues[70],
                                labelRemarksCValues[71],
                                labelRemarksCValues[72],
                                labelRemarksCValues[73],
                                labelRemarksCValues[74],
                                labelRemarksCValues[75],
                                labelRemarksCValues[76],
                                labelRemarksCValues[77],
                                labelRemarksCValues[78],
                                labelRemarksCValues[79],
                                labelRemarksCValues[80],
                                labelRemarksCValues[81],
                                labelRemarksCValues[82],
                                labelRemarksCValues[83],
                                labelRemarksCValues[84],
                                labelRemarksCValues[85],
                                labelRemarksCValues[86],
                                labelRemarksCValues[87],
                                labelRemarksCValues[88],
                                labelRemarksCValues[89],
                                labelRemarksCValues[90],
                                labelRemarksCValues[91],
                                labelRemarksCValues[92],
                                labelRemarksCValues[93],
                                labelRemarksCValues[94],
                                labelRemarksCValues[95],
                                labelRemarksCValues[96],
                                labelRemarksCValues[97],
                                labelRemarksCValues[98],
                                labelRemarksCValues[99]);


                        if (xmlQualityControlsClients != null)
                        {
                            if (!xmlQualityControlsClients.Count.Equals(0))
                            {
                                string stringRemarksClients = string.Concat(xmlQualityControlsClients[0].C1,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C2,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C3,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C4,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C5,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C6,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C7,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C8,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C9,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C10,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C11,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C12,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C13,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C14,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C15,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C16,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C17,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C18,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C19,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C20,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C21,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C22,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C23,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C24,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C25,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C26,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C27,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C28,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C29,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C30,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C31,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C32,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C33,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C34,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C35,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C36,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C37,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C38,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C39,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C40,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C41,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C42,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C43,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C44,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C45,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C46,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C47,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C48,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C49,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C50,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C51,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C52,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C53,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C54,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C55,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C56,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C57,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C58,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C59,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C60,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C61,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C62,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C63,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C64,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C65,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C66,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C67,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C68,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C69,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C70,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C71,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C72,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C73,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C74,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C75,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C76,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C77,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C78,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C79,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C80,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C81,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C82,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C83,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C84,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C85,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C86,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C87,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C88,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C89,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C90,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C91,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C92,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C93,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C94,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C95,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C96,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C97,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C98,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C99,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C100);

                                try
                                {
                                    remarksClients.Add(stringRemarksClients);
                                }
                                catch
                                {
                                    remarksClients[counter - 1] = stringRemarksClients;
                                }
                            }
                        }
                    }

                }
                else
                {
                    if (!string.IsNullOrEmpty(ucQCHotels.CorporativeQualityControls[0].EmissionSendQCClient)
                    && ucQCHotels.CorporativeQualityControls[0].EmissionSendQCClient.Equals(Resources.TicketEmission.Constants.ACTIVE))
                    {
                        List<CatValuesXMLQualityControlsClients> xmlQualityControlsClients = CatValuesXMLQualityControlsClientsBL.GetValuesXMLQualityControls(
                                ucQCHotels.Attribute1,
                                string.Empty,
                                labelRemarksCValues[0],
                                labelRemarksCValues[1],
                                labelRemarksCValues[2],
                                labelRemarksCValues[3],
                                labelRemarksCValues[4],
                                labelRemarksCValues[5],
                                labelRemarksCValues[6],
                                labelRemarksCValues[7],
                                labelRemarksCValues[8],
                                labelRemarksCValues[9],
                                labelRemarksCValues[10],
                                labelRemarksCValues[11],
                                labelRemarksCValues[12],
                                labelRemarksCValues[13],
                                labelRemarksCValues[14],
                                labelRemarksCValues[15],
                                labelRemarksCValues[16],
                                labelRemarksCValues[17],
                                labelRemarksCValues[18],
                                labelRemarksCValues[19],
                                labelRemarksCValues[20],
                                labelRemarksCValues[21],
                                labelRemarksCValues[22],
                                labelRemarksCValues[23],
                                labelRemarksCValues[24],
                                labelRemarksCValues[25],
                                labelRemarksCValues[26],
                                labelRemarksCValues[27],
                                labelRemarksCValues[28],
                                labelRemarksCValues[29],
                                labelRemarksCValues[30],
                                labelRemarksCValues[31],
                                labelRemarksCValues[32],
                                labelRemarksCValues[33],
                                labelRemarksCValues[34],
                                labelRemarksCValues[35],
                                labelRemarksCValues[36],
                                labelRemarksCValues[37],
                                labelRemarksCValues[38],
                                labelRemarksCValues[39],
                                labelRemarksCValues[40],
                                labelRemarksCValues[41],
                                labelRemarksCValues[42],
                                labelRemarksCValues[43],
                                labelRemarksCValues[44],
                                labelRemarksCValues[45],
                                labelRemarksCValues[46],
                                labelRemarksCValues[47],
                                labelRemarksCValues[48],
                                labelRemarksCValues[49],
                                labelRemarksCValues[50],
                                labelRemarksCValues[51],
                                labelRemarksCValues[52],
                                labelRemarksCValues[53],
                                labelRemarksCValues[54],
                                labelRemarksCValues[55],
                                labelRemarksCValues[56],
                                labelRemarksCValues[57],
                                labelRemarksCValues[58],
                                labelRemarksCValues[59],
                                labelRemarksCValues[60],
                                labelRemarksCValues[61],
                                labelRemarksCValues[62],
                                labelRemarksCValues[63],
                                labelRemarksCValues[64],
                                labelRemarksCValues[65],
                                labelRemarksCValues[66],
                                labelRemarksCValues[67],
                                labelRemarksCValues[68],
                                labelRemarksCValues[69],
                                labelRemarksCValues[70],
                                labelRemarksCValues[71],
                                labelRemarksCValues[72],
                                labelRemarksCValues[73],
                                labelRemarksCValues[74],
                                labelRemarksCValues[75],
                                labelRemarksCValues[76],
                                labelRemarksCValues[77],
                                labelRemarksCValues[78],
                                labelRemarksCValues[79],
                                labelRemarksCValues[80],
                                labelRemarksCValues[81],
                                labelRemarksCValues[82],
                                labelRemarksCValues[83],
                                labelRemarksCValues[84],
                                labelRemarksCValues[85],
                                labelRemarksCValues[86],
                                labelRemarksCValues[87],
                                labelRemarksCValues[88],
                                labelRemarksCValues[89],
                                labelRemarksCValues[90],
                                labelRemarksCValues[91],
                                labelRemarksCValues[92],
                                labelRemarksCValues[93],
                                labelRemarksCValues[94],
                                labelRemarksCValues[95],
                                labelRemarksCValues[96],
                                labelRemarksCValues[97],
                                labelRemarksCValues[98],
                                labelRemarksCValues[99]);



                        if (xmlQualityControlsClients != null)
                        {
                            if (!xmlQualityControlsClients.Count.Equals(0))
                            {
                                string stringRemarksClients = string.Concat(xmlQualityControlsClients[0].C1,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C2,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C3,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C4,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C5,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C6,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C7,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C8,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C9,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C10,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C11,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C12,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C13,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C14,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C15,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C16,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C17,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C18,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C19,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C20,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C21,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C22,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C23,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C24,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C25,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C26,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C27,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C28,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C29,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C30,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C31,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C32,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C33,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C34,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C35,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C36,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C37,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C38,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C39,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C40,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C41,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C42,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C43,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C44,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C45,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C46,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C47,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C48,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C49,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C50,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C51,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C52,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C53,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C54,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C55,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C56,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C57,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C58,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C59,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C60,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C61,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C62,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C63,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C64,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C65,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C66,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C67,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C68,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C69,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C70,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C71,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C72,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C73,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C74,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C75,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C76,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C77,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C78,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C79,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C80,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C81,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C82,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C83,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C84,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C85,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C86,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C87,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C88,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C89,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C90,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C91,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C92,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C93,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C94,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C95,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C96,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C97,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C98,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C99,
                                    Resources.TicketEmission.Constants.PLUS,
                                    xmlQualityControlsClients[0].C100);

                                try
                                {
                                    remarksClients.Add(stringRemarksClients);
                                }
                                catch
                                {
                                    remarksClients[counter - 1] = stringRemarksClients;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Carga los valores de los controles dinamicos en el arreglo passengerPositionValues para mantener
        /// los valores en el flujo
        /// </summary>
        private void LoadFormValuesByPax()
        {
            arrayValues.Clear();
            int i = 0;
            foreach (Control control in this.Controls)
            {

                if (control is TextBox)
                {
                    i++;
                    //Redim(i, Resources.TicketEmission.Constants.ARRAY_NAME_ARRAY_VALUES);
                    arrayValues.Add(((TextBox)control).Text);
                }

                else if (control is ComboBox)
                {
                    i++;
                    //Redim(i, Resources.TicketEmission.Constants.ARRAY_NAME_ARRAY_VALUES);
                    arrayValues.Add(((ComboBox)control).Text);
                }

                else if (control is CheckBox)
                {
                    i++;
                    //Redim(i, Resources.TicketEmission.Constants.ARRAY_NAME_ARRAY_VALUES);
                    arrayValues.Add(((CheckBox)control).Checked.ToString());
                }
            }

            try
            {
                passengerPositionValues[counter - 1] = arrayValues.ToArray();
            }
            catch
            {
                passengerPositionValues.Add(arrayValues.ToArray());
            }

        }

        /// <summary>
        /// Carga los valores previos ingresados en la mascarilla deacurdo al numero de pasajero
        /// </summary>
        private void LoadFormPreviousValues()
        {
            int i = 0;
            string[] values = new string[passengerPositionValues[counter].Length];
            bool existingItem = false;
            values = ((string[])passengerPositionValues[counter]);

            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    existingItem = false;
                    ((TextBox)control).Text = values[i];
                    i++;
                }

                else if (control is ComboBox)
                {
                    existingItem = false;
                    for (int j = 1; j <= ((ComboBox)control).Items.Count - 1; j++)
                    {
                        if (((ListItem)((ComboBox)control).Items[j]).Text.Equals(values[i]))
                        {
                            existingItem = true;
                            ((ComboBox)control).SelectedIndex = j;
                            break;
                        }
                        else if (((ListItem)((ComboBox)control).Items[j]).Value.Equals(values[i]))
                        {
                            existingItem = true;
                            ((ComboBox)control).SelectedIndex = j;
                            break;
                        }
                    }
                    if (!existingItem)
                    {
                        ((ComboBox)control).Items.Add(values[i]);
                        ((ComboBox)control).SelectedIndex = ((ComboBox)control).Items.Count - 1;
                    }
                    i++;
                }

                else if (control is CheckBox)
                {

                    if (values[i].Equals(Resources.TicketEmission.Constants.TRUE_VALUE))
                    {

                        ((CheckBox)control).Checked = true;
                        i++;
                    }
                    else
                    {
                        existingItem = false;
                        ((CheckBox)control).Checked = false;
                        i++;
                    }
                }
            }
        }

        /// <summary>
        /// Carga los controles dependiendo de que existan datos en passengerPositionValues
        /// </summary>
        /// <param name="charge">indicador que determina que valores se vana cargar en el uc</param>
        private void LoadFormNextValues(bool charge)
        {
            bool existingItem = false;
            int position = 0;
            int i = 0;

            if (charge)
                if (!passengerPositionValues.Count.Equals(counter + 1))
                {
                    position = counter - 1;
                }
                else
                {
                    position = counter;
                }

            else
                position = counter;
            string[] values = new string[passengerPositionValues[position].Length];


            values = ((string[])passengerPositionValues[position]);

            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    existingItem = false;
                    ((TextBox)control).Text = values[i];
                    i++;
                }

                else if (control is ComboBox)
                {
                    existingItem = false;
                    //if (((ComboBox)control).SelectedIndex > 0)
                    //{
                    for (int j = 1; j <= ((ComboBox)control).Items.Count - 1; j++)
                    {
                        if (((ListItem)((ComboBox)control).Items[j]).Text.Equals(values[i]))
                        {
                            existingItem = true;
                            ((ComboBox)control).SelectedIndex = j;
                            break;
                        }
                        else if (((ListItem)((ComboBox)control).Items[j]).Value.Equals(values[i]))
                        {
                            existingItem = true;
                            ((ComboBox)control).SelectedIndex = j;
                            break;
                        }
                    }
                    //}
                    //if(((ComboBox)control).Items.Count < 2)
                    //{
                    //    existingItem = true;
                    //}
                    if (!existingItem)
                    {
                        if (!values[i].Equals(Resources.TicketEmission.Constants.COMBOBOX_FIRST_ITEM_TEXT))
                        {
                            ((ComboBox)control).Items.Add(values[i]);
                            ((ComboBox)control).SelectedIndex = ((ComboBox)control).Items.Count - 1;
                        }
                    }
                    i++;
                }

                else if (control is CheckBox)
                {
                    existingItem = false;
                    if (values[i].Equals(Resources.TicketEmission.Constants.TRUE_VALUE))
                    {

                        ((CheckBox)control).Checked = true;
                        i++;
                    }
                    else
                    {
                        ((CheckBox)control).Checked = false;
                        i++;
                    }
                }
            }
        }

        /// <summary>
        /// Carga los controles dinamicos con valores de una instancia del usercontrol inicial previa
        /// </summary>
        private void LoadValues()
        {
            statusParamReceived = true;
            if (!escKeyDown)
            {
                if (counter.Equals(0) && passengerPositionValues.Count.Equals(0))
                {
                    PreviousRemarkICAAVValues();
                }
                else
                {
                    LoadFormNextValues(true);
                }

            }
            else
            {
                escKeyDown = false;
                if (passengerPositionValues[counter] == null)
                    LoadFormPreviousValues();
                else
                    LoadFormNextValues(false);
            }
            statusParamReceived = false;
        }

        /// <summary>
        /// verifica los valores de los catalogos aplicables para los remarks CF y CG permitiendo carga de
        /// dichos valores
        /// </summary>
        private void IcavComboboxvalues()
        {
            bool exitingItem = false;
            positionOneCF = (!string.IsNullOrEmpty(ucRemoveRemarks.C33)) ? ucRemoveRemarks.C33 : string.Empty;
            positionTwoCF = (!string.IsNullOrEmpty(ucRemoveRemarks.C34)) ? ucRemoveRemarks.C34 : string.Empty;
            positionThreeCF = (!string.IsNullOrEmpty(ucRemoveRemarks.C35)) ? ucRemoveRemarks.C35 : string.Empty;
            positionFourCF = (!string.IsNullOrEmpty(ucRemoveRemarks.C36)) ? ucRemoveRemarks.C36 : string.Empty;

            positionOneCG = (!string.IsNullOrEmpty(ucRemoveRemarks.C37)) ? ucRemoveRemarks.C37 : string.Empty;
            positionTwoCG = (!string.IsNullOrEmpty(ucRemoveRemarks.C38)) ? ucRemoveRemarks.C38 : string.Empty;
            foreach (Control cmbControl in this.Controls)
            {
                if (cmbControl is ComboBox)
                {
                    if (cmbControl.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_THIRTY_THREE))
                    {
                        if (!string.IsNullOrEmpty(positionOneCF))
                        {
                            for (int i = 1; i <= ((ComboBox)cmbControl).Items.Count - 1; i++)
                            {

                                if (((ListItem)((ComboBox)cmbControl).Items[i]).Value.Equals(positionOneCF))
                                {
                                    exitingItem = true;
                                    ((ComboBox)cmbControl).SelectedIndex = i;
                                    break;
                                }
                            }
                            if (!exitingItem)
                            {
                                ((ComboBox)cmbControl).Items.Add(positionOneCF);
                                ((ComboBox)cmbControl).SelectedIndex = ((ComboBox)cmbControl).Items.Count - 1;
                            }

                        }

                    }

                    //
                    exitingItem = false;
                    if (cmbControl.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_THIRTY_FOUR))
                    {
                        if (!string.IsNullOrEmpty(positionTwoCF))
                        {
                            for (int i = 1; i <= ((ComboBox)cmbControl).Items.Count - 1; i++)
                            {
                                if (((ListItem)((ComboBox)cmbControl).Items[i]).Value.Equals(positionTwoCF))
                                {
                                    exitingItem = true;
                                    ((ComboBox)cmbControl).SelectedIndex = i;
                                    break;
                                }
                            }
                            if (!exitingItem)
                            {
                                ((ComboBox)cmbControl).Items.Add(positionTwoCF);
                                ((ComboBox)cmbControl).SelectedIndex = ((ComboBox)cmbControl).Items.Count - 1;
                            }

                        }
                    }

                    //
                    exitingItem = false;
                    if (cmbControl.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_THIRTY_FIVE))
                    {
                        if (!string.IsNullOrEmpty(positionThreeCF))
                        {
                            for (int i = 1; i <= ((ComboBox)cmbControl).Items.Count - 1; i++)
                            {
                                if (((ListItem)((ComboBox)cmbControl).Items[i]).Value.Equals(positionThreeCF))
                                {
                                    exitingItem = true;
                                    ((ComboBox)cmbControl).SelectedIndex = i;
                                    break;
                                }
                            }
                            if (!exitingItem)
                            {
                                ((ComboBox)cmbControl).Items.Add(positionThreeCF);
                                ((ComboBox)cmbControl).SelectedIndex = ((ComboBox)cmbControl).Items.Count - 1;
                            }

                        }
                    }

                    //
                    exitingItem = false;
                    if (cmbControl.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_THIRTY_SIX))
                    {
                        if (!string.IsNullOrEmpty(positionFourCF))
                        {
                            for (int i = 1; i <= ((ComboBox)cmbControl).Items.Count - 1; i++)
                            {
                                if (((ListItem)((ComboBox)cmbControl).Items[i]).Value.Equals(positionFourCF))
                                {
                                    exitingItem = true;
                                    ((ComboBox)cmbControl).SelectedIndex = i;
                                    break;
                                }
                            }
                            if (!exitingItem)
                            {
                                ((ComboBox)cmbControl).Items.Add(positionFourCF);
                                ((ComboBox)cmbControl).SelectedIndex = ((ComboBox)cmbControl).Items.Count - 1;
                            }

                        }
                    }

                    //
                    exitingItem = false;
                    if (cmbControl.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_THIRTY_SEVEN))
                    {
                        if (!string.IsNullOrEmpty(positionOneCG))
                        {
                            for (int i = 1; i <= ((ComboBox)cmbControl).Items.Count - 1; i++)
                            {
                                if (((ListItem)((ComboBox)cmbControl).Items[i]).Value.Equals(positionOneCG))
                                {
                                    exitingItem = true;
                                    ((ComboBox)cmbControl).SelectedIndex = i;
                                    break;
                                }
                            }
                            if (!exitingItem)
                            {
                                ((ComboBox)cmbControl).Items.Add(positionOneCG);
                                ((ComboBox)cmbControl).SelectedIndex = ((ComboBox)cmbControl).Items.Count - 1;
                            }

                        }
                    }

                    //
                    exitingItem = false;
                    if (cmbControl.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_THIRTY_EIGHT))
                    {
                        if (!string.IsNullOrEmpty(positionTwoCG))
                        {
                            for (int i = 1; i <= ((ComboBox)cmbControl).Items.Count - 1; i++)
                            {
                                if (((ListItem)((ComboBox)cmbControl).Items[i]).Value.Equals(positionTwoCG))
                                {
                                    exitingItem = true;
                                    ((ComboBox)cmbControl).SelectedIndex = i;
                                    break;
                                }
                            }
                            if (!exitingItem)
                            {
                                ((ComboBox)cmbControl).Items.Add(positionTwoCG);
                                ((ComboBox)cmbControl).SelectedIndex = ((ComboBox)cmbControl).Items.Count - 1;
                            }

                        }
                    }
                }
            }
        }


        private bool IsVolaris
        {
            get { return (this.Parameter != null && Parameter is VolarisReservation); }
        }

        private bool IsInterJet
        {

            get { return (this.Parameter != null && Parameter is InterJetSession); }
        }


        /// <summary>
        /// Carga el siguiente user control dependiendo del valor de counter
        /// </summary>
        private void LoadNextUcControl()
        {
            if (VolarisSession.IsVolarisProcess)
            {
                globalPaxNumber = VolarisSession.ContAdult + VolarisSession.ContChild;
            }

            if (counter.Equals(globalPaxNumber))
            {

                //TODO: InterJet remover cuando acaben las pruebas.
                if (ucAvailability.IsInterJetProcess && !ucAvailability.AgentCanSeeFullFunctionality)
                {

                    globalPaxNumber = 0;
                    counter = 0;

                    ucMenuReservations.ChargeService = true; //Resources.TicketEmission.Constants.UC_CHARGESERVICE
                    //Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucCalculateServiceCharge", this.Parameter, this.Parameters);
                    Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_CHARGESERVICE, this.Parameter, this.Parameters);
                }

                if (VolarisSession.IsVolarisProcess)
                {

                    globalPaxNumber = 0;
                    counter = 0;
                    ucTicketEmissionBuildCommand.IsVolaris = true;
                    ucTicketEmissionBuildCommand.BuildRemarksForVolaris();

                    var remarks = ucTicketEmissionBuildCommand.RemarkVolaris;
                    //var reservation = (VolarisReservation)this.Parameter;
                    //reservation.Remarks.Add(remarks);
                    VolarisSession.Remarks.Add(remarks);
                    ucTicketEmissionBuildCommand.IsVolaris = false;
                    ucTicketEmissionBuildCommand.RemarkVolaris.Clear();
                    ucTicketEmissionBuildCommand.RemarkInterJet.Clear();
                    //TODO : Llamar al cargo por servicio generico para areolineas de bajo de costo.-Volaris-InterJet
                    Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucChargeOfServiceLowFare", this.Parameter, new[] { "Volaris" });
                }
                //TODO: Verificar que se mande cuando se realiza de forma correcta.
                if (IsInterJet && ucAvailability.AgentCanSeeFullFunctionality)
                {
                    globalPaxNumber = 0;
                    counter = 0;
                    ucTicketEmissionBuildCommand.IsInterJet = true;
                    ucTicketEmissionBuildCommand.BuildRemarksForInterJet();
                    var remarks = ucTicketEmissionBuildCommand.RemarkInterJet;
                    if (Parameter is InterJetSession)
                    {
                        var session = (InterJetSession)Parameter;
                        var ticket = (InterJetTicket)session.Session["CurrentTicket"];
                        if (!string.IsNullOrEmpty(ucDKClient.extendDescription))
                        {
                            ticket.Remarks.Add(ucDKClient.extendDescription);
                            ucDKClient.extendDescription = string.Empty;
                        }
                        ticket.Remarks.Add(remarks);
                    }
                    ucTicketEmissionBuildCommand.IsInterJet = false;
                    ucTicketEmissionBuildCommand.RemarkVolaris.Clear();
                    ucTicketEmissionBuildCommand.RemarkInterJet.Clear();

                    Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucChargeOfServiceLowFare", this.Parameter, new[] { "InterJet" });
                }

                if (!ucMenuReservations.qualityControls && !ucAvailability.IsInterJetProcess && !VolarisSession.IsVolarisProcess)
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCPRESENT_RECORD);
                }
                else if (ucQREX.Qrex && !ucAvailability.IsInterJetProcess && !VolarisSession.IsVolarisProcess)
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCUSEINDEPENDENTCHARGESERVICE);
                }
                else
                {
                    if (!ucAvailability.IsInterJetProcess && !VolarisSession.IsVolarisProcess)
                    {
                        if (ucEndReservation.isFlowHotel)
                        {
                            QueueAgent();
                            using (CommandsAPI objCommand = new CommandsAPI())
                            {
                                objCommand.SendReceive(string.Concat(Resources.Constants.AST, ucEndReservation.objItineraryHotel[0].Record.Contains('|') ? ucEndReservation.objItineraryHotel[0].Record.Split('|')[0] : ucEndReservation.objItineraryHotel[0].Record));
                            }
                            activeStepsCorporativeQC.CorporativeQualityControls = null;

                            remarksHotels = string.Empty;
                            isDocumentNow = false;
                            ucMenuReservations.EnabledMenu = true;
                            ucEndReservation.objItineraryHotel = null;
                            if (IncluirCargoPorServicio || IncluirCargoPorServicioAuto)
                            {

                                if (IncluirCargoPorServicio)
                                {
                                    if (IncluirCargoPorServicioAuto)
                                    {
                                        ucHotelChargeService.TipoCargo = ChargesPerService.OrigenTipoCargo.Autos;
                                    }

                                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCHOTELCHARGESERVICE);
                                }

                                if (IncluirCargoPorServicioAuto)
                                {
                                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCCARCHARGESERVICE);
                                }
                            }
                            else
                            {
                                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                            }
                        }
                        else
                            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTICKETEMISSIONBUILDCOMMAND);
                    }
                }
            }
            else
            {
                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_ALL_QUALITY_CONTROLS, this.Parameter, null);
            }

        }

        /// <summary>
        /// LLama el modal auxiliar para inserción de nuevos datos por quality control
        /// </summary>
        /// <param name="control">Control de origen</param>
        /// <param name="index">indice de la posicion del arreglo del quality control
        /// respectivo</param>
        private void CallModalInsert(Control control, int index)
        {
            frmQualityControls frm = new frmQualityControls();
            frm.formPrompt = string.Concat("INGRESA LA DESCRIPCIÓN DEL ",
                dinamicQualityControlsList[index].QCDescription.ToUpper(),
                "\n",
                "PARA EL CORPORATIVO ",
                activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1);
            frm.client = activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1;
            frm.remarkLabelID = string.Concat("C", Convert.ToString(index + 1));
            frm.code = control.Text;
            frm.ShowDialog();
        }

        /// <summary>
        /// Verifica los corporativos para asignarle valores por default el origen de la venta
        /// y la unidad corporativa. Hasta el 30-Sep-09 solo estan en la tabla 
        /// los valores para Consolid
        /// </summary>
        private void ValidateCorporative()
        {
            List<GetCorporativeFeatures> indexList = new List<GetCorporativeFeatures>();
            indexList = GetCorporativeFeaturesBL.GetCorporativeFeatures(activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1);
            if (!indexList.Count.Equals(0))
            {
                foreach (Control cmbControl in this.Controls)
                {
                    if (cmbControl is ComboBox)
                    {
                        if (cmbControl.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_TWENTY_ONE))
                        {
                            ((ComboBox)(cmbControl)).SelectedIndex = indexList[0].C21;//Origen de venta
                        }
                        if (cmbControl.Name.Equals(Resources.TicketEmission.Constants.CONTROL_NAME_QC_TWENTY_TWO))
                        {
                            ((ComboBox)(cmbControl)).SelectedIndex = indexList[0].C22;//Unidad operativa
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Carga el catalogo general de valores para los quality controls aplicables por
        /// corporativo
        /// </summary>
        private void LoadPredictiveLists()
        {
            CatClientsCatalogsBL.ListClientsCatalogs = CatClientsCatalogsBL.GetCatalog_ClientsCatalogs(activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1, string.Empty);
        }

        /// <summary>
        /// Inserta nuevos valores de catalogos por Quality Control
        /// </summary>
        /// <param name="control">Control de origen de la petición</param>
        private void InsertNewValues(Control control)
        {
            int remark = 0;
            try
            {
                remark = Convert.ToInt32(control.Name.Substring(4, 2));
            }
            catch
            {
                remark = Convert.ToInt32(control.Name.Substring(4, 1));
            }

            if (dinamicQualityControlsList[remark - 1].AllowInsertvalues)
            {
                string[] value = control.Text.Split(new char[] { '-' });
                string valueCode = value[0].Trim();
                if (valueCode == "Seleccione el valor deseado:")
                {
                    valueCode = string.Empty;
                }
                else
                {
                    List<SearchClientsCatalogs> existInList = SearchClientsCatalogsBL.GetSearchClientsCatalogs(activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1, dinamicQualityControlsList[remark - 1].QCId, valueCode);
                    if (!existInList.Count.Equals(0))
                    {
                        if (existInList[0].Result.Equals(Resources.TicketEmission.Constants.MINUS_ONE))
                        {
                            messageToSend = string.Format(Resources.TicketEmission.Tickets.AGREGAR_NUEVO,
                                dinamicQualityControlsList[remark - 1].QCDescription,
                                "\n");
                            DialogResult yesNo = MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (yesNo.Equals(DialogResult.Yes))
                            {
                                CallModalInsert(control, remark - 1);
                            }
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Carga los datos para el catalogo de ComboBox dependiendo de que quality control 
        /// esta activo
        /// </summary>
        /// <param name="cmbcontrol">control ComboBox a signar</param>
        /// <param name="QCId">etiqueta de quality control</param>
        private void LoadComboBoxCatalog(ComboBox cmbcontrol, string QCId)
        {
            List<ListItem> ClientCatalogsList = CatClientsCatalogsBL.GetCatalog_ClientsCatalogs(activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1, QCId);
            bindingSource1.DataSource = ClientCatalogsList;

            cmbcontrol.DisplayMember = Resources.Constants.TEXT;
            cmbcontrol.ValueMember = Resources.Constants.VALUE;

            foreach (ListItem ClientCatalogsItem in ClientCatalogsList)
            {
                ListItem litem = new ListItem();
                if (!string.IsNullOrEmpty(ClientCatalogsItem.Text))
                {
                    litem.Text = string.Format("{0} - {1}",
                        ClientCatalogsItem.Value,
                        ClientCatalogsItem.Text2);
                }
                else
                {
                    litem.Text = ClientCatalogsItem.Value;
                }
                litem.Value = ClientCatalogsItem.Value;
                cmbcontrol.Items.Add(litem);
            }
        }

        /// <summary>
        /// Recorre y asigna valores provenientes del record a los controles de Quality Controls que coincidan
        /// </summary>
        private void AddQCValues()
        {
            string[] value = null;
            if (activeStepsCorporativeQC.CorporativeQualityControls[0].GetThereQCValues)
            {
                string sabreAnswer = string.Empty;
                string send = Resources.TicketEmission.Constants.COMMANDS_AST_CROSSLORAINE;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    sabreAnswer = objCommand.SendReceive(send);

                }
                sabreConcat = sabreAnswer;
                SearchDocumentEnd();
                string[] lines = sabreConcat.Split(new char[] { '\n' });
                foreach (string Line in lines)
                {
                    value = Line.Split(new Char[] { '-' });
                    if (value.Length > 2)
                    {
                        for (int i = 2; i < value.Length; i++)
                        {
                            value[1] = string.Concat(value[1],
                                Resources.TicketEmission.Constants.INDENT,
                                value[i]);
                        }
                    }
                    //string[] name = value[0].Split(new Char[] { ' ' });
                    foreach (QCControlsClients QCName in dinamicQualityControlsList)
                    {
                        //if (name.Length.Equals(2))
                        //{
                        //if (!string.IsNullOrEmpty(QCName.QCDescription.ToUpper().ToString()) &&
                        //    !string.IsNullOrEmpty(value[0]) &&
                        //    (QCName.QCDescription.ToUpper().Contains(value[0].Trim(new char[] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '‡', '.' }))))
                        if (!string.IsNullOrEmpty(QCName.QCDescription) && value[0].Contains(QCName.QCDescription.ToUpper()))
                        {
                            foreach (Control txt in this.Controls)
                            {
                                if (txt is SmartTextBox)
                                {
                                    if (txt.Name.Equals(QCName.CtrlName))
                                    {
                                        try
                                        {
                                            txt.Text = value[1];
                                        }
                                        catch { }
                                    }

                                }
                            }

                        }
                    }
                }
            }
        }

        private void AddCTSQCValues()
        {
            if (ucRemoveRemarks.qcCTSValues != null)
            {
                try
                {
                    if (ucRemoveRemarks.qcCTSValues.Count > 0)
                    {
                        foreach (QCControlsClients QCName in dinamicQualityControlsList)
                        {
                            foreach (ListItem itm in ucRemoveRemarks.qcCTSValues)
                            {
                                if (QCName.QCId.Equals(itm.Text))
                                {
                                    if (string.Concat(itm.Text2.TrimStart(new char[] { '0' }), ".1").Equals(passengerNumber))
                                    {
                                        foreach (Control txt in this.Controls)
                                        {
                                            if (txt is SmartTextBox)
                                            {
                                                if (txt.Name.Equals(QCName.CtrlName))
                                                {
                                                    try
                                                    {
                                                        txt.Text = itm.Text3;
                                                    }
                                                    catch { }
                                                }

                                            }
                                            else if (txt is ComboBox)
                                            {
                                                if (txt.Name.Equals(QCName.CtrlName))
                                                {
                                                    try
                                                    {
                                                        for (int i = 1; i <= ((ComboBox)txt).Items.Count - 1; i++)
                                                        {
                                                            if (((ListItem)((ComboBox)txt).Items[i]).Value.Equals(itm.Text3))
                                                            {
                                                                ((ComboBox)txt).SelectedIndex = i;
                                                                break;
                                                            }
                                                            else if (((ListItem)((ComboBox)txt).Items[i]).Text.Contains(itm.Text3))
                                                            {
                                                                ((ComboBox)txt).SelectedIndex = i;
                                                                break;
                                                            }
                                                        }
                                                    }
                                                    catch { }
                                                }

                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// Busca el final del despliegue del comando *‡
        /// </summary>
        private void SearchDocumentEnd()
        {
            string result = SendMoveDownCommand();
            if (!EndScrollValidation(result))
            {
                sabreConcat = string.Concat(sabreConcat,
                    "\n",
                    result);
                SearchDocumentEnd();
            }
        }


        //Despliega mas informacion sobre MySabre
        private string SendMoveDownCommand()
        {
            string sabreAnswer = string.Empty;
            string send = Resources.TicketEmission.Constants.COMMANDS_MD;

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send, 0, 0);
            }

            return sabreAnswer;
        }


        //Busca la etiqueta que indica el final del despliegue en MySabre
        private bool EndScrollValidation(string sabreAnswer)
        {
            int row = 0;
            int col = 0;
            bool IsEndScroll = false;
            CommandsQik.searchResponse(sabreAnswer, "SCROLL‡", ref row, ref col);
            if (row > 0)
            {
                IsEndScroll = true;
            }

            return IsEndScroll;
        }

        private void SetClientValues()
        {
            if (!ucEndReservation.isFlowHotel)
            {
                if (ucFirstValidations.CorporativeQualityControls[0].EmissionSendQCClient.Equals(Resources.TicketEmission.Constants.ACTIVE))
                {
                    if (ucRemoveRemarks.ClientRemarkNumber.Count > 0)
                    {
                        foreach (ListItem remarkValue in ucRemoveRemarks.ClientRemarkNumber)
                        {

                            if (!remarkValue.Text.Contains("C10")) //&& (!remarkValue.Text.Contains("C22"))&& (!remarkValue.Text.Contains("C23")))
                            {
                                foreach (Control control in this.Controls)
                                {
                                    if (control is TextBox)
                                    {
                                        if (control.Name.Equals(remarkValue.Text))
                                        {
                                            if (remarkValue.Text3.Contains(Resources.Constants.CROSSLORAINE))
                                                remarkValue.Text3 = remarkValue.Text3.Replace(Resources.Constants.CROSSLORAINE, "@");
                                            control.Text = remarkValue.Text3;
                                        }
                                    }
                                    else if (control is ComboBox)
                                    {
                                        bool exitingItem = false;
                                        if (control.Name.Equals(remarkValue.Text))
                                        {
                                            if (!string.IsNullOrEmpty(remarkValue.Text3))
                                            {
                                                for (int i = 1; i <= ((ComboBox)control).Items.Count - 1; i++)
                                                {
                                                    if (((ListItem)((ComboBox)control).Items[i]).Value.Equals(remarkValue.Text3))
                                                    {
                                                        exitingItem = true;
                                                        ((ComboBox)control).SelectedIndex = i;
                                                        break;
                                                    }
                                                }
                                                if (!exitingItem)
                                                {
                                                    ((ComboBox)control).Items.Add(remarkValue.Text3);
                                                    ((ComboBox)control).SelectedIndex = ((ComboBox)control).Items.Count - 1;
                                                }

                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                LabelC10 = string.Empty;
                                LabelC10 = remarkValue.Text3;
                            }
                        }
                    }
                }
            }
            else
            {
                if (ucQCHotels.CorporativeQualityControls[0].EmissionSendQCClient.Equals(Resources.TicketEmission.Constants.ACTIVE))
                {
                    if (ucRemoveRemarks.ClientRemarkNumber.Count > 0)
                    {
                        foreach (ListItem remarkValue in ucRemoveRemarks.ClientRemarkNumber)
                        {

                            if (!remarkValue.Text.Contains("C10")) //&& (!remarkValue.Text.Contains("C22"))&& (!remarkValue.Text.Contains("C23")))
                            {
                                foreach (Control control in this.Controls)
                                {
                                    if (control is TextBox)
                                    {
                                        if (control.Name.Equals(remarkValue.Text))
                                        {
                                            if (remarkValue.Text3.Contains(Resources.Constants.CROSSLORAINE))
                                                remarkValue.Text3 = remarkValue.Text3.Replace(Resources.Constants.CROSSLORAINE, "@");
                                            control.Text = remarkValue.Text3;
                                        }
                                    }
                                    else if (control is ComboBox)
                                    {
                                        bool exitingItem = false;
                                        if (control.Name.Equals(remarkValue.Text))
                                        {
                                            if (!string.IsNullOrEmpty(remarkValue.Text3))
                                            {
                                                for (int i = 1; i <= ((ComboBox)control).Items.Count - 1; i++)
                                                {
                                                    if (((ListItem)((ComboBox)control).Items[i]).Value.Equals(remarkValue.Text3))
                                                    {
                                                        exitingItem = true;
                                                        ((ComboBox)control).SelectedIndex = i;
                                                        break;
                                                    }
                                                }
                                                if (!exitingItem)
                                                {
                                                    ((ComboBox)control).Items.Add(remarkValue.Text3);
                                                    ((ComboBox)control).SelectedIndex = ((ComboBox)control).Items.Count - 1;
                                                }

                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                LabelC10 = string.Empty;
                                LabelC10 = remarkValue.Text3;
                            }
                        }
                    }
                }
            }
        }
        #endregion//End MethodsClass


        #region ===== Back to a Previous Usercontrol or Validate Enter KeyDown =====

        /// <summary>
        /// Regreso a mascarilla anterior al presionar la tecla ESC
        /// o continua con el flujo de emision de boleto al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (!ucEndReservation.isFlowHotel)
            {
                if (e.KeyData == Keys.Escape)
                {
                    counter--;
                    escKeyDown = true;
                    if (counter >= 0)
                    {
                        originOfSale.RemoveAt(counter);
                        ListBussinesUnit.RemoveAt(counter);
                        Loader.AddToPanel(Loader.Zone.Middle, this,
                                          Resources.TicketEmission.Constants.UC_ALL_QUALITY_CONTROLS);
                    }
                    else
                    {
                        counter = 0;
                        globalPaxNumber = 0;
                        escKeyDown = false;
                        if (!ucEndReservation.isFlowHotel)
                            Loader.AddToPanel(Loader.Zone.Middle, this,
                                              Resources.TicketEmission.Constants.UC_QUALITIES_BY_PAX);
                        else
                            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                    }
                }
            }
            if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }

        }

        /// <summary>
        /// seleccion de predictivo al presionar la tecla DOWN
        /// Oculta el predictivo al presionar la tecla ESC o ingresa codigo de opcion 
        ///  seleccionada al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControlPredictive_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Escape)
            {
                counter--;
                escKeyDown = true;
                if (counter >= 0)
                {
                    originOfSale.RemoveAt(counter);
                    ListBussinesUnit.RemoveAt(counter);
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_ALL_QUALITY_CONTROLS);
                }
                else
                {
                    ucRemarkToCFE.Status = true;
                    globalPaxNumber = 0;
                    counter = 0;
                    escKeyDown = false;
                    if (!ucEndReservation.isFlowHotel)
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_QUALITIES_BY_PAX);
                    else
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
            }
            if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }

            if (e.KeyCode == Keys.Down)
            {

                if (lbPredictives.Items.Count > 0)
                {

                    lbPredictives.SelectedIndex = 0;
                    lbPredictives.Focus();
                    lbPredictives.Visible = true;
                    lbPredictives.Focus();
                }
            }
        }

        #endregion//End Back to a Previous Usercontrol or Validate Enter KeyDown


        #region ====== Predictives=======


        //Evento txtCostCenter_TextChanged
        private void txtchargePerService_TextChanged(object sender, EventArgs e)
        {
            //if (!statusParamReceived)
            //{
            //    lbPredictives.Items.Clear();
            //    TextBox txt = (TextBox)sender;
            //    txtSender = txt;
            //    Common.SetListBoxPax(txt, lbPredictives);
            //}
        }



        //Evento txtClientsCatalogs_TextChanged
        private void txtClientsCatalogs_TextChanged(object sender, EventArgs e)
        {
            string label = string.Empty;
            if (!statusParamReceived)
            {

                lbPredictives.Items.Clear();
                TextBox txt = (TextBox)sender;
                txtSender = txt;

                try
                {
                    label = txt.Name.Substring(3, 3);
                }
                catch
                {
                    label = txt.Name.Substring(3, 2);
                }


                foreach (ListItem item in CatClientsCatalogsBL.ListClientsCatalogs)
                {
                    if (item.Text3.Equals(label))
                    {
                        IsCatalogExist = true;
                        break;
                    }
                    else
                        IsCatalogExist = false;
                }


                if (IsCatalogExist)
                    Common.SetListClientCatalogs(txt, lbPredictives, activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1, label);
                else if (label.Equals("C3"))
                    Common.SetListCostCenter(txt, lbPredictives);


            }
        }


        #endregion//End Predictive CostCenter


        #region===== Listbox Events =====

        //MouseClick LbCostCenter
        private void ListBox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                TextBox txt = txtSender;
                ListBox listBox = (ListBox)sender;
                ListItem li = (ListItem)listBox.SelectedItem;
                txt.Text = li.Value;
                lbPredictives.Visible = false;
                lbPredictives.Items.Clear();
                txt.Focus();
            }
            catch
            {
                lbPredictives.Visible = false;
                lbPredictives.Items.Clear();
            }
        }


        //KeyDown lbCostCenter
        private void lbPredictives_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = txtSender;
            ListBox listBox = (ListBox)sender;

            if (e.KeyCode == Keys.Enter)
            {
                ListItem li = (ListItem)listBox.SelectedItem;
                txt.Text = li.Value;
                lbPredictives.Visible = false;
                txt.Focus();
                lbPredictives.Items.Clear();

            }

            if (e.KeyCode == Keys.Escape)
            {
                lbPredictives.Hide();
                lbPredictives.Items.Clear();
            }

        }



        private void hidePredictive(object sender, EventArgs e)
        {
            lbPredictives.Hide();
        }


        #endregion//End Listbox Events


        #region===== Leave and Enter Textbox Events =====

        private void txtControl_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.White;

        }

        private void txtControl_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.PaleGoldenrod;
            lbPredictives.Hide();

        }

        private void control_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox)
                ((TextBox)sender).BackColor = Color.PaleGoldenrod;
            lbPredictives.Hide();

        }

        #endregion//End Leave and Enter Textbox Events


        public static string BuildSabreRemarkCommandForVolaris()
        {

            return BuildSabreCommandForInterjet();
        }

        public static string BuildSabreCommandForInterjet()
        {

            string send = "";
            if (!string.IsNullOrEmpty(ucAllQualityControls.TicketsJustifications))
            {
                send = string.Concat(send,
                    ucAllQualityControls.TicketsJustifications,
                    "Σ");
            }


            foreach (string value in ucAllQualityControls.workerNumberArray)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    send = string.Concat(send,
                    value,
                    "Σ");
                }
            }


            send = string.Concat(send,
                ucAllQualityControls.BusinessUnit,
                "Σ");



            send = string.Concat(send,
                ucAllQualityControls.Origin,
                "Σ");



            if (!string.IsNullOrEmpty(ucAllQualityControls.icaavRemarkCC))
            {
                send = string.Concat(send,
                    ucAllQualityControls.icaavRemarkCC,
                    "Σ");
            }

            if (!string.IsNullOrEmpty(ucAllQualityControls.icaavRemarkCD))
            {
                send = string.Concat(send,
                    ucAllQualityControls.icaavRemarkCD,
                    "Σ");


            }

            if (!string.IsNullOrEmpty(ucAllQualityControls.icaavRemarkCE))
            {
                send = string.Concat(send,
                    ucAllQualityControls.icaavRemarkCE,
                    "Σ");
            }

            if (!string.IsNullOrEmpty(ucAllQualityControls.icaavRemarkCF))
            {
                send = string.Concat(send,
                    ucAllQualityControls.icaavRemarkCF,
                    "Σ");
            }

            if (!string.IsNullOrEmpty(ucAllQualityControls.icaavRemarkCG))
            {
                send = string.Concat(send,
                    ucAllQualityControls.icaavRemarkCG,
                    "Σ");
            }

            if (!string.IsNullOrEmpty(ucAllQualityControls.icaavRemarkCH))
            {
                send = string.Concat(send,
                    ucAllQualityControls.icaavRemarkCH,
                    "Σ");
            }

            return send;
        }

    }
}
