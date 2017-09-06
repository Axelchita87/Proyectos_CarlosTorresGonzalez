using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class AgentPCCBL
    {
        public static AgentPCC GetAgentPCC(string Agent)
        {
            AgentPCC item = new AgentPCC();
            AgentPCCDAL objAgents = new AgentPCCDAL();
            try
            {
                try
                {
                    item = objAgents.GetAgentPCC(Agent, CommonENT.MYCTSDBPRODUCTIVITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    item = objAgents.GetAgentPCC(Agent, CommonENT.MYCTSDBPRODUCTIVITYBACKUP_CONNECTION);
                }

            }
            catch
            { }
            return item;

        }

    }
}
