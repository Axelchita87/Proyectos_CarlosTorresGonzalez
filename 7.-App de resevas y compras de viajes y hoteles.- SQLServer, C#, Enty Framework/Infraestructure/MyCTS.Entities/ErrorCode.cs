using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public enum ErrorCode
    {

        #region Codigo de Errores de la disponibilidad

        TooMannyPassangers = 1,
        NoPassangers = 2,
        TooManyInfants = 3,
        DepartureDateIsLessThanToday = 4,
        ReturningDateIsBiggerThanReturningDate = 5,
        IsRoundTripAndNoReturningDate = 6,
        NoDepartureStation = 7,
        NoArrivalStation = 8,
        IncorrecDepartureStation = 9,
        IncorrectArrivalStation =10,
        SameDepartureAndArrivalStation =11,
        #endregion
        #region Codigo de Errores

        NoSelectedFlight = 7



        #endregion
    }
}
