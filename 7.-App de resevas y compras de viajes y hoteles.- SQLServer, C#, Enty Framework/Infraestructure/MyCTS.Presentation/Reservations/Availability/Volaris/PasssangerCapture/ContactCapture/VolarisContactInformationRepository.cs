using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Presentation.Base;
using MyCTS.Business;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture.ContactCapture
{
    public class VolarisContactInformationRepository : IBaseRepository
    {
        #region Miembros de IBaseRepository

        public void Initialize()
        {

        }

        public List<VolarisContactEmail> GetConfiguredEmails()
        {
            var configuredEmailParameter = ParameterBL.GetParameterValue("VolarisConfiguredEmail");
            var emails = new List<VolarisContactEmail>();
            if (configuredEmailParameter != null && !string.IsNullOrEmpty(configuredEmailParameter.Values))
            {
                var emailsStrings = configuredEmailParameter.Values.Split('|');
                foreach (var emailString in emailsStrings)
                {
                    if (!string.IsNullOrEmpty(emailString))
                    {
                        var email = new VolarisContactEmail()
                                        {
                                            Email = emailString
                                        };
                        emails.Add(email);
                    }

                }
            }
            return emails;
        }

        /// <summary>
        /// Gets the configure telephones.
        /// </summary>
        /// <returns></returns>
        public List<VolarisContactTelephone> GetConfigureTelephones()
        {
            var configuredTelephoneParameter = ParameterBL.GetParameterValue("VolarisConfiguredTelephones");
            var telephones = new List<VolarisContactTelephone>();
            if (configuredTelephoneParameter != null && !string.IsNullOrEmpty(configuredTelephoneParameter.Values))
            {
                var phonesStrings = configuredTelephoneParameter.Values.Split('|');
                foreach (var phoneString in phonesStrings)
                {
                    if (!string.IsNullOrEmpty(phoneString))
                    {
                        var phone = phoneString.Split('-');
                        if (phone.Length == 2)
                        {
                            var email = new VolarisContactTelephone()
                                            {
                                                TelephoneCityCode = phone[0],
                                                Telephone = phone[1]
                                            };
                            telephones.Add(email);
                        }
                    }

                }
            }
            return telephones;

        }
        #endregion
    }
}
