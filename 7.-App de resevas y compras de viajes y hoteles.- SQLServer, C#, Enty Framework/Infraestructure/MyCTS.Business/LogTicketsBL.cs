using MyCTS.DataAccess;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Business
{
    public class LogTicketsBL
    {
        public static LogTickets LogTicketsInterjet(string ticketNumber)
        {
            LogTicketsDAL objLogApplication = new LogTicketsDAL();
            LogTickets obj = new LogTickets();
            try
            {
                try
                {
                   obj= objLogApplication.LogTicketsInterjet(ticketNumber, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                   obj= objLogApplication.LogTicketsInterjet(ticketNumber, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return obj;
        }

        public static LogTickets LogTicketsVolaris(string ticketNumber)
        {
            LogTicketsDAL objLogApplication = new LogTicketsDAL();
            LogTickets obj = new LogTickets();
            try
            {
                try
                {
                    obj = objLogApplication.LogTicketsVolaris(ticketNumber, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    obj = objLogApplication.LogTicketsVolaris(ticketNumber, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return obj;
        }

        public static void LogTicketsInterjetUpdate(string pnrAirline, string pnrSabre)
        {
            LogTicketsDAL objLogApplication = new LogTicketsDAL();
            try
            {
                try
                {
                    objLogApplication.LogTicketsInterjetUpdate(pnrAirline, pnrSabre, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objLogApplication.LogTicketsInterjetUpdate(pnrAirline, pnrSabre, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
        }

        public static void LogTicketsVolarisUpdate(string pnrAirline, string pnrSabre)
        {
            LogTicketsDAL objLogApplication = new LogTicketsDAL();
            try
            {
                try
                {
                    objLogApplication.LogTicketsVolarisUpdate(pnrAirline, pnrSabre, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objLogApplication.LogTicketsVolarisUpdate(pnrAirline, pnrSabre, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
        }

        public static void LogTicketsInterjetInsert(string ticketNumber, DateTime date, string pnrAirline, string pnrSabre)
        {
            LogTicketsDAL objLogApplication = new LogTicketsDAL();
            try
            {
                try
                {
                   objLogApplication.LogTicketsInterjetInsert(ticketNumber, date,pnrAirline,pnrSabre, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objLogApplication.LogTicketsInterjetInsert(ticketNumber, date, pnrAirline, pnrSabre, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
        }

        public static void LogTicketsVolarisInsert(string ticketNumber, DateTime date, string pnrAirline, string pnrSabre)
        {
            LogTicketsDAL objLogApplication = new LogTicketsDAL();
            try
            {
                try
                {
                    objLogApplication.LogTicketsVolarisInsert(ticketNumber, date, pnrAirline, pnrSabre, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objLogApplication.LogTicketsVolarisInsert(ticketNumber, date, pnrAirline, pnrSabre, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
        }

        public static double RandomVolaris()
        {
            LogTicketsDAL objLogApplication = new LogTicketsDAL();
            double numberTicket = 0;
            try
            {
                numberTicket = 0;
                try
                {
                   numberTicket= objLogApplication.RandomVolaris(CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                   numberTicket= objLogApplication.RandomVolaris(CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return numberTicket;
        }
    }
}
