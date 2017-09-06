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
    public class Cat1stStarInfoByLocationDAL
    {
        public Cat1stStarInfoByLocation GetstStarInfoByLocation(string Location, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.Cat1stStarInfoByLocationResources.SP_Get1stStarInfoByLocation);
            db.AddInParameter(dbCommand, Resources.Cat1stStarInfoByLocationResources.PARAM_QUERY, DbType.String, Location);

            Cat1stStarInfoByLocation item = null;
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _location = dr.GetOrdinal(Resources.Cat1stStarInfoByLocationResources.PARAM_LOCATION);
                int _attribute1 = dr.GetOrdinal(Resources.Cat1stStarInfoByLocationResources.PARAM_ATTRIBUTE1);
                int _customername = dr.GetOrdinal(Resources.Cat1stStarInfoByLocationResources.PARAM_CUSTOMER_NAME);
                int _address = dr.GetOrdinal(Resources.Cat1stStarInfoByLocationResources.PARAM_ADDRESS);
                int _address1 = dr.GetOrdinal(Resources.Cat1stStarInfoByLocationResources.PARAM_ADDRESS1);
                int _address2 = dr.GetOrdinal(Resources.Cat1stStarInfoByLocationResources.PARAM_ADDRESS2);
                int _address3 = dr.GetOrdinal(Resources.Cat1stStarInfoByLocationResources.PARAM_ADDRESS3);
                int _address4 = dr.GetOrdinal(Resources.Cat1stStarInfoByLocationResources.PARAM_ADDRESS4);
                int _city = dr.GetOrdinal(Resources.Cat1stStarInfoByLocationResources.PARAM_CITY);
                int _municipality = dr.GetOrdinal(Resources.Cat1stStarInfoByLocationResources.PARAM_MUNICIPALITY);
                int _postalcode = dr.GetOrdinal(Resources.Cat1stStarInfoByLocationResources.PARAM_POSTAL_CODE);
                int _state = dr.GetOrdinal(Resources.Cat1stStarInfoByLocationResources.PARAM_STATE);
                int _rfc = dr.GetOrdinal(Resources.Cat1stStarInfoByLocationResources.PARAM_RFC);
                int _mainphone = dr.GetOrdinal(Resources.Cat1stStarInfoByLocationResources.PARAM_MAIN_PHONE);
        
                if (dr.Read())
                {
                    item = new Cat1stStarInfoByLocation();
                    item.Location = (dr[_location] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_location);
                    item.Attribute1 = (dr[_attribute1] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_attribute1);
                    item.CustomerName = (dr[_customername] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_customername);
                    item.Address = (dr[_address] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_address);
                    item.Address1 = (dr[_address1] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_address1);
                    item.Address2 = (dr[_address2] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_address2);
                    item.Address3 = (dr[_address3] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_address3);
                    item.Address4 = (dr[_address4] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_address4);
                    item.City = (dr[_city] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_city);
                    item.Municipality = (dr[_municipality] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_municipality);
                    item.PostalCode = (dr[_postalcode] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_postalcode);
                    item.State = (dr[_state] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_state);
                    item.RFC = (dr[_rfc] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_rfc);
                    item.MainPhone = (dr[_mainphone] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_mainphone);
                }
            }

            return item;
        }
    }
}
