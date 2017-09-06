using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using MyCTS.Presentation.Base;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PasssangerCapture.PassangerCaptureForm
{
    public class VolarisPassangerCaptureFormPresenter : IBasePresenter<IVolarisPassangerCaptureFormView, VolarisPassangerCaptureFormRepository>
    {
        #region Miembros de IBasePresenter<IVolarisPassangerCaptureFormView,VolarisPassangerCaptureFormRepository>

        public IVolarisPassangerCaptureFormView View { get; set; }

        public VolarisPassangerCaptureFormRepository Repository { get; set; }

        public void InitializeView()
        {

        }

        public bool HasProfile { get; set; }
        public void SetProfile(VolarisProfile profile)
        {
            if (profile != null)
            {
                View.PaxName = profile.Name;
                View.LastName = profile.LastName;
                View.DateOfBirth = profile.BirthDay;

                HasProfile = true;
            }
        }

        public void RemoveProfile()
        {
            HasProfile = false;
            View.PaxName = string.Empty;
            View.LastName = string.Empty;
            View.DateOfBirth = DateTime.Now;

        }


        public void SetPassanger()
        {
            View.Header = _internalPassanger.ToString();
            if (_internalPassanger.HasValue)
            {

            }
            if (_internalPassanger is VolarisAdultPassanger)
            {
                _internalPassanger = _internalPassanger as VolarisAdultPassanger;
                View.SetAdultView();
            }

            if (_internalPassanger is VolarisChildPassanger)
            {
                _internalPassanger = _internalPassanger as VolarisChildPassanger;
                View.SetChildView();
            }
            if (_internalPassanger is VolarisInfantPassanger)
            {
                _internalPassanger = _internalPassanger as VolarisInfantPassanger;
                View.SetInfantView();
                View.ShowInfantsPanel = true;
            }
        }
        private IVolarisPassanger _internalPassanger;
        /// <summary>
        /// Sets the passanger.
        /// </summary>
        /// <param name="passanger">The passanger.</param>
        public void SetPassanger(IVolarisPassanger passanger)
        {

            _internalPassanger = passanger;
            if (passanger is VolarisInfantPassanger)
            {
                IsInfant = true;
               
            }
        }

        public bool IsInfant { get; set; }

        /// <summary>
        /// Gets the passanger.
        /// </summary>
        /// <returns></returns>
        public IVolarisPassanger GetPassanger()
        {

            _internalPassanger.Name = View.PaxName;
            _internalPassanger.DateOfBirth = View.DateOfBirth;
            _internalPassanger.LastName = View.LastName;
            _internalPassanger.Gender = View.Gender;
            _internalPassanger.Title = View.Title;
            _internalPassanger.SpecialServices.Add(View.SpecialService);           
            _internalPassanger.SpecialServices.Add(new VolarisPassangerSpecialService
                                                       {
                                                           Type = VolarisSepecialServiceType.SecureFlight
                                                       });
            
            if (IsInfant)
            {
                var infant = (VolarisInfantPassanger)_internalPassanger;
                infant.AssignedPassanger = (VolarisAdultPassanger)View.TravelWithPassanger;
                infant.AssignedPassanger.AssignedInfat = infant;
                _internalPassanger.SpecialServices.Add(new VolarisPassangerSpecialService
                                                           {
                                                               Type = VolarisSepecialServiceType.Infant
                                                           });
                return infant;
            }


            return _internalPassanger;
        }

        /// <summary>
        /// Gets the pax.
        /// </summary>
        /// <returns></returns>

        public void UpdateView(object modelObject)
        {
        }

        #endregion
    }
}
