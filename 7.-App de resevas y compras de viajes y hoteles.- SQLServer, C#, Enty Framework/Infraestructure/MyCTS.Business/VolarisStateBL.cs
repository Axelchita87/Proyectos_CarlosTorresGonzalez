using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class VolarisStateBL
    {
       private VolarisStateDAL _dataAccess;

        private VolarisStateDAL DataAccess
        {
            get { return _dataAccess ?? (_dataAccess = new VolarisStateDAL()); }
        }

        public List<VolarisState> GetStateByContry(string countryId)
        {
            return DataAccess.GetStatesByCountry(countryId);
        }

        public static List<VolarisState> GetAllState()
        {
            List<VolarisState> StatesList = new List<VolarisState>();
            VolarisStateDAL objStates = new VolarisStateDAL();
            try
            {
                StatesList = objStates.GetAllState(CommonENT.MYCTSDB_CONNECTION);
            }
            catch (Exception ex)
            {
                new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                StatesList = objStates.GetAllState(CommonENT.MYCTSDBBACKUP_CONNECTION);
            }
            return StatesList;
        }

        public static List<ListItem> GetAllStatePredictive(string strToSearch)
        {
            List<ListItem> StatesList = new List<ListItem>();
            VolarisStateDAL objStates = new VolarisStateDAL();
            try
            {
                StatesList = objStates.GetAllStatePredictive(strToSearch,CommonENT.MYCTSDB_CONNECTION);
            }
            catch (Exception ex)
            {
                new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                StatesList = objStates.GetAllStatePredictive(strToSearch, CommonENT.MYCTSDBBACKUP_CONNECTION);
            }
            return StatesList;
        }
    }
}
