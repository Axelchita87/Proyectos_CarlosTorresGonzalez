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
   public class GetChaincodeDAL
    {
       public List<ListItem> GetChaincode(string reclog, string chaincode, string connectionName)
       {
           
           List<ListItem> detalsList = new List<ListItem>();
           //DetailsPNRHotels detailslhotel = new DetailsPNRHotels();
           Database db = DatabaseFactory.CreateDatabase(connectionName);
           DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetChainCodeResources.SP_GETCHAINCODE);
           db.AddInParameter(dbCommand, Resources.GetChainCodeResources.PARAM_RECLOG, DbType.String, reclog);
           db.AddInParameter(dbCommand, Resources.GetChainCodeResources.PARAM_CHAIN_CODE, DbType.String, chaincode);
           using (IDataReader dr = db.ExecuteReader(dbCommand))
           {
               int _reclog = dr.GetOrdinal(Resources.GetChainCodeResources.RECORD);
               int _chaincode = dr.GetOrdinal(Resources.GetChainCodeResources.CHAINCODE);
               while (dr.Read())
               {
                  ListItem item = new ListItem();
                  item.Value = dr.GetString(_reclog);
                  item.Text = dr.GetString(_chaincode);
                  detalsList.Add(item);
               }
               
               

           }
           return detalsList;
       
       
       }
    }
}
