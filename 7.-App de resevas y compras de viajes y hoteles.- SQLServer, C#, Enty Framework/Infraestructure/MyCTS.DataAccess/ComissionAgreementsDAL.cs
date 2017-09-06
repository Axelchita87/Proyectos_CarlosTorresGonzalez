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
    public class ComissionAgreementsDAL
    {
        public List<ComissionAgreements> GetComissionAgreements(string StrToSearch, string airlineID, bool internationalFlight, string classType, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.ComissionAgreementsResources.SP_GetComissionAgreements);
            db.AddInParameter(dbCommand, Resources.ComissionAgreementsResources.PARAM_QUERY1, DbType.String, StrToSearch);
            db.AddInParameter(dbCommand, Resources.ComissionAgreementsResources.PARAM_QUERY2, DbType.String, airlineID);
            db.AddInParameter(dbCommand, Resources.ComissionAgreementsResources.PARAM_QUERY3, DbType.Boolean, internationalFlight);
            db.AddInParameter(dbCommand, Resources.ComissionAgreementsResources.PARAM_QUERY4, DbType.String, classType);

            List<ComissionAgreements> ComissionAgreementsList = new List<ComissionAgreements>();
            if (!internationalFlight)
            {
                using (IDataReader dr = db.ExecuteReader(dbCommand))
                {
                    int _domesticcommision = dr.GetOrdinal(Resources.ComissionAgreementsResources.PARAM_DOMESTICCOMISSION);
                    int _tourcode = dr.GetOrdinal(Resources.ComissionAgreementsResources.PARAM_TOURCODE);
                    int _osi = dr.GetOrdinal(Resources.ComissionAgreementsResources.PARAM_OSI);
                    int _itcode = dr.GetOrdinal(Resources.ComissionAgreementsResources.PARAM_ITCODE);
                    int _itccommand = dr.GetOrdinal(Resources.ComissionAgreementsResources.PARAM_ITCCOMMAND);

                    while (dr.Read())
                    {
                        ComissionAgreements item = new ComissionAgreements();
                        item.DomesticCommision = (dr[_domesticcommision] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_domesticcommision);
                        item.TourCode = (dr[_tourcode] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_tourcode);
                        item.OSI = (dr[_osi] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_osi);
                        item.ITCode = (dr[_itcode] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_itcode);
                        item.ITCCommand = (dr[_itccommand] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_itccommand);
                        ComissionAgreementsList.Add(item);
                    }
                }
            }
            else
            {
                using (IDataReader dr = db.ExecuteReader(dbCommand))
                {
                    int _internationalcommision = dr.GetOrdinal(Resources.ComissionAgreementsResources.PARAM_INTERNATIONALCOMISSION);
                    int _tourcode = dr.GetOrdinal(Resources.ComissionAgreementsResources.PARAM_TOURCODE);
                    int _osi = dr.GetOrdinal(Resources.ComissionAgreementsResources.PARAM_OSI);
                    int _itcode = dr.GetOrdinal(Resources.ComissionAgreementsResources.PARAM_ITCODE);
                    int _itccommand = dr.GetOrdinal(Resources.ComissionAgreementsResources.PARAM_ITCCOMMAND);

                    while (dr.Read())
                    {
                        ComissionAgreements item = new ComissionAgreements();
                        item.InternationalCommision = (dr[_internationalcommision] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_internationalcommision);
                        item.TourCode = (dr[_tourcode] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_tourcode);
                        item.OSI = (dr[_osi] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_osi);
                        item.ITCode = (dr[_itcode] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_itcode);
                        item.ITCCommand = (dr[_itccommand] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_itccommand);
                        ComissionAgreementsList.Add(item);
                    }
                }
            }
            return ComissionAgreementsList;
        }
    }
}
