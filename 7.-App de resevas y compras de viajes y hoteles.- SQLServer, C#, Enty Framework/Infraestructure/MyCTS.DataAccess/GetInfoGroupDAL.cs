using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.IO;
using System.Data;
using System.Data.Common;
using MyCTS.Entities;
using MyCTS.Components.NullableHelper;

namespace MyCTS.DataAccess
{
    public class GetInfoGroupDAL
    {
        public List<GetInfoGroup> GetInfoGroupIndex(string pnr, int OrgId, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetInfoGroupResources.SP_GETINFOGROUP);
            db.AddInParameter(dbCommand, Resources.GetInfoGroupResources.PARAM_QUERY1, DbType.String, pnr);
            db.AddInParameter(dbCommand, Resources.GetInfoGroupResources.PARAM_ORG_ID, DbType.Int32, OrgId);

            List<GetInfoGroup> getInfoGroupList = new List<GetInfoGroup>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _recLoc = dr.GetOrdinal(Resources.GetInfoGroupResources.PARAM_RECLOC);
                int _origin = dr.GetOrdinal(Resources.GetInfoGroupResources.PARAM_ORIGIN);
                int _destination = dr.GetOrdinal(Resources.GetInfoGroupResources.PARAM_DESTINATION);
                int _departureTime = dr.GetOrdinal(Resources.GetInfoGroupResources.PARAM_DEPARTURETIME);
                int _arrivalTime = dr.GetOrdinal(Resources.GetInfoGroupResources.PARAM_ARRIVALTIME);
                int _airlineCode = dr.GetOrdinal(Resources.GetInfoGroupResources.PARAM_AIRLINECODE);
                int _airlineRef = dr.GetOrdinal(Resources.GetInfoGroupResources.PARAM_AIRLINEREF);
                int _flightNumber = dr.GetOrdinal(Resources.GetInfoGroupResources.PARAM_FLIGHTNUMBER);
                int _departureDate = dr.GetOrdinal(Resources.GetInfoGroupResources.PARAM_DEPARTUDATE);
                int _paxName = dr.GetOrdinal(Resources.GetInfoGroupResources.PARAM_PAXNAME);
                int _paxLastName = dr.GetOrdinal(Resources.GetInfoGroupResources.PARAM_PAXLASTNAME);
                int _paxNumber = dr.GetOrdinal(Resources.GetInfoGroupResources.PARAM_PAXNUMBER);
                int _masterPNR = dr.GetOrdinal(Resources.GetInfoGroupResources.PARAM_MASTERPNR);
                int _idGroup = dr.GetOrdinal(Resources.GetInfoGroupResources.PARAM_IDGROUP);

                while (dr.Read())
                {
                    GetInfoGroup item = new GetInfoGroup();
                    item.RecLoc = dr.GetString(_recLoc);
                    item.Origin = dr.GetString(_origin);
                    item.Destination = dr.GetString(_destination);
                    item.DepartureTime = dr.GetString(_departureTime);
                    item.ArrivalTime = dr.GetString(_arrivalTime);
                    item.AirlineCode = dr.GetString(_airlineCode);
                    item.AirlineRef = (dr[_airlineRef] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_airlineRef);
                    item.FlightNumber = dr.GetString(_flightNumber);
                    item.DepartureDate = dr.GetDateTime(_departureDate);
                    item.PaxName = dr.GetString(_paxName);
                    item.PaxLastName = dr.GetString(_paxLastName);
                    item.PaxNumber = dr.GetDecimal(_paxNumber);
                    item.MasterPNR = dr.GetString(_masterPNR);
                    item.IDGroup = dr.GetString(_idGroup);
                    getInfoGroupList.Add(item);
                }
                return getInfoGroupList;
            }
        }
    }
}