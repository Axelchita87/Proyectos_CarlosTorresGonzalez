using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class CatInterJetStateBL
    {
        private CatInterJetStateDAL _dataAcces;

        private CatInterJetStateDAL DataAcces
        {
            get{

                if(_dataAcces == null)
                {
                    _dataAcces = new CatInterJetStateDAL();
                }
                return _dataAcces;
            }
        }

        public List<InterJetState> GeStates()
        {
            return DataAcces.GetStates();
        }
    }
}
