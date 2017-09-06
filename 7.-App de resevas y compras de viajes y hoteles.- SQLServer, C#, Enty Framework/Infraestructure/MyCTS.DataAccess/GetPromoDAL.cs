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
    public class GetPromoDAL
    {
        public Promo GetPromo(string airline, string typeCard, string bank, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetPromoResources.SP_GetPromo);
            db.AddInParameter(dbCommand, Resources.GetPromoResources.PARAM_QUERY_AIRLINE, DbType.String, airline);
            db.AddInParameter(dbCommand, Resources.GetPromoResources.PARAM_QUERY_TYPE_CARD, DbType.String, typeCard);
            db.AddInParameter(dbCommand, Resources.GetPromoResources.PARAM_BANK, DbType.String, bank);
            Promo objPromo=new Promo();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _airline = dr.GetOrdinal(Resources.GetPromoResources.PARAM_AIRLINE);
                int _typecard = dr.GetOrdinal(Resources.GetPromoResources.PARAM_TYPE_CARD);
                int _emissionbank = dr.GetOrdinal(Resources.GetPromoResources.PARAM_EMISSION_BANK);
                int _datepromobegin = dr.GetOrdinal(Resources.GetPromoResources.PARAM_DATE_PROMO_BEGIN);
                int _datepromoend = dr.GetOrdinal(Resources.GetPromoResources.PARAM_DATE_PROMO_END);
                int _monthswithinterest = dr.GetOrdinal(Resources.GetPromoResources.PARAM_MONTHS_WITH_INTEREST);
                int _monthswithoutinterest = dr.GetOrdinal(Resources.GetPromoResources.PARAM_MONTHS_WITHOUT_INTEREST);
                int _description = dr.GetOrdinal(Resources.GetPromoResources.PARAM_DESCRIPTION);
                int _amount = dr.GetOrdinal(Resources.GetPromoResources.PARAM_AMOUNT);
                int _origen = dr.GetOrdinal(Resources.GetPromoResources.PARAM_ORIGEN);
                int _destination = dr.GetOrdinal(Resources.GetPromoResources.PARAM_DESTINATION);
                int _origenzone = dr.GetOrdinal(Resources.GetPromoResources.PARAM_ORIGEN_ZONE);
                int _destinationzone = dr.GetOrdinal(Resources.GetPromoResources.PARAM_DESTINATION_ZONE);
                int _countryemission = dr.GetOrdinal(Resources.GetPromoResources.PARAM_COUNTRY_EMISSION);
                int _sharedflight = dr.GetOrdinal(Resources.GetPromoResources.PARAM_SHARED_FLIGHT);
                int _includedclasses = dr.GetOrdinal(Resources.GetPromoResources.PARAM_INCLUDED_CLASSES);
                int _excludedclasses = dr.GetOrdinal(Resources.GetPromoResources.PARAM_EXCLUDED_CLASSES);
                int _applydatepromoflight = dr.GetOrdinal(Resources.GetPromoResources.PARAM_APPLY_DATE_PROMO_FLIGHT);

                try
                {
                    if (dr.Read())
                    {
                        objPromo.Airline = (dr[_airline] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_airline);
                        objPromo.TypeCard = (dr[_typecard] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_typecard);
                        objPromo.EmissionBank = (dr[_emissionbank] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_emissionbank);
                        objPromo.DatePromoBegin = (dr[_datepromobegin] == DBNull.Value) ? Types.DateNullValue : dr.GetDateTime(_datepromobegin);
                        objPromo.DatePromoEnd = (dr[_datepromoend] == DBNull.Value) ? Types.DateNullValue : dr.GetDateTime(_datepromoend);
                        objPromo.MonthsWithInterest = (dr[_monthswithinterest] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_monthswithinterest);
                        objPromo.MonthsWithoutInterest = (dr[_monthswithoutinterest] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_monthswithoutinterest);
                        objPromo.Description = (dr[_description] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_description);
                        objPromo.Amount = (dr[_amount] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_amount);
                        objPromo.Origen = (dr[_origen] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_origen);
                        objPromo.Destination = (dr[_destination] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_destination);
                        objPromo.OrigenZone = (dr[_origenzone] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_origenzone);
                        objPromo.DestinationZone = (dr[_destinationzone] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_destinationzone);
                        objPromo.CountryEmission = (dr[_countryemission] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_countryemission);
                        objPromo.SharedFlight = dr.GetBoolean(_sharedflight);
                        objPromo.IncludedClasses = (dr[_includedclasses] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_includedclasses);
                        objPromo.ExcludedClasses = (dr[_excludedclasses] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_excludedclasses);
                        objPromo.ApplyDatePromoFlight = dr.GetBoolean(_applydatepromoflight);
                    }
                }
                catch { }
            }
            return objPromo;
        }
    }
}
