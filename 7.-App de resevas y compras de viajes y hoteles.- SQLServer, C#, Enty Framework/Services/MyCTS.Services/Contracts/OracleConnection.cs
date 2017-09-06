using System;
using System.Collections.Generic;
using System.Text;
using MyCTS.Services.MyCTSOracleConnection;
using MyCTS.Services.MyCTSOracleConnectionDev;

namespace MyCTS.Services.Contracts
{
    public class OracleConnection
    {

        public MyCTS.Services.MyCTSOracleConnection.GetAttribute1 GetAttribute1(string location, int OrgId)
        {
                MyCTS.Services.MyCTSOracleConnection.GetAttribute1 AttributeInfo = null;
                MyCTSOracleConnection.Service1 WS = new MyCTSOracleConnection.Service1();
                AttributeInfo = WS.GetAttribute(location, OrgId);
                return AttributeInfo;
        }

        public MyCTS.Services.MyCTSOracleConnectionDev.GetAttribute1 GetAttribute1Dev(string location, int OrgId)
        {
            MyCTS.Services.MyCTSOracleConnectionDev.GetAttribute1 AttributeInfo = null;
            MyCTSOracleConnectionDev.Service1 WS = new MyCTSOracleConnectionDev.Service1();
            AttributeInfo = WS.GetAttribute(location, OrgId);
            return AttributeInfo;
        }



        public MyCTS.Services.MyCTSOracleConnection.Cat1stStarInfoByLocation GetProfileInfo(string location, int OrgId)
        {
            MyCTS.Services.MyCTSOracleConnection.Cat1stStarInfoByLocation ProfileInfo = null;
                MyCTSOracleConnection.Service1 WS = new MyCTSOracleConnection.Service1();
                ProfileInfo = WS.GetProfileByLocation(location, OrgId);
                return ProfileInfo;
        }

        public MyCTS.Services.MyCTSOracleConnectionDev.Cat1stStarInfoByLocation GetProfileInfoDev(string location, int OrgId)
        {
            MyCTS.Services.MyCTSOracleConnectionDev.Cat1stStarInfoByLocation ProfileInfo = null;
            MyCTSOracleConnectionDev.Service1 WS = new MyCTSOracleConnectionDev.Service1();
            ProfileInfo = WS.GetProfileByLocation(location, OrgId);
            return ProfileInfo;
        }

        public string[] GetLocationsDK(string attribute1, int OrgId)
        {
            string[] locationsDK = null;

            try
            {
                MyCTSOracleConnection.Service1 WS = new MyCTSOracleConnection.Service1();
                locationsDK = WS.GetLocationByAttribute1(attribute1, OrgId);
                return locationsDK;
            }
            catch
            {
                try
                {
                    MyCTSOracleConnectionDev.Service1 WS = new MyCTSOracleConnectionDev.Service1();
                    locationsDK = WS.GetLocationByAttribute1(attribute1, OrgId);
                    return locationsDK;
                }
                catch { return locationsDK; }
            }
        }

        public string GetCreditCardNumber(string dk, string typeCard, int OrgId)
        {
            string numeberCard = string.Empty;

            try
            {
                MyCTSOracleConnection.Service1 WS = new MyCTSOracleConnection.Service1();
                numeberCard = WS.GetCreditCardNumber(dk, typeCard, OrgId);
                return numeberCard;
            }
            catch
            {
                try
                {
                    MyCTSOracleConnectionDev.Service1 WS = new MyCTSOracleConnectionDev.Service1();
                    numeberCard = WS.GetCreditCardNumber(dk, typeCard, OrgId);
                    return numeberCard;
                }
                catch { return numeberCard; }

            }
        }

        public bool RegenerateInvoice(string typeInvoice, string numberInvoice, int OrgId)
        {
            bool status = false;
            try
            {
                MyCTSOracleConnection.Service1 WS = new MyCTSOracleConnection.Service1();
                status = WS.RegenerateInvoice(typeInvoice, numberInvoice, OrgId);
                return status;
            }
            catch
            {
                try
                {
                    MyCTSOracleConnectionDev.Service1 WS = new MyCTSOracleConnectionDev.Service1();
                    status = WS.RegenerateInvoice(typeInvoice, numberInvoice, OrgId);
                    return status;
                }
                catch { return status; }
            }
        }

        public string GetTranferCheckNumber(string dk)
        {
            string number = string.Empty;
            try
            {
                MyCTSOracleConnection.Service1 WS = new MyCTSOracleConnection.Service1();
                number = WS.GetTranferCheckNumber(dk);
                return number;
            }
            catch
            {
                try
                {
                    MyCTSOracleConnectionDev.Service1 WS = new MyCTSOracleConnectionDev.Service1();
                    //status = WS.RegenerateInvoice(typeInvoice, numberInvoice, OrgId);
                    return number;
                }
                catch { return number; }
            }
        }
    }
}
