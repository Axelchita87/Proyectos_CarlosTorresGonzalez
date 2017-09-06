using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Services.Contracts.Volaris.EventArguments;
using MyCTS.Services.Contracts.Volaris.ResponsabilityChain;
using MyCTS.Services.APIVolaris;
using MyCTS.Services.BookingManager;
using MyCTS.Business;

namespace MyCTS.Services.Contracts.Volaris
{
    /// <summary>
    /// 
    /// </summary>
    public class VolarisServiceManager
    {
        int contMount = 0;
        int contIva = 0;
        int contIvaChild = 0;
        int contMountChild = 0;
        int contPsf = 0;
        int contPsfChild = 0;
        public static bool ciclo = false;
        public static Object thisLock = new Object();
        public static List<VueloDisponibleMyCTS> volarisVuelos = new List<VueloDisponibleMyCTS>();
        public static List<VueloDisponible> dispVolaris = new List<VueloDisponible>();
        List<Entities.ExtrasViajeVolaris> listExtras = null;

        List<AdditionalAccountingLine> psfAdult = null;
        List<AdditionalAccountingLine> psfChild = null;
        /// <summary>
        /// Gets or sets the on web service call start.
        /// </summary>
        /// <value>
        /// The on web service call start.
        /// </value>
        public EventHandler<OnWebServiceCallStartEventArg> OnWebServiceCallStart { get; set; }
        /// <summary>
        /// Gets or sets the on web service call completed.
        /// </summary>
        /// <value>
        /// The on web service call completed.
        /// </value>
        public EventHandler<OnWebServiceCallCompletedEventArg> OnWebServiceCallCompleted { get; set; }
        /// <summary>
        /// Gets or sets the on reservation created completed.
        /// </summary>
        /// <value>
        /// The on reservation created completed.
        /// </value>
        public EventHandler OnReservationCreatedCompleted { get; set; }

        /// <summary>
        /// Gets the availability.
        /// </summary>
        /// <param name="availabilityRequest">The availability request.</param>
        /// <returns></returns>
        public List<IFlight> GetAvailability(MyCTS.Entities.AvailabilityRequest availabilityRequest)
        {
            try
            {
                lock (thisLock)
                {

                    List<IFlight> Vuelos = new List<IFlight>();
                    List<IFlight> Vuelos2 = new List<IFlight>();
                    ISabreService openSessionService = new OpenSessionService();
                    IVolaris cliente = new VolarisClient();
                    List<VueloDisponible> disponibilidad = new List<VueloDisponible>();
                    if (!ciclo)
                    {
                        VolarisSession.Signature = cliente.AbrirConexion();
                    }

                    List<APIVolaris.TiposVolarisPassengerType> listPasajero = new List<APIVolaris.TiposVolarisPassengerType>();
                    VolarisSession.ListaTipoPassenger = new List<TiposVolaris.PassengerType>();

                    VolarisSession.ContAdult = availabilityRequest.Pasengers.Adult.Count + availabilityRequest.Pasengers.Senior.Count;
                    VolarisSession.ContInfant = availabilityRequest.Pasengers.Infant.Count;
                    VolarisSession.ContChild = availabilityRequest.Pasengers.Child.Count;

                    VolarisSession.contAdult = VolarisSession.ContAdult;
                    VolarisSession.contInfant = VolarisSession.ContInfant;
                    VolarisSession.contChild = VolarisSession.ContChild;

                    if (VolarisSession.ListaTipoPassenger.Count == 0)
                    {
                        for (int i = 0; i < availabilityRequest.Pasengers.Adult.Count; i++)
                        {
                            listPasajero.Add(APIVolaris.TiposVolarisPassengerType.Adult);
                            VolarisSession.ListaTipoPassenger.Add(TiposVolaris.PassengerType.Adult);
                        }
                        for (int i = 0; i < availabilityRequest.Pasengers.Child.Count; i++)
                        {
                            listPasajero.Add(APIVolaris.TiposVolarisPassengerType.Children);
                            VolarisSession.ListaTipoPassenger.Add(TiposVolaris.PassengerType.Children);
                        }
                        for (int i = 0; i < availabilityRequest.Pasengers.Infant.Count; i++)
                        {
                            listPasajero.Add(APIVolaris.TiposVolarisPassengerType.Infant);
                            VolarisSession.ListaTipoPassenger.Add(TiposVolaris.PassengerType.Infant);
                        }
                        for (int i = 0; i < availabilityRequest.Pasengers.Senior.Count; i++)
                        {
                            listPasajero.Add(APIVolaris.TiposVolarisPassengerType.Adult);
                            VolarisSession.ListaTipoPassenger.Add(TiposVolaris.PassengerType.Adult);
                        }
                    }
                    DateTime returnDate = new DateTime();
                    if (availabilityRequest.ReturningDateTime.ToString() != "")
                        returnDate = Convert.ToDateTime(availabilityRequest.ReturningDateTime.ToString());

                    if (string.IsNullOrEmpty(VolarisSession.DepartureRoute))
                    {
                        VolarisSession.DepartureRoute = availabilityRequest.DepartureStation + "-" + availabilityRequest.ArrivalStation;
                    }

                    VolarisPointToPoint pointToPoint = VolarisPointToPointBL.VolarisPointToPoint(availabilityRequest.DepartureStation, availabilityRequest.ArrivalStation);
                    VolarisSession.IsInternational = pointToPoint.IsInternational;

                    if (availabilityRequest.Type.ToString() == "SingleTrip")
                    {
                        VolarisSession.TypeFly = "SingleTrip";
                        disponibilidad = cliente.ObtenerDisponibilidad(availabilityRequest.DepartureStation, availabilityRequest.ArrivalStation, availabilityRequest.DepartureDateTime, returnDate, "MXN", APIVolaris.TiposVolarisFlightTypes.OnlyTrip, listPasajero, VolarisSession.Signature);
                    }
                    else if (availabilityRequest.Type.ToString() == "RoundTrip")
                    {
                        VolarisSession.TypeFly = "RoundTrip";
                        VolarisSession.ArrivalRoute = availabilityRequest.DepartureStation + "-" + availabilityRequest.ArrivalStation;
                        disponibilidad = cliente.ObtenerDisponibilidad(availabilityRequest.DepartureStation, availabilityRequest.ArrivalStation, availabilityRequest.DepartureDateTime, returnDate, "MXN", APIVolaris.TiposVolarisFlightTypes.RoundTrip, listPasajero, VolarisSession.Signature);
                    }
                    if (!ciclo)
                    {
                        dispVolaris = disponibilidad;
                        volarisVuelos = TranslateFromVueloDisponibleToVueloDisponibleMyCTS(dispVolaris);
                        ciclo = true;
                    }
                    Vuelos = TranslateFromVueloDisponibleToIFlight(dispVolaris);
                    Vuelos2= Vuelos.Where(f => f.BasePrice != 0).ToList();
                    VolarisSession.VuelosDisponibles = volarisVuelos.Where(h=>h.Amount!=0).ToList();
                    return Vuelos2;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal ObtenerVenta(VueloDisponibleMyCTS ida, VueloDisponibleMyCTS vuelta,List<TiposVolaris.PassengerType>passenger, TiposVolaris.FlightTypes tipoVuelo)
        {
            try
            {
                lock (thisLock)
                {
                    decimal venta = 0;
                    IVolaris cliente = new VolarisClient();
                    VueloDisponible vueltaAPI = null;
                    VueloDisponible idaAPI = TranslateFromVueloDisponibleMyCTSToVueloDisponible(ida);
                    if (vuelta != null)
                    {
                        vueltaAPI = TranslateFromVueloDisponibleMyCTSToVueloDisponible(vuelta);
                    }

                    List<TiposVolarisPassengerType> listPassenger = TranslateFromTiposVolarisPassengerTypeToAPITiposPassengerType(passenger);
                    TiposVolarisFlightTypes tipoVueloAPI = (TiposVolarisFlightTypes)tipoVuelo;
                    venta = cliente.ObtenerVenta(idaAPI, vueltaAPI, listPassenger, tipoVueloAPI);

                    
                    listExtras = new List<Entities.ExtrasViajeVolaris>();
                    foreach (Entities.SegmentoDeVuelo a in ida.Segments)
                    {
                        VolarisSession.TotalSegments = ida.Segments.Count;
                        SSRs(a);
                    }
                    if (vuelta != null)
                    {
                        foreach (Entities.SegmentoDeVuelo a in vuelta.Segments)
                        {
                            VolarisSession.TotalSegments = VolarisSession.TotalSegments + vuelta.Segments.Count;
                            SSRs(a);
                        }
                    }

                    VolarisSession.Extra = 0;
                    if (listExtras.Count > 0)
                    {
                        VolarisSession.Extra = ServiciosExtras(listExtras, VolarisSession.Signature);
                    }
                    listExtras.Clear();
                    if (VolarisSession.Extra > 0)
                    {
                        VolarisSession.Extra = VolarisSession.Extra - venta;
                        VolarisSession.Venta = venta;
                    }
                    else
                    {
                        VolarisSession.Extra = 0;
                        VolarisSession.Venta = venta;
                    }

                    decimal desc = 0;
                    decimal desc2 = 0;

                    for (int i = 0; i < VolarisSession.ItinerarioVolaris.Count; i++)
                    {
                        if (VolarisSession.TypeFly == "SingleTrip" && VolarisSession.Venta < (VolarisSession.ItinerarioVolaris[i].PrecioTotalAdult + VolarisSession.ItinerarioVolaris[i].PrecioTotalChild))
                        {
                            if (VolarisSession.ItinerarioVolaris[i].PrecioTotalAdult > 0 && VolarisSession.ItinerarioVolaris[i].PrecioTotalChild > 0)
                            {
                                desc = ((VolarisSession.ItinerarioVolaris[i].PrecioTotalAdult + VolarisSession.ItinerarioVolaris[i].PrecioTotalChild) - VolarisSession.Venta);
                                desc2 = (desc / 4);

                                VolarisSession.ItinerarioVolaris[i].PrecioBaseAdult = VolarisSession.ItinerarioVolaris[i].PrecioBaseAdult - desc2;
                                VolarisSession.ItinerarioVolaris[i].TaxAdult = VolarisSession.ItinerarioVolaris[i].TaxAdult - desc2;
                                VolarisSession.ItinerarioVolaris[i].PrecioTotalAdult = VolarisSession.ItinerarioVolaris[i].PrecioTotalAdult - (desc / 2);

                                VolarisSession.ItinerarioVolaris[i].PrecioBaseChild = VolarisSession.ItinerarioVolaris[i].PrecioBaseChild - desc2;
                                VolarisSession.ItinerarioVolaris[i].TaxChild = VolarisSession.ItinerarioVolaris[i].TaxChild - desc2;
                                VolarisSession.ItinerarioVolaris[i].PrecioTotalChild = VolarisSession.ItinerarioVolaris[i].PrecioTotalChild - (desc / 2);
                            }
                            else
                            {
                                if (VolarisSession.ItinerarioVolaris[i].PrecioTotalAdult > 0)
                                {
                                    desc = (VolarisSession.ItinerarioVolaris[i].PrecioTotalAdult - VolarisSession.Venta);
                                    desc2 = (desc / 2);
                                    VolarisSession.ItinerarioVolaris[i].PrecioBaseAdult = VolarisSession.ItinerarioVolaris[i].PrecioBaseAdult - desc2;
                                    VolarisSession.ItinerarioVolaris[i].TaxAdult = VolarisSession.ItinerarioVolaris[i].TaxAdult - desc2;
                                    VolarisSession.ItinerarioVolaris[i].PrecioTotalAdult = VolarisSession.Venta;
                                }
                                if (VolarisSession.ItinerarioVolaris[i].PrecioTotalChild > 0)
                                {
                                    desc = (VolarisSession.ItinerarioVolaris[i].PrecioTotalChild - VolarisSession.Venta);
                                    desc2 = (desc / 2);
                                    VolarisSession.ItinerarioVolaris[i].PrecioBaseChild = VolarisSession.ItinerarioVolaris[i].PrecioBaseChild - desc2;
                                    VolarisSession.ItinerarioVolaris[i].TaxChild = VolarisSession.ItinerarioVolaris[i].TaxChild - desc2;
                                    VolarisSession.ItinerarioVolaris[i].PrecioTotalChild = VolarisSession.Venta;
                                }

                            }
                        }
                        else if (VolarisSession.TypeFly == "RoundTrip" && VolarisSession.Venta < ((VolarisSession.ItinerarioVolaris[i].PrecioTotalAdult + VolarisSession.ItinerarioVolaris[i].PrecioTotalChild) * 2))
                        {
                            if (VolarisSession.ItinerarioVolaris[i].PrecioTotalAdult > 0 && VolarisSession.ItinerarioVolaris[i].PrecioTotalChild > 0)
                            {
                                if (desc == 0 && VolarisSession.ItinerarioVolaris.Count == 2)
                                {
                                    desc = (((VolarisSession.ItinerarioVolaris[0].PrecioTotalAdult + VolarisSession.ItinerarioVolaris[0].PrecioTotalChild)
                                        + (VolarisSession.ItinerarioVolaris[1].PrecioTotalAdult + VolarisSession.ItinerarioVolaris[1].PrecioTotalChild)) - VolarisSession.Venta);
                                    desc2 = (desc / 8);
                                }
                                else if (desc == 0 && VolarisSession.ItinerarioVolaris.Count == 4)
                                {
                                    desc = (((VolarisSession.ItinerarioVolaris[0].PrecioTotalAdult + VolarisSession.ItinerarioVolaris[0].PrecioTotalChild)
                                        + (VolarisSession.ItinerarioVolaris[2].PrecioTotalAdult + VolarisSession.ItinerarioVolaris[2].PrecioTotalChild)) - VolarisSession.Venta);
                                    desc2 = (desc / 8);
                                }

                                VolarisSession.ItinerarioVolaris[i].PrecioBaseAdult = VolarisSession.ItinerarioVolaris[i].PrecioBaseAdult - desc2;
                                VolarisSession.ItinerarioVolaris[i].TaxAdult = VolarisSession.ItinerarioVolaris[i].TaxAdult - desc2;
                                VolarisSession.ItinerarioVolaris[i].PrecioTotalAdult = VolarisSession.ItinerarioVolaris[i].PrecioBaseAdult + VolarisSession.ItinerarioVolaris[i].TaxAdult;

                                VolarisSession.ItinerarioVolaris[i].PrecioBaseChild = VolarisSession.ItinerarioVolaris[i].PrecioBaseChild - desc2;
                                VolarisSession.ItinerarioVolaris[i].TaxChild = VolarisSession.ItinerarioVolaris[i].TaxChild - desc2;
                                VolarisSession.ItinerarioVolaris[i].PrecioTotalChild = VolarisSession.ItinerarioVolaris[i].PrecioBaseChild + VolarisSession.ItinerarioVolaris[i].TaxChild;
                            }
                            else
                            {
                                if (VolarisSession.ItinerarioVolaris[i].PrecioTotalAdult > 0)
                                {
                                    if (desc == 0 && VolarisSession.ItinerarioVolaris.Count == 2)
                                    {
                                        desc = ((VolarisSession.ItinerarioVolaris[0].PrecioTotalAdult + VolarisSession.ItinerarioVolaris[1].PrecioTotalAdult) - VolarisSession.Venta);
                                        desc2 = (desc / 4);
                                    }
                                    else if (desc == 0 && VolarisSession.ItinerarioVolaris.Count == 4)
                                    {
                                        desc = ((VolarisSession.ItinerarioVolaris[0].PrecioTotalAdult + VolarisSession.ItinerarioVolaris[2].PrecioTotalAdult) - VolarisSession.Venta);
                                        desc2 = (desc / 4);
                                    }

                                    VolarisSession.ItinerarioVolaris[i].PrecioBaseAdult = VolarisSession.ItinerarioVolaris[i].PrecioBaseAdult - desc2;
                                    VolarisSession.ItinerarioVolaris[i].TaxAdult = VolarisSession.ItinerarioVolaris[i].TaxAdult - desc2;
                                    VolarisSession.ItinerarioVolaris[i].PrecioTotalAdult = VolarisSession.ItinerarioVolaris[i].PrecioBaseAdult + VolarisSession.ItinerarioVolaris[i].TaxAdult;
                                }
                                if (VolarisSession.ItinerarioVolaris[i].PrecioTotalChild > 0)
                                {
                                    if (desc == 0 && VolarisSession.ItinerarioVolaris.Count == 2)
                                    {
                                        desc = ((VolarisSession.ItinerarioVolaris[0].PrecioTotalChild + VolarisSession.ItinerarioVolaris[1].PrecioTotalChild) - VolarisSession.Venta);
                                        desc2 = (desc / 4);
                                    }
                                    else if (desc == 0 && VolarisSession.ItinerarioVolaris.Count == 4)
                                    {
                                        desc = ((VolarisSession.ItinerarioVolaris[0].PrecioTotalAdult + VolarisSession.ItinerarioVolaris[2].PrecioTotalAdult) - VolarisSession.Venta);
                                        desc2 = (desc / 4);
                                    }

                                    VolarisSession.ItinerarioVolaris[i].PrecioBaseChild = VolarisSession.ItinerarioVolaris[i].PrecioBaseChild - desc2;
                                    VolarisSession.ItinerarioVolaris[i].TaxChild = VolarisSession.ItinerarioVolaris[i].TaxChild - desc2;
                                    VolarisSession.ItinerarioVolaris[i].PrecioTotalChild = VolarisSession.ItinerarioVolaris[i].PrecioBaseChild + VolarisSession.ItinerarioVolaris[i].TaxChild;
                                }

                            }
                        }
                        else
                            break;
                    }

                    return venta;
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SSRs(Entities.SegmentoDeVuelo a)
        {
            int pax = 0;
            foreach (TiposVolarisPassengerType p in VolarisSession.ListaTipoPassenger)
            {
                if (p.ToString() == "Infant")
                {

                    Entities.ExtrasViajeVolaris extras = new Entities.ExtrasViajeVolaris();
                    extras.CodigoSSR = "INFT";
                    extras.Destino = a.ArrivalStation ;
                    extras.Origen = a.DepartureStation;
                    extras.NumeroPasajero = pax;
                    listExtras.Add(extras);
                    pax++;
                }
            }
        }

        public void ObtenerImpuestos()
        {
            try
            {
                lock (thisLock)
                {
                    IVolaris cliente = new VolarisClient();
                    MyCTS.Entities.BookingData booking = new MyCTS.Entities.BookingData();
                    booking = TranslateFromBokingDataAPIToBokingDataEntities(cliente.GetBookingFromState(VolarisSession.Signature));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
               
            decimal _11Mount = 0;
            decimal _16Mount = 0;
            decimal _11Iva = 0;
            decimal _16Iva = 0;


            decimal _11MountChild = 0;
            decimal _16MountChild = 0;
            decimal _11IvaChild = 0;
            decimal _16IvaChild = 0;
            lock (thisLock)
            {
                if (contMount > 0)
                {
                    for (int i = 0; i < contMount; i++)
                    {
                        if (contMount > 1 && i + 1 < contMount &&
                        VolarisSession.AdditionalAdult[i].Amount > VolarisSession.AdditionalAdult[i + 1].Amount &&
                        VolarisSession.AdditionalAdult[i].Iva > 0 && VolarisSession.AdditionalAdult[i + 1].Iva == 0)
                        {
                            VolarisSession.AdditionalAdult[i + 1].Iva = VolarisSession.AdditionalAdult[i].Iva;
                            VolarisSession.AdditionalAdult[i].Iva = 0;
                            string desc = VolarisSession.AdditionalAdult[i + 1].Description;
                            VolarisSession.AdditionalAdult[i + 1].Description = VolarisSession.AdditionalAdult[i].Description;
                            VolarisSession.AdditionalAdult[i].Description = desc;
                        }
                    }



                    foreach (AdditionalAccountingLine add in VolarisSession.AdditionalAdult)
                    {
                        if (add.Description == "11" && add.Iva > 0)
                        {
                            _11Mount = _11Mount + add.Amount;
                            _11Iva = _11Iva + add.Iva;
                        }
                        else if (add.Description == "16" && add.Iva > 0)
                        {
                            _16Mount = _16Mount + add.Amount;
                            _16Iva = _16Iva + add.Iva;
                        }
                        else if (add.Iva == 0)
                        {
                            _16Mount = _16Mount + add.Amount;
                            _16Iva = _16Iva + add.Iva;
                        }
                    }
                }

                if (contMountChild > 0)
                {
                    for (int i = 0; i < contMountChild; i++)
                    {
                        if (contMount > 1 && i + 1 < contMount &&
                        VolarisSession.AdditionalChild[i].Amount > VolarisSession.AdditionalChild[i + 1].Amount &&
                        VolarisSession.AdditionalChild[i].Iva > 0 && VolarisSession.AdditionalChild[i + 1].Iva == 0)
                        {
                            VolarisSession.AdditionalChild[i + 1].Iva = VolarisSession.AdditionalChild[i].Iva;
                            VolarisSession.AdditionalChild[i].Iva = 0;
                            string desc = VolarisSession.AdditionalChild[i + 1].Description;
                            VolarisSession.AdditionalChild[i + 1].Description = VolarisSession.AdditionalChild[i].Description;
                            VolarisSession.AdditionalChild[i].Description = desc;
                        }
                    }



                    foreach (AdditionalAccountingLine add in VolarisSession.AdditionalChild)
                    {
                        if (add.Description == "11" && add.Iva != 0)
                        {
                            _11MountChild = _11MountChild + add.Amount;
                            _11IvaChild = _11IvaChild + add.Iva;
                        }
                        else if (add.Description == "16" && add.Iva != 0)
                        {
                            _16MountChild = _16MountChild + add.Amount;
                            _16IvaChild = _16IvaChild + add.Iva;
                        }
                        else if (add.Iva == 0)
                        {
                            _16MountChild = _16MountChild + add.Amount;
                            _16IvaChild = _16IvaChild + add.Iva;
                        }
                    }
                }

                VolarisSession.AdditionalAdult = new List<AdditionalAccountingLine>();
                VolarisSession.AdditionalChild = new List<AdditionalAccountingLine>();
                VolarisSession.additionalAdult = new List<AdditionalAccountingLine>();
                VolarisSession.additionalChild = new List<AdditionalAccountingLine>();

                string monto16Adt = string.Empty;
                string monto16Chd = string.Empty;
                int z = 0;
                int w = 0;
                if (_11Mount > 0)
                {
                    VolarisSession.AdditionalAdult.Add(new AdditionalAccountingLine());
                    VolarisSession.AdditionalAdult[z].Amount = _11Mount;
                    VolarisSession.AdditionalAdult[z].Iva = _11Iva;
                    VolarisSession.AdditionalAdult[z].Description = "11";
                    z++;
                }
                if (_16Mount > 0)
                {
                    VolarisSession.AdditionalAdult.Add(new AdditionalAccountingLine());
                    VolarisSession.AdditionalAdult[z].Amount = _16Mount;
                    VolarisSession.AdditionalAdult[z].Iva = _16Iva;
                    VolarisSession.AdditionalAdult[z].Description = "16";

                    VolarisSession.additionalAdult.Add(new AdditionalAccountingLine());
                    VolarisSession.additionalAdult[z].Amount = _16Mount;
                    VolarisSession.additionalAdult[z].Iva=_16Iva;
                    VolarisSession.additionalAdult[z].Description="16";

                    //Quitar
                    monto16Adt = "ADT" + _16Mount.ToString("#.00") + _16Iva.ToString("#.00") ;
                }
                if (_11MountChild > 0)
                {
                    VolarisSession.AdditionalChild.Add(new AdditionalAccountingLine());
                    VolarisSession.AdditionalChild[w].Amount = _11MountChild;
                    VolarisSession.AdditionalChild[w].Iva = _11IvaChild;
                    VolarisSession.AdditionalChild[w].Description = "11";
                    w++;
                }
                if (_16MountChild > 0)
                {
                    VolarisSession.AdditionalChild.Add(new AdditionalAccountingLine());
                    VolarisSession.AdditionalChild[w].Amount = _16MountChild;
                    VolarisSession.AdditionalChild[w].Iva = _16IvaChild;
                    VolarisSession.AdditionalChild[w].Description = "16";

                    VolarisSession.additionalChild.Add(new AdditionalAccountingLine());
                    VolarisSession.additionalChild[w].Amount = _16MountChild;
                    VolarisSession.additionalChild[w].Iva = _16IvaChild;
                    VolarisSession.additionalChild[w].Description = "16";
                    w++;
                    //Quitar
                    monto16Chd = "CHD" + _16MountChild.ToString("#.00") + _16IvaChild.ToString("#.00") ;

                }
                //Recordar quitar
                ImpuestosBajoCosto.ImpuestosObtenidos = ImpuestosBajoCosto.ImpuestosObtenidos + monto16Adt + monto16Chd;
                ImpuestosBajoCostoBL.UpdateImpuestosBajoCosto(ImpuestosBajoCosto.Id, ImpuestosBajoCosto.ImpuestosObtenidos, string.Empty, string.Empty, string.Empty, string.Empty);
            }
        }

        public string PagarReservacion(MyCTS.Entities.MetodoPagoVolaris metodoPago)
        {
            try
            {
                lock (thisLock)
                {
                    string reservationPay = string.Empty;
                    IVolaris cliente = new VolarisClient();
                    MyCTS.Services.APIVolaris.MetodoPagoVolaris newMetodoPago = TranslateFormMedodoPagoVolarisEntitiesToAPI(metodoPago);
                    MyCTS.Services.APIVolaris.Contact newContact = TranslateFormContactVolarisEntitiesToContact();
                    reservationPay = cliente.PagarReservacion(newMetodoPago, newContact, VolarisSession.Signature);

                    //System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(reservationPay.GetType());
                    //System.IO.StreamWriter file = new System.IO.StreamWriter(@"c:\RESP\VolarisPaymentResponse" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
                    //writer.Serialize(file, reservationPay);
                    //file.Close();

                    return reservationPay;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ConfirmarReservacion(string recordLocator)
        {
            try
            {
                string confirmationPay = string.Empty;
                IVolaris cliente = new VolarisClient();
                confirmationPay = cliente.ConfirmacionReservacion(recordLocator, VolarisSession.Signature);
                return confirmationPay;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CloseReservation()
        {
            IVolaris cliente = new VolarisClient();
            try
            {
                if (!string.IsNullOrEmpty(VolarisSession.Signature))
                {
                    cliente.CerrarConexion(VolarisSession.Signature);
                    VolarisSession.Signature = string.Empty;
                }
            }
            catch (Exception ex)
            {
                if (ex.ToString() == "Session token authentication failure")
                    VolarisSession.Signature = string.Empty;
            }
        }

        public MyCTS.Services.APIVolaris.MetodoPagoVolaris TranslateFormMedodoPagoVolarisEntitiesToAPI(MyCTS.Entities.MetodoPagoVolaris metodoPago)
        {
            MyCTS.Services.APIVolaris.MetodoPagoVolaris pagoAPI = new APIVolaris.MetodoPagoVolaris();
            pagoAPI.Apellido = metodoPago.Apellido;
            pagoAPI.Ciudad = metodoPago.Ciudad;
            pagoAPI.CodigoPais = metodoPago.CodigoPais;
            pagoAPI.CodigoPostal = metodoPago.CodigoPostal;
            pagoAPI.CodigoSeguridad = metodoPago.CodigoSeguridad;
            pagoAPI.Direccion = metodoPago.Direccion;
            pagoAPI.Email = metodoPago.Email;
            pagoAPI.EstadoProvincia = metodoPago.EstadoProvincia;
            pagoAPI.MetodoDePago = metodoPago.MetodoDePago;
            pagoAPI.FechaExpiracion = metodoPago.FechaExpiracion;
            pagoAPI.Moneda = metodoPago.Moneda;
            pagoAPI.Monto = metodoPago.Monto;
            pagoAPI.NumeroAgencia = metodoPago.NumeroAgencia;
            pagoAPI.NumeroTarjeta = metodoPago.NumeroTarjeta;
            pagoAPI.Telefono = metodoPago.Telefono;
            pagoAPI.TipoMetodoPago = (TiposVolarisPaymentMethodType)metodoPago.TipoMetodoPago;
            pagoAPI.TipoTarjeta = metodoPago.TipoTarjeta;
            pagoAPI.Titular = metodoPago.Titular;
            pagoAPI.IP = metodoPago.IP;
            pagoAPI.BlackBox = metodoPago.BlackBox;
            return pagoAPI;
        }

        public MyCTS.Services.APIVolaris.Contact TranslateFormContactVolarisEntitiesToContact()
        {
            MyCTS.Services.APIVolaris.Contact contact = new Contact();
            contact.Address = VolarisSession.Contacto.Address;
            contact.City = VolarisSession.Contacto.City;
            contact.CountryCode = VolarisSession.Contacto.CountryCode;
            contact.Email = VolarisSession.Contacto.Email;
            contact.FirstName = VolarisSession.Contacto.FirstName;
            contact.HomePhone = VolarisSession.Contacto.HomePhone;
            contact.LastName = VolarisSession.Contacto.LastName;
            contact.PostalCode = VolarisSession.Contacto.PostalCode;
            contact.Title = VolarisSession.Contacto.Title;
            return contact;
        }

        public List<TiposVolarisPassengerType> TranslateFromTiposVolarisPassengerTypeToAPITiposPassengerType(List<TiposVolaris.PassengerType> passenger)
        {
            List<TiposVolarisPassengerType> listaPassenger = new List<TiposVolarisPassengerType>();
            for (int i = 0; i < passenger.Count; i++)
            {
                TiposVolarisPassengerType tipoPassenger = new TiposVolarisPassengerType();
                if (passenger[i].ToString() == "Adult")
                    tipoPassenger = TiposVolarisPassengerType.Adult;
                if (passenger[i].ToString() == "Children")
                    tipoPassenger = TiposVolarisPassengerType.Children;

                if (passenger[i].ToString() == "Infant")
                    tipoPassenger = TiposVolarisPassengerType.Infant;
                else
                    listaPassenger.Add(tipoPassenger);
            }
            return listaPassenger;
        }

        public VueloDisponible TranslateFromVueloDisponibleMyCTSToVueloDisponible(VueloDisponibleMyCTS vueloMCTS)
        {
                VueloDisponible vuelo = new VueloDisponible();
                vuelo.Amountk__BackingField = vueloMCTS.Amount;
                vuelo.TypeFlightk__BackingField =(TiposVolarisFlightFullType) vueloMCTS.TypeFlight;
                vuelo.Segmentsk__BackingField = TranslateFromSegmentoVueloEntitiesToAPISegmentoVuelo(vueloMCTS.Segments);
                vuelo.Signaturek__BackingField = vueloMCTS.Signature;
                vuelo.Taxk__BackingField = vueloMCTS.Tax;
                vuelo.ContractVersionk__BackingField = vueloMCTS.ContractVersion;
                vuelo.CountFaresk__BackingField = vueloMCTS.CountFares;
                vuelo.FareSellKeyk__BackingField = vueloMCTS.FareSellKey;
                vuelo.JourneySellKeyk__BackingField = vueloMCTS.JourneySellKey;
                return vuelo;
        }

        private List<MyCTS.Services.APIVolaris.SegmentoDeVuelo> TranslateFromSegmentoVueloEntitiesToAPISegmentoVuelo(List<MyCTS.Entities.SegmentoDeVuelo> segmentoVuelo)
        {
            List<MyCTS.Services.APIVolaris.SegmentoDeVuelo> tipoSegmento = new List<MyCTS.Services.APIVolaris.SegmentoDeVuelo>();
            for (int i = 0; i < segmentoVuelo.Count; i++)
            {
                MyCTS.Services.APIVolaris.SegmentoDeVuelo tipoSegVolaris = new MyCTS.Services.APIVolaris.SegmentoDeVuelo();

                tipoSegVolaris.FlightNumberk__BackingField = segmentoVuelo[i].FlightNumber;
                tipoSegVolaris.ArrivalStationk__BackingField = segmentoVuelo[i].ArrivalStation;
                tipoSegVolaris.ArrivalStationDateTimek__BackingField = segmentoVuelo[i].ArrivalStationDateTime;
                tipoSegVolaris.DepartureDateTimek__BackingField = segmentoVuelo[i].DepartureDateTime;
                tipoSegVolaris.DepartureStationk__BackingField = segmentoVuelo[i].DepartureStation;
                tipoSegmento.Add(tipoSegVolaris);
            }
            return tipoSegmento;
        }

        public MyCTS.Entities.BookingData TranslateFromBokingDataAPIToBokingDataEntities(MyCTS.Services.APIVolaris.BookingData booking)
        {


            //System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(booking.GetType());
            //System.IO.StreamWriter file = new System.IO.StreamWriter(@"c:\RESP\ItineraryPriceReqVolaris " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
            //writer.Serialize(file, booking);
            //file.Close();

            lock (thisLock)
            {
                MyCTS.Entities.BookingData bookingData = ConstructBody(booking);
                Entities.PaxFare paxFare = new Entities.PaxFare();
                Entities.BookingServiceCharge serviceCharges = new Entities.BookingServiceCharge();

                decimal tua = 0;
                decimal iva = 0;
                decimal otrosImpuestos = 0;
                decimal tarifaBase = 0;
                decimal discount = 0;

                decimal tuaChild = 0;
                decimal ivaChild = 0;
                decimal otrosImpuestosChild = 0;
                decimal tarifaBaseChild = 0;
                bool pass = false;
                bool passChild = false;
                decimal discountChild = 0;

                contMount = 0;
                contIva = 0;
                contIvaChild = 0;
                contMountChild = 0;
                contPsf = 0;
                contPsfChild = 0;
                psfAdult = new List<AdditionalAccountingLine>();
                psfChild = new List<AdditionalAccountingLine>();
                VolarisSession.BaseTotalPayAdult = 0;
                VolarisSession.BaseTotalPayChild = 0;
                bool first = false;
                bool firstChild = false;

                VolarisSession.AdditionalAdult = new List<AdditionalAccountingLine>();
                VolarisSession.AdditionalChild = new List<AdditionalAccountingLine>();
                //recordar quitar
                string impuestos = string.Empty;

                VolarisSession.baseTotalPayChild = 0;
                VolarisSession.ivaTotalPayChild = 0;
                VolarisSession.tuaTotalPayChild = 0;
                VolarisSession.otrosTotalPayChild = 0;

                VolarisSession.baseTotalPayAdult = 0;
                VolarisSession.ivaTotalPayAdult = 0;
                VolarisSession.tuaTotalPayAdult = 0;
                VolarisSession.otrosTotalPayAdult = 0;


                for (int i = 0; i < bookingData.Journeys.Count(); i++)
                {
                    VolarisSession.ItinerarioVolaris[i].BookingData = new List<Entities.BookingServiceCharge>();
                    VolarisSession.ItinerarioVolaris[i].SegmentTaxes = new List<SegmentTaxes>();

                    for (int j = 0; j < bookingData.Journeys[i].Segments.Count(); j++)
                    {
                        VolarisSession.ItinerarioVolaris[i].SegmentTaxes.Add(new SegmentTaxes());
                        tua = 0;
                        iva = 0;
                        otrosImpuestos = 0;
                        discount = 0;
                        tuaChild = 0;
                        ivaChild = 0;
                        otrosImpuestosChild = 0;
                        tarifaBase = 0;
                        tarifaBaseChild = 0;
                        discountChild = 0;

                        for (int l = 0; l < bookingData.Journeys[i].Segments[j].Fares.Count(); l++)
                        {
                            for (int k = 0; k < bookingData.Journeys[i].Segments[j].Fares[l].PaxFares.Count(); k++)
                            {
                                paxFare = new Entities.PaxFare()
                                {
                                    PaxType = booking.Journeys[i].Segments[j].Fares[l].PaxFares[k].PaxType
                                };
                                bookingData.Journeys[i].Segments[j].Fares[l].PaxFares[k].PaxType = paxFare.PaxType;

                                for (int m = 0; m < bookingData.Journeys[i].Segments[j].Fares[l].PaxFares[k].ServiceCharges.Count(); m++)
                                {
                                    serviceCharges = new Entities.BookingServiceCharge()
                                    {
                                        ChargeType = (MyCTS.Entities.ChargeType)Convert.ToInt32(booking.Journeys[i].Segments[j].Fares[l].PaxFares[k].ServiceCharges[m].ChargeType),
                                        ChargeCode = booking.Journeys[i].Segments[j].Fares[l].PaxFares[k].ServiceCharges[m].ChargeCode.ToString(),
                                        Amount = booking.Journeys[i].Segments[j].Fares[l].PaxFares[k].ServiceCharges[m].Amount,
                                        ChargeDetail = booking.Journeys[i].Segments[j].Fares[l].PaxFares[k].ServiceCharges[m].ChargeDetail
                                    };
                                    bookingData.Journeys[i].Segments[j].Fares[l].PaxFares[k].ServiceCharges[m] = serviceCharges;
                                    VolarisSession.ItinerarioVolaris[i].BookingData.Add(serviceCharges);
                                    if (paxFare.PaxType == "ADT")
                                    {
                                        impuestos = impuestos + "ADT ";
                                        if (serviceCharges.ChargeType.ToString() == "Discount")
                                        {
                                            impuestos = impuestos + serviceCharges.ChargeType.ToString() + " " + serviceCharges.Amount.ToString("#.00");
                                            discount = discount + serviceCharges.Amount;
                                            VolarisSession.ItinerarioVolaris[i].SegmentTaxes[j].DiscountAdult = (discount * VolarisSession.ContAdult);
                                        }
                                        else if (serviceCharges.ChargeCode.Contains("XV") || serviceCharges.ChargeCode.Contains("XD"))
                                        {
                                            impuestos = impuestos + serviceCharges.ChargeCode.ToString() + " " + serviceCharges.Amount.ToString("#.00");
                                            tua = tua + serviceCharges.Amount;
                                            VolarisSession.ItinerarioVolaris[i].SegmentTaxes[j].TUAAdult = (tua * VolarisSession.ContAdult);
                                            VolarisSession.tuaTotalPayAdult = VolarisSession.tuaTotalPayAdult + serviceCharges.Amount;
                                        }
                                        else if (serviceCharges.ChargeCode.Contains("MX") || serviceCharges.ChargeCode.Contains("XO"))
                                        {
                                            impuestos = impuestos + serviceCharges.ChargeCode.ToString() + " " + serviceCharges.Amount.ToString("#.00");
                                            iva = iva + serviceCharges.Amount;
                                            VolarisSession.ItinerarioVolaris[i].SegmentTaxes[j].IVAAdult = (iva * VolarisSession.ContAdult);
                                            VolarisSession.ivaTotalPayAdult = VolarisSession.ivaTotalPayAdult + serviceCharges.Amount;

                                        }
                                        else if (serviceCharges.ChargeCode == "CFOT" || serviceCharges.ChargeCode.Contains("PSF") ||
                                            serviceCharges.ChargeCode == "MO" || serviceCharges.ChargeCode == "OXS")
                                        {
                                            impuestos = impuestos + serviceCharges.ChargeCode.ToString() + " " + serviceCharges.Amount.ToString("#.00");
                                            if (contMount > contIva && i == 1 && !pass && !first)
                                            {
                                                contIva = contMount;
                                                pass = true;
                                            }
                                            if (contMount < contIva && i == 1 && !pass && !first)
                                            {
                                                contMount = contIva;
                                                pass = true;
                                            }

                                            if (serviceCharges.ChargeCode.Contains("CFOT") || serviceCharges.ChargeCode.Contains("PSF"))
                                            {

                                                VolarisSession.AdditionalAdult.Add(new AdditionalAccountingLine());
                                                VolarisSession.AdditionalAdult[contMount].Amount = (serviceCharges.Amount);
                                                VolarisSession.AdditionalAdult[contMount].Iva = 0;
                                                VolarisSession.AdditionalAdult[contMount].Description = string.Empty;
                                                VolarisSession.AdditionalAdult[contMount].jorney = i;
                                                contMount++;
                                                if (i == 1)
                                                    first = true;
                                            }
                                            else if (serviceCharges.ChargeCode == "MO" || serviceCharges.ChargeCode == "OXS")
                                            {

                                                if (serviceCharges.ChargeCode == "MO")
                                                {
                                                    try
                                                    {
                                                        VolarisSession.AdditionalAdult[contIva].Iva = (serviceCharges.Amount);
                                                        VolarisSession.AdditionalAdult[contIva].Description = "16";
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        VolarisSession.AdditionalAdult.Add(new AdditionalAccountingLine());
                                                        VolarisSession.AdditionalAdult[contIva].Amount = 0;
                                                        VolarisSession.AdditionalAdult[contIva].Iva = (serviceCharges.Amount);
                                                        VolarisSession.AdditionalAdult[contIva].Description = "16";
                                                        VolarisSession.AdditionalAdult[contIva].jorney = i;
                                                    }
                                                }
                                                else if (serviceCharges.ChargeCode == "OXS")
                                                {
                                                    try
                                                    {
                                                        VolarisSession.AdditionalAdult[contIva].Iva = (serviceCharges.Amount);
                                                        VolarisSession.AdditionalAdult[contIva].Description = "11";
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        VolarisSession.AdditionalAdult.Add(new AdditionalAccountingLine());
                                                        VolarisSession.AdditionalAdult[contIva].Amount = 0;
                                                        VolarisSession.AdditionalAdult[contIva].Iva = (serviceCharges.Amount);
                                                        VolarisSession.AdditionalAdult[contIva].Description = "11";
                                                        VolarisSession.AdditionalAdult[contIva].jorney = i;
                                                    }
                                                }
                                                contIva++;
                                                if (i == 1)
                                                    first = true;
                                            }
                                        }
                                        else if (!string.IsNullOrEmpty(serviceCharges.ChargeCode))
                                        {
                                            impuestos = impuestos + serviceCharges.ChargeCode.ToString() + " " + serviceCharges.Amount.ToString("#.00");
                                            otrosImpuestos = otrosImpuestos + serviceCharges.Amount;
                                            VolarisSession.ItinerarioVolaris[i].SegmentTaxes[j].OtrosImpuestosAdult = (otrosImpuestos * VolarisSession.ContAdult);
                                            VolarisSession.otrosTotalPayAdult = VolarisSession.otrosTotalPayAdult + serviceCharges.Amount;

                                        }
                                        else if (serviceCharges.ChargeType.ToString() == "FarePrice")
                                        {
                                            impuestos = impuestos + serviceCharges.ChargeType.ToString() + " " + serviceCharges.Amount.ToString("#.00");
                                            tarifaBase = tarifaBase + serviceCharges.Amount;
                                            VolarisSession.ItinerarioVolaris[i].SegmentTaxes[j].TarifaBaseAdult = (tarifaBase * VolarisSession.ContAdult);
                                            VolarisSession.baseTotalPayAdult = VolarisSession.baseTotalPayAdult + serviceCharges.Amount;

                                        }
                                    }
                                    else if (paxFare.PaxType == "CHD")
                                    {
                                        impuestos = impuestos + " CHD ";

                                        if (serviceCharges.ChargeType.ToString() == "Discount")
                                        {
                                            impuestos = impuestos + serviceCharges.ChargeType.ToString() + " " + serviceCharges.Amount.ToString("#.00");
                                            discountChild = discountChild + serviceCharges.Amount;
                                            VolarisSession.ItinerarioVolaris[i].SegmentTaxes[j].DiscountChild = (discountChild * VolarisSession.ContChild);
                                        }
                                        else if (serviceCharges.ChargeCode.Contains("XV") || serviceCharges.ChargeCode.Contains("XD"))
                                        {
                                            impuestos = impuestos + serviceCharges.ChargeCode.ToString() + " " + serviceCharges.Amount.ToString("#.00");
                                            tuaChild = tuaChild + serviceCharges.Amount;
                                            VolarisSession.ItinerarioVolaris[i].SegmentTaxes[j].TUAChild = (tuaChild * VolarisSession.ContChild);
                                            VolarisSession.tuaTotalPayChild = VolarisSession.tuaTotalPayChild + serviceCharges.Amount;
                                        }
                                        else if (serviceCharges.ChargeCode.Contains("MX") || serviceCharges.ChargeCode.Contains("XO"))
                                        {
                                            impuestos = impuestos + serviceCharges.ChargeCode.ToString() + " " + serviceCharges.Amount.ToString("#.00");
                                            ivaChild = ivaChild + serviceCharges.Amount;
                                            VolarisSession.ItinerarioVolaris[i].SegmentTaxes[j].IVAChild = (ivaChild * VolarisSession.ContChild);
                                            VolarisSession.ivaTotalPayChild = VolarisSession.ivaTotalPayChild + serviceCharges.Amount;

                                        }
                                        else if (serviceCharges.ChargeCode == "CFOT" || serviceCharges.ChargeCode.Contains("PSF") ||
                                            serviceCharges.ChargeCode == "MO" || serviceCharges.ChargeCode == "OXS")
                                        {
                                            impuestos = impuestos + serviceCharges.ChargeCode.ToString() + " " + serviceCharges.Amount.ToString("#.00");

                                            if (contMountChild > contIvaChild && i == 1 && !passChild && !firstChild)
                                            {
                                                contIvaChild = contMountChild;
                                                passChild = true;
                                            }
                                            if (contMountChild < contIvaChild && i == 1 && !passChild && !firstChild)
                                            {
                                                contMountChild = contIvaChild;
                                                passChild = true;
                                            }

                                            if (serviceCharges.ChargeCode == "CFOT" || serviceCharges.ChargeCode.Contains("PSF"))
                                            {
                                                VolarisSession.AdditionalChild.Add(new AdditionalAccountingLine());
                                                VolarisSession.AdditionalChild[contMountChild].Amount = (serviceCharges.Amount);
                                                VolarisSession.AdditionalChild[contMountChild].Iva = 0;
                                                VolarisSession.AdditionalChild[contMountChild].Description = string.Empty;
                                                VolarisSession.AdditionalChild[contMountChild].jorney = i;
                                                contMountChild++;
                                                if (i == 1)
                                                    firstChild = true;
                                            }
                                            else if (serviceCharges.ChargeCode == "MO" || serviceCharges.ChargeCode == "OXS")
                                            {
                                                if (serviceCharges.ChargeCode == "MO")
                                                {
                                                    try
                                                    {
                                                        VolarisSession.AdditionalChild[contIvaChild].Iva = (serviceCharges.Amount);
                                                        VolarisSession.AdditionalChild[contIvaChild].Description = "16";
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        VolarisSession.AdditionalChild.Add(new AdditionalAccountingLine());
                                                        VolarisSession.AdditionalChild[contIvaChild].Amount = 0;
                                                        VolarisSession.AdditionalChild[contIvaChild].Iva = (serviceCharges.Amount);
                                                        VolarisSession.AdditionalChild[contIvaChild].Description = "16";
                                                        VolarisSession.AdditionalChild[contIvaChild].jorney = i;
                                                    }
                                                }
                                                else if (serviceCharges.ChargeCode == "OXS")
                                                {
                                                    try
                                                    {
                                                        VolarisSession.AdditionalChild[contIvaChild].Iva = (serviceCharges.Amount);
                                                        VolarisSession.AdditionalChild[contIvaChild].Description = "11";
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        VolarisSession.AdditionalChild.Add(new AdditionalAccountingLine());
                                                        VolarisSession.AdditionalChild[contIvaChild].Amount = 0;
                                                        VolarisSession.AdditionalChild[contIvaChild].Iva = (serviceCharges.Amount);
                                                        VolarisSession.AdditionalChild[contIvaChild].Description = "11";
                                                        VolarisSession.AdditionalChild[contIvaChild].jorney = i;
                                                    }
                                                }
                                                contIvaChild++;
                                                if (i == 1)
                                                    firstChild = true;
                                            }
                                        }
                                        else if (!string.IsNullOrEmpty(serviceCharges.ChargeCode))
                                        {
                                            impuestos = impuestos + serviceCharges.ChargeCode.ToString() + " " + serviceCharges.Amount.ToString("#.00");
                                            otrosImpuestosChild = otrosImpuestosChild + serviceCharges.Amount;
                                            VolarisSession.ItinerarioVolaris[i].SegmentTaxes[j].OtrosImpuestosChild = (otrosImpuestosChild * VolarisSession.ContChild);
                                            VolarisSession.otrosTotalPayChild = VolarisSession.otrosTotalPayChild + serviceCharges.Amount;

                                        }
                                        else if (serviceCharges.ChargeType.ToString() == "FarePrice")
                                        {
                                            impuestos = impuestos + serviceCharges.ChargeType.ToString() + " " + serviceCharges.Amount.ToString("#.00");
                                            tarifaBaseChild = tarifaBaseChild + serviceCharges.Amount;
                                            VolarisSession.ItinerarioVolaris[i].SegmentTaxes[j].TarifaBaseChild = (tarifaBaseChild * VolarisSession.ContChild);
                                            VolarisSession.baseTotalPayChild = VolarisSession.baseTotalPayChild + serviceCharges.Amount;
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
                //Recordar quitar
                Guid g = Guid.NewGuid();
                ImpuestosBajoCosto.Id = g.ToString();
                ImpuestosBajoCosto.ImpuestosObtenidos = string.Empty;
                ImpuestosBajoCosto.ImpuestosObtenidos = impuestos;
                ImpuestosBajoCostoBL.InsertImpuestosBajoCosto(ImpuestosBajoCosto.Id, ImpuestosBajoCosto.ImpuestosObtenidos, string.Empty, string.Empty, string.Empty, string.Empty);

                if (bookingData.Journeys.Count() > 0)
                {
                    int cont = 0;
                    for (int a = 0; a < bookingData.Journeys.Count(); a++)
                    {
                        for (int b = 0; b < VolarisSession.ItinerarioVolaris[a].SegmentTaxes.Count; b++)
                        {
                            VolarisSession.ItinerarioVolaris[cont].PrecioBaseAdult = VolarisSession.ItinerarioVolaris[a].SegmentTaxes[b].TarifaBaseAdult;
                            VolarisSession.BaseTotalPayAdult = VolarisSession.BaseTotalPayAdult + VolarisSession.ItinerarioVolaris[cont].PrecioBaseAdult;

                            VolarisSession.ItinerarioVolaris[cont].IVAAdult = VolarisSession.ItinerarioVolaris[a].SegmentTaxes[b].IVAAdult;
                            VolarisSession.IVATotalPayAdult = VolarisSession.IVATotalPayAdult + VolarisSession.ItinerarioVolaris[cont].IVAAdult;

                            VolarisSession.ItinerarioVolaris[cont].OtrosImpuestosAdult = VolarisSession.ItinerarioVolaris[a].SegmentTaxes[b].OtrosImpuestosAdult;
                            VolarisSession.OtrosTotalPayAdult = VolarisSession.OtrosTotalPayAdult + VolarisSession.ItinerarioVolaris[cont].OtrosImpuestosAdult;

                            VolarisSession.ItinerarioVolaris[cont].TUAAdult = VolarisSession.ItinerarioVolaris[a].SegmentTaxes[b].TUAAdult;
                            VolarisSession.TUATotalPayAdult = VolarisSession.TUATotalPayAdult + VolarisSession.ItinerarioVolaris[cont].TUAAdult;

                            VolarisSession.ItinerarioVolaris[cont].DiscountAdult = VolarisSession.ItinerarioVolaris[a].SegmentTaxes[b].DiscountAdult;
                            VolarisSession.DiscountTotalPayAdult = VolarisSession.DiscountTotalPayAdult + VolarisSession.ItinerarioVolaris[cont].DiscountAdult;


                            VolarisSession.ItinerarioVolaris[cont].PrecioBaseChild = VolarisSession.ItinerarioVolaris[a].SegmentTaxes[b].TarifaBaseChild;
                            VolarisSession.BaseTotalPayChild = VolarisSession.BaseTotalPayChild + VolarisSession.ItinerarioVolaris[cont].PrecioBaseChild;


                            VolarisSession.ItinerarioVolaris[cont].IVAChild = VolarisSession.ItinerarioVolaris[a].SegmentTaxes[b].IVAChild;
                            VolarisSession.IVATotalPayChild = VolarisSession.IVATotalPayChild + VolarisSession.ItinerarioVolaris[cont].IVAChild;

                            VolarisSession.ItinerarioVolaris[cont].OtrosImpuestosChild = VolarisSession.ItinerarioVolaris[a].SegmentTaxes[b].OtrosImpuestosChild;
                            VolarisSession.OtrosTotalPayChild = VolarisSession.OtrosTotalPayChild + VolarisSession.ItinerarioVolaris[cont].OtrosImpuestosChild;

                            VolarisSession.ItinerarioVolaris[cont].TUAChild = VolarisSession.ItinerarioVolaris[a].SegmentTaxes[b].TUAChild;
                            VolarisSession.TUATotalPayChild = VolarisSession.TUATotalPayChild + VolarisSession.ItinerarioVolaris[cont].TUAChild;

                            VolarisSession.ItinerarioVolaris[cont].DiscountChild = VolarisSession.ItinerarioVolaris[a].SegmentTaxes[b].DiscountChild;
                            VolarisSession.DiscountTotalPayChild = VolarisSession.DiscountTotalPayChild + VolarisSession.ItinerarioVolaris[cont].DiscountChild;
                            cont++;
                        }
                    }
                }
                return bookingData;
            }
        }

        public MyCTS.Entities.BookingData ConstructBody(MyCTS.Services.APIVolaris.BookingData booking)
        {
            MyCTS.Entities.BookingData bookingData = new MyCTS.Entities.BookingData();
            bookingData.Journeys = new List<Entities.Journey>();

            for (int i = 0; i < booking.Journeys.Count(); i++)
            {
                bookingData.Journeys.Add(new Entities.Journey());
                for (int j = 0; j < booking.Journeys[i].Segments.Count(); j++)
                {
                    bookingData.Journeys[i].Segments.Add(new Entities.Segment());
                    for (int k = 0; k < booking.Journeys[i].Segments[j].Fares.Count(); k++)
                    {
                        bookingData.Journeys[i].Segments[j].Fares.Add(new Entities.Fare());
                        for (int l = 0; l < booking.Journeys[i].Segments[j].Fares[k].PaxFares.Count(); l++)
                        {
                            bookingData.Journeys[i].Segments[j].Fares[k].PaxFares.Add(new Entities.PaxFare());
                            for (int m = 0; m < booking.Journeys[i].Segments[j].Fares[k].PaxFares[l].ServiceCharges.Count(); m++)
                            {
                                bookingData.Journeys[i].Segments[j].Fares[k].PaxFares[l].ServiceCharges.Add(new Entities.BookingServiceCharge());
                            }
                        }
                    }
                }
            }

            return bookingData;
        }

        public MyCTS.Services.APIVolaris.BookingData GetBookingFromState(string signature)
        {
            try
            {
                lock (thisLock)
                {
                    MyCTS.Services.APIVolaris.BookingData booking = new MyCTS.Services.APIVolaris.BookingData();
                    IVolaris cliente = new VolarisClient();
                    booking = cliente.GetBookingFromState(signature);
                    //new Logging(booking);
                    return booking;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AgregarPasajeros(List<MyCTS.Entities.PasajerosVolaris> pasajeros, string signature)
        {
            try
            {
                lock (thisLock)
                {
                    int cantidad;
                    IVolaris cliente = new VolarisClient();
                    cantidad = cliente.AgregarPasajeros(TranslateFromPajaeroEntitiesToPasajeroAPI(pasajeros), signature);
                   // new Logging(cantidad);
                    return cantidad;
                }
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("Age is not"))
                    VolarisSession.ReturnShowInformation = true;
                throw ex;
            }
        }

        public decimal ServiciosExtras(List<MyCTS.Entities.ExtrasViajeVolaris> extras, string signature)
        {
            try
            {
                lock (thisLock)
                {
                    decimal cantidad = 0;
                    IVolaris cliente = new VolarisClient();
                    cantidad = cliente.AgregarExtras(TranslateFromVolarisServicesExtrasToExtrasViajeVolaris(extras), signature);
                    return cantidad;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MyCTS.Services.APIVolaris.ExtrasViajeVolaris> TranslateFromVolarisServicesExtrasToExtrasViajeVolaris(List<MyCTS.Entities.ExtrasViajeVolaris> extras)
        {
            List<MyCTS.Services.APIVolaris.ExtrasViajeVolaris> APIExtras = new List<APIVolaris.ExtrasViajeVolaris>();
            for (int i = 0; i < extras.Count; i++)
            {
                MyCTS.Services.APIVolaris.ExtrasViajeVolaris extra = new APIVolaris.ExtrasViajeVolaris();
                extra.CodigoSSR=extras[i].CodigoSSR;
                extra.Destino=extras[i].Destino;
                extra.NumeroPasajero=extras[i].NumeroPasajero;
                extra.Origen=extras[i].Origen;
                APIExtras.Add(extra);
            }
            return APIExtras;
        }

        public List<MyCTS.Services.APIVolaris.PasajerosVolaris> TranslateFromPajaeroEntitiesToPasajeroAPI(List<MyCTS.Entities.PasajerosVolaris> pasajeros)
        {
            List<MyCTS.Services.APIVolaris.PasajerosVolaris> APIPasajeros = new List<APIVolaris.PasajerosVolaris>();
            for (int i = 0; i < pasajeros.Count; i++)
            {
                MyCTS.Services.APIVolaris.PasajerosVolaris pasajero= new APIVolaris.PasajerosVolaris();
                pasajero.Apellidos = pasajeros[i].Apellidos;
                pasajero.Genero = TranslateFromGenerToTiposVolarisGender(pasajeros[i].Genero);
                pasajero.Nombres=pasajeros[i].Nombres;
                pasajero.NumeroPasajero=pasajeros[i].NumeroPasajero;
                pasajero.TipoPasajero = TranslateFromPassengerTypeToTiposVolarisPassengerType(pasajeros[i].TipoPasajero);
                pasajero.Titulo = TranslateFromTittleToTiposVolarisFirstTittle(pasajeros[i].Titulo);
                pasajero.FechaNacimiento=pasajeros[i].FechaNacimiento;
                pasajero.Nacionalidad = VolarisSession.Nacionalidad;
                pasajero.Pais = VolarisSession.Nacionalidad;
                pasajero.TipoDeViajeInfante= pasajeros[i].TipoDeViajeInfante;
                APIPasajeros.Add(pasajero);
            }
            return APIPasajeros;
        }

        public TiposVolarisFirstTittle TranslateFromTittleToTiposVolarisFirstTittle(TiposVolaris.FirstTittle titulo)
        {
            return (TiposVolarisFirstTittle)titulo;
        }

        public TiposVolarisGender TranslateFromGenerToTiposVolarisGender(TiposVolaris.Gender genero)
        {
            return (TiposVolarisGender)genero;
        }

        public TiposVolarisPassengerType TranslateFromPassengerTypeToTiposVolarisPassengerType(TiposVolaris.PassengerType passegner)
        {
            return (TiposVolarisPassengerType)passegner;
        }

        public List<IFlight> TranslateFromVueloDisponibleToIFlight(List<VueloDisponible> disponibilidad)
        {
            try
            {
                List<IFlight> tipoVuelo = new List<IFlight>();

                for (int i = 0; i < disponibilidad.Count; i++)
                {
                    IFlight tipoVueloVolaris = null;
                    List<ISegment> segmentus = new List<ISegment>();

                    for (int j = 0; j < disponibilidad[i].Segmentsk__BackingField.Count; j++)
                    {
                        
                        ISegment segmento = new VolarisSegment();
                        segmento.ArrivalStation = disponibilidad[i].Segmentsk__BackingField[j].ArrivalStationk__BackingField;
                        segmento.ArrivalTime = GetFechaVolaris(disponibilidad[i].Segmentsk__BackingField[j].ArrivalStationDateTimek__BackingField.Replace(disponibilidad[i].Segmentsk__BackingField[j].ArrivalStationk__BackingField, "").Trim());
                        segmento.DepartureStation = disponibilidad[i].Segmentsk__BackingField[j].DepartureStationk__BackingField;
                        segmento.DepartureTime = GetFechaVolaris(disponibilidad[i].Segmentsk__BackingField[j].DepartureDateTimek__BackingField.Replace(disponibilidad[i].Segmentsk__BackingField[j].DepartureStationk__BackingField, "").Trim());
                        segmento.ID = disponibilidad[i].Segmentsk__BackingField[j].FlightNumberk__BackingField.Substring(2, 5);
                        segmentus.Add(segmento);

                    }
                    tipoVueloVolaris = new VolarisFlight();
                    if (segmentus.Count == 2)
                    {
                        tipoVueloVolaris.ArrivalStation = disponibilidad[i].Segmentsk__BackingField[1].ArrivalStationk__BackingField;
                        tipoVueloVolaris.ArrivalTime = GetFechaVolaris(disponibilidad[i].Segmentsk__BackingField[1].ArrivalStationDateTimek__BackingField.Replace(disponibilidad[i].Segmentsk__BackingField[1].ArrivalStationk__BackingField, "").Trim());
                        tipoVueloVolaris.DepartureStation = disponibilidad[i].Segmentsk__BackingField[0].DepartureStationk__BackingField;
                        tipoVueloVolaris.DepartureTime = GetFechaVolaris(disponibilidad[i].Segmentsk__BackingField[0].DepartureDateTimek__BackingField.Replace(disponibilidad[i].Segmentsk__BackingField[0].DepartureStationk__BackingField, "").Trim());
                        tipoVueloVolaris.ID = disponibilidad[i].Segmentsk__BackingField[0].FlightNumberk__BackingField.Substring(2, 5);
                    }
                    else
                    {
                        tipoVueloVolaris.ArrivalStation = disponibilidad[i].Segmentsk__BackingField[0].ArrivalStationk__BackingField;
                        tipoVueloVolaris.ArrivalTime = GetFechaVolaris(disponibilidad[i].Segmentsk__BackingField[0].ArrivalStationDateTimek__BackingField.Replace(disponibilidad[i].Segmentsk__BackingField[0].ArrivalStationk__BackingField, "").Trim());
                        tipoVueloVolaris.DepartureStation = disponibilidad[i].Segmentsk__BackingField[0].DepartureStationk__BackingField;
                        tipoVueloVolaris.DepartureTime = GetFechaVolaris(disponibilidad[i].Segmentsk__BackingField[0].DepartureDateTimek__BackingField.Replace(disponibilidad[i].Segmentsk__BackingField[0].DepartureStationk__BackingField, "").Trim());
                        tipoVueloVolaris.ID = disponibilidad[i].Segmentsk__BackingField[0].FlightNumberk__BackingField.Substring(2, 5);
                    }
                    tipoVueloVolaris.Segments.Add(segmentus);
                    tipoVueloVolaris.OwnerCompany = "Volaris";
                    tipoVueloVolaris.TotalPrice = disponibilidad[i].Amountk__BackingField + disponibilidad[i].Taxk__BackingField;
                    tipoVueloVolaris.Tax = disponibilidad[i].Taxk__BackingField;
                    tipoVueloVolaris.BasePrice = disponibilidad[i].Amountk__BackingField;
                    // aqui se pregunta si el viaje es sencillo en caso contrario es redondo
                    if (disponibilidad[i].TypeFlightk__BackingField.ToString() == TiposVolaris.FlightFullType.Outbound.ToString())
                    {
                        tipoVueloVolaris.IsSingleTrip = true;
                    }
                    if (disponibilidad[i].TypeFlightk__BackingField.ToString() == TiposVolaris.FlightFullType.Inbound.ToString())
                    {
                        tipoVueloVolaris.IsSingleTrip = false;
                    }

                    tipoVuelo.Add(tipoVueloVolaris);

                }
                 return tipoVuelo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DateTime GetFechaVolaris(string fechaOrigen)
        {
            string fecha = fechaOrigen.Split(' ')[0];
            string horaOrigen = fechaOrigen.Split(' ')[1];

            int mes = Convert.ToInt32(fecha.Split('/')[0]);
            int dia = Convert.ToInt32(fecha.Split('/')[1]);
            int anio = Convert.ToInt32(fecha.Split('/')[2]);

            int hora = Convert.ToInt32(horaOrigen.Split(':')[0]);
            int minuto = Convert.ToInt32(horaOrigen.Split(':')[1]);

            return new DateTime(anio, mes, dia, hora, minuto, 0);
        }

        private List<VueloDisponibleMyCTS> TranslateFromVueloDisponibleToVueloDisponibleMyCTS(List<VueloDisponible> vueloDisponible)
        {
            VolarisSession.ListaSegmentos = new List<Entities.SegmentoDeVuelo>();
            List<VueloDisponibleMyCTS> disponibilidad = new List<VueloDisponibleMyCTS>();
            for (int i = 0; i < vueloDisponible.Count; i++)
            {
                VueloDisponibleMyCTS vuelo = new VueloDisponibleMyCTS();
                vuelo.Amount = vueloDisponible[i].Amountk__BackingField;
                vuelo.TypeFlight = TranslateFromTiposVolarisFlightTypesToFlightTypes(vueloDisponible[i].TypeFlightk__BackingField);
                vuelo.Segments = TranslateFromAPISegmentoVueloToSegmentoVueloEntities(vueloDisponible[i].Segmentsk__BackingField);
                vuelo.Signature = vueloDisponible[i].Signaturek__BackingField;
                vuelo.Tax = vueloDisponible[i].Taxk__BackingField;
                vuelo.ContractVersion = vueloDisponible[i].ContractVersionk__BackingField;
                vuelo.CountFares = vueloDisponible[i].CountFaresk__BackingField;
                vuelo.FareSellKey = vueloDisponible[i].FareSellKeyk__BackingField;
                vuelo.JourneySellKey = vueloDisponible[i].JourneySellKeyk__BackingField;
                disponibilidad.Add(vuelo);
            }
            return disponibilidad;
        }

        private TiposVolaris.FlightFullType TranslateFromTiposVolarisFlightTypesToFlightTypes(TiposVolarisFlightFullType tipoVuelo)
        {
            return (TiposVolaris.FlightFullType)tipoVuelo;
        }

        private List<MyCTS.Entities.SegmentoDeVuelo> TranslateFromAPISegmentoVueloToSegmentoVueloEntities(List<MyCTS.Services.APIVolaris.SegmentoDeVuelo> segmentoVuelo)
        {
            lock (thisLock)
            {
                List<MyCTS.Entities.SegmentoDeVuelo> tipoSegmento = new List<Entities.SegmentoDeVuelo>();

                for (int i = 0; i < segmentoVuelo.Count; i++)
                {
                    MyCTS.Entities.SegmentoDeVuelo tipoSegVolaris = new MyCTS.Entities.SegmentoDeVuelo();
                    tipoSegVolaris.FlightNumber = segmentoVuelo[i].FlightNumberk__BackingField;
                    tipoSegVolaris.ArrivalStation = segmentoVuelo[i].ArrivalStationk__BackingField;
                    tipoSegVolaris.ArrivalStationDateTime = segmentoVuelo[i].ArrivalStationDateTimek__BackingField;
                    tipoSegVolaris.DepartureDateTime = segmentoVuelo[i].DepartureDateTimek__BackingField;
                    tipoSegVolaris.DepartureStation = segmentoVuelo[i].DepartureStationk__BackingField;
                    tipoSegmento.Add(tipoSegVolaris);
                    VolarisSession.ListaSegmentos.Add(tipoSegVolaris);
                }
                return tipoSegmento;
            }
        }

        /// <summary>
        /// Creates the reservation.
        /// </summary>
        /// <param name="reservation">The reservation.</param>
        public void CreateReservation(VolarisReservation reservation)
        {
            var responsabilityChainReservation = new VolarisReservationChain
            {
                OnWebServiceCallStart = OnWebServiceCallStart,
                OnWebServiceCallCompleted = OnWebServiceCallCompleted
            };
            responsabilityChainReservation.Execute(reservation);
        }

        /// <summary>
        /// Calls the service.
        /// </summary>
        /// <param name="reservation">The reservation.</param>
        public void AmericanExpressPayment(VolarisReservation reservation)
        {
            var paymentChain = new VolarisPaymentChain()
            {
                OnWebServiceCallStart = OnWebServiceCallStart,
                OnWebServiceCallCompleted = OnWebServiceCallCompleted
            };
            paymentChain.AmericanExpressPayment(reservation);
        }

        public void VisaPayment(VolarisReservation reservation)
        {
            var paymentChain = new VolarisPaymentChain()
            {
                OnWebServiceCallStart = OnWebServiceCallStart,
                OnWebServiceCallCompleted = OnWebServiceCallCompleted
            };
            paymentChain.VisaOrMasterCardPayment(reservation);
        }

        public void MasterCardPayment(VolarisReservation reservation)
        {
            var paymentChain = new VolarisPaymentChain()
            {
                OnWebServiceCallStart = OnWebServiceCallStart,
                OnWebServiceCallCompleted = OnWebServiceCallCompleted
            };
            paymentChain.VisaOrMasterCardPayment(reservation);
        }

    }

}