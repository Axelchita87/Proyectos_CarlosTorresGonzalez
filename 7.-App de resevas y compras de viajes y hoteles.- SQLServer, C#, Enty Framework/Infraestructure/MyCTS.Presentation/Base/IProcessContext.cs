using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Presentation.Base
{
    public interface IProcessContext<T> where T : class
    {

        void Resolve(T objectContext);
    }
}
