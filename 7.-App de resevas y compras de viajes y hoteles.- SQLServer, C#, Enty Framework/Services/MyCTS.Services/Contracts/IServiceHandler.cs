using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Services.Contracts
{
    public interface IServiceHandler<TResult>

        where TResult : class
    {
        IService<TResult> Service { get; set; }
        void CallService();



    }

    public interface IServiceHandler
    {
        IService Service { get; set; }
        void CallService();
    }

}
