using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucRatingActualFare : CustomUserControl, IProcessAsync
    {
        /// <summary>
        /// Descripción: User Control que permite la tarifa vendida con impuestos y sin 
        ///              impuestos y conservar el valor en variables estaticas para su utilizacion 
        ///              en otros procedimientos del flujo de emision de boletos
        /// Creación:    Mayo - Junio 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        /// 
        private static string farewithtaxessold;
        public static string fareWithTaxesSold
        {
            get { return farewithtaxessold; }
            set { farewithtaxessold = value; }
        }

        private static string farewithouttaxessold;
        public static string fareWithoutTaxesSold
        {
            get { return farewithouttaxessold; }
            set { farewithouttaxessold = value; }
        }

        private static bool internationalflight;
        public static bool internationalFlight
        {
            get { return internationalflight; }
            set { internationalflight = value; }
        }

        private static string farebasissold;
        public static string fareBasisSold
        {
            get { return farebasissold; }
            set { farebasissold = value; }
        }

        private string tempFareWithTaxes = string.Empty;
        private string tempFareWithoutTaxes = string.Empty;
        //*********
        private string UC = string.Empty;
        //*********
        public ucRatingActualFare()
        {
            InitializeComponent();
        }

        private void ucRatingActualFare_Load(object sender, EventArgs e)
        {
            //frmPreloading fr = new frmPreloading(this);
            //fr.Show();
            ucAvailability.IsInterJetProcess = false;
            RatingActualFare();
        }

        void IProcessAsync.InitProcess()
        {
            RatingActualFare();
        }
        void IProcessAsync.EndProcess()
        {
            if (UC.Equals("comparisonRates"))
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_COMPARISON_RATES);
            else if (UC.Equals("welcome"))
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }

        #region ===== MethodsClass =====


        /// <summary>
        /// >Obtención de la tarifa vendida con o sin impuestos y 
        /// asignacion de valores a variables estaticas
        /// </summary>
        private void RatingActualFare()
        {
            farewithtaxessold = string.Empty;
            farewithouttaxessold = string.Empty;
            string active = activeStepsCorporativeQC.CorporativeQualityControls[0].CuotingActualFare;
            string send = string.Empty;
            string sabreAnswer = string.Empty;
            int row = 0;
            int col = 0;
            if (active.Equals(Resources.TicketEmission.Constants.ACTIVE))
            {
                send = Resources.TicketEmission.Constants.COMMANDS_WP;
                MyCTS.Presentation.Parameters.TimeExtendedAPI = true;
                try
                {
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        sabreAnswer = objCommand.SendReceive(send);
                    }
                }
                catch { }
                MyCTS.Presentation.Parameters.TimeExtendedAPI = false;
                CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.BASE_FARE, ref row, ref col);
                if (row != 0 || col != 0)
                {
                    CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.TOTAL, ref row, ref col, 1, 4, 30, 64);
                    if (row != 0 || col != 0)
                    {
                        row = row + 1;
                        tempFareWithTaxes = string.Empty;
                        CommandsQik.CopyResponse(sabreAnswer, ref tempFareWithTaxes, row, 47, 14);
                        tempFareWithTaxes = tempFareWithTaxes.Replace(Resources.TicketEmission.Constants.MXN, Resources.TicketEmission.Constants.SPACE);
                        tempFareWithTaxes = tempFareWithTaxes.Trim();
                        farewithtaxessold = tempFareWithTaxes;

                        row = 0;
                        col = 0;
                        CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.EQUIV_AMT, ref row, ref col, 1, 4, 15, 40);
                        if (row != 0 || col != 0)
                        {
                            row = row + 1;
                            tempFareWithoutTaxes = string.Empty;
                            CommandsQik.CopyResponse(sabreAnswer, ref tempFareWithoutTaxes, row, 19, 14);
                            tempFareWithoutTaxes = tempFareWithoutTaxes.Replace(Resources.TicketEmission.Constants.MXN, Resources.TicketEmission.Constants.SPACE);
                            tempFareWithoutTaxes = tempFareWithoutTaxes.Trim();
                            farewithouttaxessold = tempFareWithoutTaxes;
                            internationalflight = true;
                        }
                        else
                        {
                            CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.BASE_FARE, ref row, ref col, 1, 4, 1, 20);
                            if (row != 0 || col != 0)
                            {
                                row = row + 1;
                                tempFareWithoutTaxes = string.Empty;
                                CommandsQik.CopyResponse(sabreAnswer, ref tempFareWithoutTaxes, row, 5, 14);
                                tempFareWithoutTaxes = tempFareWithoutTaxes.Replace(Resources.TicketEmission.Constants.MXN, Resources.TicketEmission.Constants.SPACE);
                                tempFareWithoutTaxes = tempFareWithoutTaxes.Trim();
                                farewithouttaxessold = tempFareWithoutTaxes;
                                internationalflight = false;
                            }
                        }
                        row = 0;
                        col = 0;
                        CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.ADT, ref row, ref col, 5, 7, 1, 4);
                        if (row != 0 || col != 0)
                        {
                            farebasissold = string.Empty;
                            CommandsQik.CopyResponse(sabreAnswer, ref farebasissold, row, 9, 30);
                        }
                    }
                    //UC = "comparisonRates";// 
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_COMPARISON_RATES);
                }
                else
                {
                    send = Resources.TicketEmission.Constants.COMMANDS_AST_PQ;
                    using (CommandsAPI objCommand = new CommandsAPI())
                    {
                        sabreAnswer = objCommand.SendReceive(send);
                    }
                    row = 0;
                    col = 0;
                    CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.PRICE_QUOTE_RECORD_DETAILS, ref row, ref col);
                    if (row != 0 || col != 0)
                    {
                        send = Resources.TicketEmission.Constants.COMMANDS_5H_NO_SE_PUDO_CALC_TARIFA_AUTO;
                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            sabreAnswer = objCommand.SendReceive(send);
                        }
                        //UC = "comparisonRates";// 
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_COMPARISON_RATES);
                    }
                    else
                    {
                        MessageBox.Show(Resources.TicketEmission.Tickets.NO_CALC_TARIFA_VENDIDA_RECOTIZA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //UC = "welcome";// 
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                    }
                }

            }
            else
            {
                //UC = "comparisonRates";// 
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_COMPARISON_RATES);
            }
        }
        #endregion//End MethodsClass
    }
}