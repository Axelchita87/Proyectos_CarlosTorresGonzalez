using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Presentation.Base
{
    public interface IErrorHandler<T> where T : class
    {
        IErrorHandler<T> Succesor { get; set; }
        void Handle(T request);
        IProcessContext<T> Context { get; set; }
    }
}
