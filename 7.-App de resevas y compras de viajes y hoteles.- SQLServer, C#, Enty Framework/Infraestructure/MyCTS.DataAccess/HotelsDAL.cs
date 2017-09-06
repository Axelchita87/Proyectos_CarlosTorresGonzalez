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
    public class HotelsDAL
    {

        public List<Hotels> GetHotels(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.HotelResources.SP_GetHotels);

            List<Hotels> hotelsList = new List<Hotels>();
            
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _id = dr.GetOrdinal(Resources.HotelResources.PARAM_HOTELID);
                int _namechain = dr.GetOrdinal(Resources.HotelResources.PARAM_HOTELNAMECHAIN);
                
                while (dr.Read())
                {
                    Hotels item = new Hotels();
                    item.HotelID = dr.GetString(_id); 
                    item.HotelNameChain = (dr[_namechain]==null) ? Types.StringNullValue : dr.GetString(_namechain);
                    hotelsList.Add(item);
                }                
            }

            return hotelsList;
        }
        
    }
}
