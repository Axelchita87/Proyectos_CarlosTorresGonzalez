using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Presentation.Base;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture.ContactCapture
{
    public class VolarisContactInformationPresenter : IBasePresenter<VolarisContactInformationView, VolarisContactInformationRepository>
    {
        #region Miembros de IBasePresenter<VolarisContactInformationView,VolarisContactInformationRepository>

        public VolarisContactInformationView View { get; set; }

        public VolarisContactInformationRepository Repository { get; set; }

        public void InitializeView()
        {

        }

        public void UpdateView(object modelObject)
        {

        }


        /// <summary>
        /// Gets the contact.
        /// </summary>
        /// <returns></returns>
        public VolarisContact GetContact()
        {
            var contact = new VolarisContact();

            var userEmail = new VolarisContactEmail()
                                {
                                    Email = View.Email,
                                    Type = VolarisEmailType.Primary
                                };
            contact.Emails.Add(userEmail);
            //Ingreso de codigo de IATA
            var iataCode = new VolarisContactTelephone()
            {
                Telephone = "86513711"
            };
            contact.Phones.Add(iataCode);

            var userPhone = new VolarisContactTelephone()
                                {
                                    TelephoneCityCode = View.TelePhoneLada,
                                    Telephone = View.TelePhone,
                                    Type = VolarisPhoneType.Primary
                                };
            contact.Phones.Add(userPhone);

            if (!string.IsNullOrEmpty(View.CellPhoneLada) && !string.IsNullOrEmpty(View.CellPhone))
            {
                var userCellPhone = new VolarisContactTelephone()
                {
                    TelephoneCityCode = View.CellPhoneLada,
                    Telephone = View.CellPhone,                    
                };
                contact.Phones.Add(userCellPhone);
            }            
            contact.Emails.Add(Repository.GetConfiguredEmails());
            contact.Phones.Add(Repository.GetConfigureTelephones());
            return contact;
        }

        #endregion
    }
}
