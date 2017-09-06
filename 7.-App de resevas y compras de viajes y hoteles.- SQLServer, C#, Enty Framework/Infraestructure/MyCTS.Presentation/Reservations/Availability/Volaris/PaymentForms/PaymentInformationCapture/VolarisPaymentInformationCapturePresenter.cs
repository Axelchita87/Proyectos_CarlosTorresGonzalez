using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PaymentForms.PaymentInformationCapture
{
    public class VolarisPaymentInformationCapturePresenter : IBasePresenter<IVolarisPaymentInformationCaptureView, VolarisPaymentInformationRepository>
    {


        public IVolarisPaymentInformationCaptureView View { get; set; }

        public VolarisPaymentInformationRepository Repository { get; set; }

        public void InitializeView()
        {

        }

        public void UpdateView(object modelObject)
        {

        }

    }
}
