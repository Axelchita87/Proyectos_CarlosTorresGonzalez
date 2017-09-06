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
    public class GetAuthCodeDAL
    {
        public AuthCode GetAuthCode(string pnr, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.AuthCodeResources.SP_GetAuthCode);
            db.AddInParameter(dbCommand, Resources.AuthCodeResources.PARAM_PNR, DbType.String, pnr);

            AuthCode AuthCode = new AuthCode(); ;

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _pnr = dr.GetOrdinal(Resources.AuthCodeResources.PARAM_PNR);
                int _authcode = dr.GetOrdinal(Resources.AuthCodeResources.PARAM_AUTH_CODE);
                int _cardtype = dr.GetOrdinal(Resources.AuthCodeResources.PARAM_CARD_TYPE);
                int _amount = dr.GetOrdinal(Resources.AuthCodeResources.PARAM_AMOUNT);
                int _bank = dr.GetOrdinal(Resources.AuthCodeResources.PARAM_BANK);
                int _ticket = dr.GetOrdinal(Resources.AuthCodeResources.PARAM_TICKET);
                int _date = dr.GetOrdinal(Resources.AuthCodeResources.PARAM_DATE);
                int _commandwp = dr.GetOrdinal(Resources.AuthCodeResources.PARAM_COMMAND_WP);


                try
                {
                    if (dr.Read())
                    {
                        AuthCode.PNR = (dr[_pnr] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_pnr);
                        AuthCode.Code = (dr[_authcode] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_authcode);
                        AuthCode.CardType = (dr[_cardtype] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_cardtype);
                        AuthCode.Amount = (dr[_amount] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_amount);
                        AuthCode.Bank = (dr[_bank] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_bank);
                        AuthCode.Ticket = (dr[_ticket] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_ticket);
                        AuthCode.Date = (dr[_date] == DBNull.Value) ? Types.DateNullValue : dr.GetDateTime(_date);
                        AuthCode.CommandWP = (dr[_commandwp] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_commandwp);
                    }
                }
                catch { }
            }

            return AuthCode;

        }
    }
}
