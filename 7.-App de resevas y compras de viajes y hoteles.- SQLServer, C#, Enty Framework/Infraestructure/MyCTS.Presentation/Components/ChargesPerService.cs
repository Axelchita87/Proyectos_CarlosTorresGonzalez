using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Forms.UI;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;
using MyCTS.Services;
using MyCTS.Services.Contracts;
using MyCTS.Services.PagosMIT;
using System.Configuration;
using MyCTS.Services.PrintVoucher;
using MyCTS.Services.ValidateDKsAndCreditCards;
using System.Xml.Linq;

namespace MyCTS.Presentation.Components
{
    public class ChargesPerService
    {
        public enum OrigenTipoCargo
        {
            FlujoAereo,
            BajoCosto,
            Independiente,
            Hoteles,
            Autos
        }

        public class RespuestasSabre
        {
            public const string NO_NAMES = "NO NAMES";
            public const string NO_ITIN = "NO ITIN";
            public const string NO_DATA = "NO DATA";
            public const string NO_PSGR_DATA = "NO PSGR DATA";
            public const string ACCOUNTING_DATA = "ACCOUNTING DATA";
            public const string TAW = "TAW";
            public const string ARNK = "ARNK";
            public const string HK = "HK";
            public const string YK = "YK";
            // segmento para acciones repetir el DIN
            public const string PAC_TO_VERIFY = "*PAC TO VERIFY";
            public const string SEGMENTS_NOT_IN_DATE_ORDER = "SEGMENTS NOT IN DATE ORDER";
            public const string WARNING_EDITS = "*WARNING EDITS* ";
            public const string SEGMENTS_NOT_IN_DATE_ORDER_VERIFY_AND_REENTER = "SEGMENTS NOT IN DATE ORDER - VERIFY AND REENTER";
            public const string VERIFY_ORDER_OF_ITINERARY_SEGMENTS = "VERIFY ORDER OF ITINERARY SEGMENTS - MODIFY OR END TRANSACTION";
            public const string AIRCRAFT_CHANGE_SEGMENT = "AIRCRAFT CHANGE SEGMENT 05 - USE 4G OR 4GC TO COMPLETE SEATS";
            public const string MULTIPLE_SEGMENTS_FOR_SAME_FLIGHT = "MULTIPLE SEGMENTS FOR SAME FLIGHT - SELL AS ONE SEGMENT";
        }

        public class PreguntasASabre
        {
            public const string VERIFICAR_RESERVA = "*A";
            public const string SOLICITAR_PASAJEROS = "*N";
            public const string SOLICITAR_ITINERARIO = "*IA";
            public const string SOLICITAR_TICKET = "*T";
            public const string VERIFICAR_LINEA_CONTABLE = "*PAC";
            public const string DIN = "DIN";
        }

        public class AerolineasBajoCosto
        {
            public const string INTERJET = "Y4";
            public const string VOLARIS = "O4";
        }

        public static String DKActual;
        public static String DKActualBajoCosto { get; set; }

        public static bool ValidateTestingUsers(OrigenTipoCargo FaseActual)
        {
            string sFaseActual = String.Empty;
            switch (FaseActual)
            {
                case OrigenTipoCargo.FlujoAereo:
                    sFaseActual = "A";
                    break;
                case OrigenTipoCargo.BajoCosto:
                    sFaseActual = "C";
                    break;
                case OrigenTipoCargo.Independiente:
                    sFaseActual = "B";
                    break;
                case OrigenTipoCargo.Hoteles:
                    sFaseActual = "H";
                    break;
                case OrigenTipoCargo.Autos:
                    sFaseActual = "D";
                    break;
            }
            // Si tiene marcado como all ya no valida     
            string[] sFaseValida = ParameterBL.GetParameterValue("ActivePhaseServicesFee").Values.Split('|');

            for (int i = 0; i < sFaseValida.Length; i++)
            {
                if (sFaseActual == sFaseValida[i])
                    break;
                if (i == sFaseValida.Length - 1)
                    return false;
            }                    

            if (ParameterBL.GetParameterValue("ActiveServicesFee").Values == "All")
            {
                return true;
            }
            else
            {
                if (FaseActual == OrigenTipoCargo.BajoCosto)
                    DKActual = DKActualBajoCosto;
                else
                    RecuperarDK();

                string[] sDKValido = ParameterBL.GetParameterValue("ActiveDKServicesFee").Values.Split('|');
                for (int i = 0; i < sDKValido.Length; i++)
                {
                    if (DKActual == sDKValido[i])
                    {
                        string[] sUsuarioValido = ParameterBL.GetParameterValue("ActiveServicesFee").Values.Split('|');
                        for (int j = 0; j < sUsuarioValido.Length; j++)
                        {
                            // y si es este usuario
                            if (ConfigurationManager.AppSettings["DatosContacto"].Split('|')[1] == sUsuarioValido[j])
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public static void RecuperarDK()
        {
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                string sabreAnswer = objCommand.SendReceive("*PDK");
                CommandsQik.CopyResponse(sabreAnswer, ref DKActual, 1, 19, 6);
            }
        }

        public static void ImprimeTicket(string sReservacion, string sDestinatarios)
        {
            Voucher printVoucher = new Voucher();
            // se harcodea el valor del orgId al de CTS, cambiar para cuando se integren mas empresas
            printVoucher.EnviaVoucher(sReservacion, sDestinatarios, 85);
        }


        public static void ImprimeTicketBanco(string transaccion, int organizacionId, string to, string asunto)
        {
            Voucher printVoucher = new Voucher();
            // se harcodea el valor del orgId al de CTS, cambiar para cuando se integren mas empresas
            printVoucher.SendVoucherBanco(transaccion, organizacionId, "adminmycts@ctsmex.com.mx",to,asunto);
        }

        /// <summary>
        /// Existes the cadena en respuestas sabre.
        /// </summary>
        /// <param name="sPregunta">The s pregunta.</param>
        /// <param name="sCadenaAEvaluar">The s cadena A evaluar.</param>
        /// <returns></returns>
        public static bool ExisteCadenaEnRespuestasSabre(String sPregunta, String sCadenaAEvaluar)
        {
            string sResultado = string.Empty;
            int iRenglonInicioCadena = 0;
            int iColumnaInicioCadena = 0;

            string[] sCadenasABuscar = sCadenaAEvaluar.Split('|');

            try
            {
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    string sabreAnswer = objCommand.SendReceive(sPregunta);
                    for (int i = 0; i < sCadenasABuscar.Length; i++)
                    {
                        CommandsQik.searchResponse(sabreAnswer, sCadenasABuscar[i], ref iRenglonInicioCadena, ref iColumnaInicioCadena);
                        for (int j = 0; j < sCadenasABuscar.Length; j++)
                        {
                            if (iColumnaInicioCadena == 0)
                                iColumnaInicioCadena = 1;
                            if (iRenglonInicioCadena == 0)
                                iRenglonInicioCadena = 1;

                            sabreAnswer = sabreAnswer.Replace("‡", "");

                            CommandsQik.CopyResponse(sabreAnswer, ref sResultado, iRenglonInicioCadena, iColumnaInicioCadena, sCadenasABuscar[j].Length);

                            // Ahora buscamos la cadena HK si no la contiene
                            if (sabreAnswer.Contains(RespuestasSabre.ARNK))
                                if (!sabreAnswer.Contains(RespuestasSabre.HK) && !sabreAnswer.Contains(RespuestasSabre.YK))
                                    return true;

                            if (sResultado == sCadenasABuscar[j])
                                return true;
                        }
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static void OnlySendCommands(String sPregunta)
        {
            string sResultado = string.Empty;

            try
            {
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    string sabreAnswer = objCommand.SendReceive(sPregunta);                    
                }
            }
            catch
            {
            }
        }

        public static TransaccionesRespuestasEntities CobroEnLinea(LogServiceFee item, string sNombreTitular, TransaccionesRespuestasEntities Respuesta, String sMerchant, String sTipoTarjeta, TransaccionesTarjetaNPService Tran, String sCurrency, int valor, CreditCardInfo dtsTarjeta, int iPaxNumber, string recLoc)
        {
            try
            {
                decimal MontoConIVA = Math.Round(Convert.ToDecimal(item.sMonto) * 1.16M, 2);
                string idTransaccion = item.id + valor;
                
                string sRespuesta = Tran.Cobro(idTransaccion, sNombreTitular, item.sNumTarjeta, item.sMesVencimiento, item.sAnioVencimiento, item.sCodigoTarjeta, MontoConIVA, sCurrency, sTipoTarjeta, sMerchant, ref Respuesta);
                var tr = new MyCTS.Services.PagosMIT.TransaccionesEntities();
                if (Respuesta == null || string.IsNullOrEmpty(Respuesta.NumeroOperacion) || string.IsNullOrEmpty(Respuesta.NumeroAutorizacion))
                {
                    ErrorLogServiceChargeBL.InsertErrorLogServiceCharge("Error", "Error en " + item.id, "", "");
                    tr =new MyCTS.Services.PagosMIT.TransaccionesEntities { sReference = item.id };
                    string m = Tran.ValidatePayment(ref tr, DateTime.Now);
                    Respuesta.NumeroOperacion = tr.sNoOperacion;
                    Respuesta.NumeroAutorizacion = tr.sAuth;
                }
                else
                {
                    ErrorLogServiceChargeBL.InsertErrorLogServiceCharge(string.IsNullOrEmpty(Respuesta.EstatusTransaccion) ? "" : Respuesta.EstatusTransaccion, string.IsNullOrEmpty(Respuesta.MensajeAmistoso) ? "" : Respuesta.MensajeAmistoso, string.IsNullOrEmpty(Respuesta.NumeroAutorizacion) ? "" : Respuesta.NumeroAutorizacion, string.IsNullOrEmpty(Respuesta.NumeroOperacion) ? "" : Respuesta.NumeroOperacion);
                }
                item.sNumOperacion = Respuesta.NumeroOperacion;
                item.sNumAutorizacion = Respuesta.NumeroAutorizacion;
                
                if (dtsTarjeta.OrigenVenta == "H" || dtsTarjeta.OrigenVenta == "D")
                {
                    LogCxSHotelBL logCxSHotelBL = new LogCxSHotelBL();
                    logCxSHotelBL.InserLogCxSHotel(dtsTarjeta.PNR, idTransaccion, 85, Respuesta.NumeroAutorizacion, Respuesta.NumeroOperacion, item.sNumTarjeta, item.sBanco, Convert.ToDecimal(item.sMonto));
                }
                else
                {
                    if (!string.IsNullOrEmpty(Respuesta.NumeroOperacion) && !string.IsNullOrEmpty(Respuesta.NumeroAutorizacion))
                    {
                        try
                        {
                            LogOnlinePayServicesBL.InsertOnlinePayService(dtsTarjeta.TipoTarjeta, iPaxNumber, recLoc, Respuesta.NumeroAutorizacion, Respuesta.NumeroOperacion, item.sNumTarjeta, Convert.ToDecimal(item.sMonto), item.sBoletos, "");
                        }
                        catch (Exception ex)
                        {
                            new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.CapaDePresentacion);
                        }
                    }
                }
                if (!string.IsNullOrEmpty(Respuesta.NumeroOperacion) && !string.IsNullOrEmpty(Respuesta.NumeroAutorizacion))
                {
                    try
                    {
                        ImprimeTicketBanco(idTransaccion, 85, ConfigurationManager.AppSettings["DatosContacto"].Split('|')[3], "Comprobante de pago referencia No. " + idTransaccion);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("No se ha podido enviar el comprobante. Por favor contacta a la Mesa de Servicio para levantar el reporte", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                try
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.CapaDePresentacion);
                }
                catch (Exception)
                {
                    new EventsManager.EventsManager(System.Diagnostics.EventLogEntryType.Error, ex);
                }
            }
            return Respuesta;
        }

        public static bool ValidarTarjetaCTS(string sNumeroTarjeta)
        {
            try
            {
                if (string.IsNullOrEmpty(sNumeroTarjeta))
                    return false;

                WsMyCTS wsServ = new WsMyCTS();
                string creditCard = wsServ.GetCreditCardNumberCTS(sNumeroTarjeta);

                if (string.IsNullOrEmpty(creditCard))
                    return false;                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al validar tarjeta. Reintente");
            }
            return true;
        }

        /// <summary>
        /// Armado del los comandos que s envian a sabre
        /// </summary>
        public static void BuilCommandToSend(string sOperacion, string sAutorizacion, int iPaxNumber, CreditCardInfo dtsTarjeta, OrigenTipoCargo TipoCargo, string recLoc)
        {
            int iPaxFrontNumber = iPaxNumber + 1;
            int aux = 0;
            string sabreSend = string.Empty;
            string remarkCTS = string.Empty;

            switch (dtsTarjeta.TipoTarjeta)
            {
                case "TP":
                    dtsTarjeta.TipoTarjeta = "CCTC";
                    break;
                case "CA":
                    dtsTarjeta.NumeroTarjeta = string.Empty;
                    break;
            }
                                  
            if (dtsTarjeta.TipoTarjeta.Equals("CA") || dtsTarjeta.TipoTarjeta.Equals("CCTC") || dtsTarjeta.TipoTarjeta.Equals("TR") || dtsTarjeta.TipoTarjeta.Equals("CH"))
            {
                sOperacion = LogNotOnlinePayServicesBL.GetAndInsertNotOnlinePayService(dtsTarjeta.TipoTarjeta, iPaxFrontNumber, recLoc, dtsTarjeta.NumeroTarjeta, dtsTarjeta.MontoCargo, dtsTarjeta.Ticket, sabreSend).ToString();                
            }

            remarkCTS = string.Format("-{0}-{1}-{2}-{3}-{4}/>", dtsTarjeta.TipoTarjeta, dtsTarjeta.NumeroTarjeta, sOperacion, sAutorizacion, dtsTarjeta.Ticket);
            sabreSend = string.Concat("5.</C23-", dtsTarjeta.PaxNumber.ToString("00"), "*", dtsTarjeta.MontoCargo.ToString("#.00"), remarkCTS);
            dtsTarjeta.Remark = sabreSend;

            try
            {
                // Actualizacion de tickets y remarks en MyCTS
                UpdateTicketsLogOnlinePayServicesBL.UpdateTicketsLogOnlinePayServices(dtsTarjeta.TipoTarjeta, iPaxFrontNumber, recLoc, sAutorizacion, sOperacion, dtsTarjeta.Ticket, dtsTarjeta.Remark);
            }
            catch (Exception ex)
            {
                string sError = ex.Message;
            }

            if (dtsTarjeta.MontoCargo > 0)
            {
                dtsTarjeta.Remark = sabreSend;
            }
            else
            {
                dtsTarjeta.Remark = String.Empty;
            }
        }

        public static string GetLast(String sCadena, int iLongitud)
        {
            if (iLongitud >= sCadena.Length)
                return sCadena;
            return sCadena.Substring(sCadena.Length - iLongitud);
        }

        public static bool ValidacionPrevioCargoIndependiente()
        {
            //1.- lanzamos *n*ia
            //si la respuesta es <> 'no data'
            if (!ExisteCadenaEnRespuestasSabre(ChargesPerService.PreguntasASabre.SOLICITAR_ITINERARIO, ChargesPerService.RespuestasSabre.NO_ITIN + "|" + ChargesPerService.RespuestasSabre.ARNK))
            {
                //    2.- lanzamos *T       
                //    Si la respuesta es <> 'TAW' or <> 'NO PSGR DATA'
                if (!ExisteCadenaEnRespuestasSabre(ChargesPerService.PreguntasASabre.SOLICITAR_TICKET, ChargesPerService.RespuestasSabre.TAW + "|" + ChargesPerService.RespuestasSabre.NO_PSGR_DATA))
                {
                    //3.- *PAC
                    //Si resp = 'ACCOUNTING DATA'
                    if (ExisteCadenaEnRespuestasSabre(ChargesPerService.PreguntasASabre.VERIFICAR_LINEA_CONTABLE, ChargesPerService.RespuestasSabre.ACCOUNTING_DATA))
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception("No existen registros contables");
                    }
                }
                else
                {
                    //3.- *PAC
                    //Si resp = 'ACCOUNTING DATA'
                    if (ExisteCadenaEnRespuestasSabre(ChargesPerService.PreguntasASabre.VERIFICAR_LINEA_CONTABLE, ChargesPerService.RespuestasSabre.ACCOUNTING_DATA))
                    {
                        //4.- Search resp Y4 or O4
                        if (ExisteCadenaEnRespuestasSabre(ChargesPerService.PreguntasASabre.VERIFICAR_LINEA_CONTABLE, ChargesPerService.AerolineasBajoCosto.INTERJET + "|" + ChargesPerService.AerolineasBajoCosto.VOLARIS))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        throw new Exception("No existe boleto en el PNR");
                    }
                }
            }
            else
            {
                throw new Exception("No hay PNR presente");
            }
            return false;
        }

        public static void BuilCommandToSendOld(int iPaxNumber, CreditCardInfo dtsTarjeta)
        {
            if (dtsTarjeta != null)
            {
                string sabreSend = string.Empty;
                if (dtsTarjeta.TipoTarjeta != null && dtsTarjeta.TipoTarjeta != string.Empty)
                {
                    if (dtsTarjeta.TipoTarjeta == "CA")
                        sabreSend = String.Format("5.</C23-{0}*{1}-{2}/>", dtsTarjeta.PaxNumber.ToString("00"), dtsTarjeta.MontoCargo.ToString("#.00"), dtsTarjeta.TipoTarjeta);
                    else
                        sabreSend = String.Format("5.</C23-{0}*{1}-{2}-{3}/>", dtsTarjeta.PaxNumber.ToString("00"), dtsTarjeta.MontoCargo.ToString("#.00"), dtsTarjeta.TipoTarjeta, dtsTarjeta.NumeroTarjeta);

                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        objCommand.SendReceiveEmission(sabreSend);
                    }
                }
            }
        }

    }
}
