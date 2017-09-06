using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Components.NullableHelper;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace MyCTS.DataAccess
{
    public class CatOnlineToolsPicCodesDAL
    {
        public List<CatOnlineToolsPicCodes> GetPicCodes(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatOnlineToolsPicCodesResources.SP_GetCatOnlineToolsPicCodes);
            List<CatOnlineToolsPicCodes> CatPicCodesList = new List<CatOnlineToolsPicCodes>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _piccode = dr.GetOrdinal(Resources.CatOnlineToolsPicCodesResources.PARAM_PICCODE);
                int _description = dr.GetOrdinal(Resources.CatOnlineToolsPicCodesResources.PARAM_DESCRIPTION);


                while (dr.Read())
                {
                    CatOnlineToolsPicCodes item = new CatOnlineToolsPicCodes();
                    item.PicCode = (dr[_piccode] == DBNull.Value) ? Types.IntegerNullValue : dr.GetInt32(_piccode);
                    item.Description = (dr[_description] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_description);
                    CatPicCodesList.Add(item);
                }
            }

            return CatPicCodesList;

        }
    }
}
