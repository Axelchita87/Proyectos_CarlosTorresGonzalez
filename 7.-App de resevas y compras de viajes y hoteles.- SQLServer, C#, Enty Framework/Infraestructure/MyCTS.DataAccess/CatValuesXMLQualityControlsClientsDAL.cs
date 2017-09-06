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
    public class CatValuesXMLQualityControlsClientsDAL
    {
        public List<CatValuesXMLQualityControlsClients> GetValuesXMLQualityControls(string Attribute1, string PaxNumber, string C1s, string C2s, string C3s,
              string C4s, string C5s, string C6s, string C7s, string C8s, string C9s, string C10s, string C11s, string C12s, string C13s,
              string C14s, string C15s, string C16s, string C17s, string C18s, string C19s, string C20s, string C21s, string C22s, string C23s,
              string C24s, string C25s, string C26s, string C27s, string C28s, string C29s, string C30s, string C31s, string C32s, string C33s,
              string C34s, string C35s, string C36s, string C37s, string C38s, string C39s, string C40s, string C41s, string C42s, string C43s,
              string C44s, string C45s, string C46s, string C47s, string C48s, string C49s, string C50s, string C51s, string C52s, string C53s,
              string C54s, string C55s, string C56s, string C57s, string C58s, string C59s, string C60s, string C61s, string C62s, string C63s,
              string C64s, string C65s, string C66s, string C67s, string C68s, string C69s, string C70s, string C71s, string C72s, string C73s,
              string C74s, string C75s, string C76s, string C77s, string C78s, string C79s, string C80s, string C81s, string C82s, string C83s,
              string C84s, string C85s, string C86s, string C87s, string C88s, string C89s, string C90s, string C91s, string C92s, string C93s,
              string C94s, string C95s, string C96s, string C97s, string C98s, string C99s, string C100s, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatValuesXMLQualityControlsClientsResources.SP_GetValuesXMLQualityControlsClients);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_QUERY, DbType.String, Attribute1);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_PAX_NUMBER, DbType.String, PaxNumber);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C1, DbType.String, C1s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C2, DbType.String, C2s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C3, DbType.String, C3s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C4, DbType.String, C4s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C5, DbType.String, C5s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C6, DbType.String, C6s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C7, DbType.String, C7s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C8, DbType.String, C8s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C9, DbType.String, C9s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C10, DbType.String, C10s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C11, DbType.String, C11s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C12, DbType.String, C12s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C13, DbType.String, C13s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C14, DbType.String, C14s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C15, DbType.String, C15s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C16, DbType.String, C16s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C17, DbType.String, C17s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C18, DbType.String, C18s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C19, DbType.String, C19s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C20, DbType.String, C20s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C21, DbType.String, C21s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C22, DbType.String, C22s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C23, DbType.String, C23s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C24, DbType.String, C24s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C25, DbType.String, C25s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C26, DbType.String, C26s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C27, DbType.String, C27s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C28, DbType.String, C28s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C29, DbType.String, C29s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C30, DbType.String, C30s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C31, DbType.String, C31s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C32, DbType.String, C32s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C33, DbType.String, C33s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C34, DbType.String, C34s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C35, DbType.String, C35s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C36, DbType.String, C36s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C37, DbType.String, C37s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C38, DbType.String, C38s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C39, DbType.String, C39s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C40, DbType.String, C40s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C41, DbType.String, C41s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C42, DbType.String, C42s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C43, DbType.String, C43s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C44, DbType.String, C44s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C45, DbType.String, C45s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C46, DbType.String, C46s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C47, DbType.String, C47s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C48, DbType.String, C48s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C49, DbType.String, C49s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C50, DbType.String, C50s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C51, DbType.String, C51s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C52, DbType.String, C52s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C53, DbType.String, C53s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C54, DbType.String, C54s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C55, DbType.String, C55s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C56, DbType.String, C56s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C57, DbType.String, C57s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C58, DbType.String, C58s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C59, DbType.String, C59s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C60, DbType.String, C60s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C61, DbType.String, C61s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C62, DbType.String, C62s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C63, DbType.String, C63s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C64, DbType.String, C64s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C65, DbType.String, C65s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C66, DbType.String, C66s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C67, DbType.String, C67s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C68, DbType.String, C68s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C69, DbType.String, C69s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C70, DbType.String, C70s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C71, DbType.String, C71s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C72, DbType.String, C72s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C73, DbType.String, C73s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C74, DbType.String, C74s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C75, DbType.String, C75s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C76, DbType.String, C76s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C77, DbType.String, C77s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C78, DbType.String, C78s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C79, DbType.String, C79s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C80, DbType.String, C80s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C81, DbType.String, C81s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C82, DbType.String, C82s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C83, DbType.String, C83s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C84, DbType.String, C84s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C85, DbType.String, C85s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C86, DbType.String, C86s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C87, DbType.String, C87s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C88, DbType.String, C88s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C89, DbType.String, C89s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C90, DbType.String, C90s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C91, DbType.String, C91s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C92, DbType.String, C92s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C93, DbType.String, C93s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C94, DbType.String, C94s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C95, DbType.String, C95s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C96, DbType.String, C96s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C97, DbType.String, C97s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C98, DbType.String, C98s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C99, DbType.String, C99s);
            db.AddInParameter(dbCommand, Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C100, DbType.String, C100s);





            List<CatValuesXMLQualityControlsClients> ValuesXMLQualityControlsList = new List<CatValuesXMLQualityControlsClients>();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _status = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_STATUS);
                int _c1 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C1);
                int _c2 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C2);
                int _c3 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C3);
                int _c4 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C4);
                int _c5 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C5);
                int _c6 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C6);
                int _c7 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C7);
                int _c8 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C8);
                int _c9 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C9);
                int _c10 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C10);
                int _c11 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C11);
                int _c12 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C12);
                int _c13 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C13);
                int _c14 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C14);
                int _c15 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C15);
                int _c16 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C16);
                int _c17 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C17);
                int _c18 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C18);
                int _c19 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C19);
                int _c20 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C20);
                int _c21 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C21);
                int _c22 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C22);
                int _c23 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C23);
                int _c24 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C24);
                int _c25 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C25);
                int _c26 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C26);
                int _c27 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C27);
                int _c28 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C28);
                int _c29 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C29);
                int _c30 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C30);
                int _c31 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C31);
                int _c32 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C32);
                int _c33 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C33);
                int _c34 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C34);
                int _c35 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C35);
                int _c36 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C36);
                int _c37 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C37);
                int _c38 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C38);
                int _c39 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C39);
                int _c40 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C40);
                int _c41 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C41);
                int _c42 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C42);
                int _c43 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C43);
                int _c44 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C44);
                int _c45 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C45);
                int _c46 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C46);
                int _c47 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C47);
                int _c48 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C48);
                int _c49 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C49);
                int _c50 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C50);
                int _c51 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C51);
                int _c52 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C52);
                int _c53 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C53);
                int _c54 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C54);
                int _c55 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C55);
                int _c56 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C56);
                int _c57 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C57);
                int _c58 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C58);
                int _c59 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C59);
                int _c60 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C60);
                int _c61 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C61);
                int _c62 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C62);
                int _c63 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C63);
                int _c64 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C64);
                int _c65 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C65);
                int _c66 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C66);
                int _c67 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C67);
                int _c68 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C68);
                int _c69 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C69);
                int _c70 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C70);
                int _c71 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C71);
                int _c72 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C72);
                int _c73 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C73);
                int _c74 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C74);
                int _c75 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C75);
                int _c76 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C76);
                int _c77 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C77);
                int _c78 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C78);
                int _c79 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C79);
                int _c80 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C80);
                int _c81 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C81);
                int _c82 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C82);
                int _c83 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C83);
                int _c84 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C84);
                int _c85 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C85);
                int _c86 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C86);
                int _c87 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C87);
                int _c88 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C88);
                int _c89 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C89);
                int _c90 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C90);
                int _c91 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C91);
                int _c92 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C92);
                int _c93 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C93);
                int _c94 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C94);
                int _c95 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C95);
                int _c96 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C96);
                int _c97 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C97);
                int _c98 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C98);
                int _c99 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C99);
                int _c100 = dr.GetOrdinal(Resources.CatValuesXMLQualityControlsClientsResources.PARAM_C100);




                while (dr.Read())
                {
                    CatValuesXMLQualityControlsClients item = new CatValuesXMLQualityControlsClients();

                    item.Status = (dr[_status] == DBNull.Value) ? Types.IntegerNullValue : dr.GetInt32(_status);
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



                    ValuesXMLQualityControlsList.Add(item);
                }

            }
            return ValuesXMLQualityControlsList;
        }
    }
}
