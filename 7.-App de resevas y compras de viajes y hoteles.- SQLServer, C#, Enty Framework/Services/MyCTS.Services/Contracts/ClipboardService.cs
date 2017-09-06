using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Services.ClipboardService;

namespace MyCTS.Services.Contracts
{
    public class ClipboardService
    {
        public Schedule CopyReport(string departure, string arrival, DateTime departureDate, bool showFlightsIndirect, bool showShareCode, bool showScheduleWeekly, bool showAircraftType, bool isExcludeFlights, string startHour, string finalHour, List<string> airlines)
        {
            ClipboardServiceClient client = new ClipboardServiceClient();
            Schedule schedule = new Schedule();
            try
            {
                client.Open();
                schedule = client.GetScheduleReportClipboard(departure, arrival, departureDate, showFlightsIndirect, showShareCode, showScheduleWeekly, showAircraftType, isExcludeFlights, startHour, finalHour, airlines);
            }
            catch
            {
            }
            finally
            {
                if (client.State != System.ServiceModel.CommunicationState.Closed)
                {
                    client.Close();
                }
            }
            return schedule;
        }

        public File CopyReport(Schedule schedule)
        {
            ClipboardServiceClient client = new ClipboardServiceClient();
            File file = new File();
            try
            {
                client.Open();
                file = client.GetScheduleReportClipboardFormated(schedule);
            }
            catch
            {
            }
            finally
            {
                if (client.State != System.ServiceModel.CommunicationState.Closed)
                {
                    client.Close();
                }
            }
            return file;
        }

        public File CopyReport(Itinerary itinerary)
        {
            ClipboardServiceClient client = new ClipboardServiceClient();
            File file = new File();
            try
            {
                client.Open();
                file = client.GetItineraryReportClipboardByItinerary(itinerary);
            }
            catch
            {
            }
            finally
            {
                if (client.State != System.ServiceModel.CommunicationState.Closed)
                {
                    client.Close();
                }
            }
            return file;
        }

        public Itinerary CopyReport(string PNR)
        {
            ClipboardServiceClient client = new ClipboardServiceClient();
            Itinerary itinerary = new Itinerary();
            try
            {
                client.Open();
                itinerary = client.GetItineraryReportClipboardByPNR(PNR);
            }
            finally
            {
                if (client.State != System.ServiceModel.CommunicationState.Closed)
                {
                    client.Close();
                }
            }
            return itinerary;
        }

        public Search CopyReport(string securityToken, string command)
        {
            ClipboardServiceClient client = new ClipboardServiceClient();
            Search search = new Search();
            try
            {
                client.Open();
                search = client.GetSearchReportClipboard(securityToken, command);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (client.State != System.ServiceModel.CommunicationState.Closed)
                {
                    client.Close();
                }
            }

            return search;
        }

        public Itinerary CopyReportModified(string securityToken)
        {
            ClipboardServiceClient client = new ClipboardServiceClient();
            Itinerary itinerary = new Itinerary();
            try
            {
                client.Open();
                itinerary = client.GetItineraryModifiedReportClipboard(securityToken);
            }
            finally
            {
                if (client.State != System.ServiceModel.CommunicationState.Closed)
                {
                    client.Close();
                }
            }
            return itinerary;
        }
    }
}
