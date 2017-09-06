using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Components.NullableHelper;
using MyCTS.DataAccess.Resources;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace MyCTS.DataAccess
{
    public class LogTicketsDAL
    {
        public LogTickets LogTicketsInterjet(string ticketNumber, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.LogTicketsResources.SP_GetLogTicketsInterjet);
            db.AddInParameter(dbCommand, Resources.LogTicketsResources.PARAM_TicketNumber, DbType.String, ticketNumber);
            LogTickets item = new LogTickets();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    int _ticketNumber = dr.GetOrdinal(Resources.LogTicketsResources.PARAM_GetTicketNumber);
                    item.TicketNumber = (dr[_ticketNumber] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_ticketNumber);
                }
            }
            return item;
        }

        public LogTickets LogTicketsVolaris(string ticketNumber, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.LogTicketsResources.SP_GetLogTicketsVolaris);
            db.AddInParameter(dbCommand, Resources.LogTicketsResources.PARAM_TicketNumber, DbType.String, ticketNumber);
            LogTickets item = new LogTickets();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    int _ticketNumber = dr.GetOrdinal(Resources.LogTicketsResources.PARAM_GetTicketNumber);
                    item.TicketNumber = (dr[_ticketNumber] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_ticketNumber);
                }
            }
            return item;
        }

        public void LogTicketsInterjetUpdate(string pnrAirline, string pnrSabre, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.LogTicketsResources.SP_UpdateLogTicketsInterjet);
            db.AddInParameter(dbCommand, Resources.LogTicketsResources.PARAM_PNRAirLine, DbType.String, pnrAirline);
            db.AddInParameter(dbCommand, Resources.LogTicketsResources.PARAM_PNRSabre, DbType.String, pnrSabre);
            db.ExecuteReader(dbCommand);
        }

        public void LogTicketsVolarisUpdate(string pnrAirline, string pnrSabre, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.LogTicketsResources.SP_UpdateLogTicketsVolaris);
            db.AddInParameter(dbCommand, Resources.LogTicketsResources.PARAM_PNRAirLine, DbType.String, pnrAirline);
            db.AddInParameter(dbCommand, Resources.LogTicketsResources.PARAM_PNRSabre, DbType.String, pnrSabre);
            db.ExecuteReader(dbCommand);
        }

        public void LogTicketsInterjetInsert(string ticketNumber, DateTime  date,string pnrAirline, string pnrSabre, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.LogTicketsResources.SP_InsertLogTicketsInterjet);
            db.AddInParameter(dbCommand, Resources.LogTicketsResources.PARAM_TicketNumber, DbType.String, ticketNumber);
            db.AddInParameter(dbCommand, Resources.LogTicketsResources.PARAM_PNRAirLine, DbType.String, pnrAirline);
            db.AddInParameter(dbCommand, Resources.LogTicketsResources.PARAM_PNRSabre, DbType.String, pnrSabre);
            db.ExecuteReader(dbCommand);
        }

        public void LogTicketsVolarisInsert(string ticketNumber, DateTime date, string pnrAirline, string pnrSabre, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.LogTicketsResources.SP_InsertLogTicketsVolaris);
            db.AddInParameter(dbCommand, Resources.LogTicketsResources.PARAM_TicketNumber, DbType.String, ticketNumber);
            db.AddInParameter(dbCommand, Resources.LogTicketsResources.PARAM_PNRAirLine, DbType.String, pnrAirline);
            db.AddInParameter(dbCommand, Resources.LogTicketsResources.PARAM_PNRSabre, DbType.String, pnrSabre);
            db.ExecuteReader(dbCommand);
        }

        public double RandomVolaris(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.LogTicketsResources.SP_GETRANDOM);
            GetRandomVolaris rand = new GetRandomVolaris();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    int _random = dr.GetOrdinal(Resources.LogTicketsResources.PARAM_RANDOM);
                    rand.RandomVolaris = (dr[_random] == DBNull.Value) ? Types.DoubleNullValue : dr.GetDouble(_random);
                }
            }
            return rand.RandomVolaris;
        }
    }
}
