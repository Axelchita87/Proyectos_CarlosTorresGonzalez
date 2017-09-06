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
    public class AirLineFareDAL
    {
        public List<AirLineFare> GetAirLineFare(string StrToSearch, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.AirLineFareResources.SP_GetAirLineFare);
            db.AddInParameter(dbCommand, Resources.AirLineFareResources.PARAM_QUERY, DbType.String, StrToSearch);

            List<AirLineFare> AirLineFareList = new List<AirLineFare>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _airlinealfaid = dr.GetOrdinal(Resources.AirLineFareResources.PARAM_CATAIRLINFARID);
                int _airlinename = dr.GetOrdinal(Resources.AirLineFareResources.PARAM_CATAIRLINFARNAME);
                int _ccaut = dr.GetOrdinal(Resources.AirLineFareResources.PARAM_CCAUT);
                int _ccman = dr.GetOrdinal(Resources.AirLineFareResources.PARAM_CCMAN);
                int _cash = dr.GetOrdinal(Resources.AirLineFareResources.PARAM_CASH);
                int _pmix = dr.GetOrdinal(Resources.AirLineFareResources.PARAM_PMIX);
                int _misc = dr.GetOrdinal(Resources.AirLineFareResources.PARAM_MISC);
                int _opmanual = dr.GetOrdinal(Resources.AirLineFareResources.PARAM_OPMANUAL);


                while (dr.Read())
                {
                    AirLineFare item = new AirLineFare();
                    item.CatAirLinFarId = dr.GetString(_airlinealfaid);
                    item.CatAirLinFarName = dr.GetString(_airlinename);
                    item.CCAut = dr.GetBoolean(_ccaut);
                    item.CCMan = dr.GetBoolean(_ccman);
                    item.Cash = dr.GetBoolean(_cash);
                    item.PMix = dr.GetBoolean(_pmix);
                    item.Misc = dr.GetBoolean(_misc);
                    item.OpManual = dr.GetBoolean(_opmanual);
                    AirLineFareList.Add(item);
                }

            }

            return AirLineFareList;
        }


        public AirLineFare GetOneAirLineFare(string airline, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.AirLineFareResources.SP_GetOneAirLineFare);
            db.AddInParameter(dbCommand, Resources.AirLineFareResources.PARAM_QUERY, DbType.String, airline);

            AirLineFare AirLineFare = new AirLineFare();

            try
            {
                using (IDataReader dr = db.ExecuteReader(dbCommand))
                {
                    int _airlinealfaid = dr.GetOrdinal(Resources.AirLineFareResources.PARAM_CATAIRLINFARID);
                    int _airlinename = dr.GetOrdinal(Resources.AirLineFareResources.PARAM_CATAIRLINFARNAME);
                    int _ccaut = dr.GetOrdinal(Resources.AirLineFareResources.PARAM_CCAUT);
                    int _ccman = dr.GetOrdinal(Resources.AirLineFareResources.PARAM_CCMAN);
                    int _cash = dr.GetOrdinal(Resources.AirLineFareResources.PARAM_CASH);
                    int _pmix = dr.GetOrdinal(Resources.AirLineFareResources.PARAM_PMIX);
                    int _misc = dr.GetOrdinal(Resources.AirLineFareResources.PARAM_MISC);
                    int _opmanual = dr.GetOrdinal(Resources.AirLineFareResources.PARAM_OPMANUAL);


                    if (dr.Read())
                    {
                        AirLineFare.CatAirLinFarId = dr.GetString(_airlinealfaid);
                        AirLineFare.CatAirLinFarName = dr.GetString(_airlinename);
                        AirLineFare.CCAut = dr.GetBoolean(_ccaut);
                        AirLineFare.CCMan = dr.GetBoolean(_ccman);
                        AirLineFare.Cash = dr.GetBoolean(_cash);
                        AirLineFare.PMix = dr.GetBoolean(_pmix);
                        AirLineFare.Misc = dr.GetBoolean(_misc);
                        AirLineFare.OpManual = dr.GetBoolean(_opmanual);
                    }
                }
            }
            catch { }

            return AirLineFare;
        }
    }
}
