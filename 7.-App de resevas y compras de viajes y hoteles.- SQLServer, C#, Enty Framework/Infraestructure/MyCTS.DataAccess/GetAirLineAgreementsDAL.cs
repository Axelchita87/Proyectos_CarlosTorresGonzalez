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
    public class GetAirLineAgreementsDAL
    {
        public List<GetAirLineAgreements> GetAirLineAgreements(string AlCodeToSearch, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetAirLineAgreementsResources.SP_GetAirLineAgreements);
            db.AddInParameter(dbCommand, Resources.GetAirLineAgreementsResources.PARAM_QUERY, DbType.String, AlCodeToSearch);

            List<GetAirLineAgreements> ALAgreementList = new List<GetAirLineAgreements>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _idalcode = dr.GetOrdinal(Resources.GetAirLineAgreementsResources.PARAM_IDAlCODE);
                int _internationalcomission = dr.GetOrdinal(Resources.GetAirLineAgreementsResources.PARAM_INTERCOMISSION);
                int _domesticcomission = dr.GetOrdinal(Resources.GetAirLineAgreementsResources.PARAM_DOMESTICCOMISSION);
                int _tourcode = dr.GetOrdinal(Resources.GetAirLineAgreementsResources.PARAM_TOURCODE);
                int _osi = dr.GetOrdinal(Resources.GetAirLineAgreementsResources.PARAM_OSI);

                while (dr.Read())
                {
                    GetAirLineAgreements item = new GetAirLineAgreements();
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
