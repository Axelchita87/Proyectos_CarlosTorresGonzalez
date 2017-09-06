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
    public class ViewCarsDAL
    {
        public List<ViewCars> GetCars(string StrToSearch)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.ViewCarsResources.SP_GetCars);
            db.AddInParameter(dbCommand, Resources.ViewCarsResources.PARAM_QUERY, DbType.String, StrToSearch);

            List<ViewCars> CarsList = new List<ViewCars>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _code = dr.GetOrdinal(Resources.ViewCarsResources.PARAM_CODE);
                int _description = dr.GetOrdinal(Resources.ViewCarsResources.PARAM_DESCRIPTION);

                while (dr.Read())
                {
                    ViewCars item = new ViewCars();
                    item.Code = (dr[_code] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_code);
                    item.Description = (dr[_description] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_description);
                    CarsList.Add(item);


                }
            }

            return CarsList;
        }
    }
}
