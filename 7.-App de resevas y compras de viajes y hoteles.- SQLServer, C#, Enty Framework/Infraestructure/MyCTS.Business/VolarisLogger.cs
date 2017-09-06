using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class VolarisLogger
    {


        private static VolarisLoggerDAL _dataAcces;
        private static VolarisLoggerDAL DataAccess
        {
            get { return _dataAcces ?? (_dataAcces = new VolarisLoggerDAL()); }
        }

        public static int InsertReservation()
        {
            return DataAccess.InsertReservation();
        }

        public static int UpdateReservation(string volarisPnr, string sabrePnr, VolarisReservationStatus status)
        {
            return DataAccess.UpdateReservation(volarisPnr, sabrePnr, status);
        }
    }
}
