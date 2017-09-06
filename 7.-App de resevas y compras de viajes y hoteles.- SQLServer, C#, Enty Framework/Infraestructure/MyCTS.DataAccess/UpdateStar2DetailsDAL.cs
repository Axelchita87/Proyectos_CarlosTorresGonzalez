using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.DataAccess.Resources;
using MyCTS.Entities;

namespace MyCTS.DataAccess
{
    public class UpdateStar2DetailsDAL
    {
        public void UpdateS2Details(Star2Details objS2Details, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(UpdateStar2DetailsResources.SP_UpdateStar2Details);

            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_Id, DbType.String, objS2Details.Id);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_Level1, DbType.String, objS2Details.Level1);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_Level2, DbType.String, objS2Details.Level2);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_Name, DbType.String, objS2Details.Name);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_LastName, DbType.String, objS2Details.LastName);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_OfficePhone, DbType.String, objS2Details.OfficePhone);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_Ext, DbType.String, objS2Details.Ext);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_OfficePhoneCode, DbType.String, objS2Details.OfficePhoneCode);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_DirectPhone, DbType.String, objS2Details.DirectPhone);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_DirectPhoneCode, DbType.String, objS2Details.DirectPhoneCode);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_Email, DbType.String, objS2Details.Email);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_FrequentFlyer1, DbType.String, objS2Details.FrequentFlyer1);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_FrequentFlyer2, DbType.String, objS2Details.FrequentFlyer2);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_FrequentFlyer3, DbType.String, objS2Details.FrequentFlyer3);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_FrequentFlyer4, DbType.String, objS2Details.FrequentFlyer4);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_FrequentFlyer5, DbType.String, objS2Details.FrequentFlyer5);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_Passport, DbType.String, objS2Details.Passport);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_Birthday, DbType.String, objS2Details.Birthday);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_Visa, DbType.String, objS2Details.Visa);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_ImmigrationForm, DbType.String, objS2Details.ImmigrationForm);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_RFC, DbType.String, objS2Details.Rfc);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_CreditCar, DbType.String, objS2Details.CreditCar);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_PersonalCar, DbType.String, objS2Details.PersonalCar);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_StreetAndNumber, DbType.String, objS2Details.StreetAndNumber);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_Colony, DbType.String, objS2Details.Colony);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_PostalCode, DbType.String, objS2Details.PostalCode);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_Estate, DbType.String, objS2Details.Estate);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_City, DbType.String, objS2Details.City);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_Name2, DbType.String, objS2Details.Name2);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_LastName2, DbType.String, objS2Details.LastName2);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_Paternal, DbType.String, objS2Details.Paternal);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_Maternal, DbType.String, objS2Details.Maternal);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_Occupation, DbType.String, objS2Details.Occupation);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_Seat, DbType.String, objS2Details.Seat);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_Family1, DbType.String, objS2Details.Family1);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_Family2, DbType.String, objS2Details.Family2);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_Family3, DbType.String, objS2Details.Family3);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_Family4, DbType.String, objS2Details.Family4);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_Family5, DbType.String, objS2Details.Family5);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_Family6, DbType.String, objS2Details.Family6);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_Comments, DbType.String, objS2Details.Comments);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_HotelCreditCar, DbType.String, objS2Details.HotelCreditCar);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_CadHotel1, DbType.String, objS2Details.CadHotel1);
            db.AddInParameter(dbcomand, UpdateStar2DetailsResources.PARAM_CadHotel2, DbType.String, objS2Details.CadHotel2);

            db.ExecuteNonQuery(dbcomand);
        }
    }
}
