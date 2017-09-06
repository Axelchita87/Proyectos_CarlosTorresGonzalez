using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{
    public class InterJetSession
    {
        /// <summary>
        /// 
        /// </summary>
        private  Hashtable _session;
        /// <summary>
        /// 
        /// </summary>
        public  Hashtable Session
        {
            get { 
                if(_session == null)
                {
                    _session = new Hashtable();
                }
                return _session;
            
            }
        }

        public void Destroy()
        {
            this._session.Clear();
            this._session = null;
        }
           
     


    }
}
