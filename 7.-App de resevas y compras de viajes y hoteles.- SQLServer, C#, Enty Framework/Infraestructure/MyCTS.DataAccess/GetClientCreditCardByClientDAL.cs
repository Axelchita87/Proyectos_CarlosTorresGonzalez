using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using System.Data;
using System.Data.Common;
using MyCTS.Components.NullableHelper;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace MyCTS.DataAccess
{
    public class GetClientCreditCardByClientDAL
    {
        public ClientCreditCard GetClientCreditCardNumber(string creditCardNumber, string Attribute1, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetClientCreditCardNumberResources.SP_GetClientCreditCardNumber);
            db.AddInParameter(dbCommand, Resources.GetClientCreditCardNumberResources.PARAM_QUERY1, DbType.String, creditCardNumber);
            db.AddInParameter(dbCommand, Resources.GetClientCreditCardNumberResources.PARAM_QUERY2, DbType.String, Attribute1);
            ClientCreditCard creditCard = new ClientCreditCard();
            try
            {
                using (IDataReader dr = db.ExecuteReader(dbCommand))
                {
                    int _creditCard = dr.GetOrdinal(Resources.GetClientCreditCardNumberResources.PARAM_CREDIT_CARD_NUMBER);
                    int _client = dr.GetOrdinal(Resources.GetClientCreditCardNumberResources.PARAM_CLIENT);
                    int _type = dr.GetOrdinal(Resources.GetClientCreditCardNumberResources.PARAM_TYPE);
                    if (dr.Read())
                    {
                        creditCard.CreditCardNumber = dr.GetString(_creditCard);
                        creditCard.Client = dr.GetString(_client);
                        creditCard.Type = dr.GetString(_type);
                    }
                }
            }
            catch { }

            return creditCard;
        }
    }
}
