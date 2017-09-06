using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Presentation.Base
{
    public abstract class ErrorManager<T>
        where T : class
    {

        public IErrorHandler<T> Handler { get; set; }
        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        public void Handle(T request)
        {
            if (Handler != null)
            {
                Handler.Handle(request);
                return;
            }
            throw new ArgumentException("No se encontro ningun manejador de errores configurado.");
        }
    }
}
