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
    public class GetLinkByTktDAL
    {
        public List<GetLinkByTkt> GetLinkByTktIndex(string ticket, int OrgId, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetLinkByTkt.SP_GETTKTLINKS);
            db.AddInParameter(dbCommand, Resources.GetLinkByTkt.PARAM_QUERY1, DbType.String, ticket);
            db.AddInParameter(dbCommand, Resources.GetLinkByTkt.PARAM_ORG_ID, DbType.Int32, OrgId);

            List<GetLinkByTkt> getLinkByTktList = new List<GetLinkByTkt>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _agent = dr.GetOrdinal(Resources.GetLinkByTkt.PARAM_AGENT);
                int _linkInvoice = dr.GetOrdinal(Resources.GetLinkByTkt.PARAM_LINKINVOICE);
                int _linkVirtuallyThere = dr.GetOrdinal(Resources.GetLinkByTkt.PARAM_LINKVIRTUALLYTHERE);
                int _descrptionType = dr.GetOrdinal(Resources.GetLinkByTkt.PARAM_DESCRIPTIONTYPE);
                int _linkPasssengerReceipt = dr.GetOrdinal(Resources.GetLinkByTkt.PARAM_LINKPASSENGERRECEIPT);
                int _linkTicketPrinter = dr.GetOrdinal(Resources.GetLinkByTkt.PARAM_LINKTICKETPRINTER);

                while (dr.Read())
                {
                    GetLinkByTkt item = new GetLinkByTkt();
                    item.Agent = (dr[_agent] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_agent);
                    item.LinkInvoice = (dr[_linkInvoice] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_linkInvoice);
                    item.LinkVirtuallyThere = (dr[_linkVirtuallyThere] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_linkVirtuallyThere);
                    item.DescriptionType = (dr[_descrptionType] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_descrptionType);
                    item.LinkPassengerReceipt = (dr[_linkPasssengerReceipt] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_linkPasssengerReceipt);
                    item.LinkTicketPrinter = (dr[_linkTicketPrinter] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_linkTicketPrinter);
                    getLinkByTktList.Add(item);
                }
            }
            return getLinkByTktList;
        }
    }
}