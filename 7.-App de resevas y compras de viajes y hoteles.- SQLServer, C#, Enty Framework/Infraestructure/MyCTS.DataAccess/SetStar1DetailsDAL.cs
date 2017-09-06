using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.IO;
using System.Data;
using System.Data.Common;
using MyCTS.Entities;
using MyCTS.Components.NullableHelper;

namespace MyCTS.DataAccess
{
    public class SetStar1DetailsDAL
    {
        public void AddStar1Details(Star1Details objS1Details, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.SetStar1Details.SP_SetStar1Details);

            db.AddInParameter(dbcomand, Resources.SetStar1Details.PARAM_ProfileName, DbType.String, objS1Details.ProfileName);
            db.AddInParameter(dbcomand, Resources.SetStar1Details.PARAM_CustomerDK, DbType.String, objS1Details.CustomerDk);
            db.AddInParameter(dbcomand, Resources.SetStar1Details.PARAM_PCC, DbType.String, objS1Details.Pcc);
            db.AddInParameter(dbcomand, Resources.SetStar1Details.PARAM_CompanyName, DbType.String, objS1Details.CompanyName);
            db.AddInParameter(dbcomand, Resources.SetStar1Details.PARAM_Telephone, DbType.String, objS1Details.Phone);
            db.AddInParameter(dbcomand, Resources.SetStar1Details.PARAM_Ext, DbType.String, objS1Details.Ext);
            db.AddInParameter(dbcomand, Resources.SetStar1Details.PARAM_TravelPolicies, DbType.String, objS1Details.TravelPolicies);
            db.AddInParameter(dbcomand, Resources.SetStar1Details.PARAM_SocialReason, DbType.String, objS1Details.SocialReason);
            db.AddInParameter(dbcomand, Resources.SetStar1Details.PARAM_Street, DbType.String, objS1Details.Street);
            db.AddInParameter(dbcomand, Resources.SetStar1Details.PARAM_OutsideNumber, DbType.String, objS1Details.OutsideNumber);
            db.AddInParameter(dbcomand, Resources.SetStar1Details.PARAM_InternalNumber, DbType.String, objS1Details.InternalNumber);
            db.AddInParameter(dbcomand, Resources.SetStar1Details.PARAM_Colony, DbType.String, objS1Details.Colony);
            db.AddInParameter(dbcomand, Resources.SetStar1Details.PARAM_Municipality, DbType.String, objS1Details.Municipality);
            db.AddInParameter(dbcomand, Resources.SetStar1Details.PARAM_PostalCode, DbType.String, objS1Details.PostalCode);
            db.AddInParameter(dbcomand, Resources.SetStar1Details.PARAM_City, DbType.String, objS1Details.City);
            db.AddInParameter(dbcomand, Resources.SetStar1Details.PARAM_State, DbType.String, objS1Details.State);
            db.AddInParameter(dbcomand, Resources.SetStar1Details.PARAM_RFC, DbType.String, objS1Details.Rfc);
            db.AddInParameter(dbcomand, Resources.SetStar1Details.PARAM_CreditCard, DbType.String, objS1Details.CreditCard);
            db.AddInParameter(dbcomand, Resources.SetStar1Details.PARAM_ExpiratioDate, DbType.String, objS1Details.ExpirationDate);
            db.AddInParameter(dbcomand, Resources.SetStar1Details.PARAM_ContactCompany, DbType.String, objS1Details.ContactCompany);
            db.AddInParameter(dbcomand, Resources.SetStar1Details.PARAM_Email, DbType.String, objS1Details.Email);
            db.AddInParameter(dbcomand, Resources.SetStar1Details.PARAM_Comments, DbType.String, objS1Details.Comments);
            db.AddInParameter(dbcomand, Resources.SetStar1Details.PARAM_CreatedBy, DbType.String, objS1Details.CreatedBy);
            db.AddInParameter(dbcomand, Resources.SetStar1Details.PARAM_Password, DbType.String, objS1Details.Password);
            //db.AddInParameter(dbcomand, Resources.SetStar1Details.PARAM_ExtraData, DbType.String, extraData);

            db.ExecuteNonQuery(dbcomand);
        }
    }
}
