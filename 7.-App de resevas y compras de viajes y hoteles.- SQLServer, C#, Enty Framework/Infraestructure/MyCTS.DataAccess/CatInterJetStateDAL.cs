using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.IO;
using System.Data;
using System.Data.Common;
using MyCTS.Entities;
using System.Linq;
using MyCTS.Components.NullableHelper;

namespace MyCTS.DataAccess
{
    public class CatInterJetStateDAL
    {

        public List<InterJetState> GetStates()
        {
            try
            {
                Database dataBase = DatabaseFactory.CreateDatabase(CommonENT.MYCTSDB_CONNECTION);
                DbCommand dbComand = dataBase.GetStoredProcCommand("GetInterJetState");
                List<InterJetState> states = new List<InterJetState>();
                using (IDataReader dataReader = dataBase.ExecuteReader(dbComand))
                {

                    int ID = dataReader.GetOrdinal("ID");
                    int Name = dataReader.GetOrdinal("Name");

                    while (dataReader.Read())
                    {
                        InterJetState state = new InterJetState();
                        state.ID = dataReader.GetString(ID);
                        state.Name = dataReader.GetString(Name).ToUpper();
                        states.Add(state);
                    }

                }

                CatStatesUSADAL dataAccesUsaState = new CatStatesUSADAL();
                List<CatStatesUSA> statesOfUsa = dataAccesUsaState.GetStateUSA();

                List<InterJetState> usaStates = (from state in statesOfUsa
                                                 select
                                                 new InterJetState
                                                 {
                                                     ID = state.CatStaUSACode,
                                                     Name = state.CatStaUSAName
                                                 }
                                                  ).ToList();
                states.AddRange(usaStates);
                return states.OrderBy(s => s.Name).ToList();
            }
            catch (Exception ex)
            {
                return new List<InterJetState>();
            }
        }
    }
}
