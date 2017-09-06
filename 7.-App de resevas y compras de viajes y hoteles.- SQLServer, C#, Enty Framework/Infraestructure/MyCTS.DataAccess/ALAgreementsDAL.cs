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
using System.Collections.Specialized;

namespace MyCTS.DataAccess
{
    public class ALAgreementsDAL
    {
        public List<ALAgreements> ALAgreements(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.ALAgreementsResources.SP_GetALAgreements);

            List<ALAgreements> ALAgreementList = new List<ALAgreements>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _idalcode = dr.GetOrdinal(Resources.ALAgreementsResources.PARAM_IDAlCODE);
                int _internationalcomission = dr.GetOrdinal(Resources.ALAgreementsResources.PARAM_INTERCOMISSION);
                int _domesticcomission = dr.GetOrdinal(Resources.ALAgreementsResources.PARAM_DOMESTICCOMISSION);
                int _tourcode = dr.GetOrdinal(Resources.ALAgreementsResources.PARAM_TOURCODE);
                int _osi = dr.GetOrdinal(Resources.ALAgreementsResources.PARAM_OSI);

                while (dr.Read())
                {
                    ALAgreements item = new ALAgreements();
                    item.IDAlCode = dr.GetString(_idalcode);
                    item.InternationalComission = dr.GetString(_internationalcomission);
                    item.DomesticComission = dr.GetString(_domesticcomission);
                    item.TourCode = (dr[_tourcode] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_tourcode);
                    item.OSI = (dr[_osi] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_osi);

                    ALAgreementList.Add(item);

                }

            }

            return ALAgreementList;
        }


    }
}
