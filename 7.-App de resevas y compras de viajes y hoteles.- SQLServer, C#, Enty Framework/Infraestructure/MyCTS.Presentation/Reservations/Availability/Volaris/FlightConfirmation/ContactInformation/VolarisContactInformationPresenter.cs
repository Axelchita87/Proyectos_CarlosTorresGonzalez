using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Presentation.Base;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.FlightConfirmation.ContactInformation
{
    public class VolarisContactInformationPresenter : IBasePresenter<IVolarisContactInformationView,VolarisContactInformationRepository>
    {
        #region Miembros de IBasePresenter<IVolarisContactInformationView,VolarisContactInformationRepository>

        public IVolarisContactInformationView View { get; set; }

        public VolarisContactInformationRepository Repository { get; set; }

        public void InitializeView()
        {
            
        }

        public void SetContanct( VolarisContact contact)
        {
            Contact = contact;
        }
        public VolarisContact GetContact()
        {
            return Contact;
        }

        private VolarisContact Contact { get; set; }
        public void UpdateView(object modelObject)
        {
            
        }
        public string GetPrimaryEmail()
        {

            if (Contact != null && Contact.Emails.GetAll().Any())
            {
                var email = Contact.Emails.GetAll().FirstOrDefault(e => e.Type == VolarisEmailType.Primary);
                if (email != null)
                {
                    return email.Email;
                }
            }
            return string.Empty;
        }

        public string GetPrimaryPhone()
        {
            if (Contact != null && Contact.Phones.GetAll().Any())
            {
                var phone = Contact.Phones.GetAll().FirstOrDefault(p => p.Type == VolarisPhoneType.Primary);
                if (phone != null)
                {
                    return phone.FullNumber;
                }
            }
            return string.Empty;
        }
        #endregion
    }
}
