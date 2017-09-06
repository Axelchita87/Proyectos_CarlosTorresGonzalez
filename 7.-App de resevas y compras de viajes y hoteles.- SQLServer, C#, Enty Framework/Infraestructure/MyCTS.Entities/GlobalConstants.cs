using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class GlobalConstants
    {

        public static List<string> FilesDBList = null;

        private static string pathXML = "xml\\{0}.xml";

        public static string AIRLINES_FILENAME
        {
            get
            {
                return string.Format(pathXML, FilesDBList[0]);
            }
        }
        public static string AIRLINESCLASSES_FILENAME
        {
            get
            {
                return string.Format(pathXML, FilesDBList[1]);
            }
        }
        public static string AIRPORTCITYCOUNTRY_LEN_MAJ_FILENAME
        {
            get
            {
                return string.Format(pathXML, FilesDBList[2]);
            }
        }
        public static string AIRPORTCITYCOUNTRY_LEN_MIN_FILENAME
        {
            get
            {
                return string.Format(pathXML, FilesDBList[3]);
            }
        }
        public static string BUSCODES_FILENAME
        {
            get
            {
                return string.Format(pathXML, FilesDBList[4]);
            }
        }
        public static string CARTYPECODES_FILENAME
        {
            get
            {
                return string.Format(pathXML, FilesDBList[5]);
            }
        }
        public static string CATPAIRLINESFARE_FILENAME
        {
            get
            {
                return string.Format(pathXML, FilesDBList[6]);
            }
        }
        //public static string CHARGEPERSERVICE_FILENAME
        //{
        //    get
        //    {
        //        return string.Format(pathXML, FilesDBList[7]);
        //    }
        //}
        public static string CITIES_FILENAME
        {
            get
            {
                return string.Format(pathXML, FilesDBList[7]);
            }
        }
        public static string COSTCENTER_FILNAME
        {
            get
            {
                return string.Format(pathXML, FilesDBList[8]);
            }
        }
        public static string COUNTRIES_FILENAME
        {
            get
            {
                return string.Format(pathXML, FilesDBList[9]);
            }
        }
        public static string CREDITCARDSCODES_FILENAME
        {
            get
            {
                return string.Format(pathXML, FilesDBList[10]);
            }
        }
        public static string CURRENCIESCOUNTRIES_FILENAME
        {
            get
            {
                return string.Format(pathXML, FilesDBList[11]);
            }
        }
        public static string CONFIRMDK_FILNAME
        {
            get
            {
                return string.Format(pathXML, FilesDBList[12]);
            }
        }
        public static string EQUIPMENTCODES_FILENAME
        {
            get
            {
                return string.Format(pathXML, FilesDBList[13]);
            }
        }
        public static string HOTELS_FILENAME
        {
            get
            {
                return string.Format(pathXML, FilesDBList[14]);
            }
        }
        public static string MEALCODES_FILANE
        {
            get
            {
                return string.Format(pathXML, FilesDBList[15]);
            }
        }
        public static string PCCS_FILNAME
        {
            get
            {
                return string.Format(pathXML, FilesDBList[16]);
            }
        }
        public static string SEAVENCODNAME_FILENAME
        {
            get
            {
                return string.Format(pathXML, FilesDBList[17]);
            }
        }
        public static string STATESUSA_FILENAME
        {
            get
            {
                return string.Format(pathXML, FilesDBList[18]);
            }
        }
        public static string STATUSCODES_FILENAME
        {
            get
            {
                return string.Format(pathXML, FilesDBList[19]);
            }
        }
        public static string VENDORCODES_FILENAME
        {
            get
            {
                return string.Format(pathXML, FilesDBList[20]);
            }
        }

        public static string CLIENTSCATALOGS_FILENAME
        {
            get
            {
                return string.Format(pathXML, FilesDBList[24]);
            }
        }

        public static string CLIENTSCATALOGS_SSRCODES
        {
            get
            {
                return string.Format(pathXML, FilesDBList[21]);
            }
        }
        public static string CLIENTSCATALOGS_FARETYPECODES
        {
            get
            {
                return string.Format(pathXML, FilesDBList[22]);
            }
        }
        public static string AGENT_FILENAME
        {
            get
            {
                return string.Format(pathXML, FilesDBList[23]);
            }
        }
        public static string TEMP_FILES
        {
            get
            {
                return PATH_SABRE_USER + "\\temp";
            }
        }
        public static string QUEUE_FILES
        {
            get
            {
                return PATH_SABRE_USER + "\\queue";
            }
        }

        public static string PATH_SABRE_COMPILED;
        public static string PATH_SABRE_USER;

        private static string _currentfilename;
        public static string CurrentFileName
        {
            get
            {
                if (string.IsNullOrEmpty(_currentfilename))
                {
                    _currentfilename = string.Format("mycts_{0}.txt", Guid.NewGuid().ToString());
                }
                return _currentfilename;
            }
            set
            {
                _currentfilename = value;
            }
        }

    }
}
