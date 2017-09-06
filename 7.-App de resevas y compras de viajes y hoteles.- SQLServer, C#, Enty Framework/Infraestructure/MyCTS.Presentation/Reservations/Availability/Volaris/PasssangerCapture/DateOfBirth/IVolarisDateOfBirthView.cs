using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture.DateOfBirth
{
    public interface IVolarisDateOfBirthView : IBaseView
    {
        DateTime BirthDay { get; set; }
        bool CheckForInfantBirthDay { get; set; }
        void SetMonths(string[] months);
        void SetDays(string[] days);
        void SetYears(string[] years);
    }
}
