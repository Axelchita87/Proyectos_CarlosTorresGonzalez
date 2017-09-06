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
    public class GetBannerImageDAL
    {
        public List<BannerImage> GetBannerImages(string ControlIndex, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetBannerImageResources.SP_GET_BANNER_IMAGE);
            db.AddInParameter(dbCommand, Resources.GetBannerImageResources.PARAM_CONTROLINDEX, DbType.String, ControlIndex);
            List<BannerImage> BannerImageList = new List<BannerImage>();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _content = dr.GetOrdinal(Resources.GetBannerImageResources.FIELD_CONTENT);
                int _name = dr.GetOrdinal(Resources.GetBannerImageResources.FIELD_NAME);
                int _extension = dr.GetOrdinal(Resources.GetBannerImageResources.FIELD_EXTENSION);
                int _url = dr.GetOrdinal(Resources.GetBannerImageResources.FIELD_URL);
                int _activate = dr.GetOrdinal(Resources.GetBannerImageResources.FIELD_ACTIVATE);

                while (dr.Read())
                {
                    BannerImage item = new BannerImage();
                    item.Content = (byte[])dr[_content];
                    item.Name = (dr[_name] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_name);
                    item.Extension = (dr[_extension] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_extension);
                    item.Url = (dr[_url] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_url);
                    item.Activate = (dr[_activate] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_activate);

                    BannerImageList.Add(item);
                }
            }
            return BannerImageList;
        }
    }
}
