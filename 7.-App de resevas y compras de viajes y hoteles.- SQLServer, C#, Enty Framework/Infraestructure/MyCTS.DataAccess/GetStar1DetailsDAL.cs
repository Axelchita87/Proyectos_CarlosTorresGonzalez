using System;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using MyCTS.Entities;
using MyCTS.Components.NullableHelper;

namespace MyCTS.DataAccess
{
    public class GetStar1DetailsDAL
    {
        public Star1Details ObjGetStar1Details(string pcc, string profileName , string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetStar1DetailsResources.SP_GetStar1Details);
            db.AddInParameter(dbCommand, Resources.GetStar1DetailsResources.PARAM_PCC, DbType.String, pcc);
            db.AddInParameter(dbCommand, Resources.GetStar1DetailsResources.PARAM_ProfileName, DbType.String, profileName);
            var item = new Star1Details();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
               int _id = dr.GetOrdinal(Resources.GetStar1DetailsResources.PARAM_Id);
               int _city = dr.GetOrdinal(Resources.GetStar1DetailsResources.PARAM_City);
               int _colony = dr.GetOrdinal(Resources.GetStar1DetailsResources.PARAM_Colony);
               int _comments = dr.GetOrdinal(Resources.GetStar1DetailsResources.PARAM_Comments);
               int _companyName = dr.GetOrdinal(Resources.GetStar1DetailsResources.PARAM_CompanyName);
               int _contactCompany = dr.GetOrdinal(Resources.GetStar1DetailsResources.PARAM_ContactCompany);
               int _createdBy = dr.GetOrdinal(Resources.GetStar1DetailsResources.PARAM_CreatedBy);
               int _creditCard = dr.GetOrdinal(Resources.GetStar1DetailsResources.PARAM_CreditCard);
               int _customerDK = dr.GetOrdinal(Resources.GetStar1DetailsResources.PARAM_CustomerDK);
               int _email = dr.GetOrdinal(Resources.GetStar1DetailsResources.PARAM_Email);
               int _expiratioDate = dr.GetOrdinal(Resources.GetStar1DetailsResources.PARAM_ExpiratioDate);
               int _ext = dr.GetOrdinal(Resources.GetStar1DetailsResources.PARAM_Ext);
               //int _extraData = dr.GetOrdinal(Resources.GetStar1DetailsResources.PARAM_ExtraData);
               int _internalNumber = dr.GetOrdinal(Resources.GetStar1DetailsResources.PARAM_InternalNumber);
               int _municipality = dr.GetOrdinal(Resources.GetStar1DetailsResources.PARAM_Municipality);
               int _0utsideNumber = dr.GetOrdinal(Resources.GetStar1DetailsResources.PARAM_OutsideNumber);
               int _password = dr.GetOrdinal(Resources.GetStar1DetailsResources.PARAM_Password);
               int _pcc = dr.GetOrdinal(Resources.GetStar1DetailsResources.PARAM_PCC);
               int _postalCode = dr.GetOrdinal(Resources.GetStar1DetailsResources.PARAM_PostalCode);
               int _profileName = dr.GetOrdinal(Resources.GetStar1DetailsResources.PARAM_ProfileName);
               int _rfc = dr.GetOrdinal(Resources.GetStar1DetailsResources.PARAM_RFC);
               int _socialReason = dr.GetOrdinal(Resources.GetStar1DetailsResources.PARAM_SocialReason);
               int _state = dr.GetOrdinal(Resources.GetStar1DetailsResources.PARAM_State);
               int _street = dr.GetOrdinal(Resources.GetStar1DetailsResources.PARAM_Street);
               int _phone = dr.GetOrdinal(Resources.GetStar1DetailsResources.PARAM_Telephone);
               int _travelPolicies = dr.GetOrdinal(Resources.GetStar1DetailsResources.PARAM_TravelPolicies);

                while (dr.Read())
                {

                    item.Id = (dr[_id] == DBNull.Value) ? Types.StringNullValue : dr.GetInt32(_id).ToString();
                    item.City = (dr[_city] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_city);
                    item.Colony = (dr[_colony] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_colony);
                    item.Comments = (dr[_comments] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_comments);
                    item.CompanyName = (dr[_companyName] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_companyName);
                    item.ContactCompany = (dr[_contactCompany] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_contactCompany);
                    item.CreatedBy = (dr[_createdBy] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_createdBy);
                    item.CreditCard = (dr[_creditCard] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_creditCard);
                    item.CustomerDk = (dr[_customerDK] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_customerDK);
                    item.Email = (dr[_email] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_email);
                    item.ExpirationDate = (dr[_expiratioDate] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_expiratioDate);
                    item.Ext = (dr[_ext] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_ext);
                    item.InternalNumber = (dr[_internalNumber] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_internalNumber);
                    item.Municipality = (dr[_municipality] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_municipality);
                    item.OutsideNumber = (dr[_0utsideNumber] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_0utsideNumber);
                    item.Password = (dr[_password] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_password);
                    item.Pcc = (dr[_pcc] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_pcc);
                    item.PostalCode = (dr[_postalCode] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_postalCode);
                    item.ProfileName = (dr[_profileName] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_profileName);
                    item.Rfc = (dr[_rfc] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_rfc);
                    item.SocialReason = (dr[_socialReason] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_socialReason);
                    item.State = (dr[_state] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_state);
                    item.Street = (dr[_street] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_street);
                    item.Phone = (dr[_phone] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_phone);
                    item.TravelPolicies = (dr[_travelPolicies] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_travelPolicies);
             

                    
                }
            }

            return item;
        }
    }
}
