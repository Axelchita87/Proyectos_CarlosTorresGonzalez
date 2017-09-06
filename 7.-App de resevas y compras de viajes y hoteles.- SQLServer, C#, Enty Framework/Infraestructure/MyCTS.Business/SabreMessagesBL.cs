using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class SabreMessagesBL
    {

        public enum Module
        {
            Default = 0,
            Availability = 1,
            SellSegments = 2,
            AirRateMenu = 3,
            AddDataPassenger=4,
            DefinePassengerType=5,
            INFPassenger=6,
            SetsMap=7,
            BoletageDateAndReceived=8,
            ConcludeReservation=9,
            CancelSegments=10,
            DWLIST = 11,

        }

        public static SabreMessages GetSingleSabreMessage(string apiMessage, Module module)
        {
            int moduleId = GetModuleID(module);

            SabreMessages item = null;
            SabreMessagesDAL objSabreMessages = new SabreMessagesDAL();
            try
            {
                try
                {
                    item = objSabreMessages.GetSingleSabreMessage(apiMessage, moduleId, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    item = objSabreMessages.GetSingleSabreMessage(apiMessage, moduleId, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
                
            }
            catch
            { }

            return item;
        }
        public static SabreMessages GetSingleSabreMessage(string apiMessage)
        {
            return GetSingleSabreMessage(apiMessage, Module.Default);
        }

        public static List<SabreMessages> GetSabreMessages(Module module)
        {
            return GetSabreMessages(module, false);
        }

        public static List<SabreMessages> GetSabreMessages(Module module, bool includeConditionals)
        {
            int moduleId = GetModuleID(module);

            List<SabreMessages> listSabreMessages = new List<SabreMessages>();
            try
            {
                SabreMessagesDAL objSabreMessages = new SabreMessagesDAL();
                listSabreMessages = objSabreMessages.GetSabreMessages(moduleId, includeConditionals);
            }
            catch (Exception )
            {
 
            }

            return listSabreMessages;
        }

        private static int GetModuleID(Module module)
        {
            int moduleId = 0;

            switch (module)
            {
                case Module.Default:
                    moduleId = Components.NullableHelper.Types.IntegerNullValue;
                    break;
                
                case Module.Availability:
                    moduleId = 1;
                    break;
                case Module.SellSegments:
                    moduleId = 2;
                    break;

                case Module.AirRateMenu:
                    moduleId = 3;
                    break;
                case Module.AddDataPassenger:
                    moduleId = 4;
                    break;

                case Module.DefinePassengerType:
                    moduleId=5;
                    break;
                case Module.INFPassenger:
                    moduleId = 6;
                    break;
                case Module.SetsMap:
                    moduleId = 7;
                    break;
                case Module.BoletageDateAndReceived:
                    moduleId = 8;
                    break;
                case Module.ConcludeReservation:
                    moduleId = 9;
                    break;
                case Module.CancelSegments:
                    moduleId = 10;
                    break;
                case Module.DWLIST:
                    moduleId = 11;
                    break;

            }

            return moduleId;
        }
    }
}
