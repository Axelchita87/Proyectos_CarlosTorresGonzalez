using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Presentation.Base
{
    public interface IDynamicBuilder<T>
    {

         T Build();
    }
}
