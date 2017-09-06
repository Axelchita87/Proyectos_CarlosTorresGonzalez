using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.IO;
using System.Data;
using System.Data.Common;
using MyCTS.Entities;

namespace MyCTS.DataAccess
{
   public class UpdateQCbyAttribute1_ADDAL
    {
        public void UpdateQCbyAttribute1_AD(string attribute1, string deleteAccountingLines, string deleteAccountingRemarks,
                            string cuotingActualFare,string comparativeMoreEconomicFareNotAvailable,
                            string comparativeMoreEconomicFareAvailable, string comparativeStandardFare, 
                            string classComparativeStandard,string comparativeSpecificFare,
                            string classComparativeSpecific, string comparativeBusinessFare, 
                            string classComparativeBusiness1, string classComparativeBusiness2,
                            string classComparativeBusiness3, string classComparativeBusiness4,
                            string comparativeSoldFareVSMoreEconomicFareNotAvailable, string fareJustification,
                            string applyComparativeMoreEconomicFare,string chargePerService,
                            string remarksAvailableClasses, string remarkContableAuthorization,
                            string qcAuthorized, string labelQC,string cancellation, string fareRemark,
                            string verifyTicketEmission,string getThereQCValues, string reservationSendQCClient,string emissionSendQCClient,
                            string c1, string c2,string c3,string c4,string c5,string c6,string c7,string c8,
                            string c9, string c10,string c11, string c12,string c13,string c14,string c15,
                            string c16,string c17,string c18,string c19,string c20,string c21,string c22,
                            string c23,string c24,string c25,string c26,string c27,string c28,string c29,
                            string c30,string c31,string c32,string c33,string c34,string c35,string c36,
                            string c37,string c38,string c39,string c40,string c41,string c42,string c43,
                            string c44,string c45,string c46,string c47,string c48,string c49,string c50,
                            string c51,string c52,string c53,string c54,string c55,string c56,string c57,
                            string c58,string c59,string c60,string c61,string c62,string c63,string c64,
                            string c65,string c66,string c67,string c68,string c69,string c70,string c71,
                            string c72,string c73,string c74,string c75,string c76,string c77,string c78,
                            string c79,string c80,string c81,string c82,string c83,string c84,string c85,
                            string c86,string c87,string c88,string c89,string c90,string c91,string c92,   
                            string c93,string c94,string c95,string c96,string c97,string c98,string c99,
                            string c100, string costCenters, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcomand = db.GetStoredProcCommand(Resources.UpdateQCbyAttribute1_ADResources.SP_UpdateQCbyAttribute1_AD);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY, DbType.String, attribute1);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY2, DbType.String, deleteAccountingLines);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY3, DbType.String, deleteAccountingRemarks);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY4, DbType.String, cuotingActualFare);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY5, DbType.String, comparativeMoreEconomicFareNotAvailable);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY6, DbType.String, comparativeMoreEconomicFareAvailable);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY7, DbType.String, comparativeStandardFare);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY8, DbType.String, classComparativeStandard);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY9, DbType.String, comparativeSpecificFare);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY10, DbType.String, classComparativeSpecific);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY11, DbType.String, comparativeBusinessFare);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY12, DbType.String, classComparativeBusiness1);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY13, DbType.String, classComparativeBusiness2);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY14, DbType.String, classComparativeBusiness3);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY15, DbType.String, classComparativeBusiness4);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY16, DbType.String, comparativeSoldFareVSMoreEconomicFareNotAvailable);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY17, DbType.String, fareJustification);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY18, DbType.String, applyComparativeMoreEconomicFare);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY19, DbType.String, chargePerService);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY20, DbType.String, remarksAvailableClasses);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY21, DbType.String, remarkContableAuthorization);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY22, DbType.String, qcAuthorized);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY23, DbType.String, labelQC);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY24, DbType.String, cancellation);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY25, DbType.String, fareRemark);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY26, DbType.String, verifyTicketEmission);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_GetThereQCValues, DbType.Byte, getThereQCValues);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY27, DbType.String, reservationSendQCClient);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY28, DbType.String, emissionSendQCClient);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY29, DbType.String, c1);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY30, DbType.String, c2);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY31, DbType.String, c3);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY32, DbType.String, c4);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY33, DbType.String, c5);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY34, DbType.String, c6);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY35, DbType.String, c7);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY36, DbType.String, c8);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY37, DbType.String, c9);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY38, DbType.String, c10);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY39, DbType.String, c11);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY40, DbType.String, c12);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY41, DbType.String, c13);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY42, DbType.String, c14);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY43, DbType.String, c15);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY44, DbType.String, c16);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY45, DbType.String, c17);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY46, DbType.String, c18);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY47, DbType.String, c19);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY48, DbType.String, c20);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY49, DbType.String, c21);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY50, DbType.String, c22);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY51, DbType.String, c23);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY52, DbType.String, c24);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY53, DbType.String, c25);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY54, DbType.String, c26);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY55, DbType.String, c27);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY56, DbType.String, c28);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY57, DbType.String, c29);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY58, DbType.String, c30);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY59, DbType.String, c31);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY60, DbType.String, c32);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY61, DbType.String, c33);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY62, DbType.String, c34);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY63, DbType.String, c35);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY64, DbType.String, c36);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY65, DbType.String, c37);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY66, DbType.String, c38);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY67, DbType.String, c39);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY68, DbType.String, c40);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY69, DbType.String, c41);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY70, DbType.String, c42);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY71, DbType.String, c43);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY72, DbType.String, c44);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY73, DbType.String, c45);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY74, DbType.String, c46);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY75, DbType.String, c47);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY76, DbType.String, c48);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY77, DbType.String, c49);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY78, DbType.String, c50);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY79, DbType.String, c51);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY80, DbType.String, c52);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY81, DbType.String, c53);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY82, DbType.String, c54);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY83, DbType.String, c55);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY84, DbType.String, c56);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY85, DbType.String, c57);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY86, DbType.String, c58);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY87, DbType.String, c59);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY88, DbType.String, c60);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY89, DbType.String, c61);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY90, DbType.String, c62);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY91, DbType.String, c63);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY92, DbType.String, c64);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY93, DbType.String, c65);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY94, DbType.String, c66);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY95, DbType.String, c67);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY96, DbType.String, c68);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY97, DbType.String, c69);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY98, DbType.String, c70);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY99, DbType.String, c71);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY100, DbType.String, c72);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY101, DbType.String, c73);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY102, DbType.String, c74);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY103, DbType.String, c75);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY104, DbType.String, c76);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY105, DbType.String, c77);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY106, DbType.String, c78);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY107, DbType.String, c79);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY108, DbType.String, c80);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY109, DbType.String, c81);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY110, DbType.String, c82);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY111, DbType.String, c83);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY112, DbType.String, c84);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY113, DbType.String, c85);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY114, DbType.String, c86);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY115, DbType.String, c87);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY116, DbType.String, c88);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY117, DbType.String, c89);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY118, DbType.String, c90);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY119, DbType.String, c91);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY120, DbType.String, c92);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY121, DbType.String, c93);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY122, DbType.String, c94);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY123, DbType.String, c95);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY124, DbType.String, c96);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY125, DbType.String, c97);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY126, DbType.String, c98);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY127, DbType.String, c99);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY128, DbType.String, c100);
            db.AddInParameter(dbcomand, Resources.UpdateQCbyAttribute1_ADResources.PARAM_QUERY129, DbType.String, costCenters);

            db.ExecuteNonQuery(dbcomand);
        }
    }
}
