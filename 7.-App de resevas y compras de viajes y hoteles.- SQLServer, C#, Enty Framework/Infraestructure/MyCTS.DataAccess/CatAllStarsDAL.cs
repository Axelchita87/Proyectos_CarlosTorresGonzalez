using System;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using MyCTS.Entities;
using MyCTS.Components.NullableHelper;

namespace MyCTS.DataAccess
{
    public class CatAllStarsDAL
    {
        public List<CatAllStars> GetAllStars(int OrgId, string name, string tipoBusqueda, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatAllStarsResources.SP_GetAllStars);
            db.AddInParameter(dbCommand, Resources.CatAllStarsResources.PARAM_ORG_ID, DbType.Int32, OrgId);
            db.AddInParameter(dbCommand, Resources.CatAllStarsResources.PARAM_NAME, DbType.String, name);
            db.AddInParameter(dbCommand, Resources.CatAllStarsResources.PARAM_TIPO_BUSQUEDA, DbType.String, tipoBusqueda);
            List<CatAllStars> AllStarsList = new List<CatAllStars>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _pccid = dr.GetOrdinal(Resources.CatAllStarsResources.PARAM_PCCID);
                int _starname = dr.GetOrdinal(Resources.CatAllStarsResources.PARAM_STARNAME);
                int _level = dr.GetOrdinal(Resources.CatAllStarsResources.PARAM_LEVEL);
                int _star1ref = dr.GetOrdinal(Resources.CatAllStarsResources.PARAM_STAR1REF);
                int _active = dr.GetOrdinal(Resources.CatAllStarsResources.PARAM_ACTIVE);
                int _isNew = dr.GetOrdinal(Resources.CatAllStarsResources.PARAM_IS_NEW);
                int _email = dr.GetOrdinal(Resources.CatAllStarsResources.PARAM_EMAIL);
                int _dk = dr.GetOrdinal(Resources.CatAllStarsResources.PARAM_DK);

                while (dr.Read())
                {
                    CatAllStars item = new CatAllStars();
                    item.PccId = (dr[_pccid] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_pccid);
                    item.StarName = (dr[_starname] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_starname);
                    item.Level = (dr[_level] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_level);
                    item.Star1Ref = (dr[_star1ref] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_star1ref);
                    item.Active = dr[_active] != DBNull.Value && dr.GetBoolean(_active);
                    item.IsNew = dr[_isNew] != DBNull.Value && dr.GetBoolean(_isNew);
                    string mail = (dr[_email] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_email); mail = mail.Replace('‡', ' ');
                    item.Email = mail;
                    item.DK = (dr[_dk] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_dk);
                    AllStarsList.Add(item);
                }
            }
            return AllStarsList;
        }

        public List<CatAllStars> GetAllStars(int OrgId, string name, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatAllStarsResources.SP_GetAllStars);
            db.AddInParameter(dbCommand, Resources.CatAllStarsResources.PARAM_ORG_ID, DbType.Int32, OrgId);
            db.AddInParameter(dbCommand, Resources.CatAllStarsResources.PARAM_NAME, DbType.String, name);

            List<CatAllStars> AllStarsList = new List<CatAllStars>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _pccid = dr.GetOrdinal(Resources.CatAllStarsResources.PARAM_PCCID);
                int _starname = dr.GetOrdinal(Resources.CatAllStarsResources.PARAM_STARNAME);
                int _level = dr.GetOrdinal(Resources.CatAllStarsResources.PARAM_LEVEL);
                int _star1ref = dr.GetOrdinal(Resources.CatAllStarsResources.PARAM_STAR1REF);
                int _active = dr.GetOrdinal(Resources.CatAllStarsResources.PARAM_ACTIVE);
                int _isNew = dr.GetOrdinal(Resources.CatAllStarsResources.PARAM_IS_NEW);
                int _email = dr.GetOrdinal(Resources.CatAllStarsResources.PARAM_EMAIL);
                int _dk = dr.GetOrdinal(Resources.CatAllStarsResources.PARAM_DK);

                while (dr.Read())
                {
                    CatAllStars item = new CatAllStars();
                    item.PccId = (dr[_pccid] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_pccid);
                    item.StarName = (dr[_starname] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_starname);
                    item.Level = (dr[_level] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_level);
                    item.Star1Ref = (dr[_star1ref] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_star1ref);
                    item.Active = dr[_active] != DBNull.Value && dr.GetBoolean(_active);
                    item.IsNew = dr[_isNew] != DBNull.Value && dr.GetBoolean(_isNew);
                    string mail = (dr[_email] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_email);
                    mail = mail.Replace('‡', ' ');
                    item.Email = mail;
                    item.DK = (dr[_dk] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_dk);
                    AllStarsList.Add(item);
                }
            }

            return AllStarsList;
        }



        public List<CatAllStars> GetProfiles2LevelByFirstLevel(int OrgId, string firstLevel, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatAllStarsResources.SP_GetProfiles2LevelByFirstLevel);
            db.AddInParameter(dbCommand, Resources.CatAllStarsResources.PARAM_ORG_ID, DbType.Int32, OrgId);
            db.AddInParameter(dbCommand, Resources.CatAllStarsResources.PARAM_LEVEL1, DbType.String, firstLevel);

            List<CatAllStars> AllStarsList = new List<CatAllStars>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _pccid = dr.GetOrdinal(Resources.CatAllStarsResources.PARAM_PCCID);
                int _starname = dr.GetOrdinal(Resources.CatAllStarsResources.PARAM_STAR2NAME);
                int _level = dr.GetOrdinal(Resources.CatAllStarsResources.PARAM_LEVEL);
                int _star1ref = dr.GetOrdinal(Resources.CatAllStarsResources.PARAM_STAR1REF);
                int _active = dr.GetOrdinal(Resources.CatAllStarsResources.PARAM_ACTIVE);
                int _isNew = dr.GetOrdinal(Resources.CatAllStarsResources.PARAM_IS_NEW);
                int _email = dr.GetOrdinal(Resources.CatAllStarsResources.PARAM_EMAIL);
                int _dk = dr.GetOrdinal(Resources.CatAllStarsResources.PARAM_DK);

                while (dr.Read())
                {
                    CatAllStars item = new CatAllStars();
                    item.PccId = (dr[_pccid] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_pccid);
                    item.StarName = (dr[_starname] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_starname);
                    item.Level = (dr[_level] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_level);
                    item.Star1Ref = (dr[_star1ref] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_star1ref);
                    item.Active = dr[_active] != DBNull.Value && dr.GetBoolean(_active);
                    item.IsNew = dr[_isNew] != DBNull.Value && dr.GetBoolean(_isNew);
                    string mail = (dr[_email] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_email);
                    mail = mail.Replace('‡', ' ');
                    item.Email = mail;
                    item.DK = (dr[_dk] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_dk);
                    AllStarsList.Add(item);
                }
            }

            return AllStarsList;
        }
    }
}
