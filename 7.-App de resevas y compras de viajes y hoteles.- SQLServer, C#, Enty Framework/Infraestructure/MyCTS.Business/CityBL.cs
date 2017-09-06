using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class CityBL
    {


        private CityDAL _cityService;

        private CityDAL CityService
        { get { return _cityService ?? (_cityService = new CityDAL()); } }

        public City GetCity(string cityId)
        {

            return CityService.GetCity(cityId);
        }

    }
}
