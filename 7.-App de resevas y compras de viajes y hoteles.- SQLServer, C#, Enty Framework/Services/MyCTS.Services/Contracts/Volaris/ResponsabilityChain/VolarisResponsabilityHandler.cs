using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Services.Contracts.Volaris.EventArguments;

namespace MyCTS.Services.Contracts.Volaris.ResponsabilityChain
{
    public abstract class VolarisResponsabilityHandler
    {

        public string MessageToSend { get; set; }
        private VolarisResponsabilityHandler _succesor;
        public void SetSuccesor(VolarisResponsabilityHandler succesor)
        {
            if (succesor == null)
            {
                throw new ArgumentException("El succesor no puede estar nulo");
            }
            _succesor = succesor;
        }
        public  VolarisResponsabilityHandler Succesor
        {
            get { return _succesor; }
        }

        public EventHandler<OnWebServiceCallStartEventArg> OnWebServiceCallStart { get; set; }
        public EventHandler<OnWebServiceCallCompletedEventArg> OnWebServiceCallCompleted { get; set; }


        public abstract void Execute(VolarisReservation reservation, string securityToken);
        /// <summary>
        /// Services the call success.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="messageToSend">The message to send.</param>
        /// <returns></returns>
        public bool ServiceCallSuccess(ISabreService service, string messageToSend)
        {
            if (OnWebServiceCallStart != null)
            {
                OnWebServiceCallStart(null, new OnWebServiceCallStartEventArg
                {
                    Message = messageToSend
                });
            }
            service.Call();
            if (!service.Success)
            {

                if (OnWebServiceCallCompleted != null)
                {
                    OnWebServiceCallCompleted(null, new OnWebServiceCallCompletedEventArg
                    {
                        ErrorMessage = service.ErrorMessage,
                        Success = service.Success
                    });
                }

            }

            return service.Success;
        }

        public void IgnoreAndCloseSession(string securityToken)
        {
            ServiceCallSuccess(new IgnoreTransaction() { SecurityToken = securityToken }, "");
            ServiceCallSuccess(new CloseSessionService() { SecurityToken = securityToken }, "");
        }

        public void CloseSession(string securityToken)
        {

            ServiceCallSuccess(new CloseSessionService() { SecurityToken = securityToken }, "");
        }


    }
}
