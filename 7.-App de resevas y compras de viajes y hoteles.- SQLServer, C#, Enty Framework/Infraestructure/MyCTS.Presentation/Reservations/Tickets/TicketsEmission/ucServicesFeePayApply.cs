using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Services.PagosMIT;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using MyCTS.Business;
using MyCTS.Services;
using MyCTS.Services.Contracts;
using System.Collections;

namespace MyCTS.Presentation
{
    public partial class ucServicesFeePayApply : CustomUserControl
    {
        public static List<CreditCardInfo> lstDatosTarjeta = null;
        //public static List<CreditCardInfo> lstDatosTarjeta2 = null;
        public string recLoc { get; set; }
        private static bool UsuarioValidoParaCargosPorServicio = false;
        OTATravelItinerary.OTATravelItineraryObject myObject = null;
        public static String PNRBajoCostoAerolinea { get; set; }
        public static String PNRBajoCostoSabre { get; set; }
        public CreditCardInfo tarjeta { get; set; }

        public static ChargesPerService.OrigenTipoCargo OrigenTipo { get; set; }

        bool bCargosFallidos = false;

        public ucServicesFeePayApply()
        {
            InitializeComponent();
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            crearPerfil();
            // Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }

        private void ucServicesFeePayApply_Load(object sender, EventArgs e)
        {
            if (!UsuarioValidoParaCargosPorServicio)
            {
                MessageBox.Show("EL USUARIO NO ES VALIDO PARA REALIZAR CARGOS POR SERVICIO.", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            else
            {
                List<ListaFiltrada> lstListaFiltrada = FiltrarLista(lstDatosTarjeta);
                gvwCargosAplicados.DataSource = lstListaFiltrada;
            }
        }

        public String GetDynamicProperties(string propName, List<Dynamic> listFields)
        {
            string x = "";
            var item = new Dynamic();
            try
            {
                var prop = from p in listFields
                           where p.FieldName.ToLower() == propName.ToLower()
                           select p;

                item = (prop.Count() > 0) ? prop.First<Dynamic>() : null;
                if (item != null)

                    x = item.GetType().GetProperty(item.FieldName).GetValue(item, null).ToString();
                return x;
            }
            catch (Exception ex)
            {
                new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
            }
            return x;
        }
        public static List<NewPassengerProfile> exist = new List<NewPassengerProfile>();
        public static List<NewPassengerProfile> notExist = new List<NewPassengerProfile>();

        public void crearPerfil()
        {
            try
            {
                List<NewPassengerProfile> newProfile = ucFirstValidations.newProfile;
                if (newProfile != null)
                {

                    if (newProfile.Count != 0)
                    {
                        exist.Clear();
                        notExist.Clear();

                        exist = (from cust in newProfile
                                 where cust.IsNewProfile == true
                                 select cust).ToList();

                        notExist = (from cust in newProfile
                                    where cust.IsNewProfile == false
                                    select cust).ToList();

                        MyCTS.Presentation.Reservations.Tickets.TicketsEmission.frmCreateOrDiscartProfile frmCreate = new Reservations.Tickets.TicketsEmission.frmCreateOrDiscartProfile();
                        MyCTS.Presentation.Reservations.Tickets.TicketsEmission.frmCreateOrDiscartProfile.isSelect = false;
                        frmCreate.ShowDialog();

                        if (MyCTS.Presentation.Reservations.Tickets.TicketsEmission.frmCreateOrDiscartProfile.isSelect)
                        {
                            newProfile.Clear();

                            List<int> listC = MyCTS.Presentation.Reservations.Tickets.TicketsEmission.frmCreateOrDiscartProfile.ChkedRow;
                            List<int> listNC = MyCTS.Presentation.Reservations.Tickets.TicketsEmission.frmCreateOrDiscartProfile.ChkedRowN;

                            for (int i = 0; i < listC.Count; i++)
                            {
                                newProfile.Add(exist[listC[i]]);
                            }

                            for (int i = 0; i < listNC.Count; i++)
                            {
                                newProfile.Add(notExist[listNC[i]]);
                            }

                            List<Star2Details> listProfile = new List<Star2Details>();

                            foreach (NewPassengerProfile item in newProfile)
                            {
                                List<Star2Details> listProfiles = MyCTS.Business.Get2StarEmailBL.Get2StarEmail(item.Email, "");

                                Star2Details profile = new Star2Details();
                                if (!string.IsNullOrEmpty(listProfiles[0].Name))
                                {
                                    profile = listProfiles[0];

                                    if (string.IsNullOrEmpty(profile.OfficePhone))
                                        profile.OfficePhone = "0000";

                                    listProfile.Add(profile);

                                }
                                else
                                {
                                    string lastName = item.LastName != null ? item.LastName : string.Empty;
                                    string name = item.Name != null ? item.Name : string.Empty;
                                    profile.LastName = item.LastName != null ? item.LastName : string.Empty;
                                    profile.Name = item.Name != null ? item.Name : string.Empty;
                                    profile.Email = item.Email != null ? item.Email : string.Empty;
                                    profile.Level2 = lastName.Replace(" ", "") + "/" + name.Replace(" ", "");
                                    profile.Level1 = item.DK;

                                    listProfile.Add(profile);
                                }
                            }

                            MyCTS.Presentation.Reservations.Profiles.UcSecondLevelProfiles.ListObjStar2Dcpsl = listProfile;
                            MyCTS.Presentation.Reservations.Profiles.UcSecondLevelProfiles.ticketProfile = 0;

                            frmProfiles frmProfile = new frmProfiles();
                            frmProfiles.IsTicket = true;
                            frmProfile.ShowDialog();

                            lstDatosTarjeta = new List<CreditCardInfo>();

                            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                throw new Exception();
            }
            finally
            {
                ucFirstValidations.newProfile = null;

                lstDatosTarjeta = new List<CreditCardInfo>();

                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
        }

        public void showProfile()
        {
            frmProfiles frmProfile = new frmProfiles();
            frmProfiles.IsTicket = true;
            frmProfile.ShowDialog();
        }

        public void PayServiceFee()
        {
            frmPreloading frm2 = new frmPreloading(this);
            frm2.Show();
            List<ListaFiltrada> lstListaFiltrada = new List<ListaFiltrada>();
            UsuarioValidoParaCargosPorServicio = ChargesPerService.ValidateTestingUsers(OrigenTipo);
            if ((OrigenTipo != ChargesPerService.OrigenTipoCargo.Independiente) && !UsuarioValidoParaCargosPorServicio)
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            else
            {
                if (OrigenTipo == ChargesPerService.OrigenTipoCargo.BajoCosto)
                {
                    if (String.IsNullOrEmpty(PNRBajoCostoSabre))
                    {
                        MessageBox.Show("No ha sido posible generar la factura para el servicio aéreo,\n por tal motivo los cargos por servicio en linea\n no pudieron ser completados", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            string sabreAnswer = objCommand.SendReceive("*" + PNRBajoCostoSabre);
                        }
                        recLoc = PNRBajoCostoSabre;
                    }
                }
                else if (OrigenTipo == ChargesPerService.OrigenTipoCargo.Hoteles || OrigenTipo == ChargesPerService.OrigenTipoCargo.Autos)
                {
                    TransaccionesRespuestasEntities Respuesta = new TransaccionesRespuestasEntities();
                    PagarHotel(ref lstListaFiltrada, ref Respuesta);
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        objCommand.SendReceive(ChargesPerService.PreguntasASabre.VERIFICAR_RESERVA);
                    }
                }
                else
                    RecuperarPNR();

                if (tarjeta != null)
                {
                    lstDatosTarjeta.Add(tarjeta);
                }

                if (!string.IsNullOrEmpty(recLoc) && recLoc.Length == 6 && ValidateRegularExpression.ValidatePNR(recLoc) &&
                    OrigenTipo != ChargesPerService.OrigenTipoCargo.Hoteles && OrigenTipo != ChargesPerService.OrigenTipoCargo.Autos)
                {
                    FlujoPagos();
                }

                lstListaFiltrada = FiltrarLista(lstDatosTarjeta);
                if (!string.IsNullOrEmpty(recLoc) && recLoc.Length == 6 && ValidateRegularExpression.ValidatePNR(recLoc) &&
                    OrigenTipo != ChargesPerService.OrigenTipoCargo.Hoteles && OrigenTipo != ChargesPerService.OrigenTipoCargo.Autos)
                {
                    MandarDin(lstListaFiltrada);
                }
            }
        }

        private void PagarHotel(ref List<ListaFiltrada> lstListaFiltrada, ref TransaccionesRespuestasEntities Respuesta)
        {

            if (tarjeta.TipoTarjeta.Equals("CCAC") || tarjeta.TipoTarjeta.Equals("CCPV") || tarjeta.TipoTarjeta.Equals("CCTD"))
            {
                try
                {
                    LogServiceFee item = new LogServiceFee();
                    String sNombreTransaccion = string.Empty;
                    TransaccionesTarjetaNPService Tran = new TransaccionesTarjetaNPService();
                    int iNumeroIntento = 0;
                    // Se guarda en LogServiceFee la respuesta
                    item = new LogServiceFee
                    {
                        id = sNombreTransaccion,
                        sCodigoTarjeta = tarjeta.CodigoSeguridad,
                        sNumTarjeta = tarjeta.NumeroTarjeta,
                        sMesVencimiento = tarjeta.MesVencimiento,
                        sAnioVencimiento = tarjeta.AnioVencimiento,
                        sBanco = tarjeta.TipoTarjeta,
                        sMonto = tarjeta.MontoCargo.ToString(),
                        dtDate = DateTime.Now,
                        sBoletos = tarjeta.Ticket,
                        sRemarks = String.Empty,
                        sRecLoc = recLoc
                    };

                    // se harcodea el valor del orgId al de CTS, cambiar para cuando se integren mas empresas

                    item.id = sNombreTransaccion = "MyCTS-" + tarjeta.OrigenVenta + "-" + recLoc + "_";

                    Respuesta = Pagar(ref item, tarjeta.NombreTitular, tarjeta, 1, iNumeroIntento);
                    ErrorLogServiceChargeBL.InsertErrorLogServiceCharge(Respuesta.EstatusTransaccion, Respuesta.MensajeAmistoso, Respuesta.NumeroAutorizacion, Respuesta.NumeroOperacion);

                    if (Respuesta.EstatusTransaccion == "Error" || Respuesta.EstatusTransaccion == "Denegada")
                    {
                        char[] caracterSeparador = { '.' };
                        String[] sErrorCorto = Respuesta.MensajeAmistoso.Split(caracterSeparador, StringSplitOptions.RemoveEmptyEntries);
                        String sErrorParteDos = String.Empty;
                        if (sErrorCorto.Length > 1)
                        {
                            sErrorParteDos = "Transacción rechazada. " + sErrorCorto[1].Trim(); ;
                        }
                        else
                        {
                            sErrorParteDos = Respuesta.MensajeAmistoso;
                        }
                        tarjeta.Pagado = false;
                        tarjeta.MensajeError = sErrorParteDos;
                        return;
                    }
                    else
                    {
                        tarjeta.Pagado = true;
                        tarjeta.NumeroAutorizacion = item.sNumAutorizacion;
                        tarjeta.NumeroOperacion = item.sNumOperacion;
                    }
                }
                catch (Exception ex)
                {
                    tarjeta.Pagado = false;
                    tarjeta.MensajeError = "Error al intentar conectar con MIT";
                    try
                    {
                        new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.CapaDePresentacion);
                    }
                    catch (Exception)
                    {
                        new EventsManager.EventsManager(System.Diagnostics.EventLogEntryType.Error, ex);
                    }
                    return;
                }
            }
            else
            {
                LogCxSHotelBL logCxSHotelBL = new LogCxSHotelBL();
                logCxSHotelBL.InserLogCxSHotel(tarjeta.PNR, string.Empty, 85, Respuesta.NumeroAutorizacion, Respuesta.NumeroOperacion, tarjeta.NumeroTarjeta, tarjeta.TipoTarjeta, Convert.ToDecimal(tarjeta.MontoCargo));
            }

            tarjeta.Activo = false;


            /*
            foreach (var tarjeta in lstDatosTarjeta2)
            {
                if (tarjeta.TipoTarjeta.Equals("CCAC") || tarjeta.TipoTarjeta.Equals("CCPV") || tarjeta.TipoTarjeta.Equals("CCTD"))
                {
                    try
                    {
                        LogServiceFee item = new LogServiceFee();
                        String sNombreTransaccion = string.Empty;
                        TransaccionesTarjetaNPService Tran = new TransaccionesTarjetaNPService();
                        int iNumeroIntento = 0;
                        // Se guarda en LogServiceFee la respuesta
                        item = new LogServiceFee
                        {
                            id = sNombreTransaccion,
                            sCodigoTarjeta = tarjeta.CodigoSeguridad,
                            sNumTarjeta = tarjeta.NumeroTarjeta,
                            sMesVencimiento = tarjeta.MesVencimiento,
                            sAnioVencimiento = tarjeta.AnioVencimiento,
                            sBanco = tarjeta.TipoTarjeta,
                            sMonto = tarjeta.MontoCargo.ToString(),
                            dtDate = DateTime.Now,
                            sBoletos = tarjeta.Ticket,
                            sRemarks = String.Empty,
                            sRecLoc = recLoc
                        };

                        // se harcodea el valor del orgId al de CTS, cambiar para cuando se integren mas empresas

                        item.id = sNombreTransaccion = "MyCTS-" + tarjeta.OrigenVenta + "-" + tarjeta.PNR + "_";

                        Respuesta = Pagar(ref item, tarjeta.NombreTitular, tarjeta, 1, iNumeroIntento);

                        if (Respuesta.EstatusTransaccion == "Error" || Respuesta.EstatusTransaccion == "Denegada")
                        {
                            char[] caracterSeparador = { '.' };
                            String[] sErrorCorto = Respuesta.MensajeAmistoso.Split(caracterSeparador, StringSplitOptions.RemoveEmptyEntries);
                            String sErrorParteDos = String.Empty;
                            if (sErrorCorto.Length > 1)
                            {
                                sErrorParteDos = "Transacción rechazada. " + sErrorCorto[1].Trim(); ;
                            }
                            else
                            {
                                sErrorParteDos = Respuesta.MensajeAmistoso;
                            }
                            tarjeta.Pagado = false;
                            tarjeta.MensajeError = sErrorParteDos;
                            return;
                        }
                        else
                        {
                            tarjeta.Pagado = true;
                            tarjeta.NumeroAutorizacion = item.sNumAutorizacion;
                            tarjeta.NumeroOperacion = item.sNumOperacion;
                        }
                    }
                    catch (Exception ex)
                    {
                        tarjeta.Pagado = false;
                        tarjeta.MensajeError = "Error al intentar conectar con MIT";
                        try
                        {
                            new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.CapaDePresentacion);
                        }
                        catch (Exception)
                        {
                            new EventsManager.EventsManager(System.Diagnostics.EventLogEntryType.Error, ex);
                        }
                        return;
                    }
                }
                else
                {
                    LogCxSHotelBL logCxSHotelBL = new LogCxSHotelBL();
                    logCxSHotelBL.InserLogCxSHotel(tarjeta.PNR, string.Empty, 85, Respuesta.NumeroAutorizacion, Respuesta.NumeroOperacion, tarjeta.NumeroTarjeta, tarjeta.TipoTarjeta, Convert.ToDecimal(tarjeta.MontoCargo));
                }

                tarjeta.Activo = false;
            }
            */
            lstListaFiltrada = FiltrarLista(lstDatosTarjeta);
            MandarDin(lstListaFiltrada);

            return;
        }

        private void MandarDin(List<ListaFiltrada> lstListaFiltrada)
        {
            for (int i = 0; i < lstListaFiltrada.Count; i++)
            {
                if ((lstListaFiltrada[i].ESTATUS == "OK" || lstListaFiltrada[i].ESTATUS == "Cargo Exitoso") && !string.IsNullOrEmpty(lstListaFiltrada[i].AUTORIZACION) && !string.IsNullOrEmpty(lstListaFiltrada[i].OPERACION))
                {
                    GeneracionRemarks();

                    bool isVolverAMandarDIN = ChargesPerService.ExisteCadenaEnRespuestasSabre(
                        ChargesPerService.PreguntasASabre.DIN,
                        ChargesPerService.RespuestasSabre.PAC_TO_VERIFY + "|" +
                        ChargesPerService.RespuestasSabre.SEGMENTS_NOT_IN_DATE_ORDER + "|" +
                        ChargesPerService.RespuestasSabre.WARNING_EDITS + "|" +
                        ChargesPerService.RespuestasSabre.SEGMENTS_NOT_IN_DATE_ORDER_VERIFY_AND_REENTER + "|" +
                        ChargesPerService.RespuestasSabre.VERIFY_ORDER_OF_ITINERARY_SEGMENTS + "|" +
                        ChargesPerService.RespuestasSabre.AIRCRAFT_CHANGE_SEGMENT + "|" +
                        ChargesPerService.RespuestasSabre.MULTIPLE_SEGMENTS_FOR_SAME_FLIGHT);
                    if (isVolverAMandarDIN)
                        ChargesPerService.ExisteCadenaEnRespuestasSabre(ChargesPerService.PreguntasASabre.DIN, "");
                    break;
                }
                else if ((lstListaFiltrada[i].ESTATUS == "OK" || lstListaFiltrada[i].ESTATUS == "Cargo Exitoso") && (lstDatosTarjeta[i].TipoTarjeta != "CCAC" && lstDatosTarjeta[i].TipoTarjeta != "CCPV" && lstDatosTarjeta[i].TipoTarjeta != "CCTD"))
                {
                    GeneracionRemarks();

                    bool isVolverAMandarDIN = ChargesPerService.ExisteCadenaEnRespuestasSabre(
                        ChargesPerService.PreguntasASabre.DIN,
                        ChargesPerService.RespuestasSabre.PAC_TO_VERIFY + "|" +
                        ChargesPerService.RespuestasSabre.SEGMENTS_NOT_IN_DATE_ORDER + "|" +
                        ChargesPerService.RespuestasSabre.WARNING_EDITS + "|" +
                        ChargesPerService.RespuestasSabre.SEGMENTS_NOT_IN_DATE_ORDER_VERIFY_AND_REENTER + "|" +
                        ChargesPerService.RespuestasSabre.VERIFY_ORDER_OF_ITINERARY_SEGMENTS + "|" +
                        ChargesPerService.RespuestasSabre.AIRCRAFT_CHANGE_SEGMENT + "|" +
                        ChargesPerService.RespuestasSabre.MULTIPLE_SEGMENTS_FOR_SAME_FLIGHT);
                    if (isVolverAMandarDIN)
                        ChargesPerService.ExisteCadenaEnRespuestasSabre(ChargesPerService.PreguntasASabre.DIN, "");
                    break;
                }
            }
        }

        private void RecuperarPNR()
        {
            if (String.IsNullOrEmpty(recLoc))
            {
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    string recordLocalizador = string.Empty;
                    string sabreAnswer = objCommand.SendReceive(ChargesPerService.PreguntasASabre.VERIFICAR_RESERVA);
                    CommandsQik.CopyResponse(sabreAnswer, ref recordLocalizador, 1, 1, 6);
                    recLoc = recordLocalizador;
                }
            }
        }

        private List<ListaFiltrada> FiltrarLista(List<CreditCardInfo> listaTarjetaOriginal)
        {
            List<ListaFiltrada> ListaGrid = new List<ListaFiltrada>();
            for (int i = 0; i < listaTarjetaOriginal.Count; i++)
            {
                ListaFiltrada NuevaLista = new ListaFiltrada();
                NuevaLista.PAX = listaTarjetaOriginal[i].PaxNumber.ToString();
                NuevaLista.MONTO = listaTarjetaOriginal[i].MontoCargo.ToString();

                if (listaTarjetaOriginal[i].TipoTarjeta == "CCAC" || listaTarjetaOriginal[i].TipoTarjeta == "CCPV" || listaTarjetaOriginal[i].TipoTarjeta == "CCTD")
                {
                    if (listaTarjetaOriginal[i].Pagado == false)
                        NuevaLista.ESTATUS = "Cargo Fallido";
                    else
                        NuevaLista.ESTATUS = "Cargo Exitoso";
                }
                else
                {
                    NuevaLista.ESTATUS = "OK";
                }

                NuevaLista.AUTORIZACION = listaTarjetaOriginal[i].NumeroAutorizacion;
                NuevaLista.OPERACION = listaTarjetaOriginal[i].NumeroOperacion;
                NuevaLista.MENSAJE = listaTarjetaOriginal[i].MensajeError;
                ListaGrid.Add(NuevaLista);
            }
            return ListaGrid;
        }

        private void FlujoPagos()
        {
            // Validacion para obtener los boletos de bajo costo
            try
            {
                if (lstDatosTarjeta.Count > 0 && lstDatosTarjeta[0].OrigenVenta != "C")
                {
                    GetInfoPassengerByPNR PNRTickets = new GetInfoPassengerByPNR();
                    var GetPNRTickets = PNRTickets.GetInfoPassengerPNR(recLoc);

                    // Aqui pintamos todos los boletos por pasajero
                    for (int j = 0; j < GetPNRTickets.namePassengerList.Length; j++)
                    {
                        for (int i = 0; i < lstDatosTarjeta.Count; i++)
                        {
                            if (GetPNRTickets.namePassengerList[j].paxNumber.Split('.')[0] == lstDatosTarjeta[i].PaxNumber.ToString())
                            {
                                if (lstDatosTarjeta[i].Ticket == null)
                                {
                                    lstDatosTarjeta[i].Ticket = GetPNRTickets.namePassengerList[j].paxTicket;
                                }
                            }
                        }
                    }
                }
                else
                {
                    ExtraerBoletosBajoCosto();
                }
            }
            catch (Exception ex)
            {
                ExtraerBoletosBajoCosto();
            }

            for (int i = 0; i < lstDatosTarjeta.Count; i++)
            {
                if (lstDatosTarjeta[i].MontoCargo != 0 && lstDatosTarjeta[i].Pagado != true)
                {
                    string sError = string.Empty;
                    PayForItemFormPaymentCS(lstDatosTarjeta[i], i, ref sError);
                }
            }
        }

        private static void ExtraerBoletosBajoCosto()
        {
            // Cargamos los boletos de bajo costo
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                // obtenemos lista de bolestos utilizando el *PAC
                string sabreAnswer = objCommand.SendReceive(ChargesPerService.PreguntasASabre.VERIFICAR_LINEA_CONTABLE);

                //SOLO PARA PRUEBAS GABY SOLANO
                //CatTransactionBL.AddCommandsTransaction(Login.Agent, Common.CurrentPNR, sabreAnswer, DateTime.Now, Common.CurrentArea);


                char[] cCaracterSeparador = { '\n' };
                List<string> sRespuestaBajoCosto = sabreAnswer.Split(cCaracterSeparador, StringSplitOptions.RemoveEmptyEntries).ToList();

                for (int j = 0; j < lstDatosTarjeta.Count; j++)
                {
                    for (int i = 0; i < sRespuestaBajoCosto.Count; i++)
                    {
                        string[] sRespuestaBoletos = sRespuestaBajoCosto[i].Split('/');

                        if (lstDatosTarjeta[j].PaxNumber.ToString() == sRespuestaBoletos[0].Split('.')[0].Trim()
                            && !VolarisSession.IsVolarisProcess)
                        {
                            lstDatosTarjeta[j].Ticket = sRespuestaBoletos[1];
                            sRespuestaBajoCosto[i] = String.Empty;
                            break;
                        }
                        else if (!VolarisSession.IsVolarisProcess)
                        {
                            sRespuestaBajoCosto[i] = String.Empty;
                        }

                        if (sRespuestaBoletos[0].Contains(".") &&
                            sRespuestaBoletos[0].Split('.')[1].Trim().Substring(0, 1) == "Y"
                            && VolarisSession.IsVolarisProcess)
                        {
                            if (sRespuestaBoletos[1].Substring(0, 2) != "99" && sRespuestaBoletos[1].Substring(0, 2) != "98")
                            {
                                lstDatosTarjeta[j].Ticket = sRespuestaBoletos[1];
                                sRespuestaBajoCosto[i] = String.Empty;
                                break;
                            }
                            else
                            {
                                sRespuestaBajoCosto[i] = String.Empty;
                            }
                        }
                        else if (VolarisSession.IsVolarisProcess)
                        {
                            sRespuestaBajoCosto[i] = String.Empty;
                        }
                    }
                }
            }
        }

        private void GeneracionRemarks()
        {
            for (int i = 0; i < lstDatosTarjeta.Count; i++)
            {
                if (lstDatosTarjeta[i].Remark != null && lstDatosTarjeta[i].Remark != String.Empty)
                {
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        objCommand.SendReceiveEmission(lstDatosTarjeta[i].Remark);
                    }
                }
            }
        }

        private bool PayForItemFormPaymentCS(CreditCardInfo dtsTarjeta, int iPaxNumber, ref string Error)
        {
            int iPaxFrontNumber = iPaxNumber + 1;
            TransaccionesRespuestasEntities Respuesta = new TransaccionesRespuestasEntities();

            if (dtsTarjeta == null)
                return false;

            if (UsuarioValidoParaCargosPorServicio)
            {
                if (dtsTarjeta.TipoTarjeta.Equals("CCAC") || dtsTarjeta.TipoTarjeta.Equals("CCPV") || dtsTarjeta.TipoTarjeta.Equals("CCTD"))
                {
                    try
                    {
                        LogServiceFee item = new LogServiceFee();
                        String sNombreTransaccion = string.Empty;
                        TransaccionesTarjetaNPService Tran = new TransaccionesTarjetaNPService();
                        int iCargoAplicado = 0;
                        int iNumeroIntento = 0;
                        // Se guarda en LogServiceFee la respuesta
                        item = new LogServiceFee
                        {
                            id = sNombreTransaccion,
                            sCodigoTarjeta = dtsTarjeta.CodigoSeguridad,
                            sNumTarjeta = dtsTarjeta.NumeroTarjeta,
                            sMesVencimiento = dtsTarjeta.MesVencimiento,
                            sAnioVencimiento = dtsTarjeta.AnioVencimiento,
                            sBanco = dtsTarjeta.TipoTarjeta,
                            sMonto = dtsTarjeta.MontoCargo.ToString(),
                            dtDate = DateTime.Now,
                            sBoletos = dtsTarjeta.Ticket,
                            sRemarks = String.Empty,
                            sRecLoc = recLoc
                        };

                        // se harcodea el valor del orgId al de CTS, cambiar para cuando se integren mas empresas
                        iNumeroIntento = Tran.GetNumeroIntentos(recLoc, 85);
                        iCargoAplicado = Tran.GetNumeroTransacciones(recLoc, 85);

                        item.id = sNombreTransaccion = "MyCTS-" + dtsTarjeta.OrigenVenta + "-" + recLoc + "-" + iCargoAplicado + "-" + iPaxFrontNumber + "_";

                        Respuesta = Pagar(ref item, dtsTarjeta.NombreTitular, dtsTarjeta, iPaxFrontNumber, iNumeroIntento);

                        ErrorLogServiceChargeBL.InsertErrorLogServiceCharge(Respuesta.EstatusTransaccion, Respuesta.MensajeAmistoso, Respuesta.NumeroAutorizacion, Respuesta.NumeroOperacion);

                        if (Respuesta.EstatusTransaccion == "Error" || Respuesta.EstatusTransaccion == "Denegada")
                        {
                            char[] caracterSeparador = { '.' };
                            String[] sErrorCorto = Respuesta.MensajeAmistoso.Split(caracterSeparador, StringSplitOptions.RemoveEmptyEntries);
                            String sErrorParteDos = String.Empty;
                            if (sErrorCorto.Length > 1)
                            {
                                sErrorParteDos = "Transacción rechazada. " + sErrorCorto[1].Trim(); ;
                            }
                            else
                            {
                                sErrorParteDos = Respuesta.MensajeAmistoso;
                            }
                            Error = Respuesta.MensajeAmistoso;
                            dtsTarjeta.Pagado = false;
                            dtsTarjeta.MensajeError = sErrorParteDos;
                            return false;
                        }
                        if (string.IsNullOrEmpty(Respuesta.EstatusTransaccion))
                        {
                            Error = "Error al intentar realizar el cargo";
                            dtsTarjeta.Pagado = false;
                            dtsTarjeta.MensajeError = Error;
                            return false;
                        }
                        else
                        {
                            dtsTarjeta.Pagado = true;
                            dtsTarjeta.NumeroAutorizacion = item.sNumAutorizacion;
                            dtsTarjeta.NumeroOperacion = item.sNumOperacion;
                        }
                    }
                    catch (Exception ex)
                    {
                        Error = "Error al intentar conectar con MIT";
                        dtsTarjeta.Pagado = false;
                        dtsTarjeta.MensajeError = "Error al intentar conectar con MIT";
                        try
                        {
                            new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.CapaDePresentacion);
                        }
                        catch (Exception)
                        {
                            new EventsManager.EventsManager(System.Diagnostics.EventLogEntryType.Error, ex);
                        }
                        return false;
                    }
                }
                ChargesPerService.BuilCommandToSend(Respuesta.NumeroOperacion, Respuesta.NumeroAutorizacion, iPaxNumber, dtsTarjeta, OrigenTipo, recLoc);
                dtsTarjeta.Activo = false;
            }
            else
            {
                if (OrigenTipo == ChargesPerService.OrigenTipoCargo.Independiente)
                {
                    ChargesPerService.BuilCommandToSendOld(iPaxNumber, dtsTarjeta);
                    dtsTarjeta.Pagado = true;
                }
            }

            return true;
        }

        public TransaccionesRespuestasEntities Pagar(ref LogServiceFee item, string sNombreTitular, CreditCardInfo dtsTarjeta, int iPaxNumber, int iNumeroIntento)
        {
            TransaccionesRespuestasEntities Respuesta = new TransaccionesRespuestasEntities();

            try
            {
                String sMerchant;
                String sTipoTarjeta;
                TransaccionesTarjetaNPService Tran = new TransaccionesTarjetaNPService();
                String sCurrency = "MXN";

                if (item.sBanco == "CCAC")
                {
                    sTipoTarjeta = "AMEX";
                    sMerchant = "33828";
                }
                else
                {
                    sTipoTarjeta = "VMC";
                    sMerchant = "33521";
                }

                if (System.Configuration.ConfigurationManager.AppSettings["Ambiente"] == "PRUEBAS")
                {
                    sMerchant = "07854";
                }

                Respuesta = ChargesPerService.CobroEnLinea(item, sNombreTitular, Respuesta, sMerchant, sTipoTarjeta, Tran, sCurrency, iNumeroIntento, dtsTarjeta, iPaxNumber, recLoc);

            }
            catch (Exception ex)
            {
                Respuesta.EstatusTransaccion = "Error";
                Respuesta.MensajeAmistoso = ex.Message;
            }
            return Respuesta;
        }

        /// </summary>
        public void GetValuesWebServices()
        {
            using (WSSessionSabre obj = new WSSessionSabre())
            {
                obj.OpenConnection();
                if (obj.IsConnected)
                {
                    myObject = new OTATravelItinerary().TravelItineraryMethod(obj.ConversationId, obj.IPcc, obj.SecurityToken, recLoc);
                    //if (myObject != null)
                    //    if (myObject.Status)
                    //        InsertDetailsPNR();
                }
            }
        }
    }

    class ListaFiltrada
    {
        public string PAX { get; set; }
        public string MONTO { get; set; }
        public string ESTATUS { get; set; }
        public string AUTORIZACION { get; set; }
        public string OPERACION { get; set; }
        public string MENSAJE { get; set; }

    }
}
