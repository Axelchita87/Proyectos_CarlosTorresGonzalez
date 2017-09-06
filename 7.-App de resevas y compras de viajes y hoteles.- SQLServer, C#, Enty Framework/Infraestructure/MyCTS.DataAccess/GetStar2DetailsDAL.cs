using System;
using System.Data.Common;
using MyCTS.Components.NullableHelper;
using MyCTS.Entities;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MyCTS.DataAccess
{
   public class GetStar2DetailsDAL
    {        
        public Star2Details ObjGetStar2Details(string level1, string level2 , string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetStar2DetailsResources.SP_GetStar2Details);
            db.AddInParameter(dbCommand, Resources.GetStar2DetailsResources.PARAM_Level1, DbType.String, level1);
            db.AddInParameter(dbCommand, Resources.GetStar2DetailsResources.PARAM_Level2, DbType.String, level2);

            var item = new Star2Details();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _id = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_Id);
                int _level1 = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_Level1);
                int _level2 = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_Level2);
                int _name = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_Name);
                int _lastName = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_LastName);
                int _officePhone = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_OfficePhone);
                int _ext = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_Ext);
                int _officePhoneCode = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_OfficePhoneCode);
                int _directPhone = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_DirectPhone);
                int _directPhoneCode = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_DirectPhoneCode);
                int _email = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_Email);
                int _frequentFlyer1 = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_FrequentFlyer1);
                int _frequentFlyer2 = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_FrequentFlyer2);
                int _frequentFlyer3 = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_FrequentFlyer3);
                int _frequentFlyer4 = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_FrequentFlyer4);
                int _frequentFlyer5 = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_FrequentFlyer5);
                int _passport = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_Passport);
                int _birthday = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_Birthday);
                int _visa = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_Visa);
                int _immigrationForm = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_ImmigrationForm);
                int _rfc = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_RFC);
                int _creditCar = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_CreditCar);
                int _personalCar = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_PersonalCar);
                int _streetAndNumber = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_StreetAndNumber);
                int _colony = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_Colony);
                int _postalCode = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_PostalCode);
                int _estate = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_Estate);
                int _city = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_City);
                int _name2 = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_Name2);
                int _lastName2 = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_LastName2);
                int _paternal = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_Paternal);
                int _maternal = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_Maternal);
                int _occupation = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_Occupation);
                int _seat = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_Seat);
                int _family1 = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_Family1);
                int _family2 = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_Family2);
                int _family3 = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_Family3);
                int _family4 = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_Family4);
                int _family5 = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_Family5);
                int _family6 = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_Family6);
                int _comments = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_Comments);
                int _hotelCreditCar = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_HotelCreditCar);
                int _cadHotel1 = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_CadHotel1);
                int _cadHotel2 = dr.GetOrdinal(Resources.GetStar2DetailsResources.PARAM_CadHotel2);


                while (dr.Read())
                {

                item.Id = (dr[_id] == DBNull.Value) ? Types.StringNullValue : dr.GetInt32(_id).ToString();
                item.Level1 = MyCTSConvert.ToString(dr.GetString(_level1));
                item.Level2 = MyCTSConvert.ToString(dr.GetString(_level2));
                item.Name = MyCTSConvert.ToString(dr.GetString(_name));
                item.LastName = MyCTSConvert.ToString(dr.GetString(_lastName));
                item.OfficePhone = MyCTSConvert.ToString(dr.GetString(_officePhone));
                item.Ext = MyCTSConvert.ToString(dr.GetString(_ext));
                item.OfficePhoneCode = MyCTSConvert.ToString(dr.GetString(_officePhoneCode));
                item.DirectPhone = MyCTSConvert.ToString(dr.GetString(_directPhone));
                item.DirectPhoneCode = MyCTSConvert.ToString(dr.GetString(_directPhoneCode));
                item.Email = MyCTSConvert.ToString(dr.GetString(_email));
                item.FrequentFlyer1 = MyCTSConvert.ToString(dr.GetString(_frequentFlyer1));
                item.FrequentFlyer2 = MyCTSConvert.ToString(dr.GetString(_frequentFlyer2));
                item.FrequentFlyer3 = MyCTSConvert.ToString(dr.GetString(_frequentFlyer3));
                item.FrequentFlyer4 = MyCTSConvert.ToString(dr.GetString(_frequentFlyer4));
                item.FrequentFlyer5 = MyCTSConvert.ToString(dr.GetString(_frequentFlyer5));
                item.Passport = MyCTSConvert.ToString(dr.GetString(_passport));
                item.Birthday = MyCTSConvert.ToString(dr.GetString(_birthday));
                item.Visa = MyCTSConvert.ToString(dr.GetString(_visa));
                item.ImmigrationForm = MyCTSConvert.ToString(dr.GetString(_immigrationForm));
                item.Rfc = MyCTSConvert.ToString(dr.GetString(_rfc));
                item.CreditCar = MyCTSConvert.ToString(dr.GetString(_creditCar));
                item.PersonalCar = MyCTSConvert.ToString(dr.GetString(_personalCar));
                item.StreetAndNumber = MyCTSConvert.ToString(dr.GetString(_streetAndNumber));
                item.Colony = MyCTSConvert.ToString(dr.GetString(_colony));
                item.PostalCode = MyCTSConvert.ToString(dr.GetString(_postalCode));
                item.Estate = MyCTSConvert.ToString(dr.GetString(_estate));
                item.City = MyCTSConvert.ToString(dr.GetString(_city));
                item.Name2 = MyCTSConvert.ToString(dr.GetString(_name2));
                item.LastName2 = MyCTSConvert.ToString(dr.GetString(_lastName2));
                item.Paternal = MyCTSConvert.ToString(dr.GetString(_paternal));
                item.Maternal = MyCTSConvert.ToString(dr.GetString(_maternal));
                item.Occupation = MyCTSConvert.ToString(dr.GetString(_occupation));
                item.Seat = MyCTSConvert.ToString(dr.GetString(_seat));
                item.Family1 = MyCTSConvert.ToString(dr.GetString(_family1));
                item.Family2 = MyCTSConvert.ToString(dr.GetString(_family2));
                item.Family3 = MyCTSConvert.ToString(dr.GetString(_family3));
                item.Family4 = MyCTSConvert.ToString(dr.GetString(_family4));
                item.Family5 = MyCTSConvert.ToString(dr.GetString(_family5));
                item.Family6 = MyCTSConvert.ToString(dr.GetString(_family6));
                item.Comments = MyCTSConvert.ToString(dr.GetString(_comments));
                item.HotelCreditCar = MyCTSConvert.ToString(dr.GetString(_hotelCreditCar));
                item.CadHotel1 = MyCTSConvert.ToString(dr.GetString(_cadHotel1));
                item.CadHotel2 = MyCTSConvert.ToString(dr.GetString(_cadHotel2));
                }
            }
            return item;
        }
    }
    
}
