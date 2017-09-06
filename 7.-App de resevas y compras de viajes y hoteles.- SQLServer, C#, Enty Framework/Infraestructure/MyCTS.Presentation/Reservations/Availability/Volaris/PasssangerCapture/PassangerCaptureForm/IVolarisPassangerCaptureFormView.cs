using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;
using System;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture.PassangerCaptureForm
{
    public interface IVolarisPassangerCaptureFormView : IBaseView
    {
        IVolarisPassanger Passanger { get; set; }
        void SetProfile(VolarisProfile profile);
        void RemoveProfile();
        void SetInfantView();
        void SetAdultView();
        void SetChildView();
        string Header { get; set; }
        bool ShowInfantsPanel { get; set; }
        void SetListOfPassangersNumber(List<VolarisAdultPassanger> passangersNumber);
        VolarisPassangerTitleType Title { get; set; }
        VolarisPassangerGenderType Gender { get; set; }
        string PaxName { get; set; }
        string LastName { get; set; }
        DateTime DateOfBirth { get; set; }
        IVolarisPassanger TravelWithPassanger { get; set; }
        VolarisPassangerSpecialService SpecialService { get; set; }
    }
}
