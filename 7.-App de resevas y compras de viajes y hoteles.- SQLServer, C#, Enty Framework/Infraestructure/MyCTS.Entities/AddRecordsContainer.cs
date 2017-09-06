using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class AddRecordsContainer
    {
        private static string recloc;
        public static string Recloc
        {
            get { return recloc; }
            set { recloc = value; }
        }

        private static string agent;
        public static string Agent
        {
            get { return agent; }
            set { agent = value; }
        }

        private static bool emissionstatus;
        public static bool EmissionStatus
        {
            get { return emissionstatus; }
            set { emissionstatus = value; }
        }

        //private static bool documentationstatus;
        //public static bool DocumentationStatus
        //{
        //    get { return documentationstatus; }
        //    set { documentationstatus = value; }
        //}
    }
}
