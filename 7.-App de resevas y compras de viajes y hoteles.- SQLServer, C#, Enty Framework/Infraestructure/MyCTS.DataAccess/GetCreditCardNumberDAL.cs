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
    public class GetCreditCardNumberDAL
    {
        public string GetCreditCardNumber(string creditCardNumber, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetCreditCardNumberResources.SP_GetCreditCardNumber);
            db.AddInParameter(dbCommand, Resources.GetCreditCardNumberResources.PARAM_QUERY1, DbType.String, creditCardNumber);
            string creditCard = string.Empty;
            try
            {
                using (IDataReader dr = db.ExecuteReader(dbCommand))
                {
                    int _creditCard = dr.GetOrdinal(Resources.GetCreditCardNumberResources.PARAM_CREDIT_CARD_NUMBER);
                    if (dr.Read())
                    {
                        creditCard = dr.GetString(_creditCard);
                    }
                }
            }
            catch { }

            return creditCard;
        }
    }
}
