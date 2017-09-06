namespace MyCTS.Presentation
{
    partial class ucEnableDisable
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.rdoAdd = new System.Windows.Forms.RadioButton();
            this.rdoDelete = new System.Windows.Forms.RadioButton();
            this.cmbKeyWord10 = new System.Windows.Forms.ComboBox();
            this.cmbKeyWord11 = new System.Windows.Forms.ComboBox();
            this.cmbKeyWord9 = new System.Windows.Forms.ComboBox();
            this.cmbKeyWord12 = new System.Windows.Forms.ComboBox();
            this.cmbKeyWord8 = new System.Windows.Forms.ComboBox();
            this.txtAuthorization = new MyCTS.Forms.UI.SmartTextBox();
            this.lblAuthorization = new System.Windows.Forms.Label();
            this.txtNumberFirm = new MyCTS.Forms.UI.SmartTextBox();
            this.lblNumberFirm = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblKeyword = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(-3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(411, 17);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Eliminar/Agregar Keywords";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // rdoAdd
            // 
            this.rdoAdd.AutoSize = true;
            this.rdoAdd.Location = new System.Drawing.Point(19, 36);
            this.rdoAdd.Name = "rdoAdd";
            this.rdoAdd.Size = new System.Drawing.Size(62, 17);
            this.rdoAdd.TabIndex = 1;
            this.rdoAdd.TabStop = true;
            this.rdoAdd.Text = "Agregar";
            this.rdoAdd.UseVisualStyleBackColor = true;
            this.rdoAdd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoDelete
            // 
            this.rdoDelete.AutoSize = true;
            this.rdoDelete.Location = new System.Drawing.Point(101, 36);
            this.rdoDelete.Name = "rdoDelete";
            this.rdoDelete.Size = new System.Drawing.Size(61, 17);
            this.rdoDelete.TabIndex = 2;
            this.rdoDelete.TabStop = true;
            this.rdoDelete.Text = "Eliminar";
            this.rdoDelete.UseVisualStyleBackColor = true;
            this.rdoDelete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // cmbKeyWord10
            // 
            this.cmbKeyWord10.FormattingEnabled = true;
            this.cmbKeyWord10.Items.AddRange(new object[] {
            "",
            "AASATO                  AGENCY ACCESS TO FOCUS MANUALS - F*CDP",
            "ABAEXC                  ABACUS AGENT EXCEPTION",
            "ADSCOM                 CONTROL ADS MACHINE-TO-MACHINE NETWORK COMMUNICATION",
            "AGSTRC                  FORCE ICE DEBUG",
            "ALTDSP                   CONTROL HOTEL SHOPPING LIST DISPLAY",
            "ALUPTE                   ABACUS AND INFINI CONNECTIVITY TAG",
            "APLRST                   APPLICATIONS RESTRICT - EPR RESTRICTED TO APLCTL",
            "ARCRPT                  ALLOW PRINTING OF AGENCY ARC REPORTS",
            "ASK@@@               CONTROL *   ENTRY VIA PAC CODE TABLE ",
            "ATBRPT                   ALLOW DELETE OF TKT AUDIT TRAIL REPORT",
            "AVLSCN                   AA.COM SCAN AVAILABILTY ENTRIES/REQUEST AADVANTAGE CLS",
            "AYMADM                 SPVSR ADMINISTRATOR ROLE FOR ARM-REVENUE ADVANTAGE AGT+",
            "AYMAFM                 ALLOW ACCESS TO WEB GUI TO UPDATE SERVICE FEE RULES",
            "AYMARM                 AGENCY REVENUE MANAGMENT SUPERVISOR",
            "AYMARU                 AGENCY REVENUE MANAGMENT USER",
            "B-MAIL                    ALLOW DISPLAY/USE OF B-MAIL MESSAGE QUEUE",
            "BSRDSP                   PRICING -- BANKERS SELLING RATE DISPLAY",
            "CARCAN                  PROVIDE RATE CANVASSING WITHOUT PROVIDING RATE UPDATE",
            "CATSUP                   SUPPRESS CATEGORIES IN AN ELECTRONIC RULES DISPLAY",
            "CCVIEW                   ALLOW AGENT TO ADD CCVIEW UAT KEYWORD TO AAA&OAM",
            "COMMSG                 ALLOW PAC CODE -MS- ENTRIES FOR AGENCIES/ASSOCIATES",
            "COMSAB                  ALLOW CREATE AND MODIFY COMMERCIAL SABRE PROFILES",
            "CVRSAB                   CONVERSATIONAL SABRE TERMINAL",
            "DOTCOM                 IDENTIFY AIRLINE CONTROLLED PCC",
            "E@@@@@             CONTROL E   ENTRY VIA PAC CODE TABLE",
            "EPRDSP                   ALLOW DISPLAY OF ALL EPRS AND -H*CST- CAPABILITY",
            "ETDNAG                  ELECTRONIC TICKET DELIVERY NETWORK AGENCY AGENT ",
            "ETRMAP                  ALLOW ONLINE CREATION AND ACTIVATION OF ETRMAP FILE",
            "F@@@@@             CONTROL F   ENTRIES VIA PAC CODE TABLE  ",
            "FOXCTL                   ALLOW UPDT/CREATE OF AUTOMATED REFERENCE SYS DATABASE",
            "FS@@@@              CONTROL FS  ENTRY VIA PAC CODE TABLE",
            "GLOBAL                   ALLOW SUBSCRIBERS GLOBAL SPECTRA AND MULTI BR SPECTRA",
            "GLSAGT                   ALLOW GLOBAL SECURITY ENTRIES",
            "GMRUPD                  APPLY RESTRICTIONS TO GMR DISPLAY REQUESTS AND UPDATES",
            "GMSELL                    APPLY RESTRICTIONS TO GMR SELLS",
            "GMTIME                   DISPLAY CURRENT TIME IN GREENWICH MEAN TIME",
            "HDMRCH                 ALLOWED TO PERFORM CK*SMHD ENTRY",
            "HLPDSK                   PROVIDE HELP DESK CAPABILITIES FOR MULTI-HOSTS",
            "HODMIN                  SUPPRESS FREE TXT-HOTEL DIRECT CONNECT AVAIL DISPLAYS",
            "HODRTE                  RESTRICT HOTEL DCS DISPLAYS TO ONLY CRITICAL ELEMENTS",
            "INFEXC                    INFINI AGENT EXCEPTION",
            "INHMSG                   RESTRICT USE OF TELETYPE TRANSFER MESSAGES",
            "INHNMC                   INHIBIT NAME CHANGE ON RETRIEVED PNRS",
            "IPSI01                     IP SIGN IN VERSION ONE",
            "LABELS                    ALLOW PRINTING OF AGENCY MAILING LABELS",
            "LMTACC                  DIRECT ACCESS USERS WITH LIMITED CAPABILITIES",
            "MGUPTE                  CREATE PASSIVE SEG WITH MG/GA TAG",
            "MNTAGT                  ALLOW AGENT TO MONITOR AUTHORIZED SETS",
            "MONEY@                 ALLOW UPDATE OF BANKERS BUYING RATE TABLES",
            "MRCHNT                  RESTRICT MERCHANT FUNCTION TO KEYWORD HOLDERS",
            "N@@@@@             CONTROL N  ENTRY VIA PAC CODE TABLE",
            "MULSET                    ALLOW SIGN-IN FROM ONE EPR INTO MULTIPLE LNIATA/S",
            "NEGAGT                   ALLOW BUILDING OF BRANCH TABLES FOR NEGOTIATED FARES",
            "NETFQD\t                ACCESS TO NET FARES APPLICABLE TO AGENTS LOCATION",
            "NETWEB                  WEB-BASED BROWSER FOR NET FARES MARK UP PROJECT",
            "NO@AAA                 INHIBIT CHANGING AAA TO THE SET/S UAT CITY",
            "NOBCHQ                  INHIBIT ACCESS TO BRANCH OFFICE QUEUES",
            "NOBDPS                   INHIBIT BOARDING PASS PRINTER ASSIGNMENT",
            "NOCTPS                   INHIBIT CORP TVL PLCY SYSTEM/FLEXIBLE PNR EDITS",
            "NODOCS                  INHIBIT ALL BOARDING CONTROL PRINTER ASSIGNMENTS",
            "NOINIS                     INHIBIT INVOICE/ITINERARY PRINTER ASSIGNMENT",
            "NOMSGQ                  INHIBIT BRANCH OFF QUEUES AND MSG QUEUES OF HOME STA",
            "NOPNRS                   INHIBIT PNR UPDATES",
            "NOQUES                   INHIBIT ACCESS TO ALL QUEUES",
            "NOSTAR                   INHIBIT UPDATES TO STARS",
            "NOTKTS                    INHIBIT TICKET PRINTER ASSIGNMENT",
            "NSPLAT                    CONTROL N* ENTRIES VIA PAC TABLE",
            "ONSNAP                   NETEGRITY SECURITY FOR ONSNAP WEB APPLICATION",
            "PTR@@@                CONTROL PTR ENTRIES VIA PAC CODE TABLE",
            "PVTAGT                    ALLOW USE AND DISPLAY OF PRIVATE FARES",
            "PVTDIS                     ALLOW USE AND DISPLAY OF PRIVATE FARES",
            "Q@@@@@             CONTROL Q   ENTRY VIA PAC CODE TABLE",
            "QUESUB                   ALLOWS UPDATES TO PUB-SUB INDICATORS IN QUEUES DATABASE",
            "RECHCK                   PERMIT USE OF NIGHTLY FARE RE-CHECK ",
            "REMOVE                   ALLOW REMOVAL OF INTERFACE MESSAGE FROM THE PQS QUEUE",
            "REQROB                   POSSIBLE ROBOTIC MACHINE ID",
            "RKNAME                   ABACUS SURNAME CHANGE RESTRICTION TABLE",
            "ROBAP1                   GENUINE ROBOTIC MACHINE ID",
            "ROBAP2                   GENUINE ROBOTIC MACHINE ID-2",
            "RTABLE                    AMEX- ALLOW SUBSCRIBERS TO UPD RESTRICTION TABLES",
            "S@@@@@              CONTROL S   ENTRY VIA PAC CODE TABLE",
            "SABEXC                    SABRE AGENT EXCEPTION",
            "SAMRCH                  ALLOWED TO PERFORM CK*SMSA ENTRY",
            "SASELN                    CONTROL SASE LINES FOR COMPLEX PRICING",
            "SI@@@@                CONTROL SI  ENTRY VIA PAC CODE TABLE",
            "SIRMSG                    ALLOW AGENTS TO CREATE SIGN-IN MSGS FOR THEIR OWN CITY",
            "SPRMKT                    \\SUPERMARKET AUTHORIZATION KEYWORD",
            "STCORP                    ALLOW ACCESS TO SATO DATA BASE ",
            "STMOPR                    ALLOW CMS INTERFACE QUEUE ENTRIES",
            "SUBAAA                    ALLOW AAA ENTRY FOR AGENCY - BRA DOCUMENT GENERATION",
            "SUBREJ                     ALLOW SUBSCRIBER AGENT TO SIGN-IN WITH DUTY CODE ZERO",
            "TAVAIL                      ALLOW 20 LINE CITY PAIR AVAILABILITY DISPLAY",
            "TODAGT                    ALLOW AGENT TO ISSUE TICKET ON DEPARTURE PTA",
            "TRPSCH                     PERMIT USE OF FARE TRIP SEARCH",
            "UNISTR                     ALLOW CREATION OF UNIVERSAL STAR RECORDS",
            "W@@@@@             CONTROL W   ENTRY VIA PAC CODE TABLE",
            "WPNALL                    ALLOW WPNI OR WPNC/ALL ENTRIES",
            "WSLASH                   CONTROL W/  ENTRIES VIA PAC CODE TABLE",
            "WWWUSR                SABRE INTERNET PRODUCTS THAT USSE EZGDS TO COMUNICATE",
            "XAGSSX                    AGSS CONTROL KEYWORD",
            "Y@SLH@                  CONTROL Y/  ENTRIES VIA PAC CODE TABLE",
            "1@@@@@              CONTROL 1   ENTRY VIA PAC CODE TABLE",
            "5@@@@@              CONTROL 5   ENTRY VIA PAC CODE TABLE",
            "6@@@@@              CONTROL 6   ENTRY VIA PAC CODE TABLE"});
            this.cmbKeyWord10.Location = new System.Drawing.Point(19, 195);
            this.cmbKeyWord10.Name = "cmbKeyWord10";
            this.cmbKeyWord10.Size = new System.Drawing.Size(371, 21);
            this.cmbKeyWord10.TabIndex = 7;
            this.cmbKeyWord10.SelectedIndexChanged += new System.EventHandler(this.cmbKeyWord10_SelectedIndexChanged);
            this.cmbKeyWord10.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // cmbKeyWord11
            // 
            this.cmbKeyWord11.FormattingEnabled = true;
            this.cmbKeyWord11.Items.AddRange(new object[] {
            "",
            "AASATO                  AGENCY ACCESS TO FOCUS MANUALS - F*CDP",
            "ABAEXC                  ABACUS AGENT EXCEPTION",
            "ADSCOM                 CONTROL ADS MACHINE-TO-MACHINE NETWORK COMMUNICATION",
            "AGSTRC                  FORCE ICE DEBUG",
            "ALTDSP                   CONTROL HOTEL SHOPPING LIST DISPLAY",
            "ALUPTE                   ABACUS AND INFINI CONNECTIVITY TAG",
            "APLRST                   APPLICATIONS RESTRICT - EPR RESTRICTED TO APLCTL",
            "ARCRPT                  ALLOW PRINTING OF AGENCY ARC REPORTS",
            "ASK@@@               CONTROL *   ENTRY VIA PAC CODE TABLE ",
            "ATBRPT                   ALLOW DELETE OF TKT AUDIT TRAIL REPORT",
            "AVLSCN                   AA.COM SCAN AVAILABILTY ENTRIES/REQUEST AADVANTAGE CLS",
            "AYMADM                 SPVSR ADMINISTRATOR ROLE FOR ARM-REVENUE ADVANTAGE AGT+",
            "AYMAFM                 ALLOW ACCESS TO WEB GUI TO UPDATE SERVICE FEE RULES",
            "AYMARM                 AGENCY REVENUE MANAGMENT SUPERVISOR",
            "AYMARU                 AGENCY REVENUE MANAGMENT USER",
            "B-MAIL                    ALLOW DISPLAY/USE OF B-MAIL MESSAGE QUEUE",
            "BSRDSP                   PRICING -- BANKERS SELLING RATE DISPLAY",
            "CARCAN                  PROVIDE RATE CANVASSING WITHOUT PROVIDING RATE UPDATE",
            "CATSUP                   SUPPRESS CATEGORIES IN AN ELECTRONIC RULES DISPLAY",
            "CCVIEW                   ALLOW AGENT TO ADD CCVIEW UAT KEYWORD TO AAA&OAM",
            "COMMSG                 ALLOW PAC CODE -MS- ENTRIES FOR AGENCIES/ASSOCIATES",
            "COMSAB                  ALLOW CREATE AND MODIFY COMMERCIAL SABRE PROFILES",
            "CVRSAB                   CONVERSATIONAL SABRE TERMINAL",
            "DOTCOM                 IDENTIFY AIRLINE CONTROLLED PCC",
            "E@@@@@             CONTROL E   ENTRY VIA PAC CODE TABLE",
            "EPRDSP                   ALLOW DISPLAY OF ALL EPRS AND -H*CST- CAPABILITY",
            "ETDNAG                  ELECTRONIC TICKET DELIVERY NETWORK AGENCY AGENT ",
            "ETRMAP                  ALLOW ONLINE CREATION AND ACTIVATION OF ETRMAP FILE",
            "F@@@@@             CONTROL F   ENTRIES VIA PAC CODE TABLE  ",
            "FOXCTL                   ALLOW UPDT/CREATE OF AUTOMATED REFERENCE SYS DATABASE",
            "FS@@@@              CONTROL FS  ENTRY VIA PAC CODE TABLE",
            "GLOBAL                   ALLOW SUBSCRIBERS GLOBAL SPECTRA AND MULTI BR SPECTRA",
            "GLSAGT                   ALLOW GLOBAL SECURITY ENTRIES",
            "GMRUPD                  APPLY RESTRICTIONS TO GMR DISPLAY REQUESTS AND UPDATES",
            "GMSELL                    APPLY RESTRICTIONS TO GMR SELLS",
            "GMTIME                   DISPLAY CURRENT TIME IN GREENWICH MEAN TIME",
            "HDMRCH                 ALLOWED TO PERFORM CK*SMHD ENTRY",
            "HLPDSK                   PROVIDE HELP DESK CAPABILITIES FOR MULTI-HOSTS",
            "HODMIN                  SUPPRESS FREE TXT-HOTEL DIRECT CONNECT AVAIL DISPLAYS",
            "HODRTE                  RESTRICT HOTEL DCS DISPLAYS TO ONLY CRITICAL ELEMENTS",
            "INFEXC                    INFINI AGENT EXCEPTION",
            "INHMSG                   RESTRICT USE OF TELETYPE TRANSFER MESSAGES",
            "INHNMC                   INHIBIT NAME CHANGE ON RETRIEVED PNRS",
            "IPSI01                     IP SIGN IN VERSION ONE",
            "LABELS                    ALLOW PRINTING OF AGENCY MAILING LABELS",
            "LMTACC                  DIRECT ACCESS USERS WITH LIMITED CAPABILITIES",
            "MGUPTE                  CREATE PASSIVE SEG WITH MG/GA TAG",
            "MNTAGT                  ALLOW AGENT TO MONITOR AUTHORIZED SETS",
            "MONEY@                 ALLOW UPDATE OF BANKERS BUYING RATE TABLES",
            "MRCHNT                  RESTRICT MERCHANT FUNCTION TO KEYWORD HOLDERS",
            "N@@@@@             CONTROL N  ENTRY VIA PAC CODE TABLE",
            "MULSET                    ALLOW SIGN-IN FROM ONE EPR INTO MULTIPLE LNIATA/S",
            "NEGAGT                   ALLOW BUILDING OF BRANCH TABLES FOR NEGOTIATED FARES",
            "NETFQD\t                ACCESS TO NET FARES APPLICABLE TO AGENTS LOCATION",
            "NETWEB                  WEB-BASED BROWSER FOR NET FARES MARK UP PROJECT",
            "NO@AAA                 INHIBIT CHANGING AAA TO THE SET/S UAT CITY",
            "NOBCHQ                  INHIBIT ACCESS TO BRANCH OFFICE QUEUES",
            "NOBDPS                   INHIBIT BOARDING PASS PRINTER ASSIGNMENT",
            "NOCTPS                   INHIBIT CORP TVL PLCY SYSTEM/FLEXIBLE PNR EDITS",
            "NODOCS                  INHIBIT ALL BOARDING CONTROL PRINTER ASSIGNMENTS",
            "NOINIS                     INHIBIT INVOICE/ITINERARY PRINTER ASSIGNMENT",
            "NOMSGQ                  INHIBIT BRANCH OFF QUEUES AND MSG QUEUES OF HOME STA",
            "NOPNRS                   INHIBIT PNR UPDATES",
            "NOQUES                   INHIBIT ACCESS TO ALL QUEUES",
            "NOSTAR                   INHIBIT UPDATES TO STARS",
            "NOTKTS                    INHIBIT TICKET PRINTER ASSIGNMENT",
            "NSPLAT                    CONTROL N* ENTRIES VIA PAC TABLE",
            "ONSNAP                   NETEGRITY SECURITY FOR ONSNAP WEB APPLICATION",
            "PTR@@@                CONTROL PTR ENTRIES VIA PAC CODE TABLE",
            "PVTAGT                    ALLOW USE AND DISPLAY OF PRIVATE FARES",
            "PVTDIS                     ALLOW USE AND DISPLAY OF PRIVATE FARES",
            "Q@@@@@             CONTROL Q   ENTRY VIA PAC CODE TABLE",
            "QUESUB                   ALLOWS UPDATES TO PUB-SUB INDICATORS IN QUEUES DATABASE",
            "RECHCK                   PERMIT USE OF NIGHTLY FARE RE-CHECK ",
            "REMOVE                   ALLOW REMOVAL OF INTERFACE MESSAGE FROM THE PQS QUEUE",
            "REQROB                   POSSIBLE ROBOTIC MACHINE ID",
            "RKNAME                   ABACUS SURNAME CHANGE RESTRICTION TABLE",
            "ROBAP1                   GENUINE ROBOTIC MACHINE ID",
            "ROBAP2                   GENUINE ROBOTIC MACHINE ID-2",
            "RTABLE                    AMEX- ALLOW SUBSCRIBERS TO UPD RESTRICTION TABLES",
            "S@@@@@              CONTROL S   ENTRY VIA PAC CODE TABLE",
            "SABEXC                    SABRE AGENT EXCEPTION",
            "SAMRCH                  ALLOWED TO PERFORM CK*SMSA ENTRY",
            "SASELN                    CONTROL SASE LINES FOR COMPLEX PRICING",
            "SI@@@@                CONTROL SI  ENTRY VIA PAC CODE TABLE",
            "SIRMSG                    ALLOW AGENTS TO CREATE SIGN-IN MSGS FOR THEIR OWN CITY",
            "SPRMKT                    \\SUPERMARKET AUTHORIZATION KEYWORD",
            "STCORP                    ALLOW ACCESS TO SATO DATA BASE ",
            "STMOPR                    ALLOW CMS INTERFACE QUEUE ENTRIES",
            "SUBAAA                    ALLOW AAA ENTRY FOR AGENCY - BRA DOCUMENT GENERATION",
            "SUBREJ                     ALLOW SUBSCRIBER AGENT TO SIGN-IN WITH DUTY CODE ZERO",
            "TAVAIL                      ALLOW 20 LINE CITY PAIR AVAILABILITY DISPLAY",
            "TODAGT                    ALLOW AGENT TO ISSUE TICKET ON DEPARTURE PTA",
            "TRPSCH                     PERMIT USE OF FARE TRIP SEARCH",
            "UNISTR                     ALLOW CREATION OF UNIVERSAL STAR RECORDS",
            "W@@@@@             CONTROL W   ENTRY VIA PAC CODE TABLE",
            "WPNALL                    ALLOW WPNI OR WPNC/ALL ENTRIES",
            "WSLASH                   CONTROL W/  ENTRIES VIA PAC CODE TABLE",
            "WWWUSR                SABRE INTERNET PRODUCTS THAT USSE EZGDS TO COMUNICATE",
            "XAGSSX                    AGSS CONTROL KEYWORD",
            "Y@SLH@                  CONTROL Y/  ENTRIES VIA PAC CODE TABLE",
            "1@@@@@              CONTROL 1   ENTRY VIA PAC CODE TABLE",
            "5@@@@@              CONTROL 5   ENTRY VIA PAC CODE TABLE",
            "6@@@@@              CONTROL 6   ENTRY VIA PAC CODE TABLE"});
            this.cmbKeyWord11.Location = new System.Drawing.Point(19, 220);
            this.cmbKeyWord11.Name = "cmbKeyWord11";
            this.cmbKeyWord11.Size = new System.Drawing.Size(371, 21);
            this.cmbKeyWord11.TabIndex = 8;
            this.cmbKeyWord11.SelectedIndexChanged += new System.EventHandler(this.cmbKeyWord11_SelectedIndexChanged);
            this.cmbKeyWord11.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // cmbKeyWord9
            // 
            this.cmbKeyWord9.FormattingEnabled = true;
            this.cmbKeyWord9.Items.AddRange(new object[] {
            "",
            "AASATO                  AGENCY ACCESS TO FOCUS MANUALS - F*CDP",
            "ABAEXC                  ABACUS AGENT EXCEPTION",
            "ADSCOM                 CONTROL ADS MACHINE-TO-MACHINE NETWORK COMMUNICATION",
            "AGSTRC                  FORCE ICE DEBUG",
            "ALTDSP                   CONTROL HOTEL SHOPPING LIST DISPLAY",
            "ALUPTE                   ABACUS AND INFINI CONNECTIVITY TAG",
            "APLRST                   APPLICATIONS RESTRICT - EPR RESTRICTED TO APLCTL",
            "ARCRPT                  ALLOW PRINTING OF AGENCY ARC REPORTS",
            "ASK@@@               CONTROL *   ENTRY VIA PAC CODE TABLE ",
            "ATBRPT                   ALLOW DELETE OF TKT AUDIT TRAIL REPORT",
            "AVLSCN                   AA.COM SCAN AVAILABILTY ENTRIES/REQUEST AADVANTAGE CLS",
            "AYMADM                 SPVSR ADMINISTRATOR ROLE FOR ARM-REVENUE ADVANTAGE AGT+",
            "AYMAFM                 ALLOW ACCESS TO WEB GUI TO UPDATE SERVICE FEE RULES",
            "AYMARM                 AGENCY REVENUE MANAGMENT SUPERVISOR",
            "AYMARU                 AGENCY REVENUE MANAGMENT USER",
            "B-MAIL                    ALLOW DISPLAY/USE OF B-MAIL MESSAGE QUEUE",
            "BSRDSP                   PRICING -- BANKERS SELLING RATE DISPLAY",
            "CARCAN                  PROVIDE RATE CANVASSING WITHOUT PROVIDING RATE UPDATE",
            "CATSUP                   SUPPRESS CATEGORIES IN AN ELECTRONIC RULES DISPLAY",
            "CCVIEW                   ALLOW AGENT TO ADD CCVIEW UAT KEYWORD TO AAA&OAM",
            "COMMSG                 ALLOW PAC CODE -MS- ENTRIES FOR AGENCIES/ASSOCIATES",
            "COMSAB                  ALLOW CREATE AND MODIFY COMMERCIAL SABRE PROFILES",
            "CVRSAB                   CONVERSATIONAL SABRE TERMINAL",
            "DOTCOM                 IDENTIFY AIRLINE CONTROLLED PCC",
            "E@@@@@             CONTROL E   ENTRY VIA PAC CODE TABLE",
            "EPRDSP                   ALLOW DISPLAY OF ALL EPRS AND -H*CST- CAPABILITY",
            "ETDNAG                  ELECTRONIC TICKET DELIVERY NETWORK AGENCY AGENT ",
            "ETRMAP                  ALLOW ONLINE CREATION AND ACTIVATION OF ETRMAP FILE",
            "F@@@@@             CONTROL F   ENTRIES VIA PAC CODE TABLE  ",
            "FOXCTL                   ALLOW UPDT/CREATE OF AUTOMATED REFERENCE SYS DATABASE",
            "FS@@@@              CONTROL FS  ENTRY VIA PAC CODE TABLE",
            "GLOBAL                   ALLOW SUBSCRIBERS GLOBAL SPECTRA AND MULTI BR SPECTRA",
            "GLSAGT                   ALLOW GLOBAL SECURITY ENTRIES",
            "GMRUPD                  APPLY RESTRICTIONS TO GMR DISPLAY REQUESTS AND UPDATES",
            "GMSELL                    APPLY RESTRICTIONS TO GMR SELLS",
            "GMTIME                   DISPLAY CURRENT TIME IN GREENWICH MEAN TIME",
            "HDMRCH                 ALLOWED TO PERFORM CK*SMHD ENTRY",
            "HLPDSK                   PROVIDE HELP DESK CAPABILITIES FOR MULTI-HOSTS",
            "HODMIN                  SUPPRESS FREE TXT-HOTEL DIRECT CONNECT AVAIL DISPLAYS",
            "HODRTE                  RESTRICT HOTEL DCS DISPLAYS TO ONLY CRITICAL ELEMENTS",
            "INFEXC                    INFINI AGENT EXCEPTION",
            "INHMSG                   RESTRICT USE OF TELETYPE TRANSFER MESSAGES",
            "INHNMC                   INHIBIT NAME CHANGE ON RETRIEVED PNRS",
            "IPSI01                     IP SIGN IN VERSION ONE",
            "LABELS                    ALLOW PRINTING OF AGENCY MAILING LABELS",
            "LMTACC                  DIRECT ACCESS USERS WITH LIMITED CAPABILITIES",
            "MGUPTE                  CREATE PASSIVE SEG WITH MG/GA TAG",
            "MNTAGT                  ALLOW AGENT TO MONITOR AUTHORIZED SETS",
            "MONEY@                 ALLOW UPDATE OF BANKERS BUYING RATE TABLES",
            "MRCHNT                  RESTRICT MERCHANT FUNCTION TO KEYWORD HOLDERS",
            "N@@@@@             CONTROL N  ENTRY VIA PAC CODE TABLE",
            "MULSET                    ALLOW SIGN-IN FROM ONE EPR INTO MULTIPLE LNIATA/S",
            "NEGAGT                   ALLOW BUILDING OF BRANCH TABLES FOR NEGOTIATED FARES",
            "NETFQD\t                ACCESS TO NET FARES APPLICABLE TO AGENTS LOCATION",
            "NETWEB                  WEB-BASED BROWSER FOR NET FARES MARK UP PROJECT",
            "NO@AAA                 INHIBIT CHANGING AAA TO THE SET/S UAT CITY",
            "NOBCHQ                  INHIBIT ACCESS TO BRANCH OFFICE QUEUES",
            "NOBDPS                   INHIBIT BOARDING PASS PRINTER ASSIGNMENT",
            "NOCTPS                   INHIBIT CORP TVL PLCY SYSTEM/FLEXIBLE PNR EDITS",
            "NODOCS                  INHIBIT ALL BOARDING CONTROL PRINTER ASSIGNMENTS",
            "NOINIS                     INHIBIT INVOICE/ITINERARY PRINTER ASSIGNMENT",
            "NOMSGQ                  INHIBIT BRANCH OFF QUEUES AND MSG QUEUES OF HOME STA",
            "NOPNRS                   INHIBIT PNR UPDATES",
            "NOQUES                   INHIBIT ACCESS TO ALL QUEUES",
            "NOSTAR                   INHIBIT UPDATES TO STARS",
            "NOTKTS                    INHIBIT TICKET PRINTER ASSIGNMENT",
            "NSPLAT                    CONTROL N* ENTRIES VIA PAC TABLE",
            "ONSNAP                   NETEGRITY SECURITY FOR ONSNAP WEB APPLICATION",
            "PTR@@@                CONTROL PTR ENTRIES VIA PAC CODE TABLE",
            "PVTAGT                    ALLOW USE AND DISPLAY OF PRIVATE FARES",
            "PVTDIS                     ALLOW USE AND DISPLAY OF PRIVATE FARES",
            "Q@@@@@             CONTROL Q   ENTRY VIA PAC CODE TABLE",
            "QUESUB                   ALLOWS UPDATES TO PUB-SUB INDICATORS IN QUEUES DATABASE",
            "RECHCK                   PERMIT USE OF NIGHTLY FARE RE-CHECK ",
            "REMOVE                   ALLOW REMOVAL OF INTERFACE MESSAGE FROM THE PQS QUEUE",
            "REQROB                   POSSIBLE ROBOTIC MACHINE ID",
            "RKNAME                   ABACUS SURNAME CHANGE RESTRICTION TABLE",
            "ROBAP1                   GENUINE ROBOTIC MACHINE ID",
            "ROBAP2                   GENUINE ROBOTIC MACHINE ID-2",
            "RTABLE                    AMEX- ALLOW SUBSCRIBERS TO UPD RESTRICTION TABLES",
            "S@@@@@              CONTROL S   ENTRY VIA PAC CODE TABLE",
            "SABEXC                    SABRE AGENT EXCEPTION",
            "SAMRCH                  ALLOWED TO PERFORM CK*SMSA ENTRY",
            "SASELN                    CONTROL SASE LINES FOR COMPLEX PRICING",
            "SI@@@@                CONTROL SI  ENTRY VIA PAC CODE TABLE",
            "SIRMSG                    ALLOW AGENTS TO CREATE SIGN-IN MSGS FOR THEIR OWN CITY",
            "SPRMKT                    \\SUPERMARKET AUTHORIZATION KEYWORD",
            "STCORP                    ALLOW ACCESS TO SATO DATA BASE ",
            "STMOPR                    ALLOW CMS INTERFACE QUEUE ENTRIES",
            "SUBAAA                    ALLOW AAA ENTRY FOR AGENCY - BRA DOCUMENT GENERATION",
            "SUBREJ                     ALLOW SUBSCRIBER AGENT TO SIGN-IN WITH DUTY CODE ZERO",
            "TAVAIL                      ALLOW 20 LINE CITY PAIR AVAILABILITY DISPLAY",
            "TODAGT                    ALLOW AGENT TO ISSUE TICKET ON DEPARTURE PTA",
            "TRPSCH                     PERMIT USE OF FARE TRIP SEARCH",
            "UNISTR                     ALLOW CREATION OF UNIVERSAL STAR RECORDS",
            "W@@@@@             CONTROL W   ENTRY VIA PAC CODE TABLE",
            "WPNALL                    ALLOW WPNI OR WPNC/ALL ENTRIES",
            "WSLASH                   CONTROL W/  ENTRIES VIA PAC CODE TABLE",
            "WWWUSR                SABRE INTERNET PRODUCTS THAT USSE EZGDS TO COMUNICATE",
            "XAGSSX                    AGSS CONTROL KEYWORD",
            "Y@SLH@                  CONTROL Y/  ENTRIES VIA PAC CODE TABLE",
            "1@@@@@              CONTROL 1   ENTRY VIA PAC CODE TABLE",
            "5@@@@@              CONTROL 5   ENTRY VIA PAC CODE TABLE",
            "6@@@@@              CONTROL 6   ENTRY VIA PAC CODE TABLE"});
            this.cmbKeyWord9.Location = new System.Drawing.Point(19, 168);
            this.cmbKeyWord9.Name = "cmbKeyWord9";
            this.cmbKeyWord9.Size = new System.Drawing.Size(371, 21);
            this.cmbKeyWord9.TabIndex = 6;
            this.cmbKeyWord9.SelectedIndexChanged += new System.EventHandler(this.cmbKeyWord9_SelectedIndexChanged);
            this.cmbKeyWord9.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // cmbKeyWord12
            // 
            this.cmbKeyWord12.FormattingEnabled = true;
            this.cmbKeyWord12.Items.AddRange(new object[] {
            "",
            "AASATO                  AGENCY ACCESS TO FOCUS MANUALS - F*CDP",
            "ABAEXC                  ABACUS AGENT EXCEPTION",
            "ADSCOM                 CONTROL ADS MACHINE-TO-MACHINE NETWORK COMMUNICATION",
            "AGSTRC                  FORCE ICE DEBUG",
            "ALTDSP                   CONTROL HOTEL SHOPPING LIST DISPLAY",
            "ALUPTE                   ABACUS AND INFINI CONNECTIVITY TAG",
            "APLRST                   APPLICATIONS RESTRICT - EPR RESTRICTED TO APLCTL",
            "ARCRPT                  ALLOW PRINTING OF AGENCY ARC REPORTS",
            "ASK@@@               CONTROL *   ENTRY VIA PAC CODE TABLE ",
            "ATBRPT                   ALLOW DELETE OF TKT AUDIT TRAIL REPORT",
            "AVLSCN                   AA.COM SCAN AVAILABILTY ENTRIES/REQUEST AADVANTAGE CLS",
            "AYMADM                 SPVSR ADMINISTRATOR ROLE FOR ARM-REVENUE ADVANTAGE AGT+",
            "AYMAFM                 ALLOW ACCESS TO WEB GUI TO UPDATE SERVICE FEE RULES",
            "AYMARM                 AGENCY REVENUE MANAGMENT SUPERVISOR",
            "AYMARU                 AGENCY REVENUE MANAGMENT USER",
            "B-MAIL                    ALLOW DISPLAY/USE OF B-MAIL MESSAGE QUEUE",
            "BSRDSP                   PRICING -- BANKERS SELLING RATE DISPLAY",
            "CARCAN                  PROVIDE RATE CANVASSING WITHOUT PROVIDING RATE UPDATE",
            "CATSUP                   SUPPRESS CATEGORIES IN AN ELECTRONIC RULES DISPLAY",
            "CCVIEW                   ALLOW AGENT TO ADD CCVIEW UAT KEYWORD TO AAA&OAM",
            "COMMSG                 ALLOW PAC CODE -MS- ENTRIES FOR AGENCIES/ASSOCIATES",
            "COMSAB                  ALLOW CREATE AND MODIFY COMMERCIAL SABRE PROFILES",
            "CVRSAB                   CONVERSATIONAL SABRE TERMINAL",
            "DOTCOM                 IDENTIFY AIRLINE CONTROLLED PCC",
            "E@@@@@             CONTROL E   ENTRY VIA PAC CODE TABLE",
            "EPRDSP                   ALLOW DISPLAY OF ALL EPRS AND -H*CST- CAPABILITY",
            "ETDNAG                  ELECTRONIC TICKET DELIVERY NETWORK AGENCY AGENT ",
            "ETRMAP                  ALLOW ONLINE CREATION AND ACTIVATION OF ETRMAP FILE",
            "F@@@@@             CONTROL F   ENTRIES VIA PAC CODE TABLE  ",
            "FOXCTL                   ALLOW UPDT/CREATE OF AUTOMATED REFERENCE SYS DATABASE",
            "FS@@@@              CONTROL FS  ENTRY VIA PAC CODE TABLE",
            "GLOBAL                   ALLOW SUBSCRIBERS GLOBAL SPECTRA AND MULTI BR SPECTRA",
            "GLSAGT                   ALLOW GLOBAL SECURITY ENTRIES",
            "GMRUPD                  APPLY RESTRICTIONS TO GMR DISPLAY REQUESTS AND UPDATES",
            "GMSELL                    APPLY RESTRICTIONS TO GMR SELLS",
            "GMTIME                   DISPLAY CURRENT TIME IN GREENWICH MEAN TIME",
            "HDMRCH                 ALLOWED TO PERFORM CK*SMHD ENTRY",
            "HLPDSK                   PROVIDE HELP DESK CAPABILITIES FOR MULTI-HOSTS",
            "HODMIN                  SUPPRESS FREE TXT-HOTEL DIRECT CONNECT AVAIL DISPLAYS",
            "HODRTE                  RESTRICT HOTEL DCS DISPLAYS TO ONLY CRITICAL ELEMENTS",
            "INFEXC                    INFINI AGENT EXCEPTION",
            "INHMSG                   RESTRICT USE OF TELETYPE TRANSFER MESSAGES",
            "INHNMC                   INHIBIT NAME CHANGE ON RETRIEVED PNRS",
            "IPSI01                     IP SIGN IN VERSION ONE",
            "LABELS                    ALLOW PRINTING OF AGENCY MAILING LABELS",
            "LMTACC                  DIRECT ACCESS USERS WITH LIMITED CAPABILITIES",
            "MGUPTE                  CREATE PASSIVE SEG WITH MG/GA TAG",
            "MNTAGT                  ALLOW AGENT TO MONITOR AUTHORIZED SETS",
            "MONEY@                 ALLOW UPDATE OF BANKERS BUYING RATE TABLES",
            "MRCHNT                  RESTRICT MERCHANT FUNCTION TO KEYWORD HOLDERS",
            "N@@@@@             CONTROL N  ENTRY VIA PAC CODE TABLE",
            "MULSET                    ALLOW SIGN-IN FROM ONE EPR INTO MULTIPLE LNIATA/S",
            "NEGAGT                   ALLOW BUILDING OF BRANCH TABLES FOR NEGOTIATED FARES",
            "NETFQD\t                ACCESS TO NET FARES APPLICABLE TO AGENTS LOCATION",
            "NETWEB                  WEB-BASED BROWSER FOR NET FARES MARK UP PROJECT",
            "NO@AAA                 INHIBIT CHANGING AAA TO THE SET/S UAT CITY",
            "NOBCHQ                  INHIBIT ACCESS TO BRANCH OFFICE QUEUES",
            "NOBDPS                   INHIBIT BOARDING PASS PRINTER ASSIGNMENT",
            "NOCTPS                   INHIBIT CORP TVL PLCY SYSTEM/FLEXIBLE PNR EDITS",
            "NODOCS                  INHIBIT ALL BOARDING CONTROL PRINTER ASSIGNMENTS",
            "NOINIS                     INHIBIT INVOICE/ITINERARY PRINTER ASSIGNMENT",
            "NOMSGQ                  INHIBIT BRANCH OFF QUEUES AND MSG QUEUES OF HOME STA",
            "NOPNRS                   INHIBIT PNR UPDATES",
            "NOQUES                   INHIBIT ACCESS TO ALL QUEUES",
            "NOSTAR                   INHIBIT UPDATES TO STARS",
            "NOTKTS                    INHIBIT TICKET PRINTER ASSIGNMENT",
            "NSPLAT                    CONTROL N* ENTRIES VIA PAC TABLE",
            "ONSNAP                   NETEGRITY SECURITY FOR ONSNAP WEB APPLICATION",
            "PTR@@@                CONTROL PTR ENTRIES VIA PAC CODE TABLE",
            "PVTAGT                    ALLOW USE AND DISPLAY OF PRIVATE FARES",
            "PVTDIS                     ALLOW USE AND DISPLAY OF PRIVATE FARES",
            "Q@@@@@             CONTROL Q   ENTRY VIA PAC CODE TABLE",
            "QUESUB                   ALLOWS UPDATES TO PUB-SUB INDICATORS IN QUEUES DATABASE",
            "RECHCK                   PERMIT USE OF NIGHTLY FARE RE-CHECK ",
            "REMOVE                   ALLOW REMOVAL OF INTERFACE MESSAGE FROM THE PQS QUEUE",
            "REQROB                   POSSIBLE ROBOTIC MACHINE ID",
            "RKNAME                   ABACUS SURNAME CHANGE RESTRICTION TABLE",
            "ROBAP1                   GENUINE ROBOTIC MACHINE ID",
            "ROBAP2                   GENUINE ROBOTIC MACHINE ID-2",
            "RTABLE                    AMEX- ALLOW SUBSCRIBERS TO UPD RESTRICTION TABLES",
            "S@@@@@              CONTROL S   ENTRY VIA PAC CODE TABLE",
            "SABEXC                    SABRE AGENT EXCEPTION",
            "SAMRCH                  ALLOWED TO PERFORM CK*SMSA ENTRY",
            "SASELN                    CONTROL SASE LINES FOR COMPLEX PRICING",
            "SI@@@@                CONTROL SI  ENTRY VIA PAC CODE TABLE",
            "SIRMSG                    ALLOW AGENTS TO CREATE SIGN-IN MSGS FOR THEIR OWN CITY",
            "SPRMKT                    \\SUPERMARKET AUTHORIZATION KEYWORD",
            "STCORP                    ALLOW ACCESS TO SATO DATA BASE ",
            "STMOPR                    ALLOW CMS INTERFACE QUEUE ENTRIES",
            "SUBAAA                    ALLOW AAA ENTRY FOR AGENCY - BRA DOCUMENT GENERATION",
            "SUBREJ                     ALLOW SUBSCRIBER AGENT TO SIGN-IN WITH DUTY CODE ZERO",
            "TAVAIL                      ALLOW 20 LINE CITY PAIR AVAILABILITY DISPLAY",
            "TODAGT                    ALLOW AGENT TO ISSUE TICKET ON DEPARTURE PTA",
            "TRPSCH                     PERMIT USE OF FARE TRIP SEARCH",
            "UNISTR                     ALLOW CREATION OF UNIVERSAL STAR RECORDS",
            "W@@@@@             CONTROL W   ENTRY VIA PAC CODE TABLE",
            "WPNALL                    ALLOW WPNI OR WPNC/ALL ENTRIES",
            "WSLASH                   CONTROL W/  ENTRIES VIA PAC CODE TABLE",
            "WWWUSR                SABRE INTERNET PRODUCTS THAT USSE EZGDS TO COMUNICATE",
            "XAGSSX                    AGSS CONTROL KEYWORD",
            "Y@SLH@                  CONTROL Y/  ENTRIES VIA PAC CODE TABLE",
            "1@@@@@              CONTROL 1   ENTRY VIA PAC CODE TABLE",
            "5@@@@@              CONTROL 5   ENTRY VIA PAC CODE TABLE",
            "6@@@@@              CONTROL 6   ENTRY VIA PAC CODE TABLE"});
            this.cmbKeyWord12.Location = new System.Drawing.Point(19, 246);
            this.cmbKeyWord12.Name = "cmbKeyWord12";
            this.cmbKeyWord12.Size = new System.Drawing.Size(371, 21);
            this.cmbKeyWord12.TabIndex = 9;
            this.cmbKeyWord12.SelectedIndexChanged += new System.EventHandler(this.cmbKeyWord12_SelectedIndexChanged);
            this.cmbKeyWord12.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // cmbKeyWord8
            // 
            this.cmbKeyWord8.FormattingEnabled = true;
            this.cmbKeyWord8.Items.AddRange(new object[] {
            "",
            "AASATO                  AGENCY ACCESS TO FOCUS MANUALS - F*CDP",
            "ABAEXC                  ABACUS AGENT EXCEPTION",
            "ADSCOM                 CONTROL ADS MACHINE-TO-MACHINE NETWORK COMMUNICATION",
            "AGSTRC                  FORCE ICE DEBUG",
            "ALTDSP                   CONTROL HOTEL SHOPPING LIST DISPLAY",
            "ALUPTE                   ABACUS AND INFINI CONNECTIVITY TAG",
            "APLRST                   APPLICATIONS RESTRICT - EPR RESTRICTED TO APLCTL",
            "ARCRPT                  ALLOW PRINTING OF AGENCY ARC REPORTS",
            "ASK@@@               CONTROL *   ENTRY VIA PAC CODE TABLE ",
            "ATBRPT                   ALLOW DELETE OF TKT AUDIT TRAIL REPORT",
            "AVLSCN                   AA.COM SCAN AVAILABILTY ENTRIES/REQUEST AADVANTAGE CLS",
            "AYMADM                 SPVSR ADMINISTRATOR ROLE FOR ARM-REVENUE ADVANTAGE AGT+",
            "AYMAFM                 ALLOW ACCESS TO WEB GUI TO UPDATE SERVICE FEE RULES",
            "AYMARM                 AGENCY REVENUE MANAGMENT SUPERVISOR",
            "AYMARU                 AGENCY REVENUE MANAGMENT USER",
            "B-MAIL                    ALLOW DISPLAY/USE OF B-MAIL MESSAGE QUEUE",
            "BSRDSP                   PRICING -- BANKERS SELLING RATE DISPLAY",
            "CARCAN                  PROVIDE RATE CANVASSING WITHOUT PROVIDING RATE UPDATE",
            "CATSUP                   SUPPRESS CATEGORIES IN AN ELECTRONIC RULES DISPLAY",
            "CCVIEW                   ALLOW AGENT TO ADD CCVIEW UAT KEYWORD TO AAA&OAM",
            "COMMSG                 ALLOW PAC CODE -MS- ENTRIES FOR AGENCIES/ASSOCIATES",
            "COMSAB                  ALLOW CREATE AND MODIFY COMMERCIAL SABRE PROFILES",
            "CVRSAB                   CONVERSATIONAL SABRE TERMINAL",
            "DOTCOM                 IDENTIFY AIRLINE CONTROLLED PCC",
            "E@@@@@             CONTROL E   ENTRY VIA PAC CODE TABLE",
            "EPRDSP                   ALLOW DISPLAY OF ALL EPRS AND -H*CST- CAPABILITY",
            "ETDNAG                  ELECTRONIC TICKET DELIVERY NETWORK AGENCY AGENT ",
            "ETRMAP                  ALLOW ONLINE CREATION AND ACTIVATION OF ETRMAP FILE",
            "F@@@@@             CONTROL F   ENTRIES VIA PAC CODE TABLE  ",
            "FOXCTL                   ALLOW UPDT/CREATE OF AUTOMATED REFERENCE SYS DATABASE",
            "FS@@@@              CONTROL FS  ENTRY VIA PAC CODE TABLE",
            "GLOBAL                   ALLOW SUBSCRIBERS GLOBAL SPECTRA AND MULTI BR SPECTRA",
            "GLSAGT                   ALLOW GLOBAL SECURITY ENTRIES",
            "GMRUPD                  APPLY RESTRICTIONS TO GMR DISPLAY REQUESTS AND UPDATES",
            "GMSELL                    APPLY RESTRICTIONS TO GMR SELLS",
            "GMTIME                   DISPLAY CURRENT TIME IN GREENWICH MEAN TIME",
            "HDMRCH                 ALLOWED TO PERFORM CK*SMHD ENTRY",
            "HLPDSK                   PROVIDE HELP DESK CAPABILITIES FOR MULTI-HOSTS",
            "HODMIN                  SUPPRESS FREE TXT-HOTEL DIRECT CONNECT AVAIL DISPLAYS",
            "HODRTE                  RESTRICT HOTEL DCS DISPLAYS TO ONLY CRITICAL ELEMENTS",
            "INFEXC                    INFINI AGENT EXCEPTION",
            "INHMSG                   RESTRICT USE OF TELETYPE TRANSFER MESSAGES",
            "INHNMC                   INHIBIT NAME CHANGE ON RETRIEVED PNRS",
            "IPSI01                     IP SIGN IN VERSION ONE",
            "LABELS                    ALLOW PRINTING OF AGENCY MAILING LABELS",
            "LMTACC                  DIRECT ACCESS USERS WITH LIMITED CAPABILITIES",
            "MGUPTE                  CREATE PASSIVE SEG WITH MG/GA TAG",
            "MNTAGT                  ALLOW AGENT TO MONITOR AUTHORIZED SETS",
            "MONEY@                 ALLOW UPDATE OF BANKERS BUYING RATE TABLES",
            "MRCHNT                  RESTRICT MERCHANT FUNCTION TO KEYWORD HOLDERS",
            "N@@@@@             CONTROL N  ENTRY VIA PAC CODE TABLE",
            "MULSET                    ALLOW SIGN-IN FROM ONE EPR INTO MULTIPLE LNIATA/S",
            "NEGAGT                   ALLOW BUILDING OF BRANCH TABLES FOR NEGOTIATED FARES",
            "NETFQD\t                ACCESS TO NET FARES APPLICABLE TO AGENTS LOCATION",
            "NETWEB                  WEB-BASED BROWSER FOR NET FARES MARK UP PROJECT",
            "NO@AAA                 INHIBIT CHANGING AAA TO THE SET/S UAT CITY",
            "NOBCHQ                  INHIBIT ACCESS TO BRANCH OFFICE QUEUES",
            "NOBDPS                   INHIBIT BOARDING PASS PRINTER ASSIGNMENT",
            "NOCTPS                   INHIBIT CORP TVL PLCY SYSTEM/FLEXIBLE PNR EDITS",
            "NODOCS                  INHIBIT ALL BOARDING CONTROL PRINTER ASSIGNMENTS",
            "NOINIS                     INHIBIT INVOICE/ITINERARY PRINTER ASSIGNMENT",
            "NOMSGQ                  INHIBIT BRANCH OFF QUEUES AND MSG QUEUES OF HOME STA",
            "NOPNRS                   INHIBIT PNR UPDATES",
            "NOQUES                   INHIBIT ACCESS TO ALL QUEUES",
            "NOSTAR                   INHIBIT UPDATES TO STARS",
            "NOTKTS                    INHIBIT TICKET PRINTER ASSIGNMENT",
            "NSPLAT                    CONTROL N* ENTRIES VIA PAC TABLE",
            "ONSNAP                   NETEGRITY SECURITY FOR ONSNAP WEB APPLICATION",
            "PTR@@@                CONTROL PTR ENTRIES VIA PAC CODE TABLE",
            "PVTAGT                    ALLOW USE AND DISPLAY OF PRIVATE FARES",
            "PVTDIS                     ALLOW USE AND DISPLAY OF PRIVATE FARES",
            "Q@@@@@             CONTROL Q   ENTRY VIA PAC CODE TABLE",
            "QUESUB                   ALLOWS UPDATES TO PUB-SUB INDICATORS IN QUEUES DATABASE",
            "RECHCK                   PERMIT USE OF NIGHTLY FARE RE-CHECK ",
            "REMOVE                   ALLOW REMOVAL OF INTERFACE MESSAGE FROM THE PQS QUEUE",
            "REQROB                   POSSIBLE ROBOTIC MACHINE ID",
            "RKNAME                   ABACUS SURNAME CHANGE RESTRICTION TABLE",
            "ROBAP1                   GENUINE ROBOTIC MACHINE ID",
            "ROBAP2                   GENUINE ROBOTIC MACHINE ID-2",
            "RTABLE                    AMEX- ALLOW SUBSCRIBERS TO UPD RESTRICTION TABLES",
            "S@@@@@              CONTROL S   ENTRY VIA PAC CODE TABLE",
            "SABEXC                    SABRE AGENT EXCEPTION",
            "SAMRCH                  ALLOWED TO PERFORM CK*SMSA ENTRY",
            "SASELN                    CONTROL SASE LINES FOR COMPLEX PRICING",
            "SI@@@@                CONTROL SI  ENTRY VIA PAC CODE TABLE",
            "SIRMSG                    ALLOW AGENTS TO CREATE SIGN-IN MSGS FOR THEIR OWN CITY",
            "SPRMKT                    \\SUPERMARKET AUTHORIZATION KEYWORD",
            "STCORP                    ALLOW ACCESS TO SATO DATA BASE ",
            "STMOPR                    ALLOW CMS INTERFACE QUEUE ENTRIES",
            "SUBAAA                    ALLOW AAA ENTRY FOR AGENCY - BRA DOCUMENT GENERATION",
            "SUBREJ                     ALLOW SUBSCRIBER AGENT TO SIGN-IN WITH DUTY CODE ZERO",
            "TAVAIL                      ALLOW 20 LINE CITY PAIR AVAILABILITY DISPLAY",
            "TODAGT                    ALLOW AGENT TO ISSUE TICKET ON DEPARTURE PTA",
            "TRPSCH                     PERMIT USE OF FARE TRIP SEARCH",
            "UNISTR                     ALLOW CREATION OF UNIVERSAL STAR RECORDS",
            "W@@@@@             CONTROL W   ENTRY VIA PAC CODE TABLE",
            "WPNALL                    ALLOW WPNI OR WPNC/ALL ENTRIES",
            "WSLASH                   CONTROL W/  ENTRIES VIA PAC CODE TABLE",
            "WWWUSR                SABRE INTERNET PRODUCTS THAT USSE EZGDS TO COMUNICATE",
            "XAGSSX                    AGSS CONTROL KEYWORD",
            "Y@SLH@                  CONTROL Y/  ENTRIES VIA PAC CODE TABLE",
            "1@@@@@              CONTROL 1   ENTRY VIA PAC CODE TABLE",
            "5@@@@@              CONTROL 5   ENTRY VIA PAC CODE TABLE",
            "6@@@@@              CONTROL 6   ENTRY VIA PAC CODE TABLE"});
            this.cmbKeyWord8.Location = new System.Drawing.Point(19, 141);
            this.cmbKeyWord8.Name = "cmbKeyWord8";
            this.cmbKeyWord8.Size = new System.Drawing.Size(371, 21);
            this.cmbKeyWord8.TabIndex = 5;
            this.cmbKeyWord8.SelectedIndexChanged += new System.EventHandler(this.cmbKeyWord8_SelectedIndexChanged);
            this.cmbKeyWord8.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtAuthorization
            // 
            this.txtAuthorization.AllowBlankSpaces = true;
            this.txtAuthorization.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAuthorization.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtAuthorization.CustomExpression = ".*";
            this.txtAuthorization.EnterColor = System.Drawing.Color.Empty;
            this.txtAuthorization.LeaveColor = System.Drawing.Color.Empty;
            this.txtAuthorization.Location = new System.Drawing.Point(99, 90);
            this.txtAuthorization.MaxLength = 20;
            this.txtAuthorization.Name = "txtAuthorization";
            this.txtAuthorization.Size = new System.Drawing.Size(152, 20);
            this.txtAuthorization.TabIndex = 4;
            this.txtAuthorization.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblAuthorization
            // 
            this.lblAuthorization.AutoSize = true;
            this.lblAuthorization.Location = new System.Drawing.Point(16, 94);
            this.lblAuthorization.Name = "lblAuthorization";
            this.lblAuthorization.Size = new System.Drawing.Size(75, 13);
            this.lblAuthorization.TabIndex = 31;
            this.lblAuthorization.Text = "Autorizado por";
            // 
            // txtNumberFirm
            // 
            this.txtNumberFirm.AllowBlankSpaces = true;
            this.txtNumberFirm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberFirm.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtNumberFirm.CustomExpression = ".*";
            this.txtNumberFirm.EnterColor = System.Drawing.Color.Empty;
            this.txtNumberFirm.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumberFirm.Location = new System.Drawing.Point(99, 62);
            this.txtNumberFirm.MaxLength = 4;
            this.txtNumberFirm.Name = "txtNumberFirm";
            this.txtNumberFirm.Size = new System.Drawing.Size(63, 20);
            this.txtNumberFirm.TabIndex = 3;
            this.txtNumberFirm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblNumberFirm
            // 
            this.lblNumberFirm.AutoSize = true;
            this.lblNumberFirm.Location = new System.Drawing.Point(16, 65);
            this.lblNumberFirm.Name = "lblNumberFirm";
            this.lblNumberFirm.Size = new System.Drawing.Size(67, 13);
            this.lblNumberFirm.TabIndex = 0;
            this.lblNumberFirm.Text = "No. de Firma";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(278, 278);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 10;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblKeyword
            // 
            this.lblKeyword.AutoSize = true;
            this.lblKeyword.Location = new System.Drawing.Point(16, 122);
            this.lblKeyword.Name = "lblKeyword";
            this.lblKeyword.Size = new System.Drawing.Size(85, 13);
            this.lblKeyword.TabIndex = 35;
            this.lblKeyword.Text = "Keyword a elegir";
            // 
            // ucEnableDisable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblKeyword);
            this.Controls.Add(this.txtAuthorization);
            this.Controls.Add(this.lblAuthorization);
            this.Controls.Add(this.txtNumberFirm);
            this.Controls.Add(this.lblNumberFirm);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.cmbKeyWord10);
            this.Controls.Add(this.cmbKeyWord11);
            this.Controls.Add(this.cmbKeyWord9);
            this.Controls.Add(this.cmbKeyWord12);
            this.Controls.Add(this.cmbKeyWord8);
            this.Controls.Add(this.rdoDelete);
            this.Controls.Add(this.rdoAdd);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucEnableDisable";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucEnableDisable_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RadioButton rdoAdd;
        private System.Windows.Forms.RadioButton rdoDelete;
        private System.Windows.Forms.ComboBox cmbKeyWord10;
        private System.Windows.Forms.ComboBox cmbKeyWord11;
        private System.Windows.Forms.ComboBox cmbKeyWord9;
        private System.Windows.Forms.ComboBox cmbKeyWord12;
        private System.Windows.Forms.ComboBox cmbKeyWord8;
        private MyCTS.Forms.UI.SmartTextBox txtAuthorization;
        private System.Windows.Forms.Label lblAuthorization;
        private MyCTS.Forms.UI.SmartTextBox txtNumberFirm;
        private System.Windows.Forms.Label lblNumberFirm;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblKeyword;
    }
}
