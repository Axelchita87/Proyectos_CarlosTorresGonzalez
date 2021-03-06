using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Presentation.Components;
using System.Text.RegularExpressions;
using System.Collections.Specialized;

namespace MyCTS.Presentation
{
    public partial class ucRemarksClass : CustomUserControl, IProcessAsync
    {

        /// <summary>
        /// Descripción: Rutina que permite obtener las clases vendidas y las clases disponibles para
        ///              el itinerario.
        /// Creación:    Mayo - Junio 09, Modificación: 18 nov 09
        /// Cambio:      Cambio de rutina en general (realizado por Marcos Q. Ramírez)
        /// Solicito:    Guillermo Granados
        /// Autor:       Omar Flores Gomez  
        /// </summary>
        /// 

        private static string bookingClass;
        public static string BookingClass
        {
            get { return bookingClass; }
            set { bookingClass = value; }
        }

        private string send = string.Empty;
        private string sabreAnswer = string.Empty;
        private string[] sabreAnswerInfo;
        private long sabreAnswerLong;
        private int row = 0;
        private int col = 0;
        private int ItineraryStart;
        private string remInfo;
        private int remInfoLenght;
        private string remInfoID;
        private string remInfoContent;

        public int contador = 0;

        private string flightAirline;
        private string flightNumber;
        private string date;
        private string cpa;
        private string sabre;
        private string sabreConcaten;
        private string responseAvailability;

        NameValueCollection TableSegments = new NameValueCollection();
        private string TableSegmentsRowNumber;
        private string[] TableSegmentsRowContent;
        private string TableSegmentsLine;
        private long TableSegmentsRows;
        private int copyRow;

        NameValueCollection tableClassAvailable = new NameValueCollection();
        NameValueCollection tableClassSold = new NameValueCollection();

        private int rowRemark;

        //********
        private string UC = string.Empty;
        //********



        public ucRemarksClass()
        {
            InitializeComponent();
        }


        //Evento ucRemarksClass_Load
        private void ucRemarksClass_Load(object sender, EventArgs e)
        {
            //frmPreloading fr = new frmPreloading(this);
            //fr.Show();
            ucAvailability.IsInterJetProcess = false;
            RemarksClass();
        }

        void IProcessAsync.InitProcess()
        {
            RemarksClass();
        }

        void IProcessAsync.EndProcess()
        {
            if (UC.Equals("generatingAccountableRemark"))
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_GENERATING_ACCOUNTABLE_REMARK);
        }


        #region ===== MethodsClass =====


        /// <summary>
        /// Genera los remarks de clases disponibles para el itinerario
        /// </summary>
        private void RemarksClass()
        {
            string active = activeStepsCorporativeQC.CorporativeQualityControls[0].RemarksAvailableClasses;
            send = string.Empty;
            sabreAnswer = string.Empty;
            row = 0;
            col = 0;

            send = Resources.TicketEmission.Constants.COMMANDS_AST_IAB;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }

            CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.ITINERARY, ref row, ref col);
            if (row != 0 || col != 0)
            {
                ItineraryStart = 1;
                sabreAnswerInfo = sabreAnswer.Split(new char[] { '\n' });
                sabreAnswerLong = sabreAnswerInfo.LongLength;
            }

            if (ItineraryStart == 1 && active.Equals(Resources.TicketEmission.Constants.ACTIVE))//Start Itinerary
            {
                sabreAnswerLong = sabreAnswerLong - 1;
            readItinerary:
                row = row + 1;
                if (row <= sabreAnswerLong)//Verify Long
                {
                    col = 0;
                    CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.ARUNK, ref row, ref col, row, row);

                    if (col > 0)
                    {
                        goto readItinerary;
                    }
                    else
                    {
                        try
                        {
                            remInfo = string.Empty;
                            CommandsQik.CopyResponse(sabreAnswer, ref remInfo, row, 1, 100);
                            try
                            {
                                remInfoID = remInfo.Substring(0, 2);
                            }
                            catch
                            {
                                remInfoID = remInfo.Substring(1, 2);
                            }
                            remInfoLenght = remInfo.Length - 2;
                            remInfoContent = remInfo.Substring(2, remInfoLenght);
                            TableSegments.Add(remInfoID, remInfoContent);
                            goto readItinerary;
                        }
                        catch
                        {
                            goto readItinerary;
                        }
                    }

                }// end Very1
                else
                {
                    TableSegmentsRows = TableSegments.Count;

                    copyRow = 0;
                copyClass:
                    copyRow = copyRow + 1;
                    if (copyRow <= TableSegmentsRows)//CopyStart
                    {
                        TableSegmentsRowNumber = TableSegments.GetKey(copyRow - 1);
                        TableSegmentsRowContent = TableSegments.GetValues(copyRow - 1);

                        String sTableSegmentsLineTemp = string.Format("{0}", TableSegmentsRowContent);
                        TableSegmentsLine = string.Format("{0}", TableSegmentsRowContent);
                        TableSegmentsLine.Trim();
                        TableSegmentsLine = TableSegmentsLine.Replace("¡ ", String.Empty);
                        TableSegmentsLine = TableSegmentsLine.Replace("¡", String.Empty);
                        flightAirline = TableSegmentsLine.Substring(1, 2);
                        flightAirline.Trim();
                        flightNumber = TableSegmentsLine.Substring(3, 4);
                        flightNumber.Trim();
                        bookingClass = TableSegmentsLine.Substring(7, 1); //Se cambia el 8 por el 7...
                        bookingClass.Trim();
                        date = TableSegmentsLine.Substring(9, 5);
                        date.Trim();
                        cpa = TableSegmentsLine.Substring(17, 7);
                        cpa.Trim();

                        sabre = Resources.TicketEmission.Constants.ONE + flightAirline.Trim() + flightNumber.Trim() + Resources.TicketEmission.Constants.SLASH + date.Trim() + cpa.Trim();


                        send = string.Empty;
                        sabreAnswer = string.Empty;
                        row = 0;
                        col = 0;

                        send = sabre.Trim();
                        using (CommandsAPI objCommand = new CommandsAPI())
                        {
                            sabreAnswer = objCommand.SendReceive(send);
                        }
                        CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.Constants.CROSS_LORAINE, ref row, ref col);

                        if (row == 0)
                        {
                            responseAvailability = string.Empty;
                            CommandsQik.CopyResponse(sabreAnswer, ref responseAvailability, 1, 1, 70);

                            sabre = string.Empty;
                            responseAvailability = responseAvailability.Replace(".", "").Trim();
                            responseAvailability = responseAvailability.Trim();
                            sabre = Resources.TicketEmission.Constants.COMMANDS_S + TableSegmentsRowNumber.Trim() + " " + "CLASE VENDIDA - " + bookingClass;
                            tableClassSold.Add(TableSegmentsRowNumber.Trim(), sabre);
                            tableClassAvailable.Add(copyRow.ToString(), responseAvailability);
                            contador = Convert.ToInt32(TableSegmentsRowNumber.Trim());
                            goto copyClass;

                        }
                        else
                        {

                            contador = contador + 1;

                            sabre = string.Empty;
                            sabre = Resources.TicketEmission.Constants.COMMANDS_S + contador + " " + "CLASE VENDIDA - " + bookingClass;
                            tableClassSold.Add(TableSegmentsRowNumber.Trim(),sabre);
                            tableClassAvailable.Add(copyRow.ToString(), Resources.TicketEmission.Constants.NO_HAY_DISPONIBILIDAD_SEGEMENTO);
                            goto copyClass;
                        }
                        //else
                        //{
                        //    goto copyClass;
                        //}


                    }
                    else
                    {
                        sabre = string.Empty;
                        sabreConcaten = string.Empty;

                        rowRemark = 0;
                    buildRemarks:
                        rowRemark = rowRemark + 1;
                        sabreConcaten = sabreConcaten + sabre;
                        if (rowRemark <= tableClassSold.Count)
                        {

                            sabre = string.Format("{0}", tableClassSold.GetValues(rowRemark - 1));
                            sabre = Resources.TicketEmission.Constants.COMMANDS_FIVE_CROSSLORAINE + sabre + Resources.TicketEmission.Constants.ENDIT + Resources.TicketEmission.Constants.COMMANDS_FIVE_CROSS_LORAINE_S + string.Format("{0}", tableClassSold.GetKey(rowRemark - 1)) + " " + string.Format("{0}", tableClassAvailable.GetValues(rowRemark - 1));
                            int lastEndit = sabre.IndexOf('Σ', 30);
                            if ((sabre.Length - lastEndit) > 70)
                            {
                                sabre = sabre.Insert(lastEndit + 70, Resources.TicketEmission.Constants.ENDIT + Resources.TicketEmission.Constants.COMMANDS_FIVE_CROSS_LORAINE_S + tableClassSold.GetKey(rowRemark - 1) + " ");
                            }
                            if (rowRemark > 1)
                            {
                                sabre = Resources.TicketEmission.Constants.ENDIT + sabre;
                            }
                            goto buildRemarks;



                        }
                        else
                        {

                            send = string.Empty;
                            sabreAnswer = string.Empty;
                            row = 0;
                            col = 0;
                            send = sabreConcaten;
                            if (!string.IsNullOrEmpty(send))
                            {
                                using (CommandsAPI objCommand = new CommandsAPI())
                                {
                                    sabreAnswer = objCommand.SendReceive(send);
                                }
                            }
                            //UC = "generatingAccountableRemark";//
                            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_GENERATING_ACCOUNTABLE_REMARK);


                        }



                    }




                }//end Very2

            }//End Start Itinerary
            else
            {
                //UC = "generatingAccountableRemark";// 
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_GENERATING_ACCOUNTABLE_REMARK);

            }

        }//End RemarksClass



        #endregion


    }
}