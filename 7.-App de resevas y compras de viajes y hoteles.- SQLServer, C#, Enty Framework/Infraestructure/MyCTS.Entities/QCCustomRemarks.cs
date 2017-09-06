using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class QCCustomRemarks
    {
        private string rmrktype;
        public string RmrkType
        {
            get { return rmrktype; }
            set { rmrktype = value; }
        }

        private string rmrkinitiallabel;
        public string RmrkInitialLabel
        {
            get { return rmrkinitiallabel; }
            set { rmrkinitiallabel = value; }
        }

        private string rmrkidentyfier;
        public string RmrkIdentyfier
        {
            get { return rmrkidentyfier; }
            set { rmrkidentyfier = value; }
        }

        private string rmrkpaxidentyfier;
        public string RmrkPaxIdentyfier
        {
            get { return rmrkpaxidentyfier; }
            set { rmrkpaxidentyfier = value; }
        }

        private string rmrkvalueidentyfier;
        public string RmrkValueIdentyfier
        {
            get { return rmrkvalueidentyfier; }
            set { rmrkvalueidentyfier = value; }
        }

        private string rmrkfinallabel;
        public string RmrkFinalLabel
        {
            get { return rmrkfinallabel; }
            set { rmrkfinallabel = value; }
        }
    }
}
