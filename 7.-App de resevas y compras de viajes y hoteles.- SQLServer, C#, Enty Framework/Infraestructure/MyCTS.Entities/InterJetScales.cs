using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class InterJetScales
    {
        /// <summary>
        /// 
        /// </summary>
        private List<InterJetFlight> _scales = new List<InterJetFlight>();
        /// <summary>
        /// 
        /// </summary>
        private List<InterJetFlight> Scales
        {
            get
            {
                return this._scales;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="scale"></param>
        public void AddScale(InterJetFlight scale)
        {

            this.Scales.Add(scale);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<InterJetFlight> GetScales()
        {
            return this.Scales;
        }



    }
}
