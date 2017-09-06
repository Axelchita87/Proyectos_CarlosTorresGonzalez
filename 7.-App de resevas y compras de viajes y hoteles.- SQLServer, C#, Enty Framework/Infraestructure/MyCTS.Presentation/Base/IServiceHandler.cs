using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Services.Contracts;

namespace MyCTS.Presentation.Base
{
    public interface IServiceHandler<TResult>

        where TResult : class
    {
        IService<Flights> Service { get; set; }
        void CallService();

    }

    public interface IServiceHandler
    {
        IService Service { get; set; }
        void CallService();
    }

}
