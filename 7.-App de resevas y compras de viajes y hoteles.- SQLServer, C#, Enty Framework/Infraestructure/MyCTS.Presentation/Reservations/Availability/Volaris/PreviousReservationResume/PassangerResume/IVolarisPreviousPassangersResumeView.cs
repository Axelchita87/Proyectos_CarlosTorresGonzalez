using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PreviousReservationResume.PassangerResume
{
    public interface IVolarisPreviousPassangersResumeView : IBaseView
    {

        void SetPassanger(VolarisPassangers passangers, bool paxWithNames);
        void SetAdultPassanger(int passangerCount);
        void SetChildPassanger(int passangerCount);
        void SetInfantPassanger(int passangerCount);



    }
}
