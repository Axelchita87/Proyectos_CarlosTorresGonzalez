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
    public class GetCreditCardsSecondLevelDAL
    {
        public List<string> GetCreditCardsSecondLevel(string name, string lastName, string level1, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetCreditCardsSecondLevelResources.SP_GetCreditCardsSecondLevel);
            db.AddInParameter(dbCommand, Resources.GetCreditCardsSecondLevelResources.PARAM_NAME, DbType.String, name);
            db.AddInParameter(dbCommand, Resources.GetCreditCardsSecondLevelResources.PARAM_LASTNAME, DbType.String, lastName);
            db.AddInParameter(dbCommand, Resources.GetCreditCardsSecondLevelResources.PARAM_LEVEL1, DbType.String, level1);

            List<string> creditCard = new List<string>(); ;
            try
            {
                using (IDataReader dr = db.ExecuteReader(dbCommand))
                {
                    int _creditCar = dr.GetOrdinal(Resources.GetCreditCardsSecondLevelResources.PARAM_CREDITCAR);
                    int _hotelcreditcar = dr.GetOrdinal(Resources.GetCreditCardsSecondLevelResources.PARAM_HOTEL_CREDITCAR);
                    int _creditCard3 = dr.GetOrdinal(Resources.GetCreditCardsSecondLevelResources.PARAM_CREDITCARD3);
                    int _creditCard4 = dr.GetOrdinal(Resources.GetCreditCardsSecondLevelResources.PARAM_CREDITCARD4);
                    int _creditCard5 = dr.GetOrdinal(Resources.GetCreditCardsSecondLevelResources.PARAM_CREDITCARD5);
                    int _creditCard6 = dr.GetOrdinal(Resources.GetCreditCardsSecondLevelResources.PARAM_CREDITCARD6);
                    int _creditCard7 = dr.GetOrdinal(Resources.GetCreditCardsSecondLevelResources.PARAM_CREDITCARD7);
                    int _creditCard8 = dr.GetOrdinal(Resources.GetCreditCardsSecondLevelResources.PARAM_CREDITCARD8);
                    if (dr.Read())
                    {
                        creditCard.Add((dr[_creditCar] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_creditCar));
                        creditCard.Add((dr[_hotelcreditcar] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_hotelcreditcar));
                        creditCard.Add((dr[_creditCard3] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_creditCard3));
                        creditCard.Add((dr[_creditCard4] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_creditCard4));
                        creditCard.Add((dr[_creditCard5] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_creditCard5));
                        creditCard.Add((dr[_creditCard6] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_creditCard6));
                        creditCard.Add((dr[_creditCard7] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_creditCard7));
                        creditCard.Add((dr[_creditCard8] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_creditCard8));
                    }
                }
            }
            catch(Exception ex) {
                throw new Exception(ex.Message);
            }

            return creditCard;
        }
    }
}
