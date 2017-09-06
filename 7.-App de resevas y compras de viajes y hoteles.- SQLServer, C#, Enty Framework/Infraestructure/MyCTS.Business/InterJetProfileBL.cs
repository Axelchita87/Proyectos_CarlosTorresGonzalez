using System.Collections.Generic;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class InterJetProfileBL
    {

        /// <summary>
        /// 
        /// </summary>
        private InterJetProfileDAL _accesData;

        /// <summary>
        /// Gets the acces data.
        /// </summary>
        private InterJetProfileDAL AccesData
        {

            get { return _accesData ?? (_accesData = new InterJetProfileDAL()); }
        }


        /// <summary>
        /// Gets the profile.
        /// </summary>
        /// <param name="secondLevelProfile">The second level profile.</param>
        /// <param name="firstLevelProfile">The first level profile.</param>
        /// <returns></returns>
        public InterJetProfile GetProfile(string secondLevelProfile, string firstLevelProfile)
        {

            return AccesData.GetProfile(secondLevelProfile.Trim(), firstLevelProfile.Trim());
        }

        /// <summary>
        /// Gets the profile credit card.
        /// </summary>
        /// <param name="fristLevelProfile">The frist level profile.</param>
        /// <returns></returns>
        public List<InterJetProfileCreditCard> GetProfileCreditCard(string fristLevelProfile)
        {
            return AccesData.GetProfileCreditCard(fristLevelProfile);
        }



    }
}
