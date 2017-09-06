using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;
using MyCTS.Components;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Presentation.Components;
using System.Text.RegularExpressions;

namespace MyCTS.Presentation
{
    public partial class frmMain
    {

        #region ===== Declaracion de variables para el manejo del API de MySabre =====
        public delegate void AddTextCallback(string text);
        public delegate void SendMessageCallback();

        //private bool reconnect = false;
        public static bool IsConnected = false;
        public static bool IsLocked = false;
        //private static Int32 WM_VSCROLL = 0x115;
        //private static Int32 SB_BOTTOM = 7;
        private const int API_READY = 0;
        private const int API_UPDATE = 1;
        private const int API_SUSPENDED = 2;
        public const int API_UNAVAILABLE = 3;
        private const int API_RESUME = 4;
        private const int API_ERROR = -1;
        private const int INFINITE = -1;
        private int previousState = API_ERROR;
        public static string markupProperties = string.Empty;
        private int Listenercount = 0;
        private const long MESSAGE_TYPE = 1 | 2;

        private bool IsRegmarkup = false;
        public static bool IsSigned = false;

        private static string SABRE_API_LOADED_EVENT_STATE = "MYSABRE_API_LOADED";
        private static string SABRE_API_ACTIVE_EVENT_STATE = "MYSABRE_API_ACTIVE";
        private static string SABRE_API_UPDATING_EVENT_STATE = "MYSABRE_API_UPDATING";
        private static string SABRE_API_RESUME_EVENT_STATE = "MYSABRE_API_RESUMED";

        private string SABRE_API_NOTIFY_A = "MYSABRE_API_NOTIFY_A";
        private string SABRE_API_NOTIFY_B = "MYSABRE_API_NOTIFY_B";

        private string COMMANDTYPE_MSG = "MSG";
        private string COMMANDTYPE_UC = "UC";


        public MySabreAPI mySabreAPI;
        private CallBackHandler.MySabreCallback cb;
        private CallBackHandler.MySabreMarkupCallback cbMarkup;
        public long handleMod;

        [DllImport("user32")]
        private static extern IntPtr SendMessage(IntPtr hWnd, Int32 Msg, Int32 wParam, Int32 lParam);

        public static string defaultMarkupProperties = "cmd={0};markup.order=1;rsp.to=3000";
        public static bool isDefaultMarkupDetails = false;
        #endregion


        private void begin_SabreTrafficListener()
        {
            try
            {
                long output = CallBackHandler.beginSabreTrafficListener_stdcall(Convert.ToInt32(MESSAGE_TYPE), cb);

                if (output.Equals(0))
                {
                    //Listenercount += 1;
                }

            }
            catch
            {
            }
        }

        private void end_SabreTrafficListener()
        {
            long output = CallBackHandler.endSabreTrafficListener_stdcall(cb);
        }

        #region Objetos Asíncronos

        private delegate void SenderInvoker();
        private delegate void SenderInvokerBool(bool hide);
        private void ReceiverSigned()
        {
            if (this.InvokeRequired)
                this.Invoke(new SenderInvoker(ReceiverSigned));
            else
            {
                SenderInvoker smh = new SenderInvoker(LoadInitialControls);
                smh.BeginInvoke(null, null);
            }
        }

        private void ReceiverUnSigned()
        {
            if (this.InvokeRequired)
                this.Invoke(new SenderInvoker(ReceiverUnSigned));
            else
            {
                SenderInvoker smh = new SenderInvoker(UnloadInitialControls);
                smh.BeginInvoke(null, null);
            }
        }

        private void LoadInitialControls()
        {
            if (this.InvokeRequired)
                this.Invoke(new SenderInvoker(LoadInitialControls));
            else
            {
                pnlLeft.Controls.Clear();
                pnlLeft.Controls.Add(Loader.GetReferenceUserControl("ucMenuReservations"));

                pnlMiddle.Controls.Clear();
                pnlMiddle.Controls.Add(Loader.GetReferenceUserControl("ucConnected"));

                pnlArea.Controls.Clear();
                pnlArea.Controls.Add(Loader.GetReferenceUserControl("ucArea"));

                toolStripButtonQueue.Visible = true;
                Common.SetCurrentArea(Common.Area.Area_A);

                if (Login.IsMySabreBlocked)
                    MyCTSAPI.EnabledBrowser(false);
            }
        }

        private void UnloadInitialControls()
        {
            if (this.InvokeRequired)
                this.Invoke(new SenderInvoker(UnloadInitialControls));
            else
            {
                foreach (Control c in pnlLeft.Controls)
                    c.Dispose();
                foreach (Control c in pnlArea.Controls)
                    c.Dispose();
                toolStripButtonQueue.Visible = false;
                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucWelcome", Login.TA);
                lblQueue.Text = string.Empty;
            }

        }

        private void CloseObjects()
        {
            if (this.InvokeRequired)
                this.Invoke(new SenderInvoker(CloseObjects));
            else
            {
                try
                {
                    int IsDisconnected;
                    mySabreAPI = null;
                    IsDisconnected = MySabreAPI.clientDisconnect();
                }
                catch { }

                try
                {
                    string emuapi = "emuapi";
                    int hVal = MySabreAPI.GetModuleHandle(ref emuapi);
                    if (hVal != 0)
                    {
                        while (MySabreAPI.FreeLibrary(hVal))
                        { }
                    }
                }
                catch {}
                Application.Exit();
                frmLogin frm = (frmLogin)Application.OpenForms["frmLogin"];
                if (frm != null)
                    frm.Dispose();
            }
        }
        #endregion

        #region Sabre Escucha
        private string sabreCommand = string.Empty;
        private int tempSabreHandler(int messageType, string message)
        {
            try
            {
                //System.Threading.Thread.Sleep(3000);

                if (messageType.Equals(1))
                {
                    sabreCommand = message;
                    if (CommandsAPI.ValidateMarkups)
                    {
                        ReceiverParams(message);
                    }
                }

                if (messageType.Equals(2))
                {
                    if (!CommandsAPI.ValidateMarkups)
                        return 0;

                    string temp = message;
                    if ((string.IsNullOrEmpty(temp)) | (temp.Equals("\n")))
                        return 0;

                    Common.FindPNR(temp);

                    //El usuario no ha ingresado al sistema
                    if (!IsSigned)
                    {
                        if ((temp.Contains("SI<                >")) | (temp.Contains("SIGN IN")))
                            return 0;
                        IsSigned = true;
                        ReceiverSigned();
                    }
                    else
                    {
                        if (temp.Contains("SIGNED OUT"))
                        {
                            IsSigned = false;
                            ReceiverUnSigned();
                        }

                        if (!string.IsNullOrEmpty(sabreCommand))
                            Components.CommandsAPILog.WriteCommandIntoFile(sabreCommand);

                        sabreCommand = string.Empty;

                    }

                }

                if (message.Equals("IGD \n"))
                {
                    ConfigurationManager.AppSettings.Set("MirrorOn", "Off");
                }

            }
            catch (Exception)
            {
                return -1;
            }
            return 0;

        }


        /// <summary>
        /// Busca PNR en respuesta y asigna el área actual así como el PNR correspondiente a su área
        /// </summary>
        /// <param name="result">Respuesta API</param>
        private void FindPNR(string result)
        {
            result = result.Split(new char[] { '\n' })[0];
            //result = "BJKFTP";
            string pattern = @"^[a-zA-z]{6}$";
            Regex regExp = new Regex(pattern);
            result = result.Replace("\r", string.Empty);

            if (regExp.Match(result).Success)
            {
                Common.SetValueCurrentPNR(result);
            }
        }

        private void starthandler()
        {

#if (POLLING)
            {
                waitForManualResetPollingEvent();
            }
#else
            {
                waitForManualResetEvent();

            }
#endif
        }

        private void waitForManualResetEvent()
        {
            long WaitRet = API_ERROR;
            int[] handlesNotify = new int[2];
            int count;
            bool bNotifyAEventSet = false;
            bool bNotifyBEventSet = false;
            CreateNamedManualResetEvent(SABRE_API_NOTIFY_A, ref handlesNotify[0]);
            CreateNamedManualResetEvent(SABRE_API_NOTIFY_B, ref handlesNotify[1]);

            WaitRet = MySabreAPI.WaitForMultipleObjects(2, ref handlesNotify[0], 0, INFINITE);
            if (WaitRet == MySabreAPI.WAIT_OBJECT_0)
                bNotifyAEventSet = true;
            if (MySabreAPI.WAIT_OBJECT_0 + 1 == WaitRet)
                bNotifyBEventSet = true;
            if (bNotifyAEventSet | bNotifyBEventSet)
                checkStateChange();
            do
            {
                bool bWaitingOnA = !bNotifyAEventSet;
                if (bWaitingOnA)
                    count = 0;
                else
                    count = 1;
                WaitRet = MySabreAPI.WaitForSingleObject(handlesNotify[count], -1);
                if (WaitRet == MySabreAPI.WAIT_OBJECT_0)
                {
                    bNotifyAEventSet = bWaitingOnA;
                    checkStateChange();
                }
            } while (true);

        }

        private void checkStateChange()
        {
            int currentState = API_ERROR;
            int count;
            int output;



#if (POLLING) 
            {
                currentState = getApiStateFromEvents();
                if (previousState == API_SUSPENDED && currentState == API_READY)
                {
                    currentState = API_RESUME;
                    printAPIState(currentState);
                    previousState = API_READY;
                    return;
                }

            }
#else
            {
                currentState = getApiStateFromEventsWithResume();
            }
#endif
            if ((currentState != API_ERROR) && (currentState != previousState))
            {
                switch (currentState)
                {
                    case API_READY:
                        #region Connected
                        if (IsConnected)
                        {
                            client_Connect();
                            if (Listenercount > 0)
                            {
                                for (count = 1; count <= Listenercount; count++)
                                {
                                    output = CallBackHandler.beginSabreTrafficListener_stdcall(Convert.ToInt32(MESSAGE_TYPE), cb);
                                }
                            }
                        }
                        else
                        {
                            client_Connect();
                            begin_SabreTrafficListener();
                            LoadCommandsRestricted();
                            CheckConnection();
                        }
                        break;
                        #endregion
                    case API_UNAVAILABLE:
                        IsSigned = false;
                        IsConnected = false;
                        CloseObjects();
                        break;

                }
                previousState = currentState;
            }
        }

        #endregion

        #region Markup Handler

        delegate void SendMessageToHost(string command);
        private void SendMessageToHostCallBack(string command)
        {
            if (this.InvokeRequired)
                this.Invoke(new SendMessageToHost(SendMessageToHostCallBack), command);
            else
            {
                CommandsActions commandAction =
                    ListCommandsActions.Find(delegate(CommandsActions c)
                                       {
                                           return c.Command.Equals(command);
                                       });

                if (commandAction != null)
                {
                    if (commandAction.CommandType.Equals(COMMANDTYPE_MSG))
                    {
                        string msg = commandAction.Message;
                        //MessageBox.Show(msg);
                        CommandsAPI2.send_MessageToEmulator(msg);
                    }
                    else if (commandAction.CommandType.Equals(COMMANDTYPE_UC))
                    {
                        pnlMiddle.Controls.Clear();
                        pnlMiddle.Controls.Add(Loader.GetReferenceUserControl(commandAction.ModuleSrc));
                    }
                }
				else
                {
                    if (command.Contains("§"))
                        CommandsAPI2.send_MessageToEmulator("FORMATO NO DISPONIBLE");
                }
            }

        }

        private delegate void SenderParams(string command);
        private void ReceiverParams(string command)
        {
            if (this.InvokeRequired)
                this.Invoke(new SenderParams(ReceiverParams), command);
            else
            {

                SendMessageToHost smh = new SendMessageToHost(SendMessageToHostCallBack);
                smh.BeginInvoke(command, null, null);
            }

        }

        public int tempSabreMarkupHandler(int messageType, string message, string properties)
        {
            int retcode = 0;

            try
            {
                if (message.Length > 30 && message.Substring(0, 3) == "EM<")
                {
                }
                else
                {
                    if (messageType.Equals(1))
                    {
                        //ValidateMarkups por default es true, cuando se ejecuta del lado 
                        //de la aplicación es false
                        if (CommandsAPI.ValidateMarkups)
                        {
                            retcode = 2;
                            //Busca que el comando empiece con el que está registrado en la base de datos
                            CommandsActions commandAction =
                                ListCommandsActions.Find(delegate(CommandsActions c)
                                           {
                                               return message.StartsWith(c.Command);
                                           });
                            //Si Allow = false se valida el comando tal cual
                            if (commandAction != null)
                            {
                                if (!commandAction.Allow)
                                {
                                    retcode = 2;
                                }
                                else
                                {
                                    //Busca que el comando no contenga comandos restringidos
                                    string commandRestricted =
                                        commandAction.CommandsRestricted.Find(delegate(string c)
                                            { return message.Contains(c); });

                                    //si el comando contiene un comando restringido busca también que contenga comandos permitidos                            
                                    if (!string.IsNullOrEmpty(commandRestricted))
                                    {
                                        message = message.Replace(commandRestricted, string.Empty);
                                        string commandsAllowd = commandAction.CommandsAllowed.Find(delegate(string c)
                                        { return message.Contains(c); });

                                        if (!string.IsNullOrEmpty(commandsAllowd))
                                            retcode = 0;

                                    }
                                    else
                                    {
                                        string commandsAllowd = commandAction.CommandsAllowed.Find(delegate(string c)
                                       { return message.Contains(c); });

                                        if (!string.IsNullOrEmpty(commandsAllowd))
                                            retcode = 0;
                                    }
                                }

                            }
                            else
                            {
                                retcode = (message.Contains("§")) ? 2 : 0;
                            }

                            if (retcode.Equals(2))
                                ReceiverParams(message);
                        }
                    }

                    if (messageType.Equals(2))
                    {
                        retcode = 0;
                    }
                }
                return retcode;

            }
            catch (Exception)
            {
            }

            return retcode;
        }

        private void sendMarkupThread()
        {
            sendMarkup();
        }

        private void sendMarkup()
        {
            int ret = 0;

            //if (isDefaultMarkupDetails)
            //    ret = CallBackHandler.sendMarkup(ref markupInstructions);
            //else
            //    ret = CallBackHandler.sendMarkup(ref defaultMarkupInstructions);

            if (ret.Equals(3021))
            {
                //ok
            }
            else if (ret.Equals(3023))
            {
                //markup no registrado
            }
            else
            {
                //error
            }
        }

        #endregion

        #region API Métodos
        private void CreateNamedManualResetEvent(string name, ref int handle)
        {
            MySabreAPI.SECURITY_ATTRIBUTES sd = new MySabreAPI.SECURITY_ATTRIBUTES();
            handle = 0;
            sd.nLength = Microsoft.VisualBasic.Strings.Len(sd);
            sd.lpSecurityDescriptor = 0;
            sd.bInheritHandle = 0;
            handle = MySabreAPI.CreateEvent(ref sd, 1, 0, ref name);
        }

        private static bool isEventSet(string eventName)
        {
            bool bEventSet = false;
            int hEvent = API_ERROR;
            long WaitRet;
            hEvent = MySabreAPI.OpenEvent(MySabreAPI.EVENT_ALL_ACCESS, 0, ref eventName);
            if (hEvent != 0)
            {
                WaitRet = MySabreAPI.WaitForSingleObject(hEvent, 0);
                MySabreAPI.CloseHandle(hEvent);
                if (MySabreAPI.WAIT_OBJECT_0 == WaitRet)
                    bEventSet = true;
            }

            return bEventSet;

        }

        private int getApiStateFromEventsWithResume()
        {
            int apiState = getApiStateFromEvents();
            bool isResumeEventSet = isEventSet(SABRE_API_RESUME_EVENT_STATE);
            if (API_READY == apiState && isResumeEventSet)
                apiState = API_RESUME;

            return apiState;

        }

        public static int getApiStateFromEvents()
        {
            int apiState = API_ERROR;
            bool isLoadedEventSet = isEventSet(SABRE_API_LOADED_EVENT_STATE);
            bool isActiveEventSet = isEventSet(SABRE_API_ACTIVE_EVENT_STATE);
            bool isUpdatingEventSet = isEventSet(SABRE_API_UPDATING_EVENT_STATE);

            if (isLoadedEventSet && isActiveEventSet && !isUpdatingEventSet)
                apiState = API_READY;
            else if (isLoadedEventSet && !isActiveEventSet && !isUpdatingEventSet)
                apiState = API_SUSPENDED;
            else if (!isLoadedEventSet && !isActiveEventSet && isUpdatingEventSet)
                apiState = API_UPDATE;
            else if (!isLoadedEventSet && !isActiveEventSet && !isUpdatingEventSet)
                apiState = API_UNAVAILABLE;

            return apiState;
        }

        private void registerSabreMarkup(string commands)
        {
            try
            {
                int ret = 0;
                string markupProperties = string.Format(defaultMarkupProperties, commands);
                ret = CallBackHandler.registerSabreMarkup_stdcall(cbMarkup, ref markupProperties);

                if (ret.Equals(3001))
                    IsRegmarkup = true;
                else if (ret.Equals(3003))
                    IsRegmarkup = true;
                else
                {
                    //lblStatusRegister.Text = "Error al registrar markup";
                }

            }
            catch (Exception)
            {
                //lblStatusRegister.Text = "Error al registrar markup\nDescripción\n" + ex.ToString();
            }
        }

        private void unRegisterSabreMarkup()
        {
            try
            {
                int ret = 0;
                ret = CallBackHandler.unRegisterSabreMarkup();

                if (ret.Equals(3011))
                {
                    IsRegmarkup = false;
                }
                else if (ret.Equals(3013))
                {
                    //lblStatusRegister.Text = "Markup no registrado";
                }
                else
                {
                    //lblStatusRegister.Text = "Error al registrar markup";
                }

            }
            catch (Exception)
            {
                //lblStatusRegister.Text = "Error al registrar markup\nDescripción\n" + ex.ToString();
            }
        }

        private void load_Dll()
        {
            string emuapi = "emuapi.dll";
            handleMod = MySabreAPI.LoadLibrary(ref  emuapi);

        }

        private void unload_DLL()
        {
            string emuapi = "emuapi";
            int hVal = MySabreAPI.GetModuleHandle(ref emuapi);
            if (hVal != 0)
            {
                while (MySabreAPI.FreeLibrary(hVal))
                { }
            }
        }

        public void client_Connect()
        {
            int connected;
            int output = 0;
            string strVendorName = "MySabre API Development Team";
            string strVendorPcc = "PE51";
            string strApplicationName = "MySabre API Sample";
            string strApplicationVersion = "1.0";
            string strToken = "VKOG6WSS";
            handleMod = 0;

            try
            {
                mySabreAPI = new MySabreAPI();
                load_Dll();
                connected = MySabreAPI.clientConnect(ref strVendorName, ref strVendorPcc, ref strApplicationName, ref strApplicationVersion,
                    ref strToken, strToken.Length, 0, ref output);

                if (connected.Equals(0))
                {
                    IsConnected = true;

                }

            }
            catch (Exception)
            {
            }

        }

        private void client_Disconnect()
        {
            int IsDisconnected;
            mySabreAPI = null;

            IsDisconnected = MySabreAPI.clientDisconnect();

            if (IsDisconnected.Equals(0))
            {
                IsConnected = false;
                Listenercount = 0;
            }
        }

        #endregion

    }
}
