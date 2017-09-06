using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class UpdateQCbyAttribute1_ADBL
    {
        public static void UpdateQCbyAttribute1_AD(string attribute1, string deleteAccountingLines, string deleteAccountingRemarks,
                            string cuotingActualFare, string comparativeMoreEconomicFareNotAvailable,
                            string comparativeMoreEconomicFareAvailable, string comparativeStandardFare,
                            string classComparativeStandard, string comparativeSpecificFare,
                            string classComparativeSpecific, string comparativeBusinessFare,
                            string classComparativeBusiness1, string classComparativeBusiness2,
                            string classComparativeBusiness3, string classComparativeBusiness4,
                            string comparativeSoldFareVSMoreEconomicFareNotAvailable, string fareJustification,
                            string applyComparativeMoreEconomicFare, string chargePerService,
                            string remarksAvailableClasses, string remarkContableAuthorization,
                            string qcAuthorized, string labelQC, string cancellation, string fareRemark,
                            string verifyTicketEmission,string getThereQCValues, string reservationSendQCClient, string emissionSendQCClient,
                            string c1, string c2, string c3, string c4, string c5, string c6, string c7, string c8,
                            string c9, string c10, string c11, string c12, string c13, string c14, string c15,
                            string c16, string c17, string c18, string c19, string c20, string c21, string c22,
                            string c23, string c24, string c25, string c26, string c27, string c28, string c29,
                            string c30, string c31, string c32, string c33, string c34, string c35, string c36,
                            string c37, string c38, string c39, string c40, string c41, string c42, string c43,
                            string c44, string c45, string c46, string c47, string c48, string c49, string c50,
                            string c51, string c52, string c53, string c54, string c55, string c56, string c57,
                            string c58, string c59, string c60, string c61, string c62, string c63, string c64,
                            string c65, string c66, string c67, string c68, string c69, string c70, string c71,
                            string c72, string c73, string c74, string c75, string c76, string c77, string c78,
                            string c79, string c80, string c81, string c82, string c83, string c84, string c85,
                            string c86, string c87, string c88, string c89, string c90, string c91, string c92,
                            string c93, string c94, string c95, string c96, string c97, string c98, string c99,
                            string c100, string costCenters)
        {
            UpdateQCbyAttribute1_ADDAL objQC = new UpdateQCbyAttribute1_ADDAL();
            try
            {
                    objQC.UpdateQCbyAttribute1_AD(attribute1,deleteAccountingLines,deleteAccountingRemarks,cuotingActualFare,comparativeMoreEconomicFareNotAvailable,comparativeMoreEconomicFareAvailable,comparativeStandardFare,
                    classComparativeStandard,comparativeSpecificFare,classComparativeSpecific,comparativeBusinessFare,classComparativeBusiness1,classComparativeBusiness2,classComparativeBusiness3,classComparativeBusiness4,
                    comparativeSoldFareVSMoreEconomicFareNotAvailable,fareJustification,applyComparativeMoreEconomicFare,chargePerService,remarksAvailableClasses,remarkContableAuthorization,qcAuthorized,labelQC,cancellation,
                    fareRemark,verifyTicketEmission, getThereQCValues, reservationSendQCClient,emissionSendQCClient,c1,c2,c3,c4,c5,c6,c7,c8,c9,c10,c11,c12,c13,c14,c15,c16,c17,c18,c19,c20,c21,c22,c23,c24,c25,c26,c27,c28,c29,c30,c31,c32,c33,c34,
                    c35,c36,c37,c38,c39,c40,c41,c42,c43,c44,c45,c46,c47,c48,c49,c50,c51,c52,c53,c54,c55,c56,c57,c58,c59,c60,c61,c62,c63,c64,c65,c66,c67,c68,c69,c70,c71,c72,c73,c74,c75,c76,c77,c78,c79,c80,c81,c82,c83,c84,c85,
                    c86,c87,c88,c89,c90,c91,c92,c93,c94,c95,c96,c97,c98,c99,c100,costCenters, CommonENT.MYCTSDB_CONNECTION);
            }
            catch (Exception ex)
            {
                try
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objQC.UpdateQCbyAttribute1_AD(attribute1, deleteAccountingLines, deleteAccountingRemarks, cuotingActualFare, comparativeMoreEconomicFareNotAvailable, comparativeMoreEconomicFareAvailable, comparativeStandardFare,
                    classComparativeStandard, comparativeSpecificFare, classComparativeSpecific, comparativeBusinessFare, classComparativeBusiness1, classComparativeBusiness2, classComparativeBusiness3, classComparativeBusiness4,
                    comparativeSoldFareVSMoreEconomicFareNotAvailable, fareJustification, applyComparativeMoreEconomicFare, chargePerService, remarksAvailableClasses, remarkContableAuthorization, qcAuthorized, labelQC, cancellation,
                    fareRemark, verifyTicketEmission, getThereQCValues, reservationSendQCClient, emissionSendQCClient, c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26, c27, c28, c29, 
                    c30, c31, c32, c33, c34,c35, c36, c37, c38, c39, c40, c41, c42, c43, c44, c45, c46, c47, c48, c49, c50, c51, c52, c53, c54, c55, c56, c57, c58, c59, c60, c61, c62, c63, c64, c65, c66, c67, c68, c69, c70, c71, c72, c73, 
                    c74, c75, c76, c77, c78, c79, c80, c81, c82, c83, c84, c85,c86, c87, c88, c89, c90, c91, c92, c93, c94, c95, c96, c97, c98, c99, c100, costCenters, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
                catch { }
            }
        }
    }
}
