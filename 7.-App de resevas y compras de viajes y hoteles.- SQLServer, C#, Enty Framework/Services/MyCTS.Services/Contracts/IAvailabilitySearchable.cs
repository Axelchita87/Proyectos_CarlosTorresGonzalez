using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;

namespace MyCTS.Services.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAvailabilitySearchable : IService<List<IFlight>>
    {
        AvailabilityRequest Request { get; set; }
        string CompanyName { get; }

    }
}
