using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public enum VolarisReservationStatus
    {

        Accepted, //Cuando ya se ha aceptado y apartado el lugar dentro del host de volaris.
        NotAccepted,
        Invoiced,
        None // Cuando la reserva esta recien creada pero aun no ha sido aceptada por el host.
    }
}
