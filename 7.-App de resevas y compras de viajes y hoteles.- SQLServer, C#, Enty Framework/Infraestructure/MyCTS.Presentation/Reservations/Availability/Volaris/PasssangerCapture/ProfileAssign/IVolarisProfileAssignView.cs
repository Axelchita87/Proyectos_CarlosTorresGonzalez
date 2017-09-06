using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture.ProfileAssign
{
    public interface IVolarisProfileAssignView : IBaseView
    {
        VolarisProfile Profile { get; set; }
        bool HasProfile { get; }
        string FristLevelProfile { get; set; }
        string SeconLevelProfile { get; set; }
        List<VolarisAdultPassanger> PassangerList { get; set; }

    }
}
