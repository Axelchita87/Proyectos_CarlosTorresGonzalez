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
  public class AirLinesFareDAL
   {
     public List<AirLinesFare> GetAirLinesFare(string connectionName)
     {
         Database db = DatabaseFactory.CreateDatabase(connectionName);
        DbCommand dbcommand = db.GetStoredProcCommand(Resources.AirLinesFareResources.SP_GetAirLinesFare);
        //Este StoredProcedure no lleva parametros
        //Lista de parametros

        List<AirLinesFare> airLinesFareList = new List<AirLinesFare>();
        using (IDataReader dr = db.ExecuteReader(dbcommand))
        {
            int _catairlinfarid = dr.GetOrdinal(Resources.AirLinesFareResources.PARAM_CATAIRLINFARID);
           int _catairlinfarname = dr.GetOrdinal(Resources.AirLinesFareResources.PARAM_CATAIRLINFARNAME);
           int _catairlinfarccaut = dr.GetOrdinal(Resources.AirLinesFareResources.PARAM_CATAIRLINFARCCAUT);
           int _catairlinfarccman = dr.GetOrdinal(Resources.AirLinesFareResources.PARAM_CATAIRLINFARCCMAN);
           int _catairlinfarcash= dr.GetOrdinal(Resources.AirLinesFareResources.PARAM_CATAIRLINFARCASH);
           int _catairlinfarpmix = dr.GetOrdinal(Resources.AirLinesFareResources.PARAM_CATAIRLINFARPMIX);
           int _catairlinfarMisc = dr.GetOrdinal(Resources.AirLinesFareResources.PARAM_CATAIRLINFARMISC);
           //No se ingresaron nullables por que las columnas de las tablas no aceptan nulos
           while (dr.Read())
           {
              AirLinesFare item = new AirLinesFare();
              item.CatAirLinFarId = dr.GetString(_catairlinfarid);
              item.CatAirLinFarName = dr.GetString(_catairlinfarname);
              item.CCAut = dr.GetBoolean(_catairlinfarccaut);
              item.CCMan = dr.GetBoolean(_catairlinfarccman);
              item.Cash = dr.GetBoolean(_catairlinfarcash);
              item.Misc = dr.GetBoolean(_catairlinfarMisc);
              airLinesFareList.Add(item);
           }

        }
        return airLinesFareList;

    
     }

   }
}
