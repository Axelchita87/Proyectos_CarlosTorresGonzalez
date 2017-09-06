using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Entities;

namespace MyCTS.DataAccess
{
    public class VolarisStateDAL
    {

        /// <summary>
        /// Gets the states by country.
        /// </summary>
        /// <param name="countryID">The country ID.</param>
        /// <returns></returns>
        public List<VolarisState> GetStatesByCountry(string countryID)
        {
            try
            {
                return GetStatesByCountry(countryID, CommonENT.MYCTSDB_CONNECTION);
            }
            catch (Exception)
            {
                try
                {
                    return GetStatesByCountry(countryID, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
                catch (Exception)
                {


                }

            }
            return new List<VolarisState>();

        }

        /// <summary>
        /// Gets the states by country.
        /// </summary>
        /// <param name="countryID">The country ID.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <returns></returns>
        public List<VolarisState> GetStatesByCountry(string countryID, string connectionString)
        {

            Database dataBase = DatabaseFactory.CreateDatabase(connectionString);
            DbCommand dataBaseCommand = dataBase.GetStoredProcCommand("GetVolarisStates");
            dataBase.AddInParameter(dataBaseCommand, "countryId", DbType.String, countryID);
            var states = new List<VolarisState>();
            using (IDataReader dataReader = dataBase.ExecuteReader(dataBaseCommand))
            {

                while (dataReader.Read())
                {

                    int idPosition = dataReader.GetOrdinal("CatCitId");
                    int namePosition = dataReader.GetOrdinal("CatCitName");
                    int countryId = dataReader.GetOrdinal("CatCitCouId");
                    var state = new VolarisState();
                    state.StateID = dataReader.GetString(countryId);
                    state.Id = dataReader.GetString(idPosition);
                    state.Name = dataReader.GetString(namePosition);
                    states.Add(state);

                }

            }
            return states;

        }

        public List<VolarisState> GetAllState(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand("GetVolarisCatStates");
            List<VolarisState> CatLineClassesList = new List<VolarisState>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _catairlinclaid = dr.GetOrdinal("Code");
                int _catairlinclaname = dr.GetOrdinal("Name");

                while (dr.Read())
                {
                    VolarisState item = new VolarisState();
                    item.StateID = dr.GetString(_catairlinclaid);
                    item.Name =  dr.GetString(_catairlinclaname);
                    CatLineClassesList.Add(item);
                }
            }
            return CatLineClassesList;
        }

        public List<ListItem> GetAllStatePredictive(string strToSearch,string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand("GetVolarisCatStatesPredictive");
            db.AddInParameter(dbCommand, "@StrToSearch", DbType.String, strToSearch);
            List<ListItem> CatLineClassesList = new List<ListItem>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _catairlinclaid = dr.GetOrdinal("Code");
                int _catairlinclaname = dr.GetOrdinal("Name");
                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Value = dr.GetString(_catairlinclaid);
                    item.Text = dr.GetString(_catairlinclaid) + " " + dr.GetString(_catairlinclaname);
                    item.Text2 = dr.GetString(_catairlinclaid);
                    CatLineClassesList.Add(item);
                }
            }
            return CatLineClassesList;
        }
    }
}
