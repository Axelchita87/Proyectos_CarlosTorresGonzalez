using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class VolarisProfileBL
    {


        /// <summary>
        /// 
        /// </summary>
        private VolarisProfileDAL _service;
        /// <summary>
        /// Gets the data access service.
        /// </summary>
        private VolarisProfileDAL DataAccessService
        {

            get { return _service ?? (_service = new VolarisProfileDAL()); }
        }
        /// <summary>
        /// Gets the profile.
        /// </summary>
        /// <param name="secondLevelProfile">The second level profile.</param>
        /// <param name="firstLevelProfile">The first level profile.</param>
        /// <returns></returns>
        public VolarisProfile GetProfile(string secondLevelProfile, string firstLevelProfile)
        {

            return DataAccessService.GetProfile(secondLevelProfile, firstLevelProfile);

        }
    }
}
