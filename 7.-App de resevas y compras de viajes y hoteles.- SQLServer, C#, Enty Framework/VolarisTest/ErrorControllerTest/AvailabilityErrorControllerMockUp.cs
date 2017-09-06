using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Presentation.Base;
using MyCTS.Presentation.Reservations.Availability;
using NUnit.Framework;
using VolarisTest.ViewTest;

namespace VolarisTest.ErrorControllerTest
{

    public class AvailabilityErrorControllerMockUp : ErrorController
    {

        public AvailabilityErrorControllerMockUp()
        {

            this.RegisterErrorWithControl(ErrorCode.TooMannyPassangers, new Control());
            this.RegisterErrorWithControl(ErrorCode.TooManyInfants, new Control());
            this.RegisterErrorWithControl(ErrorCode.NoPassangers, new Control());
            this.RegisterErrorWithControl(ErrorCode.DepartureDateIsLessThanToday, new Control());
            this.RegisterErrorWithControl(ErrorCode.ReturningDateIsBiggerThanReturningDate, new Control());
            this.RegisterErrorWithControl(ErrorCode.IsRoundTripAndNoReturningDate, new Control());
        }
    }


}
