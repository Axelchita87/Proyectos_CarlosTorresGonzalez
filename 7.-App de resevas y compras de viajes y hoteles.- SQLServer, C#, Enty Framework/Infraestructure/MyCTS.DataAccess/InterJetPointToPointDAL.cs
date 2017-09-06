using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace MyCTS.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetPointToPointDAL
    {



        public static bool IsInterJetRoute(string departure, string destination)
        {
            if (IsDirectFlight(departure, destination))
            {
                return true;
            }
            else
            {
                var destinations = GetDestination(departure);

                if (destinations.Any())
                {
                    return destinations.Any(dest => PointsV2.Any(p => p.From.Equals(dest) && p.To.Equals(destination)));
                }

                return false;
            }


        }


        /// <summary>
        /// 
        /// </summary>
        private static List<InterJetPointToPoint> _points;

        /// <summary>
        /// Gets the points.
        /// </summary>
        private static List<InterJetPointToPoint> Points
        {
            get { return _points ?? (_points = GetPointToPointFlights()); }
        }

        /// <summary>
        /// 
        /// </summary>
        private static List<InterJetPointToPoint> _pointsV2;

        /// <summary>
        /// Gets the points.
        /// </summary>
        private static IEnumerable<InterJetPointToPoint> PointsV2
        {
            get { return _pointsV2 ?? (_pointsV2 = GetPointToPointFlightsV2()); }
        }

        /// <summary>
        /// Gets the point to point destinations.
        /// </summary>
        /// <returns></returns>
        public List<InterJetPointToPoint> GetPointToPointDestinations()
        {
            return Points;
        }



        public static bool IsDirectFlight(string departure, string destination)
        {

            return PointsV2.Any(p => p.From.Equals(departure) && p.To.Equals(destination));
        }

        public static IEnumerable<string> GetDestination(string departure)
        {

            return PointsV2.Where(p => p.From.Equals(departure)).Select(p => p.To).ToList();
        }
        public static bool IsInternational(string departure, string destination)
        {
            var result = PointsV2.FirstOrDefault(p => p.From.Equals(departure) && p.To.Equals(destination));
            if (result != null)
            {
                return result.IsInternational;
            }
            return false;
        }

        private static List<InterJetPointToPoint> GetPointToPointFlightsV2()
        {
            try
            {
                Database dataBase = DatabaseFactory.CreateDatabase(CommonENT.MYCTSDB_CONNECTION);
                DbCommand dataBaseCommand = dataBase.GetStoredProcCommand("GetInterJetPointToPointConnectionsV2");
                var points = new List<InterJetPointToPoint>();

                using (IDataReader dataReader = dataBase.ExecuteReader(dataBaseCommand))
                {
                    int id = dataReader.GetOrdinal("ID");
                    int pointTo = dataReader.GetOrdinal("To");
                    int pointFrom = dataReader.GetOrdinal("From");
                    int isInternational = dataReader.GetOrdinal("IsInternational");
                    while (dataReader.Read())
                    {
                        var point = new InterJetPointToPoint();
                        point.ID = dataReader.GetInt32(id);
                        point.To = dataReader.GetString(pointTo);
                        point.From = dataReader.GetString(pointFrom);
                        point.IsInternational = dataReader.GetBoolean(isInternational);
                        points.Add(point);

                    }

                }
                return points;
            }
            catch (Exception ex)
            {
                return new List<InterJetPointToPoint>();
            }



        }
        /// <summary>
        /// Gets the point to point flights.
        /// </summary>
        /// <returns></returns>
        private static List<InterJetPointToPoint> GetPointToPointFlights()
        {
            try
            {
                Database dataBase = DatabaseFactory.CreateDatabase(CommonENT.MYCTSDB_CONNECTION);
                DbCommand dataBaseCommand = dataBase.GetStoredProcCommand("GetInterJetPointToPointConnections");
                var points = new List<InterJetPointToPoint>();

                using (IDataReader dataReader = dataBase.ExecuteReader(dataBaseCommand))
                {
                    int id = dataReader.GetOrdinal("ID");
                    int pointTo = dataReader.GetOrdinal("PointTo");
                    int pointFrom = dataReader.GetOrdinal("PointFrom");

                    while (dataReader.Read())
                    {
                        var point = new InterJetPointToPoint();
                        point.ID = dataReader.GetInt32(id);
                        point.To = dataReader.GetString(pointTo);
                        point.From = dataReader.GetString(pointFrom);
                        points.Add(point);

                    }

                }
                return points;
            }
            catch (Exception ex)
            {
                return null;
            }



        }
    }
}
