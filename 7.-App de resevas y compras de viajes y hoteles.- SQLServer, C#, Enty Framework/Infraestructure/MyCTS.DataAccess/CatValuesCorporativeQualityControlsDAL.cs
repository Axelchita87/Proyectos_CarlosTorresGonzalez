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
    public class CatValuesCorporativeQualityControlsDAL
    {
        public List<CatValuesCorporativeQualityControls> GetValuesQualityControls(string DKToSearch, string Firm, string PCC, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatValuesCorporativeQualityControlsResources.SP_GetValuesQualityControls);
            db.AddInParameter(dbCommand, Resources.CatValuesCorporativeQualityControlsResources.PARAM_QUERY, DbType.String, DKToSearch);
            db.AddInParameter(dbCommand, Resources.CatValuesCorporativeQualityControlsResources.PARAM_QUERY2, DbType.String, Firm);
            db.AddInParameter(dbCommand, Resources.CatValuesCorporativeQualityControlsResources.PARAM_QUERY3, DbType.String, PCC);

            List<CatValuesCorporativeQualityControls> ValuesCorporativeQualityControlsList = new List<CatValuesCorporativeQualityControls>();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _c1 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C1);
                int _c2 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C2);
                int _c3 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C3);
                int _c4 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C4);
                int _c5 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C5);
                int _c6 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C6);
                int _c7 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C7);
                int _c8 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C8);
                int _c9 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C9);
                int _c10 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C10);
                int _c11 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C11);
                int _c12 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C12);
                int _c13 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C13);
                int _c14 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C14);
                int _c15 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C15);
                int _c16 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C16);
                int _c17 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C17);
                int _c18 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C18);
                int _c19 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C19);
                int _c20 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C20);
                int _c21 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C21);
                int _c22 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C22);
                int _c23 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C23);
                int _c24 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C24);
                int _c25 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C25);
                int _c26 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C26);
                int _c27 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C27);
                int _c28 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C28);
                int _c29 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C29);
                int _c30 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C30);
                int _c31 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C31);
                int _c32 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C32);
                int _c33 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C33);
                int _c34 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C34);
                int _c35 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C35);
                int _c36 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C36);
                int _c37 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C37);
                int _c38 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C38);
                int _c39 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C39);
                int _c40 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C40);
                int _c41 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C41);
                int _c42 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C42);
                int _c43 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C43);
                int _c44 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C44);
                int _c45 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C45);
                int _c46 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C46);
                int _c47 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C47);
                int _c48 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C48);
                int _c49 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C49);
                int _c50 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C50);
                int _c51 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C51);
                int _c52 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C52);
                int _c53 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C53);
                int _c54 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C54);
                int _c55 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C55);
                int _c56 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C56);
                int _c57 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C57);
                int _c58 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C58);
                int _c59 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C59);
                int _c60 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C60);
                int _c61 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C61);
                int _c62 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C62);
                int _c63 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C63);
                int _c64 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C64);
                int _c65 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C65);
                int _c66 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C66);
                int _c67 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C67);
                int _c68 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C68);
                int _c69 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C69);
                int _c70 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C70);
                int _c71 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C71);
                int _c72 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C72);
                int _c73 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C73);
                int _c74 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C74);
                int _c75 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C75);
                int _c76 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C76);
                int _c77 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C77);
                int _c78 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C78);
                int _c79 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C79);
                int _c80 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C80);
                int _c81 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C81);
                int _c82 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C82);
                int _c83 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C83);
                int _c84 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C84);
                int _c85 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C85);
                int _c86 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C86);
                int _c87 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C87);
                int _c88 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C88);
                int _c89 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C89);
                int _c90 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C90);
                int _c91 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C91);
                int _c92 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C92);
                int _c93 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C93);
                int _c94 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C94);
                int _c95 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C95);
                int _c96 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C96);
                int _c97 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C97);
                int _c98 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C98);
                int _c99 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C99);
                int _c100 = dr.GetOrdinal(Resources.CatValuesCorporativeQualityControlsResources.PARAM_C100);




                while (dr.Read())
                {
                    CatValuesCorporativeQualityControls item = new CatValuesCorporativeQualityControls();

                    item.C1 = (dr[_c1] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c1);
                    item.C2 = (dr[_c2] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c2);
                    item.C3 = (dr[_c3] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c3);
                    item.C4 = (dr[_c4] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c4);
                    item.C5 = (dr[_c5] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c5);
                    item.C6 = (dr[_c6] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c6);
                    item.C7 = (dr[_c7] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c7);
                    item.C8 = (dr[_c8] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c8);
                    item.C9 = (dr[_c9] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c9);
                    item.C10 = (dr[_c10] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c10);
                    item.C11 = (dr[_c11] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c11);
                    item.C12 = (dr[_c12] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c12);
                    item.C13 = (dr[_c13] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c13);
                    item.C14 = (dr[_c14] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c14);
                    item.C15 = (dr[_c15] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c15);
                    item.C16 = (dr[_c16] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c16);
                    item.C17 = (dr[_c17] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c17);
                    item.C18 = (dr[_c18] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c18);
                    item.C19 = (dr[_c19] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c19);
                    item.C20 = (dr[_c20] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c20);
                    item.C21 = (dr[_c21] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c21);
                    item.C22 = (dr[_c22] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c22);
                    item.C23 = (dr[_c23] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c23);
                    item.C24 = (dr[_c24] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c24);
                    item.C25 = (dr[_c25] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c25);
                    item.C26 = (dr[_c26] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c26);
                    item.C27 = (dr[_c27] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c27);
                    item.C28 = (dr[_c28] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c28);
                    item.C29 = (dr[_c29] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c29);
                    item.C30 = (dr[_c30] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c30);
                    item.C31 = (dr[_c31] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c31);
                    item.C32 = (dr[_c32] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c32);
                    item.C33 = (dr[_c33] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c33);
                    item.C34 = (dr[_c34] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c34);
                    item.C35 = (dr[_c35] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c35);
                    item.C36 = (dr[_c36] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c36);
                    item.C37 = (dr[_c37] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c37);
                    item.C38 = (dr[_c38] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c38);
                    item.C39 = (dr[_c39] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c39);
                    item.C40 = (dr[_c40] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c40);
                    item.C41 = (dr[_c41] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c41);
                    item.C42 = (dr[_c42] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c42);
                    item.C43 = (dr[_c43] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c43);
                    item.C44 = (dr[_c44] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c44);
                    item.C45 = (dr[_c45] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c45);
                    item.C46 = (dr[_c46] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c46);
                    item.C47 = (dr[_c47] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c47);
                    item.C48 = (dr[_c48] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c48);
                    item.C49 = (dr[_c49] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c49);
                    item.C50 = (dr[_c50] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c50);
                    item.C51 = (dr[_c51] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c51);
                    item.C52 = (dr[_c52] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c52);
                    item.C53 = (dr[_c53] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c53);
                    item.C54 = (dr[_c54] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c54);
                    item.C55 = (dr[_c55] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c55);
                    item.C56 = (dr[_c56] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c56);
                    item.C57 = (dr[_c57] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c57);
                    item.C58 = (dr[_c58] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c58);
                    item.C59 = (dr[_c59] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c59);
                    item.C60 = (dr[_c60] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c60);
                    item.C61 = (dr[_c61] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c61);
                    item.C62 = (dr[_c62] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c62);
                    item.C63 = (dr[_c63] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c63);
                    item.C64 = (dr[_c64] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c64);
                    item.C65 = (dr[_c65] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c65);
                    item.C66 = (dr[_c66] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c66);
                    item.C67 = (dr[_c67] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c67);
                    item.C68 = (dr[_c68] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c68);
                    item.C69 = (dr[_c69] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c69);
                    item.C70 = (dr[_c70] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c70);
                    item.C71 = (dr[_c71] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c71);
                    item.C72 = (dr[_c72] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c72);
                    item.C73 = (dr[_c73] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c73);
                    item.C74 = (dr[_c74] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c74);
                    item.C75 = (dr[_c75] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c75);
                    item.C76 = (dr[_c76] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c76);
                    item.C77 = (dr[_c77] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c77);
                    item.C78 = (dr[_c78] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c78);
                    item.C79 = (dr[_c79] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c79);
                    item.C80 = (dr[_c80] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c80);
                    item.C81 = (dr[_c81] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c81);
                    item.C82 = (dr[_c82] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c82);
                    item.C83 = (dr[_c83] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c83);
                    item.C84 = (dr[_c84] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c84);
                    item.C85 = (dr[_c85] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c85);
                    item.C86 = (dr[_c86] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c86);
                    item.C87 = (dr[_c87] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c87);
                    item.C88 = (dr[_c88] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c88);
                    item.C89 = (dr[_c89] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c89);
                    item.C90 = (dr[_c90] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c90);
                    item.C91 = (dr[_c91] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c91);
                    item.C92 = (dr[_c92] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c92);
                    item.C93 = (dr[_c93] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c93);
                    item.C94 = (dr[_c94] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c94);
                    item.C95 = (dr[_c95] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c95);
                    item.C96 = (dr[_c96] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c96);
                    item.C97 = (dr[_c97] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c97);
                    item.C98 = (dr[_c98] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c98);
                    item.C99 = (dr[_c99] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c99);
                    item.C100 = (dr[_c100] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_c100);


                    ValuesCorporativeQualityControlsList.Add(item);
                }

            }
            return ValuesCorporativeQualityControlsList;
        }


    }
}
