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
    public class CtaDHLDAL
    {
        public List<CtaDHL> GetCtaDHL(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CtaDHLResources.SP_GetCtaDHL);
            List<CtaDHL> CtaDHLList = new List<CtaDHL>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _cta = dr.GetOrdinal(Resources.CtaDHLResources.PARAM_CTA);



                while (dr.Read())
                {
                    CtaDHL item = new CtaDHL();
                    item.Cta = dr.GetString(_cta);
                    CtaDHLList.Add(item);
                }
            }

            return CtaDHLList;

        }
    }
}
