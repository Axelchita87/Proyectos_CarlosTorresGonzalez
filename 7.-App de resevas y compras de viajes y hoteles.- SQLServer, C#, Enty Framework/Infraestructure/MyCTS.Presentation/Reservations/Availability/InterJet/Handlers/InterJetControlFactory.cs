using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{
    public class InterJetControlFactory
    {

        #region Default Coordinates for an Adult PAX


        private static readonly int X_BASECOORD_PANEL_ADULT = 5;
        private static readonly int Y_BASECOORD_PANEL_ADULT = 41;

        private static readonly int X_HEIGHT_PANEL_ADULT = 430;
        private static readonly int Y_WIDHT_PANEL_ADULT = 27;

        private static readonly int X_BASECOORD_CLUBINTERJET_ADULT = 3;
        private static readonly int Y_BASECOORD_CLUBINTERJET_ADULT = 2;

        private static readonly int X_WIDHT_CLUBINTERJET_ADULT = 44;
        private static readonly int Y_HEIGHT_CLUBINTERJET_ADULT = 20;

        private static readonly int X_BASECOORD_TITLE_ADULT = 53;
        private static readonly int Y_BASECOORD_TITLE_ADULT = 2;

        private static readonly int X_WIDHT_TITLE_ADULT = 45;
        private static readonly int Y_HEIGHT_TITLE_ADULT = 21;

        private static readonly int X_BASECOORD_NAME_ADULT = 104;
        private static readonly int Y_BASECOORD_NAME_ADULT = 2;

        private static readonly int X_WIDHT_NAME_ADULT = 88;
        private static readonly int Y_HEIGHT_NAME_ADULT = 20;

        private static readonly int X_BASECOORD_LASTNAME_ADULT = 198;
        private static readonly int Y_BASECOORD_LASTNAME_ADULT = 2;

        private static readonly int X_WIDHT_LASTNAME_ADULT = 118;
        private static readonly int Y_HEIGHT_LASTNAME_ADULT = 20;

        private static readonly int X_BASECOORD_SUFFIX_ADULT = 322;
        private static readonly int Y_BASECOORD_SUFFIX_ADULT = 3;

        private static readonly int X_WIDHT_SUFFIX_ADULT = 53;
        private static readonly int Y_HEIGHT_SUFFIX_ADULT = 21;

        private static readonly int X_BASECOORD_ADULT_ISCONTACT = 390;
        private static readonly int Y_BASECOORD_ADULT_ISCONTACT = 8;

        private static readonly int X_WIDHT_ADULT_ISCONTACT = 15;
        private static readonly int Y_HEIGHT_ADULT_ISCONTACT = 14;


        #endregion

        #region Default Coordinates for a SENIOR PAX

        private static readonly int X_BASECOORD_PANEL_SENIOR = 6;
        private static readonly int Y_BASECOORD_PANEL_SENIOR = 33;

        private static readonly int X_HEIGHT_PANEL_SENIOR = 430;
        private static readonly int Y_WIDHT_PANEL_SENIOR = 30;

        private static readonly int X_BASECOORD_CLUBINTERJET_SENIOR = 3;
        private static readonly int Y_BASECOORD_CLUBINTERJET_SENIOR = 2;

        private static readonly int X_WIDHT_CLUBINTERJET_SENIOR = 44;
        private static readonly int Y_HEIGHT_CLUBINTERJET_SENIOR = 20;

        private static readonly int X_BASECOORD_TITLE_SENIOR = 53;
        private static readonly int Y_BASECOORD_TITLE_SENIOR = 2;

        private static readonly int X_WIDHT_TITLE_SENIOR = 45;
        private static readonly int Y_HEIGHT_TITLE_SENIOR = 21;

        private static readonly int X_BASECOORD_NAME_SENIOR = 104;
        private static readonly int Y_BASECOORD_NAME_SENIOR = 2;

        private static readonly int X_WIDHT_NAME_SENIOR = 88;
        private static readonly int Y_HEIGHT_NAME_SENIOR = 20;

        private static readonly int X_BASECOORD_LASTNAME_SENIOR = 198;
        private static readonly int Y_BASECOORD_LASTNAME_SENIOR = 2;

        private static readonly int X_WIDHT_LASTNAME_SENIOR = 118;
        private static readonly int Y_HEIGHT_LASTNAME_SENIOR = 20;

        private static readonly int X_BASECOORD_SUFFIX_SENIOR = 322;
        private static readonly int Y_BASECOORD_SUFFIX_SENIOR = 3;

        private static readonly int X_WIDHT_SUFFIX_SENIOR = 53;
        private static readonly int Y_HEIGHT_SUFFIX_SENIOR = 21;

        private static readonly int X_BASECOORD_SENIOR_ISCONTACT = 389;
        private static readonly int Y_BASECOORD_SENIOR_ISCONTACT = 5;

        private static readonly int X_WIDHT_SENIOR_ISCONTACT = 15;
        private static readonly int Y_HEIGHT_SENIOR_ISCONTACT = 14;


        #endregion

        #region Default Coordinates for a Child PAX


        private static readonly int X_BASECOORD_PANEL_CHILD = 6;
        private static readonly int Y_BASECOORD_PANEL_CHILD = 33;

        private static readonly int X_HEIGHT_PANEL_CHILD = 430;
        private static readonly int Y_WIDHT_PANEL_CHILD = 30;

        private static readonly int X_BASECOORD_CLUBINTERJET_CHILD = 3;
        private static readonly int Y_BASECOORD_CLUBINTERJET_CHILD = 2;

        private static readonly int X_WIDHT_CLUBINTERJET_CHILD = 44;
        private static readonly int Y_HEIGHT_CLUBINTERJET_CHILD = 20;

        private static readonly int X_BASECOORD_TITLE_CHILD = 53;
        private static readonly int Y_BASECOORD_TITLE_CHILD = 2;

        private static readonly int X_WIDHT_TITLE_CHILD = 45;
        private static readonly int Y_HEIGHT_TITLE_CHILD = 21;

        private static readonly int X_BASECOORD_NAME_CHILD = 104;
        private static readonly int Y_BASECOORD_NAME_CHILD = 2;

        private static readonly int X_WIDHT_NAME_CHILD = 88;
        private static readonly int Y_HEIGHT_NAME_CHILD = 20;

        private static readonly int X_BASECOORD_LASTNAME_CHILD = 198;
        private static readonly int Y_BASECOORD_LASTNAME_CHILD = 2;

        private static readonly int X_WIDHT_LASTNAME_CHILD = 118;
        private static readonly int Y_HEIGHT_LASTNAME_CHILD = 20;

        private static readonly int X_BASECOORD_SUFFIX_CHILD = 322;
        private static readonly int Y_BASECOORD_SUFFIX_CHILD = 3;

        private static readonly int X_WIDHT_SUFFIX_CHILD = 53;
        private static readonly int Y_HEIGHT_SUFFIX_CHILD = 21;

        private static readonly int X_BASECOORD_CHILD_ISCONTACT = 389;
        private static readonly int Y_BASECOORD_CHILD_ISCONTACT = 6;

        private static readonly int X_WIDHT_CHILD_ISCONTACT = 15;
        private static readonly int Y_HEIGHT_CHILD_ISCONTACT = 14;
        #endregion

        #region Default Coordinates for Special Services

        private static readonly int X_BASECOORD_PANEL_SPECIAL_SERVICE = 6;
        private static readonly int Y_BASECOORD_PANEL_SPECIAL_SERVICE = 41;

        private static readonly int X_HEIGHT_PANEL_SPECIAL_SERVICE = 434;
        private static readonly int Y_WIDHT_PANEL_SPECIAL_SERVICE = 53;


        private static readonly int X_BASECOORD_CHECKBOXSPECIALSERVICE = 26;
        private static readonly int Y_BASECOORD_CHECKBOXSPECIALSERVICE = 10; // antes era 3

        private static readonly int X_HEIGHT_CHECKBOXSPECIALSERVICE = 20;
        private static readonly int Y_WIDHT_CHECKBOXSPECIALSERVICE = 9; // antes era 4

        private static readonly int X_BASECOORD_COMBOBOX_TYPEOFSERVICE = 66;
        private static readonly int Y_BASECOORD_COMBOBOX_TYPEOFSERVICE = 3;

        private static readonly int X_HEIGHT_COMBOBOX_TYPEOFSERVICE = 126;
        private static readonly int Y_WIDHT_COMBOBOX_TYPEOFSERVICE = 21;


        private static readonly int X_BASECOORD_COMBOBOX_NUMBEROFSERVICES = 229;
        private static readonly int Y_BASECOORD_COMBOBOX_NUMBEROFSERVICES = 3;

        private static readonly int X_HEIGHT_COMBOBOX_NUMBEROFSERVICES = 41;
        private static readonly int Y_WIDHT_COMBOBOX_NUMBEROFSERVICES = 21;


        private static readonly int X_BASECOORD_COMBOBOX_FLIGTH = 291;
        private static readonly int Y_BASECOORD_COMBOBOX_FLIGTH = 3;

        private static readonly int X_HEIGHT_COMBOBOX_FLIGTH = 109;
        private static readonly int Y_WIDHT_COMBOBOX_FLIGTH = 21;


        private static readonly int X_BASECOORD_NOTELABEL = 27;
        private static readonly int Y_BASECOORD_NOTELABEL = 33;

        private static readonly int X_HEIGHT_NOTELABEL = 33;
        private static readonly int Y_WIDHT_NOTELABEL = 13;

        private static readonly int X_BASECOORD_NOTETEXTBOX = 66;
        private static readonly int Y_BASECOORD_NOTETEXTBOX = 30;

        private static readonly int X_HEIGHT_NOTETEXTBOX = 334;
        private static readonly int Y_WIDHT_NOTETEXTBOX = 20;




        #endregion

        #region Default Coordinates Infant

        private static readonly int X_BASECOORD_PANEL_INFANTS = 3;
        private static readonly int Y_BASECOORD_PANEL_INFANTS = 3;

        private static readonly int X_HEIGHT_PANEL_INFANTS = 466;
        private static readonly int Y_WIDHT_PANEL_INFANTS = 170;

        private static readonly int X_BASECOORD_INFANTS_GROUPBOX = 14;
        private static readonly int Y_BASECOORD_INFANTS_GROUPBOX = 3;

        private static readonly int X_HEIGHT_INFANTS_GROUPBOX = 445;
        private static readonly int Y_WIDHT_INFANTS_GROUPBOX = 156;

        private static readonly int X_BASECOORD_INFANT_GENDER_COMBOBOX = 85;
        private static readonly int Y_BASECOORD_INFANT_GENDER_COMBOBOX = 95;

        private static readonly int X_HEIGHT_INFANT_GENDER_COMBOBOX = 58;
        private static readonly int Y_WIDHT_INFANT_GENDER_COMBOBOX = 21;

        private static readonly int X_BASECOORD_INFANT_GENDER_LABEL = 18;
        private static readonly int Y_BASECOORD_INFANT_GENDER_LABEL = 99;

        private static readonly int X_HEIGHT_INFANT_GENDER_LABEL = 34;
        private static readonly int Y_WIDHT_INFANT_GENDER_LABEL = 13;

        private static readonly int X_BASECOORD_INFANT_YEAR_COMBOBOX = 354;
        private static readonly int Y_BASECOORD_INFANT_YEAR_COMBOBOX = 124;

        private static readonly int X_HEIGHT_INFANT_YEAR_COMBOBOX = 72;
        private static readonly int Y_WIDHT_INFANT_YEAR_COMBOBOX = 21;

        private static readonly int X_BASECOORD_INFANT_MONTH_COMBOBOX = 248;
        private static readonly int Y_BASECOORD_INFANT_MONTH_COMBOBOX = 124;

        private static readonly int X_HEIGHT_INFANT_MONTH_COMBOBOX = 100;
        private static readonly int Y_WIDHT_INFANT_MONTH_COMBOBOX = 21;

        private static readonly int X_BASECOORD_INFANT_DAY_COMBOBOX = 192;
        private static readonly int Y_BASECOORD_INFANT_DAY_COMBOBOX = 124;

        private static readonly int X_HEIGHT_INFANT_DAY_COMBOBOX = 50;
        private static readonly int Y_WIDHT_INFANT_DAY_COMBOBOX = 21;

        private static readonly int X_BASECOORD_INFANT_DATOFBIRTH_LABEL = 3;
        private static readonly int Y_BASECOORD_INFANT_DATOFBIRTH_LABEL = 119;

        private static readonly int X_HEIGHT_INFANT_DATOFBIRTH_LABEL = 183;
        private static readonly int Y_WIDHT_INFANT_DATOFBIRTH_LABEL = 26;

        private static readonly int X_BASECOORD_INFANT_COUNTRY_COMBOBOX = 277;
        private static readonly int Y_BASECOORD_INFANT_COUNTRY_COMBOBOX = 71;

        private static readonly int X_HEIGHT_INFANT_COUNTRY_COMBOBOX = 121;
        private static readonly int Y_WIDHT_INFANT_COUNTRY_COMBOBOX = 21;

        private static readonly int X_BASECOORD_INFANT_COUNTRY_LABEL = 227;
        private static readonly int Y_BASECOORD_INFANT_COUNTRY_LABEL = 71;

        private static readonly int X_HEIGHT_INFANT_COUNTRY_LABEL = 32;
        private static readonly int Y_WIDHT_INFANT_COUNTRY_LABEL = 13;

        private static readonly int X_BASECOORD_INFANT_NACIONALITY_LABEL = 7;
        private static readonly int Y_BASECOORD_INFANT_NACIONALITY_LABEL = 71;

        private static readonly int X_HEIGHT_INFANT_NACIONALITY_LABEL = 72;
        private static readonly int Y_WIDHT_INFANT_NACIONALITY_LABEL = 13;

        private static readonly int X_BASECOORD_INFANT_NACIONALITY_COMBOBOX = 85;
        private static readonly int Y_BASECOORD_INFANT_NACIONALITY_COMBOBOX = 68;

        private static readonly int X_HEIGHT_INFANT_NACIONALITY_COMBOBOX = 130;
        private static readonly int Y_WIDHT_INFANT_NACIONALITY_COMBOBOX = 21;

        private static readonly int X_BASECOORD_INFANT_LASTNAME_TEXTBOX = 277;
        private static readonly int Y_BASECOORD_INFANT_LASTNAME_TEXTBOX = 48;

        private static readonly int X_HEIGHT_INFANT_LASTNAME_TEXTBOX = 121;
        private static readonly int Y_WIDHT_INFANT_LASTNAME_TEXTBOX = 20;

        private static readonly int X_BASECOORD_INFANT_LASTNAME_LABEL = 223;
        private static readonly int Y_BASECOORD_INFANT_LASTNAME_LABEL = 49;

        private static readonly int X_HEIGHT_INFANT_LASTNAME_LABEL = 47;
        private static readonly int Y_WIDHT_INFANT_LASTNAME_LABEL = 13;

        private static readonly int X_BASECOORD_INFANT_NAME_TEXTBOX = 85;
        private static readonly int Y_BASECOORD_INFANT_NAME_TEXTBOX = 45;

        private static readonly int X_HEIGHT_INFANT_NAME_TEXTBOX = 130;
        private static readonly int Y_WIDHT_INFANT_NAME_TEXTBOX = 20;

        private static readonly int X_BASECOORD_INFANT_NAME_LABEL = 18;
        private static readonly int Y_BASECOORD_INFANT_NAME_LABEL = 49;

        private static readonly int X_HEIGHT_INFANT_NAME_LABEL = 47;
        private static readonly int Y_WIDHT_INFANT_NAME_LABEL = 13;

        private static readonly int X_BASECOORD_INFANT_TITLE_LABEL = 223;
        private static readonly int Y_BASECOORD_INFANT_TITLE_LABEL = 25;

        private static readonly int X_HEIGHT_INFANT_TITLE_LABEL = 36;
        private static readonly int Y_WIDHT_INFANT_TITLE_LABEL = 13;

        private static readonly int X_BASECOORD_INFANT_TITLE_COMBOBOX = 277;
        private static readonly int Y_BASECOORD_INFANT_TITLE_COMBOBOX = 21;

        private static readonly int X_HEIGHT_INFANT_TITLE_COMBOBOX = 121;
        private static readonly int Y_WIDHT_INFANT_TITLE_COMBOBOX = 21;


        private static readonly int X_BASECOORD_INFANT_TRAVELWITH_LABEL = 6;
        private static readonly int Y_BASECOORD_INFANT_TRAVELWITH_LABEL = 25;

        private static readonly int X_HEIGHT_INFANT_TRAVELWITH_LABEL = 73;
        private static readonly int Y_WIDHT_INFANT_TRAVELWITH_LABEL = 13;

        private static readonly int X_BASECOORD_INFANT_TRAVELWITH_COMBOBOX = 85;
        private static readonly int Y_BASECOORD_INFANT_TRAVELWITH_COMBOBOX = 22;

        private static readonly int X_HEIGHT_INFANT_TRAVELWITH_COMBOBOX = 130;
        private static readonly int Y_WIDHT_INFANT_TRAVELWITH_COMBOBOX = 21;




        #endregion

        #region Default Coordinate for Flight resume.
        private static readonly int X_BASECOORD_GROUPBOX_FLIGHTRESUME = 12;
        private static readonly int Y_BASECOORD_GROUPBOX_FLIGHTRESUME = 12;

        private static readonly int X_HEIGHT_GROUPBOX_FLIGHTRESUME = 470;
        private static readonly int Y_WIDHT_GROUPBOX_FLIGHTRESUME = 178;


        private static readonly int X_BASECOORD_CONTAINER_FLIGHTRESUME = 6;
        private static readonly int Y_BASECOORD_CONTAINER_FLIGHTRESUME = 19;

        private static readonly int X_HEIGHT_CONTAINER_FLIGHTRESUME = 442;
        private static readonly int Y_WIDHT_CONTAINER_FLIGHTRESUME = 151;

        private static readonly int X_BASECOORD_HEADER_FLIGHTRESUME = 10;
        private static readonly int Y_BASECOORD_HEADER_FLIGHTRESUME = 9;

        private static readonly int X_HEIGHT_HEADER_FLIGHTRESUME = 183;
        private static readonly int Y_WIDHT_HEADER_FLIGHTRESUME = 26;

        private static readonly int X_BASECOORD_ADULT_FLIGHTRESUME = 10;
        private static readonly int Y_BASECOORD_ADULT_FLIGHTRESUME = 40;

        private static readonly int X_HEIGHT_ADULT_FLIGHTRESUME = 117;
        private static readonly int Y_WIDHT_ADULT_FLIGHTRESUME = 78;


        private static readonly int X_BASECOORD_SENIOR_FLIGHTRESUME = 142;
        private static readonly int Y_BASECOORD_SENIOR_FLIGHTRESUME = 40;

        private static readonly int X_HEIGHT_SENIOR_FLIGHTRESUME = 117;
        private static readonly int Y_WIDHT_SENIOR_FLIGHTRESUME = 78;


        private static readonly int X_BASECOORD_CHILD_FLIGHTRESUME = 292;
        private static readonly int Y_BASECOORD_CHILD_FLIGHTRESUME = 40;

        private static readonly int X_HEIGHT_CHILD_FLIGHTRESUME = 117;
        private static readonly int Y_WIDHT_CHILD_FLIGHTRESUME = 78;

        private static readonly int X_BASECOORD_PRICE_FLIGHTRESUME = 285;
        private static readonly int Y_BASECOORD_PRICE_FLIGHTRESUME = 128;

        private static readonly int X_HEIGHT_PRICE_FLIGHTRESUME = 148;
        private static readonly int Y_WIDHT_PRICE_FLIGHTRESUME = 13;


        #endregion

        #region Default location for reservation resume
        private static readonly int X_BASECOORD_PAX_RESERVATIONRESUME_GROUP = 32; // point
        private static readonly int Y_BASECOORD_PAX_RESERVATIONRESUME_GROUP = 40;

        //private static readonly int X_HEIGHT_PAX_RESERVATIONRESUME_GROUP = 85; // size
        //private static readonly int Y_WIDHT_PAX_RESERVATIONRESUME_GROUP = 495;

        private static readonly int X_HEIGHT_PAX_RESERVATIONRESUME_GROUP = 495; // size
        private static readonly int Y_WIDHT_PAX_RESERVATIONRESUME_GROUP = 85;

        private static readonly int X_BASECOORD_PAX_RESERVATIONRESUME_LABEL = 6; // point
        private static readonly int Y_BASECOORD_PAX_RESERVATIONRESUME_LABEL = 25;

        private static readonly int X_HEIGHT_PAX_RESERVATIONRESUME_LABEL = 194; // size
        private static readonly int Y_WIDHT_PAX_RESERVATIONRESUME_LABEL = 26;




        private static readonly int X_BASECOORD_SEGMENTS_RESERVATIONRESUME_GROUP = 32;  // point
        private static readonly int Y_BASECOORD_SEGMENTS_RESERVATIONRESUME_GROUP = 139;

        //private static readonly int X_HEIGHT_SEGMENTS_RESERVATIONRESUME_GROUP = 109; // size
        //private static readonly int Y_WIDHT_SEGMENTS_RESERVATIONRESUME_GROUP = 495;
        private static readonly int X_HEIGHT_SEGMENTS_RESERVATIONRESUME_GROUP = 495; // size
        private static readonly int Y_WIDHT_SEGMENTS_RESERVATIONRESUME_GROUP = 109;


        private static readonly int X_BASECOORD_SEGMENTS_RESERVATIONRESUME_LABEL = 6; // point
        private static readonly int Y_BASECOORD_SEGMENTS_RESERVATIONRESUME_LABEL = 16;

        private static readonly int X_HEIGHT_SEGMENTS_RESERVATIONRESUME_LABEL = 122; // size
        private static readonly int Y_WIDHT_SEGMENTS_RESERVATIONRESUME_LABEL = 78;






        private static readonly int X_BASECOORD_FARES_RESERVATIONRESUME_GROUP = 32; // point
        private static readonly int Y_BASECOORD_FARES_RESERVATIONRESUME_GROUP = 139;

        //private static readonly int X_HEIGHT_FARES_RESERVATIONRESUME_GROUP = 88; // size
        //private static readonly int Y_WIDHT_FARES_RESERVATIONRESUME_GROUP = 495;


        private static readonly int X_HEIGHT_FARES_RESERVATIONRESUME_GROUP = 495; // size
        private static readonly int Y_WIDHT_FARES_RESERVATIONRESUME_GROUP = 88;

        private static readonly int X_BASECOORD_FARES_RESERVATIONRESUME_LABEL = 6; // point
        private static readonly int Y_BASECOORD_FARES_RESERVATIONRESUME_LABEL = 25;

        private static readonly int X_HEIGHT_FARES_RESERVATIONRESUME_LABEL = 145; // size
        private static readonly int Y_WIDHT_FARES_RESERVATIONRESUME_LABEL = 52;





        private static readonly int X_BASECOORD_PAX_RESERVATIONRESUME_PANEL = 29; // point
        private static readonly int Y_BASECOORD_PAX_RESERVATIONRESUME_PANEL = 40;

        private static readonly int X_HEIGHT_PAX_RESERVATIONRESUME_PANEL = 92; // size
        private static readonly int Y_WIDHT_PAX_RESERVATIONRESUME_PANEL = 496;


        private static readonly int X_BASECOORD_SEGMENTS_RESERVATIONRESUME_PANEL = 0;  // point
        private static readonly int Y_BASECOORD_SEGMENTS_RESERVATIONRESUME_PANEL = 0;

        private static readonly int X_HEIGHT_SEGMENTS_RESERVATIONRESUME_PANEL = 121; // size
        private static readonly int Y_WIDHT_SEGMENTS_RESERVATIONRESUME_PANEL = 497;



        private static readonly int X_BASECOORD_FARES_RESERVATIONRESUME_PANEL = 0; // point
        private static readonly int Y_BASECOORD_FARES_RESERVATIONRESUME_PANEL = 0;

        private static readonly int X_HEIGHT_FARES_RESERVATIONRESUME_PANEL = 129; // size
        private static readonly int Y_WIDHT_FARES_RESERVATIONRESUME_PANEL = 496;






        #endregion

        #region DEfault Coordinates for panel

        private static readonly int X_BASECOORD_PANEL_PASSANGER = 18; // point
        private static readonly int Y_BASECOORD_PANEL_PASSANGER = 120;//19

        private static readonly int X_HEIGHT_PANEL_PASSANGER = 0; // size
        private static readonly int Y_WIDHT_PANEL_PASSANGER = 0;

        private static readonly int X_BASECOORD_PANEL_INFANT = 1; // point
        private static readonly int Y_BASECOORD_PANEL_INFANT = 19;

        //private static readonly int X_HEIGHT_PANEL_INFANT = 430; // size
        //private static readonly int Y_WIDHT_PANEL_INFANT = 158;

        private static readonly int X_HEIGHT_PANEL_INFANT = 0; // size
        private static readonly int Y_WIDHT_PANEL_INFANT = 0;
        #endregion

        #region Constants

        private static readonly int Displacement = 7;
        #endregion
        #region DefaultLabels

        //TODO: checar salto de linea.
        private const string PASSANGER_CONFIRMATIONLABEL = "Pasajero:{0}\r\nCodigo de Confirmación :{1}\r\n";
        private const string SEGMENTS_CONFIRMATIONLABEL = "{0} a {1}                    \r\n------------------------- \r\nSegmento: {2}-{3}\r\nNo." +
                " Vuelo: {4}\r\nFecha: {5}\r\nHora : {6} - {7}\n\n";

        private const string FARE_CONFIRMATIONLABEL = "Tarifa Base MXN ({0}-{1}) {2}\r\nTUA XV ({3}-{4}) {5}\r\nIVA MX ({6}-{7}) " +
                " {8}\r\nTarifa Total {9}\n\n";
        #endregion

        #region Dispatcher

        //private Dictionary<string, Func<int, Control[]>> dispatcher;
        //private Dictionary<string, Func<int, Control[]>> DispatchControl
        //{
        //    get
        //    {
        //        if (this.dispatcher == null)
        //        {

        //            this.dispatcher = new Dictionary<string, Func<int, Control[]>>();
        //            this.dispatcher.Add("Adult", this.GetAdultsContols);
        //            this.dispatcher.Add("Children", this.GetAdultsContols);
        //            this.dispatcher.Add("Seniors", this.GetAdultsContols);
        //        }
        //        return this.dispatcher;

        //    }
        //}
        #endregion

        #region Dispatcher Handler

        private Control[] GetAdultsContols(int numberOfPax)
        {
            List<Control> controls = new List<Control>();
            int displacement = 0;
            int amountToDisplace = 25;
            for (int paxIndex = 0; paxIndex < numberOfPax; paxIndex++)
            {

                controls.Add(this.CreateDynamicRowControlsForAdultsPax(paxIndex, displacement));
                displacement += amountToDisplace;
            }
            return controls.ToArray();
        }

        private Control[] GetInfantsControls(int numberOfInfants, Hashtable session)
        {
            List<Control> controls = new List<Control>();
            int displacement = 0;

            for (int paxIndex = 0; paxIndex < numberOfInfants; paxIndex++)
            {

                controls.Add(this.CreateDynamicControlsForInfants(paxIndex, displacement, session));
                displacement += 170;
            }
            return controls.ToArray();
        }


        private Control[] GetChildrenControls(int paxNumber)
        {
            List<Control> controls = new List<Control>();
            int displacement = 0;
            int amountToDisplay = 30;
            for (int paxIndex = 0; paxIndex < paxNumber; paxIndex++)
            {

                controls.Add(this.CreateDynamicRowControlsForChildrenPax(paxIndex, displacement));
                displacement += amountToDisplay;
            }
            return controls.ToArray();
        }
        private Control[] GetSeniorsControls(int paxNumber)
        {
            List<Control> controls = new List<Control>();
            int displacement = 0;
            int amountToDisplay = 30;
            for (int paxIndex = 0; paxIndex < paxNumber; paxIndex++)
            {

                controls.Add(this.CreateDynamicRowControlsForSeniorsPax(paxIndex, displacement));
                displacement += amountToDisplay;
            }
            return controls.ToArray();
        }
        private Control[] GetSpecialService(int paxNumber)
        {
            List<Control> controls = new List<Control>();
            int displacement = 0;
            for (int paxIndex = 0; paxIndex < paxNumber; paxIndex++)
            {

                controls.Add(this.CreateDynamicRowForSpecialService(paxIndex, displacement));
                displacement += 30;
            }
            return controls.ToArray();
        }
        private ArrayList GetTitles()
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add("");
            arrayList.Add("Sr.");
            arrayList.Add("Sra.");
            arrayList.Add("Srita.");
            return arrayList;
        }
        private ArrayList GetSuffix()
        {
            ArrayList arrayListSuffix = new ArrayList();
            arrayListSuffix.Add("");
            arrayListSuffix.Add("JR");
            return arrayListSuffix;
        }
        #endregion

        #region Generates Dynamic Controls

        public void CreateInfantsControls(Panel panelToDraw, int numberOfInfants, Hashtable sessionInProgress)
        {
            panelToDraw.Controls.AddRange(this.GetInfantsControls(numberOfInfants, sessionInProgress));

        }


        public void CreateSpecialServiceControl(Panel panelToDraw, int numbersOfPassanger)
        {

            GroupBox group = this.GetGroupBoxContainer(panelToDraw, "groupBox1");
            group.Controls.AddRange(this.GetSpecialService(numbersOfPassanger));
            panelToDraw.Controls.Add(group);

        }

        public void CreateAdultControls(Panel panelToDraw, int numberOfAdults)
        {
            GroupBox group = this.GetGroupBoxContainer(panelToDraw, "groupBox2");
            group.Controls.AddRange(this.GetAdultsContols(numberOfAdults));
            panelToDraw.Controls.Add(group);
        }

        public void CreateChildrenControls(Panel panelToDraw, int numberOfChildren)
        {
            GroupBox group = this.GetGroupBoxContainer(panelToDraw, "childrenGroupBox");
            group.Controls.AddRange(this.GetChildrenControls(numberOfChildren));
            panelToDraw.Controls.Add(group);
        }



        public void CreateSeniorControls(Panel panelToDraw, int numberOfSeniors)
        {
            GroupBox group = this.GetGroupBoxContainer(panelToDraw, "seniorsGroupBox");
            group.Controls.AddRange(this.GetSeniorsControls(numberOfSeniors));
            panelToDraw.Controls.Add(group);
        }

        private GroupBox GetGroupBoxContainer(Panel panel, string name)
        {
            GroupBox group = (GroupBox)panel.Controls.Find(name, true).FirstOrDefault();
            return group;
        }

        //private Control[] GetPassangerControls(string paxType, int numberOfPax)
        //{
        //    if (this.DispatchControl.ContainsKey(paxType))
        //    {
        //        return this.DispatchControl[paxType](numberOfPax);
        //    }
        //    return null;
        //}

        private GroupBox CreateGroupBox(string name, Point point, Size size)
        {
            GroupBox groupBox = new GroupBox();
            groupBox.Name = name;
            groupBox.Location = point;
            groupBox.Size = size;
            return groupBox;

        }

        public InterJetPassangerCaptureFormHandler InterJetPassangerCaptureFormHandler
        {
            get;
            set;
        }

     
        private ComboBox CreateComboBox(string name, Point point, Size size)
        {
            ComboBox combo = new ComboBox();
            combo.Name = name;
            combo.Location = point;
            combo.Size = size;
            return combo;
        }
        private TextBox CreateTextBox(string name, Point point, Size size)
        {
            TextBox textBox = new TextBox();
            textBox.Name = name;
            textBox.Size = size;
            textBox.Location = point;
            return textBox;
        }

        private Panel CreatePanel(string name, Point point, Size size)
        {
            Panel panel = new Panel();
            panel.Name = name;
            panel.Location = point;
            panel.Size = size;
            panel.Visible = true;
            return panel;
        }

        private CheckBox CreateCheckBox(string name, Point point, Size size)
        {
            CheckBox checkBox = new CheckBox();
            checkBox.Name = name;
            checkBox.Location = point;
            checkBox.Size = size;
            checkBox.UseVisualStyleBackColor = true;
            return checkBox;
        }
        private Label CreateLabel(string name, Point point, Size size)
        {
            Label label = new Label();
            label.Name = name;
            label.Location = point;
            label.Size = size;
            return label;
        }

        private string[] GetYears()
        {
            List<string> years = new List<string>();
            for (int year = 1900; year < 2015; year++)
            {
                years.Add(year.ToString());
            }
            return years.OrderByDescending(e => e).ToArray();
        }

        private string[] GetDays()
        {
            List<string> days = new List<string>();
            for (int day = 1; day < 32; day++)
            {
                days.Add(day.ToString());
            }

            return days.ToArray();
        }




        private Panel CreateDynamicControlsForInfants(int infantNumber, int displacement, Hashtable sessionInProgress)
        {

            Panel panelForInfants = this.CreatePanel(string.Format("Infant{0}", infantNumber),
                new Point(InterJetControlFactory.X_BASECOORD_PANEL_INFANTS, InterJetControlFactory.Y_BASECOORD_PANEL_INFANTS + displacement),
                new Size(InterJetControlFactory.X_HEIGHT_PANEL_INFANTS, InterJetControlFactory.Y_WIDHT_PANEL_INFANTS)
                );

            GroupBox groupBoxInfant = this.CreateGroupBox(string.Format("InfantGroup{0}", infantNumber),
                new Point(InterJetControlFactory.X_BASECOORD_INFANTS_GROUPBOX, InterJetControlFactory.Y_BASECOORD_INFANTS_GROUPBOX),
                new Size(InterJetControlFactory.X_HEIGHT_INFANTS_GROUPBOX, InterJetControlFactory.Y_WIDHT_INFANTS_GROUPBOX)
                );

            groupBoxInfant.Text = string.Format("Infante {0}", infantNumber);

            Label genderLabel = this.CreateLabel(string.Format("genderLabel{0}", infantNumber),
                new Point(InterJetControlFactory.X_BASECOORD_INFANT_GENDER_LABEL, InterJetControlFactory.Y_BASECOORD_INFANT_GENDER_LABEL),
                new Size(InterJetControlFactory.X_HEIGHT_INFANT_GENDER_LABEL, InterJetControlFactory.Y_WIDHT_INFANT_GENDER_LABEL)
                );
            genderLabel.Text = "Sexo:";

            ComboBox genderComboBox = this.CreateComboBox(string.Format("Gender{0}", infantNumber),
                new Point(InterJetControlFactory.X_BASECOORD_INFANT_GENDER_COMBOBOX, InterJetControlFactory.Y_BASECOORD_INFANT_GENDER_COMBOBOX),
                new Size(InterJetControlFactory.X_HEIGHT_INFANT_GENDER_COMBOBOX, InterJetControlFactory.Y_WIDHT_INFANT_GENDER_COMBOBOX)
                );

            genderComboBox.DataSource = new string[] { "Hombre", "Mujer" };

            groupBoxInfant.Controls.Add(genderLabel);
            groupBoxInfant.Controls.Add(genderComboBox);

            Label dateOfBirthLabel = this.CreateLabel(string.Format("dateofBirthLabel{0}", infantNumber),
                 new Point(InterJetControlFactory.X_BASECOORD_INFANT_DATOFBIRTH_LABEL, InterJetControlFactory.Y_BASECOORD_INFANT_DATOFBIRTH_LABEL),
                 new Size(InterJetControlFactory.X_HEIGHT_INFANT_DATOFBIRTH_LABEL, InterJetControlFactory.Y_WIDHT_INFANT_DATOFBIRTH_LABEL)
                 );

            dateOfBirthLabel.Text = @"Fecha de Nacimiento(max 24 meses al momento de viajar):";

            ComboBox daysComboBox = this.CreateComboBox(string.Format("dayOfBirth{0}", infantNumber),
                new Point(InterJetControlFactory.X_BASECOORD_INFANT_DAY_COMBOBOX, InterJetControlFactory.Y_BASECOORD_INFANT_DAY_COMBOBOX),
                new Size(InterJetControlFactory.X_HEIGHT_INFANT_DAY_COMBOBOX, InterJetControlFactory.Y_WIDHT_INFANT_DAY_COMBOBOX)
                );
            daysComboBox.DataSource = this.GetDays();
            ComboBox monthComboBox = this.CreateComboBox(string.Format("monthOfBirth{0}", infantNumber),
                new Point(InterJetControlFactory.X_BASECOORD_INFANT_MONTH_COMBOBOX, InterJetControlFactory.Y_BASECOORD_INFANT_MONTH_COMBOBOX),
                new Size(InterJetControlFactory.X_HEIGHT_INFANT_MONTH_COMBOBOX, InterJetControlFactory.Y_WIDHT_INFANT_MONTH_COMBOBOX)
                );

            monthComboBox.DataSource = new string[] { "ENE", "FEB", "MAR", "ABR", "MAY", "JUN", "JUL", "AGO", "SEP", "OCT", "NOV", "DIC" };

            ComboBox yearComboBox = this.CreateComboBox(string.Format("yearOfBirth{0}", infantNumber),
                new Point(InterJetControlFactory.X_BASECOORD_INFANT_YEAR_COMBOBOX, InterJetControlFactory.Y_BASECOORD_INFANT_YEAR_COMBOBOX),
                new Size(InterJetControlFactory.X_HEIGHT_INFANT_YEAR_COMBOBOX, InterJetControlFactory.Y_WIDHT_INFANT_YEAR_COMBOBOX)
                );
            yearComboBox.DataSource = this.GetYears();

            groupBoxInfant.Controls.Add(dateOfBirthLabel);
            groupBoxInfant.Controls.Add(daysComboBox);
            groupBoxInfant.Controls.Add(monthComboBox);
            groupBoxInfant.Controls.Add(yearComboBox);

            Label countryLabel = this.CreateLabel(string.Format("countryLabel{0}", infantNumber),
                 new Point(InterJetControlFactory.X_BASECOORD_INFANT_COUNTRY_LABEL, InterJetControlFactory.Y_BASECOORD_INFANT_COUNTRY_LABEL),
                 new Size(InterJetControlFactory.X_HEIGHT_INFANT_COUNTRY_LABEL, InterJetControlFactory.Y_WIDHT_INFANT_COUNTRY_LABEL)
                 );

            countryLabel.Text = "País:";
            ComboBox countryComboBox = this.CreateComboBox(string.Format("Country{0}", infantNumber),
                new Point(InterJetControlFactory.X_BASECOORD_INFANT_COUNTRY_COMBOBOX, InterJetControlFactory.Y_BASECOORD_INFANT_COUNTRY_COMBOBOX),
                new Size(InterJetControlFactory.X_HEIGHT_INFANT_COUNTRY_COMBOBOX, InterJetControlFactory.Y_WIDHT_INFANT_COUNTRY_COMBOBOX)
                );

            countryComboBox.DataSource = this.GetCountrys();
            countryComboBox.DisplayMember = "Text";
            countryComboBox.ValueMember = "Value";

            groupBoxInfant.Controls.Add(countryLabel);
            groupBoxInfant.Controls.Add(countryComboBox);

            Label nacionalityLabel = this.CreateLabel(string.Format("nacionalityLabel{0}", infantNumber),
                 new Point(InterJetControlFactory.X_BASECOORD_INFANT_NACIONALITY_LABEL, InterJetControlFactory.Y_BASECOORD_INFANT_NACIONALITY_LABEL),
                 new Size(InterJetControlFactory.X_HEIGHT_INFANT_NACIONALITY_LABEL, InterJetControlFactory.Y_WIDHT_INFANT_NACIONALITY_LABEL)
                 );

            nacionalityLabel.Text = "Nacionalidad:";
            ComboBox nacionalityComboBox = this.CreateComboBox(string.Format("Nacionality{0}", infantNumber),
                new Point(InterJetControlFactory.X_BASECOORD_INFANT_NACIONALITY_COMBOBOX, InterJetControlFactory.Y_BASECOORD_INFANT_NACIONALITY_COMBOBOX),
                new Size(InterJetControlFactory.X_HEIGHT_INFANT_NACIONALITY_COMBOBOX, InterJetControlFactory.Y_WIDHT_INFANT_NACIONALITY_COMBOBOX)
                );

            nacionalityComboBox.DataSource = this.GetCountrys();
            nacionalityComboBox.DisplayMember = "Text";
            nacionalityComboBox.ValueMember = "Value";

            groupBoxInfant.Controls.Add(nacionalityLabel);
            groupBoxInfant.Controls.Add(nacionalityComboBox);

            Label lastNameLabel = this.CreateLabel(string.Format("lastNameLabel{0}", infantNumber),
                 new Point(InterJetControlFactory.X_BASECOORD_INFANT_LASTNAME_LABEL, InterJetControlFactory.Y_BASECOORD_INFANT_LASTNAME_LABEL),
                 new Size(InterJetControlFactory.X_HEIGHT_INFANT_LASTNAME_LABEL, InterJetControlFactory.Y_WIDHT_INFANT_LASTNAME_LABEL)
                 );
            lastNameLabel.Text = "Apellido:";
            TextBox lastNameTextBox = this.CreateTextBox(string.Format("LastName{0}", infantNumber),
                new Point(InterJetControlFactory.X_BASECOORD_INFANT_LASTNAME_TEXTBOX, InterJetControlFactory.Y_BASECOORD_INFANT_LASTNAME_TEXTBOX),
                new Size(InterJetControlFactory.X_HEIGHT_INFANT_LASTNAME_TEXTBOX, InterJetControlFactory.Y_WIDHT_INFANT_LASTNAME_TEXTBOX)
                );
            groupBoxInfant.Controls.Add(lastNameLabel);
            groupBoxInfant.Controls.Add(lastNameTextBox);

            Label nameLabel = this.CreateLabel(string.Format("NameLabel{0}", infantNumber),
                 new Point(InterJetControlFactory.X_BASECOORD_INFANT_NAME_LABEL, InterJetControlFactory.Y_BASECOORD_INFANT_NAME_LABEL),
                 new Size(InterJetControlFactory.X_HEIGHT_INFANT_NAME_LABEL, InterJetControlFactory.Y_WIDHT_INFANT_NAME_LABEL)
                 );
            nameLabel.Text = "Nombre:";
            TextBox nameTextBox = this.CreateTextBox(string.Format("Name{0}", infantNumber),
                new Point(InterJetControlFactory.X_BASECOORD_INFANT_NAME_TEXTBOX, InterJetControlFactory.Y_BASECOORD_INFANT_NAME_TEXTBOX),
                new Size(InterJetControlFactory.X_HEIGHT_INFANT_NAME_TEXTBOX, InterJetControlFactory.Y_WIDHT_INFANT_NAME_TEXTBOX)
                );
            groupBoxInfant.Controls.Add(nameLabel);
            groupBoxInfant.Controls.Add(nameTextBox);

            Label titleLabel = this.CreateLabel(string.Format("titleLabel{0}", infantNumber),
             new Point(InterJetControlFactory.X_BASECOORD_INFANT_TITLE_LABEL, InterJetControlFactory.Y_BASECOORD_INFANT_TITLE_LABEL),
             new Size(InterJetControlFactory.X_HEIGHT_INFANT_TITLE_LABEL, InterJetControlFactory.Y_WIDHT_INFANT_TITLE_LABEL)
             );
            titleLabel.Text = "Titulo:";
            ComboBox titleComboBox = this.CreateComboBox(string.Format("Title{0}", infantNumber),
                new Point(InterJetControlFactory.X_BASECOORD_INFANT_TITLE_COMBOBOX, InterJetControlFactory.Y_BASECOORD_INFANT_TITLE_COMBOBOX),
                new Size(InterJetControlFactory.X_HEIGHT_INFANT_TITLE_COMBOBOX, InterJetControlFactory.Y_WIDHT_INFANT_TITLE_COMBOBOX)
                );
            titleComboBox.DataSource = new string[] { "Menor" };
            groupBoxInfant.Controls.Add(titleLabel);
            groupBoxInfant.Controls.Add(titleComboBox);

            Label travelWithLabel = this.CreateLabel(string.Format("travelWithLabel{0}", infantNumber),
                 new Point(InterJetControlFactory.X_BASECOORD_INFANT_TRAVELWITH_LABEL, InterJetControlFactory.Y_BASECOORD_INFANT_TRAVELWITH_LABEL),
                 new Size(InterJetControlFactory.X_HEIGHT_INFANT_TRAVELWITH_LABEL, InterJetControlFactory.Y_WIDHT_INFANT_TRAVELWITH_LABEL)
                 );

            travelWithLabel.Text = "Viaja Con:";
            ComboBox travelWithComboBox = this.CreateComboBox(string.Format("PassangerID{0}", infantNumber),
                new Point(InterJetControlFactory.X_BASECOORD_INFANT_TRAVELWITH_COMBOBOX, InterJetControlFactory.Y_BASECOORD_INFANT_TRAVELWITH_COMBOBOX),
                new Size(InterJetControlFactory.X_HEIGHT_INFANT_TRAVELWITH_COMBOBOX, InterJetControlFactory.Y_WIDHT_INFANT_TRAVELWITH_COMBOBOX)
                );

            InterJetPassangers passangers = (InterJetPassangers)sessionInProgress["Passangers"];
            travelWithComboBox.DataSource = passangers.GetAllAdultsPassanger();
            travelWithComboBox.ValueMember = "ID";
            travelWithComboBox.DisplayMember = "NameAndLastName";


            groupBoxInfant.Controls.Add(travelWithLabel);
            groupBoxInfant.Controls.Add(travelWithComboBox);

            panelForInfants.Controls.Add(groupBoxInfant);
            return panelForInfants;

        }

        public void CreateDynamicFlightResumeControls(InterJetTicket ticket, Form form)
        {
            int displacement = 184;
            form.Controls.AddRange(this.GetDynamicFlightResumeControls(ticket, displacement));
        }

        public void CreateDynamicReservationResumeControls(Panel panelToDraw, InterJetTicket ticket)
        {
            panelToDraw.Controls.AddRange(this.GetDynamicReservationResumeControls(ticket));
        }

        private Control[] GetDynamicReservationResumeControls(InterJetTicket ticket)
        {
            List<Control> controls = new List<Control>();

            controls.Add(this.GetPassangerGroupForReservationResume(ticket));
            controls.Add(this.GetSegmentsGroupForSegments(ticket));
            controls.Add(this.GetFareGroupForSegments(ticket));
            return controls.ToArray();
        }

        private Control GetFareGroupForSegments(InterJetTicket ticket)
        {
            //Panel panel = this.CreatePanel("farePanel",
            //    new Point(InterJetControlFactory.X_BASECOORD_FARES_RESERVATIONRESUME_PANEL, InterJetControlFactory.Y_BASECOORD_FARES_RESERVATIONRESUME_PANEL),
            //    new Size(InterJetControlFactory.X_HEIGHT_FARES_RESERVATIONRESUME_PANEL, InterJetControlFactory.Y_WIDHT_FARES_RESERVATIONRESUME_PANEL)
            //     );

            //panel.AccessibleName = "rodrigofare";


            GroupBox fareGroupBox = this.CreateGroupBox("fareGroupBox",
            new Point(InterJetControlFactory.X_BASECOORD_FARES_RESERVATIONRESUME_GROUP, InterJetControlFactory.Y_BASECOORD_FARES_RESERVATIONRESUME_GROUP),
            new Size(InterJetControlFactory.X_HEIGHT_FARES_RESERVATIONRESUME_GROUP, InterJetControlFactory.Y_WIDHT_FARES_RESERVATIONRESUME_GROUP)
            );

            fareGroupBox.Text = "Tarifas";
            fareGroupBox.AutoSize = true;

            string fareLabelText = "";
            foreach (InterJetFlight flight in ticket.Flights.GetFlights())
            {
                fareLabelText = string.Concat(fareLabelText,
                                                string.Format(InterJetControlFactory.FARE_CONFIRMATIONLABEL,
                                                flight.DepartureStation,
                                                flight.ArrivalStation,
                                                this.GetTotalBasePriceFromFlight(ticket, flight).ToString("c"),
                                                flight.DepartureStation,
                                                flight.ArrivalStation,
                                                this.GetTotalTUAPriceFromFlight(ticket, flight).ToString("c"),
                                                flight.DepartureStation,
                                                flight.ArrivalStation,
                                                this.GetTotalIVAPriceFromFlight(ticket, flight).ToString("c"),
                                                ticket.BalanceToPay.ToString("c")

                                                ));
            }

            Label fareLabel = this.CreateLabel("fareLabel",
            new Point(InterJetControlFactory.X_BASECOORD_FARES_RESERVATIONRESUME_LABEL, InterJetControlFactory.Y_BASECOORD_FARES_RESERVATIONRESUME_LABEL),
            new Size(InterJetControlFactory.X_HEIGHT_FARES_RESERVATIONRESUME_LABEL, InterJetControlFactory.Y_WIDHT_FARES_RESERVATIONRESUME_LABEL)
            );
            fareLabel.Text = fareLabelText;
            fareLabel.AutoSize = true;
            fareGroupBox.Controls.Add(fareLabel);

            return fareGroupBox;
        }

        private decimal GetTotalBasePriceFromFlight(InterJetTicket ticket, InterJetFlight flight)
        {
            decimal totalBasePrice = 0;
            if (ticket.Passangers.HasAdults)
            {
                totalBasePrice += flight.PriceDetail.Adult.BasePrice * ticket.Passangers.TotalAdults;
            }

            if (ticket.Passangers.HasChildren)
            {
                totalBasePrice += flight.PriceDetail.Child.BasePrice * ticket.Passangers.TotalChildren;
            }
            if (ticket.Passangers.HasSeniorAdult)
            {
                totalBasePrice += flight.PriceDetail.Senior.BasePrice * ticket.Passangers.TotalSenior;
            }

            return totalBasePrice;
        }

        private decimal GetTotalTUAPriceFromFlight(InterJetTicket ticket, InterJetFlight flight)
        {
            decimal totalBasePrice = 0;
            if (ticket.Passangers.HasAdults)
            {
                totalBasePrice += flight.PriceDetail.Adult.TUA * ticket.Passangers.TotalAdults;
            }

            if (ticket.Passangers.HasChildren)
            {
                totalBasePrice += flight.PriceDetail.Child.TUA * ticket.Passangers.TotalChildren;
            }
            if (ticket.Passangers.HasSeniorAdult)
            {
                totalBasePrice += flight.PriceDetail.Senior.TUA * ticket.Passangers.TotalSenior;
            }

            return totalBasePrice;
        }

        private decimal GetTotalIVAPriceFromFlight(InterJetTicket ticket, InterJetFlight flight)
        {
            decimal totalBasePrice = 0;
            if (ticket.Passangers.HasAdults)
            {
                totalBasePrice += flight.PriceDetail.Adult.IVA * ticket.Passangers.TotalAdults;
            }

            if (ticket.Passangers.HasChildren)
            {
                totalBasePrice += flight.PriceDetail.Child.IVA * ticket.Passangers.TotalChildren;
            }
            if (ticket.Passangers.HasSeniorAdult)
            {
                totalBasePrice += flight.PriceDetail.Senior.IVA * ticket.Passangers.TotalSenior;
            }

            return totalBasePrice;
        }
        private Control GetSegmentsGroupForSegments(InterJetTicket ticket)
        {

            //Panel panel = this.CreatePanel("segmentPanel",
            //    new Point(InterJetControlFactory.X_BASECOORD_SEGMENTS_RESERVATIONRESUME_PANEL, InterJetControlFactory.Y_BASECOORD_SEGMENTS_RESERVATIONRESUME_PANEL),
            //    new Size(InterJetControlFactory.X_HEIGHT_SEGMENTS_RESERVATIONRESUME_PANEL, InterJetControlFactory.Y_WIDHT_SEGMENTS_RESERVATIONRESUME_PANEL)
            //     );
            //panel.AccessibleName = "rodrigosegment";
            GroupBox segmentsGroupBox = this.CreateGroupBox("segmentsGroupBox",
                new Point(InterJetControlFactory.X_BASECOORD_SEGMENTS_RESERVATIONRESUME_GROUP, InterJetControlFactory.Y_BASECOORD_SEGMENTS_RESERVATIONRESUME_GROUP),
                new Size(InterJetControlFactory.X_HEIGHT_SEGMENTS_RESERVATIONRESUME_GROUP, InterJetControlFactory.Y_WIDHT_SEGMENTS_RESERVATIONRESUME_GROUP)
                );

            segmentsGroupBox.Text = "Vuelos";
            segmentsGroupBox.AutoSize = true;

            string segmentsLabelText = "";
            foreach (InterJetFlight flight in ticket.Flights.GetFlights())
            {
                segmentsLabelText = string.Concat(segmentsLabelText, string.Format(InterJetControlFactory.SEGMENTS_CONFIRMATIONLABEL,
                                                                                   flight.DepartureStation,
                                                                                   flight.ArrivalStation,
                                                                                   flight.DepartureStation,
                                                                                   flight.ArrivalStation,
                                                                                   flight.FlightNumber,
                                                                                   flight.DepartureTime.ToString("dd/MM/yyyy"),
                                                                                   flight.DepartureTime.ToString("hh:mm"),
                                                                                   flight.ArrivalDateTime.ToString("hh:mm")));
            }

            Label segmentsLabel = this.CreateLabel("segmentLabel",
                new Point(InterJetControlFactory.X_BASECOORD_SEGMENTS_RESERVATIONRESUME_LABEL, InterJetControlFactory.Y_BASECOORD_SEGMENTS_RESERVATIONRESUME_LABEL),
                new Size(InterJetControlFactory.X_HEIGHT_SEGMENTS_RESERVATIONRESUME_LABEL, InterJetControlFactory.Y_WIDHT_SEGMENTS_RESERVATIONRESUME_LABEL)
                );
            segmentsLabel.AutoSize = true;
            segmentsLabel.Text = segmentsLabelText;
            segmentsGroupBox.Controls.Add(segmentsLabel);
            //panel.Controls.Add(segmentsGroupBox);
            //panel.AutoSize = true;
            return segmentsGroupBox;
        }

        private Control GetPassangerGroupForReservationResume(InterJetTicket ticket)
        {
            //Panel panel = this.CreatePanel("paxPanel",
            //    new Point(InterJetControlFactory.X_BASECOORD_PAX_RESERVATIONRESUME_PANEL, InterJetControlFactory.Y_BASECOORD_PAX_RESERVATIONRESUME_PANEL),
            //    new Size(InterJetControlFactory.X_HEIGHT_PAX_RESERVATIONRESUME_PANEL, InterJetControlFactory.Y_WIDHT_PAX_RESERVATIONRESUME_PANEL)
            //    );
            //panel.AccessibleName = "rodrigoPax";

            GroupBox passangerGroupBox = this.CreateGroupBox("PassangerGroupBox",
                new Point(InterJetControlFactory.X_BASECOORD_PAX_RESERVATIONRESUME_GROUP, InterJetControlFactory.Y_BASECOORD_PAX_RESERVATIONRESUME_GROUP),
                new Size(InterJetControlFactory.X_HEIGHT_PAX_RESERVATIONRESUME_GROUP, InterJetControlFactory.Y_WIDHT_PAX_RESERVATIONRESUME_GROUP)
                );

            passangerGroupBox.Text = "Pasajeros";
            passangerGroupBox.AutoSize = true;
            string passangerLabelInfo = "";
            foreach (InterJetPassanger pax in ticket.Passangers.GetAll())
            {
                passangerLabelInfo = string.Concat(passangerLabelInfo, string.Format(InterJetControlFactory.PASSANGER_CONFIRMATIONLABEL, pax.FullName, ticket.RecordLocator));
            }

            Label passangersLabel = this.CreateLabel("paxLabel",
                new Point(InterJetControlFactory.X_BASECOORD_PAX_RESERVATIONRESUME_LABEL, InterJetControlFactory.Y_BASECOORD_PAX_RESERVATIONRESUME_LABEL),
                new Size(InterJetControlFactory.X_HEIGHT_PAX_RESERVATIONRESUME_LABEL, InterJetControlFactory.Y_WIDHT_PAX_RESERVATIONRESUME_LABEL)
                );
            passangersLabel.Text = passangerLabelInfo;
            passangersLabel.AutoSize = true;
            passangerGroupBox.Controls.Add(passangersLabel);
            //panel.Controls.Add(passangerGroupBox);
            //panel.AutoSize = true;
            return passangerGroupBox;
        }

        public Control[] GetDynamicFlightResumeControls(InterJetTicket ticket, int displacement)
        {
            List<Control> controls = new List<Control>();
            int newDisplacement = 0;
            int flightCounter = 1;
            foreach (InterJetDetailPriceMessage detail in ticket.DetailsMessages)
            {
                GroupBox group = this.CreateGroupBox("group",
                    new Point(InterJetControlFactory.X_BASECOORD_GROUPBOX_FLIGHTRESUME, InterJetControlFactory.Y_BASECOORD_GROUPBOX_FLIGHTRESUME + newDisplacement),
                    new Size(InterJetControlFactory.X_HEIGHT_GROUPBOX_FLIGHTRESUME, InterJetControlFactory.Y_WIDHT_GROUPBOX_FLIGHTRESUME));
                group.Text = string.Format("Vuelo {0}: {1}", flightCounter, detail.DateTimeFlightString);
                Panel panel = this.CreatePanel("panel",
                   new Point(InterJetControlFactory.X_BASECOORD_CONTAINER_FLIGHTRESUME, InterJetControlFactory.Y_BASECOORD_CONTAINER_FLIGHTRESUME),
                   new Size(InterJetControlFactory.X_HEIGHT_CONTAINER_FLIGHTRESUME, InterJetControlFactory.Y_WIDHT_CONTAINER_FLIGHTRESUME));

                Label header = this.CreateLabel("label",
                  new Point(InterJetControlFactory.X_BASECOORD_HEADER_FLIGHTRESUME, InterJetControlFactory.Y_BASECOORD_HEADER_FLIGHTRESUME),
                  new Size(InterJetControlFactory.X_HEIGHT_HEADER_FLIGHTRESUME, InterJetControlFactory.Y_WIDHT_HEADER_FLIGHTRESUME));
                header.Text = detail.MessageHeader;
                panel.Controls.Add(header);

                if (!string.IsNullOrEmpty(detail.AdultBodyMessage))
                {
                    Label adultMessage = this.CreateLabel("adult",
                   new Point(InterJetControlFactory.X_BASECOORD_ADULT_FLIGHTRESUME, InterJetControlFactory.Y_BASECOORD_ADULT_FLIGHTRESUME),
                   new Size(InterJetControlFactory.X_HEIGHT_ADULT_FLIGHTRESUME, InterJetControlFactory.Y_WIDHT_ADULT_FLIGHTRESUME));
                    adultMessage.AutoSize = true;
                    adultMessage.TextAlign = ContentAlignment.MiddleCenter;
                    adultMessage.Text = detail.AdultBodyMessage;
                    panel.Controls.Add(adultMessage);
                }

                if (!string.IsNullOrEmpty(detail.SeniorBodyMessage))
                {
                    Label seniorMessage = this.CreateLabel("senior",
                    new Point(InterJetControlFactory.X_BASECOORD_SENIOR_FLIGHTRESUME, InterJetControlFactory.Y_BASECOORD_SENIOR_FLIGHTRESUME),
                    new Size(InterJetControlFactory.X_HEIGHT_SENIOR_FLIGHTRESUME, InterJetControlFactory.Y_WIDHT_SENIOR_FLIGHTRESUME));
                    seniorMessage.Text = detail.SeniorBodyMessage;
                    seniorMessage.TextAlign = ContentAlignment.MiddleCenter;
                    seniorMessage.AutoSize = true;
                    panel.Controls.Add(seniorMessage);
                }

                if (!string.IsNullOrEmpty(detail.ChildBodyMessage))
                {

                    Label childMessage = this.CreateLabel("child",
                    new Point(InterJetControlFactory.X_BASECOORD_CHILD_FLIGHTRESUME, InterJetControlFactory.Y_BASECOORD_CHILD_FLIGHTRESUME),
                    new Size(InterJetControlFactory.X_HEIGHT_CHILD_FLIGHTRESUME, InterJetControlFactory.Y_WIDHT_CHILD_FLIGHTRESUME));
                    childMessage.Text = detail.ChildBodyMessage;
                    childMessage.TextAlign = ContentAlignment.MiddleCenter;
                    childMessage.AutoSize = true;
                    panel.Controls.Add(childMessage);
                }

                Label price = this.CreateLabel("price",
                new Point(InterJetControlFactory.X_BASECOORD_PRICE_FLIGHTRESUME, InterJetControlFactory.Y_BASECOORD_PRICE_FLIGHTRESUME),
                new Size(InterJetControlFactory.X_HEIGHT_PRICE_FLIGHTRESUME, InterJetControlFactory.Y_WIDHT_PRICE_FLIGHTRESUME));
                price.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                price.Text = string.Format("Precio Total : {0}", detail.TotalPrice);
                panel.Controls.Add(price);
                group.Controls.Add(panel);
                controls.Add(group);
                newDisplacement += displacement;
                flightCounter += 1;
            }
            return controls.ToArray();

        }

        private ArrayList GetCountrys()
        {
            ArrayList listOfCountrys = new ArrayList();

            listOfCountrys.Add(new { Text = "Colombia", Value = "CO" });
            listOfCountrys.Add(new { Text = "Cuba", Value = "CU" });
            listOfCountrys.Add(new { Text = "USA", Value = "US" });
            listOfCountrys.Add(new { Text = "México", Value = "MX" });
            return listOfCountrys;
        }


        private Panel CreateDynamicRowForSpecialService(int passangerNumber, int displacement)
        {

            Panel panel = this.CreatePanel(string.Format("Pax{0}", passangerNumber),
                new Point(InterJetControlFactory.X_BASECOORD_PANEL_SPECIAL_SERVICE, InterJetControlFactory.Y_BASECOORD_PANEL_SPECIAL_SERVICE + displacement),
                new Size(InterJetControlFactory.X_HEIGHT_PANEL_SPECIAL_SERVICE, InterJetControlFactory.Y_WIDHT_PANEL_SPECIAL_SERVICE + displacement)
                );

            CheckBox selectedServiceCheckBox = this.CreateCheckBox(string.Format("serviceIsNecesary{0}", passangerNumber),
               new Point(InterJetControlFactory.X_BASECOORD_CHECKBOXSPECIALSERVICE, InterJetControlFactory.Y_BASECOORD_CHECKBOXSPECIALSERVICE + displacement),
               new Size(InterJetControlFactory.X_HEIGHT_CHECKBOXSPECIALSERVICE, InterJetControlFactory.Y_WIDHT_CHECKBOXSPECIALSERVICE)
               );
            panel.Controls.Add(selectedServiceCheckBox);

            ComboBox comboBoxTypeOfService = this.CreateComboBox(string.Format("interjetTitleo{0}", passangerNumber),
                new Point(InterJetControlFactory.X_BASECOORD_COMBOBOX_TYPEOFSERVICE, InterJetControlFactory.Y_BASECOORD_COMBOBOX_TYPEOFSERVICE + displacement),
                new Size(InterJetControlFactory.X_HEIGHT_COMBOBOX_TYPEOFSERVICE, InterJetControlFactory.Y_WIDHT_COMBOBOX_TYPEOFSERVICE + displacement)
              );

            comboBoxTypeOfService.DataSource = new string[] { "Infante", "Menor Sin Acompañar", "Silla de Ruedas" };
            panel.Controls.Add(comboBoxTypeOfService);

            ComboBox comboBoxNumberOfService = this.CreateComboBox(string.Format("interjetTitle1{0}", passangerNumber),
                  new Point(InterJetControlFactory.X_BASECOORD_COMBOBOX_NUMBEROFSERVICES, InterJetControlFactory.Y_BASECOORD_COMBOBOX_NUMBEROFSERVICES + displacement),
                  new Size(InterJetControlFactory.X_HEIGHT_COMBOBOX_NUMBEROFSERVICES, InterJetControlFactory.Y_WIDHT_COMBOBOX_NUMBEROFSERVICES + displacement)
                );

            comboBoxNumberOfService.DataSource = new string[] { "0", "1" };
            panel.Controls.Add(comboBoxNumberOfService);

            ComboBox selectedFlightsComboBox = this.CreateComboBox(string.Format("interjetTitle11{0}", passangerNumber),
                  new Point(InterJetControlFactory.X_BASECOORD_COMBOBOX_FLIGTH, InterJetControlFactory.Y_BASECOORD_COMBOBOX_FLIGTH + displacement),
                  new Size(InterJetControlFactory.X_HEIGHT_COMBOBOX_FLIGTH, InterJetControlFactory.Y_WIDHT_COMBOBOX_FLIGTH + displacement)
                );

            //if (InterJetSession.Session["SelectedFlights"] != null)
            //{
            //    // si existe bajar los vuelos previamente seleccionados 
            //    InterJetSelectedFlights selectedFlights = (InterJetSelectedFlights)InterJetSession.Session["SelectedFlights"];
            //    //selectedFlightsComboBox.DisplayMember = "IntineraryString";
            //    selectedFlightsComboBox.DataSource = (from flight in selectedFlights.GetFlights()
            //                                          select
            //                                          flight.IntineraryString

            //                                         ).ToArray();


            //}

            panel.Controls.Add(selectedFlightsComboBox);

            Label NoteLabel = this.CreateLabel(string.Format("interjetTitle3{0}", passangerNumber),
              new Point(InterJetControlFactory.X_BASECOORD_NOTELABEL, InterJetControlFactory.Y_BASECOORD_NOTELABEL + displacement),
              new Size(InterJetControlFactory.X_HEIGHT_NOTELABEL, InterJetControlFactory.Y_WIDHT_NOTELABEL + displacement)
            );
            NoteLabel.Text = "Nota:";
            panel.Controls.Add(NoteLabel);

            TextBox noteTextBox = this.CreateTextBox(string.Format("interjetClub2{0}", passangerNumber),
             new Point(InterJetControlFactory.X_BASECOORD_NOTETEXTBOX, InterJetControlFactory.Y_BASECOORD_NOTETEXTBOX + displacement),
             new Size(InterJetControlFactory.X_HEIGHT_NOTETEXTBOX, InterJetControlFactory.Y_WIDHT_NOTETEXTBOX + displacement)
             );
            panel.Controls.Add(noteTextBox);

            return panel;

        }



        private Panel CreateDynamicRowControlsForAdultsPax(int passangerNumber, int displacement)
        {
            Panel panel = this.CreatePanel(string.Format("Pax{0}", passangerNumber),
                new Point(InterJetControlFactory.X_BASECOORD_PANEL_ADULT, InterJetControlFactory.Y_BASECOORD_PANEL_ADULT + displacement),
                new Size(InterJetControlFactory.X_HEIGHT_PANEL_ADULT, InterJetControlFactory.Y_WIDHT_PANEL_ADULT)
                );

            TextBox textBoxInterJetClub = this.CreateTextBox(string.Format("interjetClub{0}", passangerNumber),
                new Point(InterJetControlFactory.X_BASECOORD_CLUBINTERJET_ADULT, InterJetControlFactory.Y_BASECOORD_CLUBINTERJET_ADULT),
                new Size(InterJetControlFactory.X_WIDHT_CLUBINTERJET_ADULT, InterJetControlFactory.Y_HEIGHT_CLUBINTERJET_ADULT)
                );

            panel.Controls.Add(textBoxInterJetClub);

            ComboBox comboBoxTitle = this.CreateComboBox(string.Format("interjetTitle{0}", passangerNumber),
                new Point(InterJetControlFactory.X_BASECOORD_TITLE_ADULT, InterJetControlFactory.Y_BASECOORD_TITLE_ADULT),
                new Size(InterJetControlFactory.X_WIDHT_TITLE_ADULT, InterJetControlFactory.Y_BASECOORD_TITLE_ADULT)
                );
            comboBoxTitle.DataSource = this.GetTitles();

            panel.Controls.Add(comboBoxTitle);

            TextBox textBoxPaxName = this.CreateTextBox(string.Format("interjetName{0}", passangerNumber),
               new Point(InterJetControlFactory.X_BASECOORD_NAME_ADULT, InterJetControlFactory.Y_BASECOORD_NAME_ADULT),
               new Size(InterJetControlFactory.X_WIDHT_NAME_ADULT, InterJetControlFactory.Y_HEIGHT_NAME_ADULT)
               );

            panel.Controls.Add(textBoxPaxName);

            TextBox textBoxPaxLastName = this.CreateTextBox(string.Format("interjetLastName{0}", passangerNumber),
               new Point(InterJetControlFactory.X_BASECOORD_LASTNAME_ADULT, InterJetControlFactory.Y_BASECOORD_LASTNAME_ADULT),
               new Size(InterJetControlFactory.X_WIDHT_LASTNAME_ADULT, InterJetControlFactory.Y_HEIGHT_LASTNAME_ADULT)
              );

            panel.Controls.Add(textBoxPaxLastName);

            ComboBox comboBoxSuffix = this.CreateComboBox(string.Format("interjetPaxSuffix{0}", passangerNumber),
           new Point(InterJetControlFactory.X_BASECOORD_SUFFIX_ADULT, InterJetControlFactory.Y_BASECOORD_SUFFIX_ADULT),
           new Size(InterJetControlFactory.X_WIDHT_SUFFIX_ADULT, InterJetControlFactory.Y_HEIGHT_SUFFIX_ADULT)
           );
            comboBoxSuffix.DataSource = this.GetSuffix();
            panel.Controls.Add(comboBoxSuffix);


            CheckBox checkBox = this.CreateCheckBox(string.Format("interjetIsContact{0}", passangerNumber),
           new Point(InterJetControlFactory.X_BASECOORD_ADULT_ISCONTACT, InterJetControlFactory.Y_BASECOORD_ADULT_ISCONTACT),
           new Size(InterJetControlFactory.X_WIDHT_ADULT_ISCONTACT, InterJetControlFactory.Y_HEIGHT_ADULT_ISCONTACT)
           );

            checkBox.CheckedChanged += new EventHandler(InterJetPassangerCaptureFormHandler.OnContactChecked);
            panel.Controls.Add(checkBox);

            return panel;
        }



        private Panel CreateDynamicRowControlsForChildrenPax(int passangerNumber, int displacement)
        {
            Panel panel = this.CreatePanel(string.Format("Pax{0}", passangerNumber),
                new Point(InterJetControlFactory.X_BASECOORD_PANEL_CHILD, InterJetControlFactory.Y_BASECOORD_PANEL_CHILD + displacement),
                new Size(InterJetControlFactory.X_HEIGHT_PANEL_CHILD, InterJetControlFactory.Y_WIDHT_PANEL_CHILD)
                );

            TextBox textBoxInterJetClub = this.CreateTextBox(string.Format("interjetClub{0}", passangerNumber),
                new Point(InterJetControlFactory.X_BASECOORD_CLUBINTERJET_CHILD, InterJetControlFactory.Y_BASECOORD_CLUBINTERJET_CHILD),
                new Size(InterJetControlFactory.X_WIDHT_CLUBINTERJET_CHILD, InterJetControlFactory.Y_HEIGHT_CLUBINTERJET_CHILD)
                );

            panel.Controls.Add(textBoxInterJetClub);

            ComboBox comboBoxTitle = this.CreateComboBox(string.Format("interjetTitle{0}", passangerNumber),
                new Point(InterJetControlFactory.X_BASECOORD_TITLE_CHILD, InterJetControlFactory.Y_BASECOORD_TITLE_CHILD),
                new Size(InterJetControlFactory.X_WIDHT_TITLE_CHILD, InterJetControlFactory.Y_BASECOORD_TITLE_CHILD)
                );

            comboBoxTitle.DataSource = this.GetTitles();

            panel.Controls.Add(comboBoxTitle);

            TextBox textBoxPaxName = this.CreateTextBox(string.Format("interjetName{0}", passangerNumber),
               new Point(InterJetControlFactory.X_BASECOORD_NAME_CHILD, InterJetControlFactory.Y_BASECOORD_NAME_CHILD),
               new Size(InterJetControlFactory.X_WIDHT_NAME_CHILD, InterJetControlFactory.Y_HEIGHT_NAME_CHILD)
               );

            panel.Controls.Add(textBoxPaxName);

            TextBox textBoxPaxLastName = this.CreateTextBox(string.Format("interjetLastName{0}", passangerNumber),
               new Point(InterJetControlFactory.X_BASECOORD_LASTNAME_CHILD, InterJetControlFactory.Y_BASECOORD_LASTNAME_CHILD),
               new Size(InterJetControlFactory.X_WIDHT_LASTNAME_CHILD, InterJetControlFactory.Y_HEIGHT_LASTNAME_CHILD)
              );

            panel.Controls.Add(textBoxPaxLastName);

            ComboBox comboBoxSuffix = this.CreateComboBox(string.Format("interjetPaxSuffix{0}", passangerNumber),
           new Point(InterJetControlFactory.X_BASECOORD_SUFFIX_CHILD, InterJetControlFactory.Y_BASECOORD_SUFFIX_CHILD),
           new Size(InterJetControlFactory.X_WIDHT_SUFFIX_CHILD, InterJetControlFactory.Y_HEIGHT_SUFFIX_CHILD)
           );
            comboBoxSuffix.DataSource = this.GetSuffix();
            panel.Controls.Add(comboBoxSuffix);

            CheckBox checkBox = this.CreateCheckBox(string.Format("interjetIsContact{0}", passangerNumber),
           new Point(InterJetControlFactory.X_BASECOORD_CHILD_ISCONTACT, InterJetControlFactory.Y_BASECOORD_CHILD_ISCONTACT),
           new Size(InterJetControlFactory.X_WIDHT_CHILD_ISCONTACT, InterJetControlFactory.Y_HEIGHT_CHILD_ISCONTACT)
           );
            panel.Controls.Add(checkBox);

            return panel;
        }

        private Panel CreateDynamicRowControlsForSeniorsPax(int passangerNumber, int displacement)
        {


            Panel panel = this.CreatePanel(string.Format("Pax{0}", passangerNumber),
                new Point(InterJetControlFactory.X_BASECOORD_PANEL_SENIOR, InterJetControlFactory.Y_BASECOORD_PANEL_SENIOR + displacement),
                new Size(InterJetControlFactory.X_HEIGHT_PANEL_SENIOR, InterJetControlFactory.Y_WIDHT_PANEL_SENIOR)
                );

            TextBox textBoxInterJetClub = this.CreateTextBox(string.Format("interjetClub{0}", passangerNumber),
                new Point(InterJetControlFactory.X_BASECOORD_CLUBINTERJET_SENIOR, InterJetControlFactory.Y_BASECOORD_CLUBINTERJET_SENIOR),
                new Size(InterJetControlFactory.X_WIDHT_CLUBINTERJET_SENIOR, InterJetControlFactory.Y_HEIGHT_CLUBINTERJET_SENIOR)
                );

            panel.Controls.Add(textBoxInterJetClub);

            ComboBox comboBoxTitle = this.CreateComboBox(string.Format("interjetTitle{0}", passangerNumber),
                new Point(InterJetControlFactory.X_BASECOORD_TITLE_SENIOR, InterJetControlFactory.Y_BASECOORD_TITLE_SENIOR),
                new Size(InterJetControlFactory.X_WIDHT_TITLE_SENIOR, InterJetControlFactory.Y_BASECOORD_TITLE_SENIOR)
                );
            comboBoxTitle.DataSource = this.GetTitles();

            panel.Controls.Add(comboBoxTitle);

            TextBox textBoxPaxName = this.CreateTextBox(string.Format("interjetName{0}", passangerNumber),
               new Point(InterJetControlFactory.X_BASECOORD_NAME_SENIOR, InterJetControlFactory.Y_BASECOORD_NAME_SENIOR),
               new Size(InterJetControlFactory.X_WIDHT_NAME_SENIOR, InterJetControlFactory.Y_HEIGHT_NAME_SENIOR)
               );

            panel.Controls.Add(textBoxPaxName);

            TextBox textBoxPaxLastName = this.CreateTextBox(string.Format("interjetLastName{0}", passangerNumber),
               new Point(InterJetControlFactory.X_BASECOORD_LASTNAME_SENIOR, InterJetControlFactory.Y_BASECOORD_LASTNAME_SENIOR),
               new Size(InterJetControlFactory.X_WIDHT_LASTNAME_SENIOR, InterJetControlFactory.Y_HEIGHT_LASTNAME_SENIOR)
              );

            panel.Controls.Add(textBoxPaxLastName);

            ComboBox comboBoxSuffix = this.CreateComboBox(string.Format("interjetPaxSuffix{0}", passangerNumber),
           new Point(InterJetControlFactory.X_BASECOORD_SUFFIX_SENIOR, InterJetControlFactory.Y_BASECOORD_SUFFIX_SENIOR),
           new Size(InterJetControlFactory.X_WIDHT_SUFFIX_SENIOR, InterJetControlFactory.Y_HEIGHT_SUFFIX_CHILD)
           );
            comboBoxSuffix.DataSource = this.GetSuffix();

            panel.Controls.Add(comboBoxSuffix);

            CheckBox checkBox = this.CreateCheckBox(string.Format("interjetIsContact{0}", passangerNumber),
           new Point(InterJetControlFactory.X_BASECOORD_SENIOR_ISCONTACT, InterJetControlFactory.Y_BASECOORD_SENIOR_ISCONTACT),
           new Size(InterJetControlFactory.X_WIDHT_SENIOR_ISCONTACT, InterJetControlFactory.Y_HEIGHT_SENIOR_ISCONTACT)
           );

            checkBox.CheckedChanged += new EventHandler(InterJetPassangerCaptureFormHandler.OnContactChecked);
            panel.Controls.Add(checkBox);

            return panel;
        }




        #endregion

        #region Add PasssangerUserControls


        private static Stack<Control> _currentStack;

        public static Stack<Control> CurrentStack
        {
            get
            {
                return _currentStack ?? (_currentStack = new Stack<Control>());
            }
        }

        /// <summary>
        /// Loads the infant user control.
        /// </summary>
        /// <param name="mainContainer">The main container.</param>
        /// <param name="numberOfInfants">The number of infants.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="handler">The handler.</param>
        public void LoadInfantUserControl(Control mainContainer, int numberOfInfants, object parameter, KeyEventHandler handler)
        {

            var controlsToAdd = new List<Control>();

            for (int infantIndex = 1; infantIndex <= numberOfInfants; infantIndex++)
            {
                Panel panelToAdd = this.CreatePanel(string.Format("Infant{0}", infantIndex),
                    new Point(InterJetControlFactory.X_BASECOORD_PANEL_INFANT, InterJetControlFactory.Y_BASECOORD_PANEL_INFANT),
                    new Size(InterJetControlFactory.X_HEIGHT_PANEL_INFANT, InterJetControlFactory.Y_WIDHT_PANEL_INFANT)
                    );
                panelToAdd.AutoSize = true;

                var newInfantUserControl = new ucInterJetInfantCapture();

                newInfantUserControl.KeyEventHandler = handler;
                newInfantUserControl.Parameter = parameter;
                newInfantUserControl.GroupBoxTitle = string.Format("Infante {0}", infantIndex);
                panelToAdd.Controls.Add(newInfantUserControl);
                controlsToAdd.Add(panelToAdd);
            }
            int controlCounter = 0;
            var controlStack = new Stack<Control>();
            foreach (Control controlToResize in controlsToAdd)
            {
                bool IsNotTheFirstItem = controlCounter != 0;
                if (IsNotTheFirstItem)
                {
                    Control previousControl = controlStack.Pop();
                    Point newLocation = previousControl.Location;
                    int y_Displacement = 270;
                    controlToResize.Location = new Point(newLocation.X, newLocation.Y + y_Displacement);

                }
                controlStack.Push(controlToResize);
                controlCounter += 1;
            }

            Panel panelWithButtons = mainContainer.Controls.Find("panelWithButtons", true).FirstOrDefault() as Panel;

            if (panelWithButtons != null)
            {
                Control previousControl = controlStack.Pop();
                Point newLocation = previousControl.Location;
                int y_Displacement = 255;
                panelWithButtons.Location = new Point(newLocation.X, newLocation.Y + y_Displacement);

            }

            mainContainer.Controls.AddRange(controlsToAdd.ToArray());

        }


        /// <summary>
        /// Loads the passanger user control.
        /// </summary>
        /// <param name="mainContainer">The main container.</param>
        /// <param name="numberOfPax">The number of pax.</param>
        /// <param name="type">The type.</param>
        /// <param name="eventHandler">The event handler.</param>
        public void LoadPassangerUserControl(Control mainContainer, int numberOfPax, InterJetPassangerType type, KeyEventHandler eventHandler)
        {

            var controlsToAdd = new List<Control>();

            for (int paxIndex = 1; paxIndex <= numberOfPax; paxIndex++)
            {

                Panel panelToAdd = this.CreatePanel(string.Format("Pax{0}", paxIndex),
                    new Point(InterJetControlFactory.X_BASECOORD_PANEL_PASSANGER, InterJetControlFactory.Y_BASECOORD_PANEL_PASSANGER),
                    new Size(InterJetControlFactory.X_HEIGHT_PANEL_PASSANGER, InterJetControlFactory.Y_WIDHT_PANEL_PASSANGER)
                    );
                panelToAdd.AutoSize = true;
                var passangerUserControl = new ucInterJetPassangerCapture();

                if (paxIndex == 1)
                {
                    passangerUserControl.Focus();
                }
                passangerUserControl.KeyEventHandler = eventHandler;
                passangerUserControl.PassangerType = type;
                passangerUserControl.PassangerID = paxIndex.ToString();
                passangerUserControl.GroupBoxTitle = string.Format("{0} {1}", this.GetPassangerType(type), paxIndex);
                panelToAdd.Controls.Add(passangerUserControl);
                controlsToAdd.Add(panelToAdd);
            }

            int counter = 0;

            foreach (Control controlToResize in controlsToAdd)
            {

                if (counter != 0 || CurrentStack.Count > 0)
                {

                    Control previousControl = CurrentStack.Pop();
                    Point newLocation = previousControl.Location;
                    int y_Displacement = 180;
                    controlToResize.Location = new Point(newLocation.X, newLocation.Y + y_Displacement);
                }
                CurrentStack.Push(controlToResize);
                counter += 1;

            }
            mainContainer.Controls.AddRange(controlsToAdd.ToArray());
        }

        private string GetPassangerType(InterJetPassangerType type)
        {
            switch (type)
            {
                case InterJetPassangerType.Adult:
                    return "Adulto";
                case InterJetPassangerType.Senior:
                    return "Adulto Mayor";
                case InterJetPassangerType.Child:
                    return "Menor";

            }
            return "";

        }

        #endregion





    }
}


