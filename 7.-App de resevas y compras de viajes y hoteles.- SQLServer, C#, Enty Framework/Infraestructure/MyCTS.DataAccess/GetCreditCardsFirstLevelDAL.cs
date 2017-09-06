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
    public class GetCreditCardsFirstLevelDAL
    {
        public List<string> GetCreditCardsFirstLevel(string dk, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetCreditCardsFirstLevelResources.SP_GetCreditCardsFirstLevel);
            db.AddInParameter(dbCommand, Resources.GetCreditCardsFirstLevelResources.PARAM_DK, DbType.String, dk);

            List<string> creditCard = new List<string>();
            try
            {
                using (IDataReader dr = db.ExecuteReader(dbCommand))
                {
                    int _creditCard1 = dr.GetOrdinal(Resources.GetCreditCardsFirstLevelResources.PARAM_CREDITCARD1);
                    int _creditCard2 = dr.GetOrdinal(Resources.GetCreditCardsFirstLevelResources.PARAM_CREDITCARD2);
                    int _creditCard3 = dr.GetOrdinal(Resources.GetCreditCardsFirstLevelResources.PARAM_CREDITCARD3);
                    int _creditCard4 = dr.GetOrdinal(Resources.GetCreditCardsFirstLevelResources.PARAM_CREDITCARD4);
                    int _creditCard5 = dr.GetOrdinal(Resources.GetCreditCardsFirstLevelResources.PARAM_CREDITCARD5);
                    
                    if (dr.Read())
                    {
                        creditCard.Add((dr[_creditCard1] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_creditCard1));
                        creditCard.Add((dr[_creditCard2] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_creditCard2));
                        creditCard.Add((dr[_creditCard3] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_creditCard3));
                        creditCard.Add((dr[_creditCard4] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_creditCard4));
                        creditCard.Add((dr[_creditCard5] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_creditCard5));
                    }
                }
            }
            catch { }

            return creditCard;
        }
    }
}
