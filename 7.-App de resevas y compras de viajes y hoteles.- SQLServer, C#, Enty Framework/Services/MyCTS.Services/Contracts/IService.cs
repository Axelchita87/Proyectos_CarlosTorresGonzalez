using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Services.Contracts
{
    public interface IService<T>
    {
        T Call();
    }
    public interface IService
    {
        void Call();
    }
}
