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
    public class CatCorporativeQualityControlsDAL
    {
        public List<CatCorporativeQualityControls> GetCorporativeQualityControls(string Attribute1, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatCorporativeQualityControlsResources.SP_GetCorporativeQualityControls);
            db.AddInParameter(dbCommand, Resources.CatCorporativeQualityControlsResources.PARAM_QUERY, DbType.String, Attribute1);

            List<CatCorporativeQualityControls> CorporativeQualityControlsList = new List<CatCorporativeQualityControls>();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _attribute1 = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_ATTRIBUTE1);
                //int _corporativeidicaav = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_CORPORATIVEIDICAAV);
                int _status = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_STATUS);
                int _deleteaccountinglines = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_DELETEACCOUNTINGLINES);
                int _deleteaccountingremarks = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_DELETEACCOUNTINGREMARKS);
                int _cuotingactualfare = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_CUOTINGACTUALFARE);
                int _comparativemoreeconomicfarenotavailable = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_COMPARATIVEMOREECONOMICFARENOTAVAILABLE);
                int _comparativemoreeconomicfareavailable = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_COMPARATIVEMOREECONOMICFAREAVAILABLE);
                int _comparativestandardfare = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_COMPARATIVESTANDARDFARE);
                int _classcomparativestandard = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_CLASSCOMPARATIVESTANDARD);
                int _comparativespecificfare = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_COMPARATIVESPECIFICFARE);
                int _classcomparativespecific = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_CLASSCOMPARATIVESPECIFIC);
                int _comparativebusinessfare = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_COMPARATIVEBUSINESSFARE);
                int _classcomparativebusiness1 = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_CLASSCOMPARATIVEBUSINESS1);
                int _classcomparativebusiness2 = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_CLASSCOMPARATIVEBUSINESS2);
                int _classcomparativebusiness3 = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_CLASSCOMPARATIVEBUSINESS3);
                int _classcomparativebusiness4 = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_CLASSCOMPARATIVEBUSINESS4);
                int _comparativesoldfarevsmoreeconomicfarenotavailable = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_COMPARATIVESOLDFAREVSMOREECONOMICFARENOTAVAILABLE);
                int _farejustification = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_FAREJUSTIFICATION);
                int _chargeperservice = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_CHARGEPERSERVICE);
                int _remarksavailableclasses = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_REMARKAVAILABLECLASS);
                int _remarkcontableauthorization = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_REMARKCONTABLEAUTHORIZATION);
                int _qcauthorized = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_QCAUTHORIZED);
                int _labelqc = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_LABELQC);
                int _applycomparativemoreeconomicfare = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_APPLYCOMPARATIVEMOREECONOMICFARE);

                int _remarkcmefna = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_REMARKCMEFNA);
                int _remarkcmefa = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_REMARKCMEFA);
                int _remarkcstdf = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_REMARKCSTDF);
                int _remarkcspcf = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_REMARKCSPCF);
                int _remarkcbnsf = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_REMARKCBNSF);
                int _remarkfj = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_REMARKFJ);
                int _remarkrobot = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_REMARK_ROBOT);
                int _fareremark = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_FARE_REMARK);
                int _verifyticketemission = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_VERIFY_TICKET_EMISSION);
                int _getthereqcvalues = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_GETTHEREQCVALUES);
                int _reservationsendqcclient = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_RESERVATIONSENDQCCLIENT);
                int _emissionsendqcclient = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_EMISSIONSENDQCCLIENT);
                int _clientremarktype = dr.GetOrdinal(Resources.CatCorporativeQualityControlsResources.PARAM_CLIENTREMARKTYPE);

                while (dr.Read())
                {
                    CatCorporativeQualityControls item = new CatCorporativeQualityControls();

                    item.Attribute1 = (dr[_attribute1] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_attribute1);
                    //item.CorporativeIDICAAV = (dr[_corporativeidicaav] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_corporativeidicaav);
                    item.Status = (dr[_status] == DBNull.Value) ? Types.IntegerNullValue : dr.GetInt32(_status);
                    item.DeleteAccountingLines = (dr[_deleteaccountinglines] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_deleteaccountinglines);
                    item.DeleteAccountingRemarks = (dr[_deleteaccountingremarks] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_deleteaccountingremarks);
                    item.CuotingActualFare = (dr[_cuotingactualfare] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_cuotingactualfare);
                    item.ComparativeMoreEconomicFareNotAvailable = (dr[_comparativemoreeconomicfarenotavailable] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_comparativemoreeconomicfarenotavailable);
                    item.ComparativeMoreEconomicFareAvailable = (dr[_comparativemoreeconomicfareavailable] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_comparativemoreeconomicfareavailable);
                    item.ComparativeStandardFare = (dr[_comparativestandardfare] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_comparativestandardfare);
                    item.ClassComparativeStandard = (dr[_classcomparativestandard] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_classcomparativestandard);
                    item.ComparativeSpecificFare = (dr[_comparativespecificfare] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_comparativespecificfare);
                    item.ClassComparativeSpecific = (dr[_classcomparativespecific] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_classcomparativespecific);
                    item.ComparativeBusinessFare = (dr[_comparativebusinessfare] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_comparativebusinessfare);
                    item.ClassComparativeBusiness1 = (dr[_classcomparativebusiness1] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_classcomparativebusiness1);
                    item.ClassComparativeBusiness2 = (dr[_classcomparativebusiness2] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_classcomparativebusiness2);
                    item.ClassComparativeBusiness3 = (dr[_classcomparativebusiness3] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_classcomparativebusiness3);
                    item.ClassComparativeBusiness4 = (dr[_classcomparativebusiness4] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_classcomparativebusiness4);
                    item.ComparativeSoldFareVSMoreEconomicFareNotAvailable = (dr[_comparativesoldfarevsmoreeconomicfarenotavailable] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_comparativesoldfarevsmoreeconomicfarenotavailable);
                    item.FareJustification = (dr[_farejustification] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_farejustification);
                    item.ChargePerService = (dr[_chargeperservice] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_chargeperservice);
                    item.RemarksAvailableClasses = (dr[_remarksavailableclasses] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_remarksavailableclasses);
                    item.RemarkContableAuthorization = (dr[_remarkcontableauthorization] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_remarkcontableauthorization);
                    item.QCAuthorized = (dr[_qcauthorized] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_qcauthorized);
                    item.LabelQC = (dr[_labelqc] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_labelqc);
                    item.ApplyComparativeMoreEconomicFare = (dr[_applycomparativemoreeconomicfare] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_applycomparativemoreeconomicfare);

                    item.RemarkCMEFNA = (dr[_remarkcmefna] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_remarkcmefna);
                    item.RemarkCMEFA = (dr[_remarkcmefa] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_remarkcmefa);
                    item.RemarkCStdF = (dr[_remarkcstdf] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_remarkcstdf);
                    item.RemarkCSpcF = (dr[_remarkcspcf] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_remarkcspcf);
                    item.RemarkCBnsF = (dr[_remarkcbnsf] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_remarkcbnsf);
                    item.RemarkFJ = (dr[_remarkfj] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_remarkfj);
                    item.RemarkRobot = (dr[_remarkrobot] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_remarkrobot);
                    item.FareRemark = (dr[_fareremark] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_fareremark);
                    item.verifyTicketEmission = (dr[_verifyticketemission] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_verifyticketemission);
                    item.GetThereQCValues = dr.GetBoolean(_getthereqcvalues);
                    item.ReservationSendQCClient = (dr[_reservationsendqcclient] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_reservationsendqcclient);
                    item.EmissionSendQCClient = (dr[_emissionsendqcclient] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_emissionsendqcclient);
                    item.ClientRemarkType = (dr[_clientremarktype] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_clientremarktype);

                    CorporativeQualityControlsList.Add(item);
                }

            }
            return CorporativeQualityControlsList;
        }

    }
}
