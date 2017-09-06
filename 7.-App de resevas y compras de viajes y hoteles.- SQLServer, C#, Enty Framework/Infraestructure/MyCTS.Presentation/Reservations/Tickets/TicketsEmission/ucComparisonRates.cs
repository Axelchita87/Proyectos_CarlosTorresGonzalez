using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Presentation.Components;
using System.Text.RegularExpressions;


namespace MyCTS.Presentation
{
    public partial class ucComparisonRates : CustomUserControl, IProcessAsync
    {
        /// <summary>
        /// Descripcion: Permite hacer la comparación de las Tárifas,pertenece a Emitir Boleto
        /// Creación:    3/Junio/09 , Modificación:08/Abril/10
        /// Cambio:      No mandar Remarks con 5.S* , Solicito Memo
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        #region ======= Declaration of Variable Static =======

        private static string answer;
        public static string Answer
        {
            get { return answer; }
            set { answer = value; }
        }

        private static bool basefare;
        public static bool BaseFare
        {
            get { return basefare; }
            set { basefare = value; }
        }

        private static string rate_sinimp_low_nd;
        public static string rate_SinImp_Low_ND
        {
            get { return rate_sinimp_low_nd; }
            set { rate_sinimp_low_nd = value; }
        }

        private static string rate_conimp_low_nd;
        public static string rate_ConImp_Low_ND
        {
            get { return rate_conimp_low_nd; }
            set { rate_conimp_low_nd = value; }
        }

        private static string rate_conimp_low_d;
        public static string rate_ConImp_Low_D
        {
            get { return rate_conimp_low_d; }
            set { rate_conimp_low_d = value; }
        }

        private static string rate_sinimp_low_d;
        public static string rate_SinImp_Low_D
        {
            get { return rate_sinimp_low_d; }
            set { rate_sinimp_low_d = value; }
        }

        //Standar
        private static string rate_conimp_stan;
        public static string rate_ConImp_Stan
        {
            get { return rate_conimp_stan; }
            set { rate_conimp_stan = value; }
        }

        private static string rate_sinimp_stan;
        public static string rate_SinImp_Stan
        {
            get { return rate_sinimp_stan; }
            set { rate_sinimp_stan = value; }
        }

        //Especific
        private static string rate_conimp_espe;
        public static string rate_ConImp_Espe
        {
            get { return rate_conimp_espe; }
            set { rate_conimp_espe = value; }
        }

        private static string rate_sinimp_espe;
        public static string rate_SinImp_Espe
        {
            get { return rate_sinimp_espe; }
            set { rate_sinimp_espe = value; }
        }

        //Business
        private static string rate_conimp_busi;
        public static string rate_ConImp_Busi
        {
            get { return rate_conimp_busi; }
            set { rate_conimp_busi = value; }
        }

        private static string rate_sinimp_busi;
        public static string rate_SinImp_Busi
        {
            get { return rate_sinimp_busi; }
            set { rate_sinimp_busi = value; }
        }

        #endregion

        #region ======= Declaration of Variable =======

        string send = string.Empty;
        string result = string.Empty;
        public string book_fare_Low_D;
        public string temp_WPNC_SI;
        public string temp_WPNCS_SI;
        public string temp_WPNCS_CI;
        public string book_fare_Low_ND;
        public string temp_WPNC_CI;

        #endregion

        public ucComparisonRates()
        {
            InitializeComponent();
        }

        //User Control Load
        /// <summary>
        /// Primero se limpian las Variables
        /// Se extraen los comparativos de las tárifas si es que se encuentran activas 
        /// Se hace la comparación cuando estas se encuentran activas
        /// Y al finalizar se va a otro User Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucComparisonRates_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            //frmPreloading fr = new frmPreloading(this);
            //fr.Show();
            Cleanvariable();

            #region ======== Extract DataBase =========

            string comparativeMoreEconomicFareNotAvailable = activeStepsCorporativeQC.CorporativeQualityControls[0].ComparativeMoreEconomicFareNotAvailable;
            string comparativeMoreEconomicFareAvailable = activeStepsCorporativeQC.CorporativeQualityControls[0].ComparativeMoreEconomicFareAvailable;
            string comparativeStandardFare = activeStepsCorporativeQC.CorporativeQualityControls[0].ComparativeStandardFare;
            string comparativeSpecificFare = activeStepsCorporativeQC.CorporativeQualityControls[0].ComparativeSpecificFare;
            string comparativeBusinessFare = activeStepsCorporativeQC.CorporativeQualityControls[0].ComparativeBusinessFare;
            // string remarkfj = activeStepsCorporativeQC.CorporativeQualityControls[0].RemarkFJ;
            #endregion

            if (comparativeMoreEconomicFareNotAvailable == Resources.TicketEmission.Constants.ACTIVE)
                Validation_wpncs();
            if (comparativeMoreEconomicFareAvailable == Resources.TicketEmission.Constants.ACTIVE)
                Validation_wpnc();
            if (comparativeStandardFare == Resources.TicketEmission.Constants.ACTIVE)
                Validation_wpoc_standar();
            if (comparativeSpecificFare == Resources.TicketEmission.Constants.ACTIVE)
                Validation_wpoc_specific();
            if (comparativeBusinessFare == Resources.TicketEmission.Constants.ACTIVE)
                Validation_wpoc_bussines();

            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_COMPARING_FARES);
        }

        void IProcessAsync.InitProcess()
        {
            Cleanvariable();

            #region ======== Extract DataBase =========

            string comparativeMoreEconomicFareNotAvailable = activeStepsCorporativeQC.CorporativeQualityControls[0].ComparativeMoreEconomicFareNotAvailable;
            string comparativeMoreEconomicFareAvailable = activeStepsCorporativeQC.CorporativeQualityControls[0].ComparativeMoreEconomicFareAvailable;
            string comparativeStandardFare = activeStepsCorporativeQC.CorporativeQualityControls[0].ComparativeStandardFare;
            string comparativeSpecificFare = activeStepsCorporativeQC.CorporativeQualityControls[0].ComparativeSpecificFare;
            string comparativeBusinessFare = activeStepsCorporativeQC.CorporativeQualityControls[0].ComparativeBusinessFare;
            // string remarkfj = activeStepsCorporativeQC.CorporativeQualityControls[0].RemarkFJ;
            #endregion

            if (comparativeMoreEconomicFareNotAvailable == Resources.TicketEmission.Constants.ACTIVE)
                Validation_wpncs();
            if (comparativeMoreEconomicFareAvailable == Resources.TicketEmission.Constants.ACTIVE)
                Validation_wpnc();
            if (comparativeStandardFare == Resources.TicketEmission.Constants.ACTIVE)
                Validation_wpoc_standar();
            if (comparativeSpecificFare == Resources.TicketEmission.Constants.ACTIVE)
                Validation_wpoc_specific();
            if (comparativeBusinessFare == Resources.TicketEmission.Constants.ACTIVE)
                Validation_wpoc_bussines();
        }

        void IProcessAsync.EndProcess()
        {
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_COMPARING_FARES);
        }



        #region===== MethodsClass =====

        /// <summary>
        /// Se manda un commando y se busca la Base fare y si se encontro 
        /// se empiza a copiar los datos necesarios para armar el comando
        /// de la tárifa más baja no disponible 
        /// </summary>
        private void Validation_wpncs()
        {
            Answer = result;
            BaseFare = false;
            int row = 0;
            int col = 0;
            send = Resources.TicketEmission.Constants.COMMANDS_WPNCS;
            MyCTS.Presentation.Parameters.TimeExtendedAPI = true;
            try
            {
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
            }
            catch { }
            MyCTS.Presentation.Parameters.TimeExtendedAPI = false;
            CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.BASE_FARE, ref row, ref col);
            if (row != 0 || col != 0)
            {
                BaseFare = true;
                row = 0;
                col = 0;
            }
            if (BaseFare)
            {
                CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.TOTAL, ref row, ref col, 1, 4, 30, 64);
                if (row != 0 || col != 0)
                {
                    row = row + 1;
                    CommandsQik.CopyResponse(result, ref temp_WPNCS_CI, row, 47, 14);
                    temp_WPNCS_CI = temp_WPNCS_CI.Replace(Resources.TicketEmission.Constants.MXN, Resources.TicketEmission.Constants.SPACE);
                    temp_WPNCS_CI = temp_WPNCS_CI.Trim();
                    rate_ConImp_Low_ND = temp_WPNCS_CI;
                    col = 0;
                    row = 0;
                }
                CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.EQUIV_AMT, ref row, ref col);
                if (row != 0 || col != 0)
                {
                    row = row + 1;
                    CommandsQik.CopyResponse(result, ref temp_WPNCS_SI, row, 19, 14);
                    temp_WPNCS_SI = temp_WPNCS_SI.Replace(Resources.TicketEmission.Constants.MXN, Resources.TicketEmission.Constants.SPACE);
                    temp_WPNCS_SI = temp_WPNCS_SI.Trim();
                    rate_SinImp_Low_ND = temp_WPNCS_SI;
                    col = 0;
                    row = 0;
                    BaseFare = false;
                }
                if (BaseFare)
                {
                    CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.BASE_FARE, ref row, ref col, 1, 4, 1, 20);
                    if (row != 0 || col != 0)
                    {
                        row = row + 1;
                        CommandsQik.CopyResponse(result, ref temp_WPNCS_SI, row, 5, 14);
                        temp_WPNCS_SI = temp_WPNCS_SI.Replace(Resources.TicketEmission.Constants.MXN, Resources.TicketEmission.Constants.SPACE);
                        temp_WPNCS_SI = temp_WPNCS_SI.Trim();
                        rate_SinImp_Low_ND = temp_WPNCS_SI;
                        col = 0;
                        row = 0;
                    }
                }
                CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.ADT, ref row, ref col, 5, 7, 1, 4);
                if (row != 0 || col != 0)
                {
                    CommandsQik.CopyResponse(result, ref book_fare_Low_ND, row, 9, 30);
                    col = 0;
                    row = 0;
                }
            }
            else
            {
                string hourscad;
                string hour;
                string day;
                string month;
                DateTime time = DateTime.Now;
                hour = time.ToString("hh:mm");
                hourscad = Convert.ToString(hour);
                hour = Regex.Replace(hourscad, @"[^\w\.@¥-]", "");
                day = time.ToString("dd");
                month = time.ToString("MMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
                send = Resources.TicketEmission.Constants.COMMANDS_5H_NO_DETERMINO_TARIFA_MAS_BAJA_NO_DISPONIBLE_WPNCS_AST +
                    hour + Resources.TicketEmission.Constants.AST + day + month;
                rate_ConImp_Low_ND = "0";
                rate_SinImp_Low_ND = "0";
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    objCommands.SendReceive(send);
                }
            }
        }

        /// <summary>
        /// Se manda un commando y se busca la Base fare y si se encontro 
        /// se empiza a copiar los datos necesarios para armar el comando
        /// de la tárifa más económica disponible 
        /// </summary>
        private void Validation_wpnc()
        {
            string remarkcmefa = activeStepsCorporativeQC.CorporativeQualityControls[0].RemarkCMEFA;
            string remarkcmefna = activeStepsCorporativeQC.CorporativeQualityControls[0].RemarkCMEFNA;
            string result = string.Empty;
            string sabre = remarkcmefna;
            string contactSabrecs = string.Empty;
            string contactSabrec = string.Empty;
            Answer = result;
            BaseFare = false;
            int row = 0;
            int col = 0;
            string send = string.Empty;
            send = Resources.TicketEmission.Constants.COMMANDS_WPNC;
            MyCTS.Presentation.Parameters.TimeExtendedAPI = true;
            try
            {
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
            }
            catch { }
            MyCTS.Presentation.Parameters.TimeExtendedAPI = false;
            CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.BASE_FARE, ref row, ref col);
            if (row != 0 || col != 0)
            {
                BaseFare = true;
                row = 0;
                col = 0;
            }
            if (BaseFare)
            {
                CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.TOTAL, ref row, ref col, 1, 4, 30, 64);
                if (row != 0 || col != 0)
                {
                    row = row + 1;
                    CommandsQik.CopyResponse(result, ref temp_WPNC_CI, row, 47, 14);
                    temp_WPNC_CI = temp_WPNC_CI.Replace(Resources.TicketEmission.Constants.MXN, Resources.TicketEmission.Constants.SPACE);
                    temp_WPNC_CI = temp_WPNC_CI.Trim();
                    rate_ConImp_Low_D = temp_WPNC_CI;
                    col = 0;
                    row = 0;
                }
                CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.EQUIV_AMT, ref row, ref col);
                if (row != 0 || col != 0)
                {
                    row = row + 1;
                    CommandsQik.CopyResponse(result, ref temp_WPNC_SI, row, 19, 14);
                    temp_WPNC_SI = temp_WPNC_SI.Replace(Resources.TicketEmission.Constants.MXN, Resources.TicketEmission.Constants.SPACE);
                    temp_WPNC_SI = temp_WPNC_SI.Trim();
                    rate_SinImp_Low_D = temp_WPNC_SI;
                    col = 0;
                    row = 0;
                    BaseFare = false;
                }
                if (BaseFare)
                {
                    CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.BASE_FARE, ref row, ref col, 1, 4, 1, 20);
                    if (row != 0 || col != 0)
                    {
                        row = row + 1;
                        CommandsQik.CopyResponse(result, ref temp_WPNC_SI, row, 5, 14);
                        temp_WPNC_SI = temp_WPNC_SI.Replace(Resources.TicketEmission.Constants.MXN, Resources.TicketEmission.Constants.SPACE);
                        temp_WPNC_SI = temp_WPNC_SI.Trim();
                        rate_SinImp_Low_D = temp_WPNC_SI;
                        col = 0;
                        row = 0;
                    }
                }
                CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.ADT, ref row, ref col, 5, 7, 1, 4);
                if (row != 0 || col != 0)
                {
                    CommandsQik.CopyResponse(result, ref book_fare_Low_D, row, 9, 30);
                    col = 0;
                    row = 0;
                }
            }
            else
            {
                string hourscad;
                string hour;
                string day;
                string month;
                DateTime time = DateTime.Now;
                hour = time.ToString("hh:mm");
                hourscad = Convert.ToString(hour);
                hour = Regex.Replace(hourscad, @"[^\w\.@¥-]", "");
                day = time.ToString("dd");
                month = time.ToString("MMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
                send = Resources.TicketEmission.Constants.COMMANDS_5H_NO_DETERMINO_TARIFA_MAS_BAJA_DISPONIBLE_WPNC_AST +
                    hour + Resources.TicketEmission.Constants.AST + day + month;
                rate_ConImp_Low_D = "0";
                rate_SinImp_Low_D = "0";
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    objCommands.SendReceive(send);
                }
            }
            if (!string.IsNullOrEmpty(rate_ConImp_Low_ND))
            {
                //5.S*LF
                contactSabrecs = rate_ConImp_Low_ND + Resources.TicketEmission.Constants.INDENT +
                    rate_SinImp_Low_ND + Resources.TicketEmission.Constants.INDENT +
                    book_fare_Low_ND + Resources.TicketEmission.Constants.COMMANDS_TARIFA_MAS_ECONOMICA_NO_DISPONIBLE;
            }
            if (!string.IsNullOrEmpty(rate_ConImp_Low_D))
            {
                //5.S*LC
                contactSabrec = remarkcmefa + rate_ConImp_Low_D +
                    Resources.TicketEmission.Constants.INDENT + rate_SinImp_Low_D +
                    Resources.TicketEmission.Constants.INDENT + book_fare_Low_D +
                    Resources.TicketEmission.Constants.COMMANDS_TARIFA_MAS_ECONOMICA_DISPONIBLE;
            }

            #region===== Se manejaba con ICAVV ======
            //if ((!string.IsNullOrEmpty(contactSabrecs)) && (!string.IsNullOrEmpty(contactSabrec)))
            //{
            //    send = sabre + contactSabrecs + Resources.TicketEmission.Constants.END_ITEM + contactSabrec;
            //    using (CommandsAPI objCommands = new CommandsAPI())
            //    {
            //        objCommands.SendReceive(send);
            //    }
            //}

            //if (string.IsNullOrEmpty(contactSabrecs) && (!string.IsNullOrEmpty(contactSabrec)))
            //{
            //    send = sabre + contactSabrec;
            //    using (CommandsAPI objCommands = new CommandsAPI())
            //    {
            //        objCommands.SendReceive(send);
            //    }
            //}

            //if ((!string.IsNullOrEmpty(contactSabrecs)) && (string.IsNullOrEmpty(contactSabrec)))
            //{
            //    send = contactSabrecs;
            //    using (CommandsAPI objCommands = new CommandsAPI())
            //    {
            //        objCommands.SendReceive(send);
            //    }
            //}
            #endregion
        }

        /// <summary>
        /// Primero buscamos el La etiqueta a armar y despues extraemos las clases
        /// de comparativos Standard y se manda el comando para armar el comando 
        /// que se va a utilizar
        /// </summary>
        private void Validation_wpoc_standar()
        {
            string remarkcstdf = activeStepsCorporativeQC.CorporativeQualityControls[0].RemarkCStdF;
            string result = string.Empty;
            string sabre = remarkcstdf;
            string temp_WPOCY_CI = string.Empty;
            string temp_WPOCY_SI = string.Empty;
            string book_fare_full = string.Empty;
            Answer = result;
            BaseFare = false;
            int row = 0;
            int col = 0;
            string send = string.Empty;
            string classComparativeStandard = ucFirstValidations.CorporativeQualityControls[0].ClassComparativeStandard;
            send = Resources.TicketEmission.Constants.COMMANDS_WPOC_B + classComparativeStandard;
            MyCTS.Presentation.Parameters.TimeExtendedAPI = true;
            try
            {
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
            }
            catch { }
            MyCTS.Presentation.Parameters.TimeExtendedAPI = false;
            CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.BASE_FARE, ref row, ref col);
            if (row != 0 || col != 0)
            {
                BaseFare = true;
                row = 0;
                col = 0;
            }
            if (BaseFare)
            {
                CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.TOTAL, ref row, ref col, 1, 4, 30, 64);
                if (row != 0 || col != 0)
                {
                    row = row + 1;
                    CommandsQik.CopyResponse(result, ref temp_WPOCY_CI, row, 47, 14);
                    temp_WPOCY_CI = temp_WPOCY_CI.Replace(Resources.TicketEmission.Constants.MXN, Resources.TicketEmission.Constants.SPACE);
                    temp_WPOCY_CI = temp_WPOCY_CI.Trim();
                    rate_ConImp_Stan = temp_WPOCY_CI;
                    col = 0;
                    row = 0;
                }
                CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.EQUIV_AMT, ref row, ref col);
                if (row != 0 || col != 0)
                {
                    row = row + 1;
                    CommandsQik.CopyResponse(result, ref temp_WPOCY_SI, row, 19, 14);
                    temp_WPOCY_SI = temp_WPOCY_SI.Replace(Resources.TicketEmission.Constants.MXN, Resources.TicketEmission.Constants.SPACE);
                    temp_WPOCY_SI = temp_WPOCY_SI.Trim();
                    rate_SinImp_Stan = temp_WPOCY_SI;
                    col = 0;
                    row = 0;
                    BaseFare = false;
                }
                if (BaseFare)
                {
                    CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.BASE_FARE, ref row, ref col, 1, 4, 1, 20);
                    if (row != 0 || col != 0)
                    {
                        row = row + 1;
                        CommandsQik.CopyResponse(result, ref temp_WPOCY_SI, row, 5, 14);
                        temp_WPOCY_SI = temp_WPOCY_SI.Replace(Resources.TicketEmission.Constants.MXN, Resources.TicketEmission.Constants.SPACE);
                        temp_WPOCY_SI = temp_WPOCY_SI.Trim();
                        rate_SinImp_Stan = temp_WPOCY_SI;
                        col = 0;
                        row = 0;
                    }
                }
                CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.ADT, ref row, ref col, 5, 7, 1, 4);
                if (row != 0 || col != 0)
                {
                    CommandsQik.CopyResponse(result, ref book_fare_full, row, 9, 30);
                    col = 0;
                    row = 0;
                    //5.S*FF
                    send = sabre + rate_ConImp_Stan + Resources.TicketEmission.Constants.INDENT +
                        rate_SinImp_Stan + Resources.TicketEmission.Constants.INDENT +
                        book_fare_full + Resources.TicketEmission.Constants.COMMANDS_TARIFA_BASE_ESTANDAR;
                    //using (CommandsAPI objCommands = new CommandsAPI())
                    //{
                    //    objCommands.SendReceive(send);
                    //}
                }
            }
            else
            {
                string hourscad;
                string hour;
                string day;
                string month;
                DateTime time = DateTime.Now;
                hour = time.ToString("hh:mm");
                hourscad = Convert.ToString(hour);
                hour = Regex.Replace(hourscad, @"[^\w\.@¥-]", "");
                day = time.ToString("dd");
                month = time.ToString("MMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
                send = Resources.TicketEmission.Constants.COMMANDS_5H_NO_DETERMINO_TARIFA_ESTANDAR_AST +
                    hour + Resources.TicketEmission.Constants.AST + day + month;
                rate_ConImp_Stan = "0";
                rate_SinImp_Stan = "0";
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    objCommands.SendReceive(send);
                }
            }
        }

        /// <summary>
        /// Extraemos la etiqueta que se va usar desde la Base de Datos
        /// Se extrae la clase de comparativo para la especifica
        /// se manda el commando y se busca una etiqueta
        /// despues de encontrarla se arma el commando
        /// </summary>
        private void Validation_wpoc_specific()
        {
            string remarkcspcf = activeStepsCorporativeQC.CorporativeQualityControls[0].RemarkCSpcF;
            string result = string.Empty;
            string sabre = remarkcspcf;
            string temp_WPOCK_CI = string.Empty;
            string temp_WPOCK_SI = string.Empty;
            string book_fare_med = string.Empty;
            Answer = result;
            BaseFare = false;
            int row = 0;
            int col = 0;
            string send = string.Empty;
            string classComparativeSpecific = ucFirstValidations.CorporativeQualityControls[0].ClassComparativeSpecific;
            send = Resources.TicketEmission.Constants.COMMANDS_WPOC_B + classComparativeSpecific;
            MyCTS.Presentation.Parameters.TimeExtendedAPI = true;
            try
            {
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    result = objCommands.SendReceive(send);
                }
            }
            catch { }
            MyCTS.Presentation.Parameters.TimeExtendedAPI = false;
            CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.BASE_FARE, ref row, ref col);
            if (row != 0 || col != 0)
            {
                BaseFare = true;
                row = 0;
                col = 0;
            }
            if (BaseFare)
            {
                CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.TOTAL, ref row, ref col, 1, 4, 30, 64);
                if (row != 0 || col != 0)
                {
                    row = row + 1;
                    CommandsQik.CopyResponse(result, ref temp_WPOCK_CI, row, 47, 14);
                    temp_WPOCK_CI = temp_WPOCK_CI.Replace(Resources.TicketEmission.Constants.MXN, Resources.TicketEmission.Constants.SPACE);
                    temp_WPOCK_CI = temp_WPOCK_CI.Trim();
                    rate_ConImp_Espe = temp_WPOCK_CI;
                    col = 0;
                    row = 0;
                }
                CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.EQUIV_AMT, ref row, ref col);
                if (row != 0 || col != 0)
                {
                    row = row + 1;
                    CommandsQik.CopyResponse(result, ref temp_WPOCK_SI, row, 19, 14);
                    temp_WPOCK_SI = temp_WPOCK_SI.Replace(Resources.TicketEmission.Constants.MXN, Resources.TicketEmission.Constants.SPACE);
                    temp_WPOCK_SI = temp_WPOCK_SI.Trim();
                    rate_SinImp_Espe = temp_WPOCK_SI;
                    col = 0;
                    row = 0;
                    BaseFare = false;
                }
                if (BaseFare)
                {
                    CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.BASE_FARE, ref row, ref col, 1, 4, 1, 20);
                    if (row != 0 || col != 0)
                    {
                        row = row + 1;
                        CommandsQik.CopyResponse(result, ref temp_WPOCK_SI, row, 5, 14);
                        temp_WPOCK_SI = temp_WPOCK_SI.Replace(Resources.TicketEmission.Constants.MXN, Resources.TicketEmission.Constants.SPACE);
                        temp_WPOCK_SI = temp_WPOCK_SI.Trim();
                        rate_SinImp_Espe = temp_WPOCK_SI;
                        col = 0;
                        row = 0;
                    }
                }

                CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.ADT, ref row, ref col, 5, 7, 1, 4);
                if (row != 0 || col != 0)
                {
                    CommandsQik.CopyResponse(result, ref book_fare_med, row, 9, 30);
                    col = 0;
                    row = 0;
                    //sabre 5.S*FM
                    send = sabre + rate_ConImp_Espe + Resources.TicketEmission.Constants.INDENT +
                        rate_SinImp_Espe + Resources.TicketEmission.Constants.INDENT +
                        book_fare_med + Resources.TicketEmission.Constants.COMMANDS_TARIFA_BASE_ESPECIFICA;
                    //using (CommandsAPI objCommands = new CommandsAPI())
                    //{
                    //    objCommands.SendReceive(send);
                    //}
                }
            }
            else
            {
                string hourscad;
                string hour;
                string day;
                string month;
                DateTime time = DateTime.Now;
                hour = time.ToString("hh:mm");
                hourscad = Convert.ToString(hour);
                hour = Regex.Replace(hourscad, @"[^\w\.@¥-]", "");
                day = time.ToString("dd");
                month = time.ToString("MMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
                send = Resources.TicketEmission.Constants.COMMANDS_5H_NO_DETERMINO_TARIFA_ESPECIFICA_AST +
                    hour + Resources.TicketEmission.Constants.AST + day + month;
                rate_ConImp_Espe = "0";
                rate_SinImp_Espe = "0";
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    objCommands.SendReceive(send);
                }
            }
        }

        /// <summary>
        /// Se extrae la etiqueta que va aser usada
        /// tambien extraemos los comparativos de la clase bussines
        /// Se manda un commando y se busca una etiqueta y se sique mandando el comando pero con
        /// los diferentes comparativos de clases bussines hasta encontrar esa etiqueta
        /// Cuando la encuentra se arma el commando 
        /// </summary>
        private void Validation_wpoc_bussines()
        {
            string remarkcbnsf = activeStepsCorporativeQC.CorporativeQualityControls[0].RemarkCBnsF;
            string result = string.Empty;
            string sabre = remarkcbnsf;
            string temp_WPOCB_CI = string.Empty;
            string temp_WPOCB_SI = string.Empty;
            string book_fare_busi = string.Empty;
            Answer = result;
            BaseFare = false;
            int row = 0;
            int col = 0;
            int attemptsClass = 0;
            string send = string.Empty;
            string classComparativeBusiness1 = ucFirstValidations.CorporativeQualityControls[0].ClassComparativeBusiness1;
            string classComparativeBusiness2 = ucFirstValidations.CorporativeQualityControls[0].ClassComparativeBusiness2;
            string classComparativeBusiness3 = ucFirstValidations.CorporativeQualityControls[0].ClassComparativeBusiness3;
            string classComparativeBusiness4 = ucFirstValidations.CorporativeQualityControls[0].ClassComparativeBusiness4;

            while (attemptsClass < 5)
            {
                CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.BASE_FARE, ref row, ref col);
                if (row != 0 || col != 0)
                {
                    BaseFare = true;
                    row = 0;
                    col = 0;
                    break;
                }
                attemptsClass += 1;

                if (!BaseFare && attemptsClass == 1)
                {
                    send = Resources.TicketEmission.Constants.COMMANDS_WPOC_B + classComparativeBusiness1;
                    MyCTS.Presentation.Parameters.TimeExtendedAPI = true;
                    try
                    {
                        using (CommandsAPI objCommands = new CommandsAPI())
                        {
                            result = objCommands.SendReceive(send);
                        }
                    }
                    catch { }
                    MyCTS.Presentation.Parameters.TimeExtendedAPI = false;
                }
                if (!BaseFare && attemptsClass == 2)
                {
                    send = Resources.TicketEmission.Constants.COMMANDS_WPOC_B + classComparativeBusiness2;
                    MyCTS.Presentation.Parameters.TimeExtendedAPI = true;
                    try
                    {
                        using (CommandsAPI objCommands = new CommandsAPI())
                        {
                            result = objCommands.SendReceive(send);
                        }
                    }
                    catch { }
                    MyCTS.Presentation.Parameters.TimeExtendedAPI = false;
                }
                else if (!BaseFare && attemptsClass == 3)
                {
                    send = Resources.TicketEmission.Constants.COMMANDS_WPOC_B + classComparativeBusiness3;
                    MyCTS.Presentation.Parameters.TimeExtendedAPI = true;
                    try
                    {
                        using (CommandsAPI objCommands = new CommandsAPI())
                        {
                            result = objCommands.SendReceive(send);
                        }
                    }
                    catch { }
                    MyCTS.Presentation.Parameters.TimeExtendedAPI = false;
                }
                else if (!BaseFare && attemptsClass == 4)
                {
                    send = Resources.TicketEmission.Constants.COMMANDS_WPOC_B + classComparativeBusiness4;
                    MyCTS.Presentation.Parameters.TimeExtendedAPI = true;
                    try
                    {
                        using (CommandsAPI objCommands = new CommandsAPI())
                        {
                            result = objCommands.SendReceive(send);
                        }
                    }
                    catch { }
                    MyCTS.Presentation.Parameters.TimeExtendedAPI = false;
                }
            }
            if (BaseFare)
            {
                CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.TOTAL, ref row, ref col, 1, 4, 30, 64);
                if (row != 0 || col != 0)
                {
                    row = row + 1;
                    CommandsQik.CopyResponse(result, ref temp_WPOCB_CI, row, 47, 14);
                    temp_WPOCB_CI = temp_WPOCB_CI.Replace(Resources.TicketEmission.Constants.MXN, Resources.TicketEmission.Constants.SPACE);
                    temp_WPOCB_CI = temp_WPOCB_CI.Trim();
                    rate_ConImp_Busi = temp_WPOCB_CI;
                    col = 0;
                    row = 0;
                }
                CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.EQUIV_AMT, ref row, ref col);
                if (row != 0 || col != 0)
                {
                    row = row + 1;
                    CommandsQik.CopyResponse(result, ref temp_WPOCB_SI, row, 19, 14);
                    temp_WPOCB_SI = temp_WPOCB_SI.Replace(Resources.TicketEmission.Constants.MXN, Resources.TicketEmission.Constants.SPACE);
                    temp_WPOCB_SI = temp_WPOCB_SI.Trim();
                    rate_SinImp_Busi = temp_WPOCB_SI;
                    col = 0;
                    row = 0;
                    BaseFare = false;
                }
                if (BaseFare)
                {
                    CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.BASE_FARE, ref row, ref col, 1, 4, 1, 20);
                    if (row != 0 || col != 0)
                    {
                        row = row + 1;
                        CommandsQik.CopyResponse(result, ref temp_WPOCB_SI, row, 5, 14);
                        temp_WPOCB_SI = temp_WPOCB_SI.Replace(Resources.TicketEmission.Constants.MXN, Resources.TicketEmission.Constants.SPACE);
                        temp_WPOCB_SI = temp_WPOCB_SI.Trim();
                        rate_SinImp_Busi = temp_WPOCB_SI;
                        col = 0;
                        row = 0;
                    }
                }
                CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.ADT, ref row, ref col, 5, 7, 1, 4);
                if (row != 0 || col != 0)
                {
                    CommandsQik.CopyResponse(result, ref book_fare_busi, row, 9, 30);
                    col = 0;
                    row = 0;
                    //sabre 5.S*FB
                    send = sabre + rate_ConImp_Busi + Resources.TicketEmission.Constants.INDENT +
                        rate_SinImp_Busi + Resources.TicketEmission.Constants.INDENT +
                        book_fare_busi + Resources.TicketEmission.Constants.COMMANDS_TARIFA_BASE_BUSINESS;
                    //using (CommandsAPI objCommands = new CommandsAPI())
                    //{
                    //    objCommands.SendReceive(send);
                    //}
                }
            }
            else if (!BaseFare && attemptsClass == 5)
            {
                string hourscad;
                string hour;
                string day;
                string month;
                DateTime time = DateTime.Now;
                hour = time.ToString("hh:mm");
                hourscad = Convert.ToString(hour);
                hour = Regex.Replace(hourscad, @"[^\w\.@¥-]", "");
                day = time.ToString("dd");
                month = time.ToString("MMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
                send = Resources.TicketEmission.Constants.COMMANDS_5H_NO_DETERMINO_TARIFA_BUSINESS_AST +
                    hour + Resources.TicketEmission.Constants.AST + day + month;
                rate_ConImp_Busi = "0";
                rate_SinImp_Busi = "0";
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    objCommands.SendReceive(send);
                }
            }
        }

        /// <summary>
        /// Se limpian las variables 
        /// </summary>
        private void Cleanvariable()
        {
            rate_ConImp_Low_D = string.Empty;
            rate_ConImp_Low_ND = string.Empty;
            rate_ConImp_Busi = string.Empty;
            rate_ConImp_Espe = string.Empty;
            rate_ConImp_Stan = string.Empty;
            rate_SinImp_Low_D = string.Empty;
            rate_SinImp_Low_ND = string.Empty;
            rate_SinImp_Busi = string.Empty;
            rate_SinImp_Espe = string.Empty;
            rate_SinImp_Stan = string.Empty;
        }

        #endregion
    }
}
