using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Presentation.Reservations.Availability.LowFareAvailability.Helpers
{
    public class LowFareAvailabilitProcessListener
    {

        private readonly object _lockedObjet = new object();

        private int _runningProcess = 0;

        public void Increment()
        {
            lock (_lockedObjet)
            {
                _runningProcess += 1;
            }
        }

        public void Decrement()
        {
            lock (_lockedObjet)
            {
                _runningProcess -= 1;
            }
        }


        public bool HasRuningProcess
        {

            get
            {
                lock (_lockedObjet)
                {
                    return _runningProcess == 0;
                }

            }
        }
    }
}
