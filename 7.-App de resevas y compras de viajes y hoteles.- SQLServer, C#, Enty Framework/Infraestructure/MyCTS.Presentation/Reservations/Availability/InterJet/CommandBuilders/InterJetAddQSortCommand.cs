using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.CommandBuilders
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetAddQSortCommand: InterJetCommandBuilder
    {
        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns></returns>
        public override string Build()
        {
            string ApiResponseFromAPI = this.Comunicator.SendCommand(GetSabreCommand());
            return ApiResponseFromAPI;
        }


        public string GetSabreCommand()
        {

            return string.Format("QSORT/-{0}", Login.Queue);
        }
    }
}
