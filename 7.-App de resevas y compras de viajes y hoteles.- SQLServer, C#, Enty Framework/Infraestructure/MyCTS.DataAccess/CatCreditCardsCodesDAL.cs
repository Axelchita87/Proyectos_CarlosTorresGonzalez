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
    public class CatCreditCardsCodesDAL
    {
        public List<CatCreditCardsCodes> GetCreditCardsCodes(string StrToSearch, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatCreditCardsCodesResource.SP_GetCreditCardsCodes);
            db.AddInParameter(dbCommand, Resources.CatCreditCardsCodesResource.PARAM_QUERY, DbType.String, StrToSearch);
            List<CatCreditCardsCodes> CatCreditCardsCodesList = new List<CatCreditCardsCodes>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _catcrecarcodcode = dr.GetOrdinal(Resources.CatCreditCardsCodesResource.PARAM_CATCRECARCODCODE);
                int _catcrecarcodname = dr.GetOrdinal(Resources.CatCreditCardsCodesResource.PARAM_CATCRECARCODNAME);


                while (dr.Read())
                {
                    CatCreditCardsCodes item = new CatCreditCardsCodes();
                    item.CatCreCarCodCode = (dr[_catcrecarcodcode] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catcrecarcodcode);
                    item.CatCreCarCodName = (dr[_catcrecarcodname] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catcrecarcodname);
                    CatCreditCardsCodesList.Add(item);
                }
            }

            return CatCreditCardsCodesList;

        }

        public List<ListItem> GetFOPCTS(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatCreditCardsCodesResource.SP_GetCatFormPaymentCTS);
            //db.AddInParameter(dbCommand, Resources.CatCreditCardsCodesResource.PARAM_QUERY, DbType.String, StrToSearch);
            List<ListItem> CatFOPCTSList = new List<ListItem>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _formtypecode = dr.GetOrdinal(Resources.CatCreditCardsCodesResource.PARAM_FORMTYPECODE);
                int _formtypesabrecode = dr.GetOrdinal(Resources.CatCreditCardsCodesResource.PARAM_FORMTYPESABRECODE);
                int _formtypedescription = dr.GetOrdinal(Resources.CatCreditCardsCodesResource.PARAM_FORMTYPEDESCRIPTION);
                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Value = (dr[_formtypesabrecode] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_formtypesabrecode);
                    item.Text = (dr[_formtypedescription] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_formtypedescription);
                    item.Text2 = (dr[_formtypecode] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_formtypecode);
                    CatFOPCTSList.Add(item);
                }
            }

            return CatFOPCTSList;

        }

        public List<ListItem> GetFOPCTSSinFoPTP(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatCreditCardsCodesResource.SP_CatFormPaymentCTSSinFoPTP);
            List<ListItem> CatFOPCTSList = new List<ListItem>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _formtypecode = dr.GetOrdinal(Resources.CatCreditCardsCodesResource.PARAM_FORMTYPECODE);
                int _formtypesabrecode = dr.GetOrdinal(Resources.CatCreditCardsCodesResource.PARAM_FORMTYPESABRECODE);
                int _formtypedescription = dr.GetOrdinal(Resources.CatCreditCardsCodesResource.PARAM_FORMTYPEDESCRIPTION);
                while (dr.Read()) 
                {
                    ListItem item = new ListItem();
                    item.Value = (dr[_formtypesabrecode] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_formtypesabrecode);
                    item.Text = (dr[_formtypedescription] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_formtypedescription);
                    item.Text2 = (dr[_formtypecode] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_formtypecode);
                    CatFOPCTSList.Add(item);
                }
            }
            return CatFOPCTSList;
        }

    }
}
