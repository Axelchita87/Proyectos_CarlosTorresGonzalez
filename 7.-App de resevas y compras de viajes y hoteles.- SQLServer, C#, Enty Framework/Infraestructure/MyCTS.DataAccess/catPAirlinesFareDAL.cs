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
    public class catPAirlinesFareDAL
    {
        //public List<CatPAirlinesFare> GetPAirLinesFare(string StrToSearch)
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand dbcommand = db.GetStoredProcCommand(Resources.CatPAirlinesFareResources.SP_GetPAirLinesFare);
        //    db.AddInParameter(dbcommand, Resources.CatPAirlinesFareResources.PARAM_QUERY, DbType.String, StrToSearch);

        //    List<CatPAirlinesFare> airLinesFareList = new List<CatPAirlinesFare>();
        //    using (IDataReader dr = db.ExecuteReader(dbcommand))
        //    {
        //        int _catairlinfarid = dr.GetOrdinal(Resources.CatPAirlinesFareResources.PARAM_CATAIRLINFARID);
        //        int _catairlinfarname = dr.GetOrdinal(Resources.CatPAirlinesFareResources.PARAM_CATAIRLINFARNAME);
        //        //No se ingresaron nullables por que las columnas de las tablas no aceptan nulos
        //        while (dr.Read())
        //        {
        //            CatPAirlinesFare item = new CatPAirlinesFare();
        //            item.CatAirLinFarId = dr.GetString(_catairlinfarid);
        //            item.CatAirLinFarName = dr.GetString(_catairlinfarname);
        //            airLinesFareList.Add(item);
        //        }

        //    }
        //    return airLinesFareList;


        //}

        public List<ListItem> GetPAirLinesFare(string StrToSearch,string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcommand = db.GetStoredProcCommand(Resources.CatPAirlinesFareResources.SP_GetPAirLinesFare);
            db.AddInParameter(dbcommand, Resources.CatPAirlinesFareResources.PARAM_QUERY, DbType.String, StrToSearch);

            List<ListItem> airLinesFareList = new List<ListItem>();
            using (IDataReader dr = db.ExecuteReader(dbcommand))
            {
                int _catairlinfarid = dr.GetOrdinal(Resources.CatPAirlinesFareResources.PARAM_CATAIRLINFARID);
                int _catairlinfarname = dr.GetOrdinal(Resources.CatPAirlinesFareResources.PARAM_CATAIRLINFARNAME);
                //No se ingresaron nullables por que las columnas de las tablas no aceptan nulos
                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Value = dr.GetString(_catairlinfarid);
                    item.Text = string.Concat((dr.GetString(_catairlinfarid)), ' ', (dr.GetString(_catairlinfarname)));
                    //item.CatAirLinFarId = dr.GetString(_catairlinfarid);
                    //item.CatAirLinFarName = dr.GetString(_catairlinfarname);
                    airLinesFareList.Add(item);
                }

            }
            return airLinesFareList;


        }
    }
}
