using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.DataAccess.Resources;
using MyCTS.Entities;

namespace MyCTS.DataAccess
{
    public class UpdateStar1DetailsDAL
    {
        public void UpdateS1Details(Star1Details objS1Details, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(UpdateS1DetailsResources.PS_UpdateS1Details);

            db.AddInParameter(dbcomand, UpdateS1DetailsResources.PARAM_Id, DbType.Int32, objS1Details.Id);
            db.AddInParameter(dbcomand, UpdateS1DetailsResources.PARAM_ProfileName, DbType.String, objS1Details.ProfileName);
            db.AddInParameter(dbcomand, UpdateS1DetailsResources.PARAM_CustomerDK, DbType.String, objS1Details.CustomerDk);
            db.AddInParameter(dbcomand, UpdateS1DetailsResources.PARAM_PCC, DbType.String, objS1Details.Pcc);
            db.AddInParameter(dbcomand, UpdateS1DetailsResources.PARAM_CompanyName, DbType.String, objS1Details.CompanyName);
            db.AddInParameter(dbcomand, UpdateS1DetailsResources.PARAM_Telephone, DbType.String, objS1Details.Phone);
            db.AddInParameter(dbcomand, UpdateS1DetailsResources.PARAM_Ext, DbType.String, objS1Details.Ext);
            db.AddInParameter(dbcomand, UpdateS1DetailsResources.PARAM_TravelPolicies, DbType.String, objS1Details.TravelPolicies);
            db.AddInParameter(dbcomand, UpdateS1DetailsResources.PARAM_SocialReason, DbType.String, objS1Details.SocialReason);
            db.AddInParameter(dbcomand, UpdateS1DetailsResources.PARAM_Street, DbType.String, objS1Details.Street);
            db.AddInParameter(dbcomand, UpdateS1DetailsResources.PARAM_OutsideNumber, DbType.String, objS1Details.OutsideNumber);
            db.AddInParameter(dbcomand, UpdateS1DetailsResources.PARAM_InternalNumber, DbType.String, objS1Details.InternalNumber);
            db.AddInParameter(dbcomand, UpdateS1DetailsResources.PARAM_Colony, DbType.String, objS1Details.Colony);
            db.AddInParameter(dbcomand, UpdateS1DetailsResources.PARAM_Municipality, DbType.String, objS1Details.Municipality);
            db.AddInParameter(dbcomand, UpdateS1DetailsResources.PARAM_PostalCode, DbType.String, objS1Details.PostalCode);
            db.AddInParameter(dbcomand, UpdateS1DetailsResources.PARAM_City, DbType.String, objS1Details.City);
            db.AddInParameter(dbcomand, UpdateS1DetailsResources.PARAM_State, DbType.String, objS1Details.State);
            db.AddInParameter(dbcomand, UpdateS1DetailsResources.PARAM_RFC, DbType.String, objS1Details.Rfc);
            db.AddInParameter(dbcomand, UpdateS1DetailsResources.PARAM_CreditCard, DbType.String, objS1Details.CreditCard);
            db.AddInParameter(dbcomand, UpdateS1DetailsResources.PARAM_ExpiratioDate, DbType.String, objS1Details.ExpirationDate);
            db.AddInParameter(dbcomand, UpdateS1DetailsResources.PARAM_ContactCompany, DbType.String, objS1Details.ContactCompany);
            db.AddInParameter(dbcomand, UpdateS1DetailsResources.PARAM_Email, DbType.String, objS1Details.Email);
            db.AddInParameter(dbcomand, UpdateS1DetailsResources.PARAM_Comments, DbType.String, objS1Details.Comments);
            db.AddInParameter(dbcomand, UpdateS1DetailsResources.PARAM_CreatedBy, DbType.String, objS1Details.CreatedBy);
            db.AddInParameter(dbcomand, UpdateS1DetailsResources.PARAM_Password, DbType.String, objS1Details.Password);
            //db.AddInParameter(dbcomand, Resources.UpdateS1DetailsResources.PARAM_ExtraData, DbType.String, extraData);

            db.ExecuteNonQuery(dbcomand);
        }
    }
}