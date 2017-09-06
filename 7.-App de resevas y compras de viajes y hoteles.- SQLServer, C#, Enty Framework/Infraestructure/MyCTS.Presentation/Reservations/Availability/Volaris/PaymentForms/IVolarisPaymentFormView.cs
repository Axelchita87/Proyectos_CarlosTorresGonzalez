using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Presentation.Base;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PaymentForms
{
    public interface IVolarisPaymentFormView : IBaseView
    {
        VolarisReservation Reservation { get; set; }
 

    }
}
