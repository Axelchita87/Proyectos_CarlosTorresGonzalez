using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
   public  class VolarisPassangerSpecialServices
   {

       private readonly List<VolarisPassangerSpecialService> _services;
       public VolarisPassangerSpecialServices()
       {
           _services = new List<VolarisPassangerSpecialService>();
       }

       public void Add(List<VolarisPassangerSpecialService> services )
       {
           if(services != null && services.Any())
           {

               foreach (var service in services)
               {
                   if(service.Type != VolarisSepecialServiceType.None)
                   {

                       if (!_services.Any(s => s.Type == service.Type))
                       {
                           _services.Add(service);
                       }
                   }
               }
              
           }
       }

       public void Add(VolarisPassangerSpecialService service)
       {
           Add(new List<VolarisPassangerSpecialService>{service});
       }


       public List<VolarisPassangerSpecialService> GetAllService()
       {
           return _services;
       }
    }
}
