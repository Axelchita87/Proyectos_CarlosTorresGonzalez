using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Components.NullableHelper;
using MyCTS.Entities;

namespace MyCTS.DataAccess
{
    public class InterJetProfileDAL
    {


        /// <summary>
        /// Gets the profile.
        /// </summary>
        /// <param name="secondLevelProfile">The second level profile.</param>
        /// <param name="firstLevelProfile">The first level profile.</param>
        /// <returns></returns>
        public InterJetProfile GetProfile(string secondLevelProfile, string firstLevelProfile)
        {

            try
            {
                return this.GetProfile(secondLevelProfile, firstLevelProfile, CommonENT.MYCTSDBPROFILES_CONNECTION);
            }
            catch
            {

                try
                {
                    return this.GetProfile(secondLevelProfile, firstLevelProfile, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
                catch
                {

                }
            }
            return new InterJetProfile();

        }


        /// <summary>
        /// Gets the profile.
        /// </summary>
        /// <param name="secondLevelProfile">The second level profile.</param>
        /// <param name="firstLevelProfile">The first level profile.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <returns></returns>
        private InterJetProfile GetProfile(string secondLevelProfile, string firstLevelProfile, string connectionString)
        {

            Database dataBase = DatabaseFactory.CreateDatabase(connectionString);
            DbCommand dataBaseCommand = dataBase.GetStoredProcCommand("GetInterJetProfile");
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
                int email = dataReader.GetOrdinal("Email");
                int phone = dataReader.GetOrdinal("OfficePhone");
                int creditCard2 = dataReader.GetOrdinal("CreditCard2");
                int creditCard3 = dataReader.GetOrdinal("CreditCard3");
                int creditCard4 = dataReader.GetOrdinal("CreditCard4");
                int creditCard5 = dataReader.GetOrdinal("CreditCard5");
                int creditCard6 = dataReader.GetOrdinal("CreditCard6");
                int creditCard7 = dataReader.GetOrdinal("CreditCard7");
                int creditCard8 = dataReader.GetOrdinal("CreditCard8");
                var profiles = new List<InterJetProfile>();
                while (dataReader.Read())
                {
                    var profile = new InterJetProfile();
                    profile.Id = dataReader.GetInt32(id);
                    profile.Name = dataReader.GetString(name);
                    profile.Email = dataReader.GetString(email);
                    profile.Phone = dataReader.GetString(phone);
                    profile.LastName = dataReader.GetString(lastName);
                    profile.FirstLevelProfile = dataReader.GetString(fristLevel);
                    profile.SecondLevelProfile = dataReader.GetString(secondLevel);
                    profile.BirthDay = this.GetBirthDay(dataReader.GetString(birthtDay));
                    profile.CreditCards = new InterJetProfileCreditCards();
                    profile.CreditCards.Add(new InterJetProfileCreditCard((dataReader[creditCard] == DBNull.Value) ? Types.StringNullValue : dataReader.GetString(creditCard), false));
                    profile.CreditCards.Add(new InterJetProfileCreditCard((dataReader[creditCard2] == DBNull.Value) ? Types.StringNullValue : dataReader.GetString(creditCard2), false));
                    profile.CreditCards.Add(new InterJetProfileCreditCard((dataReader[creditCard3] == DBNull.Value) ? Types.StringNullValue : dataReader.GetString(creditCard3), false));
                    profile.CreditCards.Add(new InterJetProfileCreditCard((dataReader[creditCard4] == DBNull.Value) ? Types.StringNullValue : dataReader.GetString(creditCard4), false));
                    profile.CreditCards.Add(new InterJetProfileCreditCard((dataReader[creditCard5] == DBNull.Value) ? Types.StringNullValue : dataReader.GetString(creditCard5), false));
                    profile.CreditCards.Add(new InterJetProfileCreditCard((dataReader[creditCard6] == DBNull.Value) ? Types.StringNullValue : dataReader.GetString(creditCard6), false));
                    profile.CreditCards.Add(new InterJetProfileCreditCard((dataReader[creditCard7] == DBNull.Value) ? Types.StringNullValue : dataReader.GetString(creditCard7), false));
                    profile.CreditCards.Add(new InterJetProfileCreditCard((dataReader[creditCard8] == DBNull.Value) ? Types.StringNullValue : dataReader.GetString(creditCard8), false));
                    profiles.Add(profile);
                }
                if (profiles.Any())
                {
                    var resultedProfile = profiles.FirstOrDefault(p => p.FirstLevelProfile.Equals(firstLevelProfile)
                                                                       &&
                                                                       p.SecondLevelProfile.Equals(secondLevelProfile));

                    return resultedProfile;
                }

            }

            return new InterJetProfile();
        }

        /// <summary>
        /// Gets the profile credit card.
        /// </summary>
        /// <param name="fristLevelProfile">The frist level profile.</param>
        /// <returns></returns>
        public List<InterJetProfileCreditCard> GetProfileCreditCard(string fristLevelProfile)
        {
            try
            {
                return GetProfileCreditCard(fristLevelProfile, CommonENT.MYCTSDBPROFILES_CONNECTION);

            }
            catch
            {

                try
                {

                    return GetProfileCreditCard(fristLevelProfile, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);

                }
                catch
                {
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the profile credit card.
        /// </summary>
        /// <param name="fristLevelProfile">The frist level profile.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <returns></returns>
        private List<InterJetProfileCreditCard> GetProfileCreditCard(string fristLevelProfile, string connectionString)
        {

            Database dataBase = DatabaseFactory.CreateDatabase(connectionString);

            DbCommand dataBaseCommand = dataBase.GetStoredProcCommand("[GetCreditCardFromFristLevelProfile_Usr]");
            dataBase.AddInParameter(dataBaseCommand, "input", DbType.String, fristLevelProfile);
            var creditCards = new List<string>();
            using (IDataReader dataReader = dataBase.ExecuteReader(dataBaseCommand))
            {
                int creditCardPosition = dataReader.GetOrdinal("CreditCard");
                int creditCardPosition2 = dataReader.GetOrdinal("CreditCard2");
                int creditCardPosition3 = dataReader.GetOrdinal("CreditCard3");
                int creditCardPosition4 = dataReader.GetOrdinal("CreditCard4");
                int creditCardPosition5 = dataReader.GetOrdinal("CreditCard5");
                int cvv1 = dataReader.GetOrdinal("CVV1");
                int cvv2 = dataReader.GetOrdinal("CVV2");
                int cvv3 = dataReader.GetOrdinal("CVV3");
                int eDate1 = dataReader.GetOrdinal("ExpirationDate");
                int eDate2 = dataReader.GetOrdinal("ExpirationDate2");
                int eDate3 = dataReader.GetOrdinal("ExpirationDate3");
                while (dataReader.Read())
                {
                    string expirationDate1 = (dataReader[eDate1] == DBNull.Value)
                                           ? Types.StringNullValue
                                           : dataReader.GetString(eDate1);

                    string expirationDate2 = (dataReader[eDate2] == DBNull.Value)
                                           ? Types.StringNullValue
                                           : dataReader.GetString(eDate2);

                    string expirationDate3 = (dataReader[eDate3] == DBNull.Value)
                                           ? Types.StringNullValue
                                           : dataReader.GetString(eDate3);

                    string expirationDate4 = (dataReader[dataReader.GetOrdinal("ExpirationDate4")] == DBNull.Value)
                                           ? Types.StringNullValue
                                           : dataReader.GetString(dataReader.GetOrdinal("ExpirationDate4"));

                    string expirationDate5 = (dataReader[dataReader.GetOrdinal("ExpirationDate5")] == DBNull.Value)
                                           ? Types.StringNullValue
                                           : dataReader.GetString(dataReader.GetOrdinal("ExpirationDate5"));

                    string CVV1 = (dataReader[cvv1] == DBNull.Value)
                                           ? Types.StringNullValue
                                           : dataReader.GetString(cvv1);

                    string CVV2 = (dataReader[cvv2] == DBNull.Value)
                                           ? Types.StringNullValue
                                           : dataReader.GetString(cvv2);

                    string CVV3 = (dataReader[cvv3] == DBNull.Value)
                                           ? Types.StringNullValue
                                           : dataReader.GetString(cvv3);

                    string CVV4 = (dataReader[dataReader.GetOrdinal("CVV4")] == DBNull.Value)
                                           ? Types.StringNullValue
                                           : dataReader.GetString(dataReader.GetOrdinal("CVV4"));

                    string CVV5 = (dataReader[dataReader.GetOrdinal("CVV5")] == DBNull.Value)
                                           ? Types.StringNullValue
                                           : dataReader.GetString(dataReader.GetOrdinal("CVV5"));

                    string creditCard = (dataReader[creditCardPosition] == DBNull.Value)
                                           ? Types.StringNullValue
                                           : dataReader.GetString(creditCardPosition);


                    creditCards.Add(creditCard + "^" + expirationDate1 + "^" + CVV1 + "^" + ((dataReader[dataReader.GetOrdinal("TypeOfService1")] == DBNull.Value)
                                           ? Types.StringNullValue
                                           : dataReader.GetString(dataReader.GetOrdinal("TypeOfService1"))));

                    string creditCard2 = (dataReader[creditCardPosition2] == DBNull.Value)
                                           ? Types.StringNullValue
                                           : dataReader.GetString(creditCardPosition2);
                    creditCards.Add(creditCard2 + "^"+expirationDate2+ "^" + CVV2 + "^" + ((dataReader[dataReader.GetOrdinal("TypeOfService2")] == DBNull.Value)
                                           ? Types.StringNullValue
                                           : dataReader.GetString(dataReader.GetOrdinal("TypeOfService2"))));

                    string creditCard3 = (dataReader[creditCardPosition3] == DBNull.Value)
                                           ? Types.StringNullValue
                                           : dataReader.GetString(creditCardPosition3);

                    creditCards.Add(creditCard3 + "^" + expirationDate3 + "^" + CVV3 + "^" + ((dataReader[dataReader.GetOrdinal("TypeOfService3")] == DBNull.Value)
                                           ? Types.StringNullValue
                                           : dataReader.GetString(dataReader.GetOrdinal("TypeOfService3"))));

                    string creditCard4 = (dataReader[creditCardPosition4] == DBNull.Value)
                                           ? Types.StringNullValue
                                           : dataReader.GetString(creditCardPosition4);
                    creditCards.Add(creditCard4 + "^" + expirationDate4 + "^" + CVV4 + "^" + ((dataReader[dataReader.GetOrdinal("TypeOfService4")] == DBNull.Value)
                                           ? Types.StringNullValue
                                           : dataReader.GetString(dataReader.GetOrdinal("TypeOfService4"))));

                    string creditCard5 = (dataReader[creditCardPosition5] == DBNull.Value)
                                           ? Types.StringNullValue
                                           : dataReader.GetString(creditCardPosition5);
                    creditCards.Add(creditCard5 + "^" + expirationDate5 + "^" + CVV5 + "^" + ((dataReader[dataReader.GetOrdinal("TypeOfService5")] == DBNull.Value)
                                           ? Types.StringNullValue
                                           : dataReader.GetString(dataReader.GetOrdinal("TypeOfService5"))));
                }
            }

            var profilesCreditCard = new List<InterJetProfileCreditCard>();

            foreach (string creditcard in creditCards)
            {
                profilesCreditCard.Add(new InterJetProfileCreditCard(creditcard, true));


            }
            return profilesCreditCard.Where(cp => cp.IsValid).ToList();


        }


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


    }




}
