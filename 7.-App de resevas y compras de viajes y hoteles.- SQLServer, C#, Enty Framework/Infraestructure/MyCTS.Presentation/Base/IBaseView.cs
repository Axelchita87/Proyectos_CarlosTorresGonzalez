using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Presentation.Base
{
    public interface IBaseView
    {
        string Name { get; set; }
        void ValidateInput();
        bool IsValid { get; set; }


    }


}
