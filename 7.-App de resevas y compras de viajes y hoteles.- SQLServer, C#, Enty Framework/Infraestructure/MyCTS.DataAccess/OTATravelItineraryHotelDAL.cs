using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Entities;

namespace MyCTS.DataAccess
{
   public class OTATravelItineraryHotelDAL
    {
        public bool InsertPNR(OTATravelItineraryObjectHotel objItineraryHotel,string connectionName)
        {
            bool insert = false;
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbComand = db.GetStoredProcCommand(Resources.InsertItneraryHotel.SP_INSERTDETAILSPNRHOTEL);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_RECORD, DbType.String, objItineraryHotel.Record);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_CONFIRMATION_NUMBER, DbType.String, objItineraryHotel.Confirmation_Number);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_HOTEL, DbType.String, objItineraryHotel.Hotel);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_PROVID_DIREC_PAY, DbType.Boolean, objItineraryHotel.Prov_Direct_Pay);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_DK, DbType.String, objItineraryHotel.DK);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_PHONE, DbType.String, objItineraryHotel.Phone);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_RFC, DbType.String, objItineraryHotel.RFC);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_MAIL, DbType.String, objItineraryHotel.Mail);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_REQUEST, DbType.String, objItineraryHotel.Request);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_PAYMENT_FORM, DbType.String, objItineraryHotel.Payment_Form);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_CAR_NUMBER, DbType.Int32, objItineraryHotel.Car_Number);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_SALES_SOURCE, DbType.String, objItineraryHotel.Sales_Source);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_OPERATIONAL_UNIT, DbType.String, objItineraryHotel.Operational_Unit == null ? string.Empty : objItineraryHotel.Operational_Unit);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_USER, DbType.String, objItineraryHotel.User);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_SERVICE_TYPE, DbType.String, objItineraryHotel.Service_Type);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_PROVIDER, DbType.String, objItineraryHotel.Provider);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_SITE, DbType.String, objItineraryHotel.Site);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_IN_DATE, DbType.Date, objItineraryHotel.In_Date != DateTime.MinValue ? objItineraryHotel.In_Date : DateTime.Now);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_OUT_DATE, DbType.Date, objItineraryHotel.Out_Date != DateTime.MinValue ? objItineraryHotel.Out_Date : DateTime.Now);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_CITY, DbType.String, objItineraryHotel.City);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_ROOM, DbType.String, objItineraryHotel.Room);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_ROOM_TYPE, DbType.String, objItineraryHotel.Room_Type);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_MEAL_PLAN, DbType.String, objItineraryHotel.Meal_Plan);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_NUMBER_NIGHTS, DbType.Double, objItineraryHotel.Number_Nights);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_PASSENGER_NAME, DbType.String, objItineraryHotel.Passenger_Name);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_PASSENGER_NUM, DbType.Int32, objItineraryHotel.Passenger_Num);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_SURNAME, DbType.String, objItineraryHotel.Surname);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_TITLE, DbType.String, objItineraryHotel.Title);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_PASSENGER_TYPE, DbType.String, objItineraryHotel.Passenger_Type == null ? string.Empty : objItineraryHotel.Passenger_Type.TrimStart('|'));
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_RATE, DbType.String, objItineraryHotel.Rate);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_CURRENCY, DbType.String, objItineraryHotel.Currency);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_PROVIDER_COMMISSION, DbType.String, objItineraryHotel.Provider_Commission);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_COST, DbType.Double, objItineraryHotel.Cost);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_PRICE, DbType.Double, objItineraryHotel.Price);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_TAXES, DbType.Double, objItineraryHotel.IVA);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_CREATED_DATE, DbType.DateTime, objItineraryHotel.C_Date != DateTime.MinValue ? objItineraryHotel.C_Date : DateTime.Now);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_TIME_LIMIT, DbType.Date, objItineraryHotel.Time_Limit != DateTime.MinValue ? objItineraryHotel.Time_Limit : DateTime.Today.AddDays(1));
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_STATUS, DbType.String, objItineraryHotel.Status);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_CANCEL_NUMBER, DbType.String, objItineraryHotel.Cancel_Number == null ? string.Empty : objItineraryHotel.Cancel_Number);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_CHAIN_CODE, DbType.String, objItineraryHotel.ChainCode);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_CHANGE_TYPE, DbType.Double, objItineraryHotel.ChangeType);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_ORG_ID, DbType.Int32, objItineraryHotel.OrgId);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_PCC, DbType.String, objItineraryHotel.Pcc);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_REMAKS_STRING, DbType.String, objItineraryHotel.Remarks);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_USER_NAME, DbType.String, objItineraryHotel.UserName);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_GEAERRORMSG, DbType.String, objItineraryHotel.errorWSSabre);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_DESCRIPTION, DbType.String, objItineraryHotel.Description);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_IN_CITY, DbType.String, objItineraryHotel.In_City);
            db.AddInParameter(dbComand, Resources.InsertItneraryHotel.PARAM_OUT_CITY, DbType.String, objItineraryHotel.Out_City);
                db.ExecuteNonQuery(dbComand);
                insert = true;
           

            return insert;

        }
    }
}
