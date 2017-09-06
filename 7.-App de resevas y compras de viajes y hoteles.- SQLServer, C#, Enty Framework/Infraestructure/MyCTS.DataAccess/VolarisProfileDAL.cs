using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Components.NullableHelper;
using MyCTS.Entities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
namespace MyCTS.DataAccess
{
    public class VolarisProfileDAL
    {

        /// <summary>
        /// Gets the birth day.
        /// </summary>
        /// <param name="stringDate">The string date.</param>
        /// <returns></returns>
        private DateTime GetBirthDay(string stringDate)
        {
            try
            {
                string newStringDate = stringDate.Replace("*#*", "");
                return DateTime.Parse(newStringDate);
            }
            catch
            {
                return DateTime.Now;
            }



        }


        /// <summary>
        /// Gets the profile.
        /// </summary>
        /// <param name="secondLevelProfile">The second level profile.</param>
        /// <param name="firstLevelProfile">The first level profile.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <returns></returns>
        private VolarisProfile GetProfile(string secondLevelProfile, string firstLevelProfile, string connectionString)
        {
            Database dataBase = DatabaseFactory.CreateDatabase(connectionString);
            DbCommand dataBaseCommand = dataBase.GetStoredProcCommand("GetVolarisProfile");
            dataBase.AddInParameter(dataBaseCommand, "input", DbType.String, secondLevelProfile);

            using (IDataReader dataReader = dataBase.ExecuteReader(dataBaseCommand))
            {
                int id = dataReader.GetOrdinal("Id");

                int name = dataReader.GetOrdinal("Name");
                int lastName = dataReader.GetOrdinal("LastName");
                int birthtDay = dataReader.GetOrdinal("Birthday");
                int fristLevel = dataReader.GetOrdinal("Level1");
                int secondLevel = dataReader.GetOrdinal("Level2");
                int creditCard = dataReader.GetOrdinal("CreditCar");

                int creditCard2 = dataReader.GetOrdinal("CreditCard2");
                int creditCard3 = dataReader.GetOrdinal("CreditCard3");
                int creditCard4 = dataReader.GetOrdinal("CreditCard4");
                int creditCard5 = dataReader.GetOrdinal("CreditCard5");
                int creditCard6 = dataReader.GetOrdinal("CreditCard6");
                int creditCard7 = dataReader.GetOrdinal("CreditCard7");
                int creditCard8 = dataReader.GetOrdinal("CreditCard8");
                var profiles = new List<VolarisProfile>();
                while (dataReader.Read())
                {
                    var profile = new VolarisProfile();
                    profile.Id = dataReader.GetInt32(id);
                    profile.Name = dataReader.GetString(name);
                    profile.LastName = dataReader.GetString(lastName);
                    profile.FirstLevelProfile = dataReader.GetString(fristLevel);
                    profile.SecondLevelProfile = dataReader.GetString(secondLevel);
                    profile.BirthDay = this.GetBirthDay(dataReader.GetString(birthtDay));
                    profile.CreditCards.Add(new VolarisProfileCreditCard((dataReader[creditCard] == DBNull.Value) ? Types.StringNullValue : dataReader.GetString(creditCard), false));
                    profile.CreditCards.Add(new VolarisProfileCreditCard((dataReader[creditCard2] == DBNull.Value) ? Types.StringNullValue : dataReader.GetString(creditCard2), false));
                    profile.CreditCards.Add(new VolarisProfileCreditCard((dataReader[creditCard3] == DBNull.Value) ? Types.StringNullValue : dataReader.GetString(creditCard3), false));
                    profile.CreditCards.Add(new VolarisProfileCreditCard((dataReader[creditCard4] == DBNull.Value) ? Types.StringNullValue : dataReader.GetString(creditCard4), false));
                    profile.CreditCards.Add(new VolarisProfileCreditCard((dataReader[creditCard5] == DBNull.Value) ? Types.StringNullValue : dataReader.GetString(creditCard5), false));
                    profile.CreditCards.Add(new VolarisProfileCreditCard((dataReader[creditCard6] == DBNull.Value) ? Types.StringNullValue : dataReader.GetString(creditCard6), false));
                    profile.CreditCards.Add(new VolarisProfileCreditCard((dataReader[creditCard7] == DBNull.Value) ? Types.StringNullValue : dataReader.GetString(creditCard7), false));
                    profile.CreditCards.Add(new VolarisProfileCreditCard((dataReader[creditCard8] == DBNull.Value) ? Types.StringNullValue : dataReader.GetString(creditCard8), false));
                    profiles.Add(profile);
                }
                if (profiles.Any())
                {
                    var resultedProfile = profiles.FirstOrDefault(p => p.FirstLevelProfile.Equals(firstLevelProfile)
                                                                       &&
                                                                       p.SecondLevelProfile.Equals(secondLevelProfile));

                    if (resultedProfile != null)
                    {
                        resultedProfile.CreditCards.Add(GetCardsFromFristLevel(resultedProfile.FirstLevelProfile));
                    }
                    return resultedProfile;
                }

            }

            return null;

        }


        /// <summary>
        /// Gets the profile.
        /// </summary>
        /// <param name="secondLevelProfile">The second level profile.</param>
        /// <param name="firstLevelProfile">The first level profile.</param>
        /// <returns></returns>
        public VolarisProfile GetProfile(string secondLevelProfile, string firstLevelProfile)
        {
            try
            {
                return GetProfile(secondLevelProfile, firstLevelProfile, CommonENT.MYCTSDBPROFILES_CONNECTION);
            }
            catch
            {
                try
                {
                    return GetProfile(secondLevelProfile, firstLevelProfile, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
                catch
                {

                }
            }
            return null;
        }


        /// <summary>
        /// Gets the cards from frist level.
        /// </summary>
        /// <param name="fristLevelProfile">The frist level profile.</param>
        /// <returns></returns>
        private List<VolarisProfileCreditCard> GetCardsFromFristLevel(string fristLevelProfile)
        {
            try
            {
                return GetCardsFromFristLevel(fristLevelProfile, CommonENT.MYCTSDBPROFILES_CONNECTION);
            }
            catch
            {
                try
                {
                    return GetCardsFromFristLevel(fristLevelProfile, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
                catch
                {

                }
            }
            return null;
        }

        /// <summary>
        /// Gets the cards from frist level.
        /// </summary>
        /// <param name="fristLevelProfile">The frist level profile.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <returns></returns>
        private List<VolarisProfileCreditCard> GetCardsFromFristLevel(string fristLevelProfile, string connectionString)
        {

            Database dataBase = DatabaseFactory.CreateDatabase(connectionString);
            DbCommand dataBaseCommand = dataBase.GetStoredProcCommand("GetCreditCardsFirstLevel");
            dataBase.AddInParameter(dataBaseCommand, "dk", DbType.String, fristLevelProfile);
            var creditCards = new List<string>();
            using (IDataReader dataReader = dataBase.ExecuteReader(dataBaseCommand))
            {
                int creditCardPosition = dataReader.GetOrdinal("CreditCard1");
                int creditCardPosition2 = dataReader.GetOrdinal("CreditCard2");
                int creditCardPosition3 = dataReader.GetOrdinal("CreditCard3");
                int creditCardPosition4 = dataReader.GetOrdinal("CreditCard4");
                int creditCardPosition5 = dataReader.GetOrdinal("CreditCard5");
                while (dataReader.Read())
                {
                    string creditCard = (dataReader[creditCardPosition] == DBNull.Value)
                                           ? Types.StringNullValue
                                           : dataReader.GetString(creditCardPosition);
                    creditCards.Add(creditCard);
                    string creditCard2 = (dataReader[creditCardPosition2] == DBNull.Value)
                                           ? Types.StringNullValue
                                           : dataReader.GetString(creditCardPosition2);
                    creditCards.Add(creditCard2);


                    string creditCard3 = (dataReader[creditCardPosition3] == DBNull.Value)
                                           ? Types.StringNullValue
                                           : dataReader.GetString(creditCardPosition3);

                    creditCards.Add(creditCard3);
                    string creditCard4 = (dataReader[creditCardPosition4] == DBNull.Value)
                                           ? Types.StringNullValue
                                           : dataReader.GetString(creditCardPosition4);
                    creditCards.Add(creditCard4);
                    string creditCard5 = (dataReader[creditCardPosition5] == DBNull.Value)
                                           ? Types.StringNullValue
                                           : dataReader.GetString(creditCardPosition5);
                    creditCards.Add(creditCard5);
                }
            }

            var profilesCreditCard = new List<VolarisProfileCreditCard>();

            foreach (string creditcard in creditCards)
            {
                profilesCreditCard.Add(new VolarisProfileCreditCard(creditcard, true));


            }
            return profilesCreditCard.Where(cp => cp.IsValid).ToList();


        }


    }
}
